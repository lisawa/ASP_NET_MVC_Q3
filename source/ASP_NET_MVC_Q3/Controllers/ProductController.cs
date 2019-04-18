using ASP_NET_MVC_Q3.Data;
using ASP_NET_MVC_Q3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ASP_NET_MVC_Q3.Controllers
{
    public class ProductController : Controller
    {
        ProductViewModel source;
        public ActionResult List()
        {
            source = new ProductViewModel();
            source.Products = Product.Data;
            source.UpdateIndex = -1;
            return View(source);
        }

        public ActionResult Delete(int id, string resources)
        {
            source = DeserializeProductVM(resources);
            source.Products = source.Products.Where(x => x.Id != id).ToList();
            source.UpdateIndex = -1;
            source.Add = false;
            return View("List", source);
        }
        public ActionResult Insert(string name, string resources, int Location = -1)
        {
            source = new ProductViewModel();
            source = DeserializeProductVM(resources);
            if (!String.IsNullOrEmpty(name) && Location > 0)
            {
                source.Products.Add(
                    new Product
                    {
                        Id = source.Products.Max(x => x.Id) + 1,
                        Name = name,
                        Locale = ((locate)Location).ToString(),
                        CreateDate = DateTime.Now,
                    });
            }
            source.UpdateIndex = -1;
            source.Add = false;
            return View("List", source);
        }
        public ActionResult UpdateSelect(int id, string resources)
        {
            source = new ProductViewModel();
            source = DeserializeProductVM(resources);
            source.UpdateIndex = id - 1;
            source.Add = false;
            return View("List", source);
        }
        
        public ActionResult AddSelect(string resources)
        {
            source = new ProductViewModel();
            source = DeserializeProductVM(resources);
            source.UpdateIndex = -1;
            source.Add = true;
            return View("List", source);
        }
        public ActionResult Update(int id, string resources, string updateName, int Location)
        {
            source = new ProductViewModel();
            source = DeserializeProductVM(resources);
            source.Products.Where(x => x.Id == id).FirstOrDefault().Name = updateName;
            source.Products.Where(x => x.Id == id).FirstOrDefault().Locale = ((locate)Location).ToString();
            source.Products.Where(x => x.Id == id).FirstOrDefault().UpdateDate = DateTime.Now;
            source.UpdateIndex = -1;
            return View("List", source);
        }
        public ActionResult Cancel(int id, string resources)
        {
            source = new ProductViewModel();
            source = DeserializeProductVM(resources);
            source.UpdateIndex = -1;
            source.Add = false;
            return View("List", source);
        }

        public ProductViewModel DeserializeProductVM(string resouce)
        {
            return new JavaScriptSerializer().Deserialize<ProductViewModel>(resouce);
        }
    }
}