using ProductCatagoryWeb.Models;
using ProductCatagoryWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductCatagoryWeb.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            try
            {
                ProductContext db = new ProductContext();
                List<ProductList> list = new List<ProductList>();
                var td = (from s in db.products
                          join r in db.category on s.CategoryId equals r.CategoryId
                          select new
                          {
                              s.ProductId,
                              s.ProductName,
                              r.CategoryId,
                              r.CategoryName,
                          }).ToList();

                foreach (var item in td)
                {
                    list.Add(new ProductList()
                    {
                        ProductId = item.ProductId,
                        ProductName = item.ProductName,
                        CategoryId = item.CategoryId,
                        CategoryName = item.CategoryName,
                    });
                }
                return View(list);
            }
            catch (Exception)
            {
                return View(new List<ProductList>());
            }
            
        }

        public ActionResult ManageCategory()
        {
            try
            {
                ProductContext db = new ProductContext();
                List<CategoryVM> list = db.category.Select(x => new CategoryVM()
                {
                    CategoryName = x.CategoryName,
                    CategoryId = x.CategoryId
                }).ToList();
                return View(list);
            }
            catch (Exception)
            {
                return View(new List<CategoryVM>());
            }
           
        }

        public ActionResult ManageProduct()
        {
            try
            {
                ProductContext db = new ProductContext();
                List<ProductVM> list = db.products.Select(x => new ProductVM()
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    CategoryId = x.CategoryId
                }).ToList();
                return View(list);
            }
            catch (Exception)
            {
                return View(new List<ProductVM>());
            }
           
        }

        [HttpPost]
        public ActionResult AddCategory(string CategoryName)
        {
            ProductContext db = new ProductContext();
            Category c = new Category()
            {
                //CategoryId = 1,
                CategoryName = CategoryName
            };

            db.category.Add(c);
            db.SaveChanges();
            return Json(true);
        }

        [HttpGet]
        public ActionResult getbyID(int Id)
        {
            ProductContext db = new ProductContext();
            var r=db.category.Where(x=>x.CategoryId==Id).FirstOrDefault();
            return Json(r,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateCategory(string CategoryName,int CategoryId)
        {
            ProductContext db = new ProductContext();
            var r = db.category.Where(x => x.CategoryId == CategoryId).FirstOrDefault();
            r.CategoryName= CategoryName;
            db.SaveChanges();
            return Json(true);
        }

        [HttpPost]
        public ActionResult DeleteCategory(int Id)
        {
            ProductContext db = new ProductContext();
            var r = db.category.Where(x => x.CategoryId == Id).FirstOrDefault();
            db.category.Remove(r);
            db.SaveChanges();
            return Json(true);
        }

        [HttpPost]
        public ActionResult AddProduct(string ProductName,int CId)
        {
            ProductContext db = new ProductContext();
            Product c = new Product()
            {
                ProductName = ProductName,
                CategoryId=CId
            };
            db.products.Add(c);
            db.SaveChanges();
            return Json(true);
        }


        [HttpGet]
        public ActionResult getProductbyID(int Id)
        {
            ProductContext db = new ProductContext();
            var r = db.products.Where(x => x.ProductId == Id).FirstOrDefault();
            return Json(r, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UpdateProduct(string ProductName,int ProductId, int CId)
        {
            ProductContext db = new ProductContext();
            var r = db.products.Where(x => x.ProductId == ProductId).FirstOrDefault();
            r.ProductName = ProductName;
            r.CategoryId= CId;
            db.SaveChanges();
            return Json(true);
        }
        [HttpPost]
        public ActionResult DeleteProduct(int Id)
        {
            ProductContext db = new ProductContext();
            var r = db.products.Where(x => x.ProductId == Id).FirstOrDefault();
            db.products.Remove(r);
            db.SaveChanges();
            return Json(true);
        }
    }
}
