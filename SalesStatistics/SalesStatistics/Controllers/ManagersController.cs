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
    public class ManagersController : Controller
    {
        protected IModelHandler<BL.Models.Manager> _managersHandler = new ManagerHandler();

        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            Mapper.CreateMap<BL.Models.Manager, Manager>();
            Mapper.CreateMap<Manager, BL.Models.Manager>();

            return View("Managers", GetManagers());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Managers()
        {
            Mapper.CreateMap<BL.Models.Manager, Manager>();

            return PartialView("ManagersGrid", GetManagers());
        }

        protected IEnumerable<Manager> GetManagers()
        {
            var managers = _managersHandler.GetAll();
            var vmManagers = Mapper.Map<IEnumerable<BL.Models.Manager>, IEnumerable<Manager>>(managers);

            return vmManagers;
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
            if (ModelState.IsValid)
            {
                if (_managersHandler.IsExists(Mapper.Map<Manager, BL.Models.Manager>(manager)))
                {
                    ModelState.AddModelError("", "This manager already exists.");
                    return View(manager);
                }
                _managersHandler.AddToDb(Mapper.Map<Manager, BL.Models.Manager>(manager));
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Invalid model.");
            }
            return View(manager);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditManager(int id)
        {
            var manager = _managersHandler.FindInDb(id);
            return PartialView(Mapper.Map<BL.Models.Manager, Manager>(manager));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditManager(Manager manager)
        {
            if (ModelState.IsValid)
            {
                if (_managersHandler.IsExists(Mapper.Map<Manager, BL.Models.Manager>(manager)))
                {
                    ModelState.AddModelError("", "This manager already exists.");
                    return View(manager);
                }   
                _managersHandler.UpdateInDb(Mapper.Map<Manager, BL.Models.Manager>(manager));
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Invalid model.");
            }
            return View(manager);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult RemoveManager(int id)
        {
            var manager = _managersHandler.FindInDb(id);
            _managersHandler.RemoveFromDb(manager);
            return RedirectToAction("Index");
        }
    }
}