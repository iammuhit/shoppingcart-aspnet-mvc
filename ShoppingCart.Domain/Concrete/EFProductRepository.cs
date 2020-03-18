using System;
using System.Collections.Generic;
using ShoppingCart.Domain.Abstract;
using ShoppingCart.Domain.Entities;

namespace ShoppingCart.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private readonly EFDbContext context = new EFDbContext();

        public IEnumerable<Product> Products => context.Products;

        public void SaveProduct(Product product)
        {
            if (product.Id == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products.Find(product.Id);

                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }

            context.SaveChanges();
        }

        public Product DeleteProduct(int Id)
        {
            Product product = context.Products.Find(Id);

            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }

            return product;
        }
    }
}
