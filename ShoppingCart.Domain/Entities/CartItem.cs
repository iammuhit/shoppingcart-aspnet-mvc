using System;

namespace ShoppingCart.Domain.Entities
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
