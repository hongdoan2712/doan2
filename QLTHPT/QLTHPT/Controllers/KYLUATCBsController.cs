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
    public class KYLUATCBsController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: KYLUATCBs
        public ActionResult Index()
        {
            return View(db.KYLUATCBs.ToList());
        }

        // GET: KYLUATCBs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KYLUATCB kYLUATCB = db.KYLUATCBs.Find(id);
            if (kYLUATCB == null)
            {
                return HttpNotFound();
            }
            return View(kYLUATCB);
        }

        // GET: KYLUATCBs/Create
        public ActionResult Create()
        {
            KYLUATCB obj = new KYLUATCB();
            obj.KLCB_MA = CreateID.CreateID_ByteText();
            return View(obj);
        }

        // POST: KYLUATCBs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KLCB_MA,KLCB_NGAY,KLCB_HT")] KYLUATCB kYLUATCB)
        {
            if (ModelState.IsValid)
            {
                db.KYLUATCBs.Add(kYLUATCB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kYLUATCB);
        }

        // GET: KYLUATCBs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KYLUATCB kYLUATCB = db.KYLUATCBs.Find(id);
            if (kYLUATCB == null)
            {
                return HttpNotFound();
            }
            return View(kYLUATCB);
        }

        // POST: KYLUATCBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KLCB_MA,KLCB_NGAY,KLCB_HT")] KYLUATCB kYLUATCB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kYLUATCB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kYLUATCB);
        }

        // GET: KYLUATCBs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KYLUATCB kYLUATCB = db.KYLUATCBs.Find(id);
            if (kYLUATCB == null)
            {
                return HttpNotFound();
            }
            return View(kYLUATCB);
        }

        // POST: KYLUATCBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KYLUATCB kYLUATCB = db.KYLUATCBs.Find(id);
            db.KYLUATCBs.Remove(kYLUATCB);
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
