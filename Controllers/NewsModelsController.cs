using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using iitu_project_hh.Models;

namespace iitu_project_hh.Controllers
{
    public class NewsModelsController : Controller
    {
        private NewsContext db = new NewsContext();

        // GET: NewsModels
        public ActionResult Index()
        {
            return View(db.NewsModel.ToList());
        }

        // GET: NewsModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsModels newsModels = db.NewsModel.Find(id);
            if (newsModels == null)
            {
                return HttpNotFound();
            }
            return View(newsModels);
        }

        // GET: NewsModels/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsModels/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Text,AddedTime,NewsImage,OwnerId")] NewsModels newsModels)
        {
            if (ModelState.IsValid)
            {
                newsModels.AddedTime = DateTime.Now;
                db.NewsModel.Add(newsModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsModels);
        }

        // GET: NewsModels/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsModels newsModels = db.NewsModel.Find(id);
            if (newsModels == null)
            {
                return HttpNotFound();
            }
            return View(newsModels);
        }

        // POST: NewsModels/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,Title,Text,AddedTime,NewsImage,OwnerId")] NewsModels newsModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsModels);
        }

        [Authorize]
        // GET: NewsModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsModels newsModels = db.NewsModel.Find(id);
            if (newsModels == null)
            {
                return HttpNotFound();
            }
            return View(newsModels);
        }


        // POST: NewsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsModels newsModels = db.NewsModel.Find(id);
            db.NewsModel.Remove(newsModels);
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
