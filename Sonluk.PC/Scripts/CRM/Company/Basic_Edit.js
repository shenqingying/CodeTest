


//出差抬头表格加载
function TableLoad_TT() {

    var data = [{
        NAME: "企业概况",
        ISACTIVE:1
    }, {
        NAME: "企业实力",
        ISACTIVE: 1
    }, {
        NAME: "企业视频",
        ISACTIVE: 1
    }, {
        NAME: "企业样本册",
        ISACTIVE: 1
    }];

    var table = layui.table;
    table.render({
        elem: '#tb_TT',
        data: data,
        page: true, //开启分页
        cols: [[ //表头
            { type: 'checkbox', fixed: 'left' },
            { title: '序号', templet: '#indexTpl', width: 60 },
          { field: 'NAME', title: '目录名称', width: 100 },
          { field: 'ISACTIVE', title: '是否启用', width: 150, templet: '#zhuangtai' },
          { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_TT', fixed: 'right' }
        ]]
    });
    //$.ajax({
    //    type: "POST",
    //    //async: false,
    //    url: "../Company/Data_Select_CCTT_ByModel",
    //    data: {
    //        cxdata: JSON.stringify(cxdata),
    //        status: 1
    //    },
    //    success: function (resdata) {
            
    //        var data = JSON.parse(resdata);
    //        table.render({
    //            elem: '#tb_TT',
    //            data: data,
    //            page: true, //开启分页
    //            cols: [[ //表头
    //                { type: 'checkbox', fixed: 'left' },
    //                { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left' },
    //              { field: 'CCRNAME', title: '目录名称', width: 100 },
    //              { field: 'CCDD', title: '是否启用', width: 150 },
    //              { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_TT', fixed: 'right' }
    //            ]]
    //        });

    //    },
    //    error: function () {
    //        alert("出差抬头加载失败");
    //    }
    //});

}







$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var staffID = $("#staffid").val() == "" ? 0 : parseInt($("#staffid").val());
    var ccid;
    var cxdata = {
        SJKSSJ: $("#se_time_open").val(),
        SJCCJSSJ: $("#se_time_end").val(),
        STAFFID: staffID,
        ISACTIVE: $("#status").val()
    };


    







    TableLoad_TT();



    $("#btn_cx").click(function () {
        if (($("#se_time_open").val() == "" && $("#se_time_end").val() != "") || ($("#se_time_open").val() != "" && $("#se_time_end").val() == "")) {
            layer.msg("请填写完整的时间段！");
            return false;
        }


        
        TableLoad_TT();
        $("#div_select_tiaojian").removeClass("layui-show");
    });


    $("#btn_insert").click(function () {
        
    });


    $("#btn_back").click(function () {
        $("#btn_cx").show();
        $("#div_TT").show();
        $("#btn_back").hide();
        $("#btn_insert").hide();
        $("#div_MX").hide();

    });



    








    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {
        var upload = layui.upload;
        var laydate = layui.laydate;








        upload.render({
            elem: '#btn_insert', //绑定元素
            method: 'post',
            accept: 'file',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var loaddata = {
                    GSDX: 5,
                    GSDXID: ccid,
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: ccid,
                    data: JSON.stringify(loaddata)
                }

            },
            done: function (res) {
                //上传完毕回调
                layer.msg("成功");
                layer.close(index_befo);
                TableLoad_fujian(ccid);
            },
            error: function () {
                //请求异常回调
                layer.msg("上传失败");
                layer.close(index_befo);
            }
        });



        //监听抬头表工具条
        table.on('tool(tb_TT)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'delete') {
                
                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Company/Data_Delete_CCTT",
                            data: {
                                CCID: data.CCID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_TT();
                                    layer.msg("删除成功！");
                                }
                                else
                                    layer.msg("删除失败");

                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！");
                            }
                        });
                        layer.close(index);
                    }
                });
            }
            else if (obj.event == 'watch') {
                
                $("#btn_cx").hide();
                $("#div_TT").hide();
                $("#btn_back").show();
                $("#btn_insert").show();
                $("#div_MX").show();
                
                table.render({
                    elem: '#tb_MX',
                    data: [],
                    page: true, //开启分页
                    cols: [[ //表头
                        { type: 'checkbox', fixed: 'left' },
                        { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left' },
                      { field: 'CCRNAME', title: '图片名称', width: 100 },
                      { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_TT', fixed: 'right' }
                    ]]
                });
                //$.ajax({
                //    type: "POST",
                //    //async: false,
                //    url: "../Company/Data_Select_CCTT_ByModel",
                //    data: {
                //        cxdata: JSON.stringify(cxdata),
                //        status: 1
                //    },
                //    success: function (resdata) {

                //        var data = JSON.parse(resdata);
                //        table.render({
                //            elem: '#tb_MX',
                //            data: data,
                //            page: true, //开启分页
                //            cols: [[ //表头
                //                { type: 'checkbox', fixed: 'left' },
                //                { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left' },
                //              { field: 'CCRNAME', title: '目录名称', width: 100 },
                //              { field: 'CCDD', title: '是否启用', width: 150 },
                //              { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_TT', fixed: 'right' }
                //            ]]
                //        });

                //    },
                //    error: function () {
                //        alert("出差抬头加载失败");
                //    }
                //});
               



            }


        });



        //监听出差明细表工具条
        table.on('tool(CC_detail)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'delete') {
                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KaoQin/Data_Delete_CCMX",
                            data: {
                                CCID: data.CCID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_TT();
                                    layer.msg("删除成功！");
                                }
                                else
                                    layer.msg("删除失败");

                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！");
                            }
                        });
                        layer.close(index);
                    }
                });
            }
            else if (obj.event == 'edit') {

                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['500px', '500px'], //宽高
                    content: $('#div_detail'),
                    title: '出差申请明细',
                    moveOut: true,
                    btn: ['保存', '取消'],
                    yes: function (index, layero) {

                        var MXdata = {
                            ID: data.ID,
                            CCID: ccid,
                            DATE: $("#mx_time").val(),
                            CCSJLX: $("#mx_timetype").val(),
                            DD: $("#mx_address").val(),
                            GZMB: $("#mx_target").val(),
                            MBWCQK: $("#mx_report").val(),
                            ISACTIVE: 1

                        };
                        $.ajax({
                            type: "POST",
                            url: "../KaoQin/Data_Update_CCMX",
                            data: {
                                data: JSON.stringify(MXdata)
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_CCMX(ccid);
                                    layer.msg("修改成功！");
                                }
                                else
                                    layer.msg("修改失败");
                            }
                        });

                        layer.close(index); //如果设定了yes回调，需进行手工关闭
                    },
                    success: function () {

                        $("#mx_time").val(data.DATE);
                        $("#mx_timetype").val(data.CCSJLX);
                        $("#mx_address").val(data.DD);
                        $("#mx_target").val(data.GZMB);
                        $("#mx_report").val(data.MBWCQK);
                        form.render();
                        //根据所选行的出差id把出差明细和附件带出来
                        $("#btn_next").hide();
                        $("#btn_submit").show();
                        $("#div_detail_table").show();
                    },
                    end: function () {
                        $("#mx_time").val("");
                        $("#mx_timetype").val("0");
                        $("#mx_address").val("");
                        $("#mx_target").val("");
                        $("#mx_report").val("");
                        TableLoad_CCMX(ccid);
                        $('#div_detail').hide();
                    }
                });



            }
            else if (obj.event == "signin") {
                if (data.ISQD == true) {
                    layer.msg("已经签过到，无须再签");
                    return false;
                }

            }


        });



        //监听附件工具条
        table.on('tool(fujian_upload)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'delete') {
                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KeHu/Data_Delete_WJJL",
                            data: {
                                id: data.ID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_fujian(ccid);
                                    layer.msg("删除成功！");
                                }
                                else
                                    layer.msg("删除失败");

                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！");
                            }
                        });
                        layer.close(index);
                    }
                });
            }
            else if (obj.event == 'watch') {
                window.open(obj.data.ML);
            }


        });








    });


});