// Creighton Newsom
// ViewSupportingDocuments Page 11/2018
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
    public class ViewSupportingDocumentsBLL
    {
        // Create DAL Object
        ViewSupportingDocumentsDAL objViewSupportingDocumentsDAL = new ViewSupportingDocumentsDAL();


        #region "mapGetDisclosurePeriodDataBLLResponse"
        // FUNCTION GETS THE DISCLOSURE PERIODS BASED ON THE YEAR AND FILER ID
        internal IList<DisclosurePreiodModel> mapGetDisclosurePeriodsForYearAndFilerIDDataBLLResponse(String strFilerID, String strElectionYearID)
        {
            IList<DisclosurePreiodModel> lstDisclosurePreiodModel = new List<DisclosurePreiodModel>();
            lstDisclosurePreiodModel = objViewSupportingDocumentsDAL.mapGetDisclosurePeriodsForYearAndFilerIDDataDALResponse(strFilerID, strElectionYearID);
            return lstDisclosurePreiodModel;
        }
        #endregion

        #region "getViewSupportingDocumentsGridData"
        // FUNCTION GETS DATA FOR THE SUPPORTINGDOCUMENTS GRID
        // FILERID IS REQUIRED, REPORTYEAR AND DISCLOSUREPERIOD ARE OPTIONAL
        internal IList<ViewSupportingDocumentsGridModel> getViewSupportingDocumentsGridData(String strFilerID, String strReportYearID, String strDisclosurePeriodID)
        {
            IList<ViewSupportingDocumentsGridModel> lstViewSupportingDocumentsGridModel = new List<ViewSupportingDocumentsGridModel>();
            lstViewSupportingDocumentsGridModel = objViewSupportingDocumentsDAL.GetViewSupportingDocumentsGridData(strFilerID, strReportYearID, strDisclosurePeriodID);
            return lstViewSupportingDocumentsGridModel;
        }
        #endregion

        #region "mapGetElectionYearForFilerID_VSD"
        // THIS FUNCTION GETS THE ELECTION YEAR FOR FILTER DROPDOWN
        internal IList<ElectionYearModel> mapGetElectionYearForFilerID_VSD(String strFilerID)
        {
            IList<ElectionYearModel> lstElectionYearModel = new List<ElectionYearModel>();
            lstElectionYearModel = objViewSupportingDocumentsDAL.mapGetElectionYearsForFilerID_VSD(strFilerID);
            return lstElectionYearModel;
        }
        #endregion
    }
}
