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
    public class WrittenConvController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WrittenConv
        public ActionResult Index()
        {
            return View(db.WrittenConvs.ToList());
        }

        // GET: WrittenConv/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WrittenConv writtenConv = db.WrittenConvs.Find(id);
            if (writtenConv == null)
            {
                return HttpNotFound();
            }
            return View(writtenConv);
        }

        // GET: WrittenConv/Create
        [Authorize(Roles = "Administrators")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: WrittenConv/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrators")]
        public ActionResult Create([Bind(Include = "Id,Title,Body")] WrittenConv writtenConv)
        {
            if (ModelState.IsValid)
            {
                db.WrittenConvs.Add(writtenConv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(writtenConv);
        }

        // GET: WrittenConv/Edit/5
        [Authorize(Roles = "Administrators")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WrittenConv writtenConv = db.WrittenConvs.Find(id);
            if (writtenConv == null)
            {
                return HttpNotFound();
            }
            return View(writtenConv);
        }

        // POST: WrittenConv/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrators")]
        public ActionResult Edit([Bind(Include = "Id,Title,Body,Date")] WrittenConv writtenConv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(writtenConv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(writtenConv);
        }

        // GET: WrittenConv/Delete/5
        [Authorize(Roles = "Administrators")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WrittenConv writtenConv = db.WrittenConvs.Find(id);
            if (writtenConv == null)
            {
                return HttpNotFound();
            }
            return View(writtenConv);
        }

        // POST: WrittenConv/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrators")]
        public ActionResult DeleteConfirmed(int id)
        {
            WrittenConv writtenConv = db.WrittenConvs.Find(id);
            db.WrittenConvs.Remove(writtenConv);
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
