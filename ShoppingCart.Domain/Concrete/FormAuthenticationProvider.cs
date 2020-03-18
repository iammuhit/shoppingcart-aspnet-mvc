using System;
using System.Linq;
using ShoppingCart.Domain.Abstract;
using ShoppingCart.Domain.Entities;

namespace ShoppingCart.Domain.Concrete
{
    public class FormAuthenticationProvider : IAuthentication
    {
        private readonly EFDbContext context = new EFDbContext();

        public bool Authenticate(string username, string password)
        {
            User user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user == null) return false;

            return true;
        }

        public bool Logout()
        {
            return true;
        }
    }
}
