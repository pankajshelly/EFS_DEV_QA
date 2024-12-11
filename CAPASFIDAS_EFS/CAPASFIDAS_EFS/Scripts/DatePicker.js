/**Provides a function to quickly initialize a jquery-ui datepicker.
 * DatePicker.js
 * Version key major.minor.patch
 * Version 1.0.2 - Last formal update 07/19/2022
 */
var $m = jQuery.noConflict();
/**
 * Creates a datepicker for any element with the class .datepicker.
 * You can set the max date when the function is invoked.
 * @param {string} maxDate
 * @param {string} imagePath - Path to Calendar.png resource.
 */
function LoadDatePicker(maxDate, imagePath) {
    //If the default image path doesn't work the user can specify their own.
    var path = "../../Content/Images/Calendar.png";
    if (imagePath && imagePath != null && (typeof imagePath === 'string' || imagePath instanceof String)) {
        path = imagePath;
    }
    $m(".datepicker").datepicker({
        showOn: "button",
        buttonImage: path,
        buttonImageOnly: false, //Accessibility: Ensures the calendar icon is reachable via keyboard.
        showButtonPanel: true, //Accessibility: Provides close button reachable via keyboard.
        closeText: 'Close',  //Accessibility: Provides close button text.
        buttonText: "Select From Date",
        changeMonth: true,
        changeYear: true,
        numberOfMonths: 1,
        dateFormat: 'mm/dd/yy',
        onChange: function () {
            try {
                $m(this).valid();//valid is a jquery validator function we can't assume it is implemented everytime jquery ui is implemented.
            } catch (e) {
                console.error("DatePicker:LoadDatePicker:onChange is not able to validate the date input field.");
            }
            //Note (by Jorge) Consider passing the element through attributes so function can validate any form or element. See AlertMessageBox.js Version 0.0.0.2.3 or higher for an example.
        },
        onClose: function () {
            this.focus() //Retunr focus back to input for accessibility.
        }
    });
    try {
        if (maxDate && maxDate != null && (typeof maxDate === 'string' || maxDate instanceof String)) {
            // Setter for max date
            $m(".datepicker").datepicker("option", "maxDate", maxDate);
        }
    } catch (e) {
        console.error("Error: DatePicker.js unable to set MaxDate");
        console.error(e);
    }

    $m('.datepicker').attr("placeholder", "MM/DD/YYYY").datepicker();

}