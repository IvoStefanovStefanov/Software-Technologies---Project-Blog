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
    public class ArtPostController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ArtPost
        public ActionResult Index()
        {
            return View(db.ArtPosts.ToList());
        }

     //    GET: ArtPost/Details/5
        public ActionResult Details(int? id)
       {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtPost artPost = db.ArtPosts.Find(id);
            if (artPost == null)
            {
                return HttpNotFound();
            }
            return View(artPost);
        }

        // GET: ArtPost/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArtPost/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArtPost img, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Pictures/") + file.FileName);
                    img.ImagePath = file.FileName;
                }
                db.ArtPosts.Add(img);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(img);
        }

        // GET: ArtPost/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtPost artPost = db.ArtPosts.Find(id);
            if (artPost == null)
            {
                return HttpNotFound();
            }
            return View(artPost);
        }

        // POST: ArtPost/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ImagePath")] ArtPost artPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artPost);
        }

        // GET: ArtPost/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtPost artPost = db.ArtPosts.Find(id);
            if (artPost == null)
            {
                return HttpNotFound();
            }
            return View(artPost);
        }

        // POST: ArtPost/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArtPost artPost = db.ArtPosts.Find(id);
            db.ArtPosts.Remove(artPost);
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
