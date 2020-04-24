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
    public class THONGTINDAOTAOsController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: THONGTINDAOTAOs
        public ActionResult Index(string id)
        {
            var tHONGTINDAOTAOs = db.THONGTINDAOTAOs.Include(t => t.CANBO).Where(t => t.CANBO_CB_MA == id).Include(t => t.CHUYENNGANH).Include(t => t.HINHTHUC).Include(t => t.VANBANG);
            ViewBag.CB_MA = id;
            return View(tHONGTINDAOTAOs.ToList());
        }

        // GET: THONGTINDAOTAOs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THONGTINDAOTAO tHONGTINDAOTAO = db.THONGTINDAOTAOs.Find(id);
            if (tHONGTINDAOTAO == null)
            {
                return HttpNotFound();
            }
            return View(tHONGTINDAOTAO);
        }

        // GET: THONGTINDAOTAOs/Create
        public ActionResult Create(string id)
        {
            ViewBag.CHUYENNGANH_CN_MA = new SelectList(db.CHUYENNGANHs, "CN_MA", "CN_TEN");
            ViewBag.HINHTHUCs_HT_MA = new SelectList(db.HINHTHUCs, "HT_MA", "HT_TEN");
            ViewBag.VANBANG_VB_MA = new SelectList(db.VANBANGs, "VB_MA", "VB_TEN");
            ViewBag.CANBO_CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN");
            ViewBag.CANBO = db.CANBOes.FirstOrDefault(cb => cb.CB_MA == id);
            THONGTINDAOTAO obj = new THONGTINDAOTAO();
            obj.TTDT_MA = CreateID.CreateID_ByteText();
            return View(obj);
        }

        // POST: THONGTINDAOTAOs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TTDT_MA,HINHTHUCs_HT_MA,CHUYENNGANH_CN_MA,VANBANG_VB_MA,CANBO_CB_MA")] THONGTINDAOTAO tHONGTINDAOTAO)
        {
            string duongdan = "Index/" + tHONGTINDAOTAO.CANBO_CB_MA;
            if (ModelState.IsValid)
            {
                db.THONGTINDAOTAOs.Add(tHONGTINDAOTAO);
                db.SaveChanges();
                return RedirectToAction(duongdan);
            }

            ViewBag.CANBO_CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN", tHONGTINDAOTAO.CANBO_CB_MA);
            ViewBag.CHUYENNGANH_CN_MA = new SelectList(db.CHUYENNGANHs, "CN_MA", "CN_TEN", tHONGTINDAOTAO.CHUYENNGANH_CN_MA);
            ViewBag.HINHTHUCs_HT_MA = new SelectList(db.HINHTHUCs, "HT_MA", "HT_TEN", tHONGTINDAOTAO.HINHTHUCs_HT_MA);
            ViewBag.VANBANG_VB_MA = new SelectList(db.VANBANGs, "VB_MA", "VB_TEN", tHONGTINDAOTAO.VANBANG_VB_MA);
            return View(duongdan);
        }

        // GET: THONGTINDAOTAOs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THONGTINDAOTAO tHONGTINDAOTAO = db.THONGTINDAOTAOs.Find(id);
            if (tHONGTINDAOTAO == null)
            {
                return HttpNotFound();
            }
            ViewBag.CANBO_CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN", tHONGTINDAOTAO.CANBO_CB_MA);
            ViewBag.CHUYENNGANH_CN_MA = new SelectList(db.CHUYENNGANHs, "CN_MA", "CN_TEN", tHONGTINDAOTAO.CHUYENNGANH_CN_MA);
            ViewBag.HINHTHUCs_HT_MA = new SelectList(db.HINHTHUCs, "HT_MA", "HT_TEN", tHONGTINDAOTAO.HINHTHUCs_HT_MA);
            ViewBag.VANBANG_VB_MA = new SelectList(db.VANBANGs, "VB_MA", "VB_TEN", tHONGTINDAOTAO.VANBANG_VB_MA);
            return View(tHONGTINDAOTAO);
        }

        // POST: THONGTINDAOTAOs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TTDT_MA,HINHTHUCs_HT_MA,CHUYENNGANH_CN_MA,VANBANG_VB_MA,CANBO_CB_MA")] THONGTINDAOTAO tHONGTINDAOTAO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHONGTINDAOTAO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CANBO_CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN", tHONGTINDAOTAO.CANBO_CB_MA);
            ViewBag.CHUYENNGANH_CN_MA = new SelectList(db.CHUYENNGANHs, "CN_MA", "CN_TEN", tHONGTINDAOTAO.CHUYENNGANH_CN_MA);
            ViewBag.HINHTHUCs_HT_MA = new SelectList(db.HINHTHUCs, "HT_MA", "HT_TEN", tHONGTINDAOTAO.HINHTHUCs_HT_MA);
            ViewBag.VANBANG_VB_MA = new SelectList(db.VANBANGs, "VB_MA", "VB_TEN", tHONGTINDAOTAO.VANBANG_VB_MA);
            return View(tHONGTINDAOTAO);
        }

        // GET: THONGTINDAOTAOs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THONGTINDAOTAO tHONGTINDAOTAO = db.THONGTINDAOTAOs.Find(id);
            if (tHONGTINDAOTAO == null)
            {
                return HttpNotFound();
            }
            return View(tHONGTINDAOTAO);
        }

        // POST: THONGTINDAOTAOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            THONGTINDAOTAO tHONGTINDAOTAO = db.THONGTINDAOTAOs.Find(id);
            db.THONGTINDAOTAOs.Remove(tHONGTINDAOTAO);
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
