using System.Web;
using System.Web.Optimization;

namespace CAPASFIDAS_EFS
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            ///To minify and bundle files the EnableOptimizations value must be true OR the debug attribute in the compilation Element in the Web.config file must be set false.
            ///Additionally, the .min version of files will not be used, the full debug versions will be selected.
            ///EnableOptimizations overides the debug attribute in the compilation Element in the Web.config file.
            ///Unless debuging scripts this setting should be TRUE.
            ///NOTE: That said set this to FALSE for now. 
            ///There is an ongoing problem with this project where core libraries were manually modified by developers.
            ///When we enableOptimizations the .min file is being used and the core changes are lost.
            ///For example jquery.dataTables.css is a custom file and does not match jquery.dataTables.min.css
            BundleTable.EnableOptimizations = false;//NOTE keep as false.

            //Script bundles should be rendered in this order for correct performance.
            bundles.Add(new ScriptBundle("~/Scripts/bundle-jquery").Include(
                "~/Scripts/jquery-3.7.1.js",
                "~/Scripts/jquery-3.7.1.min.js",
                //"~/Scripts/jquery-migrate-1.4.1.js",//Upgrade tool provides debug warnings on what code to change.
                //"~/Scripts/jquery-migrate-3.1.0.js",//Upgrade tool provides debug warnings on what code to change.
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/DataTables-1.10.20/bundle-jquery-dataTables").Include(
                "~/Scripts/DataTables-1.10.20/js/jquery.datatables.js",
                "~/Scripts/DataTables-1.10.20/js/jquery.datatables.min.js",
                "~/Scripts/DataTables-1.10.20/extensions/Responsive/js/dataTables.responsive.js",
                "~/Scripts/DataTables-1.10.20/extensions/Responsive/js/dataTables.responsive.min.js",
                "~/Scripts/DataTables-1.10.20/plugins/moment-2.29.1.min.js", //Provides extended javascript date functions.
                "~/Scripts/DataTables-1.10.20/plugins/datetime-moment.js", //Adds date sorting functionality to datatables.
                "~/Scripts/dataTables.boe-accessibility-helper.js"));//Provides extended functionality

            bundles.Add(new ScriptBundle("~/Scripts/jquery-timepicker").Include(
                "~/Scripts/jquery.timepicker.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/bundle-jquery-ui").Include(
                "~/Scripts/jquery-ui-1.13.2.js",
                "~/Scripts/jquery-ui-datePicker-accessibility-helper.js",
                "~/Scripts/jquery-ui-global-accessibility-helper.js"));

            bundles.Add(new ScriptBundle("~/Scripts/bundle-other").Include(
                "~/Scripts/ApplicationCommonCode_EFS.js",//This is specific to EFS.
                "~/Scripts/DatePicker.js",
                "~/Scripts/AlertMessageBox.js",
                "~/Scripts/EFS-Validations.js",
                "~/Scripts/respond.js",
                "~/Scripts/spin.js",
                "~/Scripts/boe.accessibility-helper.common.js",
                "~/Scripts/boe.app-utilities.common.js"));

            bundles.Add(new ScriptBundle("~/Scripts/bundle-multiple-select").Include(
                "~/Scripts/multiple-select-1.5.2.js",
                "~/Scripts/multiple-select-1.5.2.min.js"));

            bundles.Add(new Bundle("~/Scripts/bundle-bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/bootstrap-3.boe-extensions.js"));//Provides extended functionality not found in Bootstrap 3.

            // Use the development version of Modernizr to develop with and learn from. 
            // Then, when you'ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/Scripts/bundle-modernizr").Include(
                "~/Scripts/modernizr-2.8.3.js"));

            //Style bundles
            bundles.Add(new StyleBundle("~/Content/bundle-base").Include(
                "~/Content/Site.css",
                "~/Content/site-boe-common.css",
                "~/Content/site-temp-overrides-and-workaround.css"));

            bundles.Add(new StyleBundle("~/Content/bundle-jquery").Include(
                "~/Content/jquery.validate.unobstrusive-boe-overides.css"));

            bundles.Add(new StyleBundle("~/Content/jquery-timepicker").Include(
                "~/Content/jquery.timepicker.min.css"));

            bundles.Add(new StyleBundle("~/Content/bundle-jquery-ui").Include(
                "~/Content/jquery-ui-1.13.2.css",
                "~/Content/jquery-ui-1.12.1-site-overides.css",
                "~/Content/jquery-ui-1.12.1-boe-overides.css"));

            bundles.Add(new StyleBundle("~/Content/multiple-select/bundle-multiple-select").Include(
                "~/Content/multiple-select/multiple-select-1.5.2.css",
                "~/Content/multiple-select/multiple-select-1.5.2.min.css",
                "~/Content/multiple-select/multiple-select-1.5.2-boe-overides.css"));

            bundles.Add(new StyleBundle("~/Content/bundle-bootstrap").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-boe-overides.css",
                "~/Content/bootstrap-3.boe-extensions.css"));//Provides extended functionality not found in Bootstrap 3.

            bundles.Add(new StyleBundle("~/Content/DataTables-1.10.20/css/bundle-jquery-dataTables").Include(
                "~/Content/DataTables-1.10.20/css/jquery.dataTables.css",
                "~/Content/DataTables-1.10.20/css/dataTables.bootstrap.css",
                "~/Content/DataTables-1.10.20/css/jquery.dataTables-boe-overides.css",
                "~/Content/DataTables-1.10.20/css/jquery.dataTables-site-overides.css"));

            bundles.Add(new StyleBundle("~/Content/DataTables-1.10.20/extensions/Responsive/css/bundle-jquery-dataTables-responsive").Include(
               "~/Content/DataTables-1.10.20/extensions/Responsive/css/responsive.dataTables.css",
               "~/Content/DataTables-1.10.20/extensions/Responsive/css/dataTables.responsive.nightly.css"));
        }
    }
}
