
   

$(document).ready(function () {
        //$(document).ready(function () {
        //    alert("_InitScroll");
        //    eval(_InitScroll("A1","A2",550,19*6,4000));
        //    alert("_InitScroll");
        //});


        //function _InitScroll(_S1, _S2, _W, _H, _T) {
        //    return "var marqueesHeight" + _S1 + "=" + _H + ";var stopscroll" + _S1 + "=false;var scrollElem" + _S1 + "=document.getElementById('" + _S1 + "');with(scrollElem" + _S1 + "){style.width=" + _W + ";style.height=marqueesHeight" + _S1 + ";style.overflow='hidden';noWrap=true;}scrollElem" + _S1 + ".onmouseover=new Function('stopscroll" + _S1 + "=true');scrollElem" + _S1 + ".onmouseout=new Function('stopscroll" + _S1 + "=false');var preTop" + _S1 + "=0; var currentTop" + _S1 + "=0; var stoptime" + _S1 + "=0;var leftElem" + _S2 + "=document.getElementById('" + _S2 + "');scrollElem" + _S1 + ".appendChild(leftElem" + _S2 + ".cloneNode(true));setTimeout('init_srolltext" + _S1 + "()'," + _T + ");function init_srolltext" + _S1 + "(){scrollElem" + _S1 + ".scrollTop=0;setInterval('scrollUp" + _S1 + "()',50);}function scrollUp" + _S1 + "(){if(stopscroll" + _S1 + "){return;}currentTop" + _S1 + "+=1;if(currentTop" + _S1 + "==(marqueesHeight" + _S1 + "+1)) {stoptime" + _S1 + "+=1;currentTop" + _S1 + "-=1;if(stoptime" + _S1 + "==" + _T / 50 + ") {currentTop" + _S1 + "=0;stoptime" + _S1 + "=0;}}else{preTop" + _S1 + "=scrollElem" + _S1 + ".scrollTop;scrollElem" + _S1 + ".scrollTop +=1;if(preTop" + _S1 + "==scrollElem" + _S1 + ".scrollTop){scrollElem" + _S1 + ".scrollTop=0;scrollElem" + _S1 + ".scrollTop +=1;}}}";
    //}

        function showLocale(objD) {
            var str, colorhead, colorfoot;
            var yy = objD.getYear();
            if (yy < 1900) yy = yy + 1900;
            var MM = objD.getMonth() + 1;
            if (MM < 10) MM = '0' + MM;
            var dd = objD.getDate();
            if (dd < 10) dd = '0' + dd;
            var hh = objD.getHours();
            if (hh < 10) hh = '0' + hh;
            var mm = objD.getMinutes();
            if (mm < 10) mm = '0' + mm;
            var ss = objD.getSeconds();
            if (ss < 10) ss = '0' + ss;
            var ww = objD.getDay();
            if (ww == 0) colorhead = "<font color=\"#white\">";
            if (ww > 0 && ww < 6) colorhead = "<font color=\"#white\">";
            if (ww == 6) colorhead = "<font color=\"#008000\">";
            if (ww == 0) ww = "星期日";
            if (ww == 1) ww = "星期一";
            if (ww == 2) ww = "星期二";
            if (ww == 3) ww = "星期三";
            if (ww == 4) ww = "星期四";
            if (ww == 5) ww = "星期五";
            if (ww == 6) ww = "星期六";
            colorfoot = "</font>"
            //str = colorhead + yy + "-" + MM + "-" + dd + " " + hh + ":" + mm + ":" + ss + "  " + ww + colorfoot;
            str = yy + "-" + MM + "-" + dd + " " + hh + ":" + mm;
            return (str);
        }

        function PickingtaskList() {
            var panel = $("div#picking-task-list");
            var data = [];
            //alert(panel.next().val());
            panel.load(panel.next().val(),
                data,
                function (data, status) {
                    if (status == "success") {
                        //alert(data);
                    }
                    else {
                        panel.text(data);
                    }
                }
            );
        }

        function showmessage() {
            //var today;
            //today = new Date();
            //var marquee = $("div#picking-task-message");
            //marquee.text(today);

            var panel = $("div#picking-task-message");
            var data = [];
            panel.load(panel.next().val(),
                data,
                function (data, status) {
                    if (status == "success") {
                        //alert(data);
                    }
                    else {
                        panel.text(data);
                    }
                }
            );
        }
        
        function tick()
        {
            showmessage();
            PickingtaskList();
        }
        tick();
        setInterval(tick, 5000);
 
    }
)
