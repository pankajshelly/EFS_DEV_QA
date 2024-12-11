/**
 * jquery-ui-global-accessibility-helper.js
 * Provides functions to increase jquery-ui-1.12.1 (or higher) user accessibility.
 * User accessibility is inteded to meet WCAG 2.0 compliance.
 * Version key major.minor.patch
 * Version 1.0.10 - Last formal update 07/15/2021
 * Requires jquery-ui-1.12.1 (or higher).
 * Requires jquery-3.5.0 (or higher).
 * Author Jorge Diaz
 */
window.$m = jQuery.noConflict();

/**
 * Custom plug in that allows us to Change an element with all it's attributes and contents.
 * to use call <jquery element>.boeChangeElementType("") plus the "stringNewType" after a jquery element.
 */
(function ($m) {
    /**
     * Change an element with all it's attributes and contents.
     * To use call <jquery element>.boeChangeElementType("") plus the "stringNewType" after a jquery element.
     */
    $m.fn.boe_changeElementType = function (stringNewType) {
        try {
            var attrs = this.boe_collectAttributes();
            var contents = this.contents();
            this.replaceWith(function () {
                return $m("<" + stringNewType + "/>", attrs).append(contents);
            });
        } catch (e) {
            console.error("jquery-ui-global-accessibility-helper.js CATCH: Something went wrong while executing dialog boe_changeElementType. This jquery widget extension may need to be reviewed.");
            console.error(e);
        }
    };

    /**
     * Returns all attributes for a given element.
     * To use call <jquery element>.boe_collectAttributes().
     */
    $m.fn.boe_collectAttributes = function () {
        var attrs = {};
        try {
            $m.each(this[0].attributes, function (idx, attr) {
                attrs[attr.nodeName] = attr.nodeValue;
            });
        } catch (e) {
            console.error("jquery-ui-global-accessibility-helper.js CATCH: Something went wrong while executing dialog boe_collectAttributes. This jquery widget extension may need to be reviewed.");
            console.error(e);
        }
        return attrs;
    };
})(jQuery);



/////////////////////////////////////////////////////////
// JQUERY UI Extensions
/////////////////////////////////////////////////////////
/**
 * Extends the jquery ui dialog.
 * Test HTML and javascript code:
<button id="testDialogButton">Open Dialog</button>
<div id="testDialog" title="Basic dialog">
    <p>This is the default dialog which is useful for displaying information. The dialog window can be moved, resized and closed with the 'x' icon.</p>
</div>
var testDialog = $m("#testDialog").dialog({
    autoOpen: false,
    resizable: false,
    height: 'auto',
    width: 800,
    position: {
        my: "center top",
        at: "center top+250",
    },
    modal: true,
    resizable: false,
    closeOnEscape: false,
    buttons: [
        {
            text: "Ok",
            class: "btn btn-default",
            click: function () {
                $m(this).dialog('close');
            }
        },
        {
            text: "Cancel",
            class: "btn btn-default",
            click: function () {
                $m(this).dialog('close');
            }
        }
    ]
});
$m("#testDialogButton").on("click", function () {
    console.log("testDialogButton click");
    testDialog.dialog("open");
});
*/
$m.widget("ui.dialog", $m.ui.dialog, {
    open: function () {
        /**This is a partial fix for an issue which stems from incompatibility in the order in which jquery-ui.js and bootstrap.js are loaded in the page and was first discovered while working on ALM Defect 4200.
         * When jquery-ui.j is loaded before bootstrap.js the later interferes with code that creates the[x] button on dialogs.
         * This code will locate the [x] button and ensure it contains the elments and classes needed for rendering the icons.
        */
        $m(this.uiDialogTitlebar).find(".ui-dialog-titlebar-close").addClass("ui-button ui-corner-all ui-widget ui-button-icon-only").html("<span class='ui-button-icon ui-icon ui-icon-closethick' aria-label='Close Dialog'></span><span class='ui-button-icon-space'></span></button>");
        return this._super();
    },
    _create: function () {
        // This extension is intended to prevent the violation "Avoid the use of implicit headings".
        // Will change the element used in .ui-dialog-title from <span> to <title>
        // Had we not changed it we should have to change attributes for "role" to"heading" and "aria-level" to "2".
        try {
            //Debug console.log("jquery-ui-global-accessibility-helper.js DEBUG: Executing dialog _create extended function for heading.");
            this._super();// Invoke the parent widget's original function.
            var dialogTitle = $m(this.uiDialogTitlebar).find(".ui-dialog-title");
            dialogTitle.boe_changeElementType("h2");
            //Debug var nodeNameBefore = dialogTitle.prop('nodeName');
            //Debug var nodeNameAfter = $m(this.uiDialogTitlebar).find(".ui-dialog-title").prop('nodeName');
            //Debug console.log("jquery-ui-global-accessibility-helper.js DEBUG: Modified the dialog from '" + nodeNameBefore + "' to '" + nodeNameAfter + "'.");
        } catch (e) {
            console.error("jquery-ui-global-accessibility-helper.js CATCH: Something went wrong while executing dialog dialog._create try block. This jquery widget extension may need to be reviewed.");
            console.error(e);
        }
    },
    _createButtonPane: function () {
        //Extension for defect to make button titles match content. ALM Defect 3667
        try {
            this._super();// Invoke the parent widget's original function.
            //Debug console.log("jquery-ui-global-accessibility-helper.js DEBUG: Executing dialog _createButtonPane extended function for buttons.");
            $m(this.uiDialogButtonPane).find("button").each(function (index) {
                //Debug console.log("jquery-ui-global-accessibility-helper.js DEBUG: Index " + index + " > Before " + $(this).text());
                $(this).attr("title", $(this).text());
                //Debug console.log("jquery-ui-global-accessibility-helper.js DEBUG: Index " + index + " > After " + $(this).text());
            });
        } catch (e) {
            console.error("jquery-ui-global-accessibility-helper.js CATCH: Something went wrong while executing dialog dialog._createButtonPane try block. This jquery widget extension may need to be reviewed.");
            console.error(e);
        }
    }
});

/**
 * Extends the jquery ui accordion.
 * Test HTML and javascript code:
<button id="testAccordionRefresh" type="button">Accordion Refresh</button><br/>
<button id="testAccordionDisable" type="button">Accordion Disable</button><br/>
<button id="testAccordionEnable" type="button">Accordion Enable</button><br/>
<button id="testAccordionDestroy" type="button">Accordion Destroy</button><br/>
<button id="testAccordionCreate" type="button">Accordion Create</button><br/>
<div id="testAccordion">
    <h3><label for="testName">Section 1 Label </label> <input type="text" id="testName" name="testName"></h3>
    <div>
        <p>
            Section text 1.
        </p>
    </div>
    <h3>Section 2</h3>
    <div>
        <p>
            Section text 2.
        </p>
    </div>
</div>
var testAccordion = $m("#testAccordion").accordion();
$m("#testAccordionRefresh").on("click", function () {
    console.log("testAccordionRefresh click");
    if (typeof testAccordion.accordion("instance") != 'undefined') {
        $m("#testAccordion").append("<h3>" + new Date() + "</h3><div>" + new Date() + "</div>");
        testAccordion.accordion("refresh");
    }
});
$m("#testAccordionDisable").on("click", function () {
    console.log("testAccordionDisable click");
    if (typeof testAccordion.accordion("instance") != 'undefined') {
        testAccordion.accordion("disable");
    }
});
$m("#testAccordionEnable").on("click", function () {
    console.log("testAccordionEnable click");
    if (typeof testAccordion.accordion("instance") != 'undefined') {
        testAccordion.accordion("enable");
    }
});
$m("#testAccordionDestroy").on("click", function () {
    console.log("testAccordionDestroy click");
    if (typeof testAccordion.accordion("instance") != 'undefined') {
        testAccordion.accordion("destroy");
    }
});
$m("#testAccordionCreate").on("click", function () {
    console.log("testAccordionCreate click");
    if (typeof testAccordion.accordion("instance") == 'undefined') {
        testAccordion = $m("#testAccordion").accordion();
    } else {
        console.log("testAccordionCreate click already exists!");
    }
});
 */
$m.widget("ui.accordion", $m.ui.accordion, {
    // This extension is intended to prevent the violation "Avoid the use of implicit headings".
    // Will change the element used in .ui-dialog-title from <span> to <title>
    // Had we not changed it we should have to change attributes for "role" to"heading" and "aria-level" to "2".
    //Debug console.log("jquery-ui-global-accessibility-helper.js DEBUG: Executing dialog _create extended function.");
    _destroy: function () {
        this._super();// Invoke the parent widget's original function.
        this._boe_restoreOriginalHeaders();
    },
    refresh: function () {
        this._boe_restoreOriginalHeaders();
        this._super();// Invoke the parent widget's original function.
    },
    _refresh: function () {
        this._boe_restoreOriginalHeaders();
        this._super();// Invoke the parent widget's original function.
        this._boe_createAccessibleHeaders();
    },
    _eventHandler: function (event) {
        this._super(event);// Invoke the parent widget's original function.
        try {
            this.headers.each(function (index, header) {
                //Debug console.log("jquery-ui-global-accessibility-helper.js DEBUG: Executing accordion._eventHandler index:'" + index+ "'.");
                var oldHeader = $m(header); //Get the old header.
                var sibling = $m(header).prev("#" + oldHeader.attr("id"));//Get the sibling with the same id.
                sibling.attr("class", oldHeader.attr("class"));//Copy the class definitions to the header.
                sibling.find("button").attr("aria-expanded", oldHeader.attr("aria-expanded"));//Copy the aria-expanded status to the button.
                sibling.find("button span.ui-accordion-header-icon").attr("class", oldHeader.children("span.ui-accordion-header-icon").attr("class"));//Copy the class definitions to the button icon.
            });
        } catch (e) {
            console.error("jquery-ui-global-accessibility-helper.js CATCH: Something went wrong while executing dialog accordion._eventHandler. This jquery widget extension may need to be reviewed.");
            console.error(e);
        }
    },
    _keydown: function (event) {
        this._super(event);// Invoke the parent widget's original function.
        //Now use the event info to change focus to various buttons.
        try {
            //Debug console.log("jquery-ui-global-accessibility-helper.js DEBUG: Executing accordion._keydown event.target:'" + event.keyCode + "'.");
            var keyCode = $m.ui.keyCode,
                length = this.buttonsAccessible.length,
                currentIndex = this.headers.index(event.target),
                toFocus = false;
            switch (event.keyCode) {
                case keyCode.RIGHT:
                case keyCode.DOWN:
                    toFocus = this.buttonsAccessible[(currentIndex + 1) % length];
                    break;
                case keyCode.LEFT:
                case keyCode.UP:
                    toFocus = this.buttonsAccessible[(currentIndex - 1 + length) % length];
                    break;
                case keyCode.HOME:
                    toFocus = this.buttonsAccessible[0];
                    break;
                case keyCode.END:
                    toFocus = this.buttonsAccessible[length - 1];
                    break;
            }
            if (toFocus) {
                $m(toFocus).trigger("focus");
                event.preventDefault();
            }
        } catch (e) {
            console.error("jquery-ui-global-accessibility-helper.js CATCH: Something went wrong while executing dialog accordion._keydown. This jquery widget extension may need to be reviewed.");
            console.error(e);
        }
    },
    _boe_restoreOriginalHeaders: function () {
        try {
            //Debug console.log("jquery-ui-global-accessibility-helper.js DEBUG: Executing accordion._boe_CreateAccessibleHeaders index:'" + index+ "'.");
            $m.each(this.headersAccessible, function (key, value) {
                $m(value).remove();//We use this as a proxy.
            });
            this.headers.each(function (index, header) {
                $m(header).show();//We use this as a proxy.
            });
        } catch (e) {
            console.error("jquery-ui-global-accessibility-helper.js CATCH: Something went wrong while executing dialog accordion._boe_restoreOriginalHeaders. This jquery widget extension may need to be reviewed.");
            console.error(e);
        }
    },
    _boe_createAccessibleHeaders: function () {
        try {
            var lib = this;
            this.headersAccessible = [];
            this.buttonsAccessible = [];
            this.headers.each(function (index, header) {
                //Debug console.log("jquery-ui-global-accessibility-helper.js DEBUG: Executing accordion._boe_CreateAccessibleHeaders index:'" + index+ "'.");
                var oldHeader = $m(header); //Get the old header.
                var oldHeaderSpan = oldHeader.children("span.ui-accordion-header-icon").clone();//Only grab the span with the triangle.
                var newHeader = $m("<" + header.nodeName + "/>").attr({
                    "class": oldHeader.attr("class"),
                    "id": oldHeader.attr("id")
                });
                var newButton = $m("<button/>").attr({
                    "type": "button",
                    "aria-expanded": oldHeader.attr("aria-expanded"),
                    "aria-controls": oldHeader.attr("aria-controls"),
                    "style": "margin-right:min(1em);"
                        + "margin-left:0;"
                        + "background-color: inherit;"
                        + "padding:0.25em;"
                        + "border-width:3px;"
                        + "border-color:#eee;"
                });
                newButton.append(oldHeaderSpan);//Get the old headers span.
                newButton.on("click", function () {
                    oldHeader.click();
                }).keydown(function (e) {
                    var newEvent = $m.Event('keydown');//Create new event.
                    newEvent.which = e.keyCode;
                    newEvent.keyCode = e.keyCode;
                    newEvent.ctrlKey = e.ctrlKey;
                    newEvent.keyCode = e.keyCode;
                    oldHeader.trigger(newEvent);//Trigger the event on the hidden header.
                });
                newHeader.append(newButton);
                //Get a clone of the old header, remove the span with the accordion-header-icon and then get rest of it's current children.
                var oldHeaderChildren = oldHeader.clone().find("span.ui-accordion-header-icon").remove().end().children();
                //Get a clone of the old header and retrieve only the inner text.
                var oldHeaderText = oldHeader.clone().children().remove().end().text();
                newHeader.append(oldHeaderChildren);
                newHeader.append(oldHeaderText);
                newHeader.insertBefore(oldHeader);
                lib.headersAccessible.push(newHeader);
                lib.buttonsAccessible.push(newButton);
                oldHeader.hide();//We use this as a proxy.
            });
            this.panels.each(function (index, panel) {
                $m(panel).attr("role", "region");
            });
        } catch (e) {
            console.error("jquery-ui-global-accessibility-helper.js CATCH: Something went wrong while executing dialog accordion._boe_createAccessibleHeaders. This jquery widget extension may need to be reviewed.");
            console.error(e);
        }
    },
});