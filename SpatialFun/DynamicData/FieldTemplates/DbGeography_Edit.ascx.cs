using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Web.DynamicData;
using System.Globalization;

namespace MvcApplication2.DynamicData.FieldTemplates
{
    public partial class DbGeography_EditField : System.Web.DynamicData.FieldTemplateUserControl
    {
        public System.Data.Spatial.DbGeography geo;


        protected override void ExtractValues(IOrderedDictionary dictionary)
        {            
            //object val = location.Text;            
            //geo = ((System.Data.Spatial.DbGeography)val);
            //dictionary[Column.Name] = System.Data.Spatial.DbGeography.FromText(location.Text);

            //string[] latLongStr = location.Text.Split(',');
            //string point = string.Format("POINT ({0} {1})", latLongStr[1], latLongStr[0]);
            ////4326 format puts LONGITUDE first then LATITUDE
            //System.Data.Spatial.DbGeography result = System.Data.Spatial.DbGeography.FromText(point, 4326);
            //dictionary[Column.Name] = result;
            dictionary[Column.Name] = location.Text;

        }
    
        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);
            var geo = FieldValue as System.Data.Spatial.DbGeography;
            if (geo != null)
            {
                location.Text = geo.Latitude.Value.ToString("G", CultureInfo.InvariantCulture) + "," + geo.Longitude.Value.ToString("G", CultureInfo.InvariantCulture);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        public override Control DataControl
        {
            get
            {
                return location;
            }
        }
    }
}
