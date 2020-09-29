

function getFormatNowDate() {
    var date = new Date();
    var seperator1 = "-";
    var year = date.getFullYear();
    var month = date.getMonth() + 1;
    var strDate = date.getDate();
    if (month >= 1 && month <= 9) {
        month = "0" + month;
    }
    if (strDate >= 0 && strDate <= 9) {
        strDate = "0" + strDate;
    }
    var currentdate = year + seperator1 + month + seperator1 + strDate;
    return currentdate;
}


function BBTableLoad() {
    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_GZRL",
        data: {},
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#result_bb',
                page: {
                    limit: 10
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    //{ title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'BBID', title: '日历版本id', width: 110, event: 'click' },
                { field: 'MS', title: '日历描述', width: 200, event: 'click' },
                //{ fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("日历版本列表加载失败");
        }
    });


}


function MXTableLoad(bbid) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_GZRLMX",
        data: {
            bbid: bbid,
            start: $("#start_time").val(),
            end: $("#end_time").val()
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#result_mx',
                page: {
                    limit: 10
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    //{ title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'BBID', title: '版本id', width: 110 },
                { field: 'DATE', title: '日期', width: 110 },
                { field: 'SFGZR', title: '工作日', width: 120, templet: '#switchTpl', event: 'click' },
                { field: 'BEIZ', title: '备注', width: 120 },
                //{ fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("数据列表加载失败");
        }
    });


}


$(document).ready(function () {

    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;
    var laydate = layui.laydate;


    $("#start_time").val(getFormatNowDate());
    $("#end_time").val(getFormatNowDate());

    BBTableLoad();




    $("#btn_back").click(function () {

        $("#div1").show();
        $("#div_tb_mx").hide();

    });


    $("#btn_daoru").click(function () {
        var layindex;
        layer.open({
            type: 1,
            shade: 0,
            btn: ['导入', '取消'],
            area: ['400px', '200px'], //宽高
            content: $("#div_daoru"),
            title: '导入工作日历明细',
            moveOut: true,
            yes: function (index, layero) {
                if ($("#year").val() == "") {
                    layer.msg("请选择要导入的年份！");
                    return false;
                }


                layer.close(index);
                layindex = layer.load();
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../System/Data_DaoRu_GZRLMX",
                    data: {
                        BBID: $("#bbid").val(),
                        year: $("#year").val()
                    },
                    success: function (sesponseTest) {

                        if (sesponseTest > 0) {
                            layer.msg("导入成功！");
                        }
                        else if (sesponseTest == -1) {
                            layer.msg("导入过程中出现问题，请联系管理员！");
                        }
                        else {
                            layer.msg("导入失败！");
                        }
                        layer.close(layindex);
                    },
                    error: function () {
                        alert("系统错误,请联系管理员");
                        layer.close(layindex);
                    }
                });
                
            },
            end: function () {
                $("#div_daoru").hide();
            }
        });

    });


    layui.use(['form', 'layer', 'element', 'table', 'laydate'], function () {

        laydate.render({
            elem: '#start_time',
            done: function (value, date, endDate) {
                if ($("#start_time").val() != "" && $("#end_time").val() != "")
                    MXTableLoad(parseInt($("#bbid").val()));

            }
        });

        laydate.render({
            elem: '#end_time',
            done: function (value, date, endDate) {
                if ($("#start_time").val() != "" && $("#end_time").val() != "")
                    MXTableLoad(parseInt($("#bbid").val()));

            }
        });

        laydate.render({
            elem: '#year',
            type: 'year'
        });


        //监听工具条
        table.on('tool(result_bb)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (layEvent == "click") {

                $("#div1").hide();
                $("#div_tb_mx").show();

                $("#bbid").val(data.BBID);
                MXTableLoad(data.BBID);
            }


        });


        //监听工具条
        table.on('tool(result_mx)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (layEvent == "click") {
                var mxdata = {
                    BBMXID: data.BBMXID,
                    BBID: data.BBID,
                    DATE: data.DATE,
                    SFGZR: !(data.SFGZR),
                    ISACTIVE: data.ISACTIVE,
                    BEIZ: data.BEIZ
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/Data_Update_GZRLMX",
                    data: {
                        data: JSON.stringify(mxdata)
                    },
                    success: function (id) {
                        if (id <= 0) {
                            layer.msg("系统错误");
                            return false;
                        }


                    },
                    error: function () {
                        alert("数据列表加载失败");
                    }
                });



                //MXTableLoad(data.BBID);
            }


        });




        form.render();

    });

});



