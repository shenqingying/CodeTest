$.fn.table = function (freeze) {

    $("div.header-title").remove();
    $("div.left-title").remove();
    $("div.left-title-header").remove();

    var self = this;

    self.parent().append('<div class="header-title"><table class="header-title-table" style="width:' + (self.width() + 1) + 'px;display:block;"><tr></tr></table></div>');

    var headerTitle = $("table.header-title-table").find("tr:eq(0)");
    var width;
    self.find("tr:eq(0)").children().each(function () {
        width = $(this).width() + 1;
        //if (width == 66)
        //    width--;
        headerTitle.append('<td class="data-table-header sort-asc" style="width:' + width + 'px">' + $(this).text() + '</td>');
    });

    if (freeze > 0) {

        var leftTitle = $('<div class="left-title"></div>');
        var leftTitleHeader = $('<div class="left-title-header"></div>');
        self.parent().append(leftTitle);
        self.parent().append(leftTitleHeader);

        var leftTitleTable = $('<table class="left-title-table"></table>');
        var leftTitleHeaderTable = $('<table></table>');
        leftTitle.append(leftTitleTable);
        leftTitleHeader.append(leftTitleHeaderTable);
        var i = 1;
        self.find("tr").each(function () {
            var leftTitleTr = $("<tr></tr>");
            var leftTitleHeaderTr = $("<tr></tr>");
            leftTitleTable.append(leftTitleTr);
            leftTitleHeaderTable.append(leftTitleHeaderTr);

            $(this).find("td:lt(" + freeze + ")").each(function () {
                var data = $(this);
                if (i == 1) {
                    leftTitleTr.append('<td class="data-table-header">' + data.text() + '</td>');
                    leftTitleHeaderTr.append('<td class="data-table-header  sort-asc">' + data.text() + '</td>');

                } else {
                    leftTitleTr.append('<td>' + data.text() + '</td>');
                    leftTitleHeaderTr.append('<td>' + data.text() + '</td>');
                }
            });
            i++;
        });
    }

    TableResize();
};

function sort(self, asc) {

    if (asc)
        self.removeClass("sort-asc");
    else
        self.removeClass("sort-desc");


    var index = self.index();
    var table = $(".data-table");
    var leftTable = $(".left-title-table");
    var length = table.find("tr").length;
    var numeric = false;
    var result = true;

    var values = new Array();
    var current = table.find("tr:eq(0)");
    for (var i = 1; i < length ; i++) {
        current = current.next();
        values[i - 1] = new Array();
        values[i - 1][0] = i;
        values[i - 1][1] = current.find("td:eq(" + index + ")").text();;

    }

    for (var i = 0; i < length - 1; i++) {
        if (values[i][1] != "") {
            if (/^\d+(\.\d+)?$/.test(values[i][1]))
                numeric = true;
            break;
        }
    }

    if (numeric) {
        if (asc)
            values.sort(function (x, y) {
                return x[1] - y[1];
            });
        else
            values.sort(function (x, y) {
                return y[1] - x[1];
            });
    } else {
        if (asc)
            values.sort(function (x, y) {
                if (x[1] > y[1]) {
                    //alert(x[1] +">"+ y[1]);
                    return -1;
                } else if (x[1] < y[1]) {
                    //alert(x[1] + "<" + y[1]);
                    return 1;
                } else {
                    // alert(x[1] + "=" + y[1]);
                    return 0;
                }

            });
        else
            values.sort(function (x, y) {
                if (x[1] < y[1]) {
                    //alert(x[1] + "<" + y[1]);
                    return -1;
                } else if (x[1] > y[1]) {
                    //alert(x[1] + ">" + y[1]);
                    return 1;
                } else {
                    //alert(x[1] + "=" + y[1]);
                    return 0;
                }
            });
    }

    values.unshift(new Array());

    //values = bubbleSort(values, numeric, asc);
    //values = insert_sort(values, numeric, asc);
    //var valuesString = "";
    //for (var i = 1; i < length ; i++) {
    //    valuesString = valuesString + values[i][1] + ";";
    //}
    //alert(valuesString);

    var max = 0;
    for (var i = 1; i < length ; i++) {
        if (i != values[i][0]) {

            table.find("tr:eq(" + i + ")").before(table.find("tr:eq(" + values[i][0] + ")"));
            leftTable.find("tr:eq(" + i + ")").before(leftTable.find("tr:eq(" + values[i][0] + ")"));

            max = values[i][0];
            for (var j = i + 1; j < length; j++) {

                if (values[j][0] < max)
                    values[j][0]++;

            }
        }
    }
    if (asc)
        self.addClass("sort-desc");
    else
        self.addClass("sort-asc");


}

function bubbleSort(values, numeric, asc) {

    var length = values.length;
    var currentValue, nextValue;
    var temp;
    var exchange = true;
    while (exchange) {

        exchange = false;

        for (var i = 1; i < length - 1; i++) {

            currentValue = values[i][1];
            nextValue = values[i + 1][1];

            if (numeric) {
                if (currentValue == "")
                    currentValue = 0;
                if (nextValue == "")
                    nextValue = 0;

                if (asc)
                    result = parseFloat(currentValue) > parseFloat(nextValue);
                else
                    result = parseFloat(currentValue) < parseFloat(nextValue);
            } else {

                if (asc)
                    result = currentValue > nextValue;
                else
                    result = currentValue < nextValue;
            }

            if (result) {

                exchange = true;
                temp = values[i + 1];
                values[i + 1] = values[i];
                values[i] = temp;

            } else {
                //current = next;
                //currentValue = nextValue;
            }
        }
    }
    return values;
}

function quickSort(values, numeric, asc) {
    //var array = [8,4,6,2,7,9,3,5,74,5];
    //var array = [0,1,2,44,4,324,5,65,6,6,34,4,5,6,2,43,5,6,62,43,5,1,4,51,56,76,7,7,2,1,45,4,6,7];
    var i = 0;
    var j = values.length - 1;
    var Sort = function (i, j) {

        // 结束条件
        if (i == j) {
            return
        };

        var key = values[i];
        var stepi = i; // 记录开始位置
        var stepj = j; // 记录结束位置
        while (j > i) {
            // j <<-------------- 向前查找
            if (values[j][1] >= key[1]) {
                j--;
            } else {
                values[i][1] = values[j][1]
                //i++ ------------>>向后查找
                while (j > ++i) {
                    if (values[i][1] > key[1]) {
                        values[j][1] = values[i][1];
                        break;
                    }
                }
            }
        }

        // 如果第一个取出的 key 是最小的数
        if (stepi == i) {
            Sort(++i, stepj);
            return;
        }

        // 最后一个空位留给 key
        values[i] = key;

        // 递归
        Sort(stepi, i);
        Sort(j, stepj);
    }

    Sort(i, j);

    return values;
}

function insertSort(values, numeric, asc) {

    // http://baike.baidu.com/image/d57e99942da24e5dd21b7080
    // http://baike.baidu.com/view/396887.htm
    //var array = [0,1,2,44,4,324,5,65,6,6,34,4,5,6,2,43,5,6,62,43,5,1,4,51,56,76,7,7,2,1,45,4,6,7];
    var i = 1,
    j, step, key, len = array.length;

    for (; i < len; i++) {

        step = j = i;
        key = array[j];

        while (--j > -1) {
            if (array[j] > key) {
                array[j + 1] = array[j];
            } else {
                break;
            }
        }

        array[j + 1] = key;
    }

    return array;
}

function shellSort(values, numeric, asc) {

    // http://zh.wikipedia.org/zh/%E5%B8%8C%E5%B0%94%E6%8E%92%E5%BA%8F
    // var array = [13,14,94,33,82,25,59,94,65,23,45,27,73,25,39,10];
    var stepArr = [1750, 701, 301, 132, 57, 23, 10, 4, 1]; // reverse() 在维基上看到这个最优的步长 较小数组
    //var stepArr = [1031612713, 217378076, 45806244, 9651787, 2034035, 428481, 90358, 19001, 4025, 836, 182, 34, 9, 1]//针对大数组的步长选择
    var i = 0;
    var stepArrLength = stepArr.length;
    var len = array.length;
    var len2 = parseInt(len / 2);

    for (; i < stepArrLength; i++) {
        if (stepArr[i] > len2) {
            continue;
        }

        stepSort(stepArr[i]);
    }

    // 排序一个步长
    function stepSort(step) {

        //console.log(step) 使用的步长统计
        var i = 0,
        j = 0,
        f, tem, key;
        var stepLen = len % step > 0 ? parseInt(len / step) + 1 : len / step;

        for (; i < step; i++) { // 依次循环列
            for (j = 1;
                /*j < stepLen && */
            step * j + i < len; j++) { //依次循环每列的每行
                tem = f = step * j + i;
                key = array[f];

                while ((tem -= step) >= 0) { // 依次向上查找
                    if (array[tem] > key) {
                        array[tem + step] = array[tem];
                    } else {
                        break;
                    }
                }

                array[tem + step] = key;

            }
        }

    }

    return array;

}

function insert_sort(values, numeric, asc) {
    var count = values.length;
    for (var i = 1; i < count; ++i) {
        for (var j = i; j < count; ++j) {
            if (values[i][1] > values[j][1]) {
                swap(values, i, j);
            }
        }
    }

    return values;
}

function swap(values, i, j) {
    var tmp = values[i];
    values[i] = values[j];
    values[j] = tmp;
}

//伴随显示按钮区域
function selfAdaptionDisplayShow() {
    $("div.sonluk-table-control-self-adaption-display").fadeIn();
}

function selfAdaptionDisplayHide() {
    $("div.sonluk-table-control-self-adaption-display").fadeOut();
}

function selfAdaptionDisplayToggle() {
    if ($(".row-selected").length == 0) {
        selfAdaptionDisplayHide();
    }
    else {
        selfAdaptionDisplayShow();
    }
}

function selectAll() {
    $("table.left-title-table").find("tr:gt(0)").addClass("row-selected");
    $("table.data-table").find("tr:gt(0)").addClass("row-selected");
    selfAdaptionDisplayShow();
}

function responseInfo(time) {
    var now = new Date();
    $("div.sonluk-table-control-response-time").text($("input#node-count").val() + " " + (now - time) / 1000);
}

$(document).ready(function () {

    $(document).bind("keydown", function (e) {
        e = window.event || e;
        if (e.keyCode == 116) {
            e.keyCode = 0;
            return false;
        }
    });

    //冻结项移动
    $("div.sonluk-table-content").scroll(function (event) {
        $("table.header-title-table").css("margin-left", -($(this).scrollLeft()));
        $("table.left-title-table").css("margin-top", -($(this).scrollTop()));
    });

    //选定/取消
    $(document).on("click", "table.left-title-table tr", function () {
        $(this).toggleClass("row-selected");
        $("table.data-table").find("tr:eq(" + $(this).index() + ")").toggleClass("row-selected");;
        selfAdaptionDisplayToggle();
    })
    $(document).on("click", "table.data-table tr", function () {
        $(this).toggleClass("row-selected");
        $("table.left-title-table").find("tr:eq(" + $(this).index() + ")").toggleClass("row-selected");;
        selfAdaptionDisplayToggle();
    })

    //全选
    $(document).on("click", ".row-select-all", function () {
        selectAll();
    })

    //清除所有选择
    $(document).on("click", ".row-select-cancel-all", function () {
        $(".row-selected").removeClass("row-selected");
        selfAdaptionDisplayHide();
    })

    //反选
    $(document).on("click", ".row-select-invert", function () {
        $("table.left-title-table").find("tr:gt(0)").addClass("row-forward-selected");
        $("table.data-table").find("tr:gt(0)").addClass("row-forward-selected");
        $(".row-selected").removeClass("row-forward-selected");
        $(".row-selected").removeClass("row-selected");
        $(".row-forward-selected").addClass("row-selected");
        $(".row-forward-selected").removeClass("row-forward-selected");
        selfAdaptionDisplayToggle();
    })

    //全选所属行项目
    $(document).on("click", ".item-select-all", function () {
        var number = $("table.left-title-table").find("tr.row-selected:eq(0)").find("td:eq(0)").text();

        $(".row-selected").removeClass("row-selected");


        $("table.left-title-table").find("tr:gt(0)").each(function () {
            var node = $(this);
            if (node.find("td:eq(0)").text() == number) {

                node.addClass("row-selected");

                $("table.data-table").find("tr:eq(" + node.index() + ")").addClass("row-selected");
            }

        });
    })

    //升序
    $(document).on("click", ".sort-asc", function () {

        var startDate = new Date();

        sort($(this), true);

        var endDate = new Date();
        $("div.time").text("ASC    " + (endDate - startDate) / 1000 + "S");
    });

    //降序
    $(document).on("click", ".sort-desc", function () {

        var startDate = new Date();

        sort($(this), false);

        var endDate = new Date();
        $("div.time").text("DESC    " + (endDate - startDate) / 1000 + "S");
    });


    function sortOLD(self) {

        self.removeClass("sort-asc");
        self.addClass("sort-desc");

        var index = self.index();
        var table = $(".data-table");
        var leftTable = $(".left-title-table");
        var length = table.find("tr").length;
        var numeric = false;
        var result = true;
        var exchange = true;

        for (var i = 1; i < length - 1; i++) {
            var value = table.find("tr:eq(" + i + ")").find("td:eq(" + index + ")").text();
            if (value != "") {
                if (/^\d+(\.\d+)?$/.test(value))
                    numeric = true;
                break;
            }
        }

        while (exchange) {

            exchange = false;
            var current, next, currentValue, nextValue;
            current = table.find("tr:eq(1)");
            currentValue = current.find("td:eq(" + index + ")").text();

            for (var i = 1; i < length - 1; i++) {
                next = current.next();
                nextValue = next.find("td:eq(" + index + ")").text();

                if (numeric) {
                    if (currentValue == "")
                        currentValue = 0;
                    if (nextValue == "")
                        nextValue = 0;
                    result = parseFloat(currentValue) > parseFloat(nextValue);
                }
                else {
                    result = currentValue > nextValue;
                }

                if (result) {
                    exchange = true;
                    current.before(next);
                    leftTable.find("tr:eq(" + i + ")").before(leftTable.find("tr:eq(" + (i + 1) + ")"));
                }
                else {
                    current = next;
                    currentValue = nextValue;
                }
            }
        }


    }

    function quickSort(array) {
        function sort(prev, numsize) {
            var nonius = prev;
            var j = numsize - 1;
            var flag = array[prev];
            if ((numsize - prev) > 1) {
                while (nonius < j) {
                    for (; nonius < j; j--) {
                        if (array[j] < flag) {
                            array[nonius++] = array[j];　//a[i] = a[j]; i += 1;
                            break;
                        };
                    }
                    for (; nonius < j; nonius++) {
                        if (array[nonius] > flag) {
                            array[j--] = array[nonius];
                            break;
                        }
                    }
                }
                array[nonius] = flag;
                sort(0, nonius);
                sort(nonius + 1, numsize);
            }
        }
        sort(0, array.length);
        return array;
    }

    function merge(left, right) {
        var result = [];
        while (left.length > 0 && right.length > 0) {
            if (left[0] < right[0]) {
                /*shift()方法用于把数组的第一个元素从其中删除，并返回第一个元素的值。*/
                result.push(left.shift());
            } else {
                result.push(right.shift());
            }
        }
        return result.concat(left).concat(right);
    }

    function mergeSort(items) {
        if (items.length == 1) {
            return items;
        }
        var middle = Math.floor(items.length / 2),
        left = items.slice(0, middle),
        right = items.slice(middle);
        return merge(mergeSort(left), mergeSort(right));
    }
});