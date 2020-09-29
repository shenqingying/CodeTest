using System.Web;
using System.Web.Optimization;

namespace Sonluk.PC
{
    public class BundleConfig
    {
        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            //sonluk组件
            bundles.Add(new ScriptBundle("~/bundles/sonlui").Include(
                        "~/Scripts/sonlui.js"));

            //jquery组件
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.cookie.js"));

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

            //layui组件
            bundles.Add(new ScriptBundle("~/bundles/CRM/js/layui").Include(
                "~/Scripts/jquery-1.8.2.js"
                ));
            bundles.Add(new StyleBundle("~/bundles/CRM/css/layui").Include(
                "~/Content/other.css"
                ));

            bundles.Add(new StyleBundle("~/Content/layui/css/login").Include("~/Scripts/layui/css/login.css"));
            bundles.Add(new StyleBundle("~/Content/layui/css/layui").Include("~/Scripts/layui/css/layui.css"));
            bundles.Add(new StyleBundle("~/Content/layui/css/layuimain").Include("~/Scripts/layui/css/layuimain.css"));

            bundles.Add(new StyleBundle("~/bundles/layui/layui").Include("~/Scripts/layui/layui.js"));
            bundles.Add(new StyleBundle("~/bundles/PS/main").Include("~/Scripts/PS/main.js"));
            bundles.Add(new StyleBundle("~/bundles/PS/ljCX").Include("~/Scripts/PS/ljCX.js"));
            bundles.Add(new StyleBundle("~/bundles/PS/QualifiedPart").Include("~/Scripts/PS/QualifiedPart.js"));
            bundles.Add(new StyleBundle("~/bundles/PS/ScrapPart").Include("~/Scripts/PS/ScrapPart.js"));
            bundles.Add(new StyleBundle("~/bundles/PS/OutSource_out").Include("~/Scripts/PS/OutSource_out.js"));
            bundles.Add(new StyleBundle("~/bundles/PS/OutSource_in").Include("~/Scripts/PS/OutSource_in.js"));
            bundles.Add(new ScriptBundle("~/bundles/CRM/BaiFang/Plan").Include(
                        "~/Scripts/CRM/BaiFang/Plan.js"));

            bundles.Add(new ScriptBundle("~/bundles/CRM/BaiFang/Assign").Include(
                        "~/Scripts/CRM/BaiFang/Assign.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/BaiFang/ToDo").Include(
                        "~/Scripts/CRM/BaiFang/ToDo.js"));
            bundles.Add(new ScriptBundle("~/bundles/CRM/BaiFang/Log").Include(
                        "~/Scripts/CRM/BaiFang/Log.js"));
            bundles.Add(new ScriptBundle("~/bundles/CRM/BaiFang/BaoBiao").Include(
                        "~/Scripts/CRM/BaiFang/BaoBiao.js"));
            bundles.Add(new ScriptBundle("~/bundles/CRM/BaiFang/Select_KeHu_ToBaiFang").Include(
                        "~/Scripts/CRM/BaiFang/Select_KeHu_ToBaiFang.js",
                        "~/Scripts/CRM/KeHu/GetDDLdata.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/BaiFang/Insert_BaiFang").Include(
                        "~/Scripts/CRM/BaiFang/Insert_BaiFang.js",
                        "~/Scripts/CRM/KeHu/GetDDLdata.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/BaiFang/Update_BaiFang").Include(
                        "~/Scripts/CRM/BaiFang/Update_BaiFang.js",
                        "~/Scripts/CRM/KeHu/GetDDLdata.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/BaiFang/BaiFangManage").Include(
                        "~/Scripts/CRM/BaiFang/BaiFangManage.js",
                        "~/Scripts/CRM/KeHu/GetDDLdata.js",
                        "~/Scripts/CRM/BaiFang/StaffDDLByKHGroup.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/BaiFang/BaiFangReport").Include(
                       "~/Scripts/CRM/BaiFang/BaiFangReport.js",
                        "~/Scripts/CRM/KeHu/GetDDLdata.js",
                        "~/Scripts/CRM/Public/Province_City.js",
                        "~/Scripts/CRM/KeHu/Tree_KHGroup.js"
                       ));

            //从零开始的拜访模块
            bundles.Add(new ScriptBundle("~/bundles/CRM/BaiFang/Backlog").Include(
                        "~/Scripts/CRM/BaiFang/Backlog.js"
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
                        "~/Scripts/CRM/BaiFang/StaffDDLByKHGroup.js"
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
                        "~/Scripts/CRM/BaiFang/StaffDDLByKHGroup.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/BaiFang/PlanManage").Include(
                        "~/Scripts/CRM/BaiFang/PlanManage.js",
                        "~/Scripts/CRM/KeHu/Tree_KHGroup.js",
                        "~/Scripts/CRM/KeHu/GetDDLdata.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/BaiFang/BaiFangReportBySTAFF").Include(
                       "~/Scripts/CRM/BaiFang/BaiFangReportBySTAFF.js",
                        "~/Scripts/CRM/KeHu/GetDDLdata.js",
                        "~/Scripts/CRM/Public/Province_City.js",
                        "~/Scripts/CRM/KeHu/Tree_KHGroup.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/BaiFang/BaiFangReportByDate").Include(
                       "~/Scripts/CRM/BaiFang/BaiFangReportByDate.js",
                        "~/Scripts/CRM/KeHu/GetDDLdata.js",
                        "~/Scripts/CRM/Public/Province_City.js",
                        "~/Scripts/CRM/KeHu/Tree_KHGroup.js"
                       ));




            bundles.Add(new ScriptBundle("~/bundles/CRM/Public/Index").Include(
                        "~/Scripts/CRM/Public/Index.js"
                        ));


            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/Insert").Include(
                "~/Scripts/CRM/KeHu/Insert.js",
                "~/Scripts/CRM/KeHu/DropDownList.js",
                "~/Scripts/CRM/KeHu/SelectUpKeHu.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/KeHu/getDDL_PKH.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/Update").Include(
                "~/Scripts/CRM/KeHu/DropDownList.js",
                "~/Scripts/CRM/KeHu/SelectUpKeHu.js",
                "~/Scripts/CRM/KeHu/Update.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/KeHu/getDDL_PKH.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/Update_SelectOnly").Include(
                "~/Scripts/CRM/KeHu/DropDownList.js",
                "~/Scripts/CRM/KeHu/SelectUpKeHu.js",
                "~/Scripts/CRM/KeHu/Update_SelectOnly.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/KeHu/getDDL_PKH.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/Select").Include(
                "~/Scripts/CRM/KeHu/Select.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/Public/DownloadFile.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/Select_SelectOnly").Include(
                "~/Scripts/CRM/KeHu/Select_SelectOnly.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/SAP").Include(
                "~/Scripts/CRM/KeHu/SAP.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/KeHuPower").Include(
                "~/Scripts/CRM/KeHu/KeHuPower.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/KeHuPower2").Include(
                "~/Scripts/CRM/KeHu/KeHuPower2.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/StaffPower").Include(
                "~/Scripts/CRM/KeHu/StaffPower.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/Staff/AllStaffDDL.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/SpaceArea").Include(
                "~/Scripts/CRM/KeHu/SpaceArea.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/Public/Province_City.js",
                "~/Scripts/CRM/Public/DownloadFile.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/Power").Include(
                "~/Scripts/CRM/KeHu/Power.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/DataReport").Include(
               "~/Scripts/CRM/KeHu/DataReport.js",
               "~/Scripts/CRM/Public/Load_ProvinceCity.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js",
               "~/Scripts/CRM/Staff/StaffDDLBYKHGroupAndDuty.js",
                "~/Scripts/CRM/Public/DownloadFile.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/Report_LKA").Include(
               "~/Scripts/CRM/KeHu/Report_LKA.js",
               "~/Scripts/CRM/Public/Load_ProvinceCity.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js",
               "~/Scripts/CRM/Staff/StaffDDLBYKHGroupAndDuty.js",
                "~/Scripts/CRM/Public/DownloadFile.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/Report_DisplayImg").Include(
                "~/Scripts/CRM/KeHu/Report_DisplayImg.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KeHu/Select_LKA_SH").Include(
             "~/Scripts/CRM/KeHu/Select_LKA_SH.js",
             "~/Scripts/CRM/KeHu/GetDDLdata.js",
             "~/Scripts/CRM/Public/DownloadFile.js"
             ));



            bundles.Add(new ScriptBundle("~/bundles/CRM/Staff/Insert").Include(
                "~/Scripts/CRM/Staff/Insert.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Staff/Select").Include(
               "~/Scripts/CRM/Staff/Select.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Staff/Update").Include(
               "~/Scripts/CRM/Staff/Update.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Staff/Manager").Include(
              "~/Scripts/CRM/Staff/Manager.js"
              ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Staff/Confirm").Include(
              "~/Scripts/CRM/Staff/Confirm.js",
              "~/Scripts/CRM/Staff/AllStaffDDL.js"
              ));



            bundles.Add(new ScriptBundle("~/bundles/CRM/KaoQin/QingJia").Include(
                "~/Scripts/CRM/KaoQin/QingJia.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KaoQin/HeXiao_QingJia").Include(
                "~/Scripts/CRM/KaoQin/HeXiao_QingJia.js"
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
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KaoQin/HeXiao_ChuChai").Include(
               "~/Scripts/CRM/KaoQin/HeXiao_ChuChai.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KaoQin/HeXiao_Update_ChuChai").Include(
               "~/Scripts/CRM/KaoQin/HeXiao_Update_ChuChai.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KaoQin/YiChang").Include(
                "~/Scripts/CRM/KaoQin/YiChang.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KaoQin/YiChang_HeXiao").Include(
                "~/Scripts/CRM/KaoQin/YiChang_HeXiao.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
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



            bundles.Add(new ScriptBundle("~/bundles/CRM/System/Department").Include(
                "~/Scripts/CRM/System/Department.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/System/Job").Include(
                "~/Scripts/CRM/System/Job.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/System/Role").Include(
                "~/Scripts/CRM/System/Role.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/System/Users").Include(
                "~/Scripts/CRM/System/Users.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/System/Data").Include(
                "~/Scripts/CRM/System/Data.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/System/Function").Include(
                "~/Scripts/CRM/System/Function.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/System/RiLi").Include(
                "~/Scripts/CRM/System/RiLi.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/System/BanZu").Include(
                "~/Scripts/CRM/System/BanZu.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/System/PinCi").Include(
                "~/Scripts/CRM/System/PinCi.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/System/SaleArea").Include(
                "~/Scripts/CRM/System/SaleArea.js",
                "~/Scripts/CRM/Public/Province_City.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/System/System").Include(
                "~/Scripts/CRM/System/System.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/System/Password").Include(
                "~/Scripts/CRM/System/Password.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/System/KHLX").Include(
                "~/Scripts/CRM/System/KHLX.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/System/KHAcount").Include(
                "~/Scripts/CRM/System/KHAcount.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/System/STAFF_OPENID").Include(
                "~/Scripts/CRM/System/STAFF_OPENID.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/System/STAFFDICT").Include(
                "~/Scripts/CRM/System/STAFFDICT.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));


            bundles.Add(new ScriptBundle("~/bundles/CRM/HuoDong/InsertFee").Include(
                "~/Scripts/CRM/HuoDong/InsertFee.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/HuoDong/Arabia_to_Chinese.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/HuoDong/SelectFee").Include(
                "~/Scripts/CRM/HuoDong/SelectFee.js",
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

            bundles.Add(new ScriptBundle("~/bundles/CRM/SAP/Order").Include(
                "~/Scripts/CRM/SAP/Order.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/SAP/Shipment").Include(
                "~/Scripts/CRM/SAP/Shipment.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/SAP/Invoice").Include(
                "~/Scripts/CRM/SAP/Invoice.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));




            bundles.Add(new ScriptBundle("~/bundles/CRM/FCH/Insert_PM").Include(
                "~/Scripts/CRM/FCH/Insert_PM.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/FCH/Select_PM").Include(
                "~/Scripts/CRM/FCH/Select_PM.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/FCH/Insert_PM_CG").Include(
                "~/Scripts/CRM/FCH/Insert_PM_CG.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/FCH/Select_PM_CG").Include(
                "~/Scripts/CRM/FCH/Select_PM_CG.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));







            bundles.Add(new ScriptBundle("~/bundles/CRM/MSG/Select_Invoice").Include(
                "~/Scripts/CRM/MSG/Select_Invoice.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/MSG/Select_Notice").Include(
                "~/Scripts/CRM/MSG/Select_Notice.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/MSG/Insert_Notice").Include(
                "~/Scripts/CRM/MSG/Insert_Notice.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/MSG/Update_Notice").Include(
                "~/Scripts/CRM/MSG/Update_Notice.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/MSG/Show_Notice").Include(
                "~/Scripts/CRM/MSG/Show_Notice.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/MSG/SH_Notice").Include(
                "~/Scripts/CRM/MSG/SH_Notice.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));




            bundles.Add(new ScriptBundle("~/bundles/CRM/Product/Insert_Product").Include(
                "~/Scripts/CRM/Product/Insert_Product.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Product/Select_Product").Include(
                "~/Scripts/CRM/Product/Select_Product.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Product/Update_Product").Include(
                "~/Scripts/CRM/Product/Update_Product.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Product/Select_ProductType").Include(
                "~/Scripts/CRM/Product/Select_ProductType.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Product/Insert_YJProduct").Include(
                "~/Scripts/CRM/Product/Insert_YJProduct.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Product/Select_YJProduct").Include(
                "~/Scripts/CRM/Product/Select_YJProduct.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Product/Update_YJProduct").Include(
                "~/Scripts/CRM/Product/Update_YJProduct.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Product/Select_ProductGroup").Include(
                "~/Scripts/CRM/Product/Select_ProductGroup.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Product/Update_ProductGroup").Include(
                "~/Scripts/CRM/Product/Update_ProductGroup.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Product/DaoRu_ProductGroup").Include(
                "~/Scripts/CRM/Product/DaoRu_ProductGroup.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Product/SetKH_ProductGroup").Include(
                "~/Scripts/CRM/Product/SetKH_ProductGroup.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Product/ProductToGroup").Include(
                "~/Scripts/CRM/Product/ProductToGroup.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
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
            bundles.Add(new ScriptBundle("~/bundles/CRM/Order/GD_Order").Include(
                "~/Scripts/CRM/Order/GD_Order.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Order/Report_Order").Include(
                "~/Scripts/CRM/Order/Report_Order.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/Public/DownloadFile.js"
                ));
            bundles.Add(new StyleBundle("~/Content/CRM/PRINT/print").Include(
                "~/Content/CRM/PRINT/print.css"
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
            bundles.Add(new ScriptBundle("~/bundles/CRM/Company/Basic_Edit").Include(
                "~/Scripts/CRM/Company/Basic_Edit.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Company/Product_Edit").Include(
                "~/Scripts/CRM/Company/Product_Edit.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Company/QYJS_Edit").Include(
                "~/Scripts/CRM/Company/QYJS_Edit.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));


            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Insert_LKAyear").Include(
                "~/Scripts/CRM/Fee/Insert_LKAyear.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_LKAyear").Include(
                "~/Scripts/CRM/Fee/Select_LKAyear.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_LKAyear_UpdateAll").Include(
                "~/Scripts/CRM/Fee/Select_LKAyear_UpdateAll.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_LKAyear").Include(
                "~/Scripts/CRM/Fee/Update_LKAyear.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/Public/fujian.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_LKAyear_UpdateAll").Include(
                "~/Scripts/CRM/Fee/Update_LKAyear_UpdateAll.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/Public/fujian.js"
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
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/Public/fujian.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_Special_Display").Include(
                "~/Scripts/CRM/Fee/Select_Special_Display.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_Special_Display").Include(
                "~/Scripts/CRM/Fee/Update_Special_Display.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/Public/fujian.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_Special_Display2").Include(
                "~/Scripts/CRM/Fee/Update_Special_Display2.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/Public/fujian.js"
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
               "~/Scripts/CRM/HuoDong/Arabia_to_Chinese.js"
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
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_KAyear").Include(
               "~/Scripts/CRM/Fee/Select_KAyear.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_KAyear").Include(
               "~/Scripts/CRM/Fee/Update_KAyear.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js",
               "~/Scripts/CRM/Public/fujian.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_OutDisplay").Include(
               "~/Scripts/CRM/Fee/Select_OutDisplay.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_KACXY").Include(
               "~/Scripts/CRM/Fee/Select_KACXY.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_KACXY").Include(
               "~/Scripts/CRM/Fee/Update_KACXY.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_KACXYGZ").Include(
               "~/Scripts/CRM/Fee/Select_KACXYGZ.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/Public/DownloadFile.js"
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
               "~/Scripts/CRM/KeHu/GetDDLdata.js",
               "~/Scripts/CRM/Public/fujian.js"
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
               "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/Public/DownloadFile.js"
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
               "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/Public/DownloadFile.js"
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
               "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/Public/DownloadFile.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_Other").Include(
               "~/Scripts/CRM/Fee/Select_Other.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_KADT").Include(
               "~/Scripts/CRM/Fee/Select_KADT.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_KADT_HX").Include(
               "~/Scripts/CRM/Fee/Select_KADT_HX.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_KADT").Include(
               "~/Scripts/CRM/Fee/Update_KADT.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js",
               "~/Scripts/CRM/Public/fujian.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_KADT_HX").Include(
               "~/Scripts/CRM/Fee/Update_KADT_HX.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js",
               "~/Scripts/CRM/Public/fujian.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_KATSCL").Include(
               "~/Scripts/CRM/Fee/Select_KATSCL.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_KATSCL_HX").Include(
               "~/Scripts/CRM/Fee/Select_KATSCL_HX.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_KATSCL").Include(
               "~/Scripts/CRM/Fee/Update_KATSCL.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js",
               "~/Scripts/CRM/Public/fujian.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_KATSCL_HX").Include(
               "~/Scripts/CRM/Fee/Update_KATSCL_HX.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js",
               "~/Scripts/CRM/Public/fujian.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_MDBS").Include(
               "~/Scripts/CRM/Fee/Select_MDBS.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js",
               "~/Scripts/CRM/Public/fujian.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_KAHXZL").Include(
               "~/Scripts/CRM/Fee/Select_KAHXZL.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_KAHXZL").Include(
               "~/Scripts/CRM/Fee/Update_KAHXZL.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
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
               "~/Scripts/CRM/KeHu/GetDDLdata.js",
               "~/Scripts/CRM/Public/fujian.js"
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
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
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
              "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/Public/DownloadFile.js"
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
              "~/Scripts/CRM/KeHu/GetDDLdata.js",
              "~/Scripts/CRM/Public/fujian.js"
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
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_MDBS_HX2").Include(
               "~/Scripts/CRM/Fee/Select_MDBS_HX2.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js",
               "~/Scripts/CRM/Public/fujian.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_KAHXZL_ZZF").Include(
               "~/Scripts/CRM/Fee/Select_KAHXZL_ZZF.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_KAHXZL_ZZF").Include(
               "~/Scripts/CRM/Fee/Update_KAHXZL_ZZF.js",
               "~/Scripts/CRM/KeHu/GetDDLdata.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_CXYWH").Include(
              "~/Scripts/CRM/Fee/Select_CXYWH.js",
              "~/Scripts/CRM/KeHu/GetDDLdata.js"
              ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/LKA_SingleReport").Include(
              "~/Scripts/CRM/Fee/LKA_SingleReport.js",
              "~/Scripts/CRM/KeHu/GetDDLdata.js",
               "~/Scripts/CRM/Public/DownloadFile.js"
              ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/JXS_Report").Include(
              "~/Scripts/CRM/Fee/JXS_Report.js"
              ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Select_Special_Display_HX").Include(
              "~/Scripts/CRM/Fee/Select_Special_Display_HX.js"
              ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/Fee/Update_Special_Display_HX").Include(
              "~/Scripts/CRM/Fee/Update_Special_Display_HX.js",
                "~/Scripts/CRM/Public/fujian.js"
              ));







            bundles.Add(new ScriptBundle("~/bundles/MSG/SYS/SYS_Info").Include(
              "~/Scripts/MSG/SYS/SYS_Info.js"
              ));
            bundles.Add(new ScriptBundle("~/bundles/MSG/SYS/MSG_SENDWAY").Include(
              "~/Scripts/MSG/SYS/MSG_SENDWAY.js"
              ));
            bundles.Add(new ScriptBundle("~/bundles/MSG/SYS/MSG_TYPE").Include(
              "~/Scripts/MSG/SYS/MSG_TYPE.js"
              ));































            //物流管理
            bundles.Add(new ScriptBundle("~/bundles/CRM/WL/Select_Wl").Include(
                "~/Scripts/CRM/WL/Select_Wl.js",
                "~/Scripts/CRM/KeHu/GetDDLdata.js",
                "~/Scripts/CRM/KeHu/WX_IMG.js"
                ));






















            bundles.Add(new StyleBundle("~/bundles/MES/PD/Assign_WorkOrder").Include(
                "~/Scripts/MES/PD/Assign_WorkOrder.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/MES/System/PLDH_MANAGE").Include(
            "~/Scripts/MES/System/PLDH_MANAGE.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/MES/System/StaffManage").Include(
                        "~/Scripts/MES/System/StaffManage.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/MES/System/SY_LANGUAGE_MANAGE").Include(
                        "~/Scripts/MES/System/SY_LANGUAGE_MANAGE.js"
                        ));
            bundles.Add(new StyleBundle("~/bundles/MES/PD/CREATE_WorkOrder").Include(
                "~/Scripts/MES/PD/CREATE_WorkOrder.js"
                ));
            bundles.Add(new StyleBundle("~/bundles/MES/PD/ADD_GD_FROMSAP").Include(
                "~/Scripts/MES/PD/ADD_GD_FROMSAP.js"
                ));
            bundles.Add(new StyleBundle("~/bundles/MES/PD/RW_SELECT").Include(
                "~/Scripts/MES/PD/RW_SELECT.js"
                ));
            bundles.Add(new StyleBundle("~/bundles/MES/MESSelect/TMGL_SELECT").Include(
                "~/Scripts/MES/MESSelect/TMGL_SELECT.js"
                ));
            bundles.Add(new StyleBundle("~/bundles/MES/Print/Print").Include(
                "~/Scripts/MES/Print/Print.js"
                ));
            bundles.Add(new StyleBundle("~/Content/MES/PRINT/print").Include("~/Content/MES/PRINT/print.css"));
            bundles.Add(new ScriptBundle("~/bundles/MES/MESSelect/PD_TL_ERROR").Include(
                        "~/Scripts/MES/MESSelect/PD_TL_ERROR.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/MES/DepositBattery/DepositBattery").Include(
                        "~/Scripts/MES/DepositBattery/DepositBattery.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/MES/MESSelect/PD_TL_SELECT").Include(
                        "~/Scripts/MES/MESSelect/PD_TL_SELECT.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/MES/MESSelect/PLDH_MANAGE_SELECT").Include(
                        "~/Scripts/MES/MESSelect/PLDH_MANAGE_SELECT.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/MES/MESSelect/PD_SCRW_SELECT_FJ").Include(
                        "~/Scripts/MES/MESSelect/PD_SCRW_SELECT_FJ.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/MES/MESSelect/PD_SCRW_SELECT_FJ_LIST").Include(
                        "~/Scripts/MES/MESSelect/PD_SCRW_SELECT_FJ_LIST.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/MES/PD/RW_SELECT_ALL").Include(
                        "~/Scripts/MES/PD/RW_SELECT_ALL.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/MES/PD/YF_WorkOrder").Include(
                "~/Scripts/MES/PD/YF_WorkOrder.js"
                ));


            bundles.Add(new ScriptBundle("~/bundles/MES/System/DataGather").Include(
                        "~/Scripts/MES/System/DataGather.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/MES/System/DepotRole").Include(
                        "~/Scripts/MES/System/DepotRole.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/MES/System/DeviceManage").Include(
                        "~/Scripts/MES/System/DeviceManage.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/MES/System/FactoryManage").Include(
                        "~/Scripts/MES/System/FactoryManage.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/MES/System/FJ").Include(
                        "~/Scripts/MES/System/FJ.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/MES/System/Formula_Order").Include(
                        "~/Scripts/MES/System/Formula_Order.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/MES/System/Material").Include(
                        "~/Scripts/MES/System/Material.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/MES/System/Material_Group").Include(
                        "~/Scripts/MES/System/Material_Group.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/MES/System/PJCOUNT").Include(
                        "~/Scripts/MES/System/PJCOUNT.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/MES/System/PositionRole").Include(
                        "~/Scripts/MES/System/PositionRole.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/MES/System/QuantityManage").Include(
                        "~/Scripts/MES/System/QuantityManage.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/MES/System/ReplaceBZ").Include(
                        "~/Scripts/MES/System/ReplaceBZ.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/MES/System/RY_MANAGE").Include(
                        "~/Scripts/MES/System/RY_MANAGE.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/MES/System/WorkCenter").Include(
                        "~/Scripts/MES/System/WorkCenter.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/MES/System/WorkCenterRole").Include(
                        "~/Scripts/MES/System/WorkCenterRole.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/MES/System/SBSelect").Include(
                        "~/Scripts/MES/System/SBSelect.js",
                        "~/Scripts/html2canvas.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/MES/System/QDCodeSC").Include(
                        "~/Scripts/MES/System/QDCodeSC.js",
                        "~/Scripts/html2canvas.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/html2canvas").Include(
                         "~/Scripts/html2canvas.js"
                         ));
            bundles.Add(new ScriptBundle("~/bundles/MES/System/BBXX").Include(
                        "~/Scripts/MES/System/BBXX.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/MES/MESSelect/CHANGEINFO_SELECT").Include(
                       "~/Scripts/MES/MESSelect/CHANGEINFO_SELECT.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/MES/MESSelect/SCJD_SELECT").Include(
                     "~/Scripts/MES/MESSelect/SCJD_SELECT.js"
                     ));
            bundles.Add(new ScriptBundle("~/bundles/MES/TMManage/TM_DELETE").Include(
                       "~/Scripts/MES/TMManage/TM_DELETE.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/MES/TMManage/TM_UPDATE_ZT_PL").Include(
                       "~/Scripts/MES/TMManage/TM_UPDATE_ZT_PL.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/MES/TMManage/SCDATE_TH").Include(
                       "~/Scripts/MES/TMManage/SCDATE_TH.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/MES/MESSelect/FJ_ALL_TLXX").Include(
                       "~/Scripts/MES/MESSelect/FJ_ALL_TLXX.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/MES/MESSelect/TL_GL_CC_SELECT").Include(
                       "~/Scripts/MES/MESSelect/TL_GL_CC_SELECT.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/MES/System/MES_SBBH_TD").Include(
                       "~/Scripts/MES/System/MES_SBBH_TD.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/MES/TPM/TPM_Manage").Include(
                       "~/Scripts/MES/TPM/TPM_Manage.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/MES/TPM/TPM_SELECT").Include(
                       "~/Scripts/MES/TPM/TPM_SELECT.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/MES/TPM/TPM_ZHNO_Manage").Include(
                       "~/Scripts/MES/TPM/TPM_ZHNO_Manage.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/MES/TPM/TPM_ZHNO_SELECT").Include(
                       "~/Scripts/MES/TPM/TPM_ZHNO_SELECT.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/MES/YCLSY/BAT_SPECS").Include(
                       "~/Scripts/MES/YCLSY/BAT_SPECS.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/MES/YCLSY/BAT_SPECS_SAMP").Include(
                       "~/Scripts/MES/YCLSY/BAT_SPECS_SAMP.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/MES/YCLSY/BAT_SPECS_PERFOR").Include(
                       "~/Scripts/MES/YCLSY/BAT_SPECS_PERFOR.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/MES/YCLSY/BAT_PACKAGE").Include(
                       "~/Scripts/MES/YCLSY/BAT_PACKAGE.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/MES/YCLSY/BAT_REPORT").Include(
                       "~/Scripts/MES/YCLSY/BAT_REPORT.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/MES/YCLSY/BAT_QLTY").Include(
                       "~/Scripts/MES/YCLSY/BAT_QLTY.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/MES/YCLSY/BAT_QLTY_TMARK").Include(
                       "~/Scripts/MES/YCLSY/BAT_QLTY_TMARK.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/MES/YCLSY/BAT_QLTY_REPORT").Include(
                       "~/Scripts/MES/YCLSY/BAT_QLTY_REPORT.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/MES/ZS/CLPB_MANAGE").Include(
                       "~/Scripts/MES/ZS/CLPB_MANAGE.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/MES/ZS/CLPB_MANAGE_SELECT").Include(
                       "~/Scripts/MES/ZS/CLPB_MANAGE_SELECT.js"
           ));
            bundles.Add(new ScriptBundle("~/bundles/MES/ZS/ZS_KCMXSELECT_MANAGE").Include(
                       "~/Scripts/MES/ZS/ZS_KCMXSELECT_MANAGE.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/MES/ZS/ZS_KCSELECT_MANAGE").Include(
                       "~/Scripts/MES/ZS/ZS_KCSELECT_MANAGE.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/MES/ZS/ZS_MFQFG_MANAGE").Include(
                       "~/Scripts/MES/ZS/ZS_MFQFG_MANAGE.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/MES/ZS/ZS_MFQQJ_MANAGE").Include(
                      "~/Scripts/MES/ZS/ZS_MFQQJ_MANAGE.js"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/MES/ZS/ZS_QJ_ERRORJL_SELECT").Include(
                      "~/Scripts/MES/ZS/ZS_QJ_ERRORJL_SELECT.js"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/MES/ZS/ZS_TL_MANAGE").Include(
                      "~/Scripts/MES/ZS/ZS_TL_MANAGE.js"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/MES/ZS/ZS_MFQQJ_SBLIST").Include(
               "~/Scripts/MES/ZS/ZS_MFQQJ_SBLIST.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/MES/ZS/ZS_TEST").Include(
              "~/Scripts/MES/ZS/ZS_TEST.js"
              ));

            bundles.Add(new ScriptBundle("~/bundles/FIVES/System/DICTIONARY").Include(
              "~/Scripts/FIVES/System/Dictionary.js"
              ));
            bundles.Add(new ScriptBundle("~/bundles/FIVES/System/CHECKDETAILS").Include(
             "~/Scripts/FIVES/System/CheckDetails.js"
             ));

            bundles.Add(new ScriptBundle("~/bundles/HR/ZZJG/DEPT_REPORT_BZKHREPORT").Include(
                       "~/Scripts/HR/ZZJG/DEPT_REPORT_BZKHREPORT.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/ZZJG/GSMANAGE").Include(
                       "~/Scripts/HR/ZZJG/GSMANAGE.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/ZZJG/DEPTMANAGE").Include(
                       "~/Scripts/HR/ZZJG/DEPTMANAGE.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/TAX/TAXMANAGE").Include(
                       "~/Scripts/HR/TAX/TAXMANAGE.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/XZGL/XZGL_FFJL").Include(
                       "~/Scripts/HR/XZGL/XZGL_FFJL.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/XZGL/XZGL_FFJL_BACK").Include(
                       "~/Scripts/HR/XZGL/XZGL_FFJL_BACK.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/XZGL/XZGL_FFJL_FFMXREPORT").Include(
                       "~/Scripts/HR/XZGL/XZGL_FFJL_FFMXREPORT.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/XZGL/XZGL_FFJL_GUOSREPORT").Include(
                       "~/Scripts/HR/XZGL/XZGL_FFJL_GUOSREPORT.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/XZGL/XZGL_FFJL_GZXJSDREPORT").Include(
                       "~/Scripts/HR/XZGL/XZGL_FFJL_GZXJSDREPORT.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/XZGL/XZGL_FFJL_REPORT").Include(
                       "~/Scripts/HR/XZGL/XZGL_FFJL_REPORT.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/XZGL/XZGL_FFJLLIST").Include(
                       "~/Scripts/HR/XZGL/XZGL_FFJLLIST.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/XZGL/XZGL_FFJLLIST_TZ").Include(
                       "~/Scripts/HR/XZGL/XZGL_FFJLLIST_TZ.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/XZGL/XZGL_FFJLMX_GAOWENJTREPORT").Include(
                       "~/Scripts/HR/XZGL/XZGL_FFJLMX_GAOWENJTREPORT.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/XZGL/XZGL_FFJLMX_TXFREPORT").Include(
                       "~/Scripts/HR/XZGL/XZGL_FFJLMX_TXFREPORT.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/XZGL/XZGL_FLFA").Include(
                       "~/Scripts/HR/XZGL/XZGL_FLFA.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/XZGL/XZGL_JJFL_HEAD_MANAGE").Include(
                       "~/Scripts/HR/XZGL/XZGL_JJFL_HEAD_MANAGE.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/XZGL/XZGL_JJFL_HEARNAME_MANAGE").Include(
                       "~/Scripts/HR/XZGL/XZGL_JJFL_HEARNAME_MANAGE.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/XZGL/XZGL_JJFL_MX").Include(
                       "~/Scripts/HR/XZGL/XZGL_JJFL_MX.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/XZGL/XZGL_JJFL_MX_MANAGE").Include(
                       "~/Scripts/HR/XZGL/XZGL_JJFL_MX_MANAGE.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/XZGL/XZGL_MBGL").Include(
                       "~/Scripts/HR/XZGL/XZGL_MBGL.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/XZGL/XZGL_MONTHXZJL").Include(
                       "~/Scripts/HR/XZGL/XZGL_MONTHXZJL.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/XZGL/XZGL_XZDA").Include(
                       "~/Scripts/HR/XZGL/XZGL_XZDA.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/XZGL/XZGL_XZDA_TZJL").Include(
                       "~/Scripts/HR/XZGL/XZGL_XZDA_TZJL.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/XZGL/XZGL_XZDA_ZHMANAGE").Include(
                       "~/Scripts/HR/XZGL/XZGL_XZDA_ZHMANAGE.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/XZGL/XZGL_ZDMANAGE").Include(
                       "~/Scripts/HR/XZGL/XZGL_ZDMANAGE.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/XZGL/XZGL_ZXFJKC").Include(
                       "~/Scripts/HR/XZGL/XZGL_ZXFJKC.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/XZGL/XZGL_FLDA").Include(
                       "~/Scripts/HR/XZGL/XZGL_FLDA.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/XZGL/XZGL_ZQMONTH_MANAGE").Include(
                       "~/Scripts/HR/XZGL/XZGL_ZQMONTH_MANAGE.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/SYSTEM/SY_TYPEMX").Include(
                       "~/Scripts/HR/SYSTEM/SY_TYPEMX.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/SYSTEM/SY_GSLY").Include(
                       "~/Scripts/HR/SYSTEM/SY_GSLY.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/SYSTEM/SY_ZJH").Include(
                       "~/Scripts/HR/SYSTEM/SY_ZJH.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/SYSTEM/MYMANAGE").Include(
                       "~/Scripts/HR/SYSTEM/MYMANAGE.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/SYSTEM/MYMANAGE_ADMIN").Include(
                       "~/Scripts/HR/SYSTEM/MYMANAGE_ADMIN.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/SYSTEM/MYMANAGE_STAFFID").Include(
                       "~/Scripts/HR/SYSTEM/MYMANAGE_STAFFID.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/ZZJG/DUTYMANAGE").Include(
                       "~/Scripts/HR/ZZJG/DUTYMANAGE.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/RYGL/RY_RYINFO_RLZREPORT").Include(
                       "~/Scripts/HR/RYGL/RY_RYINFO_RLZREPORT.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/RYGL/YPDJ").Include(
                       "~/Scripts/HR/RYGL/YPDJ.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/RYGL/RYINFOGL").Include(
                       "~/Scripts/HR/RYGL/RYINFOGL.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/RYGL/RYINFO_CHECK").Include(
                       "~/Scripts/HR/RYGL/RYINFO_CHECK.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/RYGL/RYINFOGL_MAIN").Include(
                       "~/Scripts/HR/RYGL/RYINFOGL_MAIN.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/RYGL/WS_RYINFOGL").Include(
                       "~/Scripts/HR/RYGL/WS_RYINFOGL.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/RYGL/WS_RYINFO_CHECK").Include(
                       "~/Scripts/HR/RYGL/WS_RYINFO_CHECK.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/RYGL/WS_RYINFOGL_MAIN").Include(
                       "~/Scripts/HR/RYGL/WS_RYINFOGL_MAIN.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/RYGL/RYINFO_RSDA").Include(
                       "~/Scripts/HR/RYGL/RYINFO_RSDA.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/RYGL/RYINFO_ISINGH").Include(
                       "~/Scripts/HR/RYGL/RYINFO_ISINGH.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/RYGL/RYINFO_RSDA_EDIT").Include(
                       "~/Scripts/HR/RYGL/RYINFO_RSDA_EDIT.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/RYGL/RYINFO_RSDA_EDIT_CHILD").Include(
                       "~/Scripts/HR/RYGL/RYINFO_RSDA_EDIT_CHILD.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/RYGL/RYINFO_HTGL").Include(
                       "~/Scripts/HR/RYGL/RYINFO_HTGL.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/KQGL/KQ_BDMANAGE").Include(
                       "~/Scripts/HR/KQGL/KQ_BDMANAGE.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/KQGL/KQ_BZ_MANAGE").Include(
                       "~/Scripts/HR/KQGL/KQ_BZ_MANAGE.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/KQGL/KQ_DEPT_MANAGE").Include(
                       "~/Scripts/HR/KQGL/KQ_DEPT_MANAGE.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/KQGL/KQ_DEPTKQ_MANAGE").Include(
                       "~/Scripts/HR/KQGL/KQ_DEPTKQ_MANAGE.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/KQGL/KQ_DEPTKQ_SELECT").Include(
                      "~/Scripts/HR/KQGL/KQ_DEPTKQ_SELECT.js"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/HR/KQGL/KQ_JQGL").Include(
                       "~/Scripts/HR/KQGL/KQ_JQGL.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/KQGL/KQ_JQGLMX").Include(
                       "~/Scripts/HR/KQGL/KQ_JQGLMX.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/KQGL/KQ_JQGLREPORT").Include(
                       "~/Scripts/HR/KQGL/KQ_JQGLREPORT.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/KQGL/KQ_PBFZ_MANAGE").Include(
                       "~/Scripts/HR/KQGL/KQ_PBFZ_MANAGE.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/KQGL/KQ_QJ_MANAGE").Include(
                      "~/Scripts/HR/KQGL/KQ_QJ_MANAGE.js"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/HR/KQGL/KQ_QJ_REPORT").Include(
                      "~/Scripts/HR/KQGL/KQ_QJ_REPORT.js"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/HR/KQGL/KQ_RY_MANAGE").Include(
                       "~/Scripts/HR/KQGL/KQ_RY_MANAGE.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/KQGL/KQ_WCDJ_MANAGE").Include(
                      "~/Scripts/HR/KQGL/KQ_WCDJ_MANAGE.js"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/HR/KQGL/KQ_YCKQ_MANAGE").Include(
                      "~/Scripts/HR/KQGL/KQ_YCKQ_MANAGE.js"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/HR/KQGL/KQ_YSKQJL").Include(
                       "~/Scripts/HR/KQGL/KQ_YSKQJL.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/KQGL/KQ_YSKQJL_check").Include(
                       "~/Scripts/HR/KQGL/KQ_YSKQJL_check.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/XZGL/XZGL_FLDATZ").Include(
                       "~/Scripts/HR/XZGL/XZGL_FLDATZ.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/XZGL/XZGL_FLDATZMX").Include(
                       "~/Scripts/HR/XZGL/XZGL_FLDATZMX.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/XZGL/XZGL_KKGL").Include(
                       "~/Scripts/HR/XZGL/XZGL_KKGL.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/XZGL/XZGL_KKGLMX").Include(
                       "~/Scripts/HR/XZGL/XZGL_KKGLMX.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/TJBB/TJ_GLBB").Include(
                       "~/Scripts/HR/TJBB/TJ_GLBB.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/TJBB/GSMX_CXBB").Include(
                       "~/Scripts/HR/TJBB/GSMX_CXBB.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/TJBB/WJWG_CXBB").Include(
                       "~/Scripts/HR/TJBB/WJWG_CXBB.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/TJBB/WBZW_CXBB").Include(
                       "~/Scripts/HR/TJBB/WBZW_CXBB.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/TJBB/BIRTH_CXBB").Include(
                       "~/Scripts/HR/TJBB/BIRTH_CXBB.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/TJBB/TJBB_CHANGEINFO_RYINFO").Include(
                       "~/Scripts/HR/TJBB/TJBB_CHANGEINFO_RYINFO.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/TJBB/TJBB_ZCREPORT").Include(
                       "~/Scripts/HR/TJBB/TJBB_ZCREPORT.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/HRXZGL/RONGYGL").Include(
                       "~/Scripts/HR/HRXZGL/RONGYGL.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/HRXZGL/XZGL_JSDA").Include(
                       "~/Scripts/HR/HRXZGL/XZGL_JSDA.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/HRXZGL/BOOKZL").Include(
                       "~/Scripts/HR/HRXZGL/BOOKZL.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/HRXZGL/BOOKJY").Include(
                       "~/Scripts/HR/HRXZGL/BOOKJY.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/HRXZGL/DORM_MANAGE").Include(
                       "~/Scripts/HR/HRXZGL/DORM_MANAGE.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/HRXZGL/LIVE_MANAGE").Include(
                       "~/Scripts/HR/HRXZGL/LIVE_MANAGE.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/HRXZGL/LIVEMX_REPORT").Include(
                       "~/Scripts/HR/HRXZGL/LIVEMX_REPORT.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/HRXZGL/YCRY_REPORT").Include(
                       "~/Scripts/HR/HRXZGL/YCRY_REPORT.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/HRXZGL/YHRY_MANAGE").Include(
                       "~/Scripts/HR/HRXZGL/YHRY_MANAGE.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/PXFZ/PXZT").Include(
                       "~/Scripts/HR/PXFZ/PXZT.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/HR/PXFZ/PXMX").Include(
                       "~/Scripts/HR/PXFZ/PXMX.js"
                       ));




            bundles.Add(new ScriptBundle("~/bundles/FIVES/System/CHECKPOINT").Include(
           "~/Scripts/FIVES/System/CheckPoint.js",
           "~/Scripts/FIVES/System/SY_DICT.js"
           ));
            bundles.Add(new ScriptBundle("~/bundles/FIVES/System/SY_DICT").Include(
          "~/Scripts/FIVES/System/SY_DICT.js"
          ));
            bundles.Add(new ScriptBundle("~/bundles/FIVES/System/STAFF_DEP").Include(
                       "~/Scripts/FIVES/System/STAFF_DEP.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/FIVES/System/STAFF_DEP_ACCESS").Include(
                       "~/Scripts/FIVES/System/STAFF_DEP_ACCESS.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/FIVES/Report/CheckInfo").Include(
                   "~/Scripts/FIVES/Report/CheckInfo.js"
                   ));
            bundles.Add(new ScriptBundle("~/bundles/FIVES/Report/DJHZ").Include(
                   "~/Scripts/FIVES/Report/DJHZ.js"
                   ));
            bundles.Add(new ScriptBundle("~/bundles/FIVES/Report/BHGDJ").Include(
                   "~/Scripts/FIVES/Report/BHGDJ.js"
                   ));
            bundles.Add(new ScriptBundle("~/bundles/FIVES/System/CheckXMFL").Include(
                  "~/Scripts/FIVES/System/CheckXMFL.js"
                  ));
            bundles.Add(new ScriptBundle("~/bundles/FIVES/System/CHECKPOINTFL").Include(
                 "~/Scripts/FIVES/System/CheckPointFL.js"
                 ));
            bundles.Add(new ScriptBundle("~/bundles/FIVES/Report/UPDATE_INFO").Include(
                 "~/Scripts/FIVES/Report/UPDATE_INFO.js"
                 ));
            bundles.Add(new ScriptBundle("~/bundles/FIVES/Report/SELECT_COMPARE").Include(
                 "~/Scripts/FIVES/Report/SELECT_COMPARE.js"
                 ));
            bundles.Add(new ScriptBundle("~/bundles/PS/jgfh").Include(
                "~/Scripts/PS/jgfh.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/PS/updateNetwork").Include(
                "~/Scripts/PS/updateNetwork.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/PS/CNYJ").Include(
                "~/Scripts/PS/CNYJ.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/PS/Modify_GZCN").Include(
                "~/Scripts/PS/Modify_GZCN.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/PS/PS_CALENDAR").Include(
              "~/Scripts/PS/ps_calendar.js"
              ));
            bundles.Add(new ScriptBundle("~/bundles/EM/system/XTBB").Include(
            "~/Scripts/EM/system/XTBB.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/EM/system/INSERT_EM").Include(
            "~/Scripts/EM/system/INSERT_EM.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/EM/system/SELECT_EM").Include(
           "~/Scripts/EM/system/SELECT_EM.js"
           ));
            bundles.Add(new ScriptBundle("~/bundles/EM/system/MODIFY_EM").Include(
           "~/Scripts/EM/system/MODIFY_EM.js"
           ));
            bundles.Add(new ScriptBundle("~/bundles/EM/system/Contact_Management").Include(
           "~/Scripts/EM/system/Contact_Management.js"
           ));
            bundles.Add(new ScriptBundle("~/bundles/EM/system/PBGL").Include(
           "~/Scripts/EM/system/PBGL.js"
           ));

            bundles.Add(new ScriptBundle("~/bundles/EM/system/DEVICEGUIDE").Include(
            "~/Scripts/EM/system/DEVICEGUIDE.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/EM/system/DEVICEGUIDEDETAIL").Include(
            "~/Scripts/EM/system/DEVICEGUIDEDETAIL.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/EM/system/DEVICERQJL").Include(
            "~/Scripts/EM/system/DEVICERQJL.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/EM/system/SBBHDEVICEGUIDE").Include(
            "~/Scripts/EM/system/SBBHDEVICEGUIDE.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/EM/system/MISSION_GL").Include(
            "~/Scripts/EM/system/MISSION_GL.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/EM/system/MISSION_Select").Include(
            "~/Scripts/EM/system/MISSION_Select.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/CRM/KAOrder/DDCXDY").Include(
          "~/Scripts/CRM/KAOrder/DDCXDY.js"
          ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KAOrder/SelectOrderMX").Include(
        "~/Scripts/CRM/KAOrder/SelectOrderMX.js"
        ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KAOrder/SHBG").Include(
           "~/Scripts/CRM/KAOrder/SHBG.js"
           ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KAOrder/SHBGMX").Include(
           "~/Scripts/CRM/KAOrder/SHBGMX.js"
           ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KAOrder/CreateOrder").Include(
           "~/Scripts/CRM/KAOrder/CreateOrder.js"
           ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KAOrder/HHXXWH").Include(
          "~/Scripts/CRM/KAOrder/HHXXWH.js",
          "~/Scripts/CRM/KeHu/GetDDLdata.js",
          "~/Scripts/CRM/Public/DownloadFile.js"
          ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KAOrder/DRF_LOGIN").Include(
          "~/Scripts/CRM/KAOrder/DRF_LOGIN.js"
          ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KAOrder/ShowPDF").Include(
          "~/Scripts/CRM/KAOrder/ShowPDF.js"
          ));
            bundles.Add(new ScriptBundle("~/bundles/CRM/KAOrder/HHXXWH_KB").Include(
         "~/Scripts/CRM/KAOrder/HHXXWH_KB.js",
          "~/Scripts/CRM/Public/DownloadFile.js"
         ));


            //FICO
            bundles.Add(new ScriptBundle("~/bundles/FICO/FM/ElectricInvoice").Include(
         "~/Scripts/FICO/FM/ElectricInvoice.js"
         ));
            bundles.Add(new ScriptBundle("~/bundles/FICO/FM/ElectricInvoiceForEdit").Include(
         "~/Scripts/FICO/FM/ElectricInvoiceForEdit.js"
         ));
            bundles.Add(new ScriptBundle("~/bundles/FICO/FM/Select_ElectricInvoice").Include(
        "~/Scripts/FICO/FM/Select_ElectricInvoice.js"
        ));
            //BARCODING
            bundles.Add(new ScriptBundle("~/bundles/BARCODE/SYSTEM/CODING").Include(
         "~/Scripts/BARCODE/SYSTEM/CODING.js",
          "~/Scripts/CRM/KeHu/GetDDLdata.js"
         ));
            bundles.Add(new ScriptBundle("~/bundles/BARCODE/SYSTEM/READ_CODING").Include(
         "~/Scripts/BARCODE/SYSTEM/READ_CODING.js",
          "~/Scripts/CRM/KeHu/GetDDLdata.js"
         ));
            bundles.Add(new ScriptBundle("~/bundles/BARCODE/SYSTEM/MANAGE_CODING").Include(
         "~/Scripts/BARCODE/SYSTEM/MANAGE_CODING.js",
          "~/Scripts/CRM/KeHu/GetDDLdata.js"
         ));
            bundles.Add(new ScriptBundle("~/bundles/BARCODE/SYSTEM/CREATE_CODE").Include(
         "~/Scripts/BARCODE/SYSTEM/CREATE_CODE.js",
          "~/Scripts/CRM/KeHu/GetDDLdata.js"
         ));
            bundles.Add(new ScriptBundle("~/bundles/MES/SYSTEM/SY_CN_SELECT").Include(
        "~/Scripts/MES/SYSTEM/SY_CN_SELECT.js"
        ));
            bundles.Add(new ScriptBundle("~/bundles/MES/SYSTEM/SY_CN_MANAGE").Include(
       "~/Scripts/MES/SYSTEM/SY_CN_MANAGE.js"
       ));
            bundles.Add(new ScriptBundle("~/bundles/MES/SYSTEM/SY_GYLX_MANAGE").Include(
       "~/Scripts/MES/SYSTEM/SY_GYLX_MANAGE.js"
       ));
            bundles.Add(new ScriptBundle("~/bundles/MES/SYSTEM/SY_GYLX_SELECT").Include(
       "~/Scripts/MES/SYSTEM/SY_GYLX_SELECT.js"
       ));
            bundles.Add(new ScriptBundle("~/bundles/MES/SCH/BILL_MANAGE").Include(
       "~/Scripts/MES/SCH/BILL_MANAGE.js"
       ));
            bundles.Add(new ScriptBundle("~/bundles/MES/SCH/BILL_SELECT").Include(
      "~/Scripts/MES/SCH/BILL_SELECT.js"
      ));
            bundles.Add(new ScriptBundle("~/bundles/MES/SCH/SCHEDULES_MANAGE").Include(
      "~/Scripts/MES/SCH/SCHEDULES_MANAGE.js"
      ));
            bundles.Add(new ScriptBundle("~/bundles/MES/SCH/SCHEDULES_SELECT").Include(
     "~/Scripts/MES/SCH/SCHEDULES_SELECT.js"
     ));
            bundles.Add(new ScriptBundle("~/bundles/MES/SCH/PB_MANAGE").Include(
     "~/Scripts/MES/SCH/PB_MANAGE.js"
     ));
            bundles.Add(new ScriptBundle("~/bundles/MES/SCH/PB_SELECT").Include(
     "~/Scripts/MES/SCH/PB_SELECT.js"
     ));

            bundles.Add(new ScriptBundle("~/bundles/MES/SYSTEM/SY_GZZX_SBBH_STATUS").Include(
      "~/Scripts/MES/SYSTEM/SY_GZZX_SBBH_STATUS.js"
      ));
            bundles.Add(new ScriptBundle("~/bundles/MES/SYSTEM/SY_GZZX_SBBH_STATUS_SELECT").Include(
      "~/Scripts/MES/SYSTEM/SY_GZZX_SBBH_STATUS_SELECT.js"
      ));
            bundles.Add(new ScriptBundle("~/bundles/zwk").Include(
       "~/Scripts/EM/zwk.js"
       ));
            bundles.Add(new ScriptBundle("~/bundles/MES/SCH/SCH_SHOWCHOICE").Include(
            "~/Scripts/MES/SCH/SCH_SHOWCHOICE.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/MES/SCH/SCH_SHOWMACHINE").Include(
            "~/Scripts/MES/SCH/SCH_SHOWMACHINE.js"
            ));






            //WMS
            bundles.Add(new ScriptBundle("~/bundles/WMS/System/CK_Setting").Include(
            "~/Scripts/WMS/System/CK_Setting.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/WMS/BC_TM/REPLACE_TBM").Include(
            "~/Scripts/WMS/BC_TM/REPLACE_TBM.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/MES/SCH/BZYZDPrint").Include(
            "~/Scripts/WMS/BC_TM/BZYZDPrint.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/WMS/BC_TM/YHXQXF").Include(
            "~/Scripts/WMS/BC_TM/YHXQXF.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/WMS/BC_TM/WL_CHANGE").Include(
            "~/Scripts/WMS/BC_TM/WL_CHANGE.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/WMS/BC_TM/CPHWBS").Include(
            "~/Scripts/WMS/BC_TM/CPHWBS.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/WMS/BC_TM/XSCK_GZSQ").Include(
            "~/Scripts/WMS/BC_TM/XSCK_GZSQ.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/WMS/BC_TM/XSCK_READ").Include(
            "~/Scripts/WMS/BC_TM/XSCK_READ.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/WMS/BC_TM/WLDZB").Include(
            "~/Scripts/WMS/BC_TM/WLDZB.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/WMS/BC_TM/JHZCCX").Include(
            "~/Scripts/WMS/BC_TM/JHZCCX.js"
            ));

            






            //FW
            bundles.Add(new ScriptBundle("~/bundles/WMS/FW/TMPrint_GL").Include(
            "~/Scripts/WMS/FW/TMPrint_GL.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/WMS/FW/TMPrint_CX").Include(
            "~/Scripts/WMS/FW/TMPrint_CX.js"
            ));
            



        }
    }
}