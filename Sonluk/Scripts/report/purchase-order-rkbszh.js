
$(document).ready(function () {

    //生成
    $(document).on("click", ".panel-search-submit", function () {

        var data = [];

        var nums = 0;
        var errs = 0;
        var index = 0;
        var i = 0;

        var GLTS = $("#RKBSZH_TS").val();
        var FS = 1;

        if (GLTS == "") GLTS = 0;
        if ((GLTS % 1 != 0) || GLTS <= 0) {
            messageDialogWarning("托数输入不正确！", function () { });
            panel.spin(false);
            return;
        }

        data.push({ name: "GLTS", value: GLTS });
        data.push({ name: "FS", value: FS });

        $("table.data-table-list").find("tr.data").each(function () {
            index = 0;
            var node = $(this);
           
            data.push({ name: "itemNodes[" + i + "].Ebeln", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Ebelp", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Eindt", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Matnr", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Txz01", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Zsl", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Wssl", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Meins", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Vbeln", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Vbelp", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Yglts", value: node.find("td:eq(" + (index++) + ")").text() });

            var Zj = '';
            //alert('01:'+node.find("td:eq(" + (index) + ")").children().attr('checked'));
            if (node.find("td:eq(" + (index) + ")").children().attr('checked') == 'checked')
            {
                
                Zj = 'X';
                nums++;
            }                
            //alert('zj:'+Zj)
            data.push({ name: "itemNodes[" + i + "].Zj", value: Zj });
            index++;
            var Sl = node.find("td:eq(" + (index) + ")").children().val();
            if (Sl == "") Sl = 0;
            if ((Sl % 1 != 0) || Sl <= 0) {
                errs++;
            }
            data.push({ name: "itemNodes[" + i + "].Sl", value: node.find("td:eq(" + (index) + ")").children().val() });
            index++;
            i++;
        });       
        //alert('nums' + nums);
        if (nums == 0)
        {
            messageDialogWarning("请选择主键！", function () { });
            panel.spin(false);
            return;
        }

        if (nums != 1) {
            messageDialogWarning("只能选择1个主键！", function () { });
            panel.spin(false);
            return;
        }

        if (errs > 0) {
            messageDialogWarning("本托数量输入不正确！", function () { });
            panel.spin(false);
            return;
        }

        var uri = $(this).next();
        
        $.ajax({
            type: "post",
            url: uri.val(),
            data: data,
            async: false,
            success: function (message) {
                if (message == "") {
                    //window.open(uri.next().val());
                    $("div.panel-search-refresh").click();
                }
                else {
                    messageDialogWarning(message, function () { });
                    panel.spin(false);
                }
            }
        });

    });

    //查询入库标识
    var panel = $("div#rkbszh-list");
    $("div.panel-search-refresh").click(function () {

        selfAdaptionDisplayHide();
        exportType = "List";
        panel.children().remove();
        panel.css("height", $(window).height() - top - 50);
        panel.spin({ color: '#2980B9', });

        var data = [];
        var nums = 0;
        var errs = 0;
        var index = 0;
        var i = 0;
        //alert('查询入库标识1');
        $("table.data-table-list").find("tr.data").each(function () {
            index = 0;
            var node = $(this);

            data.push({ name: "itemNodes[" + i + "].Ebeln", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Ebelp", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Eindt", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Matnr", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Txz01", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Zsl", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Wssl", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Meins", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Vbeln", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Vbelp", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Yglts", value: node.find("td:eq(" + (index++) + ")").text() });
            //data.push({ name: "itemNodes[" + i + "].Zj", value: node.find("td:eq(" + (index++) + ")").children().val() });
            //data.push({ name: "itemNodes[" + i + "].Sl", value: node.find("td:eq(" + (index++) + ")").children().val() });
            var Zj = '';
            //alert('01:'+node.find("td:eq(" + (index) + ")").children().attr('checked'));
            if (node.find("td:eq(" + (index) + ")").children().attr('checked') == 'checked') {

                Zj = 'X';
                nums++;
            }
            //alert('zj:'+Zj)
            data.push({ name: "itemNodes[" + i + "].Zj", value: Zj });
            index++;
            var Sl = node.find("td:eq(" + (index) + ")").children().val();
            if (Sl == "") Sl = 0;
            if ((Sl % 1 != 0) || Sl <= 0) {
                errs++;
            }
            data.push({ name: "itemNodes[" + i + "].Sl", value: node.find("td:eq(" + (index) + ")").children().val() });
            index++;

            i++;
        });
        //alert('查询入库标识2');
        var node = $(this);
        var startDate = new Date();
        panel.load(node.next().val(),
                data,
                function (data, status) {
                    //alert(status);
                    if (status == "success") {
                        
                        $("table.data-table").table(2);
                        $(".sonluk-table-control").show();

                        responseInfo(startDate);
                    }
                    else {
                        panel.text(data);
                    }
                }
        );
    });

    //打印
    $(document).on("click", ".rkbs-reprint", function () {

        var uri = $(this).next();
        var data = [];
        var index = 0;
        var i = 0;
        var zhms = new Array()

        //取组合码
        $("table.data-table").find("tr.row-selected").each(function () {
            index = 3;
            var node = $(this);
            zhms[i] = node.find("td:eq(" + (index) + ")").text();
            //alert(node.find("td:eq(" + (index) + ")").text() + ' xsw ' + zhms[i]);
            i++;
        });
        
        if (zhms.length == 0)
        {
            messageDialogWarning("请选择要打印的记录！", function () { });
            panel.spin(false);
            return;
        }
        i = 0;
        $("table.data-table").find("tr.data").each(function () {
            
            var node = $(this);
            index = 3;
            if (zhms.indexOf(node.find("td:eq(" + (index++) + ")").text()) != -1)
            {
                //alert(node.find("td:eq(" + (index++) + ")").text());
                index = 0;       

                data.push({ name: "itemNodes[" + i + "].Matnr", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "itemNodes[" + i + "].Txz01", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "itemNodes[" + i + "].Zj", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "itemNodes[" + i + "].Zhm", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "itemNodes[" + i + "].Tpm", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "itemNodes[" + i + "].Scsl", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "itemNodes[" + i + "].Sl", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "itemNodes[" + i + "].Zbtxs", value: node.find("td:eq(" + (index++) + ")").children().val() });
                data.push({ name: "itemNodes[" + i + "].Zxs", value: node.find("td:eq(" + (index++) + ")").children().val() });
                data.push({ name: "itemNodes[" + i + "].Zts", value: node.find("td:eq(" + (index++) + ")").text() });   
                data.push({ name: "itemNodes[" + i + "].Ebeln", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "itemNodes[" + i + "].Ebelp", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "itemNodes[" + i + "].Eindt", value: node.find("td:eq(" + (index++) + ")").text() });                
                data.push({ name: "itemNodes[" + i + "].Zsl", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "itemNodes[" + i + "].Wssl", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "itemNodes[" + i + "].Meins", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "itemNodes[" + i + "].Vbeln", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "itemNodes[" + i + "].Vbelp", value: node.find("td:eq(" + (index++) + ")").text() });
             
                i++;
            }
        });
        //alert(data);
        $.ajax({
            type: "post",
            url: uri.val(),
            data: data,
            async: false,
            success: function (message) {
                //alert(message);
                if (message == "") {
                    window.open(uri.next().val());
                }
                else {
                    alert(message);
                }
            }
        });
    });

    //删除
    $(document).on("click", ".rkbs-delete", function () {

        var uri = $(this).next();
        var data = [];

        var RKBS_TPM = "";

        var index = 0;
        var sels = 0;
        $("table.data-table").find("tr.row-selected").each(function () {
            var node = $(this);
            index = 4;
            if (RKBS_TPM == "") {
                RKBS_TPM = node.find("td:eq(" + (index++) + ")").text();
            }
            else {
                RKBS_TPM = RKBS_TPM + '\r\n' + node.find("td:eq(" + (index++) + ")").text();
            }
            index++;
            sels++;
        });

        if (sels > 1) {
            messageDialogWarning("只能选择1条记录！", function () { });
            panel.spin(false);
            return;
        }

        data.push({ name: "IV_TPM", value: RKBS_TPM });

        messageDialogWarning("确认删除入库标识吗？", function () {

            $.ajax({
                type: "post",
                url: uri.val(),
                data: data,
                async: false,
                success: function (message) {
                    if (message == "") {
                        $("div.panel-search-refresh").click();
                        //messageDialogWarning('操作成功！', function () { });
                    }
                    else {
                        messageDialogWarning(message, function () { });
                    }
                }
            });

        })

    });
});