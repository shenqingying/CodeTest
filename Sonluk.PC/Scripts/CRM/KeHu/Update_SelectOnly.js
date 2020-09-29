
function toTree(data) {
    // 删除 所有 children,以防止多次调用
    data.forEach(function (item) {
        delete item.children;
    });

    // 将数据存储为 以 id 为 KEY 的 map 索引数据列
    var map = {};
    data.forEach(function (item) {
        map[item.Id] = item;
    });
    //        console.log(map);

    var val = [];
    data.forEach(function (item) {

        // 以当前遍历项，的pid,去map对象中找到索引的id
        var parent = map[item.Pid];

        // 好绕啊，如果找到索引，那么说明此项不在顶级当中,那么需要把此项添加到，他对应的父级中
        if (parent) {

            (parent.children || (parent.children = [])).push(item);

        } else {
            //如果没有在map中找到对应的索引ID,那么直接把 当前的item添加到 val结果集中，作为顶级
            val.push(item);
        }
    });

    return val;
}

//获取url参数
function getQueryVariable(variable) {
    var query = window.location.search.substring(1);
    var vars = query.split("&");
    for (var i = 0; i < vars.length; i++) {
        var pair = vars[i].split("=");
        if (pair[0] == variable) { return pair[1]; }
    }
    return (false);
}

//根据DICID条件加载下拉框
function getSomeDropDownData(typeid, fid, selector, DICID, words) {
    var form = layui.form;
    $("#" + selector).empty();
    $("#" + selector).append('<option value="0" selected="selected">' + words + '</option>');
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Load_Dropdown",
        data: {
            typeid: typeid,
            fid: fid
        },
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                for (var j = 0; j < DICID.length; j++) {
                    if (res[i].DICID == DICID[j])
                        $("#" + selector).append("<option value='" + res[i].DICID + "'>" + res[i].DICNAME + "</option>");
                }

            }

            form.render();


        }
    });

}

//渠道、销售品种、竞品表格数据加载
function TableLoad_qudaopinzhongjingpin(khid, xxlb, isactive, elem, title) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_QTXX",
        data: {
            khid: khid,
            xxlb: xxlb,
            isactive: isactive
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#' + elem,
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'XXMC', title: title, width: 90 },
                 { fixed: 'right', width: 70, align: 'center', toolbar: '#tb_qudao' }
                ]]
            });

        },
        error: function () {
            alert("code1011-" + khid + "-" + xxlb + ",请联系管理员");
        }
    });

}

//陈列表格数据加载
function TableLoad_display(khid, isactive) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_QTXX",
        data: {
            khid: khid,
            XXLB: 4,
            isactive: isactive
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#display6',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                 { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'CLLX', title: '陈列类型', width: 90, templet: '#display_Tpl' },
                 { field: 'CLFSDES', title: '陈列方式', width: 100 },
                 { field: 'CLGSRQ', title: '陈列归属开始日期', width: 150, align: 'center' },
                 { field: 'CLGSJSRQ', title: '陈列归属结束日期', width: 150, align: 'center' },
                 //{ field: 'DISPLAYITEM', title: '双鹿陈列道具', width: 150, templet: '#displayitem_Tpl' },
                 { field: 'BEIZ', title: '备注', width: 150 },
                 { field: 'DisplayImgCount', title: '照片数量', width: 120 },
                 { fixed: 'right', width: 160, align: 'center', toolbar: '#tb_display' }
                ]]
            });

        },
        error: function () {
            alert("code1012,请联系管理员");
        }
    });

}

//邮寄地址表格数据加载
function TableLoad_post(khid) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_QTXX",
        data: {
            KHID: khid,
            XXLB: 5,
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#post6',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                 { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'KHYJDZ', title: '客户办公(邮寄)地址', width: 160 },
                 { field: 'YB', title: '邮编', width: 80 },
                 { field: 'SJR', title: '收件人', width: 80 },
                 { field: 'SJRLXFS', title: '收件人联系方式', width: 130 },
                 { field: 'BEIZ', title: '备注', width: 150 },
                 { fixed: 'right', width: 150, align: 'center', toolbar: '#tb_area' }
                ]]
            });

        },
        error: function () {
            alert("code1015,请联系管理员");
        }
    });

}

//客户联系人表格数据加载
function TableLoad_contact(khid, isactive) {
    var table = layui.table;
    var form = layui.form;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_Contact",
        data: {
            id: khid,
            LB: 1081
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);

            table.reload('contact6', {
                data: data
            });

        },
        error: function () {
            alert("code1014,请联系管理员");
        }
    });

}

//直销人员表格数据加载
function TableLoad_zxry(khid) {
    var table = layui.table;
    var form = layui.form;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_Contact",
        data: {
            id: khid,
            LB: 1082
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);

            table.render({
                elem: '#zxry6',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                 { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'LXR', title: '联系人', width: 75 },
                 { field: 'YDDH', title: '联系方式', width: 120 },
                 { field: 'BEIZ', title: '工作内容', width: 200 },
                 { fixed: 'right', width: 150, align: 'center', toolbar: '#tb_contact' }
                ]]
            });
        },
        error: function () {
            alert("直销人员表格加载失败,请联系管理员");
        }
    });

}

//管辖区域表格数据加载
function TableLoad_area(khid) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_Area",
        data: {
            id: khid
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#sale_area6',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                 { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'GXQYLX', title: '管辖区域类型', width: 120, templet: '#area_Tpl' },
                 { field: 'GXQYMCDES', title: '管辖区域名称', width: 120 },
                 { field: 'BEIZ', title: '备注', width: 300 },
                 { fixed: 'right', width: 150, align: 'center', toolbar: '#tb_area' }
                ]]
            });

        },
        error: function () {
            alert("code1015,请联系管理员");
        }
    });

}

//合作伙伴表格数据加载
function TableLoad_partner(sap) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_Partner",
        data: {
            sapsn: sap
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#partner6',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                 { title: '序号', templet: '#indexTpl', width: 60 },

                 { field: 'HZHBGN', title: '合作伙伴类型', width: 120, templet: '#partner_Tpl' },
                 //{ field: 'HZHBJSQ', title: '合作伙伴计数', width: 120, sort: true },
                 { field: 'HZHBKHID', title: 'SAP编号', width: 110, sort: true },
                 { field: 'MC', title: '合作伙伴名称', width: 200 },
                 { field: 'KHSHDZ', title: '收货人地址', width: 400 },
                 { field: 'KHSHLXR', title: '收货人', width: 80 },
                 { field: 'KHSHLXDH', title: '收货人联系方式', width: 140 },
                 { field: 'CSDES', title: '销售区域', width: 90 },
                 //{ fixed: 'right', width: 70, align: 'center', toolbar: '#tb_partner' }
                ]],
                done: function (res, curr, count) {
                    //$("[data-field='typevalue']").css('display', 'none');
                }
            });

        },
        error: function () {
            alert("code1015,请联系管理员");
        }
    });

}

//签到地址表格数据加载
function TableLoad_qiandao(khid) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Selete_KaoQin",
        data: {
            KHID: khid
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#qiandao',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'DZMS', title: '地址描述', width: 250 },
                  { field: 'SFDES', title: '省份', width: 90 },
                  { field: 'CSDES', title: '城市', width: 90 },
                  { field: 'DZRC', title: '容差(米)', width: 90 },
                 { fixed: 'right', width: 150, align: 'center', toolbar: '#tb_kaoqin' }
                ]]
            });

        },
        error: function () {
            alert("code1017,请联系管理员");
        }
    });

}

//拜访频次客户关联表格数据加载
function TableLoad_pinciToKH(khid) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_KH_KHBF_ByKHID",
        data: {
            KHID: khid
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#pinciToKH',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'DUTYNAME', title: '职务', width: 150 },
                  { field: 'BFZQDES', title: '周期', width: 90 },
                  { field: 'BFCS', title: '次数', width: 90 },
                 { fixed: 'right', width: 70, align: 'center', toolbar: '#tb_qudao' }
                ]]
            });

        },
        error: function () {
            alert("拜访频次关系列表加载失败");
        }
    });

}

//拜访频次表格数据加载
function TableLoad_pinci(khid) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_KH_BF",
        data: {
            cxdata: ""
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#pinci',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'DUTYIDDES', title: '职务', width: 150 },
                  { field: 'BFZQDES', title: '周期', width: 90 },
                  { field: 'BFCS', title: '次数', width: 90 },
                 { fixed: 'right', width: 70, align: 'center', toolbar: '#bar_select_jxs' }
                ]]
            });

        },
        error: function () {
            alert("拜访频次列表加载失败");
        }
    });

}

//分组表格数据加载
function TableLoad_group(khid) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_Group",
        data: {
            KHID: khid
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#to_group',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: '0', title: '分组ID', width: 90 },
                  { field: '1', title: '分组名称', width: 90 },
                 { fixed: 'right', width: 70, align: 'center', toolbar: '#tb_group' }
                ]]
            });

        },
        error: function () {
            alert("code1017,请联系管理员");
        }
    });

}

//图片等表格数据加载
function TableLoad_wjjl(GSDXID, GSDX, elem, titlt) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_WJJL",
        data: {
            dxname: GSDX,
            id: GSDXID
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#' + elem,
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'WJM', title: titlt, width: 200, style: 'height:100px', templet: '#imgTpl', align: 'center' },
                  { field: 'IMGSOURCE', title: '照片来源', width: 110 },
                  { field: 'CZSJ', title: '上传时间', width: 160 },
                  { field: 'SPZT', title: '审批状态', width: 110, templet: '#spzt_Tpl' },
                  { field: 'SPRNAME', title: '审批人', width: 110 },
                  { field: 'SPSJ', title: '审批时间', width: 160 },
                  { field: 'SPYJDES', title: '审批意见', width: 110 },
                  { field: 'OPINION', title: '文字说明', width: 110 },
                 { width: 150, align: 'center', toolbar: '#tb_fujian' }
                ]]
            });
            $("img.mytableimg").parent().css("height", "auto");
        },
        error: function () {
            alert("code1018,请联系管理员");
        }
    });

}

//附件表格数据加载
function TableLoad_fujian(GSDXID, GSDX, elem, titlt) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_WJJL",
        data: {
            dxname: GSDX,
            id: GSDXID
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#' + elem,
                data: data,
                width: 520,
                page: true, //开启分页
                cols: [[ //表头
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'WJM', title: titlt, width: 300 },
                 { fixed: 'right', width: 150, align: 'center', toolbar: '#tb_fujian' }
                ]]
            });

        },
        error: function () {
            alert("code1018,请联系管理员");
        }
    });

}

//渠道、销售品种、竞品保存按钮
function SaveBtn_qudao(khid, xxlb, xxmc, isactive) {

    var mydate = new Date();
    var layer = layui.layer;
    var QTdata = {
        KHID: khid,
        XXLB: xxlb,
        XXMC: $("#" + xxmc).find("option:selected").text(),
        //操作人
        //CZRQ: mydate.toLocaleDateString(),
        ISACTIVE: isactive
    };
    //var url;
    //if ($("#action_status").val() == "insert")
    //    url = "../KeHu/Data_Insert_QTXX";
    //else if ($("#action_status").val() == "edit")
    //    url = "../KeHu/Data_Update_QTXX";
    $.ajax({
        type: "POST",
        url: "../KeHu/Data_Insert_QTXX",
        data: {
            data: JSON.stringify(QTdata)
        },
        success: function (sesponseTest) {
            if (sesponseTest > 0)
                layer.msg("保存成功！");
            else if (sesponseTest == -1)
                layer.msg("数据重复！");
            else
                layer.msg("保存失败");
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest.status);
            alert(XMLHttpRequest.readyState);
            alert(textStatus);
            alert("code1007-" + khid + "-" + xxlb + ",请联系管理员");
        }
    });

}

//送货数量表格数据加载
function TableLoad_songhuo(khid) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_XSTJ",
        data: {
            KHID: khid,
            XSLB: 1
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#tb_songhuo',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                 { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'XSMC', title: '送货次数', width: 120 },
                 { field: 'XSSL', title: '送货数量', width: 120 },
                 { field: 'GSRQ', title: '送货日期', width: 120 },
                 { field: 'BEIZ', title: '备注', width: 180 },
                 { fixed: 'right', width: 150, align: 'center', toolbar: '#bar_songhuo' }
                ]]
            });

        },
        error: function () {
            alert("送货数量表格加载失败");
        }
    });

}

//直销商销售表格数据加载
function TableLoad_zhixiao(khid) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_XSTJ",
        data: {
            KHID: khid,
            XSLB: 2
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#tb_zhixiao',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                 { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'XSMC', title: '销售类别', width: 120 },
                 { field: 'XSJE', title: '销售额(万元)', width: 120 },
                 { field: 'GSRQ', title: '年份', width: 120 },
                 { fixed: 'right', width: 70, align: 'center', toolbar: '#tb_qudao' }
                ]]
            });

        },
        error: function () {
            alert("直销商销售表格加载失败");
        }
    });

}

//网点数量表格数据加载
function TableLoad_WDshuliang(khid) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_XSTJ",
        data: {
            KHID: khid,
            XSLB: 3
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#tb_WDshuliang',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                 { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'XSMC', title: '信息类别', width: 120 },
                 { field: 'XSSL', title: '数量', width: 120 },
                 { field: 'GSRQ', title: '年份', width: 120 },
                 { fixed: 'right', width: 70, align: 'center', toolbar: '#tb_qudao' }
                ]]
            });

        },
        error: function () {
            alert("直销商销售表格加载失败");
        }
    });

}

//车牌表格数据加载
function TableLoad_chepai(khid) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_QTXX",
        data: {
            khid: khid,
            XXLB: 6,
            isactive: 1
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#tb_chepai',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                 { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'XXMC', title: '车牌', width: 150 },
                 { field: 'PD', title: '车体广告', width: 100, templet: '#chepai_Tpl' },
                 { fixed: 'right', width: 160, align: 'center', toolbar: '#tb_display' }
                ]]
            });

        },
        error: function () {
            alert("车牌表格加载失败");
        }
    });

}

//促销单品数据加载
function TableLoad_cuxiao(khid) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_QTXX",
        data: {
            khid: khid,
            XXLB: 7,
            isactive: 1
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#tb_cuxiao',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                 { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'XXMC', title: '单品名称', width: 250 },
                 { field: 'PD', title: 'LKA渠道重叠', width: 120, templet: '#chepai_Tpl' },
                 { fixed: 'right', width: 160, align: 'center', toolbar: '#tb_qudao' }
                ]]
            });

        },
        error: function () {
            alert("促销单品表格加载失败");
        }
    });

}

//销售业务进展数据加载
function TableLoad_xsywjz(khid) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_XSYWJZ_ByKHID",
        data: {
            KHID: khid
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#tb_jinzhan',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                 { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'JZIDDES', title: '单品名称', width: 250 },
                 { field: 'INFO1', title: '信息描述', width: 120 },
                 { fixed: 'right', width: 160, align: 'center', toolbar: '#tb_area' }
                ]]
            });

        },
        error: function () {
            alert("销售业务进展表格加载失败");
        }
    });

}

//客户活动数据加载
function TableLoad_khhd(khid) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_KHHD_ByKHID",
        data: {
            KHID: khid
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#tb_hd',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                 { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'HDMCDES', title: '活动名称', width: 150 },
                 { field: 'HDTCDES', title: '活动套餐', width: 250 },
                 { field: 'BEIZ', title: '备注', width: 120 },
                 { field: 'IMGCOUNT', title: '照片数量', width: 120 },
                 { fixed: 'right', width: 160, align: 'center', toolbar: '#tb_display' }
                ]]
            });

        },
        error: function () {
            alert("客户活动表格加载失败");
        }
    });

}


var khid;
$(document).ready(function () {
    var typevalue;
    var isactive;
    var khlx2;
    var form = layui.form;
    var table = layui.table;
    var layer = layui.layer;
    var address_data;
    var tree = layui.tree;
    var gid;

    khid = sessionStorage.getItem("id");
    if (khid == null || khid == "")
        window.location.href = "../KeHu/Select";
    //layer.msg("这会儿应该报错的，但为了调试方便暂时放放");
    //sessionStorage.setItem("id", "");

    var model;
    getDropDownData(32, 0, "Insert_KHtype");





    table.render({
        elem: '#contact6',
        id: 'contact6',
        data: {},
        page: true, //开启分页
        cols: [[ //表头
         { title: '序号', templet: '#indexTpl', width: 60 },
         { field: 'LXR', title: '联系人', width: 75 },
         { field: 'SEX', title: '性别', width: 60 },
         { field: 'JTDZ', title: '家庭地址', width: 200 },
         { field: 'JG', title: '籍贯', width: 110 },
         { field: 'MZDES', title: '民族', width: 60 },
         { field: 'ZWDES', title: '职位', width: 80 },
         { field: 'AH', title: '爱好', width: 100 },
         { field: 'HYZKDES', title: '婚姻状况', width: 90 },
         { field: 'YDDH', title: '移动电话', width: 120 },
         { field: 'GDDH', title: '固定电话', width: 120 },
         { field: 'TEL', title: '传真', width: 120 },
         { field: 'EMAIL', title: '邮箱', width: 150 },
         { field: 'WXH', title: '微信号', width: 100 },
         { field: 'SR', title: '生日', width: 110 },
         { field: 'TXDZ', title: '通信地址', width: 200 },
         { field: 'YZBM', title: '邮政编码', width: 100 },
         { field: 'XGMS', title: '性格描述', width: 100 },
         //{ field: 'PHOTO', title: '照片', width: 60 },
         { field: 'SFZYLXR', title: '是否主要联系人', width: 120, templet: '#major_Tpl' },
         { field: 'BEIZ', title: '备注', width: 200 },
         { fixed: 'right', width: 150, align: 'center', toolbar: '#tb_area' }
        ]]
    });


    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_ByID",
        data: {
            id: khid,
        },
        success: function (reslist) {
            model = JSON.parse(reslist);

        },
        error: function () {
            alert("code1005,请联系管理员");
        }
    });

    typevalue = model.KHLX;
    isactive = model.ISACTIVE;
    khlx2 = model.KHLX2;
    $("#Insert_KHtype").val('' + typevalue);
    $("#CRMid1").val(model.CRMID);
    $("#name").val(model.MC);
    $("#Insert_KHXZ").val(model.IsOfficial);


    //根据客户类型来加载客户资质的下拉框
    if (typevalue == 1) {
        getSomeDropDownData(42, 0, 'ZZ_type', [1057], '');

        getSomeDropDownData(43, 0, 'iszxs1', [1064], '否');
    }
    else if (typevalue == 10) {
        getSomeDropDownData(42, 0, 'ZZ_type', [1057, 1058], '');
    }
    else if (typevalue == 5) {
        getSomeDropDownData(42, 0, 'ZZ_type', [1058], '');
    }




    //基本信息加载

    if (typevalue == 1 || typevalue == 2 || typevalue == 4) {   //$("#Insert_KHtype").val("经销商");
        $("#div1").show();

        $("#div_other").show();
        $("#div_qudao").show();
        $("#div_partner").show();
        $("#div_post").show();
        $("#div6").show();
        $("#div_area").show();
        $("#div_contact").show();
        //$("#div_display").show();
        $("#div_to_group").show();
        $("#div_upload").show();
        $("#div8").show();
        $("#div_qd").show();
        //$("#div_bf").show();
        if (typevalue == 1) {
            $("#for_jxs").show();
            //$("#div_zz").show();
            getDropDownData(44, 0, "source1");
            $("#source1").val(model.KHSOURCE);
            $("#iszxs1").val(model.KHLX2);
            $("#khjs1").val(model.KHJS);
        }
        else if (typevalue == 4) {
            $("#div_b2b").show();
            $("#div_b2bqianzai").show();
            $("#address10").val(model.MDDZ);
            $("#pp10").val(model.PP);
            $("#owner10").val(model.PPOWNER);
            $("#factory10").val(model.FACTORY);
            $("#remark10").val(model.BEIZ);

            getDropDownData(52, 0, "KH2type10");
            $("#KH2type10").val(model.KHLX2);
            if (model.KHLX2 == 1262) {
                $("#div_industry").show();
            }
            getDropDownData(60, 0, "industrytype1");
            $("#industrytype1").val(model.MCLC);
        }

        $("#up_name1").val(model.PKHIDDES);
        if (model.PKHID == 0)
            $("#up_id1").val("");
        else
            $("#up_id1").val(model.PKHID);
        $("#name1").val(model.MC);
        $("#jc1").val(model.JC);
        $("#sapsn1").val(model.SAPSN);
        getDropDownData(39, 0, "KP_xingzhi1");
        $("#KP_xingzhi1").val(model.KPXZ);
        $("#nsr1").val(model.NSRSBH);
        $("#KP_address1").val(model.KPDZ);
        $("#KP_tel1").val(model.KPDH);
        $("#company_lxr1").val(model.GSLXR);
        $("#company_tel1").val(model.GSLXDH);
        $("#company_faren1").val(model.FR);
        $("#company_guanxi1").val(model.GSFRGX);
        $("#KD_address1").val(model.KDJSDZ);
        $("#KD_staff1").val(model.KDLXR);
        $("#KD_tel1").val(model.KDLXDH);
        $("#mission1").val(model.HTXSRW);
        $("#JXmission1").val(model.HTXSRW);
        $("#bank_account1").val(model.YHZH);
        $("#bank_name1").val(model.YHMC);
        $("#xs_explain1").val(model.XSSJSM);
        $("#fl_explain1").val(model.FLSJSM);
        if (model.SFCCJ == true)
            $("#sfccj1").val("1");
        else if (model.SFCCJ == false)
            $("#sfccj1").val("0");

        $("#price_content").val(model.SFCCJSM);
        $("#receive_address1").val(model.KHSHDZ);
        $("#receive_staff1").val(model.KHSHLXR);
        $("#receive_tel1").val(model.KHSHLXDH);
        $("#situation_explain1").val(model.TSQKSM);
        if (model.JXSYX == true)
            $("#haveeffect1").val("1");
        else if (model.JXSYX == false)
            $("#haveeffect1").val("0");
        $("#effect_content").val(model.YXSM);
        $("#Atypeamount1").val(model.FIRSTAMOUNT);
        $("#joinactivity1").val(model.JOINACTIVITY);
        form.render('select');
    }

    else if (typevalue == 3) {
        //$("#Insert_KHtype").val("直营卖场");

        $("#div6").show();
        $("#div_area").show();
        $("#div_contact").show();
        $("#div_display").show();
        $("#div_to_group").show();
        $("#div_upload").show();
        $("#div8").show();
        $("#Markettype").show();
        //if (model.MCSX == 2) {
        //    $("#div_market_up").show();
        //}
        $("#div_qd").show();
        //$("#div_bf").show();

        $("#type_maichang2").val(model.MCSX);
        if (model.MCSX == 1) {
            $("#div2").show();

            $("#up_name2").val(model.PKHIDDES);
            if (model.PKHID == 0)
                $("#up_id2").val("");
            else
                $("#up_id2").val(model.PKHID);

            getDropDownData(1, 0, "province2");
            $("#province2").val(model.SF);
            getDropDownData(2, model.SF, "city2");
            $("#city2").val(model.CS);
            getDropDownData(34, model.CS, "county2");
            $("#county2").val(model.COUNTY);

            $("#name2").val(model.MC);
            $("#jc2").val(model.JC);
            $("#sapsn2").val(model.SAPSN);
            $("#type_maichang2").val(model.MCSX);
            $("#FK_tiaojian2").val(model.FKTJ);
            $("#company_lxr2").val(model.GSLXR);
            $("#company_tel2").val(model.GSLXDH);
            $("#KP_address2").val(model.KPDZ);
            $("#KP_tel2").val(model.KPDH);
            getDropDownData(39, 0, "KP_xingzhi2");
            $("#KP_xingzhi2").val(model.KPXZ);
            $("#nsr2").val(model.NSRSBH);
            $("#company_faren2").val(model.FR);
            $("#KD_address2").val(model.KDJSDZ);
            $("#KD_staff2").val(model.KDLXR);
            $("#KD_tel2").val(model.KDLXDH);
            $("#bank_account2").val(model.YHZH);
            $("#bank_name2").val(model.YHMC);
        }
        else if (model.MCSX == 2) {
            $("#div2p").show();

            $("#up_name2p").val(model.PKHIDDES);
            if (model.PKHID == 0)
                $("#up_id2p").val("");
            else
                $("#up_id2p").val(model.PKHID);

            getDropDownData(1, 0, "province2p");
            $("#province2p").val(model.SF);
            getDropDownData(2, model.SF, "city2p");
            $("#city2p").val(model.CS);
            getDropDownData(34, model.CS, "county2");
            $("#county2").val(model.COUNTY);

            $("#code2p").val(model.BEIZ);
            $("#name2p").val(model.MC);
            $("#jc2p").val(model.JC);
            $("#sapsn2p").val(model.SAPSN);
            $("#SH_address2p").val(model.KHSHDZ);
            $("#SH_staff2p").val(model.KHSHLXR);
            $("#SH_tel2p").val(model.KHSHLXDH);
            $("#gc2p").val(model.GC);
            $("#kcdd2p").val(model.KCDD);

        }




        form.render('select');
    }

    else if (typevalue == 5 || typevalue == 6) {
        //$("#Insert_KHtype").val("网点终端");

        $("#div4").show();
        $("#div_other").show();
        $("#div_pinzhong").show();
        $("#div_display").show();
        $("#div_to_group").show();
        $("#div_upload").show();
        $("#div7").show();
        $("#div8").show();
        $("#div_qd").show();
        //$("#div_bf").show();
        $("#div_hd").show();
        $("#div_mentou").show();

        getDropDownData(1, 0, "province4");
        $("#province4").val(model.SF);
        getDropDownData(2, model.SF, "city4");
        $("#city4").val(model.CS);
        $("#jxs_name4").val(model.PKHIDDES);
        if (model.PKHID == 0)
            $("#jxs_id4").val("");
        else
            $("#jxs_id4").val(model.PKHID);
        $("#name4").val(model.MC);
        $("#jc4").val(model.JC);
        $("#address4").val(model.MDDZ);
        $("#lxr4").val(model.GSLXR);
        $("#tel4").val(model.GSLXDH);
        getDropDownData(3, 0, "type_wangdian4");
        $("#type_wangdian4").val(model.WDLX);
        if (model.SFZXS == true)
            $("#is_zxs4").val("1");
        else if (model.SFZXS == false)
            $("#is_zxs4").val("0");
        if (model.SFBZWD == true)
            $("#is_bzwd4").val("1");
        else if (model.SFBZWD == false)
            $("#is_bzwd4").val("0");
        $("#remark4").val(model.BEIZ);
        $("#kfsj4").val(model.KHZZSJ);

        $.ajax({
            type: "POST",
            url: "../KeHu/Data_Select_KHZZ_ByKHID",
            data: {
                KHID: khid
            },
            success: function (result) {
                var res = JSON.parse(result);
                for (var i = 0; i < res.length; i++) {
                    if (res[i].ZZMCID == 1058) {       //电子锁
                        $("#is_dzs4").val("1");
                        $("#xypp4").val(res[i].INFO1);
                        $("#div_songhuo").show();
                        TableLoad_songhuo(khid);
                    }
                    else if (res[i].ZZMCID == 1080) {    //有效客户
                        $("#is_yx4").val("1");
                        $("#xl4").val(res[i].INFO1);
                        $("#sm4").val(res[i].INFO2);
                    }
                }
                form.render('select');

            }
        });

        form.render('select');
    }

    else if (typevalue == 7) {
        //$("#Insert_KHtype").val("LKA终端");


        $("#div_other").show();



        $("#div_to_group").show();
        $("#div_upload").show();
        $("#div7").show();
        $("#div8").show();
        $("#LKAtype").show();
        $("#div_qd").show();
        //$("#div_bf").show();

        $("#Insert_LKAtype").val(model.MCSX);
        if (model.MCSX == 1) {
            $("#div5").show();
            $("#div_contact").show();

            getDropDownData(57, 0, "manageway5");
            $("#manageway5").val(model.MANAGEWAY);
            getDropDownData(58, 0, "payway5");
            $("#payway5").val(model.PAYWAY);
            getDropDownData(59, 0, "jqrzw5");
            $("#jqrzw5").val(model.GSLXRZW);

            $("#jxs_name5").val(model.PKHIDDES);
            if (model.PKHID == 0)
                $("#jxs_id5").val("");
            else
                $("#jxs_id5").val(model.PKHID);
            $("#maichang_name5").val(model.MC);
            $("#jc5").val(model.JC);
            $("#store_jcsl5").val(model.MDJCSL);
            $("#address5").val(model.MDDZ);
            $("#remark5").val(model.BEIZ);
            $("#reason5").val(model.XYDJ);
            $("#kfsj5").val(model.KHZZSJ);
            $("#firsttime5").val(model.FIRSTTIME);
            $("#psqk5").val(model.PSQK);
            $("#aoe5").val(model.FSFW);
            $("#manageway5").val(model.MANAGEWAY);
            $("#payway5").val(model.PAYWAY);
            $("#jqr5").val(model.GSLXR);
            $("#jqrzw5").val(model.GSLXRZW);
            $("#jqrdh5").val(model.GSLXDH);
            $("#supportother5").val(model.SUPPORTOTHER);
            $("#isnew5").val(model.ISNEW);
            $("#pact5").val(model.PACT);
            $("#belongka5").val(model.BELONGKA);
            $("#website5").val(model.WEBSITE);
            $("#account5").val(model.ACCOUNT);
            $("#yyzt5").val(model.YYZT);
            $("#gdsj5").val(model.GDSJ);
            if (model.YYZT == 2361) {
                $("#div_gd5").show();
            }
            else {
                $("#div_gd5").hide();
            }

            $.ajax({
                type: "POST",
                url: "../KeHu/Data_Select_KHZZ_ByKHID",
                data: {
                    KHID: khid
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    for (var i = 0; i < res.length; i++) {
                        if (res[i].ZZMCID == 1080) {    //有效客户
                            $("#is_yx5").val("1");
                            $("#xl5").val(res[i].INFO1);
                            $("#sm5").val(res[i].INFO2);
                        }
                    }
                    form.render('select');

                }
            });

        }
        else if (model.MCSX == 2) {
            $("#div5p").show();
            $("#div_pinzhong").show();
            $("#div_display").show();
            $("#div_mentou").show();

            $("#maichang_name5p").val(model.PKHIDDES);
            if (model.PKHID == 0)
                $("#maichang_id5p").val("");
            else
                $("#maichang_id5p").val(model.PKHID);
            $("#store_name5p").val(model.MC);
            $("#jc5p").val(model.JC);
            getDropDownData(4, 0, "maichang_type5p");
            $("#maichang_type5p").val(model.MCLC);
            $("#maichang_pinzhong5p").val(model.XSSJSM);
            $("#address5p").val(model.MDDZ);
            $("#jcdpsl5p").val(model.JCDPSL);
            $("#remark5p").val(model.BEIZ);
            $("#kfsj5p").val(model.KHZZSJ);
            $("#yyzt5p").val(model.YYZT);
            $("#gdsj5p").val(model.GDSJ);
            if (model.YYZT == 2361) {
                $("#div_gd5p").show();
            }
            else {
                $("#div_gd5p").hide();
            }

            $.ajax({
                type: "POST",
                url: "../KeHu/Data_Select_KHZZ_ByKHID",
                data: {
                    KHID: khid
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    for (var i = 0; i < res.length; i++) {
                        if (res[i].ZZMCID == 1080) {    //有效客户
                            $("#is_yx5p").val("1");
                            $("#xl5p").val(res[i].INFO1);
                            $("#sm5p").val(res[i].INFO2);
                        }
                    }
                    form.render('select');

                }
            });

        }
        else {
            alert("code1006,请联系管理员");
        }



        form.render('select');
    }
        //电子锁
    else if (typevalue == 8) {

        $("#div_other").show();
        $("#div_pinzhong").show();
        $("#div_display").show();
        $("#div_to_group").show();
        $("#div_upload").show();
        $("#div8").show();
        $("#div_qd").show();
        $("#div_songhuo").show();
        $("#div_dzs").show();

        getDropDownData(1, 0, "province7");
        $("#province7").val(model.SF);
        getDropDownData(2, model.SF, "city7");
        $("#city7").val(model.CS);
        $("#jxs_name7").val(model.PKHIDDES);
        $("#jxs_id7").val(model.PKHID);
        $("#name7").val(model.MC);
        $("#jc7").val(model.JC);
        $("#address7").val(model.MDDZ);
        $("#lxr7").val(model.GSLXR);
        $("#tel7").val(model.GSLXDH);
        getDropDownData(35, 0, "type_wangdian7");
        $("#type_wangdian7").val(model.WDLX);
        $("#use_now7").val(model.TSQKSM);
        $("#remark7").val(model.BEIZ);

        form.render('select');
    }
        //直销商
    else if (typevalue == 9) {

        $("#div_other").show();
        $("#div_area").show();
        $("#div_contact").show();
        $("#div_display").show();
        $("#div_display").show();
        $("#div_to_group").show();
        $("#div_upload").show();
        $("#div8").show();
        $("#div_qd").show();
        $("#div_zhixiao").show();
        $("#div_zhixiaotb").show();
        $("#div_WDshuliang").show();
        $("#div_chepai").show();
        $("#div_cuxiao").show();

        getDropDownData(1, 0, "province6");
        $("#province6").val(model.SF);
        getDropDownData(2, model.SF, "city6");
        $("#city6").val(model.CS);
        $("#jxs_name6").val(model.PKHIDDES);
        $("#jxs_id6").val(model.PKHID);
        $("#name6").val(model.MC);
        $("#jc6").val(model.JC);
        $("#address6").val(model.MDDZ);
        $("#lxr6").val(model.GSLXR);
        $("#tel6").val(model.GSLXDH);
        $("#remark6").val(model.BEIZ);

        getDropDownData(36, 0, "zhixiao_type13");
        getDropDownData(37, 0, "shuliang_type14");
        getDropDownData(38, 0, "DPname16");

        $("#h2_contact").html("直销人员").append('<i class="layui-icon layui-colla-icon"></i>');
        $("#lb_contactBEIZ").html("工作内容：");

        form.render('select');
    }
    else if (typevalue == 10) {
        $("#div_zhongjian").show();
        //$("#div_zz").show();
        $("#div8").show();
        $("#div_pinzhong").show();
        $("#div7").show();
        $("#div_area").show();
        $("#div_to_group").show();
        $("#div_post").show();
        $("#div_contact").show();
        $("#div_qd").show();
        //$("#div_chepai").show();
        //$("#div_zhixiaotb").show();
        //$("#div_WDshuliang").show();
        //$("#div_cuxiao").show();
        $("#div_mentou").show();
        $("#div_display").show();


        getDropDownData(43, 0, "type_zjs8");

        getDropDownData(1, 0, "province8");
        $("#province8").val(model.SF);
        getDropDownData(2, model.SF, "city8");
        $("#city8").val(model.CS);

        $("#jxs_name8").val(model.PKHIDDES);
        if (model.PKHID == 0)
            $("#jxs_id8").val("");
        else
            $("#jxs_id8").val(model.PKHID);

        $("#name8").val(model.MC);
        $("#jc8").val(model.JC);
        $("#address8").val(model.MDDZ);
        $("#type_zjs8").val(model.KHLX2);
        $("#lxr8").val(model.GSLXR);
        $("#tel8").val(model.GSLXDH);
        $("#remark8").val(model.BEIZ);
        $("#kfsj8").val(model.KHZZSJ);

        $.ajax({
            type: "POST",
            url: "../KeHu/Data_Select_KHZZ_ByKHID",
            data: {
                KHID: khid
            },
            success: function (result) {
                var res = JSON.parse(result);
                for (var i = 0; i < res.length; i++) {
                    if (res[i].ZZMCID == 1080) {    //有效客户
                        $("#is_yx8").val("1");
                        $("#xl8").val(res[i].INFO1);
                        $("#sm8").val(res[i].INFO2);
                    }
                }
                form.render('select');

            }
        });

        form.render('select');
    }
    else if (typevalue == 1105) {
        $("#div_oem").show();


        $("#div_contact").show();
        $("#div_to_group").show();
        $("#div8").show();
        $("#div_qd").show();


        $("#up_name9").val(model.PKHIDDES);
        if (model.PKHID == 0)
            $("#up_id9").val("");
        else
            $("#up_id9").val(model.PKHID);
        $("#name9").val(model.MC);
        $("#jc9").val(model.JC);
        $("#sapsn9").val(model.SAPSN);
        getDropDownData(39, 0, "KP_xingzhi9");
        $("#KP_xingzhi9").val(model.KPXZ);
        $("#nsr9").val(model.NSRSBH);
        $("#KP_address9").val(model.KPDZ);
        $("#KP_tel9").val(model.KPDH);
        $("#company_lxr9").val(model.GSLXR);
        $("#company_tel9").val(model.GSLXDH);
        $("#company_faren9").val(model.FR);
        $("#company_guanxi9").val(model.GSFRGX);
        $("#KD_address9").val(model.KDJSDZ);
        $("#KD_staff9").val(model.KDLXR);
        $("#KD_tel9").val(model.KDLXDH);
        $("#bank_account9").val(model.YHZH);
        $("#bank_name9").val(model.YHMC);



        form.render('select');
    }
    else if (typevalue == 1106) {
        $("#div_dp").show();
        $("#div8").show();
        $("#div_display").show();
        $("#div_to_group").show();
        $("#div_mentou").show();
        $("#div_battery").show();
        $("#div_pack").show();
        $("#div_qd").show();

        getDropDownData(52, 0, "KH2type10");

        $("#KH2type10").val(model.KHLX2);
        $("#name10").val(model.MC);
        $("#address10").val(model.MDDZ);
        $("#pp10").val(model.PP);
        $("#owner10").val(model.PPOWNER);
        $("#factory10").val(model.FACTORY);
        $("#remark10").val(model.BEIZ);

        form.render('select');
    }
    else {
        layer.msg("找不到对应的客户类型");
    }

    //if (typevalue == 5 || typevalue == 7 || typevalue == 10 || isactive == 1)
    if ((isactive == 1 || model.IsOfficial == 10 || (model.IsOfficial == 30 && khlx2 != 1064)) && isactive != 2) {



        $("#btn_save_only").show();

        $("#insert_pic_mentou").show();

        $("#insert_hd").show();
        $("#insert_qudao").show();
        $("#insert_pinzhong").show();
        $("#insert_post").show();
        $("#insert_area").show();
        $("#insert_contact").show();
        $("#insert_display").show();
        $("#insert_jingpin").show();
        $("#insert_qiandaoDZ").show();
        $("#insert_BFpinci").show();

        $("#insert_zhixiao").show();
        $("#insert_WDshuliang").show();
        $("#insert_chepai").show();
        $("#insert_cuxiao").show();
        $("#insert_fujian").show();
        $("#btn_upload_display").show();
        $("#btn_upload_chepai").show();

        $("#insert_songhuo").show();

        if (isactive == 1 || model.IsOfficial == 10 || model.KHLX == 7 || model.KHLX == 5) {
            $("#insert_to_group").show();
            if (model.KHLX == 7 || model.KHLX == 5) {
                $("#name4").removeAttr("disabled");

                $("#div_bar").append('<script type="text/html" id="bar_songhuo">'
                    + '<a class="layui-btn layui-btn-xs" lay-event="edit">编辑</a>'
                    + '<a class="layui-btn layui-btn-xs layui-btn-danger" lay-event="delete">删除</a> </script>'
                    + '<script type="text/html" id="tb_group">'
                    + '<a class="layui-btn layui-btn-xs layui-btn-danger" lay-event="delete">删除</a>  </script>');
            }
            if (isactive == 1) {
                $("#insert_qiandaoDZ").show();
                $("#btn_save_only_submit").show();
            }
        }



        $("#div_bar").append('<script type="text/html" id="bar_select_jxs">'
         + '<a class="layui-btn layui-btn-xs" lay-event="confirm">确认</a> </script>'

       + '<script type="text/html" id="tb_area">'
          + '<a class="layui-btn layui-btn-xs" lay-event="edit">编辑</a>'
          + '<a class="layui-btn layui-btn-xs layui-btn-danger" lay-event="delete">删除</a> </script>'

       + '<script type="text/html" id="tb_display">'
          + '<a class="layui-btn layui-btn-xs" lay-event="edit">编辑</a>'
          + '<a class="layui-btn layui-btn-xs" lay-event="img">照片</a>'
          + '<a class="layui-btn layui-btn-xs layui-btn-danger" lay-event="delete">删除</a> </script>'

       + '<script type="text/html" id="tb_qudao">'
           + '<a class="layui-btn layui-btn-xs layui-btn-danger" lay-event="delete">删除</a>  </script>'

       + '<script type="text/html" id="tb_fujian">'
          + '<a class="layui-btn layui-btn-xs" lay-event="watch">查看</a>'
          + '<a class="layui-btn layui-btn-xs layui-btn-danger" lay-event="delete">删除</a>  </script>'

       + '<script type="text/html" id="tb_kaoqin">'
          + '<a class="layui-btn layui-btn-xs" lay-event="edit">修改容差</a>'
          + '<a class="layui-btn layui-btn-xs layui-btn-danger" lay-event="delete">删除</a> </script>');
    }
    else {
        $("#div_bar").append('<script type="text/html" id="tb_display">'
         + '<a class="layui-btn layui-btn-xs" lay-event="img">照片</a> </script>');
    }

    getDropDownData(31, 0, "marry002");

    getDropDownData_PKH(32, 0, "select_jxs_type");
    //getDropDownData_PKH(32, 0, "select_lkajxs_type");
    //getDropDownData_PKH(32, 0, "select_dzsjxs_type");
    //getDropDownData_PKH(32, 0, "select_zhixiaojxs_type");
    getDropDownData(1, 0, "province001");
    getDropDownData(7, 0, "qudao006");
    getDropDownData(8, 0, "pinzhong007");
    getDropDownData(9, 0, "displayway004");
    getDropDownData(10, 0, "jingpin005");
    getDropDownData(11, 0, "nation002");
    getDropDownData(12, 0, "job002");
    getDropDownData(46, 0, "HDname");

    form.on('select(province001)', function (data) {

        $("#city001").empty();


        getDropDownData(2, data.value, "city001");


    });

    form.on('select(city001)', function (data) {

        $("#county001").empty();


        getDropDownData(34, data.value, "county001");


    });

    form.on('select(province2)', function (data) {

        $("#city2").empty();

        getDropDownData(2, data.value, "city2");


    });
    form.on('select(city2)', function (data) {

        $("#county2").empty();

        getDropDownData(34, data.value, "county2");
    });

    form.on('select(province2p)', function (data) {

        $("#city2p").empty();

        getDropDownData(2, data.value, "city2p");


    });
    form.on('select(city2p)', function (data) {

        $("#county2p").empty();

        getDropDownData(34, data.value, "county2p");
    });

    form.on('select(province4)', function (data) {

        $("#city4").empty();

        getDropDownData(2, data.value, "city4");


    });

    form.on('select(province8)', function (data) {

        $("#city8").empty();

        getDropDownData(2, data.value, "city8");


    });

    form.on('select(HDname)', function (data) {

        $("#HDcplx").empty();
        getDropDownData(45, data.value, "HDcplx");

        $("#HDtc").empty();
        getDropDownData(105, data.value, "HDtc");

        if (data.value == 1432) {
            $("#div_hdcl").show();
        }
        else {
            $("#div_hdcl").hide();
        }
        if (data.value == 4166) {
            $("#div_hdxl").show();
        }
        else {
            $("#div_hdxl").hide();
        }
    });

    form.on('select(Insert_LKAtype)', function (data) {
        switch (data.value) {
            case "1":
                $("#div5").show();
                $("#div5p").hide();
                break;
            case "2":
                $("#div5").hide();
                $("#div5p").show();
                break;

            default:
                $("#div5").hide();
                $("#div5p").hide();
                break;
        }



    });


    form.on('select(ZZ_type)', function (data) {
        ZZhide();    //先把所有资质界面都隐藏，然后显示当前选择的资质所需要显示的资质界面
        switch (data.value) {
            case "1057":



                break;
            case "1058":
                //$("#div_zz_dzs").show();


                break;

            default:

                break;
        }



    });

    function ZZhide() {
        $("#div_zz_dzs").hide();
    }

    form.on('select(KP_xingzhi1)', function (data) {
        switch (data.value) {
            case "919":
                $("#nsr1").attr("placeholder", "必填");
                $("#KP_address1").attr("placeholder", "必填");
                $("#KP_tel1").attr("placeholder", "必填");
                $("#bank_account1").attr("placeholder", "必填");
                $("#bank_name1").attr("placeholder", "必填");
                $("#company_faren1").attr("placeholder", "必填");
                $("#company_guanxi1").attr("placeholder", "必填");

                break;
            case "920":
                $("#nsr1").removeAttr("placeholder");
                $("#KP_address1").removeAttr("placeholder");
                $("#KP_tel1").removeAttr("placeholder");
                $("#bank_account1").removeAttr("placeholder");
                $("#bank_name1").removeAttr("placeholder");
                $("#company_faren1").removeAttr("placeholder");
                $("#company_guanxi1").removeAttr("placeholder");
                break;
            default:
                break;
        }
    });

    form.on('select(KP_xingzhi9)', function (data) {
        switch (data.value) {
            case "919":
                $("#nsr9").attr("placeholder", "必填");
                $("#KP_address9").attr("placeholder", "必填");
                $("#KP_tel9").attr("placeholder", "必填");
                $("#bank_account9").attr("placeholder", "必填");
                $("#bank_name9").attr("placeholder", "必填");
                $("#company_faren9").attr("placeholder", "必填");
                $("#company_guanxi9").attr("placeholder", "必填");

                break;
            case "920":
                $("#nsr9").removeAttr("placeholder");
                $("#KP_address9").removeAttr("placeholder");
                $("#KP_tel9").removeAttr("placeholder");
                $("#bank_account9").removeAttr("placeholder");
                $("#bank_name9").removeAttr("placeholder");
                $("#company_faren9").removeAttr("placeholder");
                $("#company_guanxi9").removeAttr("placeholder");
                break;
            default:
                break;
        }
    });


    //根据客户类型加载各自所需的子表信息
    switch (model.KHLX) {
        case 1:

            TableLoad_qudaopinzhongjingpin(khid, 1, 1, 'qudao6', '渠道名称');//渠道load
            TableLoad_area(khid);                 //管辖区域
            TableLoad_partner(model.SAPSN);       //合作伙伴
            TableLoad_contact(khid, 1);           //客户联系人
            TableLoad_post(khid);                 //邮寄地址
            TableLoad_display(khid, 1);              //陈列    
            TableLoad_qiandao(khid);              //签到地址
            //TableLoad_pinciToKH(khid);                //拜访频次
            TableLoad_group(khid);                //分配组
            TableLoad_fujian(khid, 4, "fujian_upload", "附件名称");                 //附件

            break;
        case 2:
            TableLoad_qudaopinzhongjingpin(khid, 1, 1, 'qudao6', '渠道名称');//渠道load
            TableLoad_area(khid);                 //管辖区域
            TableLoad_partner(model.SAPSN);       //合作伙伴
            TableLoad_contact(khid, 1);           //客户联系人
            TableLoad_post(khid);                 //邮寄地址
            TableLoad_display(khid, 1);              //陈列   
            TableLoad_qiandao(khid);              //签到地址
            //TableLoad_pinciToKH(khid);                //拜访频次
            TableLoad_group(khid);                //分配组
            TableLoad_fujian(khid, 4, "fujian_upload", "附件名称");                   //附件
            break;
        case 3:
            //TableLoad_area(khid);             //管辖区域
            //TableLoad_partner(model.SAPSN);   //合作伙伴
            TableLoad_contact(khid, 1);       //客户联系人
            //TableLoad_post(khid);             //邮寄地址
            //TableLoad_display(khid, 1);       //陈列
            TableLoad_qiandao(khid);          //签到地址
            //TableLoad_pinciToKH(khid);                //拜访频次
            TableLoad_group(khid);            //分配组
            TableLoad_fujian(khid, 4, "fujian_upload", "附件名称");              //附件
            break;
        case 4:
            TableLoad_qudaopinzhongjingpin(khid, 1, 1, 'qudao6', '渠道名称');//渠道load
            TableLoad_area(khid);                 //管辖区域
            TableLoad_partner(model.SAPSN);       //合作伙伴
            TableLoad_contact(khid, 1);           //客户联系人
            TableLoad_post(khid);                 //邮寄地址
            TableLoad_display(khid, 1);              //陈列    
            TableLoad_qiandao(khid);              //签到地址
            //TableLoad_pinciToKH(khid);                //拜访频次
            TableLoad_group(khid);                //分配组
            TableLoad_fujian(khid, 4, "fujian_upload", "附件名称");                 //附件
            break;
        case 5:
            TableLoad_wjjl(khid, 3, "mentou4", "门头照片");           //门头照片
            TableLoad_qudaopinzhongjingpin(khid, 2, 1, 'pinzhong6', '销售品种');  //销售品种load
            TableLoad_display(khid, 1);                                    //陈列
            TableLoad_qudaopinzhongjingpin(khid, 3, 1, 'jingpin7', '竞品');   //竞品load
            TableLoad_qiandao(khid);              //签到地址
            //TableLoad_pinciToKH(khid);                //拜访频次
            TableLoad_group(khid);                                         //分配组
            TableLoad_fujian(khid, 4, "fujian_upload", "附件名称");            //附件
            TableLoad_khhd(khid);                 //客户活动
            break;
        case 6:
            TableLoad_wjjl(khid, 3, "mentou4", "门头照片");               //门头照片
            TableLoad_qudaopinzhongjingpin(khid, 2, 1, 'pinzhong6', '销售品种');  //销售品种load
            TableLoad_display(khid, 1);                                      //陈列
            TableLoad_qudaopinzhongjingpin(khid, 3, 1, 'jingpin7', '竞品');   //竞品load
            TableLoad_qiandao(khid);              //签到地址
            //TableLoad_pinciToKH(khid);                //拜访频次
            TableLoad_group(khid);                                             //分配组
            TableLoad_fujian(khid, 4, "fujian_upload", "附件名称");             //附件
            break;
        case 7:

            TableLoad_qudaopinzhongjingpin(khid, 2, 1, 'pinzhong6', '销售品种');  //销售品种load
            TableLoad_display(khid, 1);                                       //陈列
            TableLoad_qudaopinzhongjingpin(khid, 3, 1, 'jingpin7', '竞品');   //竞品load
            TableLoad_qiandao(khid);              //签到地址
            //TableLoad_pinciToKH(khid);                //拜访频次
            TableLoad_group(khid);                                              //分配组
            TableLoad_fujian(khid, 4, "fujian_upload", "附件名称");              //附件
            TableLoad_khhd(khid);                 //客户活动
            if (model.MCSX == 1) {
                TableLoad_contact(khid, 1);           //客户联系人
            }
            else if (model.MCSX == 2) {
                TableLoad_wjjl(khid, 3, "mentou4", "门头照片");                   //门头照片
            }
            break;
        case 8:
            //TableLoad_wjjl(khid, 3, "mentou4", "门头照片");           //门头照片
            TableLoad_qudaopinzhongjingpin(khid, 2, 1, 'pinzhong6', '销售品种');  //销售品种load
            TableLoad_display(khid, 1);                                    //陈列
            TableLoad_qudaopinzhongjingpin(khid, 3, 1, 'jingpin7', '竞品');   //竞品load
            TableLoad_qiandao(khid);              //签到地址
            //TableLoad_pinciToKH(khid);                //拜访频次
            TableLoad_group(khid);                                         //分配组
            TableLoad_fujian(khid, 4, "fujian_upload", "附件名称");            //附件
            TableLoad_songhuo(khid);                 //送货数量
            break;
        case 9:
            TableLoad_area(khid);                 //管辖区域
            TableLoad_partner(model.SAPSN);       //合作伙伴
            TableLoad_contact(khid, 1);           //客户联系人
            TableLoad_post(khid);                 //邮寄地址
            //TableLoad_wjjl(khid, 3, "mentou4", "门头照片");           //门头照片
            TableLoad_qudaopinzhongjingpin(khid, 2, 1, 'pinzhong6', '销售品种');  //销售品种load
            TableLoad_display(khid, 1);                                    //陈列
            TableLoad_qudaopinzhongjingpin(khid, 3, 1, 'jingpin7', '竞品');   //竞品load
            TableLoad_qiandao(khid);              //签到地址
            //TableLoad_pinciToKH(khid);                //拜访频次
            TableLoad_group(khid);                                         //分配组
            TableLoad_fujian(khid, 4, "fujian_upload", "附件名称");            //附件
            TableLoad_zhixiao(khid);              //直销商销售
            TableLoad_WDshuliang(khid);           //网点数量
            TableLoad_chepai(khid);               //车牌
            TableLoad_cuxiao(khid);               //促销单品
            break;
        case 10:
            TableLoad_qudaopinzhongjingpin(khid, 2, 1, 'pinzhong6', '销售品种');  //销售品种load
            TableLoad_qudaopinzhongjingpin(khid, 3, 1, 'jingpin7', '竞品');   //竞品load
            TableLoad_area(khid);                 //管辖区域
            TableLoad_group(khid);                //分配组
            TableLoad_post(khid);                 //邮寄地址
            TableLoad_contact(khid, 1);           //客户联系人
            TableLoad_qiandao(khid);              //签到地址
            //TableLoad_zz(khid, typevalue);                      //资质
            //TableLoad_zhixiao(khid);              //直销商销售
            //TableLoad_WDshuliang(khid);           //网点数量
            //TableLoad_chepai(khid);               //车牌
            //TableLoad_cuxiao(khid);               //促销单品
            TableLoad_khhd(khid);                 //客户活动
            TableLoad_display(khid, 1);                                           //陈列
            TableLoad_wjjl(khid, 3, "mentou4", "门头照片");                   //门头照片
            break;
        case 1105:
            TableLoad_contact(khid, 1);           //客户联系人
            TableLoad_qiandao(khid);              //签到地址
            TableLoad_group(khid);                //分配组

            break;
        case 1106:
            TableLoad_group(khid);                                      //分配组
            TableLoad_wjjl(khid, 3, "mentou4", "门头照片");             //门头照片
            TableLoad_display(khid, 1);                                 //陈列
            TableLoad_qiandao(khid);                                    //签到地址
            TableLoad_wjjl(khid, 10, "tb_battery", "电池照片");             //门头照片
            TableLoad_wjjl(khid, 11, "tb_pack", "包装照片");             //门头照片

            break;
        default:

            break;
    }
    if (model.IsOfficial == 10) {
        TableLoad_xsywjz(khid);
        getDropDownData(41, 0, "jieduan17");
        $("#div_jinzhan").show();
    }
    if (model.KHLX2 == 1064)      //为直销商
    {
        $("#div_chepai").show();
        $("#div_zxry").show();




        TableLoad_zxry(khid);                 //直销人员
        TableLoad_chepai(khid);               //车牌


        if (model.KHLX == 10) {      //中间商转直销商时才有下面这些东西
            $("#div_zhixiaotb").show();
            $("#div_WDshuliang").show();
            $("#div_cuxiao").show();

            getDropDownData(36, 0, "zhixiao_type13");
            getDropDownData(37, 0, "shuliang_type14");
            getDropDownData(38, 0, "DPname16");

            TableLoad_zhixiao(khid);              //直销商销售
            TableLoad_WDshuliang(khid);           //网点数量
            TableLoad_cuxiao(khid);               //促销单品

        }

    }

    var from = sessionStorage.getItem("from");
    sessionStorage.setItem("from", "");
    if (from == "insert") {
        layer.alert("请务必给客户分配权限组！");
        $(".layui-colla-content").removeClass("layui-show");
        $("#div_group_colla").addClass("layui-show");
    }


    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_AllGroup",
        data: {},
        success: function (reslist) {
            var res = JSON.parse(reslist);     //这里data不能直接赋值给tree，要把json里面改成和layui要求的结构一样
            var data = toTree(res);
            data[0].spread = true;
            if (data[0].children != null)
                data[0].children[0].spread = true;
            layui.use('tree', function () {
                //layui.tree({
                //    elem: '#classtree',
                //    nodes: data,
                //    skin: 'shihuang',
                //    //click: function (node) {            //node即为当前点击的节点数据
                //    //    $("#gid").val(node.Id);
                //    //}
                //    click: function (node) {
                //        gid = node.Id;
                //        var $select = $($(this)[0].elem).parents(".layui-form-select");
                //        $select.removeClass("layui-form-selected").find(".layui-select-title span").html(node.name).end().find("input:hidden[name='selectID']").val(node.id);
                //    }
                //});
                var tree = layui.tree;
                var inst1 = tree.render({
                    elem: '#classtree',  //绑定元素
                    data: data,
                    onlyIconControl: true,
                    click: function (obj) {
                        console.log(obj.data); //得到当前点击的节点数据
                        //console.log(obj.state); //得到当前节点的展开状态：open、close、normal
                        //console.log(obj.elem); //得到当前节点元素

                        //console.log(obj.data.children); //当前节点下是否有子节点

                        gid = obj.data.Id;
                        var $select = $($(this)[0].elem).parents(".layui-form-select");
                        $select.removeClass("layui-form-selected").find(".layui-select-title span").html(obj.data.title).end().find("input:hidden[name='selectID']").val(obj.data.Id);

                        //$("span").css('background-color', '');
                        //$("span:contains(" + obj.data.title + ")").css('background-color', '#ffe793');





                    }
                });


            });

        },
        error: function () {
            alert("code1020,请联系管理员");
        }
    });








    //子表跳框

    $("#insert_area").click(function () {
        //$("#action_status").val("insert");
        top.layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '400px'], //宽高
            content: $('#001'),
            btn: ['保存', '取消'],
            title: '新增管辖区域',
            moveOut: true,
            yes: function (index, layero) {

                var mydate = new Date();
                var layer = layui.layer;

                var type = parseInt($("#area_type001").val());
                var name;
                switch (type) {
                    case 1:
                        name = 0;
                        break;
                    case 2:
                        name = parseInt($("#province001").val());
                        break;
                    case 3:
                        name = parseInt($("#city001").val());
                        break;
                    case 4:
                        name = parseInt($("#county001").val());
                        break;
                    default:
                        break;
                }

                var areadata;
                var url;
                url = "../KeHu/Data_Insert_Area";
                areadata = {
                    KHID: khid,
                    GXQYLX: type,
                    GXQYMC: name,
                    BEIZ: $("#remark001").val(),
                    ISACTIVE: 1
                };

                $.ajax({
                    type: "POST",
                    url: url,
                    data: {
                        data: JSON.stringify(areadata)
                    },
                    success: function (sesponseTest) {
                        if (sesponseTest > 0) {
                            TableLoad_area(khid);
                            layer.msg("保存成功！");
                        }
                        else if (sesponseTest == -1) {
                            layer.msg("数据重复！");
                        }
                        else {
                            layer.msg("保存失败");
                        }

                        layer.close(index);
                    },
                    error: function () {
                        alert("code1017,请联系管理员");
                    }
                });

            },
            end: function () {
                $("#area_type001").val("0");
                $("#province001").val("0");
                $("#city001").empty();
                $("#county001").empty();
                $("#remark001").val("");
                $("#001").hide();
                $("#001_2").hide();
                $("#001_3").hide();
                $("#001_5").hide();

                form.render();
            }
        });
        return false;

    });


    $("#insert_contact").click(function () {
        //$("#action_status").val("insert");
        layer.open({
            type: 1,
            shade: 0,
            area: ['1000px', '500px'], //宽高
            content: $("#002"),
            btn: ['保存', '取消'],
            title: '新增客户联系人',
            moveOut: true,
            yes: function (index, layero) {

                var layer = layui.layer;
                if ($("#name002").val() == "") {
                    layer.msg("联系人名称不能为空");
                    return false;
                }
                var pa = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                if ($("#mail002").val() != "" && pa.test($("#mail002").val()) == false) {
                    layer.msg("邮箱格式不正确");
                    return false;
                }

                var disdata;
                var url;
                url = "../KeHu/Data_Insert_Contact";
                disdata = {
                    LB: 1081,
                    KHID: khid,
                    LXR: $("#name002").val(),
                    SEX: $("#sex002").val(),
                    JTDZ: $("#home002").val(),
                    JG: $("#jiguan002").val(),
                    MZ: parseInt($("#nation002").val()),
                    ZW: parseInt($("#job002").val()),
                    AH: $("#hobby002").val(),
                    HYZK: $("#marry002").val(),
                    YDDH: $("#mobtel002").val(),
                    GDDH: $("#tel002").val(),
                    TEL: $("#fax002").val(),
                    EMAIL: $("#mail002").val(),
                    WXH: $("#weixin002").val(),
                    SR: $("#birthday002").val(),
                    TXDZ: $("#address002").val(),
                    YZBM: $("#postalcode002").val(),
                    XGMS: $("#nature002").val(),
                    PHOTO: $("#path").val(),           //图片地址
                    SFZYLXR: $("#major002").val(),
                    BEIZ: $("#remark002").val(),
                    //操作人
                    ISACTIVE: 1
                };

                $.ajax({
                    type: "POST",
                    url: url,
                    data: {
                        data: JSON.stringify(disdata)
                    },
                    success: function (sesponseTest) {
                        if (sesponseTest > 0) {
                            TableLoad_contact(khid, 1);
                            layer.msg("保存成功！");
                        }
                        else if (sesponseTest == -1) {
                            layer.msg("数据重复！");
                        }
                        else {
                            layer.msg("保存失败！");
                        }

                        layer.close(index);
                    },
                    error: function () {
                        alert("code1014,请联系管理员");
                    }
                });

            },
            end: function () {
                $("#name002").val("");
                $("#sex002").val("");
                $("#home002").val("");
                $("#jiguan002").val("");
                $("#nation002").val("0");
                $("#job002").val("0");
                $("#hobby002").val("");
                $("#marry002").val("0");
                $("#mobtel002").val("");
                $("#tel002").val("");
                $("#fax002").val("");
                $("#mail002").val("");
                $("#weixin002").val("");
                $("#birthday002").val("");
                $("#address002").val("");
                $("#postalcode002").val("");
                $("#nature002").val("");
                $("#major002").val("0");
                $("#remark002").val("");
                $("#pic_contact002").attr("src", $("#netpath").val());
                $("#002").hide();

                form.render();
            }
        });
        return false;
    });


    $("#insert_zxry").click(function () {
        //$("#action_status").val("insert");
        layer.open({
            type: 1,
            shade: 0,
            area: ['400px', '400px'], //宽高
            content: $("#002p"),
            btn: ['保存', '取消'],
            title: '新增直销人员',
            moveOut: true,
            yes: function (index, layero) {

                var layer = layui.layer;
                if ($("#name002p").val() == "") {
                    layer.msg("人员名称不能为空");
                    return false;
                }
                if ($("#mobtel002p").val() == "") {
                    layer.msg("联系方式不能为空");
                    return false;
                }
                if ($("#remark002p").val() == "") {
                    layer.msg("工作内容不能为空");
                    return false;
                }

                var disdata;
                var url;
                url = "../KeHu/Data_Insert_Contact";
                disdata = {
                    LB: 1082,
                    KHID: khid,
                    LXR: $("#name002p").val(),
                    YDDH: $("#mobtel002p").val(),
                    BEIZ: $("#remark002p").val(),
                    //操作人
                    ISACTIVE: 1
                };

                $.ajax({
                    type: "POST",
                    url: url,
                    data: {
                        data: JSON.stringify(disdata)
                    },
                    success: function (sesponseTest) {
                        if (sesponseTest > 0) {
                            TableLoad_zxry(khid);
                            layer.msg("保存成功！");
                        }
                        else if (sesponseTest == -1) {
                            layer.msg("数据重复！");
                        }
                        else {
                            layer.msg("保存失败！");
                        }

                        layer.close(index);
                    },
                    error: function () {
                        alert("新增失败,请联系管理员");
                    }
                });

            },
            end: function () {
                $("#name002p").val("");
                $("#mobtel002p").val("");
                $("#remark002p").val("");
                $("#002p").hide();

                form.render();
            }
        });
        return false;
    });


    $("#insert_post").click(function () {
        $("#action_status").val("insert");
        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['500px', '400px'], //宽高
            content: $("#003"),
            title: '新增邮寄地址',
            moveOut: true,
            yes: function (index, layero) {

                var mydate = new Date();
                var layer = layui.layer;
                var postdata;
                var url;
                url = "../KeHu/Data_Insert_QTXX";
                postdata = {
                    KHID: khid,
                    XXLB: 5,
                    KHYJDZ: $("#address003").val(),
                    YB: $("#postalcode003").val(),
                    SJR: $("#name003").val(),
                    SJRLXFS: $("#tel003").val(),
                    //操作人
                    //CZRQ: mydate.toLocaleDateString(),
                    BEIZ: $("#remark003").val(),
                    ISACTIVE: 1
                };


                $.ajax({
                    type: "POST",
                    url: url,
                    data: {
                        data: JSON.stringify(postdata)
                    },
                    success: function (sesponseTest) {
                        if (sesponseTest > 0) {
                            TableLoad_post(khid);
                            layer.msg("保存成功！");
                        }
                        else if (sesponseTest == -1) {
                            layer.msg("数据重复！");
                        }
                        else {
                            layer.msg("保存失败！");
                        }

                        layer.close(index);
                    },
                    error: function () {
                        alert("code1016,请联系管理员");
                    }
                });

            },
            end: function () {
                $("#address003").val("");
                $("#postalcode003").val("");
                $("#name003").val("");
                $("#tel003").val("");
                $("#remark003").val("");
                $("#003").hide();

            }
        });
        return false;
    });


    $("#insert_display").click(function () {
        $("#action_status").val("insert");
        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['500px', '400px'], //宽高
            content: $("#004"),
            title: '新增陈列',
            moveOut: true,
            yes: function (index, layero) {
                if ($("#displayway004").val() == "0") {
                    layer.msg("请输入陈列方式！");
                    return false;
                }
                if (typevalue == 7 && ($("#display_time004").val() == "" || $("#display_endtime004").val() == "")) {
                    layer.msg("请输入陈列归属日期！");
                    return false;
                }


                var mydate = new Date();

                var disdata;
                var url;
                url = "../KeHu/Data_Insert_QTXX";
                disdata = {
                    KHID: khid,
                    XXLB: 4,
                    CLLX: $("#displaytype004").val(),
                    CLFS: $("#displayway004").val(),
                    CLGSRQ: $("#display_time004").val(),
                    CLGSJSRQ: $("#display_endtime004").val(),
                    DISPLAYITEM: $("#displayitem004").val(),
                    //操作人
                    //CZRQ: mydate.toLocaleDateString(),
                    BEIZ: $("#remark004").val(),
                    ISACTIVE: 1
                };


                $.ajax({
                    type: "POST",
                    url: url,
                    data: {
                        data: JSON.stringify(disdata)
                    },
                    success: function (sesponseTest) {
                        if (sesponseTest > 0) {
                            TableLoad_display(khid, 1);
                            layer.msg("保存成功！");
                        }
                        else if (sesponseTest == -1) {
                            layer.msg("数据重复！");
                        }
                        else {
                            layer.msg("保存失败！");
                        }
                        layer.close(index);
                    },
                    error: function () {
                        alert("code1013,请联系管理员");
                    }
                });

            },
            end: function () {
                $("#displaytype004").val("1");
                $("#displayway004").val("0");
                $("#display_time004").val("");
                $("#displayitem004").val("");
                $("#remark004").val("");
                $("#004").hide();

                form.render();
            }
        });
        return false;
    });


    $("#insert_jingpin").click(function () {
        //$("#action_status").val("insert");
        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['350px', '350px'], //宽高
            content: $("#005"),
            title: '新增竞品',
            moveOut: true,
            yes: function (index, layero) {

                SaveBtn_qudao(khid, 3, "jingpin005", 1);
                TableLoad_qudaopinzhongjingpin(khid, 3, 1, 'jingpin7', '竞品');
                layer.close(index);
            },
            end: function () {
                $("#jingpin005").val("0");
                $("#005").hide();

                form.render();
            }
        });
        return false;
    });


    $("#insert_qudao").click(function () {
        //$("#action_status").val("insert");
        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['350px', '350px'], //宽高
            content: $('#006'),
            title: '新增渠道',
            moveOut: true,
            yes: function (index, layero) {

                SaveBtn_qudao(khid, 1, "qudao006", 1);
                TableLoad_qudaopinzhongjingpin(khid, 1, 1, 'qudao6', '渠道名称');
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


    $("#insert_pinzhong").click(function () {
        //$("#action_status").val("insert");
        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['350px', '350px'], //宽高
            content: $('#007'),
            title: '新增销售品种',
            moveOut: true,
            yes: function (index, layero) {

                SaveBtn_qudao(khid, 2, "pinzhong007", 1);
                TableLoad_qudaopinzhongjingpin(khid, 2, 1, 'pinzhong6', '销售品种');
                layer.close(index);
            },
            end: function () {
                $("#pinzhong007").val("0");
                $("#007").hide();

                form.render();
            }
        });
        return false;
    });


    $("#insert_to_group").click(function () {
        //$("#action_status").val("insert");
        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['350px', '450px'], //宽高
            content: $('#008'),
            title: '添加客户到组',
            moveOut: true,
            yes: function (index, layero) {
                var mydate = new Date();
                var layer = layui.layer;

                if ($("#treeclass").text() == "请选择") {
                    layer.msg("请选择客户分组！");
                    return false;
                }



                $.ajax({
                    type: "POST",
                    url: "../KeHu/Data_Insert_Group",
                    data: {
                        KHID: khid,
                        GID: gid
                    },
                    success: function (sesponseTest) {
                        if (sesponseTest > 0) {
                            TableLoad_group(khid);
                            layer.msg("保存成功！");
                        }
                        else
                            layer.msg("客户已经在该分组内了");
                        layer.close(index);
                    },
                    error: function () {
                        alert("code1018,请联系管理员");
                    }
                });

            },
            end: function () {
                $("#treeclass").text("请选择");
                $("#008").hide();

                form.render();
            }
        });
        return false;
    });


    $("#insert_qiandaoDZ").click(function () {
        $("#div_shibie").hide();
        //$("#action_status").val("insert");
        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['500px', '250px'], //宽高
            content: $('#009'),
            title: '新增签到地址',
            moveOut: true,
            yes: function (index, layero) {

                var layer = layui.layer;

                var KQdata = {
                    KHID: khid,
                    DZMS: $("#address009").val(),

                    ED: address_data.result.location.lat,
                    JD: address_data.result.location.lng,
                    //DZRC: 200,
                    ISACTIVE: 1,
                    DWDZMS: $("#shibieAddress009").val()
                };
                $.ajax({
                    type: "POST",
                    url: "../KeHu/Data_Upload_KaoQin",
                    data: {
                        data: JSON.stringify(KQdata),
                        SF: address_data.result.address_components.province,
                        CS: address_data.result.address_components.city,
                    },
                    success: function (res) {
                        if (res > 0) {
                            layer.msg("保存成功！");
                            TableLoad_qiandao(khid);
                        }
                        else if (res == -1)
                            layer.msg("在系统中找不到该地址的省份或城市信息！");
                        else
                            layer.msg("保存失败！");
                        layer.close(index);
                    },
                    error: function () {
                        alert("code1019,请联系管理员");
                    }
                });

            },
            end: function () {
                $("#address009").val("");
                $("#shibieAddress009").val("");
                $("#009").hide();

                form.render();
            }
        });
        return false;
    });


    $("#insert_BFpinci").click(function () {
        $("#div_shibie").hide();
        //$("#action_status").val("insert");
        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['600px', '400px'], //宽高
            content: $('#011'),
            title: '新增拜访频次',
            moveOut: true,
            success: function () {
                TableLoad_pinci(khid);
            }
        });
        return false;
    });


    $("#insert_songhuo").click(function () {
        // $("#action_status").val("insert");
        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['500px', '400px'], //宽高
            content: $("#012"),
            title: '新增送货数量',
            moveOut: true,
            yes: function (index, layero) {

                if ($("#songhuo_cishu012").val() == "") {
                    layer.msg("送货次数不可为空！");
                    return false;
                }
                var reg = /^\+?[1-9][0-9]*$/;
                if (!reg.test($("#songhuo_cishu012").val())) {
                    layer.msg("送货次数必须为全数字");
                    return false;
                }
                if (parseInt($("#songhuo_cishu012").val()) > 50) {
                    layer.msg("送货次数不可大于50");
                    return false;
                }
                if ($("#songhuo_counts012").val() == "") {
                    layer.msg("送货数量不可为空！");
                    return false;
                }
                if ($("#songhuo_time012").val() == "") {
                    layer.msg("送货日期不可为空！");
                    return false;
                }

                var mydate = new Date();
                var disdata;
                var url;
                url = "../KeHu/Data_Insert_XSTJ";
                disdata = {
                    KHID: khid,
                    XSLB: 1,
                    XSMC: $("#songhuo_cishu012").val(),
                    XSSL: $("#songhuo_counts012").val(),
                    GSRQ: $("#songhuo_time012").val(),
                    //操作人
                    //CZRQ: mydate.toLocaleDateString(),
                    BEIZ: $("#remark012").val(),
                    ISACTIVE: 1
                };


                $.ajax({
                    type: "POST",
                    url: url,
                    data: {
                        data: JSON.stringify(disdata)
                    },
                    success: function (sesponseTest) {
                        if (sesponseTest > 0) {
                            TableLoad_songhuo(khid);
                            layer.msg("保存成功！");
                        }
                        else if (sesponseTest == -1) {
                            layer.msg("数据重复！");
                        }
                        else {
                            layer.msg("保存失败！");
                        }
                        layer.close(index);
                    },
                    error: function () {
                        alert("code1013,请联系管理员");
                    }
                });

            },
            end: function () {
                $("#songhuo_cishu012").val("");
                $("#songhuo_counts012").val("");
                $("#songhuo_time012").val("");
                $("#remark012").val("");
                $("#012").hide();

                form.render();
            }
        });
        return false;
    });


    $("#insert_zhixiao").click(function () {
        // $("#action_status").val("insert");
        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['500px', '400px'], //宽高
            content: $("#013"),
            title: '新增直销商销售',
            moveOut: true,
            yes: function (index, layero) {

                var mydate = new Date();
                var layer = layui.layer;
                var disdata;
                var url;
                url = "../KeHu/Data_Insert_XSTJ";
                disdata = {
                    KHID: khid,
                    XSLB: 2,
                    XSMC: $("#zhixiao_type13").find("option:selected").text(),
                    XSJE: $("#zhixiao_howmuch13").val(),
                    GSRQ: $("#zhixiao_year13").val(),
                    //操作人
                    //CZRQ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };


                $.ajax({
                    type: "POST",
                    url: url,
                    data: {
                        data: JSON.stringify(disdata)
                    },
                    success: function (sesponseTest) {
                        if (sesponseTest > 0) {
                            TableLoad_zhixiao(khid);
                            layer.msg("保存成功！");
                        }
                        else if (sesponseTest == -1) {
                            layer.msg("数据重复！");
                        }
                        else {
                            layer.msg("保存失败！");
                        }
                        layer.close(index);
                    },
                    error: function () {
                        alert("系统错误");
                    }
                });

            },
            end: function () {
                $("#zhixiao_type13").val("0");
                $("#zhixiao_howmuch13").val("");
                $("#zhixiao_year13").val("");
                $("#013").hide();

                form.render();
            }
        });
        return false;
    });


    $("#insert_WDshuliang").click(function () {
        // $("#action_status").val("insert");
        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['500px', '400px'], //宽高
            content: $("#014"),
            title: '新增直销商销售',
            moveOut: true,
            yes: function (index, layero) {

                var mydate = new Date();
                var layer = layui.layer;
                var disdata;
                var url;
                url = "../KeHu/Data_Insert_XSTJ";
                disdata = {
                    KHID: khid,
                    XSLB: 3,
                    XSMC: $("#shuliang_type14").find("option:selected").text(),
                    XSSL: $("#shuliang_counts14").val(),
                    GSRQ: $("#shuliang_year14").val(),
                    //操作人
                    //CZRQ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };


                $.ajax({
                    type: "POST",
                    url: url,
                    data: {
                        data: JSON.stringify(disdata)
                    },
                    success: function (sesponseTest) {
                        if (sesponseTest > 0) {
                            TableLoad_WDshuliang(khid);
                            layer.msg("保存成功！");
                        }
                        else if (sesponseTest == -1) {
                            layer.msg("数据重复！");
                        }
                        else {
                            layer.msg("保存失败！");
                        }
                        layer.close(index);
                    },
                    error: function () {
                        alert("系统错误");
                    }
                });

            },
            end: function () {
                $("#shuliang_type14").val("0");
                $("#shuliang_counts14").val("");
                $("#shuliang_year14").val("");
                $("#014").hide();

                form.render();
            }
        });
        return false;
    });


    $("#insert_chepai").click(function () {
        //$("#action_status").val("insert");
        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['500px', '400px'], //宽高
            content: $("#015"),
            title: '新增车牌',
            moveOut: true,
            yes: function (index, layero) {

                var mydate = new Date();
                var layer = layui.layer;
                var postdata;
                var url;
                url = "../KeHu/Data_Insert_QTXX";
                newdata = {
                    KHID: khid,
                    XXLB: 6,
                    XXMC: $("#chepai15").val(),
                    PD: $("#haveAd15").val(),
                    //操作人
                    //CZRQ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };


                $.ajax({
                    type: "POST",
                    url: url,
                    data: {
                        data: JSON.stringify(newdata)
                    },
                    success: function (sesponseTest) {
                        if (sesponseTest > 0) {
                            TableLoad_chepai(khid);
                            layer.msg("保存成功！");
                        }
                        else {
                            layer.msg("保存失败！");
                        }

                        layer.close(index);
                    },
                    error: function () {
                        alert("系统错误");
                    }
                });

            },
            end: function () {
                $("#chepai15").val("");
                $("#haveAd15").val("0");
                $("#015").hide();

            }
        });
        return false;
    });


    $("#insert_cuxiao").click(function () {
        //$("#action_status").val("insert");
        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['500px', '400px'], //宽高
            content: $("#016"),
            title: '新增促销单品',
            moveOut: true,
            yes: function (index, layero) {

                var mydate = new Date();
                var layer = layui.layer;
                var postdata;
                var url;
                url = "../KeHu/Data_Insert_QTXX";
                newdata = {
                    KHID: khid,
                    XXLB: 7,
                    XXMC: $("#DPname16").find("option:selected").text(),
                    PD: $("#ischongdie16").val(),
                    //操作人
                    //CZRQ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };


                $.ajax({
                    type: "POST",
                    url: url,
                    data: {
                        data: JSON.stringify(newdata)
                    },
                    success: function (sesponseTest) {
                        if (sesponseTest > 0) {
                            TableLoad_cuxiao(khid);
                            layer.msg("保存成功！");
                        }
                        else {
                            layer.msg("保存失败！");
                        }

                        layer.close(index);
                    },
                    error: function () {
                        alert("系统错误");
                    }
                });

            },
            end: function () {
                $("#DPname16").val("0");
                $("#ischongdie16").val("0");
                $("#016").hide();

            }
        });
        return false;
    });


    $("#insert_jinzhan").click(function () {
        //$("#action_status").val("insert");
        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['500px', '400px'], //宽高
            content: $("#017"),
            title: '新增销售业务进展',
            moveOut: true,
            yes: function (index, layero) {

                var mydate = new Date();
                var layer = layui.layer;
                var postdata;
                var url;
                url = "../KeHu/Data_Insert_XSYWJZ";
                newdata = {
                    KHID: khid,
                    JZID: $("#jieduan17").val(),
                    INFO1: $("#info17").val(),
                    INFO2: "",
                    INFO3: "",
                    //CZR
                    //CZSJ
                    ISACTIVE: 1,
                    ISDELETE: false,
                    BEIZ: ""

                };


                $.ajax({
                    type: "POST",
                    url: url,
                    data: {
                        data: JSON.stringify(newdata)
                    },
                    success: function (sesponseTest) {
                        if (sesponseTest > 0) {
                            TableLoad_xsywjz(khid);
                            layer.msg("保存成功！");
                        }
                        else {
                            layer.msg("保存失败！");
                        }

                        layer.close(index);
                    },
                    error: function () {
                        alert("系统错误");
                    }
                });

            },
            end: function () {
                $("#jieduan17").val("0");
                $("#info17").val("");
                $("#017").hide();

            }
        });
        return false;
    });


    $("#insert_zz").click(function () {
        //$("#action_status").val("insert");
        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['500px', '400px'], //宽高
            content: $("#div_newzz"),
            title: '新增客户资质',
            moveOut: true,
            yes: function (index, layero) {

                var mydate = new Date();
                var layer = layui.layer;
                var postdata;
                var url;
                url = "../KeHu/Data_Insert_KHZZ";
                newdata = {
                    KHID: khid,
                    ZZMCID: $("#ZZ_type").val(),
                    INFO1: $("#zz_dzs_usenow").val(),
                    INFO2: "",
                    INFO3: "",
                    //CZR: 
                    CZSJ: "",
                    ISACTIVE: 3,
                    //ISDELETE:
                    BEIZ: ""
                };


                $.ajax({
                    type: "POST",
                    url: url,
                    data: {
                        data: JSON.stringify(newdata)
                    },
                    success: function (sesponseTest) {
                        if (sesponseTest > 0) {
                            TableLoad_zz(khid, typevalue);
                            layer.msg("保存成功！");
                        }
                        else {
                            layer.msg("保存失败！");
                        }

                        layer.close(index);
                    },
                    error: function () {
                        alert("系统错误");
                    }
                });

            },
            end: function () {
                $("#ZZ_type").val("0");
                $("#zz_dzs_usenow").val("");
                $("#div_newzz").hide();

            }
        });
        return false;
    });


    $("#insert_hd").click(function () {
        //$("#action_status").val("insert");
        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['500px', '400px'], //宽高
            content: $("#div_newhd"),
            title: '新增客户活动',
            skin: 'select_out',
            moveOut: true,
            yes: function (index, layero) {
                if ($("#HDname").val() == "0") {
                    layer.msg("请选择活动名称");
                    return false;
                }
                if ($("#HDname").val() != 1076) {
                    if ($("#HDtc").val() == 0) {
                        layer.msg("请选择活动套餐");
                        return false;
                    }
                    //if ($("#HDcplx").val() == "0") {
                    //    layer.msg("请选择产品类型");
                    //    return false;
                    //}
                    //if ($("#HDxl").val() == "") {
                    //    layer.msg("请输入销量");
                    //    return false;
                    //}
                    //var reg = /^\+?[1-9][0-9]*$/;
                    //if (!reg.test($("#HDxl").val()) && $("#HDxl").val() != "") {
                    //    layer.msg("销量必须为全数字");
                    //    return false;
                    //}
                }
                if ($("#HDname").val() == 4166) {
                    var reg = /^\+?[1-9][0-9]*$/;
                    if (!reg.test($("#HDxl").val())) {
                        layer.msg("送活动数量必须为全数字");
                        return false;
                    }
                }


                var mydate = new Date();

                var newdata;
                newdata = {
                    KHID: khid,
                    HDMC: $("#HDname").val(),
                    HDTC: $("#HDtc").val(),
                    CPLX: $("#HDcplx").val(),
                    XL: $("#HDxl").val(),
                    HDCL: $("#HDdisplay").val(),
                    BEIZ: $("#HDbeiz").val(),
                    //CZR: 
                    CZSJ: "",
                    ISACTIVE: 1
                };
                $.ajax({
                    type: "POST",
                    url: "../KeHu/Data_Insert_KHHD",
                    data: {
                        data: JSON.stringify(newdata)
                    },
                    success: function (sesponseTest) {
                        if (sesponseTest > 0) {
                            TableLoad_khhd(khid);
                            layer.msg("保存成功！");
                        }
                        else {
                            layer.msg("保存失败！");
                        }

                        layer.close(index);
                    },
                    error: function () {
                        alert("系统错误");
                    }
                });



            },
            end: function () {
                $("#HDname").val("0");
                $("#HDtc").val("0");
                $("#HDcplx").val("0");
                $("#HDxl").val("");
                $("#HDdisplay").val(0);
                $("#HDbeiz").val("");
                $("#div_newhd").hide();
                $("#div_hdcl").hide();
                form.render();
            }
        });
        return false;
    });




    $("#turn_official").click(function () {


        $.ajax({
            type: "POST",
            async: false,
            url: "../KeHu/Data_TurnKH_Official",
            data: {
                CRMID: model.CRMID
            },
            success: function (res) {

                if (res == -1) {
                    layer.alert("客户的最终阶段为合同才可以转正");
                }
                else if (res != 0) {
                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '提交成功！',
                        btn: '确定',
                        yes: function (index, layero) {
                            window.location.reload();

                        }
                    });
                }
                else {
                    layer.alert("客户转正的过程中出现问题，请联系管理员");
                }

            },
            error: function () {
                alert("系统错误");
            }
        });


    });


    //保存基本信息
    $("#btn_save_only").click(function () {

        var typevalue = parseInt($("#Insert_KHtype").val());
        //var id = parseInt($("#CRMid1").val());
        //var name = $("#name1").val();
        var data;
        var zzdata = [];
        //经销商、电商、B2B
        if (typevalue == 1 || typevalue == 2 || typevalue == 4) {
            if ($("#name1").val() == "") {
                layer.msg("客户名称不可为空");
                return false;
            }
            if ($("#Insert_KHXZ").val() != "10") {
                if ($("#company_lxr1").val() == "") {
                    layer.msg("公司联系人不可为空");
                    return false;
                }
                if ($("#company_tel1").val() == "") {
                    layer.msg("公司联系电话不可为空");
                    return false;
                }
                if ($("#KP_xingzhi1").val() == "0") {
                    layer.msg("开票性质不可为空");
                    return false;
                }

                if ($("#KP_xingzhi1").val() == "919") {
                    if ($("#company_faren1").val() == "") {
                        layer.msg("法人不可为空");
                        return false;
                    }
                    if ($("#KP_address1").val() == "") {
                        layer.msg("开票地址不可为空");
                        return false;
                    }
                    if ($("#KP_tel1").val() == "") {
                        layer.msg("开票电话不可为空");
                        return false;
                    }
                    if ($("#nsr1").val() == "") {
                        layer.msg("纳税人识别号不可为空");
                        return false;
                    }
                    if ($("#bank_account1").val() == "") {
                        layer.msg("银行帐号不可为空");
                        return false;
                    }
                    if ($("#bank_name1").val() == "") {
                        layer.msg("银行名称不可为空");
                        return false;
                    }
                    if ($("#company_guanxi1").val() == "") {
                        layer.msg("联系人与法人关系不可为空");
                        return false;
                    }
                }
                if (typevalue == 1) {
                    if ($("#source1").val() == "0") {
                        layer.msg("经销商来源不可为空");
                        return false;
                    }
                    if ($("#khjs1").val() == "") {
                        layer.msg("客户介绍不可为空");
                        return false;
                    }
                    if ($("#Atypeamount1").val() == "") {
                        layer.msg("首批订单A类产品订货金额不可为空");
                        return false;
                    }
                    if ($("#mission1").val() == "") {
                        layer.msg("合同销售任务不可为空");
                        return false;
                    }
                    if ($("#JXmission1").val() == "") {
                        layer.msg("A类产品销售任务不可为空");
                        return false;
                    }

                    if ($("#xs_explain1").val() == "") {
                        layer.msg("销售归属不可为空");
                        return false;
                    }
                    if ($("#fl_explain1").val() == "") {
                        layer.msg("返利归属不可为空");
                        return false;
                    }
                }

                if ($("#sfccj1").val() == "0" && $("#price_content").val() == "") {
                    layer.msg("请对价格进行说明");
                    return false;
                }
                if ($("#haveeffect1").val() == "1" && $("#effect_content").val() == "") {
                    layer.msg("请对经销商的影响进行说明");
                    return false;
                }
            }


            var sfccj;
            var jxsyx;
            if ($("#sfccj1").val() == "1")
                sfccj = true;
            else
                sfccj = false;
            if ($("#haveeffect1").val() == "1")
                jxsyx = true;
            else
                jxsyx = false;

            var pkhid;
            if ($("#up_id1").val() != "")
                pkhid = $("#up_id1").val();
            else
                pkhid = 0;

            data = {
                KHID: khid,
                PKHID: pkhid,
                SAPSN: $("#sapsn1").val(),
                CRMID: $("#CRMid1").val(),
                KHLX: typevalue,
                MC: $("#name1").val(),
                JC: $("#jc1").val(),
                GSLXR: $("#company_lxr1").val(),
                GSLXDH: $("#company_tel1").val(),
                FR: $("#company_faren1").val(),
                GSFRGX: $("#company_guanxi1").val(),
                NSRSBH: $("#nsr1").val(),
                KDJSDZ: $("#KD_address1").val(),
                KDLXR: $("#KD_staff1").val(),
                KDLXDH: $("#KD_tel1").val(),
                KPDZ: $("#KP_address1").val(),
                KPXZ: parseInt($("#KP_xingzhi1").val()),
                KPDH: $("#KP_tel1").val(),
                HTXSRW: $("#mission1").val(),
                HTJXXSRW: $("#JXmission1").val(),
                YHZH: $("#bank_account1").val(),
                YHMC: $("#bank_name1").val(),
                XSSJSM: $("#data_explain1").val(),
                FLSJSM: $("#fl_explain1").val(),
                SFCCJ: sfccj,
                SFCCJSM: $("#price_content").val(),
                KHSHDZ: $("#receive_address1").val(),
                KHSHLXR: $("#receive_staff1").val(),
                KHSHLXDH: $("#receive_tel1").val(),
                TSQKSM: $("#situation_explain1").val(),
                JXSYX: jxsyx,
                YXSM: $("#effect_content").val(),
                SF: model.SF,
                CS: model.CS,
                KHSOURCE: $("#source1").val(),
                KHLX2: 0,
                KHJS: $("#khjs1").val(),
                FIRSTAMOUNT: $("#Atypeamount1").val(),
                JOINACTIVITY: $("#joinactivity1").val(),

                MDDZ: $("#address10").val(),
                PP: $("#pp10").val(),
                PPOWNER: $("#owner10").val(),
                FACTORY: $("#factory10").val(),
                BEIZ: $("#remark10").val(),

                SFZXS: model.SFZXS,
                SFBZWD: model.SFBZWD,
                MCSX: model.MCSX,
                SAPKHLX: 1,
                ISACTIVE: model.ISACTIVE,
                FID: model.FID,
                IsOfficial: model.IsOfficial
            };
            if (typevalue == 1)
                data.KHLX2 = $("#iszxs1").val();
            else if (typevalue == 4) {
                data.KHLX2 = $("#KH2type10").val();
                data.MCLC = $("#industrytype1").val();
            }

        }
            //直营卖场
        else if (typevalue == 3) {
            var maichang_type = $("#type_maichang2").val();
            //直营卖场系统
            if (maichang_type == "1") {
                if ($("#name2").val() == "") {
                    layer.msg("客户名称不可为空");
                    return false;
                }
                if ($("#Insert_KHXZ").val() != "10") {
                    if ($("#type_maichang2").val() == "0") {
                        layer.msg("卖场类型不可为空");
                        return false;
                    }
                    if ($("#company_lxr2").val() == "") {
                        layer.msg("公司联系人不可为空");
                        return false;
                    }
                    if ($("#company_tel2").val() == "") {
                        layer.msg("公司联系电话不可为空");
                        return false;
                    }

                    //if ($("#KP_xingzhi2").val() == "0") {
                    //    layer.msg("开票性质不可为空");
                    //    return false;
                    //}


                    if ($("#FK_tiaojian2").val() == "") {
                        layer.msg("付款条件不可为空");
                        return false;
                    }
                }

                var pkhid;
                if ($("#up_id2").val() != "")
                    pkhid = $("#up_id2").val();
                else
                    pkhid = 0;

                data = {
                    KHID: khid,
                    CRMID: $("#CRMid1").val(),
                    SAPSN: $("#sapsn2").val(),
                    KHLX: typevalue,
                    PKHID: pkhid,
                    MC: $("#name2").val(),
                    JC: $("#jc2").val(),
                    MCSX: 1,
                    GSLXR: $("#company_lxr2").val(),
                    GSLXDH: $("#company_tel2").val(),
                    FR: $("#company_faren2").val(),
                    NSRSBH: $("#nsr2").val(),
                    KDJSDZ: $("#KD_address2").val(),
                    KDLXR: $("#KD_staff2").val(),
                    KDLXDH: $("#KD_tel2").val(),
                    KPDZ: $("#KP_address2").val(),
                    KPXZ: parseInt($("#KP_xingzhi2").val()),
                    KPDH: $("#KP_tel2").val(),
                    YHZH: $("#bank_account2").val(),
                    YHMC: $("#bank_name2").val(),
                    FKTJ: $("#FK_tiaojian2").val(),
                    SF: parseInt($("#province2").val()),
                    CS: parseInt($("#city2").val()),
                    COUNTY: parseInt($("#county2").val()),

                    SFCCJ: model.SFCCJ,
                    JXSYX: model.JXSYX,
                    SFZXS: model.SFZXS,
                    SFBZWD: model.SFBZWD,
                    SAPKHLX: 1,
                    ISACTIVE: model.ISACTIVE,
                    FID: model.FID,
                    IsOfficial: model.IsOfficial
                };



            }
                //直营卖场门店
            else if (maichang_type == "2") {
                if ($("#name2p").val() == "") {
                    layer.msg("客户名称不可为空");
                    return false;
                }
                if ($("#up_name2p").val() == "") {
                    layer.msg("上级客户名称不可为空");
                    return false;
                }



                data = {
                    KHID: khid,
                    CRMID: $("#CRMid1").val(),
                    SAPSN: $("#sapsn2p").val(),
                    KHLX: typevalue,
                    PKHID: parseInt($("#up_id2p").val()),
                    MC: $("#name2p").val(),
                    JC: $("#jc2p").val(),
                    MCSX: 2,
                    //GSLXR: $("#company_lxr2").val(),
                    //GSLXDH: $("#company_tel2").val(),
                    //FR: $("#company_faren2").val(),
                    //NSRSBH: $("#nsr2").val(),
                    //KDJSDZ: $("#KD_address2").val(),
                    //KDLXR: $("#KD_staff2").val(),
                    //KDLXDH: $("#KD_tel2").val(),
                    //KPDZ: $("#KP_address2").val(),
                    //KPXZ: parseInt($("#KP_xingzhi2").val()),
                    //KPDH: $("#KP_tel2").val(),
                    //YHZH: $("#bank_account2").val(),
                    //YHMC: $("#bank_name2").val(),
                    //FKTJ: $("#FK_tiaojian2").val(),

                    KHSHDZ: $("#SH_address2p").val(),
                    KHSHLXR: $("#SH_staff2p").val(),
                    KHSHLXDH: $("#SH_tel2p").val(),
                    BEIZ: $("#code2p").val(),
                    SF: parseInt($("#province2p").val()),
                    CS: parseInt($("#city2p").val()),
                    COUNTY: parseInt($("#county2p").val()),
                    GC: $("#gc2p").val(),
                    KCDD: $("#kcdd2p").val(),

                    SFCCJ: model.SFCCJ,
                    JXSYX: model.JXSYX,
                    SFZXS: model.SFZXS,
                    SFBZWD: model.SFBZWD,
                    SAPKHLX: 1,
                    ISACTIVE: model.ISACTIVE,
                    FID: model.FID,
                    IsOfficial: model.IsOfficial
                };


            }




        }
            //终端网点、批发
        else if (typevalue == 5 || typevalue == 6) {
            if ($("#name4").val() == "") {
                layer.msg("主控网点名称不可为空");
                return false;
            }
            if ($("#Insert_KHXZ").val() != "10") {
                if ($("#province4").val() == "0") {
                    layer.msg("省份不可为空");
                    return false;
                }
                if ($("#city4").val() == "0") {
                    layer.msg("城市不可为空");
                    return false;
                }

                if ($("#jxs_id4").val() == "") {
                    layer.msg("经销商名称不可为空");
                    return false;
                }
                if ($("#lxr4").val() == "") {
                    layer.msg("联系人不可为空");
                    return false;
                }
                if ($("#tel4").val() == "") {
                    layer.msg("联系电话不可为空");
                    return false;
                }
                if ($("#address4").val() == "") {
                    layer.msg("地址不可为空");
                    return false;
                }
                if ($("#type_wangdian4").val() == "0") {
                    layer.msg("网点类型不可为空");
                    return false;
                }
                if ($("#kfsj4").val() == "") {
                    layer.msg("客户开发时间不可为空");
                    return false;
                }
            }
            if ($("#is_yx4").val() == "1") {
                if ($("#xl4").val() == "") {
                    layer.msg("有效网点销量不可为空");
                    return false;
                }
            }
            if ($("#is_dzs4").val() == "1") {
                if ($("#type_wangdian4").val() == "12" || $("#type_wangdian4").val() == "13" || $("#type_wangdian4").val() == "14") {
                    layer.msg("电子锁客户的网点类型有问题，请修改！");
                    return false;
                }
            }

            var sfzxs;
            var sfbzwd;
            if ($("#is_zxs4").val() == "1")
                sfzxs = true;
            else
                sfzxs = false;
            if ($("#is_bzwd4").val() == "1")
                sfbzwd = true;
            else
                sfbzwd = false;

            var pkhid;
            if ($("#jxs_id4").val() != "")
                pkhid = $("#jxs_id4").val();
            else
                pkhid = 0;


            data = {
                KHID: khid,
                CRMID: $("#CRMid1").val(),
                KHLX: typevalue,
                //FID: $("#staff4").val(),
                SF: parseInt($("#province4").val()),
                CS: parseInt($("#city4").val()),
                PKHID: pkhid,
                MC: $("#name4").val(),
                JC: $("#jc4").val(),
                MDDZ: $("#address4").val(),
                GSLXR: $("#lxr4").val(),
                GSLXDH: $("#tel4").val(),
                WDLX: parseInt($("#type_wangdian4").val()),
                SFZXS: sfzxs,
                SFBZWD: sfbzwd,
                BEIZ: $("#remark4").val(),
                KHZZSJ: $("#kfsj4").val(),

                SFCCJ: model.SFCCJ,
                JXSYX: model.JXSYX,
                MCSX: model.MCSX,
                SAPKHLX: 1,
                ISACTIVE: model.ISACTIVE,
                FID: model.FID,
                IsOfficial: model.IsOfficial

            };
            var arr;
            if ($("#is_yx4").val() == "1") {
                arr = {
                    ZZMCID: 1080,
                    INFO1: $("#xl4").val(),
                    INFO2: $("#sm4").val(),
                    INFO3: "",
                    ISACTIVE: 3,
                    CZSJ: "",
                    BEIZ: ""
                };
                zzdata.push(arr);
            }
            if ($("#is_dzs4").val() == "1") {
                arr = {
                    ZZMCID: 1058,
                    INFO1: $("#xypp4").val(),
                    INFO2: "",
                    INFO3: "",
                    ISACTIVE: 3,
                    CZSJ: "",
                    BEIZ: ""
                };
                zzdata.push(arr);
            }

        }
            //LKA
        else if (typevalue == 7) {
            var LKA_type = $("#Insert_LKAtype").val();
            //LKA系统
            if (LKA_type == "1") {
                if ($("#name5").val() == "") {
                    layer.msg("卖场名称不可为空");
                    return false;
                }
                if ($("#Insert_KHXZ").val() != "10") {
                    if ($("#jxs_id5").val() == "") {
                        layer.msg("经销商名称不可为空");
                        return false;
                    }

                    if ($("#store_jcsl5").val() == "") {
                        layer.msg("门店进场数量不可为空");
                        return false;
                    }
                    if ($("#address5").val() == "") {
                        layer.msg("卖场总部地址不可为空");
                        return false;
                    }
                    //if ($("#maichang_type5").val() == "0") {
                    //    layer.msg("卖场类型不可为空");
                    //    return false;
                    //}
                    if ($("#kfsj5").val() == "") {
                        layer.msg("客户开发时间不可为空");
                        return false;
                    }

                    if ($("#firsttime5").val() == "") {
                        layer.msg("首次进场时间不可为空");
                        return false;
                    }
                    if ($("#psqk5").val() == "") {
                        layer.msg("配送情况不可为空");
                        return false;
                    }
                    if ($("#aoe5").val() == "") {
                        layer.msg("辐射范围不可为空");
                        return false;
                    }
                    if ($("#manageway5").val() == 0) {
                        layer.msg("经营方式不可为空");
                        return false;
                    }
                    if ($("#payway5").val() == 0) {
                        layer.msg("结款方式不可为空");
                        return false;
                    }
                    if ($("#jqr5").val() == "") {
                        layer.msg("卖场接洽人不可为空");
                        return false;
                    }
                    if ($("#jqrzw5").val() == 0) {
                        layer.msg("接洽人职务不可为空");
                        return false;
                    }
                    if ($("#jqrdh5").val() == "") {
                        layer.msg("接洽人电话不可为空");
                        return false;
                    }
                    if ($("#website5").val() == "") {
                        layer.msg("卖场网址不可为空");
                        return false;
                    }
                    if ($("#account5").val() == "") {
                        layer.msg("帐号、密码不可为空");
                        return false;
                    }

                }
                if ($("#is_yx5").val() == "1") {
                    if ($("#xl5").val() == "") {
                        layer.msg("有效网点销量不可为空");
                        return false;
                    }
                }

                var pkhid;
                if ($("#jxs_id5").val() != "")
                    pkhid = $("#jxs_id5").val();
                else
                    pkhid = 0;

                data = {
                    KHID: khid,
                    CRMID: $("#CRMid1").val(),
                    KHLX: typevalue,
                    PKHID: pkhid,
                    MC: $("#maichang_name5").val(),
                    JC: $("#jc5").val(),
                    MDJCSL: $("#store_jcsl5").val(),
                    MCSX: "1",
                    MDDZ: $("#address5").val(),
                    BEIZ: $("#remark5").val(),
                    SF: model.SF,
                    CS: model.CS,
                    KHZZSJ: $("#kfsj5").val(),
                    FIRSTTIME: $("#firsttime5").val(),
                    PSQK: $("#psqk5").val(),
                    FSFW: $("#aoe5").val(),
                    MANAGEWAY: $("#manageway5").val(),
                    PAYWAY: $("#payway5").val(),
                    GSLXR: $("#jqr5").val(),
                    GSLXRZW: $("#jqrzw5").val(),
                    GSLXDH: $("#jqrdh5").val(),
                    SUPPORTOTHER: $("#supportother5").val(),
                    ISNEW: $("#isnew5").val(),
                    PACT: $("#pact5").val(),
                    BELONGKA: $("#belongka5").val(),
                    WEBSITE: $("#website5").val(),
                    ACCOUNT: $("#account5").val(),
                    YYZT: $("#yyzt5").val(),
                    GDSJ: $("#gdsj5").val(),


                    SFCCJ: model.SFCCJ,
                    JXSYX: model.JXSYX,
                    SFZXS: model.SFZXS,
                    SFBZWD: model.SFBZWD,
                    SAPKHLX: 1,
                    ISACTIVE: model.ISACTIVE,
                    FID: model.FID,
                    IsOfficial: model.IsOfficial
                };
                var arr;
                if ($("#is_yx5").val() == "1") {
                    arr = {
                        ZZMCID: 1080,
                        INFO1: $("#xl5").val(),
                        INFO2: $("#sm5").val(),
                        INFO3: "",
                        ISACTIVE: 3,
                        CZSJ: "",
                        BEIZ: ""
                    };
                    zzdata.push(arr);
                }

            }
                //LKA网点
            else if (LKA_type == "2") {
                if ($("#name5p").val() == "") {
                    layer.msg("门店名称不可为空");
                    return false;
                }
                if ($("#maichang_name5p").val() == "") {
                    layer.msg("卖场名称不可为空");
                    return false;
                }
                if ($("#Insert_KHXZ").val() != "10") {


                    if ($("#address5p").val() == "") {
                        layer.msg("门店地址不可为空");
                        return false;
                    }
                    if ($("#jcdpsl5p").val() == "") {
                        layer.msg("进场单品数量不可为空");
                        return false;
                    }
                    if ($("#kfsj5p").val() == "") {
                        layer.msg("客户开发时间不可为空");
                        return false;
                    }
                }
                if ($("#is_yx5p").val() == "1") {
                    if ($("#xl5p").val() == "") {
                        layer.msg("有效网点销量不可为空");
                        return false;
                    }
                }

                var pkhid;
                if ($("#maichang_id5p").val() != "")
                    pkhid = $("#maichang_id5p").val();
                else
                    pkhid = 0;

                data = {
                    KHID: khid,
                    CRMID: $("#CRMid1").val(),
                    KHLX: typevalue,
                    PKHID: pkhid,
                    MC: $("#store_name5p").val(),
                    JC: $("#jc5p").val(),
                    MCSX: 2,
                    XSSJSM: $("#maichang_pinzhong5p").val(),
                    MCLC: $("#maichang_type5p").val(),
                    MDDZ: $("#address5p").val(),
                    JCDPSL: $("#jcdpsl5p").val(),
                    BEIZ: $("#remark5p").val(),
                    SF: model.SF,
                    CS: model.CS,
                    KHZZSJ: $("#kfsj5p").val(),
                    YYZT: $("#yyzt5p").val(),
                    GDSJ: $("#gdsj5p").val(),

                    SFCCJ: model.SFCCJ,
                    JXSYX: model.JXSYX,
                    SFZXS: model.SFZXS,
                    SFBZWD: model.SFBZWD,
                    SAPKHLX: 1,
                    ISACTIVE: model.ISACTIVE,
                    FID: model.FID,
                    IsOfficial: model.IsOfficial
                };
                var arr;
                if ($("#is_yx5p").val() == "1") {
                    arr = {
                        ZZMCID: 1080,
                        INFO1: $("#xl5p").val(),
                        INFO2: $("#sm5p").val(),
                        INFO3: "",
                        ISACTIVE: 3,
                        CZSJ: "",
                        BEIZ: ""
                    };
                    zzdata.push(arr);
                }

            }
            else {
                layer.msg("code1008,请联系管理员");
                return false;
            }






        }
        else if (typevalue == 8) {

            if ($("#name7").val() == "") {
                layer.msg("网点名称不可为空");
                return false;
            }
            if ($("#Insert_KHXZ").val() != "10") {
                if ($("#jxs_name7").val() == "") {
                    layer.msg("经销商名称不可为空");
                    return false;
                }
                if ($("#jxs_id7").val() == "") {
                    layer.msg("经销商名称不可为空");
                    return false;
                }
            }


            data = {
                KHID: khid,
                CRMID: $("#CRMid1").val(),
                KHLX: typevalue,
                PKHID: $("#jxs_id7").val(),
                SF: $("#province7").val(),
                CS: $("#city7").val(),
                MC: $("#name7").val(),
                JC: $("#jc7").val(),
                MDDZ: $("#address7").val(),
                GSLXR: $("#lxr7").val(),
                GSLXDH: $("#tel7").val(),
                WDLX: $("#type_wangdian7").val(),
                TSQKSM: $("#use_now7").val(),
                BEIZ: $("#remark7").val(),

                SFCCJ: model.SFCCJ,
                JXSYX: model.JXSYX,
                MCSX: model.MCSX,
                SAPKHLX: model.SAPKHLX,
                ISACTIVE: model.ISACTIVE,
                FID: model.FID,
                IsOfficial: model.IsOfficial
            };

        }
        else if (typevalue == 9) {

            if ($("#name6").val() == "") {
                layer.msg("客户名称不可为空");
                return false;
            }
            var pkhid = 0;
            if ($("#jxs_id6").val() != "")
                pkhid = parseInt($("#jxs_id6").val());
            data = {
                KHID: khid,
                CRMID: $("#CRMid1").val(),
                KHLX: typevalue,
                PKHID: pkhid,
                SF: $("#province6").val(),
                CS: $("#city6").val(),
                MC: $("#name6").val(),
                JC: $("#jc6").val(),
                MDDZ: $("#address6").val(),
                GSLXR: $("#lxr6").val(),
                GSLXDH: $("#tel6").val(),
                BEIZ: $("#remark6").val(),

                SFCCJ: model.SFCCJ,
                JXSYX: model.JXSYX,
                WDLX: model.WDLX,
                MCSX: model.MCSX,
                SAPKHLX: model.SAPKHLX,
                ISACTIVE: model.ISACTIVE,
                FID: model.FID,
                IsOfficial: model.IsOfficial
            };

        }
        else if (typevalue == 10) {
            if ($("#name8").val() == "") {
                layer.msg("客户名称不可为空");
                return false;
            }

            if ($("#Insert_KHXZ").val() != "10") {

                if ($("#type_zjs8").val() == "0") {
                    layer.msg("中间商类型不可为空");
                    return false;
                }

                if ($("#kfsj8").val() == "") {
                    layer.msg("客户开发时间不可为空");
                    return false;
                }
            }
            if ($("#is_yx8").val() == "1") {
                if ($("#xl8").val() == "") {
                    layer.msg("有效网点销量不可为空");
                    return false;
                }
            }

            var pkhid = 0;
            if ($("#jxs_id8").val() != "")
                pkhid = parseInt($("#jxs_id8").val());

            data = {
                KHID: khid,
                CRMID: $("#CRMid1").val(),
                KHLX: typevalue,
                PKHID: pkhid,
                SF: $("#province8").val(),
                CS: $("#city8").val(),
                MC: $("#name8").val(),
                JC: $("#jc8").val(),
                MDDZ: $("#address8").val(),
                KHLX2: parseInt($("#type_zjs8").val()),
                GSLXR: $("#lxr8").val(),
                GSLXDH: $("#tel8").val(),
                BEIZ: $("#remark8").val(),
                KHZZSJ: $("#kfsj8").val(),

                SFCCJ: model.SFCCJ,
                JXSYX: model.JXSYX,
                MCSX: 0,
                SAPKHLX: 1,
                ISACTIVE: 1,
                FID: model.FID,
                IsOfficial: model.IsOfficial
            };
            var arr;
            if ($("#is_yx8").val() == "1") {
                arr = {
                    ZZMCID: 1080,
                    INFO1: $("#xl8").val(),
                    INFO2: $("#sm8").val(),
                    INFO3: "",
                    ISACTIVE: 3,
                    CZSJ: "",
                    BEIZ: ""
                };
                zzdata.push(arr);
            }
        }
        else if (typevalue == 1105) {
            if ($("#name9").val() == "") {
                layer.msg("客户名称不可为空");
                return false;
            }
            if ($("#Insert_KHXZ").val() != "10") {

                if ($("#company_lxr9").val() == "") {
                    layer.msg("公司联系人不可为空");
                    return false;
                }
                if ($("#company_tel9").val() == "") {
                    layer.msg("公司联系电话不可为空");
                    return false;
                }
                if ($("#KP_xingzhi9").val() == "0") {
                    layer.msg("开票性质不可为空");
                    return false;
                }

                if ($("#KP_xingzhi9").val() == "919") {
                    if ($("#company_faren9").val() == "") {
                        layer.msg("法人不可为空");
                        return false;
                    }
                    if ($("#KP_address9").val() == "") {
                        layer.msg("开票地址不可为空");
                        return false;
                    }
                    if ($("#KP_tel9").val() == "") {
                        layer.msg("开票电话不可为空");
                        return false;
                    }
                    if ($("#nsr9").val() == "") {
                        layer.msg("纳税人识别号不可为空");
                        return false;
                    }
                    if ($("#bank_account9").val() == "") {
                        layer.msg("银行帐号不可为空");
                        return false;
                    }
                    if ($("#bank_name9").val() == "") {
                        layer.msg("银行名称不可为空");
                        return false;
                    }
                    if ($("#company_guanxi9").val() == "") {
                        layer.msg("联系人与法人关系不可为空");
                        return false;
                    }
                }


            }

            var pkhid;
            if ($("#up_id9").val() != "")
                pkhid = $("#up_id9").val();
            else
                pkhid = 0;

            data = {
                KHID: khid,
                KHLX: typevalue,
                CRMID: $("#CRMid1").val(),
                PKHID: pkhid,
                SAPSN: $("#sapsn9").val(),
                MC: $("#name9").val(),
                JC: $("#jc9").val(),
                GSLXR: $("#company_lxr9").val(),
                GSLXDH: $("#company_tel9").val(),
                FR: $("#company_faren9").val(),
                GSFRGX: $("#company_guanxi9").val(),
                NSRSBH: $("#nsr9").val(),
                KDJSDZ: $("#KD_address9").val(),
                KDLXR: $("#KD_staff9").val(),
                KDLXDH: $("#KD_tel9").val(),
                KPDZ: $("#KP_address9").val(),
                KPXZ: parseInt($("#KP_xingzhi9").val()),
                KPDH: $("#KP_tel9").val(),
                YHZH: $("#bank_account9").val(),
                YHMC: $("#bank_name9").val(),


                SFZXS: model.SFZXS,
                SFBZWD: model.SFBZWD,
                MCSX: model.MCSX,
                SAPKHLX: 1,
                ISACTIVE: model.ISACTIVE,
                FID: model.FID,
                IsOfficial: model.IsOfficial
            };
        }
        else if (typevalue == 1106) {
            if ($("#name10").val() == "") {
                layer.msg("店名名称不可为空");
                return false;
            }
            if ($("#KH2type10").val() == 0) {
                layer.msg("请选择大客户类型");
                return false;
            }
            data = {
                KHID: khid,
                KHLX: typevalue,
                KHLX2: $("#KH2type10").val(),
                CRMID: $("#CRMid1").val(),
                MC: $("#name10").val(),
                MDDZ: $("#address10").val(),
                PP: $("#pp10").val(),
                PPOWNER: $("#owner10").val(),
                FACTORY: $("#factory10").val(),
                BEIZ: $("#remark10").val(),


                SFZXS: model.SFZXS,
                SFBZWD: model.SFBZWD,
                MCSX: model.MCSX,
                SAPKHLX: 1,
                ISACTIVE: model.ISACTIVE,
                FID: model.FID,
                IsOfficial: model.IsOfficial
            };
        }
        else {
            layer.msg("找不到对应的客户类型,请联系管理员");
            return false;
        }

        $.ajax({
            type: "POST",
            url: "../KeHu/Data_Update",
            data: {
                data: JSON.stringify(data),
                zzdata: JSON.stringify(zzdata)
            },
            success: function (res) {
                if (res == -10) {
                    layer.msg("请给客户分配分组！");
                    return false;
                }
                else if (res == -11) {
                    layer.msg("请输入客户活动信息！");
                    return false;
                }
                else if (res > 0) {


                    //window.location.href = "../KeHu/Update?tv=" + typevalue;

                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '修改成功',
                        btn: '确定',
                        yes: function (index, layero) {

                            window.location.reload();
                            layer.close(index);
                        },
                        end: function (index, layero) {

                            window.location.reload();
                            layer.close(index);
                        }
                    });
                }
                else {
                    layer.msg("修改失败！");
                    return false;
                }
            },
            error: function () {
                alert("修改失败,请联系管理员");
            }
        });



    });


    $("#btn_save_only_submit").click(function () {


        var typevalue = parseInt($("#Insert_KHtype").val());
        //var id = parseInt($("#CRMid1").val());
        //var name = $("#name1").val();
        var data;
        var zzdata = [];
        //经销商、电商、B2B
        if (typevalue == 1 || typevalue == 2 || typevalue == 4) {
            if ($("#name1").val() == "") {
                layer.msg("客户名称不可为空");
                return false;
            }
            if ($("#Insert_KHXZ").val() != "10") {
                if ($("#company_lxr1").val() == "") {
                    layer.msg("公司联系人不可为空");
                    return false;
                }
                if ($("#company_tel1").val() == "") {
                    layer.msg("公司联系电话不可为空");
                    return false;
                }
                if ($("#KP_xingzhi1").val() == "0") {
                    layer.msg("开票性质不可为空");
                    return false;
                }

                if ($("#KP_xingzhi1").val() == "919") {
                    if ($("#company_faren1").val() == "") {
                        layer.msg("法人不可为空");
                        return false;
                    }
                    if ($("#KP_address1").val() == "") {
                        layer.msg("开票地址不可为空");
                        return false;
                    }
                    if ($("#KP_tel1").val() == "") {
                        layer.msg("开票电话不可为空");
                        return false;
                    }
                    if ($("#nsr1").val() == "") {
                        layer.msg("纳税人识别号不可为空");
                        return false;
                    }
                    if ($("#bank_account1").val() == "") {
                        layer.msg("银行帐号不可为空");
                        return false;
                    }
                    if ($("#bank_name1").val() == "") {
                        layer.msg("银行名称不可为空");
                        return false;
                    }
                    if ($("#company_guanxi1").val() == "") {
                        layer.msg("联系人与法人关系不可为空");
                        return false;
                    }
                }
                if (typevalue == 1) {
                    if ($("#source1").val() == "0") {
                        layer.msg("经销商来源不可为空");
                        return false;
                    }
                    if ($("#khjs1").val() == "") {
                        layer.msg("客户介绍不可为空");
                        return false;
                    }
                    if ($("#Atypeamount1").val() == "") {
                        layer.msg("首批订单A类产品订货金额不可为空");
                        return false;
                    }
                    if ($("#mission1").val() == "") {
                        layer.msg("合同销售任务不可为空");
                        return false;
                    }
                    if ($("#JXmission1").val() == "") {
                        layer.msg("A类产品销售任务不可为空");
                        return false;
                    }

                    if ($("#xs_explain1").val() == "") {
                        layer.msg("销售归属不可为空");
                        return false;
                    }
                    if ($("#fl_explain1").val() == "") {
                        layer.msg("返利归属不可为空");
                        return false;
                    }
                }

                if ($("#sfccj1").val() == "0" && $("#price_content").val() == "") {
                    layer.msg("请对价格进行说明");
                    return false;
                }
                if ($("#haveeffect1").val() == "1" && $("#effect_content").val() == "") {
                    layer.msg("请对经销商的影响进行说明");
                    return false;
                }
            }


            var sfccj;
            var jxsyx;
            if ($("#sfccj1").val() == "1")
                sfccj = true;
            else
                sfccj = false;
            if ($("#haveeffect1").val() == "1")
                jxsyx = true;
            else
                jxsyx = false;

            var pkhid;
            if ($("#up_id1").val() != "")
                pkhid = $("#up_id1").val();
            else
                pkhid = 0;

            data = {
                KHID: khid,
                PKHID: pkhid,
                SAPSN: $("#sapsn1").val(),
                CRMID: $("#CRMid1").val(),
                KHLX: typevalue,
                MC: $("#name1").val(),
                JC: $("#jc1").val(),
                GSLXR: $("#company_lxr1").val(),
                GSLXDH: $("#company_tel1").val(),
                FR: $("#company_faren1").val(),
                GSFRGX: $("#company_guanxi1").val(),
                NSRSBH: $("#nsr1").val(),
                KDJSDZ: $("#KD_address1").val(),
                KDLXR: $("#KD_staff1").val(),
                KDLXDH: $("#KD_tel1").val(),
                KPDZ: $("#KP_address1").val(),
                KPXZ: parseInt($("#KP_xingzhi1").val()),
                KPDH: $("#KP_tel1").val(),
                HTXSRW: $("#mission1").val(),
                HTJXXSRW: $("#JXmission1").val(),
                YHZH: $("#bank_account1").val(),
                YHMC: $("#bank_name1").val(),
                XSSJSM: $("#data_explain1").val(),
                FLSJSM: $("#fl_explain1").val(),
                SFCCJ: sfccj,
                SFCCJSM: $("#price_content").val(),
                KHSHDZ: $("#receive_address1").val(),
                KHSHLXR: $("#receive_staff1").val(),
                KHSHLXDH: $("#receive_tel1").val(),
                TSQKSM: $("#situation_explain1").val(),
                JXSYX: jxsyx,
                YXSM: $("#effect_content").val(),
                SF: model.SF,
                CS: model.CS,
                KHSOURCE: $("#source1").val(),
                KHLX2: 0,
                KHJS: $("#khjs1").val(),
                FIRSTAMOUNT: $("#Atypeamount1").val(),
                JOINACTIVITY: $("#joinactivity1").val(),

                MDDZ: $("#address10").val(),
                PP: $("#pp10").val(),
                PPOWNER: $("#owner10").val(),
                FACTORY: $("#factory10").val(),
                BEIZ: $("#remark10").val(),

                SFZXS: model.SFZXS,
                SFBZWD: model.SFBZWD,
                MCSX: model.MCSX,
                SAPKHLX: 1,
                ISACTIVE: model.ISACTIVE,
                FID: model.FID,
                IsOfficial: model.IsOfficial
            };
            if (typevalue == 1)
                data.KHLX2 = $("#iszxs1").val();
            else if (typevalue == 4) {
                data.KHLX2 = $("#KH2type10").val();
                data.MCLC = $("#industrytype1").val();
            }

        }
            //直营卖场
        else if (typevalue == 3) {
            var maichang_type = $("#type_maichang2").val();
            //直营卖场系统
            if (maichang_type == "1") {
                if ($("#name2").val() == "") {
                    layer.msg("客户名称不可为空");
                    return false;
                }
                if ($("#Insert_KHXZ").val() != "10") {
                    if ($("#type_maichang2").val() == "0") {
                        layer.msg("卖场类型不可为空");
                        return false;
                    }
                    if ($("#company_lxr2").val() == "") {
                        layer.msg("公司联系人不可为空");
                        return false;
                    }
                    if ($("#company_tel2").val() == "") {
                        layer.msg("公司联系电话不可为空");
                        return false;
                    }

                    //if ($("#KP_xingzhi2").val() == "0") {
                    //    layer.msg("开票性质不可为空");
                    //    return false;
                    //}


                    if ($("#FK_tiaojian2").val() == "") {
                        layer.msg("付款条件不可为空");
                        return false;
                    }
                }

                var pkhid;
                if ($("#up_id2").val() != "")
                    pkhid = $("#up_id2").val();
                else
                    pkhid = 0;

                data = {
                    KHID: khid,
                    CRMID: $("#CRMid1").val(),
                    SAPSN: $("#sapsn2").val(),
                    KHLX: typevalue,
                    PKHID: pkhid,
                    MC: $("#name2").val(),
                    JC: $("#jc2").val(),
                    MCSX: 1,
                    GSLXR: $("#company_lxr2").val(),
                    GSLXDH: $("#company_tel2").val(),
                    FR: $("#company_faren2").val(),
                    NSRSBH: $("#nsr2").val(),
                    KDJSDZ: $("#KD_address2").val(),
                    KDLXR: $("#KD_staff2").val(),
                    KDLXDH: $("#KD_tel2").val(),
                    KPDZ: $("#KP_address2").val(),
                    KPXZ: parseInt($("#KP_xingzhi2").val()),
                    KPDH: $("#KP_tel2").val(),
                    YHZH: $("#bank_account2").val(),
                    YHMC: $("#bank_name2").val(),
                    FKTJ: $("#FK_tiaojian2").val(),
                    SF: parseInt($("#province2").val()),
                    CS: parseInt($("#city2").val()),
                    COUNTY: parseInt($("#county2").val()),

                    SFCCJ: model.SFCCJ,
                    JXSYX: model.JXSYX,
                    SFZXS: model.SFZXS,
                    SFBZWD: model.SFBZWD,
                    SAPKHLX: 1,
                    ISACTIVE: model.ISACTIVE,
                    FID: model.FID,
                    IsOfficial: model.IsOfficial
                };



            }
                //直营卖场门店
            else if (maichang_type == "2") {
                if ($("#name2p").val() == "") {
                    layer.msg("客户名称不可为空");
                    return false;
                }
                if ($("#up_name2p").val() == "") {
                    layer.msg("上级客户名称不可为空");
                    return false;
                }



                data = {
                    KHID: khid,
                    CRMID: $("#CRMid1").val(),
                    SAPSN: $("#sapsn2p").val(),
                    KHLX: typevalue,
                    PKHID: parseInt($("#up_id2p").val()),
                    MC: $("#name2p").val(),
                    JC: $("#jc2p").val(),
                    MCSX: 2,
                    //GSLXR: $("#company_lxr2").val(),
                    //GSLXDH: $("#company_tel2").val(),
                    //FR: $("#company_faren2").val(),
                    //NSRSBH: $("#nsr2").val(),
                    //KDJSDZ: $("#KD_address2").val(),
                    //KDLXR: $("#KD_staff2").val(),
                    //KDLXDH: $("#KD_tel2").val(),
                    //KPDZ: $("#KP_address2").val(),
                    //KPXZ: parseInt($("#KP_xingzhi2").val()),
                    //KPDH: $("#KP_tel2").val(),
                    //YHZH: $("#bank_account2").val(),
                    //YHMC: $("#bank_name2").val(),
                    //FKTJ: $("#FK_tiaojian2").val(),

                    KHSHDZ: $("#SH_address2p").val(),
                    KHSHLXR: $("#SH_staff2p").val(),
                    KHSHLXDH: $("#SH_tel2p").val(),
                    BEIZ: $("#code2p").val(),
                    SF: parseInt($("#province2p").val()),
                    CS: parseInt($("#city2p").val()),
                    COUNTY: parseInt($("#county2p").val()),

                    SFCCJ: model.SFCCJ,
                    JXSYX: model.JXSYX,
                    SFZXS: model.SFZXS,
                    SFBZWD: model.SFBZWD,
                    SAPKHLX: 1,
                    ISACTIVE: model.ISACTIVE,
                    FID: model.FID,
                    IsOfficial: model.IsOfficial
                };


            }




        }
            //终端网点、批发
        else if (typevalue == 5 || typevalue == 6) {
            if ($("#name4").val() == "") {
                layer.msg("主控网点名称不可为空");
                return false;
            }
            if ($("#Insert_KHXZ").val() != "10") {
                if ($("#province4").val() == "0") {
                    layer.msg("省份不可为空");
                    return false;
                }
                if ($("#city4").val() == "0") {
                    layer.msg("城市不可为空");
                    return false;
                }

                if ($("#jxs_id4").val() == "") {
                    layer.msg("经销商名称不可为空");
                    return false;
                }
                if ($("#lxr4").val() == "") {
                    layer.msg("联系人不可为空");
                    return false;
                }
                if ($("#tel4").val() == "") {
                    layer.msg("联系电话不可为空");
                    return false;
                }
                if ($("#address4").val() == "") {
                    layer.msg("地址不可为空");
                    return false;
                }
                if ($("#type_wangdian4").val() == "0") {
                    layer.msg("网点类型不可为空");
                    return false;
                }
                if ($("#kfsj4").val() == "") {
                    layer.msg("客户开发时间不可为空");
                    return false;
                }
            }
            if ($("#is_yx4").val() == "1") {
                if ($("#xl4").val() == "") {
                    layer.msg("有效网点销量不可为空");
                    return false;
                }
            }
            if ($("#is_dzs4").val() == "1") {
                if ($("#type_wangdian4").val() == "12" || $("#type_wangdian4").val() == "13" || $("#type_wangdian4").val() == "14") {
                    layer.msg("电子锁客户的网点类型有问题，请修改！");
                    return false;
                }
            }

            var sfzxs;
            var sfbzwd;
            if ($("#is_zxs4").val() == "1")
                sfzxs = true;
            else
                sfzxs = false;
            if ($("#is_bzwd4").val() == "1")
                sfbzwd = true;
            else
                sfbzwd = false;

            var pkhid;
            if ($("#jxs_id4").val() != "")
                pkhid = $("#jxs_id4").val();
            else
                pkhid = 0;


            data = {
                KHID: khid,
                CRMID: $("#CRMid1").val(),
                KHLX: typevalue,
                //FID: $("#staff4").val(),
                SF: parseInt($("#province4").val()),
                CS: parseInt($("#city4").val()),
                PKHID: pkhid,
                MC: $("#name4").val(),
                JC: $("#jc4").val(),
                MDDZ: $("#address4").val(),
                GSLXR: $("#lxr4").val(),
                GSLXDH: $("#tel4").val(),
                WDLX: parseInt($("#type_wangdian4").val()),
                SFZXS: sfzxs,
                SFBZWD: sfbzwd,
                BEIZ: $("#remark4").val(),
                KHZZSJ: $("#kfsj4").val(),

                SFCCJ: model.SFCCJ,
                JXSYX: model.JXSYX,
                MCSX: model.MCSX,
                SAPKHLX: 1,
                ISACTIVE: model.ISACTIVE,
                FID: model.FID,
                IsOfficial: model.IsOfficial

            };
            var arr;
            if ($("#is_yx4").val() == "1") {
                arr = {
                    ZZMCID: 1080,
                    INFO1: $("#xl4").val(),
                    INFO2: $("#sm4").val(),
                    INFO3: "",
                    ISACTIVE: 3,
                    CZSJ: "",
                    BEIZ: ""
                };
                zzdata.push(arr);
            }
            if ($("#is_dzs4").val() == "1") {
                arr = {
                    ZZMCID: 1058,
                    INFO1: $("#xypp4").val(),
                    INFO2: "",
                    INFO3: "",
                    ISACTIVE: 3,
                    CZSJ: "",
                    BEIZ: ""
                };
                zzdata.push(arr);
            }

        }
            //LKA
        else if (typevalue == 7) {
            var LKA_type = $("#Insert_LKAtype").val();
            //LKA系统
            if (LKA_type == "1") {
                if ($("#name5").val() == "") {
                    layer.msg("卖场名称不可为空");
                    return false;
                }
                if ($("#Insert_KHXZ").val() != "10") {
                    if ($("#jxs_id5").val() == "") {
                        layer.msg("经销商名称不可为空");
                        return false;
                    }

                    if ($("#store_jcsl5").val() == "") {
                        layer.msg("门店进场数量不可为空");
                        return false;
                    }
                    if ($("#address5").val() == "") {
                        layer.msg("卖场总部地址不可为空");
                        return false;
                    }
                    //if ($("#maichang_type5").val() == "0") {
                    //    layer.msg("卖场类型不可为空");
                    //    return false;
                    //}
                    if ($("#kfsj5").val() == "") {
                        layer.msg("客户开发时间不可为空");
                        return false;
                    }

                    if ($("#firsttime5").val() == "") {
                        layer.msg("首次进场时间不可为空");
                        return false;
                    }
                    if ($("#psqk5").val() == "") {
                        layer.msg("配送情况不可为空");
                        return false;
                    }
                    if ($("#aoe5").val() == "") {
                        layer.msg("辐射范围不可为空");
                        return false;
                    }
                    if ($("#manageway5").val() == 0) {
                        layer.msg("经营方式不可为空");
                        return false;
                    }
                    if ($("#payway5").val() == 0) {
                        layer.msg("结款方式不可为空");
                        return false;
                    }
                    if ($("#jqr5").val() == "") {
                        layer.msg("卖场接洽人不可为空");
                        return false;
                    }
                    if ($("#jqrzw5").val() == 0) {
                        layer.msg("接洽人职务不可为空");
                        return false;
                    }
                    if ($("#jqrdh5").val() == "") {
                        layer.msg("接洽人电话不可为空");
                        return false;
                    }
                    if ($("#website5").val() == "") {
                        layer.msg("卖场网址不可为空");
                        return false;
                    }
                    if ($("#account5").val() == "") {
                        layer.msg("帐号、密码不可为空");
                        return false;
                    }

                }
                if ($("#is_yx5").val() == "1") {
                    if ($("#xl5").val() == "") {
                        layer.msg("有效网点销量不可为空");
                        return false;
                    }
                }

                var pkhid;
                if ($("#jxs_id5").val() != "")
                    pkhid = $("#jxs_id5").val();
                else
                    pkhid = 0;

                data = {
                    KHID: khid,
                    CRMID: $("#CRMid1").val(),
                    KHLX: typevalue,
                    PKHID: pkhid,
                    MC: $("#maichang_name5").val(),
                    JC: $("#jc5").val(),
                    MDJCSL: $("#store_jcsl5").val(),
                    MCSX: "1",
                    MDDZ: $("#address5").val(),
                    BEIZ: $("#remark5").val(),
                    SF: model.SF,
                    CS: model.CS,
                    KHZZSJ: $("#kfsj5").val(),
                    FIRSTTIME: $("#firsttime5").val(),
                    PSQK: $("#psqk5").val(),
                    FSFW: $("#aoe5").val(),
                    MANAGEWAY: $("#manageway5").val(),
                    PAYWAY: $("#payway5").val(),
                    GSLXR: $("#jqr5").val(),
                    GSLXRZW: $("#jqrzw5").val(),
                    GSLXDH: $("#jqrdh5").val(),
                    SUPPORTOTHER: $("#supportother5").val(),
                    ISNEW: $("#isnew5").val(),
                    PACT: $("#pact5").val(),
                    BELONGKA: $("#belongka5").val(),
                    WEBSITE: $("#website5").val(),
                    ACCOUNT: $("#account5").val(),


                    SFCCJ: model.SFCCJ,
                    JXSYX: model.JXSYX,
                    SFZXS: model.SFZXS,
                    SFBZWD: model.SFBZWD,
                    SAPKHLX: 1,
                    ISACTIVE: model.ISACTIVE,
                    FID: model.FID,
                    IsOfficial: model.IsOfficial
                };
                var arr;
                if ($("#is_yx5").val() == "1") {
                    arr = {
                        ZZMCID: 1080,
                        INFO1: $("#xl5").val(),
                        INFO2: $("#sm5").val(),
                        INFO3: "",
                        ISACTIVE: 3,
                        CZSJ: "",
                        BEIZ: ""
                    };
                    zzdata.push(arr);
                }

            }
                //LKA网点
            else if (LKA_type == "2") {
                if ($("#name5p").val() == "") {
                    layer.msg("门店名称不可为空");
                    return false;
                }
                if ($("#maichang_name5p").val() == "") {
                    layer.msg("卖场名称不可为空");
                    return false;
                }
                if ($("#Insert_KHXZ").val() != "10") {


                    if ($("#address5p").val() == "") {
                        layer.msg("门店地址不可为空");
                        return false;
                    }
                    if ($("#jcdpsl5p").val() == "") {
                        layer.msg("进场单品数量不可为空");
                        return false;
                    }
                    if ($("#kfsj5p").val() == "") {
                        layer.msg("客户开发时间不可为空");
                        return false;
                    }
                }
                if ($("#is_yx5p").val() == "1") {
                    if ($("#xl5p").val() == "") {
                        layer.msg("有效网点销量不可为空");
                        return false;
                    }
                }

                var pkhid;
                if ($("#maichang_id5p").val() != "")
                    pkhid = $("#maichang_id5p").val();
                else
                    pkhid = 0;

                data = {
                    KHID: khid,
                    CRMID: $("#CRMid1").val(),
                    KHLX: typevalue,
                    PKHID: pkhid,
                    MC: $("#store_name5p").val(),
                    JC: $("#jc5p").val(),
                    MCSX: 2,
                    XSSJSM: $("#maichang_pinzhong5p").val(),
                    MCLC: $("#maichang_type5p").val(),
                    MDDZ: $("#address5p").val(),
                    JCDPSL: $("#jcdpsl5p").val(),
                    BEIZ: $("#remark5p").val(),
                    SF: model.SF,
                    CS: model.CS,
                    KHZZSJ: $("#kfsj5p").val(),

                    SFCCJ: model.SFCCJ,
                    JXSYX: model.JXSYX,
                    SFZXS: model.SFZXS,
                    SFBZWD: model.SFBZWD,
                    SAPKHLX: 1,
                    ISACTIVE: model.ISACTIVE,
                    FID: model.FID,
                    IsOfficial: model.IsOfficial
                };
                var arr;
                if ($("#is_yx5p").val() == "1") {
                    arr = {
                        ZZMCID: 1080,
                        INFO1: $("#xl5p").val(),
                        INFO2: $("#sm5p").val(),
                        INFO3: "",
                        ISACTIVE: 3,
                        CZSJ: "",
                        BEIZ: ""
                    };
                    zzdata.push(arr);
                }

            }
            else {
                layer.msg("code1008,请联系管理员");
                return false;
            }






        }
        else if (typevalue == 8) {

            if ($("#name7").val() == "") {
                layer.msg("网点名称不可为空");
                return false;
            }
            if ($("#Insert_KHXZ").val() != "10") {
                if ($("#jxs_name7").val() == "") {
                    layer.msg("经销商名称不可为空");
                    return false;
                }
                if ($("#jxs_id7").val() == "") {
                    layer.msg("经销商名称不可为空");
                    return false;
                }
            }


            data = {
                KHID: khid,
                CRMID: $("#CRMid1").val(),
                KHLX: typevalue,
                PKHID: $("#jxs_id7").val(),
                SF: $("#province7").val(),
                CS: $("#city7").val(),
                MC: $("#name7").val(),
                JC: $("#jc7").val(),
                MDDZ: $("#address7").val(),
                GSLXR: $("#lxr7").val(),
                GSLXDH: $("#tel7").val(),
                WDLX: $("#type_wangdian7").val(),
                TSQKSM: $("#use_now7").val(),
                BEIZ: $("#remark7").val(),

                SFCCJ: model.SFCCJ,
                JXSYX: model.JXSYX,
                MCSX: model.MCSX,
                SAPKHLX: model.SAPKHLX,
                ISACTIVE: model.ISACTIVE,
                FID: model.FID,
                IsOfficial: model.IsOfficial
            };

        }
        else if (typevalue == 9) {

            if ($("#name6").val() == "") {
                layer.msg("客户名称不可为空");
                return false;
            }
            var pkhid = 0;
            if ($("#jxs_id6").val() != "")
                pkhid = parseInt($("#jxs_id6").val());
            data = {
                KHID: khid,
                CRMID: $("#CRMid1").val(),
                KHLX: typevalue,
                PKHID: pkhid,
                SF: $("#province6").val(),
                CS: $("#city6").val(),
                MC: $("#name6").val(),
                JC: $("#jc6").val(),
                MDDZ: $("#address6").val(),
                GSLXR: $("#lxr6").val(),
                GSLXDH: $("#tel6").val(),
                BEIZ: $("#remark6").val(),

                SFCCJ: model.SFCCJ,
                JXSYX: model.JXSYX,
                WDLX: model.WDLX,
                MCSX: model.MCSX,
                SAPKHLX: model.SAPKHLX,
                ISACTIVE: model.ISACTIVE,
                FID: model.FID,
                IsOfficial: model.IsOfficial
            };

        }
        else if (typevalue == 10) {
            if ($("#name8").val() == "") {
                layer.msg("客户名称不可为空");
                return false;
            }

            if ($("#Insert_KHXZ").val() != "10") {

                if ($("#type_zjs8").val() == "0") {
                    layer.msg("中间商类型不可为空");
                    return false;
                }

                if ($("#kfsj8").val() == "") {
                    layer.msg("客户开发时间不可为空");
                    return false;
                }
            }
            if ($("#is_yx8").val() == "1") {
                if ($("#xl8").val() == "") {
                    layer.msg("有效网点销量不可为空");
                    return false;
                }
            }

            var pkhid = 0;
            if ($("#jxs_id8").val() != "")
                pkhid = parseInt($("#jxs_id8").val());

            data = {
                KHID: khid,
                CRMID: $("#CRMid1").val(),
                KHLX: typevalue,
                PKHID: pkhid,
                SF: $("#province8").val(),
                CS: $("#city8").val(),
                MC: $("#name8").val(),
                JC: $("#jc8").val(),
                MDDZ: $("#address8").val(),
                KHLX2: parseInt($("#type_zjs8").val()),
                GSLXR: $("#lxr8").val(),
                GSLXDH: $("#tel8").val(),
                BEIZ: $("#remark8").val(),
                KHZZSJ: $("#kfsj8").val(),

                SFCCJ: model.SFCCJ,
                JXSYX: model.JXSYX,
                MCSX: 0,
                SAPKHLX: 1,
                ISACTIVE: 1,
                FID: model.FID,
                IsOfficial: model.IsOfficial
            };
            var arr;
            if ($("#is_yx8").val() == "1") {
                arr = {
                    ZZMCID: 1080,
                    INFO1: $("#xl8").val(),
                    INFO2: $("#sm8").val(),
                    INFO3: "",
                    ISACTIVE: 3,
                    CZSJ: "",
                    BEIZ: ""
                };
                zzdata.push(arr);
            }
        }
        else if (typevalue == 1105) {
            if ($("#name9").val() == "") {
                layer.msg("客户名称不可为空");
                return false;
            }
            if ($("#Insert_KHXZ").val() != "10") {

                if ($("#company_lxr9").val() == "") {
                    layer.msg("公司联系人不可为空");
                    return false;
                }
                if ($("#company_tel9").val() == "") {
                    layer.msg("公司联系电话不可为空");
                    return false;
                }
                if ($("#KP_xingzhi9").val() == "0") {
                    layer.msg("开票性质不可为空");
                    return false;
                }

                if ($("#KP_xingzhi9").val() == "919") {
                    if ($("#company_faren9").val() == "") {
                        layer.msg("法人不可为空");
                        return false;
                    }
                    if ($("#KP_address9").val() == "") {
                        layer.msg("开票地址不可为空");
                        return false;
                    }
                    if ($("#KP_tel9").val() == "") {
                        layer.msg("开票电话不可为空");
                        return false;
                    }
                    if ($("#nsr9").val() == "") {
                        layer.msg("纳税人识别号不可为空");
                        return false;
                    }
                    if ($("#bank_account9").val() == "") {
                        layer.msg("银行帐号不可为空");
                        return false;
                    }
                    if ($("#bank_name9").val() == "") {
                        layer.msg("银行名称不可为空");
                        return false;
                    }
                    if ($("#company_guanxi9").val() == "") {
                        layer.msg("联系人与法人关系不可为空");
                        return false;
                    }
                }


            }

            var pkhid;
            if ($("#up_id9").val() != "")
                pkhid = $("#up_id9").val();
            else
                pkhid = 0;

            data = {
                KHID: khid,
                KHLX: typevalue,
                CRMID: $("#CRMid1").val(),
                PKHID: pkhid,
                SAPSN: $("#sapsn9").val(),
                MC: $("#name9").val(),
                JC: $("#jc9").val(),
                GSLXR: $("#company_lxr9").val(),
                GSLXDH: $("#company_tel9").val(),
                FR: $("#company_faren9").val(),
                GSFRGX: $("#company_guanxi9").val(),
                NSRSBH: $("#nsr9").val(),
                KDJSDZ: $("#KD_address9").val(),
                KDLXR: $("#KD_staff9").val(),
                KDLXDH: $("#KD_tel9").val(),
                KPDZ: $("#KP_address9").val(),
                KPXZ: parseInt($("#KP_xingzhi9").val()),
                KPDH: $("#KP_tel9").val(),
                YHZH: $("#bank_account9").val(),
                YHMC: $("#bank_name9").val(),


                SFZXS: model.SFZXS,
                SFBZWD: model.SFBZWD,
                MCSX: model.MCSX,
                SAPKHLX: 1,
                ISACTIVE: model.ISACTIVE,
                FID: model.FID,
                IsOfficial: model.IsOfficial
            };
        }
        else if (typevalue == 1106) {
            if ($("#name10").val() == "") {
                layer.msg("店名名称不可为空");
                return false;
            }
            if ($("#KH2type10").val() == 0) {
                layer.msg("请选择大客户类型");
                return false;
            }
            data = {
                KHID: khid,
                KHLX: typevalue,
                KHLX2: $("#KH2type10").val(),
                CRMID: $("#CRMid1").val(),
                MC: $("#name10").val(),
                MDDZ: $("#address10").val(),
                PP: $("#pp10").val(),
                PPOWNER: $("#owner10").val(),
                FACTORY: $("#factory10").val(),
                BEIZ: $("#remark10").val(),


                SFZXS: model.SFZXS,
                SFBZWD: model.SFBZWD,
                MCSX: model.MCSX,
                SAPKHLX: 1,
                ISACTIVE: model.ISACTIVE,
                FID: model.FID,
                IsOfficial: model.IsOfficial
            };
        }
        else {
            layer.msg("找不到对应的客户类型,请联系管理员");
            return false;
        }

        layer.open({
            title: '提示',
            type: 0,
            content: '确定提交？',
            btn: ['确定', '取消'],
            yes: function (index, layero) {
                $.ajax({
                    type: "POST",
                    url: "../KeHu/Data_UpdateKH_Submit",
                    data: {
                        data: JSON.stringify(data),
                        zzdata: JSON.stringify(zzdata)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        layer.open({
                            title: '提示',
                            type: 0,
                            content: res.Value,
                            btn: '确定',
                            yes: function (index, layero) {
                                if (res.Key > 0)
                                    window.location.reload();
                                layer.close(index);
                            },
                            end: function (index, layero) {

                                //window.location.reload();
                                layer.close(index);
                            }
                        });
                    },
                    error: function () {
                        alert("修改失败,请联系管理员");
                    }
                });
                layer.close(index);
            },
            end: function (index, layero) {

                layer.close(index);
            }
        });





    });




    //签到地址
    $("#btn_confirm009").click(function () {


        $.ajax({
            type: "POST",
            url: "../KeHu/Data_AddressToLocation",
            data: {
                address: $("#address009").val()
            },
            success: function (res) {
                address_data = JSON.parse(res);
                if (res == null || res == "") {
                    layer.msg("获取定位失败");
                }
                else {
                    var sfcs;
                    if (address_data.result.address_components.province == address_data.result.address_components.city) {
                        sfcs = address_data.result.address_components.province;
                    }
                    else {
                        sfcs = address_data.result.address_components.province + address_data.result.address_components.city;
                    }
                    $("#shibieAddress009").val(sfcs + address_data.result.title);
                    $("#div_shibie").show();
                }


            },
            error: function () {
                alert("code1020,请联系管理员");
            }
        });

    });







    layui.use(['form', 'layer', 'element', 'table', 'laydate', 'upload'], function () {
        var form = layui.form;
        var element = layui.element;
        var table = layui.table;
        var layer = layui.layer;
        form.render();
        var index_befo;
        var laydate = layui.laydate;

        var $ = layui.jquery;

        $(".downpanel").on("click", ".layui-select-title", function (e) {
            $(".layui-form-select").not($(this).parents(".layui-form-select")).removeClass("layui-form-selected");
            $(this).parents(".downpanel").toggleClass("layui-form-selected");
            layui.stope(e);
        }).on("click", "dl i", function (e) {
            layui.stope(e);
        });
        //$(document).on("click", function (e) {
        //    $(".layui-form-select").removeClass("layui-form-selected");
        //});

        laydate.render({
            elem: '#birthday002'
        });

        laydate.render({
            elem: '#display_time004'
        });

        laydate.render({
            elem: '#display_endtime004'
        });

        laydate.render({
            elem: '#songhuo_time012'
        });

        laydate.render({
            elem: '#zhixiao_year13',
            type: 'year'
        });

        laydate.render({
            elem: '#shuliang_year14',
            type: 'year'
        });

        laydate.render({
            elem: '#kfsj4'
        });

        laydate.render({
            elem: '#kfsj8'
        });

        laydate.render({
            elem: '#kfsj5'
        });

        laydate.render({
            elem: '#firsttime5'
        });

        laydate.render({
            elem: '#kfsj5p'
        });

        laydate.render({
            elem: '#gdsj5'
        });

        laydate.render({
            elem: '#gdsj5p'
        });


        var upload = layui.upload;

        //执行实例
        upload.render({
            elem: '#btn_upload_display', //绑定元素
            method: 'post',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var disID = parseInt($("#displayID").val());
                var loaddata = {
                    GSDX: 2,
                    GSDXID: disID,
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: disID,
                    data: JSON.stringify(loaddata)
                }

            },
            done: function (res) {
                //上传完毕回调


                var disID = parseInt($("#displayID").val());
                TableLoad_wjjl(disID, 2, "pic_display004", "陈列照片");
                TableLoad_display(khid, 1);
                layer.msg("成功");
                layer.close(index_befo);
            },
            error: function () {
                //请求异常回调
                layer.msg("上传失败");
                layer.close(index_befo);
            }
        });




        upload.render({
            elem: '#pic_contact002', //绑定元素
            method: 'post',
            url: '../KeHu/Data_Insert_ContacImg', //上传接口
            //data: { KHID: khid },
            before: function () {

                index_befo = layer.load();
                this.data = {
                    KHID: khid
                }

            },
            done: function (res, index, upload) {
                //上传完毕回调
                layer.msg("成功");
                $("#path").val(res.locapath);


                $("#pic_contact002").attr("src", res.res);
                layer.close(index_befo);
            },
            error: function () {
                //请求异常回调
                layer.msg("上传失败");
                layer.close(index_befo);
            }
        });


        upload.render({
            elem: '#insert_pic_mentou', //绑定元素
            method: 'post',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var loaddata = {
                    GSDX: 3,
                    GSDXID: khid,
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: khid,
                    data: JSON.stringify(loaddata)
                }

            },
            done: function (res) {
                //上传完毕回调
                layer.msg("成功");
                layer.close(index_befo);
                TableLoad_wjjl(khid, 3, "mentou4", "门头照片");
            },
            error: function () {
                //请求异常回调
                layer.msg("上传失败");
                layer.close(index_befo);
            }
        });


        upload.render({
            elem: '#insert_fujian', //绑定元素
            method: 'post',
            accept: 'file',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var loaddata = {
                    GSDX: 4,
                    GSDXID: khid,
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: khid,
                    data: JSON.stringify(loaddata)
                }

            },
            done: function (res) {
                //上传完毕回调
                layer.msg("成功");
                layer.close(index_befo);
                TableLoad_fujian(khid, 4, "fujian_upload", "附件名称");
            },
            error: function () {
                //请求异常回调
                //layer.msg("上传失败");
                layer.close(index_befo);
            }
        });




        upload.render({
            elem: '#btn_upload_chepai', //绑定元素
            method: 'post',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var carID = parseInt($("#chepaiID").val());
                var loaddata = {
                    GSDX: 7,
                    GSDXID: carID,
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: carID,
                    data: JSON.stringify(loaddata)
                }

            },
            done: function (res) {
                //上传完毕回调


                var carID = parseInt($("#chepaiID").val());
                TableLoad_wjjl(carID, 7, "pic_chepai015", "车牌照片");
                layer.msg("成功");
                layer.close(index_befo);
            },
            error: function () {
                //请求异常回调
                layer.msg("上传失败");
                layer.close(index_befo);
            }
        });


        upload.render({
            elem: '#btn_upload_hdimg', //绑定元素
            method: 'post',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var hdID = parseInt($("#hdID").val());
                var loaddata = {
                    GSDX: 8,
                    GSDXID: hdID,
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: hdID,
                    data: JSON.stringify(loaddata)
                }

            },
            done: function (res) {
                //上传完毕回调


                var hdID = parseInt($("#hdID").val());
                TableLoad_wjjl(hdID, 8, "pic_hdimg", "活动照片");
                layer.msg("成功");
                layer.close(index_befo);
            },
            error: function () {
                //请求异常回调
                layer.msg("上传失败");
                layer.close(index_befo);
            }
        });

        upload.render({
            elem: '#insert_pic_battery', //绑定元素
            method: 'post',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var loaddata = {
                    GSDX: 10,
                    GSDXID: khid,
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: khid,
                    data: JSON.stringify(loaddata)
                }

            },
            done: function (res) {
                //上传完毕回调
                layer.msg("成功");
                layer.close(index_befo);
                TableLoad_wjjl(khid, 10, "tb_battery", "电池照片");
            },
            error: function () {
                //请求异常回调
                layer.msg("上传失败");
                layer.close(index_befo);
            }
        });

        upload.render({
            elem: '#insert_pic_pack', //绑定元素
            method: 'post',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var loaddata = {
                    GSDX: 11,
                    GSDXID: khid,
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: khid,
                    data: JSON.stringify(loaddata)
                }

            },
            done: function (res) {
                //上传完毕回调
                layer.msg("成功");
                layer.close(index_befo);
                TableLoad_wjjl(khid, 11, "tb_pack", "包装照片");
            },
            error: function () {
                //请求异常回调
                layer.msg("上传失败");
                layer.close(index_befo);
            }
        });


        //});

        form.on('select(type_maichang2)', function (data) {
            switch (data.value) {
                case "1":
                    $("#div_market_up").hide();
                    $("#name2").attr("placeholder", "必填");
                    $("#company_lxr2").attr("placeholder", "必填");
                    $("#company_tel2").attr("placeholder", "必填");
                    //$("#KD_address2").attr("placeholder", "必填");
                    //$("#KD_tel2").attr("placeholder", "必填");
                    $("#FK_tiaojian2").attr("placeholder", "必填");

                    break;
                case "2":
                    $("#div_market_up").show();
                    $("#name2").attr("placeholder", "必填");
                    //$("#KD_address2").attr("placeholder", "必填");
                    //$("#KD_tel2").attr("placeholder", "必填");
                    $("#company_lxr2").removeAttr("placeholder");
                    $("#company_tel2").removeAttr("placeholder");
                    $("#FK_tiaojian2").removeAttr("placeholder");
                    break;
                default:
                    $("#div_market_up").hide();
                    $("#name2").removeAttr("placeholder");
                    //$("#KD_address2").removeAttr("placeholder");
                    //$("#KD_tel2").removeAttr("placeholder");
                    $("#company_lxr2").removeAttr("placeholder");
                    $("#company_tel2").removeAttr("placeholder");
                    $("#FK_tiaojian2").removeAttr("placeholder");
                    break;
            }
        });

        //var arr_area = []
        //if (sessionStorage.getItem("area") != null)
        //{
        //    arr_area = JSON.parse(sessionStorage.getItem("area"));
        //}

        form.on('select(KH2type10)', function (data) {
            if (data.value == 1262) {
                $("#div_industry").show();
            }
            else {
                $("#div_industry").hide();
            }



        });


        form.on('select(area_type001)', function (data) {

            switch (data.value) {
                case "1":
                    $("#001_2").hide();
                    $("#001_3").hide();
                    $("#001_5").hide();
                    break;
                case "2":
                    $("#001_2").show();
                    $("#001_3").hide();
                    $("#001_5").hide();
                    break;
                case "3":
                    $("#001_2").show();
                    $("#001_3").show();
                    $("#001_5").hide();
                    break;
                case "4":
                    $("#001_2").show();
                    $("#001_3").show();
                    $("#001_5").show();
                    break;
                default:
                    $("#001_2").hide();
                    $("#001_3").hide();
                    $("#001_5").hide();
                    break;
            }


        });

        form.on('select(isOfficial)', function (data) {
            switch (data.value) {
                case "10":


                    $("#nsr1").removeAttr("placeholder");
                    $("#KP_address1").removeAttr("placeholder");
                    $("#KP_tel1").removeAttr("placeholder");
                    $("#bank_account1").removeAttr("placeholder");
                    $("#bank_name1").removeAttr("placeholder");
                    $("#company_lxr1").removeAttr("placeholder");
                    $("#company_tel1").removeAttr("placeholder");
                    $("#company_faren1").removeAttr("placeholder");
                    $("#company_guanxi1").removeAttr("placeholder");
                    $("#mission1").removeAttr("placeholder");
                    $("#JXmission1").removeAttr("placeholder");



                    $("#FK_tiaojian2").removeAttr("placeholder");
                    $("#company_lxr2").removeAttr("placeholder");
                    $("#company_tel2").removeAttr("placeholder");
                    $("#name2p").removeAttr("placeholder");

                    $("#jxs_name4").removeAttr("placeholder");
                    $("#address4").removeAttr("placeholder");
                    $("#lxr4").removeAttr("placeholder");
                    $("#tel4").removeAttr("placeholder");

                    $("#jxs_name5").removeAttr("placeholder");

                    $("#address5").removeAttr("placeholder");
                    $("#maichang_name5p").removeAttr("placeholder");

                    $("#address5p").removeAttr("placeholder");


                    $("#jxs_name7").removeAttr("placeholder");

                    $("#address7").removeAttr("placeholder");
                    $("#lxr7").removeAttr("placeholder");
                    $("#tel7").removeAttr("placeholder");

                    $("#address6").removeAttr("placeholder");
                    $("#lxr6").removeAttr("placeholder");
                    $("#tel6").removeAttr("placeholder");

                    break;
                case "20":


                    $("#nsr1").attr("placeholder", "必填");
                    $("#KP_address1").attr("placeholder", "必填");
                    $("#KP_tel1").attr("placeholder", "必填");
                    $("#bank_account1").attr("placeholder", "必填");
                    $("#bank_name1").attr("placeholder", "必填");
                    $("#company_lxr1").attr("placeholder", "必填");
                    $("#company_tel1").attr("placeholder", "必填");
                    $("#company_faren1").attr("placeholder", "必填");
                    $("#company_guanxi1").attr("placeholder", "必填");
                    $("#mission1").attr("placeholder", "必填");
                    $("#JXmission1").attr("placeholder", "必填");



                    $("#FK_tiaojian2").attr("placeholder", "必填");
                    $("#company_lxr2").attr("placeholder", "必填");
                    $("#company_tel2").attr("placeholder", "必填");
                    $("#name2p").attr("placeholder", "必填");

                    $("#jxs_name4").attr("placeholder", "必填");

                    $("#address4").attr("placeholder", "必填");

                    $("#jxs_name5").attr("placeholder", "必填");

                    $("#address5").attr("placeholder", "必填");
                    $("#maichang_name5p").attr("placeholder", "必填");

                    $("#address5p").attr("placeholder", "必填");


                    $("#jxs_name7").attr("placeholder", "必填");

                    $("#address7").attr("placeholder", "必填");
                    $("#lxr7").attr("placeholder", "必填");
                    $("#tel7").attr("placeholder", "必填");

                    $("#address6").attr("placeholder", "必填");
                    $("#lxr6").attr("placeholder", "必填");
                    $("#tel6").attr("placeholder", "必填");;

                    break;

                default:

                    break;
            }



        });


        form.on('select(yyzt5)', function (data) {

            if (data.value == 2361) {
                $("#div_gd5").show();
            }
            else {
                $("#div_gd5").hide();
            }
        });


        form.on('select(yyzt5p)', function (data) {

            if (data.value == 2361) {
                $("#div_gd5p").show();
            }
            else {
                $("#div_gd5p").hide();
            }
        });











        //监听渠道工具条
        table.on('tool(qudao6)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            layer.open({
                title: '提示',
                type: 0,
                content: '确定删除?',
                btn: ['确定', '取消'],
                yes: function (index, layero) {

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../KeHu/Data_Delete_QTXX",
                        data: { xxid: obj.data.XXID },
                        success: function (id) {
                            if (id > 0) {
                                TableLoad_qudaopinzhongjingpin(khid, 1, 1, 'qudao6', '渠道名称');
                                layer.msg("删除成功！");
                            }
                            else {
                                layer.msg("删除失败");
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

        //监听销售品种工具条
        table.on('tool(pinzhong6)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            layer.open({
                title: '提示',
                type: 0,
                content: '确定删除?',
                btn: ['确定', '取消'],
                yes: function (index, layero) {

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../KeHu/Data_Delete_QTXX",
                        data: { xxid: obj.data.XXID },
                        success: function (id) {
                            if (id > 0) {
                                TableLoad_qudaopinzhongjingpin(khid, 2, 1, 'pinzhong6', '销售品种');
                                layer.msg("删除成功！");
                            }
                            else {
                                layer.msg("删除失败");
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

        //监听竞品工具条
        table.on('tool(jingpin7)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            layer.open({
                title: '提示',
                type: 0,
                content: '确定删除?',
                btn: ['确定', '取消'],
                yes: function (index, layero) {

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../KeHu/Data_Delete_QTXX",
                        data: { xxid: obj.data.XXID },
                        success: function (id) {
                            if (id > 0) {
                                TableLoad_qudaopinzhongjingpin(khid, 3, 1, 'jingpin7', '竞品');
                                layer.msg("删除成功！");
                            }
                            else {
                                layer.msg("删除失败");
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

        //监听管辖区域工具条
        table.on('tool(sale_area)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {
                //$("#action_status").val("edit");
                layer.open({
                    type: 1,
                    shade: 0,
                    btn: ['保存', '取消'],
                    area: ['500px', '400px'], //宽高
                    //content: ['/KeHu/Insert_Area', 'no'],
                    content: $("#001"),
                    title: '编辑管辖区域',
                    moveOut: true,
                    success: function (layero, index) {
                        //console.log(layero, index);

                        //$("#area001").val(obj.data.area);
                        //$("#staff001").val(obj.data.staff);
                        //$("#leader001").val(obj.data.leader);
                        //$("#KHstaff001").val(obj.data.KHstaff);
                        //$("#remark001").val(obj.data.remark);

                        $("#zibiao_id").val(obj.data.GXQYID);
                        $("#area_type001").val(obj.data.GXQYLX);
                        if (obj.data.GXQYLX == 2) {
                            $("#province001").val(obj.data.GXQYMC);
                            $("#001_2").show();
                        }
                        else if (obj.data.GXQYLX == 3) {
                            $("#province001").val(obj.data.FID);
                            getDropDownData(2, data.FID, "city001");
                            $("#city001").val(obj.data.GXQYMC);
                            $("#001_2").show();
                            $("#001_3").show();
                        }
                        else if (obj.data.GXQYLX == 4) {


                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../KeHu/Data_SelectDict_ByDicID",
                                data: {
                                    DICID: data.GXQYMC
                                },
                                success: function (reslist) {
                                    var res = JSON.parse(reslist);   //返回的是城市的model
                                    $("#province001").val(res.FID);
                                    getDropDownData(2, res.FID, "city001");
                                    getDropDownData(34, data.FID, "county001");

                                    $("#city001").val(obj.data.FID);
                                    $("#county001").val(obj.data.GXQYMC);

                                    $("#001_2").show();
                                    $("#001_3").show();
                                    $("#001_5").show();

                                    form.render();

                                }
                            });

                        }
                        $("#remark001").val(obj.data.BEIZ);
                        form.render('select');

                    },
                    yes: function (index, layero) {

                        var mydate = new Date();
                        var layer = layui.layer;

                        var type = parseInt($("#area_type001").val());
                        var name;
                        switch (type) {
                            case 1:
                                name = 0;
                                break;
                            case 2:
                                name = parseInt($("#province001").val());
                                break;
                            case 3:
                                name = parseInt($("#city001").val());
                                break;
                            case 4:
                                name = parseInt($("#county001").val());
                                break;
                            default:
                                break;
                        }

                        var areadata;
                        var url;

                        url = "../KeHu/Data_Update_Area";
                        areadata = {
                            GXQYID: $("#zibiao_id").val(),
                            KHID: khid,
                            GXQYLX: type,
                            GXQYMC: name,
                            BEIZ: $("#remark001").val(),
                            ISACTIVE: 1
                        };

                        $.ajax({
                            type: "POST",
                            url: url,
                            data: {
                                data: JSON.stringify(areadata)
                            },
                            success: function (sesponseTest) {
                                if (sesponseTest > 0) {
                                    TableLoad_area(khid);
                                    layer.msg("保存成功！");
                                }
                                else {
                                    layer.msg("保存失败");
                                }

                                layer.close(index);
                            },
                            error: function () {
                                alert("code1017,请联系管理员");
                            }
                        });

                    },
                    end: function () {
                        $("#area_type001").val("");
                        $("#province001").val("0");
                        $("#city001").val("0");
                        $("#county001").val("0");
                        $("#remark001").val("");
                        $("#001").hide();
                        $("#001_2").hide();
                        $("#001_3").hide();
                        $("#001_5").hide();


                        form.render();
                    }

                });
            }
            else if (obj.event == 'delete') {

                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KeHu/Data_Delete_Area",
                            data: { id: obj.data.GXQYID },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_area(khid);
                                    layer.msg("删除成功！");
                                }
                                else {
                                    layer.msg("删除失败");
                                }


                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！")
                            }
                        });
                        layer.close(index);
                    }
                });

            }

        });

        //监听客户联系人工具条
        table.on('tool(contact6)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象
            //sessionStorage.setItem('marry', obj.data.marryvalue);
            //sessionStorage.setItem('major', obj.data.majorvalue);
            if (obj.event == 'edit') {
                //$("#action_status").val("edit");
                layer.open({
                    type: 1,
                    shade: 0,
                    btn: ['保存', '取消'],
                    area: ['1000px', '500px'], //宽高
                    content: $("#002"),
                    title: '编辑客户联系人',
                    moveOut: true,
                    success: function (layero, index) {
                        //console.log(layero, index);
                        $("#zibiao_id").val(obj.data.KHLXRID);
                        $("#name002").val(obj.data.LXR);
                        $("#sex002").val(obj.data.SEX);
                        $("#home002").val(obj.data.JTDZ);
                        $("#jiguan002").val(obj.data.JG);
                        $("#nation002").val(obj.data.MZ);
                        $("#job002").val(obj.data.ZW);
                        $("#hobby002").val(obj.data.AH);
                        $("#marry002").val("" + obj.data.HYZK);
                        $("#mobtel002").val(obj.data.YDDH);
                        $("#tel002").val(obj.data.GDDH);
                        $("#fax002").val(obj.data.TEL);
                        $("#mail002").val(obj.data.EMAIL);
                        $("#weixin002").val(obj.data.WXH);
                        $("#birthday002").val(obj.data.SR);
                        $("#address002").val(obj.data.TXDZ);
                        $("#postalcode002").val(obj.data.YZBM);
                        $("#nature002").val(obj.data.XGMS);
                        $("#major002").val(obj.data.SFZYLXR);
                        $("#remark002").val(obj.data.BEIZ);

                        $("#pic_contact002").attr("src", obj.data.PHOTO);

                        form.render();
                    },
                    yes: function (index, layero) {

                        var layer = layui.layer;
                        if ($("#name002").val() == "") {
                            layer.msg("联系人名称不能为空");
                            return false;
                        }
                        var pa = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                        if ($("#mail002").val() != "" && pa.test($("#mail002").val()) == false) {
                            layer.msg("邮箱格式不正确");
                            return false;
                        }

                        var disdata;
                        var url;
                        url = "../KeHu/Data_Update_Contact";
                        disdata = {
                            KHLXRID: $("#zibiao_id").val(),
                            KHID: khid,
                            LXR: $("#name002").val(),
                            SEX: $("#sex002").val(),
                            JTDZ: $("#home002").val(),
                            JG: $("#jiguan002").val(),
                            MZ: $("#nation002").val(),
                            ZW: $("#job002").val(),
                            AH: $("#hobby002").val(),
                            HYZK: $("#marry002").val(),
                            YDDH: $("#mobtel002").val(),
                            GDDH: $("#tel002").val(),
                            TEL: $("#fax002").val(),
                            EMAIL: $("#mail002").val(),
                            WXH: $("#weixin002").val(),
                            SR: $("#birthday002").val(),
                            TXDZ: $("#address002").val(),
                            YZBM: $("#postalcode002").val(),
                            XGMS: $("#nature002").val(),
                            PHOTO: $("#path").val(),            //图片地址
                            SFZYLXR: $("#major002").val(),
                            BEIZ: $("#remark002").val(),
                            //操作人
                            ISACTIVE: 1
                        };

                        $.ajax({
                            type: "POST",
                            url: url,
                            data: {
                                data: JSON.stringify(disdata)
                            },
                            success: function (sesponseTest) {
                                if (sesponseTest > 0) {
                                    TableLoad_contact(khid, 1);
                                    layer.msg("保存成功！");
                                }
                                else {
                                    layer.msg("保存失败");
                                }

                                layer.close(index);
                            },
                            error: function () {
                                alert("code1014,请联系管理员");
                            }
                        });

                    },
                    end: function () {
                        $("#name002").val("");
                        $("#sex002").val("");
                        $("#home002").val("");
                        $("#jiguan002").val("");
                        $("#nation002").val("0");
                        $("#job002").val("0");
                        $("#hobby002").val("");
                        $("#marry002").val("0");
                        $("#mobtel002").val("");
                        $("#tel002").val("");
                        $("#fax002").val("");
                        $("#mail002").val("");
                        $("#weixin002").val("");
                        $("#birthday002").val("");
                        $("#address002").val("");
                        $("#postalcode002").val("");
                        $("#nature002").val("");
                        $("#major002").val("0");
                        $("#remark002").val("");
                        $("#pic_contact002").attr("src", $("#netpath").val());
                        $("#002").hide();

                        form.render();
                    }
                });
            }
            else if (obj.event == "delete") {

                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KeHu/Data_Delete_Contact",
                            data: { id: obj.data.KHLXRID },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_contact(khid, 1);
                                    layer.msg("删除成功！");
                                }
                                else {
                                    layer.msg("删除失败");
                                }


                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！")
                            }
                        });
                        layer.close(index);
                    }
                });

            }

        });

        //监听直销人员工具条
        table.on('tool(zxry6)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象
            //sessionStorage.setItem('marry', obj.data.marryvalue);
            //sessionStorage.setItem('major', obj.data.majorvalue);
            if (obj.event == 'edit') {
                //$("#action_status").val("edit");
                layer.open({
                    type: 1,
                    shade: 0,
                    btn: ['保存', '取消'],
                    area: ['400px', '400px'], //宽高
                    content: $("#002p"),
                    title: '编辑直销人员',
                    moveOut: true,
                    success: function (layero, index) {
                        //console.log(layero, index);
                        $("#zibiao_id").val(obj.data.KHLXRID);
                        $("#name002p").val(obj.data.LXR);
                        $("#mobtel002p").val(obj.data.YDDH);
                        $("#remark002p").val(obj.data.BEIZ);

                        //$("#pic_contact002").attr("src", obj.data.PHOTO);

                        form.render();
                    },
                    yes: function (index, layero) {

                        var layer = layui.layer;
                        if ($("#name002p").val() == "") {
                            layer.msg("人员名称不能为空");
                            return false;
                        }
                        if ($("#mobtel002p").val() == "") {
                            layer.msg("联系方式不能为空");
                            return false;
                        }
                        if ($("#remark002p").val() == "") {
                            layer.msg("工作内容不能为空");
                            return false;
                        }

                        var disdata;
                        var url;
                        url = "../KeHu/Data_Update_Contact";
                        disdata = {
                            KHLXRID: $("#zibiao_id").val(),
                            KHID: data.KHID,
                            LXR: $("#name002p").val(),
                            YDDH: $("#mobtel002p").val(),
                            BEIZ: $("#remark002p").val(),
                            //操作人
                            ISACTIVE: 1
                        };

                        $.ajax({
                            type: "POST",
                            url: url,
                            data: {
                                data: JSON.stringify(disdata)
                            },
                            success: function (sesponseTest) {
                                if (sesponseTest > 0) {
                                    TableLoad_zxry(khid);
                                    layer.msg("保存成功！");
                                }
                                else {
                                    layer.msg("保存失败");
                                }

                                layer.close(index);
                            },
                            error: function () {
                                alert("修改失败,请联系管理员");
                            }
                        });

                    },
                    end: function () {
                        $("#name002p").val("");
                        $("#mobtel002p").val("");
                        $("#remark002p").val("");
                        $("#002p").hide();

                        form.render();
                    }
                });
            }
            else if (obj.event == "delete") {

                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KeHu/Data_Delete_Contact",
                            data: {
                                id: obj.data.KHLXRID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_zxry(khid);
                                    layer.msg("删除成功！");
                                }
                                else {
                                    layer.msg("删除失败");
                                }


                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！")
                            }
                        });
                        layer.close(index);
                    }
                });

            }

        });

        //监听邮寄地址工具条
        table.on('tool(post6)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {

                //$("#action_status").val("edit");
                layer.open({
                    type: 1,
                    shade: 0,
                    btn: ['保存', '取消'],
                    area: ['500px', '400px'], //宽高
                    //content: ['/KeHu/Insert_Area', 'no'],
                    content: $("#003"),
                    title: '编辑邮寄区域',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#zibiao_id").val(obj.data.XXID);
                        $("#address003").val(obj.data.KHYJDZ);
                        $("#postalcode003").val(obj.data.YB);
                        $("#name003").val(obj.data.SJR);
                        $("#tel003").val(obj.data.SJRLXFS);
                        $("#remark003").val(obj.data.BEIZ);



                    },
                    yes: function (index, layero) {

                        var mydate = new Date();
                        var layer = layui.layer;
                        var postdata;
                        var url;
                        url = "../KeHu/Data_Update_QTXX";
                        postdata = {
                            XXID: $("#zibiao_id").val(),
                            KHID: khid,
                            XXLB: 5,
                            KHYJDZ: $("#address003").val(),
                            YB: $("#postalcode003").val(),
                            SJR: $("#name003").val(),
                            SJRLXFS: $("#tel003").val(),
                            //操作人
                            //CZRQ: mydate.toLocaleDateString(),
                            BEIZ: $("#remark003").val(),
                            ISACTIVE: 1
                        };


                        $.ajax({
                            type: "POST",
                            url: url,
                            data: {
                                data: JSON.stringify(postdata)
                            },
                            success: function (sesponseTest) {
                                if (sesponseTest > 0) {
                                    TableLoad_post(khid);
                                    layer.msg("保存成功！");
                                }
                                else {
                                    layer.msg("保存失败");
                                }

                                layer.close(index);
                            },
                            error: function () {
                                alert("code1016,请联系管理员");
                            }
                        });

                    },
                    end: function () {
                        $("#address003").val("");
                        $("#postalcode003").val("");
                        $("#name003").val("");
                        $("#tel003").val("");
                        $("#remark003").val("");
                        $("#003").hide();




                    }

                });

            }
            else if (obj.event == 'delete') {

                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KeHu/Data_Delete_QTXX",
                            data: { xxid: obj.data.XXID },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_post(khid);
                                    layer.msg("删除成功！");
                                }
                                else {
                                    layer.msg("删除失败");
                                }


                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！")
                            }
                        });
                        layer.close(index);
                    }
                });

            }


        });

        //监听陈列工具条
        table.on('tool(display6)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {

                //$("#action_status").val("edit");
                layer.open({
                    type: 1,
                    shade: 0,
                    btn: ['保存', '取消'],
                    area: ['500px', '400px'], //宽高
                    //content: ['/KeHu/Insert_Area', 'no'],
                    content: $("#004"),
                    title: '编辑陈列',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#zibiao_id").val(obj.data.XXID);
                        $("#displaytype004").val(obj.data.CLLX);
                        $("#displayway004").val(obj.data.CLFS);
                        $("#display_time004").val(obj.data.CLGSRQ);
                        $("#display_endtime004").val(obj.data.CLGSJSRQ);
                        $("#displayitem004").val(obj.data.DISPLAYITEM);
                        $("#remark004").val(obj.data.BEIZ);


                        form.render();
                    },
                    yes: function (index, layero) {
                        if ($("#displayway004").val() == "0") {
                            layer.msg("请输入陈列方式！");
                            return false;
                        }
                        if (typevalue == 7 && ($("#display_time004").val() == "" || $("#display_endtime004").val() == "")) {
                            layer.msg("请输入陈列归属日期！");
                            return false;
                        }


                        var mydate = new Date();
                        var disdata;
                        var url;
                        url = "../KeHu/Data_Update_QTXX";
                        disdata = {
                            XXID: $("#zibiao_id").val(),
                            KHID: khid,
                            XXLB: 4,
                            CLLX: $("#displaytype004").val(),
                            CLFS: $("#displayway004").val(),
                            CLGSRQ: $("#display_time004").val(),
                            CLGSJSRQ: $("#display_endtime004").val(),
                            DISPLAYITEM: $("#displayitem004").val(),
                            //操作人
                            //CZRQ: mydate.toLocaleDateString(),
                            BEIZ: $("#remark004").val(),
                            ISACTIVE: 1
                        };


                        $.ajax({
                            type: "POST",
                            url: url,
                            data: {
                                data: JSON.stringify(disdata)
                            },
                            success: function (sesponseTest) {
                                if (sesponseTest > 0) {
                                    TableLoad_display(khid, 1);
                                    layer.msg("保存成功！");
                                }
                                else {
                                    layer.msg("保存失败");
                                }

                                layer.close(index);
                            },
                            error: function () {
                                alert("code1013,请联系管理员");
                            }
                        });

                    },
                    end: function () {
                        $("#displaytype004").val("1");
                        $("#displayway004").val("0");
                        $("#display_time004").val("");
                        $("#display_endtime004").val("");
                        $("#remark004").val("");
                        $("#004").hide();

                        form.render();
                    }

                });


            }
            else if (obj.event == 'img') {
                $("#displayID").val(obj.data.XXID);
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['70%', '80%'], //宽高
                    content: $('#004p'),
                    title: '编辑陈列照片',
                    moveOut: true,
                    success: function (layero, index) {
                        //读取对应的照片信息加载到表格中
                        TableLoad_wjjl(obj.data.XXID, 2, "pic_display004", "陈列照片");
                    },
                    end: function () {
                        $("#004p").hide();
                    }
                });
            }
            else if (obj.event == 'delete') {

                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KeHu/Data_Delete_QTXX",
                            data: { xxid: obj.data.XXID },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_display(khid, 1);
                                    layer.msg("删除成功！");
                                }
                                else {
                                    layer.msg("删除失败");
                                }


                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！")
                            }
                        });
                        layer.close(index);
                    }
                });

            }



        });

        //监听分组工具条
        table.on('tool(to_group)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            layer.open({
                title: '提示',
                type: 0,
                content: '确定删除?',
                btn: ['确定', '取消'],
                yes: function (index, layero) {

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../KeHu/Data_Delete_Group",
                        data: {
                            KHID: khid,
                            GID: obj.data[0]
                        },
                        success: function (id) {
                            if (id > 0) {
                                TableLoad_group(khid);
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
                                    TableLoad_fujian(khid, 4, "fujian_upload", "附件名称");
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

        //监听门头照片工具条
        table.on('tool(mentou4)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'delete') {
                if (data.SPZT == 30) {
                    layer.msg("当前状态不可删除！");
                    return false;
                }
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
                                    TableLoad_wjjl(khid, 3, "mentou4", "门头照片");
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

        //监听陈列照片工具条
        table.on('tool(pic_display004)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'delete') {
                if (data.SPZT == 30) {
                    layer.msg("当前状态不可删除！");
                    return false;
                }
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
                                    var disID = parseInt($("#displayID").val());
                                    TableLoad_wjjl(disID, 2, "pic_display004", "陈列照片");
                                    TableLoad_display(khid, 1);
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

        //监听签到工具条
        table.on('tool(qiandao)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == "delete") {
                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KeHu/Data_Delete_KaoQin",
                            data: {
                                DZID: data.DZID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_qiandao(khid);
                                    layer.msg("删除成功！");
                                }
                                else
                                    layer.msg("删除失败！");

                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！");
                            }
                        });
                        layer.close(index);
                    }
                });
            }
            else if (obj.event == "edit") {

                layer.open({
                    type: 1,
                    shade: 0,
                    btn: ['保存', '取消'],
                    area: ['350px', '250px'], //宽高
                    content: $('#010'),
                    title: '修改容差',
                    moveOut: true,
                    success: function () {
                        $("#rongcha010").val(data.DZRC);
                    },
                    yes: function (index, layero) {

                        var layer = layui.layer;


                        $.ajax({
                            type: "POST",
                            url: "../KeHu/Data_Update_KaoQinRC",
                            data: {
                                data: JSON.stringify(obj.data),
                                rongcha: parseInt($("#rongcha010").val())
                            },
                            success: function (res) {
                                if (res > 0) {
                                    layer.msg("修改成功！");
                                    TableLoad_qiandao(khid);
                                }
                                else
                                    layer.msg("修改失败！");
                                layer.close(index);
                            },
                            error: function () {
                                alert("code1021,请联系管理员");
                            }
                        });

                    },
                    end: function () {
                        $("#rongcha010").val("");
                        $("#010").hide();

                        form.render();
                    }
                });

            }





        });

        //监听拜访频次关联表工具条
        table.on('tool(pinciToKH)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            layer.open({
                title: '提示',
                type: 0,
                content: '确定删除?',
                btn: ['确定', '取消'],
                yes: function (index, layero) {

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../KeHu/Data_Delete_KH_KHBF",
                        data: {
                            KHID: obj.data.KHID,
                            BFID: data.BFID
                        },
                        success: function (id) {
                            if (id > 0) {
                                TableLoad_pinciToKH(khid);
                                layer.msg("删除成功！");
                            }
                            else {
                                layer.msg("删除失败");
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

        //监听拜访频次工具条
        table.on('tool(pinci)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            $.ajax({
                type: "POST",
                async: false,
                url: "../KeHu/Data_Insert_KH_KHBF",
                data: {
                    KHID: khid,
                    BFID: data.BFID
                },
                success: function (id) {
                    if (id > 0) {
                        TableLoad_pinciToKH(khid);
                        layer.closeAll();
                        layer.msg("添加成功！");

                    }
                    else {
                        layer.msg("添加失败");
                    }


                },
                error: function (err) {
                    layer.msg("系统错误,请重试！")
                }
            });



        });

        //监听送货数量工具条
        table.on('tool(tb_songhuo)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {

                //$("#action_status").val("edit");
                layer.open({
                    type: 1,
                    shade: 0,
                    btn: ['保存', '取消'],
                    area: ['500px', '400px'], //宽高
                    //content: ['/KeHu/Insert_Area', 'no'],
                    content: $("#012"),
                    title: '编辑送货数量',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#zibiao_id").val(obj.data.XSID);
                        $("#songhuo_cishu012").val(obj.data.XSMC);
                        $("#songhuo_counts012").val(obj.data.XSSL);
                        $("#songhuo_time012").val(obj.data.GSRQ);
                        $("#remark012").val(obj.data.BEIZ);



                    },
                    yes: function (index, layero) {

                        if ($("#songhuo_cishu012").val() == "") {
                            layer.msg("送货次数不可为空！");
                            return false;
                        }
                        var reg = /^\+?[1-9][0-9]*$/;
                        if (!reg.test($("#songhuo_cishu012").val())) {
                            layer.msg("送货次数必须为全数字");
                            return false;
                        }
                        if (parseInt($("#songhuo_cishu012").val()) > 50) {
                            layer.msg("送货次数不可大于50");
                            return false;
                        }
                        if ($("#songhuo_counts012").val() == "") {
                            layer.msg("送货数量不可为空！");
                            return false;
                        }
                        if ($("#songhuo_time012").val() == "") {
                            layer.msg("送货日期不可为空！");
                            return false;
                        }


                        var mydate = new Date();
                        var postdata;
                        var url;
                        url = "../KeHu/Data_Update_XSTJ";
                        postdata = {
                            XSID: data.XSID,
                            KHID: khid,
                            XSLB: data.XSLB,
                            XSMC: $("#songhuo_cishu012").val(),
                            XSSL: $("#songhuo_counts012").val(),
                            GSRQ: $("#songhuo_time012").val(),
                            //操作人
                            //CZRQ: mydate.toLocaleDateString(),
                            BEIZ: $("#remark012").val(),
                            ISACTIVE: data.ISACTIVE
                        };


                        $.ajax({
                            type: "POST",
                            url: url,
                            data: {
                                data: JSON.stringify(postdata)
                            },
                            success: function (sesponseTest) {
                                if (sesponseTest > 0) {
                                    TableLoad_songhuo(khid);
                                    layer.msg("保存成功！");
                                }
                                else {
                                    layer.msg("保存失败");
                                }

                                layer.close(index);
                            },
                            error: function () {
                                alert("系统错误");
                            }
                        });

                    },
                    end: function () {
                        $("#songhuo_cishu012").val("");
                        $("#songhuo_counts012").val("");
                        $("#songhuo_time012").val("");
                        $("#remark012").val("");
                        $("#012").hide();




                    }

                });

            }
            else if (obj.event == 'delete') {

                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KeHu/Data_Delete_XSTJ",
                            data: {
                                XSID: obj.data.XSID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_songhuo(khid);
                                    layer.msg("删除成功！");
                                }
                                else {
                                    layer.msg("删除失败");
                                }


                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！")
                            }
                        });
                        layer.close(index);
                    }
                });

            }


        });

        //监听直销商销售工具条
        table.on('tool(tb_zhixiao)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {

                //$("#action_status").val("edit");
                layer.open({
                    type: 1,
                    shade: 0,
                    btn: ['保存', '取消'],
                    area: ['500px', '400px'], //宽高
                    //content: ['/KeHu/Insert_Area', 'no'],
                    content: $("#013"),
                    title: '编辑直销商销售',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#zibiao_id").val(obj.data.XSID);
                        $("#zhixiao_type13").val(data.XSLB);
                        $("#zhixiao_year13").val(obj.data.GSRQ);
                        $("#zhixiao_howmuch13").val(obj.data.XSJE);

                        form.render();

                    },
                    yes: function (index, layero) {

                        var mydate = new Date();
                        var layer = layui.layer;
                        var postdata;
                        var url;
                        url = "../KeHu/Data_Update_XSTJ";
                        postdata = {
                            XSID: data.XSID,
                            KHID: khid,
                            XSLB: data.XSLB,
                            XSMC: $("#zhixiao_type13").val(),
                            XSJE: $("#zhixiao_howmuch13").val(),
                            GSRQ: $("#zhixiao_year13").val(),
                            //操作人
                            //CZRQ: mydate.toLocaleDateString(),
                            ISACTIVE: data.ISACTIVE
                        };


                        $.ajax({
                            type: "POST",
                            url: url,
                            data: {
                                data: JSON.stringify(postdata)
                            },
                            success: function (sesponseTest) {
                                if (sesponseTest > 0) {
                                    TableLoad_zhixiao(khid);
                                    layer.msg("保存成功！");
                                }
                                else {
                                    layer.msg("保存失败");
                                }

                                layer.close(index);
                            },
                            error: function () {
                                alert("系统错误");
                            }
                        });

                    },
                    end: function () {
                        $("#zhixiao_type13").val("0");
                        $("#zhixiao_howmuch13").val("");
                        $("#zhixiao_year13").val("");
                        $("#013").hide();




                    }

                });

            }
            else if (obj.event == 'delete') {

                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KeHu/Data_Delete_XSTJ",
                            data: {
                                XSID: obj.data.XSID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_zhixiao(khid);
                                    layer.msg("删除成功！");
                                }
                                else {
                                    layer.msg("删除失败");
                                }


                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！")
                            }
                        });
                        layer.close(index);
                    }
                });

            }


        });

        //监听网点数量工具条
        table.on('tool(tb_WDshuliang)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
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
                            url: "../KeHu/Data_Delete_XSTJ",
                            data: {
                                XSID: obj.data.XSID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_WDshuliang(khid);
                                    layer.msg("删除成功！");
                                }
                                else {
                                    layer.msg("删除失败");
                                }


                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！")
                            }
                        });
                        layer.close(index);
                    }
                });

            }


        });

        //监听车牌工具条
        table.on('tool(tb_chepai)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {

                //$("#action_status").val("edit");
                layer.open({
                    type: 1,
                    shade: 0,
                    btn: ['保存', '取消'],
                    area: ['500px', '400px'], //宽高
                    //content: ['/KeHu/Insert_Area', 'no'],
                    content: $("#015"),
                    title: '编辑车牌',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#zibiao_id").val(obj.data.XXID);
                        $("#chepai15").val(obj.data.XXMC);
                        $("#haveAd15").val(obj.data.PD);

                        form.render();

                    },
                    yes: function (index, layero) {

                        var mydate = new Date();
                        var layer = layui.layer;
                        var postdata;
                        var url;
                        url = "../KeHu/Data_Update_QTXX";
                        newdata = {
                            XXID: data.XXID,
                            KHID: data.KHID,
                            XXLB: data.XXLB,
                            XXMC: $("#chepai15").val(),
                            PD: $("#haveAd15").val(),
                            //操作人
                            //CZRQ: mydate.toLocaleDateString(),
                            ISACTIVE: data.ISACTIVE
                        };


                        $.ajax({
                            type: "POST",
                            url: url,
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (sesponseTest) {
                                if (sesponseTest > 0) {
                                    TableLoad_chepai(khid);
                                    layer.msg("保存成功！");
                                }
                                else {
                                    layer.msg("保存失败");
                                }

                                layer.close(index);
                            },
                            error: function () {
                                alert("系统错误");
                            }
                        });

                    },
                    end: function () {
                        $("#chepai15").val("");
                        $("#haveAd15").val("0");
                        $("#015").hide();




                    }

                });

            }
            else if (obj.event == 'delete') {

                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KeHu/Data_Delete_QTXX",
                            data: { xxid: obj.data.XXID },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_chepai(khid);
                                    layer.msg("删除成功！");
                                }
                                else {
                                    layer.msg("删除失败");
                                }


                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！")
                            }
                        });
                        layer.close(index);
                    }
                });

            }
            else if (obj.event == 'img') {
                $("#chepaiID").val(obj.data.XXID);
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['500px', '450px'], //宽高
                    content: $('#015p'),
                    title: '编辑车牌照片',
                    moveOut: true,
                    success: function (layero, index) {
                        //读取对应的照片信息加载到表格中
                        TableLoad_wjjl(obj.data.XXID, 7, "pic_chepai015", "车牌照片");
                    },
                    end: function () {
                        $("#015p").hide();
                    }
                });
            }


        });

        //监听车牌照片工具条
        table.on('tool(pic_chepai015)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
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
                                    var carID = parseInt($("#chepaiID").val());
                                    TableLoad_wjjl(carID, 7, "pic_chepai015", "车牌照片");
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

        //监听促销单品工具条
        table.on('tool(tb_cuxiao)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {

                //$("#action_status").val("edit");
                layer.open({
                    type: 1,
                    shade: 0,
                    btn: ['保存', '取消'],
                    area: ['500px', '400px'], //宽高
                    //content: ['/KeHu/Insert_Area', 'no'],
                    content: $("#016"),
                    title: '编辑促销单品',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#zibiao_id").val(obj.data.XXID);
                        $("#DPname16").val(obj.data.XXMC);
                        $("#ischongdie16").val(obj.data.PD);

                        form.render();

                    },
                    yes: function (index, layero) {

                        var mydate = new Date();
                        var layer = layui.layer;
                        var postdata;
                        var url;
                        url = "../KeHu/Data_Update_QTXX";
                        newdata = {
                            XXID: data.XXID,
                            KHID: data.KHID,
                            XXLB: data.XXLB,
                            XXMC: $("#DPname16").find("option:selected").text(),
                            PD: $("#ischongdie16").val(),
                            //操作人
                            //CZRQ: mydate.toLocaleDateString(),
                            ISACTIVE: data.ISACTIVE
                        };


                        $.ajax({
                            type: "POST",
                            url: url,
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (sesponseTest) {
                                if (sesponseTest > 0) {
                                    TableLoad_cuxiao(khid);
                                    layer.msg("保存成功！");
                                }
                                else {
                                    layer.msg("保存失败");
                                }

                                layer.close(index);
                            },
                            error: function () {
                                alert("系统错误");
                            }
                        });

                    },
                    end: function () {
                        $("#DPname16").val("");
                        $("#ischongdie16").val("0");
                        $("#016").hide();




                    }

                });

            }
            else if (obj.event == 'delete') {

                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KeHu/Data_Delete_QTXX",
                            data: { xxid: obj.data.XXID },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_cuxiao(khid);
                                    layer.msg("删除成功！");
                                }
                                else {
                                    layer.msg("删除失败");
                                }


                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！")
                            }
                        });
                        layer.close(index);
                    }
                });

            }


        });

        //监听销售业务进展工具条
        table.on('tool(tb_jinzhan)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {

                //$("#action_status").val("edit");
                layer.open({
                    type: 1,
                    shade: 0,
                    btn: ['保存', '取消'],
                    area: ['500px', '400px'], //宽高
                    //content: ['/KeHu/Insert_Area', 'no'],
                    content: $("#017"),
                    title: '编辑销售业务进展',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#jieduan17").val(obj.data.JZID);
                        $("#info17").val(obj.data.INFO1);

                        form.render();

                    },
                    yes: function (index, layero) {

                        var mydate = new Date();
                        var layer = layui.layer;
                        var postdata;
                        var url;
                        url = "../KeHu/Data_Update_XSYWJZ";
                        newdata = {
                            XSYWJZID: data.XSYWJZID,
                            KHID: data.KHID,
                            JZID: $("#jieduan17").val(),
                            INFO1: $("#info17").val(),
                            INFO2: data.INFO2,
                            INFO3: data.INFO3,
                            //CZR:
                            //CZSJ:
                            ISACTIVE: data.ISACTIVE,
                            ISDELETE: data.ISDELETE,
                            BEIZ: data.BEIZ

                        };


                        $.ajax({
                            type: "POST",
                            url: url,
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (sesponseTest) {
                                if (sesponseTest > 0) {
                                    TableLoad_xsywjz(khid);
                                    layer.msg("保存成功！");
                                }
                                else {
                                    layer.msg("保存失败");
                                }

                                layer.close(index);
                            },
                            error: function () {
                                alert("系统错误");
                            }
                        });

                    },
                    end: function () {
                        $("#jieduan17").val("0");
                        $("#info17").val("");
                        $("#017").hide();

                    }

                });

            }
            else if (obj.event == 'delete') {

                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KeHu/Data_Delete_XSYWJZ",
                            data: {
                                XSYWJZID: obj.data.XSYWJZID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_xsywjz(khid);
                                    layer.msg("删除成功！");
                                }
                                else {
                                    layer.msg("删除失败");
                                }


                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！")
                            }
                        });
                        layer.close(index);
                    }
                });

            }


        });

        //监听资质工具条
        table.on('tool(tb_zz)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {

                //$("#action_status").val("edit");
                layer.open({
                    type: 1,
                    shade: 0,
                    btn: ['保存', '取消'],
                    area: ['500px', '400px'], //宽高
                    //content: ['/KeHu/Insert_Area', 'no'],
                    content: $("#div_newzz"),
                    title: '编辑客户资质',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#ZZ_type").val(obj.data.ZZMCID);
                        $("#zz_dzs_usenow").val(obj.data.INFO1);

                        form.render();

                    },
                    yes: function (index, layero) {

                        var mydate = new Date();
                        var layer = layui.layer;
                        var postdata;
                        var url;
                        url = "../KeHu/Data_Update_KHZZ";
                        newdata = {
                            ZZID: data.ZZID,
                            KHID: data.KHID,
                            ZZMCID: $("#ZZ_type").val(),
                            INFO1: $("#zz_dzs_usenow").val(),
                            INFO2: data.INFO2,
                            INFO3: data.INFO3,
                            //CZR: 
                            CZSJ: "",
                            ISACTIVE: data.ISACTIVE,
                            //ISDELETE:
                            BEIZ: data.BEIZ
                        };


                        $.ajax({
                            type: "POST",
                            url: url,
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (sesponseTest) {
                                if (sesponseTest > 0) {
                                    TableLoad_zz(khid, typevalue);
                                    layer.msg("保存成功！");
                                }
                                else {
                                    layer.msg("保存失败");
                                }

                                layer.close(index);
                            },
                            error: function () {
                                alert("系统错误");
                            }
                        });

                    },
                    end: function () {
                        $("#ZZ_type").val("0");
                        $("#zz_dzs_usenow").val("");
                        $("#div_newzz").hide();

                    }

                });

            }
            else if (obj.event == 'delete') {

                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KeHu/Data_Delete_KHZZ",
                            data: {
                                ZZID: obj.data.ZZID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_zz(khid, typevalue);
                                    layer.msg("删除成功！");
                                }
                                else {
                                    layer.msg("删除失败");
                                }


                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！")
                            }
                        });
                        layer.close(index);
                    }
                });

            }


        });

        //监听客户活动工具条
        table.on('tool(tb_hd)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {

                //$("#action_status").val("edit");
                layer.open({
                    type: 1,
                    shade: 0,
                    btn: ['保存', '取消'],
                    area: ['500px', '400px'], //宽高
                    //content: ['/KeHu/Insert_Area', 'no'],
                    content: $("#div_newhd"),
                    title: '编辑客户活动',
                    moveOut: true,
                    success: function (layero, index) {
                        getDropDownData(45, data.HDMC, "HDcplx");
                        getDropDownData(105, data.HDMC, "HDtc");


                        $("#HDname").val(obj.data.HDMC);
                        $("#HDtc").val(obj.data.HDTC);
                        $("#HDcplx").val(obj.data.CPLX);
                        $("#HDxl").val(obj.data.XL);
                        $("#HDdisplay").val(obj.data.HDCL);
                        $("#HDbeiz").val(obj.data.BEIZ);



                        form.render();
                        if (data.HDMC == 1432) {
                            $("#div_hdcl").show();
                        }
                        else {
                            $("#div_hdcl").hide();
                        }
                        if (data.HDMC == 4166) {
                            $("#div_hdxl").show();
                        }
                        else {
                            $("#div_hdxl").hide();
                        }

                    },
                    yes: function (index, layero) {
                        if ($("#HDname").val() == "0") {
                            layer.msg("请选择活动名称");
                            return false;
                        }
                        if ($("#HDname").val() != 1076) {
                            if ($("#HDtc").val() == 0) {
                                layer.msg("请选择活动套餐");
                                return false;
                            }
                            //if ($("#HDcplx").val() == "0") {
                            //    layer.msg("请选择产品类型");
                            //    return false;
                            //}
                            //if ($("#HDxl").val() == "") {
                            //    layer.msg("请输入销量");
                            //    return false;
                            //}
                            //var reg = /^\+?[1-9][0-9]*$/;
                            //if (!reg.test($("#HDxl").val()) && $("#HDxl").val() != "") {
                            //    layer.msg("销量必须为全数字");
                            //    return false;
                            //}
                        }
                        var newdata;
                        newdata = {
                            HDID: data.HDID,
                            KHID: data.KHID,
                            HDMC: $("#HDname").val(),
                            HDTC: $("#HDtc").val(),
                            CPLX: $("#HDcplx").val(),
                            XL: $("#HDxl").val(),
                            HDCL: $("#HDdisplay").val(),
                            BEIZ: $("#HDbeiz").val(),
                            //CZR: 
                            CZSJ: "",
                            ISACTIVE: data.ISACTIVE
                        };
                        $.ajax({
                            type: "POST",
                            url: "../KeHu/Data_Update_KHHD",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (sesponseTest) {
                                if (sesponseTest > 0) {
                                    TableLoad_khhd(khid);
                                    layer.closeAll();
                                    layer.msg("保存成功！");
                                }
                                else {
                                    layer.msg("保存失败");
                                }

                                layer.close(index);
                            },
                            error: function () {
                                alert("系统错误");
                            }
                        });




                    },
                    end: function () {
                        $("#HDname").val("0");
                        $("#HDtc").val("0");
                        $("#HDcplx").val("0");
                        $("#HDxl").val("");
                        $("#HDdisplay").val(0);
                        $("#HDbeiz").val("");
                        $("#div_newhd").hide();
                        $("#div_hdcl").hide();
                        form.render();
                    }

                });

            }
            else if (obj.event == 'delete') {

                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KeHu/Data_Delete_KHHD",
                            data: {
                                HDID: obj.data.HDID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_khhd(khid);
                                    layer.msg("删除成功！");
                                }
                                else {
                                    layer.msg("删除失败");
                                }


                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！")
                            }
                        });
                        layer.close(index);
                    }
                });

            }
            else if (obj.event == 'img') {
                $("#hdID").val(obj.data.HDID);
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['70%', '80%'], //宽高
                    content: $('#div_hdimg'),
                    title: '编辑活动照片',
                    moveOut: true,
                    success: function (layero, index) {
                        //读取对应的照片信息加载到表格中
                        TableLoad_wjjl(obj.data.HDID, 8, "pic_hdimg", "活动照片");
                    },
                    end: function () {
                        $("#div_hdimg").hide();
                    }
                });
            }


        });

        //监听活动照片工具条
        table.on('tool(pic_hdimg)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'delete') {
                if (data.SPZT == 30) {
                    layer.msg("当前状态不可删除！");
                    return false;
                }
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
                                    var hdID = parseInt($("#hdID").val());
                                    TableLoad_wjjl(hdID, 8, "pic_hdimg", "活动照片");
                                    TableLoad_khhd(khid);
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

        //监听电池照片工具条
        table.on('tool(tb_battery)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
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
                                    TableLoad_wjjl(khid, 10, "tb_battery", "电池照片");
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

        //监听包装照片工具条
        table.on('tool(tb_pack)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
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
                                    TableLoad_wjjl(khid, 11, "tb_pack", "包装照片");
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


    //form.render();




});












