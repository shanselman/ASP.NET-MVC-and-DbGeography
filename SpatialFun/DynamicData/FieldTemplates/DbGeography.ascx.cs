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

namespace MvcApplication2.DynamicData.FieldTemplates
{
    public partial class DbGeography : System.Web.DynamicData.FieldTemplateUserControl
    {
        public System.Data.Spatial.DbGeography geo;

        protected override void OnDataBinding(EventArgs e)
        {
                base.OnDataBinding(e);                
                geo = ((System.Data.Spatial.DbGeography)FieldValue);
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
