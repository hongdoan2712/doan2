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
    public class HOCKiesController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: HOCKies
        public ActionResult Index()
        {
            return View(db.HOCKies.ToList());
        }

        // GET: HOCKies/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOCKY hOCKY = db.HOCKies.Find(id);
            if (hOCKY == null)
            {
                return HttpNotFound();
            }
            return View(hOCKY);
        }

        // GET: HOCKies/Create
        public ActionResult Create()
        {
            HOCKY obj = new HOCKY();
            obj.HK_MA = CreateID.CreateID_ByteText();
            return View(obj);
        }

        // POST: HOCKies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HK_MA,HK_TEN")] HOCKY hOCKY)
        {
            if (ModelState.IsValid)
            {
                db.HOCKies.Add(hOCKY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hOCKY);
        }

        // GET: HOCKies/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOCKY hOCKY = db.HOCKies.Find(id);
            if (hOCKY == null)
            {
                return HttpNotFound();
            }
            return View(hOCKY);
        }

        // POST: HOCKies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HK_MA,HK_TEN")] HOCKY hOCKY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOCKY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hOCKY);
        }

        // GET: HOCKies/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOCKY hOCKY = db.HOCKies.Find(id);
            if (hOCKY == null)
            {
                return HttpNotFound();
            }
            return View(hOCKY);
        }

        // POST: HOCKies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HOCKY hOCKY = db.HOCKies.Find(id);
            db.HOCKies.Remove(hOCKY);
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
