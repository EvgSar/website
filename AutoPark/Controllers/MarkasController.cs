using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoPark.Models;

namespace AutoPark.Controllers
{
    public class MarkasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Markas
        public ActionResult Index()
        {
            var markas = db.Markas.Include(m => m.Model);
            return View(markas.ToList());
        }

        // GET: Markas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marka marka = db.Markas.Find(id);
            if (marka == null)
            {
                return HttpNotFound();
            }
            return View(marka);
        }

        // GET: Markas/Create
        public ActionResult Create()
        {
            ViewBag.ModelId = new SelectList(db.Models, "Id", "Name");
            return View();
        }

        // POST: Markas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NameMarka,ModelId")] Marka marka)
        {
            if (ModelState.IsValid)
            {
                db.Markas.Add(marka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ModelId = new SelectList(db.Models, "Id", "Name", marka.ModelId);
            return View(marka);
        }

        // GET: Markas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marka marka = db.Markas.Find(id);
            if (marka == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModelId = new SelectList(db.Models, "Id", "Name", marka.ModelId);
            return View(marka);
        }

        // POST: Markas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NameMarka,ModelId")] Marka marka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ModelId = new SelectList(db.Models, "Id", "Name", marka.ModelId);
            return View(marka);
        }

        // GET: Markas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marka marka = db.Markas.Find(id);
            if (marka == null)
            {
                return HttpNotFound();
            }
            return View(marka);
        }

        // POST: Markas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Marka marka = db.Markas.Find(id);
            db.Markas.Remove(marka);
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
