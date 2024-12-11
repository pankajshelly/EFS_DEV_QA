using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
    public class TreasurerProfileBLL
    {
        // Create DAL Object
        TreasurerProfileDAL objTreasurerProfileDAL = new TreasurerProfileDAL();


        //Init
        internal void init()
        {
        }

        //Validate Request
        internal void validateRequest()
        {
        }

        //Map Response
        internal void mapResponse()
        {
        }

        /// <summary>
        /// Get Treasurer Profile
        /// </summary>
        /// <param name="personID"></param>
        /// <returns></returns>
        public IList<TreasurerProfileModel> GetTreasurerProfileInfoBLL(string personID)
        {
            IList<TreasurerProfileModel> lstTreasurerProfileModel = new List<TreasurerProfileModel>();
            lstTreasurerProfileModel = objTreasurerProfileDAL.GetTreasurerProfileInfoDAL(personID);   
            return lstTreasurerProfileModel;
        }

        /// <summary>
        /// Get Committee Information
        /// </summary>
        /// <param name="transID"></param>
        /// <returns></returns>
        public IList<TreasurerCommitteeInformationModel> GetTreasurerCommitteeInformationBLL(string transID)
        {
            IList<TreasurerCommitteeInformationModel> lstTreasurerCommitteeInformationModel = new List<TreasurerCommitteeInformationModel>();
            lstTreasurerCommitteeInformationModel = objTreasurerProfileDAL.GetTreasurerCommitteeInformationDAL(transID);
            return lstTreasurerCommitteeInformationModel;
        }

        /// <summary>
        /// Get Transurer Assistant Information
        /// </summary>
        /// <param name="commID"></param>
        /// <returns></returns>
        public IList<TreasAssistantInformationModel> GetTreasurerAssistantInformationBLL(string commID)
        {
            IList<TreasAssistantInformationModel> lstTreasAssistantInformationModel = new List<TreasAssistantInformationModel>();
            lstTreasAssistantInformationModel = objTreasurerProfileDAL.GetTreasurerAssistantInformationDAL(commID);
            return lstTreasAssistantInformationModel;
        }

        /// <summary>
        /// Treasurer History Information
        /// </summary>
        /// <param name="commID"></param>
        /// <param name="transID"></param>
        /// <returns></returns>
        public IList<TreasurerHistoryModel> GetTreasurerHistoryInformationBLL(string commID, string transID)
        {
            IList<TreasurerHistoryModel> lstTreasurerHistoryModel = new List<TreasurerHistoryModel>();
            lstTreasurerHistoryModel = objTreasurerProfileDAL.GetTreasurerHistoryInformationDAL(commID, transID);
            return lstTreasurerHistoryModel;
        }

        /// <summary>
        /// Get Treasurer Additional Committee Contact
        /// </summary>
        /// <param name="commID"></param>
        /// <returns></returns>
        public IList<TreasAdditionalCommitteeContactModel> GetTreasurerAdditionalCommitteeContactBLL(string commID)
        {
            IList<TreasAdditionalCommitteeContactModel> lstTreasAdditionalCommitteeContactModel = new List<TreasAdditionalCommitteeContactModel>();            
            lstTreasAdditionalCommitteeContactModel = objTreasurerProfileDAL.GetTreasurerAdditionalCommitteeContactDAL(commID);
            return lstTreasAdditionalCommitteeContactModel;
        }

        /// <summary>
        /// Get Treasurer Depository Bank Information
        /// </summary>
        /// <param name="commID"></param>
        /// <returns></returns>
        public IList<TreasDepositoryBankInformationModel> GetTreasurerDepositoryBankInformationBLL(string commID)
        {
            IList<TreasDepositoryBankInformationModel> lstTreasDepositoryBankInformationModel = new List<TreasDepositoryBankInformationModel>();
            lstTreasDepositoryBankInformationModel = objTreasurerProfileDAL.GetTreasurerDepositoryBankInformationDAL(commID);
            return lstTreasDepositoryBankInformationModel;
        }

        public IList<TreasCandidateSupportOpposeModel> GetTreasurerCandidateSupposeOpposeBLL(string commID)
        {
            IList<TreasCandidateSupportOpposeModel> lstTreasCandidateSupportOpposeModel = new List<TreasCandidateSupportOpposeModel>();
            lstTreasCandidateSupportOpposeModel = objTreasurerProfileDAL.GetTreasurerCandidateSupposeOpposeDAL(commID);
            return lstTreasCandidateSupportOpposeModel;
        }

        /// <summary>
        /// Get Treasurer Authorized To Sign Check Conract
        /// </summary>
        /// <param name="commID"></param>
        /// <returns></returns>
        public IList<TreasAuthorizedToSignCheckModel> GetTreasurerAuthorizedToSignCheckContactBLL(string commID)
        {
            IList<TreasAuthorizedToSignCheckModel> lstTreasAuthorizedToSignCheckModel = new List<TreasAuthorizedToSignCheckModel>();
            lstTreasAuthorizedToSignCheckModel = objTreasurerProfileDAL.GetTreasurerAuthorizedToSignCheckContactDAL(commID);
            return lstTreasAuthorizedToSignCheckModel;
        }

        /// <summary>
        /// Get Treasurer Ballot Issues Contract
        /// </summary>
        /// <param name="commID"></param>
        /// <returns></returns>
        public IList<TreasBallotIssuesModel> GetTreasurerBallotIssuesContactBLL(string commID)
        {
            IList<TreasBallotIssuesModel> lstTreasBallotIssuesModel = new List<TreasBallotIssuesModel>();
            lstTreasBallotIssuesModel = objTreasurerProfileDAL.GetTreasurerBallotIssuesContactDAL(commID);
            return lstTreasBallotIssuesModel;
        }

        /// <summary>
        /// mapAddSubTreasurerDataBLLResponse
        /// </summary>
        /// <param name="objSubTreasurerPersonModel"></param>
        /// <returns></returns>
        internal Boolean mapAddSubTreasurerDataBLLResponse(SubTreasurerPersonModel objSubTreasurerPersonModel)
        {
            Boolean result = objTreasurerProfileDAL.mapAddSubTreasurerDataDALResponse(objSubTreasurerPersonModel);

            return result;
        }

        /// <summary>
        /// mapUpdateSubTreasurerDataBLLResponse
        /// </summary>
        /// <param name="objSubTreasurerPersonModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateSubTreasurerDataBLLResponse(SubTreasurerPersonModel objSubTreasurerPersonModel)
        {
            Boolean result = objTreasurerProfileDAL.mapUpdateSubTreasurerDataDALResponse(objSubTreasurerPersonModel);

            return result;
        }

        /// <summary>
        /// Add Authorized To Sign Check Entry
        /// </summary>
        /// <param name="objAuthorizedToSignCheckEntity"></param>
        /// <returns></returns>
        internal Boolean AddAuthorizedToSignCheckBLL(AuthorizedToSignCheckModel objAuthorizedToSignCheckModel)
        {
            Boolean result = objTreasurerProfileDAL.AddAuthorizedToSignCheckDAL(objAuthorizedToSignCheckModel);

            return result;
        }        
    }
}
