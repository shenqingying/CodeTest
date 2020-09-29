var sonluk = {
    /** 版本（使用前请确认版本） */
    v: "2.2.1",
    /** 代数 */
    g: "2",
    /** 前缀 */
    name: "",

    /** 默认全局设置 */
    config: {
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
    },

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
        /** 翻译文本缓存 */
        global: {
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
        },
        /** WeUI标记 */
        weui: {
            /** 捕捉标记 */
            catched: false,
            /** 全局Loding */
            loading: {
                element: null,
                options: null
            }
        },
        /** UI渲染标记 */
        render: {
            /** 可点击标记 */
            navClick: true,
            /** 底部子导航id */
            navFuncSelector: "#func_nav",
            /** 底部主导航id */
            navMainSelector: "#main_nav",
            /** 超级按钮id */
            navSuperBtn: "#main_current",
            /** 超级按钮初始图标 */
            navSuperBtnIcon: "icon_edit",
        },
        /** layui缓存 */
        layui: {
            /** 捕捉标记 */
            catched: false,
            table: {}
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
        }
    },

    //#region Main

    /**
     * 加载域内JS
     * @param {any} location Scripts目录下的JS路径（不需要加扩展名）
     */
    loadSJS: function (location) { },
    /**
     * 加载域内CSS
     * @param {any} location Content目录下的CSS路径（不需要加扩展名）
     */
    loadSCSS: function (location) { },
    /**
     * 加载JS
     * @param {any} url JS完整URL
     */
    loadJS: function (url) { },
    /**
     * 加载CSS
     * @param {any} url CSS完整URL
     */
    loadCSS: function (url) { },

    /** 国际化与本地化 */
    global: {

        /**加载Layui多语言模块（如果Layui是模块化加载，需写到layui.use内部） */
        replaceLayui: function () { },

        /**
         * 手动设置本地文化代码（需符合i18n标准）
         * @param {String} input
         */
        setCulture: function (input) { },

        /**
         * 加载语言包，并给lid赋值（common与lv变量的key直接可用于lid，其他自定义变量需要加前缀）
         * @param {String} location 语言包路径
         * @param {String} name 自定义变量（留空则为common）
         * @param {String} type 如果自定义变量已存在时的操作（留空为替换，merge为合并）
         */
        getResources: function (location, name, type) { },

        /**
         * 仅加载语言包
         * @param {String} location 语言包路径
         * @param {String} name 自定义变量（留空则为common）
         * @param {String} type 如果自定义变量已存在时的操作（留空为替换，merge为合并）
         */
        getResourcesOnly: function (location, name, type) { },

        /**
         * 仅加载语言包（异步）
         * @param {String} location 语言包路径
         * @param {String} name 自定义变量（留空则为common）
         * @param {String} type 如果自定义变量已存在时的操作（留空为替换，merge为合并）
         */
        getResourcesOnlyAsync: function (location, name, type) { },

        /**
         * 用已获取的语言包进行翻译
         */
        translate: function () { },

        /**
         * 修改标题（head中的title）
         * @param {String} value 标题名
         */
        setTitle: function (value) { }
    },

    //#endregion

    //#region Advance模块

    /** 延时 */
    sleep: function (interval) { },

    /**
     * ajax加强版
     * @param {*} input 
     */
    ajax: function (input) { },

    /**
     * 重写方法
     * @param {string} name 方法名
     * @param {Function} func 新方法
     * @param {number} type 重新方式（默认为一次性重写，执行完后恢复；1为后继承，执行完原方法后执行新方法；2为前继承，执行完新方法后执行原方法）
     */
    override: function (name, func, type) { },

    /**
     * 克隆对象（symbol除外）
     * @param {object} obj 被克隆对象（如果要克隆函数请使用箭头函数）
     * @param {function} error 克隆失败后的报错回调（返回true则会在控制台显示警告消息）
     */
    clone: function (obj, error) { },

    //#endregion

    //#region Basic模块

    /**类型转换 */
    convert: {
        /**
         * 字符串转时间：
         * 可以使用“年月日时分秒”、“月日年时分秒”、“月日时分秒”和“时分秒”四种顺序填写，中间请用任一分隔符隔开；
         * 可以从后往前省略（省略项自动用最小值填充，年份最小值为1000），但中间不能漏；
         * 如果使用“年月日时分秒”顺序则至少需要包含“年月”。
         * 如果使用“时分秒”顺序则必须用“:”隔开。
         * @param {string} str 被转字符串
         */
        toDatetime: function (str) { }
    },

    /** Cookie */
    cookie: {
        /**
         * 获取cookie
         * @param {any} cname cookie名
         */
        get: function (cname) { }
    },

    /**日期操作 */
    date: {
        /**
         * 获取当前日期
         * @param {String} seperator 分隔符，（留空为“-”）
         */
        now: function (seperator) { }
    },

    /**时间操作 */
    time: {
        /**
         * 获取当前时间
         * @param {String} seperator 分隔符，（留空为“:”）
         */
        now: function (seperator) { }
    },

    /**字符串格式化 */
    format: {
        /**
         * 日期和时间格式化（返回字符串）
         * @param {any} date 日期（字符串或Date）
         * @param {String} format 日期格式，例如“yyyy-mm-dd”
         */
        datetime: function (date, format) { },

        /**
         * 规定长度，不足加前缀
         * @param {String} str 原始字符串
         * @param {Number} len 总长度
         * @param {String} fix 补足字符
         */
        prefix: function (str, len, fix) { },

        /**
         * 规定长度，不足加后缀
         * @param {String} str 原始字符串
         * @param {Number} len 总长度
         * @param {String} fix 补足字符
         */
        suffix: function (str, len, fix) { }
    },

    /**计算功能 */
    math: {
        /**
         * 赋予数组中的RI唯一的负数
         * @param {Array} ri_list 被赋予的数组
         */
        newnn: function (ri_list) { },

        /**
         * 计算两个时间间隔（如果返回月份及以上单位，则不保留小数）
         * @param {any} times 计算起始时间（请按照年月日时分秒顺序填写，并隔开）
         * @param {any} timee 计算结束时间（请按照年月日时分秒顺序填写，并隔开）
         * @param {String} type 返回时间单位（留空为秒，从毫秒到世纪，支持标准单位、英文以及中文）
         */
        timespan: function (times, timee, type) { }
    },

    /** 本地存储 */
    save: {
        /**
         * 快速生成本地储存名
         * @param {String} type 留空：使用通用名（存的是xurui.value），new：根据当前页面取名
         */
        name: function (type) { },

        /**
         * 快速新建本地储存（存在则不允许新建）
         * @param {String} key 本地储存名
         * @param {any} data 保存内容
         */
        set: function (key, data) { },

        /**
         * 快速覆盖本地储存（不存在则新建，存在则覆盖）
         * @param {String} key 本地储存名
         * @param {any} data 保存内容
         */
        cover: function (key, data) { },

        /**
         * 快速更新本地储存（不存在则不允许新建）
         * @param {String} key 本地储存名
         * @param {any} data 保存内容
         */
        update: function (key, data) { },

        /**
         * 快速获取本地储存
         * @param {String} key 本地储存名
         */
        get: function (key) { },

        /**
         * 快速删除本地储存
         * @param {String} key 本地储存名
         */
        remove: function (key) { },

        /**快速删除所有的本地储存 */
        clear: function () { },

        /**
         * 检查本地储存名是否存在
         * @param {String} key 本地储存名
         */
        exist: function (key) { },

        /**检查本地储存所占空间 */
        usage: function () { },

        /**检查本地储存是否可用 */
        available: function () { },

        /**
         * 连点操作：返回上一级或指定点
         * @param {String} key 指定点
         */
        rt: function (key) { }
    },

    /**
     * 合并对象（如果重复则以后一个为准）
     * @param {object} objectMain 被合并对象
     * @param {object} objectMerge 合并对象
     */
    merge: function (objectMain, objectMerge) { },

    //#endregion

    //#region Http模块

    /**http操作 */
    http: {
        /**
         * 对获得的资源数据进行下载操作（如果资源比较大，请勿使用此方式，请直接从服务器下载）
         * @param {BinaryType} data 要下载的数据
         * @param {String} name 下载后的文件名（包含扩展名）
         */
        download: function (data, name) { },

        /**
         * 上传操作
         * @param {Object} input 上传参数
         */
        upload: function (input) { },

        /**向Api发送请求操作 */
        api: {
            /**
             * 向指定Api发送请求获得下载内容（带ptoken）
             * @param {Object} input Ajax模式传入对象，非Ajax模式传入地址
             * @param {String} module Ajax模式留空，非Ajax模式传入Api模块名
             * @param {Boolean} get Ajax模式留空，非Ajax模式true为GET请求，false为POST请求，默认true
             * @param {Object} data Ajax模式留空，非Ajax模式传入数据
             */
            sdownload: function (input, module, get, data) { },
            /**
             * 向指定Api发送GET请求（带ptoken）
             * @param {Object} input Ajax模式传入对象，非Ajax模式传入地址
             * @param {Function} success Ajax模式留空，非Ajax模式传入回调函数，参数为对象化的传入数据
             * @param {String} module Ajax模式留空，非Ajax模式传入Api模块名
             * @param {Boolean} asyn Ajax模式留空，非Ajax模式传入是否异步布尔值
             */
            sget: function (input, success, module, asyn) { },
            /**
             * 向指定Api发送GET请求（带ptoken）
             * @param {Object} input Ajax模式传入对象，非Ajax模式传入地址
             * @param {Object} data Ajax模式留空，非Ajax模式传入Json字符串化之前的数据
             * @param {Function} success Ajax模式留空，非Ajax模式传入回调函数，参数为对象化的传入数据
             * @param {String} module Ajax模式留空，非Ajax模式传入Api模块名
             * @param {Boolean} asyn Ajax模式留空，非Ajax模式传入是否异步布尔值
             */
            spost: function (input, data, success, module, asyn) { },
            /**
             * 向指定Api发送请求获得下载内容（不带ptoken）
             * @param {Object} input Ajax模式传入对象，非Ajax模式传入地址
             * @param {String} module Ajax模式留空，非Ajax模式传入Api模块名
             * @param {Boolean} get Ajax模式留空，非Ajax模式true为GET请求，false为POST请求，默认true
             * @param {Object} data Ajax模式留空，非Ajax模式传入Json字符串化之前的数据（GET请求则留空）
             */
            download: function (input, module, get, data) { },
            /**
             * 向指定Api发送GET请求（不带ptoken）
             * @param {Object} input Ajax模式传入对象，非Ajax模式传入地址
             * @param {Function} success Ajax模式留空，非Ajax模式传入回调函数，参数为对象化的传入数据
             * @param {String} module Ajax模式留空，非Ajax模式传入Api模块名
             * @param {Boolean} async Ajax模式留空，非Ajax模式传入是否异步布尔值
             */
            get: function (input, success, module, async) { },
            /**
             * 向指定Api发送POST请求（不带ptoken）
             * @param {Object} input Ajax模式传入对象，非Ajax模式传入地址
             * @param {Object} data Ajax模式留空，非Ajax模式传入Json字符串化之前的数据
             * @param {Boolean} success Ajax模式留空，非Ajax模式传入回调函数，参数为对象化的传入数据
             * @param {String} module Ajax模式留空，非Ajax模式传入Api模块名
             * @param {Boolean} async Ajax模式留空，非Ajax模式传入是否异步布尔值
             */
            post: function (input, data, success, module, async) { }
        },

        /**
         * 标准http请求（类ajax用法，如果改变了contentType，请确保data格式正确）
         * @param {Object} input
         */
        ajax: function (input) { }
    },

    //#endregion

    //#region Image模块

    /**
     * 填充图标（class）
     */
    icon: {
        //常用图标
        icon_current: [],
        icon_edit: [],
        icon_func: [],
        icon_notice: [],
        icon_lock: [],
        icon_home: [],
        icon_config: [],
        icon_search: [],
        icon_add: [],
        icon_refresh: [],
        icon_list: [],
        icon_close: [],
        icon_left: [],
        icon_right: [],
        icon_resume: [],
        //线条化图标（用于功能菜单）
        icon_hollow_resume: [],
        icon_hollow_back: [],
        //设置页图标
        icon_config_Style_Dark: [],
        icon_config_Style_Color: [],
        icon_config_Cam_Default: [],
        icon_config_Cam_Quality: [],
        icon_config_Sys_Clear: [],
        icon_config_Sys_Logout: [],
        icon_config_Sys_AppConfig: [],
        icon_config_Sys_AppExit: [],
    },

    //#endregion

    //#region JPage模块

    jpage: {
        /**
         * JPage初始化（详细方法请参考参数）
         * @param {*} input input参数（【】部分为参数名）：
         *     【nav】导航栏选择器, 【page】页面选择器, 【index】默认页,
         *     【prefix】前缀，load时寻找带前缀的页面，并加载前缀加ID页面,
         *     【hash】是否开启hash，开启（true）后将监听location.hash,
         *     【translate】是否启用多语言,
         *     【sc】启用多语言后的公共资源路径（留空则不加载）,
         *     【slv】启用多语言后的个人资源路径（必须加载），可以为数组（加载多次）,
         *     【load】使用load后的固定事件, 【unload】load后的非加载页面固定事件,
         *     【go】使用go后的固定事件, 【back】使用back后的固定事件
         */
        init: function (input) { }
    },

    //#endregion

    //#region WeUI部分

    /** weui提前捕捉 */
    weuiCatch: function () { },

    /** 原始weui */
    weuiFormer: {},

    /** weui加强版 */
    weui: {
        /** 母页面标记 */
        light: function (selector) { },

        /** 左下角按钮快速设置 */
        superBtn: function (text, icon) { },

        /** 全局Loding */
        loading: {
            new: function (options) { },
            show: function (options) { },
            hide: function (callback) { },
            change: function (text) { }
        },

        topTips: function (content, options) { },

        /**
         * dialog弹窗，alert和confirm的父类
         * @param {object=} options 配置项
         * @param {string=} options.title 弹窗的标题
         * @param {string=} options.content 弹窗的内容
         * @param {string=} options.className 弹窗的自定义类名
         * @param {array=} options.buttons 按钮配置项
         *
         * @param {string} [options.buttons[].label=确定] 按钮的文字
         * @param {string} [options.buttons[].type=primary] 按钮的类型 [primary, default]
         * @param {function} [options.buttons[].onClick=$.noop] 按钮的回调
         */
        dialog: function (options) { },

        gallery: function (urls, options) { },

        nav: {}
    },

    /** UI渲染 */
    render: {
        svg: function (name) { },

        nav: function (selector) { },
    },

    //#endregion

    //#region LayUI部分

    /** layui提前捕捉 */
    layuiCatch: function () { },

    /** layui加强版 */
    layui: {

        replace: function () { },

        table: {
            limit: function (layID) { },
            render: function (input) { }
        },

        laydate: {
            render: function (input) { }
        },

        layer: {
            /**
             * 设置监听：鼠标移入显示tips，移出关闭tips
             * @param {String} elem 选择器
             * @param {String} words 显示的内容
             * @param {Boolean} bool 鼠标移入时是否显示内容（true为显示，默认为true）
             * @param {Number} dir 显示内容的方向（0为左，1为上，2为右，3为下，默认显示在右边）
             */
            hover: function (elem, words, bool, dir) { },
            confirm: function (content, options, yes, cancel) { },
            alert: function (content, options, yes) { }
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
    },

    /**消息操作 */
    msg: {
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
         */
        open: function (message, type, style, input) { },
        /**
         * 成功消息
         * @param {Object} message 消息内容（可以为数组以展示多条消息）
         * @param {Number} style 消息风格（偶数为自动消失，奇数为需点击确认）：
         * 【0】弹出若干秒后消失，【2】在0的基础上将消息以列表形式展现，【4】在0的基础上将消息以行形式展现；
         * 【1】弹出后需点确认，【3】在1的基础上将消息以列表形式展现，【5】在1的基础上将消息以行形式展现；
         * @param {Number|Function} input 回调和时间：
         * 当为数字时表示生效时间（单位为秒，当消息风格为0、2、4时生效，默认为3秒）；
         * 当为方法时表示点击回调（当消息风格为1、3、5时生效）；
         */
        success: function (message, style, input) { },
        /**
         * 警告消息
         * @param {Object} message 消息内容（可以为数组以展示多条消息）
         * @param {Number} style 消息风格（偶数为自动消失，奇数为需点击确认）：
         * 【0】弹出若干秒后消失，【2】在0的基础上将消息以列表形式展现，【4】在0的基础上将消息以行形式展现；
         * 【1】弹出后需点确认，【3】在1的基础上将消息以列表形式展现，【5】在1的基础上将消息以行形式展现；
         * @param {Number|Function} input 回调和时间：
         * 当为数字时表示生效时间（单位为秒，当消息风格为0、2、4时生效，默认为3秒）；
         * 当为方法时表示点击回调（当消息风格为1、3、5时生效）；
         */
        warning: function (message, style, input) { },
        /**
         * 错误消息
         * @param {Object} message 消息内容（可以为数组以展示多条消息）
         * @param {Number} style 消息风格（偶数为自动消失，奇数为需点击确认）：
         * 【0】弹出若干秒后消失，【2】在0的基础上将消息以列表形式展现，【4】在0的基础上将消息以行形式展现；
         * 【1】弹出后需点确认，【3】在1的基础上将消息以列表形式展现，【5】在1的基础上将消息以行形式展现；
         * @param {Number|Function} input 回调和时间：
         * 当为数字时表示生效时间（单位为秒，当消息风格为0、2、4时生效，默认为3秒）；
         * 当为方法时表示点击回调（当消息风格为1、3、5时生效）；
         */
        error: function (message, style, input) { },
        /**
         * 循环消息（界面同风格为5的普通消息，但是是循环弹出每条消息）
         * @param {Object} msgs 消息内容（如果为数组则循环弹出消息）
         * @param {Function} after 当最后一个消息点击确定后的回调
         * @param {Function} every 每个消息点击确定后的回调
         */
        repeat: function (msgs, after, every, index) { },
    },

    /**全局风格 */
    style: {
        /**
         * 读取本地存储的xurui.value
         * @param {String} key
         */
        read: function (key) { },
        /**
         * 应用xurui.value.style
         * @param {Object} config
         */
        apply: function (config) { },
        /**
         * 快速获取本地存储并使用
         * @param {String} type 留空：仅读取本地存储并应用，set：在留空基础上，如果没有本地储存则将默认值存入本地存储，mix：在set基础上，如果有本地储存则将本地存储覆盖到xurui.value
         */
        auto: function (type) { },
        /**
         * 设置标签颜色
         * @param {String} input
         */
        tagColor: function (input) { },
        /**
         * 设置左侧菜单背景色
         * @param {String} input
         */
        lrColor: function (input) { },
        /**
         * 设置顶部标题背景色
         * @param {String} input
         */
        headColor: function (input) { },
        dot: function (input, value) { },
        /**
         * 保存至本地
         * @param {String} key
         */
        save: function (key) { },
        /**
         * 返回上一级或指定点
         * @param {String} key
         */
        rt: function (key) { }
    }

    //#endregion

};

/**
 * 隐藏gallery
 * @param {Function} callback 隐藏之后的回调函数
 */
sonluk.weui.gallery.hide = function (callback) { };
/**
 * 隐藏底部导航栏
 */
sonluk.nav.hide = function () { };