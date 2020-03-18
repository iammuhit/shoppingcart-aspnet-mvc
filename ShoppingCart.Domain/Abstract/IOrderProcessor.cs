using System;
using ShoppingCart.Domain.Entities;

namespace ShoppingCart.Domain.Abstract
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}
