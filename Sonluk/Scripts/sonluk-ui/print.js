$(document).ready(function () {


    var type;

    if ($("input#type").length > 0 )
        type = $("input#type").val();
    else
        type = "";

    function printSetting() {
        factory.printing.header = ""   //页眉
        factory.printing.footer = ""   //页脚
        factory.printing.portrait = true;    //true为纵向打印，false为横向打印
        factory.printing.leftMargin = 3.98   //左页边距
        factory.printing.topMargin = 3.98    //上页边距
        factory.printing.rightMargin = 3.98  //右页边距
        factory.printing.bottomMargin = 4.02 //下页边距
    }

    var message = "";
    var obj = document.getElementById("message");
    if (obj) {
        message = $("#message").val();
    }

    if ($("input#quick-print").val()=="1")
    {
        if (message != "") {
            messageDialogDefault(message, "确认", function () {
                try {
                    printSetting();
                    factory.printing.Print(false);

                } catch (e) {

                    window.print();
                }
            });
        }
        else {
            try {
                printSetting();
                factory.printing.Print(false);

            } catch (e) {

                window.print();
            }
        }
       
        //window.close();
    }
    else
        if (message != "") {
            messageDialogDefault(message, "确认", function () { });
        }

    $("div#print").click(function () {

        try {
            printSetting();
            factory.printing.Print(false);

        } catch (e) {

            if (type != "consignment-note")
                messageDialogWarning("无法加载打印配置，请手动设置页边距及页眉页脚或使用IE。", function () { window.print(); });
            else
                
                window.print();
        }


    });

    $("div#print-preview").click(function () {

        try {
            printSetting();
            factory.printing.Preview();
           

        } catch (e) {
            if (type != "consignment-note")
                messageDialogWarning("无法加载打印配置，请手动设置页边距及页眉页脚或使用IE。", function () { window.print(); });
            else
                
                window.print();

        }

    });

    $("div#back").click(function () {
        window.close();
    });
});