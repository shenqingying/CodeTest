




$(document).ready(function () {
    var staffID = parseInt($("#staffid").val());
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var layer = layui.layer;

    var khid = 0;
    var crmid = 0;
    if (sessionStorage.getItem("BFkhid") != null) {
        var kh_model = JSON.parse(sessionStorage.getItem("BFkhid"));
        khid = kh_model.KHID;
        crmid = kh_model.CRMID;
        $("#KH_name").val(kh_model.MC);
        $("#KH_type").val(kh_model.KHLX);
        $("#BF_type").val(kh_model.BFLX);
        form.render();
    }



    getDropDownData(12, 0, "lxr_job");
    getDropDownData(19, 0, "BF_target");
    getDropDownData(20, 0, "BF_result");
    getDropDownData(32, 0, "KH_type");





    $("#btn_insert").click(function () {

        var data = {
            BFJHID: 0,                  //
            BFRYID: staffID,
            BFKH: khid,
            BFKHGID: 0,                 //
            BFLX: $("#BF_type").val(),
            CRMID: crmid,
            KHMC: $("#KH_name").val(),
            KHLX: $("#KH_type").val(),
            XSQD: "",                   //
            JHBFKSSJ: "",               //
            JHBFJSSJ: "",               //
            BFDZ: $("#BF_address").val(),
            BFSJ: $("#BF_time").val(),
            BFPC: 0,//
            LXR: $("#lxr_name").val(),
            LXRTEL: $("#lxr_tel").val(),
            LXRZW: $("#lxr_job").val(),
            BFMD: $("#BF_target").val(),
            BFJG: $("#BF_result").val(),
            XCBFSJ: $("#BF_next_time").val(),
            XCBFJH: $("#BF_next_content").val(),
            QTXX: $("#other").val(),
            ISACTIVE: 1
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../BaiFang/Data_Insert_BFDJ",
            data: {
                data: JSON.stringify(data)

            },
            success: function (id) {

                if (id > 0) {

                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '登记成功！即将跳转到拜访管理页面',
                        btn: ['确定', '取消'],
                        yes: function (index, layero) {

                            if ($("#BF_type").val() == "1") {             //客户日常检查
                                sessionStorage.setItem("BFDJID", id);
                                window.location.href = "../BaiFang/Update_BaiFang";
                            }
                            else {                //新客户开发
                                window.location.href = "../BaiFang/BaiFangManage";
                            }
                            layer.close(index);
                        }
                    });



                }
                else {
                    layer.msg("保存失败！");
                }


            },
            error: function () {
                layer.msg("拜访登记失败！");
            }
        });

    });




    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {





        var laydate = layui.laydate;

        laydate.render({
            elem: '#BF_time'
        });

        laydate.render({
            elem: '#BF_next_time'
        });







    });


});