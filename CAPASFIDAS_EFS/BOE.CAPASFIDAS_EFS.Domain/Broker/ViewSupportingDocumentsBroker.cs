// Creighton Newsom
// ViewSupportingDocuments Page 11/2018
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Models;

namespace Broker
{
    public class ViewSupportingDocumentsBroker
    {
        // Create BLL Object
        ViewSupportingDocumentsBLL objViewSupportingDocumentsBLL = new ViewSupportingDocumentsBLL();

        #region "GetDisclosurePeriodsForYearAndFilerIDDataResponse"
        // FUNCTION GETS THE DISCLOSURE PERIODS BASED ON THE YEAR AND FILER ID
        public IList<DisclosurePreiodModel> GetDisclosurePeriodsForYearAndFilerIDDataResponse(String strFilerID, String strElectionYearID)
        {
            IList<DisclosurePreiodModel> lstDisclosurePreiodModel = new List<DisclosurePreiodModel>();
            lstDisclosurePreiodModel = objViewSupportingDocumentsBLL.mapGetDisclosurePeriodsForYearAndFilerIDDataBLLResponse(strFilerID, strElectionYearID);
            return lstDisclosurePreiodModel;
        }
        #endregion

        #region "getViewSupportingDocumentsGridData"
        // FUNCTION GETS DATA FOR THE SUPPORTINGDOCUMENTS GRID
        // FILERID IS REQUIRED, REPORTYEAR AND DISCLOSUREPERIOD ARE OPTIONAL
        public IList<ViewSupportingDocumentsGridModel> getViewSupportingDocumentsGridData(String strFilerID, String strReportYearID, String strDisclosurePeriodID)
        {
            IList<ViewSupportingDocumentsGridModel> lstViewSupportingDocumentsGridModel = new List<ViewSupportingDocumentsGridModel>();
            lstViewSupportingDocumentsGridModel = objViewSupportingDocumentsBLL.getViewSupportingDocumentsGridData(strFilerID, strReportYearID, strDisclosurePeriodID);
            return lstViewSupportingDocumentsGridModel;
        }
        #endregion

        #region "GetElectionYearForFilerID_VSD"
        // THIS FUNCTION GETS THE ELECTION YEAR FOR FILTER DROPDOWN
        public IList<ElectionYearModel> GetElectionYearForFilerID_VSD(String strFilerID)
        {
            IList<ElectionYearModel> lstElectionYearModel = new List<ElectionYearModel>();

            lstElectionYearModel = objViewSupportingDocumentsBLL.mapGetElectionYearForFilerID_VSD(strFilerID);

            return lstElectionYearModel;
        }
        #endregion
    }

}
