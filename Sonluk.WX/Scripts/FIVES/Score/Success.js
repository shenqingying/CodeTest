



$(document).ready(function () {
    var data;
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;

    var appid = $("#appid").val();
    var state = $("#state").val();

    
    $("#btn_continu").click(function () {
        
        ScanPF(appid, state);

    });








});