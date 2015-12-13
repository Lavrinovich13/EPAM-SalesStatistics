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

        protected User ConvertToUser(ApplicationUser appUser)
        {
            var user =  new User() 
            { Email = appUser.Email, Id = appUser.Id, UserName = appUser.UserName};

            user.Role = _userManager.GetRoles(user.Id).ElementAt(0);
            return user;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            Mapper.CreateMap<User, ApplicationUser>();

            return View("Users", GetUsers());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Users()
        {
            return PartialView("UsersGrid", GetUsers());
        }

        protected IEnumerable<User> GetUsers()
        {
            var users = new List<ApplicationUser>(_userManager.Users);
            var vmUsers = users.Select(x => ConvertToUser(x));
            return vmUsers;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AddUser()
        {
            return RedirectToAction("Register", "Account");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                var appUser = new ApplicationUser() { Email = user.Email, UserName = user.UserName };
                var result = _userManager.Create(appUser, user.Password);

                if (result.Succeeded)
                {
                    _userManager.AddToRole(appUser.Id, user.Role);
                    _userManager.SetLockoutEnabled(appUser.Id, true);
                    return RedirectToAction("Index");
                }
            }
            return View(user);
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