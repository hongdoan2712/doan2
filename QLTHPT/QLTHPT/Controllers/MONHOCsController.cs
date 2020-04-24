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
    public class MONHOCsController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: MONHOCs
        public ActionResult Index()
        {
            var mONHOCs = db.MONHOCs.Include(m => m.CHITIETDANHGIA);
            return View(mONHOCs.ToList());
        }

        // GET: MONHOCs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MONHOC mONHOC = db.MONHOCs.Find(id);
            if (mONHOC == null)
            {
                return HttpNotFound();
            }
            return View(mONHOC);
        }

        // GET: MONHOCs/Create
        public ActionResult Create()
        {
            ViewBag.CHITIETDANHGIA_CTDG_MA = new SelectList(db.CHITIETDANHGIAs, "CTDG_MA", "SODANHGIA_SDG_MA");
            MONHOC obj = new MONHOC();
            obj.MH_MA = CreateID.CreateID_ByteText();
            return View(obj);
        }

        // POST: MONHOCs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MH_MA,MH_TEN,CHITIETDANHGIA_CTDG_MA")] MONHOC mONHOC)
        {
            if (ModelState.IsValid)
            {
                db.MONHOCs.Add(mONHOC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CHITIETDANHGIA_CTDG_MA = new SelectList(db.CHITIETDANHGIAs, "CTDG_MA", "SODANHGIA_SDG_MA", mONHOC.CHITIETDANHGIA_CTDG_MA);
            return View(mONHOC);
        }

        // GET: MONHOCs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MONHOC mONHOC = db.MONHOCs.Find(id);
            if (mONHOC == null)
            {
                return HttpNotFound();
            }
            ViewBag.CHITIETDANHGIA_CTDG_MA = new SelectList(db.CHITIETDANHGIAs, "CTDG_MA", "SODANHGIA_SDG_MA", mONHOC.CHITIETDANHGIA_CTDG_MA);
            return View(mONHOC);
        }

        // POST: MONHOCs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MH_MA,MH_TEN,CHITIETDANHGIA_CTDG_MA")] MONHOC mONHOC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mONHOC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CHITIETDANHGIA_CTDG_MA = new SelectList(db.CHITIETDANHGIAs, "CTDG_MA", "SODANHGIA_SDG_MA", mONHOC.CHITIETDANHGIA_CTDG_MA);
            return View(mONHOC);
        }

        // GET: MONHOCs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MONHOC mONHOC = db.MONHOCs.Find(id);
            if (mONHOC == null)
            {
                return HttpNotFound();
            }
            return View(mONHOC);
        }

        // POST: MONHOCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MONHOC mONHOC = db.MONHOCs.Find(id);
            db.MONHOCs.Remove(mONHOC);
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
