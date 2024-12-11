/**boe.app-utilities.common.js 
 * Provides functions simplify the common implementation of features in shared views.
 * Requires jquery 3.5 or higher.
 * Works bests with classes from site-boe-common.css 1.1.0 or higher.
 * Version key major-minor-patch
 * Version 1.1.1 - Last formal update 10/17/2022
 * Author Jorge Diaz
 * */

/**
 * The function can be used to trigger a click event on an element only if this element is in foccus.
 * You would add this in the function portion of a keypress event.
 * For example:
 * $(#id)on("keydown", boeAppCommonTriggerClickIfFocussed).click(function () { ... });
 * @param {Event} event
 */
function boeAppCommonTriggerClickIfFocussed(event) {
    try {
        if (event && event.target) {
            //Debug console.log(document.activeElement);
            //Debug console.log($m(event.target)[0]);
            if (document.activeElement === $m(event.target)[0]) {
                if (event.which == 13) {//Enter key pressed
                    //Debug console.log("Debug: boe.app-utilities.common.js boeAppCommonTriggerClickIfFocussed event 13.");
                    $m(event.target).click();//Trigger search button click event
                } else {
                    //Debug console.warn("Debug: boe.app-utilities.common.js boeAppCommonTriggerClickIfFocussed event not supported.");
                }
            } else {
                //Debug console.log("Debug: boe.app-utilities.common.js boeAppCommonTriggerClickIfFocussed.");
            }
        }
    } catch (e) {
        console.error("Error: boe.app-utilities.common.js boeAppCommonTriggerClickIfFocussed.");
        console.error(e);
    }
}

/**
 *  Will iterate through the children of a parent element and return first input that's active and not hidden.
 *  @param {String} parentElementJquerySelector value to use as jquery selector. You know like "#id" or "div.Class" etc.
 *  @param {boolean} debug when not false or null it will display the returned value.
 *  @returns {Object} Returns a jquery object or null.
 */
function bUtilFindFirstActiveInput(parentElementJquerySelector, debug) {
    try {
        var result = null;
        var id = "Not found!"
        if (bUtilIsString(parentElementJquerySelector)) {
            var element = $m(parentElementJquerySelector);
            if (bUtilIsJqueryObject(element)) {
                element.find("input, select, textarea").each(function (i) {
                    var child = $m(this);
                    id = child.attr('id');
                    if (bUtilIsString(id) && bUtilIsInput("#" + id) && !child.prop('disabled')) {
                        result = child;
                        //Break out of the loop
                        return false;
                    }
                });
                if (result == null) {
                    console.warn("Warning: boe.app-utilities.common.js bUtilFindFirstActiveInput. Unable to find input child returning null!");
                }
            }
        } else {
            console.warn("Warning: boe.app-utilities.common.js bUtilFindFirstActiveInput. Unsuported value '" + parentElementJquerySelector + "'.");
        }
        if (debug) {
            console.log(id);
        }
        return result;
    } catch (e) {
        console.error("Error: boe.app-utilities.common.js bUtilFindFirstActiveInput.");
        console.error(e);
    }
}

/**
 *  Attempts to focus on the first active child input child (select or check box) of a parent element.
 *  @param {String} parentElementJquerySelector value to use as jquery selector. You know like "#id" or "div.Class" etc.
 *  @param {int} focusMilisecondDelay use to make the focus event happend with a delay.
 */
function bUtilFocusOnFirstChildImput(parentElementJquerySelector, focusMilisecondDelay) {
    try {
        if (bUtilIsString(parentElementJquerySelector)) {
            var firstInput = bUtilFindFirstActiveInput(parentElementJquerySelector);
            if (bUtilIsJqueryObject(firstInput)) {
                if (bUtilIsNumber(focusMilisecondDelay)) {
                    setTimeout(function () {
                        firstInput.focus();
                    }, focusMilisecondDelay);
                } else {
                    firstInput.focus();
                }
            } else {
                console.warn("Warning: boe.app-utilities.common.js bUtilFocusOnFirstChildImput. Unable to find first child for '" + parentElementJquerySelector + "'.");
            }
        } else { console.warn("Error: boe.app-utilities.common.js bUtilFocusOnFirstChildImput. Invalid selector '" + parentElementJquerySelector + "'."); }
    } catch (e) {
        console.error("Error: boe.app-utilities.common.js bUtilFocusOnFirstChildImput.");
        console.error(e);
    }
}

/**
 *  Determines the type and clears the value of value of an input identified by the selector.
 *  Note that it assumes the checkbox default is false unless you add 
 *  @param {String} jquerySelector string value to use as jquery selector.
 *  @param {boolean} checkboxDefaultOveride boolean value . 
 *  @param {boolean} debugPrint boolean used to print debug messages .
 */
function bUtilInputClearValue(jquerySelector, checkboxDefaultOveride, debugPrint) {
    var value = null;
    var type = bUtilIsInput(jquerySelector);
    try {
        if (type !== false) {
            switch (type.toLowerCase()) {
                case "text":
                    value = $m(jquerySelector).val("");
                    break;
                case "select":
                    $m(jquerySelector).prop('selectedIndex', 0);
                    value = $m(jquerySelector + " option:selected").val();
                    break;
                case "checkbox":
                    value = checkboxDefaultOveride ? true : false;
                    $m(jquerySelector).prop('checked', value);
                    break;
                default:
                    console.warn("Warning: boe.app-utilities.common.js bUtilInputClearValue. Unsuported value '" + type + "'.");
                    break;
            }
            if (debugPrint) {
                console.log("DEBUG: boe.app-utilities.common.js bUtilInputClearValue. Set value of  '" + jquerySelector + "' to '" + value + "'");
            }
        } else {
            console.warn("Warning: boe.app-utilities.common.js bUtilInputClearValue. Unable to fetch value of input defined by selector '" + jquerySelector + "'.");
        }
    } catch (e) {
        console.error("Error: boe.app-utilities.common.js bUtilInputClearValue.");
        console.log(e);
    }
}

/**
 *  Returns the string formatted value of an input identified by the selector.
 *  If the value was not found it will return null.
 *  @param {String} jquerySelector string value to use as jquery selector.
 */
function bUtilInputGetValue(jquerySelector) {
    var value = null;
    var type = bUtilIsInput(jquerySelector);
    try {
        if (type !== false) {
            switch (type.toLowerCase()) {
                case "text":
                    value = $m(jquerySelector).val();
                    break;
                case "select":
                    value = $m(jquerySelector + " option:selected").val();
                    break;
                case "checkbox":
                    value = $m(jquerySelector).is(":checked");
                    break;
                default:
                    console.warn("Warning: boe.app-utilities.common.js bUtilInputGetValue. Unsuported value '" + type + "'.");
                    break;
            }
        } else {
            console.warn("Warning: boe.app-utilities.common.js bUtilInputGetValue. Unable to fetch value of input defined by selector '" + jquerySelector + "'.");
        }
    } catch (e) {
        console.error("Error: boe.app-utilities.common.js bUtilInputGetValue.");
        console.log(e);
    }
    return value;
}

/**
 *  Returns true or false depending if a value provided is a string.
 *  @param {value} any value or refrence
 */
function bUtilIsString(value) {
    return typeof value === 'string' || value instanceof String;
}

/**
 *  Returns true or false depending if a value provided is a number.
 *  @param {value} any value or refrence
 */
function bUtilIsNumber(value) {
    return typeof value === 'number' && isFinite(value);
}

/**
 *  Returns true or false depending if a value provided is a NULL value.
 *  @param {value} any value or refrence
 */
function bUtilIsNull(value) {
    return value === null;
}

/**
 *  Returns true or false depending if a value provided is an Array.
 *  ES5 actually has a method for this (ie9+)
 *  Array.isArray(value);
 *  @param {value} any value or refrence
 */
function bUtilIsArray(value) {
    return value && typeof value === 'object' && value.constructor === Array;
}

/**
 *  Returns true or false depending if a value provided is a boolean.
 *  @param {value} any value or refrence
 */
function bUtilIsBoolean(value) {
    return typeof value === 'boolean';
}

/**
 *  Returns true or false depending if a value provided is a an error object.
 *  @param {value} any value or refrence
 */
function bUtilIsError(value) {
    return value instanceof Error && typeof value.message !== 'undefined';
}

/**
 *  Returns true or false depending if a value provided is a date.
 *  @param {value} any value or refrence
 */
// Returns if value is a date object
function bUtilIsDate(value) {
    return value instanceof Date;
}

/**
 *  Returns true or false depending if a value provided is a function.
 *  @param {value} any value or refrence
 */
function bUtilIsFunction(value) {
    return typeof value === 'function';
}

/**
 *  Returns type/true or false if a value is an input type.
 *  @param {String} jquerySelector
 */
function bUtilIsInput(jquerySelector) {
    var isInput = false;
    if (bUtilIsString(jquerySelector)) {
        var element = $m(jquerySelector);
        var type = false;
        if (element && element.length > 0) {
            type = element[0].tagName;
        }
        if (type && type.toLowerCase() === 'input') {
            isInput = element[0].type.toLowerCase();
        } else if ($m(element[0]).prop("tagName") && ["text", "select", "checkbox"].includes(element[0].tagName.toLowerCase())) {
            isInput = element[0].tagName.toLowerCase();
        }
    } else {
        console.error("Error: boe.app-utilities.common.js bUtilIsInput. Did not provide a valid string for jquery selection.");
    }
    return isInput;
}

/**
 * Many times we need to see if we have a valid jquery objet with length greater than 1.
 * This function returns true or false on just that.
 * @param {object} jQuery obj a jQuery object with length > 0.
 */
function bUtilIsJqueryObject(obj) {
    try {
        return obj && obj.length > 0 && typeof obj === 'object' && obj.jquery;
    } catch (e) {
        console.error("Error: boe.app-utilities.common.js bUtilIsJqueryObject. Provide valid dataTable instance.");
        return false;
    }
}

/**
 *  Returns true or false if a value is an Object.
 *  @param {value} any value or refrence
 */
function bUtilIsObject(value) {
    return value && typeof value === 'object' && value.constructor === Object;
}

/**
 *  Returns true or false if a value is a regular expression.
 *  @param {value} any value or refrence
 */
function bUtilIsRegExp(value) {
    return value && typeof value === 'object' && value.constructor === RegExp;
}

/**
 *  Returns true or false if a value is a Symbol.
 *  @param {value} any value or refrence
 */
function bUtilIsSymbol(value) {
    return typeof value === 'symbol';
}

/**
 *  Returns true or false if a value is undefined.
 *  @param {value} any value or refrence
 */
function bUtilIsUndefined(value) {
    return typeof value === 'undefined';
}


/**
 *  Prints out the values of an array of jquery selectors.
 *  @param {[String]} selectorArray of string values to use as jquery selectors
 */
// Tries to print the value of every input matching the selector in the array
function bUtilPrintInputArrayValues(selectorArray) {
    if (bUtilIsArray(selectorArray)) {
        try {
            selectorArray.forEach(function (value) {
                console.log("'" + value + "' is input? Result is type '" + bUtilIsInput(value) + "' and value is = '" + bUtilInputGetValue(value) + "'.");
            });
        } catch (e) {
            console.error("Error: boe.app-utilities.common.js printArrayValues.");
            console.error(e);
        }
    } else {
        console.error("Error: boe.app-utilities.common.js printArrayValues. Did not provide a valid array.");
    }
}

/**
 *  Checks to see if a value is a string and if not it returns "".
 *  @param {value} potentialString value or refrence
 */
function bUtilSanitizeString(potentialString) {
    return bUtilIsString(potentialString) ? potentialString : "";
}

/**
 * This is reusable code for the filter buttons typically called "show/hide" and "hide/show".
 * When called it will initialize click events for hiding the filter and increasing or decreasing the work area grid.
 * There's a bit of set up needed for this to work properly.
 * 
 * Once the set up is done you add this line to the $m(document).ready(function (){}).
 * Example:
 *  $m(document).ready(function () {
 *      bUtilInitializeSimpleFilter();
 *  }
 * 
 * Buttons inside the "workAreaLeft" control the column classes in "workAreaRightGrid".
 * The buttons also control visibility of the filter options in "divTopSection".
 * The most basic set up is:
    @*Class row is required for using column sites and display block 'd-block'.*@
    <div id="workAreaContainer" class="row d-block">
        <div id="workAreaLeft" class="float-left col-xl-2 col-lg-2 col-md-12 col-sm-12">
            <div id="filterTitle" class="bg-color-nys-busines-secondary">
                <div role="heading" class="float-left" aria-level="2">
                    <div role="heading" class="visibleTablet visibleMobile" aria-level="2">
                        County Board Roster
                    </div><div style="padding-left: 1em; display: contents;">Filter</div>
                </div>
                <button type="button" class="btn btn-sm buttonTransparent floatRight clsHideFilterButton">
                    <img src="~/Content/Images/up20.png" alt="Collapse/Hide Filter" />
                </button>
                <button type="button" class="btn btn-sm buttonTransparent floatRight clsShowFilterButton">
                    <img src="~/Content/Images/down20.png" alt="Expand/Show Filter" />
                </button>
            </div>
            <div id="filterContents" class="bg-color-nys-busines-secondary" style="min-height:100px">
                <span>Filter inputs go in here.</span>
            </div>
        </div>
        @*Right side Main section Starts*@
        <div id="workAreaRight" class="float-left col-xl-10 col-lg-10 col-md-12 col-sm-12">
              <!--Header and breadcrumb content goes here.-->
         </div>
         @*Right side bottom section Starts*@
        <div id="workAreaRightGrid" class="divGridCSS float-left gridPaddingLeft2em pb-2 col-xl-10 col-lg-10 col-md-12 col-sm-12">
             <!--Grid content goes here.-->
        </div>
   </div>
 */
function bUtilInitializeSimpleFilter() {
    try {
        //Make the hide button invisible.
        $m(".clsHideFilterButton").hide();
        //The button that hides the filter fields.
        $m(".clsHideFilterButton").bind('click', function (e) {
            $m(".clsHideFilterButton").hide("slow");
            $m(".clsShowFilterButton").show("slow");

            $m("#workAreaRightGrid").removeClass(" col-xl-12 col-lg-12").addClass("col-xl-10 col-lg-10");
            //Contents of the filter.
            $m("#filterContents").show("slow");
        });
        //The button that shows the filter fields.
        $m(".clsShowFilterButton").bind('click', function (e) {
            $m(".clsShowFilterButton").hide("slow");
            $m(".clsHideFilterButton").show("slow");

            $m("#workAreaRightGrid").removeClass(" col-xl-10 col-lg-10").addClass("col-xl-12 col-lg-12");
            //Contents of the filter.
            $m("#filterContents").hide("slow");
        });
    } catch (e) {
        console.error("Error: boe.app-utilities.common.js bUtilInitializeSimpleFilter Error!");
        console.warn(e);
    }
}