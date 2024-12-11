/**Provides functions to increase datatable user accessibility.
 * User accessibility is inteded to meet WCAG 2.0 compliance.
 * Issues tackled are based on accessibility reports from Level Acces (3rd party vendor).
 * dataTables.boe-accessibility-helper.js
 * Version key Major-Minor-Patch
 * Version 3.0.6 - Last formal update 04/10/2023
 * Requires DataTables 1.10.20 (jquery.dataTables.js) or higher.
 * Requires Responsive 2.2.3 (dataTables.responsive.js) or higher.
 * Requires classes defined in jquery.dataTables-boe-overides.css is now Version 1.0.0 or later.
 * Author Jorge Diaz
 * */
var $m = jQuery.noConflict();

checkVersion();
/**
 * Utility for tracking our Bundled versions.
 */
function checkVersion() {
    var expected = '1.10.2';
    if (!$m.fn.dataTable.versionCheck(expected)) {
        console.log("Expected datatable version " + expected + ". Found version " + $m.fn.dataTable.version + ".");
    }
}


/**
 * Makes paginator anchors accessible by:
 * # Add or remove aria-labels on paginator buttons.
 * # When adding aria-labels it should read "Active table page n paginator control", "Table page n paginator control" or "Disabled table page n paginator control".
 * WCAG accessibility. Ensure color is not used as the sole method of indicating selection
 *  @param {object} jQuery object for datatables this will be $m("#<table id>_paginate").children("a") and $m("#<table id>_paginate").children("span").children("a")
 */
function makePaginatorAnchorAccessible(nodeList) {
    if (nodeList && typeof nodeList == "object" && nodeList.length) {
        nodeList.each(function (index) {
            //$m() changes this to jquery obect.
            var isDisabledControl = $m(this).hasClass("disabled");
            var isCurrentPage = $m(this).hasClass("current");
            var newAccessibleText = "";

            if (isDisabledControl === true) {
                newAccessibleText = "Disabled " + $m(this).html() + " table paginator control";
            } else if (isCurrentPage === true) {
                newAccessibleText = "Active table page " + $m(this).html() + " paginator control";
            } else {
                newAccessibleText = "Table page " + $m(this).html() + " paginator control";
            }

            if (newAccessibleText != "") {
                //Debug console.log("Setting title to '" + newAccessibleText + "' in " + this.id);
                $m(this).attr("aria-label", newAccessibleText); //Update for screen reader requirement.
            } else {
                //Update for screen reader requirement.
                $m(this).removeAttr("aria-label");
            }
        });
    } else {
        console.log("No paginators needed for '" + nodeList + "' of type '" + typeof nodeList + "' and lenght of '" + nodeList.length + "'.");
    }
}

/**
 * Creates a MutationObserver interface provides the ability to watch for changes being made to the DOM tree and alter the datatable paginator buttons when it detects changes.
 * @param {string} idSelector for the jquery datatable paginator object typically identified by id "<table id>_paginate".
 */
function newPaginatorObserver(idSelector) {
    if ("MutationObserver" in window && idSelector && idSelector != "") {
        return new MutationObserver(function (mutations) {
            //Internet explorer compliant iterator.
            $m.each(mutations, function (index, mutation) {
                //Targets the paginator with id of "<table id>_paginate"
                if (mutation.target && mutation.target.id.indexOf("_paginate") !== -1) {
                    makePaginatorAnchorAccessible($m("#" + idSelector).children("a"));//Does Next and Previous buttons.
                    makePaginatorAnchorAccessible($m("#" + idSelector).children("span").children("a"));//Does the page numbers.
                    //If we found the paginator we break the loop
                    return false;
                }
            });
        });
    } else {
        console.warn("dataTable-accessibility-helper: This browser version does not support MutationObserver.");
        return null;
    }
}


/**
 * For a given datatable object it makes sure the paginator conforms to accessibility standards.
 * It does this by locating the datatable pagination element element identified by id "<table id>_paginate".
 * From there it sets a mutation observer that triggers when the element is modified by the user or the table code.
 * When a change is detected by the mutation observer it will set accessible attributes to the paginator buttons.
 * This function should be called from the 'initComplete': function (settings, json) {} parameter.
 * WCAG accessibility. Ensure color is not used as the sole method of indicating selection
 *  @param {DataTables.Api DataTable} dataTableInstance - These can be provided via $m('#' + gridName).DataTable() which returns a DataTables API instance and should not to be confused with $m('#' + gridName).dataTable() which returns a jQuery Object.
 */
function makeDataTablePaginatorReaderAccessible(dataTableInstance) {
    if (dataTableInstance) {
        try {
            //Try to get the table
            var id = dataTableInstance.tables().nodes().to$().attr('id');
            if (id && id != "") {
                // Options, target the nodes children, also target the children's decendants.
                var paginatorSelectorId = id + "_paginate";
                var node = $m("#" + paginatorSelectorId);
                //Don't assume we have paginators.
                if (node.length) {
                    var options = { childList: true, subtree: true }
                    // Start observing
                    var observer = newPaginatorObserver(paginatorSelectorId);
                    observer.observe(node[0], options);
                    // Uncomment to trigger/force a change in the paginator while debuging.
                    //node.find(">:first-child").children("#" + paginatorSelectorId + "temp").remove();
                    node.children("#" + paginatorSelectorId + "temp").remove();
                }
            }
        } catch (error) {
            console.error("dataTable-accessibility-helper: Unable to process the provided dataTableInstance.");
            throw (error);//Rethrow the error so we can see what the actual issue was.
        }
    } else {
        console.warn("dataTable-accessibility-helper: Please provide valid dataTable instance.");
    }
}

/** 
 *  Adds apply and clear buttons to the datatable search feature.
 *  This function should be called from the initComplete: function (settings, json) event trigger.
 *  WCAG accessibility. Avoid using event handlers that trigger focus or context changes on user input.
 *  The 'Search' input field changes the context of the page on input without the user being advised.
 *  When input controls change the content of the page onchange, the page content will change as soon as a keyboard performs input.
 *  Keyboard users will not be able to move use and review the input field.
 *  @param {string} tableId
 *  @param {boolean} enableClearButton
 */
function addCustomSearchButtons(tableId, enableClearButton) {
    try {
        var btnClass = 'btn btn-default btn-xm';
        //Validate a table id is provided.
        if (typeof tableId === 'string' || tableId instanceof String) {
            //Debug console.log("dataTable-accessibility-helper: Adding search button to table='" + tableId +"'.");
            //Unbind events to the filter input field
            var input = $m('#' + tableId + '_filter' + '.dataTables_filter label input');
            var filterID = tableId + '_filterSearchInput';
            input.attr('id', filterID);//Adding a "unique" id is not required but it is helpfull when inspecting the dom elements for errors. .
            input.off();//Remove bindings to filter.
            //Make sure to use var when defining the API ref to avoid the variable from bubbling up and attaching to a global var.
            var dtApiRef = $m('#' + tableId).DataTable();
            var $searchButton, $clearButton;
            // Create search button
            $searchButton = $m('<button>', {
                text: 'Search',
                type: 'button',
                class: btnClass,
                title: 'Search using Filter text',
                id: tableId + '_btn_search',
                click: function (target) {
                    var value = input.val();
                    //Debug console.log("dataTable-accessibility-helper addCustomSearchButtons DEBUG: Search button performed for table id='" + tableId + "' and input id ='" + filterID+"' with value='"+ value +"'.");
                    //Bind the search to this button.
                    dtApiRef.search(value).draw();
                }
            });
            if (enableClearButton === true) {
                //Create clear button
                $clearButton = $m('<button>', {
                    text: 'Clear',
                    type: 'button',
                    class: btnClass,
                    title: 'Clear table Filter',
                    id: tableId + '_btn_clear',
                    click: function () {
                        //Debug console.log("dataTable-accessibility-helper addCustomSearchButtons DEBUG: Clear button performed for table id='" + tableId + "' and input id ='" + filterID+"' with value='"+ input.val() +"'.");
                        //Clear input value.
                        input.val('');
                        //Search with no value to reset table.
                        $searchButton.click();
                    }
                });
                $m('#' + tableId + '_filter' + '.dataTables_filter').append($searchButton, $clearButton);
            } else {
                $m('#' + tableId + '_filter' + '.dataTables_filter').append($searchButton);
            }
        } else {
            console.warn("dataTable-accessibility-helper: Please provide valid dataTable id.");
        }
    } catch (error) {
        console.error("dataTable-accessibility-helper: Unable to process the provided dataTable id.");
        throw (error);//Rethrow the error so we can see what the actual issue was.
    }
}

/**
 *  All encompassing solution for making a datatable accessible.
 *  This function should be called from the initComplete: function (settings, json) event trigger.
 *  @param {DataTables.Api DataTable} dataTableInstance - These can be provided via $m('#' + gridName).DataTable() which returns a DataTables API instance and should not to be confused with $m('#' + gridName).dataTable() which returns a jQuery Object.
 *  @param {boolean} enableSearchClearButton - The clear button on the data table search field will not be shown unless this is true.
 */
function applyInitCompleteGlobalAccessibilityHelpers(dataTableInstance, enableSearchClearButton) {
    makeDataTablePaginatorReaderAccessible(dataTableInstance);
    //Users of this function will get the clear button although it can be specified NOT to.
    addCustomSearchButtons(dataTableInstance.tables().nodes().to$().attr('id'), enableSearchClearButton);
    //Make sure our responsive first cells are accessible.
    setFirstCellAriaAttrubutes(dataTableInstance, 'makeDataTableAccessible');
}

/** 
 *  DEPRECATED: Please use adjustTabIndexFromFirstVisibleColumn instead.
 *  Removes the tabIndex from the first visible column. DataTable adds tab index on sort and filtering.
 *  This function should be called from the <tableInstance>.on('draw', function () {});
 *  WCAG accessibility. Avoid placing inactive elements in the focus order. 
 *  Assistive technology user will get the impression element is interactive and resulting in extra keystrokes to navigate.
 *  @param {DataTables.Api DataTable} dataTableInstance - These can be provided via $m('#' + gridName).DataTable() which returns a DataTables API instance and should not to be confused with $m('#' + gridName).dataTable() which returns a jQuery Object.
 */
function removeTabIndexFromFirstVisibleColumn(dataTableInstance) {
    console.warn("dataTable-accessibility-helper: removeTabIndexFromFirstVisibleColumn is deprecated please use adjustTabIndexFromFirstVisibleColumn instead.");
    if (dataTableInstance) {
        try {
            //Try to get the table
            var id = getDataTableInstanceID(dataTableInstance);
            if (id) {
                // Options, target the nodes children, also target the children's descendants.
                $m("#" + id + " tr td:first-child").removeAttr("tabindex");
            } else {
                console.warn("dataTable-accessibility-helper: Unable to determine table id to update tab index.");
            }
        } catch (error) {
            console.error("dataTable-accessibility-helper: Unable to process the provided dataTableInstance.");
            throw (error);//Rethrow the error so we can see what the actual issue was.
        }
    } else {
        console.warn("dataTable-accessibility-helper: Please provide valid dataTable instance.");
    }
}

/**
 * Many times we need to see if we have a valid jquery objet with length greater than 1.
 * This function returns true or false on just that.
 * @param {object} jQuery obj a jQuery object with length > 0.
 */
function dtHelperUtilityValidateJqueryObj(obj) {
    try {
        return obj && obj.length > 0 && typeof obj === 'object' && obj.jquery;
    } catch (e) {
        console.error("dataTable-accessibility-helper: Provide valid jQuery object instance.");
        return false;
    }
}


/** 
 *  Utility that allows us to validate a dataTable instance and retrieve the table ID.
 *  @returns {string or false} - Will return the id of the dataTable or false.
 *  @param {DataTables.Api DataTable} dataTableInstance - These can be provided via $m('#' + gridName).DataTable() which returns a DataTables API instance and should not to be confused with $m('#' + gridName).dataTable() which returns a jQuery Object.
 */
function getDataTableInstanceID(dataTableInstance) {
    var stringId = false;
    try {
        if (dataTableInstance instanceof $m.fn.dataTable.Api) {
            //Debug console.log("Instance is valid");
            //Try to get the table
            var tableId = dataTableInstance.tables().nodes().to$().attr('id');
            if (typeof tableId === 'string' || tableId instanceof String && tableId != "") {
                var instances = $m("#" + tableId);
                //Check if we are duplicating ID's. Duplicate Id's will lead to unexpected errors.
                //Debug console.log(instances.length);
                switch (instances.length) {
                    case 0:
                        throw new Error("dataTable-accessibility-helper:  ERROR table id " + tableId + " failed to return instances!");
                    case 1:
                        //Debug console.log("dataTable-accessibility-helper: Instance ID is valid");
                        stringId = tableId;
                        break;
                    default:
                        throw new Error("dataTable-accessibility-helper: ERROR table id " + tableId + " is not unique returned multiple instances!");
                }
            } else {
                console.warn("dataTable-accessibility-helper: Unable to determine table id.");
            }
        }
        return stringId;
    } catch (error) {
        console.error("dataTable-accessibility-helper: Unable to process the provided dataTableInstance.");
        throw (error);//Rethrow the error so we can see what the actual issue was.
    }
}

/**
 *  This is not an accessibility fix but rather a fix for what is likely an accessibility side effect.
 *  Fix for Defect 3883 where the Enter Key was triggering the asp.net calls to the controller.
 *  @param {DataTables.Api DataTable} dataTableInstance - These can be provided via $m('#' + gridName).DataTable() which returns a DataTables API instance and should not to be confused with $m('#' + gridName).dataTable() which returns a jQuery Object.
 */
function captureSearchInputEnterKeyPress(dataTableInstance) {
    try {
        if (dataTableInstance) {
            //Try to get the table id
            var id = getDataTableInstanceID(dataTableInstance);
            //Skip if we don't have it.
            if (!id) {
                return;
            }
            //Get the search input.
            var searchInput = $m("#" + id + "_filterSearchInput");
            //Skip if we already set a data-captureSearchInputEnterKeyPress attribute for this input
            if (searchInput.attr("data-captureSearchInputEnterKeyPress") == "true") {
                return;
            }
            //Adds the data-captureSearchInputEnterKeyPress reference attribute. Add the special data attribute so we only add this code once.
            searchInput.attr("data-captureSearchInputEnterKeyPress", "true");
            //Now will set an event listener for this element using the neter key..
            searchInput.keypress(function (event) {
                var keycode = (event.keyCode ? event.keyCode : event.which);
                if (keycode == '13') {
                    event.preventDefault();
                    //Debug console.log("dataTable-accessibility-helper captureSearchInputEnterKeyPress DEBUG: Caputuring keycode '"+ keycode + "'(aka. 'Enter').");
                }
            });
        } else {
            console.warn("dataTable-accessibility-helper: Please provide valid dataTable instance.");
        }
    } catch (error) {
        console.error("dataTable-accessibility-helper: Unable to process the provided dataTableInstance.");
        throw (error);//Rethrow the error so we can see what the actual issue was.
    }
}

/**
 *  This function tries to replace default cell responsive control with buttons.
 *  @param {object} tableRowFirstTdChildren - jQuery , typically first Td <child> object for a datatables <row>.
 */
function tryReplaceFirstCellResponsiveControlWithButtons(tableRowFirstTdChildren) {
    try {
        // We will attempt to replace default cell responsive control with buttons.
        /* 1) Create variables to store references with the click event we would need to replace. */
        var clickEventElement = null;

        /* 2) Looks at the first row to determine if we can expect click events.*/
        var currentElement = $m(tableRowFirstTdChildren[0]);
        var elementFound = false;
        var iteratorStopper = 0; //Prevents out of control looping.
        var maxIteration = 4;

        /* 2 Move up from the first rows td cell and locate and object with the event handler used by datatables and Locate index that points to the first child.
        * Starting on td:first-child it will move up. Typically finding it on the table <tr> row itself. 
        * These handlers are usually set dataTables.responsives.js _detailsInit function definition. */
        while (!elementFound && iteratorStopper < maxIteration) {
            // Do we have an element and does the currentElement contain any click events?
            if (typeof currentElement[0] != 'undefined'
                && typeof jQuery._data(currentElement[0], "events") != 'undefined'
                && typeof jQuery._data(currentElement[0], "events").click != 'undefined') {
                elementFound = "maybe";
                break;
            }
            currentElement = currentElement.parent();
            iteratorStopper++;
        }

        //Exit if we don't have an element at this point skip the rest of the function.
        if (!elementFound) {
            console.warn("dataTable-accessibility-helper: Unable to find click event handler after '" + maxIteration + "' iterations.");
            return;
        }

        /* 3 When we see click events we dig deeper to find if they are both mapped to the td:first-child and get their click[index]. */
        //Are the click events mapped to the "td:first-child"?
        var eventsLength = jQuery._data(currentElement[0], "events").click.length;
        //Iterate through each click index object and but stop when elementFound is not true.
        var clickEventIndex = null;
        //Reset element found.
        elementFound = false;
        for (var index = 0; index < eventsLength && !elementFound; index++) {
            //Get the 'click' events registered at the current index.
            var clickIndexObject = jQuery._data(currentElement[0], "events").click[index]
            var condition1 = false;
            var condition2 = false;
            // Do they exists (meaning they are not 'undefined')?
            if (typeof clickIndexObject != 'undefined') {
                /*
                 * We have found our element if we meet two conditions. 
                 * Condition 1: It has to be the first element of the table.
                 * This can be determined by checking the click event selector which is one of either/or:
                 *  - "td:first-child" in datatables 1.10.2
                 *  - "td.dtr-control" in datatables 1.12.1.
                */
                condition1 = (clickIndexObject.selector.includes("td:first-child") === true || clickIndexObject.selector.includes("td.dtr-control"));
                /*
                 * Condition 2: Check to see if we already added the accessible button. 
                 * This is known because it has the click event "button.accessibilityJQueryClassSelector".
                */
                condition2 = clickIndexObject.selector.includes("button.accessibilityJQueryClassSelector") === true;
                elementFound = condition1 || condition2;
            }
            //If we find the element we set the click envent index and element found to break the loop.
            clickEventIndex = index;
            //Debug console.log("dataTable-accessibility-helper tryReplaceFirstCellResponsiveControlWithButtons DEBUG: Processing index '" + index + ":" + eventsLength + "'. Current selector is '" + jQuery._data(currentElement[0], "events").click[index].selector + "'.");
        }

        /* Set our reference if we can.*/
        if (elementFound === true && clickEventIndex != null) {
            clickEventElement = currentElement;
        }

        //4 Attempt to perform the replacement on each row.
        $m(tableRowFirstTdChildren).each(function () {
            remapResponsiveControlsToButtons(clickEventIndex, clickEventElement, $m(this));
        });
    } catch (e) {
        console.error("dataTable-accessibility-helper : Unable to locate click event handler object.");
        console.log(e);
    }
}

/**
 * Improves accessibility by creating  a button element inside the td element that controls expand and contract. 
 * Click events have their selector remapped activate using the buttons .
 * @param {object} clickEventIndex - clickEventElement that currently controls the expand and collapse event.
 * @param {int} clickEventIndex - is the index of the selector in the clickEvent handler which we need to replace.
 * @param {object} firstTdChild - jQuery first Td <child> object for a datatables <row>.
 */
function remapResponsiveControlsToButtons(clickEventIndex, clickEventElement, firstTdChild) {
    /* 1) Only proceed if we believe to have valid parameters. */
    if (typeof clickEventIndex != "number" || !dtHelperUtilityValidateJqueryObj(clickEventElement) || !dtHelperUtilityValidateJqueryObj(firstTdChild)) {
        console.error("dataTable-accessibility-helper : Unable to locate click event handler object, the click event index or the td elements to process. Table row processing will be skipped.");
        return;
    }
    /* 3) Gather information bassed on the "firstCell"
        * - Gather an alias to make operations on.
        * - Current row id is used to uniquely flag and link parent rows with collapsed child rows. 
        *   Note that this assumes a unique id which is provided by giveRowsUniqueId() called during the 'draw.dt' table event ; */
    var rowId = firstTdChild.parent().attr("id");

    //Debug console.log("dataTable-accessibility-helper setFirstCellAriaAttrubutes DEBUG: Prosessing row with id ='" + rowId + "'.");

    /* 4) Get the reference to any collapsible row.
        * In DataTables this should be the next row with the class "child" following the current row with class "parent". */
    var collapsibleRow = firstTdChild.parent().next("tr.child");

    //Try and provide a unique identifier for collapsible row that will be controlled by (+) and (-).
    if (dtHelperUtilityValidateJqueryObj(collapsibleRow)) {
        collapsibleRow.attr("id", "rowCollapse_" + rowId);
    }

    /* 5) Determine if the first cell is a collapsible row by looking for the classes "parent" or "child" which are assigned by datatables. 
     Exit the function if this is a child/collapsible row.*/
    var pseudoSelectorValue;
    if (firstTdChild.parent().hasClass("child") === true) {
        //Debug console.log("dataTable-accessibility-helper remapResponsiveControlsToButtons DEBUG: This is the child row skipping button processing.");
        return;
    } else {
        pseudoSelectorValue = firstTdChild.parent().hasClass("parent") === true ? '"-"' : '"+"';
    }
    //Debug console.log("dataTable-accessibility-helper remapResponsiveControlsToButtons DEBUG: pseudoSelectorValue value is '" + pseudoSelectorValue + "'.");

    /* 6) Attempt to locate the <span> element we used to add context to the (+) and (-) icons/buttons. */
    var firstCellButton = firstTdChild.children("button.accessibilityJQueryClassSelector");

    /*7) Create or update a <button> element to add context to the (+) and (-) icons/buttons. Inside we will add a span is visilbe only to screen raders. 
     * The classes used are defined in jquery.dataTables-boe-overide.css is now Version 0.0.0.3.6 or later.*/
    if (dtHelperUtilityValidateJqueryObj(firstCellButton)) {
        //If we have a button clear it.
        firstCellButton.empty();
    } else {
        //If we don't have button create an empty one.
        firstTdChild.append("<button type='button' class='accessibilityJQueryClassSelector'>");
        firstCellButton = firstTdChild.children("button.accessibilityJQueryClassSelector");
    }

    /* 8) Update the text inside the screen reader only <span>. */
    var spanId = "span_" + rowId;
    switch (pseudoSelectorValue) {
        case '"+"':
            firstCellButton.attr("aria-expanded", false).removeAttr("aria-controls").html("+");
            firstCellButton.append("<span id='" + spanId + "' class='accessibilityHiddenToScreenReader'>Plus:Show Details Row</span></button>");//Added for screen reader
            //Debug console.log("dataTable-accessibility-helper remapResponsiveControlsToButtons DEBUG: Updating the (+) sign.");
            break;
        case '"-"':
            firstCellButton.attr("aria-expanded", true).attr("aria-controls", "rowCollapse_" + rowId).html("-");
            firstCellButton.append("<span id='" + spanId + "' class='accessibilityHiddenToScreenReader'>Minus:Hide Details Row</span></button>");//Added for screen reader
            //Debug console.log("dataTable-accessibility-helper remapResponsiveControlsToButtons DEBUG: Updating the (-) sign.");
            break;
        default:
            break;
    }

    //9) Once we have successfully made buttons we can remove tabindex from first cell. Buttons will get tab focus automatically.
    firstTdChild.removeAttr("tabindex");

    //10) Add classes to remove pseudo selector controls defined in jquery.dataTables-boe-overide.css is now Version 0.0.0.3.6 or later.
    if (firstTdChild.hasClass("accessibilityTdOveride") === false) {
        firstTdChild.addClass("accessibilityTdOveride");
    }

    /* 12) Adjust click event handlers. To focus on the new button. */
    try {
        var buttonSelector = "td:first-child button.accessibilityJQueryClassSelector,";
        //This is the problem of not knowing who has the click event.
        if (jQuery._data(clickEventElement[0], "events").click[clickEventIndex].selector.includes(buttonSelector) === false) {
            //Debug console.log("dataTable-accessibility-helper remapResponsiveControlsToButtons DEBUG: Updating selector '" + jQuery._data(clickEventElement[0], "events").click[clickEventIndex].selector) + "'.";
            jQuery._data(clickEventElement[0], "events").click[clickEventIndex].selector = jQuery._data(clickEventElement[0], "events").click[clickEventIndex].selector.replace("td:first-child,", buttonSelector);
            //Debug console.log("dataTable-accessibility-helper remapResponsiveControlsToButtons DEBUG: Selector already did not contain '"+ buttonSelector +"'.");
        }
    } catch (e) {
        console.log(e);
    }
}

/**
 *  Removes or restores the tabIndex from the first visible column depending on the collapse status.
 *  Allows us to make the  expand row (+) and (-) controls accessible:
 * - Sets aria label attributes on controller cell and the collapsible row.
 * - Inserts and updates elements for screen readers.
 *  This function should be called from:
 *    - the <tableInstance>.on('draw', function () {});
 *    - the <tableInstance>.on('responsive-resize.dt', function () {});
 *    - the <tableInstance>.on('responsive-display.dt', function () {});
 *  WCAG accessibility. Avoid placing inactive elements in the focus order. 
 *  Assistive technology user will get the impression element is interactive and resulting in extra keystrokes to navigate.
 *  @param {DataTables.Api DataTable} dataTableInstance - These can be provided via $m('#' + gridName).DataTable() which returns a DataTables API instance and should not to be confused with $m('#' + gridName).dataTable() which returns a jQuery Object.
 *  @param {string} debugSource - An optional string which you can use to determine where it came from.
 */
function setFirstCellAriaAttrubutes(dataTableInstance, debugSource) {
    //Debug console.log("dataTable-accessibility-helper setFirstCellAriaAttrubutes DEBUG: Called from '" + debugSource + "'.");
    if (!dataTableInstance) {
        console.warn("dataTable-accessibility-helper setFirstCellAriaAttrubutes: Please provide valid dataTable instance.");
        return;
    }
    try {
        //Try to get the table
        var id = getDataTableInstanceID(dataTableInstance);
        if (!id) { return; }

        //Checks the version of datatables used. Required is Responsive 2.2.3 (dataTables.responsive.js) or higher.
        var versionCheck = typeof $m("#" + id).dataTable().api().responsive.hasHidden === "function";
        if (!versionCheck) {
            console.error("dataTable-accessibility-helper setFirstCellAriaAttrubutes: Unable to find hasHidden function necessary to adjust tab index. Required -> Responsive 2.2.3 (dataTables.responsive.js) or higher.");
            return;
        }

        /* 1) Assemble a collection of the first td child of every row in the table. */
        var tableRowFirstTdChildren = $m("#" + id + " tr td:first-child");

        /* 2) Skip processing if the table has a row but it is displaying the empty message. */
        if (!tableRowFirstTdChildren || $m(tableRowFirstTdChildren).hasClass("dataTables_empty")) {
            //Debug console.log("dataTable-accessibility-helper setFirstCellAriaAttrubutes: DEBUG The table is empty.");
            return;
        }

        /* 3) If the table doesn't have hidden fields or the 'collapsed' class we remove all the tab indexes and arial labels. */
        //Debug console.log("Has hidden is '" + $m("#" + id).dataTable().api().responsive.hasHidden() + "' and hasClass('collapsed') is '" + $m("#" + id).hasClass("collapsed") + "'.");
        if ($m("#" + id).dataTable().api().responsive.hasHidden() === false || $m("#" + id).hasClass("collapsed") === false) {

            if (!dtHelperUtilityValidateJqueryObj(tableRowFirstTdChildren)) {
                console.warn("dataTable-accessibility-helper setFirstCellAriaAttrubutes : Unable to REMOVE cell attributes for accessibilitty. Invalid row objects found on table id '" + id + "'.");
                return;
            }
            //Debug console.log("dataTable-accessibility-helper setFirstCellAriaAttrubutes: DEBUG Removing tab index from target the children's decendants.");
            /* Cell clean up. */
            tableRowFirstTdChildren.removeAttr("tabindex");
            tableRowFirstTdChildren.children("button.accessibilityJQueryClassSelector").remove();

        } else {
            /* 4) Check to see if the "tableRowFirstTdChildren" it's a valid jquery object we can operate on. */
            if (!dtHelperUtilityValidateJqueryObj(tableRowFirstTdChildren)) {
                //Debug console.warn("dataTable-accessibility-helper setFirstCellAriaAttrubutes : Unable to ADD cell attributes for accessiblitty. Invalid row objects found on table id '" + id + "'.");
                return;
            }
            /* 5) We will attempt to replace default cell responsive control with buttons. */
            tryReplaceFirstCellResponsiveControlWithButtons(tableRowFirstTdChildren);
        }
    } catch (error) {
        console.error("dataTable-accessibility-helper setFirstCellAriaAttrubutes: Unable to process the provided dataTableInstance.");
        throw (error);//Rethrow the error so we can see what the actual issue was.
    }
}

/**
 *  Iterates through rows and assign a unique id we can use programatically.
 *  @param {DataTables.Api DataTable} dataTableInstance - These can be provided via $m('#' + gridName).DataTable() which returns a DataTables API instance and should not to be confused with $m('#' + gridName).dataTable() which returns a jQuery Object.
 */
function giveRowsUniqueId(dataTableInstance) {
    //Try to get the table
    var id = getDataTableInstanceID(dataTableInstance);
    if (dataTableInstance && id) {
        $m("#" + id + " > tbody > tr").each(function () {
            //Use the jquery ui uniqueId() method to quickly create unique ids to rows IF those rows don't already have an id.
            $m(this).uniqueId();
        });
    } else {
        console.warn("dataTable-accessibility-helper: Unable to make add uique ids to rows.");
    }
}

/**
 *  Makes datatables sort controls accessible by implementing invisible/hidden elements.
 *  This function should be called from the 'responsive-display.dt', function (e, datatable, row, showHide, update) event trigger.
 *  @param {object} jqueryTh - jQuery object.
 *  @param {string} uniqueCellId - Unique identifier for the cell following the format <table id>_ordering_span_<ordering>_<index>
 *  @param {object} jqueryTableParent - jQuery object of the parent to the entire table.
 *  @param {string} sorting - Used to determine the aria label used.
 */
function setHeaderAccessible(jqueryTh, uniqueCellId, jqueryTableParent, sorting) {
    if (!dtHelperUtilityValidateJqueryObj(jqueryTh)) {
        console.error("dataTable-accessibility-helper: Unable to process the specified header with available jquery table header object.");
        return;
    }
    if ((typeof uniqueCellId !== 'string' && !(uniqueCellId instanceof String)) || uniqueCellId === "") {
        console.error("dataTable-accessibility-helper: Unable to create accessible header without unique cell id.");
        return;
    }
    if (!dtHelperUtilityValidateJqueryObj(jqueryTableParent)) {
        console.error("dataTable-accessibility-helper: Unable to process the table parent with available jquery table parent object.");
    } else {
        var spMsg = "";
        switch (sorting) {
            case "both":
                spMsg = "Unsorted";
                break;
            case "asc":
            case "desc":
            default:
                break;
        }
        //Create a span to update the datatable.
        if (spMsg != "") {
            let $span = $m('<span>', {
                style: 'display: none;',
                class: 'accessibilityHelperSpan',
                text: spMsg,
                id: uniqueCellId
            });
            jqueryTh.append($span);
        }
        //Add classes to remove pseudo selector controls defined in jquery.dataTables-boe-overide.css is now Version 0.0.0.3.6 or later.
        if (jqueryTh.hasClass("accessibilityThOveride") === false) {
            jqueryTh.addClass("accessibilityThOveride");
        }
    }
}

/**
 *  Makes the table sorting accessible by creating invisible spans that describe the sort cell.
 *  This function should be called from the 'draw.dt' function (e, settings) event trigger.
 *  @param {DataTables.Api DataTable} dataTableInstance - These can be provided via $m('#' + gridName).DataTable() which returns a DataTables API instance and should not to be confused with $m('#' + gridName).dataTable() which returns a jQuery Object.
 *  [Compliant Code Example]
 *  <span id="sortascending" style="display:none;>Activate to sort column ascending">
 *  <th class="sorting" tabindex="0" aria-controls="gridFilingTransactions" rowspan="1" colspan="1" aria-label="Action" aria-describedby="sortascending" style="width: 38px;">
 *      Action
 *  </th>
 */
function makeSortingAccessible(dataTableInstance) {
    try {
        if (dataTableInstance) {
            //Locate all the elements to update.
            var header = dataTableInstance.tables().header().to$();//Header.
            var asc = header.find("th.sorting_asc");//Ascending elements.
            var desc = header.find("th.sorting_desc");//Descending elements.
            var sorting = header.find("th.sorting");//Sorting (not defined) elements.
            var tableId = getDataTableInstanceID(dataTableInstance);//Datatable instance.
            var tableParent = $m("#" + tableId).parent();//Table's parent element.
            //Remove any accessible spans.
            var uniqueId_seed = tableId + "_ordering_span";
            tableParent.find('[id^=' + uniqueId_seed + ']').remove();
            //Debug console.log("dataTable-accessibility-helper header length is '"+asc.length+"'.");
            for (var i = 0; i < asc.length && asc.length > 0; i++) {
                var uniqueCellIdAsc = uniqueId_seed + "_asc_" + i;
                setHeaderAccessible($m(asc[i]), uniqueCellIdAsc, tableParent, 'asc');
            }
            //Debug console.log("dataTable-accessibility-helper desc length is '"+desc.length + "'.");
            for (var j = 0; j < desc.length && desc.length > 0; j++) {
                var uniqueCellIdDesc = uniqueId_seed + "_desc_" + j;
                setHeaderAccessible($m(desc[j]), uniqueCellIdDesc, tableParent, 'desc');
            }
            //Debug console.log("dataTable-accessibility-helper sorting length is '"+sorting.length+"'.");
            for (var k = 0; k < sorting.length && sorting.length > 0; k++) {
                var uniqueCellIdBoth = uniqueId_seed + "_both_" + k;
                setHeaderAccessible($m(sorting[k]), uniqueCellIdBoth, tableParent, 'both');
            }
        } else {
            console.warn("dataTable-accessibility-helper: Please provide valid dataTable instance.");
        }
    } catch (error) {
        console.error("dataTable-accessibility-helper: Unable to process the provided dataTableInstance.");
        throw (error);//Rethrow the error so we can see what the actual issue was.
    }
}

/**
 * Accessibility requests by LevelAccess was that we give focus to the first row when we paginate.
 * The challenge is that the page.dt event fires before draw so the focus target changes.
 * This is a partial accessibility request where paginator buttons will set a data attribute.
 * That data attribute is read on draw and attempt to focus on the row expand button (+).
 * Rather than use a delay we will add an attribute (data-a11y-focus-first-row-on-draw) to the table and remove it later.
 * IMPORTANT: This is the function that adds the attribute.
 * WORKS IN COLLABORATIN WITH: reviewFocusTargetAtrributeForDrawEvent
 * @param {string} dataTableId - The id of the table that we will add the attribute to.
 */
function addFocusTargetAtrributeForDrawEvent(dataTableId) {
    if (isNonEmptyString(dataTableId)) {
        var table = $m("table#" + dataTableId);
        if (table && table.length == 1) {
            //Add the element that we use to track if we need to focus an element after re-draw.
            table.attr("data-a11y-focus-first-row-on-draw", "true");
        } else {
            console.warn("dataTable-accessibility-helper addFocusTargetAtrributeForDrawEvent: Unable to locate table singleton.");
        }
    } else {
        console.warn("dataTable-accessibility-helper addFocusTargetAtrributeForDrawEvent: Invalid dataTableId ='" + dataTableId + "'.");
    }
}

/**
 * Accessibility requests by LevelAccess was that we give focus to the first row when we paginate.
 * The challenge is that the page.dt event fires before draw so the focus target changes.
 * This is a partial accessibility request where paginator buttons will set a data attribute.
 * That data attribute is read on draw and attempt to focus on:
 *  - the first button present on the first row
 *  - or the first anchor present on the first row
 *  - or the last th of the header
 * Rather than use a delay we will add an attribute to the table and remove it later.
 * IMPORTANT: This is the function that sets the focus and remove the attribute.
 * WORKS IN COLLABORATIN WITH: addFocusTargetAtrributeForDrawEvent
 * @param {string} dataTableId - The id of the table that we will remove the attribute from.
 */
function reviewFocusTargetAtrributeForDrawEvent(dataTableId) {
    //Exit function
    if (!isNonEmptyString(dataTableId)) {
        console.warn("dataTable-accessibility-helper reviewFocusTargetAtrributeForDrawEvent: Invalid dataTableId ='" + dataTableId + "'.");
        return false;
    }
    //Exit function
    var table = $m("table#" + dataTableId);
    if (!table && table.length != 1) {
        console.warn("dataTable-accessibility-helper reviewFocusTargetAtrributeForDrawEvent: Unable to locate table singleton.");
        return false;
    }

    //Look for the focuss attribute 'data-a11y-focus-first-row-on-draw'.
    var focusAttribute = table.attr("data-a11y-focus-first-row-on-draw");
    //If it doesn't exists we do not need to look for an item to focus on.
    if (focusAttribute != "true") {
        //DEBUG console.warn("dataTable-accessibility-helper reviewFocusTargetAtrributeForDrawEvent: Invalid focusAttribute ='" + focusAttribute + "'.");
        return false;
    }

    //Before we try to focus on something lets remove the attribute we were looking for. This prevents infinite focus loops.
    table.removeAttr("data-a11y-focus-first-row-on-draw");
    //Select the expand button you find in the first td of the first row.
    var expandButton = $m("table#" + dataTableId).find('tbody tr:first td:first button');
    if (expandButton && expandButton.length == 1) {
        expandButton.focus();
        return true;
    }
    //Try select any button you find in the first row.
    var anyRowButton = $m("table#" + dataTableId).find('tbody tr:first td button');
    if (anyRowButton && anyRowButton.length == 1) {
        anyRowButton.focus();
        return true;
    }
    //Try select the first anchor you find in the first td of the first row.
    var firstAnchor = $m("table#" + dataTableId).find('tbody tr:first td a:first');
    if (firstAnchor && firstAnchor.length == 1) {
        firstAnchor.focus();
        return true;
    }
    //Select the last header cell.
    var lastTh = $m("table#" + dataTableId).find('thead tr:first th:last');
    if (lastTh && lastTh.length == 1) {
        lastTh.focus();
        return true;
    }
}

/**
 *  One stop shop to make a dataTable screen reader accessible.
 *  This function should be called from the initComplete: function (settings, json) event trigger.
 *  @param {DataTables.Api DataTable} dataTableInstance - These can be provided via $m('#' + gridName).DataTable() which returns a DataTables API instance and should not to be confused with $m('#' + gridName).dataTable() which returns a jQuery Object.
 */
function makeDataTableAccessible(dataTableInstance) {
    try {
        //Try to get the table
        var id = getDataTableInstanceID(dataTableInstance);
        if (id) {
            //Accessibility: Adds the search submit and clear buttons and makes paginator screen reader accessible.
            applyInitCompleteGlobalAccessibilityHelpers($m('#' + id).DataTable());
            dataTableInstance.on('draw.dt', function (e, settings) {
                //Debug console.log("dataTable-accessibility-helper makeDataTableAccessible: Hiding processing div.");
                showHideProcessingDiv(id, "hide");
                //Debug console.log("dataTable-accessibility-helper makeDataTableAccessible: Giving rows unique ids.");
                giveRowsUniqueId(dataTableInstance);
                //Debug console.log("dataTable-accessibility-helper makeDataTableAccessible: Making table headers sort controls accessible.");
                makeSortingAccessible(dataTableInstance);
                //Debug console.log("dataTable-accessibility-helper makeDataTableAccessible: Removing the tabindex dataTable adds to 1st column automatically.");
                setFirstCellAriaAttrubutes(dataTableInstance, 'draw.dt');
                //Debug console.log("dataTable-accessibility-helper makeDataTableAccessible: Adding special code to fix asp.net issue where enter key is being captured by the controller.");
                captureSearchInputEnterKeyPress(dataTableInstance);
                //Debug console.log("dataTable-accessibility-helper makeDataTableAccessible: Attempting to focus first row expand/collapse button.");
                reviewFocusTargetAtrributeForDrawEvent(id);
            }).on('responsive-resize.dt', function (e, datatable, columns) {
                //Debug console.log("dataTable-accessibility-helper: " + columns.reduce(function (a, b) { return b === false ? a + 1 : a; }, 0) + " column(s) are hidden.");
                setFirstCellAriaAttrubutes(dataTableInstance, 'responsive-resize.dt');
            }).on('responsive-display.dt', function (e, datatable, row, showHide, update) {
                //Debug console.log("dataTable-accessibility-helper: Removing the tabindex dataTable adds to 1st column automatically.");
                setFirstCellAriaAttrubutes(dataTableInstance, 'responsive-display.dt');
            }).on('order.dt', function (e, datatable, row, showHide, update) {
                //Debug console.log("dataTable-accessibility-helper makeDataTableAccessible: order.dt event triggers both on search and order. Showing processing div.");
                showHideProcessingDiv(id, "show");
            }).on('page.dt', function (e, settings) {
                //Debug console.log("dataTable-accessibility-helper makeDataTableAccessible: page.dt event triggers both on paging changes.");
                //NOTE: This is not an accessibility feature.
                //It was a feature requested in defect 3866 and may in fact cause an accessibility issue.
                $m("#" + id + " > thead")[0].scrollIntoView();
                //This is a partial accessibility request where paginator buttons will set a data attribute.
                //That data attribute is read on draw and attempt to focus on the expand button.
                addFocusTargetAtrributeForDrawEvent(id);
            });
        } else {
            console.warn("dataTable-accessibility-helper makeDataTableAccessible: Unable to make dataTable Accessible.");
        }
    } catch (error) {
        console.error("dataTable-accessibility-helper makeDataTableAccessible: Unable to process the provided dataTableInstance.");
        throw (error);//Rethrow the error so we can see what the actual issue was.
    }
}

/**
 * Generates unique identifier with the info available from fnRowCallback options attributes
 * https://legacy.datatables.net/release-datatables/examples/advanced_init/row_callback.html
 *  @param {integer} iDisplayIndex - Row number in the current search set of data (i.e. over all available pages). 
 *  @param {node} nRow - TR element being inserted into the document.  
 * */
function generateUniqueRowIdForFnRowCallback(iDisplayIndex, nRow) {
    var uniqueRowId = new Date().valueOf();
    try {
        uniqueRowId = iDisplayIndex + "_" + nRow.rowIndex.toString() + "_" + uniqueRowId;
        uniqueRowId = uniqueRowId.replace("'", "").replace('"', ""); //remove ' and "
        return uniqueRowId;

    } catch (e) {
        console.error("dataTable-accessibility-helper: Unable to generate unique row id. Generating using time stamp only");
        return uniqueRowId
    }
}

/**
 * The processing message is not always displayed during long operations. 
 * This function allows us to show or hide the "#<id>_processing" element.
 *  @param {string} id - The id of a datatable instance. 
 *  @param {string} showOrHide - Supported operations are 'show' or 'hide'. 
 **/
function showHideProcessingDiv(id, showOrHide) {
    try {
        //Debug console.log($m("#" + id + "_processing"));
        switch (showOrHide.toLowerCase()) {
            case "show":
                $m("#" + id + "_processing").show();
                $m("#" + id + " > tbody").css("opacity", "50%");
                break;
            case "hide":
                $m("#" + id + "_processing").hide();
                $m("#" + id + " > tbody").css("opacity", "initial");
                break;
            default:
                console.error("dataTable-accessibility-helper: showHideProcessingDiv Unsuported command '" + showOrHide + "'.");
                break;
        }
    } catch (e) {
        console.error("dataTable-accessibility-helper: showHideProcessingDiv Unable to show or hide processing div.");
        console.error(e);
    }
}

/**
 * Uses the date function to generate an unique row identifier.
 * Apply it during initialization by using the row id option.:
 * $m('#tableId').DataTable({
 *    "rowId": function () { return dtA11yHelper_GenerateUniqueRowId("tableId"); },
 * });
 *  @param {string} tableid - The id of the table element of a given datatable. 
 **/
function dtA11yHelper_GenerateUniqueRowId(tableid) {
    var prefix = (typeof tableid === 'string' || tableid instanceof String) && tableid.trim() != "" ? tableid.trim() : "idNotProvided";
    return (prefix + "_row" + new Date().valueOf()).replace("'", "").replace('"', "");
}

//**This code canbe used to test datatables
/*
 *  //HTML
<div>
    <h2 id="testdate"></h2>
    <table id="example" class="display nowrap cell-border table-bordered" style="width:100%">
        <thead>
            <tr>
                <th>0 Hidden</th>
                <th>1 Text</th>
                <th>2 Text</th>
                <th>3 Text</th>
                <th>4 Date/Time</th>
                <th>5 Date</th>
                <th>6 Date</th>
                <th>7 Letters</th>
                <th>8 Letters</th>
                <th>9 Letters</th>
                <th>10 Numbers</th>
                <th>11 Date</th>
                <th>12 Money</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>Hidden 1</td>
                <td>Tiger Nixon</td>
                <td>System Architect</td>
                <td>Edinburgh</td>
                <td>01/01/2011 11:01:01 AM</td>
                <td>2011/04/25</td>
                <td>Jan 1, 2011</td>
                <td>AAA AAA</td>
                <td>Foo Foo</td>
                <td>Abcdefg</td>
                <td>100</td>
                <td>June 2020</td>
                <td>$1,000,000</td>
            </tr>
            <tr>
                <td>Hidden 2</td>
                <td>Garrett Winters</td>
                <td>Accountant</td>
                <td>Tokyo</td>
                <td>01/01/2011 11:01:01 PM</td>
                <td>2011/07/25</td>
                <td>Jan 1, 2011</td>
                <td>BBB BBB</td>
                <td>Bar Bar</td>
                <td>Hijklm</td>
                <td>50</td>
                <td>July 2020</td>
                <td>$0</td>
            </tr>
            <tr>
                <td>Hidden 3</td>
                <td>Ziggy Marley</td>
                <td>Programmer</td>
                <td>Zambia</td>
                <td>01/02/2011 11:01:01 AM</td>
                <td>2011/07/28</td>
                <td>Jan 2, 2011</td>
                <td>CC CC</td>
                <td>Wu Wu</td>
                <td>Opqrstuv</td>
                <td>0</td>
                <td>August 2020</td>
                <td>-$10</td>
            </tr>
            <tr>
                <td>Hidden 4</td>
                <td>Bob Sagget</td>
                <td>Commedian</td>
                <td>Zambia</td>
                <td>01/01/2012 11:01:01 AM</td>
                <td>2011/07/28</td>
                <td>Jan 1, 2012</td>
                <td>CC CC</td>
                <td>Tang Tang</td>
                <td>Wxyz</td>
                <td>-10</td>
                <td>August 2021</td>
                <td>-$10.5</td>
            </tr>
        </tbody>
    </table>
</div>
<script>
    $m = jQuery.noConflict();

    $m(document).ready(function () {
        console.log("Testing Example Table");

        //You can use this code to figure out what format your date is.
        var testDate = new Date();
        $m("#testdate").html(moment(testDate).format('MMM D, YYYY'));

        //Inside the document ready function you tell data table to match whatever format you want to use.
        //Requires:
        // * Scripts/DataTables-1.10.20/plugins/datetime-moment.js
        // * Scripts/DataTables-1.10.20/plugins/moment-2.29.1.min.js
        //Format for 01/02/2011 11:01:01 AM
        $m.fn.dataTable.moment('MM/DD/YYYY h:mm:ss A');
        //Format for Jan 2, 2011
        $m.fn.dataTable.moment('MMM D, YYYY');
        //Format for August 2021
        $m.fn.dataTable.moment('MMMM YYYY');

        //This is your standard table code
        var exampleTableReference = $m('#example').DataTable({
            "responsive": true,
            "columnDefs": [
                {
                    "targets": [0],
                    "visible": false,
                    "searchable": false
                }
            ],
            "initComplete": function (settings, json) {
                //Accessibility: Applies various Accessibility features to this dataTable.
                makeDataTableAccessible($m('#example').DataTable());
            },
        });
        exampleTableReference.draw();
        exampleTableReference.columns.adjust().responsive.recalc();
    });
</script>
 */