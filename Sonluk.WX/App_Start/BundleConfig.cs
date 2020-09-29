using System.Web;
using System.Web.Optimization;

namespace Sonluk.WX
{
    public class BundleConfig
    {
        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new StyleBundle("~/Content/layui/css/login").Include("~/Scripts/layui2.2.5/css/login.css"));
            bundles.Add(new StyleBundle("~/Content/layui/css/layui").Include("~/Scripts/layui2.2.5/css/layui.css"));

            bundles.Add(new ScriptBundle("~/bundles/CRM/js/weui").Include(
                "~/Scripts/jquery-1.8.2.js",
                "~/Scripts/weui.js/dist/weui.js"
                //"~/Scripts/layui2.4.5/layui.all.js"
                ));
            bundles.Add(new StyleBundle("~/bundles/CRM/css/weui").Include(
                "~/Scripts/weui-1.1.3/weui-1.1.3/dist/style/weui.css"
                //"~/Scripts/layui2.4.5/css/layui.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/CRM/js/layui").Include(
                "~/Scripts/jquery-1.8.2.js"
                //"~/Scripts/layui2.2.5/layui.all.js"
                ));
            bundles.Add(new StyleBundle("~/bundles/CRM/css/layui").Include(
                //"~/Scripts/layui2.2.5/css/layui.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/Insert").Include(
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/KeHu/getDDL_PKH.js",
                "~/Scripts/CRM/KeHu/Insert.js",
                "~/Scripts/CRM/KeHu/SelectUpKeHu.js"

                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/Update").Include(
                "~/Scripts/CRM/KeHu/DropDownList.js",
                "~/Scripts/CRM/KeHu/SelectUpKeHu.js",
                "~/Scripts/CRM/KeHu/Update.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                 "~/Scripts/CRM/KeHu/getDDL_PKH.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/Select").Include(
                "~/Scripts/CRM/KeHu/Select.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/SAP").Include(
                "~/Scripts/CRM/KeHu/SAP.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/Qudao").Include(
                "~/Scripts/CRM/KeHu/QuDao.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/Pinzhong").Include(
                "~/Scripts/CRM/KeHu/PinZhong.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/Jingpin").Include(
                "~/Scripts/CRM/KeHu/Jingpin.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/Area").Include(
                "~/Scripts/CRM/KeHu/Area.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/Display").Include(
                "~/Scripts/CRM/KeHu/Display.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/DisplayImg").Include(
                "~/Scripts/CRM/KeHu/DisplayImg.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/KeHu/WX_IMG.js",
                "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/Partner").Include(
                "~/Scripts/CRM/KeHu/Partner.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/Contact").Include(
                "~/Scripts/CRM/KeHu/Contact.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/KeHu/WX_IMG.js",
                "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/ZXRY").Include(
                "~/Scripts/CRM/KeHu/ZXRY.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/Post").Include(
                "~/Scripts/CRM/KeHu/Post.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/Mentou").Include(
                "~/Scripts/CRM/KeHu/Mentou.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/KeHu/WX_IMG.js",
                "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/Group").Include(
                "~/Scripts/CRM/KeHu/Group.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/KaoQin").Include(
                "~/Scripts/CRM/KeHu/KaoQin.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/KaoQin_Select").Include(
                "~/Scripts/CRM/KeHu/KaoQin_Select.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/SongHuo").Include(
                "~/Scripts/CRM/KeHu/SongHuo.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/XiaoShou").Include(
                "~/Scripts/CRM/KeHu/XiaoShou.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/WDshuliang").Include(
                "~/Scripts/CRM/KeHu/WDshuliang.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/ChePai").Include(
                "~/Scripts/CRM/KeHu/ChePai.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/ChePaiImg").Include(
                "~/Scripts/CRM/KeHu/ChePaiImg.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/KeHu/WX_IMG.js",
                "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/CuXiao").Include(
                "~/Scripts/CRM/KeHu/CuXiao.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/JinZhan").Include(
                "~/Scripts/CRM/KeHu/JinZhan.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/HuoDong").Include(
                "~/Scripts/CRM/KeHu/HuoDong.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/HuoDongImg").Include(
                "~/Scripts/CRM/KeHu/HuoDongImg.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/KeHu/WX_IMG.js",
                "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/UpdateIndex").Include(
                "~/Scripts/CRM/KeHu/UpdateIndex.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/BatteryImg").Include(
                "~/Scripts/CRM/KeHu/BatteryImg.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/KeHu/WX_IMG.js",
                "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/PackImg").Include(
                "~/Scripts/CRM/KeHu/PackImg.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/KeHu/WX_IMG.js",
                "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js"
                ));



            bundles.Add(new ScriptBundle("~/bundles/CRM/Staff/Address").Include(
                "~/Scripts/CRM/Staff/Address.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/CRM/KaoQin/QianDao").Include(
                "~/Scripts/CRM/KaoQin/QianDao.js",
                "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js",
                "~/Scripts/CRM/KaoQin/GetDistance.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KaoQin/QingJia").Include(
                "~/Scripts/CRM/KaoQin/QingJia.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KaoQin/Insert_QingJia").Include(
                "~/Scripts/CRM/KaoQin/Insert_QingJia.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KaoQin/Update_QingJia").Include(
                "~/Scripts/CRM/KaoQin/Update_QingJia.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KaoQin/ChuChai").Include(
                "~/Scripts/CRM/KaoQin/ChuChai.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KaoQin/Insert_ChuChai").Include(
                "~/Scripts/CRM/KaoQin/Insert_ChuChai.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KaoQin/Select_ChuChai").Include(
                "~/Scripts/CRM/KaoQin/Select_ChuChai.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KaoQin/Update_ChuChai").Include(
                "~/Scripts/CRM/KaoQin/Update_ChuChai.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js",
                "~/Scripts/CRM/KaoQin/GetDistance.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KaoQin/HeXiao_ChuChai").Include(
                "~/Scripts/CRM/KaoQin/HeXiao_ChuChai.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KaoQin/HeXiao_Update_ChuChai").Include(
                "~/Scripts/CRM/KaoQin/HeXiao_Update_ChuChai.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js",
                "~/Scripts/CRM/KaoQin/GetDistance.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KaoQin/CCimg").Include(
                "~/Scripts/CRM/KaoQin/CCimg.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/KeHu/WX_IMG.js",
                "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KaoQin/YiChang").Include(
                "~/Scripts/CRM/KaoQin/YiChang.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KaoQin/YiChang_Single").Include(
                "~/Scripts/CRM/KaoQin/YiChang_Single.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KaoQin/BaoBiao").Include(
                "~/Scripts/CRM/KaoQin/BaoBiao.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KaoQin/BaoBiao_Personal").Include(
                "~/Scripts/CRM/KaoQin/BaoBiao_Personal.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KaoQin/Retreat_ChuChai").Include(
                "~/Scripts/CRM/KaoQin/Retreat_ChuChai.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));


            bundles.Add(new ScriptBundle("~/bundles/CRM/BaiFang/bf_log").Include(
            "~/Scripts/CRM/BaiFang/bf_log.js"));
            bundles.Add(new ScriptBundle("~/bundles/CRM/BaiFang/Select_KeHu_ToBaiFang").Include(
            "~/Scripts/CRM/BaiFang/Select_KeHu_ToBaiFang.js",
            "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js",
                        "~/Scripts/CRM/KeHu/GetDDLdata.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/BaiFang/Insert_BaiFang").Include(
                        "~/Scripts/CRM/BaiFang/Insert_BaiFang.js",
                        "~/Scripts/CRM/KeHu/GetDDLdata.js",
                        "~/Scripts/CRM/BaiFang/GetKHDZ_Distance.js",
                        "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js",
                        "~/Scripts/CRM/BaiFang/ShowLocationMap.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/BaiFang/Update_BaiFang").Include(
                        "~/Scripts/CRM/BaiFang/Update_BaiFang.js",
                        "~/Scripts/CRM/KeHu/GetDDLdata.js",
                        "~/Scripts/CRM/KeHu/WX_IMG.js",
                        "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/BaiFang/BaiFangManage").Include(
                        "~/Scripts/CRM/BaiFang/BaiFangManage.js",
                        "~/Scripts/CRM/KeHu/GetDDLdata.js",
                        "~/Scripts/CRM/BaiFang/StaffDDLByKHGroup.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/BaiFang/BaiFangReport").Include(
                        "~/Scripts/CRM/BaiFang/BaiFangReport.js",
                        "~/Scripts/CRM/KeHu/GetDDLdata.js",
                        "~/Scripts/CRM/KeHu/GetGroupByPower.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/BaiFang/Backlog").Include(
                        "~/Scripts/CRM/BaiFang/Backlog.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/BaiFang/BacklogMX").Include(
                        "~/Scripts/CRM/BaiFang/BacklogMX.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/BaiFang/ZXManage").Include(
                        "~/Scripts/CRM/BaiFang/ZXManage.js",
                        "~/Scripts/CRM/BaiFang/StaffDDLByKHGroup.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/BaiFang/Insert_ZX").Include(
                        "~/Scripts/CRM/BaiFang/Insert_ZX.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/BaiFang/Update_ZX").Include(
                        "~/Scripts/CRM/BaiFang/Update_ZX.js",
                        "~/Scripts/CRM/KeHu/GetDDLdata.js",
                        "~/Scripts/CRM/Public/Province_City.js",
                        "~/Scripts/CRM/BaiFang/StaffDDLByKHGroup.js",
                        "~/Scripts/CRM/KeHu/GetGroupByPower.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/BaiFang/ZPManage").Include(
                        "~/Scripts/CRM/BaiFang/ZPManage.js",
                        "~/Scripts/CRM/BaiFang/StaffDDLByKHGroup.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/BaiFang/Insert_ZP").Include(
                        "~/Scripts/CRM/BaiFang/Insert_ZP.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/BaiFang/Update_ZP").Include(
                        "~/Scripts/CRM/BaiFang/Update_ZP.js",
                        "~/Scripts/CRM/KeHu/GetDDLdata.js",
                        "~/Scripts/CRM/Public/Province_City.js",
                        "~/Scripts/CRM/BaiFang/StaffDDLByKHGroup.js",
                        "~/Scripts/CRM/KeHu/GetGroupByPower.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/BaiFang/BaiFangReportBySTAFF").Include(
                       "~/Scripts/CRM/BaiFang/BaiFangReportBySTAFF.js",
                        "~/Scripts/CRM/KeHu/GetDDLdata.js",
                        "~/Scripts/CRM/Public/Province_City.js",
                        "~/Scripts/CRM/KeHu/Tree_KHGroup.js"
                       ));


            bundles.Add(new ScriptBundle("~/bundles/CRM/HuoDong/InsertFee").Include(
                "~/Scripts/CRM/HuoDong/InsertFee.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/HuoDong/Arabia_to_Chinese.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/HuoDong/SelectFee_Personal").Include(
                "~/Scripts/CRM/HuoDong/SelectFee_Personal.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/HuoDong/Arabia_to_Chinese.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/HuoDong/UpdateFee").Include(
                "~/Scripts/CRM/HuoDong/UpdateFee.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/HuoDong/Arabia_to_Chinese.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/CRM/SAP/Invoice").Include(
                "~/Scripts/CRM/SAP/Invoice.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/CRM/System/Password").Include(
                "~/Scripts/CRM/System/Password.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/System/Users").Include(
                "~/Scripts/CRM/System/Users.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/System/KHPassword").Include(
               "~/Scripts/CRM/System/KHPassword.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));


            bundles.Add(new ScriptBundle("~/bundles/CRM/FCH/SAPXXTB").Include(
                "~/Scripts/CRM/FCH/SAPXXTB.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/FCH/SelectBarCode").Include(
                "~/Scripts/CRM/FCH/SelectBarCode.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/FCH/WX_ScanDXMorNHM.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/FCH/SelectBarCode_KH").Include(
                "~/Scripts/CRM/FCH/SelectBarCode_KH.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/FCH/WX_ScanDXMorNHM.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/FCH/ScanCH").Include(
               "~/Scripts/CRM/FCH/ScanCH.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/FCH/ScanCH_WX").Include(
               "~/Scripts/CRM/FCH/ScanCH_WX.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js",
               "~/Scripts/CRM/FCH/ScanBarCode.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/FCH/UpdateScanCH").Include(
               "~/Scripts/CRM/FCH/UpdateScanCH.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/FCH/FXCH_CX").Include(
               "~/Scripts/CRM/FCH/FXCH_CX.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/FCH/FXCH_CX_WX").Include(
               "~/Scripts/CRM/FCH/FXCH_CX_WX.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js",
               "~/Scripts/CRM/FCH/ScanBarCode.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/FCH/FXCH_Report").Include(
               "~/Scripts/CRM/FCH/FXCH_Report.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js",
               "~/Scripts/CRM/FCH/ScanBarCode.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/FCH/ScanCH_FX").Include(
               "~/Scripts/CRM/FCH/ScanCH_FX.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/FCH/ScanFAHUO").Include(
               "~/Scripts/CRM/FCH/ScanFAHUO.js"
               ));







            bundles.Add(new ScriptBundle("~/bundles/CRM/Order/Insert_Order").Include(
                "~/Scripts/CRM/Order/Insert_Order.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Order/Choose_Product").Include(
                "~/Scripts/CRM/Order/Choose_Product.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Order/Select_Order").Include(
                "~/Scripts/CRM/Order/Select_Order.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Order/Update_Order").Include(
                "~/Scripts/CRM/Order/Update_Order.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Order/SH_Order").Include(
                 "~/Scripts/CRM/Order/SH_Order.js",
                 "~/Scripts/CRM/KeHu/GetDDLdata.js"
                 ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Order/Report_Order").Include(
                "~/Scripts/CRM/Order/Report_Order.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));





            bundles.Add(new ScriptBundle("~/bundles/CRM/Company/Basic").Include(
                "~/Scripts/CRM/Company/Basic.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Company/Product").Include(
                "~/Scripts/CRM/Company/Product.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Company/Promotion").Include(
                "~/Scripts/CRM/Company/Promotion.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));





            bundles.Add(new ScriptBundle("~/bundles/CRM/MSG/Invoice").Include(
                "~/Scripts/CRM/MSG/Invoice.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/MSG/Notice").Include(
               "~/Scripts/CRM/MSG/Notice.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));



            //5S
            bundles.Add(new ScriptBundle("~/bundles/FIVES/Score/Create_Score").Include(
                "~/Scripts/FIVES/Score/Create_Score.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/FIVES/Score/Success").Include(
                "~/Scripts/FIVES/Score/Success.js",
                "~/Scripts/FIVES/Score/ScanPF.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/FIVES/Score/Select_Score").Include(
                "~/Scripts/FIVES/Score/Select_Score.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/FIVES/System/SY_DICT.js",
                "~/Scripts/FIVES/Score/ScanPF.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/FIVES/Score/Update_Score").Include(
                "~/Scripts/FIVES/Score/Update_Score.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/FIVES/Score/Create_Score_DJ").Include(
                "~/Scripts/FIVES/Score/Create_Score_DJ.js",
               "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/FIVES/Score/Auto_CreateScore").Include(
                "~/Scripts/FIVES/Score/Auto_CreateScore.js"
                ));




            //物流管理
            bundles.Add(new ScriptBundle("~/bundles/CRM/WL/WLIndex").Include(
                "~/Scripts/CRM/WL/WLIndex.js",
                "~/Scripts/CRM/KeHu/WX_IMG.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/FCH/ScanBarCode.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/CRM/WL/FollowWL").Include(
                "~/Scripts/CRM/WL/FollowWL.js",
                "~/Scripts/CRM/KeHu/WX_IMG.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/FCH/ScanBarCode.js"
                ));


            //费用管理
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_KACXY").Include(
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/Fee/Select_KACXY.js"
                ));
          




            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Insert_LKAyear").Include(
                "~/Scripts/CRM/Fee/Insert_LKAyear.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_LKAyear").Include(
                "~/Scripts/CRM/Fee/Select_LKAyear.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_LKAyear").Include(
                "~/Scripts/CRM/Fee/Update_LKAyear.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_ABC_Product").Include(
                "~/Scripts/CRM/Fee/Select_ABC_Product.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Insert_ABC_Product").Include(
                "~/Scripts/CRM/Fee/Insert_ABC_Product.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_ABC_Product").Include(
                "~/Scripts/CRM/Fee/Update_ABC_Product.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Insert_LKAXS").Include(
                "~/Scripts/CRM/Fee/Insert_LKAXS.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_LKAXS").Include(
                "~/Scripts/CRM/Fee/Select_LKAXS.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_LKAXS").Include(
                "~/Scripts/CRM/Fee/Update_LKAXS.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_AdCompany").Include(
                "~/Scripts/CRM/Fee/Select_AdCompany.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Insert_AdCompany").Include(
                "~/Scripts/CRM/Fee/Insert_AdCompany.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_AdCompany").Include(
                "~/Scripts/CRM/Fee/Update_AdCompany.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Check_AdCompany").Include(
                "~/Scripts/CRM/Fee/Check_AdCompany.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_ITEM").Include(
                "~/Scripts/CRM/Fee/Select_ITEM.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_Create_Fee").Include(
                "~/Scripts/CRM/Fee/Select_Create_Fee.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Insert_Create_Fee").Include(
                "~/Scripts/CRM/Fee/Insert_Create_Fee.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_Create_Fee").Include(
                "~/Scripts/CRM/Fee/Update_Create_Fee.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_LKAHXZL").Include(
                "~/Scripts/CRM/Fee/Select_LKAHXZL.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_LKAHXZL").Include(
                "~/Scripts/CRM/Fee/Update_LKAHXZL.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_LKAHXDJ").Include(
                "~/Scripts/CRM/Fee/Select_LKAHXDJ.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_LKAHXDJ").Include(
                "~/Scripts/CRM/Fee/Update_LKAHXDJ.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_HaiBao").Include(
                "~/Scripts/CRM/Fee/Select_HaiBao.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_HaiBao").Include(
                "~/Scripts/CRM/Fee/Update_HaiBao.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_Special_Display").Include(
                "~/Scripts/CRM/Fee/Select_Special_Display.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_Special_Display").Include(
                "~/Scripts/CRM/Fee/Update_Special_Display.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_Check_Create_Fee").Include(
                "~/Scripts/CRM/Fee/Select_Check_Create_Fee.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_Check_Create_Fee").Include(
                "~/Scripts/CRM/Fee/Update_Check_Create_Fee.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_Travel").Include(
                "~/Scripts/CRM/Fee/Select_Travel.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Insert_Travel").Include(
               "~/Scripts/CRM/Fee/Insert_Travel.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_Travel").Include(
               "~/Scripts/CRM/Fee/Update_Travel.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js",
               "~/Scripts/CRM/HuoDong/Arabia_to_Chinese.js",
               "~/Scripts/CRM/Public/IMG_OPINION_Load.js",
             "~/Scripts/CRM/KeHu/WX_IMG.js",
             "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_FI").Include(
               "~/Scripts/CRM/Fee/Select_FI.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_JXSCXHD").Include(
               "~/Scripts/CRM/Fee/Select_JXSCXHD.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_JXSCXHD").Include(
               "~/Scripts/CRM/Fee/Update_JXSCXHD.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_JXSRYZC").Include(
               "~/Scripts/CRM/Fee/Select_JXSRYZC.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_JXSRYZC").Include(
               "~/Scripts/CRM/Fee/Update_JXSRYZC.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Insert_KAyear").Include(
               "~/Scripts/CRM/Fee/Insert_KAyear.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_KAyear").Include(
               "~/Scripts/CRM/Fee/Select_KAyear.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_KAyear").Include(
               "~/Scripts/CRM/Fee/Update_KAyear.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js",
               "~/Scripts/CRM/Public/IMG_OPINION_Load.js",
               "~/Scripts/CRM/KeHu/WX_IMG.js",
               "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_OutDisplay").Include(
               "~/Scripts/CRM/Fee/Select_OutDisplay.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_KACXY").Include(
               "~/Scripts/CRM/Fee/Select_KACXY.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Insert_KACXY").Include(
              "~/Scripts/CRM/Fee/Insert_KACXY.js",
              "~/Scripts/CRM/KeHu/GetDDLdata.js"
              ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_KACXY").Include(
               "~/Scripts/CRM/Fee/Update_KACXY.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js",
               "~/Scripts/CRM/Public/IMG_OPINION_Load.js",
                "~/Scripts/CRM/KeHu/WX_IMG.js",
                "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_KACXYGZ").Include(
               "~/Scripts/CRM/Fee/Select_KACXYGZ.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_KACXYGZ").Include(
              "~/Scripts/CRM/Fee/Update_KACXYGZ.js",
              "~/Scripts/CRM/KeHu/GetDDLdata.js"
              ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_KHTS").Include(
               "~/Scripts/CRM/Fee/Select_KHTS.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_KHTS").Include(
               "~/Scripts/CRM/Fee/Update_KHTS.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_CBZX").Include(
               "~/Scripts/CRM/Fee/Select_CBZX.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_HaiBao_Other").Include(
               "~/Scripts/CRM/Fee/Select_HaiBao_Other.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_HaiBao_Other").Include(
               "~/Scripts/CRM/Fee/Update_HaiBao_Other.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_SH_LKAHXZL").Include(
               "~/Scripts/CRM/Fee/Select_SH_LKAHXZL.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_SH_LKAHXZL").Include(
               "~/Scripts/CRM/Fee/Update_SH_LKAHXZL.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_SH_Travel").Include(
               "~/Scripts/CRM/Fee/Select_SH_Travel.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_SH_Travel").Include(
               "~/Scripts/CRM/Fee/Update_SH_Travel.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_NKAXS").Include(
               "~/Scripts/CRM/Fee/Select_NKAXS.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Report_NKAXS").Include(
               "~/Scripts/CRM/Fee/Report_NKAXS.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_KAXS").Include(
               "~/Scripts/CRM/Fee/Select_KAXS.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_KAXS").Include(
               "~/Scripts/CRM/Fee/Update_KAXS.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_Travel_SH").Include(
                "~/Scripts/CRM/Fee/Select_Travel_SH.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_Travel_SP").Include(
                "~/Scripts/CRM/Fee/Select_Travel_SP.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_Travel_SH").Include(
                "~/Scripts/CRM/Fee/Update_Travel_SH.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/HuoDong/Arabia_to_Chinese.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_PSF").Include(
               "~/Scripts/CRM/Fee/Select_PSF.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_Other").Include(
               "~/Scripts/CRM/Fee/Select_Other.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Insert_KADT").Include(
               "~/Scripts/CRM/Fee/Insert_KADT.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_KADT").Include(
               "~/Scripts/CRM/Fee/Select_KADT.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_KADT").Include(
               "~/Scripts/CRM/Fee/Update_KADT.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js",
               "~/Scripts/CRM/Public/IMG_OPINION_Load.js",
               "~/Scripts/CRM/KeHu/WX_IMG.js",
               "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Insert_KATSCL").Include(
               "~/Scripts/CRM/Fee/Insert_KATSCL.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_KATSCL").Include(
               "~/Scripts/CRM/Fee/Select_KATSCL.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_KATSCL").Include(
               "~/Scripts/CRM/Fee/Update_KATSCL.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js",
               "~/Scripts/CRM/Public/IMG_OPINION_Load.js",
               "~/Scripts/CRM/KeHu/WX_IMG.js",
               "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Insert_MDBS").Include(
               "~/Scripts/CRM/Fee/Insert_MDBS.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_MDBS").Include(
               "~/Scripts/CRM/Fee/Select_MDBS.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_MDBS").Include(
               "~/Scripts/CRM/Fee/Update_MDBS.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js",
               "~/Scripts/CRM/Public/IMG_OPINION_Load.js",
                "~/Scripts/CRM/KeHu/WX_IMG.js",
                "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_MDBS_HX").Include(
               "~/Scripts/CRM/Fee/Update_MDBS_HX.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js",
               "~/Scripts/CRM/Public/IMG_OPINION_Load.js",
                "~/Scripts/CRM/KeHu/WX_IMG.js",
                "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Insert_KAHXZL").Include(
               "~/Scripts/CRM/Fee/Insert_KAHXZL.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_KAHXZL").Include(
               "~/Scripts/CRM/Fee/Select_KAHXZL.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_KAHXZL").Include(
               "~/Scripts/CRM/Fee/Update_KAHXZL.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js",
               "~/Scripts/CRM/Public/IMG_OPINION_Load.js",
               "~/Scripts/CRM/KeHu/WX_IMG.js",
               "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_KAHXDJ").Include(
               "~/Scripts/CRM/Fee/Select_KAHXDJ.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_KAHXDJ").Include(
               "~/Scripts/CRM/Fee/Update_KAHXDJ.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_MDBS_HX").Include(
               "~/Scripts/CRM/Fee/Select_MDBS_HX.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_JXSHXDJ").Include(
               "~/Scripts/CRM/Fee/Select_JXSHXDJ.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_JXSHXDJ").Include(
               "~/Scripts/CRM/Fee/Update_JXSHXDJ.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_SH_KAHXZL").Include(
               "~/Scripts/CRM/Fee/Select_SH_KAHXZL.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_SH_KAHXZL").Include(
               "~/Scripts/CRM/Fee/Update_SH_KAHXZL.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js",
               "~/Scripts/CRM/Public/IMG_OPINION_Load.js",
               "~/Scripts/CRM/KeHu/WX_IMG.js",
               "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_JXSFee").Include(
              "~/Scripts/CRM/Fee/Select_JXSFee.js",
              "~/Scripts/CRM/KeHu/GetDDLdata.js"
              ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_JXSFee").Include(
              "~/Scripts/CRM/Fee/Update_JXSFee.js",
              "~/Scripts/CRM/KeHu/GetDDLdata.js"
              ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_PRINT_KAHX").Include(
              "~/Scripts/CRM/Fee/Select_PRINT_KAHX.js",
              "~/Scripts/CRM/KeHu/GetDDLdata.js"
              ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_KHTSSH").Include(
              "~/Scripts/CRM/Fee/Select_KHTSSH.js",
              "~/Scripts/CRM/KeHu/GetDDLdata.js"
              ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_KHTSSH").Include(
              "~/Scripts/CRM/Fee/Update_KHTSSH.js",
              "~/Scripts/CRM/KeHu/GetDDLdata.js"
              ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_KHTSSP").Include(
              "~/Scripts/CRM/Fee/Select_KHTSSP.js",
              "~/Scripts/CRM/KeHu/GetDDLdata.js"
              ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_CXHD_CPLX").Include(
              "~/Scripts/CRM/Fee/Select_CXHD_CPLX.js",
              "~/Scripts/CRM/KeHu/GetDDLdata.js"
              ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_CXHDTT").Include(
              "~/Scripts/CRM/Fee/Select_CXHDTT.js",
              "~/Scripts/CRM/KeHu/GetDDLdata.js"
              ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_CXHDTT").Include(
              "~/Scripts/CRM/Fee/Update_CXHDTT.js",
              "~/Scripts/CRM/KeHu/GetDDLdata.js"
              ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_CXYGL").Include(
              "~/Scripts/CRM/Fee/Select_CXYGL.js",
              "~/Scripts/CRM/KeHu/GetDDLdata.js"
              ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_CXHDTT_HX").Include(
              "~/Scripts/CRM/Fee/Select_CXHDTT_HX.js",
              "~/Scripts/CRM/KeHu/GetDDLdata.js"
              ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_CXHDTT_PG").Include(
              "~/Scripts/CRM/Fee/Select_CXHDTT_PG.js",
              "~/Scripts/CRM/KeHu/GetDDLdata.js"
              ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_CXHDTT_SP").Include(
              "~/Scripts/CRM/Fee/Select_CXHDTT_SP.js",
              "~/Scripts/CRM/KeHu/GetDDLdata.js"
              ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Insert_MDBS_HX2").Include(
               "~/Scripts/CRM/Fee/Insert_MDBS_HX2.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_MDBS_HX2").Include(
               "~/Scripts/CRM/Fee/Select_MDBS_HX2.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_MDBS_HX2").Include(
               "~/Scripts/CRM/Fee/Update_MDBS_HX2.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_KAHXZL_ZZF").Include(
               "~/Scripts/CRM/Fee/Select_KAHXZL_ZZF.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_KAHXZL_ZZF").Include(
               "~/Scripts/CRM/Fee/Update_KAHXZL_ZZF.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/UpdateZZF_BaseInfo").Include(
               "~/Scripts/CRM/Fee/UpdateZZF_BaseInfo.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/UpdateZZF_GGSJT").Include(
             "~/Scripts/CRM/Fee/UpdateZZF_GGSJT.js",
             "~/Scripts/CRM/KeHu/GetDDLdata.js",
             "~/Scripts/CRM/Public/IMG_OPINION_Load.js",
              "~/Scripts/CRM/KeHu/WX_IMG.js",
              "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js"
             ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/UpdateZZF_GGXGT").Include(
               "~/Scripts/CRM/Fee/UpdateZZF_GGXGT.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js",
               "~/Scripts/CRM/Public/IMG_OPINION_Load.js",
                "~/Scripts/CRM/KeHu/WX_IMG.js",
                "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/UpdateZZF_ZZQZP").Include(
            "~/Scripts/CRM/Fee/UpdateZZF_ZZQZP.js",
            "~/Scripts/CRM/KeHu/GetDDLdata.js",
            "~/Scripts/CRM/Public/IMG_OPINION_Load.js",
             "~/Scripts/CRM/KeHu/WX_IMG.js",
             "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/UpdateZZF_GGZZMX").Include(
         "~/Scripts/CRM/Fee/UpdateZZF_GGZZMX.js",
         "~/Scripts/CRM/KeHu/GetDDLdata.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/UpdateZZF_ZWHJZP").Include(
            "~/Scripts/CRM/Fee/UpdateZZF_ZWHJZP.js",
            "~/Scripts/CRM/KeHu/GetDDLdata.js",
            "~/Scripts/CRM/Public/IMG_OPINION_Load.js",
             "~/Scripts/CRM/KeHu/WX_IMG.js",
             "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/UpdateZZF_SPYJ").Include(
            "~/Scripts/CRM/Fee/UpdateZZF_SPYJ.js",
            "~/Scripts/CRM/KeHu/GetDDLdata.js",
            "~/Scripts/CRM/Public/IMG_OPINION_Load.js",
             "~/Scripts/CRM/KeHu/WX_IMG.js",
             "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/UpdateZZF_GGZLXY").Include(
            "~/Scripts/CRM/Fee/UpdateZZF_GGZLXY.js",
            "~/Scripts/CRM/KeHu/GetDDLdata.js",
            "~/Scripts/CRM/Public/IMG_OPINION_Load.js",
             "~/Scripts/CRM/KeHu/WX_IMG.js",
             "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/UpdateZZF_GGWCHM").Include(
           "~/Scripts/CRM/Fee/UpdateZZF_GGWCHM.js",
           "~/Scripts/CRM/KeHu/GetDDLdata.js",
           "~/Scripts/CRM/Public/IMG_OPINION_Load.js",
            "~/Scripts/CRM/KeHu/WX_IMG.js",
            "~/Scripts/CRM/KaoQin/GetLocationAndAddress.js"
           ));







            bundles.Add(new ScriptBundle("~/bundles/WMS/BC_TM/YH_MARK").Include(
           "~/Scripts/WMS/BC_TM/YH_MARK.js"
           ));







        }
    }
}