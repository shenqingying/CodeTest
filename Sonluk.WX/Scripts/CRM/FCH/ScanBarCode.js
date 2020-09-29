


function Scan(Appid, state, name, needResult, tabledata) {
    var layer = layui.layer;

    if (state != null) {
        var appid = Appid;
        var ticket;
        var url = encodeURIComponent(location.href.split('#')[0]);
        var mytimes;
        var mystr;
        var mysign;
        var link;

        $.ajax({
            type: "POST",
            async: false,
            url: "../Public/GetSignature",
            data: {
                urldata: url
            },
            success: function (res) {
                var sign = JSON.parse(res);
                mytimes = sign.Timestamp;
                mystr = sign.Noncestr;
                ticket = sign.Ticket;
                mysign = sign.Signa;

            },
            error: function (err) {
                alert("getSignErr" + err);
            }
        });

        wx.config({
            beta: true,// 必须这么写，否则在微信插件有些jsapi会有问题
            debug: false, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
            appId: appid, // 必填，公众号的唯一标识
            timestamp: mytimes, // 必填，生成签名的时间戳
            nonceStr: mystr, // 必填，生成签名的随机串
            signature: mysign,// 必填，签名，见附录1
            jsApiList: [
                'checkJsApi',
                        'scanQRCode',
            ]
        });



        wx.ready(function () {

            wx.scanQRCode({
                needResult: needResult, // 默认为0，扫描结果由微信处理，1则直接返回扫描结果，
                scanType: ["qrCode", "barCode"], // 可以指定扫二维码还是一维码，默认二者都有
                success: function (res) {
                    if (needResult == 1) {
                        var result = res.resultStr; // 当needResult 为 1 时，扫码返回的结果

                        //alert(result);
                        var barcode;
                        barcode = result.replace($("#dxm_url").val(), "").replace("CODE_128,", "");
                        $(name).val(barcode);

                        if (barcode.length != 15 && barcode.length != 12 && barcode.length != 18)
                            return false;


                        if (tabledata == null) {         //不传入值，现应用在表报查询功能
                            TableLoad(barcode);
                        }
                        else if (tabledata == "DXM") {     //应用于微信端查询扫码记录功能
                            var cxdata = {
                                DXM: barcode
                            };
                            TableLoad(cxdata);
                        }
                        else {              //现应用于扫码出货功能
                            var dxm;

                            if ($("#DXM").val().length == 15 || $("#DXM").val().length == 12) {
                                dxm = $("#DXM").val();
                            }
                            else {
                                dxm = $("#DXM").val().replace($("#dxm_url").val(), "");
                                if (dxm.length != 15 && dxm.length != 12) {
                                    return false;
                                }
                            }

                            var layerindex = layer.load();
                            try {
                                for (var i = 0; i < tabledata.length; i++) {
                                    if (dxm == tabledata[i].DXM) {
                                        layer.msg("该条码已经存在，请不要重复输入");
                                        $("#DXM").val("");
                                        $("#DXM").focus();
                                        layer.close(layerindex);
                                        return false;
                                    }
                                }


                                var json = {
                                    DXM: dxm
                                };
                                tabledata.push(json);

                                $.ajax({
                                    type: "POST",
                                    async: true,
                                    url: "../FCH/Data_VerifyBarCode",
                                    data: {
                                        barcode: JSON.stringify(tabledata)
                                    },
                                    success: function (resdata) {
                                        var res = JSON.parse(resdata);
                                        if (res.KEY == 0)
                                            layer.msg(res.MSG);


                                        TableLoad(tabledata);
                                        layer.close(layerindex);
                                    },
                                    error: function () {
                                        layer.close(layerindex);
                                        layer.alert("系统错误");
                                    }
                                });




                                $('#DXM').val("");
                                //location.href = "#maodian";
                                //location.href = "#DXM";
                                //$('#DXM').focus();


                                $('html,body').animate({
                                    scrollTop: $('.bottom').offset().top
                                }, 1);
                            }
                            catch (e) {
                                layer.close(layerindex);
                                layer.alert("系统错误");
                            }
                        }


                    }


                }
            });




        });

    }
    else {
        alert("code404,请联系管理员");
    }





}