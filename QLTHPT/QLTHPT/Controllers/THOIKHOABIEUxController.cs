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
    public class THOIKHOABIEUxController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: THOIKHOABIEUx
        public ActionResult Index()
        {
            var tHOIKHOABIEUx = db.THOIKHOABIEUx.Include(t => t.CANBO).Include(t => t.HOCKY).Include(t => t.LOP).Include(t => t.MONHOC).Include(t => t.THU).Include(t => t.TIETHOC);
            return View(tHOIKHOABIEUx.ToList());
        }

        // GET: THOIKHOABIEUx/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THOIKHOABIEU tHOIKHOABIEU = db.THOIKHOABIEUx.Find(id);
            if (tHOIKHOABIEU == null)
            {
                return HttpNotFound();
            }
            return View(tHOIKHOABIEU);
        }

        // GET: THOIKHOABIEUx/Create
        public ActionResult Create()
        {
            ViewBag.CANBO_CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN");
            ViewBag.HOCKY_HK_MA = new SelectList(db.HOCKies, "HK_MA", "HK_TEN");
            ViewBag.LOP_LOP_MA = new SelectList(db.LOPs, "LOP_MA", "LOP_TEN");
            ViewBag.MONHOC_MH_MA = new SelectList(db.MONHOCs, "MH_MA", "MH_TEN");
            ViewBag.THU_THU_MA = new SelectList(db.THUs, "THU_MA", "THU_TEN");
            ViewBag.TIETHOC_TH_MA = new SelectList(db.TIETHOCs, "TH_MA", "TH_TEN");
            THOIKHOABIEU obj = new THOIKHOABIEU();
            obj.TKB_MA = CreateID.CreateID_ByteText();
            return View(obj);
        }

        // POST: THOIKHOABIEUx/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TKB_MA,LOP_LOP_MA,MONHOC_MH_MA,THU_THU_MA,TIETHOC_TH_MA,CANBO_CB_MA,HOCKY_HK_MA")] THOIKHOABIEU tHOIKHOABIEU)
        {
            if (ModelState.IsValid)
            {
                db.THOIKHOABIEUx.Add(tHOIKHOABIEU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CANBO_CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN", tHOIKHOABIEU.CANBO_CB_MA);
            ViewBag.HOCKY_HK_MA = new SelectList(db.HOCKies, "HK_MA", "HK_TEN", tHOIKHOABIEU.HOCKY_HK_MA);
            ViewBag.LOP_LOP_MA = new SelectList(db.LOPs, "LOP_MA", "LOP_TEN", tHOIKHOABIEU.LOP_LOP_MA);
            ViewBag.MONHOC_MH_MA = new SelectList(db.MONHOCs, "MH_MA", "MH_TEN", tHOIKHOABIEU.MONHOC_MH_MA);
            ViewBag.THU_THU_MA = new SelectList(db.THUs, "THU_MA", "THU_TEN", tHOIKHOABIEU.THU_THU_MA);
            ViewBag.TIETHOC_TH_MA = new SelectList(db.TIETHOCs, "TH_MA", "TH_TEN", tHOIKHOABIEU.TIETHOC_TH_MA);
            return View(tHOIKHOABIEU);
        }

        // GET: THOIKHOABIEUx/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THOIKHOABIEU tHOIKHOABIEU = db.THOIKHOABIEUx.Find(id);
            if (tHOIKHOABIEU == null)
            {
                return HttpNotFound();
            }
            ViewBag.CANBO_CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN", tHOIKHOABIEU.CANBO_CB_MA);
            ViewBag.HOCKY_HK_MA = new SelectList(db.HOCKies, "HK_MA", "HK_TEN", tHOIKHOABIEU.HOCKY_HK_MA);
            ViewBag.LOP_LOP_MA = new SelectList(db.LOPs, "LOP_MA", "LOP_TEN", tHOIKHOABIEU.LOP_LOP_MA);
            ViewBag.MONHOC_MH_MA = new SelectList(db.MONHOCs, "MH_MA", "MH_TEN", tHOIKHOABIEU.MONHOC_MH_MA);
            ViewBag.THU_THU_MA = new SelectList(db.THUs, "THU_MA", "THU_TEN", tHOIKHOABIEU.THU_THU_MA);
            ViewBag.TIETHOC_TH_MA = new SelectList(db.TIETHOCs, "TH_MA", "TH_TEN", tHOIKHOABIEU.TIETHOC_TH_MA);
            return View(tHOIKHOABIEU);
        }

        // POST: THOIKHOABIEUx/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TKB_MA,LOP_LOP_MA,MONHOC_MH_MA,THU_THU_MA,TIETHOC_TH_MA,CANBO_CB_MA,HOCKY_HK_MA")] THOIKHOABIEU tHOIKHOABIEU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHOIKHOABIEU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CANBO_CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN", tHOIKHOABIEU.CANBO_CB_MA);
            ViewBag.HOCKY_HK_MA = new SelectList(db.HOCKies, "HK_MA", "HK_TEN", tHOIKHOABIEU.HOCKY_HK_MA);
            ViewBag.LOP_LOP_MA = new SelectList(db.LOPs, "LOP_MA", "LOP_TEN", tHOIKHOABIEU.LOP_LOP_MA);
            ViewBag.MONHOC_MH_MA = new SelectList(db.MONHOCs, "MH_MA", "MH_TEN", tHOIKHOABIEU.MONHOC_MH_MA);
            ViewBag.THU_THU_MA = new SelectList(db.THUs, "THU_MA", "THU_TEN", tHOIKHOABIEU.THU_THU_MA);
            ViewBag.TIETHOC_TH_MA = new SelectList(db.TIETHOCs, "TH_MA", "TH_TEN", tHOIKHOABIEU.TIETHOC_TH_MA);
            return View(tHOIKHOABIEU);
        }

        // GET: THOIKHOABIEUx/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THOIKHOABIEU tHOIKHOABIEU = db.THOIKHOABIEUx.Find(id);
            if (tHOIKHOABIEU == null)
            {
                return HttpNotFound();
            }
            return View(tHOIKHOABIEU);
        }

        // POST: THOIKHOABIEUx/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            THOIKHOABIEU tHOIKHOABIEU = db.THOIKHOABIEUx.Find(id);
            db.THOIKHOABIEUx.Remove(tHOIKHOABIEU);
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
