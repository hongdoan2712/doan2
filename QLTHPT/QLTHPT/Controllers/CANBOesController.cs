using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLTHPT.Models;

namespace QLTHPT.Controllers
{
    public class CANBOesController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: CANBOes
        public ActionResult Index()
        {
            var cANBOes = db.CANBOes.Include(c => c.COQUAN).Include(c => c.KHENTHUONGCB).Include(c => c.KYLUATCB);
            return View(cANBOes.ToList());
        }

        // GET: CANBOes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CANBO cANBO = db.CANBOes.Find(id);
            if (cANBO == null)
            {
                return HttpNotFound();
            }
            return View(cANBO);
        }

        // GET: CANBOes/Create
        public ActionResult Create()
        {
            ViewBag.COQUAN_CQ_MA = new SelectList(db.COQUANs, "CQ_MA", "CQ_TEN");
            ViewBag.KHENTHUONGCB_KTCB_MA = new SelectList(db.KHENTHUONGCBs, "KTCB_MA", "KTCB_NGAY");
            ViewBag.KYLUATCB_KLCB_MA = new SelectList(db.KYLUATCBs, "KLCB_MA", "KLCB_NGAY");
            return View();
        }

        // POST: CANBOes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CB_MA,CB_HOTEN,CB_GIOITINH,CB_DIACHI,CB_NGAYSINH,CB_CMND,COQUAN_CQ_MA,KYLUATCB_KLCB_MA,KHENTHUONGCB_KTCB_MA")] CANBO cANBO)
        {
            if (ModelState.IsValid)
            {
                db.CANBOes.Add(cANBO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COQUAN_CQ_MA = new SelectList(db.COQUANs, "CQ_MA", "CQ_TEN", cANBO.COQUAN_CQ_MA);
            ViewBag.KHENTHUONGCB_KTCB_MA = new SelectList(db.KHENTHUONGCBs, "KTCB_MA", "KTCB_NGAY", cANBO.KHENTHUONGCB_KTCB_MA);
            ViewBag.KYLUATCB_KLCB_MA = new SelectList(db.KYLUATCBs, "KLCB_MA", "KLCB_NGAY", cANBO.KYLUATCB_KLCB_MA);
            return View(cANBO);
        }

        // GET: CANBOes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CANBO cANBO = db.CANBOes.Find(id);
            if (cANBO == null)
            {
                return HttpNotFound();
            }
            ViewBag.COQUAN_CQ_MA = new SelectList(db.COQUANs, "CQ_MA", "CQ_TEN", cANBO.COQUAN_CQ_MA);
            ViewBag.KHENTHUONGCB_KTCB_MA = new SelectList(db.KHENTHUONGCBs, "KTCB_MA", "KTCB_NGAY", cANBO.KHENTHUONGCB_KTCB_MA);
            ViewBag.KYLUATCB_KLCB_MA = new SelectList(db.KYLUATCBs, "KLCB_MA", "KLCB_NGAY", cANBO.KYLUATCB_KLCB_MA);
            return View(cANBO);
        }

        // POST: CANBOes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CB_MA,CB_HOTEN,CB_GIOITINH,CB_DIACHI,CB_NGAYSINH,CB_CMND,COQUAN_CQ_MA,KYLUATCB_KLCB_MA,KHENTHUONGCB_KTCB_MA")] CANBO cANBO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cANBO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COQUAN_CQ_MA = new SelectList(db.COQUANs, "CQ_MA", "CQ_TEN", cANBO.COQUAN_CQ_MA);
            ViewBag.KHENTHUONGCB_KTCB_MA = new SelectList(db.KHENTHUONGCBs, "KTCB_MA", "KTCB_NGAY", cANBO.KHENTHUONGCB_KTCB_MA);
            ViewBag.KYLUATCB_KLCB_MA = new SelectList(db.KYLUATCBs, "KLCB_MA", "KLCB_NGAY", cANBO.KYLUATCB_KLCB_MA);
            return View(cANBO);
        }

        // GET: CANBOes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CANBO cANBO = db.CANBOes.Find(id);
            if (cANBO == null)
            {
                return HttpNotFound();
            }
            return View(cANBO);
        }

        // POST: CANBOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CANBO cANBO = db.CANBOes.Find(id);
            db.CANBOes.Remove(cANBO);
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
