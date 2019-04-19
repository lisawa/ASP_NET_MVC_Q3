using ASP_NET_MVC_Q3.Data;
using ASP_NET_MVC_Q3.Models;
using ASP_NET_MVC_Q3.Repository;
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
            source = CreateViewModel();
            return View(source);
        }
        
        /// <summary>
        /// Create New Product 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="nowLocate"></param>
        /// <returns></returns>
        public ActionResult Create(string name, string nowLocate)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(nowLocate))
            {
                new ProductRepository().Create(name, nowLocate);
            }

            return RedirectToAction("List");
        }
        
        /// <summary>
        /// Update Product's Name and Locate by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateName"></param>
        /// <param name="nowLocate"></param>
        /// <returns></returns>
        public ActionResult Update(int id, string updateName, string nowLocate)
        {
            new ProductRepository().Update(id, updateName, nowLocate);
            return RedirectToAction("List");
        }

        /// <summary>
        /// Delete Product by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            new ProductRepository().Delete(id);
            return RedirectToAction("List");
        }

        /// <summary>
        /// Select which one will Update
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult UpdateSelect(int id)
        {
            source = CreateViewModel(id);
            string nowLocate = source.Products.Where(y => y.Id == id).FirstOrDefault().Locale;
            source.locate.Where(x => x.Text == nowLocate).FirstOrDefault().Selected = true;
            return View("List", source);
        }
        
        /// <summary>
        /// Start Insert
        /// </summary>
        /// <returns></returns>
        public ActionResult AddSelect()
        {
            source = CreateViewModel(-1, true);
            return View("List", source);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ProductViewModel CreateViewModel(int updateId = -1, bool add = false)
        {
            source = new ProductViewModel()
            {
                Products = new ProductRepository().GetAll(),
                UpdateIndex = updateId,
                Add = add,
                locate = SetLocateList()
            };

            return source;
        }

        public List<SelectListItem> SetLocateList()
        {
            return Enum.GetValues(typeof(locate)).Cast<locate>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = v.ToString(),
            }).ToList();
        }
    }
}