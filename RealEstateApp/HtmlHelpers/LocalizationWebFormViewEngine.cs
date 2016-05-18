using System.Web.Mvc;

namespace RealEstateApp.HtmlHelpers
{
    public class LocalizationWebFormViewEngine:WebFormViewEngine
    {
        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            return new LocalizationWebFormView(controllerContext,viewPath, masterPath);
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            return new LocalizationWebFormView(controllerContext,partialPath, null);
        }
    }
}