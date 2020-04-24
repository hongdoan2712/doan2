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
    public class HOCSINHsController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: HOCSINHs
        public ActionResult Index()
        {
            var hOCSINHs = db.HOCSINHs.Include(h => h.DANTOC).Include(h => h.KHENTHUONG).Include(h => h.KHOI).Include(h => h.KYLUAT).Include(h => h.LOP).Include(h => h.QUANHUYEN).Include(h => h.TINHTHANH).Include(h => h.XAPHUONG);
            return View(hOCSINHs.ToList());
        }

        // GET: HOCSINHs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOCSINH hOCSINH = db.HOCSINHs.Find(id);
            if (hOCSINH == null)
            {
                return HttpNotFound();
            }
            return View(hOCSINH);
        }

        // GET: HOCSINHs/Create
        public ActionResult Create()
        {
            ViewBag.DANTOC_DT_MA = new SelectList(db.DANTOCs, "DT_MA", "DT_TEN");
            ViewBag.KHENTHUONG_KT_MA = new SelectList(db.KHENTHUONGs, "KT_MA", "KT_THANHTICH");
            ViewBag.KHOI_KHOI_MA = new SelectList(db.KHOIs, "KHOI_MA", "KHOI_TEN");
            ViewBag.KYLUAT_KL_MA = new SelectList(db.KYLUATs, "KL_MA", "KL_HINHTHUC");
            ViewBag.LOP_LOP_MA = new SelectList(db.LOPs, "LOP_MA", "LOP_TEN");
            ViewBag.QUANHUYEN_QH_MA = new SelectList(db.QUANHUYENs, "QH_MA", "QH_TEN");
            ViewBag.TINHTHANH_TT_MA = new SelectList(db.TINHTHANHs, "TT_MA", "TT_TEN");
            ViewBag.XAPHUONG_XP_MA = new SelectList(db.XAPHUONGs, "XP_MA", "XP_TEN");
            HOCSINH obj = new HOCSINH();
            obj.HS_MA = CreateID.CreateID_ByteText();
            return View(obj);
        }

        // POST: HOCSINHs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HS_MA,HS_HOTEN,HS_GIOITINH,HS_NGAYSINH,HS_TONGIAO,TINHTHANH_TT_MA,XAPHUONG_XP_MA,KYLUAT_KL_MA,KHENTHUONG_KT_MA,QUANHUYEN_QH_MA,DANTOC_DT_MA,LOP_LOP_MA,KHOI_KHOI_MA")] HOCSINH hOCSINH)
        {
            if (ModelState.IsValid)
            {
                db.HOCSINHs.Add(hOCSINH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DANTOC_DT_MA = new SelectList(db.DANTOCs, "DT_MA", "DT_TEN", hOCSINH.DANTOC_DT_MA);
            ViewBag.KHENTHUONG_KT_MA = new SelectList(db.KHENTHUONGs, "KT_MA", "KT_THANHTICH", hOCSINH.KHENTHUONG_KT_MA);
            ViewBag.KHOI_KHOI_MA = new SelectList(db.KHOIs, "KHOI_MA", "KHOI_TEN", hOCSINH.KHOI_KHOI_MA);
            ViewBag.KYLUAT_KL_MA = new SelectList(db.KYLUATs, "KL_MA", "KL_HINHTHUC", hOCSINH.KYLUAT_KL_MA);
            ViewBag.LOP_LOP_MA = new SelectList(db.LOPs, "LOP_MA", "LOP_TEN", hOCSINH.LOP_LOP_MA);
            ViewBag.QUANHUYEN_QH_MA = new SelectList(db.QUANHUYENs, "QH_MA", "QH_TEN", hOCSINH.QUANHUYEN_QH_MA);
            ViewBag.TINHTHANH_TT_MA = new SelectList(db.TINHTHANHs, "TT_MA", "TT_TEN", hOCSINH.TINHTHANH_TT_MA);
            ViewBag.XAPHUONG_XP_MA = new SelectList(db.XAPHUONGs, "XP_MA", "XP_TEN", hOCSINH.XAPHUONG_XP_MA);
            return View(hOCSINH);
        }

        // GET: HOCSINHs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOCSINH hOCSINH = db.HOCSINHs.Find(id);
            if (hOCSINH == null)
            {
                return HttpNotFound();
            }
            ViewBag.DANTOC_DT_MA = new SelectList(db.DANTOCs, "DT_MA", "DT_TEN", hOCSINH.DANTOC_DT_MA);
            ViewBag.KHENTHUONG_KT_MA = new SelectList(db.KHENTHUONGs, "KT_MA", "KT_THANHTICH", hOCSINH.KHENTHUONG_KT_MA);
            ViewBag.KHOI_KHOI_MA = new SelectList(db.KHOIs, "KHOI_MA", "KHOI_TEN", hOCSINH.KHOI_KHOI_MA);
            ViewBag.KYLUAT_KL_MA = new SelectList(db.KYLUATs, "KL_MA", "KL_HINHTHUC", hOCSINH.KYLUAT_KL_MA);
            ViewBag.LOP_LOP_MA = new SelectList(db.LOPs, "LOP_MA", "LOP_TEN", hOCSINH.LOP_LOP_MA);
            ViewBag.QUANHUYEN_QH_MA = new SelectList(db.QUANHUYENs, "QH_MA", "QH_TEN", hOCSINH.QUANHUYEN_QH_MA);
            ViewBag.TINHTHANH_TT_MA = new SelectList(db.TINHTHANHs, "TT_MA", "TT_TEN", hOCSINH.TINHTHANH_TT_MA);
            ViewBag.XAPHUONG_XP_MA = new SelectList(db.XAPHUONGs, "XP_MA", "XP_TEN", hOCSINH.XAPHUONG_XP_MA);
            return View(hOCSINH);
        }

        // POST: HOCSINHs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HS_MA,HS_HOTEN,HS_GIOITINH,HS_NGAYSINH,HS_TONGIAO,TINHTHANH_TT_MA,XAPHUONG_XP_MA,KYLUAT_KL_MA,KHENTHUONG_KT_MA,QUANHUYEN_QH_MA,DANTOC_DT_MA,LOP_LOP_MA,KHOI_KHOI_MA")] HOCSINH hOCSINH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOCSINH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DANTOC_DT_MA = new SelectList(db.DANTOCs, "DT_MA", "DT_TEN", hOCSINH.DANTOC_DT_MA);
            ViewBag.KHENTHUONG_KT_MA = new SelectList(db.KHENTHUONGs, "KT_MA", "KT_THANHTICH", hOCSINH.KHENTHUONG_KT_MA);
            ViewBag.KHOI_KHOI_MA = new SelectList(db.KHOIs, "KHOI_MA", "KHOI_TEN", hOCSINH.KHOI_KHOI_MA);
            ViewBag.KYLUAT_KL_MA = new SelectList(db.KYLUATs, "KL_MA", "KL_HINHTHUC", hOCSINH.KYLUAT_KL_MA);
            ViewBag.LOP_LOP_MA = new SelectList(db.LOPs, "LOP_MA", "LOP_TEN", hOCSINH.LOP_LOP_MA);
            ViewBag.QUANHUYEN_QH_MA = new SelectList(db.QUANHUYENs, "QH_MA", "QH_TEN", hOCSINH.QUANHUYEN_QH_MA);
            ViewBag.TINHTHANH_TT_MA = new SelectList(db.TINHTHANHs, "TT_MA", "TT_TEN", hOCSINH.TINHTHANH_TT_MA);
            ViewBag.XAPHUONG_XP_MA = new SelectList(db.XAPHUONGs, "XP_MA", "XP_TEN", hOCSINH.XAPHUONG_XP_MA);
            return View(hOCSINH);
        }

        // GET: HOCSINHs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOCSINH hOCSINH = db.HOCSINHs.Find(id);
            if (hOCSINH == null)
            {
                return HttpNotFound();
            }
            return View(hOCSINH);
        }

        // POST: HOCSINHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HOCSINH hOCSINH = db.HOCSINHs.Find(id);
            db.HOCSINHs.Remove(hOCSINH);
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
