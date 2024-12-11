/**boe.accessibility-helper.common.js 
 * Provides functions simplify the implementation of accessibility features in shared views.
 * User accessibility is inteded to meet WCAG 2.0 compliance.
 * Version key major-minor-bug fix
 * Version 1.0.2 - Last formal update 11/02/2021
 * Author Jorge Diaz
 * */

/**
 * Implements datepicker, datatables accessibility features.
 * For best results call this function inside the pages $(document).ready(function () {
 * */
function boeA11yHelperImplementCommonAccessibilityFeatures() {
    try {
        if (typeof boe_makeAllDatePickersAccessible === "function") {
            //Make accessible all datePickers currently initialized.
            boe_makeAllDatePickersAccessible();
        }
        if (typeof extendBootstrap3Navbar === "function") {
            //Adds functionality for subMenuDropDowns
            extendBootstrap3Navbar(false);
        }
        if (typeof $m.fn.dataTable.moment === "function") {
            //Enable datatables to use datetime-momment plugin to sort dates.
            $m.fn.dataTable.moment('MM/DD/YYYY');
        }
    } catch (e) {
        console.error("Error: boe.accessibility-helper.common.js boeA11yHelperImplementCommonAccessibilityFeatures");
        console.error(e);
    }
}

/**
 * Allows users to set delayed focus on Elements after an interval
 * @param {Element} element
 * @param {int} secondsDelay
 */
let boeA11yHelperSetDelayedFocus = function (element, secondsDelay) {
    if (element) {
        var miliseconds = isNaN(secondsDelay) ? 0 : secondsDelay * 1000;
        setTimeout(function () {
            element.focus();
        }, miliseconds);
    } else {
        console.warn("Warning: boe.accessibility-helper.common.js boeA11yHelperSetDelayedFocus unable to set focus");
    }
};