/**
 * ApplicationCommonCode_EFS.js
 * Provides common solutions for page code that we see copyed and pasted all over the place.
 * Version key Mayor-Minor-Patch
 * Version 2.0.16 - Last formal update 06/12/2023.
 * Various Authors
 * Requires:
 * - boe.app-utilities.common.js 1.0.2 or higher.
 * - jquery-ui-1.12.0.js or higher.
 * - jquery-3.5.0.js or higher.
 * - dataTables.boe-accessibility-helper.js 2.0.4 or higher.
 * - DataTables 1.10.20 (jquery.dataTables.js) or higher.
 * - Responsive 2.2.3 (dataTables.responsive.js) or higher.
 * */

var $m = jQuery.noConflict();
var CONST_contactMessage = 'Please Contact NYS Board of of Elections(518) 474 - 8200.';
var CONST_errorMessage = 'Error Fetching Data. ' + CONST_contactMessage;
var CONST_openFunctionHideLoader = function () {
    $m("#divLoading").hide();//Hide any loaders.
}

//Defines the headings of a commonly used grid _UC_GridCommonNIIEWeeklyExpenditure.cshtml
const columnIndexes_UC_GridCommonNIIEWeeklyExpenditure = [
    ['Submission Date', 11],
    ['Entity Name', 12],
    ['Amount', 13],
    ['Status', 14],
    ['Amend', 15],
    ['Transaction Date', 16],
    ['Transaction Type', 17],
    ['Purpose Code', 18],
    ['Country', 19],
    ['Street Address', 20],
    ['City', 21],
    ['State', 22],
    ['Zip Code', 23],
    ['Method', 24],
    ['Check', 25],
    ['Explanation', 26],
    ['Itemized', 27],
    ['Treasurer First Name', 28],
    ['Treasurer Last Name', 29],
    ['Treasurer Middle Name', 30],
    ['Treasurer Occupation', 31],
    ['Treasurer Employer', 32],
    ['Treasurer Street Address', 33],
    ['Treasurer City', 34],
    ['Treasurer State', 35],
    ['Treasurer Zip Code', 36],
    ['Independent Expenditure Description', 37],
    ["Candidate's Name/Ballot Proposal Reference", 38],
    ['Supported', 39],
    ['Created Date', 40]];

//Defines the headings of a commonly used grid _UC_GridCommonNonItem24HourNotice.cshtml
const columnIndexes_GridCommonNonItem24HourNotice = [
    ['Submission Date', 9],
    ['Entity Name', 10],
    ['First Name', 11],
    ['Middle Name', 12],
    ['Last Name', 13],
    ['Amount', 14],
    ['Status', 15],
    ['Amend', 16],
    ['Transaction Date', 17],
    ['Transaction Type', 18],
    ['Contributor Type', 19],
    ['Contribution Type', 20],
    ['Loaner Code', 21],
    ['Country', 22],
    ['Street Address', 23],
    ['City', 24],
    ['State', 25],
    ['Zip Code', 26],
    ['Method', 27],
    ['Check', 28],
    ['Explanation', 29],
    ['Itemized', 30],
    ['Created Date', 31]];

//Defines the headings of a commonly used grid _UC_GridCommonControl.cshtml
const columnIndexes_UC_GridCommonControl = [
    ['Transaction Date', 10],
    ['Transaction Type', 11],
    ['Contributor Type', 12],
    ['Entity Name', 13],
    ['First Name', 14],
    ['Middle Name', 15],
    ['Last Name', 16],
    ['Country', 17],
    ['Street Address', 18],
    ['City', 19],
    ['State', 20],
    ['Zip Code', 21],
    ['Method', 22],
    ['Check', 23],
    ['Amount', 24],
    ['Outstanding Amount', 25],
    ['Receipt Type', 26],
    ['Transfer Type', 27],
    ['Contribution Type', 28],
    ['Purpose Code', 29],
    ['Receipt Code', 30],
    ['Original Date', 31],
    ['Loaner Code', 32],
    ['Election Year', 33],
    ['District', 34],
    ['Office', 35],
    ['Explanation', 36],
    ['Itemized', 37],
    ['County', 38],
    ['Municipality', 39],
    ['Created Date', 40]];

//Defines the headings of a commonly used grid from _UC_GridCommonNIIE24HContribution.cshtml
const columnIndexes_UC_GridCommonNIIE24HContribution = [
    ['Submission Date', 10],
    ['Entity Name', 11],
    ['First Name', 12],
    ['Middle Name', 13],
    ['Last Name', 14],
    ['Amount', 15],
    ['Status', 16],
    ['Amend', 17],
    ['Transaction Date', 18],
    ['Transaction Type', 19],
    ['Contributor Type', 20],
    ['Contribution Type', 21],
    ['Loaner Code', 22],
    ['Purpose Code', 23],
    ['Country', 24],
    ['Street Address', 25],
    ['City', 26],
    ['State', 27],
    ['Zip Code', 28],
    ['Method', 29],
    ['Check', 30],
    ['Explanation', 31],
    ['Itemized', 32],
    ['Treasurer First Name', 33],
    ['Treasurer Last Name', 34],
    ['Treasurer Middle Name', 35],
    ['Treasurer Occupation', 36],
    ['Treasurer Employer', 37],
    ['Treasurer Street Address', 38],
    ['Treasurer City', 39],
    ['Treasurer State', 40],
    ['Treasurer Zip Code', 41],
    ['Contributor Occupation', 42],
    ['Contributor Employer', 43],
    ['Independent Expenditure Description', 44],
    ["Candidate's Name / Ballot Proposal Reference", 45],
    ['Supported', 46],
    ['Created Date', 47]];

//Defines the headings of a commonly used grid from _UC_GridCommonNIIEWeeklyContribution.cshtml
const columnIndexes_UC_GridCommonNIIEWeeklyContribution = [
    ['Submission Date', 9],
    ['Entity Name', 10],
    ['First Name', 11],
    ['Middle Name', 12],
    ['Last Name', 13],
    ['Amount', 14],
    ['Status', 15],
    ['Amend', 16],
    ['Transaction Date', 17],
    ['Transaction Type', 18],
    ['Contributor Type', 19],
    ['Contribution Type', 20],
    ['Loaner Code', 21],
    ['Country', 22],
    ['Street Address', 23],
    ['City', 24],
    ['State', 25],
    ['Zip Code', 26],
    ['Method', 27],
    ['Check', 28],
    ['Explanation', 29],
    ['Itemized', 30],
    ['Treasurer First Name', 31],
    ['Treasurer Last Name', 32],
    ['Treasurer Middle Name', 33],
    ['Treasurer Occupation', 34],
    ['Treasurer Employer', 35],
    ['Treasurer Street Address', 36],
    ['Treasurer City', 37],
    ['Treasurer State', 38],
    ['Treasurer Zip Code', 39],
    ['Contributor Occupation', 40],
    ['Contributor Employer', 41],
    ['Independent Expenditure Description', 42],
    ["Candidate's Name / Ballot Proposal Reference", 43],
    ['Supported', 44],
    ['Created Date', 45]];

/**
 * This code is used widely in various schedule reports.
 * Appends label text to _validate elementys based on a list of custom errors returned from the server.
 * It won't do anyting to handle "AmmountError" keys but it will return true if it sees one in the list.
 * @param {Objectparam} {result.Errors} errorList
 * @param {map} errorLabelDiscrepancies for keys that don't match their input convention. Uses a map of string string.
 * Example of such map:
 * var errorLabelDiscrepancies = new Map([[ "txtAmt", "txtAmtABC"],[ "txtPartAmt", "txtPartAmtAC"]]);
 * The pattern is ["Result Key", "inputID"]
 * The code is meant to replace things like 
 * The function is mean to replace this type of code basically:
    for (var i = 0; i < results.Errors.length; i++) {
        if (results.Errors[i].Key == "txtPartAmt") {
            $m("#txtAmtABC_validate").append('<label for="txtAmtABC" class="error">' + results.Errors[i].Value + '</label>');
        }
        if (results.Errors[i].Key == "txtPartExplanationInKind") {
            $m("#txtPartExplanationInKind_validate").append('<label for="txtPartExplanationInKind" class="error">' + results.Errors[i].Value + '</label>');
        }
        if (results.Errors[i].Key == "AmountError") {
            ShowDialogBox('EFS', 'Partnership Amount cannot be more than Outstanding Amount $' + parseFloat(expPartAmount).toFixed(2).toString(), 'Ok', '');
        }
    }
  * The repacement code would look like this.
    var hasAmmountError = appCommonEFS_AppendCustomErrorLabelsForAmmountError(results.Errors, false);

    if (hasAmmountError) {
        ShowDialogBox('EFS', 'Amount cannot be less than partnership details amount $' + parseFloat(resultsPartnershipAmt).toFixed(2).toString(), 'Ok', '');
    }
  * If you have special overides it is recommednded you make a page specific function with errorLabelDiscrepancies 
*/

function appCommonEFS_AppendCustomErrorLabelsForAmmountError(errorList, errorLabelDiscrepancies) {
    var hasAmmountError = false;
    try {
        for (var i of errorList) {
            //Ammount error logic can be difficult to extrapolate and so it should be supported outside this function.
            if (errorList[i].Key != "AmountError") {
                //Handle edge cases where the label id doesn't match the eror label text.
                if (errorLabelDiscrepancies && errorLabelDiscrepancies.has(errorList[i].Key)) {
                    $m("#" + errorLabelDiscrepancies.get(errorList[i].Key) + "_validate").append('<label for="' + errorLabelDiscrepancies.get(errorList[i].Key) + '" class="error">' + errorList[i].Value + '</label>');
                } else {
                    //Handle any cases that conform to naming convetnion key == Key+"_validate" == label for input id "key".
                    //Check by Naming convention.
                    var label = $m("div[id^='" + errorList[i].Key + "_validate']");
                    if (label && label.length > 0) {
                        label.append('<label for="' + errorList[i].Value + '" class="error">' + errorList[i].Value + '</label>');
                    }
                }
            } else {
                hasAmmountError = true;
            }
        }
    } catch (e) {
        console.error("ApplicationCommonCode_EFS:appCommonEFS_AppendCustomErrorLabelsForAmmountError runtime exception error!");
        console.error(e);
        return hasAmmountError;
    }
    return hasAmmountError;
}

/**
 * Solution used for binding and selecting values in a DDL. Used often by GetPaymentMethodData, GetContributionNameData, GetContributionTypeData
 * Executes the call, empties the DDL, fills the DDL and if theres a comparator it will try to select it.
 * @param {String} urlGetPaymentMethodData controller method with the dialog
 * @param {String} stringComparator the value we will try to set the targetDDLSelector option to this by either value or name.
 * @param {String} targetDLLSelector the target DDL field we will populate and select. Example #SomeId or .someClass
 * @param {String} errorDecorator Should match "Error fetching <your errorDecorator variable> data."
 */
function appCommonEFS_BindAndPopulateDLL(urlGetPaymentMethodData, stringComparator, targetDLLSelector, errorDecorator) {
    try {
        if (urlGetPaymentMethodData && stringComparator && stringComparator) {
            // Build Ajax Code
            var options = {};
            options.url = urlGetPaymentMethodData;
            options.type = "POST";
            options.data = null;
            options.dataType = "json";
            options.contentType = "application/json";
            options.success = function (results) {
                $m(targetDLLSelector).empty();
                for (var i in results) {
                    $m(targetDLLSelector).append("<option value='" + results[i].Value + "'>" + results[i].Text + "</option>");
                }
                // Set Contributor Type
                if (stringComparator != null || stringComparator != "") {
                    $m(targetDLLSelector + " option")
                        .filter(function () {
                            //Try to find a match option by value or if not by text.
                            return $m(this).val() == stringComparator || $m(this).text() == stringComparator;
                        })
                        .attr('selected', 'selected');
                }
            };
            options.error = function () {
                //Hide any loaders if we're displaying messages.
                ShowDialogBoxWithOpenFunction('EFS', 'Error Fetching ' + (errorDecorator ? errorDecorator : "") + ' Data. ' + CONST_contactMessage, 'Ok', '', CONST_openFunctionHideLoader);
            };
            $m.ajax(options);
        }
    } catch (e) {
        console.error("ApplicationCommonCode_EFS:appCommonEFS_BindAndPopulateDLL runtime exception error!");
        console.error(e);
    }
}

/**
 * Makes an ajax call to "~/_UC_GridCommonControl/UpdateColumnValue/".
 * Passes "uniqueValueForAjax" for "uniqueValue".
 * Updates the table reference in "dataTableInstance"
 * @param {String} uniqueValueForAjax (required) - String value to feed ~/_UC_GridCommonControl/UpdateColumnValue/.
 * @param {DataTables.Api DataTable} dataTableInstance (required) - Table to update. These can be provided via $m('#' + gridName).DataTable() which returns a DataTables API instance and should not to be confused with $m('#' + gridName).dataTable() which returns a jQuery Object.
 * @param {String} jqueryMultiSelectIdForHideColumn (required) - Jquery multi-select id to use when hiding colums
 * @param {ajax data param} dataOverides (required) - Data values used for appCommonEFS_GetAllTransactionTypesDataCommon.
 */
function appCommonEFS_btnSetPrefrencesCommonCode(uniqueValueForAjax, dataTableInstance, jqueryMultiSelectIdForHideColumn, dataOverides) {
    if (bUtilIsString(uniqueValueForAjax) && dataTableInstance && bUtilIsString(jqueryMultiSelectIdForHideColumn) && bUtilIsObject(dataOverides)) {
        try {
            $m("#divLoading").show();
            //Prepare aja options.
            var options = {};
            options.url = "/_UC_GridCommonControl/UpdateColumnValue/";
            options.type = "GET";
            options.data = {
                uniqueValue: uniqueValueForAjax
            };
            options.dataType = "json";
            options.contentType = "application/json";
            options.success = function (results) {
                window.status = "Preferences saved successfully";
                //Bind Grid also hides loading.
                appCommonEFS_GetAllTransactionTypesDataCommon(true, dataTableInstance, dataOverides, false);
                var rules = {
                    "indexesToStartHidden": [0, 1, 2, 3, 4, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43],
                    "indexesToAlwaysKeepUnhidden": [8, 9], //Will always unhide.
                    "columnNamesToUnhide": $m("#" + jqueryMultiSelectIdForHideColumn).multipleSelect("getSelects", "text").toString().split(","),//String to match.
                    "columnNamesIndexMappings": appCommonEFS_GetGridColumnSettings("UC_GridCommonControl") //String in header, index to unhide
                }
                //Hide the columns
                appCommonEFS_HideTableColumn(dataTableInstance, rules);
            };
            options.error = function () {
                //Hide any loaders if we're displaying messages.
                ShowDialogBoxWithOpenFunction('EFS', CONST_errorMessage, 'Ok', '', CONST_openFunctionHideLoader);
            };
            $m.ajax(options);
        } catch (e) {
            $m("#divLoading").hide();
            console.error("ApplicationCommonCode_EFS:appCommonEFS_btnSetPrefrencesCommonCode runtime exception error!");
            console.error(e);
        }
    } else {
        console.error("ApplicationCommonCode_EFS:appCommonEFS_btnSetPrefrencesCommonCode One of the parameters was invalid!");
    }
}

/**
 * This code will remove the label text and class errro for a given input id.
 * @param {Objectparam} {array[String]} inputIdArray
 * The code is meant to replace things like
 * The function is mean to replace this type of code basically:
        $m("label[for=txtSubcontractorName]").text('');
        $m("#txtSubcontractorName").removeClass("error");
        $m("label[for=txtPartFirstName]").text('');
        $m("#txtPartFirstName").removeClass("error");
  * The repacement code would look like this.
    var hasAmmountError = appCommonEFS_AppendCustomErrorLabelsForAmmountError(["txtSubcontractorName", "txtPartFirstName"]);

    if (hasAmmountError) {
        ShowDialogBox('EFS', 'Amount cannot be less than partnership details amount $' + parseFloat(resultsPartnershipAmt).toFixed(2).toString(), 'Ok', '');
    }
  * If you have special overides it is recommednded you make a page specific function with errorLabelDiscrepancies
*/
function appCommonEFS_ClearLabeltextAndRemoveClassError(inputIdArray) {
    try {
        for (var i of inputIdArray) {
            $m("label[for=" + inputIdArray[i] +"]").text('');
            $m("#" + inputIdArray[i] +"").removeClass("error");
        }
    } catch (e) {
        console.error("ApplicationCommonCode_EFS:appCommonEFS_ClearLabeltextAndRemoveClassError runtime exception error!");
        console.error(e);
    }
}

/**
 * Common code will take a string number and determine what IE Contribution schedule to redirect to.
 * Determine if you can delete. If not pop ups will appear. If able this will retreive the message and redirect url.
 * You can also provide a label id (or id's) selector to update.
 * Also hides $m("#divLoading") on failiure.
 * @param {String} dataStringScheduleNumber This is the number of the schedule we will move to.
 * Valid numbers include "1", "2", "3", "4" and "9".
 * @param {String} dataFilingTransIdEdit This is the transaction number we will store into session variables.
 */
function appCommonEFS_DetermineIeContributionRedirect(dataStringScheduleNumber, dataFilingTransIdEdit) {
    if (!bUtilIsString(dataStringScheduleNumber)
        || dataStringScheduleNumber.trim() == ""
        || !bUtilIsString(dataFilingTransIdEdit)
        || dataFilingTransIdEdit.trim() == "") {
        console.error("ApplicationCommonCode_EFS:appCommonEFS_DetermineIeContributionRedirect valid schedule or transaction string was not provided!");
        return;
    }
    try {
        //Keep loading element open until we move to the other page.
        var newHeaderText = $m("#lblHeader").text();//Get the current header text
        var urlLocation = false;
        switch (dataStringScheduleNumber) {
            case "1": // Monetary Contributions Received From Individual & Partnerships EDIT TRANSACTION
                newHeaderText = "Contributions - Candidate, Individual & Family";
                urlLocation = "/NonItemIEWeeklyContributionSchedA/NonItemIEWeeklyContributionSchedA/";
                break;
            case "2": // Monetary Contributions Received From Corporate EDIT TRANSACTION
                newHeaderText = "Monetary Contributions Received From Corporate";
                urlLocation = "/NonItemIEWeeklyContributionSchedB/NonItemIEWeeklyContributionSchedB/";
                break;
            case "3": // Monetary Contributions Received From All Other EDIT TRANSACTION
                newHeaderText = "Monetary Contributions Received From All Other";
                urlLocation = "/NonItemIEWeeklyContributionSchedC/NonItemIEWeeklyContributionSchedC/";
                break;
            case "4": // In-Kind (Non-Monetary) Contributions Received EDIT TRANSACTION
                newHeaderText = "Contributions - In Kind";
                urlLocation = "/NonItemIEWeeklyContributionSchedD/NonItemIEWeeklyContributionSchedD/";
                break;
            case "9": // Loans Received EDIT TRANSACTION
                newHeaderText = "Loan Received";
                urlLocation = "/NonItemIEWeeklyContributionSchedI/NonItemIEWeeklyContributionSchedI/";
                break;
            default:
                break;
        }
        if (urlLocation) {
            // Set the Session Variable for Edit DialogBox.
            sessionStorage.setItem("ScheduleId", dataStringScheduleNumber);
            sessionStorage.setItem("FilingTransIdEdit", dataFilingTransIdEdit);
            sessionStorage.setItem("EditFlag", "True");
            $m("#lblHeader,#lblHeader1,#lblHeader2, .lblHeaderSelector").text(newHeaderText);
            window.location.href = urlLocation;
        } else {
            console.error("ApplicationCommonCode_EFS:appCommonEFS_DetermineIeContributionRedirect unable to find url redirect for dataStringScheduleNumber '" + dataStringScheduleNumber + "'.");
            //Hide any loaders if we're displaying messages.
            ShowDialogBoxWithOpenFunction('EFS', 'Failed to redirect to page.', 'Ok', '', CONST_openFunctionHideLoader);
        }
    } catch (e) {
        console.error("ApplicationCommonCode_EFS:appCommonEFS_DetermineIeContributionRedirect runtime exception error!");
        console.error(e);
    }
}

/**
 * Common code will take a string number and determine what Non-Itemized Transaction Schedule to redirect to.
 * Determine if you can delete. If not pop ups will appear. If able this will retreive the message and redirect url.
 * You can also provide a label id (or id's) selector to update.
 * Also hides $m("#divLoading") on failiure.
 * @param {String} dataStringScheduleNumber This is the number of the schedule we will move to.
 * Valid numbers include "1", "2", "3", "4" and "9".
 * @param {String} dataFilingTransIdEdit This is the transaction number we will store into session variables.
 */
function appCommonEFS_DetermineNonItemizedTransactionSchedRedirect(dataStringScheduleNumber, dataFilingTransIdEdit) {
    if (!bUtilIsString(dataStringScheduleNumber)
        || dataStringScheduleNumber.trim() == ""
        || !bUtilIsString(dataFilingTransIdEdit)
        || dataFilingTransIdEdit.trim() == "") {
        console.error("ApplicationCommonCode_EFS:appCommonEFS_DetermineNonItemizedTransactionSchedRedirect valid schedule or transaction string was not provided!");
        return;
    }
    try {
        //Keep loading element open until we move to the other page.
        var newHeaderText = $m("#lblHeader").text();//Get the current header text
        var urlLocation = false;
        switch (dataStringScheduleNumber) {
            case "1": // Monetary Contributions Received From Individual & Partnerships EDIT TRANSACTION
                newHeaderText = "Contributions - Candidate, Individual & Family";
                urlLocation = "/NonItemizedTransactionSchedA/NonItemizedTransactionSchedA/";
                break;
            case "2": // Monetary Contributions Received From Corporate EDIT TRANSACTION
                newHeaderText = "Monetary Contributions Received From Corporate";
                urlLocation = "/NonItemizedTransactionSchedB/NonItemizedTransactionSchedB/";
                break;
            case "3": // Monetary Contributions Received From All Other EDIT TRANSACTION
                newHeaderText = "Monetary Contributions Received From All Other";
                urlLocation = "/NonItemizedTransactionSchedC/NonItemizedTransactionSchedC/";
                break;
            case "4": // In-Kind (Non-Monetary) Contributions Received EDIT TRANSACTION
                newHeaderText = "Contributions - In Kind";
                urlLocation = "/NonItemizedTransactionSchedD/NonItemizedTransactionSchedD/";
                break;
            case "9": // Loans Received EDIT TRANSACTION
                newHeaderText = "Loan Received";
                urlLocation = "/NonItemizedTransactionSchedI/NonItemizedTransactionSchedI/";
                break;
            default:
                break;
        }
        if (urlLocation) {
            // Set the Session Variable for Edit DialogBox.
            sessionStorage.setItem("ScheduleId", dataStringScheduleNumber);
            sessionStorage.setItem("TransNumberEdit", dataFilingTransIdEdit);
            sessionStorage.setItem("EditFlag", "True");
            $m("#lblHeader,#lblHeader1,#lblHeader2, .lblHeaderSelector").text(newHeaderText);
            window.location.href = urlLocation;
        } else {
            console.error("ApplicationCommonCode_EFS:appCommonEFS_DetermineNonItemizedTransactionSchedRedirect unable to find url redirect for dataStringScheduleNumber '" + dataStringScheduleNumber + "'.");
            //Hide any loaders if we're displaying messages.
            ShowDialogBoxWithOpenFunction('EFS', 'Failed to redirect to page.', 'Ok', '', CONST_openFunctionHideLoader);
        }
    } catch (e) {
        console.error("ApplicationCommonCode_EFS:appCommonEFS_DetermineNonItemizedTransactionSchedRedirect runtime exception error!");
        console.error(e);
    }
}

/**
 * Common code will take a string number and determine what schedule to redirect to.
 * Also hides $m("#divLoading") on failiure.
 * @param {String} dataStringScheduleNumber This is the number of the schedule we will move to.
 * Valid numbers include "1" through "18" excluding "14" and "15"
 * @param {String} dataStringTransNumber This is the transaction number we will store into session variables.
 */
function appCommonEFS_DetermineScheduleRedirect(dataStringScheduleNumber, dataStringTransNumber) {

    if (!bUtilIsString(dataStringScheduleNumber)
        || dataStringScheduleNumber.trim() == ""
        || !bUtilIsString(dataStringTransNumber)
        || dataStringTransNumber.trim() == "") {
        console.error("ApplicationCommonCode_EFS:appCommonEFS_DetermineScheduleRedirect valid schedule or transaction string was not provided!");
        return;
    }
    try {
        //Keep loading element open until we move to the other page.
        var newHeaderText = $m("#lblHeader").text();//Get the current header text
        var urlLocation = false;
        switch (dataStringScheduleNumber){
             case "1": // Monetary Contributions Received From Individual & Partnerships EDIT TRANSACTION
                newHeaderText = "Monetary Contributions Received From Individual & Partnerships";
                urlLocation = "/ContributionsCandIndFamily/ContributionsCandIndFamily/";
                sessionStorage.setItem("IndPart", "Yes"); // Schedule '1' - A
                sessionStorage.setItem("Corporate", "No"); // Schedule '2' - B
                sessionStorage.setItem("Other", "No"); // Schedule '3' - C
                break;
             case "2": // Monetary Contributions Received From Corporate EDIT TRANSACTION
                newHeaderText = "Monetary Contributions Received From Corporate";
                urlLocation = "/ContributionsCandIndFamily/ContributionsCandIndFamily/";
                sessionStorage.setItem("Corporate", "Yes");
                sessionStorage.setItem("IndPart", "No");
                sessionStorage.setItem("Other", "No");
               break;
            case "3": // Monetary Contributions Received From All Other EDIT TRANSACTION
                newHeaderText = "Monetary Contributions Received From All Other";
                urlLocation = "/ContributionsCandIndFamily/ContributionsCandIndFamily/";
                sessionStorage.setItem("Other", "Yes");
                sessionStorage.setItem("IndPart", "No");
                sessionStorage.setItem("Corporate", "No");
              break;
            case "4": // In-Kind (Non-Monetary) Contributions Received EDIT TRANSACTION
                newHeaderText = "Contributions - In Kind";
                urlLocation = "/ContributionInKind/ContributionInKind/";
              break;
            case "5": // Other Receipts Received EDIT TRANSACTION
                newHeaderText = "Other Receipts";
                urlLocation = "/OtherReceiptsReceivedSchedE/OtherReceiptsReceivedSchedE/";
              break;
            case "6": // Expenditures/Payments EDIT TRANSACTION
                newHeaderText = "Expenditure Payments";
                urlLocation = "/ExpenditurePaymentsSchedF/ExpenditurePaymentsSchedF/";
              break;
            case "7": // Transfers In EDIT TRANSACTION
                newHeaderText = "Transfer In";
                urlLocation = "/TransferInScheG/TransferInScheG/";
              break;
            case "8": // Transfers Out EDIT TRANSACTION
                newHeaderText = "Transfer Out";
                urlLocation = "/TransferOutSchedH/TransferOutSchedH/";
              break;
            case "9": // Loans Received EDIT TRANSACTION
                newHeaderText = "Loan Received";
                urlLocation = "/LoanReceivedSchedI/LoanReceivedSchedI/";
              break;
            case "10": // Loan Repayments EDIT TRANSACTION
                newHeaderText = "Loan Repayments";
                urlLocation = "/LoanRepaymentsSchedJ/LoanRepaymentsSchedJ/";
              break;
            case "11": // Liabilities/Loans Forgiven EDIT TRANSACTION
                newHeaderText = "Liabilities/Loans Forgiven";
                urlLocation = "/LiabilitiesLoansForgivenSchedK/LiabilitiesLoansForgivenSchedK/";
              break;
            case "12": // Expenditure Refunds (Increases Balance) EDIT TRANSACTION
                newHeaderText = "Expenditure Refund";
                urlLocation = "/ExpenditureRefundsSchedL/ExpenditureRefundsSchedL/";
              break;
            case "13": // Contributions Refunded (Decreases Balance) EDIT TRANSACTION
                newHeaderText = "Contributions Refunded";
                urlLocation = "/ContributionRefundedSchedM/ContributionRefundedSchedM/";
              break;
            case "16": // Non-Campaign Housekeeping Receipts EDIT TRANSACTION
                newHeaderText = "Non-Campaign HouseKeeping Receipts";
                urlLocation = "/NonCampaignHousekeepingReceiptsSchedP/NonCampaignHousekeepingReceiptsSchedP/";
              break;
            case "17": // Non-Campaign Housekeeping Expenses EDIT TRANSACTION
                newHeaderText = "Non-Campaign HouseKeeping Expenses";
                urlLocation = "/NonCampaignHousekeepingExpensesSchedQ/NonCampaignHousekeepingExpensesSchedQ/";
               break;
            case "18": // Expense Allocation Amoung Candidates EDIT TRANSACTION
                newHeaderText = "Amount Allocated";
                urlLocation = "/ExpensesAllocationScheR/ExpensesAllocationScheR/";
                break;
            case "19": // Public Fund Receipts EDIT TRANSACTION
                newHeaderText = "Public Fund Receipts ";
                urlLocation = "/PublicFundReceiptsSchedS/PublicFundReceiptsSchedS/";
                break;
            case "20": // Public Fund Expenses EDIT TRANSACTION
                newHeaderText = "Public Fund Expenses";
                urlLocation = "/PublicFundExpensesSchedT/PublicFundExpensesSchedT/";
                break;
            case "21": // Public Fund Repayment EDIT TRANSACTION
                newHeaderText = "Public Fund Repayment";
                urlLocation = "/PublicFundRepaymentSchedU/PublicFundRepaymentSchedU/";
                break;
            default:
              break;
        }
        if (urlLocation) {
            // Set the Session Variable for Edit DialogBox.
            sessionStorage.setItem("ScheduleId", dataStringScheduleNumber);
            sessionStorage.setItem("TransNumberEdit", dataStringTransNumber);
            sessionStorage.setItem("EditFlag", "True");
            $m("#lblHeader,#lblHeader1,#lblHeader2,.lblHeaderSelector").text(newHeaderText);
            window.location.href = urlLocation;
        } else {
            sessionStorage.setItem("Corporate", "No");
            sessionStorage.setItem("IndPart", "No");
            sessionStorage.setItem("Other", "No");
            console.error("ApplicationCommonCode_EFS:appCommonEFS_DetermineScheduleRedirect unable to find url redirect for dataStringScheduleNumber '" + dataStringScheduleNumber +"'.");
            //Hide any loaders if we're displaying messages.
            ShowDialogBoxWithOpenFunction('EFS', 'Failed to redirect to page.', 'Ok', '', CONST_openFunctionHideLoader);
        }
    } catch (e) {
        console.error("ApplicationCommonCode_EFS:appCommonEFS_DetermineScheduleRedirect runtime exception error!");
        console.error(e);
    }
}

/**
 * Common code will take a string number and determine what schedule to redirect to for the delete operation.
 * Also hides $m("#divLoading") on failiure.
 * @param {[int]} dataTransArray This is the number of the schedule we will move to.
 * Valid numbers include "1" through "18" excluding "14" and "15"
 * @param {Object} deleteData Contains values used to determine delete operation.
 * Must contain:
 * {
 *      resultDelSchedF: "",
 *      resultDelSchedN: "",
 *      resultDelSchedABC: "",
 *      resultDeleteFlagSchedI:
 * }
 * @returns false OR an Object with two attributes alertMessageForOperation and deleteURL.
 */
function appCommonEFS_DetermineScheduleDelete(dataTransArray, deleteData) {
    //Not the congnitive complexity of this function is high. Leave it as is.
    if (!bUtilIsArray(dataTransArray)
        || !bUtilIsObject(deleteData)) {
        console.error("ApplicationCommonCode_EFS:appCommonEFS_DetermineScheduleDelete valid schedule or transaction string was not provided!");
        return false;
    }
    try {
        //Check values for non Strings
        deleteData.resultDelSchedF = bUtilSanitizeString(deleteData.resultDelSched);
        deleteData.resultDelSchedN = bUtilSanitizeString(deleteData.resultDelSchedN);
        deleteData.DelSchedABC = bUtilSanitizeString(deleteData.DelSchedABC);
        deleteData.DeleteFlagSchedI = bUtilSanitizeString(deleteData.DeleteFlagSchedI);

        //Keep loading element open until we move to the other page.
        var alertMessageForOperation = "Are you sure you want to delete this transaction?";
        var deleteURL = "/ContributionsCandIndFamily/DeleteFilingTransactions/";//Common URL
        //A subResult is needed for schedules with more complex logic.
        var subResult = false;
        switch (dataTransArray[1].toString()) {
            case "1"://Monetary Contributions Received From Ind. & Part.
            case "2"://Monetary Contributions Received From Corporate transaction
            case "3"://Monetary Contributions Received From All Other transaction 
            case "4"://In-Kind (Non-Monetary) Contributions Received transaction
                //This logic is complex so it goes into a separate function.
                subResult = appCommonEFS_DetermineDeleteForContributionsCandIndFamily(dataTransArray, deleteData.resultDelSchedABC);
                //Runs when deleteData.resultDelSchedABC.toString().toUpperCase() != "TRUE"
                alertMessageForOperation = subResult;
                break;
            case "6"://ExpenditurePaymentsSchedF
                //This logic is complex so it goes into a separate function.
                subResult = appCommonEFS_DetermineDeleteForScheduleF(dataTransArray, deleteData.resultDelSchedF);
                //Runs when resultDelSchedF.toString().toUpperCase() != "TRUE"
                alertMessageForOperation = subResult;
                deleteURL = "/ExpenditurePaymentsSchedF/DeleteFilingTransactions/";
                break;
            case "20"://Qualified Expenditures
                //This logic is complex so it goes into a separate function.
                subResult = appCommonEFS_DetermineDeleteForScheduleF(dataTransArray, deleteData.resultDelSchedF);
                //Runs when resultDelSchedF.toString().toUpperCase() != "TRUE"
                alertMessageForOperation = subResult;
                deleteURL = "/PublicFundExpensesSchedT/DeleteFilingTransactions/";
                break;
            case "9"://LoanReceivedSchedI
                //Anything other than would indicate we do not want to allow the delete. Why is it no just expecting "TRUE" is unkown at this time.
                if(deleteData.resultDeleteFlagSchedI.toUpperCase() != "FALSE") {
                    //Hide any loaders if we're displaying messages.
                    ShowDialogBoxWithOpenFunction('EFS', 'Either Liabilities/Loans Forgiven or Loan Payments exists against this Loan. Delete these transactions before deleting the Loan.', 'Ok', '', CONST_openFunctionHideLoader);
                    return false;
                }
                //Runs when deleteData.resultDeleteFlagSchedI.toUpperCase() == "FALSE
                alertMessageForOperation = "Deleting Loan Received will delete all loan repayments, loan forgiven and outstanding loans records associated with this loan. Are you sure you want to delete?";
                deleteURL = "/LoanReceivedSchedI/DeleteLoanReceived/";
                break;
            case "10"://LoanRepaymentsSchedJ
                alertMessageForOperation = "Deleting Loan Repayment will delete the outstanding loan record and associated with this loan repayment. Are you sure you want to delete?";
                deleteURL = "/LoanRepaymentsSchedJ/DeleteLoanRepayment/";
                break;
            case "11"://LiabilitiesLoansForgivenSchedK
                alertMessageForOperation = "If you Delete Liabilities/Loans Forgiven then Outstanding Liabilities/Loans will also deleted. Do you want to be continue?";
                deleteURL = "/LiabilitiesLoansForgivenSchedK/DeleteLoanForgiven/";
                break;
            case "14"://OutStandingLiabilityLoansSchedN
                deleteURL = "/OutStandingLiabilityLoansSchedN/DeleteOutstandingLiability/";
                if (deleteData.resultSchedNExists.toString() != "FALSE") {
                    alertMessageForOperation = 'This outstanding original liability is linked with either Schedule F or Schedule K transaction(s). This cannot be deleted';
                }
                break;
            case "16"://ContributionsCandIndFamily Partnership including LLPs
                if (dataTransArray[30].toString() == "Partnership including LLPs") {
                    alertMessageForOperation = "Deleting this transaction will also delete the partnership details added for this transaction. Are you sure you want to delete?";
                }
                break;
            case "17"://ContributionsCandIndFamily Reimbursement and Credit Card
                //This logic is complex so it goes into a separate function.
                subResult = appCommonEFS_DetermineDeleteForContCandIndFamReimbAndCard(dataTransArray, deleteData.resultDelSchedF);
                //Runs when resultDelSchedF.toString().toUpperCase() != "TRUE"
                alertMessageForOperation = subResult;
                break;
            case "5"://Other Receipts Received "OtherReceiptsReceived"
            case "7"://Transfers In "TransferInScheduleG".
            case "8"://Transfers Out "TransferOutScheduleH".
            case "12"://Expenditure Refunds (Increases Balance)
            case "13"://Contributions Refunded (Decreases Balance) "ContributionRefundedSchedM".
            case "21"://Public Fund Repayment Sched U "PublicFundRepaymentSchedU".
            case "18"://Expense Allocation Among Candidates "ExpensesAllocationScheR".
            case "19"://Public Fund Receipts
                //5,7,8,12,13,18 and 19 currently don't change either the default alertMessageForOperation or default deleteURL.
                break;
            default:
                console.error("ApplicationCommonCode_EFS:appCommonEFS_DetermineScheduleDelete Unsuported transaction value of '" + dataTransArray[1].toString() + "'!");
                return false;
        }
        //False is a bad sign which implies the alertMessageForOperation will also be false.
        if (!alertMessageForOperation || !deleteURL) {
            return false;
        } else {
            return {
                alertMessageForOperation: alertMessageForOperation,
                deleteURL: deleteURL
            }
        }
    } catch (e) {
        console.error("ApplicationCommonCode_EFS:appCommonEFS_DetermineScheduleDelete runtime exception error!");
        console.error(e);
    }
}

/**
 * Extracts logic for determining if we can delete a ContributionsCandIndFamily controlled record (Sched A, B, C, D).
 * @param {[int]} dataTransArray Contains the number of the schedule we will move to as well as other information we are interested in indexes 1 and 3.
 * @param {String} resultDelSchedABC Contains values used for determining uperation.
 * @returns false OR a String with and alertMessageForOperation.
 */
function appCommonEFS_DetermineDeleteForContributionsCandIndFamily(dataTransArray, resultDelSchedABC) {
    var alertMessageForOperation = false;
    if (!bUtilIsArray(dataTransArray)
        || !bUtilIsString(resultDelSchedABC)) {
        console.error("ApplicationCommonCode_EFS:appCommonEFS_DetermineDeleteForContributionsCandIndFamily valid schedule or transaction string was not provided!");
        return false;
    }
    try {
        //TRUE would indicate we do not want to allow the delete.
        if (resultDelSchedABC.toString().toUpperCase() == "TRUE") {
            var constraintString = false;
            switch (dataTransArray[1].toString()) {
                case "1"://Monetary Contributions Received From Ind. & Part.
                    constraintString = 'Monetary Contributions Received From Ind. & Part.';
                    break;
                case "2"://Monetary Contributions Received From Corporate transaction
                    constraintString = 'Monetary Contributions Received From Corporate';
                    break;
                case "3"://Monetary Contributions Received From All Other transaction
                    constraintString = 'Monetary Contributions Received From All Other';
                    break;
                case "4"://In-Kind (Non-Monetary) Contributions Received transaction
                    constraintString = 'In-Kind (Non-Monetary) Contributions Received';
                    break;
                default:
                    break;
            }
            if (!constraintString) {
                console.log("ApplicationCommonCode_EFS:appCommonEFS_DetermineDeleteForContributionsCandIndFamily Unsuported transaction value of '" + dataTransArray[1].toString() + "'!");
                ShowDialogBoxWithOpenFunction('EFS', 'This transaction cannot be deleted as corresponding Contribution Refunds transaction(s) exist.', 'Ok', '', CONST_openFunctionHideLoader);
            } else {
                //Hide any loaders if we're displaying messages.
                ShowDialogBoxWithOpenFunction('EFS', constraintString + ' transaction cannot be deleted as corresponding Contribution Refunds transaction(s) exist.', 'Ok', '', CONST_openFunctionHideLoader);
            }
            return false;
        }
        //When resultDelSchedABC.toString().toUpperCase() != "TRUE") {
        switch (dataTransArray[3].toString()) {
            case "5"://For dataTransArray[1] == 1 and dataTransArray[1] == 4. Monetary Contributions Received From Ind. & Part.
                alertMessageForOperation = "Deleting this transaction will also delete the partnership details added for this transaction. Are you sure you want to delete this transaction?";
                break;
            case "11"://For dataTransArray[1] == 3. Monetary Contributions Received From Corporate transaction
                alertMessageForOperation = "Deleting this transaction will also delete the attribution details added for this transaction.Are you sure you want to delete?";
                break;
            default:
                //Default message
                alertMessageForOperation = "Are you sure you want to delete this transaction ?"
                console.log("ApplicationCommonCode_EFS:appCommonEFS_DetermineDeleteForContributionsCandIndFamily Unsuported transaction value of '" + dataTransArray[3].toString() + "'!");
                break;
        }
    } catch (e) {
        console.error("ApplicationCommonCode_EFS:appCommonEFS_DetermineDeleteForContributionsCandIndFamily runtime exception error!");
        console.error(e);
    }
    return alertMessageForOperation;
}

/**
 * Extracts logic for determining if we can delete a Non-Campaign Housekeeping Expenses.
 * @param {[int]} dataTransArray Contains the number of the schedule we will move to as well as other information we are interested in indexes 29.
 * @param {String} resultDelSchedF Contains values used for determining uperation.
 * @returns false OR a String with and alertMessageForOperation.
 */
function appCommonEFS_DetermineDeleteForContCandIndFamReimbAndCard(dataTransArray, resultDelSchedF) {
    var alertMessageForOperation = false;
    if (!bUtilIsArray(dataTransArray)
        || !bUtilIsString(resultDelSchedF)) {
        console.error("ApplicationCommonCode_EFS:appCommonEFS_DetermineDeleteForContCandIndFamReimbAndCard valid schedule or transaction string was not provided!");
        return false;
    }
    try {
        //Check to see if we can't delete this based on response.
        //TRUE would indicate we do not want to allow the delete.
        if (resultDelSchedF.toString().toUpperCase() == "TRUE") {
            //Hide any loaders if we're displaying messages.
            ShowDialogBoxWithOpenFunction('EFS', 'Non-Campaign Housekeeping Expenses transaction cannot be deleted as corresponding Expenditure Refunds transaction(s) exist.', 'Ok', '', CONST_openFunctionHideLoader);
            return false;
        }
        //When resultDelSchedF.toString().toUpperCase() != "TRUE") {
        if (dataTransArray[29].toString() == "Reimbursement") { // Reimbursement Details
            alertMessageForOperation = "Deleting this transaction will also delete the reimbursement details added for this transaction. Are you sure you want to delete this transaction?";
        }
        else if (dataTransArray[29].toString() == "Credit Card Payment") { // Credit Card Itemization
            alertMessageForOperation = "Deleting this transaction will also delete the credit card itemization added for this transaction. Are you sure you want to delete this transaction?";
        } else {
            //Default message
            alertMessageForOperation = "Are you sure you want to delete this transaction ?"
            console.log("ApplicationCommonCode_EFS:appCommonEFS_DetermineDeleteForContCandIndFamReimbAndCard Unsuported transaction value of [29] = '" + dataTransArray[29].toString() + "'!");
        }
    } catch (e) {
        console.error("ApplicationCommonCode_EFS:appCommonEFS_DetermineDeleteForContCandIndFamReimbAndCard runtime exception error!");
        console.error(e);
    }
    return alertMessageForOperation;
}

/**
 * Extracts logic for determining if we can delete a schedule F Expenditures/Payments.
 * @param {[int]} dataTransArray Contains the number of the schedule we will move to as well as other information we are interested in indexes 29, 7 and 6.
 * @param {String} resultDelSchedF Contains values used for determining uperation.
 * @returns false OR a String with and alertMessageForOperation.
 */
function appCommonEFS_DetermineDeleteForScheduleF(dataTransArray, resultDelSchedF) {
    var alertMessageForOperation = false;
    if (!bUtilIsArray(dataTransArray)
        || !bUtilIsString(resultDelSchedF)) {
        console.error("ApplicationCommonCode_EFS:appCommonEFS_DetermineDeleteForScheduleF valid schedule or transaction string was not provided!");
        return false;
    }
    try {
        //Check to see if we can't delete this based on response.
        if (resultDelSchedF.toString().toUpperCase() == "TRUE") {
            //Hide any loaders if we're displaying messages.
            ShowDialogBoxWithOpenFunction('EFS', 'Expenditures/Payments transaction cannot be deleted as corresponding Expenditure Refunds transaction(s) exist.', 'Ok', '', CONST_openFunctionHideLoader);
            return false;
        }
        //When resultDelSchedF.toString().toUpperCase() != "TRUE" it means we can delete it so we need to determine the appropriate message.
        if (dataTransArray[29].toString() == "Reimbursement") { // Reimbursement Details
            alertMessageForOperation = "Deleting this transaction will also delete the reimbursement details added for this transaction. Are you sure you want to delete this transaction?";
        }
        else if (dataTransArray[29].toString() == "Credit Card Payment") { // Credit Card Itemization
            alertMessageForOperation = "Deleting this transaction will also delete the credit card itemization added for this transaction. Are you sure you want to delete this transaction?";
        }
        else if (dataTransArray[7].toString().toUpperCase() == "Y") { // Subcontractor
            alertMessageForOperation = "Deleting this transaction will also delete the subcontractor details added for this transaction. Are you sure you want to delete this transaction?";
        }
        else if (dataTransArray[6].toString().toUpperCase() == "Y") { // Liability
            alertMessageForOperation = "Deleting this transaction will also delete the outstanding liability of this transaction. Are you sure you want to delete this transaction?";
        } else {
            console.log("ApplicationCommonCode_EFS:appCommonEFS_DetermineDeleteForScheduleF Unsuported transaction values. [29] was '" + dataTransArray[29].toString() + "'. [7] was '" + dataTransArray[7].toString() + "'. [6] was '" + dataTransArray[6].toString() + "'!");
            alertMessageForOperation = "Are you sure you want to delete this transaction ?";
        }
    } catch (e) {
        console.error("ApplicationCommonCode_EFS:appCommonEFS_DetermineDeleteForScheduleF runtime exception error!");
        console.error(e);
    }
    return alertMessageForOperation;
}

/** Common code for invoking GetAllTransactionTypesData from _UC_GridCommonControl controller.
 * reloadAndRecalc { boolean } 
 * dataTableInstanceToReload { function } The referecne to the datatable we will reload in the success callback..
 * dataOverides { ajax data params } pass to overwrite data values when making ajax call.
 * doneFunction { function } A function to be called if the ajax call is completed.
 * @param {boolean} reloadAndRecalc (optional) reloads and recalculates the table. When we reload we will display the "divLoading" image until the ajax reload call is completed. This was created for ALM Defect 707 where users were intertacting with the table while the "Processing..." text was still visible.
 * @param {function} dataTableInstanceToReload (required) The referecne to the datatable we will reload in the success callback.
 * @param {ajax data param} dataOverides (required) Allow user to overwrite data values when making ajax call.
 * @param {function} doneFunction (optional) A function to be called if the ajax call is completed.
 */
function appCommonEFS_GetAllTransactionTypesDataCommon(reloadAndRecalc, dataTableInstanceToReload, dataOverides, doneFunction) {
    if (dataTableInstanceToReload && bUtilIsObject(dataOverides)) {
        try {
            var ajaxUrl = "/_UC_GridCommonControl/GetAllTransactionTypesData/";
            appCommonEFS_GenericCallForTransactionGrid(reloadAndRecalc, dataTableInstanceToReload, dataOverides, doneFunction, ajaxUrl);
        } catch (e) {
            console.error("ApplicationCommonCode_EFS:appCommonEFS_GetAllTransactionTypesDataCommon error!");
            console.error(e);
        }
    } else {
        console.error("ApplicationCommonCode_EFS:appCommonEFS_GetAllTransactionTypesDataCommon One of the parameters was invalid!");
    }
}
/** Common code for invoking GetIEWeeklyContributionTransactions from _UC_GridCommonNIIEWeeklyContribution controller.
 * dataTableInstanceToReload { function } The referecne to the datatable we will reload in the success callback..
 * dataOverides { ajax data params } pass to overwrite data values when making ajax call.
 * doneFunction { function } A function to be called if the ajax call is completed.
 * @param {boolean} reloadAndRecalc (optional) reloads and recalculates the table. When we reload we will display the "divLoading" image until the ajax reload call is completed. This was created for ALM Defect 707 where users were intertacting with the table while the "Processing..." text was still visible.
 * @param {function} dataTableInstanceToReload (required) The referecne to the datatable we will reload in the success callback.
 * @param {ajax data param} dataOverides (required) Allow user to overwrite data values when making ajax call.
 * @param {function} doneFunction (optional) A function to be called if the ajax call is completed.
 */
function appCommonEFS_GetIEWeeklyContributionTransactionsCommon(dataTableInstanceToReload, dataOverides, doneFunction) {
    if (dataTableInstanceToReload && bUtilIsObject(dataOverides)) {
        try {
            var ajaxUrl = "/_UC_GridCommonNIIEWeeklyContribution/GetIEWeeklyContributionTransactions/";
            appCommonEFS_GenericCallForTransactionGrid(false, dataTableInstanceToReload, dataOverides, doneFunction, ajaxUrl);
        } catch (e) {
            console.error("ApplicationCommonCode_EFS:appCommonEFS_GetIEWeeklyContributionTransactionsCommon error!");
            console.error(e);
        }
    } else {
        console.error("ApplicationCommonCode_EFS:appCommonEFS_GetIEWeeklyContributionTransactionsCommon One of the parameters was invalid!");
    }
}

/** Common code for invoking Get24HourNoticeTransactions from _UC_GridCommonNonItem24HourNotice controller.
 * reloadAndRecalc { boolean } 
 * dataTableInstanceToReload { function } The referecne to the datatable we will reload in the success callback..
 * dataOverides { ajax data params } pass to overwrite data values when making ajax call.
 * doneFunction { function } A function to be called if the ajax call is completed.
 * This was created for ALM Defect 707 where users were intertacting with the table while the "Processing..." text was still visible.
 * @param {function} dataTableInstanceToReload (required) The referecne to the datatable we will reload in the success callback.
 * @param {ajax data param} dataOverides (required) Allow user to overwrite data values when making ajax call.
 * @param {function} doneFunction (optional) A function to be called if the ajax call is completed.
 */
function appCommonEFS_GridCommonNonItem24HourNoticeCommon(dataTableInstanceToReload, dataOverides, doneFunction) {
    if (dataTableInstanceToReload && bUtilIsObject(dataOverides)) {
        try {
            var ajaxUrl = "/_UC_GridCommonNonItem24HourNotice/Get24HourNoticeTransactions/";
            appCommonEFS_GenericCallForTransactionGrid(false, dataTableInstanceToReload, dataOverides, doneFunction, ajaxUrl);
        } catch (e) {
            console.error("ApplicationCommonCode_EFS:appCommonEFS_GridCommonNonItem24HourNoticeCommon error!");
            console.error(e);
        }
    } else {
        console.error("ApplicationCommonCode_EFS:appCommonEFS_GridCommonNonItem24HourNoticeCommon One of the parameters was invalid!");
    }
}

/** Common code for invoking GetIE24HContributionTransactions from _UC_GridCommonNIIE24HContribution controller.
 * dataTableInstanceToReload { function } The referecne to the datatable we will reload in the success callback.
 * dataOverides { ajax data params } pass to overwrite data values when making ajax call.
 * doneFunction { function } A function to be called if the ajax call is completed.
 * @param {boolean} reloadAndRecalc (optional) reloads and recalculates the table. When we reload we will display the "divLoading" image until the ajax reload call is completed. This was created for ALM Defect 707 where users were intertacting with the table while the "Processing..." text was still visible.
 * @param {function} dataTableInstanceToReload (required) The referecne to the datatable we will reload in the success callback.
 * @param {ajax data param} dataOverides (required) Allow user to overwrite data values when making ajax call.
 * @param {function} doneFunction (optional) A function to be called if the ajax call is completed.
 */
function appCommonEFS_GetIE24HContributionTransactionsCommon(dataTableInstanceToReload, dataOverides, doneFunction) {
    if (dataTableInstanceToReload && bUtilIsObject(dataOverides)) {
        try {
            var ajaxUrl = "/_UC_GridCommonNIIE24HContribution/GetIE24HContributionTransactions/";
            appCommonEFS_GenericCallForTransactionGrid(false, dataTableInstanceToReload, dataOverides, doneFunction, ajaxUrl);
        } catch (e) {
            console.error("ApplicationCommonCode_EFS:appCommonEFS_GetIE24HContributionTransactionsCommon error!");
            console.error(e);
        }
    } else {
        console.error("ApplicationCommonCode_EFS:appCommonEFS_GetIE24HContributionTransactionsCommon One of the parameters was invalid!");
    }
}

/** Common code for invoking GetIE24HourExpenditureTransactions from _UC_GridCommonNIIEWeeklyExpenditure controller.
 * dataTableInstanceToReload { function } The referecne to the datatable we will reload in the success callback.
 * dataOverides { ajax data params } pass to overwrite data values when making ajax call.
 * doneFunction { function } A function to be called if the ajax call is completed.
 * @param {boolean} reloadAndRecalc (optional) reloads and recalculates the table. When we reload we will display the "divLoading" image until the ajax reload call is completed. This was created for ALM Defect 707 where users were intertacting with the table while the "Processing..." text was still visible.
 * @param {function} dataTableInstanceToReload (required) The referecne to the datatable we will reload in the success callback.
 * @param {ajax data param} dataOverides (required) Allow user to overwrite data values when making ajax call.
 * @param {function} doneFunction (optional) A function to be called if the ajax call is completed.
 */
function appCommonEFS_GetIE24HourExpenditureTransactions(dataTableInstanceToReload, dataOverides, doneFunction) {
    if (dataTableInstanceToReload && bUtilIsObject(dataOverides)) {
        try {
            var ajaxUrl = "/_UC_GridCommonNIIEWeeklyExpenditure/GetIE24HourExpenditureTransactions/";
            appCommonEFS_GenericCallForTransactionGrid(false, dataTableInstanceToReload, dataOverides, doneFunction, ajaxUrl);
        } catch (e) {
            console.error("ApplicationCommonCode_EFS:appCommonEFS_GetIE24HourExpenditureTransactions error!");
            console.error(e);
        }
    } else {
        console.error("ApplicationCommonCode_EFS:appCommonEFS_GetIE24HourExpenditureTransactions One of the parameters was invalid!");
    }
}

/** Common code for invoking appCommonEFS_MakeAjaxCallForDataTableGrid for ANY controller for ANY grid.
 * This was created for ALM Defect 707 where users were intertacting with the table while the "Processing..." text was still visible.
 * reloadAndRecalc { boolean } - Wil reload the table using DataTable' .ajax.reload() function which will re-execute any ajax calls used during initialization.
 * dataTableInstanceToReload { function } The referecne to the datatable we will reload in the success callback..
 * dataOverides { ajax data params } pass to overwrite data values when making ajax call.
 * doneFunction { function } A function to be called if the ajax call is completed.
 * @param {boolean} reloadAndRecalc (optional) reloads and recalculates the table. But remember it will execute the ajax and redraw the table again!
 * @param {function} dataTableInstanceToReload (required) The reference to the datatable we will reload in the success callback.
 * @param {ajax data param} dataOverides (required) Allow user to overwrite data values when making ajax call.
 * @param {function} doneFunction (optional) A function to be called if the ajax call is completed.
 * @param {function} ajaxUrl (required) The url to the controller method that provides for the table.
 */
function appCommonEFS_GenericCallForTransactionGrid(reloadAndRecalc, dataTableInstanceToReload, dataOverides, doneFunction, ajaxUrl) {
    if (dataTableInstanceToReload && bUtilIsObject(dataOverides)) {
        try {
            var ajaxParams = {
                "reloadAndRecalc": reloadAndRecalc,// Reloads and recalculates the table. When true it display the "divLoading" and tell the table to reload the data.
                "data": dataOverides, //Data values when making ajax call.
                "doneFunction": doneFunction,//Function to be called if the ajax call is completed.
                "ajaxUrl": ajaxUrl,//Url to make ajax call.
            }
            appCommonEFS_MakeAjaxCallForDataTableGrid(dataTableInstanceToReload, ajaxParams, true);
        } catch (e) {
            console.error("ApplicationCommonCode_EFS:appCommonEFS_GenericCallForTransactionGrid error!");
            console.error(e);
        }
    } else {
        console.error("ApplicationCommonCode_EFS:appCommonEFS_GenericCallForTransactionGrid One of the parameters was invalid!");
    }
}

/**
 * Feed it a string and it will determine what NonItemIE24HContributionSched cshtml file to redirect to.
 * It will also change the label headersfor $m("#lblHeader,#lblHeader1,#lblHeader2").text(labelHeader).
 * It will also set the sessionVariables for "ScheduleId" and "FilingTransIdEdit".
 * @param {string} scheduleIdValue a schedule number to match before redirect and to save into  "ScheduleId" session var.
 * @param {string} filingTransIdEditValue a Filing Trans Id to save into  "FilingTransIdEdit" session var.
 * @param {string} basePath the base path to redirect to.
 */
function appCommonEFS_RedirectEditIE24HContribution(scheduleIdValue, filingTransIdEditValue, basePath) {
    if (bUtilIsString(scheduleIdValue) && bUtilIsString(basePath)) {
        var suppoetedSchedulesValues = ["1", "2", "3", "4", "6", "9"];
        if (!suppoetedSchedulesValues.includes(scheduleIdValue)) {
            console.warn("ApplicationCommonCode_EFS:appCommonEFS_RedirectEditIE24HContribution unable to determine redirect!");
            return;//Quit function
        }
        try {
            //Put up the loader to prevent users from multi-clicking.
            $m("#divLoading").show();
            // Set the Session Variable for Edit DialogBox.
            sessionStorage.setItem("ScheduleId", scheduleIdValue);
            sessionStorage.setItem("FilingTransIdEdit", filingTransIdEditValue);
            sessionStorage.setItem("EditFlag", "True");
            var labelHeader = null;
            var redirectUrl = null;

            if (scheduleIdValue == "1") { // Monetary Contributions Received From Individual & Partnerships EDIT TRANSACTION;
                // Changes the Header Name.
                labelHeader = "Contributions - Candidate, Individual & Family";
                redirectUrl = "NonItemIE24HContributionSchedA/NonItemIE24HContributionSchedA/";
            }
            else if (scheduleIdValue == "2") { // Monetary Contributions Received From Corporate EDIT TRANSACTION
                // Changes the Header Name.
                labelHeader = "Monetary Contributions Received From Corporate";
                redirectUrl = "NonItemIE24HContributionSchedB/NonItemIE24HContributionSchedB/";
            }
            else if (scheduleIdValue == "3") { // Monetary Contributions Received From All Other EDIT TRANSACTION
                // Changes the Header Name.
                labelHeader = "Monetary Contributions Received From All Other";
                redirectUrl = "NonItemIE24HContributionSchedC/NonItemIE24HContributionSchedC/";
            }
            else if (scheduleIdValue == "4") { // In-Kind (Non-Monetary) Contributions Received EDIT TRANSACTION
                // Changes the Header Name.
                labelHeader = "Contributions - In Kind";
                redirectUrl = "NonItemIE24HContributionSchedD/NonItemIE24HContributionSchedD/";
            }
            else if (scheduleIdValue == "6") { // Expenditure Payments
                // Changes the Header Name.
                labelHeader = "Expenditure Payments";
                redirectUrl = "NonItemIE24HContributionSchedF/NonItemIE24HContributionSchedF/";
            }
            else if (scheduleIdValue == "9") { // Loans Received EDIT TRANSACTION
                // Changes the Header Name.
                labelHeader = "Loan Received";
                redirectUrl = "NonItemIE24HContributionSchedI/NonItemIE24HContributionSchedI/";
            }
            //Execute the redirect.
            if (redirectUrl != null) {
                //Set headers
                $m("#lblHeader,#lblHeader1,#lblHeader2").text(labelHeader);
                window.location.href = basePath + redirectUrl;
                return;//Quit function
            }
            //If we get this far we did not find the url.
            $m("#divLoading").hide();
            return;//Quit function
        } catch (e) {
            console.error("ApplicationCommonCode_EFS:appCommonEFS_RedirectEditIE24HContribution error!");
            console.error(e);
        }
    }
    console.error("ApplicationCommonCode_EFS:appCommonEFS_RedirectEditIE24HContribution One of the parameters was invalid!");
}
/**
 * Used to map common settings on different tables
 * @param {String} tableName
 */
function appCommonEFS_GetGridColumnSettings(tableName) {
    var settings = false;
    switch (tableName) {
        case "UC_GridCommonControl":
            settings = columnIndexes_UC_GridCommonControl;
            break;
        case "UC_GridCommonNIIEWeeklyContribution":
            settings = columnIndexes_UC_GridCommonNIIEWeeklyContribution;
            break;
        case "UC_GridCommonNIIE24HContribution":
            settings = columnIndexes_UC_GridCommonNIIE24HContribution;
            break;
        case "UC_GridCommonNIIEWeeklyExpenditure":
            settings = columnIndexes_UC_GridCommonNIIEWeeklyExpenditure;
            break;
        case "UC_GridCommonNonItem24HourNotice":
            settings = columnIndexes_GridCommonNonItem24HourNotice;
            break;
        case "":
        default:
            console.warn("ApplicationCommonCode_EFS:appCommonEFS_GetGridColumnSettings unsuported table name of '" + tableName + "'.");
            break;
    }
    return settings;
}

/**
 * Use to adjust visible columns.
 * For a given dataTableInstance it will:
 * a) Hide all the columns specified in indexesToStartHidden by adding the class 'never'.
 * b) Unhide all the columns specified in indexesToAlwaysKeepUnhidden by removing the class 'never'.
 * c) Go through columnNamesToUnhide array and unhide any columns matching the names found in columnNamesIndexMappings.
 * d) Reload the table.
 * @param {DataTables.Api DataTable} dataTableInstance - These can be provided via $m('#' + gridName).DataTable() which returns a DataTables API instance and should not to be confused with $m('#' + gridName).dataTable() which returns a jQuery Object.
  *@param {Object} - rulesObject see example.
    {
    "indexesToStartHidden" : [0, 3],
    "indexesToAlwaysKeepUnhidden" : [2, 4], //Will always unhide.
    "columnNamesToUnhide" : ["Foo", "Bar"],//String to match.
    "columnNamesIndexMappings" : [["Bar", 3], ["Hello", 5], ["World", 6]] //String in header, index to unhide
    }
 */
function appCommonEFS_HideTableColumn(dataTableInstance, rulesObject) {
    //hideIndexes, alwaysUnhide, columnNamesToUnhide, columnNamesIndexMappings
    var tableId = getDataTableInstanceID(dataTableInstance);
    if (!tableId || !bUtilIsArray(rulesObject.indexesToStartHidden)) {
        console.error("ApplicationCommonCode_EFS:HideTableColumn did not receive valid datatable instance or valid hide index array");
        return;
    }
    try {
        //Hide the column indexes we always want hidden.
        $m(dataTableInstance.columns(rulesObject.indexesToStartHidden).header()).addClass('never');

        //Unhide column indexes we always want unhidden.
        if (bUtilIsArray(rulesObject.indexesToAlwaysKeepUnhidden)) {
            $m(dataTableInstance.columns(rulesObject.indexesToAlwaysKeepUnhidden).header()).removeClass('never');
        }
        //Collect arrays
        var tempA = bUtilIsArray(rulesObject.columnNamesToUnhide) ? rulesObject.columnNamesToUnhide : false;
        var tempB = bUtilIsArray(rulesObject.columnNamesIndexMappings) ? rulesObject.columnNamesIndexMappings : false;
        //Try to find matching tempA[n] strings in tempB[n][0] then hide tempB[n][1].
        for (var a in tempA) {
            for (var b in tempB) {
                if (bUtilIsArray(tempB[b]) && tempB[b].length == 2 && tempA[a] == tempB[b][0]) {
                    $m(dataTableInstance.column(tempB[b][1]).header()).removeClass('never');
                }
            }
        }
        dataTableInstance.columns.adjust().draw(false);
        dataTableInstance.responsive.rebuild();
        dataTableInstance.columns.adjust().responsive.recalc();
    } catch (e) {
        console.error("ApplicationCommonCode_EFS:HideTableColumn error!");
        console.error(e);
    }

}

/**
 * Common code for invoking GetAllTransactionTypesData from controller.
 * @param {DataTables.Api DataTable} dataTableInstance - These can be provided via $m('#' + gridName).DataTable() which returns a DataTables API instance and should not to be confused with $m('#' + gridName).dataTable() which returns a jQuery Object.
  *@param {Object} - ajaxParams Object see example.
  *@param {boolean} - Trigger loading to happen.
 * Object like:
   {
       "reloadAndRecalc" : ,//reloadAndRecalc { boolean } Reloads and recalculates the table. When true it display the "divLoading" and tell the table to reload the data. This was created for ALM Defect 707 where users were intertacting with the table while the "Processing..." text was still visible.
       "data" : ,//data { ajax data params } Data values when making ajax call.
       "doneFunction" : ,//doneFunction { function } Function to be called if the ajax call is completed.
       "ajaxUrl" : ,//ajaxUrl { string } Url to make ajax call.
   }
 */
function appCommonEFS_MakeAjaxCallForDataTableGrid(dataTableInstance, ajaxParams, showHideLoading) {
    try {
        if (!dataTableInstance) {
            //We're done without a datatable instance.
            return false;
        }

        //Get the DataTable table id.
        var dataTableInstanceId = getDataTableInstanceID(dataTableInstance);
        var successFunction = typeof dataTableInstance === 'function' ? dataTableInstance : function () { console.warn("ApplicationCommonCode_EFS:appCommonEFS_MakeAjaxCallForDataTableGrid, DataTable instance or call back function was not provided!");} ;
        //Set up the ajax paramter data.
        var ajaxParamData = ajaxParams.data ? ajaxParams.data : {} ;

        //Set up the done and success functions.
        var doneFunction = bUtilIsFunction(ajaxParams.doneFunction) ? ajaxParams.doneFunction : function () { /*Provide an empty 'done' function.*/};

        //Evaluate more settings for show and hide.
        var showLoadingFunction = function () { /*Provide an empty 'show loading' function.*/ };
        var hideLoadingFunction = function () { /*Provide an empty 'hide loading' function.*/ };
        if (showHideLoading) {
            //Overwrite dummy functions.
            showLoadingFunction = function () {
                //Shows the spinner that exists in the project (partial _UC_Loding.cshtml) blocking the user from multi clicking.
                $m("#divLoading").show();
            }
            //Overwrite dummy functions.
            hideLoadingFunction = function () {
                //Hides the spinner that exists in the project (partial _UC_Loding.cshtml) blocking the user from multi clicking.
                $m("#divLoading").hide();
            }
        }
        //Evaluate roeload and recalc.
        var reloadAndRecalcFunction = function () { /*Provide an empty 'reload and recalc' function.*/ };
        if (ajaxParams.reloadAndRecalc) {
            reloadAndRecalcFunction = function () {
                if (dataTableInstanceId) {
                    //This will reload the table as it was initially defined.
                    $m("#" + dataTableInstanceId).DataTable().ajax.reload();
                    $m("#" + dataTableInstanceId).DataTable().responsive.recalc();
                }
            }
        }
        //Build the params.
        var params = {
            "url": ajaxParams.ajaxUrl,
            "data": ajaxParamData,
            "dataType": "json",
            "type": "POST",
            "error": function ( jqXHR, textStatus, errorThrown) {
                //Hide any loaders if we're displaying messages.
                ShowDialogBoxWithOpenFunction('EFS', CONST_errorMessage, 'Ok', '', CONST_openFunctionHideLoader);
            },
            "beforeSend": function (jqXHR, settings) {
                showLoadingFunction();
            },
            "complete": function (jqXHR, textStatus) {
                hideLoadingFunction();
                doneFunction();
                reloadAndRecalcFunction();
            },
            "success": function (data, textStatus, jqXHR) {
                if (!dataTableInstanceId) {
                    /**
                     * This is the call back function from:
                        $m('#someID').DataTable({
                            "fnRowCallback": (url, data, callback) {
                                appCommonEFS_MakeAjaxCallForDataTableGrid(
                                    callback,
                                    {
                                        "reloadAndRecalc": false,//If called from fnRowCallback.
                                        "data": {}, //Data values when making ajax call.
                                        "doneFunction": function(){//Or false.},//Function to be called if the ajax call is completed.
                                        "ajaxUrl": ajaxUrl,//Url to make ajax call.
                                    }, 
                                    true);
                            });.
                        });
                    */
                    successFunction(data);
                }
             }
        };
        /*
         * This ajax call execution won't refresh the table unless you externally call:
         *  $m('#someID').DataTable().ajax.reload();
         *  or
         *  $m('#someID').DataTable().ajax.reload(function(){ console.log("Function which executes after reload.") });
         */
        $m.ajax(params);

    } catch (e) {
        console.error("ApplicationCommonCode_EFS:appCommonEFS_MakeAjaxCallForDataTableGrid error!");
        if (showHideLoading) {
            $m("#divLoading").hide();
        }
        console.error(e);
    }
}
