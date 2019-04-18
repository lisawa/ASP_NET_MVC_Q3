using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_NET_MVC_Q3.Data;

namespace ASP_NET_MVC_Q3.Models
{
    public class ProductViewModel
    {
        public List<Product> Products { get; set; }
        
        public int UpdateIndex { get; set; }

        public bool Add { get; set; }

        public List<SelectListItem> locate { get; set; }

        public locate Location { get; set; }
    }
}