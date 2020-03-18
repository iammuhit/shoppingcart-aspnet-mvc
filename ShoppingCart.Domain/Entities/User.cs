using System;
using System.Web.Mvc;

namespace ShoppingCart.Domain.Entities
{
    public class User
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
