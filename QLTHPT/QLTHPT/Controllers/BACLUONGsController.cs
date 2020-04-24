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
    public class BACLUONGsController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: BACLUONGs
        public ActionResult Index()
        {
            return View(db.BACLUONGs.ToList());
        }

        // GET: BACLUONGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BACLUONG bACLUONG = db.BACLUONGs.Find(id);
            if (bACLUONG == null)
            {
                return HttpNotFound();
            }
            return View(bACLUONG);
        }

        // GET: BACLUONGs/Create
        public ActionResult Create()
        {
            BACLUONG obj = new BACLUONG();
            obj.BL_MA = CreateID.CreateID_ByteText();
            return View(obj);
        }

        // POST: BACLUONGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BL_MA,BL_TEN")] BACLUONG bACLUONG)
        {
            if (ModelState.IsValid)
            {
                db.BACLUONGs.Add(bACLUONG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bACLUONG);
        }

        // GET: BACLUONGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BACLUONG bACLUONG = db.BACLUONGs.Find(id);
            if (bACLUONG == null)
            {
                return HttpNotFound();
            }
            return View(bACLUONG);
        }

        // POST: BACLUONGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BL_MA,BL_TEN")] BACLUONG bACLUONG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bACLUONG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bACLUONG);
        }

        // GET: BACLUONGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BACLUONG bACLUONG = db.BACLUONGs.Find(id);
            if (bACLUONG == null)
            {
                return HttpNotFound();
            }
            return View(bACLUONG);
        }

        // POST: BACLUONGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BACLUONG bACLUONG = db.BACLUONGs.Find(id);
            db.BACLUONGs.Remove(bACLUONG);
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
