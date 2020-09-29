/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId]) {
/******/ 			return installedModules[moduleId].exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		if(!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, { enumerable: true, get: getter });
/******/ 		}
/******/ 	};
/******/
/******/ 	// define __esModule on exports
/******/ 	__webpack_require__.r = function(exports) {
/******/ 		if(typeof Symbol !== 'undefined' && Symbol.toStringTag) {
/******/ 			Object.defineProperty(exports, Symbol.toStringTag, { value: 'Module' });
/******/ 		}
/******/ 		Object.defineProperty(exports, '__esModule', { value: true });
/******/ 	};
/******/
/******/ 	// create a fake namespace object
/******/ 	// mode & 1: value is a module id, require it
/******/ 	// mode & 2: merge all properties of value into the ns
/******/ 	// mode & 4: return value when already ns object
/******/ 	// mode & 8|1: behave like require
/******/ 	__webpack_require__.t = function(value, mode) {
/******/ 		if(mode & 1) value = __webpack_require__(value);
/******/ 		if(mode & 8) return value;
/******/ 		if((mode & 4) && typeof value === 'object' && value && value.__esModule) return value;
/******/ 		var ns = Object.create(null);
/******/ 		__webpack_require__.r(ns);
/******/ 		Object.defineProperty(ns, 'default', { enumerable: true, value: value });
/******/ 		if(mode & 2 && typeof value != 'string') for(var key in value) __webpack_require__.d(ns, key, function(key) { return value[key]; }.bind(null, key));
/******/ 		return ns;
/******/ 	};
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "";
/******/
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = "./src/editions/sonlui.js");
/******/ })
/************************************************************************/
/******/ ({

/***/ "./node_modules/webpack/buildin/global.js":
/*!***********************************!*\
  !*** (webpack)/buildin/global.js ***!
  \***********************************/
/*! no static exports found */
/***/ (function(module, exports) {

var g;

// This works in non-strict mode
g = (function() {
	return this;
})();

try {
	// This works if eval is allowed (see CSP)
	g = g || new Function("return this")();
} catch (e) {
	// This works if the window reference is available
	if (typeof window === "object") g = window;
}

// g can still be undefined, but nothing to do about it...
// We return undefined, instead of nothing here, so it's
// easier to handle this case. if(!global) { ...}

module.exports = g;


/***/ }),

/***/ "./src/config.js":
/*!***********************!*\
  !*** ./src/config.js ***!
  \***********************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/** 默认全局设置 */
var config = {
    /** 开启快速模式 */
    fast: true,
    /** 路径修正 */
    location: "",
    /** style前缀修正 */
    classPrefix: "sonlui-",
    /**多语言设置 */
    globalize: {
        /**启用多语言 */
        active: true,
        /**在加载多语言资源时自动替换Layui（Layui需要全模块加载） */
        autoRepLayui: true,
        /**是否通过异步请求获取多语言资源 */
        async: false,
        /**是否通过POST请求协助获取多语言资源 */
        useUrl: true,
        /**直接获取多语言资源的初始路径（当useUrl为false时） */
        base: "../../Global/",
        /**POST请求地址（当useUrl为true时） */
        url: "../../MES/Tools/GlobalResources",
        /**地域标识代码 */
        culture: "zh-CN"
    },
    /**Http请求设置 */
    http: {
        /**Api模块信息（包含地址，传输方式等） */
        api: {
            /**Api默认模块（普通模块未定义的项默认来自该模块，默认模块中未定义的项默认取自下一个模块） */
            DFLT: {
                /**Api地址 */
                address: "",
                /**Api传输方式 */
                contentType: "application/json; charset=UTF-8",
                /**Api请求数据格式化 */
                requestData: function (data) {
                    return JSON.stringify(data);
                },
                /**Api响应数据格式化 */
                responseData: function (data) {
                    return JSON.parse(data);
                }
            }
        }
    },
    /**Cookie设置 */
    cookie: {
        /**启用Cookie */
        active: true,
        /**存放地域标识代码的Cookie名 */
        global: "Local.Culture"
    },
    /**本地存储设置 */
    local: {
        /**启用本地存储 */
        active: true,
        /**xurui.value的本地存储名 */
        all: "Config",
        /**xurui.value.style的本地存储名 */
        style: "Style",
        /**存放地域标识代码的本地存储名 */
        global: "Local.Culture"
    },
    /**定制layui设置 */
    layui: {
        /**自动替换Layui（Layui需要全模块加载） */
        autoReplace: true,
        /**Layui是否为全模块加载（如果layui在之后加载，需要手动更正） */
        all: false
    },
    /**原型扩展设置 */
    prototype: {
        /**启用原型扩展 */
        active: true,
        /**启用全部原型扩展（如果为true将会无视所有单独原型扩展设置） */
        all: false,
        /**字符串扩展 */
        string: true,
        /**类型转换扩展 */
        convert: true
    }
};

/* harmony default export */ __webpack_exports__["default"] = (config);

/***/ }),

/***/ "./src/editions/sonlui.js":
/*!********************************!*\
  !*** ./src/editions/sonlui.js ***!
  \********************************/
/*! no exports provided */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* WEBPACK VAR INJECTION */(function(global) {/* harmony import */ var _main_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../main.js */ "./src/main.js");
/* harmony import */ var _modules_compatibility_js__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../modules/compatibility.js */ "./src/modules/compatibility.js");
/* harmony import */ var _modules_compatibility_js__WEBPACK_IMPORTED_MODULE_1___default = /*#__PURE__*/__webpack_require__.n(_modules_compatibility_js__WEBPACK_IMPORTED_MODULE_1__);
/* harmony import */ var _modules_basic_js__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../modules/basic.js */ "./src/modules/basic.js");
/* harmony import */ var _modules_http_js__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../modules/http.js */ "./src/modules/http.js");
/* harmony import */ var _modules_image_js__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../modules/image.js */ "./src/modules/image.js");
/* harmony import */ var _extends_layui_main_js__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../extends/layui/main.js */ "./src/extends/layui/main.js");







global.xurui = _main_js__WEBPACK_IMPORTED_MODULE_0__["main"];
xurui.config.classPrefix = "sonlui-";
xurui.name = "Sonluk";
Object(_main_js__WEBPACK_IMPORTED_MODULE_0__["init"])([_extends_layui_main_js__WEBPACK_IMPORTED_MODULE_5__["layuiSoon"]], [_extends_layui_main_js__WEBPACK_IMPORTED_MODULE_5__["layuiAfter"]], "sonlui");
global.sonluk = xurui;
/* WEBPACK VAR INJECTION */}.call(this, __webpack_require__(/*! ./../../node_modules/webpack/buildin/global.js */ "./node_modules/webpack/buildin/global.js")))

/***/ }),

/***/ "./src/extends/layui/breadcrumbe.html":
/*!********************************************!*\
  !*** ./src/extends/layui/breadcrumbe.html ***!
  \********************************************/
/*! no static exports found */
/***/ (function(module, exports) {

// Module
var code = "<span class=\"layui-breadcrumb\" lay-separator=\">\" style=\"visibility: visible;\">\r\n    <a></a>\r\n    <span lay-separator=\"\">&gt;</span>\r\n    <a><cite></cite></a>\r\n</span>";
// Exports
module.exports = code;

/***/ }),

/***/ "./src/extends/layui/main.js":
/*!***********************************!*\
  !*** ./src/extends/layui/main.js ***!
  \***********************************/
/*! exports provided: layui, layuiSoon, layuiAfter */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "layuiSoon", function() { return soon; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "layuiAfter", function() { return after; });
/* harmony import */ var _main_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../../main.js */ "./src/main.js");
/* harmony import */ var layui__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! layui */ "layui");
/* harmony import */ var layui__WEBPACK_IMPORTED_MODULE_1___default = /*#__PURE__*/__webpack_require__.n(layui__WEBPACK_IMPORTED_MODULE_1__);
/* harmony reexport (default from non-harmony) */ __webpack_require__.d(__webpack_exports__, "layui", function() { return layui__WEBPACK_IMPORTED_MODULE_1___default.a; });
/* harmony import */ var jquery__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! jquery */ "jquery");
/* harmony import */ var jquery__WEBPACK_IMPORTED_MODULE_2___default = /*#__PURE__*/__webpack_require__.n(jquery__WEBPACK_IMPORTED_MODULE_2__);
/* harmony import */ var _msg_js__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./msg.js */ "./src/extends/layui/msg.js");
/* harmony import */ var _style_js__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./style.js */ "./src/extends/layui/style.js");
/* harmony import */ var _config_js__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../config.js */ "./src/config.js");
/* harmony import */ var _globalize_js__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../../globalize.js */ "./src/globalize.js");
/* harmony import */ var _breadcrumbe_html__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./breadcrumbe.html */ "./src/extends/layui/breadcrumbe.html");
/* harmony import */ var _breadcrumbe_html__WEBPACK_IMPORTED_MODULE_7___default = /*#__PURE__*/__webpack_require__.n(_breadcrumbe_html__WEBPACK_IMPORTED_MODULE_7__);









/** 全局变量和缓存：layui缓存 */
_main_js__WEBPACK_IMPORTED_MODULE_0__["default"].values.layui = {
    /** 捕捉标记 */
    catched: false,
    table: {}
};

/** layui提前捕捉 */
_main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layuiCatch = function () {
    if (!_main_js__WEBPACK_IMPORTED_MODULE_0__["default"].values.layui.catched && typeof layui__WEBPACK_IMPORTED_MODULE_1___default.a === 'object') {
        _config_js__WEBPACK_IMPORTED_MODULE_5__["default"].layui.autoReplace = _config_js__WEBPACK_IMPORTED_MODULE_5__["default"].layui.autoReplace && _config_js__WEBPACK_IMPORTED_MODULE_5__["default"].layui.all;
        if (_config_js__WEBPACK_IMPORTED_MODULE_5__["default"].layui.autoReplace) {
            _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui.replace();
        }
        _config_js__WEBPACK_IMPORTED_MODULE_5__["default"].layui.all = layui__WEBPACK_IMPORTED_MODULE_1___default.a["layui.all"] ? true : false;
        for (let key in layui__WEBPACK_IMPORTED_MODULE_1___default.a) {
            if (_main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui[key] == null) _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui[key] = layui__WEBPACK_IMPORTED_MODULE_1___default.a[key];
            else _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui[key] = layui__WEBPACK_IMPORTED_MODULE_1___default.a[key];
        }
        _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].values.layui.catched = true;
    }
};

_main_js__WEBPACK_IMPORTED_MODULE_0__["default"].msg = _msg_js__WEBPACK_IMPORTED_MODULE_3__["default"];

_main_js__WEBPACK_IMPORTED_MODULE_0__["default"].style = _style_js__WEBPACK_IMPORTED_MODULE_4__["default"];

/** layui加强版 */
_main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui = {

    breadcrumbefix: function (menuNameQuery, subMenuNameQuery) {
        if (layui__WEBPACK_IMPORTED_MODULE_1___default.a && layui__WEBPACK_IMPORTED_MODULE_1___default.a.element) bcfix();
        else jquery__WEBPACK_IMPORTED_MODULE_2___default()(document).ready(function () { bcfix(); });
    },

    replace: function () {
        _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui.fn.replaceLayui();
    },

    table: {
        limit: function (layID) {
            return jquery__WEBPACK_IMPORTED_MODULE_2___default()("div[lay-id='" + layID + "'] .layui-laypage-limits").find("option:selected").val();
        },
        render: function (input) {
            /*复写layui表格变量*/
            /*1.变量初始化*/
            var donecallback = input.done;
            input.globalize = input.globalize || _config_js__WEBPACK_IMPORTED_MODULE_5__["default"].globalize.active;
            input.filter = input.filter || jquery__WEBPACK_IMPORTED_MODULE_2___default()(input.elem).attr("lay-filter");
            input.id = input.id || jquery__WEBPACK_IMPORTED_MODULE_2___default()(input.elem).attr("id");
            input.value = input.value || _globalize_js__WEBPACK_IMPORTED_MODULE_6__["default"].values.lv[input.id];
            _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].values.layui.table[input.id] = _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].values.layui.table[input.id] || { page: { curr: 0 } }
            /*2.设定当前页初始数据，每页显示数量保持不变并且避免末页无数据*/
            if (typeof input.page === 'object') {
                if (_main_js__WEBPACK_IMPORTED_MODULE_0__["default"].values.layui.table[input.id].page.curr) input.page.curr = _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].values.layui.table[input.id].page.curr;
                else _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].values.layui.table[input.id].page.curr = input.page.curr || 1;
                input.page.limit = jquery__WEBPACK_IMPORTED_MODULE_2___default()("div[lay-id='" + input.filter + "'] .layui-laypage-limits").find("option:selected").val() || input.page.limit;
                var fyall = Math.ceil(input.data.length / input.page.limit);
                if (fyall < input.page.curr) input.page.curr = Number(fyall);
            }
            /*3.标题栏多语言*/
            if (input.globalize) input.cols = _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui.fn.globalizeCols(input.cols, input.value);
            /*4.宽度设置（在未设置宽度情况下，标题栏宽度适应标题长度；在未设置对齐方式情况下，默认居中）*/
            if (input.cols && input.cols.length) _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui.fn.widthCols(input.cols, input.elem);
            /*5.表格渲染完成后的动作*/
            input.done = function (res, curr, count) {
                /*5.1底部页码多语言*/
                if (input.globalize && input.page) _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui.fn.globalizePage(input.filter);
                /*5.2借助全局变量保持当前页*/
                if (typeof input.page === 'object') _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].values.layui.table[input.id].page.curr = curr;
                /*5.3执行外部传来的done*/
                if (donecallback !== undefined) donecallback(res, curr, count);
            };
            /*加载layui表格*/
            if (_main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui.former.module.indexOf("table") != -1) _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui.former.table.render(input);
            else layui__WEBPACK_IMPORTED_MODULE_1___default.a.table.render(input);
        }
    },

    laydate: {
        render: function (input) {
            /*复写layui日期变量*/
            if (_config_js__WEBPACK_IMPORTED_MODULE_5__["default"].globalize.culture.split(/-|_/)[0] != "zh" && _config_js__WEBPACK_IMPORTED_MODULE_5__["default"].globalize.active) input.lang = 'en';
            /*加载layui日期*/
            if (_main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui.former.module.indexOf("laydate") != -1) _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui.former.laydate.render(input);
            else layui__WEBPACK_IMPORTED_MODULE_1___default.a.laydate.render(input);
        }
    },

    layer: {
        /**
         * 设置监听：鼠标移入显示tips，移出关闭tips
         * @param {String} elem 选择器
         * @param {String} words 显示的内容
         * @param {Boolean} bool 鼠标移入时是否显示内容（true为显示，默认为true）
         * @param {Number} dir 显示内容的方向（0为左，1为上，2为右，3为下，默认显示在右边）
         */
        hover: function (elem, words, bool, dir) {
            if (typeof bool !== 'function') bool = function () { return true; };
            dir = dir || 2;
            var tip_index = 0;
            jquery__WEBPACK_IMPORTED_MODULE_2___default()(elem).mouseenter(function () {
                if (bool()) tip_index = layui__WEBPACK_IMPORTED_MODULE_1___default.a.layer.tips(words, elem, { tips: [dir, '#009688'], time: 0 });
            }).mouseleave(function () {
                layui__WEBPACK_IMPORTED_MODULE_1___default.a.layer.close(tip_index);
            });
        },
        confirm: function (content, options, yes, cancel) {
            /*复写layui.confirm变量*/
            if (_config_js__WEBPACK_IMPORTED_MODULE_5__["default"].globalize.active) {
                switch (arguments.length) {
                    case 0:
                    case 1:
                        options = {
                            title: _globalize_js__WEBPACK_IMPORTED_MODULE_6__["default"].values.common.layui_title_infor,
                            btn: [_globalize_js__WEBPACK_IMPORTED_MODULE_6__["default"].values.common.layui_btn_confirm, _globalize_js__WEBPACK_IMPORTED_MODULE_6__["default"].values.common.layui_btn_cancel]
                        }
                        break;
                    default:
                        if (typeof options === "function") {
                            cancel = yes;
                            yes = options;
                            options = {
                                title: _globalize_js__WEBPACK_IMPORTED_MODULE_6__["default"].values.common.layui_title_infor,
                                btn: [_globalize_js__WEBPACK_IMPORTED_MODULE_6__["default"].values.common.layui_btn_confirm, _globalize_js__WEBPACK_IMPORTED_MODULE_6__["default"].values.common.layui_btn_cancel]
                            }
                        }
                        else {
                            if (options.title === undefined) options.title = _globalize_js__WEBPACK_IMPORTED_MODULE_6__["default"].values.common.layui_title_infor;
                            if (options.btn === undefined) options.btn = [_globalize_js__WEBPACK_IMPORTED_MODULE_6__["default"].values.common.layui_btn_confirm, _globalize_js__WEBPACK_IMPORTED_MODULE_6__["default"].values.common.layui_btn_cancel];
                        }
                        break;
                }
            }
            /*加载layui.confirm*/
            if (_main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui.former.module.indexOf("layer") != -1) _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui.former.layer.confirm(content, options, yes, cancel);
            else layui__WEBPACK_IMPORTED_MODULE_1___default.a.layer.confirm(content, options, yes, cancel);
        },
        alert: function (content, options, yes) {
            /*复写layui.alert变量*/
            if (_config_js__WEBPACK_IMPORTED_MODULE_5__["default"].globalize.active) {
                switch (arguments.length) {
                    case 0:
                    case 1:
                        options = {
                            title: _globalize_js__WEBPACK_IMPORTED_MODULE_6__["default"].values.common.layui_title_infor,
                            btn: [_globalize_js__WEBPACK_IMPORTED_MODULE_6__["default"].values.common.layui_btn_confirm]
                        }
                        break;
                    default:
                        if (typeof options === "function") {
                            yes = options;
                            options = {
                                title: _globalize_js__WEBPACK_IMPORTED_MODULE_6__["default"].values.common.layui_title_infor,
                                btn: [_globalize_js__WEBPACK_IMPORTED_MODULE_6__["default"].values.common.layui_btn_confirm]
                            }
                        }
                        else {
                            if (options.title === undefined) options.title = _globalize_js__WEBPACK_IMPORTED_MODULE_6__["default"].values.common.layui_title_infor;
                            if (options.btn === undefined) options.btn = [_globalize_js__WEBPACK_IMPORTED_MODULE_6__["default"].values.common.layui_btn_confirm];
                        }
                        break;
                }
            }
            /*加载layui.alert*/
            if (_main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui.former.module.indexOf("layer") != -1) _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui.former.layer.alert(content, options, yes);
            else layui__WEBPACK_IMPORTED_MODULE_1___default.a.layer.alert(content, options, yes);
        }
    },

    former: {
        module: [],
        table: {
            render: {}
        },
        laydate: {
            render: {}
        },
        layer: {
            confirm: {},
            alert: {}
        }
    },

    /**内部操作（请勿在外部操作） */
    fn: {
        replaceLayui: function () {
            /*table替换*/
            if (layui__WEBPACK_IMPORTED_MODULE_1___default.a.table && _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui.former.module.indexOf("table") == -1) {
                _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui.former.table.render = layui__WEBPACK_IMPORTED_MODULE_1___default.a.table.render;
                layui__WEBPACK_IMPORTED_MODULE_1___default.a.table.render = _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui.table.render;
                _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui.former.module.push("table");
            }
            /*laydate替换*/
            if (layui__WEBPACK_IMPORTED_MODULE_1___default.a.laydate && _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui.former.module.indexOf("laydate") == -1) {
                _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui.former.laydate.render = layui__WEBPACK_IMPORTED_MODULE_1___default.a.laydate.render;
                layui__WEBPACK_IMPORTED_MODULE_1___default.a.laydate.render = _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui.laydate.render;
                _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui.former.module.push("laydate");
            }
            /*layer替换*/
            if (layui__WEBPACK_IMPORTED_MODULE_1___default.a.layer && _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui.former.module.indexOf("layer") == -1) {
                _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui.former.layer.confirm = layui__WEBPACK_IMPORTED_MODULE_1___default.a.layer.confirm;
                layui__WEBPACK_IMPORTED_MODULE_1___default.a.layer.confirm = _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui.layer.confirm;
                _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui.former.layer.alert = layui__WEBPACK_IMPORTED_MODULE_1___default.a.layer.alert;
                layui__WEBPACK_IMPORTED_MODULE_1___default.a.layer.alert = _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui.layer.alert;
                _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].layui.former.module.push("layer");
            }
        },
        globalizePage: function (idName) {
            var a = jquery__WEBPACK_IMPORTED_MODULE_2___default()("div[lay-id='" + idName + "'] .layui-table-page .layui-laypage-count").html() || "";
            if (a != "") {
                a = a.replace(/共/g, _globalize_js__WEBPACK_IMPORTED_MODULE_6__["default"].values.common.layui_Gong).replace(/条/g, _globalize_js__WEBPACK_IMPORTED_MODULE_6__["default"].values.common.layui_Tiao);
                jquery__WEBPACK_IMPORTED_MODULE_2___default()("div[lay-id='" + idName + "'] .layui-table-page .layui-laypage-count").html(a);

                a = jquery__WEBPACK_IMPORTED_MODULE_2___default()("div[lay-id='" + idName + "'] .layui-table-page .layui-laypage-btn").html();
                a = a.replace(/确定/g, _globalize_js__WEBPACK_IMPORTED_MODULE_6__["default"].values.common.layui_QueDing);
                jquery__WEBPACK_IMPORTED_MODULE_2___default()("div[lay-id='" + idName + "'] .layui-table-page .layui-laypage-btn").html(a);

                jquery__WEBPACK_IMPORTED_MODULE_2___default()("div[lay-id='" + idName + "'] .layui-table-page .layui-laypage-skip")[0].childNodes[0].nodeValue = _globalize_js__WEBPACK_IMPORTED_MODULE_6__["default"].values.common.layui_DaoDi;
                jquery__WEBPACK_IMPORTED_MODULE_2___default()("div[lay-id='" + idName + "'] .layui-table-page .layui-laypage-skip")[0].childNodes[2].nodeValue = _globalize_js__WEBPACK_IMPORTED_MODULE_6__["default"].values.common.layui_Ye;

                jquery__WEBPACK_IMPORTED_MODULE_2___default()("div[lay-id='" + idName + "'] .layui-table-page .layui-laypage-limits select option").each(function () {
                    jquery__WEBPACK_IMPORTED_MODULE_2___default()(this).html(jquery__WEBPACK_IMPORTED_MODULE_2___default()(this).html().replace(/条/g, _globalize_js__WEBPACK_IMPORTED_MODULE_6__["default"].values.common.layui_Tiao).replace(/页/g, _globalize_js__WEBPACK_IMPORTED_MODULE_6__["default"].values.common.layui_Ye));
                });
            }
        },
        globalizeCols: function (cols, value) {
            cols = cols || [[]];
            value = value || "";
            for (var i = 0; i < cols.length; i++) {
                for (var j = 0; j < cols[i].length; j++) {
                    var field = cols[i][j].field || ""
                    if (cols[i][j].title === undefined && value[field]) {
                        cols[i][j].title = value[field];
                    }
                }
            }
            return cols
        },
        widthCols: function (cols, elem) {
            var lastRow = cols.length - 1;
            for (var i = 0; i < cols[lastRow].length; i++) {
                if (cols[lastRow][i].width === undefined && cols[lastRow][i].minWidth === undefined) {
                    var moreWidth = 0;
                    if (cols[lastRow][i].sort) moreWidth = 20;
                    jquery__WEBPACK_IMPORTED_MODULE_2___default()(elem).after('<span id = "assistWidthMeasure" style = "font-size: 14px;">' + cols[lastRow][i].title + '</span>');
                    cols[lastRow][i].width = jquery__WEBPACK_IMPORTED_MODULE_2___default()("#assistWidthMeasure").width() + 31 + moreWidth;
                    jquery__WEBPACK_IMPORTED_MODULE_2___default()("#assistWidthMeasure").remove();
                }
                cols[lastRow][i].align = cols[lastRow][i].align || 'center';
            }
            return cols
        }
    }

};

function bcfix(menuNameQuery, subMenuNameQuery) {
    var menuName = '';
    var subMenuName = '';
    if (menuNameQuery && jquery__WEBPACK_IMPORTED_MODULE_2___default()(menuNameQuery).length > 0) menuName = jquery__WEBPACK_IMPORTED_MODULE_2___default()(menuNameQuery).find('a').eq(0).text();
    if (subMenuNameQuery && jquery__WEBPACK_IMPORTED_MODULE_2___default()(subMenuNameQuery).length > 0) subMenuName = jquery__WEBPACK_IMPORTED_MODULE_2___default()(subMenuNameQuery).find('a').eq(0).text();
    menuName = menuName || jquery__WEBPACK_IMPORTED_MODULE_2___default()('li.layui-nav-itemed').find('a').eq(0).text();
    subMenuName = subMenuName || jquery__WEBPACK_IMPORTED_MODULE_2___default()('li.layui-nav-itemed > dl > dd.layui-this').find('a').eq(0).text();
    if (!menuName || !subMenuName) console.warn('未找到对应主菜单或子菜单文字，将显示空值');
    var bc = jquery__WEBPACK_IMPORTED_MODULE_2___default()(_breadcrumbe_html__WEBPACK_IMPORTED_MODULE_7___default.a);
    bc.find('a').eq(0).text(menuName);
    bc.find('a').eq(1).first().text(subMenuName);
    jquery__WEBPACK_IMPORTED_MODULE_2___default()('.layui-breadcrumb')[0].outerHTML = bc[0].outerHTML;
}

function soon(father) {
    father.layuiCatch();
}

function after(father) {
    father.layuiCatch();
}



/***/ }),

/***/ "./src/extends/layui/msg.js":
/*!**********************************!*\
  !*** ./src/extends/layui/msg.js ***!
  \**********************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var jquery__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! jquery */ "jquery");
/* harmony import */ var jquery__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(jquery__WEBPACK_IMPORTED_MODULE_0__);
/* harmony import */ var _main_js__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../main.js */ "./src/main.js");
/* harmony import */ var _globalize_js__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../globalize.js */ "./src/globalize.js");
/* harmony import */ var layui__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! layui */ "layui");
/* harmony import */ var layui__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(layui__WEBPACK_IMPORTED_MODULE_3__);





/**消息操作 */
var msg = {
    /**
     * 标准消息
     * @param {Object} message 消息内容（可以为数组以展示多条消息）
     * @param {String} type 消息类型（I为普通消息，W为警告消息，E为错误消息）
     * @param {Number} style 消息风格（偶数为自动消失，奇数为需点击确认）：
     * 【0】弹出若干秒后消失，【1】弹出后需点确认；
     * 【2】在0的基础上将消息以列表形式展现，【3】在1的基础上将消息以列表形式展现；
     * 【4】在0的基础上将消息以行形式展现，【5】在1的基础上将消息以行形式展现；
     * @param {Number|Function} input 回调和时间：
     * 当为数字时表示生效时间（单位为秒，当消息风格为0、2、4时生效，默认为3秒）；
     * 当为方法时表示点击回调（当消息风格为1、3、5时生效）；
     * @param {Boolean} clean 是否省略消息号
     */
    open: function (message, type, style, input, clean) {
        var title = "";
        var icon = 0;
        var time = 3;
        var callback = function () { };
        type = type || 'S';
        if (typeof input === 'number') time = input;
        else if (typeof input === 'function') callback = input;
        if (clean) message = cleanMsg(message, type);
        else message = checkMsg(message, type);
        switch (type) {
            case "E":
                style = typeof style === "number" ? style : 5;
                icon = 5;
                title = '<i class="layui-icon layui-icon-notice" style="font-size:18px; color:white;"></i><span style="margin-left:10px; font-size:16px;">' + _globalize_js__WEBPACK_IMPORTED_MODULE_2__["default"].values.common.layui_msg_E + '<span>'
                break;
            case "W":
                style = typeof style === "number" ? style : 5;
                icon = 0;
                title = '<i class="layui-icon layui-icon-notice" style="font-size:18px; color:white;"></i><span style="margin-left:10px; font-size:16px;">' + _globalize_js__WEBPACK_IMPORTED_MODULE_2__["default"].values.common.layui_msg_W + '<span>'
                break;
            case "I":
            default:
                style = typeof style === "number" ? style : 0;
                icon = 6;
                title = '<i class="layui-icon layui-icon-notice" style="font-size:18px; color:white;"></i><span style="margin-left:10px; font-size:16px;">' + _globalize_js__WEBPACK_IMPORTED_MODULE_2__["default"].values.common.layui_msg_S + '<span>'
                break;
        }
        switch (style) {
            case 0:
                layui__WEBPACK_IMPORTED_MODULE_3___default.a.layer.msg(msg.fn.combine(message), { icon: icon, time: time * 1000 });
                break;
            case 1:
                _main_js__WEBPACK_IMPORTED_MODULE_1__["default"].layui.layer.alert(msg.fn.combine(message), {
                    title: title,
                    skin: 'layui-layer-molv',
                    closeBtn: 0
                }, function () {
                    callback();
                });
                break;
            case 2:
                layui__WEBPACK_IMPORTED_MODULE_3___default.a.layer.msg("<div style=\"padding:20px;\"><table class=\"layui-hide\" id=\"sonluk_msg_open2\" lay-filter=\"sonluk_msg_open2\"></table></div>", { icon: icon, time: time * 1000, area: '700px', offset: '30%' });
                _main_js__WEBPACK_IMPORTED_MODULE_1__["default"].layui.table.render({
                    elem: '#sonluk_msg_open2',
                    data: msg.fn.list(message),
                    cols: [[
                        { field: 'code', title: _globalize_js__WEBPACK_IMPORTED_MODULE_2__["default"].values.common.layui_msg_table_code },
                        { field: 'type', title: _globalize_js__WEBPACK_IMPORTED_MODULE_2__["default"].values.common.layui_msg_table_type },
                        { field: 'message', title: _globalize_js__WEBPACK_IMPORTED_MODULE_2__["default"].values.common.layui_msg_table_content, minWidth: 150, align: "left" }
                    ]]
                })
                break;
            case 3:
                layui__WEBPACK_IMPORTED_MODULE_3___default.a.layer.open({
                    type: 1,
                    skin: 'layui-layer-molv',
                    closeBtn: 1,
                    area: ["700px", "430px"],
                    anim: 0,
                    btn: [_globalize_js__WEBPACK_IMPORTED_MODULE_2__["default"].values.common.layui_msg_btn],
                    title: title,
                    shade: 0.5,
                    shadeClose: false,
                    content: "<div style=\"padding:20px;\"><table class=\"layui-hide\" id=\"sonluk_msg_open3\" lay-filter=\"sonluk_msg_open3\"></table></div>",
                    yes: function (index, layero) {
                        callback(index, layero);
                        layui__WEBPACK_IMPORTED_MODULE_3___default.a.layer.close(index);
                    }
                });
                _main_js__WEBPACK_IMPORTED_MODULE_1__["default"].layui.table.render({
                    elem: '#sonluk_msg_open3',
                    data: msg.fn.list(message),
                    height: 265,
                    cols: [[
                        { field: 'code', title: _globalize_js__WEBPACK_IMPORTED_MODULE_2__["default"].values.common.layui_msg_table_code },
                        { field: 'type', title: _globalize_js__WEBPACK_IMPORTED_MODULE_2__["default"].values.common.layui_msg_table_type },
                        { field: 'message', title: _globalize_js__WEBPACK_IMPORTED_MODULE_2__["default"].values.common.layui_msg_table_content, minWidth: 150, align: "left" }
                    ]],
                    page: {
                        curr: 1,
                        limit: 5,
                        limits: [5]
                    }
                })
                break;
            case 4:
                layui__WEBPACK_IMPORTED_MODULE_3___default.a.layer.msg(msg.fn.merge(message, false), { skin: 'layui-layer-molv', time: time * 1000 });
                break;
            case 5:
            default:
                layui__WEBPACK_IMPORTED_MODULE_3___default.a.layer.open({
                    type: 1,
                    skin: 'layui-layer-molv',
                    closeBtn: 1,
                    area: msg.fn.fix(message),
                    anim: 0,
                    btn: [_globalize_js__WEBPACK_IMPORTED_MODULE_2__["default"].values.common.layui_msg_btn],
                    title: title,
                    shade: 0.5,
                    shadeClose: false,
                    content: msg.fn.merge(message),
                    yes: function (index, layero) {
                        callback(index, layero);
                        layui__WEBPACK_IMPORTED_MODULE_3___default.a.layer.close(index);
                    }
                });
                break;
        }
    },
    /**
     * 成功消息
     * @param {Object} message 消息内容（可以为数组以展示多条消息）
     * @param {Number} style 消息风格（偶数为自动消失，奇数为需点击确认）：
     * 【0】弹出若干秒后消失，【2】在0的基础上将消息以列表形式展现，【4】在0的基础上将消息以行形式展现；
     * 【1】弹出后需点确认，【3】在1的基础上将消息以列表形式展现，【5】在1的基础上将消息以行形式展现；
     * @param {Number|Function} input 回调和时间：
     * 当为数字时表示生效时间（单位为秒，当消息风格为0、2、4时生效，默认为3秒）；
     * 当为方法时表示点击回调（当消息风格为1、3、5时生效）；
     * @param {Boolean} clean 是否省略消息号
     */
    success: function (message, style, input, clean) {
        msg.open(message, "I", style, input, clean);
    },
    /**
     * 警告消息
     * @param {Object} message 消息内容（可以为数组以展示多条消息）
     * @param {Number} style 消息风格（偶数为自动消失，奇数为需点击确认）：
     * 【0】弹出若干秒后消失，【2】在0的基础上将消息以列表形式展现，【4】在0的基础上将消息以行形式展现；
     * 【1】弹出后需点确认，【3】在1的基础上将消息以列表形式展现，【5】在1的基础上将消息以行形式展现；
     * @param {Number|Function} input 回调和时间：
     * 当为数字时表示生效时间（单位为秒，当消息风格为0、2、4时生效，默认为3秒）；
     * 当为方法时表示点击回调（当消息风格为1、3、5时生效）；
     * @param {Boolean} clean 是否省略消息号
     */
    warning: function (message, style, input, clean) {
        msg.open(message, "W", style, input, clean);
    },
    /**
     * 错误消息
     * @param {Object} message 消息内容（可以为数组以展示多条消息）
     * @param {Number} style 消息风格（偶数为自动消失，奇数为需点击确认）：
     * 【0】弹出若干秒后消失，【2】在0的基础上将消息以列表形式展现，【4】在0的基础上将消息以行形式展现；
     * 【1】弹出后需点确认，【3】在1的基础上将消息以列表形式展现，【5】在1的基础上将消息以行形式展现；
     * @param {Number|Function} input 回调和时间：
     * 当为数字时表示生效时间（单位为秒，当消息风格为0、2、4时生效，默认为3秒）；
     * 当为方法时表示点击回调（当消息风格为1、3、5时生效）；
     * @param {Boolean} clean 是否省略消息号
     */
    error: function (message, style, input, clean) {
        msg.open(message, "E", style, input, clean);
    },
    /**
     * 循环消息（界面同风格为5的普通消息，但是是循环弹出每条消息）
     * @param {Object} msgs 消息内容（如果为数组则循环弹出消息）
     * @param {Function} after 当最后一个消息点击确定后的回调
     * @param {Function} every 每个消息点击确定后的回调
     * @param {Boolean} clean 是否省略消息号
     */
    repeat: function (msgs, after, every, index, clean) {
        after = after || function () { };
        every = every || function () { };
        index = index || 0;
        if (clean) msgs = cleanMsg(msgs, 'S');
        else msgs = checkMsg(msgs, 'S');
        if (msgs.length > index) {
            if (msgs.length == 1) {
                msg.open(msgs[index], msgs[index].type, 5, function () {
                    every(index);
                    after();
                }, clean);
            }
            else {
                msg.open(msgs[index], msgs[index].type, 5, function () {
                    index++;
                    every(index);
                    if (msgs.length == index) after();
                    msg.repeat(msgs, after, every, index, clean);
                }, clean);
            }
        }
    },

    ok: function (message, style, input) {
        msg.success(message, style, input, true)
    },

    warn: function (message, style, input) {
        msg.warning(message, style, input, true);
    },

    err: function (message, style, input) {
        msg.error(message, style, input, true);
    },

    rep: function (msgs, after, every, index) {
        msg.repeat(msgs, after, every, index, true);
    },

    /**内部操作（请勿在外部操作） */
    fn: {
        combine: function (message) {
            var rst = "";
            for (var i = 0; i < message.length; i++) {
                if (typeof message[i] === "string") rst = rst + message[i] + "</br>";
                else rst = rst + "【" + message[i].code + "(" + message[i].type + ")" + "】" + message[i].message + "</br>";
            }
            return rst;
        },
        merge: function (message, fix) {
            var fixSpan = "margin-top:6px;";
            if (typeof fix === "boolean" && fix === false) fixSpan = "";
            var content = "";
            for (var i = 0; i < message.length; i++) {
                content = content + "<div style=\"padding:10px 20px; display:flex;\">";
                if (typeof message[i] === "string") content = content + message[i];
                else content = content + msg.fn.type(message[i].type) + "<span style=\"margin-left:15px; float:left;" + fixSpan + "\">" + message[i].code + " " + message[i].message + "</span>";
                content = content + "</div>";
            }
            return content;
        },
        list: function (message) {
            for (var i = 0; i < message.length; i++) {
                if (typeof message[i] === "string") message[i] = { message: message[i] };
            }
            return message;
        },
        fix: function (message) {
            var height = 120;
            var width = 200;
            if (message instanceof Array) {
                height = height + message.length * 47;
                for (var i = 0; i < message.length; i++) {
                    var elem = document.createElement("span");
                    elem.innerText = message[i].code + " " + message[i].message;
                    jquery__WEBPACK_IMPORTED_MODULE_0___default()(elem).appendTo('body');
                    if (width < elem.offsetWidth + 100) width = elem.offsetWidth + 100;
                    jquery__WEBPACK_IMPORTED_MODULE_0___default()(elem).remove();
                }
            }
            if (height > 500) height = 500;
            if (width < height + 150) width = height + 150;
            if (width > 1000) width = 1000;
            return [width + 'px', height + 'px'];
        },
        type: function (type, size) {
            size = size || "25px";
            switch (type) {
                case "I":
                case "S":
                    return "<i class=\"layui-icon layui-icon-face-smile\" style=\"font-size: " + size + "; color:green; float:left;\"></i>";
                case "W":
                    return "<i class=\"layui-icon layui-icon-face-surprised\" style=\"font-size: " + size + "; color:#d26442; float:left;\"></i>";
                case "E":
                default:
                    return "<i class=\"layui-icon layui-icon-face-cry\" style=\"font-size: " + size + "; color:red; float:left;\"></i>";
            }
        }
    }
};

function cleanMsg(message, type) {
    if (typeof message === 'string') message = [{ code: '', type: type, message: message }];
    else if (typeof message === 'object') {
        if (message instanceof Array) {
            message.forEach(function (item) {
                if (typeof item === 'object') {
                    item.message = item.message || '';
                    item.type = item.type || 'S';
                    item.code = '';
                }
                else item = [{ code: '', type: type, message: item.toString() }];
            });
        }
        else {
            message.message = message.message || '';
            message.type = message.type || 'S';
            message.code = '';
            message = [message];
        }
    }
    else throw Error('消息类型错误：既不是字符串（组），也不是标准的ApiRetun中的消息（组）');
    return message;
}

function checkMsg(message, type) {
    if (typeof message === 'string') message = [{ code: '00015', type: type, message: message }];
    else if (typeof message === 'object') {
        if (message instanceof Array) {
            message.forEach(function (item) {
                if (typeof item === 'object') {
                    item.message = item.message || '';
                    item.type = item.type || 'S';
                    item.code = item.code || '00015';
                }
                else item = [{ code: '00015', type: type, message: item.toString() }];
            });
        }
        else {
            message.message = message.message || '';
            message.type = message.type || 'S';
            message.code = message.code || '00015';
            message = [message];
        }
    }
    else throw Error('消息类型错误：既不是字符串（组），也不是标准的ApiRetun中的消息（组）');
    return message;
}

/* harmony default export */ __webpack_exports__["default"] = (msg);

/***/ }),

/***/ "./src/extends/layui/style.js":
/*!************************************!*\
  !*** ./src/extends/layui/style.js ***!
  \************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _internal_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../../internal.js */ "./src/internal.js");
/* harmony import */ var jquery__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! jquery */ "jquery");
/* harmony import */ var jquery__WEBPACK_IMPORTED_MODULE_1___default = /*#__PURE__*/__webpack_require__.n(jquery__WEBPACK_IMPORTED_MODULE_1__);
/* harmony import */ var _utils_save_js__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../utils/save.js */ "./src/utils/save.js");
/* harmony import */ var _main_js__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../main.js */ "./src/main.js");





/**全局风格 */
var style = {

    /*标准操作*/
    /**
     * 读取本地存储的values
     * @param {String} key
     */
    read: function (key) {
        key = key || _utils_save_js__WEBPACK_IMPORTED_MODULE_2__["default"].name();
        var rst = null
        if (_utils_save_js__WEBPACK_IMPORTED_MODULE_2__["default"].available()) {
            if (_utils_save_js__WEBPACK_IMPORTED_MODULE_2__["default"].exist(key)) {
                rst = _utils_save_js__WEBPACK_IMPORTED_MODULE_2__["default"].get(key);
            }
            else {
                rst = "";
            }
        }
        return rst;
    },
    /**
     * 应用values.style
     * @param {Object} config
     */
    apply: function (config) {
        config = config || _main_js__WEBPACK_IMPORTED_MODULE_3__["default"].values;
        jquery__WEBPACK_IMPORTED_MODULE_1___default()('.layui-elem-field').css('color', config.style.color.tag || _main_js__WEBPACK_IMPORTED_MODULE_3__["default"].values.style.color.tag);
        jquery__WEBPACK_IMPORTED_MODULE_1___default()('.layui-elem-field').css('border-color', config.style.color.tag || _main_js__WEBPACK_IMPORTED_MODULE_3__["default"].values.style.color.tag);
        jquery__WEBPACK_IMPORTED_MODULE_1___default()('.layui-side .layui-nav').css('background-color', config.style.color.lr || _main_js__WEBPACK_IMPORTED_MODULE_3__["default"].values.style.color.lr);
        jquery__WEBPACK_IMPORTED_MODULE_1___default()('.layui-header').css('background-color', config.style.color.head || _main_js__WEBPACK_IMPORTED_MODULE_3__["default"].values.style.color.head);
        return true;
    },

    /*快速操作*/
    /**
     * 快速获取本地存储并使用
     * @param {String} type 留空：仅读取本地存储并应用，set：在留空基础上，如果没有本地储存则将默认值存入本地存储，mix：在set基础上，如果有本地储存则将本地存储覆盖到values
     */
    auto: function (type) {
        type = type || "";
        var config = style.read() || "";
        if (config == null) return false;
        switch (type) {
            case "set":
                if (config == "") {
                    config = _main_js__WEBPACK_IMPORTED_MODULE_3__["default"].values;
                    _utils_save_js__WEBPACK_IMPORTED_MODULE_2__["default"].set(_utils_save_js__WEBPACK_IMPORTED_MODULE_2__["default"].name(), config);
                    style.apply(config);
                    return true;
                }
                else {
                    style.apply(config);
                    return true;
                }
                break;
            case "mix":
                if (config == "") {
                    config = _main_js__WEBPACK_IMPORTED_MODULE_3__["default"].values;
                    _utils_save_js__WEBPACK_IMPORTED_MODULE_2__["default"].set(_utils_save_js__WEBPACK_IMPORTED_MODULE_2__["default"].name(), config);
                    style.apply(config);
                    return true;
                }
                else {
                    _main_js__WEBPACK_IMPORTED_MODULE_3__["default"].values = config;
                    style.apply(config);
                    return true;
                }
                break;
            default:
                if (config != "") {
                    style.apply(config);
                    return true;
                }
                break;
        }
    },

    /*连点操作*/
    /**
     * 设置标签颜色
     * @param {String} input
     */
    tagColor: function (input) {
        return style.dot(input, _main_js__WEBPACK_IMPORTED_MODULE_3__["default"].values.style.color.tag);
    },
    /**
     * 设置左侧菜单背景色
     * @param {String} input
     */
    lrColor: function (input) {
        return style.dot(input, _main_js__WEBPACK_IMPORTED_MODULE_3__["default"].values.style.color.lr);
    },
    /**
     * 设置顶部标题背景色
     * @param {String} input
     */
    headColor: function (input) {
        return style.dot(input, _main_js__WEBPACK_IMPORTED_MODULE_3__["default"].values.style.color.head);
    },
    dot: function (input, value) {
        if (input === undefined) { return value; }
        else { input == input || ""; }
        value = input;
        style.apply(_main_js__WEBPACK_IMPORTED_MODULE_3__["default"].values);
        return this;
    },
    /**
     * 保存至本地
     * @param {String} key
     */
    save: function (key) {
        if (key === undefined || key === null) return this;
        else return _internal_js__WEBPACK_IMPORTED_MODULE_0__["default"].save(key);
    },
    /**
     * 返回上一级或指定点
     * @param {String} key
     */
    rt: function (key) {
        return _internal_js__WEBPACK_IMPORTED_MODULE_0__["default"].rt(key);
    }

};

/* harmony default export */ __webpack_exports__["default"] = (style);

/***/ }),

/***/ "./src/globalize.js":
/*!**************************!*\
  !*** ./src/globalize.js ***!
  \**************************/
/*! exports provided: default, globalize, globalizeSoon */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "globalize", function() { return globalize; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "globalizeSoon", function() { return soon; });
/* harmony import */ var _config_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./config.js */ "./src/config.js");
/* harmony import */ var _utils_merge_js__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./utils/merge.js */ "./src/utils/merge.js");
/* harmony import */ var _internal_js__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./internal.js */ "./src/internal.js");




/** 全局变量和缓存：翻译文本缓存 */
var values = {
    common: {
        layui_DaoDi: "到第",
        layui_Ye: "页",
        layui_QueDing: "确定",
        layui_Gong: "共",
        layui_Tiao: "条",
        layui_title_infor: "信息",
        layui_btn_confirm: "确定",
        layui_btn_cancel: "取消",
        layui_msg_S: "提示",
        layui_msg_W: "警告",
        layui_msg_E: "错误",
        layui_msg_btn: "确认",
        layui_msg_table_code: "消息代码",
        layui_msg_table_type: "消息类型",
        layui_msg_table_content: "消息内容",
        weui_picker_year: '年',
        weui_picker_month: '月',
        weui_picker_day: '日',
        weui_btn_continue: '继续',
        weui_btn_close: '关闭',
        weui_btn_confirm: '确认',
        weui_btn_cancel: '取消',
        weui_nav_main: '主菜单',
        weui_nav_sub: '子菜单'
    },
    lv: {}
};

/** 国际化与本地化 */
var globalize = {
    values: values,

    /**加载Layui多语言模块（如果Layui是模块化加载，需写到layui.use内部） */
    replaceLayui: function () {
        xurui.layui.fn.replaceLayui();
    },

    /**
     * 手动设置本地文化代码（需符合i18n标准）
     * @param {String} input
     */
    setCulture: function (input) {
        _config_js__WEBPACK_IMPORTED_MODULE_0__["default"].globalize.culture = input;
    },

    /**
     * 加载语言包，并给lid赋值（common与lv变量的key直接可用于lid，其他自定义变量需要加前缀）
     * @param {String} location 语言包路径
     * @param {String} name 自定义变量（留空则为common）
     * @param {String} type 如果自定义变量已存在时的操作（留空为替换，merge为合并）
     */
    getResources: function (location, name, type) {
        /*当自动替换开启时替换Layui*/
        if (xurui.config.globalize.autoRepLayui) xurui.layui.fn.replaceLayui();
        /*加载语言包*/
        location = location || "common";
        name = name || "common";
        if (xurui.config.globalize.useUrl) xurui.global.urlFunc(location, name, type);
        else xurui.global.baseFunc(location, name, type);
        /*当多语言开启时给lid赋值（遍历lid，先从lv里面找，然后再从自定义变量里面找，最后从common里面找，如果不存在则不赋值，存在则赋值。如果lid是拼接的话，则只要任一key不存在就不赋值）*/
        if (xurui.config.globalize.active) {
            addEventListener('load', function () {
                globalize.translate();
            });
        }
    },

    /**
     * 仅加载语言包
     * @param {String} location 语言包路径
     * @param {String} name 自定义变量（留空则为common）
     * @param {String} type 如果自定义变量已存在时的操作（留空为替换，merge为合并）
     */
    getResourcesOnly: function (location, name, type) {
        location = location || "common";
        name = name || "common";
        if (xurui.config.globalize.useUrl) xurui.global.urlFunc(location, name, type);
        else xurui.global.baseFunc(location, name, type);
    },

    /**
     * 用已获取的语言包进行翻译
     */
    translate: function () {
        var lidAll = document.querySelectorAll("[lid]");
        if (typeof lidAll.forEach !== 'function') {
            lidAll.forEach = function (callback) {
                for (var i = 0; i < lidAll.length; i++) {
                    callback(lidAll[i]);
                }
            }
        }
        lidAll.forEach(function (child) {
            var lvalue = "";
            var lidStr = child.getAttribute("lid").split('+');
            var empty = true;
            for (var i = 0; i < lidStr.length; i++) {
                empty = true;
                if (empty) {
                    if (xurui.value.global["lv"][lidStr[i]]) {
                        lvalue = lvalue + xurui.value.global["lv"][lidStr[i]];
                        empty = false;
                    }
                }
                if (empty) {
                    for (let key in xurui.value.global) {
                        if (key !== "lv" && key !== "common") {
                            var lidKey = lidStr[i].replace(key + "_", "");
                            if (lidStr[i].split('_')[0] === key && xurui.value.global[key][lidKey]) {
                                lvalue = lvalue + xurui.value.global[key][lidKey];
                                empty = false;
                                break;
                            }
                        }
                    }
                }
                if (empty) {
                    if (xurui.value.global["common"][lidStr[i]]) {
                        lvalue = lvalue + xurui.value.global["common"][lidStr[i]];
                        empty = false;
                    }
                }
                if (empty) break;
            }
            if (!empty) xurui.global.lidFunc(child.getAttribute("lid"), lvalue);
        });
    },

    /**
     * 修改标题（head中的title）
     * @param {String} value 标题名
     */
    setTitle: function (value) {
        document.querySelector('head > title').innerHTML = value;
    },

    /**内部操作（请勿在外部操作） */
    baseFunc: function (location, name, type, callback) {
        callback = callback || function () { };
        type = type || "";
        var base = xurui.config.globalize.base || "../../"
        var url = base + location;
        var culture = xurui.config.globalize.culture.split(/-|_/)[0];
        switch (culture) {
            case "en":
            case "vi":
            case "zh":
                break;
            default:
                culture = "zh";
                break;
        }
        var fix = ["-" + culture + ".json", ".json", "-zh.json"];
        for (var i = 0; i < fix.length; i++) {
            var getUrl = url + fix[i];
            var out = false;
            _internal_js__WEBPACK_IMPORTED_MODULE_2__["default"].get(getUrl, xurui.config.globalize.async, function (data) {
                if (type === "merge" && xurui.value.global[name]) Object(_utils_merge_js__WEBPACK_IMPORTED_MODULE_1__["default"])(xurui.value.global[name], data);
                else xurui.value.global[name] = data;
                out = true;
                callback(data);
            });
            if (out) break;
        }
    },
    urlFunc: function (location, name, type, callback) {
        callback = callback || function () { };
        type = type || "";
        var culture = xurui.config.globalize.culture.split(/-|_/)[0];
        switch (culture) {
            case "en":
            case "vi":
            case "zh":
                break;
            default:
                culture = "zh";
                break;
        }
        _internal_js__WEBPACK_IMPORTED_MODULE_2__["default"].post(xurui.config.globalize.url, { culture: culture, location: location }, xurui.config.globalize.async, function (data) {
            if (type === "merge" && xurui.value.global[name]) Object(_utils_merge_js__WEBPACK_IMPORTED_MODULE_1__["default"])(xurui.value.global[name], data);
            else xurui.value.global[name] = data;
            callback(data);
        });
    },
    lidFunc: function (lid, lvalue) {
        var lidItem = document.querySelectorAll("[lid='" + lid + "']");
        if (typeof lidItem.forEach !== 'function') {
            lidItem.forEach = function (callback) {
                for (var i = 0; i < lidItem.length; i++) {
                    callback(lidItem[i]);
                }
            }
        }
        lidItem.forEach(function (child) {
            if (child.hasAttribute("type") && child.getAttribute("type") == "radio") child.setAttribute("title", lvalue);
            else if (child.tagName == "INPUT") child.setAttribute("placeholder", lvalue);
            else child.innerHTML = lvalue;
        });
    }

};

function soon() {
    xurui.config.globalize.autoRepLayui = xurui.config.globalize.autoRepLayui && xurui.config.globalize.active && xurui.config.layui.all;
    xurui.config.globalize.culture = xurui.cookie.get(xurui.config.local.global) || window.navigator.language;
    if (xurui.config.globalize.active) {
        if ((xurui.cookie.get(xurui.config.local.global) === undefined || xurui.cookie.get(xurui.config.local.global) === null || xurui.cookie.get(xurui.config.local.global) === "") && xurui.save.exist(xurui.config.local.global)) {
            /*xurui.cookie.get(xurui.config.local.global, xurui.save.get(xurui.config.local.global), { expires: 10, path: '/' });*/
        }
    }
}

/* harmony default export */ __webpack_exports__["default"] = (globalize);


/***/ }),

/***/ "./src/internal.js":
/*!*************************!*\
  !*** ./src/internal.js ***!
  \*************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _main_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./main.js */ "./src/main.js");


/** 内部方法 */
var fn = {

    /**
     * 连点快速定位
     * @param {String} key 定点代号
     */
    rt: function (key) {
        key = key || "";
        switch (key) {
            case "value":
                return _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].value;
                break;
            case "config":
                return _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].config;
                break;
            case "style":
                return _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].style;
                break;
            case "local":
                return _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].save;
                break;
            default:
                return _main_js__WEBPACK_IMPORTED_MODULE_0__["default"];
        }
    },

    /**保存至本地存储 */
    save: function (key) {
        xurui.save.cover(xurui.save.name(), xurui.value);
        return fn.rt(key);
    },

    /**POST请求 */
    post: function (postUrl, postData, async, callback) {
        xurui.http.ajax({
            type: "POST",
            async: async,
            url: postUrl,
            data: postData,
            success: function (data) {
                if (data !== "") callback(JSON.parse(data));
                else callback(data);
            }
        });
    },

    /**GET请求 */
    get: function (getUrl, async, callback) {
        xurui.http.ajax({
            type: "GET",
            async: async,
            url: getUrl,
            success: function (data) {
                if (data !== "") callback(JSON.parse(data));
                else callback(data);
            }
        });
    },

    /**加载JS文件 */
    load: function (url, callback) {
        var script = document.createElement('script');
        var fn = callback || function () { };
        script.type = 'text/javascript';
        /*IE*/
        if (script.readyState) {
            script.onreadystatechange = function () {
                if (script.readyState == 'loaded' || script.readyState == 'complete') {
                    script.onreadystatechange = null;
                    fn();
                }
            };
        }
        /*其他浏览器*/
        else {
            script.onload = function () {
                fn();
            };
        }
        script.src = url;
        document.getElementsByTagName('head')[0].appendChild(script);
    },

    /**
     * render
     * 取值：<%= variable %>
     * 表达式：<% if {} %>
     * 例子：
     *  <div>
     *    <div class="weui-mask"></div>
     *    <div class="weui-dialog">
     *    <% if(typeof title === 'string'){ %>
     *           <div class="weui-dialog__hd"><strong class="weui-dialog__title"><%=title%></strong></div>
     *    <% } %>
     *    <div class="weui-dialog__bd"><%=content%></div>
     *    <div class="weui-dialog__ft">
     *    <% for(var i = 0; i < buttons.length; i++){ %>
     *        <a href="javascript:;" class="weui-dialog__btn weui-dialog__btn_<%=buttons[i]['type']%>"><%=buttons[i]['label']%></a>
     *    <% } %>
     *    </div>
     *    </div>
     *  </div>
     * A very simple template engine
     * @param {String} tpl
     * @param {Object=} data
     * @returns {String}
     */
    render: function (tpl, data) {
        const code = 'var p=[];with(this){p.push(\'' +
            tpl
                .replace(/[\r\t\n]/g, ' ')
                .split('<%').join('\t')
                .replace(/((^|%>)[^\t]*)'/g, '$1\r')
                .replace(/\t=(.*?)%>/g, '\',$1,\'')
                .split('\t').join('\');')
                .split('%>').join('p.push(\'')
                .split('\r').join('\\\'')
            + '\');}return p.join(\'\');';
        return new Function(code).apply(data);
    },

    isDOM: function (obj) {
        if (typeof HTMLElement === 'object') {
            return obj instanceof HTMLElement;
        }
        else {
            return obj && typeof obj === 'object' && obj.nodeType === 1 && typeof obj.nodeName === 'string';
        }
    }
}

/* harmony default export */ __webpack_exports__["default"] = (fn);

/***/ }),

/***/ "./src/main.js":
/*!*********************!*\
  !*** ./src/main.js ***!
  \*********************/
/*! exports provided: default, main, init */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* WEBPACK VAR INJECTION */(function(global) {/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "main", function() { return main; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "init", function() { return init; });
/* harmony import */ var _config_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./config.js */ "./src/config.js");
/* harmony import */ var _globalize_js__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./globalize.js */ "./src/globalize.js");



var main = {
    /** 版本（使用前请确认版本） */
    v: "2.2.4",
    /** 代数 */
    g: "2",
    /** 前缀 */
    name: "",

    /** 全局变量和缓存 */
    values: {
        /** 全局设置值 */
        config: {},
        /** App交互标记 */
        app: {
            scheme: "sdemo",
            isApp: false,
            mac: "",
            verName: "",
            verCode: 0
        },
        style: {
            color: {
                tag: "#009688",
                lr: "#393D49",
                head: "#23262E"
            }
        },
        url: {
            area: "",
            controller: "",
            action: ""
        },
        globalize: _globalize_js__WEBPACK_IMPORTED_MODULE_1__["globalize"].values,
        global: _globalize_js__WEBPACK_IMPORTED_MODULE_1__["globalize"].values
    },

    /** 默认全局设置 */
    config: _config_js__WEBPACK_IMPORTED_MODULE_0__["default"],

    /** 多语言模块 */
    globalize: _globalize_js__WEBPACK_IMPORTED_MODULE_1__["globalize"],

    /** 多语言模块（兼容性） */
    global: _globalize_js__WEBPACK_IMPORTED_MODULE_1__["globalize"],

    /**
     * 加载域内JS
     * @param {string} location Scripts目录下的JS路径（不需要加扩展名）
     * @param {string} append 额外后缀
     */
    loadSJS: function (location, append) {
        append = append || '';
        var script = document.createElement("script");
        script.src = xurui.config.location + "/Scripts/" + location + ".js" + append;
        document.querySelector("head").append(script);
    },

    /**
     * 加载域内CSS
     * @param {string} location Content目录下的CSS路径（不需要加扩展名）
     * @param {string} append 额外后缀
     */
    loadSCSS: function (location, append) {
        append = append || '';
        var style = document.createElement("link");
        style.href = xurui.config.location + "/Content/" + location + ".css" + append;
        style.rel = "stylesheet";
        document.querySelector("head").append(style);
    },

    /**
     * 加载JS
     * @param {string} url JS完整URL
     * @param {string} append 额外后缀
     */
    loadJS: function (url, append) {
        append = append || '';
        var script = document.createElement("script");
        script.src = url + append;
        document.querySelector("head").append(script);
    },

    /**
     * 加载CSS
     * @param {string} url CSS完整URL
     * @param {string} append 额外后缀
     */
    loadCSS: function (url, append) {
        append = append || '';
        var style = document.createElement("link");
        style.href = url + append;
        style.rel = "stylesheet";
        document.querySelector("head").append(style);
    }
};

main.value = main.values;

function init(funsSoon, funsAfter, app) {
    /** 基础变量初始化 */
    xurui.config.local.all = xurui.name + "." + xurui.config.local.all;
    xurui.config.local.style = xurui.name + "." + xurui.config.local.style;
    xurui.config.local.global = xurui.name + "." + xurui.config.local.global;
    xurui.config.cookie.global = xurui.name + "." + xurui.config.cookie.global;
    /** 原型扩展初始化 */
    xurui.config.prototype.string = xurui.config.prototype.active && (xurui.config.prototype.string || xurui.config.prototype.all);
    xurui.config.prototype.convert = xurui.config.prototype.active && (xurui.config.prototype.convert || xurui.config.prototype.all);
    if (xurui.config.prototype.string) {
        /**
         * 日期和时间格式化
         * @param {String} format 日期格式，例如“yyyy-mm-dd”
         */
        String.prototype.sldatetime = function (format) {
            return xurui.format.datetime(this.toString(), format);
        }
        /**
         * 规定长度，不足加前缀
         * @param {Number} len 总长度
         * @param {String} fix 补足字符
         */
        String.prototype.slprefix = function (len, fix) {
            return xurui.format.suffix(this.toString(), len, fix);
        }
        /**
         * 规定长度，不足加后缀
         * @param {Number} len 总长度
         * @param {String} fix 补足字符
         */
        String.prototype.slsuffix = function (len, fix) {
            return xurui.format.suffix(this.toString(), len, fix);
        }
    }
    if (xurui.config.prototype.convert) {
        /**
         * Sonluk类型转换扩展：字符串转时间：
         * 可以使用“年月日时分秒”、“月日年时分秒”、“月日时分秒”和“时分秒”四种顺序填写，中间请用任一分隔符隔开；
         * 可以从后往前省略（省略项自动用最小值填充，年份最小值为1000），但中间不能漏；
         * 如果使用“年月日时分秒”顺序则至少需要包含“年月”。
         * 如果使用“时分秒”顺序则必须用“:”隔开。
         */
        String.prototype.sltoDatetime = function () {
            return xurui.convert.toDatetime(this.toString());
        }
    }
    /** 阶段初始化 */
    if (xurui.config.fast) global.$$ = xurui;
    //app联动检测
    switch (app) {
        case "sonlui":
            if (typeof sonluiApp != "undefined") {
                xurui.values.app.isApp = true;
                xurui.app = sonluiApp;
                if (typeof xurui.app.getAppVersionCode == "function") xurui.values.app.verCode = xurui.app.getAppVersionCode();
                if (typeof xurui.app.getAppVersionName == "function") xurui.values.app.verName = xurui.app.getAppVersionName();
                if (typeof xurui.app.getAppMac == "function") xurui.values.app.mac = xurui.app.getAppMac();
            }
            break;
        case "xurui":
            break;
    }
    Object(_globalize_js__WEBPACK_IMPORTED_MODULE_1__["globalizeSoon"])(main);
    funsSoon.forEach(function (fun) {
        fun(main);
    })
    /** 最后初始化 */
    window.addEventListener('load', function () {
        if (typeof document.querySelectorAll("svg").forEach === 'function') {
            document.querySelectorAll("svg").forEach(function (child) {
                if (!child.hasAttribute("viewBox")) child.setAttribute("viewBox", "0 0 1024 1024");
            });
        }
        funsAfter.forEach(function (fun) {
            fun(xurui);
        })
    });
}

/* harmony default export */ __webpack_exports__["default"] = (main);

/* WEBPACK VAR INJECTION */}.call(this, __webpack_require__(/*! ./../node_modules/webpack/buildin/global.js */ "./node_modules/webpack/buildin/global.js")))

/***/ }),

/***/ "./src/modules/basic.js":
/*!******************************!*\
  !*** ./src/modules/basic.js ***!
  \******************************/
/*! exports provided: default, basicMain */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _main_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../main.js */ "./src/main.js");
/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "basicMain", function() { return _main_js__WEBPACK_IMPORTED_MODULE_0__["default"]; });

/* harmony import */ var _utils_convert_js__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../utils/convert.js */ "./src/utils/convert.js");
/* harmony import */ var _utils_cookie_js__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../utils/cookie.js */ "./src/utils/cookie.js");
/* harmony import */ var _utils_date_js__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../utils/date.js */ "./src/utils/date.js");
/* harmony import */ var _utils_dom_js__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../utils/dom.js */ "./src/utils/dom.js");
/* harmony import */ var _utils_format_js__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../utils/format.js */ "./src/utils/format.js");
/* harmony import */ var _utils_math_js__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../utils/math.js */ "./src/utils/math.js");
/* harmony import */ var _utils_merge_js__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../utils/merge.js */ "./src/utils/merge.js");
/* harmony import */ var _utils_save_js__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ../utils/save.js */ "./src/utils/save.js");
/* harmony import */ var _utils_time_js__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ../utils/time.js */ "./src/utils/time.js");











var basic = {
    convert: _utils_convert_js__WEBPACK_IMPORTED_MODULE_1__["default"],
    cookie: _utils_cookie_js__WEBPACK_IMPORTED_MODULE_2__["default"],
    date: _utils_date_js__WEBPACK_IMPORTED_MODULE_3__["default"],
    dom: _utils_dom_js__WEBPACK_IMPORTED_MODULE_4__["default"],
    format: _utils_format_js__WEBPACK_IMPORTED_MODULE_5__["default"],
    math: _utils_math_js__WEBPACK_IMPORTED_MODULE_6__["default"],
    merge: _utils_merge_js__WEBPACK_IMPORTED_MODULE_7__["default"],
    save: _utils_save_js__WEBPACK_IMPORTED_MODULE_8__["default"],
    time: _utils_time_js__WEBPACK_IMPORTED_MODULE_9__["default"]
};

for (let key in basic) {
    _main_js__WEBPACK_IMPORTED_MODULE_0__["default"][key] = basic[key];
};

/* harmony default export */ __webpack_exports__["default"] = (basic);


/***/ }),

/***/ "./src/modules/compatibility.js":
/*!**************************************!*\
  !*** ./src/modules/compatibility.js ***!
  \**************************************/
/*! no static exports found */
/***/ (function(module, exports) {

if (typeof String.prototype.startsWith !== 'function') {
    String.prototype.startsWith = function (prefix) {
        return this.slice(0, prefix.length) === prefix;
    };
}

if (typeof String.prototype.endsWith !== 'function') {
    String.prototype.endsWith = function (suffix) {
        return this.indexOf(suffix, this.length - suffix.length) !== -1;
    };
}

if (typeof Array.prototype.find !== 'function') {
    Array.prototype.find = function (compare) {
        for (var i = 0; i < this.length; i++) {
            if (compare(this[i])) {
                return this[i];
            }
        }
    };
}

/***/ }),

/***/ "./src/modules/http.js":
/*!*****************************!*\
  !*** ./src/modules/http.js ***!
  \*****************************/
/*! exports provided: default, http, httpMain */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "http", function() { return http; });
/* harmony import */ var _main_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../main.js */ "./src/main.js");
/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "httpMain", function() { return _main_js__WEBPACK_IMPORTED_MODULE_0__["default"]; });



/**http操作 */
var http = {

    /**
     * 对获得的资源数据进行下载操作（如果资源比较大，请勿使用此方式，请直接从服务器下载）
     * @param {BinaryType} data 要下载的数据
     * @param {String} name 下载后的文件名（包含扩展名）
     */
    downloadLite: function (data, name) {
        var a = document.createElement('a');
        a.setAttribute('href', 'data:*/*;base64,' + data);
        a.setAttribute('download', name);
        document.querySelector('body').append(a);
        a[0].click();
        a.remove();
        return a;
    },

    /**
     * 下载操作
     * @param {Object} input Ajax模式传入对象，非Ajax模式传入地址
     * @param {Boolean} get Ajax模式留空，非Ajax模式true为GET请求，false为POST请求，默认true
     * @param {Object} data Ajax模式留空，非Ajax模式传入Json字符串化之前的数据（GET请求则留空）
     * @param {Object} query Ajax模式留空，非Ajax模式传入JS对象，根据对象名和值给Url赋参数
     */
    download: function (input, get, data, query, target) {
        var newUrl;
        var newGet = true;
        var newData;
        var newQuery;
        var newTarget = '_self';
        if (typeof input === 'object') {
            if (typeof input.url === 'string') newUrl = input.url;
            if (typeof input.get === 'boolean') newGet = input.get;
            if (typeof input.data === 'object') newData = input.data;
            if (typeof input.query === 'object') newQuery = input.query;
            if (typeof input.target === 'string') newTarget = input.target;
        }
        else if (typeof input === 'string') {
            if (typeof input === 'string') newUrl = input;
            if (typeof get === 'boolean') newGet = get;
            if (typeof data === 'object') newData = data;
            if (typeof query === 'object') newQuery = query;
            if (typeof target === 'string') newTarget = target;
        }
        else throw Error('传入参数错误！');
        for (let key in newQuery) {
            newUrl = urlQueryAdd(newUrl, key, newQuery[key]);
        }
        if (newGet) {
            window.open(newUrl, newTarget);
            return newUrl;
        }
        else {
            var form = document.createElement('form');
            form.setAttribute('method', 'post');
            form.setAttribute('action', newUrl);
            form.setAttribute('target', newTarget);
            if (typeof newData === 'string') {
                var formInput = document.createElement('input');
                formInput.setAttribute('type', 'hidden');
                formInput.setAttribute('name', 'input');
                formInput.setAttribute('value', newData);
                form.insertAdjacentElement('beforeend', formInput);
            }
            else if (typeof newData === 'object') {
                for (let key in newData) {
                    var formInput = document.createElement('input');
                    formInput.setAttribute('type', 'hidden');
                    formInput.setAttribute('name', key);
                    if (typeof newData[key] === 'object') formInput.setAttribute('value', JSON.stringify(newData[key]));
                    else formInput.setAttribute('value', newData[key]);
                    form.insertAdjacentElement('beforeend', formInput);
                }
            }
            document.querySelector('body').insertAdjacentElement('beforeend', form);
            form.submit();
            form.parentNode.removeChild(form);
            return form;
        }
    },

    /**
     * 上传操作
     * @param {Object} input 上传参数
     */
    upload: function (input) {
        var data = document.querySelector(input.elem);
        input.success = input.success || function (a) { };
        input.error = input.error || function (a) { };
        input.complete = input.complete || function (a) { };
        input.progress = input.progress || function (a) { };
        input.before = input.before || function (a) { };
        input.name = input.name || 'file';
        input.before(data);
        var formData = new FormData();
        if (data.files.length > 0) {
            for (var i = 0; i < data.files.length; i++) {
                formData.append(input.name, data.files[i]);
            }
        }
        else {
            return;
        }
        var xhr = new XMLHttpRequest();
        xhr.addEventListener('load', function (e) {
            if (e.srcElement.status === 200) {
                input.success(e.srcElement.response);
            }
            else {
                input.error(e.srcElement);
            }
        });
        xhr.addEventListener('error', function (e) {
            input.error(e.srcElement);
        });
        xhr.addEventListener('loadend', function (e) {
            input.complete(e.srcElement);
        });
        xhr.upload.addEventListener('progress', function (e) {
            if (e.lengthComputable) {
                input.progress(Math.ceil(e.loaded * 100 / e.total) + '%', e);
            }
        }, false);
        xhr.open('POST', input.url);
        xhr.send(formData);
        return xhr;
    },

    /**向Api发送请求操作 */
    api: {

        /**
         * 向指定Api发送请求获得下载内容（带ptoken）
         * @param {Object} input Ajax模式传入对象，非Ajax模式传入地址
         * @param {String} module Ajax模式留空，非Ajax模式传入Api模块名
         * @param {Boolean} get Ajax模式留空，非Ajax模式true为GET请求，false为POST请求，默认true
         * @param {Object} data Ajax模式留空，非Ajax模式传入数据
         * @param {Object} query Ajax模式留空，非Ajax模式传入JS对象，根据对象名和值给Url赋参数
         */
        sdownload: function (input, module, get, data, query) {
            return _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].http.api.download(ptokenAdd(input), module, get, data, query);
        },
        /**
         * 向指定Api发送GET请求（带ptoken）
         * @param {Object} input Ajax模式传入对象，非Ajax模式传入地址
         * @param {Function} success Ajax模式留空，非Ajax模式传入回调函数，参数为对象化的传入数据
         * @param {String} module Ajax模式留空，非Ajax模式传入Api模块名
         * @param {Boolean} asyn Ajax模式留空，非Ajax模式传入是否异步布尔值
         */
        sget: function (input, success, module, asyn) {
            return _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].http.api.get(ptokenAdd(input), success, module, asyn);
        },
        /**
         * 向指定Api发送GET请求（带ptoken）
         * @param {Object} input Ajax模式传入对象，非Ajax模式传入地址
         * @param {Object} data Ajax模式留空，非Ajax模式传入Json字符串化之前的数据
         * @param {Function} success Ajax模式留空，非Ajax模式传入回调函数，参数为对象化的传入数据
         * @param {String} module Ajax模式留空，非Ajax模式传入Api模块名
         * @param {Boolean} asyn Ajax模式留空，非Ajax模式传入是否异步布尔值
         */
        spost: function (input, data, success, module, asyn) {
            return _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].http.api.post(ptokenAdd(input), data, success, module, asyn);
        },
        /**
         * 向指定Api发送请求获得下载内容（不带ptoken）
         * @param {Object} input Ajax模式传入对象，非Ajax模式传入地址
         * @param {String} module Ajax模式留空，非Ajax模式传入Api模块名
         * @param {Boolean} get Ajax模式留空，非Ajax模式true为GET请求，false为POST请求，默认true
         * @param {Object} data Ajax模式留空，非Ajax模式传入Json字符串化之前的数据（GET请求则留空）
         * @param {Object} query Ajax模式留空，非Ajax模式传入JS对象，根据对象名和值给Url赋参数
         */
        download: function (input, module, get, data, query) {
            if (typeof input === 'object') {
                if (typeof input.url === 'string' && typeof input.module === 'string') {
                    input.module = xurui.config.http.api[input.module || 'DFLT'] || xurui.config.http.api.DFLT;
                    input.module.address = input.module.address || xurui.config.http.api.DFLT.address;
                    input.url = input.module.address + input.url;
                }
            }
            else {
                if (typeof input === 'string' && typeof module === 'string') {
                    module = xurui.config.http.api[module || 'DFLT'] || xurui.config.http.api.DFLT;
                    module.address = module.address || xurui.config.http.api.DFLT.address;
                    input = module.address + input;
                }
            }
            _main_js__WEBPACK_IMPORTED_MODULE_0__["default"].http.download(input, get, data, query);
        },
        /**
         * 向指定Api发送GET请求（不带ptoken）
         * @param {Object} input Ajax模式传入对象，非Ajax模式传入地址
         * @param {Function} success Ajax模式留空，非Ajax模式传入回调函数，参数为对象化的传入数据
         * @param {String} module Ajax模式留空，非Ajax模式传入Api模块名
         * @param {Boolean} async Ajax模式留空，非Ajax模式传入是否异步布尔值
         */
        get: function (input, success, module, async) {
            var newUrl;
            var newSuccess;
            var newModule = 'DFLT';
            var newAsync;
            if (typeof input === 'object') {
                if (typeof input.url === 'string') newUrl = input.url;
                if (typeof input.success === 'function') newSuccess = input.success;
                if (typeof input.module === 'string') newModule = input.module;
                if (typeof input.async === 'boolean') newAsync = input.async;
            }
            else if (typeof input === 'string') {
                newUrl = input;
                if (typeof success === 'function') newSuccess = success;
                if (typeof module === 'string') newModule = module;
                if (typeof async === 'boolean') newAsync = async;
            }
            else {
                throw Error('参数不正确，请以AJAX方式填入参数或确保第一个参数为Url地址');
            }
            newModule = xurui.config.http.api[newModule] || xurui.config.http.api.DFLT;
            newModule.address = newModule.address || xurui.config.http.api.DFLT.address;
            newModule.contentType = newModule.contentType || xurui.config.http.api.DFLT.contentType;
            newModule.responseData = newModule.responseData || xurui.config.http.api.DFLT.responseData;
            return xurui.http.ajax({
                type: 'GET',
                contentType: newModule.contentType,
                async: newAsync,
                success: function (data) { newSuccess(newModule.responseData(data)) },
                url: newModule.address + newUrl,
            });
        },
        /**
         * 向指定Api发送POST请求（不带ptoken）
         * @param {Object} input Ajax模式传入对象，非Ajax模式传入地址
         * @param {Object} data Ajax模式留空，非Ajax模式传入Json字符串化之前的数据
         * @param {Boolean} success Ajax模式留空，非Ajax模式传入回调函数，参数为对象化的传入数据
         * @param {String} module Ajax模式留空，非Ajax模式传入Api模块名
         * @param {Boolean} async Ajax模式留空，非Ajax模式传入是否异步布尔值
         */
        post: function (input, data, success, module, async) {
            var newUrl;
            var newData;
            var newSuccess;
            var newModule = 'DFLT';
            var newAsync;
            if (typeof input === 'object') {
                if (typeof input.url === 'string') newUrl = input.url;
                if (typeof input.data === 'object' && input.data !== null) newData = input.data;
                if (typeof input.success === 'function') newSuccess = input.success;
                if (typeof input.module === 'string') newModule = input.module;
                if (typeof input.async === 'boolean') newAsync = input.async;
            }
            else if (typeof input === 'string') {
                newUrl = input;
                if (typeof data === 'object' && data !== null) newData = data;
                if (typeof success === 'function') newSuccess = success;
                if (typeof module === 'string') newModule = module;
                if (typeof async === 'boolean') newAsync = async;
            }
            else {
                throw Error('参数不正确，请以AJAX方式填入参数或确保第一个参数为Url地址');
            }
            newModule = xurui.config.http.api[newModule] || xurui.config.http.api.DFLT;
            newModule.address = newModule.address || xurui.config.http.api.DFLT.address;
            newModule.contentType = newModule.contentType || xurui.config.http.api.DFLT.contentType;
            newModule.requestData = newModule.requestData || xurui.config.http.api.DFLT.requestData;
            newModule.responseData = newModule.responseData || xurui.config.http.api.DFLT.responseData;
            return xurui.http.ajax({
                type: 'POST',
                contentType: newModule.contentType,
                async: newAsync,
                data: newModule.requestData(newData),
                success: function (data) { newSuccess(newModule.responseData(data)) },
                url: newModule.address + newUrl,
            });
        }
    },

    /**
     * 标准http请求（类ajax用法，如果改变了contentType，请确保data格式正确）
     * @param {Object} input
     */
    ajax: function (input) {
        if (input.async == undefined) input.async = true;
        input.data = input.data || '';
        input.success = input.success || function (a) { }
        input.error = input.error || function (a) { }
        input.complete = input.complete || function (a) { }
        input.url = input.url || '';
        input.type = input.type || 'GET';
        if (input.contentType === undefined) {
            var newData = new FormData();
            for (let key in input.data) {
                newData.append(key, input.data[key]);
            }
            input.data = newData;
        }
        else if (input.contentType.indexOf('application/x-www-form-urlencoded') != -1) {
            var newData = '';
            for (let key in input.data) {
                newData += key + '=' + input.data[key] + '&'
            }
            input.data = encodeURI(newData.substring(0, newData.length - 1));
        }
        var xhr = new XMLHttpRequest();
        xhr.addEventListener('load', function (e) {
            if (e.srcElement.status === 200 || e.srcElement.status === 304) {
                input.success(e.srcElement.response);
            }
            else {
                input.error(e.srcElement);
            }
        });
        xhr.addEventListener('error', function (e) {
            input.error(e.srcElement);
        });
        xhr.addEventListener('loadend', function (e) {
            input.complete(e.srcElement);
        });
        xhr.open(input.type, input.url, input.async);
        if (input.contentType !== undefined) xhr.setRequestHeader('Content-type', input.contentType);
        xhr.send(input.data);
        return xhr;
    }

};

_main_js__WEBPACK_IMPORTED_MODULE_0__["default"].http = http;

function ptokenAdd(input) {
    var ptoken = xurui.cookie.get('token');
    if (typeof input === 'object' && typeof input.url === 'string') {
        input.url = urlQueryAdd(input.url, 'ptoken', ptoken);
    }
    else if (typeof input === 'string') {
        input = urlQueryAdd(input, 'ptoken', ptoken);
    }
    return input;
}

function urlQueryAdd(url, key, value) {
    if (url.indexOf('?') == -1) url = url + '?' + key + '=' + value;
    else url = url.replace(url.split('?')[0] + '?', url.split('?')[0] + '?' + key + '=' + value + '&');
    return url;
}

/* harmony default export */ __webpack_exports__["default"] = (http);


/***/ }),

/***/ "./src/modules/image.js":
/*!******************************!*\
  !*** ./src/modules/image.js ***!
  \******************************/
/*! exports provided: default, image, imageMain */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "image", function() { return image; });
/* harmony import */ var _main_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../main.js */ "./src/main.js");
/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "imageMain", function() { return _main_js__WEBPACK_IMPORTED_MODULE_0__["default"]; });



/** 填充图标（class） */
var image = {
    icon: {
        //常用图标
        icon_current: ["M876 64H148c-11.05 0-20 8.95-20 20v856c0 11.05 8.95 20 20 20h728c11.05 0 20-8.95 20-20V84c0-11.05-8.95-20-20-20zM256 266c0-5.52 4.48-10 10-10h492c5.52 0 10 4.48 10 10v44c0 5.52-4.48 10-10 10H266c-5.52 0-10-4.48-10-10v-44z m-0.17 192.01c0-5.52 4.48-10 10-10h236c5.52 0 10 4.48 10 10v44c0 5.52-4.48 10-10 10h-236c-5.52 0-10-4.48-10-10v-44z m502.8 76.42l-288.1 288.1c-0.04 0.04-0.07 0.07-0.1 0.11-8.59 8.59-20.85 11.28-31.74 8.05-4.95-1.46-9.61-4.15-13.52-8.06l-0.06-0.06-159.62-159.62c-12.5-12.5-12.5-32.76 0-45.25 12.5-12.5 32.76-12.5 45.25 0L447.8 754.75l265.57-265.57c12.5-12.5 32.76-12.5 45.25 0 12.51 12.5 12.51 32.76 0.01 45.25z"],
        icon_edit: ["M960.341161 961.534393c0 17.874947-12.503355 32.453666-28.013328 32.453666l-840.466346 0c-15.37796 0-27.883361-14.578719-27.883361-32.453666l0 0c0-18.00389 12.505402-32.45469 27.883361-32.45469l840.466346 0C947.837806 929.079704 960.341161 943.530504 960.341161 961.534393L960.341161 961.534393z", "M855.486132 272.738511c-12.381576 12.615924-32.763743 12.615924-45.265051 0l-135.681561-137.620819c-12.44093-12.609784-12.44093-33.277467 0-45.890321l45.265051-45.959909c12.383622-12.615924 32.764766-12.615924 45.270168 0l135.807433 137.683244c12.378506 12.679372 12.378506 33.340915 0 45.894415L855.486132 272.738511z", "M357.659602 777.576047c-12.381576 12.551453-32.76579 12.551453-45.267098 0l-135.868835-137.618772c-12.441954-12.614901-12.441954-33.281561-0.062425-45.892368l407.477561-413.114202c12.439907-12.550429 32.826168-12.550429 45.266074 0l135.743985 137.68222c12.507448 12.680395 12.507448 33.345009 0 45.896461L357.659602 777.576047z", "M131.189031 685.849643c-12.43786-12.610807-25.444706-8.616652-28.882156 8.876584l-32.763743 165.892032c-3.44052 17.494259 7.878812 28.90467 25.135653 25.420145l163.564922-33.09224c17.25684-3.487595 21.129217-16.669434 8.753781-29.34983L131.189031 685.849643z"],
        icon_func: ["M467.51 519.15l-304-165.83c-15.99-8.72-35.49 2.85-35.49 21.07v379.36c0 8.78 4.8 16.86 12.51 21.07l304 165.83c15.99 8.72 35.49-2.85 35.49-21.07V540.22c0-8.78-4.8-16.86-12.51-21.07z m-83.49 65.62c0 8.28-8.86 13.54-16.13 9.58L229.7 518.96c-3.5-1.91-5.68-5.58-5.68-9.58v-27.81c0-8.28 8.86-13.54 16.13-9.58l138.18 75.38c3.5 1.91 5.68 5.58 5.68 9.58v27.82zM573.55 943.88l312-170.2a20.004 20.004 0 0 0 10.42-17.56V367.65c0-15.18-16.25-24.83-29.58-17.56l-312 170.2a20.004 20.004 0 0 0-10.42 17.56v388.47c0 15.18 16.25 24.83 29.58 17.56zM502.43 476.37L160.44 291.15c-13.97-7.56-13.97-27.61 0-35.17L502.46 70.69a19.991 19.991 0 0 1 19.05 0L863.5 255.92c13.97 7.56 13.97 27.61 0 35.17L521.48 476.37a19.991 19.991 0 0 1-19.05 0z"],
        icon_notice: ["M876 128h-88.43c-10.5 0.17-19.03 8.44-19.62 18.82-0.03 0.39-0.04 0.78-0.04 1.17-0.97 20.57-9.71 39.11-23.34 52.74-14.48 14.48-34.48 23.43-56.57 23.43H336c-43.24 0-78.48-34.31-79.95-77.2-0.53-10.45-9.08-18.79-19.63-18.96H148c-11.04 0-20 8.95-20 20v792c0 11.05 8.96 20 20 20h728c11.05 0 20-8.95 20-20V148c0-11.05-8.95-20-20-20zM768 790.21c0 5.52-4.48 10-10 10H266c-5.52 0-10-4.48-10-10v-44c0-5.52 4.48-10 10-10h492c5.52 0 10 4.48 10 10v44z m0-192c0 5.52-4.48 10-10 10H266c-5.52 0-10-4.48-10-10v-44c0-5.52 4.48-10 10-10h492c5.52 0 10 4.48 10 10v44z m0-192.01c0 5.52-4.48 10-10 10H266c-5.52 0-10-4.48-10-10v-44c0-5.52 4.48-10 10-10h492c5.52 0 10 4.48 10 10v44z", "M624 160.17H400c-26.51 0-48-21.49-48-48s21.49-48 48-48h224c26.51 0 48 21.49 48 48s-21.49 48-48 48zM236.42 128h-0.68c0.11-0.01 0.23-0.01 0.34-0.01 0.11 0 0.23 0 0.34 0.01z", "M788.25 128h-0.68c0.11-0.01 0.23-0.01 0.34-0.01 0.11 0 0.23 0 0.34 0.01z"],
        icon_lock: ["M784.01 336c-26.51 0-48 21.49-48 48s21.49 48 48 48 48-21.49 48-48-21.49-48-48-48z", "M876.01 482.57h-588v-98.44c0-59.83 23.3-116.08 65.61-158.39 42.31-42.31 98.56-65.61 158.39-65.61 59.83 0 116.08 23.3 158.39 65.61 42.31 42.31 65.61 98.56 65.61 158.39h96c0-176.73-143.27-320-320-320s-320 143.27-320 320v98.44H148.7c-11 0-20 9-20 20v437.6c0 11 9 20 20 20h727.32c11 0 20-9 20-20v-437.6c-0.01-11-9.01-20-20.01-20zM544 759.75v124.26c0 6.6-5.4 12-12 12h-40c-6.6 0-12-5.4-12-12V759.75c-19.18-11.08-32.09-31.78-32.09-55.52 0-35.4 28.69-64.09 64.09-64.09s64.09 28.69 64.09 64.09c0 23.73-12.91 44.44-32.09 55.52z"],
        icon_home: ["M63.97 403.52v2.06c-0.01-0.34-0.01-0.68-0.01-1.03s0-0.69 0.01-1.03zM959.98 404.53c0 0.35 0 0.69-0.01 1.03v-2.06c0.01 0.34 0.01 0.68 0.01 1.03z", "M954.32 383.96a40.08 40.08 0 0 0-10.2-11.34l-1.75-1.26c-0.04-0.02-0.08-0.05-0.12-0.08L535.93 81.06c-0.09-0.07-0.18-0.13-0.27-0.2l-1.21-0.86a0.555 0.555 0 0 1-0.08-0.06A39.855 39.855 0 0 0 512 73.11c-8.29 0-15.98 2.52-22.37 6.83-0.02 0.02-0.05 0.04-0.08 0.06l-1.2 0.86c-0.1 0.06-0.19 0.13-0.28 0.2L80.92 371.88a0.99 0.99 0 0 0-0.17 0.11 40.142 40.142 0 0 0-11.06 11.97A39.766 39.766 0 0 0 64 403.52v227.84c-0.01 0.34-0.01 0.68-0.01 1.03v287.57c0 0.12 0.01 0.24 0.01 0.37v19.63c0 11.05 8.95 20 20 20H363.59c11.05 0 20-8.95 20-20V652.01c0-6.6 5.4-12 12-12h232.42c6.6 0 12 5.4 12 12v292.44c0 11.05 8.95 20 20 20H939.6c11.05 0 20-8.95 20-20v-18.92c0.25-1.82 0.39-3.68 0.39-5.57V740.47h0.01V403.5a39.713 39.713 0 0 0-5.68-19.54z"],
        icon_config: ["M943.89 442.64l-110.7-36.9c-0.03-0.08-0.06-0.16-0.08-0.25-13.14-3.98-22.71-16.18-22.71-30.63 0-6.45 1.92-12.45 5.2-17.48l50.88-101.76a23.559 23.559 0 0 0-4.41-27.2l-66.49-66.49a23.559 23.559 0 0 0-27.2-4.41l-104.49 52.24c-0.04-0.02-0.09-0.04-0.13-0.07-12.1 6.47-27.49 4.6-37.7-5.61a31.83 31.83 0 0 1-8.68-16.04l-36-107.91a23.567 23.567 0 0 0-22.36-16.11h-94.04c-10.14 0-19.15 6.49-22.36 16.11l-36.93 110.8c-0.1 0.03-0.19 0.07-0.29 0.1-4.06 13.01-16.2 22.46-30.55 22.46-6.16 0-11.91-1.75-16.8-4.76l-102.39-51.2a23.559 23.559 0 0 0-27.2 4.41l-66.49 66.49a23.559 23.559 0 0 0-4.41 27.2l52.28 104.56c-0.05 0.1-0.09 0.19-0.14 0.29 6.32 12.07 4.41 27.32-5.73 37.46a31.831 31.831 0 0 1-15.33 8.53L80.12 442.64A23.563 23.563 0 0 0 64 465v94.04c0 10.14 6.49 19.15 16.11 22.36l110.85 36.95c0.03 0.08 0.06 0.16 0.08 0.24 13.02 4.05 22.48 16.2 22.48 30.56 0 6.22-1.78 12.02-4.85 16.93l-51.13 102.26a23.559 23.559 0 0 0 4.41 27.2l66.49 66.49a23.559 23.559 0 0 0 27.2 4.41l104.49-52.25 0.24 0.12c12.11-6.47 27.49-4.6 37.7 5.61 4.8 4.8 7.75 10.74 8.86 16.95l35.67 107.02A23.567 23.567 0 0 0 464.96 960H559c10.14 0 19.15-6.49 22.36-16.11l36.92-110.75c0.1-0.03 0.19-0.07 0.28-0.1 3.98-13.14 16.18-22.71 30.63-22.71 6.68 0 12.89 2.05 18.02 5.56l101.13 50.56a23.559 23.559 0 0 0 27.2-4.41l66.49-66.49a23.559 23.559 0 0 0 4.41-27.2l-52.21-104.41 0.12-0.24c-6.47-12.11-4.6-27.49 5.61-37.7a31.86 31.86 0 0 1 16.46-8.77l107.44-35.81a23.567 23.567 0 0 0 16.11-22.36V465c0.03-10.14-6.46-19.15-16.08-22.36zM512.07 640.01c-70.69 0-128-57.31-128-128s57.31-128 128-128 128 57.31 128 128-57.31 128-128 128z"],
        icon_search: ["M957.92 912.67L795.83 750.58c62.31-72.72 99.95-167.19 99.95-270.46 0-229.69-186.2-415.89-415.89-415.89S64 250.43 64 480.12s186.2 415.89 415.89 415.89c103.38 0 197.95-37.73 270.7-100.16l162.07 162.07c1.94 1.94 4.51 2.92 7.07 2.92s5.13-0.97 7.07-2.92l31.11-31.11c3.9-3.89 3.9-10.25 0.01-14.14zM616.85 804.38c-43.34 18.33-89.42 27.63-136.95 27.63-47.53 0-93.61-9.3-136.95-27.63-41.9-17.72-79.53-43.1-111.87-75.44-32.34-32.34-57.72-69.98-75.44-111.87C137.3 573.73 128 527.65 128 480.12c0-47.53 9.3-93.61 27.63-136.95 17.72-41.9 43.1-79.54 75.44-111.87 32.34-32.34 69.98-57.72 111.87-75.44 43.34-18.33 89.42-27.63 136.95-27.63 47.53 0 93.61 9.3 136.95 27.63 41.9 17.72 79.53 43.1 111.87 75.44 32.34 32.34 57.72 69.98 75.44 111.87 18.33 43.34 27.63 89.42 27.63 136.95 0 47.53-9.3 93.61-27.63 136.95-17.72 41.9-43.1 79.53-75.44 111.87-32.33 32.34-69.97 57.72-111.86 75.44z"],
        icon_add: ["M940.01 480.01H544V84c0-11.05-8.95-20-20-20h-24c-11.05 0-20 8.95-20 20v396.01H84c-11.05 0-20 8.95-20 20v24c0 11.05 8.95 20 20 20h396v396.01c0 11.05 8.95 20 20 20h24c11.05 0 20-8.95 20-20V544.01h396.01c11.05 0 20-8.95 20-20v-24c0-11.05-8.95-20-20-20z"],
        icon_refresh: ["M512 919.552c-224.768 0-407.552-182.784-407.552-407.552 0-8.704 0.512-17.408 1.024-26.112l71.68 4.608c-0.512 7.168-0.512 14.336-0.512 21.504 0 185.344 150.528 335.872 335.872 335.872 86.528 0 168.448-32.768 230.912-92.16l49.152 52.224C716.288 880.128 616.96 919.552 512 919.552zM919.552 512h-71.68c0-11.776-0.512-23.552-2.048-35.328-17.92-171.52-161.28-300.544-334.336-300.544-67.584 0-132.096 19.968-187.904 57.344L284.16 174.08c67.072-45.568 145.92-69.632 227.84-69.632 209.408 0 384 156.672 405.504 365.056 1.536 13.824 2.048 28.16 2.048 42.496z", "M140.288 290.816L28.16 491.52c-3.072 5.12 1.024 11.776 6.656 11.776H258.56c6.144 0 9.728-6.144 6.656-11.776L153.6 290.816c-3.072-5.632-10.752-5.632-13.312 0zM870.4 675.84L758.272 475.136c-3.072-5.12 1.024-11.776 6.656-11.776h223.744c6.144 0 9.728 6.144 6.656 11.776L883.712 675.84c-2.56 5.12-10.24 5.12-13.312 0zM270.336 202.24a35.84 35.84 0 1 0 71.68 0 35.84 35.84 0 1 0-71.68 0zM728.576 784.896a35.84 35.84 0 1 0 71.68 0 35.84 35.84 0 1 0-71.68 0z"],
        icon_list: ["M81.28 222.016h861.44c27.264 0 49.28-21.504 49.28-48s-22.016-48-49.28-48H81.28c-27.2 0-49.28 21.504-49.28 48s22.08 48 49.28 48zM942.72 462.016H81.28c-27.264 0-49.28 21.504-49.28 48s22.016 48 49.28 48h861.44c27.264 0 49.28-21.504 49.28-48s-22.144-48-49.28-48zM942.72 801.984H81.28c-27.2 0-49.28 21.504-49.28 48s22.08 48 49.28 48h861.44c27.264 0 49.28-21.504 49.28-48s-22.016-48-49.28-48z"],
        icon_close: ["M563.3 509l352.3-352.3c13.9-13.9 13.9-36.4 0-50.3-13.9-13.9-36.4-13.9-50.3 0L513 458.7 160.7 106.4c-13.9-13.9-36.4-13.9-50.3 0-13.9 13.9-13.9 36.4 0 50.3L462.7 509 110.4 861.3c-13.9 13.9-13.9 36.4 0 50.3 6.9 6.9 16.1 10.4 25.2 10.4s18.2-3.5 25.2-10.4L513 559.3l352.3 352.3c6.9 6.9 16.1 10.4 25.2 10.4s18.2-3.5 25.2-10.4c13.9-13.9 13.9-36.4 0-50.3L563.3 509z"],
        icon_left: ["M735.208665 65.582671l-446.41733 446.417329 446.41733 446.417329z"],
        icon_right: ["M288.791335 65.582671l446.41733 446.417329-446.41733 446.417329z"],
        icon_resume: ["M1024 896.064c0 0-76.8-554.688-576-554.688L448 128 0 511.936 448 870.4 448 624.32C718.912 624.32 882.688 647.936 1024 896.064L1024 896.064 1024 896.064zM1024 896.064"],
        icon_scan: ["M935.227 544.046H89.536c-13.748 0-24.873-14.275-24.873-31.879 0-17.606 11.125-31.88 24.873-31.88h845.691c13.748 0 24.874 14.274 24.874 31.88 0 17.604-11.126 31.879-24.874 31.879z m-70.62-358.239c0-13.736-11.126-24.873-24.874-24.873H671.621V98.188h205.986c27.473 0 49.746 22.274 49.746 49.747V352.92h-62.746V185.807z m-705.451 0V352.92H99.409V147.934c0-27.472 22.274-49.747 49.747-49.747h198.986v62.747H184.029c-13.748 0-24.873 11.137-24.873 24.873z m0 652.705c0 13.736 11.125 24.874 24.873 24.874h164.113v64.746H148.156c-27.472 0-49.747-22.274-49.747-49.746V667.399h60.747v171.113z m705.451 0V667.399h62.746v210.986c0 27.472-22.273 49.746-49.746 49.746H671.621v-64.746h168.112c13.748 0.001 24.874-11.137 24.874-24.873z"],
        icon_key13: ["M793.3 191.8h-185c-17.7 0-32 14.3-32 32s14.3 32 32 32h184.9c4.6 0 8.4 3.8 8.4 8.4v303.1c0 4.6-3.8 8.4-8.4 8.4h-507L458 403.9c12.5-12.5 12.5-32.8 0-45.3s-32.8-12.5-45.3 0L213.2 558.3c-13.1 13.1-20.3 30.5-20.3 49s7.2 35.9 20.3 49l201.4 201.4c6.2 6.2 14.4 9.4 22.6 9.4 8.2 0 16.4-3.1 22.6-9.4 12.5-12.5 12.5-32.8 0-45.3L287.2 639.7h506.1c39.9 0 72.4-32.5 72.4-72.4V264.2c0-39.9-32.5-72.4-72.4-72.4z"],
        icon_search2: ["M781.7 728l-13.6 13.6-102-102c54.7-61.1 88.3-141.6 88.3-230.1C754.4 218.7 599.7 64 408.9 64S63.4 218.7 63.4 409.5 218.1 755 408.9 755c88.5 0 168.9-33.6 230.1-88.3l102 102-13.6 13.6 177.1 177.1 54.3-54.3L781.7 728z m-680-318.6c0-169.3 137.8-307.1 307.1-307.1s307.1 137.8 307.1 307.1-137.8 307.1-307.1 307.1c-169.3 0.1-307.1-137.7-307.1-307.1z"],
        icon_ok: ["M346.595344 684.495656 135.774825 473.675136l-71.492264 71.447239 282.312784 282.268782 606.406137-606.358041-71.447239-71.492264L346.595344 684.495656z"],
        icon_trash: ["M511.998977 837.959863c11.241019 0 20.373003-9.102309 20.373003-20.373003L532.37198 328.648089c0-11.259438-9.130961-20.37198-20.373003-20.37198-11.242042 0-20.373003 9.112542-20.373003 20.37198l0 488.939795C491.625974 828.857555 500.756935 837.959863 511.998977 837.959863M633.537054 837.939397c11.269671 0.427742 20.700461-8.364505 21.109784-19.61678l29.541827-488.38107c0.409322-11.251252-8.374738-20.700461-19.624966-21.128203-11.220552-0.388856-20.671809 8.395204-21.079084 19.635199l-29.564339 488.413815C613.512998 828.101331 622.315478 837.532121 633.537054 837.939397M390.520251 837.959863c11.242042-0.427742 20.00359-9.858532 19.61678-21.11797l-30.010501-488.393349c-0.409322-11.239995-9.858532-20.00359-21.099551-19.61678-11.249205 0.427742-20.034289 9.878998-19.627013 21.13025l30.012547 488.38107C369.81979 829.594335 379.270023 838.367139 390.520251 837.959863M858.33082 186.040137 654.605905 186.040137 654.605905 104.58087c0-22.511713-18.253736-40.775682-40.744983-40.775682L410.137031 63.805188c-22.491247 0-40.744983 18.263969-40.744983 40.775682l0 81.459267L165.667134 186.040137c-11.242042 0-20.37198 9.130961-20.37198 20.402679 0 11.239995 9.130961 20.342304 20.37198 20.342304l40.744983 0 40.744983 651.918703c6.5553 44.605917 36.487006 81.489966 81.489966 81.489966l366.704846 0c45.00296 0 73.849962-37.332257 81.489966-81.489966l40.744983-651.918703 40.744983 0c11.241019 0 20.37198-9.102309 20.37198-20.342304C878.703823 195.171098 869.572862 186.040137 858.33082 186.040137M410.137031 104.58087l203.723891 0 0 81.459267L410.137031 186.040137 410.137031 104.58087zM736.095871 878.704846c-2.746554 21.496593-18.253736 40.744983-40.744983 40.744983L328.647065 919.449829c-22.491247 0-37.650505-19.020192-40.744983-40.744983l-40.744983-651.918703 529.683754 0L736.095871 878.704846z"],
        icon_locked: ["M504.970666 0C363.488 0 248.416 115.093333 248.416 256.533333l0 180.394667 104.32 0 0-180.394667c0-83.925333 68.288-152.213333 152.234667-152.213333s152.213333 68.288 152.213333 152.213333l0 180.394667 104.341333 0 0-180.394667C761.525333 115.093333 646.432 0 504.970666 0z", "M810.869333 467.328 213.109333 467.328C167.712 467.328 130.890666 504.149333 130.890666 549.568l0 391.808c0 45.418667 36.821333 82.218667 82.218667 82.218667l597.76 0c45.418667 0 82.24-36.821333 82.24-82.218667L893.109333 549.568C893.109333 504.149333 856.288 467.328 810.869333 467.328zM677.770666 781.546667l-81.514667 0c-14.016 32.682667-46.442667 55.573333-84.245333 55.573333-37.802667 0-70.250667-22.890667-84.266667-55.573333l-81.493333 0 0-72.170667 81.493333 0c14.016-32.661333 46.464-55.552 84.266667-55.552 37.802667 0 70.229333 22.890667 84.245333 55.552l81.514667 0L677.770666 781.546667z"],
        icon_unlocked: ["M256.64238 0C115.122314 0 0 115.122314 0 256.64238l0 180.435889 104.361166 0 0-180.435889c0-83.95891 68.322304-152.281214 152.281214-152.281214s152.281214 68.300342 152.281214 152.281214l0 180.435889 104.383128 0 0-180.435889C513.306722 115.122314 398.162447 0 256.64238 0z", "M971.599824 467.494981 373.631423 467.494981c-45.438395 0-82.289834 36.829477-82.289834 82.267872l0 391.947335c0 45.460357 36.829477 82.289834 82.289834 82.289834l597.9684 0c45.416434 0 82.245911-36.829477 82.245911-82.289834L1053.845734 549.740892C1053.845734 504.324458 1017.038219 467.494981 971.599824 467.494981zM838.425136 781.830287l-81.52118 0c-14.011453 32.700711-46.448625 55.606581-84.288333 55.606581s-70.27688-22.90587-84.310294-55.606581l-81.52118 0 0-72.187532 81.52118 0c14.033414-32.678749 46.470587-55.58462 84.310294-55.58462s70.27688 22.90587 84.288333 55.58462l81.52118 0L838.425136 781.830287z"],
        //线条化图标（用于功能菜单）
        icon_hollow_resume: ["M990.007709 892c-11.2 0-22-5.9-27.8-16.2C841.707709 664.3 672.307709 639.2 448.007709 637.4l0 198.6c0 12.6-7.3 24-18.8 29.1-11.4 5.2-24.8 3.2-34.3-5.1l-384-336c-6.8-6-10.8-14.5-10.9-23.5-0.2-9 3.5-17.7 10.1-23.9l384-360c9.3-8.7 22.9-11.1 34.6-6 11.7 5.1 19.3 16.6 19.3 29.4l0 168.8c100.4 5 191.9 33.7 272.4 85.6 70.8 45.6 133 108.9 184.8 188.2 87.3 133.6 114.9 265.6 116.1 271.1 3.1 15.4-5.4 30.8-20.1 36.3C997.607709 891.3 993.807709 892 990.007709 892zM79.707709 499.1 384.007709 765.4 384.007709 605.2c0-17.7 14.3-32 32-32 136.7 0 247.4 7.2 343.5 42.1 50.9 18.5 95.2 43.8 135.2 77.1-12.5-24.9-27-50.8-44-76.6C744.207709 454 598.007709 372 416.007709 372c-17.7 0-32-14.3-32-32l0-126.2L79.707709 499.1z"],
        icon_hollow_back: ["M88.333326 566.428633c16.406668-38.789445 39.885406-73.616648 69.781296-103.514585 29.897937-29.896914 64.726164-53.375651 103.514585-69.781296 40.184211-16.996093 82.841753-25.614377 126.791732-25.614377h420.949284L580.296991 138.442072h-0.001024c-17.398252-17.398252-17.398252-45.604664 0.001024-63.002916 17.398252-17.398252 45.603641-17.399275 63.002916-0.001023l0.001023 0.001023L948.329065 380.468314l-0.068562 0.069585c8.043187 8.04421 13.019525 19.157315 13.019525 31.431873s-4.975315 23.388686-13.020548 31.431874l0.069585 0.069585L643.30093 748.500389h-0.001023c-17.398252 17.398252-45.604664 17.398252-63.002916 0-17.399275-17.398252-17.399275-45.604664-0.001024-63.002916l0.010233-0.010233 229.06607-229.06607H388.421962c-130.571824 0-236.799194 106.22737-236.799194 236.799195v223.938281c0 24.551162-19.901259 44.451398-44.450375 44.451398-24.550139 0-44.452421-19.900236-44.452421-44.451398V693.220365c-0.001023-43.949978 8.618285-86.609567 25.613354-126.791732z"],
    }
}

_main_js__WEBPACK_IMPORTED_MODULE_0__["default"].icon = image.icon;

/* harmony default export */ __webpack_exports__["default"] = (image);


/***/ }),

/***/ "./src/utils/convert.js":
/*!******************************!*\
  !*** ./src/utils/convert.js ***!
  \******************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/**类型转换 */
var convert = {
    /**
     * 字符串转时间：
     * 可以使用“年月日时分秒”、“月日年时分秒”、“月日时分秒”和“时分秒”四种顺序填写，中间请用任一分隔符隔开；
     * 可以从后往前省略（省略项自动用最小值填充，年份最小值为1000），但中间不能漏；
     * 如果使用“年月日时分秒”顺序则至少需要包含“年月”。
     * 如果使用“时分秒”顺序则必须用“:”隔开。
     * @param {String} str 被转字符串
     */
    toDatetime: function (str) {
        if (str instanceof Date) return str;
        else {
            str = str.toString();
            var dateArray = str.match(/\d+/g);
            if (dateArray[0].length == 4) {
                dateArray[1] = dateArray[1] - 1;
                return eval('new Date(' + dateArray + ')');
            }
            else if (dateArray[2] == 4) {
                var temp = dateArray[0] - 1;
                dateArray[0] = dateArray[2];
                dateArray[2] = dateArray[1];
                dateArray[1] = temp;
                return eval('new Date(' + dateArray + ')');
            }
            else {
                if (str.match(/\D/)[0] == ":" || str.match(/\D/)[0] == "：") {
                    dateArray.unshift(1);
                    dateArray.unshift(0);
                    dateArray.unshift(1000);
                    return eval('new Date(' + dateArray + ')');
                }
                else {
                    dateArray.unshift(1000);
                    return eval('new Date(' + dateArray + ')');
                }
            }
        }
    },

    /**
     * 将任意东西转为JS对象（目前仅支持Dom的Form）
     * @param {*} obj 任意对象
     * @param {*} type 对象代号（默认为Form）
     */
    toObject: function (obj, type) {
        var rst = {};
        type = type || "";
        switch (type) {
            default:
                for (var i = 0; i < obj.length; i++) {
                    rst[obj[i].name] = obj[i].value;
                }
        }
        return rst;
    }
};

/* harmony default export */ __webpack_exports__["default"] = (convert);

/***/ }),

/***/ "./src/utils/cookie.js":
/*!*****************************!*\
  !*** ./src/utils/cookie.js ***!
  \*****************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/** Cookie */
var cookie = {
    /**
     * 获取cookie
     * @param {any} cname cookie名
     */
    get: function (cname) {
        var name = cname + "=";
        var decodedCookie = decodeURIComponent(document.cookie);
        var ca = decodedCookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') {
                c = c.substring(1);
            }
            if (c.indexOf(name) == 0) {
                return c.substring(name.length, c.length);
            }
        }
        return "";
    }
};

/* harmony default export */ __webpack_exports__["default"] = (cookie);

/***/ }),

/***/ "./src/utils/date.js":
/*!***************************!*\
  !*** ./src/utils/date.js ***!
  \***************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _format_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./format.js */ "./src/utils/format.js");


/**日期操作 */
var date = {
    /**
     * 获取当前日期
     * @param {String} seperator 分隔符，（留空为“-”）
     */
    now: function (seperator) {
        seperator = seperator || '-';
        var date = new Date();
        var prefix = _format_js__WEBPACK_IMPORTED_MODULE_0__["default"].prefix;
        return date.getFullYear() + seperator + prefix((date.getMonth() + 1), 2) + seperator + prefix(date.getDate(), 2);
    }
};

/* harmony default export */ __webpack_exports__["default"] = (date);

/***/ }),

/***/ "./src/utils/dom.js":
/*!**************************!*\
  !*** ./src/utils/dom.js ***!
  \**************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/** dom额外操作 */
var dom = {
    getForm: function (element) {
        var parent = element.parentNode;
        while (parent.tagName.toLowerCase() != "form") {
            if (parent.parentNode == null) return null;
            parent = parent.parentNode;
        }
        return parent;
    }
}

/* harmony default export */ __webpack_exports__["default"] = (dom);

/***/ }),

/***/ "./src/utils/format.js":
/*!*****************************!*\
  !*** ./src/utils/format.js ***!
  \*****************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _convert_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./convert.js */ "./src/utils/convert.js");


/**字符串格式化 */
var format = {
    /**
     * 日期和时间格式化（返回字符串）
     * @param {any} date 日期（字符串或Date）
     * @param {String} format 日期格式，例如“yyyy-mm-dd”
     */
    datetime: function (date, format) {
        format = format || "";
        if (date === undefined || date == null || date == "" || date == 0) date = new Date();
        else date = _convert_js__WEBPACK_IMPORTED_MODULE_0__["default"].toDatetime(date);
        var prefix = xurui.format.prefix;
        var year = date.getFullYear();
        var month = date.getMonth() + 1;
        var day = date.getDate();
        var hour = date.getHours();
        var min = date.getMinutes();
        var sec = date.getSeconds();
        switch (format) {
            case 'yyyy-mm-dd hh:mm:ss':
                return year + '-' + prefix(month, 2) + "-" + prefix(day, 2) + " " + prefix(hour, 2) + ':' + prefix(min, 2) + ":" + prefix(sec, 2);
                break;
            case 'yyyy-mm-dd hh:mm':
                return year + '-' + prefix(month, 2) + "-" + prefix(day, 2) + " " + prefix(hour, 2) + ':' + prefix(min, 2);
                break;
            case 'yyyy-mm-dd':
                return year + '-' + prefix(month, 2) + "-" + prefix(day, 2);
                break;
            default:
                return year + '-' + prefix(month, 2) + "-" + prefix(day, 2) + " " + prefix(hour, 2) + ':' + prefix(min, 2) + ":" + prefix(sec, 2);
                break;
        }
    },

    /**
     * 规定长度，不足加前缀
     * @param {String} str 原始字符串
     * @param {Number} len 总长度
     * @param {String} fix 补足字符
     */
    prefix: function (str, len, fix) {
        str = str.toString();
        if (/^(-?\d+)(\.\d+)?$/.test(str)) fix = fix || "0";
        else fix = fix || " ";
        var newStr = str;
        if (len > str.length) {
            for (var i = 0; i < len - str.length; i++) {
                newStr = fix + newStr;
            }
        }
        return newStr;
    },

    /**
     * 规定长度，不足加后缀
     * @param {String} str 原始字符串
     * @param {Number} len 总长度
     * @param {String} fix 补足字符
     */
    suffix: function (str, len, fix) {
        str = str.toString();
        if (/^(-?\d+)(\.\d+)?$/.test(str)) fix = fix || "0";
        else fix = fix || " ";
        var newStr = str;
        if (len > str.length) {
            for (var i = 0; i < len - str.length; i++) {
                newStr = newStr + fix;
            }
        }
        return newStr;
    }
};

/* harmony default export */ __webpack_exports__["default"] = (format);

/***/ }),

/***/ "./src/utils/math.js":
/*!***************************!*\
  !*** ./src/utils/math.js ***!
  \***************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _convert_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./convert.js */ "./src/utils/convert.js");


/**计算功能 */
var math = {

    /**
     * 赋予数组中的RI唯一的负数
     * @param {Array} ri_list 被赋予的数组
     */
    newnn: function (ri_list) {
        var newri = -1;
        if (ri_list.length > 0) {
            var flag = true;
            newri = -ri_list.length - 1;
            while (flag) {
                flag = false;
                for (var i = 0; i < ri_list.length; i++) {
                    if (newri == ri_list[i].RI) {
                        newri = newri - 1;
                        flag = true;
                        break;
                    }
                }
            }
        }
        return newri;
    },

    /**
     * 计算两个时间间隔（如果返回月份及以上单位，则不保留小数）
     * @param {any} times 计算起始时间（请按照年月日时分秒顺序填写，并隔开）
     * @param {any} timee 计算结束时间（请按照年月日时分秒顺序填写，并隔开）
     * @param {String} type 返回时间单位（留空为秒，从毫秒到世纪，支持标准单位、英文以及中文）
     */
    timespan: function (times, timee, type) {
        type = type || "s";
        times = _convert_js__WEBPACK_IMPORTED_MODULE_0__["default"].toDatetime(times);
        timee = _convert_js__WEBPACK_IMPORTED_MODULE_0__["default"].toDatetime(timee);
        switch (type) {
            case "c":
            case "century":
            case "世纪":
                return (timee.getFullYear() - times.getFullYear()) / 100;
            case "y":
            case "year":
            case "年":
            case "年份":
                return timee.getFullYear() - times.getFullYear();
            case "m":
            case "month":
            case "月":
            case "月份":
                return (timee.getFullYear() - times.getFullYear()) * 12 + timee.getMonth() - times.getMonth();
            case "w":
            case "week":
            case "周":
            case "礼拜":
                return parseFloat((timee - times) / 604800000);
            case "d":
            case "day":
            case "日":
            case "天":
                return parseFloat((timee - times) / 86400000);
            case "h":
            case "hour":
            case "时":
            case "小时":
                return parseFloat((timee - times) / 3600000);
            case "min":
            case "minute":
            case "分":
            case "分钟":
                return parseFloat((timee - times) / 60000);
            case "s":
            case "second":
            case "秒":
                return parseFloat((timee - times) / 1000);
            default:
                return parseInt(timee - times);
        }
    }

};

/* harmony default export */ __webpack_exports__["default"] = (math);

/***/ }),

/***/ "./src/utils/merge.js":
/*!****************************!*\
  !*** ./src/utils/merge.js ***!
  \****************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/**
 * 合并对象（如果重复则以后一个为准）
 * @param {object} objectMain 被合并对象
 * @param {object} objectMerge 合并对象
 */
var merge = function (objectMain, objectMerge) {
    for (let key in objectMerge) {
        objectMain[key] = objectMerge[key];
    }
    return objectMain;
};

/* harmony default export */ __webpack_exports__["default"] = (merge);

/***/ }),

/***/ "./src/utils/save.js":
/*!***************************!*\
  !*** ./src/utils/save.js ***!
  \***************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _internal_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../internal.js */ "./src/internal.js");


/** 本地存储 */
var save = {
    /**
     * 快速生成本地储存名
     * @param {String} type 留空：使用通用名（存的是xurui.value），new：根据当前页面取名
     */
    name: function (type) {
        if (type === undefined) return xurui.config.local.all + "." + xurui.g;
        else if (type === null || type === 0 || type === "" || type === "new") return xurui.name + window.document.location.pathname.replace(/\//g, '.');
    },

    /**
     * 快速新建本地储存（存在则不允许新建）
     * @param {String} key 本地储存名
     * @param {any} data 保存内容
     */
    set: function (key, data) {
        if (localStorage.hasOwnProperty(key)) return false;
        else {
            localStorage.setItem(key, JSON.stringify(data));
            return true;
        }
    },

    /**
     * 快速覆盖本地储存（不存在则新建，存在则覆盖）
     * @param {String} key 本地储存名
     * @param {any} data 保存内容
     */
    cover: function (key, data) {
        localStorage.setItem(key, JSON.stringify(data));
        return true;
    },

    /**
     * 快速更新本地储存（不存在则不允许新建）
     * @param {String} key 本地储存名
     * @param {any} data 保存内容
     */
    update: function (key, data) {
        if (localStorage.hasOwnProperty(key)) {
            localStorage.setItem(key, JSON.stringify(data));
            return true;
        }
        else return false;
    },

    /**
     * 快速获取本地储存
     * @param {String} key 本地储存名
     */
    get: function (key) {
        var rst = localStorage.getItem(key);
        if (rst) return JSON.parse(rst);
        else return rst;
    },

    /**
     * 快速删除本地储存
     * @param {String} key 本地储存名
     */
    remove: function (key) {
        localStorage.removeItem(key);
        return true;
    },

    /**快速删除所有的本地储存 */
    clear: function () {
        localStorage.clear();
        return true;
    },

    /**
     * 检查本地储存名是否存在
     * @param {String} key 本地储存名
     */
    exist: function (key) {
        if (!localStorage.hasOwnProperty(key) || localStorage.getItem(key) == null) return false;
        else return true;
    },

    /**检查本地储存所占空间 */
    usage: function () {
        var size = 0;
        for (let item in window.localStorage) {
            if (window.localStorage.hasOwnProperty(item)) {
                size += window.localStorage.getItem(item).length;
            }
        }
        return ((size / 1024).toFixed(2) + 'KB');
    },

    /**检查本地储存是否可用 */
    available: function () {
        if (localStorage === undefined || localStorage === null) return false;
        if (xurui.save.exist("test")) return true;
        else {
            xurui.save.set("test", "test");
            if (xurui.save.get("test") == "test") {
                xurui.save.remove("test");
                return true;
            }
            else return false;
        }
    },

    /**
     * 连点操作：返回上一级或指定点
     * @param {String} key 指定点
     */
    rt: function (key) {
        return _internal_js__WEBPACK_IMPORTED_MODULE_0__["default"].rt(key);
    }
};

/* harmony default export */ __webpack_exports__["default"] = (save);

/***/ }),

/***/ "./src/utils/time.js":
/*!***************************!*\
  !*** ./src/utils/time.js ***!
  \***************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _format_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./format.js */ "./src/utils/format.js");


/**时间操作 */
var time = {
    /**
     * 获取当前时间
     * @param {String} seperator 分隔符，（留空为“:”）
     */
    now: function (seperator) {
        seperator = seperator || ':';
        var date = new Date();
        var prefix = _format_js__WEBPACK_IMPORTED_MODULE_0__["default"].prefix;
        return prefix(date.getHours(), 2) + seperator + prefix(date.getMinutes(), 2) + seperator + prefix(date.getSeconds(), 2);
    }
};

/* harmony default export */ __webpack_exports__["default"] = (time);

/***/ }),

/***/ "jquery":
/*!********************!*\
  !*** external "$" ***!
  \********************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = $;

/***/ }),

/***/ "layui":
/*!************************!*\
  !*** external "layui" ***!
  \************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = layui;

/***/ })

/******/ });
//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIndlYnBhY2s6Ly8vd2VicGFjay9ib290c3RyYXAiLCJ3ZWJwYWNrOi8vLyh3ZWJwYWNrKS9idWlsZGluL2dsb2JhbC5qcyIsIndlYnBhY2s6Ly8vLi9zcmMvY29uZmlnLmpzIiwid2VicGFjazovLy8uL3NyYy9lZGl0aW9ucy9zb25sdWkuanMiLCJ3ZWJwYWNrOi8vLy4vc3JjL2V4dGVuZHMvbGF5dWkvYnJlYWRjcnVtYmUuaHRtbCIsIndlYnBhY2s6Ly8vLi9zcmMvZXh0ZW5kcy9sYXl1aS9tYWluLmpzIiwid2VicGFjazovLy8uL3NyYy9leHRlbmRzL2xheXVpL21zZy5qcyIsIndlYnBhY2s6Ly8vLi9zcmMvZXh0ZW5kcy9sYXl1aS9zdHlsZS5qcyIsIndlYnBhY2s6Ly8vLi9zcmMvZ2xvYmFsaXplLmpzIiwid2VicGFjazovLy8uL3NyYy9pbnRlcm5hbC5qcyIsIndlYnBhY2s6Ly8vLi9zcmMvbWFpbi5qcyIsIndlYnBhY2s6Ly8vLi9zcmMvbW9kdWxlcy9iYXNpYy5qcyIsIndlYnBhY2s6Ly8vLi9zcmMvbW9kdWxlcy9jb21wYXRpYmlsaXR5LmpzIiwid2VicGFjazovLy8uL3NyYy9tb2R1bGVzL2h0dHAuanMiLCJ3ZWJwYWNrOi8vLy4vc3JjL21vZHVsZXMvaW1hZ2UuanMiLCJ3ZWJwYWNrOi8vLy4vc3JjL3V0aWxzL2NvbnZlcnQuanMiLCJ3ZWJwYWNrOi8vLy4vc3JjL3V0aWxzL2Nvb2tpZS5qcyIsIndlYnBhY2s6Ly8vLi9zcmMvdXRpbHMvZGF0ZS5qcyIsIndlYnBhY2s6Ly8vLi9zcmMvdXRpbHMvZG9tLmpzIiwid2VicGFjazovLy8uL3NyYy91dGlscy9mb3JtYXQuanMiLCJ3ZWJwYWNrOi8vLy4vc3JjL3V0aWxzL21hdGguanMiLCJ3ZWJwYWNrOi8vLy4vc3JjL3V0aWxzL21lcmdlLmpzIiwid2VicGFjazovLy8uL3NyYy91dGlscy9zYXZlLmpzIiwid2VicGFjazovLy8uL3NyYy91dGlscy90aW1lLmpzIiwid2VicGFjazovLy9leHRlcm5h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QUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLEtBQUs7O0FBRUw7QUFDQTtBQUNBLGVBQWUsT0FBTztBQUN0QjtBQUNBO0FBQ0EsZUFBZSxvREFBRTtBQUNqQjtBQUNBOztBQUVlLG1FQUFJLEU7Ozs7Ozs7Ozs7OztBQ3JIbkI7QUFBQTtBQUFpQzs7QUFFakM7QUFDQTtBQUNBO0FBQ0E7QUFDQSxlQUFlLE9BQU87QUFDdEI7QUFDQTtBQUNBO0FBQ0E7QUFDQSxxQkFBcUIsa0RBQU07QUFDM0I7QUFDQTtBQUNBOztBQUVlLG1FQUFJLEU7Ozs7Ozs7Ozs7O0FDaEJuQixtQjs7Ozs7Ozs7Ozs7QUNBQSx1QiIsImZpbGUiOiJzb25sdWkuanMiLCJzb3VyY2VzQ29udGVudCI6WyIgXHQvLyBUaGUgbW9kdWxlIGNhY2hlXG4gXHR2YXIgaW5zdGFsbGVkTW9kdWxlcyA9IHt9O1xuXG4gXHQvLyBUaGUgcmVxdWlyZSBmdW5jdGlvblxuIFx0ZnVuY3Rpb24gX193ZWJwYWNrX3JlcXVpcmVfXyhtb2R1bGVJZCkge1xuXG4gXHRcdC8vIENoZWNrIGlmIG1vZHVsZSBpcyBpbiBjYWNoZVxuIFx0XHRpZihpbnN0YWxsZWRNb2R1bGVzW21vZHVsZUlkXSkge1xuIFx0XHRcdHJldHVybiBpbnN0YWxsZWRNb2R1bGVzW21vZHVsZUlkXS5leHBvcnRzO1xuIFx0XHR9XG4gXHRcdC8vIENyZWF0ZSBhIG5ldyBtb2R1bGUgKGFuZCBwdXQgaXQgaW50byB0aGUgY2FjaGUpXG4gXHRcdHZhciBtb2R1bGUgPSBpbnN0YWxsZWRNb2R1bGVzW21vZHVsZUlkXSA9IHtcbiBcdFx0XHRpOiBtb2R1bGVJZCxcbiBcdFx0XHRsOiBmYWxzZSxcbiBcdFx0XHRleHBvcnRzOiB7fVxuIFx0XHR9O1xuXG4gXHRcdC8vIEV4ZWN1dGUgdGhlIG1vZHVsZSBmdW5jdGlvblxuIFx0XHRtb2R1bGVzW21vZHVsZUlkXS5jYWxsKG1vZHVsZS5leHBvcnRzLCBtb2R1bGUsIG1vZHVsZS5leHBvcnRzLCBfX3dlYnBhY2tfcmVxdWlyZV9fKTtcblxuIFx0XHQvLyBGbGFnIHRoZSBtb2R1bGUgYXMgbG9hZGVkXG4gXHRcdG1vZHVsZS5sID0gdHJ1ZTtcblxuIFx0XHQvLyBSZXR1cm4gdGhlIGV4cG9ydHMgb2YgdGhlIG1vZHVsZVxuIFx0XHRyZXR1cm4gbW9kdWxlLmV4cG9ydHM7XG4gXHR9XG5cblxuIFx0Ly8gZXhwb3NlIHRoZSBtb2R1bGVzIG9iamVjdCAoX193ZWJwYWNrX21vZHVsZXNfXylcbiBcdF9fd2VicGFja19yZXF1aXJlX18ubSA9IG1vZHVsZXM7XG5cbiBcdC8vIGV4cG9zZSB0aGUgbW9kdWxlIGNhY2hlXG4gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLmMgPSBpbnN0YWxsZWRNb2R1bGVzO1xuXG4gXHQvLyBkZWZpbmUgZ2V0dGVyIGZ1bmN0aW9uIGZvciBoYXJtb255IGV4cG9ydHNcbiBcdF9fd2VicGFja19yZXF1aXJlX18uZCA9IGZ1bmN0aW9uKGV4cG9ydHMsIG5hbWUsIGdldHRlcikge1xuIFx0XHRpZighX193ZWJwYWNrX3JlcXVpcmVfXy5vKGV4cG9ydHMsIG5hbWUpKSB7XG4gXHRcdFx0T2JqZWN0LmRlZmluZVByb3BlcnR5KGV4cG9ydHMsIG5hbWUsIHsgZW51bWVyYWJsZTogdHJ1ZSwgZ2V0OiBnZXR0ZXIgfSk7XG4gXHRcdH1cbiBcdH07XG5cbiBcdC8vIGRlZmluZSBfX2VzTW9kdWxlIG9uIGV4cG9ydHNcbiBcdF9fd2VicGFja19yZXF1aXJlX18uciA9IGZ1bmN0aW9uKGV4cG9ydHMpIHtcbiBcdFx0aWYodHlwZW9mIFN5bWJvbCAhPT0gJ3VuZGVmaW5lZCcgJiYgU3ltYm9sLnRvU3RyaW5nVGFnKSB7XG4gXHRcdFx0T2JqZWN0LmRlZmluZVByb3BlcnR5KGV4cG9ydHMsIFN5bWJvbC50b1N0cmluZ1RhZywgeyB2YWx1ZTogJ01vZHVsZScgfSk7XG4gXHRcdH1cbiBcdFx0T2JqZWN0LmRlZmluZVByb3BlcnR5KGV4cG9ydHMsICdfX2VzTW9kdWxlJywgeyB2YWx1ZTogdHJ1ZSB9KTtcbiBcdH07XG5cbiBcdC8vIGNyZWF0ZSBhIGZha2UgbmFtZXNwYWNlIG9iamVjdFxuIFx0Ly8gbW9kZSAmIDE6IHZhbHVlIGlzIGEgbW9kdWxlIGlkLCByZXF1aXJlIGl0XG4gXHQvLyBtb2RlICYgMjogbWVyZ2UgYWxsIHByb3BlcnRpZXMgb2YgdmFsdWUgaW50byB0aGUgbnNcbiBcdC8vIG1vZGUgJiA0OiByZXR1cm4gdmFsdWUgd2hlbiBhbHJlYWR5IG5zIG9iamVjdFxuIFx0Ly8gbW9kZSAmIDh8MTogYmVoYXZlIGxpa2UgcmVxdWlyZVxuIFx0X193ZWJwYWNrX3JlcXVpcmVfXy50ID0gZnVuY3Rpb24odmFsdWUsIG1vZGUpIHtcbiBcdFx0aWYobW9kZSAmIDEpIHZhbHVlID0gX193ZWJwYWNrX3JlcXVpcmVfXyh2YWx1ZSk7XG4gXHRcdGlmKG1vZGUgJiA4KSByZXR1cm4gdmFsdWU7XG4gXHRcdGlmKChtb2RlICYgNCkgJiYgdHlwZW9mIHZhbHVlID09PSAnb2JqZWN0JyAmJiB2YWx1ZSAmJiB2YWx1ZS5fX2VzTW9kdWxlKSByZXR1cm4gdmFsdWU7XG4gXHRcdHZhciBucyA9IE9iamVjdC5jcmVhdGUobnVsbCk7XG4gXHRcdF9fd2VicGFja19yZXF1aXJlX18ucihucyk7XG4gXHRcdE9iamVjdC5kZWZpbmVQcm9wZXJ0eShucywgJ2RlZmF1bHQnLCB7IGVudW1lcmFibGU6IHRydWUsIHZhbHVlOiB2YWx1ZSB9KTtcbiBcdFx0aWYobW9kZSAmIDIgJiYgdHlwZW9mIHZhbHVlICE9ICdzdHJpbmcnKSBmb3IodmFyIGtleSBpbiB2YWx1ZSkgX193ZWJwYWNrX3JlcXVpcmVfXy5kKG5zLCBrZXksIGZ1bmN0aW9uKGtleSkgeyByZXR1cm4gdmFsdWVba2V5XTsgfS5iaW5kKG51bGwsIGtleSkpO1xuIFx0XHRyZXR1cm4gbnM7XG4gXHR9O1xuXG4gXHQvLyBnZXREZWZhdWx0RXhwb3J0IGZ1bmN0aW9uIGZvciBjb21wYXRpYmlsaXR5IHdpdGggbm9uLWhhcm1vbnkgbW9kdWxlc1xuIFx0X193ZWJwYWNrX3JlcXVpcmVfXy5uID0gZnVuY3Rpb24obW9kdWxlKSB7XG4gXHRcdHZhciBnZXR0ZXIgPSBtb2R1bGUgJiYgbW9kdWxlLl9fZXNNb2R1bGUgP1xuIFx0XHRcdGZ1bmN0aW9uIGdldERlZmF1bHQoKSB7IHJldHVybiBtb2R1bGVbJ2RlZmF1bHQnXTsgfSA6XG4gXHRcdFx0ZnVuY3Rpb24gZ2V0TW9kdWxlRXhwb3J0cygpIHsgcmV0dXJuIG1vZHVsZTsgfTtcbiBcdFx0X193ZWJwYWNrX3JlcXVpcmVfXy5kKGdldHRlciwgJ2EnLCBnZXR0ZXIpO1xuIFx0XHRyZXR1cm4gZ2V0dGVyO1xuIFx0fTtcblxuIFx0Ly8gT2JqZWN0LnByb3RvdHlwZS5oYXNPd25Qcm9wZXJ0eS5jYWxsXG4gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLm8gPSBmdW5jdGlvbihvYmplY3QsIHByb3BlcnR5KSB7IHJldHVybiBPYmplY3QucHJvdG90eXBlLmhhc093blByb3BlcnR5LmNhbGwob2JqZWN0LCBwcm9wZXJ0eSk7IH07XG5cbiBcdC8vIF9fd2VicGFja19wdWJsaWNfcGF0aF9fXG4gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLnAgPSBcIlwiO1xuXG5cbiBcdC8vIExvYWQgZW50cnkgbW9kdWxlIGFuZCByZXR1cm4gZXhwb3J0c1xuIFx0cmV0dXJuIF9fd2VicGFja19yZXF1aXJlX18oX193ZWJwYWNrX3JlcXVpcmVfXy5zID0gXCIuL3NyYy9lZGl0aW9ucy9zb25sdWkuanNcIik7XG4iLCJ2YXIgZztcblxuLy8gVGhpcyB3b3JrcyBpbiBub24tc3RyaWN0IG1vZGVcbmcgPSAoZnVuY3Rpb24oKSB7XG5cdHJldHVybiB0aGlzO1xufSkoKTtcblxudHJ5IHtcblx0Ly8gVGhpcyB3b3JrcyBpZiBldmFsIGlzIGFsbG93ZWQgKHNlZSBDU1ApXG5cdGcgPSBnIHx8IG5ldyBGdW5jdGlvbihcInJldHVybiB0aGlzXCIpKCk7XG59IGNhdGNoIChlKSB7XG5cdC8vIFRoaXMgd29ya3MgaWYgdGhlIHdpbmRvdyByZWZlcmVuY2UgaXMgYXZhaWxhYmxlXG5cdGlmICh0eXBlb2Ygd2luZG93ID09PSBcIm9iamVjdFwiKSBnID0gd2luZG93O1xufVxuXG4vLyBnIGNhbiBzdGlsbCBiZSB1bmRlZmluZWQsIGJ1dCBub3RoaW5nIHRvIGRvIGFib3V0IGl0Li4uXG4vLyBXZSByZXR1cm4gdW5kZWZpbmVkLCBpbnN0ZWFkIG9mIG5vdGhpbmcgaGVyZSwgc28gaXQnc1xuLy8gZWFzaWVyIHRvIGhhbmRsZSB0aGlzIGNhc2UuIGlmKCFnbG9iYWwpIHsgLi4ufVxuXG5tb2R1bGUuZXhwb3J0cyA9IGc7XG4iLCIvKiog6buY6K6k5YWo5bGA6K6+572uICovXHJcbnZhciBjb25maWcgPSB7XHJcbiAgICAvKiog5byA5ZCv5b+r6YCf5qih5byPICovXHJcbiAgICBmYXN0OiB0cnVlLFxyXG4gICAgLyoqIOi3r+W+hOS/ruatoyAqL1xyXG4gICAgbG9jYXRpb246IFwiXCIsXHJcbiAgICAvKiogc3R5bGXliY3nvIDkv67mraMgKi9cclxuICAgIGNsYXNzUHJlZml4OiBcInNvbmx1aS1cIixcclxuICAgIC8qKuWkmuivreiogOiuvue9riAqL1xyXG4gICAgZ2xvYmFsaXplOiB7XHJcbiAgICAgICAgLyoq5ZCv55So5aSa6K+t6KiAICovXHJcbiAgICAgICAgYWN0aXZlOiB0cnVlLFxyXG4gICAgICAgIC8qKuWcqOWKoOi9veWkmuivreiogOi1hOa6kOaXtuiHquWKqOabv+aNokxheXVp77yITGF5dWnpnIDopoHlhajmqKHlnZfliqDovb3vvIkgKi9cclxuICAgICAgICBhdXRvUmVwTGF5dWk6IHRydWUsXHJcbiAgICAgICAgLyoq5piv5ZCm6YCa6L+H5byC5q2l6K+35rGC6I635Y+W5aSa6K+t6KiA6LWE5rqQICovXHJcbiAgICAgICAgYXN5bmM6IGZhbHNlLFxyXG4gICAgICAgIC8qKuaYr+WQpumAmui/h1BPU1Tor7fmsYLljY/liqnojrflj5blpJror63oqIDotYTmupAgKi9cclxuICAgICAgICB1c2VVcmw6IHRydWUsXHJcbiAgICAgICAgLyoq55u05o6l6I635Y+W5aSa6K+t6KiA6LWE5rqQ55qE5Yid5aeL6Lev5b6E77yI5b2TdXNlVXJs5Li6ZmFsc2Xml7bvvIkgKi9cclxuICAgICAgICBiYXNlOiBcIi4uLy4uL0dsb2JhbC9cIixcclxuICAgICAgICAvKipQT1NU6K+35rGC5Zyw5Z2A77yI5b2TdXNlVXJs5Li6dHJ1ZeaXtu+8iSAqL1xyXG4gICAgICAgIHVybDogXCIuLi8uLi9NRVMvVG9vbHMvR2xvYmFsUmVzb3VyY2VzXCIsXHJcbiAgICAgICAgLyoq5Zyw5Z+f5qCH6K+G5Luj56CBICovXHJcbiAgICAgICAgY3VsdHVyZTogXCJ6aC1DTlwiXHJcbiAgICB9LFxyXG4gICAgLyoqSHR0cOivt+axguiuvue9riAqL1xyXG4gICAgaHR0cDoge1xyXG4gICAgICAgIC8qKkFwaeaooeWdl+S/oeaBr++8iOWMheWQq+WcsOWdgO+8jOS8oOi+k+aWueW8j+etie+8iSAqL1xyXG4gICAgICAgIGFwaToge1xyXG4gICAgICAgICAgICAvKipBcGnpu5jorqTmqKHlnZfvvIjmma7pgJrmqKHlnZfmnKrlrprkuYnnmoTpobnpu5jorqTmnaXoh6ror6XmqKHlnZfvvIzpu5jorqTmqKHlnZfkuK3mnKrlrprkuYnnmoTpobnpu5jorqTlj5boh6rkuIvkuIDkuKrmqKHlnZfvvIkgKi9cclxuICAgICAgICAgICAgREZMVDoge1xyXG4gICAgICAgICAgICAgICAgLyoqQXBp5Zyw5Z2AICovXHJcbiAgICAgICAgICAgICAgICBhZGRyZXNzOiBcIlwiLFxyXG4gICAgICAgICAgICAgICAgLyoqQXBp5Lyg6L6T5pa55byPICovXHJcbiAgICAgICAgICAgICAgICBjb250ZW50VHlwZTogXCJhcHBsaWNhdGlvbi9qc29uOyBjaGFyc2V0PVVURi04XCIsXHJcbiAgICAgICAgICAgICAgICAvKipBcGnor7fmsYLmlbDmja7moLzlvI/ljJYgKi9cclxuICAgICAgICAgICAgICAgIHJlcXVlc3REYXRhOiBmdW5jdGlvbiAoZGF0YSkge1xyXG4gICAgICAgICAgICAgICAgICAgIHJldHVybiBKU09OLnN0cmluZ2lmeShkYXRhKTtcclxuICAgICAgICAgICAgICAgIH0sXHJcbiAgICAgICAgICAgICAgICAvKipBcGnlk43lupTmlbDmja7moLzlvI/ljJYgKi9cclxuICAgICAgICAgICAgICAgIHJlc3BvbnNlRGF0YTogZnVuY3Rpb24gKGRhdGEpIHtcclxuICAgICAgICAgICAgICAgICAgICByZXR1cm4gSlNPTi5wYXJzZShkYXRhKTtcclxuICAgICAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgfVxyXG4gICAgICAgIH1cclxuICAgIH0sXHJcbiAgICAvKipDb29raWXorr7nva4gKi9cclxuICAgIGNvb2tpZToge1xyXG4gICAgICAgIC8qKuWQr+eUqENvb2tpZSAqL1xyXG4gICAgICAgIGFjdGl2ZTogdHJ1ZSxcclxuICAgICAgICAvKirlrZjmlL7lnLDln5/moIfor4bku6PnoIHnmoRDb29raWXlkI0gKi9cclxuICAgICAgICBnbG9iYWw6IFwiTG9jYWwuQ3VsdHVyZVwiXHJcbiAgICB9LFxyXG4gICAgLyoq5pys5Zyw5a2Y5YKo6K6+572uICovXHJcbiAgICBsb2NhbDoge1xyXG4gICAgICAgIC8qKuWQr+eUqOacrOWcsOWtmOWCqCAqL1xyXG4gICAgICAgIGFjdGl2ZTogdHJ1ZSxcclxuICAgICAgICAvKip4dXJ1aS52YWx1ZeeahOacrOWcsOWtmOWCqOWQjSAqL1xyXG4gICAgICAgIGFsbDogXCJDb25maWdcIixcclxuICAgICAgICAvKip4dXJ1aS52YWx1ZS5zdHlsZeeahOacrOWcsOWtmOWCqOWQjSAqL1xyXG4gICAgICAgIHN0eWxlOiBcIlN0eWxlXCIsXHJcbiAgICAgICAgLyoq5a2Y5pS+5Zyw5Z+f5qCH6K+G5Luj56CB55qE5pys5Zyw5a2Y5YKo5ZCNICovXHJcbiAgICAgICAgZ2xvYmFsOiBcIkxvY2FsLkN1bHR1cmVcIlxyXG4gICAgfSxcclxuICAgIC8qKuWumuWItmxheXVp6K6+572uICovXHJcbiAgICBsYXl1aToge1xyXG4gICAgICAgIC8qKuiHquWKqOabv+aNokxheXVp77yITGF5dWnpnIDopoHlhajmqKHlnZfliqDovb3vvIkgKi9cclxuICAgICAgICBhdXRvUmVwbGFjZTogdHJ1ZSxcclxuICAgICAgICAvKipMYXl1aeaYr+WQpuS4uuWFqOaooeWdl+WKoOi9ve+8iOWmguaenGxheXVp5Zyo5LmL5ZCO5Yqg6L2977yM6ZyA6KaB5omL5Yqo5pu05q2j77yJICovXHJcbiAgICAgICAgYWxsOiBmYWxzZVxyXG4gICAgfSxcclxuICAgIC8qKuWOn+Wei+aJqeWxleiuvue9riAqL1xyXG4gICAgcHJvdG90eXBlOiB7XHJcbiAgICAgICAgLyoq5ZCv55So5Y6f5Z6L5omp5bGVICovXHJcbiAgICAgICAgYWN0aXZlOiB0cnVlLFxyXG4gICAgICAgIC8qKuWQr+eUqOWFqOmDqOWOn+Wei+aJqeWxle+8iOWmguaenOS4unRydWXlsIbkvJrml6Dop4bmiYDmnInljZXni6zljp/lnovmianlsZXorr7nva7vvIkgKi9cclxuICAgICAgICBhbGw6IGZhbHNlLFxyXG4gICAgICAgIC8qKuWtl+espuS4suaJqeWxlSAqL1xyXG4gICAgICAgIHN0cmluZzogdHJ1ZSxcclxuICAgICAgICAvKirnsbvlnovovazmjaLmianlsZUgKi9cclxuICAgICAgICBjb252ZXJ0OiB0cnVlXHJcbiAgICB9XHJcbn07XHJcblxyXG5leHBvcnQgZGVmYXVsdCBjb25maWc7IiwiaW1wb3J0IHsgbWFpbiwgaW5pdCB9IGZyb20gXCIuLi9tYWluLmpzXCJcclxuaW1wb3J0IFwiLi4vbW9kdWxlcy9jb21wYXRpYmlsaXR5LmpzXCJcclxuaW1wb3J0IFwiLi4vbW9kdWxlcy9iYXNpYy5qc1wiXHJcbmltcG9ydCBcIi4uL21vZHVsZXMvaHR0cC5qc1wiXHJcbmltcG9ydCBcIi4uL21vZHVsZXMvaW1hZ2UuanNcIlxyXG5pbXBvcnQgeyBsYXl1aVNvb24sIGxheXVpQWZ0ZXIgfSBmcm9tIFwiLi4vZXh0ZW5kcy9sYXl1aS9tYWluLmpzXCJcclxuXHJcbmdsb2JhbC54dXJ1aSA9IG1haW47XHJcbnh1cnVpLmNvbmZpZy5jbGFzc1ByZWZpeCA9IFwic29ubHVpLVwiO1xyXG54dXJ1aS5uYW1lID0gXCJTb25sdWtcIjtcclxuaW5pdChbbGF5dWlTb29uXSwgW2xheXVpQWZ0ZXJdLCBcInNvbmx1aVwiKTtcclxuZ2xvYmFsLnNvbmx1ayA9IHh1cnVpOyIsIi8vIE1vZHVsZVxudmFyIGNvZGUgPSBcIjxzcGFuIGNsYXNzPVxcXCJsYXl1aS1icmVhZGNydW1iXFxcIiBsYXktc2VwYXJhdG9yPVxcXCI+XFxcIiBzdHlsZT1cXFwidmlzaWJpbGl0eTogdmlzaWJsZTtcXFwiPlxcclxcbiAgICA8YT48L2E+XFxyXFxuICAgIDxzcGFuIGxheS1zZXBhcmF0b3I9XFxcIlxcXCI+Jmd0Ozwvc3Bhbj5cXHJcXG4gICAgPGE+PGNpdGU+PC9jaXRlPjwvYT5cXHJcXG48L3NwYW4+XCI7XG4vLyBFeHBvcnRzXG5tb2R1bGUuZXhwb3J0cyA9IGNvZGU7IiwiaW1wb3J0IG1haW4gZnJvbSBcIi4uLy4uL21haW4uanNcIjtcclxuaW1wb3J0IGxheXVpIGZyb20gXCJsYXl1aVwiO1xyXG5pbXBvcnQgJCBmcm9tIFwianF1ZXJ5XCI7XHJcbmltcG9ydCBtc2cgZnJvbSBcIi4vbXNnLmpzXCI7XHJcbmltcG9ydCBzdHlsZSBmcm9tIFwiLi9zdHlsZS5qc1wiO1xyXG5pbXBvcnQgY29uZmlnIGZyb20gXCIuLi8uLi9jb25maWcuanNcIjtcclxuaW1wb3J0IGdsb2JhbGl6ZSBmcm9tIFwiLi4vLi4vZ2xvYmFsaXplLmpzXCI7XHJcbmltcG9ydCBicmVhZGNydW1iZSBmcm9tIFwiLi9icmVhZGNydW1iZS5odG1sXCI7XHJcblxyXG4vKiog5YWo5bGA5Y+Y6YeP5ZKM57yT5a2Y77yabGF5dWnnvJPlrZggKi9cclxubWFpbi52YWx1ZXMubGF5dWkgPSB7XHJcbiAgICAvKiog5o2V5o2J5qCH6K6wICovXHJcbiAgICBjYXRjaGVkOiBmYWxzZSxcclxuICAgIHRhYmxlOiB7fVxyXG59O1xyXG5cclxuLyoqIGxheXVp5o+Q5YmN5o2V5o2JICovXHJcbm1haW4ubGF5dWlDYXRjaCA9IGZ1bmN0aW9uICgpIHtcclxuICAgIGlmICghbWFpbi52YWx1ZXMubGF5dWkuY2F0Y2hlZCAmJiB0eXBlb2YgbGF5dWkgPT09ICdvYmplY3QnKSB7XHJcbiAgICAgICAgY29uZmlnLmxheXVpLmF1dG9SZXBsYWNlID0gY29uZmlnLmxheXVpLmF1dG9SZXBsYWNlICYmIGNvbmZpZy5sYXl1aS5hbGw7XHJcbiAgICAgICAgaWYgKGNvbmZpZy5sYXl1aS5hdXRvUmVwbGFjZSkge1xyXG4gICAgICAgICAgICBtYWluLmxheXVpLnJlcGxhY2UoKTtcclxuICAgICAgICB9XHJcbiAgICAgICAgY29uZmlnLmxheXVpLmFsbCA9IGxheXVpW1wibGF5dWkuYWxsXCJdID8gdHJ1ZSA6IGZhbHNlO1xyXG4gICAgICAgIGZvciAobGV0IGtleSBpbiBsYXl1aSkge1xyXG4gICAgICAgICAgICBpZiAobWFpbi5sYXl1aVtrZXldID09IG51bGwpIG1haW4ubGF5dWlba2V5XSA9IGxheXVpW2tleV07XHJcbiAgICAgICAgICAgIGVsc2UgbWFpbi5sYXl1aVtrZXldID0gbGF5dWlba2V5XTtcclxuICAgICAgICB9XHJcbiAgICAgICAgbWFpbi52YWx1ZXMubGF5dWkuY2F0Y2hlZCA9IHRydWU7XHJcbiAgICB9XHJcbn07XHJcblxyXG5tYWluLm1zZyA9IG1zZztcclxuXHJcbm1haW4uc3R5bGUgPSBzdHlsZTtcclxuXHJcbi8qKiBsYXl1aeWKoOW8uueJiCAqL1xyXG5tYWluLmxheXVpID0ge1xyXG5cclxuICAgIGJyZWFkY3J1bWJlZml4OiBmdW5jdGlvbiAobWVudU5hbWVRdWVyeSwgc3ViTWVudU5hbWVRdWVyeSkge1xyXG4gICAgICAgIGlmIChsYXl1aSAmJiBsYXl1aS5lbGVtZW50KSBiY2ZpeCgpO1xyXG4gICAgICAgIGVsc2UgJChkb2N1bWVudCkucmVhZHkoZnVuY3Rpb24gKCkgeyBiY2ZpeCgpOyB9KTtcclxuICAgIH0sXHJcblxyXG4gICAgcmVwbGFjZTogZnVuY3Rpb24gKCkge1xyXG4gICAgICAgIG1haW4ubGF5dWkuZm4ucmVwbGFjZUxheXVpKCk7XHJcbiAgICB9LFxyXG5cclxuICAgIHRhYmxlOiB7XHJcbiAgICAgICAgbGltaXQ6IGZ1bmN0aW9uIChsYXlJRCkge1xyXG4gICAgICAgICAgICByZXR1cm4gJChcImRpdltsYXktaWQ9J1wiICsgbGF5SUQgKyBcIiddIC5sYXl1aS1sYXlwYWdlLWxpbWl0c1wiKS5maW5kKFwib3B0aW9uOnNlbGVjdGVkXCIpLnZhbCgpO1xyXG4gICAgICAgIH0sXHJcbiAgICAgICAgcmVuZGVyOiBmdW5jdGlvbiAoaW5wdXQpIHtcclxuICAgICAgICAgICAgLyrlpI3lhplsYXl1aeihqOagvOWPmOmHjyovXHJcbiAgICAgICAgICAgIC8qMS7lj5jph4/liJ3lp4vljJYqL1xyXG4gICAgICAgICAgICB2YXIgZG9uZWNhbGxiYWNrID0gaW5wdXQuZG9uZTtcclxuICAgICAgICAgICAgaW5wdXQuZ2xvYmFsaXplID0gaW5wdXQuZ2xvYmFsaXplIHx8IGNvbmZpZy5nbG9iYWxpemUuYWN0aXZlO1xyXG4gICAgICAgICAgICBpbnB1dC5maWx0ZXIgPSBpbnB1dC5maWx0ZXIgfHwgJChpbnB1dC5lbGVtKS5hdHRyKFwibGF5LWZpbHRlclwiKTtcclxuICAgICAgICAgICAgaW5wdXQuaWQgPSBpbnB1dC5pZCB8fCAkKGlucHV0LmVsZW0pLmF0dHIoXCJpZFwiKTtcclxuICAgICAgICAgICAgaW5wdXQudmFsdWUgPSBpbnB1dC52YWx1ZSB8fCBnbG9iYWxpemUudmFsdWVzLmx2W2lucHV0LmlkXTtcclxuICAgICAgICAgICAgbWFpbi52YWx1ZXMubGF5dWkudGFibGVbaW5wdXQuaWRdID0gbWFpbi52YWx1ZXMubGF5dWkudGFibGVbaW5wdXQuaWRdIHx8IHsgcGFnZTogeyBjdXJyOiAwIH0gfVxyXG4gICAgICAgICAgICAvKjIu6K6+5a6a5b2T5YmN6aG15Yid5aeL5pWw5o2u77yM5q+P6aG15pi+56S65pWw6YeP5L+d5oyB5LiN5Y+Y5bm25LiU6YG/5YWN5pyr6aG15peg5pWw5o2uKi9cclxuICAgICAgICAgICAgaWYgKHR5cGVvZiBpbnB1dC5wYWdlID09PSAnb2JqZWN0Jykge1xyXG4gICAgICAgICAgICAgICAgaWYgKG1haW4udmFsdWVzLmxheXVpLnRhYmxlW2lucHV0LmlkXS5wYWdlLmN1cnIpIGlucHV0LnBhZ2UuY3VyciA9IG1haW4udmFsdWVzLmxheXVpLnRhYmxlW2lucHV0LmlkXS5wYWdlLmN1cnI7XHJcbiAgICAgICAgICAgICAgICBlbHNlIG1haW4udmFsdWVzLmxheXVpLnRhYmxlW2lucHV0LmlkXS5wYWdlLmN1cnIgPSBpbnB1dC5wYWdlLmN1cnIgfHwgMTtcclxuICAgICAgICAgICAgICAgIGlucHV0LnBhZ2UubGltaXQgPSAkKFwiZGl2W2xheS1pZD0nXCIgKyBpbnB1dC5maWx0ZXIgKyBcIiddIC5sYXl1aS1sYXlwYWdlLWxpbWl0c1wiKS5maW5kKFwib3B0aW9uOnNlbGVjdGVkXCIpLnZhbCgpIHx8IGlucHV0LnBhZ2UubGltaXQ7XHJcbiAgICAgICAgICAgICAgICB2YXIgZnlhbGwgPSBNYXRoLmNlaWwoaW5wdXQuZGF0YS5sZW5ndGggLyBpbnB1dC5wYWdlLmxpbWl0KTtcclxuICAgICAgICAgICAgICAgIGlmIChmeWFsbCA8IGlucHV0LnBhZ2UuY3VycikgaW5wdXQucGFnZS5jdXJyID0gTnVtYmVyKGZ5YWxsKTtcclxuICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICAvKjMu5qCH6aKY5qCP5aSa6K+t6KiAKi9cclxuICAgICAgICAgICAgaWYgKGlucHV0Lmdsb2JhbGl6ZSkgaW5wdXQuY29scyA9IG1haW4ubGF5dWkuZm4uZ2xvYmFsaXplQ29scyhpbnB1dC5jb2xzLCBpbnB1dC52YWx1ZSk7XHJcbiAgICAgICAgICAgIC8qNC7lrr3luqborr7nva7vvIjlnKjmnKrorr7nva7lrr3luqbmg4XlhrXkuIvvvIzmoIfpopjmoI/lrr3luqbpgILlupTmoIfpopjplb/luqbvvJvlnKjmnKrorr7nva7lr7npvZDmlrnlvI/mg4XlhrXkuIvvvIzpu5jorqTlsYXkuK3vvIkqL1xyXG4gICAgICAgICAgICBpZiAoaW5wdXQuY29scyAmJiBpbnB1dC5jb2xzLmxlbmd0aCkgbWFpbi5sYXl1aS5mbi53aWR0aENvbHMoaW5wdXQuY29scywgaW5wdXQuZWxlbSk7XHJcbiAgICAgICAgICAgIC8qNS7ooajmoLzmuLLmn5PlrozmiJDlkI7nmoTliqjkvZwqL1xyXG4gICAgICAgICAgICBpbnB1dC5kb25lID0gZnVuY3Rpb24gKHJlcywgY3VyciwgY291bnQpIHtcclxuICAgICAgICAgICAgICAgIC8qNS4x5bqV6YOo6aG156CB5aSa6K+t6KiAKi9cclxuICAgICAgICAgICAgICAgIGlmIChpbnB1dC5nbG9iYWxpemUgJiYgaW5wdXQucGFnZSkgbWFpbi5sYXl1aS5mbi5nbG9iYWxpemVQYWdlKGlucHV0LmZpbHRlcik7XHJcbiAgICAgICAgICAgICAgICAvKjUuMuWAn+WKqeWFqOWxgOWPmOmHj+S/neaMgeW9k+WJjemhtSovXHJcbiAgICAgICAgICAgICAgICBpZiAodHlwZW9mIGlucHV0LnBhZ2UgPT09ICdvYmplY3QnKSBtYWluLnZhbHVlcy5sYXl1aS50YWJsZVtpbnB1dC5pZF0ucGFnZS5jdXJyID0gY3VycjtcclxuICAgICAgICAgICAgICAgIC8qNS4z5omn6KGM5aSW6YOo5Lyg5p2l55qEZG9uZSovXHJcbiAgICAgICAgICAgICAgICBpZiAoZG9uZWNhbGxiYWNrICE9PSB1bmRlZmluZWQpIGRvbmVjYWxsYmFjayhyZXMsIGN1cnIsIGNvdW50KTtcclxuICAgICAgICAgICAgfTtcclxuICAgICAgICAgICAgLyrliqDovb1sYXl1aeihqOagvCovXHJcbiAgICAgICAgICAgIGlmIChtYWluLmxheXVpLmZvcm1lci5tb2R1bGUuaW5kZXhPZihcInRhYmxlXCIpICE9IC0xKSBtYWluLmxheXVpLmZvcm1lci50YWJsZS5yZW5kZXIoaW5wdXQpO1xyXG4gICAgICAgICAgICBlbHNlIGxheXVpLnRhYmxlLnJlbmRlcihpbnB1dCk7XHJcbiAgICAgICAgfVxyXG4gICAgfSxcclxuXHJcbiAgICBsYXlkYXRlOiB7XHJcbiAgICAgICAgcmVuZGVyOiBmdW5jdGlvbiAoaW5wdXQpIHtcclxuICAgICAgICAgICAgLyrlpI3lhplsYXl1aeaXpeacn+WPmOmHjyovXHJcbiAgICAgICAgICAgIGlmIChjb25maWcuZ2xvYmFsaXplLmN1bHR1cmUuc3BsaXQoLy18Xy8pWzBdICE9IFwiemhcIiAmJiBjb25maWcuZ2xvYmFsaXplLmFjdGl2ZSkgaW5wdXQubGFuZyA9ICdlbic7XHJcbiAgICAgICAgICAgIC8q5Yqg6L29bGF5dWnml6XmnJ8qL1xyXG4gICAgICAgICAgICBpZiAobWFpbi5sYXl1aS5mb3JtZXIubW9kdWxlLmluZGV4T2YoXCJsYXlkYXRlXCIpICE9IC0xKSBtYWluLmxheXVpLmZvcm1lci5sYXlkYXRlLnJlbmRlcihpbnB1dCk7XHJcbiAgICAgICAgICAgIGVsc2UgbGF5dWkubGF5ZGF0ZS5yZW5kZXIoaW5wdXQpO1xyXG4gICAgICAgIH1cclxuICAgIH0sXHJcblxyXG4gICAgbGF5ZXI6IHtcclxuICAgICAgICAvKipcclxuICAgICAgICAgKiDorr7nva7nm5HlkKzvvJrpvKDmoIfnp7vlhaXmmL7npLp0aXBz77yM56e75Ye65YWz6ZetdGlwc1xyXG4gICAgICAgICAqIEBwYXJhbSB7U3RyaW5nfSBlbGVtIOmAieaLqeWZqFxyXG4gICAgICAgICAqIEBwYXJhbSB7U3RyaW5nfSB3b3JkcyDmmL7npLrnmoTlhoXlrrlcclxuICAgICAgICAgKiBAcGFyYW0ge0Jvb2xlYW59IGJvb2wg6byg5qCH56e75YWl5pe25piv5ZCm5pi+56S65YaF5a6577yIdHJ1ZeS4uuaYvuekuu+8jOm7mOiupOS4unRydWXvvIlcclxuICAgICAgICAgKiBAcGFyYW0ge051bWJlcn0gZGlyIOaYvuekuuWGheWuueeahOaWueWQke+8iDDkuLrlt6bvvIwx5Li65LiK77yMMuS4uuWPs++8jDPkuLrkuIvvvIzpu5jorqTmmL7npLrlnKjlj7PovrnvvIlcclxuICAgICAgICAgKi9cclxuICAgICAgICBob3ZlcjogZnVuY3Rpb24gKGVsZW0sIHdvcmRzLCBib29sLCBkaXIpIHtcclxuICAgICAgICAgICAgaWYgKHR5cGVvZiBib29sICE9PSAnZnVuY3Rpb24nKSBib29sID0gZnVuY3Rpb24gKCkgeyByZXR1cm4gdHJ1ZTsgfTtcclxuICAgICAgICAgICAgZGlyID0gZGlyIHx8IDI7XHJcbiAgICAgICAgICAgIHZhciB0aXBfaW5kZXggPSAwO1xyXG4gICAgICAgICAgICAkKGVsZW0pLm1vdXNlZW50ZXIoZnVuY3Rpb24gKCkge1xyXG4gICAgICAgICAgICAgICAgaWYgKGJvb2woKSkgdGlwX2luZGV4ID0gbGF5dWkubGF5ZXIudGlwcyh3b3JkcywgZWxlbSwgeyB0aXBzOiBbZGlyLCAnIzAwOTY4OCddLCB0aW1lOiAwIH0pO1xyXG4gICAgICAgICAgICB9KS5tb3VzZWxlYXZlKGZ1bmN0aW9uICgpIHtcclxuICAgICAgICAgICAgICAgIGxheXVpLmxheWVyLmNsb3NlKHRpcF9pbmRleCk7XHJcbiAgICAgICAgICAgIH0pO1xyXG4gICAgICAgIH0sXHJcbiAgICAgICAgY29uZmlybTogZnVuY3Rpb24gKGNvbnRlbnQsIG9wdGlvbnMsIHllcywgY2FuY2VsKSB7XHJcbiAgICAgICAgICAgIC8q5aSN5YaZbGF5dWkuY29uZmlybeWPmOmHjyovXHJcbiAgICAgICAgICAgIGlmIChjb25maWcuZ2xvYmFsaXplLmFjdGl2ZSkge1xyXG4gICAgICAgICAgICAgICAgc3dpdGNoIChhcmd1bWVudHMubGVuZ3RoKSB7XHJcbiAgICAgICAgICAgICAgICAgICAgY2FzZSAwOlxyXG4gICAgICAgICAgICAgICAgICAgIGNhc2UgMTpcclxuICAgICAgICAgICAgICAgICAgICAgICAgb3B0aW9ucyA9IHtcclxuICAgICAgICAgICAgICAgICAgICAgICAgICAgIHRpdGxlOiBnbG9iYWxpemUudmFsdWVzLmNvbW1vbi5sYXl1aV90aXRsZV9pbmZvcixcclxuICAgICAgICAgICAgICAgICAgICAgICAgICAgIGJ0bjogW2dsb2JhbGl6ZS52YWx1ZXMuY29tbW9uLmxheXVpX2J0bl9jb25maXJtLCBnbG9iYWxpemUudmFsdWVzLmNvbW1vbi5sYXl1aV9idG5fY2FuY2VsXVxyXG4gICAgICAgICAgICAgICAgICAgICAgICB9XHJcbiAgICAgICAgICAgICAgICAgICAgICAgIGJyZWFrO1xyXG4gICAgICAgICAgICAgICAgICAgIGRlZmF1bHQ6XHJcbiAgICAgICAgICAgICAgICAgICAgICAgIGlmICh0eXBlb2Ygb3B0aW9ucyA9PT0gXCJmdW5jdGlvblwiKSB7XHJcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICBjYW5jZWwgPSB5ZXM7XHJcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICB5ZXMgPSBvcHRpb25zO1xyXG4gICAgICAgICAgICAgICAgICAgICAgICAgICAgb3B0aW9ucyA9IHtcclxuICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICB0aXRsZTogZ2xvYmFsaXplLnZhbHVlcy5jb21tb24ubGF5dWlfdGl0bGVfaW5mb3IsXHJcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgYnRuOiBbZ2xvYmFsaXplLnZhbHVlcy5jb21tb24ubGF5dWlfYnRuX2NvbmZpcm0sIGdsb2JhbGl6ZS52YWx1ZXMuY29tbW9uLmxheXVpX2J0bl9jYW5jZWxdXHJcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICB9XHJcbiAgICAgICAgICAgICAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgICAgICAgICAgICAgZWxzZSB7XHJcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICBpZiAob3B0aW9ucy50aXRsZSA9PT0gdW5kZWZpbmVkKSBvcHRpb25zLnRpdGxlID0gZ2xvYmFsaXplLnZhbHVlcy5jb21tb24ubGF5dWlfdGl0bGVfaW5mb3I7XHJcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICBpZiAob3B0aW9ucy5idG4gPT09IHVuZGVmaW5lZCkgb3B0aW9ucy5idG4gPSBbZ2xvYmFsaXplLnZhbHVlcy5jb21tb24ubGF5dWlfYnRuX2NvbmZpcm0sIGdsb2JhbGl6ZS52YWx1ZXMuY29tbW9uLmxheXVpX2J0bl9jYW5jZWxdO1xyXG4gICAgICAgICAgICAgICAgICAgICAgICB9XHJcbiAgICAgICAgICAgICAgICAgICAgICAgIGJyZWFrO1xyXG4gICAgICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgICAgIC8q5Yqg6L29bGF5dWkuY29uZmlybSovXHJcbiAgICAgICAgICAgIGlmIChtYWluLmxheXVpLmZvcm1lci5tb2R1bGUuaW5kZXhPZihcImxheWVyXCIpICE9IC0xKSBtYWluLmxheXVpLmZvcm1lci5sYXllci5jb25maXJtKGNvbnRlbnQsIG9wdGlvbnMsIHllcywgY2FuY2VsKTtcclxuICAgICAgICAgICAgZWxzZSBsYXl1aS5sYXllci5jb25maXJtKGNvbnRlbnQsIG9wdGlvbnMsIHllcywgY2FuY2VsKTtcclxuICAgICAgICB9LFxyXG4gICAgICAgIGFsZXJ0OiBmdW5jdGlvbiAoY29udGVudCwgb3B0aW9ucywgeWVzKSB7XHJcbiAgICAgICAgICAgIC8q5aSN5YaZbGF5dWkuYWxlcnTlj5jph48qL1xyXG4gICAgICAgICAgICBpZiAoY29uZmlnLmdsb2JhbGl6ZS5hY3RpdmUpIHtcclxuICAgICAgICAgICAgICAgIHN3aXRjaCAoYXJndW1lbnRzLmxlbmd0aCkge1xyXG4gICAgICAgICAgICAgICAgICAgIGNhc2UgMDpcclxuICAgICAgICAgICAgICAgICAgICBjYXNlIDE6XHJcbiAgICAgICAgICAgICAgICAgICAgICAgIG9wdGlvbnMgPSB7XHJcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICB0aXRsZTogZ2xvYmFsaXplLnZhbHVlcy5jb21tb24ubGF5dWlfdGl0bGVfaW5mb3IsXHJcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICBidG46IFtnbG9iYWxpemUudmFsdWVzLmNvbW1vbi5sYXl1aV9idG5fY29uZmlybV1cclxuICAgICAgICAgICAgICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICAgICAgICAgICAgICBicmVhaztcclxuICAgICAgICAgICAgICAgICAgICBkZWZhdWx0OlxyXG4gICAgICAgICAgICAgICAgICAgICAgICBpZiAodHlwZW9mIG9wdGlvbnMgPT09IFwiZnVuY3Rpb25cIikge1xyXG4gICAgICAgICAgICAgICAgICAgICAgICAgICAgeWVzID0gb3B0aW9ucztcclxuICAgICAgICAgICAgICAgICAgICAgICAgICAgIG9wdGlvbnMgPSB7XHJcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgdGl0bGU6IGdsb2JhbGl6ZS52YWx1ZXMuY29tbW9uLmxheXVpX3RpdGxlX2luZm9yLFxyXG4gICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIGJ0bjogW2dsb2JhbGl6ZS52YWx1ZXMuY29tbW9uLmxheXVpX2J0bl9jb25maXJtXVxyXG4gICAgICAgICAgICAgICAgICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICAgICAgICAgICAgICB9XHJcbiAgICAgICAgICAgICAgICAgICAgICAgIGVsc2Uge1xyXG4gICAgICAgICAgICAgICAgICAgICAgICAgICAgaWYgKG9wdGlvbnMudGl0bGUgPT09IHVuZGVmaW5lZCkgb3B0aW9ucy50aXRsZSA9IGdsb2JhbGl6ZS52YWx1ZXMuY29tbW9uLmxheXVpX3RpdGxlX2luZm9yO1xyXG4gICAgICAgICAgICAgICAgICAgICAgICAgICAgaWYgKG9wdGlvbnMuYnRuID09PSB1bmRlZmluZWQpIG9wdGlvbnMuYnRuID0gW2dsb2JhbGl6ZS52YWx1ZXMuY29tbW9uLmxheXVpX2J0bl9jb25maXJtXTtcclxuICAgICAgICAgICAgICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICAgICAgICAgICAgICBicmVhaztcclxuICAgICAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICAvKuWKoOi9vWxheXVpLmFsZXJ0Ki9cclxuICAgICAgICAgICAgaWYgKG1haW4ubGF5dWkuZm9ybWVyLm1vZHVsZS5pbmRleE9mKFwibGF5ZXJcIikgIT0gLTEpIG1haW4ubGF5dWkuZm9ybWVyLmxheWVyLmFsZXJ0KGNvbnRlbnQsIG9wdGlvbnMsIHllcyk7XHJcbiAgICAgICAgICAgIGVsc2UgbGF5dWkubGF5ZXIuYWxlcnQoY29udGVudCwgb3B0aW9ucywgeWVzKTtcclxuICAgICAgICB9XHJcbiAgICB9LFxyXG5cclxuICAgIGZvcm1lcjoge1xyXG4gICAgICAgIG1vZHVsZTogW10sXHJcbiAgICAgICAgdGFibGU6IHtcclxuICAgICAgICAgICAgcmVuZGVyOiB7fVxyXG4gICAgICAgIH0sXHJcbiAgICAgICAgbGF5ZGF0ZToge1xyXG4gICAgICAgICAgICByZW5kZXI6IHt9XHJcbiAgICAgICAgfSxcclxuICAgICAgICBsYXllcjoge1xyXG4gICAgICAgICAgICBjb25maXJtOiB7fSxcclxuICAgICAgICAgICAgYWxlcnQ6IHt9XHJcbiAgICAgICAgfVxyXG4gICAgfSxcclxuXHJcbiAgICAvKirlhoXpg6jmk43kvZzvvIjor7fli7/lnKjlpJbpg6jmk43kvZzvvIkgKi9cclxuICAgIGZuOiB7XHJcbiAgICAgICAgcmVwbGFjZUxheXVpOiBmdW5jdGlvbiAoKSB7XHJcbiAgICAgICAgICAgIC8qdGFibGXmm7/mjaIqL1xyXG4gICAgICAgICAgICBpZiAobGF5dWkudGFibGUgJiYgbWFpbi5sYXl1aS5mb3JtZXIubW9kdWxlLmluZGV4T2YoXCJ0YWJsZVwiKSA9PSAtMSkge1xyXG4gICAgICAgICAgICAgICAgbWFpbi5sYXl1aS5mb3JtZXIudGFibGUucmVuZGVyID0gbGF5dWkudGFibGUucmVuZGVyO1xyXG4gICAgICAgICAgICAgICAgbGF5dWkudGFibGUucmVuZGVyID0gbWFpbi5sYXl1aS50YWJsZS5yZW5kZXI7XHJcbiAgICAgICAgICAgICAgICBtYWluLmxheXVpLmZvcm1lci5tb2R1bGUucHVzaChcInRhYmxlXCIpO1xyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgICAgIC8qbGF5ZGF0Zeabv+aNoiovXHJcbiAgICAgICAgICAgIGlmIChsYXl1aS5sYXlkYXRlICYmIG1haW4ubGF5dWkuZm9ybWVyLm1vZHVsZS5pbmRleE9mKFwibGF5ZGF0ZVwiKSA9PSAtMSkge1xyXG4gICAgICAgICAgICAgICAgbWFpbi5sYXl1aS5mb3JtZXIubGF5ZGF0ZS5yZW5kZXIgPSBsYXl1aS5sYXlkYXRlLnJlbmRlcjtcclxuICAgICAgICAgICAgICAgIGxheXVpLmxheWRhdGUucmVuZGVyID0gbWFpbi5sYXl1aS5sYXlkYXRlLnJlbmRlcjtcclxuICAgICAgICAgICAgICAgIG1haW4ubGF5dWkuZm9ybWVyLm1vZHVsZS5wdXNoKFwibGF5ZGF0ZVwiKTtcclxuICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICAvKmxheWVy5pu/5o2iKi9cclxuICAgICAgICAgICAgaWYgKGxheXVpLmxheWVyICYmIG1haW4ubGF5dWkuZm9ybWVyLm1vZHVsZS5pbmRleE9mKFwibGF5ZXJcIikgPT0gLTEpIHtcclxuICAgICAgICAgICAgICAgIG1haW4ubGF5dWkuZm9ybWVyLmxheWVyLmNvbmZpcm0gPSBsYXl1aS5sYXllci5jb25maXJtO1xyXG4gICAgICAgICAgICAgICAgbGF5dWkubGF5ZXIuY29uZmlybSA9IG1haW4ubGF5dWkubGF5ZXIuY29uZmlybTtcclxuICAgICAgICAgICAgICAgIG1haW4ubGF5dWkuZm9ybWVyLmxheWVyLmFsZXJ0ID0gbGF5dWkubGF5ZXIuYWxlcnQ7XHJcbiAgICAgICAgICAgICAgICBsYXl1aS5sYXllci5hbGVydCA9IG1haW4ubGF5dWkubGF5ZXIuYWxlcnQ7XHJcbiAgICAgICAgICAgICAgICBtYWluLmxheXVpLmZvcm1lci5tb2R1bGUucHVzaChcImxheWVyXCIpO1xyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgfSxcclxuICAgICAgICBnbG9iYWxpemVQYWdlOiBmdW5jdGlvbiAoaWROYW1lKSB7XHJcbiAgICAgICAgICAgIHZhciBhID0gJChcImRpdltsYXktaWQ9J1wiICsgaWROYW1lICsgXCInXSAubGF5dWktdGFibGUtcGFnZSAubGF5dWktbGF5cGFnZS1jb3VudFwiKS5odG1sKCkgfHwgXCJcIjtcclxuICAgICAgICAgICAgaWYgKGEgIT0gXCJcIikge1xyXG4gICAgICAgICAgICAgICAgYSA9IGEucmVwbGFjZSgv5YWxL2csIGdsb2JhbGl6ZS52YWx1ZXMuY29tbW9uLmxheXVpX0dvbmcpLnJlcGxhY2UoL+adoS9nLCBnbG9iYWxpemUudmFsdWVzLmNvbW1vbi5sYXl1aV9UaWFvKTtcclxuICAgICAgICAgICAgICAgICQoXCJkaXZbbGF5LWlkPSdcIiArIGlkTmFtZSArIFwiJ10gLmxheXVpLXRhYmxlLXBhZ2UgLmxheXVpLWxheXBhZ2UtY291bnRcIikuaHRtbChhKTtcclxuXHJcbiAgICAgICAgICAgICAgICBhID0gJChcImRpdltsYXktaWQ9J1wiICsgaWROYW1lICsgXCInXSAubGF5dWktdGFibGUtcGFnZSAubGF5dWktbGF5cGFnZS1idG5cIikuaHRtbCgpO1xyXG4gICAgICAgICAgICAgICAgYSA9IGEucmVwbGFjZSgv56Gu5a6aL2csIGdsb2JhbGl6ZS52YWx1ZXMuY29tbW9uLmxheXVpX1F1ZURpbmcpO1xyXG4gICAgICAgICAgICAgICAgJChcImRpdltsYXktaWQ9J1wiICsgaWROYW1lICsgXCInXSAubGF5dWktdGFibGUtcGFnZSAubGF5dWktbGF5cGFnZS1idG5cIikuaHRtbChhKTtcclxuXHJcbiAgICAgICAgICAgICAgICAkKFwiZGl2W2xheS1pZD0nXCIgKyBpZE5hbWUgKyBcIiddIC5sYXl1aS10YWJsZS1wYWdlIC5sYXl1aS1sYXlwYWdlLXNraXBcIilbMF0uY2hpbGROb2Rlc1swXS5ub2RlVmFsdWUgPSBnbG9iYWxpemUudmFsdWVzLmNvbW1vbi5sYXl1aV9EYW9EaTtcclxuICAgICAgICAgICAgICAgICQoXCJkaXZbbGF5LWlkPSdcIiArIGlkTmFtZSArIFwiJ10gLmxheXVpLXRhYmxlLXBhZ2UgLmxheXVpLWxheXBhZ2Utc2tpcFwiKVswXS5jaGlsZE5vZGVzWzJdLm5vZGVWYWx1ZSA9IGdsb2JhbGl6ZS52YWx1ZXMuY29tbW9uLmxheXVpX1llO1xyXG5cclxuICAgICAgICAgICAgICAgICQoXCJkaXZbbGF5LWlkPSdcIiArIGlkTmFtZSArIFwiJ10gLmxheXVpLXRhYmxlLXBhZ2UgLmxheXVpLWxheXBhZ2UtbGltaXRzIHNlbGVjdCBvcHRpb25cIikuZWFjaChmdW5jdGlvbiAoKSB7XHJcbiAgICAgICAgICAgICAgICAgICAgJCh0aGlzKS5odG1sKCQodGhpcykuaHRtbCgpLnJlcGxhY2UoL+adoS9nLCBnbG9iYWxpemUudmFsdWVzLmNvbW1vbi5sYXl1aV9UaWFvKS5yZXBsYWNlKC/pobUvZywgZ2xvYmFsaXplLnZhbHVlcy5jb21tb24ubGF5dWlfWWUpKTtcclxuICAgICAgICAgICAgICAgIH0pO1xyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgfSxcclxuICAgICAgICBnbG9iYWxpemVDb2xzOiBmdW5jdGlvbiAoY29scywgdmFsdWUpIHtcclxuICAgICAgICAgICAgY29scyA9IGNvbHMgfHwgW1tdXTtcclxuICAgICAgICAgICAgdmFsdWUgPSB2YWx1ZSB8fCBcIlwiO1xyXG4gICAgICAgICAgICBmb3IgKHZhciBpID0gMDsgaSA8IGNvbHMubGVuZ3RoOyBpKyspIHtcclxuICAgICAgICAgICAgICAgIGZvciAodmFyIGogPSAwOyBqIDwgY29sc1tpXS5sZW5ndGg7IGorKykge1xyXG4gICAgICAgICAgICAgICAgICAgIHZhciBmaWVsZCA9IGNvbHNbaV1bal0uZmllbGQgfHwgXCJcIlxyXG4gICAgICAgICAgICAgICAgICAgIGlmIChjb2xzW2ldW2pdLnRpdGxlID09PSB1bmRlZmluZWQgJiYgdmFsdWVbZmllbGRdKSB7XHJcbiAgICAgICAgICAgICAgICAgICAgICAgIGNvbHNbaV1bal0udGl0bGUgPSB2YWx1ZVtmaWVsZF07XHJcbiAgICAgICAgICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgICAgIHJldHVybiBjb2xzXHJcbiAgICAgICAgfSxcclxuICAgICAgICB3aWR0aENvbHM6IGZ1bmN0aW9uIChjb2xzLCBlbGVtKSB7XHJcbiAgICAgICAgICAgIHZhciBsYXN0Um93ID0gY29scy5sZW5ndGggLSAxO1xyXG4gICAgICAgICAgICBmb3IgKHZhciBpID0gMDsgaSA8IGNvbHNbbGFzdFJvd10ubGVuZ3RoOyBpKyspIHtcclxuICAgICAgICAgICAgICAgIGlmIChjb2xzW2xhc3RSb3ddW2ldLndpZHRoID09PSB1bmRlZmluZWQgJiYgY29sc1tsYXN0Um93XVtpXS5taW5XaWR0aCA9PT0gdW5kZWZpbmVkKSB7XHJcbiAgICAgICAgICAgICAgICAgICAgdmFyIG1vcmVXaWR0aCA9IDA7XHJcbiAgICAgICAgICAgICAgICAgICAgaWYgKGNvbHNbbGFzdFJvd11baV0uc29ydCkgbW9yZVdpZHRoID0gMjA7XHJcbiAgICAgICAgICAgICAgICAgICAgJChlbGVtKS5hZnRlcignPHNwYW4gaWQgPSBcImFzc2lzdFdpZHRoTWVhc3VyZVwiIHN0eWxlID0gXCJmb250LXNpemU6IDE0cHg7XCI+JyArIGNvbHNbbGFzdFJvd11baV0udGl0bGUgKyAnPC9zcGFuPicpO1xyXG4gICAgICAgICAgICAgICAgICAgIGNvbHNbbGFzdFJvd11baV0ud2lkdGggPSAkKFwiI2Fzc2lzdFdpZHRoTWVhc3VyZVwiKS53aWR0aCgpICsgMzEgKyBtb3JlV2lkdGg7XHJcbiAgICAgICAgICAgICAgICAgICAgJChcIiNhc3Npc3RXaWR0aE1lYXN1cmVcIikucmVtb3ZlKCk7XHJcbiAgICAgICAgICAgICAgICB9XHJcbiAgICAgICAgICAgICAgICBjb2xzW2xhc3RSb3ddW2ldLmFsaWduID0gY29sc1tsYXN0Um93XVtpXS5hbGlnbiB8fCAnY2VudGVyJztcclxuICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICByZXR1cm4gY29sc1xyXG4gICAgICAgIH1cclxuICAgIH1cclxuXHJcbn07XHJcblxyXG5mdW5jdGlvbiBiY2ZpeChtZW51TmFtZVF1ZXJ5LCBzdWJNZW51TmFtZVF1ZXJ5KSB7XHJcbiAgICB2YXIgbWVudU5hbWUgPSAnJztcclxuICAgIHZhciBzdWJNZW51TmFtZSA9ICcnO1xyXG4gICAgaWYgKG1lbnVOYW1lUXVlcnkgJiYgJChtZW51TmFtZVF1ZXJ5KS5sZW5ndGggPiAwKSBtZW51TmFtZSA9ICQobWVudU5hbWVRdWVyeSkuZmluZCgnYScpLmVxKDApLnRleHQoKTtcclxuICAgIGlmIChzdWJNZW51TmFtZVF1ZXJ5ICYmICQoc3ViTWVudU5hbWVRdWVyeSkubGVuZ3RoID4gMCkgc3ViTWVudU5hbWUgPSAkKHN1Yk1lbnVOYW1lUXVlcnkpLmZpbmQoJ2EnKS5lcSgwKS50ZXh0KCk7XHJcbiAgICBtZW51TmFtZSA9IG1lbnVOYW1lIHx8ICQoJ2xpLmxheXVpLW5hdi1pdGVtZWQnKS5maW5kKCdhJykuZXEoMCkudGV4dCgpO1xyXG4gICAgc3ViTWVudU5hbWUgPSBzdWJNZW51TmFtZSB8fCAkKCdsaS5sYXl1aS1uYXYtaXRlbWVkID4gZGwgPiBkZC5sYXl1aS10aGlzJykuZmluZCgnYScpLmVxKDApLnRleHQoKTtcclxuICAgIGlmICghbWVudU5hbWUgfHwgIXN1Yk1lbnVOYW1lKSBjb25zb2xlLndhcm4oJ+acquaJvuWIsOWvueW6lOS4u+iPnOWNleaIluWtkOiPnOWNleaWh+Wtl++8jOWwhuaYvuekuuepuuWAvCcpO1xyXG4gICAgdmFyIGJjID0gJChicmVhZGNydW1iZSk7XHJcbiAgICBiYy5maW5kKCdhJykuZXEoMCkudGV4dChtZW51TmFtZSk7XHJcbiAgICBiYy5maW5kKCdhJykuZXEoMSkuZmlyc3QoKS50ZXh0KHN1Yk1lbnVOYW1lKTtcclxuICAgICQoJy5sYXl1aS1icmVhZGNydW1iJylbMF0ub3V0ZXJIVE1MID0gYmNbMF0ub3V0ZXJIVE1MO1xyXG59XHJcblxyXG5mdW5jdGlvbiBzb29uKGZhdGhlcikge1xyXG4gICAgZmF0aGVyLmxheXVpQ2F0Y2goKTtcclxufVxyXG5cclxuZnVuY3Rpb24gYWZ0ZXIoZmF0aGVyKSB7XHJcbiAgICBmYXRoZXIubGF5dWlDYXRjaCgpO1xyXG59XHJcblxyXG5leHBvcnQgeyBsYXl1aSwgc29vbiBhcyBsYXl1aVNvb24sIGFmdGVyIGFzIGxheXVpQWZ0ZXIgfTsiLCJpbXBvcnQgJCBmcm9tIFwianF1ZXJ5XCI7XHJcbmltcG9ydCBtYWluIGZyb20gXCIuLi8uLi9tYWluLmpzXCI7XHJcbmltcG9ydCBnbG9iYWxpemUgZnJvbSBcIi4uLy4uL2dsb2JhbGl6ZS5qc1wiO1xyXG5pbXBvcnQgbGF5dWkgZnJvbSBcImxheXVpXCI7XHJcblxyXG4vKirmtojmga/mk43kvZwgKi9cclxudmFyIG1zZyA9IHtcclxuICAgIC8qKlxyXG4gICAgICog5qCH5YeG5raI5oGvXHJcbiAgICAgKiBAcGFyYW0ge09iamVjdH0gbWVzc2FnZSDmtojmga/lhoXlrrnvvIjlj6/ku6XkuLrmlbDnu4Tku6XlsZXnpLrlpJrmnaHmtojmga/vvIlcclxuICAgICAqIEBwYXJhbSB7U3RyaW5nfSB0eXBlIOa2iOaBr+exu+Wei++8iEnkuLrmma7pgJrmtojmga/vvIxX5Li66K2m5ZGK5raI5oGv77yMReS4uumUmeivr+a2iOaBr++8iVxyXG4gICAgICogQHBhcmFtIHtOdW1iZXJ9IHN0eWxlIOa2iOaBr+mjjuagvO+8iOWBtuaVsOS4uuiHquWKqOa2iOWkse+8jOWlh+aVsOS4uumcgOeCueWHu+ehruiupO+8ie+8mlxyXG4gICAgICog44CQMOOAkeW8ueWHuuiLpeW5suenkuWQjua2iOWkse+8jOOAkDHjgJHlvLnlh7rlkI7pnIDngrnnoa7orqTvvJtcclxuICAgICAqIOOAkDLjgJHlnKgw55qE5Z+656GA5LiK5bCG5raI5oGv5Lul5YiX6KGo5b2i5byP5bGV546w77yM44CQM+OAkeWcqDHnmoTln7rnoYDkuIrlsIbmtojmga/ku6XliJfooajlvaLlvI/lsZXnjrDvvJtcclxuICAgICAqIOOAkDTjgJHlnKgw55qE5Z+656GA5LiK5bCG5raI5oGv5Lul6KGM5b2i5byP5bGV546w77yM44CQNeOAkeWcqDHnmoTln7rnoYDkuIrlsIbmtojmga/ku6XooYzlvaLlvI/lsZXnjrDvvJtcclxuICAgICAqIEBwYXJhbSB7TnVtYmVyfEZ1bmN0aW9ufSBpbnB1dCDlm57osIPlkozml7bpl7TvvJpcclxuICAgICAqIOW9k+S4uuaVsOWtl+aXtuihqOekuueUn+aViOaXtumXtO+8iOWNleS9jeS4uuenku+8jOW9k+a2iOaBr+mjjuagvOS4ujDjgIEy44CBNOaXtueUn+aViO+8jOm7mOiupOS4ujPnp5LvvInvvJtcclxuICAgICAqIOW9k+S4uuaWueazleaXtuihqOekuueCueWHu+Wbnuiwg++8iOW9k+a2iOaBr+mjjuagvOS4ujHjgIEz44CBNeaXtueUn+aViO+8ie+8m1xyXG4gICAgICogQHBhcmFtIHtCb29sZWFufSBjbGVhbiDmmK/lkKbnnIHnlaXmtojmga/lj7dcclxuICAgICAqL1xyXG4gICAgb3BlbjogZnVuY3Rpb24gKG1lc3NhZ2UsIHR5cGUsIHN0eWxlLCBpbnB1dCwgY2xlYW4pIHtcclxuICAgICAgICB2YXIgdGl0bGUgPSBcIlwiO1xyXG4gICAgICAgIHZhciBpY29uID0gMDtcclxuICAgICAgICB2YXIgdGltZSA9IDM7XHJcbiAgICAgICAgdmFyIGNhbGxiYWNrID0gZnVuY3Rpb24gKCkgeyB9O1xyXG4gICAgICAgIHR5cGUgPSB0eXBlIHx8ICdTJztcclxuICAgICAgICBpZiAodHlwZW9mIGlucHV0ID09PSAnbnVtYmVyJykgdGltZSA9IGlucHV0O1xyXG4gICAgICAgIGVsc2UgaWYgKHR5cGVvZiBpbnB1dCA9PT0gJ2Z1bmN0aW9uJykgY2FsbGJhY2sgPSBpbnB1dDtcclxuICAgICAgICBpZiAoY2xlYW4pIG1lc3NhZ2UgPSBjbGVhbk1zZyhtZXNzYWdlLCB0eXBlKTtcclxuICAgICAgICBlbHNlIG1lc3NhZ2UgPSBjaGVja01zZyhtZXNzYWdlLCB0eXBlKTtcclxuICAgICAgICBzd2l0Y2ggKHR5cGUpIHtcclxuICAgICAgICAgICAgY2FzZSBcIkVcIjpcclxuICAgICAgICAgICAgICAgIHN0eWxlID0gdHlwZW9mIHN0eWxlID09PSBcIm51bWJlclwiID8gc3R5bGUgOiA1O1xyXG4gICAgICAgICAgICAgICAgaWNvbiA9IDU7XHJcbiAgICAgICAgICAgICAgICB0aXRsZSA9ICc8aSBjbGFzcz1cImxheXVpLWljb24gbGF5dWktaWNvbi1ub3RpY2VcIiBzdHlsZT1cImZvbnQtc2l6ZToxOHB4OyBjb2xvcjp3aGl0ZTtcIj48L2k+PHNwYW4gc3R5bGU9XCJtYXJnaW4tbGVmdDoxMHB4OyBmb250LXNpemU6MTZweDtcIj4nICsgZ2xvYmFsaXplLnZhbHVlcy5jb21tb24ubGF5dWlfbXNnX0UgKyAnPHNwYW4+J1xyXG4gICAgICAgICAgICAgICAgYnJlYWs7XHJcbiAgICAgICAgICAgIGNhc2UgXCJXXCI6XHJcbiAgICAgICAgICAgICAgICBzdHlsZSA9IHR5cGVvZiBzdHlsZSA9PT0gXCJudW1iZXJcIiA/IHN0eWxlIDogNTtcclxuICAgICAgICAgICAgICAgIGljb24gPSAwO1xyXG4gICAgICAgICAgICAgICAgdGl0bGUgPSAnPGkgY2xhc3M9XCJsYXl1aS1pY29uIGxheXVpLWljb24tbm90aWNlXCIgc3R5bGU9XCJmb250LXNpemU6MThweDsgY29sb3I6d2hpdGU7XCI+PC9pPjxzcGFuIHN0eWxlPVwibWFyZ2luLWxlZnQ6MTBweDsgZm9udC1zaXplOjE2cHg7XCI+JyArIGdsb2JhbGl6ZS52YWx1ZXMuY29tbW9uLmxheXVpX21zZ19XICsgJzxzcGFuPidcclxuICAgICAgICAgICAgICAgIGJyZWFrO1xyXG4gICAgICAgICAgICBjYXNlIFwiSVwiOlxyXG4gICAgICAgICAgICBkZWZhdWx0OlxyXG4gICAgICAgICAgICAgICAgc3R5bGUgPSB0eXBlb2Ygc3R5bGUgPT09IFwibnVtYmVyXCIgPyBzdHlsZSA6IDA7XHJcbiAgICAgICAgICAgICAgICBpY29uID0gNjtcclxuICAgICAgICAgICAgICAgIHRpdGxlID0gJzxpIGNsYXNzPVwibGF5dWktaWNvbiBsYXl1aS1pY29uLW5vdGljZVwiIHN0eWxlPVwiZm9udC1zaXplOjE4cHg7IGNvbG9yOndoaXRlO1wiPjwvaT48c3BhbiBzdHlsZT1cIm1hcmdpbi1sZWZ0OjEwcHg7IGZvbnQtc2l6ZToxNnB4O1wiPicgKyBnbG9iYWxpemUudmFsdWVzLmNvbW1vbi5sYXl1aV9tc2dfUyArICc8c3Bhbj4nXHJcbiAgICAgICAgICAgICAgICBicmVhaztcclxuICAgICAgICB9XHJcbiAgICAgICAgc3dpdGNoIChzdHlsZSkge1xyXG4gICAgICAgICAgICBjYXNlIDA6XHJcbiAgICAgICAgICAgICAgICBsYXl1aS5sYXllci5tc2cobXNnLmZuLmNvbWJpbmUobWVzc2FnZSksIHsgaWNvbjogaWNvbiwgdGltZTogdGltZSAqIDEwMDAgfSk7XHJcbiAgICAgICAgICAgICAgICBicmVhaztcclxuICAgICAgICAgICAgY2FzZSAxOlxyXG4gICAgICAgICAgICAgICAgbWFpbi5sYXl1aS5sYXllci5hbGVydChtc2cuZm4uY29tYmluZShtZXNzYWdlKSwge1xyXG4gICAgICAgICAgICAgICAgICAgIHRpdGxlOiB0aXRsZSxcclxuICAgICAgICAgICAgICAgICAgICBza2luOiAnbGF5dWktbGF5ZXItbW9sdicsXHJcbiAgICAgICAgICAgICAgICAgICAgY2xvc2VCdG46IDBcclxuICAgICAgICAgICAgICAgIH0sIGZ1bmN0aW9uICgpIHtcclxuICAgICAgICAgICAgICAgICAgICBjYWxsYmFjaygpO1xyXG4gICAgICAgICAgICAgICAgfSk7XHJcbiAgICAgICAgICAgICAgICBicmVhaztcclxuICAgICAgICAgICAgY2FzZSAyOlxyXG4gICAgICAgICAgICAgICAgbGF5dWkubGF5ZXIubXNnKFwiPGRpdiBzdHlsZT1cXFwicGFkZGluZzoyMHB4O1xcXCI+PHRhYmxlIGNsYXNzPVxcXCJsYXl1aS1oaWRlXFxcIiBpZD1cXFwic29ubHVrX21zZ19vcGVuMlxcXCIgbGF5LWZpbHRlcj1cXFwic29ubHVrX21zZ19vcGVuMlxcXCI+PC90YWJsZT48L2Rpdj5cIiwgeyBpY29uOiBpY29uLCB0aW1lOiB0aW1lICogMTAwMCwgYXJlYTogJzcwMHB4Jywgb2Zmc2V0OiAnMzAlJyB9KTtcclxuICAgICAgICAgICAgICAgIG1haW4ubGF5dWkudGFibGUucmVuZGVyKHtcclxuICAgICAgICAgICAgICAgICAgICBlbGVtOiAnI3Nvbmx1a19tc2dfb3BlbjInLFxyXG4gICAgICAgICAgICAgICAgICAgIGRhdGE6IG1zZy5mbi5saXN0KG1lc3NhZ2UpLFxyXG4gICAgICAgICAgICAgICAgICAgIGNvbHM6IFtbXHJcbiAgICAgICAgICAgICAgICAgICAgICAgIHsgZmllbGQ6ICdjb2RlJywgdGl0bGU6IGdsb2JhbGl6ZS52YWx1ZXMuY29tbW9uLmxheXVpX21zZ190YWJsZV9jb2RlIH0sXHJcbiAgICAgICAgICAgICAgICAgICAgICAgIHsgZmllbGQ6ICd0eXBlJywgdGl0bGU6IGdsb2JhbGl6ZS52YWx1ZXMuY29tbW9uLmxheXVpX21zZ190YWJsZV90eXBlIH0sXHJcbiAgICAgICAgICAgICAgICAgICAgICAgIHsgZmllbGQ6ICdtZXNzYWdlJywgdGl0bGU6IGdsb2JhbGl6ZS52YWx1ZXMuY29tbW9uLmxheXVpX21zZ190YWJsZV9jb250ZW50LCBtaW5XaWR0aDogMTUwLCBhbGlnbjogXCJsZWZ0XCIgfVxyXG4gICAgICAgICAgICAgICAgICAgIF1dXHJcbiAgICAgICAgICAgICAgICB9KVxyXG4gICAgICAgICAgICAgICAgYnJlYWs7XHJcbiAgICAgICAgICAgIGNhc2UgMzpcclxuICAgICAgICAgICAgICAgIGxheXVpLmxheWVyLm9wZW4oe1xyXG4gICAgICAgICAgICAgICAgICAgIHR5cGU6IDEsXHJcbiAgICAgICAgICAgICAgICAgICAgc2tpbjogJ2xheXVpLWxheWVyLW1vbHYnLFxyXG4gICAgICAgICAgICAgICAgICAgIGNsb3NlQnRuOiAxLFxyXG4gICAgICAgICAgICAgICAgICAgIGFyZWE6IFtcIjcwMHB4XCIsIFwiNDMwcHhcIl0sXHJcbiAgICAgICAgICAgICAgICAgICAgYW5pbTogMCxcclxuICAgICAgICAgICAgICAgICAgICBidG46IFtnbG9iYWxpemUudmFsdWVzLmNvbW1vbi5sYXl1aV9tc2dfYnRuXSxcclxuICAgICAgICAgICAgICAgICAgICB0aXRsZTogdGl0bGUsXHJcbiAgICAgICAgICAgICAgICAgICAgc2hhZGU6IDAuNSxcclxuICAgICAgICAgICAgICAgICAgICBzaGFkZUNsb3NlOiBmYWxzZSxcclxuICAgICAgICAgICAgICAgICAgICBjb250ZW50OiBcIjxkaXYgc3R5bGU9XFxcInBhZGRpbmc6MjBweDtcXFwiPjx0YWJsZSBjbGFzcz1cXFwibGF5dWktaGlkZVxcXCIgaWQ9XFxcInNvbmx1a19tc2dfb3BlbjNcXFwiIGxheS1maWx0ZXI9XFxcInNvbmx1a19tc2dfb3BlbjNcXFwiPjwvdGFibGU+PC9kaXY+XCIsXHJcbiAgICAgICAgICAgICAgICAgICAgeWVzOiBmdW5jdGlvbiAoaW5kZXgsIGxheWVybykge1xyXG4gICAgICAgICAgICAgICAgICAgICAgICBjYWxsYmFjayhpbmRleCwgbGF5ZXJvKTtcclxuICAgICAgICAgICAgICAgICAgICAgICAgbGF5dWkubGF5ZXIuY2xvc2UoaW5kZXgpO1xyXG4gICAgICAgICAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgICAgIH0pO1xyXG4gICAgICAgICAgICAgICAgbWFpbi5sYXl1aS50YWJsZS5yZW5kZXIoe1xyXG4gICAgICAgICAgICAgICAgICAgIGVsZW06ICcjc29ubHVrX21zZ19vcGVuMycsXHJcbiAgICAgICAgICAgICAgICAgICAgZGF0YTogbXNnLmZuLmxpc3QobWVzc2FnZSksXHJcbiAgICAgICAgICAgICAgICAgICAgaGVpZ2h0OiAyNjUsXHJcbiAgICAgICAgICAgICAgICAgICAgY29sczogW1tcclxuICAgICAgICAgICAgICAgICAgICAgICAgeyBmaWVsZDogJ2NvZGUnLCB0aXRsZTogZ2xvYmFsaXplLnZhbHVlcy5jb21tb24ubGF5dWlfbXNnX3RhYmxlX2NvZGUgfSxcclxuICAgICAgICAgICAgICAgICAgICAgICAgeyBmaWVsZDogJ3R5cGUnLCB0aXRsZTogZ2xvYmFsaXplLnZhbHVlcy5jb21tb24ubGF5dWlfbXNnX3RhYmxlX3R5cGUgfSxcclxuICAgICAgICAgICAgICAgICAgICAgICAgeyBmaWVsZDogJ21lc3NhZ2UnLCB0aXRsZTogZ2xvYmFsaXplLnZhbHVlcy5jb21tb24ubGF5dWlfbXNnX3RhYmxlX2NvbnRlbnQsIG1pbldpZHRoOiAxNTAsIGFsaWduOiBcImxlZnRcIiB9XHJcbiAgICAgICAgICAgICAgICAgICAgXV0sXHJcbiAgICAgICAgICAgICAgICAgICAgcGFnZToge1xyXG4gICAgICAgICAgICAgICAgICAgICAgICBjdXJyOiAxLFxyXG4gICAgICAgICAgICAgICAgICAgICAgICBsaW1pdDogNSxcclxuICAgICAgICAgICAgICAgICAgICAgICAgbGltaXRzOiBbNV1cclxuICAgICAgICAgICAgICAgICAgICB9XHJcbiAgICAgICAgICAgICAgICB9KVxyXG4gICAgICAgICAgICAgICAgYnJlYWs7XHJcbiAgICAgICAgICAgIGNhc2UgNDpcclxuICAgICAgICAgICAgICAgIGxheXVpLmxheWVyLm1zZyhtc2cuZm4ubWVyZ2UobWVzc2FnZSwgZmFsc2UpLCB7IHNraW46ICdsYXl1aS1sYXllci1tb2x2JywgdGltZTogdGltZSAqIDEwMDAgfSk7XHJcbiAgICAgICAgICAgICAgICBicmVhaztcclxuICAgICAgICAgICAgY2FzZSA1OlxyXG4gICAgICAgICAgICBkZWZhdWx0OlxyXG4gICAgICAgICAgICAgICAgbGF5dWkubGF5ZXIub3Blbih7XHJcbiAgICAgICAgICAgICAgICAgICAgdHlwZTogMSxcclxuICAgICAgICAgICAgICAgICAgICBza2luOiAnbGF5dWktbGF5ZXItbW9sdicsXHJcbiAgICAgICAgICAgICAgICAgICAgY2xvc2VCdG46IDEsXHJcbiAgICAgICAgICAgICAgICAgICAgYXJlYTogbXNnLmZuLmZpeChtZXNzYWdlKSxcclxuICAgICAgICAgICAgICAgICAgICBhbmltOiAwLFxyXG4gICAgICAgICAgICAgICAgICAgIGJ0bjogW2dsb2JhbGl6ZS52YWx1ZXMuY29tbW9uLmxheXVpX21zZ19idG5dLFxyXG4gICAgICAgICAgICAgICAgICAgIHRpdGxlOiB0aXRsZSxcclxuICAgICAgICAgICAgICAgICAgICBzaGFkZTogMC41LFxyXG4gICAgICAgICAgICAgICAgICAgIHNoYWRlQ2xvc2U6IGZhbHNlLFxyXG4gICAgICAgICAgICAgICAgICAgIGNvbnRlbnQ6IG1zZy5mbi5tZXJnZShtZXNzYWdlKSxcclxuICAgICAgICAgICAgICAgICAgICB5ZXM6IGZ1bmN0aW9uIChpbmRleCwgbGF5ZXJvKSB7XHJcbiAgICAgICAgICAgICAgICAgICAgICAgIGNhbGxiYWNrKGluZGV4LCBsYXllcm8pO1xyXG4gICAgICAgICAgICAgICAgICAgICAgICBsYXl1aS5sYXllci5jbG9zZShpbmRleCk7XHJcbiAgICAgICAgICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICAgICAgfSk7XHJcbiAgICAgICAgICAgICAgICBicmVhaztcclxuICAgICAgICB9XHJcbiAgICB9LFxyXG4gICAgLyoqXHJcbiAgICAgKiDmiJDlip/mtojmga9cclxuICAgICAqIEBwYXJhbSB7T2JqZWN0fSBtZXNzYWdlIOa2iOaBr+WGheWuue+8iOWPr+S7peS4uuaVsOe7hOS7peWxleekuuWkmuadoea2iOaBr++8iVxyXG4gICAgICogQHBhcmFtIHtOdW1iZXJ9IHN0eWxlIOa2iOaBr+mjjuagvO+8iOWBtuaVsOS4uuiHquWKqOa2iOWkse+8jOWlh+aVsOS4uumcgOeCueWHu+ehruiupO+8ie+8mlxyXG4gICAgICog44CQMOOAkeW8ueWHuuiLpeW5suenkuWQjua2iOWkse+8jOOAkDLjgJHlnKgw55qE5Z+656GA5LiK5bCG5raI5oGv5Lul5YiX6KGo5b2i5byP5bGV546w77yM44CQNOOAkeWcqDDnmoTln7rnoYDkuIrlsIbmtojmga/ku6XooYzlvaLlvI/lsZXnjrDvvJtcclxuICAgICAqIOOAkDHjgJHlvLnlh7rlkI7pnIDngrnnoa7orqTvvIzjgJAz44CR5ZyoMeeahOWfuuehgOS4iuWwhua2iOaBr+S7peWIl+ihqOW9ouW8j+WxleeOsO+8jOOAkDXjgJHlnKgx55qE5Z+656GA5LiK5bCG5raI5oGv5Lul6KGM5b2i5byP5bGV546w77ybXHJcbiAgICAgKiBAcGFyYW0ge051bWJlcnxGdW5jdGlvbn0gaW5wdXQg5Zue6LCD5ZKM5pe26Ze077yaXHJcbiAgICAgKiDlvZPkuLrmlbDlrZfml7booajnpLrnlJ/mlYjml7bpl7TvvIjljZXkvY3kuLrnp5LvvIzlvZPmtojmga/po47moLzkuLow44CBMuOAgTTml7bnlJ/mlYjvvIzpu5jorqTkuLoz56eS77yJ77ybXHJcbiAgICAgKiDlvZPkuLrmlrnms5Xml7booajnpLrngrnlh7vlm57osIPvvIjlvZPmtojmga/po47moLzkuLox44CBM+OAgTXml7bnlJ/mlYjvvInvvJtcclxuICAgICAqIEBwYXJhbSB7Qm9vbGVhbn0gY2xlYW4g5piv5ZCm55yB55Wl5raI5oGv5Y+3XHJcbiAgICAgKi9cclxuICAgIHN1Y2Nlc3M6IGZ1bmN0aW9uIChtZXNzYWdlLCBzdHlsZSwgaW5wdXQsIGNsZWFuKSB7XHJcbiAgICAgICAgbXNnLm9wZW4obWVzc2FnZSwgXCJJXCIsIHN0eWxlLCBpbnB1dCwgY2xlYW4pO1xyXG4gICAgfSxcclxuICAgIC8qKlxyXG4gICAgICog6K2m5ZGK5raI5oGvXHJcbiAgICAgKiBAcGFyYW0ge09iamVjdH0gbWVzc2FnZSDmtojmga/lhoXlrrnvvIjlj6/ku6XkuLrmlbDnu4Tku6XlsZXnpLrlpJrmnaHmtojmga/vvIlcclxuICAgICAqIEBwYXJhbSB7TnVtYmVyfSBzdHlsZSDmtojmga/po47moLzvvIjlgbbmlbDkuLroh6rliqjmtojlpLHvvIzlpYfmlbDkuLrpnIDngrnlh7vnoa7orqTvvInvvJpcclxuICAgICAqIOOAkDDjgJHlvLnlh7roi6XlubLnp5LlkI7mtojlpLHvvIzjgJAy44CR5ZyoMOeahOWfuuehgOS4iuWwhua2iOaBr+S7peWIl+ihqOW9ouW8j+WxleeOsO+8jOOAkDTjgJHlnKgw55qE5Z+656GA5LiK5bCG5raI5oGv5Lul6KGM5b2i5byP5bGV546w77ybXHJcbiAgICAgKiDjgJAx44CR5by55Ye65ZCO6ZyA54K556Gu6K6k77yM44CQM+OAkeWcqDHnmoTln7rnoYDkuIrlsIbmtojmga/ku6XliJfooajlvaLlvI/lsZXnjrDvvIzjgJA144CR5ZyoMeeahOWfuuehgOS4iuWwhua2iOaBr+S7peihjOW9ouW8j+WxleeOsO+8m1xyXG4gICAgICogQHBhcmFtIHtOdW1iZXJ8RnVuY3Rpb259IGlucHV0IOWbnuiwg+WSjOaXtumXtO+8mlxyXG4gICAgICog5b2T5Li65pWw5a2X5pe26KGo56S655Sf5pWI5pe26Ze077yI5Y2V5L2N5Li656eS77yM5b2T5raI5oGv6aOO5qC85Li6MOOAgTLjgIE05pe255Sf5pWI77yM6buY6K6k5Li6M+enku+8ie+8m1xyXG4gICAgICog5b2T5Li65pa55rOV5pe26KGo56S654K55Ye75Zue6LCD77yI5b2T5raI5oGv6aOO5qC85Li6MeOAgTPjgIE15pe255Sf5pWI77yJ77ybXHJcbiAgICAgKiBAcGFyYW0ge0Jvb2xlYW59IGNsZWFuIOaYr+WQpuecgeeVpea2iOaBr+WPt1xyXG4gICAgICovXHJcbiAgICB3YXJuaW5nOiBmdW5jdGlvbiAobWVzc2FnZSwgc3R5bGUsIGlucHV0LCBjbGVhbikge1xyXG4gICAgICAgIG1zZy5vcGVuKG1lc3NhZ2UsIFwiV1wiLCBzdHlsZSwgaW5wdXQsIGNsZWFuKTtcclxuICAgIH0sXHJcbiAgICAvKipcclxuICAgICAqIOmUmeivr+a2iOaBr1xyXG4gICAgICogQHBhcmFtIHtPYmplY3R9IG1lc3NhZ2Ug5raI5oGv5YaF5a6577yI5Y+v5Lul5Li65pWw57uE5Lul5bGV56S65aSa5p2h5raI5oGv77yJXHJcbiAgICAgKiBAcGFyYW0ge051bWJlcn0gc3R5bGUg5raI5oGv6aOO5qC877yI5YG25pWw5Li66Ieq5Yqo5raI5aSx77yM5aWH5pWw5Li66ZyA54K55Ye756Gu6K6k77yJ77yaXHJcbiAgICAgKiDjgJAw44CR5by55Ye66Iul5bmy56eS5ZCO5raI5aSx77yM44CQMuOAkeWcqDDnmoTln7rnoYDkuIrlsIbmtojmga/ku6XliJfooajlvaLlvI/lsZXnjrDvvIzjgJA044CR5ZyoMOeahOWfuuehgOS4iuWwhua2iOaBr+S7peihjOW9ouW8j+WxleeOsO+8m1xyXG4gICAgICog44CQMeOAkeW8ueWHuuWQjumcgOeCueehruiupO+8jOOAkDPjgJHlnKgx55qE5Z+656GA5LiK5bCG5raI5oGv5Lul5YiX6KGo5b2i5byP5bGV546w77yM44CQNeOAkeWcqDHnmoTln7rnoYDkuIrlsIbmtojmga/ku6XooYzlvaLlvI/lsZXnjrDvvJtcclxuICAgICAqIEBwYXJhbSB7TnVtYmVyfEZ1bmN0aW9ufSBpbnB1dCDlm57osIPlkozml7bpl7TvvJpcclxuICAgICAqIOW9k+S4uuaVsOWtl+aXtuihqOekuueUn+aViOaXtumXtO+8iOWNleS9jeS4uuenku+8jOW9k+a2iOaBr+mjjuagvOS4ujDjgIEy44CBNOaXtueUn+aViO+8jOm7mOiupOS4ujPnp5LvvInvvJtcclxuICAgICAqIOW9k+S4uuaWueazleaXtuihqOekuueCueWHu+Wbnuiwg++8iOW9k+a2iOaBr+mjjuagvOS4ujHjgIEz44CBNeaXtueUn+aViO+8ie+8m1xyXG4gICAgICogQHBhcmFtIHtCb29sZWFufSBjbGVhbiDmmK/lkKbnnIHnlaXmtojmga/lj7dcclxuICAgICAqL1xyXG4gICAgZXJyb3I6IGZ1bmN0aW9uIChtZXNzYWdlLCBzdHlsZSwgaW5wdXQsIGNsZWFuKSB7XHJcbiAgICAgICAgbXNnLm9wZW4obWVzc2FnZSwgXCJFXCIsIHN0eWxlLCBpbnB1dCwgY2xlYW4pO1xyXG4gICAgfSxcclxuICAgIC8qKlxyXG4gICAgICog5b6q546v5raI5oGv77yI55WM6Z2i5ZCM6aOO5qC85Li6NeeahOaZrumAmua2iOaBr++8jOS9huaYr+aYr+W+queOr+W8ueWHuuavj+adoea2iOaBr++8iVxyXG4gICAgICogQHBhcmFtIHtPYmplY3R9IG1zZ3Mg5raI5oGv5YaF5a6577yI5aaC5p6c5Li65pWw57uE5YiZ5b6q546v5by55Ye65raI5oGv77yJXHJcbiAgICAgKiBAcGFyYW0ge0Z1bmN0aW9ufSBhZnRlciDlvZPmnIDlkI7kuIDkuKrmtojmga/ngrnlh7vnoa7lrprlkI7nmoTlm57osINcclxuICAgICAqIEBwYXJhbSB7RnVuY3Rpb259IGV2ZXJ5IOavj+S4qua2iOaBr+eCueWHu+ehruWumuWQjueahOWbnuiwg1xyXG4gICAgICogQHBhcmFtIHtCb29sZWFufSBjbGVhbiDmmK/lkKbnnIHnlaXmtojmga/lj7dcclxuICAgICAqL1xyXG4gICAgcmVwZWF0OiBmdW5jdGlvbiAobXNncywgYWZ0ZXIsIGV2ZXJ5LCBpbmRleCwgY2xlYW4pIHtcclxuICAgICAgICBhZnRlciA9IGFmdGVyIHx8IGZ1bmN0aW9uICgpIHsgfTtcclxuICAgICAgICBldmVyeSA9IGV2ZXJ5IHx8IGZ1bmN0aW9uICgpIHsgfTtcclxuICAgICAgICBpbmRleCA9IGluZGV4IHx8IDA7XHJcbiAgICAgICAgaWYgKGNsZWFuKSBtc2dzID0gY2xlYW5Nc2cobXNncywgJ1MnKTtcclxuICAgICAgICBlbHNlIG1zZ3MgPSBjaGVja01zZyhtc2dzLCAnUycpO1xyXG4gICAgICAgIGlmIChtc2dzLmxlbmd0aCA+IGluZGV4KSB7XHJcbiAgICAgICAgICAgIGlmIChtc2dzLmxlbmd0aCA9PSAxKSB7XHJcbiAgICAgICAgICAgICAgICBtc2cub3Blbihtc2dzW2luZGV4XSwgbXNnc1tpbmRleF0udHlwZSwgNSwgZnVuY3Rpb24gKCkge1xyXG4gICAgICAgICAgICAgICAgICAgIGV2ZXJ5KGluZGV4KTtcclxuICAgICAgICAgICAgICAgICAgICBhZnRlcigpO1xyXG4gICAgICAgICAgICAgICAgfSwgY2xlYW4pO1xyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgICAgIGVsc2Uge1xyXG4gICAgICAgICAgICAgICAgbXNnLm9wZW4obXNnc1tpbmRleF0sIG1zZ3NbaW5kZXhdLnR5cGUsIDUsIGZ1bmN0aW9uICgpIHtcclxuICAgICAgICAgICAgICAgICAgICBpbmRleCsrO1xyXG4gICAgICAgICAgICAgICAgICAgIGV2ZXJ5KGluZGV4KTtcclxuICAgICAgICAgICAgICAgICAgICBpZiAobXNncy5sZW5ndGggPT0gaW5kZXgpIGFmdGVyKCk7XHJcbiAgICAgICAgICAgICAgICAgICAgbXNnLnJlcGVhdChtc2dzLCBhZnRlciwgZXZlcnksIGluZGV4LCBjbGVhbik7XHJcbiAgICAgICAgICAgICAgICB9LCBjbGVhbik7XHJcbiAgICAgICAgICAgIH1cclxuICAgICAgICB9XHJcbiAgICB9LFxyXG5cclxuICAgIG9rOiBmdW5jdGlvbiAobWVzc2FnZSwgc3R5bGUsIGlucHV0KSB7XHJcbiAgICAgICAgbXNnLnN1Y2Nlc3MobWVzc2FnZSwgc3R5bGUsIGlucHV0LCB0cnVlKVxyXG4gICAgfSxcclxuXHJcbiAgICB3YXJuOiBmdW5jdGlvbiAobWVzc2FnZSwgc3R5bGUsIGlucHV0KSB7XHJcbiAgICAgICAgbXNnLndhcm5pbmcobWVzc2FnZSwgc3R5bGUsIGlucHV0LCB0cnVlKTtcclxuICAgIH0sXHJcblxyXG4gICAgZXJyOiBmdW5jdGlvbiAobWVzc2FnZSwgc3R5bGUsIGlucHV0KSB7XHJcbiAgICAgICAgbXNnLmVycm9yKG1lc3NhZ2UsIHN0eWxlLCBpbnB1dCwgdHJ1ZSk7XHJcbiAgICB9LFxyXG5cclxuICAgIHJlcDogZnVuY3Rpb24gKG1zZ3MsIGFmdGVyLCBldmVyeSwgaW5kZXgpIHtcclxuICAgICAgICBtc2cucmVwZWF0KG1zZ3MsIGFmdGVyLCBldmVyeSwgaW5kZXgsIHRydWUpO1xyXG4gICAgfSxcclxuXHJcbiAgICAvKirlhoXpg6jmk43kvZzvvIjor7fli7/lnKjlpJbpg6jmk43kvZzvvIkgKi9cclxuICAgIGZuOiB7XHJcbiAgICAgICAgY29tYmluZTogZnVuY3Rpb24gKG1lc3NhZ2UpIHtcclxuICAgICAgICAgICAgdmFyIHJzdCA9IFwiXCI7XHJcbiAgICAgICAgICAgIGZvciAodmFyIGkgPSAwOyBpIDwgbWVzc2FnZS5sZW5ndGg7IGkrKykge1xyXG4gICAgICAgICAgICAgICAgaWYgKHR5cGVvZiBtZXNzYWdlW2ldID09PSBcInN0cmluZ1wiKSByc3QgPSByc3QgKyBtZXNzYWdlW2ldICsgXCI8L2JyPlwiO1xyXG4gICAgICAgICAgICAgICAgZWxzZSByc3QgPSByc3QgKyBcIuOAkFwiICsgbWVzc2FnZVtpXS5jb2RlICsgXCIoXCIgKyBtZXNzYWdlW2ldLnR5cGUgKyBcIilcIiArIFwi44CRXCIgKyBtZXNzYWdlW2ldLm1lc3NhZ2UgKyBcIjwvYnI+XCI7XHJcbiAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgcmV0dXJuIHJzdDtcclxuICAgICAgICB9LFxyXG4gICAgICAgIG1lcmdlOiBmdW5jdGlvbiAobWVzc2FnZSwgZml4KSB7XHJcbiAgICAgICAgICAgIHZhciBmaXhTcGFuID0gXCJtYXJnaW4tdG9wOjZweDtcIjtcclxuICAgICAgICAgICAgaWYgKHR5cGVvZiBmaXggPT09IFwiYm9vbGVhblwiICYmIGZpeCA9PT0gZmFsc2UpIGZpeFNwYW4gPSBcIlwiO1xyXG4gICAgICAgICAgICB2YXIgY29udGVudCA9IFwiXCI7XHJcbiAgICAgICAgICAgIGZvciAodmFyIGkgPSAwOyBpIDwgbWVzc2FnZS5sZW5ndGg7IGkrKykge1xyXG4gICAgICAgICAgICAgICAgY29udGVudCA9IGNvbnRlbnQgKyBcIjxkaXYgc3R5bGU9XFxcInBhZGRpbmc6MTBweCAyMHB4OyBkaXNwbGF5OmZsZXg7XFxcIj5cIjtcclxuICAgICAgICAgICAgICAgIGlmICh0eXBlb2YgbWVzc2FnZVtpXSA9PT0gXCJzdHJpbmdcIikgY29udGVudCA9IGNvbnRlbnQgKyBtZXNzYWdlW2ldO1xyXG4gICAgICAgICAgICAgICAgZWxzZSBjb250ZW50ID0gY29udGVudCArIG1zZy5mbi50eXBlKG1lc3NhZ2VbaV0udHlwZSkgKyBcIjxzcGFuIHN0eWxlPVxcXCJtYXJnaW4tbGVmdDoxNXB4OyBmbG9hdDpsZWZ0O1wiICsgZml4U3BhbiArIFwiXFxcIj5cIiArIG1lc3NhZ2VbaV0uY29kZSArIFwiIFwiICsgbWVzc2FnZVtpXS5tZXNzYWdlICsgXCI8L3NwYW4+XCI7XHJcbiAgICAgICAgICAgICAgICBjb250ZW50ID0gY29udGVudCArIFwiPC9kaXY+XCI7XHJcbiAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgcmV0dXJuIGNvbnRlbnQ7XHJcbiAgICAgICAgfSxcclxuICAgICAgICBsaXN0OiBmdW5jdGlvbiAobWVzc2FnZSkge1xyXG4gICAgICAgICAgICBmb3IgKHZhciBpID0gMDsgaSA8IG1lc3NhZ2UubGVuZ3RoOyBpKyspIHtcclxuICAgICAgICAgICAgICAgIGlmICh0eXBlb2YgbWVzc2FnZVtpXSA9PT0gXCJzdHJpbmdcIikgbWVzc2FnZVtpXSA9IHsgbWVzc2FnZTogbWVzc2FnZVtpXSB9O1xyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgICAgIHJldHVybiBtZXNzYWdlO1xyXG4gICAgICAgIH0sXHJcbiAgICAgICAgZml4OiBmdW5jdGlvbiAobWVzc2FnZSkge1xyXG4gICAgICAgICAgICB2YXIgaGVpZ2h0ID0gMTIwO1xyXG4gICAgICAgICAgICB2YXIgd2lkdGggPSAyMDA7XHJcbiAgICAgICAgICAgIGlmIChtZXNzYWdlIGluc3RhbmNlb2YgQXJyYXkpIHtcclxuICAgICAgICAgICAgICAgIGhlaWdodCA9IGhlaWdodCArIG1lc3NhZ2UubGVuZ3RoICogNDc7XHJcbiAgICAgICAgICAgICAgICBmb3IgKHZhciBpID0gMDsgaSA8IG1lc3NhZ2UubGVuZ3RoOyBpKyspIHtcclxuICAgICAgICAgICAgICAgICAgICB2YXIgZWxlbSA9IGRvY3VtZW50LmNyZWF0ZUVsZW1lbnQoXCJzcGFuXCIpO1xyXG4gICAgICAgICAgICAgICAgICAgIGVsZW0uaW5uZXJUZXh0ID0gbWVzc2FnZVtpXS5jb2RlICsgXCIgXCIgKyBtZXNzYWdlW2ldLm1lc3NhZ2U7XHJcbiAgICAgICAgICAgICAgICAgICAgJChlbGVtKS5hcHBlbmRUbygnYm9keScpO1xyXG4gICAgICAgICAgICAgICAgICAgIGlmICh3aWR0aCA8IGVsZW0ub2Zmc2V0V2lkdGggKyAxMDApIHdpZHRoID0gZWxlbS5vZmZzZXRXaWR0aCArIDEwMDtcclxuICAgICAgICAgICAgICAgICAgICAkKGVsZW0pLnJlbW92ZSgpO1xyXG4gICAgICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgICAgIGlmIChoZWlnaHQgPiA1MDApIGhlaWdodCA9IDUwMDtcclxuICAgICAgICAgICAgaWYgKHdpZHRoIDwgaGVpZ2h0ICsgMTUwKSB3aWR0aCA9IGhlaWdodCArIDE1MDtcclxuICAgICAgICAgICAgaWYgKHdpZHRoID4gMTAwMCkgd2lkdGggPSAxMDAwO1xyXG4gICAgICAgICAgICByZXR1cm4gW3dpZHRoICsgJ3B4JywgaGVpZ2h0ICsgJ3B4J107XHJcbiAgICAgICAgfSxcclxuICAgICAgICB0eXBlOiBmdW5jdGlvbiAodHlwZSwgc2l6ZSkge1xyXG4gICAgICAgICAgICBzaXplID0gc2l6ZSB8fCBcIjI1cHhcIjtcclxuICAgICAgICAgICAgc3dpdGNoICh0eXBlKSB7XHJcbiAgICAgICAgICAgICAgICBjYXNlIFwiSVwiOlxyXG4gICAgICAgICAgICAgICAgY2FzZSBcIlNcIjpcclxuICAgICAgICAgICAgICAgICAgICByZXR1cm4gXCI8aSBjbGFzcz1cXFwibGF5dWktaWNvbiBsYXl1aS1pY29uLWZhY2Utc21pbGVcXFwiIHN0eWxlPVxcXCJmb250LXNpemU6IFwiICsgc2l6ZSArIFwiOyBjb2xvcjpncmVlbjsgZmxvYXQ6bGVmdDtcXFwiPjwvaT5cIjtcclxuICAgICAgICAgICAgICAgIGNhc2UgXCJXXCI6XHJcbiAgICAgICAgICAgICAgICAgICAgcmV0dXJuIFwiPGkgY2xhc3M9XFxcImxheXVpLWljb24gbGF5dWktaWNvbi1mYWNlLXN1cnByaXNlZFxcXCIgc3R5bGU9XFxcImZvbnQtc2l6ZTogXCIgKyBzaXplICsgXCI7IGNvbG9yOiNkMjY0NDI7IGZsb2F0OmxlZnQ7XFxcIj48L2k+XCI7XHJcbiAgICAgICAgICAgICAgICBjYXNlIFwiRVwiOlxyXG4gICAgICAgICAgICAgICAgZGVmYXVsdDpcclxuICAgICAgICAgICAgICAgICAgICByZXR1cm4gXCI8aSBjbGFzcz1cXFwibGF5dWktaWNvbiBsYXl1aS1pY29uLWZhY2UtY3J5XFxcIiBzdHlsZT1cXFwiZm9udC1zaXplOiBcIiArIHNpemUgKyBcIjsgY29sb3I6cmVkOyBmbG9hdDpsZWZ0O1xcXCI+PC9pPlwiO1xyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgfVxyXG4gICAgfVxyXG59O1xyXG5cclxuZnVuY3Rpb24gY2xlYW5Nc2cobWVzc2FnZSwgdHlwZSkge1xyXG4gICAgaWYgKHR5cGVvZiBtZXNzYWdlID09PSAnc3RyaW5nJykgbWVzc2FnZSA9IFt7IGNvZGU6ICcnLCB0eXBlOiB0eXBlLCBtZXNzYWdlOiBtZXNzYWdlIH1dO1xyXG4gICAgZWxzZSBpZiAodHlwZW9mIG1lc3NhZ2UgPT09ICdvYmplY3QnKSB7XHJcbiAgICAgICAgaWYgKG1lc3NhZ2UgaW5zdGFuY2VvZiBBcnJheSkge1xyXG4gICAgICAgICAgICBtZXNzYWdlLmZvckVhY2goZnVuY3Rpb24gKGl0ZW0pIHtcclxuICAgICAgICAgICAgICAgIGlmICh0eXBlb2YgaXRlbSA9PT0gJ29iamVjdCcpIHtcclxuICAgICAgICAgICAgICAgICAgICBpdGVtLm1lc3NhZ2UgPSBpdGVtLm1lc3NhZ2UgfHwgJyc7XHJcbiAgICAgICAgICAgICAgICAgICAgaXRlbS50eXBlID0gaXRlbS50eXBlIHx8ICdTJztcclxuICAgICAgICAgICAgICAgICAgICBpdGVtLmNvZGUgPSAnJztcclxuICAgICAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgICAgIGVsc2UgaXRlbSA9IFt7IGNvZGU6ICcnLCB0eXBlOiB0eXBlLCBtZXNzYWdlOiBpdGVtLnRvU3RyaW5nKCkgfV07XHJcbiAgICAgICAgICAgIH0pO1xyXG4gICAgICAgIH1cclxuICAgICAgICBlbHNlIHtcclxuICAgICAgICAgICAgbWVzc2FnZS5tZXNzYWdlID0gbWVzc2FnZS5tZXNzYWdlIHx8ICcnO1xyXG4gICAgICAgICAgICBtZXNzYWdlLnR5cGUgPSBtZXNzYWdlLnR5cGUgfHwgJ1MnO1xyXG4gICAgICAgICAgICBtZXNzYWdlLmNvZGUgPSAnJztcclxuICAgICAgICAgICAgbWVzc2FnZSA9IFttZXNzYWdlXTtcclxuICAgICAgICB9XHJcbiAgICB9XHJcbiAgICBlbHNlIHRocm93IEVycm9yKCfmtojmga/nsbvlnovplJnor6/vvJrml6LkuI3mmK/lrZfnrKbkuLLvvIjnu4TvvInvvIzkuZ/kuI3mmK/moIflh4bnmoRBcGlSZXR1buS4reeahOa2iOaBr++8iOe7hO+8iScpO1xyXG4gICAgcmV0dXJuIG1lc3NhZ2U7XHJcbn1cclxuXHJcbmZ1bmN0aW9uIGNoZWNrTXNnKG1lc3NhZ2UsIHR5cGUpIHtcclxuICAgIGlmICh0eXBlb2YgbWVzc2FnZSA9PT0gJ3N0cmluZycpIG1lc3NhZ2UgPSBbeyBjb2RlOiAnMDAwMTUnLCB0eXBlOiB0eXBlLCBtZXNzYWdlOiBtZXNzYWdlIH1dO1xyXG4gICAgZWxzZSBpZiAodHlwZW9mIG1lc3NhZ2UgPT09ICdvYmplY3QnKSB7XHJcbiAgICAgICAgaWYgKG1lc3NhZ2UgaW5zdGFuY2VvZiBBcnJheSkge1xyXG4gICAgICAgICAgICBtZXNzYWdlLmZvckVhY2goZnVuY3Rpb24gKGl0ZW0pIHtcclxuICAgICAgICAgICAgICAgIGlmICh0eXBlb2YgaXRlbSA9PT0gJ29iamVjdCcpIHtcclxuICAgICAgICAgICAgICAgICAgICBpdGVtLm1lc3NhZ2UgPSBpdGVtLm1lc3NhZ2UgfHwgJyc7XHJcbiAgICAgICAgICAgICAgICAgICAgaXRlbS50eXBlID0gaXRlbS50eXBlIHx8ICdTJztcclxuICAgICAgICAgICAgICAgICAgICBpdGVtLmNvZGUgPSBpdGVtLmNvZGUgfHwgJzAwMDE1JztcclxuICAgICAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgICAgIGVsc2UgaXRlbSA9IFt7IGNvZGU6ICcwMDAxNScsIHR5cGU6IHR5cGUsIG1lc3NhZ2U6IGl0ZW0udG9TdHJpbmcoKSB9XTtcclxuICAgICAgICAgICAgfSk7XHJcbiAgICAgICAgfVxyXG4gICAgICAgIGVsc2Uge1xyXG4gICAgICAgICAgICBtZXNzYWdlLm1lc3NhZ2UgPSBtZXNzYWdlLm1lc3NhZ2UgfHwgJyc7XHJcbiAgICAgICAgICAgIG1lc3NhZ2UudHlwZSA9IG1lc3NhZ2UudHlwZSB8fCAnUyc7XHJcbiAgICAgICAgICAgIG1lc3NhZ2UuY29kZSA9IG1lc3NhZ2UuY29kZSB8fCAnMDAwMTUnO1xyXG4gICAgICAgICAgICBtZXNzYWdlID0gW21lc3NhZ2VdO1xyXG4gICAgICAgIH1cclxuICAgIH1cclxuICAgIGVsc2UgdGhyb3cgRXJyb3IoJ+a2iOaBr+exu+Wei+mUmeivr++8muaXouS4jeaYr+Wtl+espuS4su+8iOe7hO+8ie+8jOS5n+S4jeaYr+agh+WHhueahEFwaVJldHVu5Lit55qE5raI5oGv77yI57uE77yJJyk7XHJcbiAgICByZXR1cm4gbWVzc2FnZTtcclxufVxyXG5cclxuZXhwb3J0IGRlZmF1bHQgbXNnOyIsImltcG9ydCBmbiBmcm9tIFwiLi4vLi4vaW50ZXJuYWwuanNcIjtcclxuaW1wb3J0ICQgZnJvbSBcImpxdWVyeVwiO1xyXG5pbXBvcnQgc2F2ZSBmcm9tIFwiLi4vLi4vdXRpbHMvc2F2ZS5qc1wiO1xyXG5pbXBvcnQgbWFpbiBmcm9tIFwiLi4vLi4vbWFpbi5qc1wiO1xyXG5cclxuLyoq5YWo5bGA6aOO5qC8ICovXHJcbnZhciBzdHlsZSA9IHtcclxuXHJcbiAgICAvKuagh+WHhuaTjeS9nCovXHJcbiAgICAvKipcclxuICAgICAqIOivu+WPluacrOWcsOWtmOWCqOeahHZhbHVlc1xyXG4gICAgICogQHBhcmFtIHtTdHJpbmd9IGtleVxyXG4gICAgICovXHJcbiAgICByZWFkOiBmdW5jdGlvbiAoa2V5KSB7XHJcbiAgICAgICAga2V5ID0ga2V5IHx8IHNhdmUubmFtZSgpO1xyXG4gICAgICAgIHZhciByc3QgPSBudWxsXHJcbiAgICAgICAgaWYgKHNhdmUuYXZhaWxhYmxlKCkpIHtcclxuICAgICAgICAgICAgaWYgKHNhdmUuZXhpc3Qoa2V5KSkge1xyXG4gICAgICAgICAgICAgICAgcnN0ID0gc2F2ZS5nZXQoa2V5KTtcclxuICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICBlbHNlIHtcclxuICAgICAgICAgICAgICAgIHJzdCA9IFwiXCI7XHJcbiAgICAgICAgICAgIH1cclxuICAgICAgICB9XHJcbiAgICAgICAgcmV0dXJuIHJzdDtcclxuICAgIH0sXHJcbiAgICAvKipcclxuICAgICAqIOW6lOeUqHZhbHVlcy5zdHlsZVxyXG4gICAgICogQHBhcmFtIHtPYmplY3R9IGNvbmZpZ1xyXG4gICAgICovXHJcbiAgICBhcHBseTogZnVuY3Rpb24gKGNvbmZpZykge1xyXG4gICAgICAgIGNvbmZpZyA9IGNvbmZpZyB8fCBtYWluLnZhbHVlcztcclxuICAgICAgICAkKCcubGF5dWktZWxlbS1maWVsZCcpLmNzcygnY29sb3InLCBjb25maWcuc3R5bGUuY29sb3IudGFnIHx8IG1haW4udmFsdWVzLnN0eWxlLmNvbG9yLnRhZyk7XHJcbiAgICAgICAgJCgnLmxheXVpLWVsZW0tZmllbGQnKS5jc3MoJ2JvcmRlci1jb2xvcicsIGNvbmZpZy5zdHlsZS5jb2xvci50YWcgfHwgbWFpbi52YWx1ZXMuc3R5bGUuY29sb3IudGFnKTtcclxuICAgICAgICAkKCcubGF5dWktc2lkZSAubGF5dWktbmF2JykuY3NzKCdiYWNrZ3JvdW5kLWNvbG9yJywgY29uZmlnLnN0eWxlLmNvbG9yLmxyIHx8IG1haW4udmFsdWVzLnN0eWxlLmNvbG9yLmxyKTtcclxuICAgICAgICAkKCcubGF5dWktaGVhZGVyJykuY3NzKCdiYWNrZ3JvdW5kLWNvbG9yJywgY29uZmlnLnN0eWxlLmNvbG9yLmhlYWQgfHwgbWFpbi52YWx1ZXMuc3R5bGUuY29sb3IuaGVhZCk7XHJcbiAgICAgICAgcmV0dXJuIHRydWU7XHJcbiAgICB9LFxyXG5cclxuICAgIC8q5b+r6YCf5pON5L2cKi9cclxuICAgIC8qKlxyXG4gICAgICog5b+r6YCf6I635Y+W5pys5Zyw5a2Y5YKo5bm25L2/55SoXHJcbiAgICAgKiBAcGFyYW0ge1N0cmluZ30gdHlwZSDnlZnnqbrvvJrku4Xor7vlj5bmnKzlnLDlrZjlgqjlubblupTnlKjvvIxzZXTvvJrlnKjnlZnnqbrln7rnoYDkuIrvvIzlpoLmnpzmsqHmnInmnKzlnLDlgqjlrZjliJnlsIbpu5jorqTlgLzlrZjlhaXmnKzlnLDlrZjlgqjvvIxtaXjvvJrlnKhzZXTln7rnoYDkuIrvvIzlpoLmnpzmnInmnKzlnLDlgqjlrZjliJnlsIbmnKzlnLDlrZjlgqjopobnm5bliLB2YWx1ZXNcclxuICAgICAqL1xyXG4gICAgYXV0bzogZnVuY3Rpb24gKHR5cGUpIHtcclxuICAgICAgICB0eXBlID0gdHlwZSB8fCBcIlwiO1xyXG4gICAgICAgIHZhciBjb25maWcgPSBzdHlsZS5yZWFkKCkgfHwgXCJcIjtcclxuICAgICAgICBpZiAoY29uZmlnID09IG51bGwpIHJldHVybiBmYWxzZTtcclxuICAgICAgICBzd2l0Y2ggKHR5cGUpIHtcclxuICAgICAgICAgICAgY2FzZSBcInNldFwiOlxyXG4gICAgICAgICAgICAgICAgaWYgKGNvbmZpZyA9PSBcIlwiKSB7XHJcbiAgICAgICAgICAgICAgICAgICAgY29uZmlnID0gbWFpbi52YWx1ZXM7XHJcbiAgICAgICAgICAgICAgICAgICAgc2F2ZS5zZXQoc2F2ZS5uYW1lKCksIGNvbmZpZyk7XHJcbiAgICAgICAgICAgICAgICAgICAgc3R5bGUuYXBwbHkoY29uZmlnKTtcclxuICAgICAgICAgICAgICAgICAgICByZXR1cm4gdHJ1ZTtcclxuICAgICAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgICAgIGVsc2Uge1xyXG4gICAgICAgICAgICAgICAgICAgIHN0eWxlLmFwcGx5KGNvbmZpZyk7XHJcbiAgICAgICAgICAgICAgICAgICAgcmV0dXJuIHRydWU7XHJcbiAgICAgICAgICAgICAgICB9XHJcbiAgICAgICAgICAgICAgICBicmVhaztcclxuICAgICAgICAgICAgY2FzZSBcIm1peFwiOlxyXG4gICAgICAgICAgICAgICAgaWYgKGNvbmZpZyA9PSBcIlwiKSB7XHJcbiAgICAgICAgICAgICAgICAgICAgY29uZmlnID0gbWFpbi52YWx1ZXM7XHJcbiAgICAgICAgICAgICAgICAgICAgc2F2ZS5zZXQoc2F2ZS5uYW1lKCksIGNvbmZpZyk7XHJcbiAgICAgICAgICAgICAgICAgICAgc3R5bGUuYXBwbHkoY29uZmlnKTtcclxuICAgICAgICAgICAgICAgICAgICByZXR1cm4gdHJ1ZTtcclxuICAgICAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgICAgIGVsc2Uge1xyXG4gICAgICAgICAgICAgICAgICAgIG1haW4udmFsdWVzID0gY29uZmlnO1xyXG4gICAgICAgICAgICAgICAgICAgIHN0eWxlLmFwcGx5KGNvbmZpZyk7XHJcbiAgICAgICAgICAgICAgICAgICAgcmV0dXJuIHRydWU7XHJcbiAgICAgICAgICAgICAgICB9XHJcbiAgICAgICAgICAgICAgICBicmVhaztcclxuICAgICAgICAgICAgZGVmYXVsdDpcclxuICAgICAgICAgICAgICAgIGlmIChjb25maWcgIT0gXCJcIikge1xyXG4gICAgICAgICAgICAgICAgICAgIHN0eWxlLmFwcGx5KGNvbmZpZyk7XHJcbiAgICAgICAgICAgICAgICAgICAgcmV0dXJuIHRydWU7XHJcbiAgICAgICAgICAgICAgICB9XHJcbiAgICAgICAgICAgICAgICBicmVhaztcclxuICAgICAgICB9XHJcbiAgICB9LFxyXG5cclxuICAgIC8q6L+e54K55pON5L2cKi9cclxuICAgIC8qKlxyXG4gICAgICog6K6+572u5qCH562+6aKc6ImyXHJcbiAgICAgKiBAcGFyYW0ge1N0cmluZ30gaW5wdXRcclxuICAgICAqL1xyXG4gICAgdGFnQ29sb3I6IGZ1bmN0aW9uIChpbnB1dCkge1xyXG4gICAgICAgIHJldHVybiBzdHlsZS5kb3QoaW5wdXQsIG1haW4udmFsdWVzLnN0eWxlLmNvbG9yLnRhZyk7XHJcbiAgICB9LFxyXG4gICAgLyoqXHJcbiAgICAgKiDorr7nva7lt6bkvqfoj5zljZXog4zmma/oibJcclxuICAgICAqIEBwYXJhbSB7U3RyaW5nfSBpbnB1dFxyXG4gICAgICovXHJcbiAgICBsckNvbG9yOiBmdW5jdGlvbiAoaW5wdXQpIHtcclxuICAgICAgICByZXR1cm4gc3R5bGUuZG90KGlucHV0LCBtYWluLnZhbHVlcy5zdHlsZS5jb2xvci5scik7XHJcbiAgICB9LFxyXG4gICAgLyoqXHJcbiAgICAgKiDorr7nva7pobbpg6jmoIfpopjog4zmma/oibJcclxuICAgICAqIEBwYXJhbSB7U3RyaW5nfSBpbnB1dFxyXG4gICAgICovXHJcbiAgICBoZWFkQ29sb3I6IGZ1bmN0aW9uIChpbnB1dCkge1xyXG4gICAgICAgIHJldHVybiBzdHlsZS5kb3QoaW5wdXQsIG1haW4udmFsdWVzLnN0eWxlLmNvbG9yLmhlYWQpO1xyXG4gICAgfSxcclxuICAgIGRvdDogZnVuY3Rpb24gKGlucHV0LCB2YWx1ZSkge1xyXG4gICAgICAgIGlmIChpbnB1dCA9PT0gdW5kZWZpbmVkKSB7IHJldHVybiB2YWx1ZTsgfVxyXG4gICAgICAgIGVsc2UgeyBpbnB1dCA9PSBpbnB1dCB8fCBcIlwiOyB9XHJcbiAgICAgICAgdmFsdWUgPSBpbnB1dDtcclxuICAgICAgICBzdHlsZS5hcHBseShtYWluLnZhbHVlcyk7XHJcbiAgICAgICAgcmV0dXJuIHRoaXM7XHJcbiAgICB9LFxyXG4gICAgLyoqXHJcbiAgICAgKiDkv53lrZjoh7PmnKzlnLBcclxuICAgICAqIEBwYXJhbSB7U3RyaW5nfSBrZXlcclxuICAgICAqL1xyXG4gICAgc2F2ZTogZnVuY3Rpb24gKGtleSkge1xyXG4gICAgICAgIGlmIChrZXkgPT09IHVuZGVmaW5lZCB8fCBrZXkgPT09IG51bGwpIHJldHVybiB0aGlzO1xyXG4gICAgICAgIGVsc2UgcmV0dXJuIGZuLnNhdmUoa2V5KTtcclxuICAgIH0sXHJcbiAgICAvKipcclxuICAgICAqIOi/lOWbnuS4iuS4gOe6p+aIluaMh+WumueCuVxyXG4gICAgICogQHBhcmFtIHtTdHJpbmd9IGtleVxyXG4gICAgICovXHJcbiAgICBydDogZnVuY3Rpb24gKGtleSkge1xyXG4gICAgICAgIHJldHVybiBmbi5ydChrZXkpO1xyXG4gICAgfVxyXG5cclxufTtcclxuXHJcbmV4cG9ydCBkZWZhdWx0IHN0eWxlOyIsImltcG9ydCBjb25maWcgZnJvbSBcIi4vY29uZmlnLmpzXCI7XHJcbmltcG9ydCBtZXJnZSBmcm9tIFwiLi91dGlscy9tZXJnZS5qc1wiO1xyXG5pbXBvcnQgZm4gZnJvbSBcIi4vaW50ZXJuYWwuanNcIjtcclxuXHJcbi8qKiDlhajlsYDlj5jph4/lkoznvJPlrZjvvJrnv7vor5HmlofmnKznvJPlrZggKi9cclxudmFyIHZhbHVlcyA9IHtcclxuICAgIGNvbW1vbjoge1xyXG4gICAgICAgIGxheXVpX0Rhb0RpOiBcIuWIsOesrFwiLFxyXG4gICAgICAgIGxheXVpX1llOiBcIumhtVwiLFxyXG4gICAgICAgIGxheXVpX1F1ZURpbmc6IFwi56Gu5a6aXCIsXHJcbiAgICAgICAgbGF5dWlfR29uZzogXCLlhbFcIixcclxuICAgICAgICBsYXl1aV9UaWFvOiBcIuadoVwiLFxyXG4gICAgICAgIGxheXVpX3RpdGxlX2luZm9yOiBcIuS/oeaBr1wiLFxyXG4gICAgICAgIGxheXVpX2J0bl9jb25maXJtOiBcIuehruWumlwiLFxyXG4gICAgICAgIGxheXVpX2J0bl9jYW5jZWw6IFwi5Y+W5raIXCIsXHJcbiAgICAgICAgbGF5dWlfbXNnX1M6IFwi5o+Q56S6XCIsXHJcbiAgICAgICAgbGF5dWlfbXNnX1c6IFwi6K2m5ZGKXCIsXHJcbiAgICAgICAgbGF5dWlfbXNnX0U6IFwi6ZSZ6K+vXCIsXHJcbiAgICAgICAgbGF5dWlfbXNnX2J0bjogXCLnoa7orqRcIixcclxuICAgICAgICBsYXl1aV9tc2dfdGFibGVfY29kZTogXCLmtojmga/ku6PnoIFcIixcclxuICAgICAgICBsYXl1aV9tc2dfdGFibGVfdHlwZTogXCLmtojmga/nsbvlnotcIixcclxuICAgICAgICBsYXl1aV9tc2dfdGFibGVfY29udGVudDogXCLmtojmga/lhoXlrrlcIixcclxuICAgICAgICB3ZXVpX3BpY2tlcl95ZWFyOiAn5bm0JyxcclxuICAgICAgICB3ZXVpX3BpY2tlcl9tb250aDogJ+aciCcsXHJcbiAgICAgICAgd2V1aV9waWNrZXJfZGF5OiAn5pelJyxcclxuICAgICAgICB3ZXVpX2J0bl9jb250aW51ZTogJ+e7p+e7rScsXHJcbiAgICAgICAgd2V1aV9idG5fY2xvc2U6ICflhbPpl60nLFxyXG4gICAgICAgIHdldWlfYnRuX2NvbmZpcm06ICfnoa7orqQnLFxyXG4gICAgICAgIHdldWlfYnRuX2NhbmNlbDogJ+WPlua2iCcsXHJcbiAgICAgICAgd2V1aV9uYXZfbWFpbjogJ+S4u+iPnOWNlScsXHJcbiAgICAgICAgd2V1aV9uYXZfc3ViOiAn5a2Q6I+c5Y2VJ1xyXG4gICAgfSxcclxuICAgIGx2OiB7fVxyXG59O1xyXG5cclxuLyoqIOWbvemZheWMluS4juacrOWcsOWMliAqL1xyXG52YXIgZ2xvYmFsaXplID0ge1xyXG4gICAgdmFsdWVzOiB2YWx1ZXMsXHJcblxyXG4gICAgLyoq5Yqg6L29TGF5dWnlpJror63oqIDmqKHlnZfvvIjlpoLmnpxMYXl1aeaYr+aooeWdl+WMluWKoOi9ve+8jOmcgOWGmeWIsGxheXVpLnVzZeWGhemDqO+8iSAqL1xyXG4gICAgcmVwbGFjZUxheXVpOiBmdW5jdGlvbiAoKSB7XHJcbiAgICAgICAgeHVydWkubGF5dWkuZm4ucmVwbGFjZUxheXVpKCk7XHJcbiAgICB9LFxyXG5cclxuICAgIC8qKlxyXG4gICAgICog5omL5Yqo6K6+572u5pys5Zyw5paH5YyW5Luj56CB77yI6ZyA56ym5ZCIaTE4buagh+WHhu+8iVxyXG4gICAgICogQHBhcmFtIHtTdHJpbmd9IGlucHV0XHJcbiAgICAgKi9cclxuICAgIHNldEN1bHR1cmU6IGZ1bmN0aW9uIChpbnB1dCkge1xyXG4gICAgICAgIGNvbmZpZy5nbG9iYWxpemUuY3VsdHVyZSA9IGlucHV0O1xyXG4gICAgfSxcclxuXHJcbiAgICAvKipcclxuICAgICAqIOWKoOi9veivreiogOWMhe+8jOW5tue7mWxpZOi1i+WAvO+8iGNvbW1vbuS4jmx25Y+Y6YeP55qEa2V555u05o6l5Y+v55So5LqObGlk77yM5YW25LuW6Ieq5a6a5LmJ5Y+Y6YeP6ZyA6KaB5Yqg5YmN57yA77yJXHJcbiAgICAgKiBAcGFyYW0ge1N0cmluZ30gbG9jYXRpb24g6K+t6KiA5YyF6Lev5b6EXHJcbiAgICAgKiBAcGFyYW0ge1N0cmluZ30gbmFtZSDoh6rlrprkuYnlj5jph4/vvIjnlZnnqbrliJnkuLpjb21tb27vvIlcclxuICAgICAqIEBwYXJhbSB7U3RyaW5nfSB0eXBlIOWmguaenOiHquWumuS5ieWPmOmHj+W3suWtmOWcqOaXtueahOaTjeS9nO+8iOeVmeepuuS4uuabv+aNou+8jG1lcmdl5Li65ZCI5bm277yJXHJcbiAgICAgKi9cclxuICAgIGdldFJlc291cmNlczogZnVuY3Rpb24gKGxvY2F0aW9uLCBuYW1lLCB0eXBlKSB7XHJcbiAgICAgICAgLyrlvZPoh6rliqjmm7/mjaLlvIDlkK/ml7bmm7/mjaJMYXl1aSovXHJcbiAgICAgICAgaWYgKHh1cnVpLmNvbmZpZy5nbG9iYWxpemUuYXV0b1JlcExheXVpKSB4dXJ1aS5sYXl1aS5mbi5yZXBsYWNlTGF5dWkoKTtcclxuICAgICAgICAvKuWKoOi9veivreiogOWMhSovXHJcbiAgICAgICAgbG9jYXRpb24gPSBsb2NhdGlvbiB8fCBcImNvbW1vblwiO1xyXG4gICAgICAgIG5hbWUgPSBuYW1lIHx8IFwiY29tbW9uXCI7XHJcbiAgICAgICAgaWYgKHh1cnVpLmNvbmZpZy5nbG9iYWxpemUudXNlVXJsKSB4dXJ1aS5nbG9iYWwudXJsRnVuYyhsb2NhdGlvbiwgbmFtZSwgdHlwZSk7XHJcbiAgICAgICAgZWxzZSB4dXJ1aS5nbG9iYWwuYmFzZUZ1bmMobG9jYXRpb24sIG5hbWUsIHR5cGUpO1xyXG4gICAgICAgIC8q5b2T5aSa6K+t6KiA5byA5ZCv5pe257uZbGlk6LWL5YC877yI6YGN5Y6GbGlk77yM5YWI5LuObHbph4zpnaLmib7vvIznhLblkI7lho3ku47oh6rlrprkuYnlj5jph4/ph4zpnaLmib7vvIzmnIDlkI7ku45jb21tb27ph4zpnaLmib7vvIzlpoLmnpzkuI3lrZjlnKjliJnkuI3otYvlgLzvvIzlrZjlnKjliJnotYvlgLzjgILlpoLmnpxsaWTmmK/mi7zmjqXnmoTor53vvIzliJnlj6ropoHku7vkuIBrZXnkuI3lrZjlnKjlsLHkuI3otYvlgLzvvIkqL1xyXG4gICAgICAgIGlmICh4dXJ1aS5jb25maWcuZ2xvYmFsaXplLmFjdGl2ZSkge1xyXG4gICAgICAgICAgICBhZGRFdmVudExpc3RlbmVyKCdsb2FkJywgZnVuY3Rpb24gKCkge1xyXG4gICAgICAgICAgICAgICAgZ2xvYmFsaXplLnRyYW5zbGF0ZSgpO1xyXG4gICAgICAgICAgICB9KTtcclxuICAgICAgICB9XHJcbiAgICB9LFxyXG5cclxuICAgIC8qKlxyXG4gICAgICog5LuF5Yqg6L296K+t6KiA5YyFXHJcbiAgICAgKiBAcGFyYW0ge1N0cmluZ30gbG9jYXRpb24g6K+t6KiA5YyF6Lev5b6EXHJcbiAgICAgKiBAcGFyYW0ge1N0cmluZ30gbmFtZSDoh6rlrprkuYnlj5jph4/vvIjnlZnnqbrliJnkuLpjb21tb27vvIlcclxuICAgICAqIEBwYXJhbSB7U3RyaW5nfSB0eXBlIOWmguaenOiHquWumuS5ieWPmOmHj+W3suWtmOWcqOaXtueahOaTjeS9nO+8iOeVmeepuuS4uuabv+aNou+8jG1lcmdl5Li65ZCI5bm277yJXHJcbiAgICAgKi9cclxuICAgIGdldFJlc291cmNlc09ubHk6IGZ1bmN0aW9uIChsb2NhdGlvbiwgbmFtZSwgdHlwZSkge1xyXG4gICAgICAgIGxvY2F0aW9uID0gbG9jYXRpb24gfHwgXCJjb21tb25cIjtcclxuICAgICAgICBuYW1lID0gbmFtZSB8fCBcImNvbW1vblwiO1xyXG4gICAgICAgIGlmICh4dXJ1aS5jb25maWcuZ2xvYmFsaXplLnVzZVVybCkgeHVydWkuZ2xvYmFsLnVybEZ1bmMobG9jYXRpb24sIG5hbWUsIHR5cGUpO1xyXG4gICAgICAgIGVsc2UgeHVydWkuZ2xvYmFsLmJhc2VGdW5jKGxvY2F0aW9uLCBuYW1lLCB0eXBlKTtcclxuICAgIH0sXHJcblxyXG4gICAgLyoqXHJcbiAgICAgKiDnlKjlt7Lojrflj5bnmoTor63oqIDljIXov5vooYznv7vor5FcclxuICAgICAqL1xyXG4gICAgdHJhbnNsYXRlOiBmdW5jdGlvbiAoKSB7XHJcbiAgICAgICAgdmFyIGxpZEFsbCA9IGRvY3VtZW50LnF1ZXJ5U2VsZWN0b3JBbGwoXCJbbGlkXVwiKTtcclxuICAgICAgICBpZiAodHlwZW9mIGxpZEFsbC5mb3JFYWNoICE9PSAnZnVuY3Rpb24nKSB7XHJcbiAgICAgICAgICAgIGxpZEFsbC5mb3JFYWNoID0gZnVuY3Rpb24gKGNhbGxiYWNrKSB7XHJcbiAgICAgICAgICAgICAgICBmb3IgKHZhciBpID0gMDsgaSA8IGxpZEFsbC5sZW5ndGg7IGkrKykge1xyXG4gICAgICAgICAgICAgICAgICAgIGNhbGxiYWNrKGxpZEFsbFtpXSk7XHJcbiAgICAgICAgICAgICAgICB9XHJcbiAgICAgICAgICAgIH1cclxuICAgICAgICB9XHJcbiAgICAgICAgbGlkQWxsLmZvckVhY2goZnVuY3Rpb24gKGNoaWxkKSB7XHJcbiAgICAgICAgICAgIHZhciBsdmFsdWUgPSBcIlwiO1xyXG4gICAgICAgICAgICB2YXIgbGlkU3RyID0gY2hpbGQuZ2V0QXR0cmlidXRlKFwibGlkXCIpLnNwbGl0KCcrJyk7XHJcbiAgICAgICAgICAgIHZhciBlbXB0eSA9IHRydWU7XHJcbiAgICAgICAgICAgIGZvciAodmFyIGkgPSAwOyBpIDwgbGlkU3RyLmxlbmd0aDsgaSsrKSB7XHJcbiAgICAgICAgICAgICAgICBlbXB0eSA9IHRydWU7XHJcbiAgICAgICAgICAgICAgICBpZiAoZW1wdHkpIHtcclxuICAgICAgICAgICAgICAgICAgICBpZiAoeHVydWkudmFsdWUuZ2xvYmFsW1wibHZcIl1bbGlkU3RyW2ldXSkge1xyXG4gICAgICAgICAgICAgICAgICAgICAgICBsdmFsdWUgPSBsdmFsdWUgKyB4dXJ1aS52YWx1ZS5nbG9iYWxbXCJsdlwiXVtsaWRTdHJbaV1dO1xyXG4gICAgICAgICAgICAgICAgICAgICAgICBlbXB0eSA9IGZhbHNlO1xyXG4gICAgICAgICAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgICAgIGlmIChlbXB0eSkge1xyXG4gICAgICAgICAgICAgICAgICAgIGZvciAobGV0IGtleSBpbiB4dXJ1aS52YWx1ZS5nbG9iYWwpIHtcclxuICAgICAgICAgICAgICAgICAgICAgICAgaWYgKGtleSAhPT0gXCJsdlwiICYmIGtleSAhPT0gXCJjb21tb25cIikge1xyXG4gICAgICAgICAgICAgICAgICAgICAgICAgICAgdmFyIGxpZEtleSA9IGxpZFN0cltpXS5yZXBsYWNlKGtleSArIFwiX1wiLCBcIlwiKTtcclxuICAgICAgICAgICAgICAgICAgICAgICAgICAgIGlmIChsaWRTdHJbaV0uc3BsaXQoJ18nKVswXSA9PT0ga2V5ICYmIHh1cnVpLnZhbHVlLmdsb2JhbFtrZXldW2xpZEtleV0pIHtcclxuICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBsdmFsdWUgPSBsdmFsdWUgKyB4dXJ1aS52YWx1ZS5nbG9iYWxba2V5XVtsaWRLZXldO1xyXG4gICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIGVtcHR5ID0gZmFsc2U7XHJcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgYnJlYWs7XHJcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICB9XHJcbiAgICAgICAgICAgICAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgICAgICAgICB9XHJcbiAgICAgICAgICAgICAgICB9XHJcbiAgICAgICAgICAgICAgICBpZiAoZW1wdHkpIHtcclxuICAgICAgICAgICAgICAgICAgICBpZiAoeHVydWkudmFsdWUuZ2xvYmFsW1wiY29tbW9uXCJdW2xpZFN0cltpXV0pIHtcclxuICAgICAgICAgICAgICAgICAgICAgICAgbHZhbHVlID0gbHZhbHVlICsgeHVydWkudmFsdWUuZ2xvYmFsW1wiY29tbW9uXCJdW2xpZFN0cltpXV07XHJcbiAgICAgICAgICAgICAgICAgICAgICAgIGVtcHR5ID0gZmFsc2U7XHJcbiAgICAgICAgICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICAgICAgaWYgKGVtcHR5KSBicmVhaztcclxuICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICBpZiAoIWVtcHR5KSB4dXJ1aS5nbG9iYWwubGlkRnVuYyhjaGlsZC5nZXRBdHRyaWJ1dGUoXCJsaWRcIiksIGx2YWx1ZSk7XHJcbiAgICAgICAgfSk7XHJcbiAgICB9LFxyXG5cclxuICAgIC8qKlxyXG4gICAgICog5L+u5pS55qCH6aKY77yIaGVhZOS4reeahHRpdGxl77yJXHJcbiAgICAgKiBAcGFyYW0ge1N0cmluZ30gdmFsdWUg5qCH6aKY5ZCNXHJcbiAgICAgKi9cclxuICAgIHNldFRpdGxlOiBmdW5jdGlvbiAodmFsdWUpIHtcclxuICAgICAgICBkb2N1bWVudC5xdWVyeVNlbGVjdG9yKCdoZWFkID4gdGl0bGUnKS5pbm5lckhUTUwgPSB2YWx1ZTtcclxuICAgIH0sXHJcblxyXG4gICAgLyoq5YaF6YOo5pON5L2c77yI6K+35Yu/5Zyo5aSW6YOo5pON5L2c77yJICovXHJcbiAgICBiYXNlRnVuYzogZnVuY3Rpb24gKGxvY2F0aW9uLCBuYW1lLCB0eXBlLCBjYWxsYmFjaykge1xyXG4gICAgICAgIGNhbGxiYWNrID0gY2FsbGJhY2sgfHwgZnVuY3Rpb24gKCkgeyB9O1xyXG4gICAgICAgIHR5cGUgPSB0eXBlIHx8IFwiXCI7XHJcbiAgICAgICAgdmFyIGJhc2UgPSB4dXJ1aS5jb25maWcuZ2xvYmFsaXplLmJhc2UgfHwgXCIuLi8uLi9cIlxyXG4gICAgICAgIHZhciB1cmwgPSBiYXNlICsgbG9jYXRpb247XHJcbiAgICAgICAgdmFyIGN1bHR1cmUgPSB4dXJ1aS5jb25maWcuZ2xvYmFsaXplLmN1bHR1cmUuc3BsaXQoLy18Xy8pWzBdO1xyXG4gICAgICAgIHN3aXRjaCAoY3VsdHVyZSkge1xyXG4gICAgICAgICAgICBjYXNlIFwiZW5cIjpcclxuICAgICAgICAgICAgY2FzZSBcInZpXCI6XHJcbiAgICAgICAgICAgIGNhc2UgXCJ6aFwiOlxyXG4gICAgICAgICAgICAgICAgYnJlYWs7XHJcbiAgICAgICAgICAgIGRlZmF1bHQ6XHJcbiAgICAgICAgICAgICAgICBjdWx0dXJlID0gXCJ6aFwiO1xyXG4gICAgICAgICAgICAgICAgYnJlYWs7XHJcbiAgICAgICAgfVxyXG4gICAgICAgIHZhciBmaXggPSBbXCItXCIgKyBjdWx0dXJlICsgXCIuanNvblwiLCBcIi5qc29uXCIsIFwiLXpoLmpzb25cIl07XHJcbiAgICAgICAgZm9yICh2YXIgaSA9IDA7IGkgPCBmaXgubGVuZ3RoOyBpKyspIHtcclxuICAgICAgICAgICAgdmFyIGdldFVybCA9IHVybCArIGZpeFtpXTtcclxuICAgICAgICAgICAgdmFyIG91dCA9IGZhbHNlO1xyXG4gICAgICAgICAgICBmbi5nZXQoZ2V0VXJsLCB4dXJ1aS5jb25maWcuZ2xvYmFsaXplLmFzeW5jLCBmdW5jdGlvbiAoZGF0YSkge1xyXG4gICAgICAgICAgICAgICAgaWYgKHR5cGUgPT09IFwibWVyZ2VcIiAmJiB4dXJ1aS52YWx1ZS5nbG9iYWxbbmFtZV0pIG1lcmdlKHh1cnVpLnZhbHVlLmdsb2JhbFtuYW1lXSwgZGF0YSk7XHJcbiAgICAgICAgICAgICAgICBlbHNlIHh1cnVpLnZhbHVlLmdsb2JhbFtuYW1lXSA9IGRhdGE7XHJcbiAgICAgICAgICAgICAgICBvdXQgPSB0cnVlO1xyXG4gICAgICAgICAgICAgICAgY2FsbGJhY2soZGF0YSk7XHJcbiAgICAgICAgICAgIH0pO1xyXG4gICAgICAgICAgICBpZiAob3V0KSBicmVhaztcclxuICAgICAgICB9XHJcbiAgICB9LFxyXG4gICAgdXJsRnVuYzogZnVuY3Rpb24gKGxvY2F0aW9uLCBuYW1lLCB0eXBlLCBjYWxsYmFjaykge1xyXG4gICAgICAgIGNhbGxiYWNrID0gY2FsbGJhY2sgfHwgZnVuY3Rpb24gKCkgeyB9O1xyXG4gICAgICAgIHR5cGUgPSB0eXBlIHx8IFwiXCI7XHJcbiAgICAgICAgdmFyIGN1bHR1cmUgPSB4dXJ1aS5jb25maWcuZ2xvYmFsaXplLmN1bHR1cmUuc3BsaXQoLy18Xy8pWzBdO1xyXG4gICAgICAgIHN3aXRjaCAoY3VsdHVyZSkge1xyXG4gICAgICAgICAgICBjYXNlIFwiZW5cIjpcclxuICAgICAgICAgICAgY2FzZSBcInZpXCI6XHJcbiAgICAgICAgICAgIGNhc2UgXCJ6aFwiOlxyXG4gICAgICAgICAgICAgICAgYnJlYWs7XHJcbiAgICAgICAgICAgIGRlZmF1bHQ6XHJcbiAgICAgICAgICAgICAgICBjdWx0dXJlID0gXCJ6aFwiO1xyXG4gICAgICAgICAgICAgICAgYnJlYWs7XHJcbiAgICAgICAgfVxyXG4gICAgICAgIGZuLnBvc3QoeHVydWkuY29uZmlnLmdsb2JhbGl6ZS51cmwsIHsgY3VsdHVyZTogY3VsdHVyZSwgbG9jYXRpb246IGxvY2F0aW9uIH0sIHh1cnVpLmNvbmZpZy5nbG9iYWxpemUuYXN5bmMsIGZ1bmN0aW9uIChkYXRhKSB7XHJcbiAgICAgICAgICAgIGlmICh0eXBlID09PSBcIm1lcmdlXCIgJiYgeHVydWkudmFsdWUuZ2xvYmFsW25hbWVdKSBtZXJnZSh4dXJ1aS52YWx1ZS5nbG9iYWxbbmFtZV0sIGRhdGEpO1xyXG4gICAgICAgICAgICBlbHNlIHh1cnVpLnZhbHVlLmdsb2JhbFtuYW1lXSA9IGRhdGE7XHJcbiAgICAgICAgICAgIGNhbGxiYWNrKGRhdGEpO1xyXG4gICAgICAgIH0pO1xyXG4gICAgfSxcclxuICAgIGxpZEZ1bmM6IGZ1bmN0aW9uIChsaWQsIGx2YWx1ZSkge1xyXG4gICAgICAgIHZhciBsaWRJdGVtID0gZG9jdW1lbnQucXVlcnlTZWxlY3RvckFsbChcIltsaWQ9J1wiICsgbGlkICsgXCInXVwiKTtcclxuICAgICAgICBpZiAodHlwZW9mIGxpZEl0ZW0uZm9yRWFjaCAhPT0gJ2Z1bmN0aW9uJykge1xyXG4gICAgICAgICAgICBsaWRJdGVtLmZvckVhY2ggPSBmdW5jdGlvbiAoY2FsbGJhY2spIHtcclxuICAgICAgICAgICAgICAgIGZvciAodmFyIGkgPSAwOyBpIDwgbGlkSXRlbS5sZW5ndGg7IGkrKykge1xyXG4gICAgICAgICAgICAgICAgICAgIGNhbGxiYWNrKGxpZEl0ZW1baV0pO1xyXG4gICAgICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgfVxyXG4gICAgICAgIGxpZEl0ZW0uZm9yRWFjaChmdW5jdGlvbiAoY2hpbGQpIHtcclxuICAgICAgICAgICAgaWYgKGNoaWxkLmhhc0F0dHJpYnV0ZShcInR5cGVcIikgJiYgY2hpbGQuZ2V0QXR0cmlidXRlKFwidHlwZVwiKSA9PSBcInJhZGlvXCIpIGNoaWxkLnNldEF0dHJpYnV0ZShcInRpdGxlXCIsIGx2YWx1ZSk7XHJcbiAgICAgICAgICAgIGVsc2UgaWYgKGNoaWxkLnRhZ05hbWUgPT0gXCJJTlBVVFwiKSBjaGlsZC5zZXRBdHRyaWJ1dGUoXCJwbGFjZWhvbGRlclwiLCBsdmFsdWUpO1xyXG4gICAgICAgICAgICBlbHNlIGNoaWxkLmlubmVySFRNTCA9IGx2YWx1ZTtcclxuICAgICAgICB9KTtcclxuICAgIH1cclxuXHJcbn07XHJcblxyXG5mdW5jdGlvbiBzb29uKCkge1xyXG4gICAgeHVydWkuY29uZmlnLmdsb2JhbGl6ZS5hdXRvUmVwTGF5dWkgPSB4dXJ1aS5jb25maWcuZ2xvYmFsaXplLmF1dG9SZXBMYXl1aSAmJiB4dXJ1aS5jb25maWcuZ2xvYmFsaXplLmFjdGl2ZSAmJiB4dXJ1aS5jb25maWcubGF5dWkuYWxsO1xyXG4gICAgeHVydWkuY29uZmlnLmdsb2JhbGl6ZS5jdWx0dXJlID0geHVydWkuY29va2llLmdldCh4dXJ1aS5jb25maWcubG9jYWwuZ2xvYmFsKSB8fCB3aW5kb3cubmF2aWdhdG9yLmxhbmd1YWdlO1xyXG4gICAgaWYgKHh1cnVpLmNvbmZpZy5nbG9iYWxpemUuYWN0aXZlKSB7XHJcbiAgICAgICAgaWYgKCh4dXJ1aS5jb29raWUuZ2V0KHh1cnVpLmNvbmZpZy5sb2NhbC5nbG9iYWwpID09PSB1bmRlZmluZWQgfHwgeHVydWkuY29va2llLmdldCh4dXJ1aS5jb25maWcubG9jYWwuZ2xvYmFsKSA9PT0gbnVsbCB8fCB4dXJ1aS5jb29raWUuZ2V0KHh1cnVpLmNvbmZpZy5sb2NhbC5nbG9iYWwpID09PSBcIlwiKSAmJiB4dXJ1aS5zYXZlLmV4aXN0KHh1cnVpLmNvbmZpZy5sb2NhbC5nbG9iYWwpKSB7XHJcbiAgICAgICAgICAgIC8qeHVydWkuY29va2llLmdldCh4dXJ1aS5jb25maWcubG9jYWwuZ2xvYmFsLCB4dXJ1aS5zYXZlLmdldCh4dXJ1aS5jb25maWcubG9jYWwuZ2xvYmFsKSwgeyBleHBpcmVzOiAxMCwgcGF0aDogJy8nIH0pOyovXHJcbiAgICAgICAgfVxyXG4gICAgfVxyXG59XHJcblxyXG5leHBvcnQgZGVmYXVsdCBnbG9iYWxpemU7XHJcbmV4cG9ydCB7IGdsb2JhbGl6ZSwgc29vbiBhcyBnbG9iYWxpemVTb29uIH07IiwiaW1wb3J0IG1haW4gZnJvbSBcIi4vbWFpbi5qc1wiO1xyXG5cclxuLyoqIOWGhemDqOaWueazlSAqL1xyXG52YXIgZm4gPSB7XHJcblxyXG4gICAgLyoqXHJcbiAgICAgKiDov57ngrnlv6vpgJ/lrprkvY1cclxuICAgICAqIEBwYXJhbSB7U3RyaW5nfSBrZXkg5a6a54K55Luj5Y+3XHJcbiAgICAgKi9cclxuICAgIHJ0OiBmdW5jdGlvbiAoa2V5KSB7XHJcbiAgICAgICAga2V5ID0ga2V5IHx8IFwiXCI7XHJcbiAgICAgICAgc3dpdGNoIChrZXkpIHtcclxuICAgICAgICAgICAgY2FzZSBcInZhbHVlXCI6XHJcbiAgICAgICAgICAgICAgICByZXR1cm4gbWFpbi52YWx1ZTtcclxuICAgICAgICAgICAgICAgIGJyZWFrO1xyXG4gICAgICAgICAgICBjYXNlIFwiY29uZmlnXCI6XHJcbiAgICAgICAgICAgICAgICByZXR1cm4gbWFpbi5jb25maWc7XHJcbiAgICAgICAgICAgICAgICBicmVhaztcclxuICAgICAgICAgICAgY2FzZSBcInN0eWxlXCI6XHJcbiAgICAgICAgICAgICAgICByZXR1cm4gbWFpbi5zdHlsZTtcclxuICAgICAgICAgICAgICAgIGJyZWFrO1xyXG4gICAgICAgICAgICBjYXNlIFwibG9jYWxcIjpcclxuICAgICAgICAgICAgICAgIHJldHVybiBtYWluLnNhdmU7XHJcbiAgICAgICAgICAgICAgICBicmVhaztcclxuICAgICAgICAgICAgZGVmYXVsdDpcclxuICAgICAgICAgICAgICAgIHJldHVybiBtYWluO1xyXG4gICAgICAgIH1cclxuICAgIH0sXHJcblxyXG4gICAgLyoq5L+d5a2Y6Iez5pys5Zyw5a2Y5YKoICovXHJcbiAgICBzYXZlOiBmdW5jdGlvbiAoa2V5KSB7XHJcbiAgICAgICAgeHVydWkuc2F2ZS5jb3Zlcih4dXJ1aS5zYXZlLm5hbWUoKSwgeHVydWkudmFsdWUpO1xyXG4gICAgICAgIHJldHVybiBmbi5ydChrZXkpO1xyXG4gICAgfSxcclxuXHJcbiAgICAvKipQT1NU6K+35rGCICovXHJcbiAgICBwb3N0OiBmdW5jdGlvbiAocG9zdFVybCwgcG9zdERhdGEsIGFzeW5jLCBjYWxsYmFjaykge1xyXG4gICAgICAgIHh1cnVpLmh0dHAuYWpheCh7XHJcbiAgICAgICAgICAgIHR5cGU6IFwiUE9TVFwiLFxyXG4gICAgICAgICAgICBhc3luYzogYXN5bmMsXHJcbiAgICAgICAgICAgIHVybDogcG9zdFVybCxcclxuICAgICAgICAgICAgZGF0YTogcG9zdERhdGEsXHJcbiAgICAgICAgICAgIHN1Y2Nlc3M6IGZ1bmN0aW9uIChkYXRhKSB7XHJcbiAgICAgICAgICAgICAgICBpZiAoZGF0YSAhPT0gXCJcIikgY2FsbGJhY2soSlNPTi5wYXJzZShkYXRhKSk7XHJcbiAgICAgICAgICAgICAgICBlbHNlIGNhbGxiYWNrKGRhdGEpO1xyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgfSk7XHJcbiAgICB9LFxyXG5cclxuICAgIC8qKkdFVOivt+axgiAqL1xyXG4gICAgZ2V0OiBmdW5jdGlvbiAoZ2V0VXJsLCBhc3luYywgY2FsbGJhY2spIHtcclxuICAgICAgICB4dXJ1aS5odHRwLmFqYXgoe1xyXG4gICAgICAgICAgICB0eXBlOiBcIkdFVFwiLFxyXG4gICAgICAgICAgICBhc3luYzogYXN5bmMsXHJcbiAgICAgICAgICAgIHVybDogZ2V0VXJsLFxyXG4gICAgICAgICAgICBzdWNjZXNzOiBmdW5jdGlvbiAoZGF0YSkge1xyXG4gICAgICAgICAgICAgICAgaWYgKGRhdGEgIT09IFwiXCIpIGNhbGxiYWNrKEpTT04ucGFyc2UoZGF0YSkpO1xyXG4gICAgICAgICAgICAgICAgZWxzZSBjYWxsYmFjayhkYXRhKTtcclxuICAgICAgICAgICAgfVxyXG4gICAgICAgIH0pO1xyXG4gICAgfSxcclxuXHJcbiAgICAvKirliqDovb1KU+aWh+S7tiAqL1xyXG4gICAgbG9hZDogZnVuY3Rpb24gKHVybCwgY2FsbGJhY2spIHtcclxuICAgICAgICB2YXIgc2NyaXB0ID0gZG9jdW1lbnQuY3JlYXRlRWxlbWVudCgnc2NyaXB0Jyk7XHJcbiAgICAgICAgdmFyIGZuID0gY2FsbGJhY2sgfHwgZnVuY3Rpb24gKCkgeyB9O1xyXG4gICAgICAgIHNjcmlwdC50eXBlID0gJ3RleHQvamF2YXNjcmlwdCc7XHJcbiAgICAgICAgLypJRSovXHJcbiAgICAgICAgaWYgKHNjcmlwdC5yZWFkeVN0YXRlKSB7XHJcbiAgICAgICAgICAgIHNjcmlwdC5vbnJlYWR5c3RhdGVjaGFuZ2UgPSBmdW5jdGlvbiAoKSB7XHJcbiAgICAgICAgICAgICAgICBpZiAoc2NyaXB0LnJlYWR5U3RhdGUgPT0gJ2xvYWRlZCcgfHwgc2NyaXB0LnJlYWR5U3RhdGUgPT0gJ2NvbXBsZXRlJykge1xyXG4gICAgICAgICAgICAgICAgICAgIHNjcmlwdC5vbnJlYWR5c3RhdGVjaGFuZ2UgPSBudWxsO1xyXG4gICAgICAgICAgICAgICAgICAgIGZuKCk7XHJcbiAgICAgICAgICAgICAgICB9XHJcbiAgICAgICAgICAgIH07XHJcbiAgICAgICAgfVxyXG4gICAgICAgIC8q5YW25LuW5rWP6KeI5ZmoKi9cclxuICAgICAgICBlbHNlIHtcclxuICAgICAgICAgICAgc2NyaXB0Lm9ubG9hZCA9IGZ1bmN0aW9uICgpIHtcclxuICAgICAgICAgICAgICAgIGZuKCk7XHJcbiAgICAgICAgICAgIH07XHJcbiAgICAgICAgfVxyXG4gICAgICAgIHNjcmlwdC5zcmMgPSB1cmw7XHJcbiAgICAgICAgZG9jdW1lbnQuZ2V0RWxlbWVudHNCeVRhZ05hbWUoJ2hlYWQnKVswXS5hcHBlbmRDaGlsZChzY3JpcHQpO1xyXG4gICAgfSxcclxuXHJcbiAgICAvKipcclxuICAgICAqIHJlbmRlclxyXG4gICAgICog5Y+W5YC877yaPCU9IHZhcmlhYmxlICU+XHJcbiAgICAgKiDooajovr7lvI/vvJo8JSBpZiB7fSAlPlxyXG4gICAgICog5L6L5a2Q77yaXHJcbiAgICAgKiAgPGRpdj5cclxuICAgICAqICAgIDxkaXYgY2xhc3M9XCJ3ZXVpLW1hc2tcIj48L2Rpdj5cclxuICAgICAqICAgIDxkaXYgY2xhc3M9XCJ3ZXVpLWRpYWxvZ1wiPlxyXG4gICAgICogICAgPCUgaWYodHlwZW9mIHRpdGxlID09PSAnc3RyaW5nJyl7ICU+XHJcbiAgICAgKiAgICAgICAgICAgPGRpdiBjbGFzcz1cIndldWktZGlhbG9nX19oZFwiPjxzdHJvbmcgY2xhc3M9XCJ3ZXVpLWRpYWxvZ19fdGl0bGVcIj48JT10aXRsZSU+PC9zdHJvbmc+PC9kaXY+XHJcbiAgICAgKiAgICA8JSB9ICU+XHJcbiAgICAgKiAgICA8ZGl2IGNsYXNzPVwid2V1aS1kaWFsb2dfX2JkXCI+PCU9Y29udGVudCU+PC9kaXY+XHJcbiAgICAgKiAgICA8ZGl2IGNsYXNzPVwid2V1aS1kaWFsb2dfX2Z0XCI+XHJcbiAgICAgKiAgICA8JSBmb3IodmFyIGkgPSAwOyBpIDwgYnV0dG9ucy5sZW5ndGg7IGkrKyl7ICU+XHJcbiAgICAgKiAgICAgICAgPGEgaHJlZj1cImphdmFzY3JpcHQ6O1wiIGNsYXNzPVwid2V1aS1kaWFsb2dfX2J0biB3ZXVpLWRpYWxvZ19fYnRuXzwlPWJ1dHRvbnNbaV1bJ3R5cGUnXSU+XCI+PCU9YnV0dG9uc1tpXVsnbGFiZWwnXSU+PC9hPlxyXG4gICAgICogICAgPCUgfSAlPlxyXG4gICAgICogICAgPC9kaXY+XHJcbiAgICAgKiAgICA8L2Rpdj5cclxuICAgICAqICA8L2Rpdj5cclxuICAgICAqIEEgdmVyeSBzaW1wbGUgdGVtcGxhdGUgZW5naW5lXHJcbiAgICAgKiBAcGFyYW0ge1N0cmluZ30gdHBsXHJcbiAgICAgKiBAcGFyYW0ge09iamVjdD19IGRhdGFcclxuICAgICAqIEByZXR1cm5zIHtTdHJpbmd9XHJcbiAgICAgKi9cclxuICAgIHJlbmRlcjogZnVuY3Rpb24gKHRwbCwgZGF0YSkge1xyXG4gICAgICAgIGNvbnN0IGNvZGUgPSAndmFyIHA9W107d2l0aCh0aGlzKXtwLnB1c2goXFwnJyArXHJcbiAgICAgICAgICAgIHRwbFxyXG4gICAgICAgICAgICAgICAgLnJlcGxhY2UoL1tcXHJcXHRcXG5dL2csICcgJylcclxuICAgICAgICAgICAgICAgIC5zcGxpdCgnPCUnKS5qb2luKCdcXHQnKVxyXG4gICAgICAgICAgICAgICAgLnJlcGxhY2UoLygoXnwlPilbXlxcdF0qKScvZywgJyQxXFxyJylcclxuICAgICAgICAgICAgICAgIC5yZXBsYWNlKC9cXHQ9KC4qPyklPi9nLCAnXFwnLCQxLFxcJycpXHJcbiAgICAgICAgICAgICAgICAuc3BsaXQoJ1xcdCcpLmpvaW4oJ1xcJyk7JylcclxuICAgICAgICAgICAgICAgIC5zcGxpdCgnJT4nKS5qb2luKCdwLnB1c2goXFwnJylcclxuICAgICAgICAgICAgICAgIC5zcGxpdCgnXFxyJykuam9pbignXFxcXFxcJycpXHJcbiAgICAgICAgICAgICsgJ1xcJyk7fXJldHVybiBwLmpvaW4oXFwnXFwnKTsnO1xyXG4gICAgICAgIHJldHVybiBuZXcgRnVuY3Rpb24oY29kZSkuYXBwbHkoZGF0YSk7XHJcbiAgICB9LFxyXG5cclxuICAgIGlzRE9NOiBmdW5jdGlvbiAob2JqKSB7XHJcbiAgICAgICAgaWYgKHR5cGVvZiBIVE1MRWxlbWVudCA9PT0gJ29iamVjdCcpIHtcclxuICAgICAgICAgICAgcmV0dXJuIG9iaiBpbnN0YW5jZW9mIEhUTUxFbGVtZW50O1xyXG4gICAgICAgIH1cclxuICAgICAgICBlbHNlIHtcclxuICAgICAgICAgICAgcmV0dXJuIG9iaiAmJiB0eXBlb2Ygb2JqID09PSAnb2JqZWN0JyAmJiBvYmoubm9kZVR5cGUgPT09IDEgJiYgdHlwZW9mIG9iai5ub2RlTmFtZSA9PT0gJ3N0cmluZyc7XHJcbiAgICAgICAgfVxyXG4gICAgfVxyXG59XHJcblxyXG5leHBvcnQgZGVmYXVsdCBmbjsiLCJpbXBvcnQgY29uZmlnIGZyb20gXCIuL2NvbmZpZy5qc1wiO1xyXG5pbXBvcnQgeyBnbG9iYWxpemUsIGdsb2JhbGl6ZVNvb24gfSBmcm9tIFwiLi9nbG9iYWxpemUuanNcIjtcclxuXHJcbnZhciBtYWluID0ge1xyXG4gICAgLyoqIOeJiOacrO+8iOS9v+eUqOWJjeivt+ehruiupOeJiOacrO+8iSAqL1xyXG4gICAgdjogXCIyLjIuNFwiLFxyXG4gICAgLyoqIOS7o+aVsCAqL1xyXG4gICAgZzogXCIyXCIsXHJcbiAgICAvKiog5YmN57yAICovXHJcbiAgICBuYW1lOiBcIlwiLFxyXG5cclxuICAgIC8qKiDlhajlsYDlj5jph4/lkoznvJPlrZggKi9cclxuICAgIHZhbHVlczoge1xyXG4gICAgICAgIC8qKiDlhajlsYDorr7nva7lgLwgKi9cclxuICAgICAgICBjb25maWc6IHt9LFxyXG4gICAgICAgIC8qKiBBcHDkuqTkupLmoIforrAgKi9cclxuICAgICAgICBhcHA6IHtcclxuICAgICAgICAgICAgc2NoZW1lOiBcInNkZW1vXCIsXHJcbiAgICAgICAgICAgIGlzQXBwOiBmYWxzZSxcclxuICAgICAgICAgICAgbWFjOiBcIlwiLFxyXG4gICAgICAgICAgICB2ZXJOYW1lOiBcIlwiLFxyXG4gICAgICAgICAgICB2ZXJDb2RlOiAwXHJcbiAgICAgICAgfSxcclxuICAgICAgICBzdHlsZToge1xyXG4gICAgICAgICAgICBjb2xvcjoge1xyXG4gICAgICAgICAgICAgICAgdGFnOiBcIiMwMDk2ODhcIixcclxuICAgICAgICAgICAgICAgIGxyOiBcIiMzOTNENDlcIixcclxuICAgICAgICAgICAgICAgIGhlYWQ6IFwiIzIzMjYyRVwiXHJcbiAgICAgICAgICAgIH1cclxuICAgICAgICB9LFxyXG4gICAgICAgIHVybDoge1xyXG4gICAgICAgICAgICBhcmVhOiBcIlwiLFxyXG4gICAgICAgICAgICBjb250cm9sbGVyOiBcIlwiLFxyXG4gICAgICAgICAgICBhY3Rpb246IFwiXCJcclxuICAgICAgICB9LFxyXG4gICAgICAgIGdsb2JhbGl6ZTogZ2xvYmFsaXplLnZhbHVlcyxcclxuICAgICAgICBnbG9iYWw6IGdsb2JhbGl6ZS52YWx1ZXNcclxuICAgIH0sXHJcblxyXG4gICAgLyoqIOm7mOiupOWFqOWxgOiuvue9riAqL1xyXG4gICAgY29uZmlnOiBjb25maWcsXHJcblxyXG4gICAgLyoqIOWkmuivreiogOaooeWdlyAqL1xyXG4gICAgZ2xvYmFsaXplOiBnbG9iYWxpemUsXHJcblxyXG4gICAgLyoqIOWkmuivreiogOaooeWdl++8iOWFvOWuueaAp++8iSAqL1xyXG4gICAgZ2xvYmFsOiBnbG9iYWxpemUsXHJcblxyXG4gICAgLyoqXHJcbiAgICAgKiDliqDovb3ln5/lhoVKU1xyXG4gICAgICogQHBhcmFtIHtzdHJpbmd9IGxvY2F0aW9uIFNjcmlwdHPnm67lvZXkuIvnmoRKU+i3r+W+hO+8iOS4jemcgOimgeWKoOaJqeWxleWQje+8iVxyXG4gICAgICogQHBhcmFtIHtzdHJpbmd9IGFwcGVuZCDpop3lpJblkI7nvIBcclxuICAgICAqL1xyXG4gICAgbG9hZFNKUzogZnVuY3Rpb24gKGxvY2F0aW9uLCBhcHBlbmQpIHtcclxuICAgICAgICBhcHBlbmQgPSBhcHBlbmQgfHwgJyc7XHJcbiAgICAgICAgdmFyIHNjcmlwdCA9IGRvY3VtZW50LmNyZWF0ZUVsZW1lbnQoXCJzY3JpcHRcIik7XHJcbiAgICAgICAgc2NyaXB0LnNyYyA9IHh1cnVpLmNvbmZpZy5sb2NhdGlvbiArIFwiL1NjcmlwdHMvXCIgKyBsb2NhdGlvbiArIFwiLmpzXCIgKyBhcHBlbmQ7XHJcbiAgICAgICAgZG9jdW1lbnQucXVlcnlTZWxlY3RvcihcImhlYWRcIikuYXBwZW5kKHNjcmlwdCk7XHJcbiAgICB9LFxyXG5cclxuICAgIC8qKlxyXG4gICAgICog5Yqg6L295Z+f5YaFQ1NTXHJcbiAgICAgKiBAcGFyYW0ge3N0cmluZ30gbG9jYXRpb24gQ29udGVudOebruW9leS4i+eahENTU+i3r+W+hO+8iOS4jemcgOimgeWKoOaJqeWxleWQje+8iVxyXG4gICAgICogQHBhcmFtIHtzdHJpbmd9IGFwcGVuZCDpop3lpJblkI7nvIBcclxuICAgICAqL1xyXG4gICAgbG9hZFNDU1M6IGZ1bmN0aW9uIChsb2NhdGlvbiwgYXBwZW5kKSB7XHJcbiAgICAgICAgYXBwZW5kID0gYXBwZW5kIHx8ICcnO1xyXG4gICAgICAgIHZhciBzdHlsZSA9IGRvY3VtZW50LmNyZWF0ZUVsZW1lbnQoXCJsaW5rXCIpO1xyXG4gICAgICAgIHN0eWxlLmhyZWYgPSB4dXJ1aS5jb25maWcubG9jYXRpb24gKyBcIi9Db250ZW50L1wiICsgbG9jYXRpb24gKyBcIi5jc3NcIiArIGFwcGVuZDtcclxuICAgICAgICBzdHlsZS5yZWwgPSBcInN0eWxlc2hlZXRcIjtcclxuICAgICAgICBkb2N1bWVudC5xdWVyeVNlbGVjdG9yKFwiaGVhZFwiKS5hcHBlbmQoc3R5bGUpO1xyXG4gICAgfSxcclxuXHJcbiAgICAvKipcclxuICAgICAqIOWKoOi9vUpTXHJcbiAgICAgKiBAcGFyYW0ge3N0cmluZ30gdXJsIEpT5a6M5pW0VVJMXHJcbiAgICAgKiBAcGFyYW0ge3N0cmluZ30gYXBwZW5kIOmineWkluWQjue8gFxyXG4gICAgICovXHJcbiAgICBsb2FkSlM6IGZ1bmN0aW9uICh1cmwsIGFwcGVuZCkge1xyXG4gICAgICAgIGFwcGVuZCA9IGFwcGVuZCB8fCAnJztcclxuICAgICAgICB2YXIgc2NyaXB0ID0gZG9jdW1lbnQuY3JlYXRlRWxlbWVudChcInNjcmlwdFwiKTtcclxuICAgICAgICBzY3JpcHQuc3JjID0gdXJsICsgYXBwZW5kO1xyXG4gICAgICAgIGRvY3VtZW50LnF1ZXJ5U2VsZWN0b3IoXCJoZWFkXCIpLmFwcGVuZChzY3JpcHQpO1xyXG4gICAgfSxcclxuXHJcbiAgICAvKipcclxuICAgICAqIOWKoOi9vUNTU1xyXG4gICAgICogQHBhcmFtIHtzdHJpbmd9IHVybCBDU1PlrozmlbRVUkxcclxuICAgICAqIEBwYXJhbSB7c3RyaW5nfSBhcHBlbmQg6aKd5aSW5ZCO57yAXHJcbiAgICAgKi9cclxuICAgIGxvYWRDU1M6IGZ1bmN0aW9uICh1cmwsIGFwcGVuZCkge1xyXG4gICAgICAgIGFwcGVuZCA9IGFwcGVuZCB8fCAnJztcclxuICAgICAgICB2YXIgc3R5bGUgPSBkb2N1bWVudC5jcmVhdGVFbGVtZW50KFwibGlua1wiKTtcclxuICAgICAgICBzdHlsZS5ocmVmID0gdXJsICsgYXBwZW5kO1xyXG4gICAgICAgIHN0eWxlLnJlbCA9IFwic3R5bGVzaGVldFwiO1xyXG4gICAgICAgIGRvY3VtZW50LnF1ZXJ5U2VsZWN0b3IoXCJoZWFkXCIpLmFwcGVuZChzdHlsZSk7XHJcbiAgICB9XHJcbn07XHJcblxyXG5tYWluLnZhbHVlID0gbWFpbi52YWx1ZXM7XHJcblxyXG5mdW5jdGlvbiBpbml0KGZ1bnNTb29uLCBmdW5zQWZ0ZXIsIGFwcCkge1xyXG4gICAgLyoqIOWfuuehgOWPmOmHj+WIneWni+WMliAqL1xyXG4gICAgeHVydWkuY29uZmlnLmxvY2FsLmFsbCA9IHh1cnVpLm5hbWUgKyBcIi5cIiArIHh1cnVpLmNvbmZpZy5sb2NhbC5hbGw7XHJcbiAgICB4dXJ1aS5jb25maWcubG9jYWwuc3R5bGUgPSB4dXJ1aS5uYW1lICsgXCIuXCIgKyB4dXJ1aS5jb25maWcubG9jYWwuc3R5bGU7XHJcbiAgICB4dXJ1aS5jb25maWcubG9jYWwuZ2xvYmFsID0geHVydWkubmFtZSArIFwiLlwiICsgeHVydWkuY29uZmlnLmxvY2FsLmdsb2JhbDtcclxuICAgIHh1cnVpLmNvbmZpZy5jb29raWUuZ2xvYmFsID0geHVydWkubmFtZSArIFwiLlwiICsgeHVydWkuY29uZmlnLmNvb2tpZS5nbG9iYWw7XHJcbiAgICAvKiog5Y6f5Z6L5omp5bGV5Yid5aeL5YyWICovXHJcbiAgICB4dXJ1aS5jb25maWcucHJvdG90eXBlLnN0cmluZyA9IHh1cnVpLmNvbmZpZy5wcm90b3R5cGUuYWN0aXZlICYmICh4dXJ1aS5jb25maWcucHJvdG90eXBlLnN0cmluZyB8fCB4dXJ1aS5jb25maWcucHJvdG90eXBlLmFsbCk7XHJcbiAgICB4dXJ1aS5jb25maWcucHJvdG90eXBlLmNvbnZlcnQgPSB4dXJ1aS5jb25maWcucHJvdG90eXBlLmFjdGl2ZSAmJiAoeHVydWkuY29uZmlnLnByb3RvdHlwZS5jb252ZXJ0IHx8IHh1cnVpLmNvbmZpZy5wcm90b3R5cGUuYWxsKTtcclxuICAgIGlmICh4dXJ1aS5jb25maWcucHJvdG90eXBlLnN0cmluZykge1xyXG4gICAgICAgIC8qKlxyXG4gICAgICAgICAqIOaXpeacn+WSjOaXtumXtOagvOW8j+WMllxyXG4gICAgICAgICAqIEBwYXJhbSB7U3RyaW5nfSBmb3JtYXQg5pel5pyf5qC85byP77yM5L6L5aaC4oCceXl5eS1tbS1kZOKAnVxyXG4gICAgICAgICAqL1xyXG4gICAgICAgIFN0cmluZy5wcm90b3R5cGUuc2xkYXRldGltZSA9IGZ1bmN0aW9uIChmb3JtYXQpIHtcclxuICAgICAgICAgICAgcmV0dXJuIHh1cnVpLmZvcm1hdC5kYXRldGltZSh0aGlzLnRvU3RyaW5nKCksIGZvcm1hdCk7XHJcbiAgICAgICAgfVxyXG4gICAgICAgIC8qKlxyXG4gICAgICAgICAqIOinhOWumumVv+W6pu+8jOS4jei2s+WKoOWJjee8gFxyXG4gICAgICAgICAqIEBwYXJhbSB7TnVtYmVyfSBsZW4g5oC76ZW/5bqmXHJcbiAgICAgICAgICogQHBhcmFtIHtTdHJpbmd9IGZpeCDooaXotrPlrZfnrKZcclxuICAgICAgICAgKi9cclxuICAgICAgICBTdHJpbmcucHJvdG90eXBlLnNscHJlZml4ID0gZnVuY3Rpb24gKGxlbiwgZml4KSB7XHJcbiAgICAgICAgICAgIHJldHVybiB4dXJ1aS5mb3JtYXQuc3VmZml4KHRoaXMudG9TdHJpbmcoKSwgbGVuLCBmaXgpO1xyXG4gICAgICAgIH1cclxuICAgICAgICAvKipcclxuICAgICAgICAgKiDop4Tlrprplb/luqbvvIzkuI3otrPliqDlkI7nvIBcclxuICAgICAgICAgKiBAcGFyYW0ge051bWJlcn0gbGVuIOaAu+mVv+W6plxyXG4gICAgICAgICAqIEBwYXJhbSB7U3RyaW5nfSBmaXgg6KGl6Laz5a2X56ymXHJcbiAgICAgICAgICovXHJcbiAgICAgICAgU3RyaW5nLnByb3RvdHlwZS5zbHN1ZmZpeCA9IGZ1bmN0aW9uIChsZW4sIGZpeCkge1xyXG4gICAgICAgICAgICByZXR1cm4geHVydWkuZm9ybWF0LnN1ZmZpeCh0aGlzLnRvU3RyaW5nKCksIGxlbiwgZml4KTtcclxuICAgICAgICB9XHJcbiAgICB9XHJcbiAgICBpZiAoeHVydWkuY29uZmlnLnByb3RvdHlwZS5jb252ZXJ0KSB7XHJcbiAgICAgICAgLyoqXHJcbiAgICAgICAgICogU29ubHVr57G75Z6L6L2s5o2i5omp5bGV77ya5a2X56ym5Liy6L2s5pe26Ze077yaXHJcbiAgICAgICAgICog5Y+v5Lul5L2/55So4oCc5bm05pyI5pel5pe25YiG56eS4oCd44CB4oCc5pyI5pel5bm05pe25YiG56eS4oCd44CB4oCc5pyI5pel5pe25YiG56eS4oCd5ZKM4oCc5pe25YiG56eS4oCd5Zub56eN6aG65bqP5aGr5YaZ77yM5Lit6Ze06K+355So5Lu75LiA5YiG6ZqU56ym6ZqU5byA77ybXHJcbiAgICAgICAgICog5Y+v5Lul5LuO5ZCO5b6A5YmN55yB55Wl77yI55yB55Wl6aG56Ieq5Yqo55So5pyA5bCP5YC85aGr5YWF77yM5bm05Lu95pyA5bCP5YC85Li6MTAwMO+8ie+8jOS9huS4remXtOS4jeiDvea8j++8m1xyXG4gICAgICAgICAqIOWmguaenOS9v+eUqOKAnOW5tOaciOaXpeaXtuWIhuenkuKAnemhuuW6j+WImeiHs+WwkemcgOimgeWMheWQq+KAnOW5tOaciOKAneOAglxyXG4gICAgICAgICAqIOWmguaenOS9v+eUqOKAnOaXtuWIhuenkuKAnemhuuW6j+WImeW/hemhu+eUqOKAnDrigJ3pmpTlvIDjgIJcclxuICAgICAgICAgKi9cclxuICAgICAgICBTdHJpbmcucHJvdG90eXBlLnNsdG9EYXRldGltZSA9IGZ1bmN0aW9uICgpIHtcclxuICAgICAgICAgICAgcmV0dXJuIHh1cnVpLmNvbnZlcnQudG9EYXRldGltZSh0aGlzLnRvU3RyaW5nKCkpO1xyXG4gICAgICAgIH1cclxuICAgIH1cclxuICAgIC8qKiDpmLbmrrXliJ3lp4vljJYgKi9cclxuICAgIGlmICh4dXJ1aS5jb25maWcuZmFzdCkgZ2xvYmFsLiQkID0geHVydWk7XHJcbiAgICAvL2FwcOiBlOWKqOajgOa1i1xyXG4gICAgc3dpdGNoIChhcHApIHtcclxuICAgICAgICBjYXNlIFwic29ubHVpXCI6XHJcbiAgICAgICAgICAgIGlmICh0eXBlb2Ygc29ubHVpQXBwICE9IFwidW5kZWZpbmVkXCIpIHtcclxuICAgICAgICAgICAgICAgIHh1cnVpLnZhbHVlcy5hcHAuaXNBcHAgPSB0cnVlO1xyXG4gICAgICAgICAgICAgICAgeHVydWkuYXBwID0gc29ubHVpQXBwO1xyXG4gICAgICAgICAgICAgICAgaWYgKHR5cGVvZiB4dXJ1aS5hcHAuZ2V0QXBwVmVyc2lvbkNvZGUgPT0gXCJmdW5jdGlvblwiKSB4dXJ1aS52YWx1ZXMuYXBwLnZlckNvZGUgPSB4dXJ1aS5hcHAuZ2V0QXBwVmVyc2lvbkNvZGUoKTtcclxuICAgICAgICAgICAgICAgIGlmICh0eXBlb2YgeHVydWkuYXBwLmdldEFwcFZlcnNpb25OYW1lID09IFwiZnVuY3Rpb25cIikgeHVydWkudmFsdWVzLmFwcC52ZXJOYW1lID0geHVydWkuYXBwLmdldEFwcFZlcnNpb25OYW1lKCk7XHJcbiAgICAgICAgICAgICAgICBpZiAodHlwZW9mIHh1cnVpLmFwcC5nZXRBcHBNYWMgPT0gXCJmdW5jdGlvblwiKSB4dXJ1aS52YWx1ZXMuYXBwLm1hYyA9IHh1cnVpLmFwcC5nZXRBcHBNYWMoKTtcclxuICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICBicmVhaztcclxuICAgICAgICBjYXNlIFwieHVydWlcIjpcclxuICAgICAgICAgICAgYnJlYWs7XHJcbiAgICB9XHJcbiAgICBnbG9iYWxpemVTb29uKG1haW4pO1xyXG4gICAgZnVuc1Nvb24uZm9yRWFjaChmdW5jdGlvbiAoZnVuKSB7XHJcbiAgICAgICAgZnVuKG1haW4pO1xyXG4gICAgfSlcclxuICAgIC8qKiDmnIDlkI7liJ3lp4vljJYgKi9cclxuICAgIHdpbmRvdy5hZGRFdmVudExpc3RlbmVyKCdsb2FkJywgZnVuY3Rpb24gKCkge1xyXG4gICAgICAgIGlmICh0eXBlb2YgZG9jdW1lbnQucXVlcnlTZWxlY3RvckFsbChcInN2Z1wiKS5mb3JFYWNoID09PSAnZnVuY3Rpb24nKSB7XHJcbiAgICAgICAgICAgIGRvY3VtZW50LnF1ZXJ5U2VsZWN0b3JBbGwoXCJzdmdcIikuZm9yRWFjaChmdW5jdGlvbiAoY2hpbGQpIHtcclxuICAgICAgICAgICAgICAgIGlmICghY2hpbGQuaGFzQXR0cmlidXRlKFwidmlld0JveFwiKSkgY2hpbGQuc2V0QXR0cmlidXRlKFwidmlld0JveFwiLCBcIjAgMCAxMDI0IDEwMjRcIik7XHJcbiAgICAgICAgICAgIH0pO1xyXG4gICAgICAgIH1cclxuICAgICAgICBmdW5zQWZ0ZXIuZm9yRWFjaChmdW5jdGlvbiAoZnVuKSB7XHJcbiAgICAgICAgICAgIGZ1bih4dXJ1aSk7XHJcbiAgICAgICAgfSlcclxuICAgIH0pO1xyXG59XHJcblxyXG5leHBvcnQgZGVmYXVsdCBtYWluO1xyXG5leHBvcnQgeyBtYWluLCBpbml0IH07IiwiaW1wb3J0IG1haW4gZnJvbSBcIi4uL21haW4uanNcIjtcclxuaW1wb3J0IGNvbnZlcnQgZnJvbSBcIi4uL3V0aWxzL2NvbnZlcnQuanNcIjtcclxuaW1wb3J0IGNvb2tpZSBmcm9tIFwiLi4vdXRpbHMvY29va2llLmpzXCI7XHJcbmltcG9ydCBkYXRlIGZyb20gXCIuLi91dGlscy9kYXRlLmpzXCI7XHJcbmltcG9ydCBkb20gZnJvbSBcIi4uL3V0aWxzL2RvbS5qc1wiO1xyXG5pbXBvcnQgZm9ybWF0IGZyb20gXCIuLi91dGlscy9mb3JtYXQuanNcIjtcclxuaW1wb3J0IG1hdGggZnJvbSBcIi4uL3V0aWxzL21hdGguanNcIjtcclxuaW1wb3J0IG1lcmdlIGZyb20gXCIuLi91dGlscy9tZXJnZS5qc1wiO1xyXG5pbXBvcnQgc2F2ZSBmcm9tIFwiLi4vdXRpbHMvc2F2ZS5qc1wiO1xyXG5pbXBvcnQgdGltZSBmcm9tIFwiLi4vdXRpbHMvdGltZS5qc1wiO1xyXG5cclxudmFyIGJhc2ljID0ge1xyXG4gICAgY29udmVydDogY29udmVydCxcclxuICAgIGNvb2tpZTogY29va2llLFxyXG4gICAgZGF0ZTogZGF0ZSxcclxuICAgIGRvbTogZG9tLFxyXG4gICAgZm9ybWF0OiBmb3JtYXQsXHJcbiAgICBtYXRoOiBtYXRoLFxyXG4gICAgbWVyZ2U6IG1lcmdlLFxyXG4gICAgc2F2ZTogc2F2ZSxcclxuICAgIHRpbWU6IHRpbWVcclxufTtcclxuXHJcbmZvciAobGV0IGtleSBpbiBiYXNpYykge1xyXG4gICAgbWFpbltrZXldID0gYmFzaWNba2V5XTtcclxufTtcclxuXHJcbmV4cG9ydCBkZWZhdWx0IGJhc2ljO1xyXG5leHBvcnQgeyBtYWluIGFzIGJhc2ljTWFpbiB9OyIsImlmICh0eXBlb2YgU3RyaW5nLnByb3RvdHlwZS5zdGFydHNXaXRoICE9PSAnZnVuY3Rpb24nKSB7XHJcbiAgICBTdHJpbmcucHJvdG90eXBlLnN0YXJ0c1dpdGggPSBmdW5jdGlvbiAocHJlZml4KSB7XHJcbiAgICAgICAgcmV0dXJuIHRoaXMuc2xpY2UoMCwgcHJlZml4Lmxlbmd0aCkgPT09IHByZWZpeDtcclxuICAgIH07XHJcbn1cclxuXHJcbmlmICh0eXBlb2YgU3RyaW5nLnByb3RvdHlwZS5lbmRzV2l0aCAhPT0gJ2Z1bmN0aW9uJykge1xyXG4gICAgU3RyaW5nLnByb3RvdHlwZS5lbmRzV2l0aCA9IGZ1bmN0aW9uIChzdWZmaXgpIHtcclxuICAgICAgICByZXR1cm4gdGhpcy5pbmRleE9mKHN1ZmZpeCwgdGhpcy5sZW5ndGggLSBzdWZmaXgubGVuZ3RoKSAhPT0gLTE7XHJcbiAgICB9O1xyXG59XHJcblxyXG5pZiAodHlwZW9mIEFycmF5LnByb3RvdHlwZS5maW5kICE9PSAnZnVuY3Rpb24nKSB7XHJcbiAgICBBcnJheS5wcm90b3R5cGUuZmluZCA9IGZ1bmN0aW9uIChjb21wYXJlKSB7XHJcbiAgICAgICAgZm9yICh2YXIgaSA9IDA7IGkgPCB0aGlzLmxlbmd0aDsgaSsrKSB7XHJcbiAgICAgICAgICAgIGlmIChjb21wYXJlKHRoaXNbaV0pKSB7XHJcbiAgICAgICAgICAgICAgICByZXR1cm4gdGhpc1tpXTtcclxuICAgICAgICAgICAgfVxyXG4gICAgICAgIH1cclxuICAgIH07XHJcbn0iLCJpbXBvcnQgbWFpbiBmcm9tICcuLi9tYWluLmpzJztcclxuXHJcbi8qKmh0dHDmk43kvZwgKi9cclxudmFyIGh0dHAgPSB7XHJcblxyXG4gICAgLyoqXHJcbiAgICAgKiDlr7nojrflvpfnmoTotYTmupDmlbDmja7ov5vooYzkuIvovb3mk43kvZzvvIjlpoLmnpzotYTmupDmr5TovoPlpKfvvIzor7fli7/kvb/nlKjmraTmlrnlvI/vvIzor7fnm7TmjqXku47mnI3liqHlmajkuIvovb3vvIlcclxuICAgICAqIEBwYXJhbSB7QmluYXJ5VHlwZX0gZGF0YSDopoHkuIvovb3nmoTmlbDmja5cclxuICAgICAqIEBwYXJhbSB7U3RyaW5nfSBuYW1lIOS4i+i9veWQjueahOaWh+S7tuWQje+8iOWMheWQq+aJqeWxleWQje+8iVxyXG4gICAgICovXHJcbiAgICBkb3dubG9hZExpdGU6IGZ1bmN0aW9uIChkYXRhLCBuYW1lKSB7XHJcbiAgICAgICAgdmFyIGEgPSBkb2N1bWVudC5jcmVhdGVFbGVtZW50KCdhJyk7XHJcbiAgICAgICAgYS5zZXRBdHRyaWJ1dGUoJ2hyZWYnLCAnZGF0YToqLyo7YmFzZTY0LCcgKyBkYXRhKTtcclxuICAgICAgICBhLnNldEF0dHJpYnV0ZSgnZG93bmxvYWQnLCBuYW1lKTtcclxuICAgICAgICBkb2N1bWVudC5xdWVyeVNlbGVjdG9yKCdib2R5JykuYXBwZW5kKGEpO1xyXG4gICAgICAgIGFbMF0uY2xpY2soKTtcclxuICAgICAgICBhLnJlbW92ZSgpO1xyXG4gICAgICAgIHJldHVybiBhO1xyXG4gICAgfSxcclxuXHJcbiAgICAvKipcclxuICAgICAqIOS4i+i9veaTjeS9nFxyXG4gICAgICogQHBhcmFtIHtPYmplY3R9IGlucHV0IEFqYXjmqKHlvI/kvKDlhaXlr7nosaHvvIzpnZ5BamF45qih5byP5Lyg5YWl5Zyw5Z2AXHJcbiAgICAgKiBAcGFyYW0ge0Jvb2xlYW59IGdldCBBamF45qih5byP55WZ56m677yM6Z2eQWpheOaooeW8j3RydWXkuLpHRVTor7fmsYLvvIxmYWxzZeS4ulBPU1Tor7fmsYLvvIzpu5jorqR0cnVlXHJcbiAgICAgKiBAcGFyYW0ge09iamVjdH0gZGF0YSBBamF45qih5byP55WZ56m677yM6Z2eQWpheOaooeW8j+S8oOWFpUpzb27lrZfnrKbkuLLljJbkuYvliY3nmoTmlbDmja7vvIhHRVTor7fmsYLliJnnlZnnqbrvvIlcclxuICAgICAqIEBwYXJhbSB7T2JqZWN0fSBxdWVyeSBBamF45qih5byP55WZ56m677yM6Z2eQWpheOaooeW8j+S8oOWFpUpT5a+56LGh77yM5qC55o2u5a+56LGh5ZCN5ZKM5YC857uZVXJs6LWL5Y+C5pWwXHJcbiAgICAgKi9cclxuICAgIGRvd25sb2FkOiBmdW5jdGlvbiAoaW5wdXQsIGdldCwgZGF0YSwgcXVlcnksIHRhcmdldCkge1xyXG4gICAgICAgIHZhciBuZXdVcmw7XHJcbiAgICAgICAgdmFyIG5ld0dldCA9IHRydWU7XHJcbiAgICAgICAgdmFyIG5ld0RhdGE7XHJcbiAgICAgICAgdmFyIG5ld1F1ZXJ5O1xyXG4gICAgICAgIHZhciBuZXdUYXJnZXQgPSAnX3NlbGYnO1xyXG4gICAgICAgIGlmICh0eXBlb2YgaW5wdXQgPT09ICdvYmplY3QnKSB7XHJcbiAgICAgICAgICAgIGlmICh0eXBlb2YgaW5wdXQudXJsID09PSAnc3RyaW5nJykgbmV3VXJsID0gaW5wdXQudXJsO1xyXG4gICAgICAgICAgICBpZiAodHlwZW9mIGlucHV0LmdldCA9PT0gJ2Jvb2xlYW4nKSBuZXdHZXQgPSBpbnB1dC5nZXQ7XHJcbiAgICAgICAgICAgIGlmICh0eXBlb2YgaW5wdXQuZGF0YSA9PT0gJ29iamVjdCcpIG5ld0RhdGEgPSBpbnB1dC5kYXRhO1xyXG4gICAgICAgICAgICBpZiAodHlwZW9mIGlucHV0LnF1ZXJ5ID09PSAnb2JqZWN0JykgbmV3UXVlcnkgPSBpbnB1dC5xdWVyeTtcclxuICAgICAgICAgICAgaWYgKHR5cGVvZiBpbnB1dC50YXJnZXQgPT09ICdzdHJpbmcnKSBuZXdUYXJnZXQgPSBpbnB1dC50YXJnZXQ7XHJcbiAgICAgICAgfVxyXG4gICAgICAgIGVsc2UgaWYgKHR5cGVvZiBpbnB1dCA9PT0gJ3N0cmluZycpIHtcclxuICAgICAgICAgICAgaWYgKHR5cGVvZiBpbnB1dCA9PT0gJ3N0cmluZycpIG5ld1VybCA9IGlucHV0O1xyXG4gICAgICAgICAgICBpZiAodHlwZW9mIGdldCA9PT0gJ2Jvb2xlYW4nKSBuZXdHZXQgPSBnZXQ7XHJcbiAgICAgICAgICAgIGlmICh0eXBlb2YgZGF0YSA9PT0gJ29iamVjdCcpIG5ld0RhdGEgPSBkYXRhO1xyXG4gICAgICAgICAgICBpZiAodHlwZW9mIHF1ZXJ5ID09PSAnb2JqZWN0JykgbmV3UXVlcnkgPSBxdWVyeTtcclxuICAgICAgICAgICAgaWYgKHR5cGVvZiB0YXJnZXQgPT09ICdzdHJpbmcnKSBuZXdUYXJnZXQgPSB0YXJnZXQ7XHJcbiAgICAgICAgfVxyXG4gICAgICAgIGVsc2UgdGhyb3cgRXJyb3IoJ+S8oOWFpeWPguaVsOmUmeivr++8gScpO1xyXG4gICAgICAgIGZvciAobGV0IGtleSBpbiBuZXdRdWVyeSkge1xyXG4gICAgICAgICAgICBuZXdVcmwgPSB1cmxRdWVyeUFkZChuZXdVcmwsIGtleSwgbmV3UXVlcnlba2V5XSk7XHJcbiAgICAgICAgfVxyXG4gICAgICAgIGlmIChuZXdHZXQpIHtcclxuICAgICAgICAgICAgd2luZG93Lm9wZW4obmV3VXJsLCBuZXdUYXJnZXQpO1xyXG4gICAgICAgICAgICByZXR1cm4gbmV3VXJsO1xyXG4gICAgICAgIH1cclxuICAgICAgICBlbHNlIHtcclxuICAgICAgICAgICAgdmFyIGZvcm0gPSBkb2N1bWVudC5jcmVhdGVFbGVtZW50KCdmb3JtJyk7XHJcbiAgICAgICAgICAgIGZvcm0uc2V0QXR0cmlidXRlKCdtZXRob2QnLCAncG9zdCcpO1xyXG4gICAgICAgICAgICBmb3JtLnNldEF0dHJpYnV0ZSgnYWN0aW9uJywgbmV3VXJsKTtcclxuICAgICAgICAgICAgZm9ybS5zZXRBdHRyaWJ1dGUoJ3RhcmdldCcsIG5ld1RhcmdldCk7XHJcbiAgICAgICAgICAgIGlmICh0eXBlb2YgbmV3RGF0YSA9PT0gJ3N0cmluZycpIHtcclxuICAgICAgICAgICAgICAgIHZhciBmb3JtSW5wdXQgPSBkb2N1bWVudC5jcmVhdGVFbGVtZW50KCdpbnB1dCcpO1xyXG4gICAgICAgICAgICAgICAgZm9ybUlucHV0LnNldEF0dHJpYnV0ZSgndHlwZScsICdoaWRkZW4nKTtcclxuICAgICAgICAgICAgICAgIGZvcm1JbnB1dC5zZXRBdHRyaWJ1dGUoJ25hbWUnLCAnaW5wdXQnKTtcclxuICAgICAgICAgICAgICAgIGZvcm1JbnB1dC5zZXRBdHRyaWJ1dGUoJ3ZhbHVlJywgbmV3RGF0YSk7XHJcbiAgICAgICAgICAgICAgICBmb3JtLmluc2VydEFkamFjZW50RWxlbWVudCgnYmVmb3JlZW5kJywgZm9ybUlucHV0KTtcclxuICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICBlbHNlIGlmICh0eXBlb2YgbmV3RGF0YSA9PT0gJ29iamVjdCcpIHtcclxuICAgICAgICAgICAgICAgIGZvciAobGV0IGtleSBpbiBuZXdEYXRhKSB7XHJcbiAgICAgICAgICAgICAgICAgICAgdmFyIGZvcm1JbnB1dCA9IGRvY3VtZW50LmNyZWF0ZUVsZW1lbnQoJ2lucHV0Jyk7XHJcbiAgICAgICAgICAgICAgICAgICAgZm9ybUlucHV0LnNldEF0dHJpYnV0ZSgndHlwZScsICdoaWRkZW4nKTtcclxuICAgICAgICAgICAgICAgICAgICBmb3JtSW5wdXQuc2V0QXR0cmlidXRlKCduYW1lJywga2V5KTtcclxuICAgICAgICAgICAgICAgICAgICBpZiAodHlwZW9mIG5ld0RhdGFba2V5XSA9PT0gJ29iamVjdCcpIGZvcm1JbnB1dC5zZXRBdHRyaWJ1dGUoJ3ZhbHVlJywgSlNPTi5zdHJpbmdpZnkobmV3RGF0YVtrZXldKSk7XHJcbiAgICAgICAgICAgICAgICAgICAgZWxzZSBmb3JtSW5wdXQuc2V0QXR0cmlidXRlKCd2YWx1ZScsIG5ld0RhdGFba2V5XSk7XHJcbiAgICAgICAgICAgICAgICAgICAgZm9ybS5pbnNlcnRBZGphY2VudEVsZW1lbnQoJ2JlZm9yZWVuZCcsIGZvcm1JbnB1dCk7XHJcbiAgICAgICAgICAgICAgICB9XHJcbiAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgZG9jdW1lbnQucXVlcnlTZWxlY3RvcignYm9keScpLmluc2VydEFkamFjZW50RWxlbWVudCgnYmVmb3JlZW5kJywgZm9ybSk7XHJcbiAgICAgICAgICAgIGZvcm0uc3VibWl0KCk7XHJcbiAgICAgICAgICAgIGZvcm0ucGFyZW50Tm9kZS5yZW1vdmVDaGlsZChmb3JtKTtcclxuICAgICAgICAgICAgcmV0dXJuIGZvcm07XHJcbiAgICAgICAgfVxyXG4gICAgfSxcclxuXHJcbiAgICAvKipcclxuICAgICAqIOS4iuS8oOaTjeS9nFxyXG4gICAgICogQHBhcmFtIHtPYmplY3R9IGlucHV0IOS4iuS8oOWPguaVsFxyXG4gICAgICovXHJcbiAgICB1cGxvYWQ6IGZ1bmN0aW9uIChpbnB1dCkge1xyXG4gICAgICAgIHZhciBkYXRhID0gZG9jdW1lbnQucXVlcnlTZWxlY3RvcihpbnB1dC5lbGVtKTtcclxuICAgICAgICBpbnB1dC5zdWNjZXNzID0gaW5wdXQuc3VjY2VzcyB8fCBmdW5jdGlvbiAoYSkgeyB9O1xyXG4gICAgICAgIGlucHV0LmVycm9yID0gaW5wdXQuZXJyb3IgfHwgZnVuY3Rpb24gKGEpIHsgfTtcclxuICAgICAgICBpbnB1dC5jb21wbGV0ZSA9IGlucHV0LmNvbXBsZXRlIHx8IGZ1bmN0aW9uIChhKSB7IH07XHJcbiAgICAgICAgaW5wdXQucHJvZ3Jlc3MgPSBpbnB1dC5wcm9ncmVzcyB8fCBmdW5jdGlvbiAoYSkgeyB9O1xyXG4gICAgICAgIGlucHV0LmJlZm9yZSA9IGlucHV0LmJlZm9yZSB8fCBmdW5jdGlvbiAoYSkgeyB9O1xyXG4gICAgICAgIGlucHV0Lm5hbWUgPSBpbnB1dC5uYW1lIHx8ICdmaWxlJztcclxuICAgICAgICBpbnB1dC5iZWZvcmUoZGF0YSk7XHJcbiAgICAgICAgdmFyIGZvcm1EYXRhID0gbmV3IEZvcm1EYXRhKCk7XHJcbiAgICAgICAgaWYgKGRhdGEuZmlsZXMubGVuZ3RoID4gMCkge1xyXG4gICAgICAgICAgICBmb3IgKHZhciBpID0gMDsgaSA8IGRhdGEuZmlsZXMubGVuZ3RoOyBpKyspIHtcclxuICAgICAgICAgICAgICAgIGZvcm1EYXRhLmFwcGVuZChpbnB1dC5uYW1lLCBkYXRhLmZpbGVzW2ldKTtcclxuICAgICAgICAgICAgfVxyXG4gICAgICAgIH1cclxuICAgICAgICBlbHNlIHtcclxuICAgICAgICAgICAgcmV0dXJuO1xyXG4gICAgICAgIH1cclxuICAgICAgICB2YXIgeGhyID0gbmV3IFhNTEh0dHBSZXF1ZXN0KCk7XHJcbiAgICAgICAgeGhyLmFkZEV2ZW50TGlzdGVuZXIoJ2xvYWQnLCBmdW5jdGlvbiAoZSkge1xyXG4gICAgICAgICAgICBpZiAoZS5zcmNFbGVtZW50LnN0YXR1cyA9PT0gMjAwKSB7XHJcbiAgICAgICAgICAgICAgICBpbnB1dC5zdWNjZXNzKGUuc3JjRWxlbWVudC5yZXNwb25zZSk7XHJcbiAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgZWxzZSB7XHJcbiAgICAgICAgICAgICAgICBpbnB1dC5lcnJvcihlLnNyY0VsZW1lbnQpO1xyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgfSk7XHJcbiAgICAgICAgeGhyLmFkZEV2ZW50TGlzdGVuZXIoJ2Vycm9yJywgZnVuY3Rpb24gKGUpIHtcclxuICAgICAgICAgICAgaW5wdXQuZXJyb3IoZS5zcmNFbGVtZW50KTtcclxuICAgICAgICB9KTtcclxuICAgICAgICB4aHIuYWRkRXZlbnRMaXN0ZW5lcignbG9hZGVuZCcsIGZ1bmN0aW9uIChlKSB7XHJcbiAgICAgICAgICAgIGlucHV0LmNvbXBsZXRlKGUuc3JjRWxlbWVudCk7XHJcbiAgICAgICAgfSk7XHJcbiAgICAgICAgeGhyLnVwbG9hZC5hZGRFdmVudExpc3RlbmVyKCdwcm9ncmVzcycsIGZ1bmN0aW9uIChlKSB7XHJcbiAgICAgICAgICAgIGlmIChlLmxlbmd0aENvbXB1dGFibGUpIHtcclxuICAgICAgICAgICAgICAgIGlucHV0LnByb2dyZXNzKE1hdGguY2VpbChlLmxvYWRlZCAqIDEwMCAvIGUudG90YWwpICsgJyUnLCBlKTtcclxuICAgICAgICAgICAgfVxyXG4gICAgICAgIH0sIGZhbHNlKTtcclxuICAgICAgICB4aHIub3BlbignUE9TVCcsIGlucHV0LnVybCk7XHJcbiAgICAgICAgeGhyLnNlbmQoZm9ybURhdGEpO1xyXG4gICAgICAgIHJldHVybiB4aHI7XHJcbiAgICB9LFxyXG5cclxuICAgIC8qKuWQkUFwaeWPkemAgeivt+axguaTjeS9nCAqL1xyXG4gICAgYXBpOiB7XHJcblxyXG4gICAgICAgIC8qKlxyXG4gICAgICAgICAqIOWQkeaMh+WumkFwaeWPkemAgeivt+axguiOt+W+l+S4i+i9veWGheWuue+8iOW4pnB0b2tlbu+8iVxyXG4gICAgICAgICAqIEBwYXJhbSB7T2JqZWN0fSBpbnB1dCBBamF45qih5byP5Lyg5YWl5a+56LGh77yM6Z2eQWpheOaooeW8j+S8oOWFpeWcsOWdgFxyXG4gICAgICAgICAqIEBwYXJhbSB7U3RyaW5nfSBtb2R1bGUgQWpheOaooeW8j+eVmeepuu+8jOmdnkFqYXjmqKHlvI/kvKDlhaVBcGnmqKHlnZflkI1cclxuICAgICAgICAgKiBAcGFyYW0ge0Jvb2xlYW59IGdldCBBamF45qih5byP55WZ56m677yM6Z2eQWpheOaooeW8j3RydWXkuLpHRVTor7fmsYLvvIxmYWxzZeS4ulBPU1Tor7fmsYLvvIzpu5jorqR0cnVlXHJcbiAgICAgICAgICogQHBhcmFtIHtPYmplY3R9IGRhdGEgQWpheOaooeW8j+eVmeepuu+8jOmdnkFqYXjmqKHlvI/kvKDlhaXmlbDmja5cclxuICAgICAgICAgKiBAcGFyYW0ge09iamVjdH0gcXVlcnkgQWpheOaooeW8j+eVmeepuu+8jOmdnkFqYXjmqKHlvI/kvKDlhaVKU+Wvueixoe+8jOagueaNruWvueixoeWQjeWSjOWAvOe7mVVybOi1i+WPguaVsFxyXG4gICAgICAgICAqL1xyXG4gICAgICAgIHNkb3dubG9hZDogZnVuY3Rpb24gKGlucHV0LCBtb2R1bGUsIGdldCwgZGF0YSwgcXVlcnkpIHtcclxuICAgICAgICAgICAgcmV0dXJuIG1haW4uaHR0cC5hcGkuZG93bmxvYWQocHRva2VuQWRkKGlucHV0KSwgbW9kdWxlLCBnZXQsIGRhdGEsIHF1ZXJ5KTtcclxuICAgICAgICB9LFxyXG4gICAgICAgIC8qKlxyXG4gICAgICAgICAqIOWQkeaMh+WumkFwaeWPkemAgUdFVOivt+axgu+8iOW4pnB0b2tlbu+8iVxyXG4gICAgICAgICAqIEBwYXJhbSB7T2JqZWN0fSBpbnB1dCBBamF45qih5byP5Lyg5YWl5a+56LGh77yM6Z2eQWpheOaooeW8j+S8oOWFpeWcsOWdgFxyXG4gICAgICAgICAqIEBwYXJhbSB7RnVuY3Rpb259IHN1Y2Nlc3MgQWpheOaooeW8j+eVmeepuu+8jOmdnkFqYXjmqKHlvI/kvKDlhaXlm57osIPlh73mlbDvvIzlj4LmlbDkuLrlr7nosaHljJbnmoTkvKDlhaXmlbDmja5cclxuICAgICAgICAgKiBAcGFyYW0ge1N0cmluZ30gbW9kdWxlIEFqYXjmqKHlvI/nlZnnqbrvvIzpnZ5BamF45qih5byP5Lyg5YWlQXBp5qih5Z2X5ZCNXHJcbiAgICAgICAgICogQHBhcmFtIHtCb29sZWFufSBhc3luIEFqYXjmqKHlvI/nlZnnqbrvvIzpnZ5BamF45qih5byP5Lyg5YWl5piv5ZCm5byC5q2l5biD5bCU5YC8XHJcbiAgICAgICAgICovXHJcbiAgICAgICAgc2dldDogZnVuY3Rpb24gKGlucHV0LCBzdWNjZXNzLCBtb2R1bGUsIGFzeW4pIHtcclxuICAgICAgICAgICAgcmV0dXJuIG1haW4uaHR0cC5hcGkuZ2V0KHB0b2tlbkFkZChpbnB1dCksIHN1Y2Nlc3MsIG1vZHVsZSwgYXN5bik7XHJcbiAgICAgICAgfSxcclxuICAgICAgICAvKipcclxuICAgICAgICAgKiDlkJHmjIflrppBcGnlj5HpgIFHRVTor7fmsYLvvIjluKZwdG9rZW7vvIlcclxuICAgICAgICAgKiBAcGFyYW0ge09iamVjdH0gaW5wdXQgQWpheOaooeW8j+S8oOWFpeWvueixoe+8jOmdnkFqYXjmqKHlvI/kvKDlhaXlnLDlnYBcclxuICAgICAgICAgKiBAcGFyYW0ge09iamVjdH0gZGF0YSBBamF45qih5byP55WZ56m677yM6Z2eQWpheOaooeW8j+S8oOWFpUpzb27lrZfnrKbkuLLljJbkuYvliY3nmoTmlbDmja5cclxuICAgICAgICAgKiBAcGFyYW0ge0Z1bmN0aW9ufSBzdWNjZXNzIEFqYXjmqKHlvI/nlZnnqbrvvIzpnZ5BamF45qih5byP5Lyg5YWl5Zue6LCD5Ye95pWw77yM5Y+C5pWw5Li65a+56LGh5YyW55qE5Lyg5YWl5pWw5o2uXHJcbiAgICAgICAgICogQHBhcmFtIHtTdHJpbmd9IG1vZHVsZSBBamF45qih5byP55WZ56m677yM6Z2eQWpheOaooeW8j+S8oOWFpUFwaeaooeWdl+WQjVxyXG4gICAgICAgICAqIEBwYXJhbSB7Qm9vbGVhbn0gYXN5biBBamF45qih5byP55WZ56m677yM6Z2eQWpheOaooeW8j+S8oOWFpeaYr+WQpuW8guatpeW4g+WwlOWAvFxyXG4gICAgICAgICAqL1xyXG4gICAgICAgIHNwb3N0OiBmdW5jdGlvbiAoaW5wdXQsIGRhdGEsIHN1Y2Nlc3MsIG1vZHVsZSwgYXN5bikge1xyXG4gICAgICAgICAgICByZXR1cm4gbWFpbi5odHRwLmFwaS5wb3N0KHB0b2tlbkFkZChpbnB1dCksIGRhdGEsIHN1Y2Nlc3MsIG1vZHVsZSwgYXN5bik7XHJcbiAgICAgICAgfSxcclxuICAgICAgICAvKipcclxuICAgICAgICAgKiDlkJHmjIflrppBcGnlj5HpgIHor7fmsYLojrflvpfkuIvovb3lhoXlrrnvvIjkuI3luKZwdG9rZW7vvIlcclxuICAgICAgICAgKiBAcGFyYW0ge09iamVjdH0gaW5wdXQgQWpheOaooeW8j+S8oOWFpeWvueixoe+8jOmdnkFqYXjmqKHlvI/kvKDlhaXlnLDlnYBcclxuICAgICAgICAgKiBAcGFyYW0ge1N0cmluZ30gbW9kdWxlIEFqYXjmqKHlvI/nlZnnqbrvvIzpnZ5BamF45qih5byP5Lyg5YWlQXBp5qih5Z2X5ZCNXHJcbiAgICAgICAgICogQHBhcmFtIHtCb29sZWFufSBnZXQgQWpheOaooeW8j+eVmeepuu+8jOmdnkFqYXjmqKHlvI90cnVl5Li6R0VU6K+35rGC77yMZmFsc2XkuLpQT1NU6K+35rGC77yM6buY6K6kdHJ1ZVxyXG4gICAgICAgICAqIEBwYXJhbSB7T2JqZWN0fSBkYXRhIEFqYXjmqKHlvI/nlZnnqbrvvIzpnZ5BamF45qih5byP5Lyg5YWlSnNvbuWtl+espuS4suWMluS5i+WJjeeahOaVsOaNru+8iEdFVOivt+axguWImeeVmeepuu+8iVxyXG4gICAgICAgICAqIEBwYXJhbSB7T2JqZWN0fSBxdWVyeSBBamF45qih5byP55WZ56m677yM6Z2eQWpheOaooeW8j+S8oOWFpUpT5a+56LGh77yM5qC55o2u5a+56LGh5ZCN5ZKM5YC857uZVXJs6LWL5Y+C5pWwXHJcbiAgICAgICAgICovXHJcbiAgICAgICAgZG93bmxvYWQ6IGZ1bmN0aW9uIChpbnB1dCwgbW9kdWxlLCBnZXQsIGRhdGEsIHF1ZXJ5KSB7XHJcbiAgICAgICAgICAgIGlmICh0eXBlb2YgaW5wdXQgPT09ICdvYmplY3QnKSB7XHJcbiAgICAgICAgICAgICAgICBpZiAodHlwZW9mIGlucHV0LnVybCA9PT0gJ3N0cmluZycgJiYgdHlwZW9mIGlucHV0Lm1vZHVsZSA9PT0gJ3N0cmluZycpIHtcclxuICAgICAgICAgICAgICAgICAgICBpbnB1dC5tb2R1bGUgPSB4dXJ1aS5jb25maWcuaHR0cC5hcGlbaW5wdXQubW9kdWxlIHx8ICdERkxUJ10gfHwgeHVydWkuY29uZmlnLmh0dHAuYXBpLkRGTFQ7XHJcbiAgICAgICAgICAgICAgICAgICAgaW5wdXQubW9kdWxlLmFkZHJlc3MgPSBpbnB1dC5tb2R1bGUuYWRkcmVzcyB8fCB4dXJ1aS5jb25maWcuaHR0cC5hcGkuREZMVC5hZGRyZXNzO1xyXG4gICAgICAgICAgICAgICAgICAgIGlucHV0LnVybCA9IGlucHV0Lm1vZHVsZS5hZGRyZXNzICsgaW5wdXQudXJsO1xyXG4gICAgICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgICAgIGVsc2Uge1xyXG4gICAgICAgICAgICAgICAgaWYgKHR5cGVvZiBpbnB1dCA9PT0gJ3N0cmluZycgJiYgdHlwZW9mIG1vZHVsZSA9PT0gJ3N0cmluZycpIHtcclxuICAgICAgICAgICAgICAgICAgICBtb2R1bGUgPSB4dXJ1aS5jb25maWcuaHR0cC5hcGlbbW9kdWxlIHx8ICdERkxUJ10gfHwgeHVydWkuY29uZmlnLmh0dHAuYXBpLkRGTFQ7XHJcbiAgICAgICAgICAgICAgICAgICAgbW9kdWxlLmFkZHJlc3MgPSBtb2R1bGUuYWRkcmVzcyB8fCB4dXJ1aS5jb25maWcuaHR0cC5hcGkuREZMVC5hZGRyZXNzO1xyXG4gICAgICAgICAgICAgICAgICAgIGlucHV0ID0gbW9kdWxlLmFkZHJlc3MgKyBpbnB1dDtcclxuICAgICAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICBtYWluLmh0dHAuZG93bmxvYWQoaW5wdXQsIGdldCwgZGF0YSwgcXVlcnkpO1xyXG4gICAgICAgIH0sXHJcbiAgICAgICAgLyoqXHJcbiAgICAgICAgICog5ZCR5oyH5a6aQXBp5Y+R6YCBR0VU6K+35rGC77yI5LiN5bimcHRva2Vu77yJXHJcbiAgICAgICAgICogQHBhcmFtIHtPYmplY3R9IGlucHV0IEFqYXjmqKHlvI/kvKDlhaXlr7nosaHvvIzpnZ5BamF45qih5byP5Lyg5YWl5Zyw5Z2AXHJcbiAgICAgICAgICogQHBhcmFtIHtGdW5jdGlvbn0gc3VjY2VzcyBBamF45qih5byP55WZ56m677yM6Z2eQWpheOaooeW8j+S8oOWFpeWbnuiwg+WHveaVsO+8jOWPguaVsOS4uuWvueixoeWMlueahOS8oOWFpeaVsOaNrlxyXG4gICAgICAgICAqIEBwYXJhbSB7U3RyaW5nfSBtb2R1bGUgQWpheOaooeW8j+eVmeepuu+8jOmdnkFqYXjmqKHlvI/kvKDlhaVBcGnmqKHlnZflkI1cclxuICAgICAgICAgKiBAcGFyYW0ge0Jvb2xlYW59IGFzeW5jIEFqYXjmqKHlvI/nlZnnqbrvvIzpnZ5BamF45qih5byP5Lyg5YWl5piv5ZCm5byC5q2l5biD5bCU5YC8XHJcbiAgICAgICAgICovXHJcbiAgICAgICAgZ2V0OiBmdW5jdGlvbiAoaW5wdXQsIHN1Y2Nlc3MsIG1vZHVsZSwgYXN5bmMpIHtcclxuICAgICAgICAgICAgdmFyIG5ld1VybDtcclxuICAgICAgICAgICAgdmFyIG5ld1N1Y2Nlc3M7XHJcbiAgICAgICAgICAgIHZhciBuZXdNb2R1bGUgPSAnREZMVCc7XHJcbiAgICAgICAgICAgIHZhciBuZXdBc3luYztcclxuICAgICAgICAgICAgaWYgKHR5cGVvZiBpbnB1dCA9PT0gJ29iamVjdCcpIHtcclxuICAgICAgICAgICAgICAgIGlmICh0eXBlb2YgaW5wdXQudXJsID09PSAnc3RyaW5nJykgbmV3VXJsID0gaW5wdXQudXJsO1xyXG4gICAgICAgICAgICAgICAgaWYgKHR5cGVvZiBpbnB1dC5zdWNjZXNzID09PSAnZnVuY3Rpb24nKSBuZXdTdWNjZXNzID0gaW5wdXQuc3VjY2VzcztcclxuICAgICAgICAgICAgICAgIGlmICh0eXBlb2YgaW5wdXQubW9kdWxlID09PSAnc3RyaW5nJykgbmV3TW9kdWxlID0gaW5wdXQubW9kdWxlO1xyXG4gICAgICAgICAgICAgICAgaWYgKHR5cGVvZiBpbnB1dC5hc3luYyA9PT0gJ2Jvb2xlYW4nKSBuZXdBc3luYyA9IGlucHV0LmFzeW5jO1xyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgICAgIGVsc2UgaWYgKHR5cGVvZiBpbnB1dCA9PT0gJ3N0cmluZycpIHtcclxuICAgICAgICAgICAgICAgIG5ld1VybCA9IGlucHV0O1xyXG4gICAgICAgICAgICAgICAgaWYgKHR5cGVvZiBzdWNjZXNzID09PSAnZnVuY3Rpb24nKSBuZXdTdWNjZXNzID0gc3VjY2VzcztcclxuICAgICAgICAgICAgICAgIGlmICh0eXBlb2YgbW9kdWxlID09PSAnc3RyaW5nJykgbmV3TW9kdWxlID0gbW9kdWxlO1xyXG4gICAgICAgICAgICAgICAgaWYgKHR5cGVvZiBhc3luYyA9PT0gJ2Jvb2xlYW4nKSBuZXdBc3luYyA9IGFzeW5jO1xyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgICAgIGVsc2Uge1xyXG4gICAgICAgICAgICAgICAgdGhyb3cgRXJyb3IoJ+WPguaVsOS4jeato+ehru+8jOivt+S7pUFKQVjmlrnlvI/loavlhaXlj4LmlbDmiJbnoa7kv53nrKzkuIDkuKrlj4LmlbDkuLpVcmzlnLDlnYAnKTtcclxuICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICBuZXdNb2R1bGUgPSB4dXJ1aS5jb25maWcuaHR0cC5hcGlbbmV3TW9kdWxlXSB8fCB4dXJ1aS5jb25maWcuaHR0cC5hcGkuREZMVDtcclxuICAgICAgICAgICAgbmV3TW9kdWxlLmFkZHJlc3MgPSBuZXdNb2R1bGUuYWRkcmVzcyB8fCB4dXJ1aS5jb25maWcuaHR0cC5hcGkuREZMVC5hZGRyZXNzO1xyXG4gICAgICAgICAgICBuZXdNb2R1bGUuY29udGVudFR5cGUgPSBuZXdNb2R1bGUuY29udGVudFR5cGUgfHwgeHVydWkuY29uZmlnLmh0dHAuYXBpLkRGTFQuY29udGVudFR5cGU7XHJcbiAgICAgICAgICAgIG5ld01vZHVsZS5yZXNwb25zZURhdGEgPSBuZXdNb2R1bGUucmVzcG9uc2VEYXRhIHx8IHh1cnVpLmNvbmZpZy5odHRwLmFwaS5ERkxULnJlc3BvbnNlRGF0YTtcclxuICAgICAgICAgICAgcmV0dXJuIHh1cnVpLmh0dHAuYWpheCh7XHJcbiAgICAgICAgICAgICAgICB0eXBlOiAnR0VUJyxcclxuICAgICAgICAgICAgICAgIGNvbnRlbnRUeXBlOiBuZXdNb2R1bGUuY29udGVudFR5cGUsXHJcbiAgICAgICAgICAgICAgICBhc3luYzogbmV3QXN5bmMsXHJcbiAgICAgICAgICAgICAgICBzdWNjZXNzOiBmdW5jdGlvbiAoZGF0YSkgeyBuZXdTdWNjZXNzKG5ld01vZHVsZS5yZXNwb25zZURhdGEoZGF0YSkpIH0sXHJcbiAgICAgICAgICAgICAgICB1cmw6IG5ld01vZHVsZS5hZGRyZXNzICsgbmV3VXJsLFxyXG4gICAgICAgICAgICB9KTtcclxuICAgICAgICB9LFxyXG4gICAgICAgIC8qKlxyXG4gICAgICAgICAqIOWQkeaMh+WumkFwaeWPkemAgVBPU1Tor7fmsYLvvIjkuI3luKZwdG9rZW7vvIlcclxuICAgICAgICAgKiBAcGFyYW0ge09iamVjdH0gaW5wdXQgQWpheOaooeW8j+S8oOWFpeWvueixoe+8jOmdnkFqYXjmqKHlvI/kvKDlhaXlnLDlnYBcclxuICAgICAgICAgKiBAcGFyYW0ge09iamVjdH0gZGF0YSBBamF45qih5byP55WZ56m677yM6Z2eQWpheOaooeW8j+S8oOWFpUpzb27lrZfnrKbkuLLljJbkuYvliY3nmoTmlbDmja5cclxuICAgICAgICAgKiBAcGFyYW0ge0Jvb2xlYW59IHN1Y2Nlc3MgQWpheOaooeW8j+eVmeepuu+8jOmdnkFqYXjmqKHlvI/kvKDlhaXlm57osIPlh73mlbDvvIzlj4LmlbDkuLrlr7nosaHljJbnmoTkvKDlhaXmlbDmja5cclxuICAgICAgICAgKiBAcGFyYW0ge1N0cmluZ30gbW9kdWxlIEFqYXjmqKHlvI/nlZnnqbrvvIzpnZ5BamF45qih5byP5Lyg5YWlQXBp5qih5Z2X5ZCNXHJcbiAgICAgICAgICogQHBhcmFtIHtCb29sZWFufSBhc3luYyBBamF45qih5byP55WZ56m677yM6Z2eQWpheOaooeW8j+S8oOWFpeaYr+WQpuW8guatpeW4g+WwlOWAvFxyXG4gICAgICAgICAqL1xyXG4gICAgICAgIHBvc3Q6IGZ1bmN0aW9uIChpbnB1dCwgZGF0YSwgc3VjY2VzcywgbW9kdWxlLCBhc3luYykge1xyXG4gICAgICAgICAgICB2YXIgbmV3VXJsO1xyXG4gICAgICAgICAgICB2YXIgbmV3RGF0YTtcclxuICAgICAgICAgICAgdmFyIG5ld1N1Y2Nlc3M7XHJcbiAgICAgICAgICAgIHZhciBuZXdNb2R1bGUgPSAnREZMVCc7XHJcbiAgICAgICAgICAgIHZhciBuZXdBc3luYztcclxuICAgICAgICAgICAgaWYgKHR5cGVvZiBpbnB1dCA9PT0gJ29iamVjdCcpIHtcclxuICAgICAgICAgICAgICAgIGlmICh0eXBlb2YgaW5wdXQudXJsID09PSAnc3RyaW5nJykgbmV3VXJsID0gaW5wdXQudXJsO1xyXG4gICAgICAgICAgICAgICAgaWYgKHR5cGVvZiBpbnB1dC5kYXRhID09PSAnb2JqZWN0JyAmJiBpbnB1dC5kYXRhICE9PSBudWxsKSBuZXdEYXRhID0gaW5wdXQuZGF0YTtcclxuICAgICAgICAgICAgICAgIGlmICh0eXBlb2YgaW5wdXQuc3VjY2VzcyA9PT0gJ2Z1bmN0aW9uJykgbmV3U3VjY2VzcyA9IGlucHV0LnN1Y2Nlc3M7XHJcbiAgICAgICAgICAgICAgICBpZiAodHlwZW9mIGlucHV0Lm1vZHVsZSA9PT0gJ3N0cmluZycpIG5ld01vZHVsZSA9IGlucHV0Lm1vZHVsZTtcclxuICAgICAgICAgICAgICAgIGlmICh0eXBlb2YgaW5wdXQuYXN5bmMgPT09ICdib29sZWFuJykgbmV3QXN5bmMgPSBpbnB1dC5hc3luYztcclxuICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICBlbHNlIGlmICh0eXBlb2YgaW5wdXQgPT09ICdzdHJpbmcnKSB7XHJcbiAgICAgICAgICAgICAgICBuZXdVcmwgPSBpbnB1dDtcclxuICAgICAgICAgICAgICAgIGlmICh0eXBlb2YgZGF0YSA9PT0gJ29iamVjdCcgJiYgZGF0YSAhPT0gbnVsbCkgbmV3RGF0YSA9IGRhdGE7XHJcbiAgICAgICAgICAgICAgICBpZiAodHlwZW9mIHN1Y2Nlc3MgPT09ICdmdW5jdGlvbicpIG5ld1N1Y2Nlc3MgPSBzdWNjZXNzO1xyXG4gICAgICAgICAgICAgICAgaWYgKHR5cGVvZiBtb2R1bGUgPT09ICdzdHJpbmcnKSBuZXdNb2R1bGUgPSBtb2R1bGU7XHJcbiAgICAgICAgICAgICAgICBpZiAodHlwZW9mIGFzeW5jID09PSAnYm9vbGVhbicpIG5ld0FzeW5jID0gYXN5bmM7XHJcbiAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgZWxzZSB7XHJcbiAgICAgICAgICAgICAgICB0aHJvdyBFcnJvcign5Y+C5pWw5LiN5q2j56Gu77yM6K+35LulQUpBWOaWueW8j+Whq+WFpeWPguaVsOaIluehruS/neesrOS4gOS4quWPguaVsOS4ulVybOWcsOWdgCcpO1xyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgICAgIG5ld01vZHVsZSA9IHh1cnVpLmNvbmZpZy5odHRwLmFwaVtuZXdNb2R1bGVdIHx8IHh1cnVpLmNvbmZpZy5odHRwLmFwaS5ERkxUO1xyXG4gICAgICAgICAgICBuZXdNb2R1bGUuYWRkcmVzcyA9IG5ld01vZHVsZS5hZGRyZXNzIHx8IHh1cnVpLmNvbmZpZy5odHRwLmFwaS5ERkxULmFkZHJlc3M7XHJcbiAgICAgICAgICAgIG5ld01vZHVsZS5jb250ZW50VHlwZSA9IG5ld01vZHVsZS5jb250ZW50VHlwZSB8fCB4dXJ1aS5jb25maWcuaHR0cC5hcGkuREZMVC5jb250ZW50VHlwZTtcclxuICAgICAgICAgICAgbmV3TW9kdWxlLnJlcXVlc3REYXRhID0gbmV3TW9kdWxlLnJlcXVlc3REYXRhIHx8IHh1cnVpLmNvbmZpZy5odHRwLmFwaS5ERkxULnJlcXVlc3REYXRhO1xyXG4gICAgICAgICAgICBuZXdNb2R1bGUucmVzcG9uc2VEYXRhID0gbmV3TW9kdWxlLnJlc3BvbnNlRGF0YSB8fCB4dXJ1aS5jb25maWcuaHR0cC5hcGkuREZMVC5yZXNwb25zZURhdGE7XHJcbiAgICAgICAgICAgIHJldHVybiB4dXJ1aS5odHRwLmFqYXgoe1xyXG4gICAgICAgICAgICAgICAgdHlwZTogJ1BPU1QnLFxyXG4gICAgICAgICAgICAgICAgY29udGVudFR5cGU6IG5ld01vZHVsZS5jb250ZW50VHlwZSxcclxuICAgICAgICAgICAgICAgIGFzeW5jOiBuZXdBc3luYyxcclxuICAgICAgICAgICAgICAgIGRhdGE6IG5ld01vZHVsZS5yZXF1ZXN0RGF0YShuZXdEYXRhKSxcclxuICAgICAgICAgICAgICAgIHN1Y2Nlc3M6IGZ1bmN0aW9uIChkYXRhKSB7IG5ld1N1Y2Nlc3MobmV3TW9kdWxlLnJlc3BvbnNlRGF0YShkYXRhKSkgfSxcclxuICAgICAgICAgICAgICAgIHVybDogbmV3TW9kdWxlLmFkZHJlc3MgKyBuZXdVcmwsXHJcbiAgICAgICAgICAgIH0pO1xyXG4gICAgICAgIH1cclxuICAgIH0sXHJcblxyXG4gICAgLyoqXHJcbiAgICAgKiDmoIflh4ZodHRw6K+35rGC77yI57G7YWpheOeUqOazle+8jOWmguaenOaUueWPmOS6hmNvbnRlbnRUeXBl77yM6K+356Gu5L+dZGF0YeagvOW8j+ato+ehru+8iVxyXG4gICAgICogQHBhcmFtIHtPYmplY3R9IGlucHV0XHJcbiAgICAgKi9cclxuICAgIGFqYXg6IGZ1bmN0aW9uIChpbnB1dCkge1xyXG4gICAgICAgIGlmIChpbnB1dC5hc3luYyA9PSB1bmRlZmluZWQpIGlucHV0LmFzeW5jID0gdHJ1ZTtcclxuICAgICAgICBpbnB1dC5kYXRhID0gaW5wdXQuZGF0YSB8fCAnJztcclxuICAgICAgICBpbnB1dC5zdWNjZXNzID0gaW5wdXQuc3VjY2VzcyB8fCBmdW5jdGlvbiAoYSkgeyB9XHJcbiAgICAgICAgaW5wdXQuZXJyb3IgPSBpbnB1dC5lcnJvciB8fCBmdW5jdGlvbiAoYSkgeyB9XHJcbiAgICAgICAgaW5wdXQuY29tcGxldGUgPSBpbnB1dC5jb21wbGV0ZSB8fCBmdW5jdGlvbiAoYSkgeyB9XHJcbiAgICAgICAgaW5wdXQudXJsID0gaW5wdXQudXJsIHx8ICcnO1xyXG4gICAgICAgIGlucHV0LnR5cGUgPSBpbnB1dC50eXBlIHx8ICdHRVQnO1xyXG4gICAgICAgIGlmIChpbnB1dC5jb250ZW50VHlwZSA9PT0gdW5kZWZpbmVkKSB7XHJcbiAgICAgICAgICAgIHZhciBuZXdEYXRhID0gbmV3IEZvcm1EYXRhKCk7XHJcbiAgICAgICAgICAgIGZvciAobGV0IGtleSBpbiBpbnB1dC5kYXRhKSB7XHJcbiAgICAgICAgICAgICAgICBuZXdEYXRhLmFwcGVuZChrZXksIGlucHV0LmRhdGFba2V5XSk7XHJcbiAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgaW5wdXQuZGF0YSA9IG5ld0RhdGE7XHJcbiAgICAgICAgfVxyXG4gICAgICAgIGVsc2UgaWYgKGlucHV0LmNvbnRlbnRUeXBlLmluZGV4T2YoJ2FwcGxpY2F0aW9uL3gtd3d3LWZvcm0tdXJsZW5jb2RlZCcpICE9IC0xKSB7XHJcbiAgICAgICAgICAgIHZhciBuZXdEYXRhID0gJyc7XHJcbiAgICAgICAgICAgIGZvciAobGV0IGtleSBpbiBpbnB1dC5kYXRhKSB7XHJcbiAgICAgICAgICAgICAgICBuZXdEYXRhICs9IGtleSArICc9JyArIGlucHV0LmRhdGFba2V5XSArICcmJ1xyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgICAgIGlucHV0LmRhdGEgPSBlbmNvZGVVUkkobmV3RGF0YS5zdWJzdHJpbmcoMCwgbmV3RGF0YS5sZW5ndGggLSAxKSk7XHJcbiAgICAgICAgfVxyXG4gICAgICAgIHZhciB4aHIgPSBuZXcgWE1MSHR0cFJlcXVlc3QoKTtcclxuICAgICAgICB4aHIuYWRkRXZlbnRMaXN0ZW5lcignbG9hZCcsIGZ1bmN0aW9uIChlKSB7XHJcbiAgICAgICAgICAgIGlmIChlLnNyY0VsZW1lbnQuc3RhdHVzID09PSAyMDAgfHwgZS5zcmNFbGVtZW50LnN0YXR1cyA9PT0gMzA0KSB7XHJcbiAgICAgICAgICAgICAgICBpbnB1dC5zdWNjZXNzKGUuc3JjRWxlbWVudC5yZXNwb25zZSk7XHJcbiAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgZWxzZSB7XHJcbiAgICAgICAgICAgICAgICBpbnB1dC5lcnJvcihlLnNyY0VsZW1lbnQpO1xyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgfSk7XHJcbiAgICAgICAgeGhyLmFkZEV2ZW50TGlzdGVuZXIoJ2Vycm9yJywgZnVuY3Rpb24gKGUpIHtcclxuICAgICAgICAgICAgaW5wdXQuZXJyb3IoZS5zcmNFbGVtZW50KTtcclxuICAgICAgICB9KTtcclxuICAgICAgICB4aHIuYWRkRXZlbnRMaXN0ZW5lcignbG9hZGVuZCcsIGZ1bmN0aW9uIChlKSB7XHJcbiAgICAgICAgICAgIGlucHV0LmNvbXBsZXRlKGUuc3JjRWxlbWVudCk7XHJcbiAgICAgICAgfSk7XHJcbiAgICAgICAgeGhyLm9wZW4oaW5wdXQudHlwZSwgaW5wdXQudXJsLCBpbnB1dC5hc3luYyk7XHJcbiAgICAgICAgaWYgKGlucHV0LmNvbnRlbnRUeXBlICE9PSB1bmRlZmluZWQpIHhoci5zZXRSZXF1ZXN0SGVhZGVyKCdDb250ZW50LXR5cGUnLCBpbnB1dC5jb250ZW50VHlwZSk7XHJcbiAgICAgICAgeGhyLnNlbmQoaW5wdXQuZGF0YSk7XHJcbiAgICAgICAgcmV0dXJuIHhocjtcclxuICAgIH1cclxuXHJcbn07XHJcblxyXG5tYWluLmh0dHAgPSBodHRwO1xyXG5cclxuZnVuY3Rpb24gcHRva2VuQWRkKGlucHV0KSB7XHJcbiAgICB2YXIgcHRva2VuID0geHVydWkuY29va2llLmdldCgndG9rZW4nKTtcclxuICAgIGlmICh0eXBlb2YgaW5wdXQgPT09ICdvYmplY3QnICYmIHR5cGVvZiBpbnB1dC51cmwgPT09ICdzdHJpbmcnKSB7XHJcbiAgICAgICAgaW5wdXQudXJsID0gdXJsUXVlcnlBZGQoaW5wdXQudXJsLCAncHRva2VuJywgcHRva2VuKTtcclxuICAgIH1cclxuICAgIGVsc2UgaWYgKHR5cGVvZiBpbnB1dCA9PT0gJ3N0cmluZycpIHtcclxuICAgICAgICBpbnB1dCA9IHVybFF1ZXJ5QWRkKGlucHV0LCAncHRva2VuJywgcHRva2VuKTtcclxuICAgIH1cclxuICAgIHJldHVybiBpbnB1dDtcclxufVxyXG5cclxuZnVuY3Rpb24gdXJsUXVlcnlBZGQodXJsLCBrZXksIHZhbHVlKSB7XHJcbiAgICBpZiAodXJsLmluZGV4T2YoJz8nKSA9PSAtMSkgdXJsID0gdXJsICsgJz8nICsga2V5ICsgJz0nICsgdmFsdWU7XHJcbiAgICBlbHNlIHVybCA9IHVybC5yZXBsYWNlKHVybC5zcGxpdCgnPycpWzBdICsgJz8nLCB1cmwuc3BsaXQoJz8nKVswXSArICc/JyArIGtleSArICc9JyArIHZhbHVlICsgJyYnKTtcclxuICAgIHJldHVybiB1cmw7XHJcbn1cclxuXHJcbmV4cG9ydCBkZWZhdWx0IGh0dHA7XHJcbmV4cG9ydCB7IGh0dHAsIG1haW4gYXMgaHR0cE1haW4gfTsiLCJpbXBvcnQgbWFpbiBmcm9tIFwiLi4vbWFpbi5qc1wiO1xyXG5cclxuLyoqIOWhq+WFheWbvuagh++8iGNsYXNz77yJICovXHJcbnZhciBpbWFnZSA9IHtcclxuICAgIGljb246IHtcclxuICAgICAgICAvL+W4uOeUqOWbvuagh1xyXG4gICAgICAgIGljb25fY3VycmVudDogW1wiTTg3NiA2NEgxNDhjLTExLjA1IDAtMjAgOC45NS0yMCAyMHY4NTZjMCAxMS4wNSA4Ljk1IDIwIDIwIDIwaDcyOGMxMS4wNSAwIDIwLTguOTUgMjAtMjBWODRjMC0xMS4wNS04Ljk1LTIwLTIwLTIwek0yNTYgMjY2YzAtNS41MiA0LjQ4LTEwIDEwLTEwaDQ5MmM1LjUyIDAgMTAgNC40OCAxMCAxMHY0NGMwIDUuNTItNC40OCAxMC0xMCAxMEgyNjZjLTUuNTIgMC0xMC00LjQ4LTEwLTEwdi00NHogbS0wLjE3IDE5Mi4wMWMwLTUuNTIgNC40OC0xMCAxMC0xMGgyMzZjNS41MiAwIDEwIDQuNDggMTAgMTB2NDRjMCA1LjUyLTQuNDggMTAtMTAgMTBoLTIzNmMtNS41MiAwLTEwLTQuNDgtMTAtMTB2LTQ0eiBtNTAyLjggNzYuNDJsLTI4OC4xIDI4OC4xYy0wLjA0IDAuMDQtMC4wNyAwLjA3LTAuMSAwLjExLTguNTkgOC41OS0yMC44NSAxMS4yOC0zMS43NCA4LjA1LTQuOTUtMS40Ni05LjYxLTQuMTUtMTMuNTItOC4wNmwtMC4wNi0wLjA2LTE1OS42Mi0xNTkuNjJjLTEyLjUtMTIuNS0xMi41LTMyLjc2IDAtNDUuMjUgMTIuNS0xMi41IDMyLjc2LTEyLjUgNDUuMjUgMEw0NDcuOCA3NTQuNzVsMjY1LjU3LTI2NS41N2MxMi41LTEyLjUgMzIuNzYtMTIuNSA0NS4yNSAwIDEyLjUxIDEyLjUgMTIuNTEgMzIuNzYgMC4wMSA0NS4yNXpcIl0sXHJcbiAgICAgICAgaWNvbl9lZGl0OiBbXCJNOTYwLjM0MTE2MSA5NjEuNTM0MzkzYzAgMTcuODc0OTQ3LTEyLjUwMzM1NSAzMi40NTM2NjYtMjguMDEzMzI4IDMyLjQ1MzY2NmwtODQwLjQ2NjM0NiAwYy0xNS4zNzc5NiAwLTI3Ljg4MzM2MS0xNC41Nzg3MTktMjcuODgzMzYxLTMyLjQ1MzY2NmwwIDBjMC0xOC4wMDM4OSAxMi41MDU0MDItMzIuNDU0NjkgMjcuODgzMzYxLTMyLjQ1NDY5bDg0MC40NjYzNDYgMEM5NDcuODM3ODA2IDkyOS4wNzk3MDQgOTYwLjM0MTE2MSA5NDMuNTMwNTA0IDk2MC4zNDExNjEgOTYxLjUzNDM5M0w5NjAuMzQxMTYxIDk2MS41MzQzOTN6XCIsIFwiTTg1NS40ODYxMzIgMjcyLjczODUxMWMtMTIuMzgxNTc2IDEyLjYxNTkyNC0zMi43NjM3NDMgMTIuNjE1OTI0LTQ1LjI2NTA1MSAwbC0xMzUuNjgxNTYxLTEzNy42MjA4MTljLTEyLjQ0MDkzLTEyLjYwOTc4NC0xMi40NDA5My0zMy4yNzc0NjcgMC00NS44OTAzMjFsNDUuMjY1MDUxLTQ1Ljk1OTkwOWMxMi4zODM2MjItMTIuNjE1OTI0IDMyLjc2NDc2Ni0xMi42MTU5MjQgNDUuMjcwMTY4IDBsMTM1LjgwNzQzMyAxMzcuNjgzMjQ0YzEyLjM3ODUwNiAxMi42NzkzNzIgMTIuMzc4NTA2IDMzLjM0MDkxNSAwIDQ1Ljg5NDQxNUw4NTUuNDg2MTMyIDI3Mi43Mzg1MTF6XCIsIFwiTTM1Ny42NTk2MDIgNzc3LjU3NjA0N2MtMTIuMzgxNTc2IDEyLjU1MTQ1My0zMi43NjU3OSAxMi41NTE0NTMtNDUuMjY3MDk4IDBsLTEzNS44Njg4MzUtMTM3LjYxODc3MmMtMTIuNDQxOTU0LTEyLjYxNDkwMS0xMi40NDE5NTQtMzMuMjgxNTYxLTAuMDYyNDI1LTQ1Ljg5MjM2OGw0MDcuNDc3NTYxLTQxMy4xMTQyMDJjMTIuNDM5OTA3LTEyLjU1MDQyOSAzMi44MjYxNjgtMTIuNTUwNDI5IDQ1LjI2NjA3NCAwbDEzNS43NDM5ODUgMTM3LjY4MjIyYzEyLjUwNzQ0OCAxMi42ODAzOTUgMTIuNTA3NDQ4IDMzLjM0NTAwOSAwIDQ1Ljg5NjQ2MUwzNTcuNjU5NjAyIDc3Ny41NzYwNDd6XCIsIFwiTTEzMS4xODkwMzEgNjg1Ljg0OTY0M2MtMTIuNDM3ODYtMTIuNjEwODA3LTI1LjQ0NDcwNi04LjYxNjY1Mi0yOC44ODIxNTYgOC44NzY1ODRsLTMyLjc2Mzc0MyAxNjUuODkyMDMyYy0zLjQ0MDUyIDE3LjQ5NDI1OSA3Ljg3ODgxMiAyOC45MDQ2NyAyNS4xMzU2NTMgMjUuNDIwMTQ1bDE2My41NjQ5MjItMzMuMDkyMjRjMTcuMjU2ODQtMy40ODc1OTUgMjEuMTI5MjE3LTE2LjY2OTQzNCA4Ljc1Mzc4MS0yOS4zNDk4M0wxMzEuMTg5MDMxIDY4NS44NDk2NDN6XCJdLFxyXG4gICAgICAgIGljb25fZnVuYzogW1wiTTQ2Ny41MSA1MTkuMTVsLTMwNC0xNjUuODNjLTE1Ljk5LTguNzItMzUuNDkgMi44NS0zNS40OSAyMS4wN3YzNzkuMzZjMCA4Ljc4IDQuOCAxNi44NiAxMi41MSAyMS4wN2wzMDQgMTY1LjgzYzE1Ljk5IDguNzIgMzUuNDktMi44NSAzNS40OS0yMS4wN1Y1NDAuMjJjMC04Ljc4LTQuOC0xNi44Ni0xMi41MS0yMS4wN3ogbS04My40OSA2NS42MmMwIDguMjgtOC44NiAxMy41NC0xNi4xMyA5LjU4TDIyOS43IDUxOC45NmMtMy41LTEuOTEtNS42OC01LjU4LTUuNjgtOS41OHYtMjcuODFjMC04LjI4IDguODYtMTMuNTQgMTYuMTMtOS41OGwxMzguMTggNzUuMzhjMy41IDEuOTEgNS42OCA1LjU4IDUuNjggOS41OHYyNy44MnpNNTczLjU1IDk0My44OGwzMTItMTcwLjJhMjAuMDA0IDIwLjAwNCAwIDAgMCAxMC40Mi0xNy41NlYzNjcuNjVjMC0xNS4xOC0xNi4yNS0yNC44My0yOS41OC0xNy41NmwtMzEyIDE3MC4yYTIwLjAwNCAyMC4wMDQgMCAwIDAtMTAuNDIgMTcuNTZ2Mzg4LjQ3YzAgMTUuMTggMTYuMjUgMjQuODMgMjkuNTggMTcuNTZ6TTUwMi40MyA0NzYuMzdMMTYwLjQ0IDI5MS4xNWMtMTMuOTctNy41Ni0xMy45Ny0yNy42MSAwLTM1LjE3TDUwMi40NiA3MC42OWExOS45OTEgMTkuOTkxIDAgMCAxIDE5LjA1IDBMODYzLjUgMjU1LjkyYzEzLjk3IDcuNTYgMTMuOTcgMjcuNjEgMCAzNS4xN0w1MjEuNDggNDc2LjM3YTE5Ljk5MSAxOS45OTEgMCAwIDEtMTkuMDUgMHpcIl0sXHJcbiAgICAgICAgaWNvbl9ub3RpY2U6IFtcIk04NzYgMTI4aC04OC40M2MtMTAuNSAwLjE3LTE5LjAzIDguNDQtMTkuNjIgMTguODItMC4wMyAwLjM5LTAuMDQgMC43OC0wLjA0IDEuMTctMC45NyAyMC41Ny05LjcxIDM5LjExLTIzLjM0IDUyLjc0LTE0LjQ4IDE0LjQ4LTM0LjQ4IDIzLjQzLTU2LjU3IDIzLjQzSDMzNmMtNDMuMjQgMC03OC40OC0zNC4zMS03OS45NS03Ny4yLTAuNTMtMTAuNDUtOS4wOC0xOC43OS0xOS42My0xOC45NkgxNDhjLTExLjA0IDAtMjAgOC45NS0yMCAyMHY3OTJjMCAxMS4wNSA4Ljk2IDIwIDIwIDIwaDcyOGMxMS4wNSAwIDIwLTguOTUgMjAtMjBWMTQ4YzAtMTEuMDUtOC45NS0yMC0yMC0yMHpNNzY4IDc5MC4yMWMwIDUuNTItNC40OCAxMC0xMCAxMEgyNjZjLTUuNTIgMC0xMC00LjQ4LTEwLTEwdi00NGMwLTUuNTIgNC40OC0xMCAxMC0xMGg0OTJjNS41MiAwIDEwIDQuNDggMTAgMTB2NDR6IG0wLTE5MmMwIDUuNTItNC40OCAxMC0xMCAxMEgyNjZjLTUuNTIgMC0xMC00LjQ4LTEwLTEwdi00NGMwLTUuNTIgNC40OC0xMCAxMC0xMGg0OTJjNS41MiAwIDEwIDQuNDggMTAgMTB2NDR6IG0wLTE5Mi4wMWMwIDUuNTItNC40OCAxMC0xMCAxMEgyNjZjLTUuNTIgMC0xMC00LjQ4LTEwLTEwdi00NGMwLTUuNTIgNC40OC0xMCAxMC0xMGg0OTJjNS41MiAwIDEwIDQuNDggMTAgMTB2NDR6XCIsIFwiTTYyNCAxNjAuMTdINDAwYy0yNi41MSAwLTQ4LTIxLjQ5LTQ4LTQ4czIxLjQ5LTQ4IDQ4LTQ4aDIyNGMyNi41MSAwIDQ4IDIxLjQ5IDQ4IDQ4cy0yMS40OSA0OC00OCA0OHpNMjM2LjQyIDEyOGgtMC42OGMwLjExLTAuMDEgMC4yMy0wLjAxIDAuMzQtMC4wMSAwLjExIDAgMC4yMyAwIDAuMzQgMC4wMXpcIiwgXCJNNzg4LjI1IDEyOGgtMC42OGMwLjExLTAuMDEgMC4yMy0wLjAxIDAuMzQtMC4wMSAwLjExIDAgMC4yMyAwIDAuMzQgMC4wMXpcIl0sXHJcbiAgICAgICAgaWNvbl9sb2NrOiBbXCJNNzg0LjAxIDMzNmMtMjYuNTEgMC00OCAyMS40OS00OCA0OHMyMS40OSA0OCA0OCA0OCA0OC0yMS40OSA0OC00OC0yMS40OS00OC00OC00OHpcIiwgXCJNODc2LjAxIDQ4Mi41N2gtNTg4di05OC40NGMwLTU5LjgzIDIzLjMtMTE2LjA4IDY1LjYxLTE1OC4zOSA0Mi4zMS00Mi4zMSA5OC41Ni02NS42MSAxNTguMzktNjUuNjEgNTkuODMgMCAxMTYuMDggMjMuMyAxNTguMzkgNjUuNjEgNDIuMzEgNDIuMzEgNjUuNjEgOTguNTYgNjUuNjEgMTU4LjM5aDk2YzAtMTc2LjczLTE0My4yNy0zMjAtMzIwLTMyMHMtMzIwIDE0My4yNy0zMjAgMzIwdjk4LjQ0SDE0OC43Yy0xMSAwLTIwIDktMjAgMjB2NDM3LjZjMCAxMSA5IDIwIDIwIDIwaDcyNy4zMmMxMSAwIDIwLTkgMjAtMjB2LTQzNy42Yy0wLjAxLTExLTkuMDEtMjAtMjAuMDEtMjB6TTU0NCA3NTkuNzV2MTI0LjI2YzAgNi42LTUuNCAxMi0xMiAxMmgtNDBjLTYuNiAwLTEyLTUuNC0xMi0xMlY3NTkuNzVjLTE5LjE4LTExLjA4LTMyLjA5LTMxLjc4LTMyLjA5LTU1LjUyIDAtMzUuNCAyOC42OS02NC4wOSA2NC4wOS02NC4wOXM2NC4wOSAyOC42OSA2NC4wOSA2NC4wOWMwIDIzLjczLTEyLjkxIDQ0LjQ0LTMyLjA5IDU1LjUyelwiXSxcclxuICAgICAgICBpY29uX2hvbWU6IFtcIk02My45NyA0MDMuNTJ2Mi4wNmMtMC4wMS0wLjM0LTAuMDEtMC42OC0wLjAxLTEuMDNzMC0wLjY5IDAuMDEtMS4wM3pNOTU5Ljk4IDQwNC41M2MwIDAuMzUgMCAwLjY5LTAuMDEgMS4wM3YtMi4wNmMwLjAxIDAuMzQgMC4wMSAwLjY4IDAuMDEgMS4wM3pcIiwgXCJNOTU0LjMyIDM4My45NmE0MC4wOCA0MC4wOCAwIDAgMC0xMC4yLTExLjM0bC0xLjc1LTEuMjZjLTAuMDQtMC4wMi0wLjA4LTAuMDUtMC4xMi0wLjA4TDUzNS45MyA4MS4wNmMtMC4wOS0wLjA3LTAuMTgtMC4xMy0wLjI3LTAuMmwtMS4yMS0wLjg2YTAuNTU1IDAuNTU1IDAgMCAxLTAuMDgtMC4wNkEzOS44NTUgMzkuODU1IDAgMCAwIDUxMiA3My4xMWMtOC4yOSAwLTE1Ljk4IDIuNTItMjIuMzcgNi44My0wLjAyIDAuMDItMC4wNSAwLjA0LTAuMDggMC4wNmwtMS4yIDAuODZjLTAuMSAwLjA2LTAuMTkgMC4xMy0wLjI4IDAuMkw4MC45MiAzNzEuODhhMC45OSAwLjk5IDAgMCAwLTAuMTcgMC4xMSA0MC4xNDIgNDAuMTQyIDAgMCAwLTExLjA2IDExLjk3QTM5Ljc2NiAzOS43NjYgMCAwIDAgNjQgNDAzLjUydjIyNy44NGMtMC4wMSAwLjM0LTAuMDEgMC42OC0wLjAxIDEuMDN2Mjg3LjU3YzAgMC4xMiAwLjAxIDAuMjQgMC4wMSAwLjM3djE5LjYzYzAgMTEuMDUgOC45NSAyMCAyMCAyMEgzNjMuNTljMTEuMDUgMCAyMC04Ljk1IDIwLTIwVjY1Mi4wMWMwLTYuNiA1LjQtMTIgMTItMTJoMjMyLjQyYzYuNiAwIDEyIDUuNCAxMiAxMnYyOTIuNDRjMCAxMS4wNSA4Ljk1IDIwIDIwIDIwSDkzOS42YzExLjA1IDAgMjAtOC45NSAyMC0yMHYtMTguOTJjMC4yNS0xLjgyIDAuMzktMy42OCAwLjM5LTUuNTdWNzQwLjQ3aDAuMDFWNDAzLjVhMzkuNzEzIDM5LjcxMyAwIDAgMC01LjY4LTE5LjU0elwiXSxcclxuICAgICAgICBpY29uX2NvbmZpZzogW1wiTTk0My44OSA0NDIuNjRsLTExMC43LTM2LjljLTAuMDMtMC4wOC0wLjA2LTAuMTYtMC4wOC0wLjI1LTEzLjE0LTMuOTgtMjIuNzEtMTYuMTgtMjIuNzEtMzAuNjMgMC02LjQ1IDEuOTItMTIuNDUgNS4yLTE3LjQ4bDUwLjg4LTEwMS43NmEyMy41NTkgMjMuNTU5IDAgMCAwLTQuNDEtMjcuMmwtNjYuNDktNjYuNDlhMjMuNTU5IDIzLjU1OSAwIDAgMC0yNy4yLTQuNDFsLTEwNC40OSA1Mi4yNGMtMC4wNC0wLjAyLTAuMDktMC4wNC0wLjEzLTAuMDctMTIuMSA2LjQ3LTI3LjQ5IDQuNi0zNy43LTUuNjFhMzEuODMgMzEuODMgMCAwIDEtOC42OC0xNi4wNGwtMzYtMTA3LjkxYTIzLjU2NyAyMy41NjcgMCAwIDAtMjIuMzYtMTYuMTFoLTk0LjA0Yy0xMC4xNCAwLTE5LjE1IDYuNDktMjIuMzYgMTYuMTFsLTM2LjkzIDExMC44Yy0wLjEgMC4wMy0wLjE5IDAuMDctMC4yOSAwLjEtNC4wNiAxMy4wMS0xNi4yIDIyLjQ2LTMwLjU1IDIyLjQ2LTYuMTYgMC0xMS45MS0xLjc1LTE2LjgtNC43NmwtMTAyLjM5LTUxLjJhMjMuNTU5IDIzLjU1OSAwIDAgMC0yNy4yIDQuNDFsLTY2LjQ5IDY2LjQ5YTIzLjU1OSAyMy41NTkgMCAwIDAtNC40MSAyNy4ybDUyLjI4IDEwNC41NmMtMC4wNSAwLjEtMC4wOSAwLjE5LTAuMTQgMC4yOSA2LjMyIDEyLjA3IDQuNDEgMjcuMzItNS43MyAzNy40NmEzMS44MzEgMzEuODMxIDAgMCAxLTE1LjMzIDguNTNMODAuMTIgNDQyLjY0QTIzLjU2MyAyMy41NjMgMCAwIDAgNjQgNDY1djk0LjA0YzAgMTAuMTQgNi40OSAxOS4xNSAxNi4xMSAyMi4zNmwxMTAuODUgMzYuOTVjMC4wMyAwLjA4IDAuMDYgMC4xNiAwLjA4IDAuMjQgMTMuMDIgNC4wNSAyMi40OCAxNi4yIDIyLjQ4IDMwLjU2IDAgNi4yMi0xLjc4IDEyLjAyLTQuODUgMTYuOTNsLTUxLjEzIDEwMi4yNmEyMy41NTkgMjMuNTU5IDAgMCAwIDQuNDEgMjcuMmw2Ni40OSA2Ni40OWEyMy41NTkgMjMuNTU5IDAgMCAwIDI3LjIgNC40MWwxMDQuNDktNTIuMjUgMC4yNCAwLjEyYzEyLjExLTYuNDcgMjcuNDktNC42IDM3LjcgNS42MSA0LjggNC44IDcuNzUgMTAuNzQgOC44NiAxNi45NWwzNS42NyAxMDcuMDJBMjMuNTY3IDIzLjU2NyAwIDAgMCA0NjQuOTYgOTYwSDU1OWMxMC4xNCAwIDE5LjE1LTYuNDkgMjIuMzYtMTYuMTFsMzYuOTItMTEwLjc1YzAuMS0wLjAzIDAuMTktMC4wNyAwLjI4LTAuMSAzLjk4LTEzLjE0IDE2LjE4LTIyLjcxIDMwLjYzLTIyLjcxIDYuNjggMCAxMi44OSAyLjA1IDE4LjAyIDUuNTZsMTAxLjEzIDUwLjU2YTIzLjU1OSAyMy41NTkgMCAwIDAgMjcuMi00LjQxbDY2LjQ5LTY2LjQ5YTIzLjU1OSAyMy41NTkgMCAwIDAgNC40MS0yNy4ybC01Mi4yMS0xMDQuNDEgMC4xMi0wLjI0Yy02LjQ3LTEyLjExLTQuNi0yNy40OSA1LjYxLTM3LjdhMzEuODYgMzEuODYgMCAwIDEgMTYuNDYtOC43N2wxMDcuNDQtMzUuODFhMjMuNTY3IDIzLjU2NyAwIDAgMCAxNi4xMS0yMi4zNlY0NjVjMC4wMy0xMC4xNC02LjQ2LTE5LjE1LTE2LjA4LTIyLjM2ek01MTIuMDcgNjQwLjAxYy03MC42OSAwLTEyOC01Ny4zMS0xMjgtMTI4czU3LjMxLTEyOCAxMjgtMTI4IDEyOCA1Ny4zMSAxMjggMTI4LTU3LjMxIDEyOC0xMjggMTI4elwiXSxcclxuICAgICAgICBpY29uX3NlYXJjaDogW1wiTTk1Ny45MiA5MTIuNjdMNzk1LjgzIDc1MC41OGM2Mi4zMS03Mi43MiA5OS45NS0xNjcuMTkgOTkuOTUtMjcwLjQ2IDAtMjI5LjY5LTE4Ni4yLTQxNS44OS00MTUuODktNDE1Ljg5UzY0IDI1MC40MyA2NCA0ODAuMTJzMTg2LjIgNDE1Ljg5IDQxNS44OSA0MTUuODljMTAzLjM4IDAgMTk3Ljk1LTM3LjczIDI3MC43LTEwMC4xNmwxNjIuMDcgMTYyLjA3YzEuOTQgMS45NCA0LjUxIDIuOTIgNy4wNyAyLjkyczUuMTMtMC45NyA3LjA3LTIuOTJsMzEuMTEtMzEuMTFjMy45LTMuODkgMy45LTEwLjI1IDAuMDEtMTQuMTR6TTYxNi44NSA4MDQuMzhjLTQzLjM0IDE4LjMzLTg5LjQyIDI3LjYzLTEzNi45NSAyNy42My00Ny41MyAwLTkzLjYxLTkuMy0xMzYuOTUtMjcuNjMtNDEuOS0xNy43Mi03OS41My00My4xLTExMS44Ny03NS40NC0zMi4zNC0zMi4zNC01Ny43Mi02OS45OC03NS40NC0xMTEuODdDMTM3LjMgNTczLjczIDEyOCA1MjcuNjUgMTI4IDQ4MC4xMmMwLTQ3LjUzIDkuMy05My42MSAyNy42My0xMzYuOTUgMTcuNzItNDEuOSA0My4xLTc5LjU0IDc1LjQ0LTExMS44NyAzMi4zNC0zMi4zNCA2OS45OC01Ny43MiAxMTEuODctNzUuNDQgNDMuMzQtMTguMzMgODkuNDItMjcuNjMgMTM2Ljk1LTI3LjYzIDQ3LjUzIDAgOTMuNjEgOS4zIDEzNi45NSAyNy42MyA0MS45IDE3LjcyIDc5LjUzIDQzLjEgMTExLjg3IDc1LjQ0IDMyLjM0IDMyLjM0IDU3LjcyIDY5Ljk4IDc1LjQ0IDExMS44NyAxOC4zMyA0My4zNCAyNy42MyA4OS40MiAyNy42MyAxMzYuOTUgMCA0Ny41My05LjMgOTMuNjEtMjcuNjMgMTM2Ljk1LTE3LjcyIDQxLjktNDMuMSA3OS41My03NS40NCAxMTEuODctMzIuMzMgMzIuMzQtNjkuOTcgNTcuNzItMTExLjg2IDc1LjQ0elwiXSxcclxuICAgICAgICBpY29uX2FkZDogW1wiTTk0MC4wMSA0ODAuMDFINTQ0Vjg0YzAtMTEuMDUtOC45NS0yMC0yMC0yMGgtMjRjLTExLjA1IDAtMjAgOC45NS0yMCAyMHYzOTYuMDFIODRjLTExLjA1IDAtMjAgOC45NS0yMCAyMHYyNGMwIDExLjA1IDguOTUgMjAgMjAgMjBoMzk2djM5Ni4wMWMwIDExLjA1IDguOTUgMjAgMjAgMjBoMjRjMTEuMDUgMCAyMC04Ljk1IDIwLTIwVjU0NC4wMWgzOTYuMDFjMTEuMDUgMCAyMC04Ljk1IDIwLTIwdi0yNGMwLTExLjA1LTguOTUtMjAtMjAtMjB6XCJdLFxyXG4gICAgICAgIGljb25fcmVmcmVzaDogW1wiTTUxMiA5MTkuNTUyYy0yMjQuNzY4IDAtNDA3LjU1Mi0xODIuNzg0LTQwNy41NTItNDA3LjU1MiAwLTguNzA0IDAuNTEyLTE3LjQwOCAxLjAyNC0yNi4xMTJsNzEuNjggNC42MDhjLTAuNTEyIDcuMTY4LTAuNTEyIDE0LjMzNi0wLjUxMiAyMS41MDQgMCAxODUuMzQ0IDE1MC41MjggMzM1Ljg3MiAzMzUuODcyIDMzNS44NzIgODYuNTI4IDAgMTY4LjQ0OC0zMi43NjggMjMwLjkxMi05Mi4xNmw0OS4xNTIgNTIuMjI0QzcxNi4yODggODgwLjEyOCA2MTYuOTYgOTE5LjU1MiA1MTIgOTE5LjU1MnpNOTE5LjU1MiA1MTJoLTcxLjY4YzAtMTEuNzc2LTAuNTEyLTIzLjU1Mi0yLjA0OC0zNS4zMjgtMTcuOTItMTcxLjUyLTE2MS4yOC0zMDAuNTQ0LTMzNC4zMzYtMzAwLjU0NC02Ny41ODQgMC0xMzIuMDk2IDE5Ljk2OC0xODcuOTA0IDU3LjM0NEwyODQuMTYgMTc0LjA4YzY3LjA3Mi00NS41NjggMTQ1LjkyLTY5LjYzMiAyMjcuODQtNjkuNjMyIDIwOS40MDggMCAzODQgMTU2LjY3MiA0MDUuNTA0IDM2NS4wNTYgMS41MzYgMTMuODI0IDIuMDQ4IDI4LjE2IDIuMDQ4IDQyLjQ5NnpcIiwgXCJNMTQwLjI4OCAyOTAuODE2TDI4LjE2IDQ5MS41MmMtMy4wNzIgNS4xMiAxLjAyNCAxMS43NzYgNi42NTYgMTEuNzc2SDI1OC41NmM2LjE0NCAwIDkuNzI4LTYuMTQ0IDYuNjU2LTExLjc3NkwxNTMuNiAyOTAuODE2Yy0zLjA3Mi01LjYzMi0xMC43NTItNS42MzItMTMuMzEyIDB6TTg3MC40IDY3NS44NEw3NTguMjcyIDQ3NS4xMzZjLTMuMDcyLTUuMTIgMS4wMjQtMTEuNzc2IDYuNjU2LTExLjc3NmgyMjMuNzQ0YzYuMTQ0IDAgOS43MjggNi4xNDQgNi42NTYgMTEuNzc2TDg4My43MTIgNjc1Ljg0Yy0yLjU2IDUuMTItMTAuMjQgNS4xMi0xMy4zMTIgMHpNMjcwLjMzNiAyMDIuMjRhMzUuODQgMzUuODQgMCAxIDAgNzEuNjggMCAzNS44NCAzNS44NCAwIDEgMC03MS42OCAwek03MjguNTc2IDc4NC44OTZhMzUuODQgMzUuODQgMCAxIDAgNzEuNjggMCAzNS44NCAzNS44NCAwIDEgMC03MS42OCAwelwiXSxcclxuICAgICAgICBpY29uX2xpc3Q6IFtcIk04MS4yOCAyMjIuMDE2aDg2MS40NGMyNy4yNjQgMCA0OS4yOC0yMS41MDQgNDkuMjgtNDhzLTIyLjAxNi00OC00OS4yOC00OEg4MS4yOGMtMjcuMiAwLTQ5LjI4IDIxLjUwNC00OS4yOCA0OHMyMi4wOCA0OCA0OS4yOCA0OHpNOTQyLjcyIDQ2Mi4wMTZIODEuMjhjLTI3LjI2NCAwLTQ5LjI4IDIxLjUwNC00OS4yOCA0OHMyMi4wMTYgNDggNDkuMjggNDhoODYxLjQ0YzI3LjI2NCAwIDQ5LjI4LTIxLjUwNCA0OS4yOC00OHMtMjIuMTQ0LTQ4LTQ5LjI4LTQ4ek05NDIuNzIgODAxLjk4NEg4MS4yOGMtMjcuMiAwLTQ5LjI4IDIxLjUwNC00OS4yOCA0OHMyMi4wOCA0OCA0OS4yOCA0OGg4NjEuNDRjMjcuMjY0IDAgNDkuMjgtMjEuNTA0IDQ5LjI4LTQ4cy0yMi4wMTYtNDgtNDkuMjgtNDh6XCJdLFxyXG4gICAgICAgIGljb25fY2xvc2U6IFtcIk01NjMuMyA1MDlsMzUyLjMtMzUyLjNjMTMuOS0xMy45IDEzLjktMzYuNCAwLTUwLjMtMTMuOS0xMy45LTM2LjQtMTMuOS01MC4zIDBMNTEzIDQ1OC43IDE2MC43IDEwNi40Yy0xMy45LTEzLjktMzYuNC0xMy45LTUwLjMgMC0xMy45IDEzLjktMTMuOSAzNi40IDAgNTAuM0w0NjIuNyA1MDkgMTEwLjQgODYxLjNjLTEzLjkgMTMuOS0xMy45IDM2LjQgMCA1MC4zIDYuOSA2LjkgMTYuMSAxMC40IDI1LjIgMTAuNHMxOC4yLTMuNSAyNS4yLTEwLjRMNTEzIDU1OS4zbDM1Mi4zIDM1Mi4zYzYuOSA2LjkgMTYuMSAxMC40IDI1LjIgMTAuNHMxOC4yLTMuNSAyNS4yLTEwLjRjMTMuOS0xMy45IDEzLjktMzYuNCAwLTUwLjNMNTYzLjMgNTA5elwiXSxcclxuICAgICAgICBpY29uX2xlZnQ6IFtcIk03MzUuMjA4NjY1IDY1LjU4MjY3MWwtNDQ2LjQxNzMzIDQ0Ni40MTczMjkgNDQ2LjQxNzMzIDQ0Ni40MTczMjl6XCJdLFxyXG4gICAgICAgIGljb25fcmlnaHQ6IFtcIk0yODguNzkxMzM1IDY1LjU4MjY3MWw0NDYuNDE3MzMgNDQ2LjQxNzMyOS00NDYuNDE3MzMgNDQ2LjQxNzMyOXpcIl0sXHJcbiAgICAgICAgaWNvbl9yZXN1bWU6IFtcIk0xMDI0IDg5Ni4wNjRjMCAwLTc2LjgtNTU0LjY4OC01NzYtNTU0LjY4OEw0NDggMTI4IDAgNTExLjkzNiA0NDggODcwLjQgNDQ4IDYyNC4zMkM3MTguOTEyIDYyNC4zMiA4ODIuNjg4IDY0Ny45MzYgMTAyNCA4OTYuMDY0TDEwMjQgODk2LjA2NCAxMDI0IDg5Ni4wNjR6TTEwMjQgODk2LjA2NFwiXSxcclxuICAgICAgICBpY29uX3NjYW46IFtcIk05MzUuMjI3IDU0NC4wNDZIODkuNTM2Yy0xMy43NDggMC0yNC44NzMtMTQuMjc1LTI0Ljg3My0zMS44NzkgMC0xNy42MDYgMTEuMTI1LTMxLjg4IDI0Ljg3My0zMS44OGg4NDUuNjkxYzEzLjc0OCAwIDI0Ljg3NCAxNC4yNzQgMjQuODc0IDMxLjg4IDAgMTcuNjA0LTExLjEyNiAzMS44NzktMjQuODc0IDMxLjg3OXogbS03MC42Mi0zNTguMjM5YzAtMTMuNzM2LTExLjEyNi0yNC44NzMtMjQuODc0LTI0Ljg3M0g2NzEuNjIxVjk4LjE4OGgyMDUuOTg2YzI3LjQ3MyAwIDQ5Ljc0NiAyMi4yNzQgNDkuNzQ2IDQ5Ljc0N1YzNTIuOTJoLTYyLjc0NlYxODUuODA3eiBtLTcwNS40NTEgMFYzNTIuOTJIOTkuNDA5VjE0Ny45MzRjMC0yNy40NzIgMjIuMjc0LTQ5Ljc0NyA0OS43NDctNDkuNzQ3aDE5OC45ODZ2NjIuNzQ3SDE4NC4wMjljLTEzLjc0OCAwLTI0Ljg3MyAxMS4xMzctMjQuODczIDI0Ljg3M3ogbTAgNjUyLjcwNWMwIDEzLjczNiAxMS4xMjUgMjQuODc0IDI0Ljg3MyAyNC44NzRoMTY0LjExM3Y2NC43NDZIMTQ4LjE1NmMtMjcuNDcyIDAtNDkuNzQ3LTIyLjI3NC00OS43NDctNDkuNzQ2VjY2Ny4zOTloNjAuNzQ3djE3MS4xMTN6IG03MDUuNDUxIDBWNjY3LjM5OWg2Mi43NDZ2MjEwLjk4NmMwIDI3LjQ3Mi0yMi4yNzMgNDkuNzQ2LTQ5Ljc0NiA0OS43NDZINjcxLjYyMXYtNjQuNzQ2aDE2OC4xMTJjMTMuNzQ4IDAuMDAxIDI0Ljg3NC0xMS4xMzcgMjQuODc0LTI0Ljg3M3pcIl0sXHJcbiAgICAgICAgaWNvbl9rZXkxMzogW1wiTTc5My4zIDE5MS44aC0xODVjLTE3LjcgMC0zMiAxNC4zLTMyIDMyczE0LjMgMzIgMzIgMzJoMTg0LjljNC42IDAgOC40IDMuOCA4LjQgOC40djMwMy4xYzAgNC42LTMuOCA4LjQtOC40IDguNGgtNTA3TDQ1OCA0MDMuOWMxMi41LTEyLjUgMTIuNS0zMi44IDAtNDUuM3MtMzIuOC0xMi41LTQ1LjMgMEwyMTMuMiA1NTguM2MtMTMuMSAxMy4xLTIwLjMgMzAuNS0yMC4zIDQ5czcuMiAzNS45IDIwLjMgNDlsMjAxLjQgMjAxLjRjNi4yIDYuMiAxNC40IDkuNCAyMi42IDkuNCA4LjIgMCAxNi40LTMuMSAyMi42LTkuNCAxMi41LTEyLjUgMTIuNS0zMi44IDAtNDUuM0wyODcuMiA2MzkuN2g1MDYuMWMzOS45IDAgNzIuNC0zMi41IDcyLjQtNzIuNFYyNjQuMmMwLTM5LjktMzIuNS03Mi40LTcyLjQtNzIuNHpcIl0sXHJcbiAgICAgICAgaWNvbl9zZWFyY2gyOiBbXCJNNzgxLjcgNzI4bC0xMy42IDEzLjYtMTAyLTEwMmM1NC43LTYxLjEgODguMy0xNDEuNiA4OC4zLTIzMC4xQzc1NC40IDIxOC43IDU5OS43IDY0IDQwOC45IDY0UzYzLjQgMjE4LjcgNjMuNCA0MDkuNSAyMTguMSA3NTUgNDA4LjkgNzU1Yzg4LjUgMCAxNjguOS0zMy42IDIzMC4xLTg4LjNsMTAyIDEwMi0xMy42IDEzLjYgMTc3LjEgMTc3LjEgNTQuMy01NC4zTDc4MS43IDcyOHogbS02ODAtMzE4LjZjMC0xNjkuMyAxMzcuOC0zMDcuMSAzMDcuMS0zMDcuMXMzMDcuMSAxMzcuOCAzMDcuMSAzMDcuMS0xMzcuOCAzMDcuMS0zMDcuMSAzMDcuMWMtMTY5LjMgMC4xLTMwNy4xLTEzNy43LTMwNy4xLTMwNy4xelwiXSxcclxuICAgICAgICBpY29uX29rOiBbXCJNMzQ2LjU5NTM0NCA2ODQuNDk1NjU2IDEzNS43NzQ4MjUgNDczLjY3NTEzNmwtNzEuNDkyMjY0IDcxLjQ0NzIzOSAyODIuMzEyNzg0IDI4Mi4yNjg3ODIgNjA2LjQwNjEzNy02MDYuMzU4MDQxLTcxLjQ0NzIzOS03MS40OTIyNjRMMzQ2LjU5NTM0NCA2ODQuNDk1NjU2elwiXSxcclxuICAgICAgICBpY29uX3RyYXNoOiBbXCJNNTExLjk5ODk3NyA4MzcuOTU5ODYzYzExLjI0MTAxOSAwIDIwLjM3MzAwMy05LjEwMjMwOSAyMC4zNzMwMDMtMjAuMzczMDAzTDUzMi4zNzE5OCAzMjguNjQ4MDg5YzAtMTEuMjU5NDM4LTkuMTMwOTYxLTIwLjM3MTk4LTIwLjM3MzAwMy0yMC4zNzE5OC0xMS4yNDIwNDIgMC0yMC4zNzMwMDMgOS4xMTI1NDItMjAuMzczMDAzIDIwLjM3MTk4bDAgNDg4LjkzOTc5NUM0OTEuNjI1OTc0IDgyOC44NTc1NTUgNTAwLjc1NjkzNSA4MzcuOTU5ODYzIDUxMS45OTg5NzcgODM3Ljk1OTg2M002MzMuNTM3MDU0IDgzNy45MzkzOTdjMTEuMjY5NjcxIDAuNDI3NzQyIDIwLjcwMDQ2MS04LjM2NDUwNSAyMS4xMDk3ODQtMTkuNjE2NzhsMjkuNTQxODI3LTQ4OC4zODEwN2MwLjQwOTMyMi0xMS4yNTEyNTItOC4zNzQ3MzgtMjAuNzAwNDYxLTE5LjYyNDk2Ni0yMS4xMjgyMDMtMTEuMjIwNTUyLTAuMzg4ODU2LTIwLjY3MTgwOSA4LjM5NTIwNC0yMS4wNzkwODQgMTkuNjM1MTk5bC0yOS41NjQzMzkgNDg4LjQxMzgxNUM2MTMuNTEyOTk4IDgyOC4xMDEzMzEgNjIyLjMxNTQ3OCA4MzcuNTMyMTIxIDYzMy41MzcwNTQgODM3LjkzOTM5N00zOTAuNTIwMjUxIDgzNy45NTk4NjNjMTEuMjQyMDQyLTAuNDI3NzQyIDIwLjAwMzU5LTkuODU4NTMyIDE5LjYxNjc4LTIxLjExNzk3bC0zMC4wMTA1MDEtNDg4LjM5MzM0OWMtMC40MDkzMjItMTEuMjM5OTk1LTkuODU4NTMyLTIwLjAwMzU5LTIxLjA5OTU1MS0xOS42MTY3OC0xMS4yNDkyMDUgMC40Mjc3NDItMjAuMDM0Mjg5IDkuODc4OTk4LTE5LjYyNzAxMyAyMS4xMzAyNWwzMC4wMTI1NDcgNDg4LjM4MTA3QzM2OS44MTk3OSA4MjkuNTk0MzM1IDM3OS4yNzAwMjMgODM4LjM2NzEzOSAzOTAuNTIwMjUxIDgzNy45NTk4NjNNODU4LjMzMDgyIDE4Ni4wNDAxMzcgNjU0LjYwNTkwNSAxODYuMDQwMTM3IDY1NC42MDU5MDUgMTA0LjU4MDg3YzAtMjIuNTExNzEzLTE4LjI1MzczNi00MC43NzU2ODItNDAuNzQ0OTgzLTQwLjc3NTY4Mkw0MTAuMTM3MDMxIDYzLjgwNTE4OGMtMjIuNDkxMjQ3IDAtNDAuNzQ0OTgzIDE4LjI2Mzk2OS00MC43NDQ5ODMgNDAuNzc1NjgybDAgODEuNDU5MjY3TDE2NS42NjcxMzQgMTg2LjA0MDEzN2MtMTEuMjQyMDQyIDAtMjAuMzcxOTggOS4xMzA5NjEtMjAuMzcxOTggMjAuNDAyNjc5IDAgMTEuMjM5OTk1IDkuMTMwOTYxIDIwLjM0MjMwNCAyMC4zNzE5OCAyMC4zNDIzMDRsNDAuNzQ0OTgzIDAgNDAuNzQ0OTgzIDY1MS45MTg3MDNjNi41NTUzIDQ0LjYwNTkxNyAzNi40ODcwMDYgODEuNDg5OTY2IDgxLjQ4OTk2NiA4MS40ODk5NjZsMzY2LjcwNDg0NiAwYzQ1LjAwMjk2IDAgNzMuODQ5OTYyLTM3LjMzMjI1NyA4MS40ODk5NjYtODEuNDg5OTY2bDQwLjc0NDk4My02NTEuOTE4NzAzIDQwLjc0NDk4MyAwYzExLjI0MTAxOSAwIDIwLjM3MTk4LTkuMTAyMzA5IDIwLjM3MTk4LTIwLjM0MjMwNEM4NzguNzAzODIzIDE5NS4xNzEwOTggODY5LjU3Mjg2MiAxODYuMDQwMTM3IDg1OC4zMzA4MiAxODYuMDQwMTM3TTQxMC4xMzcwMzEgMTA0LjU4MDg3bDIwMy43MjM4OTEgMCAwIDgxLjQ1OTI2N0w0MTAuMTM3MDMxIDE4Ni4wNDAxMzcgNDEwLjEzNzAzMSAxMDQuNTgwODd6TTczNi4wOTU4NzEgODc4LjcwNDg0NmMtMi43NDY1NTQgMjEuNDk2NTkzLTE4LjI1MzczNiA0MC43NDQ5ODMtNDAuNzQ0OTgzIDQwLjc0NDk4M0wzMjguNjQ3MDY1IDkxOS40NDk4MjljLTIyLjQ5MTI0NyAwLTM3LjY1MDUwNS0xOS4wMjAxOTItNDAuNzQ0OTgzLTQwLjc0NDk4M2wtNDAuNzQ0OTgzLTY1MS45MTg3MDMgNTI5LjY4Mzc1NCAwTDczNi4wOTU4NzEgODc4LjcwNDg0NnpcIl0sXHJcbiAgICAgICAgaWNvbl9sb2NrZWQ6IFtcIk01MDQuOTcwNjY2IDBDMzYzLjQ4OCAwIDI0OC40MTYgMTE1LjA5MzMzMyAyNDguNDE2IDI1Ni41MzMzMzNsMCAxODAuMzk0NjY3IDEwNC4zMiAwIDAtMTgwLjM5NDY2N2MwLTgzLjkyNTMzMyA2OC4yODgtMTUyLjIxMzMzMyAxNTIuMjM0NjY3LTE1Mi4yMTMzMzNzMTUyLjIxMzMzMyA2OC4yODggMTUyLjIxMzMzMyAxNTIuMjEzMzMzbDAgMTgwLjM5NDY2NyAxMDQuMzQxMzMzIDAgMC0xODAuMzk0NjY3Qzc2MS41MjUzMzMgMTE1LjA5MzMzMyA2NDYuNDMyIDAgNTA0Ljk3MDY2NiAwelwiLCBcIk04MTAuODY5MzMzIDQ2Ny4zMjggMjEzLjEwOTMzMyA0NjcuMzI4QzE2Ny43MTIgNDY3LjMyOCAxMzAuODkwNjY2IDUwNC4xNDkzMzMgMTMwLjg5MDY2NiA1NDkuNTY4bDAgMzkxLjgwOGMwIDQ1LjQxODY2NyAzNi44MjEzMzMgODIuMjE4NjY3IDgyLjIxODY2NyA4Mi4yMTg2NjdsNTk3Ljc2IDBjNDUuNDE4NjY3IDAgODIuMjQtMzYuODIxMzMzIDgyLjI0LTgyLjIxODY2N0w4OTMuMTA5MzMzIDU0OS41NjhDODkzLjEwOTMzMyA1MDQuMTQ5MzMzIDg1Ni4yODggNDY3LjMyOCA4MTAuODY5MzMzIDQ2Ny4zMjh6TTY3Ny43NzA2NjYgNzgxLjU0NjY2N2wtODEuNTE0NjY3IDBjLTE0LjAxNiAzMi42ODI2NjctNDYuNDQyNjY3IDU1LjU3MzMzMy04NC4yNDUzMzMgNTUuNTczMzMzLTM3LjgwMjY2NyAwLTcwLjI1MDY2Ny0yMi44OTA2NjctODQuMjY2NjY3LTU1LjU3MzMzM2wtODEuNDkzMzMzIDAgMC03Mi4xNzA2NjcgODEuNDkzMzMzIDBjMTQuMDE2LTMyLjY2MTMzMyA0Ni40NjQtNTUuNTUyIDg0LjI2NjY2Ny01NS41NTIgMzcuODAyNjY3IDAgNzAuMjI5MzMzIDIyLjg5MDY2NyA4NC4yNDUzMzMgNTUuNTUybDgxLjUxNDY2NyAwTDY3Ny43NzA2NjYgNzgxLjU0NjY2N3pcIl0sXHJcbiAgICAgICAgaWNvbl91bmxvY2tlZDogW1wiTTI1Ni42NDIzOCAwQzExNS4xMjIzMTQgMCAwIDExNS4xMjIzMTQgMCAyNTYuNjQyMzhsMCAxODAuNDM1ODg5IDEwNC4zNjExNjYgMCAwLTE4MC40MzU4ODljMC04My45NTg5MSA2OC4zMjIzMDQtMTUyLjI4MTIxNCAxNTIuMjgxMjE0LTE1Mi4yODEyMTRzMTUyLjI4MTIxNCA2OC4zMDAzNDIgMTUyLjI4MTIxNCAxNTIuMjgxMjE0bDAgMTgwLjQzNTg4OSAxMDQuMzgzMTI4IDAgMC0xODAuNDM1ODg5QzUxMy4zMDY3MjIgMTE1LjEyMjMxNCAzOTguMTYyNDQ3IDAgMjU2LjY0MjM4IDB6XCIsIFwiTTk3MS41OTk4MjQgNDY3LjQ5NDk4MSAzNzMuNjMxNDIzIDQ2Ny40OTQ5ODFjLTQ1LjQzODM5NSAwLTgyLjI4OTgzNCAzNi44Mjk0NzctODIuMjg5ODM0IDgyLjI2Nzg3MmwwIDM5MS45NDczMzVjMCA0NS40NjAzNTcgMzYuODI5NDc3IDgyLjI4OTgzNCA4Mi4yODk4MzQgODIuMjg5ODM0bDU5Ny45Njg0IDBjNDUuNDE2NDM0IDAgODIuMjQ1OTExLTM2LjgyOTQ3NyA4Mi4yNDU5MTEtODIuMjg5ODM0TDEwNTMuODQ1NzM0IDU0OS43NDA4OTJDMTA1My44NDU3MzQgNTA0LjMyNDQ1OCAxMDE3LjAzODIxOSA0NjcuNDk0OTgxIDk3MS41OTk4MjQgNDY3LjQ5NDk4MXpNODM4LjQyNTEzNiA3ODEuODMwMjg3bC04MS41MjExOCAwYy0xNC4wMTE0NTMgMzIuNzAwNzExLTQ2LjQ0ODYyNSA1NS42MDY1ODEtODQuMjg4MzMzIDU1LjYwNjU4MXMtNzAuMjc2ODgtMjIuOTA1ODctODQuMzEwMjk0LTU1LjYwNjU4MWwtODEuNTIxMTggMCAwLTcyLjE4NzUzMiA4MS41MjExOCAwYzE0LjAzMzQxNC0zMi42Nzg3NDkgNDYuNDcwNTg3LTU1LjU4NDYyIDg0LjMxMDI5NC01NS41ODQ2MnM3MC4yNzY4OCAyMi45MDU4NyA4NC4yODgzMzMgNTUuNTg0NjJsODEuNTIxMTggMEw4MzguNDI1MTM2IDc4MS44MzAyODd6XCJdLFxyXG4gICAgICAgIC8v57q/5p2h5YyW5Zu+5qCH77yI55So5LqO5Yqf6IO96I+c5Y2V77yJXHJcbiAgICAgICAgaWNvbl9ob2xsb3dfcmVzdW1lOiBbXCJNOTkwLjAwNzcwOSA4OTJjLTExLjIgMC0yMi01LjktMjcuOC0xNi4yQzg0MS43MDc3MDkgNjY0LjMgNjcyLjMwNzcwOSA2MzkuMiA0NDguMDA3NzA5IDYzNy40bDAgMTk4LjZjMCAxMi42LTcuMyAyNC0xOC44IDI5LjEtMTEuNCA1LjItMjQuOCAzLjItMzQuMy01LjFsLTM4NC0zMzZjLTYuOC02LTEwLjgtMTQuNS0xMC45LTIzLjUtMC4yLTkgMy41LTE3LjcgMTAuMS0yMy45bDM4NC0zNjBjOS4zLTguNyAyMi45LTExLjEgMzQuNi02IDExLjcgNS4xIDE5LjMgMTYuNiAxOS4zIDI5LjRsMCAxNjguOGMxMDAuNCA1IDE5MS45IDMzLjcgMjcyLjQgODUuNiA3MC44IDQ1LjYgMTMzIDEwOC45IDE4NC44IDE4OC4yIDg3LjMgMTMzLjYgMTE0LjkgMjY1LjYgMTE2LjEgMjcxLjEgMy4xIDE1LjQtNS40IDMwLjgtMjAuMSAzNi4zQzk5Ny42MDc3MDkgODkxLjMgOTkzLjgwNzcwOSA4OTIgOTkwLjAwNzcwOSA4OTJ6TTc5LjcwNzcwOSA0OTkuMSAzODQuMDA3NzA5IDc2NS40IDM4NC4wMDc3MDkgNjA1LjJjMC0xNy43IDE0LjMtMzIgMzItMzIgMTM2LjcgMCAyNDcuNCA3LjIgMzQzLjUgNDIuMSA1MC45IDE4LjUgOTUuMiA0My44IDEzNS4yIDc3LjEtMTIuNS0yNC45LTI3LTUwLjgtNDQtNzYuNkM3NDQuMjA3NzA5IDQ1NCA1OTguMDA3NzA5IDM3MiA0MTYuMDA3NzA5IDM3MmMtMTcuNyAwLTMyLTE0LjMtMzItMzJsMC0xMjYuMkw3OS43MDc3MDkgNDk5LjF6XCJdLFxyXG4gICAgICAgIGljb25faG9sbG93X2JhY2s6IFtcIk04OC4zMzMzMjYgNTY2LjQyODYzM2MxNi40MDY2NjgtMzguNzg5NDQ1IDM5Ljg4NTQwNi03My42MTY2NDggNjkuNzgxMjk2LTEwMy41MTQ1ODUgMjkuODk3OTM3LTI5Ljg5NjkxNCA2NC43MjYxNjQtNTMuMzc1NjUxIDEwMy41MTQ1ODUtNjkuNzgxMjk2IDQwLjE4NDIxMS0xNi45OTYwOTMgODIuODQxNzUzLTI1LjYxNDM3NyAxMjYuNzkxNzMyLTI1LjYxNDM3N2g0MjAuOTQ5Mjg0TDU4MC4yOTY5OTEgMTM4LjQ0MjA3MmgtMC4wMDEwMjRjLTE3LjM5ODI1Mi0xNy4zOTgyNTItMTcuMzk4MjUyLTQ1LjYwNDY2NCAwLjAwMTAyNC02My4wMDI5MTYgMTcuMzk4MjUyLTE3LjM5ODI1MiA0NS42MDM2NDEtMTcuMzk5Mjc1IDYzLjAwMjkxNi0wLjAwMTAyM2wwLjAwMTAyMyAwLjAwMTAyM0w5NDguMzI5MDY1IDM4MC40NjgzMTRsLTAuMDY4NTYyIDAuMDY5NTg1YzguMDQzMTg3IDguMDQ0MjEgMTMuMDE5NTI1IDE5LjE1NzMxNSAxMy4wMTk1MjUgMzEuNDMxODczcy00Ljk3NTMxNSAyMy4zODg2ODYtMTMuMDIwNTQ4IDMxLjQzMTg3NGwwLjA2OTU4NSAwLjA2OTU4NUw2NDMuMzAwOTMgNzQ4LjUwMDM4OWgtMC4wMDEwMjNjLTE3LjM5ODI1MiAxNy4zOTgyNTItNDUuNjA0NjY0IDE3LjM5ODI1Mi02My4wMDI5MTYgMC0xNy4zOTkyNzUtMTcuMzk4MjUyLTE3LjM5OTI3NS00NS42MDQ2NjQtMC4wMDEwMjQtNjMuMDAyOTE2bDAuMDEwMjMzLTAuMDEwMjMzIDIyOS4wNjYwNy0yMjkuMDY2MDdIMzg4LjQyMTk2MmMtMTMwLjU3MTgyNCAwLTIzNi43OTkxOTQgMTA2LjIyNzM3LTIzNi43OTkxOTQgMjM2Ljc5OTE5NXYyMjMuOTM4MjgxYzAgMjQuNTUxMTYyLTE5LjkwMTI1OSA0NC40NTEzOTgtNDQuNDUwMzc1IDQ0LjQ1MTM5OC0yNC41NTAxMzkgMC00NC40NTI0MjEtMTkuOTAwMjM2LTQ0LjQ1MjQyMS00NC40NTEzOThWNjkzLjIyMDM2NWMtMC4wMDEwMjMtNDMuOTQ5OTc4IDguNjE4Mjg1LTg2LjYwOTU2NyAyNS42MTMzNTQtMTI2Ljc5MTczMnpcIl0sXHJcbiAgICB9XHJcbn1cclxuXHJcbm1haW4uaWNvbiA9IGltYWdlLmljb247XHJcblxyXG5leHBvcnQgZGVmYXVsdCBpbWFnZTtcclxuZXhwb3J0IHsgaW1hZ2UsIG1haW4gYXMgaW1hZ2VNYWluIH07IiwiLyoq57G75Z6L6L2s5o2iICovXHJcbnZhciBjb252ZXJ0ID0ge1xyXG4gICAgLyoqXHJcbiAgICAgKiDlrZfnrKbkuLLovazml7bpl7TvvJpcclxuICAgICAqIOWPr+S7peS9v+eUqOKAnOW5tOaciOaXpeaXtuWIhuenkuKAneOAgeKAnOaciOaXpeW5tOaXtuWIhuenkuKAneOAgeKAnOaciOaXpeaXtuWIhuenkuKAneWSjOKAnOaXtuWIhuenkuKAneWbm+enjemhuuW6j+Whq+WGme+8jOS4remXtOivt+eUqOS7u+S4gOWIhumalOespumalOW8gO+8m1xyXG4gICAgICog5Y+v5Lul5LuO5ZCO5b6A5YmN55yB55Wl77yI55yB55Wl6aG56Ieq5Yqo55So5pyA5bCP5YC85aGr5YWF77yM5bm05Lu95pyA5bCP5YC85Li6MTAwMO+8ie+8jOS9huS4remXtOS4jeiDvea8j++8m1xyXG4gICAgICog5aaC5p6c5L2/55So4oCc5bm05pyI5pel5pe25YiG56eS4oCd6aG65bqP5YiZ6Iez5bCR6ZyA6KaB5YyF5ZCr4oCc5bm05pyI4oCd44CCXHJcbiAgICAgKiDlpoLmnpzkvb/nlKjigJzml7bliIbnp5LigJ3pobrluo/liJnlv4XpobvnlKjigJw64oCd6ZqU5byA44CCXHJcbiAgICAgKiBAcGFyYW0ge1N0cmluZ30gc3RyIOiiq+i9rOWtl+espuS4slxyXG4gICAgICovXHJcbiAgICB0b0RhdGV0aW1lOiBmdW5jdGlvbiAoc3RyKSB7XHJcbiAgICAgICAgaWYgKHN0ciBpbnN0YW5jZW9mIERhdGUpIHJldHVybiBzdHI7XHJcbiAgICAgICAgZWxzZSB7XHJcbiAgICAgICAgICAgIHN0ciA9IHN0ci50b1N0cmluZygpO1xyXG4gICAgICAgICAgICB2YXIgZGF0ZUFycmF5ID0gc3RyLm1hdGNoKC9cXGQrL2cpO1xyXG4gICAgICAgICAgICBpZiAoZGF0ZUFycmF5WzBdLmxlbmd0aCA9PSA0KSB7XHJcbiAgICAgICAgICAgICAgICBkYXRlQXJyYXlbMV0gPSBkYXRlQXJyYXlbMV0gLSAxO1xyXG4gICAgICAgICAgICAgICAgcmV0dXJuIGV2YWwoJ25ldyBEYXRlKCcgKyBkYXRlQXJyYXkgKyAnKScpO1xyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgICAgIGVsc2UgaWYgKGRhdGVBcnJheVsyXSA9PSA0KSB7XHJcbiAgICAgICAgICAgICAgICB2YXIgdGVtcCA9IGRhdGVBcnJheVswXSAtIDE7XHJcbiAgICAgICAgICAgICAgICBkYXRlQXJyYXlbMF0gPSBkYXRlQXJyYXlbMl07XHJcbiAgICAgICAgICAgICAgICBkYXRlQXJyYXlbMl0gPSBkYXRlQXJyYXlbMV07XHJcbiAgICAgICAgICAgICAgICBkYXRlQXJyYXlbMV0gPSB0ZW1wO1xyXG4gICAgICAgICAgICAgICAgcmV0dXJuIGV2YWwoJ25ldyBEYXRlKCcgKyBkYXRlQXJyYXkgKyAnKScpO1xyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgICAgIGVsc2Uge1xyXG4gICAgICAgICAgICAgICAgaWYgKHN0ci5tYXRjaCgvXFxELylbMF0gPT0gXCI6XCIgfHwgc3RyLm1hdGNoKC9cXEQvKVswXSA9PSBcIu+8mlwiKSB7XHJcbiAgICAgICAgICAgICAgICAgICAgZGF0ZUFycmF5LnVuc2hpZnQoMSk7XHJcbiAgICAgICAgICAgICAgICAgICAgZGF0ZUFycmF5LnVuc2hpZnQoMCk7XHJcbiAgICAgICAgICAgICAgICAgICAgZGF0ZUFycmF5LnVuc2hpZnQoMTAwMCk7XHJcbiAgICAgICAgICAgICAgICAgICAgcmV0dXJuIGV2YWwoJ25ldyBEYXRlKCcgKyBkYXRlQXJyYXkgKyAnKScpO1xyXG4gICAgICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICAgICAgZWxzZSB7XHJcbiAgICAgICAgICAgICAgICAgICAgZGF0ZUFycmF5LnVuc2hpZnQoMTAwMCk7XHJcbiAgICAgICAgICAgICAgICAgICAgcmV0dXJuIGV2YWwoJ25ldyBEYXRlKCcgKyBkYXRlQXJyYXkgKyAnKScpO1xyXG4gICAgICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgfVxyXG4gICAgfSxcclxuXHJcbiAgICAvKipcclxuICAgICAqIOWwhuS7u+aEj+S4nOilv+i9rOS4ukpT5a+56LGh77yI55uu5YmN5LuF5pSv5oyBRG9t55qERm9ybe+8iVxyXG4gICAgICogQHBhcmFtIHsqfSBvYmog5Lu75oSP5a+56LGhXHJcbiAgICAgKiBAcGFyYW0geyp9IHR5cGUg5a+56LGh5Luj5Y+377yI6buY6K6k5Li6Rm9ybe+8iVxyXG4gICAgICovXHJcbiAgICB0b09iamVjdDogZnVuY3Rpb24gKG9iaiwgdHlwZSkge1xyXG4gICAgICAgIHZhciByc3QgPSB7fTtcclxuICAgICAgICB0eXBlID0gdHlwZSB8fCBcIlwiO1xyXG4gICAgICAgIHN3aXRjaCAodHlwZSkge1xyXG4gICAgICAgICAgICBkZWZhdWx0OlxyXG4gICAgICAgICAgICAgICAgZm9yICh2YXIgaSA9IDA7IGkgPCBvYmoubGVuZ3RoOyBpKyspIHtcclxuICAgICAgICAgICAgICAgICAgICByc3Rbb2JqW2ldLm5hbWVdID0gb2JqW2ldLnZhbHVlO1xyXG4gICAgICAgICAgICAgICAgfVxyXG4gICAgICAgIH1cclxuICAgICAgICByZXR1cm4gcnN0O1xyXG4gICAgfVxyXG59O1xyXG5cclxuZXhwb3J0IGRlZmF1bHQgY29udmVydDsiLCIvKiogQ29va2llICovXHJcbnZhciBjb29raWUgPSB7XHJcbiAgICAvKipcclxuICAgICAqIOiOt+WPlmNvb2tpZVxyXG4gICAgICogQHBhcmFtIHthbnl9IGNuYW1lIGNvb2tpZeWQjVxyXG4gICAgICovXHJcbiAgICBnZXQ6IGZ1bmN0aW9uIChjbmFtZSkge1xyXG4gICAgICAgIHZhciBuYW1lID0gY25hbWUgKyBcIj1cIjtcclxuICAgICAgICB2YXIgZGVjb2RlZENvb2tpZSA9IGRlY29kZVVSSUNvbXBvbmVudChkb2N1bWVudC5jb29raWUpO1xyXG4gICAgICAgIHZhciBjYSA9IGRlY29kZWRDb29raWUuc3BsaXQoJzsnKTtcclxuICAgICAgICBmb3IgKHZhciBpID0gMDsgaSA8IGNhLmxlbmd0aDsgaSsrKSB7XHJcbiAgICAgICAgICAgIHZhciBjID0gY2FbaV07XHJcbiAgICAgICAgICAgIHdoaWxlIChjLmNoYXJBdCgwKSA9PSAnICcpIHtcclxuICAgICAgICAgICAgICAgIGMgPSBjLnN1YnN0cmluZygxKTtcclxuICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICBpZiAoYy5pbmRleE9mKG5hbWUpID09IDApIHtcclxuICAgICAgICAgICAgICAgIHJldHVybiBjLnN1YnN0cmluZyhuYW1lLmxlbmd0aCwgYy5sZW5ndGgpO1xyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgfVxyXG4gICAgICAgIHJldHVybiBcIlwiO1xyXG4gICAgfVxyXG59O1xyXG5cclxuZXhwb3J0IGRlZmF1bHQgY29va2llOyIsImltcG9ydCBmb3JtYXQgZnJvbSBcIi4vZm9ybWF0LmpzXCI7XHJcblxyXG4vKirml6XmnJ/mk43kvZwgKi9cclxudmFyIGRhdGUgPSB7XHJcbiAgICAvKipcclxuICAgICAqIOiOt+WPluW9k+WJjeaXpeacn1xyXG4gICAgICogQHBhcmFtIHtTdHJpbmd9IHNlcGVyYXRvciDliIbpmpTnrKbvvIzvvIjnlZnnqbrkuLrigJwt4oCd77yJXHJcbiAgICAgKi9cclxuICAgIG5vdzogZnVuY3Rpb24gKHNlcGVyYXRvcikge1xyXG4gICAgICAgIHNlcGVyYXRvciA9IHNlcGVyYXRvciB8fCAnLSc7XHJcbiAgICAgICAgdmFyIGRhdGUgPSBuZXcgRGF0ZSgpO1xyXG4gICAgICAgIHZhciBwcmVmaXggPSBmb3JtYXQucHJlZml4O1xyXG4gICAgICAgIHJldHVybiBkYXRlLmdldEZ1bGxZZWFyKCkgKyBzZXBlcmF0b3IgKyBwcmVmaXgoKGRhdGUuZ2V0TW9udGgoKSArIDEpLCAyKSArIHNlcGVyYXRvciArIHByZWZpeChkYXRlLmdldERhdGUoKSwgMik7XHJcbiAgICB9XHJcbn07XHJcblxyXG5leHBvcnQgZGVmYXVsdCBkYXRlOyIsIi8qKiBkb23pop3lpJbmk43kvZwgKi9cclxudmFyIGRvbSA9IHtcclxuICAgIGdldEZvcm06IGZ1bmN0aW9uIChlbGVtZW50KSB7XHJcbiAgICAgICAgdmFyIHBhcmVudCA9IGVsZW1lbnQucGFyZW50Tm9kZTtcclxuICAgICAgICB3aGlsZSAocGFyZW50LnRhZ05hbWUudG9Mb3dlckNhc2UoKSAhPSBcImZvcm1cIikge1xyXG4gICAgICAgICAgICBpZiAocGFyZW50LnBhcmVudE5vZGUgPT0gbnVsbCkgcmV0dXJuIG51bGw7XHJcbiAgICAgICAgICAgIHBhcmVudCA9IHBhcmVudC5wYXJlbnROb2RlO1xyXG4gICAgICAgIH1cclxuICAgICAgICByZXR1cm4gcGFyZW50O1xyXG4gICAgfVxyXG59XHJcblxyXG5leHBvcnQgZGVmYXVsdCBkb207IiwiaW1wb3J0IGNvbnZlcnQgZnJvbSBcIi4vY29udmVydC5qc1wiO1xyXG5cclxuLyoq5a2X56ym5Liy5qC85byP5YyWICovXHJcbnZhciBmb3JtYXQgPSB7XHJcbiAgICAvKipcclxuICAgICAqIOaXpeacn+WSjOaXtumXtOagvOW8j+WMlu+8iOi/lOWbnuWtl+espuS4su+8iVxyXG4gICAgICogQHBhcmFtIHthbnl9IGRhdGUg5pel5pyf77yI5a2X56ym5Liy5oiWRGF0Ze+8iVxyXG4gICAgICogQHBhcmFtIHtTdHJpbmd9IGZvcm1hdCDml6XmnJ/moLzlvI/vvIzkvovlpoLigJx5eXl5LW1tLWRk4oCdXHJcbiAgICAgKi9cclxuICAgIGRhdGV0aW1lOiBmdW5jdGlvbiAoZGF0ZSwgZm9ybWF0KSB7XHJcbiAgICAgICAgZm9ybWF0ID0gZm9ybWF0IHx8IFwiXCI7XHJcbiAgICAgICAgaWYgKGRhdGUgPT09IHVuZGVmaW5lZCB8fCBkYXRlID09IG51bGwgfHwgZGF0ZSA9PSBcIlwiIHx8IGRhdGUgPT0gMCkgZGF0ZSA9IG5ldyBEYXRlKCk7XHJcbiAgICAgICAgZWxzZSBkYXRlID0gY29udmVydC50b0RhdGV0aW1lKGRhdGUpO1xyXG4gICAgICAgIHZhciBwcmVmaXggPSB4dXJ1aS5mb3JtYXQucHJlZml4O1xyXG4gICAgICAgIHZhciB5ZWFyID0gZGF0ZS5nZXRGdWxsWWVhcigpO1xyXG4gICAgICAgIHZhciBtb250aCA9IGRhdGUuZ2V0TW9udGgoKSArIDE7XHJcbiAgICAgICAgdmFyIGRheSA9IGRhdGUuZ2V0RGF0ZSgpO1xyXG4gICAgICAgIHZhciBob3VyID0gZGF0ZS5nZXRIb3VycygpO1xyXG4gICAgICAgIHZhciBtaW4gPSBkYXRlLmdldE1pbnV0ZXMoKTtcclxuICAgICAgICB2YXIgc2VjID0gZGF0ZS5nZXRTZWNvbmRzKCk7XHJcbiAgICAgICAgc3dpdGNoIChmb3JtYXQpIHtcclxuICAgICAgICAgICAgY2FzZSAneXl5eS1tbS1kZCBoaDptbTpzcyc6XHJcbiAgICAgICAgICAgICAgICByZXR1cm4geWVhciArICctJyArIHByZWZpeChtb250aCwgMikgKyBcIi1cIiArIHByZWZpeChkYXksIDIpICsgXCIgXCIgKyBwcmVmaXgoaG91ciwgMikgKyAnOicgKyBwcmVmaXgobWluLCAyKSArIFwiOlwiICsgcHJlZml4KHNlYywgMik7XHJcbiAgICAgICAgICAgICAgICBicmVhaztcclxuICAgICAgICAgICAgY2FzZSAneXl5eS1tbS1kZCBoaDptbSc6XHJcbiAgICAgICAgICAgICAgICByZXR1cm4geWVhciArICctJyArIHByZWZpeChtb250aCwgMikgKyBcIi1cIiArIHByZWZpeChkYXksIDIpICsgXCIgXCIgKyBwcmVmaXgoaG91ciwgMikgKyAnOicgKyBwcmVmaXgobWluLCAyKTtcclxuICAgICAgICAgICAgICAgIGJyZWFrO1xyXG4gICAgICAgICAgICBjYXNlICd5eXl5LW1tLWRkJzpcclxuICAgICAgICAgICAgICAgIHJldHVybiB5ZWFyICsgJy0nICsgcHJlZml4KG1vbnRoLCAyKSArIFwiLVwiICsgcHJlZml4KGRheSwgMik7XHJcbiAgICAgICAgICAgICAgICBicmVhaztcclxuICAgICAgICAgICAgZGVmYXVsdDpcclxuICAgICAgICAgICAgICAgIHJldHVybiB5ZWFyICsgJy0nICsgcHJlZml4KG1vbnRoLCAyKSArIFwiLVwiICsgcHJlZml4KGRheSwgMikgKyBcIiBcIiArIHByZWZpeChob3VyLCAyKSArICc6JyArIHByZWZpeChtaW4sIDIpICsgXCI6XCIgKyBwcmVmaXgoc2VjLCAyKTtcclxuICAgICAgICAgICAgICAgIGJyZWFrO1xyXG4gICAgICAgIH1cclxuICAgIH0sXHJcblxyXG4gICAgLyoqXHJcbiAgICAgKiDop4Tlrprplb/luqbvvIzkuI3otrPliqDliY3nvIBcclxuICAgICAqIEBwYXJhbSB7U3RyaW5nfSBzdHIg5Y6f5aeL5a2X56ym5LiyXHJcbiAgICAgKiBAcGFyYW0ge051bWJlcn0gbGVuIOaAu+mVv+W6plxyXG4gICAgICogQHBhcmFtIHtTdHJpbmd9IGZpeCDooaXotrPlrZfnrKZcclxuICAgICAqL1xyXG4gICAgcHJlZml4OiBmdW5jdGlvbiAoc3RyLCBsZW4sIGZpeCkge1xyXG4gICAgICAgIHN0ciA9IHN0ci50b1N0cmluZygpO1xyXG4gICAgICAgIGlmICgvXigtP1xcZCspKFxcLlxcZCspPyQvLnRlc3Qoc3RyKSkgZml4ID0gZml4IHx8IFwiMFwiO1xyXG4gICAgICAgIGVsc2UgZml4ID0gZml4IHx8IFwiIFwiO1xyXG4gICAgICAgIHZhciBuZXdTdHIgPSBzdHI7XHJcbiAgICAgICAgaWYgKGxlbiA+IHN0ci5sZW5ndGgpIHtcclxuICAgICAgICAgICAgZm9yICh2YXIgaSA9IDA7IGkgPCBsZW4gLSBzdHIubGVuZ3RoOyBpKyspIHtcclxuICAgICAgICAgICAgICAgIG5ld1N0ciA9IGZpeCArIG5ld1N0cjtcclxuICAgICAgICAgICAgfVxyXG4gICAgICAgIH1cclxuICAgICAgICByZXR1cm4gbmV3U3RyO1xyXG4gICAgfSxcclxuXHJcbiAgICAvKipcclxuICAgICAqIOinhOWumumVv+W6pu+8jOS4jei2s+WKoOWQjue8gFxyXG4gICAgICogQHBhcmFtIHtTdHJpbmd9IHN0ciDljp/lp4vlrZfnrKbkuLJcclxuICAgICAqIEBwYXJhbSB7TnVtYmVyfSBsZW4g5oC76ZW/5bqmXHJcbiAgICAgKiBAcGFyYW0ge1N0cmluZ30gZml4IOihpei2s+Wtl+esplxyXG4gICAgICovXHJcbiAgICBzdWZmaXg6IGZ1bmN0aW9uIChzdHIsIGxlbiwgZml4KSB7XHJcbiAgICAgICAgc3RyID0gc3RyLnRvU3RyaW5nKCk7XHJcbiAgICAgICAgaWYgKC9eKC0/XFxkKykoXFwuXFxkKyk/JC8udGVzdChzdHIpKSBmaXggPSBmaXggfHwgXCIwXCI7XHJcbiAgICAgICAgZWxzZSBmaXggPSBmaXggfHwgXCIgXCI7XHJcbiAgICAgICAgdmFyIG5ld1N0ciA9IHN0cjtcclxuICAgICAgICBpZiAobGVuID4gc3RyLmxlbmd0aCkge1xyXG4gICAgICAgICAgICBmb3IgKHZhciBpID0gMDsgaSA8IGxlbiAtIHN0ci5sZW5ndGg7IGkrKykge1xyXG4gICAgICAgICAgICAgICAgbmV3U3RyID0gbmV3U3RyICsgZml4O1xyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgfVxyXG4gICAgICAgIHJldHVybiBuZXdTdHI7XHJcbiAgICB9XHJcbn07XHJcblxyXG5leHBvcnQgZGVmYXVsdCBmb3JtYXQ7IiwiaW1wb3J0IGNvbnZlcnQgZnJvbSBcIi4vY29udmVydC5qc1wiO1xyXG5cclxuLyoq6K6h566X5Yqf6IO9ICovXHJcbnZhciBtYXRoID0ge1xyXG5cclxuICAgIC8qKlxyXG4gICAgICog6LWL5LqI5pWw57uE5Lit55qEUknllK/kuIDnmoTotJ/mlbBcclxuICAgICAqIEBwYXJhbSB7QXJyYXl9IHJpX2xpc3Qg6KKr6LWL5LqI55qE5pWw57uEXHJcbiAgICAgKi9cclxuICAgIG5ld25uOiBmdW5jdGlvbiAocmlfbGlzdCkge1xyXG4gICAgICAgIHZhciBuZXdyaSA9IC0xO1xyXG4gICAgICAgIGlmIChyaV9saXN0Lmxlbmd0aCA+IDApIHtcclxuICAgICAgICAgICAgdmFyIGZsYWcgPSB0cnVlO1xyXG4gICAgICAgICAgICBuZXdyaSA9IC1yaV9saXN0Lmxlbmd0aCAtIDE7XHJcbiAgICAgICAgICAgIHdoaWxlIChmbGFnKSB7XHJcbiAgICAgICAgICAgICAgICBmbGFnID0gZmFsc2U7XHJcbiAgICAgICAgICAgICAgICBmb3IgKHZhciBpID0gMDsgaSA8IHJpX2xpc3QubGVuZ3RoOyBpKyspIHtcclxuICAgICAgICAgICAgICAgICAgICBpZiAobmV3cmkgPT0gcmlfbGlzdFtpXS5SSSkge1xyXG4gICAgICAgICAgICAgICAgICAgICAgICBuZXdyaSA9IG5ld3JpIC0gMTtcclxuICAgICAgICAgICAgICAgICAgICAgICAgZmxhZyA9IHRydWU7XHJcbiAgICAgICAgICAgICAgICAgICAgICAgIGJyZWFrO1xyXG4gICAgICAgICAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgfVxyXG4gICAgICAgIH1cclxuICAgICAgICByZXR1cm4gbmV3cmk7XHJcbiAgICB9LFxyXG5cclxuICAgIC8qKlxyXG4gICAgICog6K6h566X5Lik5Liq5pe26Ze06Ze06ZqU77yI5aaC5p6c6L+U5Zue5pyI5Lu95Y+K5Lul5LiK5Y2V5L2N77yM5YiZ5LiN5L+d55WZ5bCP5pWw77yJXHJcbiAgICAgKiBAcGFyYW0ge2FueX0gdGltZXMg6K6h566X6LW35aeL5pe26Ze077yI6K+35oyJ54Wn5bm05pyI5pel5pe25YiG56eS6aG65bqP5aGr5YaZ77yM5bm26ZqU5byA77yJXHJcbiAgICAgKiBAcGFyYW0ge2FueX0gdGltZWUg6K6h566X57uT5p2f5pe26Ze077yI6K+35oyJ54Wn5bm05pyI5pel5pe25YiG56eS6aG65bqP5aGr5YaZ77yM5bm26ZqU5byA77yJXHJcbiAgICAgKiBAcGFyYW0ge1N0cmluZ30gdHlwZSDov5Tlm57ml7bpl7TljZXkvY3vvIjnlZnnqbrkuLrnp5LvvIzku47mr6vnp5LliLDkuJbnuqrvvIzmlK/mjIHmoIflh4bljZXkvY3jgIHoi7Hmlofku6Xlj4rkuK3mlofvvIlcclxuICAgICAqL1xyXG4gICAgdGltZXNwYW46IGZ1bmN0aW9uICh0aW1lcywgdGltZWUsIHR5cGUpIHtcclxuICAgICAgICB0eXBlID0gdHlwZSB8fCBcInNcIjtcclxuICAgICAgICB0aW1lcyA9IGNvbnZlcnQudG9EYXRldGltZSh0aW1lcyk7XHJcbiAgICAgICAgdGltZWUgPSBjb252ZXJ0LnRvRGF0ZXRpbWUodGltZWUpO1xyXG4gICAgICAgIHN3aXRjaCAodHlwZSkge1xyXG4gICAgICAgICAgICBjYXNlIFwiY1wiOlxyXG4gICAgICAgICAgICBjYXNlIFwiY2VudHVyeVwiOlxyXG4gICAgICAgICAgICBjYXNlIFwi5LiW57qqXCI6XHJcbiAgICAgICAgICAgICAgICByZXR1cm4gKHRpbWVlLmdldEZ1bGxZZWFyKCkgLSB0aW1lcy5nZXRGdWxsWWVhcigpKSAvIDEwMDtcclxuICAgICAgICAgICAgY2FzZSBcInlcIjpcclxuICAgICAgICAgICAgY2FzZSBcInllYXJcIjpcclxuICAgICAgICAgICAgY2FzZSBcIuW5tFwiOlxyXG4gICAgICAgICAgICBjYXNlIFwi5bm05Lu9XCI6XHJcbiAgICAgICAgICAgICAgICByZXR1cm4gdGltZWUuZ2V0RnVsbFllYXIoKSAtIHRpbWVzLmdldEZ1bGxZZWFyKCk7XHJcbiAgICAgICAgICAgIGNhc2UgXCJtXCI6XHJcbiAgICAgICAgICAgIGNhc2UgXCJtb250aFwiOlxyXG4gICAgICAgICAgICBjYXNlIFwi5pyIXCI6XHJcbiAgICAgICAgICAgIGNhc2UgXCLmnIjku71cIjpcclxuICAgICAgICAgICAgICAgIHJldHVybiAodGltZWUuZ2V0RnVsbFllYXIoKSAtIHRpbWVzLmdldEZ1bGxZZWFyKCkpICogMTIgKyB0aW1lZS5nZXRNb250aCgpIC0gdGltZXMuZ2V0TW9udGgoKTtcclxuICAgICAgICAgICAgY2FzZSBcIndcIjpcclxuICAgICAgICAgICAgY2FzZSBcIndlZWtcIjpcclxuICAgICAgICAgICAgY2FzZSBcIuWRqFwiOlxyXG4gICAgICAgICAgICBjYXNlIFwi56S85oucXCI6XHJcbiAgICAgICAgICAgICAgICByZXR1cm4gcGFyc2VGbG9hdCgodGltZWUgLSB0aW1lcykgLyA2MDQ4MDAwMDApO1xyXG4gICAgICAgICAgICBjYXNlIFwiZFwiOlxyXG4gICAgICAgICAgICBjYXNlIFwiZGF5XCI6XHJcbiAgICAgICAgICAgIGNhc2UgXCLml6VcIjpcclxuICAgICAgICAgICAgY2FzZSBcIuWkqVwiOlxyXG4gICAgICAgICAgICAgICAgcmV0dXJuIHBhcnNlRmxvYXQoKHRpbWVlIC0gdGltZXMpIC8gODY0MDAwMDApO1xyXG4gICAgICAgICAgICBjYXNlIFwiaFwiOlxyXG4gICAgICAgICAgICBjYXNlIFwiaG91clwiOlxyXG4gICAgICAgICAgICBjYXNlIFwi5pe2XCI6XHJcbiAgICAgICAgICAgIGNhc2UgXCLlsI/ml7ZcIjpcclxuICAgICAgICAgICAgICAgIHJldHVybiBwYXJzZUZsb2F0KCh0aW1lZSAtIHRpbWVzKSAvIDM2MDAwMDApO1xyXG4gICAgICAgICAgICBjYXNlIFwibWluXCI6XHJcbiAgICAgICAgICAgIGNhc2UgXCJtaW51dGVcIjpcclxuICAgICAgICAgICAgY2FzZSBcIuWIhlwiOlxyXG4gICAgICAgICAgICBjYXNlIFwi5YiG6ZKfXCI6XHJcbiAgICAgICAgICAgICAgICByZXR1cm4gcGFyc2VGbG9hdCgodGltZWUgLSB0aW1lcykgLyA2MDAwMCk7XHJcbiAgICAgICAgICAgIGNhc2UgXCJzXCI6XHJcbiAgICAgICAgICAgIGNhc2UgXCJzZWNvbmRcIjpcclxuICAgICAgICAgICAgY2FzZSBcIuenklwiOlxyXG4gICAgICAgICAgICAgICAgcmV0dXJuIHBhcnNlRmxvYXQoKHRpbWVlIC0gdGltZXMpIC8gMTAwMCk7XHJcbiAgICAgICAgICAgIGRlZmF1bHQ6XHJcbiAgICAgICAgICAgICAgICByZXR1cm4gcGFyc2VJbnQodGltZWUgLSB0aW1lcyk7XHJcbiAgICAgICAgfVxyXG4gICAgfVxyXG5cclxufTtcclxuXHJcbmV4cG9ydCBkZWZhdWx0IG1hdGg7IiwiLyoqXHJcbiAqIOWQiOW5tuWvueixoe+8iOWmguaenOmHjeWkjeWImeS7peWQjuS4gOS4quS4uuWHhu+8iVxyXG4gKiBAcGFyYW0ge29iamVjdH0gb2JqZWN0TWFpbiDooqvlkIjlubblr7nosaFcclxuICogQHBhcmFtIHtvYmplY3R9IG9iamVjdE1lcmdlIOWQiOW5tuWvueixoVxyXG4gKi9cclxudmFyIG1lcmdlID0gZnVuY3Rpb24gKG9iamVjdE1haW4sIG9iamVjdE1lcmdlKSB7XHJcbiAgICBmb3IgKGxldCBrZXkgaW4gb2JqZWN0TWVyZ2UpIHtcclxuICAgICAgICBvYmplY3RNYWluW2tleV0gPSBvYmplY3RNZXJnZVtrZXldO1xyXG4gICAgfVxyXG4gICAgcmV0dXJuIG9iamVjdE1haW47XHJcbn07XHJcblxyXG5leHBvcnQgZGVmYXVsdCBtZXJnZTsiLCJpbXBvcnQgZm4gZnJvbSBcIi4uL2ludGVybmFsLmpzXCI7XHJcblxyXG4vKiog5pys5Zyw5a2Y5YKoICovXHJcbnZhciBzYXZlID0ge1xyXG4gICAgLyoqXHJcbiAgICAgKiDlv6vpgJ/nlJ/miJDmnKzlnLDlgqjlrZjlkI1cclxuICAgICAqIEBwYXJhbSB7U3RyaW5nfSB0eXBlIOeVmeepuu+8muS9v+eUqOmAmueUqOWQje+8iOWtmOeahOaYr3h1cnVpLnZhbHVl77yJ77yMbmV377ya5qC55o2u5b2T5YmN6aG16Z2i5Y+W5ZCNXHJcbiAgICAgKi9cclxuICAgIG5hbWU6IGZ1bmN0aW9uICh0eXBlKSB7XHJcbiAgICAgICAgaWYgKHR5cGUgPT09IHVuZGVmaW5lZCkgcmV0dXJuIHh1cnVpLmNvbmZpZy5sb2NhbC5hbGwgKyBcIi5cIiArIHh1cnVpLmc7XHJcbiAgICAgICAgZWxzZSBpZiAodHlwZSA9PT0gbnVsbCB8fCB0eXBlID09PSAwIHx8IHR5cGUgPT09IFwiXCIgfHwgdHlwZSA9PT0gXCJuZXdcIikgcmV0dXJuIHh1cnVpLm5hbWUgKyB3aW5kb3cuZG9jdW1lbnQubG9jYXRpb24ucGF0aG5hbWUucmVwbGFjZSgvXFwvL2csICcuJyk7XHJcbiAgICB9LFxyXG5cclxuICAgIC8qKlxyXG4gICAgICog5b+r6YCf5paw5bu65pys5Zyw5YKo5a2Y77yI5a2Y5Zyo5YiZ5LiN5YWB6K645paw5bu677yJXHJcbiAgICAgKiBAcGFyYW0ge1N0cmluZ30ga2V5IOacrOWcsOWCqOWtmOWQjVxyXG4gICAgICogQHBhcmFtIHthbnl9IGRhdGEg5L+d5a2Y5YaF5a65XHJcbiAgICAgKi9cclxuICAgIHNldDogZnVuY3Rpb24gKGtleSwgZGF0YSkge1xyXG4gICAgICAgIGlmIChsb2NhbFN0b3JhZ2UuaGFzT3duUHJvcGVydHkoa2V5KSkgcmV0dXJuIGZhbHNlO1xyXG4gICAgICAgIGVsc2Uge1xyXG4gICAgICAgICAgICBsb2NhbFN0b3JhZ2Uuc2V0SXRlbShrZXksIEpTT04uc3RyaW5naWZ5KGRhdGEpKTtcclxuICAgICAgICAgICAgcmV0dXJuIHRydWU7XHJcbiAgICAgICAgfVxyXG4gICAgfSxcclxuXHJcbiAgICAvKipcclxuICAgICAqIOW/q+mAn+imhuebluacrOWcsOWCqOWtmO+8iOS4jeWtmOWcqOWImeaWsOW7uu+8jOWtmOWcqOWImeimhueblu+8iVxyXG4gICAgICogQHBhcmFtIHtTdHJpbmd9IGtleSDmnKzlnLDlgqjlrZjlkI1cclxuICAgICAqIEBwYXJhbSB7YW55fSBkYXRhIOS/neWtmOWGheWuuVxyXG4gICAgICovXHJcbiAgICBjb3ZlcjogZnVuY3Rpb24gKGtleSwgZGF0YSkge1xyXG4gICAgICAgIGxvY2FsU3RvcmFnZS5zZXRJdGVtKGtleSwgSlNPTi5zdHJpbmdpZnkoZGF0YSkpO1xyXG4gICAgICAgIHJldHVybiB0cnVlO1xyXG4gICAgfSxcclxuXHJcbiAgICAvKipcclxuICAgICAqIOW/q+mAn+abtOaWsOacrOWcsOWCqOWtmO+8iOS4jeWtmOWcqOWImeS4jeWFgeiuuOaWsOW7uu+8iVxyXG4gICAgICogQHBhcmFtIHtTdHJpbmd9IGtleSDmnKzlnLDlgqjlrZjlkI1cclxuICAgICAqIEBwYXJhbSB7YW55fSBkYXRhIOS/neWtmOWGheWuuVxyXG4gICAgICovXHJcbiAgICB1cGRhdGU6IGZ1bmN0aW9uIChrZXksIGRhdGEpIHtcclxuICAgICAgICBpZiAobG9jYWxTdG9yYWdlLmhhc093blByb3BlcnR5KGtleSkpIHtcclxuICAgICAgICAgICAgbG9jYWxTdG9yYWdlLnNldEl0ZW0oa2V5LCBKU09OLnN0cmluZ2lmeShkYXRhKSk7XHJcbiAgICAgICAgICAgIHJldHVybiB0cnVlO1xyXG4gICAgICAgIH1cclxuICAgICAgICBlbHNlIHJldHVybiBmYWxzZTtcclxuICAgIH0sXHJcblxyXG4gICAgLyoqXHJcbiAgICAgKiDlv6vpgJ/ojrflj5bmnKzlnLDlgqjlrZhcclxuICAgICAqIEBwYXJhbSB7U3RyaW5nfSBrZXkg5pys5Zyw5YKo5a2Y5ZCNXHJcbiAgICAgKi9cclxuICAgIGdldDogZnVuY3Rpb24gKGtleSkge1xyXG4gICAgICAgIHZhciByc3QgPSBsb2NhbFN0b3JhZ2UuZ2V0SXRlbShrZXkpO1xyXG4gICAgICAgIGlmIChyc3QpIHJldHVybiBKU09OLnBhcnNlKHJzdCk7XHJcbiAgICAgICAgZWxzZSByZXR1cm4gcnN0O1xyXG4gICAgfSxcclxuXHJcbiAgICAvKipcclxuICAgICAqIOW/q+mAn+WIoOmZpOacrOWcsOWCqOWtmFxyXG4gICAgICogQHBhcmFtIHtTdHJpbmd9IGtleSDmnKzlnLDlgqjlrZjlkI1cclxuICAgICAqL1xyXG4gICAgcmVtb3ZlOiBmdW5jdGlvbiAoa2V5KSB7XHJcbiAgICAgICAgbG9jYWxTdG9yYWdlLnJlbW92ZUl0ZW0oa2V5KTtcclxuICAgICAgICByZXR1cm4gdHJ1ZTtcclxuICAgIH0sXHJcblxyXG4gICAgLyoq5b+r6YCf5Yig6Zmk5omA5pyJ55qE5pys5Zyw5YKo5a2YICovXHJcbiAgICBjbGVhcjogZnVuY3Rpb24gKCkge1xyXG4gICAgICAgIGxvY2FsU3RvcmFnZS5jbGVhcigpO1xyXG4gICAgICAgIHJldHVybiB0cnVlO1xyXG4gICAgfSxcclxuXHJcbiAgICAvKipcclxuICAgICAqIOajgOafpeacrOWcsOWCqOWtmOWQjeaYr+WQpuWtmOWcqFxyXG4gICAgICogQHBhcmFtIHtTdHJpbmd9IGtleSDmnKzlnLDlgqjlrZjlkI1cclxuICAgICAqL1xyXG4gICAgZXhpc3Q6IGZ1bmN0aW9uIChrZXkpIHtcclxuICAgICAgICBpZiAoIWxvY2FsU3RvcmFnZS5oYXNPd25Qcm9wZXJ0eShrZXkpIHx8IGxvY2FsU3RvcmFnZS5nZXRJdGVtKGtleSkgPT0gbnVsbCkgcmV0dXJuIGZhbHNlO1xyXG4gICAgICAgIGVsc2UgcmV0dXJuIHRydWU7XHJcbiAgICB9LFxyXG5cclxuICAgIC8qKuajgOafpeacrOWcsOWCqOWtmOaJgOWNoOepuumXtCAqL1xyXG4gICAgdXNhZ2U6IGZ1bmN0aW9uICgpIHtcclxuICAgICAgICB2YXIgc2l6ZSA9IDA7XHJcbiAgICAgICAgZm9yIChsZXQgaXRlbSBpbiB3aW5kb3cubG9jYWxTdG9yYWdlKSB7XHJcbiAgICAgICAgICAgIGlmICh3aW5kb3cubG9jYWxTdG9yYWdlLmhhc093blByb3BlcnR5KGl0ZW0pKSB7XHJcbiAgICAgICAgICAgICAgICBzaXplICs9IHdpbmRvdy5sb2NhbFN0b3JhZ2UuZ2V0SXRlbShpdGVtKS5sZW5ndGg7XHJcbiAgICAgICAgICAgIH1cclxuICAgICAgICB9XHJcbiAgICAgICAgcmV0dXJuICgoc2l6ZSAvIDEwMjQpLnRvRml4ZWQoMikgKyAnS0InKTtcclxuICAgIH0sXHJcblxyXG4gICAgLyoq5qOA5p+l5pys5Zyw5YKo5a2Y5piv5ZCm5Y+v55SoICovXHJcbiAgICBhdmFpbGFibGU6IGZ1bmN0aW9uICgpIHtcclxuICAgICAgICBpZiAobG9jYWxTdG9yYWdlID09PSB1bmRlZmluZWQgfHwgbG9jYWxTdG9yYWdlID09PSBudWxsKSByZXR1cm4gZmFsc2U7XHJcbiAgICAgICAgaWYgKHh1cnVpLnNhdmUuZXhpc3QoXCJ0ZXN0XCIpKSByZXR1cm4gdHJ1ZTtcclxuICAgICAgICBlbHNlIHtcclxuICAgICAgICAgICAgeHVydWkuc2F2ZS5zZXQoXCJ0ZXN0XCIsIFwidGVzdFwiKTtcclxuICAgICAgICAgICAgaWYgKHh1cnVpLnNhdmUuZ2V0KFwidGVzdFwiKSA9PSBcInRlc3RcIikge1xyXG4gICAgICAgICAgICAgICAgeHVydWkuc2F2ZS5yZW1vdmUoXCJ0ZXN0XCIpO1xyXG4gICAgICAgICAgICAgICAgcmV0dXJuIHRydWU7XHJcbiAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgZWxzZSByZXR1cm4gZmFsc2U7XHJcbiAgICAgICAgfVxyXG4gICAgfSxcclxuXHJcbiAgICAvKipcclxuICAgICAqIOi/nueCueaTjeS9nO+8mui/lOWbnuS4iuS4gOe6p+aIluaMh+WumueCuVxyXG4gICAgICogQHBhcmFtIHtTdHJpbmd9IGtleSDmjIflrprngrlcclxuICAgICAqL1xyXG4gICAgcnQ6IGZ1bmN0aW9uIChrZXkpIHtcclxuICAgICAgICByZXR1cm4gZm4ucnQoa2V5KTtcclxuICAgIH1cclxufTtcclxuXHJcbmV4cG9ydCBkZWZhdWx0IHNhdmU7IiwiaW1wb3J0IGZvcm1hdCBmcm9tIFwiLi9mb3JtYXQuanNcIjtcclxuXHJcbi8qKuaXtumXtOaTjeS9nCAqL1xyXG52YXIgdGltZSA9IHtcclxuICAgIC8qKlxyXG4gICAgICog6I635Y+W5b2T5YmN5pe26Ze0XHJcbiAgICAgKiBAcGFyYW0ge1N0cmluZ30gc2VwZXJhdG9yIOWIhumalOespu+8jO+8iOeVmeepuuS4uuKAnDrigJ3vvIlcclxuICAgICAqL1xyXG4gICAgbm93OiBmdW5jdGlvbiAoc2VwZXJhdG9yKSB7XHJcbiAgICAgICAgc2VwZXJhdG9yID0gc2VwZXJhdG9yIHx8ICc6JztcclxuICAgICAgICB2YXIgZGF0ZSA9IG5ldyBEYXRlKCk7XHJcbiAgICAgICAgdmFyIHByZWZpeCA9IGZvcm1hdC5wcmVmaXg7XHJcbiAgICAgICAgcmV0dXJuIHByZWZpeChkYXRlLmdldEhvdXJzKCksIDIpICsgc2VwZXJhdG9yICsgcHJlZml4KGRhdGUuZ2V0TWludXRlcygpLCAyKSArIHNlcGVyYXRvciArIHByZWZpeChkYXRlLmdldFNlY29uZHMoKSwgMik7XHJcbiAgICB9XHJcbn07XHJcblxyXG5leHBvcnQgZGVmYXVsdCB0aW1lOyIsIm1vZHVsZS5leHBvcnRzID0gJDsiLCJtb2R1bGUuZXhwb3J0cyA9IGxheXVpOyJdLCJzb3VyY2VSb290IjoiIn0=