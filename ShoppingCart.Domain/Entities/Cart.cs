using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Domain.Entities
{
    public class Cart
    {
        private List<CartItem> items = new List<CartItem>();

        public void Add(Product product, int quantity)
        {
            CartItem item = items.Where(p => p.Product.Id == product.Id).FirstOrDefault();

            if (item == null)
            {
                items.Add(new CartItem { Product = product, Quantity = quantity });
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public void Remove(Product product)
        {
            items.RemoveAll(p => p.Product.Id == product.Id);
        }

        public decimal TotalPrice()
        {
            return items.Sum(p => p.Product.Price * p.Quantity);
        }

        public IEnumerable<CartItem> Items => items;

        public void Clear()
        {
            items.Clear();
        }
    }
}
