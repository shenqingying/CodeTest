


function Table_Detail() {
    var table = layui.table;

    $.ajax({
        type: "POST",
        async: false,
        url: "../KaoQin/Data_Select_QingJia",
        data: {
            STAFFID: staffid,
        },
        success: function (reslist) {
            var data = JSON.parse(reslist);
            for (var i = 0; i < data.length; i++) {
                for (var j = 0; j < depArr.length; j++) {
                    if (depArr[j].DEPID == data[i]["DEPNAME"]) {
                        data[i]["DEPNAMEDES"] = depArr[j].DEPNAME;
                    }
                }
            }
            table.render({
                elem: '#result',
                height: 315,
                width: 830,
                page: true, //开启分页
                cols: [[ //表头
                { field: 'KH_sap', title: 'SAP客户编号', width: 130, sort: true },
                { field: 'KH_name', title: '客户名称', width: 90 },
                { field: 'ordertime', title: '销售订单日期', width: 120 },
                { field: 'order', title: '销售订单', width: 90 },
                { field: 'matnr', title: '物料', width: 60 },
                { field: 'matnr1', title: '物料描述', width: 90 },
                { field: 'count', title: '订单数量', width: 90 },
                { field: 'price', title: '订单单价', width: 90 },
                { field: 'total', title: '总价', width: 60 }
                ]],
                data: arr,
                id: 'result'
            });

        },
        error: function () {
            alert("code1005,请联系管理员");
        }
    });

}


function Table_Summary_KH() {
    var table = layui.table;

    $.ajax({
        type: "POST",
        async: false,
        url: "../KaoQin/Data_Select_QingJia",
        data: {
            STAFFID: staffid,
        },
        success: function (reslist) {
            var data = JSON.parse(reslist);
            for (var i = 0; i < data.length; i++) {
                for (var j = 0; j < depArr.length; j++) {
                    if (depArr[j].DEPID == data[i]["DEPNAME"]) {
                        data[i]["DEPNAMEDES"] = depArr[j].DEPNAME;
                    }
                }
            }
            table.render({
                elem: '#HZ_KH',
                height: 315,
                width: 375,
                page: true, //开启分页
                cols: [[ //表头
                { field: 'KH_sap', title: 'SAP客户编号', width: 130, sort: true },
                { field: 'KH_name', title: '客户名称', width: 90 },
                { field: 'count', title: '订单数量', width: 90 },
                { field: 'total', title: '总价', width: 60 }
                ]],
                data: arr,
                id: 'HZ_KH'
            });

        },
        error: function () {
            alert("code1005,请联系管理员");
        }
    });

}


function Table_Summary_BGS() {
    var table = layui.table;

    $.ajax({
        type: "POST",
        async: false,
        url: "../KaoQin/Data_Select_QingJia",
        data: {
            STAFFID: staffid,
        },
        success: function (reslist) {
            var data = JSON.parse(reslist);
            for (var i = 0; i < data.length; i++) {
                for (var j = 0; j < depArr.length; j++) {
                    if (depArr[j].DEPID == data[i]["DEPNAME"]) {
                        data[i]["DEPNAMEDES"] = depArr[j].DEPNAME;
                    }
                }
            }
            table.render({
                elem: '#HZ_xsbgs',
                height: 315,
                width: 430,
                page: true, //开启分页
                cols: [[ //表头
                { field: 'KH_sap', title: '销售办公室编号', width: 145, sort: true },
                { field: 'KH_name', title: '销售办公室名称', width: 130 },
                { field: 'count', title: '订单数量', width: 90 },
                { field: 'total', title: '总价', width: 60 }
                ]],
                data: arr,
                id: 'HZ_xsbgs'
            });

        },
        error: function () {
            alert("code1005,请联系管理员");
        }
    });

}


function Table_Summary_XSZ() {
    var table = layui.table;

    $.ajax({
        type: "POST",
        async: false,
        url: "../KaoQin/Data_Select_QingJia",
        data: {
            STAFFID: staffid,
        },
        success: function (reslist) {
            var data = JSON.parse(reslist);
            for (var i = 0; i < data.length; i++) {
                for (var j = 0; j < depArr.length; j++) {
                    if (depArr[j].DEPID == data[i]["DEPNAME"]) {
                        data[i]["DEPNAMEDES"] = depArr[j].DEPNAME;
                    }
                }
            }
            table.render({
                elem: '#HZ_xsz',
                height: 315,
                width: 370,
                page: true, //开启分页
                cols: [[ //表头
                { field: 'KH_sap', title: '销售组编号', width: 115, sort: true },
                { field: 'KH_name', title: '销售组名称', width: 100 },
                { field: 'count', title: '订单数量', width: 90 },
                { field: 'total', title: '总价', width: 60 }
                ]],
                data: arr,
                id: 'HZ_xsz'
            });

        },
        error: function () {
            alert("code1005,请联系管理员");
        }
    });

}


$(document).ready(function () {


    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var layer = layui.layer;


    var laydate = layui.laydate;

    laydate.render({
        elem: '#time_start'
    });

    laydate.render({
        elem: '#time_end'
    });



    $("#btn_cx").click(function () {

        $("#hz_kh").show();
        $("#hz_bgs").show();
        $("#hz_xsz").show();
    });


    $("#hz_kh").click(function () {
        $("#btn_cx").hide();
        $("#btn_back").show();
        $("#hz_kh").hide();
        $("#hz_bgs").hide();
        $("#hz_xsz").hide();

    });


    $("#hz_bgs").click(function () {
        $("#btn_cx").hide();
        $("#btn_back").show();
        $("#hz_kh").hide();
        $("#hz_bgs").hide();
        $("#hz_xsz").hide();

    });


    $("#hz_xsz").click(function () {
        $("#btn_cx").hide();
        $("#btn_back").show();
        $("#hz_kh").hide();
        $("#hz_bgs").hide();
        $("#hz_xsz").hide();

    });


    $("#btn_back").click(function () {
        $("#btn_cx").show();
        $("#hz_kh").show();
        $("#hz_bgs").show();
        $("#hz_xsz").show();
        $("#btn_back").hide();



    });



});