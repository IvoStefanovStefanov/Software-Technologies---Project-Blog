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
    public class H2HCommentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: H2HComment
        public ActionResult Index()
        {
            return View(db.H2HComments.Include(p => p.Author).ToList());
        }

        // GET: H2HComment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            H2HComment h2HComment = db.H2HComments.Find(id);
            if (h2HComment == null)
            {
                return HttpNotFound();
            }
            return View(h2HComment);
        }

        // GET: H2HComment/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: H2HComment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Text")] H2HComment h2HComment)
        {
            if (ModelState.IsValid)
            {
                db.H2HComments.Add(h2HComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(h2HComment);
        }

        // GET: H2HComment/Edit/5
        [Authorize(Roles = "Administrators")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            H2HComment h2HComment = db.H2HComments.Find(id);
            if (h2HComment == null)
            {
                return HttpNotFound();
            }
            return View(h2HComment);
        }

        // POST: H2HComment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrators")]
        public ActionResult Edit([Bind(Include = "Id,Text")] H2HComment h2HComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(h2HComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(h2HComment);
        }

        // GET: H2HComment/Delete/5
        [Authorize(Roles = "Administrators")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            H2HComment h2HComment = db.H2HComments.Find(id);
            if (h2HComment == null)
            {
                return HttpNotFound();
            }
            return View(h2HComment);
        }

        // POST: H2HComment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrators")]
        public ActionResult DeleteConfirmed(int id)
        {
            H2HComment h2HComment = db.H2HComments.Find(id);
            db.H2HComments.Remove(h2HComment);
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
