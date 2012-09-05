using System;
using System.Collections.Generic;
using System.Data.Spatial;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;



namespace MvcApplication2
{
    public class DbGeographyModelBinderWebForms : DefaultModelBinder
    {
        public bool BindModel(ModelBindingExecutionContext modelBindingExecutionContext, ModelBindingContext bindingContext)
        {
            //ToDo: update modelbinder to save the value/edit the value of the field
            ModelBindingContext modelBindingContext = bindingContext;
            //IModelBinder binder = this.Providers.GetBinder(modelBindingExecutionContext, bindingContext);
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            string[] latLongStr = valueProviderResult.AttemptedValue.Split(',');
            string point = string.Format("POINT ({0} {1})", latLongStr[1], latLongStr[0]);
            //4326 format puts LONGITUDE first then LATITUDE
            DbGeography result = valueProviderResult == null ? null :
                DbGeography.FromText(point, 4326);
            //if (binder != null)
            //{
            //    bool flag = binder.BindModel(modelBindingExecutionContext, modelBindingContext);
            //    if (flag)
            //    {
            //        modelBindingContext.ValidationNode.Validate(modelBindingExecutionContext, null);
            //        return true;
            //    }
            //}
            //return false;
            return true;
        }
    }



    public class EFModelBinderProviderWebForms : ModelBinderProvider
    {        
        public override IModelBinder GetBinder(ModelBindingExecutionContext modelBindingExecutionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(DbGeography))
            {
                return new DbGeographyModelBinderWebForms();
            }
            return null;
        }
    }
}