using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductCatagoryWeb.ViewModels
{
    public class ProductList
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}