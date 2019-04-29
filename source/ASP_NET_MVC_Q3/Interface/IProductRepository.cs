using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_NET_MVC_Q3.Data;
using ASP_NET_MVC_Q3.Models;

namespace ASP_NET_MVC_Q3.Interface
{
    public interface IProductRepository
    {
        List<Product> GetAll();

        void Update(int id, string name, string locate);

        void Create(int id, string Name, string locate);

        void Delete(int id);
    }
}