using Microsoft.AspNet.FriendlyUrls;
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
    public partial class Details : System.Web.UI.Page
    {
        private AttractionContext db = new AttractionContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public MvcApplication2.Models.TouristAttraction attractionDetails_GetItem(
            [FriendlyUrlSegments]int? id)
        {
            TouristAttraction touristattraction = db.TouristAttractions.Find(id);
            return touristattraction;
        }
    }
}