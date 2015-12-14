using AutoMapper;
using BL.Handlers;
using BL.Interfaces;
using SalesStatistics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesStatistics.Controllers
{
    public class ProductsController : Controller
    {
        protected IModelHandler<BL.Models.Product> _productsHandler = new ProductHandler();

        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            Mapper.CreateMap<BL.Models.Product, Product>();
            Mapper.CreateMap<Product, BL.Models.Product>();

            return View("Products", GetProducts());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Products()
        {
            Mapper.CreateMap<BL.Models.Product, Product>();

            return PartialView("ProductsGrid", GetProducts());
        }

        protected IEnumerable<Product> GetProducts()
        {
            var products = _productsHandler.GetAll();
            var vmProducts = Mapper.Map<IEnumerable<BL.Models.Product>, IEnumerable<Product>>(products);

            return vmProducts;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AddProduct()
        {
            return PartialView();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _productsHandler.AddToDb(Mapper.Map<Product, BL.Models.Product>(product));
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View("Error");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid model.");
            }
            return View(product);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditProduct(int id)
        {
            var product = _productsHandler.FindInDb(id);
            return PartialView(Mapper.Map<BL.Models.Product, Product>(product));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _productsHandler.UpdateInDb(Mapper.Map<Product, BL.Models.Product>(product));
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View("Error");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid model.");
            }
            return View(product);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult RemoveProduct(int id)
        {
            var product = _productsHandler.FindInDb(id);
            _productsHandler.RemoveFromDb(product);

            return RedirectToAction("Index");
        }
    }
}