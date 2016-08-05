using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ScheduMate.Models;

namespace ScheduMate.Controllers
{
    [Authorize]
    public class EmployersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employers
        public ActionResult Index()
        {
            return View(db.Employers.ToList());
        }

        // GET: Employers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employers employers = db.Employers.Find(id);
            if (employers == null)
            {
                return HttpNotFound();
            }
            return View(employers);
        }

        // GET: Employers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Mobile,Email,Rate", Exclude = "Photo")] Employers employers)
        {
            if (ModelState.IsValid)
            {

                byte[] imageData = null;
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase poImgFile = Request.Files["Photo"];

                    using (var binary = new BinaryReader(poImgFile.InputStream))
                    {
                        imageData = binary.ReadBytes(poImgFile.ContentLength);
                    }
                }
                employers.Photo = imageData;

                db.Employers.Add(employers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employers);
        }

        // GET: Employers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employers employers = db.Employers.Find(id);
            if (employers == null)
            {
                return HttpNotFound();
            }
            return View(employers);
        }

        // POST: Employers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Mobile,Email,Rate", Exclude = "Photo")] Employers employers)
        {
            if (ModelState.IsValid)
            {
                byte[] imageData = null;
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase poImgFile = Request.Files["Photo"];

                    using (var binary = new BinaryReader(poImgFile.InputStream))
                    {
                        imageData = binary.ReadBytes(poImgFile.ContentLength);
                    }
                }
                employers.Photo = imageData;

                db.Entry(employers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employers);
        }

        // GET: Employers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employers employers = db.Employers.Find(id);
            if (employers == null)
            {
                return HttpNotFound();
            }
            return View(employers);
        }

        // POST: Employers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employers employers = db.Employers.Find(id);
            db.Employers.Remove(employers);
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

        public FileContentResult Photos(int id)
        {
            var Image = db.Employers.Where(x => x.id == id).FirstOrDefault();

            return new FileContentResult(Image.Photo, "image/jpeg");
        }

    }
}
