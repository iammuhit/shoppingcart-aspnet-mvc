using System;
using System.Data.Entity;
using ShoppingCart.Domain.Entities;

namespace ShoppingCart.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
