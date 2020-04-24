using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLTHPT.App_Start;
using QLTHPT.Models;

namespace QLTHPT.Controllers
{
    public class QUANHUYENsController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: QUANHUYENs
        public ActionResult Index()
        {
            return View(db.QUANHUYENs.ToList());
        }

        // GET: QUANHUYENs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUANHUYEN qUANHUYEN = db.QUANHUYENs.Find(id);
            if (qUANHUYEN == null)
            {
                return HttpNotFound();
            }
            return View(qUANHUYEN);
        }

        // GET: QUANHUYENs/Create
        public ActionResult Create()
        {
            QUANHUYEN obj = new QUANHUYEN();
            obj.QH_MA = CreateID.CreateID_ByteText();
            return View(obj);
        }

        // POST: QUANHUYENs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QH_MA,QH_TEN")] QUANHUYEN qUANHUYEN)
        {
            if (ModelState.IsValid)
            {
                db.QUANHUYENs.Add(qUANHUYEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(qUANHUYEN);
        }

        // GET: QUANHUYENs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUANHUYEN qUANHUYEN = db.QUANHUYENs.Find(id);
            if (qUANHUYEN == null)
            {
                return HttpNotFound();
            }
            return View(qUANHUYEN);
        }

        // POST: QUANHUYENs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QH_MA,QH_TEN")] QUANHUYEN qUANHUYEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qUANHUYEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qUANHUYEN);
        }

        // GET: QUANHUYENs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUANHUYEN qUANHUYEN = db.QUANHUYENs.Find(id);
            if (qUANHUYEN == null)
            {
                return HttpNotFound();
            }
            return View(qUANHUYEN);
        }

        // POST: QUANHUYENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            QUANHUYEN qUANHUYEN = db.QUANHUYENs.Find(id);
            db.QUANHUYENs.Remove(qUANHUYEN);
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
