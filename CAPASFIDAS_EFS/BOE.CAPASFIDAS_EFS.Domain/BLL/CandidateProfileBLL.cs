using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
    public class CandidateProfileBLL
    {
        // Create DAL Object
        CandidateProfileDAL objCandidateProfileDAL = new CandidateProfileDAL();


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
        /// mapGetContactDataDALResponse
        /// </summary>
        /// <returns></returns>
        internal IList<ShowAddressModel> mapGetAddressDataBLLResponse(String strPersonId)
        {
            IList<ShowAddressModel> lstShowAddressModel = new List<ShowAddressModel>();

            lstShowAddressModel = objCandidateProfileDAL.mapGetAddressDataDALResponse(strPersonId);

            return lstShowAddressModel;
        }

        /// <summary>
        /// mapGetContactDataBLLResponse
        /// </summary>
        /// <returns></returns>
        internal IList<ShowContactModel> mapGetContactDataBLLResponse(String strPersonId)
        {
            IList<ShowContactModel> lstShowContactModel = new List<ShowContactModel>();

            lstShowContactModel = objCandidateProfileDAL.mapGetContactDataDALResponse(strPersonId);

            return lstShowContactModel;
        }

        /// <summary>
        /// mapGetDepositoryBankInfoDataBLLResponse
        /// </summary>
        /// <param name="strPersonId"></param>
        /// <returns></returns>
        internal IList<DepositoryBankInfoModel> mapGetDepositoryBankInfoDataBLLResponse(String strPersonId)
        {
            IList<DepositoryBankInfoModel> lstDepositoryBankInfoModel = new List<DepositoryBankInfoModel>();

            lstDepositoryBankInfoModel = objCandidateProfileDAL.mapGetDepositoryBankInfoDataDALResponse(strPersonId);

            return lstDepositoryBankInfoModel;
        }

        /// <summary>
        /// mapGetCandAuthCommitteesDataBLLResponse
        /// </summary>
        /// <param name="strPersonId"></param>
        /// <returns></returns>
        internal IList<CandAuthCommitteesModel> mapGetCandAuthCommitteesDataBLLResponse(String strPersonId)
        {
            IList<CandAuthCommitteesModel> lstCandAuthCommitteesModel = new List<CandAuthCommitteesModel>();

            lstCandAuthCommitteesModel = objCandidateProfileDAL.mapGetCandAuthCommitteesDataDALResponse(strPersonId);

            return lstCandAuthCommitteesModel;
        }

        /// <summary>
        /// mapGetCandidateHeaderDataBLLResponse
        /// </summary>
        /// <param name="strPersonId"></param>
        /// <returns></returns>
        internal IList<CandidateHeaderDataModel> mapGetCandidateHeaderDataBLLResponse(String strPersonId)
        {
            IList<CandidateHeaderDataModel> lstCandidateHeaderDataModel = new List<CandidateHeaderDataModel>();

            lstCandidateHeaderDataModel = objCandidateProfileDAL.mapGetCandidateHeaderDataDALResponse(strPersonId);

            return lstCandidateHeaderDataModel;
        }

        /// <summary>
        /// mapAddAddressDataBLLResponse
        /// </summary>
        /// <param name="objAddressDataModel"></param>
        /// <returns></returns>
        internal Boolean mapAddAddressDataBLLResponse(AddressDataModel objAddressDataModel)
        {
            Boolean result = objCandidateProfileDAL.mapAddAddressDataDALResponse(objAddressDataModel);

            return result;
        }

        /// <summary>
        /// mapUpdateAddressDataBLLResponse
        /// </summary>
        /// <param name="objAddressDataModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateAddressDataBLLResponse(AddressDataModel objAddressDataModel)
        {
            Boolean result = objCandidateProfileDAL.mapUpdateAddressDataDALResponse(objAddressDataModel);

            return result;
        }

        /// <summary>
        /// mapDeleteAddressDataBLLResponse
        /// </summary>
        /// <param name="objAddressDataModel"></param>
        /// <returns></returns>
        internal Boolean mapDeleteAddressDataBLLResponse(AddressDataModel objAddressDataModel)
        {
            Boolean result = objCandidateProfileDAL.mapDeleteAddressDataDALResponse(objAddressDataModel);

            return result;
        }

        /// <summary>
        /// mapGetAddressTypesDataBLLResponse
        /// </summary>
        /// <returns></returns>
        internal IList<AddressTypesModel> mapGetAddressTypesDataBLLResponse()
        {
            IList<AddressTypesModel> lstAddressTypesModel = new List<AddressTypesModel>();

            lstAddressTypesModel = objCandidateProfileDAL.mapGetAddressTypesDataDALResponse();

            return lstAddressTypesModel;
        }

        /// <summary>
        /// mapGetBestContactTypesDataBLLResponse
        /// </summary>
        /// <returns></returns>
        internal IList<BestContactTypesModel> mapGetBestContactTypesDataBLLResponse()
        {
            IList<BestContactTypesModel> lstBestContactTypesModel = new List<BestContactTypesModel>();

            lstBestContactTypesModel = objCandidateProfileDAL.mapGetBestContactTypesDataDALResponse();

            return lstBestContactTypesModel;
        }

        /// <summary>
        /// mapGetContactTypesDataBLLResponse
        /// </summary>
        /// <returns></returns>
        internal IList<ContactTypesModel> mapGetContactTypesDataBLLResponse()
        {
            IList<ContactTypesModel> lstContactTypesModel = new List<ContactTypesModel>();

            lstContactTypesModel = objCandidateProfileDAL.mapGetContactTypesDataDALResponse();

            return lstContactTypesModel;
        }

        /// <summary>
        /// mapAddContactDataBLLResponse
        /// </summary>
        /// <param name="objShowContactModel"></param>
        /// <returns></returns>
        public Boolean mapAddContactDataBLLResponse(ShowContactModel objShowContactModel)
        {
            Boolean results = objCandidateProfileDAL.mapAddContactDataDALResponse(objShowContactModel);

            return results;
        }


        /// <summary>
        /// mapUpdateContactDataBLLResponse
        /// </summary>
        /// <param name="objShowContactModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateContactDataBLLResponse(ShowContactModel objShowContactModel)
        {
            Boolean results = objCandidateProfileDAL.mapUpdateContactDataDALResponse(objShowContactModel);

            return results;
        }

        /// <summary>
        /// mapDeleteContactDataBLLResponse
        /// </summary>
        /// <param name="objShowContactModel"></param>
        /// <returns></returns>
        internal Boolean mapDeleteContactDataBLLResponse(ShowContactModel objShowContactModel)
        {
            Boolean results = objCandidateProfileDAL.mapDeleteContactDataDALResponse(objShowContactModel);

            return results;
        }

        /// <summary>
        /// mapAddDepositoryBankInfoBLLResponse
        /// </summary>
        /// <param name="objDepositoryBankInfoModel"></param>
        /// <returns></returns>
        internal Boolean mapAddDepositoryBankInfoBLLResponseTrans(TreasDepositoryBankInformationModel objDepositoryBankInfoModel)
        {
            Boolean results = objCandidateProfileDAL.mapAddDepositoryBankInfoDALResponseTrans(objDepositoryBankInfoModel);

            return results;
        }

        /// <summary>
        /// mapAddDepositoryBankInfoBLLResponse
        /// </summary>
        /// <param name="objDepositoryBankInfoModel"></param>
        /// <returns></returns>
        internal Boolean mapAddDepositoryBankInfoBLLResponse(DepositoryBankInfoModel objDepositoryBankInfoModel)
        {
            Boolean results = objCandidateProfileDAL.mapAddDepositoryBankInfoDALResponse(objDepositoryBankInfoModel);

            return results;
        }

        /// <summary>
        /// mapUpdateDepositoryBankInfoBLLResponse
        /// </summary>
        /// <param name="objDepositoryBankInfoModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateDepositoryBankInfoBLLResponse(DepositoryBankInfoModel objDepositoryBankInfoModel)
        {
            Boolean results = objCandidateProfileDAL.mapUpdateDepositoryBankInfoDALResponse(objDepositoryBankInfoModel);

            return results;
        }

        /// <summary>
        /// mapDeleteDepositoryBankInfoBLLResponse
        /// </summary>
        /// <param name="objDepositoryBankInfoModel"></param>
        /// <returns></returns>
        internal Boolean mapDeleteDepositoryBankInfoBLLResponse(DepositoryBankInfoModel objDepositoryBankInfoModel)
        {
            Boolean results = objCandidateProfileDAL.mapDeleteDepositoryBankInfoDALResponse(objDepositoryBankInfoModel);

            return results;
        }

        /// <summary>
        /// mapGetBankAccountTypesBLLResponse
        /// </summary>
        /// <returns></returns>
        internal IList<BankAccountTypesModel> mapGetBankAccountTypesBLLResponse()
        {
            IList<BankAccountTypesModel> lstBankAccountTypesModel = new List<BankAccountTypesModel>();
            
            lstBankAccountTypesModel = objCandidateProfileDAL.mapGetBankAccountTypesDALResponse();
            
            return lstBankAccountTypesModel;
        }
    }
}
