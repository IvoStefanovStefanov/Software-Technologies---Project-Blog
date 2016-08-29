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
    public class WrittenConvCommentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WrittenConvComment
        public ActionResult Index()
        {
            return View(db.WrittenConvComments.ToList());
        }

        // GET: WrittenConvComment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WrittenConvComment writtenConvComment = db.WrittenConvComments.Find(id);
            if (writtenConvComment == null)
            {
                return HttpNotFound();
            }
            return View(writtenConvComment);
        }

        // GET: WrittenConvComment/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: WrittenConvComment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Text")] WrittenConvComment writtenConvComment)
        {
            if (ModelState.IsValid)
            {
                db.WrittenConvComments.Add(writtenConvComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(writtenConvComment);
        }

        // GET: WrittenConvComment/Edit/5
        [Authorize(Roles = "Administrators")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WrittenConvComment writtenConvComment = db.WrittenConvComments.Find(id);
            if (writtenConvComment == null)
            {
                return HttpNotFound();
            }
            return View(writtenConvComment);
        }

        // POST: WrittenConvComment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrators")]
        public ActionResult Edit([Bind(Include = "Id,Text,Date")] WrittenConvComment writtenConvComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(writtenConvComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(writtenConvComment);
        }

        // GET: WrittenConvComment/Delete/5
        [Authorize(Roles = "Administrators")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WrittenConvComment writtenConvComment = db.WrittenConvComments.Find(id);
            if (writtenConvComment == null)
            {
                return HttpNotFound();
            }
            return View(writtenConvComment);
        }

        // POST: WrittenConvComment/Delete/5
        [Authorize(Roles = "Administrators")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WrittenConvComment writtenConvComment = db.WrittenConvComments.Find(id);
            db.WrittenConvComments.Remove(writtenConvComment);
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
