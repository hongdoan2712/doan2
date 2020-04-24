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
    public class PHONGHOCsController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: PHONGHOCs
        public ActionResult Index()
        {
            return View(db.PHONGHOCs.ToList());
        }

        // GET: PHONGHOCs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHONGHOC pHONGHOC = db.PHONGHOCs.Find(id);
            if (pHONGHOC == null)
            {
                return HttpNotFound();
            }
            return View(pHONGHOC);
        }

        // GET: PHONGHOCs/Create
        public ActionResult Create()
        {
            PHONGHOC obj = new PHONGHOC();
            obj.PH_MA = CreateID.CreateID_ByteText();
            return View(obj);
        }

        // POST: PHONGHOCs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PH_MA,PH_TEN")] PHONGHOC pHONGHOC)
        {
            if (ModelState.IsValid)
            {
                db.PHONGHOCs.Add(pHONGHOC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pHONGHOC);
        }

        // GET: PHONGHOCs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHONGHOC pHONGHOC = db.PHONGHOCs.Find(id);
            if (pHONGHOC == null)
            {
                return HttpNotFound();
            }
            return View(pHONGHOC);
        }

        // POST: PHONGHOCs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PH_MA,PH_TEN")] PHONGHOC pHONGHOC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHONGHOC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pHONGHOC);
        }

        // GET: PHONGHOCs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHONGHOC pHONGHOC = db.PHONGHOCs.Find(id);
            if (pHONGHOC == null)
            {
                return HttpNotFound();
            }
            return View(pHONGHOC);
        }

        // POST: PHONGHOCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHONGHOC pHONGHOC = db.PHONGHOCs.Find(id);
            db.PHONGHOCs.Remove(pHONGHOC);
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
