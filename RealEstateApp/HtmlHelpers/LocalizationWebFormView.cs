using System.Web.Mvc;
using System.IO;

namespace RealEstateApp.HtmlHelpers
{
    public class LocalizationWebFormView:WebFormView
    {
        internal const string ViewPathKey = "~/App_GlobalResources/";

        

        public override void Render(ViewContext viewContext, TextWriter writer)
        {
            // there seems to be a bug with RenderPartial tainting the page's view data
            // so we should capture the current view path, and revert back after rendering
            string originalViewPath = (string)viewContext.ViewData[ViewPathKey];

            viewContext.ViewData[ViewPathKey] = ViewPath;
            base.Render(viewContext, writer);

            viewContext.ViewData[ViewPathKey] = originalViewPath;
        }

        public LocalizationWebFormView(ControllerContext controllerContext, string viewPath) : base(controllerContext, viewPath)
        {
        }

        public LocalizationWebFormView(ControllerContext controllerContext, string viewPath, string masterPath) : base(controllerContext, viewPath, masterPath)
        {
        }

        public LocalizationWebFormView(ControllerContext controllerContext, string viewPath, string masterPath, IViewPageActivator viewPageActivator) : base(controllerContext, viewPath, masterPath, viewPageActivator)
        {
        }
    }
}