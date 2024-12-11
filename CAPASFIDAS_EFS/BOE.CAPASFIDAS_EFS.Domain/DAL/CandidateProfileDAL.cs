using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOE.CAPASFIDAS_EFS.Domain.EFSService;
using Models;

namespace DAL
{
    public class CandidateProfileDAL
    {
        //Set Binding
        private void setBinding()
        {
        }

        //Map Request to Service Request
        private void mapRequest()
        {
        }

        //Map Response to Service Response
        private void mapResponse()
        {
        }

        // Create Service Object
        //CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient();

        internal IList<ShowAddressModel> mapGetAddressDataDALResponse(String strPersonId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ShowAddressModel> lstShowAddressModel = new List<ShowAddressModel>();
                    ShowAddressModel objShowAddressModel;

                    var results = client.GetAddressData(strPersonId);

                    foreach (var item in results)
                    {
                        objShowAddressModel = new ShowAddressModel();
                        objShowAddressModel.AddressId = item.AddressId;
                        objShowAddressModel.BestContactId = item.BestContactId;
                        objShowAddressModel.BestContractDesc = item.BestContractDesc;
                        objShowAddressModel.AddressTypeId = item.AddressTypeId;
                        objShowAddressModel.AddressTypeDesc = item.AddressTypeDesc;
                        objShowAddressModel.AddressStreetNumber = item.AddressStreetNumber;
                        objShowAddressModel.AddressStreetName = item.AddressStreetName;
                        objShowAddressModel.AddressAddress1 = item.AddressAddress1;
                        objShowAddressModel.AddressAddress2 = item.AddressAddress2;
                        objShowAddressModel.AddressCity = item.AddressCity;
                        objShowAddressModel.AddressState = item.AddressState;
                        objShowAddressModel.AddressZip = item.AddressZip;
                        objShowAddressModel.AddressZip4 = item.AddressZip4;
                        lstShowAddressModel.Add(objShowAddressModel);
                    }
                    client.Close();
                    return lstShowAddressModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        /// <summary>
        /// mapGetContactDataDALResponse
        /// </summary>
        /// <returns></returns>
        internal IList<ShowContactModel> mapGetContactDataDALResponse(String strPersonId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ShowContactModel> lstShowContactModel = new List<ShowContactModel>();
                    ShowContactModel objShowContactModel;

                    var results = client.GetContactData(strPersonId);

                    foreach (var item in results)
                    {
                        objShowContactModel = new ShowContactModel();
                        objShowContactModel.ContractId = item.ContractId;
                        objShowContactModel.PersonId = item.PersonId;
                        objShowContactModel.ContactTypeId = item.ContactTypeId;
                        objShowContactModel.ContactTypeDescription = item.ContactTypeDescription;
                        objShowContactModel.BestContactId = item.BestContactId;
                        objShowContactModel.BestContract_Desc = item.BestContract_Desc;
                        objShowContactModel.Phone = item.Phone;
                        objShowContactModel.EmailAddress = item.EmailAddress;
                        objShowContactModel.FAX = item.FAX;
                        objShowContactModel.URL = item.URL;
                        lstShowContactModel.Add(objShowContactModel);
                    }
                    client.Close();
                    return lstShowContactModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        /// <summary>
        /// mapGetDepositoryBankInfoDataDALResponse
        /// </summary>
        /// <param name="strPersonId"></param>
        /// <returns></returns>
        internal IList<DepositoryBankInfoModel> mapGetDepositoryBankInfoDataDALResponse(String strPersonId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<DepositoryBankInfoModel> lstDepositoryBankInfoModel = new List<DepositoryBankInfoModel>();
                    DepositoryBankInfoModel objDepositoryBankInfoModel;

                    var results = client.GetDepositoryBankInfoData(strPersonId);

                    foreach (var item in results)
                    {
                        objDepositoryBankInfoModel = new DepositoryBankInfoModel();
                        objDepositoryBankInfoModel.BankId = item.BankId;
                        objDepositoryBankInfoModel.AddressId = item.AddressId;
                        objDepositoryBankInfoModel.CandidateId = item.CandidateId;
                        objDepositoryBankInfoModel.DepositoryBankName = item.DepositoryBankName;
                        objDepositoryBankInfoModel.BankAccountTypeId = item.BankAccountTypeId;
                        objDepositoryBankInfoModel.StreetNumber = item.StreetNumber;
                        objDepositoryBankInfoModel.StreetName = item.StreetName;
                        objDepositoryBankInfoModel.City = item.City;
                        objDepositoryBankInfoModel.State = item.State;
                        objDepositoryBankInfoModel.Zip = item.Zip;
                        objDepositoryBankInfoModel.Zip4 = item.Zip4;
                        lstDepositoryBankInfoModel.Add(objDepositoryBankInfoModel);
                    }
                    client.Close();
                    return lstDepositoryBankInfoModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        /// <summary>
        /// mapGetCandAuthCommitteesDataDALResponse
        /// </summary>
        /// <param name="strPersonId"></param>
        /// <returns></returns>
        internal IList<CandAuthCommitteesModel> mapGetCandAuthCommitteesDataDALResponse(String strPersonId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<CandAuthCommitteesModel> lstCandAuthCommitteesModel = new List<CandAuthCommitteesModel>();
                    CandAuthCommitteesModel objCandAuthCommitteesModel;

                    var results = client.GetCandAuthCommitteesData(strPersonId);

                    foreach (var item in results)
                    {
                        objCandAuthCommitteesModel = new CandAuthCommitteesModel();
                        objCandAuthCommitteesModel.FilerId = item.FilerId;
                        objCandAuthCommitteesModel.CommitteeName = item.CommitteeName;
                        objCandAuthCommitteesModel.Status = item.Status;
                        objCandAuthCommitteesModel.RegistrationDate = item.RegistrationDate;
                        objCandAuthCommitteesModel.TerminationDate = item.TerminationDate;
                        lstCandAuthCommitteesModel.Add(objCandAuthCommitteesModel);
                    }
                    client.Close();
                    return lstCandAuthCommitteesModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        /// <summary>
        /// mapGetCandidateHeaderDataDALResponse
        /// </summary>
        /// <param name="strPersonId"></param>
        /// <returns></returns>
        internal IList<CandidateHeaderDataModel> mapGetCandidateHeaderDataDALResponse(String strPersonId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<CandidateHeaderDataModel> lstCandidateHeaderDataModel = new List<CandidateHeaderDataModel>();
                    CandidateHeaderDataModel objCandidateHeaderDataModel;

                    var results = client.GetCandidateHeaderData(strPersonId);

                    foreach (var item in results)
                    {
                        objCandidateHeaderDataModel = new CandidateHeaderDataModel();
                        objCandidateHeaderDataModel.FilerType = item.FilerType;
                        objCandidateHeaderDataModel.Office = item.Office;
                        objCandidateHeaderDataModel.District = item.District;
                        objCandidateHeaderDataModel.Municipality = item.Municipality;
                        objCandidateHeaderDataModel.ElectionYear = item.ElectionYear;
                        objCandidateHeaderDataModel.CandidateId = item.CandidateId;
                        objCandidateHeaderDataModel.SSN = item.SSN;
                        objCandidateHeaderDataModel.PoliticalParty = item.PoliticalParty;
                        objCandidateHeaderDataModel.RegistrationDate = item.RegistrationDate;
                        objCandidateHeaderDataModel.Status = item.Status;
                        objCandidateHeaderDataModel.TerminationDate = item.TerminationDate;
                        objCandidateHeaderDataModel.Prefix = item.Prefix;
                        objCandidateHeaderDataModel.LastName = item.LastName;
                        objCandidateHeaderDataModel.FirstName = item.FirstName;
                        objCandidateHeaderDataModel.MiddleName = item.MiddleName;
                        objCandidateHeaderDataModel.Suffix = item.Suffix;
                        lstCandidateHeaderDataModel.Add(objCandidateHeaderDataModel);
                    }
                    client.Close();
                    return lstCandidateHeaderDataModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        /// <summary>
        /// mapAddAddressDataDALResponse
        /// </summary>
        /// <param name="objAddressDataModel"></param>
        /// <returns></returns>
        internal Boolean mapAddAddressDataDALResponse(AddressDataModel objAddressDataModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    AddressDataContract objAddressDataContract = new AddressDataContract();
                    objAddressDataContract.AddressTypeId = objAddressDataModel.AddressTypeId;
                    objAddressDataContract.PersonId = objAddressDataModel.PersonId;
                    objAddressDataContract.BestContactId = objAddressDataModel.BestContactId;
                    objAddressDataContract.AddressBusinessName = objAddressDataModel.AddressBusinessName;
                    objAddressDataContract.AddressStreetNumber = objAddressDataModel.AddressStreetNumber;
                    objAddressDataContract.AddressStreetName = objAddressDataModel.AddressStreetName;
                    objAddressDataContract.AddressAddress1 = objAddressDataModel.AddressAddress1;
                    objAddressDataContract.AddressAddress2 = objAddressDataModel.AddressAddress2;
                    objAddressDataContract.AdresssCity = objAddressDataModel.AddresssCity;
                    objAddressDataContract.AddressState = objAddressDataModel.AddressState;
                    objAddressDataContract.AddressZip = objAddressDataModel.AddressZip;
                    objAddressDataContract.AddressZip4 = objAddressDataModel.AddressZip4;
                    objAddressDataContract.CreatedBy = objAddressDataModel.CreatedBy;

                    Boolean result = client.AddAddressData(objAddressDataContract);
                    client.Close();
                    return result;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
             
        }

        /// <summary>
        /// mapUpdateAddressDataDALResponse
        /// </summary>
        /// <param name="objAddressDataModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateAddressDataDALResponse(AddressDataModel objAddressDataModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    AddressDataContract objAddressDataContract = new AddressDataContract();
                    objAddressDataContract.AddressId = objAddressDataModel.AddressId;
                    objAddressDataContract.AddressTypeId = objAddressDataModel.AddressTypeId;
                    objAddressDataContract.BestContactId = objAddressDataModel.BestContactId;
                    objAddressDataContract.AddressStreetName = objAddressDataModel.AddressStreetName;
                    objAddressDataContract.AdresssCity = objAddressDataModel.AddresssCity;
                    objAddressDataContract.AddressState = objAddressDataModel.AddressState;
                    objAddressDataContract.AddressZip = objAddressDataModel.AddressZip;
                    objAddressDataContract.ModifiedBy = objAddressDataModel.ModifiedBy;

                    Boolean result = client.UpdateAddressData(objAddressDataContract);
                    client.Close();
                    return result;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
                      
        }

        /// <summary>
        /// mapDeleteAddressDataDALResponse
        /// </summary>
        /// <param name="objAddressDataModel"></param>
        /// <returns></returns>
        internal Boolean mapDeleteAddressDataDALResponse(AddressDataModel objAddressDataModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    AddressDataContract objAddressDataContract = new AddressDataContract();
                    objAddressDataContract.AddressId = objAddressDataModel.AddressId;
                    objAddressDataContract.ModifiedBy = objAddressDataModel.ModifiedBy;

                    Boolean result = client.DeleteAddressData(objAddressDataContract);
                    client.Close();
                    return result;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapGetAddressTypesDataDALResponse
        /// </summary>
        /// <returns></returns>
        internal IList<AddressTypesModel> mapGetAddressTypesDataDALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<AddressTypesModel> lstAddressTypesModel = new List<AddressTypesModel>();
                    AddressTypesModel objAddressTypesModel;

                    var results = client.GetAddressTypesData();

                    foreach (var item in results)
                    {
                        objAddressTypesModel = new AddressTypesModel();
                        objAddressTypesModel.AddressTypeId = item.AddressTypeId;
                        objAddressTypesModel.AddressTypeDescription = item.AddressTypeDescription;
                        lstAddressTypesModel.Add(objAddressTypesModel);
                    }
                    client.Close();
                    return lstAddressTypesModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapGetBestContactTypesDataDALResponse
        /// </summary>
        /// <returns></returns>
        internal IList<BestContactTypesModel> mapGetBestContactTypesDataDALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<BestContactTypesModel> lstBestContactTypesModel = new List<BestContactTypesModel>();
                    BestContactTypesModel objBestContactTypesModel;

                    var results = client.GetBestContactTypesData();

                    foreach (var item in results)
                    {
                        objBestContactTypesModel = new BestContactTypesModel();
                        objBestContactTypesModel.BestContactTypeId = item.BestContactTypeId;
                        objBestContactTypesModel.BestContactTypeDesc = item.BestContactTypeDesc;
                        lstBestContactTypesModel.Add(objBestContactTypesModel);
                    }
                    client.Close();
                    return lstBestContactTypesModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapGetContactTypesDataDALResponse
        /// </summary>
        /// <returns></returns>
        internal IList<ContactTypesModel> mapGetContactTypesDataDALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ContactTypesModel> lstContactTypesModel = new List<ContactTypesModel>();
                    ContactTypesModel objContactTypesModel;

                    var results = client.GetContactTypesData();

                    foreach (var item in results)
                    {
                        objContactTypesModel = new ContactTypesModel();
                        objContactTypesModel.ContactTypeId = item.ContactTypeId;
                        objContactTypesModel.ContactTypeDescription = item.ContactTypeDescription;
                        lstContactTypesModel.Add(objContactTypesModel);
                    }
                    client.Close();
                    return lstContactTypesModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapAddContactDataDALResponse
        /// </summary>
        /// <param name="objShowContactModel"></param>
        /// <returns></returns>
        public Boolean mapAddContactDataDALResponse(ShowContactModel objShowContactModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    ShowContactContract objShowContactContract = new ShowContactContract();
                    objShowContactContract.PersonId = objShowContactModel.PersonId;
                    objShowContactContract.BestContactId = objShowContactModel.BestContactId;
                    objShowContactContract.ContactTypeId = objShowContactModel.ContactTypeId;
                    objShowContactContract.Phone = objShowContactModel.Phone;
                    objShowContactContract.EmailAddress = objShowContactModel.EmailAddress;
                    objShowContactContract.FAX = objShowContactModel.FAX;
                    objShowContactContract.URL = objShowContactModel.URL;
                    objShowContactContract.CreatedBy = objShowContactModel.CreatedBy;

                    Boolean results = client.AddContactData(objShowContactContract);
                    client.Close();
                    return results;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapUpdateContactDataDALResponse
        /// </summary>
        /// <param name="objShowContactModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateContactDataDALResponse(ShowContactModel objShowContactModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    ShowContactContract objShowContactContract = new ShowContactContract();
                    objShowContactContract.ContractId = objShowContactModel.ContractId;
                    objShowContactContract.PersonId = objShowContactModel.PersonId;
                    objShowContactContract.BestContactId = objShowContactModel.BestContactId;
                    objShowContactContract.ContactTypeId = objShowContactModel.ContactTypeId;
                    objShowContactContract.Phone = objShowContactModel.Phone;
                    objShowContactContract.EmailAddress = objShowContactModel.EmailAddress;
                    objShowContactContract.FAX = objShowContactModel.FAX;
                    objShowContactContract.URL = objShowContactModel.URL;
                    objShowContactContract.ModifiedBy = objShowContactModel.ModifiedBy;

                    Boolean results = client.UpdateContactData(objShowContactContract);
                    client.Close();
                    return results;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapDeleteContactDataDALResponse
        /// </summary>
        /// <param name="objShowContactModel"></param>
        /// <returns></returns>
        internal Boolean mapDeleteContactDataDALResponse(ShowContactModel objShowContactModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    ShowContactContract objShowContactContract = new ShowContactContract();
                    objShowContactContract.ContractId = objShowContactModel.ContractId;
                    objShowContactContract.ModifiedBy = objShowContactModel.ModifiedBy;

                    Boolean results = client.DeleteContactData(objShowContactContract);
                    client.Close();
                    return results;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapAddDepositoryBankInfoDALResponse
        /// </summary>
        /// <param name="objDepositoryBankInfoModel"></param>
        /// <returns></returns>
        internal Boolean mapAddDepositoryBankInfoDALResponse(DepositoryBankInfoModel objDepositoryBankInfoModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    DepositoryBankInfoContract objDepositoryBankInfoContract = new DepositoryBankInfoContract();
                    objDepositoryBankInfoContract.PersonId = objDepositoryBankInfoModel.PersonId;
                    objDepositoryBankInfoContract.CandidateId = objDepositoryBankInfoModel.CandidateId;
                    objDepositoryBankInfoContract.DepositoryBankName = objDepositoryBankInfoModel.DepositoryBankName;
                    objDepositoryBankInfoContract.BankAccountTypeId = objDepositoryBankInfoModel.BankAccountTypeId;
                    objDepositoryBankInfoContract.StreetNumber = objDepositoryBankInfoModel.StreetNumber;
                    objDepositoryBankInfoContract.StreetName = objDepositoryBankInfoModel.StreetName;
                    objDepositoryBankInfoContract.City = objDepositoryBankInfoModel.City;
                    objDepositoryBankInfoContract.State = objDepositoryBankInfoModel.State;
                    objDepositoryBankInfoContract.Zip = objDepositoryBankInfoModel.Zip;
                    objDepositoryBankInfoContract.Zip4 = objDepositoryBankInfoModel.Zip4;
                    objDepositoryBankInfoContract.CreatedBy = objDepositoryBankInfoModel.CreatedBy;

                    Boolean results = client.AddDepositoryBankInfo(objDepositoryBankInfoContract);
                    client.Close();
                    return results;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapAddDepositoryBankInfoDALResponse
        /// </summary>
        /// <param name="objDepositoryBankInfoModel"></param>
        /// <returns></returns>
        internal Boolean mapAddDepositoryBankInfoDALResponseTrans(TreasDepositoryBankInformationModel objDepositoryBankInfoModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    TreasDepositoryBankInformationContract objDepositoryBankInfoContract = new TreasDepositoryBankInformationContract();
                    objDepositoryBankInfoContract.PERSON_ID = objDepositoryBankInfoModel.PERSON_ID;
                    objDepositoryBankInfoContract.COMM_ID = objDepositoryBankInfoModel.COMM_ID;
                    objDepositoryBankInfoContract.BankName = objDepositoryBankInfoModel.BankName;
                    objDepositoryBankInfoContract.BankAccountTypeID = objDepositoryBankInfoModel.BankAccountTypeID;
                    objDepositoryBankInfoContract.AddrStrName = objDepositoryBankInfoModel.AddrStrName;
                    objDepositoryBankInfoContract.AddrCity = objDepositoryBankInfoModel.AddrCity;
                    objDepositoryBankInfoContract.AddrState = objDepositoryBankInfoModel.AddrState;
                    objDepositoryBankInfoContract.AddrZip = objDepositoryBankInfoModel.AddrZip;
                    objDepositoryBankInfoContract.CreatedBy = objDepositoryBankInfoModel.CreatedBy;

                    Boolean results = client.AddDepositoryBankInfoTreasurer(objDepositoryBankInfoContract);
                    client.Close();
                    return results;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        
        /// <summary>
        /// mapUpdateDepositoryBankInfoDALResponse
        /// </summary>
        /// <param name="objDepositoryBankInfoModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateDepositoryBankInfoDALResponse(DepositoryBankInfoModel objDepositoryBankInfoModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    DepositoryBankInfoContract objDepositoryBankInfoContract = new DepositoryBankInfoContract();
                    objDepositoryBankInfoContract.AddressId = objDepositoryBankInfoModel.AddressId;
                    objDepositoryBankInfoContract.BankId = objDepositoryBankInfoModel.BankId;
                    objDepositoryBankInfoContract.DepositoryBankName = objDepositoryBankInfoModel.DepositoryBankName;
                    objDepositoryBankInfoContract.BankAccountTypeId = objDepositoryBankInfoModel.BankAccountTypeId;
                    objDepositoryBankInfoContract.StreetName = objDepositoryBankInfoModel.StreetName;
                    objDepositoryBankInfoContract.City = objDepositoryBankInfoModel.City;
                    objDepositoryBankInfoContract.State = objDepositoryBankInfoModel.State;
                    objDepositoryBankInfoContract.Zip = objDepositoryBankInfoModel.Zip;
                    objDepositoryBankInfoContract.ModifiedBy = objDepositoryBankInfoModel.ModifiedBy;

                    Boolean results = client.UpdateDepositoryBankInfo(objDepositoryBankInfoContract);
                    client.Close();
                    return results;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
           
            
        }

        /// <summary>
        /// mapDeleteDepositoryBankInfoDALResponse
        /// </summary>
        /// <param name="objDepositoryBankInfoModel"></param>
        /// <returns></returns>
        internal Boolean mapDeleteDepositoryBankInfoDALResponse(DepositoryBankInfoModel objDepositoryBankInfoModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    DepositoryBankInfoContract objDepositoryBankInfoContract = new DepositoryBankInfoContract();
                    objDepositoryBankInfoContract.AddressId = objDepositoryBankInfoModel.AddressId;
                    objDepositoryBankInfoContract.BankId = objDepositoryBankInfoModel.BankId;
                    objDepositoryBankInfoContract.ModifiedBy = objDepositoryBankInfoModel.ModifiedBy;

                    Boolean results = client.DeleteDepositoryBankInfo(objDepositoryBankInfoContract);
                    client.Close();
                    return results;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapGetBankAccountTypesDALResponse
        /// </summary>
        /// <returns></returns>
        internal IList<BankAccountTypesModel> mapGetBankAccountTypesDALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<BankAccountTypesModel> lstBankAccountTypesModel = new List<BankAccountTypesModel>();
                    BankAccountTypesModel objBankAccountTypesModel;

                    var results = client.GetBankAccountTypes();

                    foreach (var item in results)
                    {
                        objBankAccountTypesModel = new BankAccountTypesModel();
                        objBankAccountTypesModel.AccountTypeId = item.AccountTypeId;
                        objBankAccountTypesModel.AccountTypeDesc = item.AccountTypeDesc;
                        lstBankAccountTypesModel.Add(objBankAccountTypesModel);
                    }
                    client.Close();
                    return lstBankAccountTypesModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }
    }
}
