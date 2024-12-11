// Creighton Newsom
// ViewAllDisclosures Page
using System;
using System.Collections.Generic;
using System.Linq;
using BLL;
using Models;

namespace Broker
{
    public class ViewAllDisclosuresBroker
    {
        // Create BLL Object
        ViewAllDisclosuresBLL objViewAllDisclosuresBLL = new ViewAllDisclosuresBLL();

        #region "GetOfficeTypeForFilerIDResponse"
        // FUNCTION POPULATES OFFICETYPES FOR THE FILTER DROPDOWN
        public IEnumerable<OfficeType> GetOfficeTypeForFilerIDResponse(String strElectYearID, String strFilerID)
        {
            IList<OfficeType> listOfficeType = new List<OfficeType>();

            listOfficeType = objViewAllDisclosuresBLL.mapGetOfficeTypeForFilerIDBLLResponse(strElectYearID, strFilerID).ToList();

            return listOfficeType;
        }
        #endregion

        #region "GetElectionTypeForFilerIDResponse"
        // THIS FUNCTION GETS THE DATA FOR THE ELECTIONTYPE FILTER DROPDOWN
        public IEnumerable<ElectionType> GetElectionTypeForFilerIDResponse(String strElectYearID, String strOfficeTypeID, String strCountyID, String strMunicipalityID, String strFilerID)
        {
            IList<ElectionType> listElectionType = new List<ElectionType>();

            listElectionType = objViewAllDisclosuresBLL.mapGetElectionTypeForFilerIDBLLResponse(strElectYearID, strOfficeTypeID, strCountyID, strMunicipalityID, strFilerID).ToList();

            return listElectionType;
        }
        #endregion

        #region "GetElectionDateResponse"
        // THIS FUNCTION GETS THE DATA FOR THE ELECTIONDATE FILTER DROPDOWN
        public IEnumerable<Election_Date> GetElectionDateResponse(string electionYearID, string electionTypeID, string officeTypeID, string filerID, string countyID, string municipalityID)
        {
            IList<Election_Date> listElectionDate = new List<Election_Date>();

            listElectionDate = objViewAllDisclosuresBLL.mapGetElectionDateBLLResponse(electionYearID, electionTypeID, officeTypeID, filerID, countyID, municipalityID).ToList();

            return listElectionDate;
        }
        #endregion

        #region "GetCountyResponse"
        // THIS FUNCTION GETS THE DATA FOR THE COUNTY FILTER DROPDOWN
        public IEnumerable<County> GetCountyResponse(int officeTypeID)
        {
            IList<County> listCounty = new List<County>();

            listCounty = objViewAllDisclosuresBLL.mapGetCountyBLLResponse(officeTypeID).ToList();

            return listCounty;
        }
        #endregion

        #region "GetMunicipalityResponse"
        // THIS FUNCTION GETS THE DATA FOR THE MUNICIPALITY FILTER DROPDOWN
        public IEnumerable<Municipality> GetMunicipalityResponse(int countyID)
        {
            IList<Municipality> listMunicipality = new List<Municipality>();

            listMunicipality = objViewAllDisclosuresBLL.mapGetMunicipalityBLLResponse(countyID).ToList();

            return listMunicipality;
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
            return objViewAllDisclosuresBLL.InsertSupportingDocument(strTransNumber, strFilingMethodID, strDocTypeID, strScanDocID, strFileType, strFileSize, strCreatedBy, strFilerID, strFilingsID);
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
            return objViewAllDisclosuresBLL.InsertSupportingDocumentPIDA(strTransNumber, strFilingMethodID, strCommunicationTypeID, strScanDocID, strFileType, strFileSize, strDateSubmitted, strComments, strCreatedBy, strFilerID, strFilingsID);
        }
        #endregion

        #region "UpdateSupportingDocumentPIDA"
        // FUNCTION DOES AN INSERT INTO THE SUPPORTINGDOCUMENTS TABLE
        // THIS GETS CALLED AFTER THE DOCUMENT IS UPLOADED TO CABINET
        // SCANDOCID IS THE NUMBER RETURNED FROM CABINET
        public String UpdateSupportingDocumentPIDA(
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
            return objViewAllDisclosuresBLL.UpdateSupportingDocumentPIDA(strSupportingDocID, strFilingMethodID, strCommTypeID, strScanDocID, strFileType, strFileSize, strDateSubmitted, strComments, strUserID);
        }
        #endregion

        #region "DeleteDisclosure"
        // IF IN PROD, SOFT DELETES A DISCLOSURE BY UPDATING FILING AND FILING TRANSACTION TABLES
        // IF IN TEMPORARY DATABASE, DOES A HARD DELETE
        public String DeleteDisclosure(String strFilingID, String strIsSubmitted, String strUserName, String strTransNumber)
        {
            return objViewAllDisclosuresBLL.DeleteDisclosure(strFilingID, strIsSubmitted, strUserName, strTransNumber);
        }
        #endregion

        #region "DeleteSupportingDocument"
        // SOFT DELETES A SUPPORTING DOCUMENT BY UPDATING R_STATUS
        public String DeleteSupportingDocument(String strSupportingDocumentID, String strUserName)
        {
            return objViewAllDisclosuresBLL.DeleteSupportingDocument(strSupportingDocumentID, strUserName);
        }
        #endregion

        #region "GetElectionYearForFilerID"
        // THIS FUNCTION GETS THE ELECTION YEAR FOR FILTER DROPDOWN
        public IList<ElectionYearModel> GetElectionYearForFilerID(String strFilerID)
        {
            IList<ElectionYearModel> lstElectionYearModel = new List<ElectionYearModel>();

            lstElectionYearModel = objViewAllDisclosuresBLL.mapGetElectionYearForFilerID(strFilerID);

            return lstElectionYearModel;
        }
        #endregion

        #region "GetDisclosureTypesForYearAndFilerIDDataResponse"
        // THIS FUNCTION GETS THE DISCLOSURETYPES FOR FILTER DROPDOWN
        public IList<DisclosureTypesModel> GetDisclosureTypesForYearAndFilerIDDataResponse(String strFilerID, String strElectionYearID, String strElectionTypeID, String strElectionDateID)
        {
            IList<DisclosureTypesModel> lstDisclosureTypesModel = new List<DisclosureTypesModel>();

            lstDisclosureTypesModel = objViewAllDisclosuresBLL.mapGetDisclosureTypesForYearAndFilerIDDataBLLResponse(strFilerID, strElectionYearID, strElectionTypeID, strElectionDateID);

            return lstDisclosureTypesModel;
        }
        #endregion

        #region "GetDisclosurePeriodDataResponse"
        // THIS FUNCTION GETS DISCLOSURE PERIODS FOR FILTER DROPDOWN	
        public IList<DisclosurePreiodModel> GetDisclosurePeriodsForYearAndFilerIDAndElectionType(String strFilerID, String strElectionYearID, String strElectionTypeID, String strFilingCatID, String strOfficeTypeID)
        {
            IList<DisclosurePreiodModel> lstDisclosurePreiodModel = new List<DisclosurePreiodModel>();

            lstDisclosurePreiodModel = objViewAllDisclosuresBLL.GetDisclosurePeriodsForYearAndFilerIDAndElectionType(strFilerID, strElectionYearID, strElectionTypeID, strFilingCatID, strOfficeTypeID);

            return lstDisclosurePreiodModel;
        }
        #endregion

        #region "GetDocumentTypesDataResponse"
        // GETS THE DOCUMENT TYPES (LETTER OF INDEBTEDNESS ETC)
        public IList<DocumentTypeModel> GetDocumentTypesDataResponse(String ApplicationID)
        {
            IList<DocumentTypeModel> lstDocumentTypeModel = new List<DocumentTypeModel>();

            lstDocumentTypeModel = objViewAllDisclosuresBLL.mapGetDocumentTypesDataBLLResponse(ApplicationID);

            return lstDocumentTypeModel;
        }
        #endregion

        #region "GetDisclosureGridDataResponse"
        // FUNCTION GETS THE DATA FOR THE DISCLOSURE GRID
        public IList<DisclosureGridModel> GetDisclosureGridDataResponse(String strFilerID, String strReportYearID, String strOfficeTypeID, String strCountyID, String strMunicipalityID, String strElectionTypeID, String strElectionDateID, String strDiclosureTypeID, String strDisclosurePeriodID)
        {
            IList<DisclosureGridModel> lstDisclosureGridModel = new List<DisclosureGridModel>();

            lstDisclosureGridModel = objViewAllDisclosuresBLL.mapGetDisclosureGridDataBLLResponse(strFilerID, strReportYearID, strOfficeTypeID, strCountyID, strMunicipalityID, strElectionTypeID, strElectionDateID, strDiclosureTypeID, strDisclosurePeriodID);

            return lstDisclosureGridModel;
        }
        #endregion

        #region "GetTransactionsGridDataBrokerResponse"
        // FUNCTION GETS THE DATA FOR THE TRANSACTION GRID
        public IList<TransactionGridModel> GetTransactionsGridDataBrokerResponse(String strFilingsID, String strPolCalDateID, String strAmended, String strR_Status, String strDateSubmitted, String strFilingCatID, String strTransNumber, String strCommTypeID)
        {
            IList<TransactionGridModel> lstTransactionsGridModel = new List<TransactionGridModel>();

            lstTransactionsGridModel = objViewAllDisclosuresBLL.mapGetTransactionsGridDataBLLResponse(strFilingsID, strPolCalDateID, strAmended, strR_Status, strDateSubmitted, strFilingCatID, strTransNumber, strCommTypeID);

            return lstTransactionsGridModel;
        }
        #endregion

        #region "GetSupportingDocumentsGridDataBrokerResponse"
        // FUNCTION GETS THE DATA FOR THE SUPPORTING DOCUMENTS GRID
        public IList<SupportingDocumentsGridModel> GetSupportingDocumentsGridDataBrokerResponse(String strTransNumber, String strFilingID)
        {
            IList<SupportingDocumentsGridModel> lstSupportingDocumentsGridModel = new List<SupportingDocumentsGridModel>();

            lstSupportingDocumentsGridModel = objViewAllDisclosuresBLL.mapGetSupportingDocumentsGridDataBLLResponse(strTransNumber, strFilingID);

            return lstSupportingDocumentsGridModel;
        }
        #endregion

        #region "GetPIDAGridData"
        // FUNCTION GETS THE DATA FOR THE SUPPORTING DOCUMENTS GRID
        public IList<PIDAGridModel> GetPIDAGridData(String strTransNumber)
        {
            IList<PIDAGridModel> lstPIDAGridModel = new List<PIDAGridModel>();

            lstPIDAGridModel = objViewAllDisclosuresBLL.GetPIDAGridData(strTransNumber);

            return lstPIDAGridModel;
        }
        #endregion

        #region "GetCommunicationTypes"
        // GETS THE COMMUNICATIONTYPES
        public IList<CommunicationTypeModel> GetCommunicationTypes()
        {
            IList<CommunicationTypeModel> lstCommunicationTypeModel = new List<CommunicationTypeModel>();

            lstCommunicationTypeModel = objViewAllDisclosuresBLL.GetCommunicationTypes();

            return lstCommunicationTypeModel;
        }
        #endregion

        #region "mapGetTransactionDetailsGridDataBrokerResponse"
        // FUNCTION GETS THE DATA FOR THE TRANSACTION DETAILS GRID
        public IList<TransactionDetailsGridModel> mapGetTransactionDetailsGridDataBrokerResponse(String strTransNumber, String strSubmitDate, String strFilerID)
        {
            IList<TransactionDetailsGridModel> lstTransactionDetailsGrid = new List<TransactionDetailsGridModel>();

            lstTransactionDetailsGrid = objViewAllDisclosuresBLL.mapGetTransactionDetailsGridDataBLLResponse(strTransNumber, strSubmitDate, strFilerID);

            return lstTransactionDetailsGrid;
        }
        #endregion

        #region "GetCampaignMaterialsGridData"
        // FUNCTION GETS THE DATA FOR THE TRANSACTION GRID
        public IList<CampaignMaterialsGridModel> GetCampaignMaterialsGridData(String strFilingsID, String strAmended)
        {
            IList<CampaignMaterialsGridModel> lstCampaignMaterialsGridModel = new List<CampaignMaterialsGridModel>();

            lstCampaignMaterialsGridModel = objViewAllDisclosuresBLL.GetCampaignMaterialsGridData(strFilingsID, strAmended);

            return lstCampaignMaterialsGridModel;
        }
        #endregion

        #region "TransactionHasDetails"
        // FUNCTION RETURNS TRUE OR FALSE 
        // DEPENDING ON WHETHER OR NOT THE SENT TRANS_NUMBER
        // HAS THE VALUE IN TRANS_MAPPING
        public String TransactionHasDetails(String strTransNumber, String filerID)
        {
            return objViewAllDisclosuresBLL.TransactionHasDetails(strTransNumber, filerID);
        }
        #endregion

        #region "DoesTransNumberExistInTemp"
        public String DoesTransNumberExistInTemp(String strTransNumber, String filerID)
        {
            return objViewAllDisclosuresBLL.DoesTransNumberExistInTemp(strTransNumber, filerID);
        }
        #endregion


        #region "GetElectionTypeForFilerIDResponse"
        // THIS FUNCTION GETS THE DATA FOR THE ELECTIONTYPE FILTER DROPDOWN
        public IEnumerable<ElectionType> GetElectionTypeForFilerIDForSubmit(String strElectYearID, String strOfficeTypeID, String strCountyID, String strMunicipalityID, String strFilerID)
        {
            IList<ElectionType> listElectionType = new List<ElectionType>();

            listElectionType = objViewAllDisclosuresBLL.mapGetElectionTypeForFilerIDBLLForSubmit(strElectYearID, strOfficeTypeID, strCountyID, strMunicipalityID, strFilerID).ToList();

            return listElectionType;
        }
        #endregion


        #region "GetElectionYearForFilerID"
        // THIS FUNCTION GETS THE ELECTION YEAR FOR FILTER DROPDOWN
        public IList<ElectionYearModel> GetElectionYearForFilerIDForSubmit(String strFilerID)
        {
            IList<ElectionYearModel> lstElectionYearModel = new List<ElectionYearModel>();

            lstElectionYearModel = objViewAllDisclosuresBLL.mapGetElectionYearForFilerIDForSubmit(strFilerID);

            return lstElectionYearModel;
        }
        #endregion
    }

}
