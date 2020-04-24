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
    public class TINHTHANHsController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: TINHTHANHs
        public ActionResult Index()
        {
            return View(db.TINHTHANHs.ToList());
        }

        // GET: TINHTHANHs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINHTHANH tINHTHANH = db.TINHTHANHs.Find(id);
            if (tINHTHANH == null)
            {
                return HttpNotFound();
            }
            return View(tINHTHANH);
        }

        // GET: TINHTHANHs/Create
        public ActionResult Create()
        {
            TINHTHANH obj = new TINHTHANH();
            obj.TT_MA = CreateID.CreateID_ByteText();
            return View(obj);
        }

        // POST: TINHTHANHs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TT_MA,TT_TEN")] TINHTHANH tINHTHANH)
        {
            if (ModelState.IsValid)
            {
                db.TINHTHANHs.Add(tINHTHANH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tINHTHANH);
        }

        // GET: TINHTHANHs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINHTHANH tINHTHANH = db.TINHTHANHs.Find(id);
            if (tINHTHANH == null)
            {
                return HttpNotFound();
            }
            return View(tINHTHANH);
        }

        // POST: TINHTHANHs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TT_MA,TT_TEN")] TINHTHANH tINHTHANH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tINHTHANH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tINHTHANH);
        }

        // GET: TINHTHANHs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINHTHANH tINHTHANH = db.TINHTHANHs.Find(id);
            if (tINHTHANH == null)
            {
                return HttpNotFound();
            }
            return View(tINHTHANH);
        }

        // POST: TINHTHANHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TINHTHANH tINHTHANH = db.TINHTHANHs.Find(id);
            db.TINHTHANHs.Remove(tINHTHANH);
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
