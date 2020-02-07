using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bombex.Models;

namespace Bombex.Controllers
{
    public class VisitorsController : Controller
    {
        private bombex_dbEntities db = new bombex_dbEntities();

        // GET: Visitors
        public ActionResult Index()
        {
            var visitors = db.Visitors.Include(v => v.Resident).Include(v => v.Vehicle);
            return View(visitors.ToList());
        }

        // GET: Visitors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visitor visitor = db.Visitors.Find(id);
            if (visitor == null)
            {
                return HttpNotFound();
            }
            return View(visitor);
        }

        // GET: Visitors/Create
        public ActionResult Create()
        {
            ViewBag.ResidentID = new SelectList(db.Residents, "ResidentID", "CardNumber");
            ViewBag.VehicleNumber = new SelectList(db.Vehicles, "VehicleNumber", "SafetySticker");
            return View();
        }

        // POST: Visitors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Company,VehicleNumber,NumberOfPeople,Photo,ResidentID")] Visitor visitor)
        {
            if (ModelState.IsValid)
            {
                db.Visitors.Add(visitor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ResidentID = new SelectList(db.Residents, "ResidentID", "CardNumber", visitor.ResidentID);
            ViewBag.VehicleNumber = new SelectList(db.Vehicles, "VehicleNumber", "SafetySticker", visitor.VehicleNumber);
            return View(visitor);
        }

        // GET: Visitors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visitor visitor = db.Visitors.Find(id);
            if (visitor == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResidentID = new SelectList(db.Residents, "ResidentID", "CardNumber", visitor.ResidentID);
            ViewBag.VehicleNumber = new SelectList(db.Vehicles, "VehicleNumber", "SafetySticker", visitor.VehicleNumber);
            return View(visitor);
        }

        // POST: Visitors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Company,VehicleNumber,NumberOfPeople,Photo,ResidentID")] Visitor visitor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visitor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResidentID = new SelectList(db.Residents, "ResidentID", "CardNumber", visitor.ResidentID);
            ViewBag.VehicleNumber = new SelectList(db.Vehicles, "VehicleNumber", "SafetySticker", visitor.VehicleNumber);
            return View(visitor);
        }

        // GET: Visitors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visitor visitor = db.Visitors.Find(id);
            if (visitor == null)
            {
                return HttpNotFound();
            }
            return View(visitor);
        }

        // POST: Visitors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visitor visitor = db.Visitors.Find(id);
            db.Visitors.Remove(visitor);
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
