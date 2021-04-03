﻿using System.Web;
using System.Web.Optimization;

namespace PrVeterinaria
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            System.Web.Optimization.BundleTable.EnableOptimizations = false;

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                         "~/Scripts/popper.js",
                          "~/Scripts/popper.min.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/app.config.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/app.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/Content/platillaSmartAdmin").Include(
                        "~/Content/SmartAdmin/smartadmin-production-plugins.min.css",
                        "~/Content/SmartAdmin/smartadmin-production.min.css",
                        "~/Content/SmartAdmin/smartadmin-skins.min.css",
                        "~/Content/SmartAdmin/smartadmin-rtl.min.css"));
        }
    }
}
