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
    public class KHENTHUONGCBsController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: KHENTHUONGCBs
        public ActionResult Index()
        {
            return View(db.KHENTHUONGCBs.ToList());
        }

        // GET: KHENTHUONGCBs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHENTHUONGCB kHENTHUONGCB = db.KHENTHUONGCBs.Find(id);
            if (kHENTHUONGCB == null)
            {
                return HttpNotFound();
            }
            return View(kHENTHUONGCB);
        }

        // GET: KHENTHUONGCBs/Create
        public ActionResult Create()
        {
           KHENTHUONGCB obj = new KHENTHUONGCB();
            obj.KTCB_MA = CreateID.CreateID_ByteText();
            return View(obj);
        }

        // POST: KHENTHUONGCBs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KTCB_MA,KTCB_NGAY,KTCB_THANHTICH")] KHENTHUONGCB kHENTHUONGCB)
        {
            if (ModelState.IsValid)
            {
                db.KHENTHUONGCBs.Add(kHENTHUONGCB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kHENTHUONGCB);
        }

        // GET: KHENTHUONGCBs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHENTHUONGCB kHENTHUONGCB = db.KHENTHUONGCBs.Find(id);
            if (kHENTHUONGCB == null)
            {
                return HttpNotFound();
            }
            return View(kHENTHUONGCB);
        }

        // POST: KHENTHUONGCBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KTCB_MA,KTCB_NGAY,KTCB_THANHTICH")] KHENTHUONGCB kHENTHUONGCB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kHENTHUONGCB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kHENTHUONGCB);
        }

        // GET: KHENTHUONGCBs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHENTHUONGCB kHENTHUONGCB = db.KHENTHUONGCBs.Find(id);
            if (kHENTHUONGCB == null)
            {
                return HttpNotFound();
            }
            return View(kHENTHUONGCB);
        }

        // POST: KHENTHUONGCBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KHENTHUONGCB kHENTHUONGCB = db.KHENTHUONGCBs.Find(id);
            db.KHENTHUONGCBs.Remove(kHENTHUONGCB);
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
