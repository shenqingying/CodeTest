var common = sonluk.value.global.common;
var sonluklv = sonluk.value.global.lv;
//var baseurl = 'http://192.168.0.107/API/API/';
var baseurl = 'http://localhost:20597/API/';
var token = "?ptoken=" + sonluk.cookie.get("token");

function $$(selector) {
    return document.getElementById(selector);
}

function VerifyNo(data) {
    return /^[1-9][0-9]*([\.][0-9]{1,3})?$/.test(data);

}
function VerifyNolengTen(data) {
    return /^\d{ 10 } ?$/.test(data);
}
function VerifyInt(data) {
    return /^[1-9][0-9]*?$/.test(data);

}
function Clock(selector,prefix) {
    setInterval(function () {
        var sjdiv = document.getElementById(selector);
        var date = new Date();
        var year = date.getFullYear();
        var month = date.getMonth() + 1;
        var day = date.getDate();

        var hour = date.getHours();
        turnDate(hour);
        var min = date.getMinutes();
        turnDate(min);
        var sec = date.getSeconds();
        sec = turnDate(sec);
        sjdiv.innerHTML = prefix + year + "年" + month + "月" + day + "日 " + hour + ":" + min + ":" + sec;

    }, 1000)

   
}
function turnDate(date) {
    if (date < 10) {
        return date = "0" + date
    } else {
        return date
    }
}



function getNowFormatDay(Addday) {
    var char = "-";
    var nowDate = new Date();
    if (Addday != null) {
        nowDate.setDate(nowDate.getDate() + Addday);
    }
    var day = nowDate.getDate();
    var month = nowDate.getMonth() + 1;//注意月份需要+1
    var year = nowDate.getFullYear();
    //补全0，并拼接
    return year + char + completeDate(month) + char + completeDate(day);
}
//获取当前时间，格式YYYY-MM-DD HH:mm:ss
function getNowFormatTime() {
    var nowDate = new Date();
    var colon = ":";
    var h = nowDate.getHours();
    var m = nowDate.getMinutes();
    var s = nowDate.getSeconds();
    //补全0，并拼接
    return getNowFormatDay(nowDate) + " " + completeDate(h) + colon + completeDate(m) + colon + completeDate(s);
}
function sysTime() {

    var myDate = new Date();

    var year = myDate.getFullYear();

    var month = myDate.getMonth() + 1;

    var date = myDate.getDate();

    var h = myDate.getHours();

    var m = myDate.getMinutes();

    var s = myDate.getSeconds();

    var now = year + '-' + getMakeZero(month) + "-" + getMakeZero(date) + " " + getMakeZero(h) + ':' + getMakeZero(m) + ":" + getMakeZero(s);

    return now;
}
/**
   *  时间补0
   * 
   * @return 返回时间类型 yyyy-MM-dd HH:mm:ss
   */

function getMakeZero(s) {



    return s < 10 ? '0' + s : s;

}

//补全0
function completeDate(value) {
    return value < 10 ? "0" + value : value;
}
var ExportTempletExcel = "Helper/File/ExportTempletExcel"
var ReadSY_TYPEMX = 'MES/SY/ReadSY_TYPEMX';

var CreateSY_CN = "MES/SCH/CreateSY_CN";
var UpdateSY_CN = "MES/SCH/UpdateSY_CN";
var ReadSY_CN = "MES/SCH/ReadSY_CN";
var DeleteSY_CN = "MES/SCH/DeleteSY_CN";
var ExportSY_CN = "MES/SCH/ExportByExcel";

var CreateSY_GYLX = "MES/SCH/CreateSY_GYLX";
var UpdateSY_GYLX = "MES/SCH/UpdateSY_GYLX";
var ReadSY_GYLX = "MES/SCH/ReadSY_GYLX";
var DeleteSY_GYLX = "MES/SCH/DeleteSY_GYLX";
var ExportSY_GYLX = "MES/SCH/ExportSY_GYLX"; 
var ImportSY_GYLX = "MES/SCH/ImportSY_GYLXByExcel"; 
