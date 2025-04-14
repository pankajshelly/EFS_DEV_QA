using BOE.CAPASFIDAS_EFS.Domain.EFSService;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace DAL
{
    public class ItemizedReportsDAL
    {
        // Create Service Object
        //CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient();

        /// <summary>
        /// mapGetFilingTransactionsDataDALResponse
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetFilingTransactionsDataDALResponse(FilingTransDataModel objFilingTransDataModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {
                    IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                    FilingTransactionDataModel objFilingTransactionDataModel;

                    FilingTransDataContract objFilingTransDataContract = new FilingTransDataContract();
                    objFilingTransDataContract.FilerId = objFilingTransDataModel.FilerId;
                    objFilingTransDataContract.ReportYearId = objFilingTransDataModel.ReportYearId;
                    objFilingTransDataContract.OfficeTypeId = objFilingTransDataModel.OfficeTypeId;
                    objFilingTransDataContract.DisclosurePeriod = objFilingTransDataModel.DisclosurePeriod;
                    objFilingTransDataContract.ElectionType = objFilingTransDataModel.ElectionType;
                    objFilingTransDataContract.ElectionDateId = objFilingTransDataModel.ElectionDateId;
                    objFilingTransDataContract.FilingDate = objFilingTransDataModel.FilingDate;
                    objFilingTransDataContract.MunicipalityID = objFilingTransDataModel.MunicipalityID;

                    var results = client.GetFilingTransactionsData(objFilingTransDataContract);

                    foreach (var item in results)
                    {
                        objFilingTransactionDataModel = new FilingTransactionDataModel();
                        objFilingTransactionDataModel.FilingTransId = item.FilingTransId;
                        objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                        objFilingTransactionDataModel.ContributorTypeId = item.ContributorTypeId;
                        objFilingTransactionDataModel.ContributorTypeDesc = item.ContributorTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.PaymentTypeId = item.PaymentTypeId;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.SchedDate = item.SchedDate;
                        objFilingTransactionDataModel.FilingSchedDesc = item.FilingSchedDesc;
                        objFilingTransactionDataModel.FilingEntityId = item.FilingEntityId;
                        objFilingTransactionDataModel.FilingEntityName = item.FilingEntityName;
                        objFilingTransactionDataModel.FilingFirstName = item.FilingFirstName;
                        objFilingTransactionDataModel.FilingMiddleName = item.FilingMiddleName;
                        objFilingTransactionDataModel.FilingLastName = item.FilingLastName;
                        objFilingTransactionDataModel.FilingStreetNumber = item.FilingStreetNumber;
                        objFilingTransactionDataModel.FilingStreetName = item.FilingStreetName;
                        objFilingTransactionDataModel.FilingCity = item.FilingCity;
                        objFilingTransactionDataModel.FilingState = item.FilingState;
                        objFilingTransactionDataModel.FilingZip = item.FilingZip;
                        objFilingTransactionDataModel.FilingCountry = item.FilingCountry;
                        objFilingTransactionDataModel.PaymentTypeDesc = item.PaymentTypeDesc;
                        objFilingTransactionDataModel.PayNumber = item.PayNumber;
                        objFilingTransactionDataModel.OriginalAmount = item.OriginalAmount;
                        objFilingTransactionDataModel.ReceiptTypeDesc = item.ReceiptTypeDesc;
                        objFilingTransactionDataModel.TransferTypeDesc = item.TransferTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.OriginalDate = item.OriginalDate;
                        objFilingTransactionDataModel.LoanerCode = item.LoanerCode;
                        objFilingTransactionDataModel.ElectionYear = item.ElectionYear;
                        objFilingTransactionDataModel.Office = item.Office;
                        objFilingTransactionDataModel.District = item.District;
                        objFilingTransactionDataModel.RLiability = item.RLiability;
                        objFilingTransactionDataModel.RSubcontractor = item.RSubcontractor;
                        objFilingTransactionDataModel.TransExplanation = item.TransExplanation;
                        objFilingTransactionDataModel.OwedAmount = item.OwedAmount;
                        objFilingTransactionDataModel.RItemized = item.RItemized;
                        objFilingTransactionDataModel.CountyID = item.CountyID;
                        objFilingTransactionDataModel.CountyDesc = item.CountyDesc;
                        objFilingTransactionDataModel.MunicipalityID = item.MunicipalityID;
                        objFilingTransactionDataModel.MunicipalityDesc = item.MunicipalityDesc;
                        objFilingTransactionDataModel.LoanerCodeID = item.LoanerCodeID;
                        objFilingTransactionDataModel.CreatedDate = item.CreatedDate;
                        objFilingTransactionDataModel.LoanLiablityNumber = item.LoanLiablityNumber;
                        objFilingTransactionDataModel.TransNumber = item.TransNumber;
                        objFilingTransactionDataModel.TransMapping = item.TransMapping;
                        objFilingTransactionDataModel.FilingsId = item.FilingsId;
                        objFilingTransactionDataModel.Office_Desc = item.Office_Desc;
                        objFilingTransactionDataModel.RClaim = item.RClaim;
                        objFilingTransactionDataModel.InDistrict = item.InDistrict;
                        objFilingTransactionDataModel.RMinor = item.RMinor;
                        objFilingTransactionDataModel.RVendor = item.RVendor;
                        objFilingTransactionDataModel.RLobbyist = item.RLobbyist;
                        objFilingTransactionDataModel.TreasurerEmployer = item.TreasurerEmployer;
                        objFilingTransactionDataModel.TreasurerOccuptaion = item.TreasurerOccuptaion;
                        objFilingTransactionDataModel.TreaAddress = item.TreaAddress;
                        objFilingTransactionDataModel.TreaAddr1 = item.TreaAddr1;
                        objFilingTransactionDataModel.TreaCity = item.TreaCity;
                        objFilingTransactionDataModel.TreaState = item.TreaState;
                        objFilingTransactionDataModel.TreaZipCode = item.TreaZipCode;
                        objFilingTransactionDataModel.RContributions = item.RContributions;
                        objFilingTransactionDataModel.IESupported = item.IESupported;
                        lstFilingTransactionDataModel.Add(objFilingTransactionDataModel);
                    }
                    client.Close();
                    return lstFilingTransactionDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
        }


        /// <summary>
        /// mapGetContributionTypeDataDALResponse
        /// </summary>
        /// <returns></returns>
        internal IList<ContributionTypeModel> mapGetContributionTypeDataDALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ContributionTypeModel> lstContributionTypeModel = new List<ContributionTypeModel>();
                    ContributionTypeModel objContributionTypeModel;

                    var results = client.GetContributionTypeData();

                    foreach (var item in results)
                    {
                        objContributionTypeModel = new ContributionTypeModel();
                        objContributionTypeModel.ContributionTypeId = item.ContributionTypeId;
                        objContributionTypeModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objContributionTypeModel.ContributionTypeAbbrev = item.ContributionTypeAbbrev;
                        lstContributionTypeModel.Add(objContributionTypeModel);
                    }
                    client.Close();
                    return lstContributionTypeModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
        }

        internal IList<ContributorNameModel> mapGetContributionNameDataDALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ContributorNameModel> lstContributorNameModel = new List<ContributorNameModel>();
                    ContributorNameModel objContributorNameModel;

                    var results = client.GetContributionNameData();

                    foreach (var item in results)
                    {
                        objContributorNameModel = new ContributorNameModel();
                        objContributorNameModel.ContributorTypeId = item.ContributorTypeId;
                        objContributorNameModel.ContributorTypeDesc = item.ContributorTypeDesc;
                        objContributorNameModel.ContributorTypeAbbrev = item.ContributorTypeAbbrev;
                        lstContributorNameModel.Add(objContributorNameModel);
                    }
                    client.Close();
                    return lstContributorNameModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        internal IList<DisclosurePreiodModel> mapGetDisclosurePeriodDataDALResponse(String strElectTypeId, String strfilerID, String strElectYearId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<DisclosurePreiodModel> lstDisclosurePreiodModel = new List<DisclosurePreiodModel>();
                    DisclosurePreiodModel objDisclosurePreiodModel;

                    var results = client.GetDisclosurePeriodData(strElectTypeId, strfilerID, strElectYearId);

                    foreach (var item in results)
                    {
                        objDisclosurePreiodModel = new DisclosurePreiodModel();
                        objDisclosurePreiodModel.FilingTypeId = item.FilingTypeId;
                        objDisclosurePreiodModel.FilingDesc = item.FilingDesc;
                        objDisclosurePreiodModel.FilingAbbrev = item.FilingAbbrev;
                        lstDisclosurePreiodModel.Add(objDisclosurePreiodModel);
                    }
                    client.Close();
                    return lstDisclosurePreiodModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        internal IList<ElectionDateModel> mapGetElectionDateDataDALResponse(String strElectYearId, String strElectTypeId, String strOfficeTypeId, String strCounty, String strMunicipality)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ElectionDateModel> lstElectionDateModel = new List<ElectionDateModel>();
                    ElectionDateModel objElectionDateModel;

                    var results = client.GetElectionDateData(strElectYearId, strElectTypeId, strOfficeTypeId, strCounty, strMunicipality);

                    foreach (var item in results)
                    {
                        objElectionDateModel = new ElectionDateModel();
                        objElectionDateModel.ElectId = item.ElectId;
                        objElectionDateModel.ElectDate = Convert.ToDateTime(item.ElectDate).ToString("MM/dd/yyyy");
                        lstElectionDateModel.Add(objElectionDateModel);
                    }
                    client.Close();
                    return lstElectionDateModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        internal IList<FilerCommitteeModel> mapGetFilerCommitteeDataDALResponse(String strFilerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilerCommitteeModel> lstFilerCommitteeModel = new List<FilerCommitteeModel>();
                    FilerCommitteeModel objFilerCommitteeModel;

                    var results = client.GetFilerCommitteeData(strFilerID);

                    foreach (var item in results)
                    {
                        objFilerCommitteeModel = new FilerCommitteeModel();
                        objFilerCommitteeModel.FilerId = item.FilerId;
                        objFilerCommitteeModel.CommitteeId = item.CommitteeId;
                        objFilerCommitteeModel.CommitteeName = item.CommitteeName;
                        objFilerCommitteeModel.OfficeId = item.OfficeId;
                        objFilerCommitteeModel.personID = item.personID;
                        objFilerCommitteeModel.TreasurerId = item.TreasurerId;
                        objFilerCommitteeModel.CommTypeId = item.CommTypeId;
                        objFilerCommitteeModel.OfficTypeID = item.OfficTypeID;
                        objFilerCommitteeModel.OfficeTypeDesc = item.OfficeTypeDesc;
                        lstFilerCommitteeModel.Add(objFilerCommitteeModel);
                    }
                    client.Close();
                    return lstFilerCommitteeModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        internal IList<PaymentMethodModel> mapGetPaymentMethodDataDALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<PaymentMethodModel> lstPaymentMethodModel = new List<PaymentMethodModel>();
                    PaymentMethodModel objPaymentMethodModel;

                    var results = client.GetPaymentMethodData();

                    foreach (var item in results)
                    {
                        objPaymentMethodModel = new PaymentMethodModel();
                        objPaymentMethodModel.PaymentTypeId = item.PaymentTypeId;
                        objPaymentMethodModel.PaymentTypeDesc = item.PaymentTypeDesc;
                        objPaymentMethodModel.PaymentTypeAbbrev = item.PaymentTypeAbbrev;
                        lstPaymentMethodModel.Add(objPaymentMethodModel);
                    }
                    client.Close();
                    return lstPaymentMethodModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        internal IList<PurposeCodeModel> mapGetPurposeCodeDataDALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();
                    PurposeCodeModel objPurposeCodeModel;

                    var results = client.GetPurposeCodeData();

                    foreach (var item in results)
                    {
                        objPurposeCodeModel = new PurposeCodeModel();
                        objPurposeCodeModel.PurposeCodeId = item.PurposeCodeId;
                        objPurposeCodeModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objPurposeCodeModel.PurposeCodeAbbrev = item.PurposeCodeAbbrev;
                        lstPurposeCodeModel.Add(objPurposeCodeModel);
                    }
                    client.Close();
                    return lstPurposeCodeModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal IList<ReceiptCodeModel> mapGetReceiptCodeDataDALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ReceiptCodeModel> lstReceiptCodeModel = new List<ReceiptCodeModel>();
                    ReceiptCodeModel objReceiptCodeModel;

                    var results = client.GetReceiptCodeData();

                    foreach (var item in results)
                    {
                        objReceiptCodeModel = new ReceiptCodeModel();
                        objReceiptCodeModel.ReceiptCodeId = item.ReceiptCodeId;
                        objReceiptCodeModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objReceiptCodeModel.ReceiptCodeAbbrev = item.ReceiptCodeAbbrev;
                        lstReceiptCodeModel.Add(objReceiptCodeModel);
                    }
                    client.Close();
                    return lstReceiptCodeModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        internal IList<ReceiptTypeModel> mapGetReceiptTypeDataDALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ReceiptTypeModel> lstReceiptTypeModel = new List<ReceiptTypeModel>();
                    ReceiptTypeModel objReceiptTypeModel;

                    var results = client.GetReceiptTypeData();

                    foreach (var item in results)
                    {
                        objReceiptTypeModel = new ReceiptTypeModel();
                        objReceiptTypeModel.ReceiptTypeId = item.ReceiptTypeId;
                        objReceiptTypeModel.ReceiptTypeDesc = item.ReceiptTypeDesc;
                        objReceiptTypeModel.ReceiptTypeAbbrev = item.ReceiptTypeAbbrev;
                        lstReceiptTypeModel.Add(objReceiptTypeModel);
                    }
                    client.Close();
                    return lstReceiptTypeModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        internal IList<TransferTypeModel> mapGetTransferTypeDataDALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<TransferTypeModel> lstTransferTypeModel = new List<TransferTypeModel>();
                    TransferTypeModel objTransferTypeModel;

                    var results = client.GetTransferTypeData();

                    foreach (var item in results)
                    {
                        objTransferTypeModel = new TransferTypeModel();
                        objTransferTypeModel.TransferTypeId = item.TransferTypeId;
                        objTransferTypeModel.TransferTypeDesc = item.TransferTypeDesc;
                        objTransferTypeModel.TransferTypeAbbrev = item.TransferTypeAbbrev;
                        lstTransferTypeModel.Add(objTransferTypeModel);
                    }
                    client.Close();
                    return lstTransferTypeModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        internal IList<ElectionYearModel> mapGetElectionYearDataDALResponse(String filerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ElectionYearModel> lstElectionYearModel = new List<ElectionYearModel>();
                    ElectionYearModel objElectionYearModel;

                    var results = client.GetElectionYearData(filerID);

                    foreach (var item in results)
                    {
                        objElectionYearModel = new ElectionYearModel();
                        objElectionYearModel.ElectionYearId = item.ElectionYearId;
                        objElectionYearModel.ElectionYearValue = item.ElectionYearValue;
                        lstElectionYearModel.Add(objElectionYearModel);
                    }
                    client.Close();
                    return lstElectionYearModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        internal IList<ElectionTypeModel> mapGetElectionTypeDataDALResponse(String strElectionYearId,
            String strOfficeTypeId, String strCountyId, String strMunicipalityId, String strCommTypeId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ElectionTypeModel> lstElectionTypeModel = new List<ElectionTypeModel>();
                    ElectionTypeModel objElectionTypeModel;

                    var results = client.GetElectionTypeData(strElectionYearId, strOfficeTypeId,
                        strCountyId, strMunicipalityId, strCommTypeId);

                    foreach (var item in results)
                    {
                        objElectionTypeModel = new ElectionTypeModel();
                        objElectionTypeModel.ElectionTypeId = item.ElectionTypeId;
                        objElectionTypeModel.ElectionTypeDesc = item.ElectionTypeDesc;
                        lstElectionTypeModel.Add(objElectionTypeModel);
                    }
                    client.Close();
                    return lstElectionTypeModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        /// <summary>
        /// mapGetFilingCutOffDateDataDALResponse
        /// </summary>
        /// <param name="strElectYearId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <returns></returns>
        internal IList<FilingCutOffDateModel> mapGetFilingCutOffDateDataDALResponse(String strElectYearId, String strFilingTypeId, String strOfficeTypeId, String strFilingDateId, String strCuttOffDateId, String strElectionDateId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingCutOffDateModel> lstFilingCutOffDateModel = new List<FilingCutOffDateModel>();
                    FilingCutOffDateModel objFilingCutOffDateModel;

                    var results = client.GetFilingCutOffDateData(strElectYearId, strFilingTypeId, strOfficeTypeId, strFilingDateId, strCuttOffDateId, strElectionDateId);

                    foreach (var item in results)
                    {
                        objFilingCutOffDateModel = new FilingCutOffDateModel();
                        objFilingCutOffDateModel.PoliticalCalDateId = item.PoliticalCalDateId;
                        objFilingCutOffDateModel.PoliticalCalLabelId = item.PoliticalCalLabelId;
                        objFilingCutOffDateModel.FilingDueDate = item.FilingDueDate;
                        objFilingCutOffDateModel.CutOffDate = item.CutOffDate;
                        lstFilingCutOffDateModel.Add(objFilingCutOffDateModel);
                    }
                    client.Close();
                    return lstFilingCutOffDateModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        /// <summary>
        /// mapGetContributorTypesDataDALResponse
        /// </summary>
        /// <returns></returns>
        internal IList<ContributorTypesModel> mapGetContributorTypesDataDALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ContributorTypesModel> lstContributorTypesModel = new List<ContributorTypesModel>();
                    ContributorTypesModel objContributorTypesModel;

                    var results = client.GetContributorTypesData();

                    foreach (var item in results)
                    {
                        objContributorTypesModel = new ContributorTypesModel();
                        objContributorTypesModel.ContributorTypeId = item.ContributorTypeId;
                        objContributorTypesModel.ContributoryTypeDesc = item.ContributoryTypeDesc;
                        lstContributorTypesModel.Add(objContributorTypesModel);
                    }
                    client.Close();
                    return lstContributorTypesModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        } 

        /// <summary>
        /// mapGetTransactionTypesDataDALResponse
        /// </summary>
        /// <returns></returns>
        internal IList<TransactionTypesModel> mapGetTransactionTypesDataDALResponse(String strCandCommId = "")
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<TransactionTypesModel> lstTransactionTypesModel = new List<TransactionTypesModel>();
                    TransactionTypesModel objTransactionTypesModel;

                    var results = client.GetTransactionTypesData(strCandCommId);

                    foreach (var item in results)
                    {
                        objTransactionTypesModel = new TransactionTypesModel();
                        objTransactionTypesModel.FilingSchedId = item.FilingSchedId;
                        objTransactionTypesModel.FilingSchedDesc = item.FilingSchedDesc;
                        objTransactionTypesModel.FilingSchedAbbrev = item.FilingSchedAbbrev;
                        lstTransactionTypesModel.Add(objTransactionTypesModel);
                    }
                    client.Close();
                    return lstTransactionTypesModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        /// <summary>
        /// mapGetDisclosureTypesDataDALResponse 
        /// </summary>
        /// <returns></returns>
        internal IList<DisclosureTypesModel> mapGetDisclosureTypesDataDALResponse(String strCandCommId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<DisclosureTypesModel> lstDisclosureTypesModel = new List<DisclosureTypesModel>();
                    DisclosureTypesModel objDisclosureTypesModel;

                    var results = client.GetDisclosureTypesData(strCandCommId);

                    foreach (var item in results)
                    {
                        objDisclosureTypesModel = new DisclosureTypesModel();
                        objDisclosureTypesModel.DisclosureTypeId = item.DisclosureTypeId;
                        if (item.DisclosureSubTypeDesc != null)
                            objDisclosureTypesModel.DisclosureTypeDesc = item.DisclosureTypeDesc + " - " + item.DisclosureSubTypeDesc;
                        objDisclosureTypesModel.DisclosureTypeDesc = item.DisclosureTypeDesc;
                        objDisclosureTypesModel.DisclosureSubTypeDesc = item.DisclosureSubTypeDesc;
                        lstDisclosureTypesModel.Add(objDisclosureTypesModel);
                    }
                    client.Close();
                    return lstDisclosureTypesModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        /// <summary>
        /// mapAddFilingTransactionsDataDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal string mapAddFlngTransContrInKindDataDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.ElectionDate = objFilingTransactionsModel.ElectionDate;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.FilingTypeId = objFilingTransactionsModel.FilingTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.ElectionYear = objFilingTransactionsModel.ElectionYear;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.OrgDate = objFilingTransactionsModel.OrgDate;
                    objFilingTransactionsContract.FlngEntFirstName = objFilingTransactionsModel.FlngEntFirstName;
                    objFilingTransactionsContract.FlngEntLastName = objFilingTransactionsModel.FlngEntLastName;
                    objFilingTransactionsContract.FlngEntMiddleName = objFilingTransactionsModel.FlngEntMiddleName;
                    objFilingTransactionsContract.DistOffCandBalProp = objFilingTransactionsModel.DistOffCandBalProp;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.RItemized = objFilingTransactionsModel.RItemized;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.ContributorTypeId = objFilingTransactionsModel.ContributorTypeId;
                    objFilingTransactionsContract.ContributionTypeId = objFilingTransactionsModel.ContributionTypeId;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.PayDate = objFilingTransactionsModel.PayDate;
                    objFilingTransactionsContract.OwedAmt = objFilingTransactionsModel.OwedAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.ResigTermTypeId = objFilingTransactionsModel.ResigTermTypeId;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;
                    objFilingTransactionsContract.MunicipalityID = objFilingTransactionsModel.MunicipalityID;
                    objFilingTransactionsContract.TreasurerEmployer = objFilingTransactionsModel.TreasurerEmployer;
                    objFilingTransactionsContract.TreasurerOccupation = objFilingTransactionsModel.TreasurerOccupation;
                    objFilingTransactionsContract.TreasurerStreetAddress = objFilingTransactionsModel.TreasurerStreetAddress;
                    objFilingTransactionsContract.TreasurerCity = objFilingTransactionsModel.TreasurerCity;
                    objFilingTransactionsContract.TreasurerState = objFilingTransactionsModel.TreasurerState;
                    objFilingTransactionsContract.TreasurerZip = objFilingTransactionsModel.TreasurerZip;
                    objFilingTransactionsContract.CommTypeID = objFilingTransactionsModel.CommTypeID;
                    objFilingTransactionsContract.RContributions = objFilingTransactionsModel.RContributions;

                    string result = client.AddFlngTransContrInKindData(objFilingTransactionsContract);
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

        internal IList<OfficeTypeModel> mapGetOfficeTypeDALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<OfficeTypeModel> lstOfficeTypeModel = new List<OfficeTypeModel>();
                    OfficeTypeModel objOfficeTypeModel;

                    var results = client.GetOfficeType();

                    foreach (var item in results)
                    {
                        objOfficeTypeModel = new OfficeTypeModel();
                        objOfficeTypeModel.OfficeTypeId = item.OfficeTypeId;
                        objOfficeTypeModel.OfficeTypeDesc = item.OfficeTypeDesc;
                        lstOfficeTypeModel.Add(objOfficeTypeModel);
                    }
                    client.Close();
                    return lstOfficeTypeModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        internal IList<CountyModel> mapGetCountyDALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<CountyModel> lstCountyModel = new List<CountyModel>();
                    CountyModel objCountyModel;

                    var results = client.GetCounty();

                    foreach (var item in results)
                    {
                        objCountyModel = new CountyModel();
                        objCountyModel.CountyId = item.CountyId;
                        objCountyModel.CountyDesc = item.CountyDesc;
                        lstCountyModel.Add(objCountyModel);
                    }
                    client.Close();
                    return lstCountyModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        internal IList<MunicipalityModel> mapGetMunicipalityDALResponse(String strCountyId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<MunicipalityModel> lstMunicipalityModel = new List<MunicipalityModel>();
                    MunicipalityModel objMunicipalityModel;

                    var results = client.GetMunicipality(strCountyId);

                    foreach (var item in results)
                    {
                        objMunicipalityModel = new MunicipalityModel();
                        objMunicipalityModel.MunicipalityId = item.MunicipalityId;
                        objMunicipalityModel.MunicipalityDesc = item.MunicipalityDesc;
                        lstMunicipalityModel.Add(objMunicipalityModel);
                    }
                    client.Close();
                    return lstMunicipalityModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        /// <summary>
        /// mapGetAutoCompleteNameAddressDALResponse
        /// </summary>
        /// <param name="name"></param>
        /// <param name="strFilerId"></param>
        /// <param name="strFLName"></param>
        /// <returns></returns>
        internal IList<AutoCompFLNameAddressModel> mapGetAutoCompleteNameAddressDALResponse(String name, String strFilerId, String strFLName)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<AutoCompFLNameAddressModel> lstAutoCompFLNameAddressModel = new List<AutoCompFLNameAddressModel>();
                    AutoCompFLNameAddressModel objAutoCompFLNameAddressModel;

                    var results = client.GetAutoCompleteNameAddress(name, strFilerId, strFLName);

                    foreach (var item in results)
                    {
                        objAutoCompFLNameAddressModel = new AutoCompFLNameAddressModel();
                        objAutoCompFLNameAddressModel.FilingEntityId = item.FilingEntityId;
                        objAutoCompFLNameAddressModel.FilingEntityName = item.FilingEntityName;
                        objAutoCompFLNameAddressModel.FilingEntityFirstName = item.FilingEntityFirstName;
                        objAutoCompFLNameAddressModel.FilingEntityMiddleName = item.FilingEntityMiddleName;
                        objAutoCompFLNameAddressModel.FilingEntityLastName = item.FilingEntityLastName;
                        objAutoCompFLNameAddressModel.FilingEntityStreetNum = item.FilingEntityStreetNum;
                        objAutoCompFLNameAddressModel.FilingEntityStreetName = item.FilingEntityStreetName;
                        objAutoCompFLNameAddressModel.FilingEntityCity = item.FilingEntityCity;
                        objAutoCompFLNameAddressModel.FilingEntityState = item.FilingEntityState;
                        objAutoCompFLNameAddressModel.FilingEntityZip = item.FilingEntityZip;
                        objAutoCompFLNameAddressModel.FilingEntityCountry = item.FilingEntityCountry;
                        objAutoCompFLNameAddressModel.FilingEntityNameAndAddress = item.FilingEntityNameAndAddress;
                        lstAutoCompFLNameAddressModel.Add(objAutoCompFLNameAddressModel);
                    }
                    client.Close();
                    return lstAutoCompFLNameAddressModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        /// <summary>
        /// mapDeleteFilingTransactionsDataDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        internal Boolean mapDeleteFilingTransactionsDataDALResponse(String strTransNumber, String strModifiedBy, String strFilerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    Boolean results = client.DeleteFilingTransactionsData(strTransNumber, strModifiedBy, strFilerID);
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
        /// mapDeleteFlngTransExpPaySchedFNDataDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        internal Boolean mapDeleteFlngTransExpPaySchedFNDataDALResponse(String strLoanLiabNumberOrg, String strTransNumberOrg, String strRLiability, String strModifiedBy, String strFilerID, String strSchedID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    Boolean results = client.DeleteFlngTransExpPaySchedFNData(strLoanLiabNumberOrg, strTransNumberOrg, strRLiability, strModifiedBy, strFilerID, strSchedID);
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
        /// Viewable Column DAL
        /// </summary>
        /// <param name="strUniqueID"></param>
        /// <param name="strApplicationName"></param>
        /// <param name="strPageName"></param>
        /// <returns></returns>
        internal IList<ViewableColumnModel> GetViewableColumnsDAL(String strUniqueID, String strApplicationName, String strPageName)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ViewableColumnModel> lstViewableColumnModel = new List<ViewableColumnModel>();
                    IList<ViewableColumnModel> lstViewableColumnModelDefault = new List<ViewableColumnModel>();
                    IList<ViewableColumnModel> lstViewableColumnModelResults = new List<ViewableColumnModel>();
                    ViewableColumnModel objViewableColumnModel;

                    var results = client.GetViewableColumns(strUniqueID, strApplicationName, strPageName);

                    foreach (var item in results)
                    {
                        objViewableColumnModel = new ViewableColumnModel();
                        objViewableColumnModel.ViewableFieldID = item.ViewableFieldID.ToString();
                        objViewableColumnModel.UniqueID = item.UniqueID;
                        objViewableColumnModel.ColumnName = item.ColumnName;
                        objViewableColumnModel.Viewable = item.Viewable;
                        lstViewableColumnModel.Add(objViewableColumnModel);
                    }

                    if (strPageName == "FileDisclosureReport")
                    {
                        foreach (var item in lstViewableColumnModel)
                        {
                            //if (item.ViewableFieldID == "9" || item.ViewableFieldID == "21" || item.ViewableFieldID == "23" || item.ViewableFieldID == "24" || item.ViewableFieldID == "28" || item.ViewableFieldID == "26")
                            if (item.ColumnName.ToString() == "Amount" || item.ColumnName == "Entity Name" || item.ColumnName == "First Name" || item.ColumnName == "Last Name" || item.ColumnName == "Transaction Date" || item.ColumnName == "Transaction Type")
                            {
                                objViewableColumnModel = new ViewableColumnModel();
                                objViewableColumnModel.ViewableFieldID = item.ViewableFieldID.ToString();
                                objViewableColumnModel.UniqueID = item.UniqueID;
                                objViewableColumnModel.ColumnName = item.ColumnName;
                                objViewableColumnModel.Viewable = item.Viewable;
                                lstViewableColumnModelDefault.Add(objViewableColumnModel);
                            }
                            else
                            {
                                objViewableColumnModel = new ViewableColumnModel();
                                objViewableColumnModel.ViewableFieldID = item.ViewableFieldID.ToString();
                                objViewableColumnModel.UniqueID = item.UniqueID;
                                objViewableColumnModel.ColumnName = item.ColumnName;
                                objViewableColumnModel.Viewable = item.Viewable;
                                lstViewableColumnModelResults.Add(objViewableColumnModel);
                            }
                        }
                    }
                    else if (strPageName == "NonItemized24HNotice")
                    {
                        foreach (var item in lstViewableColumnModel)
                        {
                            if (item.ColumnName.ToString() == "Submission Date" || item.ColumnName.ToString() == "Entity Name" || item.ColumnName.ToString() == "Last Name" || item.ColumnName.ToString() == "First Name" || item.ColumnName.ToString() == "Transaction Date" || item.ColumnName.ToString() == "Transaction Type" || item.ColumnName.ToString() == "Amount")
                            {
                                objViewableColumnModel = new ViewableColumnModel();
                                objViewableColumnModel.ViewableFieldID = item.ViewableFieldID.ToString();
                                objViewableColumnModel.UniqueID = item.UniqueID;
                                objViewableColumnModel.ColumnName = item.ColumnName;
                                objViewableColumnModel.Viewable = item.Viewable;
                                lstViewableColumnModelDefault.Add(objViewableColumnModel);
                            }
                            else
                            {
                                objViewableColumnModel = new ViewableColumnModel();
                                objViewableColumnModel.ViewableFieldID = item.ViewableFieldID.ToString();
                                objViewableColumnModel.UniqueID = item.UniqueID;
                                objViewableColumnModel.ColumnName = item.ColumnName;
                                objViewableColumnModel.Viewable = item.Viewable;
                                lstViewableColumnModelResults.Add(objViewableColumnModel);
                            }
                        }
                    }
                    else if (strPageName == "IE-WeeklyExpenditure")
                    {
                        foreach (var item in lstViewableColumnModel)
                        {
                            if (item.ColumnName.ToString() == "Submission Date" || item.ColumnName.ToString() == "Entity Name" || item.ColumnName.ToString() == "Transaction Date" || item.ColumnName.ToString() == "Transaction Type" || item.ColumnName.ToString() == "Amount")
                            {
                                objViewableColumnModel = new ViewableColumnModel();
                                objViewableColumnModel.ViewableFieldID = item.ViewableFieldID.ToString();
                                objViewableColumnModel.UniqueID = item.UniqueID;
                                objViewableColumnModel.ColumnName = item.ColumnName;
                                objViewableColumnModel.Viewable = item.Viewable;
                                lstViewableColumnModelDefault.Add(objViewableColumnModel);
                            }
                            else
                            {
                                objViewableColumnModel = new ViewableColumnModel();
                                objViewableColumnModel.ViewableFieldID = item.ViewableFieldID.ToString();
                                objViewableColumnModel.UniqueID = item.UniqueID;
                                objViewableColumnModel.ColumnName = item.ColumnName;
                                objViewableColumnModel.Viewable = item.Viewable;
                                lstViewableColumnModelResults.Add(objViewableColumnModel);
                            }
                        }
                    }
                    else if (strPageName == "IE-WeeklyContribution")
                    {
                        foreach (var item in lstViewableColumnModel)
                        {
                            if (item.ColumnName.ToString() == "Submission Date" || item.ColumnName.ToString() == "Entity Name" || item.ColumnName.ToString() == "Transaction Date" || item.ColumnName.ToString() == "Transaction Type" || item.ColumnName.ToString() == "Amount")
                            {
                                objViewableColumnModel = new ViewableColumnModel();
                                objViewableColumnModel.ViewableFieldID = item.ViewableFieldID.ToString();
                                objViewableColumnModel.UniqueID = item.UniqueID;
                                objViewableColumnModel.ColumnName = item.ColumnName;
                                objViewableColumnModel.Viewable = item.Viewable;
                                lstViewableColumnModelDefault.Add(objViewableColumnModel);
                            }
                            else
                            {
                                objViewableColumnModel = new ViewableColumnModel();
                                objViewableColumnModel.ViewableFieldID = item.ViewableFieldID.ToString();
                                objViewableColumnModel.UniqueID = item.UniqueID;
                                objViewableColumnModel.ColumnName = item.ColumnName;
                                objViewableColumnModel.Viewable = item.Viewable;
                                lstViewableColumnModelResults.Add(objViewableColumnModel);
                            }
                        }
                    }
                    else if (strPageName == "IE-24HourContribution")
                    {
                        foreach (var item in lstViewableColumnModel)
                        {
                            if (item.ColumnName.ToString() == "Submission Date" || item.ColumnName.ToString() == "Entity Name" || item.ColumnName.ToString() == "Transaction Date" || item.ColumnName.ToString() == "Transaction Type" || item.ColumnName.ToString() == "Amount")
                            {
                                objViewableColumnModel = new ViewableColumnModel();
                                objViewableColumnModel.ViewableFieldID = item.ViewableFieldID.ToString();
                                objViewableColumnModel.UniqueID = item.UniqueID;
                                objViewableColumnModel.ColumnName = item.ColumnName;
                                objViewableColumnModel.Viewable = item.Viewable;
                                lstViewableColumnModelDefault.Add(objViewableColumnModel);
                            }
                            else
                            {
                                objViewableColumnModel = new ViewableColumnModel();
                                objViewableColumnModel.ViewableFieldID = item.ViewableFieldID.ToString();
                                objViewableColumnModel.UniqueID = item.UniqueID;
                                objViewableColumnModel.ColumnName = item.ColumnName;
                                objViewableColumnModel.Viewable = item.Viewable;
                                lstViewableColumnModelResults.Add(objViewableColumnModel);
                            }
                        }
                    }
                    else if (strPageName == "IE-WeeklyLiabilityIncurred")
                    {
                        foreach (var item in lstViewableColumnModel)
                        {
                            if (item.ColumnName.ToString() == "Submission Date" || item.ColumnName.ToString() == "Entity Name" || item.ColumnName.ToString() == "Transaction Date" || item.ColumnName.ToString() == "Transaction Type" || item.ColumnName.ToString() == "Original Amount")
                            {
                                objViewableColumnModel = new ViewableColumnModel();
                                objViewableColumnModel.ViewableFieldID = item.ViewableFieldID.ToString();
                                objViewableColumnModel.UniqueID = item.UniqueID;
                                objViewableColumnModel.ColumnName = item.ColumnName;
                                objViewableColumnModel.Viewable = item.Viewable;
                                lstViewableColumnModelDefault.Add(objViewableColumnModel);
                            }
                            else
                            {
                                objViewableColumnModel = new ViewableColumnModel();
                                objViewableColumnModel.ViewableFieldID = item.ViewableFieldID.ToString();
                                objViewableColumnModel.UniqueID = item.UniqueID;
                                objViewableColumnModel.ColumnName = item.ColumnName;
                                objViewableColumnModel.Viewable = item.Viewable;
                                lstViewableColumnModelResults.Add(objViewableColumnModel);
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in lstViewableColumnModel)
                        {
                            objViewableColumnModel = new ViewableColumnModel();
                            objViewableColumnModel.ViewableFieldID = item.ViewableFieldID.ToString();
                            objViewableColumnModel.UniqueID = item.UniqueID;
                            objViewableColumnModel.ColumnName = item.ColumnName;
                            objViewableColumnModel.Viewable = item.Viewable;
                            lstViewableColumnModelResults.Add(objViewableColumnModel);
                        }
                    }

                    lstViewableColumnModelResults = lstViewableColumnModelResults.OrderBy(x => x.ColumnName).ToList();

                    lstViewableColumnModel = lstViewableColumnModelDefault.Concat(lstViewableColumnModelResults).ToList();
                    client.Close();
                    return lstViewableColumnModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        internal IList<ViewableColumnModel> GetViewableColumnsSortingDAL(String strUniqueID, String strApplicationName, String strPageName)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ViewableColumnModel> lstViewableColumnModel = new List<ViewableColumnModel>();
                    ViewableColumnModel objViewableColumnModel;
                    var results = client.GetViewableColumns(strUniqueID, strApplicationName, strPageName);

                    foreach (var item in results)
                    {
                        objViewableColumnModel = new ViewableColumnModel();
                        objViewableColumnModel.ViewableFieldID = item.ViewableFieldID.ToString();
                        objViewableColumnModel.UniqueID = item.UniqueID;
                        objViewableColumnModel.ColumnName = item.ColumnName;
                        objViewableColumnModel.Viewable = item.Viewable;
                        lstViewableColumnModel.Add(objViewableColumnModel);
                    }
                    client.Close();
                    return lstViewableColumnModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        /// <summary>
        /// Update Column DAL
        /// </summary>
        /// <param name="uniqueID"></param>
        /// <param name="applicationName"></param>
        /// <param name="pageName"></param>
        /// <param name="uniqueValue"></param>
        /// <param name="modifyBy"></param>
        /// <returns></returns>
        internal Boolean UpdateColumnValueDAL(String uniqueID, String applicationName, String pageName, String uniqueValue, String modifyBy)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    Boolean results = client.UpdateColumnValue(uniqueID,
                                                             applicationName,
                                                             pageName,
                                                             uniqueValue,
                                                             modifyBy);
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
        /// mapUpdateFilingTransContrInKindDataDALResponse
        /// </summary>
        /// <param name="objFilingTransactionDataModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateFilingTransContrInKindDataDALResponse(FilingTransactionDataModel objFilingTransactionDataModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionDataContract objFilingTransactionDataContract = new FilingTransactionDataContract();
                    objFilingTransactionDataContract.FilingTransId = objFilingTransactionDataModel.FilingTransId;
                    objFilingTransactionDataContract.FilingEntityId = objFilingTransactionDataModel.FilingEntityId;
                    objFilingTransactionDataContract.ContributionTypeId = objFilingTransactionDataModel.ContributionTypeId;
                    objFilingTransactionDataContract.SchedDate = objFilingTransactionDataModel.SchedDate;
                    objFilingTransactionDataContract.PayNumber = objFilingTransactionDataModel.PayNumber;
                    objFilingTransactionDataContract.PaymentTypeId = objFilingTransactionDataModel.PaymentTypeId;
                    objFilingTransactionDataContract.OriginalAmount = objFilingTransactionDataModel.OriginalAmount;
                    objFilingTransactionDataContract.TransExplanation = objFilingTransactionDataModel.TransExplanation;
                    objFilingTransactionDataContract.FilingEntityName = objFilingTransactionDataModel.FilingEntityName;
                    objFilingTransactionDataContract.FilingFirstName = objFilingTransactionDataModel.FilingFirstName;
                    objFilingTransactionDataContract.FilingMiddleName = objFilingTransactionDataModel.FilingMiddleName;
                    objFilingTransactionDataContract.FilingLastName = objFilingTransactionDataModel.FilingLastName;
                    objFilingTransactionDataContract.FilingCountry = objFilingTransactionDataModel.FilingCountry;
                    objFilingTransactionDataContract.FilingStreetName = objFilingTransactionDataModel.FilingStreetName;
                    objFilingTransactionDataContract.FilingCity = objFilingTransactionDataModel.FilingCity;
                    objFilingTransactionDataContract.FilingState = objFilingTransactionDataModel.FilingState;
                    objFilingTransactionDataContract.FilingZip = objFilingTransactionDataModel.FilingZip;
                    objFilingTransactionDataContract.ModifiedBy = objFilingTransactionDataModel.ModifiedBy;
                    objFilingTransactionDataContract.FilerId = objFilingTransactionDataModel.FilerId;
                    objFilingTransactionDataContract.TreasurerEmployer = objFilingTransactionDataModel.TreasurerEmployer;
                    objFilingTransactionDataContract.TreasurerOccuptaion = objFilingTransactionDataModel.TreasurerOccuptaion;
                    objFilingTransactionDataContract.TreasurerStreetAddress = objFilingTransactionDataModel.TreasurerStreetAddress;
                    objFilingTransactionDataContract.TreasurerCity = objFilingTransactionDataModel.TreasurerCity;
                    objFilingTransactionDataContract.TreasurerState = objFilingTransactionDataModel.TreasurerState;
                    objFilingTransactionDataContract.TreasurerZip = objFilingTransactionDataModel.TreasurerZip;
                    objFilingTransactionDataContract.CommTypeID = objFilingTransactionDataModel.CommTypeID;
                    objFilingTransactionDataContract.RContributions = objFilingTransactionDataModel.RContributions;

                    Boolean returnValue = client.UpdateFilingTransContrInKindData(objFilingTransactionDataContract);
                    client.Close();
                    return returnValue;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        internal IList<ContributorNameModel> mapGetPartnerSubContractorDataDALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ContributorNameModel> lstContributorNameModel = new List<ContributorNameModel>();
                    ContributorNameModel objContributorNameModel;

                    var results = client.GetPartnerSubContractorData();

                    foreach (var item in results)
                    {
                        objContributorNameModel = new ContributorNameModel();
                        objContributorNameModel.ContributorTypeId = item.ContributorTypeId;
                        objContributorNameModel.ContributorTypeDesc = item.ContributorTypeDesc;
                        objContributorNameModel.ContributorTypeAbbrev = item.ContributorTypeAbbrev;
                        lstContributorNameModel.Add(objContributorNameModel);
                    }
                    client.Close();
                    return lstContributorNameModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        //internal Boolean mapAddLoanReceivedDALResponse(IList<FilingTransactionsModel> objFilingTransactionsModel)
        //{
        //    List<FilingTransactionsContract> lstFilingTransactionsContract = new List<FilingTransactionsContract>();                        
        //    FilingTransactionsContract objFilingTransactionsContract;            

        //    foreach (var item in objFilingTransactionsModel)
        //    {
        //        objFilingTransactionsContract = new FilingTransactionsContract();
        //        objFilingTransactionsContract.FilerId = item.FilerId;
        //        objFilingTransactionsContract.FilingTransId = item.FilingTransId;
        //        objFilingTransactionsContract.FilingSchedId = item.FilingSchedId;
        //        objFilingTransactionsContract.SchedDate = item.SchedDate;
        //        objFilingTransactionsContract.OrgAmt = item.OrgAmt;
        //        objFilingTransactionsContract.ElectionDate = item.ElectionDate;
        //        objFilingTransactionsContract.ElectionTypeId = item.ElectionTypeId;
        //        objFilingTransactionsContract.OfficeTypeId = item.OfficeTypeId;
        //        objFilingTransactionsContract.FilingTypeId = item.FilingTypeId;
        //        objFilingTransactionsContract.ElectYearId = item.ElectYearId;
        //        objFilingTransactionsContract.ElectionYear = item.ElectionYear;
        //        objFilingTransactionsContract.FilingEntId = item.FilingEntId;
        //        objFilingTransactionsContract.FlngEntFirstName = item.FlngEntFirstName;
        //        objFilingTransactionsContract.FlngEntLastName = item.FlngEntLastName;
        //        objFilingTransactionsContract.FlngEntMiddleName = item.FlngEntMiddleName;
        //        objFilingTransactionsContract.DistOffCandBalProp = item.DistOffCandBalProp;
        //        objFilingTransactionsContract.FlngEntStrNum = item.FlngEntStrNum;
        //        objFilingTransactionsContract.FlngEntStrName = item.FlngEntStrName;
        //        objFilingTransactionsContract.FlngEntCity = item.FlngEntCity;
        //        objFilingTransactionsContract.FlngEntState = item.FlngEntState;
        //        objFilingTransactionsContract.FlngEntZip = item.FlngEntZip;
        //        objFilingTransactionsContract.FlngEntZip4 = item.FlngEntZip4;
        //        objFilingTransactionsContract.TransExplanation = item.TransExplanation;
        //        objFilingTransactionsContract.CreatedBy = item.CreatedBy;
        //        lstFilingTransactionsContract.Add(objFilingTransactionsContract);                
        //    }
        //    bool result = client.AddLoanReceivedData(lstFilingTransactionsContract.ToArray());
        //    return result;
        //}

        /// <summary>
        /// mapAddContrInKindPartnersDataDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapAddContrInKindPartnersDataDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();

                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.TransNumber = objFilingTransactionsModel.TransNumber;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntFirstName = objFilingTransactionsModel.FlngEntFirstName;
                    objFilingTransactionsContract.FlngEntLastName = objFilingTransactionsModel.FlngEntLastName;
                    objFilingTransactionsContract.FlngEntMiddleName = objFilingTransactionsModel.FlngEntMiddleName;
                    objFilingTransactionsContract.DistOffCandBalProp = objFilingTransactionsModel.DistOffCandBalProp;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.RItemized = objFilingTransactionsModel.RItemized;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.TreasurerEmployer = objFilingTransactionsModel.TreasurerEmployer;
                    objFilingTransactionsContract.TreasurerOccupation = objFilingTransactionsModel.TreasurerOccupation;
                    objFilingTransactionsContract.TreasurerStreetAddress = objFilingTransactionsModel.TreasurerStreetAddress;
                    objFilingTransactionsContract.TreasurerCity = objFilingTransactionsModel.TreasurerCity;
                    objFilingTransactionsContract.TreasurerState = objFilingTransactionsModel.TreasurerState;
                    objFilingTransactionsContract.TreasurerZip = objFilingTransactionsModel.TreasurerZip;
                    objFilingTransactionsContract.CommTypeID = objFilingTransactionsModel.CommTypeID;
                    objFilingTransactionsContract.RContributions = objFilingTransactionsModel.RContributions;
                    objFilingTransactionsContract.SchedID = objFilingTransactionsModel.SchedID;

                    Boolean result = client.AddContrInKindPartnersData(objFilingTransactionsContract);
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
        /// mapGetContrInKindPartnersDataDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<ContrInKindPartnersModel> mapGetContrInKindPartnersDataDALResponse(String strFilingTransId, String strFilerId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ContrInKindPartnersModel> lstContrInKindPartnersModel = new List<ContrInKindPartnersModel>();
                    ContrInKindPartnersModel objContrInKindPartnersModel;

                    var results = client.GetContrInKindPartnersData(strFilingTransId, strFilerId);

                    foreach (var item in results)
                    {
                        objContrInKindPartnersModel = new ContrInKindPartnersModel();
                        objContrInKindPartnersModel.FilingTransId = item.FilingTransId;
                        objContrInKindPartnersModel.FilingEntityId = item.FilingEntityId;
                        objContrInKindPartnersModel.PartnershipName = item.PartnershipName;
                        objContrInKindPartnersModel.PartnerFirstName = item.PartnerFirstName;
                        objContrInKindPartnersModel.PartnerMiddleName = item.PartnerMiddleName;
                        objContrInKindPartnersModel.PartnerLastName = item.PartnerLastName;
                        objContrInKindPartnersModel.PartnerStreetNo = item.PartnerStreetNo;
                        objContrInKindPartnersModel.PartnerStreetName = item.PartnerStreetName;
                        objContrInKindPartnersModel.PartnerCity = item.PartnerCity;
                        objContrInKindPartnersModel.PartnerState = item.PartnerState;
                        objContrInKindPartnersModel.PartnerZip5 = item.PartnerZip5;
                        objContrInKindPartnersModel.PartnershipCountry = item.PartnershipCountry;
                        objContrInKindPartnersModel.PartnerAmountAttributed = item.PartnerAmountAttributed;
                        objContrInKindPartnersModel.PartnerExplanation = item.PartnerExplanation;
                        objContrInKindPartnersModel.RItemized = item.RUnitemzied;
                        objContrInKindPartnersModel.TransNumber = item.TransNumber;
                        objContrInKindPartnersModel.TransMapping = item.TransMapping;
                        objContrInKindPartnersModel.TreasurerEmployer = item.TreasurerEmployer;
                        objContrInKindPartnersModel.TreasurerOccupation = item.TreasurerOccupation;
                        objContrInKindPartnersModel.TreaAddress = item.TreaAddress;
                        objContrInKindPartnersModel.TreaAddr1 = item.TreaAddr1;
                        objContrInKindPartnersModel.TreaCity = item.TreaCity;
                        objContrInKindPartnersModel.TreaState = item.TreaState;
                        objContrInKindPartnersModel.TreaZipCode = item.TreaZipCode;
                        objContrInKindPartnersModel.RContributions = item.RContributions;
                        lstContrInKindPartnersModel.Add(objContrInKindPartnersModel);
                    }
                    client.Close();
                    return lstContrInKindPartnersModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        /// <summary>
        /// Add Transfer In scheudled data DAL
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal string AddFilingTransaction_TransferIn_DAL(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.TransferTypeId = objFilingTransactionsModel.TransferTypeId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.FilingTypeId = objFilingTransactionsModel.FilingTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.FlngEntZip4 = objFilingTransactionsModel.FlngEntZip4;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;
                    objFilingTransactionsContract.ResigTermTypeId = objFilingTransactionsModel.ResigTermTypeId;
                    objFilingTransactionsContract.MunicipalityID = objFilingTransactionsModel.MunicipalityID;

                    string result = client.AddFilingTransaction_TransferIn(objFilingTransactionsContract);
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
        /// Update Filing Transaction
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean UpdateFilingTransaction_TransferIn_DAL(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.TransferTypeId = objFilingTransactionsModel.TransferTypeId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.FilingTypeId = objFilingTransactionsModel.FilingTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.FlngEntZip4 = objFilingTransactionsModel.FlngEntZip4;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.TransNumber = objFilingTransactionsModel.TransNumber;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;

                    Boolean result = client.UpdateFilingTransaction_TransferIn(objFilingTransactionsContract);
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
        /// mapDeleteContrInKindPartnersDataDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strFilingTransMapping"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        internal Boolean mapDeleteContrInKindPartnersDataDALResponse(String strTransNumber, String strModifiedBy, String strFilerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    Boolean returnValue = client.DeleteContrInKindPartnersData(strTransNumber, strModifiedBy, strFilerID);
                    client.Close();
                    return returnValue;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        /// <summary>
        /// mapUpdateContrInKindPartnersDataDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateContrInKindPartnersDataDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();

                    objFilingTransactionsContract.TransNumber = objFilingTransactionsModel.TransNumber;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntFirstName = objFilingTransactionsModel.FlngEntFirstName;
                    objFilingTransactionsContract.FlngEntMiddleName = objFilingTransactionsModel.FlngEntMiddleName;
                    objFilingTransactionsContract.FlngEntLastName = objFilingTransactionsModel.FlngEntLastName;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.ModifiedBy = objFilingTransactionsModel.ModifiedBy;
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.TreasurerEmployer = objFilingTransactionsModel.TreasurerEmployer;
                    objFilingTransactionsContract.TreasurerOccupation = objFilingTransactionsModel.TreasurerOccupation;
                    objFilingTransactionsContract.TreasurerStreetAddress = objFilingTransactionsModel.TreasurerStreetAddress;
                    objFilingTransactionsContract.TreasurerCity = objFilingTransactionsModel.TreasurerCity;
                    objFilingTransactionsContract.TreasurerState = objFilingTransactionsModel.TreasurerState;
                    objFilingTransactionsContract.TreasurerZip = objFilingTransactionsModel.TreasurerZip;
                    objFilingTransactionsContract.CommTypeID = objFilingTransactionsModel.CommTypeID;
                    objFilingTransactionsContract.RContributions = objFilingTransactionsModel.RContributions;

                    Boolean returnValue = client.UpdateContrInKindPartnersData(objFilingTransactionsContract);
                    client.Close();
                    return returnValue;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        /// <summary>
        /// mapAddFilingTransactionNonCompHKReceiptsDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal string mapAddFilingTransactionNonCompHKReceiptsDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.ReceiptCodeId = objFilingTransactionsModel.ReceiptCodeId;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.ElectionDate = objFilingTransactionsModel.ElectionDate;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.FilingTypeId = objFilingTransactionsModel.FilingTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.ElectionYear = objFilingTransactionsModel.ElectionYear;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntFirstName = objFilingTransactionsModel.FlngEntFirstName;
                    objFilingTransactionsContract.FlngEntLastName = objFilingTransactionsModel.FlngEntLastName;
                    objFilingTransactionsContract.FlngEntMiddleName = objFilingTransactionsModel.FlngEntMiddleName;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.RItemized = objFilingTransactionsModel.RItemized;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;
                    objFilingTransactionsContract.ResigTermTypeId = objFilingTransactionsModel.ResigTermTypeId;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;
                    objFilingTransactionsContract.MunicipalityID = objFilingTransactionsModel.MunicipalityID;

                    string results = client.AddFilingTransaction_NonCompHKReceipts(objFilingTransactionsContract);
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
        /// mapUpdateFilingTransNonCompHKReceiptsDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateFilingTransNonCompHKReceiptsDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionContract = new FilingTransactionsContract();
                    objFilingTransactionContract.TransNumber = objFilingTransactionsModel.TransNumber;
                    objFilingTransactionContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionContract.ReceiptCodeId = objFilingTransactionsModel.ReceiptCodeId;
                    objFilingTransactionContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionContract.FlngEntFirstName = objFilingTransactionsModel.FlngEntFirstName;
                    objFilingTransactionContract.FlngEntMiddleName = objFilingTransactionsModel.FlngEntMiddleName;
                    objFilingTransactionContract.FlngEntLastName = objFilingTransactionsModel.FlngEntLastName;
                    objFilingTransactionContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionContract.ModifiedBy = objFilingTransactionsModel.ModifiedBy;
                    objFilingTransactionContract.FilerId = objFilingTransactionsModel.FilerId;

                    Boolean results = client.UpdateFilingTransNonCompHKReceipts(objFilingTransactionContract);
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

        #region mapAddFlngTransContrMonetaryDataDALResponse
        /// <summary>
        /// mapAddFlngTransContrMonetaryDataDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal string mapAddFlngTransContrMonetaryDataDALResponse(FilingTransactionsModel objFilingTransactionsModel) 
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.ContributorTypeId = objFilingTransactionsModel.ContributorTypeId;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.ElectionDate = objFilingTransactionsModel.ElectionDate;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.FilingTypeId = objFilingTransactionsModel.FilingTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.ElectionYear = objFilingTransactionsModel.ElectionYear;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntFirstName = objFilingTransactionsModel.FlngEntFirstName;
                    objFilingTransactionsContract.FlngEntLastName = objFilingTransactionsModel.FlngEntLastName;
                    objFilingTransactionsContract.FlngEntMiddleName = objFilingTransactionsModel.FlngEntMiddleName;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.RItemized = objFilingTransactionsModel.RItemized;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.ResigTermTypeId = objFilingTransactionsModel.ResigTermTypeId;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;
                    objFilingTransactionsContract.MunicipalityID = objFilingTransactionsModel.MunicipalityID;
                    objFilingTransactionsContract.IsClaim = objFilingTransactionsModel.IsClaim;
                    objFilingTransactionsContract.InDistrict = objFilingTransactionsModel.InDistrict;
                    objFilingTransactionsContract.Minor = objFilingTransactionsModel.Minor;
                    objFilingTransactionsContract.Vendor = objFilingTransactionsModel.Vendor;
                    objFilingTransactionsContract.Lobbyist = objFilingTransactionsModel.Lobbyist;
                    objFilingTransactionsContract.TreasurerEmployer = objFilingTransactionsModel.TreasurerEmployer;
                    objFilingTransactionsContract.TreasurerOccupation = objFilingTransactionsModel.TreasurerOccupation;
                    objFilingTransactionsContract.TreasurerStreetAddress = objFilingTransactionsModel.TreasurerStreetAddress;
                    objFilingTransactionsContract.TreasurerCity = objFilingTransactionsModel.TreasurerCity;
                    objFilingTransactionsContract.TreasurerState = objFilingTransactionsModel.TreasurerState;
                    objFilingTransactionsContract.TreasurerZip = objFilingTransactionsModel.TreasurerZip;
                    objFilingTransactionsContract.CommTypeID = objFilingTransactionsModel.CommTypeID;
                    objFilingTransactionsContract.RContributions = objFilingTransactionsModel.RContributions;

                    string result = client.AddFlngTransContrMonetaryData(objFilingTransactionsContract);
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
        #endregion mapAddFlngTransContrMonetaryDataDALResponse

        /// <summary>
        /// UpdateFlngTransMonetaryContrDataDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateFlngTransMonetaryContrDataDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.TransNumber = objFilingTransactionsModel.TransNumber;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.ContributorTypeId = objFilingTransactionsModel.ContributorTypeId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntFirstName = objFilingTransactionsModel.FlngEntFirstName;
                    objFilingTransactionsContract.FlngEntMiddleName = objFilingTransactionsModel.FlngEntMiddleName;
                    objFilingTransactionsContract.FlngEntLastName = objFilingTransactionsModel.FlngEntLastName;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.ModifiedBy = objFilingTransactionsModel.ModifiedBy;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.FilingTypeId = objFilingTransactionsModel.FilingTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.IsClaim = objFilingTransactionsModel.IsClaim;
                    objFilingTransactionsContract.InDistrict = objFilingTransactionsModel.InDistrict;
                    objFilingTransactionsContract.Minor = objFilingTransactionsModel.Minor;
                    objFilingTransactionsContract.Vendor = objFilingTransactionsModel.Vendor;
                    objFilingTransactionsContract.Lobbyist = objFilingTransactionsModel.Lobbyist;
                    objFilingTransactionsContract.TreasurerEmployer = objFilingTransactionsModel.TreasurerEmployer;
                    objFilingTransactionsContract.TreasurerOccupation = objFilingTransactionsModel.TreasurerOccupation;
                    objFilingTransactionsContract.TreasurerStreetAddress = objFilingTransactionsModel.TreasurerStreetAddress;
                    objFilingTransactionsContract.TreasurerCity = objFilingTransactionsModel.TreasurerCity;
                    objFilingTransactionsContract.TreasurerState = objFilingTransactionsModel.TreasurerState;
                    objFilingTransactionsContract.TreasurerZip = objFilingTransactionsModel.TreasurerZip;
                    objFilingTransactionsContract.CommTypeID = objFilingTransactionsModel.CommTypeID;
                    objFilingTransactionsContract.RContributions = objFilingTransactionsModel.RContributions;

                    Boolean returnValue = client.UpdateFlngTransMonetaryContrData(objFilingTransactionsContract);
                    client.Close();
                    return returnValue;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        /// <summary>
        /// mapAddFlngTransExpenditureDataDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal String mapAddFlngTransExpenditureDataDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.TransNumber = objFilingTransactionsModel.TransNumber;
                    objFilingTransactionsContract.TransNumberOrg = objFilingTransactionsModel.TransNumberOrg;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.PurposeCodeId = objFilingTransactionsModel.PurposeCodeId;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.OrgDate = objFilingTransactionsModel.OrgDate;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.LiabilityOrgAmt = objFilingTransactionsModel.LiabilityOrgAmt;
                    objFilingTransactionsContract.LiabilityOwedAmt = objFilingTransactionsModel.LiabilityOwedAmt;
                    objFilingTransactionsContract.LiabilityPartialAmt = objFilingTransactionsModel.LiabilityPartialAmt;
                    objFilingTransactionsContract.RLiability = objFilingTransactionsModel.RLiability;
                    objFilingTransactionsContract.RSubcontractor = objFilingTransactionsModel.RSubcontractor;
                    objFilingTransactionsContract.RItemized = objFilingTransactionsModel.RItemized;
                    objFilingTransactionsContract.RLiabilityExists = objFilingTransactionsModel.RLiabilityExists;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.LiabilityTransExplanation = objFilingTransactionsModel.LiabilityTransExplanation;
                    objFilingTransactionsContract.ElectionDate = objFilingTransactionsModel.ElectionDate;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.FilingTypeId = objFilingTransactionsModel.FilingTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.ElectionYear = objFilingTransactionsModel.ElectionYear;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;
                    objFilingTransactionsContract.ResigTermTypeId = objFilingTransactionsModel.ResigTermTypeId;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;
                    objFilingTransactionsContract.MunicipalityID = objFilingTransactionsModel.MunicipalityID;
                    objFilingTransactionsContract.SchedID = objFilingTransactionsModel.SchedID;
                    objFilingTransactionsContract.RIESupported = objFilingTransactionsModel.RIESupported;

                    String result = client.AddFlngTransExpenditureData(objFilingTransactionsContract);
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
        /// Add Transfer Out scheudled data DAL
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal string AddFilingTransaction_TransferOut_DAL(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.TransferTypeId = objFilingTransactionsModel.TransferTypeId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.FilingTypeId = objFilingTransactionsModel.FilingTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.FlngEntZip4 = objFilingTransactionsModel.FlngEntZip4;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;
                    objFilingTransactionsContract.ResigTermTypeId = objFilingTransactionsModel.ResigTermTypeId;
                    objFilingTransactionsContract.MunicipalityID = objFilingTransactionsModel.MunicipalityID;

                    string result = client.AddFilingTransaction_TransferOut(objFilingTransactionsContract);
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
        /// Update Filing Transaction
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean UpdateFilingTransaction_TransferOut_DAL(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.TransferTypeId = objFilingTransactionsModel.TransferTypeId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.FilingTypeId = objFilingTransactionsModel.FilingTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.FlngEntZip4 = objFilingTransactionsModel.FlngEntZip4;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.TransNumber = objFilingTransactionsModel.TransNumber;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;

                    Boolean result = client.UpdateFilingTransaction_TransferOut(objFilingTransactionsContract);
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
        /// Add Loan Received scheudled data DAL
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal string AddFilingTransaction_LoanReceived_DAL(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.OtherFilingSchedId = objFilingTransactionsModel.OtherFilingSchedId;
                    objFilingTransactionsContract.TransferTypeId = objFilingTransactionsModel.TransferTypeId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.OtherTransExplanation = objFilingTransactionsModel.OtherTransExplanation;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.FilingTypeId = objFilingTransactionsModel.FilingTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntFirstName = objFilingTransactionsModel.FlngEntFirstName;
                    objFilingTransactionsContract.FlngEntMiddleName = objFilingTransactionsModel.FlngEntMiddleName;
                    objFilingTransactionsContract.FlngEntLastName = objFilingTransactionsModel.FlngEntLastName;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.FlngEntZip4 = objFilingTransactionsModel.FlngEntZip4;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.LoanOtherId = objFilingTransactionsModel.LoanOtherId;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;
                    objFilingTransactionsContract.ResigTermTypeId = objFilingTransactionsModel.ResigTermTypeId;
                    objFilingTransactionsContract.MunicipalityID = objFilingTransactionsModel.MunicipalityID;
                    objFilingTransactionsContract.TreasurerEmployer = objFilingTransactionsModel.TreasurerEmployer;
                    objFilingTransactionsContract.TreasurerOccupation = objFilingTransactionsModel.TreasurerOccupation;
                    objFilingTransactionsContract.TreasurerStreetAddress = objFilingTransactionsModel.TreasurerStreetAddress;
                    objFilingTransactionsContract.TreasurerCity = objFilingTransactionsModel.TreasurerCity;
                    objFilingTransactionsContract.TreasurerState = objFilingTransactionsModel.TreasurerState;
                    objFilingTransactionsContract.TreasurerZip = objFilingTransactionsModel.TreasurerZip;
                    objFilingTransactionsContract.CommTypeID = objFilingTransactionsModel.CommTypeID;

                    string result = client.AddFilingTransaction_LoanReceived(objFilingTransactionsContract);
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

        internal string AddFilingTransaction_LoanRepayment_DAL(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.OtherFilingSchedId = objFilingTransactionsModel.OtherFilingSchedId;
                    objFilingTransactionsContract.TransferTypeId = objFilingTransactionsModel.TransferTypeId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.OtherTransExplanation = objFilingTransactionsModel.OtherTransExplanation;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.FilingTypeId = objFilingTransactionsModel.FilingTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntFirstName = objFilingTransactionsModel.FlngEntFirstName;
                    objFilingTransactionsContract.FlngEntMiddleName = objFilingTransactionsModel.FlngEntMiddleName;
                    objFilingTransactionsContract.FlngEntLastName = objFilingTransactionsModel.FlngEntLastName;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.LoanOtherId = objFilingTransactionsModel.LoanOtherId;
                    objFilingTransactionsContract.OtherAmount = objFilingTransactionsModel.OtherAmount;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;
                    objFilingTransactionsContract.ResigTermTypeId = objFilingTransactionsModel.ResigTermTypeId;
                    objFilingTransactionsContract.Loan_Lib_Number = objFilingTransactionsModel.Loan_Lib_Number;
                    objFilingTransactionsContract.TransNumber = objFilingTransactionsModel.TransNumber;
                    objFilingTransactionsContract.MunicipalityID = objFilingTransactionsModel.MunicipalityID;

                    string result = client.AddFilingTransaction_LoanRepayment(objFilingTransactionsContract);
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
        /// Update Filing Transaction
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean UpdateFilingTransaction_LoanReceived_DAL(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntFirstName = objFilingTransactionsModel.FlngEntFirstName;
                    objFilingTransactionsContract.FlngEntMiddleName = objFilingTransactionsModel.FlngEntMiddleName;
                    objFilingTransactionsContract.FlngEntLastName = objFilingTransactionsModel.FlngEntLastName;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.ModifiedBy = objFilingTransactionsModel.ModifiedBy;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.LoanOtherId = objFilingTransactionsModel.LoanOtherId;
                    objFilingTransactionsContract.IsAmtChanged = objFilingTransactionsModel.IsAmtChanged;
                    objFilingTransactionsContract.Loan_Lib_Number = objFilingTransactionsModel.Loan_Lib_Number;
                    objFilingTransactionsContract.TransNumber = objFilingTransactionsModel.TransNumber;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.TreasurerEmployer = objFilingTransactionsModel.TreasurerEmployer;
                    objFilingTransactionsContract.TreasurerOccupation = objFilingTransactionsModel.TreasurerOccupation;
                    objFilingTransactionsContract.TreasurerStreetAddress = objFilingTransactionsModel.TreasurerStreetAddress;
                    objFilingTransactionsContract.TreasurerCity = objFilingTransactionsModel.TreasurerCity;
                    objFilingTransactionsContract.TreasurerState = objFilingTransactionsModel.TreasurerState;
                    objFilingTransactionsContract.TreasurerZip = objFilingTransactionsModel.TreasurerZip;
                    objFilingTransactionsContract.CommTypeID = objFilingTransactionsModel.CommTypeID;
                    Boolean result = client.UpdateFilingTransaction_LoanReceived(objFilingTransactionsContract);
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
        /// Get Loaner Code
        /// </summary>
        /// <returns></returns>
        public IList<LoanerCodeModel> GetLoanerCodeDAL()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<LoanerCodeModel> lstLoanerCodeModel = new List<LoanerCodeModel>();
                    LoanerCodeModel objLoanerCodeModel;

                    var results = client.GetLoanerCode();

                    foreach (var item in results)
                    {
                        objLoanerCodeModel = new LoanerCodeModel();
                        objLoanerCodeModel.LoanerID = item.LoanerID;
                        objLoanerCodeModel.LoanerDesc = item.LoanerDesc;
                        lstLoanerCodeModel.Add(objLoanerCodeModel);
                    }
                    client.Close();
                    return lstLoanerCodeModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        /// <summary>
        /// GetAutoCompleteCreditorNameLiabDALResponse
        /// </summary>
        /// <param name="name"></param>
        /// <param name="strFilerId"></param>
        /// <returns></returns>
        internal IList<OutstandingLiabilityModel> mapGetAutoCompleteCreditorNameLiabDALResponse(String name, String strFilerId, String strNameFlag)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<OutstandingLiabilityModel> lstOutstandingLiabilityModel = new List<OutstandingLiabilityModel>();
                    OutstandingLiabilityModel objOutstandingLiabilityModel;

                    var results = client.GetAutoCompleteCreditorNameLiab(name, strFilerId, strNameFlag);

                    foreach (var item in results)
                    {
                        objOutstandingLiabilityModel = new OutstandingLiabilityModel();
                        objOutstandingLiabilityModel.FilingEntityId = item.FilingEntityId;
                        objOutstandingLiabilityModel.PayeeName = item.PayeeName;
                        objOutstandingLiabilityModel.FlngEntCountry = item.FlngEntCountry;
                        objOutstandingLiabilityModel.LiabilityStreetName = item.LiabilityStreetName;
                        objOutstandingLiabilityModel.LiabilityCity = item.LiabilityCity;
                        objOutstandingLiabilityModel.LiabilityState = item.LiabilityState;
                        objOutstandingLiabilityModel.LiabilityZipCode = item.LiabilityZipCode;
                        objOutstandingLiabilityModel.FilingEntityNameAndAddress = item.FilingEntityNameAndAddress;
                        lstOutstandingLiabilityModel.Add(objOutstandingLiabilityModel);
                    }
                    client.Close();
                    return lstOutstandingLiabilityModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        /// <summary>
        /// GetDateIncurredLiabDataDALResponse
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        internal IList<DateIncurredModel> mapGetDateIncurredLiabDataDALResponse(String strFilingEntityId, String strFilerId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<DateIncurredModel> lstDateIncurredModel = new List<DateIncurredModel>();
                    DateIncurredModel objDateIncurredModel;

                    var results = client.GetDateIncurredLiabData(strFilingEntityId, strFilerId);

                    foreach (var item in results)
                    {
                        objDateIncurredModel = new DateIncurredModel();
                        objDateIncurredModel.DateIncurredId = item.DateIncurredId;
                        objDateIncurredModel.DateIncurredValue = item.DateIncurredValue;
                        objDateIncurredModel.AmountLiability = item.AmountLiability;
                        lstDateIncurredModel.Add(objDateIncurredModel);
                    }
                    client.Close();
                    return lstDateIncurredModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        /// <summary>
        /// GetDateIncurredLiabDataDALResponse
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        internal IList<DateIncurredModel> mapGetDateIncurredLiabDataForForgivenDAL(String strFilingEntityId, String strFilerId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<DateIncurredModel> lstDateIncurredModel = new List<DateIncurredModel>();
                    DateIncurredModel objDateIncurredModel;

                    var results = client.GetDateIncurredLiabDataForForgiven(strFilingEntityId, strFilerId);

                    foreach (var item in results)
                    {
                        objDateIncurredModel = new DateIncurredModel();
                        objDateIncurredModel.DateIncurredId = item.DateIncurredId;
                        objDateIncurredModel.DateIncurredValue = item.DateIncurredValue;
                        objDateIncurredModel.AmountLiability = item.AmountLiability;
                        objDateIncurredModel.OutstandingAmount = item.OutstandingAmount;
                        lstDateIncurredModel.Add(objDateIncurredModel);
                    }
                    client.Close();
                    return lstDateIncurredModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        /// <summary>
        /// GetOriginalAmountLiabDataDALResponse
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        internal IList<OriginalAmountModel> mapGetOutstandingAmountLiabDataDALResponse(String strFilingEntityId, String strUpdateStatus, String strFilingTransId, String strFilingsId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<OriginalAmountModel> lstOriginalAmountModel = new List<OriginalAmountModel>();
                    OriginalAmountModel objOriginalAmountModel;

                    var results = client.GetOutstandingAmountLiabData(strFilingEntityId, strUpdateStatus, strFilingTransId, strFilingsId);

                    foreach (var item in results)
                    {
                        objOriginalAmountModel = new OriginalAmountModel();
                        objOriginalAmountModel.OriginalAmountId = item.OriginalAmountId;
                        objOriginalAmountModel.OutstandingAmount = item.OutstandingAmount;
                        lstOriginalAmountModel.Add(objOriginalAmountModel);
                    }
                    client.Close();
                    return lstOriginalAmountModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        /// <summary>
        /// mapGetExpenditureLiabilityExistsDALResponse
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        internal String mapGetExpenditureLiabilityExistsDALResponse(String strFilingEntityId, String strFlngEntyName, String filerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    String returnFlngEntityId = String.Empty;

                    returnFlngEntityId = client.GetExpenditureLiabilityExists(strFilingEntityId, strFlngEntyName, filerID);
                    client.Close();
                    return returnFlngEntityId;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        /// <summary>
        /// mapGetExpPaymentsLiabilityDataDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<OutstandingLiabilityModel> mapGetExpPaymentsLiabilityDataDALResponse(String strTransNumber, String strFilerId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<OutstandingLiabilityModel> lstOutstandingLiabilityModel = new List<OutstandingLiabilityModel>();
                    OutstandingLiabilityModel objOutstandingLiabilityModel;

                    var results = client.GetExpPaymentsLiabilityData(strTransNumber, strFilerId);

                    foreach (var item in results)
                    {
                        objOutstandingLiabilityModel = new OutstandingLiabilityModel();
                        objOutstandingLiabilityModel.TransNumber = item.TransNumber;
                        objOutstandingLiabilityModel.FilingEntityId = item.FilingEntityId;
                        objOutstandingLiabilityModel.PayeeName = item.PayeeName;
                        objOutstandingLiabilityModel.DateIncurred = item.DateIncurred.Trim();
                        objOutstandingLiabilityModel.OriginalAmount = "$" + item.OrignalAmount; // + ".00";
                        objOutstandingLiabilityModel.OutstandingAmount = "$" + item.OutstandingAmount; // + ".00";
                        objOutstandingLiabilityModel.CreditorName = item.CreditorName;
                        objOutstandingLiabilityModel.LiabilityStreetName = item.LiabilityStreetName;
                        objOutstandingLiabilityModel.LiabilityCity = item.LiabilityCity;
                        objOutstandingLiabilityModel.LiabilityState = item.LiabilityState;
                        objOutstandingLiabilityModel.LiabilityZipCode = item.LiabilityZipCode;
                        objOutstandingLiabilityModel.LiabilityExplanation = item.LiabilityExplanation;
                        lstOutstandingLiabilityModel.Add(objOutstandingLiabilityModel);
                    }
                    client.Close();
                    return lstOutstandingLiabilityModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        /// <summary>
        /// mapUpdateFlngTransExpenditureDataDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateFlngTransExpenditureDataDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.RLiability = objFilingTransactionsModel.RLiability;
                    objFilingTransactionsContract.RSubcontractor = objFilingTransactionsModel.RSubcontractor;
                    objFilingTransactionsContract.RItemized = objFilingTransactionsModel.RItemized;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.ModifiedBy = objFilingTransactionsModel.ModifiedBy;
                    objFilingTransactionsContract.Loan_Lib_Number = objFilingTransactionsModel.Loan_Lib_Number;
                    objFilingTransactionsContract.TransNumberOrg = objFilingTransactionsModel.TransNumberOrg;
                    objFilingTransactionsContract.IsAmtChanged = objFilingTransactionsModel.IsAmtChanged;
                    objFilingTransactionsContract.PurposeCodeId = objFilingTransactionsModel.PurposeCodeId;
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.SchedID = objFilingTransactionsModel.SchedID;
                    objFilingTransactionsContract.RIESupported = objFilingTransactionsModel.RIESupported;

                    Boolean returnValue = client.UpdateFlngTransExpenditureData(objFilingTransactionsContract);
                    client.Close();
                    return returnValue;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        /// <summary>
        /// mapGetSubcontracorsExistsDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal Boolean mapGetSubcontracorsExistsDALResponse(String strFilingTransId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    Boolean results = client.GetSubcontracorsExists(strFilingTransId);
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
        /// Get Date
        /// </summary>
        /// <returns></returns>
        internal IList<GetSearchForScheduledIModel> GetDate_SchedueledJDAL(string FILING_ENTITY_NAME, string ORG_AMT, string flng_Ent_FirstName,
                                                                 string flng_Ent_MiddleName, string flng_Ent_LastName, string filer_ID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<GetSearchForScheduledIModel> lstGetSearchForScheduledI = new List<GetSearchForScheduledIModel>();
                    GetSearchForScheduledIModel objGetSearchForScheduledI;

                    var results = client.GetDate_SchedueledJ(FILING_ENTITY_NAME, ORG_AMT, flng_Ent_FirstName, flng_Ent_MiddleName, flng_Ent_LastName, filer_ID);

                    foreach (var item in results)
                    {
                        objGetSearchForScheduledI = new GetSearchForScheduledIModel();
                        objGetSearchForScheduledI.Trans_Number = item.Trans_Number.ToString();
                        objGetSearchForScheduledI.Loan_Lib_Number = item.Loan_Lib_Number.ToString();
                        objGetSearchForScheduledI.Date = item.Date.ToString();
                        lstGetSearchForScheduledI.Add(objGetSearchForScheduledI);
                    }
                    client.Close();
                    return lstGetSearchForScheduledI;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        /// <summary>
        /// Get Amount
        /// </summary>
        /// <param name="filing_date"></param>
        /// <returns></returns>
        internal IList<GetSearchForScheduledIModel> GetAmount_SchedueledJDAL(string FILING_ENTITY_NAME, string flng_Ent_FirstName,
                                                                 string flng_Ent_MiddleName, string flng_Ent_LastName, string filer_ID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<GetSearchForScheduledIModel> lstGetSearchForScheduledI = new List<GetSearchForScheduledIModel>();
                    GetSearchForScheduledIModel objGetSearchForScheduledI;

                    var results = client.GetAmount_SchedueledJ(FILING_ENTITY_NAME, flng_Ent_FirstName, flng_Ent_MiddleName, flng_Ent_LastName, filer_ID);

                    foreach (var item in results)
                    {
                        objGetSearchForScheduledI = new GetSearchForScheduledIModel();
                        objGetSearchForScheduledI.Amount = item.Amount.ToString();
                        lstGetSearchForScheduledI.Add(objGetSearchForScheduledI);
                    }
                    client.Close();
                    return lstGetSearchForScheduledI;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        /// <summary>
        /// Get Name
        /// </summary>
        /// <param name="filing_date"></param>
        /// <param name="org_amt"></param>
        /// <returns></returns>
        internal IList<GetSearchForScheduledIModel> GetName_SchedueledJDAL(string filer_ID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<GetSearchForScheduledIModel> lstGetSearchForScheduledI = new List<GetSearchForScheduledIModel>();
                    GetSearchForScheduledIModel objGetSearchForScheduledI;

                    var results = client.GetName_SchedueledJ(filer_ID);

                    foreach (var item in results)
                    {
                        objGetSearchForScheduledI = new GetSearchForScheduledIModel();
                        objGetSearchForScheduledI.Name = item.Name.ToString();
                        objGetSearchForScheduledI.flng_Ent_FirstName = item.flng_Ent_FirstName.ToString();
                        objGetSearchForScheduledI.flng_Ent_MiddleName = item.flng_Ent_MiddleName.ToString();
                        objGetSearchForScheduledI.flng_Ent_LastName = item.flng_Ent_LastName.ToString();
                        lstGetSearchForScheduledI.Add(objGetSearchForScheduledI);
                    }
                    client.Close();
                    return lstGetSearchForScheduledI;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        /// <summary>
        /// Get Entity Data for Scheduled J
        /// </summary>
        /// <param name="filing_Trans_ID"></param>
        /// <returns></returns>
        internal IList<FilingTransactionsModel> GetScheduleJ_EntityDataDAL(string trans_Number, String filerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingTransactionsModel> lstFilingTransactionsModel = new List<FilingTransactionsModel>();
                    FilingTransactionsModel objFilingTransactionsModel;

                    var results = client.GetScheduleJ_EntityData(trans_Number, filerID);

                    foreach (var item in results)
                    {
                        objFilingTransactionsModel = new FilingTransactionsModel();
                        objFilingTransactionsModel.Loan_Lib_Number = item.Loan_Lib_Number.ToString();
                        objFilingTransactionsModel.TransNumber = item.TransNumber.ToString();
                        objFilingTransactionsModel.FlngEntName = item.FlngEntName.ToString();
                        objFilingTransactionsModel.FlngEntFirstName = item.FlngEntFirstName.ToString();
                        objFilingTransactionsModel.FlngEntMiddleName = item.FlngEntMiddleName.ToString();
                        objFilingTransactionsModel.FlngEntLastName = item.FlngEntLastName.ToString();
                        objFilingTransactionsModel.FlngEntStrName = item.FlngEntStrName.ToString();
                        objFilingTransactionsModel.FlngEntCity = item.FlngEntCity.ToString();
                        objFilingTransactionsModel.FlngEntState = item.FlngEntState.ToString();
                        objFilingTransactionsModel.FlngEntZip = item.FlngEntZip.ToString();
                        objFilingTransactionsModel.FlngEntCountry = item.FlngEntCountry.ToString();
                        objFilingTransactionsModel.OrgAmt = item.OrgAmt;
                        objFilingTransactionsModel.LoanOtherId = item.LoanOtherId.ToString();
                        objFilingTransactionsModel.FilingEntId = item.FilingEntId.ToString();
                        if (item.SchedDate != "")
                        {
                            objFilingTransactionsModel.SchedDate = Convert.ToDateTime(item.SchedDate).ToShortDateString().ToString(); ;
                        }
                        else
                        {
                            objFilingTransactionsModel.SchedDate = item.SchedDate.ToString();
                        }
                        if (item.PaymentTypeId != null)
                            objFilingTransactionsModel.PaymentTypeId = item.PaymentTypeId;
                        else
                            objFilingTransactionsModel.PaymentTypeId = "";
                        if (item.PayNumber != null)
                            objFilingTransactionsModel.PayNumber = item.PayNumber;
                        else
                            objFilingTransactionsModel.PayNumber = "";

                        lstFilingTransactionsModel.Add(objFilingTransactionsModel);
                    }
                    client.Close();
                    return lstFilingTransactionsModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        /// <summary>
        /// Validate Scheduled J Amount
        /// </summary>
        /// <param name="filing_Trans_ID"></param>
        /// <returns></returns>
        internal IList<GetSearchForScheduledIModel> ValidateSchedJ_AmountDAL(string trans_Nubmer,string status, string FilerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<GetSearchForScheduledIModel> lstGetSearchForScheduledI = new List<GetSearchForScheduledIModel>();
                    GetSearchForScheduledIModel objGetSearchForScheduledI;

                    var results = client.ValidateSchedJ_Amount(trans_Nubmer, status, FilerID);

                    foreach (var item in results)
                    {
                        objGetSearchForScheduledI = new GetSearchForScheduledIModel();
                        objGetSearchForScheduledI.Amount = item.Amount.ToString();
                        objGetSearchForScheduledI.Original_Amt = item.Original_Amt.ToString();
                        objGetSearchForScheduledI.Date = item.Date.ToString();
                        lstGetSearchForScheduledI.Add(objGetSearchForScheduledI);
                    }
                    client.Close();
                    return lstGetSearchForScheduledI;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }
        /// <summary>
        /// AddFilingTransExpReimbursmentData
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapAddFilingTransExpReimbursmentDataDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.TransNumber = objFilingTransactionsModel.TransNumber;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PurposeCodeId = objFilingTransactionsModel.PurposeCodeId;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.RItemized = objFilingTransactionsModel.RItemized;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.SchedID = objFilingTransactionsModel.SchedID;

                    Boolean result = client.AddFilingTransExpReimbursmentData(objFilingTransactionsContract);
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
        /// mapGetFlngTransExpReimbursementDataDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<FilingTransactionsModel> mapGetFlngTransExpReimbursementDataDALResponse(String strTransNumber, String strFilerId, String strSchedID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingTransactionsModel> lstFilingTransactionsModel = new List<FilingTransactionsModel>();
                    FilingTransactionsModel objFilingTransactionsModel;

                    var results = client.GetFlngTransExpReimbursementData(strTransNumber, strFilerId, strSchedID);

                    foreach (var item in results)
                    {
                        objFilingTransactionsModel = new FilingTransactionsModel();
                        objFilingTransactionsModel.FilingTransId = item.FilingTransId;
                        objFilingTransactionsModel.FilingEntId = item.FilingEntId;
                        objFilingTransactionsModel.PurposeCodeId = item.PurposeCodeId;
                        objFilingTransactionsModel.SchedDate = item.SchedDate;
                        objFilingTransactionsModel.FlngEntName = item.FlngEntName;
                        objFilingTransactionsModel.FlngEntCountry = item.FlngEntCountry;
                        objFilingTransactionsModel.FlngEntStrName = item.FlngEntStrName;
                        objFilingTransactionsModel.FlngEntCity = item.FlngEntCity;
                        objFilingTransactionsModel.FlngEntState = item.FlngEntState;
                        objFilingTransactionsModel.FlngEntZip = item.FlngEntZip;
                        objFilingTransactionsModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objFilingTransactionsModel.OrgAmt = item.OrgAmt;
                        objFilingTransactionsModel.TransExplanation = item.TransExplanation;
                        if (item.RItemized == "Y")
                            objFilingTransactionsModel.RItemized = "Yes";
                        else
                            objFilingTransactionsModel.RItemized = "No";
                        objFilingTransactionsModel.TransNumber = item.TransNumber;
                        lstFilingTransactionsModel.Add(objFilingTransactionsModel);
                    }
                    client.Close();
                    return lstFilingTransactionsModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
        }

        /// <summary>
        /// mapGetReimbursementDetailsAmtDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal String mapGetReimbursementDetailsAmtDALResponse(String strTransNumber, String strFilerId, String strSchedID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    String strReimbursementDetailsAmt = String.Empty;

                    strReimbursementDetailsAmt = client.GetReimbursementDetailsAmt(strTransNumber, strFilerId, strSchedID);
                    client.Close();
                    return strReimbursementDetailsAmt;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapUpdateFilingTransExpReimbursmentDataDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateFilingTransExpReimbursmentDataDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.TransNumber = objFilingTransactionsModel.TransNumber;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PurposeCodeId = objFilingTransactionsModel.PurposeCodeId;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.SchedID = objFilingTransactionsModel.SchedID;

                    Boolean result = client.UpdateFilingTransExpReimbursmentData(objFilingTransactionsContract);
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
        /// mapDeleteFlngTransReimbursementDataSchedFDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strFilingTransMapping"></param>
        /// <param name="strModififedBy"></param> 
        /// <returns></returns>
        internal Boolean mapDeleteFlngTransReimbursementDataSchedFDALResponse(String strTransNumber, String strModififedBy, String strFilerId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    Boolean results = client.DeleteFlngTransReimbursementDataSchedF(strTransNumber, strModififedBy, strFilerId);
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
        /// mapAddFilingTransNonCompaignHKExpensesDataDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal String mapAddFilingTransNonCompaignHKExpensesDataDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PurposeCodeId = objFilingTransactionsModel.PurposeCodeId;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.ElectionDate = objFilingTransactionsModel.ElectionDate;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.FilingTypeId = objFilingTransactionsModel.FilingTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.ElectionYear = objFilingTransactionsModel.ElectionYear;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.RItemized = objFilingTransactionsModel.RItemized;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;
                    objFilingTransactionsContract.ResigTermTypeId = objFilingTransactionsModel.ResigTermTypeId;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;
                    objFilingTransactionsContract.MunicipalityID = objFilingTransactionsModel.MunicipalityID;

                    String results = client.AddFilingTransNonCompaignHKExpensesData(objFilingTransactionsContract);
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
        /// mapGetNCHKExpensesReimbursementDataDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<FilingTransactionsModel> mapGetNCHKExpensesReimbursementDataDALResponse(String strFilingTransId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingTransactionsModel> lstFilingTransactionsModel = new List<FilingTransactionsModel>();
                    FilingTransactionsModel objFilingTransactionsModel;

                    var results = client.GetNCHKExpensesReimbursementData(strFilingTransId);

                    foreach (var item in results)
                    {
                        objFilingTransactionsModel = new FilingTransactionsModel();
                        objFilingTransactionsModel.FilingTransId = item.FilingTransId;
                        objFilingTransactionsModel.FilingEntId = item.FilingEntId;
                        objFilingTransactionsModel.PurposeCodeId = item.PurposeCodeId;
                        objFilingTransactionsModel.SchedDate = item.SchedDate;
                        objFilingTransactionsModel.FlngEntName = item.FlngEntName;
                        objFilingTransactionsModel.FlngEntCountry = item.FlngEntCountry;
                        objFilingTransactionsModel.FlngEntStrName = item.FlngEntStrName;
                        objFilingTransactionsModel.FlngEntCity = item.FlngEntCity;
                        objFilingTransactionsModel.FlngEntState = item.FlngEntState;
                        objFilingTransactionsModel.FlngEntZip = item.FlngEntZip;
                        objFilingTransactionsModel.OrgAmt = item.OrgAmt;
                        objFilingTransactionsModel.TransExplanation = item.TransExplanation;
                        objFilingTransactionsModel.RItemized = item.RItemized;
                        objFilingTransactionsModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        lstFilingTransactionsModel.Add(objFilingTransactionsModel);
                    }
                    client.Close();
                    return lstFilingTransactionsModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapUpdateNonCompaignHKExpensesSchedQDataDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateNonCompaignHKExpensesSchedQDataDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.TransNumber = objFilingTransactionsModel.TransNumber;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.PurposeCodeId = objFilingTransactionsModel.PurposeCodeId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.ModifiedBy = objFilingTransactionsModel.ModifiedBy;
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;

                    Boolean results = client.UpdateNonCompaignHKExpensesSchedQData(objFilingTransactionsContract);
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
        internal IList<GetSearchForScheduledIModel> ValidateForUpdateScheJDAL(string filing_Trans_ID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<GetSearchForScheduledIModel> lstGetSearchForScheduledI = new List<GetSearchForScheduledIModel>();
                    GetSearchForScheduledIModel objGetSearchForScheduledI;

                    var results = client.ValidateForUpdateScheJ(filing_Trans_ID);

                    foreach (var item in results)
                    {
                        objGetSearchForScheduledI = new GetSearchForScheduledIModel();
                        objGetSearchForScheduledI.Amount = item.Amount.ToString();
                        objGetSearchForScheduledI.Original_Amt = item.Original_Amt.ToString();
                        lstGetSearchForScheduledI.Add(objGetSearchForScheduledI);
                    }
                    client.Close();
                    return lstGetSearchForScheduledI;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        internal Boolean UpdateLoanRepaymentDataDAL(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OtherAmount = objFilingTransactionsModel.OtherAmount;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.ModifiedBy = objFilingTransactionsModel.ModifiedBy;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntFirstName = objFilingTransactionsModel.FlngEntFirstName;
                    objFilingTransactionsContract.FlngEntMiddleName = objFilingTransactionsModel.FlngEntMiddleName;
                    objFilingTransactionsContract.FlngEntLastName = objFilingTransactionsModel.FlngEntLastName;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.LoanOtherId = objFilingTransactionsModel.LoanOtherId;
                    objFilingTransactionsContract.Loan_Lib_Number = objFilingTransactionsModel.Loan_Lib_Number;
                    objFilingTransactionsContract.TransNumber = objFilingTransactionsModel.TransNumber;
                    objFilingTransactionsContract.IsAmtChanged = objFilingTransactionsModel.IsAmtChanged;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    Boolean result = client.UpdateLoanRepaymentData(objFilingTransactionsContract);
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
        /// Delete Loan Received Entry
        /// </summary>
        /// <param name="filing_Trans_ID"></param>
        /// <param name="modify_By"></param>
        /// <returns></returns>
        internal Boolean DeleteLoanReceivedDAL(String transNumber, String strFilerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    Boolean returnValue = client.DeleteLoanReceived(transNumber, strFilerID);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }


        /// <summary>
        /// Delete Loan Repayment Entry
        /// </summary>
        /// <param name="filing_Trans_ID"></param>
        /// <param name="modify_By"></param>
        /// <returns></returns>
        internal Boolean DeleteLoanRepaymentDAL(String loan_Lib_Number, String transNumber, String modify_By, String strFilerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    Boolean returnValue = client.DeleteLoanRepayment(loan_Lib_Number, transNumber, modify_By, strFilerID);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// Get Filing Transaction data
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> GetFilingTransactionsForScheduledIJNDAL(FilingTransDataModel objFilingTransDataModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                    FilingTransactionDataModel objFilingTransactionDataModel;

                    FilingTransDataContract objFilingTransDataContract = new FilingTransDataContract();
                    objFilingTransDataContract.Loan_Lib_Num = objFilingTransDataModel.Loan_Lib_Num;
                    objFilingTransDataContract.SchedName = objFilingTransDataModel.SchedName;
                    objFilingTransDataContract.FilerId = objFilingTransDataModel.FilerId;

                    var results = client.GetFilingTransactionsForScheduledIJN(objFilingTransDataContract);

                    foreach (var item in results)
                    {
                        objFilingTransactionDataModel = new FilingTransactionDataModel();
                        objFilingTransactionDataModel.FilingTransId = item.FilingTransId;
                        objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                        objFilingTransactionDataModel.ContributorTypeId = item.ContributorTypeId;
                        objFilingTransactionDataModel.ContributorTypeDesc = item.ContributorTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.PaymentTypeId = item.PaymentTypeId;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.SchedDate = item.SchedDate;
                        objFilingTransactionDataModel.FilingSchedDesc = item.FilingSchedDesc;
                        objFilingTransactionDataModel.FilingEntityId = item.FilingEntityId;
                        objFilingTransactionDataModel.FilingEntityName = item.FilingEntityName;
                        objFilingTransactionDataModel.FilingFirstName = item.FilingFirstName;
                        objFilingTransactionDataModel.FilingMiddleName = item.FilingMiddleName;
                        objFilingTransactionDataModel.FilingLastName = item.FilingLastName;
                        objFilingTransactionDataModel.FilingCountry = item.FilingCountry;
                        objFilingTransactionDataModel.FilingStreetNumber = item.FilingStreetNumber;
                        objFilingTransactionDataModel.FilingStreetName = item.FilingStreetName;
                        objFilingTransactionDataModel.FilingCity = item.FilingCity;
                        objFilingTransactionDataModel.FilingState = item.FilingState;
                        objFilingTransactionDataModel.FilingZip = item.FilingZip;
                        objFilingTransactionDataModel.PaymentTypeDesc = item.PaymentTypeDesc;
                        objFilingTransactionDataModel.PayNumber = item.PayNumber;
                        objFilingTransactionDataModel.OriginalAmount = item.OriginalAmount;
                        objFilingTransactionDataModel.ReceiptTypeDesc = item.ReceiptTypeDesc;
                        objFilingTransactionDataModel.TransferTypeDesc = item.TransferTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.OriginalDate = item.OriginalDate;
                        objFilingTransactionDataModel.LoanerCode = item.LoanerCode;
                        objFilingTransactionDataModel.ElectionYear = item.ElectionYear;
                        objFilingTransactionDataModel.Office = item.Office;
                        objFilingTransactionDataModel.District = item.District;
                        objFilingTransactionDataModel.RLiability = item.RLiability;
                        objFilingTransactionDataModel.RSubcontractor = item.RSubcontractor;
                        objFilingTransactionDataModel.TransExplanation = item.TransExplanation;
                        objFilingTransactionDataModel.OwedAmount = item.OwedAmount;
                        objFilingTransactionDataModel.RItemized = item.RItemized;
                        objFilingTransactionDataModel.CreatedDate = item.CreatedDate;
                        lstFilingTransactionDataModel.Add(objFilingTransactionDataModel);
                    }
                    client.Close();
                    return lstFilingTransactionDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// Update Outstanding Loans
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        internal Boolean UpdateOutStandingLoansDataDAL(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilingTransId = objFilingTransactionsModel.FilingTransId;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.OtherTransExplanation = objFilingTransactionsModel.OtherTransExplanation;
                    objFilingTransactionsContract.ModifiedBy = objFilingTransactionsModel.ModifiedBy;

                    var returnValue = client.UpdateOutStandingLoansData(objFilingTransactionsContract);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// Check Scheduled for Outstanding Loans
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<FilingTransactionsModel> CheckOutstandingScheduledDAL(String strFilingTransId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingTransactionsModel> lstFilingTransactionsEntity = new List<FilingTransactionsModel>();
                    FilingTransactionsModel objFilingTransactionsEntity;

                    var results = client.CheckOutstandingScheduled(strFilingTransId);

                    foreach (var item in results)
                    {
                        objFilingTransactionsEntity = new FilingTransactionsModel();
                        objFilingTransactionsEntity.FilingTransId = item.FilingTransId;
                        lstFilingTransactionsEntity.Add(objFilingTransactionsEntity);
                    }
                    client.Close();
                    return lstFilingTransactionsEntity;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// Validate Loan Received Amount
        /// </summary>
        /// <param name="filing_Trans_ID"></param>
        /// <returns></returns>
        internal IList<GetSearchForScheduledIModel> ValidateSchedI_UpdateAmountDAL(string trans_Number, string FilerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<GetSearchForScheduledIModel> lstGetSearchForScheduledI = new List<GetSearchForScheduledIModel>();
                    GetSearchForScheduledIModel objGetSearchForScheduledI;

                    var results = client.ValidateSchedI_UpdateAmount(trans_Number, FilerID);

                    foreach (var item in results)
                    {
                        objGetSearchForScheduledI = new GetSearchForScheduledIModel();
                        objGetSearchForScheduledI.Amount = item.Amount.ToString();
                        lstGetSearchForScheduledI.Add(objGetSearchForScheduledI);
                    }
                    client.Close();
                    return lstGetSearchForScheduledI;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapGetExpLiabilityOwedAmtDALResponse
        /// </summary>
        /// <param name="strFlngEntityId"></param>
        /// <returns></returns>
        internal String mapGetExpLiabilityOwedAmtDALResponse(String strFlngEntityId, String filerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    String strExpLiabilityOwedAmt = String.Empty;

                    strExpLiabilityOwedAmt = client.GetExpLiabilityOwedAmt(strFlngEntityId, filerID);
                    client.Close();
                    return strExpLiabilityOwedAmt;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapGetExpSubContrTotAmtDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal String mapGetExpSubContrTotAmtDALResponse(String strTransNumber, String strFilerId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    String strExpSubContrTotAmt = String.Empty;

                    strExpSubContrTotAmt = client.GetExpSubContrTotAmt(strTransNumber, strFilerId);
                    client.Close();
                    return strExpSubContrTotAmt;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        internal String mapGetOutstandingLiabilityAmountDALResponse(String strFilingEntityId, String strFlngTransId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    String strOutstandingLiablityAmount = String.Empty;

                    strOutstandingLiablityAmount = client.GetOutstandingLiabilityAmount(strFilingEntityId, strFlngTransId);
                    client.Close();
                    return strOutstandingLiablityAmount;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// GetExpPayTotalLiabAmount
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <param name="strFlngTransId"></param>
        /// <returns></returns>
        internal String mapGetExpPayTotalLiabAmountDALResponse(String strTransNumber, String filerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    String strExpPayTotalLiabAmount = String.Empty;

                    strExpPayTotalLiabAmount = client.GetExpPayTotalLiabAmount(strTransNumber, filerID);
                    client.Close();
                    return strExpPayTotalLiabAmount;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapGetContributorTypesSchedCDALResponse
        /// </summary>
        /// <returns></returns>
        internal IList<ContributorNameModel> mapGetContributorTypesSchedCDALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ContributorNameModel> lstContributorNameModel = new List<ContributorNameModel>();
                    ContributorNameModel objContributorNameModel;

                    var results = client.GetContributorTypesSchedC();

                    foreach (var item in results)
                    {
                        objContributorNameModel = new ContributorNameModel();
                        objContributorNameModel.ContributorTypeId = item.ContributorTypeId;
                        objContributorNameModel.ContributorTypeDesc = item.ContributorTypeDesc;
                        objContributorNameModel.ContributorTypeAbbrev = item.ContributorTypeAbbrev;
                        lstContributorNameModel.Add(objContributorNameModel);
                    }
                    client.Close();
                    return lstContributorNameModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// Add Loan Forgiven
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>        
        /// 
        internal string AddFilingTransaction_LoanForgiven_DAL(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.OtherFilingSchedId = objFilingTransactionsModel.OtherFilingSchedId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.OtherAmount = objFilingTransactionsModel.OtherAmount;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.FilingTypeId = objFilingTransactionsModel.FilingTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntFirstName = objFilingTransactionsModel.FlngEntFirstName;
                    objFilingTransactionsContract.FlngEntMiddleName = objFilingTransactionsModel.FlngEntMiddleName;
                    objFilingTransactionsContract.FlngEntLastName = objFilingTransactionsModel.FlngEntLastName;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.LoanOtherId = objFilingTransactionsModel.LoanOtherId;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;
                    objFilingTransactionsContract.ResigTermTypeId = objFilingTransactionsModel.ResigTermTypeId;
                    objFilingTransactionsContract.Loan_Lib_Number = objFilingTransactionsModel.Loan_Lib_Number;
                    objFilingTransactionsContract.TransNumber = objFilingTransactionsModel.TransNumber;
                    objFilingTransactionsContract.MunicipalityID = objFilingTransactionsModel.MunicipalityID;

                    string results = client.AddFilingTransaction_LoanForgiven(objFilingTransactionsContract);
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
        /// Delete Loan Forgiven
        /// </summary>
        /// <param name="filing_Trans_ID"></param>
        /// <param name="modify_By"></param>
        /// <returns></returns>
        internal Boolean DeleteLoanForgivenDAL(String loan_Lib_Number, String transNumber, String modify_By, String strLiability, String strFilerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    Boolean returnValue = client.DeleteLoanForgiven(loan_Lib_Number, transNumber, modify_By, strLiability, strFilerID);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapGetPurposeCodeReimburDetailsDataDALResponse
        /// </summary>
        /// <returns></returns>
        internal IList<PurposeCodeModel> mapGetPurposeCodeReimburDetailsDataDALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();
                    PurposeCodeModel objPurposeCodeModel;

                    var results = client.GetPurposeCodeReimburDetailsData();

                    foreach (var item in results)
                    {
                        objPurposeCodeModel = new PurposeCodeModel();
                        objPurposeCodeModel.PurposeCodeId = item.PurposeCodeId;
                        objPurposeCodeModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objPurposeCodeModel.PurposeCodeAbbrev = item.PurposeCodeAbbrev;
                        lstPurposeCodeModel.Add(objPurposeCodeModel);
                    }
                    client.Close();
                    return lstPurposeCodeModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapGetPurposeCodeSubcontractorSchedFDALResponse
        /// </summary>
        /// <returns></returns>
        internal IList<PurposeCodeModel> mapGetPurposeCodeSubcontractorSchedFDALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();
                    PurposeCodeModel objPurposeCodeModel;

                    var results = client.GetPurposeCodeSubcontractorSchedF();

                    foreach (var item in results)
                    {
                        objPurposeCodeModel = new PurposeCodeModel();
                        objPurposeCodeModel.PurposeCodeId = item.PurposeCodeId;
                        objPurposeCodeModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objPurposeCodeModel.PurposeCodeAbbrev = item.PurposeCodeAbbrev;
                        lstPurposeCodeModel.Add(objPurposeCodeModel);
                    }
                    client.Close();
                    return lstPurposeCodeModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapGetPurposeCodeCreditCardItemSchedFDALResponse
        /// </summary>
        /// <returns></returns>
        internal IList<PurposeCodeModel> mapGetPurposeCodeCreditCardItemSchedFDALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();
                    PurposeCodeModel objPurposeCodeModel;

                    var results = client.GetPurposeCodeCreditCardItemSchedF();

                    foreach (var item in results)
                    {
                        objPurposeCodeModel = new PurposeCodeModel();
                        objPurposeCodeModel.PurposeCodeId = item.PurposeCodeId;
                        objPurposeCodeModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objPurposeCodeModel.PurposeCodeAbbrev = item.PurposeCodeAbbrev;
                        lstPurposeCodeModel.Add(objPurposeCodeModel);
                    }
                    client.Close();
                    return lstPurposeCodeModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapGetExpPayTransIdPopUpSchedFDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<ExpPaymentTransIdPopUpSchedFModel> mapGetExpPayTransIdPopUpSchedFDALResponse(String strTransNumber, String filerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ExpPaymentTransIdPopUpSchedFModel> lstExpPaymentTransIdPopUpSchedFModel = new List<ExpPaymentTransIdPopUpSchedFModel>();
                    ExpPaymentTransIdPopUpSchedFModel objExpPaymentTransIdPopUpSchedFModel;

                    var results = client.GetExpPayTransIdPopUpSchedF(strTransNumber, filerID);

                    foreach (var item in results)
                    {
                        objExpPaymentTransIdPopUpSchedFModel = new ExpPaymentTransIdPopUpSchedFModel();
                        objExpPaymentTransIdPopUpSchedFModel.TransNumber = item.TransNumber;
                        objExpPaymentTransIdPopUpSchedFModel.FilingSchedId = item.FilingSchedId;
                        objExpPaymentTransIdPopUpSchedFModel.ScheduleDate = item.ScheduleDate.Trim();
                        objExpPaymentTransIdPopUpSchedFModel.OrgAmount = item.OrgAmount;
                        lstExpPaymentTransIdPopUpSchedFModel.Add(objExpPaymentTransIdPopUpSchedFModel);
                    }
                    client.Close();
                    return lstExpPaymentTransIdPopUpSchedFModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// Add Loan Forgiven Liabilities
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        internal Boolean AddFilingTransaction_LoanForgiven_Liabiliites_DAL(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.RLiabilityExists = objFilingTransactionsModel.RLiabilityExists;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.OtherAmount = objFilingTransactionsModel.OtherAmount;
                    objFilingTransactionsContract.OwedAmt = objFilingTransactionsModel.OwedAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.FilingTypeId = objFilingTransactionsModel.FilingTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;
                    objFilingTransactionsContract.ResigTermTypeId = objFilingTransactionsModel.ResigTermTypeId;
                    objFilingTransactionsContract.TransNumber = objFilingTransactionsModel.TransNumber;
                    objFilingTransactionsContract.MunicipalityID = objFilingTransactionsModel.MunicipalityID;

                    Boolean result = client.AddFilingTransaction_LoanForgiven_Liabiliites(objFilingTransactionsContract);
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
        /// mapGetDateIncurredLiabUpdateDataDALResponse
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        internal IList<DateIncurredModel> mapGetDateIncurredLiabUpdateDataDALResponse(String strTransNumber, String strFilerId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<DateIncurredModel> lstDateIncurredModel = new List<DateIncurredModel>();
                    DateIncurredModel objDateIncurredModel;

                    var results = client.GetDateIncurredLiabUpdateData(strTransNumber, strFilerId);

                    foreach (var item in results)
                    {
                        objDateIncurredModel = new DateIncurredModel();
                        objDateIncurredModel.DateIncurredId = item.DateIncurredId;
                        objDateIncurredModel.DateIncurredValue = item.DateIncurredValue.Trim();
                        objDateIncurredModel.AmountLiability = item.AmountLiability;
                        lstDateIncurredModel.Add(objDateIncurredModel);
                    }
                    client.Close();
                    return lstDateIncurredModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// AddOtherReceivedReceiptsSchedE
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal string mapAddOtherReceivedReceiptsSchedEDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();

                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.ElectionDate = objFilingTransactionsModel.ElectionDate;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.FilingTypeId = objFilingTransactionsModel.FilingTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.ElectionYear = objFilingTransactionsModel.ElectionYear;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.ReceiptTypeId = objFilingTransactionsModel.ReceiptTypeId;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.RItemized = objFilingTransactionsModel.RItemized;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.ResigTermTypeId = objFilingTransactionsModel.ResigTermTypeId;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;
                    objFilingTransactionsContract.MunicipalityID = objFilingTransactionsModel.MunicipalityID;

                    string result = client.AddOtherReceivedReceiptsSchedE(objFilingTransactionsContract);
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

        // Update Other Receipts Received Transactions.
        /// <summary>
        /// UpdateOtherReceiptsReceivedSchedE
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        internal Boolean mapUpdateOtherReceiptsReceivedSchedEDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();

                    objFilingTransactionsContract.TransNumber = objFilingTransactionsModel.TransNumber;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.ReceiptTypeId = objFilingTransactionsModel.ReceiptTypeId;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.RItemized = objFilingTransactionsModel.RItemized;
                    objFilingTransactionsContract.ModifiedBy = objFilingTransactionsModel.ModifiedBy;
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;

                    Boolean returnValue = client.UpdateOtherReceiptsReceivedSchedE(objFilingTransactionsContract);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapGetOriginalNameDALResponse
        /// </summary>
        /// <returns></returns>
        internal IList<ExpPaymentOriginalNameModel> mapGetOriginalNameDALResponse(String strFilerId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ExpPaymentOriginalNameModel> lstExpPaymentOriginalNameModel = new List<ExpPaymentOriginalNameModel>();
                    ExpPaymentOriginalNameModel objExpPaymentOriginalNameModel;

                    var results = client.GetOriginalName(strFilerId);

                    foreach (var item in results)
                    {
                        objExpPaymentOriginalNameModel = new ExpPaymentOriginalNameModel();
                        objExpPaymentOriginalNameModel.FilingEntityId = item.FilingEntityId;
                        objExpPaymentOriginalNameModel.FilingEntityName = item.FilingEntityName;
                        lstExpPaymentOriginalNameModel.Add(objExpPaymentOriginalNameModel);
                    }
                    client.Close();
                    return lstExpPaymentOriginalNameModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapGetOriginalAmountDALResponse
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        internal IList<ExpPaymentOriginalAmountModel> mapGetOriginalAmountDALResponse(String strFilingEntityId, String strFilerId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ExpPaymentOriginalAmountModel> lstExpPaymentOriginalAmountModel = new List<ExpPaymentOriginalAmountModel>();
                    ExpPaymentOriginalAmountModel objExpPaymentOriginalAmountModel;

            var results = client.GetOriginalAmount(strFilingEntityId, strFilerId);

                    foreach (var item in results)
                    {
                        objExpPaymentOriginalAmountModel = new ExpPaymentOriginalAmountModel();
                        objExpPaymentOriginalAmountModel.TransNumber = item.TransNumber;
                        objExpPaymentOriginalAmountModel.OriginalAmount = item.OriginalAmount;
                        lstExpPaymentOriginalAmountModel.Add(objExpPaymentOriginalAmountModel);
                    }
                    client.Close();
                    return lstExpPaymentOriginalAmountModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapGetOriginalExpeseDateDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<ExpPaymentOriginalExpenseDateModel> mapGetOriginalExpeseDateDALResponse(String strTransNumber, String strFilerId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ExpPaymentOriginalExpenseDateModel> lstExpPaymentOriginalExpenseDateModel = new List<ExpPaymentOriginalExpenseDateModel>();
                    ExpPaymentOriginalExpenseDateModel objExpPaymentOriginalExpenseDateModel;

            var results = client.GetOriginalExpeseDate(strTransNumber, strFilerId);

                    foreach (var item in results)
                    {
                        objExpPaymentOriginalExpenseDateModel = new ExpPaymentOriginalExpenseDateModel();
                        objExpPaymentOriginalExpenseDateModel.TransNumber = item.TransNumber;
                        objExpPaymentOriginalExpenseDateModel.OriginalExpenseDate = item.OriginalExpenseDate.Trim().ToString();
                        lstExpPaymentOriginalExpenseDateModel.Add(objExpPaymentOriginalExpenseDateModel);
                    }
                    client.Close();
                    return lstExpPaymentOriginalExpenseDateModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapAddExpenditureRefundsSchedLDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal string mapAddExpenditureRefundsSchedLDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();

                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.ElectionDate = objFilingTransactionsModel.ElectionDate;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.FilingTypeId = objFilingTransactionsModel.FilingTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.ElectionYear = objFilingTransactionsModel.ElectionYear;
                    objFilingTransactionsContract.TransNumberOrg = objFilingTransactionsModel.TransNumberOrg;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;
                    objFilingTransactionsContract.ResigTermTypeId = objFilingTransactionsModel.ResigTermTypeId;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.MunicipalityID = objFilingTransactionsModel.MunicipalityID;

                    string result = client.AddExpenditureRefundsSchedL(objFilingTransactionsContract);
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
        /// mapGetOutstaningAmtExpRefundedDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal String mapGetOutstaningAmtExpRefundedDALResponse(String strTransNumber, String strFilerId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    var results = client.GetOutstaningAmtExpRefunded(strTransNumber, strFilerId);
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
        /// mapUpdateExpenditureRefundedSchedLDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateExpenditureRefundedSchedLDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();

                    objFilingTransactionsContract.TransNumber = objFilingTransactionsModel.TransNumber;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.ModifiedBy = objFilingTransactionsModel.ModifiedBy;
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;

                    Boolean returnValue = client.UpdateExpenditureRefundedSchedL(objFilingTransactionsContract);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapGetOriginalAmtRefundedSchedLDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<ExpPaymentOriginalAmountModel> mapGetOriginalAmtRefundedSchedLDALResponse(String strTransNumber, String strFilerId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ExpPaymentOriginalAmountModel> lstExpPaymentOriginalAmountModel = new List<ExpPaymentOriginalAmountModel>();
                    ExpPaymentOriginalAmountModel objExpPaymentOriginalAmountModel;

            var results = client.GetOriginalAmtRefundedSchedL(strTransNumber, strFilerId);

                    foreach (var item in results)
                    {
                        objExpPaymentOriginalAmountModel = new ExpPaymentOriginalAmountModel();
                        objExpPaymentOriginalAmountModel.TransNumber = item.TransNumber;
                        objExpPaymentOriginalAmountModel.OriginalAmount = item.OriginalAmount;
                        lstExpPaymentOriginalAmountModel.Add(objExpPaymentOriginalAmountModel);
                    }
                    client.Close();
                    return lstExpPaymentOriginalAmountModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapGetContributorOriginalNameDALResponse
        /// </summary>
        /// <returns></returns>
        internal IList<ExpPaymentOriginalNameModel> mapGetContributorOriginalNameDALResponse(String strFilerId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ExpPaymentOriginalNameModel> lstExpPaymentOriginalNameModel = new List<ExpPaymentOriginalNameModel>();
                    ExpPaymentOriginalNameModel objExpPaymentOriginalNameModel;

                    var results = client.GetContributorOriginalName(strFilerId);

                    foreach (var item in results)
                    {
                        objExpPaymentOriginalNameModel = new ExpPaymentOriginalNameModel();
                        objExpPaymentOriginalNameModel.FilingEntityId = item.FilingEntityId;
                        objExpPaymentOriginalNameModel.FilingEntityName = item.FilingEntityName;
                        lstExpPaymentOriginalNameModel.Add(objExpPaymentOriginalNameModel);
                    }
                    client.Close();
                    return lstExpPaymentOriginalNameModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapGetContributorOriginalAmountDALResponse
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        internal IList<ExpPaymentOriginalAmountModel> mapGetContributorOriginalAmountDALResponse(String strFilingEntityId, String strFilerId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ExpPaymentOriginalAmountModel> lstExpPaymentOriginalAmountModel = new List<ExpPaymentOriginalAmountModel>();
                    ExpPaymentOriginalAmountModel objExpPaymentOriginalAmountModel;

            var results = client.GetContributorOriginalAmount(strFilingEntityId, strFilerId);

                    foreach (var item in results)
                    {
                        objExpPaymentOriginalAmountModel = new ExpPaymentOriginalAmountModel();
                        objExpPaymentOriginalAmountModel.TransNumber = item.TransNumber;
                        objExpPaymentOriginalAmountModel.OriginalAmount = item.OriginalAmount;
                        lstExpPaymentOriginalAmountModel.Add(objExpPaymentOriginalAmountModel);
                    }
                    client.Close();
                    return lstExpPaymentOriginalAmountModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapGetContributorOriginalContributionDateDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<ExpPaymentOriginalExpenseDateModel> mapGetContributorOriginalContributionDateDALResponse(String strFilingEntityId, String strOriginalAmt, String strFilerId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ExpPaymentOriginalExpenseDateModel> lstExpPaymentOriginalExpenseDateModel = new List<ExpPaymentOriginalExpenseDateModel>();
                    ExpPaymentOriginalExpenseDateModel objExpPaymentOriginalExpenseDateModel;

            var results = client.GetContributorOriginalContributionDate(strFilingEntityId, strOriginalAmt, strFilerId);

                    foreach (var item in results)
                    {
                        objExpPaymentOriginalExpenseDateModel = new ExpPaymentOriginalExpenseDateModel();
                        objExpPaymentOriginalExpenseDateModel.TransNumber = item.TransNumber;
                        objExpPaymentOriginalExpenseDateModel.OriginalExpenseDate = item.OriginalExpenseDate.Trim().ToString();
                        lstExpPaymentOriginalExpenseDateModel.Add(objExpPaymentOriginalExpenseDateModel);
                    }
                    client.Close();
                    return lstExpPaymentOriginalExpenseDateModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapGetOutstaningAmtContrRefundedDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal String mapGetOutstaningAmtContrRefundedDALResponse(String strTransNumber, String strFilerId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    var results = client.GetOutstaningAmtContrRefunded(strTransNumber, strFilerId);
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
        /// mapGetOriginalAmtRefundedSchedMDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<ExpPaymentOriginalAmountModel> mapGetOriginalAmtRefundedSchedMDALResponse(String strTransNumber, String filerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ExpPaymentOriginalAmountModel> lstExpPaymentOriginalAmountModel = new List<ExpPaymentOriginalAmountModel>();
                    ExpPaymentOriginalAmountModel objExpPaymentOriginalAmountModel;

                    var results = client.GetOriginalAmtRefundedSchedM(strTransNumber, filerID);

                    foreach (var item in results)
                    {
                        objExpPaymentOriginalAmountModel = new ExpPaymentOriginalAmountModel();
                        objExpPaymentOriginalAmountModel.TransNumber = item.TransNumber;
                        objExpPaymentOriginalAmountModel.OriginalAmount = item.OriginalAmount;
                        lstExpPaymentOriginalAmountModel.Add(objExpPaymentOriginalAmountModel);
                    }
                    client.Close();
                    return lstExpPaymentOriginalAmountModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapAddContributionsRefundedSchedMDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal string mapAddContributionsRefundedSchedMDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();

                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.ElectionDate = objFilingTransactionsModel.ElectionDate;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.FilingTypeId = objFilingTransactionsModel.FilingTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.ElectionYear = objFilingTransactionsModel.ElectionYear;
                    objFilingTransactionsContract.TransNumberOrg = objFilingTransactionsModel.TransNumberOrg;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;
                    objFilingTransactionsContract.ResigTermTypeId = objFilingTransactionsModel.ResigTermTypeId;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.MunicipalityID = objFilingTransactionsModel.MunicipalityID;

                    string result = client.AddContributionsRefundedSchedM(objFilingTransactionsContract);
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
        /// mapUpdateContributionsRefundedSchedMDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateContributionsRefundedSchedMDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();

                    objFilingTransactionsContract.TransNumber = objFilingTransactionsModel.TransNumber;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.ModifiedBy = objFilingTransactionsModel.ModifiedBy;
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;

                    Boolean returnValue = client.UpdateContributionsRefundedSchedM(objFilingTransactionsContract);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapAddOutstandingLiabilitySchedNDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal string mapAddOutstandingLiabilitySchedNDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();

                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.ElectionDate = objFilingTransactionsModel.ElectionDate;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.FilingTypeId = objFilingTransactionsModel.FilingTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.ElectionYear = objFilingTransactionsModel.ElectionYear;
                    objFilingTransactionsContract.FilingTransId = objFilingTransactionsModel.FilingTransId;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.PurposeCodeId = objFilingTransactionsModel.PurposeCodeId;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.OwedAmt = objFilingTransactionsModel.OwedAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;
                    objFilingTransactionsContract.ResigTermTypeId = objFilingTransactionsModel.ResigTermTypeId;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;
                    objFilingTransactionsContract.MunicipalityID = objFilingTransactionsModel.MunicipalityID;
                    objFilingTransactionsContract.RIESupported = objFilingTransactionsModel.RIESupported;

                    string result = client.AddOutstandingLiabilitySchedN(objFilingTransactionsContract);
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
        /// mapUpdateOutstandingLiabilitySchedNDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateOutstandingLiabilitySchedNDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();

                    objFilingTransactionsContract.TransNumber = objFilingTransactionsModel.TransNumber;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.PurposeCodeId = objFilingTransactionsModel.PurposeCodeId;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.OwedAmt = objFilingTransactionsModel.OwedAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.ModifiedBy = objFilingTransactionsModel.ModifiedBy;
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.RIESupported = objFilingTransactionsModel.RIESupported;

                    Boolean returnValue = client.UpdateOutstandingLiabilitySchedN(objFilingTransactionsContract);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapOutstandingLiabilityChildExistsDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal String mapOutstandingLiabilityChildExistsDALResponse(String strTransNumber, String filerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    String strExists = String.Empty;

                    strExists = client.OutstandingLiabilityChildExists(strTransNumber, filerID);
                    client.Close();
                    return strExists;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapDeleteOutstandingLiabilitySchedNDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        internal Boolean mapDeleteOutstandingLiabilitySchedNDALResponse(String strTransNumber, String strFilingsId, String strModifiedBy)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    Boolean returnValue = client.DeleteOutstandingLiabilitySchedN(strTransNumber, strFilingsId, strModifiedBy);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// mapGetEditTransactionDataDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetEditTransactionDataDALResponse(String strTransNumber, String strFilerId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                    FilingTransactionDataModel objFilingTransactionDataModel;

                    var results = client.GetEditTransactionData(strTransNumber, strFilerId);

                    foreach (var item in results)
                    {
                        objFilingTransactionDataModel = new FilingTransactionDataModel();
                        objFilingTransactionDataModel.TransNumber = item.TransNumber;
                        objFilingTransactionDataModel.LoanLiablityNumber = item.LoanLiablityNumber;
                        objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                        objFilingTransactionDataModel.ContributorTypeId = item.ContributorTypeId;
                        objFilingTransactionDataModel.ContributorTypeDesc = item.ContributorTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.PaymentTypeId = item.PaymentTypeId;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.SchedDate = item.SchedDate;
                        objFilingTransactionDataModel.FilingSchedDesc = item.FilingSchedDesc;
                        objFilingTransactionDataModel.FilingEntityId = item.FilingEntityId;
                        objFilingTransactionDataModel.FilingEntityName = item.FilingEntityName;
                        objFilingTransactionDataModel.FilingFirstName = item.FilingFirstName;
                        objFilingTransactionDataModel.FilingMiddleName = item.FilingMiddleName;
                        objFilingTransactionDataModel.FilingLastName = item.FilingLastName;
                        objFilingTransactionDataModel.FilingStreetNumber = item.FilingStreetNumber;
                        objFilingTransactionDataModel.FilingStreetName = item.FilingStreetName;
                        objFilingTransactionDataModel.FilingCity = item.FilingCity;
                        objFilingTransactionDataModel.FilingState = item.FilingState;
                        objFilingTransactionDataModel.FilingZip = item.FilingZip;
                        objFilingTransactionDataModel.FilingCountry = item.FilingCountry;
                        objFilingTransactionDataModel.PaymentTypeDesc = item.PaymentTypeDesc;
                        objFilingTransactionDataModel.PayNumber = item.PayNumber;
                        objFilingTransactionDataModel.OriginalAmount = item.OriginalAmount;
                        objFilingTransactionDataModel.ReceiptTypeDesc = item.ReceiptTypeDesc;
                        objFilingTransactionDataModel.TransferTypeDesc = item.TransferTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.OriginalDate = item.OriginalDate;
                        objFilingTransactionDataModel.LoanerCode = item.LoanerCode;
                        objFilingTransactionDataModel.ElectionYear = item.ElectionYear;
                        objFilingTransactionDataModel.Office = item.Office;
                        objFilingTransactionDataModel.District = item.District;
                        objFilingTransactionDataModel.RLiability = item.RLiability;
                        objFilingTransactionDataModel.RSubcontractor = item.RSubcontractor;
                        objFilingTransactionDataModel.TransExplanation = item.TransExplanation;
                        objFilingTransactionDataModel.OwedAmount = item.OwedAmount;
                        objFilingTransactionDataModel.RItemized = item.RItemized;
                        objFilingTransactionDataModel.LoanerCodeID = item.LoanerCodeID;
                        objFilingTransactionDataModel.LoanerCode = item.LoanerCode;
                        objFilingTransactionDataModel.Office = item.Office;
                        objFilingTransactionDataModel.District = item.District;
                        objFilingTransactionDataModel.CountyID = item.CountyID;
                        objFilingTransactionDataModel.CountyDesc = item.CountyDesc;
                        objFilingTransactionDataModel.MunicipalityID = item.MunicipalityID;
                        objFilingTransactionDataModel.MunicipalityDesc = item.MunicipalityDesc;
                        objFilingTransactionDataModel.Original_Sched_Date = item.Original_Sched_Date;
                        objFilingTransactionDataModel.RClaim = item.RClaim;
                        objFilingTransactionDataModel.InDistrict = item.InDistrict;
                        objFilingTransactionDataModel.RMinor = item.RMinor;
                        objFilingTransactionDataModel.RVendor = item.RVendor;
                        objFilingTransactionDataModel.RLobbyist = item.RLobbyist;
                        objFilingTransactionDataModel.TreasurerEmployer = item.TreasurerEmployer;
                        objFilingTransactionDataModel.TreasurerOccuptaion = item.TreasurerOccuptaion;
                        objFilingTransactionDataModel.TreaAddress = item.TreaAddress;
                        objFilingTransactionDataModel.TreaAddr1 = item.TreaAddr1;
                        objFilingTransactionDataModel.TreaCity = item.TreaCity;
                        objFilingTransactionDataModel.TreaState = item.TreaState;
                        objFilingTransactionDataModel.TreaZipCode = item.TreaZipCode;
                        objFilingTransactionDataModel.RContributions = item.RContributions;
                        objFilingTransactionDataModel.RIESupported = item.RIESupported;
                        lstFilingTransactionDataModel.Add(objFilingTransactionDataModel);
                    }
                    client.Close();
                    return lstFilingTransactionDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// GetOriginalAmountLiabDataDALResponse
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        internal IList<OriginalAmountModel> GetOutstandingAmountForForgivenDAL(String strFilingTransId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<OriginalAmountModel> lstOriginalAmountModel = new List<OriginalAmountModel>();
                    OriginalAmountModel objOriginalAmountModel;

                    var results = client.GetOutstandingAmountForForgiven(strFilingTransId);

                    foreach (var item in results)
                    {
                        objOriginalAmountModel = new OriginalAmountModel();
                        objOriginalAmountModel.OriginalAmountId = item.OriginalAmountId;
                        objOriginalAmountModel.OutstandingAmount = item.OutstandingAmount;
                        lstOriginalAmountModel.Add(objOriginalAmountModel);
                    }
                    client.Close();
                    return lstOriginalAmountModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// Get and Authenticate value from Temp CAPASFIDAS Database
        /// </summary>
        /// <param name="filerID"></param>
        /// <param name="roleID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        internal IList<ValidateFilerInfoModel> GetAuthenticateFilerInfoDAL(String userID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ValidateFilerInfoModel> lstValidateFilerInfo = new List<ValidateFilerInfoModel>();
                    ValidateFilerInfoModel objValidateFilerInfo;

                    var results = client.GetAuthenticateFilerInfo(userID);

                    foreach (var item in results)
                    {
                        objValidateFilerInfo = new ValidateFilerInfoModel();
                        objValidateFilerInfo.FilerID = item.FilerID;
                        objValidateFilerInfo.RoleID = item.RoleID;
                        objValidateFilerInfo.Name = item.Name;
                        lstValidateFilerInfo.Add(objValidateFilerInfo);
                    }
                    client.Close();
                    return lstValidateFilerInfo;
                }

                catch (Exception ex)
                {
                    client.Abort();
                    throw;
                }
            }
        }

        /// <summary>
        /// Add Amount Allocation Scheduled R
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        internal string AddAmountAllocationSchedNDAL(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();

                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.FlngEntFirstName = objFilingTransactionsModel.FlngEntFirstName;
                    objFilingTransactionsContract.FlngEntMiddleName = objFilingTransactionsModel.FlngEntMiddleName;
                    objFilingTransactionsContract.FlngEntLastName = objFilingTransactionsModel.FlngEntLastName;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.FilingTypeId = objFilingTransactionsModel.FilingTypeId;
                    objFilingTransactionsContract.ElectionDate = objFilingTransactionsModel.ElectionDate;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.ElectionYear = objFilingTransactionsModel.ElectionYear;
                    objFilingTransactionsContract.MunicipalityID = objFilingTransactionsModel.MunicipalityID;
                    objFilingTransactionsContract.OfficeID = objFilingTransactionsModel.OfficeID;
                    objFilingTransactionsContract.DistrictID = objFilingTransactionsModel.DistrictID;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;
                    objFilingTransactionsContract.ResigTermTypeId = objFilingTransactionsModel.ResigTermTypeId;
                    objFilingTransactionsContract.SupportOppose = objFilingTransactionsModel.SupportOppose;
                    objFilingTransactionsContract.TransNumber = objFilingTransactionsModel.TransNumber;

                    string result = client.AddAmountAllocationSchedN(objFilingTransactionsContract);
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
        /// Update Amount Allocation Sched R
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        internal Boolean UpdateAmountAllocationSchedNDAL(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();

                    objFilingTransactionsContract.TransNumber = objFilingTransactionsModel.TransNumber;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.ModifiedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.SupportOppose = objFilingTransactionsModel.SupportOppose;
                    var returnValue = client.UpdateAmountAllocationSchedN(objFilingTransactionsContract);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
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
        internal String GetAllAmountDAL(String filing_Ent_ID, String elect_Year, String municipalityID, String officeID, String distID, String filerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    String results = client.GetAllAmount(filing_Ent_ID, elect_Year, municipalityID, officeID, distID, filerID);
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

        internal IList<DistrictModel> GetDistrictsForOfficeDAL(String strOfficeID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<DistrictModel> listGetDistrictsEntity = new List<DistrictModel>();
                    DistrictModel objGetDistrictsEntity;
                    //data from stored procedure
                    var results = client.GetDistrictsForOffice(strOfficeID);

                    foreach (var item in results)
                    {
                        //create GetDistrictsEntity object
                        objGetDistrictsEntity = new DistrictModel();
                        //modify object's attributes
                        objGetDistrictsEntity.District_ID = item.District_ID;
                        objGetDistrictsEntity.Parent_District_ID = item.Parent_District_ID;
                        //add object to list
                        listGetDistrictsEntity.Add(objGetDistrictsEntity);
                    }
                    client.Close();
                    return listGetDistrictsEntity;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        internal IList<OfficeModel> GetOfficesDAL(String strMunicipalityID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<OfficeModel> listGetOfficeEntity = new List<OfficeModel>();
                    OfficeModel objGetOfficeEntity;
                    //data from stored procedure
                    var results = client.GetOffices(strMunicipalityID);

                    foreach (var item in results)
                    {
                        //create GetDistrictsEntity object
                        objGetOfficeEntity = new OfficeModel();
                        //modify object's attributes
                        objGetOfficeEntity.OfficeId = item.OfficeId;
                        objGetOfficeEntity.OfficeDesc = item.OfficeDesc;
                        //add object to list
                        listGetOfficeEntity.Add(objGetOfficeEntity);
                    }
                    client.Close();
                    return listGetOfficeEntity;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// Auto Complete of Sched R
        /// </summary>
        /// <param name="name"></param>
        /// <param name="strFilerId"></param>
        /// <returns></returns>
        internal IList<AutoCompleteSchedRModel> GetAutoCompleteSchedRDAL(String name, String strFilerId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<AutoCompleteSchedRModel> lstAutoCompleteSchedREntity = new List<AutoCompleteSchedRModel>();
                    AutoCompleteSchedRModel objAutoCompleteSchedREntity;

                    var results = client.GetAutoCompleteSchedR(name, strFilerId);

                    foreach (var item in results)
                    {
                        objAutoCompleteSchedREntity = new AutoCompleteSchedRModel();
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
                    client.Close();
                    return lstAutoCompleteSchedREntity;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }

            }
            
            
        }

        #region mapGetOriginalLiabilityDataDALResponse GET ORIGINAL SCHEDULE 'N' TRANSACTIONS.
        /// <summary>
        /// mapGetOriginalLiabilityDataDALResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        internal IList<LiabilityDetailsModel> mapGetOriginalLiabilityDataDALResponse(String strTransNumber, String filerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<LiabilityDetailsModel> lstLiabilityDetailsModel = new List<LiabilityDetailsModel>();
                    LiabilityDetailsModel objLiabilityDetailsModel;

                    var results = client.GetOriginalLiabilityData(strTransNumber, filerID);

                    foreach (var item in results)
                    {
                        objLiabilityDetailsModel = new LiabilityDetailsModel();
                        objLiabilityDetailsModel.FilingTransId = item.FilingTransId;
                        objLiabilityDetailsModel.TransNumber = item.TransNumber;
                        objLiabilityDetailsModel.ContributionType = item.ContributionType;
                        objLiabilityDetailsModel.TransactionDate = item.TransactionDate;
                        objLiabilityDetailsModel.TransactionType = item.TransactionType;
                        objLiabilityDetailsModel.FilingEntityName = item.FilingEntityName;
                        objLiabilityDetailsModel.FilingFirstName = item.FilingFirstName;
                        objLiabilityDetailsModel.FilingMiddleName = item.FilingMiddleName;
                        objLiabilityDetailsModel.FilingLastName = item.FilingLastName;
                        objLiabilityDetailsModel.FilingStreetName = item.FilingStreetName;
                        objLiabilityDetailsModel.FilingCity = item.FilingCity;
                        objLiabilityDetailsModel.FilingState = item.FilingState;
                        objLiabilityDetailsModel.FilingZip = item.FilingZip;
                        objLiabilityDetailsModel.FilingCountry = item.FilingCountry;
                        objLiabilityDetailsModel.PaymentType = item.PaymentType;
                        objLiabilityDetailsModel.PayNumber = item.PayNumber;
                        objLiabilityDetailsModel.Amount = item.Amount;
                        objLiabilityDetailsModel.OutstandingAmount = item.OutstandingAmount;
                        objLiabilityDetailsModel.RecieptType = item.RecieptType;
                        objLiabilityDetailsModel.TransferType = item.TransferType;
                        objLiabilityDetailsModel.ContributionType = item.ContributionType;
                        objLiabilityDetailsModel.PurposeCode = item.PurposeCode;
                        objLiabilityDetailsModel.RecieptCdoe = item.RecieptCdoe;
                        objLiabilityDetailsModel.OriginalDate = item.OriginalDate;
                        objLiabilityDetailsModel.LoanerCode = item.LoanerCode;
                        objLiabilityDetailsModel.ElectionYear = item.ElectionYear;
                        objLiabilityDetailsModel.Office = item.Office;
                        objLiabilityDetailsModel.District = item.District;
                        objLiabilityDetailsModel.TransExplanation = item.TransExplanation;
                        objLiabilityDetailsModel.RItemized = item.RItemized;
                        objLiabilityDetailsModel.CountId = item.CountId;
                        objLiabilityDetailsModel.MunicipalityId = item.MunicipalityId;
                        objLiabilityDetailsModel.County = item.County;
                        objLiabilityDetailsModel.Municipality = item.Municipality;
                        objLiabilityDetailsModel.CreatedDate = item.CreatedDate;
                        lstLiabilityDetailsModel.Add(objLiabilityDetailsModel);
                    }
                    client.Close();
                    return lstLiabilityDetailsModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetOriginalLiabilityDataDALResponse GET ORIGINAL SCHEDULE 'N' TRANSACTIONS.

        #region mapGetExpenditurePaymentLiabilityDataDALResponse GET EXPENDITURE PAYMENT SCHEDULE 'F' TRANSACTIONS.
        /// <summary>
        /// mapGetExpenditurePaymentLiabilityDataDALResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        internal IList<LiabilityDetailsModel> mapGetExpenditurePaymentLiabilityDataDALResponse(String strTransNumber, String filerID, String strSchedID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<LiabilityDetailsModel> lstLiabilityDetailsModel = new List<LiabilityDetailsModel>();
                    LiabilityDetailsModel objLiabilityDetailsModel;

                    var results = client.GetExpenditurePaymentLiabilityData(strTransNumber, filerID, strSchedID);

                    foreach (var item in results)
                    {
                        objLiabilityDetailsModel = new LiabilityDetailsModel();
                        objLiabilityDetailsModel.FilingTransId = item.FilingTransId;
                        objLiabilityDetailsModel.TransNumber = item.TransNumber;
                        objLiabilityDetailsModel.ContributionType = item.ContributionType;
                        objLiabilityDetailsModel.TransactionDate = item.TransactionDate;
                        objLiabilityDetailsModel.TransactionType = item.TransactionType;
                        objLiabilityDetailsModel.FilingEntityName = item.FilingEntityName;
                        objLiabilityDetailsModel.FilingFirstName = item.FilingFirstName;
                        objLiabilityDetailsModel.FilingMiddleName = item.FilingMiddleName;
                        objLiabilityDetailsModel.FilingLastName = item.FilingLastName;
                        objLiabilityDetailsModel.FilingStreetName = item.FilingStreetName;
                        objLiabilityDetailsModel.FilingCity = item.FilingCity;
                        objLiabilityDetailsModel.FilingState = item.FilingState;
                        objLiabilityDetailsModel.FilingZip = item.FilingZip;
                        objLiabilityDetailsModel.FilingCountry = item.FilingCountry;
                        objLiabilityDetailsModel.PaymentType = item.PaymentType;
                        objLiabilityDetailsModel.PayNumber = item.PayNumber;
                        objLiabilityDetailsModel.Amount = item.Amount;
                        objLiabilityDetailsModel.OutstandingAmount = item.OutstandingAmount;
                        objLiabilityDetailsModel.RecieptType = item.RecieptType;
                        objLiabilityDetailsModel.TransferType = item.TransferType;
                        objLiabilityDetailsModel.ContributionType = item.ContributionType;
                        objLiabilityDetailsModel.PurposeCode = item.PurposeCode;
                        objLiabilityDetailsModel.RecieptCdoe = item.RecieptCdoe;
                        objLiabilityDetailsModel.OriginalDate = item.OriginalDate;
                        objLiabilityDetailsModel.LoanerCode = item.LoanerCode;
                        objLiabilityDetailsModel.ElectionYear = item.ElectionYear;
                        objLiabilityDetailsModel.Office = item.Office;
                        objLiabilityDetailsModel.District = item.District;
                        objLiabilityDetailsModel.TransExplanation = item.TransExplanation;
                        objLiabilityDetailsModel.RItemized = item.RItemized;
                        objLiabilityDetailsModel.CountId = item.CountId;
                        objLiabilityDetailsModel.MunicipalityId = item.MunicipalityId;
                        objLiabilityDetailsModel.County = item.County;
                        objLiabilityDetailsModel.Municipality = item.Municipality;
                        objLiabilityDetailsModel.CreatedDate = item.CreatedDate;
                        lstLiabilityDetailsModel.Add(objLiabilityDetailsModel);
                    }
                    client.Close();
                    return lstLiabilityDetailsModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetExpenditurePaymentLiabilityDataDALResponse GET EXPENDITURE PAYMENT SCHEDULE 'F' TRANSACTIONS.

        #region mapGetOutstandingLiabilityDataDALResponse GET OUTSTANDING LIABILITY SCHEDULE 'N' TRANSACTIONS.
        /// <summary>
        /// mapGetOutstandingLiabilityDataDALResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        internal IList<LiabilityDetailsModel> mapGetOutstandingLiabilityDataDALResponse(String strTransNumber, String filerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<LiabilityDetailsModel> lstLiabilityDetailsModel = new List<LiabilityDetailsModel>();
                    LiabilityDetailsModel objLiabilityDetailsModel;

                    var results = client.GetOutstandingLiabilityData(strTransNumber, filerID);

                    foreach (var item in results)
                    {
                        objLiabilityDetailsModel = new LiabilityDetailsModel();
                        objLiabilityDetailsModel.FilingTransId = item.FilingTransId;
                        objLiabilityDetailsModel.TransNumber = item.TransNumber;
                        objLiabilityDetailsModel.ContributionType = item.ContributionType;
                        objLiabilityDetailsModel.TransactionDate = item.TransactionDate;
                        objLiabilityDetailsModel.TransactionType = item.TransactionType;
                        objLiabilityDetailsModel.FilingEntityName = item.FilingEntityName;
                        objLiabilityDetailsModel.FilingFirstName = item.FilingFirstName;
                        objLiabilityDetailsModel.FilingMiddleName = item.FilingMiddleName;
                        objLiabilityDetailsModel.FilingLastName = item.FilingLastName;
                        objLiabilityDetailsModel.FilingStreetName = item.FilingStreetName;
                        objLiabilityDetailsModel.FilingCity = item.FilingCity;
                        objLiabilityDetailsModel.FilingState = item.FilingState;
                        objLiabilityDetailsModel.FilingZip = item.FilingZip;
                        objLiabilityDetailsModel.FilingCountry = item.FilingCountry;
                        objLiabilityDetailsModel.PaymentType = item.PaymentType;
                        objLiabilityDetailsModel.PayNumber = item.PayNumber;
                        objLiabilityDetailsModel.Amount = item.Amount;
                        objLiabilityDetailsModel.OutstandingAmount = item.OutstandingAmount;
                        objLiabilityDetailsModel.RecieptType = item.RecieptType;
                        objLiabilityDetailsModel.TransferType = item.TransferType;
                        objLiabilityDetailsModel.ContributionType = item.ContributionType;
                        objLiabilityDetailsModel.PurposeCode = item.PurposeCode;
                        objLiabilityDetailsModel.RecieptCdoe = item.RecieptCdoe;
                        objLiabilityDetailsModel.OriginalDate = item.OriginalDate;
                        objLiabilityDetailsModel.LoanerCode = item.LoanerCode;
                        objLiabilityDetailsModel.ElectionYear = item.ElectionYear;
                        objLiabilityDetailsModel.Office = item.Office;
                        objLiabilityDetailsModel.District = item.District;
                        objLiabilityDetailsModel.TransExplanation = item.TransExplanation;
                        objLiabilityDetailsModel.RItemized = item.RItemized;
                        objLiabilityDetailsModel.CountId = item.CountId;
                        objLiabilityDetailsModel.MunicipalityId = item.MunicipalityId;
                        objLiabilityDetailsModel.County = item.County;
                        objLiabilityDetailsModel.Municipality = item.Municipality;
                        objLiabilityDetailsModel.CreatedDate = item.CreatedDate;
                        lstLiabilityDetailsModel.Add(objLiabilityDetailsModel);
                    }
                    client.Close();
                    return lstLiabilityDetailsModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetOutstandingLiabilityDataDALResponse GET OUTSTANDING LIABILITY SCHEDULE 'N' TRANSACTIONS.

        #region mapGetLiabilityForgivenDataDALResponse GET LIABILITY FORGIVEN SCHEDULE 'K' TRANSACTIONS.
        /// <summary>
        /// mapGetLiabilityForgivenDataDALResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        internal IList<LiabilityDetailsModel> mapGetLiabilityForgivenDataDALResponse(String strTransNumber, String filerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<LiabilityDetailsModel> lstLiabilityDetailsModel = new List<LiabilityDetailsModel>();
                    LiabilityDetailsModel objLiabilityDetailsModel;

                    var results = client.GetLiabilityForgivenData(strTransNumber, filerID);

                    foreach (var item in results)
                    {
                        objLiabilityDetailsModel = new LiabilityDetailsModel();
                        objLiabilityDetailsModel.FilingTransId = item.FilingTransId;
                        objLiabilityDetailsModel.TransNumber = item.TransNumber;
                        objLiabilityDetailsModel.ContributionType = item.ContributionType;
                        objLiabilityDetailsModel.TransactionDate = item.TransactionDate;
                        objLiabilityDetailsModel.TransactionType = item.TransactionType;
                        objLiabilityDetailsModel.FilingEntityName = item.FilingEntityName;
                        objLiabilityDetailsModel.FilingFirstName = item.FilingFirstName;
                        objLiabilityDetailsModel.FilingMiddleName = item.FilingMiddleName;
                        objLiabilityDetailsModel.FilingLastName = item.FilingLastName;
                        objLiabilityDetailsModel.FilingStreetName = item.FilingStreetName;
                        objLiabilityDetailsModel.FilingCity = item.FilingCity;
                        objLiabilityDetailsModel.FilingState = item.FilingState;
                        objLiabilityDetailsModel.FilingZip = item.FilingZip;
                        objLiabilityDetailsModel.FilingCountry = item.FilingCountry;
                        objLiabilityDetailsModel.PaymentType = item.PaymentType;
                        objLiabilityDetailsModel.PayNumber = item.PayNumber;
                        objLiabilityDetailsModel.Amount = item.Amount;
                        objLiabilityDetailsModel.OutstandingAmount = item.OutstandingAmount;
                        objLiabilityDetailsModel.RecieptType = item.RecieptType;
                        objLiabilityDetailsModel.TransferType = item.TransferType;
                        objLiabilityDetailsModel.ContributionType = item.ContributionType;
                        objLiabilityDetailsModel.PurposeCode = item.PurposeCode;
                        objLiabilityDetailsModel.RecieptCdoe = item.RecieptCdoe;
                        objLiabilityDetailsModel.OriginalDate = item.OriginalDate;
                        objLiabilityDetailsModel.LoanerCode = item.LoanerCode;
                        objLiabilityDetailsModel.ElectionYear = item.ElectionYear;
                        objLiabilityDetailsModel.Office = item.Office;
                        objLiabilityDetailsModel.District = item.District;
                        objLiabilityDetailsModel.TransExplanation = item.TransExplanation;
                        objLiabilityDetailsModel.RItemized = item.RItemized;
                        objLiabilityDetailsModel.CountId = item.CountId;
                        objLiabilityDetailsModel.MunicipalityId = item.MunicipalityId;
                        objLiabilityDetailsModel.County = item.County;
                        objLiabilityDetailsModel.Municipality = item.Municipality;
                        objLiabilityDetailsModel.CreatedDate = item.CreatedDate;
                        lstLiabilityDetailsModel.Add(objLiabilityDetailsModel);
                    }
                    client.Close();
                    return lstLiabilityDetailsModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetLiabilityForgivenDataDALResponse GET LIABILITY FORGIVEN SCHEDULE 'K' TRANSACTIONS.

        //=========================================================================================================================================
        // NON-ITEMIZED TRANSACTIONS - >>> START START START >>>>>>>>>>>>>>>>>>>>>>>>>
        //=========================================================================================================================================

        #region mapGetInLieuOfStatementDataDALResponse
        /// <summary>
        /// mapGetInLieuOfStatementDataDALResponse
        /// </summary>
        /// <param name="strElectionYearId"></param>
        /// <param name="strElectTypeId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <returns></returns>
        internal IList<InLieuOfStatementNonItemModel> mapGetInLieuOfStatementDataDALResponse(String strFilerid, String strElectionDate,
            String strElectionYearId, String strElectionYear, String strElectTypeId,
            String strOfficeTypeId, String strFilingTypeId, String strFilingDate)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<InLieuOfStatementNonItemModel> lstInLieuOfStatementNonItemModel = new List<InLieuOfStatementNonItemModel>();
                    InLieuOfStatementNonItemModel objInLieuOfStatementNonItemModel;

                    var results = client.GetInLieuOfStatementData(strFilerid, strElectionDate,
                        strElectionYearId, strElectionYear, strElectTypeId, strOfficeTypeId, strFilingTypeId, strFilingDate);

                    foreach (var item in results)
                    {
                        objInLieuOfStatementNonItemModel = new InLieuOfStatementNonItemModel();
                        objInLieuOfStatementNonItemModel.FilingsId = item.FilingsId;
                        objInLieuOfStatementNonItemModel.ElectionYear = item.ElectionYear;
                        objInLieuOfStatementNonItemModel.OfficeType = item.OfficeType;
                        objInLieuOfStatementNonItemModel.ElectionType = item.ElectionType;
                        objInLieuOfStatementNonItemModel.ElectionDate = item.ElectionDate;
                        objInLieuOfStatementNonItemModel.DisclosurePeriod = item.DisclosurePeriod;
                        objInLieuOfStatementNonItemModel.DateSubmitted = item.DateSubmitted;
                        lstInLieuOfStatementNonItemModel.Add(objInLieuOfStatementNonItemModel);
                    }
                    client.Close();
                    return lstInLieuOfStatementNonItemModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            

        }
        #endregion mapGetInLieuOfStatementDataDALResponse

        #region mapAddInLieuOfStatementDALResponse
        /// <summary>
        /// mapAddInLieuOfStatementDALResponse
        /// </summary>
        /// <param name="objAddInLieuOfStatementModel"></param>
        /// <returns></returns>
        internal Boolean mapAddInLieuOfStatementDALResponse(AddInLieuOfStatementModel objAddInLieuOfStatementModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    AddInLieuOfStatementContract objAAddInLieuOfStatementContract;
                    objAAddInLieuOfStatementContract = new AddInLieuOfStatementContract();
                    objAAddInLieuOfStatementContract.FilerId = objAddInLieuOfStatementModel.FilerId;
                    objAAddInLieuOfStatementContract.ElectionDate = objAddInLieuOfStatementModel.ElectionDate;
                    objAAddInLieuOfStatementContract.ElectionTypeId = objAddInLieuOfStatementModel.ElectionTypeId;
                    objAAddInLieuOfStatementContract.OfficeTypeId = objAddInLieuOfStatementModel.OfficeTypeId;
                    objAAddInLieuOfStatementContract.FilingTypeId = objAddInLieuOfStatementModel.FilingTypeId;
                    objAAddInLieuOfStatementContract.FilingCategoryId = objAddInLieuOfStatementModel.FilingCategoryId;
                    objAAddInLieuOfStatementContract.ElectYearId = objAddInLieuOfStatementModel.ElectYearId;
                    objAAddInLieuOfStatementContract.ElectionYear = objAddInLieuOfStatementModel.ElectionYear;
                    objAAddInLieuOfStatementContract.CountyId = objAddInLieuOfStatementModel.CountyId;
                    objAAddInLieuOfStatementContract.MunicipalityId = objAddInLieuOfStatementModel.MunicipalityId;
                    objAAddInLieuOfStatementContract.CreatedBy = objAddInLieuOfStatementModel.CreatedBy;
                    objAAddInLieuOfStatementContract.ElectionDateId = objAddInLieuOfStatementModel.ElectionDateId;
                    objAAddInLieuOfStatementContract.FilingDate = objAddInLieuOfStatementModel.FilingDate;

                    Boolean results = client.AddInLieuOfStatement(objAAddInLieuOfStatementContract);
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
        #endregion mapAddInLieuOfStatementDALResponse

        #region mapDeleteInLieuOfStatementDALResponse
        /// <summary>
        /// mapDeleteInLieuOfStatementDALResponse
        /// </summary>
        /// <param name="strFilingsId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        internal Boolean mapDeleteInLieuOfStatementDALResponse(String strFilingsId, String strModifiedBy)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    Boolean results = client.DeleteInLieuOfStatement(strFilingsId, strModifiedBy);
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
        #endregion mapDeleteInLieuOfStatementDALResponse

        #region mapGetPersonNameAndTreasurerDataDALResponse
        /// <summary>
        /// mapGetPersonNameAndTreasurerDataDALResponse
        /// </summary>
        /// <param name="strPersonId"></param>
        /// <returns></returns>
        internal IList<PersonNameAndTreasurerDataModel> mapGetPersonNameAndTreasurerDataDALResponse(String strPersonId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<PersonNameAndTreasurerDataModel> lstPersonNameAndTreasurerDataModel = new List<PersonNameAndTreasurerDataModel>();
                    PersonNameAndTreasurerDataModel objPersonNameAndTreasurerDataModel;

                    var results = client.GetPersonNameAndTreasurerData(strPersonId);

                    foreach (var item in results)
                    {
                        objPersonNameAndTreasurerDataModel = new PersonNameAndTreasurerDataModel();
                        objPersonNameAndTreasurerDataModel.PersonName = item.PersonName;
                        objPersonNameAndTreasurerDataModel.TreasId = item.TreasId;
                        lstPersonNameAndTreasurerDataModel.Add(objPersonNameAndTreasurerDataModel);
                    }
                    client.Close();
                    return lstPersonNameAndTreasurerDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetPersonNameAndTreasurerDataDALResponse

        #region mapGetNoActivityReporttDataDALResponse
        /// <summary>
        /// mapGetNoActivityReporttDataDALResponse
        /// </summary>
        /// <param name="strFilerid"></param>
        /// <param name="strElectionDate"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strElectionYear"></param>
        /// <param name="strElectTypeId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <returns></returns>
        internal IList<InLieuOfStatementNonItemModel> mapGetNoActivityReporttDataDALResponse(String strFilerid, String strElectionDate,
            String strElectionYearId, String strElectionYear, String strElectTypeId,
            String strOfficeTypeId, String strFilingTypeId, String strFilingDate)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<InLieuOfStatementNonItemModel> lstInLieuOfStatementNonItemModel = new List<InLieuOfStatementNonItemModel>();
                    InLieuOfStatementNonItemModel objInLieuOfStatementNonItemModel;

                    var results = client.GetNoActivityReporttData(strFilerid, strElectionDate,
                        strElectionYearId, strElectionYear, strElectTypeId, strOfficeTypeId, strFilingTypeId, strFilingDate);

                    foreach (var item in results)
                    {
                        objInLieuOfStatementNonItemModel = new InLieuOfStatementNonItemModel();
                        objInLieuOfStatementNonItemModel.FilingsId = item.FilingsId;
                        objInLieuOfStatementNonItemModel.ElectionYear = item.ElectionYear;
                        objInLieuOfStatementNonItemModel.OfficeType = item.OfficeType;
                        objInLieuOfStatementNonItemModel.ElectionType = item.ElectionType;
                        objInLieuOfStatementNonItemModel.ElectionDate = item.ElectionDate;
                        objInLieuOfStatementNonItemModel.DisclosurePeriod = item.DisclosurePeriod;
                        objInLieuOfStatementNonItemModel.DateSubmitted = item.DateSubmitted;
                        lstInLieuOfStatementNonItemModel.Add(objInLieuOfStatementNonItemModel);
                    }
                    client.Close();
                    return lstInLieuOfStatementNonItemModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetNoActivityReporttDataDALResponse

        #region mapAddNoActivityReportDALResponse
        /// <summary>
        /// mapAddNoActivityReportDALResponse
        /// </summary>
        /// <param name="objAddInLieuOfStatementModel"></param>
        /// <returns></returns>
        internal Boolean mapAddNoActivityReportDALResponse(AddInLieuOfStatementModel objAddInLieuOfStatementModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    AddInLieuOfStatementContract objAAddInLieuOfStatementContract;
                    objAAddInLieuOfStatementContract = new AddInLieuOfStatementContract();
                    objAAddInLieuOfStatementContract.FilerId = objAddInLieuOfStatementModel.FilerId;
                    objAAddInLieuOfStatementContract.ElectionDate = objAddInLieuOfStatementModel.ElectionDate;
                    objAAddInLieuOfStatementContract.ElectionTypeId = objAddInLieuOfStatementModel.ElectionTypeId;
                    objAAddInLieuOfStatementContract.OfficeTypeId = objAddInLieuOfStatementModel.OfficeTypeId;
                    objAAddInLieuOfStatementContract.FilingTypeId = objAddInLieuOfStatementModel.FilingTypeId;
                    objAAddInLieuOfStatementContract.FilingCategoryId = objAddInLieuOfStatementModel.FilingCategoryId;
                    objAAddInLieuOfStatementContract.ElectYearId = objAddInLieuOfStatementModel.ElectYearId;
                    objAAddInLieuOfStatementContract.ElectionYear = objAddInLieuOfStatementModel.ElectionYear;
                    objAAddInLieuOfStatementContract.CountyId = objAddInLieuOfStatementModel.CountyId;
                    objAAddInLieuOfStatementContract.MunicipalityId = objAddInLieuOfStatementModel.MunicipalityId;
                    objAAddInLieuOfStatementContract.ResigTermTypeId = objAddInLieuOfStatementModel.ResigTermTypeId;
                    objAAddInLieuOfStatementContract.CreatedBy = objAddInLieuOfStatementModel.CreatedBy;
                    objAAddInLieuOfStatementContract.ElectionDateId = objAddInLieuOfStatementModel.ElectionDateId;
                    objAAddInLieuOfStatementContract.FilingDate = objAddInLieuOfStatementModel.FilingDate;

                    Boolean results = client.AddNoActivityReport(objAAddInLieuOfStatementContract);
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
        #endregion mapAddNoActivityReportDALResponse

        #region mapGetItemizedTransSubmittedDALResponse
        /// <summary>
        /// mapGetItemizedTransSubmittedDALResponse
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <returns></returns>
        internal Boolean mapGetItemizedTransSubmittedDALResponse(String strFilerId, String strElectionYearId, String strOfficeTypeId,
            String strFilingTypeId, String strFilingCatId, String strElectTypeID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    Boolean strSubmitted;

                    strSubmitted = client.GetItemizedTransSubmitted(strFilerId, strElectionYearId,
                        strOfficeTypeId, strFilingTypeId, strFilingCatId, strElectTypeID);
                    client.Close();
                    return strSubmitted;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetItemizedTransSubmittedDALResponse

        #region mapAddNoticeOfNonParticipationDALResponse
        /// <summary>
        /// mapAddNoticeOfNonParticipationDALResponse
        /// </summary>
        /// <param name="objAddInLieuOfStatementModel"></param>
        /// <returns></returns>
        internal Boolean mapAddNoticeOfNonParticipationDALResponse(AddInLieuOfStatementModel objAddInLieuOfStatementModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    AddInLieuOfStatementContract objAAddInLieuOfStatementContract;
                    objAAddInLieuOfStatementContract = new AddInLieuOfStatementContract();
                    objAAddInLieuOfStatementContract.FilerId = objAddInLieuOfStatementModel.FilerId;
                    objAAddInLieuOfStatementContract.ElectionDate = objAddInLieuOfStatementModel.ElectionDate;
                    objAAddInLieuOfStatementContract.ElectionTypeId = objAddInLieuOfStatementModel.ElectionTypeId;
                    objAAddInLieuOfStatementContract.OfficeTypeId = objAddInLieuOfStatementModel.OfficeTypeId;
                    objAAddInLieuOfStatementContract.FilingTypeId = objAddInLieuOfStatementModel.FilingTypeId;
                    objAAddInLieuOfStatementContract.FilingCategoryId = objAddInLieuOfStatementModel.FilingCategoryId;
                    objAAddInLieuOfStatementContract.ElectYearId = objAddInLieuOfStatementModel.ElectYearId;
                    objAAddInLieuOfStatementContract.ElectionYear = objAddInLieuOfStatementModel.ElectionYear;
                    objAAddInLieuOfStatementContract.CountyId = objAddInLieuOfStatementModel.CountyId;
                    objAAddInLieuOfStatementContract.MunicipalityId = objAddInLieuOfStatementModel.MunicipalityId;
                    objAAddInLieuOfStatementContract.CreatedBy = objAddInLieuOfStatementModel.CreatedBy;
                    objAAddInLieuOfStatementContract.ElectionDateId = objAddInLieuOfStatementModel.ElectionDateId;
                    objAAddInLieuOfStatementContract.FilingDate = objAddInLieuOfStatementModel.FilingDate;

                    Boolean results = client.AddNoticeOfNonParticipation(objAAddInLieuOfStatementContract);
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
        #endregion mapAddNoticeOfNonParticipationDALResponse

        #region mapGetNoticeOfNonParticipationtDataDALResponse
        /// <summary>
        /// mapGetNoticeOfNonParticipationtDataDALResponse
        /// </summary>
        /// <param name="strFilerid"></param>
        /// <param name="strElectionDate"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strElectionYear"></param>
        /// <param name="strElectTypeId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <returns></returns>
        internal IList<InLieuOfStatementNonItemModel> mapGetNoticeOfNonParticipationtDataDALResponse(String strFilerid, String strElectionDate,
            String strElectionYearId, String strElectionYear, String strElectTypeId,
            String strOfficeTypeId, String strFilingTypeId, String strCountyId, String strMunicipalityId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<InLieuOfStatementNonItemModel> lstInLieuOfStatementNonItemModel = new List<InLieuOfStatementNonItemModel>();
                    InLieuOfStatementNonItemModel objInLieuOfStatementNonItemModel;

                    var results = client.GetNoticeOfNonParticipationtData(strFilerid, strElectionDate,
                        strElectionYearId, strElectionYear, strElectTypeId, strOfficeTypeId, strFilingTypeId, strCountyId, strMunicipalityId);

                    foreach (var item in results)
                    {
                        objInLieuOfStatementNonItemModel = new InLieuOfStatementNonItemModel();
                        objInLieuOfStatementNonItemModel.FilingsId = item.FilingsId;
                        objInLieuOfStatementNonItemModel.ElectionYear = item.ElectionYear;
                        objInLieuOfStatementNonItemModel.OfficeType = item.OfficeType;
                        objInLieuOfStatementNonItemModel.ElectionType = item.ElectionType;
                        objInLieuOfStatementNonItemModel.ElectionDate = item.ElectionDate;
                        objInLieuOfStatementNonItemModel.DisclosurePeriod = item.DisclosurePeriod;
                        objInLieuOfStatementNonItemModel.DateSubmitted = item.DateSubmitted;
                        lstInLieuOfStatementNonItemModel.Add(objInLieuOfStatementNonItemModel);
                    }
                    client.Close();
                    return lstInLieuOfStatementNonItemModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetNoticeOfNonParticipationtDataDALResponse

        #region mapGetTransactionTypes24HNoticeDataDALResponse
        /// <summary>
        /// mapGetTransactionTypes24HNoticeDataDALResponse
        /// </summary>
        /// <returns></returns>
        internal IList<TransactionTypesModel> mapGetTransactionTypes24HNoticeDataDALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<TransactionTypesModel> lstTransactionTypesModel = new List<TransactionTypesModel>();
                    TransactionTypesModel objTransactionTypesModel;

                    var results = client.GetTransactionTypes24HNoticeData();

                    foreach (var item in results)
                    {
                        objTransactionTypesModel = new TransactionTypesModel();
                        objTransactionTypesModel.FilingSchedId = item.FilingSchedId;
                        objTransactionTypesModel.FilingSchedDesc = item.FilingSchedDesc;
                        objTransactionTypesModel.FilingSchedAbbrev = item.FilingSchedAbbrev;
                        lstTransactionTypesModel.Add(objTransactionTypesModel);
                    }
                    client.Close();
                    return lstTransactionTypesModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetTransactionTypes24HNoticeDataDALResponse

        #region GetFilingTrans24HourNoticeData
        /// <summary>
        /// GetFilingTrans24HourNoticeData
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetFilingTrans24HourNoticeDataDALResponse(FilingTransDataModel objFilingTransDataModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                    FilingTransactionDataModel objFilingTransactionDataModel;

                    FilingTransDataContract objFilingTransDataContract = new FilingTransDataContract();
                    objFilingTransDataContract.FilerId = objFilingTransDataModel.FilerId;
                    objFilingTransDataContract.ReportYearId = objFilingTransDataModel.ReportYearId;
                    objFilingTransDataContract.OfficeTypeId = objFilingTransDataModel.OfficeTypeId;
                    objFilingTransDataContract.ElectionType = objFilingTransDataModel.ElectionType;
                    objFilingTransDataContract.ElectionDateId = objFilingTransDataModel.ElectionDateId;
                    objFilingTransDataContract.FilingDate = objFilingTransDataModel.FilingDate;

                    var results = client.GetFilingTrans24HourNoticeData(objFilingTransDataContract);

                    foreach (var item in results)
                    {
                        objFilingTransactionDataModel = new FilingTransactionDataModel();
                        objFilingTransactionDataModel.FilingTransId = item.FilingTransId;
                        objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                        objFilingTransactionDataModel.ContributorTypeId = item.ContributorTypeId;
                        objFilingTransactionDataModel.ContributorTypeDesc = item.ContributorTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.PaymentTypeId = item.PaymentTypeId;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.SubmissionDate = item.SubmissionDate;
                        objFilingTransactionDataModel.SchedDate = item.SchedDate;
                        objFilingTransactionDataModel.FilingSchedDesc = item.FilingSchedDesc;
                        objFilingTransactionDataModel.FilingEntityId = item.FilingEntityId;
                        objFilingTransactionDataModel.FilingEntityName = item.FilingEntityName;
                        objFilingTransactionDataModel.FilingFirstName = item.FilingFirstName;
                        objFilingTransactionDataModel.FilingMiddleName = item.FilingMiddleName;
                        objFilingTransactionDataModel.FilingLastName = item.FilingLastName;
                        objFilingTransactionDataModel.FilingStreetNumber = item.FilingStreetNumber;
                        objFilingTransactionDataModel.FilingStreetName = item.FilingStreetName;
                        objFilingTransactionDataModel.FilingCity = item.FilingCity;
                        objFilingTransactionDataModel.FilingState = item.FilingState;
                        objFilingTransactionDataModel.FilingZip = item.FilingZip;
                        objFilingTransactionDataModel.FilingCountry = item.FilingCountry;
                        objFilingTransactionDataModel.PaymentTypeDesc = item.PaymentTypeDesc;
                        objFilingTransactionDataModel.PayNumber = item.PayNumber;
                        objFilingTransactionDataModel.OriginalAmount = item.OriginalAmount;
                        objFilingTransactionDataModel.ReceiptTypeDesc = item.ReceiptTypeDesc;
                        objFilingTransactionDataModel.TransferTypeDesc = item.TransferTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.OriginalDate = item.OriginalDate;
                        objFilingTransactionDataModel.LoanerCode = item.LoanerCode;
                        objFilingTransactionDataModel.ElectionYear = item.ElectionYear;
                        objFilingTransactionDataModel.Office = item.Office;
                        objFilingTransactionDataModel.District = item.District;
                        objFilingTransactionDataModel.RLiability = item.RLiability;
                        objFilingTransactionDataModel.RSubcontractor = item.RSubcontractor;
                        objFilingTransactionDataModel.TransExplanation = item.TransExplanation;
                        objFilingTransactionDataModel.OwedAmount = item.OwedAmount;
                        objFilingTransactionDataModel.RItemized = item.RItemized;
                        objFilingTransactionDataModel.RAmend = item.RAmend;
                        objFilingTransactionDataModel.Status = item.RStatus;
                        objFilingTransactionDataModel.CountyID = item.CountyID;
                        objFilingTransactionDataModel.CountyDesc = item.CountyDesc;
                        objFilingTransactionDataModel.MunicipalityID = item.MunicipalityID;
                        objFilingTransactionDataModel.MunicipalityDesc = item.MunicipalityDesc;
                        objFilingTransactionDataModel.LoanerCodeID = item.LoanerCodeID;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.CreatedDate = item.CreatedDate;
                        objFilingTransactionDataModel.LoanLiablityNumber = item.LoanLiablityNumber;
                        objFilingTransactionDataModel.TransNumber = item.TransNumber;
                        objFilingTransactionDataModel.TransMapping = item.TransMapping;
                        lstFilingTransactionDataModel.Add(objFilingTransactionDataModel);
                    }
                    client.Close();
                    return lstFilingTransactionDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion GetFilingTrans24HourNoticeData

        #region mapGetFilingTrans24HourNoticeHistoryDataDALResponse
        /// <summary>
        /// mapGetFilingTrans24HourNoticeHistoryDataDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetFilingTrans24HourNoticeHistoryDataDALResponse(String strTransNumber, String filerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                    FilingTransactionDataModel objFilingTransactionDataModel;

                    var results = client.GetFilingTrans24HourNoticeHistoryData(strTransNumber, filerID);

                    foreach (var item in results)
                    {
                        objFilingTransactionDataModel = new FilingTransactionDataModel();
                        objFilingTransactionDataModel.FilingTransId = item.FilingTransId;
                        objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                        objFilingTransactionDataModel.ContributorTypeId = item.ContributorTypeId;
                        objFilingTransactionDataModel.ContributorTypeDesc = item.ContributorTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.PaymentTypeId = item.PaymentTypeId;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.SubmissionDate = item.SubmissionDate;
                        objFilingTransactionDataModel.SchedDate = item.SchedDate;
                        objFilingTransactionDataModel.FilingSchedDesc = item.FilingSchedDesc;
                        objFilingTransactionDataModel.FilingEntityId = item.FilingEntityId;
                        objFilingTransactionDataModel.FilingEntityName = item.FilingEntityName;
                        objFilingTransactionDataModel.FilingFirstName = item.FilingFirstName;
                        objFilingTransactionDataModel.FilingMiddleName = item.FilingMiddleName;
                        objFilingTransactionDataModel.FilingLastName = item.FilingLastName;
                        objFilingTransactionDataModel.FilingStreetNumber = item.FilingStreetNumber;
                        objFilingTransactionDataModel.FilingStreetName = item.FilingStreetName;
                        objFilingTransactionDataModel.FilingCity = item.FilingCity;
                        objFilingTransactionDataModel.FilingState = item.FilingState;
                        objFilingTransactionDataModel.FilingZip = item.FilingZip;
                        objFilingTransactionDataModel.FilingCountry = item.FilingCountry;
                        objFilingTransactionDataModel.PaymentTypeDesc = item.PaymentTypeDesc;
                        objFilingTransactionDataModel.PayNumber = item.PayNumber;
                        objFilingTransactionDataModel.OriginalAmount = item.OriginalAmount;
                        objFilingTransactionDataModel.ReceiptTypeDesc = item.ReceiptTypeDesc;
                        objFilingTransactionDataModel.TransferTypeDesc = item.TransferTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.OriginalDate = item.OriginalDate;
                        objFilingTransactionDataModel.LoanerCode = item.LoanerCode;
                        objFilingTransactionDataModel.ElectionYear = item.ElectionYear;
                        objFilingTransactionDataModel.Office = item.Office;
                        objFilingTransactionDataModel.District = item.District;
                        objFilingTransactionDataModel.RLiability = item.RLiability;
                        objFilingTransactionDataModel.RSubcontractor = item.RSubcontractor;
                        objFilingTransactionDataModel.TransExplanation = item.TransExplanation;
                        objFilingTransactionDataModel.OwedAmount = item.OwedAmount;
                        objFilingTransactionDataModel.RItemized = item.RItemized;
                        objFilingTransactionDataModel.RAmend = item.RAmend;
                        objFilingTransactionDataModel.Status = item.RStatus;
                        objFilingTransactionDataModel.CountyID = item.CountyID;
                        objFilingTransactionDataModel.CountyDesc = item.CountyDesc;
                        objFilingTransactionDataModel.MunicipalityID = item.MunicipalityID;
                        objFilingTransactionDataModel.MunicipalityDesc = item.MunicipalityDesc;
                        objFilingTransactionDataModel.LoanerCodeID = item.LoanerCodeID;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.CreatedDate = item.CreatedDate;
                        objFilingTransactionDataModel.LoanLiablityNumber = item.LoanLiablityNumber;
                        objFilingTransactionDataModel.TransNumber = item.TransNumber;
                        objFilingTransactionDataModel.TransMapping = item.TransMapping;
                        lstFilingTransactionDataModel.Add(objFilingTransactionDataModel);
                    }
                    client.Close();
                    return lstFilingTransactionDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetFilingTrans24HourNoticeHistoryDataDALResponse

        #region mapAddNonItem24HourNoticeFlngTransDALResponse
        /// <summary>
        /// mapAddNonItem24HourNoticeFlngTransDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapAddNonItem24HourNoticeFlngTransDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.ContributorTypeId = objFilingTransactionsModel.ContributorTypeId;
                    objFilingTransactionsContract.ContributionTypeId = objFilingTransactionsModel.ContributionTypeId;
                    objFilingTransactionsContract.LoanOtherId = objFilingTransactionsModel.LoanOtherId;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.MunicipalityID = objFilingTransactionsModel.MunicipalityID;
                    objFilingTransactionsContract.RAmend = objFilingTransactionsModel.RAmend;
                    objFilingTransactionsContract.ElectionDate = objFilingTransactionsModel.ElectionDate;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.ElectionYear = objFilingTransactionsModel.ElectionYear;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntFirstName = objFilingTransactionsModel.FlngEntFirstName;
                    objFilingTransactionsContract.FlngEntLastName = objFilingTransactionsModel.FlngEntLastName;
                    objFilingTransactionsContract.FlngEntMiddleName = objFilingTransactionsModel.FlngEntMiddleName;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;

                    Boolean returnValue = client.AddNonItem24HourNoticeFlngTrans(objFilingTransactionsContract);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapAddNonItem24HourNoticeFlngTransDALResponse

        #region mapUpdate24HNoticeFlngTransDALResponse
        /// <summary>
        /// mapUpdate24HNoticeFlngTransDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdate24HNoticeFlngTransDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();

                    objFilingTransactionsContract.TransNumber = objFilingTransactionsModel.TransNumber;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.ContributorTypeId = objFilingTransactionsModel.ContributorTypeId;
                    objFilingTransactionsContract.ContributionTypeId = objFilingTransactionsModel.ContributionTypeId;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.SubmissionDate = objFilingTransactionsModel.SubmissionDate;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntFirstName = objFilingTransactionsModel.FlngEntFirstName;
                    objFilingTransactionsContract.FlngEntMiddleName = objFilingTransactionsModel.FlngEntMiddleName;
                    objFilingTransactionsContract.FlngEntLastName = objFilingTransactionsModel.FlngEntLastName;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.ModifiedBy = objFilingTransactionsModel.ModifiedBy;
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;

                    Boolean returnValue = client.Update24HNoticeFlngTrans(objFilingTransactionsContract);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapUpdate24HNoticeFlngTransDALResponse

        #region mapSubmit24HNoticeFlngTransDALResponse
        /// <summary>
        /// mapSubmit24HNoticeFlngTransDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapSubmit24HNoticeFlngTransDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.ContributorTypeId = objFilingTransactionsModel.ContributorTypeId;
                    objFilingTransactionsContract.ContributionTypeId = objFilingTransactionsModel.ContributionTypeId;
                    objFilingTransactionsContract.TransNumber = objFilingTransactionsModel.TransNumber;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.ElectionDate = objFilingTransactionsModel.ElectionDate;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.ElectionYear = objFilingTransactionsModel.ElectionYear;
                    objFilingTransactionsContract.MunicipalityID = objFilingTransactionsModel.MunicipalityID;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;
                    objFilingTransactionsContract.ModifiedBy = objFilingTransactionsModel.ModifiedBy;

                    Boolean returnValue = client.Submit24HNoticeFlngTrans(objFilingTransactionsContract);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapSubmit24HNoticeFlngTransDALResponse

        #region mapDelete24HNoticeFlngTransDALResponse
        /// <summary>
        /// mapDelete24HNoticeFlngTransDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        internal Boolean mapDelete24HNoticeFlngTransDALResponse(String strTransNumber, String strModifiedBy, String filerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    Boolean returnValue = client.Delete24HNoticeFlngTrans(strTransNumber, strModifiedBy, filerID);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapDelete24HNoticeFlngTransDALResponse

        #region mapGetNonItemChildTransExistsDALResponse
        /// <summary>
        /// mapGetNonItemChildTransExistsDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal Boolean mapGetNonItemChildTransExistsDALResponse(String strTransNumber, String filerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    Boolean strChildTransExists = client.GetNonItemChildTransExists(strTransNumber, filerID);
                    client.Close();
                    return strChildTransExists;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
           
            
        }
        #endregion mapGetNonItemChildTransExistsDALResponse

        #region mapGetNonItemParentTransExistsDALResponse
        /// <summary>
        /// mapGetNonItemParentTransExistsDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal Boolean mapGetNonItemParentTransExistsDALResponse(String strTransNumber, String filerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    Boolean strChildTransExists = client.GetNonItemParentTransExists(strTransNumber, filerID);
                    client.Close();
                    return strChildTransExists;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetNonItemParentTransExistsDALResponse

        #region mapGetCommEdit24HourNoticeTransDataDALResponse
        /// <summary>
        /// mapGetCommEdit24HourNoticeTransDataDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param> 
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetCommEdit24HourNoticeTransDataDALResponse(String strTransNumber, String filerID) 
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                    FilingTransactionDataModel objFilingTransactionDataModel;

                    var results = client.GetCommEdit24HourNoticeTransData(strTransNumber, filerID);

                    foreach (var item in results)
                    {
                        objFilingTransactionDataModel = new FilingTransactionDataModel();
                        objFilingTransactionDataModel.FilingTransId = item.FilingTransId;
                        objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                        objFilingTransactionDataModel.ContributorTypeId = item.ContributorTypeId;
                        objFilingTransactionDataModel.ContributorTypeDesc = item.ContributorTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.PaymentTypeId = item.PaymentTypeId;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.SubmissionDate = item.SubmissionDate;
                        objFilingTransactionDataModel.SchedDate = item.SchedDate;
                        objFilingTransactionDataModel.FilingSchedDesc = item.FilingSchedDesc;
                        objFilingTransactionDataModel.FilingEntityId = item.FilingEntityId;
                        objFilingTransactionDataModel.FilingEntityName = item.FilingEntityName;
                        objFilingTransactionDataModel.FilingFirstName = item.FilingFirstName;
                        objFilingTransactionDataModel.FilingMiddleName = item.FilingMiddleName;
                        objFilingTransactionDataModel.FilingLastName = item.FilingLastName;
                        objFilingTransactionDataModel.FilingStreetNumber = item.FilingStreetNumber;
                        objFilingTransactionDataModel.FilingStreetName = item.FilingStreetName;
                        objFilingTransactionDataModel.FilingCity = item.FilingCity;
                        objFilingTransactionDataModel.FilingState = item.FilingState;
                        objFilingTransactionDataModel.FilingZip = item.FilingZip;
                        objFilingTransactionDataModel.FilingCountry = item.FilingCountry;
                        objFilingTransactionDataModel.PaymentTypeDesc = item.PaymentTypeDesc;
                        objFilingTransactionDataModel.PayNumber = item.PayNumber;
                        objFilingTransactionDataModel.OriginalAmount = item.OriginalAmount;
                        objFilingTransactionDataModel.ReceiptTypeDesc = item.ReceiptTypeDesc;
                        objFilingTransactionDataModel.TransferTypeDesc = item.TransferTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.OriginalDate = item.OriginalDate;
                        objFilingTransactionDataModel.LoanerCode = item.LoanerCode;
                        objFilingTransactionDataModel.ElectionYear = item.ElectionYear;
                        objFilingTransactionDataModel.Office = item.Office;
                        objFilingTransactionDataModel.District = item.District;
                        objFilingTransactionDataModel.RLiability = item.RLiability;
                        objFilingTransactionDataModel.RSubcontractor = item.RSubcontractor;
                        objFilingTransactionDataModel.TransExplanation = item.TransExplanation;
                        objFilingTransactionDataModel.OwedAmount = item.OwedAmount;
                        objFilingTransactionDataModel.RItemized = item.RItemized;
                        objFilingTransactionDataModel.RAmend = item.RAmend;
                        objFilingTransactionDataModel.Status = item.RStatus;
                        objFilingTransactionDataModel.CountyID = item.CountyID;
                        objFilingTransactionDataModel.CountyDesc = item.CountyDesc;
                        objFilingTransactionDataModel.MunicipalityID = item.MunicipalityID;
                        objFilingTransactionDataModel.MunicipalityDesc = item.MunicipalityDesc;
                        objFilingTransactionDataModel.LoanerCodeID = item.LoanerCodeID;
                        objFilingTransactionDataModel.LoanLiablityNumber = item.LoanLiablityNumber;
                        objFilingTransactionDataModel.TransNumber = item.TransNumber;
                        objFilingTransactionDataModel.TransMapping = item.TransMapping;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        lstFilingTransactionDataModel.Add(objFilingTransactionDataModel);
                    }
                    client.Close();
                    return lstFilingTransactionDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetCommEdit24HourNoticeTransDataDALResponse

        #region mapGetFilingTransIEWeeklyContributioneDataDALResponse
        /// <summary>
        /// mapGetFilingTransIEWeeklyContributioneDataDALResponse
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetFilingTransIEWeeklyContributioneDataDALResponse(FilingTransDataModel objFilingTransDataModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                    FilingTransactionDataModel objFilingTransactionDataModel;

                    FilingTransDataContract objFilingTransDataContract = new FilingTransDataContract();
                    objFilingTransDataContract.FilerId = objFilingTransDataModel.FilerId;
                    objFilingTransDataContract.ReportYearId = objFilingTransDataModel.ReportYearId;
                    objFilingTransDataContract.OfficeTypeId = objFilingTransDataModel.OfficeTypeId;
                    objFilingTransDataContract.ElectionType = objFilingTransDataModel.ElectionType;
                    objFilingTransDataContract.ElectionDateId = objFilingTransDataModel.ElectionDateId;
                    objFilingTransDataContract.FilingDate = objFilingTransDataModel.FilingDate;
                    objFilingTransDataContract.MunicipalityID = objFilingTransDataModel.MunicipalityID;

                    var results = client.GetFilingTransIEWeeklyContributioneData(objFilingTransDataContract);

                    foreach (var item in results)
                    {
                        objFilingTransactionDataModel = new FilingTransactionDataModel();
                        objFilingTransactionDataModel.FilingTransId = item.FilingTransId;
                        objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                        objFilingTransactionDataModel.ContributorTypeId = item.ContributorTypeId;
                        objFilingTransactionDataModel.ContributorTypeDesc = item.ContributorTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.PaymentTypeId = item.PaymentTypeId;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.SubmissionDate = item.SubmissionDate;
                        objFilingTransactionDataModel.SchedDate = item.SchedDate;
                        objFilingTransactionDataModel.FilingSchedDesc = item.FilingSchedDesc;
                        objFilingTransactionDataModel.FilingEntityId = item.FilingEntityId;
                        objFilingTransactionDataModel.FilingEntityName = item.FilingEntityName;
                        objFilingTransactionDataModel.FilingFirstName = item.FilingFirstName;
                        objFilingTransactionDataModel.FilingMiddleName = item.FilingMiddleName;
                        objFilingTransactionDataModel.FilingLastName = item.FilingLastName;
                        objFilingTransactionDataModel.FilingStreetNumber = item.FilingStreetNumber;
                        objFilingTransactionDataModel.FilingStreetName = item.FilingStreetName;
                        objFilingTransactionDataModel.FilingCity = item.FilingCity;
                        objFilingTransactionDataModel.FilingState = item.FilingState;
                        objFilingTransactionDataModel.FilingZip = item.FilingZip;
                        objFilingTransactionDataModel.FilingCountry = item.FilingCountry;
                        objFilingTransactionDataModel.PaymentTypeDesc = item.PaymentTypeDesc;
                        objFilingTransactionDataModel.PayNumber = item.PayNumber;
                        objFilingTransactionDataModel.OriginalAmount = item.OriginalAmount;
                        objFilingTransactionDataModel.ReceiptTypeDesc = item.ReceiptTypeDesc;
                        objFilingTransactionDataModel.TransferTypeDesc = item.TransferTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.OriginalDate = item.OriginalDate;
                        objFilingTransactionDataModel.LoanerCode = item.LoanerCode;
                        objFilingTransactionDataModel.ElectionYear = item.ElectionYear;
                        objFilingTransactionDataModel.Office = item.Office;
                        objFilingTransactionDataModel.District = item.District;
                        objFilingTransactionDataModel.RLiability = item.RLiability;
                        objFilingTransactionDataModel.RSubcontractor = item.RSubcontractor;
                        objFilingTransactionDataModel.TransExplanation = item.TransExplanation;
                        objFilingTransactionDataModel.OwedAmount = item.OwedAmount;
                        objFilingTransactionDataModel.RItemized = item.RItemized;
                        objFilingTransactionDataModel.RAmend = item.RAmend;
                        objFilingTransactionDataModel.Status = item.RStatus;
                        objFilingTransactionDataModel.CountyID = item.CountyID;
                        objFilingTransactionDataModel.CountyDesc = item.CountyDesc;
                        objFilingTransactionDataModel.MunicipalityID = item.MunicipalityID;
                        objFilingTransactionDataModel.MunicipalityDesc = item.MunicipalityDesc;
                        objFilingTransactionDataModel.LoanerCodeID = item.LoanerCodeID;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.CreatedDate = item.CreatedDate;
                        objFilingTransactionDataModel.TreasurerFirstName = item.TreasurerFirstName;
                        objFilingTransactionDataModel.TreasurerLastName = item.TreasurerLastName;
                        objFilingTransactionDataModel.TreasurerMiddleName = item.TreasurerMiddleName;
                        objFilingTransactionDataModel.TreasurerOccuptaion = item.TreasurerOccuptaion;
                        objFilingTransactionDataModel.TreasurerEmployer = item.TreasurerEmployer;
                        objFilingTransactionDataModel.TreasurerStreetAddress = item.TreasurerStreetAddress;
                        objFilingTransactionDataModel.TreasurerCity = item.TreasurerCity;
                        objFilingTransactionDataModel.TreasurerState = item.TreasurerState;
                        objFilingTransactionDataModel.TreasurerZip = item.TreasurerZip;
                        objFilingTransactionDataModel.ContributorOccupation = item.ContributorOccupation;
                        objFilingTransactionDataModel.ContributorEmployer = item.ContributorEmployer;
                        objFilingTransactionDataModel.IEDescription = item.IEDescription;
                        objFilingTransactionDataModel.CandBallotPropReference = item.CandBallotPropReference;
                        objFilingTransactionDataModel.IESupported = item.IESupported;
                        objFilingTransactionDataModel.AddrId = item.AddrId;
                        objFilingTransactionDataModel.TreasId = item.TreasId;
                        objFilingTransactionDataModel.LoanLiablityNumber = item.LoanLiablityNumber;
                        objFilingTransactionDataModel.TransNumber = item.TransNumber;
                        objFilingTransactionDataModel.TransMapping = item.TransMapping;
                        lstFilingTransactionDataModel.Add(objFilingTransactionDataModel);
                    }
                    client.Close();
                    return lstFilingTransactionDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetFilingTransIEWeeklyContributioneDataDALResponse

        #region mapGetIEWeeklyContrbutionTreasurerDataDALResponse
        /// <summary>
        /// mapGetIEWeeklyContrbutionTreasurerDataDALResponse
        /// </summary>
        /// <param name="strTreasurerId"></param>
        /// <returns></returns>
        internal IList<NonItemIETreasurerModel> mapGetIEWeeklyContrbutionTreasurerDataDALResponse(String strTreasurerId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<NonItemIETreasurerModel> lstNonItemIETreasurerModel = new List<NonItemIETreasurerModel>();
                    NonItemIETreasurerModel objNonItemIETreasurerModel;

                    var results = client.GetIEWeeklyContrbutionTreasurerData(strTreasurerId);

                    foreach (var item in results)
                    {
                        objNonItemIETreasurerModel = new NonItemIETreasurerModel();
                        objNonItemIETreasurerModel.AddressId = item.AddressId;
                        objNonItemIETreasurerModel.PersonId = item.PersonId;
                        objNonItemIETreasurerModel.TreasurerName = item.TreasurerName;
                        objNonItemIETreasurerModel.TreasurerOccupation = item.TreasurerOccupation;
                        objNonItemIETreasurerModel.TreasurerEmployer = item.TreasurerEmployer;
                        objNonItemIETreasurerModel.TreasurerStreetAddress = item.TreasurerStreetAddress;
                        objNonItemIETreasurerModel.TreasurerCity = item.TreasurerCity;
                        objNonItemIETreasurerModel.TreasurerState = item.TreasurerState;
                        objNonItemIETreasurerModel.TreasurerZip = item.TreasurerZip;
                        lstNonItemIETreasurerModel.Add(objNonItemIETreasurerModel);
                    }
                    client.Close();
                    return lstNonItemIETreasurerModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetIEWeeklyContrbutionTreasurerDataDALResponse

        #region mapAddNonItemIEWeeklyContrFlngTransDALResponse
        /// <summary>
        /// mapAddNonItemIEWeeklyContrFlngTransDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapAddNonItemIEWeeklyContrFlngTransDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.PersonId = objFilingTransactionsModel.PersonId;
                    objFilingTransactionsContract.TreasId = objFilingTransactionsModel.TreasId;
                    objFilingTransactionsContract.AddrId = objFilingTransactionsModel.AddrId;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.ContributorTypeId = objFilingTransactionsModel.ContributorTypeId;
                    objFilingTransactionsContract.ContributionTypeId = objFilingTransactionsModel.ContributionTypeId;
                    objFilingTransactionsContract.LoanOtherId = objFilingTransactionsModel.LoanOtherId;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.MunicipalityID = objFilingTransactionsModel.MunicipalityID;
                    objFilingTransactionsContract.RAmend = objFilingTransactionsModel.RAmend;
                    objFilingTransactionsContract.ElectionDate = objFilingTransactionsModel.ElectionDate;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.ElectionYear = objFilingTransactionsModel.ElectionYear;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntFirstName = objFilingTransactionsModel.FlngEntFirstName;
                    objFilingTransactionsContract.FlngEntLastName = objFilingTransactionsModel.FlngEntLastName;
                    objFilingTransactionsContract.FlngEntMiddleName = objFilingTransactionsModel.FlngEntMiddleName;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.TreasurerOccupation = objFilingTransactionsModel.TreasurerOccupation;
                    objFilingTransactionsContract.TreasurerEmployer = objFilingTransactionsModel.TreasurerEmployer;
                    objFilingTransactionsContract.TreasurerStreetAddress = objFilingTransactionsModel.TreasurerStreetAddress;
                    objFilingTransactionsContract.TreasurerCity = objFilingTransactionsModel.TreasurerCity;
                    objFilingTransactionsContract.TreasurerState = objFilingTransactionsModel.TreasurerState;
                    objFilingTransactionsContract.TreasurerZip = objFilingTransactionsModel.TreasurerZip;
                    objFilingTransactionsContract.CandBallotPropReference = objFilingTransactionsModel.CandBallotPropReference;
                    objFilingTransactionsContract.ContributorOccupation = objFilingTransactionsModel.ContributorOccupation;
                    objFilingTransactionsContract.ContributorEmployer = objFilingTransactionsModel.ContributorEmployer;
                    objFilingTransactionsContract.IEDescription = objFilingTransactionsModel.IEDescription;
                    objFilingTransactionsContract.R_Supported = objFilingTransactionsModel.R_Supported;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;

                    Boolean results = client.AddNonItemIEWeeklyContrFlngTrans(objFilingTransactionsContract);
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
        #endregion mapAddNonItemIEWeeklyContrFlngTransDALResponse

        #region mapUpdateIEWeeklyContrFlngTransDALResponse
        /// <summary>
        /// mapUpdateIEWeeklyContrFlngTransDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateIEWeeklyContrFlngTransDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.TransNumber = objFilingTransactionsModel.TransNumber;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.ContributorTypeId = objFilingTransactionsModel.ContributorTypeId;
                    objFilingTransactionsContract.ContributionTypeId = objFilingTransactionsModel.ContributionTypeId;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.TreasId = objFilingTransactionsModel.TreasId;
                    objFilingTransactionsContract.AddrId = objFilingTransactionsModel.AddrId;
                    objFilingTransactionsContract.PersonId = objFilingTransactionsModel.PersonId;
                    objFilingTransactionsContract.SubmissionDate = objFilingTransactionsModel.SubmissionDate;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntFirstName = objFilingTransactionsModel.FlngEntFirstName;
                    objFilingTransactionsContract.FlngEntMiddleName = objFilingTransactionsModel.FlngEntMiddleName;
                    objFilingTransactionsContract.FlngEntLastName = objFilingTransactionsModel.FlngEntLastName;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.TreasurerStreetAddress = objFilingTransactionsModel.TreasurerStreetAddress;
                    objFilingTransactionsContract.TreasurerCity = objFilingTransactionsModel.TreasurerCity;
                    objFilingTransactionsContract.TreasurerState = objFilingTransactionsModel.TreasurerState;
                    objFilingTransactionsContract.TreasurerZip = objFilingTransactionsModel.TreasurerZip;
                    objFilingTransactionsContract.ContributorOccupation = objFilingTransactionsModel.ContributorOccupation;
                    objFilingTransactionsContract.ContributorEmployer = objFilingTransactionsModel.ContributorEmployer;
                    objFilingTransactionsContract.IEDescription = objFilingTransactionsModel.IEDescription;
                    objFilingTransactionsContract.TreasurerOccupation = objFilingTransactionsModel.TreasurerOccupation;
                    objFilingTransactionsContract.TreasurerEmployer = objFilingTransactionsModel.TreasurerEmployer;
                    objFilingTransactionsContract.R_Supported = objFilingTransactionsModel.R_Supported;
                    objFilingTransactionsContract.CandBallotPropReference = objFilingTransactionsModel.CandBallotPropReference;
                    objFilingTransactionsContract.ModifiedBy = objFilingTransactionsModel.ModifiedBy;

                    Boolean results = client.UpdateIEWeeklyContrFlngTrans(objFilingTransactionsContract);
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
        #endregion mapUpdateIEWeeklyContrFlngTransDALResponse

        #region mapSubmitIEWeeklyContrFlngTransDALResponse
        /// <summary>
        /// mapSubmitIEWeeklyContrFlngTransDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        internal Boolean mapSubmitIEWeeklyContrFlngTransDALResponse(String strTransNumber, String strModifiedBy)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    Boolean results = client.SubmitIEWeeklyContrFlngTrans(strTransNumber, strModifiedBy);
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
        #endregion mapSubmitIEWeeklyContrFlngTransDALResponse

        #region mapGetFilingTransIETransHistoryDataDALResponse
        /// <summary>
        /// mapGetFilingTransIETransHistoryDataDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetFilingTransIETransHistoryDataDALResponse(String strFilingTransId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                    FilingTransactionDataModel objFilingTransactionDataModel;

                    var results = client.GetFilingTransIETransHistoryData(strFilingTransId);

                    foreach (var item in results)
                    {
                        objFilingTransactionDataModel = new FilingTransactionDataModel();
                        objFilingTransactionDataModel.FilingTransId = item.FilingTransId;
                        objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                        objFilingTransactionDataModel.ContributorTypeId = item.ContributorTypeId;
                        objFilingTransactionDataModel.ContributorTypeDesc = item.ContributorTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.PaymentTypeId = item.PaymentTypeId;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.SubmissionDate = item.SubmissionDate;
                        objFilingTransactionDataModel.SchedDate = item.SchedDate;
                        objFilingTransactionDataModel.FilingSchedDesc = item.FilingSchedDesc;
                        objFilingTransactionDataModel.FilingEntityId = item.FilingEntityId;
                        objFilingTransactionDataModel.FilingEntityName = item.FilingEntityName;
                        objFilingTransactionDataModel.FilingFirstName = item.FilingFirstName;
                        objFilingTransactionDataModel.FilingMiddleName = item.FilingMiddleName;
                        objFilingTransactionDataModel.FilingLastName = item.FilingLastName;
                        objFilingTransactionDataModel.FilingStreetNumber = item.FilingStreetNumber;
                        objFilingTransactionDataModel.FilingStreetName = item.FilingStreetName;
                        objFilingTransactionDataModel.FilingCity = item.FilingCity;
                        objFilingTransactionDataModel.FilingState = item.FilingState;
                        objFilingTransactionDataModel.FilingZip = item.FilingZip;
                        objFilingTransactionDataModel.FilingCountry = item.FilingCountry;
                        objFilingTransactionDataModel.PaymentTypeDesc = item.PaymentTypeDesc;
                        objFilingTransactionDataModel.PayNumber = item.PayNumber;
                        objFilingTransactionDataModel.OriginalAmount = item.OriginalAmount;
                        objFilingTransactionDataModel.ReceiptTypeDesc = item.ReceiptTypeDesc;
                        objFilingTransactionDataModel.TransferTypeDesc = item.TransferTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.OriginalDate = item.OriginalDate;
                        objFilingTransactionDataModel.LoanerCode = item.LoanerCode;
                        objFilingTransactionDataModel.ElectionYear = item.ElectionYear;
                        objFilingTransactionDataModel.Office = item.Office;
                        objFilingTransactionDataModel.District = item.District;
                        objFilingTransactionDataModel.RLiability = item.RLiability;
                        objFilingTransactionDataModel.RSubcontractor = item.RSubcontractor;
                        objFilingTransactionDataModel.TransExplanation = item.TransExplanation;
                        objFilingTransactionDataModel.OwedAmount = item.OwedAmount;
                        objFilingTransactionDataModel.RItemized = item.RItemized;
                        objFilingTransactionDataModel.RAmend = item.RAmend;
                        objFilingTransactionDataModel.Status = item.RStatus;
                        objFilingTransactionDataModel.CountyID = item.CountyID;
                        objFilingTransactionDataModel.CountyDesc = item.CountyDesc;
                        objFilingTransactionDataModel.MunicipalityID = item.MunicipalityID;
                        objFilingTransactionDataModel.MunicipalityDesc = item.MunicipalityDesc;
                        objFilingTransactionDataModel.LoanerCodeID = item.LoanerCodeID;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.CreatedDate = item.CreatedDate;
                        objFilingTransactionDataModel.TreasurerFirstName = item.TreasurerFirstName;
                        objFilingTransactionDataModel.TreasurerLastName = item.TreasurerLastName;
                        objFilingTransactionDataModel.TreasurerMiddleName = item.TreasurerMiddleName;
                        objFilingTransactionDataModel.TreasurerOccuptaion = item.TreasurerOccuptaion;
                        objFilingTransactionDataModel.TreasurerEmployer = item.TreasurerEmployer;
                        objFilingTransactionDataModel.TreasurerStreetAddress = item.TreasurerStreetAddress;
                        objFilingTransactionDataModel.TreasurerCity = item.TreasurerCity;
                        objFilingTransactionDataModel.TreasurerState = item.TreasurerState;
                        objFilingTransactionDataModel.TreasurerZip = item.TreasurerZip;
                        objFilingTransactionDataModel.ContributorOccupation = item.ContributorOccupation;
                        objFilingTransactionDataModel.ContributorEmployer = item.ContributorEmployer;
                        objFilingTransactionDataModel.CandBallotPropReference = item.CandBallotPropReference;
                        objFilingTransactionDataModel.IEDescription = item.IEDescription;
                        objFilingTransactionDataModel.IESupported = item.IESupported;
                        objFilingTransactionDataModel.LoanLiablityNumber = item.LoanLiablityNumber;
                        objFilingTransactionDataModel.TransNumber = item.TransNumber;
                        objFilingTransactionDataModel.TransMapping = item.TransMapping;
                        lstFilingTransactionDataModel.Add(objFilingTransactionDataModel);
                    }
                    client.Close();
                    return lstFilingTransactionDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetFilingTransIETransHistoryDataDALResponse

        #region mapGetItemizedNonItemIETransactionsDALResponse
        /// <summary>
        /// mapGetItemizedNonItemIETransactionsDALResponse
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strElectionDateId"></param> 
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetItemizedNonItemIETransactionsDALResponse(String strFilerId, String strElectionYearId, String strOfficeTypeId, String strElectionTypeId, String strElectionDateId, String strMunicipalityId, String strFilingDate)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                    FilingTransactionDataModel objFilingTransactionDataModel;
                    if (strElectionDateId == "- Select -")
                    {
                        strElectionDateId = "0";
                    }
                    var results = client.GetItemizedNonItemIETransactions(strFilerId, strElectionYearId, strOfficeTypeId, strElectionTypeId, strElectionDateId, strMunicipalityId, strFilingDate);

                    foreach (var item in results)
                    {
                        objFilingTransactionDataModel = new FilingTransactionDataModel();
                        objFilingTransactionDataModel.FilingTransId = item.FilingTransId;
                        objFilingTransactionDataModel.SchedDate = item.SchedDate;
                        objFilingTransactionDataModel.OriginalAmount = item.OriginalAmount;
                        objFilingTransactionDataModel.IEDescription = item.IEDescription;
                        objFilingTransactionDataModel.IEType = item.IEType;
                        objFilingTransactionDataModel.TreasurerName = item.TreasurerName;
                        objFilingTransactionDataModel.ContributorName = item.ContributorName;
                        objFilingTransactionDataModel.TreasurerCity = item.TreasurerCity;
                        objFilingTransactionDataModel.TreasurerState = item.TreasurerState;
                        objFilingTransactionDataModel.CandBallotPropReference = item.CandBallotPropReference;
                        objFilingTransactionDataModel.TransExplanation = item.TransExplanation;
                        objFilingTransactionDataModel.CreatedDate = item.CreatedDate;
                        objFilingTransactionDataModel.LoanLiablityNumber = item.LoanLiablityNumber;
                        objFilingTransactionDataModel.TransNumber = item.TransNumber;
                        objFilingTransactionDataModel.TransMapping = item.TransMapping;
                        lstFilingTransactionDataModel.Add(objFilingTransactionDataModel);
                    }
                    client.Close();
                    return lstFilingTransactionDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetItemizedNonItemIETransactionsDALResponse

        #region mapAddItemizedIETransactionsDataDALResponse
        /// <summary>
        /// mapAddItemizedIETransactionsDataDALResponse
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
        internal Boolean mapAddItemizedIETransactionsDataDALResponse(IEnumerable<String> strTransNumber, String strFilerId, String strElectionYearId, String strOfficeTypeId, String strFilingTypeId, String strElectionTypeId, String strElectionDateId, String strCreatedBy, String strFilingDate)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    var arrayString = new List<String>(strTransNumber).ToArray();

                    Boolean results = client.AddItemizedIETransactionsData(arrayString, strFilerId, strElectionYearId, strOfficeTypeId, strFilingTypeId, strElectionTypeId, strElectionDateId, strCreatedBy, strFilingDate);
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
        #endregion mapAddItemizedIETransactionsDataDALResponse

        #region mapGetContributorCodeIEWeeklyContrSchedCDALResponse
        /// <summary>
        /// mapGetContributorCodeIEWeeklyContrSchedCDALResponse
        /// </summary>
        /// <returns></returns>
        internal IList<ContributorNameModel> mapGetContributorCodeIEWeeklyContrSchedCDALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ContributorNameModel> lstContributorNameModel = new List<ContributorNameModel>();
                    ContributorNameModel objContributorNameModel;

                    var results = client.GetContributorCodeIEWeeklyContrSchedC();

                    foreach (var item in results)
                    {
                        objContributorNameModel = new ContributorNameModel();
                        objContributorNameModel.ContributorTypeId = item.ContributorTypeId;
                        objContributorNameModel.ContributorTypeDesc = item.ContributorTypeDesc;
                        objContributorNameModel.ContributorTypeAbbrev = item.ContributorTypeAbbrev;
                        lstContributorNameModel.Add(objContributorNameModel);
                    }
                    client.Close();
                    return lstContributorNameModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetContributorCodeIEWeeklyContrSchedCDALResponse

        #region mapGetContributorCodeIEWeeklyContrSchedDDALRespnse
        /// <summary>
        /// /mapGetContributorCodeIEWeeklyContrSchedDDALRespnse
        /// </summary>
        /// <returns></returns>
        internal IList<ContributorNameModel> mapGetContributorCodeIEWeeklyContrSchedDDALRespnse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ContributorNameModel> lstContributorNameModel = new List<ContributorNameModel>();
                    ContributorNameModel objContributorNameModel;

                    var results = client.GetContributorCodeIEWeeklyContrSchedD();

                    foreach (var item in results)
                    {
                        objContributorNameModel = new ContributorNameModel();
                        objContributorNameModel.ContributorTypeId = item.ContributorTypeId;
                        objContributorNameModel.ContributorTypeDesc = item.ContributorTypeDesc;
                        objContributorNameModel.ContributorTypeAbbrev = item.ContributorTypeAbbrev;
                        lstContributorNameModel.Add(objContributorNameModel);
                    }
                    client.Close();
                    return lstContributorNameModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetContributorCodeIEWeeklyContrSchedDDALRespnse

        #region mapGetFilingTransIE24HContributioneDataDALResponse
        /// <summary> 
        /// mapGetFilingTransIE24HContributioneDataDALResponse
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetFilingTransIE24HContributioneDataDALResponse(FilingTransDataModel objFilingTransDataModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                    FilingTransactionDataModel objFilingTransactionDataModel;

                    FilingTransDataContract objFilingTransDataContract = new FilingTransDataContract();
                    objFilingTransDataContract.FilerId = objFilingTransDataModel.FilerId;
                    objFilingTransDataContract.ReportYearId = objFilingTransDataModel.ReportYearId;
                    objFilingTransDataContract.OfficeTypeId = objFilingTransDataModel.OfficeTypeId;
                    objFilingTransDataContract.ElectionType = objFilingTransDataModel.ElectionType;
                    objFilingTransDataContract.ElectionDateId = objFilingTransDataModel.ElectionDateId;
                    objFilingTransDataContract.FilingDate = objFilingTransDataModel.FilingDate;

                    var results = client.GetFilingTransIE24HContributioneData(objFilingTransDataContract);

                    foreach (var item in results)
                    {
                        objFilingTransactionDataModel = new FilingTransactionDataModel();
                        objFilingTransactionDataModel.FilingTransId = item.FilingTransId;
                        objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                        objFilingTransactionDataModel.ContributorTypeId = item.ContributorTypeId;
                        objFilingTransactionDataModel.ContributorTypeDesc = item.ContributorTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.PaymentTypeId = item.PaymentTypeId;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.PurposeCodeId = item.PurposeCodeId;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.SubmissionDate = item.SubmissionDate;
                        objFilingTransactionDataModel.SchedDate = item.SchedDate;
                        objFilingTransactionDataModel.FilingSchedDesc = item.FilingSchedDesc;
                        objFilingTransactionDataModel.FilingEntityId = item.FilingEntityId;
                        objFilingTransactionDataModel.FilingEntityName = item.FilingEntityName;
                        objFilingTransactionDataModel.FilingFirstName = item.FilingFirstName;
                        objFilingTransactionDataModel.FilingMiddleName = item.FilingMiddleName;
                        objFilingTransactionDataModel.FilingLastName = item.FilingLastName;
                        objFilingTransactionDataModel.FilingStreetNumber = item.FilingStreetNumber;
                        objFilingTransactionDataModel.FilingStreetName = item.FilingStreetName;
                        objFilingTransactionDataModel.FilingCity = item.FilingCity;
                        objFilingTransactionDataModel.FilingState = item.FilingState;
                        objFilingTransactionDataModel.FilingZip = item.FilingZip;
                        objFilingTransactionDataModel.FilingCountry = item.FilingCountry;
                        objFilingTransactionDataModel.PaymentTypeDesc = item.PaymentTypeDesc;
                        objFilingTransactionDataModel.PayNumber = item.PayNumber;
                        objFilingTransactionDataModel.OriginalAmount = item.OriginalAmount;
                        objFilingTransactionDataModel.ReceiptTypeDesc = item.ReceiptTypeDesc;
                        objFilingTransactionDataModel.TransferTypeDesc = item.TransferTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.OriginalDate = item.OriginalDate;
                        objFilingTransactionDataModel.LoanerCode = item.LoanerCode;
                        objFilingTransactionDataModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objFilingTransactionDataModel.ElectionYear = item.ElectionYear;
                        objFilingTransactionDataModel.Office = item.Office;
                        objFilingTransactionDataModel.District = item.District;
                        objFilingTransactionDataModel.RLiability = item.RLiability;
                        objFilingTransactionDataModel.RSubcontractor = item.RSubcontractor;
                        objFilingTransactionDataModel.TransExplanation = item.TransExplanation;
                        objFilingTransactionDataModel.OwedAmount = item.OwedAmount;
                        objFilingTransactionDataModel.RItemized = item.RItemized;
                        objFilingTransactionDataModel.RAmend = item.RAmend;
                        objFilingTransactionDataModel.Status = item.RStatus;
                        objFilingTransactionDataModel.CountyID = item.CountyID;
                        objFilingTransactionDataModel.CountyDesc = item.CountyDesc;
                        objFilingTransactionDataModel.MunicipalityID = item.MunicipalityID;
                        objFilingTransactionDataModel.MunicipalityDesc = item.MunicipalityDesc;
                        objFilingTransactionDataModel.LoanerCodeID = item.LoanerCodeID;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.CreatedDate = item.CreatedDate;
                        objFilingTransactionDataModel.TreasurerFirstName = item.TreasurerFirstName;
                        objFilingTransactionDataModel.TreasurerLastName = item.TreasurerLastName;
                        objFilingTransactionDataModel.TreasurerMiddleName = item.TreasurerMiddleName;
                        objFilingTransactionDataModel.TreasurerOccuptaion = item.TreasurerOccuptaion;
                        objFilingTransactionDataModel.TreasurerEmployer = item.TreasurerEmployer;
                        objFilingTransactionDataModel.TreasurerStreetAddress = item.TreasurerStreetAddress;
                        objFilingTransactionDataModel.TreasurerCity = item.TreasurerCity;
                        objFilingTransactionDataModel.TreasurerState = item.TreasurerState;
                        objFilingTransactionDataModel.TreasurerZip = item.TreasurerZip;
                        objFilingTransactionDataModel.ContributorOccupation = item.ContributorOccupation;
                        objFilingTransactionDataModel.ContributorEmployer = item.ContributorEmployer;
                        objFilingTransactionDataModel.IEDescription = item.IEDescription;
                        objFilingTransactionDataModel.CandBallotPropReference = item.CandBallotPropReference;
                        objFilingTransactionDataModel.IESupported = item.IESupported;
                        objFilingTransactionDataModel.AddrId = item.AddrId;
                        objFilingTransactionDataModel.TreasId = item.TreasId;
                        objFilingTransactionDataModel.TransNumber = item.TransNumber;
                        objFilingTransactionDataModel.LoanLiablityNumber = item.LoanLiablityNumber;
                        objFilingTransactionDataModel.TransMapping = item.TransMapping;
                        lstFilingTransactionDataModel.Add(objFilingTransactionDataModel);
                    }
                    client.Close();
                    return lstFilingTransactionDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetFilingTransIE24HContributioneDataDALResponse

        #region mapGetFilingTransIE24HContributionHistoryDataDALResponse
        /// <summary>
        /// mapGetFilingTransIE24HContributionHistoryDataDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetFilingTransIE24HContributionHistoryDataDALResponse(String strTransNumber)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                    FilingTransactionDataModel objFilingTransactionDataModel;

                    var results = client.GetFilingTransIE24HContributionHistoryData(strTransNumber);

                    foreach (var item in results)
                    {
                        objFilingTransactionDataModel = new FilingTransactionDataModel();
                        objFilingTransactionDataModel.FilingTransId = item.FilingTransId;
                        objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                        objFilingTransactionDataModel.ContributorTypeId = item.ContributorTypeId;
                        objFilingTransactionDataModel.ContributorTypeDesc = item.ContributorTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.PaymentTypeId = item.PaymentTypeId;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.SubmissionDate = item.SubmissionDate;
                        objFilingTransactionDataModel.SchedDate = item.SchedDate;
                        objFilingTransactionDataModel.FilingSchedDesc = item.FilingSchedDesc;
                        objFilingTransactionDataModel.FilingEntityId = item.FilingEntityId;
                        objFilingTransactionDataModel.FilingEntityName = item.FilingEntityName;
                        objFilingTransactionDataModel.FilingFirstName = item.FilingFirstName;
                        objFilingTransactionDataModel.FilingMiddleName = item.FilingMiddleName;
                        objFilingTransactionDataModel.FilingLastName = item.FilingLastName;
                        objFilingTransactionDataModel.FilingStreetNumber = item.FilingStreetNumber;
                        objFilingTransactionDataModel.FilingStreetName = item.FilingStreetName;
                        objFilingTransactionDataModel.FilingCity = item.FilingCity;
                        objFilingTransactionDataModel.FilingState = item.FilingState;
                        objFilingTransactionDataModel.FilingZip = item.FilingZip;
                        objFilingTransactionDataModel.FilingCountry = item.FilingCountry;
                        objFilingTransactionDataModel.PaymentTypeDesc = item.PaymentTypeDesc;
                        objFilingTransactionDataModel.PayNumber = item.PayNumber;
                        objFilingTransactionDataModel.OriginalAmount = item.OriginalAmount;
                        objFilingTransactionDataModel.ReceiptTypeDesc = item.ReceiptTypeDesc;
                        objFilingTransactionDataModel.TransferTypeDesc = item.TransferTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.OriginalDate = item.OriginalDate;
                        objFilingTransactionDataModel.LoanerCode = item.LoanerCode;
                        objFilingTransactionDataModel.ElectionYear = item.ElectionYear;
                        objFilingTransactionDataModel.Office = item.Office;
                        objFilingTransactionDataModel.District = item.District;
                        objFilingTransactionDataModel.RLiability = item.RLiability;
                        objFilingTransactionDataModel.RSubcontractor = item.RSubcontractor;
                        objFilingTransactionDataModel.TransExplanation = item.TransExplanation;
                        objFilingTransactionDataModel.OwedAmount = item.OwedAmount;
                        objFilingTransactionDataModel.RItemized = item.RItemized;
                        objFilingTransactionDataModel.RAmend = item.RAmend;
                        objFilingTransactionDataModel.Status = item.RStatus;
                        objFilingTransactionDataModel.CountyID = item.CountyID;
                        objFilingTransactionDataModel.CountyDesc = item.CountyDesc;
                        objFilingTransactionDataModel.MunicipalityID = item.MunicipalityID;
                        objFilingTransactionDataModel.MunicipalityDesc = item.MunicipalityDesc;
                        objFilingTransactionDataModel.LoanerCodeID = item.LoanerCodeID;
                        objFilingTransactionDataModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.CreatedDate = item.CreatedDate;
                        objFilingTransactionDataModel.TreasurerFirstName = item.TreasurerFirstName;
                        objFilingTransactionDataModel.TreasurerLastName = item.TreasurerLastName;
                        objFilingTransactionDataModel.TreasurerMiddleName = item.TreasurerMiddleName;
                        objFilingTransactionDataModel.TreasurerOccuptaion = item.TreasurerOccuptaion;
                        objFilingTransactionDataModel.TreasurerEmployer = item.TreasurerEmployer;
                        objFilingTransactionDataModel.TreasurerStreetAddress = item.TreasurerStreetAddress;
                        objFilingTransactionDataModel.TreasurerCity = item.TreasurerCity;
                        objFilingTransactionDataModel.TreasurerState = item.TreasurerState;
                        objFilingTransactionDataModel.TreasurerZip = item.TreasurerZip;
                        objFilingTransactionDataModel.ContributorOccupation = item.ContributorOccupation;
                        objFilingTransactionDataModel.ContributorEmployer = item.ContributorEmployer;
                        objFilingTransactionDataModel.CandBallotPropReference = item.CandBallotPropReference;
                        objFilingTransactionDataModel.IEDescription = item.IEDescription;
                        objFilingTransactionDataModel.IESupported = item.IESupported;
                        objFilingTransactionDataModel.TransNumber = item.TransNumber;
                        objFilingTransactionDataModel.LoanLiablityNumber = item.LoanLiablityNumber;
                        objFilingTransactionDataModel.TransMapping = item.TransMapping;
                        lstFilingTransactionDataModel.Add(objFilingTransactionDataModel);
                    }
                    client.Close();
                    return lstFilingTransactionDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetFilingTransIE24HContributionHistoryDataDALResponse

        #region mapGetIE24HContrTransactionTypesDALResponse
        /// <summary>
        /// mapGetIE24HContrTransactionTypesDALResponse 
        /// </summary>
        /// <returns></returns>
        internal IList<TransactionTypesModel> mapGetIE24HContrTransactionTypesDALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<TransactionTypesModel> lstTransactionTypesModel = new List<TransactionTypesModel>();
                    TransactionTypesModel objTransactionTypesModel;

                    var results = client.GetIE24HContrTransactionTypes();

                    foreach (var item in results)
                    {
                        objTransactionTypesModel = new TransactionTypesModel();
                        objTransactionTypesModel.FilingSchedId = item.FilingSchedId;
                        objTransactionTypesModel.FilingSchedDesc = item.FilingSchedDesc;
                        objTransactionTypesModel.FilingSchedAbbrev = item.FilingSchedAbbrev;
                        lstTransactionTypesModel.Add(objTransactionTypesModel);
                    }
                    client.Close();
                    return lstTransactionTypesModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetIE24HContrTransactionTypesDALResponse

        #region mapAddNonItemIE24HContrFlngTransDALResponse
        /// <summary>
        /// mapAddNonItemIE24HContrFlngTransDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapAddNonItemIE24HContrFlngTransDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.PersonId = objFilingTransactionsModel.PersonId;
                    objFilingTransactionsContract.TreasId = objFilingTransactionsModel.TreasId;
                    objFilingTransactionsContract.AddrId = objFilingTransactionsModel.AddrId;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.ContributorTypeId = objFilingTransactionsModel.ContributorTypeId;
                    objFilingTransactionsContract.ContributionTypeId = objFilingTransactionsModel.ContributionTypeId;
                    objFilingTransactionsContract.LoanOtherId = objFilingTransactionsModel.LoanOtherId;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.MunicipalityID = objFilingTransactionsModel.MunicipalityID;
                    objFilingTransactionsContract.RAmend = objFilingTransactionsModel.RAmend;
                    objFilingTransactionsContract.ElectionDate = objFilingTransactionsModel.ElectionDate;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.ElectionYear = objFilingTransactionsModel.ElectionYear;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntFirstName = objFilingTransactionsModel.FlngEntFirstName;
                    objFilingTransactionsContract.FlngEntLastName = objFilingTransactionsModel.FlngEntLastName;
                    objFilingTransactionsContract.FlngEntMiddleName = objFilingTransactionsModel.FlngEntMiddleName;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.TreasurerOccupation = objFilingTransactionsModel.TreasurerOccupation;
                    objFilingTransactionsContract.TreasurerEmployer = objFilingTransactionsModel.TreasurerEmployer;
                    objFilingTransactionsContract.TreasurerStreetAddress = objFilingTransactionsModel.TreasurerStreetAddress;
                    objFilingTransactionsContract.TreasurerCity = objFilingTransactionsModel.TreasurerCity;
                    objFilingTransactionsContract.TreasurerState = objFilingTransactionsModel.TreasurerState;
                    objFilingTransactionsContract.TreasurerZip = objFilingTransactionsModel.TreasurerZip;
                    objFilingTransactionsContract.CandBallotPropReference = objFilingTransactionsModel.CandBallotPropReference;
                    objFilingTransactionsContract.ContributorOccupation = objFilingTransactionsModel.ContributorOccupation;
                    objFilingTransactionsContract.ContributorEmployer = objFilingTransactionsModel.ContributorEmployer;
                    objFilingTransactionsContract.IEDescription = objFilingTransactionsModel.IEDescription;
                    objFilingTransactionsContract.R_Supported = objFilingTransactionsModel.R_Supported;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;

                    Boolean results = client.AddNonItemIE24HContrFlngTrans(objFilingTransactionsContract);
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
        #endregion mapAddNonItemIE24HContrFlngTransDALResponse

        #region mapUpdateIE24HContrFlngTransDALResponse
        /// <summary>
        /// mapUpdateIE24HContrFlngTransDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateIE24HContrFlngTransDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.TransNumber = objFilingTransactionsModel.TransNumber;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.ContributorTypeId = objFilingTransactionsModel.ContributorTypeId;
                    objFilingTransactionsContract.ContributionTypeId = objFilingTransactionsModel.ContributionTypeId;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.TreasId = objFilingTransactionsModel.TreasId;
                    objFilingTransactionsContract.AddrId = objFilingTransactionsModel.AddrId;
                    objFilingTransactionsContract.PersonId = objFilingTransactionsModel.PersonId;
                    objFilingTransactionsContract.SubmissionDate = objFilingTransactionsModel.SubmissionDate;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntFirstName = objFilingTransactionsModel.FlngEntFirstName;
                    objFilingTransactionsContract.FlngEntMiddleName = objFilingTransactionsModel.FlngEntMiddleName;
                    objFilingTransactionsContract.FlngEntLastName = objFilingTransactionsModel.FlngEntLastName;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.TreasurerStreetAddress = objFilingTransactionsModel.TreasurerStreetAddress;
                    objFilingTransactionsContract.TreasurerCity = objFilingTransactionsModel.TreasurerCity;
                    objFilingTransactionsContract.TreasurerState = objFilingTransactionsModel.TreasurerState;
                    objFilingTransactionsContract.TreasurerZip = objFilingTransactionsModel.TreasurerZip;
                    objFilingTransactionsContract.ContributorOccupation = objFilingTransactionsModel.ContributorOccupation;
                    objFilingTransactionsContract.ContributorEmployer = objFilingTransactionsModel.ContributorEmployer;
                    objFilingTransactionsContract.IEDescription = objFilingTransactionsModel.IEDescription;
                    objFilingTransactionsContract.TreasurerOccupation = objFilingTransactionsModel.TreasurerOccupation;
                    objFilingTransactionsContract.TreasurerEmployer = objFilingTransactionsModel.TreasurerEmployer;
                    objFilingTransactionsContract.R_Supported = objFilingTransactionsModel.R_Supported;
                    objFilingTransactionsContract.CandBallotPropReference = objFilingTransactionsModel.CandBallotPropReference;
                    objFilingTransactionsContract.ModifiedBy = objFilingTransactionsModel.ModifiedBy;

                    Boolean results = client.UpdateIE24HContrFlngTrans(objFilingTransactionsContract);
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
        #endregion mapUpdateIE24HContrFlngTransDALResponse

        #region mapSubmitIE24HContrFlngTransDALResponse
        /// <summary>
        /// mapSubmitIE24HContrFlngTransDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        internal Boolean mapSubmitIE24HContrFlngTransDALResponse(String strTransNumber, String strModifiedBy)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    Boolean results = client.SubmitIE24HContrFlngTrans(strTransNumber, strModifiedBy);
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
        #endregion mapSubmitIE24HContrFlngTransDALResponse

        #region mapGetIEWeeklyExpTransactionTypesDALResponse
        /// <summary>
        /// mapGetIEWeeklyExpTransactionTypesDALResponse
        /// </summary>
        /// <returns></returns>
        internal IList<TransactionTypesModel> mapGetIEWeeklyExpTransactionTypesDALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<TransactionTypesModel> lstTransactionTypesModel = new List<TransactionTypesModel>();
                    TransactionTypesModel objTransactionTypesModel;

                    var results = client.GetIEWeeklyExpTransactionTypes();

                    foreach (var item in results)
                    {
                        objTransactionTypesModel = new TransactionTypesModel();
                        objTransactionTypesModel.FilingSchedId = item.FilingSchedId;
                        objTransactionTypesModel.FilingSchedDesc = item.FilingSchedDesc;
                        objTransactionTypesModel.FilingSchedAbbrev = item.FilingSchedAbbrev;
                        lstTransactionTypesModel.Add(objTransactionTypesModel);
                    }
                    client.Close();
                    return lstTransactionTypesModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetIEWeeklyExpTransactionTypesDALResponse

        #region mapGetFilingTransIEWeeklyExpenditureDataDALResponse
        /// <summary>
        /// mapGetFilingTransIEWeeklyExpenditureDataDALResponse
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetFilingTransIEWeeklyExpenditureDataDALResponse(FilingTransDataModel objFilingTransDataModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                    FilingTransactionDataModel objFilingTransactionDataModel;

                    FilingTransDataContract objFilingTransDataContract = new FilingTransDataContract();
                    objFilingTransDataContract.FilerId = objFilingTransDataModel.FilerId;
                    objFilingTransDataContract.ReportYearId = objFilingTransDataModel.ReportYearId;
                    objFilingTransDataContract.OfficeTypeId = objFilingTransDataModel.OfficeTypeId;
                    objFilingTransDataContract.ElectionType = objFilingTransDataModel.ElectionType;
                    objFilingTransDataContract.ElectionDateId = objFilingTransDataModel.ElectionDateId;
                    objFilingTransDataContract.FilingDate = objFilingTransDataModel.FilingDate;
                    objFilingTransDataContract.MunicipalityID = objFilingTransDataModel.MunicipalityID;

                    var results = client.GetFilingTransIEWeeklyExpenditureData(objFilingTransDataContract);

                    foreach (var item in results)
                    {
                        objFilingTransactionDataModel = new FilingTransactionDataModel();
                        objFilingTransactionDataModel.FilingTransId = item.FilingTransId;
                        objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.PaymentTypeId = item.PaymentTypeId;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.PurposeCodeId = item.PurposeCodeId;
                        objFilingTransactionDataModel.SubmissionDate = item.SubmissionDate;
                        objFilingTransactionDataModel.SchedDate = item.SchedDate;
                        objFilingTransactionDataModel.FilingSchedDesc = item.FilingSchedDesc;
                        objFilingTransactionDataModel.FilingEntityId = item.FilingEntityId;
                        objFilingTransactionDataModel.FilingEntityName = item.FilingEntityName;
                        objFilingTransactionDataModel.FilingFirstName = item.FilingFirstName;
                        objFilingTransactionDataModel.FilingMiddleName = item.FilingMiddleName;
                        objFilingTransactionDataModel.FilingLastName = item.FilingLastName;
                        objFilingTransactionDataModel.FilingStreetNumber = item.FilingStreetNumber;
                        objFilingTransactionDataModel.FilingStreetName = item.FilingStreetName;
                        objFilingTransactionDataModel.FilingCity = item.FilingCity;
                        objFilingTransactionDataModel.FilingState = item.FilingState;
                        objFilingTransactionDataModel.FilingZip = item.FilingZip;
                        objFilingTransactionDataModel.FilingCountry = item.FilingCountry;
                        objFilingTransactionDataModel.PaymentTypeDesc = item.PaymentTypeDesc;
                        objFilingTransactionDataModel.PayNumber = item.PayNumber;
                        objFilingTransactionDataModel.OriginalAmount = item.OriginalAmount;
                        objFilingTransactionDataModel.ReceiptTypeDesc = item.ReceiptTypeDesc;
                        objFilingTransactionDataModel.TransferTypeDesc = item.TransferTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.OriginalDate = item.OriginalDate;
                        objFilingTransactionDataModel.LoanerCode = item.LoanerCode;
                        objFilingTransactionDataModel.ElectionYear = item.ElectionYear;
                        objFilingTransactionDataModel.Office = item.Office;
                        objFilingTransactionDataModel.District = item.District;
                        objFilingTransactionDataModel.RLiability = item.RLiability;
                        objFilingTransactionDataModel.RSubcontractor = item.RSubcontractor;
                        objFilingTransactionDataModel.TransExplanation = item.TransExplanation;
                        objFilingTransactionDataModel.OwedAmount = item.OwedAmount;
                        objFilingTransactionDataModel.RItemized = item.RItemized;
                        objFilingTransactionDataModel.RAmend = item.RAmend;
                        objFilingTransactionDataModel.Status = item.RStatus;
                        objFilingTransactionDataModel.CountyID = item.CountyID;
                        objFilingTransactionDataModel.CountyDesc = item.CountyDesc;
                        objFilingTransactionDataModel.MunicipalityID = item.MunicipalityID;
                        objFilingTransactionDataModel.MunicipalityDesc = item.MunicipalityDesc;
                        objFilingTransactionDataModel.LoanerCodeID = item.LoanerCodeID;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.CreatedDate = item.CreatedDate;
                        objFilingTransactionDataModel.TreasurerFirstName = item.TreasurerFirstName;
                        objFilingTransactionDataModel.TreasurerLastName = item.TreasurerLastName;
                        objFilingTransactionDataModel.TreasurerMiddleName = item.TreasurerMiddleName;
                        objFilingTransactionDataModel.TreasurerOccuptaion = item.TreasurerOccuptaion;
                        objFilingTransactionDataModel.TreasurerEmployer = item.TreasurerEmployer;
                        objFilingTransactionDataModel.TreasurerStreetAddress = item.TreasurerStreetAddress;
                        objFilingTransactionDataModel.TreasurerCity = item.TreasurerCity;
                        objFilingTransactionDataModel.TreasurerState = item.TreasurerState;
                        objFilingTransactionDataModel.TreasurerZip = item.TreasurerZip;
                        objFilingTransactionDataModel.ContributorOccupation = item.ContributorOccupation;
                        objFilingTransactionDataModel.ContributorEmployer = item.ContributorEmployer;
                        objFilingTransactionDataModel.IEDescription = item.IEDescription;
                        objFilingTransactionDataModel.CandBallotPropReference = item.CandBallotPropReference;
                        objFilingTransactionDataModel.IESupported = item.IESupported;
                        objFilingTransactionDataModel.RLiability = item.RLiability;
                        objFilingTransactionDataModel.RSubcontractor = item.RSubcontractor;
                        objFilingTransactionDataModel.AddrId = item.AddrId;
                        objFilingTransactionDataModel.TreasId = item.TreasId;
                        objFilingTransactionDataModel.DateIncurredOrgAmtId = item.DateIncurredOrgAmtId;
                        objFilingTransactionDataModel.LoanLiablityNumber = item.LoanLiablityNumber;
                        objFilingTransactionDataModel.TransNumber = item.TransNumber;
                        objFilingTransactionDataModel.TransMapping = item.TransMapping;
                        objFilingTransactionDataModel.FilingsId = item.FilingsId;
                        lstFilingTransactionDataModel.Add(objFilingTransactionDataModel);
                    }
                    client.Close();
                    return lstFilingTransactionDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetFilingTransIEWeeklyExpenditureDataDALResponse

        #region mapGetFilingTransIEWeeklyExpenditureHistoryDataDALResponse
        /// <summary>
        /// mapGetFilingTransIEWeeklyExpenditureHistoryDataDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetFilingTransIEWeeklyExpenditureHistoryDataDALResponse(String strTransNumber)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                    FilingTransactionDataModel objFilingTransactionDataModel;

                    var results = client.GetFilingTransIEWeeklyExpenditureHistoryData(strTransNumber);

                    foreach (var item in results)
                    {
                        objFilingTransactionDataModel = new FilingTransactionDataModel();
                        objFilingTransactionDataModel.FilingTransId = item.FilingTransId;
                        objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                        objFilingTransactionDataModel.PurposeCodeId = item.PurposeCodeId;
                        objFilingTransactionDataModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.PaymentTypeId = item.PaymentTypeId;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.SubmissionDate = item.SubmissionDate;
                        objFilingTransactionDataModel.SchedDate = item.SchedDate;
                        objFilingTransactionDataModel.FilingSchedDesc = item.FilingSchedDesc;
                        objFilingTransactionDataModel.FilingEntityId = item.FilingEntityId;
                        objFilingTransactionDataModel.FilingEntityName = item.FilingEntityName;
                        objFilingTransactionDataModel.FilingFirstName = item.FilingFirstName;
                        objFilingTransactionDataModel.FilingMiddleName = item.FilingMiddleName;
                        objFilingTransactionDataModel.FilingLastName = item.FilingLastName;
                        objFilingTransactionDataModel.FilingStreetNumber = item.FilingStreetNumber;
                        objFilingTransactionDataModel.FilingStreetName = item.FilingStreetName;
                        objFilingTransactionDataModel.FilingCity = item.FilingCity;
                        objFilingTransactionDataModel.FilingState = item.FilingState;
                        objFilingTransactionDataModel.FilingZip = item.FilingZip;
                        objFilingTransactionDataModel.FilingCountry = item.FilingCountry;
                        objFilingTransactionDataModel.PaymentTypeDesc = item.PaymentTypeDesc;
                        objFilingTransactionDataModel.PayNumber = item.PayNumber;
                        objFilingTransactionDataModel.OriginalAmount = item.OriginalAmount;
                        objFilingTransactionDataModel.ReceiptTypeDesc = item.ReceiptTypeDesc;
                        objFilingTransactionDataModel.TransferTypeDesc = item.TransferTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.OriginalDate = item.OriginalDate;
                        objFilingTransactionDataModel.LoanerCode = item.LoanerCode;
                        objFilingTransactionDataModel.ElectionYear = item.ElectionYear;
                        objFilingTransactionDataModel.Office = item.Office;
                        objFilingTransactionDataModel.District = item.District;
                        objFilingTransactionDataModel.RLiability = item.RLiability;
                        objFilingTransactionDataModel.RSubcontractor = item.RSubcontractor;
                        objFilingTransactionDataModel.TransExplanation = item.TransExplanation;
                        objFilingTransactionDataModel.OwedAmount = item.OwedAmount;
                        objFilingTransactionDataModel.RItemized = item.RItemized;
                        objFilingTransactionDataModel.RAmend = item.RAmend;
                        objFilingTransactionDataModel.Status = item.RStatus;
                        objFilingTransactionDataModel.CountyID = item.CountyID;
                        objFilingTransactionDataModel.CountyDesc = item.CountyDesc;
                        objFilingTransactionDataModel.MunicipalityID = item.MunicipalityID;
                        objFilingTransactionDataModel.MunicipalityDesc = item.MunicipalityDesc;
                        objFilingTransactionDataModel.LoanerCodeID = item.LoanerCodeID;
                        objFilingTransactionDataModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.CreatedDate = item.CreatedDate;
                        objFilingTransactionDataModel.TreasurerFirstName = item.TreasurerFirstName;
                        objFilingTransactionDataModel.TreasurerLastName = item.TreasurerLastName;
                        objFilingTransactionDataModel.TreasurerMiddleName = item.TreasurerMiddleName;
                        objFilingTransactionDataModel.TreasurerOccuptaion = item.TreasurerOccuptaion;
                        objFilingTransactionDataModel.TreasurerEmployer = item.TreasurerEmployer;
                        objFilingTransactionDataModel.TreasurerStreetAddress = item.TreasurerStreetAddress;
                        objFilingTransactionDataModel.TreasurerCity = item.TreasurerCity;
                        objFilingTransactionDataModel.TreasurerState = item.TreasurerState;
                        objFilingTransactionDataModel.TreasurerZip = item.TreasurerZip;
                        objFilingTransactionDataModel.ContributorOccupation = item.ContributorOccupation;
                        objFilingTransactionDataModel.ContributorEmployer = item.ContributorEmployer;
                        objFilingTransactionDataModel.CandBallotPropReference = item.CandBallotPropReference;
                        objFilingTransactionDataModel.IEDescription = item.IEDescription;
                        objFilingTransactionDataModel.IESupported = item.IESupported;
                        objFilingTransactionDataModel.LoanLiablityNumber = item.LoanLiablityNumber;
                        objFilingTransactionDataModel.TransNumber = item.TransNumber;
                        objFilingTransactionDataModel.TransMapping = item.TransMapping;
                        lstFilingTransactionDataModel.Add(objFilingTransactionDataModel);
                    }
                    client.Close();
                    return lstFilingTransactionDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetFilingTransIEWeeklyExpenditureHistoryDataDALResponse

        #region mapAddNonItemIEWeeklyExpFlngTransDALResponse
        /// <summary>
        /// mapAddNonItemIEWeeklyExpFlngTransDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapAddNonItemIEWeeklyExpFlngTransDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.PersonId = objFilingTransactionsModel.PersonId;
                    objFilingTransactionsContract.TreasId = objFilingTransactionsModel.TreasId;
                    objFilingTransactionsContract.AddrId = objFilingTransactionsModel.AddrId;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.PurposeCodeId = objFilingTransactionsModel.PurposeCodeId;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.OwedAmt = objFilingTransactionsModel.OwedAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.MunicipalityID = objFilingTransactionsModel.MunicipalityID;
                    objFilingTransactionsContract.RAmend = objFilingTransactionsModel.RAmend;
                    objFilingTransactionsContract.ElectionDate = objFilingTransactionsModel.ElectionDate;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.ElectionYear = objFilingTransactionsModel.ElectionYear;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.TreasurerOccupation = objFilingTransactionsModel.TreasurerOccupation;
                    objFilingTransactionsContract.TreasurerEmployer = objFilingTransactionsModel.TreasurerEmployer;
                    objFilingTransactionsContract.TreasurerStreetAddress = objFilingTransactionsModel.TreasurerStreetAddress;
                    objFilingTransactionsContract.TreasurerCity = objFilingTransactionsModel.TreasurerCity;
                    objFilingTransactionsContract.TreasurerState = objFilingTransactionsModel.TreasurerState;
                    objFilingTransactionsContract.TreasurerZip = objFilingTransactionsModel.TreasurerZip;
                    objFilingTransactionsContract.CandBallotPropReference = objFilingTransactionsModel.CandBallotPropReference;
                    objFilingTransactionsContract.IEDescription = objFilingTransactionsModel.IEDescription;
                    objFilingTransactionsContract.R_Supported = objFilingTransactionsModel.R_Supported;
                    objFilingTransactionsContract.RLiability = objFilingTransactionsModel.RLiability;
                    objFilingTransactionsContract.RSubcontractor = objFilingTransactionsModel.RSubcontractor;
                    objFilingTransactionsContract.DateIncurredOrgAmtId = objFilingTransactionsModel.DateIncurredOrgAmtId;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;

                    Boolean returnValue = client.AddNonItemIEWeeklyExpFlngTrans(objFilingTransactionsContract);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapAddNonItemIEWeeklyExpFlngTransDALResponse

        #region mapUpdateIEWeeklyExpenditureFlngTransDALResponse
        /// <summary>
        /// mapUpdateIEWeeklyExpenditureFlngTransDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateIEWeeklyExpenditureFlngTransDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.TransNumber = objFilingTransactionsModel.TransNumber;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.TreasId = objFilingTransactionsModel.TreasId;
                    objFilingTransactionsContract.AddrId = objFilingTransactionsModel.AddrId;
                    objFilingTransactionsContract.PersonId = objFilingTransactionsModel.PersonId;
                    objFilingTransactionsContract.SubmissionDate = objFilingTransactionsModel.SubmissionDate;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.PurposeCodeId = objFilingTransactionsModel.PurposeCodeId;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.OwedAmt = objFilingTransactionsModel.OwedAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.TreasurerStreetAddress = objFilingTransactionsModel.TreasurerStreetAddress;
                    objFilingTransactionsContract.TreasurerCity = objFilingTransactionsModel.TreasurerCity;
                    objFilingTransactionsContract.TreasurerState = objFilingTransactionsModel.TreasurerState;
                    objFilingTransactionsContract.TreasurerZip = objFilingTransactionsModel.TreasurerZip;
                    objFilingTransactionsContract.IEDescription = objFilingTransactionsModel.IEDescription;
                    objFilingTransactionsContract.TreasurerOccupation = objFilingTransactionsModel.TreasurerOccupation;
                    objFilingTransactionsContract.TreasurerEmployer = objFilingTransactionsModel.TreasurerEmployer;
                    objFilingTransactionsContract.R_Supported = objFilingTransactionsModel.R_Supported;
                    objFilingTransactionsContract.CandBallotPropReference = objFilingTransactionsModel.CandBallotPropReference;
                    objFilingTransactionsContract.RSubcontractor = objFilingTransactionsModel.RSubcontractor;
                    objFilingTransactionsContract.RLiability = objFilingTransactionsModel.RLiability;
                    objFilingTransactionsContract.DateIncurredOrgAmtId = objFilingTransactionsModel.DateIncurredOrgAmtId;
                    objFilingTransactionsContract.ModifiedBy = objFilingTransactionsModel.ModifiedBy;

                    Boolean returnValue = client.UpdateIEWeeklyExpenditureFlngTrans(objFilingTransactionsContract);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }

            }
            
            
        }
        #endregion mapUpdateIEWeeklyExpenditureFlngTransDALResponse

        #region mapGetNonItemIEDateIncrdLiabUpdateDataDALResponse
        /// <summary>
        /// mapGetNonItemIEDateIncrdLiabUpdateDataDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<DateIncurredModel> mapGetNonItemIEDateIncrdLiabUpdateDataDALResponse(String strTransNumber)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<DateIncurredModel> lstDateIncurredModel = new List<DateIncurredModel>();
                    DateIncurredModel objDateIncurredModel;

                    var results = client.GetNonItemIEDateIncrdLiabUpdateData(strTransNumber);

                    foreach (var item in results)
                    {
                        objDateIncurredModel = new DateIncurredModel();
                        objDateIncurredModel.DateIncurredId = item.DateIncurredId;
                        objDateIncurredModel.DateIncurredValue = item.DateIncurredValue;
                        objDateIncurredModel.AmountLiability = item.AmountLiability;
                        lstDateIncurredModel.Add(objDateIncurredModel);
                    }
                    client.Close();
                    return lstDateIncurredModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetNonItemIEDateIncrdLiabUpdateDataDALResponse

        #region mapGetNonItemIEPurposeCodesDALResponse
        /// <summary>
        /// mapGetNonItemIEPurposeCodesDALResponse
        /// </summary>
        /// <returns></returns>
        internal IList<PurposeCodeModel> mapGetNonItemIEPurposeCodesDALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();
                    PurposeCodeModel objPurposeCodeModel;

                    var results = client.GetNonItemIEPurposeCodes();

                    foreach (var item in results)
                    {
                        objPurposeCodeModel = new PurposeCodeModel();
                        objPurposeCodeModel.PurposeCodeId = item.PurposeCodeId;
                        objPurposeCodeModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objPurposeCodeModel.PurposeCodeAbbrev = item.PurposeCodeAbbrev;
                        lstPurposeCodeModel.Add(objPurposeCodeModel);
                    }
                    client.Close();
                    return lstPurposeCodeModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetNonItemIEPurposeCodesDALResponse

        #region mapGetNonItemIEPurposeCodesSubContrDALResponse
        /// <summary>
        /// mapGetNonItemIEPurposeCodesSubContrDALResponse
        /// </summary>
        /// <returns></returns>
        internal IList<PurposeCodeModel> mapGetNonItemIEPurposeCodesSubContrDALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();
                    PurposeCodeModel objPurposeCodeModel;

                    var results = client.GetNonItemIEPurposeCodesSubContr();

                    foreach (var item in results)
                    {
                        objPurposeCodeModel = new PurposeCodeModel();
                        objPurposeCodeModel.PurposeCodeId = item.PurposeCodeId;
                        objPurposeCodeModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objPurposeCodeModel.PurposeCodeAbbrev = item.PurposeCodeAbbrev;
                        lstPurposeCodeModel.Add(objPurposeCodeModel);
                    }
                    client.Close();
                    return lstPurposeCodeModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
           
            
        }
        #endregion mapGetNonItemIEPurposeCodesSubContrDALResponse

        #region mapGetFilingTransIE24HourExpenditureDataDALResponse
        /// <summary>
        /// mapGetFilingTransIE24HourExpenditureDataDALResponse
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetFilingTransIE24HourExpenditureDataDALResponse(FilingTransDataModel objFilingTransDataModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                    FilingTransactionDataModel objFilingTransactionDataModel;

                    FilingTransDataContract objFilingTransDataContract = new FilingTransDataContract();
                    objFilingTransDataContract.FilerId = objFilingTransDataModel.FilerId;
                    objFilingTransDataContract.ReportYearId = objFilingTransDataModel.ReportYearId;
                    objFilingTransDataContract.OfficeTypeId = objFilingTransDataModel.OfficeTypeId;
                    objFilingTransDataContract.ElectionType = objFilingTransDataModel.ElectionType;
                    objFilingTransDataContract.ElectionDateId = objFilingTransDataModel.ElectionDateId;
                    objFilingTransDataContract.FilingDate = objFilingTransDataModel.FilingDate;

                    var results = client.GetFilingTransIE24HourExpenditureData(objFilingTransDataContract);

                    foreach (var item in results)
                    {
                        objFilingTransactionDataModel = new FilingTransactionDataModel();
                        objFilingTransactionDataModel.FilingTransId = item.FilingTransId;
                        objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.PaymentTypeId = item.PaymentTypeId;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.PurposeCodeId = item.PurposeCodeId;
                        objFilingTransactionDataModel.SubmissionDate = item.SubmissionDate;
                        objFilingTransactionDataModel.SchedDate = item.SchedDate;
                        objFilingTransactionDataModel.FilingSchedDesc = item.FilingSchedDesc;
                        objFilingTransactionDataModel.FilingEntityId = item.FilingEntityId;
                        objFilingTransactionDataModel.FilingEntityName = item.FilingEntityName;
                        objFilingTransactionDataModel.FilingFirstName = item.FilingFirstName;
                        objFilingTransactionDataModel.FilingMiddleName = item.FilingMiddleName;
                        objFilingTransactionDataModel.FilingLastName = item.FilingLastName;
                        objFilingTransactionDataModel.FilingStreetNumber = item.FilingStreetNumber;
                        objFilingTransactionDataModel.FilingStreetName = item.FilingStreetName;
                        objFilingTransactionDataModel.FilingCity = item.FilingCity;
                        objFilingTransactionDataModel.FilingState = item.FilingState;
                        objFilingTransactionDataModel.FilingZip = item.FilingZip;
                        objFilingTransactionDataModel.FilingCountry = item.FilingCountry;
                        objFilingTransactionDataModel.PaymentTypeDesc = item.PaymentTypeDesc;
                        objFilingTransactionDataModel.PayNumber = item.PayNumber;
                        objFilingTransactionDataModel.OriginalAmount = item.OriginalAmount;
                        objFilingTransactionDataModel.ReceiptTypeDesc = item.ReceiptTypeDesc;
                        objFilingTransactionDataModel.TransferTypeDesc = item.TransferTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.OriginalDate = item.OriginalDate;
                        objFilingTransactionDataModel.LoanerCode = item.LoanerCode;
                        objFilingTransactionDataModel.ElectionYear = item.ElectionYear;
                        objFilingTransactionDataModel.Office = item.Office;
                        objFilingTransactionDataModel.District = item.District;
                        objFilingTransactionDataModel.RLiability = item.RLiability;
                        objFilingTransactionDataModel.RSubcontractor = item.RSubcontractor;
                        objFilingTransactionDataModel.TransExplanation = item.TransExplanation;
                        objFilingTransactionDataModel.OwedAmount = item.OwedAmount;
                        objFilingTransactionDataModel.RItemized = item.RItemized;
                        objFilingTransactionDataModel.RAmend = item.RAmend;
                        objFilingTransactionDataModel.Status = item.RStatus;
                        objFilingTransactionDataModel.CountyID = item.CountyID;
                        objFilingTransactionDataModel.CountyDesc = item.CountyDesc;
                        objFilingTransactionDataModel.MunicipalityID = item.MunicipalityID;
                        objFilingTransactionDataModel.MunicipalityDesc = item.MunicipalityDesc;
                        objFilingTransactionDataModel.LoanerCodeID = item.LoanerCodeID;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.CreatedDate = item.CreatedDate;
                        objFilingTransactionDataModel.TreasurerFirstName = item.TreasurerFirstName;
                        objFilingTransactionDataModel.TreasurerLastName = item.TreasurerLastName;
                        objFilingTransactionDataModel.TreasurerMiddleName = item.TreasurerMiddleName;
                        objFilingTransactionDataModel.TreasurerOccuptaion = item.TreasurerOccuptaion;
                        objFilingTransactionDataModel.TreasurerEmployer = item.TreasurerEmployer;
                        objFilingTransactionDataModel.TreasurerStreetAddress = item.TreasurerStreetAddress;
                        objFilingTransactionDataModel.TreasurerCity = item.TreasurerCity;
                        objFilingTransactionDataModel.TreasurerState = item.TreasurerState;
                        objFilingTransactionDataModel.TreasurerZip = item.TreasurerZip;
                        objFilingTransactionDataModel.ContributorOccupation = item.ContributorOccupation;
                        objFilingTransactionDataModel.ContributorEmployer = item.ContributorEmployer;
                        objFilingTransactionDataModel.IEDescription = item.IEDescription;
                        objFilingTransactionDataModel.CandBallotPropReference = item.CandBallotPropReference;
                        objFilingTransactionDataModel.IESupported = item.IESupported;
                        objFilingTransactionDataModel.RLiability = item.RLiability;
                        objFilingTransactionDataModel.RSubcontractor = item.RSubcontractor;
                        objFilingTransactionDataModel.AddrId = item.AddrId;
                        objFilingTransactionDataModel.TreasId = item.TreasId;
                        objFilingTransactionDataModel.DateIncurredOrgAmtId = item.DateIncurredOrgAmtId;
                        objFilingTransactionDataModel.LoanLiablityNumber = item.LoanLiablityNumber;
                        objFilingTransactionDataModel.TransNumber = item.TransNumber;
                        objFilingTransactionDataModel.TransMapping = item.TransMapping;
                        lstFilingTransactionDataModel.Add(objFilingTransactionDataModel);
                    }
                    client.Close();
                    return lstFilingTransactionDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetFilingTransIE24HourExpenditureDataDALResponse

        #region mapGetFilingTransIE24HourPIDAExpenditureDataDALResponse
        /// <summary>
        /// mapGetFilingTransIE24HourPIDAExpenditureDataDALResponse
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetFilingTransIE24HourPIDAExpenditureDataDALResponse(FilingTransDataModel objFilingTransDataModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                    FilingTransactionDataModel objFilingTransactionDataModel;

                    FilingTransDataContract objFilingTransDataContract = new FilingTransDataContract();
                    objFilingTransDataContract.FilerId = objFilingTransDataModel.FilerId;
                    objFilingTransDataContract.ReportYearId = objFilingTransDataModel.ReportYearId;
                    objFilingTransDataContract.OfficeTypeId = objFilingTransDataModel.OfficeTypeId;
                    objFilingTransDataContract.ElectionType = objFilingTransDataModel.ElectionType;
                    objFilingTransDataContract.ElectionDateId = objFilingTransDataModel.ElectionDateId;
                    objFilingTransDataContract.FilingDate = objFilingTransDataModel.FilingDate;

                    var results = client.GetFilingTransIE24HourPIDAExpenditureData(objFilingTransDataContract);

                    foreach (var item in results)
                    {
                        objFilingTransactionDataModel = new FilingTransactionDataModel();
                        objFilingTransactionDataModel.FilingTransId = item.FilingTransId;
                        objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.PaymentTypeId = item.PaymentTypeId;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.PurposeCodeId = item.PurposeCodeId;
                        objFilingTransactionDataModel.SubmissionDate = item.SubmissionDate;
                        objFilingTransactionDataModel.SchedDate = item.SchedDate;
                        objFilingTransactionDataModel.FilingSchedDesc = item.FilingSchedDesc;
                        objFilingTransactionDataModel.FilingEntityId = item.FilingEntityId;
                        objFilingTransactionDataModel.FilingEntityName = item.FilingEntityName;
                        objFilingTransactionDataModel.FilingFirstName = item.FilingFirstName;
                        objFilingTransactionDataModel.FilingMiddleName = item.FilingMiddleName;
                        objFilingTransactionDataModel.FilingLastName = item.FilingLastName;
                        objFilingTransactionDataModel.FilingStreetNumber = item.FilingStreetNumber;
                        objFilingTransactionDataModel.FilingStreetName = item.FilingStreetName;
                        objFilingTransactionDataModel.FilingCity = item.FilingCity;
                        objFilingTransactionDataModel.FilingState = item.FilingState;
                        objFilingTransactionDataModel.FilingZip = item.FilingZip;
                        objFilingTransactionDataModel.FilingCountry = item.FilingCountry;
                        objFilingTransactionDataModel.PaymentTypeDesc = item.PaymentTypeDesc;
                        objFilingTransactionDataModel.PayNumber = item.PayNumber;
                        objFilingTransactionDataModel.OriginalAmount = item.OriginalAmount;
                        objFilingTransactionDataModel.ReceiptTypeDesc = item.ReceiptTypeDesc;
                        objFilingTransactionDataModel.TransferTypeDesc = item.TransferTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.OriginalDate = item.OriginalDate;
                        objFilingTransactionDataModel.LoanerCode = item.LoanerCode;
                        objFilingTransactionDataModel.ElectionYear = item.ElectionYear;
                        objFilingTransactionDataModel.Office = item.Office;
                        objFilingTransactionDataModel.District = item.District;
                        objFilingTransactionDataModel.RLiability = item.RLiability;
                        objFilingTransactionDataModel.RSubcontractor = item.RSubcontractor;
                        objFilingTransactionDataModel.TransExplanation = item.TransExplanation;
                        objFilingTransactionDataModel.OwedAmount = item.OwedAmount;
                        objFilingTransactionDataModel.RItemized = item.RItemized;
                        objFilingTransactionDataModel.RAmend = item.RAmend;
                        objFilingTransactionDataModel.Status = item.RStatus;
                        objFilingTransactionDataModel.CountyID = item.CountyID;
                        objFilingTransactionDataModel.CountyDesc = item.CountyDesc;
                        objFilingTransactionDataModel.MunicipalityID = item.MunicipalityID;
                        objFilingTransactionDataModel.MunicipalityDesc = item.MunicipalityDesc;
                        objFilingTransactionDataModel.LoanerCodeID = item.LoanerCodeID;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.CreatedDate = item.CreatedDate;
                        objFilingTransactionDataModel.TreasurerFirstName = item.TreasurerFirstName;
                        objFilingTransactionDataModel.TreasurerLastName = item.TreasurerLastName;
                        objFilingTransactionDataModel.TreasurerMiddleName = item.TreasurerMiddleName;
                        objFilingTransactionDataModel.TreasurerOccuptaion = item.TreasurerOccuptaion;
                        objFilingTransactionDataModel.TreasurerEmployer = item.TreasurerEmployer;
                        objFilingTransactionDataModel.TreasurerStreetAddress = item.TreasurerStreetAddress;
                        objFilingTransactionDataModel.TreasurerCity = item.TreasurerCity;
                        objFilingTransactionDataModel.TreasurerState = item.TreasurerState;
                        objFilingTransactionDataModel.TreasurerZip = item.TreasurerZip;
                        objFilingTransactionDataModel.ContributorOccupation = item.ContributorOccupation;
                        objFilingTransactionDataModel.ContributorEmployer = item.ContributorEmployer;
                        objFilingTransactionDataModel.IEDescription = item.IEDescription;
                        objFilingTransactionDataModel.CandBallotPropReference = item.CandBallotPropReference;
                        objFilingTransactionDataModel.IESupported = item.IESupported;
                        objFilingTransactionDataModel.RLiability = item.RLiability;
                        objFilingTransactionDataModel.RSubcontractor = item.RSubcontractor;
                        objFilingTransactionDataModel.AddrId = item.AddrId;
                        objFilingTransactionDataModel.TreasId = item.TreasId;
                        objFilingTransactionDataModel.DateIncurredOrgAmtId = item.DateIncurredOrgAmtId;
                        objFilingTransactionDataModel.LoanLiablityNumber = item.LoanLiablityNumber;
                        objFilingTransactionDataModel.TransNumber = item.TransNumber;
                        objFilingTransactionDataModel.TransMapping = item.TransMapping;
                        lstFilingTransactionDataModel.Add(objFilingTransactionDataModel);
                    }
                    client.Close();
                    return lstFilingTransactionDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetFilingTransIE24HourPIDAExpenditureDataDALResponse

        #region mapAddNonItemIE24HourExpFlngTransDALResponse
        /// <summary>
        /// mapAddNonItemIE24HourExpFlngTransDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapAddNonItemIE24HourExpFlngTransDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.PersonId = objFilingTransactionsModel.PersonId;
                    objFilingTransactionsContract.TreasId = objFilingTransactionsModel.TreasId;
                    objFilingTransactionsContract.AddrId = objFilingTransactionsModel.AddrId;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.PurposeCodeId = objFilingTransactionsModel.PurposeCodeId;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.OwedAmt = objFilingTransactionsModel.OwedAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.MunicipalityID = objFilingTransactionsModel.MunicipalityID;
                    objFilingTransactionsContract.RAmend = objFilingTransactionsModel.RAmend;
                    objFilingTransactionsContract.ElectionDate = objFilingTransactionsModel.ElectionDate;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.ElectionYear = objFilingTransactionsModel.ElectionYear;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.TreasurerOccupation = objFilingTransactionsModel.TreasurerOccupation;
                    objFilingTransactionsContract.TreasurerEmployer = objFilingTransactionsModel.TreasurerEmployer;
                    objFilingTransactionsContract.TreasurerStreetAddress = objFilingTransactionsModel.TreasurerStreetAddress;
                    objFilingTransactionsContract.TreasurerCity = objFilingTransactionsModel.TreasurerCity;
                    objFilingTransactionsContract.TreasurerState = objFilingTransactionsModel.TreasurerState;
                    objFilingTransactionsContract.TreasurerZip = objFilingTransactionsModel.TreasurerZip;
                    objFilingTransactionsContract.CandBallotPropReference = objFilingTransactionsModel.CandBallotPropReference;
                    objFilingTransactionsContract.IEDescription = objFilingTransactionsModel.IEDescription;
                    objFilingTransactionsContract.R_Supported = objFilingTransactionsModel.R_Supported;
                    objFilingTransactionsContract.RLiability = objFilingTransactionsModel.RLiability;
                    objFilingTransactionsContract.RSubcontractor = objFilingTransactionsModel.RSubcontractor;
                    objFilingTransactionsContract.DateIncurredOrgAmtId = objFilingTransactionsModel.DateIncurredOrgAmtId;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;

                    Boolean returnValue = client.AddNonItemIE24HourExpFlngTrans(objFilingTransactionsContract);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapAddNonItemIE24HourExpFlngTransDALResponse

        #region mapAddNonItemIE24HourPIDAExpFlngTransDALResponse
        /// <summary>
        /// mapAddNonItemIE24HourPIDAExpFlngTransDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapAddNonItemIE24HourPIDAExpFlngTransDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.PersonId = objFilingTransactionsModel.PersonId;
                    objFilingTransactionsContract.TreasId = objFilingTransactionsModel.TreasId;
                    objFilingTransactionsContract.AddrId = objFilingTransactionsModel.AddrId;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.PurposeCodeId = objFilingTransactionsModel.PurposeCodeId;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.OwedAmt = objFilingTransactionsModel.OwedAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.MunicipalityID = objFilingTransactionsModel.MunicipalityID;
                    objFilingTransactionsContract.RAmend = objFilingTransactionsModel.RAmend;
                    objFilingTransactionsContract.ElectionDate = objFilingTransactionsModel.ElectionDate;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.ElectionYear = objFilingTransactionsModel.ElectionYear;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.TreasurerOccupation = objFilingTransactionsModel.TreasurerOccupation;
                    objFilingTransactionsContract.TreasurerEmployer = objFilingTransactionsModel.TreasurerEmployer;
                    objFilingTransactionsContract.TreasurerStreetAddress = objFilingTransactionsModel.TreasurerStreetAddress;
                    objFilingTransactionsContract.TreasurerCity = objFilingTransactionsModel.TreasurerCity;
                    objFilingTransactionsContract.TreasurerState = objFilingTransactionsModel.TreasurerState;
                    objFilingTransactionsContract.TreasurerZip = objFilingTransactionsModel.TreasurerZip;
                    objFilingTransactionsContract.CandBallotPropReference = objFilingTransactionsModel.CandBallotPropReference;
                    objFilingTransactionsContract.IEDescription = objFilingTransactionsModel.IEDescription;
                    objFilingTransactionsContract.R_Supported = objFilingTransactionsModel.R_Supported;
                    objFilingTransactionsContract.RLiability = objFilingTransactionsModel.RLiability;
                    objFilingTransactionsContract.RSubcontractor = objFilingTransactionsModel.RSubcontractor;
                    objFilingTransactionsContract.DateIncurredOrgAmtId = objFilingTransactionsModel.DateIncurredOrgAmtId;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;

                    Boolean returnValue = client.AddNonItemIE24HourPIDAExpFlngTrans(objFilingTransactionsContract);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapAddNonItemIE24HourPIDAExpFlngTransDALResponse

        #region mapGetFilingTransIEWeeklyPIDAExpenditureDataDALResponse
        /// <summary>
        /// mapGetFilingTransIEWeeklyPIDAExpenditureDataDALResponse
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns> 
        internal IList<FilingTransactionDataModel> mapGetFilingTransIEWeeklyPIDAExpenditureDataDALResponse(FilingTransDataModel objFilingTransDataModel) 
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                    FilingTransactionDataModel objFilingTransactionDataModel;

                    FilingTransDataContract objFilingTransDataContract = new FilingTransDataContract();
                    objFilingTransDataContract.FilerId = objFilingTransDataModel.FilerId;
                    objFilingTransDataContract.ReportYearId = objFilingTransDataModel.ReportYearId;
                    objFilingTransDataContract.OfficeTypeId = objFilingTransDataModel.OfficeTypeId;
                    objFilingTransDataContract.ElectionType = objFilingTransDataModel.ElectionType;
                    objFilingTransDataContract.ElectionDateId = objFilingTransDataModel.ElectionDateId;
                    objFilingTransDataContract.FilingDate = objFilingTransDataModel.FilingDate;
                    objFilingTransDataContract.MunicipalityID = objFilingTransDataModel.MunicipalityID;

                    var results = client.GetFilingTransIEWeeklyPIDAExpenditureData(objFilingTransDataContract);

                    foreach (var item in results)
                    {
                        objFilingTransactionDataModel = new FilingTransactionDataModel();
                        objFilingTransactionDataModel.FilingTransId = item.FilingTransId;
                        objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.PaymentTypeId = item.PaymentTypeId;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.PurposeCodeId = item.PurposeCodeId;
                        objFilingTransactionDataModel.SubmissionDate = item.SubmissionDate;
                        objFilingTransactionDataModel.SchedDate = item.SchedDate;
                        objFilingTransactionDataModel.FilingSchedDesc = item.FilingSchedDesc;
                        objFilingTransactionDataModel.FilingEntityId = item.FilingEntityId;
                        objFilingTransactionDataModel.FilingEntityName = item.FilingEntityName;
                        objFilingTransactionDataModel.FilingFirstName = item.FilingFirstName;
                        objFilingTransactionDataModel.FilingMiddleName = item.FilingMiddleName;
                        objFilingTransactionDataModel.FilingLastName = item.FilingLastName;
                        objFilingTransactionDataModel.FilingStreetNumber = item.FilingStreetNumber;
                        objFilingTransactionDataModel.FilingStreetName = item.FilingStreetName;
                        objFilingTransactionDataModel.FilingCity = item.FilingCity;
                        objFilingTransactionDataModel.FilingState = item.FilingState;
                        objFilingTransactionDataModel.FilingZip = item.FilingZip;
                        objFilingTransactionDataModel.FilingCountry = item.FilingCountry;
                        objFilingTransactionDataModel.PaymentTypeDesc = item.PaymentTypeDesc;
                        objFilingTransactionDataModel.PayNumber = item.PayNumber;
                        objFilingTransactionDataModel.OriginalAmount = item.OriginalAmount;
                        objFilingTransactionDataModel.ReceiptTypeDesc = item.ReceiptTypeDesc;
                        objFilingTransactionDataModel.TransferTypeDesc = item.TransferTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.OriginalDate = item.OriginalDate;
                        objFilingTransactionDataModel.LoanerCode = item.LoanerCode;
                        objFilingTransactionDataModel.ElectionYear = item.ElectionYear;
                        objFilingTransactionDataModel.Office = item.Office;
                        objFilingTransactionDataModel.District = item.District;
                        objFilingTransactionDataModel.RLiability = item.RLiability;
                        objFilingTransactionDataModel.RSubcontractor = item.RSubcontractor;
                        objFilingTransactionDataModel.TransExplanation = item.TransExplanation;
                        objFilingTransactionDataModel.OwedAmount = item.OwedAmount;
                        objFilingTransactionDataModel.RItemized = item.RItemized;
                        objFilingTransactionDataModel.RAmend = item.RAmend;
                        objFilingTransactionDataModel.Status = item.RStatus;
                        objFilingTransactionDataModel.CountyID = item.CountyID;
                        objFilingTransactionDataModel.CountyDesc = item.CountyDesc;
                        objFilingTransactionDataModel.MunicipalityID = item.MunicipalityID;
                        objFilingTransactionDataModel.MunicipalityDesc = item.MunicipalityDesc;
                        objFilingTransactionDataModel.LoanerCodeID = item.LoanerCodeID;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.CreatedDate = item.CreatedDate;
                        objFilingTransactionDataModel.TreasurerFirstName = item.TreasurerFirstName;
                        objFilingTransactionDataModel.TreasurerLastName = item.TreasurerLastName;
                        objFilingTransactionDataModel.TreasurerMiddleName = item.TreasurerMiddleName;
                        objFilingTransactionDataModel.TreasurerOccuptaion = item.TreasurerOccuptaion;
                        objFilingTransactionDataModel.TreasurerEmployer = item.TreasurerEmployer;
                        objFilingTransactionDataModel.TreasurerStreetAddress = item.TreasurerStreetAddress;
                        objFilingTransactionDataModel.TreasurerCity = item.TreasurerCity;
                        objFilingTransactionDataModel.TreasurerState = item.TreasurerState;
                        objFilingTransactionDataModel.TreasurerZip = item.TreasurerZip;
                        objFilingTransactionDataModel.ContributorOccupation = item.ContributorOccupation;
                        objFilingTransactionDataModel.ContributorEmployer = item.ContributorEmployer;
                        objFilingTransactionDataModel.IEDescription = item.IEDescription;
                        objFilingTransactionDataModel.CandBallotPropReference = item.CandBallotPropReference;
                        objFilingTransactionDataModel.IESupported = item.IESupported;
                        objFilingTransactionDataModel.RLiability = item.RLiability;
                        objFilingTransactionDataModel.RSubcontractor = item.RSubcontractor;
                        objFilingTransactionDataModel.AddrId = item.AddrId;
                        objFilingTransactionDataModel.TreasId = item.TreasId;
                        objFilingTransactionDataModel.DateIncurredOrgAmtId = item.DateIncurredOrgAmtId;
                        objFilingTransactionDataModel.LoanLiablityNumber = item.LoanLiablityNumber;
                        objFilingTransactionDataModel.TransNumber = item.TransNumber;
                        objFilingTransactionDataModel.TransMapping = item.TransMapping;

                        lstFilingTransactionDataModel.Add(objFilingTransactionDataModel);
                    }
                    client.Close();
                    return lstFilingTransactionDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetFilingTransIEWeeklyPIDAExpenditureDataDALResponse

        #region mapAddNonItemIEWeeklyPIDAExpFlngTransDALResponse
        /// <summary>
        /// mapAddNonItemIEWeeklyPIDAExpFlngTransDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapAddNonItemIEWeeklyPIDAExpFlngTransDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.PersonId = objFilingTransactionsModel.PersonId;
                    objFilingTransactionsContract.TreasId = objFilingTransactionsModel.TreasId;
                    objFilingTransactionsContract.AddrId = objFilingTransactionsModel.AddrId;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.PurposeCodeId = objFilingTransactionsModel.PurposeCodeId;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.OwedAmt = objFilingTransactionsModel.OwedAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.MunicipalityID = objFilingTransactionsModel.MunicipalityID;
                    objFilingTransactionsContract.RAmend = objFilingTransactionsModel.RAmend;
                    objFilingTransactionsContract.ElectionDate = objFilingTransactionsModel.ElectionDate;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.ElectionYear = objFilingTransactionsModel.ElectionYear;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.TreasurerOccupation = objFilingTransactionsModel.TreasurerOccupation;
                    objFilingTransactionsContract.TreasurerEmployer = objFilingTransactionsModel.TreasurerEmployer;
                    objFilingTransactionsContract.TreasurerStreetAddress = objFilingTransactionsModel.TreasurerStreetAddress;
                    objFilingTransactionsContract.TreasurerCity = objFilingTransactionsModel.TreasurerCity;
                    objFilingTransactionsContract.TreasurerState = objFilingTransactionsModel.TreasurerState;
                    objFilingTransactionsContract.TreasurerZip = objFilingTransactionsModel.TreasurerZip;
                    objFilingTransactionsContract.CandBallotPropReference = objFilingTransactionsModel.CandBallotPropReference;
                    objFilingTransactionsContract.IEDescription = objFilingTransactionsModel.IEDescription;
                    objFilingTransactionsContract.R_Supported = objFilingTransactionsModel.R_Supported;
                    objFilingTransactionsContract.RLiability = objFilingTransactionsModel.RLiability;
                    objFilingTransactionsContract.RSubcontractor = objFilingTransactionsModel.RSubcontractor;
                    objFilingTransactionsContract.DateIncurredOrgAmtId = objFilingTransactionsModel.DateIncurredOrgAmtId;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;

                    Boolean returnValue = client.AddNonItemIEWeeklyPIDAExpFlngTrans(objFilingTransactionsContract);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapAddNonItemIEWeeklyPIDAExpFlngTransDALResponse

        #region mapGetIEWeeklyLiabInccrTransactionTypesDALResponse
        /// <summary>
        /// mapGetIEWeeklyLiabInccrTransactionTypesDALResponse
        /// </summary>
        /// <returns></returns>
        internal IList<TransactionTypesModel> mapGetIEWeeklyLiabInccrTransactionTypesDALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<TransactionTypesModel> lstTransactionTypesModel = new List<TransactionTypesModel>();
                    TransactionTypesModel objTransactionTypesModel;

                    var results = client.GetIEWeeklyLiabInccrTransactionTypes();

                    foreach (var item in results)
                    {
                        objTransactionTypesModel = new TransactionTypesModel();
                        objTransactionTypesModel.FilingSchedId = item.FilingSchedId;
                        objTransactionTypesModel.FilingSchedDesc = item.FilingSchedDesc;
                        objTransactionTypesModel.FilingSchedAbbrev = item.FilingSchedAbbrev;
                        lstTransactionTypesModel.Add(objTransactionTypesModel);
                    }
                    client.Close();
                    return lstTransactionTypesModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetIEWeeklyLiabInccrTransactionTypesDALResponse

        #region mapGetNonItemIESchedNPurposeCodesDALResponse
        /// <summary>
        /// mapGetNonItemIESchedNPurposeCodesDALResponse
        /// </summary>
        /// <returns></returns>
        internal IList<PurposeCodeModel> mapGetNonItemIESchedNPurposeCodesDALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();
                    PurposeCodeModel objPurposeCodeModel;

                    var results = client.GetNonItemIESchedNPurposeCodes();

                    foreach (var item in results)
                    {
                        objPurposeCodeModel = new PurposeCodeModel();
                        objPurposeCodeModel.PurposeCodeId = item.PurposeCodeId;
                        objPurposeCodeModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objPurposeCodeModel.PurposeCodeAbbrev = item.PurposeCodeAbbrev;
                        lstPurposeCodeModel.Add(objPurposeCodeModel);
                    }
                    client.Close();
                    return lstPurposeCodeModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetNonItemIESchedNPurposeCodesDALResponse

        #region mapGetFilingTransIEWeeklyLiabIncrDataDALResponse
        /// <summary>
        /// mapGetFilingTransIEWeeklyLiabIncrDataDALResponse
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetFilingTransIEWeeklyLiabIncrDataDALResponse(FilingTransDataModel objFilingTransDataModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                    FilingTransactionDataModel objFilingTransactionDataModel;

                    FilingTransDataContract objFilingTransDataContract = new FilingTransDataContract();
                    objFilingTransDataContract.FilerId = objFilingTransDataModel.FilerId;
                    objFilingTransDataContract.ReportYearId = objFilingTransDataModel.ReportYearId;
                    objFilingTransDataContract.OfficeTypeId = objFilingTransDataModel.OfficeTypeId;
                    objFilingTransDataContract.ElectionType = objFilingTransDataModel.ElectionType;
                    objFilingTransDataContract.ElectionDateId = objFilingTransDataModel.ElectionDateId;
                    objFilingTransDataContract.FilingDate = objFilingTransDataModel.FilingDate;
                    objFilingTransDataContract.MunicipalityID = objFilingTransDataModel.MunicipalityID;

                    var results = client.GetFilingTransIEWeeklyLiabIncrData(objFilingTransDataContract);

                    foreach (var item in results)
                    {
                        objFilingTransactionDataModel = new FilingTransactionDataModel();
                        objFilingTransactionDataModel.FilingTransId = item.FilingTransId;
                        objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.PaymentTypeId = item.PaymentTypeId;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.PurposeCodeId = item.PurposeCodeId;
                        objFilingTransactionDataModel.SubmissionDate = item.SubmissionDate;
                        objFilingTransactionDataModel.SchedDate = item.SchedDate;
                        objFilingTransactionDataModel.FilingSchedDesc = item.FilingSchedDesc;
                        objFilingTransactionDataModel.FilingEntityId = item.FilingEntityId;
                        objFilingTransactionDataModel.FilingEntityName = item.FilingEntityName;
                        objFilingTransactionDataModel.FilingFirstName = item.FilingFirstName;
                        objFilingTransactionDataModel.FilingMiddleName = item.FilingMiddleName;
                        objFilingTransactionDataModel.FilingLastName = item.FilingLastName;
                        objFilingTransactionDataModel.FilingStreetNumber = item.FilingStreetNumber;
                        objFilingTransactionDataModel.FilingStreetName = item.FilingStreetName;
                        objFilingTransactionDataModel.FilingCity = item.FilingCity;
                        objFilingTransactionDataModel.FilingState = item.FilingState;
                        objFilingTransactionDataModel.FilingZip = item.FilingZip;
                        objFilingTransactionDataModel.FilingCountry = item.FilingCountry;
                        objFilingTransactionDataModel.PaymentTypeDesc = item.PaymentTypeDesc;
                        objFilingTransactionDataModel.PayNumber = item.PayNumber;
                        objFilingTransactionDataModel.OriginalAmount = item.OriginalAmount;
                        objFilingTransactionDataModel.OwedAmount = item.OwedAmount;
                        objFilingTransactionDataModel.ReceiptTypeDesc = item.ReceiptTypeDesc;
                        objFilingTransactionDataModel.TransferTypeDesc = item.TransferTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.OriginalDate = item.OriginalDate;
                        objFilingTransactionDataModel.LoanerCode = item.LoanerCode;
                        objFilingTransactionDataModel.ElectionYear = item.ElectionYear;
                        objFilingTransactionDataModel.Office = item.Office;
                        objFilingTransactionDataModel.District = item.District;
                        objFilingTransactionDataModel.RLiability = item.RLiability;
                        objFilingTransactionDataModel.RSubcontractor = item.RSubcontractor;
                        objFilingTransactionDataModel.TransExplanation = item.TransExplanation;
                        objFilingTransactionDataModel.OwedAmount = item.OwedAmount;
                        objFilingTransactionDataModel.RItemized = item.RItemized;
                        objFilingTransactionDataModel.RAmend = item.RAmend;
                        objFilingTransactionDataModel.Status = item.RStatus;
                        objFilingTransactionDataModel.CountyID = item.CountyID;
                        objFilingTransactionDataModel.CountyDesc = item.CountyDesc;
                        objFilingTransactionDataModel.MunicipalityID = item.MunicipalityID;
                        objFilingTransactionDataModel.MunicipalityDesc = item.MunicipalityDesc;
                        objFilingTransactionDataModel.LoanerCodeID = item.LoanerCodeID;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.CreatedDate = item.CreatedDate;
                        objFilingTransactionDataModel.TreasurerFirstName = item.TreasurerFirstName;
                        objFilingTransactionDataModel.TreasurerLastName = item.TreasurerLastName;
                        objFilingTransactionDataModel.TreasurerMiddleName = item.TreasurerMiddleName;
                        objFilingTransactionDataModel.TreasurerOccuptaion = item.TreasurerOccuptaion;
                        objFilingTransactionDataModel.TreasurerEmployer = item.TreasurerEmployer;
                        objFilingTransactionDataModel.TreasurerStreetAddress = item.TreasurerStreetAddress;
                        objFilingTransactionDataModel.TreasurerCity = item.TreasurerCity;
                        objFilingTransactionDataModel.TreasurerState = item.TreasurerState;
                        objFilingTransactionDataModel.TreasurerZip = item.TreasurerZip;
                        objFilingTransactionDataModel.ContributorOccupation = item.ContributorOccupation;
                        objFilingTransactionDataModel.ContributorEmployer = item.ContributorEmployer;
                        objFilingTransactionDataModel.IEDescription = item.IEDescription;
                        objFilingTransactionDataModel.CandBallotPropReference = item.CandBallotPropReference;
                        objFilingTransactionDataModel.IESupported = item.IESupported;
                        objFilingTransactionDataModel.RLiability = item.RLiability;
                        objFilingTransactionDataModel.RSubcontractor = item.RSubcontractor;
                        objFilingTransactionDataModel.AddrId = item.AddrId;
                        objFilingTransactionDataModel.TreasId = item.TreasId;
                        objFilingTransactionDataModel.DateIncurredOrgAmtId = item.DateIncurredOrgAmtId;
                        objFilingTransactionDataModel.LoanLiablityNumber = item.LoanLiablityNumber;
                        objFilingTransactionDataModel.TransNumber = item.TransNumber;
                        objFilingTransactionDataModel.TransMapping = item.TransMapping;
                        lstFilingTransactionDataModel.Add(objFilingTransactionDataModel);
                    }
                    client.Close();
                    return lstFilingTransactionDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetFilingTransIEWeeklyLiabIncrDataDALResponse

        #region mapGetFilingTransIEWeeklyLiabIncrHistoryDataDALResponse
        /// <summary>
        /// mapGetFilingTransIEWeeklyLiabIncrHistoryDataDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetFilingTransIEWeeklyLiabIncrHistoryDataDALResponse(String strTransNumber)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                    FilingTransactionDataModel objFilingTransactionDataModel;

                    var results = client.GetFilingTransIEWeeklyLiabIncrHistoryData(strTransNumber);

                    foreach (var item in results)
                    {
                        objFilingTransactionDataModel = new FilingTransactionDataModel();
                        objFilingTransactionDataModel.FilingTransId = item.FilingTransId;
                        objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                        objFilingTransactionDataModel.PurposeCodeId = item.PurposeCodeId;
                        objFilingTransactionDataModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.PaymentTypeId = item.PaymentTypeId;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.SubmissionDate = item.SubmissionDate;
                        objFilingTransactionDataModel.SchedDate = item.SchedDate;
                        objFilingTransactionDataModel.FilingSchedDesc = item.FilingSchedDesc;
                        objFilingTransactionDataModel.FilingEntityId = item.FilingEntityId;
                        objFilingTransactionDataModel.FilingEntityName = item.FilingEntityName;
                        objFilingTransactionDataModel.FilingFirstName = item.FilingFirstName;
                        objFilingTransactionDataModel.FilingMiddleName = item.FilingMiddleName;
                        objFilingTransactionDataModel.FilingLastName = item.FilingLastName;
                        objFilingTransactionDataModel.FilingStreetNumber = item.FilingStreetNumber;
                        objFilingTransactionDataModel.FilingStreetName = item.FilingStreetName;
                        objFilingTransactionDataModel.FilingCity = item.FilingCity;
                        objFilingTransactionDataModel.FilingState = item.FilingState;
                        objFilingTransactionDataModel.FilingZip = item.FilingZip;
                        objFilingTransactionDataModel.FilingCountry = item.FilingCountry;
                        objFilingTransactionDataModel.PaymentTypeDesc = item.PaymentTypeDesc;
                        objFilingTransactionDataModel.PayNumber = item.PayNumber;
                        objFilingTransactionDataModel.OriginalAmount = item.OriginalAmount;
                        objFilingTransactionDataModel.ReceiptTypeDesc = item.ReceiptTypeDesc;
                        objFilingTransactionDataModel.TransferTypeDesc = item.TransferTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.OriginalDate = item.OriginalDate;
                        objFilingTransactionDataModel.LoanerCode = item.LoanerCode;
                        objFilingTransactionDataModel.ElectionYear = item.ElectionYear;
                        objFilingTransactionDataModel.Office = item.Office;
                        objFilingTransactionDataModel.District = item.District;
                        objFilingTransactionDataModel.RLiability = item.RLiability;
                        objFilingTransactionDataModel.RSubcontractor = item.RSubcontractor;
                        objFilingTransactionDataModel.TransExplanation = item.TransExplanation;
                        objFilingTransactionDataModel.OwedAmount = item.OwedAmount;
                        objFilingTransactionDataModel.RItemized = item.RItemized;
                        objFilingTransactionDataModel.RAmend = item.RAmend;
                        objFilingTransactionDataModel.Status = item.RStatus;
                        objFilingTransactionDataModel.CountyID = item.CountyID;
                        objFilingTransactionDataModel.CountyDesc = item.CountyDesc;
                        objFilingTransactionDataModel.MunicipalityID = item.MunicipalityID;
                        objFilingTransactionDataModel.MunicipalityDesc = item.MunicipalityDesc;
                        objFilingTransactionDataModel.LoanerCodeID = item.LoanerCodeID;
                        objFilingTransactionDataModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.CreatedDate = item.CreatedDate;
                        objFilingTransactionDataModel.TreasurerFirstName = item.TreasurerFirstName;
                        objFilingTransactionDataModel.TreasurerLastName = item.TreasurerLastName;
                        objFilingTransactionDataModel.TreasurerMiddleName = item.TreasurerMiddleName;
                        objFilingTransactionDataModel.TreasurerOccuptaion = item.TreasurerOccuptaion;
                        objFilingTransactionDataModel.TreasurerEmployer = item.TreasurerEmployer;
                        objFilingTransactionDataModel.TreasurerStreetAddress = item.TreasurerStreetAddress;
                        objFilingTransactionDataModel.TreasurerCity = item.TreasurerCity;
                        objFilingTransactionDataModel.TreasurerState = item.TreasurerState;
                        objFilingTransactionDataModel.TreasurerZip = item.TreasurerZip;
                        objFilingTransactionDataModel.ContributorOccupation = item.ContributorOccupation;
                        objFilingTransactionDataModel.ContributorEmployer = item.ContributorEmployer;
                        objFilingTransactionDataModel.CandBallotPropReference = item.CandBallotPropReference;
                        objFilingTransactionDataModel.IEDescription = item.IEDescription;
                        objFilingTransactionDataModel.IESupported = item.IESupported;
                        objFilingTransactionDataModel.LoanLiablityNumber = item.LoanLiablityNumber;
                        objFilingTransactionDataModel.TransNumber = item.TransNumber;
                        objFilingTransactionDataModel.TransMapping = item.TransMapping;
                        lstFilingTransactionDataModel.Add(objFilingTransactionDataModel);
                    }
                    client.Close();
                    return lstFilingTransactionDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetFilingTransIEWeeklyLiabIncrHistoryDataDALResponse

        #region mapAddNonItemIEWeeklyLiabIncrFlngTransDALResponse
        /// <summary>
        /// mapAddNonItemIEWeeklyLiabIncrFlngTransDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapAddNonItemIEWeeklyLiabIncrFlngTransDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.PersonId = objFilingTransactionsModel.PersonId;
                    objFilingTransactionsContract.TreasId = objFilingTransactionsModel.TreasId;
                    objFilingTransactionsContract.AddrId = objFilingTransactionsModel.AddrId;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.PurposeCodeId = objFilingTransactionsModel.PurposeCodeId;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.OwedAmt = objFilingTransactionsModel.OwedAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.MunicipalityID = objFilingTransactionsModel.MunicipalityID;
                    objFilingTransactionsContract.RAmend = objFilingTransactionsModel.RAmend;
                    objFilingTransactionsContract.ElectionDate = objFilingTransactionsModel.ElectionDate;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.ElectionYear = objFilingTransactionsModel.ElectionYear;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.TreasurerOccupation = objFilingTransactionsModel.TreasurerOccupation;
                    objFilingTransactionsContract.TreasurerEmployer = objFilingTransactionsModel.TreasurerEmployer;
                    objFilingTransactionsContract.ContributorOccupation = objFilingTransactionsModel.ContributorOccupation;
                    objFilingTransactionsContract.ContributorEmployer = objFilingTransactionsModel.ContributorEmployer;
                    objFilingTransactionsContract.TreasurerStreetAddress = objFilingTransactionsModel.TreasurerStreetAddress;
                    objFilingTransactionsContract.TreasurerCity = objFilingTransactionsModel.TreasurerCity;
                    objFilingTransactionsContract.TreasurerState = objFilingTransactionsModel.TreasurerState;
                    objFilingTransactionsContract.TreasurerZip = objFilingTransactionsModel.TreasurerZip;
                    objFilingTransactionsContract.CandBallotPropReference = objFilingTransactionsModel.CandBallotPropReference;
                    objFilingTransactionsContract.IEDescription = objFilingTransactionsModel.IEDescription;
                    objFilingTransactionsContract.R_Supported = objFilingTransactionsModel.R_Supported;
                    objFilingTransactionsContract.DateIncurredOrgAmtId = objFilingTransactionsModel.DateIncurredOrgAmtId;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;

                    Boolean returnValue = client.AddNonItemIEWeeklyLiabIncrFlngTrans(objFilingTransactionsContract);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }

            }
            
            
        }
        #endregion mapAddNonItemIEWeeklyLiabIncrFlngTransDALResponse

        #region mapUpdateIEWeeklyLiabIncrFlngTransDALResponse
        /// <summary>
        /// mapUpdateIEWeeklyLiabIncrFlngTransDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateIEWeeklyLiabIncrFlngTransDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.TransNumber = objFilingTransactionsModel.TransNumber;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.TreasId = objFilingTransactionsModel.TreasId;
                    objFilingTransactionsContract.AddrId = objFilingTransactionsModel.AddrId;
                    objFilingTransactionsContract.PersonId = objFilingTransactionsModel.PersonId;
                    objFilingTransactionsContract.SubmissionDate = objFilingTransactionsModel.SubmissionDate;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.PurposeCodeId = objFilingTransactionsModel.PurposeCodeId;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.OwedAmt = objFilingTransactionsModel.OwedAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.TreasurerStreetAddress = objFilingTransactionsModel.TreasurerStreetAddress;
                    objFilingTransactionsContract.TreasurerCity = objFilingTransactionsModel.TreasurerCity;
                    objFilingTransactionsContract.TreasurerState = objFilingTransactionsModel.TreasurerState;
                    objFilingTransactionsContract.TreasurerZip = objFilingTransactionsModel.TreasurerZip;
                    objFilingTransactionsContract.IEDescription = objFilingTransactionsModel.IEDescription;
                    objFilingTransactionsContract.TreasurerOccupation = objFilingTransactionsModel.TreasurerOccupation;
                    objFilingTransactionsContract.TreasurerEmployer = objFilingTransactionsModel.TreasurerEmployer;
                    objFilingTransactionsContract.ContributorOccupation = objFilingTransactionsModel.ContributorOccupation;
                    objFilingTransactionsContract.ContributorEmployer = objFilingTransactionsModel.ContributorEmployer;
                    objFilingTransactionsContract.R_Supported = objFilingTransactionsModel.R_Supported;
                    objFilingTransactionsContract.CandBallotPropReference = objFilingTransactionsModel.CandBallotPropReference;
                    objFilingTransactionsContract.ModifiedBy = objFilingTransactionsModel.ModifiedBy;

                    Boolean returnValue = client.UpdateIEWeeklyLiabIncrFlngTrans(objFilingTransactionsContract);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
           
            
        }
        #endregion mapUpdateIEWeeklyLiabIncrFlngTransDALResponse

        #region mapGetFilingMethodDataDALResponse
        /// <summary>
        /// mapGetFilingMethodDataDALResponse
        /// </summary>
        /// <returns></returns>
        internal IList<FilingMthodModel> mapGetFilingMethodDataDALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingMthodModel> lstFilingMthodModel = new List<FilingMthodModel>();
                    FilingMthodModel objFilingMthodModel;

                    var results = client.GetFilingMethodData();

                    foreach (var item in results)
                    {
                        objFilingMthodModel = new FilingMthodModel();
                        objFilingMthodModel.FilingMethodId = item.FilingMethodId;
                        objFilingMthodModel.FilingMethodDesc = item.FilingMethodDesc;
                        lstFilingMthodModel.Add(objFilingMthodModel);
                    }
                    client.Close();
                    return lstFilingMthodModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetFilingMethodDataDALResponse

        #region mapGetCampaignMaterialDataDALResponse
        /// <summary>
        /// mapGetCampaignMaterialDataDALResponse
        /// </summary>
        /// <param name="objNonItemCampaignMaterialModel"></param>
        /// <returns></returns>
        internal IList<NonItemCampaignMaterialDataModel> mapGetCampaignMaterialDataDALResponse(NonItemCampaignMaterialModel objNonItemCampaignMaterialModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<NonItemCampaignMaterialDataModel> lstNonItemCampaignMaterialDataModel = new List<NonItemCampaignMaterialDataModel>();
                    NonItemCampaignMaterialDataModel objNonItemCampaignMaterialDataModel;

                    NonItemCampaignMaterialContract objNonItemCampaignMaterialContract = new NonItemCampaignMaterialContract();
                    objNonItemCampaignMaterialContract.FilerId = objNonItemCampaignMaterialModel.FilerId;
                    objNonItemCampaignMaterialContract.ElectionDate = objNonItemCampaignMaterialModel.ElectionDate;
                    objNonItemCampaignMaterialContract.ElectYearId = objNonItemCampaignMaterialModel.ElectYearId;
                    objNonItemCampaignMaterialContract.ElectionYear = objNonItemCampaignMaterialModel.ElectionYear;
                    objNonItemCampaignMaterialContract.ElectionTypeId = objNonItemCampaignMaterialModel.ElectionTypeId;
                    objNonItemCampaignMaterialContract.OfficeTypeId = objNonItemCampaignMaterialModel.OfficeTypeId;
                    objNonItemCampaignMaterialContract.FilingTypeId = objNonItemCampaignMaterialModel.FilingTypeId;
                    objNonItemCampaignMaterialContract.ElectionDateId = objNonItemCampaignMaterialModel.ElectionDateId;
                    objNonItemCampaignMaterialContract.FilingDate = objNonItemCampaignMaterialModel.FilingDate;

                    var results = client.GetCampaignMaterialData(objNonItemCampaignMaterialContract);

                    foreach (var item in results)
                    {
                        objNonItemCampaignMaterialDataModel = new NonItemCampaignMaterialDataModel();
                        objNonItemCampaignMaterialDataModel.CampaignMaterialId = item.CampaignMaterialId;
                        objNonItemCampaignMaterialDataModel.FilingMethodId = item.FilingMethodId;
                        objNonItemCampaignMaterialDataModel.ScanDocId = item.SacnDocId;
                        objNonItemCampaignMaterialDataModel.DateSubmitted = item.DateSubmitted;
                        objNonItemCampaignMaterialDataModel.CampaignMaterialDesc = item.CampaignMaterialDesc;
                        objNonItemCampaignMaterialDataModel.CampMatrFileType = item.CampMatrFileType;
                        objNonItemCampaignMaterialDataModel.CampMatrFileSize = item.CampMatrFileSize;
                        objNonItemCampaignMaterialDataModel.FilingMethodDesc = item.FilingMethodDesc;
                        objNonItemCampaignMaterialDataModel.RCampMatr = item.RCampMatr;
                        objNonItemCampaignMaterialDataModel.CreatedDate = item.CreatedDate;
                        objNonItemCampaignMaterialDataModel.RAmended = item.RAmended;
                        lstNonItemCampaignMaterialDataModel.Add(objNonItemCampaignMaterialDataModel);
                    }
                    client.Close();
                    return lstNonItemCampaignMaterialDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetCampaignMaterialDataDALResponse

        #region mapAddNonItemCampaignMaterialDALResponse
        /// <summary>
        /// mapAddNonItemCampaignMaterialDALResponse
        /// </summary>
        /// <param name="objNonItemCampaignMaterialModel"></param>
        /// <returns></returns>
        internal Boolean mapAddNonItemCampaignMaterialDALResponse(NonItemCampaignMaterialModel objNonItemCampaignMaterialModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    NonItemCampaignMaterialContract objNonItemCampaignMaterialContract = new NonItemCampaignMaterialContract();
                    objNonItemCampaignMaterialContract.FilerId = objNonItemCampaignMaterialModel.FilerId;
                    objNonItemCampaignMaterialContract.ElectionDate = objNonItemCampaignMaterialModel.ElectionDate;
                    objNonItemCampaignMaterialContract.ElectionDateId = objNonItemCampaignMaterialModel.ElectionDateId;
                    objNonItemCampaignMaterialContract.ElectionTypeId = objNonItemCampaignMaterialModel.ElectionTypeId;
                    objNonItemCampaignMaterialContract.OfficeTypeId = objNonItemCampaignMaterialModel.OfficeTypeId;
                    objNonItemCampaignMaterialContract.FilingTypeId = objNonItemCampaignMaterialModel.FilingTypeId;
                    objNonItemCampaignMaterialContract.FilingCategoryId = objNonItemCampaignMaterialModel.FilingCategoryId;
                    objNonItemCampaignMaterialContract.ElectYearId = objNonItemCampaignMaterialModel.ElectYearId;
                    objNonItemCampaignMaterialContract.ElectionYear = objNonItemCampaignMaterialModel.ElectionYear;
                    objNonItemCampaignMaterialContract.CountyId = objNonItemCampaignMaterialModel.CountyId;
                    objNonItemCampaignMaterialContract.MunicipalityId = objNonItemCampaignMaterialModel.MunicipalityId;
                    objNonItemCampaignMaterialContract.DateSubmitted = objNonItemCampaignMaterialModel.DateSubmitted;
                    objNonItemCampaignMaterialContract.FilingMethodId = objNonItemCampaignMaterialModel.FilingMethodId;
                    objNonItemCampaignMaterialContract.CampaignMaterialDesc = objNonItemCampaignMaterialModel.CampaignMaterialDesc;
                    objNonItemCampaignMaterialContract.CampMatrFileType = objNonItemCampaignMaterialModel.CampMatrFileType;
                    objNonItemCampaignMaterialContract.CampMatrFileSize = objNonItemCampaignMaterialModel.CampMatrFileSize;
                    objNonItemCampaignMaterialContract.SacnDocId = objNonItemCampaignMaterialModel.SacnDocId;
                    objNonItemCampaignMaterialContract.RCampMatr = objNonItemCampaignMaterialModel.RCampMatr;
                    objNonItemCampaignMaterialContract.CreatedBy = objNonItemCampaignMaterialModel.CreatedBy;
                    objNonItemCampaignMaterialContract.FilingDate = objNonItemCampaignMaterialModel.FilingDate;

                    Boolean returnValue = client.AddNonItemCampaignMaterial(objNonItemCampaignMaterialContract);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapAddNonItemCampaignMaterialDALResponse

        #region mapDeleteCampaignMaterialDALResponse
        /// <summary>
        /// mapDeleteCampaignMaterialDALResponse
        /// </summary>
        /// <param name="strCampMatrId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        internal Boolean mapDeleteCampaignMaterialDALResponse(String strCampMatrId, String strModifiedBy)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    Boolean returnValue = client.DeleteCampaignMaterial(strCampMatrId, strModifiedBy);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapDeleteCampaignMaterialDALResponse

        //=======CABITNET CODE==================CABINET CODE========================

        #region mapGetFilingDateOffCycleDataDALResponse
        /// <summary>
        /// mapGetFilingDateOffCycleDataDALResponse
        /// </summary>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <returns></returns>
        internal IList<FilingDatesOffCycleModel> mapGetFilingDateOffCycleDataDALResponse(String strElectionYearId, String strOfficeTypeId, String strFilerId, String strDisclosureType)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingDatesOffCycleModel> lstFilingDatesOffCycleModel = new List<FilingDatesOffCycleModel>();
                    FilingDatesOffCycleModel objFilingDatesOffCycleModel;

                    var results = client.GetFilingDateOffCycleData(strElectionYearId, strOfficeTypeId, strFilerId, strDisclosureType);

                    foreach (var item in results)
                    {
                        objFilingDatesOffCycleModel = new FilingDatesOffCycleModel();
                        objFilingDatesOffCycleModel.FilingDateId = item.FilingDateId;
                        objFilingDatesOffCycleModel.FilingDate = item.FilingDate.Trim();
                        lstFilingDatesOffCycleModel.Add(objFilingDatesOffCycleModel);
                    }
                    client.Close();
                    return lstFilingDatesOffCycleModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetFilingDateOffCycleDataDALResponse

        #region mapGetFilingDateIEWeeklyeDataDALResponse
        /// <summary>
        /// mapGetFilingDateIEWeeklyeDataDALResponse
        /// </summary>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strFilingType"></param>
        /// <param name="strFilingCatId"></param>
        /// <param name="strElectionDateId"></param>
        /// <returns></returns>
        internal IList<FilingDatesOffCycleModel> mapGetFilingDateIEWeeklyeDataDALResponse(String strElectionYearId, String strElectionTypeId, String strOfficeTypeId, String strFilerId, String strFilingType, String strFilingCatId, String strElectionDateId, String strMunicipalityID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingDatesOffCycleModel> lstFilingDatesOffCycleModel = new List<FilingDatesOffCycleModel>();
                    FilingDatesOffCycleModel objFilingDatesOffCycleModel;

                    var results = client.GetFilingDateIEWeeklyeData(strElectionYearId, strElectionTypeId, strOfficeTypeId, strFilerId, strFilingType, strFilingCatId, strElectionDateId, strMunicipalityID);

                    foreach (var item in results)
                    {
                        objFilingDatesOffCycleModel = new FilingDatesOffCycleModel();
                        objFilingDatesOffCycleModel.FilingDateId = item.FilingDateId;
                        objFilingDatesOffCycleModel.FilingDate = item.FilingDate;
                        lstFilingDatesOffCycleModel.Add(objFilingDatesOffCycleModel);
                    }
                    client.Close();
                    return lstFilingDatesOffCycleModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetFilingDateIEWeeklyeDataDALResponse


        #region mapGetTokenIdDALResponse
        /// <summary>
        /// mapGetTokenIdDALResponse
        /// </summary>
        /// <param name="objCampMatrDocumentIdModel"></param>
        /// <returns></returns>
        internal CabinetReturnValModel mapGetTokenIdDALResponse(CampMatrDocumentIdModel objCampMatrDocumentIdModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    CabinetReturnValModel objCabinetReturnValModel;

                    DocumentIDContract objDocumentIDContract = new DocumentIDContract();

                    objDocumentIDContract.strCampMatrFileName = objCampMatrDocumentIdModel.strCampMatrFileName;
                    objDocumentIDContract.strCampMatrFilerId = objCampMatrDocumentIdModel.strCampMatrFilerId;
                    objDocumentIDContract.fileBytes = objCampMatrDocumentIdModel.fileBytes;
                    objDocumentIDContract.FolderFilerId = objCampMatrDocumentIdModel.FolderFilerId;
                    objDocumentIDContract.FolderElectionYear = objCampMatrDocumentIdModel.FolderElectionYear;
                    objDocumentIDContract.FolderDisclosurePeriod = objCampMatrDocumentIdModel.FolderDisclosurePeriod;
                    objDocumentIDContract.FileExtension = objCampMatrDocumentIdModel.FileExtension;
                    objDocumentIDContract.PageName = objCampMatrDocumentIdModel.PageName;

                    var results = client.GetTokenID(objDocumentIDContract);

                    objCabinetReturnValModel = new CabinetReturnValModel();
                    objCabinetReturnValModel.DocumentID = results.DocumentID;
                    objCabinetReturnValModel.TokenID = results.TokenID;
                    objCabinetReturnValModel.RepositoryID = results.RepositoryID;
                    objCabinetReturnValModel.CabinetID = results.CabinetID;
                    objCabinetReturnValModel.ManagerID = results.ManagerID;
                    objCabinetReturnValModel.ExtensionID = results.ExtensionID;
                    objCabinetReturnValModel.ExtensionName = results.ExtensionName;
                    objCabinetReturnValModel.FormattedFileSize = results.FormattedFileSize;
                    objCabinetReturnValModel.TabID = results.TabID;
                    objCabinetReturnValModel.TemplateID = results.TemplateID;
                    client.Close();
                    return objCabinetReturnValModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetTokenIdDALResponse

        #region GetTokenIDDAL
        /// <summary>
        /// GetTokenIDDAL
        /// </summary>
        /// <param name="strFileType"></param>
        /// <returns></returns>
        internal CabinetReturnValModel GetTokenIDDAL(String strFileType, String strPageName)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    CabinetReturnValModel objCabinetReturnValModel = new CabinetReturnValModel();
                    PIDAReturnVal objPIDAReturnVal;
                    objPIDAReturnVal = client.GetTokenIDData(strFileType, strPageName);

                    objCabinetReturnValModel.TokenID = objPIDAReturnVal.TokenID.ToString();
                    objCabinetReturnValModel.RepositoryID = objPIDAReturnVal.RepositoryID;
                    objCabinetReturnValModel.CabinetID = objPIDAReturnVal.CabinetID;
                    objCabinetReturnValModel.ManagerID = objPIDAReturnVal.ManagerID;
                    objCabinetReturnValModel.ExtensionID = objPIDAReturnVal.ExtensionID;
                    objCabinetReturnValModel.ExtensionName = objPIDAReturnVal.ExtensionName;
                    objCabinetReturnValModel.TabID = objPIDAReturnVal.TabID;
                    objCabinetReturnValModel.TemplateID = objPIDAReturnVal.TemplateID;
                    client.Close();
                    return objCabinetReturnValModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion GetTokenIDDAL

        #region DocumentDownloadDAL
        /// <summary>
        /// DocumentDownloadDAL
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="CabinetID"></param>
        /// <param name="DocumentID"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        internal CabinetDownloadObjectModel DocumentDownloadDAL(string Token, int CabinetID, int DocumentID, string fileName)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    CabinetDownloadObjectModel objCabinetDownloadObjectModel = new CabinetDownloadObjectModel();
                    PIDADownloadObject pIDADownloadObject;

                    pIDADownloadObject = client.DocumentDownload(Token, CabinetID, DocumentID, fileName);

                    objCabinetDownloadObjectModel.FileByte = pIDADownloadObject.FileByte;
                    objCabinetDownloadObjectModel.FileName = pIDADownloadObject.FileName;
                    client.Close();
                    return objCabinetDownloadObjectModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion DocumentDownloadDAL

        //=======CABITNET CODE==================CABINET CODE========================

        //=======NETWORK DRIVE CODE==================NETWORK DRIVE CODE========================

        #region mapUploadFileInNetworkDriveDALResponse
        /// <summary>
        /// mapUploadFileInNetworkDriveDALResponse
        /// </summary>
        /// <param name="objUploadFileNTDriveModel"></param>
        /// <returns></returns>
        internal Boolean mapUploadFileInNetworkDriveDALResponse(UploadFileNTDriveModel objUploadFileNTDriveModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    UploadFileNTDriveContract objUploadFileNTDriveContract = new UploadFileNTDriveContract();
                    objUploadFileNTDriveContract.CampMatrFileName = objUploadFileNTDriveModel.CampMatrFileName;
                    objUploadFileNTDriveContract.FileBytes = objUploadFileNTDriveModel.FileBytes;
                    objUploadFileNTDriveContract.FilerIdNTDrive = objUploadFileNTDriveModel.FilerIdNTDrive;
                    objUploadFileNTDriveContract.ElectionYearNTDrive = objUploadFileNTDriveModel.ElectionYearNTDrive;
                    objUploadFileNTDriveContract.DisclosurePeriodNTDrive = objUploadFileNTDriveModel.DisclosurePeriodNTDrive;

                    Boolean returnValue = client.UploadFileInNetworkDrive(objUploadFileNTDriveContract);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapUploadFileInNetworkDriveDALResponse

        #region mapDownloadFileInNetworkDriveDALResponse
        /// <summary>
        /// mapDownloadFileInNetworkDriveDALResponse
        /// </summary>
        /// <param name="strFileFolderPath"></param>
        /// <param name="strFileName"></param>
        /// <returns></returns>
        internal Byte[] mapDownloadFileInNetworkDriveDALResponse(String strFileFolderPath, String strFileName)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    Byte[] returnValue = client.DownloadFileInNetworkDrive(strFileFolderPath, strFileName);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapDownloadFileInNetworkDriveDALResponse

        //=======NETWORK DRIVE CODE==================NETWORK DRIVE CODE========================

        //=========================================================================================================================================
        // NON-ITEMIZED TRANSACTIONS - >>> END END END >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //=========================================================================================================================================

        //========================================================================================================================================
        // COMMON METHOD FOR DROPDOWN VALUES VALIDATION.
        //========================================================================================================================================

        #region mapGetDropdownValueExistsDALResponse
        /// <summary>
        /// mapGetDropdownValueExistsDALResponse
        /// </summary>
        /// <param name="strTableName"></param>
        /// <param name="strDropdownValue"></param>
        /// <returns></returns>
        internal Boolean mapGetDropdownValueExistsDALResponse(String strTableName, String strDropdownValue)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    Boolean returnValue = client.GetDropdownValueExists(strTableName, strDropdownValue);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
           
            
        }
        #endregion mapGetDropdownValueExistsDALResponse

        #region GetDropdownValueExistsValidation
        /// <summary>
        /// GetDropdownValueExistsValidation
        /// </summary>
        /// <returns></returns>
        internal IList<VendorImportValidationModel> GetDropdownValueExistsValidation()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<VendorImportValidationModel> lstVendorImportValidation = new List<VendorImportValidationModel>();
                    VendorImportValidationModel objVendorImportValidation;

                    var results = client.GetDropdownValueExistsValidation();

                    foreach (var item in results)
                    {
                        objVendorImportValidation = new VendorImportValidationModel();
                        objVendorImportValidation.Id = item.Id;
                        objVendorImportValidation.TableName = item.TableName;
                        lstVendorImportValidation.Add(objVendorImportValidation);
                    }
                    client.Close();
                    return lstVendorImportValidation;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
           
            

        }
        #endregion GetDropdownValueExistsValidation

        #region mapTransferOutStandingLiabilityBalanceDALResponse
        /// <summary>
        /// mapTransferOutStandingLiabilityBalanceDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal String mapTransferOutStandingLiabilityBalanceDALResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract;
                    objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.FilingTypeId = objFilingTransactionsModel.FilingTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;
                    objFilingTransactionsContract.ResigTermTypeId = objFilingTransactionsModel.ResigTermTypeId;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;

                    String results = client.TransferOutStandingLiabilityBalance(objFilingTransactionsContract);
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
        #endregion mapTransferOutStandingLiabilityBalanceDALResponse

        //========================================================================================================================================
        // COMMON METHOD FOR DROPDOWN VALUES VALIDATION.
        //========================================================================================================================================

        #region mapGeResigTermTypeDataDALResponse
        /// <summary>
        /// mapGeResigTermTypeDataDALResponse
        /// </summary>
        /// <returns></returns>
        internal IList<ResigTermTypeModel> mapGeResigTermTypeDataDALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ResigTermTypeModel> lstResigTermTypeModel = new List<ResigTermTypeModel>();
                    ResigTermTypeModel objResigTermTypeModel;

                    var results = client.GeResigTermTypeData();

                    foreach (var item in results)
                    {
                        objResigTermTypeModel = new ResigTermTypeModel();
                        objResigTermTypeModel.ResigTermTypeId = item.ResigTermTypeId;
                        objResigTermTypeModel.ResigTermTypeDesc = item.ResigTermTypeDesc;
                        lstResigTermTypeModel.Add(objResigTermTypeModel);
                    }
                    client.Close();
                    return lstResigTermTypeModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGeResigTermTypeDataDALResponse

        #region mapGetResgTermTypeExistsValueDALResponse
        /// <summary>
        /// mapGetResgTermTypeExistsValueDALResponse
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <param name="strElectionYearId"></param>
        /// <returns></returns>
        internal IList<ResigTermTypeModel> mapGetResgTermTypeExistsValueDALResponse(String strFilerId, String strElectionTypeId, String strOfficeTypeId, String strFilingTypeId, String strElectionYearId, String strElectionDateId, String strFilingDate, String strFilingCategoryId, String strMunicipalityId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ResigTermTypeModel> lstResigTermTypeModel = new List<ResigTermTypeModel>();
                    ResigTermTypeModel objResigTermTypeModel;

                    var results = client.GetResgTermTypeExistsValue(strFilerId, strElectionTypeId, strOfficeTypeId, strFilingTypeId, strElectionYearId, strElectionDateId, strFilingDate.Trim().ToString(), strFilingCategoryId, strMunicipalityId);

                    foreach (var item in results)
                    {
                        objResigTermTypeModel = new ResigTermTypeModel();
                        objResigTermTypeModel.ResigTermTypeId = item.ResigTermTypeId;
                        objResigTermTypeModel.ResigTermTypeDesc = item.ResigTermTypeDesc;
                        objResigTermTypeModel.FilingsId = item.FilingsId;
                        lstResigTermTypeModel.Add(objResigTermTypeModel);
                    }
                    client.Close();
                    return lstResigTermTypeModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetResgTermTypeExistsValueDALResponse

        #region mapUpdateResgTermTypeFilingsDALResponse
        /// <summary>
        /// mapUpdateResgTermTypeFilingsDALResponse
        /// </summary>
        /// <param name="strFilingsId"></param>
        /// <param name="strResgTermTypeId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        internal Boolean mapUpdateResgTermTypeFilingsDALResponse(String strFilingsId, String strResgTermTypeId, String strModifiedBy)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    Boolean results = client.UpdateResgTermTypeFilings(strFilingsId, strResgTermTypeId, strModifiedBy);
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
        #endregion UpdateResgTermTypeFilings

        #region mapGetEelectionExistsEFSDALResponse
        /// <summary>
        /// mapGetEelectionExistsEFSDALResponse
        /// </summary>
        /// <param name="strElectionYearId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strElectionDateId"></param>
        /// <returns></returns>
        public Boolean mapGetEelectionExistsEFSDALResponse(String strElectionYearId, String strElectionTypeId, String strOfficeTypeId, String strElectionDateId, String strMunicipalityId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    Boolean results = client.GetEelectionExistsEFS(strElectionYearId, strElectionTypeId, strOfficeTypeId, strElectionDateId, strMunicipalityId);
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
        #endregion mapGetEelectionExistsEFSDALResponse

        /// <summary>
        /// Get Filer Information
        /// </summary>
        /// <param name="filerID"></param>
        /// <param name="person_ID"></param>
        /// <returns></returns>
        public IList<FilerInfoModel> GetFilerInforamationDAL(String filerID, String person_ID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilerInfoModel> listFilerInfo = new List<FilerInfoModel>();
                    FilerInfoModel objFilerInfo;
                    //data from stored procedure
                    var results = client.GetFilerInforamation(filerID, person_ID);

                    foreach (var item in results)
                    {
                        //create GetDistrictsEntity object
                        objFilerInfo = new FilerInfoModel();
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
                    client.Close();
                    return listFilerInfo;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// Transfer Outstanding balance in Sched N
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public string TransferOutStandingBalanceDAL(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract;
                    objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.FilingTypeId = objFilingTransactionsModel.FilingTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;
                    objFilingTransactionsContract.ResigTermTypeId = objFilingTransactionsModel.ResigTermTypeId;
                    objFilingTransactionsContract.MunicipalityID = objFilingTransactionsModel.MunicipalityID;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;

                    string results = client.TransferOutStandingBalance(objFilingTransactionsContract);
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
        /// Submit filings from summery page
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean SubmitFilings_SummeryDAL(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.FilingTypeId = objFilingTransactionsModel.FilingTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;

                    Boolean result = client.SubmitFilings_Summery(objFilingTransactionsContract);
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
        /// mapGetFilingTransactionsDataDALResponse
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> GetFilingTransactionsDataSummaryDAL(FilingTransDataModel objFilingTransDataModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                    FilingTransactionDataModel objFilingTransactionDataModel;

                    FilingTransDataContract objFilingTransDataContract = new FilingTransDataContract();
                    objFilingTransDataContract.FilerId = objFilingTransDataModel.FilerId;
                    objFilingTransDataContract.ReportYearId = objFilingTransDataModel.ReportYearId;
                    objFilingTransDataContract.OfficeTypeId = objFilingTransDataModel.OfficeTypeId;
                    objFilingTransDataContract.DisclosurePeriod = objFilingTransDataModel.DisclosurePeriod;
                    objFilingTransDataContract.ElectionType = objFilingTransDataModel.ElectionType;
                    objFilingTransDataContract.ElectionDateId = objFilingTransDataModel.ElectionDateId;
                    objFilingTransDataContract.FilingDate = objFilingTransDataModel.FilingDate;
                    objFilingTransDataContract.FilingSchedID = objFilingTransDataModel.FilingSchedID;


                    var results = client.GetFilingTransactionsDataSummary(objFilingTransDataContract);

                    foreach (var item in results)
                    {
                        objFilingTransactionDataModel = new FilingTransactionDataModel();
                        objFilingTransactionDataModel.FilingTransId = item.FilingTransId;
                        objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                        objFilingTransactionDataModel.ReportYear = item.ReportYear;
                        objFilingTransactionDataModel.ContributorTypeId = item.ContributorTypeId;
                        objFilingTransactionDataModel.ContributorTypeDesc = item.ContributorTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.PaymentTypeId = item.PaymentTypeId;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.SchedDate = item.SchedDate;
                        objFilingTransactionDataModel.FilingSchedDesc = item.FilingSchedDesc;
                        objFilingTransactionDataModel.FilingEntityId = item.FilingEntityId;
                        objFilingTransactionDataModel.FilingEntityName = item.FilingEntityName;
                        objFilingTransactionDataModel.FilingFirstName = item.FilingFirstName;
                        objFilingTransactionDataModel.FilingMiddleName = item.FilingMiddleName;
                        objFilingTransactionDataModel.FilingLastName = item.FilingLastName;
                        objFilingTransactionDataModel.FilingStreetNumber = item.FilingStreetNumber;
                        objFilingTransactionDataModel.FilingStreetName = item.FilingStreetName;
                        objFilingTransactionDataModel.FilingCity = item.FilingCity;
                        objFilingTransactionDataModel.FilingState = item.FilingState;
                        objFilingTransactionDataModel.FilingZip = item.FilingZip;
                        objFilingTransactionDataModel.FilingCountry = item.FilingCountry;
                        objFilingTransactionDataModel.PaymentTypeDesc = item.PaymentTypeDesc;
                        objFilingTransactionDataModel.PayNumber = item.PayNumber;
                        objFilingTransactionDataModel.OriginalAmount = item.OriginalAmount;
                        objFilingTransactionDataModel.ReceiptTypeDesc = item.ReceiptTypeDesc;
                        objFilingTransactionDataModel.TransferTypeDesc = item.TransferTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.OriginalDate = item.OriginalDate;
                        objFilingTransactionDataModel.LoanerCode = item.LoanerCode;
                        objFilingTransactionDataModel.ElectionYear = item.ElectionYear;
                        objFilingTransactionDataModel.Office = item.Office;
                        objFilingTransactionDataModel.District = item.District;
                        objFilingTransactionDataModel.RLiability = item.RLiability;
                        objFilingTransactionDataModel.RSubcontractor = item.RSubcontractor;
                        objFilingTransactionDataModel.TransExplanation = item.TransExplanation;
                        objFilingTransactionDataModel.OwedAmount = item.OwedAmount;
                        objFilingTransactionDataModel.RItemized = item.RItemized;
                        objFilingTransactionDataModel.CountyID = item.CountyID;
                        objFilingTransactionDataModel.CountyDesc = item.CountyDesc;
                        objFilingTransactionDataModel.MunicipalityID = item.MunicipalityID;
                        objFilingTransactionDataModel.MunicipalityDesc = item.MunicipalityDesc;
                        objFilingTransactionDataModel.LoanerCodeID = item.LoanerCodeID;
                        objFilingTransactionDataModel.Increased = item.Increased;
                        objFilingTransactionDataModel.Decreased = item.Decreased;
                        objFilingTransactionDataModel.Balance = item.Balance;
                        objFilingTransactionDataModel.CreatedDate = item.CreatedDate;
                        objFilingTransactionDataModel.LoanLiablityNumber = item.LoanLiablityNumber;
                        objFilingTransactionDataModel.TransNumber = item.TransNumber;
                        objFilingTransactionDataModel.TransMapping = item.TransMapping;
                        objFilingTransactionDataModel.DBStatus = item.DBStatus;
                        objFilingTransactionDataModel.FilerId = item.FilerId;
                        objFilingTransactionDataModel.CandidateCommitteeName = item.CandidateCommitteeName;
                        objFilingTransactionDataModel.FilerType = item.FilerType;
                        objFilingTransactionDataModel.ElectionType = item.ElectionType;
                        objFilingTransactionDataModel.ReportType = item.ReportType;
                        objFilingTransactionDataModel.ElectionDate = item.ElectionDate;
                        objFilingTransactionDataModel.DisclosureType = item.DisclosureType;
                        objFilingTransactionDataModel.DisclosurePeriod = item.DisclosurePeriod;
                        objFilingTransactionDataModel.Office_Desc = item.Office_Desc;
                        objFilingTransactionDataModel.RClaim = item.RClaim;
                        objFilingTransactionDataModel.InDistrict = item.InDistrict;
                        objFilingTransactionDataModel.RMinor = item.RMinor;
                        objFilingTransactionDataModel.RVendor = item.RVendor;
                        objFilingTransactionDataModel.RLobbyist = item.RLobbyist;
                        objFilingTransactionDataModel.TreasurerEmployer = item.TreasurerEmployer;
                        objFilingTransactionDataModel.TreasurerOccuptaion = item.TreasurerOccuptaion;
                        objFilingTransactionDataModel.TreaAddress = item.TreaAddress;
                        objFilingTransactionDataModel.TreaAddr1 = item.TreaAddr1;
                        objFilingTransactionDataModel.TreaCity = item.TreaCity;
                        objFilingTransactionDataModel.TreaState = item.TreaState;
                        objFilingTransactionDataModel.TreaZipCode = item.TreaZipCode;
                        objFilingTransactionDataModel.RContributions = item.RContributions;
                        objFilingTransactionDataModel.RIESupported = item.RIESupported;
                        objFilingTransactionDataModel.RSupportOppose = item.RSupportOppose;
                        lstFilingTransactionDataModel.Add(objFilingTransactionDataModel);
                    }
                    client.Close();
                    return lstFilingTransactionDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
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
        internal String GetSummery_OpeningBalanceDAL(String filerID, String election_Year_ID, String office_Type_ID, String filing_Type_ID, String election_Date, String filing_Date)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    String strOpeningBalance = String.Empty;

                    strOpeningBalance = client.GetSummery_OpeningBalance(filerID, election_Year_ID, office_Type_ID, filing_Type_ID, election_Date, filing_Date);
                    client.Close();
                    return strOpeningBalance;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// Get Closing Balance of Summery page
        /// </summary>
        /// <param name="filerID"></param>
        /// <param name="election_Year_ID"></param>
        /// <param name="office_Type_ID"></param>
        /// <param name="filing_Type_ID"></param>
        /// <returns></returns>
        internal String GetSummery_ClosingBalanceDAL(String filerID, String election_Year_ID, String office_Type_ID, String filing_Type_ID, String filing_Date)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    String strClosingBalance = String.Empty;

                    strClosingBalance = client.GetSummery_ClosingBalance(filerID, election_Year_ID, office_Type_ID, filing_Type_ID, filing_Date);
                    client.Close();
                    return strClosingBalance;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
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
        internal String GetSummery_AllSchedBalancesDAL(String filerID, String election_Year_ID, String office_Type_ID, String filing_Type_ID, String filing_date, String filingSchedID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    String strClosingBalance = String.Empty;

                    strClosingBalance = client.GetSummery_AllSchedBalances(filerID, election_Year_ID, office_Type_ID, filing_Type_ID, filing_date, filingSchedID);
                    client.Close();
                    return strClosingBalance;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        internal String GetSummery_AllSchedBalancesDAL_Sched_N(String filerID, String election_Year_ID, String office_Type_ID, String filing_Type_ID, String filing_date, String filingSchedID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    String strClosingBalance = String.Empty;

                    strClosingBalance = client.GetSummery_AllSchedBalances_Sched_N(filerID, election_Year_ID, office_Type_ID, filing_Type_ID, filing_date, filingSchedID);
                    client.Close();
                    return strClosingBalance;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        #region GetOfficeTypeEFS
        /// <summary>
        /// GetOfficeTypeEFS
        /// </summary>
        /// <param name="strElectionYear"></param>
        /// <returns></returns>
        internal IList<OfficeTypeModel> mapGetOfficeTypeEFSDALResponse(String strElectionYear)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<OfficeTypeModel> lstOfficeTypeModel = new List<OfficeTypeModel>();
                    OfficeTypeModel objOfficeTypeModel;

                    var results = client.GetOfficeTypeEFS(strElectionYear);

                    foreach (var item in results)
                    {
                        objOfficeTypeModel = new OfficeTypeModel();
                        objOfficeTypeModel.OfficeTypeId = item.OfficeTypeId;
                        objOfficeTypeModel.OfficeTypeDesc = item.OfficeTypeDesc;
                        lstOfficeTypeModel.Add(objOfficeTypeModel);
                    }
                    client.Close();
                    return lstOfficeTypeModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion GetOfficeTypeEFS

        /// <summary>
        /// Get Outstanding Fogiven
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        internal IList<OriginalAmountModel> GetOutstandingAmountLiabData_ForgivenDAL(String strFilingEntityId, String strTransNumber, String strFilingsId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<OriginalAmountModel> lstOriginalAmountModel = new List<OriginalAmountModel>();
                    OriginalAmountModel objOriginalAmountModel;

                    var results = client.GetOutstandingAmountLiabData_Forgiven(strFilingEntityId, strTransNumber, strFilingsId);

                    foreach (var item in results)
                    {
                        objOriginalAmountModel = new OriginalAmountModel();
                        objOriginalAmountModel.OriginalAmountId = item.OriginalAmountId;
                        objOriginalAmountModel.OutstandingAmount = item.OutstandingAmount;
                        lstOriginalAmountModel.Add(objOriginalAmountModel);
                    }
                    client.Close();
                    return lstOriginalAmountModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// Check Amend Status
        /// </summary>
        /// <param name="filings_ID"></param>
        /// <returns></returns>
        internal IList<CheckAmendStatusModel> GetAmendStatusDAL(FilingTransDataModel objFilingTransDataModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<CheckAmendStatusModel> lstCheckAmendStatusEntity = new List<CheckAmendStatusModel>();
                    CheckAmendStatusModel objCheckAmendStatusEntity;

                    FilingTransDataContract objFilingTransDataContract = new FilingTransDataContract();
                    objFilingTransDataContract.FilerId = objFilingTransDataModel.FilerId;
                    objFilingTransDataContract.ReportYearId = objFilingTransDataModel.ReportYearId;
                    objFilingTransDataContract.OfficeTypeId = objFilingTransDataModel.OfficeTypeId;
                    objFilingTransDataContract.DisclosurePeriod = objFilingTransDataModel.DisclosurePeriod;
                    objFilingTransDataContract.ElectionType = objFilingTransDataModel.ElectionType;
                    objFilingTransDataContract.ElectionDateId = objFilingTransDataModel.ElectionDateId;
                    objFilingTransDataContract.FilingDate = objFilingTransDataModel.FilingDate;

                    var results = client.GetAmendStatus(objFilingTransDataContract);

                    foreach (var item in results)
                    {
                        objCheckAmendStatusEntity = new CheckAmendStatusModel();
                        objCheckAmendStatusEntity.Submit_Date = item.Submit_Date.ToString();
                        objCheckAmendStatusEntity.IsAmend = item.IsAmend.ToString();
                        lstCheckAmendStatusEntity.Add(objCheckAmendStatusEntity);
                    }
                    client.Close();
                    return lstCheckAmendStatusEntity;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
           
            
        }

        /// <summary>
        /// GetExpSubContrTotAmtDAL
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal String GetExpSubContrTotAmtDAL(String strTransNumber, String filerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    String strExpSubContrTotAmt = String.Empty;

                    strExpSubContrTotAmt = client.GetExpSubContrTotAmt_LoanDetails(strTransNumber, filerID);
                    client.Close();
                    return strExpSubContrTotAmt;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// Get Edit Flag
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        internal IList<GetEditFlagDataModel> GetEditFlagDAL(FilingTransDataModel objFilingTransDataModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<GetEditFlagDataModel> lstGetEditFlagDataModel = new List<GetEditFlagDataModel>();
                    GetEditFlagDataModel objGetEditFlagDataModel;

                    FilingTransDataContract objFilingTransDataContract = new FilingTransDataContract();
                    objFilingTransDataContract.FilerId = objFilingTransDataModel.FilerId;
                    objFilingTransDataContract.ReportYearId = objFilingTransDataModel.ReportYearId;
                    objFilingTransDataContract.ElectionType = objFilingTransDataModel.ElectionType;
                    objFilingTransDataContract.OfficeTypeId = objFilingTransDataModel.OfficeTypeId;
                    objFilingTransDataContract.DisclosurePeriod = objFilingTransDataModel.DisclosurePeriod;
                    objFilingTransDataContract.FilingDate = objFilingTransDataModel.FilingDate;
                    objFilingTransDataContract.ElectionDateId = objFilingTransDataModel.ElectionDateId;
                    objFilingTransDataContract.Created_By = objFilingTransDataModel.Created_By;
                    objFilingTransDataContract.TransNumber = objFilingTransDataModel.TransNumber;
                    objFilingTransDataContract.MunicipalityID = objFilingTransDataModel.MunicipalityID;

                    var results = client.GetEditFlag(objFilingTransDataContract);

                    foreach (var item in results)
                    {
                        objGetEditFlagDataModel = new GetEditFlagDataModel();
                        objGetEditFlagDataModel.Is_Edit = item.Is_Edit.ToString();
                        lstGetEditFlagDataModel.Add(objGetEditFlagDataModel);
                    }
                    client.Close();
                    return lstGetEditFlagDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// ValidateFilingsDAL
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        internal IList<GetEditFlagDataModel> ValidateFilingsDAL(FilingTransDataModel objFilingTransDataModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<GetEditFlagDataModel> lstGetEditFlagDataModel = new List<GetEditFlagDataModel>();
                    GetEditFlagDataModel objGetEditFlagDataModel;

                    FilingTransDataContract objFilingTransDataContract = new FilingTransDataContract();
                    objFilingTransDataContract.FilerId = objFilingTransDataModel.FilerId;
                    objFilingTransDataContract.FilingDate = objFilingTransDataModel.FilingDate;

                    var results = client.ValidateFilings(objFilingTransDataContract);

                    foreach (var item in results)
                    {
                        objGetEditFlagDataModel = new GetEditFlagDataModel();
                        objGetEditFlagDataModel.VALIDATE_FILINGS = item.VALIDATE_FILINGS.ToString();
                        lstGetEditFlagDataModel.Add(objGetEditFlagDataModel);
                    }
                    client.Close();
                    return lstGetEditFlagDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// Add Viewable Column
        /// </summary>
        /// <param name="filer_ID"></param>
        /// <param name="created_By"></param>
        /// <returns></returns>
        internal Boolean AddViewableColumnDAL(string filer_ID, string created_By)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    Boolean result = client.AddViewableColumn(filer_ID, created_By);
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
        /// mapGetContrInKindPartnersDataDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<ContrInKindPartnersModel> GetLoanReceviedPartnersDataDAL(String strFilingTransId, String strFilerId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ContrInKindPartnersModel> lstContrInKindPartnersModel = new List<ContrInKindPartnersModel>();
                    ContrInKindPartnersModel objContrInKindPartnersModel;

                    var results = client.GetLoanReceviedPartnersData(strFilingTransId, strFilerId);

                    foreach (var item in results)
                    {
                        objContrInKindPartnersModel = new ContrInKindPartnersModel();
                        objContrInKindPartnersModel.FilingTransId = item.FilingTransId;
                        objContrInKindPartnersModel.FilingEntityId = item.FilingEntityId;
                        objContrInKindPartnersModel.PartnershipName = item.PartnershipName;
                        objContrInKindPartnersModel.PartnerFirstName = item.PartnerFirstName;
                        objContrInKindPartnersModel.PartnerMiddleName = item.PartnerMiddleName;
                        objContrInKindPartnersModel.PartnerLastName = item.PartnerLastName;
                        objContrInKindPartnersModel.PartnerStreetNo = item.PartnerStreetNo;
                        objContrInKindPartnersModel.PartnerStreetName = item.PartnerStreetName;
                        objContrInKindPartnersModel.PartnerCity = item.PartnerCity;
                        objContrInKindPartnersModel.PartnerState = item.PartnerState;
                        objContrInKindPartnersModel.PartnerZip5 = item.PartnerZip5;
                        objContrInKindPartnersModel.PartnershipCountry = item.PartnershipCountry;
                        objContrInKindPartnersModel.PartnerAmountAttributed = item.PartnerAmountAttributed;
                        objContrInKindPartnersModel.PartnerExplanation = item.PartnerExplanation;
                        objContrInKindPartnersModel.RItemized = item.RUnitemzied;
                        objContrInKindPartnersModel.TransNumber = item.TransNumber;
                        objContrInKindPartnersModel.TransMapping = item.TransMapping;
                        objContrInKindPartnersModel.TreasurerEmployer = item.TreasurerEmployer;
                        objContrInKindPartnersModel.TreasurerOccupation = item.TreasurerOccupation;
                        objContrInKindPartnersModel.TreaAddress = item.TreaAddress;
                        objContrInKindPartnersModel.TreaAddr1 = item.TreaAddr1;
                        objContrInKindPartnersModel.TreaCity = item.TreaCity;
                        objContrInKindPartnersModel.TreaState = item.TreaState;
                        objContrInKindPartnersModel.TreaZipCode = item.TreaZipCode;
                        objContrInKindPartnersModel.RContributions = item.RContributions;
                        lstContrInKindPartnersModel.Add(objContrInKindPartnersModel);
                    }
                    client.Close();
                    return lstContrInKindPartnersModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        /// <summary>
        /// Validate Loan Received delete
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        internal IList<GetEditFlagDataModel> ValidateLoanReceived_Delete_DAL(FilingTransDataModel objFilingTransDataModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<GetEditFlagDataModel> lstGetEditFlagDataModel = new List<GetEditFlagDataModel>();
                    GetEditFlagDataModel objGetEditFlagDataModel;

                    FilingTransDataContract objFilingTransDataContract = new FilingTransDataContract();
                    objFilingTransDataContract.Loan_Lib_Num = objFilingTransDataModel.Loan_Lib_Num;
                    objFilingTransDataContract.FilerId = objFilingTransDataModel.FilerId;
                    var results = client.ValidateLoanReceived_Delete(objFilingTransDataContract);

                    foreach (var item in results)
                    {
                        objGetEditFlagDataModel = new GetEditFlagDataModel();
                        objGetEditFlagDataModel.VALIDATE_FILINGS = item.VALIDATE_FILINGS.ToString();
                        lstGetEditFlagDataModel.Add(objGetEditFlagDataModel);
                    }
                    client.Close();
                    return lstGetEditFlagDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        #region mapGetExpPaymentExistsSchedLDALResponse
        /// <summary>
        /// mapGetExpPaymentExistsSchedLDALResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        internal String mapGetExpPaymentExistsSchedLDALResponse(String strTransNumber, String filerID, String strSchedID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    String results = client.GetExpPaymentExistsSchedL(strTransNumber, filerID, strSchedID);
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
        #endregion mapGetExpPaymentExistsSchedLDALResponse

        #region mapGetContributionsExistsSchedMDALResponse
        /// <summary>
        /// mapGetContributionsExistsSchedMDALResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        internal String mapGetContributionsExistsSchedMDALResponse(String strTransNumber, String filerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    String results = client.GetContributionsExistsSchedM(strTransNumber, filerID);
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
        #endregion mapGetContributionsExistsSchedMDALResponse

        #region mapGetFilingsSubmittedOrNotDALResponse
        /// <summary>
        /// mapGetFilingsSubmittedOrNotDALResponse
        /// </summary>
        /// <param name="strFilingsId"></param>
        /// <returns></returns>
        internal String mapGetFilingsSubmittedOrNotDALResponse(String strFilingsId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    String strExists = client.GetFilingsSubmittedOrNot(strFilingsId);
                    client.Close();
                    return strExists;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetFilingsSubmittedOrNotDALResponse

        #region mpaGetExpRefundedSchedFTotalAmtDALResponse
        /// <summary>
        /// mpaGetExpRefundedSchedFTotalAmtDALResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        internal String mpaGetExpRefundedSchedFTotalAmtDALResponse(String strTransNumber, String filerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    String strExpRefundedAmt = client.GetExpRefundedSchedFTotalAmt(strTransNumber, filerID);
                    client.Close();
                    return strExpRefundedAmt;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mpaGetExpRefundedSchedFTotalAmtDALResponse

        #region mapGetContrRefundedSchedABCTotalAmtDALResponse
        /// <summary>
        /// mapGetContrRefundedSchedABCTotalAmtDALResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        internal String mapGetContrRefundedSchedABCTotalAmtDALResponse(String strTransNumber, String filerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    String strContrRefundedAmt = client.GetContrRefundedSchedABCTotalAmt(strTransNumber, filerID);
                    client.Close();
                    return strContrRefundedAmt;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetContrRefundedSchedABCTotalAmtDALResponse

        #region mapGetCommEditIETransDataDALResponse
        /// <summary>
        /// mapGetCommEditIETransDataDALResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetCommEditIETransDataDALResponse(String strTransNumber, String filerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                    FilingTransactionDataModel objFilingTransactionDataModel;

                    var results = client.GetCommEditIETransData(strTransNumber, filerID);

                    foreach (var item in results)
                    {
                        objFilingTransactionDataModel = new FilingTransactionDataModel();
                        objFilingTransactionDataModel.FilingTransId = item.FilingTransId;
                        objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                        objFilingTransactionDataModel.ContributorTypeId = item.ContributorTypeId;
                        objFilingTransactionDataModel.ContributorTypeDesc = item.ContributorTypeDesc;
                        objFilingTransactionDataModel.PaymentTypeId = item.PaymentTypeId;
                        objFilingTransactionDataModel.SubmissionDate = item.SubmissionDate;
                        objFilingTransactionDataModel.SchedDate = item.SchedDate;
                        objFilingTransactionDataModel.FilingSchedDesc = item.FilingSchedDesc;
                        objFilingTransactionDataModel.FilingEntityId = item.FilingEntityId;
                        objFilingTransactionDataModel.FilingEntityName = item.FilingEntityName;
                        objFilingTransactionDataModel.FilingFirstName = item.FilingFirstName;
                        objFilingTransactionDataModel.FilingMiddleName = item.FilingMiddleName;
                        objFilingTransactionDataModel.FilingLastName = item.FilingLastName;
                        objFilingTransactionDataModel.FilingStreetNumber = item.FilingStreetNumber;
                        objFilingTransactionDataModel.FilingStreetName = item.FilingStreetName;
                        objFilingTransactionDataModel.FilingCity = item.FilingCity;
                        objFilingTransactionDataModel.FilingState = item.FilingState;
                        objFilingTransactionDataModel.FilingZip = item.FilingZip;
                        objFilingTransactionDataModel.FilingCountry = item.FilingCountry;
                        objFilingTransactionDataModel.PaymentTypeDesc = item.PaymentTypeDesc;
                        objFilingTransactionDataModel.PayNumber = item.PayNumber;
                        objFilingTransactionDataModel.OriginalAmount = item.OriginalAmount;
                        objFilingTransactionDataModel.TransExplanation = item.TransExplanation;
                        objFilingTransactionDataModel.RItemized = item.RItemized;
                        objFilingTransactionDataModel.CountyDesc = item.CountyDesc;
                        objFilingTransactionDataModel.RAmend = item.RAmend;
                        objFilingTransactionDataModel.Status = item.RStatus;
                        objFilingTransactionDataModel.MunicipalityDesc = item.MunicipalityDesc;
                        objFilingTransactionDataModel.LoanerCodeID = item.LoanerCodeID;
                        objFilingTransactionDataModel.LoanerCode = item.LoanerCode;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.CreatedDate = item.CreatedDate;
                        objFilingTransactionDataModel.TreasurerFirstName = item.TreasurerFirstName;
                        objFilingTransactionDataModel.TreasurerLastName = item.TreasurerLastName;
                        objFilingTransactionDataModel.TreasurerMiddleName = item.TreasurerMiddleName;
                        objFilingTransactionDataModel.TreasurerOccuptaion = item.TreasurerOccuptaion;
                        objFilingTransactionDataModel.TreasurerEmployer = item.TreasurerEmployer;
                        objFilingTransactionDataModel.TreasurerStreetAddress = item.TreasurerStreetAddress;
                        objFilingTransactionDataModel.TreasurerCity = item.TreasurerCity;
                        objFilingTransactionDataModel.TreasurerState = item.TreasurerState;
                        objFilingTransactionDataModel.TreasurerZip = item.TreasurerZip;
                        objFilingTransactionDataModel.ContributorOccupation = item.ContributorOccupation;
                        objFilingTransactionDataModel.ContributorEmployer = item.ContributorEmployer;
                        objFilingTransactionDataModel.IEDescription = item.IEDescription;
                        objFilingTransactionDataModel.CandBallotPropReference = item.CandBallotPropReference;
                        objFilingTransactionDataModel.IESupported = item.IESupported;
                        objFilingTransactionDataModel.AddrId = item.AddrId;
                        objFilingTransactionDataModel.TreasId = item.TreasId;
                        objFilingTransactionDataModel.LoanLiablityNumber = item.LoanLiablityNumber;
                        objFilingTransactionDataModel.TransNumber = item.TransNumber;
                        objFilingTransactionDataModel.TransMapping = item.TransMapping;
                        objFilingTransactionDataModel.DateIncurredOrgAmtId = item.DateIncurredOrgAmtId;
                        objFilingTransactionDataModel.RLiability = item.RLiability;
                        objFilingTransactionDataModel.RSubcontractor = item.RSubcontractor;
                        objFilingTransactionDataModel.OwedAmount = item.OwedAmount;
                        objFilingTransactionDataModel.PurposeCodeId = item.PurposeCodeId;
                        lstFilingTransactionDataModel.Add(objFilingTransactionDataModel);
                    }
                    client.Close();
                    return lstFilingTransactionDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
           
            
        }
        #endregion mapGetCommEditIETransDataDALResponse

        #region mapLiabilityPrevFlngsOrgAutoCreatedExtsDALResponse
        /// <summary>
        /// mapLiabilityPrevFlngsOrgAutoCreatedExtsDALResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <param name="strFilingsId"></param>
        /// <returns></returns>
        internal String mapLiabilityPrevFlngsOrgAutoCreatedExtsDALResponse(String strTransNumber, String strFilingsId, String filerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    String strExists = String.Empty;

                    strExists = client.LiabilityPrevFlngsOrgAutoCreatedExts(strTransNumber, strFilingsId, filerID);
                    client.Close();
                    return strExists;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapLiabilityPrevFlngsOrgAutoCreatedExtsDALResponse

        #region mapAddNonItemSetPrefPerFilerDALResponse
        /// <summary>
        /// mapAddNonItemSetPrefPerFilerDALResponse
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <param name="strCreatedBy"></param>
        /// <returns></returns>
        internal Boolean mapAddNonItemSetPrefPerFilerDALResponse(String strFilerId, String strFilingTypeId, String strCreatedBy)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    Boolean returnValue = client.AddNonItemSetPrefPerFiler(strFilerId, strFilingTypeId, strCreatedBy);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapAddNonItemSetPrefPerFilerDALResponse

        #region mapGetEFSPDFBytesDALResponse
        /// <summary>
        /// mapGetEFSPDFBytesDALResponse
        /// </summary>
        /// <param name="objEFSPDFRequestModel"></param>
        /// <returns></returns>
        internal EFSPDFResponseModel mapGetEFSPDFBytesDALResponse(EFSPDFRequestModel objEFSPDFRequestModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    EFSPDFResponseModel objEFSPDFResponseModel = new EFSPDFResponseModel();

                    EFSPDFRequestContract objEFSPDFRequestContract = new EFSPDFRequestContract();

                    objEFSPDFRequestContract.ReportName = objEFSPDFRequestModel.ReportName;
                    objEFSPDFRequestContract.FilerId = objEFSPDFRequestModel.FilerId;
                    objEFSPDFRequestContract.ElectionYearId = objEFSPDFRequestModel.ElectionYearId;
                    objEFSPDFRequestContract.OfficeTypeId = objEFSPDFRequestModel.OfficeTypeId;
                    objEFSPDFRequestContract.FilingTypeId = objEFSPDFRequestModel.FilingTypeId;
                    objEFSPDFRequestContract.FilingDate = objEFSPDFRequestModel.FilingDate;
                    objEFSPDFRequestContract.ElectionTypeID = objEFSPDFRequestModel.ElectionTypeID;
                    objEFSPDFRequestContract.ElectionDateID = objEFSPDFRequestModel.ElectionDateID;
                    objEFSPDFRequestContract.SubmitDate = objEFSPDFRequestModel.SubmitDate;

                    // Add parameters if required            

                    var results = client.GetEFSPDFBytes(objEFSPDFRequestContract);

                    if (results != null)
                    {
                        objEFSPDFResponseModel.fileByte = results.fileByte;
                        objEFSPDFResponseModel.fileURL = results.fileURL;
                    }
                    client.Close();
                    return objEFSPDFResponseModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion mapGetEFSPDFBytesDALResponse

        #region GetImportDisclosureRptsDataDALResponse
        /// <summary>
        /// GetImportDisclosureRptsDataDALResponse
        /// </summary>
        /// <param name="txtFilerID"></param>
        /// <param name="strReportYear"></param>
        /// <returns></returns>
        public IList<ImportDisclosureRptsData> GetImportDisclosureRptsDataDALResponse(String txtFilerID, String strReportYear)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    List<ImportDisclosureRptsData> lstImportDisclosureRptsData = new List<ImportDisclosureRptsData>();
                    ImportDisclosureRptsData objImportDisclosureRptsData;

                    var results = client.GetImportDisclosureRptsData(txtFilerID, strReportYear);

                    foreach (var item in results)
                    {
                        objImportDisclosureRptsData = new ImportDisclosureRptsData();
                        objImportDisclosureRptsData.DateImported = item.DateImported;
                        objImportDisclosureRptsData.TransactionType = item.TransactionType;
                        objImportDisclosureRptsData.ReportYear = item.ReportYear;
                        objImportDisclosureRptsData.FilerType = item.FilerType;
                        objImportDisclosureRptsData.ReportType = item.ReportType;
                        if (item.ElectionTypeId == "4") // IF PERIODIC NOT SHOWING ELECTION DATE.
                            objImportDisclosureRptsData.ElectionDate = "";
                        else
                            objImportDisclosureRptsData.ElectionDate = item.ElectionDate;
                        objImportDisclosureRptsData.DisclosurePeriod = item.DisclosurePeriod;
                        objImportDisclosureRptsData.SubmissionStatus = item.SubmissionStatus;
                        objImportDisclosureRptsData.FileSize = item.FileSize;
                        objImportDisclosureRptsData.NoOfTrans = item.NoOfTrans;
                        objImportDisclosureRptsData.ElectionYearId = item.ElectionYearId;
                        objImportDisclosureRptsData.OfficeTypeId = item.OfficeTypeId;
                        objImportDisclosureRptsData.ElectionTypeId = item.ElectionTypeId;
                        objImportDisclosureRptsData.ElectionDateId = item.ElectionDateId;
                        objImportDisclosureRptsData.FilingTypeId = item.FilingTypeId;
                        objImportDisclosureRptsData.FilingCategoryId = item.FilingCategoryId;
                        objImportDisclosureRptsData.VendorName = item.VendorName;
                        lstImportDisclosureRptsData.Add(objImportDisclosureRptsData);
                    }
                    client.Close();
                    return lstImportDisclosureRptsData;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
           
            
        }
        #endregion GetImportDisclosureRptsDataDALResponse

        #region GetVendorNamesDataDALResponse
        /// <summary>
        /// GetVendorNamesDataDALResponse
        /// </summary>
        /// <returns></returns>
        public IList<VendorNames> GetVendorNamesDataDALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    List<VendorNames> lstVendorNames = new List<VendorNames>();
                    VendorNames objVendorNames;

                    var results = client.GetVendorNamesData();

                    foreach (var item in results)
                    {
                        objVendorNames = new VendorNames();
                        objVendorNames.VendorId = item.VendorId;
                        objVendorNames.VendorName = item.VendorName;
                        lstVendorNames.Add(objVendorNames);
                    }
                    client.Close();
                    return lstVendorNames;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion GetVendorNamesDataDALResponse

        #region GetFilingDateCheckValuesDALResponse
        /// <summary>
        /// GetFilingDateCheckValues
        /// </summary>
        /// <param name="GetFilingDateCheckValuesDALResponse"></param>
        /// <returns></returns>
        public IList<CheckFilingDateModel> GetFilingDateCheckValuesDALResponse(String filingPeriodID, String electID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    ImportDisclsoureRptsFilingsContract objImportDisclsoureRptsFilingsContract = new ImportDisclsoureRptsFilingsContract();
                    IList<CheckFilingDateModel> lstCheckFilingDateModel = new List<CheckFilingDateModel>();
                    CheckFilingDateModel objCheckFilingDateModel;

                    objImportDisclsoureRptsFilingsContract.FilingPeriodId = filingPeriodID;
                    objImportDisclsoureRptsFilingsContract.ElectId = electID;

                    var results = client.GetFilingDateCheckValues(objImportDisclsoureRptsFilingsContract);

                    foreach (var item in results)
                    {
                        objCheckFilingDateModel = new CheckFilingDateModel();
                        objCheckFilingDateModel.ElectionYearId = item.ElectionYearId;
                        objCheckFilingDateModel.ElectionTypeId = item.ElectionTypeId;
                        objCheckFilingDateModel.OfficeTypeId = item.OfficeTypeId;
                        objCheckFilingDateModel.FilingTypeId = item.FilingTypeId;
                        objCheckFilingDateModel.ElectionDateId = item.ElectionDateId;
                        lstCheckFilingDateModel.Add(objCheckFilingDateModel);
                    }
                    client.Close();
                    return lstCheckFilingDateModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion GetFilingDateCheckValuesDALResponse

        #region GetFilingsIdForUploadDataDALResponse
        /// <summary>
        /// GetFilingsIdForUploadDataDALResponse
        /// </summary>
        /// <param name="objImportDisclsoureRptsFilings"></param>
        /// <returns></returns>
        public IList<FilingsForFilingCutOffDate> GetFilingsIdForUploadDataDALResponse(String filerID, String filingPeriodID,
                                                                                   String filingCategoryID, String electID,
                                                                                   String resigTermTypeID, String rFilingDate,
                                                                                   String createdBy)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    ImportDisclsoureRptsFilingsContract objImportDisclsoureRptsFilingsContract = new ImportDisclsoureRptsFilingsContract();
                    IList<FilingsForFilingCutOffDate> lstFilingsForFilingCutOffDate = new List<FilingsForFilingCutOffDate>();
                    FilingsForFilingCutOffDate objFilingsForFilingCutOffDate;

                    objImportDisclsoureRptsFilingsContract.FilerId = filerID;
                    objImportDisclsoureRptsFilingsContract.FilingPeriodId = filingPeriodID;
                    objImportDisclsoureRptsFilingsContract.FilingCategoryId = filingCategoryID;
                    objImportDisclsoureRptsFilingsContract.ElectId = electID;
                    objImportDisclsoureRptsFilingsContract.ResigTermTypeId = resigTermTypeID;
                    objImportDisclsoureRptsFilingsContract.RFilingDate = rFilingDate;
                    objImportDisclsoureRptsFilingsContract.CreatedBy = createdBy;

                    var results = client.GetFilingsIdForUploadData(objImportDisclsoureRptsFilingsContract);

                    foreach (var item in results)
                    {
                        objFilingsForFilingCutOffDate = new FilingsForFilingCutOffDate();
                        objFilingsForFilingCutOffDate.FilingsId = item.FilingsId;
                        objFilingsForFilingCutOffDate.ElectionYearId = item.ElectionYearId;
                        objFilingsForFilingCutOffDate.ElectionTypeId = item.ElectionTypeId;
                        objFilingsForFilingCutOffDate.OfficeTypeId = item.OfficeTypeId;
                        objFilingsForFilingCutOffDate.FilingTypeId = item.FilingTypeId;
                        objFilingsForFilingCutOffDate.ElectionDateId = item.ElectionDateId;
                        objFilingsForFilingCutOffDate.FilingDate = item.FilingDate;
                        lstFilingsForFilingCutOffDate.Add(objFilingsForFilingCutOffDate);
                    }
                    client.Close();
                    return lstFilingsForFilingCutOffDate;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion GetFilingsIdForUploadDataDALResponse

        #region GetFilingsExistsorNotDALResponse
        /// <summary>
        /// GetFilingsExistsorNotDALResponse
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <returns></returns>
        public String GetFilingsExistsorNotDALResponse(String strFilerId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    var results = client.GetFilingsExistsorNot(strFilerId);
                    client.Close();
                    return results.ToString();

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion GetFilingsExistsorNotDALResponse

        #region LoanLiabilityExistsDALResponse
        /// <summary>
        /// LoanLiabilityExistsDALResponse
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strTransNumber"></param>
        /// <param name="strLoanLiabilityNumber"></param>
        /// <returns></returns>
        public Boolean LoanLiabilityExistsDALResponse(String strFilerId, String strTransNumber, String strLoanLiabilityNumber)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    Boolean results = client.LoanLiabilityExists(strFilerId, strTransNumber, strLoanLiabilityNumber);
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
        #endregion LoanLiabilityExistsDALResponse

        #region AddVendorImportFileIntoTempDatabaseDALResponse
        /// <summary>
        /// AddVendorImportFileIntoTempDatabaseDALResponse
        /// </summary>
        /// <param name="lstFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean AddVendorImportFileIntoTempDatabaseDALResponse(IList<FilingTransactionsModel> lstFilingTransactionsModel, VendorImportDataModel objVendorImportDataModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingTransactionsContract> lstFilingTransactionsContract = new List<FilingTransactionsContract>();
                    FilingTransactionsContract objFilingTransactionsContract;
                    VendorImportDataContract objVendorImportDataContract;

                    foreach (var item in lstFilingTransactionsModel)
                    {
                        objFilingTransactionsContract = new FilingTransactionsContract(); 
                        objFilingTransactionsContract.FlngEntName = item.FlngEntName;
                        objFilingTransactionsContract.FlngEntFirstName = item.FlngEntFirstName;
                        objFilingTransactionsContract.FlngEntMiddleName = item.FlngEntMiddleName;
                        objFilingTransactionsContract.FlngEntLastName = item.FlngEntLastName;
                        objFilingTransactionsContract.FlngEntStrName = item.FlngEntStrName;
                        objFilingTransactionsContract.FlngEntCity = item.FlngEntCity;
                        objFilingTransactionsContract.FlngEntState = item.FlngEntState;
                        objFilingTransactionsContract.FlngEntZip = item.FlngEntZip;
                        objFilingTransactionsContract.FlngEntCountry = item.FlngEntCountry;
                        objFilingTransactionsContract.Loan_Lib_Number = item.Loan_Lib_Number;
                        objFilingTransactionsContract.TransNumber = item.TransNumber;
                        objFilingTransactionsContract.TransMapping = item.TransMapping;
                        objFilingTransactionsContract.FilingsId = item.FilingsId;
                        objFilingTransactionsContract.FilingSchedId = item.FilingSchedId;
                        objFilingTransactionsContract.ContributorTypeId = item.ContributorTypeId;
                        objFilingTransactionsContract.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionsContract.PaymentTypeId = item.PaymentTypeId;
                        objFilingTransactionsContract.ReceiptTypeId = item.ReceiptTypeId;
                        objFilingTransactionsContract.PurposeCodeId = item.PurposeCodeId;
                        objFilingTransactionsContract.TransferTypeId = item.TransferTypeId;
                        objFilingTransactionsContract.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionsContract.LoanOtherId = item.LoanOtherId;
                        objFilingTransactionsContract.MunicipalityID = item.MunicipalityID;
                        objFilingTransactionsContract.TreasId = item.TreasId;
                        objFilingTransactionsContract.AddrId = item.AddrId;
                        objFilingTransactionsContract.ParentFilingEntityId = item.ParentFilingEntityId;
                        objFilingTransactionsContract.OfficeID = item.OfficeID;
                        objFilingTransactionsContract.DistrictID = item.DistrictID;
                        objFilingTransactionsContract.SchedDate = item.SchedDate;
                        objFilingTransactionsContract.OrgDate = item.OrgDate;
                        objFilingTransactionsContract.PayNumber = item.PayNumber;
                        objFilingTransactionsContract.OrgAmt = item.OrgAmt;
                        objFilingTransactionsContract.OwedAmt = item.OwedAmt;
                        objFilingTransactionsContract.TransExplanation = item.TransExplanation;
                        objFilingTransactionsContract.ElectionYear = item.ElectionYear;
                        objFilingTransactionsContract.RBankLoan = item.RBankLoan;
                        objFilingTransactionsContract.DistOffCandBalProp = item.DistOffCandBalProp;
                        objFilingTransactionsContract.ContributorOccupation = item.ContributorOccupation;
                        objFilingTransactionsContract.ContributorEmployer = item.ContributorEmployer;
                        objFilingTransactionsContract.IEDescription = item.IEDescription;
                        objFilingTransactionsContract.TreasurerOccupation = item.TreasurerOccupation;
                        objFilingTransactionsContract.TreasurerEmployer = item.TreasurerEmployer;
                        objFilingTransactionsContract.TreasurerStreetAddress = item.TreasurerStreetAddress;
                        objFilingTransactionsContract.TreasurerCity = item.TreasurerCity;
                        objFilingTransactionsContract.TreasurerState = item.TreasurerState;
                        objFilingTransactionsContract.TreasurerZip = item.TreasurerZip;
                        objFilingTransactionsContract.ExistsLiabTransNumber = item.ExistsLiabTransNumber;
                        objFilingTransactionsContract.RIESupported = item.RIESupported;
                        objFilingTransactionsContract.RSubcontractor = item.IsExpSubcontractor;
                        objFilingTransactionsContract.RLiability = item.RLiability;
                        objFilingTransactionsContract.RItemized = item.RItemized;
                        objFilingTransactionsContract.RIEIncluded = item.RIEIncluded;
                        objFilingTransactionsContract.RAmend = item.RAmend;
                        objFilingTransactionsContract.CreatedBy = item.CreatedBy;
                        objFilingTransactionsContract.RParent = item.RParent;
                        objFilingTransactionsContract.IsClaim = item.IsClaim;
                        objFilingTransactionsContract.InDistrict = item.InDistrict;
                        objFilingTransactionsContract.Minor = item.Minor;
                        objFilingTransactionsContract.Vendor = item.Vendor;
                        objFilingTransactionsContract.Lobbyist = item.Lobbyist;
                        objFilingTransactionsContract.RContributions = item.RContributions;
                        objFilingTransactionsContract.SupportOppose = item.SupportOppose;
                        lstFilingTransactionsContract.Add(objFilingTransactionsContract);
                    }

                    objVendorImportDataContract = new VendorImportDataContract();
                    objVendorImportDataContract.FilingsId = objVendorImportDataModel.FilingsId;
                    objVendorImportDataContract.VendorId = objVendorImportDataModel.VendorId;
                    objVendorImportDataContract.VendorFileSize = objVendorImportDataModel.VendorFileSize;
                    objVendorImportDataContract.VendorTransCount = objVendorImportDataModel.VendorTransCount;
                    objVendorImportDataContract.CreatedBy = objVendorImportDataModel.CreatedBy;
                    objVendorImportDataContract.dtCreatedDate = objVendorImportDataModel.dtCreatedDate;
                    objVendorImportDataContract.strLastSetOfTrans = objVendorImportDataModel.strLastSetOfTrans;

                    var arrayFilingTransactionsContract = new List<FilingTransactionsContract>(lstFilingTransactionsContract).ToArray();

                    Boolean returnValue = client.AddVendorImportFileIntoTempDatabase(arrayFilingTransactionsContract, objVendorImportDataContract);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion AddVendorImportFileIntoTempDatabaseDALResponse

        /// <summary>
        /// GetSchedR_Exists
        /// </summary>
        /// <param name="objSchedR_ISExists_Entity"></param>
        /// <returns></returns>
        internal String GetSchedR_Exists_DAL(SchedR_ISExists_Model objSchedR_ISExists_Model)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    SchedR_ISExists_Contract objSchedR_ISExists_Contract = new SchedR_ISExists_Contract();
                    objSchedR_ISExists_Contract.FilerId = objSchedR_ISExists_Model.FilerId;
                    objSchedR_ISExists_Contract.ReportYearId = objSchedR_ISExists_Model.ReportYearId;
                    objSchedR_ISExists_Contract.Filing_Enty_First_Name = objSchedR_ISExists_Model.Filing_Enty_First_Name;
                    objSchedR_ISExists_Contract.Filing_Enty_Middle_Name = objSchedR_ISExists_Model.Filing_Enty_Middle_Name;
                    objSchedR_ISExists_Contract.Filing_Enty_Last_Name = objSchedR_ISExists_Model.Filing_Enty_Last_Name;
                    objSchedR_ISExists_Contract.Office_Id = objSchedR_ISExists_Model.Office_Id;
                    objSchedR_ISExists_Contract.District_Id = objSchedR_ISExists_Model.District_Id;

                    String results = client.GetSchedR_Exists(objSchedR_ISExists_Contract);
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
        /// GetFilerCommitteeTypeId
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <returns></returns>
        internal String GetFilerCommitteeTypeId(String strFilerId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    String strCommitteeTypeId = client.GetFilerCommitteeTypeId(strFilerId);
                    client.Close();
                    return strCommitteeTypeId;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        internal IList<DisclosurePreiodModel> mapGetDisclosurePeriodDataDALResponseForNoActivity(String strFilerID, String strPolCalDateID, String strElectTypeId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<DisclosurePreiodModel> lstDisclosurePreiodModel = new List<DisclosurePreiodModel>();
                    DisclosurePreiodModel objDisclosurePreiodModel;

                    var results = client.GetDisclosurePeriodDataForNoActivity(strFilerID, strPolCalDateID, strElectTypeId);

                    foreach (var item in results)
                    {
                        objDisclosurePreiodModel = new DisclosurePreiodModel();
                        objDisclosurePreiodModel.FilingTypeId = item.FilingTypeId;
                        objDisclosurePreiodModel.FilingDesc = item.FilingDesc;
                        objDisclosurePreiodModel.FilingAbbrev = item.FilingAbbrev;
                        lstDisclosurePreiodModel.Add(objDisclosurePreiodModel);
                    }
                    client.Close();
                    return lstDisclosurePreiodModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        #region GetMunicipalityByOfficeType
        /// <summary>
        /// GetMunicipalityByOfficeType
        /// </summary>
        /// <param name="strCountyId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <returns></returns>
        // GetMunicipalityByOfficeType
        internal IList<MunicipalityModel> GetMunicipalityByOfficeType(String strCountyId, String strOfficeTypeId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<MunicipalityModel> lstMunicipalityEntity = new List<MunicipalityModel>();
                    MunicipalityModel objMunicipalityEntity;

                    var results = client.GetMunicipalityByOfficeType(strCountyId, strOfficeTypeId);

                    foreach (var item in results)
                    {
                        objMunicipalityEntity = new MunicipalityModel();
                        objMunicipalityEntity.MunicipalityId = item.MunicipalityId;
                        objMunicipalityEntity.MunicipalityDesc = item.MunicipalityDesc;
                        lstMunicipalityEntity.Add(objMunicipalityEntity);
                    }
                    client.Close();
                    return lstMunicipalityEntity;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion GetMunicipalityByOfficeType

        #region "mapGetCountyDALResponse"
        // THIS FUNCTION GETS THE DATA FOR THE COUNTY FILTER DROPDOWN
        /// <summary>
        /// GetCountyForFilingsDAL
        /// </summary>
        /// <param name="elect_Year_ID"></param>
        /// <param name="filer_ID"></param>
        /// <returns></returns>
        internal IEnumerable<County> GetCountyForFilingsDAL(string elect_Year_ID, string filer_ID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<County> listCounty = new List<County>();
                    County objCounty;

                    var results = client.GetCountyForFilings(elect_Year_ID, filer_ID);

                    foreach (var item in results)
                    {
                        objCounty = new County();
                        objCounty.CountyID = item.CountyId;
                        objCounty.CountyBoard = item.CountyDesc;
                        listCounty.Add(objCounty);
                    }
                    client.Close();
                    return listCounty;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
        }
        #endregion

        /// <summary>
        /// Get Loan Outstanding balance
        /// </summary>
        /// <param name="loan_Lib_number"></param>
        /// <param name="strFilerId"></param>
        /// <returns></returns>
        internal String FilingTransactionOutStandingBalanceDAL(String loan_Lib_number, String strFilerId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {
                    String strOutstandingBalance = client.FilingTransactionOutStandingBalance(loan_Lib_number, strFilerId);
                    client.Close();
                    return strOutstandingBalance;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }

        }

        #region AddVendorImportFileForSchedADAL
        /// <summary>
        /// AddVendorImportFileIntoTempDatabaseDALResponse
        /// </summary>
        /// <param name="lstFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean AddVendorImportFileForSchedADAL(IList<FilingTransactionsModel> lstFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingTransactionsContract> lstFilingTransactionsContract = new List<FilingTransactionsContract>();
                    FilingTransactionsContract objFilingTransactionsContract;

                    foreach (var item in lstFilingTransactionsModel)
                    {
                        objFilingTransactionsContract = new FilingTransactionsContract();

                        objFilingTransactionsContract.FilerId = item.FilerId;
                        objFilingTransactionsContract.ElectYearId = item.ElectYearId;
                        objFilingTransactionsContract.OfficeTypeId = item.OfficeTypeId;
                        objFilingTransactionsContract.ElectionTypeId = item.ElectionTypeId;
                        objFilingTransactionsContract.ElectionDateId = item.ElectionDateId;
                        objFilingTransactionsContract.FilingTypeId = item.FilingTypeId;
                        objFilingTransactionsContract.ResigTermTypeId = item.ResigTermTypeId;
                        objFilingTransactionsContract.FilingDate = item.FilingDate;
                        objFilingTransactionsContract.CreatedBy = item.CreatedBy;
                        objFilingTransactionsContract.SchedDate = item.SchedDate;
                        objFilingTransactionsContract.ContributorTypeDesc = item.ContributorTypeDesc;
                        objFilingTransactionsContract.FlngEntFirstName = item.FlngEntFirstName;
                        objFilingTransactionsContract.FlngEntMiddleName = item.FlngEntMiddleName;
                        objFilingTransactionsContract.FlngEntLastName = item.FlngEntLastName;
                        objFilingTransactionsContract.FlngEntName = item.FlngEntName;
                        objFilingTransactionsContract.FlngEntCountry = item.FlngEntCountry;
                        objFilingTransactionsContract.FlngEntStrName = item.FlngEntStrName;
                        objFilingTransactionsContract.FlngEntCity = item.FlngEntCity;
                        objFilingTransactionsContract.FlngEntState = item.FlngEntState;
                        objFilingTransactionsContract.FlngEntZip = item.FlngEntZip;
                        objFilingTransactionsContract.PaymentTypeDesc = item.PaymentTypeDesc;
                        objFilingTransactionsContract.PayNumber = item.PayNumber;
                        objFilingTransactionsContract.OrgAmt = item.OrgAmt;
                        objFilingTransactionsContract.TransExplanation = item.TransExplanation;
                        objFilingTransactionsContract.Unique_Num = item.Unique_Num;
                        objFilingTransactionsContract.IsClaim = item.IsClaim;
                        objFilingTransactionsContract.InDistrict = item.InDistrict;
                        objFilingTransactionsContract.Minor = item.Minor;
                        objFilingTransactionsContract.Vendor = item.Vendor;
                        objFilingTransactionsContract.Lobbyist = item.Lobbyist;
                        objFilingTransactionsContract.RContributions = item.RContributions;
                        objFilingTransactionsContract.TreasurerEmployer = item.TreasurerEmployer;
                        objFilingTransactionsContract.TreasurerOccupation = item.TreasurerOccupation;
                        objFilingTransactionsContract.TreasurerStreetAddress = item.TreasurerStreetAddress;
                        objFilingTransactionsContract.TreasurerCity = item.TreasurerCity;
                        objFilingTransactionsContract.TreasurerState = item.TreasurerState;
                        objFilingTransactionsContract.TreasurerZip = item.TreasurerZip;

                        lstFilingTransactionsContract.Add(objFilingTransactionsContract);
                    }

                    var arrayFilingTransactionsContract = new List<FilingTransactionsContract>(lstFilingTransactionsContract).ToArray();

                    Boolean returnValue = client.AddVendorImportFileForSchedA(arrayFilingTransactionsContract);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }


        }
        #endregion AddVendorImportFileForSchedA

        /// <summary>
        /// DowloadHelpDocumentPDFFileDAL()
        /// </summary>
        /// <returns></returns>
        internal List<EFSPDFResponseModel> DowloadHelpDocumentPDFFileDAL()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {
                    List<EFSPDFResponseModel> lstEFSPDFResponseModel = new List<EFSPDFResponseModel>();
                    Models.EFSPDFResponseModel objEFSPDFResponseModel = new Models.EFSPDFResponseModel();
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                    var result = client.GetFileinByteFormat();
                    foreach (var item in result)
                    {
                        objEFSPDFResponseModel = new Models.EFSPDFResponseModel();
                        objEFSPDFResponseModel.fileByte = item.fileByte;
                        objEFSPDFResponseModel.fileName = item.fileName;
                        lstEFSPDFResponseModel.Add(objEFSPDFResponseModel);
                    }
                    client.Close();
                    return lstEFSPDFResponseModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }            
        }

        /// <summary>
        /// DowloadHelpDocumentPDFFileDAL()
        /// </summary>
        /// <returns></returns>
        internal List<EFSPDFResponseModel> DownloadPCFHelpDocumentPDF()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {
                    List<EFSPDFResponseModel> lstEFSPDFResponseModel = new List<EFSPDFResponseModel>();
                    Models.EFSPDFResponseModel objEFSPDFResponseModel = new Models.EFSPDFResponseModel();
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                    var result = client.GetFileinByteFormatPCF();
                    foreach (var item in result)
                    {
                        objEFSPDFResponseModel = new Models.EFSPDFResponseModel();
                        objEFSPDFResponseModel.fileByte = item.fileByte;
                        objEFSPDFResponseModel.fileName = item.fileName;
                        lstEFSPDFResponseModel.Add(objEFSPDFResponseModel);
                    }
                    client.Close();
                    return lstEFSPDFResponseModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
        }

        /// <summary>
        /// DowloadHelpDocumentPDFFileDAL()
        /// </summary>
        /// <returns></returns>
        internal List<EFSPDFResponseModel> DownloadSchedAImportTemplate()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {
                    List<EFSPDFResponseModel> lstEFSPDFResponseModel = new List<EFSPDFResponseModel>();
                    Models.EFSPDFResponseModel objEFSPDFResponseModel = new Models.EFSPDFResponseModel();
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                    var result = client.GetTemplateinByteFormat();
                    foreach (var item in result)
                    {
                        objEFSPDFResponseModel = new Models.EFSPDFResponseModel();
                        objEFSPDFResponseModel.fileByte = item.fileByte;
                        objEFSPDFResponseModel.fileName = item.fileName;
                        lstEFSPDFResponseModel.Add(objEFSPDFResponseModel);
                    }
                    client.Close();
                    return lstEFSPDFResponseModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
        }

        /// <summary>
        /// DowloadHelpDocumentPDFFileDAL()
        /// </summary>
        /// <returns></returns>
        internal List<EFSPDFResponseModel> DownloadSchedAImportPCFTemplate()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {
                    List<EFSPDFResponseModel> lstEFSPDFResponseModel = new List<EFSPDFResponseModel>();
                    Models.EFSPDFResponseModel objEFSPDFResponseModel = new Models.EFSPDFResponseModel();
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                    var result = client.GetTemplateinByteFormatPCF();
                    foreach (var item in result)
                    {
                        objEFSPDFResponseModel = new Models.EFSPDFResponseModel();
                        objEFSPDFResponseModel.fileByte = item.fileByte;
                        objEFSPDFResponseModel.fileName = item.fileName;
                        lstEFSPDFResponseModel.Add(objEFSPDFResponseModel);
                    }
                    client.Close();
                    return lstEFSPDFResponseModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
        }

        #region GetTransactionTypesForWeeklyClaimBrokerDAL
        /// <summary>
        /// GetTransactionTypesForWeeklyClaimBrokerDAL
        /// </summary>
        /// <returns></returns>
        internal IList<TransactionTypesModel> GetTransactionTypesForWeeklyClaimBrokerDAL()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<TransactionTypesModel> lstTransactionTypesModel = new List<TransactionTypesModel>();
                    TransactionTypesModel objTransactionTypesModel;

                    var results = client.GetTransactionTypesForWeeklyClaim();

                    foreach (var item in results)
                    {
                        objTransactionTypesModel = new TransactionTypesModel();
                        objTransactionTypesModel.FilingSchedId = item.FilingSchedId;
                        objTransactionTypesModel.FilingSchedDesc = item.FilingSchedDesc;
                        objTransactionTypesModel.FilingSchedAbbrev = item.FilingSchedAbbrev;
                        lstTransactionTypesModel.Add(objTransactionTypesModel);
                    }
                    client.Close();
                    return lstTransactionTypesModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }


        }
        #endregion GetTransactionTypesForWeeklyClaimBrokerDAL

        #region GetFilingWeeklyClaimSubmissionData
        /// <summary>
        /// GetFilingWeeklyClaimSubmissionData
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> GetFilingWeeklyClaimSubmissionDataDAL(FilingTransDataModel objFilingTransDataModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                    FilingTransactionDataModel objFilingTransactionDataModel;

                    FilingTransDataContract objFilingTransDataContract = new FilingTransDataContract();
                    objFilingTransDataContract.FilerId = objFilingTransDataModel.FilerId;
                    objFilingTransDataContract.ReportYearId = objFilingTransDataModel.ReportYearId;
                    objFilingTransDataContract.OfficeTypeId = objFilingTransDataModel.OfficeTypeId;
                    objFilingTransDataContract.ElectionType = objFilingTransDataModel.ElectionType;
                    objFilingTransDataContract.ElectionDateId = objFilingTransDataModel.ElectionDateId;
                    objFilingTransDataContract.FilingDate = objFilingTransDataModel.FilingDate;
                    objFilingTransDataContract.MunicipalityID = objFilingTransDataModel.MunicipalityID;

                    var results = client.GetFilingWeeklyClaimSubmissionData(objFilingTransDataContract);

                    foreach (var item in results)
                    {
                        objFilingTransactionDataModel = new FilingTransactionDataModel();
                        objFilingTransactionDataModel.FilingTransId = item.FilingTransId;
                        objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                        objFilingTransactionDataModel.ContributorTypeId = item.ContributorTypeId;
                        objFilingTransactionDataModel.ContributorTypeDesc = item.ContributorTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.PaymentTypeId = item.PaymentTypeId;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.SubmissionDate = item.SubmissionDate;
                        objFilingTransactionDataModel.SchedDate = item.SchedDate;
                        objFilingTransactionDataModel.FilingSchedDesc = item.FilingSchedDesc;
                        objFilingTransactionDataModel.FilingEntityId = item.FilingEntityId;
                        objFilingTransactionDataModel.FilingEntityName = item.FilingEntityName;
                        objFilingTransactionDataModel.FilingFirstName = item.FilingFirstName;
                        objFilingTransactionDataModel.FilingMiddleName = item.FilingMiddleName;
                        objFilingTransactionDataModel.FilingLastName = item.FilingLastName;
                        objFilingTransactionDataModel.FilingStreetNumber = item.FilingStreetNumber;
                        objFilingTransactionDataModel.FilingStreetName = item.FilingStreetName;
                        objFilingTransactionDataModel.FilingCity = item.FilingCity;
                        objFilingTransactionDataModel.FilingState = item.FilingState;
                        objFilingTransactionDataModel.FilingZip = item.FilingZip;
                        objFilingTransactionDataModel.FilingCountry = item.FilingCountry;
                        objFilingTransactionDataModel.PaymentTypeDesc = item.PaymentTypeDesc;
                        objFilingTransactionDataModel.PayNumber = item.PayNumber;
                        objFilingTransactionDataModel.OriginalAmount = item.OriginalAmount;
                        objFilingTransactionDataModel.ReceiptTypeDesc = item.ReceiptTypeDesc;
                        objFilingTransactionDataModel.TransferTypeDesc = item.TransferTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.OriginalDate = item.OriginalDate;
                        objFilingTransactionDataModel.LoanerCode = item.LoanerCode;
                        objFilingTransactionDataModel.ElectionYear = item.ElectionYear;
                        objFilingTransactionDataModel.Office = item.Office;
                        objFilingTransactionDataModel.District = item.District;
                        objFilingTransactionDataModel.RLiability = item.RLiability;
                        objFilingTransactionDataModel.RSubcontractor = item.RSubcontractor;
                        objFilingTransactionDataModel.TransExplanation = item.TransExplanation;
                        objFilingTransactionDataModel.OwedAmount = item.OwedAmount;
                        objFilingTransactionDataModel.RItemized = item.RItemized;
                        objFilingTransactionDataModel.RAmend = item.RAmend;
                        objFilingTransactionDataModel.Status = item.RStatus;
                        objFilingTransactionDataModel.CountyID = item.CountyID;
                        objFilingTransactionDataModel.CountyDesc = item.CountyDesc;
                        objFilingTransactionDataModel.MunicipalityID = item.MunicipalityID;
                        objFilingTransactionDataModel.MunicipalityDesc = item.MunicipalityDesc;
                        objFilingTransactionDataModel.LoanerCodeID = item.LoanerCodeID;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.CreatedDate = item.CreatedDate;
                        objFilingTransactionDataModel.TreasurerFirstName = item.TreasurerFirstName;
                        objFilingTransactionDataModel.TreasurerLastName = item.TreasurerLastName;
                        objFilingTransactionDataModel.TreasurerMiddleName = item.TreasurerMiddleName;
                        objFilingTransactionDataModel.TreasurerOccuptaion = item.TreasurerOccuptaion;
                        objFilingTransactionDataModel.TreasurerEmployer = item.TreasurerEmployer;
                        objFilingTransactionDataModel.TreasurerStreetAddress = item.TreasurerStreetAddress;
                        objFilingTransactionDataModel.TreasurerCity = item.TreasurerCity;
                        objFilingTransactionDataModel.TreasurerState = item.TreasurerState;
                        objFilingTransactionDataModel.TreasurerZip = item.TreasurerZip;
                        objFilingTransactionDataModel.ContributorOccupation = item.ContributorOccupation;
                        objFilingTransactionDataModel.ContributorEmployer = item.ContributorEmployer;
                        objFilingTransactionDataModel.IEDescription = item.IEDescription;
                        objFilingTransactionDataModel.CandBallotPropReference = item.CandBallotPropReference;
                        objFilingTransactionDataModel.IESupported = item.IESupported;
                        objFilingTransactionDataModel.AddrId = item.AddrId;
                        objFilingTransactionDataModel.TreasId = item.TreasId;
                        objFilingTransactionDataModel.LoanLiablityNumber = item.LoanLiablityNumber;
                        objFilingTransactionDataModel.TransNumber = item.TransNumber;
                        objFilingTransactionDataModel.TransMapping = item.TransMapping;
                        objFilingTransactionDataModel.InDistrict = item.InDistrict;
                        objFilingTransactionDataModel.RMinor = item.RMinor;
                        objFilingTransactionDataModel.RVendor = item.RVendor;
                        objFilingTransactionDataModel.RLobbyist = item.RLobbyist;
                        objFilingTransactionDataModel.RContributions = item.RContributions;
                        objFilingTransactionDataModel.TreasurerEmployer = item.TreasurerEmployer;
                        objFilingTransactionDataModel.TreasurerOccuptaion = item.TreasurerOccuptaion;
                        objFilingTransactionDataModel.TreaAddress = item.TreaAddress;
                        objFilingTransactionDataModel.TreaAddr1 = item.TreaAddr1;
                        objFilingTransactionDataModel.TreaCity = item.TreaCity;
                        objFilingTransactionDataModel.TreaState = item.TreaState;
                        objFilingTransactionDataModel.TreaZipCode = item.TreaZipCode;
                        objFilingTransactionDataModel.RecordType = item.RecordType;

                        lstFilingTransactionDataModel.Add(objFilingTransactionDataModel);
                    }
                    client.Close();
                    return lstFilingTransactionDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }


        }
        #endregion GetFilingWeeklyClaimSubmissionData

        #region GetWeeklyClaimSubmissionHistoryData
        /// <summary>
        /// GetWeeklyClaimSubmissionHistoryData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> GetWeeklyClaimSubmissionHistoryDataDAL(String strFilingTransId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                    FilingTransactionDataModel objFilingTransactionDataModel;

                    var results = client.GetWeeklyClaimSubmissionHistoryData(strFilingTransId);

                    foreach (var item in results)
                    {
                        objFilingTransactionDataModel = new FilingTransactionDataModel();
                        objFilingTransactionDataModel.FilingTransId = item.FilingTransId;
                        objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                        objFilingTransactionDataModel.ContributorTypeId = item.ContributorTypeId;
                        objFilingTransactionDataModel.ContributorTypeDesc = item.ContributorTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.PaymentTypeId = item.PaymentTypeId;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.SubmissionDate = item.SubmissionDate;
                        objFilingTransactionDataModel.SchedDate = item.SchedDate;
                        objFilingTransactionDataModel.FilingSchedDesc = item.FilingSchedDesc;
                        objFilingTransactionDataModel.FilingEntityId = item.FilingEntityId;
                        objFilingTransactionDataModel.FilingEntityName = item.FilingEntityName;
                        objFilingTransactionDataModel.FilingFirstName = item.FilingFirstName;
                        objFilingTransactionDataModel.FilingMiddleName = item.FilingMiddleName;
                        objFilingTransactionDataModel.FilingLastName = item.FilingLastName;
                        objFilingTransactionDataModel.FilingStreetNumber = item.FilingStreetNumber;
                        objFilingTransactionDataModel.FilingStreetName = item.FilingStreetName;
                        objFilingTransactionDataModel.FilingCity = item.FilingCity;
                        objFilingTransactionDataModel.FilingState = item.FilingState;
                        objFilingTransactionDataModel.FilingZip = item.FilingZip;
                        objFilingTransactionDataModel.FilingCountry = item.FilingCountry;
                        objFilingTransactionDataModel.PaymentTypeDesc = item.PaymentTypeDesc;
                        objFilingTransactionDataModel.PayNumber = item.PayNumber;
                        objFilingTransactionDataModel.OriginalAmount = item.OriginalAmount;
                        objFilingTransactionDataModel.ReceiptTypeDesc = item.ReceiptTypeDesc;
                        objFilingTransactionDataModel.TransferTypeDesc = item.TransferTypeDesc;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeDesc = item.ReceiptCodeDesc;
                        objFilingTransactionDataModel.ReceiptCodeId = item.ReceiptCodeId;
                        objFilingTransactionDataModel.OriginalDate = item.OriginalDate;
                        objFilingTransactionDataModel.LoanerCode = item.LoanerCode;
                        objFilingTransactionDataModel.ElectionYear = item.ElectionYear;
                        objFilingTransactionDataModel.Office = item.Office;
                        objFilingTransactionDataModel.District = item.District;
                        objFilingTransactionDataModel.RLiability = item.RLiability;
                        objFilingTransactionDataModel.RSubcontractor = item.RSubcontractor;
                        objFilingTransactionDataModel.TransExplanation = item.TransExplanation;
                        objFilingTransactionDataModel.OwedAmount = item.OwedAmount;
                        objFilingTransactionDataModel.RItemized = item.RItemized;
                        objFilingTransactionDataModel.RAmend = item.RAmend;
                        objFilingTransactionDataModel.Status = item.RStatus;
                        objFilingTransactionDataModel.CountyID = item.CountyID;
                        objFilingTransactionDataModel.CountyDesc = item.CountyDesc;
                        objFilingTransactionDataModel.MunicipalityID = item.MunicipalityID;
                        objFilingTransactionDataModel.MunicipalityDesc = item.MunicipalityDesc;
                        objFilingTransactionDataModel.LoanerCodeID = item.LoanerCodeID;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.CreatedDate = item.CreatedDate;
                        objFilingTransactionDataModel.TreasurerFirstName = item.TreasurerFirstName;
                        objFilingTransactionDataModel.TreasurerLastName = item.TreasurerLastName;
                        objFilingTransactionDataModel.TreasurerMiddleName = item.TreasurerMiddleName;
                        objFilingTransactionDataModel.TreasurerOccuptaion = item.TreasurerOccuptaion;
                        objFilingTransactionDataModel.TreasurerEmployer = item.TreasurerEmployer;
                        objFilingTransactionDataModel.TreasurerStreetAddress = item.TreasurerStreetAddress;
                        objFilingTransactionDataModel.TreasurerCity = item.TreasurerCity;
                        objFilingTransactionDataModel.TreasurerState = item.TreasurerState;
                        objFilingTransactionDataModel.TreasurerZip = item.TreasurerZip;
                        objFilingTransactionDataModel.ContributorOccupation = item.ContributorOccupation;
                        objFilingTransactionDataModel.ContributorEmployer = item.ContributorEmployer;
                        objFilingTransactionDataModel.CandBallotPropReference = item.CandBallotPropReference;
                        objFilingTransactionDataModel.IEDescription = item.IEDescription;
                        objFilingTransactionDataModel.IESupported = item.IESupported;
                        objFilingTransactionDataModel.LoanLiablityNumber = item.LoanLiablityNumber;
                        objFilingTransactionDataModel.TransNumber = item.TransNumber;
                        objFilingTransactionDataModel.TransMapping = item.TransMapping;
                        objFilingTransactionDataModel.InDistrict = item.InDistrict;
                        objFilingTransactionDataModel.RMinor = item.RMinor;
                        objFilingTransactionDataModel.RVendor = item.RVendor;
                        objFilingTransactionDataModel.RLobbyist = item.RLobbyist;
                        objFilingTransactionDataModel.RContributions = item.RContributions;
                        objFilingTransactionDataModel.TreasurerEmployer = item.TreasurerEmployer;
                        objFilingTransactionDataModel.TreasurerOccuptaion = item.TreasurerOccuptaion;
                        objFilingTransactionDataModel.TreaAddress = item.TreaAddress;
                        objFilingTransactionDataModel.TreaAddr1 = item.TreaAddr1;
                        objFilingTransactionDataModel.TreaCity = item.TreaCity;
                        objFilingTransactionDataModel.TreaState = item.TreaState;
                        objFilingTransactionDataModel.TreaZipCode = item.TreaZipCode;
                        lstFilingTransactionDataModel.Add(objFilingTransactionDataModel);
                    }
                    client.Close();
                    return lstFilingTransactionDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }


        }
        #endregion GetWeeklyClaimSubmissionHistoryData

        #region AddWeeklyClaimSubSchedA
        /// <summary>
        /// AddWeeklyClaimSubSchedA
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal string AddWeeklyClaimSubSchedADAL(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.FilingSchedId = objFilingTransactionsModel.FilingSchedId;
                    objFilingTransactionsContract.ContributorTypeId = objFilingTransactionsModel.ContributorTypeId;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.ElectionDate = objFilingTransactionsModel.ElectionDate;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.FilingTypeId = objFilingTransactionsModel.FilingTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.ElectionYear = objFilingTransactionsModel.ElectionYear;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntFirstName = objFilingTransactionsModel.FlngEntFirstName;
                    objFilingTransactionsContract.FlngEntLastName = objFilingTransactionsModel.FlngEntLastName;
                    objFilingTransactionsContract.FlngEntMiddleName = objFilingTransactionsModel.FlngEntMiddleName;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.RItemized = objFilingTransactionsModel.RItemized;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    objFilingTransactionsContract.ResigTermTypeId = objFilingTransactionsModel.ResigTermTypeId;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;
                    objFilingTransactionsContract.MunicipalityID = objFilingTransactionsModel.MunicipalityID;
                    objFilingTransactionsContract.IsClaim = objFilingTransactionsModel.IsClaim;
                    objFilingTransactionsContract.InDistrict = objFilingTransactionsModel.InDistrict;
                    objFilingTransactionsContract.Minor = objFilingTransactionsModel.Minor;
                    objFilingTransactionsContract.Vendor = objFilingTransactionsModel.Vendor;
                    objFilingTransactionsContract.Lobbyist = objFilingTransactionsModel.Lobbyist;
                    objFilingTransactionsContract.TreasurerEmployer = objFilingTransactionsModel.TreasurerEmployer;
                    objFilingTransactionsContract.TreasurerOccupation = objFilingTransactionsModel.TreasurerOccupation;
                    objFilingTransactionsContract.TreasurerStreetAddress = objFilingTransactionsModel.TreasurerStreetAddress;
                    objFilingTransactionsContract.TreasurerCity = objFilingTransactionsModel.TreasurerCity;
                    objFilingTransactionsContract.TreasurerState = objFilingTransactionsModel.TreasurerState;
                    objFilingTransactionsContract.TreasurerZip = objFilingTransactionsModel.TreasurerZip;
                    objFilingTransactionsContract.CommTypeID = objFilingTransactionsModel.CommTypeID;
                    objFilingTransactionsContract.RContributions = objFilingTransactionsModel.RContributions;

                    string result = client.AddWeeklyClaimSubSchedA(objFilingTransactionsContract);
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
        #endregion AddWeeklyClaimSubSchedA

        /// <summary>
        /// UpdateWeeklyClaimSubSchedADAL
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean UpdateWeeklyClaimSubSchedADAL(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.TransNumber = objFilingTransactionsModel.TransNumber;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.ContributorTypeId = objFilingTransactionsModel.ContributorTypeId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.FlngEntName = objFilingTransactionsModel.FlngEntName;
                    objFilingTransactionsContract.FlngEntFirstName = objFilingTransactionsModel.FlngEntFirstName;
                    objFilingTransactionsContract.FlngEntMiddleName = objFilingTransactionsModel.FlngEntMiddleName;
                    objFilingTransactionsContract.FlngEntLastName = objFilingTransactionsModel.FlngEntLastName;
                    objFilingTransactionsContract.FlngEntStrName = objFilingTransactionsModel.FlngEntStrName;
                    objFilingTransactionsContract.FlngEntCity = objFilingTransactionsModel.FlngEntCity;
                    objFilingTransactionsContract.FlngEntState = objFilingTransactionsModel.FlngEntState;
                    objFilingTransactionsContract.FlngEntZip = objFilingTransactionsModel.FlngEntZip;
                    objFilingTransactionsContract.FlngEntCountry = objFilingTransactionsModel.FlngEntCountry;
                    objFilingTransactionsContract.ModifiedBy = objFilingTransactionsModel.ModifiedBy;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.FilingTypeId = objFilingTransactionsModel.FilingTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.IsClaim = objFilingTransactionsModel.IsClaim;
                    objFilingTransactionsContract.InDistrict = objFilingTransactionsModel.InDistrict;
                    objFilingTransactionsContract.Minor = objFilingTransactionsModel.Minor;
                    objFilingTransactionsContract.Vendor = objFilingTransactionsModel.Vendor;
                    objFilingTransactionsContract.Lobbyist = objFilingTransactionsModel.Lobbyist;
                    objFilingTransactionsContract.TreasurerEmployer = objFilingTransactionsModel.TreasurerEmployer;
                    objFilingTransactionsContract.TreasurerOccupation = objFilingTransactionsModel.TreasurerOccupation;
                    objFilingTransactionsContract.TreasurerStreetAddress = objFilingTransactionsModel.TreasurerStreetAddress;
                    objFilingTransactionsContract.TreasurerCity = objFilingTransactionsModel.TreasurerCity;
                    objFilingTransactionsContract.TreasurerState = objFilingTransactionsModel.TreasurerState;
                    objFilingTransactionsContract.TreasurerZip = objFilingTransactionsModel.TreasurerZip;
                    objFilingTransactionsContract.CommTypeID = objFilingTransactionsModel.CommTypeID;
                    objFilingTransactionsContract.RContributions = objFilingTransactionsModel.RContributions;
                    objFilingTransactionsContract.SubmissionDate = objFilingTransactionsModel.SubmissionDate;

                    Boolean returnValue = client.UpdateWeeklyClaimSubSchedA(objFilingTransactionsContract);
                    client.Close();
                    return returnValue;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
        }

        #region mapSubmitIEWeeklyContrFlngTransDALResponse
        /// <summary>
        /// mapSubmitIEWeeklyContrFlngTransDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        internal Boolean WeeklyClaimSubSubmitTransDAL(IList<FilingTransactionsTransID> lstFilingTransactionsTransID, String filerID, String strModifiedBy)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {
                    IList<FilingTransactionsTransIDContract> lstFilingTransactionsTransIDContract = new List<FilingTransactionsTransIDContract>();
                    FilingTransactionsTransIDContract objFilingTransactionsTransIDContract;

                    foreach (var item in lstFilingTransactionsTransID)
                    {
                        objFilingTransactionsTransIDContract = new FilingTransactionsTransIDContract();
                        objFilingTransactionsTransIDContract.TransID = item.TransID;
                        lstFilingTransactionsTransIDContract.Add(objFilingTransactionsTransIDContract);
                    }

                    var arrayFilingTransactionsTransIDContract = new List<FilingTransactionsTransIDContract>(lstFilingTransactionsTransIDContract).ToArray();

                    Boolean results = client.WeeklyClaimSubSubmitTrans(arrayFilingTransactionsTransIDContract, filerID, strModifiedBy);
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
        #endregion WeeklyClaimSubSubmitTransDAL

        #region DeleteWeeklyClaimSubSchedA
        /// <summary>
        /// DeleteWeeklyClaimSubSchedA
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        internal Boolean DeleteWeeklyClaimSubSchedADAL(String strTransNumber, String strModifiedBy, String filerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    Boolean returnValue = client.DeleteWeeklyClaimSubSchedA(strTransNumber, strModifiedBy, filerID);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }


        }
        #endregion DeleteWeeklyClaimSubSchedA

        #region GetItemizedWCSTransDAL
        /// <summary>
        /// GetItemizedWCSTransDAL
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strElectionDateId"></param> 
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> GetItemizedWCSTransDAL(String strFilerId, String strElectionYearId, String strOfficeTypeId, String strElectionTypeId, String strElectionDateId, String strMunicipalityId,
                                                                          String strCuttOffDate)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                    FilingTransactionDataModel objFilingTransactionDataModel;
                    if (strElectionDateId == "- Select -")
                    {
                        strElectionDateId = "0";
                    }
                    var results = client.GetItemizedWCSTrans(strFilerId, strElectionYearId, strOfficeTypeId, strElectionTypeId, strElectionDateId, strMunicipalityId, strCuttOffDate);

                    foreach (var item in results)
                    {
                        objFilingTransactionDataModel = new FilingTransactionDataModel();
                        objFilingTransactionDataModel.FilingTransId = item.FilingTransId;
                        objFilingTransactionDataModel.SchedDate = item.SchedDate;
                        objFilingTransactionDataModel.OriginalAmount = item.OriginalAmount;
                        objFilingTransactionDataModel.IEDescription = item.IEDescription;
                        objFilingTransactionDataModel.IEType = item.IEType;
                        objFilingTransactionDataModel.TreasurerName = item.TreasurerName;
                        objFilingTransactionDataModel.ContributorName = item.ContributorName;
                        objFilingTransactionDataModel.TreasurerCity = item.TreasurerCity;
                        objFilingTransactionDataModel.TreasurerState = item.TreasurerState;
                        objFilingTransactionDataModel.CandBallotPropReference = item.CandBallotPropReference;
                        objFilingTransactionDataModel.TransExplanation = item.TransExplanation;
                        objFilingTransactionDataModel.CreatedDate = item.CreatedDate;
                        objFilingTransactionDataModel.LoanLiablityNumber = item.LoanLiablityNumber;
                        objFilingTransactionDataModel.TransNumber = item.TransNumber;
                        objFilingTransactionDataModel.TransMapping = item.TransMapping;
                        lstFilingTransactionDataModel.Add(objFilingTransactionDataModel);
                    }
                    client.Close();
                    return lstFilingTransactionDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }


        }
        #endregion GetItemizedWCSTransDAL

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
        public Boolean AddWeeklyClaimSubItemizedTransDAL(IList<FilingTransactionsModel> lstFilingTransactionsModel, String strFilerId, String strElectionYearId, String strOfficeTypeId, String strFilingTypeId, String strElectionTypeId, String strElectionDateId, String strCreatedBy, String strFilingDate)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {
                    IList<FilingTransactionsContract> lstFilingTransactionsContract = new List<FilingTransactionsContract>();
                    FilingTransactionsContract objFilingTransactionsContract;

                    foreach (var item in lstFilingTransactionsModel)
                    {
                        objFilingTransactionsContract = new FilingTransactionsContract();
                        objFilingTransactionsContract.TransNumber = item.TransNumber;
                        lstFilingTransactionsContract.Add(objFilingTransactionsContract);
                    }

                    var arrayFilingTransactionsContract = new List<FilingTransactionsContract>(lstFilingTransactionsContract).ToArray();

                    Boolean returnValue = client.AddWeeklyClaimSubItemizedTrans(arrayFilingTransactionsContract, strFilerId, strElectionYearId, strOfficeTypeId, strFilingTypeId, strElectionTypeId, strElectionDateId, strCreatedBy, strFilingDate);
                    client.Close();
                    return returnValue;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
        }
        #endregion

        /// <summary>
        /// GetDisclosureTypesDataForPCFBDAL 
        /// </summary>
        /// <returns></returns>
        internal IList<DisclosureTypesModel> GetDisclosureTypesDataForPCFBDAL(String strCandCommId, String strElectTypeID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<DisclosureTypesModel> lstDisclosureTypesModel = new List<DisclosureTypesModel>();
                    DisclosureTypesModel objDisclosureTypesModel;

                    var results = client.GetDisclosureTypesDataForPCFB(strCandCommId, strElectTypeID);

                    foreach (var item in results)
                    {
                        objDisclosureTypesModel = new DisclosureTypesModel();
                        objDisclosureTypesModel.DisclosureTypeId = item.DisclosureTypeId;
                        if (item.DisclosureSubTypeDesc != null)
                            objDisclosureTypesModel.DisclosureTypeDesc = item.DisclosureTypeDesc + " - " + item.DisclosureSubTypeDesc;
                        objDisclosureTypesModel.DisclosureTypeDesc = item.DisclosureTypeDesc;
                        objDisclosureTypesModel.DisclosureSubTypeDesc = item.DisclosureSubTypeDesc;
                        lstDisclosureTypesModel.Add(objDisclosureTypesModel);
                    }
                    client.Close();
                    return lstDisclosureTypesModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }

        }

        /// <summary>
        /// GetReportSourceDataSchedSDAL
        /// </summary>
        /// <returns></returns>
        internal IList<ReportSourceModel> GetReportSourceDataSchedSDAL()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {
                    IList<ReportSourceModel> lstReportSourceModel = new List<ReportSourceModel>();
                    ReportSourceModel objReportSourceModel;

                    var results = client.GetReportSourceDataSchedS();

                    foreach (var item in results)
                    {
                        objReportSourceModel = new ReportSourceModel();
                        objReportSourceModel.FilingEntityId = item.FilingEntityId;
                        objReportSourceModel.ReportSource = item.ReportSource;
                        objReportSourceModel.StreetAddress1 = item.StreetAddress1;
                        objReportSourceModel.City = item.City;
                        objReportSourceModel.State = item.State;
                        objReportSourceModel.ZipCode = item.ZipCode;
                        objReportSourceModel.Country = item.Country;
                        lstReportSourceModel.Add(objReportSourceModel);
                    }
                    client.Close();
                    return lstReportSourceModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }

        }

        /// <summary>
        /// AddPublic_Fund_Receipts_SchedS_DAL
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal string AddPublic_Fund_Receipts_SchedS_DAL(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {
                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;
                    objFilingTransactionsContract.ReceiptTypeId = objFilingTransactionsModel.ReceiptTypeId;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.FilingTypeId = objFilingTransactionsModel.FilingTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;
                    objFilingTransactionsContract.ResigTermTypeId = objFilingTransactionsModel.ResigTermTypeId;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;

                    string result = client.AddPublic_Fund_Receipts_SchedS(objFilingTransactionsContract);
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
        /// UpdateFlngtrans_PublicFundRecptDAL
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean UpdateFlngtrans_PublicFundRecptDAL(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.TransNumber = objFilingTransactionsModel.TransNumber;                    
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;                    
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    Boolean result = client.UpdateFlngtrans_PublicFundRecpt(objFilingTransactionsContract);
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
        /// mapGetPaymentMethodDataDALSchedA
        /// </summary>
        /// <returns></returns>
        internal IList<PaymentMethodModel> mapGetPaymentMethodDataDALSchedA()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<PaymentMethodModel> lstPaymentMethodModel = new List<PaymentMethodModel>();
                    PaymentMethodModel objPaymentMethodModel;

                    var results = client.GetPaymentMethodDataForSchedA();

                    foreach (var item in results)
                    {
                        objPaymentMethodModel = new PaymentMethodModel();
                        objPaymentMethodModel.PaymentTypeId = item.PaymentTypeId;
                        objPaymentMethodModel.PaymentTypeDesc = item.PaymentTypeDesc;
                        objPaymentMethodModel.PaymentTypeAbbrev = item.PaymentTypeAbbrev;
                        lstPaymentMethodModel.Add(objPaymentMethodModel);
                    }
                    client.Close();
                    return lstPaymentMethodModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }

        }

        /// <summary>
        /// GetEditFlagPCFDueDate
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strCommTypeId"></param>
        /// <param name="strLabelId"></param>
        /// <param name="strFilingDate"></param>
        /// <returns></returns>
        internal IList<GetEditFlagDataModel> GetEditFlagPCFDueDateDAL(FilingTransDataModel objFilingTransDataModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<GetEditFlagDataModel> lstGetEditFlagDataModel = new List<GetEditFlagDataModel>();
                    GetEditFlagDataModel objGetEditFlagDataModel;

                    FilingTransDataContract objFilingTransDataContract = new FilingTransDataContract();
                    objFilingTransDataContract.FilerId = objFilingTransDataModel.FilerId;
                    objFilingTransDataContract.ReportYearId = objFilingTransDataModel.ReportYearId;
                    objFilingTransDataContract.ElectionType = objFilingTransDataModel.ElectionType;
                    objFilingTransDataContract.OfficeTypeId = objFilingTransDataModel.OfficeTypeId;
                    objFilingTransDataContract.DisclosurePeriod = objFilingTransDataModel.DisclosurePeriod;
                    objFilingTransDataContract.FilingDate = objFilingTransDataModel.FilingDate;
                    objFilingTransDataContract.ElectionDateId = objFilingTransDataModel.ElectionDateId;
                    objFilingTransDataContract.Created_By = objFilingTransDataModel.Created_By;
                    objFilingTransDataContract.TransNumber = objFilingTransDataModel.TransNumber;
                    objFilingTransDataContract.MunicipalityID = objFilingTransDataModel.MunicipalityID;
                    objFilingTransDataContract.CommTypeId = objFilingTransDataModel.CommTypeId;
                    objFilingTransDataContract.LabelId = objFilingTransDataModel.LabelId;

                    var results = client.GetEditFlagPCFDueDate(objFilingTransDataContract);

                    foreach (var item in results)
                    {
                        objGetEditFlagDataModel = new GetEditFlagDataModel();
                        objGetEditFlagDataModel.Is_Edit = item.Is_Edit.ToString();
                        lstGetEditFlagDataModel.Add(objGetEditFlagDataModel);
                    }
                    client.Close();
                    return lstGetEditFlagDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }


        }

        /// <summary>
        /// GetEditFlagPCFDueDateImport
        /// </summary>
        /// <param name="filerId"></param>
        /// <param name="filingPeriodId"></param>
        /// <param name="electId"></param>
        /// <returns></returns>
        internal IList<GetEditFlagDataModel> GetEditFlagPCFDueDateImportDAL(String filerId, String filingPeriodId, String electId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {
                    IList<GetEditFlagDataModel> lstGetEditFlagDataModel = new List<GetEditFlagDataModel>();
                    GetEditFlagDataModel objGetEditFlagDataModel;                    

                    var results = client.GetEditFlagPCFDueDateImport(filerId, filingPeriodId, electId);
                    foreach (var item in results)
                    {
                        objGetEditFlagDataModel = new GetEditFlagDataModel();
                        objGetEditFlagDataModel.Is_Edit = item.Is_Edit.ToString();
                        lstGetEditFlagDataModel.Add(objGetEditFlagDataModel);
                    }
                    client.Close();
                    return lstGetEditFlagDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
        }

        /// <summary>
        /// AddPublic_Fund_Payment_SchedU_DAL
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal string AddPublic_Fund_Payment_SchedU_DAL(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {
                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.FilingEntId = objFilingTransactionsModel.FilingEntId;                    
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.ElectionTypeId = objFilingTransactionsModel.ElectionTypeId;
                    objFilingTransactionsContract.OfficeTypeId = objFilingTransactionsModel.OfficeTypeId;
                    objFilingTransactionsContract.FilingTypeId = objFilingTransactionsModel.FilingTypeId;
                    objFilingTransactionsContract.ElectYearId = objFilingTransactionsModel.ElectYearId;
                    objFilingTransactionsContract.FilingDate = objFilingTransactionsModel.FilingDate;
                    objFilingTransactionsContract.ElectionDateId = objFilingTransactionsModel.ElectionDateId;
                    objFilingTransactionsContract.ResigTermTypeId = objFilingTransactionsModel.ResigTermTypeId;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;

                    string result = client.AddPublic_Fund_Payment_SchedU(objFilingTransactionsContract);
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
        /// UpdateFlngtrans_PublicFundPayment_DAL
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean UpdateFlngtrans_PublicFundPayment_DAL(FilingTransactionsModel objFilingTransactionsModel)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    FilingTransactionsContract objFilingTransactionsContract = new FilingTransactionsContract();
                    objFilingTransactionsContract.FilerId = objFilingTransactionsModel.FilerId;
                    objFilingTransactionsContract.TransNumber = objFilingTransactionsModel.TransNumber;
                    objFilingTransactionsContract.SchedDate = objFilingTransactionsModel.SchedDate;
                    objFilingTransactionsContract.PaymentTypeId = objFilingTransactionsModel.PaymentTypeId;
                    objFilingTransactionsContract.PayNumber = objFilingTransactionsModel.PayNumber;
                    objFilingTransactionsContract.OrgAmt = objFilingTransactionsModel.OrgAmt;
                    objFilingTransactionsContract.TransExplanation = objFilingTransactionsModel.TransExplanation;
                    objFilingTransactionsContract.CreatedBy = objFilingTransactionsModel.CreatedBy;
                    Boolean result = client.UpdateFlngtrans_PublicFundPayment(objFilingTransactionsContract);
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
        /// GetFilingCutOffDateData_PCF_WCS_DAL
        /// </summary>
        /// <param name="strElectYearId"></param>
        /// <param name="strElectTypeId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <returns></returns>
        internal IList<FilingCutOffDateModel> GetFilingCutOffDateData_PCF_WCS_DAL(String strElectYearId, String strElectTypeId, String strOfficeTypeId, String strPolCalMapId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingCutOffDateModel> lstFilingCutOffDateModel = new List<FilingCutOffDateModel>();
                    FilingCutOffDateModel objFilingCutOffDateModel;

                    var results = client.GetFilingCutOffDateData_PCF_WCS(strElectYearId, strElectTypeId, strOfficeTypeId, strPolCalMapId);

                    foreach (var item in results)
                    {
                        objFilingCutOffDateModel = new FilingCutOffDateModel();
                        objFilingCutOffDateModel.PoliticalCalDateId = item.PoliticalCalDateId;
                        objFilingCutOffDateModel.PriGenDate = item.PriGenDate;
                        objFilingCutOffDateModel.FilingDueDate = item.FilingDueDate;
                        objFilingCutOffDateModel.CutOffDate = item.CutOffDate;
                        lstFilingCutOffDateModel.Add(objFilingCutOffDateModel);
                    }
                    client.Close();
                    return lstFilingCutOffDateModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }

        }

        /// <summary>
        /// GetFilingTransSchedR_ChildDataDAL
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <param name="strFilerId"></param>
        /// <returns></returns>
        internal IList<FilingTransactionsModel> GetFilingTransSchedR_ChildDataDAL(String strTransNumber, String strFilerId)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingTransactionsModel> lstFilingTransactionsModel = new List<FilingTransactionsModel>();
                    FilingTransactionsModel objFilingTransactionsModel;

                    var results = client.GetFilingTransSchedR_ChildData(strTransNumber, strFilerId);

                    foreach (var item in results)
                    {
                        objFilingTransactionsModel = new FilingTransactionsModel();                        
                        objFilingTransactionsModel.FilingTransId = item.FilingTransId;
                        objFilingTransactionsModel.TransNumber = item.TransNumber;
                        objFilingTransactionsModel.TransMapping = item.TransMapping;
                        objFilingTransactionsModel.FilingEntId = item.FilingEntId;
                        objFilingTransactionsModel.SupportOppose = item.SupportOppose;
                        objFilingTransactionsModel.SchedDate = item.SchedDate;
                        objFilingTransactionsModel.FlngEntFirstName = item.FlngEntFirstName;
                        objFilingTransactionsModel.FlngEntMiddleName = item.FlngEntMiddleName;
                        objFilingTransactionsModel.FlngEntLastName = item.FlngEntLastName;
                        objFilingTransactionsModel.OrgAmt = item.OrgAmt;
                        objFilingTransactionsModel.ElectionYear = item.ElectionYear;
                        objFilingTransactionsModel.OfficeID = item.OfficeID;
                        objFilingTransactionsModel.DistrictID = item.DistrictID;
                        objFilingTransactionsModel.TransExplanation = item.TransExplanation;
                        objFilingTransactionsModel.RItemized = item.RItemized;
                        lstFilingTransactionsModel.Add(objFilingTransactionsModel);
                    }
                    client.Close();
                    return lstFilingTransactionsModel;
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }

        }

        #region mapGetCommEditIETransDataDALResponse_WCS
        /// <summary>
        /// mapGetCommEditIETransDataDALResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetCommEditIETransDataDALResponse_WCS(String strTransNumber, String filerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                    FilingTransactionDataModel objFilingTransactionDataModel;

                    var results = client.GetCommEditIETransData_WCS(strTransNumber, filerID);

                    foreach (var item in results)
                    {
                        objFilingTransactionDataModel = new FilingTransactionDataModel();
                        objFilingTransactionDataModel.FilingTransId = item.FilingTransId;
                        objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                        objFilingTransactionDataModel.ContributorTypeId = item.ContributorTypeId;
                        objFilingTransactionDataModel.ContributorTypeDesc = item.ContributorTypeDesc;
                        objFilingTransactionDataModel.PaymentTypeId = item.PaymentTypeId;
                        objFilingTransactionDataModel.SubmissionDate = item.SubmissionDate;
                        objFilingTransactionDataModel.SchedDate = item.SchedDate;
                        objFilingTransactionDataModel.FilingSchedDesc = item.FilingSchedDesc;
                        objFilingTransactionDataModel.FilingEntityId = item.FilingEntityId;
                        objFilingTransactionDataModel.FilingEntityName = item.FilingEntityName;
                        objFilingTransactionDataModel.FilingFirstName = item.FilingFirstName;
                        objFilingTransactionDataModel.FilingMiddleName = item.FilingMiddleName;
                        objFilingTransactionDataModel.FilingLastName = item.FilingLastName;
                        objFilingTransactionDataModel.FilingStreetNumber = item.FilingStreetNumber;
                        objFilingTransactionDataModel.FilingStreetName = item.FilingStreetName;
                        objFilingTransactionDataModel.FilingCity = item.FilingCity;
                        objFilingTransactionDataModel.FilingState = item.FilingState;
                        objFilingTransactionDataModel.FilingZip = item.FilingZip;
                        objFilingTransactionDataModel.FilingCountry = item.FilingCountry;
                        objFilingTransactionDataModel.PaymentTypeDesc = item.PaymentTypeDesc;
                        objFilingTransactionDataModel.PayNumber = item.PayNumber;
                        objFilingTransactionDataModel.OriginalAmount = item.OriginalAmount;
                        objFilingTransactionDataModel.TransExplanation = item.TransExplanation;
                        objFilingTransactionDataModel.RItemized = item.RItemized;
                        objFilingTransactionDataModel.CountyDesc = item.CountyDesc;
                        objFilingTransactionDataModel.RAmend = item.RAmend;
                        objFilingTransactionDataModel.Status = item.RStatus;
                        objFilingTransactionDataModel.MunicipalityDesc = item.MunicipalityDesc;
                        objFilingTransactionDataModel.LoanerCodeID = item.LoanerCodeID;
                        objFilingTransactionDataModel.LoanerCode = item.LoanerCode;
                        objFilingTransactionDataModel.ContributionTypeId = item.ContributionTypeId;
                        objFilingTransactionDataModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objFilingTransactionDataModel.CreatedDate = item.CreatedDate;
                        objFilingTransactionDataModel.TreasurerFirstName = item.TreasurerFirstName;
                        objFilingTransactionDataModel.TreasurerLastName = item.TreasurerLastName;
                        objFilingTransactionDataModel.TreasurerMiddleName = item.TreasurerMiddleName;
                        objFilingTransactionDataModel.TreasurerOccuptaion = item.TreasurerOccuptaion;
                        objFilingTransactionDataModel.TreasurerEmployer = item.TreasurerEmployer;
                        objFilingTransactionDataModel.TreasurerStreetAddress = item.TreasurerStreetAddress;
                        objFilingTransactionDataModel.TreasurerCity = item.TreasurerCity;
                        objFilingTransactionDataModel.TreasurerState = item.TreasurerState;
                        objFilingTransactionDataModel.TreasurerZip = item.TreasurerZip;
                        objFilingTransactionDataModel.ContributorOccupation = item.ContributorOccupation;
                        objFilingTransactionDataModel.ContributorEmployer = item.ContributorEmployer;
                        objFilingTransactionDataModel.IEDescription = item.IEDescription;
                        objFilingTransactionDataModel.CandBallotPropReference = item.CandBallotPropReference;
                        objFilingTransactionDataModel.IESupported = item.IESupported;
                        objFilingTransactionDataModel.AddrId = item.AddrId;
                        objFilingTransactionDataModel.TreasId = item.TreasId;
                        objFilingTransactionDataModel.LoanLiablityNumber = item.LoanLiablityNumber;
                        objFilingTransactionDataModel.TransNumber = item.TransNumber;
                        objFilingTransactionDataModel.TransMapping = item.TransMapping;
                        objFilingTransactionDataModel.DateIncurredOrgAmtId = item.DateIncurredOrgAmtId;
                        objFilingTransactionDataModel.RLiability = item.RLiability;
                        objFilingTransactionDataModel.RSubcontractor = item.RSubcontractor;
                        objFilingTransactionDataModel.OwedAmount = item.OwedAmount;
                        objFilingTransactionDataModel.PurposeCodeId = item.PurposeCodeId;
                        objFilingTransactionDataModel.RClaim = item.RClaim;
                        objFilingTransactionDataModel.InDistrict = item.InDistrict;
                        objFilingTransactionDataModel.RMinor = item.RMinor;
                        objFilingTransactionDataModel.RVendor = item.RVendor;
                        objFilingTransactionDataModel.RLobbyist = item.RLobbyist;
                        objFilingTransactionDataModel.RContributions = item.RContributions;
                        lstFilingTransactionDataModel.Add(objFilingTransactionDataModel);
                    }
                    client.Close();
                    return lstFilingTransactionDataModel;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }


        }
        #endregion mapGetCommEditIETransDataDALResponse_WCS

        /// <summary>
        /// mapGetPurposeCodeData_PCF_DALResponse
        /// </summary>
        /// <returns></returns>
        internal IList<PurposeCodeModel> mapGetPurposeCodeData_PCF_DALResponse()
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();
                    PurposeCodeModel objPurposeCodeModel;

                    var results = client.GetPurposeCodeData_PCF();

                    foreach (var item in results)
                    {
                        objPurposeCodeModel = new PurposeCodeModel();
                        objPurposeCodeModel.PurposeCodeId = item.PurposeCodeId;
                        objPurposeCodeModel.PurposeCodeDesc = item.PurposeCodeDesc;
                        objPurposeCodeModel.PurposeCodeAbbrev = item.PurposeCodeAbbrev;
                        lstPurposeCodeModel.Add(objPurposeCodeModel);
                    }
                    client.Close();
                    return lstPurposeCodeModel;
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
