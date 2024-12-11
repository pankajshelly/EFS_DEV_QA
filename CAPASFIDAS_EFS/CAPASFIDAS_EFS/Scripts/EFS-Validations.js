/**
 *  EFS-Validations.js
    Version key Major-Minor-Patch
 *  Version 1.0.1 - Last formal update 06/05/2023
 */
function GetValidDate() {
    if ($("#txtCurrentDate").val() != "") {

        if ($("#txtCurrentDate").val().toString() == "MM/DD/YYYY") {
            return "Date Received Required";
        }
        else {
            var currDate = $("#txtCurrentDate").val();

            var dtRegex = new RegExp(/\b\d{1,2}[\/-]\d{1,2}[\/-]\d{4}\b/);
            if (!dtRegex.test(currDate)) {
                return "Enter Valid Date Format (MM/DD/YYYY)";
            }
            else {
                var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
                var dtArray = currDate.match(rxDatePattern); // is format OK?

                if (dtArray == null) {
                    return "Enter Valid Date";
                }

                var now = new Date();
                var currentDate = new Date(currDate);

                //Checks for mm/dd/yyyy format.
                var dtMonth = dtArray[1];
                var dtDay = dtArray[3];
                var dtYear = dtArray[5];

                if (dtMonth < 1 || dtMonth > 12) {
                    return "Enter Valid Date";
                }
                else if (dtDay < 1 || dtDay > 31) {

                    return "Enter Valid Date";
                }
                else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31) {
                    return "Enter Valid Date";
                }
                else if (dtMonth == 2) {
                    var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
                    if (dtDay > 29 || (dtDay == 29 && !isleap)) {
                        return "Enter Valid Date";
                    }
                }
                else if (currentDate > now) {
                    return "Date should not be in the future";
                }
                else {
                    return "";
                }
            }
        }
    }
}

function GetValidDateFilter() {

    var results = "";

    if ($("#txtNewFilingDate").val() != "") {

        if ($("#txtNewFilingDate").val().toString() == "MM/DD/YYYY") {
            return results = "New Filing Date Required";
        }
        else {
            var currDate = $("#txtNewFilingDate").val();
            //var dateRegex = /^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-.\/])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$/;
            //var date_regex = /^(0[1-9]|1[0-2])\/(0[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$/;
            var dtRegex = new RegExp(/\b\d{1,2}[\/-]\d{1,2}[\/-]\d{4}\b/);
            if (!dtRegex.test(currDate)) {
                var txtBox = document.getElementById("txtNewFilingDate");
                //$("#txtNewFilingDate").val("");
                //txtBox.focus();
                //ShowDialogBox('EFS', 'Enter Valid Date Format (MM/DD/YYYY)', 'Ok', '', 'GoToAssetList', null);
                //alert('EFS - Enter Valid Date Format (MM/DD/YYYY)');
                return results = "Enter Valid Date Format (MM/DD/YYYY)";
            }
            else {
                var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
                var dtArray = currDate.match(rxDatePattern); // is format OK?

                if (dtArray == null) {
                    //return false;
                    //alert('Invalid Date.');
                    return results = "Enter Valid Date";
                }

                var now = new Date();
                var currentDate = new Date(currDate);

                //Checks for mm/dd/yyyy format.
                dtMonth = dtArray[1];
                dtDay = dtArray[3];
                dtYear = dtArray[5];

                if (dtMonth < 1 || dtMonth > 12) {
                    //return false;
                    //alert('Invalid Date.');
                    return results = "Enter Valid Date";
                }
                else if (dtDay < 1 || dtDay > 31) {
                    //return false;
                    //alert('Invalid Date.');
                    return results = "Enter Valid Date";
                }
                else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31) {
                    //return false;
                    //alert('Invalid Date.');
                    return results = "Enter Valid Date";
                }
                else if (dtMonth == 2) {
                    var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
                    if (dtDay > 29 || (dtDay == 29 && !isleap)) {
                        //return false;
                        //alert('Invalid Date.');
                        return results = "Enter Valid Date";
                    }
                }
                else if (currentDate > now) {
                    return results = "Date should not be in the future";
                }

                return results;
            }
        }
    }
}

function GetValidDate24HNotice() {

    var results = "";

    if ($("#txtCurrentDate24HNotice").val() != "") {

        if ($("#txtCurrentDate24HNotice").val().toString() == "MM/DD/YYYY") {
            return results = "Date Received Required";
        }
        else {
            var currDate = $("#txtCurrentDate24HNotice").val();
            //var dateRegex = /^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-.\/])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$/;
            //var date_regex = /^(0[1-9]|1[0-2])\/(0[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$/;
            var dtRegex = new RegExp(/\b\d{1,2}[\/-]\d{1,2}[\/-]\d{4}\b/);
            if (!dtRegex.test(currDate)) {
                var txtBox = document.getElementById("txtCurrentDate24HNotice");
                //$("#txtCurrentDate24HNotice").val("");
                //txtBox.focus();
                //ShowDialogBox('EFS', 'Enter Valid Date Format (MM/DD/YYYY)', 'Ok', '', 'GoToAssetList', null);
                //alert('EFS - Enter Valid Date Format (MM/DD/YYYY)');
                return results = "Enter Valid Date Format (MM/DD/YYYY)";
            }
            else {
                var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
                var dtArray = currDate.match(rxDatePattern); // is format OK?

                if (dtArray == null) {
                    //return false;
                    //alert('Invalid Date.');
                    return results = "Enter Valid Date";
                }

                var now = new Date();
                var currentDate = new Date(currDate);

                //Checks for mm/dd/yyyy format.
                dtMonth = dtArray[1];
                dtDay = dtArray[3];
                dtYear = dtArray[5];

                if (dtMonth < 1 || dtMonth > 12) {
                    //return false;
                    //alert('Invalid Date.');
                    return results = "Enter Valid Date";
                }
                else if (dtDay < 1 || dtDay > 31) {
                    //return false;
                    //alert('Invalid Date.');
                    return results = "Enter Valid Date";
                }
                else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31) {
                    //return false;
                    //alert('Invalid Date.');
                    return results = "Enter Valid Date";
                }
                else if (dtMonth == 2) {
                    var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
                    if (dtDay > 29 || (dtDay == 29 && !isleap)) {
                        //return false;
                        //alert('Invalid Date.');
                        return results = "Enter Valid Date";
                    }
                }
                else if (currentDate > now) {
                    return results = "Date should not be in the future";
                }

                return results;
            }
        }
    }
}

function GetValidDateIEWeekly() {
    var results = "";

    if ($("#txtCurrentDateIEWeeklyContr").val() != "") {

        if ($("#txtCurrentDateIEWeeklyContr").val().toString() == "MM/DD/YYYY") {
            return results = "Date Received Required";
        }
        else {
            var currDate = $("#txtCurrentDateIEWeeklyContr").val();
            //var dateRegex = /^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-.\/])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$/;
            //var date_regex = /^(0[1-9]|1[0-2])\/(0[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$/;
            var dtRegex = new RegExp(/\b\d{1,2}[\/-]\d{1,2}[\/-]\d{4}\b/);
            if (!dtRegex.test(currDate)) {
                var txtBox = document.getElementById("txtCurrentDateIEWeeklyContr");
                //$("#txtCurrentDateIEWeeklyContr").val("");
                //txtBox.focus();
                //ShowDialogBox('EFS', 'Enter Valid Date Format (MM/DD/YYYY)', 'Ok', '', 'GoToAssetList', null);
                //alert('EFS - Enter Valid Date Format (MM/DD/YYYY)');
                return results = "Enter Valid Date Format (MM/DD/YYYY)";
            }
            else {
                var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
                var dtArray = currDate.match(rxDatePattern); // is format OK?

                if (dtArray == null) {
                    //return false;
                    //alert('Invalid Date.');
                    return results = "Enter Valid Date";
                }

                var now = new Date();
                var currentDate = new Date(currDate);

                //Checks for mm/dd/yyyy format.
                dtMonth = dtArray[1];
                dtDay = dtArray[3];
                dtYear = dtArray[5];

                if (dtMonth < 1 || dtMonth > 12) {
                    //return false;
                    //alert('Invalid Date.');
                    return results = "Enter Valid Date";
                }
                else if (dtDay < 1 || dtDay > 31) {
                    //return false;
                    //alert('Invalid Date.');
                    return results = "Enter Valid Date";
                }
                else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31) {
                    //return false;
                    //alert('Invalid Date.');
                    return results = "Enter Valid Date";
                }
                else if (dtMonth == 2) {
                    var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
                    if (dtDay > 29 || (dtDay == 29 && !isleap)) {
                        //return false;
                        //alert('Invalid Date.');
                        return results = "Enter Valid Date";
                    }
                }
                else if (currentDate > now) {
                    return results = "Date should not be in the future";
                }

                return results;
            }
        }
    }
}

function GetValidDateIE24HExp() {
    var results = "";

    if ($("#txtCurrentDateIE24HourExp").val() != "") {

        if ($("#txtCurrentDateIE24HourExp").val().toString() == "MM/DD/YYYY") {
            return results = "Date Received Required";
        }
        else {
            var currDate = $("#txtCurrentDateIE24HourExp").val();
            //var dateRegex = /^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-.\/])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$/;
            //var date_regex = /^(0[1-9]|1[0-2])\/(0[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$/;
            var dtRegex = new RegExp(/\b\d{1,2}[\/-]\d{1,2}[\/-]\d{4}\b/);
            if (!dtRegex.test(currDate)) {
                var txtBox = document.getElementById("txtCurrentDateIE24HourExp");
                //$("#txtCurrentDateIE24HourExp").val("");
                //txtBox.focus();
                //ShowDialogBox('EFS', 'Enter Valid Date Format (MM/DD/YYYY)', 'Ok', '', 'GoToAssetList', null);
                //alert('EFS - Enter Valid Date Format (MM/DD/YYYY)');
                return results = "Enter Valid Date Format (MM/DD/YYYY)";
            }
            else {
                var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
                var dtArray = currDate.match(rxDatePattern); // is format OK?

                if (dtArray == null) {
                    //return false;
                    //alert('Invalid Date.');
                    return results = "Enter Valid Date";
                }

                var now = new Date();
                var currentDate = new Date(currDate);

                //Checks for mm/dd/yyyy format.
                dtMonth = dtArray[1];
                dtDay = dtArray[3];
                dtYear = dtArray[5];

                if (dtMonth < 1 || dtMonth > 12) {
                    //return false;
                    //alert('Invalid Date.');
                    return results = "Enter Valid Date";
                }
                else if (dtDay < 1 || dtDay > 31) {
                    //return false;
                    //alert('Invalid Date.');
                    return results = "Enter Valid Date";
                }
                else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31) {
                    //return false;
                    //alert('Invalid Date.');
                    return results = "Enter Valid Date";
                }
                else if (dtMonth == 2) {
                    var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
                    if (dtDay > 29 || (dtDay == 29 && !isleap)) {
                        //return false;
                        //alert('Invalid Date.');
                        return results = "Enter Valid Date";
                    }
                }
                else if (currentDate > now) {
                    return results = "Date should not be in the future";
                }

                return results;
            }
        }
    }
}

function GetValidDateIE24H() {
    var results = "";

    if ($("#txtCurrentDateIE24HContr").val() != "") {

        if ($("#txtCurrentDateIE24HContr").val().toString() == "MM/DD/YYYY") {
            return results = "Date Received Required";
        }
        else {
            var currDate = $("#txtCurrentDateIE24HContr").val();
            //var dateRegex = /^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-.\/])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$/;
            //var date_regex = /^(0[1-9]|1[0-2])\/(0[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$/;
            var dtRegex = new RegExp(/\b\d{1,2}[\/-]\d{1,2}[\/-]\d{4}\b/);
            if (!dtRegex.test(currDate)) {
                var txtBox = document.getElementById("txtCurrentDateIE24HContr");
                //$("#txtCurrentDateIE24HContr").val("");
                //txtBox.focus();
                //ShowDialogBox('EFS', 'Enter Valid Date Format (MM/DD/YYYY)', 'Ok', '', 'GoToAssetList', null);
                //alert('EFS - Enter Valid Date Format (MM/DD/YYYY)');
                return results = "Enter Valid Date Format (MM/DD/YYYY)";
            }
            else {
                var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
                var dtArray = currDate.match(rxDatePattern); // is format OK?

                if (dtArray == null) {
                    //return false;
                    //alert('Invalid Date.');
                    return results = "Enter Valid Date";
                }

                var now = new Date();
                var currentDate = new Date(currDate);

                //Checks for mm/dd/yyyy format.
                dtMonth = dtArray[1];
                dtDay = dtArray[3];
                dtYear = dtArray[5];

                if (dtMonth < 1 || dtMonth > 12) {
                    //return false;
                    //alert('Invalid Date.');
                    return results = "Enter Valid Date";
                }
                else if (dtDay < 1 || dtDay > 31) {
                    //return false;
                    //alert('Invalid Date.');
                    return results = "Enter Valid Date";
                }
                else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31) {
                    //return false;
                    //alert('Invalid Date.');
                    return results = "Enter Valid Date";
                }
                else if (dtMonth == 2) {
                    var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
                    if (dtDay > 29 || (dtDay == 29 && !isleap)) {
                        //return false;
                        //alert('Invalid Date.');
                        return results = "Enter Valid Date";
                    }
                }
                else if (currentDate > now) {
                    return results = "Date should not be in the future";
                }

                return results;
            }
        }
    }
}

function GetValidDateForCommon(txtCurrentDate, message) {

    var results = "";

    if ($("#" + txtCurrentDate).val() != "") {

        if ($("#" + txtCurrentDate).val().toString() == "MM/DD/YYYY") {
            return results = "Date " + message + " Required";
        }
        else {
            var currDate = $("#" + txtCurrentDate).val();
            var dtRegex = new RegExp(/\b\d{1,2}[\/-]\d{1,2}[\/-]\d{4}\b/);
            if (!dtRegex.test(currDate)) {
                var txtBox = document.getElementById(txtCurrentDate);
                return results = "Enter Valid Date Format (MM/DD/YYYY)";
            }
            else {
                var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
                var dtArray = currDate.match(rxDatePattern);

                if (dtArray == null) {
                    return results = "Enter Valid Date";
                }

                var now = new Date();
                var currentDate = new Date(currDate);

                //Checks for mm/dd/yyyy format.
                dtMonth = dtArray[1];
                dtDay = dtArray[3];
                dtYear = dtArray[5];

                if (dtMonth < 1 || dtMonth > 12) {
                    return results = "Enter Valid Date";
                }
                else if (dtDay < 1 || dtDay > 31) {
                    return results = "Enter Valid Date";
                }
                else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31) {
                    return results = "Enter Valid Date";
                }
                else if (dtMonth == 2) {
                    var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
                    if (dtDay > 29 || (dtDay == 29 && !isleap)) {
                        return results = "Enter Valid Date";
                    }
                }
                else if (currentDate > now) {
                    return results = "Date should not be in the future";
                }
                return results;
            }
        }
    }
}

function GetValidDateSchedF() {

    var results = "";

    if ($("#txtCurrentDateSchedF").val() != "") {

        if ($("#txtCurrentDateSchedF").val().toString() == "MM/DD/YYYY") {
            return results = "Date Paid Required";
        }
        else {
            var currDate = $("#txtCurrentDateSchedF").val();
            //var dateRegex = /^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-.\/])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$/;
            //var date_regex = /^(0[1-9]|1[0-2])\/(0[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$/;
            var dtRegex = new RegExp(/\b\d{1,2}[\/-]\d{1,2}[\/-]\d{4}\b/);
            if (!dtRegex.test(currDate)) {
                var txtBox = document.getElementById("txtCurrentDateSchedF");
                //$("#txtCurrentDate").val("");
                //txtBox.focus();
                //ShowDialogBox('EFS', 'Enter Valid Date Format (MM/DD/YYYY)', 'Ok', '', 'GoToAssetList', null);
                //alert('EFS - Enter Valid Date Format (MM/DD/YYYY)');
                return results = "Enter Valid Date Format (MM/DD/YYYY)";
            }
            else {
                var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
                var dtArray = currDate.match(rxDatePattern); // is format OK?

                if (dtArray == null) {
                    //return false;
                    //alert('Invalid Date.');
                    return results = "Enter Valid Date";
                }

                var now = new Date();
                var currentDate = new Date(currDate);

                //Checks for mm/dd/yyyy format.
                dtMonth = dtArray[1];
                dtDay = dtArray[3];
                dtYear = dtArray[5];

                if (dtMonth < 1 || dtMonth > 12) {
                    //return false;
                    //alert('Invalid Date.');
                    return results = "Enter Valid Date";
                }
                else if (dtDay < 1 || dtDay > 31) {
                    //return false;
                    //alert('Invalid Date.');
                    return results = "Enter Valid Date";
                }
                else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31) {
                    //return false;
                    //alert('Invalid Date.');
                    return results = "Enter Valid Date";
                }
                else if (dtMonth == 2) {
                    var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
                    if (dtDay > 29 || (dtDay == 29 && !isleap)) {
                        //return false;
                        //alert('Invalid Date.');
                        return results = "Enter Valid Date";
                    }
                }
                else if (currentDate > now) {
                    return results = "Date should not be in the future";
                }

                return results;
            }
        }
    }
}

function GetValidDateReimDetSchedF() {

    var results = "";

    if ($("#txtCurrentDateReimDetSchedF").val() != "") {

        if ($("#txtCurrentDateReimDetSchedF").val().toString() == "MM/DD/YYYY") {
            return results = "Date Paid Required";
        }
        else {
            var currDate = $("#txtCurrentDateReimDetSchedF").val();
            //var dateRegex = /^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-.\/])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$/;
            //var date_regex = /^(0[1-9]|1[0-2])\/(0[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$/;
            var dtRegex = new RegExp(/\b\d{1,2}[\/-]\d{1,2}[\/-]\d{4}\b/);
            if (!dtRegex.test(currDate)) {
                var txtBox = document.getElementById("txtCurrentDateReimDetSchedF");
                //$("#txtCurrentDate").val("");
                //txtBox.focus();
                //ShowDialogBox('EFS', 'Enter Valid Date Format (MM/DD/YYYY)', 'Ok', '', 'GoToAssetList', null);
                //alert('EFS - Enter Valid Date Format (MM/DD/YYYY)');
                return results = "Enter Valid Date Format (MM/DD/YYYY)";
            }
            else {
                var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
                var dtArray = currDate.match(rxDatePattern); // is format OK?

                if (dtArray == null) {
                    //return false;
                    //alert('Invalid Date.');
                    return results = "Enter Valid Date";
                }

                var now = new Date();
                var currentDate = new Date(currDate);

                //Checks for mm/dd/yyyy format.
                dtMonth = dtArray[1];
                dtDay = dtArray[3];
                dtYear = dtArray[5];

                if (dtMonth < 1 || dtMonth > 12) {
                    //return false;
                    //alert('Invalid Date.');
                    return results = "Enter Valid Date";
                }
                else if (dtDay < 1 || dtDay > 31) {
                    //return false;
                    //alert('Invalid Date.');
                    return results = "Enter Valid Date";
                }
                else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31) {
                    //return false;
                    //alert('Invalid Date.');
                    return results = "Enter Valid Date";
                }
                else if (dtMonth == 2) {
                    var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
                    if (dtDay > 29 || (dtDay == 29 && !isleap)) {
                        //return false;
                        //alert('Invalid Date.');
                        return results = "Enter Valid Date";
                    }
                }
                else if (currentDate > now) {
                    return results = "Date should not be in the future";
                }

                return results;
            }
        }
    }
}

function GetValidName(Val) {
    //
    if (Val.toString() != "") {

        var results = "";

        var currName = Val.toString();

        var dtRegex = new RegExp(/^[a-zA-Z .']+$/);

        if (!dtRegex.test(currName)) {
            return results = "Enter Valid Name";
        }
        else {
            return results;
        }
    }
}

function ValidateAlphabet(Val) {

    //
    if (Val.toString() != "") {

        var results = "";

        var currName = Val.toString();

        var dtRegex = new RegExp(/^[a-zA-Z]*$/);

        if (!dtRegex.test(currName)) {
            return results = "Enter Valid Name";
        }
        else {
            return results;
        }
    }
}

function ValidateAlphabetSpecialChar(Val) {

    //
    if (Val.toString() != "") {

        var results = "";

        var currName = Val.toString();

        var dtRegex = new RegExp(/^[a-zA-Z #'.,-]*$/);

        if (!dtRegex.test(currName)) {
            return results = "Enter Valid Name";
        }
        else {
            return results;
        }
    }
}

function ValidateAlphaNumeric(Val) {
    //
    if (Val.toString() != "") {

        var results = "";

        var currName = Val.toString();

        var dtRegex = new RegExp(/^[a-zA-Z0-9 ]*$/);

        if (!dtRegex.test(currName)) {
            return results = "Enter Valid Address";
        }
        else {
            return results;
        }
    }
}

function ValidateAlphaNumericAddress(Val) {
    //
    if (Val.toString() != "") {

        var results = "";

        var currName = Val.toString();

        var dtRegex = new RegExp(/^[a-zA-Z0-9 #'.,-]*$/);

        if (!dtRegex.test(currName)) {
            return results = "Enter Valid Address";
        }
        else {
            return results;
        }
    }
}

function ValidateNumericZip(Val) {
    //
    if (Val.toString() != "") {

        var results = "";

        var currName = Val.toString();

        var dtRegex = new RegExp(/^[0-9]+$/);

        if (!dtRegex.test(currName)) {
            return results = "Enter Valid Zip";
        }
        else {
            return results;
        }
    }
}

function ValidateNumericZipCode(Val) {
    //
    if (Val.toString() != "") {

        var results = "";

        var currName = Val.toString();

        var strLength = Val.length;

        if (strLength <= 5) {
            var dtRegex = new RegExp(/^[0-9]+$/);
            if (!dtRegex.test(currName)) {
                return results = "Enter Valid Zip";
            }
            else {
                return results;
            }
        }
        else {
            var dtRegex = new RegExp(/^\d{5}$|^\d{5}-$|^\d{5}-\d{4}$/);

            if (!dtRegex.test(currName)) {
                return results = "Enter Valid Zip";
            }
            else {
                return results;
            }
        }
    }
}

function ValidateNumericAmount(Val) {
    //
    if (Val.toString() != "") {

        var results = "";

        var currName = Val.toString();

        var dtRegex = new RegExp(/^(\d+)?([.]?\d{0,2})?$/);

        if (!dtRegex.test(currName)) {
            return results = "Enter Valid Amount";
        }
        else {
            return results;
        }
    }
}

// DATE Validation
function ValidateDateControl(FormID) {

    var varFormId = '#' + FormID.toString();

    $m(varFormId).validate({ // initialize the plugin
        rules: {
            txtCurrentDate: {
                required: true,
                //dateUS: true,
                //ValCutOffDate: true
            },
            txtStreetName: {
                ValidateAlphaNumericAddress: true,
                minlength: 4
            },
            txtCity: {
                ValidateAlphaSpecial: true
            },
            txtState: {
                ValidateAlphaSpecial: true
            },
            txtCountry: {
                required: function () {
                    return $('#chkCountry').is(':checked')
                },
                AlphabetsVal: function () {
                    return $('#chkCountry').is(':checked')
                }
            },
            txtZipCode: {
                FomatZipcode: {
                    depends: function () {
                        return $('#chkCountry').is(':checked') == false
                    }
                },
                OtherCountryZipVal: function () {
                    return $('#chkCountry').is(':checked') == true
                }
            }
        },
        errorPlacement: function (error, element) {
            var trigger = element.next('.ui-datepicker-trigger');
            error.insertBefore(trigger.length > 0 ? trigger : element);
        },
        messages: {
            txtCurrentDate: {
                required: "Error: Date Received is required",
                //dateUS: "Enter valid date format (MM/DD/YYYY)",
                //ValCutOffDate: "Date Received cannot be later than Cut Off Date"
            },
            txtStreetName: {
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters ‘# -., are allowed",
                minlength: "Error: Street Address must contain at least four characters"
            },
            txtStreetNameShedF: {
                required: "Error: Street Address is required",
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters ‘# -., are allowed",
                minlength: "Error: Street Address must contain at least four characters"
            },
            txtCity: {
                ValidateAlphaSpecial: "Error: Letters and characters ‘# -., are allowed"
            },
            txtState: {
                ValidateAlphaSpecial: "Error: Letters and characters ‘# -., are allowed"
            },
            txtCountry: {
                required: "Error: Country is required",
                AlphabetsVal: "Error: Letters are allowed"
            },
            txtCountryShedF: {
                required: "Error: Country is required",
                AlphabetsVal: "Error: Letters are allowed"
            },
            txtZipCode: {
                FomatZipcode: "Error: Numbers and - are allowed",
                OtherCountryZipVal: "Error: Letters, numbers and - are allowed"
            }
        },
        errorPlacement: function (error, element) {
            $(error).insertBefore(element);
        }
    });

    // DATE VALIDATION
    $m.validator.addMethod("dateUS", function (value, element) {
        var errormsg = "";
        var re = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
        if (re.test(value)) {
            var adata = value.split('/');
            var mm = parseInt(adata[0], 10);
            var dd = parseInt(adata[1], 10);
            var yyyy = parseInt(adata[2], 10);
            var xdata = new Date(yyyy, mm - 1, dd);
            if ((xdata.getFullYear() == yyyy) && (xdata.getMonth() == mm - 1) && (xdata.getDate() == dd))
                check = true;
            else {
                //check = false; Modified.
                check = false;
                errormsg = "Leap year date";
            }
        } else
            check = false;
        return this.optional(element) || check;
    }, "Invalid Date");

}


function ValidateAddress(valid) {

    // Street Address Validate.
    if ($("#txtStreetName").val() != "") {
        var resultsName = ValidateAlphaNumericAddress($("#txtStreetName").val().toString());
        if (resultsName != "") {
            $("#divErrorStreetName").show();
            $("#lblErrorStreetName").text("Enter Valid Street Name");
            $("#txtStreetName").addClass("ui-state-error");
            valid = false;
        }
    }

    // Street Address Validate.
    if ($("#txtStreetNameShedF").val() != "") {
        var resultsName = ValidateAlphaNumericAddress($("#txtStreetNameShedF").val().toString());
        if (resultsName != "") {
            $("#divErrorStreetName").show();
            $("#lblErrorStreetName").text("Enter Valid Street Name");
            $("#txtStreetNameShedF").addClass("ui-state-error");
            valid = false;
        }
    }

    // City Validate.
    if ($("#txtCity").val() != "") {
        var resultsName = GetValidName($("#txtCity").val().toString());
        if (resultsName != "") {
            $("#divErrorCity").show();
            $("#lblErrorCity").text("Enter Valid City");
            $("#txtCity").addClass("ui-state-error");

            valid = false;
        }
    }

    // State Validate.
    if ($("#txtState").val() != "") {
        var resultsName = GetValidName($("#txtState").val().toString());
        if (resultsName != "") {
            $("#divErrorState").show();
            $("#lblErrorState").text("Enter Valid State");
            $("#txtState").addClass("ui-state-error");
            valid = false;
        }
    }

    // State Zip5.
    if ($("#txtZipCode").val() != "") {
        var resultsName = ValidateNumericZip($("#txtZipCode").val().toString());
        if (resultsName != "") {
            $("#divErrorZip5").show();
            $("#lblErrorZip5").text("Enter Valid Zip5");
            $("#txtZip5").addClass("ui-state-error");
            valid = false;
        }
    }
    return valid;
}

function validatePage(pageName) {
    $m("#" + pageName).validate({
        rules: {
            lstContributionName: {
                ContributorCodeVal: true
            },
            lstSuppOrOpps: {
                lstSuppOrOppsVal: true
            },
            lstContributionNameSchedD: {
                ContributorCodeValSchedDNonItem: true
            },
            lstContributionNameInKind: {
                ContributorCodeValSchedD: true
            },
            lstContributionTypeInKind: {
                ContributionTypeValSchedD: true
            },
            lstContributionTypeNonItemD: {
                ContributionTypeValNonItemD: true
            },
            lstTransferType: {
                lstTransferTypeVal: true
            },
            lstOffice: {
                lstOfficeVal: true
            },
            lstDistrict: {
                lstDistrictVal: true
            },
            lstElectionCycleAllocated: {
                lstElectionCycleAllocatedVal: true
            },
            lstExpPaymentName: {
                ExpPaymentNameVal: true
            },
            lstExpPaymentAmount: {
                ExpPaymentAmountVal: true
            },
            lstExpPaymentDate: {
                ExpPaymentDateVal: true
            },
            lstContributorName: {
                ContributionNameVal: true
            },
            lstContributorAmount: {
                ContributionAmountVal: true
            },
            lstContributorDate: {
                ContributorDateVal: true
            },
            lstReceiptCode: {
                RecieptCodeVal: true
            },
            lstPurposeCode: {
                PurposeCodeVal: true
            },
            lstDateIncurred: {
                DateIncurredVal: function () {
                    return $("#lstLiabilityExists option:selected").val().toString() == "Y";
                }
            },
            txtCurrentDate: {
                required: true,
                dateUS: true,
                ValCutOffDate: true
            },
            txtCurrentDateWCS: {
                required: true,
                dateUS: true,
                CutOffDateWCFVal: true
            },
            txtCurrentDateTransferred: {
                required: true,
                dateUS: true,
                ValCutOffDateTransferred: true
            },
            txtCurrentDateSchedN: {
                required: true,
                dateUS: true,
                ValCutOffDateSchedN: true
            },
            //txtCurrentDateAllocatedSchedR: {
            //    required: true,
            //    dateUS: true,
            //    ValCutOffDateSchedR: true
            //},
            txtCurrentDateLoanReceived: {
                required: true,
                dateUS: true,
                ValCutOffDateLoanReceived: true
            },
            txtCurrentDateLoanRepay: {
                required: true,
                dateUS: true,
                ValCutOffDateLoanRepay: true
            },
            txtCurrentDateLoanForgiven: {
                required: true,
                dateUS: true,
                ValCutOffDateLoanForgiven: true
            },
            txtCurrentDateShedF: {
                required: true,
                dateUS: true,
                ValCutOffDateLoanRepayScheF: true
            },
            txtCurrentDateSchedL: {
                required: true,
                dateUS: true,
                ValCutOffDateSchedL: true
            },
            txtCurrentDateSchedQ: {
                required: true,
                dateUS: true,
                ValCutOffDateSchedQ: true
            },
            txtCurrentDate24HNotice: {
                required: true,
                dateUS: true,
                ValCutOffDateSchedA24HNotice: true
            },
            txtCurrentDateIEWeeklyContr: {
                required: true,
                dateUS: true,
                ValDateRecSchedAIEWeeklyContr: true
            },
            txtCurrentDateIE24HourExp: {
                required: true,
                dateUS: true,
                ValDateRecSchedFIE24HourExp: true
            },
            txtCurrentDateIE24HContr: {
                required: true,
                dateUS: true,
                ValDateRecSchedAIE24HContr: true
            },
            txtCurrentDateReceived: {
                required: true,
                dateUS: true,
                CutCurrentDateVal: true
            },
            txtDateRefundPaid: {
                required: true,
                dateUS: true,
                DateRefundCurrentDateVal: true
            },
            txtFirstName: { // come here
                required: true,
                NameOnlyValidate: true
            },
            txtMI: {
                NameOnlyValidate: true
            },
            txtLastName: {
                required: true,
                NameOnlyValidate: true
            },
            txtPartnerShipName: {
                required: true,
                EntityNameValidate: true
            },
            txtPartnerShipNameSchedDIN: {
                required: function () {
                    if ($("#lstContributionNameInKind option:selected").val() != null) {
                        if ($("#lstContributionNameInKind option:selected").val() != "") {
                            //lstContributionNameInKind =="4" we want to return false.
                            return $("#lstContributionNameInKind option:selected").val().toString() != "4";
                        }

                    }
                    else if ($("#lstContributionNameSchedD option:selected").val() != null) {
                        if ($("#lstContributionNameSchedD option:selected").val() != "") {
                            //lstContributionNameSchedD =="4" we want to return false.
                            return $("#lstContributionNameSchedD option:selected").val().toString() != "4";
                        }
                    }
                    else {
                        return true;
                    }
                },
                EntityNameValidate: true
            },
            txtTransferorName: {
                required: true,
                EntityNameValidate: true
            },
            txtCreditorName: {
                required: true,
                EntityNameValidate: true
            },
            txtTransfereeName: {
                required: true,
                EntityNameValidate: true
            },
            txtReceiptSource: {
                required: true,
                EntityNameValidate: true
            },
            txtPayorName: {
                required: true,
                EntityNameValidate: true
            },
            txtPayeeNameShedF: {
                required: true,
                EntityNameValidate: true
            },
            txtContributorName: {
                required: true,
                EntityNameValidate: true
            },
            txtPayeeName: {
                required: true,
                EntityNameValidate: true
            },
            txtTreasurerOccupation: {
                required: true,
                NameValidate: true
            },
            txtContributorOccupation: {
                required: true,
                NameValidate: true
            },
            txtTreasurerEmployer: {
                required: true,
                NameValidate: true
            },
            txtContributorEmployer: {
                required: true,
                NameValidate: true
            },
            txtIndependentExpenditureDescription: {
                required: true,
                NameValidate: true
            },
            txtCandidateNameBPReference: {
                required: true,
                NameValidate: true
            },
            txtStreetName: {
                required: true,
                ValidateAlphaNumericAddress: true,
                minlength: 4
            },
            txtStreetNameShedF: {
                required: true,
                ValidateAlphaNumericAddress: true,
                minlength: 4
            },
            txtStreetNameTreasurer: {
                required: true,
                ValidateAlphaNumericAddress: true,
                minlength: 4
            },
            txtCity: {
                required: true,
                ValidateAlphaSpecial: true,
                AlphaSpecialNumOtherCntry: true
            },
            txtCityShedF: {
                required: true,
                ValidateAlphaSpecial: true,
                AlphaSpecialNumOtherCntry: true
            },
            txtCityTreasurer: {
                required: true,
                ValidateAlphaSpecialTreasurerCity: true,
            },
            txtState: {
                required: true,
                AlphaSpecialStateOtherCntry: true,
                AlphabetsValState: true,
                State2LettersVal: true
            },
            txtStateShedF: {
                required: true,
                AlphaSpecialStateOtherCntry: true,
                AlphabetsValState: true,
                State2LettersVal: true
            },
            txtStateTreasurer: {
                required: true,
                ValidateAlphaTreasurerState: true
            },
            txtCountry: {
                required: function () {
                    return $('#chkCountry').is(':checked')
                },
                AlphabetsVal: function () {
                    return $('#chkCountry').is(':checked')
                }
            },
            txtCountryShedF: {
                required: function () {
                    return $('#chkCountryShedF').is(':checked')
                },
                AlphabetsVal: function () {
                    return $('#chkCountryShedF').is(':checked')
                }
            },
            txtZipCode: {
                required: true,
                FomatZipcode: true,
                OtherCountryZipVal: true
            },
            txtZipCodeShedF: {
                required: true,
                FomatZipcodeSchedF: true,
                OtherCountryZipVal: true
            },
            txtZipCodeTreasurer: {
                required: true,
                FomatZipcodeTreasurer: true
            },
            txtCheck: {
                required: function () {
                    return ($("#lstMethod option:selected").val().toString() == "1" || $("#lstMethod option:selected").val().toString() == "8");
                },
                AlphaNumeric: function () {
                    return ($("#lstMethod option:selected").val().toString() == "1" || $("#lstMethod option:selected").val().toString() == "8");
                }
            },
            txtCheckExpenditurePayments: {
                required: function () {
                    return $("#lstMethod option:selected").val().toString() == "1";
                },
                AlphaNumeric: function () {
                    return $("#lstMethod option:selected").val().toString() == "1";
                }
            },
            txtAmt: {
                required: true,
                number: true,
                AmountValidate: true,
                Amount12DigitVal: true,
                AmountZeroValtxtAmt: true
            },
            txtAmtABC: {
                required: true,
                number: true,
                AmountValidate: true,
                Amount12DigitValABC: true,
                AmountZeroValSchedABC: true
            },
            txtAmtSchedD: {
                required: true,
                number: true,
                AmountValidate: true,
                Amount12DigitValD: true,
                AmountValZeroSchedD: true
            },
            txtAmtSchedE: {
                required: true,
                number: true,
                AmountValidate: true,
                Amount12DigitValSchedE: true,
                AmountValZeroSchedE: true
            },
            txtAmtSchedN: {
                required: true,
                number: true,
                AmountValidate: true,
                Amount12DigitValN: true,
                AmountValZeroSchedN: true
            },
            txtAmtSchedP: {
                required: true,
                number: true,
                AmountValidate: true,
                Amount12DigitValP: true,
                AmountValZeroSchedP: true
            },
            txtAmtSchedQ: {
                required: true,
                number: true,
                AmountValidate: true,
                Amount12DigitValQ: true,
                AmountValZeroSchedQ: true
            },
            txtAmountRefunded: {
                required: true,
                number: true,
                AmountValidate: true,
                Amount12DigitValSchedL: true,
                AmountZeroValSchedL: true
            },
            txtOriginalAmount: {
                required: true,
                number: true,
                AmountValidate: true,
                Amount12DigitValSchedF: true,
                AmountZeroValSchedF: true
            },
            txtAmtExpenditurePayments: {
                required: true,
                number: true,
                AmountValidate: true,
                Amount12DigitValSchedFAmt: true,
                AmountZeroValSchedFAmt: true
            },
            txtAmt24HNotice: {
                required: true,
                number: true,
                AmountValidate: true,
                Amount12DigitValSchedA24HNotice: true,
                AmountZeroValSchedA24HNotice: true,
                Amount24HNoticeValidate: true
            },
            txtAmtIEWeeklyContr: {
                required: true,
                number: true,
                AmountValidate: true,
                Amount12DigitValSchedAIEWContr: true,
                AmountZeroValSchedAIEWContr: true,
                AmountIEWContrValidate: true
            },
            txtAmtIEWeeklyExpenditure: {
                required: true,
                number: true,
                AmountValidate: true,
                Amount12DigitValSchedFIEWExp: true,
                AmountZeroValSchedFIEWExp: true,
                AmountIEWExpValidate: true
            },
            txtAmtIEWeeklyPIDAExpenditure: {
                required: true,
                number: true,
                AmountValidate: true,
                Amount12DigitValSchedFIEWExpPIDA: true,
                AmountZeroValSchedFIEWExpPIDA: true,
                AmountIEWExpPIDAValidate: true
            },
            txtAmtIE24HrPIDAExpenditure: {
                required: true,
                number: true,
                AmountValidate: true,
                Amount12DigitValSchedFIE24HrPIDA: true,
                AmountZeroValSchedFIE24HrPIDA: true,
                AmountIE24HrPIDAValidate: true
            },
            txtOriginalAmountShedF: {
                required: true,
                number: true,
                AmountValidate: true,
                AmountOriginalSchedKFVal: true,
                AmountOriginalShedKFVal: true
            },
            txtAmtExpensesAllocation: {
                required: true,
                number: true,
                AmountValidateForSchedR: true,
                Amount12DigitValSchedR: true,
                AmountZeroValtxtAmtSchedR: true
            },
            txtExplanation: {
                required: function () {
                    if ($("#lstMethod option:selected").val().toString() == "7") {
                        return true;
                    }
                    else if ($("#lstContributionName option:selected").val() != null) {
                        return $("#lstContributionName option:selected").val().toString() == "14";
                    }
                    else if ($("#lblExplanation").text().toString() == "* Explanation") {
                        return true;
                    }
                    else {
                        return false;
                    }
                },
                ValidateAlphaNumericAddress: true
            },
            txtExplanationCommonShedF: {
                required: function () {
                    return $("#lstMethodShedF option:selected").val().toString() == "7";
                },
                ValidateAlphaNumericAddress: true
            },
            txtExplanationCommon: {
                required: function () {
                    if ($("#lstMethod option:selected").val().toString() == "7") {
                        return true;
                    }
                    else if ($("#lstPurposeCode option:selected").val() != null) {
                        return $("#lstPurposeCode option:selected").val().toString() == "8";
                    }
                    else if ($("#lstLoanerCode option:selected").val() != null) {
                        return $("#lstLoanerCode option:selected").val().toString() == "13";
                    }
                    else {
                        return false;
                    }
                },
                ValidateAlphaNumericAddress: true
            },
            txtExplanationCommonScheR: {
                ValidateAlphaNumericAddress: true
            },
            txtExplanationInKind: {
                required: true,
                ValidateAlphaNumericAddress: true
            },
            txtExplanationSchedE: {
                required: function () {
                    if ($("#lstMethod option:selected").val().toString() == "7") {
                        return true;
                    }
                    else if ($("#lstReceiptType option:selected").val().toString() == "3") {
                        return true;
                    }
                    else {
                        return false;
                    }
                },
                ValidateAlphaNumericAddress: true
            },
            txtLenderFirstName: {
                required: true,
                NameOnlyValidate: true
            },
            txtLenderMIName: {
                NameOnlyValidate: true
            },
            txtLenderLastName: {
                required: true,
                NameOnlyValidate: true
            },
            txtLenderName: {
                required: true,
                EntityNameValidate: true
            },
            lstLoanerCode: {
                lstLoanerCodeVal: true
            },
            lstReceiptType: {
                lstReceiptTypeValid: true
            },
            lstContributionType: {
                required: function () {
                    return $("#lblContributionType").text().toString() == "* Contribution Type";
                }
            },
            txtExplanationSchedP: {
                required: function () {
                    if ($("#lstMethod option:selected").val().toString() == "7") {
                        return true;
                    }
                    else if ($("#lstReceiptCode option:selected").val().toString() == "9") {
                        return true;
                    }
                    else {
                        return false;
                    }
                },
                ValidateAlphaNumericAddress: true
            },
            txtDescription: {
                required: true,
                ValidateAlphaNumericAddress: true
            },
            txtFileUpload: {
                required: true
            },
            lstSearchName: {
                lstSearchNameVal: true
            },
            lstSearchAmount: {
                lstSearchAmountVal: true
            },
            lstSearchDate: {
                lstSearchDateVal: true
            },
            lstLiabilityLoans: {
                lstLiabilityLoansVal: true
            },
            txtExplanationSchedQ: {
                required: function () {
                    if ($("#lstMethod option:selected").val().toString() == "7") {
                        return true;
                    }
                    else if ($("#lstPurposeCode option:selected").val().toString() == "8") {
                        return true;
                    }
                    else {
                        return false;
                    }
                },
                ValidateAlphaNumericAddress: true
            },
            txtExplanationSchedF: {
                required: function () {
                    if ($("#lstMethod option:selected").val().toString() == "7") {
                        return true;
                    }
                    else if ($("#lstPurposeCode option:selected").val().toString() == "8") {
                        return true;
                    }
                    else {
                        return false;
                    }
                },
                ValidateAlphaNumericAddress: true
            },
            txtExplanationSchedFIE24: {
                required: function () {
                    if ($("#lstMethodIE24HExpPayF option:selected").val().toString() == "7") {
                        return true;
                    }
                    else if ($("#lstPurposeCode option:selected").val().toString() == "8") {
                        return true;
                    }
                    else {
                        return false;
                    }
                },
                ValidateAlphaNumericAddress: true
            },
            txtExplanationSchedFIE24Contr: {
                required: function () {
                    if ($("#lstMethodIE24HExpPayF option:selected").val().toString() == "7") {
                        return true;
                    }
                    else if ($("#lstContributionName option:selected").val() != null) {
                        return $("#lstContributionName option:selected").val().toString() == "14" || $("#lstContributionName option:selected").val().toString() == "13";
                    }
                    else if ($("#lblExplanation").text().toString() == "* Explanation") {
                        return true;
                    }
                    else {
                        return false;
                    }
                },
                ValidateAlphaNumericAddress: true
            },
            lstMethodIE24HExpPayF: {
                MethodIEValidation: true
            },
            txtCheckIE24ExpPayF: {
                required: function () {
                    return $("#lstMethodIE24HExpPayF option:selected").val().toString() == "1";
                },
                AlphaNumeric: function () {
                    return $("#lstMethodIE24HExpPayF option:selected").val().toString() == "1";
                }
            },
            lstFilingMethod: {
                FileMethodCampMaterial: true
            },
            lstVendorName: {
                VendorNameVal: true
            },
            lstIsClaim: {
                lstIsClaimVal: true
            },
            txtEmployer: {
                required: true,
                ValidateAlphaNumericAddress: true
            },
            txtEmployerPCFB: {
                ValidateAlphaNumericAddress: true
            },
            txtOccupation: {
                required: true,
                ValidateAlphaNumericAddress: true
            },
            txtOccupationPCFB: {
                ValidateAlphaNumericAddress: true
            },
            txtContStreetName: {
                ValidateAlphaNumericAddress: true,
                minlength: 4
            },
            txtContCity: {
                ValidateAlphaNumericAddress: true,
                AlphaSpecialNumOtherCntry: true
            },
            txtContState: {
                ValidateAlphaNumericAddress: true,
                AlphabetsValState: true,
                State2LettersVal: true
            },
            txtContZipCode: {
                FomatZipcodeCont: true,
                OtherCountryZipVal: true
            },
            lstMethod: {
                lstMethodVal: true
            },
        },
        invalidHandler: function (form, Validator) {
            var errors = Validator.numberOfInvalids();
            if (errors) {
                Validator.errorList[0].element.focus();
            }
        },
        errorPlacement: function (error, element) {
            //Set a unique id for the lael based on the element's id
            var uniqueID = $(element).attr('id') + "ValidatorError";
            error.attr('id', uniqueID);
            //Remove any old labels mathing the unique ids
            if ($m("#" + uniqueID).length != 0) {
                $m("#" + uniqueID).remove();
            }
            //Insert the new error label.
            $(error).insertBefore(element);
        },
        messages: {
            lstContributionName: {
                ContributorCodeVal: function () {
                    if ($("#lblContributionName").text().toString() == "* Contributor Type") {
                        return "Error: Contributor Type is required"
                    }
                    else if ($("#lblContributionName").text().toString() == "* Lender Code") {
                        return "Error: Lender Code is required"
                    }
                    else {
                        return "Error: Contributor Type is required"
                    }
                }
            },
            lstSuppOrOpps: {
                lstSuppOrOppsVal: "Error: Is this in Support or Opposition to a Candidate is required"
            },
            lstContributionNameSchedD: {
                ContributorCodeValSchedDNonItem: "Error: Contributor Type is required"
            },
            lstContributionNameInKind: {
                ContributorCodeValSchedD: "Error: Contributor Type is required"
            },
            lstContributionTypeInKind: {
                ContributionTypeValSchedD: "Error: Contribution Type is required"
            },
            lstContributionTypeNonItemD: {
                ContributionTypeValNonItemD: "Error: Contribution Type is required"
            },
            lstTransferType: {
                lstTransferTypeVal: "Error: Transfer Type is required"
            },
            lstOffice: {
                lstOfficeVal: "Error: Office is required"
            },
            lstDistrict: {
                lstDistrictVal: "Error: District is required"
            },
            lstElectionCycleAllocated: {
                lstElectionCycleAllocatedVal: "Error: Election year is required"
            },
            lstExpPaymentName: {
                ExpPaymentNameVal: "Error: Original Name is required"
            },
            lstExpPaymentAmount: {
                ExpPaymentAmountVal: "Error: Original Amount is required"
            },
            lstExpPaymentDate: {
                ExpPaymentDateVal: "Error: Original Expense Date is required"
            },
            lstContributorName: {
                ContributionNameVal: "Error: Original Name is required"
            },
            lstContributorAmount: {
                ContributionAmountVal: "Error: Original Amount is required"
            },
            lstContributorDate: {
                ContributorDateVal: "Error: Original Contribution Date is required"
            },
            lstReceiptCode: {
                RecieptCodeVal: "Error: Receipt Code is required"
            },
            lstPurposeCode: {
                PurposeCodeVal: "Error: Purpose Code is required"
            },
            lstDateIncurred: {
                DateIncurredVal: "Error: Date Incurred & Original Amount is required"
            },
            txtCurrentDate: {
                required: function () {
                    if ($("#lblDatePaid").text() == "* Date Paid")
                        return "Error: Date Paid is required";
                    else
                        return "Error: Date Received is required";
                },
                dateUS: "Error: Enter valid date format (MM/DD/YYYY)",
                ValCutOffDate: function () {
                    if ($("#lstElectionType option:selected").val().toString() != "6") { // Off-Cycle
                        if ($("#lblDatePaid").text() == "* Date Paid")
                            return "Error: Date Paid cannot be later than Cut Off Date";
                        else
                            return "Error: Date Received cannot be later than Cut Off Date";
                    }
                    else {
                        if ($("#lblDatePaid").text() == "* Date Paid")
                            return "Error: Date Paid cannot be later than Filing Date";
                        else
                            return "Error: Date Received cannot be later than Filing Date";
                    }
                }
            },
            txtCurrentDateWCS: {
                required: "Error: Date Received is required",
                dateUS: "Error: Enter valid date format (MM/DD/YYYY)",
                CutOffDateWCFVal: "Error: Invalid date"
            },
            txtCurrentDateTransferred: {
                required: "Error: Date Transferred is required",
                dateUS: "Error: Enter valid date format (MM/DD/YYYY)",
                ValCutOffDateTransferred: "Error: Date Transferred cannot be later than Cut Off Date"
            },
            txtCurrentDateSchedN: {
                required: "Error: Date Incurred is required",
                dateUS: "Enter valid date format (MM/DD/YYYY)",
                ValCutOffDateSchedN: "Error: Date Incurred cannot be later than Filing/Cut Off Date"
            },
            //txtCurrentDateAllocatedSchedR: {
            //    required: "Error: Date Allocated is required",
            //    dateUS: "Error: Enter valid date format (MM/DD/YYYY)",
            //    ValCutOffDateSchedR: "Error: Date Allocated cannot be later than Cut Off Date"
            //},
            txtCurrentDateLoanReceived: {
                required: "Error: Loan Received is required",
                dateUS: "Error: Enter valid date format (MM/DD/YYYY)",
                ValCutOffDateLoanReceived: "Error: Loan Received cannot be later than Cut Off Date"
            },
            txtCurrentDateLoanRepay: {
                required: "Error: Loan Repaid is required",
                dateUS: "Error: Enter valid date format (MM/DD/YYYY)",
                ValCutOffDateLoanRepay: "Error: Loan Repay cannot be later than Cut Off Date"
            },
            txtCurrentDateLoanForgiven: {
                required: "Error: Date Forgiven is required",
                dateUS: "Error: Enter valid date format (MM/DD/YYYY)",
                ValCutOffDateLoanForgiven: "Error: Date Forgiven cannot be later than Cut Off Date"
            },
            txtCurrentDateShedF: {
                required: function () {
                    if ($m("#lblDateRcvd").text() == "* Date Forgiven")
                        return "Error: Date Forgiven is required";
                    else
                        return "Error: Loan paid is required";
                },
                dateUS: "Enter valid date format (MM/DD/YYYY)",
                ValCutOffDateLoanRepayScheF: function () {
                    if ($m("#lblDateRcvd").text() == "* Date Forgiven") {
                        return "Error: Date Forgiven cannot be later than Cut Off Date";
                    }
                    else {
                        return "Error: Loan paid cannot be later than Cut Off Date";
                    }
                }
            },
            txtCurrentDateSchedL: {
                required: "Error: Date Refund Paid is required",
                dateUS: "Error: Enter valid date format (MM/DD/YYYY)",
                ValCutOffDateSchedL: "Error: Date Refund Paid cannot be later than Cut Off Date"
            },
            txtCurrentDateSchedQ: {
                required: "Error: Date Paid is required",
                dateUS: "Error: Enter valid date format (MM/DD/YYYY)",
                ValCutOffDateSchedQ: "Error: Date Paid cannot be later than Cut Off Date"
            },
            txtCurrentDate24HNotice: {
                required: "Error: Date Received is required",
                dateUS: "Error: Enter valid date format (MM/DD/YYYY)",
                ValCutOffDateSchedA24HNotice: "Error: Date Received should be between ‘From date’ and ‘To date’"
            },
            txtCurrentDateIEWeeklyContr: {
                required: function () {
                    if ($("#lblDateReceived").text() == "* Date Paid") {
                        return "Error: Date Paid is required";
                    }
                    else if ($("#lblDateReceived").text() == "* Date Incurred") {
                        return "Error: Date Incurred is required";
                    }
                    else {
                        return "Error: Date Received is required";
                    }
                },
                //required: "Date Received is required",
                dateUS: "Error: Enter valid date format (MM/DD/YYYY)",
                ValDateRecSchedAIEWeeklyContr: "Error: Date Received should be with in the Election Year, and cannot be later than Filing Date"
            },
            txtCurrentDateIE24HourExp: {
                required: "Error: Date Paid is required",
                dateUS: "Error: Enter valid date format (MM/DD/YYYY)",
                ValDateRecSchedFIE24HourExp: "Error: Date Received should be between ‘From date’ and ‘To date’"
            },
            txtCurrentDateIE24HContr: {
                required: "Error: Date Received is required",
                dateUS: "Error: Enter valid date format (MM/DD/YYYY)",
                ValDateRecSchedAIE24HContr: "Error: Date Received should be between From Date and To Date"
            },
            txtCurrentDateReceived: {
                required: "Error: Date Received is required",
                dateUS: "Error: Enter valid date format (MM/DD/YYYY)",
                CutCurrentDateVal: "Error: Date Received cannot be the future Date"
            },
            txtDateRefundPaid: {
                required: "Error: Date of Refund Paid is required",
                dateUS: "Error: Enter valid date format (MM/DD/YYYY)",
                DateRefundCurrentDateVal: "Error: Date Received cannot be the future Date"
            },
            txtFirstName: {
                required: "Error: First Name is required",
                NameOnlyValidate: "Error: Letters, numbers and characters '# -.,&() are allowed"
            },
            txtMI: {
                NameOnlyValidate: "Error: Letters, numbers and characters '# -.,&() are allowed"
            },
            txtLastName: {
                required: "Error: Last Name is required",
                NameOnlyValidate: "Error: Letters, numbers and characters '# -.,&() are allowed"

            },
            txtPartnerShipName: {
                required: function () {
                    if ($("#lblPartnershipName").text().toString() == "* Contributor Name") {
                        return "Error: Contributor Name is required";
                    }
                    else if ($("#lblPartnershipName").text().toString() == "* Lender Name") {
                        return "Error: Lender Name is required";
                    }
                    else {
                        return "Error: Partnership Name is required";
                    }
                },
                //"Partnership Name is required",
                EntityNameValidate: "Error: Letters, numbers and characters '# -.,&() are allowed"
            },
            txtPartnerShipNameSchedDIN: {
                required: "Error: Contributor Name is required",
                EntityNameValidate: "Error: Letters, numbers and characters '# -.,&() are allowed"
            },
            txtTransferorName: {
                required: "Error: Transferor Name is required",
                EntityNameValidate: "Error: Letters, numbers and characters '# -.,&() are allowed"
            },
            txtCreditorName: {
                required: "Error: Creditor Name is required",
                EntityNameValidate: "Error: Letters, numbers and characters '# -.,&() are allowed"
            },
            txtTransfereeName: {
                required: "Error: Transferee Name is required",
                EntityNameValidate: "Error: Letters, numbers and characters '# -.,&() are allowed"
            },
            txtReceiptSource: {
                required: "Error: Receipt Source is required",
                EntityNameValidate: "Error: Letters and characters '# -.,&() are allowed"
            },
            txtPayorName: {
                required: "Error: Payor Name is required",
                EntityNameValidate: "Error: Letters, numbers and characters '# -.,&() are allowed"
            },
            txtPayeeNameShedF: {
                required: "Error: Payee Name is required",
                EntityNameValidate: "Error: Letters, numbers and characters '# -.,&() are allowed"
            },
            txtContributorName: {
                required: "Error: Contributor Name is required",
                EntityNameValidate: "Error: Letters, numbers and characters '# -.,&() are allowed"
            },
            txtPayeeName: {
                required: function () {
                    if ($("#lblPartnershipName").text().toString() == "* Creditor Name") {
                        return "Error: Creditor Name is required";
                    }
                    else {
                        return "Error: Payee Name is required";
                    }
                },
                EntityNameValidate: "Error: Letters, numbers and characters '# -.,&() are allowed"
            },
            txtTreasurerOccupation: {
                required: "Error: Treasurer Occupation is required", //"Submitter's Occupation is required",
                NameValidate: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtContributorOccupation: {
                required: function () {
                    if ($("#lblContributorOccupation").text().toString() == "* Creditor Occupation") {
                        return "Error: Creditor Occupation is required"
                    }
                    else {
                        return "Error: Contributor Occupation is required"
                    }
                },
                NameValidate: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtTreasurerEmployer: {
                required: "Error: Treasurer Employer is required",
                NameValidate: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtContributorEmployer: {
                required: function () {
                    if ($("#lblContributorEmployer").text().toString() == "* Creditor Employer") {
                        return "Error: Creditor Employer is required"
                    }
                    else {
                        return "Error: Contributor Employer is required"
                    }
                },
                NameValidate: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtIndependentExpenditureDescription: {
                required: "Error: Independent Expenditure Description is required",
                NameValidate: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtCandidateNameBPReference: {
                required: "Error: Candidate Name/Ballot Proposal Reference is required",
                NameValidate: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtStreetName: {
                required: "Error: Street Address is required",
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed",
                //ValidateSpaces: "Letters, numbers and characters '# -., are allowed",
                minlength: "Error: Street Address must contain at least four characters"
            },
            txtStreetNameShedF: {
                required: "Error: Street Address is required",
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed",
                minlength: "Error: Street Address must contain at least four characters"
            },
            txtStreetNameTreasurer: {
                required: "Error: Treasurer Street Address is required",
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed",
                minlength: "Error: Street Address must contain at least four characters"
            },
            txtCity: {
                required: "Error: City is required",
                ValidateAlphaSpecial: "Error: Letters and characters '# -., are allowed",
                AlphaSpecialNumOtherCntry: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtCityShedF: {
                required: "Error: City is required",
                ValidateAlphaSpecial: "Error: Letters and characters '# -., are allowed",
                AlphaSpecialNumOtherCntry: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtCityTreasurer: {
                required: "Error: Treasurer City is required",
                ValidateAlphaSpecialTreasurerCity: "Letters and characters '# -., are allowed"
            },
            txtState: {
                required: "Error: State is required",
                AlphaSpecialStateOtherCntry: "Error: Letters, numbers and characters '# -., are allowed",
                AlphabetsValState: "Error: Two letters are allowed",
                State2LettersVal: "Error: Two letters are allowed"
            },
            txtStateShedF: {
                required: "Error: State is required",
                AlphaSpecialStateOtherCntry: "Error: Letters, numbers and characters '# -., are allowed",
                AlphabetsValState: "Error: Two letters are allowed",
                State2LettersVal: "Error: Two letters are allowed"
            },
            txtStateTreasurer: {
                required: "Error: Treasurer State is required",
                ValidateAlphaTreasurerState: "Error: Two letters are allowed"
            },
            txtCountry: {
                required: "Error: Country is required",
                AlphabetsVal: "Error: Letters are allowed"
            },
            txtCountryShedF: {
                required: "Error: Country is required",
                AlphabetsVal: "Error: Letters are allowed"
            },
            txtZipCode: {
                required: "Error: Zip Code is required",
                FomatZipcode: "Error: Numbers and - are allowed",
                OtherCountryZipVal: "Error: Letters, numbers and - are allowed"
            },
            txtZipCodeShedF: {
                required: "Error: Zip Code is required",
                FomatZipcodeSchedF: "Error: Numbers and - are allowed",
                OtherCountryZipVal: "Error: Letters, numbers and - are allowed"
            },
            txtZipCodeTreasurer: {
                required: "Error: Treasurer Zip Code is required",
                FomatZipcodeTreasurer: "Error: Numbers and - are allowed",
            },
            txtCheck: {
                //required: "Error: Check # is required",                
                required: function () {
                    if ($("#lblCheck").text().toString() == "* Check #") {
                        return "Error: Check # is required"
                    }
                    else if ($("#lblCheck").text().toString() == "* Money Order #") {
                        return "Error: Money Order # is required"
                    }
                    else {
                        return "Error: Check # is required"
                    }
                },
                AlphaNumeric: "Error: Letters and numbers are allowed"
            },
            txtCheckExpenditurePayments: {
                required: "Error: Check # is required",
                AlphaNumeric: "Error: Letters and numbers are allowed"
            },
            txtCheckShedF: {
                required: "Error: Check # is required",
                AlphaNumeric: "Error: Letters and numbers are allowed"
            },
            txtAmt: {
                required: "Error: Amount is required",
                AmountValidate: "Error: Enter valid Amount (999999999.99)",
                number: "Error: Enter valid Amount (999999999.99)",
                Amount12DigitVal: "Error: Enter valid Amount (999999999.99)",
                AmountZeroValtxtAmt: "Error: Enter valid Amount (999999999.99)"
            },
            txtAmtABC: {
                required: "Error: Amount is required",
                AmountValidate: "Error: Enter valid Amount (999999999.99)",
                number: "Error: Enter valid Amount (999999999.99)",
                Amount12DigitValABC: "Error: Enter valid Amount (999999999.99)",
                AmountZeroValSchedABC: "Error: Enter valid Amount (999999999.99)"
            },
            txtAmtSchedD: {
                required: "Error: Amount is required",
                AmountValidate: "Error: Enter valid Amount (999999999.99)",
                number: "Error: Enter valid Amount (999999999.99)",
                Amount12DigitValD: "Error: Enter valid Amount (999999999.99)",
                // Amount12DigitValSchede - It was using wrong variable error message not showing.
                AmountValZeroSchedD: "Error: Enter valid Amount (999999999.99)"
            },
            txtAmtSchedE: {
                required: "Error: Amount is required",
                AmountValidate: "Error: Enter valid Amount (999999999.99)",
                number: "Error: Enter valid Amount (999999999.99)",
                Amount12DigitValSchedE: "Error: Enter valid Amount (999999999.99)",
                AmountValZeroSchedE: "Error: Enter valid Amount (999999999.99)"
            },
            txtAmtSchedN: {
                required: "Error: Amount is required",
                AmountValidate: "Error: Enter valid Amount (999999999.99)",
                number: "Error: Enter valid Amount (999999999.99)",
                Amount12DigitValN: "Error: Enter valid Amount (999999999.99)",
                AmountValZeroSchedN: "Error: Enter valid Amount (999999999.99)"
            },
            txtAmtSchedP: {
                required: "Error: Amount is required",
                AmountValidate: "Error: Enter valid Amount (999999999.99)",
                number: "Error: Enter valid Amount (999999999.99)",
                Amount12DigitValP: "Error: Enter valid Amount (999999999.99)",
                AmountValZeroSchedP: "Error: Enter valid Amount (999999999.99)"
            },
            txtAmtSchedQ: {
                required: "Error: Amount is required",
                AmountValidate: "Error: Enter valid Amount (999999999.99)",
                number: "Error: Enter valid Amount (999999999.99)",
                Amount12DigitValQ: "Error: Enter valid Amount (999999999.99)",
                AmountValZeroSchedQ: "Error: Enter valid Amount (999999999.99)"
            },
            txtAmountRefunded: {
                required: "Error: Amount Refunded is required",
                number: "Error: Enter valid Amount (999999999.99)",
                AmountValidate: "Error: Enter valid Amount (999999999.99)",
                Amount12DigitValSchedL: "Error: Enter valid Amount (999999999.99)",
                AmountZeroValSchedL: "Error: Enter valid Amount (999999999.99)"
            },
            txtOriginalAmount: {
                required: "Error: Original Amount is required",
                number: "Error: Enter valid Amount (999999999.99)",
                AmountValidate: "Error: Enter valid Amount (999999999.99)",
                Amount12DigitValSchedF: "Error: Enter valid Amount (999999999.99)",
                AmountZeroValSchedF: "Error: Enter valid Amount (999999999.99)"
            },
            txtAmtExpenditurePayments: {
                required: function () {
                    if ($m("#lblAmount").text() == "* Partial Amount $") {
                        return "Error: Partial Amount is required";
                    }
                    else if ($m("#lblAmountSchedFK").text() == "* Amount Forgiven $") {
                        return "Error: Amount Forgiven is required";
                    }
                    else {
                        return "Error: Amount is required";
                    }
                },
                number: "Error: Enter valid Amount (999999999.99)",
                AmountValidate: "Error: Enter valid Amount (999999999.99)",
                Amount12DigitValSchedFAmt: "Error: Enter valid Amount (999999999.99)",
                AmountZeroValSchedFAmt: "Error: Enter valid Amount (999999999.99)"
            },
            txtAmt24HNotice: {
                required: "Error: Amount is required",
                number: "Error: Enter valid Amount (999999999.99)",
                AmountValidate: "Error: Enter valid Amount (999999999.99)",
                Amount12DigitValSchedA24HNotice: "Error: Enter valid Amount (999999999.99)",
                AmountZeroValSchedA24HNotice: "Error: Enter valid Amount (999999999.99)",
                Amount24HNoticeValidate: "Error: A 24 Hour Notice is only applicable for contribution or loan amount exceeding $1,000"
            },
            txtAmtIEWeeklyContr: {
                required: "Error: Amount is required",
                number: "Error: Enter valid Amount (999999999.99)",
                AmountValidate: "Error: Enter valid Amount (999999999.99)",
                Amount12DigitValSchedAIEWContr: "Error: Enter valid Amount (999999999.99)",
                AmountZeroValSchedAIEWContr: "Error: Enter valid Amount (999999999.99)",
                AmountIEWContrValidate: "Error: Amount is not over $1,000. Independent Expenditure filing is not required "
            },
            txtAmtIEWeeklyExpenditure: {
                required: "Error: Amount is required",
                number: "Error: Enter valid Amount (999999999.99)",
                AmountValidate: "Error: Enter valid Amount (999999999.99)",
                Amount12DigitValSchedFIEWExp: "Error: Enter valid Amount (999999999.99)",
                AmountZeroValSchedFIEWExp: "Error: Enter valid Amount (999999999.99)",
                AmountIEWExpValidate: "Error: Amount is not over $5,000. Independent Expenditure filing is not required "
            },
            txtAmtIEWeeklyPIDAExpenditure: {
                required: "Error: Amount is required",
                number: "Error: Enter valid Amount (999999999.99)",
                AmountValidate: "Error: Enter valid Amount (999999999.99)",
                Amount12DigitValSchedFIEWExpPIDA: "Error: Enter valid Amount (999999999.99)",
                AmountZeroValSchedFIEWExpPIDA: "Error: Enter valid Amount (999999999.99)",
                AmountIEWExpPIDAValidate: "Error: Amount is not over $500. Independent Expenditure filing for PIDA is not required "
            },
            txtAmtIE24HrPIDAExpenditure: {
                required: "Error: Amount is required",
                number: "Error: Enter valid Amount (999999999.99)",
                AmountValidate: "Error: Enter valid Amount (999999999.99)",
                Amount12DigitValSchedFIE24HrPIDA: "Error: Enter valid Amount (999999999.99)",
                AmountZeroValSchedFIE24HrPIDA: "Error: Enter valid Amount (999999999.99)",
                AmountIE24HrPIDAValidate: "Error: Amount is not over $500. Independent Expenditure filing for PIDA is not required "
            },
            txtOriginalAmountShedF: {
                required: "Error: Original Amount is required",
                number: "Error: Enter valid Amount (999999999.99)",
                AmountValidate: "Error: Enter valid Amount (999999999.99)",
                AmountOriginalSchedKFVal: "Error: Enter valid Amount (999999999.99)",
                AmountOriginalShedKFVal: "Error: Enter valid Amount (999999999.99)"
            },
            txtAmtExpensesAllocation: {
                required: "Error: Amount is required",
                number: "Error: Enter valid Amount (999999999.99)1",
                AmountValidateForSchedR: "Error: Enter valid Amount (999999999.99)2",
                Amount12DigitValSchedR: "Error: Enter valid Amount (999999999.99)3",
                AmountZeroValtxtAmtSchedR: "Error: Enter valid Amount (999999999.99)4"
            },
            txtExplanation: {
                required: "Error: Explanation is required",
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtExplanationCommonShedF: {
                required: "Error: Explanation is required",
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtExplanationCommon: {
                required: "Error: Explanation is required",
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtExplanationCommonScheR: {
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtExplanationSchedE: {
                required: "Error: Explanation is required",
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtExplanationInKind: {
                required: "Error: Explanation is required",
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtLenderFirstName: {
                required: "Error: First Name is required",
                NameOnlyValidate: "Error: Letters, numbers and characters '# -.,&() are allowed"
            },
            txtLenderMIName: {
                NameOnlyValidate: "Error: Letters, numbers and characters '# -.,&() are allowed"
            },
            txtLenderLastName: {
                required: "Error: Last Name is required",
                NameOnlyValidate: "Error: Letters, numbers and characters '# -.,&() are allowed"

            },
            txtLenderName: {
                required: "Error: Lender Name is required",
                NameOnlyValidate: "Error: Letters, numbers and characters '# -.,&() are allowed"

            },
            lstLoanerCode: {
                lstLoanerCodeVal: "Error: Lender code is required"
            },
            lstReceiptType: {
                lstReceiptTypeValid: "Error: Receipt Type is required"
            },
            txtExplanationSchedP: {
                required: "Error: Explanation is required",
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtDescription: {
                required: "Error: Description is required",
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtFileUpload: {
                required: "Error: File To Upload is required"
            },
            lstContributionType: {
                required: "Error: Contribution Type is required"
            },
            lstSearchName: {
                //required: "Original name is required"
                lstSearchNameVal: "Error: Original Name is required"
            },
            lstSearchAmount: {
                lstSearchAmountVal: "Error: Original Amount is required"
            },
            lstSearchDate: {
                lstSearchDateVal: "Error: Original Date is required"
            },
            lstLiabilityLoans: {
                lstLiabilityLoansVal: "Error: Liability/Loan is required"
            },
            txtExplanationSchedQ: {
                required: "Error: Explanation is required",
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtExplanationSchedF: {
                required: "Error: Explanation is required",
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtExplanationSchedFIE24: {
                required: "Error: Explanation is required",
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtExplanationSchedFIE24Contr: {
                required: "Error: Explanation is required",
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed"
            },
            lstMethodIE24HExpPayF: {
                MethodIEValidation: "Error: Method is required"
            },
            txtCheckIE24ExpPayF: {
                required: "Error: Check # is required",
                AlphaNumeric: "Error: Letters and numbers are allowed"
            },
            lstFilingMethod: {
                FileMethodCampMaterial: "Error: Filing Method is required"
            },
            lstVendorName: {
                VendorNameVal: "Error: Vendor Name is required"
            },
            lstIsClaim: {
                lstIsClaimVal: "Error: Transaction Being Submitted for Claim is required"
            },
            txtEmployer: {
                required: "Error: Employer is required",
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtEmployerPCFB: {
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtOccupation: {
                required: "Error: Occupation is required",
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtOccupationPCFB: {
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtContStreetName: {
                //required: "Error: Street Address is required",
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed",
                minlength: "Error: Street Address must contain at least four characters"
            },
            txtContCity: {
                //required: "Error: City is required",
                ValidateAlphaNumericAddress: "Error: Letters and characters '# -., are allowed",
                AlphaSpecialNumOtherCntry: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtContState: {
                //required: "Error: State is required",
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed",
                AlphabetsValState: "Error: Two letters are allowed",
                State2LettersVal: "Error: Two letters are allowed"
            },
            txtContZipCode: {
                //required: "Error: Zip Code is required",
                FomatZipcodeCont: "Error: Numbers and - are allowed",
                OtherCountryZipVal: "Error: Letters, numbers and - are allowed"
            },
            lstMethod: {
                lstMethodVal: "Error: Method is required"
            },
        },
        
        onfocusout: function (element) {
            $m(element).valid();
        },
    });


    // FORM VALIDATION SCHEDULE 'A' JQUERY VALIDATOR
    //----------------------------------------------------------------------------------------------------------------------------------------------


    //$m('#DialogBoxSchedAPartnershipForm').validate();
    // FORM VALIDATION SCHEDULE 'A' PARTNERSHIP JQUERY VALIDATOR
    //----------------------------------------------------------------------------------------------------------------------------------------------

    // REMOVING ERROR COLOR AND MESSAGE ON OTHER COUNTRY CHECKBOX
    // AUTO GENERATE LABEL ID F12 WE HAVE TO FIND OUT AND ERROR CLASS ON F12
    //-------------------------------------------------------------------------------------------
    ////////////$("#lstSearchElectionDate").removeClass("PolCalSearchInvalid");
    ////////////$("label[for=lstSearchElectionDate]").text('');

    $m('.datepicker').on('change', function () {
        $m(this).valid();
    });

    $m('#txtZipCode').attr("placeholder", "00000-0000");
    $("#txtZipCode").addClass("watermarkHTMLTextBox");
    $("#txtZipCode").focusin(function () {
        $("#txtZipCode").removeClass("watermarkHTMLTextBox");
    });

    $("#txtZipCode").focusout(function () {
        if ($("#txtZipCode").val().toString() == "") {
            $("#txtZipCode").addClass("watermarkHTMLTextBox");
        }
        if ($('#chkCountry').is(':checked') == true) {
            $m('#txtZipCode').attr("placeholder", "");
        }
        else {
            $m('#txtZipCode').attr("placeholder", "00000-0000");
        }
    });

    $m('#txtZipCodeShedF').attr("placeholder", "00000-0000");
    $("#txtZipCodeShedF").addClass("watermarkHTMLTextBox");
    $("#txtZipCodeShedF").focusin(function () {
        $("#txtZipCodeShedF").removeClass("watermarkHTMLTextBox");
    });

    $("#txtZipCodeShedF").focusout(function () {
        if ($("#txtZipCodeShedF").val().toString() == "") {
            $("#txtZipCodeShedF").addClass("watermarkHTMLTextBox");
        }
        if ($('#chkCountry').is(':checked') == true) {
            $m('#txtZipCodeShedF').attr("placeholder", "");
        }
        else {
            $m('#txtZipCodeShedF').attr("placeholder", "00000-0000");
        }
    });

    $m('#txtZipCodeTreasurer').attr("placeholder", "00000-0000");
    $("#txtZipCodeTreasurer").addClass("watermarkHTMLTextBox");
    $("#txtZipCodeTreasurer").focusin(function () {
        $("#txtZipCodeTreasurer").removeClass("watermarkHTMLTextBox");
    });

    $("#txtZipCodeTreasurer").focusout(function () {
        if ($("#txtZipCodeTreasurer").val().toString() == "") {
            $("#txtZipCodeTreasurer").addClass("watermarkHTMLTextBox");
        }
        if ($('#chkCountry').is(':checked') == true) {
            $m('#txtZipCodeTreasurer').attr("placeholder", "");
        }
        else {
            $m('#txtZipCodeTreasurer').attr("placeholder", "00000-0000");
        }
    });

    $m('#txtPartZip5').attr("placeholder", "00000-0000");
    $("#txtPartZip5").addClass("watermarkHTMLTextBox");
    $("#txtPartZip5").focusin(function () {
        $("#txtPartZip5").removeClass("watermarkHTMLTextBox");
    });

    $m('#txtZipCodeReim').attr("placeholder", "00000-0000");
    $("#txtZipCodeReim").addClass("watermarkHTMLTextBox");
    $("#txtZipCodeReim").focusin(function () {
        $("#txtZipCodeReim").removeClass("watermarkHTMLTextBox");
    });

    $m('#txtZipCodeCCI').attr("placeholder", "00000-0000");
    $("#txtZipCodeCCI").addClass("watermarkHTMLTextBox");
    $("#txtZipCodeCCI").focusin(function () {
        $("#txtZipCodeCCI").removeClass("watermarkHTMLTextBox");
    });

    $("#txtPartZip5").focusout(function () {
        if ($("#txtPartZip5").val().toString() == "") {
            $("#txtPartZip5").addClass("watermarkHTMLTextBox");
        }
        if ($('#chkCountryPartnership').is(':checked') == true) {
            $m('#txtPartZip5').attr("placeholder", "");
        }
        else {
            $m('#txtPartZip5').attr("placeholder", "00000-0000");
        }
    });

    $("#txtZipCodeReim").focusout(function () {
        if ($("#txtZipCodeReim").val().toString() == "") {
            $("#txtZipCodeReim").addClass("watermarkHTMLTextBox");
        }
        if ($('#chkCountryReim').is(':checked') == true) {
            $m('#txtZipCodeReim').attr("placeholder", "");
        }
        else {
            $m('#txtZipCodeReim').attr("placeholder", "00000-0000");
        }
    });

    $("#txtZipCodeCCI").focusout(function () {
        if ($("#txtZipCodeCCI").val().toString() == "") {
            $("#txtZipCodeCCI").addClass("watermarkHTMLTextBox");
        }
        if ($('#chkCountryCCI').is(':checked') == true) {
            $m('#txtZipCodeCCI').attr("placeholder", "");
        }
        else {
            $m('#txtZipCodeCCI').attr("placeholder", "00000-0000");
        }
    });

    $m('#txtAmt').attr("placeholder", "999999999.99");
    $("#txtAmt").addClass("watermarkHTMLTextBox");
    $("#txtAmt").focusin(function () {
        $("#txtAmt").removeClass("watermarkHTMLTextBox");
    });

    $m('#txtAmtABC').attr("placeholder", "999999999.99");
    $("#txtAmtABC").addClass("watermarkHTMLTextBox");
    $("#txtAmtABC").focusin(function () {
        $("#txtAmtABC").removeClass("watermarkHTMLTextBox");
    });

    $m('#txtAmtSchedD').attr("placeholder", "999999999.99");
    $("#txtAmtSchedD").addClass("watermarkHTMLTextBox");
    $("#txtAmtSchedD").focusin(function () {
        $("#txtAmtSchedD").removeClass("watermarkHTMLTextBox");
    });

    $m('#txtAmtSchedN').attr("placeholder", "999999999.99");
    $("#txtAmtSchedN").addClass("watermarkHTMLTextBox");
    $("#txtAmtSchedN").focusin(function () {
        $("#txtAmtSchedN").removeClass("watermarkHTMLTextBox");
    });

    $m('#txtAmtSchedP').attr("placeholder", "999999999.99");
    $("#txtAmtSchedP").addClass("watermarkHTMLTextBox");
    $("#txtAmtSchedP").focusin(function () {
        $("#txtAmtSchedP").removeClass("watermarkHTMLTextBox");
    });

    $m('#txtAmtSchedP').attr("placeholder", "999999999.99");
    $("#txtAmtSchedP").addClass("watermarkHTMLTextBox");
    $("#txtAmtSchedP").focusin(function () {
        $("#txtAmtSchedP").removeClass("watermarkHTMLTextBox");
    });

    $m('#txtAmtSchedQ').attr("placeholder", "999999999.99");
    $("#txtAmtSchedQ").addClass("watermarkHTMLTextBox");
    $("#txtAmtSchedQ").focusin(function () {
        $("#txtAmtSchedQ").removeClass("watermarkHTMLTextBox");
    });

    $m('#txtOutstandingAmtShedF').attr("placeholder", "999999999.99");
    $("#txtOutstandingAmtShedF").addClass("watermarkHTMLTextBox");
    $("#txtOutstandingAmtShedF").focusin(function () {
        $("#txtOutstandingAmtShedF").removeClass("watermarkHTMLTextBox");
    });

    $m('#txtAmtExpenditurePayments').attr("placeholder", "999999999.99");
    $("#txtAmtExpenditurePayments").addClass("watermarkHTMLTextBox");
    $("#txtAmtExpenditurePayments").focusin(function () {
        $("#txtAmtExpenditurePayments").removeClass("watermarkHTMLTextBox");
    });

    $m('#txtAmt24HNotice').attr("placeholder", "999999999.99");
    $("#txtAmt24HNotice").addClass("watermarkHTMLTextBox");
    $("#txtAmt24HNotice").focusin(function () {
        $("#txtAmt24HNotice").removeClass("watermarkHTMLTextBox");
    });

    $m('#txtAmtIEWeeklyContr').attr("placeholder", "999999999.99");
    $("#txtAmtIEWeeklyContr").addClass("watermarkHTMLTextBox");
    $("#txtAmtIEWeeklyContr").focusin(function () {
        $("#txtAmtIEWeeklyContr").removeClass("watermarkHTMLTextBox");
    });

    $m('#txtAmtIEWeeklyExpenditure').attr("placeholder", "999999999.99");
    $("#txtAmtIEWeeklyExpenditure").addClass("watermarkHTMLTextBox");
    $("#txtAmtIEWeeklyExpenditure").focusin(function () {
        $("#txtAmtIEWeeklyExpenditure").removeClass("watermarkHTMLTextBox");
    });

    $m('#txtAmtIEWeeklyPIDAExpenditure').attr("placeholder", "999999999.99");
    $("#txtAmtIEWeeklyPIDAExpenditure").addClass("watermarkHTMLTextBox");
    $("#txtAmtIEWeeklyPIDAExpenditure").focusin(function () {
        $("#txtAmtIEWeeklyPIDAExpenditure").removeClass("watermarkHTMLTextBox");
    });

    $m('#txtAmtIE24HrPIDAExpenditure').attr("placeholder", "999999999.99");
    $("#txtAmtIE24HrPIDAExpenditure").addClass("watermarkHTMLTextBox");
    $("#txtAmtIE24HrPIDAExpenditure").focusin(function () {
        $("#txtAmtIE24HrPIDAExpenditure").removeClass("watermarkHTMLTextBox");
    });

    $m('#txtAmountRefunded').attr("placeholder", "999999999.99");
    $("#txtAmountRefunded").addClass("watermarkHTMLTextBox");
    $("#txtAmountRefunded").focusin(function () {
        $("#txtAmountRefunded").removeClass("watermarkHTMLTextBox");
    });

    $m('#txtOriginalAmount').attr("placeholder", "999999999.99");
    $("#txtOriginalAmount").addClass("watermarkHTMLTextBox");
    $("#txtOriginalAmount").focusin(function () {
        $("#txtOriginalAmount").removeClass("watermarkHTMLTextBox");
    });

    $m('#txtPartAmt').attr("placeholder", "999999999.99");
    $("#txtPartAmt").addClass("watermarkHTMLTextBox");
    $("#txtPartAmt").focusin(function () {
        $("#txtPartAmt").removeClass("watermarkHTMLTextBox");
    });

    $m('#txtPartAmtAC').attr("placeholder", "999999999.99");
    $("#txtPartAmtAC").addClass("watermarkHTMLTextBox");
    $("#txtPartAmtAC").focusin(function () {
        $("#txtPartAmtAC").removeClass("watermarkHTMLTextBox");
    });

    $m('#txtPartAmtSchedD').attr("placeholder", "999999999.99");
    $("#txtPartAmtSchedD").addClass("watermarkHTMLTextBox");
    $("#txtPartAmtSchedD").focusin(function () {
        $("#txtPartAmtSchedD").removeClass("watermarkHTMLTextBox");
    });

    $m('#txtPartAmtSchedF').attr("placeholder", "999999999.99");
    $("#txtPartAmtSchedF").addClass("watermarkHTMLTextBox");
    $("#txtPartAmtSchedF").focusin(function () {
        $("#txtPartAmtSchedF").removeClass("watermarkHTMLTextBox");
    });

    $m('#txtPartAmtSchedP').attr("placeholder", "999999999.99");
    $("#txtPartAmtSchedP").addClass("watermarkHTMLTextBox");
    $("#txtPartAmtSchedP").focusin(function () {
        $("#txtPartAmtSchedP").removeClass("watermarkHTMLTextBox");
    });

    $m('#txtAmtReim').attr("placeholder", "999999999.99");
    $("#txtAmtReim").addClass("watermarkHTMLTextBox");
    $("#txtAmtReim").focusin(function () {
        $("#txtAmtReim").removeClass("watermarkHTMLTextBox");
    });

    $m('#txtAmountCCI').attr("placeholder", "999999999.99");
    $("#txtAmountCCI").addClass("watermarkHTMLTextBox");
    $("#txtAmountCCI").focusin(function () {
        $("#txtAmountCCI").removeClass("watermarkHTMLTextBox");
    });

    $m('#txtOutstandingAmt').attr("placeholder", "999999999.99");
    $("#txtOutstandingAmt").addClass("watermarkHTMLTextBox");
    $("#txtOutstandingAmt").focusin(function () {
        $("#txtOutstandingAmt").removeClass("watermarkHTMLTextBox");
    });

    $m('#txtOriginalAmountShedF').attr("placeholder", "999999999.99");
    $("#txtOriginalAmountShedF").addClass("watermarkHTMLTextBox");
    $("#txtOriginalAmountShedF").focusin(function () {
        $("#txtOriginalAmountShedF").removeClass("watermarkHTMLTextBox");
    });

    $("#txtAmt").focusout(function () {
        if ($("#txtAmt").val().toString() != "") {
            if ($("#txtAmt").val().toString().length <= 9) {
                var regExpNumbers = /^[0-9.]+$/;
                if (regExpNumbers.test($("#txtAmt").val().toString())) {
                    var strAmount = $("#txtAmt").val().toString();
                    var indexAmount = strAmount.indexOf(".");
                    if (indexAmount != -1) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmt").val().toString()).toFixed(2);
                            $("#txtAmt").val(amountFloat);
                        }
                    }
                    else {
                        var amountFloat = parseFloat($("#txtAmt").val().toString()).toFixed(2);
                        $("#txtAmt").val(amountFloat);
                    }
                }
            }
            else {
                var strAmount = $("#txtAmt").val().toString();
                var indexAmount = strAmount.indexOf(".");
                var varPeriod = strAmount.indexOf(".");
                var newStrAmount = strAmount.substr(0, varPeriod);
                if (indexAmount != -1) {
                    if (newStrAmount.length <= 9) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmt").val().toString()).toFixed(2);
                            $("#txtAmt").val(amountFloat);
                        }
                    }
                }
            }
            $("#txtAmt").removeClass("watermarkHTMLTextBox");
        }
        else {
            $("#txtAmt").addClass("watermarkHTMLTextBox");
        }
    });

    $("#txtAmtExpensesAllocation").focusout(function () {
        if ($("#txtAmtExpensesAllocation").val().toString() != "") {
            var varAmount = $("#txtAmtExpensesAllocation").val().toString();
            if (varAmount.indexOf('-') > -1) {
                if ($("#txtAmtExpensesAllocation").val().toString().length <= 10) {
                    var regExpNumbers = /^-?[0-9.]+$/;
                    if (regExpNumbers.test($("#txtAmtExpensesAllocation").val().toString())) {
                        var strAmount = $("#txtAmtExpensesAllocation").val().toString();
                        var indexAmount = strAmount.indexOf(".");
                        if (indexAmount != -1) {
                            var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                            if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                                var amountFloat = parseFloat($("#txtAmtExpensesAllocation").val().toString()).toFixed(2);
                                $("#txtAmtExpensesAllocation").val(amountFloat);
                            }
                        }
                        else {
                            var amountFloat = parseFloat($("#txtAmtExpensesAllocation").val().toString()).toFixed(2);
                            $("#txtAmtExpensesAllocation").val(amountFloat);
                        }
                    }
                }
                else {
                    var strAmount = $("#txtAmtExpensesAllocation").val().toString();
                    var indexAmount = strAmount.indexOf(".");
                    var varPeriod = strAmount.indexOf(".");
                    var newStrAmount = strAmount.substr(0, varPeriod);
                    if (indexAmount != -1) {
                        if (newStrAmount.length <= 10) {
                            var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                            if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                                var amountFloat = parseFloat($("#txtAmtExpensesAllocation").val().toString()).toFixed(2);
                                $("#txtAmtExpensesAllocation").val(amountFloat);
                            }
                        }
                    }
                }
                $("#txtAmtExpensesAllocation").removeClass("watermarkHTMLTextBox");
            }
            else {
                if ($("#txtAmtExpensesAllocation").val().toString().length <= 9) {
                    var regExpNumbers = /^[0-9.]+$/;
                    if (regExpNumbers.test($("#txtAmtExpensesAllocation").val().toString())) {
                        var strAmount = $("#txtAmtExpensesAllocation").val().toString();
                        var indexAmount = strAmount.indexOf(".");
                        if (indexAmount != -1) {
                            var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                            if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                                var amountFloat = parseFloat($("#txtAmtExpensesAllocation").val().toString()).toFixed(2);
                                $("#txtAmtExpensesAllocation").val(amountFloat);
                            }
                        }
                        else {
                            var amountFloat = parseFloat($("#txtAmtExpensesAllocation").val().toString()).toFixed(2);
                            $("#txtAmtExpensesAllocation").val(amountFloat);
                        }
                    }
                }
                else {
                    var strAmount = $("#txtAmtExpensesAllocation").val().toString();
                    var indexAmount = strAmount.indexOf(".");
                    var varPeriod = strAmount.indexOf(".");
                    var newStrAmount = strAmount.substr(0, varPeriod);
                    if (indexAmount != -1) {
                        if (newStrAmount.length <= 9) {
                            var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                            if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                                var amountFloat = parseFloat($("#txtAmtExpensesAllocation").val().toString()).toFixed(2);
                                $("#txtAmtExpensesAllocation").val(amountFloat);
                            }
                        }
                    }
                }
                $("#txtAmtExpensesAllocation").removeClass("watermarkHTMLTextBox");
            }
        }
        else {
            $("#txtAmtExpensesAllocation").addClass("watermarkHTMLTextBox");
        }
    });

    $("#txtAmtABC").focusout(function () {
        if ($("#txtAmtABC").val().toString() != "") {
            if ($("#txtAmtABC").val().toString().length <= 9) {
                var regExpNumbers = /^[0-9.]+$/;
                if (regExpNumbers.test($("#txtAmtABC").val().toString())) {
                    var strAmount = $("#txtAmtABC").val().toString();
                    var indexAmount = strAmount.indexOf(".");
                    if (indexAmount != -1) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmtABC").val().toString()).toFixed(2);
                            $("#txtAmtABC").val(amountFloat);
                        }
                    }
                    else {
                        var amountFloat = parseFloat($("#txtAmtABC").val().toString()).toFixed(2);
                        $("#txtAmtABC").val(amountFloat);
                    }
                }
            }
            else {
                var strAmount = $("#txtAmtABC").val().toString();
                var indexAmount = strAmount.indexOf(".");
                var varPeriod = strAmount.indexOf(".");
                var newStrAmount = strAmount.substr(0, varPeriod);
                if (indexAmount != -1) {
                    if (newStrAmount.length <= 9) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmtABC").val().toString()).toFixed(2);
                            $("#txtAmtABC").val(amountFloat);
                        }
                    }
                }
            }
            $("#txtAmtABC").removeClass("watermarkHTMLTextBox");
        }
        else {
            $("#txtAmtABC").addClass("watermarkHTMLTextBox");
        }
    });

    $("#txtAmtSchedD").focusout(function () {
        if ($("#txtAmtSchedD").val().toString() != "") {
            if ($("#txtAmtSchedD").val().toString().length <= 9) {
                var regExpNumbers = /^[0-9.]+$/;
                if (regExpNumbers.test($("#txtAmtSchedD").val().toString())) {
                    var strAmount = $("#txtAmtSchedD").val().toString();
                    var indexAmount = strAmount.indexOf(".");
                    if (indexAmount != -1) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmtSchedD").val().toString()).toFixed(2);
                            $("#txtAmtSchedD").val(amountFloat);
                        }
                    }
                    else {
                        var amountFloat = parseFloat($("#txtAmtSchedD").val().toString()).toFixed(2);
                        $("#txtAmtSchedD").val(amountFloat);
                    }
                }
            }
            else {
                var strAmount = $("#txtAmtSchedD").val().toString();
                var indexAmount = strAmount.indexOf(".");
                var varPeriod = strAmount.indexOf(".");
                var newStrAmount = strAmount.substr(0, varPeriod);
                if (indexAmount != -1) {
                    if (newStrAmount.length <= 9) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmtSchedD").val().toString()).toFixed(2);
                            $("#txtAmtSchedD").val(amountFloat);
                        }
                    }
                }
            }
            $("#txtAmtSchedD").removeClass("watermarkHTMLTextBox");
        }
        else {
            $("#txtAmtSchedD").addClass("watermarkHTMLTextBox");
        }
    });

    $("#txtAmtSchedE").focusout(function () {
        if ($("#txtAmtSchedE").val().toString() != "") {
            if ($("#txtAmtSchedE").val().toString().length <= 9) {
                var regExpNumbers = /^[0-9.]+$/;
                if (regExpNumbers.test($("#txtAmtSchedE").val().toString())) {
                    var strAmount = $("#txtAmtSchedE").val().toString();
                    var indexAmount = strAmount.indexOf(".");
                    if (indexAmount != -1) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmtSchedE").val().toString()).toFixed(2);
                            $("#txtAmtSchedE").val(amountFloat);
                        }
                    }
                    else {
                        var amountFloat = parseFloat($("#txtAmtSchedE").val().toString()).toFixed(2);
                        $("#txtAmtSchedE").val(amountFloat);
                    }
                }
            }
            else {
                var strAmount = $("#txtAmtSchedE").val().toString();
                var indexAmount = strAmount.indexOf(".");
                var varPeriod = strAmount.indexOf(".");
                var newStrAmount = strAmount.substr(0, varPeriod);
                if (indexAmount != -1) {
                    if (newStrAmount.length <= 9) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmtSchedE").val().toString()).toFixed(2);
                            $("#txtAmtSchedE").val(amountFloat);
                        }
                    }
                }
            }
            $("#txtAmtSchedE").removeClass("watermarkHTMLTextBox");
        }
        else {
            $("#txtAmtSchedE").addClass("watermarkHTMLTextBox");
        }
    });

    $("#txtAmtSchedN").focusout(function () {
        if ($("#txtAmtSchedN").val().toString() != "") {
            if ($("#txtAmtSchedN").val().toString().length <= 9) {
                var regExpNumbers = /^[0-9.]+$/;
                if (regExpNumbers.test($("#txtAmtSchedN").val().toString())) {
                    var strAmount = $("#txtAmtSchedN").val().toString();
                    var indexAmount = strAmount.indexOf(".");
                    if (indexAmount != -1) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmtSchedN").val().toString()).toFixed(2);
                            $("#txtAmtSchedN").val(amountFloat);
                        }
                    }
                    else {
                        var amountFloat = parseFloat($("#txtAmtSchedN").val().toString()).toFixed(2);
                        $("#txtAmtSchedN").val(amountFloat);
                    }
                }
            }
            else {
                var strAmount = $("#txtAmtSchedN").val().toString();
                var indexAmount = strAmount.indexOf(".");
                var varPeriod = strAmount.indexOf(".");
                var newStrAmount = strAmount.substr(0, varPeriod);
                if (indexAmount != -1) {
                    if (newStrAmount.length <= 9) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmtSchedN").val().toString()).toFixed(2);
                            $("#txtAmtSchedN").val(amountFloat);
                        }
                    }
                }
            }
            $("#txtAmtSchedN").removeClass("watermarkHTMLTextBox");
        }
        else {
            $("#txtAmtSchedN").addClass("watermarkHTMLTextBox");
        }
    });

    $("#txtAmtSchedP").focusout(function () {
        if ($("#txtAmtSchedP").val().toString() != "") {
            if ($("#txtAmtSchedP").val().toString().length <= 9) {
                var regExpNumbers = /^[0-9.]+$/;
                if (regExpNumbers.test($("#txtAmtSchedP").val().toString())) {
                    var strAmount = $("#txtAmtSchedP").val().toString();
                    var indexAmount = strAmount.indexOf(".");
                    if (indexAmount != -1) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmtSchedP").val().toString()).toFixed(2);
                            $("#txtAmtSchedP").val(amountFloat);
                        }
                    }
                    else {
                        var amountFloat = parseFloat($("#txtAmtSchedP").val().toString()).toFixed(2);
                        $("#txtAmtSchedP").val(amountFloat);
                    }
                }
            }
            else {
                var strAmount = $("#txtAmtSchedP").val().toString();
                var indexAmount = strAmount.indexOf(".");
                var varPeriod = strAmount.indexOf(".");
                var newStrAmount = strAmount.substr(0, varPeriod);
                if (indexAmount != -1) {
                    if (newStrAmount.length <= 9) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmtSchedP").val().toString()).toFixed(2);
                            $("#txtAmtSchedP").val(amountFloat);
                        }
                    }
                }
            }
            $("#txtAmtSchedP").removeClass("watermarkHTMLTextBox");
        }
        else {
            $("#txtAmtSchedP").addClass("watermarkHTMLTextBox");
        }
    });

    $("#txtAmtSchedQ").focusout(function () {
        if ($("#txtAmtSchedQ").val().toString() != "") {
            if ($("#txtAmtSchedQ").val().toString().length <= 9) {
                var regExpNumbers = /^[0-9.]+$/;
                if (regExpNumbers.test($("#txtAmtSchedQ").val().toString())) {
                    var strAmount = $("#txtAmtSchedQ").val().toString();
                    var indexAmount = strAmount.indexOf(".");
                    if (indexAmount != -1) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmtSchedQ").val().toString()).toFixed(2);
                            $("#txtAmtSchedQ").val(amountFloat);
                        }
                    }
                    else {
                        var amountFloat = parseFloat($("#txtAmtSchedQ").val().toString()).toFixed(2);
                        $("#txtAmtSchedQ").val(amountFloat);
                    }
                }
            }
            else {
                var strAmount = $("#txtAmtSchedQ").val().toString();
                var indexAmount = strAmount.indexOf(".");
                var varPeriod = strAmount.indexOf(".");
                var newStrAmount = strAmount.substr(0, varPeriod);
                if (indexAmount != -1) {
                    if (newStrAmount.length <= 9) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmtSchedQ").val().toString()).toFixed(2);
                            $("#txtAmtSchedQ").val(amountFloat);
                        }
                    }
                }
            }
            $("#txtAmtSchedQ").removeClass("watermarkHTMLTextBox");
        }
        else {
            $("#txtAmtSchedQ").addClass("watermarkHTMLTextBox");
        }
    });

    $("#txtPartAmt").focusout(function () {
        if ($("#txtPartAmt").val().toString() != "") {
            if ($("#txtPartAmt").val().toString().length <= 9) {
                var regExpNumbers = /^[0-9.]+$/;
                if (regExpNumbers.test($("#txtPartAmt").val().toString())) {
                    var strAmount = $("#txtPartAmt").val().toString();
                    var indexAmount = strAmount.indexOf(".");
                    if (indexAmount != -1) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtPartAmt").val().toString()).toFixed(2);
                            $("#txtPartAmt").val(amountFloat);
                        }
                    }
                    else {
                        var amountFloat = parseFloat($("#txtPartAmt").val().toString()).toFixed(2);
                        $("#txtPartAmt").val(amountFloat);
                    }
                }
            }
            else {
                var strAmount = $("#txtPartAmt").val().toString();
                var indexAmount = strAmount.indexOf(".");
                var varPeriod = strAmount.indexOf(".");
                var newStrAmount = strAmount.substr(0, varPeriod);
                if (indexAmount != -1) {
                    if (newStrAmount.length <= 9) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtPartAmt").val().toString()).toFixed(2);
                            $("#txtPartAmt").val(amountFloat);
                        }
                    }
                }
            }
            $("#txtPartAmt").removeClass("watermarkHTMLTextBox");
        }
        else {
            $("#txtPartAmt").addClass("watermarkHTMLTextBox");
        }
    });

    $("#txtPartAmtAC").focusout(function () {
        if ($("#txtPartAmtAC").val().toString() != "") {
            if ($("#txtPartAmtAC").val().toString().length <= 9) {
                var regExpNumbers = /^[0-9.]+$/;
                if (regExpNumbers.test($("#txtPartAmtAC").val().toString())) {
                    var strAmount = $("#txtPartAmtAC").val().toString();
                    var indexAmount = strAmount.indexOf(".");
                    if (indexAmount != -1) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtPartAmtAC").val().toString()).toFixed(2);
                            $("#txtPartAmtAC").val(amountFloat);
                        }
                    }
                    else {
                        var amountFloat = parseFloat($("#txtPartAmtAC").val().toString()).toFixed(2);
                        $("#txtPartAmtAC").val(amountFloat);
                    }
                }
            }
            else {
                var strAmount = $("#txtPartAmtAC").val().toString();
                var indexAmount = strAmount.indexOf(".");
                var varPeriod = strAmount.indexOf(".");
                var newStrAmount = strAmount.substr(0, varPeriod);
                if (indexAmount != -1) {
                    if (newStrAmount.length <= 9) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtPartAmtAC").val().toString()).toFixed(2);
                            $("#txtPartAmtAC").val(amountFloat);
                        }
                    }
                }
            }
            $("#txtPartAmtAC").removeClass("watermarkHTMLTextBox");
        }
        else {
            $("#txtPartAmtAC").addClass("watermarkHTMLTextBox");
        }
    });

    $("#txtPartAmtSchedD").focusout(function () {
        if ($("#txtPartAmtSchedD").val().toString() != "") {
            if ($("#txtPartAmtSchedD").val().toString().length <= 9) {
                var regExpNumbers = /^[0-9.]+$/;
                if (regExpNumbers.test($("#txtPartAmtSchedD").val().toString())) {
                    var strAmount = $("#txtPartAmtSchedD").val().toString();
                    var indexAmount = strAmount.indexOf(".");
                    if (indexAmount != -1) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtPartAmtSchedD").val().toString()).toFixed(2);
                            $("#txtPartAmtSchedD").val(amountFloat);
                        }
                    }
                    else {
                        var amountFloat = parseFloat($("#txtPartAmtSchedD").val().toString()).toFixed(2);
                        $("#txtPartAmtSchedD").val(amountFloat);
                    }
                }
            }
            else {
                var strAmount = $("#txtPartAmtSchedD").val().toString();
                var indexAmount = strAmount.indexOf(".");
                var varPeriod = strAmount.indexOf(".");
                var newStrAmount = strAmount.substr(0, varPeriod);
                if (indexAmount != -1) {
                    if (newStrAmount.length <= 9) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtPartAmtSchedD").val().toString()).toFixed(2);
                            $("#txtPartAmtSchedD").val(amountFloat);
                        }
                    }
                }
            }
            $("#txtPartAmtSchedD").removeClass("watermarkHTMLTextBox");
        }
        else {
            $("#txtPartAmtSchedD").addClass("watermarkHTMLTextBox");
        }
    });

    $("#txtPartAmtSchedF").focusout(function () {
        if ($("#txtPartAmtSchedF").val().toString() != "") {
            if ($("#txtPartAmtSchedF").val().toString().length <= 9) {
                var regExpNumbers = /^[0-9.]+$/;
                if (regExpNumbers.test($("#txtPartAmtSchedF").val().toString())) {
                    var strAmount = $("#txtPartAmtSchedF").val().toString();
                    var indexAmount = strAmount.indexOf(".");
                    if (indexAmount != -1) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtPartAmtSchedF").val().toString()).toFixed(2);
                            $("#txtPartAmtSchedF").val(amountFloat);
                        }
                    }
                    else {
                        var amountFloat = parseFloat($("#txtPartAmtSchedF").val().toString()).toFixed(2);
                        $("#txtPartAmtSchedF").val(amountFloat);
                    }
                }
            }
            else {
                var strAmount = $("#txtPartAmtSchedF").val().toString();
                var indexAmount = strAmount.indexOf(".");
                var varPeriod = strAmount.indexOf(".");
                var newStrAmount = strAmount.substr(0, varPeriod);
                if (indexAmount != -1) {
                    if (newStrAmount.length <= 9) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtPartAmtSchedF").val().toString()).toFixed(2);
                            $("#txtPartAmtSchedF").val(amountFloat);
                        }
                    }
                }
            }
            $("#txtPartAmtSchedF").removeClass("watermarkHTMLTextBox");
        }
        else {
            $("#txtPartAmtSchedF").addClass("watermarkHTMLTextBox");
        }
    });

    $("#txtPartAmtSchedP").focusout(function () {
        if ($("#txtPartAmtSchedP").val().toString() != "") {
            if ($("#txtPartAmtSchedP").val().toString().length <= 9) {
                var regExpNumbers = /^[0-9.]+$/;
                if (regExpNumbers.test($("#txtPartAmtSchedP").val().toString())) {
                    var strAmount = $("#txtPartAmtSchedP").val().toString();
                    var indexAmount = strAmount.indexOf(".");
                    if (indexAmount != -1) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtPartAmtSchedP").val().toString()).toFixed(2);
                            $("#txtPartAmtSchedP").val(amountFloat);
                        }
                    }
                    else {
                        var amountFloat = parseFloat($("#txtPartAmtSchedP").val().toString()).toFixed(2);
                        $("#txtPartAmtSchedP").val(amountFloat);
                    }
                }
            }
            else {
                var strAmount = $("#txtPartAmtSchedP").val().toString();
                var indexAmount = strAmount.indexOf(".");
                var varPeriod = strAmount.indexOf(".");
                var newStrAmount = strAmount.substr(0, varPeriod);
                if (indexAmount != -1) {
                    if (newStrAmount.length <= 9) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtPartAmtSchedP").val().toString()).toFixed(2);
                            $("#txtPartAmtSchedP").val(amountFloat);
                        }
                    }
                }
            }
            $("#txtPartAmtSchedP").removeClass("watermarkHTMLTextBox");
        }
        else {
            $("#txtPartAmtSchedP").addClass("watermarkHTMLTextBox");
        }
    });

    $("#txtAmtReim").focusout(function () {
        if ($("#txtAmtReim").val().toString() != "") {
            if ($("#txtAmtReim").val().toString().length <= 9) {
                var regExpNumbers = /^[0-9.]+$/;
                if (regExpNumbers.test($("#txtAmtReim").val().toString())) {
                    var strAmount = $("#txtAmtReim").val().toString();
                    var indexAmount = strAmount.indexOf(".");
                    if (indexAmount != -1) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmtReim").val().toString()).toFixed(2);
                            $("#txtAmtReim").val(amountFloat);
                        }
                    }
                    else {
                        var amountFloat = parseFloat($("#txtAmtReim").val().toString()).toFixed(2);
                        $("#txtAmtReim").val(amountFloat);
                    }
                }
            }
            else {
                var strAmount = $("#txtAmtReim").val().toString();
                var indexAmount = strAmount.indexOf(".");
                var varPeriod = strAmount.indexOf(".");
                var newStrAmount = strAmount.substr(0, varPeriod);
                if (indexAmount != -1) {
                    if (newStrAmount.length <= 9) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmtReim").val().toString()).toFixed(2);
                            $("#txtAmtReim").val(amountFloat);
                        }
                    }
                }
            }
            $("#txtAmtReim").removeClass("watermarkHTMLTextBox");
        }
        else {
            $("#txtAmtReim").addClass("watermarkHTMLTextBox");
        }
    });


    $("#txtAmountCCI").focusout(function () {
        if ($("#txtAmountCCI").val().toString() != "") {
            if ($("#txtAmountCCI").val().toString().length <= 9) {
                var regExpNumbers = /^[0-9.]+$/;
                if (regExpNumbers.test($("#txtAmountCCI").val().toString())) {
                    var strAmount = $("#txtAmountCCI").val().toString();
                    var indexAmount = strAmount.indexOf(".");
                    if (indexAmount != -1) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmountCCI").val().toString()).toFixed(2);
                            $("#txtAmountCCI").val(amountFloat);
                        }
                    }
                    else {
                        var amountFloat = parseFloat($("#txtAmountCCI").val().toString()).toFixed(2);
                        $("#txtAmountCCI").val(amountFloat);
                    }
                }
            }
            else {
                var strAmount = $("#txtAmountCCI").val().toString();
                var indexAmount = strAmount.indexOf(".");
                var varPeriod = strAmount.indexOf(".");
                var newStrAmount = strAmount.substr(0, varPeriod);
                if (indexAmount != -1) {
                    if (newStrAmount.length <= 9) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmountCCI").val().toString()).toFixed(2);
                            $("#txtAmountCCI").val(amountFloat);
                        }
                    }
                }
            }
            $("#txtAmountCCI").removeClass("watermarkHTMLTextBox");
        }
        else {
            $("#txtAmountCCI").addClass("watermarkHTMLTextBox");
        }
    });

    $("#txtAmountRefunded").focusout(function () {
        if ($("#txtAmountRefunded").val().toString() != "") {
            if ($("#txtAmountRefunded").val().toString().length <= 9) {
                var regExpNumbers = /^[0-9.]+$/;
                if (regExpNumbers.test($("#txtAmountRefunded").val().toString())) {
                    var strAmount = $("#txtAmountRefunded").val().toString();
                    var indexAmount = strAmount.indexOf(".");
                    if (indexAmount != -1) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmountRefunded").val().toString()).toFixed(2);
                            $("#txtAmountRefunded").val(amountFloat);
                        }
                    }
                    else {
                        var amountFloat = parseFloat($("#txtAmountRefunded").val().toString()).toFixed(2);
                        $("#txtAmountRefunded").val(amountFloat);
                    }
                }
            }
            else {
                var strAmount = $("#txtAmountRefunded").val().toString();
                var indexAmount = strAmount.indexOf(".");
                var varPeriod = strAmount.indexOf(".");
                var newStrAmount = strAmount.substr(0, varPeriod);
                if (indexAmount != -1) {
                    if (newStrAmount.length <= 9) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmountRefunded").val().toString()).toFixed(2);
                            $("#txtAmountRefunded").val(amountFloat);
                        }
                    }
                }
            }
            $("#txtAmountRefunded").removeClass("watermarkHTMLTextBox");
        }
        else {
            $("#txtAmountRefunded").addClass("watermarkHTMLTextBox");
        }
    });

    $("#txtOriginalAmount").focusout(function () {
        if ($("#txtOriginalAmount").val().toString() != "") {
            if ($("#txtOriginalAmount").val().toString().length <= 9) {
                var regExpNumbers = /^[0-9.]+$/;
                if (regExpNumbers.test($("#txtOriginalAmount").val().toString())) {
                    var strAmount = $("#txtOriginalAmount").val().toString();
                    var indexAmount = strAmount.indexOf(".");
                    if (indexAmount != -1) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtOriginalAmount").val().toString()).toFixed(2);
                            $("#txtOriginalAmount").val(amountFloat);
                        }
                    }
                    else {
                        var amountFloat = parseFloat($("#txtOriginalAmount").val().toString()).toFixed(2);
                        $("#txtOriginalAmount").val(amountFloat);
                    }
                }
            }
            else {
                var strAmount = $("#txtOriginalAmount").val().toString();
                var indexAmount = strAmount.indexOf(".");
                var varPeriod = strAmount.indexOf(".");
                var newStrAmount = strAmount.substr(0, varPeriod);
                if (indexAmount != -1) {
                    if (newStrAmount.length <= 9) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtOriginalAmount").val().toString()).toFixed(2);
                            $("#txtOriginalAmount").val(amountFloat);
                        }
                    }
                }
            }
            $("#txtOriginalAmount").removeClass("watermarkHTMLTextBox");
        }
        else {
            $("#txtOriginalAmount").addClass("watermarkHTMLTextBox");
        }
    });

    $("#txtAmtExpenditurePayments").focusout(function () {
        if ($("#txtAmtExpenditurePayments").val().toString() != "") {
            if ($("#txtAmtExpenditurePayments").val().toString().length <= 9) {
                var regExpNumbers = /^[0-9.]+$/;
                if (regExpNumbers.test($("#txtAmtExpenditurePayments").val().toString())) {
                    var strAmount = $("#txtAmtExpenditurePayments").val().toString();
                    var indexAmount = strAmount.indexOf(".");
                    if (indexAmount != -1) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmtExpenditurePayments").val().toString()).toFixed(2);
                            $("#txtAmtExpenditurePayments").val(amountFloat);
                        }
                    }
                    else {
                        var amountFloat = parseFloat($("#txtAmtExpenditurePayments").val().toString()).toFixed(2);
                        $("#txtAmtExpenditurePayments").val(amountFloat);
                    }
                }
            }
            else {
                var strAmount = $("#txtAmtExpenditurePayments").val().toString();
                var indexAmount = strAmount.indexOf(".");
                var varPeriod = strAmount.indexOf(".");
                var newStrAmount = strAmount.substr(0, varPeriod);
                if (indexAmount != -1) {
                    if (newStrAmount.length <= 9) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmtExpenditurePayments").val().toString()).toFixed(2);
                            $("#txtAmtExpenditurePayments").val(amountFloat);
                        }
                    }
                }
            }
            $("#txtAmtExpenditurePayments").removeClass("watermarkHTMLTextBox");
        }
        else {
            $("#txtAmtExpenditurePayments").addClass("watermarkHTMLTextBox");
        }
    });

    $("#txtAmt24HNotice").focusout(function () {
        if ($("#txtAmt24HNotice").val().toString() != "") {
            if ($("#txtAmt24HNotice").val().toString().length <= 9) {
                var regExpNumbers = /^[0-9.]+$/;
                if (regExpNumbers.test($("#txtAmt24HNotice").val().toString())) {
                    var strAmount = $("#txtAmt24HNotice").val().toString();
                    var indexAmount = strAmount.indexOf(".");
                    if (indexAmount != -1) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmt24HNotice").val().toString()).toFixed(2);
                            $("#txtAmt24HNotice").val(amountFloat);
                        }
                    }
                    else {
                        var amountFloat = parseFloat($("#txtAmt24HNotice").val().toString()).toFixed(2);
                        $("#txtAmt24HNotice").val(amountFloat);
                    }
                }
            }
            else {
                var strAmount = $("#txtAmt24HNotice").val().toString();
                var indexAmount = strAmount.indexOf(".");
                var varPeriod = strAmount.indexOf(".");
                var newStrAmount = strAmount.substr(0, varPeriod);
                if (indexAmount != -1) {
                    if (newStrAmount.length <= 9) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmt24HNotice").val().toString()).toFixed(2);
                            $("#txtAmt24HNotice").val(amountFloat);
                        }
                    }
                }
            }
            $("#txtAmt24HNotice").removeClass("watermarkHTMLTextBox");
        }
        else {
            $("#txtAmt24HNotice").addClass("watermarkHTMLTextBox");
        }
    });

    $("#txtAmtIEWeeklyContr").focusout(function () {
        if ($("#txtAmtIEWeeklyContr").val().toString() != "") {
            if ($("#txtAmtIEWeeklyContr").val().toString().length <= 9) {
                var regExpNumbers = /^[0-9.]+$/;
                if (regExpNumbers.test($("#txtAmtIEWeeklyContr").val().toString())) {
                    var strAmount = $("#txtAmtIEWeeklyContr").val().toString();
                    var indexAmount = strAmount.indexOf(".");
                    if (indexAmount != -1) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmtIEWeeklyContr").val().toString()).toFixed(2);
                            $("#txtAmtIEWeeklyContr").val(amountFloat);
                        }
                    }
                    else {
                        var amountFloat = parseFloat($("#txtAmtIEWeeklyContr").val().toString()).toFixed(2);
                        $("#txtAmtIEWeeklyContr").val(amountFloat);
                    }
                }
            }
            else {
                var strAmount = $("#txtAmtIEWeeklyContr").val().toString();
                var indexAmount = strAmount.indexOf(".");
                var varPeriod = strAmount.indexOf(".");
                var newStrAmount = strAmount.substr(0, varPeriod);
                if (indexAmount != -1) {
                    if (newStrAmount.length <= 9) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmtIEWeeklyContr").val().toString()).toFixed(2);
                            $("#txtAmtIEWeeklyContr").val(amountFloat);
                        }
                    }
                }
            }
            $("#txtAmtIEWeeklyContr").removeClass("watermarkHTMLTextBox");
        }
        else {
            $("#txtAmtIEWeeklyContr").addClass("watermarkHTMLTextBox");
        }
    });

    $("#txtAmtIEWeeklyExpenditure").focusout(function () {
        if ($("#txtAmtIEWeeklyExpenditure").val().toString() != "") {
            if ($("#txtAmtIEWeeklyExpenditure").val().toString().length <= 9) {
                var regExpNumbers = /^[0-9.]+$/;
                if (regExpNumbers.test($("#txtAmtIEWeeklyExpenditure").val().toString())) {
                    var strAmount = $("#txtAmtIEWeeklyExpenditure").val().toString();
                    var indexAmount = strAmount.indexOf(".");
                    if (indexAmount != -1) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmtIEWeeklyExpenditure").val().toString()).toFixed(2);
                            $("#txtAmtIEWeeklyExpenditure").val(amountFloat);
                        }
                    }
                    else {
                        var amountFloat = parseFloat($("#txtAmtIEWeeklyExpenditure").val().toString()).toFixed(2);
                        $("#txtAmtIEWeeklyExpenditure").val(amountFloat);
                    }
                }
            }
            else {
                var strAmount = $("#txtAmtIEWeeklyExpenditure").val().toString();
                var indexAmount = strAmount.indexOf(".");
                var varPeriod = strAmount.indexOf(".");
                var newStrAmount = strAmount.substr(0, varPeriod);
                if (indexAmount != -1) {
                    if (newStrAmount.length <= 9) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmtIEWeeklyExpenditure").val().toString()).toFixed(2);
                            $("#txtAmtIEWeeklyExpenditure").val(amountFloat);
                        }
                    }
                }
            }
            $("#txtAmtIEWeeklyExpenditure").removeClass("watermarkHTMLTextBox");
        }
        else {
            $("#txtAmtIEWeeklyExpenditure").addClass("watermarkHTMLTextBox");
        }
    });

    $("#txtAmtIEWeeklyPIDAExpenditure").focusout(function () {

        if ($("#txtAmtIEWeeklyPIDAExpenditure").val().toString() != "") {
            if ($("#txtAmtIEWeeklyPIDAExpenditure").val().toString().length <= 9) {
                var regExpNumbers = /^[0-9.]+$/;
                if (regExpNumbers.test($("#txtAmtIEWeeklyPIDAExpenditure").val().toString())) {
                    var strAmount = $("#txtAmtIEWeeklyPIDAExpenditure").val().toString();
                    var indexAmount = strAmount.indexOf(".");
                    if (indexAmount != -1) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmtIEWeeklyPIDAExpenditure").val().toString()).toFixed(2);
                            $("#txtAmtIEWeeklyPIDAExpenditure").val(amountFloat);
                        }
                    }
                    else {
                        var amountFloat = parseFloat($("#txtAmtIEWeeklyPIDAExpenditure").val().toString()).toFixed(2);
                        $("#txtAmtIEWeeklyPIDAExpenditure").val(amountFloat);
                    }
                }
            }
            else {
                var strAmount = $("#txtAmtIEWeeklyPIDAExpenditure").val().toString();
                var indexAmount = strAmount.indexOf(".");
                var varPeriod = strAmount.indexOf(".");
                var newStrAmount = strAmount.substr(0, varPeriod);
                if (indexAmount != -1) {
                    if (newStrAmount.length <= 9) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmtIEWeeklyPIDAExpenditure").val().toString()).toFixed(2);
                            $("#txtAmtIEWeeklyPIDAExpenditure").val(amountFloat);
                        }
                    }
                }
            }
            $("#txtAmtIEWeeklyPIDAExpenditure").removeClass("watermarkHTMLTextBox");
        }
        else {
            $("#txtAmtIEWeeklyPIDAExpenditure").addClass("watermarkHTMLTextBox");
        }
    });

    $("#txtAmtIE24HrPIDAExpenditure").focusout(function () {

        if ($("#txtAmtIE24HrPIDAExpenditure").val().toString() != "") {
            if ($("#txtAmtIE24HrPIDAExpenditure").val().toString().length <= 9) {
                var regExpNumbers = /^[0-9.]+$/;
                if (regExpNumbers.test($("#txtAmtIE24HrPIDAExpenditure").val().toString())) {
                    var strAmount = $("#txtAmtIE24HrPIDAExpenditure").val().toString();
                    var indexAmount = strAmount.indexOf(".");
                    if (indexAmount != -1) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmtIE24HrPIDAExpenditure").val().toString()).toFixed(2);
                            $("#txtAmtIE24HrPIDAExpenditure").val(amountFloat);
                        }
                    }
                    else {
                        var amountFloat = parseFloat($("#txtAmtIE24HrPIDAExpenditure").val().toString()).toFixed(2);
                        $("#txtAmtIE24HrPIDAExpenditure").val(amountFloat);
                    }
                }
            }
            else {
                var strAmount = $("#txtAmtIE24HrPIDAExpenditure").val().toString();
                var indexAmount = strAmount.indexOf(".");
                var varPeriod = strAmount.indexOf(".");
                var newStrAmount = strAmount.substr(0, varPeriod);
                if (indexAmount != -1) {
                    if (newStrAmount.length <= 9) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtAmtIE24HrPIDAExpenditure").val().toString()).toFixed(2);
                            $("#txtAmtIE24HrPIDAExpenditure").val(amountFloat);
                        }
                    }
                }
            }
            $("#txtAmtIE24HrPIDAExpenditure").removeClass("watermarkHTMLTextBox");
        }
        else {
            $("#txtAmtIE24HrPIDAExpenditure").addClass("watermarkHTMLTextBox");
        }
    });

    $("#txtOriginalAmountShedF").focusout(function () {

        if ($("#txtOriginalAmountShedF").val().toString() != "") {
            if ($("#txtOriginalAmountShedF").val().toString().length <= 9) {
                var regExpNumbers = /^[0-9.]+$/;
                if (regExpNumbers.test($("#txtOriginalAmountShedF").val().toString())) {
                    var strAmount = $("#txtOriginalAmountShedF").val().toString();
                    var indexAmount = strAmount.indexOf(".");
                    if (indexAmount != -1) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtOriginalAmountShedF").val().toString()).toFixed(2);
                            $("#txtOriginalAmountShedF").val(amountFloat);
                        }
                    }
                    else {
                        var amountFloat = parseFloat($("#txtOriginalAmountShedF").val().toString()).toFixed(2);
                        $("#txtOriginalAmountShedF").val(amountFloat);
                    }
                }
            }
            else {
                var strAmount = $("#txtOriginalAmountShedF").val().toString();
                var indexAmount = strAmount.indexOf(".");
                var varPeriod = strAmount.indexOf(".");
                var newStrAmount = strAmount.substr(0, varPeriod);
                if (indexAmount != -1) {
                    if (newStrAmount.length <= 9) {
                        var amountDecimal = strAmount.substr(indexAmount + 1, strAmount.length);
                        if (amountDecimal.toString().length == "1" || amountDecimal.toString().length == "2") {
                            var amountFloat = parseFloat($("#txtOriginalAmountShedF").val().toString()).toFixed(2);
                            $("#txtOriginalAmountShedF").val(amountFloat);
                        }
                    }
                }
            }
            $("#txtOriginalAmountShedF").removeClass("watermarkHTMLTextBox");
        }
        else {
            $("#txtOriginalAmountShedF").addClass("watermarkHTMLTextBox");
        }
    });

    // JQUERY VALIDATITON REGULAR EXPRESSIONS.
    //----------------------------------------------------------------------------------------------------------------------------------------------

    // ZIP CODE VALIDATOR
    $m.validator.addMethod("FomatZipcode", function (value, element) {
        if ($("#txtZipCode").val().toString() != "") {
            if ($('#chkCountry').is(':checked') == false) {
                return this.optional(element) || /(^\d{5}$)|(^\d{5}-\d{4}$)/.test(value);
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }

    });

    // ZIP CODE VALIDATOR
    $m.validator.addMethod("FomatZipcodeCont", function (value, element) {
        if ($("#txtContZipCode").val().toString() != "") {
            return this.optional(element) || /(^\d{5}$)|(^\d{5}-\d{4}$)/.test(value);
        }
        else {
            return true;
        }
    });

    $m.validator.addMethod("FomatZipcodeSchedF", function (value, element) {
        if ($("#txtZipCodeShedF").val().toString() != "") {
            if ($('#chkCountry').is(':checked') == false) {
                return this.optional(element) || /(^\d{5}$)|(^\d{5}-\d{4}$)/.test(value);
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }

    });

    // ZIP CODE TREASURER VALIDATOR
    $m.validator.addMethod("FomatZipcodeTreasurer", function (value, element) {
        if ($("#txtZipCodeTreasurer").val().toString() != "") {
            return this.optional(element) || /(^\d{5}$)|(^\d{5}-\d{4}$)/.test(value);
        }
        else {
            return true;
        }

    });

    $m.validator.addMethod("FomatZipcodeReim", function (value, element) {
        if ($("#txtZipCodeReim").val().toString() != "") {
            if ($('#chkCountryReim').is(':checked') == false) {
                return this.optional(element) || /(^\d{5}$)|(^\d{5}-\d{4}$)/.test(value);
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    $m.validator.addMethod("FomatZipcodeCCI", function (value, element) {
        if ($("#txtZipCodeCCI").val().toString() != "") {
            if ($('#chkCountryCCI').is(':checked') == false) {
                return this.optional(element) || /(^\d{5}$)|(^\d{5}-\d{4}$)/.test(value);
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    $m.validator.addMethod("FomatZipcodePart", function (value, element) {
        if ($("#txtPartZip5").val().toString() != "") {
            if ($('#chkCountryPartnership').is(':checked') == false) {
                return this.optional(element) || /(^\d{5}$)|(^\d{5}-\d{4}$)/.test(value);
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // AMOUNT VALIDATOR
    //$m.validator.addMethod("AmountValidate", function (value, element) {
    //    return this.optional(element) || /^\d{1,9}$|^\d{1,9}-$|^\d{1,9}.\d{2}$|^d{0,12}$/.test(value);
    //}, "Valid Amount");

    $m.validator.addMethod("AmountValidateForSchedR", function (value, element) {
        //return this.optional(element) || /^\d{0,9}\.\d{0,2}$|^\d{0,12}$/.test(value);
        return this.optional(element) || /^(-{1}?(?:([0-9]{0,10}))|([0-9]{1})?(?:([0-9]{0,9})))?(?:\.([0-9]{0,2}))?$/.test(value);
    });

    $m.validator.addMethod("AmountValidate", function (value, element) {
        return this.optional(element) || /^\d{0,9}\.\d{0,2}$|^\d{0,12}$/.test(value);
    });

    $m.validator.addMethod("AmountValidatePart", function (value, element) {
        return this.optional(element) || /^\d{0,9}\.\d{0,2}$|^\d{0,12}$/.test(value);
    });

    $m.validator.addMethod("AmountValidateReim", function (value, element) {
        return this.optional(element) || /^\d{0,9}\.\d{0,2}$|^\d{0,12}$/.test(value);
    });

    $m.validator.addMethod("AmountValidateCCI", function (value, element) {
        return this.optional(element) || /^\d{0,9}\.\d{0,2}$|^\d{0,12}$/.test(value);
    });

    // VALIDATING SPACES IN ADDRESS.
    $m.validator.addMethod("ValidateSpaces", function (value, element) {        
        return this.optional(element) || /^\s*$/.test(value);
    });
    //"^\s*$"

    // AMOUNT MAX 12 VALIDATION
    $m.validator.addMethod("Amount12DigitValSchedR", function (value, element) {
        if ($("#txtAmtExpensesAllocation").val().toString() != "") {
            var varAmount = $("#txtAmtExpensesAllocation").val().toString();            
            var valAmount = 9;
            if (varAmount.indexOf('-') > -1) {
                valAmount = 10;
                if (parseInt(varAmount.length) > parseInt(valAmount)) {
                    if (varAmount.indexOf('.') > -1) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    return true;
                }
            }
            else {
                valAmount = 9;
                if (parseInt(varAmount.length) > parseInt(valAmount)) {
                    if (varAmount.indexOf('.') > -1) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    return true;
                }
            }
        }
        else {
            return false;
        }
    });

    // AMOUNT MAX 12 VALIDATION
    $m.validator.addMethod("Amount12DigitVal", function (value, element) {
        if ($("#txtAmt").val().toString() != "") {
            var varAmount = $("#txtAmt").val().toString();
            var valAmount = 9;
            if (parseInt(varAmount.length) > parseInt(valAmount)) {
                if (varAmount.indexOf('.') > -1) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    });

    // AMOUNT MAX 12 VALIDATION
    $m.validator.addMethod("Amount12DigitValABC", function (value, element) {
        if ($("#txtAmtABC").val().toString() != "") {
            var varAmount = $("#txtAmtABC").val().toString();
            var valAmount = 9;
            if (parseInt(varAmount.length) > parseInt(valAmount)) {
                if (varAmount.indexOf('.') > -1) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    });

    // AMOUNT MAX 12 VALIDATION
    $m.validator.addMethod("Amount12DigitValD", function (value, element) {
        if ($("#txtAmtSchedD").val().toString() != "") {
            var varAmount = $("#txtAmtSchedD").val().toString();
            var valAmount = 9;
            if (parseInt(varAmount.length) > parseInt(valAmount)) {
                if (varAmount.indexOf('.') > -1) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    });

    // AMOUNT MAX 12 VALIDATION
    $m.validator.addMethod("Amount12DigitValN", function (value, element) {
        if ($("#txtAmtSchedN").val().toString() != "") {
            var varAmount = $("#txtAmtSchedN").val().toString();
            var valAmount = 9;
            if (parseInt(varAmount.length) > parseInt(valAmount)) {
                if (varAmount.indexOf('.') > -1) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    });

    // AMOUNT MAX 12 VALIDATION
    $m.validator.addMethod("Amount12DigitValP", function (value, element) {
        if ($("#txtAmtSchedP").val().toString() != "") {
            var varAmount = $("#txtAmtSchedP").val().toString();
            var valAmount = 9;
            if (parseInt(varAmount.length) > parseInt(valAmount)) {
                if (varAmount.indexOf('.') > -1) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    });

    // AMOUNT MAX 12 VALIDATION
    $m.validator.addMethod("Amount12DigitValQ", function (value, element) {
        if ($("#txtAmtSchedQ").val().toString() != "") {
            var varAmount = $("#txtAmtSchedQ").val().toString();
            var valAmount = 9;
            if (parseInt(varAmount.length) > parseInt(valAmount)) {
                if (varAmount.indexOf('.') > -1) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    });

    // AMOUNT MAX 12 VALIDATION
    $m.validator.addMethod("Amount12DigitValSchedE", function (value, element) {
        if ($("#txtAmtSchedE").val().toString() != "") {
            var varAmount = $("#txtAmtSchedE").val().toString();
            var valAmount = 9;
            if (parseInt(varAmount.length) > parseInt(valAmount)) {
                if (varAmount.indexOf('.') > -1) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    });

    // AMOUNT MAX 12 VALIDATION
    $m.validator.addMethod("Amount12DigitValSchedL", function (value, element) {
        if ($("#txtAmountRefunded").val().toString() != "") {
            var varAmount = $("#txtAmountRefunded").val().toString();
            var valAmount = 9;
            if (parseInt(varAmount.length) > parseInt(valAmount)) {
                if (varAmount.indexOf('.') > -1) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    });

    // AMOUNT MAX 12 VALIDATION
    $m.validator.addMethod("Amount12DigitValSchedF", function (value, element) {
        if ($("#txtOriginalAmount").val().toString() != "") {
            var varAmount = $("#txtOriginalAmount").val().toString();
            var valAmount = 9;
            if (parseInt(varAmount.length) > parseInt(valAmount)) {
                if (varAmount.indexOf('.') > -1) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    });

    // AMOUNT MAX 12 VALIDATION
    $m.validator.addMethod("Amount12DigitValSchedFAmt", function (value, element) {
        if ($("#txtAmtExpenditurePayments").val().toString() != "") {
            var varAmount = $("#txtAmtExpenditurePayments").val().toString();
            var valAmount = 9;
            if (parseInt(varAmount.length) > parseInt(valAmount)) {
                if (varAmount.indexOf('.') > -1) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    });

    // AMOUNT MAX 12 VALIDATION
    $m.validator.addMethod("Amount12DigitValSchedA24HNotice", function (value, element) {
        if ($("#txtAmt24HNotice").val().toString() != "") {
            var varAmount = $("#txtAmt24HNotice").val().toString();
            var valAmount = 9;
            if (parseInt(varAmount.length) > parseInt(valAmount)) {
                if (varAmount.indexOf('.') > -1) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    });

    // AMOUNT MAX 12 VALIDATION
    $m.validator.addMethod("Amount12DigitValSchedAIEWContr", function (value, element) {
        if ($("#txtAmtIEWeeklyContr").val().toString() != "") {
            var varAmount = $("#txtAmtIEWeeklyContr").val().toString();
            var valAmount = 9;
            if (parseInt(varAmount.length) > parseInt(valAmount)) {
                if (varAmount.indexOf('.') > -1) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    });

    // AMOUNT MAX 12 VALIDATION
    $m.validator.addMethod("Amount12DigitValSchedFIEWExp", function (value, element) {
        if ($("#txtAmtIEWeeklyExpenditure").val().toString() != "") {
            var varAmount = $("#txtAmtIEWeeklyExpenditure").val().toString();
            var valAmount = 9;
            if (parseInt(varAmount.length) > parseInt(valAmount)) {
                if (varAmount.indexOf('.') > -1) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    });

    // AMOUNT MAX 12 VALIDATION
    $m.validator.addMethod("Amount12DigitValSchedFIEWExpPIDA", function (value, element) {
        if ($("#txtAmtIEWeeklyPIDAExpenditure").val().toString() != "") {
            var varAmount = $("#txtAmtIEWeeklyPIDAExpenditure").val().toString();
            var valAmount = 9;
            if (parseInt(varAmount.length) > parseInt(valAmount)) {
                if (varAmount.indexOf('.') > -1) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    });

    // AMOUNT MAX 12 VALIDATION
    $m.validator.addMethod("Amount12DigitValSchedFIE24HrPIDA", function (value, element) {
        if ($("#txtAmtIE24HrPIDAExpenditure").val().toString() != "") {
            var varAmount = $("#txtAmtIE24HrPIDAExpenditure").val().toString();
            var valAmount = 9;
            if (parseInt(varAmount.length) > parseInt(valAmount)) {
                if (varAmount.indexOf('.') > -1) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    });

    // AMOUNT MAX 12 VALIDATION
    $m.validator.addMethod("AmountOriginalSchedKFVal", function (value, element) {
        if ($("#txtOriginalAmountShedF").val().toString() != "") {
            var varAmount = $("#txtOriginalAmountShedF").val().toString();
            var valAmount = 9;
            if (parseInt(varAmount.length) > parseInt(valAmount)) {
                if (varAmount.indexOf('.') > -1) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    });

    $m.validator.addMethod("Amount12DigitValPart", function (value, element) {
        if ($("#txtPartAmt").val().toString() != "") {
            var varAmount = $("#txtPartAmt").val().toString();
            var valAmount = 9;
            if (parseInt(varAmount.length) > parseInt(valAmount)) {
                if (varAmount.indexOf('.') > -1) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    });

    $m.validator.addMethod("Amount12DigitValPartAC", function (value, element) {
        if ($("#txtPartAmtAC").val().toString() != "") {
            var varAmount = $("#txtPartAmtAC").val().toString();
            var valAmount = 9;
            if (parseInt(varAmount.length) > parseInt(valAmount)) {
                if (varAmount.indexOf('.') > -1) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    });

    $m.validator.addMethod("Amount12DigitValPartD", function (value, element) {
        if ($("#txtPartAmtSchedD").val().toString() != "") {
            var varAmount = $("#txtPartAmtSchedD").val().toString();
            var valAmount = 9;
            if (parseInt(varAmount.length) > parseInt(valAmount)) {
                if (varAmount.indexOf('.') > -1) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    });

    $m.validator.addMethod("Amount12DigitValPartF", function (value, element) {
        if ($("#txtPartAmtSchedF").val().toString() != "") {
            var varAmount = $("#txtPartAmtSchedF").val().toString();
            var valAmount = 9;
            if (parseInt(varAmount.length) > parseInt(valAmount)) {
                if (varAmount.indexOf('.') > -1) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    });

    $m.validator.addMethod("Amount12DigitValPartP", function (value, element) {
        if ($("#txtPartAmtSchedP").val().toString() != "") {
            var varAmount = $("#txtPartAmtSchedP").val().toString();
            var valAmount = 9;
            if (parseInt(varAmount.length) > parseInt(valAmount)) {
                if (varAmount.indexOf('.') > -1) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    });

    $m.validator.addMethod("Amount12DigitValReim", function (value, element) {
        if ($("#txtAmtReim").val().toString() != "") {
            var varAmount = $("#txtAmtReim").val().toString();
            var valAmount = 9;
            if (parseInt(varAmount.length) > parseInt(valAmount)) {
                if (varAmount.indexOf('.') > -1) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    });

    $m.validator.addMethod("Amount12DigitValCCI", function (value, element) {
        if ($("#txtAmountCCI").val().toString() != "") {
            var varAmount = $("#txtAmountCCI").val().toString();
            var valAmount = 9;
            if (parseInt(varAmount.length) > parseInt(valAmount)) {
                if (varAmount.indexOf('.') > -1) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    });

    $m.validator.addMethod("Amount12DigitValCCISchedR", function (value, element) {
        if ($("#txtAmtExpensesAllocation").val().toString() != "") {
            var varAmount = $("#txtAmtExpensesAllocation").val().toString();
            var valAmount = 9;
            if (parseInt(varAmount.length) > parseInt(valAmount)) {
                if (varAmount.indexOf('.') > -1) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    });

    // Amount Zero Validation
    $m.validator.addMethod("AmountZeroVal", function (value, element) {
        if ($("#txtAmt").val().toString() != "") {
            var amountVal = $("#txtAmt").val().toString();
            var valAmount = parseFloat("1");
            if (parseFloat(amountVal) < valAmount) {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Amount Zero Validation
    $m.validator.addMethod("AmountZeroValSchedABC", function (value, element) {
        if ($("#txtAmtABC").val().toString() != "") {
            var amountVal = $("#txtAmtABC").val().toString();
            //var valAmount = parseFloat("1");
            //if (parseFloat(amountVal) < valAmount) {
            if (amountVal == "0.00" || amountVal == "0.0" || amountVal == "0" || amountVal == ".0" || amountVal == ".00") {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Amout Zero Validation - G, H, I, J, K, L, M, O, R
    $m.validator.addMethod("AmountZeroValtxtAmt", function (value, element) {
        if ($("#txtAmt").val().toString() != "") {
            var amountVal = $("#txtAmt").val().toString();
            //var valAmount = parseFloat("1");
            //if (parseFloat(amountVal) < valAmount) {
            if (amountVal == "0.00" || amountVal == "0.0" || amountVal == "0" || amountVal == ".0" || amountVal == ".00") {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Amout Zero Validation - G, H, I, J, K, L, M, O, R
    $m.validator.addMethod("AmountZeroValtxtAmtSchedR", function (value, element) {
        if ($("#txtAmtExpensesAllocation").val().toString() != "") {
            var amountVal = $("#txtAmtExpensesAllocation").val().toString();
            //var valAmount = parseFloat("1");
            //if (parseFloat(amountVal) < valAmount) {
            if (amountVal == "0.00" || amountVal == "0.0" || amountVal == "0" || amountVal == ".0" || amountVal == ".00") {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Amount Zero Validation
    $m.validator.addMethod("AmountValZeroSchedD", function (value, element) {
        if ($("#txtAmtSchedD").val().toString() != "") {
            var amountVal = $("#txtAmtSchedD").val().toString();
            //var valAmount = parseFloat("1");
            if (amountVal == "0.00" || amountVal == "0.0" || amountVal == "0" || amountVal == ".0" || amountVal == ".00") {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Amount Zero Validation
    $m.validator.addMethod("AmountValZeroSchedE", function (value, element) {
        if ($("#txtAmtSchedE").val().toString() != "") {
            var amountVal = $("#txtAmtSchedE").val().toString();
            //var valAmount = parseFloat("1");
            if (amountVal == "0.00" || amountVal == "0.0" || amountVal == "0" || amountVal == ".0" || amountVal == ".00") {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Amount Zero Validation
    $m.validator.addMethod("AmountValZeroSchedN", function (value, element) {
        if ($("#txtAmtSchedN").val().toString() != "") {
            var amountVal = $("#txtAmtSchedN").val().toString();
            //var valAmount = parseFloat("1");
            if (amountVal == "0.00" || amountVal == "0.0" || amountVal == "0" || amountVal == ".0" || amountVal == ".00") {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Amount Zero Validation
    $m.validator.addMethod("AmountValZeroSchedP", function (value, element) {
        if ($("#txtAmtSchedP").val().toString() != "") {
            var amountVal = $("#txtAmtSchedP").val().toString();
            //var valAmount = parseFloat("1");
            if (amountVal == "0.00" || amountVal == "0.0" || amountVal == "0" || amountVal == ".0" || amountVal == ".00") {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Amount Zero Validation
    $m.validator.addMethod("AmountValZeroSchedQ", function (value, element) {
        if ($("#txtAmtSchedQ").val().toString() != "") {
            var amountVal = $("#txtAmtSchedQ").val().toString();
            //var valAmount = parseFloat("1");
            if (amountVal == "0.00" || amountVal == "0.0" || amountVal == "0" || amountVal == ".0" || amountVal == ".00") {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Amount Zero Validation
    $m.validator.addMethod("AmountZeroValSchedL", function (value, element) {
        if ($("#txtAmountRefunded").val().toString() != "") {
            var amountVal = $("#txtAmountRefunded").val().toString();
            //var valAmount = parseFloat("1");
            if (amountVal == "0.00" || amountVal == "0.0" || amountVal == "0" || amountVal == ".0" || amountVal == ".00") {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Amount Zero Validation
    $m.validator.addMethod("AmountZeroValSchedF", function (value, element) {
        if ($("#txtOriginalAmount").val().toString() != "") {
            var amountVal = $("#txtOriginalAmount").val().toString();
            //var valAmount = parseFloat("1");
            //if (parseFloat(amountVal) < valAmount) {
            if (amountVal == "0.00" || amountVal == "0.0" || amountVal == "0" || amountVal == ".0" || amountVal == ".00") {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Amount Zero Validation
    $m.validator.addMethod("AmountZeroValSchedFAmt", function (value, element) {
        if ($("#txtAmtExpenditurePayments").val().toString() != "") {
            var amountVal = $("#txtAmtExpenditurePayments").val().toString();
            //var valAmount = parseFloat("1");
            //if (parseFloat(amountVal) < valAmount) {
            if (amountVal == "0.00" || amountVal == "0.0" || amountVal == "0" || amountVal == ".0" || amountVal == ".00") {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Amount Zero Validation
    $m.validator.addMethod("AmountZeroValSchedA24HNotice", function (value, element) {
        if ($("#txtAmt24HNotice").val().toString() != "") {
            var amountVal = $("#txtAmt24HNotice").val().toString();
            var valAmount = parseFloat("1");
            if (parseFloat(amountVal) < valAmount) {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Amount Zero Validation
    $m.validator.addMethod("AmountZeroValSchedAIEWContr", function (value, element) {
        if ($("#txtAmtIEWeeklyContr").val().toString() != "") {
            var amountVal = $("#txtAmtIEWeeklyContr").val().toString();
            var valAmount = parseFloat("1");
            if (parseFloat(amountVal) < valAmount) {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Amount Zero Validation
    $m.validator.addMethod("AmountZeroValSchedFIEWExp", function (value, element) {
        if ($("#txtAmtIEWeeklyExpenditure").val().toString() != "") {
            var amountVal = $("#txtAmtIEWeeklyExpenditure").val().toString();
            var valAmount = parseFloat("1");
            if (parseFloat(amountVal) < valAmount) {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Amount Zero Validation
    $m.validator.addMethod("AmountZeroValSchedFIEWExpPIDA", function (value, element) {
        if ($("#txtAmtIEWeeklyPIDAExpenditure").val().toString() != "") {
            var amountVal = $("#txtAmtIEWeeklyPIDAExpenditure").val().toString();
            var valAmount = parseFloat("1");
            if (parseFloat(amountVal) < valAmount) {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Amount Zero Validation
    $m.validator.addMethod("AmountZeroValSchedFIE24HrPIDA", function (value, element) {
        if ($("#txtAmtIE24HrPIDAExpenditure").val().toString() != "") {
            var amountVal = $("#txtAmtIE24HrPIDAExpenditure").val().toString();
            var valAmount = parseFloat("1");
            if (parseFloat(amountVal) < valAmount) {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Amount Zero Validation
    $m.validator.addMethod("AmountOriginalShedKFVal", function (value, element) {
        if ($("#txtOriginalAmountShedF").val().toString() != "") {
            var amountVal = $("#txtOriginalAmountShedF").val().toString();
            //var valAmount = parseFloat("1");
            //if (parseFloat(amountVal) < valAmount) {
            if (amountVal == "0.00" || amountVal == "0.0" || amountVal == "0" || amountVal == ".0" || amountVal == ".00") {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Amount less than $1,000 Validation for Non-Itemized 24 Hour Notice.
    $m.validator.addMethod("Amount24HNoticeValidate", function (value, element) {
        if ($("#txtAmt24HNotice").val().toString() != "") {
            var amountVal = $("#txtAmt24HNotice").val().toString();
            var valAmount = parseFloat("1000");
            if (parseFloat(amountVal) < valAmount) {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Amount less than $1,000 Validation for Non-Itemized 24 Hour Notice.
    $m.validator.addMethod("AmountIEWContrValidate", function (value, element) {
        if ($("#txtAmtIEWeeklyContr").val().toString() != "") {
            var amountVal = $("#txtAmtIEWeeklyContr").val().toString();
            var valAmount = parseFloat("1000");
            if (parseFloat(amountVal) < valAmount) {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Amount less than $5,000 Validation for Non-Itemized 24 Hour Notice.
    $m.validator.addMethod("AmountIEWExpValidate", function (value, element) {
        if ($("#txtAmtIEWeeklyExpenditure").val().toString() != "") {
            var amountVal = $("#txtAmtIEWeeklyExpenditure").val().toString();
            var valAmount = parseFloat("5000");
            if (parseFloat(amountVal) < valAmount) {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Amount less than $500 Validation for Non-Itemized 24 Hour Notice.
    $m.validator.addMethod("AmountIEWExpPIDAValidate", function (value, element) {

        if ($("#txtAmtIEWeeklyPIDAExpenditure").val().toString() != "") {
            var amountVal = $("#txtAmtIEWeeklyPIDAExpenditure").val().toString();
            var valAmount = parseFloat("500");
            if (parseFloat(amountVal) < valAmount) {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Amount less than $500 Validation for Non-Itemized 24 Hour Notice.
    $m.validator.addMethod("AmountIE24HrPIDAValidate", function (value, element) {

        if ($("#txtAmtIE24HrPIDAExpenditure").val().toString() != "") {
            var amountVal = $("#txtAmtIE24HrPIDAExpenditure").val().toString();
            var valAmount = parseFloat("500");
            if (parseFloat(amountVal) < valAmount) {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Amount Zero Validation Partnership
    $m.validator.addMethod("AmountZeroValPartSchedAC", function (value, element) {
        if ($("#txtPartAmtAC").val().toString() != "") {
            var amountVal = $("#txtPartAmtAC").val().toString();
            //var valAmount = parseFloat("1");
            //if (parseFloat(amountVal) < valAmount) {
            if (amountVal == "0.00" || amountVal == "0.0" || amountVal == "0" || amountVal == ".0" || amountVal == ".00") {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Amount Zero Validation Partnership
    $m.validator.addMethod("AmountZeroValPartSchedD", function (value, element) {
        if ($("#txtPartAmtSchedD").val().toString() != "") {
            var amountVal = $("#txtPartAmtSchedD").val().toString();
            //var valAmount = parseFloat("1");
            //if (parseFloat(amountVal) < valAmount) {
            if (amountVal == "0.00" || amountVal == "0.0" || amountVal == "0" || amountVal == ".0" || amountVal == ".00") {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Amount Zero Validation Partnership
    $m.validator.addMethod("AmountZeroValPartSchedF", function (value, element) {
        if ($("#txtPartAmtSchedF").val().toString() != "") {
            var amountVal = $("#txtPartAmtSchedF").val().toString();
            //var valAmount = parseFloat("1");
            //if (parseFloat(amountVal) < valAmount) {
            if (amountVal == "0.00" || amountVal == "0.0" || amountVal == "0" || amountVal == ".0" || amountVal == ".00") {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Amount Zero Validation Partnership
    $m.validator.addMethod("AmountZeroValPartSchedP", function (value, element) {
        if ($("#txtPartAmtSchedP").val().toString() != "") {
            var amountVal = $("#txtPartAmtSchedP").val().toString();
            //var valAmount = parseFloat("1");
            //if (parseFloat(amountVal) < valAmount) {
            if (amountVal == "0.00" || amountVal == "0.0" || amountVal == "0" || amountVal == ".0" || amountVal == ".00") {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Amount Zero Validation Partnership
    $m.validator.addMethod("AmountZeroValPart", function (value, element) {
        //if ($("#txtPartAmt").val().toString() != "") {
        if (amountVal == "0.00" || amountVal == "0.0" || amountVal == "0" || amountVal == ".0" || amountVal == ".00") {
            var amountVal = $("#txtPartAmt").val().toString();
            var valAmount = parseFloat("1");
            if (parseFloat(amountVal) < valAmount) {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });        

    // Amount Zero Validation Partnership
    $m.validator.addMethod("AmountZeroValReim", function (value, element) {
        if ($("#txtAmtReim").val().toString() != "") {
            var amountVal = $("#txtAmtReim").val().toString();
            //var valAmount = parseFloat("1");
            //if (parseFloat(amountVal) < valAmount) {
            if (amountVal == "0.00" || amountVal == "0.0" || amountVal == "0" || amountVal == ".0" || amountVal == ".00") {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Amount Zero Validation Partnership
    $m.validator.addMethod("AmountZeroValCCI", function (value, element) {
        if ($("#txtAmountCCI").val().toString() != "") {
            var amountVal = $("#txtAmountCCI").val().toString();
            //var valAmount = parseFloat("1");
            //if (parseFloat(amountVal) < valAmount) {
            if (amountVal == "0.00" || amountVal == "0.0" || amountVal == "0" || amountVal == ".0" || amountVal == ".00") {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Amount Zero Validation Partnership
    $m.validator.addMethod("AmountZeroValCCISchedR", function (value, element) {
        if ($("#txtAmtExpensesAllocation").val().toString() != "") {
            var amountVal = $("#txtAmtExpensesAllocation").val().toString();
            //var valAmount = parseFloat("1");
            //if (parseFloat(amountVal) < valAmount) {
            if (amountVal == "0.00" || amountVal == "0.0" || amountVal == "0" || amountVal == ".0" || amountVal == ".00") {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // ALPHABETS VALIDATOR
    $m.validator.addMethod("AlphabetsVal", function (value, element) {
        return this.optional(element) || /^[a-zA-Z ]+$/i.test(value);
    });

    // ALPHABETS VALIDATOR United States State
    $m.validator.addMethod("AlphabetsValState", function (value, element) {
        if ($("#txtState").val().toString() != "") {
            if ($('#chkCountry').is(':checked') == false) {
                return this.optional(element) || /^[a-zA-Z]+$/i.test(value);
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    $m.validator.addMethod("AlphabetsValStatePart", function (value, element) {
        if ($("#txtPartState").val().toString() != "") {
            if ($('#chkCountryPartnership').is(':checked') == false) {
                return this.optional(element) || /^[a-zA-Z]+$/i.test(value);
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    $m.validator.addMethod("AlphabetsValStateReim", function (value, element) {
        if ($("#txtStateReim").val().toString() != "") {
            if ($('#chkCountryReim').is(':checked') == false) {
                return this.optional(element) || /^[a-zA-Z]+$/i.test(value);
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    $m.validator.addMethod("AlphabetsValStateCCI", function (value, element) {
        if ($("#txtStateCCI").val().toString() != "") {
            if ($('#chkCountryCCI').is(':checked') == false) {
                return this.optional(element) || /^[a-zA-Z]+$/i.test(value);
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // United State - Minimum 2 letters required.
    $m.validator.addMethod("State2LettersValPart", function (value, element) {
        if ($("#txtPartState").val().toString() != "") {
            if ($('#chkCountryPartnership').is(':checked') == false) {
                if ($("#txtPartState").val().toString().length == 2) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // United State - Minimum 2 letters required.
    $m.validator.addMethod("State2LettersValReim", function (value, element) {
        if ($("#txtStateReim").val().toString() != "") {
            if ($('#chkCountryReim').is(':checked') == false) {
                if ($("#txtStateReim").val().toString().length == 2) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // United State - Minimum 2 letters required.
    $m.validator.addMethod("State2LettersValCCI", function (value, element) {
        if ($("#txtStateCCI").val().toString() != "") {
            if ($('#chkCountryCCI').is(':checked') == false) {
                if ($("#txtStateCCI").val().toString().length == 2) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Schedule 'A' United States - State 2 letters required.
    $m.validator.addMethod("State2LettersVal", function (value, element) {
        if ($("#txtState").val().toString() != "") {
            if ($('#chkCountry').is(':checked') == false) {
                if ($("#txtState").val().toString().length == 2) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // NUMBERS AND SPECIAL CHARECTER VALIDATOR
    $m.validator.addMethod("AmountVal", function (value, element) {
        return this.optional(element) || /^\d{0,12}(\.\d{0,2})?$/i.test(value);
    });

    // ALPHANUMERIC VALIDATOR
    $m.validator.addMethod("AlphaNumeric", function (value, element) {
        return this.optional(element) || /^[a-zA-Z0-9]*$/.test(value);
    });

    // NAME VALIDATOR
    $m.validator.addMethod("NameValidate", function (value, element) {
        return this.optional(element) || /^[a-zA-Z0-9 #'.,-]*$/i.test(value);
    });

    // NAME ONLY VALIDATOR
    $m.validator.addMethod("NameOnlyValidate", function (value, element) {
        return this.optional(element) || /^[a-zA-Z0-9 #'.,&()-]*$/i.test(value);
    });

    $m.validator.addMethod("EntityNameValidate", function (value, element) {
        return this.optional(element) || /^[a-zA-Z0-9 #'.,&()-]*$/i.test(value);
    });

    $m.validator.addMethod("NameValidatePartnerDet", function (value, element) {
        if ($("#lstTransactionType option:selected").val().toString() == "1" || $("#lstTransactionType option:selected").val().toString() == "4" || $("#lstTransactionType option:selected").val().toString() == "16" || $("#lstTransactionType option:selected").val().toString() == "9") {
            return this.optional(element) || /^[a-zA-Z0-9 #'.,&-]*$/i.test(value);
        }
        else {
            return this.optional(element) || /^[a-zA-Z0-9 #'.,-]*$/i.test(value);
        }        
    });

    // Address Validator
    $m.validator.addMethod("ValidateAlphaNumericAddress", function (value, element) {
        return this.optional(element) || /^[a-zA-Z0-9 #'.,-]*$/i.test(value);
    });
    
    // Other Country Zipcode Validation
    $m.validator.addMethod("OtherCountryZipVal", function (value, element) {
        return this.optional(element) || /^[a-zA-Z0-9 -]*$/i.test(value);
    });

    // Cityr United States Validator
    $m.validator.addMethod("ValidateAlphaSpecial", function (value, element) {
        if ($("#txtCity").val().toString() != "") {
            if ($('#chkCountry').is(':checked') == false) {
                return this.optional(element) || /^[a-zA-Z #'.,-]*$/i.test(value);
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    $m.validator.addMethod("ValidateAlphaTreasurerState", function (value, element) {
        if ($("#txtStateTreasurer").val().toString() != "") {
            return this.optional(element) || /^[a-zA-Z]*$/i.test(value);
        }
        else {
            return true;
        }
    });

    $m.validator.addMethod("ValidateAlphaSpecialTreasurerCity", function (value, element) {
        if ($("#txtCityTreasurer").val().toString() != "") {
            return this.optional(element) || /^[a-zA-Z #'.,-]*$/i.test(value);
        }
        else {
            return true;
        }
    });

    // Cityr United States Validator Partnership
    $m.validator.addMethod("ValidateAlphaSpecialReim", function (value, element) {
        if ($("#txtCityReim").val().toString() != "") {
            if ($('#chkCountryReim').is(':checked') == false) {
                return this.optional(element) || /^[a-zA-Z #'.,-]*$/i.test(value);
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Cityr United States Validator Partnership
    $m.validator.addMethod("ValidateAlphaSpecialCCI", function (value, element) {
        if ($("#txtCityCCI").val().toString() != "") {
            if ($('#chkCountryCCI').is(':checked') == false) {
                return this.optional(element) || /^[a-zA-Z #'.,-]*$/i.test(value);
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // Cityr United States Validator Partnership
    $m.validator.addMethod("ValidateAlphaSpecialPart", function (value, element) {
        if ($("#txtPartCity").val().toString() != "") {
            if ($('#chkCountryPartnership').is(':checked') == false) {
                return this.optional(element) || /^[a-zA-Z #'.,-]*$/i.test(value);
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });


    // City for Other Country Validation
    $m.validator.addMethod("AlphaSpecialNumOtherCntry", function (value, element) {
        if ($("#txtCity").val().toString() != "") {
            if ($('#chkCountry').is(':checked') == true) {
                return this.optional(element) || /^[a-zA-Z0-9 #'.,-]*$/i.test(value);
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // City for Other Country Validation Partnership
    $m.validator.addMethod("AlphaSpecialNumOtherCntryParty", function (value, element) {
        if ($("#txtPartCity").val().toString() != "") {
            if ($('#chkCountryPartnership').is(':checked') == true) {
                return this.optional(element) || /^[a-zA-Z0-9 #'.,-]*$/i.test(value);
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // City for Other Country Validation Partnership
    $m.validator.addMethod("AlphaSpecialNumOtherCntryReim", function (value, element) {
        if ($("#txtCityReim").val().toString() != "") {
            if ($('#chkCountryReim').is(':checked') == true) {
                return this.optional(element) || /^[a-zA-Z0-9 #'.,-]*$/i.test(value);
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    // City for Other Country Validation Partnership
    $m.validator.addMethod("AlphaSpecialNumOtherCntryCCI", function (value, element) {
        if ($("#txtCityCCI").val().toString() != "") {
            if ($('#chkCountryCCI').is(':checked') == true) {
                return this.optional(element) || /^[a-zA-Z0-9 #'.,-]*$/i.test(value);
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    $m.validator.addMethod("AlphaSpecialStateOtherCntry", function (value, element) {
        if ($("#txtState").val().toString() != "") {
            if ($('#chkCountry').is(':checked') == true) {
                return this.optional(element) || /^[a-zA-Z0-9 #'.,-]*$/i.test(value);
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    $m.validator.addMethod("AlphaSpecialStateOtherCntryPart", function (value, element) {
        if ($("#txtPartState").val().toString() != "") {
            if ($('#chkCountryPartnership').is(':checked') == true) {
                return this.optional(element) || /^[a-zA-Z0-9 #'.,-]*$/i.test(value);
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    $m.validator.addMethod("AlphaSpecialStateOtherCntryReim", function (value, element) {
        if ($("#txtStateReim").val().toString() != "") {
            if ($('#chkCountryReim').is(':checked') == true) {
                return this.optional(element) || /^[a-zA-Z0-9 #'.,-]*$/i.test(value);
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });

    $m.validator.addMethod("AlphaSpecialStateOtherCntryCCI", function (value, element) {
        if ($("#txtStateCCI").val().toString() != "") {
            if ($('#chkCountryCCI').is(':checked') == true) {
                return this.optional(element) || /^[a-zA-Z0-9 #'.,-]*$/i.test(value);
            }
            else {
                return true;
            }
        }
        else {
            return true;
        }
    });


    // DATE VALIDATION
    $m.validator.addMethod("dateUS", function (value, element) {
        var errormsg = "";
        var re = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
        if (re.test(value)) {
            var adata = value.split('/');
            var mm = parseInt(adata[0], 10);
            var dd = parseInt(adata[1], 10);
            var yyyy = parseInt(adata[2], 10);
            var xdata = new Date(yyyy, mm - 1, dd);
            if ((xdata.getFullYear() == yyyy) && (xdata.getMonth() == mm - 1) && (xdata.getDate() == dd))
                check = true;
            else {
                check = false;
                errormsg = "Leap year date";
            }
        } else
            check = false;
        return this.optional(element) || check;
    });

    // CUTT OFF DATE VALIDATION FOR TRANSFER OUT
    $m.validator.addMethod("CutOffDateWCFVal", function (value, element) {
        var dateRange = $("#lstFilingDate option:selected").text();
        var dates = dateRange.split("-");
        var minDate = dates[0];
        var maxDate = dates[1];

        var wcfDate = $("#txtCurrentDateWCS").val().toString();     
        var d1 = new Date(wcfDate);
        var d2 = new Date(minDate);
        var d3 = new Date(maxDate);
        if (d1 > d3 || d1 < d2)
            return false;
        else
            return true;
    });

    // CUTT OFF DATE VALIDATION FOR TRANSFER OUT
    $m.validator.addMethod("CutCurrentDateVal", function (value, element) {
        var wcfDate = $("#txtCurrentDateReceived").val().toString();
        var CurrentDateValData = new Date();
        //var dateReceived = $("#txtCurrentDateTransferred").val().toString();
        var d1 = new Date(wcfDate);
        var d2 = new Date(CurrentDateValData);
        if (d1 > d2)
            return false;
        else
            return true;
    });

    // CUTT OFF DATE VALIDATION FOR Punlic fund Payment 
    $m.validator.addMethod("DateRefundCurrentDateVal", function (value, element) {
        var wcfDate = $("#txtDateRefundPaid").val().toString();
        var CurrentDateValData = new Date();
        //var dateReceived = $("#txtCurrentDateTransferred").val().toString();
        var d1 = new Date(wcfDate);
        var d2 = new Date(CurrentDateValData);
        if (d1 > d2)
            return false;
        else
            return true;
    });

    // CUTT OFF DATE VALIDATION
    $m.validator.addMethod("ValCutOffDate", function (value, element) {
        if ($("#lstElectionType option:selected").val().toString() == "6") { // Off-Cycle
            if ($("#lstFilingDate option:selected").text().toString() == "- New Filing Date -") {
                var cuttofDate = $("#txtNewFilingDate").val().toString();
                var dateReceived = $("#txtCurrentDate").val().toString();
                var d1 = new Date(cuttofDate);
                var d2 = new Date(dateReceived);
                if (d2 > d1)
                    return false;
                else
                    return true;
            }
            else {
                var cuttofDate = $("#lstFilingDate option:selected").text().toString();
                var dateReceived = $("#txtCurrentDate").val().toString();
                var d1 = new Date(cuttofDate);
                var d2 = new Date(dateReceived);
                if (d2 > d1)
                    return false;
                else
                    return true;
            }
        }
        else {
            var cuttofDate = $("#txtReportPeriodDatesFrom").val().toString();
            var dateReceived = $("#txtCurrentDate").val().toString();
            var d1 = new Date(cuttofDate);
            var d2 = new Date(dateReceived);
            if (d2 > d1)
                return false;
            else
                return true;
        }
    });

    // CUTT OFF DATE VALIDATION FOR TRANSFER OUT
    $m.validator.addMethod("ValCutOffDateTransferred", function (value, element) {
        var cuttofDate = $("#txtReportPeriodDatesFrom").val().toString();
        var dateReceived = $("#txtCurrentDateTransferred").val().toString();
        var d1 = new Date(cuttofDate);
        var d2 = new Date(dateReceived);
        if (d2 > d1)
            return false;
        else
            return true;
    });

    // CUTT OFF DATE VALIDATION FOR TRANSFER OUT
    $m.validator.addMethod("ValCutOffDateSchedN", function (value, element) {
        var cuttofDate = $("#txtReportPeriodDatesFrom").val().toString();
        var dateReceived = $("#txtCurrentDateSchedN").val().toString();
        var d1 = new Date(cuttofDate);
        var d2 = new Date(dateReceived);
        if (d2 > d1)
            return false;
        else
            return true;
    });

    // CUTT OFF DATE VALIDATION FOR TRANSFER OUT
    $m.validator.addMethod("ValCutOffDateSchedR", function (value, element) {
        var cuttofDate = $("#txtReportPeriodDatesFrom").val().toString();
        var dateReceived = $("#txtCurrentDateAllocatedSchedR").val().toString();
        var d1 = new Date(cuttofDate);
        var d2 = new Date(dateReceived);
        if (d2 > d1)
            return false;
        else
            return true;
    });

    // CUTT OFF DATE VALIDATION FOR Loan Received
    $m.validator.addMethod("ValCutOffDateLoanReceived", function (value, element) {
        var cuttofDate = $("#txtReportPeriodDatesFrom").val().toString();
        var dateReceived = $("#txtCurrentDateLoanReceived").val().toString();
        var d1 = new Date(cuttofDate);
        var d2 = new Date(dateReceived);
        if (d2 > d1)
            return false;
        else
            return true;
    });

    // CUTT OFF DATE VALIDATION FOR Loan Repayment
    $m.validator.addMethod("ValCutOffDateLoanRepay", function (value, element) {
        var cuttofDate = $("#txtReportPeriodDatesFrom").val().toString();
        var dateReceived = $("#txtCurrentDateLoanRepay").val().toString();
        var d1 = new Date(cuttofDate);
        var d2 = new Date(dateReceived);
        if (d2 > d1)
            return false;
        else
            return true;
    });

    // CUTT OFF DATE VALIDATION FOR Loan FORGIVEN
    $m.validator.addMethod("ValCutOffDateLoanForgiven", function (value, element) {
        var cuttofDate = $("#txtReportPeriodDatesFrom").val().toString();
        var dateReceived = $("#txtCurrentDateLoanForgiven").val().toString();
        var d1 = new Date(cuttofDate);
        var d2 = new Date(dateReceived);
        if (d2 > d1)
            return false;
        else
            return true;
    });

    // CUTT OFF DATE VALIDATION FOR Loan Repayment
    $m.validator.addMethod("ValCutOffDateLoanRepayScheF", function (value, element) {
        var cuttofDate = $("#txtReportPeriodDatesFrom").val().toString();
        var dateReceived = $("#txtCurrentDateShedF").val().toString();
        var d1 = new Date(cuttofDate);
        var d2 = new Date(dateReceived);
        if (d2 > d1)
            return false;
        else
            return true;
    });

    // CUTT OFF DATE VALIDATION SCHEDULE 'L'
    $m.validator.addMethod("ValCutOffDateSchedL", function (value, element) {
        var cuttofDate = $("#txtReportPeriodDatesFrom").val().toString();
        var dateReceived = $("#txtCurrentDateSchedL").val().toString();
        var d1 = new Date(cuttofDate);
        var d2 = new Date(dateReceived);
        if (d2 > d1)
            return false;
        else
            return true;
    });

    // CUTT OFF DATE VALIDATION SCHEDULE 'Q'    
    $m.validator.addMethod("ValCutOffDateSchedQ", function (value, element) {
        if ($("#lstElectionType option:selected").val().toString() == "6") { // Off-Cycle
            if ($("#lstFilingDate option:selected").text().toString() == "- New Filing Date -") {
                var cuttofDate = $("#txtNewFilingDate").val().toString();
                var dateReceived = $("#txtCurrentDateSchedQ").val().toString();
                var d1 = new Date(cuttofDate);
                var d2 = new Date(dateReceived);
                if (d2 > d1)
                    return false;
                else
                    return true;
            }
            else {
                var cuttofDate1 = $("#lstFilingDate option:selected").text().toString();
                var dateReceived1 = $("#txtCurrentDateSchedQ").val().toString();
                var d11 = new Date(cuttofDate1);
                var d22 = new Date(dateReceived1);
                if (d22 > d11)
                    return false;
                else
                    return true;
            }
        }
        else {
            var cuttofDate2 = $("#txtReportPeriodDatesFrom").val().toString();
            var dateReceived2 = $("#txtCurrentDateSchedQ").val().toString();
            var d12 = new Date(cuttofDate2);
            var d21 = new Date(dateReceived2);
            if (d21 > d12)
                return false;
            else
                return true;
        }
    });

    // FILING DATE AND CUTT OFF DATE VALIDATION FOR NON-ITEMIZED 24-HOUR NOTICE TRANSACTIONS.
    $m.validator.addMethod("ValCutOffDateSchedA24HNotice", function (value, element) {
        if ($("#txtCurrentDate24HNotice").val().toString() != "") {
            var cuttofDate = $("#txtReportPeriodDatesTo").val().toString();
            var filingDate = $("#txtReportPeriodDatesFrom").val().toString();
            var dateReceived = $("#txtCurrentDate24HNotice").val().toString();
            var minDate = new Date(filingDate);
            var maxDate = new Date(cuttofDate);
            var dateReceivedVal = new Date(dateReceived);
            if (dateReceivedVal < minDate) {
                return false;
            }
            else if (dateReceivedVal > maxDate) {
                return false;
            }
            else {
                return true;
            }
        }
    });

    // FILING DATE AND CUTT OFF DATE VALIDATION FOR NON-ITEMIZED IE - WEEKLY CONTRIBUTIONS TRANSACTIONS.
    $m.validator.addMethod("ValDateRecSchedAIEWeeklyContr", function (value, element) {
        if ($("#txtCurrentDateIEWeeklyContr").val().toString() != "") {

            var electionDate = "";
            var dateReceived = new Date($("#txtCurrentDateIEWeeklyContr").val().toString());
            if ($("#lstElectionDate option:selected").text().toString() != "") {
                electionDate = new Date($("#lstElectionDate option:selected").text().toString());
            }
            else {
                if ($m("#lstFilingDate option:selected").text().toString() == "- New Filing Date -") {
                    electionDate = new Date($("#txtNewFilingDate").val().toString());
                }
                else {
                    electionDate = new Date($("#lstFilingDate option:selected").text().toString());
                }
            }
            
            var filingDate = "";
            //if ($("#txtNewFilingDate").val().toString() != "") {
            if ($m("#lstFilingDate option:selected").text().toString() == "- New Filing Date -") {
                filingDate = new Date($("#txtNewFilingDate").val().toString());
            }
            else {
                filingDate = new Date($("#lstFilingDate option:selected").text().toString());
            }

            var dateReceivedYear = dateReceived.getFullYear();
            var electionDateYear = electionDate.getFullYear();
          
            if ((dateReceivedYear == electionDateYear) && (dateReceived <= filingDate)) {
                return true;
            }
            else {
                return false;
            }
        }
    });

    //// VALIDATION ON DATE SUBMITTED IN NON-ITEMIZED CAMPAIGN MATERIAL.
    //$m.validator.addMethod("ValDateSubmittedCampMater", function (value, element) {
    //    if ($("#txtDateSubmittedCampMater").val().toString() != "") {

    //        var dateReceived = new Date($("#txtDateSubmittedCampMater").val().toString());
    //        var electionDate = new Date($("#lstElectionDate option:selected").text().toString());
    //        var cutoffDate = new Date(sessionStorage.getItem("FilingDate").toString());

    //        var dateReceivedYear = dateReceived.getFullYear();
    //        var electionDateYear = electionDate.getFullYear();

    //        if ((dateReceivedYear == electionDateYear) && (dateReceived <= cutoffDate)) { // with in the Election Year.                
    //            return true;
    //        }
    //        else {
    //            return false;
    //        }
    //    }
    //});

    // FILING DATE AND CUTT OFF DATE VALIDATION FOR NON-ITEMIZED IE - 24 HOUR EXPENDITURE TRANSACTIONS.
    $m.validator.addMethod("ValDateRecSchedFIE24HourExp", function (value, element) {
        if ($("#txtCurrentDateIE24HourExp").val().toString() != "") {

            var dateReceived = new Date($("#txtCurrentDateIE24HourExp").val().toString());

            var fromDate = new Date(sessionStorage.getItem("CutOffDate").toString());
            var toDate = new Date(sessionStorage.getItem("FilingDate").toString());

            if ((dateReceived >= fromDate) && (dateReceived <= toDate)) {
                return true;
            }
            else {
                return false;
            }
        }
    });

    // FILING DATE AND CUTT OFF DATE VALIDATION FOR NON-ITEMIZED IE - WEEKLY CONTRIBUTIONS TRANSACTIONS.
    $m.validator.addMethod("ValDateRecSchedAIE24HContr", function (value, element) {
        if ($("#txtCurrentDateIE24HContr").val().toString() != "") {

            var dateReceived = new Date($("#txtCurrentDateIE24HContr").val().toString());

            var fromDate = new Date(sessionStorage.getItem("CutOffDate").toString());
            var toDate = new Date(sessionStorage.getItem("FilingDate").toString());

            if ((dateReceived >= fromDate) && (dateReceived <= toDate)) {
                return true;
            }
            else {
                return false;
            }
        }
    });

    // CUTT OFF DATE VALIDATION SCHEDULE 'Q' - REIMBURSEMENT 
    $m.validator.addMethod("ValCutOffDateSchedQReim", function (value, element) {
        if ($("#lstElectionType option:selected").val().toString() == "6") { // Off-Cycle
            if ($("#lstFilingDate option:selected").text().toString() == "- New Filing Date -") {
                var cuttofDate = $("#txtNewFilingDate").val().toString();
                var dateReceived = $("#txtCurrentDateSchedQReim").val().toString();
                var d1 = new Date(cuttofDate);
                var d2 = new Date(dateReceived);
                if (d2 > d1)
                    return false;
                else
                    return true;
            }
            else {
                var cuttofDate1 = $("#lstFilingDate option:selected").text().toString();
                var dateReceived1 = $("#txtCurrentDateSchedQReim").val().toString();
                var d11 = new Date(cuttofDate1);
                var d22 = new Date(dateReceived1);
                if (d22 > d11)
                    return false;
                else
                    return true;
            }
        }
        else {
            var cuttofDate11 = $("#txtReportPeriodDatesFrom").val().toString();
            var dateReceived11 = $("#txtCurrentDateSchedQReim").val().toString();
            var d12 = new Date(cuttofDate11);
            var d21 = new Date(dateReceived11);
            if (d21 > d12)
                return false;
            else
                return true;
        }
    });

    // CUTT OFF DATE VALIDATION SCHEDULE 'Q' - REIMBURSEMENT 
    $m.validator.addMethod("ValCutOffDateSchedQCCI", function (value, element) {
        if ($("#lstElectionType option:selected").val().toString() == "6") { // Off-Cycle
            if ($("#lstFilingDate option:selected").text().toString() == "- New Filing Date -") {
                var cuttofDate = $("#txtNewFilingDate").val().toString();
                var dateReceived = $("#txtCurrentDateSchedQCCI").val().toString();
                var d1 = new Date(cuttofDate);
                var d2 = new Date(dateReceived);
                if (d2 > d1)
                    return false;
                else
                    return true;
            }
            else {
                var cuttofDate1 = $("#lstFilingDate option:selected").text().toString();
                var dateReceived1 = $("#txtCurrentDateSchedQCCI").val().toString();
                var d11 = new Date(cuttofDate1);
                var d22 = new Date(dateReceived1);
                if (d22 > d11)
                    return false;
                else
                    return true;
            }
        }
        else {
            var cuttofDate11 = $("#txtReportPeriodDatesFrom").val().toString();
            var dateReceived11 = $("#txtCurrentDateSchedQCCI").val().toString();
            var d12 = new Date(cuttofDate11);
            var d21 = new Date(dateReceived11);
            if (d21 > d12)
                return false;
            else
                return true;
        }
    });

    //Method validation
    $m.validator.addMethod("lstMethodVal", function (value, element) {
        if ($("#lstMethod option:selected").text().toString() != "- Select -")
            return true;
        else
            return false;
    });


    //VENDOR NAME VALIDATION ON VENDOR IMPORT PAGE.    
    $m.validator.addMethod("VendorNameVal", function (value, element) {        
        if ($("#lstVendorName option:selected").text().toString() != "- Select -")
            return true;
        else
            return false;
    });

    // CONTRIBUTOR CODE VALIDATION
    $m.validator.addMethod("ContributorCodeVal", function (value, element) {
        if ($("#lstContributionName option:selected").val().toString() != "0")
            return true;
        else
            return false;
    });

    // CONTRIBUTOR CODE VALIDATION
    $m.validator.addMethod("ContributorCodeValSchedDNonItem", function (value, element) {
        if ($("#lstContributionNameSchedD option:selected").val().toString() != "0")
            return true;
        else
            return false;
    });

    // Support or Oppose validation
    $m.validator.addMethod("lstSuppOrOppsVal", function (value, element) {            
        if ($("#lstSuppOrOpps option:selected").text().toString() != "- Select -")
            return true;
        else
            return false;
    });

    // lstDiaSupportOppose VALIDATION
    $m.validator.addMethod("lstDiaSupportOpposeVal", function (value, element) {
        if ($("#lstDiaSupportOppose option:selected").text().toString() != "- Select -")
            return true;
        else
            return false;
    });


    // CONTRIBUTOR CODE VALIDATION
    $m.validator.addMethod("MethodIEWeeklyContrVal", function (value, element) {
        if ($("#lstMethod option:selected").val().toString() != "0")
            return true;
        else
            return false;
    });

    // Camapign Material FilingMethod Required.
    $m.validator.addMethod("FileMethodCampMaterial", function (value, element) {
        if ($("#lstFilingMethod option:selected").val().toString() != "0")
            return true;
        else
            return false;
    });

    // EXPENDITURE PAYMENT NAME VALIDATION SCHED-L
    $m.validator.addMethod("ExpPaymentNameVal", function (value, element) {
        if ($("#lstExpPaymentName option:selected").val().toString() != "0")
            return true;
        else
            return false;
    });

    // EXPENDITURE AMOUNT VALIDATION SCHED-L
    $m.validator.addMethod("ExpPaymentAmountVal", function (value, element) {
        if ($("#lstExpPaymentAmount option:selected").val().toString() != "0")
            return true;
        else
            return false;
    });

    // EXPENDITURE DATE VALIDATION SCHED-L
    $m.validator.addMethod("ExpPaymentDateVal", function (value, element) {
        if ($("#lstExpPaymentDate option:selected").text().toString() != "- Select -")
            return true;
        else
            return false;
    });

    // CONTIRUBION NAME VALIDATION SCHED-M
    $m.validator.addMethod("ContributionNameVal", function (value, element) {
        if ($("#lstContributorName option:selected").val().toString() != "0")
            return true;
        else
            return false;
    });

    // CONTRIBUTION AMOUNT VALIDATION SCHED-M
    $m.validator.addMethod("ContributionAmountVal", function (value, element) {
        if ($("#lstContributorAmount option:selected").val().toString() != "0")
            return true;
        else
            return false;
    });

    // CONTRIBUTION DATE VALIDATION SCHED-M
    $m.validator.addMethod("ContributorDateVal", function (value, element) {
        if ($("#lstContributorDate option:selected").text().toString() != "- Select -")
            return true;
        else
            return false;
    });

    // RECEIPT CODE REQUIRED VALIDATION FOR FORM-P
    $m.validator.addMethod("RecieptCodeVal", function (value, element) {
        if ($("#lstReceiptCode option:selected").val().toString() != "0")
            return true;
        else
            return false;
    });

    // PURPOSE CODE REQUIRED VALIDATION FOR FORM-Q    
    $m.validator.addMethod("PurposeCodeVal", function (value, element) {
        if ($("#lstPurposeCode option:selected").val().toString() != "0")
            return true;
        else
            return false;
    });

    // METHOD REQUIRED VALIDATION FOR FORM-Q    
    $m.validator.addMethod("MethodIEValidation", function (value, element) {
        if ($("#lstMethodIE24HExpPayF option:selected").val().toString() != "0")
            return true;
        else
            return false;
    });

    // METHOD REQUIRED VALIDATION FOR FORM-Q    
    $m.validator.addMethod("MethodRequiredIEVal", function (value, element) {
        if ($m("#lblMethodIEWeeklyContr").text().toString() == "* Method") {
            if ($("#lstMethod option:selected").val().toString() != "0") {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            return false;
        }
    });

    // DATE INCURRED & ORIGINAL AMOUNT REQUIRED VALIDATION FOR FORM-F  
    $m.validator.addMethod("DateIncurredVal", function (value, element) {
        if ($("#lstDateIncurred option:selected").val().toString() != "0")
            return true;
        else
            return false;
    });

    // PURPOSE CODE REQUIRED VALIDATION FOR FORM-Q    
    $m.validator.addMethod("PurposeCodeValReim", function (value, element) {
        if ($("#lstPurposeCodeReim option:selected").val().toString() != "0")
            return true;
        else
            return false;
    });

    // PURPOSE CODE REQUIRED VALIDATION FOR FORM-Q    
    $m.validator.addMethod("PurposeCodeValCCI", function (value, element) {
        if ($("#lstPurposeCodeCCI option:selected").val().toString() != "0")
            return true;
        else
            return false;
    });

    //// CONTRIBUTOR CODE VALIDATION Schedule 'D'
    //$m.validator.addMethod("ContributorCodeValSchedDNonItem", function (value, element) {
    //    if ($("#lstContributionNameSchedD option:selected").val().toString() != "0")
    //        return true;
    //    else
    //        return false;
    //});

    // CONTRIBUTION TYPE VALIDATION Schedule 'D'
    $m.validator.addMethod("ContributionTypeValSchedD", function (value, element) {
        if ($("#lstContributionTypeInKind option:selected").val().toString() != "0")
            return true;
        else
            return false;
    });

    // CONTRIBUTION TYPE VALIDATION Schedule 'D'
    $m.validator.addMethod("ContributorCodeValSchedD", function (value, element) {
        if ($("#lstContributionNameInKind option:selected").val().toString() != "0")
            return true;
        else
            return false;
    });

    // CONTRIBUTION TYPE VALIDATION Schedule 'D'
    $m.validator.addMethod("ContributionTypeValNonItemD", function (value, element) {
        if ($("#lstContributionTypeNonItemD option:selected").val().toString() != "0")
            return true;
        else
            return false;
    });

    // Transfer Type VALIDATION
    $m.validator.addMethod("lstTransferTypeVal", function (value, element) {
        if ($("#lstTransferType option:selected").val().toString() != "0")
            return true;
        else
            return false;
    });

    // Office VALIDATION
    $m.validator.addMethod("lstOfficeVal", function (value, element) {
        if ($("#lstOffice option:selected").val().toString() != "0")
            return true;
        else
            return false;
    });

    // District VALIDATION
    $m.validator.addMethod("lstDistrictVal", function (value, element) {        
        if ($("#lstOffice option:selected").text().toString() != "- Select -") {            
            if ($("#lstDistrict option:selected").text().toString() != "- Select -")
                return true;
            else
                return false;
        }
        else {
            if ($("#lstDistrict option:selected").text().toString() != "- Select -")
                return true;
            else
                return false;
        }   
    });

    // Election Year VALIDATION
    $m.validator.addMethod("lstElectionCycleAllocatedVal", function (value, element) {
        if ($("#lstElectionCycleAllocated option:selected").val().toString() != "0")
            return true;
        else
            return false;
    });

    // Original Name VALIDATION
    $m.validator.addMethod("lstSearchNameVal", function (value, element) {
        if ($("#lstLiabilityLoans option:selected").text().toString() == "Loans") {
            if ($("#lstSearchName option:selected").text().toString() != "- Select -")
                return true;
            else
                return false;
        }
        else {
            if ($("#lstSearchName option:selected").text().toString() != "- Select -")
                return true;
            else
                return false;
        }
    });

    // Original Amount VALIDATION
    $m.validator.addMethod("lstSearchAmountVal", function (value, element) {
        if ($("#lstLiabilityLoans option:selected").text().toString() == "Loans") {
            if ($("#lstSearchAmount option:selected").text().toString() != "- Select -")
                return true;
            else
                return false;
        }
        else {
            if ($("#lstSearchAmount option:selected").text().toString() != "- Select -")
                return true;
            else
                return false;
        }

    });

    // Original Date VALIDATION
    $m.validator.addMethod("lstSearchDateVal", function (value, element) {
        if ($("#lstLiabilityLoans option:selected").text().toString() == "Loans") {
            if ($("#lstSearchDate option:selected").text().toString() != "- Select -")
                return true;
            else
                return false;
        }
        else {
            if ($("#lstSearchDate option:selected").text().toString() != "- Select -")
                return true;
            else
                return false;
        }
        
    });

    // Loan/Liabilities VALIDATION
    $m.validator.addMethod("lstLiabilityLoansVal", function (value, element) {
        if ($("#lstLiabilityLoans option:selected").text().toString() != "- Select -")
            return true;
        else
            return false;
    });

    // lstIsClaim VALIDATION
    $m.validator.addMethod("lstIsClaimVal", function (value, element) {
        if (sessionStorage.getItem("CommTypeIDVal").toString() == "23") {
            if ($("#lstIsClaim option:selected").text().toString() != "- Select -")
                return true;
            else
                return false;
        }        
    });

    // lstInDistrict VALIDATION
    $m.validator.addMethod("lstInDistrictVal", function (value, element) {
        if ($("#lstIsClaim option:selected").text().toString() == "Yes") {
            if ($("#lstInDistrict option:selected").text().toString() != "- Select -") {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            return false;
        }
    });

    // lstMinor VALIDATION
    $m.validator.addMethod("lstMinorVal", function (value, element) {
        if ($("#lstIsClaim option:selected").text().toString() == "Yes") {
            if ($("#lstMinor option:selected").text().toString() != "- Select -")
                return true;
            else
                return false;
        }
        else {
            return false;
        }
    });

    // lstVendor VALIDATION
    $m.validator.addMethod("lstVendorVal", function (value, element) {
        if ($("#lstIsClaim option:selected").text().toString() == "Yes") {
            if ($("#lstVendor option:selected").text().toString() != "- Select -")
                return true;
            else
                return false;
        }
        else {
            return false;
        }
    });

    // lstLobbyist VALIDATION
    $m.validator.addMethod("lstLobbyistVal", function (value, element) {
        if ($("#lstIsClaim option:selected").text().toString() == "Yes") {
            if ($("#lstLobbyist option:selected").text().toString() != "- Select -")
                return true;
            else
                return false;
        }
        else {
            return false;
        }
    });

    // Loaner Code VALIDATION
    $m.validator.addMethod("lstLoanerCodeVal", function (value, element) {
        if ($("#lstLoanerCode option:selected").val().toString() != "0")
            return true;
        else
            return false;
    });

    // Loaner Code VALIDATION
    $m.validator.addMethod("lstReceiptTypeValid", function (value, element) {
        if ($("#lstReceiptType option:selected").val().toString() != "0")
            return true;
        else
            return false;
    });

    //// Loaner Code VALIDATION
    //$m.validator.addMethod("lstContributionTypeVal", function (value, element) {        
    //    if ($("#lblContributionType").text().toString() == "* Contribution Type") {            
    //        if ($("#lstContributionType option:selected").val().toString() != "0")
    //            return true;
    //        else
    //            return false;
    //    }
    //    else {
    //        return false;
    //    }        
    //});

    //--------------------------------------------------------------------------------------------------------------------------------------------------------
    // Country Check Box......
    // Checkbox Checked or Not
    $("#chkCountry").click(function () {
        if ($('#chkCountry').is(':checked')) { // Other COUNTRY
            $("#txtCountry").val("");
            $("#txtCountry").prop("disabled", false);
            $("#txtCountry").focus();
            $("#txtState").prop('maxLength', '30');
            $("#txtZipCode").val('').removeClass('watermark');
            $m('#txtZipCode').attr("placeholder", "");

            // Clear Address
            $("#txtStreetName").val("");
            $("#txtCity").val("");
            $("#txtState").val("");
            $("#txtZipCode").val("");
            // Validate
            $m("#txtStreetName").valid();
            $m("#txtCity").valid();
            $m("#txtState").valid();
            $m("#txtZipCode").valid();

            $m('#txtZipCode').attr("placeholder", "");
        }
        else { // United States Country
            $("#txtCountry").val("United States");
            $m("#txtCountry").valid();
            $("#txtCountry").prop("disabled", true);
            $("#txtState").prop('maxLength', '2');
            $("#txtState").val("");

            // Clear Address
            $("#txtStreetName").val("");
            $("#txtCity").val("");
            $("#txtState").val("");
            $("#txtZipCode").val("");
            $("#txtZipCode").blur();
            // Validate
            $m("#txtStreetName").valid();
            $m("#txtCity").valid();
            $m("#txtState").valid();
            $m("#txtZipCode").valid();

            $m("#txtState").valid();

            $m('#txtZipCode').attr("placeholder", "00000-0000");
        }
    });

    $("#chkCountryShedF").click(function () {
        if ($('#chkCountryShedF').is(':checked')) { // Other COUNTRY
            $("#txtCountryShedF").val("");
            $("#txtCountryShedF").prop("disabled", false);
            $("#txtCountryShedF").focus();
            $("#txtStateShedF").prop('maxLength', '30');
            $("#txtZipCodeShedF").val('').removeClass('watermark');
            $m('#txtZipCodeShedF').attr("placeholder", "");

            // Clear Address
            $("#txtStreetNameShedF").val("");
            $("#txtCityShedF").val("");
            $("#txtStateShedF").val("");
            $("#txtZipCodeShedF").val("");
            // Validate
            $m("#txtStreetNameShedF").valid();
            $m("#txtCityShedF").valid();
            $m("#txtStateShedF").valid();
            $m("#txtZipCodeShedF").valid();

            $m('#txtZipCodeShedF').attr("placeholder", "");
        }
        else { // United States Country
            $("#txtCountryShedF").val("United States");
            $m("#txtCountryShedF").valid();
            $("#txtCountryShedF").prop("disabled", true);
            $("#txtState").prop('maxLength', '2');
            $("#txtState").val("");

            // Clear Address
            $("#txtStreetNameShedF").val("");
            $("#txtCityShedF").val("");
            $("#txtStateShedF").val("");
            $("#txtZipCodeShedF").val("");
            $("#txtZipCodeShedF").blur();
            // Validate
            $m("#txtStreetNameShedF").valid();
            $m("#txtCityShedF").valid();
            $m("#txtStateShedF").valid();
            $m("#txtZipCodeShedF").valid();
            $m('#txtZipCodeShedF').attr("placeholder", "00000-0000");
        }
    });
    // Country Check Box......
    //--------------------------------------------------------------------------------------------------------------------------------------------------------

    //$m("#txtFirstName").focusout(function (e) {
    //    if ($("#txtFirstName").toString() != "") {
    //        alert('hi....');
    //        $m("#txtFirstName").validate();
    //    }
    //});

}

function LefthandFilterValues() {
    $("#lblAllTransText").text("All Transactions: " + sessionStorage.getItem("ElectionCycleText").toString() + " - " + sessionStorage.getItem("DisclosurePeriodText").toString());        

    // Hide all Fileter
    $("#txtFilerID").prop("disabled", true);
    $("#txtFilerType").prop("disabled", true);
    $("#txtCommitteeName").prop("disabled", true);
    $("#lstElectionCycle").prop("disabled", true);
    $("#lstElectionType").prop("disabled", true);
    $("#lstElectionDate").prop("disabled", true);
    $("#lstDisclosureType").prop("disabled", true);
    $("#lstDisclosurePeriod").prop("disabled", true);
    $("#txtReportPeriodDatesFrom").prop("disabled", true);
    $("#txtReportPeriodDatesTo").prop("disabled", true);
    $("#txtNewFilingDate").prop("disabled", true);
    $("#lstResigTermType").prop("disabled", true);
    $("#lstFilingDate").prop("disabled", true);        
    
    if (sessionStorage.getItem("ElectionType").toString() == "6") {
        // HIDE ELECTION DATE
        $("#divElectionDate").hide();
        // HIDE CUTT OF DATE
        $("#divReportPeriodDates").hide();
        // Hide Filing Date for Off Cycle
        $("#divFilingDateDropDown").show();
        if (sessionStorage.getItem("lstFilingDate") != null) {
            if (sessionStorage.getItem("lstFilingDate").toString() == "- New Filing Date -") {
                //// SHOW FILING DATE
                //$("#divReportPeriodDatesTo").show();        

                // SHOW NEW FILING DATE - ITS ONLY FOR OFF-CYLCLE.
                $("#divFilingDateOffCycle").show();
                // HIDE TO DATE FOR OTHER THAN OFF-CYLCE SELECTED.
                $("#divReportPeriodDatesTo").hide();
            }
            else {
                // SHOW NEW FILING DATE - ITS ONLY FOR OFF-CYLCLE.
                $("#divFilingDateOffCycle").hide();
                // HIDE TO DATE FOR OTHER THAN OFF-CYLCE SELECTED.
                $("#divReportPeriodDatesTo").hide();

                //// HIDE FILING DATE
                //$("#divReportPeriodDatesTo").hide();
            }
        }
        else {
            //// SHOW FILING DATE
            //$("#divReportPeriodDatesTo").show();        

            // SHOW NEW FILING DATE - ITS ONLY FOR OFF-CYLCLE.
            $("#divFilingDateOffCycle").show();
            // HIDE TO DATE FOR OTHER THAN OFF-CYLCE SELECTED.
            $("#divReportPeriodDatesTo").hide();
        }        
    }
    else {

        if (sessionStorage.getItem("ElectionType").toString() == "4") { // PERIODIC
            // HIDE ELECTION DATE
            $("#divElectionDate").hide();
            // HIDE NEW FILING DATE.
            $("#divFilingDateOffCycle").hide();
            // Hide Filing Date for Off Cycle
            $("#divFilingDateDropDown").hide();
        }
        else {
            // SHOW ELECTION DATE
            $("#divElectionDate").show();
        }

        // SHOW CUTT OF DATE        
        $("#divReportPeriodDates").show();
        // Hide Filing Date for Off Cycle
        $("#divFilingDateDropDown").hide();
        // NEW FILING DATE
        $("#divFilingDateOffCycle").hide();
    }

    $("#divShowPartnerAdddataNCR").hide();

    $("#divShowAttributionSchedC").hide();

    $("#tdButtonUpdate").hide();

    $(".clsCommonSearch").hide();

    $("#txtReportPeriodDatesFrom").prop("disabled", true);
    $("#txtReportPeriodDatesTo").prop("disabled", true);
    $("#txtNewFilingDate").prop("disabled", true);

    $("#thParterShipNameInKind").hide("slow");
    $("#tdPartnershipNameInKind").hide("slow");

    if (sessionStorage.getItem("ElectionType").toString() == "6") {
        // RESIGNATION/TERMINATION MANDATORY WHEN OFF-CYCLE.
        $("#lblReasonforFiling").text("* Resignation/Termination");
    }
    else {
        // RESIGNATION/TERMINATION MANDATORY WHEN OFF-CYCLE.
        $("#lblReasonforFiling").text("Resignation/Termination");
    }        

    $('#txtFilerID').val(sessionStorage.getItem("FilerId").toString());
    $('#txtFilerType').val(sessionStorage.getItem("FilerTypeId"));
    $('#txtCommitteeName').val(sessionStorage.getItem("CommitteeName").toString());
    $('#lstElectionCycle').val(sessionStorage.getItem("ElectionCycle").toString());
    $('#lstUCOfficeType').val(sessionStorage.getItem("OfficeType").toString());
    $('#lstUCCounty').val(sessionStorage.getItem("County").toString());
    $('#lstUCMuncipality').val(sessionStorage.getItem("Municipality").toString());    
    $('#lstElectionType').val(sessionStorage.getItem("ElectionType").toString());    
    if (sessionStorage.getItem("ElectionType").toString() != "6") { // FOR OFF-CYCLE DON'T HAVE "ELECTION DATE" FROM POLITICAL CALANEDER.                        
        $('#lstElectionDate').val(sessionStorage.getItem("ElectionDate").toString());
    }    
    //$('#lstElectionDate').val(sessionStorage.getItem("ElectionDate").toString());        
    $('#lstDisclosureType').val(sessionStorage.getItem("DisclosureType").toString());
    $('#lstDisclosurePeriod').val(sessionStorage.getItem("DisclosurePeriod").toString());
    //$('#lstTransactionType').val(sessionStorage.getItem("TransactionType").toString());
    $("#lstTransactionType option").each(function () {
        if ($(this).val() == sessionStorage.getItem("TransactionType").toString()) {
            $(this).attr('selected', 'selected');
        }
    });
    if (sessionStorage.getItem("ElectionType").toString() == "6") {
        $('#lstResigTermType').val(sessionStorage.getItem("lstResigTermType").toString());
        if (sessionStorage.getItem("lstFilingDate") != null) {
            //var lstFilingDateCheck = sessionStorage.getItem("lstFilingDate").toString();            
            //if (lstFilingDateCheck.includes("/")) {                
            //    $('#lstFilingDate').text(sessionStorage.getItem("lstFilingDate").toString());
            //    $("#lstFilingDate")[0].selectedIndex = 0;
            //}
            //else {            
            //} 
            // WHILE DOING EDIT FROM VIEW ALL DISCLOSURE PAGE THE ID NOT COMING...
            // FOR OFF-CYCLE ONLY DATE SHOWING.
            var filingDateOffCycle = sessionStorage.getItem("lstFilingDate").toString();
            if (filingDateOffCycle.includes("/")) {
                $('#lstFilingDate').text(sessionStorage.getItem("lstFilingDate").toString());
            }
            else {
                $('#lstFilingDate').val(sessionStorage.getItem("lstFilingDate").toString());
            }
        }
        else {
            $('#lstFilingDate').val("- New Filing Date -");
        }
        $('#txtNewFilingDate').val(sessionStorage.getItem("FilingDate").toString());        
    }
    else {
        $('#lstResigTermType').val(sessionStorage.getItem("lstResigTermType").toString());
        $('#txtReportPeriodDatesFrom').val(sessionStorage.getItem("CutOffDate").toString());
        $('#txtReportPeriodDatesTo').val(sessionStorage.getItem("FilingDate").toString());
    }        

    $('#lstTransactionType').focus();
    
    $("#lblHeader").text(sessionStorage.getItem("DisclosureTypeText").toString());
    $("#lblHEleYear").text(sessionStorage.getItem("ElectionCycleText").toString());
    $("#lblHDisclPer").text(sessionStorage.getItem("DisclosurePeriodText").toString());

    $('#lstUCOfficeType').prop("disabled", true);
    $('#lstUCCounty').prop("disabled", true);
    $('#lstUCMuncipality').prop("disabled", true);

    if (sessionStorage.getItem("OfficeType").toString() == "1") {
        $("#divCounty").hide();
        $("#divMunicipality").hide();
    }
    else {
        $("#divCounty").hide();
        $("#divMunicipality").hide();
    }

    $(".clsCommonSearch").hide();

    //$("#main").addClass("SetHeightCandInd");
    //$("#main").removeClass("SetHeight");

    //Show Hide Lookups
    $("#divshow").hide();
    $("#divshowForMobile").hide();        

    $m(".clsbtnCommonHideShow").bind('click', function (e) {
        if (sessionStorage.getItem('setDataTable') != "null") {
            //$m('#ContributionsMonetaryGrid').DataTable().ajax.reload();
            //$m('#PartnersGridMonetary').DataTable().ajax.reload();
        }

        $("#selectorItsRpt").toggle("slow");
        $("#divhide").show("slow");
        $("#divshow").hide("slow");

        $("#divhideForMobile").show("slow");
        $("#divshowForMobile").hide("slow");

        $("#divGrid").addClass("Per80hideShowButtonCSS");
        $("#divGrid").removeClass("Per100hideShowButtonCSS");


        $("#divShowPartnerAdddataNCR").addClass("Per80hideShowButtonCSS");
        $("#divShowPartnerAdddataNCR").removeClass("Per100hideShowButtonCSS");

        $("#divShowPartnerAdddataInKind").addClass("Per80hideShowButtonCSS");
        $("#divShowPartnerAdddataInKind").removeClass("Per100hideShowButtonCSS");

        $("#divShowSubcontroctor").addClass("Per80hideShowButtonCSS");
        $("#divShowSubcontroctor").removeClass("Per100hideShowButtonCSS");

        $("#divShowReimbursement").addClass("Per80hideShowButtonCSS");
        $("#divShowReimbursement").removeClass("Per100hideShowButtonCSS");

        $("#divShowCreditCardPayment").addClass("Per80hideShowButtonCSS");
        $("#divShowCreditCardPayment").removeClass("Per100hideShowButtonCSS");

    });

    $("#btnShowHide").click(function () {
        if ($("#divShowHide").is(":hidden")) {
            $("#divMainNew").removeClass("mainDivNew");
            $("#divMainNew").addClass("mainDiv");

        } else {
            $("#divMainNew").removeClass("mainDiv");
            $("#divMainNew").addClass("mainDivNew");
        }
    });

    $m(".clsbtnCommonShowHide").bind('click', function (e) {
        if (sessionStorage.getItem('setDataTable') != "null") {
            //$m('#ContributionsMonetaryGrid').DataTable().ajax.reload();
            //$m('#PartnersGridMonetary').DataTable().ajax.reload();
        }
        $("#selectorItsRpt").toggle("slow");
        $("#divhide").hide("slow");
        $("#divshow").show("slow");

        $("#divhideForMobile").hide("slow");
        $("#divshowForMobile").show("slow");

        $("#divGrid").addClass("Per100hideShowButtonCSS");
        $("#divGrid").removeClass("Per80hideShowButtonCSS");

        $("#ContributionsMonetaryGrid").addClass("Per100hideShowButtonCSS");
        $("#ContributionsMonetaryGrid").removeClass("Per80hideShowButtonCSS");

        $("#PartnersGridShechA").addClass("Per100hideShowButtonCSS");
        $("#PartnersGridShechA").removeClass("Per80hideShowButtonCSS");

        $("#PartnersGridSchedD").addClass("Per100hideShowButtonCSS");
        $("#PartnersGridSchedD").removeClass("Per80hideShowButtonCSS");

        $("#gridReimbursementSchedQ").addClass("Per100hideShowButtonCSS");
        $("#gridReimbursementSchedQ").removeClass("Per80hideShowButtonCSS");

        $("#gridCreditCardPaymentSchedF").addClass("Per100hideShowButtonCSS");
        $("#gridCreditCardPaymentSchedF").removeClass("Per80hideShowButtonCSS");

        $("#thdGrid").addClass("Per100hideShowButtonCSS");
        $("#thdGrid").removeClass("Per80hideShowButtonCSS");

        $("#divShowPartnerAdddataNCR").addClass("Per100hideShowButtonCSS");
        $("#divShowPartnerAdddataNCR").removeClass("Per80hideShowButtonCSS");

        $("#divShowPartnerAdddataInKind").addClass("Per100hideShowButtonCSS");
        $("#divShowPartnerAdddataInKind").removeClass("Per80hideShowButtonCSS");

        $("#divShowSubcontroctor").addClass("Per100hideShowButtonCSS");
        $("#divShowSubcontroctor").removeClass("Per80hideShowButtonCSS");

        $("#divShowReimbursement").addClass("Per100hideShowButtonCSS");
        $("#divShowReimbursement").removeClass("Per80hideShowButtonCSS");

        $("#divShowCreditCardPayment").addClass("Per100hideShowButtonCSS");
        $("#divShowCreditCardPayment").removeClass("Per80hideShowButtonCSS");

    });

}

function PartnershipValidation(partnershipVal) {
    // FORM VALIDATION SCHEDULE 'A' PARTNERSHIP JQUERY VALIDATOR
    //----------------------------------------------------------------------------------------------------------------------------------------------
    var validator = $m("#" + partnershipVal).validate({
        onfocusout: function (element) {
            $m(element).valid();
        },
        rules: {
            txtPartnerName: {
                required: true,
                EntityNameValidate: true
            },
            txtSubcontractorName: {
                required: true,
                EntityNameValidate: true
            },
            txtPartFirstName: {
                required: true,
                NameValidatePartnerDet: true
            },
            txtPartMI: {
                NameValidatePartnerDet: true
            },
            txtPartLastName: {
                required: true,
                NameValidatePartnerDet: true
            },
            txtCountryPartnership: {
                required: function () {
                    return $('#chkCountryPartnership').is(':checked')
                },
                AlphabetsVal: function () {
                    return $('#chkCountryPartnership').is(':checked')
                }
            },
            txtPartStreetName: {
                required: true,
                ValidateAlphaNumericAddress: true,
                minlength: 4
            },
            txtPartCity: {
                required: true,
                ValidateAlphaSpecialPart: true,
                AlphaSpecialNumOtherCntryParty: true
            },
            txtPartState: {
                required: true,
                AlphaSpecialStateOtherCntryPart: true,
                AlphabetsValStatePart: true,
                State2LettersValPart: true
            },
            txtPartZip5: {
                required: true,
                FomatZipcodePart: true,
                OtherCountryZipVal: true
            },
            txtPartAmt: {
                required: true,
                number: true,
                AmountValidatePart: true,
                Amount12DigitValPart: true,
                AmountZeroValPart: true
            },
            txtPartAmtAC: {
                required: true,
                number: true,
                AmountValidatePart: true,
                Amount12DigitValPartAC: true,
                AmountZeroValPartSchedAC: true
            },
            txtPartAmtSchedD: {
                required: true,
                number: true,
                AmountValidatePart: true,
                Amount12DigitValPartD: true,
                AmountZeroValPartSchedD: true
            },
            txtPartAmtSchedF: {
                required: true,
                number: true,
                AmountValidatePart: true,
                Amount12DigitValPartF: true,
                AmountZeroValPartSchedF: true
            },
            txtPartAmtSchedP: {
                required: true,
                number: true,
                AmountValidatePart: true,
                Amount12DigitValPartP: true,
                AmountZeroValPartSchedP: true
            },
            txtPartExplanationInKind: {
                ValidateAlphaNumericAddress: true
            },
            txtPartExplanationEP: {
                ValidateAlphaNumericAddress: true
            },
            txtPartEmployer: {
                ValidateAlphaNumericAddress: true
            },
            txtPartOccupation: {
                ValidateAlphaNumericAddress: true
            },
            txtPartContStreetName: {
                ValidateAlphaNumericAddress: true,
                minlength: 4
            },
            txtPartContCity: {
                ValidateAlphaNumericAddress: true,
                AlphaSpecialNumOtherCntry: true
            },
            txtPartContState: {
                ValidateAlphaNumericAddress: true,
                AlphabetsValState: true,
                State2LettersVal: true
            },
            txtPartContZipCode: {
                FomatZipcode: true,
                OtherCountryZipVal: true
            }
        },
        invalidHandler: function (form, validator) {
            var errors = validator.numberOfInvalids();
            if (errors) {
                validator.errorList[0].element.focus();
            }
        },
        errorPlacement: function (error, element) {
            var trigger = element.next('.ui-datepicker-trigger');
            error.insertBefore(trigger.length > 0 ? trigger : element);
        },
        messages: {
            txtPartnerName: {
                required: function () {
                    if ($("#lblPartnerName").text().toString() == "* Partner Name") {
                        return "Error: Partner Name is required";
                    }
                    else if ($("#lblPartnerName").text().toString() == "* Member Name") {
                        return "Error: Member Name is required";
                    }
                    else {
                        return "Error: Partner Name is required";
                    }
                },
                EntityNameValidate: "Error: Letters, numbers and characters '# -.,&() are allowed"
                //NameValidatePartnerDet: function () {                
                //    //if ($("#lstTransactionType option:selected").val().toString() == "1" || $("#lstTransactionType option:selected").val().toString() == "4" || $("#lstTransactionType option:selected").val().toString() == "16" || $("#lstTransactionType option:selected").val().toString() == "9") {
                //    //    return "Letters, numbers and characters '# -.,& are allowed";
                //    //}
                //    //else {
                //    //    return "Letters, numbers and characters '# -., are allowed";
                //    //}
                //}
                //"Letters, numbers and characters '# -., are allowed"
            },
            txtCurrentDatePartAttr: {
                required: "Error: Date is required",
            },
            txtSubcontractorName: {
                required: "Error: Subcontractor Name is required",
                EntityNameValidate: "Error: Letters, numbers and characters '# -.,&() are allowed"
            },
            txtPartFirstName: {
                required: "Error: First Name is required",
                NameValidatePartnerDet: function () {
                    if ($("#lstTransactionType option:selected").val().toString() == "1" || $("#lstTransactionType option:selected").val().toString() == "4" || $("#lstTransactionType option:selected").val().toString() == "16" || $("#lstTransactionType option:selected").val().toString() == "9") {
                        return "Letters, numbers and characters '# -.,& are allowed";
                    }
                    else {
                        return "Letters, numbers and characters '# -., are allowed";
                    }
                }
            },
            txtPartMI: {
                NameValidatePartnerDet: function () {
                    if ($("#lstTransactionType option:selected").val().toString() == "1" || $("#lstTransactionType option:selected").val().toString() == "4" || $("#lstTransactionType option:selected").val().toString() == "16" || $("#lstTransactionType option:selected").val().toString() == "9") {
                        return "Error: Letters, numbers and characters '# -.,& are allowed";
                    }
                    else {
                        return "Error: Letters, numbers and characters '# -., are allowed";
                    }
                }
            },
            txtPartLastName: {
                required: "Error: Last Name is required",
                NameValidatePartnerDet: function () {
                    if ($("#lstTransactionType option:selected").val().toString() == "1" || $("#lstTransactionType option:selected").val().toString() == "4" || $("#lstTransactionType option:selected").val().toString() == "16" || $("#lstTransactionType option:selected").val().toString() == "9") {
                        return "Letters, numbers and characters '# -.,& are allowed";
                    }
                    else {
                        return "Letters, numbers and characters '# -., are allowed";
                    }
                }
            },
            txtCountryPartnership: {
                required: "Error: Country is required",
                AlphabetsVal: "Error: Letters are allowed"
            },
            txtPartStreetName: {
                required: "Error: Street Address is required",
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed",
                minlength: "Error: Street Address must contain at least four characters"
            },
            txtPartCity: {
                required: "Error: City is required",
                ValidateAlphaSpecialPart: "Error: Letters and characters '# -., are allowed",
                AlphaSpecialNumOtherCntryParty: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtPartState: {
                required: "Error: State is required",
                AlphaSpecialStateOtherCntryPart: "Error: Letters, numbers and characters '# -., are allowed",
                AlphabetsValStatePart: "Error: Two letters are allowed",
                State2LettersValPart: "Error: Two letters are allowed"
            },
            txtPartZip5: {
                required: "Error: Zip Code is required",
                FomatZipcodePart: "Error: Numbers and - are allowed",
                OtherCountryZipVal: "Error: Letters, numbers and - are allowed"
            },
            txtPartAmt: {
                required: "Error: Amount Attributed is required",
                number: "Error: Enter valid Amount (999999999.99)",
                AmountValidatePart: "Error: Enter valid Amount (999999999.99)",
                Amount12DigitValPart: "Error: Enter valid Amount (999999999.99)",
                AmountZeroValPart: "Error: Enter valid Amount (999999999.99)"
            },
            txtPartAmtAC: {
                required: "Error: Amount Attributed is required",
                number: "Error: Enter valid Amount (999999999.99)",
                AmountValidatePart: "Error: Enter valid Amount (999999999.99)",
                Amount12DigitValPartAC: "Error: Enter valid Amount (999999999.99)",
                AmountZeroValPartSchedAC: "Error: Enter valid Amount (999999999.99)"
            },
            txtPartAmtSchedD: {
                required: "Error: Amount Attributed is required",
                number: "Error: Enter valid Amount (999999999.99)",
                AmountValidatePart: "Error: Enter valid Amount (999999999.99)",
                Amount12DigitValPartD: "Error: Enter valid Amount (999999999.99)",
                AmountZeroValPartSchedD: "Error: Enter valid Amount (999999999.99)"
            },
            txtPartAmtSchedF: {
                required: "Error: Amount Attributed is required",
                number: "Error: Enter valid Amount (999999999.99)",
                AmountValidatePart: "Error: Enter valid Amount (999999999.99)",
                Amount12DigitValPartF: "Error: Enter valid Amount (999999999.99)",
                AmountZeroValPartSchedF: "Error: Enter valid Amount (999999999.99)"
            },
            txtPartAmtSchedP: {
                required: "Error: Amount Attributed is required",
                number: "Error: Enter valid Amount (999999999.99)",
                AmountValidatePart: "Error: Enter valid Amount (999999999.99)",
                Amount12DigitValPartP: "Error: Enter valid Amount (999999999.99)",
                AmountZeroValPartSchedP: "Error: Enter valid Amount (999999999.99)"
            },
            txtPartExplanationInKind: {
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtPartExplanationEP: {
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtPartEmployer: {
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtPartOccupation: {
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtPartContStreetName: {
                //required: "Error: Street Address is required",
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed",
                minlength: "Error: Street Address must contain at least four characters"
            },
            txtPartContCity: {
                //required: "Error: City is required",
                ValidateAlphaNumericAddress: "Error: Letters and characters '# -., are allowed",
                AlphaSpecialNumOtherCntry: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtPartContState: {
                //required: "Error: State is required",
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed",
                AlphabetsValState: "Error: Two letters are allowed",
                State2LettersVal: "Error: Two letters are allowed"
            },
            txtPartContZipCode: {
                //required: "Error: Zip Code is required",
                FomatZipcode: "Error: Numbers and - are allowed",
                OtherCountryZipVal: "Error: Letters, numbers and - are allowed"
            }
        },
        errorPlacement: function (error, element) {
            var name = $(element).attr("name");
            error.appendTo($("#" + name + "_validate"));
        },
    });

    //--------------------------------------------------------------------------------------------------------------------------------------------------------
    // Country Partnership Check Box......
    // Checkbox Checked or Not
    $("#chkCountryPartnership").click(function () {
        if ($('#chkCountryPartnership').is(':checked')) { // Other COUNTRY Partnership
            $("#txtCountryPartnership").val("");
            $("#txtCountryPartnership").prop("disabled", false);
            $("#txtCountryPartnership").focus();
            $("#txtPartState").prop('maxLength', '30');
            $("#txtPartZip5").val('').removeClass('watermark');
            $m('#txtPartZip5').attr("placeholder", "");

            // Clear Address
            $("#txtPartStreetName").val("");
            $("#txtPartCity").val("");
            $("#txtPartState").val("");
            $("#txtPartZip5").val("");
            // Validate
            $m("#txtPartStreetName").valid();
            $m("#txtPartCity").valid();
            $m("#txtPartState").valid();
            $m("#txtPartZip5").valid();
        }
        else {// United States Country
            $("#txtCountryPartnership").val("United States");
            $m("#txtCountryPartnership").valid();
            $("#txtCountryPartnership").prop("disabled", true);
            $("#txtPartState").prop('maxLength', '2');
            $("#txtPartState").val("");

            if ($("#txtCountryPartnership").val().toString() == "United States") {
                $m(this).valid();
            }

            // Clear Address
            $("#txtPartStreetName").val("");
            $("#txtPartCity").val("");
            $("#txtPartState").val("");
            $("#txtPartZip5").val("");
            $("#txtPartZip5").blur();
            // Validate
            $m("#txtPartStreetName").valid();
            $m("#txtPartCity").valid();
            $m("#txtPartState").valid();
            $m("#txtPartZip5").valid();
        }
    });
    // Country Check Box......
    //--------------------------------------------------------------------------------------------------------------------------------------------------------
}

// REIMBURSEMENT DETAILS VALIDATION///////
function ValidateReimburesementDetails(reimbursementVal) {
    // FORM VALIDATION SCHEDULE 'A' PARTNERSHIP JQUERY VALIDATOR
    //----------------------------------------------------------------------------------------------------------------------------------------------
    var validator = $m("#" + reimbursementVal).validate({
        onfocusout: function (element) {
            $m(element).valid();
        },
        rules: {
            txtCurrentDateSchedQReim: {
                required: true,
                dateUS: true,
                ValCutOffDateSchedQReim: true
            },
            txtCurrentDateReimDetSchedF: {
                required: true,
                dateUS: true,
                ValCutOffDateReimDetSchedF: true
            },
            txtDetailsPayeeNameReim: {
                required: true,
                EntityNameValidate: true
            },
            txtCountryReim: {
                required: function () {
                    return $('#chkCountryReim').is(':checked')
                },
                AlphabetsVal: function () {
                    return $('#chkCountryReim').is(':checked')
                }
            },
            txtStreetNameReim: {
                required: true,
                ValidateAlphaNumericAddress: true,
                minlength: 4
            },
            txtCityReim: {
                required: true,
                ValidateAlphaSpecialReim: true,
                AlphaSpecialNumOtherCntryReim: true
            },
            txtStateReim: {
                required: true,
                AlphaSpecialStateOtherCntryReim: true,
                AlphabetsValStateReim: true,
                State2LettersValReim: true
            },
            txtZipCodeReim: {
                required: true,
                FomatZipcodeReim: true,
                OtherCountryZipVal: true
            },
            lstPurposeCodeReim: {
                PurposeCodeValReim: true
            },
            txtAmtReim: {
                required: true,
                number: true,
                AmountValidateReim: true,
                Amount12DigitValReim: true,
                AmountZeroValReim: true
            },
            txtExplanationSchedQReim: {
                required: function () {
                    if ($("#lstPurposeCodeReim option:selected").val().toString() == "8") {
                        return true;
                    }
                    else {
                        return false;
                    }
                },
                ValidateAlphaNumericAddress: true
            }
        },
        errorPlacement: function (error, element) {
            var trigger = element.next('.ui-datepicker-trigger');
            error.insertBefore(trigger.length > 0 ? trigger : element);
        },
        messages: {
            txtCurrentDateSchedQReim: {
                required: "Error: Date Paid is required",
                dateUS: "Error: Enter valid date format (MM/DD/YYYY)",
                ValCutOffDateSchedQReim: "Error: Date Paid cannot be later than Cut Off Date"
            },
            txtCurrentDateReimDetSchedF: {
                required: "Error: Date Paid is required",
                dateUS: "Error: Enter valid date format (MM/DD/YYYY)",
                ValCutOffDateReimDetSchedF: "Error: Date Paid cannot be later than Cut Off Date"
            },
            txtDetailsPayeeNameReim: {
                required: "Error: Details Payee Name is required",
                EntityNameValidate: "Error: Letters, numbers and characters '# -.,&() are allowed"
            },
            txtCountryReim: {
                required: "Error: Country is required",
                AlphabetsVal: "Error: Letters are allowed"
            },
            txtStreetNameReim: {
                required: "Error: Street Address is required",
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed",
                minlength: "Error: Street Address must contain at least four characters"
            },
            txtCityReim: {
                required: "Error: City is required",
                ValidateAlphaSpecialReim: "Error: Letters and characters '# -., are allowed",
                AlphaSpecialNumOtherCntryReim: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtStateReim: {
                required: "Error: State is required",
                AlphaSpecialStateOtherCntryReim: "Error: Letters, numbers and characters '# -., are allowed",
                AlphabetsValStateReim: "Error: Two letters are allowed",
                State2LettersValReim: "Error: Two letters are allowed"
            },
            txtZipCodeReim: {
                required: "Error: Zip Code is required",
                FomatZipcodeReim: "Error: Numbers and - are allowed",
                OtherCountryZipVal: "Error: Letters, numbers and - are allowed"
            },
            lstPurposeCodeReim: {
                PurposeCodeValReim: "Error: Purpose Code is required"
            },
            txtAmtReim: {
                required: "Error: Amount is required",
                number: "Error: Enter valid Amount (999999999.99)",
                AmountValidateReim: "Error: Enter valid Amount (999999999.99)",
                Amount12DigitValReim: "Error: Enter valid Amount (999999999.99)",
                AmountZeroValReim: "Error: Enter valid Amount (999999999.99)"
            },
            txtExplanationSchedQReim: {
                required: "Error: Explanation is required",
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed"
            }
        },
        errorPlacement: function (error, element) {
            var name = $(element).attr("name");
            error.appendTo($("#" + name + "_validate"));
        },
    });

    // REIMBURSEMENT DETAILS SCHEDULE 'F' DATE VALIDATION.
    $m.validator.addMethod("ValCutOffDateReimDetSchedF", function (value, element) {
        var cuttofDate = $("#txtReportPeriodDatesFrom").val().toString();
        var dateReceived = $("#txtCurrentDateReimDetSchedF").val().toString();
        var d1 = new Date(cuttofDate);
        var d2 = new Date(dateReceived);
        if (d2 > d1)
            return false;
        else
            return true;
    });

    //--------------------------------------------------------------------------------------------------------------------------------------------------------
    // Country Partnership Check Box......
    // Checkbox Checked or Not
    $("#chkCountryReim").click(function () {
        if ($('#chkCountryReim').is(':checked')) { // Other COUNTRY Partnership
            $("#txtCountryReim").val("");
            $("#txtCountryReim").prop("disabled", false);
            $("#txtCountryReim").focus();
            $("#txtStateReim").prop('maxLength', '30');
            $("#txtZipCodeReim").val('').removeClass('watermark');
            $m('#txtZipCodeReim').attr("placeholder", "");

            // Clear Address
            $("#txtStreetNameReim").val("");
            $("#txtCityReim").val("");
            $("#txtStateReim").val("");
            $("#txtZipCodeReim").val("");
            // Validate
            $m("#txtStreetNameReim").valid();
            $m("#txtCityReim").valid();
            $m("#txtStateReim").valid();
            $m("#txtZipCodeReim").valid();
        }
        else {// United States Country
            $("#txtCountryReim").val("United States");
            $m("#txtCountryReim").valid();
            $("#txtCountryReim").prop("disabled", true);
            $("#txtStateReim").prop('maxLength', '2');
            $("#txtStateReim").val("");

            if ($("#txtCountryReim").val().toString() == "United States") {
                $m(this).valid();
            }

            // Clear Address
            $("#txtStreetNameReim").val("");
            $("#txtCityReim").val("");
            $("#txtStateReim").val("");
            $("#txtZipCodeReim").val("");
            $("#txtZipCodeReim").blur();
            // Validate
            $m("#txtStreetNameReim").valid();
            $m("#txtCityReim").valid();
            $m("#txtStateReim").valid();
            $m("#txtZipCodeReim").valid();
        }
    });
    // Country Partnership Check Box......
    //--------------------------------------------------------------------------------------------------------------------------------------------------------
}

function ValidateAmountAllocationItemization(amountAllocationVal) {
    // FORM VALIDATION SCHEDULE 'A' PARTNERSHIP JQUERY VALIDATOR
    //----------------------------------------------------------------------------------------------------------------------------------------------
    var validator = $m("#" + amountAllocationVal).validate({
        onfocusout: function (element) {
            $m(element).valid();
        },
        rules: {
            lstDiaSupportOppose: {
                lstDiaSupportOpposeVal: true
            },
            txtCurrentDateAllocatedSchedR: {
                required: true,
                dateUS: true,
                ValCutOffDateSchedR: true
            },
            txtLenderFirstName: {
                required: true,
                EntityNameValidate: true
            },
            txtLenderLastName: {
                required: true,
                EntityNameValidate: true
            },
            lstElectionCycleAllocated: {
                lstElectionCycleAllocatedVal: true
            },
            lstOffice: {
                lstOfficeVal: true
            },
            lstDistrict: {
                lstDistrictVal: true
            },
            txtAmtExpensesAllocation: {
                required: true,
                number: true,
                AmountValidateCCI: true,
                Amount12DigitValCCISchedR: true,
                AmountZeroValCCISchedR: true
            }
        },
        errorPlacement: function (error, element) {
            var trigger = element.next('.ui-datepicker-trigger');
            error.insertBefore(trigger.length > 0 ? trigger : element);
        },
        messages: {
            lstDiaSupportOppose: {
                lstDiaSupportOpposeVal: "Error: Support or Oppose is required"
            },
            txtCurrentDateAllocatedSchedR: {
                required: "Error: Date Allocated is required",
                dateUS: "Error: Enter valid date format (MM/DD/YYYY)",
                ValCutOffDateSchedR: "Error: Date Allocated cannot be later than Cut Off Date"
            },
            txtLenderFirstName: {
                required: "Error: First Name is required",
                EntityNameValidate: "Error: Letters, numbers and characters '# -.,&() are allowed"
            },
            txtLenderLastName: {
                required: "Error: Last Name is required",
                EntityNameValidate: "Error: Letters, numbers and characters '# -.,&() are allowed"
            },
            lstElectionCycleAllocated: {
                lstElectionCycleAllocatedVal: "Error: Election year is required"
            },
            lstOffice: {
                lstOfficeVal: "Error: Office is required"
            },
            lstDistrict: {
                lstDistrictVal: "Error: District is required"
            },
            txtAmtExpensesAllocation: {
                required: "Error: Amount is required",
                number: "Error: Enter valid Amount (999999999.99)",
                AmountValidateCCI: "Error: Enter valid Amount (999999999.99)",
                Amount12DigitValCCISchedR: "Error: Enter valid Amount (999999999.99)",
                AmountZeroValCCISchedR: "Error: Enter valid Amount (999999999.99)"
            }
        },
        errorPlacement: function (error, element) {
            var name = $(element).attr("name");
            error.appendTo($("#" + name + "_validate"));
        },
    });
}

// CREDIT CARD ITEMIZATION VALIDATION///////
function ValidateCreditCardItemization(ccItemVal) {
    // FORM VALIDATION SCHEDULE 'A' PARTNERSHIP JQUERY VALIDATOR
    //----------------------------------------------------------------------------------------------------------------------------------------------
    var validator = $m("#" + ccItemVal).validate({
        onfocusout: function (element) {
            $m(element).valid();
        },
        rules: {
            txtCurrentDateSchedQCCI: {
                required: true,
                dateUS: true,
                ValCutOffDateSchedQCCI: true
            },
            txtDetailsPayeeNameCCI: {
                required: true,
                EntityNameValidate: true
            },
            txtCountryCCI: {
                required: function () {
                    return $('#chkCountryCCI').is(':checked')
                },
                AlphabetsVal: function () {
                    return $('#chkCountryCCI').is(':checked')
                }
            },
            txtStreetNameCCI: {
                required: true,
                ValidateAlphaNumericAddress: true,
                minlength: 4
            },
            txtCityCCI: {
                required: true,
                ValidateAlphaSpecialCCI: true,
                AlphaSpecialNumOtherCntryCCI: true
            },
            txtStateCCI: {
                required: true,
                AlphaSpecialStateOtherCntryCCI: true,
                AlphabetsValStateCCI: true,
                State2LettersValCCI: true
            },
            txtZipCodeCCI: {
                required: true,
                FomatZipcodeCCI: true,
                OtherCountryZipVal: true
            },
            lstPurposeCodeCCI: {
                PurposeCodeValCCI: true
            },
            txtAmountCCI: {
                required: true,
                number: true,
                AmountValidateCCI: true,
                Amount12DigitValCCI: true,
                AmountZeroValCCI: true
            },
            txtExplanationCCI: {
                required: function () {
                    if ($("#lstPurposeCodeCCI option:selected").val().toString() == "8") {
                        return true;
                    }
                    else {
                        return false;
                    }
                },
                ValidateAlphaNumericAddress: true
            }
        },
        errorPlacement: function (error, element) {
            var trigger = element.next('.ui-datepicker-trigger');
            error.insertBefore(trigger.length > 0 ? trigger : element);
        },
        messages: {
            txtCurrentDateSchedQCCI: {
                required: "Error: Date Paid is required",
                dateUS: "Error: Enter valid date format (MM/DD/YYYY)",
                ValCutOffDateSchedQCCI: "Error: Date Paid cannot be later than Cut Off Date"
            },
            txtDetailsPayeeNameCCI: {
                required: "Error: Details Payee Name is required",
                EntityNameValidate: "Error: Letters, numbers and characters '# -.,&() are allowed"
            },
            txtCountryCCI: {
                required: "Error: Country is required",
                AlphabetsVal: "Error: Letters are allowed"
            },
            txtStreetNameCCI: {
                required: "Error: Street Address is required",
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed",
                minlength: "Error: Street Address must contain at least four characters"
            },
            txtCityCCI: {
                required: "Error: City is required",
                ValidateAlphaSpecialCCI: "Error: Letters and characters '# -., are allowed",
                AlphaSpecialNumOtherCntryCCI: "Error: Letters, numbers and characters '# -., are allowed"
            },
            txtStateCCI: {
                required: "Error: State is required",
                AlphaSpecialStateOtherCntryCCI: "Error: Letters, numbers and characters '# -., are allowed",
                AlphabetsValStateCCI: "Error: Two letters are allowed",
                State2LettersValCCI: "Error: Two letters are allowed"
            },
            txtZipCodeCCI: {
                required: "Error: Zip Code is required",
                FomatZipcodeCCI: "Error: Numbers and - are allowed",
                OtherCountryZipVal: "Error: Letters, numbers and - are allowed"
            },
            lstPurposeCodeCCI: {
                PurposeCodeValCCI: "Error: Purpose Code is required"
            },
            txtAmountCCI: {
                required: "Error: Amount is required",
                number: "Error: Enter valid Amount (999999999.99)",
                AmountValidateCCI: "Error: Enter valid Amount (999999999.99)",
                Amount12DigitValCCI: "Error: Enter valid Amount (999999999.99)",
                AmountZeroValCCI: "Error: Enter valid Amount (999999999.99)"
            },
            txtExplanationCCI: {
                required: "Error: Explanation is required",
                ValidateAlphaNumericAddress: "Error: Letters, numbers and characters '# -., are allowed"
            }
        },
        errorPlacement: function (error, element) {
            var name = $(element).attr("name");
            error.appendTo($("#" + name + "_validate"));
        },
    });

    //--------------------------------------------------------------------------------------------------------------------------------------------------------
    // Country Credit Card Itemization Check Box......
    // Checkbox Checked or Not
    $("#chkCountryCCI").click(function () {
        if ($('#chkCountryCCI').is(':checked')) { // Other COUNTRY Partnership
            $("#txtCountryCCI").val("");
            $("#txtCountryCCI").prop("disabled", false);
            $("#txtCountryCCI").focus();
            $("#txtStateCCI").prop('maxLength', '30');
            $("#txtZipCodeCCI").val('').removeClass('watermark');
            $m('#txtZipCodeCCI').attr("placeholder", "");

            // Clear Address
            $("#txtStreetNameReim").val("");
            $("#txtCityReim").val("");
            $("#txtStateCCI").val("");
            $("#txtZipCodeCCI").val("");
            // Validate
            $m("#txtStreetNameReim").valid();
            $m("#txtCityCCI").valid();
            $m("#txtStateCCI").valid();
            $m("#txtZipCodeCCI").valid();
        }
        else {// United States Country
            $("#txtCountryCCI").val("United States");
            $m("#txtCountryCCI").valid();
            $("#txtCountryCCI").prop("disabled", true);
            $("#txtStateCCI").prop('maxLength', '2');
            $("#txtStateCCI").val("");

            if ($("#txtCountryCCI").val().toString() == "United States") {
                $m(this).valid();
            }

            // Clear Address
            $("#txtStreetNameCCI").val("");
            $("#txtCityCCI").val("");
            $("#txtStateCCI").val("");
            $("#txtZipCodeCCI").val("");
            $("#txtZipCodeCCI").blur();
            // Validate
            $m("#txtStreetNameCCI").valid();
            $m("#txtCityCCI").valid();
            $m("#txtStateCCI").valid();
            $m("#txtZipCodeCCI").valid();
        }
    });
    // Country Partnership Check Box......
    //--------------------------------------------------------------------------------------------------------------------------------------------------------
}

function FilterValidation(filterVal) {
    // FORM VALIDATION SCHEDULE 'A' PARTNERSHIP JQUERY VALIDATOR
    //----------------------------------------------------------------------------------------------------------------------------------------------
    var validator = $m("#" + filterVal).validate({
        onfocusout: function (element) { $m(element).valid(); },
        rules: {
            txtFilerID: {
                required: true
            },
            txtCommitteeName: {
                required: true
            },
            lstElectionCycle: {
                required: function () {                    
                    if ($("#lstElectionCycle option:selected").text().toString() == "- Select -") {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
            },
            lstUCOfficeType: {
                FilerTypeRequired: true
            },
            lstUCCounty: {
                CountyRequired: true
            },
            lstUCMuncipality: {
                MuncipalityRequired: true
            },
            lstElectionType: {
                ElectionTypeRequired: true
            },
            lstElectionDate: {
                ElectionDateRequired: true
            },
            lstDisclosureType: {
                DisclosureTypeRequired: true
            },
            lstDisclosurePeriod: {
                DisclosurePeriodRequired: true
            },
            txtReportPeriodDatesFrom: {
                required: true
            },
            txtNewFilingDate: {
                required: true,
                dateUS: true,
                filingDateValidation: true
            },
            lstResigTermType: {
                ResignationTerminationVal: function () {
                    if ($("#lblReasonforFiling").text().toString() == "* Resignation/Termination") {
                        return true;
                    }
                    else {
                        return false;
                    }
                }                
            },
            lstFilingDate: {
                FilingDateVal: true
            }
        },
        //errorPlacement: function (error, element) {
        //    var trigger = element.next('.ui-datepicker-trigger');
        //    error.insertBefore(trigger.length > 0 ? trigger : element);
        //},
        messages: {
            txtFilerID: {
                required: "Error: Filer Id is required"
            },
            txtCommitteeName: {
                required: "Error: Candidate/Committee Name Name is required"
            },
            lstElectionCycle: {
                required: "Error: Report Year is Required"
            },
            lstUCOfficeType: {
                FilerTypeRequired: "Error: Election Type is Required"
            },
            lstUCCounty: {
                CountyRequired: "Error: County is Required"
            },
            lstUCMuncipality: {
                MuncipalityRequired: "Error: Muncipality is Required"
            },
            lstElectionType: {
                ElectionTypeRequired: "Error: Report Type is Required"
            },
            lstElectionDate: {
                ElectionDateRequired: "Error: Election Date is Required"
            },
            lstDisclosureType: {
                DisclosureTypeRequired: "Error: Disclosure Type is Required"
            },
            lstDisclosurePeriod: {
                DisclosurePeriodRequired: "Error: Disclosure Period is Required"
            },
            txtReportPeriodDatesFrom: {
                required: "Error: Cut off Date is Required"
            },
            txtNewFilingDate: {
                required: function () {
                    if ($("#lstElectionType option:selected").val().toString() == "6") {
                        return "Error: New Filing Date is Required"
                    }
                    else {
                        return "Error: Filing Date is Required"
                    }
                }, //"Filing Date is Required",
                dateUS: "Error: Enter valid date format (MM/DD/YYYY)",
                filingDateValidation: "Error: Filing Date within Report Year"
            },
            lstResigTermType: {
                ResignationTerminationVal: "Error: Resignation/Termination is Required"
            },
            lstFilingDate: {
                FilingDateVal: "Error: Filing Date is Required"
            }
        },
        invalidHandler: function (form, Validator) {
            var errors = Validator.numberOfInvalids();
            if (errors) {
                Validator.errorList[0].element.focus();
            }
        },
        errorPlacement: function (error, element) {
            //Set a unique id for the lael based on the element's id
            var uniqueID = $(element).attr('id') + "ValidatorError";
            error.attr('id', uniqueID);
            //Remove any old labels mathing the unique ids
            if ($m("#" + uniqueID).length != 0) {
                $m("#" + uniqueID).remove();
            }
            //Insert the new error label.
            $(error).insertBefore(element);
        },
        //invalidHandler: function (form, validator) {
        //    var errors = validator.numberOfInvalids();
        //    if (errors) {
        //        validator.errorList[0].element.focus();
        //    }
        //},
        //errorPlacement: function (error, element) {
        //    $(error).insertBefore(element);
        //}
    });

    // Report Year Required.
    $m.validator.addMethod("ElectionCycleRequired", function (value, element) {        
        if ($m("#lstElectionCycle option:selected").val().toString() == "- Select -") {
            return true;
        }
        else {
            return false;
        }   
    });

    // Filer Type Required.
    $m.validator.addMethod("FilerTypeRequired", function (value, element) {
        if ($("#lstUCOfficeType option:selected").text().toString() != "- Select -")
            return true;
        else
            return false;
    });

    // County Required.
    $m.validator.addMethod("CountyRequired", function (value, element) {
        if ($("#lstUCOfficeType option:selected").val().toString() == "2") {
            if ($("#lstUCCounty option:selected").text().toString() != "- Select -") {
                return true;
            }   
            else {
                return false;
            }
        }
        else {
            return false;
        }   
    });

    // Muncipality Required
    $m.validator.addMethod("MuncipalityRequired", function (value, element) {
        if ($("#lstUCMuncipality option:selected").text().toString() != "- Select -")
            return true;
        else
            return false;
    });

    // Election Type Required
    $m.validator.addMethod("ElectionTypeRequired", function (value, element) {
        if ($("#lstElectionType option:selected").text().toString() != "- Select -")
            return true;
        else
            return false;
    });

    // Election Date Required
    $m.validator.addMethod("ElectionDateRequired", function (value, element) {
        if ($("#lstElectionDate option:selected").text().toString() != "- Select -")
            return true;
        else
            return false;
    });

    // Disclosure Type Required
    $m.validator.addMethod("DisclosureTypeRequired", function (value, element) {
        if ($("#lstDisclosureType option:selected").text().toString() != "- Select -")
            return true;
        else
            return false;
    });

    // Disclosure Period Required.
    $m.validator.addMethod("DisclosurePeriodRequired", function (value, element) {
        if ($("#lstDisclosurePeriod option:selected").text().toString() != "- Select -")
            return true;
        else
            return false;
    });

    // Resignation/Termination Required
    $m.validator.addMethod("ResignationTerminationVal", function (value, element) {
        //if ($("#ResignationTerminationVal option:selected").text().toString() != "- Select -") {
            if ($("#lstElectionType option:selected").val().toString() == "6") {
                if ($("#lstDisclosureType option:selected").val().toString() != "7" && $("#lstDisclosureType option:selected").val().toString() != "9" && $("#lstDisclosureType option:selected").val().toString() != "10" && $("#lstDisclosureType option:selected").val().toString() != "12" && $("#lstDisclosureType option:selected").val().toString() != "3" && $("#lstDisclosureType option:selected").val().toString() != "2") { // CHANGED ON 07/07/2020.                
                    if ($("#lstResigTermType option:selected").text().toString() != "- Not Applicable -") {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    return true;
                }
            }
            else {
                return true;
            }
        //}
    });


    // Filing Date Required
    $m.validator.addMethod("FilingDateVal", function (value, element) {
        if ($("#lstElectionType option:selected").val().toString() == "6") {
            if ($("#lstFilingDate option:selected").text().toString() != "- Select -") {
                return true;
                //if ($("#lstFilingDate option:selected").text().toString() != "- New Filing Date -") {
                //    return true;
                //}                
            }
            else {
                return false;
            }
        }
        else {
            if ($("#lstDisclosureType option:selected").val().toString() == "7" ||
                $("#lstDisclosureType option:selected").val().toString() == "14" ||
                $("#lstDisclosureType option:selected").val().toString() == "10" || $("#lstDisclosureType option:selected").val().toString() == "9" || $("#lstDisclosureType option:selected").val().toString() == "12" || $("#lstDisclosureType option:selected").val().toString() == "6") { // ADDED CAMPAIGN MATERIALS (6) TO DO FILING DATE FOR PRIMARY YEAR 2021 ABOVE.
                if ($("#lstFilingDate option:selected").text().toString() != "- Select -") {
                    return true;
                    //if ($("#lstFilingDate option:selected").text().toString() != "- New Filing Date -") {
                    //    return true;
                    //}                
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        }
    });

    // FILING DATE VALIDAITON FOR OFF-CYCLE    
    $m.validator.addMethod("filingDateValidation", function (value, element) {

        if ($("#lstElectionType option:selected").val().toString() == "6") {
            if ($("#txtNewFilingDate").val().toString() != "") {
                var electionDate = $("#lstElectionCycle option:selected").text().toString();
                var filingDate = $("#txtNewFilingDate").val().toString();

                var fromDate = '01' + '/' + '01' + '/' + electionDate;
                var toDate = '12' + '/' + '31' + '/' + electionDate;

                var filingDateVal = new Date(filingDate);
                var fromDateVal = new Date(fromDate);
                var toDateVal = new Date(toDate);

                if ((filingDateVal >= fromDateVal) && (filingDateVal <= toDateVal)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        else {
            if ($("#lstDisclosureType option:selected").val().toString() == "7" ||
                $("#lstDisclosureType option:selected").val().toString() == "14" ||
                $("#lstDisclosureType option:selected").val().toString() == "10" || $("#lstDisclosureType option:selected").val().toString() == "9" || $("#lstDisclosureType option:selected").val().toString() == "12" || $("#lstDisclosureType option:selected").val().toString() == "6") { // ADDED CAMPAIGN MATERIALS (6) TO DO FILING DATE FOR PRIMARY YEAR 2021 ABOVE.
                if ($("#txtNewFilingDate").val().toString() != "") {
                    var electionDate = $("#lstElectionCycle option:selected").text().toString();
                    var filingDate = $("#txtNewFilingDate").val().toString();

                    var fromDate = '01' + '/' + '01' + '/' + electionDate;
                    var toDate = '12' + '/' + '31' + '/' + electionDate;

                    var filingDateVal = new Date(filingDate);
                    var fromDateVal = new Date(fromDate);
                    var toDateVal = new Date(toDate);

                    if ((filingDateVal >= fromDateVal) && (filingDateVal <= toDateVal)) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
            }
        }
    });

    // DATE VALIDATION
    $m.validator.addMethod("dateUS", function (value, element) {
        var errormsg = "";
        var re = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
        if (re.test(value)) {
            var adata = value.split('/');
            var mm = parseInt(adata[0], 10);
            var dd = parseInt(adata[1], 10);
            var yyyy = parseInt(adata[2], 10);
            var xdata = new Date(yyyy, mm - 1, dd);
            if ((xdata.getFullYear() == yyyy) && (xdata.getMonth() == mm - 1) && (xdata.getDate() == dd))
                check = true;
            else {
                //check = false; Modified.
                check = false;
                errormsg = "Leap year date";
            }
        } else
            check = false;
        return this.optional(element) || check;
    }, "Invalid Date");

}

function NonItemizedLeftFilterValues() {

    $("#lblAllTransText24HNotice").text("All Transactions: " + sessionStorage.getItem("ElectionCycleText").toString());

    $("#lblAllTransTextIEWeeklyContr").text("All Transactions: " + sessionStorage.getItem("ElectionCycleText").toString());
    
    // Hide all Fileter
    $("#txtFilerID").prop("disabled", true);
    $("#txtFilerType").prop("disabled", true);
    $("#txtCommitteeName").prop("disabled", true);
    $("#lstElectionCycle").prop("disabled", true);
    $("#lstElectionType").prop("disabled", true);
    $("#lstUCOfficeType").prop("disabled", true);
    $("#lstElectionDate").prop("disabled", true);
    $("#lstDisclosureType").prop("disabled", true);
    $("#lstDisclosurePeriod").prop("disabled", true);
    $("#txtReportPeriodDatesFrom").prop("disabled", true);
    $("#txtReportPeriodDatesTo").prop("disabled", true);                        

    if (sessionStorage.getItem("DisclosureType").toString() == "2" || sessionStorage.getItem("DisclosureType").toString() == "3") {
        $("#txtNewFilingDate").prop("disabled", true);
        $("#lstResigTermType").prop("disabled", true);
        $("#lstFilingDate").prop("disabled", true);
    }

    if (sessionStorage.getItem("DisclosureType").toString() == "7" || sessionStorage.getItem("DisclosureType").toString() == "10" || sessionStorage.getItem("DisclosureType").toString() == "9" || sessionStorage.getItem("DisclosureType").toString() == "12" || sessionStorage.getItem("DisclosureType").toString() == "14") {
        $("#txtNewFilingDate").prop("disabled", true);
        $("#lstFilingDate").prop("disabled", true);
    }


    // HIDE DISCLSOURE PERIOD FOR NOTICE OF NON-PARTICIPATION, 24 HOUR NOTICE.
    if (sessionStorage.getItem("DisclosureType").toString() == "5" || sessionStorage.getItem("DisclosureType").toString() == "4" || sessionStorage.getItem("DisclosureType").toString() == "7" || sessionStorage.getItem("DisclosureType").toString() == "8" || sessionStorage.getItem("DisclosureType").toString() == "9" || sessionStorage.getItem("DisclosureType").toString() == "10" || sessionStorage.getItem("DisclosureType").toString() == "11" || sessionStorage.getItem("DisclosureType").toString() == "13" || sessionStorage.getItem("DisclosureType").toString() == "12") {
        $("#divDisclosurePeriod").hide();
    }
    else {
        $("#divDisclosurePeriod").show();
    }

    $("#divShowPartnerAdddataNCR").hide();

    $("#tdButtonUpdate").hide();

    $(".clsCommonSearch").hide();

    $("#txtReportPeriodDatesFrom").prop("disabled", true);
    $("#txtReportPeriodDatesTo").prop("disabled", true);
    $("#txtNewFilingDate").prop("disabled", true);

    $("#thParterShipNameInKind").hide("slow");
    $("#tdPartnershipNameInKind").hide("slow");

    // IE - WEEKLY NON-ITEMIZED TRANSACTIONS ITS ALWAYS NEW FILING DATE OR EXISTING FILING DATE.
    if (sessionStorage.getItem("DisclosureType").toString() == "7" || sessionStorage.getItem("DisclosureType").toString() == "10" || sessionStorage.getItem("DisclosureType").toString() == "9" || sessionStorage.getItem("DisclosureType").toString() == "12" || sessionStorage.getItem("DisclosureType").toString() == "14") {
        // Hide Filing Date for Off Cycle
        $("#divFilingDateDropDown").show();
        if (sessionStorage.getItem("lstFilingDate").toString() == "- New Filing Date -") {
            //// SHOW FILING DATE
            //$("#divReportPeriodDatesTo").show();        

            // SHOW NEW FILING DATE - ITS ONLY FOR OFF-CYLCLE.
            $("#divFilingDateOffCycle").show();
            // HIDE TO DATE FOR OTHER THAN OFF-CYLCE SELECTED.
            $("#divReportPeriodDatesTo").hide();
        }
        else {
            // SHOW NEW FILING DATE - ITS ONLY FOR OFF-CYLCLE.
            $("#divFilingDateOffCycle").hide();
            // HIDE TO DATE FOR OTHER THAN OFF-CYLCE SELECTED.
            $("#divReportPeriodDatesTo").hide();

            //// HIDE FILING DATE
            //$("#divReportPeriodDatesTo").hide();
        }
    }

    if (sessionStorage.getItem("DisclosureType").toString() == "2" || sessionStorage.getItem("DisclosureType").toString() == "7" || sessionStorage.getItem("DisclosureType").toString() == "9" || sessionStorage.getItem("DisclosureType").toString() == "10" || sessionStorage.getItem("DisclosureType").toString() == "12" || sessionStorage.getItem("DisclosureType").toString() == "3" || sessionStorage.getItem("DisclosureType").toString() == "14") {
        if (sessionStorage.getItem("ElectionType").toString() == "6") {
            // HIDE ELECTION DATE
            $("#divElectionDate").hide();
            // HIDE CUTT OF DATE
            $("#divReportPeriodDates").hide();
            // Hide Filing Date for Off Cycle
            $("#divFilingDateDropDown").show();
            if (sessionStorage.getItem("lstFilingDate").toString() == "- New Filing Date -") {
                //// SHOW FILING DATE
                //$("#divReportPeriodDatesTo").show();        

                // SHOW NEW FILING DATE - ITS ONLY FOR OFF-CYLCLE.
                $("#divFilingDateOffCycle").show();
                // HIDE TO DATE FOR OTHER THAN OFF-CYLCE SELECTED.
                $("#divReportPeriodDatesTo").hide();
            }
            else {
                // SHOW NEW FILING DATE - ITS ONLY FOR OFF-CYLCLE.
                $("#divFilingDateOffCycle").hide();
                // HIDE TO DATE FOR OTHER THAN OFF-CYLCE SELECTED.
                $("#divReportPeriodDatesTo").hide();
                // FILING DATE DROPDOWN.
                $("#divFilingDateDropDown").show();

                //// HIDE FILING DATE
                //$("#divReportPeriodDatesTo").hide();
            }
        }
        else {

            if (sessionStorage.getItem("ElectionType").toString() == "4") { // PERIODIC
                // HIDE ELECTION DATE
                $("#divElectionDate").hide();
                // HIDE NEW FILING DATE.
                $("#divFilingDateOffCycle").hide();
                // Hide Filing Date for Off Cycle
                $("#divFilingDateDropDown").hide();
            }
            else {
                // SHOW ELECTION DATE
                $("#divElectionDate").show();

                if (sessionStorage.getItem("ElectionType").toString() != "6") {
                    $("#divFilingDateOffCycle").hide();
                }
            }

            // SHOW CUTT OF DATE        
            $("#divReportPeriodDates").show();

            // Hide Filing Date for Off Cycle
            $("#divFilingDateDropDown").hide();
            // NEW FILING DATE
            //$("#divFilingDateOffCycle").hide();

            // IF IE WEEKLY THEN WE HAVE TO SHOW LIKE OFF-CYCLE FILING DATE.
            if (sessionStorage.getItem("DisclosureType").toString() == "7" || sessionStorage.getItem("DisclosureType").toString() == "9" || sessionStorage.getItem("DisclosureType").toString() == "10" || sessionStorage.getItem("DisclosureType").toString() == "12" || sessionStorage.getItem("DisclosureType").toString() == "14") {
                if (sessionStorage.getItem("lstFilingDate").toString() == "- New Filing Date -") {
                    //// SHOW FILING DATE
                    //$("#divReportPeriodDatesTo").show();        

                    // SHOW NEW FILING DATE - ITS ONLY FOR OFF-CYLCLE.
                    $("#divFilingDateOffCycle").show();
                    // HIDE TO DATE FOR OTHER THAN OFF-CYLCE SELECTED.
                    $("#divReportPeriodDatesTo").hide();
                }
                else {
                    // SHOW NEW FILING DATE - ITS ONLY FOR OFF-CYLCLE.
                    $("#divFilingDateOffCycle").hide();
                    // HIDE TO DATE FOR OTHER THAN OFF-CYLCE SELECTED.
                    $("#divReportPeriodDatesTo").hide();

                    $("#divFilingDateDropDown").show();

                    //// HIDE FILING DATE
                    //$("#divReportPeriodDatesTo").hide();
                }
            }
        }
    }

    if (sessionStorage.getItem("ElectionType").toString() == "8") {
        // HIDE ELECTION DATE.
        $("#divElectionDate").hide();
    }
    else {
        if (sessionStorage.getItem("ElectionType").toString() != "6") {
            if (sessionStorage.getItem("ElectionType").toString() == "4") { // PERIODIC NO ELECTION DATE TO SHOW.
                // SHOW ELECTION DATE.
                $("#divElectionDate").hide();
            }
            else {
                // SHOW ELECTION DATE.
                $("#divElectionDate").show();
            }
        }
    }

    $('#txtFilerID').val(sessionStorage.getItem("FilerId").toString());
    $('#txtFilerType').val(sessionStorage.getItem("FilerTypeId").toString());
    $('#txtCommitteeName').val(sessionStorage.getItem("CommitteeName").toString());
    $('#lstElectionCycle').val(sessionStorage.getItem("ElectionCycle").toString());
    $('#lstUCOfficeType').val(sessionStorage.getItem("OfficeType").toString());
    $('#lstUCCounty').val(sessionStorage.getItem("County").toString());
    $('#lstUCMuncipality').val(sessionStorage.getItem("Municipality").toString());
    $('#lstElectionType').val(sessionStorage.getItem("ElectionType").toString());
    $('#lstElectionDate').val(sessionStorage.getItem("ElectionDate").toString());
    
    // HIDE DISCLOSURE PERIOD WHEN IF PRIMARY 2021 AND ABOVE.
    var eleType = $("#lstElectionType").val().toString();
    var eleYear = parseInt($("#lstElectionCycle option:selected").text().toString());
    var valYear = parseInt("2021");
    if (eleType == "2") { // IF PRIMARY.
        if (eleYear >= valYear) { // IF 2021 AND ABOVE NO - 10-DAY POST PRIMARY.
            if (sessionStorage.getItem("DisclosurePeriod") != null) {
                if (sessionStorage.getItem("DisclosurePeriod").toString() == 'undefined') {
                    // HIDE THE DISCLOSURE PERIOD.
                    $("#lstDisclosurePeriod").empty();
                    $("#divDisclosurePeriod").hide();

                    // Hide Filing Date for Off Cycle
                    $("#divFilingDateDropDown").show();
                    if (sessionStorage.getItem("lstFilingDate").toString() == "- New Filing Date -") {
                        //// SHOW FILING DATE
                        //$("#divReportPeriodDatesTo").show();        

                        // SHOW NEW FILING DATE - ITS ONLY FOR OFF-CYLCLE.
                        $("#divFilingDateOffCycle").show();
                        // HIDE TO DATE FOR OTHER THAN OFF-CYLCE SELECTED.
                        $("#divReportPeriodDatesTo").hide();
                    }
                    else {
                        // SHOW NEW FILING DATE - ITS ONLY FOR OFF-CYLCLE.
                        $("#divFilingDateOffCycle").hide();
                        // HIDE TO DATE FOR OTHER THAN OFF-CYLCE SELECTED.
                        $("#divReportPeriodDatesTo").hide();

                        //// HIDE FILING DATE
                        //$("#divReportPeriodDatesTo").hide();
                    }

                    $('#lstFilingDate').val(sessionStorage.getItem("lstFilingDate").toString());
                    if (sessionStorage.getItem("lstFilingDate").toString() == "- New Filing Date -") {
                        $('#txtNewFilingDate').val(sessionStorage.getItem("FilingDate").toString());
                    }
                    $("#lstFilingDate").prop("disabled", true);
                }
                else {
                    // Hide Filing Date for Off Cycle
                    $("#divFilingDateDropDown").hide();
                    // SHOW NEW FILING DATE - ITS ONLY FOR OFF-CYLCLE.
                    $("#divFilingDateOffCycle").hide();
                    // HIDE TO DATE FOR OTHER THAN OFF-CYLCE SELECTED.
                    $("#divReportPeriodDatesTo").hide();
                }
            }
            else {
                // Hide Filing Date for Off Cycle
                $("#divFilingDateDropDown").hide();
                // SHOW NEW FILING DATE - ITS ONLY FOR OFF-CYLCLE.
                $("#divFilingDateOffCycle").hide();
                // HIDE TO DATE FOR OTHER THAN OFF-CYLCE SELECTED.
                $("#divReportPeriodDatesTo").hide();
            }
        }
        else {
            // Hide Filing Date for Off Cycle
            $("#divFilingDateDropDown").hide();
            // SHOW NEW FILING DATE - ITS ONLY FOR OFF-CYLCLE.
            $("#divFilingDateOffCycle").hide();
            // HIDE TO DATE FOR OTHER THAN OFF-CYLCE SELECTED.
            $("#divReportPeriodDatesTo").hide();
        }
    }    
    else {
        // Hide Filing Date for Off Cycle
        $("#divFilingDateDropDown").hide();
        // SHOW NEW FILING DATE - ITS ONLY FOR OFF-CYLCLE.
        $("#divFilingDateOffCycle").hide();
        // HIDE TO DATE FOR OTHER THAN OFF-CYLCE SELECTED.
        $("#divReportPeriodDatesTo").hide();
    }

    $('#lstDisclosureType').val(sessionStorage.getItem("DisclosureType").toString());
    if (sessionStorage.getItem("DisclosureType").toString() != "4" &&
        sessionStorage.getItem("DisclosureType").toString() != "7" &&
        sessionStorage.getItem("DisclosureType").toString() != "8" &&
        sessionStorage.getItem("DisclosureType").toString() != "9" &&
        sessionStorage.getItem("DisclosureType").toString() != "11" &&
        sessionStorage.getItem("DisclosureType").toString() != "13" &&
        sessionStorage.getItem("DisclosureType").toString() != "12" &&
        sessionStorage.getItem("DisclosureType").toString() != "14" &&
        sessionStorage.getItem("DisclosureType").toString() != "10") {
        $('#lstDisclosurePeriod').val(sessionStorage.getItem("DisclosurePeriod").toString());
    }
    if (sessionStorage.getItem("DisclosureType").toString() != "3" &&
        sessionStorage.getItem("DisclosureType").toString() != "2" &&
        sessionStorage.getItem("DisclosureType").toString() != "5" &&
        sessionStorage.getItem("DisclosureType").toString() != "14" &&
        sessionStorage.getItem("DisclosureType").toString() != "7") {
        if (sessionStorage.getItem("DisclosureType").toString() == "4" || sessionStorage.getItem("DisclosureType").toString() == "8" || sessionStorage.getItem("DisclosureType").toString() == "11" || sessionStorage.getItem("DisclosureType").toString() == "13") {
            $('#txtReportPeriodDatesTo').val(sessionStorage.getItem("FilingDate").toString());
            $('#txtReportPeriodDatesFrom').val(sessionStorage.getItem("CutOffDate").toString());
        }
        else if (sessionStorage.getItem("DisclosureType").toString() == "6") {
            $('#txtReportPeriodDatesTo').val(sessionStorage.getItem("CutOffDate").toString());
            $('#txtReportPeriodDatesFrom').val(sessionStorage.getItem("FilingDate").toString());

            $("#divDisclosurePeriod").hide();
            $("#divReportPeriodDates").hide();
            $("#divReportPeriodDatesTo").hide();

            // HIDE DISCLOSURE PERIOD WHEN IF PRIMARY 2021 AND ABOVE.
            eleType = $("#lstElectionType").val().toString();
            eleYear = parseInt($("#lstElectionCycle option:selected").text().toString());
            valYear = parseInt("2021");
            if (eleType == "2") { // IF PRIMARY.
                if (eleYear >= valYear) { // IF 2021 AND ABOVE NO - 10-DAY POST PRIMARY.
                    if (sessionStorage.getItem("DisclosurePeriod") != null) {
                        if (sessionStorage.getItem("DisclosurePeriod").toString() == 'undefined') {
                            // HIDE THE DISCLOSURE PERIOD.
                            $("#lstDisclosurePeriod").empty();
                            $("#divDisclosurePeriod").hide();

                            // Hide Filing Date for Off Cycle
                            $("#divFilingDateDropDown").show();
                            if (sessionStorage.getItem("lstFilingDate").toString() == "- New Filing Date -") {
                                //// SHOW FILING DATE
                                //$("#divReportPeriodDatesTo").show();        

                                // SHOW NEW FILING DATE - ITS ONLY FOR OFF-CYLCLE.
                                $("#divFilingDateOffCycle").show();
                                // HIDE TO DATE FOR OTHER THAN OFF-CYLCE SELECTED.
                                $("#divReportPeriodDatesTo").hide();
                            }
                            else {
                                // SHOW NEW FILING DATE - ITS ONLY FOR OFF-CYLCLE.
                                $("#divFilingDateOffCycle").hide();
                                // HIDE TO DATE FOR OTHER THAN OFF-CYLCE SELECTED.
                                $("#divReportPeriodDatesTo").hide();

                                //// HIDE FILING DATE
                                //$("#divReportPeriodDatesTo").hide();
                            }

                            $('#lstFilingDate').val(sessionStorage.getItem("lstFilingDate").toString());
                            if (sessionStorage.getItem("lstFilingDate").toString() == "- New Filing Date -") {
                                $('#txtNewFilingDate').val(sessionStorage.getItem("FilingDate").toString());
                            }
                            $("#lstFilingDate").prop("disabled", true);
                        }
                        else {
                            $("#divDisclosurePeriod").show();

                            // Hide Filing Date for Off Cycle
                            $("#divFilingDateDropDown").hide();
                            // SHOW NEW FILING DATE - ITS ONLY FOR OFF-CYLCLE.
                            $("#divFilingDateOffCycle").hide();
                            // HIDE TO DATE FOR OTHER THAN OFF-CYLCE SELECTED.
                            $("#divReportPeriodDatesTo").hide();
                        }
                    }
                    else {
                        $("#divDisclosurePeriod").show();

                        // Hide Filing Date for Off Cycle
                        $("#divFilingDateDropDown").hide();
                        // SHOW NEW FILING DATE - ITS ONLY FOR OFF-CYLCLE.
                        $("#divFilingDateOffCycle").hide();
                        // HIDE TO DATE FOR OTHER THAN OFF-CYLCE SELECTED.
                        $("#divReportPeriodDatesTo").hide();
                    }
                }
                else {
                    $("#divDisclosurePeriod").show();

                    // Hide Filing Date for Off Cycle
                    $("#divFilingDateDropDown").hide();
                    // SHOW NEW FILING DATE - ITS ONLY FOR OFF-CYLCLE.
                    $("#divFilingDateOffCycle").hide();
                    // HIDE TO DATE FOR OTHER THAN OFF-CYLCE SELECTED.
                    $("#divReportPeriodDatesTo").hide();
                }
            }
            else {
                $("#divDisclosurePeriod").show();
                
                // Hide Filing Date for Off Cycle
                $("#divFilingDateDropDown").hide();
                // SHOW NEW FILING DATE - ITS ONLY FOR OFF-CYLCLE.
                $("#divFilingDateOffCycle").hide();
                // HIDE TO DATE FOR OTHER THAN OFF-CYLCE SELECTED.
                $("#divReportPeriodDatesTo").hide();
            }
        }
        else {
            //$('#txtReportPeriodDatesFrom').val(sessionStorage.getItem("CutOffDate").toString());            
        }
    }


    // OFF-CYCLE FOR NO-ACTIVITY REPORT
    if (sessionStorage.getItem("DisclosureType").toString() == "2" || sessionStorage.getItem("DisclosureType").toString() == "3") {
        if (sessionStorage.getItem("ElectionType").toString() == "6") {
            $('#lstResigTermType').val(sessionStorage.getItem("lstResigTermType").toString());
            $('#lstFilingDate').val(sessionStorage.getItem("lstFilingDate").toString());
            $('#txtNewFilingDate').val(sessionStorage.getItem("FilingDate").toString());
        }
        else {
            $('#lstResigTermType').val(sessionStorage.getItem("lstResigTermType").toString());
            $('#txtReportPeriodDatesTo').val(sessionStorage.getItem("FilingDate").toString());
            $('#txtReportPeriodDatesFrom').val(sessionStorage.getItem("CutOffDate").toString());
        }
    }  
    //else if (sessionStorage.getItem("DisclosureType").toString() == "3") {
    //    $('#txtReportPeriodDatesTo').val(sessionStorage.getItem("FilingDate").toString());
    //    $('#txtReportPeriodDatesFrom').val(sessionStorage.getItem("CutOffDate").toString());
    //}


    // IE - WEEKLY NON-ITEMIZED TRANSACTIONS ITS ALWAYS NEW FILING DATE OR EXISTING FILING DATE.
    if (sessionStorage.getItem("DisclosureType").toString() == "7" || sessionStorage.getItem("DisclosureType").toString() == "10" || sessionStorage.getItem("DisclosureType").toString() == "9" || sessionStorage.getItem("DisclosureType").toString() == "12" || sessionStorage.getItem("DisclosureType").toString() == "14") {

        $('#lstFilingDate').val(sessionStorage.getItem("lstFilingDate").toString());
        
        if (sessionStorage.getItem("lstFilingDate").toString() == "- New Filing Date -") {
            $('#txtNewFilingDate').val(sessionStorage.getItem("FilingDate").toString());            
            $("#lstFilingDate").append("<option>" + sessionStorage.getItem("FilingDate").toString() + "</option>");
        }

        if (sessionStorage.getItem("ElectionType").toString() == "6") {
            $('#lstResigTermType').val(sessionStorage.getItem("lstResigTermType").toString());            
        }
        else {
            $('#lstResigTermType').val(sessionStorage.getItem("lstResigTermType").toString());            
        }
    }

    // SET THE HEADER TITLE.
    if (sessionStorage.getItem("DisclosureType").toString() != "12") {
        $("#lblHeader").text(sessionStorage.getItem("DisclosureTypeText").toString());
        $("#lblHeader1").text(sessionStorage.getItem("DisclosureTypeText").toString());        
    }
    else {
        $("#lblHeader").text("Independent Expenditure Weekly PIDA Expenditure");
    }
    $("#lblHEleYear").text(sessionStorage.getItem("ElectionCycleText").toString());

    if (sessionStorage.getItem("DisclosureType").toString() != "4" &&
        sessionStorage.getItem("DisclosureType").toString() != "7" &&
        sessionStorage.getItem("DisclosureType").toString() != "8" &&
        sessionStorage.getItem("DisclosureType").toString() != "9" &&
        sessionStorage.getItem("DisclosureType").toString() != "11" &&
        sessionStorage.getItem("DisclosureType").toString() != "13" &&
        sessionStorage.getItem("DisclosureType").toString() != "12" &&
        sessionStorage.getItem("DisclosureType").toString() != "14" &&
        sessionStorage.getItem("DisclosureType").toString() != "10") {
        if (sessionStorage.getItem("DisclosureType").toString() == "6") { // ONLY COMPAIGN MATERIALS.
            if (sessionStorage.getItem("DisclosurePeriodText").toString() != "- Select -") {
                if (sessionStorage.getItem("DisclosurePeriodText").toString() != "") {

                    var txtHyphan = " -";
                    var txtDisclosurePeriod = sessionStorage.getItem("DisclosurePeriodText").toString();
                    txtDisclosurePeriod = txtHyphan + " " + txtDisclosurePeriod;
                    //$("#lblHDisclPer").text(sessionStorage.getItem("DisclosurePeriodText").toString());
                    $("#lblHDisclPer").text(txtDisclosurePeriod);

                }
                else {
                    $("#lblHDisclPer").text(" - Primary");
                }
            }
            else {
                $("#lblHDisclPer").text("");
            }
        }
        else {
            if (sessionStorage.getItem("DisclosurePeriodText").toString() != "- Select -") {
                $("#lblHDisclPer").text(sessionStorage.getItem("DisclosurePeriodText").toString());
            }
            else {
                $("#lblHDisclPer").text("");
            }
        }
    }

    if (sessionStorage.getItem("DisclosureType").toString() != "3" &&
        sessionStorage.getItem("DisclosureType").toString() != "2" &&
        sessionStorage.getItem("DisclosureType").toString() != "5") {
        if (sessionStorage.getItem("ScheduleId") != null) {
            $('#lstTransactionTypeNonItem').val(sessionStorage.getItem("ScheduleId").toString());
            $('#lstTransactionTypeNonItem').focus();
        }
        else {
            $('#lstTransactionTypeNonItem').val(sessionStorage.getItem("lstTransactionTypeNonItem").toString());
            $('#lstTransactionTypeNonItem').focus();
        }
    }

    $('#lstUCOfficeType').prop("disabled", true);
    $('#lstUCCounty').prop("disabled", true);
    $('#lstUCMuncipality').prop("disabled", true);

    if (sessionStorage.getItem("OfficeType").toString() == "1") {
        $("#divCounty").hide();
        $("#divMunicipality").hide();
    }
    else {
        $("#divCounty").hide();
        $("#divMunicipality").hide();
    }

    // Non-Itemized Filter Values. Hide/Show
    var selectedDisclosureType = $("#lstDisclosureType option:selected").val().toString();
    if (selectedDisclosureType == "3125") { // REMOVED THIS CONDITION FOR IN-LIEU OF STATEMENT.
        $("#divReportPeriodDates").show();
        $("#divReportPeriodDatesTo").show();
    }
    else if (selectedDisclosureType == "4" || selectedDisclosureType == "8" || selectedDisclosureType == "11" || selectedDisclosureType == "13" || selectedDisclosureType == "6") {
        $("#divReportPeriodDates").show();
        $("#divReportPeriodDatesTo").show();
    }
    else if (selectedDisclosureType == "2" || selectedDisclosureType == "3") { // Show/Hide Based on Non-Itemized Transaction Disclosure Type.
        if (sessionStorage.getItem("ElectionType").toString() == "6") {
            $("#divReportPeriodDates").hide();
            $("#divReportPeriodDatesTo").hide();
        }
        else {
            $("#divReportPeriodDates").show();
            $("#divReportPeriodDatesTo").show();
        }

    }
    else {
        $("#divReportPeriodDates").hide();
        $("#divReportPeriodDatesTo").hide();
    }

    if (sessionStorage.getItem("DisclosureType").toString() == "6") {
        $("#divReportPeriodDates").hide();
        $("#divReportPeriodDatesTo").hide();

        // HIDE DISCLOSURE PERIOD WHEN IF PRIMARY 2021 AND ABOVE.
        eleType = $("#lstElectionType").val().toString();
        eleYear = parseInt($("#lstElectionCycle option:selected").text().toString());
        valYear = parseInt("2021");
        if (eleType == "2") { // IF PRIMARY.
            if (eleYear >= valYear) { // IF 2021 AND ABOVE NO - 10-DAY POST PRIMARY.
                if (sessionStorage.getItem("DisclosurePeriod") != null) {
                    if (sessionStorage.getItem("DisclosurePeriod").toString() == 'undefined') {
                        // HIDE THE DISCLOSURE PERIOD.
                        $("#lstDisclosurePeriod").empty();
                        $("#divDisclosurePeriod").hide();
                    }
                    else {
                        $("#divDisclosurePeriod").show();
                    }
                }
                else {
                    $("#divDisclosurePeriod").show();
                }
            }
            else {
                $("#divDisclosurePeriod").show();
            }
        }
        else {
            $("#divDisclosurePeriod").show();
        }
    }


    $(".clsCommonSearch").hide();

    //$("#main").addClass("SetHeightCandInd");
    //$("#main").removeClass("SetHeight");

    //Show Hide Lookups
    $("#divshow").hide();
    $("#divshowForMobile").hide();

    $m(".clsbtnCommonHideShow").bind('click', function (e) {
        if (sessionStorage.getItem('setDataTable') != "null") {
            //$m('#ContributionsMonetaryGrid').DataTable().ajax.reload();
            //$m('#PartnersGridMonetary').DataTable().ajax.reload();
        }

        $("#selectorItsRpt").toggle("slow");
        $("#divhide").show("slow");
        $("#divshow").hide("slow");

        $("#divhideForMobile").show("slow");
        $("#divshowForMobile").hide("slow");

        $("#divGrid").addClass("Per80hideShowButtonCSS");
        $("#divGrid").removeClass("Per100hideShowButtonCSS");

        $("#divShowInLieuOfStatement").addClass("Per80hideShowButtonCSS");
        $("#divShowInLieuOfStatement").removeClass("Per100hideShowButtonCSS");

        $("#divShowNoActivityReport").addClass("Per80hideShowButtonCSS");
        $("#divShowNoActivityReport").removeClass("Per100hideShowButtonCSS");

        $("#divShowNonParticipation").addClass("Per80hideShowButtonCSS");
        $("#divShowNonParticipation").removeClass("Per100hideShowButtonCSS");

        $("#divUC24HNoticeHistory").addClass("Per80hideShowButtonCSS");
        $("#divUC24HNoticeHistory").removeClass("Per100hideShowButtonCSS");

        $("#divUCIETransactionsHistory").addClass("Per80hideShowButtonCSS");
        $("#divUCIETransactionsHistory").removeClass("Per100hideShowButtonCSS");

    });

    $("#btnShowHide").click(function () {
        if ($("#divShowHide").is(":hidden")) {
            $("#divMainNew").removeClass("mainDivNew");
            $("#divMainNew").addClass("mainDiv");

        } else {
            $("#divMainNew").removeClass("mainDiv");
            $("#divMainNew").addClass("mainDivNew");
        }
    });

    $m(".clsbtnCommonShowHide").bind('click', function (e) {
        if (sessionStorage.getItem('setDataTable') != "null") {
            //$m('#ContributionsMonetaryGrid').DataTable().ajax.reload();
            //$m('#PartnersGridMonetary').DataTable().ajax.reload();
        }
        $("#selectorItsRpt").toggle("slow");
        $("#divhide").hide("slow");
        $("#divshow").show("slow");

        $("#divhideForMobile").hide("slow");
        $("#divshowForMobile").show("slow");

        $("#divGrid").addClass("Per100hideShowButtonCSS");
        $("#divGrid").removeClass("Per80hideShowButtonCSS");

        $("#gridInLieuOfStatement").addClass("Per100hideShowButtonCSS");
        $("#gridInLieuOfStatement").removeClass("Per80hideShowButtonCSS");

        $("#gridNoActivityReport").addClass("Per100hideShowButtonCSS");
        $("#gridNoActivityReport").removeClass("Per80hideShowButtonCSS");

        $("#gridNonParticipation").addClass("Per100hideShowButtonCSS");
        $("#gridNonParticipation").removeClass("Per80hideShowButtonCSS");

        $("#grid24HNoticeHistory").addClass("Per100hideShowButtonCSS");
        $("#grid24HNoticeHistory").removeClass("Per80hideShowButtonCSS");

        $("#gridIETransactionsHistory").addClass("Per100hideShowButtonCSS");
        $("#gridIETransactionsHistory").removeClass("Per80hideShowButtonCSS");

        $("#thdGrid").addClass("Per100hideShowButtonCSS");
        $("#thdGrid").removeClass("Per80hideShowButtonCSS");

        $("#divShowInLieuOfStatement").addClass("Per100hideShowButtonCSS");
        $("#divShowInLieuOfStatement").removeClass("Per80hideShowButtonCSS");

        $("#divShowNoActivityReport").addClass("Per100hideShowButtonCSS");
        $("#divShowNoActivityReport").removeClass("Per80hideShowButtonCSS");

        $("#divShowNonParticipation").addClass("Per100hideShowButtonCSS");
        $("#divShowNonParticipation").removeClass("Per80hideShowButtonCSS");

        $("#divIETransGrid").addClass("Per100hideShowButtonCSS");
        $("#divIETransGrid").removeClass("Per80hideShowButtonCSS");

        $("#divUC24HNoticeHistory").addClass("Per100hideShowButtonCSS");
        $("#divUC24HNoticeHistory").removeClass("Per80hideShowButtonCSS");

        $("#divUCIETransactionsHistory").addClass("Per100hideShowButtonCSS");
        $("#divUCIETransactionsHistory").removeClass("Per80hideShowButtonCSS");

    });

}

function ImportLeftFilterValues() {

    $("#divshow").hide();
    $("#divshowForMobile").hide();

    $m(".clsbtnCommonHideShow").bind('click', function (e) {
        if (sessionStorage.getItem('setDataTable') != "null") {
            //$m('#ContributionsMonetaryGrid').DataTable().ajax.reload();
            //$m('#PartnersGridMonetary').DataTable().ajax.reload();
        }

        $("#selectorItsRpt").toggle("slow");
        $("#divhide").show("slow");
        $("#divshow").hide("slow");

        $("#divhideForMobile").show("slow");
        $("#divshowForMobile").hide("slow");

        $("#divGrid").addClass("Per80hideShowButtonCSS");
        $("#divGrid").removeClass("Per100hideShowButtonCSS");

        $("#divShowInLieuOfStatement").addClass("Per80hideShowButtonCSS");
        $("#divShowInLieuOfStatement").removeClass("Per100hideShowButtonCSS");

        $("#divShowNoActivityReport").addClass("Per80hideShowButtonCSS");
        $("#divShowNoActivityReport").removeClass("Per100hideShowButtonCSS");

        $("#divShowNonParticipation").addClass("Per80hideShowButtonCSS");
        $("#divShowNonParticipation").removeClass("Per100hideShowButtonCSS");

        $("#divUC24HNoticeHistory").addClass("Per80hideShowButtonCSS");
        $("#divUC24HNoticeHistory").removeClass("Per100hideShowButtonCSS");

        $("#divUCIETransactionsHistory").addClass("Per80hideShowButtonCSS");
        $("#divUCIETransactionsHistory").removeClass("Per100hideShowButtonCSS");

    });

    $("#btnShowHide").click(function () {
        if ($("#divShowHide").is(":hidden")) {
            $("#divMainNew").removeClass("mainDivNew");
            $("#divMainNew").addClass("mainDiv");

        } else {
            $("#divMainNew").removeClass("mainDiv");
            $("#divMainNew").addClass("mainDivNew");
        }
    });

    $m(".clsbtnCommonShowHide").bind('click', function (e) {
        if (sessionStorage.getItem('setDataTable') != "null") {
            //$m('#ContributionsMonetaryGrid').DataTable().ajax.reload();
            //$m('#PartnersGridMonetary').DataTable().ajax.reload();
        }
        $("#selectorItsRpt").toggle("slow");
        $("#divhide").hide("slow");
        $("#divshow").show("slow");

        $("#divhideForMobile").hide("slow");
        $("#divshowForMobile").show("slow");

        $("#divGrid").addClass("Per100hideShowButtonCSS");
        $("#divGrid").removeClass("Per80hideShowButtonCSS");

        $("#gridInLieuOfStatement").addClass("Per100hideShowButtonCSS");
        $("#gridInLieuOfStatement").removeClass("Per80hideShowButtonCSS");

        $("#gridNoActivityReport").addClass("Per100hideShowButtonCSS");
        $("#gridNoActivityReport").removeClass("Per80hideShowButtonCSS");

        $("#gridNonParticipation").addClass("Per100hideShowButtonCSS");
        $("#gridNonParticipation").removeClass("Per80hideShowButtonCSS");

        $("#grid24HNoticeHistory").addClass("Per100hideShowButtonCSS");
        $("#grid24HNoticeHistory").removeClass("Per80hideShowButtonCSS");

        $("#gridIETransactionsHistory").addClass("Per100hideShowButtonCSS");
        $("#gridIETransactionsHistory").removeClass("Per80hideShowButtonCSS");

        $("#thdGrid").addClass("Per100hideShowButtonCSS");
        $("#thdGrid").removeClass("Per80hideShowButtonCSS");

        $("#divShowInLieuOfStatement").addClass("Per100hideShowButtonCSS");
        $("#divShowInLieuOfStatement").removeClass("Per80hideShowButtonCSS");

        $("#divShowNoActivityReport").addClass("Per100hideShowButtonCSS");
        $("#divShowNoActivityReport").removeClass("Per80hideShowButtonCSS");

        $("#divShowNonParticipation").addClass("Per100hideShowButtonCSS");
        $("#divShowNonParticipation").removeClass("Per80hideShowButtonCSS");

        $("#divIETransGrid").addClass("Per100hideShowButtonCSS");
        $("#divIETransGrid").removeClass("Per80hideShowButtonCSS");

        $("#divUC24HNoticeHistory").addClass("Per100hideShowButtonCSS");
        $("#divUC24HNoticeHistory").removeClass("Per80hideShowButtonCSS");

        $("#divUCIETransactionsHistory").addClass("Per100hideShowButtonCSS");
        $("#divUCIETransactionsHistory").removeClass("Per80hideShowButtonCSS");

    });




}

// BEGINNING OF CODE TO SORT TABLES BY DATE
//////////////////////////////////////
var TableLastSortedColumn = -1;
function SortTable() {
    var sortColumn = parseInt(arguments[0]);
    var type = arguments.length > 1 ? arguments[1] : 'T';
    var dateformat = arguments.length > 2 ? arguments[2] : '';
    var TableIDvalue = arguments.length > 3 ? arguments[3] : '';
    var table = document.getElementById(TableIDvalue);
    var tbody = table.getElementsByTagName("tbody")[0];
    var rows = tbody.getElementsByTagName("tr");
    var arrayOfRows = new Array();
    type = type.toUpperCase();
    dateformat = dateformat.toLowerCase();

    for (var i = 0, len = rows.length; i < len; i++) {
        arrayOfRows[i] = new Object;
        arrayOfRows[i].oldIndex = i;
        var celltext = rows[i].getElementsByTagName("td")[sortColumn].innerHTML.replace(/<[^>]*>/g, "");

        if (type == 'D') { arrayOfRows[i].value = GetDateSortingKey(dateformat, celltext); }
        else {
            var re = type == "N" ? /[^\.\-\+\d]/g : /[^a-zA-Z0-9]/g;
            arrayOfRows[i].value = celltext.replace(re, "").substr(0, 25).toLowerCase();
        }
    }
    if (sortColumn == TableLastSortedColumn) { arrayOfRows.reverse(); }
    else {
        TableLastSortedColumn = sortColumn;
        switch (type) {
            case "N": arrayOfRows.sort(CompareRowOfNumbers); break;
            case "D": arrayOfRows.sort(CompareRowOfNumbers); break;
            default: arrayOfRows.sort(CompareRowOfText);
        }
    }
    var newTableBody = document.createElement("tbody");
    for (var i = 0, len = arrayOfRows.length; i < len; i++) {
        newTableBody.appendChild(rows[arrayOfRows[i].oldIndex].cloneNode(true));
    }
} // function SortTable()

function CompareRowOfText(a, b) {
    var aval = a.value;
    var bval = b.value;
    return (aval == bval ? 0 : (aval > bval ? 1 : -1));
} // function CompareRowOfText()

function CompareRowOfNumbers(a, b) {
    var aval = /\d/.test(a.value) ? parseFloat(a.value) : 0;
    var bval = /\d/.test(b.value) ? parseFloat(b.value) : 0;
    return (aval == bval ? 0 : (aval > bval ? 1 : -1));
} // function CompareRowOfNumbers()

function GetDateSortingKey(format, text) {
    if (format.length < 1) { return ""; }
    format = format.toLowerCase();
    text = text.toLowerCase();
    text = text.replace(/^[^a-z0-9]*/, "");
    text = text.replace(/[^a-z0-9]*$/, "");
    if (text.length < 1) { return ""; }
    text = text.replace(/[^a-z0-9]+/g, ",");
    var date = text.split(",");
    if (date.length < 3) { return ""; }
    var d = 0, m = 0, y = 0;
    for (var i = 0; i < 3; i++) {
        var ts = format.substr(i, 1);
        if (ts == "d") { d = date[i]; }
        else if (ts == "m") { m = date[i]; }
        else if (ts == "y") { y = date[i]; }
    }
    d = d.replace(/^0/, "");
    if (d < 10) { d = "0" + d; }
    if (/[a-z]/.test(m)) {
        m = m.substr(0, 3);
        switch (m) {
            case "jan": m = String(1); break;
            case "feb": m = String(2); break;
            case "mar": m = String(3); break;
            case "apr": m = String(4); break;
            case "may": m = String(5); break;
            case "jun": m = String(6); break;
            case "jul": m = String(7); break;
            case "aug": m = String(8); break;
            case "sep": m = String(9); break;
            case "oct": m = String(10); break;
            case "nov": m = String(11); break;
            case "dec": m = String(12); break;
            default: m = String(0);
        }
    }
    m = m.replace(/^0/, "");
    if (m < 10) { m = "0" + m; }
    y = parseInt(y);
    if (y < 100) { y = parseInt(y) + 2000; }
    return "" + String(y) + "" + String(m) + "" + String(d) + "";
} // function GetDateSortingKey()
////////////////////////////////////////////////////////////////
// END OF CODE TO SORT TABLES BY DATE



