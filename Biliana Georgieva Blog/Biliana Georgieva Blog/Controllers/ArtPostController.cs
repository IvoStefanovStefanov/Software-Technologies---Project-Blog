using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biliana_Georgieva_Blog.Controllers
{
    public class ArtPostController : Controller
    {
        // GET: ArtPost
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Upload(HttpPostedFileBase file)
        {
            string path = Server.MapPath("~/Pictures/" + file.FileName);
            file.SaveAs(path);
            ViewBag.Path = path;
            return View();
        }
    }
}