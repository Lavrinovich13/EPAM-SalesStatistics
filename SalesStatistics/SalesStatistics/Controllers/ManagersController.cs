using AutoMapper;
using BL.Handlers;
using BL.Interfaces;
using Grid.Mvc.Ajax.GridExtensions;
using SalesStatistics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesStatistics.Controllers
{
    public class ManagersController : Controller
    {
        protected IModelHandler<BL.Models.Manager> _managersHandler = new ManagerHandler();

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            Mapper.CreateMap<BL.Models.Manager, Manager>();

            var managers = _managersHandler.GetAll();
            var vmManagers = Mapper.Map<IEnumerable<BL.Models.Manager>, IEnumerable<Manager>>(managers).AsQueryable();

            var grid = (AjaxGrid<Manager>)new AjaxGridFactory().CreateAjaxGrid(vmManagers, 1, false, 5);

            return View("Managers", grid);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AddManager()
        {
            return PartialView();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddManager(Manager manager)
        {
            Mapper.CreateMap<Manager, BL.Models.Manager>();

            if(ModelState.IsValid)
            {
                _managersHandler.AddToDb(Mapper.Map<Manager, BL.Models.Manager>(manager));
                return RedirectToAction("Index");
            }
            return PartialView();
        }
    }
}