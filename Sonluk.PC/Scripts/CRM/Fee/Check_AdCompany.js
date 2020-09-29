$(document).ready(function () {
    layui.use(['form', 'layer', 'element', 'laydate', 'upload', 'table'], function () {
        var form = layui.form;
        var element = layui.element;
        var table = layui.table;
        var laydate = layui.laydate;
        var layer = layui.layer;
        var upload = layui.upload;


        getDropDownData(1, 0, "SF");

        Read_Table();

        form.on('select(SF)', function (data) {


            $("#CS").empty();
            $("#SF").append("<option value='0'>全部</option>");
            $("#CS").append("<option value='0'>全部</option>");
            getDropDownData(2, data.value, "CS");
        });



        $("#btn_select").click(function () {
            Read_Table();
            $("btn_select_tiaojian").removeClass("layui-show");
        })










        //审核按钮
        $("#btn_shenhe").click(function () {
           // var layindex = layer.load();
            var checkStatus = table.checkStatus('result');
            var data;

            if (checkStatus.data.length == 0) {
              //  layer.close(layindex);
                layer.msg("请选择一行数据！");
                return false;
            }
            else if (checkStatus.data.length == 1) {
            //    for (var i = 0; i < checkStatus.data.length; i++) {
                    if (checkStatus.data[0].ISACTIVE != 2) {
                   //     layer.close(layindex);
                        layer.msg("数据错误，只有状态是审核中的数据才允许审核");
                        return false;
                    }
                    layer.open({
                        type: 1,
                        area: ['50%', '60%'], //宽高
                        content: $('#div_text'),
                        btn: ['确定', '取消'],
                        shade: 0,
                        moveOut: true,
                        success: function () {
                            
                        },
                        yes: function (index, layero) {
                            checkStatus.data[0].BEIZ = $("#desc").val();

                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../Fee/ChangeOrder_AdCompany",
                                data: {
                                    GGGSID: JSON.stringify(checkStatus.data)

                                },
                                success: function (result) {
                                    var res = JSON.parse(result);
                                    layer.msg(res.MSG);
                                    if (res.KEY > 0)
                                        Read_Table();
                                    layer.close(index);
                                    $("#div_text").hide();
                                },
                                error: function (err) {

                                    $("#div_text").hide();
                                    layer.close(index);
                                    layer.msg("审核失败,请联系管理员！")
                                }


                            })

                        },
                        end:function(index,layero)
                        {
                            $("#div_text").hide();
                        }

                    })
               // }
            }
       
        })


        //回退按钮
        $("#btn_back").click(function () {
          //  var layindex = layer.load();
            var checkStatus = table.checkStatus('result');
            var data;

            if (checkStatus.data.length == 0) {
             //   layer.close(layindex);
                layer.msg("请选择一行数据！");
                return false;
            }
            else if (checkStatus.data.length == 1) {

               // for (var i = 0; i < checkStatus.data.length; i++) {
                    if (checkStatus.data[0].ISACTIVE != 2) {
                  //      layer.close(layindex);
                        layer.msg("数据错误，当前状态不允许回退");
                        return false;
                    }
                    layer.open({
                        type: 1,
                        area: ['50%', '60%'], //宽高
                        content: $('#div_text'),
                        btn: ['确定', '取消'],
                        shade: 0,
                        moveOut: true,
                        success: function () {

                        },
                        yes: function (index, layero) {
                            checkStatus.data[0].BEIZ = $("#desc").val();

                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../Fee/BackOrder_AdCompany",
                                data: {
                                    GGGSID: JSON.stringify(checkStatus.data)

                                },
                                success: function (result) {
                                    var res = JSON.parse(result);
                                    layer.msg(res.MSG);
                                    if (res.KEY > 0)
                                        Read_Table();
                                    layer.close(index);
                                    $("#div_text").hide();
                                    //  layer.close(layindex);
                                },
                                error: function (err) {
                                    $("#div_text").hide();
                                    layer.close(index);
                                    layer.msg("回退失败,请联系管理员！")
                                }
                            })

                        },
                        end: function (index, layero) {
                            $("#div_text").hide();
                        }
                    })
                }
         //   }
           
        });


        //监听事件
        table.on('tool(result)', function (obj) {
            var data = obj.data;
            var layEvent = obj.event;
            var tr = obj.tr;

            if (layEvent == 'edit') {
                sessionStorage.setItem("GGGSID", obj.data.GGGSID);
                window.open("../Fee/Update_AdCompany");
            }
            else if (layEvent == 'delete') {

                layer.open({
                    type: 0,
                    title: '提示',
                    content: '确定删除？',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Delete_AdCompany",
                            data: {
                                GGGSID: obj.data.GGGSID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    Read_Table();
                            },
                            error: function (err) {
                                layer.msg("系统错误,请联系管理员！")
                            }

                        });
                        layer.close(index);
                    }
                })
            }
        })






    })
})

function Read_Table() {
    var table = layui.table;
    var data = {
        GGGSMC: $("#GGGSMC").val(),
        SF: $("#SF").val(),
        CS: $("#CS").val(),
        ISACTIVE: $("#ISACTIVE").val()
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/GetData_AdCompany",
        data: {
            cxdata: JSON.stringify(data)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: "#result",
                data: data,
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                },
                cols: [[
                     { type: 'checkbox' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'GGGSMC', title: '广告公司名称', width: 120 },
                    { field: 'SFDES', title: '省会', width: 100 },
                    { field: 'CSDES', title: '城市', width: 100 },
                    { field: 'TEL', title: '联系电话', width: 173 },
                    { field: 'GSADDRESS', title: '地址', width: 189 },
                    { field: 'KHYH', title: '开户银行', width: 167 },
                    { field: 'KHZH', title: '开户账户', width: 166 },
                    { field: 'ISACTIVE', templet: '#zhuangtai', title: '状态', width: 80 },
                    { field: 'right', title: '操作', align: 'center', width: 180, toolbar: "#manage", fixed: 'right' }
                ]]
            })
        },
        error: function () {
            alert("系统错误，请联系管理员！");
        }
    })
}



