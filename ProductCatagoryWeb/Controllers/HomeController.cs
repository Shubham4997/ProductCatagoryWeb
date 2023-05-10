using ProductCatagoryWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductCatagoryWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            Category c = new Category()
            {
                CategoryId = 1,
                CategoryName = "Electronics"
            };
            ProductContext db = new ProductContext();
            db.category.Add(c);
            db.SaveChanges();

            Product p = new Product()
            {
                ProductId = 1,
                ProductName = "TV",
                CategoryId=1
            };
           // ProductContext db=new ProductContext();
            db.products.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}