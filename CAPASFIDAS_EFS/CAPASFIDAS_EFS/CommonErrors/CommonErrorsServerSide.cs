using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Broker;

namespace CAPASFIDAS_EFS.CommonErrors
{
    public class CommonErrorsServerSide
    {
        public Boolean DateUS(String valueDate)
        {
            //var errormsg = "";
            //var re = "/^ (\d{ 1,2})(\/| -)(\d{ 1,2})(\/| -)(\d{ 4})$/";
            Regex re = new Regex(@"^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$");
            Match match = re.Match(valueDate);
            if (match.Success)
            {
                //var adata = valueDate.Split('/');
                //var mm = Convert.ToInt32(adata[0], 10);
                //var dd = Convert.ToInt32(adata[1], 10);
                //var yyyy = Convert.ToInt32(adata[2], 10);
                //var xdata = new DateTime(yyyy, mm - 1, dd);
                //if ((xdata.Year == yyyy) && (xdata.Day == mm - 1) && (xdata.Month == dd))
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //    //errormsg = "Leap year date";
                //}
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean CuttOffDateValidation(String valueDate, String cuttofDate) 
        {
            if (cuttofDate != "")
            {
                DateTime dtCuttOffDate = Convert.ToDateTime(cuttofDate);
                DateTime d1 = Convert.ToDateTime(cuttofDate);
                DateTime d2 = Convert.ToDateTime(valueDate);                
                if (d2 > d1)
                    return false;
                else
                    return true;
            }
            else
            {
                return true;
            }
            
        }

        public Boolean CuttOffDateValidation24HourNotice(String valueDate, String cuttofDate, String filingDate)
        {
            if (cuttofDate != "")
            {
                DateTime dtCuttOffDate = Convert.ToDateTime(cuttofDate);
                DateTime d1 = Convert.ToDateTime(cuttofDate);
                DateTime d2 = Convert.ToDateTime(valueDate);
                DateTime d3 = Convert.ToDateTime(filingDate);                
                if (d2 >= d1 && d2 <= d3)
                    return true;
                else
                    return false;
            }
            else
            {
                return true;
            }

        }

        public Boolean CuttOffDateValidationNonItem(String valueDate, String cuttofDate) 
        {
            DateTime dtCuttOffDate = Convert.ToDateTime(cuttofDate);
            DateTime d1 = Convert.ToDateTime(cuttofDate);
            DateTime d2 = Convert.ToDateTime(valueDate);
            if (d2 < d1)
                return false;
            else
                return true;
        }

        public Boolean NameValidate(String strValue)
        {
            // ADD &)( THSE SPECIAL CHARACTERS FOR NAME FILEDS.
            // ADDED THIS ON 08/27/2020 AS PER DISCUSSION.
            //return this.optional(element) || /^[a - zA - Z0 - 9 #'.,-]*$/i.test(value);
            Regex re = new Regex(@"^[a-zA-Z0-9 #'.,&()-]*$");
            Match match = re.Match(strValue);
            if (match.Success)
                return true;
            else
                return false;
        }

        public Boolean EntityNameValidate(String strValue)
        {
            //return this.optional(element) || /^[a - zA - Z0 - 9 #'.,-]*$/i.test(value);
            Regex re = new Regex(@"^[a-zA-Z0-9 #'.,&()-]*$");
            Match match = re.Match(strValue);
            if (match.Success)
                return true;
            else
                return false;
        }

        public Boolean NameValidatePartnerDetails(String strValue)
        {
            //return this.optional(element) || /^[a - zA - Z0 - 9 #'.,-]*$/i.test(value);
            Regex re = new Regex(@"^[a-zA-Z0-9 &#'.,&()-]*$");
            Match match = re.Match(strValue);
            if (match.Success)
                return true;
            else
                return false;
        }

        public Boolean AlphabetsValidation(String strValue)
        {
            //return this.optional(element) || /^[a - zA - Z] +$/ i.test(value);
            Regex re = new Regex(@"^[a-zA-Z]+$");
            Match match = re.Match(strValue);
            if (match.Success)
                return true;
            else
                return false;
        }

        public Boolean ValidateAlphaNumericAddress(String strValue)
        {
            //return this.optional(element) || /^[a - zA - Z0 - 9 #'.,-]*$/i.test(value);
            Regex re = new Regex(@"^[a-zA-Z0-9 #'.,-]*$");
            Match match = re.Match(strValue);
            if (match.Success)
                return true;
            else
                return false;
        }

        public Boolean AlphaSpecialNumOtherCntry(String strValue)
        {
            //return this.optional(element) || /^[a - zA - Z0 - 9 #'.,-]*$/i.test(value);
            Regex re = new Regex(@"^[a-zA-Z0-9 #'.,-]*$");
            Match match = re.Match(strValue);
            if (match.Success)
                return true;
            else
                return false;
        }

        public Boolean ValidateAlphaSpecial(String strValue)
        {
            //return this.optional(element) || /^[a - zA - Z #'.,-]*$/i.test(value);
            Regex re = new Regex(@"^[a-zA-Z #'.,-]*$");
            Match match = re.Match(strValue);
            if (match.Success)
                return true;
            else
                return false;
        }

        public Boolean AlphaSpecialStateOtherCntry(String strValue)
        {
            //return this.optional(element) || /^[a - zA - Z0 - 9 #'.,-]*$/i.test(value);
            Regex re = new Regex(@"^[a-zA-Z0-9 #'.,-]*$");
            Match match = re.Match(strValue);
            if (match.Success)
                return true;
            else
                return false;
        }

        public Boolean AlphabetsValState(String strValue)
        {
            //return this.optional(element) || /^[a - zA - Z] +$/ i.test(value);
            Regex re = new Regex(@"^[a-zA-Z]+$");
            Match match = re.Match(strValue);
            if (match.Success)
                return true;
            else
                return false;
        }

        public Boolean FomatZipcode(String strValue)
        {
            //return this.optional(element) || /(^\d{ 5}$)| (^\d{5}-\d{4}$)/.test(value);
            //Regex re = new Regex(@"^(^\d{ 5}$)|(^\d{5}-\d{4}$)$");
            if (Convert.ToInt32(strValue.Count()) < 5)
            {
                return false;
            }
            else if (Convert.ToInt32(strValue.Count()) > 5)
            {
                Regex re = new Regex("^\\d{5}(-\\d{4})?$");     //"^\d{5}-\d{4}|\d{9}$");
                Match match = re.Match(strValue);
                if (match.Success)
                    return true;
                else
                    return false;
            }
            else if (Convert.ToInt32(strValue.Count()) == 5)
            {
                return true;
            }
            else
            {
                return true;
            }            
        }

        public Boolean OtherCountryZipVal(String strValue)
        {
            //return this.optional(element) || /^[a - zA - Z0 - 9 -] *$/ i.test(value);
            Regex re = new Regex(@"^[a-zA-Z0-9 -]*$");
            Match match = re.Match(strValue);
            if (match.Success)
                return true;
            else
                return false;
        }

        public Boolean AlphabetsVal(String strValue)
        {
            //return this.optional(element) || /^[a - zA - Z] +$/ i.test(value);
            Regex re = new Regex(@"^[a-zA-Z ]+$");
            Match match = re.Match(strValue);
            if (match.Success)
                return true;
            else
                return false;
        }

        public Boolean AlphaNumeric(String strValue)
        {
            //return this.optional(element) || /^[a - zA - Z0 - 9] *$/.test(value);
            Regex re = new Regex(@"^[a-zA-Z0-9]*$");
            Match match = re.Match(strValue);
            if (match.Success)
                return true;
            else
                return false;
        }

        public Boolean NumbersOnly(String strValue)
        {
            Regex re = new Regex(@"^[0-9.]*$");
            Match match = re.Match(strValue);
            if (match.Success)
                return true;
            else
                return false;
        }

        public Boolean AmountValidate(String strValue)
        {
            //return this.optional(element) || /^\d{ 0,9}\.\d{ 0,2}$|^\d{ 0,12}$/.test(value);
            Regex re = new Regex(@"^\d{0,9}\.\d{0,2}$|^\d{0,12}$");
            Match match = re.Match(strValue);
            if (match.Success)
                return true;
            else
                return false;
        }

        public Boolean Amount12DigitVal(String strValue)
        {
            String varAmount = strValue;
            String valAmount = "9";
            if (Convert.ToInt32(varAmount.Length) > Convert.ToInt32(valAmount))
            {
                if (varAmount.IndexOf(".") > -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        //public Boolean AmountZeroVal(String strValue)
        //{
        //    String amountVal = strValue;
        //    Double valAmount = Convert.ToDouble("1");
        //    if (Convert.ToDouble(amountVal) < valAmount)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
        // REQUEST CAME TO ADD LESS THAN $1 AMOUNT FOR PENDING SCHEDULES.
        // IMPLEMENTED SCHEDULES G, H, I, J, K, L, M, O, R.
        // ADDED ON 05.26.2021.
        public Boolean AmountZeroVal(String strValue)
        {
            String amountVal = strValue;
            Double valAmount = Convert.ToDouble("0");
            if (Convert.ToDouble(amountVal) <= valAmount)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // IMPLEMENTED THESE CHANGES BASED ON DISCUSSION ON 02.08.2021.
        // DEFECT - 748 HAS BEEN FIXED TO ALLOW LESS THAN A $1.
        // IMPLEMENTED OF SCHEDULES A, B, C, D, E, F, N, O, P, and Q
        // AS DISCUSSED IT SHOULD ALLOW LESS THAN A $1 IN ALL THE SCHEDULES
        // PENDING SCHEDULE HAS BEEN FIXED - ON 05.24.2021.
        public Boolean AmountZeroValSched_ABC(String strValue)
        {
            String amountVal = strValue;
            Double valAmount = Convert.ToDouble("0");
            if (Convert.ToDouble(amountVal) <= valAmount)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Boolean AmountZeroValSched_E(String strValue)
        {
            String amountVal = strValue;
            Double valAmount = Convert.ToDouble("0");
            if (Convert.ToDouble(amountVal) < valAmount)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Boolean FilingDateValidation(String valueDate, String electionYear)
        {                      
            DateTime filingDate = Convert.ToDateTime(valueDate);

            String fromDate = "01" + "/" + "01" + "/" + electionYear;
            String toDate = "12" + "/" + "31" + "/" + electionYear;

            DateTime fDate = Convert.ToDateTime(fromDate);
            DateTime tDate = Convert.ToDateTime(toDate);

            if ((filingDate >= fDate) && (filingDate <= tDate))
                return true;
            else
                return false;
        }

        #region "ViewAllDisclosures"

        #region "IsFileSizeLessThan5MB"
        // 5MB IS THE MAXIMUM FILE SIZE
        public Boolean IsFileSizeLessThan5MB(String FileSize)
        {
            // FILESIZE COMES WITH MB AT THE END, SO REMOVE IT BEFORE CONVERTING TO INT
            String temp = FileSize.Remove(FileSize.IndexOf(' '));
            return Convert.ToInt32(temp) <= 5;
        }
        #endregion

        #region "IsFileTypeAcceptable"
        // FUNCTION DETERMINES IF THE FILE TYPE IS ACCEPTABLE 
        public Boolean IsFileTypeAcceptable(String extension)
        {
            switch (extension.ToUpper())
            {
                case "JPEG": return true;
                case "JPG": return true;
                case "PDF": return true;
                case "PNG": return true;
                default: return false;
            }
        }
        #endregion


        #endregion

        #region "LoanAndLiabilityReconcile"

        #region "ValidateTransFilingIDs"
        public Boolean ValidateTransFilingIDs(string afilingID, string[] filingIDsA, string[] filingIDsB, string[] filingIDsC)
        {
            ItemizedReportsBroker objItemizedReportsBroker = new ItemizedReportsBroker();

            // CREATE A LIST TO STORE ALL THE IDS
            List<string> listOfTransFilingIDs = new List<string>();

            // ADD THE FIRST SINGULAR ID
            listOfTransFilingIDs.Add(afilingID);

            // ADD THE THREE ARRAYS TO THE LIST
            if (filingIDsA != null)
                listOfTransFilingIDs.AddRange(filingIDsA);
            if (filingIDsB != null)
                listOfTransFilingIDs.AddRange(filingIDsB);
            if (filingIDsC != null)
                listOfTransFilingIDs.AddRange(filingIDsC);

            // CONVERT THE LIST BACK TO ARRAY TO LOOP THROUGH
            string[] arrayOfTransFilingIDs = listOfTransFilingIDs.ToArray();

            // LOOP THROUGH THE ARRAY OF FILING IDS AND MAKE SURE THEY EXIST IN FILING TRANSACTION
            foreach (string filingID in arrayOfTransFilingIDs)
                if (!objItemizedReportsBroker.GetDropdownValueExistsResponse("FILING_TRANSACTIONS_FILING_TRANS_ID", filingID))
                    return false;

            return true;
        }
        #endregion

        #endregion
    }
}