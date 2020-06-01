using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataStorage.DAL;
using DataStorage.Models;

namespace DataStorage.Controllers
{
    public class YearInputController : Controller
    {
        private DataStorageContext db = new DataStorageContext();

        // GET: YearInput
        public ActionResult Index()
        {
            return View(db.YearInputs.ToList());
        }

        // GET: YearInput/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearInput yearInput = db.YearInputs.Find(id);
            if (yearInput == null)
            {
                return HttpNotFound();
            }
            return View(yearInput);
        }

        // GET: YearInput/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: YearInput/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Year")] YearInput yearInput)
        {
            if (ModelState.IsValid)
            {
                db.YearInputs.Add(yearInput);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yearInput);
        }

        // GET: YearInput/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearInput yearInput = db.YearInputs.Find(id);
            if (yearInput == null)
            {
                return HttpNotFound();
            }
            return View(yearInput);
        }

        // POST: YearInput/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Year")] YearInput yearInput)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yearInput).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yearInput);
        }

        // GET: YearInput/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearInput yearInput = db.YearInputs.Find(id);
            if (yearInput == null)
            {
                return HttpNotFound();
            }
            return View(yearInput);
        }

        // POST: YearInput/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YearInput yearInput = db.YearInputs.Find(id);
            db.YearInputs.Remove(yearInput);
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
