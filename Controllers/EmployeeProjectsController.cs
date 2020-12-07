using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity;

namespace iitu_project_hh.Controllers
{
    public class EmployeeProjectsController : Controller
    {
        private ProjectContext db = new ProjectContext();


        // GET: EmployeeProjects
        public ActionResult Index()
        {
            var employeeProject = db.EmployeeProject.Include(e => e.Employee).Include(e => e.Project);
         
            return View(employeeProject.ToList());
        }

        // GET: AllProjectsAviable

        [Authorize]
        public ActionResult AllProjects()
        {
            var employeeProject = db.EmployeeProject.Include(e => e.Employee).Include(e => e.Project);
            var projects = db.Project.ToList();

            return View(projects);
        }


        [HttpPost]
        public ActionResult ProjectSearch(string name)
        {
            var allProjectsName = db.EmployeeProject.Where(a => a.Project.ProjectName.Contains(name)).ToList();

            if(allProjectsName.Count <= 0)
            {
                return HttpNotFound();
            }



            return PartialView(allProjectsName);
        }


        [HttpPost]
        public ActionResult Index(string ProjectName, string ProjectId)
        {
            ViewBag.Message = "CustomerName: " + ProjectName;
            return View();
        }


        // GET: EmployeeProjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeProject employeeProject = db.EmployeeProject.Find(id);
            if (employeeProject == null)
            {
                return HttpNotFound();
            }
            return View(employeeProject);
        }

        // GET: EmployeeProjects/Create
        [Authorize]
        public ActionResult Create()
        {
            string Id = User.Identity.GetUserId();
            var queryDbProjects = db.Project.Where(d => d.ProjectOwnerId == Id);
            var queryDbEmployees = db.Employee.Where(d => d.EmployeeOwnerId == Id);

            ViewBag.EmployeeId = new SelectList(queryDbEmployees, "EmployeeId", "EmployeeName");
            ViewBag.ProjectId = new SelectList(queryDbProjects, "ProjectId", "ProjectName");


            return View();
        }

        // POST: EmployeeProjects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "EmployeeId,ProjectId")] EmployeeProject employeeProject)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeProject.Add(employeeProject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employee, "EmployeeId", "EmployeeName", employeeProject.EmployeeId);
            ViewBag.ProjectId = new SelectList(db.Project, "ProjectId", "ProjectOwnerId", employeeProject.ProjectId);
            return View(employeeProject);
        }

        // GET: EmployeeProjects/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeProject employeeProject = db.EmployeeProject.Find(id);
            if (employeeProject == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employee, "EmployeeId", "EmployeeName", employeeProject.EmployeeId);
            ViewBag.ProjectId = new SelectList(db.Project, "ProjectId", "ProjectOwnerId", employeeProject.ProjectId);
            return View(employeeProject);
        }

        // POST: EmployeeProjects/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "EmployeeId,ProjectId")] EmployeeProject employeeProject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeProject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employee, "EmployeeId", "EmployeeName", employeeProject.EmployeeId);
            ViewBag.ProjectId = new SelectList(db.Project, "ProjectId", "ProjectOwnerId", employeeProject.ProjectId);
            return View(employeeProject);
        }

        // GET: EmployeeProjects/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeProject employeeProject = db.EmployeeProject.Find(id);
            if (employeeProject == null)
            {
                return HttpNotFound();
            }
            return View(employeeProject);
        }


        // POST: EmployeeProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeProject employeeProject = db.EmployeeProject.Find(id);
            db.EmployeeProject.Remove(employeeProject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
