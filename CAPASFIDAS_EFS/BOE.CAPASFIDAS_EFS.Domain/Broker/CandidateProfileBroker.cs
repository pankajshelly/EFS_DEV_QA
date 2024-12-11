using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Models;

namespace Broker
{
    public class CandidateProfileBroker
    {
        // Create BLL Object
        CandidateProfileBLL objCandidateProfileBLL = new CandidateProfileBLL();

        /// <summary>
        /// GetContactDataResponse
        /// </summary>
        /// <returns></returns>
        public IList<ShowAddressModel> GetAddressDataResponse(String strPersonId)
        {
            IList<ShowAddressModel> lstShowAddressModel = new List<ShowAddressModel>();

            lstShowAddressModel = objCandidateProfileBLL.mapGetAddressDataBLLResponse(strPersonId);

            return lstShowAddressModel;
        }

        /// <summary>
        /// GetContactDataResponse
        /// </summary>
        /// <returns></returns>
        public IList<ShowContactModel> GetContactDataResponse(String strPersonId)
        {
            IList<ShowContactModel> lstShowContactModel = new List<ShowContactModel>();

            lstShowContactModel = objCandidateProfileBLL.mapGetContactDataBLLResponse(strPersonId);

            return lstShowContactModel;
        }

        /// <summary>
        /// GetDepositoryBankInfoDataResponse
        /// </summary>
        /// <param name="strPersonId"></param>
        /// <returns></returns>
        public IList<DepositoryBankInfoModel> GetDepositoryBankInfoDataResponse(String strPersonId)
        {
            IList<DepositoryBankInfoModel> lstDepositoryBankInfoModel = new List<DepositoryBankInfoModel>();

            lstDepositoryBankInfoModel = objCandidateProfileBLL.mapGetDepositoryBankInfoDataBLLResponse(strPersonId);

            return lstDepositoryBankInfoModel;
        }

        /// <summary>
        /// GetCandAuthCommitteesDataResponse
        /// </summary>
        /// <param name="strPersonId"></param>
        /// <returns></returns>
        public IList<CandAuthCommitteesModel> GetCandAuthCommitteesDataResponse(String strPersonId)
        {
            IList<CandAuthCommitteesModel> lstCandAuthCommitteesModel = new List<CandAuthCommitteesModel>();

            lstCandAuthCommitteesModel = objCandidateProfileBLL.mapGetCandAuthCommitteesDataBLLResponse(strPersonId);

            return lstCandAuthCommitteesModel;
        }

        /// <summary>
        /// GetCandidateHeaderDataResponse
        /// </summary>
        /// <param name="strPersonId"></param>
        /// <returns></returns>
        public IList<CandidateHeaderDataModel> GetCandidateHeaderDataResponse(String strPersonId)
        {
            IList<CandidateHeaderDataModel> lstCandidateHeaderDataModel = new List<CandidateHeaderDataModel>();

            lstCandidateHeaderDataModel = objCandidateProfileBLL.mapGetCandidateHeaderDataBLLResponse(strPersonId);

            return lstCandidateHeaderDataModel;
        }

        /// <summary>
        /// AddAddressDataResponse
        /// </summary>
        /// <param name="objAddressDataModel"></param>
        /// <returns></returns>
        public Boolean AddAddressDataResponse(AddressDataModel objAddressDataModel)
        {
            Boolean result = objCandidateProfileBLL.mapAddAddressDataBLLResponse(objAddressDataModel);

            return result;
        }

        /// <summary>
        /// UpdateAddressDataResponse
        /// </summary>
        /// <param name="objAddressDataModel"></param>
        /// <returns></returns>
        public Boolean UpdateAddressDataResponse(AddressDataModel objAddressDataModel)
        {
            Boolean result = objCandidateProfileBLL.mapUpdateAddressDataBLLResponse(objAddressDataModel);

            return result;
        }

        /// <summary>
        /// DeleteAddressDataResponse
        /// </summary>
        /// <param name="objAddressDataModel"></param>
        /// <returns></returns>
        public Boolean DeleteAddressDataResponse(AddressDataModel objAddressDataModel)
        {
            Boolean result = objCandidateProfileBLL.mapDeleteAddressDataBLLResponse(objAddressDataModel);

            return result;
        }

        /// <summary>
        /// GetAddressTypesDataResponse
        /// </summary>
        /// <returns></returns>
        public IList<AddressTypesModel> GetAddressTypesDataResponse()
        {
            IList<AddressTypesModel> lstAddressTypesModel = new List<AddressTypesModel>();

            lstAddressTypesModel = objCandidateProfileBLL.mapGetAddressTypesDataBLLResponse();

            return lstAddressTypesModel;
        }

        /// <summary>
        /// GetBestContactTypesDataResponse
        /// </summary>
        /// <returns></returns>
        public IList<BestContactTypesModel> GetBestContactTypesDataResponse()
        {
            IList<BestContactTypesModel> lstBestContactTypesModel = new List<BestContactTypesModel>();

            lstBestContactTypesModel = objCandidateProfileBLL.mapGetBestContactTypesDataBLLResponse();

            return lstBestContactTypesModel;
        }

        /// <summary>
        /// GetContactTypesDataResponse
        /// </summary>
        /// <returns></returns>
        public IList<ContactTypesModel> GetContactTypesDataResponse()
        {
            IList<ContactTypesModel> lstContactTypesModel = new List<ContactTypesModel>();

            lstContactTypesModel = objCandidateProfileBLL.mapGetContactTypesDataBLLResponse();

            return lstContactTypesModel;
        }

        /// <summary>
        /// AddContactDataResponse
        /// </summary>
        /// <param name="objShowContactModel"></param>
        /// <returns></returns>
        public Boolean AddContactDataResponse(ShowContactModel objShowContactModel)
        {
            Boolean results = objCandidateProfileBLL.mapAddContactDataBLLResponse(objShowContactModel);

            return results;
        }

        /// <summary>
        /// UpdateContactDataResponse
        /// </summary>
        /// <param name="objShowContactModel"></param>
        /// <returns></returns>
        public Boolean UpdateContactDataResponse(ShowContactModel objShowContactModel)
        {
            Boolean results = objCandidateProfileBLL.mapUpdateContactDataBLLResponse(objShowContactModel);

            return results;
        }

        /// <summary>
        /// DeleteContactDataResponse
        /// </summary>
        /// <param name="objShowContactModel"></param>
        /// <returns></returns>
        public Boolean DeleteContactDataResponse(ShowContactModel objShowContactModel)
        {
            Boolean results = objCandidateProfileBLL.mapDeleteContactDataBLLResponse(objShowContactModel);

            return results;
        }


        /// <summary>
        /// AddDepositoryBankInfoResponse
        /// </summary>
        /// <param name="objDepositoryBankInfoModel"></param>
        /// <returns></returns>
        public Boolean AddDepositoryBankInfoResponse(DepositoryBankInfoModel objDepositoryBankInfoModel)
        {
            Boolean results = objCandidateProfileBLL.mapAddDepositoryBankInfoBLLResponse(objDepositoryBankInfoModel);

            return results;
        }

        /// <summary>
        /// AddDepositoryBankInfoResponse
        /// </summary>
        /// <param name="objDepositoryBankInfoModel"></param>
        /// <returns></returns>
        public Boolean AddDepositoryBankInfoResponseTrans(TreasDepositoryBankInformationModel objDepositoryBankInfoModel)
        {
            Boolean results = objCandidateProfileBLL.mapAddDepositoryBankInfoBLLResponseTrans(objDepositoryBankInfoModel);

            return results;
        }

        /// <summary>
        /// UpdateDepositoryBankInfoResponse
        /// </summary>
        /// <param name="objDepositoryBankInfoModel"></param>
        /// <returns></returns>
        public Boolean UpdateDepositoryBankInfoResponse(DepositoryBankInfoModel objDepositoryBankInfoModel)
        {
            Boolean results = objCandidateProfileBLL.mapUpdateDepositoryBankInfoBLLResponse(objDepositoryBankInfoModel);

            return results;
        }

        /// <summary>
        /// DeleteDepositoryBankInfoResponse
        /// </summary>
        /// <param name="objDepositoryBankInfoModel"></param>
        /// <returns></returns>
        public Boolean DeleteDepositoryBankInfoResponse(DepositoryBankInfoModel objDepositoryBankInfoModel)
        {
            Boolean results = objCandidateProfileBLL.mapDeleteDepositoryBankInfoBLLResponse(objDepositoryBankInfoModel);

            return results;
        }

        /// <summary>
        /// GetBankAccountTypesResponse
        /// </summary>
        /// <returns></returns>
        public IList<BankAccountTypesModel> GetBankAccountTypesResponse()
        {
            IList<BankAccountTypesModel> lstBankAccountTypesModel = new List<BankAccountTypesModel>();

            lstBankAccountTypesModel = objCandidateProfileBLL.mapGetBankAccountTypesBLLResponse();

            return lstBankAccountTypesModel;
        }
    }
}
