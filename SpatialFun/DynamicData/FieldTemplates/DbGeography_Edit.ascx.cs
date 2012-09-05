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
    public partial class DbGeography_EditField : System.Web.DynamicData.FieldTemplateUserControl
    {
        public System.Data.Spatial.DbGeography geo;



        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);
            object val = FieldValue;
            geo = ((System.Data.Spatial.DbGeography)val);
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
