using System.Web.Mvc;

namespace Twitter.Web
{
    public static class ViewEnginesConfig
    {
        public static void RegisterViewEngines(ViewEngineCollection viewEngines)
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}