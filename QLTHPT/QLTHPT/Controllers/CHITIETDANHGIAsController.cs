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
    public class CHITIETDANHGIAsController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: CHITIETDANHGIAs
        public ActionResult Index()
        {
            var cHITIETDANHGIAs = db.CHITIETDANHGIAs.Include(c => c.HOCSINH).Include(c => c.SODANHGIA);
            return View(cHITIETDANHGIAs.ToList());
        }

        // GET: CHITIETDANHGIAs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETDANHGIA cHITIETDANHGIA = db.CHITIETDANHGIAs.Find(id);
            if (cHITIETDANHGIA == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETDANHGIA);
        }

        // GET: CHITIETDANHGIAs/Create
        public ActionResult Create()
        {
            ViewBag.HOCSINH_HS_MA = new SelectList(db.HOCSINHs, "HS_MA", "HS_HOTEN");
            ViewBag.SODANHGIA_SDG_MA = new SelectList(db.SODANHGIAs, "SDG_MA", "SDG_DIEM");
            CANBO obj = new CANBO();
            obj.CB_MA = CreateID.CreateID_ByteText();
            return View(obj);
        }

        // POST: CHITIETDANHGIAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CTDG_MA,CTDG_NGAYDG,SODANHGIA_SDG_MA,HOCSINH_HS_MA")] CHITIETDANHGIA cHITIETDANHGIA)
        {
            if (ModelState.IsValid)
            {
                db.CHITIETDANHGIAs.Add(cHITIETDANHGIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HOCSINH_HS_MA = new SelectList(db.HOCSINHs, "HS_MA", "HS_HOTEN", cHITIETDANHGIA.HOCSINH_HS_MA);
            ViewBag.SODANHGIA_SDG_MA = new SelectList(db.SODANHGIAs, "SDG_MA", "SDG_DIEM", cHITIETDANHGIA.SODANHGIA_SDG_MA);
            return View(cHITIETDANHGIA);
        }

        // GET: CHITIETDANHGIAs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETDANHGIA cHITIETDANHGIA = db.CHITIETDANHGIAs.Find(id);
            if (cHITIETDANHGIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.HOCSINH_HS_MA = new SelectList(db.HOCSINHs, "HS_MA", "HS_HOTEN", cHITIETDANHGIA.HOCSINH_HS_MA);
            ViewBag.SODANHGIA_SDG_MA = new SelectList(db.SODANHGIAs, "SDG_MA", "SDG_DIEM", cHITIETDANHGIA.SODANHGIA_SDG_MA);
            return View(cHITIETDANHGIA);
        }

        // POST: CHITIETDANHGIAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CTDG_MA,CTDG_NGAYDG,SODANHGIA_SDG_MA,HOCSINH_HS_MA")] CHITIETDANHGIA cHITIETDANHGIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHITIETDANHGIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HOCSINH_HS_MA = new SelectList(db.HOCSINHs, "HS_MA", "HS_HOTEN", cHITIETDANHGIA.HOCSINH_HS_MA);
            ViewBag.SODANHGIA_SDG_MA = new SelectList(db.SODANHGIAs, "SDG_MA", "SDG_DIEM", cHITIETDANHGIA.SODANHGIA_SDG_MA);
            return View(cHITIETDANHGIA);
        }

        // GET: CHITIETDANHGIAs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETDANHGIA cHITIETDANHGIA = db.CHITIETDANHGIAs.Find(id);
            if (cHITIETDANHGIA == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETDANHGIA);
        }

        // POST: CHITIETDANHGIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CHITIETDANHGIA cHITIETDANHGIA = db.CHITIETDANHGIAs.Find(id);
            db.CHITIETDANHGIAs.Remove(cHITIETDANHGIA);
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
