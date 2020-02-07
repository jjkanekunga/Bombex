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
    public class ParticularsController : Controller
    {
        private bombex_dbEntities db = new bombex_dbEntities();

        // GET: Particulars
        public ActionResult Index()
        {
            var particulars = db.Particulars.Include(p => p.Resident);
            return View(particulars.ToList());
        }

        // GET: Particulars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Particular particular = db.Particulars.Find(id);
            if (particular == null)
            {
                return HttpNotFound();
            }
            return View(particular);
        }

        // GET: Particulars/Create
        public ActionResult Create()
        {
            ViewBag.ResidentID = new SelectList(db.Residents, "ResidentID", "CardNumber");
            return View();
        }

        // POST: Particulars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Esipei,WaterMeter,HouseNumber,ResidentID,Comments")] Particular particular)
        {
            if (ModelState.IsValid)
            {
                db.Particulars.Add(particular);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ResidentID = new SelectList(db.Residents, "ResidentID", "CardNumber", particular.ResidentID);
            return View(particular);
        }

        // GET: Particulars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Particular particular = db.Particulars.Find(id);
            if (particular == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResidentID = new SelectList(db.Residents, "ResidentID", "CardNumber", particular.ResidentID);
            return View(particular);
        }

        // POST: Particulars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Esipei,WaterMeter,HouseNumber,ResidentID,Comments")] Particular particular)
        {
            if (ModelState.IsValid)
            {
                db.Entry(particular).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResidentID = new SelectList(db.Residents, "ResidentID", "CardNumber", particular.ResidentID);
            return View(particular);
        }

        // GET: Particulars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Particular particular = db.Particulars.Find(id);
            if (particular == null)
            {
                return HttpNotFound();
            }
            return View(particular);
        }

        // POST: Particulars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Particular particular = db.Particulars.Find(id);
            db.Particulars.Remove(particular);
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
