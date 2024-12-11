﻿
function PageTabAcordion2() {

    var headers = $('#divOption2ByTransType .accordion-header');
    var contentAreas = $('#divOption2ByTransType .ui-accordion-content').hide();
    var expandLink = $('.accordion-expand-all');

    // add the accordion functionality
    headers.click(function () {
        var panel = $(this).next();
        var isOpen = panel.is(':visible');

        // open or close as necessary
        panel[isOpen ? 'slideUp' : 'slideDown']()
            // trigger the correct custom event
            .trigger(isOpen ? 'hide' : 'show');

        // stop the link from causing a pagescroll
        return false;
    });

    // hook up the expand/collapse all
    expandLink.click(function () {
        var isAllOpen = $(this).data('isAllOpen');

        contentAreas[isAllOpen ? 'hide' : 'show']()
            .trigger(isAllOpen ? 'hide' : 'show');
    });

    // when panels open or close, check to see if they're all open
    contentAreas.on({
        // whenever we open a panel, check to see if they're all open
        // if all open, swap the button to collapser
        show: function () {
            var isAllOpen = !contentAreas.is(':hidden');
            if (isAllOpen) {
                expandLink.text('Collapse All')
                    .data('isAllOpen', true);
            }
        },
        // whenever we close a panel, check to see if they're all open
        // if not all open, swap the button to expander
        hide: function () {
            var isAllOpen = !contentAreas.is(':hidden');
            if (!isAllOpen) {
                expandLink.text('Expand all')
                .data('isAllOpen', false);
            }
        }
    });
}







