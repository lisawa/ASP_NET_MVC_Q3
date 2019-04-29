using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_NET_MVC_Q3.Data;
using ASP_NET_MVC_Q3.Interface;
using ASP_NET_MVC_Q3.Models;

namespace ASP_NET_MVC_Q3.Repository
{
    public class ProductRepository : IProductRepository
    {
        /// <summary>
        /// Create New Product By Name and Locate
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="locate"></param>
        public void Create(string Name, string locate)
        {
            Product.Data.Add(new Product
            {
                Id = Product.Data.Max(x => x.Id) + 1,
                Name = Name,
                Locale = locate,
                CreateDate = DateTime.Now
            });
        }

        /// <summary>
        /// Delete Product by ID
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            Product.Data = Product.Data.Where(x => x.Id != id).ToList();
        }

        /// <summary>
        /// Get All Product
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAll()
        {
            return Product.Data;
        }

        /// <summary>
        /// Update Product's Name and Locate by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="locate"></param>
        public void Update(int id, string name, string locate)
        {
            var m = Product.Data.Where(x => x.Id == id).FirstOrDefault();


            m.Name = name;
            m.Locale = locate;
            m.UpdateDate = DateTime.Now;
        }
    }
}