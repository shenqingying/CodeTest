using System.Web;
using System.Web.Optimization;

namespace Sonluk.Mobile
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
            bundles.Add(new StyleBundle("~/Content/css1").Include("~/Content/site1.css"));

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

            bundles.Add(new StyleBundle("~/Content/layui/css/login").Include("~/Scripts/layui/css/login.css"));
            bundles.Add(new StyleBundle("~/Content/layui/css/layui").Include("~/Scripts/layui/css/layui.css"));
            bundles.Add(new StyleBundle("~/Content/layui/css/layuimain").Include("~/Scripts/layui/css/layuimain.css"));

            bundles.Add(new StyleBundle("~/bundles/layui/layui").Include("~/Scripts/layui2.2.5/layui.js"));
            bundles.Add(new StyleBundle("~/bundles/PS/main").Include("~/Scripts/PS/main.js"));
            bundles.Add(new StyleBundle("~/bundles/PS/cgds").Include("~/Scripts/PS/cgds.js"));
            bundles.Add(new StyleBundle("~/bundles/PS/ComponentPutaway").Include("~/Scripts/PS/ComponentPutaway.js"));
            bundles.Add(new StyleBundle("~/bundles/PS/ComponentSoldout").Include("~/Scripts/PS/ComponentSoldout.js"));
            bundles.Add(new StyleBundle("~/bundles/PS/ComponentMoving").Include("~/Scripts/PS/ComponentMoving.js"));


            bundles.Add(new StyleBundle("~/bundles/CRM/KeHu/Insert").Include(
                "~/Scripts/CRM/KeHu/Insert.js",
                "~/Scripts/CRM/KeHu/SelectUpKeHu.js"));
            bundles.Add(new StyleBundle("~/bundles/CRM/KeHu/Update").Include(
                "~/Scripts/CRM/KeHu/DropDownList.js",
                "~/Scripts/CRM/KeHu/SelectUpKeHu.js",
                "~/Scripts/CRM/KeHu/Update.js"
                ));
            bundles.Add(new StyleBundle("~/bundles/CRM/KeHu/Select").Include(
                "~/Scripts/CRM/KeHu/Select.js"
                ));
            bundles.Add(new StyleBundle("~/bundles/CRM/KeHu/SAP").Include(
                "~/Scripts/CRM/KeHu/SAP.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/CRM/KeHu/Qudao").Include(
                "~/Scripts/CRM/KeHu/DropDownList.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/CRM/KeHu/Pinzhong").Include(
                "~/Scripts/CRM/KeHu/DropDownList.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/CRM/KeHu/Jingpin").Include(
                "~/Scripts/CRM/KeHu/DropDownList.js"
                ));
            bundles.Add(new StyleBundle("~/bundles/CRM/KeHu/Area").Include(
                "~/Scripts/CRM/KeHu/DropDownList.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/MES/PD_SCRW/PD_SCRW_TL_ZJ").Include(
                "~/Scripts/MES/PD_SCRW/PD_SCRW_TL_ZJ.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/MES/SCRW_TL/TL_BB").Include(
                "~/Scripts/MES/SCRW_TL/TL_BB.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/MES/TM_Manage/TPM_CHANGE").Include(
                "~/Scripts/MES/TM_Manage/TPM_CHANGE.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/MES/TPM/TPZHNO_ADD").Include(
                "~/Scripts/MES/TPM/TPZHNO_ADD.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/MES/TPM/TP_RKBS_BD").Include(
                "~/Scripts/MES/TPM/TP_RKBS_BD.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/MES/TPM/TP_RKBS_JC").Include(
                "~/Scripts/MES/TPM/TP_RKBS_JC.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/MES/TPM/TP_TPYD").Include(
                "~/Scripts/MES/TPM/TP_TPYD.js"
                ));

            
            bundles.Add(new ScriptBundle("~/bundles/MES/ZS/ZS_FGDJ_MANAGE").Include(
               "~/Scripts/MES/ZS/ZS_FGDJ_MANAGE.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/MES/ZS/ZS_THDJ_MANAGE").Include(
               "~/Scripts/MES/ZS/ZS_THDJ_MANAGE.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/MES/ZS/ZS_WLBSK_CK_MANAGE").Include(
                "~/Scripts/MES/ZS/ZS_WLBSK_CK_MANAGE.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/MES/ZS/ZS_WLBSK_MOVE_MANAGE").Include(
                "~/Scripts/MES/ZS/ZS_WLBSK_MOVE_MANAGE.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/MES/ZS/ZS_WLBSKGL_MANAGE").Include(
                "~/Scripts/MES/ZS/ZS_WLBSKGL_MANAGE.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/MES/ZS/ZS_WLBSKGL_BACK_MANAGE").Include(
               "~/Scripts/MES/ZS/ZS_WLBSKGL_BACK_MANAGE.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/MES/ZS/ZS_MFQQJ_SBLIST").Include(
               "~/Scripts/MES/ZS/ZS_MFQQJ_SBLIST.js"
               ));
        }
    }
}