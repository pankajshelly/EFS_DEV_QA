$m = jQuery.noConflict();


function HelpDialogBox(title, content, btn1text, btn2text, functionText, parameterList) {
    var btn1css;
    var btn2css;

    if (btn1text == '') {
        btn1css = "hidecss";
    } else {
        btn1css = "showcss";
    }

    if (btn2text == '') {
        btn2css = "hidecss";
    } else {
        btn2css = "showcss";
    }
    $("#lblMessage").html(content);

    $m("#dialog").dialog({
        resizable: false,
        title: title,
        modal: true,
        width: '400px',
        height: 125,
        bgiframe: false,
        hide: { effect: 'scale', duration: 400 },
        buttons: [
            {
                text: btn1text,
                "class": btn1css,
                click: function () {

                    $m("#dialog").dialog('close');
                }
            },
            {
                text: btn2text,
                "class": btn2css,
                click: function () {
                    $m("#dialog").dialog('close');
                }
            }
        ],
        dialogClass: 'DialogHelpdialog'
    });
}
