// Creighton Newsom
// ViewSupportingDocuments Page 11/2018
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOE.CAPASFIDAS_EFS.Domain.EFSService;
using Models;

namespace DAL
{
    public class ViewSupportingDocumentsDAL
    {
        // Create Service Object
        //CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient();

        #region "mapmGetDisclosurePeriodDataDALResponse"
        // FUNCTION GETS THE DISCLOSURE PERIODS BASED ON THE YEAR AND FILER ID
        internal IList<DisclosurePreiodModel> mapGetDisclosurePeriodsForYearAndFilerIDDataDALResponse(String strFilerID, String strElectionYearID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<DisclosurePreiodModel> lstDisclosurePreiodModel = new List<DisclosurePreiodModel>();
                    DisclosurePreiodModel objDisclosurePreiodModel;

                    var results = client.GetDisclosurePeriodsForYearAndFilerID(strFilerID, strElectionYearID);

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

        #region "GetViewSupportingDocumentsGridData"
        // FUNCTION GETS DATA FOR THE SUPPORTINGDOCUMENTS GRID
        // FILERID IS REQUIRED, REPORTYEAR AND DISCLOSUREPERIOD ARE OPTIONAL
        public IList<ViewSupportingDocumentsGridModel> GetViewSupportingDocumentsGridData(String strFilerID, String strReportYearID, String strDisclosurePeriodID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ViewSupportingDocumentsGridModel> lstViewSupportingDocumentsGrid = new List<ViewSupportingDocumentsGridModel>();
                    ViewSupportingDocumentsGridModel objViewSupportingDocumentsGrid;

                    var results = client.GetViewSupportingDocumentsGridData(strFilerID, strReportYearID, strDisclosurePeriodID);

                    foreach (var item in results)
                    {
                        objViewSupportingDocumentsGrid = new ViewSupportingDocumentsGridModel();

                        objViewSupportingDocumentsGrid.SupportDocID = item.SupportDocID;
                        objViewSupportingDocumentsGrid.ScanDocID = item.ScanDocID;
                        objViewSupportingDocumentsGrid.OfficeTypeID = item.OfficeTypeID;
                        objViewSupportingDocumentsGrid.ElectTypeID = item.ElectTypeID;
                        objViewSupportingDocumentsGrid.PolCalDateID = item.PolCalDateID;

                        objViewSupportingDocumentsGrid.DateReceived = item.DateReceived;
                        objViewSupportingDocumentsGrid.DocumentType = item.DocumentType;
                        objViewSupportingDocumentsGrid.Amended = item.Amended;
                        objViewSupportingDocumentsGrid.ReportYear = item.ReportYear;
                        objViewSupportingDocumentsGrid.OfficeType = item.OfficeType;
                        objViewSupportingDocumentsGrid.ElectionType = item.ElectionType;
                        objViewSupportingDocumentsGrid.ElectionDate = item.ElectionDate;

                        objViewSupportingDocumentsGrid.DisclosurePeriod = item.DisclosurePeriod;
                        objViewSupportingDocumentsGrid.R_Status = item.R_Status;
                        objViewSupportingDocumentsGrid.FileType = item.FileType;
                        objViewSupportingDocumentsGrid.Size = item.Size;
                        objViewSupportingDocumentsGrid.FilingMethod = item.FilingMethod;

                        //add object to list
                        lstViewSupportingDocumentsGrid.Add(objViewSupportingDocumentsGrid);
                    }
                    client.Close();
                    return lstViewSupportingDocumentsGrid;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
           
            
        }
        #endregion

        #region "mapGetElectionYearsForFilerID_VSD"
        // THIS FUNCTION GETS THE ELECTION YEAR FOR FILTER DROPDOWN
        internal IList<ElectionYearModel> mapGetElectionYearsForFilerID_VSD(String strFilerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ElectionYearModel> lstElectionYearModel = new List<ElectionYearModel>();
                    ElectionYearModel objElectionYearModel;

                    var results = client.GetElectionYearForFilerID_VSD(strFilerID);

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
