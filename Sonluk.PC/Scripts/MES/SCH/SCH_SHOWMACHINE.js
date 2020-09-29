//@{
//    ViewBag.Title = "SCH_SHOWMACHINE";
//}
//<script src="~/Scripts/jquery-1.8.2.min.js"></script>
//    <link href="~/Scripts/layui2.2.5/css/layui.css" rel="stylesheet" />
//    <script src="~/Scripts/layui2.2.5/layui.all.js"></script>
//    <script src="~/Scripts/sonlui.min.js"></script>
//    <script src="~/Scripts/MES/SCH/SCH_SHOWMACHINE.js"></script>
//    <script src="~/Scripts/EM/zwk.js"></script>
//    <link href="~/Content/swiper-bundle.min.css" rel="stylesheet" />
//    <script src="~/Scripts/Echarts/echarts.min.js"></script>
//    <script src="~/Scripts/swiper-bundle.min.js"></script>
//    <style>
//        .up {
//            animation: slideUp 0.3s forwards;
//    }

//    .down {
//            animation: slideDown 0.3s forwards;
//    }

//    @@keyframes slideDown {
//            from {
//        margin-top:-64px;
//    }

//        to {
//            margin - top: 0px;
//    }
//}

//    @@keyframes slideUp {
//            from {
//        margin-top: 0px;
//    }

//        to {
//            margin - top: -64px;
//    }
//}


//    .div-a {
//            position: absolute;
//        left: 0px;
//        top: 0px;
//        background: #fafafa;
//        width: 100%;
//        height: 64px;
//        z-index:999
//    }
//    /* css注释说明： 背景为红色 */
//    .div-c {
//            position: absolute;
//        left: 0px;
//        top: 0px;
//        background: #FF0;
//        width: 100%;
//        height:100px

//    }
//    /* css注释说明： 背景为红色 */
//    .div-b {
//            position: absolute;
//        left: 0px;
//        top: 100px;
//        background: #FF0;
//        width: 100%;
//    }
//    .grid-a {

//            grid - gap: 15px;
//        display: grid;
//        grid-template-columns: repeat(auto-fit, minmax(350px,1fr));
//        grid-auto-rows: 350px;
//        justify-content: center;
//        align-content:center;

//    }

//    .grid-a>div{
//            margin: 0 auto;
//    }
//</style>


//    <body>
//        <input type="hidden" value="@Url.Action(" ReadSY_GZZX_SBBH", "SCH")" id="ReadSY_GZZX_SBBH" />
//    <input type="hidden" value="@Url.Action(" GET_GZZX_BYGC", "PD", new {area = "MES"})" id="url_gzzx" />
//    <input type="hidden" value="@Url.Action(" ReadDW_MES_SBBH_OUTPUT_DAY", "SCH", new {area = "MES"})" id="ReadDW_MES_SBBH_OUTPUT_DAY" />
//    <input type="hidden" value="@Url.Action(" ReadPD_SCRW_SJJL", "SCH")" id="ReadPD_SCRW_SJJL" />
     
     
//    <input hidden type="text" value="@ViewBag.ID" id="input_staffid" />
//        <div class="layui-form">
//            <div class="div-a" id="topChoiceDiv">
//                <div style="padding-top:13px"></div>
//                <div class="layui-inline">
//                    <label class="layui-form-label" lid="label1">工厂：</label>
//                    <div class="layui-input-inline">
//                        <select id="in_gc" lay-filter="in_gc">
//                            @if (Model.MES_SY_GC.Length == 1)
//                        {
//                                <option selected="selected" value="@Model.MES_SY_GC[0].GC">@Model.MES_SY_GC[0].GC-@Model.MES_SY_GC[0].GCMS</option>
//                            }
//                            else
//                        {
//                                <option value="" selected="selected" lid="c_selectplz">请选择</option>
//                            for (int i = 0; i < Model.MES_SY_GC.Length; i++)
//                            {
//                                <option value="@Model.MES_SY_GC[i].GC">@Model.MES_SY_GC[i].GC-@Model.MES_SY_GC[i].GCMS</option>
//                            }
//                            }
//                    </select>
//                    </div>
//                </div>
//                <div class="layui-inline">
//                    <label class="layui-form-label" lid="label2">工作中心：</label>
//                    <div class="layui-input-inline">
//                        <select id="in_gzzx" lay-filter="in_gzzx">
//                            <option value="" selected="selected" lid="c_selectplz">请选择</option>
//                        </select>
//                    </div>
//                </div>
//                <div class="layui-inline">
//                    <label class="layui-form-label" lid="label3" style="width:100px">刷新（秒）：</label>
//                    <div class="layui-input-inline">
//                        <input type="number" autocomplete="off" class="layui-input" id="in_refresh" style="width:100px" value="30">
//                </div>
//                    </div>
//                    <div class="layui-inline" style="padding-left:25px">
//                        <button class="layui-btn" lid="btn1" id="btn1" onclick="StartShow()">启动</button>
//                    </div>
//                    <div style="padding-bottom:13px"></div>
//                </div>

//                <div class="div-c" id="TitleDiv" style="background:#0B0B3B">
//                    <div style="font-size:26px;text-align:center;padding-top:10px">
//                        <h1 style="color:#e0e0e0">
//                            车间生产进度
//                </h1>
//                    </div>
//                </div>
//                <div class="swiper-container div-b" id="ContentDiv">
//                </div>

//            </div>



//</body>
//        <script>
//            var init = false;
//            var startLoop = false;
//            var mySwiper;
//    layui.use([], function () {
//        var table = layui.table;
//            var form = layui.form;
//            var element = layui.element;
//            var layer = layui.layer;
//            var id = document.getElementById('input_staffid').value;
//            divSetConfig();
//        form.on('select(in_gc)', function (data) {
//            var GC = $('#in_gc').val();
//            if (GC === "") {
//                $("#in_gzzx").html("");
//            $('#in_gzzx').append(new Option(common.c_selectplz, ""));
//            form.render();
//        }
//            else {
//                var url = document.getElementById('url_gzzx').value;
//                $.ajax({
//                type: "POST",
//            async: false,
//            url: url,
//                    data: {
//                GC: GC
//        },
//                    success: function (data) {
//                        var resdata = JSON.parse(data);
//            $("#in_gzzx").html("");
//            $('#in_gzzx').append(new Option(common.c_selectplz, ""));
//            var rstcount = resdata.length;
//                        if (rstcount > 0) {
//                            for (var i = 0; i < resdata.length; i++) {
//                $('#in_gzzx').append(new Option(resdata[i].GZZXBH + "-" + resdata[i].GZZXMS, resdata[i].GZZXBH));
//            }
//        }
//        form.render();
//    }
//});
//}
//});
//var refreshValue = localStorage.getItem('in_refresh');
//        if (refreshValue != null || refreshValue != undefined) {
//                document.getElementById('in_refresh').value = refreshValue;
//            }
//            var in_gc = localStorage.getItem('in_gc');
//        if (in_gc != null || in_gc != undefined) {
//                document.getElementById('in_gc').value = in_gc;
//            var url = document.getElementById('url_gzzx').value;
//            $.ajax({
//                type: "POST",
//            async: false,
//            url: url,
//                data: {
//                GC: in_gc
//        },
//                success: function (data) {
//                    var resdata = JSON.parse(data);
//            $("#in_gzzx").html("");
//            $('#in_gzzx').append(new Option(common.c_selectplz, ""));
//            var rstcount = resdata.length;
//                    if (rstcount > 0) {
//                        for (var i = 0; i < resdata.length; i++) {
//                $('#in_gzzx').append(new Option(resdata[i].GZZXBH + "-" + resdata[i].GZZXMS, resdata[i].GZZXBH));
//            }
//        }
//        var in_gzzx = localStorage.getItem('in_gzzx');
//                    if (in_gzzx != null || in_gzzx != undefined) {
//                document.getElementById('in_gzzx').value = in_gzzx;
//            }
//            form.render();
//        }
//    });
//}
//form.render();
//$$('topChoiceDiv').classList.add('up');
//})
//    window.onresize = function () {
//                divSetConfig();
//            }
        
//    function divSetConfig() {
//        var height = document.body.clientHeight;
//            document.getElementById('ContentDiv').style.height = height - 100;
    
//        }
      
//    function StartShow() {
//        var gc = document.getElementById('in_gc').value;
//            var gzzxbh = document.getElementById('in_gzzx').value;
//            var refresh = document.getElementById('in_refresh').value;
//        if (gc == '') {
//                sonluk.msg.warn('工厂不能为空', 0);
//            return;
//        }
//        if (gzzxbh == '') {
//                sonluk.msg.warn('工作中心不能为空', 0);
//            return;
//        }
//        if (refresh <= 0) {
//                sonluk.msg.warn('刷新频率不能为空', 0);
//            return;
//        }
//        var data = {
//                GC: gc,
//            GZZXBH: gzzxbh
//        };
//        var load = layer.load(1);
//        $.ajax({
//                type: 'Post',
//            url: $('#ReadSY_GZZX_SBBH').val(),
//            data: {
//                data: JSON.stringify(data)
//        },
//            success: function (data) {
//                data = JSON.parse(data).data;
//            if (data.length > 0) {
//                //ReadDW_MES_SBBH_OUTPUT_DAY
//                HttpRequest.ReadDW_MES_SBBH_OUTPUT_DAY({
//                    data: {
//                        GZZXBH: gzzxbh,
//                        GC: gc
//                    }
//                    , success: function (dwdata) {
//                        layer.close(load);

//                        HttpRequest.ReadBillSCRWTIME({
//                            data: {
//                                GC: gc,
//                                GZZXBH: gzzxbh
//                            },
//                            success: function (sbztdata) {
//                                ConfigUI(data, dwdata, sbztdata);
//                            },
//                            error: function (msg) {
//                                sonluk.msg.open(msg, 'I', 0);
//                            }

//                        })



//                    },
//                    error: function (msg) {
//                        layer.close(load);
//                    }
//                })


//                //ConfigUI(data);
//            } else {
//                layer.close(load);
//            sonluk.msg.open('没有设备信息', 'I', 0);
//        }
//    },
//            error: function () {
//                sonluk.msg.open(sonluklv.alert1);
//            layer.close(load);
//        }
//    })
//    //sonluk.save.cover('in_refresh');
//    localStorage.setItem('in_refresh', refresh);
//    localStorage.setItem('in_gc', gc);
//    localStorage.setItem('in_gzzx', gzzxbh);
//}
//    var HttpRequest = {
//                ReadDW_MES_SBBH_OUTPUT_DAY: function (input) {
//            var data = {
//                GZZXBH: input.data.GZZXBH,
//            GC: input.data.GC,
//            KSRQ: getNowFormatDay(),
//            JSRQ: getNowFormatDay()
//        }
//            $.ajax({
//                type: 'POST',
//            url: document.getElementById('ReadDW_MES_SBBH_OUTPUT_DAY').value,
//                data: {
//                data: JSON.stringify(data)
//        },
//                success: function (data) {
//                data = JSON.parse(data);
//            if (data.success) {
//                input.success(data.data);
//            } else {
//                input.error('获取设备生产信息大数据异常')

//            }
//            },
//                error: function (e) {

//            }
//            })
//        },
//        ReadBillSCRWTIME: function (input) {
//            @*@STATUS = 1,
//		@GC = N'1000',
//		@GZZXBH = N'Z3009',
//		@JLKSTIME = N'2020-08-28',
//		@JLJSTIME = N'2020-08-28'*@
//            var data = {
//                STATUS: 1,
//            GC: input.data.GC,
//            GZZXBH: input.data.GZZXBH,
//            JLKSTIME: getNowFormatDay(),
//            JLJSTIME: getNowFormatDay()
//        }
//            $.ajax({
//                type: 'POST',
//            url: document.getElementById('ReadPD_SCRW_SJJL').value,
//                data: {
//                data: JSON.stringify(data)
//        },
//                success: function (data) {
//                data = JSON.parse(data);
//            if (data.success) {
//                input.success(data.data);
//            } else {
//                input.error('读取设备实时工作状态失败')

//            }
//            },
//                error: function (e) {
//                input.error('读取设备实时工作状态失败')
//            }
//            })


//        }

//    }






//    function ConfigUI(data, dw_data,sbztdata) {
//        var alldiv = document.getElementById('ContentDiv');
//            alldiv.innerHTML = '';
//            //div class="swiper-wrapper"  id = "div_UI"
    
    
//            var div = document.createElement('div');
//            div.setAttribute('id', 'div_UI');
//            div.classList.add('swiper-wrapper');
//            alldiv.append(div);
//            var screenWidth = document.getElementById('div_UI').clientWidth;
//            var screenHeight = document.getElementById('div_UI').clientHeight;
    
//        var rect = {
//                width: 350,
//            height: 350
//        };
//        @* <div class="swiper-slide" style="background:#ff0000">slider1</div>
//            <div class="swiper-slide" style="background:#ff0">slider2</div>
//            <div class="swiper-slide" style="background:#0ff">slider3</div>*@
//        var rowCount = parseInt((screenWidth - 20) / rect.width);
//        var colCount = parseInt(screenHeight / rect.height);
//        var pageCount = rowCount * colCount;
//        var countPageCount = Math.ceil(data.length / pageCount);
//        var sbBigArr = [];
//        var interval = 0;
//        var subArr = [];
//        for (var i = 0; i < data.length; i++) {
//            if (interval < pageCount) {
//                subArr.push(data[i]);
//            interval++;
//            } else {
//                i--;
//            sbBigArr.push(subArr);
//            subArr = [];
//            interval = 0;;
//        }
//    }
//    sbBigArr.push(subArr);
//        for (var i = 0; i < countPageCount; i++) {
//            var pageDiv = document.createElement('div');
//            pageDiv.classList.add('swiper-slide');
//            var griddiv = document.createElement('div');
//            griddiv.classList.add('grid-a');
//            griddiv.style.position = 'relative';
//            pageDiv.append(griddiv);
//            for (var j = 0; j < sbBigArr[i].length; j++) {
                
//                var subdiv = document.createElement('div');//每块的div
//            subdiv.style.height = rect.height;
//            subdiv.style.width = rect.width;
//            var statusms = sbBigArr[i][j].STATUSMS;
//            var currsbStruct;
//            var currdw_data;
//            var exist = false;
//            var existDW = false;
//                if (statusms == '' || statusms == '正常') {
                    
                    
//                    for (var x = 0; x < sbztdata.length; x++) {
//                        if (sbBigArr[i][j].SBBH == sbztdata[x].SBBH) {
//                exist = true;
//            currsbStruct = sbztdata[x];
//            break;
//        }
//    }
//                    if (exist) {
//                subdiv.style.background = '#4cff00';
//            } else {
//                subdiv.style.background = '#D8D8D8';
//            }
//                    for (var x = 0; x < dw_data.length; x++) {
//                        if (sbBigArr[i][j].SBBH == dw_data[x].SBBH) {
//                existDW = true;
//            currdw_data = dw_data[x];
//            break;
//        }
//    }




//                } else {
//                subdiv.style.background = '#f00';
//            }
//            var font22height = 29;
//            var defaultleft = 5;
//            var defaluttop = 3;
//            var defalutmargin = 2;
//            var index = 0;
//            var sbbhlabel = document.createElement('label');
//            sbbhlabel.innerHTML = sbBigArr[i][j].SBMS;
//            sbbhlabel.style.textAlign = 'right';
//            sbbhlabel.style.width = '100%';
//            sbbhlabel.style.paddingRight = 5;
//            sbbhlabel.style.display = 'inline-block';
//            sbbhlabel.style.fontSize = '40px';
//            subdiv.append(sbbhlabel);
//                if (exist) {
//                    var scddlabel = document.createElement('div');
//                    if (currsbStruct.ERPNO == '') {
//                scddlabel.innerHTML = '生产订单:' + currsbStruct.ERPNO;
//            } else {
//                scddlabel.innerHTML = '生产订单:' + currsbStruct.GDDH;
//            }
//            scddlabel.style.marginTop = -40;
//            //scddlabel.style.position = 'absolute';
//            scddlabel.style.fontSize = '22px';
//            subdiv.append(scddlabel);
//            index++;
//            var wlhlabel = document.createElement('div');
//            wlhlabel.innerHTML = '物料编码:' + currsbStruct.WLH;
//            wlhlabel.style.fontSize = '22px';
//            subdiv.append(wlhlabel);
//            index++;
//            var sssllabel = document.createElement('div');
//            sssllabel.innerHTML = currdw_data.SSSL != undefined ? '累计产量:' + currdw_data.SSSL + '(' + currdw_data.UNITMS + ')' :'设备累计产量:暂无数据';
//            sssllabel.style.fontSize = '22px';
//            subdiv.append(sssllabel);
//                    //<div id="main" style="width:100%;height:500px;"></div>
//            //var height = 350 - 100;
//            var chartdiv = document.createElement('div');
//            chartdiv.style.height = 250;
//            var myChart = echarts.init(chartdiv);
//            subdiv.append(chartdiv);
//            myChart.clear();//数据先清空
//                    myChart.setOption({
//                series: [
//                            {
//                name: '访问来源',
//            type: 'pie',    // 设置图表类型为饼图
//            radius: '55%',  // 饼图的半径，外半径为可视区尺寸（容器高宽中较小一项）的 55% 长度。
//            data: [          // 数据数组，name 为数据项名称，value 为数据项值
//                                    {value: 235, name: '视频广告' },
//                                    {value: 274, name: '联盟广告' },
//                                    {value: 310, name: '邮件营销' },
//                                    {value: 335, name: '直接访问' },
//                                    {value: 400, name: '搜索引擎' }
//        ]
//    }
//]
//})

//}
//griddiv.append(subdiv);
//}
//div.appendChild(pageDiv);
//}

//        if (countPageCount > 1 ) {
//                mySwiper = new Swiper('.swiper-container', {
//                    autoplay: true,//可选选项，自动滑动，
//                    loop: true,
//                    speed: 3000
//                })
//            } else {

//            }








//            }
        
        
        
        
        
        
        
//            document.getElementById('ContentDiv').addEventListener('mousemove', mouseMove)
//    function mouseMove(ev) {
//                ev = ev || window.event;
//            var mousePos = mousePosition(ev);
//        if (mousePos.y < 350) {          
//            if (document.getElementById('topChoiceDiv').className.indexOf('up') != -1) {
//                document.getElementById('topChoiceDiv').classList.remove('up');
//            document.getElementById('topChoiceDiv').classList.add('down');
//        }

//        } else {
//            if (document.getElementById('topChoiceDiv').className.indexOf('down') != -1) {
//                document.getElementById('topChoiceDiv').classList.remove('down');
//            }

//            $$('topChoiceDiv').classList.add('up');
//        }
//    }
//    function mousePosition(ev) {
//        if (ev.pageX || ev.pageY) {
//            return {x: ev.pageX, y: ev.pageY };
//        }
//        return {
//                x: ev.clientX + document.body.scrollLeft - document.body.clientLeft,
//            y: ev.clientY + document.body.scrollTop - document.body.clientTop
//        };
//    }

//</script>