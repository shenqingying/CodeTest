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
                //width: 520,
                page: true, //开启分页
                cols: [[ //表头
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'WJM', title: titlt, width: 300 },
                  //{ field: 'WJM', title: titlt, width: 300, templet: '#imgTpl' },
                 { width: 150, align: 'center', toolbar: '#bar_fujian' }
                ]]
            });
            //$("img.mytableimg").parent().css("height", "auto");
        },
        error: function () {
            alert("附件加载失败,请联系管理员");
        }
    });

}



function TableLoad_fujian_watch(GSDXID, GSDX, elem, titlt) {
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
                //width: 520,
                page: true, //开启分页
                cols: [[ //表头
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'WJM', title: titlt, width: 300 },
                  //{ field: 'WJM', title: titlt, width: 300, templet: '#imgTpl' },
                 { width: 70, align: 'center', toolbar: '#bar_fujian_watch' }
                ]]
            });
            //$("img.mytableimg").parent().css("height", "auto");
        },
        error: function () {
            alert("附件加载失败,请联系管理员");
        }
    });

}




function TableLoad_opinion(OACSBH, OACSLB, elem) {
    var table = layui.table;

    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_Opinion",
        data: {
            OACSBH: OACSBH,
            OACSLB: OACSLB
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
                 { field: 'SPRNAME', title: '审批人', width: 90 },
                 { field: 'ATTITUDE', title: '审批结果', width: 120 },
                 { field: 'OPINION', title: '审批意见', width: 200 },
                 { field: 'SPSJ', title: '审批时间', width: 120 },
                 { field: 'STAFFNAME', title: '回复人', width: 120 },
                 { field: 'HFNR', title: '回复内容', width: 200 },
                 { field: 'HFSJ', title: '回复时间', width: 120 },
                 { fixed: 'right', width: 70, align: 'center', toolbar: '#bar_opinion' }
                ]]
            });

        },
        error: function () {
            alert("审批意见加载失败,请联系管理员");
        }
    });

}



function TableLoad_opinion_watch(OACSBH, OACSLB, elem) {
    var table = layui.table;

    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_Opinion",
        data: {
            OACSBH: OACSBH,
            OACSLB: OACSLB
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
                 { field: 'SPRNAME', title: '审批人', width: 90 },
                 { field: 'ATTITUDE', title: '审批结果', width: 120 },
                 { field: 'OPINION', title: '审批意见', width: 200 },
                 { field: 'SPSJ', title: '审批时间', width: 120 },
                 { field: 'STAFFNAME', title: '回复人', width: 120 },
                 { field: 'HFNR', title: '回复内容', width: 200 },
                 { field: 'HFSJ', title: '回复时间', width: 120 }
                ]]
            });

        },
        error: function () {
            alert("审批意见加载失败,请联系管理员");
        }
    });

}


