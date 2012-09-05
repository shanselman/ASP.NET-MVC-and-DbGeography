using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MvcApplication2.WebForms
{
    public partial class Create : System.Web.UI.Page
    {
        AttractionContext db = new AttractionContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void attractionsForm_InsertItem()
        {
            var item = new MvcApplication2.Models.TouristAttraction();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here
                db.TouristAttractions.Add(item);
                db.SaveChanges();
            }
        }

        protected void attractionsForm_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            
            {
                Response.RedirectToRoute("TouristAttraction");
            }
        }

        protected void attractionsForm_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName=="Cancel")
            {
                Response.RedirectToRoute("TouristAttraction");
            }
        }
    }
}