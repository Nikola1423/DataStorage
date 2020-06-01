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
    public class DistributorTableController : Controller
    {
        private DataStorageContext db = new DataStorageContext();

        // GET: DistributorTable
        public ActionResult Index(string searchString)
        {
            var distributorTables = db.DistributorTables.Include(d => d.Distributor).Include(d => d.Vehicle).Include(d => d.YearInput);
            //Filtracija po ime 
            if (!String.IsNullOrEmpty(searchString))
            {
                distributorTables = distributorTables.Where((d => d.Distributor.NameSurname.Contains(searchString)));

            }

            return View(distributorTables.ToList());
        }

        // GET: DistributorTable/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DistributorTable distributorTable = db.DistributorTables.Find(id);
            if (distributorTable == null)
            {
                return HttpNotFound();
            }
            return View(distributorTable);
        }

        // GET: DistributorTable/Create
        public ActionResult Create()
        {
            ViewBag.DistributorID = new SelectList(db.Distributors, "ID", "NameSurname");
            ViewBag.VehicleID = new SelectList(db.Vehicles, "ID", "Registration");
            ViewBag.YearInputID = new SelectList(db.YearInputs, "ID", "Year");
            return View();
        }

        // POST: DistributorTable/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,VehicleID,DistributorID,Month,YearInputID,Realization,PriceOfCostOfProduct,Gratis,Shortage,Storage,Unload,Commercialist,BrutoPay,BrutoPercent,NetoPay,NetoPercent,Fuel,Service,Consumables,RegistrationInsurance,OtherExpenses")] DistributorTable distributorTable)
        {
            if (ModelState.IsValid)
            {
                db.DistributorTables.Add(distributorTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DistributorID = new SelectList(db.Distributors, "ID", "NameSurname", distributorTable.DistributorID);
            ViewBag.VehicleID = new SelectList(db.Vehicles, "ID", "Registration", distributorTable.VehicleID);
            ViewBag.YearInputID = new SelectList(db.YearInputs, "ID", "Year", distributorTable.YearInputID);
            return View(distributorTable);
        }

        // GET: DistributorTable/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DistributorTable distributorTable = db.DistributorTables.Find(id);
            if (distributorTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistributorID = new SelectList(db.Distributors, "ID", "NameSurname", distributorTable.DistributorID);
            ViewBag.VehicleID = new SelectList(db.Vehicles, "ID", "Registration", distributorTable.VehicleID);
            ViewBag.YearInputID = new SelectList(db.YearInputs, "ID", "Year", distributorTable.YearInputID);
            return View(distributorTable);
        }

        // POST: DistributorTable/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,VehicleID,DistributorID,Month,YearInputID,Realization,PriceOfCostOfProduct,Gratis,Shortage,Storage,Unload,Commercialist,BrutoPay,BrutoPercent,NetoPay,NetoPercent,Fuel,Service,Consumables,RegistrationInsurance,OtherExpenses")] DistributorTable distributorTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(distributorTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DistributorID = new SelectList(db.Distributors, "ID", "NameSurname", distributorTable.DistributorID);
            ViewBag.VehicleID = new SelectList(db.Vehicles, "ID", "Registration", distributorTable.VehicleID);
            ViewBag.YearInputID = new SelectList(db.YearInputs, "ID", "Year", distributorTable.YearInputID);
            return View(distributorTable);
        }

        // GET: DistributorTable/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DistributorTable distributorTable = db.DistributorTables.Find(id);
            if (distributorTable == null)
            {
                return HttpNotFound();
            }
            return View(distributorTable);
        }

        // POST: DistributorTable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DistributorTable distributorTable = db.DistributorTables.Find(id);
            db.DistributorTables.Remove(distributorTable);
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
