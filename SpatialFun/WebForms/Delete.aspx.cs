using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MvcApplication2.WebForms
{
    public partial class Delete : System.Web.UI.Page
    {
        AttractionContext db = new AttractionContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public MvcApplication2.Models.TouristAttraction attractionsForm_GetItem([RouteData]int? id)
        {
            TouristAttraction touristattraction = db.TouristAttractions.Find(id);
            return touristattraction;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void attractionsForm_DeleteItem([RouteData]int? id)
        {
            TouristAttraction touristattraction = db.TouristAttractions.Find(id);
            db.TouristAttractions.Remove(touristattraction);
            db.SaveChanges();
        }

        protected void attractionsForm_ItemDeleted(object sender, FormViewDeletedEventArgs e)
        {
              Response.RedirectToRoute("TouristAttraction");
            
        }

        protected void attractionsForm_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName == "Cancel")
            {
                Response.RedirectToRoute("TouristAttraction");
            }
        }
    }
}