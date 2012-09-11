using System;
using System.Collections.Generic;
using System.Data.Spatial;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WF = System.Web.ModelBinding;

namespace MvcApplication2
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            //Add my MVC Provider
            ModelBinderProviders.BinderProviders.Add(new EFModelBinderProviderMvc());
            
            //I could register a spceific type, without a provider...
            //WF.ModelBinderProviders.Providers.RegisterBinderForType(typeof(DbGeography), new DbGeographyModelBinder());

            //Or just put my provider first as it's pretty specific
            WF.ModelBinderProviders.Providers.Insert(0,new EFModelBinderProviderWebForms());

        }
    }
}