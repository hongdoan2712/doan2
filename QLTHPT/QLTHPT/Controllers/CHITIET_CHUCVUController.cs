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
    public class CHITIET_CHUCVUController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: CHITIET_CHUCVU
        public ActionResult Index(string id)
        {
            var cHITIET_CHUCVU = db.CHITIET_CHUCVU.Include(c => c.CANBO).Include(c => c.CHUCVU).Where(c => c.CHUCVU_CV_MA == id);
            ViewBag.CV_MA = id;
            return View(cHITIET_CHUCVU.ToList());
        }

        // GET: CHITIET_CHUCVU/Details/5
        public ActionResult Details(TimeSpan id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIET_CHUCVU cHITIET_CHUCVU = db.CHITIET_CHUCVU.Find(id);
            if (cHITIET_CHUCVU == null)
            {
                return HttpNotFound();
            }
            return View(cHITIET_CHUCVU);
        }

        // GET: CHITIET_CHUCVU/Create
        public ActionResult Create(string id)
        {
            ViewBag.CANBO_CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN");
            ViewBag.CHUCVU_CV_MA = new SelectList(db.CHUCVUs, "CV_MA", "CV_TEN");
            ViewBag.CHUCVU = db.CHUCVUs.FirstOrDefault(cv => cv.CV_MA == id);
            return View();
        }

        // POST: CHITIET_CHUCVU/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CT_CV_ID,CHUCVU_CV_MA,CANBO_CB_MA")] CHITIET_CHUCVU cHITIET_CHUCVU)
        {
            string duongdan = "Index/" + cHITIET_CHUCVU.CHUCVU_CV_MA;
            if (ModelState.IsValid)
            {
                db.CHITIET_CHUCVU.Add(cHITIET_CHUCVU);
                db.SaveChanges();
                return RedirectToAction(duongdan);
            }

            ViewBag.CANBO_CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN", cHITIET_CHUCVU.CANBO_CB_MA);
            ViewBag.CHUCVU_CV_MA = new SelectList(db.CHUCVUs, "CV_MA", "CV_TEN", cHITIET_CHUCVU.CHUCVU_CV_MA);
            return View(duongdan);
        }

        // GET: CHITIET_CHUCVU/Edit/5
        public ActionResult Edit(TimeSpan id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIET_CHUCVU cHITIET_CHUCVU = db.CHITIET_CHUCVU.Find(id);
            if (cHITIET_CHUCVU == null)
            {
                return HttpNotFound();
            }
            ViewBag.CANBO_CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN", cHITIET_CHUCVU.CANBO_CB_MA);
            ViewBag.CHUCVU_CV_MA = new SelectList(db.CHUCVUs, "CV_MA", "CV_TEN", cHITIET_CHUCVU.CHUCVU_CV_MA);
            return View(cHITIET_CHUCVU);
        }

        // POST: CHITIET_CHUCVU/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CT_CV_ID,CHUCVU_CV_MA,CANBO_CB_MA")] CHITIET_CHUCVU cHITIET_CHUCVU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHITIET_CHUCVU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CANBO_CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN", cHITIET_CHUCVU.CANBO_CB_MA);
            ViewBag.CHUCVU_CV_MA = new SelectList(db.CHUCVUs, "CV_MA", "CV_TEN", cHITIET_CHUCVU.CHUCVU_CV_MA);
            return View(cHITIET_CHUCVU);
        }

        // GET: CHITIET_CHUCVU/Delete/5
        public ActionResult Delete(TimeSpan id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIET_CHUCVU cHITIET_CHUCVU = db.CHITIET_CHUCVU.Find(id);
            if (cHITIET_CHUCVU == null)
            {
                return HttpNotFound();
            }
            return View(cHITIET_CHUCVU);
        }

        // POST: CHITIET_CHUCVU/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(TimeSpan id)
        {
            CHITIET_CHUCVU cHITIET_CHUCVU = db.CHITIET_CHUCVU.Find(id);
            db.CHITIET_CHUCVU.Remove(cHITIET_CHUCVU);
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
