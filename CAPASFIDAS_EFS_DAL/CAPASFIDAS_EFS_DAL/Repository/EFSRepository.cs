// ViewAllDisclosures Region by Creighton Newsom
// ViewSupportingDocuments Region by Creighton Newsom
// Loan and Liability Reconciliation Region by Creighton Newsom
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Data.Entity.Infrastructure;
using CAPASFIDAS_EFS_DAL; 
using System.Transactions;
using System.Runtime.Remoting.Contexts;
using System.Data;
using System.Data.SqlClient;

namespace Repository
{
    public class EFSRepository
    {
        EFSEntities entities = new EFSEntities();
        CAPASFIDASTEMPDBEntities capasfidastempEntities = new CAPASFIDASTEMPDBEntities();        
        CAPASFIDASTEMPEntities1 authenticateEntites = new CAPASFIDASTEMPEntities1();

        public EFSRepository()
        {
            //EFSEntities db = new EFSEntities();
            //IObjectContextAdapter dbcontextadapter = (IObjectContextAdapter)db;
            //dbcontextadapter.ObjectContext.CommandTimeout = 180;
        }

        /// <summary>
        /// GetContactData
        /// </summary>
        /// <returns></returns>
        public IList<ShowAddressEntity> GetAddressData(String strPersonId)
        {
            IList<ShowAddressEntity> lstShowAddressEntity = new List<ShowAddressEntity>();
            ShowAddressEntity objShowAddressEntity;

            var results = entities.SP_S_GetAddressData(strPersonId);

            foreach (var item in results)
            {
                objShowAddressEntity = new ShowAddressEntity();
                objShowAddressEntity.AddressId = Convert.ToString(item.ADDR_ID);
                objShowAddressEntity.BestContactId = Convert.ToString(item.BEST_CONTACT_ID);
                objShowAddressEntity.BestContractDesc = item.BEST_CONTACT_DESC;
                objShowAddressEntity.AddressTypeId = Convert.ToString(item.ADDR_TYPE_ID);
                objShowAddressEntity.AddressTypeDesc = item.ADDR_TYPE_DESC;
                objShowAddressEntity.AddressStreetNumber = item.ADDR_STR_NUM;
                objShowAddressEntity.AddressStreetName = item.ADDR_STR_NAME;
                objShowAddressEntity.AddressAddress1 = item.ADDR_ADDR1;
                objShowAddressEntity.AddressAddress2 = item.ADDR_ADDR2;
                objShowAddressEntity.AddressCity = item.ADDR_CITY;
                objShowAddressEntity.AddressState = item.ADDR_STATE;
                objShowAddressEntity.AddressZip = Convert.ToString(item.ADDR_ZIP);
                objShowAddressEntity.AddressZip4 = Convert.ToString(item.ADDR_ZIP4);
                lstShowAddressEntity.Add(objShowAddressEntity);
            }

            return lstShowAddressEntity;
        }

        /// <summary>
        /// GetContactData
        /// </summary>
        /// <returns></returns>
        public IList<ShowContactEntity> GetContactData(String strPersonId)
        {
            IList<ShowContactEntity> lstShowContactEntity = new List<ShowContactEntity>();
            ShowContactEntity objShowContactEntity;

            var results = entities.SP_S_GetContactData(strPersonId);

            foreach (var item in results)
            {
                objShowContactEntity = new ShowContactEntity();
                objShowContactEntity.ContractId = Convert.ToString(item.CONTACT_ID);
                objShowContactEntity.PersonId = Convert.ToString(item.PERSON_ID);
                //objShowContactEntity.ContactTypeId = Convert.ToString(item.CONTACT_TYPE_ID);
                //objShowContactEntity.ContactTypeDescription = item.CONTACT_TYPE_DESC;
                objShowContactEntity.BestContactId = Convert.ToString(item.BEST_CONTACT_ID);
                objShowContactEntity.BestContract_Desc = item.BEST_CONTACT_DESC;
                objShowContactEntity.Phone = item.PHONE.ToString();
                objShowContactEntity.EmailAddress = item.EMAIL.ToString();
                objShowContactEntity.FAX = item.FAX.ToString();
                objShowContactEntity.URL = item.URL.ToString();
                //if (item.CONTACT_TYPE_DESC == "Phone")
                //    objShowContactEntity.Phone = item.CONTACT_VALUE;
                //if (item.CONTACT_TYPE_DESC == "Email")
                //    objShowContactEntity.EmailAddress = item.CONTACT_VALUE;
                //if (item.CONTACT_TYPE_DESC == "FAX")
                //    objShowContactEntity.FAX = item.CONTACT_VALUE;
                //if (item.CONTACT_TYPE_DESC == "URL")
                //    objShowContactEntity.URL = item.CONTACT_VALUE;
                lstShowContactEntity.Add(objShowContactEntity);
            }

            return lstShowContactEntity;
        }

        /// <summary>
        /// GetDepositoryBankInfoData
        /// </summary>
        /// <param name="strPersonId"></param>
        /// <returns></returns>
        public IList<DepositoryBankInfoEntity> GetDepositoryBankInfoData(String strPersonId)
        {
            IList<DepositoryBankInfoEntity> lstDepositoryBankInfoEntity = new List<DepositoryBankInfoEntity>();
            DepositoryBankInfoEntity objDepositoryBankInfoEntity;

            var results = entities.SP_S_GetDepositoryBankInfoData(strPersonId);

            foreach (var item in results)
            {
                objDepositoryBankInfoEntity = new DepositoryBankInfoEntity();
                objDepositoryBankInfoEntity.BankId = Convert.ToString(item.BANK_ID);
                objDepositoryBankInfoEntity.AddressId = Convert.ToString(item.ADDR_ID);
                objDepositoryBankInfoEntity.CandidateId = Convert.ToString(item.CAND_ID);
                objDepositoryBankInfoEntity.DepositoryBankName = item.BANK_NAME;
                objDepositoryBankInfoEntity.BankAccountTypeId = Convert.ToString(item.ACCOUNT_TYPE_ID);
                objDepositoryBankInfoEntity.StreetNumber = item.ADDR_STR_NUM;
                objDepositoryBankInfoEntity.StreetName = item.ADDR_STR_NAME;
                objDepositoryBankInfoEntity.City = item.ADDR_CITY;
                objDepositoryBankInfoEntity.State = item.ADDR_STATE;
                objDepositoryBankInfoEntity.Zip = Convert.ToString(item.ADDR_ZIP);
                objDepositoryBankInfoEntity.Zip4 = Convert.ToString(item.ADDR_ZIP4);
                lstDepositoryBankInfoEntity.Add(objDepositoryBankInfoEntity);
            }
            return lstDepositoryBankInfoEntity;
        }

        /// <summary>
        /// GetCandAuthCommitteesData
        /// </summary>
        /// <param name="strPersonId"></param>
        /// <returns></returns>
        public IList<CandAuthCommitteesEntity> GetCandAuthCommitteesData(String strPersonId)
        {
            IList<CandAuthCommitteesEntity> lstCandAuthCommitteesEntity = new List<CandAuthCommitteesEntity>();
            CandAuthCommitteesEntity objCandAuthCommitteesEntity;

            var results = entities.SP_S_GetCandAuthCommitteesData(strPersonId);

            foreach (var item in results)
            {
                objCandAuthCommitteesEntity = new CandAuthCommitteesEntity();
                objCandAuthCommitteesEntity.FilerId = Convert.ToString(item.FILER_ID);
                objCandAuthCommitteesEntity.CommitteeName = item.COMM_NAME;
                objCandAuthCommitteesEntity.Status = item.R_STATUS;
                objCandAuthCommitteesEntity.RegistrationDate = item.COMM_REG_DATE;
                objCandAuthCommitteesEntity.TerminationDate = item.COMM_TERM_DATE;
                lstCandAuthCommitteesEntity.Add(objCandAuthCommitteesEntity);
            }

            return lstCandAuthCommitteesEntity;
        }

        /// <summary>
        /// GetCandidateHeaderData
        /// </summary>
        /// <param name="strPersonId"></param>
        /// <returns></returns>
        public IList<CandidateHeaderDataEntity> GetCandidateHeaderData(String strPersonId)
        {
            IList<CandidateHeaderDataEntity> lstCandidateHeaderDataEntity = new List<CandidateHeaderDataEntity>();
            CandidateHeaderDataEntity objCandidateHeaderDataEntity;

            var results = entities.SP_S_GetCandidatePofileDetailsData(strPersonId);

            foreach (var item in results)
            {
                objCandidateHeaderDataEntity = new CandidateHeaderDataEntity();
                objCandidateHeaderDataEntity.FilerType = item.OFFICE_TYPE_DESC;
                objCandidateHeaderDataEntity.Office = item.OFFICE_DESC;
                objCandidateHeaderDataEntity.District = Convert.ToString(item.DIST_ID);
                objCandidateHeaderDataEntity.Municipality = item.MUNICIPALITY_DESC;
                objCandidateHeaderDataEntity.ElectionYear = Convert.ToString(item.ELECT_YEAR);
                objCandidateHeaderDataEntity.CandidateId = Convert.ToString(item.CAND_ID);
                objCandidateHeaderDataEntity.SSN = item.PERSON_SSN;
                objCandidateHeaderDataEntity.PoliticalParty = item.PARTY_DESC;
                objCandidateHeaderDataEntity.RegistrationDate = item.CAND_REG_DATE;
                objCandidateHeaderDataEntity.Status = item.R_STATUS;
                objCandidateHeaderDataEntity.TerminationDate = item.CAND_TERM_DATE;
                objCandidateHeaderDataEntity.Prefix = item.PERSON_PREFIX;
                objCandidateHeaderDataEntity.LastName = item.PERSON_LAST_NAME;
                objCandidateHeaderDataEntity.FirstName = item.PERSON_FIRST_NAME;
                objCandidateHeaderDataEntity.MiddleName = item.PERSON_MIDDLE_NAME;
                objCandidateHeaderDataEntity.Suffix = item.PERSON_SUFFIX;
                lstCandidateHeaderDataEntity.Add(objCandidateHeaderDataEntity);
            }

            return lstCandidateHeaderDataEntity;
        }

        /// <summary>
        /// AddAddressData
        /// </summary>
        /// <param name="objAddressDataEntity"></param>
        /// <returns></returns>
        public Boolean AddAddressData(AddressDataEntity objAddressDataEntity)
        {
            var returnValue = entities.SP_I_AddAddress(objAddressDataEntity.AddressTypeId, objAddressDataEntity.PersonId,
                objAddressDataEntity.BestContactId, objAddressDataEntity.AddressBusinessName,
                objAddressDataEntity.AddressStreetNumber, objAddressDataEntity.AddressStreetName, objAddressDataEntity.AddressAddress1,
                objAddressDataEntity.AddressAddress2, objAddressDataEntity.AdresssCity, objAddressDataEntity.AddressState,
                objAddressDataEntity.AddressZip, objAddressDataEntity.AddressZip4, objAddressDataEntity.CreatedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// UpdateAddressData
        /// </summary>
        /// <param name="objAddressDataEntity"></param>
        /// <returns></returns>
        public Boolean UpdateAddressData(AddressDataEntity objAddressDataEntity)
        {
            var returnValue = entities.SP_U_UpdateAddress(objAddressDataEntity.AddressId, objAddressDataEntity.AddressTypeId,
                objAddressDataEntity.BestContactId, objAddressDataEntity.AddressStreetName, objAddressDataEntity.AdresssCity, objAddressDataEntity.AddressState,
                objAddressDataEntity.AddressZip, objAddressDataEntity.ModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// DeleteAddressData
        /// </summary>
        /// <param name="objAddressDataEntity"></param>
        /// <returns></returns>
        public Boolean DeleteAddressData(AddressDataEntity objAddressDataEntity)
        {
            var returnValue = entities.SP_D_DeleteAddress(objAddressDataEntity.AddressId, objAddressDataEntity.ModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// GetAddressTypesData
        /// </summary>
        /// <returns></returns>
        public IList<AddressTypesEntity> GetAddressTypesData()
        {
            IList<AddressTypesEntity> lstAddressTypesEntity = new List<AddressTypesEntity>();
            AddressTypesEntity objAddressTypesEntity;

            var results = entities.SP_S_AddressTypes();

            foreach (var item in results)
            {
                objAddressTypesEntity = new AddressTypesEntity();
                objAddressTypesEntity.AddressTypeId = Convert.ToString(item.ADDR_TYPE_ID);
                objAddressTypesEntity.AddressTypeDescription = item.ADDR_TYPE_DESC;
                lstAddressTypesEntity.Add(objAddressTypesEntity);
            }

            return lstAddressTypesEntity;
        }

        /// <summary>
        /// GetBestContactTypesData
        /// </summary>
        /// <returns></returns>
        public IList<BestContactTypesEntity> GetBestContactTypesData()
        {
            IList<BestContactTypesEntity> lstBestContactTypesEntity = new List<BestContactTypesEntity>();
            BestContactTypesEntity objBestContactTypesEntity;

            var results = entities.SP_S_BestContactTypes();

            foreach (var item in results)
            {
                objBestContactTypesEntity = new BestContactTypesEntity();
                objBestContactTypesEntity.BestContactTypeId = Convert.ToString(item.BEST_CONTACT_ID);
                objBestContactTypesEntity.BestContactTypeDesc = item.BEST_CONTACT_DESC;
                lstBestContactTypesEntity.Add(objBestContactTypesEntity);
            }

            return lstBestContactTypesEntity;
        }

        /// <summary>
        /// GetContactTypesData
        /// </summary>
        /// <returns></returns>
        public IList<ContactTypesEntity> GetContactTypesData()
        {
            IList<ContactTypesEntity> lstContactTypesEntity = new List<ContactTypesEntity>();
            ContactTypesEntity objContactTypesEntity;

            var results = entities.SP_S_ContactTypes();

            foreach (var item in results)
            {
                objContactTypesEntity = new ContactTypesEntity();
                objContactTypesEntity.ContactTypeId = Convert.ToString(item.CONTACT_TYPE_ID);
                objContactTypesEntity.ContactTypeDescription = item.CONTACT_TYPE_DESC;
                lstContactTypesEntity.Add(objContactTypesEntity);
            }

            return lstContactTypesEntity;
        }

        /// <summary>
        /// AddContactData
        /// </summary>
        /// <param name="objShowContactEntity"></param>
        /// <returns></returns>
        public Boolean AddContactData(ShowContactEntity objShowContactEntity)
        {
            var returnValue = 0;

            returnValue = entities.SP_I_AddContact(objShowContactEntity.PersonId, objShowContactEntity.BestContactId,
                                                            objShowContactEntity.Phone, objShowContactEntity.EmailAddress, objShowContactEntity.FAX,
                                                            objShowContactEntity.URL, objShowContactEntity.CreatedBy);
            if (returnValue < 1)
                return false;

            //if (objShowContactEntity.Phone != null)
            //{
            //    returnValue = entities.SP_I_AddContact(objShowContactEntity.PersonId, objShowContactEntity.BestContactId,
            //                                                objShowContactEntity.ContactTypeId, objShowContactEntity.Phone,
            //                                                objShowContactEntity.CreatedBy);
            //    if (returnValue < 1)
            //        return false;
            //}
            //if (objShowContactEntity.EmailAddress != null)
            //{
            //    returnValue = entities.SP_I_AddContact(objShowContactEntity.PersonId, objShowContactEntity.BestContactId,
            //                                                objShowContactEntity.ContactTypeId, objShowContactEntity.EmailAddress,
            //                                                objShowContactEntity.CreatedBy);
            //    if (returnValue < 1)
            //        return false;
            //}
            //if (objShowContactEntity.FAX != null)
            //{
            //    returnValue = entities.SP_I_AddContact(objShowContactEntity.PersonId, objShowContactEntity.BestContactId,
            //                                                objShowContactEntity.ContactTypeId, objShowContactEntity.FAX,
            //                                                objShowContactEntity.CreatedBy);
            //    if (returnValue < 1)
            //        return false;
            //}
            //if (objShowContactEntity.URL != null)
            //{
            //    returnValue = entities.SP_I_AddContact(objShowContactEntity.PersonId, objShowContactEntity.BestContactId,
            //                                                objShowContactEntity.ContactTypeId, objShowContactEntity.URL,
            //                                                objShowContactEntity.CreatedBy);
            //    if (returnValue < 1)
            //        return false;
            //}

            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// UpdateContactData
        /// </summary>
        /// <param name="objShowContactEntity"></param>
        /// <returns></returns>
        public Boolean UpdateContactData(ShowContactEntity objShowContactEntity)
        {
            var returnValue = entities.SP_U_UpdateContact(objShowContactEntity.ContractId,
                objShowContactEntity.BestContactId, objShowContactEntity.Phone,
                objShowContactEntity.EmailAddress, objShowContactEntity.ModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// DeleteContactData
        /// </summary>
        /// <param name="objShowContactEntity"></param>
        /// <returns></returns>
        public Boolean DeleteContactData(ShowContactEntity objShowContactEntity)
        {
            var returnValue = entities.SP_D_DeleteContact(objShowContactEntity.ContractId, objShowContactEntity.ModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Treasurer Profile Information
        /// </summary>
        /// <param name="personID"></param>
        /// <returns></returns>
        public IList<TreasurerProfileEntity> GetTreasurerProfileInfo(string personID)
        {
            IList<TreasurerProfileEntity> lstTreasurerProfileEntity = new List<TreasurerProfileEntity>();
            TreasurerProfileEntity objTreasurerProfileEntity;

            var results = entities.SP_S_TreasurerProfile(personID);

            foreach (var item in results)
            {
                objTreasurerProfileEntity = new TreasurerProfileEntity();
                objTreasurerProfileEntity.TransID = Convert.ToString(item.TREAS_ID);
                objTreasurerProfileEntity.PersonID = item.PERSON_ID.ToString();
                objTreasurerProfileEntity.TransRegDate = item.TREAS_REG_DATE.ToString();
                objTreasurerProfileEntity.Status = item.R_STATUS;
                objTreasurerProfileEntity.TransTermDate = item.TREAS_TERM_DATE.ToString();
                objTreasurerProfileEntity.PersonPrefix = item.PERSON_PREFIX;
                objTreasurerProfileEntity.PersonFirstName = item.PERSON_FIRST_NAME;
                objTreasurerProfileEntity.PersonMiddleName = item.PERSON_MIDDLE_NAME;
                objTreasurerProfileEntity.PersonLastName = item.PERSON_LAST_NAME;
                objTreasurerProfileEntity.PersonSuffix = item.PERSON_SUFFIX;
                lstTreasurerProfileEntity.Add(objTreasurerProfileEntity);
            }

            return lstTreasurerProfileEntity;
        }

        /// <summary>
        /// Get Committee Information
        /// </summary>
        /// <param name="transID"></param>
        /// <returns></returns>
        public IList<TreasurerCommitteeInformationEntity> GetTreasurerCommitteeInformation(string transID)
        {
            IList<TreasurerCommitteeInformationEntity> lstTreasurerCommitteeInformationEntity = new List<TreasurerCommitteeInformationEntity>();
            TreasurerCommitteeInformationEntity objTreasurerCommitteeInformationEntity;

            var results = entities.SP_S_Treas_CommitteeInformation(transID);

            foreach (var item in results)
            {
                objTreasurerCommitteeInformationEntity = new TreasurerCommitteeInformationEntity();
                objTreasurerCommitteeInformationEntity.CommID = Convert.ToString(item.COMM_ID);
                objTreasurerCommitteeInformationEntity.FilerID = Convert.ToString(item.FILER_ID);
                objTreasurerCommitteeInformationEntity.PersonID = item.PERSON_ID.ToString();
                objTreasurerCommitteeInformationEntity.CommitteeName = item.COMM_NAME.ToString();
                objTreasurerCommitteeInformationEntity.Status = item.R_STATUS;
                objTreasurerCommitteeInformationEntity.CommitteeRegDate = item.COMM_REG_DATE.ToString();
                objTreasurerCommitteeInformationEntity.CommitteeTermDate = item.COMM_TERM_DATE.ToString();
                objTreasurerCommitteeInformationEntity.CommitteeTypeDesc = item.COMM_TYPE_DESC.ToString();
                lstTreasurerCommitteeInformationEntity.Add(objTreasurerCommitteeInformationEntity);
            }

            return lstTreasurerCommitteeInformationEntity;
        }

        /// <summary>
        /// Get Transurer Assistant Information
        /// </summary>
        /// <param name="commID"></param>
        /// <returns></returns>
        public IList<TreasAssistantInformationEntity> GetTreasurerAssistantInformation(string commID)
        {
            IList<TreasAssistantInformationEntity> lstTreasAssistantInformationEntity = new List<TreasAssistantInformationEntity>();
            TreasAssistantInformationEntity objTreasAssistantInformationEntity;

            var results = entities.SP_S_Treas_AssistantTrensInformation(commID);

            foreach (var item in results)
            {
                objTreasAssistantInformationEntity = new TreasAssistantInformationEntity();
                objTreasAssistantInformationEntity.PersonPrefix = item.PERSON_PREFIX;
                objTreasAssistantInformationEntity.PersonFirstName = item.PERSON_FIRST_NAME;
                objTreasAssistantInformationEntity.PersonMiddleName = item.PERSON_MIDDLE_NAME;
                objTreasAssistantInformationEntity.PersonLastName = item.PERSON_LAST_NAME;
                objTreasAssistantInformationEntity.PersonSuffix = item.PERSON_SUFFIX;
                objTreasAssistantInformationEntity.PersonID = item.PERSON_ID.ToString();
                lstTreasAssistantInformationEntity.Add(objTreasAssistantInformationEntity);
            }

            return lstTreasAssistantInformationEntity;
        }

        /// <summary>
        /// Treasurer History Information
        /// </summary>
        /// <param name="commID"></param>
        /// <param name="transID"></param>
        /// <returns></returns>
        public IList<TreasurerHistoryEntity> GetTreasurerHistoryInformation(string commID, string transID)
        {
            IList<TreasurerHistoryEntity> lstTreasurerHistoryEntity = new List<TreasurerHistoryEntity>();
            TreasurerHistoryEntity objTreasurerHistoryEntity;

            var results = entities.SP_S_TreasurerHistory(commID, transID);

            foreach (var item in results)
            {
                objTreasurerHistoryEntity = new TreasurerHistoryEntity();
                objTreasurerHistoryEntity.PersonPrefix = item.PERSON_PREFIX;
                objTreasurerHistoryEntity.PersonFirstName = item.PERSON_FIRST_NAME;
                objTreasurerHistoryEntity.PersonMiddleName = item.PERSON_MIDDLE_NAME;
                objTreasurerHistoryEntity.PersonLastName = item.PERSON_LAST_NAME;
                objTreasurerHistoryEntity.PersonSuffix = item.PERSON_SUFFIX;
                objTreasurerHistoryEntity.Status = item.R_STATUS;
                objTreasurerHistoryEntity.RegDate = item.REG_DATE.ToString();
                objTreasurerHistoryEntity.TermDate = item.TERM_DATE.ToString();
                objTreasurerHistoryEntity.PersonID = item.PERSON_ID.ToString();
                lstTreasurerHistoryEntity.Add(objTreasurerHistoryEntity);
            }

            return lstTreasurerHistoryEntity;
        }

        /// <summary>
        /// Get Treasurer Additional Committee Contact
        /// </summary>
        /// <param name="commID"></param>
        /// <returns></returns>
        public IList<TreasAdditionalCommitteeContactEntity> GetTreasurerAdditionalCommitteeContact(string commID)
        {
            IList<TreasAdditionalCommitteeContactEntity> lstTreasAdditionalCommitteeContactEntity = new List<TreasAdditionalCommitteeContactEntity>();
            TreasAdditionalCommitteeContactEntity objTreasAdditionalCommitteeContactEntity;

            var results = entities.SP_S_Trea_AdditionalCommitteeContact(commID);

            foreach (var item in results)
            {
                objTreasAdditionalCommitteeContactEntity = new TreasAdditionalCommitteeContactEntity();
                objTreasAdditionalCommitteeContactEntity.PersonPrefix = item.PERSON_PREFIX;
                objTreasAdditionalCommitteeContactEntity.PersonFirstName = item.PERSON_FIRST_NAME;
                objTreasAdditionalCommitteeContactEntity.PersonMiddleName = item.PERSON_MIDDLE_NAME;
                objTreasAdditionalCommitteeContactEntity.PersonLastName = item.PERSON_LAST_NAME;
                objTreasAdditionalCommitteeContactEntity.PersonSuffix = item.PERSON_SUFFIX;
                lstTreasAdditionalCommitteeContactEntity.Add(objTreasAdditionalCommitteeContactEntity);
            }

            return lstTreasAdditionalCommitteeContactEntity;
        }

        /// <summary>
        /// Get Treasurer Depository Bank Information
        /// </summary>
        /// <param name="commID"></param>
        /// <returns></returns>
        public IList<TreasDepositoryBankInformationEntity> GetTreasurerDepositoryBankInformation(string commID)
        {
            IList<TreasDepositoryBankInformationEntity> lstTreasDepositoryBankInformationEntity = new List<TreasDepositoryBankInformationEntity>();
            TreasDepositoryBankInformationEntity objTreasDepositoryBankInformationEntity;

            var results = entities.SP_S_Trea_DepositoryBankInformation(commID);

            foreach (var item in results)
            {
                objTreasDepositoryBankInformationEntity = new TreasDepositoryBankInformationEntity();
                objTreasDepositoryBankInformationEntity.BankID = item.BANK_ID.ToString();
                objTreasDepositoryBankInformationEntity.BankName = item.BANK_NAME;
                objTreasDepositoryBankInformationEntity.AddrNum = item.ADDR_STR_NUM;
                objTreasDepositoryBankInformationEntity.AddrStrName = item.ADDR_STR_NAME;
                objTreasDepositoryBankInformationEntity.AddrCity = item.ADDR_CITY;
                objTreasDepositoryBankInformationEntity.AddrState = item.ADDR_STATE;
                objTreasDepositoryBankInformationEntity.AddrZip = item.ADDR_ZIP.ToString();
                objTreasDepositoryBankInformationEntity.AddrZip4 = item.ADDR_ZIP4.ToString();
                objTreasDepositoryBankInformationEntity.ADDR_ID = item.ADDR_ID.ToString();
                objTreasDepositoryBankInformationEntity.PERSON_ID = item.PERSON_ID.ToString();
                objTreasDepositoryBankInformationEntity.COMM_ID = item.COMM_ID.ToString();
                lstTreasDepositoryBankInformationEntity.Add(objTreasDepositoryBankInformationEntity);
            }

            return lstTreasDepositoryBankInformationEntity;
        }

        public IList<TreasCandidateSupportOpposeEntity> GetTreasurerCandidateSupposeOppose(string commID)
        {
            IList<TreasCandidateSupportOpposeEntity> lstTreasCandidateSupportOpposeEntity = new List<TreasCandidateSupportOpposeEntity>();
            TreasCandidateSupportOpposeEntity objTreasCandidateSupportOpposeEntity;

            var results = entities.SP_S_Trea_Candidate_Suppot_Oppose(commID);

            foreach (var item in results)
            {
                objTreasCandidateSupportOpposeEntity = new TreasCandidateSupportOpposeEntity();
                objTreasCandidateSupportOpposeEntity.ElectionYear = item.ELECT_YEAR.ToString();
                objTreasCandidateSupportOpposeEntity.OfficeDesc = item.OFFICE_DESC;
                objTreasCandidateSupportOpposeEntity.DistID = item.DIST_ID.ToString();
                objTreasCandidateSupportOpposeEntity.PersonFirstName = item.PERSON_FIRST_NAME;
                objTreasCandidateSupportOpposeEntity.PersonMiddleName = item.PERSON_MIDDLE_NAME;
                objTreasCandidateSupportOpposeEntity.PersonLastName = item.PERSON_LAST_NAME;
                objTreasCandidateSupportOpposeEntity.SupposeOppose = item.SUPPONE_OPPOSE.ToString();
                if (item.AUTHORIZED_DATE != null)
                {
                    objTreasCandidateSupportOpposeEntity.AuthorizedDate = item.AUTHORIZED_DATE.ToString();
                }
                else
                {
                    objTreasCandidateSupportOpposeEntity.AuthorizedDate = "";
                }
                if (item.NON_EXPENDITURE_DATE != null)
                {
                    objTreasCandidateSupportOpposeEntity.NonExpenditureDate = item.NON_EXPENDITURE_DATE.ToString();
                }
                else
                {
                    objTreasCandidateSupportOpposeEntity.NonExpenditureDate = "";
                }

                lstTreasCandidateSupportOpposeEntity.Add(objTreasCandidateSupportOpposeEntity);
            }

            return lstTreasCandidateSupportOpposeEntity;
        }

        /// <summary>
        /// Get Treasurer Authorized To Sign Check Conract
        /// </summary>
        /// <param name="commID"></param>
        /// <returns></returns>
        public IList<TreasAuthorizedToSignCheckEntity> GetTreasurerAuthorizedToSignCheckContact(string commID)
        {
            IList<TreasAuthorizedToSignCheckEntity> lstTreasAuthorizedToSignCheckEntity = new List<TreasAuthorizedToSignCheckEntity>();
            TreasAuthorizedToSignCheckEntity objTreasAuthorizedToSignCheckEntity;

            var results = entities.SP_S_Trea_AuthorizedToSignCheck(commID);

            foreach (var item in results)
            {
                objTreasAuthorizedToSignCheckEntity = new TreasAuthorizedToSignCheckEntity();
                objTreasAuthorizedToSignCheckEntity.PersonPrefix = item.PERSON_PREFIX;
                objTreasAuthorizedToSignCheckEntity.PersonFirstName = item.PERSON_FIRST_NAME;
                objTreasAuthorizedToSignCheckEntity.PersonMiddleName = item.PERSON_MIDDLE_NAME;
                objTreasAuthorizedToSignCheckEntity.PersonLastName = item.PERSON_LAST_NAME;
                objTreasAuthorizedToSignCheckEntity.PersonSuffix = item.PERSON_SUFFIX;
                objTreasAuthorizedToSignCheckEntity.AuthSignedID = item.AUTH_SIGN_ID.ToString();
                objTreasAuthorizedToSignCheckEntity.PersonID = item.PERSON_ID.ToString();
                objTreasAuthorizedToSignCheckEntity.StartDate = item.START_DATE.ToString();
                objTreasAuthorizedToSignCheckEntity.EndDate = item.END_DATE.ToString();
                objTreasAuthorizedToSignCheckEntity.Status = item.STATUS.ToString();
                lstTreasAuthorizedToSignCheckEntity.Add(objTreasAuthorizedToSignCheckEntity);
            }

            return lstTreasAuthorizedToSignCheckEntity;
        }

        /// <summary>
        /// Get Treasurer Ballot Issues Contract
        /// </summary>
        /// <param name="commID"></param>
        /// <returns></returns>
        public IList<TreasBallotIssuesEntity> GetTreasurerBallotIssuesContact(string commID)
        {
            IList<TreasBallotIssuesEntity> lstTreasBallotIssuesEntity = new List<TreasBallotIssuesEntity>();
            TreasBallotIssuesEntity objTreasBallotIssuesEntity;

            var results = entities.SP_S_Trea_BallotIssues(commID);

            foreach (var item in results)
            {
                objTreasBallotIssuesEntity = new TreasBallotIssuesEntity();
                objTreasBallotIssuesEntity.BallotIssues = item.BALLOT_ISSUES.ToString();
                objTreasBallotIssuesEntity.SupposeOppose = item.SUPPONE_OPPOSE.ToString();
                lstTreasBallotIssuesEntity.Add(objTreasBallotIssuesEntity);
            }

            return lstTreasBallotIssuesEntity;
        }

        /// AddDepositoryBankInfo
        /// </summary>
        /// <param name="objDepositoryBankInfoEntity"></param>
        /// <returns></returns>
        public Boolean AddDepositoryBankInfo(DepositoryBankInfoEntity objDepositoryBankInfoEntity)
        {
            var returnValue = entities.SP_I_DepositoryBankInfo(objDepositoryBankInfoEntity.PersonId,
                                                               objDepositoryBankInfoEntity.CandidateId,
                                                               objDepositoryBankInfoEntity.DepositoryBankName,
                                                               objDepositoryBankInfoEntity.BankAccountTypeId,
                                                               objDepositoryBankInfoEntity.StreetName,
                                                               objDepositoryBankInfoEntity.City,
                                                               objDepositoryBankInfoEntity.State,
                                                               objDepositoryBankInfoEntity.Zip,
                                                               objDepositoryBankInfoEntity.CreatedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        /// AddDepositoryBankInfo
        /// </summary>
        /// <param name="objDepositoryBankInfoEntity"></param>
        /// <returns></returns>
        public Boolean AddDepositoryBankInfoTreasurer(TreasDepositoryBankInformationEntity objDepositoryBankInfoEntity)
        {
            var returnValue = entities.SP_I_DepositoryBankInfoForTrea(objDepositoryBankInfoEntity.PERSON_ID,
                objDepositoryBankInfoEntity.COMM_ID, objDepositoryBankInfoEntity.BankName,
                objDepositoryBankInfoEntity.BankAccountTypeID,
                objDepositoryBankInfoEntity.AddrStrName, objDepositoryBankInfoEntity.AddrCity,
                objDepositoryBankInfoEntity.AddrState, objDepositoryBankInfoEntity.AddrZip, objDepositoryBankInfoEntity.CreatedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }



        /// <summary>
        /// UpdateDepositoryBankInfo
        /// </summary>
        /// <param name="objDepositoryBankInfoEntity"></param>
        /// <returns></returns>
        public Boolean UpdateDepositoryBankInfo(DepositoryBankInfoEntity objDepositoryBankInfoEntity)
        {
            var returnValue = entities.SP_U_DepositoryBankInfo(objDepositoryBankInfoEntity.AddressId, objDepositoryBankInfoEntity.BankId,
                objDepositoryBankInfoEntity.DepositoryBankName, objDepositoryBankInfoEntity.BankAccountTypeId,
                objDepositoryBankInfoEntity.StreetName, objDepositoryBankInfoEntity.City,
                objDepositoryBankInfoEntity.State, objDepositoryBankInfoEntity.Zip, objDepositoryBankInfoEntity.ModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// DeleteDepositoryBankInfo
        /// </summary>
        /// <param name="objDepositoryBankInfoEntity"></param>
        /// <returns></returns>
        public Boolean DeleteDepositoryBankInfo(DepositoryBankInfoEntity objDepositoryBankInfoEntity)
        {
            var returnValue = entities.SP_D_DepositoryBankInfo(objDepositoryBankInfoEntity.AddressId, objDepositoryBankInfoEntity.BankId,
                objDepositoryBankInfoEntity.ModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// GetBankAccountTypes
        /// </summary>
        /// <returns></returns>
        public IList<BankAccountTypesEntity> GetBankAccountTypes()
        {
            IList<BankAccountTypesEntity> lstBankAccountTypesEntity = new List<BankAccountTypesEntity>();
            BankAccountTypesEntity objBankAccountTypesEntity;

            var results = entities.SP_S_BankAccountType();

            foreach (var item in results)
            {
                objBankAccountTypesEntity = new BankAccountTypesEntity();
                objBankAccountTypesEntity.AccountTypeId = Convert.ToString(item.ACCOUNT_TYPE_ID);
                objBankAccountTypesEntity.AccountTypeDesc = item.ACCOUNT_TYPE_DESC;
                lstBankAccountTypesEntity.Add(objBankAccountTypesEntity);
            }

            return lstBankAccountTypesEntity;
        }

        public Boolean AddSubTreasurerData(SubTreasurerPersonEntity objSubTreasurerPersonEntity)
        {
            var returnValue = entities.SP_I_SubTresurer(objSubTreasurerPersonEntity.StateDate,
                objSubTreasurerPersonEntity.RStatus, objSubTreasurerPersonEntity.FirstName, objSubTreasurerPersonEntity.MiddleName,
                objSubTreasurerPersonEntity.LastName, objSubTreasurerPersonEntity.Suffix, objSubTreasurerPersonEntity.Preffix,
                objSubTreasurerPersonEntity.TreasurerId, objSubTreasurerPersonEntity.CreatedBy);

            if (returnValue >= 2)
                return true;
            else
                return false;
        }

        public Boolean UpdateSubTreasurerData(SubTreasurerPersonEntity objSubTreasurerPersonEntity)
        {
            var returnValue = entities.SP_U_SubTreasurer(objSubTreasurerPersonEntity.PersonId,
                objSubTreasurerPersonEntity.FirstName, objSubTreasurerPersonEntity.MiddleName,
                objSubTreasurerPersonEntity.LastName, objSubTreasurerPersonEntity.Suffix,
                objSubTreasurerPersonEntity.Preffix, objSubTreasurerPersonEntity.SubTreasurerId,
                objSubTreasurerPersonEntity.RStatus, objSubTreasurerPersonEntity.StateDate,
                objSubTreasurerPersonEntity.ModifiedBy);

            if (returnValue >= 2)
                return true;
            else
                return false;
        }

        /// <summary>
        /// GetFilingTransactionsData
        /// </summary>
        /// <param name="objFilingTransDataEntity"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataEntity> GetFilingTransactionsData(FilingTransDataEntity objFilingTransDataEntity)
        {
            IList<FilingTransactionDataEntity> lstFilingTransactionDataEntity = new List<FilingTransactionDataEntity>();
            FilingTransactionDataEntity objFilingTransactionDataEntity;

            //var results1 = entities.SP_S_ElectionYear();

            var results = entities.SP_S_Filing_Transactions_Data(objFilingTransDataEntity.FilerId,
                objFilingTransDataEntity.ReportYearId, objFilingTransDataEntity.OfficeTypeId,
                objFilingTransDataEntity.DisclosurePeriod, objFilingTransDataEntity.ElectionType, objFilingTransDataEntity.ElectionDateId, objFilingTransDataEntity.FilingDate);

            //var results = entities.SP_S_FilingTransactionsData(objFilingTransDataEntity.FilerId,
            //  objFilingTransDataEntity.ReportYearId, objFilingTransDataEntity.OfficeTypeId,
            //  objFilingTransDataEntity.DisclosurePeriod);

            foreach (var item in results)
            {
                objFilingTransactionDataEntity = new FilingTransactionDataEntity();
                objFilingTransactionDataEntity.FilingTransId = Convert.ToString(item.FILING_TRANS_ID);
                objFilingTransactionDataEntity.FilingSchedId = Convert.ToString(item.FILING_SCHED_ID);
                objFilingTransactionDataEntity.ContributorTypeId = Convert.ToString(item.CNTRBR_TYPE_ID);
                objFilingTransactionDataEntity.ContributorTypeDesc = item.CNTRBR_TYPE_DESC;
                objFilingTransactionDataEntity.ContributionTypeId = Convert.ToString(item.CNTRBN_TYPE_ID);
                objFilingTransactionDataEntity.PaymentTypeId = Convert.ToString(item.PAYMENT_TYPE_ID);
                if (item.SCHED_DATE != "")
                    objFilingTransactionDataEntity.SchedDate = Convert.ToDateTime(item.SCHED_DATE).ToShortDateString();
                else
                    objFilingTransactionDataEntity.SchedDate = "";
                objFilingTransactionDataEntity.FilingSchedDesc = item.FILING_SCHED_DESC;
                objFilingTransactionDataEntity.FilingEntityId = item.FLNG_ENT_ID;
                objFilingTransactionDataEntity.FilingEntityName = item.FLNG_ENT_NAME;
                objFilingTransactionDataEntity.FilingFirstName = item.FLNG_ENT_FIRST_NAME;
                objFilingTransactionDataEntity.FilingMiddleName = item.FLNG_ENT_MIDDLE_NAME;
                objFilingTransactionDataEntity.FilingLastName = item.FLNG_ENT_LAST_NAME;
                objFilingTransactionDataEntity.FilingStreetNumber = item.FLNG_ENT_STR_NUM;
                objFilingTransactionDataEntity.FilingStreetName = item.FLNG_ENT_STR_NAME;
                objFilingTransactionDataEntity.FilingCity = item.FLNG_ENT_CITY;
                objFilingTransactionDataEntity.FilingState = item.FLNG_ENT_STATE;
                objFilingTransactionDataEntity.FilingZip = item.FLNG_ENT_ZIP;
                objFilingTransactionDataEntity.FilingCountry = item.FLNG_ENT_COUNTRY;
                objFilingTransactionDataEntity.PaymentTypeDesc = item.PAYMENT_TYPE_DESC;
                objFilingTransactionDataEntity.PayNumber = item.PAY_NUMBER;
                objFilingTransactionDataEntity.OriginalAmount = String.Format("{0:0.00}", item.ORG_AMT);
                objFilingTransactionDataEntity.ReceiptTypeDesc = item.RECEIPT_TYPE_ABBREV;
                objFilingTransactionDataEntity.TransferTypeDesc = item.TRANSFER_TYPE_ABBREV;
                objFilingTransactionDataEntity.ContributionTypeDesc = item.CNTRBN_TYPE_DESC;
                objFilingTransactionDataEntity.PurposeCodeDesc = item.PURPOSE_CODE_ABBREV;
                objFilingTransactionDataEntity.ReceiptCodeDesc = item.RECEIPT_CODE_DESC;
                objFilingTransactionDataEntity.ReceiptCodeId = item.RECEIPT_CODE_ID;
                objFilingTransactionDataEntity.RLiability = item.R_LIABILITY;
                objFilingTransactionDataEntity.RSubcontractor = item.R_SUBCONTRACTOR;
                if (item.ORG_DATE != "")
                    objFilingTransactionDataEntity.OriginalDate = Convert.ToDateTime(item.ORG_DATE).ToShortDateString();
                else
                    objFilingTransactionDataEntity.OriginalDate = "";
                //objFilingTransactionDataEntity.LoanerCode = item.R_BANK_LOAN;
                objFilingTransactionDataEntity.ElectionYear = item.ELECTION_YEAR;
                objFilingTransactionDataEntity.Office = Convert.ToString(item.OFFICE_ID);
                objFilingTransactionDataEntity.District = Convert.ToString(item.DISTRICT);
                objFilingTransactionDataEntity.TransExplanation = item.TRANS_EXPLNTN;
                objFilingTransactionDataEntity.OwedAmount = String.Format("{0:0.00}", item.OWED_AMT);
                if (item.R_ITEMIZED == "" || item.R_ITEMIZED == null)
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "Y")
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "N")
                    objFilingTransactionDataEntity.RItemized = "No";
                objFilingTransactionDataEntity.CountyID = Convert.ToString(item.COUNTY_ID);
                objFilingTransactionDataEntity.CountyDesc = Convert.ToString(item.CNTY_DESC);
                objFilingTransactionDataEntity.MunicipalityID = Convert.ToString(item.MUNICIPALITY_ID);
                objFilingTransactionDataEntity.MunicipalityDesc = Convert.ToString(item.MUNICIPALITY_DESC);
                objFilingTransactionDataEntity.LoanerCodeId = Convert.ToString(item.LOAN_OTHER_ID);
                objFilingTransactionDataEntity.LoanerCode = Convert.ToString(item.LOAN_OTHER_DESC);
                objFilingTransactionDataEntity.CreatedDate = item.CREATED_DATE;
                objFilingTransactionDataEntity.LoanLiablityNumber = item.LOAN_LIB_NUMBER;
                objFilingTransactionDataEntity.TransNumber = item.TRANS_NUMBER;
                objFilingTransactionDataEntity.TransMapping = item.TRANS_MAPPING;
                lstFilingTransactionDataEntity.Add(objFilingTransactionDataEntity);
            }

            return lstFilingTransactionDataEntity;
        }

        public IList<ContributionTypeEntity> GetContributionTypeData()
        {
            IList<ContributionTypeEntity> lstContributionTypeEntity = new List<ContributionTypeEntity>();
            ContributionTypeEntity objContributionTypeEntity;

            var results = entities.SP_S_ContributionType();

            foreach (var item in results)
            {
                objContributionTypeEntity = new ContributionTypeEntity();
                objContributionTypeEntity.ContributionTypeId = Convert.ToString(item.CNTRBN_TYPE_ID);
                objContributionTypeEntity.ContributionTypeDesc = item.CNTRBN_TYPE_DESC;
                objContributionTypeEntity.ContributionTypeAbbrev = item.CNTRBN_TYPE_ABBREV;
                lstContributionTypeEntity.Add(objContributionTypeEntity);
            }

            return lstContributionTypeEntity;
        }

        public IList<ContributorNameEntity> GetContributionNameData()
        {
            IList<ContributorNameEntity> lstContributorNameEntity = new List<ContributorNameEntity>();
            ContributorNameEntity objContributorNameEntity;

            var results = entities.SP_S_ContributorTypesInKind();

            foreach (var item in results)
            {
                objContributorNameEntity = new ContributorNameEntity();
                objContributorNameEntity.ContributorTypeId = Convert.ToString(item.CNTRBR_TYPE_ID);
                objContributorNameEntity.ContributorTypeDesc = item.CNTRBR_TYPE_DESC;
                objContributorNameEntity.ContributorTypeAbbrev = item.CNTRBR_TYPE_ABBREV;
                lstContributorNameEntity.Add(objContributorNameEntity);
            }

            return lstContributorNameEntity;
        }

        public IList<DisclosurePreiodEntity> GetDisclosurePeriodData(String strElectTypeId)
        {
            IList<DisclosurePreiodEntity> lstDisclosurePreiodEntity = new List<DisclosurePreiodEntity>();
            DisclosurePreiodEntity objDisclosurePreiodEntity;

            var results = entities.SP_S_DisclosurePeriod(strElectTypeId);

            foreach (var item in results)
            {
                objDisclosurePreiodEntity = new DisclosurePreiodEntity();
                objDisclosurePreiodEntity.FilingTypeId = Convert.ToString(item.FILING_TYPE_ID);
                objDisclosurePreiodEntity.FilingDesc = item.FILING_DESC;
                objDisclosurePreiodEntity.FilingAbbrev = item.FILING_ABBREV;
                lstDisclosurePreiodEntity.Add(objDisclosurePreiodEntity);
            }

            return lstDisclosurePreiodEntity;
        }

        public IList<ElectionDateEntity> GetElectionDateData(String strElectYearId, String strElectTypeId, String strOfficeTypeId)
        {
            IList<ElectionDateEntity> lstElectionDateEntity = new List<ElectionDateEntity>();
            ElectionDateEntity objElectionDateEntity;

            var results = entities.SP_S_ElectionDate(strElectYearId, strElectTypeId, strOfficeTypeId);

            foreach (var item in results)
            {
                objElectionDateEntity = new ElectionDateEntity();
                objElectionDateEntity.ElectId = Convert.ToString(item.POL_CAL_DATE_ID);
                objElectionDateEntity.ElectDate = Convert.ToDateTime(item.ELECTION_DATE).ToShortDateString();
                lstElectionDateEntity.Add(objElectionDateEntity);
            }

            return lstElectionDateEntity;
        }


        public IList<FilerCommitteeEntity> GetFilerCommitteeData(String strfilerID)
        {
            IList<FilerCommitteeEntity> lstFilerCommitteeEntity = new List<FilerCommitteeEntity>();
            FilerCommitteeEntity objFilerCommitteeEntity;

            var results = entities.SP_S_GetFilerCommittee_FilerMapping(strfilerID);

            foreach (var item in results)
            {
                objFilerCommitteeEntity = new FilerCommitteeEntity();
                objFilerCommitteeEntity.FilerId = Convert.ToString(item.FILER_ID);
                objFilerCommitteeEntity.CommitteeId = Convert.ToString(item.COMM_ID);
                objFilerCommitteeEntity.CommitteeName = item.COMM_NAME;
                objFilerCommitteeEntity.OfficeId = item.OFFICE_ID;
                objFilerCommitteeEntity.personID = Convert.ToString(item.PERSON_ID);
                objFilerCommitteeEntity.TreasurerId = Convert.ToString(item.TREAS_ID);
                lstFilerCommitteeEntity.Add(objFilerCommitteeEntity);
            }

            return lstFilerCommitteeEntity;
        }

        public IList<PaymentMethodEntity> GetPaymentMethodData()
        {
            IList<PaymentMethodEntity> lstPaymentMethodEntity = new List<PaymentMethodEntity>();
            PaymentMethodEntity objPaymentMethodEntity;

            var results = entities.SP_S_PaymentMethod();

            foreach (var item in results)
            {
                objPaymentMethodEntity = new PaymentMethodEntity();
                objPaymentMethodEntity.PaymentTypeId = Convert.ToString(item.PAYMENT_TYPE_ID);
                objPaymentMethodEntity.PaymentTypeDesc = Convert.ToString(item.PAYMENT_TYPE_DESC);
                objPaymentMethodEntity.PaymentTypeAbbrev = item.PAYMENT_TYPE_ABBREV;
                lstPaymentMethodEntity.Add(objPaymentMethodEntity);
            }

            return lstPaymentMethodEntity;
        }

        public IList<PurposeCodeEntity> GetPurposeCodeData()
        {
            IList<PurposeCodeEntity> lstPurposeCodeEntity = new List<PurposeCodeEntity>();
            PurposeCodeEntity objPurposeCodeEntity;

            var results = entities.SP_S_PurposeCode();

            foreach (var item in results)
            {
                objPurposeCodeEntity = new PurposeCodeEntity();
                objPurposeCodeEntity.PurposeCodeId = Convert.ToString(item.PURPOSE_CODE_ID);
                objPurposeCodeEntity.PurposeCodeDesc = item.PURPOSE_CODE_DESC;
                objPurposeCodeEntity.PurposeCodeAbbrev = item.PURPOSE_CODE_ABBREV;
                lstPurposeCodeEntity.Add(objPurposeCodeEntity);
            }

            return lstPurposeCodeEntity;
        }

        public IList<ReceiptCodeEntity> GetReceiptCodeData()
        {
            IList<ReceiptCodeEntity> lstReceiptCodeEntity = new List<ReceiptCodeEntity>();
            ReceiptCodeEntity objReceiptCodeEntity;

            var results = entities.SP_S_ReceiptCode();

            foreach (var item in results)
            {
                objReceiptCodeEntity = new ReceiptCodeEntity();
                objReceiptCodeEntity.ReceiptCodeId = Convert.ToString(item.RECEIPT_CODE_ID);
                objReceiptCodeEntity.ReceiptCodeDesc = item.RECEIPT_CODE_DESC;
                objReceiptCodeEntity.ReceiptCodeAbbrev = item.RECEIPT_CODE_ABBREV;
                lstReceiptCodeEntity.Add(objReceiptCodeEntity);
            }

            return lstReceiptCodeEntity;
        }

        public IList<ReceiptTypeEntity> GetReceiptTypeData()
        {
            IList<ReceiptTypeEntity> lstReceiptTypeEntity = new List<ReceiptTypeEntity>();
            ReceiptTypeEntity objReceiptTypeEntity;

            var results = entities.SP_S_ReceiptType();

            foreach (var item in results)
            {
                objReceiptTypeEntity = new ReceiptTypeEntity();
                objReceiptTypeEntity.ReceiptTypeId = Convert.ToString(item.RECEIPT_TYPE_ID);
                objReceiptTypeEntity.ReceiptTypeDesc = item.RECEIPT_TYPE_DESC;
                objReceiptTypeEntity.ReceiptTypeAbbrev = item.RECEIPT_TYPE_ABBREV;
                lstReceiptTypeEntity.Add(objReceiptTypeEntity);
            }

            return lstReceiptTypeEntity;
        }

        /// <summary>
        /// GetTransferTypeData
        /// </summary>
        /// <returns></returns>
        public IList<TransferTypeEntity> GetTransferTypeData()
        {
            IList<TransferTypeEntity> lstTransferTypeEntity = new List<TransferTypeEntity>();
            TransferTypeEntity objTransferTypeEntity;

            var results = entities.SP_S_TransferType();

            foreach (var item in results)
            {
                objTransferTypeEntity = new TransferTypeEntity();
                objTransferTypeEntity.TransferTypeId = Convert.ToString(item.TRANSFER_TYPE_ID);
                objTransferTypeEntity.TransferTypeDesc = item.TRANSFER_TYPE_DESC;
                objTransferTypeEntity.TransferTypeAbbrev = item.TRANSFER_TYPE_ABBREV;
                lstTransferTypeEntity.Add(objTransferTypeEntity);
            }

            return lstTransferTypeEntity;
        }

        /// <summary>
        /// GetElectionYearData
        /// </summary>
        /// <returns></returns>
        public IList<ElectionYearEntity> GetElectionYearData()
        {
            IList<ElectionYearEntity> lstElectionYearEntity = new List<ElectionYearEntity>();
            ElectionYearEntity objElectionYearEntity;

            var results = entities.SP_S_ElectionYear();

            foreach (var item in results)
            {
                objElectionYearEntity = new ElectionYearEntity();
                objElectionYearEntity.ElectionYearId = Convert.ToString(item.ELECTION_YEAR_ID);
                objElectionYearEntity.ElectionYearValue = Convert.ToString(item.ELECT_YEAR);
                lstElectionYearEntity.Add(objElectionYearEntity);
            }

            return lstElectionYearEntity;
        }

        /// <summary>
        /// GetElectionTypeData
        /// </summary>
        /// <param name="strElectionYearId"></param>
        /// <returns></returns>
        public IList<ElectionTypeEntity> GetElectionTypeData(String strElectionYearId,
            String strOfficeTypeId, String strCountyId, String strMunicipalityId)
        {
            IList<ElectionTypeEntity> lstElectionTypeEntity = new List<ElectionTypeEntity>();
            ElectionTypeEntity objElectionTypeEntity;

            var results = entities.SP_S_EFSElectionType(strElectionYearId, strOfficeTypeId,
                strCountyId, strMunicipalityId);

            foreach (var item in results)
            {
                objElectionTypeEntity = new ElectionTypeEntity();
                objElectionTypeEntity.ElectionTypeId = Convert.ToString(item.ELECT_TYPE_ID);
                objElectionTypeEntity.ElectionTypeDesc = item.ELECT_TYPE_DESC;
                lstElectionTypeEntity.Add(objElectionTypeEntity);
            }

            return lstElectionTypeEntity;
        }

        /// <summary>
        /// GetFilingCutOffDateData
        /// </summary>
        /// <param name="strElectYearId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <returns></returns>
        public IList<FilingCutOffDateEntity> GetFilingCutOffDateData(String strElectYearId, String strFilingTypeId, String strOfficeTypeId,
            String strFilingDateId, String strCuttOffDateId, String strElectionDateId)
        {
            IList<FilingCutOffDateEntity> lstFilingCutOffDateEntity = new List<FilingCutOffDateEntity>();
            FilingCutOffDateEntity objFilingCutOffDateEntity;

            var results = entities.SP_S_FilingAndCutOffDate(strElectYearId, strFilingTypeId, strOfficeTypeId, strFilingDateId, strCuttOffDateId, strElectionDateId);

            foreach (var item in results)
            {
                objFilingCutOffDateEntity = new FilingCutOffDateEntity();
                objFilingCutOffDateEntity.PoliticalCalDateId = Convert.ToString(item.POL_CAL_DATE_ID);
                objFilingCutOffDateEntity.PoliticalCalLabelId = Convert.ToString(item.POL_CAL_LBL_ID);
                if (Convert.ToString(item.POL_CAL_LBL_ID) == strFilingDateId)
                    objFilingCutOffDateEntity.FilingDueDate = item.FILING_AND_CUTT_OFF_DATE;
                if (Convert.ToString(item.POL_CAL_LBL_ID) == strCuttOffDateId)
                    objFilingCutOffDateEntity.CutOffDate = item.FILING_AND_CUTT_OFF_DATE;
                lstFilingCutOffDateEntity.Add(objFilingCutOffDateEntity);
            }

            return lstFilingCutOffDateEntity;
        }

        /// <summary>
        /// GetContributorTypesData
        /// </summary>
        /// <returns></returns>
        public IList<ContributorTypesEntity> GetContributorTypesData()
        {
            IList<ContributorTypesEntity> lstContributorTypesEntity = new List<ContributorTypesEntity>();
            ContributorTypesEntity objContributorTypesEntity;

            var results = entities.SP_S_ContributorTypes();

            foreach (var item in results)
            {
                objContributorTypesEntity = new ContributorTypesEntity();
                objContributorTypesEntity.ContributorTypeId = Convert.ToString(item.CNTRBR_TYPE_ID);
                objContributorTypesEntity.ContributoryTypeDesc = item.CNTRBR_TYPE_DESC;
                lstContributorTypesEntity.Add(objContributorTypesEntity);
            }

            return lstContributorTypesEntity;
        }

        /// <summary>
        /// GetTransactionTypesData
        /// </summary>
        /// <returns></returns>
        public IList<TransactionTypesEntity> GetTransactionTypesData(String strCandCommId = "")
        {
            IList<TransactionTypesEntity> lstTransactionTypesEntity = new List<TransactionTypesEntity>();
            TransactionTypesEntity objTransactionTypesEntity;

            var results = entities.SP_S_TransactionTypes(strCandCommId);

            foreach (var item in results)
            {
                objTransactionTypesEntity = new TransactionTypesEntity();
                objTransactionTypesEntity.FilingSchedId = Convert.ToString(item.FILING_SCHED_ID);
                objTransactionTypesEntity.FilingSchedDesc = item.FILING_SCHED_DESC;
                objTransactionTypesEntity.FilingSchedAbbrev = item.FILING_SCHED_ABBREV;
                lstTransactionTypesEntity.Add(objTransactionTypesEntity);
            }

            return lstTransactionTypesEntity;
        }

        /// <summary>
        /// GetDisclosureTypesData
        /// </summary>
        /// <returns></returns>
        public IList<DisclosureTypesEntity> GetDisclosureTypesData(String strCandCommId)
        {
            IList<DisclosureTypesEntity> lstDisclosureTypesEntity = new List<DisclosureTypesEntity>();
            DisclosureTypesEntity objDisclosureTypesEntity;

            var results = entities.SP_S_DisclosureTypes(strCandCommId);

            foreach (var item in results)
            {
                objDisclosureTypesEntity = new DisclosureTypesEntity();
                objDisclosureTypesEntity.DisclosureTypeId = Convert.ToString(item.FILING_CAT_ID);
                if (item.FILING_CAT_ID == 18)
                {
                    objDisclosureTypesEntity.DisclosureTypeDesc = item.FILING_CAT_DESC + " - " + item.FILING_CAT_SUBTYPE;
                    objDisclosureTypesEntity.DisclosureSubTypeDesc = item.FILING_CAT_SUBTYPE;
                }
                else if (item.FILING_CAT_ID == 19)
                {
                    objDisclosureTypesEntity.DisclosureTypeDesc = item.FILING_CAT_DESC + " - " + item.FILING_CAT_SUBTYPE;
                    objDisclosureTypesEntity.DisclosureSubTypeDesc = item.FILING_CAT_SUBTYPE;
                }
                else if (item.FILING_CAT_ID == 20)
                {
                    objDisclosureTypesEntity.DisclosureTypeDesc = item.FILING_CAT_DESC + " - " + item.FILING_CAT_SUBTYPE;
                    objDisclosureTypesEntity.DisclosureSubTypeDesc = item.FILING_CAT_SUBTYPE;
                }
                else if (item.FILING_CAT_ID == 21)
                {
                    objDisclosureTypesEntity.DisclosureTypeDesc = item.FILING_CAT_DESC + " - " + item.FILING_CAT_SUBTYPE;
                    objDisclosureTypesEntity.DisclosureSubTypeDesc = item.FILING_CAT_SUBTYPE;
                }
                else if (item.FILING_CAT_ID == 22)
                {
                    objDisclosureTypesEntity.DisclosureTypeDesc = item.FILING_CAT_DESC + " - " + item.FILING_CAT_SUBTYPE;
                    objDisclosureTypesEntity.DisclosureSubTypeDesc = item.FILING_CAT_SUBTYPE;
                }
                else if (item.FILING_CAT_ID == 23)
                {
                    objDisclosureTypesEntity.DisclosureTypeDesc = item.FILING_CAT_DESC + " - " + item.FILING_CAT_SUBTYPE;
                    objDisclosureTypesEntity.DisclosureSubTypeDesc = item.FILING_CAT_SUBTYPE;
                }
                else
                {
                    objDisclosureTypesEntity.DisclosureTypeDesc = item.FILING_CAT_DESC;
                    objDisclosureTypesEntity.DisclosureSubTypeDesc = item.FILING_CAT_SUBTYPE;
                }                
                lstDisclosureTypesEntity.Add(objDisclosureTypesEntity);
            }

            return lstDisclosureTypesEntity;
        }

        /// <summary>
        /// AddFilingTransactionsData
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean AddFlngTransContrInKindData(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var returnValue = entities.SP_I_FlngTransContrInKindData(objFilingTransactionsEntity.FilerId,
                        objFilingTransactionsEntity.FilingSchedId,
                        objFilingTransactionsEntity.ContributorTypeId,
                        objFilingTransactionsEntity.ContributionTypeId,
                        objFilingTransactionsEntity.PaymentTypeId,
                        objFilingTransactionsEntity.SchedDate,
                        objFilingTransactionsEntity.PayNumber,
                        objFilingTransactionsEntity.OrgAmt,
                        objFilingTransactionsEntity.TransExplanation,
                        objFilingTransactionsEntity.ElectionDate,
                        objFilingTransactionsEntity.ElectionTypeId,
                        objFilingTransactionsEntity.OfficeTypeId,
                        objFilingTransactionsEntity.FilingTypeId,
                        objFilingTransactionsEntity.ElectYearId,
                        objFilingTransactionsEntity.ElectionYear,
                        objFilingTransactionsEntity.FilingEntId,
                        objFilingTransactionsEntity.FlngEntName,
                        objFilingTransactionsEntity.FlngEntFirstName,
                        objFilingTransactionsEntity.FlngEntLastName,
                        objFilingTransactionsEntity.FlngEntMiddleName,
                        objFilingTransactionsEntity.FlngEntCountry,
                        objFilingTransactionsEntity.FlngEntStrName,
                        objFilingTransactionsEntity.FlngEntCity,
                        objFilingTransactionsEntity.FlngEntState,
                        objFilingTransactionsEntity.FlngEntZip,
                        objFilingTransactionsEntity.RItemized,
                        objFilingTransactionsEntity.ElectionDateId,
                        objFilingTransactionsEntity.CreatedBy,
                        objFilingTransactionsEntity.ResigTermTypeId,
                        objFilingTransactionsEntity.FilingDate);


            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        public IList<OfficeTypeEntity> GetOfficeType()
        {
            IList<OfficeTypeEntity> lstOfficeTypeEntity = new List<OfficeTypeEntity>();
            OfficeTypeEntity objOfficeTypeEntity;

            var results = entities.SP_S_OfficeTypeAll();

            foreach (var item in results)
            {
                objOfficeTypeEntity = new OfficeTypeEntity();
                objOfficeTypeEntity.OfficeTypeId = Convert.ToString(item.OFFICE_TYPE_ID);
                if (item.OFFICE_TYPE_DESC == "County")
                    objOfficeTypeEntity.OfficeTypeDesc = "Local";
                else
                    objOfficeTypeEntity.OfficeTypeDesc = item.OFFICE_TYPE_DESC;
                lstOfficeTypeEntity.Add(objOfficeTypeEntity);
            }

            return lstOfficeTypeEntity;
        }       

        public IList<CountyEntity> GetCounty()
        {
            IList<CountyEntity> lstCountyEntity = new List<CountyEntity>();
            CountyEntity objCountyEntity;

            var results = entities.SP_S_CountyAll();

            foreach (var item in results)
            {
                objCountyEntity = new CountyEntity();
                objCountyEntity.CountyId = Convert.ToString(item.COUNTY_ID);
                objCountyEntity.CountyDesc = item.CNTY_BOARD;
                lstCountyEntity.Add(objCountyEntity);
            }

            return lstCountyEntity;
        }

        public IList<MunicipalityEntity> GetMunicipality(String strCountyId)
        {
            IList<MunicipalityEntity> lstMunicipalityEntity = new List<MunicipalityEntity>();
            MunicipalityEntity objMunicipalityEntity;

            Int32 intCountyId;
            if (strCountyId != "")
                intCountyId = Convert.ToInt32(strCountyId);
            else
                intCountyId = 0;
            var results = entities.SP_S_Muncipality(intCountyId);

            foreach (var item in results)
            {
                objMunicipalityEntity = new MunicipalityEntity();
                objMunicipalityEntity.MunicipalityId = Convert.ToString(item.MUNICIPALITY_ID);
                objMunicipalityEntity.MunicipalityDesc = item.MUNICIPALITY_DESC;
                lstMunicipalityEntity.Add(objMunicipalityEntity);
            }

            return lstMunicipalityEntity;
        }

        /// <summary>
        /// GetAutoCompleteNameAddress
        /// </summary>
        /// <param name="name"></param>
        /// <param name="strFilerId"></param>
        /// <returns></returns>
        public IList<AutoCompFLNameAddressEntity> GetAutoCompleteNameAddress(String name, String strFilerId, String strFLName)
        {
            IList<AutoCompFLNameAddressEntity> lstAutoCompFLNameAddressEntity = new List<AutoCompFLNameAddressEntity>();
            AutoCompFLNameAddressEntity objAutoCompFLNameAddressEntity;

            var results = (dynamic)null;

            if (strFLName == "FName")
                results = entities.SP_S_AutoCompleteFirstNameAndAddr(name, strFilerId);
            else if (strFLName == "LName")
                results = entities.SP_S_AutoCompleteLastNameAndAddr(name, strFilerId);
            else if (strFLName == "EName")
                results = entities.SP_S_AutoCompleteEntityNameAndAddr(name, strFilerId);

            if (strFLName == "EName")
            {
                foreach (var item in results)
                {
                    objAutoCompFLNameAddressEntity = new AutoCompFLNameAddressEntity();
                    objAutoCompFLNameAddressEntity.FilingEntityId = Convert.ToString(item.FLNG_ENT_ID);
                    objAutoCompFLNameAddressEntity.FilingEntityName = item.FLNG_ENT_NAME;
                    objAutoCompFLNameAddressEntity.FilingEntityStreetNum = item.FLNG_ENT_STR_NUM;
                    objAutoCompFLNameAddressEntity.FilingEntityStreetName = item.FLNG_ENT_STR_NAME;
                    objAutoCompFLNameAddressEntity.FilingEntityCity = item.FLNG_ENT_CITY;
                    objAutoCompFLNameAddressEntity.FilingEntityState = item.FLNG_ENT_STATE;
                    objAutoCompFLNameAddressEntity.FilingEntityZip = item.FLNG_ENT_ZIP;
                    objAutoCompFLNameAddressEntity.FilingEntityCountry = item.FLNG_ENT_COUNTRY;
                    objAutoCompFLNameAddressEntity.FilingEntityNameAndAddress = item.FILING_ENTITY_NAME_ADDRESS;
                    lstAutoCompFLNameAddressEntity.Add(objAutoCompFLNameAddressEntity);
                }
            }
            else
            {
                foreach (var item in results)
                {
                    objAutoCompFLNameAddressEntity = new AutoCompFLNameAddressEntity();
                    objAutoCompFLNameAddressEntity.FilingEntityId = Convert.ToString(item.FLNG_ENT_ID);
                    objAutoCompFLNameAddressEntity.FilingEntityFirstName = item.FLNG_ENT_FIRST_NAME;
                    objAutoCompFLNameAddressEntity.FilingEntityMiddleName = item.FLNG_ENT_MIDDLE_NAME;
                    objAutoCompFLNameAddressEntity.FilingEntityLastName = item.FLNG_ENT_LAST_NAME;
                    objAutoCompFLNameAddressEntity.FilingEntityStreetNum = item.FLNG_ENT_STR_NUM;
                    objAutoCompFLNameAddressEntity.FilingEntityStreetName = item.FLNG_ENT_STR_NAME;
                    objAutoCompFLNameAddressEntity.FilingEntityCity = item.FLNG_ENT_CITY;
                    objAutoCompFLNameAddressEntity.FilingEntityState = item.FLNG_ENT_STATE;
                    objAutoCompFLNameAddressEntity.FilingEntityZip = item.FLNG_ENT_ZIP;
                    objAutoCompFLNameAddressEntity.FilingEntityCountry = item.FLNG_ENT_COUNTRY;
                    objAutoCompFLNameAddressEntity.FilingEntityNameAndAddress = item.FILING_ENTITY_NAME_ADDRESS;
                    lstAutoCompFLNameAddressEntity.Add(objAutoCompFLNameAddressEntity);
                }
            }

            return lstAutoCompFLNameAddressEntity;
        }

        /// <summary>
        /// DeleteFilingTransactionsData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        public Boolean DeleteFilingTransactionsData(String strTransNumber, String strModifiedBy)
        {
            var returnValue = entities.SP_D_FilingTransactionsData(strTransNumber, strModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// DeleteFlngTransExpPaySchedFNData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        public Boolean DeleteFlngTransExpPaySchedFNData(String strLoanLiabNumberOrg, String strTransNumberOrg, String strRLiability, String strModifiedBy)
        {
            var returnValue = entities.SP_D_FlngTransExpPaymentsSchedFNData(strLoanLiabNumberOrg, strTransNumberOrg, strRLiability, strModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// UpdateFilingTransactionsData
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean UpdateFilingTransContrInKindData(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var returnValue = entities.SP_U_Filing_TransContrInKindData(objFilingTransactionsEntity.FilingTransId,
                objFilingTransactionsEntity.FilingEntId,
                objFilingTransactionsEntity.ContributionTypeId,
                objFilingTransactionsEntity.SchedDate,
                objFilingTransactionsEntity.PayNumber,
                objFilingTransactionsEntity.PaymentTypeId,
                objFilingTransactionsEntity.OrgAmt,
                objFilingTransactionsEntity.TransExplanation,
                objFilingTransactionsEntity.FlngEntName,
                objFilingTransactionsEntity.FlngEntFirstName,
                objFilingTransactionsEntity.FlngEntMiddleName,
                objFilingTransactionsEntity.FlngEntLastName,
                objFilingTransactionsEntity.FlngEntCountry,
                objFilingTransactionsEntity.FlngEntStrName,
                objFilingTransactionsEntity.FlngEntCity,
                objFilingTransactionsEntity.FlngEntState,
                objFilingTransactionsEntity.FlngEntZip,
                objFilingTransactionsEntity.ModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Viewable Column
        /// </summary>
        /// <param name="strUniqueID"></param>
        /// <param name="strApplicationName"></param>
        /// <param name="strPageName"></param>
        /// <returns></returns>
        public IList<ViewableColumnEntity> GetViewableColumns(String strUniqueID, String strApplicationName, String strPageName)
        {
            IList<ViewableColumnEntity> lstViewableColumnEntity = new List<ViewableColumnEntity>();
            ViewableColumnEntity objViewableColumnEntity;
            var results = entities.SP_S_ViewableColumn(strUniqueID, strApplicationName, strPageName);
            foreach (var item in results)
            {
                objViewableColumnEntity = new ViewableColumnEntity();
                objViewableColumnEntity.ViewableFieldID = item.Viewable_Field_ID.ToString();
                objViewableColumnEntity.UniqueID = item.Unique_ID;
                objViewableColumnEntity.ColumnName = item.Column_Name;
                objViewableColumnEntity.Viewable = item.Viewable;
                lstViewableColumnEntity.Add(objViewableColumnEntity);
            }
            return lstViewableColumnEntity;
        }

        public IList<ContributorNameEntity> GetPartnerSubContractorData()
        {
            IList<ContributorNameEntity> lstContributorNameEntity = new List<ContributorNameEntity>();
            ContributorNameEntity objContributorNameEntity;

            var results = entities.SP_S_ContributorTypesPartnerSubContractor();

            foreach (var item in results)
            {
                objContributorNameEntity = new ContributorNameEntity();
                objContributorNameEntity.ContributorTypeId = Convert.ToString(item.CNTRBR_TYPE_ID);
                objContributorNameEntity.ContributorTypeDesc = item.CNTRBR_TYPE_DESC;
                objContributorNameEntity.ContributorTypeAbbrev = item.CNTRBR_TYPE_ABBREV;
                lstContributorNameEntity.Add(objContributorNameEntity);
            }

            return lstContributorNameEntity;
        }




        public Boolean UpdateColumnValue(String uniqueID, String applicationName, String pageName, String uniqueValue, String modifyBy)
        {
            var result = entities.SP_U_ColumnField(uniqueID,
                                         applicationName,
                                         pageName,
                                         uniqueValue,
                                         modifyBy);

            return true;
        }        

        /// <summary>
        /// AddContrInKindPartnersData
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean AddContrInKindPartnersData(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var returnValue = entities.SP_I_FlngTransContrInKindPartnersData(objFilingTransactionsEntity.FilerId,
                objFilingTransactionsEntity.TransNumber,
                objFilingTransactionsEntity.FilingSchedId,
                objFilingTransactionsEntity.SchedDate,
                objFilingTransactionsEntity.OrgAmt,
                objFilingTransactionsEntity.FilingEntId,
                objFilingTransactionsEntity.FlngEntName,
                objFilingTransactionsEntity.FlngEntFirstName,
                objFilingTransactionsEntity.FlngEntLastName,
                objFilingTransactionsEntity.FlngEntMiddleName,
                objFilingTransactionsEntity.FlngEntStrName,
                objFilingTransactionsEntity.FlngEntCity,
                objFilingTransactionsEntity.FlngEntState,
                objFilingTransactionsEntity.FlngEntZip,
                objFilingTransactionsEntity.FlngEntCountry,
                objFilingTransactionsEntity.TransExplanation,
                objFilingTransactionsEntity.RItemized,
                objFilingTransactionsEntity.CreatedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// GetContrInKindPartnersData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<ContrInKindPartnersEntity> GetContrInKindPartnersData(String strFilingTransId)
        {
            IList<ContrInKindPartnersEntity> lstContrInKindPartnersEntity = new List<ContrInKindPartnersEntity>();
            ContrInKindPartnersEntity objContrInKindPartnersEntity;

            var results = entities.SP_S_ContrInKindPartnersData(strFilingTransId);

            foreach (var item in results)
            {
                objContrInKindPartnersEntity = new ContrInKindPartnersEntity();
                objContrInKindPartnersEntity.FilingTransId = Convert.ToString(item.FILING_TRANS_ID);
                objContrInKindPartnersEntity.FilingEntityId = Convert.ToString(item.FLNG_ENT_ID);
                objContrInKindPartnersEntity.PartnershipName = item.FLNG_ENT_NAME;
                objContrInKindPartnersEntity.PartnerFirstName = item.FLNG_ENT_FIRST_NAME;
                objContrInKindPartnersEntity.PartnerMiddleName = item.FLNG_ENT_MIDDLE_NAME;
                objContrInKindPartnersEntity.PartnerLastName = item.FLNG_ENT_LAST_NAME;
                objContrInKindPartnersEntity.PartnerStreetNo = item.FLNG_ENT_STR_NUM;
                objContrInKindPartnersEntity.PartnerStreetName = item.LNG_ENT_STR_NAME;
                objContrInKindPartnersEntity.PartnerCity = item.FLNG_ENT_CITY;
                objContrInKindPartnersEntity.PartnerState = item.FLNG_ENT_STATE;
                objContrInKindPartnersEntity.PartnerZip5 = item.FLNG_ENT_ZIP;
                objContrInKindPartnersEntity.PartnershipCountry = item.FLNG_ENT_COUNTRY;
                objContrInKindPartnersEntity.PartnerAmountAttributed = String.Format("{0:0.00}", item.ORG_AMT);
                objContrInKindPartnersEntity.PartnerExplanation = item.TRANS_EXPLNTN;
                if (item.R_ITEMIZED == "" || item.R_ITEMIZED == null)
                    objContrInKindPartnersEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "Y")
                    objContrInKindPartnersEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "N")
                    objContrInKindPartnersEntity.RItemized = "No";
                objContrInKindPartnersEntity.TransNumber = item.TRANS_NUMBER;
                objContrInKindPartnersEntity.TransMapping = item.TRANS_MAPPING;
                lstContrInKindPartnersEntity.Add(objContrInKindPartnersEntity);
            }

            return lstContrInKindPartnersEntity;
        }

        /// <summary>
        /// DeleteContrInKindPartnersData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strFilingTransMapping"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        public Boolean DeleteContrInKindPartnersData(String strTransNumber, String strModifiedBy)
        {
            var returnValue = entities.SP_D_ContrInKindPartnersData(strTransNumber, strModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// UpdateContrInKindPartnersData
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean UpdateContrInKindPartnersData(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var returnValue = entities.SP_U_ContrInKindPartnersData(objFilingTransactionsEntity.TransNumber,
                objFilingTransactionsEntity.FilingEntId, objFilingTransactionsEntity.FlngEntName,
                objFilingTransactionsEntity.FlngEntFirstName, objFilingTransactionsEntity.FlngEntMiddleName,
                objFilingTransactionsEntity.FlngEntLastName, objFilingTransactionsEntity.FlngEntStrName,
                 objFilingTransactionsEntity.FlngEntCity, objFilingTransactionsEntity.FlngEntState,
                 objFilingTransactionsEntity.FlngEntZip, objFilingTransactionsEntity.FlngEntCountry,
                 objFilingTransactionsEntity.OrgAmt, objFilingTransactionsEntity.TransExplanation,
                 objFilingTransactionsEntity.ModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Add Transfer In scheudled data
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean AddFilingTransaction_TransferIn(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var result = entities.SP_I_FilingTransaction_TransferIn(objFilingTransactionsEntity.FilerId,
                                                                        objFilingTransactionsEntity.FilingSchedId,
                                                                        objFilingTransactionsEntity.TransferTypeId,
                                                                        objFilingTransactionsEntity.SchedDate,
                                                                        objFilingTransactionsEntity.PayNumber,
                                                                        objFilingTransactionsEntity.OrgAmt,
                                                                        objFilingTransactionsEntity.TransExplanation,
                                                                        objFilingTransactionsEntity.ElectionTypeId,
                                                                        objFilingTransactionsEntity.OfficeTypeId,
                                                                        objFilingTransactionsEntity.FilingTypeId,
                                                                        objFilingTransactionsEntity.ElectYearId,
                                                                        objFilingTransactionsEntity.FilingEntId,
                                                                        objFilingTransactionsEntity.FlngEntName,
                                                                        objFilingTransactionsEntity.FlngEntStrName,
                                                                        objFilingTransactionsEntity.FlngEntCity,
                                                                        objFilingTransactionsEntity.FlngEntState,
                                                                        objFilingTransactionsEntity.FlngEntZip,
                                                                        objFilingTransactionsEntity.FlngEntZip4,
                                                                        objFilingTransactionsEntity.FlngEntCountry,
                                                                        objFilingTransactionsEntity.CreatedBy,
                                                                        objFilingTransactionsEntity.PaymentTypeId,
                                                                        objFilingTransactionsEntity.FilingDate,
                                                                        objFilingTransactionsEntity.ElectionDateId,
                                                                        objFilingTransactionsEntity.ResigTermTypeId);

            if (result >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Update Filing Transaction
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean UpdateFilingTransaction_TransferIn(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var result = entities.SP_U_FilingTransaction_TransferIn(objFilingTransactionsEntity.TransferTypeId,
                                                                        objFilingTransactionsEntity.SchedDate,
                                                                        objFilingTransactionsEntity.PayNumber,
                                                                        objFilingTransactionsEntity.OrgAmt,
                                                                        objFilingTransactionsEntity.TransExplanation,
                                                                        objFilingTransactionsEntity.FilingEntId,
                                                                        objFilingTransactionsEntity.FlngEntName,
                                                                        objFilingTransactionsEntity.FlngEntStrName,
                                                                        objFilingTransactionsEntity.FlngEntCity,
                                                                        objFilingTransactionsEntity.FlngEntState,
                                                                        objFilingTransactionsEntity.FlngEntZip,
                                                                        objFilingTransactionsEntity.FlngEntZip4,
                                                                        objFilingTransactionsEntity.FlngEntCountry,
                                                                        objFilingTransactionsEntity.CreatedBy,
                                                                        objFilingTransactionsEntity.TransNumber,
                                                                        objFilingTransactionsEntity.PaymentTypeId,
                                                                        objFilingTransactionsEntity.OfficeTypeId,
                                                                        objFilingTransactionsEntity.FilingTypeId,
                                                                        objFilingTransactionsEntity.ElectYearId,
                                                                        objFilingTransactionsEntity.FilerId);

            if (result >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// AddFilingTransaction_NonCompHKReceipts
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean AddFilingTransaction_NonCompHKReceipts(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var results = entities.SP_I_FlngTransNonCompHKReceipts(objFilingTransactionsEntity.FilerId,
                objFilingTransactionsEntity.FilingSchedId,
                objFilingTransactionsEntity.SchedDate,
                objFilingTransactionsEntity.ReceiptCodeId,
                objFilingTransactionsEntity.PaymentTypeId,
                objFilingTransactionsEntity.PayNumber,
                objFilingTransactionsEntity.OrgAmt,
                objFilingTransactionsEntity.TransExplanation,
                objFilingTransactionsEntity.ElectionDate,
                objFilingTransactionsEntity.ElectionTypeId,
                objFilingTransactionsEntity.OfficeTypeId,
                objFilingTransactionsEntity.FilingTypeId,
                objFilingTransactionsEntity.ElectYearId,
                objFilingTransactionsEntity.ElectionYear,
                objFilingTransactionsEntity.FilingEntId,
                objFilingTransactionsEntity.FlngEntName,
                objFilingTransactionsEntity.FlngEntFirstName,
                objFilingTransactionsEntity.FlngEntLastName,
                objFilingTransactionsEntity.FlngEntMiddleName,
                objFilingTransactionsEntity.FlngEntCountry,
                objFilingTransactionsEntity.FlngEntStrName,
                objFilingTransactionsEntity.FlngEntCity,
                objFilingTransactionsEntity.FlngEntState,
                objFilingTransactionsEntity.FlngEntZip,
                objFilingTransactionsEntity.RItemized,
                objFilingTransactionsEntity.CreatedBy,
                objFilingTransactionsEntity.ElectionDateId,
                objFilingTransactionsEntity.ResigTermTypeId,
                objFilingTransactionsEntity.FilingDate
                );

            if (results >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// UpdateFilingTransNonCompHKReceipts
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean UpdateFilingTransNonCompHKReceipts(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var returnValue = entities.SP_U_FilingTransaction_NonCompHKReceipts(objFilingTransactionsEntity.TransNumber,
                objFilingTransactionsEntity.FilingEntId,
                objFilingTransactionsEntity.ReceiptCodeId,
                objFilingTransactionsEntity.SchedDate,
                objFilingTransactionsEntity.PayNumber,
                objFilingTransactionsEntity.PaymentTypeId,
                objFilingTransactionsEntity.OrgAmt,
                objFilingTransactionsEntity.TransExplanation,
                objFilingTransactionsEntity.FlngEntName,
                objFilingTransactionsEntity.FlngEntFirstName,
                objFilingTransactionsEntity.FlngEntMiddleName,
                objFilingTransactionsEntity.FlngEntLastName,
                objFilingTransactionsEntity.FlngEntCountry,
                objFilingTransactionsEntity.FlngEntStrName,
                objFilingTransactionsEntity.FlngEntCity,
                objFilingTransactionsEntity.FlngEntState,
                objFilingTransactionsEntity.FlngEntZip,
                objFilingTransactionsEntity.ModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// /AddFlngTransContrMonetaryData
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean AddFlngTransContrMonetaryData(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var returnValue = entities.SP_I_FlngTransContrMonetaryData(objFilingTransactionsEntity.FilerId,
                        objFilingTransactionsEntity.FilingSchedId,
                        objFilingTransactionsEntity.ContributorTypeId,
                        objFilingTransactionsEntity.PaymentTypeId,
                        objFilingTransactionsEntity.SchedDate,
                        objFilingTransactionsEntity.PayNumber,
                        objFilingTransactionsEntity.OrgAmt,
                        objFilingTransactionsEntity.TransExplanation,
                        objFilingTransactionsEntity.ElectionDate,
                        objFilingTransactionsEntity.ElectionTypeId,
                        objFilingTransactionsEntity.OfficeTypeId,
                        objFilingTransactionsEntity.FilingTypeId,
                        objFilingTransactionsEntity.ElectYearId,
                        objFilingTransactionsEntity.ElectionYear,
                        objFilingTransactionsEntity.FilingEntId,
                        objFilingTransactionsEntity.FlngEntName,
                        objFilingTransactionsEntity.FlngEntFirstName,
                        objFilingTransactionsEntity.FlngEntLastName,
                        objFilingTransactionsEntity.FlngEntMiddleName,
                        objFilingTransactionsEntity.FlngEntStrName,
                        objFilingTransactionsEntity.FlngEntCity,
                        objFilingTransactionsEntity.FlngEntState,
                        objFilingTransactionsEntity.FlngEntZip,
                        objFilingTransactionsEntity.RItemized,
                        objFilingTransactionsEntity.FlngEntCountry,
                        objFilingTransactionsEntity.ElectionDateId,
                        objFilingTransactionsEntity.CreatedBy,
                        objFilingTransactionsEntity.ResigTermTypeId,
                        objFilingTransactionsEntity.FilingDate);


            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        #region UpdateFlngTransMonetaryContrData
        /// <summary>
        /// UpdateFlngTransMonetaryContrData
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean UpdateFlngTransMonetaryContrData(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var returnValue = entities.SP_U_Flng_TransMonetaryContrData(objFilingTransactionsEntity.TransNumber,
                    objFilingTransactionsEntity.FilingEntId,
                    objFilingTransactionsEntity.ContributorTypeId,
                    objFilingTransactionsEntity.SchedDate,
                    objFilingTransactionsEntity.PayNumber,
                    objFilingTransactionsEntity.PaymentTypeId,
                    objFilingTransactionsEntity.OrgAmt,
                    objFilingTransactionsEntity.TransExplanation,
                    objFilingTransactionsEntity.FlngEntName,
                    objFilingTransactionsEntity.FlngEntFirstName,
                    objFilingTransactionsEntity.FlngEntMiddleName,
                    objFilingTransactionsEntity.FlngEntLastName,
                    objFilingTransactionsEntity.FlngEntStrName,
                    objFilingTransactionsEntity.FlngEntCity,
                    objFilingTransactionsEntity.FlngEntState,
                    objFilingTransactionsEntity.FlngEntZip,
                    objFilingTransactionsEntity.FlngEntCountry,
                    objFilingTransactionsEntity.ModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }
        #endregion UpdateFlngTransMonetaryContrData

        /// <summary>
        /// AddFlngTransExpenditureData
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public String AddFlngTransExpenditureData(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            //var returnValue = entities.SP_I_FlngTransExpLiabSchedFN(objFilingTransactionsEntity.FilerId,
            //            objFilingTransactionsEntity.FilingTransId,
            //            objFilingTransactionsEntity.FilingSchedId,
            //            objFilingTransactionsEntity.SchedDate,
            //            objFilingTransactionsEntity.PurposeCodeId,
            //            objFilingTransactionsEntity.PaymentTypeId,
            //            objFilingTransactionsEntity.PayNumber,
            //            objFilingTransactionsEntity.OrgDate,
            //            objFilingTransactionsEntity.OrgAmt,
            //            objFilingTransactionsEntity.LiabilityOrgAmt,
            //            objFilingTransactionsEntity.LiabilityOwedAmt,
            //            objFilingTransactionsEntity.RLiability,
            //            objFilingTransactionsEntity.RSubcontractor,
            //            objFilingTransactionsEntity.RItemized,
            //            objFilingTransactionsEntity.TransExplanation,
            //            objFilingTransactionsEntity.LiabilityTransExplanation,
            //            objFilingTransactionsEntity.ElectionDate,
            //            objFilingTransactionsEntity.ElectionTypeId,
            //            objFilingTransactionsEntity.OfficeTypeId,
            //            objFilingTransactionsEntity.FilingTypeId,
            //            objFilingTransactionsEntity.ElectYearId,
            //            objFilingTransactionsEntity.ElectionYear,
            //            objFilingTransactionsEntity.FilingEntId,
            //            objFilingTransactionsEntity.FlngEntName,
            //            objFilingTransactionsEntity.FlngEntStrName,
            //            objFilingTransactionsEntity.FlngEntCity,
            //            objFilingTransactionsEntity.FlngEntState,
            //            objFilingTransactionsEntity.FlngEntZip,
            //            objFilingTransactionsEntity.CreatedBy);

            ObjectParameter objReturnValue = new ObjectParameter("RETURN_IDENTITY", typeof(int));
            String strReturnValue = String.Empty;
            var returnValue = entities.SP_I_FlngTransExpenditurePaymentsSchedFN(objFilingTransactionsEntity.FilerId,
                        objFilingTransactionsEntity.TransNumber,
                        objFilingTransactionsEntity.TransNumberOrg,
                        objFilingTransactionsEntity.FilingSchedId,
                        objFilingTransactionsEntity.SchedDate,
                        objFilingTransactionsEntity.PurposeCodeId,
                        objFilingTransactionsEntity.PaymentTypeId,
                        objFilingTransactionsEntity.PayNumber,
                        objFilingTransactionsEntity.OrgDate,
                        objFilingTransactionsEntity.OrgAmt,
                        objFilingTransactionsEntity.LiabilityOrgAmt,
                        objFilingTransactionsEntity.LiabilityPartialAmt,
                        objFilingTransactionsEntity.LiabilityOwedAmt,
                        objFilingTransactionsEntity.RLiability,
                        objFilingTransactionsEntity.RSubcontractor,
                        objFilingTransactionsEntity.RItemized,
                        objFilingTransactionsEntity.RLiabilityExists,
                        objFilingTransactionsEntity.TransExplanation,
                        objFilingTransactionsEntity.LiabilityTransExplanation,
                        objFilingTransactionsEntity.ElectionDate,
                        objFilingTransactionsEntity.ElectionTypeId,
                        objFilingTransactionsEntity.OfficeTypeId,
                        objFilingTransactionsEntity.FilingTypeId,
                        objFilingTransactionsEntity.ElectYearId,
                        objFilingTransactionsEntity.ElectionYear,
                        objFilingTransactionsEntity.FilingEntId,
                        objFilingTransactionsEntity.FlngEntName,
                        objFilingTransactionsEntity.FlngEntCountry,
                        objFilingTransactionsEntity.FlngEntStrName,
                        objFilingTransactionsEntity.FlngEntCity,
                        objFilingTransactionsEntity.FlngEntState,
                        objFilingTransactionsEntity.FlngEntZip,
                        objFilingTransactionsEntity.CreatedBy,
                        objFilingTransactionsEntity.ElectionDateId,
                        objFilingTransactionsEntity.ResigTermTypeId,
                        objFilingTransactionsEntity.FilingDate, objReturnValue);

            strReturnValue = Convert.ToString(objReturnValue.Value);

            return strReturnValue;

            //if (returnValue >= 1)
            //    return true;
            //else
            //    return false;            
        }

        /// <summary>
        /// Add Transfer Out scheudled data
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean AddFilingTransaction_TransferOut(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var result = entities.SP_I_FilingTransaction_TransferOut(objFilingTransactionsEntity.FilerId,
                                                                        objFilingTransactionsEntity.FilingSchedId,
                                                                        objFilingTransactionsEntity.TransferTypeId,
                                                                        objFilingTransactionsEntity.SchedDate,
                                                                        objFilingTransactionsEntity.PayNumber,
                                                                        objFilingTransactionsEntity.OrgAmt,
                                                                        objFilingTransactionsEntity.TransExplanation,
                                                                        objFilingTransactionsEntity.ElectionTypeId,
                                                                        objFilingTransactionsEntity.OfficeTypeId,
                                                                        objFilingTransactionsEntity.FilingTypeId,
                                                                        objFilingTransactionsEntity.ElectYearId,
                                                                        objFilingTransactionsEntity.FilingEntId,
                                                                        objFilingTransactionsEntity.FlngEntName,
                                                                        objFilingTransactionsEntity.FlngEntStrName,
                                                                        objFilingTransactionsEntity.FlngEntCity,
                                                                        objFilingTransactionsEntity.FlngEntState,
                                                                        objFilingTransactionsEntity.FlngEntZip,
                                                                        objFilingTransactionsEntity.FlngEntZip4,
                                                                        objFilingTransactionsEntity.FlngEntCountry,
                                                                        objFilingTransactionsEntity.CreatedBy,
                                                                        objFilingTransactionsEntity.PaymentTypeId,
                                                                        objFilingTransactionsEntity.FilingDate,
                                                                        objFilingTransactionsEntity.ElectionDateId,
                                                                        objFilingTransactionsEntity.ResigTermTypeId);

            if (result >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Update Filing Transaction
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean UpdateFilingTransaction_TransferOut(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var result = entities.SP_U_FilingTransaction_TransferOut(objFilingTransactionsEntity.TransferTypeId,
                                                                        objFilingTransactionsEntity.SchedDate,
                                                                        objFilingTransactionsEntity.PayNumber,
                                                                        objFilingTransactionsEntity.OrgAmt,
                                                                        objFilingTransactionsEntity.TransExplanation,
                                                                        objFilingTransactionsEntity.FilingEntId,
                                                                        objFilingTransactionsEntity.FlngEntName,
                                                                        objFilingTransactionsEntity.FlngEntStrName,
                                                                        objFilingTransactionsEntity.FlngEntCity,
                                                                        objFilingTransactionsEntity.FlngEntState,
                                                                        objFilingTransactionsEntity.FlngEntZip,
                                                                        objFilingTransactionsEntity.FlngEntZip4,
                                                                        objFilingTransactionsEntity.FlngEntCountry,
                                                                        objFilingTransactionsEntity.CreatedBy,
                                                                        objFilingTransactionsEntity.TransNumber,
                                                                        objFilingTransactionsEntity.PaymentTypeId);

            if (result >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Add Loan Received scheudled data
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean AddFilingTransaction_LoanReceived(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var result = entities.SP_I_FilingTransaction_LoanReceived(objFilingTransactionsEntity.FilerId,
                                                                        objFilingTransactionsEntity.FilingSchedId,
                                                                        objFilingTransactionsEntity.OtherFilingSchedId,
                                                                        objFilingTransactionsEntity.TransferTypeId,
                                                                        objFilingTransactionsEntity.SchedDate,
                                                                        objFilingTransactionsEntity.PayNumber,
                                                                        objFilingTransactionsEntity.OrgAmt,
                                                                        objFilingTransactionsEntity.TransExplanation,
                                                                        objFilingTransactionsEntity.OtherTransExplanation,
                                                                        objFilingTransactionsEntity.ElectionTypeId,
                                                                        objFilingTransactionsEntity.OfficeTypeId,
                                                                        objFilingTransactionsEntity.FilingTypeId,
                                                                        objFilingTransactionsEntity.ElectYearId,
                                                                        objFilingTransactionsEntity.FilingEntId,
                                                                        objFilingTransactionsEntity.FlngEntName,
                                                                        objFilingTransactionsEntity.FlngEntFirstName,
                                                                        objFilingTransactionsEntity.FlngEntMiddleName,
                                                                        objFilingTransactionsEntity.FlngEntLastName,
                                                                        objFilingTransactionsEntity.FlngEntStrName,
                                                                        objFilingTransactionsEntity.FlngEntCity,
                                                                        objFilingTransactionsEntity.FlngEntState,
                                                                        objFilingTransactionsEntity.FlngEntZip,
                                                                        objFilingTransactionsEntity.FlngEntZip4,
                                                                        objFilingTransactionsEntity.FlngEntCountry,
                                                                        objFilingTransactionsEntity.CreatedBy,
                                                                        objFilingTransactionsEntity.PaymentTypeId,
                                                                        objFilingTransactionsEntity.LoanOtherId,
                                                                        objFilingTransactionsEntity.FilingDate,
                                                                        objFilingTransactionsEntity.ElectionDateId,
                                                                        objFilingTransactionsEntity.ResigTermTypeId);


            if (result >= 1)
                return true;
            else
                return false;
        }

        public Boolean AddFilingTransaction_LoanRepayment(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var result = entities.SP_I_FilingTransaction_LoanRepayment(objFilingTransactionsEntity.FilerId,
                                                                        objFilingTransactionsEntity.FilingSchedId,
                                                                        objFilingTransactionsEntity.OtherFilingSchedId,
                                                                        objFilingTransactionsEntity.TransferTypeId,
                                                                        objFilingTransactionsEntity.SchedDate,
                                                                        objFilingTransactionsEntity.PayNumber,
                                                                        objFilingTransactionsEntity.OrgAmt,
                                                                        objFilingTransactionsEntity.TransExplanation,
                                                                        objFilingTransactionsEntity.OtherTransExplanation,
                                                                        objFilingTransactionsEntity.ElectionTypeId,
                                                                        objFilingTransactionsEntity.OfficeTypeId,
                                                                        objFilingTransactionsEntity.FilingTypeId,
                                                                        objFilingTransactionsEntity.ElectYearId,
                                                                        objFilingTransactionsEntity.FilingEntId,
                                                                        objFilingTransactionsEntity.FlngEntName,
                                                                        objFilingTransactionsEntity.FlngEntFirstName,
                                                                        objFilingTransactionsEntity.FlngEntMiddleName,
                                                                        objFilingTransactionsEntity.FlngEntLastName,
                                                                        objFilingTransactionsEntity.FlngEntStrName,
                                                                        objFilingTransactionsEntity.FlngEntCity,
                                                                        objFilingTransactionsEntity.FlngEntState,
                                                                        objFilingTransactionsEntity.FlngEntZip,
                                                                        objFilingTransactionsEntity.FlngEntCountry,
                                                                        objFilingTransactionsEntity.CreatedBy,
                                                                        objFilingTransactionsEntity.PaymentTypeId,
                                                                        objFilingTransactionsEntity.LoanOtherId,
                                                                        objFilingTransactionsEntity.OtherAmount,
                                                                        objFilingTransactionsEntity.FilingDate,
                                                                        objFilingTransactionsEntity.ElectionDateId,
                                                                        objFilingTransactionsEntity.ResigTermTypeId,
                                                                        objFilingTransactionsEntity.Loan_Lib_Number,
                                                                        objFilingTransactionsEntity.TransNumber);

            if (result >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Update Filing Transaction
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean UpdateFilingTransaction_LoanReceived(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var result = entities.SP_U_FilingTransaction_LoanReceived(objFilingTransactionsEntity.TransferTypeId,
                                                                        objFilingTransactionsEntity.PayNumber,
                                                                        objFilingTransactionsEntity.OrgAmt,
                                                                        objFilingTransactionsEntity.TransExplanation,
                                                                        objFilingTransactionsEntity.OtherTransExplanation,
                                                                        objFilingTransactionsEntity.FilingEntId,
                                                                        objFilingTransactionsEntity.FlngEntName,
                                                                        objFilingTransactionsEntity.FlngEntFirstName,
                                                                        objFilingTransactionsEntity.FlngEntMiddleName,
                                                                        objFilingTransactionsEntity.FlngEntLastName,
                                                                        objFilingTransactionsEntity.FlngEntStrName,
                                                                        objFilingTransactionsEntity.FlngEntCity,
                                                                        objFilingTransactionsEntity.FlngEntState,
                                                                        objFilingTransactionsEntity.FlngEntZip,
                                                                        objFilingTransactionsEntity.FlngEntCountry,
                                                                        objFilingTransactionsEntity.ModifiedBy,
                                                                        objFilingTransactionsEntity.PaymentTypeId,
                                                                        objFilingTransactionsEntity.LoanOtherId,
                                                                        objFilingTransactionsEntity.IsAmtChanged,
                                                                        objFilingTransactionsEntity.Loan_Lib_Number,
                                                                        objFilingTransactionsEntity.TransNumber, objFilingTransactionsEntity.SchedDate);

            if (result >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Get Loaner Code
        /// </summary>
        /// <returns></returns>
        public IList<LoanerCodeEntity> GetLoanerCode()
        {
            IList<LoanerCodeEntity> lstLoanerCodeEntity = new List<LoanerCodeEntity>();
            LoanerCodeEntity objLoanerCodeEntity;

            var results = entities.SP_S_LoanerCode();

            foreach (var item in results)
            {
                objLoanerCodeEntity = new LoanerCodeEntity();
                objLoanerCodeEntity.LoanerID = Convert.ToString(item.LOAN_OTHER_ID);
                objLoanerCodeEntity.LoanerDesc = item.LOAN_OTHER_DESC;
                lstLoanerCodeEntity.Add(objLoanerCodeEntity);
            }
            return lstLoanerCodeEntity;
        }

        /// <summary>
        /// GetAutoCompleteCreditorNameLiab
        /// </summary>
        /// <param name="name"></param>
        /// <param name="strFilerId"></param>
        /// <returns></returns>
        public IList<OutstandingLiabilityEntity> GetAutoCompleteCreditorNameLiab(String name, String strFilerId)
        {
            IList<OutstandingLiabilityEntity> lstOutstandingLiabilityEntity = new List<OutstandingLiabilityEntity>();
            OutstandingLiabilityEntity objOutstandingLiabilityEntity;

            var results = entities.SP_S_AutoCompleteEntityNameLiability(name, strFilerId);

            foreach (var item in results)
            {
                objOutstandingLiabilityEntity = new OutstandingLiabilityEntity();
                objOutstandingLiabilityEntity.FilingEntityId = Convert.ToString(item.FLNG_ENT_ID);
                objOutstandingLiabilityEntity.PayeeName = item.FLNG_ENT_NAME;
                objOutstandingLiabilityEntity.FlngEntCountry = item.FLNG_ENT_COUNTRY;
                objOutstandingLiabilityEntity.LiabilityStreetName = item.FLNG_ENT_STR_NAME;
                objOutstandingLiabilityEntity.LiabilityCity = item.FLNG_ENT_CITY;
                objOutstandingLiabilityEntity.LiabilityState = item.FLNG_ENT_STATE;
                objOutstandingLiabilityEntity.LiabilityZipCode = item.FLNG_ENT_ZIP;
                objOutstandingLiabilityEntity.FilingEntityNameAndAddress = item.FILING_ENTITY_NAME_ADDRESS;
                lstOutstandingLiabilityEntity.Add(objOutstandingLiabilityEntity);
            }

            return lstOutstandingLiabilityEntity;
        }

        /// <summary>
        /// GetDateIncurredLiabData
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        public IList<DateIncurredEntity> GetDateIncurredLiabData(String strFilingEntityId)
        {
            IList<DateIncurredEntity> lstDateIncurredEntity = new List<DateIncurredEntity>();
            DateIncurredEntity objDateIncurredEntity;

            var results = entities.SP_S_DateInccuredLiability(strFilingEntityId);

            foreach (var item in results)
            {
                objDateIncurredEntity = new DateIncurredEntity();
                objDateIncurredEntity.DateIncurredId = Convert.ToString(item.TRANS_NUMBER);
                objDateIncurredEntity.DateIncurredValue = item.SCHED_DATE;
                objDateIncurredEntity.AmountLiability = String.Format("{0:0.00}", item.ORG_AMT);
                lstDateIncurredEntity.Add(objDateIncurredEntity);
            }
            return lstDateIncurredEntity;
        }

        /// <summary>
        /// GetDateIncurredLiabData
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        public IList<DateIncurredEntity> GetDateIncurredLiabDataForForgiven(String strFilingEntityId)
        {
            IList<DateIncurredEntity> lstDateIncurredEntity = new List<DateIncurredEntity>();
            DateIncurredEntity objDateIncurredEntity;

            var results = entities.SP_S_DateInccuredLiabilityForForgiven(strFilingEntityId);

            foreach (var item in results)
            {
                objDateIncurredEntity = new DateIncurredEntity();
                objDateIncurredEntity.DateIncurredId = Convert.ToString(item.FILING_TRANS_ID);
                objDateIncurredEntity.DateIncurredValue = item.SCHED_DATE;
                objDateIncurredEntity.AmountLiability = String.Format("{0:0.00}", item.ORG_AMT);
                objDateIncurredEntity.OutstandingAmount = String.Format("{0:0.00}", item.OUTSTANDING_AMT);
                lstDateIncurredEntity.Add(objDateIncurredEntity);
            }
            return lstDateIncurredEntity;
        }

        /// <summary>
        /// GetOriginalAmountLiabData
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        public IList<OriginalAmountEntity> GetOutstandingAmountLiabData(String strFilingEntityId, String strUpdateStatus, String strFilingTransId)
        {
            IList<OriginalAmountEntity> lstOriginalAmountEntity = new List<OriginalAmountEntity>();
            OriginalAmountEntity objOriginalAmountEntity;

            var results = entities.SP_S_OutstandingAmountLiability(strFilingEntityId, strFilingTransId, strUpdateStatus);

            foreach (var item in results)
            {
                objOriginalAmountEntity = new OriginalAmountEntity();
                objOriginalAmountEntity.OriginalAmountId = Convert.ToString(item.LOAN_LIB_NUMBER);
                objOriginalAmountEntity.OutstandingAmount = String.Format("{0:0.00}", item.OWED_AMT);
                lstOriginalAmountEntity.Add(objOriginalAmountEntity);
            }
            return lstOriginalAmountEntity;
        }

        /// <summary>
        /// GetExpenditureLiabilityExists
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        public String GetExpenditureLiabilityExists(String strFilingEntityId, String strFlngEntyName)
        {
            String returnFlngEntityId = String.Empty;

            var results = entities.SP_S_GetExpenditureLiabilityExists(strFilingEntityId, strFlngEntyName);

            foreach (var item in results)
            {
                returnFlngEntityId = item.Value.ToString();
            }

            return returnFlngEntityId;
        }

        /// <summary>
        /// GetExpPaymentsLiabilityData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<ExpPaymentLiabilityEntity> GetExpPaymentsLiabilityData(String strTransNumber)
        {
            IList<ExpPaymentLiabilityEntity> lstExpPaymentLiabilityEntity = new List<ExpPaymentLiabilityEntity>();
            ExpPaymentLiabilityEntity objExpPaymentLiabilityEntity;

            var results = entities.SP_S_GetExpPaymentsLiabilityData(strTransNumber);

            foreach (var item in results)
            {
                objExpPaymentLiabilityEntity = new ExpPaymentLiabilityEntity();
                objExpPaymentLiabilityEntity.TransNumber = Convert.ToString(item.TRANS_NUMBER);
                objExpPaymentLiabilityEntity.FilingEntityId = Convert.ToString(item.FLNG_ENT_ID);
                objExpPaymentLiabilityEntity.PayeeName = item.FLNG_ENT_NAME;
                objExpPaymentLiabilityEntity.DateIncurred = item.ORG_DATE;
                objExpPaymentLiabilityEntity.OrignalAmount = String.Format("{0:0.00}", item.ORG_AMT);
                objExpPaymentLiabilityEntity.OutstandingAmount = String.Format("{0:0.00}", item.OWED_AMT);
                objExpPaymentLiabilityEntity.CreditorName = item.FLNG_ENT_NAME;
                objExpPaymentLiabilityEntity.LiabilityStreetName = item.LNG_ENT_STR_NAME;
                objExpPaymentLiabilityEntity.LiabilityCity = item.FLNG_ENT_CITY;
                objExpPaymentLiabilityEntity.LiabilityState = item.FLNG_ENT_STATE;
                objExpPaymentLiabilityEntity.LiabilityZipCode = item.FLNG_ENT_ZIP;
                objExpPaymentLiabilityEntity.LiabilityExplanation = item.TRANS_EXPLNTN;
                lstExpPaymentLiabilityEntity.Add(objExpPaymentLiabilityEntity);
            }

            return lstExpPaymentLiabilityEntity;
        }

        public Boolean UpdateFlngTransExpenditureData(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var returnValue = entities.SP_U_FlngTransExpLiabSchedFN(objFilingTransactionsEntity.FilingEntId,                        
                        objFilingTransactionsEntity.SchedDate,                        
                        objFilingTransactionsEntity.PayNumber,
                        objFilingTransactionsEntity.PaymentTypeId,
                        objFilingTransactionsEntity.OrgAmt,                                                
                        objFilingTransactionsEntity.TransExplanation,                        
                        objFilingTransactionsEntity.RLiability,
                        objFilingTransactionsEntity.RSubcontractor,
                        objFilingTransactionsEntity.RItemized,
                        objFilingTransactionsEntity.FlngEntName,
                        objFilingTransactionsEntity.FlngEntCountry,
                        objFilingTransactionsEntity.FlngEntStrName,
                        objFilingTransactionsEntity.FlngEntCity,
                        objFilingTransactionsEntity.FlngEntState,
                        objFilingTransactionsEntity.FlngEntZip,
                        objFilingTransactionsEntity.ModifiedBy,
                        objFilingTransactionsEntity.LoanLiabNumberOrg,
                        objFilingTransactionsEntity.TransNumberOrg,
                        objFilingTransactionsEntity.IsAmtChanged);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// GetSubcontracorsExists
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public Boolean GetSubcontracorsExists(String strFilingTransId)
        {
            String returnFilingMappingValue = String.Empty;

            var results = entities.SP_S_GetSubcontractorsExists(strFilingTransId);

            foreach (var item in results)
            {
                returnFilingMappingValue = item.Value.ToString();
            }

            if (returnFilingMappingValue != String.Empty)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Get Date
        /// </summary>
        /// <returns></returns>
        public IList<GetSearchForScheduledI> GetDate_SchedueledJ(string FILING_ENTITY_NAME, string ORG_AMT, string flng_Ent_FirstName, 
                                                                 string flng_Ent_MiddleName, string flng_Ent_LastName, string filer_ID)
        {
            IList<GetSearchForScheduledI> lstGetSearchForScheduledI = new List<GetSearchForScheduledI>();
            GetSearchForScheduledI objGetSearchForScheduledI;

            var results = entities.SP_S_Loan_Repayment_SearchByDate(FILING_ENTITY_NAME, ORG_AMT, flng_Ent_FirstName, flng_Ent_MiddleName, flng_Ent_LastName, filer_ID);

            foreach (var item in results)
            {
                objGetSearchForScheduledI = new GetSearchForScheduledI();
                objGetSearchForScheduledI.Trans_Number = item.TRANS_NUMBER.ToString();
                objGetSearchForScheduledI.Loan_Lib_Number = item.LOAN_LIB_NUMBER.ToString();
                objGetSearchForScheduledI.Date = Convert.ToDateTime(item.SCHED_DATE).ToShortDateString().ToString();
                lstGetSearchForScheduledI.Add(objGetSearchForScheduledI);
            }
            return lstGetSearchForScheduledI;
        }

        /// <summary>
        /// Get Amount
        /// </summary>
        /// <param name="filing_date"></param>
        /// <returns></returns>
        public IList<GetSearchForScheduledI> GetAmount_SchedueledJ(string FILING_ENTITY_NAME, string flng_Ent_FirstName,
                                                                 string flng_Ent_MiddleName, string flng_Ent_LastName, string filer_ID)
        {
            IList<GetSearchForScheduledI> lstGetSearchForScheduledI = new List<GetSearchForScheduledI>();
            GetSearchForScheduledI objGetSearchForScheduledI;

            var results = entities.SP_S_Loan_Repayment_SearchByAmount(FILING_ENTITY_NAME, flng_Ent_FirstName, flng_Ent_MiddleName, flng_Ent_LastName, filer_ID);

            foreach (var item in results)
            {
                objGetSearchForScheduledI = new GetSearchForScheduledI();
                objGetSearchForScheduledI.Amount = String.Format("{0:0.00}", item.ORG_AMT); //item.ORG_AMT.ToString();
                lstGetSearchForScheduledI.Add(objGetSearchForScheduledI);
            }
            return lstGetSearchForScheduledI;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filing_date"></param>
        /// <param name="org_amt"></param>
        /// <returns></returns>
        public IList<GetSearchForScheduledI> GetName_SchedueledJ(String filer_ID)
        {
            IList<GetSearchForScheduledI> lstGetSearchForScheduledI = new List<GetSearchForScheduledI>();
            GetSearchForScheduledI objGetSearchForScheduledI;

            var results = entities.SP_S_Loan_Repayment_SearchByName(filer_ID);

            foreach (var item in results)
            {
                objGetSearchForScheduledI = new GetSearchForScheduledI();
                if (item.FLNG_ENT_NAME == null)
                {
                    objGetSearchForScheduledI.Name = "";
                }
                else
                {
                    objGetSearchForScheduledI.Name = Convert.ToString(item.FLNG_ENT_NAME);
                }
                if (item.FLNG_ENT_FIRST_NAME == null)
                {
                    objGetSearchForScheduledI.flng_Ent_FirstName = "";
                }
                else
                {
                    objGetSearchForScheduledI.flng_Ent_FirstName = Convert.ToString(item.FLNG_ENT_FIRST_NAME);
                }

                if (item.FLNG_ENT_MIDDLE_NAME == null)
                {
                    objGetSearchForScheduledI.flng_Ent_MiddleName = "";
                }
                else
                {
                    objGetSearchForScheduledI.flng_Ent_MiddleName = Convert.ToString(item.FLNG_ENT_MIDDLE_NAME);
                }

                if (item.FLNG_ENT_LAST_NAME == null)
                {
                    objGetSearchForScheduledI.flng_Ent_LastName = "";
                }
                else
                {
                    objGetSearchForScheduledI.flng_Ent_LastName = Convert.ToString(item.FLNG_ENT_LAST_NAME);
                }                
                lstGetSearchForScheduledI.Add(objGetSearchForScheduledI);
            }
            return lstGetSearchForScheduledI;
        }

        /// <summary>
        /// AddFilingTransExpReimbursmentData
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean AddFilingTransExpReimbursmentData(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var returnValue = entities.SP_I_FlngTransExpReimbursementSchedF(objFilingTransactionsEntity.TransNumber,
                objFilingTransactionsEntity.FilingSchedId,
                objFilingTransactionsEntity.SchedDate,
                objFilingTransactionsEntity.PurposeCodeId,
                objFilingTransactionsEntity.OrgAmt,
                objFilingTransactionsEntity.TransExplanation,
                objFilingTransactionsEntity.FilingEntId,
                objFilingTransactionsEntity.FlngEntName,
                objFilingTransactionsEntity.FlngEntCountry,
                objFilingTransactionsEntity.FlngEntStrName,
                objFilingTransactionsEntity.FlngEntCity,
                objFilingTransactionsEntity.FlngEntState,
                objFilingTransactionsEntity.FlngEntZip,
                objFilingTransactionsEntity.RItemized,
                objFilingTransactionsEntity.CreatedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// GetFlngTransExpReimbursementData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionsEntity> GetFlngTransExpReimbursementData(String strTransNumber)
        {
            IList<FilingTransactionsEntity> lstFilingTransactionsEntity = new List<FilingTransactionsEntity>();
            FilingTransactionsEntity objFilingTransactionsEntity;

            var results = entities.SP_S_GetExpPaymentsReimbursementData(strTransNumber);

            foreach (var item in results)
            {
                objFilingTransactionsEntity = new FilingTransactionsEntity();
                objFilingTransactionsEntity.FilingTransId = Convert.ToString(item.FILING_TRANS_ID);
                objFilingTransactionsEntity.FilingEntId = Convert.ToString(item.FLNG_ENT_ID);
                objFilingTransactionsEntity.PurposeCodeId = Convert.ToString(item.PURPOSE_CODE_ID);
                objFilingTransactionsEntity.SchedDate = item.SCHED_DATE;
                objFilingTransactionsEntity.FlngEntName = item.FLNG_ENT_NAME;
                objFilingTransactionsEntity.FlngEntCountry = item.FLNG_ENT_COUNTRY;
                objFilingTransactionsEntity.FlngEntStrName = item.FLNG_ENT_STR_NAME;
                objFilingTransactionsEntity.FlngEntCity = item.FLNG_ENT_CITY;
                objFilingTransactionsEntity.FlngEntState = item.FLNG_ENT_STATE;
                objFilingTransactionsEntity.FlngEntZip = item.FLNG_ENT_ZIP;
                objFilingTransactionsEntity.PurposeCodeDesc = item.PURPOSE_CODE_DESC;
                objFilingTransactionsEntity.OrgAmt = String.Format("{0:0.00}", item.ORG_AMT);
                objFilingTransactionsEntity.TransExplanation = item.TRANS_EXPLNTN;
                objFilingTransactionsEntity.RItemized = item.R_ITEMIZED;
                objFilingTransactionsEntity.TransNumber = item.TRANS_NUMBER;
                lstFilingTransactionsEntity.Add(objFilingTransactionsEntity);
            }

            return lstFilingTransactionsEntity;
        }

        /// <summary>
        /// GetReimbursementDetailsAmt
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public String GetReimbursementDetailsAmt(String strTransNumber)
        {
            String strReimbursementDetailsAmt = String.Empty;

            var results = entities.SP_S_GetReimbursementDetailsAmt(strTransNumber);

            foreach (var item in results)
            {
                if (item != null)
                {
                    strReimbursementDetailsAmt = String.Format("{0:0.00}", item.Value);
                }
                else
                {
                    strReimbursementDetailsAmt = "0.00";
                }

            }

            return strReimbursementDetailsAmt;
        }

        /// <summary>
        /// Get Scheudled J Entity Data
        /// </summary>
        /// <param name="filing_Trans_ID"></param>
        /// <returns></returns>
        public IList<FilingTransactionsEntity> GetScheduleJ_EntityData(string trans_Number)
        {
            IList<FilingTransactionsEntity> lstFilingTransactionsEntity = new List<FilingTransactionsEntity>();
            FilingTransactionsEntity objFilingTransactionsEntity;

            var results = entities.SP_S_Loan_Repayment_GetDataFromScheI(trans_Number);

            foreach (var item in results)
            {
                objFilingTransactionsEntity = new FilingTransactionsEntity();
                objFilingTransactionsEntity.Loan_Lib_Number = item.LOAN_LIB_NUMBER.ToString();
                objFilingTransactionsEntity.TransNumber = item.TRANS_NUMBER.ToString();
                objFilingTransactionsEntity.FlngEntName = item.FLNG_ENT_NAME.ToString();
                objFilingTransactionsEntity.FlngEntFirstName = item.FLNG_ENT_FIRST_NAME.ToString();
                objFilingTransactionsEntity.FlngEntMiddleName = item.FLNG_ENT_MIDDLE_NAME.ToString();
                objFilingTransactionsEntity.FlngEntLastName = item.FLNG_ENT_LAST_NAME.ToString();
                objFilingTransactionsEntity.FlngEntStrName = item.FLNG_ENT_STR_NAME.ToString();
                objFilingTransactionsEntity.FlngEntCity = item.FLNG_ENT_CITY.ToString();
                objFilingTransactionsEntity.FlngEntState = item.FLNG_ENT_STATE.ToString();
                objFilingTransactionsEntity.FlngEntZip = item.FLNG_ENT_ZIP.ToString();
                objFilingTransactionsEntity.FlngEntCountry = item.FLNG_ENT_COUNTRY.ToString();
                objFilingTransactionsEntity.OrgAmt = String.Format("{0:0.00}", item.ORG_AMT);  
                objFilingTransactionsEntity.LoanOtherId = item.LOAN_OTHER_ID.ToString();
                objFilingTransactionsEntity.FilingEntId = item.FLNG_ENT_ID.ToString();
                objFilingTransactionsEntity.SchedDate = item.SCHED_DATE.ToString();
                objFilingTransactionsEntity.PaymentTypeId = item.PAYMENT_TYPE_ID.ToString();
                objFilingTransactionsEntity.PayNumber = item.PAY_NUMBER.ToString();
                lstFilingTransactionsEntity.Add(objFilingTransactionsEntity);
            }
            return lstFilingTransactionsEntity;
        }

        /// <summary>
        /// Validate Scheduled J Amount
        /// </summary>
        /// <param name="filing_Trans_ID"></param>
        /// <returns></returns>
        public IList<GetSearchForScheduledI> ValidateSchedJ_Amount(string trans_Number, string status)
        {
            IList<GetSearchForScheduledI> lstGetSearchForScheduledI = new List<GetSearchForScheduledI>();
            GetSearchForScheduledI objGetSearchForScheduledI;

            var results = entities.SP_S_Loan_Repayment_Amount_Validation(trans_Number, status);

            foreach (var item in results)
            {
                objGetSearchForScheduledI = new GetSearchForScheduledI();
                objGetSearchForScheduledI.Amount = String.Format("{0:0.00}", item.ORG_AMT);
                objGetSearchForScheduledI.Original_Amt = String.Format("{0:0.00}", item.ORIGINAL_AMOUNT);
                lstGetSearchForScheduledI.Add(objGetSearchForScheduledI);
            }
            return lstGetSearchForScheduledI;
        }

        public IList<GetSearchForScheduledI> ValidateForUpdateScheJ(string filing_Trans_ID)
        {
            IList<GetSearchForScheduledI> lstGetSearchForScheduledI = new List<GetSearchForScheduledI>();
            GetSearchForScheduledI objGetSearchForScheduledI;

            var results = entities.SP_S_Loan_Repayment_UpdateAmount_Validation(filing_Trans_ID);

            foreach (var item in results)
            {
                objGetSearchForScheduledI = new GetSearchForScheduledI();
                objGetSearchForScheduledI.Amount = String.Format("{0:0.00}", item.ORG_AMT);
                objGetSearchForScheduledI.Original_Amt = item.ORIGINAL_AMOUNT.ToString();
                lstGetSearchForScheduledI.Add(objGetSearchForScheduledI);
            }
            return lstGetSearchForScheduledI;
        }

        public Boolean UpdateLoanRepaymentData(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            if (objFilingTransactionsEntity.FilingSchedId == "10")
            {
                var returnValue = entities.SP_U_FilingTransaction_LoanRepayment(objFilingTransactionsEntity.PaymentTypeId,
                        objFilingTransactionsEntity.PayNumber,
                        objFilingTransactionsEntity.OtherAmount,
                        objFilingTransactionsEntity.TransExplanation,                        
                        objFilingTransactionsEntity.ModifiedBy,
                        objFilingTransactionsEntity.FilingEntId,
                        objFilingTransactionsEntity.FlngEntName,
                        objFilingTransactionsEntity.FlngEntFirstName,
                        objFilingTransactionsEntity.FlngEntMiddleName,
                        objFilingTransactionsEntity.FlngEntLastName,
                        objFilingTransactionsEntity.FlngEntStrName,
                        objFilingTransactionsEntity.FlngEntCity,
                        objFilingTransactionsEntity.FlngEntState,
                        objFilingTransactionsEntity.FlngEntZip,
                        objFilingTransactionsEntity.FlngEntCountry,
                        objFilingTransactionsEntity.LoanOtherId,
                        objFilingTransactionsEntity.Loan_Lib_Number,
                        objFilingTransactionsEntity.TransNumber,
                        objFilingTransactionsEntity.IsAmtChanged);
                if (returnValue >= 1)
                    return true;
                else
                    return false;
            }
            else
            {
                var returnValue = entities.SP_U_LiabilitiesLoans_LoanRepayment(objFilingTransactionsEntity.FilingTransId,
                        objFilingTransactionsEntity.PaymentTypeId,
                        objFilingTransactionsEntity.PayNumber,
                        objFilingTransactionsEntity.OtherAmount,
                        objFilingTransactionsEntity.TransExplanation,
                        objFilingTransactionsEntity.OtherTransExplanation,
                        objFilingTransactionsEntity.ModifiedBy);

                if (returnValue >= 1)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Delete Loan Received Entry
        /// </summary>
        /// <param name="filing_Trans_ID"></param>
        /// <param name="modify_By"></param>
        /// <returns></returns>
        public Boolean DeleteLoanReceived(String transNumber)
        {
            var returnValue = entities.SP_D_LoanReceived(transNumber);            

            if (returnValue >= 1)
                return true;
            else
                return false;            
        }


        /// <summary>
        /// Delete Loan Repayment Entry
        /// </summary>
        /// <param name="filing_Trans_ID"></param>
        /// <param name="modify_By"></param>
        /// <returns></returns>
        public Boolean DeleteLoanRepayment(String loan_Lib_Number,String transNumber, String modify_By)
        {
            var returnValue = entities.SP_D_LoanRepayment(loan_Lib_Number, transNumber, modify_By);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        public IList<FilingTransactionDataEntity> GetFilingTransactionsForScheduledIJN(FilingTransDataEntity objFilingTransDataEntity)
        {
            IList<FilingTransactionDataEntity> lstFilingTransactionDataEntity = new List<FilingTransactionDataEntity>();
            FilingTransactionDataEntity objFilingTransactionDataEntity;

            if (objFilingTransDataEntity.SchedName == "LoanRepayment")
            {
                var results = entities.SP_S_GetLoanReceived_LoanRepayment(objFilingTransDataEntity.Loan_Lib_Num);
                foreach (var item in results)
                {
                    objFilingTransactionDataEntity = new FilingTransactionDataEntity();
                    objFilingTransactionDataEntity.FilingTransId = Convert.ToString(item.FILING_TRANS_ID);
                    objFilingTransactionDataEntity.FilingSchedId = Convert.ToString(item.FILING_SCHED_ID);
                    objFilingTransactionDataEntity.ContributorTypeId = Convert.ToString(item.CNTRBR_TYPE_ID);
                    objFilingTransactionDataEntity.ContributorTypeDesc = item.CNTRBR_TYPE_DESC;
                    objFilingTransactionDataEntity.ContributionTypeId = Convert.ToString(item.CNTRBN_TYPE_ID);
                    objFilingTransactionDataEntity.PaymentTypeId = Convert.ToString(item.PAYMENT_TYPE_ID);
                    if (item.SCHED_DATE != "")
                        objFilingTransactionDataEntity.SchedDate = Convert.ToDateTime(item.SCHED_DATE).ToShortDateString();
                    else
                        objFilingTransactionDataEntity.SchedDate = "";
                    objFilingTransactionDataEntity.FilingSchedDesc = item.FILING_SCHED_DESC;
                    objFilingTransactionDataEntity.FilingEntityId = item.FLNG_ENT_ID;
                    objFilingTransactionDataEntity.FilingEntityName = item.FLNG_ENT_NAME;
                    objFilingTransactionDataEntity.FilingFirstName = item.FLNG_ENT_FIRST_NAME;
                    objFilingTransactionDataEntity.FilingMiddleName = item.FLNG_ENT_MIDDLE_NAME;
                    objFilingTransactionDataEntity.FilingLastName = item.FLNG_ENT_LAST_NAME;
                    objFilingTransactionDataEntity.FilingCountry = item.FLNG_ENT_COUNTRY;
                    objFilingTransactionDataEntity.FilingStreetNumber = item.FLNG_ENT_STR_NUM;
                    objFilingTransactionDataEntity.FilingStreetName = item.FLNG_ENT_STR_NAME;
                    objFilingTransactionDataEntity.FilingCity = item.FLNG_ENT_CITY;
                    objFilingTransactionDataEntity.FilingState = item.FLNG_ENT_STATE;
                    objFilingTransactionDataEntity.FilingZip = item.FLNG_ENT_ZIP;
                    objFilingTransactionDataEntity.PaymentTypeDesc = item.PAYMENT_TYPE_DESC;
                    objFilingTransactionDataEntity.PayNumber = item.PAY_NUMBER;
                    objFilingTransactionDataEntity.OriginalAmount = String.Format("{0:0.00}", item.ORG_AMT);
                    objFilingTransactionDataEntity.ReceiptTypeDesc = item.RECEIPT_TYPE_ABBREV;
                    objFilingTransactionDataEntity.TransferTypeDesc = item.TRANSFER_TYPE_ABBREV;
                    objFilingTransactionDataEntity.ContributionTypeDesc = item.CNTRBN_TYPE_DESC;
                    objFilingTransactionDataEntity.PurposeCodeDesc = item.PURPOSE_CODE_ABBREV;
                    objFilingTransactionDataEntity.ReceiptCodeDesc = item.RECEIPT_CODE_DESC;
                    objFilingTransactionDataEntity.ReceiptCodeId = item.RECEIPT_CODE_ID;
                    objFilingTransactionDataEntity.RLiability = item.R_LIABILITY;
                    objFilingTransactionDataEntity.RSubcontractor = item.R_SUBCONTRACTOR;
                    if (item.ORG_DATE != "")
                        objFilingTransactionDataEntity.OriginalDate = Convert.ToDateTime(item.ORG_DATE).ToShortDateString();
                    else
                        objFilingTransactionDataEntity.OriginalDate = "";
                    objFilingTransactionDataEntity.LoanerCode = item.LOAN_OTHER_DESC;
                    objFilingTransactionDataEntity.ElectionYear = item.ELECTION_YEAR;
                    objFilingTransactionDataEntity.Office = item.DIST_OFF_CAND_BAL_PROP;
                    objFilingTransactionDataEntity.District = item.DIST_OFF_CAND_BAL_PROP;
                    objFilingTransactionDataEntity.TransExplanation = item.TRANS_EXPLNTN;
                    objFilingTransactionDataEntity.OwedAmount = String.Format("{0:0.00}", item.OWED_AMT);
                    objFilingTransactionDataEntity.TransExplanation = item.TRANS_EXPLNTN;
                    objFilingTransactionDataEntity.RItemized = item.R_ITEMIZED;
                    objFilingTransactionDataEntity.CreatedDate = item.CREATED_DATE;
                    lstFilingTransactionDataEntity.Add(objFilingTransactionDataEntity);
                }
            }
            else if (objFilingTransDataEntity.SchedName == "LoanLiabilities")
            {
                var results = entities.SP_S_GetLoanReceived_OutStandingLiabilities(objFilingTransDataEntity.Loan_Lib_Num);
                foreach (var item in results)
                {
                    objFilingTransactionDataEntity = new FilingTransactionDataEntity();
                    objFilingTransactionDataEntity.FilingTransId = Convert.ToString(item.FILING_TRANS_ID);
                    objFilingTransactionDataEntity.FilingSchedId = Convert.ToString(item.FILING_SCHED_ID);
                    objFilingTransactionDataEntity.ContributorTypeId = Convert.ToString(item.CNTRBR_TYPE_ID);
                    objFilingTransactionDataEntity.ContributorTypeDesc = item.CNTRBR_TYPE_DESC;
                    objFilingTransactionDataEntity.ContributionTypeId = Convert.ToString(item.CNTRBN_TYPE_ID);
                    objFilingTransactionDataEntity.PaymentTypeId = Convert.ToString(item.PAYMENT_TYPE_ID);
                    if (item.SCHED_DATE != "")
                        objFilingTransactionDataEntity.SchedDate = Convert.ToDateTime(item.SCHED_DATE).ToShortDateString();
                    else
                        objFilingTransactionDataEntity.SchedDate = "";
                    objFilingTransactionDataEntity.FilingSchedDesc = item.FILING_SCHED_DESC;
                    objFilingTransactionDataEntity.FilingEntityId = item.FLNG_ENT_ID;
                    objFilingTransactionDataEntity.FilingEntityName = item.FLNG_ENT_NAME;
                    objFilingTransactionDataEntity.FilingFirstName = item.FLNG_ENT_FIRST_NAME;
                    objFilingTransactionDataEntity.FilingMiddleName = item.FLNG_ENT_MIDDLE_NAME;
                    objFilingTransactionDataEntity.FilingLastName = item.FLNG_ENT_LAST_NAME;
                    objFilingTransactionDataEntity.FilingCountry = item.FLNG_ENT_COUNTRY;
                    objFilingTransactionDataEntity.FilingStreetNumber = item.FLNG_ENT_STR_NUM;
                    objFilingTransactionDataEntity.FilingStreetName = item.FLNG_ENT_STR_NAME;
                    objFilingTransactionDataEntity.FilingCity = item.FLNG_ENT_CITY;
                    objFilingTransactionDataEntity.FilingState = item.FLNG_ENT_STATE;
                    objFilingTransactionDataEntity.FilingZip = item.FLNG_ENT_ZIP;
                    objFilingTransactionDataEntity.PaymentTypeDesc = item.PAYMENT_TYPE_DESC;
                    objFilingTransactionDataEntity.PayNumber = item.PAY_NUMBER;
                    objFilingTransactionDataEntity.OriginalAmount = String.Format("{0:0.00}", item.ORG_AMT);
                    objFilingTransactionDataEntity.ReceiptTypeDesc = item.RECEIPT_TYPE_ABBREV;
                    objFilingTransactionDataEntity.TransferTypeDesc = item.TRANSFER_TYPE_ABBREV;
                    objFilingTransactionDataEntity.ContributionTypeDesc = item.CNTRBN_TYPE_DESC;
                    objFilingTransactionDataEntity.PurposeCodeDesc = item.PURPOSE_CODE_ABBREV;
                    objFilingTransactionDataEntity.ReceiptCodeDesc = item.RECEIPT_CODE_DESC;
                    objFilingTransactionDataEntity.ReceiptCodeId = item.RECEIPT_CODE_ID;
                    objFilingTransactionDataEntity.RLiability = item.R_LIABILITY;
                    objFilingTransactionDataEntity.RSubcontractor = item.R_SUBCONTRACTOR;
                    if (item.ORG_DATE != "")
                        objFilingTransactionDataEntity.OriginalDate = Convert.ToDateTime(item.ORG_DATE).ToShortDateString();
                    else
                        objFilingTransactionDataEntity.OriginalDate = "";
                    objFilingTransactionDataEntity.LoanerCode = item.LOAN_OTHER_DESC;
                    objFilingTransactionDataEntity.ElectionYear = item.ELECTION_YEAR;
                    objFilingTransactionDataEntity.Office = item.DIST_OFF_CAND_BAL_PROP;
                    objFilingTransactionDataEntity.District = item.DIST_OFF_CAND_BAL_PROP;
                    objFilingTransactionDataEntity.TransExplanation = item.TRANS_EXPLNTN;
                    objFilingTransactionDataEntity.OwedAmount = String.Format("{0:0.00}", item.OWED_AMT);
                    objFilingTransactionDataEntity.RItemized = item.R_ITEMIZED;
                    objFilingTransactionDataEntity.CreatedDate = item.CREATED_DATE;
                    lstFilingTransactionDataEntity.Add(objFilingTransactionDataEntity);
                }
            }
            else if (objFilingTransDataEntity.SchedName == "LoanReceived")
            {
                var results = entities.SP_S_GetLoanRepayment_LoanReceived(objFilingTransDataEntity.Loan_Lib_Num);
                foreach (var item in results)
                {
                    objFilingTransactionDataEntity = new FilingTransactionDataEntity();
                    objFilingTransactionDataEntity.FilingTransId = Convert.ToString(item.FILING_TRANS_ID);
                    objFilingTransactionDataEntity.FilingSchedId = Convert.ToString(item.FILING_SCHED_ID);
                    objFilingTransactionDataEntity.ContributorTypeId = Convert.ToString(item.CNTRBR_TYPE_ID);
                    objFilingTransactionDataEntity.ContributorTypeDesc = item.CNTRBR_TYPE_DESC;
                    objFilingTransactionDataEntity.ContributionTypeId = Convert.ToString(item.CNTRBN_TYPE_ID);
                    objFilingTransactionDataEntity.PaymentTypeId = Convert.ToString(item.PAYMENT_TYPE_ID);
                    if (item.SCHED_DATE != "")
                        objFilingTransactionDataEntity.SchedDate = Convert.ToDateTime(item.SCHED_DATE).ToShortDateString();
                    else
                        objFilingTransactionDataEntity.SchedDate = "";
                    objFilingTransactionDataEntity.FilingSchedDesc = item.FILING_SCHED_DESC;
                    objFilingTransactionDataEntity.FilingEntityId = item.FLNG_ENT_ID;
                    objFilingTransactionDataEntity.FilingEntityName = item.FLNG_ENT_NAME;
                    objFilingTransactionDataEntity.FilingFirstName = item.FLNG_ENT_FIRST_NAME;
                    objFilingTransactionDataEntity.FilingMiddleName = item.FLNG_ENT_MIDDLE_NAME;
                    objFilingTransactionDataEntity.FilingLastName = item.FLNG_ENT_LAST_NAME;
                    objFilingTransactionDataEntity.FilingCountry = item.FLNG_ENT_COUNTRY;
                    objFilingTransactionDataEntity.FilingStreetNumber = item.FLNG_ENT_STR_NUM;
                    objFilingTransactionDataEntity.FilingStreetName = item.FLNG_ENT_STR_NAME;
                    objFilingTransactionDataEntity.FilingCity = item.FLNG_ENT_CITY;
                    objFilingTransactionDataEntity.FilingState = item.FLNG_ENT_STATE;
                    objFilingTransactionDataEntity.FilingZip = item.FLNG_ENT_ZIP;
                    objFilingTransactionDataEntity.PaymentTypeDesc = item.PAYMENT_TYPE_DESC;
                    objFilingTransactionDataEntity.PayNumber = item.PAY_NUMBER;
                    objFilingTransactionDataEntity.OriginalAmount = String.Format("{0:0.00}", item.ORG_AMT);
                    objFilingTransactionDataEntity.ReceiptTypeDesc = item.RECEIPT_TYPE_ABBREV;
                    objFilingTransactionDataEntity.TransferTypeDesc = item.TRANSFER_TYPE_ABBREV;
                    objFilingTransactionDataEntity.ContributionTypeDesc = item.CNTRBN_TYPE_DESC;
                    objFilingTransactionDataEntity.PurposeCodeDesc = item.PURPOSE_CODE_ABBREV;
                    objFilingTransactionDataEntity.ReceiptCodeDesc = item.RECEIPT_CODE_DESC;
                    objFilingTransactionDataEntity.ReceiptCodeId = item.RECEIPT_CODE_ID;
                    objFilingTransactionDataEntity.RLiability = item.R_LIABILITY;
                    objFilingTransactionDataEntity.RSubcontractor = item.R_SUBCONTRACTOR;
                    if (item.ORG_DATE != "")
                        objFilingTransactionDataEntity.OriginalDate = Convert.ToDateTime(item.ORG_DATE).ToShortDateString();
                    else
                        objFilingTransactionDataEntity.OriginalDate = "";
                    objFilingTransactionDataEntity.LoanerCode = item.LOAN_OTHER_DESC;
                    objFilingTransactionDataEntity.ElectionYear = item.ELECTION_YEAR;
                    objFilingTransactionDataEntity.Office = item.DIST_OFF_CAND_BAL_PROP;
                    objFilingTransactionDataEntity.District = item.DIST_OFF_CAND_BAL_PROP;
                    objFilingTransactionDataEntity.TransExplanation = item.TRANS_EXPLNTN;
                    objFilingTransactionDataEntity.OwedAmount = String.Format("{0:0.00}", item.OWED_AMT);
                    objFilingTransactionDataEntity.RItemized = item.R_ITEMIZED;
                    objFilingTransactionDataEntity.CreatedDate = item.CREATED_DATE;
                    lstFilingTransactionDataEntity.Add(objFilingTransactionDataEntity);
                }
            }
            else if (objFilingTransDataEntity.SchedName == "LoanForgiven")
            {
                var results = entities.SP_S_GetLoanReceived_LoanForgiven(objFilingTransDataEntity.Loan_Lib_Num);
                foreach (var item in results)
                {
                    objFilingTransactionDataEntity = new FilingTransactionDataEntity();
                    objFilingTransactionDataEntity.FilingTransId = Convert.ToString(item.FILING_TRANS_ID);
                    objFilingTransactionDataEntity.FilingSchedId = Convert.ToString(item.FILING_SCHED_ID);
                    objFilingTransactionDataEntity.ContributorTypeId = Convert.ToString(item.CNTRBR_TYPE_ID);
                    objFilingTransactionDataEntity.ContributorTypeDesc = item.CNTRBR_TYPE_DESC;
                    objFilingTransactionDataEntity.ContributionTypeId = Convert.ToString(item.CNTRBN_TYPE_ID);
                    objFilingTransactionDataEntity.PaymentTypeId = Convert.ToString(item.PAYMENT_TYPE_ID);
                    if (item.SCHED_DATE != "")
                        objFilingTransactionDataEntity.SchedDate = Convert.ToDateTime(item.SCHED_DATE).ToShortDateString();
                    else
                        objFilingTransactionDataEntity.SchedDate = "";
                    objFilingTransactionDataEntity.FilingSchedDesc = item.FILING_SCHED_DESC;
                    objFilingTransactionDataEntity.FilingEntityId = item.FLNG_ENT_ID;
                    objFilingTransactionDataEntity.FilingEntityName = item.FLNG_ENT_NAME;
                    objFilingTransactionDataEntity.FilingFirstName = item.FLNG_ENT_FIRST_NAME;
                    objFilingTransactionDataEntity.FilingMiddleName = item.FLNG_ENT_MIDDLE_NAME;
                    objFilingTransactionDataEntity.FilingLastName = item.FLNG_ENT_LAST_NAME;
                    objFilingTransactionDataEntity.FilingCountry = item.FLNG_ENT_COUNTRY;
                    objFilingTransactionDataEntity.FilingStreetNumber = item.FLNG_ENT_STR_NUM;
                    objFilingTransactionDataEntity.FilingStreetName = item.FLNG_ENT_STR_NAME;
                    objFilingTransactionDataEntity.FilingCity = item.FLNG_ENT_CITY;
                    objFilingTransactionDataEntity.FilingState = item.FLNG_ENT_STATE;
                    objFilingTransactionDataEntity.FilingZip = item.FLNG_ENT_ZIP;
                    objFilingTransactionDataEntity.PaymentTypeDesc = item.PAYMENT_TYPE_DESC;
                    objFilingTransactionDataEntity.PayNumber = item.PAY_NUMBER;
                    objFilingTransactionDataEntity.OriginalAmount = String.Format("{0:0.00}", item.ORG_AMT);
                    objFilingTransactionDataEntity.ReceiptTypeDesc = item.RECEIPT_TYPE_ABBREV;
                    objFilingTransactionDataEntity.TransferTypeDesc = item.TRANSFER_TYPE_ABBREV;
                    objFilingTransactionDataEntity.ContributionTypeDesc = item.CNTRBN_TYPE_DESC;
                    objFilingTransactionDataEntity.PurposeCodeDesc = item.PURPOSE_CODE_ABBREV;
                    objFilingTransactionDataEntity.ReceiptCodeDesc = item.RECEIPT_CODE_DESC;
                    objFilingTransactionDataEntity.ReceiptCodeId = item.RECEIPT_CODE_ID;
                    objFilingTransactionDataEntity.RLiability = item.R_LIABILITY;
                    objFilingTransactionDataEntity.RSubcontractor = item.R_SUBCONTRACTOR;
                    if (item.ORG_DATE != "")
                        objFilingTransactionDataEntity.OriginalDate = Convert.ToDateTime(item.ORG_DATE).ToShortDateString();
                    else
                        objFilingTransactionDataEntity.OriginalDate = "";
                    objFilingTransactionDataEntity.LoanerCode = item.LOAN_OTHER_DESC;
                    objFilingTransactionDataEntity.ElectionYear = item.ELECTION_YEAR;
                    objFilingTransactionDataEntity.Office = item.DIST_OFF_CAND_BAL_PROP;
                    objFilingTransactionDataEntity.District = item.DIST_OFF_CAND_BAL_PROP;
                    objFilingTransactionDataEntity.TransExplanation = item.TRANS_EXPLNTN;
                    objFilingTransactionDataEntity.OwedAmount = String.Format("{0:0.00}", item.OWED_AMT);
                    objFilingTransactionDataEntity.RItemized = item.R_ITEMIZED;
                    objFilingTransactionDataEntity.CreatedDate = item.CREATED_DATE;
                    lstFilingTransactionDataEntity.Add(objFilingTransactionDataEntity);
                }
            }            
            return lstFilingTransactionDataEntity;
        }

        /// <summary>
        /// UpdateFilingTransExpReimbursmentData
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean UpdateFilingTransExpReimbursmentData(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var returnValue = entities.SP_U_FlngTransExpReimbursementSchedF(objFilingTransactionsEntity.TransNumber,
                objFilingTransactionsEntity.FilingSchedId,
                objFilingTransactionsEntity.SchedDate,
                objFilingTransactionsEntity.PurposeCodeId,
                objFilingTransactionsEntity.OrgAmt,
                objFilingTransactionsEntity.TransExplanation,
                objFilingTransactionsEntity.FilingEntId,
                objFilingTransactionsEntity.FlngEntName,
                objFilingTransactionsEntity.FlngEntCountry,
                objFilingTransactionsEntity.FlngEntStrName,
                objFilingTransactionsEntity.FlngEntCity,
                objFilingTransactionsEntity.FlngEntState,
                objFilingTransactionsEntity.FlngEntZip,
                objFilingTransactionsEntity.CreatedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// DeleteFlngTransReimbursementDataSchedF
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strFilingTransMapping"></param>
        /// <param name="strModififedBy"></param>
        /// <returns></returns>
        public Boolean DeleteFlngTransReimbursementDataSchedF(String strTransNumber, String strModififedBy)
        {
            var returnValue = entities.SP_D_FlngTransReimbursementData(strTransNumber, strModififedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// AddFilingTransNonCompaignHKExpensesData
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public String AddFilingTransNonCompaignHKExpensesData(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            ObjectParameter objReturnValue = new ObjectParameter("RETURN_TRANS_IDENTITY", typeof(int));
            String strReturnValue = String.Empty;

            var returnValue = entities.SP_I_FlngTransNonCompHKExpensesSchedQ(objFilingTransactionsEntity.FilerId,
                objFilingTransactionsEntity.FilingSchedId,
                objFilingTransactionsEntity.SchedDate,
                objFilingTransactionsEntity.PurposeCodeId,
                objFilingTransactionsEntity.PaymentTypeId,
                objFilingTransactionsEntity.PayNumber,
                objFilingTransactionsEntity.OrgAmt,
                objFilingTransactionsEntity.TransExplanation,
                objFilingTransactionsEntity.ElectionDate,
                objFilingTransactionsEntity.ElectionTypeId,
                objFilingTransactionsEntity.OfficeTypeId,
                objFilingTransactionsEntity.FilingTypeId,
                objFilingTransactionsEntity.ElectYearId,
                objFilingTransactionsEntity.ElectionYear,
                objFilingTransactionsEntity.FilingEntId,
                objFilingTransactionsEntity.FlngEntName,
                objFilingTransactionsEntity.FlngEntCountry,
                objFilingTransactionsEntity.FlngEntStrName,
                objFilingTransactionsEntity.FlngEntCity,
                objFilingTransactionsEntity.FlngEntState,
                objFilingTransactionsEntity.FlngEntZip,
                objFilingTransactionsEntity.RItemized,
                objFilingTransactionsEntity.CreatedBy,
                objFilingTransactionsEntity.ElectionDateId,
                objFilingTransactionsEntity.ResigTermTypeId,
                objFilingTransactionsEntity.FilingDate,
                objReturnValue);

            strReturnValue = Convert.ToString(objReturnValue.Value);
            return strReturnValue;

            //if (returnValue >= 1)
            //    return true;
            //else
            //    return false;
        }

        /// <summary>
        /// GetNCHKExpensesReimbursementData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionsEntity> GetNCHKExpensesReimbursementData(String strFilingTransId)
        {
            IList<FilingTransactionsEntity> lstFilingTransactionsEntity = new List<FilingTransactionsEntity>();
            FilingTransactionsEntity objFilingTransactionsEntity;

            var results = entities.SP_S_GetNCHKExpensesReimbursementData(strFilingTransId);

            foreach (var item in results)
            {
                objFilingTransactionsEntity = new FilingTransactionsEntity();
                objFilingTransactionsEntity.FilingTransId = Convert.ToString(item.FILING_TRANS_ID);
                objFilingTransactionsEntity.FilingEntId = Convert.ToString(item.FLNG_ENT_ID);
                objFilingTransactionsEntity.PurposeCodeId = Convert.ToString(item.PURPOSE_CODE_ID);
                objFilingTransactionsEntity.SchedDate = item.SCHED_DATE;
                if (item.R_ITEMIZED == "N")
                    objFilingTransactionsEntity.FlngEntName = "";
                else
                    objFilingTransactionsEntity.FlngEntName = item.FLNG_ENT_NAME;
                objFilingTransactionsEntity.FlngEntCountry = item.FLNG_ENT_COUNTRY;
                objFilingTransactionsEntity.FlngEntStrName = item.FLNG_ENT_STR_NAME;
                objFilingTransactionsEntity.FlngEntCity = item.FLNG_ENT_CITY;
                objFilingTransactionsEntity.FlngEntState = item.FLNG_ENT_STATE;
                objFilingTransactionsEntity.FlngEntZip = item.FLNG_ENT_ZIP;
                objFilingTransactionsEntity.OrgAmt = String.Format("{0:0.00}", item.ORG_AMT);
                objFilingTransactionsEntity.TransExplanation = item.TRANS_EXPLNTN;
                objFilingTransactionsEntity.RItemized = item.R_ITEMIZED;
                objFilingTransactionsEntity.PurposeCodeDesc = item.PURPOSE_CODE_DESC;
                lstFilingTransactionsEntity.Add(objFilingTransactionsEntity);
            }

            return lstFilingTransactionsEntity;
        }

        /// <summary>
        /// UpdateNonCompaignHKExpensesSchedQData
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean UpdateNonCompaignHKExpensesSchedQData(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var returnValue = entities.SP_U_FilingTransaction_NonCompHKExpenses(objFilingTransactionsEntity.TransNumber,
                objFilingTransactionsEntity.FilingEntId,
                objFilingTransactionsEntity.PurposeCodeId,
                objFilingTransactionsEntity.SchedDate,
                objFilingTransactionsEntity.PayNumber,
                objFilingTransactionsEntity.PaymentTypeId,
                objFilingTransactionsEntity.OrgAmt,
                objFilingTransactionsEntity.TransExplanation,
                objFilingTransactionsEntity.FlngEntName,
                objFilingTransactionsEntity.FlngEntCountry,
                objFilingTransactionsEntity.FlngEntStrName,
                objFilingTransactionsEntity.FlngEntCity,
                objFilingTransactionsEntity.FlngEntState,
                objFilingTransactionsEntity.FlngEntZip,
                objFilingTransactionsEntity.ModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Update Outstanding Loans
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean UpdateOutStandingLoansData(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var returnValue = entities.SP_U_FilingTransaction_OutstandingLoans(objFilingTransactionsEntity.FilingTransId,
                        objFilingTransactionsEntity.TransExplanation,
                        objFilingTransactionsEntity.OtherTransExplanation,
                        objFilingTransactionsEntity.ModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Check Scheduled for Outstanding Loans
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionsEntity> CheckOutstandingScheduled(String strFilingTransId)
        {
            IList<FilingTransactionsEntity> lstFilingTransactionsEntity = new List<FilingTransactionsEntity>();
            FilingTransactionsEntity objFilingTransactionsEntity;

            var results = entities.SP_S_GetOutstanding_SchedI_SchedJ(strFilingTransId);

            foreach (var item in results)
            {
                objFilingTransactionsEntity = new FilingTransactionsEntity();
                objFilingTransactionsEntity.FilingTransId = Convert.ToString(item.FILING_TRANS_ID);
                lstFilingTransactionsEntity.Add(objFilingTransactionsEntity);
            }

            return lstFilingTransactionsEntity;
        }

        /// <summary>
        /// Validate Loan Received Amount
        /// </summary>
        /// <param name="filing_Trans_ID"></param>
        /// <returns></returns>
        public IList<GetSearchForScheduledI> ValidateSchedI_UpdateAmount(string trans_Number)
        {
            IList<GetSearchForScheduledI> lstGetSearchForScheduledI = new List<GetSearchForScheduledI>();
            GetSearchForScheduledI objGetSearchForScheduledI;

            var results = entities.SP_S_Loan_Received_UpdateAmount_Validation(trans_Number);

            foreach (var item in results)
            {
                objGetSearchForScheduledI = new GetSearchForScheduledI();
                objGetSearchForScheduledI.Amount = String.Format("{0:0.00}", item.OWED_AMT);
                lstGetSearchForScheduledI.Add(objGetSearchForScheduledI);
            }
            return lstGetSearchForScheduledI;
        }

        /// <summary>
        /// GetExpLiabilityOwedAmt
        /// </summary>
        /// <param name="strFlngEntityId"></param>
        /// <returns></returns>
        public String GetExpLiabilityOwedAmt(String strFlngEntityId)
        {
            String strExpLiabilityOwedAmt = String.Empty;

            var results = entities.SP_S_GetExpLiabilityOwedAmt(strFlngEntityId);

            foreach (var item in results)
            {
                if (item != null)
                    strExpLiabilityOwedAmt = String.Format("{0:0.00}", item.Value);
                else
                    strExpLiabilityOwedAmt = "0";
            }

            return strExpLiabilityOwedAmt;
        }

        /// <summary>
        /// GetExpSubContrTotAmt
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public String GetExpSubContrTotAmt(String strTransNumber)
        {
            String strExpSubContrTotAmt = String.Empty;

            var results = entities.SP_S_GetExpSubContrAmtTot(strTransNumber);

            foreach (var item in results)
            {
                if (item != null)
                    strExpSubContrTotAmt = String.Format("{0:0.00}", item.Value);
                else
                    strExpSubContrTotAmt = "";
            }

            return strExpSubContrTotAmt;
        }

        /// <summary>
        /// GetOutstandingLiabilityAmount
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <param name="strUpdateStatus"></param>
        /// <returns></returns>
        public String GetOutstandingLiabilityAmount(String strFilingEntityId, String strFlngTransId)
        {
            String strOutstandingLiablityAmount = String.Empty;

            var results = entities.SP_S_GetOutstandingLiabilityAmount(strFilingEntityId, strFlngTransId);

            foreach (var item in results)
            {
                if (item != null)
                    strOutstandingLiablityAmount = String.Format("{0:0.00}", item.Value);
                else
                    strOutstandingLiablityAmount = "";
            }

            return strOutstandingLiablityAmount;
        }

        /// <summary>
        /// GetExpPayTotalLiabAmount
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <param name="strFlngTransId"></param>
        /// <returns></returns>
        public String GetExpPayTotalLiabAmount(String strTransNumber)
        {
            String strExpPayTotalLiabAmount = String.Empty;

            var results = entities.SP_S_GetExpPaymentsTotalLiabAmount(strTransNumber);

            foreach (var item in results)
            {
                if (item != null)
                    strExpPayTotalLiabAmount = String.Format("{0:0.00}", item.Value);
                else
                    strExpPayTotalLiabAmount = "";
            }

            return strExpPayTotalLiabAmount;
        }

        /// <summary>
        /// Add Loan Forgiven
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean AddFilingTransaction_LoanForgiven(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var result = entities.SP_I_FilingTransaction_LoanForgiven(objFilingTransactionsEntity.FilerId,
                                                                        objFilingTransactionsEntity.FilingSchedId,
                                                                        objFilingTransactionsEntity.OtherFilingSchedId,
                                                                        objFilingTransactionsEntity.SchedDate,
                                                                        objFilingTransactionsEntity.OrgAmt,
                                                                        objFilingTransactionsEntity.OtherAmount,
                                                                        objFilingTransactionsEntity.TransExplanation,
                                                                        objFilingTransactionsEntity.ElectionTypeId,
                                                                        objFilingTransactionsEntity.OfficeTypeId,
                                                                        objFilingTransactionsEntity.FilingTypeId,
                                                                        objFilingTransactionsEntity.ElectYearId,
                                                                        objFilingTransactionsEntity.FilingEntId,
                                                                        objFilingTransactionsEntity.CreatedBy,
                                                                        objFilingTransactionsEntity.FlngEntName,
                                                                        objFilingTransactionsEntity.FlngEntFirstName,
                                                                        objFilingTransactionsEntity.FlngEntMiddleName,
                                                                        objFilingTransactionsEntity.FlngEntLastName,
                                                                        objFilingTransactionsEntity.FlngEntStrName,
                                                                        objFilingTransactionsEntity.FlngEntCity,
                                                                        objFilingTransactionsEntity.FlngEntState,
                                                                        objFilingTransactionsEntity.FlngEntZip,
                                                                        objFilingTransactionsEntity.FlngEntCountry,
                                                                        objFilingTransactionsEntity.PaymentTypeId,
                                                                        objFilingTransactionsEntity.LoanOtherId,
                                                                        objFilingTransactionsEntity.PayNumber,
                                                                        objFilingTransactionsEntity.FilingDate,
                                                                        objFilingTransactionsEntity.ElectionDateId,
                                                                        objFilingTransactionsEntity.ResigTermTypeId,
                                                                        objFilingTransactionsEntity.Loan_Lib_Number,
                                                                        objFilingTransactionsEntity.TransNumber);

            if (result >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// GetContributorTypesSchedC
        /// </summary>
        /// <returns></returns>
        public IList<ContributorNameEntity> GetContributorTypesSchedC()
        {
            IList<ContributorNameEntity> lstContributorNameEntity = new List<ContributorNameEntity>();
            ContributorNameEntity objContributorNameEntity;

            var results = entities.SP_S_ContributorTypesSchedC();

            foreach (var item in results)
            {
                objContributorNameEntity = new ContributorNameEntity();
                objContributorNameEntity.ContributorTypeId = Convert.ToString(item.CNTRBR_TYPE_ID);
                objContributorNameEntity.ContributorTypeDesc = item.CNTRBR_TYPE_DESC;
                objContributorNameEntity.ContributorTypeAbbrev = item.CNTRBR_TYPE_ABBREV;
                lstContributorNameEntity.Add(objContributorNameEntity);
            }

            return lstContributorNameEntity;
        }


        /// <summary>
        /// Delete Loan Forgiven Record
        /// </summary>
        /// <param name="filing_Trans_ID"></param>
        /// <param name="modify_By"></param>
        /// <returns></returns>
        public Boolean DeleteLoanForgiven(String loan_Lib_Number,String transNumber, String modify_By)
        {
            var returnValue = entities.SP_D_LoanForgiven(loan_Lib_Number, transNumber, modify_By);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// GetPurposeCodeReimburDetailsData
        /// </summary>
        /// <returns></returns>
        public IList<PurposeCodeEntity> GetPurposeCodeReimburDetailsData()
        {
            IList<PurposeCodeEntity> lstPurposeCodeEntity = new List<PurposeCodeEntity>();
            PurposeCodeEntity objPurposeCodeEntity;

            var results = entities.SP_S_PurposeCodeReimburDetails();

            foreach (var item in results)
            {
                objPurposeCodeEntity = new PurposeCodeEntity();
                objPurposeCodeEntity.PurposeCodeId = Convert.ToString(item.PURPOSE_CODE_ID);
                objPurposeCodeEntity.PurposeCodeDesc = item.PURPOSE_CODE_DESC;
                objPurposeCodeEntity.PurposeCodeAbbrev = item.PURPOSE_CODE_ABBREV;
                lstPurposeCodeEntity.Add(objPurposeCodeEntity);
            }

            return lstPurposeCodeEntity;
        }


        /// <summary>
        /// Add Authorized To Sign Check Entry
        /// </summary>
        /// <param name="objAuthorizedToSignCheckEntity"></param>
        /// <returns></returns>
        public Boolean AddAuthorizedToSignCheck(AuthorizedToSignCheckEntity objAuthorizedToSignCheckEntity)
        {
            var returnValue = entities.SP_I_Trea_AuthorizedToSignCheck(objAuthorizedToSignCheckEntity.CommID,
                objAuthorizedToSignCheckEntity.StartDate, objAuthorizedToSignCheckEntity.Status, objAuthorizedToSignCheckEntity.EndDate,
                objAuthorizedToSignCheckEntity.Prefix, objAuthorizedToSignCheckEntity.FirstName, objAuthorizedToSignCheckEntity.MiddleName,
                objAuthorizedToSignCheckEntity.LastName, objAuthorizedToSignCheckEntity.Suffix, objAuthorizedToSignCheckEntity.Signature,
                objAuthorizedToSignCheckEntity.CreatedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// GetPurposeCodeSubcontractorSchedF
        /// </summary>
        /// <returns></returns>
        public IList<PurposeCodeEntity> GetPurposeCodeSubcontractorSchedF()
        {
            IList<PurposeCodeEntity> lstPurposeCodeEntity = new List<PurposeCodeEntity>();
            PurposeCodeEntity objPurposeCodeEntity;

            var results = entities.SP_S_PurposeCodeSubcontractorSchedF();

            foreach (var item in results)
            {
                objPurposeCodeEntity = new PurposeCodeEntity();
                objPurposeCodeEntity.PurposeCodeId = Convert.ToString(item.PURPOSE_CODE_ID);
                objPurposeCodeEntity.PurposeCodeDesc = item.PURPOSE_CODE_DESC;
                objPurposeCodeEntity.PurposeCodeAbbrev = item.PURPOSE_CODE_ABBREV;
                lstPurposeCodeEntity.Add(objPurposeCodeEntity);
            }

            return lstPurposeCodeEntity;
        }

        /// <summary>
        /// GetPurposeCodeCreditCardItemSchedF
        /// </summary>
        /// <returns></returns>
        public IList<PurposeCodeEntity> GetPurposeCodeCreditCardItemSchedF()
        {
            IList<PurposeCodeEntity> lstPurposeCodeEntity = new List<PurposeCodeEntity>();
            PurposeCodeEntity objPurposeCodeEntity;

            var results = entities.SP_S_PurposeCodeCreditCardItem();

            foreach (var item in results)
            {
                objPurposeCodeEntity = new PurposeCodeEntity();
                objPurposeCodeEntity.PurposeCodeId = Convert.ToString(item.PURPOSE_CODE_ID);
                objPurposeCodeEntity.PurposeCodeDesc = item.PURPOSE_CODE_DESC;
                objPurposeCodeEntity.PurposeCodeAbbrev = item.PURPOSE_CODE_ABBREV;
                lstPurposeCodeEntity.Add(objPurposeCodeEntity);
            }

            return lstPurposeCodeEntity;
        }

        /// <summary>
        /// GetExpPayTransIdPopUpSchedF
        /// </summary>
        /// <returns></returns>
        public IList<ExpPaymentTransIdPopUpSchedFEntity> GetExpPayTransIdPopUpSchedF(String strTransNumber)
        {
            IList<ExpPaymentTransIdPopUpSchedFEntity> lstExpPaymentTransIdPopUpSchedFEntity = new List<ExpPaymentTransIdPopUpSchedFEntity>();
            ExpPaymentTransIdPopUpSchedFEntity objExpPaymentTransIdPopUpSchedFEntity;

            var results = entities.SP_S_ExpPaymentsTransIdPopUpSchedF(strTransNumber);

            foreach (var item in results)
            {
                objExpPaymentTransIdPopUpSchedFEntity = new ExpPaymentTransIdPopUpSchedFEntity();
                objExpPaymentTransIdPopUpSchedFEntity.TransNumber = Convert.ToString(item.TRANS_NUMBER);
                objExpPaymentTransIdPopUpSchedFEntity.FilingSchedId = Convert.ToString(item.FILING_SCHED_ID);
                objExpPaymentTransIdPopUpSchedFEntity.ScheduleDate = item.SCHED_DATE;
                objExpPaymentTransIdPopUpSchedFEntity.OrgAmount = String.Format("{0:0.00}", item.ORG_AMT);
                lstExpPaymentTransIdPopUpSchedFEntity.Add(objExpPaymentTransIdPopUpSchedFEntity);
            }

            return lstExpPaymentTransIdPopUpSchedFEntity;
        }

        /// <summary>
        /// Add Loan Forgiven Liabilities
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean AddFilingTransaction_LoanForgiven_Liabiliites(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var result = entities.SP_I_FilingTransaction_LoanForgiven_Liabilities(objFilingTransactionsEntity.FilerId,                                                                        
                                                                        objFilingTransactionsEntity.RLiabilityExists,
                                                                        objFilingTransactionsEntity.SchedDate,
                                                                        objFilingTransactionsEntity.FlngEntName,
                                                                        objFilingTransactionsEntity.FilingEntId,
                                                                        objFilingTransactionsEntity.FlngEntStrName,
                                                                        objFilingTransactionsEntity.FlngEntCity,
                                                                        objFilingTransactionsEntity.FlngEntState,
                                                                        objFilingTransactionsEntity.FlngEntZip,
                                                                        objFilingTransactionsEntity.FlngEntCountry,
                                                                        objFilingTransactionsEntity.PaymentTypeId,
                                                                        objFilingTransactionsEntity.PayNumber,
                                                                        objFilingTransactionsEntity.OrgAmt,
                                                                        objFilingTransactionsEntity.OtherAmount,
                                                                        objFilingTransactionsEntity.OwedAmt,
                                                                        objFilingTransactionsEntity.TransExplanation,
                                                                        objFilingTransactionsEntity.ElectionTypeId,
                                                                        objFilingTransactionsEntity.OfficeTypeId,
                                                                        objFilingTransactionsEntity.FilingTypeId,
                                                                        objFilingTransactionsEntity.ElectYearId,
                                                                        objFilingTransactionsEntity.CreatedBy,
                                                                        objFilingTransactionsEntity.FilingDate,
                                                                        objFilingTransactionsEntity.ElectionDateId,
                                                                        objFilingTransactionsEntity.ResigTermTypeId,
                                                                        objFilingTransactionsEntity.TransNumber
                                                                        );

            return true;
        }

        /// <summary>
        /// GetDateIncurredLiabUpdateData
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        public IList<DateIncurredEntity> GetDateIncurredLiabUpdateData(String strTransNumber)
        {
            IList<DateIncurredEntity> lstDateIncurredEntity = new List<DateIncurredEntity>();
            DateIncurredEntity objDateIncurredEntity;

            var results = entities.SP_S_DateInccuredLiabilityUpdate(strTransNumber);

            foreach (var item in results)
            {
                objDateIncurredEntity = new DateIncurredEntity();
                objDateIncurredEntity.DateIncurredId = Convert.ToString(item.TRANS_NUMBER);
                objDateIncurredEntity.DateIncurredValue = item.SCHED_DATE;
                objDateIncurredEntity.AmountLiability = String.Format("{0:0.00}", item.ORG_AMT);
                lstDateIncurredEntity.Add(objDateIncurredEntity);
            }
            return lstDateIncurredEntity;
        }

        // Add Other Receipts Received Transaction Data.
        /// <summary>
        /// AddOtherReceivedReceiptsSchedE
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean AddOtherReceivedReceiptsSchedE(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var result = entities.SP_I_FlngTransOtherReceiptsReceivedSchedE(objFilingTransactionsEntity.FilerId,
                objFilingTransactionsEntity.ElectionDate,
                objFilingTransactionsEntity.ElectionTypeId,
                objFilingTransactionsEntity.OfficeTypeId,
                objFilingTransactionsEntity.FilingTypeId,
                objFilingTransactionsEntity.ElectYearId,
                objFilingTransactionsEntity.ElectionYear,
                objFilingTransactionsEntity.FilingSchedId,
                objFilingTransactionsEntity.SchedDate,
                objFilingTransactionsEntity.FilingEntId,
                objFilingTransactionsEntity.FlngEntName,
                objFilingTransactionsEntity.FlngEntCountry,
                objFilingTransactionsEntity.FlngEntStrName,
                objFilingTransactionsEntity.FlngEntCity,
                objFilingTransactionsEntity.FlngEntState,
                objFilingTransactionsEntity.FlngEntZip,
                objFilingTransactionsEntity.ReceiptTypeId,
                objFilingTransactionsEntity.PaymentTypeId,
                objFilingTransactionsEntity.PayNumber,
                objFilingTransactionsEntity.OrgAmt,
                objFilingTransactionsEntity.TransExplanation,
                objFilingTransactionsEntity.RItemized,
                objFilingTransactionsEntity.ElectionDateId,
                objFilingTransactionsEntity.CreatedBy,
                objFilingTransactionsEntity.ResigTermTypeId,
                objFilingTransactionsEntity.FilingDate);

            if (result >= 1)
                return true;
            else
                return false;

            //return true;
        }

        // Update Other Receipts Received Transactions.
        /// <summary>
        /// UpdateOtherReceiptsReceivedSchedE
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean UpdateOtherReceiptsReceivedSchedE(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var returnValue = entities.SP_U_FlngTransOtherReceiptsReceivedSchedE(objFilingTransactionsEntity.TransNumber,
                objFilingTransactionsEntity.SchedDate,
                objFilingTransactionsEntity.FilingEntId,
                objFilingTransactionsEntity.FlngEntName,
                objFilingTransactionsEntity.FlngEntCountry,
                objFilingTransactionsEntity.FlngEntStrName,
                objFilingTransactionsEntity.FlngEntCity,
                objFilingTransactionsEntity.FlngEntState,
                objFilingTransactionsEntity.FlngEntZip,
                objFilingTransactionsEntity.ReceiptTypeId,
                objFilingTransactionsEntity.PaymentTypeId,
                objFilingTransactionsEntity.PayNumber,
                objFilingTransactionsEntity.OrgAmt,
                objFilingTransactionsEntity.TransExplanation,
                objFilingTransactionsEntity.RItemized,
                objFilingTransactionsEntity.ModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// GetOriginalName
        /// </summary>
        /// <returns></returns>
        public IList<ExpPaymentOriginalNameEntity> GetOriginalName()
        {
            IList<ExpPaymentOriginalNameEntity> lstExpPaymentOriginalNameEntity = new List<ExpPaymentOriginalNameEntity>();
            ExpPaymentOriginalNameEntity objExpPaymentOriginalNameEntity;

            var results = entities.SP_S_ExpPaymentOrginalName();

            foreach (var item in results)
            {
                objExpPaymentOriginalNameEntity = new ExpPaymentOriginalNameEntity();
                objExpPaymentOriginalNameEntity.FilingEntityId = Convert.ToString(item.FLNG_ENT_ID);
                objExpPaymentOriginalNameEntity.FilingEntityName = item.FLNG_ENT_NAME;
                lstExpPaymentOriginalNameEntity.Add(objExpPaymentOriginalNameEntity);
            }

            return lstExpPaymentOriginalNameEntity;
        }

        /// <summary>
        /// GetOriginalAmount
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        public IList<ExpPaymentOriginalAmountEntity> GetOriginalAmount(String strFilingEntityId)
        {
            IList<ExpPaymentOriginalAmountEntity> lstExpPaymentOriginalAmountEntity = new List<ExpPaymentOriginalAmountEntity>();
            ExpPaymentOriginalAmountEntity objExpPaymentOriginalAmountEntity;

            var results = entities.SP_S_ExpPaymentOrginalAmount(strFilingEntityId);

            foreach (var item in results)
            {
                objExpPaymentOriginalAmountEntity = new ExpPaymentOriginalAmountEntity();
                objExpPaymentOriginalAmountEntity.TransNumber = item.TRANS_NUMBER;
                objExpPaymentOriginalAmountEntity.OriginalAmount = String.Format("{0:0.00}", item.ORG_AMT);
                lstExpPaymentOriginalAmountEntity.Add(objExpPaymentOriginalAmountEntity);
            }

            return lstExpPaymentOriginalAmountEntity;
        }

        /// <summary>
        /// GetOriginalExpeseDate
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<ExpPaymentOriginalExpenseDateEntity> GetOriginalExpeseDate(String strTransNumber)
        {
            IList<ExpPaymentOriginalExpenseDateEntity> lstExpPaymentOriginalExpenseDateEntity = new List<ExpPaymentOriginalExpenseDateEntity>();
            ExpPaymentOriginalExpenseDateEntity objExpPaymentOriginalExpenseDateEntity;

            var results = entities.SP_S_ExpPaymentOrginalExpenseDate(strTransNumber);

            foreach (var item in results)
            {
                objExpPaymentOriginalExpenseDateEntity = new ExpPaymentOriginalExpenseDateEntity();
                objExpPaymentOriginalExpenseDateEntity.TransNumber = item.TRANS_NUMBER;
                objExpPaymentOriginalExpenseDateEntity.OriginalExpenseDate = item.SCHED_DATE;
                lstExpPaymentOriginalExpenseDateEntity.Add(objExpPaymentOriginalExpenseDateEntity);
            }

            return lstExpPaymentOriginalExpenseDateEntity;
        }

        /// <summary>
        /// AddExpenditureRefundedSchedL
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean AddExpenditureRefundsSchedL(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var result = entities.SP_I_FlngTransExpenditureRefundsSchedL(objFilingTransactionsEntity.FilerId,
                objFilingTransactionsEntity.ElectionDate,
                objFilingTransactionsEntity.ElectionTypeId,
                objFilingTransactionsEntity.OfficeTypeId,
                objFilingTransactionsEntity.FilingTypeId,
                objFilingTransactionsEntity.ElectYearId,
                objFilingTransactionsEntity.ElectionYear,
                objFilingTransactionsEntity.TransNumberOrg,
                objFilingTransactionsEntity.FilingSchedId,
                objFilingTransactionsEntity.SchedDate,
                objFilingTransactionsEntity.FilingEntId,
                objFilingTransactionsEntity.FlngEntName,
                objFilingTransactionsEntity.FlngEntCountry,
                objFilingTransactionsEntity.FlngEntStrName,
                objFilingTransactionsEntity.FlngEntCity,
                objFilingTransactionsEntity.FlngEntState,
                objFilingTransactionsEntity.FlngEntZip,
                objFilingTransactionsEntity.PaymentTypeId,
                objFilingTransactionsEntity.PayNumber,
                objFilingTransactionsEntity.OrgAmt,
                objFilingTransactionsEntity.TransExplanation,
                objFilingTransactionsEntity.ElectionDateId,
                objFilingTransactionsEntity.ResigTermTypeId,
                objFilingTransactionsEntity.FilingDate,
                objFilingTransactionsEntity.CreatedBy);

            if (result >= 1)
                return true;
            else
                return false;

            //return true;
        }

        /// <summary>
        /// GetOutstaningAmtExpRefunded
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public String GetOutstaningAmtExpRefunded(String strTransNumber)
        {
            String strOutstaningExpRefundedAmt = String.Empty;

            var results = entities.SP_S_OutstandingAmtRefundedSchedL(strTransNumber);

            foreach (var item in results)
            {
                if (item != null)
                    strOutstaningExpRefundedAmt = String.Format("{0:0.00}", item.Value);
            }

            return strOutstaningExpRefundedAmt;
        }

        /// <summary>
        /// UpdateExpenditureRefundedSchedL
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean UpdateExpenditureRefundedSchedL(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var returnValue = entities.SP_U_FlngTransExpenditureRefundedSchedL(objFilingTransactionsEntity.TransNumber,
                                                    objFilingTransactionsEntity.SchedDate,
                                                    objFilingTransactionsEntity.FilingEntId,
                                                    objFilingTransactionsEntity.FlngEntName,
                                                    objFilingTransactionsEntity.FlngEntCountry,
                                                    objFilingTransactionsEntity.FlngEntStrName,
                                                    objFilingTransactionsEntity.FlngEntCity,
                                                    objFilingTransactionsEntity.FlngEntState,
                                                    objFilingTransactionsEntity.FlngEntZip,
                                                    objFilingTransactionsEntity.PaymentTypeId,
                                                    objFilingTransactionsEntity.PayNumber,
                                                    objFilingTransactionsEntity.OrgAmt,
                                                    objFilingTransactionsEntity.TransExplanation,
                                                    objFilingTransactionsEntity.ModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// GetOriginalAmtRefundedSchedL
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<ExpPaymentOriginalAmountEntity> GetOriginalAmtRefundedSchedL(String strTransNumber)
        {
            IList<ExpPaymentOriginalAmountEntity> lstExpPaymentOriginalAmountEntity = new List<ExpPaymentOriginalAmountEntity>();
            ExpPaymentOriginalAmountEntity objExpPaymentOriginalAmountEntity;

            var results = entities.SP_S_OriginalAmtRefundedSchedL(strTransNumber);

            foreach (var item in results)
            {
                objExpPaymentOriginalAmountEntity = new ExpPaymentOriginalAmountEntity();
                objExpPaymentOriginalAmountEntity.TransNumber = item.TRANS_NUMBER;
                objExpPaymentOriginalAmountEntity.OriginalAmount = String.Format("{0:0.00}", item.ORG_AMT);
                lstExpPaymentOriginalAmountEntity.Add(objExpPaymentOriginalAmountEntity);
            }

            return lstExpPaymentOriginalAmountEntity;
        }

        /// <summary>
        /// GetContributorOriginalName
        /// </summary>
        /// <returns></returns>
        public IList<ExpPaymentOriginalNameEntity> GetContributorOriginalName()
        {
            IList<ExpPaymentOriginalNameEntity> lstExpPaymentOriginalNameEntity = new List<ExpPaymentOriginalNameEntity>();
            ExpPaymentOriginalNameEntity objExpPaymentOriginalNameEntity;

            var results = entities.SP_S_ContrbutorOrginalName();

            foreach (var item in results)
            {
                objExpPaymentOriginalNameEntity = new ExpPaymentOriginalNameEntity();
                objExpPaymentOriginalNameEntity.FilingEntityId = Convert.ToString(item.FLNG_ENT_ID);
                objExpPaymentOriginalNameEntity.FilingEntityName = item.FLNG_ENT_NAME;
                lstExpPaymentOriginalNameEntity.Add(objExpPaymentOriginalNameEntity);
            }

            return lstExpPaymentOriginalNameEntity;
        }

        /// <summary>
        /// GetContributorOriginalAmount
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        public IList<ExpPaymentOriginalAmountEntity> GetContributorOriginalAmount(String strFilingEntityId)
        {
            IList<ExpPaymentOriginalAmountEntity> lstExpPaymentOriginalAmountEntity = new List<ExpPaymentOriginalAmountEntity>();
            ExpPaymentOriginalAmountEntity objExpPaymentOriginalAmountEntity;

            var results = entities.SP_S_ContributorOrginalAmount(strFilingEntityId);

            foreach (var item in results)
            {
                objExpPaymentOriginalAmountEntity = new ExpPaymentOriginalAmountEntity();
                objExpPaymentOriginalAmountEntity.TransNumber = item.TRANS_NUMBER;
                objExpPaymentOriginalAmountEntity.OriginalAmount = String.Format("{0:0.00}", item.ORG_AMT);
                lstExpPaymentOriginalAmountEntity.Add(objExpPaymentOriginalAmountEntity);
            }

            return lstExpPaymentOriginalAmountEntity;
        }

        /// <summary>
        /// GetContributorOriginalContributionDate
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<ExpPaymentOriginalExpenseDateEntity> GetContributorOriginalContributionDate(String strFilingTransId)
        {
            IList<ExpPaymentOriginalExpenseDateEntity> lstExpPaymentOriginalExpenseDateEntity = new List<ExpPaymentOriginalExpenseDateEntity>();
            ExpPaymentOriginalExpenseDateEntity objExpPaymentOriginalExpenseDateEntity;

            var results = entities.SP_S_ContributorOrginalContributionDate(strFilingTransId);

            foreach (var item in results)
            {
                objExpPaymentOriginalExpenseDateEntity = new ExpPaymentOriginalExpenseDateEntity();
                objExpPaymentOriginalExpenseDateEntity.TransNumber = item.TRANS_NUMBER;
                objExpPaymentOriginalExpenseDateEntity.OriginalExpenseDate = item.SCHED_DATE;
                lstExpPaymentOriginalExpenseDateEntity.Add(objExpPaymentOriginalExpenseDateEntity);
            }

            return lstExpPaymentOriginalExpenseDateEntity;
        }

        /// <summary>
        /// GetOutstaningAmtContrRefunded
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public String GetOutstaningAmtContrRefunded(String strTransNumber)
        {
            String strOutstaningExpRefundedAmt = String.Empty;

            var results = entities.SP_S_OutstandingAmtRefundedSchedM(strTransNumber);

            foreach (var item in results)
            {
                if (item != null)
                    strOutstaningExpRefundedAmt = String.Format("{0:0.00}", item.Value);
            }

            return strOutstaningExpRefundedAmt;
        }

        /// <summary>
        /// GetOriginalAmtRefundedSchedM
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<ExpPaymentOriginalAmountEntity> GetOriginalAmtRefundedSchedM(String strTransNumber)
        {
            IList<ExpPaymentOriginalAmountEntity> lstExpPaymentOriginalAmountEntity = new List<ExpPaymentOriginalAmountEntity>();
            ExpPaymentOriginalAmountEntity objExpPaymentOriginalAmountEntity;

            var results = entities.SP_S_OriginalAmtRefundedSchedM(strTransNumber);

            foreach (var item in results)
            {
                objExpPaymentOriginalAmountEntity = new ExpPaymentOriginalAmountEntity();
                objExpPaymentOriginalAmountEntity.TransNumber = item.TRANS_NUMBER;
                objExpPaymentOriginalAmountEntity.OriginalAmount = String.Format("{0:0.00}", item.ORG_AMT);
                lstExpPaymentOriginalAmountEntity.Add(objExpPaymentOriginalAmountEntity);
            }

            return lstExpPaymentOriginalAmountEntity;
        }

        /// <summary>
        /// AddContributionsRefundedSchedM
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean AddContributionsRefundedSchedM(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var result = entities.SP_I_FlngTransContributionsRefundedSchedM(objFilingTransactionsEntity.FilerId,
                    objFilingTransactionsEntity.ElectionDate,
                    objFilingTransactionsEntity.ElectionTypeId,
                    objFilingTransactionsEntity.OfficeTypeId,
                    objFilingTransactionsEntity.FilingTypeId,
                    objFilingTransactionsEntity.ElectYearId,
                    objFilingTransactionsEntity.ElectionYear,
                    objFilingTransactionsEntity.TransNumberOrg,
                    objFilingTransactionsEntity.FilingSchedId,
                    objFilingTransactionsEntity.SchedDate,
                    objFilingTransactionsEntity.FilingEntId,
                    objFilingTransactionsEntity.FlngEntName,
                    objFilingTransactionsEntity.FlngEntCountry,
                    objFilingTransactionsEntity.FlngEntStrName,
                    objFilingTransactionsEntity.FlngEntCity,
                    objFilingTransactionsEntity.FlngEntState,
                    objFilingTransactionsEntity.FlngEntZip,
                    objFilingTransactionsEntity.PaymentTypeId,
                    objFilingTransactionsEntity.PayNumber,
                    objFilingTransactionsEntity.OrgAmt,
                    objFilingTransactionsEntity.TransExplanation,
                    objFilingTransactionsEntity.ElectionDateId,
                    objFilingTransactionsEntity.ResigTermTypeId,
                    objFilingTransactionsEntity.FilingDate,
                    objFilingTransactionsEntity.CreatedBy);

            if (result >= 1)
                return true;
            else
                return false;

            //return true;
        }

        /// <summary>
        /// UpdateContributionsRefundedSchedM
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean UpdateContributionsRefundedSchedM(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var returnValue = entities.SP_U_FlngTransContributionsRefundedSchedM(objFilingTransactionsEntity.TransNumber,
                    objFilingTransactionsEntity.SchedDate,
                    objFilingTransactionsEntity.FilingEntId,
                    objFilingTransactionsEntity.FlngEntName,
                    objFilingTransactionsEntity.FlngEntCountry,
                    objFilingTransactionsEntity.FlngEntStrName,
                    objFilingTransactionsEntity.FlngEntCity,
                    objFilingTransactionsEntity.FlngEntState,
                    objFilingTransactionsEntity.FlngEntZip,
                    objFilingTransactionsEntity.PaymentTypeId,
                    objFilingTransactionsEntity.PayNumber,
                    objFilingTransactionsEntity.OrgAmt,
                    objFilingTransactionsEntity.TransExplanation,
                    objFilingTransactionsEntity.ModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// AddOutstandingLiabilitySchedN
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean AddOutstandingLiabilitySchedN(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var result = entities.SP_I_FlngTransOutstandingLiabilitySchedN(objFilingTransactionsEntity.FilerId,
                    objFilingTransactionsEntity.ElectionDate,
                    objFilingTransactionsEntity.ElectionTypeId,
                    objFilingTransactionsEntity.OfficeTypeId,
                    objFilingTransactionsEntity.FilingTypeId,
                    objFilingTransactionsEntity.ElectYearId,
                    objFilingTransactionsEntity.ElectionYear,
                    objFilingTransactionsEntity.FilingTransId,
                    objFilingTransactionsEntity.FilingSchedId,
                    objFilingTransactionsEntity.SchedDate,
                    objFilingTransactionsEntity.FilingEntId,
                    objFilingTransactionsEntity.FlngEntName,
                    objFilingTransactionsEntity.FlngEntStrName,
                    objFilingTransactionsEntity.FlngEntCity,
                    objFilingTransactionsEntity.FlngEntState,
                    objFilingTransactionsEntity.FlngEntZip,
                    objFilingTransactionsEntity.FlngEntCountry,
                    objFilingTransactionsEntity.PurposeCodeId,
                    objFilingTransactionsEntity.PaymentTypeId,
                    objFilingTransactionsEntity.PayNumber,
                    objFilingTransactionsEntity.OrgAmt,
                    objFilingTransactionsEntity.OwedAmt,
                    objFilingTransactionsEntity.TransExplanation,
                    objFilingTransactionsEntity.CreatedBy);

            if (result >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// UpdateOutstandingLiabilitySchedN
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean UpdateOutstandingLiabilitySchedN(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var returnValue = entities.SP_U_FlngTransOutstandingLiabilitySchedN(objFilingTransactionsEntity.FilingTransId,
                                                            objFilingTransactionsEntity.SchedDate,
                                                            objFilingTransactionsEntity.FilingEntId,
                                                            objFilingTransactionsEntity.FlngEntName,
                                                            objFilingTransactionsEntity.FlngEntStrName,
                                                            objFilingTransactionsEntity.FlngEntCity,
                                                            objFilingTransactionsEntity.FlngEntState,
                                                            objFilingTransactionsEntity.FlngEntZip,
                                                            objFilingTransactionsEntity.FlngEntCountry,
                                                            objFilingTransactionsEntity.PaymentTypeId,
                                                            objFilingTransactionsEntity.PurposeCodeId,
                                                            objFilingTransactionsEntity.PayNumber,
                                                            objFilingTransactionsEntity.OrgAmt,
                                                            objFilingTransactionsEntity.OwedAmt,
                                                            objFilingTransactionsEntity.TransExplanation,
                                                            objFilingTransactionsEntity.ModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// OutstandingLiabilityChildExists
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public String OutstandingLiabilityChildExists(String strFilingTransId)
        {
            String strExists = String.Empty;

            var results = entities.SP_S_OutstandingLiabilityExistsSchedN(strFilingTransId);

            foreach (var item in results)
            {
                strExists = item.RETURN_VALUE.ToString();
            }

            return strExists;
        }

        /// <summary>
        /// DeleteOutstandingLiabilitySchedN
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        public Boolean DeleteOutstandingLiabilitySchedN(String strFilingTransId, String strModifiedBy)
        {
            var returnValue = entities.SP_D_OutstandingLiabilitySchedN(strFilingTransId, strModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// GetEditTransactionData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataEntity> GetEditTransactionData(String strTransNumber)
        {
            IList<FilingTransactionDataEntity> lstFilingTransactionDataEntity = new List<FilingTransactionDataEntity>();
            FilingTransactionDataEntity objFilingTransactionDataEntity;

            var results = entities.SP_S_EditFilingTransactionData(strTransNumber);

            foreach (var item in results)
            {
                objFilingTransactionDataEntity = new FilingTransactionDataEntity();
                objFilingTransactionDataEntity.TransNumber = Convert.ToString(item.TRANS_NUMBER);
                objFilingTransactionDataEntity.LoanLiablityNumber = Convert.ToString(item.LOAN_LIB_NUMBER);
                objFilingTransactionDataEntity.FilingSchedId = Convert.ToString(item.FILING_SCHED_ID);
                objFilingTransactionDataEntity.ContributorTypeId = Convert.ToString(item.CNTRBR_TYPE_ID);
                objFilingTransactionDataEntity.ContributorTypeDesc = item.CNTRBR_TYPE_DESC;
                objFilingTransactionDataEntity.ContributionTypeId = Convert.ToString(item.CNTRBN_TYPE_ID);
                objFilingTransactionDataEntity.PaymentTypeId = Convert.ToString(item.PAYMENT_TYPE_ID);
                if (item.SCHED_DATE != "")
                    objFilingTransactionDataEntity.SchedDate = Convert.ToDateTime(item.SCHED_DATE).ToShortDateString();
                else
                    objFilingTransactionDataEntity.SchedDate = "";
                objFilingTransactionDataEntity.FilingSchedDesc = item.FILING_SCHED_DESC;
                objFilingTransactionDataEntity.FilingEntityId = item.FLNG_ENT_ID;
                objFilingTransactionDataEntity.FilingEntityName = item.FLNG_ENT_NAME;
                objFilingTransactionDataEntity.FilingFirstName = item.FLNG_ENT_FIRST_NAME;
                objFilingTransactionDataEntity.FilingMiddleName = item.FLNG_ENT_MIDDLE_NAME;
                objFilingTransactionDataEntity.FilingLastName = item.FLNG_ENT_LAST_NAME;
                objFilingTransactionDataEntity.FilingStreetNumber = item.FLNG_ENT_STR_NUM;
                objFilingTransactionDataEntity.FilingStreetName = item.FLNG_ENT_STR_NAME;
                objFilingTransactionDataEntity.FilingCity = item.FLNG_ENT_CITY;
                objFilingTransactionDataEntity.FilingState = item.FLNG_ENT_STATE;
                objFilingTransactionDataEntity.FilingZip = item.FLNG_ENT_ZIP;
                objFilingTransactionDataEntity.FilingCountry = item.FLNG_ENT_COUNTRY;
                objFilingTransactionDataEntity.PaymentTypeDesc = item.PAYMENT_TYPE_DESC;
                objFilingTransactionDataEntity.PayNumber = item.PAY_NUMBER;
                objFilingTransactionDataEntity.OriginalAmount = String.Format("{0:0.00}", item.ORG_AMT);
                objFilingTransactionDataEntity.ReceiptTypeDesc = item.RECEIPT_TYPE_ABBREV;
                objFilingTransactionDataEntity.TransferTypeDesc = item.TRANSFER_TYPE_ABBREV;
                objFilingTransactionDataEntity.ContributionTypeDesc = item.CNTRBN_TYPE_DESC;
                objFilingTransactionDataEntity.PurposeCodeDesc = item.PURPOSE_CODE_ABBREV;
                objFilingTransactionDataEntity.ReceiptCodeDesc = item.RECEIPT_CODE_DESC;
                objFilingTransactionDataEntity.ReceiptCodeId = item.RECEIPT_CODE_ID;
                objFilingTransactionDataEntity.RLiability = item.R_LIABILITY;
                objFilingTransactionDataEntity.RSubcontractor = item.R_SUBCONTRACTOR;
                if (item.ORG_DATE != "")
                    objFilingTransactionDataEntity.OriginalDate = Convert.ToDateTime(item.ORG_DATE).ToShortDateString();
                else
                    objFilingTransactionDataEntity.OriginalDate = "";
                objFilingTransactionDataEntity.LoanerCode = item.R_BANK_LOAN;
                objFilingTransactionDataEntity.ElectionYear = item.ELECTION_YEAR;
                objFilingTransactionDataEntity.Office = item.DIST_OFF_CAND_BAL_PROP;
                objFilingTransactionDataEntity.District = item.DIST_OFF_CAND_BAL_PROP;
                objFilingTransactionDataEntity.TransExplanation = item.TRANS_EXPLNTN;
                objFilingTransactionDataEntity.OwedAmount = String.Format("{0:0.00}", item.OWED_AMT);
                if (item.R_ITEMIZED == "" || item.R_ITEMIZED == null)
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "Y")
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "N")
                    objFilingTransactionDataEntity.RItemized = "No";
                objFilingTransactionDataEntity.LoanerCodeId = item.LOANER_CODE_ID.ToString();
                objFilingTransactionDataEntity.LoanerCode = item.LOAN_OTHER_DESC;
                lstFilingTransactionDataEntity.Add(objFilingTransactionDataEntity);
            }

            return lstFilingTransactionDataEntity;
        }

        /// <summary>
        /// GetOriginalAmountLiabData
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        public IList<OriginalAmountEntity> GetOutstandingAmountForForgiven(String strFilingTransId)
        {
            IList<OriginalAmountEntity> lstOriginalAmountContract = new List<OriginalAmountEntity>();
            OriginalAmountEntity objOriginalAmountContract;

            var results = entities.SP_S_GetOutstandingForLoanForgiven(strFilingTransId);

            foreach (var item in results)
            {
                objOriginalAmountContract = new OriginalAmountEntity();
                objOriginalAmountContract.OriginalAmountId = item.FILING_TRANS_ID.ToString();
                objOriginalAmountContract.OutstandingAmount = String.Format("{0:0.00}", item.OWED_AMT);
                lstOriginalAmountContract.Add(objOriginalAmountContract);
            }
            return lstOriginalAmountContract;
        }

        /// <summary>
        /// Get and Authenticate value from Temp CAPASFIDAS Database
        /// </summary>
        /// <param name="filerID"></param>
        /// <param name="roleID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public IList<ValidateFilerInfo> GetAuthenticateFilerInfo(String userID)
        {
            IList<ValidateFilerInfo> lstValidateFilerInfo = new List<ValidateFilerInfo>();
            ValidateFilerInfo objValidateFilerInfo;
            var results = authenticateEntites.SP_S_GetAuthorizedFiler(userID);

            foreach (var item in results)
            {
                objValidateFilerInfo = new ValidateFilerInfo();
                objValidateFilerInfo.FilerID = item.FILER_ID;
                objValidateFilerInfo.RoleID = item.ROLE_ID.ToString();
                lstValidateFilerInfo.Add(objValidateFilerInfo);
            }

            return lstValidateFilerInfo;
        }

        /// <summary>
        /// Add Amount Allocation Scheduled R
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean AddAmountAllocationSchedN(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var result = entities.SP_I_FilingTransaction_AmountAllocationScheR(objFilingTransactionsEntity.FilerId,
                    objFilingTransactionsEntity.FilingSchedId,
                    objFilingTransactionsEntity.SchedDate,
                    objFilingTransactionsEntity.FlngEntFirstName,
                    objFilingTransactionsEntity.FlngEntMiddleName,
                    objFilingTransactionsEntity.FlngEntLastName,
                    objFilingTransactionsEntity.OfficeTypeId,
                    objFilingTransactionsEntity.FilingTypeId,
                    objFilingTransactionsEntity.ElectionDate,
                    objFilingTransactionsEntity.ElectYearId,
                    objFilingTransactionsEntity.ElectionYear,
                    objFilingTransactionsEntity.MunicipalityID,
                    objFilingTransactionsEntity.OfficeID,
                    objFilingTransactionsEntity.DistrictID,
                    objFilingTransactionsEntity.OrgAmt,
                    objFilingTransactionsEntity.TransExplanation,
                    objFilingTransactionsEntity.FilingEntId,
                    objFilingTransactionsEntity.CreatedBy,
                    objFilingTransactionsEntity.ElectionTypeId,
                    objFilingTransactionsEntity.FilingDate,
                    objFilingTransactionsEntity.ElectionDateId,
                    objFilingTransactionsEntity.ResigTermTypeId);

            if (result >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Update Amount Allocation Sched R
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean UpdateAmountAllocationSchedN(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var returnValue = entities.SP_U_FilingTransaction_AmountAllocationScheR(objFilingTransactionsEntity.TransNumber,
                                                            objFilingTransactionsEntity.SchedDate,
                                                            objFilingTransactionsEntity.OrgAmt,
                                                            objFilingTransactionsEntity.TransExplanation,
                                                            objFilingTransactionsEntity.ModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Get All Amount for Amount Allocation Sched R
        /// </summary>
        /// <param name="filing_Ent_ID"></param>
        /// <param name="elect_Year"></param>
        /// <param name="municipalityID"></param>
        /// <param name="officeID"></param>
        /// <param name="distID"></param>
        /// <returns></returns>
        public String GetAllAmount(String filing_Ent_ID, String elect_Year, String municipalityID, String officeID, String distID)
        {
            String strAmount = String.Empty;

            var results = entities.SP_S_GetAllAmountAllocation(filing_Ent_ID, elect_Year, municipalityID, officeID, distID);

            foreach (var item in results)
            {
                strAmount = item.AMOUNT.ToString();
            }

            return strAmount;
        }

        public IList<DistrictEntity> GetDistrictsForOffice(String strOfficeID)
        {
            IList<DistrictEntity> listGetDistrictsEntity = new List<DistrictEntity>();
            DistrictEntity objGetDistrictsEntity;
            //data from stored procedure
            var results = entities.SP_S_District(Int32.Parse(strOfficeID));

            foreach (var item in results)
            {
                //create GetDistrictsEntity object
                objGetDistrictsEntity = new DistrictEntity();
                //modify object's attributes
                objGetDistrictsEntity.District_ID = Convert.ToString(item.DIST_ID);
                objGetDistrictsEntity.Parent_District_ID = Convert.ToString(item.PARENT_DISTRICT_ID);
                //add object to list
                listGetDistrictsEntity.Add(objGetDistrictsEntity);
            }
            return listGetDistrictsEntity;
        }

        public IList<OfficeEntity> GetOffices(String strMunicipalityID)
        {
            IList<OfficeEntity> listGetOfficeEntity = new List<OfficeEntity>();
            OfficeEntity objGetOfficeEntity;
            //data from stored procedure
            var results = entities.SP_S_OfficeForSchedR(strMunicipalityID);

            foreach (var item in results)
            {
                //create GetDistrictsEntity object
                objGetOfficeEntity = new OfficeEntity();
                //modify object's attributes
                objGetOfficeEntity.OfficeId = Convert.ToString(item.OFFICE_ID);
                objGetOfficeEntity.OfficeDesc = Convert.ToString(item.OFFICE_DESC);
                //add object to list
                listGetOfficeEntity.Add(objGetOfficeEntity);
            }
            return listGetOfficeEntity;
        }

        /// <summary>
        /// Auto Complete of Sched R
        /// </summary>
        /// <param name="name"></param>
        /// <param name="strFilerId"></param>
        /// <returns></returns>
        public IList<AutoCompleteSchedREntity> GetAutoCompleteSchedR(String name, String strFilerId)
        {
            IList<AutoCompleteSchedREntity> lstAutoCompleteSchedREntity = new List<AutoCompleteSchedREntity>();
            AutoCompleteSchedREntity objAutoCompleteSchedREntity;

            var results = entities.SP_S_AutoCompleteSchedR(name, strFilerId);

            foreach (var item in results)
            {
                objAutoCompleteSchedREntity = new AutoCompleteSchedREntity();
                objAutoCompleteSchedREntity.FilingEntityId = Convert.ToString(item.FLNG_ENT_ID);
                objAutoCompleteSchedREntity.EntityName = Convert.ToString(item.ENT_NAME);
                objAutoCompleteSchedREntity.Org_Amt = Convert.ToString(item.ORG_AMT);
                objAutoCompleteSchedREntity.FirstName = item.FLNG_ENT_FIRST_NAME;
                objAutoCompleteSchedREntity.MiddleName = item.FLNG_ENT_MIDDLE_NAME;
                objAutoCompleteSchedREntity.LastName = item.FLNG_ENT_LAST_NAME;
                objAutoCompleteSchedREntity.ElectionYear = item.ELECTION_YEAR;
                objAutoCompleteSchedREntity.Office_ID = Convert.ToString(item.OFFICE_ID);
                objAutoCompleteSchedREntity.Dist_ID = Convert.ToString(item.DIST_ID);
                lstAutoCompleteSchedREntity.Add(objAutoCompleteSchedREntity);
            }

            return lstAutoCompleteSchedREntity;
        }

        #region GetOriginalLiabilityData GET ORIGINAL SCHEDULE 'N' TRANSACTIONS.
        /// <summary>
        /// GetOriginalLiabilityData
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public IList<LiabilityDetailsEntity> GetOriginalLiabilityData(String strTransNumber)
        {
            IList<LiabilityDetailsEntity> lstLiabilityDetailsEntity = new List<LiabilityDetailsEntity>();
            LiabilityDetailsEntity objLiabilityDetailsEntity;

            var results = entities.SP_S_LiabilityOriginalSchedN(strTransNumber);

            foreach (var item in results)
            {
                objLiabilityDetailsEntity = new LiabilityDetailsEntity();
                objLiabilityDetailsEntity.FilingTransId= Convert.ToString(item.FILING_TRANS_ID);
                objLiabilityDetailsEntity.TransNumber = Convert.ToString(item.TRANS_NUMBER);                                
                objLiabilityDetailsEntity.ContributionType = item.CNTRBR_TYPE_DESC;                                
                if (item.SCHED_DATE != "")
                    objLiabilityDetailsEntity.TransactionDate = Convert.ToDateTime(item.SCHED_DATE).ToShortDateString();
                else
                    objLiabilityDetailsEntity.TransactionDate = "";
                objLiabilityDetailsEntity.TransactionType = item.FILING_SCHED_DESC;                
                objLiabilityDetailsEntity.FilingEntityName = item.FLNG_ENT_NAME;
                objLiabilityDetailsEntity.FilingFirstName = item.FLNG_ENT_FIRST_NAME;
                objLiabilityDetailsEntity.FilingMiddleName = item.FLNG_ENT_MIDDLE_NAME;
                objLiabilityDetailsEntity.FilingLastName = item.FLNG_ENT_LAST_NAME;                
                objLiabilityDetailsEntity.FilingStreetName = item.FLNG_ENT_STR_NAME;
                objLiabilityDetailsEntity.FilingCity = item.FLNG_ENT_CITY;
                objLiabilityDetailsEntity.FilingState = item.FLNG_ENT_STATE;
                objLiabilityDetailsEntity.FilingZip = item.FLNG_ENT_ZIP;
                objLiabilityDetailsEntity.FilingCountry = item.FLNG_ENT_COUNTRY;
                objLiabilityDetailsEntity.PaymentType = item.PAYMENT_TYPE_DESC;
                objLiabilityDetailsEntity.PayNumber = item.PAY_NUMBER;
                objLiabilityDetailsEntity.Amount = String.Format("{0:0.00}", item.ORG_AMT);
                objLiabilityDetailsEntity.OutstandingAmount = String.Format("{0:0.00}", item.OWED_AMT);
                objLiabilityDetailsEntity.RecieptType = item.RECEIPT_TYPE_ABBREV;
                objLiabilityDetailsEntity.TransferType = item.TRANSFER_TYPE_ABBREV;
                objLiabilityDetailsEntity.ContributionType = item.CNTRBN_TYPE_DESC;
                objLiabilityDetailsEntity.PurposeCode = item.PURPOSE_CODE_ABBREV;
                objLiabilityDetailsEntity.RecieptCdoe = item.RECEIPT_CODE_DESC;                                
                if (item.ORG_DATE != "")
                    objLiabilityDetailsEntity.OriginalDate = Convert.ToDateTime(item.ORG_DATE).ToShortDateString();
                else
                    objLiabilityDetailsEntity.OriginalDate = "";
                objLiabilityDetailsEntity.LoanerCode = item.LOAN_OTHER_DESC;
                objLiabilityDetailsEntity.ElectionYear = item.ELECTION_YEAR;
                if (item.OFFICE_ID != 0)
                    objLiabilityDetailsEntity.Office = Convert.ToString(item.OFFICE_ID);
                else
                    objLiabilityDetailsEntity.Office = "";
                objLiabilityDetailsEntity.District = Convert.ToString(item.DISTRICT);
                objLiabilityDetailsEntity.TransExplanation = item.TRANS_EXPLNTN;                                
                lstLiabilityDetailsEntity.Add(objLiabilityDetailsEntity);
            }

            return lstLiabilityDetailsEntity;
        }
        #endregion GetOriginalLiabilityData GET ORIGINAL SCHEDULE 'N' TRANSACTIONS.

        #region GetExpenditurePaymentLiabilityData GET EXPENDITURE PAYMENT SCHEDULE 'F' TRANSACTIONS.
        /// <summary>
        /// GetExpenditurePaymentLiabilityData
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public IList<LiabilityDetailsEntity> GetExpenditurePaymentLiabilityData(String strTransNumber)
        {
            IList<LiabilityDetailsEntity> lstLiabilityDetailsEntity = new List<LiabilityDetailsEntity>();
            LiabilityDetailsEntity objLiabilityDetailsEntity;

            var results = entities.SP_S_ExpPaymentLiabilitySchedF(strTransNumber);

            foreach (var item in results)
            {
                objLiabilityDetailsEntity = new LiabilityDetailsEntity();
                objLiabilityDetailsEntity.FilingTransId = Convert.ToString(item.FILING_TRANS_ID);
                objLiabilityDetailsEntity.TransNumber = Convert.ToString(item.TRANS_NUMBER);
                objLiabilityDetailsEntity.ContributionType = item.CNTRBR_TYPE_DESC;
                if (item.SCHED_DATE != "")
                    objLiabilityDetailsEntity.TransactionDate = Convert.ToDateTime(item.SCHED_DATE).ToShortDateString();
                else
                    objLiabilityDetailsEntity.TransactionDate = "";
                objLiabilityDetailsEntity.TransactionType = item.FILING_SCHED_DESC;
                objLiabilityDetailsEntity.FilingEntityName = item.FLNG_ENT_NAME;
                objLiabilityDetailsEntity.FilingFirstName = item.FLNG_ENT_FIRST_NAME;
                objLiabilityDetailsEntity.FilingMiddleName = item.FLNG_ENT_MIDDLE_NAME;
                objLiabilityDetailsEntity.FilingLastName = item.FLNG_ENT_LAST_NAME;
                objLiabilityDetailsEntity.FilingStreetName = item.FLNG_ENT_STR_NAME;
                objLiabilityDetailsEntity.FilingCity = item.FLNG_ENT_CITY;
                objLiabilityDetailsEntity.FilingState = item.FLNG_ENT_STATE;
                objLiabilityDetailsEntity.FilingZip = item.FLNG_ENT_ZIP;
                objLiabilityDetailsEntity.FilingCountry = item.FLNG_ENT_COUNTRY;
                objLiabilityDetailsEntity.PaymentType = item.PAYMENT_TYPE_DESC;
                objLiabilityDetailsEntity.PayNumber = item.PAY_NUMBER;
                objLiabilityDetailsEntity.Amount = String.Format("{0:0.00}", item.ORG_AMT);
                objLiabilityDetailsEntity.OutstandingAmount = String.Format("{0:0.00}", item.OWED_AMT);
                objLiabilityDetailsEntity.RecieptType = item.RECEIPT_TYPE_ABBREV;
                objLiabilityDetailsEntity.TransferType = item.TRANSFER_TYPE_ABBREV;
                objLiabilityDetailsEntity.ContributionType = item.CNTRBN_TYPE_DESC;
                objLiabilityDetailsEntity.PurposeCode = item.PURPOSE_CODE_ABBREV;
                objLiabilityDetailsEntity.RecieptCdoe = item.RECEIPT_CODE_DESC;
                if (item.ORG_DATE != "")
                    objLiabilityDetailsEntity.OriginalDate = Convert.ToDateTime(item.ORG_DATE).ToShortDateString();
                else
                    objLiabilityDetailsEntity.OriginalDate = "";
                objLiabilityDetailsEntity.LoanerCode = item.LOAN_OTHER_DESC;
                objLiabilityDetailsEntity.ElectionYear = item.ELECTION_YEAR;
                if (item.OFFICE_ID != 0)
                    objLiabilityDetailsEntity.Office = Convert.ToString(item.OFFICE_ID);
                else
                    objLiabilityDetailsEntity.Office = "";
                objLiabilityDetailsEntity.District = Convert.ToString(item.DISTRICT);
                objLiabilityDetailsEntity.TransExplanation = item.TRANS_EXPLNTN;
                lstLiabilityDetailsEntity.Add(objLiabilityDetailsEntity);
            }

            return lstLiabilityDetailsEntity;
        }
        #endregion GetExpenditurePaymentLiabilityData GET EXPENDITURE PAYMENT SCHEDULE 'F' TRANSACTIONS.

        #region GetOutstandingLiabilityData GET OUTSTANDING LIABILITY SCHEDULE 'N' TRANSACTIONS.
        /// <summary>
        /// GetOutstandingLiabilityData
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public IList<LiabilityDetailsEntity> GetOutstandingLiabilityData(String strTransNumber)
        {
            IList<LiabilityDetailsEntity> lstLiabilityDetailsEntity = new List<LiabilityDetailsEntity>();
            LiabilityDetailsEntity objLiabilityDetailsEntity;

            var results = entities.SP_S_ExpPayOutstandingLiabilitySchedN(strTransNumber);

            foreach (var item in results)
            {
                objLiabilityDetailsEntity = new LiabilityDetailsEntity();
                objLiabilityDetailsEntity.FilingTransId = Convert.ToString(item.FILING_TRANS_ID);
                objLiabilityDetailsEntity.TransNumber = Convert.ToString(item.TRANS_NUMBER);
                objLiabilityDetailsEntity.ContributionType = item.CNTRBR_TYPE_DESC;
                if (item.SCHED_DATE != "")
                    objLiabilityDetailsEntity.TransactionDate = Convert.ToDateTime(item.SCHED_DATE).ToShortDateString();
                else
                    objLiabilityDetailsEntity.TransactionDate = "";
                objLiabilityDetailsEntity.TransactionType = item.FILING_SCHED_DESC;
                objLiabilityDetailsEntity.FilingEntityName = item.FLNG_ENT_NAME;
                objLiabilityDetailsEntity.FilingFirstName = item.FLNG_ENT_FIRST_NAME;
                objLiabilityDetailsEntity.FilingMiddleName = item.FLNG_ENT_MIDDLE_NAME;
                objLiabilityDetailsEntity.FilingLastName = item.FLNG_ENT_LAST_NAME;
                objLiabilityDetailsEntity.FilingStreetName = item.FLNG_ENT_STR_NAME;
                objLiabilityDetailsEntity.FilingCity = item.FLNG_ENT_CITY;
                objLiabilityDetailsEntity.FilingState = item.FLNG_ENT_STATE;
                objLiabilityDetailsEntity.FilingZip = item.FLNG_ENT_ZIP;
                objLiabilityDetailsEntity.FilingCountry = item.FLNG_ENT_COUNTRY;
                objLiabilityDetailsEntity.PaymentType = item.PAYMENT_TYPE_DESC;
                objLiabilityDetailsEntity.PayNumber = item.PAY_NUMBER;
                objLiabilityDetailsEntity.Amount = String.Format("{0:0.00}", item.ORG_AMT);
                objLiabilityDetailsEntity.OutstandingAmount = String.Format("{0:0.00}", item.OWED_AMT);
                objLiabilityDetailsEntity.RecieptType = item.RECEIPT_TYPE_ABBREV;
                objLiabilityDetailsEntity.TransferType = item.TRANSFER_TYPE_ABBREV;
                objLiabilityDetailsEntity.ContributionType = item.CNTRBN_TYPE_DESC;
                objLiabilityDetailsEntity.PurposeCode = item.PURPOSE_CODE_ABBREV;
                objLiabilityDetailsEntity.RecieptCdoe = item.RECEIPT_CODE_DESC;
                if (item.ORG_DATE != "")
                    objLiabilityDetailsEntity.OriginalDate = Convert.ToDateTime(item.ORG_DATE).ToShortDateString();
                else
                    objLiabilityDetailsEntity.OriginalDate = "";
                objLiabilityDetailsEntity.LoanerCode = item.LOAN_OTHER_DESC;
                objLiabilityDetailsEntity.ElectionYear = item.ELECTION_YEAR;
                if (item.OFFICE_ID != 0)
                    objLiabilityDetailsEntity.Office = Convert.ToString(item.OFFICE_ID);
                else
                    objLiabilityDetailsEntity.Office = "";
                objLiabilityDetailsEntity.District = Convert.ToString(item.DISTRICT);
                objLiabilityDetailsEntity.TransExplanation = item.TRANS_EXPLNTN;
                lstLiabilityDetailsEntity.Add(objLiabilityDetailsEntity);
            }

            return lstLiabilityDetailsEntity;
        }
        #endregion GetOutstandingLiabilityData GET OUTSTANDING LIABILITY SCHEDULE 'N' TRANSACTIONS.

        #region GetLiabilityForgivenData GET LIABILITY FORGIVEN SCHEDULE 'K' TRANSACTIONS.
        /// <summary>
        /// GetLiabilityForgivenData
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public IList<LiabilityDetailsEntity> GetLiabilityForgivenData(String strTransNumber)
        {
            IList<LiabilityDetailsEntity> lstLiabilityDetailsEntity = new List<LiabilityDetailsEntity>();
            LiabilityDetailsEntity objLiabilityDetailsEntity;

            var results = entities.SP_S_ExpPayLiabilityForgivenSchedK(strTransNumber);

            foreach (var item in results)
            {
                objLiabilityDetailsEntity = new LiabilityDetailsEntity();
                objLiabilityDetailsEntity.FilingTransId = Convert.ToString(item.FILING_TRANS_ID);
                objLiabilityDetailsEntity.TransNumber = Convert.ToString(item.TRANS_NUMBER);
                objLiabilityDetailsEntity.ContributionType = item.CNTRBR_TYPE_DESC;
                if (item.SCHED_DATE != "")
                    objLiabilityDetailsEntity.TransactionDate = Convert.ToDateTime(item.SCHED_DATE).ToShortDateString();
                else
                    objLiabilityDetailsEntity.TransactionDate = "";
                objLiabilityDetailsEntity.TransactionType = item.FILING_SCHED_DESC;
                objLiabilityDetailsEntity.FilingEntityName = item.FLNG_ENT_NAME;
                objLiabilityDetailsEntity.FilingFirstName = item.FLNG_ENT_FIRST_NAME;
                objLiabilityDetailsEntity.FilingMiddleName = item.FLNG_ENT_MIDDLE_NAME;
                objLiabilityDetailsEntity.FilingLastName = item.FLNG_ENT_LAST_NAME;
                objLiabilityDetailsEntity.FilingStreetName = item.FLNG_ENT_STR_NAME;
                objLiabilityDetailsEntity.FilingCity = item.FLNG_ENT_CITY;
                objLiabilityDetailsEntity.FilingState = item.FLNG_ENT_STATE;
                objLiabilityDetailsEntity.FilingZip = item.FLNG_ENT_ZIP;
                objLiabilityDetailsEntity.FilingCountry = item.FLNG_ENT_COUNTRY;
                objLiabilityDetailsEntity.PaymentType = item.PAYMENT_TYPE_DESC;
                objLiabilityDetailsEntity.PayNumber = item.PAY_NUMBER;
                objLiabilityDetailsEntity.Amount = String.Format("{0:0.00}", item.ORG_AMT);
                objLiabilityDetailsEntity.OutstandingAmount = String.Format("{0:0.00}", item.OWED_AMT);
                objLiabilityDetailsEntity.RecieptType = item.RECEIPT_TYPE_ABBREV;
                objLiabilityDetailsEntity.TransferType = item.TRANSFER_TYPE_ABBREV;
                objLiabilityDetailsEntity.ContributionType = item.CNTRBN_TYPE_DESC;
                objLiabilityDetailsEntity.PurposeCode = item.PURPOSE_CODE_ABBREV;
                objLiabilityDetailsEntity.RecieptCdoe = item.RECEIPT_CODE_DESC;
                if (item.ORG_DATE != "")
                    objLiabilityDetailsEntity.OriginalDate = Convert.ToDateTime(item.ORG_DATE).ToShortDateString();
                else
                    objLiabilityDetailsEntity.OriginalDate = "";
                objLiabilityDetailsEntity.LoanerCode = item.LOAN_OTHER_DESC;
                objLiabilityDetailsEntity.ElectionYear = item.ELECTION_YEAR;
                if (item.OFFICE_ID != 0)
                    objLiabilityDetailsEntity.Office = Convert.ToString(item.OFFICE_ID);
                else
                    objLiabilityDetailsEntity.Office = "";
                objLiabilityDetailsEntity.District = Convert.ToString(item.DISTRICT);
                objLiabilityDetailsEntity.TransExplanation = item.TRANS_EXPLNTN;
                lstLiabilityDetailsEntity.Add(objLiabilityDetailsEntity);
            }

            return lstLiabilityDetailsEntity;
        }
        #endregion GetLiabilityForgivenData GET LIABILITY FORGIVEN SCHEDULE 'K' TRANSACTIONS.

        //========================================================================================================================================
        // NON-ITEMIZED TRANSACTIONS - SATART >>>>>>>>>>>>
        //========================================================================================================================================
        #region GetInLieuOfStatementData
        /// <summary>
        /// GetInLieuOfStatementData
        /// </summary>
        /// <param name="strElectionYearId"></param>
        /// <param name="strElectTypeId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <returns></returns>
        public IList<InLieuOfStatementNonItemEntity> GetInLieuOfStatementData(String strFilerid, String strElectionDate,
            String strElectionYearId, String strElectionYear, String strElectTypeId,
            String strOfficeTypeId, String strFilingTypeId)
        {
            IList<InLieuOfStatementNonItemEntity> lstInLieuOfStatementNonItemEntity = new List<InLieuOfStatementNonItemEntity>();
            InLieuOfStatementNonItemEntity objInLieuOfStatementNonItemEntity;

            var results = entities.SP_S_NonItemInLieuOfStatement(strFilerid, strElectionDate, strElectionYearId, strElectionYear,
                strElectTypeId, strOfficeTypeId, strFilingTypeId);

            foreach (var item in results)
            {
                objInLieuOfStatementNonItemEntity = new InLieuOfStatementNonItemEntity();
                objInLieuOfStatementNonItemEntity.FilingsId = Convert.ToString(item.FILINGS_ID);
                objInLieuOfStatementNonItemEntity.ElectionYear = Convert.ToString(item.ELECT_YEAR);
                objInLieuOfStatementNonItemEntity.OfficeType = item.OFFICE_TYPE_DESC;
                objInLieuOfStatementNonItemEntity.ElectionType = item.ELECT_TYPE_DESC;
                objInLieuOfStatementNonItemEntity.ElectionDate = item.ELECTION_DATE;
                objInLieuOfStatementNonItemEntity.DisclosurePeriod = item.FILING_DESC;
                objInLieuOfStatementNonItemEntity.DateSubmitted = Convert.ToString(item.CREATED_DATE);
                lstInLieuOfStatementNonItemEntity.Add(objInLieuOfStatementNonItemEntity);
            }

            return lstInLieuOfStatementNonItemEntity;

        }
        #endregion GetInLieuOfStatementData

        #region AddInLieuOfStatement
        /// <summary>
        /// AddInLieuOfStatement
        /// </summary>
        /// <param name="objAddInLieuOfStatementEntity"></param>
        /// <returns></returns>
        public Boolean AddInLieuOfStatement(AddInLieuOfStatementEntity objAddInLieuOfStatementEntity)
        {
            var results = entities.SP_I_NonItem_InLieuOfStatement(objAddInLieuOfStatementEntity.FilerId,
                objAddInLieuOfStatementEntity.ElectionDate,
                objAddInLieuOfStatementEntity.ElectionTypeId,
                objAddInLieuOfStatementEntity.OfficeTypeId,
                objAddInLieuOfStatementEntity.FilingTypeId,
                objAddInLieuOfStatementEntity.FilingCategoryId,
                objAddInLieuOfStatementEntity.ElectYearId,
                objAddInLieuOfStatementEntity.ElectionYear,
                objAddInLieuOfStatementEntity.CountyId,
                objAddInLieuOfStatementEntity.MunicipalityId,
                objAddInLieuOfStatementEntity.CreatedBy);

            if (results >= 1)
                return true;
            else
                return false;
        }
        #endregion AddInLieuOfStatement

        #region DeleteInLieuOfStatement
        /// <summary>
        /// DeleteInLieuOfStatement
        /// </summary>
        /// <param name="strFilingsId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        public Boolean DeleteInLieuOfStatement(String strFilingsId, String strModifiedBy)
        {
            var results = entities.SP_D_NonItemInLieuOfStatement(strFilingsId, strModifiedBy);

            if (results >= 1)
                return true;
            else
                return false;
        }
        #endregion DeleteInLieuOfStatement

        #region GetPersonNameAndTreasurerData
        /// <summary>
        /// GetPersonNameAndTreasurerData
        /// </summary>
        /// <param name="strPersonId"></param>
        /// <returns></returns>
        public IList<PersonNameAndTreasurerDataEntity> GetPersonNameAndTreasurerData(String strPersonId)
        {
            IList<PersonNameAndTreasurerDataEntity> lstPersonNameAndTreasurerDataEntity = new List<PersonNameAndTreasurerDataEntity>();
            PersonNameAndTreasurerDataEntity objPersonNameAndTreasurerDataEntity;

            var results = entities.SP_S_NonItemPersonName(strPersonId);

            foreach (var item in results)
            {
                objPersonNameAndTreasurerDataEntity = new PersonNameAndTreasurerDataEntity();
                objPersonNameAndTreasurerDataEntity.PersonName = item.PERSON_NAME;
                objPersonNameAndTreasurerDataEntity.TreasId = Convert.ToString(item.TREAS_ID);
                lstPersonNameAndTreasurerDataEntity.Add(objPersonNameAndTreasurerDataEntity);
            }

            return lstPersonNameAndTreasurerDataEntity;
        }
        #endregion GetPersonNameAndTreasurerData

        #region GetNoActivityReporttData
        /// <summary>
        /// GetNoActivityReporttData
        /// </summary>
        /// <param name="strFilerid"></param>
        /// <param name="strElectionDate"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strElectionYear"></param>
        /// <param name="strElectTypeId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <returns></returns>
        public IList<InLieuOfStatementNonItemEntity> GetNoActivityReporttData(String strFilerid, String strElectionDate,
            String strElectionYearId, String strElectionYear, String strElectTypeId,
            String strOfficeTypeId, String strFilingTypeId)
        {
            IList<InLieuOfStatementNonItemEntity> lstInLieuOfStatementNonItemEntity = new List<InLieuOfStatementNonItemEntity>();
            InLieuOfStatementNonItemEntity objInLieuOfStatementNonItemEntity;

            var results = entities.SP_S_NonItemNoActivityReport(strFilerid, strElectionDate, strElectionYearId, strElectionYear,
                strElectTypeId, strOfficeTypeId, strFilingTypeId);

            foreach (var item in results)
            {
                objInLieuOfStatementNonItemEntity = new InLieuOfStatementNonItemEntity();
                objInLieuOfStatementNonItemEntity.FilingsId = Convert.ToString(item.FILINGS_ID);
                objInLieuOfStatementNonItemEntity.ElectionYear = Convert.ToString(item.ELECT_YEAR);
                objInLieuOfStatementNonItemEntity.OfficeType = item.OFFICE_TYPE_DESC;
                objInLieuOfStatementNonItemEntity.ElectionType = item.ELECT_TYPE_DESC;
                objInLieuOfStatementNonItemEntity.ElectionDate = item.ELECTION_DATE;
                objInLieuOfStatementNonItemEntity.DisclosurePeriod = item.FILING_DESC;
                objInLieuOfStatementNonItemEntity.DateSubmitted = Convert.ToString(item.CREATED_DATE);
                lstInLieuOfStatementNonItemEntity.Add(objInLieuOfStatementNonItemEntity);
            }

            return lstInLieuOfStatementNonItemEntity;
        }
        #endregion GetNoActivityReporttData

        #region AddNoActivityReport
        /// <summary>
        /// AddNoActivityReport
        /// </summary>
        /// <param name="objAddInLieuOfStatementEntity"></param>
        /// <returns></returns>
        public Boolean AddNoActivityReport(AddInLieuOfStatementEntity objAddInLieuOfStatementEntity)
        {
            var results = entities.SP_I_NonItem_NoActivityReport(objAddInLieuOfStatementEntity.FilerId,
                objAddInLieuOfStatementEntity.ElectionDate,
                objAddInLieuOfStatementEntity.ElectionTypeId,
                objAddInLieuOfStatementEntity.OfficeTypeId,
                objAddInLieuOfStatementEntity.FilingTypeId,
                objAddInLieuOfStatementEntity.FilingCategoryId,
                objAddInLieuOfStatementEntity.ElectYearId,
                objAddInLieuOfStatementEntity.ElectionYear,
                objAddInLieuOfStatementEntity.CountyId,
                objAddInLieuOfStatementEntity.MunicipalityId,
                objAddInLieuOfStatementEntity.ResigTermTypeId,
                objAddInLieuOfStatementEntity.CreatedBy);

            if (results >= 1)
                return true;
            else
                return false;
        }
        #endregion AddNoActivityReport

        #region GetItemizedTransSubmitted
        /// <summary>
        /// GetItemizedTransSubmitted
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <returns></returns>
        public Boolean GetItemizedTransSubmitted(String strFilerId, String strElectionYearId, String strOfficeTypeId,
            String strFilingTypeId)
        {
            Boolean strSubmitted = false;

            var results = entities.SP_S_NonItemizedSubmittedItemizedOrNot(strFilerId, strElectionYearId,
                strOfficeTypeId, strFilingTypeId);

            foreach (var item in results)
            {
                if (item.RETURN_VALUE.ToString() == "TRUE")
                    strSubmitted = true;
                else
                    strSubmitted = false;
            }

            return strSubmitted;
        }
        #endregion GetItemizedTransSubmitted

        #region AddNoticeOfNonParticipation
        /// <summary>
        /// AddNoticeOfNonParticipation
        /// </summary>
        /// <param name="objAddInLieuOfStatementEntity"></param>
        /// <returns></returns>
        public Boolean AddNoticeOfNonParticipation(AddInLieuOfStatementEntity objAddInLieuOfStatementEntity)
        {
            var results = entities.SP_I_NonItem_NoticeOfNonParticipation(objAddInLieuOfStatementEntity.FilerId,
                objAddInLieuOfStatementEntity.ElectionDate,
                objAddInLieuOfStatementEntity.ElectionTypeId,
                objAddInLieuOfStatementEntity.OfficeTypeId,
                objAddInLieuOfStatementEntity.FilingTypeId,
                objAddInLieuOfStatementEntity.FilingCategoryId,
                objAddInLieuOfStatementEntity.ElectYearId,
                objAddInLieuOfStatementEntity.ElectionYear,
                objAddInLieuOfStatementEntity.CountyId,
                objAddInLieuOfStatementEntity.MunicipalityId,
                objAddInLieuOfStatementEntity.CreatedBy);

            if (results >= 1)
                return true;
            else
                return false;
        }
        #endregion AddNoticeOfNonParticipation

        #region GetNoticeOfNonParticipationtData
        /// <summary>
        /// GetNoticeOfNonParticipationtData
        /// </summary>
        /// <param name="strFilerid"></param>
        /// <param name="strElectionDate"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strElectionYear"></param>
        /// <param name="strElectTypeId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <returns></returns>
        public IList<InLieuOfStatementNonItemEntity> GetNoticeOfNonParticipationtData(String strFilerid, String strElectionDate,
            String strElectionYearId, String strElectionYear, String strElectTypeId,
            String strOfficeTypeId, String strFilingTypeId)
        {
            IList<InLieuOfStatementNonItemEntity> lstInLieuOfStatementNonItemEntity = new List<InLieuOfStatementNonItemEntity>();
            InLieuOfStatementNonItemEntity objInLieuOfStatementNonItemEntity;

            var results = entities.SP_S_NonItemNoticeOfNonParticipation(strFilerid, strElectionDate, strElectionYearId, strElectionYear,
                strElectTypeId, strOfficeTypeId, strFilingTypeId);

            foreach (var item in results)
            {
                objInLieuOfStatementNonItemEntity = new InLieuOfStatementNonItemEntity();
                objInLieuOfStatementNonItemEntity.FilingsId = Convert.ToString(item.FILINGS_ID);
                objInLieuOfStatementNonItemEntity.ElectionYear = Convert.ToString(item.ELECT_YEAR);
                objInLieuOfStatementNonItemEntity.OfficeType = item.OFFICE_TYPE_DESC;
                objInLieuOfStatementNonItemEntity.ElectionType = item.ELECT_TYPE_DESC;
                objInLieuOfStatementNonItemEntity.ElectionDate = item.ELECTION_DATE;
                objInLieuOfStatementNonItemEntity.DisclosurePeriod = item.FILING_DESC;
                objInLieuOfStatementNonItemEntity.DateSubmitted = Convert.ToString(item.CREATED_DATE);
                lstInLieuOfStatementNonItemEntity.Add(objInLieuOfStatementNonItemEntity);
            }

            return lstInLieuOfStatementNonItemEntity;
        }
        #endregion GetNoticeOfNonParticipationtData

        #region GetTransactionTypes24HNoticeData
        /// <summary>
        /// GetTransactionTypes24HNoticeData
        /// </summary>
        /// <returns></returns>
        public IList<TransactionTypesEntity> GetTransactionTypes24HNoticeData()
        {
            IList<TransactionTypesEntity> lstTransactionTypesEntity = new List<TransactionTypesEntity>();
            TransactionTypesEntity objTransactionTypesEntity;

            var results = entities.SP_S_TransactionTypes24HourNotice();

            foreach (var item in results)
            {
                objTransactionTypesEntity = new TransactionTypesEntity();
                objTransactionTypesEntity.FilingSchedId = Convert.ToString(item.FILING_SCHED_ID);
                objTransactionTypesEntity.FilingSchedDesc = item.FILING_SCHED_DESC;
                objTransactionTypesEntity.FilingSchedAbbrev = item.FILING_SCHED_ABBREV;
                lstTransactionTypesEntity.Add(objTransactionTypesEntity);
            }

            return lstTransactionTypesEntity;
        }
        #endregion GetTransactionTypes24HNoticeData

        #region GetFilingTrans24HourNoticeData
        /// <summary>
        /// GetFilingTrans24HourNoticeData
        /// </summary>
        /// <param name="objFilingTransDataEntity"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataEntity> GetFilingTrans24HourNoticeData(FilingTransDataEntity objFilingTransDataEntity)
        {
            IList<FilingTransactionDataEntity> lstFilingTransactionDataEntity = new List<FilingTransactionDataEntity>();
            FilingTransactionDataEntity objFilingTransactionDataEntity;

            var results = entities.SP_S_NonItem24HourNoticeTrans(objFilingTransDataEntity.FilerId,
                objFilingTransDataEntity.ReportYearId, objFilingTransDataEntity.OfficeTypeId,
                objFilingTransDataEntity.ElectionType, objFilingTransDataEntity.ElectionDateId);

            foreach (var item in results)
            {
                objFilingTransactionDataEntity = new FilingTransactionDataEntity();
                objFilingTransactionDataEntity.FilingTransId = Convert.ToString(item.FILING_TRANS_ID);
                objFilingTransactionDataEntity.FilingSchedId = Convert.ToString(item.FILING_SCHED_ID);
                objFilingTransactionDataEntity.ContributorTypeId = Convert.ToString(item.CNTRBR_TYPE_ID);
                objFilingTransactionDataEntity.ContributorTypeDesc = item.CNTRBR_TYPE_DESC;
                objFilingTransactionDataEntity.PaymentTypeId = Convert.ToString(item.PAYMENT_TYPE_ID);
                if (item.SUBMIT_DATE != "")
                {
                    if (Convert.ToDateTime(item.SUBMIT_DATE).ToShortDateString() == "1/1/1900")
                        objFilingTransactionDataEntity.SubmissionDate = "";
                    else
                        objFilingTransactionDataEntity.SubmissionDate = item.SUBMIT_DATE;
                }
                else
                {
                    objFilingTransactionDataEntity.SubmissionDate = "";
                }

                if (item.SCHED_DATE != "")
                    objFilingTransactionDataEntity.SchedDate = Convert.ToDateTime(item.SCHED_DATE).ToShortDateString();
                else
                    objFilingTransactionDataEntity.SchedDate = "";
                objFilingTransactionDataEntity.FilingSchedDesc = item.FILING_SCHED_DESC;
                objFilingTransactionDataEntity.FilingEntityId = item.FLNG_ENT_ID;
                objFilingTransactionDataEntity.FilingEntityName = item.FLNG_ENT_NAME;
                objFilingTransactionDataEntity.FilingFirstName = item.FLNG_ENT_FIRST_NAME;
                objFilingTransactionDataEntity.FilingMiddleName = item.FLNG_ENT_MIDDLE_NAME;
                objFilingTransactionDataEntity.FilingLastName = item.FLNG_ENT_LAST_NAME;
                objFilingTransactionDataEntity.FilingStreetNumber = item.FLNG_ENT_STR_NUM;
                objFilingTransactionDataEntity.FilingStreetName = item.FLNG_ENT_STR_NAME;
                objFilingTransactionDataEntity.FilingCity = item.FLNG_ENT_CITY;
                objFilingTransactionDataEntity.FilingState = item.FLNG_ENT_STATE;
                objFilingTransactionDataEntity.FilingZip = item.FLNG_ENT_ZIP;
                objFilingTransactionDataEntity.FilingCountry = item.FLNG_ENT_COUNTRY;
                objFilingTransactionDataEntity.PaymentTypeDesc = item.PAYMENT_TYPE_DESC;
                objFilingTransactionDataEntity.PayNumber = item.PAY_NUMBER;
                objFilingTransactionDataEntity.OriginalAmount = String.Format("{0:0.00}", item.ORG_AMT);
                objFilingTransactionDataEntity.TransExplanation = item.TRANS_EXPLNTN;
                if (item.R_ITEMIZED == "" || item.R_ITEMIZED == null)
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "Y")
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "N")
                    objFilingTransactionDataEntity.RItemized = "No";
                objFilingTransactionDataEntity.CountyDesc = Convert.ToString(item.CNTY_DESC);
                if (item.R_AMEND == "Y")
                {
                    objFilingTransactionDataEntity.RAmend = "Yes";
                }
                else if (item.R_AMEND == "N")
                {
                    objFilingTransactionDataEntity.RAmend = "No";
                }
                else
                {
                    objFilingTransactionDataEntity.RAmend = item.R_AMEND;
                }
                if (item.R_STATUS == "A")
                {
                    objFilingTransactionDataEntity.RStatus = "Active";
                }
                else if (item.R_STATUS == "I")
                {
                    objFilingTransactionDataEntity.RStatus = "In-Active";
                }
                else if (item.R_STATUS == "P")
                {
                    objFilingTransactionDataEntity.RStatus = "Pending";
                }
                else
                {
                    objFilingTransactionDataEntity.RStatus = item.R_STATUS;
                }
                objFilingTransactionDataEntity.MunicipalityDesc = Convert.ToString(item.MUNICIPALITY_DESC);
                objFilingTransactionDataEntity.LoanerCodeId = Convert.ToString(item.LOANER_CODE_ID);
                objFilingTransactionDataEntity.LoanerCode = Convert.ToString(item.LOANER_CODE);
                objFilingTransactionDataEntity.ContributionTypeId = item.CNTRBN_TYPE_ID;
                objFilingTransactionDataEntity.ContributionTypeDesc = item.CNTRBN_TYPE_DESC;
                objFilingTransactionDataEntity.CreatedDate = item.CREATED_DATE;
                objFilingTransactionDataEntity.LoanLiablityNumber = item.LOAN_LIB_NUMBER;
                objFilingTransactionDataEntity.TransNumber = item.TRANS_NUMBER;
                objFilingTransactionDataEntity.TransMapping = item.TRANS_MAPPING;
                lstFilingTransactionDataEntity.Add(objFilingTransactionDataEntity);
            }

            return lstFilingTransactionDataEntity;
        }
        #endregion GetFilingTrans24HourNoticeData

        #region GetFilingTrans24HourNoticeHistoryData
        /// <summary>
        /// GetFilingTrans24HourNoticeHistoryData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataEntity> GetFilingTrans24HourNoticeHistoryData(String strTransNumber)
        {
            IList<FilingTransactionDataEntity> lstFilingTransactionDataEntity = new List<FilingTransactionDataEntity>();
            FilingTransactionDataEntity objFilingTransactionDataEntity;

            var results = entities.SP_S_NonItem24HourNoticeTransHistory(strTransNumber);

            foreach (var item in results)
            {
                objFilingTransactionDataEntity = new FilingTransactionDataEntity();
                objFilingTransactionDataEntity.FilingTransId = Convert.ToString(item.FILING_TRANS_ID);
                objFilingTransactionDataEntity.FilingSchedId = Convert.ToString(item.FILING_SCHED_ID);
                objFilingTransactionDataEntity.ContributorTypeId = Convert.ToString(item.CNTRBR_TYPE_ID);
                objFilingTransactionDataEntity.ContributorTypeDesc = item.CNTRBR_TYPE_DESC;
                objFilingTransactionDataEntity.PaymentTypeId = Convert.ToString(item.PAYMENT_TYPE_ID);
                if (item.SUBMIT_DATE != "")
                {
                    if (Convert.ToDateTime(item.SUBMIT_DATE).ToShortDateString() == "1/1/1900")
                        objFilingTransactionDataEntity.SubmissionDate = "";
                    else
                        objFilingTransactionDataEntity.SubmissionDate = item.SUBMIT_DATE;
                }
                else
                {
                    objFilingTransactionDataEntity.SubmissionDate = "";
                }

                if (item.SCHED_DATE != "")
                    objFilingTransactionDataEntity.SchedDate = Convert.ToDateTime(item.SCHED_DATE).ToShortDateString();
                else
                    objFilingTransactionDataEntity.SchedDate = "";
                objFilingTransactionDataEntity.FilingSchedDesc = item.FILING_SCHED_DESC;
                objFilingTransactionDataEntity.FilingEntityId = item.FLNG_ENT_ID;
                objFilingTransactionDataEntity.FilingEntityName = item.FLNG_ENT_NAME;
                objFilingTransactionDataEntity.FilingFirstName = item.FLNG_ENT_FIRST_NAME;
                objFilingTransactionDataEntity.FilingMiddleName = item.FLNG_ENT_MIDDLE_NAME;
                objFilingTransactionDataEntity.FilingLastName = item.FLNG_ENT_LAST_NAME;
                objFilingTransactionDataEntity.FilingStreetNumber = item.FLNG_ENT_STR_NUM;
                objFilingTransactionDataEntity.FilingStreetName = item.FLNG_ENT_STR_NAME;
                objFilingTransactionDataEntity.FilingCity = item.FLNG_ENT_CITY;
                objFilingTransactionDataEntity.FilingState = item.FLNG_ENT_STATE;
                objFilingTransactionDataEntity.FilingZip = item.FLNG_ENT_ZIP;
                objFilingTransactionDataEntity.FilingCountry = item.FLNG_ENT_COUNTRY;
                objFilingTransactionDataEntity.PaymentTypeDesc = item.PAYMENT_TYPE_DESC;
                objFilingTransactionDataEntity.PayNumber = item.PAY_NUMBER;
                objFilingTransactionDataEntity.OriginalAmount = String.Format("{0:0.00}", item.ORG_AMT);
                objFilingTransactionDataEntity.TransExplanation = item.TRANS_EXPLNTN;
                if (item.R_ITEMIZED == "" || item.R_ITEMIZED == null)
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "Y")
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "N")
                    objFilingTransactionDataEntity.RItemized = "No";
                objFilingTransactionDataEntity.CountyDesc = Convert.ToString(item.CNTY_DESC);
                if (item.R_AMEND == "Y")
                {
                    objFilingTransactionDataEntity.RAmend = "Yes";
                }
                else if (item.R_AMEND == "N")
                {
                    objFilingTransactionDataEntity.RAmend = "No";
                }
                else
                {
                    objFilingTransactionDataEntity.RAmend = item.R_AMEND;
                }
                if (item.R_STATUS == "A")
                {
                    objFilingTransactionDataEntity.RStatus = "Active";
                }
                else if (item.R_STATUS == "I")
                {
                    objFilingTransactionDataEntity.RStatus = "In-Active";
                }
                else if (item.R_STATUS == "P")
                {
                    objFilingTransactionDataEntity.RStatus = "Pending";
                }
                else
                {
                    objFilingTransactionDataEntity.RStatus = item.R_STATUS;
                }
                objFilingTransactionDataEntity.MunicipalityDesc = Convert.ToString(item.MUNICIPALITY_DESC);
                objFilingTransactionDataEntity.LoanerCodeId = Convert.ToString(item.LOANER_CODE_ID);
                objFilingTransactionDataEntity.LoanerCode = Convert.ToString(item.LOANER_CODE);
                objFilingTransactionDataEntity.ContributionTypeId = item.CNTRBN_TYPE_ID;
                objFilingTransactionDataEntity.ContributionTypeDesc = item.CNTRBN_TYPE_DESC;
                objFilingTransactionDataEntity.CreatedDate = item.CREATED_DATE;
                objFilingTransactionDataEntity.LoanLiablityNumber = item.LOAN_LIB_NUMBER;
                objFilingTransactionDataEntity.TransNumber = item.TRANS_NUMBER;
                objFilingTransactionDataEntity.TransMapping = item.TRANS_MAPPING;
                lstFilingTransactionDataEntity.Add(objFilingTransactionDataEntity);
            }

            return lstFilingTransactionDataEntity;
        }
        #endregion GetFilingTrans24HourNoticeHistoryData

        #region AddNonItem24HourNoticeFlngTrans
        /// <summary>
        /// AddNonItem24HourNoticeFlngTrans
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean AddNonItem24HourNoticeFlngTrans(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var returnValue = entities.SP_I_NonItemized24HNoticeFlngTrans(objFilingTransactionsEntity.FilerId,
                        objFilingTransactionsEntity.FilingSchedId,
                        objFilingTransactionsEntity.SchedDate,
                        objFilingTransactionsEntity.PaymentTypeId,
                        objFilingTransactionsEntity.ContributorTypeId,
                        objFilingTransactionsEntity.ContributionTypeId,
                        objFilingTransactionsEntity.LoanOtherId,
                        objFilingTransactionsEntity.PayNumber,
                        objFilingTransactionsEntity.OrgAmt,
                        objFilingTransactionsEntity.TransExplanation,
                        objFilingTransactionsEntity.MunicipalityID,
                        objFilingTransactionsEntity.RAmend,
                        objFilingTransactionsEntity.ElectionDate,
                        objFilingTransactionsEntity.ElectionTypeId,
                        objFilingTransactionsEntity.OfficeTypeId,
                        objFilingTransactionsEntity.ElectYearId,
                        objFilingTransactionsEntity.ElectionYear,
                        objFilingTransactionsEntity.FilingEntId,
                        objFilingTransactionsEntity.FlngEntName,
                        objFilingTransactionsEntity.FlngEntFirstName,
                        objFilingTransactionsEntity.FlngEntLastName,
                        objFilingTransactionsEntity.FlngEntMiddleName,
                        objFilingTransactionsEntity.FlngEntStrName,
                        objFilingTransactionsEntity.FlngEntCity,
                        objFilingTransactionsEntity.FlngEntState,
                        objFilingTransactionsEntity.FlngEntZip,
                        objFilingTransactionsEntity.FlngEntCountry,
                        objFilingTransactionsEntity.ElectionDateId,
                        objFilingTransactionsEntity.FilingDate,
                        objFilingTransactionsEntity.CreatedBy);


            if (returnValue >= 1)
                return true;
            else
                return false;
        }
        #endregion AddNonItem24HourNoticeFlngTrans

        #region Update24HNoticeFlngTrans
        /// <summary>
        /// Update24HNoticeFlngTrans
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean Update24HNoticeFlngTrans(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var returnValue = entities.SP_U_NonItem24HNoticeFlngTrans(objFilingTransactionsEntity.TransNumber,
                    objFilingTransactionsEntity.FilingSchedId,
                    objFilingTransactionsEntity.ContributorTypeId,
                    objFilingTransactionsEntity.ContributionTypeId,
                    objFilingTransactionsEntity.FilingEntId,
                    objFilingTransactionsEntity.SubmissionDate,
                    objFilingTransactionsEntity.SchedDate,
                    objFilingTransactionsEntity.PayNumber,
                    objFilingTransactionsEntity.PaymentTypeId,
                    objFilingTransactionsEntity.OrgAmt,
                    objFilingTransactionsEntity.TransExplanation,
                    objFilingTransactionsEntity.FlngEntName,
                    objFilingTransactionsEntity.FlngEntFirstName,
                    objFilingTransactionsEntity.FlngEntMiddleName,
                    objFilingTransactionsEntity.FlngEntLastName,
                    objFilingTransactionsEntity.FlngEntCountry,
                    objFilingTransactionsEntity.FlngEntStrName,
                    objFilingTransactionsEntity.FlngEntCity,
                    objFilingTransactionsEntity.FlngEntState,
                    objFilingTransactionsEntity.FlngEntZip,
                    objFilingTransactionsEntity.ModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }
        #endregion Update24HNoticeFlngTrans

        #region Submit24HNoticeFlngTrans
        /// <summary>
        /// Submit24HNoticeFlngTrans
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean Submit24HNoticeFlngTrans(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var returnValue = entities.SP_U_NonItem24HNoticeFlngTransSubmit(objFilingTransactionsEntity.FilerId,
                    objFilingTransactionsEntity.FilingSchedId,
                    objFilingTransactionsEntity.ContributorTypeId,
                    objFilingTransactionsEntity.ContributionTypeId,
                    objFilingTransactionsEntity.TransNumber,
                    objFilingTransactionsEntity.FilingEntId,
                    objFilingTransactionsEntity.SchedDate,
                    objFilingTransactionsEntity.PayNumber,
                    objFilingTransactionsEntity.PaymentTypeId,
                    objFilingTransactionsEntity.OrgAmt,
                    objFilingTransactionsEntity.TransExplanation,
                    objFilingTransactionsEntity.ElectionDate,
                    objFilingTransactionsEntity.ElectionTypeId,
                    objFilingTransactionsEntity.OfficeTypeId,
                    objFilingTransactionsEntity.ElectYearId,
                    objFilingTransactionsEntity.ElectionYear,
                    objFilingTransactionsEntity.MunicipalityID,
                    objFilingTransactionsEntity.ElectionDateId,
                    objFilingTransactionsEntity.FilingDate,
                    objFilingTransactionsEntity.ModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }
        #endregion Submit24HNoticeFlngTrans

        #region Delete24HNoticeFlngTrans
        /// <summary>
        /// Delete24HNoticeFlngTrans
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        public Boolean Delete24HNoticeFlngTrans(String strTransNumber, String strModifiedBy)
        {
            var returnValue = entities.SP_D_NonItem24HourNoticeFlngTrans(strTransNumber, strModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }
        #endregion Delete24HNoticeFlngTrans

        #region GetNonItemChildTransExists
        /// <summary>
        /// GetNonItemChildTransExists
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public Boolean GetNonItemChildTransExists(String strTransNumber)
        {
            Boolean strChildTransExists = false;

            var results = entities.SP_S_NonItemizedChildTransExists(strTransNumber);

            foreach (var item in results)
            {
                if (item.RETURN_VALUE.ToString() == "TRUE")
                    strChildTransExists = true;
                else
                    strChildTransExists = false;
            }

            return strChildTransExists;
        }
        #endregion GetNonItemChildTransExists

        #region GetNonItemParentTransExists
        /// <summary>
        /// GetNonItemParentTransExists
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public Boolean GetNonItemParentTransExists(String strTransNumber)
        {
            Boolean strChildTransExists = false;

            var results = entities.SP_S_NonItemizedParentTransExists(strTransNumber);

            foreach (var item in results)
            {
                if (item.RETURN_VALUE.ToString() == "TRUE")
                    strChildTransExists = true;
                else
                    strChildTransExists = false;
            }

            return strChildTransExists;
        }
        #endregion GetNonItemParentTransExists

        #region GetCommEdit24HourNoticeTransData
        /// <summary>
        /// GetCommEdit24HourNoticeTransData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataEntity> GetCommEdit24HourNoticeTransData(String strTransNumber)
        {
            IList<FilingTransactionDataEntity> lstFilingTransactionDataEntity = new List<FilingTransactionDataEntity>();
            FilingTransactionDataEntity objFilingTransactionDataEntity;

            var results = entities.SP_S_NonItemized24HNoticeCommEditTrans(strTransNumber);

            foreach (var item in results)
            {
                objFilingTransactionDataEntity = new FilingTransactionDataEntity();
                objFilingTransactionDataEntity.FilingTransId = Convert.ToString(item.FILING_TRANS_ID);
                objFilingTransactionDataEntity.FilingSchedId = Convert.ToString(item.FILING_SCHED_ID);
                objFilingTransactionDataEntity.ContributorTypeId = Convert.ToString(item.CNTRBR_TYPE_ID);
                objFilingTransactionDataEntity.ContributorTypeDesc = item.CNTRBR_TYPE_DESC;
                objFilingTransactionDataEntity.PaymentTypeId = Convert.ToString(item.PAYMENT_TYPE_ID);
                if (item.SUBMIT_DATE != "")
                {
                    if (Convert.ToDateTime(item.SUBMIT_DATE).ToShortDateString() == "1/1/1900")
                        objFilingTransactionDataEntity.SubmissionDate = "";
                    else
                        objFilingTransactionDataEntity.SubmissionDate = item.SUBMIT_DATE;
                }
                else
                {
                    objFilingTransactionDataEntity.SubmissionDate = "";
                }

                if (item.SCHED_DATE != "")
                    objFilingTransactionDataEntity.SchedDate = Convert.ToDateTime(item.SCHED_DATE).ToShortDateString();
                else
                    objFilingTransactionDataEntity.SchedDate = "";
                objFilingTransactionDataEntity.FilingSchedDesc = item.FILING_SCHED_DESC;
                objFilingTransactionDataEntity.FilingEntityId = item.FLNG_ENT_ID;
                objFilingTransactionDataEntity.FilingEntityName = item.FLNG_ENT_NAME;
                objFilingTransactionDataEntity.FilingFirstName = item.FLNG_ENT_FIRST_NAME;
                objFilingTransactionDataEntity.FilingMiddleName = item.FLNG_ENT_MIDDLE_NAME;
                objFilingTransactionDataEntity.FilingLastName = item.FLNG_ENT_LAST_NAME;
                objFilingTransactionDataEntity.FilingStreetNumber = item.FLNG_ENT_STR_NUM;
                objFilingTransactionDataEntity.FilingStreetName = item.FLNG_ENT_STR_NAME;
                objFilingTransactionDataEntity.FilingCity = item.FLNG_ENT_CITY;
                objFilingTransactionDataEntity.FilingState = item.FLNG_ENT_STATE;
                objFilingTransactionDataEntity.FilingZip = item.FLNG_ENT_ZIP;
                objFilingTransactionDataEntity.FilingCountry = item.FLNG_ENT_COUNTRY;
                objFilingTransactionDataEntity.PaymentTypeDesc = item.PAYMENT_TYPE_DESC;
                objFilingTransactionDataEntity.PayNumber = item.PAY_NUMBER;
                objFilingTransactionDataEntity.OriginalAmount = String.Format("{0:0.00}", item.ORG_AMT);
                objFilingTransactionDataEntity.TransExplanation = item.TRANS_EXPLNTN;
                if (item.R_ITEMIZED == "" || item.R_ITEMIZED == null)
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "Y")
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "N")
                    objFilingTransactionDataEntity.RItemized = "No";
                //objFilingTransactionDataEntity.CountyDesc = Convert.ToString(item.CNTY_DESC);
                if (item.R_AMEND == "Y")
                {
                    objFilingTransactionDataEntity.RAmend = "Yes";
                }
                else if (item.R_AMEND == "N")
                {
                    objFilingTransactionDataEntity.RAmend = "No";
                }
                else
                {
                    objFilingTransactionDataEntity.RAmend = item.R_AMEND;
                }
                if (item.R_STATUS == "A")
                {
                    objFilingTransactionDataEntity.RStatus = "Active";
                }
                else if (item.R_STATUS == "I")
                {
                    objFilingTransactionDataEntity.RStatus = "In-Active";
                }
                else if (item.R_STATUS == "P")
                {
                    objFilingTransactionDataEntity.RStatus = "Pending";
                }
                else
                {
                    objFilingTransactionDataEntity.RStatus = item.R_STATUS;
                }
                //objFilingTransactionDataEntity.MunicipalityDesc = Convert.ToString(item.MUNICIPALITY_DESC);
                objFilingTransactionDataEntity.LoanerCodeId = Convert.ToString(item.LOANER_CODE_ID);
                objFilingTransactionDataEntity.LoanerCode = Convert.ToString(item.LOANER_CODE);
                objFilingTransactionDataEntity.LoanLiablityNumber = item.LOAN_LIB_NUMBER;
                objFilingTransactionDataEntity.TransNumber = item.TRANS_NUMBER;
                objFilingTransactionDataEntity.TransMapping = item.TRANS_MAPPING;
                lstFilingTransactionDataEntity.Add(objFilingTransactionDataEntity);
            }

            return lstFilingTransactionDataEntity;
        }
        #endregion GetCommEdit24HourNoticeTransData

        #region GetFilingTransIEWeeklyContributioneData
        /// <summary>
        /// GetFilingTransIEWeeklyContributioneData
        /// </summary>
        /// <param name="objFilingTransDataEntity"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataEntity> GetFilingTransIEWeeklyContributioneData(FilingTransDataEntity objFilingTransDataEntity)
        {
            IList<FilingTransactionDataEntity> lstFilingTransactionDataEntity = new List<FilingTransactionDataEntity>();
            FilingTransactionDataEntity objFilingTransactionDataEntity;

            var results = entities.SP_S_NonItemIEWeeklyContributionTrans(objFilingTransDataEntity.FilerId,
                objFilingTransDataEntity.ReportYearId, objFilingTransDataEntity.OfficeTypeId,
                objFilingTransDataEntity.ElectionType, objFilingTransDataEntity.ElectionDateId);

            foreach (var item in results)
            {
                objFilingTransactionDataEntity = new FilingTransactionDataEntity();
                objFilingTransactionDataEntity.FilingTransId = Convert.ToString(item.FILING_TRANS_ID);
                objFilingTransactionDataEntity.FilingSchedId = Convert.ToString(item.FILING_SCHED_ID);
                objFilingTransactionDataEntity.ContributorTypeId = Convert.ToString(item.CNTRBR_TYPE_ID);
                objFilingTransactionDataEntity.ContributorTypeDesc = item.CNTRBR_TYPE_DESC;
                objFilingTransactionDataEntity.PaymentTypeId = Convert.ToString(item.PAYMENT_TYPE_ID);
                if (item.SUBMIT_DATE != "")
                {
                    if (Convert.ToDateTime(item.SUBMIT_DATE).ToShortDateString() == "1/1/1900")
                        objFilingTransactionDataEntity.SubmissionDate = "";
                    else
                        objFilingTransactionDataEntity.SubmissionDate = item.SUBMIT_DATE;
                }
                else
                {
                    objFilingTransactionDataEntity.SubmissionDate = "";
                }

                if (item.SCHED_DATE != "")
                    objFilingTransactionDataEntity.SchedDate = Convert.ToDateTime(item.SCHED_DATE).ToShortDateString();
                else
                    objFilingTransactionDataEntity.SchedDate = "";
                objFilingTransactionDataEntity.FilingSchedDesc = item.FILING_SCHED_DESC;
                objFilingTransactionDataEntity.FilingEntityId = item.FLNG_ENT_ID;
                objFilingTransactionDataEntity.FilingEntityName = item.FLNG_ENT_NAME;
                objFilingTransactionDataEntity.FilingFirstName = item.FLNG_ENT_FIRST_NAME;
                objFilingTransactionDataEntity.FilingMiddleName = item.FLNG_ENT_MIDDLE_NAME;
                objFilingTransactionDataEntity.FilingLastName = item.FLNG_ENT_LAST_NAME;
                objFilingTransactionDataEntity.FilingStreetNumber = item.FLNG_ENT_STR_NUM;
                objFilingTransactionDataEntity.FilingStreetName = item.FLNG_ENT_STR_NAME;
                objFilingTransactionDataEntity.FilingCity = item.FLNG_ENT_CITY;
                objFilingTransactionDataEntity.FilingState = item.FLNG_ENT_STATE;
                objFilingTransactionDataEntity.FilingZip = item.FLNG_ENT_ZIP;
                objFilingTransactionDataEntity.FilingCountry = item.FLNG_ENT_COUNTRY;
                objFilingTransactionDataEntity.PaymentTypeDesc = item.PAYMENT_TYPE_DESC;
                objFilingTransactionDataEntity.PayNumber = item.PAY_NUMBER;
                objFilingTransactionDataEntity.OriginalAmount = String.Format("{0:0.00}", item.ORG_AMT);
                objFilingTransactionDataEntity.TransExplanation = item.TRANS_EXPLNTN;
                if (item.R_ITEMIZED == "" || item.R_ITEMIZED == null)
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "Y")
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "N")
                    objFilingTransactionDataEntity.RItemized = "No";
                objFilingTransactionDataEntity.CountyDesc = Convert.ToString(item.CNTY_DESC);
                if (item.R_AMEND == "Y")
                {
                    objFilingTransactionDataEntity.RAmend = "Yes";
                }
                else if (item.R_AMEND == "N")
                {
                    objFilingTransactionDataEntity.RAmend = "No";
                }
                else
                {
                    objFilingTransactionDataEntity.RAmend = item.R_AMEND;
                }
                if (item.R_STATUS == "A")
                {
                    objFilingTransactionDataEntity.RStatus = "Active";
                }
                else if (item.R_STATUS == "I")
                {
                    objFilingTransactionDataEntity.RStatus = "In-Active";
                }
                else if (item.R_STATUS == "P")
                {
                    objFilingTransactionDataEntity.RStatus = "Pending";
                }
                else
                {
                    objFilingTransactionDataEntity.RStatus = item.R_STATUS;
                }
                objFilingTransactionDataEntity.MunicipalityDesc = Convert.ToString(item.MUNICIPALITY_DESC);
                objFilingTransactionDataEntity.LoanerCodeId = Convert.ToString(item.LOANER_CODE_ID);
                objFilingTransactionDataEntity.LoanerCode = Convert.ToString(item.LOANER_CODE);
                objFilingTransactionDataEntity.ContributionTypeId = item.CNTRBN_TYPE_ID;
                objFilingTransactionDataEntity.ContributionTypeDesc = item.CNTRBN_TYPE_DESC;
                objFilingTransactionDataEntity.CreatedDate = item.CREATED_DATE;
                objFilingTransactionDataEntity.TreasurerFirstName = item.PERSON_FIRST_NAME;
                objFilingTransactionDataEntity.TreasurerLastName = item.PERSON_LAST_NAME;
                objFilingTransactionDataEntity.TreasurerMiddleName = item.PERSON_MIDDLE_NAME;
                objFilingTransactionDataEntity.TreasurerOccuptaion = item.TREAS_OCCUPATION;
                objFilingTransactionDataEntity.TreasurerEmployer = item.TREAS_EMPLOYER;
                objFilingTransactionDataEntity.TreasurerStreetAddress = item.ADDR_ADDR1;
                objFilingTransactionDataEntity.TreasurerCity = item.ADDR_CITY;
                objFilingTransactionDataEntity.TreasurerState = item.ADDR_STATE;
                objFilingTransactionDataEntity.TreasurerZip = item.ADDR_ZIP;
                objFilingTransactionDataEntity.ContributorOccupation = item.IE_CNTRBR_OCC;
                objFilingTransactionDataEntity.ContributorEmployer = item.IE_CNTRBR_EMP;
                objFilingTransactionDataEntity.IEDescription = item.IE_DESC;
                objFilingTransactionDataEntity.CandBallotPropReference = item.DIST_OFF_CAND_BAL_PROP;
                if (item.R_IE_SUPPORTED == "Y")
                    objFilingTransactionDataEntity.IESupported = "Yes";
                else
                    objFilingTransactionDataEntity.IESupported = "No";
                objFilingTransactionDataEntity.AddrId = item.ADDR_ID;
                objFilingTransactionDataEntity.TreasId = item.TREAS_ID;
                objFilingTransactionDataEntity.LoanLiablityNumber = item.LOAN_LIB_NUMBER;
                objFilingTransactionDataEntity.TransNumber = item.TRANS_NUMBER;
                objFilingTransactionDataEntity.TransMapping = item.TRANS_MAPPING;
                lstFilingTransactionDataEntity.Add(objFilingTransactionDataEntity);
            }

            return lstFilingTransactionDataEntity;
        }
        #endregion GetFilingTransIEWeeklyContributioneData

        #region GetIEWeeklyContrbutionTreasurerData
        /// <summary>
        /// GetIEWeeklyContrbutionTreasurerData
        /// </summary>
        /// <param name="strTreasurerId"></param>
        /// <returns></returns>
        public IList<NonItemIETreasurerData> GetIEWeeklyContrbutionTreasurerData(String strTreasurerId)
        {
            IList<NonItemIETreasurerData> lstNonItemIETreasurerData = new List<NonItemIETreasurerData>();
            NonItemIETreasurerData objNonItemIETreasurerData;

            var results = entities.SP_S_NonItemIEWeeklyCntrbTreasurerData(strTreasurerId);

            foreach (var item in results)
            {
                objNonItemIETreasurerData = new NonItemIETreasurerData();
                objNonItemIETreasurerData.AddressId = Convert.ToString(item.ADDR_ID);
                objNonItemIETreasurerData.PersonId = Convert.ToString(item.PERSON_ID);
                objNonItemIETreasurerData.TreasurerName = item.TREASURER_NAME;
                objNonItemIETreasurerData.TreasurerOccupation = item.TREAS_OCCUPATION;
                objNonItemIETreasurerData.TreasurerEmployer = item.TREAS_EMPLOYER;
                objNonItemIETreasurerData.TreasurerStreetAddress = item.ADDR_ADDR1;
                objNonItemIETreasurerData.TreasurerCity = item.ADDR_CITY;
                objNonItemIETreasurerData.TreasurerState = item.ADDR_STATE;
                objNonItemIETreasurerData.TreasurerZip = item.ADDR_ZIP;
                lstNonItemIETreasurerData.Add(objNonItemIETreasurerData);
            }

            return lstNonItemIETreasurerData;
        }
        #endregion GetIEWeeklyContrbutionTreasurerData

        #region AddNonItemIEWeeklyContrFlngTrans
        /// <summary>
        /// AddNonItemIEWeeklyContrFlngTrans
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean AddNonItemIEWeeklyContrFlngTrans(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var returnValue = entities.SP_I_NonItemizedIEWeeklyContrFlngTrans(objFilingTransactionsEntity.FilerId,
                        objFilingTransactionsEntity.PersonId,
                        objFilingTransactionsEntity.TreasId,
                        objFilingTransactionsEntity.AddrId,
                        objFilingTransactionsEntity.FilingSchedId,
                        objFilingTransactionsEntity.SchedDate,
                        objFilingTransactionsEntity.PaymentTypeId,
                        objFilingTransactionsEntity.ContributorTypeId,
                        objFilingTransactionsEntity.ContributionTypeId,
                        objFilingTransactionsEntity.LoanOtherId,
                        objFilingTransactionsEntity.PayNumber,
                        objFilingTransactionsEntity.OrgAmt,
                        objFilingTransactionsEntity.TransExplanation,
                        objFilingTransactionsEntity.MunicipalityID,
                        objFilingTransactionsEntity.RAmend,
                        objFilingTransactionsEntity.ElectionDate,
                        objFilingTransactionsEntity.ElectionDateId,
                        objFilingTransactionsEntity.ElectionTypeId,
                        objFilingTransactionsEntity.OfficeTypeId,
                        objFilingTransactionsEntity.ElectYearId,
                        objFilingTransactionsEntity.ElectionYear,
                        objFilingTransactionsEntity.FilingEntId,
                        objFilingTransactionsEntity.FlngEntName,
                        objFilingTransactionsEntity.FlngEntFirstName,
                        objFilingTransactionsEntity.FlngEntLastName,
                        objFilingTransactionsEntity.FlngEntMiddleName,
                        objFilingTransactionsEntity.FlngEntStrName,
                        objFilingTransactionsEntity.FlngEntCity,
                        objFilingTransactionsEntity.FlngEntState,
                        objFilingTransactionsEntity.FlngEntZip,
                        objFilingTransactionsEntity.FlngEntCountry,
                        objFilingTransactionsEntity.TreasurerOccupation,
                        objFilingTransactionsEntity.TreasurerEmployer,
                        objFilingTransactionsEntity.TreasurerStreetAddress,
                        objFilingTransactionsEntity.TreasurerCity,
                        objFilingTransactionsEntity.TreasurerState,
                        objFilingTransactionsEntity.TreasurerZip,
                        objFilingTransactionsEntity.CandBallotPropReference,
                        objFilingTransactionsEntity.ContributorOccupation,
                        objFilingTransactionsEntity.ContributorEmployer,
                        objFilingTransactionsEntity.IEDescription,
                        objFilingTransactionsEntity.R_Supported,
                        objFilingTransactionsEntity.CreatedBy,
                        objFilingTransactionsEntity.FilingDate);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }
        #endregion AddNonItemIEWeeklyContrFlngTrans

        #region UpdateIEWeeklyContrFlngTrans
        /// <summary>
        /// UpdateIEWeeklyContrFlngTrans
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean UpdateIEWeeklyContrFlngTrans(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var returnValue = entities.SP_U_NonItemizedIEWeeklyContrFlngTrans(objFilingTransactionsEntity.TransNumber,
                    objFilingTransactionsEntity.FilingSchedId,
                    objFilingTransactionsEntity.ContributorTypeId,
                    objFilingTransactionsEntity.ContributionTypeId,
                    objFilingTransactionsEntity.FilingEntId,
                    objFilingTransactionsEntity.TreasId,
                    objFilingTransactionsEntity.AddrId,
                    objFilingTransactionsEntity.PersonId,
                    objFilingTransactionsEntity.SubmissionDate,
                    objFilingTransactionsEntity.SchedDate,
                    objFilingTransactionsEntity.PayNumber,
                    objFilingTransactionsEntity.PaymentTypeId,
                    objFilingTransactionsEntity.OrgAmt,
                    objFilingTransactionsEntity.TransExplanation,
                    objFilingTransactionsEntity.FlngEntName,
                    objFilingTransactionsEntity.FlngEntFirstName,
                    objFilingTransactionsEntity.FlngEntMiddleName,
                    objFilingTransactionsEntity.FlngEntLastName,
                    objFilingTransactionsEntity.FlngEntCountry,
                    objFilingTransactionsEntity.FlngEntStrName,
                    objFilingTransactionsEntity.FlngEntCity,
                    objFilingTransactionsEntity.FlngEntState,
                    objFilingTransactionsEntity.FlngEntZip,
                    objFilingTransactionsEntity.TreasurerStreetAddress,
                    objFilingTransactionsEntity.TreasurerCity,
                    objFilingTransactionsEntity.TreasurerState,
                    objFilingTransactionsEntity.TreasurerZip,
                    objFilingTransactionsEntity.ContributorOccupation,
                    objFilingTransactionsEntity.ContributorEmployer,
                    objFilingTransactionsEntity.IEDescription,
                    objFilingTransactionsEntity.TreasurerOccupation,
                    objFilingTransactionsEntity.TreasurerEmployer,
                    objFilingTransactionsEntity.R_Supported,
                    objFilingTransactionsEntity.CandBallotPropReference,
                    objFilingTransactionsEntity.ModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }
        #endregion UpdateIEWeeklyContrFlngTrans

        #region SubmitIEWeeklyContrFlngTrans
        /// <summary>
        /// SubmitIEWeeklyContrFlngTrans
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        public Boolean SubmitIEWeeklyContrFlngTrans(String strTransNumber, String strModifiedBy)
        {
            var returnValue = entities.SP_U_NonItemizedIEWeeklyContrFlngTransSubmit(strTransNumber, strModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }
        #endregion SubmitIEWeeklyContrFlngTrans

        #region GetFilingTransIETransHistoryData
        /// <summary>
        /// GetFilingTransIETransHistoryData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataEntity> GetFilingTransIETransHistoryData(String strTransNumber)
        {
            IList<FilingTransactionDataEntity> lstFilingTransactionDataEntity = new List<FilingTransactionDataEntity>();
            FilingTransactionDataEntity objFilingTransactionDataEntity;

            var results = entities.SP_S_NonItemIEWeeklyContributionTransHistory(strTransNumber);

            foreach (var item in results)
            {
                objFilingTransactionDataEntity = new FilingTransactionDataEntity();
                objFilingTransactionDataEntity.FilingTransId = Convert.ToString(item.FILING_TRANS_ID);
                objFilingTransactionDataEntity.FilingSchedId = Convert.ToString(item.FILING_SCHED_ID);
                objFilingTransactionDataEntity.ContributorTypeId = Convert.ToString(item.CNTRBR_TYPE_ID);
                objFilingTransactionDataEntity.ContributorTypeDesc = item.CNTRBR_TYPE_DESC;
                objFilingTransactionDataEntity.PaymentTypeId = Convert.ToString(item.PAYMENT_TYPE_ID);
                if (item.SUBMIT_DATE != "")
                {
                    if (Convert.ToDateTime(item.SUBMIT_DATE).ToShortDateString() == "1/1/1900")
                        objFilingTransactionDataEntity.SubmissionDate = "";
                    else
                        objFilingTransactionDataEntity.SubmissionDate = item.SUBMIT_DATE;
                }
                else
                {
                    objFilingTransactionDataEntity.SubmissionDate = "";
                }

                if (item.SCHED_DATE != "")
                    objFilingTransactionDataEntity.SchedDate = Convert.ToDateTime(item.SCHED_DATE).ToShortDateString();
                else
                    objFilingTransactionDataEntity.SchedDate = "";
                objFilingTransactionDataEntity.FilingSchedDesc = item.FILING_SCHED_DESC;
                objFilingTransactionDataEntity.FilingEntityId = item.FLNG_ENT_ID;
                objFilingTransactionDataEntity.FilingEntityName = item.FLNG_ENT_NAME;
                objFilingTransactionDataEntity.FilingFirstName = item.FLNG_ENT_FIRST_NAME;
                objFilingTransactionDataEntity.FilingMiddleName = item.FLNG_ENT_MIDDLE_NAME;
                objFilingTransactionDataEntity.FilingLastName = item.FLNG_ENT_LAST_NAME;
                objFilingTransactionDataEntity.FilingStreetNumber = item.FLNG_ENT_STR_NUM;
                objFilingTransactionDataEntity.FilingStreetName = item.FLNG_ENT_STR_NAME;
                objFilingTransactionDataEntity.FilingCity = item.FLNG_ENT_CITY;
                objFilingTransactionDataEntity.FilingState = item.FLNG_ENT_STATE;
                objFilingTransactionDataEntity.FilingZip = item.FLNG_ENT_ZIP;
                objFilingTransactionDataEntity.FilingCountry = item.FLNG_ENT_COUNTRY;
                objFilingTransactionDataEntity.PaymentTypeDesc = item.PAYMENT_TYPE_DESC;
                objFilingTransactionDataEntity.PayNumber = item.PAY_NUMBER;
                objFilingTransactionDataEntity.OriginalAmount = String.Format("{0:0.00}", item.ORG_AMT);
                objFilingTransactionDataEntity.TransExplanation = item.TRANS_EXPLNTN;
                if (item.R_ITEMIZED == "" || item.R_ITEMIZED == null)
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "Y")
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "N")
                    objFilingTransactionDataEntity.RItemized = "No";
                objFilingTransactionDataEntity.CountyDesc = Convert.ToString(item.CNTY_DESC);
                if (item.R_AMEND == "Y")
                {
                    objFilingTransactionDataEntity.RAmend = "Yes";
                }
                else if (item.R_AMEND == "N")
                {
                    objFilingTransactionDataEntity.RAmend = "No";
                }
                else
                {
                    objFilingTransactionDataEntity.RAmend = item.R_AMEND;
                }
                if (item.R_STATUS == "A")
                {
                    objFilingTransactionDataEntity.RStatus = "Active";
                }
                else if (item.R_STATUS == "I")
                {
                    objFilingTransactionDataEntity.RStatus = "In-Active";
                }
                else if (item.R_STATUS == "P")
                {
                    objFilingTransactionDataEntity.RStatus = "Pending";
                }
                else
                {
                    objFilingTransactionDataEntity.RStatus = item.R_STATUS;
                }
                objFilingTransactionDataEntity.MunicipalityDesc = Convert.ToString(item.MUNICIPALITY_DESC);
                objFilingTransactionDataEntity.LoanerCodeId = Convert.ToString(item.LOANER_CODE_ID);
                objFilingTransactionDataEntity.LoanerCode = Convert.ToString(item.LOANER_CODE);
                objFilingTransactionDataEntity.ContributionTypeId = item.CNTRBN_TYPE_ID;
                objFilingTransactionDataEntity.ContributionTypeDesc = item.CNTRBN_TYPE_DESC;
                objFilingTransactionDataEntity.CreatedDate = item.CREATED_DATE;
                objFilingTransactionDataEntity.TreasurerFirstName = item.PERSON_FIRST_NAME;
                objFilingTransactionDataEntity.TreasurerLastName = item.PERSON_LAST_NAME;
                objFilingTransactionDataEntity.TreasurerMiddleName = item.PERSON_MIDDLE_NAME;
                objFilingTransactionDataEntity.TreasurerOccuptaion = item.TREAS_OCCUPATION;
                objFilingTransactionDataEntity.TreasurerEmployer = item.TREAS_EMPLOYER;
                objFilingTransactionDataEntity.TreasurerStreetAddress = item.ADDR_ADDR1;
                objFilingTransactionDataEntity.TreasurerCity = item.ADDR_CITY;
                objFilingTransactionDataEntity.TreasurerState = item.ADDR_STATE;
                objFilingTransactionDataEntity.TreasurerZip = item.ADDR_ZIP;
                objFilingTransactionDataEntity.ContributorOccupation = item.IE_CNTRBR_OCC;
                objFilingTransactionDataEntity.ContributorEmployer = item.IE_CNTRBR_EMP;
                objFilingTransactionDataEntity.CandBallotPropReference = item.DIST_OFF_CAND_BAL_PROP;
                objFilingTransactionDataEntity.IEDescription = item.IE_DESC;
                objFilingTransactionDataEntity.IESupported = item.R_IE_SUPPORTED;
                objFilingTransactionDataEntity.LoanLiablityNumber = item.LOAN_LIB_NUMBER;
                objFilingTransactionDataEntity.TransNumber = item.TRANS_NUMBER;
                objFilingTransactionDataEntity.TransMapping = item.TRANS_MAPPING;

                lstFilingTransactionDataEntity.Add(objFilingTransactionDataEntity);
            }

            return lstFilingTransactionDataEntity;
        }
        #endregion GetFilingTransIETransHistoryData

        #region GetItemizedNonItemIETransactions
        /// <summary>
        /// GetItemizedNonItemIETransactions
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strElectionDateId"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataEntity> GetItemizedNonItemIETransactions(String strFilerId, String strElectionYearId, String strOfficeTypeId, String strElectionTypeId, String strElectionDateId)
        {
            IList<FilingTransactionDataEntity> lstFilingTransactionDataEntity = new List<FilingTransactionDataEntity>();
            FilingTransactionDataEntity objFilingTransactionDataEntity;

            var results = entities.SP_S_ItemizedNonItemIETransactions(strFilerId, strElectionYearId, strOfficeTypeId, strElectionTypeId, strElectionDateId);

            foreach (var item in results)
            {
                objFilingTransactionDataEntity = new FilingTransactionDataEntity();
                objFilingTransactionDataEntity.FilingTransId = Convert.ToString(item.FILING_TRANS_ID);
                if (item.SCHED_DATE != "")
                    objFilingTransactionDataEntity.SchedDate = Convert.ToDateTime(item.SCHED_DATE).ToShortDateString();
                else
                    objFilingTransactionDataEntity.SchedDate = "";
                objFilingTransactionDataEntity.OriginalAmount = String.Format("{0:0.00}", item.ORG_AMT);
                objFilingTransactionDataEntity.IEDescription = item.IE_DESC;
                objFilingTransactionDataEntity.IEType = item.FILING_CAT_SUBTYPE;
                objFilingTransactionDataEntity.TreasurerName = item.TREASURER_NAME;
                objFilingTransactionDataEntity.ContributorName = item.CONTRIBUTOR_NAME;
                objFilingTransactionDataEntity.TreasurerCity = item.ADDR_CITY;
                objFilingTransactionDataEntity.TreasurerState = item.ADDR_STATE;
                objFilingTransactionDataEntity.CandBallotPropReference = item.DIST_OFF_CAND_BAL_PROP;
                objFilingTransactionDataEntity.TransExplanation = item.TRANS_EXPLNTN;
                objFilingTransactionDataEntity.CreatedDate = item.CREATED_DATE;
                objFilingTransactionDataEntity.LoanLiablityNumber = item.LOAN_LIB_NUMBER;
                objFilingTransactionDataEntity.TransNumber = item.TRANS_NUMBER;
                objFilingTransactionDataEntity.TransMapping = item.TRANS_MAPPING;
                lstFilingTransactionDataEntity.Add(objFilingTransactionDataEntity);
            }

            return lstFilingTransactionDataEntity;
        }
        #endregion GetItemizedNonItemIETransactions

        #region AddItemizedIETransactionsData
        /// <summary>
        /// AddItemizedIETransactionsData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strElectionDateId"></param>
        /// <param name="strCreatedBy"></param>
        /// <returns></returns>
        public Boolean AddItemizedIETransactionsData(IList<String> strTransNumber, String strFilerId, String strElectionYearId, String strOfficeTypeId, String strFilingTypeId, String strElectionTypeId, String strElectionDateId, String strCreatedBy, String strFilingDate)
        {
            IList<FilingTransactionDataEntity> lstFilingTransactionDataEntity = new List<FilingTransactionDataEntity>();
            FilingTransactionDataEntity objFilingTransactionDataEntity;

            IList<FILING_TRANSACTIONS> lstFILING_TRANSACTIONS = new List<FILING_TRANSACTIONS>();
            IList<FILING_TRANSACTIONS> lstFILING_TRANSACTIONS_SCHED_F = new List<FILING_TRANSACTIONS>();

            foreach (var item in strTransNumber)
            {
                // GET THE ITEMIZED IE TRANSACTIONS DATA.
                var results = entities.SP_S_ItemizedIETransactionsData(item, strFilerId, strElectionYearId, strOfficeTypeId, strFilingTypeId, strElectionTypeId, strElectionDateId, strCreatedBy, strFilingDate);

                foreach (var itemData in results)
                {
                    objFilingTransactionDataEntity = new FilingTransactionDataEntity();
                    objFilingTransactionDataEntity.TransNumber = Convert.ToString(itemData.TRANS_NUMBER);
                    objFilingTransactionDataEntity.FilingEntityId = Convert.ToString(itemData.FLNG_ENT_ID);
                    objFilingTransactionDataEntity.FilingsId = itemData.FILINGS_ID;
                    objFilingTransactionDataEntity.FilingSchedId = Convert.ToString(itemData.FILING_SCHED_ID);
                    objFilingTransactionDataEntity.ContributorTypeId = itemData.CNTRBR_TYPE_ID;
                    objFilingTransactionDataEntity.ContributionTypeId = itemData.CNTRBN_TYPE_ID;
                    objFilingTransactionDataEntity.PaymentTypeId = itemData.PAYMENT_TYPE_ID;
                    objFilingTransactionDataEntity.LoanerCodeId = itemData.LOAN_OTHER_ID;
                    objFilingTransactionDataEntity.PurposeCodeId = itemData.PURPOSE_CODE_ID;
                    objFilingTransactionDataEntity.SchedDate = itemData.SCHED_DATE.Trim();
                    objFilingTransactionDataEntity.PayNumber = itemData.PAY_NUMBER;
                    objFilingTransactionDataEntity.OriginalAmount = String.Format("{0:0.00}", itemData.ORG_AMT);
                    objFilingTransactionDataEntity.OwedAmount = String.Format("{0:0.00}", itemData.OWED_AMT);
                    objFilingTransactionDataEntity.LiabExistsOrigAmount = String.Format("{0:0.00}", itemData.LIAB_EXISTS_ORG_AMT);
                    objFilingTransactionDataEntity.LiabExistsTransId = itemData.EXISTS_LIAB_TRANS_NUMBER;
                    objFilingTransactionDataEntity.LoanLibNumberSchedN = itemData.EXISTS_LIAB_LOAN_LIB_NUMBER;
                    objFilingTransactionDataEntity.TransExplanation = itemData.TRANS_EXPLNTN;
                    objFilingTransactionDataEntity.RItemized = itemData.R_ITEMIZED;
                    objFilingTransactionDataEntity.IESupported = itemData.R_IE_SUPPORTED;
                    objFilingTransactionDataEntity.RSubcontractor = itemData.R_SUBCONTRACTOR;
                    objFilingTransactionDataEntity.RLiability = itemData.R_LIABILITY;
                    objFilingTransactionDataEntity.CreatedDate = itemData.CREATED_DATE;
                    objFilingTransactionDataEntity.LoanLiablityNumber = itemData.LOAN_LIB_NUMBER;
                    objFilingTransactionDataEntity.TransNumber = itemData.TRANS_NUMBER;
                    objFilingTransactionDataEntity.TransMapping = itemData.TRANS_MAPPING;
                    lstFilingTransactionDataEntity.Add(objFilingTransactionDataEntity);
                }
            }

            lstFilingTransactionDataEntity = lstFilingTransactionDataEntity.OrderBy(x => x.CreatedDate).ToList();

            // ADD ITEMIZED IE TRANSACTIONS DATA IN SELECTED DISCLOUSER PERIOD.                      
            foreach (var itemAddData in lstFilingTransactionDataEntity)
            {
                lstFILING_TRANSACTIONS_SCHED_F = new List<FILING_TRANSACTIONS>();

                if (itemAddData.FilingSchedId != "6") // NOT SCHEDULE 'F' - TRANSACTIONS.
                {
                    String strNewId = Guid.NewGuid().ToString().ToUpper();

                    FILING_TRANSACTIONS objAdd = new FILING_TRANSACTIONS
                    {
                        FLNG_ENT_ID = Convert.ToInt64(itemAddData.FilingEntityId),
                        TRANS_NUMBER = strNewId,
                        FILINGS_ID = Convert.ToInt64(itemAddData.FilingsId),
                        FILING_SCHED_ID = Convert.ToInt32(itemAddData.FilingSchedId),
                        CNTRBR_TYPE_ID = itemAddData.ContributorTypeId != "" ? Convert.ToInt32(itemAddData.ContributorTypeId) : (Int32?)null,
                        CNTRBN_TYPE_ID = itemAddData.ContributionTypeId != "" ? Convert.ToInt32(itemAddData.ContributionTypeId) : (Int32?)null,
                        PAYMENT_TYPE_ID = itemAddData.PaymentTypeId != "" ? Convert.ToInt32(itemAddData.PaymentTypeId) : (Int32?)null,
                        PURPOSE_CODE_ID = itemAddData.PurposeCodeId != "" ? Convert.ToInt32(itemAddData.PurposeCodeId) : (Int32?)null,
                        LOAN_OTHER_ID = itemAddData.LoanerCodeId != "" ? Convert.ToInt32(itemAddData.LoanerCodeId) : (Int32?)null,
                        SCHED_DATE = Convert.ToDateTime(itemAddData.SchedDate),
                        PAY_NUMBER = itemAddData.PayNumber,
                        ORG_AMT = Convert.ToDouble(itemAddData.OriginalAmount),
                        OWED_AMT = itemAddData.OwedAmount != "" ? Convert.ToDouble(itemAddData.OwedAmount) : (Double?)null,
                        TRANS_EXPLNTN = itemAddData.TransExplanation,
                        R_IE_SUPPORTED = itemAddData.IESupported,
                        R_ITEMIZED = itemAddData.RItemized,
                        R_STATUS = "A",
                        CREATED_BY = strCreatedBy,
                        CREATED_DATE = DateTime.Now
                    };

                    lstFILING_TRANSACTIONS.Add(objAdd);
                }
                else // SCHEDULE 'F' - EXPENDITURE PAYMENTS - TRANSACTIONS NON-ITEMIMZED IE - SCHEDULE 6
                {
                    // ITS SCHEDULE 'F' TRANSACTIONS WITH LIABILITY OR NOT.
                    // ELSE NOT LIABILITY TRANSACTIONS....ITS EITHER NORMAL SCHEDULE 'F' PAYMENT OR SUBCONTRACTOR PAYMENT.
                    if (itemAddData.RLiability == "Y")
                    {
                        // NOT EXISTING LIABILITY ITS NEW LIABILITY SO WILL CREATE...
                        // ORIGINAL TRANSACTION SCHEDULE 'N' AND WILL CREATE OUTSTANDING TRANSACTION SCHEUDLE 'N'...
                        // AND WILL CREATE EXPENDITURE PAYMENT TRANSACTION SCHEDULE 'F'....
                        // TOTAL WILL CREATE 3 TRANSACTION IN ITEMIZED TRANSACTIONS.
                        if (itemAddData.LiabExistsTransId == "") // NOT EXISTING LIABILIT ITS NEW LIABILITY
                        {
                            Double dblOriginalAmount = Convert.ToDouble(itemAddData.OriginalAmount) + Convert.ToDouble(itemAddData.OwedAmount);

                            String strLoanLibNumber = Guid.NewGuid().ToString().ToUpper();
                            String strTransNumberNewIdSchedNOrg = Guid.NewGuid().ToString().ToUpper();

                            // SCHEDULE - 'N' - ORIGINAL TRANSACTION
                            FILING_TRANSACTIONS objAddSchedN = new FILING_TRANSACTIONS
                            {
                                FLNG_ENT_ID = Convert.ToInt64(itemAddData.FilingEntityId),
                                LOAN_LIB_NUMBER = strLoanLibNumber,
                                TRANS_NUMBER = strTransNumberNewIdSchedNOrg,
                                FILINGS_ID = Convert.ToInt64(itemAddData.FilingsId),
                                FILING_SCHED_ID = 14, // ITS SCHEDULE F - EXPENDITURE PAYMENT
                                PAYMENT_TYPE_ID = Convert.ToInt32(itemAddData.PaymentTypeId),
                                PURPOSE_CODE_ID = Convert.ToInt32(itemAddData.PurposeCodeId),
                                SCHED_DATE = Convert.ToDateTime(itemAddData.SchedDate),
                                PAY_NUMBER = itemAddData.PayNumber,
                                ORG_AMT = dblOriginalAmount,
                                OWED_AMT = dblOriginalAmount,
                                TRANS_EXPLNTN = itemAddData.TransExplanation,
                                R_IE_SUPPORTED = itemAddData.IESupported,
                                R_SUBCONTRACTOR = itemAddData.RSubcontractor,
                                R_LIABILITY = itemAddData.RLiability,
                                R_ITEMIZED = itemAddData.RItemized,
                                R_STATUS = "A",
                                CREATED_BY = strCreatedBy,
                                CREATED_DATE = DateTime.Now
                            };

                            lstFILING_TRANSACTIONS_SCHED_F.Add(objAddSchedN);

                            String strTransNumberNewIdSchedF = Guid.NewGuid().ToString().ToUpper();

                            // SCHEDULE - 'F'
                            FILING_TRANSACTIONS objAdd = new FILING_TRANSACTIONS
                            {
                                FLNG_ENT_ID = Convert.ToInt64(itemAddData.FilingEntityId),
                                LOAN_LIB_NUMBER = strLoanLibNumber,
                                TRANS_NUMBER = strTransNumberNewIdSchedF,
                                TRANS_MAPPING = strTransNumberNewIdSchedNOrg,
                                FILINGS_ID = Convert.ToInt64(itemAddData.FilingsId),
                                FILING_SCHED_ID = Convert.ToInt32(itemAddData.FilingSchedId), // ITS SCHEDULE F - EXPENDITURE PAYMENT
                                PAYMENT_TYPE_ID = Convert.ToInt32(itemAddData.PaymentTypeId),
                                PURPOSE_CODE_ID = Convert.ToInt32(itemAddData.PurposeCodeId),
                                SCHED_DATE = Convert.ToDateTime(itemAddData.SchedDate),
                                PAY_NUMBER = itemAddData.PayNumber,
                                ORG_AMT = Convert.ToDouble(itemAddData.OriginalAmount),
                                TRANS_EXPLNTN = itemAddData.TransExplanation,
                                R_IE_SUPPORTED = itemAddData.IESupported,
                                R_SUBCONTRACTOR = itemAddData.RSubcontractor,
                                R_LIABILITY = itemAddData.RLiability,
                                R_ITEMIZED = itemAddData.RItemized,
                                R_STATUS = "A",
                                CREATED_BY = strCreatedBy,
                                CREATED_DATE = DateTime.Now
                            };

                            lstFILING_TRANSACTIONS_SCHED_F.Add(objAdd);

                            String strTransNumberNewIdSchedNOut = Guid.NewGuid().ToString().ToUpper();

                            // SCHEDULE - 'N' - OUTSTANDING TRANSACTION
                            FILING_TRANSACTIONS objAddSchedNOut = new FILING_TRANSACTIONS
                            {
                                FLNG_ENT_ID = Convert.ToInt64(itemAddData.FilingEntityId),
                                LOAN_LIB_NUMBER = strLoanLibNumber,
                                TRANS_NUMBER = strTransNumberNewIdSchedNOut,
                                TRANS_MAPPING = strTransNumberNewIdSchedF,
                                FILINGS_ID = Convert.ToInt64(itemAddData.FilingsId),
                                FILING_SCHED_ID = 14, // ITS SCHEDULE F - EXPENDITURE PAYMENT
                                PAYMENT_TYPE_ID = Convert.ToInt32(itemAddData.PaymentTypeId),
                                PURPOSE_CODE_ID = Convert.ToInt32(itemAddData.PurposeCodeId),
                                SCHED_DATE = Convert.ToDateTime(itemAddData.SchedDate),
                                PAY_NUMBER = itemAddData.PayNumber,
                                ORG_AMT = dblOriginalAmount,
                                OWED_AMT = Convert.ToDouble(itemAddData.OwedAmount),
                                TRANS_EXPLNTN = itemAddData.TransExplanation,
                                R_IE_SUPPORTED = itemAddData.IESupported,
                                R_SUBCONTRACTOR = itemAddData.RSubcontractor,
                                R_LIABILITY = itemAddData.RLiability,
                                R_ITEMIZED = itemAddData.RItemized,
                                R_STATUS = "A",
                                CREATED_BY = strCreatedBy,
                                CREATED_DATE = DateTime.Now
                            };

                            lstFILING_TRANSACTIONS_SCHED_F.Add(objAddSchedNOut);
                        }
                        // ITS EXISTING LIABILITY SO WILL CREATE EXPENDITURE PAYMENT SCHEDULE 'F' TRANSACTION...
                        // AND OUTSTANDING TRANSACTION SCHEDULE 'N'.. TOTAL 2 TRANSACTION IN ITEMIZED TRANSACTIONS.
                        else
                        {
                            String strTransNumberNewIdSchedF = Guid.NewGuid().ToString().ToUpper();
                            // SCHEDULE - 'F'
                            FILING_TRANSACTIONS objAdd = new FILING_TRANSACTIONS
                            {
                                FLNG_ENT_ID = Convert.ToInt64(itemAddData.FilingEntityId),
                                LOAN_LIB_NUMBER = itemAddData.LoanLibNumberSchedN,
                                TRANS_NUMBER = strTransNumberNewIdSchedF,
                                TRANS_MAPPING = itemAddData.LiabExistsTransId,
                                FILINGS_ID = Convert.ToInt64(itemAddData.FilingsId),
                                FILING_SCHED_ID = Convert.ToInt32(itemAddData.FilingSchedId), // ITS SCHEDULE F - EXPENDITURE PAYMENT
                                PAYMENT_TYPE_ID = Convert.ToInt32(itemAddData.PaymentTypeId),
                                PURPOSE_CODE_ID = Convert.ToInt32(itemAddData.PurposeCodeId),
                                SCHED_DATE = Convert.ToDateTime(itemAddData.SchedDate),
                                PAY_NUMBER = itemAddData.PayNumber,
                                ORG_AMT = Convert.ToDouble(itemAddData.OriginalAmount),
                                TRANS_EXPLNTN = itemAddData.TransExplanation,
                                R_IE_SUPPORTED = itemAddData.IESupported,
                                R_SUBCONTRACTOR = itemAddData.RSubcontractor,
                                R_LIABILITY = itemAddData.RLiability,
                                R_ITEMIZED = itemAddData.RItemized,
                                R_STATUS = "A",
                                CREATED_BY = strCreatedBy,
                                CREATED_DATE = DateTime.Now
                            };

                            lstFILING_TRANSACTIONS_SCHED_F.Add(objAdd);

                            String strTransNumberNewIdSchedNOut = Guid.NewGuid().ToString().ToUpper();

                            // SCHEDULE - 'N' - OUTSTANDING TRANSACTION
                            FILING_TRANSACTIONS objAddSchedNOut = new FILING_TRANSACTIONS
                            {
                                FLNG_ENT_ID = Convert.ToInt64(itemAddData.FilingEntityId),
                                LOAN_LIB_NUMBER = itemAddData.LoanLibNumberSchedN,
                                TRANS_NUMBER = strTransNumberNewIdSchedNOut,
                                TRANS_MAPPING = strTransNumberNewIdSchedF,
                                FILINGS_ID = Convert.ToInt64(itemAddData.FilingsId),
                                FILING_SCHED_ID = 14, // ITS SCHEDULE F - EXPENDITURE PAYMENT
                                PAYMENT_TYPE_ID = Convert.ToInt32(itemAddData.PaymentTypeId),
                                PURPOSE_CODE_ID = Convert.ToInt32(itemAddData.PurposeCodeId),
                                SCHED_DATE = Convert.ToDateTime(itemAddData.SchedDate),
                                PAY_NUMBER = itemAddData.PayNumber,
                                ORG_AMT = Convert.ToDouble(itemAddData.LiabExistsOrigAmount),
                                OWED_AMT = Convert.ToDouble(itemAddData.OwedAmount),
                                TRANS_EXPLNTN = itemAddData.TransExplanation,
                                //EXISTS_LIAB_TRANS_NUMBER = itemAddData.LiabExistsTransId,
                                R_IE_SUPPORTED = itemAddData.IESupported,
                                R_SUBCONTRACTOR = itemAddData.RSubcontractor,
                                R_LIABILITY = itemAddData.RLiability,
                                R_ITEMIZED = itemAddData.RItemized,
                                R_STATUS = "A",
                                CREATED_BY = strCreatedBy,
                                CREATED_DATE = DateTime.Now
                            };

                            lstFILING_TRANSACTIONS_SCHED_F.Add(objAddSchedNOut);
                        }
                    }
                    else // ITS NOT LIABILITY TRANSACTIONS....ITS EITHER NORMAL SCHEDULE 'F' PAYMENT OR SUBCONTRACTOR PAYMENT.
                    {
                        String strTransNumberNewIdAll = Guid.NewGuid().ToString().ToUpper();

                        FILING_TRANSACTIONS objAdd = new FILING_TRANSACTIONS
                        {
                            FLNG_ENT_ID = Convert.ToInt64(itemAddData.FilingEntityId),
                            TRANS_NUMBER = strTransNumberNewIdAll,
                            FILINGS_ID = Convert.ToInt64(itemAddData.FilingsId),
                            FILING_SCHED_ID = Convert.ToInt32(itemAddData.FilingSchedId),
                            PAYMENT_TYPE_ID = Convert.ToInt32(itemAddData.PaymentTypeId),
                            PURPOSE_CODE_ID = Convert.ToInt32(itemAddData.PurposeCodeId),
                            SCHED_DATE = Convert.ToDateTime(itemAddData.SchedDate),
                            PAY_NUMBER = itemAddData.PayNumber,
                            ORG_AMT = Convert.ToDouble(itemAddData.OriginalAmount),
                            TRANS_EXPLNTN = itemAddData.TransExplanation,
                            R_IE_SUPPORTED = itemAddData.IESupported,
                            R_SUBCONTRACTOR = itemAddData.RSubcontractor,
                            R_LIABILITY = itemAddData.RLiability,
                            R_ITEMIZED = itemAddData.RItemized,
                            R_STATUS = "A",
                            CREATED_BY = strCreatedBy,
                            CREATED_DATE = DateTime.Now
                        };

                        lstFILING_TRANSACTIONS.Add(objAdd);
                    }
                }

                if (lstFILING_TRANSACTIONS_SCHED_F.Count() >= 1)
                {
                    using (var context = new CAPASFIDASTEMPDBEntities())
                    {
                        using (var dbContextTransaction = context.Database.BeginTransaction())
                        {
                            try
                            {
                                // HAVE TO WORK ON THESE MAPPING BECUASE THE FILING_TRANSACTION_MAPPING TABLE GOT DELETED
                                // ... WE ARE NOT USING MAPPING TABLE SO HAVE TO LOOK INTO THIS.
                                //++++++++++================++++++++++++++++++++++
                                //++++++++++================++++++++++++++++++++++
                                //++++++++++================++++++++++++++++++++++

                                //IList<FILING_TRANSACTIONS_MAPPING> lstFILING_TRANSACTIONS_MAPPING = new List<FILING_TRANSACTIONS_MAPPING>();
                                using (var dbAdd = new CAPASFIDASTEMPDBEntities())
                                {
                                    // INSERT
                                    dbAdd.FILING_TRANSACTIONS.AddRange(lstFILING_TRANSACTIONS_SCHED_F);
                                    dbAdd.SaveChanges();
                                }

                                //String filingTransIdSchedF = String.Empty;
                                //String filingTransIdOrgLiab = String.Empty;
                                //String filingTransIdOutstandingLib = String.Empty;

                                //// IF ANY SCHEDULE 'F' TRANSACTIONS THEN IF ITS LIABILITY WE HAVE TO ADD OUTSTANDING RECORDS.
                                //// IF SCHEDULE 'F' NON-ITEMIZED TRANSACTIONS WITH NEW LIABILITY THEN...
                                //// WE HAVE TO ADD 1 SCHEUDLE 'N' ORGINAL TRANSACTION AND 1 OUTSTANDING SCHEDULE 'N' TRANSACTION
                                //// IF SCHEDULE 'F' NON-ITEMIZED TRANSACTIONS WITH EXISTING LIABILITY THEN...
                                //// WE HAVE TO ADD 1 SCHEDULE 'N' OUTSTANDING TRANSACTIONS.
                                //// WITH EITHER NEW LIABILITY OR EXISTING LIABILITY WE HAVE TO ADD SCHEDULE 'F' EXPENDITURE PAYMENT TRANSACTIONS.
                                //foreach (var itemReturnValues in lstFILING_TRANSACTIONS_SCHED_F)
                                //{
                                //    if (itemReturnValues.FILING_SCHED_ID == 6 || itemReturnValues.FILING_SCHED_ID == 14)
                                //    {
                                //        if (itemReturnValues.FILING_SCHED_ID == 6) // SCHEDULE 'F' - EXPENDITURE PAYMENT TRANSACTION
                                //        {
                                //            filingTransIdSchedF = Convert.ToString(itemReturnValues.FILING_TRANS_ID);
                                //        }
                                //        else if (itemReturnValues.FILING_SCHED_ID == 14) // OUTSTANDING LIABILITY TRANSACTIONS
                                //        {
                                //            if (itemReturnValues.ORG_AMT == itemReturnValues.OWED_AMT) // ORIGINAL SCHEDULE 'N' TRANSACTION
                                //            {
                                //                filingTransIdOrgLiab = Convert.ToString(itemReturnValues.FILING_TRANS_ID);
                                //            }
                                //            else // OUTSTANDING LIABILITY TRANSACTIONS SCHEDULE 'N'
                                //            {
                                //                filingTransIdOutstandingLib = Convert.ToString(itemReturnValues.FILING_TRANS_ID);
                                //                if (itemReturnValues.EXISTS_LIAB_TRANS_NUMBER != null)
                                //                    filingTransIdOrgLiab = Convert.ToString(itemReturnValues.EXISTS_LIAB_TRANS_NUMBER);
                                //            }
                                //        }
                                //    }
                                //}

                                // HAVE TO WORK ON THESE MAPPING BECUASE THE FILING_TRANSACTION_MAPPING TABLE GOT DELETED
                                // ... WE ARE NOT USING MAPPING TABLE SO HAVE TO LOOK INTO THIS.
                                //++++++++++================++++++++++++++++++++++
                                //++++++++++================++++++++++++++++++++++
                                //++++++++++================++++++++++++++++++++++

                                //// ADD TRANSACTION OBJECT FOR FILING_TRANSACTION_MAPPING TABLE.
                                //FILING_TRANSACTIONS_MAPPING objAddLiabMapOrgLiabAndSchedF = new FILING_TRANSACTIONS_MAPPING()
                                //{
                                //    FILING_TRANS_ID = Convert.ToInt64(filingTransIdSchedF),
                                //    FILING_TRANS_MAPPING = Convert.ToInt64(filingTransIdOrgLiab),
                                //    R_STATUS = "A",
                                //    CREATED_BY = strCreatedBy,
                                //    CREATED_DATE = DateTime.Now
                                //};
                                //lstFILING_TRANSACTIONS_MAPPING.Add(objAddLiabMapOrgLiabAndSchedF);

                                //// ADD TRANSACTION OBJECT FOR FILING_TRANSACTION_MAPPING TABLE.
                                //FILING_TRANSACTIONS_MAPPING objAddLiabMapOutLiabAndSchedF = new FILING_TRANSACTIONS_MAPPING()
                                //{
                                //    FILING_TRANS_ID = Convert.ToInt64(filingTransIdOutstandingLib),
                                //    FILING_TRANS_MAPPING = Convert.ToInt64(filingTransIdSchedF),
                                //    R_STATUS = "A",
                                //    CREATED_BY = strCreatedBy,
                                //    CREATED_DATE = DateTime.Now
                                //};
                                //lstFILING_TRANSACTIONS_MAPPING.Add(objAddLiabMapOutLiabAndSchedF);


                                //if (lstFILING_TRANSACTIONS_MAPPING.Count() >= 1)
                                //{
                                //    using (var dbAddMapping = new EFSEntities())
                                //    {
                                //        // INSERT MAPPING TRANSACTIONS FOR SCHEDULE 'F' EXPENDITURE PAYMENTS AND OUTSTANDING LIABILITY.
                                //        dbAddMapping.FILING_TRANSACTIONS_MAPPING.AddRange(lstFILING_TRANSACTIONS_MAPPING);
                                //        dbAddMapping.SaveChanges();

                                //        //dbContextTransaction.Commit();
                                //    }
                                //}

                                // HAVE TO WORK ON THESE MAPPING BECUASE THE FILING_TRANSACTION_MAPPING TABLE GOT DELETED
                                // ... WE ARE NOT USING MAPPING TABLE SO HAVE TO LOOK INTO THIS.
                                //++++++++++================++++++++++++++++++++++
                                //++++++++++================++++++++++++++++++++++
                                //++++++++++================++++++++++++++++++++++

                                // COMMIT TRANSACTIONS. IF NO ERRORS.
                                dbContextTransaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                dbContextTransaction.Rollback();
                                return false;
                                throw;
                            }
                        }
                    }
                }
            }
            
            using (var context = new CAPASFIDASTEMPDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        using (var dbAdd = new CAPASFIDASTEMPDBEntities())
                        {
                            // INSERT
                            dbAdd.FILING_TRANSACTIONS.AddRange(lstFILING_TRANSACTIONS);
                            dbAdd.SaveChanges();
                        }

                        Boolean resultValue = false;
                        //UPDATE
                        foreach (var itemUpdateData in strTransNumber)
                        {                                                  
                            var results = entities.SP_U_ItemizedIETransUpdate(itemUpdateData.ToString(), strCreatedBy);

                            if (results >= 1)
                                resultValue = true;
                            else
                                resultValue = false;
                        }

                        // COMMIT TRANSACTIONS. IF NO ERRORS.
                        dbContextTransaction.Commit();

                        if (resultValue)
                            return true;
                        else
                            return false;
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        return false;
                        throw;
                    }
                }
            }
        }
        #endregion AddItemizedIETransactionsData

        #region GetContributorCodeIEWeeklyContrSchedC
        /// <summary>
        /// /GetContributorCodeIEWeeklyContrSchedC
        /// </summary>
        /// <returns></returns>
        public IList<ContributorNameEntity> GetContributorCodeIEWeeklyContrSchedC()
        {
            IList<ContributorNameEntity> lstContributorNameEntity = new List<ContributorNameEntity>();
            ContributorNameEntity objContributorNameEntity;

            var results = entities.SP_S_ContributorCodeIEWeeklyContrSchedC();

            foreach (var item in results)
            {
                objContributorNameEntity = new ContributorNameEntity();
                objContributorNameEntity.ContributorTypeId = Convert.ToString(item.CNTRBR_TYPE_ID);
                objContributorNameEntity.ContributorTypeDesc = item.CNTRBR_TYPE_DESC;
                objContributorNameEntity.ContributorTypeAbbrev = item.CNTRBR_TYPE_ABBREV;
                lstContributorNameEntity.Add(objContributorNameEntity);
            }

            return lstContributorNameEntity;
        }
        #endregion GetContributorCodeIEWeeklyContrSchedC

        #region GetContributorCodeIEWeeklyContrScheD
        /// <summary>
        /// GetContributorCodeIEWeeklyContrScheD
        /// </summary>
        /// <returns></returns>
        public IList<ContributorNameEntity> GetContributorCodeIEWeeklyContrSchedD()
        {
            IList<ContributorNameEntity> lstContributorNameEntity = new List<ContributorNameEntity>();
            ContributorNameEntity objContributorNameEntity;

            var results = entities.SP_S_ContributorCodeIEWeeklyContrSchedD();

            foreach (var item in results)
            {
                objContributorNameEntity = new ContributorNameEntity();
                objContributorNameEntity.ContributorTypeId = Convert.ToString(item.CNTRBR_TYPE_ID);
                objContributorNameEntity.ContributorTypeDesc = item.CNTRBR_TYPE_DESC;
                objContributorNameEntity.ContributorTypeAbbrev = item.CNTRBR_TYPE_ABBREV;
                lstContributorNameEntity.Add(objContributorNameEntity);
            }

            return lstContributorNameEntity;
        }
        #endregion GetContributorCodeIEWeeklyContrScheD

        #region GetFilingTransIE24HContributioneData
        /// <summary>
        /// GetFilingTransIE24HContributioneData
        /// </summary>
        /// <param name="objFilingTransDataEntity"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataEntity> GetFilingTransIE24HContributioneData(FilingTransDataEntity objFilingTransDataEntity)
        {
            IList<FilingTransactionDataEntity> lstFilingTransactionDataEntity = new List<FilingTransactionDataEntity>();
            FilingTransactionDataEntity objFilingTransactionDataEntity;

            var results = entities.SP_S_NonItemIE24HContributionTrans(objFilingTransDataEntity.FilerId,
                objFilingTransDataEntity.ReportYearId, objFilingTransDataEntity.OfficeTypeId,
                objFilingTransDataEntity.ElectionType, objFilingTransDataEntity.ElectionDateId);

            foreach (var item in results)
            {
                objFilingTransactionDataEntity = new FilingTransactionDataEntity();
                objFilingTransactionDataEntity.FilingTransId = Convert.ToString(item.FILING_TRANS_ID);
                objFilingTransactionDataEntity.FilingSchedId = Convert.ToString(item.FILING_SCHED_ID);
                objFilingTransactionDataEntity.ContributorTypeId = Convert.ToString(item.CNTRBR_TYPE_ID);
                objFilingTransactionDataEntity.ContributorTypeDesc = item.CNTRBR_TYPE_DESC;
                objFilingTransactionDataEntity.PaymentTypeId = Convert.ToString(item.PAYMENT_TYPE_ID);
                objFilingTransactionDataEntity.PurposeCodeId = Convert.ToString(item.PURPOSE_CODE_ID);
                if (item.SUBMIT_DATE != "")
                {
                    if (Convert.ToDateTime(item.SUBMIT_DATE).ToShortDateString() == "1/1/1900")
                        objFilingTransactionDataEntity.SubmissionDate = "";
                    else
                        objFilingTransactionDataEntity.SubmissionDate = item.SUBMIT_DATE;
                }
                else
                {
                    objFilingTransactionDataEntity.SubmissionDate = "";
                }

                if (item.SCHED_DATE != "")
                    objFilingTransactionDataEntity.SchedDate = Convert.ToDateTime(item.SCHED_DATE).ToShortDateString();
                else
                    objFilingTransactionDataEntity.SchedDate = "";
                objFilingTransactionDataEntity.FilingSchedDesc = item.FILING_SCHED_DESC;
                objFilingTransactionDataEntity.FilingEntityId = item.FLNG_ENT_ID;
                objFilingTransactionDataEntity.FilingEntityName = item.FLNG_ENT_NAME;
                objFilingTransactionDataEntity.FilingFirstName = item.FLNG_ENT_FIRST_NAME;
                objFilingTransactionDataEntity.FilingMiddleName = item.FLNG_ENT_MIDDLE_NAME;
                objFilingTransactionDataEntity.FilingLastName = item.FLNG_ENT_LAST_NAME;
                objFilingTransactionDataEntity.FilingStreetNumber = item.FLNG_ENT_STR_NUM;
                objFilingTransactionDataEntity.FilingStreetName = item.FLNG_ENT_STR_NAME;
                objFilingTransactionDataEntity.FilingCity = item.FLNG_ENT_CITY;
                objFilingTransactionDataEntity.FilingState = item.FLNG_ENT_STATE;
                objFilingTransactionDataEntity.FilingZip = item.FLNG_ENT_ZIP;
                objFilingTransactionDataEntity.FilingCountry = item.FLNG_ENT_COUNTRY;
                objFilingTransactionDataEntity.PaymentTypeDesc = item.PAYMENT_TYPE_DESC;
                objFilingTransactionDataEntity.PayNumber = item.PAY_NUMBER;
                objFilingTransactionDataEntity.OriginalAmount = String.Format("{0:0.00}", item.ORG_AMT);
                objFilingTransactionDataEntity.TransExplanation = item.TRANS_EXPLNTN;
                if (item.R_ITEMIZED == "" || item.R_ITEMIZED == null)
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "Y")
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "N")
                    objFilingTransactionDataEntity.RItemized = "No";
                objFilingTransactionDataEntity.CountyDesc = Convert.ToString(item.CNTY_DESC);
                if (item.R_AMEND == "Y")
                {
                    objFilingTransactionDataEntity.RAmend = "Yes";
                }
                else if (item.R_AMEND == "N")
                {
                    objFilingTransactionDataEntity.RAmend = "No";
                }
                else
                {
                    objFilingTransactionDataEntity.RAmend = item.R_AMEND;
                }
                if (item.R_STATUS == "A")
                {
                    objFilingTransactionDataEntity.RStatus = "Active";
                }
                else if (item.R_STATUS == "I")
                {
                    objFilingTransactionDataEntity.RStatus = "In-Active";
                }
                else if (item.R_STATUS == "P")
                {
                    objFilingTransactionDataEntity.RStatus = "Pending";
                }
                else
                {
                    objFilingTransactionDataEntity.RStatus = item.R_STATUS;
                }
                objFilingTransactionDataEntity.MunicipalityDesc = Convert.ToString(item.MUNICIPALITY_DESC);
                objFilingTransactionDataEntity.LoanerCodeId = Convert.ToString(item.LOANER_CODE_ID);
                objFilingTransactionDataEntity.LoanerCode = Convert.ToString(item.LOANER_CODE);
                objFilingTransactionDataEntity.PurposeCodeDesc = item.PURPOSE_CODE_DESC;
                objFilingTransactionDataEntity.ContributionTypeId = item.CNTRBN_TYPE_ID;
                objFilingTransactionDataEntity.ContributionTypeDesc = item.CNTRBN_TYPE_DESC;
                objFilingTransactionDataEntity.CreatedDate = item.CREATED_DATE;
                objFilingTransactionDataEntity.TreasurerFirstName = item.PERSON_FIRST_NAME;
                objFilingTransactionDataEntity.TreasurerLastName = item.PERSON_LAST_NAME;
                objFilingTransactionDataEntity.TreasurerMiddleName = item.PERSON_MIDDLE_NAME;
                objFilingTransactionDataEntity.TreasurerOccuptaion = item.TREAS_OCCUPATION;
                objFilingTransactionDataEntity.TreasurerEmployer = item.TREAS_EMPLOYER;
                objFilingTransactionDataEntity.TreasurerStreetAddress = item.ADDR_ADDR1;
                objFilingTransactionDataEntity.TreasurerCity = item.ADDR_CITY;
                objFilingTransactionDataEntity.TreasurerState = item.ADDR_STATE;
                objFilingTransactionDataEntity.TreasurerZip = item.ADDR_ZIP;
                objFilingTransactionDataEntity.ContributorOccupation = item.IE_CNTRBR_OCC;
                objFilingTransactionDataEntity.ContributorEmployer = item.IE_CNTRBR_EMP;
                objFilingTransactionDataEntity.IEDescription = item.IE_DESC;
                objFilingTransactionDataEntity.CandBallotPropReference = item.DIST_OFF_CAND_BAL_PROP;
                if (item.R_IE_SUPPORTED == "Y")
                    objFilingTransactionDataEntity.IESupported = "Yes";
                else
                    objFilingTransactionDataEntity.IESupported = "No";
                objFilingTransactionDataEntity.AddrId = item.ADDR_ID;
                objFilingTransactionDataEntity.TreasId = item.TREAS_ID;
                lstFilingTransactionDataEntity.Add(objFilingTransactionDataEntity);
            }

            return lstFilingTransactionDataEntity;
        }
        #endregion GetFilingTransIE24HContributioneData

        #region GetFilingTransIE24HContributionHistoryData
        /// <summary>
        /// GetFilingTransIE24HContributionHistoryData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataEntity> GetFilingTransIE24HContributionHistoryData(String strFilingTransId)
        {
            IList<FilingTransactionDataEntity> lstFilingTransactionDataEntity = new List<FilingTransactionDataEntity>();
            FilingTransactionDataEntity objFilingTransactionDataEntity;

            var results = entities.SP_S_NonItemIE24HContributionTransHistory(strFilingTransId);

            foreach (var item in results)
            {
                objFilingTransactionDataEntity = new FilingTransactionDataEntity();
                objFilingTransactionDataEntity.FilingTransId = Convert.ToString(item.FILING_TRANS_ID);
                objFilingTransactionDataEntity.FilingSchedId = Convert.ToString(item.FILING_SCHED_ID);
                objFilingTransactionDataEntity.ContributorTypeId = Convert.ToString(item.CNTRBR_TYPE_ID);
                objFilingTransactionDataEntity.ContributorTypeDesc = item.CNTRBR_TYPE_DESC;
                objFilingTransactionDataEntity.PaymentTypeId = Convert.ToString(item.PAYMENT_TYPE_ID);
                if (item.SUBMIT_DATE != "")
                {
                    if (Convert.ToDateTime(item.SUBMIT_DATE).ToShortDateString() == "1/1/1900")
                        objFilingTransactionDataEntity.SubmissionDate = "";
                    else
                        objFilingTransactionDataEntity.SubmissionDate = item.SUBMIT_DATE;
                }
                else
                {
                    objFilingTransactionDataEntity.SubmissionDate = "";
                }

                if (item.SCHED_DATE != "")
                    objFilingTransactionDataEntity.SchedDate = Convert.ToDateTime(item.SCHED_DATE).ToShortDateString();
                else
                    objFilingTransactionDataEntity.SchedDate = "";
                objFilingTransactionDataEntity.FilingSchedDesc = item.FILING_SCHED_DESC;
                objFilingTransactionDataEntity.FilingEntityId = item.FLNG_ENT_ID;
                objFilingTransactionDataEntity.FilingEntityName = item.FLNG_ENT_NAME;
                objFilingTransactionDataEntity.FilingFirstName = item.FLNG_ENT_FIRST_NAME;
                objFilingTransactionDataEntity.FilingMiddleName = item.FLNG_ENT_MIDDLE_NAME;
                objFilingTransactionDataEntity.FilingLastName = item.FLNG_ENT_LAST_NAME;
                objFilingTransactionDataEntity.FilingStreetNumber = item.FLNG_ENT_STR_NUM;
                objFilingTransactionDataEntity.FilingStreetName = item.FLNG_ENT_STR_NAME;
                objFilingTransactionDataEntity.FilingCity = item.FLNG_ENT_CITY;
                objFilingTransactionDataEntity.FilingState = item.FLNG_ENT_STATE;
                objFilingTransactionDataEntity.FilingZip = item.FLNG_ENT_ZIP;
                objFilingTransactionDataEntity.FilingCountry = item.FLNG_ENT_COUNTRY;
                objFilingTransactionDataEntity.PaymentTypeDesc = item.PAYMENT_TYPE_DESC;
                objFilingTransactionDataEntity.PayNumber = item.PAY_NUMBER;
                objFilingTransactionDataEntity.OriginalAmount = String.Format("{0:0.00}", item.ORG_AMT);
                objFilingTransactionDataEntity.TransExplanation = item.TRANS_EXPLNTN;
                if (item.R_ITEMIZED == "" || item.R_ITEMIZED == null)
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "Y")
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "N")
                    objFilingTransactionDataEntity.RItemized = "No";
                objFilingTransactionDataEntity.CountyDesc = Convert.ToString(item.CNTY_DESC);
                if (item.R_AMEND == "Y")
                {
                    objFilingTransactionDataEntity.RAmend = "Yes";
                }
                else if (item.R_AMEND == "N")
                {
                    objFilingTransactionDataEntity.RAmend = "No";
                }
                else
                {
                    objFilingTransactionDataEntity.RAmend = item.R_AMEND;
                }
                if (item.R_STATUS == "A")
                {
                    objFilingTransactionDataEntity.RStatus = "Active";
                }
                else if (item.R_STATUS == "I")
                {
                    objFilingTransactionDataEntity.RStatus = "In-Active";
                }
                else if (item.R_STATUS == "P")
                {
                    objFilingTransactionDataEntity.RStatus = "Pending";
                }
                else
                {
                    objFilingTransactionDataEntity.RStatus = item.R_STATUS;
                }
                objFilingTransactionDataEntity.MunicipalityDesc = Convert.ToString(item.MUNICIPALITY_DESC);
                objFilingTransactionDataEntity.LoanerCodeId = Convert.ToString(item.LOANER_CODE_ID);
                objFilingTransactionDataEntity.LoanerCode = Convert.ToString(item.LOANER_CODE);
                objFilingTransactionDataEntity.PurposeCodeDesc = item.PURPOSE_CODE_DESC;
                objFilingTransactionDataEntity.ContributionTypeId = item.CNTRBN_TYPE_ID;
                objFilingTransactionDataEntity.ContributionTypeDesc = item.CNTRBN_TYPE_DESC;
                objFilingTransactionDataEntity.CreatedDate = item.CREATED_DATE;
                objFilingTransactionDataEntity.TreasurerFirstName = item.PERSON_FIRST_NAME;
                objFilingTransactionDataEntity.TreasurerLastName = item.PERSON_LAST_NAME;
                objFilingTransactionDataEntity.TreasurerMiddleName = item.PERSON_MIDDLE_NAME;
                objFilingTransactionDataEntity.TreasurerOccuptaion = item.TREAS_OCCUPATION;
                objFilingTransactionDataEntity.TreasurerEmployer = item.TREAS_EMPLOYER;
                objFilingTransactionDataEntity.TreasurerStreetAddress = item.ADDR_ADDR1;
                objFilingTransactionDataEntity.TreasurerCity = item.ADDR_CITY;
                objFilingTransactionDataEntity.TreasurerState = item.ADDR_STATE;
                objFilingTransactionDataEntity.TreasurerZip = item.ADDR_ZIP;
                objFilingTransactionDataEntity.ContributorOccupation = item.IE_CNTRBR_OCC;
                objFilingTransactionDataEntity.ContributorEmployer = item.IE_CNTRBR_EMP;
                objFilingTransactionDataEntity.CandBallotPropReference = item.DIST_OFF_CAND_BAL_PROP;
                objFilingTransactionDataEntity.IEDescription = item.IE_DESC;
                objFilingTransactionDataEntity.IESupported = item.R_IE_SUPPORTED;
                lstFilingTransactionDataEntity.Add(objFilingTransactionDataEntity);
            }

            return lstFilingTransactionDataEntity;
        }
        #endregion GetFilingTransIE24HContributionHistoryData

        #region GetIE24HContrTransactionTypes
        /// <summary>
        /// GetIE24HContrTransactionTypes
        /// </summary>
        /// <returns></returns>
        public IList<TransactionTypesEntity> GetIE24HContrTransactionTypes()
        {
            IList<TransactionTypesEntity> lstTransactionTypesEntity = new List<TransactionTypesEntity>();
            TransactionTypesEntity objTransactionTypesEntity;

            var results = entities.SP_S_TransactionTypes24HContribution();

            foreach (var item in results)
            {
                objTransactionTypesEntity = new TransactionTypesEntity();
                objTransactionTypesEntity.FilingSchedId = Convert.ToString(item.FILING_SCHED_ID);
                objTransactionTypesEntity.FilingSchedDesc = item.FILING_SCHED_DESC;
                objTransactionTypesEntity.FilingSchedAbbrev = item.FILING_SCHED_ABBREV;
                lstTransactionTypesEntity.Add(objTransactionTypesEntity);
            }

            return lstTransactionTypesEntity;
        }
        #endregion GetIE24HContrTransactionTypes

        #region AddNonItemIE24HContrFlngTrans
        /// <summary>
        /// AddNonItemIE24HContrFlngTrans
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean AddNonItemIE24HContrFlngTrans(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var returnValue = entities.SP_I_NonItemizedIE24HContrFlngTrans(objFilingTransactionsEntity.FilerId,
                        objFilingTransactionsEntity.PersonId,
                        objFilingTransactionsEntity.TreasId,
                        objFilingTransactionsEntity.AddrId,
                        objFilingTransactionsEntity.FilingSchedId,
                        objFilingTransactionsEntity.SchedDate,
                        objFilingTransactionsEntity.PaymentTypeId,
                        objFilingTransactionsEntity.ContributorTypeId,
                        objFilingTransactionsEntity.ContributionTypeId,
                        objFilingTransactionsEntity.LoanOtherId,
                        objFilingTransactionsEntity.PayNumber,
                        objFilingTransactionsEntity.OrgAmt,
                        objFilingTransactionsEntity.TransExplanation,
                        objFilingTransactionsEntity.MunicipalityID,
                        objFilingTransactionsEntity.RAmend,
                        objFilingTransactionsEntity.ElectionDate,
                        objFilingTransactionsEntity.ElectionDateId,
                        objFilingTransactionsEntity.ElectionTypeId,
                        objFilingTransactionsEntity.OfficeTypeId,
                        objFilingTransactionsEntity.ElectYearId,
                        objFilingTransactionsEntity.ElectionYear,
                        objFilingTransactionsEntity.FilingEntId,
                        objFilingTransactionsEntity.FlngEntName,
                        objFilingTransactionsEntity.FlngEntFirstName,
                        objFilingTransactionsEntity.FlngEntLastName,
                        objFilingTransactionsEntity.FlngEntMiddleName,
                        objFilingTransactionsEntity.FlngEntStrName,
                        objFilingTransactionsEntity.FlngEntCity,
                        objFilingTransactionsEntity.FlngEntState,
                        objFilingTransactionsEntity.FlngEntZip,
                        objFilingTransactionsEntity.FlngEntCountry,
                        objFilingTransactionsEntity.TreasurerOccupation,
                        objFilingTransactionsEntity.TreasurerEmployer,
                        objFilingTransactionsEntity.TreasurerStreetAddress,
                        objFilingTransactionsEntity.TreasurerCity,
                        objFilingTransactionsEntity.TreasurerState,
                        objFilingTransactionsEntity.TreasurerZip,
                        objFilingTransactionsEntity.CandBallotPropReference,
                        objFilingTransactionsEntity.ContributorOccupation,
                        objFilingTransactionsEntity.ContributorEmployer,
                        objFilingTransactionsEntity.IEDescription,
                        objFilingTransactionsEntity.R_Supported,
                        objFilingTransactionsEntity.CreatedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }
        #endregion AddNonItemIE24HContrFlngTrans

        #region UpdateIE24HContrFlngTrans
        /// <summary>
        /// UpdateIE24HContrFlngTrans
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean UpdateIE24HContrFlngTrans(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var returnValue = entities.SP_U_NonItemizedIE24HContrFlngTrans(objFilingTransactionsEntity.FilingTransId,
                    objFilingTransactionsEntity.FilingSchedId,
                    objFilingTransactionsEntity.ContributorTypeId,
                    objFilingTransactionsEntity.ContributionTypeId,
                    objFilingTransactionsEntity.FilingEntId,
                    objFilingTransactionsEntity.TreasId,
                    objFilingTransactionsEntity.AddrId,
                    objFilingTransactionsEntity.PersonId,
                    objFilingTransactionsEntity.SubmissionDate,
                    objFilingTransactionsEntity.SchedDate,
                    objFilingTransactionsEntity.PayNumber,
                    objFilingTransactionsEntity.PaymentTypeId,
                    objFilingTransactionsEntity.OrgAmt,
                    objFilingTransactionsEntity.TransExplanation,
                    objFilingTransactionsEntity.FlngEntName,
                    objFilingTransactionsEntity.FlngEntFirstName,
                    objFilingTransactionsEntity.FlngEntMiddleName,
                    objFilingTransactionsEntity.FlngEntLastName,
                    objFilingTransactionsEntity.FlngEntCountry,
                    objFilingTransactionsEntity.FlngEntStrName,
                    objFilingTransactionsEntity.FlngEntCity,
                    objFilingTransactionsEntity.FlngEntState,
                    objFilingTransactionsEntity.FlngEntZip,
                    objFilingTransactionsEntity.TreasurerStreetAddress,
                    objFilingTransactionsEntity.TreasurerCity,
                    objFilingTransactionsEntity.TreasurerState,
                    objFilingTransactionsEntity.TreasurerZip,
                    objFilingTransactionsEntity.ContributorOccupation,
                    objFilingTransactionsEntity.ContributorEmployer,
                    objFilingTransactionsEntity.IEDescription,
                    objFilingTransactionsEntity.TreasurerOccupation,
                    objFilingTransactionsEntity.TreasurerEmployer,
                    objFilingTransactionsEntity.R_Supported,
                    objFilingTransactionsEntity.CandBallotPropReference,
                    objFilingTransactionsEntity.ModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }
        #endregion UpdateIE24HContrFlngTrans

        #region SubmitIE24HContrFlngTrans
        /// <summary>
        /// SubmitIE24HContrFlngTrans
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        public Boolean SubmitIE24HContrFlngTrans(String strFilingTransId, String strModifiedBy)
        {
            var returnValue = entities.SP_U_NonItemizedIE24HContrFlngTransSubmit(strFilingTransId, strModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }
        #endregion SubmitIE24HContrFlngTrans

        #region GetIEWeeklyExpTransactionTypes
        /// <summary>
        /// GetIEWeeklyExpTransactionTypes
        /// </summary>
        /// <returns></returns>
        public IList<TransactionTypesEntity> GetIEWeeklyExpTransactionTypes()
        {
            IList<TransactionTypesEntity> lstTransactionTypesEntity = new List<TransactionTypesEntity>();
            TransactionTypesEntity objTransactionTypesEntity;

            var results = entities.SP_S_TransactionTypeIEWeeklyExpenditure();

            foreach (var item in results)
            {
                objTransactionTypesEntity = new TransactionTypesEntity();
                objTransactionTypesEntity.FilingSchedId = Convert.ToString(item.FILING_SCHED_ID);
                objTransactionTypesEntity.FilingSchedDesc = item.FILING_SCHED_DESC;
                objTransactionTypesEntity.FilingSchedAbbrev = item.FILING_SCHED_ABBREV;
                lstTransactionTypesEntity.Add(objTransactionTypesEntity);
            }

            return lstTransactionTypesEntity;
        }
        #endregion GetIEWeeklyExpTransactionTypes

        #region GetFilingTransIEWeeklyExpenditureData
        /// <summary>
        /// GetFilingTransIEWeeklyExpenditureData
        /// </summary>
        /// <param name="objFilingTransDataEntity"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataEntity> GetFilingTransIEWeeklyExpenditureData(FilingTransDataEntity objFilingTransDataEntity)
        {
            IList<FilingTransactionDataEntity> lstFilingTransactionDataEntity = new List<FilingTransactionDataEntity>();
            FilingTransactionDataEntity objFilingTransactionDataEntity;

            var results = entities.SP_S_NonItemIEWeeklyExpenditureTrans(objFilingTransDataEntity.FilerId,
                objFilingTransDataEntity.ReportYearId, objFilingTransDataEntity.OfficeTypeId,
                objFilingTransDataEntity.ElectionType, objFilingTransDataEntity.ElectionDateId);

            foreach (var item in results)
            {
                objFilingTransactionDataEntity = new FilingTransactionDataEntity();
                objFilingTransactionDataEntity.FilingTransId = Convert.ToString(item.FILING_TRANS_ID);
                objFilingTransactionDataEntity.FilingSchedId = Convert.ToString(item.FILING_SCHED_ID);
                objFilingTransactionDataEntity.PurposeCodeDesc = item.PURPOSE_CODE_DESC;
                objFilingTransactionDataEntity.PaymentTypeId = Convert.ToString(item.PAYMENT_TYPE_ID);
                objFilingTransactionDataEntity.PurposeCodeId = Convert.ToString(item.PURPOSE_CODE_ID);
                if (item.SUBMIT_DATE != "")
                {
                    if (Convert.ToDateTime(item.SUBMIT_DATE).ToShortDateString() == "1/1/1900")
                        objFilingTransactionDataEntity.SubmissionDate = "";
                    else
                        objFilingTransactionDataEntity.SubmissionDate = item.SUBMIT_DATE;
                }
                else
                {
                    objFilingTransactionDataEntity.SubmissionDate = "";
                }

                if (item.SCHED_DATE != "")
                    objFilingTransactionDataEntity.SchedDate = Convert.ToDateTime(item.SCHED_DATE).ToShortDateString();
                else
                    objFilingTransactionDataEntity.SchedDate = "";
                objFilingTransactionDataEntity.FilingSchedDesc = item.FILING_SCHED_DESC;
                objFilingTransactionDataEntity.FilingEntityId = item.FLNG_ENT_ID;
                objFilingTransactionDataEntity.FilingEntityName = item.FLNG_ENT_NAME;
                objFilingTransactionDataEntity.FilingStreetNumber = item.FLNG_ENT_STR_NUM;
                objFilingTransactionDataEntity.FilingStreetName = item.FLNG_ENT_STR_NAME;
                objFilingTransactionDataEntity.FilingCity = item.FLNG_ENT_CITY;
                objFilingTransactionDataEntity.FilingState = item.FLNG_ENT_STATE;
                objFilingTransactionDataEntity.FilingZip = item.FLNG_ENT_ZIP;
                objFilingTransactionDataEntity.FilingCountry = item.FLNG_ENT_COUNTRY;
                objFilingTransactionDataEntity.PaymentTypeDesc = item.PAYMENT_TYPE_DESC;
                objFilingTransactionDataEntity.PayNumber = item.PAY_NUMBER;
                objFilingTransactionDataEntity.OriginalAmount = String.Format("{0:0.00}", item.ORG_AMT);
                if (item.OWED_AMT != null)
                    objFilingTransactionDataEntity.OwedAmount = String.Format("{0:0.00}", item.OWED_AMT);
                else
                    objFilingTransactionDataEntity.OwedAmount = "";

                objFilingTransactionDataEntity.TransExplanation = item.TRANS_EXPLNTN;
                if (item.R_ITEMIZED == "" || item.R_ITEMIZED == null)
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "Y")
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "N")
                    objFilingTransactionDataEntity.RItemized = "No";
                objFilingTransactionDataEntity.CountyDesc = Convert.ToString(item.CNTY_DESC);
                if (item.R_AMEND == "Y")
                {
                    objFilingTransactionDataEntity.RAmend = "Yes";
                }
                else if (item.R_AMEND == "N")
                {
                    objFilingTransactionDataEntity.RAmend = "No";
                }
                else
                {
                    objFilingTransactionDataEntity.RAmend = item.R_AMEND;
                }
                if (item.R_STATUS == "A")
                {
                    objFilingTransactionDataEntity.RStatus = "Active";
                }
                else if (item.R_STATUS == "I")
                {
                    objFilingTransactionDataEntity.RStatus = "In-Active";
                }
                else if (item.R_STATUS == "P")
                {
                    objFilingTransactionDataEntity.RStatus = "Pending";
                }
                else
                {
                    objFilingTransactionDataEntity.RStatus = item.R_STATUS;
                }
                objFilingTransactionDataEntity.MunicipalityDesc = Convert.ToString(item.MUNICIPALITY_DESC);
                objFilingTransactionDataEntity.PurposeCodeDesc = item.PURPOSE_CODE_DESC;
                objFilingTransactionDataEntity.CreatedDate = item.CREATED_DATE;
                objFilingTransactionDataEntity.TreasurerFirstName = item.PERSON_FIRST_NAME;
                objFilingTransactionDataEntity.TreasurerLastName = item.PERSON_LAST_NAME;
                objFilingTransactionDataEntity.TreasurerMiddleName = item.PERSON_MIDDLE_NAME;
                objFilingTransactionDataEntity.TreasurerOccuptaion = item.TREAS_OCCUPATION;
                objFilingTransactionDataEntity.TreasurerEmployer = item.TREAS_EMPLOYER;
                objFilingTransactionDataEntity.TreasurerStreetAddress = item.ADDR_ADDR1;
                objFilingTransactionDataEntity.TreasurerCity = item.ADDR_CITY;
                objFilingTransactionDataEntity.TreasurerState = item.ADDR_STATE;
                objFilingTransactionDataEntity.TreasurerZip = item.ADDR_ZIP;
                objFilingTransactionDataEntity.IEDescription = item.IE_DESC;
                objFilingTransactionDataEntity.CandBallotPropReference = item.DIST_OFF_CAND_BAL_PROP;
                if (item.R_IE_SUPPORTED == "Y")
                    objFilingTransactionDataEntity.IESupported = "Yes";
                else
                    objFilingTransactionDataEntity.IESupported = "No";
                if (item.R_LIABILITY == "Y")
                    objFilingTransactionDataEntity.RLiability = "Yes";
                else
                    objFilingTransactionDataEntity.RLiability = "No";
                if (item.R_SUBCONTRACTOR == "Y")
                    objFilingTransactionDataEntity.RSubcontractor = "Yes";
                else
                    objFilingTransactionDataEntity.RSubcontractor = "No";
                objFilingTransactionDataEntity.AddrId = item.ADDR_ID;
                objFilingTransactionDataEntity.TreasId = item.TREAS_ID;
                objFilingTransactionDataEntity.DateIncurredOrgAmtId = item.EXISTS_LIAB_TRANS_ID;
                objFilingTransactionDataEntity.LoanLiablityNumber = item.LOAN_LIB_NUMBER;
                objFilingTransactionDataEntity.TransNumber = item.TRANS_NUMBER;
                objFilingTransactionDataEntity.TransMapping = item.TRANS_MAPPING;
                lstFilingTransactionDataEntity.Add(objFilingTransactionDataEntity);
            }

            return lstFilingTransactionDataEntity;
        }
        #endregion GetFilingTransIEWeeklyExpenditureData

        #region GetFilingTransIEWeeklyExpenditureHistoryData
        /// <summary>
        /// GetFilingTransIEWeeklyExpenditureHistoryData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataEntity> GetFilingTransIEWeeklyExpenditureHistoryData(String strTransNumber)
        {
            IList<FilingTransactionDataEntity> lstFilingTransactionDataEntity = new List<FilingTransactionDataEntity>();
            FilingTransactionDataEntity objFilingTransactionDataEntity;

            var results = entities.SP_S_NonItemIEWeeklyExpenditureTransHistory(strTransNumber);

            foreach (var item in results)
            {
                objFilingTransactionDataEntity = new FilingTransactionDataEntity();
                objFilingTransactionDataEntity.FilingTransId = Convert.ToString(item.FILING_TRANS_ID);
                objFilingTransactionDataEntity.FilingSchedId = Convert.ToString(item.FILING_SCHED_ID);
                objFilingTransactionDataEntity.PurposeCodeId = item.PURPOSE_CODE_ID;
                objFilingTransactionDataEntity.PurposeCodeDesc = item.PURPOSE_CODE_DESC;
                objFilingTransactionDataEntity.PaymentTypeId = Convert.ToString(item.PAYMENT_TYPE_ID);
                if (item.SUBMIT_DATE != "")
                {
                    if (Convert.ToDateTime(item.SUBMIT_DATE).ToShortDateString() == "1/1/1900")
                        objFilingTransactionDataEntity.SubmissionDate = "";
                    else
                        objFilingTransactionDataEntity.SubmissionDate = item.SUBMIT_DATE;
                }
                else
                {
                    objFilingTransactionDataEntity.SubmissionDate = "";
                }

                if (item.SCHED_DATE != "")
                    objFilingTransactionDataEntity.SchedDate = Convert.ToDateTime(item.SCHED_DATE).ToShortDateString();
                else
                    objFilingTransactionDataEntity.SchedDate = "";
                objFilingTransactionDataEntity.FilingSchedDesc = item.FILING_SCHED_DESC;
                objFilingTransactionDataEntity.FilingEntityId = item.FLNG_ENT_ID;
                objFilingTransactionDataEntity.FilingEntityName = item.FLNG_ENT_NAME;
                objFilingTransactionDataEntity.FilingStreetNumber = item.FLNG_ENT_STR_NUM;
                objFilingTransactionDataEntity.FilingStreetName = item.FLNG_ENT_STR_NAME;
                objFilingTransactionDataEntity.FilingCity = item.FLNG_ENT_CITY;
                objFilingTransactionDataEntity.FilingState = item.FLNG_ENT_STATE;
                objFilingTransactionDataEntity.FilingZip = item.FLNG_ENT_ZIP;
                objFilingTransactionDataEntity.FilingCountry = item.FLNG_ENT_COUNTRY;
                objFilingTransactionDataEntity.PaymentTypeDesc = item.PAYMENT_TYPE_DESC;
                objFilingTransactionDataEntity.PayNumber = item.PAY_NUMBER;
                objFilingTransactionDataEntity.OriginalAmount = String.Format("{0:0.00}", item.ORG_AMT);
                objFilingTransactionDataEntity.TransExplanation = item.TRANS_EXPLNTN;
                if (item.R_ITEMIZED == "" || item.R_ITEMIZED == null)
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "Y")
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "N")
                    objFilingTransactionDataEntity.RItemized = "No";
                objFilingTransactionDataEntity.CountyDesc = Convert.ToString(item.CNTY_DESC);
                if (item.R_AMEND == "Y")
                {
                    objFilingTransactionDataEntity.RAmend = "Yes";
                }
                else if (item.R_AMEND == "N")
                {
                    objFilingTransactionDataEntity.RAmend = "No";
                }
                else
                {
                    objFilingTransactionDataEntity.RAmend = item.R_AMEND;
                }
                if (item.R_STATUS == "A")
                {
                    objFilingTransactionDataEntity.RStatus = "Active";
                }
                else if (item.R_STATUS == "I")
                {
                    objFilingTransactionDataEntity.RStatus = "In-Active";
                }
                else if (item.R_STATUS == "P")
                {
                    objFilingTransactionDataEntity.RStatus = "Pending";
                }
                else
                {
                    objFilingTransactionDataEntity.RStatus = item.R_STATUS;
                }
                objFilingTransactionDataEntity.MunicipalityDesc = Convert.ToString(item.MUNICIPALITY_DESC);
                objFilingTransactionDataEntity.PurposeCodeDesc = item.PURPOSE_CODE_DESC;
                objFilingTransactionDataEntity.CreatedDate = item.CREATED_DATE;
                objFilingTransactionDataEntity.TreasurerFirstName = item.PERSON_FIRST_NAME;
                objFilingTransactionDataEntity.TreasurerLastName = item.PERSON_LAST_NAME;
                objFilingTransactionDataEntity.TreasurerMiddleName = item.PERSON_MIDDLE_NAME;
                objFilingTransactionDataEntity.TreasurerOccuptaion = item.TREAS_OCCUPATION;
                objFilingTransactionDataEntity.TreasurerEmployer = item.TREAS_EMPLOYER;
                objFilingTransactionDataEntity.TreasurerStreetAddress = item.ADDR_ADDR1;
                objFilingTransactionDataEntity.TreasurerCity = item.ADDR_CITY;
                objFilingTransactionDataEntity.TreasurerState = item.ADDR_STATE;
                objFilingTransactionDataEntity.TreasurerZip = item.ADDR_ZIP;
                objFilingTransactionDataEntity.CandBallotPropReference = item.DIST_OFF_CAND_BAL_PROP;
                objFilingTransactionDataEntity.IEDescription = item.IE_DESC;
                objFilingTransactionDataEntity.IESupported = item.R_IE_SUPPORTED;
                objFilingTransactionDataEntity.LoanLiablityNumber = item.LOAN_LIB_NUMBER;
                objFilingTransactionDataEntity.TransNumber = item.TRANS_NUMBER;
                objFilingTransactionDataEntity.TransMapping = item.TRANS_MAPPING;
                lstFilingTransactionDataEntity.Add(objFilingTransactionDataEntity);
            }

            return lstFilingTransactionDataEntity;
        }
        #endregion GetFilingTransIEWeeklyExpenditureHistoryData

        #region AddNonItemIEWeeklyExpFlngTrans
        /// <summary>
        /// AddNonItemIEWeeklyExpFlngTrans
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean AddNonItemIEWeeklyExpFlngTrans(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var returnValue = entities.SP_I_NonItemizedIEWeeklyExpFlngTrans(objFilingTransactionsEntity.FilerId,
                        objFilingTransactionsEntity.PersonId,
                        objFilingTransactionsEntity.TreasId,
                        objFilingTransactionsEntity.AddrId,
                        objFilingTransactionsEntity.FilingSchedId,
                        objFilingTransactionsEntity.SchedDate,
                        objFilingTransactionsEntity.PaymentTypeId,
                        objFilingTransactionsEntity.PurposeCodeId,
                        objFilingTransactionsEntity.PayNumber,
                        objFilingTransactionsEntity.OrgAmt,
                        objFilingTransactionsEntity.OwedAmt,
                        objFilingTransactionsEntity.TransExplanation,
                        objFilingTransactionsEntity.MunicipalityID,
                        objFilingTransactionsEntity.RAmend,
                        objFilingTransactionsEntity.ElectionDate,
                        objFilingTransactionsEntity.ElectionDateId,
                        objFilingTransactionsEntity.ElectionTypeId,
                        objFilingTransactionsEntity.OfficeTypeId,
                        objFilingTransactionsEntity.ElectYearId,
                        objFilingTransactionsEntity.ElectionYear,
                        objFilingTransactionsEntity.FilingEntId,
                        objFilingTransactionsEntity.FlngEntName,
                        objFilingTransactionsEntity.FlngEntStrName,
                        objFilingTransactionsEntity.FlngEntCity,
                        objFilingTransactionsEntity.FlngEntState,
                        objFilingTransactionsEntity.FlngEntZip,
                        objFilingTransactionsEntity.FlngEntCountry,
                        objFilingTransactionsEntity.TreasurerOccupation,
                        objFilingTransactionsEntity.TreasurerEmployer,
                        objFilingTransactionsEntity.TreasurerStreetAddress,
                        objFilingTransactionsEntity.TreasurerCity,
                        objFilingTransactionsEntity.TreasurerState,
                        objFilingTransactionsEntity.TreasurerZip,
                        objFilingTransactionsEntity.CandBallotPropReference,
                        objFilingTransactionsEntity.IEDescription,
                        objFilingTransactionsEntity.DateIncurredOrgAmtId,
                        objFilingTransactionsEntity.R_Supported,
                        objFilingTransactionsEntity.RLiability,
                        objFilingTransactionsEntity.RSubcontractor,
                        objFilingTransactionsEntity.CreatedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }
        #endregion AddNonItemIEWeeklyExpFlngTrans

        #region UpdateIEWeeklyExpenditureFlngTrans
        /// <summary>
        /// UpdateIEWeeklyExpenditureFlngTrans
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean UpdateIEWeeklyExpenditureFlngTrans(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var returnValue = entities.SP_U_NonItemIEWeeklyExpenditureTrans(objFilingTransactionsEntity.TransNumber,
                    objFilingTransactionsEntity.FilingSchedId,
                    objFilingTransactionsEntity.FilingEntId,
                    objFilingTransactionsEntity.TreasId,
                    objFilingTransactionsEntity.AddrId,
                    objFilingTransactionsEntity.PersonId,
                    objFilingTransactionsEntity.SubmissionDate,
                    objFilingTransactionsEntity.SchedDate,
                    objFilingTransactionsEntity.PayNumber,
                    objFilingTransactionsEntity.PaymentTypeId,
                    objFilingTransactionsEntity.PurposeCodeId,
                    objFilingTransactionsEntity.OrgAmt,
                    objFilingTransactionsEntity.OwedAmt,
                    objFilingTransactionsEntity.TransExplanation,
                    objFilingTransactionsEntity.FlngEntName,
                    objFilingTransactionsEntity.FlngEntCountry,
                    objFilingTransactionsEntity.FlngEntStrName,
                    objFilingTransactionsEntity.FlngEntCity,
                    objFilingTransactionsEntity.FlngEntState,
                    objFilingTransactionsEntity.FlngEntZip,
                    objFilingTransactionsEntity.TreasurerStreetAddress,
                    objFilingTransactionsEntity.TreasurerCity,
                    objFilingTransactionsEntity.TreasurerState,
                    objFilingTransactionsEntity.TreasurerZip,
                    objFilingTransactionsEntity.IEDescription,
                    objFilingTransactionsEntity.TreasurerOccupation,
                    objFilingTransactionsEntity.TreasurerEmployer,
                    objFilingTransactionsEntity.R_Supported,
                    objFilingTransactionsEntity.CandBallotPropReference,
                    objFilingTransactionsEntity.DateIncurredOrgAmtId,
                    objFilingTransactionsEntity.RSubcontractor,
                    objFilingTransactionsEntity.RLiability,
                    objFilingTransactionsEntity.ModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }
        #endregion UpdateIEWeeklyExpenditureFlngTrans

        #region GetNonItemIEDateIncrdLiabUpdateData
        /// <summary>
        /// GetNonItemIEDateIncrdLiabUpdateData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<DateIncurredEntity> GetNonItemIEDateIncrdLiabUpdateData(String strTransNumber)
        {
            IList<DateIncurredEntity> lstDateIncurredEntity = new List<DateIncurredEntity>();
            DateIncurredEntity objDateIncurredEntity;

            var results = entities.SP_S_NonItemIEDateIncrdLiabUpdate(strTransNumber);

            foreach (var item in results)
            {
                objDateIncurredEntity = new DateIncurredEntity();
                objDateIncurredEntity.DateIncurredId = item.TRANS_NUMBER;
                objDateIncurredEntity.DateIncurredValue = item.SCHED_DATE;
                objDateIncurredEntity.AmountLiability = String.Format("{0:0.00}", item.ORG_AMT);
                lstDateIncurredEntity.Add(objDateIncurredEntity);
            }
            return lstDateIncurredEntity;
        }
        #endregion GetNonItemIEDateIncrdLiabUpdateData

        #region GetNonItemIEPurposeCodes
        /// <summary>
        /// GetNonItemIEPurposeCodes
        /// </summary>
        /// <returns></returns>
        public IList<PurposeCodeEntity> GetNonItemIEPurposeCodes()
        {
            IList<PurposeCodeEntity> lstPurposeCodeEntity = new List<PurposeCodeEntity>();
            PurposeCodeEntity objPurposeCodeEntity;

            var results = entities.SP_S_PurposeCodeNonItemIESchedF();

            foreach (var item in results)
            {
                objPurposeCodeEntity = new PurposeCodeEntity();
                objPurposeCodeEntity.PurposeCodeId = Convert.ToString(item.PURPOSE_CODE_ID);
                objPurposeCodeEntity.PurposeCodeDesc = item.PURPOSE_CODE_DESC;
                objPurposeCodeEntity.PurposeCodeAbbrev = item.PURPOSE_CODE_ABBREV;
                lstPurposeCodeEntity.Add(objPurposeCodeEntity);
            }

            return lstPurposeCodeEntity;
        }
        #endregion GetNonItemIEPurposeCodes

        #region GetNonItemIEPurposeCodesSubContr
        /// <summary>
        /// GetNonItemIEPurposeCodesSubContr
        /// </summary>
        /// <returns></returns>
        public IList<PurposeCodeEntity> GetNonItemIEPurposeCodesSubContr()
        {
            IList<PurposeCodeEntity> lstPurposeCodeEntity = new List<PurposeCodeEntity>();
            PurposeCodeEntity objPurposeCodeEntity;

            var results = entities.SP_S_PurposeCodeNonItemIESchedFSubContr();

            foreach (var item in results)
            {
                objPurposeCodeEntity = new PurposeCodeEntity();
                objPurposeCodeEntity.PurposeCodeId = Convert.ToString(item.PURPOSE_CODE_ID);
                objPurposeCodeEntity.PurposeCodeDesc = item.PURPOSE_CODE_DESC;
                objPurposeCodeEntity.PurposeCodeAbbrev = item.PURPOSE_CODE_ABBREV;
                lstPurposeCodeEntity.Add(objPurposeCodeEntity);
            }

            return lstPurposeCodeEntity;
        }
        #endregion GetNonItemIEPurposeCodesSubContr

        #region GetFilingTransIE24HourExpenditureData
        /// <summary>
        /// GetFilingTransIE24HourExpenditureData
        /// </summary>
        /// <param name="objFilingTransDataEntity"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataEntity> GetFilingTransIE24HourExpenditureData(FilingTransDataEntity objFilingTransDataEntity)
        {
            IList<FilingTransactionDataEntity> lstFilingTransactionDataEntity = new List<FilingTransactionDataEntity>();
            FilingTransactionDataEntity objFilingTransactionDataEntity;

            var results = entities.SP_S_NonItemIE24HourExpenditureTrans(objFilingTransDataEntity.FilerId,
                objFilingTransDataEntity.ReportYearId, objFilingTransDataEntity.OfficeTypeId,
                objFilingTransDataEntity.ElectionType, objFilingTransDataEntity.ElectionDateId);

            foreach (var item in results)
            {
                objFilingTransactionDataEntity = new FilingTransactionDataEntity();
                objFilingTransactionDataEntity.FilingTransId = Convert.ToString(item.FILING_TRANS_ID);
                objFilingTransactionDataEntity.FilingSchedId = Convert.ToString(item.FILING_SCHED_ID);
                objFilingTransactionDataEntity.PurposeCodeDesc = item.PURPOSE_CODE_DESC;
                objFilingTransactionDataEntity.PaymentTypeId = Convert.ToString(item.PAYMENT_TYPE_ID);
                objFilingTransactionDataEntity.PurposeCodeId = Convert.ToString(item.PURPOSE_CODE_ID);
                if (item.SUBMIT_DATE != "")
                {
                    if (Convert.ToDateTime(item.SUBMIT_DATE).ToShortDateString() == "1/1/1900")
                        objFilingTransactionDataEntity.SubmissionDate = "";
                    else
                        objFilingTransactionDataEntity.SubmissionDate = item.SUBMIT_DATE;
                }
                else
                {
                    objFilingTransactionDataEntity.SubmissionDate = "";
                }

                if (item.SCHED_DATE != "")
                    objFilingTransactionDataEntity.SchedDate = Convert.ToDateTime(item.SCHED_DATE).ToShortDateString();
                else
                    objFilingTransactionDataEntity.SchedDate = "";
                objFilingTransactionDataEntity.FilingSchedDesc = item.FILING_SCHED_DESC;
                objFilingTransactionDataEntity.FilingEntityId = item.FLNG_ENT_ID;
                objFilingTransactionDataEntity.FilingEntityName = item.FLNG_ENT_NAME;
                objFilingTransactionDataEntity.FilingStreetNumber = item.FLNG_ENT_STR_NUM;
                objFilingTransactionDataEntity.FilingStreetName = item.FLNG_ENT_STR_NAME;
                objFilingTransactionDataEntity.FilingCity = item.FLNG_ENT_CITY;
                objFilingTransactionDataEntity.FilingState = item.FLNG_ENT_STATE;
                objFilingTransactionDataEntity.FilingZip = item.FLNG_ENT_ZIP;
                objFilingTransactionDataEntity.FilingCountry = item.FLNG_ENT_COUNTRY;
                objFilingTransactionDataEntity.PaymentTypeDesc = item.PAYMENT_TYPE_DESC;
                objFilingTransactionDataEntity.PayNumber = item.PAY_NUMBER;
                objFilingTransactionDataEntity.OriginalAmount = String.Format("{0:0.00}", item.ORG_AMT);
                if (item.OWED_AMT != null)
                    objFilingTransactionDataEntity.OwedAmount = String.Format("{0:0.00}", item.OWED_AMT);
                else
                    objFilingTransactionDataEntity.OwedAmount = "";

                objFilingTransactionDataEntity.TransExplanation = item.TRANS_EXPLNTN;
                if (item.R_ITEMIZED == "" || item.R_ITEMIZED == null)
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "Y")
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "N")
                    objFilingTransactionDataEntity.RItemized = "No";
                objFilingTransactionDataEntity.CountyDesc = Convert.ToString(item.CNTY_DESC);
                if (item.R_AMEND == "Y")
                {
                    objFilingTransactionDataEntity.RAmend = "Yes";
                }
                else if (item.R_AMEND == "N")
                {
                    objFilingTransactionDataEntity.RAmend = "No";
                }
                else
                {
                    objFilingTransactionDataEntity.RAmend = item.R_AMEND;
                }
                if (item.R_STATUS == "A")
                {
                    objFilingTransactionDataEntity.RStatus = "Active";
                }
                else if (item.R_STATUS == "I")
                {
                    objFilingTransactionDataEntity.RStatus = "In-Active";
                }
                else if (item.R_STATUS == "P")
                {
                    objFilingTransactionDataEntity.RStatus = "Pending";
                }
                else
                {
                    objFilingTransactionDataEntity.RStatus = item.R_STATUS;
                }
                objFilingTransactionDataEntity.MunicipalityDesc = Convert.ToString(item.MUNICIPALITY_DESC);
                objFilingTransactionDataEntity.PurposeCodeDesc = item.PURPOSE_CODE_DESC;
                objFilingTransactionDataEntity.CreatedDate = item.CREATED_DATE;
                objFilingTransactionDataEntity.TreasurerFirstName = item.PERSON_FIRST_NAME;
                objFilingTransactionDataEntity.TreasurerLastName = item.PERSON_LAST_NAME;
                objFilingTransactionDataEntity.TreasurerMiddleName = item.PERSON_MIDDLE_NAME;
                objFilingTransactionDataEntity.TreasurerOccuptaion = item.TREAS_OCCUPATION;
                objFilingTransactionDataEntity.TreasurerEmployer = item.TREAS_EMPLOYER;
                objFilingTransactionDataEntity.TreasurerStreetAddress = item.ADDR_ADDR1;
                objFilingTransactionDataEntity.TreasurerCity = item.ADDR_CITY;
                objFilingTransactionDataEntity.TreasurerState = item.ADDR_STATE;
                objFilingTransactionDataEntity.TreasurerZip = item.ADDR_ZIP;
                objFilingTransactionDataEntity.IEDescription = item.IE_DESC;
                objFilingTransactionDataEntity.CandBallotPropReference = item.DIST_OFF_CAND_BAL_PROP;
                if (item.R_IE_SUPPORTED == "Y")
                    objFilingTransactionDataEntity.IESupported = "Yes";
                else
                    objFilingTransactionDataEntity.IESupported = "No";
                if (item.R_LIABILITY == "Y")
                    objFilingTransactionDataEntity.RLiability = "Yes";
                else
                    objFilingTransactionDataEntity.RLiability = "No";
                if (item.R_SUBCONTRACTOR == "Y")
                    objFilingTransactionDataEntity.RSubcontractor = "Yes";
                else
                    objFilingTransactionDataEntity.RSubcontractor = "No";
                objFilingTransactionDataEntity.AddrId = item.ADDR_ID;
                objFilingTransactionDataEntity.TreasId = item.TREAS_ID;
                objFilingTransactionDataEntity.DateIncurredOrgAmtId = item.EXISTS_LIAB_TRANS_ID;
                objFilingTransactionDataEntity.LoanLiablityNumber = item.LOAN_LIB_NUMBER;
                objFilingTransactionDataEntity.TransNumber = item.TRANS_NUMBER;
                objFilingTransactionDataEntity.TransMapping = item.TRANS_MAPPING;
                lstFilingTransactionDataEntity.Add(objFilingTransactionDataEntity);
            }

            return lstFilingTransactionDataEntity;
        }
        #endregion GetFilingTransIE24HourExpenditureData

        #region AddNonItemIE24HourExpFlngTrans
        /// <summary>
        /// AddNonItemIE24HourExpFlngTrans
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean AddNonItemIE24HourExpFlngTrans(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var returnValue = entities.SP_I_NonItemizedIE24HourExpFlngTrans(objFilingTransactionsEntity.FilerId,
                        objFilingTransactionsEntity.PersonId,
                        objFilingTransactionsEntity.TreasId,
                        objFilingTransactionsEntity.AddrId,
                        objFilingTransactionsEntity.FilingSchedId,
                        objFilingTransactionsEntity.SchedDate,
                        objFilingTransactionsEntity.PaymentTypeId,
                        objFilingTransactionsEntity.PurposeCodeId,
                        objFilingTransactionsEntity.PayNumber,
                        objFilingTransactionsEntity.OrgAmt,
                        objFilingTransactionsEntity.OwedAmt,
                        objFilingTransactionsEntity.TransExplanation,
                        objFilingTransactionsEntity.MunicipalityID,
                        objFilingTransactionsEntity.RAmend,
                        objFilingTransactionsEntity.ElectionDate,
                        objFilingTransactionsEntity.ElectionDateId,
                        objFilingTransactionsEntity.ElectionTypeId,
                        objFilingTransactionsEntity.OfficeTypeId,
                        objFilingTransactionsEntity.ElectYearId,
                        objFilingTransactionsEntity.ElectionYear,
                        objFilingTransactionsEntity.FilingEntId,
                        objFilingTransactionsEntity.FlngEntName,
                        objFilingTransactionsEntity.FlngEntStrName,
                        objFilingTransactionsEntity.FlngEntCity,
                        objFilingTransactionsEntity.FlngEntState,
                        objFilingTransactionsEntity.FlngEntZip,
                        objFilingTransactionsEntity.FlngEntCountry,
                        objFilingTransactionsEntity.TreasurerOccupation,
                        objFilingTransactionsEntity.TreasurerEmployer,
                        objFilingTransactionsEntity.TreasurerStreetAddress,
                        objFilingTransactionsEntity.TreasurerCity,
                        objFilingTransactionsEntity.TreasurerState,
                        objFilingTransactionsEntity.TreasurerZip,
                        objFilingTransactionsEntity.CandBallotPropReference,
                        objFilingTransactionsEntity.IEDescription,
                        objFilingTransactionsEntity.DateIncurredOrgAmtId,
                        objFilingTransactionsEntity.R_Supported,
                        objFilingTransactionsEntity.RLiability,
                        objFilingTransactionsEntity.RSubcontractor,
                        objFilingTransactionsEntity.CreatedBy,
                        objFilingTransactionsEntity.FilingDate);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }
        #endregion AddNonItemIE24HourExpFlngTrans

        #region GetFilingTransIEWeeklyPIDAExpenditureData
        /// <summary>
        /// GetFilingTransIEWeeklyPIDAExpenditureData
        /// </summary>
        /// <param name="objFilingTransDataEntity"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataEntity> GetFilingTransIEWeeklyPIDAExpenditureData(FilingTransDataEntity objFilingTransDataEntity)
        {
            IList<FilingTransactionDataEntity> lstFilingTransactionDataEntity = new List<FilingTransactionDataEntity>();
            FilingTransactionDataEntity objFilingTransactionDataEntity;

            var results = entities.SP_S_NonItemIEWeeklyPIDAExpenditureTrans(objFilingTransDataEntity.FilerId,
                objFilingTransDataEntity.ReportYearId, objFilingTransDataEntity.OfficeTypeId,
                objFilingTransDataEntity.ElectionType, objFilingTransDataEntity.ElectionDateId);

            foreach (var item in results)
            {
                objFilingTransactionDataEntity = new FilingTransactionDataEntity();
                objFilingTransactionDataEntity.FilingTransId = Convert.ToString(item.FILING_TRANS_ID);
                objFilingTransactionDataEntity.FilingSchedId = Convert.ToString(item.FILING_SCHED_ID);
                objFilingTransactionDataEntity.PurposeCodeDesc = item.PURPOSE_CODE_DESC;
                objFilingTransactionDataEntity.PaymentTypeId = Convert.ToString(item.PAYMENT_TYPE_ID);
                objFilingTransactionDataEntity.PurposeCodeId = Convert.ToString(item.PURPOSE_CODE_ID);
                if (item.SUBMIT_DATE != "")
                {
                    if (Convert.ToDateTime(item.SUBMIT_DATE).ToShortDateString() == "1/1/1900")
                        objFilingTransactionDataEntity.SubmissionDate = "";
                    else
                        objFilingTransactionDataEntity.SubmissionDate = item.SUBMIT_DATE;
                }
                else
                {
                    objFilingTransactionDataEntity.SubmissionDate = "";
                }

                if (item.SCHED_DATE != "")
                    objFilingTransactionDataEntity.SchedDate = Convert.ToDateTime(item.SCHED_DATE).ToShortDateString();
                else
                    objFilingTransactionDataEntity.SchedDate = "";
                objFilingTransactionDataEntity.FilingSchedDesc = item.FILING_SCHED_DESC;
                objFilingTransactionDataEntity.FilingEntityId = item.FLNG_ENT_ID;
                objFilingTransactionDataEntity.FilingEntityName = item.FLNG_ENT_NAME;
                objFilingTransactionDataEntity.FilingStreetNumber = item.FLNG_ENT_STR_NUM;
                objFilingTransactionDataEntity.FilingStreetName = item.FLNG_ENT_STR_NAME;
                objFilingTransactionDataEntity.FilingCity = item.FLNG_ENT_CITY;
                objFilingTransactionDataEntity.FilingState = item.FLNG_ENT_STATE;
                objFilingTransactionDataEntity.FilingZip = item.FLNG_ENT_ZIP;
                objFilingTransactionDataEntity.FilingCountry = item.FLNG_ENT_COUNTRY;
                objFilingTransactionDataEntity.PaymentTypeDesc = item.PAYMENT_TYPE_DESC;
                objFilingTransactionDataEntity.PayNumber = item.PAY_NUMBER;
                objFilingTransactionDataEntity.OriginalAmount = String.Format("{0:0.00}", item.ORG_AMT);
                if (item.OWED_AMT != null)
                    objFilingTransactionDataEntity.OwedAmount = String.Format("{0:0.00}", item.OWED_AMT);
                else
                    objFilingTransactionDataEntity.OwedAmount = "";

                objFilingTransactionDataEntity.TransExplanation = item.TRANS_EXPLNTN;
                if (item.R_ITEMIZED == "" || item.R_ITEMIZED == null)
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "Y")
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "N")
                    objFilingTransactionDataEntity.RItemized = "No";
                objFilingTransactionDataEntity.CountyDesc = Convert.ToString(item.CNTY_DESC);
                if (item.R_AMEND == "Y")
                {
                    objFilingTransactionDataEntity.RAmend = "Yes";
                }
                else if (item.R_AMEND == "N")
                {
                    objFilingTransactionDataEntity.RAmend = "No";
                }
                else
                {
                    objFilingTransactionDataEntity.RAmend = item.R_AMEND;
                }
                if (item.R_STATUS == "A")
                {
                    objFilingTransactionDataEntity.RStatus = "Active";
                }
                else if (item.R_STATUS == "I")
                {
                    objFilingTransactionDataEntity.RStatus = "In-Active";
                }
                else if (item.R_STATUS == "P")
                {
                    objFilingTransactionDataEntity.RStatus = "Pending";
                }
                else
                {
                    objFilingTransactionDataEntity.RStatus = item.R_STATUS;
                }
                objFilingTransactionDataEntity.MunicipalityDesc = Convert.ToString(item.MUNICIPALITY_DESC);
                objFilingTransactionDataEntity.PurposeCodeDesc = item.PURPOSE_CODE_DESC;
                objFilingTransactionDataEntity.CreatedDate = item.CREATED_DATE;
                objFilingTransactionDataEntity.TreasurerFirstName = item.PERSON_FIRST_NAME;
                objFilingTransactionDataEntity.TreasurerLastName = item.PERSON_LAST_NAME;
                objFilingTransactionDataEntity.TreasurerMiddleName = item.PERSON_MIDDLE_NAME;
                objFilingTransactionDataEntity.TreasurerOccuptaion = item.TREAS_OCCUPATION;
                objFilingTransactionDataEntity.TreasurerEmployer = item.TREAS_EMPLOYER;
                objFilingTransactionDataEntity.TreasurerStreetAddress = item.ADDR_ADDR1;
                objFilingTransactionDataEntity.TreasurerCity = item.ADDR_CITY;
                objFilingTransactionDataEntity.TreasurerState = item.ADDR_STATE;
                objFilingTransactionDataEntity.TreasurerZip = item.ADDR_ZIP;
                objFilingTransactionDataEntity.IEDescription = item.IE_DESC;
                objFilingTransactionDataEntity.CandBallotPropReference = item.DIST_OFF_CAND_BAL_PROP;
                if (item.R_IE_SUPPORTED == "Y")
                    objFilingTransactionDataEntity.IESupported = "Yes";
                else
                    objFilingTransactionDataEntity.IESupported = "No";
                if (item.R_LIABILITY == "Y")
                    objFilingTransactionDataEntity.RLiability = "Yes";
                else
                    objFilingTransactionDataEntity.RLiability = "No";
                if (item.R_SUBCONTRACTOR == "Y")
                    objFilingTransactionDataEntity.RSubcontractor = "Yes";
                else
                    objFilingTransactionDataEntity.RSubcontractor = "No";
                objFilingTransactionDataEntity.AddrId = item.ADDR_ID;
                objFilingTransactionDataEntity.TreasId = item.TREAS_ID;
                objFilingTransactionDataEntity.DateIncurredOrgAmtId = item.EXISTS_LIAB_TRANS_ID;
                lstFilingTransactionDataEntity.Add(objFilingTransactionDataEntity);
            }

            return lstFilingTransactionDataEntity;
        }
        #endregion GetFilingTransIEWeeklyPIDAExpenditureData

        #region AddNonItemIEWeeklyPIDAExpFlngTrans
        /// <summary>
        /// AddNonItemIEWeeklyPIDAExpFlngTrans
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean AddNonItemIEWeeklyPIDAExpFlngTrans(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var returnValue = entities.SP_I_NonItemizedIEWeeklyPIDAExpFlngTrans(objFilingTransactionsEntity.FilerId,
                        objFilingTransactionsEntity.PersonId,
                        objFilingTransactionsEntity.TreasId,
                        objFilingTransactionsEntity.AddrId,
                        objFilingTransactionsEntity.FilingSchedId,
                        objFilingTransactionsEntity.SchedDate,
                        objFilingTransactionsEntity.PaymentTypeId,
                        objFilingTransactionsEntity.PurposeCodeId,
                        objFilingTransactionsEntity.PayNumber,
                        objFilingTransactionsEntity.OrgAmt,
                        objFilingTransactionsEntity.OwedAmt,
                        objFilingTransactionsEntity.TransExplanation,
                        objFilingTransactionsEntity.MunicipalityID,
                        objFilingTransactionsEntity.RAmend,
                        objFilingTransactionsEntity.ElectionDate,
                        objFilingTransactionsEntity.ElectionDateId,
                        objFilingTransactionsEntity.ElectionTypeId,
                        objFilingTransactionsEntity.OfficeTypeId,
                        objFilingTransactionsEntity.ElectYearId,
                        objFilingTransactionsEntity.ElectionYear,
                        objFilingTransactionsEntity.FilingEntId,
                        objFilingTransactionsEntity.FlngEntName,
                        objFilingTransactionsEntity.FlngEntStrName,
                        objFilingTransactionsEntity.FlngEntCity,
                        objFilingTransactionsEntity.FlngEntState,
                        objFilingTransactionsEntity.FlngEntZip,
                        objFilingTransactionsEntity.FlngEntCountry,
                        objFilingTransactionsEntity.TreasurerOccupation,
                        objFilingTransactionsEntity.TreasurerEmployer,
                        objFilingTransactionsEntity.TreasurerStreetAddress,
                        objFilingTransactionsEntity.TreasurerCity,
                        objFilingTransactionsEntity.TreasurerState,
                        objFilingTransactionsEntity.TreasurerZip,
                        objFilingTransactionsEntity.CandBallotPropReference,
                        objFilingTransactionsEntity.IEDescription,
                        objFilingTransactionsEntity.DateIncurredOrgAmtId,
                        objFilingTransactionsEntity.R_Supported,
                        objFilingTransactionsEntity.RLiability,
                        objFilingTransactionsEntity.RSubcontractor,
                        objFilingTransactionsEntity.CreatedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }
        #endregion AddNonItemIEWeeklyPIDAExpFlngTrans

        #region GetIEWeeklyLiabInccrTransactionTypes
        /// <summary>
        /// GetIEWeeklyLiabInccrTransactionTypes
        /// </summary>
        /// <returns></returns>
        public IList<TransactionTypesEntity> GetIEWeeklyLiabInccrTransactionTypes()
        {
            IList<TransactionTypesEntity> lstTransactionTypesEntity = new List<TransactionTypesEntity>();
            TransactionTypesEntity objTransactionTypesEntity;

            var results = entities.SP_S_TransactionTypeIEWeeklyLiabIncr();

            foreach (var item in results)
            {
                objTransactionTypesEntity = new TransactionTypesEntity();
                objTransactionTypesEntity.FilingSchedId = Convert.ToString(item.FILING_SCHED_ID);
                objTransactionTypesEntity.FilingSchedDesc = item.FILING_SCHED_DESC;
                objTransactionTypesEntity.FilingSchedAbbrev = item.FILING_SCHED_ABBREV;
                lstTransactionTypesEntity.Add(objTransactionTypesEntity);
            }

            return lstTransactionTypesEntity;
        }
        #endregion GetIEWeeklyLiabInccrTransactionTypes

        #region GetNonItemIESchedNPurposeCodes
        /// <summary>
        /// GetNonItemIESchedNPurposeCodes
        /// </summary>
        /// <returns></returns>
        public IList<PurposeCodeEntity> GetNonItemIESchedNPurposeCodes()
        {
            IList<PurposeCodeEntity> lstPurposeCodeEntity = new List<PurposeCodeEntity>();
            PurposeCodeEntity objPurposeCodeEntity;

            var results = entities.SP_S_PurposeCodeNonItemIESchedN();

            foreach (var item in results)
            {
                objPurposeCodeEntity = new PurposeCodeEntity();
                objPurposeCodeEntity.PurposeCodeId = Convert.ToString(item.PURPOSE_CODE_ID);
                objPurposeCodeEntity.PurposeCodeDesc = item.PURPOSE_CODE_DESC;
                objPurposeCodeEntity.PurposeCodeAbbrev = item.PURPOSE_CODE_ABBREV;
                lstPurposeCodeEntity.Add(objPurposeCodeEntity);
            }

            return lstPurposeCodeEntity;
        }
        #endregion GetNonItemIESchedNPurposeCodes

        #region GetFilingTransIEWeeklyLiabIncrData
        /// <summary>
        /// GetFilingTransIEWeeklyLiabIncrData
        /// </summary>
        /// <param name="objFilingTransDataEntity"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataEntity> GetFilingTransIEWeeklyLiabIncrData(FilingTransDataEntity objFilingTransDataEntity)
        {
            IList<FilingTransactionDataEntity> lstFilingTransactionDataEntity = new List<FilingTransactionDataEntity>();
            FilingTransactionDataEntity objFilingTransactionDataEntity;

            var results = entities.SP_S_NonItemIEWeeklyLiabIncrTrans(objFilingTransDataEntity.FilerId,
                objFilingTransDataEntity.ReportYearId, objFilingTransDataEntity.OfficeTypeId,
                objFilingTransDataEntity.ElectionType, objFilingTransDataEntity.ElectionDateId);

            foreach (var item in results)
            {
                objFilingTransactionDataEntity = new FilingTransactionDataEntity();
                objFilingTransactionDataEntity.FilingTransId = Convert.ToString(item.FILING_TRANS_ID);
                objFilingTransactionDataEntity.FilingSchedId = Convert.ToString(item.FILING_SCHED_ID);
                objFilingTransactionDataEntity.PurposeCodeDesc = item.PURPOSE_CODE_DESC;
                objFilingTransactionDataEntity.PaymentTypeId = Convert.ToString(item.PAYMENT_TYPE_ID);
                objFilingTransactionDataEntity.PurposeCodeId = Convert.ToString(item.PURPOSE_CODE_ID);
                if (item.SUBMIT_DATE != "")
                {
                    if (Convert.ToDateTime(item.SUBMIT_DATE).ToShortDateString() == "1/1/1900")
                        objFilingTransactionDataEntity.SubmissionDate = "";
                    else
                        objFilingTransactionDataEntity.SubmissionDate = item.SUBMIT_DATE;
                }
                else
                {
                    objFilingTransactionDataEntity.SubmissionDate = "";
                }

                if (item.SCHED_DATE != "")
                    objFilingTransactionDataEntity.SchedDate = Convert.ToDateTime(item.SCHED_DATE).ToShortDateString();
                else
                    objFilingTransactionDataEntity.SchedDate = "";
                objFilingTransactionDataEntity.FilingSchedDesc = item.FILING_SCHED_DESC;
                objFilingTransactionDataEntity.FilingEntityId = item.FLNG_ENT_ID;
                objFilingTransactionDataEntity.FilingEntityName = item.FLNG_ENT_NAME;
                objFilingTransactionDataEntity.FilingStreetNumber = item.FLNG_ENT_STR_NUM;
                objFilingTransactionDataEntity.FilingStreetName = item.FLNG_ENT_STR_NAME;
                objFilingTransactionDataEntity.FilingCity = item.FLNG_ENT_CITY;
                objFilingTransactionDataEntity.FilingState = item.FLNG_ENT_STATE;
                objFilingTransactionDataEntity.FilingZip = item.FLNG_ENT_ZIP;
                objFilingTransactionDataEntity.FilingCountry = item.FLNG_ENT_COUNTRY;
                objFilingTransactionDataEntity.PaymentTypeDesc = item.PAYMENT_TYPE_DESC;
                objFilingTransactionDataEntity.PayNumber = item.PAY_NUMBER;
                objFilingTransactionDataEntity.OriginalAmount = String.Format("{0:0.00}", item.ORG_AMT);
                if (item.OWED_AMT != null)
                    objFilingTransactionDataEntity.OwedAmount = String.Format("{0:0.00}", item.OWED_AMT);
                else
                    objFilingTransactionDataEntity.OwedAmount = "";

                objFilingTransactionDataEntity.TransExplanation = item.TRANS_EXPLNTN;
                if (item.R_ITEMIZED == "" || item.R_ITEMIZED == null)
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "Y")
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "N")
                    objFilingTransactionDataEntity.RItemized = "No";
                objFilingTransactionDataEntity.CountyDesc = Convert.ToString(item.CNTY_DESC);
                if (item.R_AMEND == "Y")
                {
                    objFilingTransactionDataEntity.RAmend = "Yes";
                }
                else if (item.R_AMEND == "N")
                {
                    objFilingTransactionDataEntity.RAmend = "No";
                }
                else
                {
                    objFilingTransactionDataEntity.RAmend = item.R_AMEND;
                }
                if (item.R_STATUS == "A")
                {
                    objFilingTransactionDataEntity.RStatus = "Active";
                }
                else if (item.R_STATUS == "I")
                {
                    objFilingTransactionDataEntity.RStatus = "In-Active";
                }
                else if (item.R_STATUS == "P")
                {
                    objFilingTransactionDataEntity.RStatus = "Pending";
                }
                else
                {
                    objFilingTransactionDataEntity.RStatus = item.R_STATUS;
                }
                objFilingTransactionDataEntity.MunicipalityDesc = Convert.ToString(item.MUNICIPALITY_DESC);
                objFilingTransactionDataEntity.PurposeCodeDesc = item.PURPOSE_CODE_DESC;
                objFilingTransactionDataEntity.CreatedDate = item.CREATED_DATE;
                objFilingTransactionDataEntity.TreasurerFirstName = item.PERSON_FIRST_NAME;
                objFilingTransactionDataEntity.TreasurerLastName = item.PERSON_LAST_NAME;
                objFilingTransactionDataEntity.TreasurerMiddleName = item.PERSON_MIDDLE_NAME;
                objFilingTransactionDataEntity.TreasurerOccuptaion = item.TREAS_OCCUPATION;
                objFilingTransactionDataEntity.TreasurerEmployer = item.TREAS_EMPLOYER;
                objFilingTransactionDataEntity.ContributorOccupation = item.CREDITOR_OCCUPATION;
                objFilingTransactionDataEntity.ContributorEmployer = item.CREDITOR_EMPLOYER;
                objFilingTransactionDataEntity.TreasurerStreetAddress = item.ADDR_ADDR1;
                objFilingTransactionDataEntity.TreasurerCity = item.ADDR_CITY;
                objFilingTransactionDataEntity.TreasurerState = item.ADDR_STATE;
                objFilingTransactionDataEntity.TreasurerZip = item.ADDR_ZIP;
                objFilingTransactionDataEntity.IEDescription = item.IE_DESC;
                objFilingTransactionDataEntity.CandBallotPropReference = item.DIST_OFF_CAND_BAL_PROP;
                if (item.R_IE_SUPPORTED == "Y")
                    objFilingTransactionDataEntity.IESupported = "Yes";
                else
                    objFilingTransactionDataEntity.IESupported = "No";                              
                objFilingTransactionDataEntity.AddrId = item.ADDR_ID;
                objFilingTransactionDataEntity.TreasId = item.TREAS_ID;                
                lstFilingTransactionDataEntity.Add(objFilingTransactionDataEntity);
            }

            return lstFilingTransactionDataEntity;
        }
        #endregion GetFilingTransIEWeeklyLiabIncrData

        #region GetFilingTransIEWeeklyLiabIncrHistoryData
        /// <summary>
        /// GetFilingTransIEWeeklyLiabIncrHistoryData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataEntity> GetFilingTransIEWeeklyLiabIncrHistoryData(String strFilingTransId)
        {
            IList<FilingTransactionDataEntity> lstFilingTransactionDataEntity = new List<FilingTransactionDataEntity>();
            FilingTransactionDataEntity objFilingTransactionDataEntity;

            var results = entities.SP_S_NonItemIEWeeklyLiabIncrTransHistory(strFilingTransId);

            foreach (var item in results)
            {
                objFilingTransactionDataEntity = new FilingTransactionDataEntity();
                objFilingTransactionDataEntity.FilingTransId = Convert.ToString(item.FILING_TRANS_ID);
                objFilingTransactionDataEntity.FilingSchedId = Convert.ToString(item.FILING_SCHED_ID);
                objFilingTransactionDataEntity.PurposeCodeId = item.PURPOSE_CODE_ID;
                objFilingTransactionDataEntity.PurposeCodeDesc = item.PURPOSE_CODE_DESC;
                objFilingTransactionDataEntity.PaymentTypeId = Convert.ToString(item.PAYMENT_TYPE_ID);
                if (item.SUBMIT_DATE != "")
                {
                    if (Convert.ToDateTime(item.SUBMIT_DATE).ToShortDateString() == "1/1/1900")
                        objFilingTransactionDataEntity.SubmissionDate = "";
                    else
                        objFilingTransactionDataEntity.SubmissionDate = item.SUBMIT_DATE;
                }
                else
                {
                    objFilingTransactionDataEntity.SubmissionDate = "";
                }

                if (item.SCHED_DATE != "")
                    objFilingTransactionDataEntity.SchedDate = Convert.ToDateTime(item.SCHED_DATE).ToShortDateString();
                else
                    objFilingTransactionDataEntity.SchedDate = "";
                objFilingTransactionDataEntity.FilingSchedDesc = item.FILING_SCHED_DESC;
                objFilingTransactionDataEntity.FilingEntityId = item.FLNG_ENT_ID;
                objFilingTransactionDataEntity.FilingEntityName = item.FLNG_ENT_NAME;
                objFilingTransactionDataEntity.FilingStreetNumber = item.FLNG_ENT_STR_NUM;
                objFilingTransactionDataEntity.FilingStreetName = item.FLNG_ENT_STR_NAME;
                objFilingTransactionDataEntity.FilingCity = item.FLNG_ENT_CITY;
                objFilingTransactionDataEntity.FilingState = item.FLNG_ENT_STATE;
                objFilingTransactionDataEntity.FilingZip = item.FLNG_ENT_ZIP;
                objFilingTransactionDataEntity.FilingCountry = item.FLNG_ENT_COUNTRY;
                objFilingTransactionDataEntity.PaymentTypeDesc = item.PAYMENT_TYPE_DESC;
                objFilingTransactionDataEntity.PayNumber = item.PAY_NUMBER;
                objFilingTransactionDataEntity.OriginalAmount = String.Format("{0:0.00}", item.ORG_AMT);
                objFilingTransactionDataEntity.OwedAmount = String.Format("{0:0.00}", item.OWED_AMT);
                objFilingTransactionDataEntity.TransExplanation = item.TRANS_EXPLNTN;
                if (item.R_ITEMIZED == "" || item.R_ITEMIZED == null)
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "Y")
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "N")
                    objFilingTransactionDataEntity.RItemized = "No";
                objFilingTransactionDataEntity.CountyDesc = Convert.ToString(item.CNTY_DESC);
                if (item.R_AMEND == "Y")
                {
                    objFilingTransactionDataEntity.RAmend = "Yes";
                }
                else if (item.R_AMEND == "N")
                {
                    objFilingTransactionDataEntity.RAmend = "No";
                }
                else
                {
                    objFilingTransactionDataEntity.RAmend = item.R_AMEND;
                }
                if (item.R_STATUS == "A")
                {
                    objFilingTransactionDataEntity.RStatus = "Active";
                }
                else if (item.R_STATUS == "I")
                {
                    objFilingTransactionDataEntity.RStatus = "In-Active";
                }
                else if (item.R_STATUS == "P")
                {
                    objFilingTransactionDataEntity.RStatus = "Pending";
                }
                else
                {
                    objFilingTransactionDataEntity.RStatus = item.R_STATUS;
                }
                objFilingTransactionDataEntity.MunicipalityDesc = Convert.ToString(item.MUNICIPALITY_DESC);
                objFilingTransactionDataEntity.PurposeCodeDesc = item.PURPOSE_CODE_DESC;
                objFilingTransactionDataEntity.CreatedDate = item.CREATED_DATE;
                objFilingTransactionDataEntity.TreasurerFirstName = item.PERSON_FIRST_NAME;
                objFilingTransactionDataEntity.TreasurerLastName = item.PERSON_LAST_NAME;
                objFilingTransactionDataEntity.TreasurerMiddleName = item.PERSON_MIDDLE_NAME;
                objFilingTransactionDataEntity.TreasurerOccuptaion = item.TREAS_OCCUPATION;
                objFilingTransactionDataEntity.TreasurerEmployer = item.TREAS_EMPLOYER;
                objFilingTransactionDataEntity.ContributorOccupation = item.CREDITOR_OCCUPATION;
                objFilingTransactionDataEntity.ContributorEmployer = item.CREDITOR_EMPLOYER;
                objFilingTransactionDataEntity.TreasurerStreetAddress = item.ADDR_ADDR1;
                objFilingTransactionDataEntity.TreasurerCity = item.ADDR_CITY;
                objFilingTransactionDataEntity.TreasurerState = item.ADDR_STATE;
                objFilingTransactionDataEntity.TreasurerZip = item.ADDR_ZIP;
                objFilingTransactionDataEntity.CandBallotPropReference = item.DIST_OFF_CAND_BAL_PROP;
                objFilingTransactionDataEntity.IEDescription = item.IE_DESC;
                objFilingTransactionDataEntity.IESupported = item.R_IE_SUPPORTED;
                lstFilingTransactionDataEntity.Add(objFilingTransactionDataEntity);
            }

            return lstFilingTransactionDataEntity;
        }
        #endregion GetFilingTransIEWeeklyLiabIncrHistoryData

        #region AddNonItemIEWeeklyLiabIncrFlngTrans
        /// <summary>
        /// AddNonItemIEWeeklyLiabIncrFlngTrans
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean AddNonItemIEWeeklyLiabIncrFlngTrans(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var returnValue = entities.SP_I_NonItemizedIEWeeklyLiabIncrFlngTrans(objFilingTransactionsEntity.FilerId,
                        objFilingTransactionsEntity.PersonId,
                        objFilingTransactionsEntity.TreasId,
                        objFilingTransactionsEntity.AddrId,
                        objFilingTransactionsEntity.FilingSchedId,
                        objFilingTransactionsEntity.SchedDate,
                        objFilingTransactionsEntity.PaymentTypeId,
                        objFilingTransactionsEntity.PurposeCodeId,
                        objFilingTransactionsEntity.PayNumber,
                        objFilingTransactionsEntity.OrgAmt,
                        objFilingTransactionsEntity.OwedAmt,
                        objFilingTransactionsEntity.TransExplanation,
                        objFilingTransactionsEntity.MunicipalityID,
                        objFilingTransactionsEntity.RAmend,
                        objFilingTransactionsEntity.ElectionDate,
                        objFilingTransactionsEntity.ElectionDateId,
                        objFilingTransactionsEntity.ElectionTypeId,
                        objFilingTransactionsEntity.OfficeTypeId,
                        objFilingTransactionsEntity.ElectYearId,
                        objFilingTransactionsEntity.ElectionYear,
                        objFilingTransactionsEntity.FilingEntId,
                        objFilingTransactionsEntity.FlngEntName,
                        objFilingTransactionsEntity.FlngEntStrName,
                        objFilingTransactionsEntity.FlngEntCity,
                        objFilingTransactionsEntity.FlngEntState,
                        objFilingTransactionsEntity.FlngEntZip,
                        objFilingTransactionsEntity.FlngEntCountry,
                        objFilingTransactionsEntity.TreasurerOccupation,
                        objFilingTransactionsEntity.TreasurerEmployer,
                        objFilingTransactionsEntity.ContributorOccupation,
                        objFilingTransactionsEntity.ContributorEmployer,
                        objFilingTransactionsEntity.TreasurerStreetAddress,
                        objFilingTransactionsEntity.TreasurerCity,
                        objFilingTransactionsEntity.TreasurerState,
                        objFilingTransactionsEntity.TreasurerZip,
                        objFilingTransactionsEntity.CandBallotPropReference,
                        objFilingTransactionsEntity.IEDescription,
                        objFilingTransactionsEntity.DateIncurredOrgAmtId,
                        objFilingTransactionsEntity.R_Supported,                        
                        objFilingTransactionsEntity.CreatedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }
        #endregion AddNonItemIEWeeklyLiabIncrFlngTrans

        #region UpdateIEWeeklyLiabIncrFlngTrans
        /// <summary>
        /// UpdateIEWeeklyLiabIncrFlngTrans
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean UpdateIEWeeklyLiabIncrFlngTrans(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var returnValue = entities.SP_U_NonItemIEWeeklyLiabIncrTrans(objFilingTransactionsEntity.FilingTransId,
                    objFilingTransactionsEntity.FilingSchedId,
                    objFilingTransactionsEntity.FilingEntId,
                    objFilingTransactionsEntity.TreasId,
                    objFilingTransactionsEntity.AddrId,
                    objFilingTransactionsEntity.PersonId,
                    objFilingTransactionsEntity.SubmissionDate,
                    objFilingTransactionsEntity.SchedDate,
                    objFilingTransactionsEntity.PayNumber,
                    objFilingTransactionsEntity.PaymentTypeId,
                    objFilingTransactionsEntity.PurposeCodeId,
                    objFilingTransactionsEntity.OrgAmt,
                    objFilingTransactionsEntity.OwedAmt,
                    objFilingTransactionsEntity.TransExplanation,
                    objFilingTransactionsEntity.FlngEntName,
                    objFilingTransactionsEntity.FlngEntCountry,
                    objFilingTransactionsEntity.FlngEntStrName,
                    objFilingTransactionsEntity.FlngEntCity,
                    objFilingTransactionsEntity.FlngEntState,
                    objFilingTransactionsEntity.FlngEntZip,
                    objFilingTransactionsEntity.TreasurerStreetAddress,
                    objFilingTransactionsEntity.TreasurerCity,
                    objFilingTransactionsEntity.TreasurerState,
                    objFilingTransactionsEntity.TreasurerZip,
                    objFilingTransactionsEntity.IEDescription,
                    objFilingTransactionsEntity.TreasurerOccupation,
                    objFilingTransactionsEntity.TreasurerEmployer,
                    objFilingTransactionsEntity.ContributorOccupation,
                    objFilingTransactionsEntity.ContributorEmployer,
                    objFilingTransactionsEntity.R_Supported,
                    objFilingTransactionsEntity.CandBallotPropReference,                              
                    objFilingTransactionsEntity.ModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }
        #endregion UpdateIEWeeklyLiabIncrFlngTrans

        #region GetFilingMethodData
        /// <summary>
        /// GetFilingMethodData
        /// </summary>
        /// <returns></returns>
        public IList<FilingMthodEntity> GetFilingMethodData()
        {
            IList<FilingMthodEntity> lstFilingMthodEntity = new List<FilingMthodEntity>();
            FilingMthodEntity objFilingMthodEntity;

            var results = entities.SP_S_FilingMethods();

            foreach (var item in results)
            {
                objFilingMthodEntity = new FilingMthodEntity();
                objFilingMthodEntity.FilingMethodId = Convert.ToString(item.FILING_METHOD_ID);
                objFilingMthodEntity.FilingMethodDesc = item.FILING_METHOD_DESC;                
                lstFilingMthodEntity.Add(objFilingMthodEntity);
            }

            return lstFilingMthodEntity;
        }
        #endregion GetFilingMethodData

        #region GetCampaignMaterialData
        /// <summary>
        /// GetCampaignMaterialData
        /// </summary>
        /// <param name="objNonItemCampaignMaterialEntity"></param>
        /// <returns></returns>
        public IList<NonItemCampaignMaterialDataEntity> GetCampaignMaterialData(NonItemCampaignMaterialEntity objNonItemCampaignMaterialEntity)
        {
            IList<NonItemCampaignMaterialDataEntity> lstNonItemCampaignMaterialDataEntity = new List<NonItemCampaignMaterialDataEntity>();
            NonItemCampaignMaterialDataEntity objNonItemCampaignMaterialDataEntity;

            var results = entities.SP_S_NonItemCampaignMaterial(objNonItemCampaignMaterialEntity.FilerId,
                                                                objNonItemCampaignMaterialEntity.ElectionDate,
                                                                objNonItemCampaignMaterialEntity.ElectYearId,
                                                                objNonItemCampaignMaterialEntity.ElectionYear,
                                                                objNonItemCampaignMaterialEntity.ElectionTypeId,
                                                                objNonItemCampaignMaterialEntity.OfficeTypeId,
                                                                objNonItemCampaignMaterialEntity.FilingTypeId,
                                                                objNonItemCampaignMaterialEntity.ElectionDateId,
                                                                objNonItemCampaignMaterialEntity.FilingDate);

            foreach (var item in results)
            {
                objNonItemCampaignMaterialDataEntity = new NonItemCampaignMaterialDataEntity();                
                objNonItemCampaignMaterialDataEntity.CampaignMaterialId = Convert.ToString(item.CAMP_MATR_ID);
                objNonItemCampaignMaterialDataEntity.FilingMethodId = Convert.ToString(item.FILING_METHOD_ID);
                objNonItemCampaignMaterialDataEntity.SacnDocId = Convert.ToString(item.SCAN_DOC_ID);
                if (item.DATE_SUBMITTED != "")
                {
                    if (Convert.ToDateTime(item.DATE_SUBMITTED).ToShortDateString() == "1/1/1900")
                        objNonItemCampaignMaterialDataEntity.DateSubmitted = "";
                    else
                        objNonItemCampaignMaterialDataEntity.DateSubmitted = item.DATE_SUBMITTED;
                }
                else
                {
                    objNonItemCampaignMaterialDataEntity.DateSubmitted = "";
                }
                objNonItemCampaignMaterialDataEntity.CampaignMaterialDesc = item.CAMP_MATR_DESC;
                objNonItemCampaignMaterialDataEntity.FilingMethodDesc = item.FILING_METHOD_DESC;
                if (item.R_CAMP_MATR == "Y")
                    objNonItemCampaignMaterialDataEntity.RCampMatr = "Yes";
                else
                    objNonItemCampaignMaterialDataEntity.RCampMatr = "No";
                objNonItemCampaignMaterialDataEntity.CreatedDate = item.CREATED_DATE.ToShortDateString();
                objNonItemCampaignMaterialDataEntity.CampMatrFileType = item.CAMP_MATR_FILE_TYPE;
                objNonItemCampaignMaterialDataEntity.CampMatrFileSize = item.CAMP_MATR_FILE_SIZE;
                lstNonItemCampaignMaterialDataEntity.Add(objNonItemCampaignMaterialDataEntity);
            }

            return lstNonItemCampaignMaterialDataEntity;
        }
        #endregion GetCampaignMaterialData

        #region AddNonItemCampaignMaterial
        /// <summary>
        /// AddNonItemCampaignMaterial
        /// </summary>
        /// <param name="objNonItemCampaignMaterialEntity"></param>
        /// <returns></returns>
        public Boolean AddNonItemCampaignMaterial(NonItemCampaignMaterialEntity objNonItemCampaignMaterialEntity)
        {
            var returnValue = entities.SP_I_NonItem_CampaignMaterial(objNonItemCampaignMaterialEntity.FilerId,
                        objNonItemCampaignMaterialEntity.ElectionDate,
                        objNonItemCampaignMaterialEntity.ElectionDateId,
                        objNonItemCampaignMaterialEntity.ElectionTypeId,
                        objNonItemCampaignMaterialEntity.OfficeTypeId,
                        objNonItemCampaignMaterialEntity.FilingTypeId,
                        objNonItemCampaignMaterialEntity.FilingCategoryId,
                        objNonItemCampaignMaterialEntity.ElectYearId,
                        objNonItemCampaignMaterialEntity.ElectionYear,
                        objNonItemCampaignMaterialEntity.CountyId,
                        objNonItemCampaignMaterialEntity.MunicipalityId,
                        objNonItemCampaignMaterialEntity.DateSubmitted,
                        objNonItemCampaignMaterialEntity.FilingMethodId,
                        objNonItemCampaignMaterialEntity.CampaignMaterialDesc,
                        objNonItemCampaignMaterialEntity.SacnDocId,
                        objNonItemCampaignMaterialEntity.CampMatrFileType,
                        objNonItemCampaignMaterialEntity.CampMatrFileSize,
                        objNonItemCampaignMaterialEntity.RCampMatr,
                        objNonItemCampaignMaterialEntity.CreatedBy,
                        objNonItemCampaignMaterialEntity.FilingDate);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }
        #endregion AddNonItemCampaignMaterial

        #region DeleteCampaignMaterial
        /// <summary>
        /// DeleteCampaignMaterial
        /// </summary>
        /// <param name="strCampMatrId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        public Boolean DeleteCampaignMaterial(String strCampMatrId, String strModifiedBy)
        {
            var returnValue = entities.SP_D_NonItemCampaignMaterial(strCampMatrId, strModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }
        #endregion DeleteCampaignMaterial               

        //========================================================================================================================================
        // NON-ITEMIZED TRANSACTIONS - END >>>>>>>>>>>>>>>
        //========================================================================================================================================

        //========================================================================================================================================
        // COMMON METHOD FOR DROPDOWN VALUES VALIDATION.
        //========================================================================================================================================

        #region GetDropdownValueExists
        /// <summary>
        /// GetDropdownValueExists
        /// </summary>
        /// <param name="strTableName"></param>
        /// <param name="strDropdownValue"></param>
        /// <returns></returns>
        public Boolean GetDropdownValueExists(String strTableName, String strDropdownValue)
        {
            Boolean dropdownValExists = false;

            var results = entities.SP_S_EFSDropdownValExists(strTableName, strDropdownValue);

            foreach (var item in results)
            {
                if (item.RETURN_VALUE.ToString() == "TRUE")
                    dropdownValExists = true;
                else
                    dropdownValExists = false;
            }

            return dropdownValExists;
        }
        #endregion GetDropdownValueExists

        //========================================================================================================================================
        // COMMON METHOD FOR DROPDOWN VALUES VALIDATION.
        //========================================================================================================================================

        #region GetFilingDateOffCycleData
        /// <summary>
        /// GetFilingDateOffCycleData
        /// </summary>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <returns></returns>
        public IList<FilingDatesOffCycleEntity> GetFilingDateOffCycleData(String strElectionYearId, String strOfficeTypeId, String strFilerId)
        {
            IList<FilingDatesOffCycleEntity> lstFilingDatesOffCycleEntity = new List<FilingDatesOffCycleEntity>();
            FilingDatesOffCycleEntity objFilingDatesOffCycleEntity;

            var results = entities.SP_S_FilingDatesOffCycle(strElectionYearId, strOfficeTypeId, strFilerId);

            foreach (var item in results)
            {
                objFilingDatesOffCycleEntity = new FilingDatesOffCycleEntity();
                objFilingDatesOffCycleEntity.FilingDateId = Convert.ToString(item.FILINGS_ID);
                objFilingDatesOffCycleEntity.FilingDate = item.FILING_DATE;
                lstFilingDatesOffCycleEntity.Add(objFilingDatesOffCycleEntity);
            }

            return lstFilingDatesOffCycleEntity;
        }
        #endregion GetFilingDateOffCycleData

        #region GetFilingDateIEWeeklyeData
        /// <summary>
        /// GetFilingDateIEWeeklyeData
        /// </summary>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strFilingType"></param>
        /// <param name="strFilingCatId"></param>
        /// <param name="strElectionDateId"></param>
        /// <returns></returns>
        public IList<FilingDatesOffCycleEntity> GetFilingDateIEWeeklyeData(String strElectionYearId, String strElectionTypeId, String strOfficeTypeId, String strFilerId,  String strFilingType, String strFilingCatId, String strElectionDateId)
        {
            IList<FilingDatesOffCycleEntity> lstFilingDatesOffCycleEntity = new List<FilingDatesOffCycleEntity>();
            FilingDatesOffCycleEntity objFilingDatesOffCycleEntity;

            var results = entities.SP_S_FilingDatesIEWeekly(strElectionYearId, strElectionTypeId, strOfficeTypeId, strFilerId, strFilingType, strFilingCatId, strElectionDateId);

            foreach (var item in results)
            {
                objFilingDatesOffCycleEntity = new FilingDatesOffCycleEntity();
                objFilingDatesOffCycleEntity.FilingDateId = Convert.ToString(item.FILINGS_ID);
                objFilingDatesOffCycleEntity.FilingDate = item.FILING_DATE;
                lstFilingDatesOffCycleEntity.Add(objFilingDatesOffCycleEntity);
            }

            return lstFilingDatesOffCycleEntity;
        }
        #endregion GetFilingDateIEWeeklyeData

        #region GeResigTermTypeData
        /// <summary>
        /// GeResigTermTypeData
        /// </summary>
        /// <returns></returns>
        public IList<ResigTermTypeEntity> GeResigTermTypeData()
        {
            IList<ResigTermTypeEntity> lstResigTermTypeEntity = new List<ResigTermTypeEntity>();
            ResigTermTypeEntity objResigTermTypeEntity;

            var results = entities.SP_S_ResignationTerminationType();

            foreach (var item in results)
            {
                objResigTermTypeEntity = new ResigTermTypeEntity();
                objResigTermTypeEntity.ResigTermTypeId = Convert.ToString(item.RESIG_TERM_TYPE_ID);
                objResigTermTypeEntity.ResigTermTypeDesc = Convert.ToString(item.RESIG_TERM_TYPE_DESC);
                lstResigTermTypeEntity.Add(objResigTermTypeEntity);
            }

            return lstResigTermTypeEntity;
        }
        #endregion GeResigTermTypeData

        #region GetResgTermTypeExistValue
        /// <summary>
        /// GetResgTermTypeExistValue
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <param name="strElectionYearId"></param>
        /// <returns></returns>
        public IList<ResigTermTypeEntity> GetResgTermTypeExistsValue(String strFilerId, String strElectionTypeId, String strOfficeTypeId, String strFilingTypeId, String strElectionYearId, String strElectionDateId, String strFilingDate, String strFilingCategoryId)
        {
            IList<ResigTermTypeEntity> lstResigTermTypeEntity = new List<ResigTermTypeEntity>();
            ResigTermTypeEntity objResigTermTypeEntity;

            var results = entities.SP_S_GetFilingsResgTermType(strFilerId, strElectionTypeId, strOfficeTypeId, strFilingTypeId, strElectionYearId, strElectionDateId, strFilingDate, strFilingCategoryId);

            foreach (var item in results)
            {
                objResigTermTypeEntity = new ResigTermTypeEntity();
                objResigTermTypeEntity.ResigTermTypeId = Convert.ToString(item.RESIG_TERM_TYPE_ID);
                objResigTermTypeEntity.ResigTermTypeDesc = Convert.ToString(item.RESIG_TERM_TYPE_DESC);
                objResigTermTypeEntity.FilingsId = Convert.ToString(item.FILINGS_ID);
                lstResigTermTypeEntity.Add(objResigTermTypeEntity);
            }

            return lstResigTermTypeEntity;
        }
        #endregion GetResgTermTypeExistValue

        #region UpdateResgTermTypeFilings
        /// <summary>
        /// UpdateResgTermTypeFilings
        /// </summary>
        /// <param name="strFilingsId"></param>
        /// <param name="strResgTermTypeId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        public Boolean UpdateResgTermTypeFilings(String strFilingsId, String strResgTermTypeId, String strModifiedBy)
        {
            var returnValue = entities.SP_U_FilingsResgTermType(strFilingsId, strResgTermTypeId, strModifiedBy);

            if (returnValue >= 1)
                return true;
            else
                return false;
        }
        #endregion UpdateResgTermTypeFilings

        #region GetEelectionExistsEFS
        /// <summary>
        /// GetEelectionExistsEFS
        /// </summary>
        /// <param name="strElectionYearId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strElectionDateId"></param>
        /// <returns></returns>
        public Boolean GetEelectionExistsEFS(String strElectionYearId, String strElectionTypeId, String strOfficeTypeId, String strElectionDateId)
        {
            Boolean electionExists = false;

            var results = entities.SP_S_EFSElectionExists(strElectionYearId, strElectionTypeId, strOfficeTypeId, strElectionDateId);

            foreach (var item in results)
            {
                if (item.RETURN_VALUE.ToString() == "TRUE")
                    electionExists = true;
                else
                    electionExists = false;
            }

            return electionExists;
        }
        #endregion GetEelectionExistsEFS

        /// <summary>
        /// Get Filer Information
        /// </summary>
        /// <param name="filerID"></param>
        /// <param name="person_ID"></param>
        /// <returns></returns>
        public IList<FilerInfo> GetFilerInforamation(String filerID, String person_ID)
        {
            IList<FilerInfo> listFilerInfo = new List<FilerInfo>();
            FilerInfo objFilerInfo;
            //data from stored procedure
            var results = entities.SP_S_GetFilerINFO(filerID, person_ID);

            foreach (var item in results)
            {
                //create GetDistrictsEntity object
                objFilerInfo = new FilerInfo();
                //modify object's attributes
                objFilerInfo.Trans_Cand_ID = Convert.ToString(item.TRASN_CAND_ID);
                objFilerInfo.Filer_ID = Convert.ToString(item.FILER_ID);
                objFilerInfo.Cand_Comm_ID = Convert.ToString(item.CAND_COMM_ID);
                objFilerInfo.Cand_Comm_Name = Convert.ToString(item.CAND_COMM_NAME);
                objFilerInfo.PersonID = Convert.ToString(item.PERSON_ID);
                objFilerInfo.Name = Convert.ToString(item.NAME);
                //add object to list
                listFilerInfo.Add(objFilerInfo);
            }
            return listFilerInfo;
        }

        /// <summary>
        /// Transfer Outstanding balance in Sched N
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public string TransferOutStandingBalance(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            String strResult_value = String.Empty;
            var result = entities.SP_I_TRANSFER_OUTSTANDING_BALANCE(objFilingTransactionsEntity.FilerId,
                                                                    objFilingTransactionsEntity.ElectionTypeId,
                                                                    objFilingTransactionsEntity.OfficeTypeId,
                                                                    objFilingTransactionsEntity.FilingTypeId,
                                                                    objFilingTransactionsEntity.ElectYearId,
                                                                    objFilingTransactionsEntity.FilingDate,
                                                                    objFilingTransactionsEntity.ElectionDateId,
                                                                    objFilingTransactionsEntity.ResigTermTypeId,
                                                                    objFilingTransactionsEntity.CreatedBy);

            foreach (var item in result)
            {
                strResult_value = item.RETURN_VALUE.ToString();
            }
            return strResult_value;
        }

        /// <summary>
        /// Submit filings from Summery Page
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean SubmitFilings_Summery(FilingTransactionsEntity objFilingTransactionsEntity)
        {
            var result = entities.SP_I_SUBMIT_FILINGS(objFilingTransactionsEntity.FilerId,
                                                                        objFilingTransactionsEntity.OfficeTypeId,
                                                                        objFilingTransactionsEntity.FilingTypeId,
                                                                        objFilingTransactionsEntity.ElectYearId,
                                                                        objFilingTransactionsEntity.FilingDate,
                                                                        objFilingTransactionsEntity.CreatedBy);

            if (result >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// GetFilingTransactionsData
        /// </summary>
        /// <param name="objFilingTransDataEntity"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataEntity> GetFilingTransactionsDataSummary(FilingTransDataEntity objFilingTransDataEntity)
        {
            IList<FilingTransactionDataEntity> lstFilingTransactionDataEntity = new List<FilingTransactionDataEntity>();
            FilingTransactionDataEntity objFilingTransactionDataEntity;

            var results = entities.SP_S_Filing_Transactions_Data_Summary(objFilingTransDataEntity.FilerId,
                objFilingTransDataEntity.ReportYearId, objFilingTransDataEntity.OfficeTypeId,
                objFilingTransDataEntity.DisclosurePeriod, objFilingTransDataEntity.FilingSchedID, objFilingTransDataEntity.ElectionType,
                objFilingTransDataEntity.ElectionDateId,objFilingTransDataEntity.FilingDate);

            foreach (var item in results)
            {
                objFilingTransactionDataEntity = new FilingTransactionDataEntity();
                objFilingTransactionDataEntity.FilingTransId = Convert.ToString(item.FILING_TRANS_ID);
                objFilingTransactionDataEntity.FilingSchedId = Convert.ToString(item.FILING_SCHED_ID);
                objFilingTransactionDataEntity.ContributorTypeId = Convert.ToString(item.CNTRBR_TYPE_ID);
                objFilingTransactionDataEntity.ContributorTypeDesc = item.CNTRBR_TYPE_DESC;
                objFilingTransactionDataEntity.ContributionTypeId = Convert.ToString(item.CNTRBN_TYPE_ID);
                objFilingTransactionDataEntity.PaymentTypeId = Convert.ToString(item.PAYMENT_TYPE_ID);
                if (item.SCHED_DATE != "")
                    objFilingTransactionDataEntity.SchedDate = Convert.ToDateTime(item.SCHED_DATE).ToShortDateString();
                else
                    objFilingTransactionDataEntity.SchedDate = "";
                objFilingTransactionDataEntity.FilingSchedDesc = item.FILING_SCHED_DESC;
                objFilingTransactionDataEntity.FilingEntityId = item.FLNG_ENT_ID;
                objFilingTransactionDataEntity.FilingEntityName = item.FLNG_ENT_NAME;
                objFilingTransactionDataEntity.FilingFirstName = item.FLNG_ENT_FIRST_NAME;
                objFilingTransactionDataEntity.FilingMiddleName = item.FLNG_ENT_MIDDLE_NAME;
                objFilingTransactionDataEntity.FilingLastName = item.FLNG_ENT_LAST_NAME;
                objFilingTransactionDataEntity.FilingStreetNumber = item.FLNG_ENT_STR_NUM;
                objFilingTransactionDataEntity.FilingStreetName = item.FLNG_ENT_STR_NAME;
                objFilingTransactionDataEntity.FilingCity = item.FLNG_ENT_CITY;
                objFilingTransactionDataEntity.FilingState = item.FLNG_ENT_STATE;
                objFilingTransactionDataEntity.FilingZip = item.FLNG_ENT_ZIP;
                objFilingTransactionDataEntity.FilingCountry = item.FLNG_ENT_COUNTRY;
                objFilingTransactionDataEntity.PaymentTypeDesc = item.PAYMENT_TYPE_DESC;
                objFilingTransactionDataEntity.PayNumber = item.PAY_NUMBER;
                objFilingTransactionDataEntity.OriginalAmount = String.Format("{0:0.00}", item.ORG_AMT);
                objFilingTransactionDataEntity.ReceiptTypeDesc = item.RECEIPT_TYPE_ABBREV;
                objFilingTransactionDataEntity.TransferTypeDesc = item.TRANSFER_TYPE_ABBREV;
                objFilingTransactionDataEntity.ContributionTypeDesc = item.CNTRBN_TYPE_DESC;
                objFilingTransactionDataEntity.PurposeCodeDesc = item.PURPOSE_CODE_ABBREV;
                objFilingTransactionDataEntity.ReceiptCodeDesc = item.RECEIPT_CODE_DESC;
                objFilingTransactionDataEntity.ReceiptCodeId = item.RECEIPT_CODE_ID;
                objFilingTransactionDataEntity.RLiability = item.R_LIABILITY;
                objFilingTransactionDataEntity.RSubcontractor = item.R_SUBCONTRACTOR;
                if (item.ORG_DATE != "")
                    objFilingTransactionDataEntity.OriginalDate = Convert.ToDateTime(item.ORG_DATE).ToShortDateString();
                else
                    objFilingTransactionDataEntity.OriginalDate = "";
                //objFilingTransactionDataEntity.LoanerCode = item.R_BANK_LOAN;
                objFilingTransactionDataEntity.ElectionYear = item.ELECTION_YEAR;
                objFilingTransactionDataEntity.Office = Convert.ToString(item.OFFICE_ID);
                objFilingTransactionDataEntity.District = Convert.ToString(item.DISTRICT);
                objFilingTransactionDataEntity.TransExplanation = item.TRANS_EXPLNTN;
                objFilingTransactionDataEntity.OwedAmount = String.Format("{0:0.00}", item.OWED_AMT);
                if (item.R_ITEMIZED == "" || item.R_ITEMIZED == null)
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "Y")
                    objFilingTransactionDataEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "N")
                    objFilingTransactionDataEntity.RItemized = "No";
                objFilingTransactionDataEntity.CountyID = Convert.ToString(item.COUNTY_ID);
                objFilingTransactionDataEntity.CountyDesc = Convert.ToString(item.CNTY_DESC);
                objFilingTransactionDataEntity.MunicipalityID = Convert.ToString(item.MUNICIPALITY_ID);
                objFilingTransactionDataEntity.MunicipalityDesc = Convert.ToString(item.MUNICIPALITY_DESC);
                objFilingTransactionDataEntity.LoanerCodeId = Convert.ToString(item.LOAN_OTHER_ID);
                objFilingTransactionDataEntity.LoanerCode = Convert.ToString(item.LOAN_OTHER_DESC);
                objFilingTransactionDataEntity.Increased = Convert.ToString(item.INCREASED);
                objFilingTransactionDataEntity.Decreased = Convert.ToString(item.DECREASED);
                objFilingTransactionDataEntity.Balance = Convert.ToString(item.BALANCE);
                objFilingTransactionDataEntity.CreatedDate = Convert.ToString(item.CREATED_DATE);
                objFilingTransactionDataEntity.LoanLiablityNumber = Convert.ToString(item.LOAN_LIB_NUMBER);
                objFilingTransactionDataEntity.TransNumber = Convert.ToString(item.TRANS_NUMBER);
                objFilingTransactionDataEntity.TransMapping = Convert.ToString(item.TRANS_MAPPING);
                lstFilingTransactionDataEntity.Add(objFilingTransactionDataEntity);
            }

            return lstFilingTransactionDataEntity;
        }

        /// <summary>
        /// Get Opening Balance of Disclosure Summery
        /// </summary>
        /// <param name="filerID"></param>
        /// <param name="election_Year_ID"></param>
        /// <param name="office_Type_ID"></param>
        /// <param name="filing_Type_ID"></param>
        /// <param name="election_Date"></param>
        /// <returns></returns>
        public String GetSummery_OpeningBalance(String filerID, String election_Year_ID, String office_Type_ID, String filing_Type_ID, String election_Date, String filing_Date)
        {
            String strOpeningBalance = String.Empty;

            var results = entities.SP_S_Get_Opening_Balance(filerID, election_Year_ID, office_Type_ID, filing_Type_ID, filing_Date);

            foreach (var item in results)
            {
                strOpeningBalance = item.OPENING_BALANCE.ToString();
            }

            return strOpeningBalance;
        }
        
        /// <summary>
        /// Get Closing Balance of Summery page
        /// </summary>
        /// <param name="filerID"></param>
        /// <param name="election_Year_ID"></param>
        /// <param name="office_Type_ID"></param>
        /// <param name="filing_Type_ID"></param>
        /// <returns></returns>
        public String GetSummery_ClosingBalance(String filerID, String election_Year_ID, String office_Type_ID, String filing_Type_ID, String filing_date)
        {
            String strClosingBalance = String.Empty;

            var results = entities.SP_S_Get_Closing_Balance(filerID, election_Year_ID, office_Type_ID, filing_Type_ID, filing_date);

            foreach (var item in results)
            {
                strClosingBalance = item.CLOSING_BALANCE.ToString();
            }

            return strClosingBalance;
        }


        /// <summary>
        /// Get All Scheduled Balances
        /// </summary>
        /// <param name="filerID"></param>
        /// <param name="election_Year_ID"></param>
        /// <param name="office_Type_ID"></param>
        /// <param name="filing_Type_ID"></param>
        /// <param name="filing_date"></param>
        /// <param name="filingSchedID"></param>
        /// <returns></returns>
        public String GetSummery_AllSchedBalances(String filerID, String election_Year_ID, String office_Type_ID, String filing_Type_ID, String filing_date, String filingSchedID)
        {
            String strClosingBalance = String.Empty;

            var results = entities.SP_S_Get_Summery_Balances(filerID, election_Year_ID, office_Type_ID, filing_Type_ID, filing_date, filingSchedID);

            foreach (var item in results)
            {
                strClosingBalance = item.TOTAL_CONTRIBUTION.ToString();
            }

            return strClosingBalance;
        }

        #region GetOfficeTypeEFS
        /// <summary>
        /// GetOfficeTypeEFS
        /// </summary>
        /// <returns></returns>
        public IList<OfficeTypeEntity> GetOfficeTypeEFS(String strElectionYear)
        {
            IList<OfficeTypeEntity> lstOfficeTypeEntity = new List<OfficeTypeEntity>();
            OfficeTypeEntity objOfficeTypeEntity;

            var results = entities.SP_S_OfficeTypesEFS(Convert.ToInt32(strElectionYear));

            foreach (var item in results)
            {
                objOfficeTypeEntity = new OfficeTypeEntity();
                objOfficeTypeEntity.OfficeTypeId = Convert.ToString(item.OFFICE_TYPE_ID);
                objOfficeTypeEntity.OfficeTypeDesc = item.OFFICE_TYPE_DESC;
                lstOfficeTypeEntity.Add(objOfficeTypeEntity);
            }

            return lstOfficeTypeEntity;
        }
        #endregion GetOfficeTypeEFS

        // Creighton Newsom
        // ViewAllDisclosures Page
        #region "ViewAllDisclosures"

        #region "GetOfficeTypeForFilerID"
        // FUNCTION POPULATES OFFICETYPES FOR THE FILTER DROPDOWNS
        public IList<OfficeTypeEntity> GetOfficeTypeForFilerID(String strElectYearID, String strFilerID)
        {
            IList<OfficeTypeEntity> listOfficeTypeEntity = new List<OfficeTypeEntity>();

            OfficeTypeEntity objOfficeTypeEntity;

            //data from stored procedure
            var results = entities.SP_S_OfficeTypesForFilerID(strElectYearID, strFilerID);

            foreach (var item in results)
            {
                //create OfficeTypeEntity object
                objOfficeTypeEntity = new OfficeTypeEntity();

                //modify object's attributes
                objOfficeTypeEntity.OfficeTypeId = Convert.ToString(item.OFFICE_TYPE_ID);
                objOfficeTypeEntity.OfficeTypeDesc = Convert.ToString(item.OFFICE_TYPE_DESC);

                //add object to list
                listOfficeTypeEntity.Add(objOfficeTypeEntity);
            }

            return listOfficeTypeEntity;
        }
        #endregion

        #region "GetElectionTypeForFilerID"
        // THIS FUNCTION GETS THE DATA FOR THE ELECTIONTYPE FILTER DROPDOWN
        public IList<ElectionTypeEntity> GetElectionTypeForFilerID(String strElectYearID, String strOfficeTypeID, String strCountyID, String strMunicipalityID, String strFilerID)
        {
            IList<ElectionTypeEntity> listElectionTypeEntity = new List<ElectionTypeEntity>();

            ElectionTypeEntity objElectionTypeEntity;

            //data from stored procedure
            var results = entities.SP_S_ElectionTypesForFilerID(strElectYearID, strOfficeTypeID, strCountyID, strMunicipalityID, strFilerID);

            foreach (var item in results)
            {
                //create ElectionTypeEntity object
                objElectionTypeEntity = new ElectionTypeEntity();

                //modify object's attributes
                objElectionTypeEntity.ElectionTypeId = Convert.ToString(item.ELECT_TYPE_ID);
                objElectionTypeEntity.ElectionTypeDesc = Convert.ToString(item.ELECT_TYPE_DESC);

                //add object to list
                listElectionTypeEntity.Add(objElectionTypeEntity);
            }

            return listElectionTypeEntity;
        }
        #endregion

        #region "GetElectionDate"
        // THIS FUNCTION GETS THE DATA FOR THE ELECTIONDATE FILTER DROPDOWN
        public IList<ElectionDateEntity> GetElectionDate(string electionYearID, string electionTypeID, string officeTypeID)
        {
            IList<ElectionDateEntity> listElectionDateEntity = new List<ElectionDateEntity>();

            ElectionDateEntity objElectionDateEntity;

            //data from stored procedure
            var results = entities.SP_S_ElectionDate(electionYearID, electionTypeID, officeTypeID);

            foreach (var item in results)
            {
                //create ElectionDateEntity object
                objElectionDateEntity = new ElectionDateEntity();

                //modify object's attributes
                objElectionDateEntity.ElectId = Convert.ToString(item.POL_CAL_DATE_ID);
                objElectionDateEntity.ElectDate = Convert.ToString(item.ELECTION_DATE);

                //add object to list
                listElectionDateEntity.Add(objElectionDateEntity);
            }

            return listElectionDateEntity;
        }
        #endregion

        #region "GetCounty"
        // THIS FUNCTION GETS THE DATA FOR THE COUNTY FILTER DROPDOWN
        public IList<CountyEntity> GetCounty(int officeTypeID)
        {
            IList<CountyEntity> listCountyEntity = new List<CountyEntity>();

            CountyEntity objCountyEntity;

            //data from stored procedure
            var results = entities.SP_S_County(officeTypeID);

            foreach (var item in results)
            {
                //create CountyEntity object
                objCountyEntity = new CountyEntity();

                //modify object's attributes
                objCountyEntity.CountyId = Convert.ToString(item.COUNTY_ID);
                objCountyEntity.CountyDesc = Convert.ToString(item.CNTY_BOARD);

                //add object to list
                listCountyEntity.Add(objCountyEntity);
            }

            return listCountyEntity;
        }
        #endregion

        #region "GetMunicipality"
        // THIS FUNCTION GETS THE DATA FOR THE MUNICIPALITY FILTER DROPDOWN
        public IList<MunicipalityEntity> GetMunicipality(int countyID)
        {
            IList<MunicipalityEntity> listMunicipalityEntity = new List<MunicipalityEntity>();

            MunicipalityEntity objMunicipalityEntity;

            //data from stored procedure
            var results = entities.SP_S_Muncipality(countyID);

            foreach (var item in results)
            {
                //create MunicipalityEntity object
                objMunicipalityEntity = new MunicipalityEntity();

                //modify object's attributes
                objMunicipalityEntity.MunicipalityId = Convert.ToString(item.MUNICIPALITY_ID);
                objMunicipalityEntity.MunicipalityDesc = Convert.ToString(item.MUNICIPALITY_DESC);

                //add object to list
                listMunicipalityEntity.Add(objMunicipalityEntity);
            }

            return listMunicipalityEntity;
        }
        #endregion


        #region "GetDisclosurePeriodsForYearAndFilerIDAndElectionType"
        // THIS FUNCTION GETS THE DISCLOSURE PERIODS FOR THE FILTER DROPDOWN
        public IList<DisclosurePreiodEntity> GetDisclosurePeriodsForYearAndFilerIDAndElectionType(String strFilerID, String strElectionYearID, String strElectionTypeID)
        {
            IList<DisclosurePreiodEntity> lstDisclosurePreiodEntity = new List<DisclosurePreiodEntity>();
            DisclosurePreiodEntity objDisclosurePreiodEntity;

            var results = entities.SP_S_DisclosurePeriodsForYearAndFilerIDAndElectionType(strFilerID, strElectionYearID, strElectionTypeID);

            foreach (var item in results)
            {
                objDisclosurePreiodEntity = new DisclosurePreiodEntity();
                objDisclosurePreiodEntity.FilingTypeId = Convert.ToString(item.FILING_TYPE_ID);
                objDisclosurePreiodEntity.FilingDesc = item.FILING_DESC;
                objDisclosurePreiodEntity.FilingAbbrev = item.FILING_ABBREV;
                lstDisclosurePreiodEntity.Add(objDisclosurePreiodEntity);
            }

            return lstDisclosurePreiodEntity;
        }
        #endregion

        #region "GetDisclosureTypesForYearAndFilerID"
        // THIS FUNCTION GETS THE DISCLOSURE TYPES FOR THE FILTER DROPDOWN
        public IList<DisclosureTypesEntity> GetDisclosureTypesForYearAndFilerID(String strFilerID, String strElectYearID, String strElectTypeID)
        {
            IList<DisclosureTypesEntity> lstDisclosureTypesEntity = new List<DisclosureTypesEntity>();
            DisclosureTypesEntity objDisclosureTypesEntity;

            var results = entities.SP_S_DisclosureTypesForYearAndFilerID(strFilerID, strElectYearID, strElectTypeID);

            foreach (var item in results)
            {
                objDisclosureTypesEntity = new DisclosureTypesEntity();
                objDisclosureTypesEntity.DisclosureTypeId = Convert.ToString(item.FILING_CAT_ID);
                objDisclosureTypesEntity.DisclosureTypeDesc = item.FILING_CAT_DESC;
                objDisclosureTypesEntity.DisclosureSubTypeDesc = item.FILING_CAT_SUBTYPE;
                lstDisclosureTypesEntity.Add(objDisclosureTypesEntity);
            }

            return lstDisclosureTypesEntity;
        }
        #endregion

        #region "GetElectionYearDataForFilerID"
        // THIS FUNCTION GETS THE ELECTION YEARS FOR THE FILTER DROPDOWN
        public IList<ElectionYearEntity> GetElectionYearDataForFilerID(String strFilerID)
        {
            IList<ElectionYearEntity> lstElectionYearEntity = new List<ElectionYearEntity>();
            ElectionYearEntity objElectionYearEntity;

            var results = entities.SP_S_GetElectionYearsForFilerID(strFilerID);

            foreach (var item in results)
            {
                objElectionYearEntity = new ElectionYearEntity();
                objElectionYearEntity.ElectionYearId = Convert.ToString(item.ELECTION_YEAR_ID);
                objElectionYearEntity.ElectionYearValue = Convert.ToString(item.ELECT_YEAR);
                lstElectionYearEntity.Add(objElectionYearEntity);
            }

            return lstElectionYearEntity;
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
            String strCreatedBy)
        {
            int result = entities.SP_I_InsertSupportingDocuments(strTransNumber, strFilingMethodID, strDocTypeID, strScanDocID, strFileType, strFileSize, strCreatedBy);
            return result.ToString();
        }
        #endregion

        #region "GetTransactionsGridData"
        // GETS THE DATA FOR THE TRANSACTION GRID
        public IList<TransactionGridEntity> GetTransactionsGridData(String strFilingsID, String strPolCalDateID, String strAmended, String strR_Status, String strDateSubmitted)
        {
            IList<TransactionGridEntity> lstTransactionsGrid = new List<TransactionGridEntity>();
            TransactionGridEntity objTransactionsGrid;

            var results = entities.SP_S_GetTransactionsGridData(strFilingsID, strPolCalDateID, strAmended, strR_Status, strDateSubmitted);

            foreach (var item in results)
            {
                objTransactionsGrid = new TransactionGridEntity();

                objTransactionsGrid.Amount = Convert.ToString(item.AMOUNT);
                objTransactionsGrid.CheckNum = item.CHECK_NUM;
                objTransactionsGrid.City = item.FLNG_ENT_CITY;
                objTransactionsGrid.ContributionType = item.CONTRIBUTION_TYPE;
                objTransactionsGrid.ContributorCode = item.CONTRIBUTOR_CODE;
                objTransactionsGrid.Country = item.FLNG_ENT_COUNTRY;
                objTransactionsGrid.County = item.COUNTY;
                objTransactionsGrid.ElectionYear = item.ELECTION_YEAR;
                objTransactionsGrid.EntityName = item.FLNG_ENT_NAME;
                objTransactionsGrid.Explanation = item.EXPLANATION;
                objTransactionsGrid.FilingSchedID = Convert.ToString(item.FILING_SCHED_ID);
                objTransactionsGrid.TransNumber = Convert.ToString(item.TRANS_NUMBER);
                objTransactionsGrid.FirstName = item.FLNG_ENT_FIRST_NAME;
                objTransactionsGrid.Itemized = item.ITEMIZED;
                objTransactionsGrid.LastName = item.FLNG_ENT_LAST_NAME;
                objTransactionsGrid.LoanerCode = item.LOANER_CODE;
                objTransactionsGrid.Method = item.METHOD;
                objTransactionsGrid.MiddleName = item.FLNG_ENT_MIDDLE_NAME;
                objTransactionsGrid.Municipality = item.MUNICIPALITY;
                objTransactionsGrid.Office = item.OFFICE;
                objTransactionsGrid.District = item.DISTRICT;
                objTransactionsGrid.OriginalDate = Convert.ToString(item.ORIGINAL_DATE);
                objTransactionsGrid.OutStandingAmount = Convert.ToString(item.OUTSTANDING_AMOUNT);
                objTransactionsGrid.PurposeCode = item.PURPOSE_CODE_DESC;
                objTransactionsGrid.PurposeCodeID = Convert.ToString(item.PURPOSE_CODE_ID);
                objTransactionsGrid.ReceiptCode = item.RECEIPT_CODE_DESC;
                objTransactionsGrid.ReceiptType = item.RECEIPT_TYPE_DESC;
                objTransactionsGrid.State = item.FLNG_ENT_STATE;
                objTransactionsGrid.StreetAddress = item.STREET_ADDRESS;
                objTransactionsGrid.TransactionDate = Convert.ToString(item.TRANSACTION_DATE);
                objTransactionsGrid.TransactionType = item.TRANSACTION_TYPE;
                objTransactionsGrid.TransferType = item.TRANSFER_TYPE_DESC;
                objTransactionsGrid.ZipCode = item.FLNG_ENT_ZIP;
                objTransactionsGrid.Status = item.STATUS;
                objTransactionsGrid.Amended = item.AMENDED;
                objTransactionsGrid.DateSubmitted = Convert.ToString(item.DATE_SUBMITTED);

                objTransactionsGrid.TransMapping = item.TRANS_MAPPING;
                objTransactionsGrid.R_Subcontractor = item.R_SUBCONTRACTOR;
                //add object to list
                lstTransactionsGrid.Add(objTransactionsGrid);
            }
            return lstTransactionsGrid;
        }

        #endregion

        #region "GetDisclosureGridData"
        // GETS THE DATA FOR THE DISCLOSURE GRID
        public IList<DisclosureGridEntity> GetDisclosureGridData(String strFilerID, String strReportYearID, String strOfficeTypeID, String strCountyID, String strMunicipalityID, String strElectionTypeID, String strElectionDateID, String strDiclosureTypeID, String strDisclosurePeriodID)
        {
            IList<DisclosureGridEntity> lstDisclosureGrid = new List<DisclosureGridEntity>();
            DisclosureGridEntity objDisclosureGrid;

            var results = entities.SP_S_GetDisclosuresGridData(strFilerID, strReportYearID, strOfficeTypeID, strCountyID, strMunicipalityID, strElectionTypeID, strElectionDateID, strDiclosureTypeID, strDisclosurePeriodID);

            foreach (var item in results)
            {
                objDisclosureGrid = new DisclosureGridEntity();
                objDisclosureGrid.FilingsID = item.FILINGS_ID.ToString();
                objDisclosureGrid.PolCalDateID = item.POL_CAL_DATE_ID.ToString();
                objDisclosureGrid.ReportYearID = item.REPORT_YEAR_ID.ToString();
                objDisclosureGrid.OfficeTypeID = item.OFFICE_TYPE_ID.ToString();
                objDisclosureGrid.ElectTypeID = item.ELECT_TYPE_ID.ToString();
                objDisclosureGrid.DisclosureTypeID = item.DISCLOSURE_TYPE_ID.ToString();
                objDisclosureGrid.DisclosurePeriodID = item.DISCLOSURE_PERIOD_ID.ToString();
                objDisclosureGrid.Amended = item.AMENDED;
                objDisclosureGrid.ReportYear = item.REPORT_YEAR.ToString();
                objDisclosureGrid.OfficeType = item.OFFICE_TYPE_DESC;
                objDisclosureGrid.ElectionType = item.ELECT_TYPE_DESC;
                if (item.ELECT_DATE != null)
                    objDisclosureGrid.ElectionDate = ((DateTime)item.ELECT_DATE).ToShortDateString();
                else
                    objDisclosureGrid.ElectionDate = "";

                if (item.FILING_DATE != null)
                    objDisclosureGrid.FilingDate = ((DateTime)item.FILING_DATE).ToShortDateString();
                else
                    objDisclosureGrid.FilingDate = "";

                objDisclosureGrid.DisclosureType = item.DISCLOSURE_TYPE;
                objDisclosureGrid.DateSubmitted = item.SUBMIT_DATE.ToString();
                objDisclosureGrid.DisclosurePeriod = item.DISCLOSURE_PERIOD;
                objDisclosureGrid.R_Status = item.R_STATUS;

                //add object to list
                lstDisclosureGrid.Add(objDisclosureGrid);
            }
            return lstDisclosureGrid;
        }

        #endregion

        #region "GetSupportingDocumentsGridData"
        // GETS THE DATA FOR THE SUPPORTING DOCUMENTS GRID
        public IList<SupportingDocumentsGridEntity> GetSupportingDocumentsGridData(String strTransNumber)
        {
            IList<SupportingDocumentsGridEntity> lstSupportingDocumentsGrid = new List<SupportingDocumentsGridEntity>();
            SupportingDocumentsGridEntity objSupportingDocumentsGrid;

            var results = entities.SP_S_GetSupportingDocumentsGridData(strTransNumber);

            foreach (var item in results)
            {
                objSupportingDocumentsGrid = new SupportingDocumentsGridEntity();
                objSupportingDocumentsGrid.DateReceived = item.DATE_RECEIVED.ToString();
                objSupportingDocumentsGrid.DocumentType = item.DOCUMENT_TYPE;
                objSupportingDocumentsGrid.FileSize = item.FILE_SIZE;
                objSupportingDocumentsGrid.FileType = item.FILE_TYPE;
                objSupportingDocumentsGrid.FilingMethod = item.FILING_METHOD_DESC;
                objSupportingDocumentsGrid.SupportingDocID = item.SUPPORT_DOC_ID.ToString();
                objSupportingDocumentsGrid.ScanDocID = item.SCAN_DOC_ID.ToString();

                //add object to list
                lstSupportingDocumentsGrid.Add(objSupportingDocumentsGrid);
            }
            return lstSupportingDocumentsGrid;
        }

        #endregion

        #region "GetCampaignMaterialsGridData"
        // GETS THE DATA FOR THE CAMPAIGN MATERIALS GRID
        public IList<CampaignMaterialsGridEntity> GetCampaignMaterialsGridData(String strFilingsID)
        {
            IList<CampaignMaterialsGridEntity> lstCampaignMaterialsGrid = new List<CampaignMaterialsGridEntity>();
            CampaignMaterialsGridEntity objCampaignMaterialsGrid;

            var results = entities.SP_S_GetCampaignMaterialsGridData(strFilingsID);

            foreach (var item in results)
            {
                objCampaignMaterialsGrid = new CampaignMaterialsGridEntity();
                objCampaignMaterialsGrid.CampaignMaterialID = Convert.ToString(item.CAMP_MATR_ID);
                objCampaignMaterialsGrid.FilingMethodID = Convert.ToString(item.FILING_METHOD_ID);
                objCampaignMaterialsGrid.DocumentID = Convert.ToString(item.DOCUMENT_TYPE_ID);

                if (item.DATE_SUBMITTED != null)
                    objCampaignMaterialsGrid.DateSubmitted = ((DateTime)item.DATE_SUBMITTED).ToShortDateString();
                else
                    objCampaignMaterialsGrid.DateSubmitted = "";

                objCampaignMaterialsGrid.Description = item.CAMP_MATR_DESC;
                objCampaignMaterialsGrid.FileSize = item.CAMP_MATR_FILE_SIZE;
                objCampaignMaterialsGrid.FileType = item.CAMP_MATR_FILE_TYPE;
                objCampaignMaterialsGrid.FilingMethod = item.FILING_METHOD_DESC;
                objCampaignMaterialsGrid.CampaignMaterialAvailable = item.CAMPAIGN_MATERIAL_AVAILABLE;

                //add object to list
                lstCampaignMaterialsGrid.Add(objCampaignMaterialsGrid);
            }
            return lstCampaignMaterialsGrid;
        }

        #endregion

        #region "GetTransactionDetialsGridData"
        // GETS THE DATA FOR THE TRANSACTION DETAILS GRID
        public IList<TransactionDetailsGridEntity> GetTransactionDetailsGridData(String strTransNumber)
        {
            IList<TransactionDetailsGridEntity> lstTransactionDetailsGrid = new List<TransactionDetailsGridEntity>();
            TransactionDetailsGridEntity objTransactionDetailsGrid;

            var results = entities.SP_S_GetTransactionDetailsGridData(strTransNumber);

            foreach (var item in results)
            {
                objTransactionDetailsGrid = new TransactionDetailsGridEntity();
                objTransactionDetailsGrid.Amount = Convert.ToString(item.ORG_AMT);
                objTransactionDetailsGrid.Explanation = item.TRANS_EXPLNTN;
                objTransactionDetailsGrid.FilingEntityCity = item.FLNG_ENT_CITY;
                objTransactionDetailsGrid.FilingEntityCountry = item.FLNG_ENT_COUNTRY;
                objTransactionDetailsGrid.FilingEntityFirstName = item.FLNG_ENT_FIRST_NAME;
                objTransactionDetailsGrid.FilingEntityID = Convert.ToString(item.FLNG_ENT_ID);
                objTransactionDetailsGrid.FilingEntityLastName = item.FLNG_ENT_LAST_NAME;
                objTransactionDetailsGrid.FilingEntityMiddleName = item.FLNG_ENT_MIDDLE_NAME;
                objTransactionDetailsGrid.FilingEntityName = item.FLNG_ENT_NAME;
                objTransactionDetailsGrid.FilingEntityState = item.FLNG_ENT_STATE;
                objTransactionDetailsGrid.FilingEntityStreetAddress = item.STREET_ADDRESS;
                objTransactionDetailsGrid.Itemized = item.R_ITEMIZED;

                if (item.CREATED_DATE != null)
                    objTransactionDetailsGrid.CreatedDate = ((DateTime)item.CREATED_DATE).ToShortDateString();
                else
                    objTransactionDetailsGrid.CreatedDate = "";

                if (item.PAY_DATE != null)
                    objTransactionDetailsGrid.PayDate = ((DateTime)item.PAY_DATE).ToShortDateString();
                else
                    objTransactionDetailsGrid.PayDate = "";

                objTransactionDetailsGrid.PurposeCode = item.PURPOSE_CODE_DESC;

                //add object to list
                lstTransactionDetailsGrid.Add(objTransactionDetailsGrid);
            }
            return lstTransactionDetailsGrid;
        }

        #endregion

        #region "GetDocumentTypes"
        // GETS THE DOCUMENT TYPES (LETTER OF INDEBTEDNESS ETC)
        public IList<DocumentTypeEntity> GetDocumentTypes(String applicationID)
        {
            IList<DocumentTypeEntity> lstDocumentTypesEntity = new List<DocumentTypeEntity>();
            DocumentTypeEntity objDocumentTypesEntity;

            var results = entities.SP_S_GetDocumentTypes(Convert.ToInt32(applicationID));
            foreach (var item in results)
            {
                objDocumentTypesEntity = new DocumentTypeEntity();
                objDocumentTypesEntity.DocumentTypeID = Convert.ToString(item.DOC_TYPE_ID);
                objDocumentTypesEntity.DocumentTypeDesc = item.DOC_TYPE_DESC;
                lstDocumentTypesEntity.Add(objDocumentTypesEntity);
            }
            return lstDocumentTypesEntity;
        }
        #endregion

        #region "DeleteDisclosure"
        // IF IN PROD, SOFT DELETES A DISCLOSURE BY UPDATING FILING AND FILING TRANSACTION TABLES
        // IF IN TEMPORARY DATABASE, DOES A HARD DELETE
        public int DeleteDisclosure(String strFilingID, String strIsSubmitted, String strUserName)
        {
            var results = entities.SP_D_DeleteDisclosure(strFilingID, strIsSubmitted, strUserName);
            return results;
        }

        #endregion

        #region "DeleteSupportingDocument"
        // SOFT DELETES A SUPPORTING DOCUMENT BY UPDATING R_STATUS
        public String DeleteSupportingDocument(String strSupportingDocumentID, String strUserName)
        {
            var result = entities.SP_D_DeleteSupportingDocument(strSupportingDocumentID, strUserName);
            return result.ToString();
        }
        #endregion

        #endregion // END REGION VIEWALLDISCLOSURES

        // Creighton Newsom
        // ViewSupportingDocuments Page 11/2018
        #region "ViewSupportingDocuments"

        #region "GetViewSupportingDocumentsGridData"
        // FUNCTION GETS DATA FOR THE SUPPORTINGDOCUMENTS GRID
        // FILERID IS REQUIRED, REPORTYEAR AND DISCLOSUREPERIOD ARE OPTIONAL
        public IList<ViewSupportingDocumentsGridEntity> GetViewSupportingDocumentsGridData(String strFilerID, String strReportYearID, String strDisclosurePeriodID)
        {
            IList<ViewSupportingDocumentsGridEntity> lstViewSupportingDocumentsGrid = new List<ViewSupportingDocumentsGridEntity>();
            ViewSupportingDocumentsGridEntity objViewSupportingDocumentsGrid;

            objViewSupportingDocumentsGrid = new ViewSupportingDocumentsGridEntity();

            var results = entities.SP_S_ViewSupportingDocumentsGrid(strFilerID, strReportYearID, strDisclosurePeriodID);

            foreach (var item in results)
            {
                objViewSupportingDocumentsGrid = new ViewSupportingDocumentsGridEntity();

                objViewSupportingDocumentsGrid.SupportDocID = Convert.ToString(item.SUPPORT_DOC_ID);
                objViewSupportingDocumentsGrid.ScanDocID = Convert.ToString(item.SCAN_DOC_ID);
                objViewSupportingDocumentsGrid.OfficeTypeID = Convert.ToString(item.OFFICE_TYPE_ID);
                objViewSupportingDocumentsGrid.ElectTypeID = Convert.ToString(item.ELECT_TYPE_ID);
                objViewSupportingDocumentsGrid.PolCalDateID = Convert.ToString(item.POL_CAL_DATE_ID);

                objViewSupportingDocumentsGrid.DateReceived = Convert.ToString(item.DATE_RECEIVED);
                objViewSupportingDocumentsGrid.DocumentType = Convert.ToString(item.DOCUMENT_TYPE);
                objViewSupportingDocumentsGrid.Amended = item.AMENDED;
                objViewSupportingDocumentsGrid.ReportYear = Convert.ToString(item.REPORT_YEAR);
                objViewSupportingDocumentsGrid.OfficeType = item.OFFICE_TYPE;
                objViewSupportingDocumentsGrid.ElectionType = item.ELECTION_TYPE;
                if (item.ELECT_DATE != null)
                    objViewSupportingDocumentsGrid.ElectionDate = ((DateTime)item.ELECT_DATE).ToShortDateString();
                else
                    objViewSupportingDocumentsGrid.ElectionDate = "";

                objViewSupportingDocumentsGrid.DisclosurePeriod = item.DISCLOSURE_PERIOD;
                objViewSupportingDocumentsGrid.R_Status = item.R_STATUS;
                objViewSupportingDocumentsGrid.FileType = item.FILE_TYPE;
                objViewSupportingDocumentsGrid.Size = Convert.ToString(item.FILE_SIZE);
                objViewSupportingDocumentsGrid.FilingMethod = item.FILING_METHOD_DESC;

                //add object to list
                lstViewSupportingDocumentsGrid.Add(objViewSupportingDocumentsGrid);
            }
            return lstViewSupportingDocumentsGrid;
        }

        #endregion

        #region "GetDisclosurePeriodsForYearAndFilerID"
        // FUNCTION GETS THE DISCLOSURE PERIODS BASED ON THE YEAR AND FILER ID
        public IList<DisclosurePreiodEntity> GetDisclosurePeriodsForYearAndFilerID(String strFilerID, String strElectionYearID)
        {
            IList<DisclosurePreiodEntity> lstDisclosurePreiodEntity = new List<DisclosurePreiodEntity>();
            DisclosurePreiodEntity objDisclosurePreiodEntity;

            var results = entities.SP_S_DisclosurePeriodsForYearAndFilerID(strFilerID, strElectionYearID);

            foreach (var item in results)
            {
                objDisclosurePreiodEntity = new DisclosurePreiodEntity();
                objDisclosurePreiodEntity.FilingTypeId = Convert.ToString(item.FILING_TYPE_ID);
                objDisclosurePreiodEntity.FilingDesc = item.FILING_DESC;
                objDisclosurePreiodEntity.FilingAbbrev = item.FILING_ABBREV;
                lstDisclosurePreiodEntity.Add(objDisclosurePreiodEntity);
            }

            return lstDisclosurePreiodEntity;
        }
        #endregion

        #endregion // END VIEWSUPPORTINGDOCUMENTS

        // Creighton Newsom
        #region "Loan and Liability Reconciliation"


        #region "GetLoanReceivedGridData"
        // FUNCTION GETS DATA FOR THE LOAN RECEIVED GRID
        // FILERID IS REQUIRED
        public IList<LoanReceivedGridEntity> GetLoanReceivedGridData(String strFilerID)
        {
            IList<LoanReceivedGridEntity> lstLoanReceivedGrid = new List<LoanReceivedGridEntity>();
            LoanReceivedGridEntity objLoanReceivedGrid;

            objLoanReceivedGrid = new LoanReceivedGridEntity();

            var results = entities.SP_S_GetLoansReceivedGridData(strFilerID);

            foreach (var item in results)
            {
                objLoanReceivedGrid = new LoanReceivedGridEntity();

                objLoanReceivedGrid.FilingTransID = Convert.ToString(item.FILING_TRANS_ID);
                objLoanReceivedGrid.TransNumber = item.TRANS_NUMBER;
                objLoanReceivedGrid.TransMapping = item.TRANS_MAPPING;

                if (item.TRANSACTION_DATE != null)
                    objLoanReceivedGrid.TransactionDate = ((DateTime)item.TRANSACTION_DATE).ToShortDateString();
                else
                    objLoanReceivedGrid.TransactionDate = "";

                objLoanReceivedGrid.EntityName = item.FLNG_ENT_NAME;
                objLoanReceivedGrid.Amount = Convert.ToString(item.AMOUNT);
                objLoanReceivedGrid.ElectionYear = Convert.ToString(item.ELECTION_YEAR);
                objLoanReceivedGrid.OfficeType = item.OFFICE_TYPE_DESC;
                objLoanReceivedGrid.ElectionType = item.ELECT_TYPE_DESC;

                if (item.ELECT_DATE != null)
                    objLoanReceivedGrid.ElectionDate = ((DateTime)item.ELECT_DATE).ToShortDateString();
                else
                    objLoanReceivedGrid.ElectionDate = "";

                objLoanReceivedGrid.DisclosurePeriod = item.FILING_DESC;

                //add object to list
                lstLoanReceivedGrid.Add(objLoanReceivedGrid);
            }
            return lstLoanReceivedGrid;
        }

        #endregion

        #region "GetLoanPaymentGridData"
        // FUNCTION GETS DATA FOR THE LOAN PAYMENT GRID
        // FILERID IS REQUIRED
        public IList<LoanPaymentGridEntity> GetLoanPaymentGridData(String strFilerID)
        {
            IList<LoanPaymentGridEntity> lstLoanPaymentGrid = new List<LoanPaymentGridEntity>();
            LoanPaymentGridEntity objLoanPaymentGrid;

            objLoanPaymentGrid = new LoanPaymentGridEntity();

            var results = entities.SP_S_GetLoanPaymentsGridData(strFilerID);

            foreach (var item in results)
            {
                objLoanPaymentGrid = new LoanPaymentGridEntity();

                objLoanPaymentGrid.FilingTransID = Convert.ToString(item.FILING_TRANS_ID);
                objLoanPaymentGrid.TransNumber = item.TRANS_NUMBER;
                objLoanPaymentGrid.TransMapping = item.TRANS_MAPPING;

                if (item.TRANSACTION_DATE != null)
                    objLoanPaymentGrid.TransactionDate = ((DateTime)item.TRANSACTION_DATE).ToShortDateString();
                else
                    objLoanPaymentGrid.TransactionDate = "";

                objLoanPaymentGrid.EntityName = item.FLNG_ENT_NAME;
                objLoanPaymentGrid.Amount = Convert.ToString(item.AMOUNT);

                if (item.ORG_DATE != null)
                    objLoanPaymentGrid.OriginalLoanDate = ((DateTime)item.ORG_DATE).ToShortDateString();
                else
                    objLoanPaymentGrid.OriginalLoanDate = "";

                objLoanPaymentGrid.ElectionYear = Convert.ToString(item.ELECTION_YEAR);
                objLoanPaymentGrid.OfficeType = item.OFFICE_TYPE_DESC;
                objLoanPaymentGrid.ElectionType = item.ELECT_TYPE_DESC;

                if (item.ELECT_DATE != null)
                    objLoanPaymentGrid.ElectionDate = ((DateTime)item.ELECT_DATE).ToShortDateString();
                else
                    objLoanPaymentGrid.ElectionDate = "";

                objLoanPaymentGrid.DisclosurePeriod = item.FILING_DESC;

                //add object to list
                lstLoanPaymentGrid.Add(objLoanPaymentGrid);
            }
            return lstLoanPaymentGrid; ;
        }

        #endregion

        #region "GetOutstandingLiabilityGridData"
        // FUNCTION GETS DATA FOR THE OUTSTANDING LIABILITIES GRID
        // FILERID AND DATATORETURN ARE REQUIRED
        // IF DATATORETURN IS 0, THEN ALL RECORDS ARE RETURNED
        // IF DATATORETURN IS 1 THEN RECORDS WHERE ORG_AMT = OWED_AMT ARE RETURNED
        // IF DATATORETURN IS 2 THEN RECORDS WHERE ORG_AMT <> OWED_AMT ARE RETURNED
        public IList<OutstandingLiabilityGridEntity> GetOutstandingLiabilityGridData(String strFilerID, int dataToReturn)
        {
            IList<OutstandingLiabilityGridEntity> lstOutstandingLiabilityGrid = new List<OutstandingLiabilityGridEntity>();
            OutstandingLiabilityGridEntity objOutstandingLiabilityGrid;

            objOutstandingLiabilityGrid = new OutstandingLiabilityGridEntity();

            //var results = entities.SP_S_GetOutstandingLiabilitiesGridData(strFilerID);

            //foreach (var item in results)
            //{
            //    objOutstandingLiabilityGrid = new OutstandingLiabilityGridEntity();

            //    objOutstandingLiabilityGrid.FilingTransID = Convert.ToString(item.FILING_TRANS_ID);
            //    objOutstandingLiabilityGrid.TransNumber = item.TRANS_NUMBER;
            //    objOutstandingLiabilityGrid.TransMapping = item.TRANS_MAPPING;

            //    if (item.TRANSACTION_DATE != null)
            //        objOutstandingLiabilityGrid.TransactionDate = ((DateTime)item.TRANSACTION_DATE).ToShortDateString();
            //    else
            //        objOutstandingLiabilityGrid.TransactionDate = "";

            //    objOutstandingLiabilityGrid.EntityName = item.FLNG_ENT_NAME;
            //    objOutstandingLiabilityGrid.OriginalAmount = Convert.ToString(item.AMOUNT);
            //    objOutstandingLiabilityGrid.OutstandingAmount = Convert.ToString(item.OWED_AMT);
            //    objOutstandingLiabilityGrid.ElectionYear = Convert.ToString(item.ELECTION_YEAR);
            //    objOutstandingLiabilityGrid.OfficeType = item.OFFICE_TYPE_DESC;
            //    objOutstandingLiabilityGrid.ElectionType = item.ELECT_TYPE_DESC;

            //    if (item.ELECT_DATE != null)
            //        objOutstandingLiabilityGrid.ElectionDate = ((DateTime)item.ELECT_DATE).ToShortDateString();
            //    else
            //        objOutstandingLiabilityGrid.ElectionDate = "";

            //    objOutstandingLiabilityGrid.DisclosurePeriod = item.FILING_DESC;

            //    //add object to list
            //    lstOutstandingLiabilityGrid.Add(objOutstandingLiabilityGrid);
            //}
            return lstOutstandingLiabilityGrid;
        }

        #endregion

        #region "GetLiabilityLoanForgivenGridData"
        // FUNCTION GETS DATA FOR THE LIABILITY/LOAN FORGIVEN GRID
        // FILERID IS REQUIRED
        public IList<LiabilityLoanForgivenGridEntity> GetLiabilityLoanFogivenGridData(String strFilerID)
        {
            IList<LiabilityLoanForgivenGridEntity> lstLiabilityLoanForgivenGrid = new List<LiabilityLoanForgivenGridEntity>();
            LiabilityLoanForgivenGridEntity objLiabilityLoanForgivenGrid;

            objLiabilityLoanForgivenGrid = new LiabilityLoanForgivenGridEntity();

            var results = entities.SP_S_GetLiabilitiesLoansForgivenGridData(strFilerID);

            foreach (var item in results)
            {
                objLiabilityLoanForgivenGrid = new LiabilityLoanForgivenGridEntity();

                objLiabilityLoanForgivenGrid.FilingTransID = Convert.ToString(item.FILING_TRANS_ID);
                objLiabilityLoanForgivenGrid.TransNumber = item.TRANS_NUMBER;
                objLiabilityLoanForgivenGrid.TransMapping = item.TRANS_MAPPING;

                if (item.TRANSACTION_DATE != null)
                    objLiabilityLoanForgivenGrid.TransactionDate = ((DateTime)item.TRANSACTION_DATE).ToShortDateString();
                else
                    objLiabilityLoanForgivenGrid.TransactionDate = "";

                objLiabilityLoanForgivenGrid.EntityName = item.FLNG_ENT_NAME;

                objLiabilityLoanForgivenGrid.Amount = Convert.ToString(item.AMOUNT);
                if (item.ORG_DATE != null)
                    objLiabilityLoanForgivenGrid.OriginalDate = ((DateTime)item.ORG_DATE).ToShortDateString();
                else
                    objLiabilityLoanForgivenGrid.OriginalDate = "";

                objLiabilityLoanForgivenGrid.ElectionYear = Convert.ToString(item.ELECTION_YEAR);
                objLiabilityLoanForgivenGrid.OfficeType = item.OFFICE_TYPE_DESC;
                objLiabilityLoanForgivenGrid.ElectionType = item.ELECT_TYPE_DESC;

                if (item.ELECT_DATE != null)
                    objLiabilityLoanForgivenGrid.ElectionDate = ((DateTime)item.ELECT_DATE).ToShortDateString();
                else
                    objLiabilityLoanForgivenGrid.ElectionDate = "";

                objLiabilityLoanForgivenGrid.DisclosurePeriod = item.FILING_DESC;

                //add object to list
                lstLiabilityLoanForgivenGrid.Add(objLiabilityLoanForgivenGrid);
            }
            return lstLiabilityLoanForgivenGrid;
        }

        #endregion

        #region "GetExpenditurePaymentGridData"
        // FUNCTION GETS DATA FOR THE EXPENDITURES/PAYMENTS GRID
        // FILERID IS REQUIRED
        public IList<ExpenditurePaymentGridEntity> GetExpenditurePaymentGridData(String strFilerID)
        {
            IList<ExpenditurePaymentGridEntity> lstExpenditurePaymentGrid = new List<ExpenditurePaymentGridEntity>();
            ExpenditurePaymentGridEntity objExpenditurePaymentGrid;

            objExpenditurePaymentGrid = new ExpenditurePaymentGridEntity();

            var results = entities.SP_S_GetExpenditurePaymentsGridData(strFilerID);

            foreach (var item in results)
            {
                objExpenditurePaymentGrid = new ExpenditurePaymentGridEntity();

                objExpenditurePaymentGrid.FilingTransID = Convert.ToString(item.FILING_TRANS_ID);
                objExpenditurePaymentGrid.TransNumber = item.TRANS_NUMBER;
                objExpenditurePaymentGrid.TransMapping = item.TRANS_MAPPING;

                if (item.TRANSACTION_DATE != null)
                    objExpenditurePaymentGrid.TransactionDate = ((DateTime)item.TRANSACTION_DATE).ToShortDateString();
                else
                    objExpenditurePaymentGrid.TransactionDate = "";

                objExpenditurePaymentGrid.EntityName = item.FLNG_ENT_NAME;
                objExpenditurePaymentGrid.Amount = Convert.ToString(item.AMOUNT);
                objExpenditurePaymentGrid.Explanation = item.TRANS_EXPLNTN;
                objExpenditurePaymentGrid.ElectionYear = Convert.ToString(item.ELECTION_YEAR);
                objExpenditurePaymentGrid.OfficeType = item.OFFICE_TYPE_DESC;
                objExpenditurePaymentGrid.ElectionType = item.ELECT_TYPE_DESC;

                if (item.ELECT_DATE != null)
                    objExpenditurePaymentGrid.ElectionDate = ((DateTime)item.ELECT_DATE).ToShortDateString();
                else
                    objExpenditurePaymentGrid.ElectionDate = "";

                objExpenditurePaymentGrid.DisclosurePeriod = item.FILING_DESC;

                //add object to list
                lstExpenditurePaymentGrid.Add(objExpenditurePaymentGrid);
            }
            return lstExpenditurePaymentGrid;
        }

        #endregion

        #region "Reconcile_Loan"
        // PROCEDURE RECONCILES LOANS, PAYMENTS, OUTSTANDING LIABILITIES AND LOAN FORGIVENS
        public String Reconcile_Loan(String Schedule_I_TransFilingID, String[] Schedule_J_TransFilingIDs, String[] Schedule_N_TransFilingIDs, String[] Schedule_K_TransFilingIDs, String strUser)
        {       
            // CREATE SQLPARAMETER TYPES FOR EACH OF THE INCOMING PARAMETERS

            // SCHEDULE I IS A SINGLE STRING ITEM
            SqlParameter Sch_I_Param = new SqlParameter("@SCHEDULE_I_ID", SqlDbType.NVarChar);
            Sch_I_Param.Value = Schedule_I_TransFilingID;

            // SCHEDULE J IS AN ARRAY
            DataTable Sch_J_TransIDs = new DataTable();
            Sch_J_TransIDs.Columns.Add(new DataColumn("FILING_TRANS_ID", typeof(string)));
            if (Schedule_J_TransFilingIDs != null)
                foreach (var id in Schedule_J_TransFilingIDs)
                    Sch_J_TransIDs.Rows.Add(id);

            SqlParameter Sch_Js_Param = new SqlParameter("@SCHEDULE_J_IDS", SqlDbType.Structured);
            Sch_Js_Param.TypeName = "dbo.ScheduleJ_ID_List";
            Sch_Js_Param.Value = Sch_J_TransIDs;

            // SCHEDULE N IS AN ARRAY
            DataTable Sch_N_TransIDs = new DataTable();
            Sch_N_TransIDs.Columns.Add(new DataColumn("FILING_TRANS_ID", typeof(string)));
            if (Schedule_N_TransFilingIDs != null)
                foreach (var id in Schedule_N_TransFilingIDs)
                    Sch_N_TransIDs.Rows.Add(id);

            SqlParameter Sch_Ns_Param = new SqlParameter("@SCHEDULE_N_IDS", SqlDbType.Structured);
            Sch_Ns_Param.TypeName = "dbo.ScheduleN_ID_List";
            Sch_Ns_Param.Value = Sch_N_TransIDs;

            // SCHEDULE K IS AN ARRAY
            DataTable Sch_K_TransIDs = new DataTable();
            Sch_K_TransIDs.Columns.Add(new DataColumn("FILING_TRANS_ID", typeof(string)));
            if (Schedule_K_TransFilingIDs != null)
                foreach (var id in Schedule_K_TransFilingIDs)
                    Sch_K_TransIDs.Rows.Add(id);

            SqlParameter Sch_Ks_Param = new SqlParameter("@SCHEDULE_K_IDS", SqlDbType.Structured);
            Sch_Ks_Param.TypeName = "dbo.ScheduleK_ID_List";
            Sch_Ks_Param.Value = Sch_K_TransIDs;

            // USER NAME
            SqlParameter User_Param = new SqlParameter("@USER", SqlDbType.NVarChar);
            User_Param.Value = strUser;

            // RETURN CODE
            SqlParameter ReturnCode_Param = new SqlParameter("@RETURN_CODE", SqlDbType.NVarChar);
            ReturnCode_Param.Direction = ParameterDirection.InputOutput;
            ReturnCode_Param.Value = "0";

            // CREATE AN OBJECT LIST AND ADD THE PARAMETER OBJECTS TO THE LIST
            List<object> parameterList = new List<object>();
            parameterList.Add(Sch_I_Param);
            parameterList.Add(Sch_Js_Param);
            parameterList.Add(Sch_Ns_Param);
            parameterList.Add(Sch_Ks_Param);
            parameterList.Add(User_Param);
            parameterList.Add(ReturnCode_Param);

            // CREATE AN OBJECT ARRAY FROM THE LIST IN ORDER TO PASS TO STORED PROC 
            object[] parameterArray = parameterList.ToArray();

            using (var context = new EFSEntities())
            {
                // FOR SELECTS USE LINE BELOW (SQLQUERY)
                //var result = context.Database.SqlQuery<Int32>("EXEC dbo.SP_U_EFS_Reconcile_Loan @SCHEDULE_I_ID, @SCHEDULE_J_IDS, @SCHEDULE_N_IDS, @SCHEDULE_K_IDS", parameterArray).ToList();

                // FOR UPDATES USE EXECUTESQLCOMMAND
                int result = context.Database.ExecuteSqlCommand("EXEC dbo.SP_U_EFS_Reconcile_Loan @SCHEDULE_I_ID, @SCHEDULE_J_IDS, @SCHEDULE_N_IDS, @SCHEDULE_K_IDS, @USER, @RETURN_CODE OUTPUT", parameterArray);
                return ReturnCode_Param.Value.ToString();
            }
        }
        #endregion

        #region "Reconcile_Liability"
        // PROCEDURE RECONCILES THE ORIGINAL LIABILITY WITH EXPENDITURES, OUTSTANDING
        // LIABILITIES AND LOANS FORGIVEN
        public String Reconcile_Liability(String Schedule_N_OriginalLiability_TransFilingID, String[] Schedule_F_TransFilingIDs, String[] Schedule_N_TransFilingIDs, String[] Schedule_K_TransFilingIDs, String strUser)
        {
            // CREATE SQLPARAMETER TYPES FOR EACH OF THE INCOMING PARAMETERS

            // SCHEDULE I IS A SINGLE STRING ITEM
            SqlParameter Sch_I_OrgLiab_Param = new SqlParameter("@SCHEDULE_N_ORIGINALLIABILITY_TRANSFILINGID", SqlDbType.NVarChar);
            Sch_I_OrgLiab_Param.Value = Schedule_N_OriginalLiability_TransFilingID;

            // SCHEDULE F IS AN ARRAY
            DataTable Sch_F_TransIDs = new DataTable();
            Sch_F_TransIDs.Columns.Add(new DataColumn("FILING_TRANS_ID", typeof(string)));
            if (Schedule_F_TransFilingIDs != null)
                foreach (var id in Schedule_F_TransFilingIDs)
                    Sch_F_TransIDs.Rows.Add(id);

            SqlParameter Sch_Fs_Param = new SqlParameter("@SCHEDULE_F_IDS", SqlDbType.Structured);
            Sch_Fs_Param.TypeName = "dbo.ScheduleF_ID_List";
            Sch_Fs_Param.Value = Sch_F_TransIDs;

            // SCHEDULE N IS AN ARRAY
            DataTable Sch_N_TransIDs = new DataTable();
            Sch_N_TransIDs.Columns.Add(new DataColumn("FILING_TRANS_ID", typeof(string)));
            if (Schedule_N_TransFilingIDs != null)
                foreach (var id in Schedule_N_TransFilingIDs)
                    Sch_N_TransIDs.Rows.Add(id);

            SqlParameter Sch_Ns_Param = new SqlParameter("@SCHEDULE_N_IDS", SqlDbType.Structured);
            Sch_Ns_Param.TypeName = "dbo.ScheduleN_ID_List";
            Sch_Ns_Param.Value = Sch_N_TransIDs;

            // SCHEDULE K IS AN ARRAY
            DataTable Sch_K_TransIDs = new DataTable();
            Sch_K_TransIDs.Columns.Add(new DataColumn("FILING_TRANS_ID", typeof(string)));
            if (Schedule_K_TransFilingIDs != null)
                foreach (var id in Schedule_K_TransFilingIDs)
                    Sch_K_TransIDs.Rows.Add(id);

            SqlParameter Sch_Ks_Param = new SqlParameter("@SCHEDULE_K_IDS", SqlDbType.Structured);
            Sch_Ks_Param.TypeName = "dbo.ScheduleK_ID_List";
            Sch_Ks_Param.Value = Sch_K_TransIDs;

            // USER NAME
            SqlParameter User_Param = new SqlParameter("@USER", SqlDbType.NVarChar);
            User_Param.Value = strUser;

            // RETURN CODE
            SqlParameter ReturnCode_Param = new SqlParameter("@RETURN_CODE", SqlDbType.NVarChar);
            ReturnCode_Param.Direction = ParameterDirection.InputOutput;
            ReturnCode_Param.Value = "0";

            // CREATE AN OBJECT LIST AND ADD THE PARAMETER OBJECTS TO THE LIST
            List<object> parameterList = new List<object>();
            parameterList.Add(Sch_I_OrgLiab_Param);
            parameterList.Add(Sch_Fs_Param);
            parameterList.Add(Sch_Ns_Param);
            parameterList.Add(Sch_Ks_Param);
            parameterList.Add(User_Param);
            parameterList.Add(ReturnCode_Param);

            // CREATE AN OBJECT ARRAY FROM THE LIST IN ORDER TO PASS TO STORED PROC 
            object[] parameterArray = parameterList.ToArray();

            using (var context = new EFSEntities())
            {
                // FOR SELECTS USE LINE BELOW (SQLQUERY)
                //var result = context.Database.SqlQuery<Int32>("EXEC dbo.SP_U_EFS_Reconcile_Loan @SCHEDULE_I_ID, @SCHEDULE_J_IDS, @SCHEDULE_N_IDS, @SCHEDULE_K_IDS", parameterArray).ToList();

                // FOR UPDATES USE EXECUTESQLCOMMAND
                int result = context.Database.ExecuteSqlCommand("EXEC dbo.SP_U_EFS_Reconcile_Liability @SCHEDULE_N_ORIGINALLIABILITY_TRANSFILINGID, @SCHEDULE_F_IDS, @SCHEDULE_N_IDS, @SCHEDULE_K_IDS, @USER, @RETURN_CODE OUTPUT", parameterArray);
                return ReturnCode_Param.Value.ToString();

            }
        }
        #endregion

        #region "GetUnreconciledLoansOrLiabilities"
        // FUNCTION RETURNS THE NUMBER OF LOANS +
        // THE NUMBER OF LIABILITIES. IF THE RESULT IS 0 THEN THE 
        // RECONCILIATION PAGE DOESN'T NEED TO LOAD. IT WILL CALL 
        // UPDATEREQUIREDFILER METHOD AND THAT IS IT.
        public String GetUncreconciledLoansAndLiabilities(String strFilerID)
        {
            //var results = entities.SP_S_GetUncreconciledLoansAndLiabilities(strFilerID);
            String returnValue = string.Empty;
            //foreach(var item in results)
            //{
            //    returnValue = Convert.ToString(item.RETURNVALUE);
            //}
            return returnValue;
        }
        #endregion

        #region "UpdateRequiredFilerForReconcile"
        // THIS METHOD SIMPLY UPDATE THE R_RECONCILED AND MODIFIED_BY COLUMNS
        // IN THE REQUIRED_FILER TABLE. IT IS CALLED WHEN THERE ARE NO LOANS 
        // OR LIABILITIES OR WHEN THEY HAVE ALL BEEN RECONCILED
        public String UpdateRequiredFilerForReconcile(String strFilerID, String strUser)
        {
            //var results = entities.SP_U_UpdateRequiredFilerForReconcile(strFilerID, strUser);
            String returnValue = string.Empty;
            //foreach(var item in results)
            //{
            //     returnValue = item.RETURNVALUE;
            //}
            return returnValue;
        }
        #endregion


        #endregion


        /// <summary>
        /// Get Outstanding Forgiven
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public IList<OriginalAmountEntity> GetOutstandingAmountLiabData_Forgiven(String strFilingEntityId, String strTransNumber)
        {
            IList<OriginalAmountEntity> lstOriginalAmountEntity = new List<OriginalAmountEntity>();
            OriginalAmountEntity objOriginalAmountEntity;

            var results = entities.SP_S_OutstandingAmountLiability_FORGIVEN(strFilingEntityId, strTransNumber);

            foreach (var item in results)
            {
                objOriginalAmountEntity = new OriginalAmountEntity();
                objOriginalAmountEntity.OriginalAmountId = Convert.ToString(item.LOAN_LIB_NUMBER);
                objOriginalAmountEntity.OutstandingAmount = String.Format("{0:0.00}", item.OWED_AMT);
                lstOriginalAmountEntity.Add(objOriginalAmountEntity);
            }
            return lstOriginalAmountEntity;
        }

        /// <summary>
        /// Check Amend Status
        /// </summary>
        /// <param name="filings_ID"></param>
        /// <returns></returns>
        public IList<CheckAmendStatus> GetAmendStatus(FilingTransDataEntity objFilingTransDataEntity)
        {
            IList<CheckAmendStatus> lstCheckAmendStatusEntity = new List<CheckAmendStatus>();
            CheckAmendStatus objCheckAmendStatusEntity;

            var results = entities.SP_S_GetAmend_Status(objFilingTransDataEntity.FilerId,
                objFilingTransDataEntity.ReportYearId, objFilingTransDataEntity.OfficeTypeId,
                objFilingTransDataEntity.DisclosurePeriod, objFilingTransDataEntity.ElectionType,
                objFilingTransDataEntity.ElectionDateId, objFilingTransDataEntity.FilingDate);

            foreach (var item in results)
            {
                objCheckAmendStatusEntity = new CheckAmendStatus();
                objCheckAmendStatusEntity.Submit_Date = item.SUBMIT_DATE.ToString();
                objCheckAmendStatusEntity.IsAmend = item.IS_AMEND.ToString();
                lstCheckAmendStatusEntity.Add(objCheckAmendStatusEntity);
            }

            return lstCheckAmendStatusEntity;
        }

        /// <summary>
        /// GetExpSubContrTotAmt
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public String GetExpSubContrTotAmt_LoanDetails(String strTransNumber)
        {
            String strExpSubContrTotAmt = String.Empty;

            var results = entities.SP_S_GetExpSubContrAmtTot_LoanReceived(strTransNumber);

            foreach (var item in results)
            {
                if (item != null)
                    strExpSubContrTotAmt = String.Format("{0:0.00}", item.Value);
                else
                    strExpSubContrTotAmt = "";
            }

            return strExpSubContrTotAmt;
        }

        /// <summary>
        /// Get Edit Flag
        /// </summary>
        /// <param name="objFilingTransDataEntity"></param>
        /// <returns></returns>
        public IList<GetEditFlagData> GetEditFlag(FilingTransDataEntity objFilingTransDataEntity)
        {
            IList<GetEditFlagData> lstGetEditFlagDataEntity = new List<GetEditFlagData>();
            GetEditFlagData objGetEditFlagDataEntity;

            if (objFilingTransDataEntity.TransNumber == null)
            {
                var results = entities.SP_S_GetIsEditFlag(objFilingTransDataEntity.FilerId,
                objFilingTransDataEntity.ReportYearId, objFilingTransDataEntity.ElectionType,
                objFilingTransDataEntity.OfficeTypeId, objFilingTransDataEntity.DisclosurePeriod, objFilingTransDataEntity.FilingDate,
                objFilingTransDataEntity.ElectionDateId, objFilingTransDataEntity.Created_By);

                foreach (var item in results)
                {
                    objGetEditFlagDataEntity = new GetEditFlagData();
                    objGetEditFlagDataEntity.Is_Edit = item.IS_EDIT.ToString();
                    lstGetEditFlagDataEntity.Add(objGetEditFlagDataEntity);
                }
            }
            else if (objFilingTransDataEntity.TransNumber != null)
            {
                var results = entities.SP_S_GetIsEditFlagNonItemized(objFilingTransDataEntity.FilerId, objFilingTransDataEntity.TransNumber);

                foreach (var item in results)
                {
                    objGetEditFlagDataEntity = new GetEditFlagData();
                    objGetEditFlagDataEntity.Is_Edit = item.IS_EDIT.ToString();
                    lstGetEditFlagDataEntity.Add(objGetEditFlagDataEntity);
                }
            }                             

            return lstGetEditFlagDataEntity;
        }

        /// <summary>
        /// ValidateFilings
        /// </summary>
        /// <param name="objFilingTransDataEntity"></param>
        /// <returns></returns>
        public IList<GetEditFlagData> ValidateFilings(FilingTransDataEntity objFilingTransDataEntity)
        {
            IList<GetEditFlagData> lstGetEditFlagDataEntity = new List<GetEditFlagData>();
            GetEditFlagData objGetEditFlagDataEntity;

            var results = entities.SP_S_Validate_Submit_Filings(objFilingTransDataEntity.FilerId,
                objFilingTransDataEntity.FilingDate);

            foreach (var item in results)
            {
                objGetEditFlagDataEntity = new GetEditFlagData();
                objGetEditFlagDataEntity.VALIDATE_FILINGS = item.VALIDATE_FILINGS.ToString();
                lstGetEditFlagDataEntity.Add(objGetEditFlagDataEntity);
            }

            return lstGetEditFlagDataEntity;
        }

        /// <summary>
        /// Add Viewable Column
        /// </summary>
        /// <param name="filer_ID"></param>
        /// <param name="created_By"></param>
        /// <returns></returns>
        public Boolean AddViewableColumn(string filer_ID, string created_By)
        {
            //var returnValue = entities.SP_I_VIEWABLE_FIELD(filer_ID, created_By);

            //if (returnValue >= 1)
            //    return true;
            //else
                return false;
        }

        /// <summary>
        /// GetContrInKindPartnersData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<ContrInKindPartnersEntity> GetLoanReceviedPartnersData(String strFilingTransId)
        {
            IList<ContrInKindPartnersEntity> lstContrInKindPartnersEntity = new List<ContrInKindPartnersEntity>();
            ContrInKindPartnersEntity objContrInKindPartnersEntity;

            var results = entities.SP_S_LoanReceived_PartnersData(strFilingTransId);

            foreach (var item in results)
            {
                objContrInKindPartnersEntity = new ContrInKindPartnersEntity();
                objContrInKindPartnersEntity.FilingTransId = Convert.ToString(item.FILING_TRANS_ID);
                objContrInKindPartnersEntity.FilingEntityId = Convert.ToString(item.FLNG_ENT_ID);
                objContrInKindPartnersEntity.PartnershipName = item.FLNG_ENT_NAME;
                objContrInKindPartnersEntity.PartnerFirstName = item.FLNG_ENT_FIRST_NAME;
                objContrInKindPartnersEntity.PartnerMiddleName = item.FLNG_ENT_MIDDLE_NAME;
                objContrInKindPartnersEntity.PartnerLastName = item.FLNG_ENT_LAST_NAME;
                objContrInKindPartnersEntity.PartnerStreetNo = item.FLNG_ENT_STR_NUM;
                objContrInKindPartnersEntity.PartnerStreetName = item.LNG_ENT_STR_NAME;
                objContrInKindPartnersEntity.PartnerCity = item.FLNG_ENT_CITY;
                objContrInKindPartnersEntity.PartnerState = item.FLNG_ENT_STATE;
                objContrInKindPartnersEntity.PartnerZip5 = item.FLNG_ENT_ZIP;
                objContrInKindPartnersEntity.PartnershipCountry = item.FLNG_ENT_COUNTRY;
                objContrInKindPartnersEntity.PartnerAmountAttributed = String.Format("{0:0.00}", item.ORG_AMT);
                objContrInKindPartnersEntity.PartnerExplanation = item.TRANS_EXPLNTN;
                if (item.R_ITEMIZED == "" || item.R_ITEMIZED == null)
                    objContrInKindPartnersEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "Y")
                    objContrInKindPartnersEntity.RItemized = "Yes";
                else if (item.R_ITEMIZED == "N")
                    objContrInKindPartnersEntity.RItemized = "No";
                objContrInKindPartnersEntity.TransNumber = item.TRANS_NUMBER;
                objContrInKindPartnersEntity.TransMapping = item.TRANS_MAPPING;
                lstContrInKindPartnersEntity.Add(objContrInKindPartnersEntity);
            }

            return lstContrInKindPartnersEntity;
        }

       
        /// <summary>
        /// Validate Loan Received Delete 
        /// </summary>
        /// <param name="objFilingTransDataEntity"></param>
        /// <returns></returns>
        public IList<GetEditFlagData> ValidateLoanReceived_Delete(FilingTransDataEntity objFilingTransDataEntity)
        {
            IList<GetEditFlagData> lstGetEditFlagDataEntity = new List<GetEditFlagData>();
            GetEditFlagData objGetEditFlagDataEntity;

            var results = entities.SP_S_VALIDATE_LOAN_RECD_DELETE(objFilingTransDataEntity.Loan_Lib_Num);

            foreach (var item in results)
            {
                objGetEditFlagDataEntity = new GetEditFlagData();
                objGetEditFlagDataEntity.VALIDATE_FILINGS = item.VALIDATE_LOAN_RECEIVED.ToString();
                lstGetEditFlagDataEntity.Add(objGetEditFlagDataEntity);
            }

            return lstGetEditFlagDataEntity;
        }
    }
}

