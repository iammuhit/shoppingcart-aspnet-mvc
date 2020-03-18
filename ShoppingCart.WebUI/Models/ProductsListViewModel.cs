using System;
using System.Collections.Generic;
using ShoppingCart.Domain.Entities;

namespace ShoppingCart.WebUI.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
