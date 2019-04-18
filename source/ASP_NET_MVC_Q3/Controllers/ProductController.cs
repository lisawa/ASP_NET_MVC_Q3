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
            source = resetModel();
            return View(source);
        }

        public ActionResult Delete(int id)
        {
            source = resetModel();
            Product.Data = Product.Data.Where(x => x.Id != id).ToList();
            source.Products = Product.Data;
            return RedirectToAction("List");
        }
        public ActionResult Insert(string name, int Location = -1)
        {
            source = resetModel();
            if (!String.IsNullOrEmpty(name) && Location >= 0)
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

            return RedirectToAction("List");
        }
        public ActionResult UpdateSelect(int id)
        {
            source = resetModel();
            source.UpdateIndex = id;
            source.locate = setLocateList();
            source.locate.Where(x => x.Value == source.Products.Where(y => y.Id == id).FirstOrDefault().Locale).FirstOrDefault().Selected = true;
            return View("List", source);
        }
        
        public ActionResult AddSelect()
        {
            source = resetModel();
            source.Add = true;
            source.locate = setLocateList();
            return View("List", source);
        }
        
        [HttpPost]
        public ActionResult Update(ProductViewModel vm, int id, string updateName)
        {
            source = resetModel();
            source.Products.Where(x => x.Id == id).FirstOrDefault().Name = updateName;
            source.Products.Where(x => x.Id == id).FirstOrDefault().Locale = vm.nowLocate;
            source.Products.Where(x => x.Id == id).FirstOrDefault().UpdateDate = DateTime.Now;

            return RedirectToAction("List");
        }

        public ProductViewModel resetModel()
        {
            source = new ProductViewModel();
            source.Products = Product.Data;
            source.UpdateIndex = -1;
            source.Add = false;
            return source;
        }

        public List<SelectListItem> setLocateList()
        {
            return Enum.GetValues(typeof(locate)).Cast<locate>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = v.ToString()
            }).ToList();
        }
    }
}