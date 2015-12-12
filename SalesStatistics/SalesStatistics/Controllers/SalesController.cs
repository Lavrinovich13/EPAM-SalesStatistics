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
    public class SalesController : Controller
    {
        // GET: Sales
        protected IModelHandler<BL.Models.Sale> _salesHandler = new SaleHandler();
        protected IModelHandler<BL.Models.Product> _productsHandler = new ProductHandler();
        protected IModelHandler<BL.Models.Manager> _managersHandler = new ManagerHandler();
        protected IModelHandler<BL.Models.Client> _clientsHandler = new ClientHandler();

        [HttpGet]
        [Authorize(Roles = "Admin")]
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

            return View("Sales", GetSales());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Sales()
        {
            return PartialView("SalesGrid", GetSales());
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<Sale> GetSales()
        {
            var sales = _salesHandler.GetAll();
            var vmSales = Mapper.Map<IEnumerable<BL.Models.Sale>, IEnumerable<Sale>>(sales);

            return vmSales;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AddSale()
        {
            ViewBag.Products =
                new List<SelectListItem>(Mapper.Map<IEnumerable<BL.Models.Product>, IEnumerable<Product>>(_productsHandler.GetAll())
                .Select(x => new SelectListItem() { Text = x.ToString(), Value = x.Id.ToString() }));
            ViewBag.Managers =
                new List<SelectListItem>(Mapper.Map<IEnumerable<BL.Models.Manager>, IEnumerable<Manager>>(_managersHandler.GetAll())
                .Select(x => new SelectListItem() { Text = x.ToString(), Value = x.Id.ToString() }));
            ViewBag.Clients =
                new List<SelectListItem>(Mapper.Map<IEnumerable<BL.Models.Client>, IEnumerable<Client>>(_clientsHandler.GetAll())
                .Select(x => new SelectListItem() { Text = x.ToString(), Value = x.Id.ToString() }));

            return PartialView();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddSale(Sale sale)
        {
            if (ModelState.IsValid)
            {
                _salesHandler.AddToDb(Mapper.Map<Sale, BL.Models.Sale>(sale));
                return RedirectToAction("Index");
            }
            return View(sale);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditSale(int id)
        {
            var sale = Mapper.Map<BL.Models.Sale, Sale>(_salesHandler.FindInDb(id));
            ViewBag.Products =
                new List<SelectListItem>(Mapper.Map<IEnumerable<BL.Models.Product>, IEnumerable<Product>>(_productsHandler.GetAll())
                .Select(x => new SelectListItem() { Text = x.ToString(), Value = x.Id.ToString() }));
            ViewBag.Managers =
                new List<SelectListItem>(Mapper.Map<IEnumerable<BL.Models.Manager>, IEnumerable<Manager>>(_managersHandler.GetAll())
                .Select(x => new SelectListItem() { Text = x.ToString(), Value = x.Id.ToString() }));
            ViewBag.Clients =
                new List<SelectListItem>(Mapper.Map<IEnumerable<BL.Models.Client>, IEnumerable<Client>>(_clientsHandler.GetAll())
                .Select(x => new SelectListItem() { Text = x.ToString(), Value = x.Id.ToString() }));

            return PartialView(sale);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditSale(Sale sale)
        {
            if (ModelState.IsValid)
            {
                _salesHandler.UpdateInDb(Mapper.Map<Sale, BL.Models.Sale>(sale));
                return RedirectToAction("Index");
            }
            return View(sale);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult RemoveSale(int id)
        {
            var sale = _salesHandler.FindInDb(id);
            _salesHandler.RemoveFromDb(sale);
            return RedirectToAction("Index");
        }
    }
}