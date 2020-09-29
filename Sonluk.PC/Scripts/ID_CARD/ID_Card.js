function idcard(idCard_id, age_id, sex_id, dess_id) {
    var idCard = $(idCard_id).val().toLocaleUpperCase();
    $(idCard_id).val(idCard);

    //根据身份证不同的位置，截取相对应的数据
    var sex = idCard.substring(16, 17);
    var num = idCard.substring(17, 18);
    var year = idCard.substring(6, 10);
    var month = idCard.substring(10, 12);
    var day = idCard.substring(12, 14);
    var age = year + "-" + month + "-" + day;
    var date = new Date(age);
    var sum = 0;
    var arr = [7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2];
    var arr2 = [1, 0, 'X', 9, 8, 7, 6, 5, 4, 3, 2];

    //计算第18位数 是否符合要求
    for (var i = 0; i < 17; i++) {
        sum += idCard.substring(i, i + 1) * arr[i]
    }
    if (num == arr2[sum % 11] || num === arr2[sum % 11]) {

        $(age_id).val(age)
        if (sex % 2 == 1) {
            $(sex_id).val("男")
        } else {
            $(sex_id).val("女")
        }

        var dataNum = mySite.cityData.length;
        for (var i = 0; i < dataNum; i++) {
            if (idCard.substring(0, 6) == mySite.cityData[i].code) {
                $(dess_id).val(mySite.cityData[i].title);
            }
        }

    } else {
        alert("身份证输入格式不对！")
        $(sex_id).val("")
        $(dess_id).val("");
        $(age_id).val("");
        return false;
    }
}
var result = "";
function checkid(formid) {
    var idCard = $(formid).val().toLocaleUpperCase();
    $(formid).val(idCard);
    var num = idCard.substring(17, 18);
    var sum = 0;
    var arr = [7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2];
    var arr2 = [1, 0, 'X', 9, 8, 7, 6, 5, 4, 3, 2];
    for (var i = 0; i < 17; i++) {
        sum += idCard.substring(i, i + 1) * arr[i]
    }
    if (num == arr2[sum % 11] || num === arr2[sum % 11]) {
        result = "S";
    } else {
        result = "E";
    }
}