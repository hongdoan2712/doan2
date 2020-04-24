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
    public class HINHTHUCsController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: HINHTHUCs
        public ActionResult Index()
        {
            return View(db.HINHTHUCs.ToList());
        }

        // GET: HINHTHUCs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HINHTHUC hINHTHUC = db.HINHTHUCs.Find(id);
            if (hINHTHUC == null)
            {
                return HttpNotFound();
            }
            return View(hINHTHUC);
        }

        // GET: HINHTHUCs/Create
        public ActionResult Create()
        {
            HINHTHUC obj = new HINHTHUC();
            obj.HT_MA = CreateID.CreateID_ByteText();
            return View(obj);
        }

        // POST: HINHTHUCs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HT_MA,HT_TEN")] HINHTHUC hINHTHUC)
        {
            if (ModelState.IsValid)
            {
                db.HINHTHUCs.Add(hINHTHUC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hINHTHUC);
        }

        // GET: HINHTHUCs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HINHTHUC hINHTHUC = db.HINHTHUCs.Find(id);
            if (hINHTHUC == null)
            {
                return HttpNotFound();
            }
            return View(hINHTHUC);
        }

        // POST: HINHTHUCs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HT_MA,HT_TEN")] HINHTHUC hINHTHUC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hINHTHUC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hINHTHUC);
        }

        // GET: HINHTHUCs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HINHTHUC hINHTHUC = db.HINHTHUCs.Find(id);
            if (hINHTHUC == null)
            {
                return HttpNotFound();
            }
            return View(hINHTHUC);
        }

        // POST: HINHTHUCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HINHTHUC hINHTHUC = db.HINHTHUCs.Find(id);
            db.HINHTHUCs.Remove(hINHTHUC);
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
