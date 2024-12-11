/**
 * jquery-ui-datePicker-accessibility-helper.js
 * Provides functions to increase jquery-ui-1.12.1 (or higher) user accessibility.
 * User accessibility is inteded to meet WCAG 2.0 compliance.
 * It is based on the Deque University accessible date picker available in 5/29/2020
 * https://dequeuniversity.com/library/aria/date-picker
 * Some of the original code have been maintained in it's original form and modifications have been made to use our custom functions which are prefixed with "boe_".
 * jquery-ui-datePicker-accessibility-helper.js
 * Version key major.minor.patch
 * Version 2.1.7 - Last formal update 01/13/2023
 * Requires jquery-ui-1.12.1 (or higher).
 * Requires jquery-3.5.0 (or higher).
 * Author Jorge Diaz
 * 
 * To use include this js file in build and add the method ("boe_makeAllDatePickersAccessible();") to the first line of the <script>$m(document).ready(function () {}<.script> in a _MasterLayout.cshtml page or to any page that calls the @RenderBody().
 * The function will/should execute after the body is rendered.
 * The function boe_checkAndCorrectCommonInitializationIssues will attemp to notify issues that cannot be resolved automatically in code.
 * 
 * Known Issues:
 * - You cannot extend because the current version of datepicker does not use the widget factory.
 * - In boe_findDayToFocus() when the date picker is not able to find the current date it will default to the last available date to select. This could be improved to get the date closest to the maxDate or minDate.
 * Test HTML and javascript code:
    <div style="width:50%">
        <span id="lblTestPicker">Test Picker('")</span>
        <input type="text" id="testPicker" name="testPicker" class="datepicker " maxlength="10" aria-labelledby="lblTestPicker" style="width:50%;" required="required" />
        <br/>
        <button id="testPickerDisable" type="button">Disable</button>
        <button id="testPickerEnable" type="button" >Enable</button>
    </div>
    <div style="width:50%">
        <input type="text" id="testPickerNoLabel" name="testPickerNoLabel" class="datepicker " maxlength="10" placeholder="MM/DD/YYYY" style="width:50%;" required="required" />
        <br />
        <button id="testPickerNoLabelDisable" type="button">Disable</button>
        <button id="testPickerNoLabelEnable" type="button">Enable</button>
    </div>
    $m("#testPicker").datepicker({
        showOn: "button",
        buttonImage: "../../Content/Images/Calendar.png",
        buttonImageOnly: false,
        buttonText: "Select From Date",
        changeMonth: true,
        changeYear: true,
        numberOfMonths: 1,
        maxDate: 0,
        dateFormat: 'mm/dd/yy',
        onChange: function () {
            console.log("On Change");
        },
        onSelect: function () {
            console.log("On Select");
        }
    }).datepicker();
    $m("#testPickerDisable").on("click", function(){
        $m( "#testPicker" ).datepicker( "option", "disabled", true);
    });
    $m("#testPickerEnable").on("click", function(){
        $m( "#testPicker" ).datepicker( "option", "disabled", false );
    });
        $m("#testPickerNoLabel").datepicker({
        showOn: "button",
        buttonImage: "../../Content/Images/Calendar.png",
        buttonImageOnly: false,
        buttonText: "Select From Date",
        changeMonth: true,
        changeYear: true,
        numberOfMonths: 1,
        maxDate: 0,
        dateFormat: 'mm/dd/yy',
        onChange: function () {
            console.log("On Change");
        },
        onSelect: function () {
            console.log("On Select");
        }
    }).datepicker();
    $m("#testPickerNoLabelDisable").on("click", function () {
        $m("#testPickerNoLabel").datepicker("option", "disabled", true);
    });
    $m("#testPickerNoLabelEnable").on("click", function () {
        $m("#testPickerNoLabel").datepicker("option", "disabled", false);
    });
 */

var $m = jQuery.noConflict();
const DEBUG_MODE = false;
const CALENDAR_BUTTON_SUFIX = "DatepickerCalendarButton";
/////////////////////////////////////////////////////////
//START Modified Deque University Accessibility Code calling "boe_" functions.
/////////////////////////////////////////////////////////
/**
 * Called from onClose: function in DatePicker initialization.
 */
function removeAria() {
    //Make the rest of the page accessible again:
    $m("#dp-container").removeAttr('aria-hidden');
    $m("#skipnav").removeAttr('aria-hidden');
}

///////////////////////////////
//////////////////////////// //
///////////////////////// // //
// UTILITY-LIKE THINGS // // //
///////////////////////// // //
//////////////////////////// //
///////////////////////////////
function isOdd(num) {
    return num % 2;
}
/**
 * Locates and sets focus to start or end of the month.
 * @param {element} target - The DOM element, located from a click or keydown, keyVent.target.
 * @param {string} startEnd - Supported 'start' and 'end'
 */
function boe_focusStartOrEndOfMonth(target, startEnd) {
    var dayToFocus = false;
    switch (startEnd) {
        case "start":
            dayToFocus = $m(target).closest('tbody').find('.ui-state-default')[0];
            break;
        case "end":
            var $daysOfMonth = $m(target).closest('tbody').find('.ui-state-default');
            dayToFocus = $daysOfMonth[$daysOfMonth.length - 1];
            break;
        default:
            console.warn("jquery-ui-datePicker-accessibility-helper: boe_focusStartOrEndOfMonth - Unsuported startEnd '" + startEnd + "'!");
            break;
    }
    if (dayToFocus) {
        dayToFocus.focus();
        setHighlightState(dayToFocus, $m('#ui-datepicker-div')[0]);
    }
}

/**
 * Locates the active date in the calendard grid and selects it
 * @param {event} keyVent - The event from a click or keydown.
 * @param {element} target - The DOM element, located from a click or keydown, keyVent.target.
 */
function boe_handleArrowKey(keyVent, target) {
    var which = keyVent.which;
    var container = document.getElementById('ui-datepicker-div');
    if (!$m(target).hasClass('ui-datepicker-close') && $m(target).hasClass('ui-state-default')) {
        keyVent.preventDefault();
        switch (which) {
            case 37:// LEFT arrow key
                previousDay(target);
                break;
            case 38:// UP arrow key
                upHandler(target, container);
                break;
            case 39:// RIGHT arrow key
                nextDay(target);
                break;
            case 40:// DOWN arrow key
                downHandler(target, container);
                break;
            default:
                console.warn("jquery-ui-datePicker-accessibility-helper: boe_handleArrowKey - Unsuported keyVent '" + which + "'!");
                break;
        }
    }
}

/**
 * Locates the active date in the calendard grid and selects it
 */
function boe_focusActiveDate() {
    var activeDate = $m('.ui-state-highlight') || $m('.ui-state-active')[0];
    // We focus on a date/day link button
    if (activeDate) {
        activeDate.focus();
    } else {
        console.warn("jquery-ui-datePicker-accessibility-helper:  boe_focusActiveDate, Unable to focus active date!");

    }
}

/**
 * Locates the 'next' button  in the calendard grid and selects it
 */
function boe_focusNext() {
    //If we have a next link and it is not disabled
    if ($m('.ui-datepicker-next').attr("aria-disabled") != "true") {
        $m('.ui-datepicker-next')[0].focus(); // We focus on the 'Next' month button
    } else {
        //We try to focus on the active date/day link button
        boe_focusActiveDate();
    }
}

/**
 * Locates the 'prev' button  in the calendard grid and selects it
 */
function boe_focusPrev() {
    // If we have a 'Prev' month link and it is not disabled
    if ($m('.ui-datepicker-prev').attr("aria-disabled") != "true") {
        $m('.ui-datepicker-prev')[0].focus(); // We focus on the 'Prev' month button
    } else {
        //We try to focus on the active date/day link button
        boe_focusActiveDate();
    }
}

/**
 * Locates and sets tab focus in a clockwise direction.
 * @param {element} target - The DOM element, located from a click or keydown, keyVent.target.
 */
function boe_determineTabFocusClockWise(target) {
    //Debug console.log("jquery-ui-datePicker-accessibility-helper: DEBUG boe_determineTabFocusClockWise!");
    var hasMonthSelect = typeof $m('select.ui-datepicker-month')[0] != "undefined";
    var hasYearSelect = typeof $m('select.ui-datepicker-year')[0] != "undefined";
    var classList = $m(target).attr('class').split(/\s+/);
    //TAB + SHIFT key expected to move focus right
    if (classList.includes('ui-datepicker-close')) { // From the 'Close' dialog button
        //We focus on the 'Prev' month button
        $m('.ui-datepicker-prev')[0].focus();
    } else if (classList.includes('ui-datepicker-prev')) { // From the 'Prev' month link
        if (hasMonthSelect) {// If we have a 'Month' select dropdown
            $m('select.ui-datepicker-month')[0].focus(); // We focus on the 'Month' select dropdown
        } else if (hasYearSelect) {// If we have a 'Year' select dropdown
            $m('select.ui-datepicker-year')[0].focus(); // We focus on the 'Year' select dropdown
        } else {
            // We try to focus on the 'Next' month button
            boe_focusNext();
        }
    } else if (classList.includes('ui-datepicker-month')) { // From the 'Month' select dropdown
        if (hasYearSelect) { // If we have a year select
            $m('select.ui-datepicker-year')[0].focus(); // We focus on the 'Year' select dropdown
        } else {
            // We try to focus on the 'Next' month button
            boe_focusNext();
        }
    } else if (classList.includes('ui-datepicker-year')) { // From the 'Year' select dropdown
        // We try to focus on the 'Next' month button
        boe_focusNext();
    } else if (classList.includes('ui-datepicker-next')) { // From the 'Next' month button
        //We try to focus on the active date/day link button
        boe_focusActiveDate();
    } else if (classList.includes('ui-state-default')) { // From a date/day link button
        //We focus on the 'Close' dialog button
        $m('.ui-datepicker-close')[0].focus();
    } else {
        console.warn("jquery-ui-datePicker-accessibility-helper:  boe_determineTabFocusClockWise, Unable to determine focus!");
    }
}

/**
 * Locates and sets tab focus in a counter clockwise direction.
 * @param {element} target - The DOM element, located from a click or keydown, keyVent.target.
 */
function boe_determineTabFocusCounterClockWise(target) {
    //Debug console.log("jquery-ui-datePicker-accessibility-helper: DEBUG boe_determineTabFocusCounterClockWise!");
    var hasMonthSelect = typeof $m('select.ui-datepicker-month')[0] != "undefined";
    var hasYearSelect = typeof $m('select.ui-datepicker-year')[0] != "undefined";
    var classList = $m(target).attr('class').split(/\s+/);

    //Internal sub-function used to find dropdowns and selected
    function boe_determineCounterClockWiseDropdownSelect(skipYear) {
        if (hasYearSelect && !skipYear) { // If we have a 'Year' select dropdown
            $m('select.ui-datepicker-year')[0].focus(); // We focus on the 'Year' select dropdown
        } else if (hasMonthSelect) { // If we have a 'Month' select dropdown
            $m('select.ui-datepicker-month')[0].focus(); // We focus on  the 'Month' select dropdown
        } else {
            //We try to focus on the active date/day link button
            boe_focusActiveDate();
        }
    }

    //TAB + SHIFT key expected to move focus right.
    if (classList.includes('ui-datepicker-close')) { // From the 'Close' dialog button
        //We try to focus on the active date/day link button
        boe_focusActiveDate();
    } else if (classList.includes('ui-state-default')) { // From a date/day link button
        // If we have a 'Next' month link and it is not disabled
        if ($m('.ui-datepicker-next').attr("aria-disabled") != "true") {
            $m('.ui-datepicker-next')[0].focus(); // We focus on the 'Next' month button
        } else {
            boe_determineCounterClockWiseDropdownSelect(false);
        }
    } else if (classList.includes('ui-datepicker-next')) { // From the 'Next' month button
        boe_determineCounterClockWiseDropdownSelect(false);
    } else if (classList.includes('ui-datepicker-year')) { // From the 'Year' select dropdown
        boe_determineCounterClockWiseDropdownSelect(true);
    } else if (classList.includes('ui-datepicker-month')) { // From the 'Month' select dropdown
        // We try to focus on the 'Prev' month button
        boe_focusPrev();
    } else if (classList.includes('ui-datepicker-prev')) { // From the 'Prev' month button
        $m('.ui-datepicker-close')[0].focus(); // We focus on the 'Close' button
    } else {
        console.warn("jquery-ui-datePicker-accessibility-helper:  boe_determineTabFocusCounterClockWise, Unable to determine focus!");
    }
}

/**
 * Contains logic for handling the Enter key or mouse click event.
 * @param {event} keyVent - The event from a click or keydown.
 */
function boe_handleEnterKeyAndMouseClickEvents(keyVent) {
    var target = keyVent.target;
    if ($m(target).hasClass('ui-datepicker-prev') || $m(target).hasClass('ui-icon-circle-triangle-w')) {
        boe_handlePrevClicks();
    } else if ($m(target).hasClass('ui-datepicker-next') || $m(target).hasClass('ui-icon-circle-triangle-e')) {
        boe_handleNextClicks();
    } else if ($m(target).hasClass('ui-datepicker-month')) {
        //Select the Month or Year Dropdown
        boe_handleDropDownSelect("month");
    } else if ($m(target).hasClass('ui-datepicker-year')) {
        //Select the Month or Year Dropdown
        //boe_handleDropDownSelect("year");
    }
}

/**
 * Locates and sets tab focus in a counter clockwise direction.
 * @param {event} keyVent - The event from a click or keydown.
 */
function boe_parseKeyDownAndClickInfo(keyVent) {
    var target = keyVent.target;
    var which = keyVent.which;
    switch (which) {
        case 1: // Mouse click
            //DEBUG console.log("MOUSE!");
            boe_handleEnterKeyAndMouseClickEvents(keyVent);
            break;
        case 9: // TAB key
            keyVent.preventDefault();
            //TAB + SHIFT key expected to move focus counter clockwise right.
            if (keyVent.shiftKey) {
                boe_determineTabFocusCounterClockWise(target);
            } else {
                //TAB should move focus clockwise left.
                boe_determineTabFocusClockWise(target);
            }
            break;
        case 13: // ENTER key
            //DEBUG console.log("ENTER!");
            boe_handleEnterKeyAndMouseClickEvents(keyVent);//This fires a mouse click?
            break;
        case 27: // ESC key
            keyVent.stopPropagation();
            boe_closeCalendar("Source: Container keydown (via boe_parseKeyDownAndClickInfo)");
            break;
        case 32: // SPACE key
            if ($m(target).hasClass('ui-datepicker-prev')) {
                boe_handlePrevClicks();
            } else if ($m(target).hasClass('ui-datepicker-next')) {
                boe_handleNextClicks();
            }
            break;
        case 33: // PAGE UP key executes Next button click
            boe_handlePrevClicks();
            break;
        case 34: // PAGE DOWN key executes Prev button click
            boe_handleNextClicks();
            break;
        case 35: // END key finds the last of the month and focuses on it.
            boe_focusStartOrEndOfMonth(target, "end");
            break;
        case 36: // HOME key finds the 1st of the month and focuses on it.
            boe_focusStartOrEndOfMonth(target, "start");
            break;
        case 37: // LEFT arrow key
        case 38: // UP arrow key
        case 39: // RIGHT arrow key
        case 40: // DOWN arrow key
            boe_handleArrowKey(keyVent, target);
            break;
        default:
            //Debug: console.warn("jquery-ui-datePicker-accessibility-helper: boe_parseKeyDownAndClickInfo - Unsuported keyVent '" + which + "'!");
            break;
    }
}

/**
 * Adds keyboard event listeners to the jQuery datepicker.
 * @param {Element} container - DOM element.
 */
function boe_addKeyboardListener(container) {
    //DEBUG console.log("jquery-ui-datePicker-accessibility-helper: DEBUG boe_addKeyboardListener called for '" + container.id + "'.");

    //Allows the clicking of a calendar date to return focus to the input.
    boe_supportMouseClickFocus();

    $m(container).on('keydown click', function calendarKeyboardListener(keyVent) {
        var dateCurrent = getCurrentDate(container);
        if (!dateCurrent) {
            dateCurrent = $m('a.ui-state-default')[0];
            setHighlightState(dateCurrent, container);
        }
        //Debug console.log("jquery-ui-datePicker-accessibility-helper: DEBUG keydown detected on container '" + container.id + "' on keydown keyVent='" + which + "'.");
        //Determine what to do with this event.
        boe_parseKeyDownAndClickInfo(keyVent);
    });
}

/**
 * Sets focus based on target.
 * @param {string} type - It can be 'month' or 'day'. 
 */
function boe_handleDropDownSelect(type) {
    //DEBUG console.log("Set boe_handleDropDownSelect");
    setTimeout(function () {
        updateHeaderElements();
        prepHighlightState();
        if (type == 'month') {
            //Debug console.log($m('.ui-datepicker-month').find(":selected").text());
            $m('.ui-datepicker-month').focus();
        } else if (type == 'year') {
            //Debug console.log($m('.ui-datepicker-month').find(":selected").text());
            $m('.ui-datepicker-year').focus();
        } else {
            console.warn("jquery-ui-datePicker-accessibility-helper boe_handleDropDownSelect Warning: Unsuported  type ='" + type + "'!");
        }
        $m(".ui-datepicker-current").hide();
    }, 0);
}

/**
 * Triggers a mouse click event and highlights the 'Next' button If the button is not disabled.
 */
function boe_handleNextClicks() {
    //DEBUG console.log("boe_handleNextClicks");
    var button = $m('.ui-datepicker-next')[0];
    var buttonIsDisabled = $m('.ui-datepicker-next').attr('aria-disabled');
    if (button && !buttonIsDisabled) {
        setTimeout(function () {
            updateHeaderElements();
            prepHighlightState();
            var isDisabledNow = $m('.ui-datepicker-next').attr('aria-disabled');
            //Do not select the "Next" button if we it is disabled instead select the date which is the clockwise element.
            if (isDisabledNow) {
                //We try to focus on the active date/day link button
                boe_focusActiveDate();
            } else {
                $m('.ui-datepicker-next').focus();
            }
            //DEBUG console.log("Hide: boe_handleNextClicks");
            $m(".ui-datepicker-current").hide();
        }, 0);
    }
}

/**
 * Triggers a mouse click event and highlights the 'Prev' button If the button is not disabled.
 */
function boe_handlePrevClicks() {
    //DEBUG console.log("boe_handlePrevClicks");
    var button = $m('.ui-datepicker-prev')[0];
    var buttonIsDisabled = $m('.ui-datepicker-prev').attr('aria-disabled');
    if (button && !buttonIsDisabled) {
        setTimeout(function () {
            updateHeaderElements();
            prepHighlightState();
            var isDisabledNow = $m('.ui-datepicker-prev').attr('aria-disabled');
            //Do not select the "Prev" button if we it is disabled instead select the date which is the clockwise element.
            if (isDisabledNow) {
                //We try to focus on the active date/day link button
                boe_focusActiveDate();
            } else {
                $m('.ui-datepicker-prev').focus();
            }
            //DEBUG console.log("Hide: boe_handlePrevClicks");
            $m(".ui-datepicker-current").hide();
        }, 0);
    }
}

/**
 * Used to handle left arrow key navigation when date number is selected.
 * @param  {HTMLElement} dateLink The target of the keyboard event (day)
 */
function previousDay(dateLink) {
    var container = document.getElementById('ui-datepicker-div');
    if (!dateLink) {
        return;//Exit this function
    }
    var td = $m(dateLink).closest('td');
    if (!td) {
        return;//Exit this function
    }

    var prevTd = $m(td).prev(),
        prevDateLink = $m('a.ui-state-default', prevTd)[0];

    if (prevTd && prevDateLink) {
        setHighlightState(prevDateLink, container);
        prevDateLink.focus();
    } else {
        handlePrevious(dateLink);
    }
}
/**
 * Manages the selection of a 'Previous' button.
 * @param {any} target
 */
function handlePrevious(target) {
    var container = document.getElementById('ui-datepicker-div');
    if (!target) {
        return;//Exit this function
    }
    var currentRow = $m(target).closest('tr');
    if (!currentRow) {
        return;//Exit this function
    }
    var previousRow = $m(currentRow).prev();

    if (!previousRow || previousRow.length === 0) {
        //There is not previous row, so we go to previous month...
        previousMonth();
    } else {
        var prevRowDates = $m('td a.ui-state-default', previousRow);
        var prevRowDate = prevRowDates[prevRowDates.length - 1];

        if (prevRowDate) {
            setTimeout(function () {
                setHighlightState(prevRowDate, container);
                prevRowDate.focus();
            }, 0);
        }
    }
}
/**
 * 
 */
function previousMonth() {
    var container = document.getElementById('ui-datepicker-div');
    // Focus last day of new month
    setTimeout(function () {
        var trs = $m('tr', container),
            lastRowTdLinks = $m('td a.ui-state-default', trs[trs.length - 1]),
            lastDate = lastRowTdLinks[lastRowTdLinks.length - 1];
        // Updating the cached header elements
        updateHeaderElements();
        setHighlightState(lastDate, container);
        lastDate.focus();
    }, 0);
}

/**
 * Used to handle right arrow key navigation when date number is selected.
 * @param  {HTMLElement} dateLink The target of the keyboard event (day)
 */
function nextDay(dateLink) {
    //Debug console.log("jquery-ui-datePicker-accessibility-helper:DEBUG nextDay='" + dateLink+"'.");
    var container = document.getElementById('ui-datepicker-div');
    if (!dateLink) {
        return;//Exit this function
    }
    var td = $m(dateLink).closest('td');
    if (!td) {
        return;//Exit this function
    }
    var nextTd = $m(td).next(),
        nextDateLink = $m('a.ui-state-default', nextTd)[0];

    if (nextTd && nextDateLink) {
        setHighlightState(nextDateLink, container);
        nextDateLink.focus(); // the next day (same row)
    } else {
        handleNext(dateLink);
    }
}
/**
 * Manages the selection of a 'Next' button.
 * @param {any} target
 */
function handleNext(target) {
    var container = document.getElementById('ui-datepicker-div');
    if (!target) {
        return;//Exit this function
    }
    var currentRow = $m(target).closest('tr'),
        nextRow = $m(currentRow).next();

    if (!nextRow || nextRow.length === 0) {
        nextMonth();
    } else {
        var nextRowFirstDate = $m('a.ui-state-default', nextRow)[0];
        if (nextRowFirstDate) {
            setHighlightState(nextRowFirstDate, container);
            nextRowFirstDate.focus();
        }
    }
}

function nextMonth() {
    var container = document.getElementById('ui-datepicker-div');
    // Focus the first day of the new month
    setTimeout(function () {
        // Updating the cached header elements
        updateHeaderElements();
        var firstDate = $m('a.ui-state-default', container)[0];
        setHighlightState(firstDate, container);
        firstDate.focus();
    }, 0);
}

/**
 * Handles the up arrow navigation through dates
 * @param  {HTMLElement} target The target of the keyboard event (day)
 * @param  {HTMLElement} cont The calendar container
 */
function upHandler(target, cont) {
    var rowContext = $m(target).closest('tr');
    if (!rowContext) {
        return;//Exit this function
    }
    var rowTds = $m('td', rowContext),
        rowLinks = $m('a.ui-state-default', rowContext),
        targetIndex = $m.inArray(target, rowLinks),
        prevRow = $m(rowContext).prev(),
        prevRowTds = $m('td', prevRow),
        parallel = prevRowTds[targetIndex],
        linkCheck = $m('a.ui-state-default', parallel)[0];

    if (prevRow && parallel && linkCheck) {
        // There is a previous row, a td at the same index
        // of the target AND theres a link in that td
        setHighlightState(linkCheck, cont);
        linkCheck.focus();
    } else {
        // We're either on the first row of a month, or we're on the
        // second and there is not a date link directly above the target
        setTimeout(function () {
            // Updating the cached header elements
            updateHeaderElements();
            var newRows = $m('tr', cont),
                lastRow = newRows[newRows.length - 1],
                lastRowTds = $m('td', lastRow),
                tdParallelIndex = $m.inArray(target.parentNode, rowTds),
                newParallel = lastRowTds[tdParallelIndex],
                newCheck = $m('a.ui-state-default', newParallel)[0];

            if (lastRow && newParallel && newCheck) {
                setHighlightState(newCheck, cont);
                newCheck.focus();
            } else {
                // Theres no date link on the last week (row) of the new month
                // meaning its an empty cell, so we'll try the 2nd to last week
                var secondLastRow = newRows[newRows.length - 2],
                    secondTds = $m('td', secondLastRow),
                    targetTd = secondTds[tdParallelIndex],
                    linkCheck2 = $m('a.ui-state-default', targetTd)[0];

                if (linkCheck2) {
                    setHighlightState(linkCheck2, cont);
                    linkCheck2.focus();
                }

            }
        }, 0);
    }
}

/**
 * Handles down arrow navigation through dates in calendar
 * @param  {HTMLElement} target The target of the keyboard event (day)
 * @param  {HTMLElement} cont The calendar container
 */
function downHandler(target, cont) {
    var targetRow = $m(target).closest('tr');
    if (!targetRow) {
        return;//Exit this function
    }
    var targetCells = $m('td', targetRow),
        cellIndex = $m.inArray(target.parentNode, targetCells), // the td (parent of target) index
        nextRow = $m(targetRow).next(),
        nextRowCells = $m('td', nextRow),
        nextWeekTd = nextRowCells[cellIndex],
        nextWeekCheck = $m('a.ui-state-default', nextWeekTd)[0];

    if (nextRow && nextWeekTd && nextWeekCheck) {
        // theres a next row, a TD at the same index of `target`,
        // and theres an anchor within that td
        setHighlightState(nextWeekCheck, cont);
        nextWeekCheck.focus();
    } else {
        setTimeout(function () {
            // updating the cached header elements
            updateHeaderElements();

            var nextMonthTrs = $m('tbody tr', cont),
                firstTds = $m('td', nextMonthTrs[0]),
                firstParallel = firstTds[cellIndex],
                firstCheck = $m('a.ui-state-default', firstParallel)[0];

            if (firstParallel && firstCheck) {
                setHighlightState(firstCheck, cont);
                firstCheck.focus();
            } else {
                // lets try the second row b/c we didnt find a
                // date link in the first row at the target's index
                var secondRow = nextMonthTrs[1],
                    secondTds = $m('td', secondRow),
                    secondRowTd = secondTds[cellIndex],
                    secondCheck = $m('a.ui-state-default', secondRowTd)[0];

                if (secondRow && secondCheck) {
                    setHighlightState(secondCheck, cont);
                    secondCheck.focus();
                }
            }
        }, 0);
    }
}


function onCalendarHide() {
    boe_closeCalendar("Source: onCalendarHide");
}

// Add an aria-label to the date link indicating the currently focused date
// (formatted identically to the required format: mm/dd/yyyy)
function monthDayYearText() {
    var cleanUps = $m('.amaze-date');

    $m(cleanUps).each(function (clean) {
        // Each(cleanUps, function (clean) {
        clean.parentNode.removeChild(clean);
    });

    var datePickDiv = document.getElementById('ui-datepicker-div');
    // In case we find no datepick div
    if (!datePickDiv) {
        console.warn("jquery-ui-datePicker-accessibility-helper: monthDayYearText - Unable to locate the datepicker div!");
        return;//Exit this function
    }
    var dates = $m('a.ui-state-default', datePickDiv);
    $m(dates).attr('role', 'button').on('keydown', function (e) {
        if (e.which === 32) { // SPACE key
            e.preventDefault();//Wu-tang
            setTimeout(function () {
                boe_closeCalendar("Source: Dates keydown (via monthDayYearText)");
            }, 100);
        }
    });
    var monthDateFormatted = boe_formatMonth(boe_getMonthValue(false))
    $m(dates).each(function (index, date) {
        var currentRow = $m(date).closest('tr'),
            currentTds = $m('td', currentRow),
            currentIndex = $m.inArray(date.parentNode, currentTds),
            headThs = $m('thead tr th', datePickDiv),
            dayIndex = headThs[currentIndex],
            daySpan = $m('span', dayIndex)[0],
            monthName = monthDateFormatted,
            year = boe_getYearValue(false),
            number = date.innerHTML;

        if (!daySpan || !monthName || !number || !year) {
            return;//Exit this function
        }

        // AT Reads: {month} {date} {year} {day}
        // "December 18 2014 Thursday"
        var dateText = date.innerHTML + ' ' + monthName + ' ' + year + ' ' + daySpan.title;
        // AT Reads: {date(number)} {name of day} {name of month} {year(number)}
        // var dateText = date.innerHTML + ' ' + daySpan.title + ' ' + monthName + ' ' + year;
        // add an aria-label to the date link reading out the currently focused date
        date.setAttribute('aria-label', dateText);
    });
    boe_setDisabledTabFocusAndAriaLabel();
}


/**
 *Update the cached header elements because we're in a new month or year
 */
function updateHeaderElements() {
    var context = document.getElementById('ui-datepicker-div');
    if (!context) {
        return;//Exit this function
    }

    var prev = $m('.ui-datepicker-prev', context)[0];
    var next = $m('.ui-datepicker-next', context)[0];

    //Make them click/focus - able
    next.href = 'javascript:void(0)';
    prev.href = 'javascript:void(0)';

    next.setAttribute('role', 'button');
    prev.setAttribute('role', 'button');
    appendOffscreenMonthText(next);
    appendOffscreenMonthText(prev);

    //Set the  accessible alert for the header when we redraw the picker.
    boe_setAccessibleAlertHeader();
    //Add month day year text
    monthDayYearText();
}


function prepHighlightState() {
    var highlight;
    var cage = document.getElementById('ui-datepicker-div');
    highlight = $m('.ui-state-highlight', cage)[0] ||
        $m('.ui-state-default', cage)[0];
    if (highlight && cage) {
        setHighlightState(highlight, cage);
    }
}

// Set the highlighted class to date elements, when focus is received
function setHighlightState(newHighlight, container) {
    var prevHighlight = getCurrentDate(container);
    // Remove the highlight state from previously
    // highlighted date and add it to our newly active date
    $m(prevHighlight).removeClass('ui-state-highlight');
    $m(newHighlight).addClass('ui-state-highlight');
}


// Grabs the current date based on the highlight class
function getCurrentDate(container) {
    return $m('.ui-state-highlight', container)[0];
}

/**
 * Appends logical next/prev month text to the buttons
 * - ex: Next Month, January 2015
 *       Previous Month, November 2014
 */
function appendOffscreenMonthText(button) {
    var buttonText;
    var isNext = $m(button).hasClass('ui-datepicker-next');
    var months = [
        'january', 'february',
        'march', 'april',
        'may', 'june', 'july',
        'august', 'september',
        'october',
        'november', 'december'
    ];

    var currentMonth = boe_getMonthValue(false);
    var monthIndex = $m.inArray(boe_formatMonth(currentMonth), months);
    var currentYear = boe_getYearValue(false);

    var adjacentIndex = (isNext) ? monthIndex + 1 : monthIndex - 1;
    if (isNext && (currentMonth === 'december' || currentMonth === 'dec')) {
        currentYear = parseInt(currentYear, 10) + 1;
        adjacentIndex = 0;
    } else if (!isNext && (currentMonth === 'january' || currentMonth === 'jan')) {
        currentYear = parseInt(currentYear, 10) - 1;
        adjacentIndex = months.length - 1;
    }

    buttonText = (isNext)
        ? 'Next Month, ' + firstToCap(months[adjacentIndex]) + ' ' + currentYear
        : 'Previous Month, ' + firstToCap(months[adjacentIndex]) + ' ' + currentYear;

    $m(button).find('.ui-icon').html(buttonText);

}

// Returns the string with the first letter capitalized
function firstToCap(s) {
    return s.charAt(0).toUpperCase() + s.slice(1);
}
/////////////////////////////////////////////////////////
//END Modified Deque University Accessibility Code (calling "boe_" functions).
/////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////
//START Custom Functions created for BOE compatibility
/////////////////////////////////////////////////////////
/**
 * Sets a timeout function is on the calendar div to track mouse clicks and keyboard navigation.
 */
function boe_setCalendarButtonTimeoutFunction() {
    //Debug console.log("jquery-ui-datePicker-accessibility-helper boe_setCalendarButtonTimeoutFunction: DEBUG Setting timeout function.");
    setTimeout(function () {
        //Try to focus on the current date if available and if not use the first day of the month.
        var today = boe_findDayToFocus();
        today.focus();

        // Hide the entire page (except the date picker)
        // from screen readers to prevent document navigation
        // (by headings, etc.) while the popup is open
        $m("main").attr('id', 'dp-container');
        $m("#dp-container").attr('aria-hidden', 'true');
        $m("#skipnav").attr('aria-hidden', 'true');

        // Hide the "Today" select button because it doesn't do what
        // you think it supposed to do
        //DEBUG console.log("Hide: boe_setCalendarButtonTimeoutFunction");
        $m(".ui-datepicker-current").hide();
        //Adds click event handlers
        boe_datePickHandler("boe_setCalendarButtonTimeoutFunction");
        boe_setAccessibleAlertHeader();
    }, 0);
}

/**
 * On load this script will set global default settings for all DatePickers which can then be overwritten locally.
 * console.log("jquery-ui-datePicker-accessibility-helper: DEBUG Setting defaults for all future datepickers.");
 */
console.log("jquery-ui-datePicker-accessibility-helper: Setting default datepicker settings for accessibility.");
$m.datepicker.setDefaults({
    showOn: "both",
    buttonImage: "../../Content/Images/Calendar.png",
    buttonImageOnly: false,  //Accessibility: Ensures the calendar icon is reachable via keyboard.
    showButtonPanel: true, //Accessibility: Provides close button reachable via keyboard.
    closeText: 'Close', //Accessibility: Provides close button text.
    changeMonth: true, //Provides functionality to change month. Can be overwritten in instance per instance basis.
    changeYear: true, //Provides functionality to change year. Can be overwritten in instance per instance basis.
    onSelect: function (dateText, inst) {
        //Debug console.log("setDefaults:onSelect");
        $m(inst.input[0]).focus();//Focus back on date input field.
        $m(inst.input[0]).change();//Trigger change events.
    },
    onClose: function (dateText, inst) {
        //Debug console.log("setDefaults:onClose");
        removeAria();
    },
    dateFormat: 'mm/dd/yy', //mm - month of year (two digit), dd - day of month (two digit) and yy - year (four digit).
    duration: "fast", //Helps make calendar appear faster in Internet Explorer.
    showAnim: "" //Helps make calendar appear faster in Internet Explorer.
})

/**
 * Provides a notification for screen readers that the date picker dialog will be added at the end of the form.
 * An element with role=”status”, or role=”alert”, or as any other live region will be announced to the user immediately and it could be placed anywhere in the DOM (when added off-screen/visually hidden).
 */
function boe_setAccessibleAlertHeader() {
    var header = $m("#accessibleDatePickerAlert");
    if (header.length == 0) {
        $m(".ui-datepicker-header").prepend("<h2 id='accessibleDatePickerAlert' role='alert' aria-live='assertive' style='position: absolute !important; height: 1px; width: 1px; overflow: hidden; clip: rect(0 0 0 0);clip: rect(1px, 1px, 1px, 1px);padding: 0;'>Calendar Date Selector Dialog</h2>");
    }
}

/**
 * Thisfunction collects all  to make all datepickers which have been initialized and adds code tha helps make them accessible.
 * To Use:
 * Add this method ("boe_makeAllDatePickersAccessible();") to the first line of the <script>$m(document).ready(function () {}<.script> in a _MasterLayout.cshtml page or to any page that calls the @RenderBody().
 * The function will/should execute after the body is rendered.
 */
function boe_makeAllDatePickersAccessible() {
    //Debug console.log("jquery-ui-datePicker-accessibility-helper boe_makeAllDatePickersAccessible: Attempting to make all available DatePickers accessible.");
    //1) Get the inputs which have been initialized as datepickers which receive the .hasDatepicker class automatically.
    var pickers = boe_getDatePickers();
    if (pickers) {
        //2) Iterate through all initialized datepickers
        pickers.each(function (index) {
            //Find the id.
            var datePickerJqueryObject = $m(this);
            if (boe_util_isValidJqueryObject(datePickerJqueryObject)) {
                var elementId = datePickerJqueryObject.attr("id");
                if (elementId && elementId != "") {
                    //Debug console.log("jquery-ui-datePicker-accessibility-helper boe_makeAllDatePickersAccessible DEBUG: Processing picker index='" + index + "' id='" + elementId + "'.");
                    //3) Check for accessibility issues.
                    boe_checkAndCorrectCommonInitializationIssues(datePickerJqueryObject);

                    //2) Try to find the label element associated with this datepicker Input and use it to associate it for screen readers.
                    var inputLabelObject = boe_getOrCreateInputLabel(datePickerJqueryObject);
                    var inputLabelId = $m(inputLabelObject[0]).attr('id');

                    //3) Now set the click events, id and aria-described by.
                    boe_locateDatePickersCalendarButtonsAndTryMakeAccessible(elementId, inputLabelId);

                    //4) Now set an aria-label on the datepicker that contains both the information of the lablel and the information of any placeholder.
                    boe_setDatePickerAriaLabel(datePickerJqueryObject, inputLabelObject);

                    //5) Set a mutation handler to track enable and disable events.
                    boe_setDisableEnableMutatorObserver(elementId);
                } else {
                    console.warn("jquery-ui-datePicker-accessibility-helper boe_makeAllDatePickersAccessible: Element is missing Id.");
                }
            } else {
                console.warn("jquery-ui-datePicker-accessibility-helper boe_makeAllDatePickersAccessible: Could not convert datepicker into jquery object.");
            }
        });

    }
}

/**
 * IF the picker has placeholder text set an aria-label on the datepicker that contains both the information of the lablel and the information of any placeholder.
 * @param {jQuery} datePickerElement - jQuery object instance of date input field.
 * @param {jQuery} inputLabelElement - jQuery object instance of the label  associated with the jQuery UI datepicker instance.
 */
function boe_setDatePickerAriaLabel(datePickerElement, inputLabelElement) {
    if (boe_util_isValidJqueryObject(datePickerElement) && boe_util_isValidJqueryObject(inputLabelElement)) {
        //Get inner text but remove any single or double quotes.
        var labelText = inputLabelElement.text().replace(/'/g, '').replace(/"/g, '');
        var ariaLabelText = labelText;
        //Get placeholder text if any is avaialable.
        var datePickerPlaceholderText = datePickerElement.attr("placeholder");
        if (datePickerPlaceholderText) {
            ariaLabelText = labelText + " (" + datePickerPlaceholderText + ")";
            //Add the aria-label text.
            datePickerElement.attr("aria-label", ariaLabelText);
        }
    } else {
        console.warn("jquery-ui-datePicker-accessibility-helper boe_setDatePickerAriaLabel: Could not set datepicker aria-label property.");
    }

}

/**
 * Will locate the a calendar icon for a datepicker and call functions to make it accessible by attempting to add an aria-label attribute and define on click events.
 * @param {string} datePickerId - The id of the jQuery UI datepicker instance.
 * @param {string} inputLabelId - The id of the label associated with the jQuery UI datepicker instance.
 */
function boe_locateDatePickersCalendarButtonsAndTryMakeAccessible(datePickerId, inputLabelId) {
    var datePickerElement = $m("#" + datePickerId);
    if (boe_util_isValidJqueryObject(datePickerElement)) {
        //Debug console.log("jquery-ui-datePicker-accessibility-helper boe_locateDatePickersCalendarButtonsAndTryMakeAccessible: DEBUG: Processing element with id='" + elementId +"'.");

        //1) Make the Trigger Button Accessible by giving it an id.
        var calendarModalTriggerButton = $m("#" + datePickerId).next("button.ui-datepicker-trigger");
        calendarModalTriggerButton.attr("id", datePickerId + CALENDAR_BUTTON_SUFIX);

        //2) Try to find the label element associated with this datepicker Input and use it to associate it for screen readers.
        // If our label is valid we associate it to the calendar trigger button.
        if (boe_validateStringAndNotEmpty(inputLabelId)) {
            calendarModalTriggerButton.attr('aria-describedby', inputLabelId);
        } else {
            console.warn("jquery-ui-datePicker-accessibility-helper boe_locateDatePickersCalendarButtonsAndTryMakeAccessible: No label id available for the element with id='" + datePickerId + "'.");
        }

        //3) Add a click event function to calendar buttons that records the input id on the hidden dialog used for picking date.
        boe_addCalendarButtonClickEvent(calendarModalTriggerButton, datePickerId);

        //4) Make the date selectors accessible
        boe_addFocusEventHandlerToInputField(datePickerElement);

    } else {
        console.warn("jquery-ui-datePicker-accessibility-helper boe_locateDatePickersCalendarButtonsAndTryMakeAccessible: datepicker object was not provided. Id used was " + datePickerId + "'.");
    }
}

/**
 * Returns a MutationObserver for the object matching a given id.
 * The mutation observer watches for changes in the Document Object Model (DOM) tree.
 * Note that this mutation observer only triggers with the "disabled" attribute and will only make changes to the element identified by datePickerId.
 * @param {string} datePickerId
 */
function boe_createMutationObserver(datePickerId) {
    //Debug console.log("jquery-ui-datePicker-accessibility-helper: DEBUG boe_createMutationObserver Try setting observer to look for datePickerId '" + datePickerId + "' .");
    if ("MutationObserver" in window && datePickerId && datePickerId != "") {
        // MutationObserver interface provides the ability to watch for changes being made to the DOM tree.
        return new MutationObserver(function (mutations) {
            $m.each(mutations, function (index, mutation) {
                //Get the current mutation
                var currentMutation = mutation.attributeName;
                //Determine if target is disabled or not.
                var targetIsNotDisabled = typeof mutation.target.attributes.disabled == 'undefined';
                //Debug console.log("jquery-ui-datePicker-accessibility-helper: DEBUG boe_createMutationObserver targetIsNotDisabled ='" + targetIsNotDisabled + "' and currentMutation='" + currentMutation + "'.");
                //When the target is not disabled we want to make the calendar button accessible.
                if (targetIsNotDisabled && currentMutation == "disabled") {
                    //Debug console.log("jquery-ui-datePicker-accessibility-helper: DEBUG boe_createMutationObserver reseting the focus event handler.");
                    //Now set the click events, id and aria-described by.
                    boe_locateDatePickersCalendarButtonsAndTryMakeAccessible(datePickerId);
                    //Exit loop
                    return false;
                }
            });
        });
    } else {
        console.warn("This browser version does not support MutationObserver.");
        return null;
    }
}

/**
 * The disable and enable process removes our event handlers so we need to put them back in if we change the state.
 * A mutator observer is used to track these state changes in the disabled attribue.
 * @param {string} datePickerId 
 */
function boe_setDisableEnableMutatorObserver(datePickerId) {
    if (!boe_util_isValidJqueryObject("#" + datePickerId)) {
        //Debug console.log("jquery-ui-datePicker-accessibility-helper boe_setDisableEnableMutatorObserver: DEBUG attempting to set mutator.");
        try {
            // Options, target the nodes children, also target the children's decendants.
            var node = $m("#" + datePickerId);
            //Don't assume we have paginators.
            if (node.length) {
                var mutationObserverOptions = {
                    attributes: true,//Only look at attribute changes.
                    attributeFilter: ['disabled'],//Only look at the disabled attribute.
                    //attributeOldValue: true
                };
                // Start observing
                var observer = boe_createMutationObserver(datePickerId);
                if (observer) {
                    observer.observe(node[0], mutationObserverOptions);
                }
            }
        } catch (error) {
            console.error("jquery-ui-datePicker-accessibility-helper boe_setDisableEnableMutatorObserver: Unable to process the provided datepicker instance.");
            throw (error);//Rethrow the error so we can see what the actual issue was.
        }
    } else {
        console.warn("jquery-ui-datePicker-accessibility-helper boe_setDisableEnableMutatorObserver: datepicker object was not provided.");
    }
}

/**
 * Tries to get the jQuery reference for the label for the datepicker. 
 * If it doesn't exsit it creates one.
 * @param {jQuery} datePickerElement - jQuery object instance of date input field.
 */
function boe_getOrCreateInputLabel(datePickerElement) {
    var inputLabel = false;
    if (boe_util_isValidJqueryObject(datePickerElement)) {
        //1) Find the label element associated with this datepicker Input and use it to associate it for screen readers.
        //2) We prioritize "aria-labeledby" attribute defintions before the "for" attribute definitions.
        var inputLabelId = datePickerElement.attr("aria-labelledby");
        if (boe_validateStringAndNotEmpty(inputLabelId)) {
            //Debug  console.log("jquery-ui-datePicker-accessibility-helper DEBUG boe_getOrCreateInputLabel: Selecting label using 'aria-labelledby' attribute '" + inputLabelId + "'.");
            inputLabel = $m("#" + inputLabelId);
        } else {
            //Get the id of the current datePicker input.
            var inputId = datePickerElement.attr("id");
            if (boe_validateStringAndNotEmpty(inputId)) {
                //3) If we don't have an inputLabel yet check if can find the element in the "for" attribute
                //Debug console.log("jquery-ui-datePicker-accessibility-helper DEBUG boe_getOrCreateInputLabel: Selecting label using 'for' attribute '" + inputId + "'.");
                var potentialLabel = $m("*[for='" + inputId + "']");
                if (boe_util_isValidJqueryObject(potentialLabel)) {
                    inputLabel = potentialLabel;
                } else {
                    var newLabelId = inputId + "_AutoGeneratedLabel";
                    console.log("jquery-ui-datePicker-accessibility-helper boe_getOrCreateInputLabel: Unable to locate labels for datePickerElement with id '" + inputId + "'.\nCreating new label with id = '" + newLabelId + "'.");
                    inputLabel = $m("<span/>", {
                        id: newLabelId,
                        text: "Date",
                        css: {
                            "position": "absolute",/*We need to hide the element from sight because CAN visibly expose the page content is malformed. That is to say theres a label but it is not correctly mapped to the input.*/
                            "left": "-10000px",/*Screen readers will see this.*/
                            "top": "auto",
                            "width": "1px",
                            "height": "1px",
                            "overflow": "hidden"
                        }
                    });
                    inputLabel.insertBefore(datePickerElement);
                    datePickerElement.attr("aria-labelledby", newLabelId);
                }
            } else {
                console.warn("jquery-ui-datePicker-accessibility-helper boe_getOrCreateInputLabel: Unable to create label label for datePickerElement because 'id' was not defined.");
            }
        }
    } else {
        console.warn("jquery-ui-datePicker-accessibility-helper boe_getOrCreateInputLabel: Invalid datePickerElement '" + datePickerElement + "'.");
    }
    return inputLabel;
}

/**
 * Makes a calendar icon button accessible by attempting to add an aria-label attribute and define on click events.
 * @param {jQuery} jQueryCalendarButtonInstance - jQuery object instance of the Calendar Button.
 * @param {String} datePickerInputId - id of jQuery object instance of the calendar input.
 */
function boe_addCalendarButtonClickEvent(jQueryCalendarButtonInstance, datePickerInputId) {
    //Debug console.log("jquery-ui-datePicker-accessibility-helper: DEBUG boe_addCalendarButtonClickEvent called for '" + datePickerInputId + "'.")
    if (!boe_util_isValidJqueryObject(jQueryCalendarButtonInstance) || !boe_utility_isStringNotBlank(datePickerInputId)) {
        console.warn("jquery-ui-datePicker-accessibility-helper jQueryCalendarButtonInstance: Invalid jQueryCalendarButtonInstance or datePickerInputId.");
        return;//Exit this function
    }
    try {
        var buttonInstanceId = jQueryCalendarButtonInstance.attr('id');

        //Add the code that runs when we open the calendar modal menu.
        jQueryCalendarButtonInstance.on("click", function () {
            //Debug console.warn("jquery-ui-datePicker-accessibility-helper: DEBUG jQueryCalendarButtonInstance, executing click event!")
            boe_setCalendarButtonTimeoutFunction();
            //If the datepicker is not disabled we want to try to update the data-a11y-input-id with the inputs instance id.
            if ($m('#' + datePickerInputId).attr("disabled") != "disabled") {
                var divVisible = $m('#ui-datepicker-div').css('display');
                var divDataAttr = $m('#ui-datepicker-div').attr('data-a11y-input-id');
                //Debug console.log("jquery-ui-datePicker-accessibility-helper: DEBUG jQueryCalendarButtonInstance is buttonInstanceId='" + buttonInstanceId + "' display='" + divVisible + "' data-a11y-input-id='" + divDataAttr + "'.");
                if (divVisible != "block" || !(divDataAttr != "" || typeof divDataAttr == "undefined" || divDataAttr == buttonInstanceId)) {
                    console.warn("jquery-ui-datePicker-accessibility-helper jQueryCalendarButtonInstance: Unable to set 'data-' attribute for element with id='" + datePickerInputId + "'.");
                    return;//Exit this function
                }
                if (divDataAttr != buttonInstanceId) {
                    //Add a data-* HTML5 attribute to the datepicker dialog and embed custom data.
                    $m('#ui-datepicker-div').attr('data-a11y-input-id', buttonInstanceId);
                }
            } else {
                console.log("jquery-ui-datePicker-accessibility-helper jQueryCalendarButtonInstance: The element with id '" + datePickerInputId + "' is currently disabled.");
            }
        });

        //Add the code we run when we close the modal menu using modal controls.
        $m(document).on('click', '#ui-datepicker-div .ui-datepicker-close', function () {
            //Debug console.log("Close: '#ui-datepicker-div .ui-datepicker-close' ");
            boe_closeCalendar("Source: boe_addCalendarButtonClickEvent");
        });

    } catch (e) {
        console.error("jquery-ui-datePicker-accessibility-helper jQueryCalendarButtonInstance: Error.");
        console.error(e);
    }
}

/**
 * Restore hrefs in order for anchors to receive focus.
 * @param {object} prevSelector - jQuery UI datepicker button instance.
 * @param {object} nextSelector - jQuery UI datepicker button instance.
 */
function boe_RestorePrevNextSelectors(prevSelector, nextSelector) {
    //We need to restore hrefs in order for anchors to receive focus.
    if (boe_util_isValidJqueryObject(prevSelector)) {
        prevSelector.attr("href", "javascript:void(0)");
    }
    if (boe_util_isValidJqueryObject(nextSelector)) {
        nextSelector.attr("href", "javascript:void(0)");
    }
}

/**
 * Adds functionality for the input field to returns focus back to DatePicker month or year dropdowns when they changed.
 * The default functionality from jquery-ui (version 1.20.0) takes focus out of the dropdown via this function execution order:
 * 1) _selectMonthYear event is triggered by select boxes.
 * 2) onChange happens triggering the _adjustDate function.
 * 3) Then _updateDatePicker function selects the input field behind the dialog box which causes an accessibility problem.
 * @param {object} datePicker - jQuery UI datepicker instance.
 */
function boe_addFocusEventHandlerToInputField(datePicker) {
    //Debug console.log("jquery-ui-datePicker-accessibility-helper DEBUG: boe_addFocusEventHandlerToInputField.");
    //Find the id of our datepicker input field.
    var elementId = $m(datePicker[0]).attr("id");
    if (!boe_validateStringAndNotEmpty(elementId)) {
        console.warn("jquery-ui-datePicker-accessibility-helper: Element is missing Id.");
        return;//Exit this function
    }
    //1) Bind a focus event for the date input field so we can return focus back to select boxes.
    $m('#' + elementId).on('focus', function (eventData) {
        //2) Find the data attributes and display status
        var datePickerDiv = $m('#ui-datepicker-div');
        var divDataAttr = datePickerDiv.attr('data-a11y-input-id');
        var divVisible = datePickerDiv.css('display');
        //3) Only return focus if the datepicker interface div is open.
        if (divVisible != "block") {
            //Debug console.log("jquery-ui-datePicker-accessibility-helper: DEBUG Dialog is not mapped to this input. Did not execute handlers for dropdowns.");
            return;//Exit this function
        }
        //4) Only return focus if the datepicker interface div is mapped to this input
        if (divDataAttr == "" || typeof divDataAttr == "undefined" || divDataAttr != elementId + CALENDAR_BUTTON_SUFIX) {
            //DEBUG console.warn("jquery-ui-datePicker-accessibility-helper boe_addFocusEventHandlerToInputField DEBUG: Calendar dialog is not associated to the inputs with id = '" + elementId + "'.");
            return;//Exit this function
        }
        //Debug console.warn("jquery-ui-datePicker-accessibility-helper DEBUG: Executing event handlers to dropdowns.");
        boe_addHandlersToCalendarHeader();
        boe_addLabelsToMonthAndYearSelectors();
    });
}

/**
 * The jQuery UI datepicker headers month/year selects and next and previous buttons will lose focus to the input field when used.
 * This is partly because the entire datepicker calendar needs to be redrawn on change.
 * This function adds event handlers that store which element was used so that focus can be restored.
 */
function boe_addHandlersToCalendarHeader() {
    // 1) Get the datepicker calendar Div.
    var dialog = $m("#ui-datepicker-div");
    if (boe_util_isValidJqueryObject(dialog)) {
        //Debug console.error("jquery-ui-datePicker-accessibility-helper DEBUG: boe_addHandlersToCalendarHeader.");
        // 2) Get our header element objects.
        var monthSelector = $m(".ui-datepicker-month");
        var yearSelector = $m(".ui-datepicker-year");
        var nextButton = $m(".ui-datepicker-next");
        var prevButton = $m(".ui-datepicker-prev");
        // 3) Bind on change events for selects
        if (boe_util_isValidJqueryObject(monthSelector)) {
            //Debug console.log("jquery-ui-datePicker-accessibility-helper DEBUG: Adding event handlers to month dropdown.");
            monthSelector.on('change', function () {
                //Debug console.log("jquery-ui-datePicker-accessibility-helper DEBUG: Month focus.");
                //monthSelector.focus();
                //$m(".ui-datepicker-current").hide();
                boe_handleDropDownSelect("month");
            });
        }
        if (boe_util_isValidJqueryObject(yearSelector)) {
            //Debug console.log("jquery-ui-datePicker-accessibility-helper DEBUG: Adding event handlers to year dropdown.");
            yearSelector.on('change', function () {
                //Debug console.log("jquery-ui-datePicker-accessibility-helper DEBUG: Year focus.");
                //yearSelector.focus();
                boe_handleDropDownSelect("year");
            });
        }
        if (boe_util_isValidJqueryObject(nextButton)) {
            //Debug console.log("jquery-ui-datePicker-accessibility-helper DEBUG: Adding event handlers to next button.");
            nextButton.click(function () {
                //Debug console.log("jquery-ui-datePicker-accessibility-helper DEBUG: Next click.");
            });
        }
        if (boe_util_isValidJqueryObject(prevButton)) {
            //Debug console.log("jquery-ui-datePicker-accessibility-helper DEBUG: Adding event handlers to previous button.");
            prevButton.click(function () {
                //Debug console.log("jquery-ui-datePicker-accessibility-helper DEBUG: Previous click.");
            });
        }
    } else {
        console.error("jquery-ui-datePicker-accessibility-helper: Provided element is not instance of jQuery. Found '" + typeof dialog + "'.");
    }
}

/**
 * Adds aria-labels to the month and year handlers.
 * @param {any} monthJqueryObject
 * @param {any} yearJqueryObject
 */
function boe_addLabelsToMonthAndYearSelectors() {
    //Debug console.log("jquery-ui-datePicker-accessibility-helper boe_addLabelsToMonthAndYearSelectors DEBUG: Adding aria-labels to year and month selects.");
    var headerJqueryObjects = $m(".ui-datepicker-header");
    var arrowsJqueryObjects = $m(".ui-datepicker-next,.ui-datepicker-prev");
    var monthJqueryObject = $m(".ui-datepicker-month");
    var yearJqueryObject = $m(".ui-datepicker-year");
    var customDatepickerLabelIdMonth = "customDatepickerLabelIdMonth";
    var customDatepickerLabelIdYear = "customDatepickerLabelIdYear";
    var customDatepickerSelectIdMonth = "customDatepickerMonthId";
    var customDatepickerSelectIdYear = "customDatepickerYearId";
    var commonSelectCSS = {
        "width": "50%",
        "padding-top": "1px",
        "padding-bottom": "1px",
        "float": "left",
        "margin-top": "0px"
    }
    if (boe_util_isValidJqueryObject(monthJqueryObject)) {
        monthJqueryObject.attr("id", customDatepickerSelectIdMonth).css(commonSelectCSS).css({ "clear": "left" });
        //Adds Month label to datepicker.
        if ($("#" + customDatepickerLabelIdMonth).length == 0) {
            $("<label id='" + customDatepickerLabelIdMonth + "' for='" + customDatepickerSelectIdMonth + "'  style='font-size:11.7px;margin:0px;float:left;'>&nbsp;Month</label>").insertBefore(monthJqueryObject);
        }
    }
    if (boe_util_isValidJqueryObject(yearJqueryObject)) {
        yearJqueryObject.attr("id", customDatepickerSelectIdYear).css(commonSelectCSS);
        //Adds Year label to datepicker.
        if ($("#" + customDatepickerLabelIdYear).length == 0) {
            $("<label id='" + customDatepickerLabelIdYear + "' for='" + customDatepickerSelectIdYear + "' style='font-size:11.7px;margin:0px;'>&nbsp;Year</label>").insertBefore(yearJqueryObject);
        }
    }
    if (boe_util_isValidJqueryObject(arrowsJqueryObjects)) {
        arrowsJqueryObjects.css({ "margin-top": "2em" });
    }
    if (boe_util_isValidJqueryObject(headerJqueryObjects)) {
        headerJqueryObjects.css({
            "padding-top": "0.1em",
            "padding-bottom": "0.1em"
        });
    }

}

/**
 * Makes the datepicker date format warning account for 'yy' is 0000 number year.
 *  @param {object} dpInstance - jQuery UI datepicker instance.
 *  @param {object} datePickerDateOptionName - Usually maxDate or minDate.
 */
function boe_handleDateFormatWarnings(dpInstance, datePickerDateOptionName) {
    //Debug console.log("jquery-ui-datePicker-accessibility-helper:boe_handleDateFormatWarnings DEBUG" + "\n-dateFormat:[" + dpInstance.datepicker("option", "dateFormat") + "]\n-maxDate:[" + dpInstance.datepicker("option", "maxDate") + "]\n-minDate:[" + dpInstance.datepicker("option", "minDate") + "].");
    var datePickerDateOptionValue = dpInstance.datepicker("option", datePickerDateOptionName);
    if (boe_utility_isStringNotBlank(datePickerDateOptionValue)) {
        var dateFormatArray = dpInstance.datepicker("option", "dateFormat");
        //Method returns a number indicating whether a reference string comes before, or after, or is the same as the given string in sort order.
        if (dpInstance.datepicker("option", datePickerDateOptionName).localeCompare('0')) {
            var diffIndex = boe_utility_FindWhereStringArrayLengthsVary(datePickerDateOptionValue.split('/'), dateFormatArray);
            if (diffIndex && diffIndex != -1) {
                //Makes the datepicker date format warning account for 'yy' is 0000 number year.
                if (maxDateArray[diffIndex].length != 4 && dateFormatArray[diffIndex] != 'yy') {
                    console.warn("jquery-ui-datePicker-accessibility-helper: Detected inconsistency between dateFormat '" + dateFormat + "' and defined " + datePickerDateOptionName + " '" + datePickerDateOptionvalue + "'.");
                }
            }
        }
    }
}


/**
 * Checks for common issues in datepicker and displays warnings.
 *  @param {object} dpInstance - jQuery UI datepicker instance.
 */
function boe_checkAndCorrectCommonInitializationIssues(dpInstance) {
    if (boe_util_isValidJqueryObject(dpInstance)) {
        //Check Dates
        var dateFormat = dpInstance.datepicker("option", "dateFormat");
        //Debug console.log("jquery-ui-datePicker-accessibility-helper:boe_checkAndCorrectCommonInitializationIssues DEBUG" + "\n-dateFormat:[" + dateFormat + "]\n-maxDate:[" + dpInstance.datepicker("option", "maxDate")+ "]\n-minDate:[" + dpInstance.datepicker("option", "minDate")+"].");
        //Examine date format and issue warnings where necessary.
        if (boe_utility_isStringNotBlank(dateFormat)) {
            //Pad 'yy' since the format stands for a 4 characters year.
            if (dateFormat[2].toString().toLowerCase() == 'yy') {
                dateFormat[2] = "-" + dateFormat[2] + "-";
            }
            boe_handleDateFormatWarnings(dpInstance, "maxDate");
            boe_handleDateFormatWarnings(dpInstance, "minDate");
        }
        //If we don't have button text we add something for the screen reader. 
        //Debug console.log("jquery-ui-datePicker-accessibility-helper: DEBUG buttonText '" + dpInstance.datepicker("option", "buttonText") + "'.");
        var buttonText = dpInstance.datepicker("option", "buttonText").trim();
        if (buttonText === "" || buttonText === "...") {
            dpInstance.datepicker("option", "buttonText", "Select Date");
        }
        //If the datepicker has a button trigger this code will try to associate it with the label or span that describes the input.
        if (dpInstance.datepicker("option", "buttonImageOnly") === true) {
            console.warn("jquery-ui-datePicker-accessibility-helper: The element with id='" + dpInstance.attr('id') + "' was not initialized to use the calendar icon as a dialog trigger.\nTo meet accessibility requirements this option will be modified so that it works as such.");
            //Changes the initialization issue.
            dpInstance.datepicker("option", "buttonImageOnly", false);
        }
    } else {
        console.error("jquery-ui-datePicker-accessibility-helper: Provided element is not instance of jQuery. Found '" + typeof dpInstance + "'.");
    }
    //Debug console.log("jquery-ui-datePicker-accessibility-helper: DEBUG boe_checkAndCorrectCommonInitializationIssues Complete.");
}

/**Used to compare arrays such returning the first true (different lengths), the index where it varies or false.
 *  @param {Array} array1 - String array.
 *  @param {Array} array2 - String array.
 */
function boe_utility_FindWhereStringArrayLengthsVary(array1, array2) {
    var hasError = false;
    if (array1.length == array2.length) {
        for (var i = 0; i < array1.length; i++) {
            //Debug console.log("jquery-ui-datePicker-accessibility-helper: DEBUG Comparing '" + array1[i] + "' and '" + array2[i] + "'.");
            if (boe_utility_isStringNotBlank(array1[i]) && boe_utility_isStringNotBlank(array2[i])) {
                if (array1[i].length != array2[i].length) {
                    hasError = i;
                    break;
                }
            }
        }
    } else {
        //Debug console.log("jquery-ui-datePicker-accessibility-helper:boe_utility_FindWhereStringArrayLengthsVary DEBUG: Arrays are different length.");
        hasError = -1;
    }
    return hasError;
}

/**
 * Checks to see if a string is a string and if its not blank.
 * Returns true or false based on value.
 * @param {String} value
 */
function boe_utility_isStringNotBlank(value) {
    var result = false;
    if (typeof value === 'string' || value instanceof String) {
        if (value.trim().length > 0) {
            result = true;
        }
    }
    return result;
}

/**
* Gets the month value from a select box or span.
*/
function boe_getMonthValue(debug) {
    var month = $m('.ui-datepicker-title .ui-datepicker-month').prop("tagName").toLowerCase() === 'span' ?
        $m('.ui-datepicker-title .ui-datepicker-month').text().toLowerCase() :
        $m('.ui-datepicker-title .ui-datepicker-month option:selected').text().toLowerCase();
    if (debug) { console.log("jquery-ui-datePicker-accessibility-helper: DEBUG month is '" + month + "'."); }
    return month;
}

/**
* Gets the year value from a select box or span.
*/
function boe_getYearValue(debug) {
    var year = $m('.ui-datepicker-title .ui-datepicker-year').prop("tagName").toLowerCase() === 'span' ?
        $m('.ui-datepicker-title .ui-datepicker-year').text().toLowerCase() :
        $m('.ui-datepicker-title .ui-datepicker-year option:selected').text().toLowerCase();
    if (debug) { console.log("jquery-ui-datePicker-accessibility-helper: DEBUG year is '" + year + "'."); }
    return year;
}

/**
* Formats months to from short (ex.'jan') to long format (ex.'january').
* @param { string } currentMonth - The month to convert.
*/
function boe_formatMonth(currentMonth) {
    //Debug console.log("jquery-ui-datePicker-accessibility-helper boe_formatMonth DEBUG: Month value '" + currentMonth + "'.");
    var formatedMonth = currentMonth;
    if (boe_utility_isStringNotBlank(formatedMonth)) {
        switch (currentMonth) {
            case 'jan':
                formatedMonth = 'january';
                break;
            case 'feb':
                formatedMonth = 'february';
                break;
            case 'mar':
                formatedMonth = 'march';
                break;
            case 'apr':
                formatedMonth = 'april';
                break;
            case 'may':
                //'may' already equals 'may' so we escape the switch.
                break;
            case 'jun':
                formatedMonth = 'june';
                break;
            case 'jul':
                formatedMonth = 'july';
                break;
            case 'aug':
                formatedMonth = 'august';
                break;
            case 'sep':
                formatedMonth = 'september';
                break;
            case 'oct':
                formatedMonth = 'october';
                break;
            case 'nov':
                formatedMonth = 'november';
                break;
            case 'dec':
                formatedMonth = 'december';
                break;
            default:
                console.warn("jquery-ui-datePicker-accessibility-helper: Month value '" + currentMonth + "' is not supported so it was left unchanged.");
                break;
        }
    } else {
        console.warn("jquery-ui-datePicker-accessibility-helper: Current month is not a string. Unable to format month.");
    }
    return formatedMonth.toLowerCase();
}

/**
 * Variation on the closeCalendar function to return focus to the specific input element which called the function.
 * @param {String } text - Can be printed in debug and this allows us to track function calls source when debugging.
 */
function boe_closeCalendar(text) {
    //Debug console.warn("jquery-ui-datePicker-accessibility-helper: DEBUG boe_closeCalendar " + text);
    var container = $m('#ui-datepicker-div');
    var containerDataInputId = container.attr("data-a11y-input-id");
    //The "data-a11y-input-id" should not be set to "closed".
    if (containerDataInputId !== "closed") {
        //Confirm we have an id to the input that launched the datepicker.
        if (containerDataInputId && containerDataInputId !== "") {
            $m(container).off('keydown');
            //Instead of removing we set the data attribute to 'close'. Prevents code from running multiple times on the same event.
            $m('#ui-datepicker-div').attr("data-a11y-input-id", "closed");
            var input = $m("#" + containerDataInputId);
            if (boe_util_isValidJqueryObject(input)) {
                //Hide datepicker
                $m(input).datepicker('hide');
                //Set focus on the input.
                //Debug console.log("jquery-ui-datePicker-accessibility-helper: DEBUG boe_closeCalendar, Hiding datepicker and focusing on calendar icon button input.");
                input.focus();
                //Trigger a change event to be picked up by any event listeners and validators.
                input.change();
                try {
                    //Try to call valid to trigger validator message updates.
                    input.valid();
                } catch (e) {
                    console.error("jquery-ui-datePicker-accessibility-helper: Warning boe_closeCalendar valid method did not run.");
                    console.error(e);
                }
            } else {
                console.error("jquery-ui-datePicker-accessibility-helper: jQuery object with id='" + containerDataInputId + "' failed to return element." + "\n Unable to focus back on input on close.");
            }
        } else {
            //Debug console.log("jquery-ui-datePicker-accessibility-helper: DEBUG Dialog display display status is not defined for container id='" + containerDataInputId + "'.");
        }
    } else {
        //Debug console.log("jquery-ui-datePicker-accessibility-helper: DEBUG jQuery DatePicker dialog for input id='" + containerDataInputId + "' appears to be already closed.");
    }
}

/**
* Allows the clicking of a calendar date to return focus to the input.
*/
function boe_supportMouseClickFocus() {
    $m("td a.ui-state-default").on('click', function (e) {
        boe_closeCalendar("Source: td 'click' (via boe_supportMouseClickFocus)");
    });
}

/**
 *  Returns true or false depending if a value provided is a string and the string is not "".
 *  @param {value} any value or refrence
 */
function boe_validateStringAndNotEmpty(value) {
    return (typeof value === 'string' || value instanceof String) && value != "";
}

/**
 * Checks to see if there are any datePicker inputs on the document.
 * */
function boe_getDatePickers() {
    var pickers = $m(".hasDatepicker").datepicker();
    if (boe_util_isValidJqueryObject(pickers)) {
        return pickers;
    } else {
        console.log("jquery-ui-datePicker-accessibility-helper: Unable to find initialized jQuery UI datepickers in page.");
        return false;
    }
}

/**
 * This function (modeled after the deque datePickHandler) looks for the datepicker modal object (container) defined by 'ui-datepicker-div'.
 * - Sets aria attributes and role
 * - Adds click event handlers to 
 * @param {String } text - Can be printed in debug and this allows us to track function calls source when debugging.
 */
function boe_datePickHandler(text) {
    if (text && DEBUG_MODE) {
        console.warn("jquery-ui-datePicker-accessibility-helper: DEBUG boe_datePickHandler, Running code to handle keydown events. This function is called from '" + text + "'.");
    }
    var container = document.getElementById('ui-datepicker-div');
    //NOTE: Feature by Board of Elections. Checks to see if there are any datePicker inputs on the document.
    var pickers = boe_getDatePickers();

    if (!container || !pickers) {
        console.log("jquery-ui-datePicker-accessibility-helper: Did not locate boe_datePickHandler container = '" + typeof container + "'.");
        return;//Exit this function
    }

    container.setAttribute('role', 'dialog');
    container.setAttribute('aria-label', 'Calendar view date-picker');

    //The top controls:
    var prev = $m('.ui-datepicker-prev', container)[0],
        next = $m('.ui-datepicker-next', container)[0];

    // This is the line that needs to be fixed for use on pages with base URL set in head
    next.href = 'javascript:void(0)';
    prev.href = 'javascript:void(0)';

    next.setAttribute('role', 'button');
    next.removeAttribute('title');
    prev.setAttribute('role', 'button');
    prev.removeAttribute('title');

    appendOffscreenMonthText(next);
    appendOffscreenMonthText(prev);

    //Add an aria-label to the date link indicating the currently focused date
    monthDayYearText();
    //Debug console.log("jquery-ui-datePicker-accessibility-helper: DEBUG boe_datePickHandler, Setting up key down event for element with id ='" + container.id + "' !");
    boe_addKeyboardListener(container);

}

/**
 * The minDate or maxDate ranges can affect the ability to find a date to focus on.
 * This function finds us a day to focus in the calendar.
 * @param {boolean} debug Used to print debug text.
 */
function boe_findDayToFocus(debug) {
    //Attempts to find the current day if it is available.
    var dayToFocus = $m('.ui-datepicker-today a')[0];
    var focusMessage = "not set.";
    if (!boe_util_isValidJqueryObject(dayToFocus)) {
        //Tries to find the day that's currently active.
        dayToFocus = $m('td a.ui-state-active')[0];
        if (!boe_util_isValidJqueryObject(dayToFocus)) {
            //Tries to find the last available/visible selectable day.
            var availableDays = $m('td a.ui-state-default');
            dayToFocus = availableDays[availableDays.length - 1];
            if (boe_util_isValidJqueryObject(availableDays)) {
                dayToFocus = availableDays[availableDays.length - 1];
                focusMessage = "set to 'last available day'."
            } else {
                console.warn("jquery-ui-datePicker-accessibility-helper: Unable to find calendar day to focus on.");
            }
        } else {
            focusMessage = "set to 'active'."
        }
    } else {
        focusMessage = "set to 'today'."
    }
    if (debug) {
        console.log("jquery-ui-datePicker-accessibility-helper: DEBUG focus " + focusMessage);
    }
    return dayToFocus;
}

/**
 * Adds aria-disabled="true" along with "tabindex = -1" on the disabled elements.
 */
function boe_setDisabledTabFocusAndAriaLabel() {
    //Debug console.log("jquery-ui-datePicker-accessibility-helper: DEBUG boe_setDisabledTabFocusAndAriaLabel");
    var datePickDiv = document.getElementById('ui-datepicker-div');
    // In case we find no datepick div
    if (!datePickDiv) {
        return;//Exit this function
    }

    //1) Get all the disabled number elements, next and previous buttons.td.ui-datepicker-unselectable.ui-state-disabled
    var dates = $m('table.ui-datepicker-calendar tbody tr td, a.ui-datepicker-next, a.ui-datepicker-prev', datePickDiv);
    $m(dates).each(function (index, date) {
        var jqDate = $m(date);
        //2a) Add the accessible attributes where needed.
        if (jqDate.hasClass("ui-state-disabled")) {
            jqDate.attr('aria-disabled', true);
            //Set the tab index on disabled element.
            if (jqDate.prop('nodeName').toLowerCase() == 'td' ||
                jqDate.prop('nodeName').toLowerCase() == 'a') {
                jqDate.attr('tabindex', -1);
            }
        } else {
            //2b) Remove the accessible attributes where needed.
            if (jqDate.attr('aria-disabled')) {
                date.removeAttr('aria-disabled');
            }
            if (jqDate.attr('tabindex') == -1) {
                date.removeAttr("tabindex");
            }
        }
    });
}

/**
 * Checks if the object is a jquery object returning true or false.
 * @param {any} object
 */
function boe_util_isValidJqueryObject(object) {
    return object && object.jquery && object.length > 0;
}


/////////////////////////////////////////////////////////
//END Custom Functions created for BOE compatibility
/////////////////////////////////////////////////////////