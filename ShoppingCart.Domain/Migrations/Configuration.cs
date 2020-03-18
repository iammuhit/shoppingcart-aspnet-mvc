
namespace ShoppingCart.Domain.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using ShoppingCart.Domain.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<ShoppingCart.Domain.Concrete.EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShoppingCart.Domain.Concrete.EFDbContext context)
        {
            var users = new List<User>
            {
                new User { Username = "admin", Password = "123456" }
            };

            users.ForEach(user => context.Users.AddOrUpdate(u => u.Username, user));
            context.SaveChanges();
        }
    }
}
