

//渠道表格数据加载
function TableLoad_qudao(bfdjid) {
    $("#div_result").empty();
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../BaiFang/Data_Select_BFqudao",
        data: {
            BFDJID: bfdjid
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);

            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;

                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="90%">'
                    + '<tr><td width="60">序号：' + xuhao + '</td><td>渠道名称：' + data[i].QDIDDES + '</td><td width="60"><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td></tr>'
                    + '</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');

                $("#btn_delete" + xuhao).on("click", { key: i }, function (event) {
                    //alert(event.data.key);
                    var count = event.data.key;
                    var xuhaoid = count + 1;

                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '确定删除?',
                        btn: ['确定', '取消'],
                        yes: function (index, layero) {

                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../BaiFang/Data_Delete_BFqudao",
                                data: {
                                    BFQDID: data[count].BFQDID
                                },
                                success: function (id) {
                                    if (id > 0) {
                                        //TableLoad_qudao(bfdjid);
                                        layer.msg("删除成功！");
                                    }
                                    else {
                                        layer.msg("删除失败！");
                                    }


                                },
                                error: function (err) {
                                    layer.msg("系统错误,请重试！")
                                }
                            });
                            layer.close(index);
                        }
                    });

                });

                $("#div_result").append('</div>');
            }

        },
        error: function () {
            alert("code1011,请联系管理员");
        }
    });

}

//照片表格数据加载
function TableLoad_img(bfdjid) {
    $("#div_result").empty();
    var data;
    var table = layui.table;
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_WJJL",
        data: {
            dxname: 6,
            id: bfdjid
        },
        success: function (resdata) {
            //alert(resdata);
            data = JSON.parse(resdata);
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;



                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="100%"><tr><td colspan="2" width="350">序号：' + xuhao + '</td></tr>'
                    + '<tr><td width="100">图片：</td><td width="200"><img style="width:100px;" src="' + data[i].ML + '" onclick="window.open(\'' + data[i].ML + '\')" /></td></tr>'
                    + '<tr><td width="100" colspan="2">照片来源：' + data[i].IMGSOURCE + '</td></tr>'
                    + '<tr><td width="100" colspan="2">照片类型：' + data[i].WJLXDES + '</td></tr>'
                    + '</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                $("#btn_watch" + xuhao).on("click", { key: i }, function (event) {
                    //alert(event.data.key);
                    var count = event.data.key;

                    window.open(data[count].ML);
                });


                $("#btn_delete" + xuhao).on("click", { key: i }, function (event) {
                    //alert(event.data.key);
                    var count = event.data.key;
                    var xuhaoid = count + 1;

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
                                    id: data[count].ID
                                },
                                success: function (id) {
                                    if (id > 0) {
                                        {
                                            TableLoad_img(bfdjid);
                                            layer.msg("删除成功！");
                                        }

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



                });





                $("#div_result").append('</div>');
            }

            


        },
        error: function () {
            alert("code1015,请联系管理员");
        }
    });

}


$(document).ready(function () {
    var staffID = parseInt($("#staffid").val());
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var layer = layui.layer;
    var appid = $("#appid").val();
    var state = $("#state").val();
    var samestaff = false;
    var isactive = 0;
    var source;

    getDropDownData(12, 0, "lxr_job");
    getDropDownData(19, 0, "BF_target");
    getDropDownData(20, 0, "BF_result");
    getDropDownData(28, 0, "BF_type");
    getDropDownData(32, 0, "KH_type");
    getDropDownData(49, 0, "newimg_type");

    var khid;
    var BFDJID;
    if (sessionStorage.getItem("BFDJID") != null) {
        BFDJID = parseInt(sessionStorage.getItem("BFDJID"));
        //TableLoad_qudao(BFDJID);
        //读取该拜访登记记录的信息
        $.ajax({
            type: "POST",
            async: false,
            url: "../BaiFang/Data_Select_BFDJ_BY_BFDJID",
            data: {
                BFDJID: BFDJID
            },
            success: function (reslist) {
                var data = JSON.parse(reslist);
                khid = data.BFKH;

                isactive = data.ISACTIVE;
                if (data.BFRYID == staffID)
                    samestaff = true;

                $("#BF_type").val(data.BFLX);
                $("#KH_crmID").val(data.CRMID);
                $("#KH_name").val(data.KHMC);
                $("#KH_type").val(data.KHLX);
                $("#BF_address").val(data.BFDZ);
                $("#BF_time").val(data.JHBFKSSJ);
                $("#lxr_name").val(data.LXR);
                $("#lxr_tel").val(data.LXRTEL);
                $("#lxr_job").val(data.LXRZW);
                $("#BF_target").val(data.BFMD);
                $("#BF_result").val(data.BFJG);
                //$("#BF_next_content").val(data.XCBFJH);
                //$("#BF_next_time").val(data.XCBFSJ);
                $("#other").val(data.QTXX);
                $("#BF_status").val(data.ISACTIVE);
                form.render();

                TableLoad_img(BFDJID);
                if (samestaff == true && isactive == 0) {
                    $("#div_foot").show();

                }
                else {
                    $("button").hide();
                }


                //加载该客户已有的渠道信息以供选择
                //$.ajax({
                //    type: "POST",
                //    async: false,
                //    url: "../KeHu/Data_Select_QTXX",
                //    data: {
                //        KHID: data.BFKH,
                //        XXLB: 1
                //    },
                //    success: function (reslist) {
                //        var res = JSON.parse(reslist);
                //        depArr = res;
                //        for (var i = 0; i < res.length; i++) {
                //            $("#qudao006").append("<option value='" + res[i].XXMC + "'>" + res[i].XXMC + "</option>");
                //        }
                //        form.render();
                //    }
                //});



            }
        });
    }
    else {
        alert("数据读取失败！");
        window.location.href = "../BaiFang/BaiFangManage";
    }







    GetData(appid, staffid, state);







    $("#btn_save").click(function () {
        //$("#action_status").val("insert");
        var data = {
            BFDJID: BFDJID,
            //BFJHID: 0,                  
            //BFRYID: staffID,
            //BFKH: khid,

            //BFLX: $("#BF_type").val(),
            //CRMID: $("#KH_crmID").val(),
            //KHMC: $("#KH_name").val(),
            //KHLX: $("#KH_type").val(),

            //JHBFKSSJ: "",               
            //JHBFJSSJ: "",               
            //BFDZ: $("#BF_address").val(),
            //BFSJ: $("#BF_time").val(),

            LXR: $("#lxr_name").val(),
            LXRTEL: $("#lxr_tel").val(),
            LXRZW: $("#lxr_job").val(),
            BFMD: $("#BF_target").val(),
            BFJG: $("#BF_result").val(),
            //XCBFSJ: $("#BF_next_time").val(),
            //XCBFJH: $("#BF_next_content").val(),
            QTXX: $("#other").val(),
            ISACTIVE: $("#BF_status").val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../BaiFang/Data_Update_BFDJ",
            data: {
                data: JSON.stringify(data),
                BFDJID: BFDJID
            },
            success: function (id) {
                if (id > 0) {

                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '保存成功，即将跳转到管理界面',
                        btn: ['确定'],
                        yes: function (index, layero) {

                            window.location.href = "../BaiFang/BaiFangManage";
                            layer.close(index);
                        },
                        end: function (index, layero) {

                            window.location.href = "../BaiFang/BaiFangManage";
                        }
                    });


                }
                else {
                    layer.msg("保存失败！");
                }


            },
            error: function () {
                layer.msg("拜访登记保存失败！");
            }
        });
        return false;
    });





    $("#insert_qudao").click(function () {
        //$("#action_status").val("insert");
        layer.open({
            type: 1,
            shade: 0,
            btn: '保存',
            area: ['80%', '350px'], //宽高
            content: $('#006'),
            title: '新增渠道',
            moveOut: true,
            yes: function (index, layero) {

                //把选中的XXMC转换成DICID再存
                $.ajax({
                    type: "POST",
                    //async: false,
                    url: "../BaiFang/Data_Insert_BFqudao",
                    data: {
                        BFDJID: BFDJID,
                        qudaoName: $("#qudao006").val()
                    },
                    success: function (id) {
                        if (id > 0) {
                            //TableLoad_qudao(BFDJID);
                            layer.msg("保存成功！");
                        }
                        else {
                            layer.msg("保存失败！");
                        }

                    },
                    error: function () {
                        alert("code1012,请联系管理员");
                    }
                });
                layer.close(index);
            },
            end: function () {
                $("#qudao006").val("0");
                $("#006").hide();
                form.render();
            }
        });
        return false;
    });




    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {




        var laydate = layui.laydate;
        var upload = layui.upload;


        laydate.render({
            elem: '#BF_next_time'
        });


        //upload.render({
        //    elem: '#insert_img', //绑定元素
        //    method: 'post',
        //    url: '../Public/Data_FileUpload', //上传接口
        //    before: function () {
        //        var mydate = new Date();
        //        var loaddata = {
        //            GSDX: 6,
        //            GSDXID: BFDJID,
        //            //操作人
        //            //CZSJ: mydate.toLocaleDateString(),
        //            ISACTIVE: 1
        //        };
        //        index_befo = layer.load();
        //        this.data = {
        //            DXID: BFDJID,
        //            data: JSON.stringify(loaddata)
        //        }

        //    },
        //    done: function (res) {
        //        //上传完毕回调


        //        TableLoad_img(BFDJID);
        //        layer.msg("成功");
        //        layer.close(index_befo);
        //    },
        //    error: function () {
        //        //请求异常回调
        //        layer.msg("上传失败");
        //        layer.close(index_befo);
        //    }
        //});

        $("#insert_img_camera").click(function () {
            source = "camera";
            

            layer.open({
                type: 1,
                shade: 0,
                btn: ['确定', '取消'],
                area: ['100%', '250px'], //宽高
                content: $('#div_newimg'),
                title: '新增拜访照片',
                moveOut: true,
                yes: function (index, layero) {
                    if ($("#newimg_type").val() == "0") {
                        layer.msg("请选择图片类型");
                        return false;
                    }
                    ImgUpload(appid, state, 6, BFDJID, ['camera'],$("#newimg_type").val());

                },
                end: function () {
                    $("#newimg_type").val(0);
                    $("#div_newimg").hide();

                    form.render();
                }
            });




        });

        $("#insert_img_album").click(function () {
            source = "album";
            
            layer.open({
                type: 1,
                shade: 0,
                btn: ['确定', '取消'],
                area: ['100%', '250px'], //宽高
                content: $('#div_newimg'),
                title: '新增拜访照片',
                moveOut: true,
                yes: function (index, layero) {
                    if ($("#newimg_type").val() == "0") {
                        layer.msg("请选择图片类型");
                        return false;
                    }
                    ImgUpload(appid, state, 6, BFDJID, ['album'], $("#newimg_type").val());

                },
                end: function () {
                    $("#newimg_type").val(0);
                    $("#div_newimg").hide();

                    form.render();
                }
            });
        });


    });


});