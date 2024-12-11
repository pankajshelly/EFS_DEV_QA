/*
    bootstrap-3.boe-extensions.js
    This file is designed to implement extensions to Bootstrap v3.3.1
    It requires a companion script file: bootstrap-3.boe-extensions.css
    Some of these are features that may become available in future versions of boostrap.
    Version key - major.minor.patch
    Version 0.0.4 - Last formal update 02/10/2022
*/

//Adds extended functionality for bootstrap navbar.
//Must be added to the page's on $m(document).ready(function () { }
var $m = jQuery.noConflict();
function extendBootstrap3Navbar(DEBUG) {
    var debugFlag = DEBUG === true ? true : false;
    printDebug(debugFlag,"Executing extendBootstrap3Navbar with debug message flag set to '"+debugFlag+"'.");
    printDebug(debugFlag, "Initializing extendBootstrap3Navbar.");

    // Toggle Secondary Dropdown on 'click' event.
    $m('.dropdown-submenu a.dropdown-toggle').on("click", function (e) {
        printDebugEvent(debugFlag, e);
        toggleUl(this, e, false, debugFlag);
    });

    // Make Secondary Dropdown visible on Mouse Enter
    $m('.dropdown-submenu a.dropdown-toggle').on("mouseenter",function (e) {
        printDebugEvent(debugFlag, e);
        toggleUl(this, e, 'visible', debugFlag);
    });

    // Make Secondary Dropdown invisible when the children loose focus
    $m('.dropdown-submenu ul.dropdown-menu').on("focusout", function (e) {
        var $event = e;
        var parentUl = this;
        setTimeout(function () {
            var count = $m(parentUl).find(":focus").length;
            if (count == 0) {
                printDebugEvent(debugFlag, $event);
                var target = $m(parentUl).siblings("a.dropdown-toggle");
                toggleUl(target[0], e, 'invisible', debugFlag);
            } 
        }, 100);
    });

    // Make Secondary Dropdown invisible on Mouse Leave
    $m('.dropdown-submenu').on("mouseleave", function (e) {
        printDebugEvent(debugFlag, e);
        toggleUl($m(this).find("a.dropdown-toggle"), e, 'invisible', debugFlag);
    });
}

//Toggles ul
function toggleUl(element, event, limit, printDebugInfo) {
    if (!limit) {
        $m(element).next('ul').toggle();
        event.stopPropagation();
        event.preventDefault();
    } else if (limit === "visible") {
        if (!$m(element).next('ul').is(':visible')) {
            toggleUl(element, event, false);
            $m(element).attr("aria-expanded", "true");
        } else {
            printDebug(printDebugInfo, "Element was already visible");
        }
    } else if (limit === "invisible") {
        if ($m(element).next('ul').is(':visible')) {
            toggleUl(element, event, false);
            $m(element).attr("aria-expanded", "false");
        } else {
            printDebug(printDebugInfo, "Element was already invisible");
        }
    } else {
        console.warn("Unsuported limit '"+limit+"'");
    }
}

//Provides debug event information.
function printDebugEvent(printDebugInfo, event) {
    var debugInfo = printDebugInfo === true ? "extendBootstrap3Navbar Debug: Event type = " : "";
    if (printDebugInfo === true) {
        if (event && event.type) {
            printDebug(true, debugInfo + event.type);
        }
    }
}

//Provides debug information.
function printDebug(printDebugInfo, text) {
    if (printDebugInfo === true) {
        console.log(text);
    }
}
