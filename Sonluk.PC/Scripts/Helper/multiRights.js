/**
 * 权限下拉框联动
 * @param {object} input
 * 目前可选联动项：工厂（GC），工作中心（GZZX），库存地点（KCDD）
 * ↓包含条件如下↓
 * 必要：
 * query：需要使用的下拉框已经对应的选择组
 * request：使用的封装请求
 * layui：使用的layui
 * 可选：
 * cache：是否对请求获取的内容进行缓存（可以单独选择，默认全部缓存）
 * done：初始化完成后的回调
 * listener：联动时的回调
 * staffId：员工ID，用于查询对应ID的缓存用，不用于请求（默认为0）
 */
function initRightList(input) {
    //#region 前置初始化

    //校验前初始化
    const prefix = 'initRightListLayFilter';
    input = input || {};
    input.query = input.query || {};
    input.request = input.request || false;
    input.layui = input.layui || false;
    input.done = input.done || function () { };
    input.listener = input.listener || function () { };
    input.staffId = input.staffId || 0;

    //强校验
    if (!input.layui) throw Error('layui错误');
    if (!input.request || typeof input.request.get !== 'function' || typeof input.request.post !== 'function') throw Error('请求方法错误');
    if (typeof input.done !== 'function') throw Error('回调必须为方法');
    if (typeof input.listener !== 'function') throw Error('监听必须为方法');
    if (typeof input.cache === 'undefined' || input.cache === true) {
        input.cache = {
            GC: true,
            GZZX: true,
            KCDD: true
        }
    }
    else if (typeof input.cache !== 'object') throw Error('缓存类型错误');
    input.query.forEach(function (item, index) {
        item.GC = check(item.GC, '工厂', 'GC' + index);
        item.GZZX = check(item.GZZX, '工作中心', 'GZZX' + index);
        item.KCDD = check(item.KCDD, '库存地点', 'KCDD' + index);
    });

    //校验后初始化
    const reqCache = {
        GC: {},
        GZZX: {},
        KCDD: {}
    };
    const form = input.layui.form;
    const layer = input.layui.layer;
    const msg = sonluk.msg;

    //#endregion

    init();

    //#region 方法

    /**
     * 初始化
     */
    function init() {
        var rGCNum = 0;
        var cGCNum = 0;
        const afterGC = function () {
            cGCNum++;
            if (rGCNum == cGCNum) input.done();
        }
        input.query.forEach(function (item, index) {
            //工厂
            if (item.GC) {
                rGCNum++;
                reqGC(item.GC.query, 0, function () {
                    afterGC();
                });
                form.on('select(' + item.GC.filter + ')', function (data) {
                    changeGC(data.value, item);
                });
            }
            //工作中心
            if (item.GZZX) {
                form.on('select(' + item.GZZX.filter + ')', function (data) {
                    changeGZZX(data.value, item);
                });
            }
            //库存地点
            if (item.KCDD) {
                form.on('select(' + item.KCDD.filter + ')', function (data) {
                    changeKCDD(data.value, item);
                });
            }
        });
        if (rGCNum == 0) input.done();
    }

    /**
     * 请求-工厂
     * @param {string} query 选择器
     * @param {string} fv 上级值
     * @param {function} callback 回调
     */
    function reqGC(query, fv, callback) {
        fv = fv || input.staffId;
        if (input.cache.GC && reqCache.GC['GC' + fv]) {
            initSelector($(query), reqCache.GC['GC' + fv]);
            callback(true);
        }
        else {
            input.request.post({
                url: 'MES/SY/ReadSY_GCByRole',
                success: function (data) {
                    if (data.success) {
                        reqCache.GC['GC' + fv] = data.data;
                        initSelector($(query), data.data);
                        callback(true);
                    }
                    else {
                        msg.error(data.messages);
                        callback(false);
                    }
                },
                error: function () {
                    callback(false);
                }
            });
        }

        function initSelector(selector, data, type) {
            type = type || 0;
            selector.empty();
            selector.append(new Option("请选择", ""));
            data.forEach(function (item) {
                selector.append(new Option(item.GC + "-" + item.GCMS, item.GC));
            });
            if (data.length == 1) selector.val(data[0].GC);
            form.render();
        }
    }

    /**
     * 请求-工作中心
     * @param {string} query 选择器
     * @param {string} fv 上级值
     * @param {function} callback 回调
     */
    function reqGZZX(query, fv, callback) {
        fv = fv || '';
        if (input.cache.GZZX && reqCache.GZZX['GZZX' + fv]) {
            initSelector($(query), reqCache.GZZX['GZZX' + fv]);
            callback(true);
        }
        else {
            input.request.post({
                url: 'MES/SY/ReadSY_GZZXByRole',
                data: { GC: fv },
                success: function (data) {
                    if (data.success) {
                        reqCache.GZZX['GZZX' + fv] = data.data;
                        initSelector($(query), data.data);
                        callback(true);
                    }
                    else {
                        msg.error(data.messages);
                        callback(false);
                    }
                },
                error: function () {
                    callback(false);
                }
            });
        }

        function initSelector(selector, data, type) {
            type = type || 0;
            selector.empty();
            selector.append(new Option("请选择", ""));
            data.forEach(function (item) {
                selector.append(new Option(item.GZZXBH + "-" + item.GZZXMS, item.GZZXBH));
            });
            if (data.length == 1) selector.val(data[0].GZZXBH);
            form.render();
        }
    }

    /**
     * 请求-库存地点
     * @param {string} query 选择器
     * @param {string} fv 上级值
     * @param {function} callback 回调
     */
    function reqKCDD(query, fv, callback) {
        fv = fv || '';
        if (input.cache.KCDD && reqCache.KCDD['KCDD' + fv]) {
            initSelector($(query), reqCache.KCDD['KCDD' + fv]);
            callback(true);
        }
        else {
            input.request.post({
                url: 'MES/MM/SELECT_MM_CK_BY_STAFFID',
                data: { GC: fv },
                success: function (data) {
                    if (data.success) {
                        reqCache.KCDD['KCDD' + fv] = data.data;
                        initSelector($(query), data.data);
                        callback(true);
                    }
                    else {
                        msg.error(data.messages);
                        callback(false);
                    }
                },
                error: function () {
                    callback(false);
                }
            });
        }

        function initSelector(selector, data, type) {
            type = type || 0;
            selector.empty();
            selector.append(new Option("请选择", ""));
            data.forEach(function (item) {
                selector.append(new Option(item.CKDM + '-' + item.CKMS, item.CKDM));
            });
            if (data.length == 1) selector.val(data[0].CKDM);
            form.render();
        }
    }

    /**
     * 监听-工厂
     * @param {string} value 值
     * @param {object} query 选择器
     */
    function changeGC(value, query) {
        var rNum = 0;
        var cNum = 0;
        const GZZX = query.GZZX;
        const KCDD = query.KCDD;
        const loading = layer.load(1);
        const after = function () {
            cNum++
            if (rNum == cNum) layer.close(loading);
        }
        if (value != "") {
            if (GZZX) {
                rNum++;
                reqGZZX(GZZX.query, value, after);
            }
            if (KCDD) {
                rNum++;
                reqKCDD(KCDD.query, value, after);
            }
        }
        else {
            if (GZZX) {
                GZZX.elem.empty();
                GZZX.elem.append(new Option("请选择", ""));
            }
            if (KCDD) {
                KCDD.elem.empty();
                KCDD.elem.append(new Option("请选择", ""));
            }
            form.render();
        }
        if (rNum == 0) layer.close(loading);
    }

    /**
     * 监听-工作中心
     * @param {string} value 值
     * @param {object} query 选择器
     */
    function changeGZZX(value, query) {
        //var rNum = 0;
        //var cNum = 0;
        //const loading = layer.load(1);
        //const after = function () {
        //    cNum++
        //    if (rNum == cNum) layer.close(loading);
        //}
        if (value != "") {
            //无
        }
        else {
            //无
            //form.render();
        }
        form.render();
    }

    /**
     * 监听-库存地点
     * @param {string} value 值
     * @param {object} query 选择器
     */
    function changeKCDD(value, query) {
        //var rNum = 0;
        //var cNum = 0;
        //const loading = layer.load(1);
        //const after = function () {
        //    cNum++
        //    if (rNum == cNum) layer.close(loading);
        //}
        if (value != "") {
            //无
        }
        else {
            //无
            //form.render();
        }
        form.render();
    }

    /**
     * 选择器校验和赋值
     * @param {any} obj 选择器
     * @param {any} name 名字
     * @param {any} id 识别代码
     */
    function check(obj, name, id) {
        if (typeof obj !== 'undefined') {
            if (typeof obj === 'string') {
                obj = {
                    filter: prefix + id,
                    query: obj,
                    elem: $(obj)
                }
                if (obj.elem.length == 0) throw Error('无法找到：' + obj.query);
                else obj.elem.attr('lay-filter', obj.filter);
                return obj;
            }
            else throw Error(name + '的query选择器不是字符串');
        }
        else return undefined;
    }

    /**
     * 查询现有选择器
     * @param {string} query 选择器
     * @param {string} ckey 验证key，可选
     */
    function findQuery(query, ckey) {
        if (typeof query === 'string') {
            for (var i = 0; i < input.query.length; i++) {
                for (let key in input.query[i]) {
                    if (input.query[i][key] && input.query[i][key].query == query) {
                        if (ckey && key != ckey) throw Error('选择器不匹配');
                        return input.query[i];
                    }
                }
            }
        }
        else throw Error('选择器必须是字符串');
        throw Error('选择器未找到');
    }

    //#endregion

    return {
        cache: reqCache,
        findQuery: findQuery,
        changeGC: function (value, query) {
            const obj = findQuery(query, 'GC');
            $(query).val(value);
            changeGC(value, obj);
        },
        changeGZZX: function (value, query) {
            const obj = findQuery(query, 'GZZX');
            $(query).val(value);
            changeGZZX(value, obj);
        },
        changeKCDD: function (value, query) {
            const obj = findQuery(query, 'KCDD');
            $(query).val(value);
            changeKCDD(value, obj);
        }
    };
}