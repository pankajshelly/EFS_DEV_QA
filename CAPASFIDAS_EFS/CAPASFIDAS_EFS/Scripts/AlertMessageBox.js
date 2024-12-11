/**
 * AlertMessageBox.js
 * Provides solutions for simplifying the coding of Alert Message Boxes.
 * Creates a custom dialog with 2 buttons. Custom functions can be passed as parameters.
 * For proper operation make sure you include bootstrap.js files prior to jquery.ui.js in your headers. See https://stackoverflow.com/questions/17367736/jquery-ui-dialog-missing-close-icon
 * Version 0.4.2 - Last formal update 12/21/2023
 * Various Authors 
 * 
 * Works best with:
 * - jquery-ui-1.12.0.js or higher
 * - jquery-3.5.0.js or higher
 * Notes:
 * - As of version 0.0.0.2.7 you can add new lines of body text using '\n' in your string. As in 'this\nhas\nnewlines'.
 * */
var $m = jQuery.noConflict();

/**
 * Common function for dialog box generation complete with function definitions
 * @param {Object} Params - See object attribute details.
 * title (string) -title for the dialog. If false  or null the dialog will display "No title provided".
 * content (string) - content for the dialog. If false  or null the dialog will provide "".
 * btn1text (string)  - String for Ok button. If not provided the button will not draw.
 * btn2text (string) - String for the Cancel button. If not provided the button will not draw.
 * openFunction (function) - Function to run as the dialog open. If false or null no funciton will run.
 * okFunction (function) - Function to run as the dialog open. If false or null no funciton will run.
 * cancelFunction (function) - Function to run as the dialog cancels. If false or null no funciton will run.
 * dialogClassesString (string)- Additional classes to apply to the dialogClass parameter.
 * hideDialogXButtonBol (boolean)- Set to true to hide the close dialog [x] button.
 * dialogIdOverride (string) - String for the an id of div html element to use. If not provided a div is created with id="dialog".
 * Sample Code:
 * ShowDialogBoxComplex({
        title: "Foo",
        content: "Bar",
        btn1text: "Lorem",
        btn2text: "Ipsum",
        openFunction: function(){ console.log("Open");},
        okFunction: function(){ console.log("Ok");},
        cancelFunction: function(){ console.log("Cancel");},
        dialogClassesString: "",
        hideDialogXButtonBol: true,
        dialogIdOverride: ""
    })
 */
function ShowDialogBoxComplex(params) {

    //Check the parameters and set default values
    var modalTitle = checkAndReplaceStringIfNull(params.title, "No title provided");
    var modalBtn1text = checkAndReplaceStringIfNull(params.btn1text, "");
    var modalBtn2text = checkAndReplaceStringIfNull(params.btn2text, "");
    //We replace any # just in case.
    var modalId = isNonEmptyString(params.dialogIdOverride) ? checkAndReplaceStringIfNull(params.dialogIdOverride.replace("#", ""), "dialog") : "dialog";

    //Creates new dialog if did not exists or was not provided. 
    if (isElementFound("#" + modalId) === false) {
        createDialogElement(modalId, modalTitle);
    }

    var obj = $m("#" + modalId).text(checkAndReplaceStringIfNull(params.content, ""));
    //The text() fuction doesn't allow to add tags (for security reasons).
    //This feature allows users to enter "\n" and it will replaced with <br/> tags.
    obj.html(obj.html().replace(/\n/g, "<br/>"));

    //Look for elements id="boe-css-overrides" which are relevant for css formatting purposes.
    var objBoeCssOverrides = $m("#boe-css-overrides");
    var appendToSelector = "body";
    if (objBoeCssOverrides.length > 0) {
        //Add inside the element that results in the correct classes to be applied.
        //We use last child to avoid having the dialog get created inside the its banner iframe.
        appendToSelector = "#boe-css-overrides:last-child";
    } else {
        //Prepend to the body.
        console.warn("The dialog element styling may not be subject to css selector styling!");
    }

    return $m("#" + modalId).dialog({
        resizable: false,
        title: modalTitle,
        modal: true,
        appendTo: appendToSelector,
        width: '400px',
        height: 'auto',
        position: {
            my: "top center",
            at: "top center",
            of: window
        },
        create: function (event) { $(event.target).parent().css({ 'position': 'fixed', 'top': '50%', 'margin-top': '-100px', 'left': '50%;', 'margin-left': '-235px' }); },
        hide: { effect: 'scale', duration: 400 },
        dialogClass: checkAndReplaceStringIfNull(params.dialogClassesString, ""),
        closeText: "hide",
        open: function (event, ui) {
            //Hides the dialog X if we ask for it and we expect to have at least one button visible based on modalBtn1Text and modalBtn2Text.
            if ((params.hideDialogXButtonBol && typeof params.hideDialogXButtonBol === 'boolean') && (isNonEmptyString(modalBtn1text) || isNonEmptyString(modalBtn2text))) {
                //Provides support to hide close button in lower version of jquery ui.
                hideDialogXButton(this);
            }
            tryCallFunction(params.openFunction);
        },
        buttons: [
            {
                text: modalBtn1text,
                class: isNonEmptyString(modalBtn1text) ? "btn btn-default clsCommonApply" : "hidecss",
                title: modalBtn1text,
                click: function () {
                    //Close current dialog before running any other close code in the okFunction to prevent '_focusTabbable' error in jquery-ui.
                    $m(this).dialog('close');
                    tryCallFunction(params.okFunction);
                }
            },
            {
                text: modalBtn2text,
                class: isNonEmptyString(modalBtn2text) ? "btn btn-default clsCommonApply" : "hidecss",
                title: modalBtn2text,
                click: function () {
                    //Close current dialog before running any other close code in the cancelFunction to prevent '_focusTabbable' error in jquery-ui.
                    $m(this).dialog('close');
                    tryCallFunction(params.cancelFunction);
                }
            }
        ]
    });
}

/**
 * Deprecated as of version 0.3.1 because of long list of parameters. Use ShowDialogBoxComplex Instead.
 * Common function for dialog box generation complete with function definitions.
 * @param {string} titleVal -title for the dialog. If false  or null the dialog will display "No title provided".
 * @param {string} contentVal - content for the dialog. If false  or null the dialog will provide "".
 * @param {any} btn1textVal - String for Ok button. If not provided the button will not draw.
 * @param {any} btn2textVal - String for the Cancel button. If not provided the button will not draw.
 * @param {any} openFunctionVal - Function to run as the dialog open. If false or null no funciton will run.
 * @param {any} okFunctionVal - Function to run as the dialog open. If false or null no funciton will run.
 * @param {any} cancelFunctionVal - Function to run as the dialog cancels. If false or null no funciton will run.
 * @param {any} dialogClassesStringVal - Additional classes to apply to the dialogClass parameter.
 * @param {any} hideDialogXButtonBolVal - Set to true to hide the close dialog [x] button.
 * @param {any} dialogIdOverrideVal - String for the an id of div html element to use. If not provided a div is created with id="dialog".
 */
function ShowDialogBoxExtended(titleVal, contentVal, btn1textVal, btn2textVal, openFunctionVal, okFunctionVal, cancelFunctionVal, dialogClassesStringVal, hideDialogXButtonBolVal, dialogIdOverrideVal) {
    console.warn("Warning AlertMessageBox.ShowDialogBoxExtended is deprecated as of version 0.3.1. Use ShowDialogBoxComplex instead.");
    //Convert the parameters into an object.
    var params = {
        title: titleVal,
        content: contentVal,
        btn1text: btn1textVal,
        btn2text: btn2textVal,
        openFunction: openFunctionVal,
        okFunction: okFunctionVal,
        cancelFunction: cancelFunctionVal,
        dialogClassesString: dialogClassesStringVal,
        hideDialogXButtonBol: hideDialogXButtonBolVal,
        dialogIdOverride: dialogIdOverrideVal
    }
    //Feed the parameters to the function we should be using.
    ShowDialogBoxComplex(params);
}

/**
 * Depreecated this function was written specifically for candidate management and needs to be deprecated.
 * Eventally code should be modified to use showSessionExpiredDialog or better yet enableSessionExpiredTimeout.
 * */
function ShowDialogSession() {
    console.warn("Warning AlertMessageBox.ShowDialogSession is deprecated as of version 0.3.4. Use ShowDialogBoxComplex instead.");
    showSessionExpiredDialog('@Url.Action("Home", "Home")', "NYSBOE", "modal_dialog");
}

/**
 * He;ps hide the X button when added to the open initialization.
 * Example:
 *    return $m("#" + modalId).dialog({
 *          open: function (event, ui) {
 *              hideDialogXButton(this);
 *          }
 *       });
 * @param {any} element
 */
function hideDialogXButton(element) {
    try {
        if (element) {
            //Provides support to hide close button in lower version of jquery ui.
            $m(element).parent().find("button.ui-dialog-titlebar-close").hide();
        } else {
            console.error("Error AlertMessageBox.hideDialogXButton was not able to hide x button. Element not provided.");
        }
    } catch (e) {
        console.error("Error AlertMessageBox.hideDialogXButton was not able to hide x button. Error found.");
    }
}


/**
 * Displays a dialog box with the specified string parameters
 * @param {string} titleVal -title for the dialog. If false  or null the dialog will display "No title provided".
 * @param {string} contentVal - content for the dialog. If false  or null the dialog will provide "".
 * @param {string} btn1textVal - String for Ok button. If not provided the button will not draw.
 * @param {string} btn2textVal - String for the Cancel button. If not provided the button will not draw.
 */
function ShowDialogBox(titleVal, contentVal, btn1textVal, btn2textVal) {
    var params = {
        title: titleVal,
        content: contentVal,
        btn1text: btn1textVal,
        btn2text: btn2textVal,
        openFunction: null,
        okFunction: null,
        cancelFunction: null,
        dialogClassesString: "",
        hideDialogXButtonBol: true,
        dialogIdOverride: null
    };
    ShowDialogBoxComplex(params);
}

/**
 * Displays a dialog box with the specified string parameters
 * @param {string} titleVal -title for the dialog. If false  or null the dialog will display "No title provided".
 * @param {string} contentVal - content for the dialog. If false  or null the dialog will provide "".
 * @param {string} btn1textVal - String for Ok button. If not provided the button will not draw.
 * @param {string} btn2textVal - String for the Cancel button. If not provided the button will not draw.
 * @param {any} openFunctionVal - Function to run as the dialog open. If false or null no funciton will run.
 */
function ShowDialogBoxWithOpenFunction(titleVal, contentVal, btn1textVal, btn2textVal, openFunctionVal) {
    var params = {
        title: titleVal,
        content: contentVal,
        btn1text: btn1textVal,
        btn2text: btn2textVal,
        openFunction: openFunctionVal,
        okFunction: null,
        cancelFunction: null,
        dialogClassesString: "",
        hideDialogXButtonBol: true,
        dialogIdOverride: null
    };
    ShowDialogBoxComplex(params);
}

/**
 * Sets a session expired timer and helps configure the dialog.
 * To use you must call this inside $(document).ready(function (){});
 * Example: enableSessionExpiredTimeout(@Session.Timeout,'@Url.Action("Home", "Home")', null,  'Case Management System', true, function (){console.log("Redirect!");});
 * @param {number} sessionTimeoutValue Suggested is session time out from web.config.
 * @param {string} redirectHref url to redirect to.
 * @param {string} dialogIdOverride the id of a div to use to render the dialog. If one is not found a default is created.
 * @param {string} dialogTitleOverride the title to use in the dialog. If one is not found a default is created.
 * @param {bool} clearAppsBrowserSessionStorageOnRedirect When true it will clear all brosers Session Storage on Redirect.
 * @param {function} onRedirectWindowOpenFunction A function to call when the redirect window opens.
 */
var SESSION_TIMEOUT_INTERVAL; //Define higher scope variable for the interval
var NEW_TIMEOUT_MILISECONDS; //Define higher scope variable for milliseconds
function enableSessionExpiredTimeout(sessionTimeoutValue, redirectHref, dialogIdOverride, dialogTitleOverride, clearAppsBrowserSessionStorageOnRedirect, onRedirectWindowOpenFunction) {
    //Evaluate parameters
    var dialogId = isNonEmptyString(dialogIdOverride) ? dialogIdOverride : 'redirect_dialog';
    var isFound = isElementFound("#" + dialogId);
    var title = isNonEmptyString(dialogTitleOverride) ? dialogTitleOverride : "Alert Dialog";
    var windowOpenFunction = onRedirectWindowOpenFunction;
    if (!isFound) {
        //Create a div for the dialog if one is not available.
        //console.log("Unable to find div with id '" + dialogId +"'.");
        createDialogElement(dialogId, dialogTitleOverride);
        if (isElementFound("#" + dialogId)) {
            //Run this function again after creating the dialog.
            enableSessionExpiredTimeout(sessionTimeoutValue, redirectHref, dialogId, title, clearAppsBrowserSessionStorageOnRedirect, windowOpenFunction);
        }
    } else {
        //Set the timeout.
        var currentTitle = isNonEmptyString(dialogTitleOverride) ? dialogTitleOverride : $m(dialogId).attr("title");
        if (isNonEmptyString(currentTitle)) {
            title = currentTitle;
        } else {
            console.log("Unable to determine title for dialog. Setting dialog title to 'Dialog'.");
            title = "Dialog";
        }

        NEW_TIMEOUT_MILISECONDS = parseInt(sessionTimeoutValue) * 60 * 1000;

        //Start -Session Code
        clearTimeout(SESSION_TIMEOUT_INTERVAL);//clear it as soon as any event occurs
        console.log("Setting the timeout to '" + NEW_TIMEOUT_MILISECONDS + "' miliseconds.");
        //NOTE for test purposes you can replace NEW_TIMEOUT_MILISECONDS with 5000 (5 seconds);
        SESSION_TIMEOUT_INTERVAL = setTimeout(showSessionExpiredDialog, NEW_TIMEOUT_MILISECONDS, redirectHref, dialogId, title, clearAppsBrowserSessionStorageOnRedirect, windowOpenFunction);

        $m(document).on('click keyup keypress', function () {
            clearTimeout(SESSION_TIMEOUT_INTERVAL);//clear it as soon as any event occurs
            SESSION_TIMEOUT_INTERVAL = setTimeout(showSessionExpiredDialog, NEW_TIMEOUT_MILISECONDS, redirectHref, dialogId, title, clearAppsBrowserSessionStorageOnRedirect, windowOpenFunction);
        });
        //End -Session Code
    }
}

/**
 * Creates a dialog div and appends it to the body element
 * @param {any} dialogId - Id to use for the dialog.
 * @param {any} dialogTitle - Title text for the dialog
 */
function createDialogElement(dialogId, dialogTitle) {
    //Make sure the dialogId is not empty and also make sure it is not already in use.
    var id = isNonEmptyString(dialogId) && !isElementFound("#" + dialogId) ? dialogId : 'createDialogElement_dialog';
    var title = isNonEmptyString(dialogTitle) ? dialogTitle : "Alert Dialog";
    var dialogElement = "<div id='" + id + "' title='" + title + "'><div></div></div>";
    /*We suspect the the EDGE browser sometimes appends this element to the body tag in the iframe.
    Target the "body" element with id = "boe-css-overrides".*/
    if (isElementFound("body#boe-css-overrides")) {
        console.log("Appending to 'body#boe-css-overrides' new elements with id='" + dialogId + "' and title ='" + dialogTitle + "'.");
        //Try to append the dialog to the body element we know is not inside the iframe.
        $m("body#boe-css-overrides").append(dialogElement);
    } else if (isElementFound("nav")) {
        console.log("Appending to 'nav' new elements with id='" + dialogId + "' and title ='" + dialogTitle + "'.");
        //Try to append the dialog to the navbar.
        $m("nav").append(dialogElement);
    } else {
        console.log("Appending to 'body' new elements with id='" + dialogId + "' and title ='" + dialogTitle + "'.");
        //Try to append the dialog to any 'body'.
        $m("body").append(dialogElement);
    }
}

/**
 * Triggers and allert dialog box.
 * @param {string} redirectHref where to go on redirect
 * @param {string} modalId id of dialog to use.
 * @param {string} modalTitle title to display.
 * @param {boolean} clearAppsBrowserSessionStorageOnOpen title to display.
 * @param {function} onOpenFunction any function you want to call when the dialog opens.
 */
function showSessionExpiredDialog(redirectHref, modalId, modalTitle, clearAppsBrowserSessionStorageOnOpen, openFunction) {
    console.log("Triggering Session expired Dialog Box");
    if (isElementFound('#' + modalId)) {
        //The function we pass to the dialog params starts as 'undefined'
        var localOnOpenFunction;
        //If the user provides us with a function we stick it in our assign it.
        if (openFunction || clearAppsBrowserSessionStorageOnOpen) {
            localOnOpenFunction = function () {
                if (openFunction) {
                    tryCallFunction(openFunction);
                }
                if (clearAppsBrowserSessionStorageOnOpen) {
                    sessionStorage.clear();
                }
            }
        }

        //Convert the parameters into an object.
        var params = {
            title: modalTitle,
            content: "Session expired. You will be redirected to Home page.",
            btn1text: "Ok",
            btn2text: "",
            openFunction: localOnOpenFunction,
            okFunction: function () { window.location.href = redirectHref; },
            cancelFunction: null,
            dialogClassesString: "",
            hideDialogXButtonBol: true,
            dialogIdOverride: modalId
        }
        //Feed the parameters to the function we should be using.
        ShowDialogBoxComplex(params);
    } else {
        console.warn("Alert Message Box unable to find dialog element with id '" + modalId + "'.");
    }
}

/**
 * Determines if one or more jquery elements matching the selector is found.
 * @param {any} jquerySelector
 */
function isElementFound(jquerySelector) {
    try {
        var foundDiv = $m(jquerySelector);
        return foundDiv.length != 0 && typeof foundDiv === 'object' && foundDiv.jquery;
    } catch (e) {
        console.error("AlertMessageBox isElementFound Error detected.");
        return false;
    }
}

/**
 * Provides a quick way check strings.
 * @param {any} value
 */
function isNonEmptyString(value) {
    try {
        if (typeof value === 'string' || value instanceof String) {
            return value.trim() != "";
        } else {
            return false;
        }
    } catch (e) {
        console.error("AlertMessageBox isNonEmptyString Error detected.");
        return false;
    }
}

/**
 * Checks to see if the value is a function and if it is it will call it.
 * @param {any} functionToCall
 */
function tryCallFunction(functionToCall) {
    try {
        if (isAFunction(functionToCall)) {
            functionToCall();
        }
    } catch (e) {
        console.error("AlertMessageBox tryCallFunction Error detected.");
    }
}

/**
 * Provides a quick way check object is a function.
 * @param {any} functionToTest
 */
function isAFunction(functionToTest) {
    try {
        return functionToTest && {}.toString.call(functionToTest) === '[object Function]';
    } catch (e) {
        console.error("AlertMessageBox isAFunction Error detected.");
        return false;
    }
}

/**
 * Evaluates a value and replacess it if needed.
 * @param {string} original value to check for null or empty.
 * @param {string} replacement to replace the element provided. This can be null, "", or any other string. Undefined values will return null
 */
function checkAndReplaceStringIfNull(original, replacement) {
    try {
        if (isNonEmptyString(original)) {
            return original;
        } else if (replacement === null && (typeof replacement === 'string' || replacement instanceof String)) {
            return replacement;
        } else if (replacement === null) {
            return replacement;
        } else {
            return null;
        }
    } catch (e) {
        console.error("AlertMessageBox checkAndReplaceStringIfNull Error detected.");
        return false;
    }
}