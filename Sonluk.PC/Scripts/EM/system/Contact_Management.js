var deptall = "";
var gsall = "";
var all_fy = 1;
var all_fysl = 12;
var all_limits = [12, 36, 108, 324, 972, 3000];
var tabledata = "";
layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'upload', 'transfer'], function () {
    var layer = layui.layer
    , transfer = layui.transfer
     , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;

    //监听工具条
    table.on('tool(table_rytable)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent == "bind") {
            //alert(data.GH);
            //div_bindContact
            layer.open({
                type: 1,
                shade: 0,
                area: ['900px', '600px'], //宽高
                content: $('#div_bindContact'),
                btn: ['保存', '取消'],
                title: '绑定设备',
                moveOut: true,
                success: function (layero, index) {
                    //var data2 = [
                    //              { "value": "1", "title": "瓦罐汤" ,"name":"1a"}
                    //              , { "value": "2", "title": "油酥饼", "name": "2a" }
                    //              , { "value": "3", "title": "炸酱面", "name": "3c" }
                    //              , { "value": "4", "title": "串串香", "name": "4d", "disabled": true }
                    //              , { "value": "5", "title": "豆腐脑", "name": "5e" }
                    //              , { "value": "6", "title": "驴打滚", "name": "6f" }
                    //              , { "value": "7", "title": "北京烤鸭", "name": "7z" }
                    //              , { "value": "8", "title": "烤冷面", "name": "8a" }
                    //              , { "value": "9", "title": "毛血旺", "name": "6", "disabled": true }
                    //              , { "value": "10", "title": "肉夹馍", "name": "12" }
                    //              , { "value": "11", "title": "臊子面", "name": "1dd" }
                    //              , { "value": "12", "title": "凉皮", "name": "ff1" }
                    //              , { "value": "13", "title": "羊肉泡馍", "name": "ff1" }
                    //              , { "value": "14", "title": "冰糖葫芦", "name": "1dd", "disabled": true }
                    //              , { "value": "15", "title": "狼牙土豆", "name": "1d" }
                    //                                ];
                    var gzzxall;
                    $.ajax({
                        type: 'post',
                        url: $('#Get_GZZX').val(),
                        async: false,
                        data: { gc: "" },
                        success: function (gzzxdata) {
                            gzzxall = JSON.parse(gzzxdata);

                        }
                    })
                    var selectdata;
                    $.ajax({
                        type: 'post',
                        url: $('#SelectContact').val(),
                        async: false,
                        data: { RYID: data.RYID  },
                        success: function (contactdata) {
                            selectdata = JSON.parse(contactdata);

                        }
                    })

                    if (gzzxall.length > 0) {
                        for (var i = 0; i < gzzxall.length; i++) {
                            gzzxall[i]["value"] = gzzxall[i].GC + "-" + gzzxall[i].GZZXBH;
                            gzzxall[i]["title"] = gzzxall[i].GC + "-" + gzzxall[i].GZZXBH + "-" + gzzxall[i].GZZXMS;
                        }
                        var selectedArr = [];
                        if (selectdata != null) {
                            for (var i = 0; i < selectdata.length; i++) {
                                //selectdata[i]["value"] = selectdata[i].GC + "-" + selectdata[i].GZZXBH;
                                //var c = selectdata[i]["value"];
                                selectedArr.push(selectdata[i].GC + "-" + selectdata[i].GZZXBH);
                                //contactdata[i]["title"] = contactdata[i].GC + "-" + contactdata[i].GZZXBH + "-" + contactdata[i].GZZXMS;
                            }
                        }
                       




                        //初始右侧数据
                        transfer.render({
                            elem: '#t_bindContact'
                          , data: gzzxall
                          , id: "t_bindContact"
                          , showSearch: true
                          , title: ['所有工作中心', data.YGNAME + "绑定的工作中心"]
                          , width: 400
                          , value: selectedArr
                        })
                    }




                },
                yes: function (index, layero) {
                    //获得右侧数据
                    var getData = transfer.getData('t_bindContact');
                    $.ajax({
                        type: 'post',
                        url: $('#ModifyContact').val(),

                        async: false,
                        data: { data: JSON.stringify(getData), RYID: data.RYID },
                        success: function (resdata) {
                            resdata = JSON.parse(resdata);
                            layer.msg(resdata.MESSAGE);
                            layer.close(index);
                        }
                    })






                    
                },
                end: function () {


                    form.render();
                }
            });
        }
    });





}
);

$('#noselect').on('blur', function () {
    if ($('#noselect').val() != "") {
        LoadTableData($('#noselect').val());
    }
});



function LoadTableData(condition) {
    var table = layui.table;
    var datastring = {

        NOSELECT: condition

    };
    var url = $('#GET_YGINFOURL').val();
    $.ajax({
        type: "POST",
        async: false,
        url: $('#GET_YGINFOURL').val(),
        data: {
            datastring: JSON.stringify(datastring),
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            tabledata = resdata.HR_RY_RYINFO_LIST;
            if (resdata.MES_RETURN.TYPE === "S") {
                var fyall = Math.ceil(resdata.HR_RY_RYINFO_LIST.length / all_fysl);
                if (fyall > all_fy - 1) {
                }
                else {
                    all_fy = Number(fyall);
                }
                table.render({
                    done: function (res, curr, count) {
                        for (var i = 0; i < all_limits.length; i++) {
                            if (all_limits[i] >= res.data.length) {
                                all_fysl = all_limits[i];
                                break;
                            }
                        }
                        all_fy = curr;
                    },
                    elem: '#table_rytable',
                    data: resdata.HR_RY_RYINFO_LIST,
                    cols: [[
                    //{ title: '序号', align: 'center', templet: '#indexTpl', width: 60, fixed: 'left' },
                    { type: 'numbers', title: '序号', width: 60, fixed: 'left' },
                    { field: 'GH', align: 'center', title: '工号', width: 90, fixed: 'left', sort: true },
                    { field: 'YGNAME', align: 'center', title: '姓名', fixed: 'left', width: 100 },
                    { field: 'YGTYPENAME', align: 'center', title: '员工类别', width: 100, sort: true },
                    { field: 'XB', align: 'center', title: '性别', width: 80, sort: true },
                    { field: 'ZZZTNAME', align: 'center', title: '在职状态', width: 100, sort: true },
                    { field: 'RZDATE', align: 'center', title: '入职日期', width: 150, sort: true },
                    //{ field: 'GLQSR', align: 'center', title: '工龄起算日', width: 150, sort: true },
                    //{ field: 'BIRTHDAT', align: 'center', title: '出生日期', width: 150, sort: true },
                    { field: 'DEPTNAME', align: 'center', title: '部门', width: 120 },
                    { field: 'GSBMNAME', align: 'center', title: '归属部门', width: 120 },
                    { field: 'GSNAME', align: 'center', title: '公司', width: 200 },

                    //{ field: 'ZZNO', align: 'center', title: '证照号码', width: 180 },

                    //{ field: 'ISECRZ', title: '是否二次入职', width: 150, templet: '#ISECRZ' },
                    { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                    ]],
                    page: {
                        limits: all_limits,
                        limit: all_fysl,
                        curr: all_fy
                    }
                });
                //$('#noselect').val("");
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        },
        error: function () {
            alert("数据列表加载失败");
        }
    })
}