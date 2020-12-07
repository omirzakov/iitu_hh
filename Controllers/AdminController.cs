using iitu_project_hh.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iitu_project_hh.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        private ApplicationDbContext db = new ApplicationDbContext();

        
        [Authorize(Roles = "Admin")]

        public ActionResult Index()
        {
            var Users = db.Users.ToList();

            return View(Users);
        }
    }
}