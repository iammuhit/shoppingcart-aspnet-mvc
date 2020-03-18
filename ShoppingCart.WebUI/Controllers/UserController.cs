using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ShoppingCart.Domain.Abstract;
using ShoppingCart.WebUI.Models;

namespace ShoppingCart.WebUI.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IAuthentication authentication;

        public UserController(IAuthentication authentication)
        {
            this.authentication = authentication;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View ();
        }

        [AllowAnonymous, HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                if(authentication.Authenticate(model.Username, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);

                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                } else
                {
                    ModelState.AddModelError("", "Incorrect username or password.");
                    return View();
                }
            }

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Admin");
        }
    }
}
