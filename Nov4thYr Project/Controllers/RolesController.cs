﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Nov4thYr_Project.Models;

namespace Nov4thYr_Project.Controllers
{
    [Authorize(Roles = "Administrator")] 
    public class RolesController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        ProjectDBEntities2 au = new ProjectDBEntities2();
        // GET: Roles
        public ActionResult Index()
        {
            return View(context.Roles.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        //Creating new roles
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                context.Roles.Add(new IdentityRole()
                {
                    Name = collection["RoleName"]
                });
                context.SaveChanges();
                ViewBag.ResultMessage = "Role created successfully";
                return View("Create");
            }
            catch
            {
                return View();
            }
        }

        //Deleting existing roles
        public ActionResult Delete(string RoleName)
        {
            var thisRole = context.Roles.Where(r => r.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            context.Roles.Remove(thisRole);
            context.SaveChanges();
            return RedirectToAction("Create");
        }

        //Editing existing roles
        // GET: /Roles/Edit/5
        public ActionResult Edit(string roleName)
        {
            var thisRole = context.Roles.Where(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            return View(thisRole);
        }

        // POST: /Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IdentityRole role)
        {
            try
            {
                context.Entry(role).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ManageUserRoles()
        {
            // prepopulate roles for the view dropdown
            var list = context.Roles.OrderBy(r => r.Name).ToList().Select(rr =>

            new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;

            var testemails = au.AspNetUsers.OrderBy(n => n.Email).ToList().Select(nn => new SelectListItem { Value = nn.Email.ToString(), Text = nn.Email }).ToList();
            ViewBag.displayEmails = testemails;

            ViewBag.UserEmails = au.AspNetUsers.Select(s => new SelectListItem
            {
                Value = s.Email,
                Text = s.Email
            }).ToList();

            return View();
        }


        public ActionResult ManageUsers()
        {
            // prepopulat roles for the view dropdown
            var list = context.Roles.OrderBy(r => r.Name).ToList().Select(rr =>
            new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;

            var testemails = au.AspNetUsers.OrderBy(n => n.Email).ToList().Select(nn => 
            new SelectListItem { Value = nn.Email.ToString(), Text = nn.Email }).ToList();
            ViewBag.displayEmails = testemails;

            ViewBag.UserEmails = au.AspNetUsers.Select(s => new SelectListItem
            {
                Value = s.Email,
                Text = s.Email
            }).ToList();
            return View();
        }
        //Add role to user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(string UserName, string RoleName, string name)
        {
            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            manager.AddToRole(user.Id, RoleName);
            

            //ViewBag.ResultMessage = "Role created successfully !";

            // prepopulate roles for the view dropdown
            var list = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;

            var testemails = au.AspNetUsers.OrderBy(n => n.Email).ToList().Select(nn => new SelectListItem { Value = nn.Email.ToString(), Text = nn.Email }).ToList();
            ViewBag.displayEmails = testemails;

            ViewBag.UserEmails = au.AspNetUsers.Select(s => new SelectListItem
            {
                Value = s.Email,
                Text = s.Email
            }).ToList();

            return View("ManageUsers");
        }
        //Get roles for user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

                ViewBag.RolesForThisUser = manager.GetRoles(user.Id);

                // prepopulate roles for the view dropdown
                var list = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                ViewBag.Roles = list;

                var testemails = au.AspNetUsers.OrderBy(n => n.Email).ToList().Select(nn => new SelectListItem { Value = nn.Email.ToString(), Text = nn.Email }).ToList();
                ViewBag.displayEmails = testemails;

                ViewBag.UserEmails = au.AspNetUsers.Select(s => new SelectListItem
                {
                    Value = s.Email,
                    Text = s.Email
                }).ToList();

            }

            return View("ManageUsers");
        }
        //Delete role from user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleForUser(string UserName, string RoleName)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            if (manager.IsInRole(user.Id, RoleName))
            {
                manager.RemoveFromRole(user.Id, RoleName);
                ViewBag.ResultMessage = "Role removed from this user successfully !";
            }
            else
            {
                ViewBag.ResultMessage = "This user doesn't belong to selected role.";
            }
            // prepopulate roles for the view dropdown
            var list = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;

            var testemails = au.AspNetUsers.OrderBy(n => n.Email).ToList().Select(nn => new SelectListItem { Value = nn.Email.ToString(), Text = nn.Email }).ToList();
            ViewBag.displayEmails = testemails;

            ViewBag.UserEmails = au.AspNetUsers.Select(s => new SelectListItem
            {
                Value = s.Email,
                Text = s.Email
            }).ToList();

            return View("ManageUsers");
        }
    }
}