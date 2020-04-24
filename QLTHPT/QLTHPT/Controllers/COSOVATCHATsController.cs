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
    public class COSOVATCHATsController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: COSOVATCHATs
        public ActionResult Index()
        {
            var cOSOVATCHATs = db.COSOVATCHATs.Include(c => c.PHONGHOC).Include(c => c.THIETBIDAYHOC).Include(c => c.THIETBIGIANGDAY).Include(c => c.TINHTRANG);
            return View(cOSOVATCHATs.ToList());
        }

        // GET: COSOVATCHATs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COSOVATCHAT cOSOVATCHAT = db.COSOVATCHATs.Find(id);
            if (cOSOVATCHAT == null)
            {
                return HttpNotFound();
            }
            return View(cOSOVATCHAT);
        }

        // GET: COSOVATCHATs/Create
        public ActionResult Create()
        {
            ViewBag.PHONGHOC_PH_MA = new SelectList(db.PHONGHOCs, "PH_MA", "PH_TEN");
            ViewBag.THIETBIDAYHOC_TBDH_MA = new SelectList(db.THIETBIDAYHOCs, "TBDH_MA", "TBDH_TEN");
            ViewBag.THIETBIGIANGDAY_TBGD_MA = new SelectList(db.THIETBIGIANGDAYs, "TBGD_MA", "TBGD_TEN");
            ViewBag.TINHTRANG_TT_MA = new SelectList(db.TINHTRANGs, "TT_MA", "TT_MOTA");
            COSOVATCHAT obj = new COSOVATCHAT();
            obj.CSVC_MA = CreateID.CreateID_ByteText();
            return View(obj);
        }

        // POST: COSOVATCHATs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CSVC_MA,CSVC_SOLUONG,PHONGHOC_PH_MA,THIETBIGIANGDAY_TBGD_MA,THIETBIDAYHOC_TBDH_MA,TINHTRANG_TT_MA")] COSOVATCHAT cOSOVATCHAT)
        {
            if (ModelState.IsValid)
            {
                db.COSOVATCHATs.Add(cOSOVATCHAT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PHONGHOC_PH_MA = new SelectList(db.PHONGHOCs, "PH_MA", "PH_TEN", cOSOVATCHAT.PHONGHOC_PH_MA);
            ViewBag.THIETBIDAYHOC_TBDH_MA = new SelectList(db.THIETBIDAYHOCs, "TBDH_MA", "TBDH_TEN", cOSOVATCHAT.THIETBIDAYHOC_TBDH_MA);
            ViewBag.THIETBIGIANGDAY_TBGD_MA = new SelectList(db.THIETBIGIANGDAYs, "TBGD_MA", "TBGD_TEN", cOSOVATCHAT.THIETBIGIANGDAY_TBGD_MA);
            ViewBag.TINHTRANG_TT_MA = new SelectList(db.TINHTRANGs, "TT_MA", "TT_MOTA", cOSOVATCHAT.TINHTRANG_TT_MA);
            return View(cOSOVATCHAT);
        }

        // GET: COSOVATCHATs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COSOVATCHAT cOSOVATCHAT = db.COSOVATCHATs.Find(id);
            if (cOSOVATCHAT == null)
            {
                return HttpNotFound();
            }
            ViewBag.PHONGHOC_PH_MA = new SelectList(db.PHONGHOCs, "PH_MA", "PH_TEN", cOSOVATCHAT.PHONGHOC_PH_MA);
            ViewBag.THIETBIDAYHOC_TBDH_MA = new SelectList(db.THIETBIDAYHOCs, "TBDH_MA", "TBDH_TEN", cOSOVATCHAT.THIETBIDAYHOC_TBDH_MA);
            ViewBag.THIETBIGIANGDAY_TBGD_MA = new SelectList(db.THIETBIGIANGDAYs, "TBGD_MA", "TBGD_TEN", cOSOVATCHAT.THIETBIGIANGDAY_TBGD_MA);
            ViewBag.TINHTRANG_TT_MA = new SelectList(db.TINHTRANGs, "TT_MA", "TT_MOTA", cOSOVATCHAT.TINHTRANG_TT_MA);
            return View(cOSOVATCHAT);
        }

        // POST: COSOVATCHATs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CSVC_MA,CSVC_SOLUONG,PHONGHOC_PH_MA,THIETBIGIANGDAY_TBGD_MA,THIETBIDAYHOC_TBDH_MA,TINHTRANG_TT_MA")] COSOVATCHAT cOSOVATCHAT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOSOVATCHAT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PHONGHOC_PH_MA = new SelectList(db.PHONGHOCs, "PH_MA", "PH_TEN", cOSOVATCHAT.PHONGHOC_PH_MA);
            ViewBag.THIETBIDAYHOC_TBDH_MA = new SelectList(db.THIETBIDAYHOCs, "TBDH_MA", "TBDH_TEN", cOSOVATCHAT.THIETBIDAYHOC_TBDH_MA);
            ViewBag.THIETBIGIANGDAY_TBGD_MA = new SelectList(db.THIETBIGIANGDAYs, "TBGD_MA", "TBGD_TEN", cOSOVATCHAT.THIETBIGIANGDAY_TBGD_MA);
            ViewBag.TINHTRANG_TT_MA = new SelectList(db.TINHTRANGs, "TT_MA", "TT_MOTA", cOSOVATCHAT.TINHTRANG_TT_MA);
            return View(cOSOVATCHAT);
        }

        // GET: COSOVATCHATs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COSOVATCHAT cOSOVATCHAT = db.COSOVATCHATs.Find(id);
            if (cOSOVATCHAT == null)
            {
                return HttpNotFound();
            }
            return View(cOSOVATCHAT);
        }

        // POST: COSOVATCHATs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            COSOVATCHAT cOSOVATCHAT = db.COSOVATCHATs.Find(id);
            db.COSOVATCHATs.Remove(cOSOVATCHAT);
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
