using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public static class ControllerExtensions
    {
        public static ViewResult RazorView(this Controller controller)
        {
            return RazorView(controller, null, null);
        }

        public static ViewResult RazorView(this Controller controller, object model)
        {
            return RazorView(controller, null, model);
        }

        public static ViewResult RazorView(this Controller controller, string viewName)
        {
            return RazorView(controller, viewName, null);
        }

        public static ViewResult RazorView(this Controller controller, string viewName, object model)
        {
            if (model != null)
                controller.ViewData.Model = model;

            controller.ViewBag._ViewName = GetViewName(controller, viewName);

            return new ViewResult
            {
                ViewName = "RazorView",
                ViewData = controller.ViewData,
                TempData = controller.TempData
            };
        }

        static string GetViewName(Controller controller, string viewName)
        {
            return !string.IsNullOrEmpty(viewName)
                ? viewName
                : controller.RouteData.GetRequiredString("action");
        }
    }
}
