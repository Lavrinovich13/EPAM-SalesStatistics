using BL.Handlers;
using BL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesStatisticsMVC.Controllers
{
    public class SalesController : Controller
    {
        protected static IModelHandler<Sale> _saleHandler = new SaleHandler();

        // GET: Sales
        public ActionResult Index()
        {
            IEnumerable<Sale> sales = _saleHandler.GetAll(x => true);

            return View(sales);
        }
    }
}