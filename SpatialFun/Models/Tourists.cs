using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Spatial;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Models
{
    public class TouristAttraction
    {
        public int TouristAttractionId { get; set; }
        
        public string Name { get; set; }

        public DbGeography Location { get; set; }

        public List<Review> Reviews { get; set; }
    }

    public class Review
    {
        public int ReviewId { get; set; }
        public string Author { get; set; }
        public string Comments { get; set; }

        public int TouristAttractionId { get; set; }
        public TouristAttraction TouristAttraction { get; set; }
    }
}