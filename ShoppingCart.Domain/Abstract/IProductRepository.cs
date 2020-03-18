using System;
using System.Collections.Generic;
using ShoppingCart.Domain.Entities;

namespace ShoppingCart.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

        void SaveProduct(Product product);
        Product DeleteProduct(int Id);
    }
}
