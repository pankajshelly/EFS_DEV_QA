// Creighton Newsom
// ViewAllDisclosures Page
using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Models;

namespace BLL
{
    public class ViewAllDisclosuresBLL
    {
        // Create DAL Object
        ViewAllDisclosuresDAL objViewAllDisclosuresDAL = new ViewAllDisclosuresDAL();

        #region "mapGetOfficeTypeForFilerIDBLLResponse"
        // FUNCTION POPULATES OFFICETYPES FOR THE FILTER DROPDOWN
        internal IEnumerable<OfficeType> mapGetOfficeTypeForFilerIDBLLResponse(String strElectYearID, String strFilerID)
        {
            IList<OfficeType> listOfficeType = new List<OfficeType>();

            listOfficeType = objViewAllDisclosuresDAL.mapGetOfficeTypeForFilerIDDALResponse(strElectYearID, strFilerID).ToList();

            return listOfficeType;
        }
        #endregion

        #region "mapGetElectionTypeForFilerIDBLLResponse"
        // THIS FUNCTION GETS THE DATA FOR THE ELECTIONTYPE FILTER DROPDOWN	
        internal IEnumerable<ElectionType> mapGetElectionTypeForFilerIDBLLResponse(String strElectYearID, String strOfficeTypeID, String strCountyID, String strMunicipalityID, String strFilerID)
        {
            IList<ElectionType> listElectionType = new List<ElectionType>();

            listElectionType = objViewAllDisclosuresDAL.mapGetElectionTypeForFilerIDDALResponse(strElectYearID, strOfficeTypeID, strCountyID, strMunicipalityID, strFilerID).ToList();

            return listElectionType;
        }
        #endregion

        #region "mapGetElectionDateBLLResponse"
        // THIS FUNCTION GETS THE DATA FOR THE ELECTIONDATE FILTER DROPDOWN	
        internal IEnumerable<Election_Date> mapGetElectionDateBLLResponse(string electionYearID, string electionTypeID, string officeTypeID, string filerID, string countyID, string municipalityID)
        {
            IList<Election_Date> listElectionDate = new List<Election_Date>();

            listElectionDate = objViewAllDisclosuresDAL.mapGetElectionDateDALResponse(electionYearID, electionTypeID, officeTypeID, filerID, countyID, municipalityID).ToList();

            return listElectionDate;
        }
        #endregion

        #region "mapGetCountyBLLResponse"
        // THIS FUNCTION GETS THE DATA FOR THE COUNTY FILTER DROPDOWN
        internal IEnumerable<County> mapGetCountyBLLResponse(int officeTypeID)
        {
            IList<County> listCounty = new List<County>();

            listCounty = objViewAllDisclosuresDAL.mapGetCountyDALResponse(officeTypeID).ToList();

            return listCounty;
        }
        #endregion

        #region "mapGetMunicipalityBLLResponse"
        // THIS FUNCTION GETS THE DATA FOR THE MUNICIPALITY FILTER DROPDOWN
        internal IEnumerable<Municipality> mapGetMunicipalityBLLResponse(int countyID)
        {
            IList<Municipality> listMunicipality = new List<Municipality>();

            listMunicipality = objViewAllDisclosuresDAL.mapGetMunicipalityDALResponse(countyID).ToList();

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
            return objViewAllDisclosuresDAL.InsertSupportingDocument(strTransNumber, strFilingMethodID, strDocTypeID, strScanDocID, strFileType, strFileSize, strCreatedBy, strFilerID, strFilingsID);
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
            return objViewAllDisclosuresDAL.InsertSupportingDocumentPIDA(strTransNumber, strFilingMethodID, strCommunicationTypeID, strScanDocID, strFileType, strFileSize, strDateSubmitted, strComments, strCreatedBy, strFilerID, strFilingsID);
        }
        #endregion

        #region "DeleteDisclosure"
        // IF IN PROD, SOFT DELETES A DISCLOSURE BY UPDATING FILING AND FILING TRANSACTION TABLES
        // IF IN TEMPORARY DATABASE, DOES A HARD DELETE
        public String DeleteDisclosure(String strFilingID, String strIsSubmitted, String strUserName, String strTransNumber)
        {
            return objViewAllDisclosuresDAL.DeleteDisclosure(strFilingID, strIsSubmitted, strUserName, strTransNumber);
        }
        #endregion

        #region "DeleteSupportingDocument"
        // SOFT DELETES A SUPPORTING DOCUMENT BY UPDATING R_STATUS
        public String DeleteSupportingDocument(String strSupportingDocumentID, String strUserName)
        {
            return objViewAllDisclosuresDAL.DeleteSupportingDocument(strSupportingDocumentID, strUserName);
        }
        #endregion

        #region "mapGetElectionYearForFilerID"
        // THIS FUNCTION GETS THE ELECTION YEAR FOR FILTER DROPDOWN
        internal IList<ElectionYearModel> mapGetElectionYearForFilerID(String strFilerID)
        {
            IList<ElectionYearModel> lstElectionYearModel = new List<ElectionYearModel>();

            lstElectionYearModel = objViewAllDisclosuresDAL.mapGetElectionYearDataForFilerID(strFilerID);

            return lstElectionYearModel;
        }
        #endregion

        #region "mapGetDisclosurePeriodDataBLLResponse"
        // THIS FUNCTION GETS DISCLOSURE PERIODS FOR FILTER DROPDOWN
        internal IList<DisclosurePreiodModel> GetDisclosurePeriodsForYearAndFilerIDAndElectionType(String strFilerID, String strElectionYearID, String strElectionTypeID, String strFilingCatID, String strOfficeTypeID)
        {
            IList<DisclosurePreiodModel> lstDisclosurePreiodModel = new List<DisclosurePreiodModel>();

            lstDisclosurePreiodModel = objViewAllDisclosuresDAL.GetDisclosurePeriodsForYearAndFilerIDAndElectionType(strFilerID, strElectionYearID, strElectionTypeID, strFilingCatID, strOfficeTypeID);

            return lstDisclosurePreiodModel;
        }
        #endregion

        #region "mapGetDisclosureTypesForYearAndFilerIDDataBLLResponse"
        // THIS FUNCTION GETS THE DISCLOSURETYPES FOR FILTER DROPDOWN
        internal IList<DisclosureTypesModel> mapGetDisclosureTypesForYearAndFilerIDDataBLLResponse(String strFilerID, String strElectionYearID, String strElectionTypeID, String strElectionDateID)
        {
            IList<DisclosureTypesModel> lstDisclosureTypesModel = new List<DisclosureTypesModel>();

            lstDisclosureTypesModel = objViewAllDisclosuresDAL.mapGetDisclosureTypesForYearAndFilerIDDataDALResponse(strFilerID, strElectionYearID, strElectionTypeID, strElectionDateID);

            return lstDisclosureTypesModel;
        }
        #endregion

        #region "mapGetDocumentTypeDataBLLResponse"
        // GETS THE DOCUMENT TYPES (LETTER OF INDEBTEDNESS ETC)
        internal IList<DocumentTypeModel> mapGetDocumentTypesDataBLLResponse(String ApplicationID)
        {
            IList<DocumentTypeModel> lstDocumentTypeModel = new List<DocumentTypeModel>();

            lstDocumentTypeModel = objViewAllDisclosuresDAL.mapGetDocumentTypesDataDALResponse(ApplicationID);

            return lstDocumentTypeModel;
        }
        #endregion

        #region "mapGetDisclosureGridDataBLLResponse"
        // FUNCTION GETS THE DATA FOR THE DISCLOSURE GRID
        internal IList<DisclosureGridModel> mapGetDisclosureGridDataBLLResponse(String strFilerID, String strReportYearID, String strOfficeTypeID, String strCountyID, String strMunicipalityID, String strElectionTypeID, String strElectionDateID, String strDiclosureTypeID, String strDisclosurePeriodID)
        {
            IList<DisclosureGridModel> lstDisclosureGridModel = new List<DisclosureGridModel>();

            lstDisclosureGridModel = objViewAllDisclosuresDAL.mapGetDisclosureGridDataDALResponse(strFilerID, strReportYearID, strOfficeTypeID, strCountyID, strMunicipalityID, strElectionTypeID, strElectionDateID, strDiclosureTypeID, strDisclosurePeriodID);

            return lstDisclosureGridModel;
        }
        #endregion

        #region "mapGetTransactionsGridDataBLLResponse"
        // FUNCTION GETS THE DATA FOR THE TRANSACTION GRID
        internal IList<TransactionGridModel> mapGetTransactionsGridDataBLLResponse(String strFilingsID, String strPolCalDateID, String strAmended, String strR_Status, String strDateSubmitted, String strFilingCatID, String strTransNumber, String strCommTypeID)
        {
            IList<TransactionGridModel> lstTransactionsGridModel = new List<TransactionGridModel>();

            lstTransactionsGridModel = objViewAllDisclosuresDAL.mapGetTransactionGridDataDALResponse(strFilingsID, strPolCalDateID, strAmended, strR_Status, strDateSubmitted, strFilingCatID, strTransNumber, strCommTypeID);

            return lstTransactionsGridModel;
        }
        #endregion

        #region "GetCampaignMaterialsGridData"
        // FUNCTION GETS THE DATA FOR THE TRANSACTION GRID
        internal IList<CampaignMaterialsGridModel> GetCampaignMaterialsGridData(String strFilingsID, String strAmended)
        {
            IList<CampaignMaterialsGridModel> lstCampaignMaterialsGridModel = new List<CampaignMaterialsGridModel>();

            lstCampaignMaterialsGridModel = objViewAllDisclosuresDAL.GetCampaignMaterialsGridData(strFilingsID, strAmended);

            return lstCampaignMaterialsGridModel;
        }
        #endregion

        #region "mapGetSupportingDocumentsGridDataBLLResponse"
        // FUNCTION GETS THE DATA FOR THE SUPPORTING DOCUMENTS GRID
        internal IList<SupportingDocumentsGridModel> mapGetSupportingDocumentsGridDataBLLResponse(String strTransNumber, String strFilingID)
        {
            IList<SupportingDocumentsGridModel> lstSupportingDocumentsGridModel = new List<SupportingDocumentsGridModel>();

            lstSupportingDocumentsGridModel = objViewAllDisclosuresDAL.mapGetSupportingDocumentsGridDataDALResponse(strTransNumber, strFilingID);

            return lstSupportingDocumentsGridModel;
        }
        #endregion

        #region "mapGetTransactionDetailsGridDataBLLResponse"
        // FUNCTION GETS THE DATA FOR THE TRANSACTION DETAILS GRID
        internal IList<TransactionDetailsGridModel> mapGetTransactionDetailsGridDataBLLResponse(String strTransNumber, String strSubmitDate, String strFilerID)
        {
            IList<TransactionDetailsGridModel> lstTransactionDetailsGrid = new List<TransactionDetailsGridModel>();

            lstTransactionDetailsGrid = objViewAllDisclosuresDAL.GetTransactionDetailsGridData(strTransNumber, strSubmitDate, strFilerID);

            return lstTransactionDetailsGrid;
        }
        #endregion

        #region "TransactionHasDetails"
        // FUNCTION RETURNS TRUE OR FALSE 
        // DEPENDING ON WHETHER OR NOT THE SENT TRANS_NUMBER
        // HAS THE VALUE IN TRANS_MAPPING
        public String TransactionHasDetails(String strTransNumber, String filerID)
        {
            return objViewAllDisclosuresDAL.TransactionHasDetails(strTransNumber, filerID);
        }
        #endregion

        #region "DoesTransNumberExistInTemp"
        public String DoesTransNumberExistInTemp(String strTransNumber, String filerID)
        {
            return objViewAllDisclosuresDAL.DoesTransNumberExistInTemp(strTransNumber, filerID);
        }
        #endregion

        #region "GetPIDAGridData"
        // FUNCTION GETS THE DATA FOR THE SUPPORTING DOCUMENTS GRID
        internal IList<PIDAGridModel> GetPIDAGridData(String strTransNumber)
        {
            IList<PIDAGridModel> lstPIDAGridModel = new List<PIDAGridModel>();

            lstPIDAGridModel = objViewAllDisclosuresDAL.GetPIDAGridData(strTransNumber);

            return lstPIDAGridModel;
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
            return objViewAllDisclosuresDAL.UpdateSupportingDocumentPIDA(strSupportingDocID, strFilingMethodID, strCommTypeID, strScanDocID, strFileType, strFileSize, strDateSubmitted, strComments, strUserID);
        }
        #endregion

        #region "GetCommunicationTypes"
        // GETS THE COMMUNICATIONTYPES
        internal IList<CommunicationTypeModel> GetCommunicationTypes()
        {
            IList<CommunicationTypeModel> lstCommunicationTypeModel = new List<CommunicationTypeModel>();

            lstCommunicationTypeModel = objViewAllDisclosuresDAL.GetCommunicationTypes();

            return lstCommunicationTypeModel;
        }
        #endregion

        #region "mapGetElectionTypeForFilerIDBLLResponse"
        // THIS FUNCTION GETS THE DATA FOR THE ELECTIONTYPE FILTER DROPDOWN	
        internal IEnumerable<ElectionType> mapGetElectionTypeForFilerIDBLLForSubmit(String strElectYearID, String strOfficeTypeID, String strCountyID, String strMunicipalityID, String strFilerID)
        {
            IList<ElectionType> listElectionType = new List<ElectionType>();

            listElectionType = objViewAllDisclosuresDAL.mapGetElectionTypeForFilerIDDALForSubmit(strElectYearID, strOfficeTypeID, strCountyID, strMunicipalityID, strFilerID).ToList();

            return listElectionType;
        }
        #endregion

        #region "mapGetElectionYearForFilerID"
        // THIS FUNCTION GETS THE ELECTION YEAR FOR FILTER DROPDOWN
        internal IList<ElectionYearModel> mapGetElectionYearForFilerIDForSubmit(String strFilerID)
        {
            IList<ElectionYearModel> lstElectionYearModel = new List<ElectionYearModel>();

            lstElectionYearModel = objViewAllDisclosuresDAL.mapGetElectionYearDataForFilerIDForSubmit(strFilerID);

            return lstElectionYearModel;
        }
        #endregion
    }
}
