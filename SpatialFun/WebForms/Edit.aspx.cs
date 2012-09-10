using Microsoft.AspNet.FriendlyUrls;
using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MvcApplication2.WebForms
{
    public partial class Edit : System.Web.UI.Page
    {
        AttractionContext db = new AttractionContext();
        
        protected void attractionsForm_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName == "Cancel")
            {
                Response.Redirect("~/WebForms");
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void attractionsForm_UpdateItem(
            [FriendlyUrlSegments]int? id)
        {
            MvcApplication2.Models.TouristAttraction item = db.TouristAttractions.Find(id); 
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        protected void attractionsForm_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            Response.Redirect("~/WebForms");
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public MvcApplication2.Models.TouristAttraction attractionsForm_GetItem(
            [FriendlyUrlSegments]int? id)
        {
            TouristAttraction touristattraction = db.TouristAttractions.Find(id);
            return touristattraction;
        }
    }
}