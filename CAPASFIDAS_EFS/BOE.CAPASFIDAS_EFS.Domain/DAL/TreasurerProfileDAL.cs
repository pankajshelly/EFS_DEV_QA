using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOE.CAPASFIDAS_EFS.Domain.EFSService;
using Models;

namespace DAL
{
    public class TreasurerProfileDAL
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

        /// <summary>
        /// Get Treasurer Profile
        /// </summary>
        /// <param name="personID"></param>
        /// <returns></returns>
        public IList<TreasurerProfileModel> GetTreasurerProfileInfoDAL(string personID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<TreasurerProfileModel> lstTreasurerProfileModel = new List<TreasurerProfileModel>();
                    TreasurerProfileModel objTreasurerProfileModel;

                    var results = client.GetTreasurerProfileInfo(personID);

                    foreach (var item in results)
                    {
                        objTreasurerProfileModel = new TreasurerProfileModel();
                        objTreasurerProfileModel.TransID = item.TransID;
                        objTreasurerProfileModel.PersonID = item.PersonID;
                        objTreasurerProfileModel.TransRegDate = item.TransRegDate;
                        if (item.Status.ToString() == "I")
                            objTreasurerProfileModel.Status = "In-Active";
                        else
                            objTreasurerProfileModel.Status = "Active";
                        objTreasurerProfileModel.TransTermDate = item.TransTermDate;
                        objTreasurerProfileModel.PersonPrefix = item.PersonPrefix;
                        objTreasurerProfileModel.PersonFirstName = item.PersonFirstName;
                        objTreasurerProfileModel.PersonMiddleName = item.PersonMiddleName;
                        objTreasurerProfileModel.PersonLastName = item.PersonLastName;
                        objTreasurerProfileModel.PersonSuffix = item.PersonSuffix;
                        lstTreasurerProfileModel.Add(objTreasurerProfileModel);
                    }
                    client.Close();
                    return lstTreasurerProfileModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// Get Committee Information
        /// </summary>
        /// <param name="transID"></param>
        /// <returns></returns>
        public IList<TreasurerCommitteeInformationModel> GetTreasurerCommitteeInformationDAL(string transID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<TreasurerCommitteeInformationModel> lstTreasurerCommitteeInformationModel = new List<TreasurerCommitteeInformationModel>();
                    TreasurerCommitteeInformationModel objTreasurerCommitteeInformationModel;

                    var results = client.GetTreasurerCommitteeInformation(transID);

                    foreach (var item in results)
                    {
                        objTreasurerCommitteeInformationModel = new TreasurerCommitteeInformationModel();
                        objTreasurerCommitteeInformationModel.CommID = Convert.ToString(item.CommID);
                        objTreasurerCommitteeInformationModel.FilerID = Convert.ToString(item.FilerID);
                        objTreasurerCommitteeInformationModel.PersonID = item.PersonID.ToString();
                        objTreasurerCommitteeInformationModel.CommitteeName = item.CommitteeName.ToString();
                        objTreasurerCommitteeInformationModel.Status = item.Status;
                        objTreasurerCommitteeInformationModel.CommitteeRegDate = item.CommitteeRegDate.ToString();
                        objTreasurerCommitteeInformationModel.CommitteeTermDate = item.CommitteeTermDate.ToString();
                        objTreasurerCommitteeInformationModel.CommitteeTypeDesc = item.CommitteeTypeDesc.ToString();
                        lstTreasurerCommitteeInformationModel.Add(objTreasurerCommitteeInformationModel);
                    }
                    client.Close();
                    return lstTreasurerCommitteeInformationModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// Get Transurer Assistant Information
        /// </summary>
        /// <param name="commID"></param>
        /// <returns></returns>
        public IList<TreasAssistantInformationModel> GetTreasurerAssistantInformationDAL(string commID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<TreasAssistantInformationModel> lstTreasAssistantInformationModel = new List<TreasAssistantInformationModel>();
                    TreasAssistantInformationModel objTreasAssistantInformationModel;

                    var results = client.GetTreasurerAssistantInformation(commID);

                    foreach (var item in results)
                    {
                        objTreasAssistantInformationModel = new TreasAssistantInformationModel();
                        objTreasAssistantInformationModel.PersonPrefix = item.PersonPrefix;
                        objTreasAssistantInformationModel.PersonFirstName = item.PersonFirstName;
                        objTreasAssistantInformationModel.PersonMiddleName = item.PersonMiddleName;
                        objTreasAssistantInformationModel.PersonLastName = item.PersonLastName;
                        objTreasAssistantInformationModel.PersonSuffix = item.PersonSuffix;
                        objTreasAssistantInformationModel.PersonID = item.PersonID;
                        objTreasAssistantInformationModel.Status = "Acive";
                        lstTreasAssistantInformationModel.Add(objTreasAssistantInformationModel);
                    }
                    client.Close();
                    return lstTreasAssistantInformationModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// Treasurer History Information
        /// </summary>
        /// <param name="commID"></param>
        /// <param name="transID"></param>
        /// <returns></returns>
        public IList<TreasurerHistoryModel> GetTreasurerHistoryInformationDAL(string commID, string transID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<TreasurerHistoryModel> lstTreasurerHistoryModel = new List<TreasurerHistoryModel>();
                    TreasurerHistoryModel objTreasurerHistoryModel;

                    var results = client.GetTreasurerHistoryInformation(commID, transID);

                    foreach (var item in results)
                    {
                        objTreasurerHistoryModel = new TreasurerHistoryModel();
                        objTreasurerHistoryModel.PersonPrefix = item.PersonPrefix;
                        objTreasurerHistoryModel.PersonFirstName = item.PersonFirstName;
                        objTreasurerHistoryModel.PersonMiddleName = item.PersonMiddleName;
                        objTreasurerHistoryModel.PersonLastName = item.PersonLastName;
                        objTreasurerHistoryModel.PersonSuffix = item.PersonSuffix;
                        if (item.Status.ToString() == "I")
                            objTreasurerHistoryModel.Status = "In-Active";
                        else
                            objTreasurerHistoryModel.Status = "Active";
                        objTreasurerHistoryModel.RegDate = item.RegDate.ToString();
                        objTreasurerHistoryModel.TermDate = item.TermDate.ToString();
                        objTreasurerHistoryModel.PersonID = item.PersonID.ToString();
                        lstTreasurerHistoryModel.Add(objTreasurerHistoryModel);
                    }
                    client.Close();
                    return lstTreasurerHistoryModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// Get Treasurer Additional Committee Contact
        /// </summary>
        /// <param name="commID"></param>
        /// <returns></returns>
        public IList<TreasAdditionalCommitteeContactModel> GetTreasurerAdditionalCommitteeContactDAL(string commID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<TreasAdditionalCommitteeContactModel> lstTreasAdditionalCommitteeContactModel = new List<TreasAdditionalCommitteeContactModel>();
                    TreasAdditionalCommitteeContactModel objTreasAdditionalCommitteeContactModel;

                    var results = client.GetTreasurerAdditionalCommitteeContact(commID);

                    foreach (var item in results)
                    {
                        objTreasAdditionalCommitteeContactModel = new TreasAdditionalCommitteeContactModel();
                        objTreasAdditionalCommitteeContactModel.PersonPrefix = item.PersonPrefix;
                        objTreasAdditionalCommitteeContactModel.PersonFirstName = item.PersonFirstName;
                        objTreasAdditionalCommitteeContactModel.PersonMiddleName = item.PersonMiddleName;
                        objTreasAdditionalCommitteeContactModel.PersonLastName = item.PersonLastName;
                        objTreasAdditionalCommitteeContactModel.PersonSuffix = item.PersonSuffix;
                        lstTreasAdditionalCommitteeContactModel.Add(objTreasAdditionalCommitteeContactModel);
                    }
                    client.Close();
                    return lstTreasAdditionalCommitteeContactModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// Get Treasurer Depository Bank Information
        /// </summary>
        /// <param name="commID"></param>
        /// <returns></returns>
        public IList<TreasDepositoryBankInformationModel> GetTreasurerDepositoryBankInformationDAL(string commID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<TreasDepositoryBankInformationModel> lstTreasDepositoryBankInformationModel = new List<TreasDepositoryBankInformationModel>();
                    TreasDepositoryBankInformationModel objTreasDepositoryBankInformationModel;

                    var results = client.GetTreasurerDepositoryBankInformation(commID);

                    foreach (var item in results)
                    {
                        objTreasDepositoryBankInformationModel = new TreasDepositoryBankInformationModel();
                        objTreasDepositoryBankInformationModel.BankID = item.BankID.ToString();
                        objTreasDepositoryBankInformationModel.BankName = item.BankName;
                        objTreasDepositoryBankInformationModel.AddrNum = item.AddrNum;
                        objTreasDepositoryBankInformationModel.AddrStrName = item.AddrStrName;
                        objTreasDepositoryBankInformationModel.AddrCity = item.AddrCity;
                        objTreasDepositoryBankInformationModel.AddrState = item.AddrState;
                        objTreasDepositoryBankInformationModel.AddrZip = item.AddrZip.ToString();
                        objTreasDepositoryBankInformationModel.AddrZip4 = item.AddrZip4.ToString();
                        objTreasDepositoryBankInformationModel.ADDR_ID = item.ADDR_ID.ToString();
                        objTreasDepositoryBankInformationModel.PERSON_ID = item.PERSON_ID.ToString();
                        objTreasDepositoryBankInformationModel.COMM_ID = item.COMM_ID.ToString();
                        lstTreasDepositoryBankInformationModel.Add(objTreasDepositoryBankInformationModel);
                    }
                    client.Close();
                    return lstTreasDepositoryBankInformationModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        public IList<TreasCandidateSupportOpposeModel> GetTreasurerCandidateSupposeOpposeDAL(string commID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<TreasCandidateSupportOpposeModel> lstTreasCandidateSupportOpposeModel = new List<TreasCandidateSupportOpposeModel>();
                    TreasCandidateSupportOpposeModel objTreasCandidateSupportOpposeModel;

                    var results = client.GetTreasurerCandidateSupposeOppose(commID);

                    foreach (var item in results)
                    {
                        objTreasCandidateSupportOpposeModel = new TreasCandidateSupportOpposeModel();
                        objTreasCandidateSupportOpposeModel.ElectionYear = item.ElectionYear.ToString();
                        objTreasCandidateSupportOpposeModel.OfficeDesc = item.OfficeDesc;
                        if (item.DistID == "0")
                        {
                            objTreasCandidateSupportOpposeModel.DistID = "";
                        }
                        else
                        {
                            objTreasCandidateSupportOpposeModel.DistID = item.DistID.ToString();
                        }
                        objTreasCandidateSupportOpposeModel.PersonFirstName = item.PersonFirstName;
                        objTreasCandidateSupportOpposeModel.PersonMiddleName = item.PersonMiddleName;
                        objTreasCandidateSupportOpposeModel.PersonLastName = item.PersonLastName;
                        objTreasCandidateSupportOpposeModel.SupposeOppose = item.SupposeOppose.ToString();
                        if (item.AuthorizedDate != null)
                        {
                            objTreasCandidateSupportOpposeModel.AuthorizedDate = item.AuthorizedDate.ToString();
                        }
                        else
                        {
                            objTreasCandidateSupportOpposeModel.AuthorizedDate = "";
                        }
                        if (item.NonExpenditureDate != null)
                        {
                            objTreasCandidateSupportOpposeModel.NonExpenditureDate = item.NonExpenditureDate.ToString();
                        }
                        else
                        {
                            objTreasCandidateSupportOpposeModel.NonExpenditureDate = "";
                        }

                        lstTreasCandidateSupportOpposeModel.Add(objTreasCandidateSupportOpposeModel);
                    }
                    client.Close();
                    return lstTreasCandidateSupportOpposeModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// Get Treasurer Authorized To Sign Check Conract
        /// </summary>
        /// <param name="commID"></param>
        /// <returns></returns>
        public IList<TreasAuthorizedToSignCheckModel> GetTreasurerAuthorizedToSignCheckContactDAL(string commID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<TreasAuthorizedToSignCheckModel> lstTreasAuthorizedToSignCheckModel = new List<TreasAuthorizedToSignCheckModel>();
                    TreasAuthorizedToSignCheckModel objTreasAuthorizedToSignCheckModel;

                    var results = client.GetTreasurerAuthorizedToSignCheckContact(commID);

                    foreach (var item in results)
                    {
                        objTreasAuthorizedToSignCheckModel = new TreasAuthorizedToSignCheckModel();
                        objTreasAuthorizedToSignCheckModel.PersonPrefix = item.PersonPrefix;
                        objTreasAuthorizedToSignCheckModel.PersonFirstName = item.PersonFirstName;
                        objTreasAuthorizedToSignCheckModel.PersonMiddleName = item.PersonMiddleName;
                        objTreasAuthorizedToSignCheckModel.PersonLastName = item.PersonLastName;
                        objTreasAuthorizedToSignCheckModel.PersonSuffix = item.PersonSuffix;
                        objTreasAuthorizedToSignCheckModel.AuthSignedID = item.AuthSignedID;
                        objTreasAuthorizedToSignCheckModel.PersonID = item.PersonID;
                        if (item.StartDate.ToString() == "1/1/1900 12:00:00 AM")
                        {
                            objTreasAuthorizedToSignCheckModel.StartDate = "";
                        }
                        else
                        {
                            objTreasAuthorizedToSignCheckModel.StartDate = Convert.ToDateTime(item.StartDate).ToShortDateString();
                        }
                        if (item.EndDate.ToString() == "1/1/1900 12:00:00 AM")
                        {
                            objTreasAuthorizedToSignCheckModel.EndDate = "";
                        }
                        else
                        {
                            objTreasAuthorizedToSignCheckModel.EndDate = Convert.ToDateTime(item.EndDate).ToShortDateString();
                        }
                        //objTreasAuthorizedToSignCheckModel.StartDate = item.StartDate;
                        //objTreasAuthorizedToSignCheckModel.EndDate = item.EndDate;
                        objTreasAuthorizedToSignCheckModel.Status = item.Status;
                        lstTreasAuthorizedToSignCheckModel.Add(objTreasAuthorizedToSignCheckModel);
                    }
                    client.Close();
                    return lstTreasAuthorizedToSignCheckModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
           
            
        }

        /// <summary>
        /// Get Treasurer Ballot Issues Contract
        /// </summary>
        /// <param name="commID"></param>
        /// <returns></returns>
        public IList<TreasBallotIssuesModel> GetTreasurerBallotIssuesContactDAL(string commID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<TreasBallotIssuesModel> lstTreasBallotIssuesModel = new List<TreasBallotIssuesModel>();
                    TreasBallotIssuesModel objTreasBallotIssuesModel;

                    var results = client.GetTreasurerBallotIssuesContact(commID);

                    foreach (var item in results)
                    {
                        objTreasBallotIssuesModel = new TreasBallotIssuesModel();
                        objTreasBallotIssuesModel.BallotIssues = item.BallotIssues.ToString();
                        objTreasBallotIssuesModel.SupposeOppose = item.SupposeOppose.ToString();
                        lstTreasBallotIssuesModel.Add(objTreasBallotIssuesModel);
                    }
                    client.Close();
                    return lstTreasBallotIssuesModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapAddSubTreasurerDataDALResponse
        /// </summary>
        /// <param name="objSubTreasurerPersonModel"></param>
        /// <returns></returns>
        internal Boolean mapAddSubTreasurerDataDALResponse(SubTreasurerPersonModel objSubTreasurerPersonModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    SubTreasurerPersonContract objSubTreasurerPersonContract = new SubTreasurerPersonContract();
                    objSubTreasurerPersonContract.StateDate = objSubTreasurerPersonModel.StateDate;
                    objSubTreasurerPersonContract.RStatus = objSubTreasurerPersonModel.RStatus;
                    objSubTreasurerPersonContract.FirstName = objSubTreasurerPersonModel.FirstName;
                    objSubTreasurerPersonContract.MiddleName = objSubTreasurerPersonModel.MiddleName;
                    objSubTreasurerPersonContract.LastName = objSubTreasurerPersonModel.LastName;
                    objSubTreasurerPersonContract.Suffix = objSubTreasurerPersonModel.Suffix;
                    objSubTreasurerPersonContract.Preffix = objSubTreasurerPersonModel.Preffix;
                    objSubTreasurerPersonContract.PersonId = objSubTreasurerPersonModel.PersonId;
                    objSubTreasurerPersonContract.TreasurerId = objSubTreasurerPersonModel.TreasurerId;
                    objSubTreasurerPersonContract.CreatedBy = objSubTreasurerPersonModel.CreatedBy;

                    Boolean result = client.AddSubTreasurerData(objSubTreasurerPersonContract);
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
        /// mapUpdateSubTreasurerDataDALResponse
        /// </summary>
        /// <param name="objSubTreasurerPersonModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateSubTreasurerDataDALResponse(SubTreasurerPersonModel objSubTreasurerPersonModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    SubTreasurerPersonContract objSubTreasurerPersonContract = new SubTreasurerPersonContract();
                    objSubTreasurerPersonContract.PersonId = objSubTreasurerPersonModel.PersonId;
                    objSubTreasurerPersonContract.FirstName = objSubTreasurerPersonModel.FirstName;
                    objSubTreasurerPersonContract.MiddleName = objSubTreasurerPersonModel.MiddleName;
                    objSubTreasurerPersonContract.LastName = objSubTreasurerPersonModel.LastName;
                    objSubTreasurerPersonContract.Suffix = objSubTreasurerPersonModel.Suffix;
                    objSubTreasurerPersonContract.Preffix = objSubTreasurerPersonModel.Preffix;
                    objSubTreasurerPersonContract.SubTreasurerId = objSubTreasurerPersonModel.SubTreasurerId;
                    objSubTreasurerPersonContract.RStatus = objSubTreasurerPersonModel.RStatus;
                    objSubTreasurerPersonContract.StateDate = objSubTreasurerPersonModel.StateDate;
                    objSubTreasurerPersonContract.ModifiedBy = objSubTreasurerPersonModel.ModifiedBy;

                    Boolean result = client.UpdateSubTreasurerData(objSubTreasurerPersonContract);
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
        /// Add Authorized To Sign Check Entry
        /// </summary>
        /// <param name="objAuthorizedToSignCheckEntity"></param>
        /// <returns></returns>
        internal Boolean AddAuthorizedToSignCheckDAL(AuthorizedToSignCheckModel objAuthorizedToSignCheckModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    AuthorizedToSignCheckContract objAuthorizedToSignCheckContract = new AuthorizedToSignCheckContract();
                    objAuthorizedToSignCheckContract.CommID = objAuthorizedToSignCheckModel.CommID;
                    objAuthorizedToSignCheckContract.StartDate = objAuthorizedToSignCheckModel.StartDate;
                    objAuthorizedToSignCheckContract.Status = objAuthorizedToSignCheckModel.Status;
                    objAuthorizedToSignCheckContract.EndDate = objAuthorizedToSignCheckModel.EndDate;
                    objAuthorizedToSignCheckContract.Prefix = objAuthorizedToSignCheckModel.Prefix;
                    objAuthorizedToSignCheckContract.FirstName = objAuthorizedToSignCheckModel.FirstName;
                    objAuthorizedToSignCheckContract.MiddleName = objAuthorizedToSignCheckModel.MiddleName;
                    objAuthorizedToSignCheckContract.LastName = objAuthorizedToSignCheckModel.LastName;
                    objAuthorizedToSignCheckContract.Suffix = objAuthorizedToSignCheckModel.Suffix;
                    objAuthorizedToSignCheckContract.Signature = objAuthorizedToSignCheckModel.Signature;
                    objAuthorizedToSignCheckContract.CreatedBy = objAuthorizedToSignCheckModel.CreatedBy;

                    Boolean results = client.AddAuthorizedToSignCheck(objAuthorizedToSignCheckContract);
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
    }
}
