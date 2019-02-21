using Nov4thYr_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nov4thYr_Project.Controllers
{
    public class CRUDUserController : Controller
    {
        // GET: CRUDUser
        public ActionResult Index()
        {
            return View();
        }

        
        [Authorize(Roles = "Administrator")]
        public ActionResult UserList()
        {
            var context = new Models.ApplicationDbContext();
            return View(context.Users.ToList());
        }
        
        [Authorize(Roles = "Administrator")]
        public ActionResult UserDelete(string id)
        {
            var context = new Models.ApplicationDbContext();
            var user = context.Users.Where(u => u.Id == id).FirstOrDefault();
            return View(user);
        }
        
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult UserDelete(ApplicationUser appuser)
        {
            var context = new Models.ApplicationDbContext();
            var user = context.Users.Where(u => u.Id == appuser.Id).FirstOrDefault();
            context.Users.Remove(user);
            context.SaveChanges();
            //var user = context.Users.Where(u => u.Id == id.ToString()).FirstOrDefault();
            return RedirectToAction("UserList");
        }
        
        [Authorize(Roles = "Administrator")]
        public ActionResult UserEdit(string id)
        {
            var context = new Models.ApplicationDbContext();
            var user = context.Users.Where(u => u.Id == id).FirstOrDefault();
            return View(user);
        }
        
        [HttpPost]
        [Authorize(Roles = "Administrator") ]
        public ActionResult UserEdit(ApplicationUser appuser)
        {
            var context = new Models.ApplicationDbContext();
            var user = context.Users.Where(u => u.Id == appuser.Id).FirstOrDefault();
            //context.Entry(appuser).State = EntityState.Modified;
            user.Email = appuser.Email;
            user.UserName = appuser.UserName;
            user.PhoneNumber = appuser.PhoneNumber;
            user.PasswordHash = user.PasswordHash;
            context.SaveChanges();
            //var user = context.Users.Where(u => u.Id == id.ToString()).FirstOrDefault();
            return RedirectToAction("UserList");
        }
    }
}