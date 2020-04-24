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
    public class NGACHLUONGsController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: NGACHLUONGs
        public ActionResult Index()
        {
            return View(db.NGACHLUONGs.ToList());
        }

        // GET: NGACHLUONGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGACHLUONG nGACHLUONG = db.NGACHLUONGs.Find(id);
            if (nGACHLUONG == null)
            {
                return HttpNotFound();
            }
            return View(nGACHLUONG);
        }

        // GET: NGACHLUONGs/Create
        public ActionResult Create()
        {
            NGACHLUONG obj = new NGACHLUONG();
            obj.NL_MA = CreateID.CreateID_ByteText();
            return View(obj);
        }

        // POST: NGACHLUONGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NL_MA,NL_TEN")] NGACHLUONG nGACHLUONG)
        {
            if (ModelState.IsValid)
            {
                db.NGACHLUONGs.Add(nGACHLUONG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nGACHLUONG);
        }

        // GET: NGACHLUONGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGACHLUONG nGACHLUONG = db.NGACHLUONGs.Find(id);
            if (nGACHLUONG == null)
            {
                return HttpNotFound();
            }
            return View(nGACHLUONG);
        }

        // POST: NGACHLUONGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NL_MA,NL_TEN")] NGACHLUONG nGACHLUONG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nGACHLUONG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nGACHLUONG);
        }

        // GET: NGACHLUONGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGACHLUONG nGACHLUONG = db.NGACHLUONGs.Find(id);
            if (nGACHLUONG == null)
            {
                return HttpNotFound();
            }
            return View(nGACHLUONG);
        }

        // POST: NGACHLUONGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NGACHLUONG nGACHLUONG = db.NGACHLUONGs.Find(id);
            db.NGACHLUONGs.Remove(nGACHLUONG);
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
