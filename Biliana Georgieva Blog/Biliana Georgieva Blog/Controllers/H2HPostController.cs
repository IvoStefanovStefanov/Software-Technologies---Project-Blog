using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Biliana_Georgieva_Blog.Models;

namespace Biliana_Georgieva_Blog.Controllers
{
    public class H2HPostController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: H2HPost
        public ActionResult Index()
        {
            return View(db.H2HPosts.ToList());
        }

        // GET: H2HPost/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            H2HPost h2HPost = db.H2HPosts.Find(id);
            if (h2HPost == null)
            {
                return HttpNotFound();
            }
            return View(h2HPost);
        }

        // GET: H2HPost/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: H2HPost/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Body,Date")] H2HPost h2HPost)
        {
            if (ModelState.IsValid)
            {
                db.H2HPosts.Add(h2HPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(h2HPost);
        }

        // GET: H2HPost/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            H2HPost h2HPost = db.H2HPosts.Find(id);
            if (h2HPost == null)
            {
                return HttpNotFound();
            }
            return View(h2HPost);
        }

        // POST: H2HPost/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Body,Date")] H2HPost h2HPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(h2HPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(h2HPost);
        }

        // GET: H2HPost/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            H2HPost h2HPost = db.H2HPosts.Find(id);
            if (h2HPost == null)
            {
                return HttpNotFound();
            }
            return View(h2HPost);
        }

        // POST: H2HPost/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            H2HPost h2HPost = db.H2HPosts.Find(id);
            db.H2HPosts.Remove(h2HPost);
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
