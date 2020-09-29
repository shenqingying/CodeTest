//Layui全局设置
layui.config({

    //layui.js 所在路径（注意，如果是script单独引入layui.js，无需设定该参数。），一般情况下可以无视
    //dir: '/Scripts/layui2.5.4/',

    //一般用于更新模块缓存，默认不开启。设为true即让浏览器不缓存。也可以设为一个固定的值，如：201610
    version: false,

    //用于开启调试模式，默认false，如果设为true，则JS模块的节点会保留在页面
    debug: false,

    //设定扩展的Layui模块的所在目录，一般用于外部模块扩展
    base: '../../Scripts/'

}).extend({

    //设定扩展模块别名，如果js文件是在上面base目录下，并且模块名与文件名一样，则无需设定。
    //格式：mymod: 'MES/YCLSY/assist'
    MES: 'MES/MES'

});