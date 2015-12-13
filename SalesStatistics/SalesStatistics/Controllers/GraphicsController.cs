
using AutoMapper;
using BL.Handlers;
using BL.Interfaces;
using Newtonsoft.Json;
using SalesStatistics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesStatistics.Controllers
{
    public class GraphicsController : Controller
    {
        protected IModelHandler<BL.Models.Product> _productsHandler = new ProductHandler();
        protected IModelHandler<BL.Models.Sale> _salesHandler = new SaleHandler();
        protected IModelHandler<BL.Models.Manager> _managersHandler = new ManagerHandler();

        [Authorize(Roles = "User")]
        // GET: Graphics
        public ActionResult Index()
        {
            Mapper.CreateMap<BL.Models.Sale, Sale>();
            Mapper.CreateMap<Sale, BL.Models.Sale>();

            Mapper.CreateMap<BL.Models.Product, Product>();
            Mapper.CreateMap<Product, BL.Models.Product>();

            Mapper.CreateMap<BL.Models.Manager, Manager>();
            Mapper.CreateMap<Manager, BL.Models.Manager>();

            Mapper.CreateMap<BL.Models.Client, Client>();
            Mapper.CreateMap<Client, BL.Models.Client>();

            return View("Graphics");
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public JsonResult GetDataForProductsGraphic()
         {
             var sales =
                 Mapper.Map<IEnumerable<BL.Models.Sale>, IEnumerable<Sale>>(_salesHandler.GetAll());

             var products = 
                 Mapper.Map<IEnumerable<BL.Models.Product>, IEnumerable<Product>>(_productsHandler.GetAll());

             var dict = new { name = "Products", colorByPoint = true,
                 data = products
                 .Select(x => new { name = x.Name, y = sales.Count(y => y.Product.Id == x.Id)})
                 .ToArray() };

             var array = new object[] { dict };

             return Json(array, JsonRequestBehavior.AllowGet);

         }

        [Authorize(Roles = "User")]
        [HttpPost]
        public JsonResult GetDataForManagersGraphic()
        {
            var sales =
                Mapper.Map<IEnumerable<BL.Models.Sale>, IEnumerable<Sale>>(_salesHandler.GetAll());

            double salesNumber = (double)sales.Count() / 100;

            var managers =
                Mapper.Map<IEnumerable<BL.Models.Manager>, IEnumerable<Manager>>(_managersHandler.GetAll());

            var dict = new { name = "Managers", colorByPoint = true, 
                data = managers
                .Select(x => new { name = x.LastName, y = salesNumber != 0 ? (double)sales.Count(y => y.Manager.Id == x.Id) / salesNumber : 0, drilldown = x.LastName })
                .ToArray() };

            var array = new object[] { dict };

            return Json(array, JsonRequestBehavior.AllowGet);

        }
    }
}