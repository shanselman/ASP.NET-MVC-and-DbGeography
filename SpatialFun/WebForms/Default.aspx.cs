using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MvcApplication2.WebForms
{
    public partial class Default : System.Web.UI.Page
    {
        private AttractionContext db = new AttractionContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<MvcApplication2.Models.TouristAttraction> displayAttractions_GetData()
        {
            return db.TouristAttractions.AsQueryable();
        }
    }
}