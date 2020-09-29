


//表格数据加载
function TableLoad(staffid) {
    $("#div_result").empty();
    var data;
    var table = layui.table;
    var form = layui.form;
    cxdata = {
        KHLX: parseInt($("#KHtype").val()),
        CRMID: $("#KH_ID").val(),
        MC: $("#KH_name").val(),
        SAPSN: $("#sap").val(),
        GID: 0,
        SF: 0,
        CS: 0,
        XSZZ: "",
        FID: 0,
        //ISACTIVE: 3,
        BEIZ: $("#mdbh").val()
    };
    var layerindex = layer.load();;
    $.ajax({
        type: "POST",
        async: true,
        url: "../KeHu/Data_Select",
        data: {
            data: JSON.stringify(cxdata)
        },
        success: function (resdata) {
            //alert(resdata);
            data = JSON.parse(resdata);
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;
                var khlx;
                switch (data[i].KHLX) {
                    case 1:
                        khlx = "经销商";
                        break;
                    case 2:
                        khlx = "电商";
                        break;
                    case 3:
                        khlx = "直营卖场";
                        break;
                    case 4:
                        khlx = "B2B";
                        break;
                    case 5:
                        khlx = "网点终端";
                        break;
                    case 6:
                        khlx = "批发";
                        break;
                    case 7:
                        khlx = "LKA";
                        break;
                    default:
                        break;
                }

                var isactive;
                switch (data[i].ISACTIVE) {
                    case 1:
                        isactive = "未提交";
                        break;
                    case 2:
                        isactive = "审核中";
                        break;
                    case 3:
                        isactive = "已审核";
                        break;
                    default:
                        isactive = "";
                        break;
                }

                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="100%"><tr><td>序号: ' + xuhao + '</td></tr>'
                    + '<tr><td colspan="2" height="30">客户名称: ' + data[i].MC + '</td></tr>'
                    + '<tr><td width="200">客户编号: ' + data[i].CRMID + '</td><td width="200">客户类型: ' + khlx + '</td></tr>'
                    + '<tr><td colspan="2">SAP编号: ' + data[i].SAPSN + '</td><td width="60"><button id="btn_baifang' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">登记</button></td></tr>'
                    + '<tr><td colspan="2">上级客户: ' + data[i].PKHIDDES + '</td></tr>'
                    + '<tr><td height="30">省份: ' + data[i].SFDES + '</td><td>城市: ' + data[i].CSDES + '</td></tr>'
                    + '<tr><td colspan="2">状态: ' + isactive + '</td></tr>'
                    + '</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                $("#btn_baifang" + xuhao).on("click", { count: i }, function (event) {

                    var count = event.data.count;
                    sessionStorage.setItem("SUMMARYID2", -3);
                    sessionStorage.setItem("BFkhid", data[count].KHID);
                    window.location.href = "../BaiFang/Insert_BaiFang";

                    //layer.open({
                    //    title: '提示',
                    //    type: 0,
                    //    content: '确认在 ' + data[count].MC + ' 登记?',
                    //    btn: ['确定', '取消'],
                    //    yes: function (index, layero) {

                    //        var bfdata = {
                    //            BFJHID: 0,                  //
                    //            BFRYID: staffid,
                    //            BFKH: data[count].KHID,
                    //            BFID: 0,
                    //            BFLX: 547,
                    //            CRMID: data[count].CRMID,
                    //            KHMC: data[count].MC,
                    //            KHLX: data[count].KHLX,
                    //            XSQD: "",                   //
                    //            //JHBFKSSJ: "",               //
                    //            //JHBFJSSJ: "",               //
                    //            BFDZ: $("#address").val(),
                    //            LXR: "",
                    //            LXRTEL: "",
                    //            LXRZW: 0,
                    //            BFMD: 0,
                    //            BFJG: 0,
                    //            XCBFSJ: "",
                    //            XCBFJH: "",
                    //            QTXX: "",
                    //            ISACTIVE: 1
                    //        };
                    //        var qddata = {
                    //            QDLX: 3,
                    //            //QDGSID
                    //            QDGSHXMID: 0,
                    //            SXB: 0,
                    //            //QDRQ
                    //            //QDSJ
                    //            GJ: 0,
                    //            //SF:
                    //            //CS:
                    //            QDWZ: $("#address").val(),
                    //            QDJD: $("#lon").val(),
                    //            QDWD: $("#lat").val(),
                    //            KQJL: "",
                    //            ISACTIVE: 1,
                    //            BEIZ: ""
                    //        };
                    //        $.ajax({
                    //            type: "POST",
                    //            async: false,
                    //            url: "../BaiFang/Data_Insert_QiandaoAndBFDJ",
                    //            data: {
                    //                bfdata: JSON.stringify(bfdata),
                    //                qddata: JSON.stringify(qddata),
                    //                sf: $("#province").val(),
                    //                cs: $("#city").val()
                    //            },
                    //            success: function (id) {
                    //                if (id > 0) {
                    //                    layer.msg("拜访签到成功！");


                    //                }
                    //                else if (id == -1) {
                    //                    layer.msg("已签到，但不在客户签到地址范围内");
                    //                }
                    //                else if (id == -2) {
                    //                    layer.open({
                    //                        title: '提示',
                    //                        type: 0,
                    //                        content: '该客户没有签到地址，是否将当前位置作为签到地址',
                    //                        btn: ['确定', '取消'],
                    //                        yes: function (index, layero) {

                    //                            sessionStorage.setItem("KHID", khid);
                    //                            window.location.href = "../KeHu/KaoQin_Upload";

                    //                            layer.close(index);
                    //                        }
                    //                    });
                    //                }
                    //                else {
                    //                    layer.msg("拜访签到失败！");
                    //                }


                    //            },
                    //            error: function () {
                    //                layer.msg("拜访登记失败！");
                    //            }
                    //        });
                    //        layer.close(index);
                    //    }
                    //});





                    //var jsondata = {
                    //    BFLX: 1,
                    //    KHID: data[count].KHID,
                    //    CRMID: data[count].CRMID,
                    //    MC: data[count].MC,
                    //    KHLX: data[count].KHLX
                    //};
                    //sessionStorage.setItem("BFkhid", JSON.stringify(jsondata));
                    //window.location.href = "../BaiFang/Insert_BaiFang";



                });



                $("#div_result").append('</div>');
            }

            layer.close(layerindex);
        },
        error: function () {
            alert("code1015,请联系管理员");
            layer.close(layerindex);
        }
    });

}






$(document).ready(function () {

    var cxdata;
    var staffID = $("#staffid").val();
    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;
    var data = {
        typeid: 1,
        fid: 0
    };
    //$.ajax({
    //    type: "POST",
    //    url: "../KeHu/Data_Load_Dropdown",
    //    data: data,
    //    success: function (list) {
    //        var data = JSON.parse(list);
    //        for (var i = 0; i < data.length; i++) {
    //            $("#province").append("<option value='" + data[i].DICID + "'>" + data[i].DICNAME + "</option>");
    //        }
    //        form.render();


    //    }
    //});


    //要把待办事项中用到的参数都清掉
    sessionStorage.setItem("BFID", "");
    sessionStorage.setItem("BFJHID", "");
    sessionStorage.setItem("BFkhid", "");
    sessionStorage.setItem("SUMMARYID2", "");


    var appid = $("#appid").val();
    var state = $("#state").val();
    GetData(appid, staffID, state);

    getDropDownData(32, 0, "KHtype");




    $("#btn_cx").click(function () {

        TableLoad(staffID);







        //$("#div_select_tiaojian").removeClass("layui-show");




        return false;
    });



    $("#btn_new").click(function () {

        sessionStorage.setItem("BFID", "");
        sessionStorage.setItem("BFJHID", "");
        sessionStorage.setItem("BFkhid", "");
        sessionStorage.setItem("SUMMARYID2", "");
        sessionStorage.setItem("SUMMARYID", "");
        window.location.href = "../BaiFang/Insert_BaiFang";
        //window.open("../BaiFang/Insert_BaiFang");
    });



    layui.use(['form', 'layer', 'element', 'table'], function () {





        //form.on('select(province)', function (data) {

        //    $("#city").empty();

        //    $.ajax({
        //        type: "POST",
        //        url: "../KeHu/Data_Load_Dropdown",
        //        data: {
        //            typeid: 2,
        //            fid: data.value
        //        },
        //        success: function (list) {
        //            var data = JSON.parse(list);
        //            for (var i = 0; i < data.length; i++) {
        //                $("#city").append("<option value='" + data[i].DICID + "'>" + data[i].DICNAME + "</option>");
        //            }
        //            form.render();


        //        }
        //    });


        //});




    });

});



