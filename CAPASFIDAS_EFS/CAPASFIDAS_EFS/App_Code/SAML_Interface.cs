using System;
using System.Web;
using System.IO;
using System.Xml;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;

namespace SAML_Interface
{
    public class SAMLResponse
    {
        public XmlDocument ParseSAMLResponse(string strEncodedSAMLResponse)
        {
            System.Text.ASCIIEncoding encencoder = new System.Text.ASCIIEncoding();
            string strCleanResponse = encencoder.GetString(Convert.FromBase64String(strEncodedSAMLResponse));

            XmlDocument xDoc = new XmlDocument();
            xDoc.PreserveWhitespace = true;
            xDoc.XmlResolver = null;
            xDoc.LoadXml(strCleanResponse);

            return xDoc;
        }

        /// <summary>Compares the signature in an XmlDoc with that of the identity provider. In this case Centrify/idaptive.</summary>
        /// <param name="xDoc">A type of XmlDocument from which we will compare signatures.</param>
        /// <returns>True if the signature property is true for a X509Certificate2</returns>
        public bool IsResponseValid(XmlDocument xDoc)
        {
            XmlNamespaceManager manager = new XmlNamespaceManager(xDoc.NameTable);

            //Adds the namespace ds with the xml digital signature definition. So we don't run into "collisions" when the same attrubute name is used.
            //In this case uri that defines the name space is from http://www.w3.org/2000/09/xmldsig#
            manager.AddNamespace("ds", SignedXml.XmlDsigNamespaceUrl);

            //Get the signature structure definition from w3.org
            XmlNodeList nodeList = xDoc.SelectNodes("//ds:Signature", manager);

            //Creates a signed xml from our xml signature.
            SignedXml signedXml = new SignedXml(xDoc);
            signedXml.LoadXml((XmlElement)nodeList[0]);

            X509Certificate2 cSigningCertificate = new X509Certificate2();

            //Gets the Centrify Certificate
            cSigningCertificate.Import(HttpContext.Current.Server.MapPath(".") + @"\Certificates\SignCertFromCentrify.cer");

            //Compares that they are the same.
            return signedXml.CheckSignature(cSigningCertificate, true);
        }

        public string ParseSAMLNameID(XmlDocument xDoc)
        {
            XmlNamespaceManager xManager = new XmlNamespaceManager(xDoc.NameTable);
            xManager.AddNamespace("ds", SignedXml.XmlDsigNamespaceUrl);
            xManager.AddNamespace("saml", "urn:oasis:names:tc:SAML:2.0:assertion");
            xManager.AddNamespace("samlp", "urn:oasis:names:tc:SAML:2.0:protocol");

            XmlNode node = xDoc.SelectSingleNode("/samlp:Response/saml:Assertion/saml:Subject/saml:NameID", xManager);
            return node.InnerText;
        }
    }

    public class SAMLRequest
    {
        public string GetSAMLRequest(string strACSUrl, string strIssuer)
        {
            using (StringWriter SWriter = new StringWriter())
            {
                XmlWriterSettings xWriterSettings = new XmlWriterSettings();
                xWriterSettings.OmitXmlDeclaration = true;

                using (XmlWriter xWriter = XmlWriter.Create(SWriter, xWriterSettings))
                {
                    xWriter.WriteStartElement("samlp", "AuthnRequest", "urn:oasis:names:tc:SAML:2.0:protocol");
                    xWriter.WriteAttributeString("ID", "_" + System.Guid.NewGuid().ToString());
                    xWriter.WriteAttributeString("Version", "2.0");
                    xWriter.WriteAttributeString("IssueInstant", DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));
                    xWriter.WriteAttributeString("ProtocolBinding", "urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST");
                    xWriter.WriteAttributeString("AssertionConsumerServiceURL", strACSUrl);

                    xWriter.WriteStartElement("saml", "Issuer", "urn:oasis:names:tc:SAML:2.0:assertion");
                    xWriter.WriteString(strIssuer);
                    xWriter.WriteEndElement();

                    xWriter.WriteStartElement("samlp", "NameIDPolicy", "urn:oasis:names:tc:SAML:2.0:protocol");
                    xWriter.WriteAttributeString("Format", "urn:oasis:names:tc:SAML:2.0:nameid-format:unspecified");
                    xWriter.WriteAttributeString("AllowCreate", "true");
                    xWriter.WriteEndElement();

                    xWriter.WriteStartElement("samlp", "RequestedAuthnContext", "urn:oasis:names:tc:SAML:2.0:protocol");
                    xWriter.WriteAttributeString("Comparison", "exact");
                    xWriter.WriteEndElement();

                    xWriter.WriteStartElement("saml", "AuthnContextClassRef", "urn:oasis:names:tc:SAML:2.0:assertion");
                    xWriter.WriteString("urn:oasis:names:tc:SAML:2.0:ac:classes:PasswordProtectedTransport");
                    xWriter.WriteEndElement();

                    xWriter.WriteEndElement();
                }

                byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(SWriter.ToString());
                return System.Convert.ToBase64String(toEncodeAsBytes);
            }
        }
    }
}
