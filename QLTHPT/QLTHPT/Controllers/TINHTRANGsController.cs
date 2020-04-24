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
    public class TINHTRANGsController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: TINHTRANGs
        public ActionResult Index()
        {
            return View(db.TINHTRANGs.ToList());
        }

        // GET: TINHTRANGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINHTRANG tINHTRANG = db.TINHTRANGs.Find(id);
            if (tINHTRANG == null)
            {
                return HttpNotFound();
            }
            return View(tINHTRANG);
        }

        // GET: TINHTRANGs/Create
        public ActionResult Create()
        {
            TINHTRANG obj = new TINHTRANG();
            obj.TT_MA = CreateID.CreateID_ByteText();
            return View(obj);
        }

        // POST: TINHTRANGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TT_MA,TT_MOTA")] TINHTRANG tINHTRANG)
        {
            if (ModelState.IsValid)
            {
                db.TINHTRANGs.Add(tINHTRANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tINHTRANG);
        }

        // GET: TINHTRANGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINHTRANG tINHTRANG = db.TINHTRANGs.Find(id);
            if (tINHTRANG == null)
            {
                return HttpNotFound();
            }
            return View(tINHTRANG);
        }

        // POST: TINHTRANGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TT_MA,TT_MOTA")] TINHTRANG tINHTRANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tINHTRANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tINHTRANG);
        }

        // GET: TINHTRANGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINHTRANG tINHTRANG = db.TINHTRANGs.Find(id);
            if (tINHTRANG == null)
            {
                return HttpNotFound();
            }
            return View(tINHTRANG);
        }

        // POST: TINHTRANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TINHTRANG tINHTRANG = db.TINHTRANGs.Find(id);
            db.TINHTRANGs.Remove(tINHTRANG);
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
