using System.Web;
using System.Web.Optimization;

namespace Sonluk
{
    public class BundleConfig
    {
        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
           
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

            //JavaScript
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jQuery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/sonluk-ui/sign-in").Include("~/Scripts/sonluk-ui/sign-in.js"));
            bundles.Add(new ScriptBundle("~/bundles/sonluk-ui").Include("~/Scripts/sonluk-ui/common.js", "~/Scripts/sonluk-ui/layout.js","~/Scripts/sonluk-ui/nav-bar.js", "~/Scripts/sonluk-ui/dialog-message.js"));
            bundles.Add(new ScriptBundle("~/bundles/sonluk-ui/dialog-message").Include("~/Scripts/sonluk-ui/dialog-message.js"));
            bundles.Add(new ScriptBundle("~/bundles/sonluk-ui/table").Include("~/Scripts/sonluk-ui/table.js", "~/Scripts/sonluk-ui/table-resize.js"));
            bundles.Add(new ScriptBundle("~/bundles/sonluk-ui/table-resize").Include("~/Scripts/sonluk-ui/table-resize.js"));
            bundles.Add(new ScriptBundle("~/bundles/sonluk-ui/print").Include("~/Scripts/sonluk-ui/print.js"));
            bundles.Add(new ScriptBundle("~/bundles/sonluk-ui/pdf-display").Include("~/Scripts/sonluk-ui/pdf-display.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/datetimepicker").Include("~/Scripts/datetimepicker/bootstrap-datetimepicker.js", "~/Scripts/datetimepicker/bootstrap-datetimepicker.zh-CN.js"));

            bundles.Add(new ScriptBundle("~/bundles/vendor/purchase-order-index").Include("~/Scripts/vendor/purchase-order-index.js"));

            bundles.Add(new ScriptBundle("~/bundles/meadco-scriptx").Include("~/Scripts/scriptx/meadco-scriptx-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/access/update-password").Include("~/Scripts/access/update-password.js"));

            bundles.Add(new ScriptBundle("~/bundles/spin").Include("~/Scripts/spin/spin.js", "~/Scripts/spin/jquery.spin.js"));

            bundles.Add(new ScriptBundle("~/bundles/sd/sales-order-index").Include("~/Scripts/sd/sales-order-index.js"));

            bundles.Add(new ScriptBundle("~/bundles/le/consignment-note-index").Include("~/Scripts/le/consignment-note-index.js"));
            bundles.Add(new ScriptBundle("~/bundles/le/consignment-note-edit").Include("~/Scripts/le/consignment-note-edit.js"));
            bundles.Add(new ScriptBundle("~/bundles/le/consignment-note-templet-edit").Include("~/Scripts/le/consignment-note-templet-edit.js"));
            bundles.Add(new ScriptBundle("~/bundles/le/outbound-delivery-index").Include("~/Scripts/le/outbound-delivery-index.js"));
            bundles.Add(new ScriptBundle("~/bundles/le/outbound-delivery-update").Include("~/Scripts/le/outbound-delivery-update.js"));
            bundles.Add(new ScriptBundle("~/bundles/le/complaint-index").Include("~/Scripts/le/complaint-index.js"));
            bundles.Add(new ScriptBundle("~/bundles/le/complaint-edit").Include("~/Scripts/le/complaint-edit.js"));
            bundles.Add(new ScriptBundle("~/bundles/le/feedback-index").Include("~/Scripts/le/feedback-index.js"));
            bundles.Add(new ScriptBundle("~/bundles/le/feedback-edit").Include("~/Scripts/le/feedback-edit.js"));
            bundles.Add(new ScriptBundle("~/bundles/le/city-index").Include("~/Scripts/le/city-index.js"));

            bundles.Add(new ScriptBundle("~/bundles/mm/purchase-order-index").Include("~/Scripts/mm/purchase-order-index.js"));
            bundles.Add(new ScriptBundle("~/bundles/mm/purchase-order-update-delivery-date").Include("~/Scripts/mm/purchase-order-update-delivery-date.js"));
            bundles.Add(new ScriptBundle("~/bundles/mm/purchase-order-temp").Include("~/Scripts/mm/purchase-order-temp.js"));
            bundles.Add(new ScriptBundle("~/bundles/mm/schedule-requisition-index").Include("~/Scripts/mm/schedule-requisition-index.js"));
            bundles.Add(new ScriptBundle("~/bundles/mm/schedule-requisition-edit").Include("~/Scripts/mm/schedule-requisition-edit.js"));
            bundles.Add(new ScriptBundle("~/bundles/mm/schedule-requisition-release").Include("~/Scripts/mm/schedule-requisition-release.js"));
           

            bundles.Add(new ScriptBundle("~/bundles/bc/enqueue-index").Include("~/Scripts/bc/enqueue-index.js"));
            bundles.Add(new ScriptBundle("~/bundles/bc/barcode-mgr").Include("~/Scripts/bc/barcode-mgr.js"));
            bundles.Add(new ScriptBundle("~/bundles/bc/picking-task-config").Include("~/Scripts/bc/picking-task-config.js"));
            bundles.Add(new ScriptBundle("~/bundles/bc/picking-task").Include("~/Scripts/bc/picking-task.js"));
            bundles.Add(new ScriptBundle("~/bundles/bc/picking-task-screenmsg").Include("~/Scripts/bc/picking-task-screenmsg.js"));
            bundles.Add(new ScriptBundle("~/bundles/bc/picking").Include("~/Scripts/bc/picking.js"));

            bundles.Add(new ScriptBundle("~/bundles/print/layout-index").Include("~/Scripts/print/layout-index.js"));
            bundles.Add(new ScriptBundle("~/bundles/print/layout-edit").Include("~/Scripts/print/layout-edit.js"));
            bundles.Add(new ScriptBundle("~/bundles/print/layout-print").Include("~/Scripts/print/layout-print.js"));

            bundles.Add(new ScriptBundle("~/bundles/report/incoming-quality-control-packing-material").Include("~/Scripts/report/incoming-quality-control-packing-material.js"));

            bundles.Add(new ScriptBundle("~/bundles/report/config").Include("~/Scripts/report/config.js"));
            bundles.Add(new ScriptBundle("~/bundles/report/purchase-order-rkbs").Include("~/Scripts/report/purchase-order-rkbs.js"));
            bundles.Add(new ScriptBundle("~/bundles/report/purchase-order-rkbszh").Include("~/Scripts/report/purchase-order-rkbszh.js"));

            bundles.Add(new ScriptBundle("~/bundles/vendor/quality-notification-index").Include("~/Scripts/vendor/quality-notification-index.js"));

            bundles.Add(new ScriptBundle("~/bundles/dev/log-index").Include("~/Scripts/dev/log-index.js"));
            bundles.Add(new ScriptBundle("~/bundles/dev/log-oa").Include("~/Scripts/dev/log-oa.js"));
            //Style  dialog-message
            bundles.Add(new StyleBundle("~/Content/sonluk-ui/sign-in").Include("~/Content/sonluk-ui/sign-in.css"));
            bundles.Add(new StyleBundle("~/Content/sonluk-ui/color").Include("~/Content/sonluk-ui/color.css"));
            bundles.Add(new StyleBundle("~/Content/sonluk-ui/standard").Include(
                        "~/Content/sonluk-ui/common.css",
                        "~/Content/sonluk-ui/color.css",
                        "~/Content/sonluk-ui/control.css",
                        "~/Content/sonluk-ui/layout.css",
                        "~/Content/sonluk-ui/nav-bar.css",
                        "~/Content/sonluk-ui/dialog-message.css"));
            bundles.Add(new StyleBundle("~/Content/sonluk-ui/content-tree").Include("~/Content/sonluk-ui/content-tree.css"));
            bundles.Add(new StyleBundle("~/Content/sonluk-ui/control-panel").Include("~/Content/sonluk-ui/control-panel.css"));
            bundles.Add(new StyleBundle("~/Content/sonluk-ui/dialog-message").Include("~/Content/sonluk-ui/dialog-message.css"));
            bundles.Add(new StyleBundle("~/Content/sonluk-ui/table").Include("~/Content/sonluk-ui/table.css"));
            bundles.Add(new StyleBundle("~/Content/sonluk-ui/print").Include("~/Content/sonluk-ui/print.css"));
            bundles.Add(new StyleBundle("~/Content/sonluk-ui/pdf-display").Include("~/Content/sonluk-ui/pdf-display.css"));

            bundles.Add(new StyleBundle("~/Content/sonluk-ui/panel-layout-flow").Include("~/Content/sonluk-ui/panel-layout-flow.css"));
            bundles.Add(new StyleBundle("~/Content/sonluk-ui/panel-search").Include("~/Content/sonluk-ui/panel-search.css"));
            bundles.Add(new StyleBundle("~/Content/sonluk-ui/panel-flow").Include("~/Content/sonluk-ui/panel-flow.css"));
            bundles.Add(new StyleBundle("~/Content/sonluk-ui/panel-pop-up").Include("~/Content/sonluk-ui/panel-pop-up.css"));

            bundles.Add(new StyleBundle("~/Content/sonluk-ui/input-width-po").Include("~/Content/sonluk-ui/input-width-po.css"));
            bundles.Add(new StyleBundle("~/Content/sonluk-ui/input-width-od").Include("~/Content/sonluk-ui/input-width-od.css"));
            bundles.Add(new StyleBundle("~/Content/sonluk-ui/input-width-cn").Include("~/Content/sonluk-ui/input-width-cn.css"));

            bundles.Add(new StyleBundle("~/Content/import-bar").Include("~/Content/import-bar.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include("~/Content/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/datetimepicker").Include("~/Content/bootstrap-datetimepicker.min.css", "~/Content/sonluk-ui/datetime-picker.css"));

            bundles.Add(new StyleBundle("~/Content/sonluk-ui/print").Include("~/Content/sonluk-ui/print.css"));

            bundles.Add(new StyleBundle("~/Content/access/update-password").Include("~/Content/access/update-password.css"));
            bundles.Add(new StyleBundle("~/Content/access/error").Include("~/Content/access/error.css"));

            bundles.Add(new StyleBundle("~/Content/mm/purchase-order-index").Include("~/Content/mm/purchase-order-index.css"));
            bundles.Add(new StyleBundle("~/Content/mm/purchase-order-update-delivery-date").Include("~/Content/mm/purchase-order-update-delivery-date.css"));
            bundles.Add(new StyleBundle("~/Content/mm/schedule-requisition-index").Include("~/Content/mm/schedule-requisition-index.css"));
            bundles.Add(new StyleBundle("~/Content/mm/schedule-requisition-edit").Include("~/Content/mm/schedule-requisition-edit.css"));

            bundles.Add(new StyleBundle("~/Content/sd/sales-order-index").Include("~/Content/sd/sales-order-index.css"));

            bundles.Add(new StyleBundle("~/Content/le/outbound-delivery-index").Include("~/Content/le/outbound-delivery-index.css"));
            bundles.Add(new StyleBundle("~/Content/le/consignment-note-edit").Include("~/Content/le/consignment-note-edit.css"));
            bundles.Add(new StyleBundle("~/Content/le/consignment-note-templet-edit").Include("~/Content/le/consignment-note-templet-edit.css"));
            bundles.Add(new StyleBundle("~/Content/le/complaint-edit").Include("~/Content/le/complaint-edit.css"));
            bundles.Add(new StyleBundle("~/Content/le/city-index").Include("~/Content/le/city-index.css"));

            bundles.Add(new StyleBundle("~/Content/bc/enqueue-index").Include("~/Content/bc/enqueue-index.css"));
            

            bundles.Add(new StyleBundle("~/Content/print/layout-index").Include("~/Content/print/layout-index.css"));
            bundles.Add(new StyleBundle("~/Content/print/layout-edit").Include("~/Content/print/layout-edit.css"));
            bundles.Add(new StyleBundle("~/Content/print/layout-print").Include("~/Content/print/layout-print.css"));

            bundles.Add(new StyleBundle("~/Content/report/test").Include("~/Content/report/test.css"));
            bundles.Add(new StyleBundle("~/Content/report/incoming-quality-control-packing-material").Include("~/Content/report/incoming-quality-control-packing-material.css"));
            bundles.Add(new StyleBundle("~/Content/report/purchase-order").Include("~/Content/report/purchase-order.css"));

            bundles.Add(new StyleBundle("~/Content/vendor/quality-notification-index").Include("~/Content/vendor/quality-notification-index.css"));

        }
    }
}