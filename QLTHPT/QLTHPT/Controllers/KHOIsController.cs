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
    public class KHOIsController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: KHOIs
        public ActionResult Index()
        {
            return View(db.KHOIs.ToList());
        }

        // GET: KHOIs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHOI kHOI = db.KHOIs.Find(id);
            if (kHOI == null)
            {
                return HttpNotFound();
            }
            return View(kHOI);
        }

        // GET: KHOIs/Create
        public ActionResult Create()
        {
            KHOI obj = new KHOI();
            obj.KHOI_MA = CreateID.CreateID_ByteText();
            return View(obj);
        }

        // POST: KHOIs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KHOI_MA,KHOI_TEN")] KHOI kHOI)
        {
            if (ModelState.IsValid)
            {
                db.KHOIs.Add(kHOI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kHOI);
        }

        // GET: KHOIs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHOI kHOI = db.KHOIs.Find(id);
            if (kHOI == null)
            {
                return HttpNotFound();
            }
            return View(kHOI);
        }

        // POST: KHOIs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KHOI_MA,KHOI_TEN")] KHOI kHOI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kHOI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kHOI);
        }

        // GET: KHOIs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHOI kHOI = db.KHOIs.Find(id);
            if (kHOI == null)
            {
                return HttpNotFound();
            }
            return View(kHOI);
        }

        // POST: KHOIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KHOI kHOI = db.KHOIs.Find(id);
            db.KHOIs.Remove(kHOI);
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
