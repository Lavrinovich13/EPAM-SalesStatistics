using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SalesStatistics.Models;
using AutoMapper;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SalesStatistics.Controllers
{
    public class UsersController : Controller
    {
        protected static ApplicationDbContext _context = new ApplicationDbContext();

        protected ApplicationUserManager _userManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        protected RoleManager<IdentityRole> _roleManager =
            new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            ViewBag.Roles = new List<IdentityRole>(_roleManager.Roles);
            return View("Users", GetUsers());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Users()
        {
            return PartialView("UsersGrid", GetUsers());
        }

        protected IEnumerable<ApplicationUser> GetUsers()
        {
            var users = new List<ApplicationUser>(_userManager.Users);
            return users;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AddUser()
        {
            return RedirectToAction("Register", "Account");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult RemoveUser(string id)
        {
            var user = _userManager.FindById(id);
            _userManager.Delete(user);
            return RedirectToAction("Index");
        }
    }
}