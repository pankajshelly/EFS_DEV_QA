// Creighton Newsom
// ViewAllDisclosures Page
using System;
using System.Collections.Generic;
using BOE.CAPASFIDAS_EFS.Domain.EFSService;
using Models;

namespace DAL
{
    public class ViewAllDisclosuresDAL
    {
        // Create Service Object
        //CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient();

        #region "mapGetOfficeTypeForFilerIDDALResponse"
        // FUNCTION POPULATES OFFICETYPES FOR THE FILTER DROPDOWN
        internal IEnumerable<OfficeType> mapGetOfficeTypeForFilerIDDALResponse(String strElectYearID, String strFilerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<OfficeType> listOfficeType = new List<OfficeType>();
                    OfficeType objOfficeType;

                    var results = client.GetOfficeTypeForFilerIDWCF(strElectYearID, strFilerID);

                    foreach (var item in results)
                    {
                        objOfficeType = new OfficeType();
                        objOfficeType.OfficeTypeID = item.OfficeTypeId;
                        objOfficeType.OfficeTypeDesc = item.OfficeTypeDesc;
                        listOfficeType.Add(objOfficeType);
                    }
                    client.Close();
                    return listOfficeType;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion

        #region "mapGetElectionTypeForFilerIDDALResponse"
        // THIS FUNCTION GETS THE DATA FOR THE ELECTIONTYPE FILTER DROPDOWN	
        internal IEnumerable<ElectionType> mapGetElectionTypeForFilerIDDALResponse(String strElectYearID, String strOfficeTypeID, String strCountyID, String strMunicipalityID, String strFilerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ElectionType> listElectionType = new List<ElectionType>();
                    ElectionType objElectionType;

                    var results = client.GetElectionTypeForFilerIDWCF(strElectYearID, strOfficeTypeID, strCountyID, strMunicipalityID, strFilerID);

                    foreach (var item in results)
                    {
                        objElectionType = new ElectionType();
                        objElectionType.ElectionTypeID = item.ElectionTypeId;
                        objElectionType.ElectionTypeDesc = item.ElectionTypeDesc;
                        listElectionType.Add(objElectionType);
                    }
                    client.Close();
                    return listElectionType;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion

        #region "mapGetElectionDateDALResponse"
        // THIS FUNCTION GETS THE DATA FOR THE ELECTIONDATE FILTER DROPDOWN
        internal IEnumerable<Election_Date> mapGetElectionDateDALResponse(string electionYearID, string electionTypeID, string officeTypeID, string filerID, string countyID, string municipalityID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<Election_Date> listElectionDate = new List<Election_Date>();
                    Election_Date objElectionDate;

                    var results = client.GetElectionDateWCF(electionYearID, electionTypeID, officeTypeID, filerID, countyID, municipalityID);

                    foreach (var item in results)
                    {
                        objElectionDate = new Election_Date();
                        objElectionDate.ElectionDateId = item.ElectId;
                        objElectionDate.ElectionDate = item.ElectDate;
                        listElectionDate.Add(objElectionDate);
                    }
                    client.Close();
                    return listElectionDate;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion

        #region "mapGetCountyDALResponse"
        // THIS FUNCTION GETS THE DATA FOR THE COUNTY FILTER DROPDOWN
        internal IEnumerable<County> mapGetCountyDALResponse(int officeTypeID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<County> listCounty = new List<County>();
                    County objCounty;

                    var results = client.GetCountyWCF(officeTypeID);

                    foreach (var item in results)
                    {
                        objCounty = new County();
                        objCounty.CountyID = item.CountyId;
                        objCounty.CountyBoard = item.CountyDesc;
                        listCounty.Add(objCounty);
                    }
                    client.Close();
                    return listCounty;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion

        #region "mapGetMunicipalityDALResponse"
        // THIS FUNCTION GETS THE DATA FOR THE MUNICIPALITY FILTER DROPDOWN
        internal IEnumerable<Municipality> mapGetMunicipalityDALResponse(int countyID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<Municipality> listMunicipality = new List<Municipality>();
                    Municipality objMunicipality;

                    var results = client.GetMunicipalityWCF(countyID);

                    foreach (var item in results)
                    {
                        objMunicipality = new Municipality();
                        objMunicipality.MunicipalityID = item.MunicipalityId;
                        objMunicipality.MunicipalityDesc = item.MunicipalityDesc;
                        listMunicipality.Add(objMunicipality);
                    }
                    client.Close();
                    return listMunicipality;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion

        #region "InsertSupportingDocument"
        // FUNCTION DOES AN INSERT INTO THE SUPPORTINGDOCUMENTS TABLE
        // THIS GETS CALLED AFTER THE DOCUMENT IS UPLOADED TO CABINET
        // SCANDOCID IS THE NUMBER RETURNED FROM CABINET
        public String InsertSupportingDocument(
                                String strTransNumber,
                                String strFilingMethodID,
                                String strDocTypeID,
                                String strScanDocID,
                                String strFileType,
                                String strFileSize,
                                String strCreatedBy,
                                String strFilerID,
                                String strFilingsID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    return client.InsertSupportingDocument(strTransNumber, strFilingMethodID, strDocTypeID, strScanDocID, strFileType, strFileSize, strCreatedBy, strFilerID, strFilingsID);
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion

        #region "InsertSupportingDocumentPIDA"
        // FUNCTION DOES AN INSERT INTO THE SUPPORTINGDOCUMENTS TABLE
        // THIS GETS CALLED AFTER THE DOCUMENT IS UPLOADED TO CABINET
        // SCANDOCID IS THE NUMBER RETURNED FROM CABINET
        public String InsertSupportingDocumentPIDA(
                                String strTransNumber,
                                String strFilingMethodID,
                                String strCommunicationTypeID,
                                String strScanDocID,
                                String strFileType,
                                String strFileSize,
                                String strDateSubmitted,
                                String strComments,
                                String strCreatedBy,
                                String strFilerID,
                                String strFilingsID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    return client.InsertSupportingDocumentPIDA(strTransNumber, strFilingMethodID, strCommunicationTypeID, strScanDocID, strFileType, strFileSize, strDateSubmitted, strComments, strCreatedBy, strFilerID, strFilingsID);
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
           
            
        }
        #endregion

        #region "DeleteDisclosure"
        // IF IN PROD, SOFT DELETES A DISCLOSURE BY UPDATING FILING AND FILING TRANSACTION TABLES
        // IF IN TEMPORARY DATABASE, DOES A HARD DELETE
        public String DeleteDisclosure(String strFilingID, String strIsSubmitted, String strUserName, String strTransNumber)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    return client.DeleteDisclosure(strFilingID, strIsSubmitted, strUserName, strTransNumber);
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
           
            
        }
        #endregion

        #region "DeleteSupportingDocument"
        // SOFT DELETES A SUPPORTING DOCUMENT BY UPDATING R_STATUS
        public String DeleteSupportingDocument(String strSupportingDocumentID, String strUserName)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    return client.DeleteSupportingDocument(strSupportingDocumentID, strUserName);
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion

        #region "mapGetElectionYearDataForFilerID"
        // THIS FUNCTION GETS THE ELECTION YEAR FOR FILTER DROPDOWN
        internal IList<ElectionYearModel> mapGetElectionYearDataForFilerID(String strFilerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ElectionYearModel> lstElectionYearModel = new List<ElectionYearModel>();
                    ElectionYearModel objElectionYearModel;

                    var results = client.GetElectionYearDataForFilerID(strFilerID);

                    foreach (var item in results)
                    {
                        objElectionYearModel = new ElectionYearModel();
                        objElectionYearModel.ElectionYearId = item.ElectionYearId;
                        objElectionYearModel.ElectionYearValue = item.ElectionYearValue;
                        lstElectionYearModel.Add(objElectionYearModel);
                    }
                    client.Close();
                    return lstElectionYearModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion

        #region "mapmGetDisclosurePeriodDataDALResponse"
        // THIS FUNCTION GETS DISCLOSURE PERIODS FOR FILTER DROPDOWN
        internal IList<DisclosurePreiodModel> GetDisclosurePeriodsForYearAndFilerIDAndElectionType(String strFilerID, String strElectionYearID, String strElectionTypeID, String strFilingCatID, String strOfficeTypeID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<DisclosurePreiodModel> lstDisclosurePreiodModel = new List<DisclosurePreiodModel>();
                    DisclosurePreiodModel objDisclosurePreiodModel;

                    var results = client.GetDisclosurePeriodsForYearAndFilerIDAndElectionType(strFilerID, strElectionYearID, strElectionTypeID, strFilingCatID, strOfficeTypeID);

                    foreach (var item in results)
                    {
                        objDisclosurePreiodModel = new DisclosurePreiodModel();
                        objDisclosurePreiodModel.FilingTypeId = item.FilingTypeId;
                        objDisclosurePreiodModel.FilingDesc = item.FilingDesc;
                        objDisclosurePreiodModel.FilingAbbrev = item.FilingAbbrev;
                        lstDisclosurePreiodModel.Add(objDisclosurePreiodModel);
                    }
                    client.Close();
                    return lstDisclosurePreiodModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion

        #region "mapGetDisclosureTypesForYearAndFilerIDDataDALResponse"
        // THIS FUNCTION GETS THE DISCLOSURETYPES FOR FILTER DROPDOWN
        internal IList<DisclosureTypesModel> mapGetDisclosureTypesForYearAndFilerIDDataDALResponse(String strFilerID, String strElectionYearID, String strElectionTypeID, String strElectionDateID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<DisclosureTypesModel> lstDisclosureTypesModel = new List<DisclosureTypesModel>();
                    DisclosureTypesModel objDisclosureTypesModel;

                    var results = client.GetDisclosureTypesForYearAndFilerID(strFilerID, strElectionYearID, strElectionTypeID, strElectionDateID);

                    foreach (var item in results)
                    {
                        objDisclosureTypesModel = new DisclosureTypesModel();
                        objDisclosureTypesModel.DisclosureTypeId = item.DisclosureTypeId;
                        objDisclosureTypesModel.DisclosureTypeDesc = item.DisclosureTypeDesc;
                        objDisclosureTypesModel.DisclosureSubTypeDesc = item.DisclosureSubTypeDesc;
                        lstDisclosureTypesModel.Add(objDisclosureTypesModel);
                    }
                    client.Close();
                    return lstDisclosureTypesModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
           
            
        }
        #endregion

        #region "mapGetDocumentTypesDataDALResponse"
        // GETS THE DOCUMENT TYPES (LETTER OF INDEBTEDNESS ETC)
        internal IList<DocumentTypeModel> mapGetDocumentTypesDataDALResponse(String ApplicationID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<DocumentTypeModel> lstDocumentTypeModel = new List<DocumentTypeModel>();
                    DocumentTypeModel objDocumentTypeModel;

                    var results = client.GetDocumentTypes(ApplicationID);

                    foreach (var item in results)
                    {
                        objDocumentTypeModel = new DocumentTypeModel();
                        objDocumentTypeModel.DocumentTypeId = item.DocumentTypeID;
                        objDocumentTypeModel.DocumentTypeDesc = item.DocumentTypeDesc;
                        lstDocumentTypeModel.Add(objDocumentTypeModel);
                    }
                    client.Close();
                    return lstDocumentTypeModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
           
            
        }
        #endregion

        #region "mapGetDisclosureGridDataDALResponse"
        // FUNCTION GETS THE DATA FOR THE DISCLOSURE GRID
        internal IList<DisclosureGridModel> mapGetDisclosureGridDataDALResponse(String strFilerID, String strReportYearID, String strOfficeTypeID, String strCountyID, String strMunicipalityID, String strElectionTypeID, String strElectionDateID, String strDiclosureTypeID, String strDisclosurePeriodID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<DisclosureGridModel> lstDisclosureGrid = new List<DisclosureGridModel>();
                    DisclosureGridModel objDisclosureGrid;

                    var results = client.GetDisclosureGridData(strFilerID, strReportYearID, strOfficeTypeID, strCountyID, strMunicipalityID, strElectionTypeID, strElectionDateID, strDiclosureTypeID, strDisclosurePeriodID);
                    foreach (var item in results)
                    {
                        objDisclosureGrid = new DisclosureGridModel();
                        objDisclosureGrid.FilingsID = item.FilingsID;
                        objDisclosureGrid.PolCalDateID = item.PolCalDateID;
                        objDisclosureGrid.ReportYearID = item.ReportYearID;
                        objDisclosureGrid.OfficeTypeID = item.OfficeTypeID;
                        objDisclosureGrid.ElectTypeID = item.ElectTypeID;
                        objDisclosureGrid.DisclosureTypeID = item.DisclosureTypeID;
                        objDisclosureGrid.DisclosurePeriodID = item.DisclosurePeriodID;

                        objDisclosureGrid.Amended = item.Amended;
                        objDisclosureGrid.ReportYear = item.ReportYear;
                        objDisclosureGrid.OfficeType = item.OfficeType;
                        objDisclosureGrid.ElectionType = item.ElectionType;
                        objDisclosureGrid.ElectionDate = item.ElectionDate;
                        objDisclosureGrid.FilingDate = item.FilingDate;
                        objDisclosureGrid.DisclosureType = item.DisclosureType;
                        objDisclosureGrid.DateSubmitted = item.DateSubmitted;
                        objDisclosureGrid.DisclosurePeriod = item.DisclosurePeriod;
                        objDisclosureGrid.R_Status = item.R_Status;
                        objDisclosureGrid.TransNumber = item.TransNumber;
                        objDisclosureGrid.FilingAbbrev = item.FilingAbbrev;
                        objDisclosureGrid.ResigTermTypeID = item.ResigTermTypeID;
                        objDisclosureGrid.LoanLibNumber = item.LoanLibNumber;
                        objDisclosureGrid.County = item.County;
                        objDisclosureGrid.Municipality = item.Municipality;
                        objDisclosureGrid.CCDocType = item.CCDocType;
                        objDisclosureGrid.PCFBMonthlyFilingCheck = "";
                        lstDisclosureGrid.Add(objDisclosureGrid);
                    }
                    client.Close();
                    return lstDisclosureGrid;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion

        #region "mapGetTransactionGridDataDALResponse"
        // FUNCTION GETS THE DATA FOR THE TRANSACTION GRID
        internal IList<TransactionGridModel> mapGetTransactionGridDataDALResponse(String strFilingsID, String strPolCalDateID, String strAmended, String strR_Status, String strDateSubmitted, String strFilingCatID, String strTransNumber, String strCommTypeID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<TransactionGridModel> lstTransactionsGrid = new List<TransactionGridModel>();
                    TransactionGridModel objTransactionsGrid;

                    var results = client.GetTransactionsGridData(strFilingsID, strPolCalDateID, strAmended, strR_Status, strDateSubmitted, strFilingCatID, strTransNumber);
                    foreach (var item in results)
                    {
                        objTransactionsGrid = new TransactionGridModel();
                        objTransactionsGrid.Amount = item.Amount;
                        objTransactionsGrid.CheckNum = item.CheckNum;
                        objTransactionsGrid.City = item.City;
                        objTransactionsGrid.ContributionType = item.ContributionType;
                        objTransactionsGrid.ContributorCode = item.ContributorCode;
                        objTransactionsGrid.Country = item.Country;
                        objTransactionsGrid.County = item.County;
                        objTransactionsGrid.ElectionYear = item.ElectionYear;
                        objTransactionsGrid.EntityName = item.EntityName;
                        objTransactionsGrid.Explanation = item.Explanation;
                        objTransactionsGrid.FilingSchedID = item.FilingSchedID;
                        objTransactionsGrid.TransNumber = item.TransNumber;
                        objTransactionsGrid.FirstName = item.FirstName;
                        objTransactionsGrid.Itemized = item.Itemized;
                        objTransactionsGrid.LastName = item.LastName;
                        objTransactionsGrid.LoanerCode = item.LoanerCode;
                        objTransactionsGrid.Method = item.Method;
                        objTransactionsGrid.MiddleName = item.MiddleName;
                        objTransactionsGrid.Municipality = item.Municipality;
                        objTransactionsGrid.Office = item.Office;
                        objTransactionsGrid.District = item.District;
                        objTransactionsGrid.OriginalDate = item.OriginalDate;
                        objTransactionsGrid.OutStandingAmount = item.OutStandingAmount;
                        objTransactionsGrid.PurposeCode = item.PurposeCode;
                        objTransactionsGrid.ReceiptCode = item.ReceiptCode;
                        objTransactionsGrid.ReceiptType = item.ReceiptType;
                        objTransactionsGrid.State = item.State;
                        objTransactionsGrid.StreetAddress = item.StreetAddress;
                        objTransactionsGrid.TransactionDate = item.TransactionDate;
                        objTransactionsGrid.TransactionType = item.TransactionType;
                        objTransactionsGrid.TransferType = item.TransferType;
                        objTransactionsGrid.ZipCode = item.ZipCode;
                        objTransactionsGrid.Status = item.Status;
                        objTransactionsGrid.Amended = item.Amended;
                        objTransactionsGrid.DateSubmitted = item.DateSubmitted;
                        objTransactionsGrid.CreatedDate = item.CreatedDate;
                        objTransactionsGrid.TransMapping = item.TransMapping;
                        objTransactionsGrid.ContributorTypeID = item.ContributorTypeID;
                        objTransactionsGrid.LoanOtherID = item.LoanOtherID;
                        objTransactionsGrid.ReceiptCodeID = item.ReceiptCodeID;
                        objTransactionsGrid.R_Subcontractor = item.R_Subcontractor;
                        objTransactionsGrid.PurposeCodeID = item.PurposeCodeID;
                        objTransactionsGrid.R_Liability = item.R_Liability;
                        objTransactionsGrid.LoanLibNumber = item.LoanLibNumber;

                        if (strCommTypeID == "23")
                        {
                            objTransactionsGrid.TreasurerOccupation = "";
                            objTransactionsGrid.TreasurerEmployer = "";
                            objTransactionsGrid.TreasurerStreetAddress = "";
                            objTransactionsGrid.TreasurerCity = "";
                            objTransactionsGrid.TreasurerState = "";
                            objTransactionsGrid.TreasurerZipCode = "";
                        }
                        else
                        {
                            objTransactionsGrid.TreasurerOccupation = item.TreasurerOccupation;
                            objTransactionsGrid.TreasurerEmployer = item.TreasurerEmployer;
                            objTransactionsGrid.TreasurerStreetAddress = item.TreasurerStreetAddress;
                            objTransactionsGrid.TreasurerCity = item.TreasurerCity;
                            objTransactionsGrid.TreasurerState = item.TreasurerState;
                            objTransactionsGrid.TreasurerZipCode = item.TreasurerZipCode;
                        }
                        objTransactionsGrid.ContributionType = item.ContributionType;
                        objTransactionsGrid.ContributorName = item.ContributorName;
                        objTransactionsGrid.ContributorOccupation = item.ContributorOccupation;
                        objTransactionsGrid.ContributorEmployer = item.ContributorEmployer;
                        objTransactionsGrid.IEDescription = item.IEDescription;
                        objTransactionsGrid.CandidateNameBallotPropReference = item.CandidateNameBallotPropReference;
                        objTransactionsGrid.Supported = item.Supported;
                        objTransactionsGrid.RClaim = item.RClaim;
                        objTransactionsGrid.InDistrict = item.InDistrict;
                        objTransactionsGrid.RMinor = item.RMinor;
                        objTransactionsGrid.RVendor = item.RVendor;
                        objTransactionsGrid.RLobbyist = item.RLobbyist;
                        objTransactionsGrid.EmployerName = item.TreasurerEmployer;
                        objTransactionsGrid.EmployerOccupation = item.TreasurerOccupation;
                        objTransactionsGrid.TreaAddress = item.TreaAddress;
                        objTransactionsGrid.TreaAddr1 = item.TreaAddr1;
                        objTransactionsGrid.TreaCity = item.TreaCity;
                        objTransactionsGrid.TreaState = item.TreaState;
                        objTransactionsGrid.TreaZipCode = item.TreaZipCode;
                        objTransactionsGrid.RContributions = item.RContributions;

                        lstTransactionsGrid.Add(objTransactionsGrid);
                    }
                    client.Close();
                    return lstTransactionsGrid;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
           
            
        }
        #endregion

        #region "mapGetSupportingDocumentsDataDALResponse"
        // FUNCTION GETS THE DATA FOR THE SUPPORTING DOCUMENTS GRID
        public IList<SupportingDocumentsGridModel> mapGetSupportingDocumentsGridDataDALResponse(String strTransNumber, string strFilingID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<SupportingDocumentsGridModel> lstSupportingDocumentsGrid = new List<SupportingDocumentsGridModel>();
                    SupportingDocumentsGridModel objSupportingDocumentsGrid;

                    var results = client.GetSupportingDocumentsGridData(strTransNumber, strFilingID);


                    foreach (var item in results)
                    {
                        objSupportingDocumentsGrid = new SupportingDocumentsGridModel();
                        objSupportingDocumentsGrid.SupportingDocID = item.SupportingDocID;
                        objSupportingDocumentsGrid.ScanDocID = item.ScanDocID;
                        objSupportingDocumentsGrid.DateReceived = item.DateReceived;
                        objSupportingDocumentsGrid.DocumentType = item.DocumentType;
                        objSupportingDocumentsGrid.FileType = item.FileType;
                        objSupportingDocumentsGrid.FileSize = item.FileSize;
                        objSupportingDocumentsGrid.FilingMethod = item.FilingMethod;
                        //add object to list
                        lstSupportingDocumentsGrid.Add(objSupportingDocumentsGrid);
                    }
                    client.Close();
                    return lstSupportingDocumentsGrid;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        #endregion

        #region "GetTransactionDetailsGridData"
        public IList<TransactionDetailsGridModel> GetTransactionDetailsGridData(String strTransNumber, String strSubmitDate, String strFilerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<TransactionDetailsGridModel> lstTransactionDetailsGrid = new List<TransactionDetailsGridModel>();
                    TransactionDetailsGridModel objTransactionDetailsGrid;

                    var results = client.GetTransactionDetailsGridData(strTransNumber, strSubmitDate, strFilerID);

                    foreach (var item in results)
                    {
                        objTransactionDetailsGrid = new TransactionDetailsGridModel();
                        objTransactionDetailsGrid.Amount = item.Amount;
                        objTransactionDetailsGrid.Explanation = item.Explanation;
                        objTransactionDetailsGrid.FilingEntityCity = item.FilingEntityCity;
                        objTransactionDetailsGrid.FilingEntityCountry = item.FilingEntityCountry;
                        objTransactionDetailsGrid.FilingEntityFirstName = item.FilingEntityFirstName;
                        objTransactionDetailsGrid.FilingEntityID = item.FilingEntityID;
                        objTransactionDetailsGrid.FilingEntityLastName = item.FilingEntityLastName;
                        objTransactionDetailsGrid.FilingEntityMiddleName = item.FilingEntityMiddleName;
                        objTransactionDetailsGrid.FilingEntityName = item.FilingEntityName;
                        objTransactionDetailsGrid.FilingEntityState = item.FilingEntityState;
                        objTransactionDetailsGrid.FilingEntityStreetAddress = item.FilingEntityStreetAddress;
                        objTransactionDetailsGrid.FilingEntityZip = item.FilingEntityZip;
                        objTransactionDetailsGrid.Itemized = item.Itemized;
                        objTransactionDetailsGrid.PayDate = item.PayDate;
                        objTransactionDetailsGrid.CreatedDate = item.CreatedDate;

                        objTransactionDetailsGrid.PurposeCode = item.PurposeCode;
                        objTransactionDetailsGrid.TreasurerEmployer = item.TreasurerEmployer;
                        objTransactionDetailsGrid.TreasurerOccupation = item.TreasurerOccupation;
                        objTransactionDetailsGrid.TreaAddress = item.TreaAddress;
                        objTransactionDetailsGrid.TreaAddr1 = item.TreaAddr1;
                        objTransactionDetailsGrid.TreaCity = item.TreaCity;
                        objTransactionDetailsGrid.TreaState = item.TreaState;
                        objTransactionDetailsGrid.TreaZipCode = item.TreaZipCode;
                        objTransactionDetailsGrid.RContributions = item.RContributions;

                        //add object to list
                        lstTransactionDetailsGrid.Add(objTransactionDetailsGrid);
                    }
                    client.Close();
                    return lstTransactionDetailsGrid;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
           
            
        }
        #endregion

        #region "GetCampaignMaterialsGridData"
        // GETS THE DATA FOR THE CAMPAIGN MATERIALS GRID
        public IList<CampaignMaterialsGridModel> GetCampaignMaterialsGridData(String strFilingsID, String strAmended)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<CampaignMaterialsGridModel> lstCampaignMaterialsGrid = new List<CampaignMaterialsGridModel>();
                    CampaignMaterialsGridModel objCampaignMaterialsGrid;

                    var results = client.GetCampaignMaterialsGridData(strFilingsID, strAmended);

                    foreach (var item in results)
                    {
                        objCampaignMaterialsGrid = new CampaignMaterialsGridModel();
                        objCampaignMaterialsGrid.CampaignMaterialID = item.CampaignMaterialID;
                        objCampaignMaterialsGrid.FilingMethodID = item.FilingMethodID;
                        objCampaignMaterialsGrid.ScanDocID = item.ScanDocID;
                        objCampaignMaterialsGrid.DateSubmitted = item.DateSubmitted;
                        objCampaignMaterialsGrid.CampaignMaterialDesc = item.CampaignMaterialDesc;
                        objCampaignMaterialsGrid.FileSize = item.FileSize;
                        objCampaignMaterialsGrid.FileType = item.FileType;
                        objCampaignMaterialsGrid.FilingMethodDesc = item.FilingMethodDesc;
                        objCampaignMaterialsGrid.CreatedDate = item.CreatedDate;
                        objCampaignMaterialsGrid.CampaignMaterialAvailable = item.CampaignMaterialAvailable;

                        //add object to list
                        lstCampaignMaterialsGrid.Add(objCampaignMaterialsGrid);
                    }
                    client.Close();
                    return lstCampaignMaterialsGrid;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        #endregion

        #region "TransactionHasDetails"
        // FUNCTION RETURNS TRUE OR FALSE 
        // DEPENDING ON WHETHER OR NOT THE SENT TRANS_NUMBER
        // HAS THE VALUE IN TRANS_MAPPING
        public String TransactionHasDetails(String strTransNumber, String filerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    return client.TransactionHasDetails(strTransNumber, filerID);
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
          
            
        }
        #endregion

        #region "DoesTransNumberExistInTemp"
        public String DoesTransNumberExistInTemp(String strTransNumber, String filerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    return client.DoesTransNumberExistInTemp(strTransNumber, filerID);
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion

        #region "GetPIDAGridData"
        // FUNCTION GETS THE DATA FOR THE SUPPORTING DOCUMENTS GRID
        public IList<PIDAGridModel> GetPIDAGridData(String strTransNumber)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<PIDAGridModel> lstPIDAGrid = new List<PIDAGridModel>();
                    PIDAGridModel objPIDAGrid;

                    var results = client.GetPIDAGridData(strTransNumber);

                    foreach (var item in results)
                    {
                        objPIDAGrid = new PIDAGridModel();
                        objPIDAGrid.SupportingDocID = item.SupportingDocID;
                        objPIDAGrid.ScanDocID = item.ScanDocID;
                        objPIDAGrid.CommunicationTypeID = item.CommunicationTypeID;
                        objPIDAGrid.FileSize = item.FileSize;
                        objPIDAGrid.FileType = item.FileType;

                        objPIDAGrid.DateSubmitted = item.DateSubmitted;
                        objPIDAGrid.CommunicationType = item.CommunicationType;

                        objPIDAGrid.Description = item.Description;
                        objPIDAGrid.SubmittedBy = item.SubmittedBy;

                        //add object to list
                        lstPIDAGrid.Add(objPIDAGrid);
                    }
                    client.Close();
                    return lstPIDAGrid;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
           
            
        }
        #endregion

        #region "GetCommunicationTypes"
        // GETS THE DOCUMENT TYPES (LETTER OF INDEBTEDNESS ETC)
        public IList<CommunicationTypeModel> GetCommunicationTypes()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<CommunicationTypeModel> lstCommunicationTypes = new List<CommunicationTypeModel>();
                    CommunicationTypeModel objCommunicationType;

                    var results = client.GetCommunicationTypes();
                    foreach (var item in results)
                    {
                        objCommunicationType = new CommunicationTypeModel();
                        objCommunicationType.CommunicationTypeID = item.CommunicationTypeID;
                        objCommunicationType.CommunicationTypeDesc = item.CommunicationTypeDesc;
                        lstCommunicationTypes.Add(objCommunicationType);
                    }
                    client.Close();
                    return lstCommunicationTypes;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion

        #region "UpdateSupportingDocumentPIDA"
        // FUNCTION DOES AN INSERT INTO THE SUPPORTINGDOCUMENTS TABLE
        // THIS GETS CALLED AFTER THE DOCUMENT IS UPLOADED TO CABINET
        // SCANDOCID IS THE NUMBER RETURNED FROM CABINET
        internal String UpdateSupportingDocumentPIDA(
            String strSupportingDocID,
            String strFilingMethodID,
            String strCommTypeID,
            String strScanDocID,
            String strFileType,
            String strFileSize,
            String strDateSubmitted,
            String strComments,
            String strUserID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    return client.UpdateSupportingDocumentPIDA(strSupportingDocID, strFilingMethodID, strCommTypeID, strScanDocID, strFileType, strFileSize, strDateSubmitted, strComments, strUserID);
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
           
            
        }
        #endregion

        #region "mapGetElectionTypeForFilerIDDALResponse"
        // THIS FUNCTION GETS THE DATA FOR THE ELECTIONTYPE FILTER DROPDOWN	
        internal IEnumerable<ElectionType> mapGetElectionTypeForFilerIDDALForSubmit(String strElectYearID, String strOfficeTypeID, String strCountyID, String strMunicipalityID, String strFilerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ElectionType> listElectionType = new List<ElectionType>();
                    ElectionType objElectionType;

                    var results = client.GetElectionTypeForFilerIDForSubmit(strElectYearID, strOfficeTypeID, strCountyID, strMunicipalityID, strFilerID);

                    foreach (var item in results)
                    {
                        objElectionType = new ElectionType();
                        objElectionType.ElectionTypeID = item.ElectionTypeId;
                        objElectionType.ElectionTypeDesc = item.ElectionTypeDesc;
                        listElectionType.Add(objElectionType);
                    }
                    client.Close();
                    return listElectionType;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion

        #region "mapGetElectionYearDataForFilerID"
        // THIS FUNCTION GETS THE ELECTION YEAR FOR FILTER DROPDOWN
        internal IList<ElectionYearModel> mapGetElectionYearDataForFilerIDForSubmit(String strFilerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ElectionYearModel> lstElectionYearModel = new List<ElectionYearModel>();
                    ElectionYearModel objElectionYearModel;

                    var results = client.GetElectionYearDataForFilerIDForSubmit(strFilerID);

                    foreach (var item in results)
                    {
                        objElectionYearModel = new ElectionYearModel();
                        objElectionYearModel.ElectionYearId = item.ElectionYearId;
                        objElectionYearModel.ElectionYearValue = item.ElectionYearValue;
                        lstElectionYearModel.Add(objElectionYearModel);
                    }
                    client.Close();
                    return lstElectionYearModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }

            }
           
            
        }
        #endregion
    }
}
