using System.Web.Optimization;

namespace LojaRazor
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //juntando os estilos em um único arquivo
            StyleBundle estilos = new StyleBundle("~/bundles/estilos");
            estilos.Include("~/Content/bootstrap/css/bootstrap.css");
            estilos.Include("~/Content/Style.css");

            ScriptBundle scripts = new ScriptBundle("~/bundles/scripts");
            scripts.Include("~/Scripts/jquery-1.7.1.js");
            scripts.Include("~/Scripts/jquery.validate.js");
            scripts.Include("~/Scripts/jquery.validate.unobtrusive.js");

            bundles.Add(estilos);
            bundles.Add(scripts);
        }
    }
}