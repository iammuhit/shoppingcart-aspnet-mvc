using System;
using ShoppingCart.Domain.Entities;

namespace ShoppingCart.WebUI.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
