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
    public class XAPHUONGsController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: XAPHUONGs
        public ActionResult Index()
        {
            return View(db.XAPHUONGs.ToList());
        }

        // GET: XAPHUONGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XAPHUONG xAPHUONG = db.XAPHUONGs.Find(id);
            if (xAPHUONG == null)
            {
                return HttpNotFound();
            }
            return View(xAPHUONG);
        }

        // GET: XAPHUONGs/Create
        public ActionResult Create()
        {
            XAPHUONG obj = new XAPHUONG();
            obj.XP_MA = CreateID.CreateID_ByteText();
            return View(obj);
        }

        // POST: XAPHUONGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "XP_MA,XP_TEN")] XAPHUONG xAPHUONG)
        {
            if (ModelState.IsValid)
            {
                db.XAPHUONGs.Add(xAPHUONG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(xAPHUONG);
        }

        // GET: XAPHUONGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XAPHUONG xAPHUONG = db.XAPHUONGs.Find(id);
            if (xAPHUONG == null)
            {
                return HttpNotFound();
            }
            return View(xAPHUONG);
        }

        // POST: XAPHUONGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "XP_MA,XP_TEN")] XAPHUONG xAPHUONG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(xAPHUONG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(xAPHUONG);
        }

        // GET: XAPHUONGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XAPHUONG xAPHUONG = db.XAPHUONGs.Find(id);
            if (xAPHUONG == null)
            {
                return HttpNotFound();
            }
            return View(xAPHUONG);
        }

        // POST: XAPHUONGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            XAPHUONG xAPHUONG = db.XAPHUONGs.Find(id);
            db.XAPHUONGs.Remove(xAPHUONG);
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
