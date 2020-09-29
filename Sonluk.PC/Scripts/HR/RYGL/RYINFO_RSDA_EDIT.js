var index = parent.layer.getFrameIndex(window.name);
layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'upload'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var $ = layui.jquery;
    var upload = layui.upload;
    layopen();
    SJZD_LIST(47, "#addinfo_zwlevel");
    $(document).ready(function () {
        load_info();
    })
    function layopen() {
        var wid = $('.layui-body_ryxx').width() - 250;
        layer.open({
            type: 1,
            shade: 0,
            area: ['200px', '400px'], //宽高
            content: $('#xfc'), //这里content是一个普通的String
            title: '目录',
            offset: ['100px', wid + 'px']
        });
    }

    $("#btn_cancel").click(function () {
        parent.layer.close(index);
    })
})
function load_info() {
    var form = layui.form;
    var datastring = {
        GH: $('#ghid').val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../RYGL/GET_YGINFO",
        data: {
            datastring: JSON.stringify(datastring),
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            var dataCount = resdata.HR_RY_RYINFO_LIST
            if (resdata.MES_RETURN.TYPE == "S") {
                $("#text_name").html(dataCount[0].YGNAME + " (" + dataCount[0].GH + ")");
                $("#text_bm").html(dataCount[0].DEPTNAME);
                $("#text_gsbm").html(dataCount[0].GSBMNAME);
                $("#text_zzzt").html(dataCount[0].ZZZTNAME);
                $("#text_rzrq").html(dataCount[0].RZDATE);
                $("#text_zc").html(dataCount[0].ZCNAME);
                if (dataCount[0].ZZZTNAME == "离职") {
                    $("#lzxx").show();
                }
                $("#text_lzrq").html(dataCount[0].LZRQ);
                if (dataCount[0].IMAGEURL == "") {
                    $("#demo1").attr("src", "../../Areas/HR/img/empty.jpg");
                } else {
                    $("#pic_scr").html(dataCount[0].IMAGEURL);
                    load_pic();
                }
                $("#addinfo_gh").val(dataCount[0].GH);
                $("#addinfo_name").val(dataCount[0].YGNAME);
                $("#addinfo_zzlb").val(dataCount[0].ZZTYPENAME);
                $("#addinfo_zzno").val(dataCount[0].ZZNO);
                $("#addinfo_birthday").val(dataCount[0].BIRTHDAT);
                $("#addinfo_sex").val(dataCount[0].XB);
                $("#addinfo_sfzdate").val(dataCount[0].SFZYXRQ);
                $("#addinfo_zc").html(dataCount[0].ZCNAME);
                $("#addinfo_xxfs").val(dataCount[0].STUDEFSNAME);
                $("#addinfo_xl").val(dataCount[0].EDUCACTIONNAME);
                $("#addinfo_zy").val(dataCount[0].ZY);
                $("#addinfo_lb").val(dataCount[0].YGTYPENAME);
                $("#addinfo_zztype").val(dataCount[0].ZZZTNAME);
                $("#in_DJRQ").val(dataCount[0].RZDATE);
                $("#in_GLQSR").val(dataCount[0].GLQSR);
                $("#addinfo_gs").val(dataCount[0].GSNAME);
                $("#addinfo_gsbm").val(dataCount[0].GSBMNAME);
                $("#addinfo_bm").val(dataCount[0].DEPTNAME);
                $("#addinfo_dqgw").val(dataCount[0].JOBSNAME);
                $("#addinfo_dqzw").val(dataCount[0].DUTYNAME);
                $("#addinfo_zj").val(dataCount[0].DUTYLEVEL);
                $("#addinfo_gj").val(dataCount[0].GJNAME);
                $("#addinfo_mz").val(dataCount[0].MZNAME);
                $("#addinfo_jg").val(dataCount[0].JG);
                $("#addinfo_lxdh").val(dataCount[0].PHONENUMBER);
                $("#addinfo_hjdz").val(dataCount[0].HJADDRESS);
                $("#addinfo_lxdz").val(dataCount[0].JZADDRESS);

                $("#addinfo_hyzk").val(dataCount[0].HYZKNAME);
                $("#addinfo_zzmm").val(dataCount[0].ZZMMNAME);

                $("#addinfo_oldgh").val(dataCount[0].GHOLD);
                $("#addinfo_bz").val(dataCount[0].REMARK);
                $("#addinfo_cj").val(dataCount[0].CJNO);
                $("#addinfo_ls").val(dataCount[0].LSNO);
                $("#addinfo_jzz").val(dataCount[0].JZZYYQ);
                $("#addinfo_hyz").val(dataCount[0].HYNO);
                $("#addinfo_hyyxrq").val(dataCount[0].HYYYQ);
                $("#addinfo_dqzw_in").val(dataCount[0].DUTYNAME);
                $("#addinfo_byschool").val(dataCount[0].EDUCACTIONSCHOOL);
                $("#addinfo_zwlevel").val(dataCount[0].ZWLEVEL);
                $("#addinfo_zwlevelname").val(dataCount[0].ZWLEVELNAME);
                $("#addinfo_phoneshort").val(dataCount[0].PHONESHORT);
                $("#addinfo_bzinfo").val(dataCount[0].BZNAME);
                
                form.render();
            }
        }
    });
}
function load_pic() {
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../RYGL/Data_load_PIC",
        data: {
            srcdata: $('#pic_scr').html()
        },
        success: function (data) {
            $("#demo1").attr("src", data);
        }
    });
};

function SJZD_LIST(TYPEID, formid) {
    var form = layui.form;
    var datastring = {
        TYPEID: TYPEID
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZZJG/GET_TYPEMX",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $(formid).html("");
                var rstcount = resdata.HR_SY_TYPEMX.length;
                $(formid).append(new Option("请选择", "0"));
                for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                    $(formid).append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
                }
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
};