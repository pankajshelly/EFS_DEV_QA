// ViewAllDisclosures Region by Creighton Newsom
// ViewSupportingDocuments Region by Creighton Newsom
// Loan and Liability Reconciliation Region by Creighton Newsom
using Cabinet.Portable.Models;
using Cabinet.Portable.Models.Document;
using Contracts;
using Entities;
using Repository;
using System;
using System.Collections.Generic;
//-------------------------------

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CabPCL = Cabinet.Portable;

namespace CAPASFIDAS_EFS_SERVICE
{
    public class CAPASFIDAS_EFS_SERVICE : ICAPASFIDAS_EFS_SERVICE
    {

        EFSRepository objEFSRepository = new EFSRepository();

        /// <summary>
        /// GetContactData
        /// </summary>
        /// <returns></returns>
        public IList<ShowAddressContract> GetAddressData(String strPersonId)
        {
            IList<ShowAddressContract> lstShowAddressContract = new List<ShowAddressContract>();
            ShowAddressContract objShowAddressContract;

            var results = objEFSRepository.GetAddressData(strPersonId);

            foreach (var item in results)
            {
                objShowAddressContract = new ShowAddressContract();
                objShowAddressContract.AddressId = item.AddressId;
                objShowAddressContract.BestContactId = item.BestContactId;
                objShowAddressContract.BestContractDesc = item.BestContractDesc;
                objShowAddressContract.AddressTypeId = item.AddressTypeId;
                objShowAddressContract.AddressTypeDesc = item.AddressTypeDesc;
                objShowAddressContract.AddressStreetNumber = item.AddressStreetNumber;
                objShowAddressContract.AddressStreetName = item.AddressStreetName;
                objShowAddressContract.AddressAddress1 = item.AddressAddress1;
                objShowAddressContract.AddressAddress2 = item.AddressAddress2;
                objShowAddressContract.AddressCity = item.AddressCity;
                objShowAddressContract.AddressState = item.AddressState;
                objShowAddressContract.AddressZip = item.AddressZip;
                objShowAddressContract.AddressZip4 = item.AddressZip4;
                lstShowAddressContract.Add(objShowAddressContract);
            }

            return lstShowAddressContract;
        }

        /// <summary>
        /// GetContactData
        /// </summary>
        /// <returns></returns>
        public IList<ShowContactContract> GetContactData(String strPersonId)
        {
            IList<ShowContactContract> lstShowContactContract = new List<ShowContactContract>();
            ShowContactContract objShowContactContract;

            var results = objEFSRepository.GetContactData(strPersonId);

            foreach (var item in results)
            {
                objShowContactContract = new ShowContactContract();
                objShowContactContract.ContractId = item.ContractId;
                objShowContactContract.PersonId = item.PersonId;
                //objShowContactContract.ContactTypeId = item.ContactTypeId;
                //objShowContactContract.ContactTypeDescription = item.ContactTypeDescription;
                objShowContactContract.BestContactId = item.BestContactId;
                objShowContactContract.BestContract_Desc = item.BestContract_Desc;
                objShowContactContract.Phone = item.Phone;
                objShowContactContract.EmailAddress = item.EmailAddress;
                objShowContactContract.FAX = item.FAX;
                objShowContactContract.URL = item.URL;
                lstShowContactContract.Add(objShowContactContract);
            }

            return lstShowContactContract;
        }

        /// <summary>
        /// GetDepositoryBankInfoData
        /// </summary>
        /// <param name="strPersonId"></param>
        /// <returns></returns>
        public IList<DepositoryBankInfoContract> GetDepositoryBankInfoData(String strPersonId)
        {
            IList<DepositoryBankInfoContract> lstDepositoryBankInfoContract = new List<DepositoryBankInfoContract>();
            DepositoryBankInfoContract objDepositoryBankInfoContract;

            var results = objEFSRepository.GetDepositoryBankInfoData(strPersonId);

            foreach (var item in results)
            {
                objDepositoryBankInfoContract = new DepositoryBankInfoContract();
                objDepositoryBankInfoContract.BankId = item.BankId;
                objDepositoryBankInfoContract.AddressId = item.AddressId;
                objDepositoryBankInfoContract.CandidateId = item.CandidateId;
                objDepositoryBankInfoContract.DepositoryBankName = item.DepositoryBankName;
                objDepositoryBankInfoContract.BankAccountTypeId = item.BankAccountTypeId;
                objDepositoryBankInfoContract.StreetNumber = item.StreetNumber;
                objDepositoryBankInfoContract.StreetName = item.StreetName;
                objDepositoryBankInfoContract.City = item.City;
                objDepositoryBankInfoContract.State = item.State;
                objDepositoryBankInfoContract.Zip = item.Zip;
                objDepositoryBankInfoContract.Zip4 = item.Zip4;
                lstDepositoryBankInfoContract.Add(objDepositoryBankInfoContract);
            }
            return lstDepositoryBankInfoContract;
        }

        /// <summary>
        /// GetCandAuthCommitteesData
        /// </summary>
        /// <param name="strPersonId"></param>
        /// <returns></returns>
        public IList<CandAuthCommitteesContract> GetCandAuthCommitteesData(String strPersonId)
        {
            IList<CandAuthCommitteesContract> lstCandAuthCommitteesContract = new List<CandAuthCommitteesContract>();
            CandAuthCommitteesContract objCandAuthCommitteesContract;

            var results = objEFSRepository.GetCandAuthCommitteesData(strPersonId);

            foreach (var item in results)
            {
                objCandAuthCommitteesContract = new CandAuthCommitteesContract();
                objCandAuthCommitteesContract.FilerId = item.FilerId;
                objCandAuthCommitteesContract.CommitteeName = item.CommitteeName;
                objCandAuthCommitteesContract.Status = item.Status;
                objCandAuthCommitteesContract.RegistrationDate = item.RegistrationDate;
                objCandAuthCommitteesContract.TerminationDate = item.TerminationDate;
                lstCandAuthCommitteesContract.Add(objCandAuthCommitteesContract);
            }

            return lstCandAuthCommitteesContract;
        }

        /// <summary>
        /// GetCandidateHeaderData
        /// </summary>
        /// <param name="strPersonId"></param>
        /// <returns></returns>
        public IList<CandidateHeaderDataContract> GetCandidateHeaderData(String strPersonId)
        {
            IList<CandidateHeaderDataContract> lstCandidateHeaderDataContract = new List<CandidateHeaderDataContract>();
            CandidateHeaderDataContract objCandidateHeaderDataContract;

            var results = objEFSRepository.GetCandidateHeaderData(strPersonId);

            foreach (var item in results)
            {
                objCandidateHeaderDataContract = new CandidateHeaderDataContract();
                objCandidateHeaderDataContract.FilerType = item.FilerType;
                objCandidateHeaderDataContract.Office = item.Office;
                objCandidateHeaderDataContract.District = item.District;
                objCandidateHeaderDataContract.Municipality = item.Municipality;
                objCandidateHeaderDataContract.ElectionYear = item.ElectionYear;
                objCandidateHeaderDataContract.CandidateId = item.CandidateId;
                objCandidateHeaderDataContract.SSN = item.SSN;
                objCandidateHeaderDataContract.PoliticalParty = item.PoliticalParty;
                objCandidateHeaderDataContract.RegistrationDate = item.RegistrationDate;
                objCandidateHeaderDataContract.Status = item.Status;
                objCandidateHeaderDataContract.TerminationDate = item.TerminationDate;
                objCandidateHeaderDataContract.Prefix = item.Prefix;
                objCandidateHeaderDataContract.LastName = item.LastName;
                objCandidateHeaderDataContract.FirstName = item.FirstName;
                objCandidateHeaderDataContract.MiddleName = item.MiddleName;
                objCandidateHeaderDataContract.Suffix = item.Suffix;
                lstCandidateHeaderDataContract.Add(objCandidateHeaderDataContract);
            }

            return lstCandidateHeaderDataContract;
        }

        /// <summary>
        /// AddAddressData
        /// </summary>
        /// <param name="objAddressDataContract"></param>
        /// <returns></returns>
        public Boolean AddAddressData(AddressDataContract objAddressDataContract)
        {
            AddressDataEntity objAddressDataEntity = new AddressDataEntity();
            objAddressDataEntity.AddressTypeId = objAddressDataContract.AddressTypeId;
            objAddressDataEntity.PersonId = objAddressDataContract.PersonId;
            objAddressDataEntity.BestContactId = objAddressDataContract.BestContactId;
            objAddressDataEntity.AddressBusinessName = objAddressDataContract.AddressBusinessName;
            objAddressDataEntity.AddressStreetNumber = objAddressDataContract.AddressStreetNumber;
            objAddressDataEntity.AddressStreetName = objAddressDataContract.AddressStreetName;
            objAddressDataEntity.AddressAddress1 = objAddressDataContract.AddressAddress1;
            objAddressDataEntity.AddressAddress2 = objAddressDataContract.AddressAddress2;
            objAddressDataEntity.AdresssCity = objAddressDataContract.AdresssCity;
            objAddressDataEntity.AddressState = objAddressDataContract.AddressState;
            objAddressDataEntity.AddressZip = objAddressDataContract.AddressZip;
            objAddressDataEntity.AddressZip4 = objAddressDataContract.AddressZip4;
            objAddressDataEntity.CreatedBy = objAddressDataContract.CreatedBy;

            Boolean result = objEFSRepository.AddAddressData(objAddressDataEntity);

            return result;
        }

        /// <summary>
        /// UpdateAddressData
        /// </summary>
        /// <param name="objAddressDataContract"></param>
        /// <returns></returns>
        public Boolean UpdateAddressData(AddressDataContract objAddressDataContract)
        {
            AddressDataEntity objAddressDataEntity = new AddressDataEntity();
            objAddressDataEntity.AddressId = objAddressDataContract.AddressId;
            objAddressDataEntity.AddressTypeId = objAddressDataContract.AddressTypeId;
            objAddressDataEntity.BestContactId = objAddressDataContract.BestContactId;
            objAddressDataEntity.AddressStreetName = objAddressDataContract.AddressStreetName;
            objAddressDataEntity.AdresssCity = objAddressDataContract.AdresssCity;
            objAddressDataEntity.AddressState = objAddressDataContract.AddressState;
            objAddressDataEntity.AddressZip = objAddressDataContract.AddressZip;
            objAddressDataEntity.ModifiedBy = objAddressDataContract.ModifiedBy;

            Boolean result = objEFSRepository.UpdateAddressData(objAddressDataEntity);

            return result;
        }

        /// <summary>
        /// DeleteAddressData
        /// </summary>
        /// <param name="objAddressDataContract"></param>
        /// <returns></returns>
        public Boolean DeleteAddressData(AddressDataContract objAddressDataContract)
        {
            AddressDataEntity objAddressDataEntity = new AddressDataEntity();
            objAddressDataEntity.AddressId = objAddressDataContract.AddressId;
            objAddressDataEntity.ModifiedBy = objAddressDataContract.ModifiedBy;

            Boolean result = objEFSRepository.DeleteAddressData(objAddressDataEntity);

            return result;
        }

        /// <summary>
        /// GetAddressTypesData
        /// </summary>
        /// <returns></returns>
        public IList<AddressTypesContract> GetAddressTypesData()
        {
            IList<AddressTypesContract> lstAddressTypesContract = new List<AddressTypesContract>();
            AddressTypesContract objAddressTypesContract;

            var results = objEFSRepository.GetAddressTypesData();

            foreach (var item in results)
            {
                objAddressTypesContract = new AddressTypesContract();
                objAddressTypesContract.AddressTypeId = item.AddressTypeId;
                objAddressTypesContract.AddressTypeDescription = item.AddressTypeDescription;
                lstAddressTypesContract.Add(objAddressTypesContract);
            }

            return lstAddressTypesContract;
        }

        /// <summary>
        /// GetBestContactTypesData
        /// </summary>
        /// <returns></returns>
        public IList<BestContactTypesContract> GetBestContactTypesData()
        {
            IList<BestContactTypesContract> lstBestContactTypesContract = new List<BestContactTypesContract>();
            BestContactTypesContract objBestContactTypesContract;

            var results = objEFSRepository.GetBestContactTypesData();

            foreach (var item in results)
            {
                objBestContactTypesContract = new BestContactTypesContract();
                objBestContactTypesContract.BestContactTypeId = item.BestContactTypeId;
                objBestContactTypesContract.BestContactTypeDesc = item.BestContactTypeDesc;
                lstBestContactTypesContract.Add(objBestContactTypesContract);
            }

            return lstBestContactTypesContract;
        }

        /// <summary>
        /// GetContactTypesData
        /// </summary>
        /// <returns></returns>
        public IList<ContactTypesContract> GetContactTypesData()
        {
            IList<ContactTypesContract> lstContactTypesContract = new List<ContactTypesContract>();
            ContactTypesContract objContactTypesContract;

            var results = objEFSRepository.GetContactTypesData();

            foreach (var item in results)
            {
                objContactTypesContract = new ContactTypesContract();
                objContactTypesContract.ContactTypeId = item.ContactTypeId;
                objContactTypesContract.ContactTypeDescription = item.ContactTypeDescription;
                lstContactTypesContract.Add(objContactTypesContract);
            }

            return lstContactTypesContract;
        }

        /// <summary>
        /// AddContactData
        /// </summary>
        /// <param name="objShowContactEntity"></param>
        /// <returns></returns>
        public Boolean AddContactData(ShowContactContract objShowContactContract)
        {
            ShowContactEntity objShowContactEntity = new ShowContactEntity();
            objShowContactEntity.PersonId = objShowContactContract.PersonId;
            objShowContactEntity.BestContactId = objShowContactContract.BestContactId;
            objShowContactEntity.ContactTypeId = objShowContactContract.ContactTypeId;
            objShowContactEntity.Phone = objShowContactContract.Phone;
            objShowContactEntity.EmailAddress = objShowContactContract.EmailAddress;
            objShowContactEntity.FAX = objShowContactContract.FAX;
            objShowContactEntity.URL = objShowContactContract.URL;
            objShowContactEntity.CreatedBy = objShowContactContract.CreatedBy;

            Boolean results = objEFSRepository.AddContactData(objShowContactEntity);

            return results;
        }

        /// <summary>
        /// UpdateContactData
        /// </summary>
        /// <param name="objShowContactEntity"></param>
        /// <returns></returns>
        public Boolean UpdateContactData(ShowContactContract objShowContactContract)
        {
            ShowContactEntity objShowContactEntity = new ShowContactEntity();
            objShowContactEntity.ContractId = objShowContactContract.ContractId;
            objShowContactEntity.BestContactId = objShowContactContract.BestContactId;
            objShowContactEntity.Phone = objShowContactContract.Phone;
            objShowContactEntity.EmailAddress = objShowContactContract.EmailAddress;
            objShowContactEntity.FAX = objShowContactContract.FAX;
            objShowContactEntity.URL = objShowContactContract.URL;
            objShowContactEntity.ModifiedBy = objShowContactContract.ModifiedBy;

            Boolean results = objEFSRepository.UpdateContactData(objShowContactEntity);

            return results;
        }

        /// <summary>
        /// DeleteContactData
        /// </summary>
        /// <param name="objShowContactEntity"></param>
        /// <returns></returns>
        public Boolean DeleteContactData(ShowContactContract objShowContactContract)
        {
            ShowContactEntity objShowContactEntity = new ShowContactEntity();
            objShowContactEntity.ContractId = objShowContactContract.ContractId;
            objShowContactEntity.ModifiedBy = objShowContactContract.ModifiedBy;

            Boolean results = objEFSRepository.DeleteContactData(objShowContactEntity);

            return results;
        }

        /// <summary>
        /// AddDepositoryBankInfo
        /// </summary>
        /// <param name="objDepositoryBankInfoEntity"></param>
        /// <returns></returns>
        public Boolean AddDepositoryBankInfo(DepositoryBankInfoContract objDepositoryBankInfoContract)
        {
            DepositoryBankInfoEntity objDepositoryBankInfoEntity = new DepositoryBankInfoEntity();
            objDepositoryBankInfoEntity.PersonId = objDepositoryBankInfoContract.PersonId;
            objDepositoryBankInfoEntity.CandidateId = objDepositoryBankInfoContract.CandidateId;
            objDepositoryBankInfoEntity.DepositoryBankName = objDepositoryBankInfoContract.DepositoryBankName;
            objDepositoryBankInfoEntity.BankAccountTypeId = objDepositoryBankInfoContract.BankAccountTypeId;
            objDepositoryBankInfoEntity.StreetNumber = objDepositoryBankInfoContract.StreetNumber;
            objDepositoryBankInfoEntity.StreetName = objDepositoryBankInfoContract.StreetName;
            objDepositoryBankInfoEntity.City = objDepositoryBankInfoContract.City;
            objDepositoryBankInfoEntity.State = objDepositoryBankInfoContract.State;
            objDepositoryBankInfoEntity.Zip = objDepositoryBankInfoContract.Zip;
            objDepositoryBankInfoEntity.Zip4 = objDepositoryBankInfoContract.Zip4;
            objDepositoryBankInfoEntity.CreatedBy = objDepositoryBankInfoContract.CreatedBy;

            Boolean results = objEFSRepository.AddDepositoryBankInfo(objDepositoryBankInfoEntity);

            return results;
        }

        /// <summary>
        /// UpdateDepositoryBankInfo
        /// </summary>
        /// <param name="objDepositoryBankInfoEntity"></param>
        /// <returns></returns>
        public Boolean UpdateDepositoryBankInfo(DepositoryBankInfoContract objDepositoryBankInfoContract)
        {
            DepositoryBankInfoEntity objDepositoryBankInfoEntity = new DepositoryBankInfoEntity();
            objDepositoryBankInfoEntity.AddressId = objDepositoryBankInfoContract.AddressId;
            objDepositoryBankInfoEntity.BankId = objDepositoryBankInfoContract.BankId;
            objDepositoryBankInfoEntity.DepositoryBankName = objDepositoryBankInfoContract.DepositoryBankName;
            objDepositoryBankInfoEntity.BankAccountTypeId = objDepositoryBankInfoContract.BankAccountTypeId;
            objDepositoryBankInfoEntity.StreetName = objDepositoryBankInfoContract.StreetName;
            objDepositoryBankInfoEntity.City = objDepositoryBankInfoContract.City;
            objDepositoryBankInfoEntity.State = objDepositoryBankInfoContract.State;
            objDepositoryBankInfoEntity.Zip = objDepositoryBankInfoContract.Zip;
            objDepositoryBankInfoEntity.ModifiedBy = objDepositoryBankInfoContract.ModifiedBy;

            Boolean results = objEFSRepository.UpdateDepositoryBankInfo(objDepositoryBankInfoEntity);

            return results;
        }

        /// <summary>
        /// DeleteDepositoryBankInfo
        /// </summary>
        /// <param name="objDepositoryBankInfoEntity"></param>
        /// <returns></returns>
        public Boolean DeleteDepositoryBankInfo(DepositoryBankInfoContract objDepositoryBankInfoContract)
        {
            DepositoryBankInfoEntity objDepositoryBankInfoEntity = new DepositoryBankInfoEntity();
            objDepositoryBankInfoEntity.AddressId = objDepositoryBankInfoContract.AddressId;
            objDepositoryBankInfoEntity.BankId = objDepositoryBankInfoContract.BankId;
            objDepositoryBankInfoEntity.ModifiedBy = objDepositoryBankInfoContract.ModifiedBy;

            Boolean results = objEFSRepository.DeleteDepositoryBankInfo(objDepositoryBankInfoEntity);

            return results;
        }

        /// <summary>
        /// GetBankAccountTypes
        /// </summary>
        /// <returns></returns>
        public IList<BankAccountTypesContract> GetBankAccountTypes()
        {
            IList<BankAccountTypesContract> lstBankAccountTypesContract = new List<BankAccountTypesContract>();
            BankAccountTypesContract objBankAccountTypesContract;

            var results = objEFSRepository.GetBankAccountTypes();

            foreach (var item in results)
            {
                objBankAccountTypesContract = new BankAccountTypesContract();
                objBankAccountTypesContract.AccountTypeId = item.AccountTypeId;
                objBankAccountTypesContract.AccountTypeDesc = item.AccountTypeDesc;
                lstBankAccountTypesContract.Add(objBankAccountTypesContract);
            }

            return lstBankAccountTypesContract;
        }

        /// <summary>
        /// Get Treasurer Profile
        /// </summary>
        /// <param name="personID"></param>
        /// <returns></returns>
        public IList<TreasurerProfileContract> GetTreasurerProfileInfo(string personID)
        {
            IList<TreasurerProfileContract> lstTreasurerProfileContract = new List<TreasurerProfileContract>();
            TreasurerProfileContract objTreasurerProfileContract;

            var results = objEFSRepository.GetTreasurerProfileInfo(personID);

            foreach (var item in results)
            {
                objTreasurerProfileContract = new TreasurerProfileContract();
                objTreasurerProfileContract.TransID = item.TransID;
                objTreasurerProfileContract.PersonID = item.PersonID;
                objTreasurerProfileContract.TransRegDate = item.TransRegDate;
                objTreasurerProfileContract.Status = item.Status;
                objTreasurerProfileContract.TransTermDate = item.TransTermDate;
                objTreasurerProfileContract.PersonPrefix = item.PersonPrefix;
                objTreasurerProfileContract.PersonFirstName = item.PersonFirstName;
                objTreasurerProfileContract.PersonMiddleName = item.PersonMiddleName;
                objTreasurerProfileContract.PersonLastName = item.PersonLastName;
                objTreasurerProfileContract.PersonSuffix = item.PersonSuffix;
                lstTreasurerProfileContract.Add(objTreasurerProfileContract);
            }

            return lstTreasurerProfileContract;
        }

        /// <summary>
        /// Get Committee Information
        /// </summary>
        /// <param name="transID"></param>
        /// <returns></returns>
        public IList<TreasurerCommitteeInformationContract> GetTreasurerCommitteeInformation(string transID)
        {
            IList<TreasurerCommitteeInformationContract> lstTreasurerCommitteeInformationContract = new List<TreasurerCommitteeInformationContract>();
            TreasurerCommitteeInformationContract objTreasurerCommitteeInformationContract;

            var results = objEFSRepository.GetTreasurerCommitteeInformation(transID);

            foreach (var item in results)
            {
                objTreasurerCommitteeInformationContract = new TreasurerCommitteeInformationContract();
                objTreasurerCommitteeInformationContract.CommID = Convert.ToString(item.CommID);
                objTreasurerCommitteeInformationContract.FilerID = Convert.ToString(item.FilerID);
                objTreasurerCommitteeInformationContract.PersonID = item.PersonID.ToString();
                objTreasurerCommitteeInformationContract.CommitteeName = item.CommitteeName.ToString();
                objTreasurerCommitteeInformationContract.Status = item.Status;
                objTreasurerCommitteeInformationContract.CommitteeRegDate = item.CommitteeRegDate.ToString();
                objTreasurerCommitteeInformationContract.CommitteeTermDate = item.CommitteeTermDate.ToString();
                objTreasurerCommitteeInformationContract.CommitteeTypeDesc = item.CommitteeTypeDesc.ToString();
                lstTreasurerCommitteeInformationContract.Add(objTreasurerCommitteeInformationContract);
            }

            return lstTreasurerCommitteeInformationContract;
        }

        /// <summary>
        /// Get Transurer Assistant Information
        /// </summary>
        /// <param name="commID"></param>
        /// <returns></returns>
        public IList<TreasAssistantInformationContract> GetTreasurerAssistantInformation(string commID)
        {
            IList<TreasAssistantInformationContract> lstTreasAssistantInformationContract = new List<TreasAssistantInformationContract>();
            TreasAssistantInformationContract objTreasAssistantInformationContract;

            var results = objEFSRepository.GetTreasurerAssistantInformation(commID);

            foreach (var item in results)
            {
                objTreasAssistantInformationContract = new TreasAssistantInformationContract();
                objTreasAssistantInformationContract.PersonPrefix = item.PersonPrefix;
                objTreasAssistantInformationContract.PersonFirstName = item.PersonFirstName;
                objTreasAssistantInformationContract.PersonMiddleName = item.PersonMiddleName;
                objTreasAssistantInformationContract.PersonLastName = item.PersonLastName;
                objTreasAssistantInformationContract.PersonSuffix = item.PersonSuffix;
                objTreasAssistantInformationContract.PersonID = item.PersonID;
                lstTreasAssistantInformationContract.Add(objTreasAssistantInformationContract);
            }

            return lstTreasAssistantInformationContract;
        }

        /// <summary>
        /// Treasurer History Information
        /// </summary>
        /// <param name="commID"></param>
        /// <param name="transID"></param>
        /// <returns></returns>
        public IList<TreasurerHistoryContract> GetTreasurerHistoryInformation(string commID, string transID)
        {
            IList<TreasurerHistoryContract> lstTreasurerHistoryContracty = new List<TreasurerHistoryContract>();
            TreasurerHistoryContract objTreasurerHistoryContract;

            var results = objEFSRepository.GetTreasurerHistoryInformation(commID, transID);

            foreach (var item in results)
            {
                objTreasurerHistoryContract = new TreasurerHistoryContract();
                objTreasurerHistoryContract.PersonPrefix = item.PersonPrefix;
                objTreasurerHistoryContract.PersonFirstName = item.PersonFirstName;
                objTreasurerHistoryContract.PersonMiddleName = item.PersonMiddleName;
                objTreasurerHistoryContract.PersonLastName = item.PersonLastName;
                objTreasurerHistoryContract.PersonSuffix = item.PersonSuffix;
                objTreasurerHistoryContract.Status = item.Status;
                objTreasurerHistoryContract.RegDate = item.RegDate.ToString();
                objTreasurerHistoryContract.TermDate = item.TermDate.ToString();
                objTreasurerHistoryContract.PersonID = item.PersonID.ToString();
                lstTreasurerHistoryContracty.Add(objTreasurerHistoryContract);
            }

            return lstTreasurerHistoryContracty;
        }

        /// <summary>
        /// Get Treasurer Additional Committee Contact
        /// </summary>
        /// <param name="commID"></param>
        /// <returns></returns>
        public IList<TreasAdditionalCommitteeContactContract> GetTreasurerAdditionalCommitteeContact(string commID)
        {
            IList<TreasAdditionalCommitteeContactContract> lstTreasAdditionalCommitteeContactContract = new List<TreasAdditionalCommitteeContactContract>();
            TreasAdditionalCommitteeContactContract objTreasAdditionalCommitteeContactContract;

            var results = objEFSRepository.GetTreasurerAdditionalCommitteeContact(commID);

            foreach (var item in results)
            {
                objTreasAdditionalCommitteeContactContract = new TreasAdditionalCommitteeContactContract();
                objTreasAdditionalCommitteeContactContract.PersonPrefix = item.PersonPrefix;
                objTreasAdditionalCommitteeContactContract.PersonFirstName = item.PersonFirstName;
                objTreasAdditionalCommitteeContactContract.PersonMiddleName = item.PersonMiddleName;
                objTreasAdditionalCommitteeContactContract.PersonLastName = item.PersonLastName;
                objTreasAdditionalCommitteeContactContract.PersonSuffix = item.PersonSuffix;
                lstTreasAdditionalCommitteeContactContract.Add(objTreasAdditionalCommitteeContactContract);
            }

            return lstTreasAdditionalCommitteeContactContract;
        }

        /// <summary>
        /// Get Treasurer Depository Bank Information
        /// </summary>
        /// <param name="commID"></param>
        /// <returns></returns>
        public IList<TreasDepositoryBankInformationContract> GetTreasurerDepositoryBankInformation(string commID)
        {
            IList<TreasDepositoryBankInformationContract> lstTreasDepositoryBankInformationContract = new List<TreasDepositoryBankInformationContract>();
            TreasDepositoryBankInformationContract objTreasDepositoryBankInformationContract;

            var results = objEFSRepository.GetTreasurerDepositoryBankInformation(commID);

            foreach (var item in results)
            {
                objTreasDepositoryBankInformationContract = new TreasDepositoryBankInformationContract();
                objTreasDepositoryBankInformationContract.BankID = item.BankID.ToString();
                objTreasDepositoryBankInformationContract.BankName = item.BankName;
                objTreasDepositoryBankInformationContract.AddrNum = item.AddrNum;
                objTreasDepositoryBankInformationContract.AddrStrName = item.AddrStrName;
                objTreasDepositoryBankInformationContract.AddrCity = item.AddrCity;
                objTreasDepositoryBankInformationContract.AddrState = item.AddrState;
                objTreasDepositoryBankInformationContract.AddrZip = item.AddrZip.ToString();
                objTreasDepositoryBankInformationContract.AddrZip4 = item.AddrZip4.ToString();
                objTreasDepositoryBankInformationContract.ADDR_ID = item.ADDR_ID.ToString();
                objTreasDepositoryBankInformationContract.PERSON_ID = item.PERSON_ID.ToString();
                objTreasDepositoryBankInformationContract.COMM_ID = item.COMM_ID.ToString();
                lstTreasDepositoryBankInformationContract.Add(objTreasDepositoryBankInformationContract);
            }

            return lstTreasDepositoryBankInformationContract;
        }

        public IList<TreasCandidateSupportOpposeContract> GetTreasurerCandidateSupposeOppose(string commID)
        {
            IList<TreasCandidateSupportOpposeContract> lstTreasCandidateSupportOpposeContract = new List<TreasCandidateSupportOpposeContract>();
            TreasCandidateSupportOpposeContract objTreasCandidateSupportOpposeContract;

            var results = objEFSRepository.GetTreasurerCandidateSupposeOppose(commID);

            foreach (var item in results)
            {
                objTreasCandidateSupportOpposeContract = new TreasCandidateSupportOpposeContract();
                objTreasCandidateSupportOpposeContract.ElectionYear = item.ElectionYear.ToString();
                objTreasCandidateSupportOpposeContract.OfficeDesc = item.OfficeDesc;
                objTreasCandidateSupportOpposeContract.DistID = item.DistID.ToString();
                objTreasCandidateSupportOpposeContract.PersonFirstName = item.PersonFirstName;
                objTreasCandidateSupportOpposeContract.PersonMiddleName = item.PersonMiddleName;
                objTreasCandidateSupportOpposeContract.PersonLastName = item.PersonLastName;
                objTreasCandidateSupportOpposeContract.SupposeOppose = item.SupposeOppose.ToString();
                if (item.AuthorizedDate != null)
                {
                    objTreasCandidateSupportOpposeContract.AuthorizedDate = item.AuthorizedDate.ToString();
                }
                else
                {
                    objTreasCandidateSupportOpposeContract.AuthorizedDate = "";
                }
                if (item.NonExpenditureDate != null)
                {
                    objTreasCandidateSupportOpposeContract.NonExpenditureDate = item.NonExpenditureDate.ToString();
                }
                else
                {
                    objTreasCandidateSupportOpposeContract.NonExpenditureDate = "";
                }

                lstTreasCandidateSupportOpposeContract.Add(objTreasCandidateSupportOpposeContract);
            }

            return lstTreasCandidateSupportOpposeContract;
        }

        /// <summary>
        /// Get Treasurer Authorized To Sign Check Conract
        /// </summary>
        /// <param name="commID"></param>
        /// <returns></returns>
        public IList<TreasAuthorizedToSignCheckContract> GetTreasurerAuthorizedToSignCheckContact(string commID)
        {
            IList<TreasAuthorizedToSignCheckContract> lstTreasAuthorizedToSignCheckContract = new List<TreasAuthorizedToSignCheckContract>();
            TreasAuthorizedToSignCheckContract objTreasAuthorizedToSignCheckContract;

            var results = objEFSRepository.GetTreasurerAuthorizedToSignCheckContact(commID);

            foreach (var item in results)
            {
                objTreasAuthorizedToSignCheckContract = new TreasAuthorizedToSignCheckContract();
                objTreasAuthorizedToSignCheckContract.PersonPrefix = item.PersonPrefix;
                objTreasAuthorizedToSignCheckContract.PersonFirstName = item.PersonFirstName;
                objTreasAuthorizedToSignCheckContract.PersonMiddleName = item.PersonMiddleName;
                objTreasAuthorizedToSignCheckContract.PersonLastName = item.PersonLastName;
                objTreasAuthorizedToSignCheckContract.PersonSuffix = item.PersonSuffix;
                objTreasAuthorizedToSignCheckContract.AuthSignedID = item.AuthSignedID;
                objTreasAuthorizedToSignCheckContract.PersonID = item.PersonID;
                objTreasAuthorizedToSignCheckContract.StartDate = item.StartDate;
                objTreasAuthorizedToSignCheckContract.EndDate = item.EndDate;
                objTreasAuthorizedToSignCheckContract.Status = item.Status;
                lstTreasAuthorizedToSignCheckContract.Add(objTreasAuthorizedToSignCheckContract);
            }

            return lstTreasAuthorizedToSignCheckContract;
        }

        /// <summary>
        /// Get Treasurer Ballot Issues Contract
        /// </summary>
        /// <param name="commID"></param>
        /// <returns></returns>
        public IList<TreasBallotIssuesContract> GetTreasurerBallotIssuesContact(string commID)
        {
            IList<TreasBallotIssuesContract> lstTreasBallotIssuesContract = new List<TreasBallotIssuesContract>();
            TreasBallotIssuesContract objTreasBallotIssuesContract;

            var results = objEFSRepository.GetTreasurerBallotIssuesContact(commID);

            foreach (var item in results)
            {
                objTreasBallotIssuesContract = new TreasBallotIssuesContract();
                objTreasBallotIssuesContract.BallotIssues = item.BallotIssues.ToString();
                objTreasBallotIssuesContract.SupposeOppose = item.SupposeOppose.ToString();
                lstTreasBallotIssuesContract.Add(objTreasBallotIssuesContract);
            }

            return lstTreasBallotIssuesContract;
        }

        /// <summary>
        /// AddDepositoryBankInfo
        /// </summary>
        /// <param name="objDepositoryBankInfoEntity"></param>
        /// <returns></returns>
        public Boolean AddDepositoryBankInfoTreasurer(TreasDepositoryBankInformationContract objDepositoryBankInfoContract)
        {
            TreasDepositoryBankInformationEntity objDepositoryBankInfoEntity = new TreasDepositoryBankInformationEntity();
            objDepositoryBankInfoEntity.PERSON_ID = objDepositoryBankInfoContract.PERSON_ID;
            objDepositoryBankInfoEntity.COMM_ID = objDepositoryBankInfoContract.COMM_ID;
            objDepositoryBankInfoEntity.BankName = objDepositoryBankInfoContract.BankName;
            objDepositoryBankInfoEntity.BankAccountTypeID = objDepositoryBankInfoContract.BankAccountTypeID;
            objDepositoryBankInfoEntity.AddrStrName = objDepositoryBankInfoContract.AddrStrName;
            objDepositoryBankInfoEntity.AddrCity = objDepositoryBankInfoContract.AddrCity;
            objDepositoryBankInfoEntity.AddrState = objDepositoryBankInfoContract.AddrState;
            objDepositoryBankInfoEntity.AddrZip = objDepositoryBankInfoContract.AddrZip;
            objDepositoryBankInfoEntity.CreatedBy = objDepositoryBankInfoContract.CreatedBy;

            Boolean results = objEFSRepository.AddDepositoryBankInfoTreasurer(objDepositoryBankInfoEntity);

            return results;
        }

        /// <summary>
        /// AddSubTreasurerData
        /// </summary>
        /// <param name="objSubTreasurerPersonContract"></param>
        /// <returns></returns>
        public Boolean AddSubTreasurerData(SubTreasurerPersonContract objSubTreasurerPersonContract)
        {
            SubTreasurerPersonEntity objSubTreasurerPersonEntity = new SubTreasurerPersonEntity();
            objSubTreasurerPersonEntity.StateDate = objSubTreasurerPersonContract.StateDate;
            objSubTreasurerPersonEntity.RStatus = objSubTreasurerPersonContract.RStatus;
            objSubTreasurerPersonEntity.FirstName = objSubTreasurerPersonContract.FirstName;
            objSubTreasurerPersonEntity.MiddleName = objSubTreasurerPersonContract.MiddleName;
            objSubTreasurerPersonEntity.LastName = objSubTreasurerPersonContract.LastName;
            objSubTreasurerPersonEntity.Suffix = objSubTreasurerPersonContract.Suffix;
            objSubTreasurerPersonEntity.Preffix = objSubTreasurerPersonContract.Preffix;
            objSubTreasurerPersonEntity.PersonId = objSubTreasurerPersonContract.PersonId;
            objSubTreasurerPersonEntity.TreasurerId = objSubTreasurerPersonContract.TreasurerId;
            objSubTreasurerPersonEntity.CreatedBy = objSubTreasurerPersonContract.CreatedBy;

            Boolean result = objEFSRepository.AddSubTreasurerData(objSubTreasurerPersonEntity);

            return result;
        }

        /// <summary>
        /// UpdateSubTreasurerData
        /// </summary>
        /// <param name="objSubTreasurerPersonContract"></param>
        /// <returns></returns>
        public Boolean UpdateSubTreasurerData(SubTreasurerPersonContract objSubTreasurerPersonContract)
        {
            SubTreasurerPersonEntity objSubTreasurerPersonEntity = new SubTreasurerPersonEntity();
            objSubTreasurerPersonEntity.PersonId = objSubTreasurerPersonContract.PersonId;
            objSubTreasurerPersonEntity.FirstName = objSubTreasurerPersonContract.FirstName;
            objSubTreasurerPersonEntity.MiddleName = objSubTreasurerPersonContract.MiddleName;
            objSubTreasurerPersonEntity.LastName = objSubTreasurerPersonContract.LastName;
            objSubTreasurerPersonEntity.Suffix = objSubTreasurerPersonContract.Suffix;
            objSubTreasurerPersonEntity.Preffix = objSubTreasurerPersonContract.Preffix;
            objSubTreasurerPersonEntity.SubTreasurerId = objSubTreasurerPersonContract.SubTreasurerId;
            objSubTreasurerPersonEntity.RStatus = objSubTreasurerPersonContract.RStatus;
            objSubTreasurerPersonEntity.StateDate = objSubTreasurerPersonContract.StateDate;
            objSubTreasurerPersonEntity.ModifiedBy = objSubTreasurerPersonContract.ModifiedBy;

            Boolean result = objEFSRepository.UpdateSubTreasurerData(objSubTreasurerPersonEntity);

            return result;
        }

        /// <summary>
        /// GetFilingTransactionsData
        /// </summary>
        /// <param name="objFilingTransDataContract"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataContract> GetFilingTransactionsData(FilingTransDataContract objFilingTransDataContract)
        {
            IList<FilingTransactionDataContract> lstFilingTransactionDataContract = new List<FilingTransactionDataContract>();
            FilingTransactionDataContract objFilingTransactionDataContract;

            FilingTransDataEntity objFilingTransDataEntity = new FilingTransDataEntity();
            objFilingTransDataEntity.FilerId = objFilingTransDataContract.FilerId;
            objFilingTransDataEntity.ReportYearId = objFilingTransDataContract.ReportYearId;
            objFilingTransDataEntity.OfficeTypeId = objFilingTransDataContract.OfficeTypeId;
            objFilingTransDataEntity.DisclosurePeriod = objFilingTransDataContract.DisclosurePeriod;
            objFilingTransDataEntity.ElectionType = objFilingTransDataContract.ElectionType;
            objFilingTransDataEntity.ElectionDateId = objFilingTransDataContract.ElectionDateId;
            objFilingTransDataEntity.FilingDate = objFilingTransDataContract.FilingDate;
            objFilingTransDataEntity.MunicipalityID = objFilingTransDataContract.MunicipalityID;

            var results = objEFSRepository.GetFilingTransactionsData(objFilingTransDataEntity);

            foreach (var item in results)
            {
                objFilingTransactionDataContract = new FilingTransactionDataContract();
                objFilingTransactionDataContract.FilingTransId = item.FilingTransId;
                objFilingTransactionDataContract.FilingSchedId = item.FilingSchedId;
                objFilingTransactionDataContract.ContributorTypeId = item.ContributorTypeId;
                objFilingTransactionDataContract.ContributorTypeDesc = item.ContributorTypeDesc;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionDataContract.PaymentTypeId = item.PaymentTypeId;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.SchedDate = item.SchedDate;
                objFilingTransactionDataContract.FilingSchedDesc = item.FilingSchedDesc;
                objFilingTransactionDataContract.FilingEntityId = item.FilingEntityId;
                objFilingTransactionDataContract.FilingEntityName = item.FilingEntityName;
                objFilingTransactionDataContract.FilingFirstName = item.FilingFirstName;
                objFilingTransactionDataContract.FilingMiddleName = item.FilingMiddleName;
                objFilingTransactionDataContract.FilingLastName = item.FilingLastName;
                objFilingTransactionDataContract.FilingStreetNumber = item.FilingStreetNumber;
                objFilingTransactionDataContract.FilingStreetName = item.FilingStreetName;
                objFilingTransactionDataContract.FilingCity = item.FilingCity;
                objFilingTransactionDataContract.FilingState = item.FilingState;
                objFilingTransactionDataContract.FilingZip = item.FilingZip;
                objFilingTransactionDataContract.FilingCountry = item.FilingCountry;
                objFilingTransactionDataContract.PaymentTypeDesc = item.PaymentTypeDesc;
                objFilingTransactionDataContract.PayNumber = item.PayNumber;
                objFilingTransactionDataContract.OriginalAmount = item.OriginalAmount;
                objFilingTransactionDataContract.ReceiptTypeDesc = item.ReceiptTypeDesc;
                objFilingTransactionDataContract.TransferTypeDesc = item.TransferTypeDesc;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.OriginalDate = item.OriginalDate;
                objFilingTransactionDataContract.LoanerCode = item.LoanerCode;
                objFilingTransactionDataContract.ElectionYear = item.ElectionYear;
                objFilingTransactionDataContract.Office = item.Office;
                objFilingTransactionDataContract.District = item.District;
                objFilingTransactionDataContract.RLiability = item.RLiability;
                objFilingTransactionDataContract.RSubcontractor = item.RSubcontractor;
                objFilingTransactionDataContract.TransExplanation = item.TransExplanation;
                objFilingTransactionDataContract.OwedAmount = item.OwedAmount;
                objFilingTransactionDataContract.RItemized = item.RItemized;
                objFilingTransactionDataContract.CountyID = item.CountyID;
                objFilingTransactionDataContract.CountyDesc = item.CountyDesc;
                objFilingTransactionDataContract.MunicipalityID = item.MunicipalityID;
                objFilingTransactionDataContract.MunicipalityDesc = item.MunicipalityDesc;
                objFilingTransactionDataContract.LoanerCodeID = item.LoanerCodeId;
                objFilingTransactionDataContract.CreatedDate = item.CreatedDate;
                objFilingTransactionDataContract.LoanLiablityNumber = item.LoanLiablityNumber;
                objFilingTransactionDataContract.TransNumber = item.TransNumber;
                objFilingTransactionDataContract.TransMapping = item.TransMapping;
                objFilingTransactionDataContract.FilingsId = item.FilingsId;
                objFilingTransactionDataContract.Office_Desc = item.Office_Desc;
                objFilingTransactionDataContract.RClaim = item.RClaim;
                objFilingTransactionDataContract.InDistrict = item.InDistrict;
                objFilingTransactionDataContract.RMinor = item.RMinor;
                objFilingTransactionDataContract.RVendor = item.RVendor;
                objFilingTransactionDataContract.RLobbyist = item.RLobbyist;
                objFilingTransactionDataContract.TreasurerEmployer = item.TreasurerEmployer;
                objFilingTransactionDataContract.TreasurerOccuptaion = item.TreasurerOccuptaion;
                objFilingTransactionDataContract.TreaAddress = item.TreaAddress;
                objFilingTransactionDataContract.TreaAddr1 = item.TreaAddr1;
                objFilingTransactionDataContract.TreaCity = item.TreaCity;
                objFilingTransactionDataContract.TreaState = item.TreaState;
                objFilingTransactionDataContract.TreaZipCode = item.TreaZipCode;
                objFilingTransactionDataContract.RContributions = item.RContributions;
                objFilingTransactionDataContract.IESupported = item.IESupported;
                lstFilingTransactionDataContract.Add(objFilingTransactionDataContract);
            }

            return lstFilingTransactionDataContract;
        }


        public IList<ContributionTypeContract> GetContributionTypeData()
        {
            IList<ContributionTypeContract> lstContributionTypeContract = new List<ContributionTypeContract>();
            ContributionTypeContract objContributionTypeContract;

            var results = objEFSRepository.GetContributionTypeData();

            foreach (var item in results)
            {
                objContributionTypeContract = new ContributionTypeContract();
                objContributionTypeContract.ContributionTypeId = item.ContributionTypeId;
                objContributionTypeContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objContributionTypeContract.ContributionTypeAbbrev = item.ContributionTypeAbbrev;
                lstContributionTypeContract.Add(objContributionTypeContract);
            }

            return lstContributionTypeContract;
        }

        public IList<ContributorNameContract> GetContributionNameData()
        {
            IList<ContributorNameContract> lstContributorNameContract = new List<ContributorNameContract>();
            ContributorNameContract objContributorNameContract;

            var results = objEFSRepository.GetContributionNameData();

            foreach (var item in results)
            {
                objContributorNameContract = new ContributorNameContract();
                objContributorNameContract.ContributorTypeId = item.ContributorTypeId;
                objContributorNameContract.ContributorTypeDesc = item.ContributorTypeDesc;
                objContributorNameContract.ContributorTypeAbbrev = item.ContributorTypeAbbrev;
                lstContributorNameContract.Add(objContributorNameContract);
            }

            return lstContributorNameContract;
        }

        public IList<DisclosurePreiodContract> GetDisclosurePeriodData(String strElectTypeId, String strfilerID, String strElectYearId)
        {
            IList<DisclosurePreiodContract> lstDisclosurePreiodContract = new List<DisclosurePreiodContract>();
            DisclosurePreiodContract objDisclosurePreiodContract;

            var results = objEFSRepository.GetDisclosurePeriodData(strElectTypeId, strfilerID, strElectYearId);

            foreach (var item in results)
            {
                objDisclosurePreiodContract = new DisclosurePreiodContract();
                objDisclosurePreiodContract.FilingTypeId = item.FilingTypeId;
                objDisclosurePreiodContract.FilingDesc = item.FilingDesc;
                objDisclosurePreiodContract.FilingAbbrev = item.FilingAbbrev;
                lstDisclosurePreiodContract.Add(objDisclosurePreiodContract);
            }

            return lstDisclosurePreiodContract;
        }

        public IList<ElectionDateContract> GetElectionDateData(String strElectYearId, String strElectTypeId, String strOfficeTypeId, String strCounty, String strMunicipality)
        {
            IList<ElectionDateContract> lstElectionDateContract = new List<ElectionDateContract>();
            ElectionDateContract objElectionDateContract;

            var results = objEFSRepository.GetElectionDateData(strElectYearId, strElectTypeId, strOfficeTypeId, strCounty, strMunicipality);

            foreach (var item in results)
            {
                objElectionDateContract = new ElectionDateContract();
                objElectionDateContract.ElectId = item.ElectId;
                objElectionDateContract.ElectDate = item.ElectDate;
                lstElectionDateContract.Add(objElectionDateContract);
            }

            return lstElectionDateContract;
        }

        public IList<FilerCommitteeContract> GetFilerCommitteeData(String strfilerID)
        {
            try
            {
                IList<FilerCommitteeContract> lstFilerCommitteeContract = new List<FilerCommitteeContract>();
                FilerCommitteeContract objFilerCommitteeContract;

                var results = objEFSRepository.GetFilerCommitteeData(strfilerID);

                foreach (var item in results)
                {
                    objFilerCommitteeContract = new FilerCommitteeContract();
                    objFilerCommitteeContract.FilerId = item.FilerId;
                    objFilerCommitteeContract.CommitteeId = item.CommitteeId;
                    objFilerCommitteeContract.CommitteeName = item.CommitteeName;
                    objFilerCommitteeContract.OfficeId = item.OfficeId;
                    objFilerCommitteeContract.personID = item.personID;
                    objFilerCommitteeContract.TreasurerId = item.TreasurerId;
                    objFilerCommitteeContract.CommTypeId = item.CommTypeId;
                    objFilerCommitteeContract.OfficTypeID = item.OfficTypeID;
                    objFilerCommitteeContract.OfficeTypeDesc = item.OfficeTypeDesc;
                    lstFilerCommitteeContract.Add(objFilerCommitteeContract);
                }

                return lstFilerCommitteeContract;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<PaymentMethodContract> GetPaymentMethodData()
        {
            IList<PaymentMethodContract> lstPaymentMethodContract = new List<PaymentMethodContract>();
            PaymentMethodContract objPaymentMethodContract;

            var results = objEFSRepository.GetPaymentMethodData();

            foreach (var item in results)
            {
                objPaymentMethodContract = new PaymentMethodContract();
                objPaymentMethodContract.PaymentTypeId = item.PaymentTypeId;
                objPaymentMethodContract.PaymentTypeDesc = item.PaymentTypeDesc;
                objPaymentMethodContract.PaymentTypeAbbrev = item.PaymentTypeAbbrev;
                lstPaymentMethodContract.Add(objPaymentMethodContract);
            }

            return lstPaymentMethodContract;
        }

        public IList<PurposeCodeContract> GetPurposeCodeData()
        {
            IList<PurposeCodeContract> lstPurposeCodeContract = new List<PurposeCodeContract>();
            PurposeCodeContract objPurposeCodeContract;

            var results = objEFSRepository.GetPurposeCodeData();

            foreach (var item in results)
            {
                objPurposeCodeContract = new PurposeCodeContract();
                objPurposeCodeContract.PurposeCodeId = item.PurposeCodeId;
                objPurposeCodeContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objPurposeCodeContract.PurposeCodeAbbrev = item.PurposeCodeAbbrev;
                lstPurposeCodeContract.Add(objPurposeCodeContract);
            }

            return lstPurposeCodeContract;
        }

        public IList<ReceiptCodeContract> GetReceiptCodeData()
        {
            IList<ReceiptCodeContract> lstReceiptCodeContract = new List<ReceiptCodeContract>();
            ReceiptCodeContract objReceiptCodeContract;

            var results = objEFSRepository.GetReceiptCodeData();

            foreach (var item in results)
            {
                objReceiptCodeContract = new ReceiptCodeContract();
                objReceiptCodeContract.ReceiptCodeId = item.ReceiptCodeId;
                objReceiptCodeContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objReceiptCodeContract.ReceiptCodeAbbrev = item.ReceiptCodeAbbrev;
                lstReceiptCodeContract.Add(objReceiptCodeContract);
            }

            return lstReceiptCodeContract;
        }

        public IList<ReceiptTypeContract> GetReceiptTypeData()
        {
            IList<ReceiptTypeContract> lstReceiptTypeContract = new List<ReceiptTypeContract>();
            ReceiptTypeContract objReceiptTypeContract;

            var results = objEFSRepository.GetReceiptTypeData();

            foreach (var item in results)
            {
                objReceiptTypeContract = new ReceiptTypeContract();
                objReceiptTypeContract.ReceiptTypeId = item.ReceiptTypeId;
                objReceiptTypeContract.ReceiptTypeDesc = item.ReceiptTypeDesc;
                objReceiptTypeContract.ReceiptTypeAbbrev = item.ReceiptTypeAbbrev;
                lstReceiptTypeContract.Add(objReceiptTypeContract);
            }

            return lstReceiptTypeContract;
        }

        public IList<TransferTypeContract> GetTransferTypeData()
        {
            IList<TransferTypeContract> lstTransferTypeContract = new List<TransferTypeContract>();
            TransferTypeContract objTransferTypeContract;

            var results = objEFSRepository.GetTransferTypeData();

            foreach (var item in results)
            {
                objTransferTypeContract = new TransferTypeContract();
                objTransferTypeContract.TransferTypeId = item.TransferTypeId;
                objTransferTypeContract.TransferTypeDesc = item.TransferTypeDesc;
                objTransferTypeContract.TransferTypeAbbrev = item.TransferTypeAbbrev;
                lstTransferTypeContract.Add(objTransferTypeContract);
            }

            return lstTransferTypeContract;
        }

        public IList<ElectionYearContract> GetElectionYearData(String filerID)
        {
            IList<ElectionYearContract> lstElectionYearContract = new List<ElectionYearContract>();
            ElectionYearContract objElectionYearContract;

            var results = objEFSRepository.GetElectionYearData(filerID);

            foreach (var item in results)
            {
                objElectionYearContract = new ElectionYearContract();
                objElectionYearContract.ElectionYearId = item.ElectionYearId;
                objElectionYearContract.ElectionYearValue = item.ElectionYearValue;
                lstElectionYearContract.Add(objElectionYearContract);
            }

            return lstElectionYearContract;
        }

        public IList<ElectionTypeContract> GetElectionTypeData(String strElectionYearId,
            String strOfficeTypeId, String strCountyId, String strMunicipalityId, String strCommTypeId)
        {
            IList<ElectionTypeContract> lstElectionTypeContract = new List<ElectionTypeContract>();
            ElectionTypeContract objElectionTypeContract;

            var results = objEFSRepository.GetElectionTypeData(strElectionYearId, strOfficeTypeId,
                strCountyId, strMunicipalityId, strCommTypeId);

            foreach (var item in results)
            {
                objElectionTypeContract = new ElectionTypeContract();
                objElectionTypeContract.ElectionTypeId = item.ElectionTypeId;
                objElectionTypeContract.ElectionTypeDesc = item.ElectionTypeDesc;
                lstElectionTypeContract.Add(objElectionTypeContract);
            }

            return lstElectionTypeContract;
        }

        public IList<FilingCutOffDateContract> GetFilingCutOffDateData(String strElectYearId, String strFilingTypeId, String strOfficeTypeId,
            String strFilingDateId, String strCuttOffDateId, String strElectionDateId)
        {
            IList<FilingCutOffDateContract> lstFilingCutOffDateContract = new List<FilingCutOffDateContract>();
            FilingCutOffDateContract objFilingCutOffDateContract;

            var results = objEFSRepository.GetFilingCutOffDateData(strElectYearId, strFilingTypeId, strOfficeTypeId, strFilingDateId, strCuttOffDateId, strElectionDateId);

            foreach (var item in results)
            {
                objFilingCutOffDateContract = new FilingCutOffDateContract();
                objFilingCutOffDateContract.PoliticalCalDateId = item.PoliticalCalDateId;
                objFilingCutOffDateContract.PoliticalCalLabelId = item.PoliticalCalLabelId;
                objFilingCutOffDateContract.FilingDueDate = item.FilingDueDate;
                objFilingCutOffDateContract.CutOffDate = item.CutOffDate;
                lstFilingCutOffDateContract.Add(objFilingCutOffDateContract);
            }

            return lstFilingCutOffDateContract;
        }

        public IList<ContributorTypesContract> GetContributorTypesData()
        {
            IList<ContributorTypesContract> lstContributorTypesContract = new List<ContributorTypesContract>();
            ContributorTypesContract objContributorTypesContract;

            var results = objEFSRepository.GetContributorTypesData();

            foreach (var item in results)
            {
                objContributorTypesContract = new ContributorTypesContract();
                objContributorTypesContract.ContributorTypeId = item.ContributorTypeId;
                objContributorTypesContract.ContributoryTypeDesc = item.ContributoryTypeDesc;
                lstContributorTypesContract.Add(objContributorTypesContract);
            }

            return lstContributorTypesContract;
        }

        /// <summary>
        /// GetTransactionTypesData
        /// </summary>
        /// <returns></returns>
        public IList<TransactionTypesContract> GetTransactionTypesData(String strCandCommId = "")
        {
            IList<TransactionTypesContract> lstTransactionTypesContract = new List<TransactionTypesContract>();
            TransactionTypesContract objTransactionTypesContract;

            var results = objEFSRepository.GetTransactionTypesData(strCandCommId);

            foreach (var item in results)
            {
                objTransactionTypesContract = new TransactionTypesContract();
                objTransactionTypesContract.FilingSchedId = item.FilingSchedId;
                objTransactionTypesContract.FilingSchedDesc = item.FilingSchedDesc;
                objTransactionTypesContract.FilingSchedAbbrev = item.FilingSchedAbbrev;
                lstTransactionTypesContract.Add(objTransactionTypesContract);
            }

            return lstTransactionTypesContract;
        }

        /// <summary>
        /// GetDisclosureTypesData
        /// </summary>
        /// <returns></returns>
        public IList<DisclosureTypesContract> GetDisclosureTypesData(String strCandCommId)
        {
            IList<DisclosureTypesContract> lstDisclosureTypesContract = new List<DisclosureTypesContract>();
            DisclosureTypesContract objDisclosureTypesContract;

            var results = objEFSRepository.GetDisclosureTypesData(strCandCommId);

            foreach (var item in results)
            {
                objDisclosureTypesContract = new DisclosureTypesContract();
                objDisclosureTypesContract.DisclosureTypeId = item.DisclosureTypeId;
                objDisclosureTypesContract.DisclosureTypeDesc = item.DisclosureTypeDesc;
                objDisclosureTypesContract.DisclosureSubTypeDesc = item.DisclosureSubTypeDesc;
                lstDisclosureTypesContract.Add(objDisclosureTypesContract);
            }

            return lstDisclosureTypesContract;
        }

        /// <summary>
        /// AddFilingTransactionsData
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public string AddFlngTransContrInKindData(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.ElectionDate = objFilingTransactionsContract.ElectionDate;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.FilingTypeId = objFilingTransactionsContract.FilingTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.ElectionYear = objFilingTransactionsContract.ElectionYear;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.OrgDate = objFilingTransactionsContract.OrgDate;
            objFilingTransactionsEntity.RBankLoan = objFilingTransactionsContract.RBankLoan;
            objFilingTransactionsEntity.ReceiptTypeId = objFilingTransactionsContract.ReceiptTypeId;
            objFilingTransactionsEntity.ReceiptCodeId = objFilingTransactionsContract.ReceiptCodeId;
            objFilingTransactionsEntity.FlngEntFirstName = objFilingTransactionsContract.FlngEntFirstName;
            objFilingTransactionsEntity.FlngEntLastName = objFilingTransactionsContract.FlngEntLastName;
            objFilingTransactionsEntity.FlngEntMiddleName = objFilingTransactionsContract.FlngEntMiddleName;
            objFilingTransactionsEntity.DistOffCandBalProp = objFilingTransactionsContract.DistOffCandBalProp;
            objFilingTransactionsEntity.FlngEntStrNum = objFilingTransactionsContract.FlngEntStrNum;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.RItemized = objFilingTransactionsContract.RItemized;
            objFilingTransactionsEntity.TransferTypeId = objFilingTransactionsContract.TransferTypeId;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.ContributorTypeId = objFilingTransactionsContract.ContributorTypeId;
            objFilingTransactionsEntity.ContributionTypeId = objFilingTransactionsContract.ContributionTypeId;
            objFilingTransactionsEntity.PurposeCodeId = objFilingTransactionsContract.PurposeCodeId;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.LoanOtherId = objFilingTransactionsContract.LoanOtherId;
            objFilingTransactionsEntity.TransCode = objFilingTransactionsContract.TransCode;
            objFilingTransactionsEntity.TransDesc = objFilingTransactionsContract.TransDesc;
            objFilingTransactionsEntity.PayDate = objFilingTransactionsContract.PayDate;
            objFilingTransactionsEntity.OwedAmt = objFilingTransactionsContract.OwedAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            objFilingTransactionsEntity.ResigTermTypeId = objFilingTransactionsContract.ResigTermTypeId;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;
            objFilingTransactionsEntity.MunicipalityID = objFilingTransactionsContract.MunicipalityID;
            objFilingTransactionsEntity.TreasurerEmployer = objFilingTransactionsContract.TreasurerEmployer;
            objFilingTransactionsEntity.TreasurerOccupation = objFilingTransactionsContract.TreasurerOccupation;
            objFilingTransactionsEntity.TreasurerStreetAddress = objFilingTransactionsContract.TreasurerStreetAddress;
            objFilingTransactionsEntity.TreasurerCity = objFilingTransactionsContract.TreasurerCity;
            objFilingTransactionsEntity.TreasurerState = objFilingTransactionsContract.TreasurerState;
            objFilingTransactionsEntity.TreasurerZip = objFilingTransactionsContract.TreasurerZip;
            objFilingTransactionsEntity.CommTypeID = objFilingTransactionsContract.CommTypeID;
            objFilingTransactionsEntity.RContributions = objFilingTransactionsContract.RContributions;

            string result = objEFSRepository.AddFlngTransContrInKindData(objFilingTransactionsEntity);

            return result;
        }

        public IList<OfficeTypeContract> GetOfficeType()
        {
            IList<OfficeTypeContract> lstOfficeTypeContract = new List<OfficeTypeContract>();
            OfficeTypeContract objOfficeTypeContract;

            var results = objEFSRepository.GetOfficeType();

            foreach (var item in results)
            {
                objOfficeTypeContract = new OfficeTypeContract();
                objOfficeTypeContract.OfficeTypeId = item.OfficeTypeId;
                objOfficeTypeContract.OfficeTypeDesc = item.OfficeTypeDesc;
                lstOfficeTypeContract.Add(objOfficeTypeContract);
            }

            return lstOfficeTypeContract;
        }

        public IList<CountyContract> GetCounty()
        {
            IList<CountyContract> lstCountyContract = new List<CountyContract>();
            CountyContract objCountyContract;

            var results = objEFSRepository.GetCounty();

            foreach (var item in results)
            {
                objCountyContract = new CountyContract();
                objCountyContract.CountyId = item.CountyId;
                objCountyContract.CountyDesc = item.CountyDesc;
                lstCountyContract.Add(objCountyContract);
            }

            return lstCountyContract;
        }

        public IList<MunicipalityContract> GetMunicipality(String strCountyId)
        {
            IList<MunicipalityContract> lstMunicipalityContract = new List<MunicipalityContract>();
            MunicipalityContract objMunicipalityContract;

            var results = objEFSRepository.GetMunicipality(strCountyId);

            foreach (var item in results)
            {
                objMunicipalityContract = new MunicipalityContract();
                objMunicipalityContract.MunicipalityId = item.MunicipalityId;
                objMunicipalityContract.MunicipalityDesc = item.MunicipalityDesc;
                lstMunicipalityContract.Add(objMunicipalityContract);
            }

            return lstMunicipalityContract;
        }

        /// <summary>
        /// GetAutoCompleteNameAddress
        /// </summary>
        /// <param name="name"></param>
        /// <param name="strFilerId"></param>
        /// <param name="strFLName"></param>
        /// <returns></returns>
        public IList<AutoCompFLNameAddressContract> GetAutoCompleteNameAddress(String name, String strFilerId, String strFLName)
        {
            IList<AutoCompFLNameAddressContract> lstAutoCompFLNameAddressContract = new List<AutoCompFLNameAddressContract>();
            AutoCompFLNameAddressContract objAutoCompFLNameAddressContract;

            var results = objEFSRepository.GetAutoCompleteNameAddress(name, strFilerId, strFLName);

            foreach (var item in results)
            {
                objAutoCompFLNameAddressContract = new AutoCompFLNameAddressContract();
                objAutoCompFLNameAddressContract.FilingEntityId = item.FilingEntityId;
                objAutoCompFLNameAddressContract.FilingEntityName = item.FilingEntityName;
                objAutoCompFLNameAddressContract.FilingEntityFirstName = item.FilingEntityFirstName;
                objAutoCompFLNameAddressContract.FilingEntityMiddleName = item.FilingEntityMiddleName;
                objAutoCompFLNameAddressContract.FilingEntityLastName = item.FilingEntityLastName;
                objAutoCompFLNameAddressContract.FilingEntityStreetNum = item.FilingEntityStreetNum;
                objAutoCompFLNameAddressContract.FilingEntityStreetName = item.FilingEntityStreetName;
                objAutoCompFLNameAddressContract.FilingEntityCity = item.FilingEntityCity;
                objAutoCompFLNameAddressContract.FilingEntityState = item.FilingEntityState;
                objAutoCompFLNameAddressContract.FilingEntityZip = item.FilingEntityZip;
                objAutoCompFLNameAddressContract.FilingEntityCountry = item.FilingEntityCountry;
                objAutoCompFLNameAddressContract.FilingEntityNameAndAddress = item.FilingEntityNameAndAddress;
                lstAutoCompFLNameAddressContract.Add(objAutoCompFLNameAddressContract);
            }

            return lstAutoCompFLNameAddressContract;
        }

        /// <summary>
        /// DeleteFilingTransactionsData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        public Boolean DeleteFilingTransactionsData(String strTransNumber, String strModifiedBy, String strFilerID)
        {
            Boolean results = objEFSRepository.DeleteFilingTransactionsData(strTransNumber, strModifiedBy, strFilerID);

            return results;
        }

        /// <summary>
        /// DeleteFlngTransExpPaySchedFNData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        public Boolean DeleteFlngTransExpPaySchedFNData(String strLoanLiabNumberOrg, String strTransNumberOrg, String strRLiability, String strModifiedBy, String strFilerID, String strSchedID)
        {
            Boolean results = objEFSRepository.DeleteFlngTransExpPaySchedFNData(strLoanLiabNumberOrg, strTransNumberOrg, strRLiability, strModifiedBy, strFilerID, strSchedID);

            return results;
        }


        /// <summary>
        /// UpdateFilingTransContrInKindData
        /// </summary>
        /// <param name="objFilingTransactionDataContract"></param>
        /// <returns></returns>
        public Boolean UpdateFilingTransContrInKindData(FilingTransactionDataContract objFilingTransactionDataContract)
        {

            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilingTransId = objFilingTransactionDataContract.FilingTransId;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionDataContract.FilingEntityId;
            objFilingTransactionsEntity.ContributionTypeId = objFilingTransactionDataContract.ContributionTypeId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionDataContract.SchedDate;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionDataContract.PayNumber;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionDataContract.PaymentTypeId;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionDataContract.OriginalAmount;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionDataContract.TransExplanation;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionDataContract.FilingEntityName;
            objFilingTransactionsEntity.FlngEntFirstName = objFilingTransactionDataContract.FilingFirstName;
            objFilingTransactionsEntity.FlngEntMiddleName = objFilingTransactionDataContract.FilingMiddleName;
            objFilingTransactionsEntity.FlngEntLastName = objFilingTransactionDataContract.FilingLastName;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionDataContract.FilingCountry;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionDataContract.FilingStreetName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionDataContract.FilingCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionDataContract.FilingState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionDataContract.FilingZip;
            objFilingTransactionsEntity.ModifiedBy = objFilingTransactionDataContract.ModifiedBy;
            objFilingTransactionsEntity.FilerId = objFilingTransactionDataContract.FilerId;
            objFilingTransactionsEntity.TreasurerEmployer = objFilingTransactionDataContract.TreasurerEmployer;
            objFilingTransactionsEntity.TreasurerOccupation = objFilingTransactionDataContract.TreasurerOccuptaion;
            objFilingTransactionsEntity.TreasurerStreetAddress = objFilingTransactionDataContract.TreasurerStreetAddress;
            objFilingTransactionsEntity.TreasurerCity = objFilingTransactionDataContract.TreasurerCity;
            objFilingTransactionsEntity.TreasurerState = objFilingTransactionDataContract.TreasurerState;
            objFilingTransactionsEntity.TreasurerZip = objFilingTransactionDataContract.TreasurerZip;
            objFilingTransactionsEntity.CommTypeID = objFilingTransactionDataContract.CommTypeID;
            objFilingTransactionsEntity.RContributions = objFilingTransactionDataContract.RContributions;

            Boolean returnValue = objEFSRepository.UpdateFilingTransContrInKindData(objFilingTransactionsEntity);

            return returnValue;
        }

        /// <summary>
        /// Viewable Column
        /// </summary>
        /// <param name="strUniqueID"></param>
        /// <param name="strApplicationName"></param>
        /// <param name="strPageName"></param>
        /// <returns></returns>
        public IList<ViewableColumnContract> GetViewableColumns(String strUniqueID, String strApplicationName, String strPageName)
        {
            IList<ViewableColumnContract> lstViewableColumnEntity = new List<ViewableColumnContract>();
            ViewableColumnContract objViewableColumnEntity;
            var results = objEFSRepository.GetViewableColumns(strUniqueID, strApplicationName, strPageName);

            foreach (var item in results)
            {
                objViewableColumnEntity = new ViewableColumnContract();
                objViewableColumnEntity.ViewableFieldID = item.ViewableFieldID.ToString();
                objViewableColumnEntity.UniqueID = item.UniqueID;
                objViewableColumnEntity.ColumnName = item.ColumnName;
                objViewableColumnEntity.Viewable = item.Viewable;
                lstViewableColumnEntity.Add(objViewableColumnEntity);
            }
            return lstViewableColumnEntity;
        }

        public IList<ContributorNameContract> GetPartnerSubContractorData()
        {
            IList<ContributorNameContract> lstContributorNameContract = new List<ContributorNameContract>();
            ContributorNameContract objContributorNameContract;

            var results = objEFSRepository.GetPartnerSubContractorData();

            foreach (var item in results)
            {
                objContributorNameContract = new ContributorNameContract();
                objContributorNameContract.ContributorTypeId = item.ContributorTypeId;
                objContributorNameContract.ContributorTypeDesc = item.ContributorTypeDesc;
                objContributorNameContract.ContributorTypeAbbrev = item.ContributorTypeAbbrev;
                lstContributorNameContract.Add(objContributorNameContract);
            }

            return lstContributorNameContract;
        }


        /// <summary>
        /// Update Column Value
        /// </summary>
        /// <param name="uniqueID"></param>
        /// <param name="applicationName"></param>
        /// <param name="pageName"></param>
        /// <param name="uniqueValue"></param>
        /// <param name="modifyBy"></param>
        /// <returns></returns>
        public Boolean UpdateColumnValue(String uniqueID, String applicationName, String pageName, String uniqueValue, String modifyBy)
        {
            Boolean result = objEFSRepository.UpdateColumnValue(uniqueID,
                                         applicationName,
                                         pageName,
                                         uniqueValue,
                                         modifyBy);

            return result;
        }

        //public Boolean AddLoanReceivedData(List<FilingTransactionsContract> objFilingTransactionsContract)
        //{
        //    IList<FilingTransactionsEntity> lstFilingTransactionsEntity = new List<FilingTransactionsEntity>();
        //    FilingTransactionsEntity objFilingTransactionsEntity;
        //    foreach (var item in objFilingTransactionsContract)
        //    {
        //        objFilingTransactionsEntity = new FilingTransactionsEntity();
        //        objFilingTransactionsEntity.FilerId = item.FilerId;
        //        objFilingTransactionsEntity.FilingTransId = item.FilingTransId;
        //        objFilingTransactionsEntity.FilingSchedId = item.FilingSchedId;
        //        objFilingTransactionsEntity.SchedDate = item.SchedDate;
        //        objFilingTransactionsEntity.OrgAmt = item.OrgAmt;
        //        objFilingTransactionsEntity.ElectionDate = item.ElectionDate;
        //        objFilingTransactionsEntity.ElectionTypeId = item.ElectionTypeId;
        //        objFilingTransactionsEntity.OfficeTypeId = item.OfficeTypeId;
        //        objFilingTransactionsEntity.FilingTypeId = item.FilingTypeId;
        //        objFilingTransactionsEntity.ElectYearId = item.ElectYearId;
        //        objFilingTransactionsEntity.ElectionYear = item.ElectionYear;
        //        objFilingTransactionsEntity.FilingEntId = item.FilingEntId;
        //        objFilingTransactionsEntity.FlngEntFirstName = item.FlngEntFirstName;
        //        objFilingTransactionsEntity.FlngEntLastName = item.FlngEntLastName;
        //        objFilingTransactionsEntity.FlngEntMiddleName = item.FlngEntMiddleName;
        //        objFilingTransactionsEntity.DistOffCandBalProp = item.DistOffCandBalProp;
        //        objFilingTransactionsEntity.FlngEntStrNum = item.FlngEntStrNum;
        //        objFilingTransactionsEntity.FlngEntStrName = item.FlngEntStrName;
        //        objFilingTransactionsEntity.FlngEntCity = item.FlngEntCity;
        //        objFilingTransactionsEntity.FlngEntState = item.FlngEntState;
        //        objFilingTransactionsEntity.FlngEntZip = item.FlngEntZip;
        //        objFilingTransactionsEntity.FlngEntZip4 = item.FlngEntZip4;
        //        objFilingTransactionsEntity.TransExplanation = item.TransExplanation;
        //        objFilingTransactionsEntity.CreatedBy = item.CreatedBy;
        //        lstFilingTransactionsEntity.Add(objFilingTransactionsEntity);
        //    }


        //    Boolean result = objEFSRepository.AddLoanReceivedData(lstFilingTransactionsEntity);

        //    return result;
        //}

        /// <summary>
        /// AddContrInKindPartnersData
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean AddContrInKindPartnersData(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.TransNumber = objFilingTransactionsContract.TransNumber;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntFirstName = objFilingTransactionsContract.FlngEntFirstName;
            objFilingTransactionsEntity.FlngEntLastName = objFilingTransactionsContract.FlngEntLastName;
            objFilingTransactionsEntity.FlngEntMiddleName = objFilingTransactionsContract.FlngEntMiddleName;
            objFilingTransactionsEntity.DistOffCandBalProp = objFilingTransactionsContract.DistOffCandBalProp;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.RItemized = objFilingTransactionsContract.RItemized;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            objFilingTransactionsEntity.TreasurerEmployer = objFilingTransactionsContract.TreasurerEmployer;
            objFilingTransactionsEntity.TreasurerOccupation = objFilingTransactionsContract.TreasurerOccupation;
            objFilingTransactionsEntity.TreasurerStreetAddress = objFilingTransactionsContract.TreasurerStreetAddress;
            objFilingTransactionsEntity.TreasurerCity = objFilingTransactionsContract.TreasurerCity;
            objFilingTransactionsEntity.TreasurerState = objFilingTransactionsContract.TreasurerState;
            objFilingTransactionsEntity.TreasurerZip = objFilingTransactionsContract.TreasurerZip;
            objFilingTransactionsEntity.CommTypeID = objFilingTransactionsContract.CommTypeID;
            objFilingTransactionsEntity.RContributions = objFilingTransactionsContract.RContributions;
            objFilingTransactionsEntity.SchedID = objFilingTransactionsContract.SchedID;
            Boolean result = objEFSRepository.AddContrInKindPartnersData(objFilingTransactionsEntity);

            return result;
        }

        /// <summary>
        /// GetContrInKindPartnersData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<ContrInKindPartnersContract> GetContrInKindPartnersData(String strFilingTransId, String strFilerId)
        {
            IList<ContrInKindPartnersContract> lstContrInKindPartnersContract = new List<ContrInKindPartnersContract>();
            ContrInKindPartnersContract objContrInKindPartnersContract;

            var results = objEFSRepository.GetContrInKindPartnersData(strFilingTransId, strFilerId);

            foreach (var item in results)
            {
                objContrInKindPartnersContract = new ContrInKindPartnersContract();
                objContrInKindPartnersContract.FilingTransId = item.FilingTransId;
                objContrInKindPartnersContract.FilingEntityId = item.FilingEntityId;
                objContrInKindPartnersContract.PartnershipName = item.PartnershipName;
                objContrInKindPartnersContract.PartnerFirstName = item.PartnerFirstName;
                objContrInKindPartnersContract.PartnerMiddleName = item.PartnerMiddleName;
                objContrInKindPartnersContract.PartnerLastName = item.PartnerLastName;
                objContrInKindPartnersContract.PartnerStreetNo = item.PartnerStreetNo;
                objContrInKindPartnersContract.PartnerStreetName = item.PartnerStreetName;
                objContrInKindPartnersContract.PartnerCity = item.PartnerCity;
                objContrInKindPartnersContract.PartnerState = item.PartnerState;
                objContrInKindPartnersContract.PartnerZip5 = item.PartnerZip5;
                objContrInKindPartnersContract.PartnershipCountry = item.PartnershipCountry;
                objContrInKindPartnersContract.PartnerAmountAttributed = item.PartnerAmountAttributed;
                objContrInKindPartnersContract.PartnerExplanation = item.PartnerExplanation;
                objContrInKindPartnersContract.RUnitemzied = item.RItemized;
                objContrInKindPartnersContract.TransNumber = item.TransNumber;
                objContrInKindPartnersContract.TransMapping = item.TransMapping;
                objContrInKindPartnersContract.TreasurerEmployer = item.TreasurerEmployer;
                objContrInKindPartnersContract.TreasurerOccupation = item.TreasurerOccupation;
                objContrInKindPartnersContract.TreaAddress = item.TreaAddress;
                objContrInKindPartnersContract.TreaAddr1 = item.TreaAddr1;
                objContrInKindPartnersContract.TreaCity = item.TreaCity;
                objContrInKindPartnersContract.TreaState = item.TreaState;
                objContrInKindPartnersContract.TreaZipCode = item.TreaZipCode;
                objContrInKindPartnersContract.RContributions = item.RContributions;
                lstContrInKindPartnersContract.Add(objContrInKindPartnersContract);
            }

            return lstContrInKindPartnersContract;
        }

        /// <summary>
        /// DeleteContrInKindPartnersData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strFilingTransMapping"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        public Boolean DeleteContrInKindPartnersData(String strTransNumber, String strModifiedBy, String strFilerID)
        {
            Boolean returnValue = objEFSRepository.DeleteContrInKindPartnersData(strTransNumber, strModifiedBy, strFilerID);

            return returnValue;
        }

        /// <summary>
        /// UpdateContrInKindPartnersData
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean UpdateContrInKindPartnersData(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();

            objFilingTransactionsEntity.TransNumber = objFilingTransactionsContract.TransNumber;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntFirstName = objFilingTransactionsContract.FlngEntFirstName;
            objFilingTransactionsEntity.FlngEntMiddleName = objFilingTransactionsContract.FlngEntMiddleName;
            objFilingTransactionsEntity.FlngEntLastName = objFilingTransactionsContract.FlngEntLastName;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.ModifiedBy = objFilingTransactionsContract.ModifiedBy;
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.TreasurerEmployer = objFilingTransactionsContract.TreasurerEmployer;
            objFilingTransactionsEntity.TreasurerOccupation = objFilingTransactionsContract.TreasurerOccupation;
            objFilingTransactionsEntity.TreasurerStreetAddress = objFilingTransactionsContract.TreasurerStreetAddress;
            objFilingTransactionsEntity.TreasurerCity = objFilingTransactionsContract.TreasurerCity;
            objFilingTransactionsEntity.TreasurerState = objFilingTransactionsContract.TreasurerState;
            objFilingTransactionsEntity.TreasurerZip = objFilingTransactionsContract.TreasurerZip;
            objFilingTransactionsEntity.CommTypeID = objFilingTransactionsContract.CommTypeID;
            objFilingTransactionsEntity.RContributions = objFilingTransactionsContract.RContributions;

            Boolean returnValue = objEFSRepository.UpdateContrInKindPartnersData(objFilingTransactionsEntity);

            return returnValue;
        }

        /// <summary>
        /// Add Transfer In scheudled data
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public string AddFilingTransaction_TransferIn(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.TransferTypeId = objFilingTransactionsContract.TransferTypeId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.FilingTypeId = objFilingTransactionsContract.FilingTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.FlngEntZip4 = objFilingTransactionsContract.FlngEntZip4;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;
            objFilingTransactionsEntity.ResigTermTypeId = objFilingTransactionsContract.ResigTermTypeId;
            objFilingTransactionsEntity.MunicipalityID = objFilingTransactionsContract.MunicipalityID;

            string result = objEFSRepository.AddFilingTransaction_TransferIn(objFilingTransactionsEntity);

            return result;
        }

        /// <summary>
        /// Update Filing Transaction
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean UpdateFilingTransaction_TransferIn(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.TransferTypeId = objFilingTransactionsContract.TransferTypeId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.FlngEntZip4 = objFilingTransactionsContract.FlngEntZip4;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            objFilingTransactionsEntity.TransNumber = objFilingTransactionsContract.TransNumber;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.FilingTypeId = objFilingTransactionsContract.FilingTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;


            Boolean result = objEFSRepository.UpdateFilingTransaction_TransferIn(objFilingTransactionsEntity);

            return result;
        }

        /// <summary>
        /// AddFilingTransaction_NonCompHKReceipts
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public string AddFilingTransaction_NonCompHKReceipts(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.ReceiptCodeId = objFilingTransactionsContract.ReceiptCodeId;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.ElectionDate = objFilingTransactionsContract.ElectionDate;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.FilingTypeId = objFilingTransactionsContract.FilingTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.ElectionYear = objFilingTransactionsContract.ElectionYear;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntFirstName = objFilingTransactionsContract.FlngEntFirstName;
            objFilingTransactionsEntity.FlngEntLastName = objFilingTransactionsContract.FlngEntLastName;
            objFilingTransactionsEntity.FlngEntMiddleName = objFilingTransactionsContract.FlngEntMiddleName;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.RItemized = objFilingTransactionsContract.RItemized;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;
            objFilingTransactionsEntity.ResigTermTypeId = objFilingTransactionsContract.ResigTermTypeId;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;
            objFilingTransactionsEntity.MunicipalityID = objFilingTransactionsContract.MunicipalityID;

            string results = objEFSRepository.AddFilingTransaction_NonCompHKReceipts(objFilingTransactionsEntity);

            return results;
        }

        public Boolean UpdateFilingTransNonCompHKReceipts(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.TransNumber = objFilingTransactionsContract.TransNumber;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.ReceiptCodeId = objFilingTransactionsContract.ReceiptCodeId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntFirstName = objFilingTransactionsContract.FlngEntFirstName;
            objFilingTransactionsEntity.FlngEntMiddleName = objFilingTransactionsContract.FlngEntMiddleName;
            objFilingTransactionsEntity.FlngEntLastName = objFilingTransactionsContract.FlngEntLastName;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.ModifiedBy = objFilingTransactionsContract.ModifiedBy;
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;

            Boolean results = objEFSRepository.UpdateFilingTransNonCompHKReceipts(objFilingTransactionsEntity);

            return results;
        }

        /// <summary>
        /// Add Transfer Out scheudled data
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public string AddFilingTransaction_TransferOut(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.TransferTypeId = objFilingTransactionsContract.TransferTypeId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.FilingTypeId = objFilingTransactionsContract.FilingTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.FlngEntZip4 = objFilingTransactionsContract.FlngEntZip4;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;
            objFilingTransactionsEntity.ResigTermTypeId = objFilingTransactionsContract.ResigTermTypeId;
            objFilingTransactionsEntity.MunicipalityID = objFilingTransactionsContract.MunicipalityID;

            string result = objEFSRepository.AddFilingTransaction_TransferOut(objFilingTransactionsEntity);

            return result;
        }

        /// <summary>
        /// Update Filing Transaction
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean UpdateFilingTransaction_TransferOut(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.TransferTypeId = objFilingTransactionsContract.TransferTypeId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.FlngEntZip4 = objFilingTransactionsContract.FlngEntZip4;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            objFilingTransactionsEntity.TransNumber = objFilingTransactionsContract.TransNumber;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;

            Boolean result = objEFSRepository.UpdateFilingTransaction_TransferOut(objFilingTransactionsEntity);

            return result;
        }

        /// <summary>
        /// Add Loan Received scheudled data
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public string AddFilingTransaction_LoanReceived(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.OtherFilingSchedId = objFilingTransactionsContract.OtherFilingSchedId;
            objFilingTransactionsEntity.TransferTypeId = objFilingTransactionsContract.TransferTypeId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.OtherTransExplanation = objFilingTransactionsContract.OtherTransExplanation;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.FilingTypeId = objFilingTransactionsContract.FilingTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntFirstName = objFilingTransactionsContract.FlngEntFirstName;
            objFilingTransactionsEntity.FlngEntMiddleName = objFilingTransactionsContract.FlngEntMiddleName;
            objFilingTransactionsEntity.FlngEntLastName = objFilingTransactionsContract.FlngEntLastName;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.FlngEntZip4 = objFilingTransactionsContract.FlngEntZip4;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.LoanOtherId = objFilingTransactionsContract.LoanOtherId;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;
            objFilingTransactionsEntity.ResigTermTypeId = objFilingTransactionsContract.ResigTermTypeId;
            objFilingTransactionsEntity.MunicipalityID = objFilingTransactionsContract.MunicipalityID;
            objFilingTransactionsEntity.TreasurerEmployer = objFilingTransactionsContract.TreasurerEmployer;
            objFilingTransactionsEntity.TreasurerOccupation = objFilingTransactionsContract.TreasurerOccupation;
            objFilingTransactionsEntity.TreasurerStreetAddress = objFilingTransactionsContract.TreasurerStreetAddress;
            objFilingTransactionsEntity.TreasurerCity = objFilingTransactionsContract.TreasurerCity;
            objFilingTransactionsEntity.TreasurerState = objFilingTransactionsContract.TreasurerState;
            objFilingTransactionsEntity.TreasurerZip = objFilingTransactionsContract.TreasurerZip;
            objFilingTransactionsEntity.CommTypeID = objFilingTransactionsContract.CommTypeID;

            string result = objEFSRepository.AddFilingTransaction_LoanReceived(objFilingTransactionsEntity);

            return result;
        }

        public string AddFilingTransaction_LoanRepayment(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.OtherFilingSchedId = objFilingTransactionsContract.OtherFilingSchedId;
            objFilingTransactionsEntity.TransferTypeId = objFilingTransactionsContract.TransferTypeId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.OtherTransExplanation = objFilingTransactionsContract.OtherTransExplanation;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.FilingTypeId = objFilingTransactionsContract.FilingTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntFirstName = objFilingTransactionsContract.FlngEntFirstName;
            objFilingTransactionsEntity.FlngEntMiddleName = objFilingTransactionsContract.FlngEntMiddleName;
            objFilingTransactionsEntity.FlngEntLastName = objFilingTransactionsContract.FlngEntLastName;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.LoanOtherId = objFilingTransactionsContract.LoanOtherId;            
            objFilingTransactionsEntity.OtherAmount = objFilingTransactionsContract.OtherAmount;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;
            objFilingTransactionsEntity.ResigTermTypeId = objFilingTransactionsContract.ResigTermTypeId;
            objFilingTransactionsEntity.Loan_Lib_Number = objFilingTransactionsContract.Loan_Lib_Number;
            objFilingTransactionsEntity.TransNumber = objFilingTransactionsContract.TransNumber;
            objFilingTransactionsEntity.MunicipalityID = objFilingTransactionsContract.MunicipalityID;

            string result = objEFSRepository.AddFilingTransaction_LoanRepayment(objFilingTransactionsEntity);

            return result;
        }

        /// <summary>
        /// Update Filing Transaction
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean UpdateFilingTransaction_LoanReceived(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.TransferTypeId = objFilingTransactionsContract.TransferTypeId;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.OtherTransExplanation = objFilingTransactionsContract.OtherTransExplanation;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntFirstName = objFilingTransactionsContract.FlngEntFirstName;
            objFilingTransactionsEntity.FlngEntMiddleName = objFilingTransactionsContract.FlngEntMiddleName;
            objFilingTransactionsEntity.FlngEntLastName = objFilingTransactionsContract.FlngEntLastName;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.ModifiedBy = objFilingTransactionsContract.ModifiedBy;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.LoanOtherId = objFilingTransactionsContract.LoanOtherId;
            objFilingTransactionsEntity.IsAmtChanged = objFilingTransactionsContract.IsAmtChanged;
            objFilingTransactionsEntity.Loan_Lib_Number = objFilingTransactionsContract.Loan_Lib_Number;
            objFilingTransactionsEntity.TransNumber = objFilingTransactionsContract.TransNumber;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.TreasurerEmployer = objFilingTransactionsContract.TreasurerEmployer;
            objFilingTransactionsEntity.TreasurerOccupation = objFilingTransactionsContract.TreasurerOccupation;
            objFilingTransactionsEntity.TreasurerStreetAddress = objFilingTransactionsContract.TreasurerStreetAddress;
            objFilingTransactionsEntity.TreasurerCity = objFilingTransactionsContract.TreasurerCity;
            objFilingTransactionsEntity.TreasurerState = objFilingTransactionsContract.TreasurerState;
            objFilingTransactionsEntity.TreasurerZip = objFilingTransactionsContract.TreasurerZip;
            objFilingTransactionsEntity.CommTypeID = objFilingTransactionsContract.CommTypeID;

            Boolean result = objEFSRepository.UpdateFilingTransaction_LoanReceived(objFilingTransactionsEntity);

            return result;
        }

        /// <summary>
        /// Get Loaner Code
        /// </summary>
        /// <returns></returns>
        public IList<LoanerCodeContract> GetLoanerCode()
        {
            IList<LoanerCodeContract> lstLoanerCodeContract = new List<LoanerCodeContract>();
            LoanerCodeContract objLoanerCodeContract;

            var results = objEFSRepository.GetLoanerCode();

            foreach (var item in results)
            {
                objLoanerCodeContract = new LoanerCodeContract();
                objLoanerCodeContract.LoanerID = Convert.ToString(item.LoanerID);
                objLoanerCodeContract.LoanerDesc = item.LoanerDesc;
                lstLoanerCodeContract.Add(objLoanerCodeContract);
            }
            return lstLoanerCodeContract;
        }

        #region AddFlngTransContrMonetaryData
        /// <summary>
        /// AddFlngTransContrMonetaryData
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public string AddFlngTransContrMonetaryData(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.ContributorTypeId = objFilingTransactionsContract.ContributorTypeId;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.ElectionDate = objFilingTransactionsContract.ElectionDate;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.FilingTypeId = objFilingTransactionsContract.FilingTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.ElectionYear = objFilingTransactionsContract.ElectionYear;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntFirstName = objFilingTransactionsContract.FlngEntFirstName;
            objFilingTransactionsEntity.FlngEntLastName = objFilingTransactionsContract.FlngEntLastName;
            objFilingTransactionsEntity.FlngEntMiddleName = objFilingTransactionsContract.FlngEntMiddleName;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.RItemized = objFilingTransactionsContract.RItemized;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            objFilingTransactionsEntity.ResigTermTypeId = objFilingTransactionsContract.ResigTermTypeId;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;
            objFilingTransactionsEntity.MunicipalityID = objFilingTransactionsContract.MunicipalityID;
            objFilingTransactionsEntity.IsClaim = objFilingTransactionsContract.IsClaim;
            objFilingTransactionsEntity.InDistrict = objFilingTransactionsContract.InDistrict;
            objFilingTransactionsEntity.Minor = objFilingTransactionsContract.Minor;
            objFilingTransactionsEntity.Vendor = objFilingTransactionsContract.Vendor;
            objFilingTransactionsEntity.Lobbyist = objFilingTransactionsContract.Lobbyist;
            objFilingTransactionsEntity.TreasurerEmployer = objFilingTransactionsContract.TreasurerEmployer;
            objFilingTransactionsEntity.TreasurerOccupation = objFilingTransactionsContract.TreasurerOccupation;
            objFilingTransactionsEntity.TreasurerStreetAddress = objFilingTransactionsContract.TreasurerStreetAddress;
            objFilingTransactionsEntity.TreasurerCity = objFilingTransactionsContract.TreasurerCity;
            objFilingTransactionsEntity.TreasurerState = objFilingTransactionsContract.TreasurerState;
            objFilingTransactionsEntity.TreasurerZip = objFilingTransactionsContract.TreasurerZip;
            objFilingTransactionsEntity.CommTypeID = objFilingTransactionsContract.CommTypeID;
            objFilingTransactionsEntity.RContributions = objFilingTransactionsContract.RContributions;

            string result = objEFSRepository.AddFlngTransContrMonetaryData(objFilingTransactionsEntity);

            return result;
        }
        #endregion AddFlngTransContrMonetaryData

        /// <summary>
        /// UpdateFlngTransMonetaryContrData
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean UpdateFlngTransMonetaryContrData(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.TransNumber = objFilingTransactionsContract.TransNumber;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.ContributorTypeId = objFilingTransactionsContract.ContributorTypeId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntFirstName = objFilingTransactionsContract.FlngEntFirstName;
            objFilingTransactionsEntity.FlngEntMiddleName = objFilingTransactionsContract.FlngEntMiddleName;
            objFilingTransactionsEntity.FlngEntLastName = objFilingTransactionsContract.FlngEntLastName;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.ModifiedBy = objFilingTransactionsContract.ModifiedBy;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.FilingTypeId = objFilingTransactionsContract.FilingTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.IsClaim = objFilingTransactionsContract.IsClaim;
            objFilingTransactionsEntity.InDistrict = objFilingTransactionsContract.InDistrict;
            objFilingTransactionsEntity.Minor = objFilingTransactionsContract.Minor;
            objFilingTransactionsEntity.Vendor = objFilingTransactionsContract.Vendor;
            objFilingTransactionsEntity.Lobbyist = objFilingTransactionsContract.Lobbyist;
            objFilingTransactionsEntity.TreasurerEmployer = objFilingTransactionsContract.TreasurerEmployer;
            objFilingTransactionsEntity.TreasurerOccupation = objFilingTransactionsContract.TreasurerOccupation;
            objFilingTransactionsEntity.TreasurerStreetAddress = objFilingTransactionsContract.TreasurerStreetAddress;
            objFilingTransactionsEntity.TreasurerCity = objFilingTransactionsContract.TreasurerCity;
            objFilingTransactionsEntity.TreasurerState = objFilingTransactionsContract.TreasurerState;
            objFilingTransactionsEntity.TreasurerZip = objFilingTransactionsContract.TreasurerZip;
            objFilingTransactionsEntity.CommTypeID = objFilingTransactionsContract.CommTypeID;
            objFilingTransactionsEntity.RContributions = objFilingTransactionsContract.RContributions;

            Boolean returnValue = objEFSRepository.UpdateFlngTransMonetaryContrData(objFilingTransactionsEntity);

            return returnValue;
        }

        /// <summary>
        /// AddFlngTransExpenditureData
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public String AddFlngTransExpenditureData(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.TransNumber = objFilingTransactionsContract.TransNumber;
            objFilingTransactionsEntity.TransNumberOrg = objFilingTransactionsContract.TransNumberOrg;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.PurposeCodeId = objFilingTransactionsContract.PurposeCodeId;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgDate = objFilingTransactionsContract.OrgDate;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.LiabilityOrgAmt = objFilingTransactionsContract.LiabilityOrgAmt;
            objFilingTransactionsEntity.LiabilityOwedAmt = objFilingTransactionsContract.LiabilityOwedAmt;
            objFilingTransactionsEntity.LiabilityPartialAmt = objFilingTransactionsContract.LiabilityPartialAmt;
            objFilingTransactionsEntity.RLiability = objFilingTransactionsContract.RLiability;
            objFilingTransactionsEntity.RSubcontractor = objFilingTransactionsContract.RSubcontractor;
            objFilingTransactionsEntity.RItemized = objFilingTransactionsContract.RItemized;
            objFilingTransactionsEntity.RLiabilityExists = objFilingTransactionsContract.RLiabilityExists;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.LiabilityTransExplanation = objFilingTransactionsContract.LiabilityTransExplanation;
            objFilingTransactionsEntity.ElectionDate = objFilingTransactionsContract.ElectionDate;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.FilingTypeId = objFilingTransactionsContract.FilingTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.ElectionYear = objFilingTransactionsContract.ElectionYear;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;
            objFilingTransactionsEntity.ResigTermTypeId = objFilingTransactionsContract.ResigTermTypeId;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;
            objFilingTransactionsEntity.MunicipalityID = objFilingTransactionsContract.MunicipalityID;
            objFilingTransactionsEntity.SchedID = objFilingTransactionsContract.SchedID;
            objFilingTransactionsEntity.RIESupported = objFilingTransactionsContract.RIESupported;

            String result = objEFSRepository.AddFlngTransExpenditureData(objFilingTransactionsEntity);

            return result;
        }

        /// <summary>
        /// GetAutoCompleteCreditorNameLiab
        /// </summary>
        /// <param name="name"></param>
        /// <param name="strFilerId"></param>
        /// <returns></returns>
        public IList<OutstandingLiabilityContract> GetAutoCompleteCreditorNameLiab(String name, String strFilerId, String strNameFlag)
        {
            IList<OutstandingLiabilityContract> lstOutstandingLiabilityContract = new List<OutstandingLiabilityContract>();
            OutstandingLiabilityContract objOutstandingLiabilityContract;

            var results = objEFSRepository.GetAutoCompleteCreditorNameLiab(name, strFilerId, strNameFlag);

            foreach (var item in results)
            {
                objOutstandingLiabilityContract = new OutstandingLiabilityContract();
                objOutstandingLiabilityContract.FilingEntityId = item.FilingEntityId;
                objOutstandingLiabilityContract.PayeeName = item.PayeeName;
                objOutstandingLiabilityContract.FlngEntCountry = item.FlngEntCountry;
                objOutstandingLiabilityContract.LiabilityStreetName = item.LiabilityStreetName;
                objOutstandingLiabilityContract.LiabilityCity = item.LiabilityCity;
                objOutstandingLiabilityContract.LiabilityState = item.LiabilityState;
                objOutstandingLiabilityContract.LiabilityZipCode = item.LiabilityZipCode;
                objOutstandingLiabilityContract.FilingEntityNameAndAddress = item.FilingEntityNameAndAddress;
                lstOutstandingLiabilityContract.Add(objOutstandingLiabilityContract);
            }

            return lstOutstandingLiabilityContract;
        }

        /// <summary>
        /// GetDateIncurredLiabData
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        public IList<DateIncurredContract> GetDateIncurredLiabData(String strFilingEntityId, String strFilerId)
        {
            IList<DateIncurredContract> lstDateIncurredContract = new List<DateIncurredContract>();
            DateIncurredContract objDateIncurredContract;

            var results = objEFSRepository.GetDateIncurredLiabData(strFilingEntityId, strFilerId);

            foreach (var item in results)
            {
                objDateIncurredContract = new DateIncurredContract();
                objDateIncurredContract.DateIncurredId = item.DateIncurredId;
                objDateIncurredContract.DateIncurredValue = item.DateIncurredValue;
                objDateIncurredContract.AmountLiability = item.AmountLiability;
                lstDateIncurredContract.Add(objDateIncurredContract);
            }
            return lstDateIncurredContract;
        }

        /// <summary>
        /// GetDateIncurredLiabData
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        public IList<DateIncurredContract> GetDateIncurredLiabDataForForgiven(String strFilingEntityId, String strFilerId)
        {
            IList<DateIncurredContract> lstDateIncurredContract = new List<DateIncurredContract>();
            DateIncurredContract objDateIncurredContract;

            var results = objEFSRepository.GetDateIncurredLiabDataForForgiven(strFilingEntityId, strFilerId);

            foreach (var item in results)
            {
                objDateIncurredContract = new DateIncurredContract();
                objDateIncurredContract.DateIncurredId = item.DateIncurredId;
                objDateIncurredContract.DateIncurredValue = item.DateIncurredValue;
                objDateIncurredContract.AmountLiability = item.AmountLiability;
                objDateIncurredContract.OutstandingAmount = item.OutstandingAmount;
                lstDateIncurredContract.Add(objDateIncurredContract);
            }
            return lstDateIncurredContract;
        }

        /// <summary>
        /// GetOriginalAmountLiabData
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        public IList<OriginalAmountContract> GetOutstandingAmountLiabData(String strFilingEntityId, String strUpdateStatus, String strFilingTransId, String strFilingsId)
        {
            IList<OriginalAmountContract> lstOriginalAmountContract = new List<OriginalAmountContract>();
            OriginalAmountContract objOriginalAmountContract;

            var results = objEFSRepository.GetOutstandingAmountLiabData(strFilingEntityId, strUpdateStatus, strFilingTransId, strFilingsId);

            foreach (var item in results)
            {
                objOriginalAmountContract = new OriginalAmountContract();
                objOriginalAmountContract.OriginalAmountId = item.OriginalAmountId;
                objOriginalAmountContract.OutstandingAmount = item.OutstandingAmount;
                lstOriginalAmountContract.Add(objOriginalAmountContract);
            }
            return lstOriginalAmountContract;
        }

        /// <summary>
        /// GetExpenditureLiabilityExists
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        public String GetExpenditureLiabilityExists(String strFilingEntityId, String strFlngEntyName, String filerID)
        {
            String returnFlngEntityId = String.Empty;

            returnFlngEntityId = objEFSRepository.GetExpenditureLiabilityExists(strFilingEntityId, strFlngEntyName, filerID);

            return returnFlngEntityId;
        }

        /// <summary>
        /// GetExpPaymentsLiabilityData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<ExpPaymentLiabilityContract> GetExpPaymentsLiabilityData(String strTransNumber, String strFilerId)
        {
            IList<ExpPaymentLiabilityContract> lstExpPaymentLiabilityContract = new List<ExpPaymentLiabilityContract>();
            ExpPaymentLiabilityContract objExpPaymentLiabilityContract;

            var results = objEFSRepository.GetExpPaymentsLiabilityData(strTransNumber, strFilerId);

            foreach (var item in results)
            {
                objExpPaymentLiabilityContract = new ExpPaymentLiabilityContract();
                objExpPaymentLiabilityContract.TransNumber = item.TransNumber;
                objExpPaymentLiabilityContract.FilingEntityId = item.FilingEntityId;
                objExpPaymentLiabilityContract.PayeeName = item.PayeeName;
                objExpPaymentLiabilityContract.DateIncurred = item.DateIncurred;
                objExpPaymentLiabilityContract.OrignalAmount = item.OrignalAmount;
                objExpPaymentLiabilityContract.OutstandingAmount = item.OutstandingAmount;
                objExpPaymentLiabilityContract.CreditorName = item.CreditorName;
                objExpPaymentLiabilityContract.LiabilityStreetName = item.LiabilityStreetName;
                objExpPaymentLiabilityContract.LiabilityCity = item.LiabilityCity;
                objExpPaymentLiabilityContract.LiabilityState = item.LiabilityState;
                objExpPaymentLiabilityContract.LiabilityZipCode = item.LiabilityZipCode;
                objExpPaymentLiabilityContract.LiabilityExplanation = item.LiabilityExplanation;
                lstExpPaymentLiabilityContract.Add(objExpPaymentLiabilityContract);
            }

            return lstExpPaymentLiabilityContract;
        }

        /// <summary>
        /// UpdateFlngTransExpenditureData
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean UpdateFlngTransExpenditureData(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();            
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;            
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;            
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;                        
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;            
            objFilingTransactionsEntity.RLiability = objFilingTransactionsContract.RLiability;
            objFilingTransactionsEntity.RSubcontractor = objFilingTransactionsContract.RSubcontractor;
            objFilingTransactionsEntity.RItemized = objFilingTransactionsContract.RItemized;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.ModifiedBy = objFilingTransactionsContract.ModifiedBy;
            objFilingTransactionsEntity.LoanLiabNumberOrg = objFilingTransactionsContract.Loan_Lib_Number;
            objFilingTransactionsEntity.TransNumberOrg = objFilingTransactionsContract.TransNumberOrg;
            objFilingTransactionsEntity.IsAmtChanged = objFilingTransactionsContract.IsAmtChanged;
            objFilingTransactionsEntity.PurposeCodeId = objFilingTransactionsContract.PurposeCodeId;
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.SchedID = objFilingTransactionsContract.SchedID;
            objFilingTransactionsEntity.RIESupported = objFilingTransactionsContract.RIESupported;

            Boolean returnValue = objEFSRepository.UpdateFlngTransExpenditureData(objFilingTransactionsEntity);

            return returnValue;
        }

        /// <summary>
        /// GetSubcontracorsExists
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public Boolean GetSubcontracorsExists(String strFilingTransId)
        {
            Boolean results = objEFSRepository.GetSubcontracorsExists(strFilingTransId);

            return results;
        }

        /// <summary>
        /// Get Date
        /// </summary>
        /// <returns></returns>
        public IList<GetSearchForScheduledIContract> GetDate_SchedueledJ(string FILING_ENTITY_NAME, string ORG_AMT, string flng_Ent_FirstName,
                                                                 string flng_Ent_MiddleName, string flng_Ent_LastName, string filer_ID)
        {
            IList<GetSearchForScheduledIContract> lstGetSearchForScheduledI = new List<GetSearchForScheduledIContract>();
            GetSearchForScheduledIContract objGetSearchForScheduledI;

            var results = objEFSRepository.GetDate_SchedueledJ(FILING_ENTITY_NAME, ORG_AMT, flng_Ent_FirstName, flng_Ent_MiddleName, flng_Ent_LastName, filer_ID);

            foreach (var item in results)
            {
                objGetSearchForScheduledI = new GetSearchForScheduledIContract();
                objGetSearchForScheduledI.Trans_Number = item.Trans_Number.ToString();
                objGetSearchForScheduledI.Loan_Lib_Number = item.Loan_Lib_Number.ToString();
                objGetSearchForScheduledI.Date = item.Date.ToString();
                lstGetSearchForScheduledI.Add(objGetSearchForScheduledI);
            }
            return lstGetSearchForScheduledI;
        }

        /// <summary>
        /// Get Amount
        /// </summary>
        /// <param name="filing_date"></param>
        /// <returns></returns>
        public IList<GetSearchForScheduledIContract> GetAmount_SchedueledJ(string FILING_ENTITY_NAME, string flng_Ent_FirstName,
                                                                 string flng_Ent_MiddleName, string flng_Ent_LastName, string filer_ID)
        {
            IList<GetSearchForScheduledIContract> lstGetSearchForScheduledI = new List<GetSearchForScheduledIContract>();
            GetSearchForScheduledIContract objGetSearchForScheduledI;

            var results = objEFSRepository.GetAmount_SchedueledJ(FILING_ENTITY_NAME, flng_Ent_FirstName, flng_Ent_MiddleName, flng_Ent_LastName, filer_ID);

            foreach (var item in results)
            {
                objGetSearchForScheduledI = new GetSearchForScheduledIContract();
                objGetSearchForScheduledI.Amount = item.Amount.ToString();
                lstGetSearchForScheduledI.Add(objGetSearchForScheduledI);
            }
            return lstGetSearchForScheduledI;
        }

        /// <summary>
        /// Get Name
        /// </summary>
        /// <param name="filing_date"></param>
        /// <param name="org_amt"></param>
        /// <returns></returns>
        public IList<GetSearchForScheduledIContract> GetName_SchedueledJ(string filer_ID)
        {
            IList<GetSearchForScheduledIContract> lstGetSearchForScheduledI = new List<GetSearchForScheduledIContract>();
            GetSearchForScheduledIContract objGetSearchForScheduledI;

            var results = objEFSRepository.GetName_SchedueledJ(filer_ID);

            foreach (var item in results)
            {
                objGetSearchForScheduledI = new GetSearchForScheduledIContract();
                objGetSearchForScheduledI.Name = Convert.ToString(item.Name);
                objGetSearchForScheduledI.flng_Ent_FirstName = Convert.ToString(item.flng_Ent_FirstName);
                objGetSearchForScheduledI.flng_Ent_MiddleName = Convert.ToString(item.flng_Ent_MiddleName);
                objGetSearchForScheduledI.flng_Ent_LastName = Convert.ToString(item.flng_Ent_LastName);
                lstGetSearchForScheduledI.Add(objGetSearchForScheduledI);
            }
            return lstGetSearchForScheduledI;
        }


        public IList<FilingTransactionsContract> GetScheduleJ_EntityData(string trans_Number, String filerID)
        {
            IList<FilingTransactionsContract> lstFilingTransactionsContract = new List<FilingTransactionsContract>();
            FilingTransactionsContract objFilingTransactionsContract;

            var results = objEFSRepository.GetScheduleJ_EntityData(trans_Number, filerID);

            foreach (var item in results)
            {
                objFilingTransactionsContract = new FilingTransactionsContract();
                objFilingTransactionsContract.Loan_Lib_Number = item.Loan_Lib_Number.ToString();
                objFilingTransactionsContract.TransNumber = item.TransNumber.ToString();                
                objFilingTransactionsContract.FlngEntName = item.FlngEntName.ToString();
                objFilingTransactionsContract.FlngEntFirstName = item.FlngEntFirstName.ToString();
                objFilingTransactionsContract.FlngEntMiddleName = item.FlngEntMiddleName.ToString();
                objFilingTransactionsContract.FlngEntLastName = item.FlngEntLastName.ToString();
                objFilingTransactionsContract.FlngEntStrName = item.FlngEntStrName.ToString();
                objFilingTransactionsContract.FlngEntCity = item.FlngEntCity.ToString();
                objFilingTransactionsContract.FlngEntState = item.FlngEntState.ToString();
                objFilingTransactionsContract.FlngEntZip = item.FlngEntZip.ToString();
                objFilingTransactionsContract.FlngEntCountry = item.FlngEntCountry.ToString();
                objFilingTransactionsContract.OrgAmt = item.OrgAmt;
                objFilingTransactionsContract.LoanOtherId = item.LoanOtherId.ToString();
                objFilingTransactionsContract.FilingEntId = item.FilingEntId.ToString();
                objFilingTransactionsContract.SchedDate = item.SchedDate.ToString();
                objFilingTransactionsContract.PaymentTypeId = item.PaymentTypeId;
                objFilingTransactionsContract.PayNumber = item.PayNumber;
                lstFilingTransactionsContract.Add(objFilingTransactionsContract);
            }
            return lstFilingTransactionsContract;
        }

        /// <summary>
        /// Validate Scheduled J Amount
        /// </summary>
        /// <param name="filing_Trans_ID"></param>
        /// <returns></returns>
        public IList<GetSearchForScheduledIContract> ValidateSchedJ_Amount(string trans_Number, string status, string FilerID)
        {
            IList<GetSearchForScheduledIContract> lstGetSearchForScheduledI = new List<GetSearchForScheduledIContract>();
            GetSearchForScheduledIContract objGetSearchForScheduledI;

            var results = objEFSRepository.ValidateSchedJ_Amount(trans_Number, status, FilerID);

            foreach (var item in results)
            {
                objGetSearchForScheduledI = new GetSearchForScheduledIContract();
                objGetSearchForScheduledI.Amount = item.Amount.ToString();
                objGetSearchForScheduledI.Original_Amt = item.Original_Amt.ToString();
                objGetSearchForScheduledI.Date = item.Date.ToString();
                lstGetSearchForScheduledI.Add(objGetSearchForScheduledI);
            }
            return lstGetSearchForScheduledI;
        }

        /// <summary>
        /// AddFilingTransExpReimbursmentData
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean AddFilingTransExpReimbursmentData(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.TransNumber = objFilingTransactionsContract.TransNumber;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PurposeCodeId = objFilingTransactionsContract.PurposeCodeId;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.RItemized = objFilingTransactionsContract.RItemized;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.SchedID = objFilingTransactionsContract.SchedID;

            Boolean result = objEFSRepository.AddFilingTransExpReimbursmentData(objFilingTransactionsEntity);

            return result;
        }

        /// <summary>
        /// GetFlngTransExpReimbursementData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionsContract> GetFlngTransExpReimbursementData(String strTransNumber, String strFilerId, String strSchedID)
        {
            IList<FilingTransactionsContract> lstFilingTransactionsContract = new List<FilingTransactionsContract>();
            FilingTransactionsContract objFilingTransactionsContract;

            var results = objEFSRepository.GetFlngTransExpReimbursementData(strTransNumber, strFilerId, strSchedID);

            foreach (var item in results)
            {
                objFilingTransactionsContract = new FilingTransactionsContract();
                objFilingTransactionsContract.FilingTransId = item.FilingTransId;
                objFilingTransactionsContract.FilingEntId = item.FilingEntId;
                objFilingTransactionsContract.PurposeCodeId = item.PurposeCodeId;
                objFilingTransactionsContract.SchedDate = item.SchedDate;
                objFilingTransactionsContract.FlngEntName = item.FlngEntName;
                objFilingTransactionsContract.FlngEntCountry = item.FlngEntCountry;
                objFilingTransactionsContract.FlngEntStrName = item.FlngEntStrName;
                objFilingTransactionsContract.FlngEntCity = item.FlngEntCity;
                objFilingTransactionsContract.FlngEntState = item.FlngEntState;
                objFilingTransactionsContract.FlngEntZip = item.FlngEntZip;
                objFilingTransactionsContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objFilingTransactionsContract.OrgAmt = item.OrgAmt;
                objFilingTransactionsContract.TransExplanation = item.TransExplanation;
                objFilingTransactionsContract.RItemized = item.RItemized;
                objFilingTransactionsContract.TransNumber = item.TransNumber;
                lstFilingTransactionsContract.Add(objFilingTransactionsContract);
            }

            return lstFilingTransactionsContract;
        }

        /// <summary>
        /// GetReimbursementDetailsAmt
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public String GetReimbursementDetailsAmt(String strTransNumber, String strFilerId, String strSchedID)
        {
            String strReimbursementDetailsAmt = String.Empty;

            strReimbursementDetailsAmt = objEFSRepository.GetReimbursementDetailsAmt(strTransNumber, strFilerId, strSchedID);

            return strReimbursementDetailsAmt;
        }

        /// <summary>
        /// Validate Updated Amount
        /// </summary>
        /// <param name="filing_Trans_ID"></param>
        /// <returns></returns>
        public IList<GetSearchForScheduledIContract> ValidateForUpdateScheJ(string filing_Trans_ID)
        {
            IList<GetSearchForScheduledIContract> lstGetSearchForScheduledI = new List<GetSearchForScheduledIContract>();
            GetSearchForScheduledIContract objGetSearchForScheduledI;

            var results = objEFSRepository.ValidateForUpdateScheJ(filing_Trans_ID);

            foreach (var item in results)
            {
                objGetSearchForScheduledI = new GetSearchForScheduledIContract();
                objGetSearchForScheduledI.Amount = item.Amount.ToString();
                objGetSearchForScheduledI.Original_Amt = item.Original_Amt.ToString();
                lstGetSearchForScheduledI.Add(objGetSearchForScheduledI);
            }
            return lstGetSearchForScheduledI;
        }

        public Boolean UpdateLoanRepaymentData(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();            
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OtherAmount = objFilingTransactionsContract.OtherAmount;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;            
            objFilingTransactionsEntity.ModifiedBy = objFilingTransactionsContract.ModifiedBy;            
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntFirstName = objFilingTransactionsContract.FlngEntFirstName;
            objFilingTransactionsEntity.FlngEntMiddleName = objFilingTransactionsContract.FlngEntMiddleName;
            objFilingTransactionsEntity.FlngEntLastName = objFilingTransactionsContract.FlngEntLastName;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;            
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.LoanOtherId = objFilingTransactionsContract.LoanOtherId;
            objFilingTransactionsEntity.Loan_Lib_Number = objFilingTransactionsContract.Loan_Lib_Number;
            objFilingTransactionsEntity.TransNumber = objFilingTransactionsContract.TransNumber;
            objFilingTransactionsEntity.IsAmtChanged = objFilingTransactionsContract.IsAmtChanged;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            Boolean result = objEFSRepository.UpdateLoanRepaymentData(objFilingTransactionsEntity);

            return result;
        }

        /// <summary>
        /// Delete Loan Received Entry
        /// </summary>
        /// <param name="filing_Trans_ID"></param>
        /// <param name="modify_By"></param>
        /// <returns></returns>
        public Boolean DeleteLoanReceived(String transNumber, String strFilerID)
        {
            Boolean returnValue = objEFSRepository.DeleteLoanReceived(transNumber, strFilerID);
            return returnValue;
        }


        /// <summary>
        /// Delete Loan Repayment Entry
        /// </summary>
        /// <param name="filing_Trans_ID"></param>
        /// <param name="modify_By"></param>
        /// <returns></returns>
        public Boolean DeleteLoanRepayment(String loan_Lib_Number, String transNumber, String modify_By, String strFilerID)
        {
            Boolean returnValue = objEFSRepository.DeleteLoanRepayment(loan_Lib_Number, transNumber, modify_By, strFilerID);
            return returnValue;
        }

        /// <summary>
        /// Get Scheduled Data - Filing Transaction
        /// </summary>
        /// <param name="objFilingTransDataContract"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataContract> GetFilingTransactionsForScheduledIJN(FilingTransDataContract objFilingTransDataContract)
        {
            IList<FilingTransactionDataContract> lstFilingTransactionDataContract = new List<FilingTransactionDataContract>();
            FilingTransactionDataContract objFilingTransactionDataContract;

            FilingTransDataEntity objFilingTransDataEntity = new FilingTransDataEntity();
            objFilingTransDataEntity.Loan_Lib_Num = objFilingTransDataContract.Loan_Lib_Num;            
            objFilingTransDataEntity.SchedName = objFilingTransDataContract.SchedName;
            objFilingTransDataEntity.FilerId = objFilingTransDataContract.FilerId;

            var results = objEFSRepository.GetFilingTransactionsForScheduledIJN(objFilingTransDataEntity);

            foreach (var item in results)
            {
                objFilingTransactionDataContract = new FilingTransactionDataContract();
                objFilingTransactionDataContract.FilingTransId = item.FilingTransId;
                objFilingTransactionDataContract.FilingSchedId = item.FilingSchedId;
                objFilingTransactionDataContract.ContributorTypeId = item.ContributorTypeId;
                objFilingTransactionDataContract.ContributorTypeDesc = item.ContributorTypeDesc;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionDataContract.PaymentTypeId = item.PaymentTypeId;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.SchedDate = item.SchedDate;
                objFilingTransactionDataContract.FilingSchedDesc = item.FilingSchedDesc;
                objFilingTransactionDataContract.FilingEntityId = item.FilingEntityId;
                objFilingTransactionDataContract.FilingEntityName = item.FilingEntityName;
                objFilingTransactionDataContract.FilingFirstName = item.FilingFirstName;
                objFilingTransactionDataContract.FilingMiddleName = item.FilingMiddleName;
                objFilingTransactionDataContract.FilingLastName = item.FilingLastName;
                objFilingTransactionDataContract.FilingCountry = item.FilingCountry;
                objFilingTransactionDataContract.FilingStreetNumber = item.FilingStreetNumber;
                objFilingTransactionDataContract.FilingStreetName = item.FilingStreetName;
                objFilingTransactionDataContract.FilingCity = item.FilingCity;
                objFilingTransactionDataContract.FilingState = item.FilingState;
                objFilingTransactionDataContract.FilingZip = item.FilingZip;
                objFilingTransactionDataContract.PaymentTypeDesc = item.PaymentTypeDesc;
                objFilingTransactionDataContract.PayNumber = item.PayNumber;
                objFilingTransactionDataContract.OriginalAmount = item.OriginalAmount;
                objFilingTransactionDataContract.ReceiptTypeDesc = item.ReceiptTypeDesc;
                objFilingTransactionDataContract.TransferTypeDesc = item.TransferTypeDesc;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.OriginalDate = item.OriginalDate;
                objFilingTransactionDataContract.LoanerCode = item.LoanerCode;
                objFilingTransactionDataContract.ElectionYear = item.ElectionYear;
                objFilingTransactionDataContract.Office = item.Office;
                objFilingTransactionDataContract.District = item.District;
                objFilingTransactionDataContract.RLiability = item.RLiability;
                objFilingTransactionDataContract.RSubcontractor = item.RSubcontractor;
                objFilingTransactionDataContract.TransExplanation = item.TransExplanation;
                objFilingTransactionDataContract.OwedAmount = item.OwedAmount;
                objFilingTransactionDataContract.RItemized = item.RItemized;
                objFilingTransactionDataContract.CreatedDate = item.CreatedDate;
                lstFilingTransactionDataContract.Add(objFilingTransactionDataContract);
            }

            return lstFilingTransactionDataContract;
        }

        /// <summary>
        /// UpdateFilingTransExpReimbursmentData
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean UpdateFilingTransExpReimbursmentData(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.TransNumber = objFilingTransactionsContract.TransNumber;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PurposeCodeId = objFilingTransactionsContract.PurposeCodeId;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.SchedID = objFilingTransactionsContract.SchedID;

            Boolean result = objEFSRepository.UpdateFilingTransExpReimbursmentData(objFilingTransactionsEntity);

            return result;
        }

        /// <summary>
        /// DeleteFlngTransReimbursementDataSchedF
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strFilingTransMapping"></param>
        /// <param name="strModififedBy"></param>
        /// <returns></returns>
        public Boolean DeleteFlngTransReimbursementDataSchedF(String strTransNumber, String strModififedBy, String strFilerId)
        {
            Boolean results = objEFSRepository.DeleteFlngTransReimbursementDataSchedF(strTransNumber, strModififedBy, strFilerId);

            return results;
        }

        /// <summary>
        /// AddFilingTransNonCompaignHKExpensesData
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public String AddFilingTransNonCompaignHKExpensesData(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PurposeCodeId = objFilingTransactionsContract.PurposeCodeId;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.ElectionDate = objFilingTransactionsContract.ElectionDate;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.FilingTypeId = objFilingTransactionsContract.FilingTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.ElectionYear = objFilingTransactionsContract.ElectionYear;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.RItemized = objFilingTransactionsContract.RItemized;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;
            objFilingTransactionsEntity.ResigTermTypeId = objFilingTransactionsContract.ResigTermTypeId;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;
            objFilingTransactionsEntity.MunicipalityID = objFilingTransactionsContract.MunicipalityID;

            String results = objEFSRepository.AddFilingTransNonCompaignHKExpensesData(objFilingTransactionsEntity);

            return results;
        }

        /// <summary>
        /// GetNCHKExpensesReimbursementData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionsContract> GetNCHKExpensesReimbursementData(String strFilingTransId)
        {
            IList<FilingTransactionsContract> lstFilingTransactionsContract = new List<FilingTransactionsContract>();
            FilingTransactionsContract objFilingTransactionsContract;

            var results = objEFSRepository.GetNCHKExpensesReimbursementData(strFilingTransId);

            foreach (var item in results)
            {
                objFilingTransactionsContract = new FilingTransactionsContract();
                objFilingTransactionsContract.FilingTransId = item.FilingTransId;
                objFilingTransactionsContract.FilingEntId = item.FilingEntId;
                objFilingTransactionsContract.PurposeCodeId = item.PurposeCodeId;
                objFilingTransactionsContract.SchedDate = item.SchedDate;
                objFilingTransactionsContract.FlngEntName = item.FlngEntName;
                objFilingTransactionsContract.FlngEntCountry = item.FlngEntCountry;
                objFilingTransactionsContract.FlngEntStrName = item.FlngEntStrName;
                objFilingTransactionsContract.FlngEntCity = item.FlngEntCity;
                objFilingTransactionsContract.FlngEntState = item.FlngEntState;
                objFilingTransactionsContract.FlngEntZip = item.FlngEntZip;
                objFilingTransactionsContract.OrgAmt = item.OrgAmt;
                objFilingTransactionsContract.TransExplanation = item.TransExplanation;
                objFilingTransactionsContract.RItemized = item.RItemized;
                objFilingTransactionsContract.PurposeCodeDesc = item.PurposeCodeDesc;
                lstFilingTransactionsContract.Add(objFilingTransactionsContract);
            }

            return lstFilingTransactionsContract;
        }

        /// <summary>
        /// UpdateNonCompaignHKExpensesSchedQData
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean UpdateNonCompaignHKExpensesSchedQData(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.TransNumber = objFilingTransactionsContract.TransNumber;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.PurposeCodeId = objFilingTransactionsContract.PurposeCodeId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.ModifiedBy = objFilingTransactionsContract.ModifiedBy;
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;

            Boolean results = objEFSRepository.UpdateNonCompaignHKExpensesSchedQData(objFilingTransactionsEntity);

            return results;
        }

        /// <summary>
        /// Update Outstanding Loans
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean UpdateOutStandingLoansData(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilingTransId = objFilingTransactionsContract.FilingTransId;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.OtherTransExplanation = objFilingTransactionsContract.OtherTransExplanation;
            objFilingTransactionsEntity.ModifiedBy = objFilingTransactionsContract.ModifiedBy;

            Boolean returnValue = objEFSRepository.UpdateOutStandingLoansData(objFilingTransactionsEntity);
            return returnValue;
        }
        /// <summary>
        /// GetExpLiabilityOwedAmt
        /// </summary>
        /// <param name="strFlngEntityId"></param>
        /// <returns></returns>
        public String GetExpLiabilityOwedAmt(String strFlngEntityId, String filerID)
        {
            String strExpLiabilityOwedAmt = String.Empty;

            strExpLiabilityOwedAmt = objEFSRepository.GetExpLiabilityOwedAmt(strFlngEntityId, filerID);

            return strExpLiabilityOwedAmt;
        }

        /// <summary>
        /// GetExpSubContrTotAmt
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public String GetExpSubContrTotAmt(String strTransNumber, String strFilerId)
        {
            String strExpSubContrTotAmt = String.Empty;

            strExpSubContrTotAmt = objEFSRepository.GetExpSubContrTotAmt(strTransNumber, strFilerId);

            return strExpSubContrTotAmt;
        }


        /// <summary>
        /// Check Scheduled for Outstanding Loans
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionsContract> CheckOutstandingScheduled(String strFilingTransId)
        {
            IList<FilingTransactionsContract> lstFilingTransactionsContract = new List<FilingTransactionsContract>();
            FilingTransactionsContract objFilingTransactionsContract;

            var results = objEFSRepository.CheckOutstandingScheduled(strFilingTransId);

            foreach (var item in results)
            {
                objFilingTransactionsContract = new FilingTransactionsContract();
                objFilingTransactionsContract.FilingTransId = item.FilingTransId;
                lstFilingTransactionsContract.Add(objFilingTransactionsContract);
            }

            return lstFilingTransactionsContract;
        }

        /// <summary>
        /// Validate Loan Received Amount
        /// </summary>
        /// <param name="filing_Trans_ID"></param>
        /// <returns></returns>
        public IList<GetSearchForScheduledIContract> ValidateSchedI_UpdateAmount(string trans_Number, string FilerID)
        {
            IList<GetSearchForScheduledIContract> lstGetSearchForScheduledI = new List<GetSearchForScheduledIContract>();
            GetSearchForScheduledIContract objGetSearchForScheduledI;

            var results = objEFSRepository.ValidateSchedI_UpdateAmount(trans_Number, FilerID);

            foreach (var item in results)
            {
                objGetSearchForScheduledI = new GetSearchForScheduledIContract();
                objGetSearchForScheduledI.Amount = item.Amount.ToString();
                lstGetSearchForScheduledI.Add(objGetSearchForScheduledI);
            }
            return lstGetSearchForScheduledI;
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

            strOutstandingLiablityAmount = objEFSRepository.GetOutstandingLiabilityAmount(strFilingEntityId, strFlngTransId);

            return strOutstandingLiablityAmount;
        }

        /// <summary>
        /// GetExpPayTotalLiabAmount
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <param name="strFlngTransId"></param>
        /// <returns></returns>
        public String GetExpPayTotalLiabAmount(String strTransNumber, String filerID)
        {
            String strExpPayTotalLiabAmount = String.Empty;

            strExpPayTotalLiabAmount = objEFSRepository.GetExpPayTotalLiabAmount(strTransNumber, filerID);

            return strExpPayTotalLiabAmount;
        }

        /// <summary>
        /// GetContributorTypesSchedC
        /// </summary>
        /// <returns></returns>
        public IList<ContributorNameContract> GetContributorTypesSchedC()
        {
            IList<ContributorNameContract> lstContributorNameContract = new List<ContributorNameContract>();
            ContributorNameContract objContributorNameContract;

            var results = objEFSRepository.GetContributorTypesSchedC();

            foreach (var item in results)
            {
                objContributorNameContract = new ContributorNameContract();
                objContributorNameContract.ContributorTypeId = item.ContributorTypeId;
                objContributorNameContract.ContributorTypeDesc = item.ContributorTypeDesc;
                objContributorNameContract.ContributorTypeAbbrev = item.ContributorTypeAbbrev;
                lstContributorNameContract.Add(objContributorNameContract);
            }

            return lstContributorNameContract;
        }

        /// <summary>
        /// Add Loan Forgiven
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>        
        public string AddFilingTransaction_LoanForgiven(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;            
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.OtherFilingSchedId = objFilingTransactionsContract.OtherFilingSchedId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.OtherAmount = objFilingTransactionsContract.OtherAmount;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.FilingTypeId = objFilingTransactionsContract.FilingTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntFirstName = objFilingTransactionsContract.FlngEntFirstName;
            objFilingTransactionsEntity.FlngEntMiddleName = objFilingTransactionsContract.FlngEntMiddleName;
            objFilingTransactionsEntity.FlngEntLastName = objFilingTransactionsContract.FlngEntLastName;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.LoanOtherId = objFilingTransactionsContract.LoanOtherId;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;
            objFilingTransactionsEntity.ResigTermTypeId = objFilingTransactionsContract.ResigTermTypeId;
            objFilingTransactionsEntity.Loan_Lib_Number = objFilingTransactionsContract.Loan_Lib_Number;
            objFilingTransactionsEntity.TransNumber = objFilingTransactionsContract.TransNumber;
            objFilingTransactionsEntity.MunicipalityID = objFilingTransactionsContract.MunicipalityID;

            string results = objEFSRepository.AddFilingTransaction_LoanForgiven(objFilingTransactionsEntity);

            return results;
        }

        /// <summary>
        /// Delete Loan Forgiven
        /// </summary>
        /// <param name="filing_Trans_ID"></param>
        /// <param name="modify_By"></param>
        /// <returns></returns>
        public Boolean DeleteLoanForgiven(String loan_Lib_Number, String transNumber, String modify_By, String strLiability, String strFilerID)
        {
            Boolean returnValue = objEFSRepository.DeleteLoanForgiven(loan_Lib_Number, transNumber, modify_By, strLiability, strFilerID);
            return returnValue;
        }

        /// <summary>
        /// Add Authorized To Sign Check Entry
        /// </summary>
        /// <param name="objAuthorizedToSignCheckEntity"></param>
        /// <returns></returns>
        public Boolean AddAuthorizedToSignCheck(AuthorizedToSignCheckContract objAuthorizedToSignCheckContract)
        {
            AuthorizedToSignCheckEntity objAuthorizedToSignCheckEntity = new AuthorizedToSignCheckEntity();
            objAuthorizedToSignCheckEntity.CommID = objAuthorizedToSignCheckContract.CommID;
            objAuthorizedToSignCheckEntity.StartDate = objAuthorizedToSignCheckContract.StartDate;
            objAuthorizedToSignCheckEntity.Status = objAuthorizedToSignCheckContract.Status;
            objAuthorizedToSignCheckEntity.EndDate = objAuthorizedToSignCheckContract.EndDate;
            objAuthorizedToSignCheckEntity.Prefix = objAuthorizedToSignCheckContract.Prefix;
            objAuthorizedToSignCheckEntity.FirstName = objAuthorizedToSignCheckContract.FirstName;
            objAuthorizedToSignCheckEntity.MiddleName = objAuthorizedToSignCheckContract.MiddleName;
            objAuthorizedToSignCheckEntity.LastName = objAuthorizedToSignCheckContract.LastName;
            objAuthorizedToSignCheckEntity.Suffix = objAuthorizedToSignCheckContract.Suffix;
            objAuthorizedToSignCheckEntity.Signature = objAuthorizedToSignCheckContract.Signature;
            objAuthorizedToSignCheckEntity.CreatedBy = objAuthorizedToSignCheckContract.CreatedBy;

            Boolean results = objEFSRepository.AddAuthorizedToSignCheck(objAuthorizedToSignCheckEntity);

            return results;
        }

        /// <summary>
        /// GetPurposeCodeReimburDetailsData
        /// </summary>
        /// <returns></returns>
        public IList<PurposeCodeContract> GetPurposeCodeReimburDetailsData()
        {
            IList<PurposeCodeContract> lstPurposeCodeContract = new List<PurposeCodeContract>();
            PurposeCodeContract objPurposeCodeContract;

            var results = objEFSRepository.GetPurposeCodeReimburDetailsData();

            foreach (var item in results)
            {
                objPurposeCodeContract = new PurposeCodeContract();
                objPurposeCodeContract.PurposeCodeId = item.PurposeCodeId;
                objPurposeCodeContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objPurposeCodeContract.PurposeCodeAbbrev = item.PurposeCodeAbbrev;
                lstPurposeCodeContract.Add(objPurposeCodeContract);
            }

            return lstPurposeCodeContract;
        }

        /// <summary>
        /// GetPurposeCodeSubcontractorSchedF
        /// </summary>
        /// <returns></returns>
        public IList<PurposeCodeContract> GetPurposeCodeSubcontractorSchedF()
        {
            IList<PurposeCodeContract> lstPurposeCodeContract = new List<PurposeCodeContract>();
            PurposeCodeContract objPurposeCodeContract;

            var results = objEFSRepository.GetPurposeCodeSubcontractorSchedF();

            foreach (var item in results)
            {
                objPurposeCodeContract = new PurposeCodeContract();
                objPurposeCodeContract.PurposeCodeId = item.PurposeCodeId;
                objPurposeCodeContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objPurposeCodeContract.PurposeCodeAbbrev = item.PurposeCodeAbbrev;
                lstPurposeCodeContract.Add(objPurposeCodeContract);
            }

            return lstPurposeCodeContract;
        }

        /// <summary>
        /// GetPurposeCodeCreditCardItemSchedF
        /// </summary>
        /// <returns></returns>
        public IList<PurposeCodeContract> GetPurposeCodeCreditCardItemSchedF()
        {
            IList<PurposeCodeContract> lstPurposeCodeContract = new List<PurposeCodeContract>();
            PurposeCodeContract objPurposeCodeContract;

            var results = objEFSRepository.GetPurposeCodeCreditCardItemSchedF();

            foreach (var item in results)
            {
                objPurposeCodeContract = new PurposeCodeContract();
                objPurposeCodeContract.PurposeCodeId = item.PurposeCodeId;
                objPurposeCodeContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objPurposeCodeContract.PurposeCodeAbbrev = item.PurposeCodeAbbrev;
                lstPurposeCodeContract.Add(objPurposeCodeContract);
            }

            return lstPurposeCodeContract;
        }

        /// <summary>
        /// GetExpPayTransIdPopUpSchedF
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<ExpPaymentTransIdPopUpSchedFContract> GetExpPayTransIdPopUpSchedF(String strTransNumber, String filerID)
        {
            IList<ExpPaymentTransIdPopUpSchedFContract> lstExpPaymentTransIdPopUpSchedFContract = new List<ExpPaymentTransIdPopUpSchedFContract>();
            ExpPaymentTransIdPopUpSchedFContract objExpPaymentTransIdPopUpSchedFContract;

            var results = objEFSRepository.GetExpPayTransIdPopUpSchedF(strTransNumber, filerID);

            foreach (var item in results)
            {
                objExpPaymentTransIdPopUpSchedFContract = new ExpPaymentTransIdPopUpSchedFContract();
                objExpPaymentTransIdPopUpSchedFContract.TransNumber = item.TransNumber;
                objExpPaymentTransIdPopUpSchedFContract.FilingSchedId = item.FilingSchedId;
                objExpPaymentTransIdPopUpSchedFContract.ScheduleDate = item.ScheduleDate;
                objExpPaymentTransIdPopUpSchedFContract.OrgAmount = item.OrgAmount;
                lstExpPaymentTransIdPopUpSchedFContract.Add(objExpPaymentTransIdPopUpSchedFContract);
            }

            return lstExpPaymentTransIdPopUpSchedFContract;
        }

        /// <summary>
        /// Add Loan Forgiven Liabilities
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean AddFilingTransaction_LoanForgiven_Liabiliites(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.RLiabilityExists = objFilingTransactionsContract.RLiabilityExists;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.OtherAmount = objFilingTransactionsContract.OtherAmount;
            objFilingTransactionsEntity.OwedAmt = objFilingTransactionsContract.OwedAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.FilingTypeId = objFilingTransactionsContract.FilingTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;
            objFilingTransactionsEntity.ResigTermTypeId = objFilingTransactionsContract.ResigTermTypeId;
            objFilingTransactionsEntity.TransNumber = objFilingTransactionsContract.TransNumber;
            objFilingTransactionsEntity.MunicipalityID = objFilingTransactionsContract.MunicipalityID;

            Boolean result = objEFSRepository.AddFilingTransaction_LoanForgiven_Liabiliites(objFilingTransactionsEntity);

            return result;
        }

        /// <summary>
        /// GetDateIncurredLiabUpdateData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<DateIncurredContract> GetDateIncurredLiabUpdateData(String strTransNumber, String strFilerId)
        {
            IList<DateIncurredContract> lstDateIncurredContract = new List<DateIncurredContract>();
            DateIncurredContract objDateIncurredContract;

            var results = objEFSRepository.GetDateIncurredLiabUpdateData(strTransNumber, strFilerId);

            foreach (var item in results)
            {
                objDateIncurredContract = new DateIncurredContract();
                objDateIncurredContract.DateIncurredId = item.DateIncurredId;
                objDateIncurredContract.DateIncurredValue = item.DateIncurredValue;
                objDateIncurredContract.AmountLiability = item.AmountLiability;
                lstDateIncurredContract.Add(objDateIncurredContract);
            }
            return lstDateIncurredContract;
        }

        /// <summary>
        /// AddOtherReceivedReceiptsSchedE
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public string AddOtherReceivedReceiptsSchedE(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();

            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.ElectionDate = objFilingTransactionsContract.ElectionDate;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.FilingTypeId = objFilingTransactionsContract.FilingTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.ElectionYear = objFilingTransactionsContract.ElectionYear;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.ReceiptTypeId = objFilingTransactionsContract.ReceiptTypeId;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.RItemized = objFilingTransactionsContract.RItemized;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            objFilingTransactionsEntity.ResigTermTypeId = objFilingTransactionsContract.ResigTermTypeId;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;
            objFilingTransactionsEntity.MunicipalityID = objFilingTransactionsContract.MunicipalityID;

            string result = objEFSRepository.AddOtherReceivedReceiptsSchedE(objFilingTransactionsEntity);

            return result;
        }

        // Update Other Receipts Received Transactions.
        /// <summary>
        /// UpdateOtherReceiptsReceivedSchedE
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean UpdateOtherReceiptsReceivedSchedE(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();

            objFilingTransactionsEntity.TransNumber = objFilingTransactionsContract.TransNumber;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.ReceiptTypeId = objFilingTransactionsContract.ReceiptTypeId;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.RItemized = objFilingTransactionsContract.RItemized;
            objFilingTransactionsEntity.ModifiedBy = objFilingTransactionsContract.ModifiedBy;
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;

            Boolean returnValue = objEFSRepository.UpdateOtherReceiptsReceivedSchedE(objFilingTransactionsEntity);

            return returnValue;
        }

        /// <summary>
        /// GetOriginalName
        /// </summary>
        /// <returns></returns>
        public IList<ExpPaymentOriginalNameContract> GetOriginalName(String strFilerId)
        {
            IList<ExpPaymentOriginalNameContract> lstExpPaymentOriginalNameContract = new List<ExpPaymentOriginalNameContract>();
            ExpPaymentOriginalNameContract objExpPaymentOriginalNameContract;

            var results = objEFSRepository.GetOriginalName(strFilerId);

            foreach (var item in results)
            {
                objExpPaymentOriginalNameContract = new ExpPaymentOriginalNameContract();
                objExpPaymentOriginalNameContract.FilingEntityId = item.FilingEntityId;
                objExpPaymentOriginalNameContract.FilingEntityName = item.FilingEntityName;
                lstExpPaymentOriginalNameContract.Add(objExpPaymentOriginalNameContract);
            }

            return lstExpPaymentOriginalNameContract;
        }

        /// <summary>
        /// GetOriginalAmount
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        public IList<ExpPaymentOriginalAmountContract> GetOriginalAmount(String strFilingEntityId, String strFilerId)
        {
            IList<ExpPaymentOriginalAmountContract> lstExpPaymentOriginalAmountContract = new List<ExpPaymentOriginalAmountContract>();
            ExpPaymentOriginalAmountContract objExpPaymentOriginalAmountContract;

            var results = objEFSRepository.GetOriginalAmount(strFilingEntityId, strFilerId);

            foreach (var item in results)
            {
                objExpPaymentOriginalAmountContract = new ExpPaymentOriginalAmountContract();
                objExpPaymentOriginalAmountContract.TransNumber = item.TransNumber;
                objExpPaymentOriginalAmountContract.OriginalAmount = item.OriginalAmount;
                lstExpPaymentOriginalAmountContract.Add(objExpPaymentOriginalAmountContract);
            }

            return lstExpPaymentOriginalAmountContract;
        }

        /// <summary>
        /// GetOriginalExpeseDate
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<ExpPaymentOriginalExpenseDateContract> GetOriginalExpeseDate(String strTransNumber, String strFilerId)
        {
            IList<ExpPaymentOriginalExpenseDateContract> lstExpPaymentOriginalExpenseDateContract = new List<ExpPaymentOriginalExpenseDateContract>();
            ExpPaymentOriginalExpenseDateContract objExpPaymentOriginalExpenseDateContract;

            var results = objEFSRepository.GetOriginalExpeseDate(strTransNumber, strFilerId);

            foreach (var item in results)
            {
                objExpPaymentOriginalExpenseDateContract = new ExpPaymentOriginalExpenseDateContract();
                objExpPaymentOriginalExpenseDateContract.TransNumber = item.TransNumber;
                objExpPaymentOriginalExpenseDateContract.OriginalExpenseDate = item.OriginalExpenseDate;
                lstExpPaymentOriginalExpenseDateContract.Add(objExpPaymentOriginalExpenseDateContract);
            }

            return lstExpPaymentOriginalExpenseDateContract;
        }

        /// <summary>
        /// AddExpenditureRefundsSchedL
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public string AddExpenditureRefundsSchedL(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();

            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.ElectionDate = objFilingTransactionsContract.ElectionDate;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.FilingTypeId = objFilingTransactionsContract.FilingTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.ElectionYear = objFilingTransactionsContract.ElectionYear;
            objFilingTransactionsEntity.TransNumberOrg = objFilingTransactionsContract.TransNumberOrg;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;
            objFilingTransactionsEntity.ResigTermTypeId = objFilingTransactionsContract.ResigTermTypeId;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            objFilingTransactionsEntity.MunicipalityID = objFilingTransactionsContract.MunicipalityID;

            var result = objEFSRepository.AddExpenditureRefundsSchedL(objFilingTransactionsEntity);

            return result;
        }

        /// <summary>
        /// GetOutstaningAmtExpRefunded
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public String GetOutstaningAmtExpRefunded(String strTransNumber, String strFilerId)
        {
            var results = objEFSRepository.GetOutstaningAmtExpRefunded(strTransNumber, strFilerId);

            return results;
        }

        /// <summary>
        /// UpdateExpenditureRefundedSchedL
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean UpdateExpenditureRefundedSchedL(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();

            objFilingTransactionsEntity.TransNumber = objFilingTransactionsContract.TransNumber;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.ModifiedBy = objFilingTransactionsContract.ModifiedBy;
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;

            Boolean returnValue = objEFSRepository.UpdateExpenditureRefundedSchedL(objFilingTransactionsEntity);

            return returnValue;
        }

        /// <summary>
        /// GetOutstaningAmtExpRefundedUpdate
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<ExpPaymentOriginalAmountContract> GetOriginalAmtRefundedSchedL(String strTransNumber, String strFilerId)
        {
            IList<ExpPaymentOriginalAmountContract> lstExpPaymentOriginalAmountContract = new List<ExpPaymentOriginalAmountContract>();
            ExpPaymentOriginalAmountContract objExpPaymentOriginalAmountContract;

            var results = objEFSRepository.GetOriginalAmtRefundedSchedL(strTransNumber, strFilerId);

            foreach (var item in results)
            {
                objExpPaymentOriginalAmountContract = new ExpPaymentOriginalAmountContract();
                objExpPaymentOriginalAmountContract.TransNumber = item.TransNumber;
                objExpPaymentOriginalAmountContract.OriginalAmount = item.OriginalAmount;
                lstExpPaymentOriginalAmountContract.Add(objExpPaymentOriginalAmountContract);
            }

            return lstExpPaymentOriginalAmountContract;
        }

        /// <summary>
        /// GetContributorOriginalName
        /// </summary>
        /// <returns></returns>
        public IList<ExpPaymentOriginalNameContract> GetContributorOriginalName(String strFilerId)
        {
            IList<ExpPaymentOriginalNameContract> lstExpPaymentOriginalNameContract = new List<ExpPaymentOriginalNameContract>();
            ExpPaymentOriginalNameContract objExpPaymentOriginalNameContract;

            var results = objEFSRepository.GetContributorOriginalName(strFilerId);

            foreach (var item in results)
            {
                objExpPaymentOriginalNameContract = new ExpPaymentOriginalNameContract();
                objExpPaymentOriginalNameContract.FilingEntityId = item.FilingEntityId;
                objExpPaymentOriginalNameContract.FilingEntityName = item.FilingEntityName;
                lstExpPaymentOriginalNameContract.Add(objExpPaymentOriginalNameContract);
            }

            return lstExpPaymentOriginalNameContract;
        }

        /// <summary>
        /// GetContributorOriginalAmount
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        public IList<ExpPaymentOriginalAmountContract> GetContributorOriginalAmount(String strFilingEntityId, String strFilerId)
        {
            IList<ExpPaymentOriginalAmountContract> lstExpPaymentOriginalAmountContract = new List<ExpPaymentOriginalAmountContract>();
            ExpPaymentOriginalAmountContract objExpPaymentOriginalAmountContract;

            var results = objEFSRepository.GetContributorOriginalAmount(strFilingEntityId, strFilerId);

            foreach (var item in results)
            {
                objExpPaymentOriginalAmountContract = new ExpPaymentOriginalAmountContract();
                objExpPaymentOriginalAmountContract.TransNumber = item.TransNumber;
                objExpPaymentOriginalAmountContract.OriginalAmount = item.OriginalAmount;
                lstExpPaymentOriginalAmountContract.Add(objExpPaymentOriginalAmountContract);
            }

            return lstExpPaymentOriginalAmountContract;
        }

        /// <summary>
        /// GetContributorOriginalContributionDate
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<ExpPaymentOriginalExpenseDateContract> GetContributorOriginalContributionDate(String strFilingEntityId, String strOriginalAmt, String strFilerId)
        {
            IList<ExpPaymentOriginalExpenseDateContract> lstExpPaymentOriginalExpenseDateContract = new List<ExpPaymentOriginalExpenseDateContract>();
            ExpPaymentOriginalExpenseDateContract objExpPaymentOriginalExpenseDateContract;

            var results = objEFSRepository.GetContributorOriginalContributionDate(strFilingEntityId, strOriginalAmt, strFilerId);

            foreach (var item in results)
            {
                objExpPaymentOriginalExpenseDateContract = new ExpPaymentOriginalExpenseDateContract();
                objExpPaymentOriginalExpenseDateContract.TransNumber = item.TransNumber;
                objExpPaymentOriginalExpenseDateContract.OriginalExpenseDate = item.OriginalExpenseDate;
                lstExpPaymentOriginalExpenseDateContract.Add(objExpPaymentOriginalExpenseDateContract);
            }

            return lstExpPaymentOriginalExpenseDateContract;
        }

        /// <summary>
        /// GetOutstaningAmtContrRefunded
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public String GetOutstaningAmtContrRefunded(String strTransNumber, String strFilerId)
        {
            var results = objEFSRepository.GetOutstaningAmtContrRefunded(strTransNumber, strFilerId);

            return results;
        }

        /// <summary>
        /// GetOriginalAmtRefundedSchedM
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<ExpPaymentOriginalAmountContract> GetOriginalAmtRefundedSchedM(String strTransNumber, String filerID)
        {
            IList<ExpPaymentOriginalAmountContract> lstExpPaymentOriginalAmountContract = new List<ExpPaymentOriginalAmountContract>();
            ExpPaymentOriginalAmountContract objExpPaymentOriginalAmountContract;

            var results = objEFSRepository.GetOriginalAmtRefundedSchedM(strTransNumber, filerID);

            foreach (var item in results)
            {
                objExpPaymentOriginalAmountContract = new ExpPaymentOriginalAmountContract();
                objExpPaymentOriginalAmountContract.TransNumber = item.TransNumber;
                objExpPaymentOriginalAmountContract.OriginalAmount = item.OriginalAmount;
                lstExpPaymentOriginalAmountContract.Add(objExpPaymentOriginalAmountContract);
            }

            return lstExpPaymentOriginalAmountContract;
        }

        /// <summary>
        /// AddContributionsRefundedSchedM
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public string AddContributionsRefundedSchedM(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();

            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.ElectionDate = objFilingTransactionsContract.ElectionDate;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.FilingTypeId = objFilingTransactionsContract.FilingTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.ElectionYear = objFilingTransactionsContract.ElectionYear;
            objFilingTransactionsEntity.TransNumberOrg = objFilingTransactionsContract.TransNumberOrg;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;
            objFilingTransactionsEntity.ResigTermTypeId = objFilingTransactionsContract.ResigTermTypeId;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            objFilingTransactionsEntity.MunicipalityID = objFilingTransactionsContract.MunicipalityID;

            var result = objEFSRepository.AddContributionsRefundedSchedM(objFilingTransactionsEntity);

            return result;
        }

        /// <summary>
        /// UpdateContributionsRefundedSchedM
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean UpdateContributionsRefundedSchedM(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();

            objFilingTransactionsEntity.TransNumber = objFilingTransactionsContract.TransNumber;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.ModifiedBy = objFilingTransactionsContract.ModifiedBy;
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;

            Boolean returnValue = objEFSRepository.UpdateContributionsRefundedSchedM(objFilingTransactionsEntity);

            return returnValue;
        }

        /// <summary>
        /// AddOutstandingLiabilitySchedN
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public string AddOutstandingLiabilitySchedN(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();

            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.ElectionDate = objFilingTransactionsContract.ElectionDate;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.FilingTypeId = objFilingTransactionsContract.FilingTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.ElectionYear = objFilingTransactionsContract.ElectionYear;
            objFilingTransactionsEntity.FilingTransId = objFilingTransactionsContract.FilingTransId;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.PurposeCodeId = objFilingTransactionsContract.PurposeCodeId;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.OwedAmt = objFilingTransactionsContract.OwedAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;
            objFilingTransactionsEntity.ResigTermTypeId = objFilingTransactionsContract.ResigTermTypeId;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;
            objFilingTransactionsEntity.MunicipalityID = objFilingTransactionsContract.MunicipalityID;
            objFilingTransactionsEntity.RIESupported = objFilingTransactionsContract.RIESupported;

            var result = objEFSRepository.AddOutstandingLiabilitySchedN(objFilingTransactionsEntity);

            return result;
        }

        /// <summary>
        /// UpdateOutstandingLiabilitySchedN
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean UpdateOutstandingLiabilitySchedN(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();

            objFilingTransactionsEntity.TransNumber = objFilingTransactionsContract.TransNumber;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.PurposeCodeId = objFilingTransactionsContract.PurposeCodeId;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.OwedAmt = objFilingTransactionsContract.OwedAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.ModifiedBy = objFilingTransactionsContract.ModifiedBy;
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.RIESupported = objFilingTransactionsContract.RIESupported;

            Boolean returnValue = objEFSRepository.UpdateOutstandingLiabilitySchedN(objFilingTransactionsEntity);

            return returnValue;
        }

        /// <summary>
        /// OutstandingLiabilityChildExists
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public String OutstandingLiabilityChildExists(String strTransNumber, String filerID)
        {
            String strExists = String.Empty;

            strExists = objEFSRepository.OutstandingLiabilityChildExists(strTransNumber, filerID);

            return strExists;
        }

        /// <summary>
        /// DeleteOutstandingLiabilitySchedN
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        public Boolean DeleteOutstandingLiabilitySchedN(String strTransNumber, String strFilingsId, String strModifiedBy)
        {
            Boolean returnValue = objEFSRepository.DeleteOutstandingLiabilitySchedN(strTransNumber, strFilingsId, strModifiedBy);

            return returnValue;
        }

        /// <summary>
        /// GetOriginalAmountLiabData
        /// </summary> 
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        public IList<OriginalAmountContract> GetOutstandingAmountForForgiven(String strFilingTransId)
        {
            IList<OriginalAmountContract> lstOriginalAmountContract = new List<OriginalAmountContract>();
            OriginalAmountContract objOriginalAmountContract;

            var results = objEFSRepository.GetOutstandingAmountForForgiven(strFilingTransId);

            foreach (var item in results)
            {
                objOriginalAmountContract = new OriginalAmountContract();
                objOriginalAmountContract.OriginalAmountId = item.OriginalAmountId;
                objOriginalAmountContract.OutstandingAmount = item.OutstandingAmount;
                lstOriginalAmountContract.Add(objOriginalAmountContract);
            }
            return lstOriginalAmountContract;
        }

        /// <summary>
        /// GetEditTransactionData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataContract> GetEditTransactionData(String strTransNumber, String strFilerId)
        {
            IList<FilingTransactionDataContract> lstFilingTransactionDataContract = new List<FilingTransactionDataContract>();
            FilingTransactionDataContract objFilingTransactionDataContract;

            var results = objEFSRepository.GetEditTransactionData(strTransNumber, strFilerId);

            foreach (var item in results)
            {
                objFilingTransactionDataContract = new FilingTransactionDataContract();
                objFilingTransactionDataContract.TransNumber = item.TransNumber;
                objFilingTransactionDataContract.LoanLiablityNumber = item.LoanLiablityNumber;
                objFilingTransactionDataContract.FilingSchedId = item.FilingSchedId;
                objFilingTransactionDataContract.ContributorTypeId = item.ContributorTypeId;
                objFilingTransactionDataContract.ContributorTypeDesc = item.ContributorTypeDesc;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionDataContract.PaymentTypeId = item.PaymentTypeId;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.SchedDate = item.SchedDate;
                objFilingTransactionDataContract.FilingSchedDesc = item.FilingSchedDesc;
                objFilingTransactionDataContract.FilingEntityId = item.FilingEntityId;
                objFilingTransactionDataContract.FilingEntityName = item.FilingEntityName;
                objFilingTransactionDataContract.FilingFirstName = item.FilingFirstName;
                objFilingTransactionDataContract.FilingMiddleName = item.FilingMiddleName;
                objFilingTransactionDataContract.FilingLastName = item.FilingLastName;
                objFilingTransactionDataContract.FilingStreetNumber = item.FilingStreetNumber;
                objFilingTransactionDataContract.FilingStreetName = item.FilingStreetName;
                objFilingTransactionDataContract.FilingCity = item.FilingCity;
                objFilingTransactionDataContract.FilingState = item.FilingState;
                objFilingTransactionDataContract.FilingZip = item.FilingZip;
                objFilingTransactionDataContract.FilingCountry = item.FilingCountry;
                objFilingTransactionDataContract.PaymentTypeDesc = item.PaymentTypeDesc;
                objFilingTransactionDataContract.PayNumber = item.PayNumber;
                objFilingTransactionDataContract.OriginalAmount = item.OriginalAmount;
                objFilingTransactionDataContract.ReceiptTypeDesc = item.ReceiptTypeDesc;
                objFilingTransactionDataContract.TransferTypeDesc = item.TransferTypeDesc;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.OriginalDate = item.OriginalDate;
                objFilingTransactionDataContract.LoanerCode = item.LoanerCode;
                objFilingTransactionDataContract.ElectionYear = item.ElectionYear;
                objFilingTransactionDataContract.Office = item.Office;
                objFilingTransactionDataContract.District = item.District;
                objFilingTransactionDataContract.RLiability = item.RLiability;
                objFilingTransactionDataContract.RSubcontractor = item.RSubcontractor;
                objFilingTransactionDataContract.TransExplanation = item.TransExplanation;
                objFilingTransactionDataContract.OwedAmount = item.OwedAmount;
                objFilingTransactionDataContract.RItemized = item.RItemized;
                objFilingTransactionDataContract.LoanerCodeID = item.LoanerCodeId;
                objFilingTransactionDataContract.LoanerCode = item.LoanerCode;
                objFilingTransactionDataContract.Office = item.Office;
                objFilingTransactionDataContract.District = item.District;
                objFilingTransactionDataContract.CountyID = item.CountyID;
                objFilingTransactionDataContract.CountyDesc = item.CountyDesc;
                objFilingTransactionDataContract.MunicipalityID = item.MunicipalityID;
                objFilingTransactionDataContract.MunicipalityDesc = item.MunicipalityDesc;
                objFilingTransactionDataContract.Original_Sched_Date = item.Original_Sched_Date;
                objFilingTransactionDataContract.RClaim = item.RClaim;
                objFilingTransactionDataContract.InDistrict = item.InDistrict;
                objFilingTransactionDataContract.RMinor = item.RMinor;
                objFilingTransactionDataContract.RVendor = item.RVendor;
                objFilingTransactionDataContract.RLobbyist = item.RLobbyist;
                objFilingTransactionDataContract.TreasurerEmployer = item.TreasurerEmployer;
                objFilingTransactionDataContract.TreasurerOccuptaion = item.TreasurerOccuptaion;
                objFilingTransactionDataContract.TreaAddress = item.TreaAddress;
                objFilingTransactionDataContract.TreaAddr1 = item.TreaAddr1;
                objFilingTransactionDataContract.TreaCity = item.TreaCity;
                objFilingTransactionDataContract.TreaState = item.TreaState;
                objFilingTransactionDataContract.TreaZipCode = item.TreaZipCode;
                objFilingTransactionDataContract.RContributions = item.RContributions;
                objFilingTransactionDataContract.RIESupported = item.RIESupported;
                lstFilingTransactionDataContract.Add(objFilingTransactionDataContract);
            }

            return lstFilingTransactionDataContract;
        }

        /// <summary>
        /// Get and Authenticate value from Temp CAPASFIDAS Database
        /// </summary>
        /// <param name="filerID"></param>
        /// <param name="roleID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public IList<ValidateFilerInfoContract> GetAuthenticateFilerInfo(String userID)
        {
            IList<ValidateFilerInfoContract> lstValidateFilerInfo = new List<ValidateFilerInfoContract>();
            try
            {   
                ValidateFilerInfoContract objValidateFilerInfo;

                var results = objEFSRepository.GetAuthenticateFilerInfo(userID);

                foreach (var item in results)
                {
                    objValidateFilerInfo = new ValidateFilerInfoContract();
                    objValidateFilerInfo.FilerID = item.FilerID;
                    objValidateFilerInfo.RoleID = item.RoleID;
                    objValidateFilerInfo.Name = Convert.ToString(item.Name);
                    lstValidateFilerInfo.Add(objValidateFilerInfo);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return lstValidateFilerInfo;
        }

        /// <summary>
        /// Add Amount Allocation Scheduled R
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public string AddAmountAllocationSchedN(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();

            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.FlngEntFirstName = objFilingTransactionsContract.FlngEntFirstName;
            objFilingTransactionsEntity.FlngEntMiddleName = objFilingTransactionsContract.FlngEntMiddleName;
            objFilingTransactionsEntity.FlngEntLastName = objFilingTransactionsContract.FlngEntLastName;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.FilingTypeId = objFilingTransactionsContract.FilingTypeId;
            objFilingTransactionsEntity.ElectionDate = objFilingTransactionsContract.ElectionDate;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.ElectionYear = objFilingTransactionsContract.ElectionYear;
            objFilingTransactionsEntity.MunicipalityID = objFilingTransactionsContract.MunicipalityID;
            objFilingTransactionsEntity.OfficeID = objFilingTransactionsContract.OfficeID;
            objFilingTransactionsEntity.DistrictID = objFilingTransactionsContract.DistrictID;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;
            objFilingTransactionsEntity.ResigTermTypeId = objFilingTransactionsContract.ResigTermTypeId;
            objFilingTransactionsEntity.SupportOppose = objFilingTransactionsContract.SupportOppose;
            objFilingTransactionsEntity.TransNumber = objFilingTransactionsContract.TransNumber;
            var result = objEFSRepository.AddAmountAllocationSchedN(objFilingTransactionsEntity);
            return result;
        }

        /// <summary>
        /// Update Amount Allocation Sched R
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean UpdateAmountAllocationSchedN(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();

            objFilingTransactionsEntity.TransNumber = objFilingTransactionsContract.TransNumber;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.ModifiedBy = objFilingTransactionsContract.ModifiedBy;
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.SupportOppose = objFilingTransactionsContract.SupportOppose;
            var returnValue = objEFSRepository.UpdateAmountAllocationSchedN(objFilingTransactionsEntity);
            return returnValue;
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
        public String GetAllAmount(String filing_Ent_ID, String elect_Year, String municipalityID, String officeID, String distID, String filerID)
        {
            String results = objEFSRepository.GetAllAmount(filing_Ent_ID, elect_Year, municipalityID, officeID, distID, filerID);
            return results;
        }

        public IList<DistrictContract> GetDistrictsForOffice(String strOfficeID)
        {
            IList<DistrictContract> listGetDistrictsEntity = new List<DistrictContract>();
            DistrictContract objGetDistrictsEntity;
            //data from stored procedure
            var results = objEFSRepository.GetDistrictsForOffice(strOfficeID);

            foreach (var item in results)
            {
                //create GetDistrictsEntity object
                objGetDistrictsEntity = new DistrictContract();
                //modify object's attributes
                objGetDistrictsEntity.District_ID = item.District_ID;
                objGetDistrictsEntity.Parent_District_ID = item.Parent_District_ID;
                //add object to list
                listGetDistrictsEntity.Add(objGetDistrictsEntity);
            }
            return listGetDistrictsEntity;
        }

        public IList<OfficeContract> GetOffices(String strMunicipalityID)
        {
            IList<OfficeContract> listGetOfficeEntity = new List<OfficeContract>();
            OfficeContract objGetOfficeEntity;
            //data from stored procedure
            var results = objEFSRepository.GetOffices(strMunicipalityID);

            foreach (var item in results)
            {
                //create GetDistrictsEntity object
                objGetOfficeEntity = new OfficeContract();
                //modify object's attributes
                objGetOfficeEntity.OfficeId = item.OfficeId;
                objGetOfficeEntity.OfficeDesc = item.OfficeDesc;
                //add object to list
                listGetOfficeEntity.Add(objGetOfficeEntity);
            }
            return listGetOfficeEntity;
        }

        #region GetOriginalLiabilityData GET ORIGINAL SCHEDULE 'N' TRANSACTIONS.
        /// <summary>
        /// GetOriginalLiabilityData
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public IList<LiabilityDetailsContract> GetOriginalLiabilityData(String strTransNumber, String filerID)
        {
            IList<LiabilityDetailsContract> lstLiabilityDetailsContract = new List<LiabilityDetailsContract>();
            LiabilityDetailsContract objLiabilityDetailsContract;

            var results = objEFSRepository.GetOriginalLiabilityData(strTransNumber, filerID);

            foreach (var item in results)
            {
                objLiabilityDetailsContract = new LiabilityDetailsContract();
                objLiabilityDetailsContract.FilingTransId = item.FilingTransId;
                objLiabilityDetailsContract.TransNumber = item.TransNumber;
                objLiabilityDetailsContract.ContributionType = item.ContributionType;
                objLiabilityDetailsContract.TransactionDate = item.TransactionDate;
                objLiabilityDetailsContract.TransactionType = item.TransactionType;
                objLiabilityDetailsContract.FilingEntityName = item.FilingEntityName;
                objLiabilityDetailsContract.FilingFirstName = item.FilingFirstName;
                objLiabilityDetailsContract.FilingMiddleName = item.FilingMiddleName;
                objLiabilityDetailsContract.FilingLastName = item.FilingLastName;
                objLiabilityDetailsContract.FilingStreetName = item.FilingStreetName;
                objLiabilityDetailsContract.FilingCity = item.FilingCity;
                objLiabilityDetailsContract.FilingState = item.FilingState;
                objLiabilityDetailsContract.FilingZip = item.FilingZip;
                objLiabilityDetailsContract.FilingCountry = item.FilingCountry;
                objLiabilityDetailsContract.PaymentType = item.PaymentType;
                objLiabilityDetailsContract.PayNumber = item.PayNumber;
                objLiabilityDetailsContract.Amount = item.Amount;
                objLiabilityDetailsContract.OutstandingAmount = item.OutstandingAmount;
                objLiabilityDetailsContract.RecieptType = item.RecieptType;
                objLiabilityDetailsContract.TransferType = item.TransferType;
                objLiabilityDetailsContract.ContributionType = item.ContributionType;
                objLiabilityDetailsContract.PurposeCode = item.PurposeCode;
                objLiabilityDetailsContract.RecieptCdoe = item.RecieptCdoe;
                objLiabilityDetailsContract.OriginalDate = item.OriginalDate;
                objLiabilityDetailsContract.LoanerCode = item.LoanerCode;
                objLiabilityDetailsContract.ElectionYear = item.ElectionYear;
                objLiabilityDetailsContract.Office = item.Office;
                objLiabilityDetailsContract.District =item.District;
                objLiabilityDetailsContract.TransExplanation = item.TransExplanation;
                objLiabilityDetailsContract.RItemized = item.RItemized;
                objLiabilityDetailsContract.CountId = item.CountId;
                objLiabilityDetailsContract.MunicipalityId = item.MunicipalityId;
                objLiabilityDetailsContract.County = item.County;
                objLiabilityDetailsContract.Municipality = item.Municipality;
                objLiabilityDetailsContract.CreatedDate = item.CreatedDate;

                lstLiabilityDetailsContract.Add(objLiabilityDetailsContract);
            }

            return lstLiabilityDetailsContract;
        }
        #endregion GetOriginalLiabilityData GET ORIGINAL SCHEDULE 'N' TRANSACTIONS.

        #region GetExpenditurePaymentLiabilityData GET EXPENDITURE PAYMENT SCHEDULE 'F' TRANSACTIONS.
        /// <summary>
        /// GetExpenditurePaymentLiabilityData
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public IList<LiabilityDetailsContract> GetExpenditurePaymentLiabilityData(String strTransNumber, String filerID, String strSchedID)
        {
            IList<LiabilityDetailsContract> lstLiabilityDetailsContract = new List<LiabilityDetailsContract>();
            LiabilityDetailsContract objLiabilityDetailsContract;

            var results = objEFSRepository.GetExpenditurePaymentLiabilityData(strTransNumber, filerID, strSchedID);

            foreach (var item in results)
            {
                objLiabilityDetailsContract = new LiabilityDetailsContract();
                objLiabilityDetailsContract.FilingTransId = item.FilingTransId;
                objLiabilityDetailsContract.TransNumber = item.TransNumber;
                objLiabilityDetailsContract.ContributionType = item.ContributionType;
                objLiabilityDetailsContract.TransactionDate = item.TransactionDate;
                objLiabilityDetailsContract.TransactionType = item.TransactionType;
                objLiabilityDetailsContract.FilingEntityName = item.FilingEntityName;
                objLiabilityDetailsContract.FilingFirstName = item.FilingFirstName;
                objLiabilityDetailsContract.FilingMiddleName = item.FilingMiddleName;
                objLiabilityDetailsContract.FilingLastName = item.FilingLastName;
                objLiabilityDetailsContract.FilingStreetName = item.FilingStreetName;
                objLiabilityDetailsContract.FilingCity = item.FilingCity;
                objLiabilityDetailsContract.FilingState = item.FilingState;
                objLiabilityDetailsContract.FilingZip = item.FilingZip;
                objLiabilityDetailsContract.FilingCountry = item.FilingCountry;
                objLiabilityDetailsContract.PaymentType = item.PaymentType;
                objLiabilityDetailsContract.PayNumber = item.PayNumber;
                objLiabilityDetailsContract.Amount = item.Amount;
                objLiabilityDetailsContract.OutstandingAmount = item.OutstandingAmount;
                objLiabilityDetailsContract.RecieptType = item.RecieptType;
                objLiabilityDetailsContract.TransferType = item.TransferType;
                objLiabilityDetailsContract.ContributionType = item.ContributionType;
                objLiabilityDetailsContract.PurposeCode = item.PurposeCode;
                objLiabilityDetailsContract.RecieptCdoe = item.RecieptCdoe;
                objLiabilityDetailsContract.OriginalDate = item.OriginalDate;
                objLiabilityDetailsContract.LoanerCode = item.LoanerCode;
                objLiabilityDetailsContract.ElectionYear = item.ElectionYear;
                objLiabilityDetailsContract.Office = item.Office;
                objLiabilityDetailsContract.District = item.District;
                objLiabilityDetailsContract.TransExplanation = item.TransExplanation;
                objLiabilityDetailsContract.RItemized = item.RItemized;
                objLiabilityDetailsContract.CountId = item.CountId;
                objLiabilityDetailsContract.MunicipalityId = item.MunicipalityId;
                objLiabilityDetailsContract.County = item.County;
                objLiabilityDetailsContract.Municipality = item.Municipality;
                objLiabilityDetailsContract.CreatedDate = item.CreatedDate;

                lstLiabilityDetailsContract.Add(objLiabilityDetailsContract);
            }

            return lstLiabilityDetailsContract;
        }
        #endregion GetExpenditurePaymentLiabilityData GET EXPENDITURE PAYMENT SCHEDULE 'F' TRANSACTIONS.

        #region GetOutstandingLiabilityData GET OUTSTANDING LIABILITY SCHEDULE 'N' TRANSACTIONS.
        /// <summary>
        /// GetOutstandingLiabilityData
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public IList<LiabilityDetailsContract> GetOutstandingLiabilityData(String strTransNumber, String filerID)
        {
            IList<LiabilityDetailsContract> lstLiabilityDetailsContract = new List<LiabilityDetailsContract>();
            LiabilityDetailsContract objLiabilityDetailsContract;

            var results = objEFSRepository.GetOutstandingLiabilityData(strTransNumber, filerID);

            foreach (var item in results)
            {
                objLiabilityDetailsContract = new LiabilityDetailsContract();
                objLiabilityDetailsContract.FilingTransId = item.FilingTransId;
                objLiabilityDetailsContract.TransNumber = item.TransNumber;
                objLiabilityDetailsContract.ContributionType = item.ContributionType;
                objLiabilityDetailsContract.TransactionDate = item.TransactionDate;
                objLiabilityDetailsContract.TransactionType = item.TransactionType;
                objLiabilityDetailsContract.FilingEntityName = item.FilingEntityName;
                objLiabilityDetailsContract.FilingFirstName = item.FilingFirstName;
                objLiabilityDetailsContract.FilingMiddleName = item.FilingMiddleName;
                objLiabilityDetailsContract.FilingLastName = item.FilingLastName;
                objLiabilityDetailsContract.FilingStreetName = item.FilingStreetName;
                objLiabilityDetailsContract.FilingCity = item.FilingCity;
                objLiabilityDetailsContract.FilingState = item.FilingState;
                objLiabilityDetailsContract.FilingZip = item.FilingZip;
                objLiabilityDetailsContract.FilingCountry = item.FilingCountry;
                objLiabilityDetailsContract.PaymentType = item.PaymentType;
                objLiabilityDetailsContract.PayNumber = item.PayNumber;
                objLiabilityDetailsContract.Amount = item.Amount;
                objLiabilityDetailsContract.OutstandingAmount = item.OutstandingAmount;
                objLiabilityDetailsContract.RecieptType = item.RecieptType;
                objLiabilityDetailsContract.TransferType = item.TransferType;
                objLiabilityDetailsContract.ContributionType = item.ContributionType;
                objLiabilityDetailsContract.PurposeCode = item.PurposeCode;
                objLiabilityDetailsContract.RecieptCdoe = item.RecieptCdoe;
                objLiabilityDetailsContract.OriginalDate = item.OriginalDate;
                objLiabilityDetailsContract.LoanerCode = item.LoanerCode;
                objLiabilityDetailsContract.ElectionYear = item.ElectionYear;
                objLiabilityDetailsContract.Office = item.Office;
                objLiabilityDetailsContract.District = item.District;
                objLiabilityDetailsContract.TransExplanation = item.TransExplanation;
                objLiabilityDetailsContract.RItemized = item.RItemized;
                objLiabilityDetailsContract.CountId = item.CountId;
                objLiabilityDetailsContract.MunicipalityId = item.MunicipalityId;
                objLiabilityDetailsContract.County = item.County;
                objLiabilityDetailsContract.Municipality = item.Municipality;
                objLiabilityDetailsContract.CreatedDate = item.CreatedDate;

                lstLiabilityDetailsContract.Add(objLiabilityDetailsContract);
            }

            return lstLiabilityDetailsContract;
        }
        #endregion GetOutstandingLiabilityData GET OUTSTANDING LIABILITY SCHEDULE 'N' TRANSACTIONS.
        
        #region GetLiabilityForgivenData GET LIABILITY FORGIVEN SCHEDULE 'K' TRANSACTIONS.
        /// <summary>
        /// GetLiabilityForgivenData
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public IList<LiabilityDetailsContract> GetLiabilityForgivenData(String strTransNumber, String filerID)
        {
            IList<LiabilityDetailsContract> lstLiabilityDetailsContract = new List<LiabilityDetailsContract>();
            LiabilityDetailsContract objLiabilityDetailsContract;

            var results = objEFSRepository.GetLiabilityForgivenData(strTransNumber, filerID);

            foreach (var item in results)
            {
                objLiabilityDetailsContract = new LiabilityDetailsContract();
                objLiabilityDetailsContract.FilingTransId = item.FilingTransId;
                objLiabilityDetailsContract.TransNumber = item.TransNumber;
                objLiabilityDetailsContract.ContributionType = item.ContributionType;
                objLiabilityDetailsContract.TransactionDate = item.TransactionDate;
                objLiabilityDetailsContract.TransactionType = item.TransactionType;
                objLiabilityDetailsContract.FilingEntityName = item.FilingEntityName;
                objLiabilityDetailsContract.FilingFirstName = item.FilingFirstName;
                objLiabilityDetailsContract.FilingMiddleName = item.FilingMiddleName;
                objLiabilityDetailsContract.FilingLastName = item.FilingLastName;
                objLiabilityDetailsContract.FilingStreetName = item.FilingStreetName;
                objLiabilityDetailsContract.FilingCity = item.FilingCity;
                objLiabilityDetailsContract.FilingState = item.FilingState;
                objLiabilityDetailsContract.FilingZip = item.FilingZip;
                objLiabilityDetailsContract.FilingCountry = item.FilingCountry;
                objLiabilityDetailsContract.PaymentType = item.PaymentType;
                objLiabilityDetailsContract.PayNumber = item.PayNumber;
                objLiabilityDetailsContract.Amount = item.Amount;
                objLiabilityDetailsContract.OutstandingAmount = item.OutstandingAmount;
                objLiabilityDetailsContract.RecieptType = item.RecieptType;
                objLiabilityDetailsContract.TransferType = item.TransferType;
                objLiabilityDetailsContract.ContributionType = item.ContributionType;
                objLiabilityDetailsContract.PurposeCode = item.PurposeCode;
                objLiabilityDetailsContract.RecieptCdoe = item.RecieptCdoe;
                objLiabilityDetailsContract.OriginalDate = item.OriginalDate;
                objLiabilityDetailsContract.LoanerCode = item.LoanerCode;
                objLiabilityDetailsContract.ElectionYear = item.ElectionYear;
                objLiabilityDetailsContract.Office = item.Office;
                objLiabilityDetailsContract.District = item.District;
                objLiabilityDetailsContract.TransExplanation = item.TransExplanation;
                objLiabilityDetailsContract.RItemized = item.RItemized;
                objLiabilityDetailsContract.CountId = item.CountId;
                objLiabilityDetailsContract.MunicipalityId = item.MunicipalityId;
                objLiabilityDetailsContract.County = item.County;
                objLiabilityDetailsContract.Municipality = item.Municipality;
                objLiabilityDetailsContract.CreatedDate = item.CreatedDate;

                lstLiabilityDetailsContract.Add(objLiabilityDetailsContract);
            }

            return lstLiabilityDetailsContract;
        }
        #endregion GetLiabilityForgivenData GET LIABILITY FORGIVEN SCHEDULE 'K' TRANSACTIONS.

        //=========================================================================================================================================
        // NON-ITEMIZED TRANSACTIONS - >>>> START START START >>>>>>>>>>>>>>>>>>>>>>>>>>
        //=========================================================================================================================================

        #region GetInLieuOfStatementData
        /// <summary>
        /// GetInLieuOfStatementData
        /// </summary>
        /// <param name="strElectionYearId"></param>
        /// <param name="strElectTypeId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <returns></returns>
        public IList<InLieuOfStatementNonItemContract> GetInLieuOfStatementData(String strFilerid, String strElectionDate,
            String strElectionYearId, String strElectionYear, String strElectTypeId,
            String strOfficeTypeId, String strFilingTypeId, String strFilingDate)
        {
            IList<InLieuOfStatementNonItemContract> lstInLieuOfStatementNonItemContract = new List<InLieuOfStatementNonItemContract>();
            InLieuOfStatementNonItemContract objInLieuOfStatementNonItemContract;

            var results = objEFSRepository.GetInLieuOfStatementData(strFilerid, strElectionDate,
                strElectionYearId, strElectionYear, strElectTypeId, strOfficeTypeId, strFilingTypeId, strFilingDate);

            foreach (var item in results)
            {
                objInLieuOfStatementNonItemContract = new InLieuOfStatementNonItemContract();
                objInLieuOfStatementNonItemContract.FilingsId = item.FilingsId;
                objInLieuOfStatementNonItemContract.ElectionYear = item.ElectionYear;
                objInLieuOfStatementNonItemContract.OfficeType = item.OfficeType;
                objInLieuOfStatementNonItemContract.ElectionType = item.ElectionType;
                objInLieuOfStatementNonItemContract.ElectionDate = item.ElectionDate;
                objInLieuOfStatementNonItemContract.DisclosurePeriod = item.DisclosurePeriod;
                objInLieuOfStatementNonItemContract.DateSubmitted = item.DateSubmitted;
                lstInLieuOfStatementNonItemContract.Add(objInLieuOfStatementNonItemContract);
            }

            return lstInLieuOfStatementNonItemContract;

        }
        #endregion GetInLieuOfStatementData

        #region AddInLieuOfStatement
        /// <summary>
        /// AddInLieuOfStatement
        /// </summary>
        /// <param name="objAddInLieuOfStatementContract"></param>
        /// <returns></returns>
        public Boolean AddInLieuOfStatement(AddInLieuOfStatementContract objAddInLieuOfStatementContract)
        {
            AddInLieuOfStatementEntity objAddInLieuOfStatementEntity;
            objAddInLieuOfStatementEntity = new AddInLieuOfStatementEntity();
            objAddInLieuOfStatementEntity.FilerId = objAddInLieuOfStatementContract.FilerId;
            objAddInLieuOfStatementEntity.ElectionDate = objAddInLieuOfStatementContract.ElectionDate;
            objAddInLieuOfStatementEntity.ElectionTypeId = objAddInLieuOfStatementContract.ElectionTypeId;
            objAddInLieuOfStatementEntity.OfficeTypeId = objAddInLieuOfStatementContract.OfficeTypeId;
            objAddInLieuOfStatementEntity.FilingTypeId = objAddInLieuOfStatementContract.FilingTypeId;
            objAddInLieuOfStatementEntity.FilingCategoryId = objAddInLieuOfStatementContract.FilingCategoryId;
            objAddInLieuOfStatementEntity.ElectYearId = objAddInLieuOfStatementContract.ElectYearId;
            objAddInLieuOfStatementEntity.ElectionYear = objAddInLieuOfStatementContract.ElectionYear;
            objAddInLieuOfStatementEntity.CountyId = objAddInLieuOfStatementContract.CountyId;
            objAddInLieuOfStatementEntity.MunicipalityId = objAddInLieuOfStatementContract.MunicipalityId;
            objAddInLieuOfStatementEntity.CreatedBy = objAddInLieuOfStatementContract.CreatedBy;
            objAddInLieuOfStatementEntity.ElectionDateId = objAddInLieuOfStatementContract.ElectionDateId;
            objAddInLieuOfStatementEntity.FilingDate = objAddInLieuOfStatementContract.FilingDate;

            Boolean results = objEFSRepository.AddInLieuOfStatement(objAddInLieuOfStatementEntity);

            return results;
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
            Boolean results = objEFSRepository.DeleteInLieuOfStatement(strFilingsId, strModifiedBy);

            return results;
        }
        #endregion DeleteInLieuOfStatement

        #region GetPersonNameAndTreasurerData
        /// <summary>
        /// GetPersonNameAndTreasurerData
        /// </summary>
        /// <param name="strPersonId"></param>
        /// <returns></returns>
        public IList<PersonNameAndTreasurerDataContract> GetPersonNameAndTreasurerData(String strPersonId)
        {
            IList<PersonNameAndTreasurerDataContract> lstPersonNameAndTreasurerDataContract = new List<PersonNameAndTreasurerDataContract>();
            PersonNameAndTreasurerDataContract objPersonNameAndTreasurerDataContract;

            var results = objEFSRepository.GetPersonNameAndTreasurerData(strPersonId);

            foreach (var item in results)
            {
                objPersonNameAndTreasurerDataContract = new PersonNameAndTreasurerDataContract();
                objPersonNameAndTreasurerDataContract.PersonName = item.PersonName;
                objPersonNameAndTreasurerDataContract.TreasId = item.TreasId;
                lstPersonNameAndTreasurerDataContract.Add(objPersonNameAndTreasurerDataContract);
            }

            return lstPersonNameAndTreasurerDataContract;
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
        public IList<InLieuOfStatementNonItemContract> GetNoActivityReporttData(String strFilerid, String strElectionDate,
            String strElectionYearId, String strElectionYear, String strElectTypeId,
            String strOfficeTypeId, String strFilingTypeId, String strFilingDate)
        {
            IList<InLieuOfStatementNonItemContract> lstInLieuOfStatementNonItemContract = new List<InLieuOfStatementNonItemContract>();
            InLieuOfStatementNonItemContract objInLieuOfStatementNonItemContract;

            var results = objEFSRepository.GetNoActivityReporttData(strFilerid, strElectionDate,
                strElectionYearId, strElectionYear, strElectTypeId, strOfficeTypeId, strFilingTypeId, strFilingDate);

            foreach (var item in results)
            {
                objInLieuOfStatementNonItemContract = new InLieuOfStatementNonItemContract();
                objInLieuOfStatementNonItemContract.FilingsId = item.FilingsId;
                objInLieuOfStatementNonItemContract.ElectionYear = item.ElectionYear;
                objInLieuOfStatementNonItemContract.OfficeType = item.OfficeType;
                objInLieuOfStatementNonItemContract.ElectionType = item.ElectionType;
                objInLieuOfStatementNonItemContract.ElectionDate = item.ElectionDate;
                objInLieuOfStatementNonItemContract.DisclosurePeriod = item.DisclosurePeriod;
                objInLieuOfStatementNonItemContract.DateSubmitted = item.DateSubmitted;
                lstInLieuOfStatementNonItemContract.Add(objInLieuOfStatementNonItemContract);
            }

            return lstInLieuOfStatementNonItemContract;
        }
        #endregion GetNoActivityReporttData

        #region AddNoActivityReport
        /// <summary>
        /// AddNoActivityReport
        /// </summary>
        /// <param name="objAddInLieuOfStatementContract"></param>
        /// <returns></returns>
        public Boolean AddNoActivityReport(AddInLieuOfStatementContract objAddInLieuOfStatementContract)
        {
            AddInLieuOfStatementEntity objAddInLieuOfStatementEntity;
            objAddInLieuOfStatementEntity = new AddInLieuOfStatementEntity();
            objAddInLieuOfStatementEntity.FilerId = objAddInLieuOfStatementContract.FilerId;
            objAddInLieuOfStatementEntity.ElectionDate = objAddInLieuOfStatementContract.ElectionDate;
            objAddInLieuOfStatementEntity.ElectionTypeId = objAddInLieuOfStatementContract.ElectionTypeId;
            objAddInLieuOfStatementEntity.OfficeTypeId = objAddInLieuOfStatementContract.OfficeTypeId;
            objAddInLieuOfStatementEntity.FilingTypeId = objAddInLieuOfStatementContract.FilingTypeId;
            objAddInLieuOfStatementEntity.FilingCategoryId = objAddInLieuOfStatementContract.FilingCategoryId;
            objAddInLieuOfStatementEntity.ElectYearId = objAddInLieuOfStatementContract.ElectYearId;
            objAddInLieuOfStatementEntity.ElectionYear = objAddInLieuOfStatementContract.ElectionYear;
            objAddInLieuOfStatementEntity.CountyId = objAddInLieuOfStatementContract.CountyId;
            objAddInLieuOfStatementEntity.MunicipalityId = objAddInLieuOfStatementContract.MunicipalityId;
            objAddInLieuOfStatementEntity.ResigTermTypeId = objAddInLieuOfStatementContract.ResigTermTypeId;
            objAddInLieuOfStatementEntity.CreatedBy = objAddInLieuOfStatementContract.CreatedBy;
            objAddInLieuOfStatementEntity.ElectionDateId = objAddInLieuOfStatementContract.ElectionDateId;
            objAddInLieuOfStatementEntity.FilingDate = objAddInLieuOfStatementContract.FilingDate;

            Boolean results = objEFSRepository.AddNoActivityReport(objAddInLieuOfStatementEntity);

            return results;
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
            String strFilingTypeId, String strFilingCatId, String strElectTypeID)
        {
            Boolean strSubmitted;

            strSubmitted = objEFSRepository.GetItemizedTransSubmitted(strFilerId, strElectionYearId,
                strOfficeTypeId, strFilingTypeId, strFilingCatId, strElectTypeID);

            return strSubmitted;
        }
        #endregion GetItemizedTransSubmitted

        #region AddNoticeOfNonParticipation
        /// <summary>
        /// AddNoticeOfNonParticipation
        /// </summary>
        /// <param name="objAddInLieuOfStatementContract"></param>
        /// <returns></returns>
        public Boolean AddNoticeOfNonParticipation(AddInLieuOfStatementContract objAddInLieuOfStatementContract)
        {
            AddInLieuOfStatementEntity objAddInLieuOfStatementEntity;
            objAddInLieuOfStatementEntity = new AddInLieuOfStatementEntity();
            objAddInLieuOfStatementEntity.FilerId = objAddInLieuOfStatementContract.FilerId;
            objAddInLieuOfStatementEntity.ElectionDate = objAddInLieuOfStatementContract.ElectionDate;
            objAddInLieuOfStatementEntity.ElectionTypeId = objAddInLieuOfStatementContract.ElectionTypeId;
            objAddInLieuOfStatementEntity.OfficeTypeId = objAddInLieuOfStatementContract.OfficeTypeId;
            objAddInLieuOfStatementEntity.FilingTypeId = objAddInLieuOfStatementContract.FilingTypeId;
            objAddInLieuOfStatementEntity.FilingCategoryId = objAddInLieuOfStatementContract.FilingCategoryId;
            objAddInLieuOfStatementEntity.ElectYearId = objAddInLieuOfStatementContract.ElectYearId;
            objAddInLieuOfStatementEntity.ElectionYear = objAddInLieuOfStatementContract.ElectionYear;
            objAddInLieuOfStatementEntity.CountyId = objAddInLieuOfStatementContract.CountyId;
            objAddInLieuOfStatementEntity.MunicipalityId = objAddInLieuOfStatementContract.MunicipalityId;
            objAddInLieuOfStatementEntity.CreatedBy = objAddInLieuOfStatementContract.CreatedBy;
            objAddInLieuOfStatementEntity.ElectionDateId = objAddInLieuOfStatementContract.ElectionDateId;
            objAddInLieuOfStatementEntity.FilingDate = objAddInLieuOfStatementContract.FilingDate;

            Boolean results = objEFSRepository.AddNoticeOfNonParticipation(objAddInLieuOfStatementEntity);

            return results;
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
        public IList<InLieuOfStatementNonItemContract> GetNoticeOfNonParticipationtData(String strFilerid, String strElectionDate,
            String strElectionYearId, String strElectionYear, String strElectTypeId,
            String strOfficeTypeId, String strFilingTypeId, String strCountyId, String strMunicipalityId)
        {
            IList<InLieuOfStatementNonItemContract> lstInLieuOfStatementNonItemContract = new List<InLieuOfStatementNonItemContract>();
            InLieuOfStatementNonItemContract objInLieuOfStatementNonItemContract;

            var results = objEFSRepository.GetNoticeOfNonParticipationtData(strFilerid, strElectionDate,
                strElectionYearId, strElectionYear, strElectTypeId, strOfficeTypeId, strFilingTypeId, strCountyId, strMunicipalityId);

            foreach (var item in results)
            {
                objInLieuOfStatementNonItemContract = new InLieuOfStatementNonItemContract();
                objInLieuOfStatementNonItemContract.FilingsId = item.FilingsId;
                objInLieuOfStatementNonItemContract.ElectionYear = item.ElectionYear;
                objInLieuOfStatementNonItemContract.OfficeType = item.OfficeType;
                objInLieuOfStatementNonItemContract.ElectionType = item.ElectionType;
                objInLieuOfStatementNonItemContract.ElectionDate = item.ElectionDate;
                objInLieuOfStatementNonItemContract.DisclosurePeriod = item.DisclosurePeriod;
                objInLieuOfStatementNonItemContract.DateSubmitted = item.DateSubmitted;
                lstInLieuOfStatementNonItemContract.Add(objInLieuOfStatementNonItemContract);
            }

            return lstInLieuOfStatementNonItemContract;
        }
        #endregion GetNoticeOfNonParticipationtData

        #region GetTransactionTypes24HNoticeData
        /// <summary>
        /// GetTransactionTypes24HNoticeData
        /// </summary>
        /// <returns></returns>
        public IList<TransactionTypesContract> GetTransactionTypes24HNoticeData()
        {
            IList<TransactionTypesContract> lstTransactionTypesContract = new List<TransactionTypesContract>();
            TransactionTypesContract objTransactionTypesContract;

            var results = objEFSRepository.GetTransactionTypes24HNoticeData();

            foreach (var item in results)
            {
                objTransactionTypesContract = new TransactionTypesContract();
                objTransactionTypesContract.FilingSchedId = item.FilingSchedId;
                objTransactionTypesContract.FilingSchedDesc = item.FilingSchedDesc;
                objTransactionTypesContract.FilingSchedAbbrev = item.FilingSchedAbbrev;
                lstTransactionTypesContract.Add(objTransactionTypesContract);
            }

            return lstTransactionTypesContract;
        }
        #endregion GetTransactionTypes24HNoticeData

        #region GetFilingTrans24HourNoticeData
        /// <summary>
        /// GetFilingTrans24HourNoticeData
        /// </summary>
        /// <param name="objFilingTransDataContract"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataContract> GetFilingTrans24HourNoticeData(FilingTransDataContract objFilingTransDataContract)
        {
            IList<FilingTransactionDataContract> lstFilingTransactionDataContract = new List<FilingTransactionDataContract>();
            FilingTransactionDataContract objFilingTransactionDataContract;

            FilingTransDataEntity objFilingTransDataEntity = new FilingTransDataEntity();
            objFilingTransDataEntity.FilerId = objFilingTransDataContract.FilerId;
            objFilingTransDataEntity.ReportYearId = objFilingTransDataContract.ReportYearId;
            objFilingTransDataEntity.OfficeTypeId = objFilingTransDataContract.OfficeTypeId;
            objFilingTransDataEntity.ElectionType = objFilingTransDataContract.ElectionType;
            objFilingTransDataEntity.ElectionDateId = objFilingTransDataContract.ElectionDateId;
            objFilingTransDataEntity.FilingDate = objFilingTransDataContract.FilingDate;

            var results = objEFSRepository.GetFilingTrans24HourNoticeData(objFilingTransDataEntity);

            foreach (var item in results)
            {
                objFilingTransactionDataContract = new FilingTransactionDataContract();
                objFilingTransactionDataContract.FilingTransId = item.FilingTransId;
                objFilingTransactionDataContract.FilingSchedId = item.FilingSchedId;
                objFilingTransactionDataContract.ContributorTypeId = item.ContributorTypeId;
                objFilingTransactionDataContract.ContributorTypeDesc = item.ContributorTypeDesc;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionDataContract.PaymentTypeId = item.PaymentTypeId;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.SubmissionDate = item.SubmissionDate;
                objFilingTransactionDataContract.SchedDate = item.SchedDate;
                objFilingTransactionDataContract.FilingSchedDesc = item.FilingSchedDesc;
                objFilingTransactionDataContract.FilingEntityId = item.FilingEntityId;
                objFilingTransactionDataContract.FilingEntityName = item.FilingEntityName;
                objFilingTransactionDataContract.FilingFirstName = item.FilingFirstName;
                objFilingTransactionDataContract.FilingMiddleName = item.FilingMiddleName;
                objFilingTransactionDataContract.FilingLastName = item.FilingLastName;
                objFilingTransactionDataContract.FilingStreetNumber = item.FilingStreetNumber;
                objFilingTransactionDataContract.FilingStreetName = item.FilingStreetName;
                objFilingTransactionDataContract.FilingCity = item.FilingCity;
                objFilingTransactionDataContract.FilingState = item.FilingState;
                objFilingTransactionDataContract.FilingZip = item.FilingZip;
                objFilingTransactionDataContract.FilingCountry = item.FilingCountry;
                objFilingTransactionDataContract.PaymentTypeDesc = item.PaymentTypeDesc;
                objFilingTransactionDataContract.PayNumber = item.PayNumber;
                objFilingTransactionDataContract.OriginalAmount = item.OriginalAmount;
                objFilingTransactionDataContract.ReceiptTypeDesc = item.ReceiptTypeDesc;
                objFilingTransactionDataContract.TransferTypeDesc = item.TransferTypeDesc;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.OriginalDate = item.OriginalDate;
                objFilingTransactionDataContract.LoanerCode = item.LoanerCode;
                objFilingTransactionDataContract.ElectionYear = item.ElectionYear;
                objFilingTransactionDataContract.Office = item.Office;
                objFilingTransactionDataContract.District = item.District;
                objFilingTransactionDataContract.RLiability = item.RLiability;
                objFilingTransactionDataContract.RSubcontractor = item.RSubcontractor;
                objFilingTransactionDataContract.TransExplanation = item.TransExplanation;
                objFilingTransactionDataContract.OwedAmount = item.OwedAmount;
                objFilingTransactionDataContract.RItemized = item.RItemized;
                objFilingTransactionDataContract.RAmend = item.RAmend;
                objFilingTransactionDataContract.RStatus = item.RStatus;
                objFilingTransactionDataContract.CountyID = item.CountyID;
                objFilingTransactionDataContract.CountyDesc = item.CountyDesc;
                objFilingTransactionDataContract.MunicipalityID = item.MunicipalityID;
                objFilingTransactionDataContract.MunicipalityDesc = item.MunicipalityDesc;
                objFilingTransactionDataContract.LoanerCodeID = item.LoanerCodeId;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.CreatedDate = item.CreatedDate;
                objFilingTransactionDataContract.LoanLiablityNumber = item.LoanLiablityNumber;
                objFilingTransactionDataContract.TransNumber = item.TransNumber;
                objFilingTransactionDataContract.TransMapping = item.TransMapping;
                lstFilingTransactionDataContract.Add(objFilingTransactionDataContract);
            }

            return lstFilingTransactionDataContract;
        }
        #endregion GetFilingTrans24HourNoticeData

        #region GetFilingTrans24HourNoticeHistoryData
        /// <summary>
        /// GetFilingTrans24HourNoticeHistoryData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataContract> GetFilingTrans24HourNoticeHistoryData(String strTransNumber, String filerID)
        {
            IList<FilingTransactionDataContract> lstFilingTransactionDataContract = new List<FilingTransactionDataContract>();
            FilingTransactionDataContract objFilingTransactionDataContract;

            var results = objEFSRepository.GetFilingTrans24HourNoticeHistoryData(strTransNumber, filerID);

            foreach (var item in results)
            {
                objFilingTransactionDataContract = new FilingTransactionDataContract();
                objFilingTransactionDataContract.FilingTransId = item.FilingTransId;
                objFilingTransactionDataContract.FilingSchedId = item.FilingSchedId;
                objFilingTransactionDataContract.ContributorTypeId = item.ContributorTypeId;
                objFilingTransactionDataContract.ContributorTypeDesc = item.ContributorTypeDesc;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionDataContract.PaymentTypeId = item.PaymentTypeId;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.SubmissionDate = item.SubmissionDate;
                objFilingTransactionDataContract.SchedDate = item.SchedDate;
                objFilingTransactionDataContract.FilingSchedDesc = item.FilingSchedDesc;
                objFilingTransactionDataContract.FilingEntityId = item.FilingEntityId;
                objFilingTransactionDataContract.FilingEntityName = item.FilingEntityName;
                objFilingTransactionDataContract.FilingFirstName = item.FilingFirstName;
                objFilingTransactionDataContract.FilingMiddleName = item.FilingMiddleName;
                objFilingTransactionDataContract.FilingLastName = item.FilingLastName;
                objFilingTransactionDataContract.FilingStreetNumber = item.FilingStreetNumber;
                objFilingTransactionDataContract.FilingStreetName = item.FilingStreetName;
                objFilingTransactionDataContract.FilingCity = item.FilingCity;
                objFilingTransactionDataContract.FilingState = item.FilingState;
                objFilingTransactionDataContract.FilingZip = item.FilingZip;
                objFilingTransactionDataContract.FilingCountry = item.FilingCountry;
                objFilingTransactionDataContract.PaymentTypeDesc = item.PaymentTypeDesc;
                objFilingTransactionDataContract.PayNumber = item.PayNumber;
                objFilingTransactionDataContract.OriginalAmount = item.OriginalAmount;
                objFilingTransactionDataContract.ReceiptTypeDesc = item.ReceiptTypeDesc;
                objFilingTransactionDataContract.TransferTypeDesc = item.TransferTypeDesc;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.OriginalDate = item.OriginalDate;
                objFilingTransactionDataContract.LoanerCode = item.LoanerCode;
                objFilingTransactionDataContract.ElectionYear = item.ElectionYear;
                objFilingTransactionDataContract.Office = item.Office;
                objFilingTransactionDataContract.District = item.District;
                objFilingTransactionDataContract.RLiability = item.RLiability;
                objFilingTransactionDataContract.RSubcontractor = item.RSubcontractor;
                objFilingTransactionDataContract.TransExplanation = item.TransExplanation;
                objFilingTransactionDataContract.OwedAmount = item.OwedAmount;
                objFilingTransactionDataContract.RItemized = item.RItemized;
                objFilingTransactionDataContract.RAmend = item.RAmend;
                objFilingTransactionDataContract.RStatus = item.RStatus;
                objFilingTransactionDataContract.CountyID = item.CountyID;
                objFilingTransactionDataContract.CountyDesc = item.CountyDesc;
                objFilingTransactionDataContract.MunicipalityID = item.MunicipalityID;
                objFilingTransactionDataContract.MunicipalityDesc = item.MunicipalityDesc;
                objFilingTransactionDataContract.LoanerCodeID = item.LoanerCodeId;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeDesc;
                objFilingTransactionDataContract.CreatedDate = item.CreatedDate;
                objFilingTransactionDataContract.LoanLiablityNumber = item.LoanLiablityNumber;
                objFilingTransactionDataContract.TransNumber = item.TransNumber;
                objFilingTransactionDataContract.TransMapping = item.TransMapping;
                lstFilingTransactionDataContract.Add(objFilingTransactionDataContract);
            }

            return lstFilingTransactionDataContract;
        }
        #endregion GetFilingTrans24HourNoticeHistoryData

        #region AddNonItem24HourNoticeFlngTrans
        /// <summary>
        /// AddNonItem24HourNoticeFlngTrans
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean AddNonItem24HourNoticeFlngTrans(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.ContributorTypeId = objFilingTransactionsContract.ContributorTypeId;
            objFilingTransactionsEntity.ContributionTypeId = objFilingTransactionsContract.ContributionTypeId;
            objFilingTransactionsEntity.LoanOtherId = objFilingTransactionsContract.LoanOtherId;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.MunicipalityID = objFilingTransactionsContract.MunicipalityID;
            objFilingTransactionsEntity.RAmend = objFilingTransactionsContract.RAmend;
            objFilingTransactionsEntity.ElectionDate = objFilingTransactionsContract.ElectionDate;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.ElectionYear = objFilingTransactionsContract.ElectionYear;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntFirstName = objFilingTransactionsContract.FlngEntFirstName;
            objFilingTransactionsEntity.FlngEntLastName = objFilingTransactionsContract.FlngEntLastName;
            objFilingTransactionsEntity.FlngEntMiddleName = objFilingTransactionsContract.FlngEntMiddleName;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;

            Boolean returnValue = objEFSRepository.AddNonItem24HourNoticeFlngTrans(objFilingTransactionsEntity);

            return returnValue;
        }
        #endregion AddNonItem24HourNoticeFlngTrans

        #region Update24HNoticeFlngTrans
        /// <summary>
        /// Update24HNoticeFlngTrans
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean Update24HNoticeFlngTrans(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();

            objFilingTransactionsEntity.TransNumber = objFilingTransactionsContract.TransNumber;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.ContributorTypeId = objFilingTransactionsContract.ContributorTypeId;
            objFilingTransactionsEntity.ContributionTypeId = objFilingTransactionsContract.ContributionTypeId;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.SubmissionDate = objFilingTransactionsContract.SubmissionDate;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntFirstName = objFilingTransactionsContract.FlngEntFirstName;
            objFilingTransactionsEntity.FlngEntMiddleName = objFilingTransactionsContract.FlngEntMiddleName;
            objFilingTransactionsEntity.FlngEntLastName = objFilingTransactionsContract.FlngEntLastName;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.ModifiedBy = objFilingTransactionsContract.ModifiedBy;
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;

            Boolean returnValue = objEFSRepository.Update24HNoticeFlngTrans(objFilingTransactionsEntity);

            return returnValue;
        }
        #endregion Update24HNoticeFlngTrans

        #region Submit24HNoticeFlngTrans
        /// <summary>
        /// Submit24HNoticeFlngTrans
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean Submit24HNoticeFlngTrans(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.ContributorTypeId = objFilingTransactionsContract.ContributorTypeId;
            objFilingTransactionsEntity.ContributionTypeId = objFilingTransactionsContract.ContributionTypeId;
            objFilingTransactionsEntity.TransNumber = objFilingTransactionsContract.TransNumber;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.ElectionDate = objFilingTransactionsContract.ElectionDate;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.ElectionYear = objFilingTransactionsContract.ElectionYear;
            objFilingTransactionsEntity.MunicipalityID = objFilingTransactionsContract.MunicipalityID;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;
            objFilingTransactionsEntity.ModifiedBy = objFilingTransactionsContract.ModifiedBy;

            Boolean returnValue = objEFSRepository.Submit24HNoticeFlngTrans(objFilingTransactionsEntity);

            return returnValue;
        }
        #endregion Submit24HNoticeFlngTrans

        #region Delete24HNoticeFlngTrans
        /// <summary>
        /// Delete24HNoticeFlngTrans
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        public Boolean Delete24HNoticeFlngTrans(String strTransNumber, String strModifiedBy, String filerID)
        {
            Boolean returnValue = objEFSRepository.Delete24HNoticeFlngTrans(strTransNumber, strModifiedBy, filerID);

            return returnValue;
        }
        #endregion Delete24HNoticeFlngTrans

        #region GetNonItemChildTransExists
        /// <summary>
        /// GetNonItemChildTransExists
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public Boolean GetNonItemChildTransExists(String strTransNumber, String filerID)
        {
            Boolean strChildTransExists = objEFSRepository.GetNonItemChildTransExists(strTransNumber, filerID);

            return strChildTransExists;
        }
        #endregion GetNonItemChildTransExists

        #region GetNonItemParentTransExists
        /// <summary>
        /// GetNonItemParentTransExists
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public Boolean GetNonItemParentTransExists(String strTransNumber, String filerID)
        {
            Boolean strChildTransExists = objEFSRepository.GetNonItemParentTransExists(strTransNumber, filerID);

            return strChildTransExists;
        }
        #endregion GetNonItemParentTransExists

        #region GetCommEdit24HourNoticeTransData
        /// <summary>
        /// GetCommEdit24HourNoticeTransData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataContract> GetCommEdit24HourNoticeTransData(String strTransNumber, String filerID)
        {
            IList<FilingTransactionDataContract> lstFilingTransactionDataContract = new List<FilingTransactionDataContract>();
            FilingTransactionDataContract objFilingTransactionDataContract;

            var results = objEFSRepository.GetCommEdit24HourNoticeTransData(strTransNumber, filerID);

            foreach (var item in results)
            {
                objFilingTransactionDataContract = new FilingTransactionDataContract();
                objFilingTransactionDataContract.FilingTransId = item.FilingTransId;
                objFilingTransactionDataContract.FilingSchedId = item.FilingSchedId;
                objFilingTransactionDataContract.ContributorTypeId = item.ContributorTypeId;
                objFilingTransactionDataContract.ContributorTypeDesc = item.ContributorTypeDesc;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionDataContract.PaymentTypeId = item.PaymentTypeId;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.SubmissionDate = item.SubmissionDate;
                objFilingTransactionDataContract.SchedDate = item.SchedDate;
                objFilingTransactionDataContract.FilingSchedDesc = item.FilingSchedDesc;
                objFilingTransactionDataContract.FilingEntityId = item.FilingEntityId;
                objFilingTransactionDataContract.FilingEntityName = item.FilingEntityName;
                objFilingTransactionDataContract.FilingFirstName = item.FilingFirstName;
                objFilingTransactionDataContract.FilingMiddleName = item.FilingMiddleName;
                objFilingTransactionDataContract.FilingLastName = item.FilingLastName;
                objFilingTransactionDataContract.FilingStreetNumber = item.FilingStreetNumber;
                objFilingTransactionDataContract.FilingStreetName = item.FilingStreetName;
                objFilingTransactionDataContract.FilingCity = item.FilingCity;
                objFilingTransactionDataContract.FilingState = item.FilingState;
                objFilingTransactionDataContract.FilingZip = item.FilingZip;
                objFilingTransactionDataContract.FilingCountry = item.FilingCountry;
                objFilingTransactionDataContract.PaymentTypeDesc = item.PaymentTypeDesc;
                objFilingTransactionDataContract.PayNumber = item.PayNumber;
                objFilingTransactionDataContract.OriginalAmount = item.OriginalAmount;
                objFilingTransactionDataContract.ReceiptTypeDesc = item.ReceiptTypeDesc;
                objFilingTransactionDataContract.TransferTypeDesc = item.TransferTypeDesc;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.OriginalDate = item.OriginalDate;
                objFilingTransactionDataContract.LoanerCode = item.LoanerCode;
                objFilingTransactionDataContract.ElectionYear = item.ElectionYear;
                objFilingTransactionDataContract.Office = item.Office;
                objFilingTransactionDataContract.District = item.District;
                objFilingTransactionDataContract.RLiability = item.RLiability;
                objFilingTransactionDataContract.RSubcontractor = item.RSubcontractor;
                objFilingTransactionDataContract.TransExplanation = item.TransExplanation;
                objFilingTransactionDataContract.OwedAmount = item.OwedAmount;
                objFilingTransactionDataContract.RItemized = item.RItemized;
                objFilingTransactionDataContract.RAmend = item.RAmend;
                objFilingTransactionDataContract.RStatus = item.RStatus;
                objFilingTransactionDataContract.CountyID = item.CountyID;
                objFilingTransactionDataContract.CountyDesc = item.CountyDesc;
                objFilingTransactionDataContract.MunicipalityID = item.MunicipalityID;
                objFilingTransactionDataContract.MunicipalityDesc = item.MunicipalityDesc;
                objFilingTransactionDataContract.LoanerCodeID = item.LoanerCodeId;
                objFilingTransactionDataContract.LoanLiablityNumber = item.LoanLiablityNumber;
                objFilingTransactionDataContract.TransNumber = item.TransNumber;
                objFilingTransactionDataContract.TransMapping = item.TransMapping;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                lstFilingTransactionDataContract.Add(objFilingTransactionDataContract);
            }

            return lstFilingTransactionDataContract;
        }
        #endregion GetCommEdit24HourNoticeTransData

        #region GetFilingTransIEWeeklyContributioneData
        /// <summary>
        /// GetFilingTransIEWeeklyContributioneData
        /// </summary>    
        /// <param name="objFilingTransDataContract"></param>  
        /// <returns></returns>
        public IList<FilingTransactionDataContract> GetFilingTransIEWeeklyContributioneData(FilingTransDataContract objFilingTransDataContract)
        {
            IList<FilingTransactionDataContract> lstFilingTransactionDataContract = new List<FilingTransactionDataContract>();
            FilingTransactionDataContract objFilingTransactionDataContract;

            FilingTransDataEntity objFilingTransDataEntity = new FilingTransDataEntity();
            objFilingTransDataEntity.FilerId = objFilingTransDataContract.FilerId;
            objFilingTransDataEntity.ReportYearId = objFilingTransDataContract.ReportYearId;
            objFilingTransDataEntity.OfficeTypeId = objFilingTransDataContract.OfficeTypeId;
            objFilingTransDataEntity.ElectionType = objFilingTransDataContract.ElectionType;
            objFilingTransDataEntity.ElectionDateId = objFilingTransDataContract.ElectionDateId;
            objFilingTransDataEntity.FilingDate = objFilingTransDataContract.FilingDate;
            objFilingTransDataEntity.MunicipalityID = objFilingTransDataContract.MunicipalityID;

            var results = objEFSRepository.GetFilingTransIEWeeklyContributioneData(objFilingTransDataEntity);

            foreach (var item in results)
            {
                objFilingTransactionDataContract = new FilingTransactionDataContract();
                objFilingTransactionDataContract.FilingTransId = item.FilingTransId;
                objFilingTransactionDataContract.FilingSchedId = item.FilingSchedId;
                objFilingTransactionDataContract.ContributorTypeId = item.ContributorTypeId;
                objFilingTransactionDataContract.ContributorTypeDesc = item.ContributorTypeDesc;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionDataContract.PaymentTypeId = item.PaymentTypeId;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.SubmissionDate = item.SubmissionDate;
                objFilingTransactionDataContract.SchedDate = item.SchedDate;
                objFilingTransactionDataContract.FilingSchedDesc = item.FilingSchedDesc;
                objFilingTransactionDataContract.FilingEntityId = item.FilingEntityId;
                objFilingTransactionDataContract.FilingEntityName = item.FilingEntityName;
                objFilingTransactionDataContract.FilingFirstName = item.FilingFirstName;
                objFilingTransactionDataContract.FilingMiddleName = item.FilingMiddleName;
                objFilingTransactionDataContract.FilingLastName = item.FilingLastName;
                objFilingTransactionDataContract.FilingStreetNumber = item.FilingStreetNumber;
                objFilingTransactionDataContract.FilingStreetName = item.FilingStreetName;
                objFilingTransactionDataContract.FilingCity = item.FilingCity;
                objFilingTransactionDataContract.FilingState = item.FilingState;
                objFilingTransactionDataContract.FilingZip = item.FilingZip;
                objFilingTransactionDataContract.FilingCountry = item.FilingCountry;
                objFilingTransactionDataContract.PaymentTypeDesc = item.PaymentTypeDesc;
                objFilingTransactionDataContract.PayNumber = item.PayNumber;
                objFilingTransactionDataContract.OriginalAmount = item.OriginalAmount;
                objFilingTransactionDataContract.ReceiptTypeDesc = item.ReceiptTypeDesc;
                objFilingTransactionDataContract.TransferTypeDesc = item.TransferTypeDesc;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.OriginalDate = item.OriginalDate;
                objFilingTransactionDataContract.LoanerCode = item.LoanerCode;
                objFilingTransactionDataContract.ElectionYear = item.ElectionYear;
                objFilingTransactionDataContract.Office = item.Office;
                objFilingTransactionDataContract.District = item.District;
                objFilingTransactionDataContract.RLiability = item.RLiability;
                objFilingTransactionDataContract.RSubcontractor = item.RSubcontractor;
                objFilingTransactionDataContract.TransExplanation = item.TransExplanation;
                objFilingTransactionDataContract.OwedAmount = item.OwedAmount;
                objFilingTransactionDataContract.RItemized = item.RItemized;
                objFilingTransactionDataContract.RAmend = item.RAmend;
                objFilingTransactionDataContract.RStatus = item.RStatus;
                objFilingTransactionDataContract.CountyID = item.CountyID;
                objFilingTransactionDataContract.CountyDesc = item.CountyDesc;
                objFilingTransactionDataContract.MunicipalityID = item.MunicipalityID;
                objFilingTransactionDataContract.MunicipalityDesc = item.MunicipalityDesc;
                objFilingTransactionDataContract.LoanerCodeID = item.LoanerCodeId;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.CreatedDate = item.CreatedDate;
                objFilingTransactionDataContract.TreasurerFirstName = item.TreasurerFirstName;
                objFilingTransactionDataContract.TreasurerLastName = item.TreasurerLastName;
                objFilingTransactionDataContract.TreasurerMiddleName = item.TreasurerMiddleName;
                objFilingTransactionDataContract.TreasurerOccuptaion = item.TreasurerOccuptaion;
                objFilingTransactionDataContract.TreasurerEmployer = item.TreasurerEmployer;
                objFilingTransactionDataContract.TreasurerStreetAddress = item.TreasurerStreetAddress;
                objFilingTransactionDataContract.TreasurerCity = item.TreasurerCity;
                objFilingTransactionDataContract.TreasurerState = item.TreasurerState;
                objFilingTransactionDataContract.TreasurerZip = item.TreasurerZip;
                objFilingTransactionDataContract.ContributorOccupation = item.ContributorOccupation;
                objFilingTransactionDataContract.ContributorEmployer = item.ContributorEmployer;
                objFilingTransactionDataContract.IEDescription = item.IEDescription;
                objFilingTransactionDataContract.CandBallotPropReference = item.CandBallotPropReference;
                objFilingTransactionDataContract.IESupported = item.IESupported;
                objFilingTransactionDataContract.AddrId = item.AddrId;
                objFilingTransactionDataContract.TreasId = item.TreasId;
                objFilingTransactionDataContract.LoanLiablityNumber = item.LoanLiablityNumber;
                objFilingTransactionDataContract.TransNumber = item.TransNumber;
                objFilingTransactionDataContract.TransMapping = item.TransMapping;
                lstFilingTransactionDataContract.Add(objFilingTransactionDataContract);
            }

            return lstFilingTransactionDataContract;
        }
        #endregion GetFilingTransIEWeeklyContributioneData

        #region GetIEWeeklyContrbutionTreasurerData
        /// <summary>
        /// GetIEWeeklyContrbutionTreasurerData
        /// </summary>
        /// <param name="strTreasurerId"></param>
        /// <returns></returns>
        public IList<NonItemIETreasurerContract> GetIEWeeklyContrbutionTreasurerData(String strTreasurerId)
        {
            IList<NonItemIETreasurerContract> lstNonItemIETreasurerContract = new List<NonItemIETreasurerContract>();
            NonItemIETreasurerContract objNonItemIETreasurerContract;

            var results = objEFSRepository.GetIEWeeklyContrbutionTreasurerData(strTreasurerId);

            foreach (var item in results)
            {
                objNonItemIETreasurerContract = new NonItemIETreasurerContract();
                objNonItemIETreasurerContract.AddressId = item.AddressId;
                objNonItemIETreasurerContract.PersonId = item.PersonId;
                objNonItemIETreasurerContract.TreasurerName = item.TreasurerName;
                objNonItemIETreasurerContract.TreasurerOccupation = item.TreasurerOccupation;
                objNonItemIETreasurerContract.TreasurerEmployer = item.TreasurerEmployer;
                objNonItemIETreasurerContract.TreasurerStreetAddress = item.TreasurerStreetAddress;
                objNonItemIETreasurerContract.TreasurerCity = item.TreasurerCity;
                objNonItemIETreasurerContract.TreasurerState = item.TreasurerState;
                objNonItemIETreasurerContract.TreasurerZip = item.TreasurerZip;
                lstNonItemIETreasurerContract.Add(objNonItemIETreasurerContract);
            }

            return lstNonItemIETreasurerContract;
        }
        #endregion GetIEWeeklyContrbutionTreasurerData

        #region AddNonItemIEWeeklyContrFlngTrans
        /// <summary>
        /// AddNonItemIEWeeklyContrFlngTrans
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean AddNonItemIEWeeklyContrFlngTrans(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.PersonId = objFilingTransactionsContract.PersonId;
            objFilingTransactionsEntity.TreasId = objFilingTransactionsContract.TreasId;
            objFilingTransactionsEntity.AddrId = objFilingTransactionsContract.AddrId;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.ContributorTypeId = objFilingTransactionsContract.ContributorTypeId;
            objFilingTransactionsEntity.ContributionTypeId = objFilingTransactionsContract.ContributionTypeId;
            objFilingTransactionsEntity.LoanOtherId = objFilingTransactionsContract.LoanOtherId;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.MunicipalityID = objFilingTransactionsContract.MunicipalityID;
            objFilingTransactionsEntity.RAmend = objFilingTransactionsContract.RAmend;
            objFilingTransactionsEntity.ElectionDate = objFilingTransactionsContract.ElectionDate;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.ElectionYear = objFilingTransactionsContract.ElectionYear;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntFirstName = objFilingTransactionsContract.FlngEntFirstName;
            objFilingTransactionsEntity.FlngEntLastName = objFilingTransactionsContract.FlngEntLastName;
            objFilingTransactionsEntity.FlngEntMiddleName = objFilingTransactionsContract.FlngEntMiddleName;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.TreasurerOccupation = objFilingTransactionsContract.TreasurerOccupation;
            objFilingTransactionsEntity.TreasurerEmployer = objFilingTransactionsContract.TreasurerEmployer;
            objFilingTransactionsEntity.TreasurerStreetAddress = objFilingTransactionsContract.TreasurerStreetAddress;
            objFilingTransactionsEntity.TreasurerCity = objFilingTransactionsContract.TreasurerCity;
            objFilingTransactionsEntity.TreasurerState = objFilingTransactionsContract.TreasurerState;
            objFilingTransactionsEntity.TreasurerZip = objFilingTransactionsContract.TreasurerZip;
            objFilingTransactionsEntity.CandBallotPropReference = objFilingTransactionsContract.CandBallotPropReference;
            objFilingTransactionsEntity.ContributorOccupation = objFilingTransactionsContract.ContributorOccupation;
            objFilingTransactionsEntity.ContributorEmployer = objFilingTransactionsContract.ContributorEmployer;
            objFilingTransactionsEntity.IEDescription = objFilingTransactionsContract.IEDescription;
            objFilingTransactionsEntity.R_Supported = objFilingTransactionsContract.R_Supported;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;

            Boolean results = objEFSRepository.AddNonItemIEWeeklyContrFlngTrans(objFilingTransactionsEntity);

            return results;
        }
        #endregion AddNonItemIEWeeklyContrFlngTrans

        #region UpdateIEWeeklyContrFlngTrans
        /// <summary>
        /// UpdateIEWeeklyContrFlngTrans
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean UpdateIEWeeklyContrFlngTrans(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.TransNumber = objFilingTransactionsContract.TransNumber;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.ContributorTypeId = objFilingTransactionsContract.ContributorTypeId;
            objFilingTransactionsEntity.ContributionTypeId = objFilingTransactionsContract.ContributionTypeId;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.TreasId = objFilingTransactionsContract.TreasId;
            objFilingTransactionsEntity.AddrId = objFilingTransactionsContract.AddrId;
            objFilingTransactionsEntity.PersonId = objFilingTransactionsContract.PersonId;
            objFilingTransactionsEntity.SubmissionDate = objFilingTransactionsContract.SubmissionDate;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntFirstName = objFilingTransactionsContract.FlngEntFirstName;
            objFilingTransactionsEntity.FlngEntMiddleName = objFilingTransactionsContract.FlngEntMiddleName;
            objFilingTransactionsEntity.FlngEntLastName = objFilingTransactionsContract.FlngEntLastName;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.TreasurerStreetAddress = objFilingTransactionsContract.TreasurerStreetAddress;
            objFilingTransactionsEntity.TreasurerCity = objFilingTransactionsContract.TreasurerCity;
            objFilingTransactionsEntity.TreasurerState = objFilingTransactionsContract.TreasurerState;
            objFilingTransactionsEntity.TreasurerZip = objFilingTransactionsContract.TreasurerZip;
            objFilingTransactionsEntity.ContributorOccupation = objFilingTransactionsContract.ContributorOccupation;
            objFilingTransactionsEntity.ContributorEmployer = objFilingTransactionsContract.ContributorEmployer;
            objFilingTransactionsEntity.IEDescription = objFilingTransactionsContract.IEDescription;
            objFilingTransactionsEntity.TreasurerOccupation = objFilingTransactionsContract.TreasurerOccupation;
            objFilingTransactionsEntity.TreasurerEmployer = objFilingTransactionsContract.TreasurerEmployer;
            objFilingTransactionsEntity.R_Supported = objFilingTransactionsContract.R_Supported;
            objFilingTransactionsEntity.CandBallotPropReference = objFilingTransactionsContract.CandBallotPropReference;
            objFilingTransactionsEntity.ModifiedBy = objFilingTransactionsContract.ModifiedBy;

            Boolean results = objEFSRepository.UpdateIEWeeklyContrFlngTrans(objFilingTransactionsEntity);

            return results;
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
            Boolean results = objEFSRepository.SubmitIEWeeklyContrFlngTrans(strTransNumber, strModifiedBy);

            return results;
        }
        #endregion SubmitIEWeeklyContrFlngTrans

        #region GetFilingTransIETransHistoryData
        /// <summary>
        /// GetFilingTransIETransHistoryData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataContract> GetFilingTransIETransHistoryData(String strFilingTransId)
        {
            IList<FilingTransactionDataContract> lstFilingTransactionDataContract = new List<FilingTransactionDataContract>();
            FilingTransactionDataContract objFilingTransactionDataContract;

            var results = objEFSRepository.GetFilingTransIETransHistoryData(strFilingTransId);

            foreach (var item in results)
            {
                objFilingTransactionDataContract = new FilingTransactionDataContract();
                objFilingTransactionDataContract.FilingTransId = item.FilingTransId;
                objFilingTransactionDataContract.FilingSchedId = item.FilingSchedId;
                objFilingTransactionDataContract.ContributorTypeId = item.ContributorTypeId;
                objFilingTransactionDataContract.ContributorTypeDesc = item.ContributorTypeDesc;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionDataContract.PaymentTypeId = item.PaymentTypeId;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.SubmissionDate = item.SubmissionDate;
                objFilingTransactionDataContract.SchedDate = item.SchedDate;
                objFilingTransactionDataContract.FilingSchedDesc = item.FilingSchedDesc;
                objFilingTransactionDataContract.FilingEntityId = item.FilingEntityId;
                objFilingTransactionDataContract.FilingEntityName = item.FilingEntityName;
                objFilingTransactionDataContract.FilingFirstName = item.FilingFirstName;
                objFilingTransactionDataContract.FilingMiddleName = item.FilingMiddleName;
                objFilingTransactionDataContract.FilingLastName = item.FilingLastName;
                objFilingTransactionDataContract.FilingStreetNumber = item.FilingStreetNumber;
                objFilingTransactionDataContract.FilingStreetName = item.FilingStreetName;
                objFilingTransactionDataContract.FilingCity = item.FilingCity;
                objFilingTransactionDataContract.FilingState = item.FilingState;
                objFilingTransactionDataContract.FilingZip = item.FilingZip;
                objFilingTransactionDataContract.FilingCountry = item.FilingCountry;
                objFilingTransactionDataContract.PaymentTypeDesc = item.PaymentTypeDesc;
                objFilingTransactionDataContract.PayNumber = item.PayNumber;
                objFilingTransactionDataContract.OriginalAmount = item.OriginalAmount;
                objFilingTransactionDataContract.ReceiptTypeDesc = item.ReceiptTypeDesc;
                objFilingTransactionDataContract.TransferTypeDesc = item.TransferTypeDesc;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.OriginalDate = item.OriginalDate;
                objFilingTransactionDataContract.LoanerCode = item.LoanerCode;
                objFilingTransactionDataContract.ElectionYear = item.ElectionYear;
                objFilingTransactionDataContract.Office = item.Office;
                objFilingTransactionDataContract.District = item.District;
                objFilingTransactionDataContract.RLiability = item.RLiability;
                objFilingTransactionDataContract.RSubcontractor = item.RSubcontractor;
                objFilingTransactionDataContract.TransExplanation = item.TransExplanation;
                objFilingTransactionDataContract.OwedAmount = item.OwedAmount;
                objFilingTransactionDataContract.RItemized = item.RItemized;
                objFilingTransactionDataContract.RAmend = item.RAmend;
                objFilingTransactionDataContract.RStatus = item.RStatus;
                objFilingTransactionDataContract.CountyID = item.CountyID;
                objFilingTransactionDataContract.CountyDesc = item.CountyDesc;
                objFilingTransactionDataContract.MunicipalityID = item.MunicipalityID;
                objFilingTransactionDataContract.MunicipalityDesc = item.MunicipalityDesc;
                objFilingTransactionDataContract.LoanerCodeID = item.LoanerCodeId;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeDesc;
                objFilingTransactionDataContract.CreatedDate = item.CreatedDate;
                objFilingTransactionDataContract.TreasurerFirstName = item.TreasurerFirstName;
                objFilingTransactionDataContract.TreasurerLastName = item.TreasurerLastName;
                objFilingTransactionDataContract.TreasurerMiddleName = item.TreasurerMiddleName;
                objFilingTransactionDataContract.TreasurerOccuptaion = item.TreasurerOccuptaion;
                objFilingTransactionDataContract.TreasurerEmployer = item.TreasurerEmployer;
                objFilingTransactionDataContract.TreasurerStreetAddress = item.TreasurerStreetAddress;
                objFilingTransactionDataContract.TreasurerCity = item.TreasurerCity;
                objFilingTransactionDataContract.TreasurerState = item.TreasurerState;
                objFilingTransactionDataContract.TreasurerZip = item.TreasurerZip;
                objFilingTransactionDataContract.ContributorOccupation = item.ContributorOccupation;
                objFilingTransactionDataContract.ContributorEmployer = item.ContributorEmployer;
                objFilingTransactionDataContract.CandBallotPropReference = item.CandBallotPropReference;
                objFilingTransactionDataContract.IEDescription = item.IEDescription;
                objFilingTransactionDataContract.IESupported = item.IESupported;
                objFilingTransactionDataContract.LoanLiablityNumber = item.LoanLiablityNumber;
                objFilingTransactionDataContract.TransNumber = item.TransNumber;
                objFilingTransactionDataContract.TransMapping = item.TransMapping;
                lstFilingTransactionDataContract.Add(objFilingTransactionDataContract);
            }

            return lstFilingTransactionDataContract;
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
        public IList<FilingTransactionDataContract> GetItemizedNonItemIETransactions(String strFilerId, String strElectionYearId, String strOfficeTypeId, String strElectionTypeId, String strElectionDateId, String strMunicipalityId, String strFilingDate)
        {
            IList<FilingTransactionDataContract> lstFilingTransactionDataContract = new List<FilingTransactionDataContract>();
            FilingTransactionDataContract objFilingTransactionDataContract;

            var results = objEFSRepository.GetItemizedNonItemIETransactions(strFilerId, strElectionYearId, strOfficeTypeId, strElectionTypeId, strElectionDateId, strMunicipalityId, strFilingDate);

            foreach (var item in results)
            {
                objFilingTransactionDataContract = new FilingTransactionDataContract();
                objFilingTransactionDataContract.FilingTransId = item.FilingTransId;
                objFilingTransactionDataContract.SchedDate = item.SchedDate;
                objFilingTransactionDataContract.OriginalAmount = item.OriginalAmount;
                objFilingTransactionDataContract.IEDescription = item.IEDescription;
                objFilingTransactionDataContract.IEType = item.IEType;
                objFilingTransactionDataContract.TreasurerName = item.TreasurerName;
                objFilingTransactionDataContract.ContributorName = item.ContributorName;
                objFilingTransactionDataContract.TreasurerCity = item.TreasurerCity;
                objFilingTransactionDataContract.TreasurerState = item.TreasurerState;
                objFilingTransactionDataContract.CandBallotPropReference = item.CandBallotPropReference;
                objFilingTransactionDataContract.TransExplanation = item.TransExplanation;
                objFilingTransactionDataContract.CreatedDate = item.CreatedDate;
                objFilingTransactionDataContract.LoanLiablityNumber = item.LoanLiablityNumber;
                objFilingTransactionDataContract.TransNumber = item.TransNumber;
                objFilingTransactionDataContract.TransMapping = item.TransMapping;
                lstFilingTransactionDataContract.Add(objFilingTransactionDataContract);
            }

            return lstFilingTransactionDataContract;
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
            Boolean results = objEFSRepository.AddItemizedIETransactionsData(strTransNumber, strFilerId, strElectionYearId, strOfficeTypeId, strFilingTypeId, strElectionTypeId, strElectionDateId, strCreatedBy, strFilingDate);

            return results;
        }
        #endregion AddItemizedIETransactionsData

        #region GetContributorCodeIEWeeklyContrSchedC
        /// <summary>
        /// GetContributorCodeIEWeeklyContrSchedC
        /// </summary>
        /// <returns></returns>
        public IList<ContributorNameContract> GetContributorCodeIEWeeklyContrSchedC()
        {
            IList<ContributorNameContract> lstContributorNameContract = new List<ContributorNameContract>();
            ContributorNameContract objContributorNameContract;

            var results = objEFSRepository.GetContributorCodeIEWeeklyContrSchedC();

            foreach (var item in results)
            {
                objContributorNameContract = new ContributorNameContract();
                objContributorNameContract.ContributorTypeId = item.ContributorTypeId;
                objContributorNameContract.ContributorTypeDesc = item.ContributorTypeDesc;
                objContributorNameContract.ContributorTypeAbbrev = item.ContributorTypeAbbrev;
                lstContributorNameContract.Add(objContributorNameContract);
            }

            return lstContributorNameContract;
        }
        #endregion GetContributorCodeIEWeeklyContrSchedC

        #region GetContributorCodeIEWeeklyContrSchedD
        /// <summary>
        /// GetContributorCodeIEWeeklyContrSchedD
        /// </summary>
        /// <returns></returns>
        public IList<ContributorNameContract> GetContributorCodeIEWeeklyContrSchedD()
        {
            IList<ContributorNameContract> lstContributorNameContract = new List<ContributorNameContract>();
            ContributorNameContract objContributorNameContract;

            var results = objEFSRepository.GetContributorCodeIEWeeklyContrSchedD();

            foreach (var item in results)
            {
                objContributorNameContract = new ContributorNameContract();
                objContributorNameContract.ContributorTypeId = item.ContributorTypeId;
                objContributorNameContract.ContributorTypeDesc = item.ContributorTypeDesc;
                objContributorNameContract.ContributorTypeAbbrev = item.ContributorTypeAbbrev;
                lstContributorNameContract.Add(objContributorNameContract);
            }

            return lstContributorNameContract;
        }
        #endregion GetContributorCodeIEWeeklyContrSchedD

        #region GetFilingTransIE24HContributioneData
        /// <summary>
        /// GetFilingTransIE24HContributioneData
        /// </summary>
        /// <param name="objFilingTransDataContract"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataContract> GetFilingTransIE24HContributioneData(FilingTransDataContract objFilingTransDataContract)
        {
            IList<FilingTransactionDataContract> lstFilingTransactionDataContract = new List<FilingTransactionDataContract>();
            FilingTransactionDataContract objFilingTransactionDataContract;

            FilingTransDataEntity objFilingTransDataEntity = new FilingTransDataEntity();
            objFilingTransDataEntity.FilerId = objFilingTransDataContract.FilerId;
            objFilingTransDataEntity.ReportYearId = objFilingTransDataContract.ReportYearId;
            objFilingTransDataEntity.OfficeTypeId = objFilingTransDataContract.OfficeTypeId;
            objFilingTransDataEntity.ElectionType = objFilingTransDataContract.ElectionType;
            objFilingTransDataEntity.ElectionDateId = objFilingTransDataContract.ElectionDateId;
            objFilingTransDataEntity.FilingDate = objFilingTransDataContract.FilingDate;

            var results = objEFSRepository.GetFilingTransIE24HContributioneData(objFilingTransDataEntity);

            foreach (var item in results)
            {
                objFilingTransactionDataContract = new FilingTransactionDataContract();
                objFilingTransactionDataContract.FilingTransId = item.FilingTransId;
                objFilingTransactionDataContract.FilingSchedId = item.FilingSchedId;
                objFilingTransactionDataContract.ContributorTypeId = item.ContributorTypeId;
                objFilingTransactionDataContract.ContributorTypeDesc = item.ContributorTypeDesc;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionDataContract.PaymentTypeId = item.PaymentTypeId;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.PurposeCodeId = item.PurposeCodeId;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.SubmissionDate = item.SubmissionDate;
                objFilingTransactionDataContract.SchedDate = item.SchedDate;
                objFilingTransactionDataContract.FilingSchedDesc = item.FilingSchedDesc;
                objFilingTransactionDataContract.FilingEntityId = item.FilingEntityId;
                objFilingTransactionDataContract.FilingEntityName = item.FilingEntityName;
                objFilingTransactionDataContract.FilingFirstName = item.FilingFirstName;
                objFilingTransactionDataContract.FilingMiddleName = item.FilingMiddleName;
                objFilingTransactionDataContract.FilingLastName = item.FilingLastName;
                objFilingTransactionDataContract.FilingStreetNumber = item.FilingStreetNumber;
                objFilingTransactionDataContract.FilingStreetName = item.FilingStreetName;
                objFilingTransactionDataContract.FilingCity = item.FilingCity;
                objFilingTransactionDataContract.FilingState = item.FilingState;
                objFilingTransactionDataContract.FilingZip = item.FilingZip;
                objFilingTransactionDataContract.FilingCountry = item.FilingCountry;
                objFilingTransactionDataContract.PaymentTypeDesc = item.PaymentTypeDesc;
                objFilingTransactionDataContract.PayNumber = item.PayNumber;
                objFilingTransactionDataContract.OriginalAmount = item.OriginalAmount;
                objFilingTransactionDataContract.ReceiptTypeDesc = item.ReceiptTypeDesc;
                objFilingTransactionDataContract.TransferTypeDesc = item.TransferTypeDesc;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.OriginalDate = item.OriginalDate;
                objFilingTransactionDataContract.LoanerCode = item.LoanerCode;
                objFilingTransactionDataContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objFilingTransactionDataContract.ElectionYear = item.ElectionYear;
                objFilingTransactionDataContract.Office = item.Office;
                objFilingTransactionDataContract.District = item.District;
                objFilingTransactionDataContract.RLiability = item.RLiability;
                objFilingTransactionDataContract.RSubcontractor = item.RSubcontractor;
                objFilingTransactionDataContract.TransExplanation = item.TransExplanation;
                objFilingTransactionDataContract.OwedAmount = item.OwedAmount;
                objFilingTransactionDataContract.RItemized = item.RItemized;
                objFilingTransactionDataContract.RAmend = item.RAmend;
                objFilingTransactionDataContract.RStatus = item.RStatus;
                objFilingTransactionDataContract.CountyID = item.CountyID;
                objFilingTransactionDataContract.CountyDesc = item.CountyDesc;
                objFilingTransactionDataContract.MunicipalityID = item.MunicipalityID;
                objFilingTransactionDataContract.MunicipalityDesc = item.MunicipalityDesc;
                objFilingTransactionDataContract.LoanerCodeID = item.LoanerCodeId;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.CreatedDate = item.CreatedDate;
                objFilingTransactionDataContract.TreasurerFirstName = item.TreasurerFirstName;
                objFilingTransactionDataContract.TreasurerLastName = item.TreasurerLastName;
                objFilingTransactionDataContract.TreasurerMiddleName = item.TreasurerMiddleName;
                objFilingTransactionDataContract.TreasurerOccuptaion = item.TreasurerOccuptaion;
                objFilingTransactionDataContract.TreasurerEmployer = item.TreasurerEmployer;
                objFilingTransactionDataContract.TreasurerStreetAddress = item.TreasurerStreetAddress;
                objFilingTransactionDataContract.TreasurerCity = item.TreasurerCity;
                objFilingTransactionDataContract.TreasurerState = item.TreasurerState;
                objFilingTransactionDataContract.TreasurerZip = item.TreasurerZip;
                objFilingTransactionDataContract.ContributorOccupation = item.ContributorOccupation;
                objFilingTransactionDataContract.ContributorEmployer = item.ContributorEmployer;
                objFilingTransactionDataContract.IEDescription = item.IEDescription;
                objFilingTransactionDataContract.CandBallotPropReference = item.CandBallotPropReference;
                objFilingTransactionDataContract.IESupported = item.IESupported;
                objFilingTransactionDataContract.AddrId = item.AddrId;
                objFilingTransactionDataContract.TreasId = item.TreasId;
                objFilingTransactionDataContract.TransNumber = item.TransNumber;
                objFilingTransactionDataContract.LoanLiablityNumber = item.LoanLiablityNumber;
                objFilingTransactionDataContract.TransMapping = item.TransMapping;
                lstFilingTransactionDataContract.Add(objFilingTransactionDataContract);
            }

            return lstFilingTransactionDataContract;
        }
        #endregion GetFilingTransIE24HContributioneData

        #region GetFilingTransIE24HContributionHistoryData
        /// <summary>
        /// GetFilingTransIE24HContributionHistoryData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataContract> GetFilingTransIE24HContributionHistoryData(String strFilingTransId)
        {
            IList<FilingTransactionDataContract> lstFilingTransactionDataContract = new List<FilingTransactionDataContract>();
            FilingTransactionDataContract objFilingTransactionDataContract;

            var results = objEFSRepository.GetFilingTransIE24HContributionHistoryData(strFilingTransId);

            foreach (var item in results)
            {
                objFilingTransactionDataContract = new FilingTransactionDataContract();
                objFilingTransactionDataContract.FilingTransId = item.FilingTransId;
                objFilingTransactionDataContract.FilingSchedId = item.FilingSchedId;
                objFilingTransactionDataContract.ContributorTypeId = item.ContributorTypeId;
                objFilingTransactionDataContract.ContributorTypeDesc = item.ContributorTypeDesc;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionDataContract.PaymentTypeId = item.PaymentTypeId;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.SubmissionDate = item.SubmissionDate;
                objFilingTransactionDataContract.SchedDate = item.SchedDate;
                objFilingTransactionDataContract.FilingSchedDesc = item.FilingSchedDesc;
                objFilingTransactionDataContract.FilingEntityId = item.FilingEntityId;
                objFilingTransactionDataContract.FilingEntityName = item.FilingEntityName;
                objFilingTransactionDataContract.FilingFirstName = item.FilingFirstName;
                objFilingTransactionDataContract.FilingMiddleName = item.FilingMiddleName;
                objFilingTransactionDataContract.FilingLastName = item.FilingLastName;
                objFilingTransactionDataContract.FilingStreetNumber = item.FilingStreetNumber;
                objFilingTransactionDataContract.FilingStreetName = item.FilingStreetName;
                objFilingTransactionDataContract.FilingCity = item.FilingCity;
                objFilingTransactionDataContract.FilingState = item.FilingState;
                objFilingTransactionDataContract.FilingZip = item.FilingZip;
                objFilingTransactionDataContract.FilingCountry = item.FilingCountry;
                objFilingTransactionDataContract.PaymentTypeDesc = item.PaymentTypeDesc;
                objFilingTransactionDataContract.PayNumber = item.PayNumber;
                objFilingTransactionDataContract.OriginalAmount = item.OriginalAmount;
                objFilingTransactionDataContract.ReceiptTypeDesc = item.ReceiptTypeDesc;
                objFilingTransactionDataContract.TransferTypeDesc = item.TransferTypeDesc;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.OriginalDate = item.OriginalDate;
                objFilingTransactionDataContract.LoanerCode = item.LoanerCode;
                objFilingTransactionDataContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objFilingTransactionDataContract.ElectionYear = item.ElectionYear;
                objFilingTransactionDataContract.Office = item.Office;
                objFilingTransactionDataContract.District = item.District;
                objFilingTransactionDataContract.RLiability = item.RLiability;
                objFilingTransactionDataContract.RSubcontractor = item.RSubcontractor;
                objFilingTransactionDataContract.TransExplanation = item.TransExplanation;
                objFilingTransactionDataContract.OwedAmount = item.OwedAmount;
                objFilingTransactionDataContract.RItemized = item.RItemized;
                objFilingTransactionDataContract.RAmend = item.RAmend;
                objFilingTransactionDataContract.RStatus = item.RStatus;
                objFilingTransactionDataContract.CountyID = item.CountyID;
                objFilingTransactionDataContract.CountyDesc = item.CountyDesc;
                objFilingTransactionDataContract.MunicipalityID = item.MunicipalityID;
                objFilingTransactionDataContract.MunicipalityDesc = item.MunicipalityDesc;
                objFilingTransactionDataContract.LoanerCodeID = item.LoanerCodeId;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeDesc;
                objFilingTransactionDataContract.CreatedDate = item.CreatedDate;
                objFilingTransactionDataContract.TreasurerFirstName = item.TreasurerFirstName;
                objFilingTransactionDataContract.TreasurerLastName = item.TreasurerLastName;
                objFilingTransactionDataContract.TreasurerMiddleName = item.TreasurerMiddleName;
                objFilingTransactionDataContract.TreasurerOccuptaion = item.TreasurerOccuptaion;
                objFilingTransactionDataContract.TreasurerEmployer = item.TreasurerEmployer;
                objFilingTransactionDataContract.TreasurerStreetAddress = item.TreasurerStreetAddress;
                objFilingTransactionDataContract.TreasurerCity = item.TreasurerCity;
                objFilingTransactionDataContract.TreasurerState = item.TreasurerState;
                objFilingTransactionDataContract.TreasurerZip = item.TreasurerZip;
                objFilingTransactionDataContract.ContributorOccupation = item.ContributorOccupation;
                objFilingTransactionDataContract.ContributorEmployer = item.ContributorEmployer;
                objFilingTransactionDataContract.CandBallotPropReference = item.CandBallotPropReference;
                objFilingTransactionDataContract.IEDescription = item.IEDescription;
                objFilingTransactionDataContract.IESupported = item.IESupported;
                objFilingTransactionDataContract.TransNumber = item.TransNumber;
                objFilingTransactionDataContract.LoanLiablityNumber = item.LoanLiablityNumber;
                objFilingTransactionDataContract.TransMapping = item.TransMapping;
                lstFilingTransactionDataContract.Add(objFilingTransactionDataContract);
            }

            return lstFilingTransactionDataContract;
        }
        #endregion GetFilingTransIE24HContributionHistoryData

        #region GetIE24HContrTransactionTypes
        /// <summary>
        /// GetIE24HContrTransactionTypes
        /// </summary>
        /// <returns></returns>
        public IList<TransactionTypesContract> GetIE24HContrTransactionTypes()
        {
            IList<TransactionTypesContract> lstTransactionTypesContract = new List<TransactionTypesContract>();
            TransactionTypesContract objTransactionTypesContract;

            var results = objEFSRepository.GetIE24HContrTransactionTypes();

            foreach (var item in results)
            {
                objTransactionTypesContract = new TransactionTypesContract();
                objTransactionTypesContract.FilingSchedId = item.FilingSchedId;
                objTransactionTypesContract.FilingSchedDesc = item.FilingSchedDesc;
                objTransactionTypesContract.FilingSchedAbbrev = item.FilingSchedAbbrev;
                lstTransactionTypesContract.Add(objTransactionTypesContract);
            }

            return lstTransactionTypesContract;
        }
        #endregion GetIE24HContrTransactionTypes

        #region AddNonItemIE24HContrFlngTrans
        /// <summary>
        /// AddNonItemIE24HContrFlngTrans
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean AddNonItemIE24HContrFlngTrans(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.PersonId = objFilingTransactionsContract.PersonId;
            objFilingTransactionsEntity.TreasId = objFilingTransactionsContract.TreasId;
            objFilingTransactionsEntity.AddrId = objFilingTransactionsContract.AddrId;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.ContributorTypeId = objFilingTransactionsContract.ContributorTypeId;
            objFilingTransactionsEntity.ContributionTypeId = objFilingTransactionsContract.ContributionTypeId;
            objFilingTransactionsEntity.LoanOtherId = objFilingTransactionsContract.LoanOtherId;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.MunicipalityID = objFilingTransactionsContract.MunicipalityID;
            objFilingTransactionsEntity.RAmend = objFilingTransactionsContract.RAmend;
            objFilingTransactionsEntity.ElectionDate = objFilingTransactionsContract.ElectionDate;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.ElectionYear = objFilingTransactionsContract.ElectionYear;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntFirstName = objFilingTransactionsContract.FlngEntFirstName;
            objFilingTransactionsEntity.FlngEntLastName = objFilingTransactionsContract.FlngEntLastName;
            objFilingTransactionsEntity.FlngEntMiddleName = objFilingTransactionsContract.FlngEntMiddleName;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.TreasurerOccupation = objFilingTransactionsContract.TreasurerOccupation;
            objFilingTransactionsEntity.TreasurerEmployer = objFilingTransactionsContract.TreasurerEmployer;
            objFilingTransactionsEntity.TreasurerStreetAddress = objFilingTransactionsContract.TreasurerStreetAddress;
            objFilingTransactionsEntity.TreasurerCity = objFilingTransactionsContract.TreasurerCity;
            objFilingTransactionsEntity.TreasurerState = objFilingTransactionsContract.TreasurerState;
            objFilingTransactionsEntity.TreasurerZip = objFilingTransactionsContract.TreasurerZip;
            objFilingTransactionsEntity.CandBallotPropReference = objFilingTransactionsContract.CandBallotPropReference;
            objFilingTransactionsEntity.ContributorOccupation = objFilingTransactionsContract.ContributorOccupation;
            objFilingTransactionsEntity.ContributorEmployer = objFilingTransactionsContract.ContributorEmployer;
            objFilingTransactionsEntity.IEDescription = objFilingTransactionsContract.IEDescription;
            objFilingTransactionsEntity.R_Supported = objFilingTransactionsContract.R_Supported;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;

            Boolean results = objEFSRepository.AddNonItemIE24HContrFlngTrans(objFilingTransactionsEntity);

            return results;
        }
        #endregion AddNonItemIE24HContrFlngTrans

        #region UpdateIE24HContrFlngTrans
        /// <summary>
        /// UpdateIE24HContrFlngTrans
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean UpdateIE24HContrFlngTrans(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.TransNumber = objFilingTransactionsContract.TransNumber;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.ContributorTypeId = objFilingTransactionsContract.ContributorTypeId;
            objFilingTransactionsEntity.ContributionTypeId = objFilingTransactionsContract.ContributionTypeId;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.TreasId = objFilingTransactionsContract.TreasId;
            objFilingTransactionsEntity.AddrId = objFilingTransactionsContract.AddrId;
            objFilingTransactionsEntity.PersonId = objFilingTransactionsContract.PersonId;
            objFilingTransactionsEntity.SubmissionDate = objFilingTransactionsContract.SubmissionDate;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntFirstName = objFilingTransactionsContract.FlngEntFirstName;
            objFilingTransactionsEntity.FlngEntMiddleName = objFilingTransactionsContract.FlngEntMiddleName;
            objFilingTransactionsEntity.FlngEntLastName = objFilingTransactionsContract.FlngEntLastName;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.TreasurerStreetAddress = objFilingTransactionsContract.TreasurerStreetAddress;
            objFilingTransactionsEntity.TreasurerCity = objFilingTransactionsContract.TreasurerCity;
            objFilingTransactionsEntity.TreasurerState = objFilingTransactionsContract.TreasurerState;
            objFilingTransactionsEntity.TreasurerZip = objFilingTransactionsContract.TreasurerZip;
            objFilingTransactionsEntity.ContributorOccupation = objFilingTransactionsContract.ContributorOccupation;
            objFilingTransactionsEntity.ContributorEmployer = objFilingTransactionsContract.ContributorEmployer;
            objFilingTransactionsEntity.IEDescription = objFilingTransactionsContract.IEDescription;
            objFilingTransactionsEntity.TreasurerOccupation = objFilingTransactionsContract.TreasurerOccupation;
            objFilingTransactionsEntity.TreasurerEmployer = objFilingTransactionsContract.TreasurerEmployer;
            objFilingTransactionsEntity.R_Supported = objFilingTransactionsContract.R_Supported;
            objFilingTransactionsEntity.CandBallotPropReference = objFilingTransactionsContract.CandBallotPropReference;
            objFilingTransactionsEntity.ModifiedBy = objFilingTransactionsContract.ModifiedBy;

            Boolean results = objEFSRepository.UpdateIE24HContrFlngTrans(objFilingTransactionsEntity);

            return results;
        }
        #endregion UpdateIE24HContrFlngTrans

        #region SubmitIE24HContrFlngTrans
        /// <summary>
        /// SubmitIE24HContrFlngTrans
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        public Boolean SubmitIE24HContrFlngTrans(String strTransNumber, String strModifiedBy)
        {
            Boolean results = objEFSRepository.SubmitIE24HContrFlngTrans(strTransNumber, strModifiedBy);

            return results;
        }
        #endregion SubmitIE24HContrFlngTrans

        #region GetIEWeeklyExpTransactionTypes
        /// <summary>
        /// GetIEWeeklyExpTransactionTypes
        /// </summary>
        /// <returns></returns>
        public IList<TransactionTypesContract> GetIEWeeklyExpTransactionTypes()
        {
            IList<TransactionTypesContract> lstTransactionTypesContract = new List<TransactionTypesContract>();
            TransactionTypesContract objTransactionTypesContract;

            var results = objEFSRepository.GetIEWeeklyExpTransactionTypes();

            foreach (var item in results)
            {
                objTransactionTypesContract = new TransactionTypesContract();
                objTransactionTypesContract.FilingSchedId = item.FilingSchedId;
                objTransactionTypesContract.FilingSchedDesc = item.FilingSchedDesc;
                objTransactionTypesContract.FilingSchedAbbrev = item.FilingSchedAbbrev;
                lstTransactionTypesContract.Add(objTransactionTypesContract);
            }

            return lstTransactionTypesContract;
        }
        #endregion GetIEWeeklyExpTransactionTypes

        #region GetFilingTransIEWeeklyExpenditureData
        /// <summary>
        /// GetFilingTransIEWeeklyExpenditureData
        /// </summary>
        /// <param name="objFilingTransDataContract"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataContract> GetFilingTransIEWeeklyExpenditureData(FilingTransDataContract objFilingTransDataContract)
        {
            IList<FilingTransactionDataContract> lstFilingTransactionDataContract = new List<FilingTransactionDataContract>();
            FilingTransactionDataContract objFilingTransactionDataContract;

            FilingTransDataEntity objFilingTransDataEntity = new FilingTransDataEntity();
            objFilingTransDataEntity.FilerId = objFilingTransDataContract.FilerId;
            objFilingTransDataEntity.ReportYearId = objFilingTransDataContract.ReportYearId;
            objFilingTransDataEntity.OfficeTypeId = objFilingTransDataContract.OfficeTypeId;
            objFilingTransDataEntity.ElectionType = objFilingTransDataContract.ElectionType;
            objFilingTransDataEntity.ElectionDateId = objFilingTransDataContract.ElectionDateId;
            objFilingTransDataEntity.FilingDate = objFilingTransDataContract.FilingDate;
            objFilingTransDataEntity.MunicipalityID = objFilingTransDataContract.MunicipalityID;

            var results = objEFSRepository.GetFilingTransIEWeeklyExpenditureData(objFilingTransDataEntity);

            foreach (var item in results)
            {
                objFilingTransactionDataContract = new FilingTransactionDataContract();
                objFilingTransactionDataContract.FilingTransId = item.FilingTransId;
                objFilingTransactionDataContract.FilingSchedId = item.FilingSchedId;
                objFilingTransactionDataContract.PurposeCodeId = item.PurposeCodeId;
                objFilingTransactionDataContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionDataContract.PaymentTypeId = item.PaymentTypeId;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.SubmissionDate = item.SubmissionDate;
                objFilingTransactionDataContract.SchedDate = item.SchedDate;
                objFilingTransactionDataContract.FilingSchedDesc = item.FilingSchedDesc;
                objFilingTransactionDataContract.FilingEntityId = item.FilingEntityId;
                objFilingTransactionDataContract.FilingEntityName = item.FilingEntityName;
                objFilingTransactionDataContract.FilingFirstName = item.FilingFirstName;
                objFilingTransactionDataContract.FilingMiddleName = item.FilingMiddleName;
                objFilingTransactionDataContract.FilingLastName = item.FilingLastName;
                objFilingTransactionDataContract.FilingStreetNumber = item.FilingStreetNumber;
                objFilingTransactionDataContract.FilingStreetName = item.FilingStreetName;
                objFilingTransactionDataContract.FilingCity = item.FilingCity;
                objFilingTransactionDataContract.FilingState = item.FilingState;
                objFilingTransactionDataContract.FilingZip = item.FilingZip;
                objFilingTransactionDataContract.FilingCountry = item.FilingCountry;
                objFilingTransactionDataContract.PaymentTypeDesc = item.PaymentTypeDesc;
                objFilingTransactionDataContract.PayNumber = item.PayNumber;
                objFilingTransactionDataContract.OriginalAmount = item.OriginalAmount;
                objFilingTransactionDataContract.ReceiptTypeDesc = item.ReceiptTypeDesc;
                objFilingTransactionDataContract.TransferTypeDesc = item.TransferTypeDesc;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.OriginalDate = item.OriginalDate;
                objFilingTransactionDataContract.LoanerCode = item.LoanerCode;
                objFilingTransactionDataContract.ElectionYear = item.ElectionYear;
                objFilingTransactionDataContract.Office = item.Office;
                objFilingTransactionDataContract.District = item.District;
                objFilingTransactionDataContract.RLiability = item.RLiability;
                objFilingTransactionDataContract.RSubcontractor = item.RSubcontractor;
                objFilingTransactionDataContract.TransExplanation = item.TransExplanation;
                objFilingTransactionDataContract.OwedAmount = item.OwedAmount;
                objFilingTransactionDataContract.RItemized = item.RItemized;
                objFilingTransactionDataContract.RAmend = item.RAmend;
                objFilingTransactionDataContract.RStatus = item.RStatus;
                objFilingTransactionDataContract.CountyID = item.CountyID;
                objFilingTransactionDataContract.CountyDesc = item.CountyDesc;
                objFilingTransactionDataContract.MunicipalityID = item.MunicipalityID;
                objFilingTransactionDataContract.MunicipalityDesc = item.MunicipalityDesc;
                objFilingTransactionDataContract.LoanerCodeID = item.LoanerCodeId;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.CreatedDate = item.CreatedDate;
                objFilingTransactionDataContract.TreasurerFirstName = item.TreasurerFirstName;
                objFilingTransactionDataContract.TreasurerLastName = item.TreasurerLastName;
                objFilingTransactionDataContract.TreasurerMiddleName = item.TreasurerMiddleName;
                objFilingTransactionDataContract.TreasurerOccuptaion = item.TreasurerOccuptaion;
                objFilingTransactionDataContract.TreasurerEmployer = item.TreasurerEmployer;
                objFilingTransactionDataContract.TreasurerStreetAddress = item.TreasurerStreetAddress;
                objFilingTransactionDataContract.TreasurerCity = item.TreasurerCity;
                objFilingTransactionDataContract.TreasurerState = item.TreasurerState;
                objFilingTransactionDataContract.TreasurerZip = item.TreasurerZip;
                objFilingTransactionDataContract.ContributorOccupation = item.ContributorOccupation;
                objFilingTransactionDataContract.ContributorEmployer = item.ContributorEmployer;
                objFilingTransactionDataContract.IEDescription = item.IEDescription;
                objFilingTransactionDataContract.CandBallotPropReference = item.CandBallotPropReference;
                objFilingTransactionDataContract.IESupported = item.IESupported;
                objFilingTransactionDataContract.RLiability = item.RLiability;
                objFilingTransactionDataContract.RSubcontractor = item.RSubcontractor;
                objFilingTransactionDataContract.AddrId = item.AddrId;
                objFilingTransactionDataContract.TreasId = item.TreasId;
                objFilingTransactionDataContract.DateIncurredOrgAmtId = item.DateIncurredOrgAmtId;
                objFilingTransactionDataContract.LoanLiablityNumber = item.LoanLiablityNumber;
                objFilingTransactionDataContract.TransNumber = item.TransNumber;
                objFilingTransactionDataContract.TransMapping = item.TransMapping;
                objFilingTransactionDataContract.FilingsId = item.FilingsId;
                lstFilingTransactionDataContract.Add(objFilingTransactionDataContract);
            }

            return lstFilingTransactionDataContract;
        }
        #endregion GetFilingTransIEWeeklyExpenditureData

        #region GetFilingTransIE24HContributionHistoryData
        /// <summary>
        /// GetFilingTransIE24HContributionHistoryData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataContract> GetFilingTransIEWeeklyExpenditureHistoryData(String strTransNumber)
        {
            IList<FilingTransactionDataContract> lstFilingTransactionDataContract = new List<FilingTransactionDataContract>();
            FilingTransactionDataContract objFilingTransactionDataContract;

            var results = objEFSRepository.GetFilingTransIEWeeklyExpenditureHistoryData(strTransNumber);

            foreach (var item in results)
            {
                objFilingTransactionDataContract = new FilingTransactionDataContract();
                objFilingTransactionDataContract.FilingTransId = item.FilingTransId;
                objFilingTransactionDataContract.FilingSchedId = item.FilingSchedId;
                objFilingTransactionDataContract.PurposeCodeId = item.ContributorTypeId;
                objFilingTransactionDataContract.PurposeCodeDesc = item.PurposeCodeId;
                objFilingTransactionDataContract.ContributionTypeId = item.PurposeCodeDesc;
                objFilingTransactionDataContract.PaymentTypeId = item.PaymentTypeId;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.SubmissionDate = item.SubmissionDate;
                objFilingTransactionDataContract.SchedDate = item.SchedDate;
                objFilingTransactionDataContract.FilingSchedDesc = item.FilingSchedDesc;
                objFilingTransactionDataContract.FilingEntityId = item.FilingEntityId;
                objFilingTransactionDataContract.FilingEntityName = item.FilingEntityName;
                objFilingTransactionDataContract.FilingFirstName = item.FilingFirstName;
                objFilingTransactionDataContract.FilingMiddleName = item.FilingMiddleName;
                objFilingTransactionDataContract.FilingLastName = item.FilingLastName;
                objFilingTransactionDataContract.FilingStreetNumber = item.FilingStreetNumber;
                objFilingTransactionDataContract.FilingStreetName = item.FilingStreetName;
                objFilingTransactionDataContract.FilingCity = item.FilingCity;
                objFilingTransactionDataContract.FilingState = item.FilingState;
                objFilingTransactionDataContract.FilingZip = item.FilingZip;
                objFilingTransactionDataContract.FilingCountry = item.FilingCountry;
                objFilingTransactionDataContract.PaymentTypeDesc = item.PaymentTypeDesc;
                objFilingTransactionDataContract.PayNumber = item.PayNumber;
                objFilingTransactionDataContract.OriginalAmount = item.OriginalAmount;
                objFilingTransactionDataContract.ReceiptTypeDesc = item.ReceiptTypeDesc;
                objFilingTransactionDataContract.TransferTypeDesc = item.TransferTypeDesc;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.OriginalDate = item.OriginalDate;
                objFilingTransactionDataContract.LoanerCode = item.LoanerCode;
                objFilingTransactionDataContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objFilingTransactionDataContract.ElectionYear = item.ElectionYear;
                objFilingTransactionDataContract.Office = item.Office;
                objFilingTransactionDataContract.District = item.District;
                objFilingTransactionDataContract.RLiability = item.RLiability;
                objFilingTransactionDataContract.RSubcontractor = item.RSubcontractor;
                objFilingTransactionDataContract.TransExplanation = item.TransExplanation;
                objFilingTransactionDataContract.OwedAmount = item.OwedAmount;
                objFilingTransactionDataContract.RItemized = item.RItemized;
                objFilingTransactionDataContract.RAmend = item.RAmend;
                objFilingTransactionDataContract.RStatus = item.RStatus;
                objFilingTransactionDataContract.CountyID = item.CountyID;
                objFilingTransactionDataContract.CountyDesc = item.CountyDesc;
                objFilingTransactionDataContract.MunicipalityID = item.MunicipalityID;
                objFilingTransactionDataContract.MunicipalityDesc = item.MunicipalityDesc;
                objFilingTransactionDataContract.LoanerCodeID = item.LoanerCodeId;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeDesc;
                objFilingTransactionDataContract.CreatedDate = item.CreatedDate;
                objFilingTransactionDataContract.TreasurerFirstName = item.TreasurerFirstName;
                objFilingTransactionDataContract.TreasurerLastName = item.TreasurerLastName;
                objFilingTransactionDataContract.TreasurerMiddleName = item.TreasurerMiddleName;
                objFilingTransactionDataContract.TreasurerOccuptaion = item.TreasurerOccuptaion;
                objFilingTransactionDataContract.TreasurerEmployer = item.TreasurerEmployer;
                objFilingTransactionDataContract.TreasurerStreetAddress = item.TreasurerStreetAddress;
                objFilingTransactionDataContract.TreasurerCity = item.TreasurerCity;
                objFilingTransactionDataContract.TreasurerState = item.TreasurerState;
                objFilingTransactionDataContract.TreasurerZip = item.TreasurerZip;
                objFilingTransactionDataContract.ContributorOccupation = item.ContributorOccupation;
                objFilingTransactionDataContract.ContributorEmployer = item.ContributorEmployer;
                objFilingTransactionDataContract.CandBallotPropReference = item.CandBallotPropReference;
                objFilingTransactionDataContract.IEDescription = item.IEDescription;
                objFilingTransactionDataContract.IESupported = item.IESupported;
                objFilingTransactionDataContract.LoanLiablityNumber = item.LoanLiablityNumber;
                objFilingTransactionDataContract.TransNumber = item.TransNumber;
                objFilingTransactionDataContract.TransMapping = item.TransMapping;
                lstFilingTransactionDataContract.Add(objFilingTransactionDataContract);
            }

            return lstFilingTransactionDataContract;
        }
        #endregion GetFilingTransIE24HContributionHistoryData

        #region AddNonItemIEWeeklyExpFlngTrans
        /// <summary>
        /// AddNonItemIEWeeklyExpFlngTrans
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean AddNonItemIEWeeklyExpFlngTrans(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.PersonId = objFilingTransactionsContract.PersonId;
            objFilingTransactionsEntity.TreasId = objFilingTransactionsContract.TreasId;
            objFilingTransactionsEntity.AddrId = objFilingTransactionsContract.AddrId;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.PurposeCodeId = objFilingTransactionsContract.PurposeCodeId;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.OwedAmt = objFilingTransactionsContract.OwedAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.MunicipalityID = objFilingTransactionsContract.MunicipalityID;
            objFilingTransactionsEntity.RAmend = objFilingTransactionsContract.RAmend;
            objFilingTransactionsEntity.ElectionDate = objFilingTransactionsContract.ElectionDate;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.ElectionYear = objFilingTransactionsContract.ElectionYear;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.TreasurerOccupation = objFilingTransactionsContract.TreasurerOccupation;
            objFilingTransactionsEntity.TreasurerEmployer = objFilingTransactionsContract.TreasurerEmployer;
            objFilingTransactionsEntity.TreasurerStreetAddress = objFilingTransactionsContract.TreasurerStreetAddress;
            objFilingTransactionsEntity.TreasurerCity = objFilingTransactionsContract.TreasurerCity;
            objFilingTransactionsEntity.TreasurerState = objFilingTransactionsContract.TreasurerState;
            objFilingTransactionsEntity.TreasurerZip = objFilingTransactionsContract.TreasurerZip;
            objFilingTransactionsEntity.CandBallotPropReference = objFilingTransactionsContract.CandBallotPropReference;
            objFilingTransactionsEntity.IEDescription = objFilingTransactionsContract.IEDescription;
            objFilingTransactionsEntity.R_Supported = objFilingTransactionsContract.R_Supported;
            objFilingTransactionsEntity.RLiability = objFilingTransactionsContract.RLiability;
            objFilingTransactionsEntity.RSubcontractor = objFilingTransactionsContract.RSubcontractor;
            objFilingTransactionsEntity.DateIncurredOrgAmtId = objFilingTransactionsContract.DateIncurredOrgAmtId;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;

            Boolean returnValue = objEFSRepository.AddNonItemIEWeeklyExpFlngTrans(objFilingTransactionsEntity);

            return returnValue;
        }
        #endregion AddNonItemIEWeeklyExpFlngTrans

        #region UpdateIEWeeklyExpenditureFlngTrans
        /// <summary>
        /// UpdateIEWeeklyExpenditureFlngTrans
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean UpdateIEWeeklyExpenditureFlngTrans(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.TransNumber = objFilingTransactionsContract.TransNumber;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.TreasId = objFilingTransactionsContract.TreasId;
            objFilingTransactionsEntity.AddrId = objFilingTransactionsContract.AddrId;
            objFilingTransactionsEntity.PersonId = objFilingTransactionsContract.PersonId;
            objFilingTransactionsEntity.SubmissionDate = objFilingTransactionsContract.SubmissionDate;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.PurposeCodeId = objFilingTransactionsContract.PurposeCodeId;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.OwedAmt = objFilingTransactionsContract.OwedAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.TreasurerStreetAddress = objFilingTransactionsContract.TreasurerStreetAddress;
            objFilingTransactionsEntity.TreasurerCity = objFilingTransactionsContract.TreasurerCity;
            objFilingTransactionsEntity.TreasurerState = objFilingTransactionsContract.TreasurerState;
            objFilingTransactionsEntity.TreasurerZip = objFilingTransactionsContract.TreasurerZip;
            objFilingTransactionsEntity.IEDescription = objFilingTransactionsContract.IEDescription;
            objFilingTransactionsEntity.TreasurerOccupation = objFilingTransactionsContract.TreasurerOccupation;
            objFilingTransactionsEntity.TreasurerEmployer = objFilingTransactionsContract.TreasurerEmployer;
            objFilingTransactionsEntity.R_Supported = objFilingTransactionsContract.R_Supported;
            objFilingTransactionsEntity.CandBallotPropReference = objFilingTransactionsContract.CandBallotPropReference;
            objFilingTransactionsEntity.RSubcontractor = objFilingTransactionsContract.RSubcontractor;
            objFilingTransactionsEntity.RLiability = objFilingTransactionsContract.RLiability;
            objFilingTransactionsEntity.DateIncurredOrgAmtId = objFilingTransactionsContract.DateIncurredOrgAmtId;
            objFilingTransactionsEntity.ModifiedBy = objFilingTransactionsContract.ModifiedBy;

            Boolean returnValue = objEFSRepository.UpdateIEWeeklyExpenditureFlngTrans(objFilingTransactionsEntity);

            return returnValue;
        }
        #endregion UpdateIEWeeklyExpenditureFlngTrans

        #region GetNonItemIEDateIncrdLiabUpdateData
        /// <summary>
        /// GetNonItemIEDateIncrdLiabUpdateData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<DateIncurredContract> GetNonItemIEDateIncrdLiabUpdateData(String strTransNumber)
        {
            IList<DateIncurredContract> lstDateIncurredContract = new List<DateIncurredContract>();
            DateIncurredContract objDateIncurredContract;

            var results = objEFSRepository.GetNonItemIEDateIncrdLiabUpdateData(strTransNumber);

            foreach (var item in results)
            {
                objDateIncurredContract = new DateIncurredContract();
                objDateIncurredContract.DateIncurredId = item.DateIncurredId;
                objDateIncurredContract.DateIncurredValue = item.DateIncurredValue;
                objDateIncurredContract.AmountLiability = item.AmountLiability;
                lstDateIncurredContract.Add(objDateIncurredContract);
            }
            return lstDateIncurredContract;
        }
        #endregion GetNonItemIEDateIncrdLiabUpdateData

        #region GetNonItemIEPurposeCodes
        /// <summary>
        /// GetNonItemIEPurposeCodes
        /// </summary>
        /// <returns></returns>
        public IList<PurposeCodeContract> GetNonItemIEPurposeCodes()
        {
            IList<PurposeCodeContract> lstPurposeCodeContract = new List<PurposeCodeContract>();
            PurposeCodeContract objPurposeCodeContract;

            var results = objEFSRepository.GetNonItemIEPurposeCodes();

            foreach (var item in results)
            {
                objPurposeCodeContract = new PurposeCodeContract();
                objPurposeCodeContract.PurposeCodeId = item.PurposeCodeId;
                objPurposeCodeContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objPurposeCodeContract.PurposeCodeAbbrev = item.PurposeCodeAbbrev;
                lstPurposeCodeContract.Add(objPurposeCodeContract);
            }

            return lstPurposeCodeContract;
        }
        #endregion GetNonItemIEPurposeCodes

        #region GetNonItemIEPurposeCodesSubContr
        /// <summary>
        /// GetNonItemIEPurposeCodesSubContr
        /// </summary>
        /// <returns></returns>
        public IList<PurposeCodeContract> GetNonItemIEPurposeCodesSubContr()
        {
            IList<PurposeCodeContract> lstPurposeCodeContract = new List<PurposeCodeContract>();
            PurposeCodeContract objPurposeCodeContract;

            var results = objEFSRepository.GetNonItemIEPurposeCodesSubContr();

            foreach (var item in results)
            {
                objPurposeCodeContract = new PurposeCodeContract();
                objPurposeCodeContract.PurposeCodeId = item.PurposeCodeId;
                objPurposeCodeContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objPurposeCodeContract.PurposeCodeAbbrev = item.PurposeCodeAbbrev;
                lstPurposeCodeContract.Add(objPurposeCodeContract);
            }

            return lstPurposeCodeContract;
        }
        #endregion GetNonItemIEPurposeCodesSubContr

        #region GetFilingTransIE24HourExpenditureData
        /// <summary>
        /// GetFilingTransIE24HourExpenditureData
        /// </summary>
        /// <param name="objFilingTransDataContract"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataContract> GetFilingTransIE24HourExpenditureData(FilingTransDataContract objFilingTransDataContract)
        {
            IList<FilingTransactionDataContract> lstFilingTransactionDataContract = new List<FilingTransactionDataContract>();
            FilingTransactionDataContract objFilingTransactionDataContract;

            FilingTransDataEntity objFilingTransDataEntity = new FilingTransDataEntity();
            objFilingTransDataEntity.FilerId = objFilingTransDataContract.FilerId;
            objFilingTransDataEntity.ReportYearId = objFilingTransDataContract.ReportYearId;
            objFilingTransDataEntity.OfficeTypeId = objFilingTransDataContract.OfficeTypeId;
            objFilingTransDataEntity.ElectionType = objFilingTransDataContract.ElectionType;
            objFilingTransDataEntity.ElectionDateId = objFilingTransDataContract.ElectionDateId;
            objFilingTransDataEntity.FilingDate = objFilingTransDataContract.FilingDate;

            var results = objEFSRepository.GetFilingTransIE24HourExpenditureData(objFilingTransDataEntity);

            foreach (var item in results)
            {
                objFilingTransactionDataContract = new FilingTransactionDataContract();
                objFilingTransactionDataContract.FilingTransId = item.FilingTransId;
                objFilingTransactionDataContract.FilingSchedId = item.FilingSchedId;
                objFilingTransactionDataContract.PurposeCodeId = item.PurposeCodeId;
                objFilingTransactionDataContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionDataContract.PaymentTypeId = item.PaymentTypeId;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.SubmissionDate = item.SubmissionDate;
                objFilingTransactionDataContract.SchedDate = item.SchedDate;
                objFilingTransactionDataContract.FilingSchedDesc = item.FilingSchedDesc;
                objFilingTransactionDataContract.FilingEntityId = item.FilingEntityId;
                objFilingTransactionDataContract.FilingEntityName = item.FilingEntityName;
                objFilingTransactionDataContract.FilingFirstName = item.FilingFirstName;
                objFilingTransactionDataContract.FilingMiddleName = item.FilingMiddleName;
                objFilingTransactionDataContract.FilingLastName = item.FilingLastName;
                objFilingTransactionDataContract.FilingStreetNumber = item.FilingStreetNumber;
                objFilingTransactionDataContract.FilingStreetName = item.FilingStreetName;
                objFilingTransactionDataContract.FilingCity = item.FilingCity;
                objFilingTransactionDataContract.FilingState = item.FilingState;
                objFilingTransactionDataContract.FilingZip = item.FilingZip;
                objFilingTransactionDataContract.FilingCountry = item.FilingCountry;
                objFilingTransactionDataContract.PaymentTypeDesc = item.PaymentTypeDesc;
                objFilingTransactionDataContract.PayNumber = item.PayNumber;
                objFilingTransactionDataContract.OriginalAmount = item.OriginalAmount;
                objFilingTransactionDataContract.ReceiptTypeDesc = item.ReceiptTypeDesc;
                objFilingTransactionDataContract.TransferTypeDesc = item.TransferTypeDesc;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.OriginalDate = item.OriginalDate;
                objFilingTransactionDataContract.LoanerCode = item.LoanerCode;
                objFilingTransactionDataContract.ElectionYear = item.ElectionYear;
                objFilingTransactionDataContract.Office = item.Office;
                objFilingTransactionDataContract.District = item.District;
                objFilingTransactionDataContract.RLiability = item.RLiability;
                objFilingTransactionDataContract.RSubcontractor = item.RSubcontractor;
                objFilingTransactionDataContract.TransExplanation = item.TransExplanation;
                objFilingTransactionDataContract.OwedAmount = item.OwedAmount;
                objFilingTransactionDataContract.RItemized = item.RItemized;
                objFilingTransactionDataContract.RAmend = item.RAmend;
                objFilingTransactionDataContract.RStatus = item.RStatus;
                objFilingTransactionDataContract.CountyID = item.CountyID;
                objFilingTransactionDataContract.CountyDesc = item.CountyDesc;
                objFilingTransactionDataContract.MunicipalityID = item.MunicipalityID;
                objFilingTransactionDataContract.MunicipalityDesc = item.MunicipalityDesc;
                objFilingTransactionDataContract.LoanerCodeID = item.LoanerCodeId;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.CreatedDate = item.CreatedDate;
                objFilingTransactionDataContract.TreasurerFirstName = item.TreasurerFirstName;
                objFilingTransactionDataContract.TreasurerLastName = item.TreasurerLastName;
                objFilingTransactionDataContract.TreasurerMiddleName = item.TreasurerMiddleName;
                objFilingTransactionDataContract.TreasurerOccuptaion = item.TreasurerOccuptaion;
                objFilingTransactionDataContract.TreasurerEmployer = item.TreasurerEmployer;
                objFilingTransactionDataContract.TreasurerStreetAddress = item.TreasurerStreetAddress;
                objFilingTransactionDataContract.TreasurerCity = item.TreasurerCity;
                objFilingTransactionDataContract.TreasurerState = item.TreasurerState;
                objFilingTransactionDataContract.TreasurerZip = item.TreasurerZip;
                objFilingTransactionDataContract.ContributorOccupation = item.ContributorOccupation;
                objFilingTransactionDataContract.ContributorEmployer = item.ContributorEmployer;
                objFilingTransactionDataContract.IEDescription = item.IEDescription;
                objFilingTransactionDataContract.CandBallotPropReference = item.CandBallotPropReference;
                objFilingTransactionDataContract.IESupported = item.IESupported;
                objFilingTransactionDataContract.RLiability = item.RLiability;
                objFilingTransactionDataContract.RSubcontractor = item.RSubcontractor;
                objFilingTransactionDataContract.AddrId = item.AddrId;
                objFilingTransactionDataContract.TreasId = item.TreasId;
                objFilingTransactionDataContract.DateIncurredOrgAmtId = item.DateIncurredOrgAmtId;
                objFilingTransactionDataContract.LoanLiablityNumber = item.LoanLiablityNumber;
                objFilingTransactionDataContract.TransNumber = item.TransNumber;
                objFilingTransactionDataContract.TransMapping = item.TransMapping;
                lstFilingTransactionDataContract.Add(objFilingTransactionDataContract);
            }

            return lstFilingTransactionDataContract;
        }
        #endregion GetFilingTransIE24HourExpenditureData

        #region GetFilingTransIE24HourPIDAExpenditureData
        /// <summary>
        /// GetFilingTransIE24HourPIDAExpenditureData
        /// </summary>
        /// <param name="objFilingTransDataContract"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataContract> GetFilingTransIE24HourPIDAExpenditureData(FilingTransDataContract objFilingTransDataContract)
        {
            IList<FilingTransactionDataContract> lstFilingTransactionDataContract = new List<FilingTransactionDataContract>();
            FilingTransactionDataContract objFilingTransactionDataContract;

            FilingTransDataEntity objFilingTransDataEntity = new FilingTransDataEntity();
            objFilingTransDataEntity.FilerId = objFilingTransDataContract.FilerId;
            objFilingTransDataEntity.ReportYearId = objFilingTransDataContract.ReportYearId;
            objFilingTransDataEntity.OfficeTypeId = objFilingTransDataContract.OfficeTypeId;
            objFilingTransDataEntity.ElectionType = objFilingTransDataContract.ElectionType;
            objFilingTransDataEntity.ElectionDateId = objFilingTransDataContract.ElectionDateId;
            objFilingTransDataEntity.FilingDate = objFilingTransDataContract.FilingDate;

            var results = objEFSRepository.GetFilingTransIE24HourPIDAExpenditureData(objFilingTransDataEntity);

            foreach (var item in results)
            {
                objFilingTransactionDataContract = new FilingTransactionDataContract();
                objFilingTransactionDataContract.FilingTransId = item.FilingTransId;
                objFilingTransactionDataContract.FilingSchedId = item.FilingSchedId;
                objFilingTransactionDataContract.PurposeCodeId = item.PurposeCodeId;
                objFilingTransactionDataContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionDataContract.PaymentTypeId = item.PaymentTypeId;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.SubmissionDate = item.SubmissionDate;
                objFilingTransactionDataContract.SchedDate = item.SchedDate;
                objFilingTransactionDataContract.FilingSchedDesc = item.FilingSchedDesc;
                objFilingTransactionDataContract.FilingEntityId = item.FilingEntityId;
                objFilingTransactionDataContract.FilingEntityName = item.FilingEntityName;
                objFilingTransactionDataContract.FilingFirstName = item.FilingFirstName;
                objFilingTransactionDataContract.FilingMiddleName = item.FilingMiddleName;
                objFilingTransactionDataContract.FilingLastName = item.FilingLastName;
                objFilingTransactionDataContract.FilingStreetNumber = item.FilingStreetNumber;
                objFilingTransactionDataContract.FilingStreetName = item.FilingStreetName;
                objFilingTransactionDataContract.FilingCity = item.FilingCity;
                objFilingTransactionDataContract.FilingState = item.FilingState;
                objFilingTransactionDataContract.FilingZip = item.FilingZip;
                objFilingTransactionDataContract.FilingCountry = item.FilingCountry;
                objFilingTransactionDataContract.PaymentTypeDesc = item.PaymentTypeDesc;
                objFilingTransactionDataContract.PayNumber = item.PayNumber;
                objFilingTransactionDataContract.OriginalAmount = item.OriginalAmount;
                objFilingTransactionDataContract.ReceiptTypeDesc = item.ReceiptTypeDesc;
                objFilingTransactionDataContract.TransferTypeDesc = item.TransferTypeDesc;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.OriginalDate = item.OriginalDate;
                objFilingTransactionDataContract.LoanerCode = item.LoanerCode;
                objFilingTransactionDataContract.ElectionYear = item.ElectionYear;
                objFilingTransactionDataContract.Office = item.Office;
                objFilingTransactionDataContract.District = item.District;
                objFilingTransactionDataContract.RLiability = item.RLiability;
                objFilingTransactionDataContract.RSubcontractor = item.RSubcontractor;
                objFilingTransactionDataContract.TransExplanation = item.TransExplanation;
                objFilingTransactionDataContract.OwedAmount = item.OwedAmount;
                objFilingTransactionDataContract.RItemized = item.RItemized;
                objFilingTransactionDataContract.RAmend = item.RAmend;
                objFilingTransactionDataContract.RStatus = item.RStatus;
                objFilingTransactionDataContract.CountyID = item.CountyID;
                objFilingTransactionDataContract.CountyDesc = item.CountyDesc;
                objFilingTransactionDataContract.MunicipalityID = item.MunicipalityID;
                objFilingTransactionDataContract.MunicipalityDesc = item.MunicipalityDesc;
                objFilingTransactionDataContract.LoanerCodeID = item.LoanerCodeId;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.CreatedDate = item.CreatedDate;
                objFilingTransactionDataContract.TreasurerFirstName = item.TreasurerFirstName;
                objFilingTransactionDataContract.TreasurerLastName = item.TreasurerLastName;
                objFilingTransactionDataContract.TreasurerMiddleName = item.TreasurerMiddleName;
                objFilingTransactionDataContract.TreasurerOccuptaion = item.TreasurerOccuptaion;
                objFilingTransactionDataContract.TreasurerEmployer = item.TreasurerEmployer;
                objFilingTransactionDataContract.TreasurerStreetAddress = item.TreasurerStreetAddress;
                objFilingTransactionDataContract.TreasurerCity = item.TreasurerCity;
                objFilingTransactionDataContract.TreasurerState = item.TreasurerState;
                objFilingTransactionDataContract.TreasurerZip = item.TreasurerZip;
                objFilingTransactionDataContract.ContributorOccupation = item.ContributorOccupation;
                objFilingTransactionDataContract.ContributorEmployer = item.ContributorEmployer;
                objFilingTransactionDataContract.IEDescription = item.IEDescription;
                objFilingTransactionDataContract.CandBallotPropReference = item.CandBallotPropReference;
                objFilingTransactionDataContract.IESupported = item.IESupported;
                objFilingTransactionDataContract.RLiability = item.RLiability;
                objFilingTransactionDataContract.RSubcontractor = item.RSubcontractor;
                objFilingTransactionDataContract.AddrId = item.AddrId;
                objFilingTransactionDataContract.TreasId = item.TreasId;
                objFilingTransactionDataContract.DateIncurredOrgAmtId = item.DateIncurredOrgAmtId;
                objFilingTransactionDataContract.LoanLiablityNumber = item.LoanLiablityNumber;
                objFilingTransactionDataContract.TransNumber = item.TransNumber;
                objFilingTransactionDataContract.TransMapping = item.TransMapping;
                lstFilingTransactionDataContract.Add(objFilingTransactionDataContract);
            }

            return lstFilingTransactionDataContract;
        }
        #endregion GetFilingTransIE24HourPIDAExpenditureData

        #region AddNonItemIE24HourExpFlngTrans
        /// <summary>
        /// AddNonItemIE24HourExpFlngTrans
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean AddNonItemIE24HourExpFlngTrans(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.PersonId = objFilingTransactionsContract.PersonId;
            objFilingTransactionsEntity.TreasId = objFilingTransactionsContract.TreasId;
            objFilingTransactionsEntity.AddrId = objFilingTransactionsContract.AddrId;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.PurposeCodeId = objFilingTransactionsContract.PurposeCodeId;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.OwedAmt = objFilingTransactionsContract.OwedAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.MunicipalityID = objFilingTransactionsContract.MunicipalityID;
            objFilingTransactionsEntity.RAmend = objFilingTransactionsContract.RAmend;
            objFilingTransactionsEntity.ElectionDate = objFilingTransactionsContract.ElectionDate;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.ElectionYear = objFilingTransactionsContract.ElectionYear;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.TreasurerOccupation = objFilingTransactionsContract.TreasurerOccupation;
            objFilingTransactionsEntity.TreasurerEmployer = objFilingTransactionsContract.TreasurerEmployer;
            objFilingTransactionsEntity.TreasurerStreetAddress = objFilingTransactionsContract.TreasurerStreetAddress;
            objFilingTransactionsEntity.TreasurerCity = objFilingTransactionsContract.TreasurerCity;
            objFilingTransactionsEntity.TreasurerState = objFilingTransactionsContract.TreasurerState;
            objFilingTransactionsEntity.TreasurerZip = objFilingTransactionsContract.TreasurerZip;
            objFilingTransactionsEntity.CandBallotPropReference = objFilingTransactionsContract.CandBallotPropReference;
            objFilingTransactionsEntity.IEDescription = objFilingTransactionsContract.IEDescription;
            objFilingTransactionsEntity.R_Supported = objFilingTransactionsContract.R_Supported;
            objFilingTransactionsEntity.RLiability = objFilingTransactionsContract.RLiability;
            objFilingTransactionsEntity.RSubcontractor = objFilingTransactionsContract.RSubcontractor;
            objFilingTransactionsEntity.DateIncurredOrgAmtId = objFilingTransactionsContract.DateIncurredOrgAmtId;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;

            Boolean returnValue = objEFSRepository.AddNonItemIE24HourExpFlngTrans(objFilingTransactionsEntity);

            return returnValue;
        }
        #endregion AddNonItemIE24HourExpFlngTrans

        #region AddNonItemIE24HourPIDAExpFlngTrans
        /// <summary>
        /// AddNonItemIE24HourPIDAExpFlngTrans
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean AddNonItemIE24HourPIDAExpFlngTrans(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.PersonId = objFilingTransactionsContract.PersonId;
            objFilingTransactionsEntity.TreasId = objFilingTransactionsContract.TreasId;
            objFilingTransactionsEntity.AddrId = objFilingTransactionsContract.AddrId;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.PurposeCodeId = objFilingTransactionsContract.PurposeCodeId;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.OwedAmt = objFilingTransactionsContract.OwedAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.MunicipalityID = objFilingTransactionsContract.MunicipalityID;
            objFilingTransactionsEntity.RAmend = objFilingTransactionsContract.RAmend;
            objFilingTransactionsEntity.ElectionDate = objFilingTransactionsContract.ElectionDate;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.ElectionYear = objFilingTransactionsContract.ElectionYear;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.TreasurerOccupation = objFilingTransactionsContract.TreasurerOccupation;
            objFilingTransactionsEntity.TreasurerEmployer = objFilingTransactionsContract.TreasurerEmployer;
            objFilingTransactionsEntity.TreasurerStreetAddress = objFilingTransactionsContract.TreasurerStreetAddress;
            objFilingTransactionsEntity.TreasurerCity = objFilingTransactionsContract.TreasurerCity;
            objFilingTransactionsEntity.TreasurerState = objFilingTransactionsContract.TreasurerState;
            objFilingTransactionsEntity.TreasurerZip = objFilingTransactionsContract.TreasurerZip;
            objFilingTransactionsEntity.CandBallotPropReference = objFilingTransactionsContract.CandBallotPropReference;
            objFilingTransactionsEntity.IEDescription = objFilingTransactionsContract.IEDescription;
            objFilingTransactionsEntity.R_Supported = objFilingTransactionsContract.R_Supported;
            objFilingTransactionsEntity.RLiability = objFilingTransactionsContract.RLiability;
            objFilingTransactionsEntity.RSubcontractor = objFilingTransactionsContract.RSubcontractor;
            objFilingTransactionsEntity.DateIncurredOrgAmtId = objFilingTransactionsContract.DateIncurredOrgAmtId;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;

            Boolean returnValue = objEFSRepository.AddNonItemIE24HourPIDAExpFlngTrans(objFilingTransactionsEntity);

            return returnValue;
        }
        #endregion AddNonItemIE24HourPIDAExpFlngTrans

        #region GetFilingTransIEWeeklyPIDAExpenditureData
        /// <summary>
        /// GetFilingTransIEWeeklyPIDAExpenditureData
        /// </summary>
        /// <param name="objFilingTransDataContract"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataContract> GetFilingTransIEWeeklyPIDAExpenditureData(FilingTransDataContract objFilingTransDataContract)
        {
            IList<FilingTransactionDataContract> lstFilingTransactionDataContract = new List<FilingTransactionDataContract>();
            FilingTransactionDataContract objFilingTransactionDataContract;

            FilingTransDataEntity objFilingTransDataEntity = new FilingTransDataEntity();
            objFilingTransDataEntity.FilerId = objFilingTransDataContract.FilerId;
            objFilingTransDataEntity.ReportYearId = objFilingTransDataContract.ReportYearId;
            objFilingTransDataEntity.OfficeTypeId = objFilingTransDataContract.OfficeTypeId;
            objFilingTransDataEntity.ElectionType = objFilingTransDataContract.ElectionType;
            objFilingTransDataEntity.ElectionDateId = objFilingTransDataContract.ElectionDateId;
            objFilingTransDataEntity.FilingDate = objFilingTransDataContract.FilingDate;
            objFilingTransDataEntity.MunicipalityID = objFilingTransDataContract.MunicipalityID;

            var results = objEFSRepository.GetFilingTransIEWeeklyPIDAExpenditureData(objFilingTransDataEntity);

            foreach (var item in results)
            {
                objFilingTransactionDataContract = new FilingTransactionDataContract();
                objFilingTransactionDataContract.FilingTransId = item.FilingTransId;
                objFilingTransactionDataContract.FilingSchedId = item.FilingSchedId;
                objFilingTransactionDataContract.PurposeCodeId = item.PurposeCodeId;
                objFilingTransactionDataContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionDataContract.PaymentTypeId = item.PaymentTypeId;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.SubmissionDate = item.SubmissionDate;
                objFilingTransactionDataContract.SchedDate = item.SchedDate;
                objFilingTransactionDataContract.FilingSchedDesc = item.FilingSchedDesc;
                objFilingTransactionDataContract.FilingEntityId = item.FilingEntityId;
                objFilingTransactionDataContract.FilingEntityName = item.FilingEntityName;
                objFilingTransactionDataContract.FilingFirstName = item.FilingFirstName;
                objFilingTransactionDataContract.FilingMiddleName = item.FilingMiddleName;
                objFilingTransactionDataContract.FilingLastName = item.FilingLastName;
                objFilingTransactionDataContract.FilingStreetNumber = item.FilingStreetNumber;
                objFilingTransactionDataContract.FilingStreetName = item.FilingStreetName;
                objFilingTransactionDataContract.FilingCity = item.FilingCity;
                objFilingTransactionDataContract.FilingState = item.FilingState;
                objFilingTransactionDataContract.FilingZip = item.FilingZip;
                objFilingTransactionDataContract.FilingCountry = item.FilingCountry;
                objFilingTransactionDataContract.PaymentTypeDesc = item.PaymentTypeDesc;
                objFilingTransactionDataContract.PayNumber = item.PayNumber;
                objFilingTransactionDataContract.OriginalAmount = item.OriginalAmount;
                objFilingTransactionDataContract.ReceiptTypeDesc = item.ReceiptTypeDesc;
                objFilingTransactionDataContract.TransferTypeDesc = item.TransferTypeDesc;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.OriginalDate = item.OriginalDate;
                objFilingTransactionDataContract.LoanerCode = item.LoanerCode;
                objFilingTransactionDataContract.ElectionYear = item.ElectionYear;
                objFilingTransactionDataContract.Office = item.Office;
                objFilingTransactionDataContract.District = item.District;
                objFilingTransactionDataContract.RLiability = item.RLiability;
                objFilingTransactionDataContract.RSubcontractor = item.RSubcontractor;
                objFilingTransactionDataContract.TransExplanation = item.TransExplanation;
                objFilingTransactionDataContract.OwedAmount = item.OwedAmount;
                objFilingTransactionDataContract.RItemized = item.RItemized;
                objFilingTransactionDataContract.RAmend = item.RAmend;
                objFilingTransactionDataContract.RStatus = item.RStatus;
                objFilingTransactionDataContract.CountyID = item.CountyID;
                objFilingTransactionDataContract.CountyDesc = item.CountyDesc;
                objFilingTransactionDataContract.MunicipalityID = item.MunicipalityID;
                objFilingTransactionDataContract.MunicipalityDesc = item.MunicipalityDesc;
                objFilingTransactionDataContract.LoanerCodeID = item.LoanerCodeId;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.CreatedDate = item.CreatedDate;
                objFilingTransactionDataContract.TreasurerFirstName = item.TreasurerFirstName;
                objFilingTransactionDataContract.TreasurerLastName = item.TreasurerLastName;
                objFilingTransactionDataContract.TreasurerMiddleName = item.TreasurerMiddleName;
                objFilingTransactionDataContract.TreasurerOccuptaion = item.TreasurerOccuptaion;
                objFilingTransactionDataContract.TreasurerEmployer = item.TreasurerEmployer;
                objFilingTransactionDataContract.TreasurerStreetAddress = item.TreasurerStreetAddress;
                objFilingTransactionDataContract.TreasurerCity = item.TreasurerCity;
                objFilingTransactionDataContract.TreasurerState = item.TreasurerState;
                objFilingTransactionDataContract.TreasurerZip = item.TreasurerZip;
                objFilingTransactionDataContract.ContributorOccupation = item.ContributorOccupation;
                objFilingTransactionDataContract.ContributorEmployer = item.ContributorEmployer;
                objFilingTransactionDataContract.IEDescription = item.IEDescription;
                objFilingTransactionDataContract.CandBallotPropReference = item.CandBallotPropReference;
                objFilingTransactionDataContract.IESupported = item.IESupported;
                objFilingTransactionDataContract.RLiability = item.RLiability;
                objFilingTransactionDataContract.RSubcontractor = item.RSubcontractor;
                objFilingTransactionDataContract.AddrId = item.AddrId;
                objFilingTransactionDataContract.TreasId = item.TreasId;
                objFilingTransactionDataContract.DateIncurredOrgAmtId = item.DateIncurredOrgAmtId;
                objFilingTransactionDataContract.LoanLiablityNumber = item.LoanLiablityNumber;
                objFilingTransactionDataContract.TransNumber = item.TransNumber;
                objFilingTransactionDataContract.TransMapping = item.TransMapping;
                lstFilingTransactionDataContract.Add(objFilingTransactionDataContract);
            }

            return lstFilingTransactionDataContract;
        }
        #endregion GetFilingTransIEWeeklyPIDAExpenditureData

        #region AddNonItemIEWeeklyPIDAExpFlngTrans
        /// <summary>
        /// AddNonItemIEWeeklyPIDAExpFlngTrans
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean AddNonItemIEWeeklyPIDAExpFlngTrans(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.PersonId = objFilingTransactionsContract.PersonId;
            objFilingTransactionsEntity.TreasId = objFilingTransactionsContract.TreasId;
            objFilingTransactionsEntity.AddrId = objFilingTransactionsContract.AddrId;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.PurposeCodeId = objFilingTransactionsContract.PurposeCodeId;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.OwedAmt = objFilingTransactionsContract.OwedAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.MunicipalityID = objFilingTransactionsContract.MunicipalityID;
            objFilingTransactionsEntity.RAmend = objFilingTransactionsContract.RAmend;
            objFilingTransactionsEntity.ElectionDate = objFilingTransactionsContract.ElectionDate;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.ElectionYear = objFilingTransactionsContract.ElectionYear;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.TreasurerOccupation = objFilingTransactionsContract.TreasurerOccupation;
            objFilingTransactionsEntity.TreasurerEmployer = objFilingTransactionsContract.TreasurerEmployer;
            objFilingTransactionsEntity.TreasurerStreetAddress = objFilingTransactionsContract.TreasurerStreetAddress;
            objFilingTransactionsEntity.TreasurerCity = objFilingTransactionsContract.TreasurerCity;
            objFilingTransactionsEntity.TreasurerState = objFilingTransactionsContract.TreasurerState;
            objFilingTransactionsEntity.TreasurerZip = objFilingTransactionsContract.TreasurerZip;
            objFilingTransactionsEntity.CandBallotPropReference = objFilingTransactionsContract.CandBallotPropReference;
            objFilingTransactionsEntity.IEDescription = objFilingTransactionsContract.IEDescription;
            objFilingTransactionsEntity.R_Supported = objFilingTransactionsContract.R_Supported;
            objFilingTransactionsEntity.RLiability = objFilingTransactionsContract.RLiability;
            objFilingTransactionsEntity.RSubcontractor = objFilingTransactionsContract.RSubcontractor;
            objFilingTransactionsEntity.DateIncurredOrgAmtId = objFilingTransactionsContract.DateIncurredOrgAmtId;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;

            Boolean returnValue = objEFSRepository.AddNonItemIEWeeklyPIDAExpFlngTrans(objFilingTransactionsEntity);

            return returnValue;
        }
        #endregion AddNonItemIEWeeklyPIDAExpFlngTrans

        #region GetIEWeeklyLiabInccrTransactionTypes
        /// <summary>
        /// GetIEWeeklyLiabInccrTransactionTypes
        /// </summary>
        /// <returns></returns>
        public IList<TransactionTypesContract> GetIEWeeklyLiabInccrTransactionTypes()
        {
            IList<TransactionTypesContract> lstTransactionTypesContract = new List<TransactionTypesContract>();
            TransactionTypesContract objTransactionTypesContract;

            var results = objEFSRepository.GetIEWeeklyLiabInccrTransactionTypes();

            foreach (var item in results)
            {
                objTransactionTypesContract = new TransactionTypesContract();
                objTransactionTypesContract.FilingSchedId = item.FilingSchedId;
                objTransactionTypesContract.FilingSchedDesc = item.FilingSchedDesc;
                objTransactionTypesContract.FilingSchedAbbrev = item.FilingSchedAbbrev;
                lstTransactionTypesContract.Add(objTransactionTypesContract);
            }

            return lstTransactionTypesContract;
        }
        #endregion GetIEWeeklyLiabInccrTransactionTypes

        #region GetNonItemIESchedNPurposeCodes
        /// <summary>
        /// GetNonItemIESchedNPurposeCodes
        /// </summary>
        /// <returns></returns>
        public IList<PurposeCodeContract> GetNonItemIESchedNPurposeCodes()
        {
            IList<PurposeCodeContract> lstPurposeCodeContract = new List<PurposeCodeContract>();
            PurposeCodeContract objPurposeCodeContract;

            var results = objEFSRepository.GetNonItemIESchedNPurposeCodes();

            foreach (var item in results)
            {
                objPurposeCodeContract = new PurposeCodeContract();
                objPurposeCodeContract.PurposeCodeId = item.PurposeCodeId;
                objPurposeCodeContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objPurposeCodeContract.PurposeCodeAbbrev = item.PurposeCodeAbbrev;
                lstPurposeCodeContract.Add(objPurposeCodeContract);
            }

            return lstPurposeCodeContract;
        }
        #endregion GetNonItemIESchedNPurposeCodes

        #region GetFilingTransIEWeeklyLiabIncrData
        /// <summary>
        /// GetFilingTransIEWeeklyLiabIncrData
        /// </summary>
        /// <param name="objFilingTransDataContract"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataContract> GetFilingTransIEWeeklyLiabIncrData(FilingTransDataContract objFilingTransDataContract)
        {
            IList<FilingTransactionDataContract> lstFilingTransactionDataContract = new List<FilingTransactionDataContract>();
            FilingTransactionDataContract objFilingTransactionDataContract;

            FilingTransDataEntity objFilingTransDataEntity = new FilingTransDataEntity();
            objFilingTransDataEntity.FilerId = objFilingTransDataContract.FilerId;
            objFilingTransDataEntity.ReportYearId = objFilingTransDataContract.ReportYearId;
            objFilingTransDataEntity.OfficeTypeId = objFilingTransDataContract.OfficeTypeId;
            objFilingTransDataEntity.ElectionType = objFilingTransDataContract.ElectionType;
            objFilingTransDataEntity.ElectionDateId = objFilingTransDataContract.ElectionDateId;
            objFilingTransDataEntity.FilingDate = objFilingTransDataContract.FilingDate;
            objFilingTransDataEntity.MunicipalityID = objFilingTransDataContract.MunicipalityID;

            var results = objEFSRepository.GetFilingTransIEWeeklyLiabIncrData(objFilingTransDataEntity);

            foreach (var item in results)
            {
                objFilingTransactionDataContract = new FilingTransactionDataContract();
                objFilingTransactionDataContract.FilingTransId = item.FilingTransId;
                objFilingTransactionDataContract.FilingSchedId = item.FilingSchedId;
                objFilingTransactionDataContract.PurposeCodeId = item.PurposeCodeId;
                objFilingTransactionDataContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionDataContract.PaymentTypeId = item.PaymentTypeId;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.SubmissionDate = item.SubmissionDate;
                objFilingTransactionDataContract.SchedDate = item.SchedDate;
                objFilingTransactionDataContract.FilingSchedDesc = item.FilingSchedDesc;
                objFilingTransactionDataContract.FilingEntityId = item.FilingEntityId;
                objFilingTransactionDataContract.FilingEntityName = item.FilingEntityName;
                objFilingTransactionDataContract.FilingFirstName = item.FilingFirstName;
                objFilingTransactionDataContract.FilingMiddleName = item.FilingMiddleName;
                objFilingTransactionDataContract.FilingLastName = item.FilingLastName;
                objFilingTransactionDataContract.FilingStreetNumber = item.FilingStreetNumber;
                objFilingTransactionDataContract.FilingStreetName = item.FilingStreetName;
                objFilingTransactionDataContract.FilingCity = item.FilingCity;
                objFilingTransactionDataContract.FilingState = item.FilingState;
                objFilingTransactionDataContract.FilingZip = item.FilingZip;
                objFilingTransactionDataContract.FilingCountry = item.FilingCountry;
                objFilingTransactionDataContract.PaymentTypeDesc = item.PaymentTypeDesc;
                objFilingTransactionDataContract.PayNumber = item.PayNumber;
                objFilingTransactionDataContract.OriginalAmount = item.OriginalAmount;
                objFilingTransactionDataContract.ReceiptTypeDesc = item.ReceiptTypeDesc;
                objFilingTransactionDataContract.TransferTypeDesc = item.TransferTypeDesc;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.OriginalDate = item.OriginalDate;
                objFilingTransactionDataContract.LoanerCode = item.LoanerCode;
                objFilingTransactionDataContract.ElectionYear = item.ElectionYear;
                objFilingTransactionDataContract.Office = item.Office;
                objFilingTransactionDataContract.District = item.District;
                objFilingTransactionDataContract.TransExplanation = item.TransExplanation;
                objFilingTransactionDataContract.OwedAmount = item.OwedAmount;
                objFilingTransactionDataContract.RItemized = item.RItemized;
                objFilingTransactionDataContract.RAmend = item.RAmend;
                objFilingTransactionDataContract.RStatus = item.RStatus;
                objFilingTransactionDataContract.CountyID = item.CountyID;
                objFilingTransactionDataContract.CountyDesc = item.CountyDesc;
                objFilingTransactionDataContract.MunicipalityID = item.MunicipalityID;
                objFilingTransactionDataContract.MunicipalityDesc = item.MunicipalityDesc;
                objFilingTransactionDataContract.LoanerCodeID = item.LoanerCodeId;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.CreatedDate = item.CreatedDate;
                objFilingTransactionDataContract.TreasurerFirstName = item.TreasurerFirstName;
                objFilingTransactionDataContract.TreasurerLastName = item.TreasurerLastName;
                objFilingTransactionDataContract.TreasurerMiddleName = item.TreasurerMiddleName;
                objFilingTransactionDataContract.TreasurerOccuptaion = item.TreasurerOccuptaion;
                objFilingTransactionDataContract.TreasurerEmployer = item.TreasurerEmployer;
                objFilingTransactionDataContract.TreasurerStreetAddress = item.TreasurerStreetAddress;
                objFilingTransactionDataContract.TreasurerCity = item.TreasurerCity;
                objFilingTransactionDataContract.TreasurerState = item.TreasurerState;
                objFilingTransactionDataContract.TreasurerZip = item.TreasurerZip;
                objFilingTransactionDataContract.ContributorOccupation = item.ContributorOccupation;
                objFilingTransactionDataContract.ContributorEmployer = item.ContributorEmployer;
                objFilingTransactionDataContract.IEDescription = item.IEDescription;
                objFilingTransactionDataContract.CandBallotPropReference = item.CandBallotPropReference;
                objFilingTransactionDataContract.IESupported = item.IESupported;
                objFilingTransactionDataContract.AddrId = item.AddrId;
                objFilingTransactionDataContract.TreasId = item.TreasId;
                objFilingTransactionDataContract.DateIncurredOrgAmtId = item.DateIncurredOrgAmtId;
                objFilingTransactionDataContract.LoanLiablityNumber = item.LoanLiablityNumber;
                objFilingTransactionDataContract.TransNumber = item.TransNumber;
                objFilingTransactionDataContract.TransMapping = item.TransMapping;
                lstFilingTransactionDataContract.Add(objFilingTransactionDataContract);
            }

            return lstFilingTransactionDataContract;
        }
        #endregion GetFilingTransIEWeeklyLiabIncrData

        #region GetFilingTransIEWeeklyLiabIncrHistoryData
        /// <summary>
        /// GetFilingTransIEWeeklyLiabIncrHistoryData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataContract> GetFilingTransIEWeeklyLiabIncrHistoryData(String strTransNumber)
        {
            IList<FilingTransactionDataContract> lstFilingTransactionDataContract = new List<FilingTransactionDataContract>();
            FilingTransactionDataContract objFilingTransactionDataContract;

            var results = objEFSRepository.GetFilingTransIEWeeklyLiabIncrHistoryData(strTransNumber);

            foreach (var item in results)
            {
                objFilingTransactionDataContract = new FilingTransactionDataContract();
                objFilingTransactionDataContract.FilingTransId = item.FilingTransId;
                objFilingTransactionDataContract.FilingSchedId = item.FilingSchedId;
                objFilingTransactionDataContract.PurposeCodeId = item.ContributorTypeId;
                objFilingTransactionDataContract.PurposeCodeDesc = item.PurposeCodeId;
                objFilingTransactionDataContract.ContributionTypeId = item.PurposeCodeDesc;
                objFilingTransactionDataContract.PaymentTypeId = item.PaymentTypeId;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.SubmissionDate = item.SubmissionDate;
                objFilingTransactionDataContract.SchedDate = item.SchedDate;
                objFilingTransactionDataContract.FilingSchedDesc = item.FilingSchedDesc;
                objFilingTransactionDataContract.FilingEntityId = item.FilingEntityId;
                objFilingTransactionDataContract.FilingEntityName = item.FilingEntityName;
                objFilingTransactionDataContract.FilingFirstName = item.FilingFirstName;
                objFilingTransactionDataContract.FilingMiddleName = item.FilingMiddleName;
                objFilingTransactionDataContract.FilingLastName = item.FilingLastName;
                objFilingTransactionDataContract.FilingStreetNumber = item.FilingStreetNumber;
                objFilingTransactionDataContract.FilingStreetName = item.FilingStreetName;
                objFilingTransactionDataContract.FilingCity = item.FilingCity;
                objFilingTransactionDataContract.FilingState = item.FilingState;
                objFilingTransactionDataContract.FilingZip = item.FilingZip;
                objFilingTransactionDataContract.FilingCountry = item.FilingCountry;
                objFilingTransactionDataContract.PaymentTypeDesc = item.PaymentTypeDesc;
                objFilingTransactionDataContract.PayNumber = item.PayNumber;
                objFilingTransactionDataContract.OriginalAmount = item.OriginalAmount;
                objFilingTransactionDataContract.OwedAmount = item.OwedAmount;
                objFilingTransactionDataContract.ReceiptTypeDesc = item.ReceiptTypeDesc;
                objFilingTransactionDataContract.TransferTypeDesc = item.TransferTypeDesc;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.OriginalDate = item.OriginalDate;
                objFilingTransactionDataContract.LoanerCode = item.LoanerCode;
                objFilingTransactionDataContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objFilingTransactionDataContract.ElectionYear = item.ElectionYear;
                objFilingTransactionDataContract.Office = item.Office;
                objFilingTransactionDataContract.District = item.District;
                objFilingTransactionDataContract.RLiability = item.RLiability;
                objFilingTransactionDataContract.RSubcontractor = item.RSubcontractor;
                objFilingTransactionDataContract.TransExplanation = item.TransExplanation;
                objFilingTransactionDataContract.OwedAmount = item.OwedAmount;
                objFilingTransactionDataContract.RItemized = item.RItemized;
                objFilingTransactionDataContract.RAmend = item.RAmend;
                objFilingTransactionDataContract.RStatus = item.RStatus;
                objFilingTransactionDataContract.CountyID = item.CountyID;
                objFilingTransactionDataContract.CountyDesc = item.CountyDesc;
                objFilingTransactionDataContract.MunicipalityID = item.MunicipalityID;
                objFilingTransactionDataContract.MunicipalityDesc = item.MunicipalityDesc;
                objFilingTransactionDataContract.LoanerCodeID = item.LoanerCodeId;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeDesc;
                objFilingTransactionDataContract.CreatedDate = item.CreatedDate;
                objFilingTransactionDataContract.TreasurerFirstName = item.TreasurerFirstName;
                objFilingTransactionDataContract.TreasurerLastName = item.TreasurerLastName;
                objFilingTransactionDataContract.TreasurerMiddleName = item.TreasurerMiddleName;
                objFilingTransactionDataContract.TreasurerOccuptaion = item.TreasurerOccuptaion;
                objFilingTransactionDataContract.TreasurerEmployer = item.TreasurerEmployer;
                objFilingTransactionDataContract.TreasurerStreetAddress = item.TreasurerStreetAddress;
                objFilingTransactionDataContract.TreasurerCity = item.TreasurerCity;
                objFilingTransactionDataContract.TreasurerState = item.TreasurerState;
                objFilingTransactionDataContract.TreasurerZip = item.TreasurerZip;
                objFilingTransactionDataContract.ContributorOccupation = item.ContributorOccupation;
                objFilingTransactionDataContract.ContributorEmployer = item.ContributorEmployer;
                objFilingTransactionDataContract.CandBallotPropReference = item.CandBallotPropReference;
                objFilingTransactionDataContract.IEDescription = item.IEDescription;
                objFilingTransactionDataContract.IESupported = item.IESupported;
                objFilingTransactionDataContract.LoanLiablityNumber = item.LoanLiablityNumber;
                objFilingTransactionDataContract.TransNumber = item.TransNumber;
                objFilingTransactionDataContract.TransMapping = item.TransMapping;
                lstFilingTransactionDataContract.Add(objFilingTransactionDataContract);
            }

            return lstFilingTransactionDataContract;
        }
        #endregion GetFilingTransIEWeeklyLiabIncrHistoryData

        #region AddNonItemIEWeeklyLiabIncrFlngTrans
        /// <summary>
        /// AddNonItemIEWeeklyLiabIncrFlngTrans
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean AddNonItemIEWeeklyLiabIncrFlngTrans(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.PersonId = objFilingTransactionsContract.PersonId;
            objFilingTransactionsEntity.TreasId = objFilingTransactionsContract.TreasId;
            objFilingTransactionsEntity.AddrId = objFilingTransactionsContract.AddrId;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.PurposeCodeId = objFilingTransactionsContract.PurposeCodeId;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.OwedAmt = objFilingTransactionsContract.OwedAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.MunicipalityID = objFilingTransactionsContract.MunicipalityID;
            objFilingTransactionsEntity.RAmend = objFilingTransactionsContract.RAmend;
            objFilingTransactionsEntity.ElectionDate = objFilingTransactionsContract.ElectionDate;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.ElectionYear = objFilingTransactionsContract.ElectionYear;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.TreasurerOccupation = objFilingTransactionsContract.TreasurerOccupation;
            objFilingTransactionsEntity.TreasurerEmployer = objFilingTransactionsContract.TreasurerEmployer;
            objFilingTransactionsEntity.ContributorOccupation = objFilingTransactionsContract.ContributorOccupation;
            objFilingTransactionsEntity.ContributorEmployer = objFilingTransactionsContract.ContributorEmployer;
            objFilingTransactionsEntity.TreasurerStreetAddress = objFilingTransactionsContract.TreasurerStreetAddress;
            objFilingTransactionsEntity.TreasurerCity = objFilingTransactionsContract.TreasurerCity;
            objFilingTransactionsEntity.TreasurerState = objFilingTransactionsContract.TreasurerState;
            objFilingTransactionsEntity.TreasurerZip = objFilingTransactionsContract.TreasurerZip;
            objFilingTransactionsEntity.CandBallotPropReference = objFilingTransactionsContract.CandBallotPropReference;
            objFilingTransactionsEntity.IEDescription = objFilingTransactionsContract.IEDescription;
            objFilingTransactionsEntity.R_Supported = objFilingTransactionsContract.R_Supported;
            objFilingTransactionsEntity.DateIncurredOrgAmtId = objFilingTransactionsContract.DateIncurredOrgAmtId;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;

            Boolean returnValue = objEFSRepository.AddNonItemIEWeeklyLiabIncrFlngTrans(objFilingTransactionsEntity);

            return returnValue;
        }
        #endregion AddNonItemIEWeeklyLiabIncrFlngTrans

        #region UpdateIEWeeklyLiabIncrFlngTrans
        /// <summary>
        /// UpdateIEWeeklyLiabIncrFlngTrans
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean UpdateIEWeeklyLiabIncrFlngTrans(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.TransNumber = objFilingTransactionsContract.TransNumber;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.TreasId = objFilingTransactionsContract.TreasId;
            objFilingTransactionsEntity.AddrId = objFilingTransactionsContract.AddrId;
            objFilingTransactionsEntity.PersonId = objFilingTransactionsContract.PersonId;
            objFilingTransactionsEntity.SubmissionDate = objFilingTransactionsContract.SubmissionDate;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.PurposeCodeId = objFilingTransactionsContract.PurposeCodeId;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.OwedAmt = objFilingTransactionsContract.OwedAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.TreasurerStreetAddress = objFilingTransactionsContract.TreasurerStreetAddress;
            objFilingTransactionsEntity.TreasurerCity = objFilingTransactionsContract.TreasurerCity;
            objFilingTransactionsEntity.TreasurerState = objFilingTransactionsContract.TreasurerState;
            objFilingTransactionsEntity.TreasurerZip = objFilingTransactionsContract.TreasurerZip;
            objFilingTransactionsEntity.IEDescription = objFilingTransactionsContract.IEDescription;
            objFilingTransactionsEntity.TreasurerOccupation = objFilingTransactionsContract.TreasurerOccupation;
            objFilingTransactionsEntity.TreasurerEmployer = objFilingTransactionsContract.TreasurerEmployer;
            objFilingTransactionsEntity.ContributorOccupation = objFilingTransactionsContract.ContributorOccupation;
            objFilingTransactionsEntity.ContributorEmployer = objFilingTransactionsContract.ContributorEmployer;
            objFilingTransactionsEntity.R_Supported = objFilingTransactionsContract.R_Supported;
            objFilingTransactionsEntity.CandBallotPropReference = objFilingTransactionsContract.CandBallotPropReference;
            objFilingTransactionsEntity.ModifiedBy = objFilingTransactionsContract.ModifiedBy;

            Boolean returnValue = objEFSRepository.UpdateIEWeeklyLiabIncrFlngTrans(objFilingTransactionsEntity);

            return returnValue;
        }
        #endregion UpdateIEWeeklyLiabIncrFlngTrans

        #region GetFilingMethodData
        /// <summary>
        /// GetFilingMethodData
        /// </summary>
        /// <returns></returns>
        public IList<FilingMthodContract> GetFilingMethodData()
        {
            IList<FilingMthodContract> lstFilingMthodContract = new List<FilingMthodContract>();
            FilingMthodContract objFilingMthodContract;

            var results = objEFSRepository.GetFilingMethodData();

            foreach (var item in results)
            {
                objFilingMthodContract = new FilingMthodContract();
                objFilingMthodContract.FilingMethodId = item.FilingMethodId;
                objFilingMthodContract.FilingMethodDesc = item.FilingMethodDesc;
                lstFilingMthodContract.Add(objFilingMthodContract);
            }

            return lstFilingMthodContract;
        }
        #endregion GetFilingMethodData

        #region GetCampaignMaterialData
        /// <summary>
        /// GetCampaignMaterialData
        /// </summary>
        /// <param name="objNonItemCampaignMaterialContract"></param>
        /// <returns></returns>
        public IList<NonItemCampaignMaterialDataContract> GetCampaignMaterialData(NonItemCampaignMaterialContract objNonItemCampaignMaterialContract)
        {
            IList<NonItemCampaignMaterialDataContract> lstNonItemCampaignMaterialDataContract = new List<NonItemCampaignMaterialDataContract>();
            NonItemCampaignMaterialDataContract objNonItemCampaignMaterialDataContract;

            NonItemCampaignMaterialEntity objNonItemCampaignMaterialEntity = new NonItemCampaignMaterialEntity();

            objNonItemCampaignMaterialEntity.FilerId = objNonItemCampaignMaterialContract.FilerId;
            objNonItemCampaignMaterialEntity.ElectionDate = objNonItemCampaignMaterialContract.ElectionDate;
            objNonItemCampaignMaterialEntity.ElectYearId = objNonItemCampaignMaterialContract.ElectYearId;
            objNonItemCampaignMaterialEntity.ElectionYear = objNonItemCampaignMaterialContract.ElectionYear;
            objNonItemCampaignMaterialEntity.ElectionTypeId = objNonItemCampaignMaterialContract.ElectionTypeId;
            objNonItemCampaignMaterialEntity.OfficeTypeId = objNonItemCampaignMaterialContract.OfficeTypeId;
            objNonItemCampaignMaterialEntity.FilingTypeId = objNonItemCampaignMaterialContract.FilingTypeId;
            objNonItemCampaignMaterialEntity.ElectionDateId = objNonItemCampaignMaterialContract.ElectionDateId;
            objNonItemCampaignMaterialEntity.FilingDate = objNonItemCampaignMaterialContract.FilingDate;

            var results = objEFSRepository.GetCampaignMaterialData(objNonItemCampaignMaterialEntity);

            foreach (var item in results)
            {
                objNonItemCampaignMaterialDataContract = new NonItemCampaignMaterialDataContract();
                objNonItemCampaignMaterialDataContract.CampaignMaterialId = item.CampaignMaterialId;
                objNonItemCampaignMaterialDataContract.FilingMethodId = item.FilingMethodId;
                objNonItemCampaignMaterialDataContract.SacnDocId = item.SacnDocId;
                objNonItemCampaignMaterialDataContract.DateSubmitted = item.DateSubmitted;
                objNonItemCampaignMaterialDataContract.CampaignMaterialDesc = item.CampaignMaterialDesc;
                objNonItemCampaignMaterialDataContract.FilingMethodDesc = item.FilingMethodDesc;
                objNonItemCampaignMaterialDataContract.CampMatrFileType = item.CampMatrFileType;
                objNonItemCampaignMaterialDataContract.CampMatrFileSize = item.CampMatrFileSize;
                objNonItemCampaignMaterialDataContract.RCampMatr = item.RCampMatr;
                objNonItemCampaignMaterialDataContract.CreatedDate = item.CreatedDate;
                objNonItemCampaignMaterialDataContract.RAmended = item.RAmended;
                lstNonItemCampaignMaterialDataContract.Add(objNonItemCampaignMaterialDataContract);
            }

            return lstNonItemCampaignMaterialDataContract;
        }
        #endregion GetCampaignMaterialData

        #region AddNonItemCampaignMaterial
        /// <summary>
        /// AddNonItemCampaignMaterial
        /// </summary>
        /// <param name="objNonItemCampaignMaterialContract"></param>
        /// <returns></returns>
        public Boolean AddNonItemCampaignMaterial(NonItemCampaignMaterialContract objNonItemCampaignMaterialContract)
        {
            NonItemCampaignMaterialEntity objNonItemCampaignMaterialEntity = new NonItemCampaignMaterialEntity();
            objNonItemCampaignMaterialEntity.FilerId = objNonItemCampaignMaterialContract.FilerId;
            objNonItemCampaignMaterialEntity.ElectionDate = objNonItemCampaignMaterialContract.ElectionDate;
            objNonItemCampaignMaterialEntity.ElectionDateId = objNonItemCampaignMaterialContract.ElectionDateId;
            objNonItemCampaignMaterialEntity.ElectionTypeId = objNonItemCampaignMaterialContract.ElectionTypeId;
            objNonItemCampaignMaterialEntity.OfficeTypeId = objNonItemCampaignMaterialContract.OfficeTypeId;
            objNonItemCampaignMaterialEntity.FilingTypeId = objNonItemCampaignMaterialContract.FilingTypeId;
            objNonItemCampaignMaterialEntity.FilingCategoryId = objNonItemCampaignMaterialContract.FilingCategoryId;
            objNonItemCampaignMaterialEntity.ElectYearId = objNonItemCampaignMaterialContract.ElectYearId;
            objNonItemCampaignMaterialEntity.ElectionYear = objNonItemCampaignMaterialContract.ElectionYear;
            objNonItemCampaignMaterialEntity.CountyId = objNonItemCampaignMaterialContract.CountyId;
            objNonItemCampaignMaterialEntity.MunicipalityId = objNonItemCampaignMaterialContract.MunicipalityId;
            objNonItemCampaignMaterialEntity.DateSubmitted = objNonItemCampaignMaterialContract.DateSubmitted;
            objNonItemCampaignMaterialEntity.FilingMethodId = objNonItemCampaignMaterialContract.FilingMethodId;
            objNonItemCampaignMaterialEntity.CampaignMaterialDesc = objNonItemCampaignMaterialContract.CampaignMaterialDesc;
            objNonItemCampaignMaterialEntity.CampMatrFileType = objNonItemCampaignMaterialContract.CampMatrFileType;
            objNonItemCampaignMaterialEntity.CampMatrFileSize = objNonItemCampaignMaterialContract.CampMatrFileSize;
            objNonItemCampaignMaterialEntity.SacnDocId = objNonItemCampaignMaterialContract.SacnDocId;
            objNonItemCampaignMaterialEntity.RCampMatr = objNonItemCampaignMaterialContract.RCampMatr;
            objNonItemCampaignMaterialEntity.CreatedBy = objNonItemCampaignMaterialContract.CreatedBy;
            objNonItemCampaignMaterialEntity.FilingDate = objNonItemCampaignMaterialContract.FilingDate;

            var returnValue = objEFSRepository.AddNonItemCampaignMaterial(objNonItemCampaignMaterialEntity);

            return returnValue;
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
            Boolean returnValue = objEFSRepository.DeleteCampaignMaterial(strCampMatrId, strModifiedBy);

            return returnValue;
        }
        #endregion DeleteCampaignMaterial
        
        //============CABINET CODE=========CAMPAIGN MATERIAL=====CABINET CODE==============
        
        #region Get Token ID
        /// <summary>
        /// Get Token ID - GET DOCUMENT ID AND UPLOAD FILE INTO CABINET.
        /// </summary>
        /// <param name="CabinetOpenAPIURL"></param>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <param name="ConnectTo"></param>
        /// <returns></returns>        
        public async Task<PIDAReturnVal> GetTokenID(DocumentIDContract objDocumentIDContract) 
        {
            // Convert Byte Array to Stream
            Stream varStream = new MemoryStream(objDocumentIDContract.fileBytes);

            CancellationToken CancelToken = new CancellationToken();
            CabPCL.clsSession classSession = new CabPCL.clsSession();
            PIDAReturnVal pIDAReturnVal = new PIDAReturnVal();

            SessionModel response = await classSession.LoginAsync(System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString(),
                                          CancelToken, System.Configuration.ConfigurationManager.AppSettings["APIUserName"].ToString(),
                                          System.Configuration.ConfigurationManager.AppSettings["APIPassword"].ToString(),
                                          System.Configuration.ConfigurationManager.AppSettings["ConnectTo"].ToString());
            if (response.Info == "success")
            {
                pIDAReturnVal.TokenID = response.Token.ToString();

                //Get Repository List
                RepositoryModel[] resRepositoryID = await GetRepositories(System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString(), response.Token.ToString());
                foreach (var item in resRepositoryID)
                {
                    if(objDocumentIDContract.PageName=="CampaignMaterials")
                    {
                        if (item.Name.ToUpper() == System.Configuration.ConfigurationManager.AppSettings["CFMRepositoryId"].ToString())
                        {
                            pIDAReturnVal.RepositoryID = item.RepositoryID.ToString();
                            break;
                        }
                    }
                    else if(objDocumentIDContract.PageName == "SupportingDocuments")
                    {
                        if (item.Name.ToUpper() == System.Configuration.ConfigurationManager.AppSettings["CFMSupDocRepositoryId"].ToString())
                        {
                            pIDAReturnVal.RepositoryID = item.RepositoryID.ToString();
                            break;
                        }
                    }                    
                }

                //Get Cabinet ID
                List<CabinetModel> rescabinetID = await GetCabinets(System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString(), response.Token.ToString(), pIDAReturnVal.RepositoryID.ToString());
                foreach (var item in rescabinetID)
                {
                    if (objDocumentIDContract.PageName == "CampaignMaterials")
                    {
                        if (item.Name == System.Configuration.ConfigurationManager.AppSettings["CFMCabinetName"].ToString())
                        {
                            pIDAReturnVal.CabinetID = item.CabinetID.ToString();
                            //CFM cabinet ID is 10
                        }
                    }
                    else if (objDocumentIDContract.PageName == "SupportingDocuments")
                    {
                        if (item.Name.ToUpper() == System.Configuration.ConfigurationManager.AppSettings["CFMSupDocCabinetName"].ToString())
                        {
                            pIDAReturnVal.CabinetID = item.CabinetID.ToString();
                            //CFM cabinet ID is 10
                        }
                    }
                }

                //Get Extension ID
                List<ExtensionModel> extensionModels = await GetExtensions(System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString(), response.Token.ToString(), pIDAReturnVal.RepositoryID.ToString());
                foreach (var item in extensionModels)
                {
                    if (objDocumentIDContract.FileExtension == "PDF")
                    {
                        if (item.Name == "Adobe")
                        {
                            pIDAReturnVal.ManagerID = item.ManagerID.ToString();
                            pIDAReturnVal.ExtensionID = item.ExtensionID.ToString();
                            pIDAReturnVal.ExtensionName = item.Extension.ToString();
                        }
                    }
                    else if (objDocumentIDContract.FileExtension == "PNG")
                    {
                        if (item.Extension == "PNG")
                        {
                            pIDAReturnVal.ManagerID = item.ManagerID.ToString();
                            pIDAReturnVal.ExtensionID = item.ExtensionID.ToString();
                            pIDAReturnVal.ExtensionName = item.Extension.ToString();
                        }
                    }
                    else if (objDocumentIDContract.FileExtension == "DOC")
                    {
                        if (item.Extension == "DOC")
                        {
                            pIDAReturnVal.ManagerID = item.ManagerID.ToString();
                            pIDAReturnVal.ExtensionID = item.ExtensionID.ToString();
                            pIDAReturnVal.ExtensionName = item.Extension.ToString();
                        }
                    }
                    else if (objDocumentIDContract.FileExtension == "DOCX")
                    {
                        if (item.Extension == "DOCX")
                        {
                            pIDAReturnVal.ManagerID = item.ManagerID.ToString();
                            pIDAReturnVal.ExtensionID = item.ExtensionID.ToString();
                            pIDAReturnVal.ExtensionName = item.Extension.ToString();
                        }
                    }
                    else if (objDocumentIDContract.FileExtension == "JPG" || objDocumentIDContract.FileExtension == "JPEG")
                    {
                        if (item.Extension == "JPG")
                        {
                            pIDAReturnVal.ManagerID = item.ManagerID.ToString();
                            pIDAReturnVal.ExtensionID = item.ExtensionID.ToString();
                            pIDAReturnVal.ExtensionName = item.Extension.ToString();
                        }
                    }
                }

                //Tab ID
                TabModel[] tabModels = await GetTabs(System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString(), response.Token.ToString(), pIDAReturnVal.CabinetID.ToString());
                foreach (var item in tabModels)
                {
                    if (item.Name == "Miscellaneous")
                    {
                        pIDAReturnVal.TabID = item.TabID.ToString();
                    }
                }

                //Template ID
                TemplateModel.Document templateID = await GetTemplate(System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString(), response.Token.ToString(), pIDAReturnVal.CabinetID.ToString());
                foreach (var item in templateID.Templates)
                {
                    pIDAReturnVal.TemplateID = item.TemplateID.ToString();
                }

                // Create Folder - FilerID + ElectionYear + FilingType
                //objDocumentIDContract.FolderFilerId = objDocumentIDContract.FolderFilerId + "-" + objDocumentIDContract.FolderElectionYear + "-" + objDocumentIDContract.FolderDisclosurePeriod;

                // Check folder exists or not in Cabinet if existing directly place the file...
                // if not exists then create folder and place the file.
                // Folder Structure 
                // Campaign Material/FilerId/ElectionYear/DisclosurePeriod/Place the file.
                // Ex. Campaign Material/113070/2014/11-Day Pre-Primary/CampaignMaterial20140918094444.PDF
                bool flag = true;
                List<FolderModel> folderModel = await GetFolder(System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString(), pIDAReturnVal.TokenID.ToString(), pIDAReturnVal.CabinetID.ToString());
                foreach (var item in folderModel)
                {
                    if (objDocumentIDContract.PageName == "CampaignMaterials")
                    {
                        string[] getValue = item.Indexes[1].Split("|".ToCharArray());
                        if (getValue[1].ToString() == objDocumentIDContract.FolderFilerId.ToString())
                        {
                            flag = false;
                            pIDAReturnVal.FolderID = item.FolderID.ToString();
                            break;
                        }
                    }
                    else if (objDocumentIDContract.PageName == "SupportingDocuments")
                    {
                        string[] getValue = item.Indexes[0].Split("|".ToCharArray());
                        if (getValue[1].ToString() == objDocumentIDContract.FolderFilerId.ToString())
                        {
                            flag = false;
                            pIDAReturnVal.FolderID = item.FolderID.ToString();
                            break;
                        }
                    }
                }
                
                if (flag == true)
                {
                    //Create Folder
                    int FolderID = await CreateFolder(System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString(), pIDAReturnVal.TokenID.ToString(), pIDAReturnVal.CabinetID.ToString(), objDocumentIDContract.FolderFilerId, objDocumentIDContract.PageName);
                    pIDAReturnVal.FolderID = FolderID.ToString();
                }

                string Keywords = "";
                int DocuntID = await this.FileDocument(Int32.Parse(pIDAReturnVal.CabinetID.ToString()),
                                                     Int32.Parse(pIDAReturnVal.FolderID.ToString()),
                                                     Int32.Parse(pIDAReturnVal.TabID.ToString()),
                                                     Int32.Parse(pIDAReturnVal.ManagerID.ToString()),
                                                     Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["ParentID"].ToString()),
                                                     Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["SecurityID"].ToString()),
                                                     Int32.Parse(pIDAReturnVal.TemplateID.ToString()),
                                                     Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["RetentionID"].ToString()),
                                                     objDocumentIDContract.strCampMatrFileName,
                                                     pIDAReturnVal.ExtensionName.ToString(),
                                                     Int32.Parse(pIDAReturnVal.ExtensionID.ToString()),
                                                     objDocumentIDContract.strCampMatrFileName,
                                                     objDocumentIDContract.strCampMatrFileName,                                                    
                                                     varStream,
                                                     pIDAReturnVal.TokenID.ToString());

                pIDAReturnVal.DocumentID = DocuntID.ToString();

                CabPCL.clsDocument clsDocument = new CabPCL.clsDocument();
                CancellationToken CancelTokenData = new CancellationToken();
                DocumentInfoModel documentInfoModel = await clsDocument.GetDocumentInfoAsync(System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString(), pIDAReturnVal.TokenID.ToString(), CancelTokenData, Int32.Parse(pIDAReturnVal.CabinetID.ToString()), Int32.Parse(pIDAReturnVal.DocumentID)); pIDAReturnVal.Extension = documentInfoModel.Info[0].Extension.ToString();
                pIDAReturnVal.FormattedFileSize = documentInfoModel.Info[0].FormattedFileSize.ToString();
                pIDAReturnVal.Keyword = documentInfoModel.Keywords[0].Keyword.ToString();

            }
            return pIDAReturnVal;
        }
        #endregion Get Token ID

        #region COMMON CABITNET CODE DON'T REMOVE.

        #region Get Repositories
        /// <summary>
        /// GetRepositories
        /// </summary>
        /// <param name="CabinetOpenAPIURL"></param>
        /// <param name="CabinetToken"></param>
        /// <returns></returns>
        public async Task<RepositoryModel[]> GetRepositories(string CabinetOpenAPIURL, string CabinetToken)
        {
            CancellationToken CancelToken = new CancellationToken();
            CabPCL.clsCabinet classCabinet = new CabPCL.clsCabinet();
            return await classCabinet.GetRepositoriesAsync(CabinetOpenAPIURL, CabinetToken, CancelToken);
        }
        #endregion Get Repositories

        #region Get Cabinets
        /// <summary>
        /// GetCabinets
        /// </summary>
        /// <param name="CabinetOpenAPIURL"></param>
        /// <param name="CabinetToken"></param>
        /// <param name="repositoryID"></param>
        /// <returns></returns>
        public async Task<List<CabinetModel>> GetCabinets(string CabinetOpenAPIURL, string CabinetToken, string repositoryID)
        {
            CancellationToken CancelToken = new CancellationToken();
            CabPCL.clsCabinet classCabinet = new CabPCL.clsCabinet();
            return await classCabinet.GetCabinetsAsync(CabinetOpenAPIURL, CabinetToken, CancelToken, Int32.Parse(repositoryID));
        }
        #endregion Get Cabinets

        #region Get Manager
        /// <summary>
        /// GetManager
        /// </summary>
        /// <param name="CabinetOpenAPIURL"></param>
        /// <param name="CabinetToken"></param>
        /// <param name="repositoryID"></param>
        /// <returns></returns>
        public async Task<List<ManagerModel>> GetManager(string CabinetOpenAPIURL, string CabinetToken, string repositoryID)
        {
            CancellationToken CancelToken = new CancellationToken();
            CabPCL.clsManagers clsManagers = new CabPCL.clsManagers();
            return await clsManagers.GetManagersAsync(CabinetOpenAPIURL, CabinetToken, CancelToken);
        }
        #endregion Get Manager

        #region Get Extensions
        /// <summary>
        /// GetExtensions
        /// </summary>
        /// <param name="CabinetOpenAPIURL"></param>
        /// <param name="CabinetToken"></param>
        /// <param name="repositoryID"></param>
        /// <returns></returns>
        public async Task<List<ExtensionModel>> GetExtensions(string CabinetOpenAPIURL, string CabinetToken, string repositoryID)
        {
            CancellationToken CancelToken = new CancellationToken();
            CabPCL.clsManagers clsManagers = new CabPCL.clsManagers();
            return await clsManagers.GetExtensionsAsync(CabinetOpenAPIURL, CabinetToken, CancelToken);
        }
        #endregion Get Extensions

        #region Get Tabs
        /// <summary>
        /// GetTabs
        /// </summary>
        /// <param name="CabinetOpenAPIURL"></param>
        /// <param name="CabinetToken"></param>
        /// <param name="cabinetID"></param>
        /// <returns></returns>
        public async Task<TabModel[]> GetTabs(string CabinetOpenAPIURL, string CabinetToken, string cabinetID)
        {
            CancellationToken CancelToken = new CancellationToken();
            CabPCL.clsTab clsTab = new CabPCL.clsTab();
            return await clsTab.GetTabsAsync(CabinetOpenAPIURL, CabinetToken, CancelToken, Int32.Parse(cabinetID));
        }
        #endregion Get Tabs

        #region Get Folder
        /// <summary>
        /// GetFolder
        /// </summary>
        /// <param name="CabinetOpenAPIURL"></param>
        /// <param name="CabinetToken"></param>
        /// <param name="cabinetID"></param>
        /// <returns></returns>
        public async Task<List<FolderModel>> GetFolder(string CabinetOpenAPIURL, string CabinetToken, string cabinetID)
        {
            CancellationToken CancelToken = new CancellationToken();
            CabPCL.clsFolder clsFolder = new CabPCL.clsFolder();
            return await clsFolder.GetFoldersAsync(CabinetOpenAPIURL, CabinetToken, CancelToken, Int32.Parse(cabinetID));
        }
        #endregion Get Folder

        #region Get Template
        /// <summary>
        /// GetTemplate
        /// </summary>
        /// <param name="CabinetOpenAPIURL"></param>
        /// <param name="CabinetToken"></param>
        /// <param name="cabinetID"></param>
        /// <returns></returns>
        public async Task<TemplateModel.Document> GetTemplate(string CabinetOpenAPIURL, string CabinetToken, string cabinetID)
        {
            CancellationToken CancelToken = new CancellationToken();
            CabPCL.clsTemplate clsTemplate = new CabPCL.clsTemplate();
            return await clsTemplate.GetTemplatesAsync(CabinetOpenAPIURL, CabinetToken, CancelToken, Int32.Parse(cabinetID), true);
        }
        #endregion Get Template

        #region Get Cabinet Indexes
        /// <summary>
        /// GetCabinetIndexes
        /// </summary>
        /// <param name="CabinetOpenAPIURL"></param>
        /// <param name="CabinetToken"></param>
        /// <param name="CancelToken"></param>
        /// <param name="CabinetID"></param>
        /// <returns></returns>
        public async Task<List<IndiciesModel>> GetCabinetIndexes(string CabinetOpenAPIURL, string CabinetToken,
            CancellationToken CancelToken, int CabinetID)
        {
            //Get the Indexes for a Cabinet                
            CabPCL.clsIndex clsIndex = new CabPCL.clsIndex();
            return await clsIndex.GetIndiciesAsync(CabinetOpenAPIURL, CabinetToken, CancelToken, CabinetID);

        }
        #endregion Get Cabinet Indexes

        #region Document Download
        /// <summary>
        /// DocumentDownload
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="CabinetID"></param>
        /// <param name="DocumentID"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task<PIDADownloadObject> DocumentDownload(string Token, int CabinetID, int DocumentID, string fileName)
        {
            PIDADownloadObject pIDADownloadObject = new PIDADownloadObject();

            System.IO.Stream DocumentStream = await DownloadDocument(CabinetID, DocumentID, Token);

            if (DocumentStream == null)
            {
                throw new Exception("Add some info for user here that we have an issue....");
            }

            // Get the File Name from Cabinet.
            CabPCL.clsDocument clsDocument = new CabPCL.clsDocument();
            CancellationToken CancelTokenData = new CancellationToken();
            DocumentInfoModel documentInfoModel = await clsDocument.GetDocumentInfoAsync(System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString(), Token, CancelTokenData, CabinetID, DocumentID);
            pIDADownloadObject.FileName = documentInfoModel.Info[0].DocumentTitle.ToString();
            
            byte[] DocumentByteArray = ToByteArray(DocumentStream);
            pIDADownloadObject.FileByte = DocumentByteArray;
            return pIDADownloadObject;
        }
        #endregion Document Download

        #region To Get Byte Array
        /// <summary>
        /// ToByteArray
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private static byte[] ToByteArray(System.IO.Stream stream)
        {
            stream.Position = 0;
            byte[] buffer = new byte[stream.Length];
            for (int totalBytesCopied = 0; totalBytesCopied < stream.Length;)
                totalBytesCopied += stream.Read(buffer, totalBytesCopied, Convert.ToInt32(stream.Length) - totalBytesCopied);
            return buffer;
        }
        #endregion To Get Byte Array

        #region Get Document Info
        /// <summary>
        /// GetDocumentInfo
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="CancelToken"></param>
        /// <param name="CabinetID"></param>
        /// <param name="DocumentID"></param>
        /// <returns></returns>
        public async Task<List<DocumentInfoModel.DocumentInformationModel>> GetDocumentInfo(string Token, CancellationToken CancelToken, int CabinetID, int DocumentID)
        {
            CabPCL.clsDocument c = new CabPCL.clsDocument();
            DocumentInfoModel DocumentInfoModel = await c.GetDocumentInfoAsync(System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString(), Token, CancelToken, CabinetID, DocumentID);
            List<DocumentInfoModel.DocumentInformationModel> DocumentInformationModels = DocumentInfoModel.Info;

            return DocumentInformationModels;
        }
        #endregion Get Document Info

        #region Download Document
        /// <summary>
        /// DownloadDocument
        /// </summary>
        /// <param name="CabinetID"></param>
        /// <param name="DocumentID"></param>
        /// <param name="TokenID"></param>
        /// <returns></returns>
        private async Task<System.IO.Stream> DownloadDocument(int CabinetID, int DocumentID, String TokenID)
        {

            CancellationToken CancelToken = new CancellationToken();
            CabPCL.clsDocument c = new CabPCL.clsDocument();
            

            DocumentModel DocumentModel = new DocumentModel
            {
                CabinetID = CabinetID,
                DocumentID = DocumentID
            };

            CabPCL.clsDocument.ProgressCallback ProgressCallback = new CabPCL.clsDocument.ProgressCallback(UpdateProgress);

            Stream DocumentStream = await c.DownloadDocumentAsync(System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString(), TokenID, CancelToken, DocumentModel, ProgressCallback);

            return DocumentStream;
        }
        #endregion Download Document

        #region Get Document Data
        /// <summary>
        /// GetDocumentData 
        /// </summary>
        /// <param name="CabinetOpenAPIURL"></param>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <param name="ConnectTo"></param>
        /// <param name="IE_Comm_Doc_ID"></param>
        /// <param name="cabinetFolderName"></param>
        /// <returns></returns>
        public async Task<DocumentInfoData> GetDocumentData(string IE_Comm_Doc_ID, string cabinetFolderName)
        {

            CancellationToken CancelToken = new CancellationToken();
            CabPCL.clsSession classSession = new CabPCL.clsSession();
            PIDAReturnVal pIDAReturnVal = new PIDAReturnVal();
            DocumentInfoData documentInfoData = new DocumentInfoData();
            SessionModel response = await classSession.LoginAsync(System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString(),
                                                                    CancelToken, System.Configuration.ConfigurationManager.AppSettings["APIUserName"].ToString(),
                                                                    System.Configuration.ConfigurationManager.AppSettings["APIPassword"].ToString(),
                                                                    System.Configuration.ConfigurationManager.AppSettings["ConnectTo"].ToString());
            if (response.Info == "success")
            {
                pIDAReturnVal.TokenID = response.Token.ToString();

                //Get Repository List
                RepositoryModel[] resRepositoryID = await GetRepositories(System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString(), response.Token.ToString());
                foreach (var item in resRepositoryID)
                {
                    pIDAReturnVal.RepositoryID = item.RepositoryID.ToString();
                }

                //Get Cabinet ID
                List<CabinetModel> rescabinetID = await GetCabinets(System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString(), response.Token.ToString(), pIDAReturnVal.RepositoryID.ToString());
                foreach (var item in rescabinetID)
                {
                    if (item.Name == cabinetFolderName)
                    {
                        pIDAReturnVal.CabinetID = item.CabinetID.ToString();
                        break;
                    }
                }

                //Get Extension ID
                List<ExtensionModel> extensionModels = await GetExtensions(System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString(), response.Token.ToString(), pIDAReturnVal.RepositoryID.ToString());
                foreach (var item in extensionModels)
                {
                    if (item.Name == "Adobe")
                    {
                        pIDAReturnVal.ManagerID = item.ManagerID.ToString();
                        pIDAReturnVal.ExtensionID = item.ExtensionID.ToString();
                        pIDAReturnVal.ExtensionName = item.Extension.ToString();
                    }
                }

                //Tab ID
                TabModel[] tabModels = await GetTabs(System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString(), response.Token.ToString(), pIDAReturnVal.CabinetID.ToString());
                foreach (var item in tabModels)
                {
                    if (item.Name == "Miscellaneous")
                    {
                        pIDAReturnVal.TabID = item.TabID.ToString();
                    }
                }

                //Template ID
                TemplateModel.Document templateID = await GetTemplate(System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString(), response.Token.ToString(), pIDAReturnVal.CabinetID.ToString());
                foreach (var item in templateID.Templates)
                {
                    pIDAReturnVal.TemplateID = item.TemplateID.ToString();
                }

                CabPCL.clsDocument clsDocument = new CabPCL.clsDocument();
                CancellationToken CancelTokenData = new CancellationToken();
                DocumentInfoModel documentInfoModel = await clsDocument.GetDocumentInfoAsync(System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString(),
                                                    pIDAReturnVal.TokenID.ToString(),
                                                    CancelTokenData,
                                                    Int32.Parse(pIDAReturnVal.CabinetID.ToString()),
                                                    Int32.Parse(IE_Comm_Doc_ID));
                documentInfoData.Extension = documentInfoModel.Info[0].Extension.ToString();
                documentInfoData.FormattedFileSize = documentInfoModel.Info[0].FormattedFileSize.ToString();
                documentInfoData.Keyword = documentInfoModel.Keywords[0].Keyword.ToString();                
            }
            return documentInfoData;
        }
        #endregion Get Document Data

        private static void UpdateProgress(long V1, long V2)
        {
        }

        #region GetTokenIDData
        // Get Document ID for Download Document from CABINET.
        /// <summary>
        /// Get Token ID Data
        /// </summary>
        /// <param name="CabinetOpenAPIURL"></param>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <param name="ConnectTo"></param>
        /// <returns></returns>        
        public async Task<PIDAReturnVal> GetTokenIDData(String strFileType, String strPageName)
        {
            CancellationToken CancelToken = new CancellationToken();
            CabPCL.clsSession classSession = new CabPCL.clsSession();
            PIDAReturnVal pIDAReturnVal = new PIDAReturnVal();

            SessionModel response = await classSession.LoginAsync(System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString(),
                                                                    CancelToken,
                                                                    System.Configuration.ConfigurationManager.AppSettings["APIUserName"].ToString(),
                                                                    System.Configuration.ConfigurationManager.AppSettings["APIPassword"].ToString(),
                                                                    System.Configuration.ConfigurationManager.AppSettings["ConnectTo"].ToString());
            if (response.Info == "success")
            {

                pIDAReturnVal.TokenID = response.Token.ToString();

                //Get Repository List
                RepositoryModel[] resRepositoryID = await GetRepositories(System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString(), response.Token.ToString());
                foreach (var item in resRepositoryID)
                {
                    if (strPageName == "CampaignMaterials")
                    {
                        if (item.Name.ToUpper() == System.Configuration.ConfigurationManager.AppSettings["CFMRepositoryId"].ToString())
                        {
                            pIDAReturnVal.RepositoryID = item.RepositoryID.ToString();
                            break;
                        }
                    }
                    else if (strPageName == "SupportingDocuments")
                    {
                        if (item.Name.ToUpper() == System.Configuration.ConfigurationManager.AppSettings["CFMSupDocRepositoryId"].ToString())
                        {
                            pIDAReturnVal.RepositoryID = item.RepositoryID.ToString();
                            break;
                        }
                    }
                }

                //Get Cabinet ID
                List<CabinetModel> rescabinetID = await GetCabinets(System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString(), response.Token.ToString(), pIDAReturnVal.RepositoryID.ToString());
                foreach (var item in rescabinetID)
                {
                    if (strPageName == "CampaignMaterials")
                    {
                        if (item.Name.ToUpper() == System.Configuration.ConfigurationManager.AppSettings["CFMCabinetName"].ToString())
                        {
                            pIDAReturnVal.CabinetID = item.CabinetID.ToString();
                        }
                    }
                    else if(strPageName == "SupportingDocuments")
                    {
                        if (item.Name.ToUpper() == System.Configuration.ConfigurationManager.AppSettings["CFMSupDocCabinetName"].ToString())
                        {
                            pIDAReturnVal.CabinetID = item.CabinetID.ToString();
                        }
                    }                        
                }

                //Get Extension ID
                List<ExtensionModel> extensionModels = await GetExtensions(System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString(), response.Token.ToString(), pIDAReturnVal.RepositoryID.ToString());
                foreach (var item in extensionModels)
                {
                    if (strFileType.ToString() == "PDF")
                    {
                        if (item.Name == "Adobe")
                        {
                            pIDAReturnVal.ManagerID = item.ManagerID.ToString();
                            pIDAReturnVal.ExtensionID = item.ExtensionID.ToString();
                            pIDAReturnVal.ExtensionName = item.Extension.ToString();
                        }
                    }
                    else if (strFileType.ToString() == "PNG")
                    {
                        if (item.Extension == "PNG")
                        {
                            pIDAReturnVal.ManagerID = item.ManagerID.ToString();
                            pIDAReturnVal.ExtensionID = item.ExtensionID.ToString();
                            pIDAReturnVal.ExtensionName = item.Extension.ToString();
                        }
                    }
                    else if (strFileType.ToString() == "JPG" || strFileType.ToString() == "JPEG")
                    {
                        if (item.Extension == "JPG")
                        {
                            pIDAReturnVal.ManagerID = item.ManagerID.ToString();
                            pIDAReturnVal.ExtensionID = item.ExtensionID.ToString();
                            pIDAReturnVal.ExtensionName = item.Extension.ToString();
                        }
                    }
                }

                //Tab ID
                TabModel[] tabModels = await GetTabs(System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString(), response.Token.ToString(), pIDAReturnVal.CabinetID.ToString());
                foreach (var item in tabModels)
                {
                    if (item.Name == "Miscellaneous")
                    {
                        pIDAReturnVal.TabID = item.TabID.ToString();
                    }
                }

                //Template ID
                TemplateModel.Document templateID = await GetTemplate(System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString(), response.Token.ToString(), pIDAReturnVal.CabinetID.ToString());
                foreach (var item in templateID.Templates)
                {
                    pIDAReturnVal.TemplateID = item.TemplateID.ToString();
                }
            }
            return pIDAReturnVal;
        }
        #endregion GetTokenID

        #region Cabinet Functions                

        public async Task<int> CreateFolder(string CabinetOpenAPIURL, string CabinetToken, string cabinetID, string folderName, string pageName)
        {
            List<string> FolderIndexValues = new List<string>(new string[] { folderName }); //Data for a Folder with 3 indexes

            CancellationToken CancelToken = new CancellationToken();
            List<IndiciesModel> CabinetIndexes = await GetCabinetIndexes(System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString(), CabinetToken, CancelToken, Int32.Parse(cabinetID));
            for (int i = 0; i <= CabinetIndexes.Count - 1; i++)
            {
                if (pageName == "SupportingDocuments")
                {
                    if (CabinetIndexes[0].Name.ToString() == System.Configuration.ConfigurationManager.AppSettings["CabinetIndexFolderId"].ToString())
                    {
                        FolderIndexValues[i] = CabinetIndexes[i].IndexID1.ToString() + "|" + FolderIndexValues[i];
                        break;
                    }
                }
                else if(pageName== "CampaignMaterials")
                {
                    if (CabinetIndexes[0].Name.ToString() == System.Configuration.ConfigurationManager.AppSettings["CabinetIndexFolderName"].ToString())
                    {
                        FolderIndexValues[i] = CabinetIndexes[i].IndexID1.ToString() + "|" + FolderIndexValues[i];
                        break;
                    }
                }                
            }

            FolderCreateEditModel NewFolderModel = new FolderCreateEditModel
            {
                CabinetID = Int32.Parse(cabinetID),
                SecurityID = 1,
                FolderID = 0,
                Indexes = FolderIndexValues
            };

            CabPCL.clsFolder clsFolder = new CabPCL.clsFolder();            
            return await clsFolder.AddFolderAsync(CabinetOpenAPIURL, CabinetToken, CancelToken, NewFolderModel);
        }

        public async Task<int> AddDocumentUsingTemplate(string CabinetOpenAPIURL, string CabinetToken, CancellationToken CancelToken, int CabinetID, int FolderID,
            int TabID, int ExtensionID, int ManagerID, int ParentID, int SecurityID, int TemplateID, int RetentionID, string Title, string ExtensionName, Stream FileStream, string Keywords = "")
        {
            CabPCL.clsCabinet clsCabinet = new CabPCL.clsCabinet();

            CabinetModel cabinetModel = await clsCabinet.GetCabinetAsync(CabinetOpenAPIURL, CabinetToken, CancelToken, CabinetID);

            CabPCL.clsDocument clsDocument = new CabPCL.clsDocument();

            int newDocumentID = await clsDocument.AddDocumentAsync(CabinetOpenAPIURL, CabinetToken, CancelToken, CabinetID, FolderID, TabID,
                ExtensionID, ManagerID, ParentID, SecurityID, TemplateID, RetentionID, Title, ExtensionName, FileStream);

            FileStream.Close();

            return newDocumentID;
        }

        public async Task<int> FileDocument(int CabinetID, int FolderID, int TabID, int ManagerID, int ParentID,
            int SecurityID, int TemplateID, int RetentionID, string Title, string ExtensionName, int ExtensionID, string FileNameToImport,
            string filePath, Stream DocumentStream, string tokenID, string Keywords = "")
        {
            int DocumentID = 0;

            //Remove leading and trailing spaces in Title
            Title = Title.TrimEnd().TrimStart();

            CancellationToken CancelToken = new CancellationToken();
            DocumentID = await this.AddDocumentUsingTemplate(System.Configuration.ConfigurationManager.AppSettings["APIURL"].ToString(), tokenID, CancelToken, CabinetID, FolderID, TabID, ExtensionID,
                    ManagerID, ParentID, SecurityID, TemplateID, RetentionID, Title, ExtensionName, DocumentStream, Keywords);

            return DocumentID;

        }

        public async Task<List<DocumentInfoModel.DocumentInformationModel>> GetDocumentInfo(string OpenAPIURL, string Token, CancellationToken CancelToken, int CabinetID, int DocumentID)
        {
            CabPCL.clsDocument c = new CabPCL.clsDocument();
            DocumentInfoModel DocumentInfoModel = await c.GetDocumentInfoAsync(OpenAPIURL, Token, CancelToken, CabinetID, DocumentID);
            List<DocumentInfoModel.DocumentInformationModel> DocumentInformationModels = DocumentInfoModel.Info;

            return DocumentInformationModels;
        }

        #endregion

        #endregion COMMON CABITNET CODE DON'T REMOVE.GetOriginalLiabilityData
                
        //============CABINET CODE=========CAMPAIGN MATERIAL=====CABINET CODE==============

        //============NEWTWORK DIRVE CODE=========CAMPAIGN MATERIAL=====NEWTWORK DIRVE CODE==============

        #region UploadFileInNetworkDrive
        /// <summary>
        /// UploadFileInNetworkDrive
        /// </summary>
        /// <param name="objUploadFileNTDriveContract"></param>
        /// <returns></returns>
        public Boolean UploadFileInNetworkDrive(UploadFileNTDriveContract objUploadFileNTDriveContract)
        {
            // UPLOAD FILE INTO NETWORK DRIVE.
            String path = System.Configuration.ConfigurationManager.AppSettings["CAMP_MATR_URL"].ToString();

            Boolean isSuccess = false;
            FileStream fileStream = null;

            String strFolderPath = objUploadFileNTDriveContract.FilerIdNTDrive + "//" + objUploadFileNTDriveContract.ElectionYearNTDrive + "//" + objUploadFileNTDriveContract.DisclosurePeriodNTDrive + "//";

            string pathString = Path.Combine(System.Configuration.ConfigurationManager.AppSettings["CAMP_MATR_URL"].ToString(), strFolderPath);

            try
            {
                if (!string.IsNullOrEmpty(pathString))
                {
                    if (!string.IsNullOrEmpty(objUploadFileNTDriveContract.CampMatrFileName))
                    {
                        String directoryName = Path.GetDirectoryName(pathString);
                        if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
                        {
                            Directory.CreateDirectory(directoryName);
                        }
                        string strFileFullPath = pathString + objUploadFileNTDriveContract.CampMatrFileName;
                        fileStream = new FileStream(strFileFullPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        // write file stream into the specified file  
                        using (System.IO.FileStream fs = fileStream)
                        {
                            fs.Write(objUploadFileNTDriveContract.FileBytes, 0, objUploadFileNTDriveContract.FileBytes.Length);
                            isSuccess = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                isSuccess = false;
            }

            return isSuccess;
        }
        #endregion UploadFileInNetworkDrive

        #region DownloadFileInNetworkDrive
        /// <summary>
        /// DownloadFileInNetworkDrive
        /// </summary>
        /// <param name="strFileFolderPath"></param>
        /// <param name="strFileName"></param>
        /// <returns></returns>
        public Byte[] DownloadFileInNetworkDrive(String strFileFolderPath, String strFileName)
        {
            String strFilePath = String.Empty;
            Byte[] fileBytes = null;

            String path = System.Configuration.ConfigurationManager.AppSettings["CAMP_MATR_URL"].ToString();
                        
            String filePath = path + strFileFolderPath;

            String fullName = Path.Combine(filePath, strFileName);
            

            if (File.Exists(fullName))
            {
                FileStream fs = File.OpenRead(fullName);
                Byte[] data = new byte[fs.Length];
                //fileBytes = File.ReadAllBytes(filePath);
                fileBytes = data;
                return fileBytes;
            }                
            else
            {
                return fileBytes;
            }                
        }
        #endregion DownloadFileInNetworkDrive

        //============NEWTWORK DIRVE CODE=========CAMPAIGN MATERIAL=====NEWTWORK DIRVE CODE==============

        //=========================================================================================================================================
        // NON-ITEMIZED TRANSACTIONS - >>>> END END END >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //=========================================================================================================================================
        
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
            Boolean returnValue = objEFSRepository.GetDropdownValueExists(strTableName, strDropdownValue);

            return returnValue;
        }
        #endregion GetDropdownValueExists

        #region GetDropdownValueExistsValidation
        /// <summary>
        /// GetDropdownValueExistsValidation
        /// </summary>
        /// <returns></returns>
        public IList<VendorImportValidationContract> GetDropdownValueExistsValidation()
        {
            IList<VendorImportValidationContract> lstVendorImportValidation = new List<VendorImportValidationContract>();
            VendorImportValidationContract objVendorImportValidation;

            var results = objEFSRepository.GetDropdownValueExistsValidation();

            foreach (var item in results)
            {
                objVendorImportValidation = new VendorImportValidationContract();
                objVendorImportValidation.Id = item.Id;
                objVendorImportValidation.TableName = item.TableName;
                lstVendorImportValidation.Add(objVendorImportValidation);
            }

            return lstVendorImportValidation;

        }
        #endregion GetDropdownValueExistsValidation

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
        public IList<FilingDatesOffCycleContract> GetFilingDateOffCycleData(String strElectionYearId, String strOfficeTypeId, String strFilerId, String strDisclosureType)
        {
            IList<FilingDatesOffCycleContract> lstFilingDatesOffCycleContract = new List<FilingDatesOffCycleContract>();
            FilingDatesOffCycleContract objFilingDatesOffCycleContract;

            var results = objEFSRepository.GetFilingDateOffCycleData(strElectionYearId, strOfficeTypeId, strFilerId, strDisclosureType);

            foreach (var item in results)
            {
                objFilingDatesOffCycleContract = new FilingDatesOffCycleContract();
                objFilingDatesOffCycleContract.FilingDateId = item.FilingDateId;
                objFilingDatesOffCycleContract.FilingDate = item.FilingDate;
                lstFilingDatesOffCycleContract.Add(objFilingDatesOffCycleContract);
            }

            return lstFilingDatesOffCycleContract;
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
        public IList<FilingDatesOffCycleContract> GetFilingDateIEWeeklyeData(String strElectionYearId, String strElectionTypeId, String strOfficeTypeId, String strFilerId, String strFilingType, String strFilingCatId, String strElectionDateId, String strMunicipalityID)
        {
            IList<FilingDatesOffCycleContract> lstFilingDatesOffCycleContract = new List<FilingDatesOffCycleContract>();
            FilingDatesOffCycleContract objFilingDatesOffCycleContract;

            var results = objEFSRepository.GetFilingDateIEWeeklyeData(strElectionYearId, strElectionTypeId, strOfficeTypeId, strFilerId, strFilingType, strFilingCatId, strElectionDateId, strMunicipalityID);

            foreach (var item in results)
            {
                objFilingDatesOffCycleContract = new FilingDatesOffCycleContract();
                objFilingDatesOffCycleContract.FilingDateId = item.FilingDateId;
                objFilingDatesOffCycleContract.FilingDate = item.FilingDate;
                lstFilingDatesOffCycleContract.Add(objFilingDatesOffCycleContract);
            }

            return lstFilingDatesOffCycleContract;
        }
        #endregion GetFilingDateIEWeeklyeData

        #region GeResigTermTypeData
        /// <summary>
        /// GeResigTermTypeData
        /// </summary>
        /// <returns></returns>
        public IList<ResigTermTypeContract> GeResigTermTypeData()
        {
            IList<ResigTermTypeContract> lstResigTermTypeContract = new List<ResigTermTypeContract>();
            ResigTermTypeContract objResigTermTypeContract;

            var results = objEFSRepository.GeResigTermTypeData();

            foreach (var item in results)
            {
                objResigTermTypeContract = new ResigTermTypeContract();
                objResigTermTypeContract.ResigTermTypeId = item.ResigTermTypeId;
                objResigTermTypeContract.ResigTermTypeDesc = item.ResigTermTypeDesc;
                lstResigTermTypeContract.Add(objResigTermTypeContract);
            }

            return lstResigTermTypeContract;
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
        public IList<ResigTermTypeContract> GetResgTermTypeExistsValue(String strFilerId, String strElectionTypeId, String strOfficeTypeId, String strFilingTypeId, String strElectionYearId, String strElectionDateId, String strFilingDate, String strFilingCategoryId, String strMunicipalityId)
        {
            IList<ResigTermTypeContract> lstResigTermTypeContract = new List<ResigTermTypeContract>();
            ResigTermTypeContract objResigTermTypeContract;

            var results = objEFSRepository.GetResgTermTypeExistsValue(strFilerId, strElectionTypeId, strOfficeTypeId, strFilingTypeId, strElectionYearId, strElectionDateId, strFilingDate, strFilingCategoryId, strMunicipalityId);

            foreach (var item in results)
            {
                objResigTermTypeContract = new ResigTermTypeContract();
                objResigTermTypeContract.ResigTermTypeId = item.ResigTermTypeId;
                objResigTermTypeContract.ResigTermTypeDesc = item.ResigTermTypeDesc;
                objResigTermTypeContract.FilingsId = item.FilingsId;
                lstResigTermTypeContract.Add(objResigTermTypeContract);
            }

            return lstResigTermTypeContract;
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
            Boolean results = objEFSRepository.UpdateResgTermTypeFilings(strFilingsId, strResgTermTypeId, strModifiedBy);

            return results;
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
        public Boolean GetEelectionExistsEFS(String strElectionYearId, String strElectionTypeId, String strOfficeTypeId, String strElectionDateId, String strMunicipalityId)
        {
            Boolean results = objEFSRepository.GetEelectionExistsEFS(strElectionYearId, strElectionTypeId, strOfficeTypeId, strElectionDateId, strMunicipalityId);

            return results;
        }
        #endregion GetEelectionExistsEFS

        #region TransferOutStandingLiabilityBalance
        /// <summary>
        /// TransferOutStandingLiabilityBalance
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public String TransferOutStandingLiabilityBalance(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity;
            objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.FilingTypeId = objFilingTransactionsContract.FilingTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;
            objFilingTransactionsEntity.ResigTermTypeId = objFilingTransactionsContract.ResigTermTypeId;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;

            string results = objEFSRepository.TransferOutStandingLiabilityBalance(objFilingTransactionsEntity);
            return results;
        }
        #endregion TransferOutStandingLiabilityBalance


        /// <summary>
        /// Auto Complete of Sched R
        /// </summary>
        /// <param name="name"></param>
        /// <param name="strFilerId"></param>
        /// <returns></returns>
        public IList<AutoCompleteSchedRContract> GetAutoCompleteSchedR(String name, String strFilerId)
        {
            IList<AutoCompleteSchedRContract> lstAutoCompleteSchedREntity = new List<AutoCompleteSchedRContract>();
            AutoCompleteSchedRContract objAutoCompleteSchedREntity;

            var results = objEFSRepository.GetAutoCompleteSchedR(name, strFilerId);

            foreach (var item in results)
            {
                objAutoCompleteSchedREntity = new AutoCompleteSchedRContract();
                objAutoCompleteSchedREntity.FilingEntityId = item.FilingEntityId;
                objAutoCompleteSchedREntity.EntityName = item.EntityName;
                objAutoCompleteSchedREntity.Org_Amt = item.Org_Amt;
                objAutoCompleteSchedREntity.FirstName = item.FirstName;
                objAutoCompleteSchedREntity.MiddleName = item.MiddleName;
                objAutoCompleteSchedREntity.LastName = item.LastName;
                objAutoCompleteSchedREntity.ElectionYear = item.ElectionYear;
                objAutoCompleteSchedREntity.Office_ID = Convert.ToString(item.Office_ID);
                objAutoCompleteSchedREntity.Dist_ID = Convert.ToString(item.Dist_ID);
                lstAutoCompleteSchedREntity.Add(objAutoCompleteSchedREntity);
            }

            return lstAutoCompleteSchedREntity;
        }

        /// <summary>
        /// Get Filer Information
        /// </summary>
        /// <param name="filerID"></param>
        /// <param name="person_ID"></param>
        /// <returns></returns>
        public IList<FilerInfoContract> GetFilerInforamation(String filerID, String person_ID)
        {
            IList<FilerInfoContract> listFilerInfo = new List<FilerInfoContract>();
            FilerInfoContract objFilerInfo;
            //data from stored procedure
            var results = objEFSRepository.GetFilerInforamation(filerID, person_ID);

            foreach (var item in results)
            {
                //create GetDistrictsEntity object
                objFilerInfo = new FilerInfoContract();
                //modify object's attributes
                objFilerInfo.Trans_Cand_ID = Convert.ToString(item.Trans_Cand_ID);
                objFilerInfo.Filer_ID = Convert.ToString(item.Filer_ID);
                objFilerInfo.Cand_Comm_ID = Convert.ToString(item.Cand_Comm_ID);
                objFilerInfo.Cand_Comm_Name = Convert.ToString(item.Cand_Comm_Name);
                objFilerInfo.PersonID = Convert.ToString(item.PersonID);
                objFilerInfo.Name = Convert.ToString(item.Name);
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
        public string TransferOutStandingBalance(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity;
            objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.FilingTypeId = objFilingTransactionsContract.FilingTypeId;        
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;
            objFilingTransactionsEntity.ResigTermTypeId = objFilingTransactionsContract.ResigTermTypeId;
            objFilingTransactionsEntity.MunicipalityID = objFilingTransactionsContract.MunicipalityID;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;

            string results = objEFSRepository.TransferOutStandingBalance(objFilingTransactionsEntity);
            return results;
        }

        /// <summary>
        /// Submit filings from Summery Page
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean SubmitFilings_Summery(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.FilingTypeId = objFilingTransactionsContract.FilingTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;

            Boolean result = objEFSRepository.SubmitFilings_Summery(objFilingTransactionsEntity);

            return result;
        }

        /// <summary>
        /// GetFilingTransactionsData
        /// </summary>
        /// <param name="objFilingTransDataContract"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataContract> GetFilingTransactionsDataSummary(FilingTransDataContract objFilingTransDataContract)
        {
            IList<FilingTransactionDataContract> lstFilingTransactionDataContract = new List<FilingTransactionDataContract>();
            FilingTransactionDataContract objFilingTransactionDataContract;

            FilingTransDataEntity objFilingTransDataEntity = new FilingTransDataEntity();
            objFilingTransDataEntity.FilerId = objFilingTransDataContract.FilerId;
            objFilingTransDataEntity.ReportYearId = objFilingTransDataContract.ReportYearId;
            objFilingTransDataEntity.OfficeTypeId = objFilingTransDataContract.OfficeTypeId;
            objFilingTransDataEntity.DisclosurePeriod = objFilingTransDataContract.DisclosurePeriod;            
            objFilingTransDataEntity.ElectionType = objFilingTransDataContract.ElectionType;
            objFilingTransDataEntity.ElectionDateId = objFilingTransDataContract.ElectionDateId;
            objFilingTransDataEntity.FilingDate = objFilingTransDataContract.FilingDate;
            objFilingTransDataEntity.FilingSchedID = objFilingTransDataContract.FilingSchedID;
            var results = objEFSRepository.GetFilingTransactionsDataSummary(objFilingTransDataEntity);
             
            foreach (var item in results)
            {
                objFilingTransactionDataContract = new FilingTransactionDataContract();
                objFilingTransactionDataContract.FilingTransId = item.FilingTransId;
                objFilingTransactionDataContract.FilingSchedId = item.FilingSchedId;
                objFilingTransactionDataContract.ContributorTypeId = item.ContributorTypeId;
                objFilingTransactionDataContract.ContributorTypeDesc = item.ContributorTypeDesc;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionDataContract.PaymentTypeId = item.PaymentTypeId;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.SchedDate = item.SchedDate;
                objFilingTransactionDataContract.FilingSchedDesc = item.FilingSchedDesc;
                objFilingTransactionDataContract.FilingEntityId = item.FilingEntityId;
                objFilingTransactionDataContract.FilingEntityName = item.FilingEntityName;
                objFilingTransactionDataContract.FilingFirstName = item.FilingFirstName;
                objFilingTransactionDataContract.FilingMiddleName = item.FilingMiddleName;
                objFilingTransactionDataContract.FilingLastName = item.FilingLastName;
                objFilingTransactionDataContract.FilingStreetNumber = item.FilingStreetNumber;
                objFilingTransactionDataContract.FilingStreetName = item.FilingStreetName;
                objFilingTransactionDataContract.FilingCity = item.FilingCity;
                objFilingTransactionDataContract.FilingState = item.FilingState;
                objFilingTransactionDataContract.FilingZip = item.FilingZip;
                objFilingTransactionDataContract.FilingCountry = item.FilingCountry;
                objFilingTransactionDataContract.PaymentTypeDesc = item.PaymentTypeDesc;
                objFilingTransactionDataContract.PayNumber = item.PayNumber;
                objFilingTransactionDataContract.OriginalAmount = item.OriginalAmount;
                objFilingTransactionDataContract.ReceiptTypeDesc = item.ReceiptTypeDesc;
                objFilingTransactionDataContract.TransferTypeDesc = item.TransferTypeDesc;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.OriginalDate = item.OriginalDate;
                objFilingTransactionDataContract.LoanerCode = item.LoanerCode;
                objFilingTransactionDataContract.ElectionYear = item.ElectionYear;
                objFilingTransactionDataContract.ReportYear = item.ReportYear;
                objFilingTransactionDataContract.Office = item.Office;
                objFilingTransactionDataContract.District = item.District;
                objFilingTransactionDataContract.RLiability = item.RLiability;
                objFilingTransactionDataContract.RSubcontractor = item.RSubcontractor;
                objFilingTransactionDataContract.TransExplanation = item.TransExplanation;
                objFilingTransactionDataContract.OwedAmount = item.OwedAmount;
                objFilingTransactionDataContract.RItemized = item.RItemized;
                objFilingTransactionDataContract.CountyID = item.CountyID;
                objFilingTransactionDataContract.CountyDesc = item.CountyDesc;
                objFilingTransactionDataContract.MunicipalityID = item.MunicipalityID;
                objFilingTransactionDataContract.MunicipalityDesc = item.MunicipalityDesc;
                objFilingTransactionDataContract.LoanerCodeID = item.LoanerCodeId;
                objFilingTransactionDataContract.Increased = item.Increased;
                objFilingTransactionDataContract.Decreased = item.Decreased;
                objFilingTransactionDataContract.Balance = item.Balance;
                objFilingTransactionDataContract.CreatedDate = item.CreatedDate;
                objFilingTransactionDataContract.LoanLiablityNumber = item.LoanLiablityNumber;
                objFilingTransactionDataContract.TransNumber = item.TransNumber;
                objFilingTransactionDataContract.TransMapping = item.TransMapping;
                objFilingTransactionDataContract.DBStatus = item.DBStatus;

                objFilingTransactionDataContract.FilerId = item.FilerId;
                objFilingTransactionDataContract.CandidateCommitteeName = item.CandidateCommitteeName;
                objFilingTransactionDataContract.FilerType = item.FilerType;
                objFilingTransactionDataContract.ElectionType = item.ElectionType;
                objFilingTransactionDataContract.ReportType = item.ReportType;
                objFilingTransactionDataContract.ElectionDate = item.ElectionDate;
                objFilingTransactionDataContract.DisclosureType = item.DisclosureType;
                objFilingTransactionDataContract.DisclosurePeriod = item.DisclosurePeriod;
                objFilingTransactionDataContract.Office_Desc = item.Office_Desc;
                objFilingTransactionDataContract.RClaim = item.RClaim;
                objFilingTransactionDataContract.InDistrict = item.InDistrict;
                objFilingTransactionDataContract.RMinor = item.RMinor;
                objFilingTransactionDataContract.RVendor = item.RVendor;
                objFilingTransactionDataContract.RLobbyist = item.RLobbyist;
                objFilingTransactionDataContract.TreasurerEmployer = item.TreasurerEmployer;
                objFilingTransactionDataContract.TreasurerOccuptaion = item.TreasurerOccuptaion;
                objFilingTransactionDataContract.TreaAddress = item.TreaAddress;
                objFilingTransactionDataContract.TreaAddr1 = item.TreaAddr1;
                objFilingTransactionDataContract.TreaCity = item.TreaCity;
                objFilingTransactionDataContract.TreaState = item.TreaState;
                objFilingTransactionDataContract.TreaZipCode = item.TreaZipCode;
                objFilingTransactionDataContract.RContributions = item.RContributions;
                objFilingTransactionDataContract.RIESupported = item.RIESupported;
                objFilingTransactionDataContract.RSupportOppose = item.RSupportOppose;
                lstFilingTransactionDataContract.Add(objFilingTransactionDataContract);
            }

            return lstFilingTransactionDataContract;
        }

        /// <summary>
        /// Get Opening Balance of Disclosure Summery
        /// </summary>
        /// <param name = "filerID" ></ param >
        /// < param name="election_Year_ID"></param>
        /// <param name = "office_Type_ID" ></ param >
        /// < param name="filing_Type_ID"></param>
        /// <param name = "election_Date" ></ param >
        /// < returns ></ returns >
        public String GetSummery_OpeningBalance(String filerID, String election_Year_ID, String office_Type_ID, String filing_Type_ID, String election_Date, String filing_date)
        {
            String strOpeningBalance = String.Empty;

            strOpeningBalance = objEFSRepository.GetSummery_OpeningBalance(filerID, election_Year_ID, office_Type_ID, filing_Type_ID, election_Date, filing_date);

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
        public String GetSummery_ClosingBalance(String filerID, String election_Year_ID, String office_Type_ID, String filing_Type_ID, String filing_Date)
        {
            String strClosingBalance = String.Empty;

            strClosingBalance = objEFSRepository.GetSummery_ClosingBalance(filerID, election_Year_ID, office_Type_ID, filing_Type_ID, filing_Date);

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

            strClosingBalance = objEFSRepository.GetSummery_AllSchedBalances(filerID, election_Year_ID, office_Type_ID, filing_Type_ID, filing_date, filingSchedID);

            return strClosingBalance;
        }

        /// <summary>
        /// GetSummery_AllSchedBalances_Sched_N
        /// </summary>
        /// <param name="filerID"></param>
        /// <param name="election_Year_ID"></param>
        /// <param name="office_Type_ID"></param>
        /// <param name="filing_Type_ID"></param>
        /// <param name="filing_date"></param>
        /// <param name="filingSchedID"></param>
        /// <returns></returns>
        public String GetSummery_AllSchedBalances_Sched_N(String filerID, String election_Year_ID, String office_Type_ID, String filing_Type_ID, String filing_date, String filingSchedID)
        {
            String strClosingBalance = String.Empty;

            strClosingBalance = objEFSRepository.GetSummery_AllSchedBalances_Sched_N(filerID, election_Year_ID, office_Type_ID, filing_Type_ID, filing_date, filingSchedID);

            return strClosingBalance;
        }

        #region GetOfficeTypeEFS
        public IList<OfficeTypeContract> GetOfficeTypeEFS(String strElectionYear)
        {
            IList<OfficeTypeContract> lstOfficeTypeContract = new List<OfficeTypeContract>();
            OfficeTypeContract objOfficeTypeContract;

            var results = objEFSRepository.GetOfficeTypeEFS(strElectionYear);

            foreach (var item in results)
            {
                objOfficeTypeContract = new OfficeTypeContract();
                objOfficeTypeContract.OfficeTypeId = item.OfficeTypeId;
                objOfficeTypeContract.OfficeTypeDesc = item.OfficeTypeDesc;
                lstOfficeTypeContract.Add(objOfficeTypeContract);
            }

            return lstOfficeTypeContract;
        }
        #endregion GetOfficeTypeEFS


        // Creighton Newsom
        // ViewAllDisclosures Page
        #region "ViewAllDisclosures"

        #region "GetCampaignMaterialsGridData"
        // GETS THE DATA FOR THE CAMPAIGN MATERIALS GRID
        public IList<CampaignMaterialsContract> GetCampaignMaterialsGridData(String strFilingsID, String strAmended)
        {
            IList<CampaignMaterialsContract> lstCampaignMaterialsGrid = new List<CampaignMaterialsContract>();
            CampaignMaterialsContract objCampaignMaterialsGrid;

            var results = objEFSRepository.GetCampaignMaterialsGridData(strFilingsID, strAmended);

            foreach (var item in results)
            {
                objCampaignMaterialsGrid = new CampaignMaterialsContract();
                objCampaignMaterialsGrid.CampaignMaterialID = item.CampaignMaterialID;
                objCampaignMaterialsGrid.FilingMethodID = item.FilingMethodID;
                objCampaignMaterialsGrid.ScanDocID = item.ScanDocID;
                objCampaignMaterialsGrid.DateSubmitted = item.DateSubmitted;
                objCampaignMaterialsGrid.FilingMethodDesc = item.FilingMethodDesc;
                objCampaignMaterialsGrid.FileSize = item.FileSize;
                objCampaignMaterialsGrid.FileType = item.FileType;
                objCampaignMaterialsGrid.CreatedDate = item.CreatedDate;
                objCampaignMaterialsGrid.CampaignMaterialAvailable = item.CampaignMaterialAvailable;
                objCampaignMaterialsGrid.CampaignMaterialDesc = item.CampaignMaterialDesc;

                //add object to list
                lstCampaignMaterialsGrid.Add(objCampaignMaterialsGrid);
        }
            return lstCampaignMaterialsGrid;
        }

        #endregion

        #region "GetOfficeTypeForFilerIDWCF"
        // FUNCTION POPULATES OFFICETYPES FOR THE FILTER DROPDOWN
        public IList<OfficeTypeContract> GetOfficeTypeForFilerIDWCF(String strElectYearID, String strFilerID)
        {
            IList<OfficeTypeContract> listOfficeTypeContract = new List<OfficeTypeContract>();
            OfficeTypeContract objOfficeTypeContract;
            var results = objEFSRepository.GetOfficeTypeForFilerID(strElectYearID, strFilerID);
            foreach (var item in results)
            {
                objOfficeTypeContract = new OfficeTypeContract();
                objOfficeTypeContract.OfficeTypeId = Convert.ToString(item.OfficeTypeId);
                objOfficeTypeContract.OfficeTypeDesc = item.OfficeTypeDesc;
                listOfficeTypeContract.Add(objOfficeTypeContract);
            }
            return listOfficeTypeContract;
        }
        #endregion

        #region "GetElectionTypeForFilerIDWCF"
        // THIS FUNCTION GETS THE DATA FOR THE ELECTIONTYPE FILTER DROPDOWN
        public IList<ElectionTypeContract> GetElectionTypeForFilerIDWCF(String strElectYearID, String strOfficeTypeID, String strCountyID, String strMunicipalityID, String strFilerID)
        {
            IList<ElectionTypeContract> listElectionTypeContract = new List<ElectionTypeContract>();
            ElectionTypeContract objElectionTypeContract;
            var results = objEFSRepository.GetElectionTypeForFilerID(strElectYearID, strOfficeTypeID, strCountyID, strMunicipalityID, strFilerID);
            foreach (var item in results)
            {
                objElectionTypeContract = new ElectionTypeContract();
                objElectionTypeContract.ElectionTypeId = Convert.ToString(item.ElectionTypeId);
                objElectionTypeContract.ElectionTypeDesc = item.ElectionTypeDesc;
                listElectionTypeContract.Add(objElectionTypeContract);
            }
            return listElectionTypeContract;
        }
        #endregion

        #region "GetElectionDateWCF"
        // THIS FUNCTION GETS THE DATA FOR THE ELECTIONDATE FILTER DROPDOWN
        public IList<ElectionDateContract> GetElectionDateWCF(string electionYearID, string electionTypeID, string officeTypeID, string filerID, string countyID, string municipalityID)
        {
            IList<ElectionDateContract> listElectionDateContract = new List<ElectionDateContract>();
            ElectionDateContract objElectionDateContract;
            var results = objEFSRepository.GetElectionDate(electionYearID, electionTypeID, officeTypeID, filerID, countyID, municipalityID);
            foreach (var item in results)
            {
                objElectionDateContract = new ElectionDateContract();
                objElectionDateContract.ElectId = Convert.ToString(item.ElectId);
                objElectionDateContract.ElectDate = item.ElectDate;
                listElectionDateContract.Add(objElectionDateContract);
            }
            return listElectionDateContract;
        }
        #endregion

        #region "GetCountyWCF"
        // THIS FUNCTION GETS THE DATA FOR THE COUNTY FILTER DROPDOWN
        public IList<CountyContract> GetCountyWCF(int officeTypeID)
        {
            IList<CountyContract> listCountyContract = new List<CountyContract>();
            CountyContract objCountyContract;
            var results = objEFSRepository.GetCounty(officeTypeID);
            foreach (var item in results)
            {
                objCountyContract = new CountyContract();
                objCountyContract.CountyId = Convert.ToString(item.CountyId);
                objCountyContract.CountyDesc = item.CountyDesc;
                listCountyContract.Add(objCountyContract);
            }
            return listCountyContract;
        }
        #endregion

        #region "GetMunicipalityWCF"
        // THIS FUNCTION GETS THE DATA FOR THE MUNICIPALITY FILTER DROPDOWN
        public IList<MunicipalityContract> GetMunicipalityWCF(int countyID)
        {
            IList<MunicipalityContract> listMunicipalityContract = new List<MunicipalityContract>();
            MunicipalityContract objMunicipalityContract;
            var results = objEFSRepository.GetMunicipality(countyID);
            foreach (var item in results)
            {
                objMunicipalityContract = new MunicipalityContract();
                objMunicipalityContract.MunicipalityId = Convert.ToString(item.MunicipalityId);
                objMunicipalityContract.MunicipalityDesc = item.MunicipalityDesc;
                listMunicipalityContract.Add(objMunicipalityContract);
            }
            return listMunicipalityContract;
        }
        #endregion

        #region "GetDisclosureTypesForYearAndFilerID"
        // THIS FUNCTION GETS THE DISCLOSURETYPES FOR FILTER DROPDOWN
        public IList<DisclosureTypesContract> GetDisclosureTypesForYearAndFilerID(String strFilerID, String strElectionYearID, String strElectionTypeID, String strElectionDateID)
        {
            IList<DisclosureTypesContract> lstDisclosureTypesContract = new List<DisclosureTypesContract>();
            DisclosureTypesContract objDisclosureTypesContract;

            var results = objEFSRepository.GetDisclosureTypesForYearAndFilerID(strFilerID, strElectionYearID, strElectionTypeID, strElectionDateID);

            foreach (var item in results)
            {
                objDisclosureTypesContract = new DisclosureTypesContract();
                objDisclosureTypesContract.DisclosureTypeId = item.DisclosureTypeId;
                objDisclosureTypesContract.DisclosureTypeDesc = item.DisclosureTypeDesc;
                objDisclosureTypesContract.DisclosureSubTypeDesc = item.DisclosureSubTypeDesc;
                lstDisclosureTypesContract.Add(objDisclosureTypesContract);
            }

            return lstDisclosureTypesContract;
        }
        #endregion

        #region "GetDisclosurePeriodsForFilerID"
        // THIS FUNCTION GETS DISCLOSURE PERIODS FOR FILTER DROPDOWN
        public IList<DisclosurePreiodContract> GetDisclosurePeriodsForYearAndFilerIDAndElectionType(String strFilerID, String strElectionYearID, String strElectionTypeID, String strFilingCatID, String strOfficeTypeID)
        {
            IList<DisclosurePreiodContract> lstDisclosurePreiodContract = new List<DisclosurePreiodContract>();
            DisclosurePreiodContract objDisclosurePreiodContract;

            var results = objEFSRepository.GetDisclosurePeriodsForYearAndFilerIDAndElectionType(strFilerID, strElectionYearID, strElectionTypeID, strFilingCatID, strOfficeTypeID);

            foreach (var item in results)
            {
                objDisclosurePreiodContract = new DisclosurePreiodContract();
                objDisclosurePreiodContract.FilingTypeId = item.FilingTypeId;
                objDisclosurePreiodContract.FilingDesc = item.FilingDesc;
                objDisclosurePreiodContract.FilingAbbrev = item.FilingAbbrev;
                lstDisclosurePreiodContract.Add(objDisclosurePreiodContract);
            }

            return lstDisclosurePreiodContract;
        }
        #endregion

        #region "GetElectionYearDataForFilerID"
        // THIS FUNCTION GETS THE ELECTION YEAR FOR FILTER DROPDOWN
        public IList<ElectionYearContract> GetElectionYearDataForFilerID(String strFilerID)
        {
            IList<ElectionYearContract> lstElectionYearContract = new List<ElectionYearContract>();
            ElectionYearContract objElectionYearContract;

            var results = objEFSRepository.GetElectionYearDataForFilerID(strFilerID);

            foreach (var item in results)
            {
                objElectionYearContract = new ElectionYearContract();
                objElectionYearContract.ElectionYearId = item.ElectionYearId;
                objElectionYearContract.ElectionYearValue = item.ElectionYearValue;
                lstElectionYearContract.Add(objElectionYearContract);
            }

            return lstElectionYearContract;
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
            return objEFSRepository.InsertSupportingDocument(strTransNumber, strFilingMethodID, strDocTypeID, strScanDocID, strFileType, strFileSize, strCreatedBy, strFilerID, strFilingsID);
        }
        #endregion

        #region "InsertSupportingDocumentPIDA"
        // FUNCTION DOES AN INSERT INTO THE SUPPORTINGDOCUMENTS TABLE
        // THIS GETS CALLED AFTER THE DOCUMENT IS UPLOADED TO CABINET
        // SCANDOCID IS THE NUMBER RETURNED FROM CABINET, THE PIDA FUNCTIONALITY
        // INCLUDES ADDITIONAL FIELDS
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
            return objEFSRepository.InsertSupportingDocumentPIDA(strTransNumber, strFilingMethodID, strCommunicationTypeID, strScanDocID, strFileType, strFileSize, strDateSubmitted, strComments, strCreatedBy, strFilerID, strFilingsID);
        }
        #endregion

        #region "UpdateSupportingDocumentPIDA"
        // FUNCTION UPDATES THE SUPPORTINGDOCUMENTS TABLE FOR PIDA FUNCTIONALITY
        public String UpdateSupportingDocumentPIDA(
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
            return objEFSRepository.UpdateSupportingDocumentPIDA(strSupportingDocID, strFilingMethodID, strCommTypeID, strScanDocID, strFileType, strFileSize, strDateSubmitted, strComments, strUserID);
        }
        #endregion

        #region "GetSupportingDocumentsGridData"
        // FUNCTION GETS THE DATA FOR THE SUPPORTING DOCUMENTS GRID
        public IList<SupportingDocumentsGridContract> GetSupportingDocumentsGridData(String strTransNumber, string strFilingID)
        {
            IList<SupportingDocumentsGridContract> lstSupportingDocumentsGrid = new List<SupportingDocumentsGridContract>();
            SupportingDocumentsGridContract objSupportingDocumentsGrid;

            var results = objEFSRepository.GetSupportingDocumentsGridData(strTransNumber, strFilingID);

            foreach (var item in results)
            {
                objSupportingDocumentsGrid = new SupportingDocumentsGridContract();
                objSupportingDocumentsGrid.SupportingDocID = item.SupportingDocID;
                objSupportingDocumentsGrid.ScanDocID = item.ScanDocID;
                objSupportingDocumentsGrid.DateReceived = item.DateReceived;
                objSupportingDocumentsGrid.DocumentType = item.DocumentType;
                objSupportingDocumentsGrid.FileSize = item.FileSize;
                objSupportingDocumentsGrid.FileType = item.FileType;
                objSupportingDocumentsGrid.FilingMethod = item.FilingMethod;

                //add object to list
                lstSupportingDocumentsGrid.Add(objSupportingDocumentsGrid);
            }
            return lstSupportingDocumentsGrid;
        }
        #endregion

        #region "GetPIDAGridData"
        // FUNCTION GETS THE DATA FOR THE PIDA GRID
        public IList<PIDAGridContract> GetPIDAGridData(String strTransNumber)
        {
            IList<PIDAGridContract> lstPIDAGrid = new List<PIDAGridContract>();
            PIDAGridContract objPIDAGrid;

            var results = objEFSRepository.GetPIDAGridData(strTransNumber);

            foreach (var item in results)
            {
                objPIDAGrid = new PIDAGridContract();
                objPIDAGrid.SupportingDocID = item.SupportingDocID;
                objPIDAGrid.ScanDocID = item.ScanDocID;
                objPIDAGrid.CommunicationTypeID = item.CommunicationTypeID;
                objPIDAGrid.FileSize = item.FileSize;
                objPIDAGrid.FileType = item.FileType;

                objPIDAGrid.DateSubmitted = item.DateSubmitted;
                objPIDAGrid.CommunicationType = item.CommunicationType;

                objPIDAGrid.Description = item.Description;
                objPIDAGrid.SubmittedBy = item.SubmittedBy;

                //add object to list
                lstPIDAGrid.Add(objPIDAGrid);
            }
            return lstPIDAGrid;
        }
        #endregion

        #region "DeleteDisclosure"
        // IF IN PROD, SOFT DELETES A DISCLOSURE BY UPDATING FILING AND FILING TRANSACTION TABLES
        // IF IN TEMPORARY DATABASE, DOES A HARD DELETE
        public String DeleteDisclosure(String strFilingID, String strIsSubmitted, String strUserName, String strTransNumber)
        {
            return objEFSRepository.DeleteDisclosure(strFilingID, strIsSubmitted, strUserName, strTransNumber);
        }
        #endregion

        #region "DeleteSupportingDocument"
        // SOFT DELETES A SUPPORTING DOCUMENT BY UPDATING R_STATUS
        public String DeleteSupportingDocument(String strSupportingDocumentID, String strUserName)
        {
            return objEFSRepository.DeleteSupportingDocument(strSupportingDocumentID, strUserName);
        }
        #endregion

        #region "GetDocumentTypes"
        // GETS THE DOCUMENT TYPES (LETTER OF INDEBTEDNESS ETC)
        public IList<DocumentTypeContract> GetDocumentTypes(string ApplicationID)
        {
            IList<DocumentTypeContract> lstDocumentTypes = new List<DocumentTypeContract>();
            DocumentTypeContract objDocumentType;

            var results = objEFSRepository.GetDocumentTypes(ApplicationID);
            foreach (var item in results)
            {
                objDocumentType = new DocumentTypeContract();
                objDocumentType.DocumentTypeID = item.DocumentTypeID;
                objDocumentType.DocumentTypeDesc = item.DocumentTypeDesc;
                lstDocumentTypes.Add(objDocumentType);
            }
            return lstDocumentTypes;
        }
        #endregion

        #region "GetCommunicationTypes"
        // GETS THE COMMUNICATION TYPES FOR PIDA FUNCTIONALITY
        public IList<CommunicationTypeContract> GetCommunicationTypes()
        {
            IList<CommunicationTypeContract> lstCommunicationTypes = new List<CommunicationTypeContract>();
            CommunicationTypeContract objCommunicationType;

            var results = objEFSRepository.GetCommunicationTypes();
            foreach (var item in results)
            {
                objCommunicationType = new CommunicationTypeContract();
                objCommunicationType.CommunicationTypeID = item.CommunicationTypeID;
                objCommunicationType.CommunicationTypeDesc = item.CommunicationTypeDesc;
                lstCommunicationTypes.Add(objCommunicationType);
            }
            return lstCommunicationTypes;
        }
        #endregion

        #region "GetDisclosureGridData"
        // FUNCTION GETS THE DATA FOR THE DISCLOSURE GRID
        public IList<DisclosureGridContract> GetDisclosureGridData(String strFilerID, String strReportYearID, String strOfficeTypeID, String strCountyID, String strMunicipalityID, String strElectionTypeID, String strElectionDateID, String strDiclosureTypeID, String strDisclosurePeriodID)
        {
            IList<DisclosureGridContract> lstDisclosureGrid = new List<DisclosureGridContract>();
            DisclosureGridContract objDisclosureGrid;

            var results = objEFSRepository.GetDisclosureGridData(strFilerID, strReportYearID, strOfficeTypeID, strCountyID, strMunicipalityID, strElectionTypeID, strElectionDateID, strDiclosureTypeID, strDisclosurePeriodID);
            foreach (var item in results)
            {
                objDisclosureGrid = new DisclosureGridContract();
                objDisclosureGrid.FilingsID = item.FilingsID;
                objDisclosureGrid.PolCalDateID = item.PolCalDateID;
                objDisclosureGrid.ReportYearID = item.ReportYearID;
                objDisclosureGrid.OfficeTypeID = item.OfficeTypeID;
                objDisclosureGrid.ElectTypeID = item.ElectTypeID;
                objDisclosureGrid.DisclosureTypeID = item.DisclosureTypeID;
                objDisclosureGrid.DisclosurePeriodID = item.DisclosurePeriodID;

                objDisclosureGrid.Amended = item.Amended;
                objDisclosureGrid.ReportYear = item.ReportYear;
                objDisclosureGrid.OfficeType = item.OfficeType;
                objDisclosureGrid.ElectionType = item.ElectionType;
                objDisclosureGrid.ElectionDate = item.ElectionDate;
                objDisclosureGrid.FilingDate = item.FilingDate;
                objDisclosureGrid.DisclosureType = item.DisclosureType;
                objDisclosureGrid.DateSubmitted = item.DateSubmitted;
                objDisclosureGrid.DisclosurePeriod = item.DisclosurePeriod;
                objDisclosureGrid.R_Status = item.R_Status;
                objDisclosureGrid.TransNumber = item.TransNumber;
                objDisclosureGrid.FilingAbbrev = item.FilingAbbrev;
                objDisclosureGrid.ResigTermTypeID = item.ResigTermTypeID;
                objDisclosureGrid.LoanLibNumber = item.LoanLibNumber;
                objDisclosureGrid.County = item.County;
                objDisclosureGrid.Municipality = item.Municipality;
                objDisclosureGrid.CCDocType = item.CCDocType;
                lstDisclosureGrid.Add(objDisclosureGrid);
            }
            return lstDisclosureGrid;
        }
        #endregion

        #region "GetTransactionsGridData"
        // FUNCTION GETS THE DATA FOR THE TRANSACTION GRID
        public IList<TransactionGridContract> GetTransactionsGridData(String strFilingsID, String strPolCalDateID, String strAmended, String strR_Status, String strDateSubmitted, String strFilingCatID, String strTransNumber)
        {
            IList<TransactionGridContract> lstTransactionsGrid = new List<TransactionGridContract>();
            TransactionGridContract objTransactionsGrid;

            var results = objEFSRepository.GetTransactionsGridData(strFilingsID, strPolCalDateID, strAmended, strR_Status, strDateSubmitted, strFilingCatID, strTransNumber);
            foreach (var item in results)
            {
                objTransactionsGrid = new TransactionGridContract();
                objTransactionsGrid.Amount = item.Amount;
                objTransactionsGrid.CheckNum = item.CheckNum;
                objTransactionsGrid.City = item.City;
                objTransactionsGrid.ContributionType = item.ContributionType;
                objTransactionsGrid.ContributorCode = item.ContributorCode;
                objTransactionsGrid.Country = item.Country;
                objTransactionsGrid.County = item.County;
                objTransactionsGrid.ElectionYear = item.ElectionYear;
                objTransactionsGrid.EntityName = item.EntityName;
                objTransactionsGrid.Explanation = item.Explanation;
                objTransactionsGrid.FilingSchedID = item.FilingSchedID;
                objTransactionsGrid.TransNumber = item.TransNumber;
                objTransactionsGrid.FirstName = item.FirstName;
                objTransactionsGrid.Itemized = item.Itemized;
                objTransactionsGrid.LastName = item.LastName;
                objTransactionsGrid.LoanerCode = item.LoanerCode;
                objTransactionsGrid.Method = item.Method;
                objTransactionsGrid.MiddleName = item.MiddleName;
                objTransactionsGrid.Municipality = item.Municipality;
                objTransactionsGrid.Office = item.Office;
                objTransactionsGrid.District = item.District;
                objTransactionsGrid.OriginalDate = item.OriginalDate;
                objTransactionsGrid.OutStandingAmount = item.OutStandingAmount;
                objTransactionsGrid.PurposeCode = item.PurposeCode;
                objTransactionsGrid.ReceiptCode = item.ReceiptCode;
                objTransactionsGrid.ReceiptType = item.ReceiptType;
                objTransactionsGrid.State = item.State;
                objTransactionsGrid.StreetAddress = item.StreetAddress;
                objTransactionsGrid.TransactionDate = item.TransactionDate;
                //objTransactionsGrid.TransactionDateID = item.TransactionDateID;
                objTransactionsGrid.TransactionType = item.TransactionType;
                //objTransactionsGrid.TransactionTypeID = item.TransactionTypeID;
                objTransactionsGrid.TransferType = item.TransferType;
                objTransactionsGrid.ZipCode = item.ZipCode;
                objTransactionsGrid.Status = item.Status;
                objTransactionsGrid.Amended = item.Amended;
                objTransactionsGrid.DateSubmitted = item.DateSubmitted;
                objTransactionsGrid.CreatedDate = item.CreatedDate;
                objTransactionsGrid.TransMapping = item.TransMapping;
                objTransactionsGrid.ContributorTypeID = item.ContributorTypeID;
                objTransactionsGrid.LoanOtherID = item.LoanOtherID;
                objTransactionsGrid.ReceiptCodeID = item.ReceiptCodeID;
                objTransactionsGrid.R_Subcontractor = item.R_Subcontractor;
                objTransactionsGrid.PurposeCodeID = item.PurposeCodeID;
                objTransactionsGrid.R_Liability = item.R_Liability;
                objTransactionsGrid.LoanLibNumber = item.LoanLibNumber;

                objTransactionsGrid.TreasurerOccupation = item.TreasurerOccupation;
                objTransactionsGrid.TreasurerEmployer = item.TreasurerEmployer;
                objTransactionsGrid.TreasurerStreetAddress = item.TreasurerStreetAddress;
                objTransactionsGrid.TreasurerCity = item.TreasurerCity;
                objTransactionsGrid.TreasurerState = item.TreasurerState;
                objTransactionsGrid.TreasurerZipCode = item.TreasurerZipCode;
                objTransactionsGrid.ContributionType = item.ContributionType;
                objTransactionsGrid.ContributorName = item.ContributorName;
                objTransactionsGrid.ContributorOccupation = item.ContributorOccupation;
                objTransactionsGrid.ContributorEmployer = item.ContributorEmployer;
                objTransactionsGrid.IEDescription = item.IEDescription;
                objTransactionsGrid.CandidateNameBallotPropReference = item.CandidateNameBallotPropReference;
                objTransactionsGrid.Supported = item.Supported;
                objTransactionsGrid.RClaim = item.RClaim;
                objTransactionsGrid.InDistrict = item.InDistrict;
                objTransactionsGrid.RMinor = item.RMinor;
                objTransactionsGrid.RVendor = item.RVendor;
                objTransactionsGrid.RLobbyist = item.RLobbyist;
                objTransactionsGrid.TreasurerEmployer = item.TreasurerEmployer;
                objTransactionsGrid.TreasurerOccupation = item.TreasurerOccupation;
                objTransactionsGrid.TreaAddress = item.TreaAddress;
                objTransactionsGrid.TreaAddr1 = item.TreaAddr1;
                objTransactionsGrid.TreaCity = item.TreaCity;
                objTransactionsGrid.TreaState = item.TreaState;
                objTransactionsGrid.TreaZipCode = item.TreaZipCode;
                objTransactionsGrid.RContributions = item.RContributions;

                lstTransactionsGrid.Add(objTransactionsGrid);
            }
            return lstTransactionsGrid;
        }
        #endregion

        #region "GetTransactionDetailsGridData"
        public IList<TransactionDetailsGridContract> GetTransactionDetailsGridData(String strTransNumber, String strSubmitDate, String strFilerID)
        {
            IList<TransactionDetailsGridContract> lstTransactionDetailsGrid = new List<TransactionDetailsGridContract>();
            TransactionDetailsGridContract objTransactionDetailsGrid;

            var results = objEFSRepository.GetTransactionDetailsGridData(strTransNumber, strSubmitDate, strFilerID);

            foreach (var item in results)
            {
                objTransactionDetailsGrid = new TransactionDetailsGridContract();
                objTransactionDetailsGrid.Amount = item.Amount;
                objTransactionDetailsGrid.Explanation = item.Explanation;
                objTransactionDetailsGrid.FilingEntityCity = item.FilingEntityCity;
                objTransactionDetailsGrid.FilingEntityCountry = item.FilingEntityCountry;
                objTransactionDetailsGrid.FilingEntityFirstName = item.FilingEntityFirstName;
                objTransactionDetailsGrid.FilingEntityID = item.FilingEntityID;
                objTransactionDetailsGrid.FilingEntityLastName = item.FilingEntityLastName;
                objTransactionDetailsGrid.FilingEntityMiddleName = item.FilingEntityMiddleName;
                objTransactionDetailsGrid.FilingEntityName = item.FilingEntityName;
                objTransactionDetailsGrid.FilingEntityState = item.FilingEntityState;
                objTransactionDetailsGrid.FilingEntityStreetAddress = item.FilingEntityStreetAddress;
                objTransactionDetailsGrid.FilingEntityZip = item.FilingEntityZip;
                objTransactionDetailsGrid.Itemized = item.Itemized;
                objTransactionDetailsGrid.PayDate = item.PayDate;
                objTransactionDetailsGrid.CreatedDate = item.CreatedDate;

                objTransactionDetailsGrid.PurposeCode = item.PurposeCode;
                objTransactionDetailsGrid.TreasurerEmployer = item.TreasurerEmployer;
                objTransactionDetailsGrid.TreasurerOccupation = item.TreasurerOccupation;
                objTransactionDetailsGrid.TreaAddress = item.TreaAddress;
                objTransactionDetailsGrid.TreaAddr1 = item.TreaAddr1;
                objTransactionDetailsGrid.TreaCity = item.TreaCity;
                objTransactionDetailsGrid.TreaState = item.TreaState;
                objTransactionDetailsGrid.TreaZipCode = item.TreaZipCode;
                objTransactionDetailsGrid.RContributions = item.RContributions;

                //add object to list
                lstTransactionDetailsGrid.Add(objTransactionDetailsGrid);
            }
            return lstTransactionDetailsGrid;
        }
        #endregion

        #region "TransactionHasDetails"
        // FUNCTION RETURNS TRUE OR FALSE 
        // DEPENDING ON WHETHER OR NOT THE SENT TRANS_NUMBER
        // HAS THE VALUE IN TRANS_MAPPING
        public String TransactionHasDetails(String strTransNumber, String filerID)
        {
            return objEFSRepository.TransactionHasDetails(strTransNumber, filerID);
        }
        #endregion

        #region "DoesTransNumberExistInTemp"
        public String DoesTransNumberExistInTemp(String strTransNumber, String filerID)
        {
            return objEFSRepository.DoesTransNumberExistInTemp(strTransNumber, filerID);
        }
        #endregion

        #endregion


        // Creighton Newsom
        // ViewSupportingDocuments Page 11/2018
        #region "ViewSupportingDocuments"

        #region "GetViewSupportingDocumentsGrid"
        // FUNCTION GETS DATA FOR THE SUPPORTINGDOCUMENTS GRID
        // FILERID IS REQUIRED, REPORTYEAR AND DISCLOSUREPERIOD ARE OPTIONAL
        public IList<ViewSupportingDocumentsGridContract> GetViewSupportingDocumentsGridData(String strFilerID, String strReportYearID, String strDisclosurePeriodID)
        {
            IList<ViewSupportingDocumentsGridContract> lstViewSupportingDocumentsGrid = new List<ViewSupportingDocumentsGridContract>();
            ViewSupportingDocumentsGridContract objViewSupportingDocumentsGrid;

            var results = objEFSRepository.GetViewSupportingDocumentsGridData(strFilerID, strReportYearID, strDisclosurePeriodID);

            foreach (var item in results)
            {
                objViewSupportingDocumentsGrid = new ViewSupportingDocumentsGridContract();

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
            return lstViewSupportingDocumentsGrid;
        }
        #endregion

        #region "GetDisclosurePeriodsForYearAndFilerID"
        // FUNCTION GETS THE DISCLOSURE PERIODS BASED ON THE YEAR AND FILER ID
        public IList<DisclosurePreiodContract> GetDisclosurePeriodsForYearAndFilerID(String strFilerID, String strElectionYearID)
        {
            IList<DisclosurePreiodContract> lstDisclosurePreiodContract = new List<DisclosurePreiodContract>();
            DisclosurePreiodContract objDisclosurePreiodContract;

            var results = objEFSRepository.GetDisclosurePeriodsForYearAndFilerID(strFilerID, strElectionYearID);

            foreach (var item in results)
            {
                objDisclosurePreiodContract = new DisclosurePreiodContract();
                objDisclosurePreiodContract.FilingTypeId =item.FilingTypeId;
                objDisclosurePreiodContract.FilingDesc = item.FilingDesc;
                objDisclosurePreiodContract.FilingAbbrev = item.FilingAbbrev;
                lstDisclosurePreiodContract.Add(objDisclosurePreiodContract);
            }

            return lstDisclosurePreiodContract;
        }
        #endregion

        #region "GetElectionYearForFilerID_VSD"
        // THIS FUNCTION GETS THE ELECTION YEAR FOR FILTER DROPDOWN
        public IList<ElectionYearContract> GetElectionYearForFilerID_VSD(String strFilerID)
        {
            IList<ElectionYearContract> lstElectionYearContract = new List<ElectionYearContract>();
            ElectionYearContract objElectionYearContract;

            var results = objEFSRepository.GetElectionYearForFilerID_VSD(strFilerID);

            foreach (var item in results)
            {
                objElectionYearContract = new ElectionYearContract();
                objElectionYearContract.ElectionYearId = item.ElectionYearId;
                objElectionYearContract.ElectionYearValue = item.ElectionYearValue;
                lstElectionYearContract.Add(objElectionYearContract);
            }

            return lstElectionYearContract;
        }
        #endregion

        #endregion

        // Creighton Newsom
        // LoanAndLiabilityReconciliation Page
        #region "Loan and Liability Reconciliation"

        #region "GetLoanReceivedGridData"
        // FUNCTION GETS DATA FOR THE LOAN RECEIVED GRID
        // FILERID IS REQUIRED
        public IList<LoanReceivedGridContract> GetLoanReceivedGridData(String strFilerID)
        {
            IList<LoanReceivedGridContract> lstLoanReceivedGrid = new List<LoanReceivedGridContract>();
            LoanReceivedGridContract objLoanReceivedGrid;

            objLoanReceivedGrid = new LoanReceivedGridContract();

            var results = objEFSRepository.GetLoanReceivedGridData(strFilerID);

            foreach (var item in results)
            {
                objLoanReceivedGrid = new LoanReceivedGridContract();
                objLoanReceivedGrid.FilingTransID = item.FilingTransID;
                objLoanReceivedGrid.TransNumber = item.TransNumber;
                objLoanReceivedGrid.TransMapping = item.TransMapping;
                objLoanReceivedGrid.TransactionDate = item.TransactionDate;
                objLoanReceivedGrid.EntityName = item.EntityName;
                objLoanReceivedGrid.Amount = item.Amount;
                objLoanReceivedGrid.ElectionYear = item.ElectionYear;
                objLoanReceivedGrid.OfficeType = item.OfficeType;
                objLoanReceivedGrid.ElectionType = item.ElectionType;
                objLoanReceivedGrid.ElectionDate = item.ElectionDate;
                objLoanReceivedGrid.DisclosurePeriod = item.DisclosurePeriod;

                //add object to list
                lstLoanReceivedGrid.Add(objLoanReceivedGrid);
            }
            return lstLoanReceivedGrid;
        }

        #endregion

        #region "GetLoanPaymentGridData"
        // FUNCTION GETS DATA FOR THE LOAN PAYMENT GRID
        // FILERID IS REQUIRED
        public IList<LoanPaymentGridContract> GetLoanPaymentGridData(String strFilerID)
        {
            IList<LoanPaymentGridContract> lstLoanPaymentGrid = new List<LoanPaymentGridContract>();
            LoanPaymentGridContract objLoanPaymentGrid;

            objLoanPaymentGrid = new LoanPaymentGridContract();

            var results = objEFSRepository.GetLoanPaymentGridData(strFilerID);

            foreach (var item in results)
            {
                objLoanPaymentGrid = new LoanPaymentGridContract();
                objLoanPaymentGrid.FilingTransID = item.FilingTransID;
                objLoanPaymentGrid.TransNumber = item.TransNumber;
                objLoanPaymentGrid.TransMapping = item.TransMapping;
                objLoanPaymentGrid.TransactionDate = item.TransactionDate;
                objLoanPaymentGrid.EntityName = item.EntityName;
                objLoanPaymentGrid.Amount = item.Amount;
                objLoanPaymentGrid.OriginalLoanDate = item.OriginalLoanDate;
                objLoanPaymentGrid.ElectionYear = item.ElectionYear;
                objLoanPaymentGrid.OfficeType = item.OfficeType;
                objLoanPaymentGrid.ElectionType = item.ElectionType;
                objLoanPaymentGrid.ElectionDate = item.ElectionDate;
                objLoanPaymentGrid.DisclosurePeriod = item.DisclosurePeriod;

                //add object to list
                lstLoanPaymentGrid.Add(objLoanPaymentGrid);
            }
            return lstLoanPaymentGrid; 
        }

        #endregion

        #region "GetOutstandingLiabilityGridData"
        // FUNCTION GETS DATA FOR THE OUTSTANDING LIABILITIES GRID
        // FILERID AND DATATORETURN ARE REQUIRED
        // IF DATATORETURN IS 0, THEN ALL RECORDS ARE RETURNED
        // IF DATATORETURN IS 1 THEN RECORDS WHERE ORG_AMT = OWED_AMT ARE RETURNED
        // IF DATATORETURN IS 2 THEN RECORDS WHERE ORG_AMT <> OWED_AMT ARE RETURNED	
        public IList<OutstandingLiabilityGridContract> GetOutstandingLiabilityGridData(String strFilerID, int dataToReturn)
        {
            IList<OutstandingLiabilityGridContract> lstOutstandingLiabilityGrid = new List<OutstandingLiabilityGridContract>();
            OutstandingLiabilityGridContract objOutstandingLiabilityGrid;

            var results = objEFSRepository.GetOutstandingLiabilityGridData(strFilerID, dataToReturn);

            foreach (var item in results)
            {
                objOutstandingLiabilityGrid = new OutstandingLiabilityGridContract();
                objOutstandingLiabilityGrid.FilingTransID = item.FilingTransID;
                objOutstandingLiabilityGrid.TransNumber = item.TransNumber;
                objOutstandingLiabilityGrid.TransMapping = item.TransMapping;
                objOutstandingLiabilityGrid.TransactionDate = item.TransactionDate;
                objOutstandingLiabilityGrid.EntityName = item.EntityName;
                objOutstandingLiabilityGrid.OriginalAmount = item.OriginalAmount;
                objOutstandingLiabilityGrid.OutstandingAmount = item.OutstandingAmount;
                objOutstandingLiabilityGrid.ElectionYear = item.ElectionYear;
                objOutstandingLiabilityGrid.OfficeType = item.OfficeType;
                objOutstandingLiabilityGrid.ElectionType = item.ElectionType;
                objOutstandingLiabilityGrid.ElectionDate = item.ElectionDate;
                objOutstandingLiabilityGrid.DisclosurePeriod = item.DisclosurePeriod;

                //add object to list
                lstOutstandingLiabilityGrid.Add(objOutstandingLiabilityGrid);
            }
            return lstOutstandingLiabilityGrid;
        }

        #endregion

        #region "GetLiabilityLoanForgivenGridData"
        // FUNCTION GETS DATA FOR THE LIABILITY/LOAN FORGIVEN GRID
        // FILERID IS REQUIRED
        public IList<LiabilityLoanForgivenGridContract> GetLiabilityLoanFogivenGridData(String strFilerID, int dataToReturn)
        {
            IList<LiabilityLoanForgivenGridContract> lstLiabilityLoanForgivenGrid = new List<LiabilityLoanForgivenGridContract>();
            LiabilityLoanForgivenGridContract objLiabilityLoanForgivenGrid;

            var results = objEFSRepository.GetLiabilityLoanFogivenGridData(strFilerID, dataToReturn);

            foreach (var item in results)
            {
                objLiabilityLoanForgivenGrid = new LiabilityLoanForgivenGridContract();
                objLiabilityLoanForgivenGrid.FilingTransID = item.FilingTransID;
                objLiabilityLoanForgivenGrid.TransNumber = item.TransNumber;
                objLiabilityLoanForgivenGrid.TransMapping = item.TransMapping;
                objLiabilityLoanForgivenGrid.TransactionDate = item.TransactionDate;
                objLiabilityLoanForgivenGrid.EntityName = item.EntityName;
                objLiabilityLoanForgivenGrid.Amount = item.Amount;
                objLiabilityLoanForgivenGrid.OriginalDate = item.OriginalDate;
                objLiabilityLoanForgivenGrid.ElectionYear = item.ElectionYear;
                objLiabilityLoanForgivenGrid.OfficeType = item.OfficeType;
                objLiabilityLoanForgivenGrid.ElectionType = item.ElectionType;
                objLiabilityLoanForgivenGrid.ElectionDate = item.ElectionDate;
                objLiabilityLoanForgivenGrid.DisclosurePeriod = item.DisclosurePeriod;

                //add object to list
                lstLiabilityLoanForgivenGrid.Add(objLiabilityLoanForgivenGrid);
            }
            return lstLiabilityLoanForgivenGrid;
        }

        #endregion

        #region "GetExpenditurePaymentGridData"
        // FUNCTION GETS DATA FOR THE EXPENDITURES/PAYMENTS GRID
        // FILERID IS REQUIRED	
        public IList<ExpenditurePaymentGridContract> GetExpenditurePaymentGridData(String strFilerID)
        {
            IList<ExpenditurePaymentGridContract> lstExpenditurePaymentGrid = new List<ExpenditurePaymentGridContract>();
            ExpenditurePaymentGridContract objExpenditurePaymentGrid;

            objExpenditurePaymentGrid = new ExpenditurePaymentGridContract();

            var results = objEFSRepository.GetExpenditurePaymentGridData(strFilerID);

            foreach (var item in results)
            {
                objExpenditurePaymentGrid = new ExpenditurePaymentGridContract();
                objExpenditurePaymentGrid.FilingTransID = item.FilingTransID;
                objExpenditurePaymentGrid.TransNumber = item.TransNumber;
                objExpenditurePaymentGrid.TransMapping = item.TransMapping;
                objExpenditurePaymentGrid.TransactionDate = item.TransactionDate;
                objExpenditurePaymentGrid.EntityName = item.EntityName;
                objExpenditurePaymentGrid.Amount = item.Amount;
                objExpenditurePaymentGrid.Explanation = item.Explanation;
                objExpenditurePaymentGrid.ElectionYear = item.ElectionYear;
                objExpenditurePaymentGrid.OfficeType = item.OfficeType;
                objExpenditurePaymentGrid.ElectionType = item.ElectionType;
                objExpenditurePaymentGrid.ElectionDate = item.ElectionDate;
                objExpenditurePaymentGrid.DisclosurePeriod = item.DisclosurePeriod;

                //add object to list
                lstExpenditurePaymentGrid.Add(objExpenditurePaymentGrid);
            }
            return lstExpenditurePaymentGrid;
        }

        #endregion

        #region "Reconcile_Loan"
        // PROCEDURE RECONCILES LOANS, PAYMENTS, OUTSTANDING LIABILITIES AND LOAN FORGIVENS
        public String Reconcile_Loan(String Schedule_I_TransFilingID, String[] Schedule_J_TransFilingIDs, String[] Schedule_N_TransFilingIDs, String[] Schedule_K_TransFilingIDs, String User)
        {
            return objEFSRepository.Reconcile_Loan(Schedule_I_TransFilingID, Schedule_J_TransFilingIDs, Schedule_N_TransFilingIDs, Schedule_K_TransFilingIDs, User);
        }
        #endregion

        #region "Reconcile_Liability"
        // PROCEDURE RECONCILES THE ORIGINAL LIABILITY WITH EXPENDITURES, OUTSTANDING
        // LIABILITIES AND LOANS FORGIVEN
        public String Reconcile_Liability(String Schedule_N_OriginalLiability_TransFilingID, String[] Schedule_F_TransFilingIDs, String[] Schedule_N_TransFilingIDs, String[] Schedule_K_TransFilingIDs, String User)
        {
            return objEFSRepository.Reconcile_Liability(Schedule_N_OriginalLiability_TransFilingID, Schedule_F_TransFilingIDs, Schedule_N_TransFilingIDs, Schedule_K_TransFilingIDs, User);
        }
        #endregion

        #region "GetUnreconciledLoansOrLiabilities"
        // FUNCTION RETURNS THE NUMBER OF LOANS +
        // THE NUMBER OF LIABILITIES. IF THE RESULT IS 0 THEN THE 
        // RECONCILIATION PAGE DOESN'T NEED TO LOAD. IT WILL CALL 
        // UPDATEREQUIREDFILER METHOD AND THAT IS IT.
        public String GetUncreconciledLoansAndLiabilities(String strFilerID)
        {
            return objEFSRepository.GetUncreconciledLoansAndLiabilities(strFilerID);
        }
        #endregion

        #region "UpdateRequiredFilerForReconcile"
        // THIS METHOD SIMPLY UPDATE THE R_RECONCILED AND MODIFIED_BY COLUMNS
        // IN THE REQUIRED_FILER TABLE. IT IS CALLED WHEN THERE ARE NO LOANS 
        // OR LIABILITIES OR WHEN THEY HAVE ALL BEEN RECONCILED
        public String UpdateRequiredFilerForReconcile(String strFilerID, String strUser)
        {
            return objEFSRepository.UpdateRequiredFilerForReconcile(strFilerID, strUser);
        }
        #endregion

        #region "GetMinReconciledOwedAmount"
        public String GetMinReconciledOwedAmount(String strTransID, String strOrgAmount, String filerID)
        {
            return objEFSRepository.GetMinReconciledOwedAmount(strTransID, strOrgAmount, filerID);
        }
        #endregion

        #endregion


        /// <summary>
        /// Get Outstanding Forgiven
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <param name="strtransNumber"></param>
        /// <returns></returns>
        public IList<OriginalAmountContract> GetOutstandingAmountLiabData_Forgiven(String strFilingEntityId, String strtransNumber, String strFilingsId)
        {
            IList<OriginalAmountContract> lstOriginalAmountContract = new List<OriginalAmountContract>();
            OriginalAmountContract objOriginalAmountContract;

            var results = objEFSRepository.GetOutstandingAmountLiabData_Forgiven(strFilingEntityId, strtransNumber, strFilingsId);

            foreach (var item in results)
            {
                objOriginalAmountContract = new OriginalAmountContract();
                objOriginalAmountContract.OriginalAmountId = item.OriginalAmountId;
                objOriginalAmountContract.OutstandingAmount = item.OutstandingAmount;
                lstOriginalAmountContract.Add(objOriginalAmountContract);
            }
            return lstOriginalAmountContract;
        }

        /// <summary>
        /// Check Amend Status
        /// </summary>
        /// <param name="filings_ID"></param>
        /// <returns></returns>
        public IList<CheckAmendStatusContract> GetAmendStatus(FilingTransDataContract objFilingTransDataContract)
        {
            IList<CheckAmendStatusContract> lstCheckAmendStatusEntity = new List<CheckAmendStatusContract>();
            CheckAmendStatusContract objCheckAmendStatusEntity;

            FilingTransDataEntity objFilingTransDataEntity = new FilingTransDataEntity();
            objFilingTransDataEntity.FilerId = objFilingTransDataContract.FilerId;
            objFilingTransDataEntity.ReportYearId = objFilingTransDataContract.ReportYearId;
            objFilingTransDataEntity.OfficeTypeId = objFilingTransDataContract.OfficeTypeId;
            objFilingTransDataEntity.DisclosurePeriod = objFilingTransDataContract.DisclosurePeriod;
            objFilingTransDataEntity.ElectionType = objFilingTransDataContract.ElectionType;
            objFilingTransDataEntity.ElectionDateId = objFilingTransDataContract.ElectionDateId;
            objFilingTransDataEntity.FilingDate = objFilingTransDataContract.FilingDate;

            var results = objEFSRepository.GetAmendStatus(objFilingTransDataEntity);

            foreach (var item in results)
            {
                objCheckAmendStatusEntity = new CheckAmendStatusContract();
                objCheckAmendStatusEntity.Submit_Date = item.Submit_Date.ToString();
                objCheckAmendStatusEntity.IsAmend = item.IsAmend.ToString();
                lstCheckAmendStatusEntity.Add(objCheckAmendStatusEntity);
            }

            return lstCheckAmendStatusEntity;
        }

        /// <summary>
        /// GetExpSubContrTotAmt_LoanDetails
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public String GetExpSubContrTotAmt_LoanDetails(String strTransNumber, String filerID)
        {
            String strExpSubContrTotAmt = String.Empty;

            strExpSubContrTotAmt = objEFSRepository.GetExpSubContrTotAmt_LoanDetails(strTransNumber, filerID);

            return strExpSubContrTotAmt;
        }

        /// <summary>
        /// Get Edit Flag
        /// </summary>
        /// <param name="objFilingTransDataContract"></param>
        /// <returns></returns>
        public IList<GetEditFlagDataContract> GetEditFlag(FilingTransDataContract objFilingTransDataContract)
        {
            IList<GetEditFlagDataContract> lstGetEditFlagDataContract = new List<GetEditFlagDataContract>();
            GetEditFlagDataContract objGetEditFlagDataContract;

            FilingTransDataEntity objFilingTransDataEntity = new FilingTransDataEntity();
            objFilingTransDataEntity.FilerId = objFilingTransDataContract.FilerId;
            objFilingTransDataEntity.ReportYearId = objFilingTransDataContract.ReportYearId;
            objFilingTransDataEntity.ElectionType = objFilingTransDataContract.ElectionType;
            objFilingTransDataEntity.OfficeTypeId = objFilingTransDataContract.OfficeTypeId;
            objFilingTransDataEntity.DisclosurePeriod = objFilingTransDataContract.DisclosurePeriod;
            objFilingTransDataEntity.FilingDate = objFilingTransDataContract.FilingDate;
            objFilingTransDataEntity.ElectionDateId = objFilingTransDataContract.ElectionDateId;
            objFilingTransDataEntity.Created_By = objFilingTransDataContract.Created_By;
            objFilingTransDataEntity.TransNumber = objFilingTransDataContract.TransNumber;
            objFilingTransDataEntity.MunicipalityID = objFilingTransDataContract.MunicipalityID;

            var results = objEFSRepository.GetEditFlag(objFilingTransDataEntity);

            foreach (var item in results)
            {
                objGetEditFlagDataContract = new GetEditFlagDataContract();
                objGetEditFlagDataContract.Is_Edit = item.Is_Edit.ToString();
                lstGetEditFlagDataContract.Add(objGetEditFlagDataContract);
            }

            return lstGetEditFlagDataContract;
        }

        /// <summary>
        /// ValidateFilings
        /// </summary>
        /// <param name="objFilingTransDataContract"></param>
        /// <returns></returns>
        public IList<GetEditFlagDataContract> ValidateFilings(FilingTransDataContract objFilingTransDataContract)
        {
            IList<GetEditFlagDataContract> lstGetEditFlagDataContract = new List<GetEditFlagDataContract>();
            GetEditFlagDataContract objGetEditFlagDataContract;

            FilingTransDataEntity objFilingTransDataEntity = new FilingTransDataEntity();
            objFilingTransDataEntity.FilerId = objFilingTransDataContract.FilerId;            
            objFilingTransDataEntity.FilingDate = objFilingTransDataContract.FilingDate;            

            var results = objEFSRepository.ValidateFilings(objFilingTransDataEntity);

            foreach (var item in results)
            {
                objGetEditFlagDataContract = new GetEditFlagDataContract();
                objGetEditFlagDataContract.VALIDATE_FILINGS = item.VALIDATE_FILINGS.ToString();
                lstGetEditFlagDataContract.Add(objGetEditFlagDataContract);
            }

            return lstGetEditFlagDataContract;
        }

        /// <summary>
        /// Add Viewable Column
        /// </summary>
        /// <param name="filer_ID"></param>
        /// <param name="created_By"></param>
        /// <returns></returns>
        public Boolean AddViewableColumn(string filer_ID, string created_By)
        {
            Boolean result = objEFSRepository.AddViewableColumn(filer_ID, created_By);            

            return result;
        }

        /// <summary>
        /// GetContrInKindPartnersData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<ContrInKindPartnersContract> GetLoanReceviedPartnersData(String strFilingTransId, String strFilerId)
        {
            IList<ContrInKindPartnersContract> lstContrInKindPartnersContract = new List<ContrInKindPartnersContract>();
            ContrInKindPartnersContract objContrInKindPartnersContract;

            var results = objEFSRepository.GetLoanReceviedPartnersData(strFilingTransId, strFilerId);

            foreach (var item in results)
            {
                objContrInKindPartnersContract = new ContrInKindPartnersContract();
                objContrInKindPartnersContract.FilingTransId = item.FilingTransId;
                objContrInKindPartnersContract.FilingEntityId = item.FilingEntityId;
                objContrInKindPartnersContract.PartnershipName = item.PartnershipName;
                objContrInKindPartnersContract.PartnerFirstName = item.PartnerFirstName;
                objContrInKindPartnersContract.PartnerMiddleName = item.PartnerMiddleName;
                objContrInKindPartnersContract.PartnerLastName = item.PartnerLastName;
                objContrInKindPartnersContract.PartnerStreetNo = item.PartnerStreetNo;
                objContrInKindPartnersContract.PartnerStreetName = item.PartnerStreetName;
                objContrInKindPartnersContract.PartnerCity = item.PartnerCity;
                objContrInKindPartnersContract.PartnerState = item.PartnerState;
                objContrInKindPartnersContract.PartnerZip5 = item.PartnerZip5;
                objContrInKindPartnersContract.PartnershipCountry = item.PartnershipCountry;
                objContrInKindPartnersContract.PartnerAmountAttributed = item.PartnerAmountAttributed;
                objContrInKindPartnersContract.PartnerExplanation = item.PartnerExplanation;
                objContrInKindPartnersContract.RUnitemzied = item.RItemized;
                objContrInKindPartnersContract.TransNumber = item.TransNumber;
                objContrInKindPartnersContract.TransMapping = item.TransMapping;
                objContrInKindPartnersContract.TreasurerEmployer = item.TreasurerEmployer;
                objContrInKindPartnersContract.TreasurerOccupation = item.TreasurerOccupation;
                objContrInKindPartnersContract.TreaAddress = item.TreaAddress;
                objContrInKindPartnersContract.TreaAddr1 = item.TreaAddr1;
                objContrInKindPartnersContract.TreaCity = item.TreaCity;
                objContrInKindPartnersContract.TreaState = item.TreaState;
                objContrInKindPartnersContract.TreaZipCode = item.TreaZipCode;
                objContrInKindPartnersContract.RContributions = item.RContributions;
                lstContrInKindPartnersContract.Add(objContrInKindPartnersContract);
            }

            return lstContrInKindPartnersContract;
        }

        /// <summary>
        /// Validate Loan Received Delete functionality
        /// </summary>
        /// <param name="objFilingTransDataContract"></param>
        /// <returns></returns>
        public IList<GetEditFlagDataContract> ValidateLoanReceived_Delete(FilingTransDataContract objFilingTransDataContract)
        {
            IList<GetEditFlagDataContract> lstGetEditFlagDataContract = new List<GetEditFlagDataContract>();
            GetEditFlagDataContract objGetEditFlagDataContract;

            FilingTransDataEntity objFilingTransDataEntity = new FilingTransDataEntity();
            objFilingTransDataEntity.Loan_Lib_Num = objFilingTransDataContract.Loan_Lib_Num;
            objFilingTransDataEntity.FilerId = objFilingTransDataContract.FilerId;
            var results = objEFSRepository.ValidateLoanReceived_Delete(objFilingTransDataEntity);

            foreach (var item in results)
            {
                objGetEditFlagDataContract = new GetEditFlagDataContract();
                objGetEditFlagDataContract.VALIDATE_FILINGS = item.VALIDATE_FILINGS.ToString();
                lstGetEditFlagDataContract.Add(objGetEditFlagDataContract);
            }

            return lstGetEditFlagDataContract;
        }

        #region GetExpPaymentExistsSchedL
        /// <summary>
        /// GetExpPaymentExistsSchedL
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public String GetExpPaymentExistsSchedL(String strTransNumber, String filerID, String strSchedID)
        {           
            String results = objEFSRepository.GetExpPaymentExistsSchedL(strTransNumber, filerID, strSchedID);
                        
            return results;
        }
        #endregion GetExpPaymentExistsSchedL

        #region GetContributionsExistsSchedM
        /// <summary>
        /// GetContributionsExistsSchedM
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public String GetContributionsExistsSchedM(String strTransNumber, String filerID)
        {
            String results = objEFSRepository.GetContributionsExistsSchedM(strTransNumber, filerID);                        

            return results;
        }
        #endregion GetContributionsExistsSchedM

        #region GetFilingsSubmittedOrNot
        /// <summary>
        /// GetFilingsSubmittedOrNot
        /// </summary>
        /// <param name="strFilingsId"></param>
        /// <returns></returns>
        public String GetFilingsSubmittedOrNot(String strFilingsId)
        {            
            String strExists = objEFSRepository.GetFilingsSubmittedOrNot(strFilingsId);                     

            return strExists;
        }
        #endregion GetFilingsSubmittedOrNot

        #region GetExpRefundedSchedFTotalAmt
        /// <summary>
        /// GetExpRefundedSchedFTotalAmt
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public String GetExpRefundedSchedFTotalAmt(String strTransNumber, String filerID)
        {
            String strExpRefundedAmt = objEFSRepository.GetExpRefundedSchedFTotalAmt(strTransNumber, filerID);
         
            return strExpRefundedAmt;
        }
        #endregion GetExpRefundedSchedFTotalAmt

        #region GetContrRefundedSchedABCTotalAmt
        /// <summary>
        /// GetContrRefundedSchedABCTotalAmt
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public String GetContrRefundedSchedABCTotalAmt(String strTransNumber, String filerID)
        {                   
            String strContrRefundedAmt = objEFSRepository.GetContrRefundedSchedABCTotalAmt(strTransNumber, filerID);                        

            return strContrRefundedAmt;
        }
        #endregion GetContrRefundedSchedABCTotalAmt

        #region GetCommEditIETransData
        /// <summary>
        /// GetCommEditIETransData
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataContract> GetCommEditIETransData(String strTransNumber, String filerID)
        {
            IList<FilingTransactionDataContract> lstFilingTransactionDataContract = new List<FilingTransactionDataContract>();
            FilingTransactionDataContract objFilingTransactionDataContract;

            var results = objEFSRepository.GetCommEditIETransData(strTransNumber, filerID);

            foreach (var item in results)
            {
                objFilingTransactionDataContract = new FilingTransactionDataContract();
                objFilingTransactionDataContract.FilingTransId = item.FilingTransId;
                objFilingTransactionDataContract.FilingSchedId = item.FilingSchedId;
                objFilingTransactionDataContract.ContributorTypeId = item.ContributorTypeId;
                objFilingTransactionDataContract.ContributorTypeDesc = item.ContributorTypeDesc;
                objFilingTransactionDataContract.PaymentTypeId = item.PaymentTypeId;
                objFilingTransactionDataContract.SubmissionDate = item.SubmissionDate;
                objFilingTransactionDataContract.SchedDate = item.SchedDate;                
                objFilingTransactionDataContract.FilingSchedDesc = item.FilingSchedDesc;
                objFilingTransactionDataContract.FilingEntityId = item.FilingEntityId;
                objFilingTransactionDataContract.FilingEntityName = item.FilingEntityName;
                objFilingTransactionDataContract.FilingFirstName = item.FilingFirstName;
                objFilingTransactionDataContract.FilingMiddleName = item.FilingMiddleName;
                objFilingTransactionDataContract.FilingLastName = item.FilingLastName;
                objFilingTransactionDataContract.FilingStreetNumber = item.FilingStreetNumber;
                objFilingTransactionDataContract.FilingStreetName = item.FilingStreetName;
                objFilingTransactionDataContract.FilingCity = item.FilingCity;
                objFilingTransactionDataContract.FilingState = item.FilingState;
                objFilingTransactionDataContract.FilingZip = item.FilingZip;
                objFilingTransactionDataContract.FilingCountry = item.FilingCountry;
                objFilingTransactionDataContract.PaymentTypeDesc = item.PaymentTypeDesc;
                objFilingTransactionDataContract.PayNumber = item.PayNumber;
                objFilingTransactionDataContract.OriginalAmount = item.OriginalAmount;
                objFilingTransactionDataContract.TransExplanation = item.TransExplanation;
                objFilingTransactionDataContract.RItemized = item.RItemized;                
                objFilingTransactionDataContract.CountyDesc = item.CountyDesc;
                objFilingTransactionDataContract.RAmend = item.RAmend;
                objFilingTransactionDataContract.RStatus = item.RStatus;                
                objFilingTransactionDataContract.MunicipalityDesc = item.MunicipalityDesc;
                objFilingTransactionDataContract.LoanerCodeID = item.LoanerCodeId;
                objFilingTransactionDataContract.LoanerCode = item.LoanerCode;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.CreatedDate = item.CreatedDate;
                objFilingTransactionDataContract.TreasurerFirstName = item.TreasurerFirstName;
                objFilingTransactionDataContract.TreasurerLastName = item.TreasurerLastName;
                objFilingTransactionDataContract.TreasurerMiddleName = item.TreasurerMiddleName;
                objFilingTransactionDataContract.TreasurerOccuptaion = item.TreasurerOccuptaion;
                objFilingTransactionDataContract.TreasurerEmployer = item.TreasurerEmployer;
                objFilingTransactionDataContract.TreasurerStreetAddress = item.TreasurerStreetAddress;
                objFilingTransactionDataContract.TreasurerCity = item.TreasurerCity;
                objFilingTransactionDataContract.TreasurerState = item.TreasurerState;
                objFilingTransactionDataContract.TreasurerZip = item.TreasurerZip;
                objFilingTransactionDataContract.ContributorOccupation = item.ContributorOccupation;
                objFilingTransactionDataContract.ContributorEmployer = item.ContributorEmployer;
                objFilingTransactionDataContract.IEDescription = item.IEDescription;
                objFilingTransactionDataContract.CandBallotPropReference = item.CandBallotPropReference;
                objFilingTransactionDataContract.IESupported = item.IESupported;                
                objFilingTransactionDataContract.AddrId = item.AddrId;
                objFilingTransactionDataContract.TreasId = item.TreasId;
                objFilingTransactionDataContract.LoanLiablityNumber = item.LoanLiablityNumber;
                objFilingTransactionDataContract.TransNumber = item.TransNumber;
                objFilingTransactionDataContract.TransMapping = item.TransMapping;
                objFilingTransactionDataContract.DateIncurredOrgAmtId = item.DateIncurredOrgAmtId;
                objFilingTransactionDataContract.RLiability = item.RLiability;
                objFilingTransactionDataContract.RSubcontractor = item.RSubcontractor;
                objFilingTransactionDataContract.OwedAmount = item.OwedAmount;
                objFilingTransactionDataContract.PurposeCodeId = item.PurposeCodeId;
                lstFilingTransactionDataContract.Add(objFilingTransactionDataContract);
            }

            return lstFilingTransactionDataContract;
        }
        #endregion GetCommEditIETransData

        #region LiabilityPrevFlngsOrgAutoCreatedExts
        /// <summary>
        /// LiabilityPrevFlngsOrgAutoCreatedExts
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <param name="strFilingsId"></param>
        /// <returns></returns>
        public String LiabilityPrevFlngsOrgAutoCreatedExts(String strTransNumber, String strFilingsId, String filerID)
        {
            String strExists = String.Empty;

            strExists = objEFSRepository.LiabilityPrevFlngsOrgAutoCreatedExts(strTransNumber, strFilingsId, filerID);                        

            return strExists;
        }
        #endregion LiabilityPrevFlngsOrgAutoCreatedExts

        #region AddNonItemSetPrefPerFiler
        /// <summary>
        /// AddNonItemSetPrefPerFiler
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <param name="strCreatedBy"></param>
        /// <returns></returns>
        public Boolean AddNonItemSetPrefPerFiler(String strFilerId, String strFilingTypeId, String strCreatedBy)
        {
            Boolean returnValue = objEFSRepository.AddNonItemSetPrefPerFiler(strFilerId, strFilingTypeId, strCreatedBy);

            return returnValue;
        }
        #endregion AddNonItemSetPrefPerFiler

        #region GetEFSPDFBytes
        /// <summary>
        /// GetEFSPDFBytes
        /// </summary>
        /// <param name="objEFSPDFRequestContract"></param>
        /// <returns></returns>
        public EFSPDFResponseContract GetEFSPDFBytes(EFSPDFRequestContract objEFSPDFRequestContract)
        {
            EFSPDFResponseContract objEFSPDFResponseContract = new EFSPDFResponseContract();

            EFSPDFRequestEntity objEFSPDFRequestEntity = new EFSPDFRequestEntity();

            objEFSPDFRequestEntity.ReportName = objEFSPDFRequestContract.ReportName;
            objEFSPDFRequestEntity.FilerId = objEFSPDFRequestContract.FilerId;
            objEFSPDFRequestEntity.ElectionYearId = objEFSPDFRequestContract.ElectionYearId;
            objEFSPDFRequestEntity.OfficeTypeId = objEFSPDFRequestContract.OfficeTypeId;
            objEFSPDFRequestEntity.FilingTypeId = objEFSPDFRequestContract.FilingTypeId;
            objEFSPDFRequestEntity.FilingDate = objEFSPDFRequestContract.FilingDate;
            objEFSPDFRequestEntity.ElectionTypeID = objEFSPDFRequestContract.ElectionTypeID;
            objEFSPDFRequestEntity.ElectionDateID = objEFSPDFRequestContract.ElectionDateID;
            objEFSPDFRequestEntity.SubmitDate = objEFSPDFRequestContract.SubmitDate;

            var results = objEFSRepository.GetEFSPDFBytes(objEFSPDFRequestEntity);

            if (results != null)
            {
                objEFSPDFResponseContract.fileByte = results.fileByte;
                objEFSPDFResponseContract.fileURL = results.fileURL;
            }

            return objEFSPDFResponseContract;
        }
        #endregion GetEFSPDFBytes

        #region GetImportDisclosureRptsData
        /// <summary>
        /// GetImportDisclosureRptsData
        /// </summary>
        /// <param name="txtFilerID"></param>
        /// <param name="strReportYear"></param>
        /// <returns></returns>
        public IList<ImportDisclosureRptsDataContract> GetImportDisclosureRptsData(String txtFilerID, String strReportYear)
        {
            List<ImportDisclosureRptsDataContract> lstImportDisclosureRptsDataContract = new List<ImportDisclosureRptsDataContract>();
            ImportDisclosureRptsDataContract objImportDisclosureRptsDataContract;

            var results = objEFSRepository.GetImportDisclosureRptsData(txtFilerID, strReportYear);

            foreach (var item in results)
            {
                objImportDisclosureRptsDataContract = new ImportDisclosureRptsDataContract();
                objImportDisclosureRptsDataContract.DateImported = item.DateImported;
                objImportDisclosureRptsDataContract.TransactionType = item.TransactionType;
                objImportDisclosureRptsDataContract.ReportYear = item.ReportYear;
                objImportDisclosureRptsDataContract.FilerType = item.FilerType;
                objImportDisclosureRptsDataContract.ReportType = item.ReportType;
                objImportDisclosureRptsDataContract.ElectionDate = item.ElectionDate;
                objImportDisclosureRptsDataContract.DisclosurePeriod = item.DisclosurePeriod;
                objImportDisclosureRptsDataContract.SubmissionStatus = item.SubmissionStatus;
                objImportDisclosureRptsDataContract.FileSize = item.FileSize;
                objImportDisclosureRptsDataContract.NoOfTrans = item.NoOfTrans;
                objImportDisclosureRptsDataContract.ElectionYearId = item.ElectionYearId;
                objImportDisclosureRptsDataContract.OfficeTypeId = item.OfficeTypeId;
                objImportDisclosureRptsDataContract.ElectionTypeId = item.ElectionTypeId;
                objImportDisclosureRptsDataContract.ElectionDateId = item.ElectionDateId;
                objImportDisclosureRptsDataContract.FilingTypeId = item.FilingTypeId;
                objImportDisclosureRptsDataContract.FilingCategoryId = item.FilingCategoryId;
                objImportDisclosureRptsDataContract.VendorName = item.VendorName;
                lstImportDisclosureRptsDataContract.Add(objImportDisclosureRptsDataContract);
            }

            return lstImportDisclosureRptsDataContract;
        }
        #endregion GetImportDisclosureRptsData

        #region GetVendorNamesData
        /// <summary>
        /// GetVendorNamesData
        /// </summary>
        /// <returns></returns>
        public IList<VendorNamesContract> GetVendorNamesData()
        {
            List<VendorNamesContract> lstVendorNamesContract = new List<VendorNamesContract>();
            VendorNamesContract objVendorNamesContract;

            var results = objEFSRepository.GetVendorNamesData();

            foreach (var item in results)
            {
                objVendorNamesContract = new VendorNamesContract();
                objVendorNamesContract.VendorId = item.VendorId;
                objVendorNamesContract.VendorName = item.VendorName;
                lstVendorNamesContract.Add(objVendorNamesContract);
            }

            return lstVendorNamesContract;
        }
        #endregion GetVendorNamesData

        #region GetFilingDateCheckValues
        /// <summary>
        /// GetFilingDateCheckValues
        /// </summary>
        /// <param name="ImportDisclsoureRptsFilingsContract"></param>
        /// <returns></returns>
        public IList<CheckFilingDateContract> GetFilingDateCheckValues(ImportDisclsoureRptsFilingsContract objImportDisclsoureRptsFilingsContract)
        {
            ImportDisclsoureRptsFilingsEntity objImportDisclsoureRptsFilingsEntity = new ImportDisclsoureRptsFilingsEntity();
            IList<CheckFilingDateContract> lstCheckFilingDateContract = new List<CheckFilingDateContract>();
            CheckFilingDateContract objCheckFilingDateContract;
            
            objImportDisclsoureRptsFilingsEntity.FilingPeriodId = objImportDisclsoureRptsFilingsContract.FilingPeriodId;            
            objImportDisclsoureRptsFilingsEntity.ElectId = objImportDisclsoureRptsFilingsContract.ElectId;

            var results = objEFSRepository.GetFilingDateCheckValues(objImportDisclsoureRptsFilingsEntity);

            foreach (var item in results)
            {
                objCheckFilingDateContract = new CheckFilingDateContract();
                objCheckFilingDateContract.ElectionYearId = item.ElectionYearId;
                objCheckFilingDateContract.ElectionTypeId = item.ElectionTypeId;
                objCheckFilingDateContract.OfficeTypeId = item.OfficeTypeId;
                objCheckFilingDateContract.FilingTypeId = item.FilingTypeId;
                objCheckFilingDateContract.ElectionDateId = item.ElectionDateId;
                lstCheckFilingDateContract.Add(objCheckFilingDateContract);
            }

            return lstCheckFilingDateContract;
        }
        #endregion GetFilingDateCheckValues

        #region GetFilingsIdForUploadData
        /// <summary>
        /// GetFilingsIdForUploadData
        /// </summary>
        /// <param name="objImportDisclsoureRptsFilings"></param>
        /// <returns></returns>
        public IList<FilingsForFilingCutOffDateContract> GetFilingsIdForUploadData(ImportDisclsoureRptsFilingsContract objImportDisclsoureRptsFilingsContract)
        {
            ImportDisclsoureRptsFilingsEntity objImportDisclsoureRptsFilingsEntity = new ImportDisclsoureRptsFilingsEntity();
            IList<FilingsForFilingCutOffDateContract> lstFilingsForFilingCutOffDateContract = new List<FilingsForFilingCutOffDateContract>();
            FilingsForFilingCutOffDateContract objFilingsForFilingCutOffDateContract;

            objImportDisclsoureRptsFilingsEntity.FilerId = objImportDisclsoureRptsFilingsContract.FilerId;
            objImportDisclsoureRptsFilingsEntity.FilingPeriodId = objImportDisclsoureRptsFilingsContract.FilingPeriodId;
            objImportDisclsoureRptsFilingsEntity.FilingCategoryId = objImportDisclsoureRptsFilingsContract.FilingCategoryId;
            objImportDisclsoureRptsFilingsEntity.ElectId = objImportDisclsoureRptsFilingsContract.ElectId;
            objImportDisclsoureRptsFilingsEntity.ResigTermTypeId = objImportDisclsoureRptsFilingsContract.ResigTermTypeId;
            objImportDisclsoureRptsFilingsEntity.RFilingDate = objImportDisclsoureRptsFilingsContract.RFilingDate;
            objImportDisclsoureRptsFilingsEntity.CreatedBy = objImportDisclsoureRptsFilingsContract.CreatedBy;

            var results = objEFSRepository.GetFilingsIdForUploadData(objImportDisclsoureRptsFilingsEntity);

            foreach (var item in results)
            {
                objFilingsForFilingCutOffDateContract = new FilingsForFilingCutOffDateContract();
                objFilingsForFilingCutOffDateContract.FilingsId = item.FilingsId;
                objFilingsForFilingCutOffDateContract.ElectionYearId = item.ElectionYearId;
                objFilingsForFilingCutOffDateContract.ElectionTypeId = item.ElectionTypeId;
                objFilingsForFilingCutOffDateContract.OfficeTypeId = item.OfficeTypeId;
                objFilingsForFilingCutOffDateContract.FilingTypeId = item.FilingTypeId;
                objFilingsForFilingCutOffDateContract.ElectionDateId = item.ElectionDateId;
                objFilingsForFilingCutOffDateContract.FilingDate = item.FilingDate;
                lstFilingsForFilingCutOffDateContract.Add(objFilingsForFilingCutOffDateContract);
            }

            return lstFilingsForFilingCutOffDateContract;
        }
        #endregion GetFilingsIdForUploadData

        #region GetFilingsExistsorNot
        /// <summary>
        /// GetFilingsExistsorNot
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <returns></returns>
        public String GetFilingsExistsorNot(String strFilerId)
        {
            var results = objEFSRepository.GetFilingsExistsorNot(strFilerId);

            return results.ToString();
        }
        #endregion GetFilingsExistsorNot

        #region LoanLiabilityExists
        /// <summary>
        /// LoanLiabilityExists
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strTransNumber"></param>
        /// <param name="strLoanLiabilityNumber"></param>
        /// <returns></returns>
        public Boolean LoanLiabilityExists(String strFilerId, String strTransNumber, String strLoanLiabilityNumber)
        {
            Boolean results = objEFSRepository.LoanLiabilityExists(strFilerId, strTransNumber, strLoanLiabilityNumber);

            return results;
        }
        #endregion LoanLiabilityExists

        #region AddVendorImportFileIntoTempDatabase
        /// <summary>
        /// AddVendorImportFileIntoTempDatabase
        /// </summary>
        /// <param name="lstFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean AddVendorImportFileIntoTempDatabase(IList<FilingTransactionsContract> lstFilingTransactionsContract, VendorImportDataContract objVendorImportDataContract)
        {
            IList<FilingTransactionsEntity> lstFilingTransactionsEntity = new List<FilingTransactionsEntity>();
            FilingTransactionsEntity objFilingTransactionsEntity;
            VendorImportDataEntity objVendorImportDataEntity;

            foreach (var item in lstFilingTransactionsContract)
            {
                objFilingTransactionsEntity = new FilingTransactionsEntity();
                objFilingTransactionsEntity.FilingEntId = item.FilingEntId;
                objFilingTransactionsEntity.FilingsId = item.FilingsId;
                objFilingTransactionsEntity.Loan_Lib_Number = item.Loan_Lib_Number;
                objFilingTransactionsEntity.TransNumber = item.TransNumber;
                objFilingTransactionsEntity.TransMapping = item.TransMapping;
                objFilingTransactionsEntity.FlngEntName = item.FlngEntName;
                objFilingTransactionsEntity.FlngEntFirstName = item.FlngEntFirstName;
                objFilingTransactionsEntity.FlngEntMiddleName = item.FlngEntMiddleName;
                objFilingTransactionsEntity.FlngEntLastName = item.FlngEntLastName;
                objFilingTransactionsEntity.FlngEntStrName = item.FlngEntStrName;
                objFilingTransactionsEntity.FlngEntCity = item.FlngEntCity;
                objFilingTransactionsEntity.FlngEntState = item.FlngEntState;
                objFilingTransactionsEntity.FlngEntZip = item.FlngEntZip;
                objFilingTransactionsEntity.FlngEntCountry = item.FlngEntCountry;
                objFilingTransactionsEntity.FilingSchedId = item.FilingSchedId;
                objFilingTransactionsEntity.ContributorTypeId = item.ContributorTypeId;
                objFilingTransactionsEntity.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionsEntity.PaymentTypeId = item.PaymentTypeId;
                objFilingTransactionsEntity.ReceiptTypeId = item.ReceiptTypeId;
                objFilingTransactionsEntity.PurposeCodeId = item.PurposeCodeId;
                objFilingTransactionsEntity.TransferTypeId = item.TransferTypeId;
                objFilingTransactionsEntity.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionsEntity.LoanOtherId = item.LoanOtherId;
                objFilingTransactionsEntity.MunicipalityID = item.MunicipalityID;
                objFilingTransactionsEntity.TreasId = item.TreasId;
                objFilingTransactionsEntity.AddrId = item.AddrId;
                objFilingTransactionsEntity.ParentFilingEntityId = item.ParentFilingEntityId;
                objFilingTransactionsEntity.OfficeID = item.OfficeID;
                objFilingTransactionsEntity.DistrictID = item.DistrictID;
                objFilingTransactionsEntity.SchedDate = item.SchedDate;
                objFilingTransactionsEntity.OrgDate = item.OrgDate;
                objFilingTransactionsEntity.PayNumber = item.PayNumber;
                objFilingTransactionsEntity.OrgAmt = item.OrgAmt;
                objFilingTransactionsEntity.OwedAmt = item.OwedAmt;
                objFilingTransactionsEntity.TransExplanation = item.TransExplanation;
                objFilingTransactionsEntity.ElectionYear = item.ElectionYear;
                objFilingTransactionsEntity.RBankLoan = item.RBankLoan;
                objFilingTransactionsEntity.DistOffCandBalProp = item.DistOffCandBalProp;
                objFilingTransactionsEntity.ContributorOccupation = item.ContributorOccupation;
                objFilingTransactionsEntity.ContributorEmployer = item.ContributorEmployer;
                objFilingTransactionsEntity.IEDescription = item.IEDescription;
                objFilingTransactionsEntity.TreasurerOccupation = item.TreasurerOccupation;
                objFilingTransactionsEntity.TreasurerEmployer = item.TreasurerEmployer;
                objFilingTransactionsEntity.TreasurerStreetAddress = item.TreasurerStreetAddress;
                objFilingTransactionsEntity.TreasurerCity = item.TreasurerCity;
                objFilingTransactionsEntity.TreasurerState = item.TreasurerState;
                objFilingTransactionsEntity.TreasurerZip = item.TreasurerZip;
                objFilingTransactionsEntity.ExistsLiabTransNumber = item.ExistsLiabTransNumber;
                objFilingTransactionsEntity.RIESupported = item.RIESupported;
                objFilingTransactionsEntity.RSubcontractor = item.RSubcontractor;
                objFilingTransactionsEntity.RLiability = item.RLiability;
                objFilingTransactionsEntity.RItemized = item.RItemized;
                objFilingTransactionsEntity.RIEIncluded = item.RIEIncluded;
                objFilingTransactionsEntity.RAmend = item.RAmend;
                objFilingTransactionsEntity.CreatedBy = item.CreatedBy;
                objFilingTransactionsEntity.RParent = item.RParent;
                objFilingTransactionsEntity.IsClaim = item.IsClaim;
                objFilingTransactionsEntity.InDistrict = item.InDistrict;
                objFilingTransactionsEntity.Minor = item.Minor;
                objFilingTransactionsEntity.Vendor = item.Vendor;
                objFilingTransactionsEntity.Lobbyist = item.Lobbyist;
                objFilingTransactionsEntity.RContributions = item.RContributions;
                objFilingTransactionsEntity.SupportOppose = item.SupportOppose;
                lstFilingTransactionsEntity.Add(objFilingTransactionsEntity);
            }

            objVendorImportDataEntity = new VendorImportDataEntity();
            objVendorImportDataEntity.FilingsId = objVendorImportDataContract.FilingsId;
            objVendorImportDataEntity.VendorId = objVendorImportDataContract.VendorId;
            objVendorImportDataEntity.VendorFileSize = objVendorImportDataContract.VendorFileSize;
            objVendorImportDataEntity.VendorTransCount = objVendorImportDataContract.VendorTransCount;
            objVendorImportDataEntity.CreatedBy = objVendorImportDataContract.CreatedBy;
            objVendorImportDataEntity.dtCreatedDate = objVendorImportDataContract.dtCreatedDate;
            objVendorImportDataEntity.strLastSetOfTrans = objVendorImportDataContract.strLastSetOfTrans;

            Boolean returnValue = objEFSRepository.AddVendorImportFileIntoTempDatabase(lstFilingTransactionsEntity, objVendorImportDataEntity);

            return returnValue; 
        }
        #endregion AddVendorImportFileIntoTempDatabase


        /// <summary>
        /// GetSchedR_Exists
        /// </summary>
        /// <param name="objSchedR_ISExists_Entity"></param>
        /// <returns></returns>
        public String GetSchedR_Exists(SchedR_ISExists_Contract objSchedR_ISExists_Contract)
        {            
            SchedR_ISExists_Entity objSchedR_ISExists_Entity = new SchedR_ISExists_Entity();
            objSchedR_ISExists_Entity.FilerId = objSchedR_ISExists_Contract.FilerId;
            objSchedR_ISExists_Entity.ReportYearId = objSchedR_ISExists_Contract.ReportYearId;
            objSchedR_ISExists_Entity.Filing_Enty_First_Name = objSchedR_ISExists_Contract.Filing_Enty_First_Name;
            objSchedR_ISExists_Entity.Filing_Enty_Middle_Name = objSchedR_ISExists_Contract.Filing_Enty_Middle_Name;
            objSchedR_ISExists_Entity.Filing_Enty_Last_Name = objSchedR_ISExists_Contract.Filing_Enty_Last_Name;
            objSchedR_ISExists_Entity.Office_Id = objSchedR_ISExists_Contract.Office_Id;
            objSchedR_ISExists_Entity.District_Id = objSchedR_ISExists_Contract.District_Id;

            String results = objEFSRepository.GetSchedR_Exists(objSchedR_ISExists_Entity);            

            return results;
        }

        /// <summary>
        /// GetFilerCommitteeTypeId
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <returns></returns>
        public String GetFilerCommitteeTypeId(String strFilerId)
        {
            String strCommitteeTypeId = objEFSRepository.GetFilerCommitteeTypeId(strFilerId);                        

            return strCommitteeTypeId;
        }

        #region "GetElectionTypeForFilerIDForSubmit"
        // THIS FUNCTION GETS THE DATA FOR THE ELECTIONTYPE FILTER DROPDOWN
        public IList<ElectionTypeContract> GetElectionTypeForFilerIDForSubmit(String strElectYearID, String strOfficeTypeID, String strCountyID, String strMunicipalityID, String strFilerID)
        {
            IList<ElectionTypeContract> listElectionTypeContract = new List<ElectionTypeContract>();
            ElectionTypeContract objElectionTypeContract;
            var results = objEFSRepository.GetElectionTypeForFilerIDForSubmit(strElectYearID, strOfficeTypeID, strCountyID, strMunicipalityID, strFilerID);
            foreach (var item in results)
            {
                objElectionTypeContract = new ElectionTypeContract();
                objElectionTypeContract.ElectionTypeId = Convert.ToString(item.ElectionTypeId);
                objElectionTypeContract.ElectionTypeDesc = item.ElectionTypeDesc;
                listElectionTypeContract.Add(objElectionTypeContract);
            }
            return listElectionTypeContract;
        }
        #endregion

        #region "GetElectionYearDataForFilerID"
        // THIS FUNCTION GETS THE ELECTION YEAR FOR FILTER DROPDOWN
        public IList<ElectionYearContract> GetElectionYearDataForFilerIDForSubmit(String strFilerID)
        {
            IList<ElectionYearContract> lstElectionYearContract = new List<ElectionYearContract>();
            ElectionYearContract objElectionYearContract;

            var results = objEFSRepository.GetElectionYearDataForFilerIDForSubmit(strFilerID);

            foreach (var item in results)
            {
                objElectionYearContract = new ElectionYearContract();
                objElectionYearContract.ElectionYearId = item.ElectionYearId;
                objElectionYearContract.ElectionYearValue = item.ElectionYearValue;
                lstElectionYearContract.Add(objElectionYearContract);
            }

            return lstElectionYearContract;
        }
        #endregion

        /// <summary>
        /// GetDisclosurePeriodDataForNoActivity
        /// </summary>
        /// <param name="strFilerID"></param>
        /// <param name="strPolCalDateID"></param>
        /// <param name="strElectTypeId"></param>
        /// <returns></returns>
        public IList<DisclosurePreiodContract> GetDisclosurePeriodDataForNoActivity(String strFilerID, String strPolCalDateID, String strElectTypeId)
        {
            IList<DisclosurePreiodContract> lstDisclosurePreiodContract = new List<DisclosurePreiodContract>();
            DisclosurePreiodContract objDisclosurePreiodContract;

            var results = objEFSRepository.GetDisclosurePeriodDataForNoActivity(strFilerID, strPolCalDateID, strElectTypeId);

            foreach (var item in results)
            {
                objDisclosurePreiodContract = new DisclosurePreiodContract();
                objDisclosurePreiodContract.FilingTypeId = item.FilingTypeId;
                objDisclosurePreiodContract.FilingDesc = item.FilingDesc;
                objDisclosurePreiodContract.FilingAbbrev = item.FilingAbbrev;
                lstDisclosurePreiodContract.Add(objDisclosurePreiodContract);
            }

            return lstDisclosurePreiodContract;
        }

        #region GetMunicipalityByOfficeType
        /// <summary>
        /// GetMunicipalityByOfficeType
        /// </summary>
        /// <param name="strCountyId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <returns></returns>
        // GetMunicipalityByOfficeType
        public IList<MunicipalityContract> GetMunicipalityByOfficeType(String strCountyId, String strOfficeTypeId)
        {
            IList<MunicipalityContract> lstMunicipalityEntity = new List<MunicipalityContract>();
            MunicipalityContract objMunicipalityEntity;            

            var results = objEFSRepository.GetMunicipalityByOfficeType(strCountyId, strOfficeTypeId);

            foreach (var item in results)
            {
                objMunicipalityEntity = new MunicipalityContract();
                objMunicipalityEntity.MunicipalityId = item.MunicipalityId;
                objMunicipalityEntity.MunicipalityDesc = item.MunicipalityDesc;
                lstMunicipalityEntity.Add(objMunicipalityEntity);
            }

            return lstMunicipalityEntity;
        }
        #endregion GetMunicipalityByOfficeType

        #region "GetCountyForFilings"
        // THIS FUNCTION GETS THE DATA FOR THE COUNTY FILTER DROPDOWN
        /// <summary>
        /// GetCountyForFilings
        /// </summary>
        /// <param name="elect_Year_ID"></param>
        /// <param name="filer_ID"></param>
        /// <returns></returns>
        public IList<CountyContract> GetCountyForFilings(string elect_Year_ID, string filer_ID)
        {
            IList<CountyContract> listCountyContract = new List<CountyContract>();
            CountyContract objCountyContract;
            var results = objEFSRepository.GetCountyForFilings(elect_Year_ID, filer_ID);
            foreach (var item in results)
            {
                objCountyContract = new CountyContract();
                objCountyContract.CountyId = Convert.ToString(item.CountyId);
                objCountyContract.CountyDesc = item.CountyDesc;
                listCountyContract.Add(objCountyContract);
            }
            return listCountyContract;
        }
        #endregion

        /// <summary>
        /// Get Loan Outstanding balance
        /// </summary>
        /// <param name="loan_Lib_number"></param>
        /// <param name="strFilerId"></param>
        /// <returns></returns>
        public String FilingTransactionOutStandingBalance(String loan_Lib_number, String strFilerId)
        {
            String strCommitteeTypeId = objEFSRepository.FilingTransactionOutStandingBalance(loan_Lib_number, strFilerId);

            return strCommitteeTypeId;
        }

        #region AddVendorImportFileForSchedA
        /// <summary>
        /// AddVendorImportFileForSchedA
        /// </summary>
        /// <param name="lstFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean AddVendorImportFileForSchedA(IList<FilingTransactionsContract> lstFilingTransactionsContract)
        {
            IList<FilingTransactionsEntity> lstFilingTransactionsEntity = new List<FilingTransactionsEntity>();
            FilingTransactionsEntity objFilingTransactionsEntity;

            foreach (var item in lstFilingTransactionsContract)
            {
                objFilingTransactionsEntity = new FilingTransactionsEntity();

                objFilingTransactionsEntity.FilerId = item.FilerId;
                objFilingTransactionsEntity.ElectYearId = item.ElectYearId;
                objFilingTransactionsEntity.OfficeTypeId = item.OfficeTypeId;
                objFilingTransactionsEntity.ElectionTypeId = item.ElectionTypeId;
                objFilingTransactionsEntity.ElectionDateId = item.ElectionDateId;
                objFilingTransactionsEntity.FilingTypeId = item.FilingTypeId;
                objFilingTransactionsEntity.ResigTermTypeId = item.ResigTermTypeId;
                objFilingTransactionsEntity.FilingDate = item.FilingDate;
                objFilingTransactionsEntity.CreatedBy = item.CreatedBy;
                objFilingTransactionsEntity.SchedDate = item.SchedDate;
                objFilingTransactionsEntity.ContributorTypeDesc = item.ContributorTypeDesc;
                objFilingTransactionsEntity.FlngEntFirstName = item.FlngEntFirstName;
                objFilingTransactionsEntity.FlngEntMiddleName = item.FlngEntMiddleName;
                objFilingTransactionsEntity.FlngEntLastName = item.FlngEntLastName;
                objFilingTransactionsEntity.FlngEntName = item.FlngEntName;
                objFilingTransactionsEntity.FlngEntCountry = item.FlngEntCountry;
                objFilingTransactionsEntity.FlngEntStrName = item.FlngEntStrName;
                objFilingTransactionsEntity.FlngEntCity = item.FlngEntCity;
                objFilingTransactionsEntity.FlngEntState = item.FlngEntState;
                objFilingTransactionsEntity.FlngEntZip = item.FlngEntZip;
                objFilingTransactionsEntity.PaymentTypeDesc = item.PaymentTypeDesc;
                objFilingTransactionsEntity.PayNumber = item.PayNumber;
                objFilingTransactionsEntity.OrgAmt = item.OrgAmt;
                objFilingTransactionsEntity.TransExplanation = item.TransExplanation;
                objFilingTransactionsEntity.Unique_Num = item.Unique_Num;
                objFilingTransactionsEntity.IsClaim = item.IsClaim;
                objFilingTransactionsEntity.InDistrict = item.InDistrict;
                objFilingTransactionsEntity.Minor = item.Minor;
                objFilingTransactionsEntity.Vendor = item.Vendor;
                objFilingTransactionsEntity.Lobbyist = item.Lobbyist;
                objFilingTransactionsEntity.RContributions = item.RContributions;
                objFilingTransactionsEntity.TreasurerEmployer = item.TreasurerEmployer;
                objFilingTransactionsEntity.TreasurerOccupation = item.TreasurerOccupation;
                objFilingTransactionsEntity.TreasurerStreetAddress = item.TreasurerStreetAddress;
                objFilingTransactionsEntity.TreasurerCity = item.TreasurerCity;
                objFilingTransactionsEntity.TreasurerState = item.TreasurerState;
                objFilingTransactionsEntity.TreasurerZip = item.TreasurerZip;

                lstFilingTransactionsEntity.Add(objFilingTransactionsEntity);
            }

            Boolean returnValue = objEFSRepository.AddVendorImportFileForSchedA(lstFilingTransactionsEntity);

            return returnValue;
        }
        #endregion AddVendorImportFileForSchedA

        /// <summary>
        /// GetFileinByteFormat()
        /// </summary>
        /// <returns></returns>
        public List<EFSPDFResponseContract> GetFileinByteFormat()
        {
            List<EFSPDFResponseContract> listEFSPDFResponseContract = new List<EFSPDFResponseContract>();
            EFSPDFResponseContract objEFSPDFResponseContract = new EFSPDFResponseContract();
            var fileFormatReference = "";
            var temp_FileFormatReference = "";

            fileFormatReference = System.Configuration.ConfigurationManager.AppSettings["FilingPath"].ToString() + "\\BOE_SchedAImport_DataDictionary.pdf";
            temp_FileFormatReference = "BOE_SchedAImport_DataDictionary.pdf";

            //Load BOE_SchedAImport_DataDictionary file
            objEFSPDFResponseContract = new EFSPDFResponseContract();
            objEFSPDFResponseContract.fileByte = File.ReadAllBytes(fileFormatReference);
            objEFSPDFResponseContract.fileName = temp_FileFormatReference;
            listEFSPDFResponseContract.Add(objEFSPDFResponseContract);
             
            return listEFSPDFResponseContract;
        }

        /// <summary>
        /// GetFileinByteFormatPCF()
        /// </summary>
        /// <returns></returns>
        public List<EFSPDFResponseContract> GetFileinByteFormatPCF()
        {
            List<EFSPDFResponseContract> listEFSPDFResponseContract = new List<EFSPDFResponseContract>();
            EFSPDFResponseContract objEFSPDFResponseContract = new EFSPDFResponseContract();
            var fileFormatReference = "";
            var temp_FileFormatReference = "";

            fileFormatReference = System.Configuration.ConfigurationManager.AppSettings["FilingPath"].ToString() + "\\BOE_SchedAImportPCF_DataDictionary.pdf";
            temp_FileFormatReference = "BOE_SchedAImportPCF_DataDictionary.pdf";

            //Load BOE_SchedAImportPCF_DataDictionary file
            objEFSPDFResponseContract = new EFSPDFResponseContract();
            objEFSPDFResponseContract.fileByte = File.ReadAllBytes(fileFormatReference);
            objEFSPDFResponseContract.fileName = temp_FileFormatReference;
            listEFSPDFResponseContract.Add(objEFSPDFResponseContract);

            return listEFSPDFResponseContract;
        }

        /// <summary>
        /// GetTemplateinByteFormat()
        /// </summary>
        /// <returns></returns>
        public List<EFSPDFResponseContract> GetTemplateinByteFormat()
        {
            List<EFSPDFResponseContract> listEFSPDFResponseContract = new List<EFSPDFResponseContract>();
            EFSPDFResponseContract objEFSPDFResponseContract = new EFSPDFResponseContract();
            var fileFormatReference = "";
            var temp_FileFormatReference = "";

            fileFormatReference = System.Configuration.ConfigurationManager.AppSettings["FilingPath"].ToString() + "\\BOE_SchedAImport_Template.csv";
            temp_FileFormatReference = "BOE_SchedAImport_Template.csv";

            //Load BOE_SchedAImport_Template file
            objEFSPDFResponseContract = new EFSPDFResponseContract();
            objEFSPDFResponseContract.fileByte = File.ReadAllBytes(fileFormatReference);
            objEFSPDFResponseContract.fileName = temp_FileFormatReference;
            listEFSPDFResponseContract.Add(objEFSPDFResponseContract);

            return listEFSPDFResponseContract;
        }

        /// <summary>
        /// GetTemplateinByteFormatPCF()
        /// </summary>
        /// <returns></returns>
        public List<EFSPDFResponseContract> GetTemplateinByteFormatPCF()
        {
            List<EFSPDFResponseContract> listEFSPDFResponseContract = new List<EFSPDFResponseContract>();
            EFSPDFResponseContract objEFSPDFResponseContract = new EFSPDFResponseContract();
            var fileFormatReference = "";
            var temp_FileFormatReference = "";

            fileFormatReference = System.Configuration.ConfigurationManager.AppSettings["FilingPath"].ToString() + "\\PCF_BOE_SchedAImport_Template.csv";
            temp_FileFormatReference = "PCF_BOE_SchedAImport_Template.csv";

            //Load PCF_BOE_SchedAImport_Template file
            objEFSPDFResponseContract = new EFSPDFResponseContract();
            objEFSPDFResponseContract.fileByte = File.ReadAllBytes(fileFormatReference);
            objEFSPDFResponseContract.fileName = temp_FileFormatReference;
            listEFSPDFResponseContract.Add(objEFSPDFResponseContract);

            return listEFSPDFResponseContract;
        }

        #region GetTransactionTypesForWeeklyClaim
        /// <summary>
        /// GetTransactionTypesForWeeklyClaim
        /// </summary>
        /// <returns></returns>
        public IList<TransactionTypesContract> GetTransactionTypesForWeeklyClaim()
        {
            IList<TransactionTypesContract> lstTransactionTypesContract = new List<TransactionTypesContract>();
            TransactionTypesContract objTransactionTypesContract;

            var results = objEFSRepository.GetTransactionTypesForWeeklyClaim();

            foreach (var item in results)
            {
                objTransactionTypesContract = new TransactionTypesContract();
                objTransactionTypesContract.FilingSchedId = item.FilingSchedId;
                objTransactionTypesContract.FilingSchedDesc = item.FilingSchedDesc;
                objTransactionTypesContract.FilingSchedAbbrev = item.FilingSchedAbbrev;
                lstTransactionTypesContract.Add(objTransactionTypesContract);
            }

            return lstTransactionTypesContract;
        }
        #endregion GetTransactionTypesForWeeklyClaim

        #region GetFilingWeeklyClaimSubmissionData
        /// <summary>
        /// GetFilingWeeklyClaimSubmissionData
        /// </summary>    
        /// <param name="objFilingTransDataContract"></param>  
        /// <returns></returns>
        public IList<FilingTransactionDataContract> GetFilingWeeklyClaimSubmissionData(FilingTransDataContract objFilingTransDataContract)
        {
            IList<FilingTransactionDataContract> lstFilingTransactionDataContract = new List<FilingTransactionDataContract>();
            FilingTransactionDataContract objFilingTransactionDataContract;

            FilingTransDataEntity objFilingTransDataEntity = new FilingTransDataEntity();
            objFilingTransDataEntity.FilerId = objFilingTransDataContract.FilerId;
            objFilingTransDataEntity.ReportYearId = objFilingTransDataContract.ReportYearId;
            objFilingTransDataEntity.OfficeTypeId = objFilingTransDataContract.OfficeTypeId;
            objFilingTransDataEntity.ElectionType = objFilingTransDataContract.ElectionType;
            objFilingTransDataEntity.ElectionDateId = objFilingTransDataContract.ElectionDateId;
            objFilingTransDataEntity.FilingDate = objFilingTransDataContract.FilingDate;
            objFilingTransDataEntity.MunicipalityID = objFilingTransDataContract.MunicipalityID;

            var results = objEFSRepository.GetFilingWeeklyClaimSubmissionData(objFilingTransDataEntity);

            foreach (var item in results)
            {
                objFilingTransactionDataContract = new FilingTransactionDataContract();
                objFilingTransactionDataContract.FilingTransId = item.FilingTransId;
                objFilingTransactionDataContract.FilingSchedId = item.FilingSchedId;
                objFilingTransactionDataContract.ContributorTypeId = item.ContributorTypeId;
                objFilingTransactionDataContract.ContributorTypeDesc = item.ContributorTypeDesc;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionDataContract.PaymentTypeId = item.PaymentTypeId;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.SubmissionDate = item.SubmissionDate;
                objFilingTransactionDataContract.SchedDate = item.SchedDate;
                objFilingTransactionDataContract.FilingSchedDesc = item.FilingSchedDesc;
                objFilingTransactionDataContract.FilingEntityId = item.FilingEntityId;
                objFilingTransactionDataContract.FilingEntityName = item.FilingEntityName;
                objFilingTransactionDataContract.FilingFirstName = item.FilingFirstName;
                objFilingTransactionDataContract.FilingMiddleName = item.FilingMiddleName;
                objFilingTransactionDataContract.FilingLastName = item.FilingLastName;
                objFilingTransactionDataContract.FilingStreetNumber = item.FilingStreetNumber;
                objFilingTransactionDataContract.FilingStreetName = item.FilingStreetName;
                objFilingTransactionDataContract.FilingCity = item.FilingCity;
                objFilingTransactionDataContract.FilingState = item.FilingState;
                objFilingTransactionDataContract.FilingZip = item.FilingZip;
                objFilingTransactionDataContract.FilingCountry = item.FilingCountry;
                objFilingTransactionDataContract.PaymentTypeDesc = item.PaymentTypeDesc;
                objFilingTransactionDataContract.PayNumber = item.PayNumber;
                objFilingTransactionDataContract.OriginalAmount = item.OriginalAmount;
                objFilingTransactionDataContract.ReceiptTypeDesc = item.ReceiptTypeDesc;
                objFilingTransactionDataContract.TransferTypeDesc = item.TransferTypeDesc;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.OriginalDate = item.OriginalDate;
                objFilingTransactionDataContract.LoanerCode = item.LoanerCode;
                objFilingTransactionDataContract.ElectionYear = item.ElectionYear;
                objFilingTransactionDataContract.Office = item.Office;
                objFilingTransactionDataContract.District = item.District;
                objFilingTransactionDataContract.RLiability = item.RLiability;
                objFilingTransactionDataContract.RSubcontractor = item.RSubcontractor;
                objFilingTransactionDataContract.TransExplanation = item.TransExplanation;
                objFilingTransactionDataContract.OwedAmount = item.OwedAmount;
                objFilingTransactionDataContract.RItemized = item.RItemized;
                objFilingTransactionDataContract.RAmend = item.RAmend;
                objFilingTransactionDataContract.RStatus = item.RStatus;
                objFilingTransactionDataContract.CountyID = item.CountyID;
                objFilingTransactionDataContract.CountyDesc = item.CountyDesc;
                objFilingTransactionDataContract.MunicipalityID = item.MunicipalityID;
                objFilingTransactionDataContract.MunicipalityDesc = item.MunicipalityDesc;
                objFilingTransactionDataContract.LoanerCodeID = item.LoanerCodeId;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.CreatedDate = item.CreatedDate;
                objFilingTransactionDataContract.TreasurerFirstName = item.TreasurerFirstName;
                objFilingTransactionDataContract.TreasurerLastName = item.TreasurerLastName;
                objFilingTransactionDataContract.TreasurerMiddleName = item.TreasurerMiddleName;
                objFilingTransactionDataContract.TreasurerOccuptaion = item.TreasurerOccuptaion;
                objFilingTransactionDataContract.TreasurerEmployer = item.TreasurerEmployer;
                objFilingTransactionDataContract.TreasurerStreetAddress = item.TreasurerStreetAddress;
                objFilingTransactionDataContract.TreasurerCity = item.TreasurerCity;
                objFilingTransactionDataContract.TreasurerState = item.TreasurerState;
                objFilingTransactionDataContract.TreasurerZip = item.TreasurerZip;
                objFilingTransactionDataContract.ContributorOccupation = item.ContributorOccupation;
                objFilingTransactionDataContract.ContributorEmployer = item.ContributorEmployer;
                objFilingTransactionDataContract.IEDescription = item.IEDescription;
                objFilingTransactionDataContract.CandBallotPropReference = item.CandBallotPropReference;
                objFilingTransactionDataContract.IESupported = item.IESupported;
                objFilingTransactionDataContract.AddrId = item.AddrId;
                objFilingTransactionDataContract.TreasId = item.TreasId;
                objFilingTransactionDataContract.LoanLiablityNumber = item.LoanLiablityNumber;
                objFilingTransactionDataContract.TransNumber = item.TransNumber;
                objFilingTransactionDataContract.TransMapping = item.TransMapping;
                objFilingTransactionDataContract.InDistrict = item.InDistrict;
                objFilingTransactionDataContract.RMinor = item.RMinor;
                objFilingTransactionDataContract.RVendor = item.RVendor;
                objFilingTransactionDataContract.RLobbyist = item.RLobbyist;
                objFilingTransactionDataContract.RContributions = item.RContributions;
                objFilingTransactionDataContract.TreasurerEmployer = item.TreasurerEmployer;
                objFilingTransactionDataContract.TreasurerOccuptaion = item.TreasurerOccuptaion;
                objFilingTransactionDataContract.TreaAddress = item.TreaAddress;
                objFilingTransactionDataContract.TreaAddr1 = item.TreaAddr1;
                objFilingTransactionDataContract.TreaCity = item.TreaCity;
                objFilingTransactionDataContract.TreaState = item.TreaState;
                objFilingTransactionDataContract.TreaZipCode = item.TreaZipCode;
                objFilingTransactionDataContract.RecordType = item.RecordType;
                lstFilingTransactionDataContract.Add(objFilingTransactionDataContract);
            }

            return lstFilingTransactionDataContract;
        }
        #endregion GetFilingWeeklyClaimSubmissionData

        #region GetWeeklyClaimSubmissionHistoryData
        /// <summary>
        /// GetWeeklyClaimSubmissionHistoryData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataContract> GetWeeklyClaimSubmissionHistoryData(String strFilingTransId)
        {
            IList<FilingTransactionDataContract> lstFilingTransactionDataContract = new List<FilingTransactionDataContract>();
            FilingTransactionDataContract objFilingTransactionDataContract;

            var results = objEFSRepository.GetWeeklyClaimSubmissionHistoryData(strFilingTransId);

            foreach (var item in results)
            {
                objFilingTransactionDataContract = new FilingTransactionDataContract();
                objFilingTransactionDataContract.FilingTransId = item.FilingTransId;
                objFilingTransactionDataContract.FilingSchedId = item.FilingSchedId;
                objFilingTransactionDataContract.ContributorTypeId = item.ContributorTypeId;
                objFilingTransactionDataContract.ContributorTypeDesc = item.ContributorTypeDesc;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionDataContract.PaymentTypeId = item.PaymentTypeId;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.SubmissionDate = item.SubmissionDate;
                objFilingTransactionDataContract.SchedDate = item.SchedDate;
                objFilingTransactionDataContract.FilingSchedDesc = item.FilingSchedDesc;
                objFilingTransactionDataContract.FilingEntityId = item.FilingEntityId;
                objFilingTransactionDataContract.FilingEntityName = item.FilingEntityName;
                objFilingTransactionDataContract.FilingFirstName = item.FilingFirstName;
                objFilingTransactionDataContract.FilingMiddleName = item.FilingMiddleName;
                objFilingTransactionDataContract.FilingLastName = item.FilingLastName;
                objFilingTransactionDataContract.FilingStreetNumber = item.FilingStreetNumber;
                objFilingTransactionDataContract.FilingStreetName = item.FilingStreetName;
                objFilingTransactionDataContract.FilingCity = item.FilingCity;
                objFilingTransactionDataContract.FilingState = item.FilingState;
                objFilingTransactionDataContract.FilingZip = item.FilingZip;
                objFilingTransactionDataContract.FilingCountry = item.FilingCountry;
                objFilingTransactionDataContract.PaymentTypeDesc = item.PaymentTypeDesc;
                objFilingTransactionDataContract.PayNumber = item.PayNumber;
                objFilingTransactionDataContract.OriginalAmount = item.OriginalAmount;
                objFilingTransactionDataContract.ReceiptTypeDesc = item.ReceiptTypeDesc;
                objFilingTransactionDataContract.TransferTypeDesc = item.TransferTypeDesc;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeDesc = item.ReceiptCodeDesc;
                objFilingTransactionDataContract.ReceiptCodeId = item.ReceiptCodeId;
                objFilingTransactionDataContract.OriginalDate = item.OriginalDate;
                objFilingTransactionDataContract.LoanerCode = item.LoanerCode;
                objFilingTransactionDataContract.ElectionYear = item.ElectionYear;
                objFilingTransactionDataContract.Office = item.Office;
                objFilingTransactionDataContract.District = item.District;
                objFilingTransactionDataContract.RLiability = item.RLiability;
                objFilingTransactionDataContract.RSubcontractor = item.RSubcontractor;
                objFilingTransactionDataContract.TransExplanation = item.TransExplanation;
                objFilingTransactionDataContract.OwedAmount = item.OwedAmount;
                objFilingTransactionDataContract.RItemized = item.RItemized;
                objFilingTransactionDataContract.RAmend = item.RAmend;
                objFilingTransactionDataContract.RStatus = item.RStatus;
                objFilingTransactionDataContract.CountyID = item.CountyID;
                objFilingTransactionDataContract.CountyDesc = item.CountyDesc;
                objFilingTransactionDataContract.MunicipalityID = item.MunicipalityID;
                objFilingTransactionDataContract.MunicipalityDesc = item.MunicipalityDesc;
                objFilingTransactionDataContract.LoanerCodeID = item.LoanerCodeId;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeDesc;
                objFilingTransactionDataContract.CreatedDate = item.CreatedDate;
                objFilingTransactionDataContract.TreasurerFirstName = item.TreasurerFirstName;
                objFilingTransactionDataContract.TreasurerLastName = item.TreasurerLastName;
                objFilingTransactionDataContract.TreasurerMiddleName = item.TreasurerMiddleName;
                objFilingTransactionDataContract.TreasurerOccuptaion = item.TreasurerOccuptaion;
                objFilingTransactionDataContract.TreasurerEmployer = item.TreasurerEmployer;
                objFilingTransactionDataContract.TreasurerStreetAddress = item.TreasurerStreetAddress;
                objFilingTransactionDataContract.TreasurerCity = item.TreasurerCity;
                objFilingTransactionDataContract.TreasurerState = item.TreasurerState;
                objFilingTransactionDataContract.TreasurerZip = item.TreasurerZip;
                objFilingTransactionDataContract.ContributorOccupation = item.ContributorOccupation;
                objFilingTransactionDataContract.ContributorEmployer = item.ContributorEmployer;
                objFilingTransactionDataContract.CandBallotPropReference = item.CandBallotPropReference;
                objFilingTransactionDataContract.IEDescription = item.IEDescription;
                objFilingTransactionDataContract.IESupported = item.IESupported;
                objFilingTransactionDataContract.LoanLiablityNumber = item.LoanLiablityNumber;
                objFilingTransactionDataContract.TransNumber = item.TransNumber;
                objFilingTransactionDataContract.TransMapping = item.TransMapping;
                objFilingTransactionDataContract.InDistrict = item.InDistrict;
                objFilingTransactionDataContract.RMinor = item.RMinor;
                objFilingTransactionDataContract.RVendor = item.RVendor;
                objFilingTransactionDataContract.RLobbyist = item.RLobbyist;
                objFilingTransactionDataContract.RContributions = item.RContributions;
                objFilingTransactionDataContract.TreasurerEmployer = item.TreasurerEmployer;
                objFilingTransactionDataContract.TreasurerOccuptaion = item.TreasurerOccuptaion;
                objFilingTransactionDataContract.TreaAddress = item.TreaAddress;
                objFilingTransactionDataContract.TreaAddr1 = item.TreaAddr1;
                objFilingTransactionDataContract.TreaCity = item.TreaCity;
                objFilingTransactionDataContract.TreaState = item.TreaState;
                objFilingTransactionDataContract.TreaZipCode = item.TreaZipCode;
                lstFilingTransactionDataContract.Add(objFilingTransactionDataContract);
            }

            return lstFilingTransactionDataContract;
        }
        #endregion GetWeeklyClaimSubmissionHistoryData

        #region AddWeeklyClaimSubSchedA
        /// <summary>
        /// AddWeeklyClaimSubSchedA
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public string AddWeeklyClaimSubSchedA(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.FilingSchedId = objFilingTransactionsContract.FilingSchedId;
            objFilingTransactionsEntity.ContributorTypeId = objFilingTransactionsContract.ContributorTypeId;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.ElectionDate = objFilingTransactionsContract.ElectionDate;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.FilingTypeId = objFilingTransactionsContract.FilingTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.ElectionYear = objFilingTransactionsContract.ElectionYear;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntFirstName = objFilingTransactionsContract.FlngEntFirstName;
            objFilingTransactionsEntity.FlngEntLastName = objFilingTransactionsContract.FlngEntLastName;
            objFilingTransactionsEntity.FlngEntMiddleName = objFilingTransactionsContract.FlngEntMiddleName;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.RItemized = objFilingTransactionsContract.RItemized;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            objFilingTransactionsEntity.ResigTermTypeId = objFilingTransactionsContract.ResigTermTypeId;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;
            objFilingTransactionsEntity.MunicipalityID = objFilingTransactionsContract.MunicipalityID;
            objFilingTransactionsEntity.IsClaim = objFilingTransactionsContract.IsClaim;
            objFilingTransactionsEntity.InDistrict = objFilingTransactionsContract.InDistrict;
            objFilingTransactionsEntity.Minor = objFilingTransactionsContract.Minor;
            objFilingTransactionsEntity.Vendor = objFilingTransactionsContract.Vendor;
            objFilingTransactionsEntity.Lobbyist = objFilingTransactionsContract.Lobbyist;
            objFilingTransactionsEntity.TreasurerEmployer = objFilingTransactionsContract.TreasurerEmployer;
            objFilingTransactionsEntity.TreasurerOccupation = objFilingTransactionsContract.TreasurerOccupation;
            objFilingTransactionsEntity.TreasurerStreetAddress = objFilingTransactionsContract.TreasurerStreetAddress;
            objFilingTransactionsEntity.TreasurerCity = objFilingTransactionsContract.TreasurerCity;
            objFilingTransactionsEntity.TreasurerState = objFilingTransactionsContract.TreasurerState;
            objFilingTransactionsEntity.TreasurerZip = objFilingTransactionsContract.TreasurerZip;
            objFilingTransactionsEntity.CommTypeID = objFilingTransactionsContract.CommTypeID;
            objFilingTransactionsEntity.RContributions = objFilingTransactionsContract.RContributions;

            string result = objEFSRepository.AddWeeklyClaimSubSchedA(objFilingTransactionsEntity);

            return result;
        }
        #endregion AddWeeklyClaimSubSchedA

        /// <summary>
        /// UpdateWeeklyClaimSubSchedA
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean UpdateWeeklyClaimSubSchedA(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.TransNumber = objFilingTransactionsContract.TransNumber;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.ContributorTypeId = objFilingTransactionsContract.ContributorTypeId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.FlngEntName = objFilingTransactionsContract.FlngEntName;
            objFilingTransactionsEntity.FlngEntFirstName = objFilingTransactionsContract.FlngEntFirstName;
            objFilingTransactionsEntity.FlngEntMiddleName = objFilingTransactionsContract.FlngEntMiddleName;
            objFilingTransactionsEntity.FlngEntLastName = objFilingTransactionsContract.FlngEntLastName;
            objFilingTransactionsEntity.FlngEntStrName = objFilingTransactionsContract.FlngEntStrName;
            objFilingTransactionsEntity.FlngEntCity = objFilingTransactionsContract.FlngEntCity;
            objFilingTransactionsEntity.FlngEntState = objFilingTransactionsContract.FlngEntState;
            objFilingTransactionsEntity.FlngEntZip = objFilingTransactionsContract.FlngEntZip;
            objFilingTransactionsEntity.FlngEntCountry = objFilingTransactionsContract.FlngEntCountry;
            objFilingTransactionsEntity.ModifiedBy = objFilingTransactionsContract.ModifiedBy;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.FilingTypeId = objFilingTransactionsContract.FilingTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.IsClaim = objFilingTransactionsContract.IsClaim;
            objFilingTransactionsEntity.InDistrict = objFilingTransactionsContract.InDistrict;
            objFilingTransactionsEntity.Minor = objFilingTransactionsContract.Minor;
            objFilingTransactionsEntity.Vendor = objFilingTransactionsContract.Vendor;
            objFilingTransactionsEntity.Lobbyist = objFilingTransactionsContract.Lobbyist;
            objFilingTransactionsEntity.TreasurerEmployer = objFilingTransactionsContract.TreasurerEmployer;
            objFilingTransactionsEntity.TreasurerOccupation = objFilingTransactionsContract.TreasurerOccupation;
            objFilingTransactionsEntity.TreasurerStreetAddress = objFilingTransactionsContract.TreasurerStreetAddress;
            objFilingTransactionsEntity.TreasurerCity = objFilingTransactionsContract.TreasurerCity;
            objFilingTransactionsEntity.TreasurerState = objFilingTransactionsContract.TreasurerState;
            objFilingTransactionsEntity.TreasurerZip = objFilingTransactionsContract.TreasurerZip;
            objFilingTransactionsEntity.CommTypeID = objFilingTransactionsContract.CommTypeID;
            objFilingTransactionsEntity.RContributions = objFilingTransactionsContract.RContributions;
            objFilingTransactionsEntity.SubmissionDate = objFilingTransactionsContract.SubmissionDate;

            Boolean returnValue = objEFSRepository.UpdateWeeklyClaimSubSchedA(objFilingTransactionsEntity);

            return returnValue;
        }

        #region WeeklyClaimSubSubmitTrans
        /// <summary>
        /// WeeklyClaimSubSubmitTrans
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        public Boolean WeeklyClaimSubSubmitTrans(IList<FilingTransactionsTransIDContract> lstFilingTransactionsTransIDContract, String filerID, String strModifiedBy)
        {
            IList<FilingTransactionsTransIDEntity> lstFilingTransactionsTransIDEntity = new List<FilingTransactionsTransIDEntity>();
            FilingTransactionsTransIDEntity objFilingTransactionsTransIDEntity;

            foreach (var item in lstFilingTransactionsTransIDContract)
            {
                objFilingTransactionsTransIDEntity = new FilingTransactionsTransIDEntity();
                objFilingTransactionsTransIDEntity.TransID = item.TransID;
                lstFilingTransactionsTransIDEntity.Add(objFilingTransactionsTransIDEntity);
            }
            Boolean results = objEFSRepository.WeeklyClaimSubSubmitTrans(lstFilingTransactionsTransIDEntity, filerID, strModifiedBy);

            return results;
        }
        #endregion WeeklyClaimSubSubmitTrans

        #region DeleteWeeklyClaimSubSchedA
        /// <summary>
        /// DeleteWeeklyClaimSubSchedA
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        public Boolean DeleteWeeklyClaimSubSchedA(String strTransNumber, String strModifiedBy, String filerID)
        {
            Boolean returnValue = objEFSRepository.DeleteWeeklyClaimSubSchedA(strTransNumber, strModifiedBy, filerID);

            return returnValue;
        }
        #endregion DeleteWeeklyClaimSubSchedA

        #region GetItemizedWCSTrans
        /// <summary>
        /// GetItemizedWCSTrans
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strElectionDateId"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataContract> GetItemizedWCSTrans(String strFilerId, String strElectionYearId, String strOfficeTypeId, String strElectionTypeId, String strElectionDateId, String strMunicipalityId, String strCuttOffDate)
        {
            IList<FilingTransactionDataContract> lstFilingTransactionDataContract = new List<FilingTransactionDataContract>();
            FilingTransactionDataContract objFilingTransactionDataContract;

            var results = objEFSRepository.GetItemizedWCSTrans(strFilerId, strElectionYearId, strOfficeTypeId, strElectionTypeId, strElectionDateId, strMunicipalityId, strCuttOffDate);

            foreach (var item in results)
            {
                objFilingTransactionDataContract = new FilingTransactionDataContract();
                objFilingTransactionDataContract.FilingTransId = item.FilingTransId;
                objFilingTransactionDataContract.SchedDate = item.SchedDate;
                objFilingTransactionDataContract.OriginalAmount = item.OriginalAmount;
                objFilingTransactionDataContract.IEDescription = item.IEDescription;
                objFilingTransactionDataContract.IEType = item.IEType;
                objFilingTransactionDataContract.TreasurerName = item.TreasurerName;
                objFilingTransactionDataContract.ContributorName = item.ContributorName;
                objFilingTransactionDataContract.TreasurerCity = item.TreasurerCity;
                objFilingTransactionDataContract.TreasurerState = item.TreasurerState;
                objFilingTransactionDataContract.CandBallotPropReference = item.CandBallotPropReference;
                objFilingTransactionDataContract.TransExplanation = item.TransExplanation;
                objFilingTransactionDataContract.CreatedDate = item.CreatedDate;
                objFilingTransactionDataContract.LoanLiablityNumber = item.LoanLiablityNumber;
                objFilingTransactionDataContract.TransNumber = item.TransNumber;
                objFilingTransactionDataContract.TransMapping = item.TransMapping;
                lstFilingTransactionDataContract.Add(objFilingTransactionDataContract);
            }

            return lstFilingTransactionDataContract;
        }
        #endregion GetItemizedWCSTrans

        #region AddWeeklyClaimSubItemizedTrans
        /// <summary>
        /// AddWeeklyClaimSubItemizedTrans
        /// </summary>
        /// <param name="lstFilingTransactionsEntity"></param>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strElectionDateId"></param>
        /// <param name="strCreatedBy"></param>
        /// <param name="strFilingDate"></param>
        /// <returns></returns>
        public Boolean AddWeeklyClaimSubItemizedTrans(IList<FilingTransactionsContract> lstFilingTransactionsContract, String strFilerId, String strElectionYearId, String strOfficeTypeId, String strFilingTypeId, String strElectionTypeId, String strElectionDateId, String strCreatedBy, String strFilingDate)
        {
            IList<FilingTransactionsEntity> lstFilingTransactionsEntity = new List<FilingTransactionsEntity>();
            FilingTransactionsEntity objFilingTransactionsEntity;

            foreach (var item in lstFilingTransactionsContract)
            {
                objFilingTransactionsEntity = new FilingTransactionsEntity();
                objFilingTransactionsEntity.TransNumber = item.TransNumber;                
                lstFilingTransactionsEntity.Add(objFilingTransactionsEntity);
            }

            Boolean returnValue = objEFSRepository.AddWeeklyClaimSubItemizedTrans(lstFilingTransactionsEntity, strFilerId, strElectionYearId, strOfficeTypeId, strFilingTypeId, strElectionTypeId, strElectionDateId,strCreatedBy, strFilingDate);

            return returnValue;
        }
        #endregion

        /// <summary>
        /// GetDisclosureTypesDataForPCFB
        /// </summary>
        /// <returns></returns>
        public IList<DisclosureTypesContract> GetDisclosureTypesDataForPCFB(String strCandCommId, String strElectTypeID)
        {
            IList<DisclosureTypesContract> lstDisclosureTypesContract = new List<DisclosureTypesContract>();
            DisclosureTypesContract objDisclosureTypesContract;

            var results = objEFSRepository.GetDisclosureTypesDataForPCFB(strCandCommId, strElectTypeID);

            foreach (var item in results)
            {
                objDisclosureTypesContract = new DisclosureTypesContract();
                objDisclosureTypesContract.DisclosureTypeId = item.DisclosureTypeId;
                objDisclosureTypesContract.DisclosureTypeDesc = item.DisclosureTypeDesc;
                objDisclosureTypesContract.DisclosureSubTypeDesc = item.DisclosureSubTypeDesc;
                lstDisclosureTypesContract.Add(objDisclosureTypesContract);
            }

            return lstDisclosureTypesContract;
        }

        /// <summary>
        /// GetReportSourceDataSchedS
        /// </summary>
        /// <returns></returns>
        public IList<ReportSourceContract> GetReportSourceDataSchedS()
        {
            IList<ReportSourceContract> lstReportSourceContract = new List<ReportSourceContract>();
            ReportSourceContract objReportSourceContract;

            var results = objEFSRepository.GetReportSourceDataSchedS();

            foreach (var item in results)
            {
                objReportSourceContract = new ReportSourceContract();
                objReportSourceContract.FilingEntityId = item.FilingEntityId;
                objReportSourceContract.ReportSource = item.ReportSource;
                objReportSourceContract.StreetAddress1 = item.StreetAddress1;
                objReportSourceContract.City = item.City;
                objReportSourceContract.State = item.State;
                objReportSourceContract.ZipCode = item.ZipCode;
                objReportSourceContract.Country = item.Country;
                lstReportSourceContract.Add(objReportSourceContract);
            }

            return lstReportSourceContract;
        }

        /// <summary>
        /// AddPublic_Fund_Receipts_SchedS
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public string AddPublic_Fund_Receipts_SchedS(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;
            objFilingTransactionsEntity.ReceiptTypeId = objFilingTransactionsContract.ReceiptTypeId;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.FilingTypeId = objFilingTransactionsContract.FilingTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;
            objFilingTransactionsEntity.ResigTermTypeId = objFilingTransactionsContract.ResigTermTypeId;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            string result = objEFSRepository.AddPublic_Fund_Receipts_SchedS(objFilingTransactionsEntity);

            return result;
        }

        /// <summary>
        /// UpdateFlngtrans_PublicFundRecpt
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean UpdateFlngtrans_PublicFundRecpt(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.TransNumber = objFilingTransactionsContract.TransNumber;            
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;            
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            Boolean result = objEFSRepository.UpdateFlngtrans_PublicFundRecpt(objFilingTransactionsEntity);

            return result;
        }

        /// <summary>
        /// GetPaymentMethodDataForSchedA
        /// </summary>
        /// <returns></returns>
        public IList<PaymentMethodContract> GetPaymentMethodDataForSchedA()
        {
            IList<PaymentMethodContract> lstPaymentMethodContract = new List<PaymentMethodContract>();
            PaymentMethodContract objPaymentMethodContract;

            var results = objEFSRepository.GetPaymentMethodDataForSchedA();

            foreach (var item in results)
            {
                objPaymentMethodContract = new PaymentMethodContract();
                objPaymentMethodContract.PaymentTypeId = item.PaymentTypeId;
                objPaymentMethodContract.PaymentTypeDesc = item.PaymentTypeDesc;
                objPaymentMethodContract.PaymentTypeAbbrev = item.PaymentTypeAbbrev;
                lstPaymentMethodContract.Add(objPaymentMethodContract);
            }

            return lstPaymentMethodContract;
        }

        /// <summary>
        /// GetEditFlagPCFDueDate
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strCommTypeId"></param>
        /// <param name="strLabelId"></param>
        /// <param name="strFilingDate"></param>
        /// <returns></returns>
        public IList<GetEditFlagDataContract> GetEditFlagPCFDueDate(FilingTransDataContract objFilingTransDataContract)
        {
            IList<GetEditFlagDataContract> lstGetEditFlagDataEntity = new List<GetEditFlagDataContract>();
            GetEditFlagDataContract objGetEditFlagDataEntity;

            FilingTransDataEntity objFilingTransDataEntity = new FilingTransDataEntity();
            objFilingTransDataEntity.FilerId = objFilingTransDataContract.FilerId;
            objFilingTransDataEntity.ReportYearId = objFilingTransDataContract.ReportYearId;
            objFilingTransDataEntity.ElectionType = objFilingTransDataContract.ElectionType;
            objFilingTransDataEntity.OfficeTypeId = objFilingTransDataContract.OfficeTypeId;
            objFilingTransDataEntity.DisclosurePeriod = objFilingTransDataContract.DisclosurePeriod;
            objFilingTransDataEntity.FilingDate = objFilingTransDataContract.FilingDate;
            objFilingTransDataEntity.ElectionDateId = objFilingTransDataContract.ElectionDateId;
            objFilingTransDataEntity.Created_By = objFilingTransDataContract.Created_By;
            objFilingTransDataEntity.TransNumber = objFilingTransDataContract.TransNumber;
            objFilingTransDataEntity.MunicipalityID = objFilingTransDataContract.MunicipalityID;
            objFilingTransDataEntity.CommTypeId = objFilingTransDataContract.CommTypeId;
            objFilingTransDataEntity.LabelId = objFilingTransDataContract.LabelId;

            var results = objEFSRepository.GetEditFlagPCFDueDate(objFilingTransDataEntity);

            foreach (var item in results)
            {
                objGetEditFlagDataEntity = new GetEditFlagDataContract();
                objGetEditFlagDataEntity.Is_Edit = item.Is_Edit.ToString();
                lstGetEditFlagDataEntity.Add(objGetEditFlagDataEntity);
            }

            return lstGetEditFlagDataEntity;

        }

        /// <summary>
        /// GetEditFlagPCFDueDateImport
        /// </summary>
        /// <param name=filerId"></param>
        /// <param name="filingPeriodId"></param>
        /// <param name="electId"></param>
        /// <returns></returns>
        public IList<GetEditFlagDataContract> GetEditFlagPCFDueDateImport(String filerId, String filingPeriodId, String electId)
        {
            IList<GetEditFlagDataContract> lstGetEditFlagDataEntity = new List<GetEditFlagDataContract>();
            GetEditFlagDataContract objGetEditFlagDataEntity;

            var results = objEFSRepository.GetEditFlagPCFDueDateImport(filerId, filingPeriodId, electId);

            foreach (var item in results)
            {
                objGetEditFlagDataEntity = new GetEditFlagDataContract();
                objGetEditFlagDataEntity.Is_Edit = item.Is_Edit.ToString();
                lstGetEditFlagDataEntity.Add(objGetEditFlagDataEntity);
            }

            return lstGetEditFlagDataEntity;

        }

        /// <summary>
        /// AddPublic_Fund_Payment_SchedU
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public string AddPublic_Fund_Payment_SchedU(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.FilingEntId = objFilingTransactionsContract.FilingEntId;            
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.ElectionTypeId = objFilingTransactionsContract.ElectionTypeId;
            objFilingTransactionsEntity.OfficeTypeId = objFilingTransactionsContract.OfficeTypeId;
            objFilingTransactionsEntity.FilingTypeId = objFilingTransactionsContract.FilingTypeId;
            objFilingTransactionsEntity.ElectYearId = objFilingTransactionsContract.ElectYearId;
            objFilingTransactionsEntity.FilingDate = objFilingTransactionsContract.FilingDate;
            objFilingTransactionsEntity.ElectionDateId = objFilingTransactionsContract.ElectionDateId;
            objFilingTransactionsEntity.ResigTermTypeId = objFilingTransactionsContract.ResigTermTypeId;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            string result = objEFSRepository.AddPublic_Fund_Payment_SchedU(objFilingTransactionsEntity);

            return result;
        }

        /// <summary>
        /// UpdateFlngtrans_PublicFundPayment
        /// </summary>
        /// <param name="objFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean UpdateFlngtrans_PublicFundPayment(FilingTransactionsContract objFilingTransactionsContract)
        {
            FilingTransactionsEntity objFilingTransactionsEntity = new FilingTransactionsEntity();
            objFilingTransactionsEntity.FilerId = objFilingTransactionsContract.FilerId;
            objFilingTransactionsEntity.TransNumber = objFilingTransactionsContract.TransNumber;
            objFilingTransactionsEntity.SchedDate = objFilingTransactionsContract.SchedDate;
            objFilingTransactionsEntity.PaymentTypeId = objFilingTransactionsContract.PaymentTypeId;
            objFilingTransactionsEntity.PayNumber = objFilingTransactionsContract.PayNumber;
            objFilingTransactionsEntity.OrgAmt = objFilingTransactionsContract.OrgAmt;
            objFilingTransactionsEntity.TransExplanation = objFilingTransactionsContract.TransExplanation;
            objFilingTransactionsEntity.CreatedBy = objFilingTransactionsContract.CreatedBy;
            Boolean result = objEFSRepository.UpdateFlngtrans_PublicFundPayment(objFilingTransactionsEntity);

            return result;
        }

        /// <summary>
        /// GetFilingCutOffDateData_PCF_WCS
        /// </summary>
        /// <param name="strElectYearId"></param>
        /// <param name="strElectTypeId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <returns></returns>
        public IList<FilingCutOffDateContract> GetFilingCutOffDateData_PCF_WCS(String strElectYearId, String strElectTypeId, String strOfficeTypeId)
        {
            IList<FilingCutOffDateContract> lstFilingCutOffDateContract = new List<FilingCutOffDateContract>();
            FilingCutOffDateContract objFilingCutOffDateContract;

            var results = objEFSRepository.GetFilingCutOffDateData_PCF_WCS(strElectYearId, strElectTypeId, strOfficeTypeId);

            foreach (var item in results)
            {
                objFilingCutOffDateContract = new FilingCutOffDateContract();
                objFilingCutOffDateContract.PoliticalCalDateId = item.PoliticalCalDateId;
                objFilingCutOffDateContract.PriGenDate = item.PriGenDate;
                objFilingCutOffDateContract.FilingDueDate = item.FilingDueDate;
                objFilingCutOffDateContract.CutOffDate = item.CutOffDate;
                lstFilingCutOffDateContract.Add(objFilingCutOffDateContract);
            }

            return lstFilingCutOffDateContract;
        }

        /// <summary>
        /// GetFilingTransSchedR_ChildData
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <param name="strFilerId"></param>
        /// <returns></returns>
        public IList<FilingTransactionsContract> GetFilingTransSchedR_ChildData(String strTransNumber, String strFilerId)
        {
            IList<FilingTransactionsContract> lstFilingTransactionsContract = new List<FilingTransactionsContract>();
            FilingTransactionsContract objFilingTransactionsContract;

            var results = objEFSRepository.GetFilingTransSchedR_ChildData(strTransNumber, strFilerId);

            foreach (var item in results)
            {
                objFilingTransactionsContract = new FilingTransactionsContract();
                objFilingTransactionsContract.FilingTransId = item.FilingTransId;
                objFilingTransactionsContract.TransNumber = item.TransNumber;
                objFilingTransactionsContract.TransMapping = item.TransMapping;
                objFilingTransactionsContract.FilingEntId = item.FilingEntId;
                objFilingTransactionsContract.SupportOppose = item.SupportOppose;
                objFilingTransactionsContract.SchedDate = item.SchedDate;
                objFilingTransactionsContract.FlngEntFirstName = item.FlngEntFirstName;
                objFilingTransactionsContract.FlngEntMiddleName = item.FlngEntMiddleName;
                objFilingTransactionsContract.FlngEntLastName = item.FlngEntLastName;
                objFilingTransactionsContract.OrgAmt = item.OrgAmt;
                objFilingTransactionsContract.ElectionYear = item.ElectionYear;
                objFilingTransactionsContract.OfficeID = item.OfficeID;
                objFilingTransactionsContract.DistrictID = item.DistrictID;
                objFilingTransactionsContract.TransExplanation = item.TransExplanation;
                objFilingTransactionsContract.RItemized = item.RItemized;
                lstFilingTransactionsContract.Add(objFilingTransactionsContract);
            }

            return lstFilingTransactionsContract;
        }

        #region GetCommEditIETransData
        /// <summary>
        /// GetCommEditIETransData
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataContract> GetCommEditIETransData_WCS(String strTransNumber, String filerID)
        {
            IList<FilingTransactionDataContract> lstFilingTransactionDataContract = new List<FilingTransactionDataContract>();
            FilingTransactionDataContract objFilingTransactionDataContract;

            var results = objEFSRepository.GetCommEditIETransData_WCS(strTransNumber, filerID);

            foreach (var item in results)
            {
                objFilingTransactionDataContract = new FilingTransactionDataContract();
                objFilingTransactionDataContract.FilingTransId = item.FilingTransId;
                objFilingTransactionDataContract.FilingSchedId = item.FilingSchedId;
                objFilingTransactionDataContract.ContributorTypeId = item.ContributorTypeId;
                objFilingTransactionDataContract.ContributorTypeDesc = item.ContributorTypeDesc;
                objFilingTransactionDataContract.PaymentTypeId = item.PaymentTypeId;
                objFilingTransactionDataContract.SubmissionDate = item.SubmissionDate;
                objFilingTransactionDataContract.SchedDate = item.SchedDate;
                objFilingTransactionDataContract.FilingSchedDesc = item.FilingSchedDesc;
                objFilingTransactionDataContract.FilingEntityId = item.FilingEntityId;
                objFilingTransactionDataContract.FilingEntityName = item.FilingEntityName;
                objFilingTransactionDataContract.FilingFirstName = item.FilingFirstName;
                objFilingTransactionDataContract.FilingMiddleName = item.FilingMiddleName;
                objFilingTransactionDataContract.FilingLastName = item.FilingLastName;
                objFilingTransactionDataContract.FilingStreetNumber = item.FilingStreetNumber;
                objFilingTransactionDataContract.FilingStreetName = item.FilingStreetName;
                objFilingTransactionDataContract.FilingCity = item.FilingCity;
                objFilingTransactionDataContract.FilingState = item.FilingState;
                objFilingTransactionDataContract.FilingZip = item.FilingZip;
                objFilingTransactionDataContract.FilingCountry = item.FilingCountry;
                objFilingTransactionDataContract.PaymentTypeDesc = item.PaymentTypeDesc;
                objFilingTransactionDataContract.PayNumber = item.PayNumber;
                objFilingTransactionDataContract.OriginalAmount = item.OriginalAmount;
                objFilingTransactionDataContract.TransExplanation = item.TransExplanation;
                objFilingTransactionDataContract.RItemized = item.RItemized;
                objFilingTransactionDataContract.CountyDesc = item.CountyDesc;
                objFilingTransactionDataContract.RAmend = item.RAmend;
                objFilingTransactionDataContract.RStatus = item.RStatus;
                objFilingTransactionDataContract.MunicipalityDesc = item.MunicipalityDesc;
                objFilingTransactionDataContract.LoanerCodeID = item.LoanerCodeId;
                objFilingTransactionDataContract.LoanerCode = item.LoanerCode;
                objFilingTransactionDataContract.ContributionTypeId = item.ContributionTypeId;
                objFilingTransactionDataContract.ContributionTypeDesc = item.ContributionTypeDesc;
                objFilingTransactionDataContract.CreatedDate = item.CreatedDate;
                objFilingTransactionDataContract.TreasurerFirstName = item.TreasurerFirstName;
                objFilingTransactionDataContract.TreasurerLastName = item.TreasurerLastName;
                objFilingTransactionDataContract.TreasurerMiddleName = item.TreasurerMiddleName;
                objFilingTransactionDataContract.TreasurerOccuptaion = item.TreasurerOccuptaion;
                objFilingTransactionDataContract.TreasurerEmployer = item.TreasurerEmployer;
                objFilingTransactionDataContract.TreasurerStreetAddress = item.TreasurerStreetAddress;
                objFilingTransactionDataContract.TreasurerCity = item.TreasurerCity;
                objFilingTransactionDataContract.TreasurerState = item.TreasurerState;
                objFilingTransactionDataContract.TreasurerZip = item.TreasurerZip;
                objFilingTransactionDataContract.ContributorOccupation = item.ContributorOccupation;
                objFilingTransactionDataContract.ContributorEmployer = item.ContributorEmployer;
                objFilingTransactionDataContract.IEDescription = item.IEDescription;
                objFilingTransactionDataContract.CandBallotPropReference = item.CandBallotPropReference;
                objFilingTransactionDataContract.IESupported = item.IESupported;
                objFilingTransactionDataContract.AddrId = item.AddrId;
                objFilingTransactionDataContract.TreasId = item.TreasId;
                objFilingTransactionDataContract.LoanLiablityNumber = item.LoanLiablityNumber;
                objFilingTransactionDataContract.TransNumber = item.TransNumber;
                objFilingTransactionDataContract.TransMapping = item.TransMapping;
                objFilingTransactionDataContract.DateIncurredOrgAmtId = item.DateIncurredOrgAmtId;
                objFilingTransactionDataContract.RLiability = item.RLiability;
                objFilingTransactionDataContract.RSubcontractor = item.RSubcontractor;
                objFilingTransactionDataContract.OwedAmount = item.OwedAmount;
                objFilingTransactionDataContract.PurposeCodeId = item.PurposeCodeId;
                objFilingTransactionDataContract.RClaim = item.RClaim;
                objFilingTransactionDataContract.InDistrict = item.InDistrict;
                objFilingTransactionDataContract.RMinor = item.RMinor;
                objFilingTransactionDataContract.RVendor = item.RVendor;
                objFilingTransactionDataContract.RLobbyist = item.RLobbyist;
                objFilingTransactionDataContract.RContributions = item.RContributions;
                lstFilingTransactionDataContract.Add(objFilingTransactionDataContract);
            }

            return lstFilingTransactionDataContract;
        }
        #endregion GetCommEditIETransData

        /// <summary>
        /// GetPurposeCodeData_PCF
        /// </summary>
        /// <returns></returns>
        public IList<PurposeCodeContract> GetPurposeCodeData_PCF()
        {
            IList<PurposeCodeContract> lstPurposeCodeContract = new List<PurposeCodeContract>();
            PurposeCodeContract objPurposeCodeContract;

            var results = objEFSRepository.GetPurposeCodeData_PCF();

            foreach (var item in results)
            {
                objPurposeCodeContract = new PurposeCodeContract();
                objPurposeCodeContract.PurposeCodeId = item.PurposeCodeId;
                objPurposeCodeContract.PurposeCodeDesc = item.PurposeCodeDesc;
                objPurposeCodeContract.PurposeCodeAbbrev = item.PurposeCodeAbbrev;
                lstPurposeCodeContract.Add(objPurposeCodeContract);
            }

            return lstPurposeCodeContract;
        }
    }
}
