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
    public class ClientsController : Controller
    {
        protected IModelHandler<BL.Models.Client> _clientsHandler = new ClientHandler();

        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            Mapper.CreateMap<BL.Models.Client, Client>();
            Mapper.CreateMap<Client, BL.Models.Client>();

            return View("Clients", GetClients());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Clients()
        {
            Mapper.CreateMap<BL.Models.Client, Client>();

            return PartialView("ClientsGrid", GetClients());
        }

        
        protected IEnumerable<Client> GetClients()
        {
            var clients = _clientsHandler.GetAll();
            var vmClients = Mapper.Map<IEnumerable<BL.Models.Client>, IEnumerable<Client>>(clients);

            return vmClients;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AddClient()
        {
            return PartialView();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddClient(Client client)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _clientsHandler.AddToDb(Mapper.Map<Client, BL.Models.Client>(client));
                }
                catch(Exception ex)
                {
                    return View("Error");
                }
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Invalid model.");
            }
            return View(client);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditClient(int id)
        {
            var client = _clientsHandler.FindInDb(id);
            return PartialView(Mapper.Map<BL.Models.Client, Client>(client));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditClient(Client client)
        {
            if (ModelState.IsValid)
            {
                try
                {
                 
                _clientsHandler.UpdateInDb(Mapper.Map<Client, BL.Models.Client>(client));
                }
                catch (Exception ex)
                {
                    return View("Error");
                }
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Invalid model.");
            }
            return View(client);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult RemoveClient(int id)
        {
            try
            {
                var client = _clientsHandler.FindInDb(id);
                _clientsHandler.RemoveFromDb(client);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
            return RedirectToAction("Index");
        }
    }
}