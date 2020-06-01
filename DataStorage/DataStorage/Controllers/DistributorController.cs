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
    public class DistributorController : Controller
    {
        private DataStorageContext db = new DataStorageContext();

        // GET: Distributor
        public ActionResult Index()
        {
            return View(db.Distributors.ToList());
        }

        // GET: Distributor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distributor distributor = db.Distributors.Find(id);
            if (distributor == null)
            {
                return HttpNotFound();
            }
            return View(distributor);
        }

        // GET: Distributor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Distributor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NameSurname,City")] Distributor distributor)
        {
            if (ModelState.IsValid)
            {
                db.Distributors.Add(distributor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(distributor);
        }

        // GET: Distributor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distributor distributor = db.Distributors.Find(id);
            if (distributor == null)
            {
                return HttpNotFound();
            }
            return View(distributor);
        }

        // POST: Distributor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NameSurname,City")] Distributor distributor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(distributor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(distributor);
        }

        // GET: Distributor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distributor distributor = db.Distributors.Find(id);
            if (distributor == null)
            {
                return HttpNotFound();
            }
            return View(distributor);
        }

        // POST: Distributor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Distributor distributor = db.Distributors.Find(id);
            db.Distributors.Remove(distributor);
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
