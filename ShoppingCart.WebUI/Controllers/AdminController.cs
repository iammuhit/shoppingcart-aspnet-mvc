using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Domain.Abstract;
using ShoppingCart.Domain.Entities;

namespace ShoppingCart.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository repository;

        public AdminController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return View(repository.Products);
        }

        public ViewResult Create()
        {
            return View(new Product());
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = String.Format("{0} has been added.", product.Name);

                return RedirectToAction("Index");
            }

            return View(product);
        }

        public ViewResult Edit(int Id)
        {
            Product product = repository.Products.FirstOrDefault(p => p.Id == Id);

            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = String.Format("{0} has been updated.", product.Name);

                return RedirectToAction("Index");
            }

            return View(product);
        }

        public ActionResult View(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = repository.Products.FirstOrDefault(p => p.Id == Id);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            Product product = repository.DeleteProduct(Id);

            if (product != null)
                TempData["message"] = String.Format("{0} has been deleted.", product.Name);

            return RedirectToAction("Index");
        }
    }
}
