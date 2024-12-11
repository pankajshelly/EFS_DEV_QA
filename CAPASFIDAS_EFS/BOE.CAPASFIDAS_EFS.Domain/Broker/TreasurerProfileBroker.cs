using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Models;

namespace Broker
{
    public class TreasurerProfileBroker
    {
        // Create BLL Object
        TreasurerProfileBLL objTreasurerProfileBLL = new TreasurerProfileBLL();

        /// <summary>
        /// Get Treasurer Profile
        /// </summary>
        /// <param name="personID"></param>
        /// <returns></returns>
        public IList<TreasurerProfileModel> GetTreasurerProfileInfoBroker(string personID)
        {
            IList<TreasurerProfileModel> lstTreasurerProfileModel = new List<TreasurerProfileModel>();
            lstTreasurerProfileModel = objTreasurerProfileBLL.GetTreasurerProfileInfoBLL(personID);                        
            return lstTreasurerProfileModel;
        }

        /// <summary>
        /// Get Committee Information
        /// </summary>
        /// <param name="transID"></param>
        /// <returns></returns>
        public IList<TreasurerCommitteeInformationModel> GetTreasurerCommitteeInformationBroker(string transID)
        {
            IList<TreasurerCommitteeInformationModel> lstTreasurerCommitteeInformationModel = new List<TreasurerCommitteeInformationModel>();
            lstTreasurerCommitteeInformationModel = objTreasurerProfileBLL.GetTreasurerCommitteeInformationBLL(transID);
            return lstTreasurerCommitteeInformationModel;
        }

        /// <summary>
        /// Get Transurer Assistant Information
        /// </summary>
        /// <param name="commID"></param>
        /// <returns></returns>
        public IList<TreasAssistantInformationModel> GetTreasurerAssistantInformationBroker(string commID)
        {
            IList<TreasAssistantInformationModel> lstTreasAssistantInformationModel = new List<TreasAssistantInformationModel>();            
            lstTreasAssistantInformationModel = objTreasurerProfileBLL.GetTreasurerAssistantInformationBLL(commID);
            return lstTreasAssistantInformationModel;
        }

        /// <summary>
        /// Treasurer History Information
        /// </summary>
        /// <param name="commID"></param>
        /// <param name="transID"></param>
        /// <returns></returns>
        public IList<TreasurerHistoryModel> GetTreasurerHistoryInformationBroker(string commID, string transID)
        {
            IList<TreasurerHistoryModel> lstTreasurerHistoryModel = new List<TreasurerHistoryModel>();
            lstTreasurerHistoryModel = objTreasurerProfileBLL.GetTreasurerHistoryInformationBLL(commID, transID);
            return lstTreasurerHistoryModel;
        }

        /// <summary>
        /// Get Treasurer Additional Committee Contact
        /// </summary>
        /// <param name="commID"></param>
        /// <returns></returns>
        public IList<TreasAdditionalCommitteeContactModel> GetTreasurerAdditionalCommitteeContactBroker(string commID)
        {
            IList<TreasAdditionalCommitteeContactModel> lstTreasAdditionalCommitteeContactModel = new List<TreasAdditionalCommitteeContactModel>();
            lstTreasAdditionalCommitteeContactModel = objTreasurerProfileBLL.GetTreasurerAdditionalCommitteeContactBLL(commID);
            return lstTreasAdditionalCommitteeContactModel;
        }

        /// <summary>
        /// Get Treasurer Depository Bank Information
        /// </summary>
        /// <param name="commID"></param>
        /// <returns></returns>
        public IList<TreasDepositoryBankInformationModel> GetTreasurerDepositoryBankInformationBroker(string commID)
        {
            IList<TreasDepositoryBankInformationModel> lstTreasDepositoryBankInformationModel = new List<TreasDepositoryBankInformationModel>();
            lstTreasDepositoryBankInformationModel = objTreasurerProfileBLL.GetTreasurerDepositoryBankInformationBLL(commID);
            return lstTreasDepositoryBankInformationModel;
        }

        public IList<TreasCandidateSupportOpposeModel> GetTreasurerCandidateSupposeOpposeBroker(string commID)
        {
            IList<TreasCandidateSupportOpposeModel> lstTreasCandidateSupportOpposeModel = new List<TreasCandidateSupportOpposeModel>();
            lstTreasCandidateSupportOpposeModel = objTreasurerProfileBLL.GetTreasurerCandidateSupposeOpposeBLL(commID);
            return lstTreasCandidateSupportOpposeModel;
        }

        /// <summary>
        /// Get Treasurer Authorized To Sign Check Conract
        /// </summary>
        /// <param name="commID"></param>
        /// <returns></returns>
        public IList<TreasAuthorizedToSignCheckModel> GetTreasurerAuthorizedToSignCheckContactBroker(string commID)
        {
            IList<TreasAuthorizedToSignCheckModel> lstTreasAuthorizedToSignCheckModel = new List<TreasAuthorizedToSignCheckModel>();
            lstTreasAuthorizedToSignCheckModel = objTreasurerProfileBLL.GetTreasurerAuthorizedToSignCheckContactBLL(commID);
            return lstTreasAuthorizedToSignCheckModel;
        }

        /// <summary>
        /// Get Treasurer Ballot Issues Contract
        /// </summary>
        /// <param name="commID"></param>
        /// <returns></returns>
        public IList<TreasBallotIssuesModel> GetTreasurerBallotIssuesContactBroker(string commID)
        {
            IList<TreasBallotIssuesModel> lstTreasBallotIssuesModel = new List<TreasBallotIssuesModel>();
            lstTreasBallotIssuesModel = objTreasurerProfileBLL.GetTreasurerBallotIssuesContactBLL(commID);
            return lstTreasBallotIssuesModel;
        }

        /// <summary>
        /// AddSubTreasurerDataResponse
        /// </summary>
        /// <param name="objSubTreasurerPersonModel"></param>
        /// <returns></returns>
        public Boolean AddSubTreasurerDataResponse(SubTreasurerPersonModel objSubTreasurerPersonModel)
        {
            Boolean result = objTreasurerProfileBLL.mapAddSubTreasurerDataBLLResponse(objSubTreasurerPersonModel);

            return result;
        }

        /// <summary>
        /// UpdateSubTreasurerDataResponse
        /// </summary>
        /// <param name="objSubTreasurerPersonModel"></param>
        /// <returns></returns>
        public Boolean UpdateSubTreasurerDataResponse(SubTreasurerPersonModel objSubTreasurerPersonModel)
        {
            Boolean result = objTreasurerProfileBLL.mapUpdateSubTreasurerDataBLLResponse(objSubTreasurerPersonModel);

            return result;
        }

        /// <summary>
        /// Add Authorized To Sign Check Entry
        /// </summary>
        /// <param name="objAuthorizedToSignCheckEntity"></param>
        /// <returns></returns>
        public Boolean AddAuthorizedToSignCheckBroker(AuthorizedToSignCheckModel objAuthorizedToSignCheckModel)
        {
            Boolean result = objTreasurerProfileBLL.AddAuthorizedToSignCheckBLL(objAuthorizedToSignCheckModel);

            return result;
        }
    }
}
