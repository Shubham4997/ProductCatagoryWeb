using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductCatagoryWeb.Models
{
    public class ProductContext:DbContext
    {
        public ProductContext():base("name=DbContext")
        {

        }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> category { get; set; }
    }
}