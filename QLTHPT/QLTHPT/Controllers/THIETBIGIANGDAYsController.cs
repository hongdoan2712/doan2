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
    public class THIETBIGIANGDAYsController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: THIETBIGIANGDAYs
        public ActionResult Index()
        {
            return View(db.THIETBIGIANGDAYs.ToList());
        }

        // GET: THIETBIGIANGDAYs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THIETBIGIANGDAY tHIETBIGIANGDAY = db.THIETBIGIANGDAYs.Find(id);
            if (tHIETBIGIANGDAY == null)
            {
                return HttpNotFound();
            }
            return View(tHIETBIGIANGDAY);
        }

        // GET: THIETBIGIANGDAYs/Create
        public ActionResult Create()
        {
            THIETBIGIANGDAY obj = new THIETBIGIANGDAY();
            obj.TBGD_MA = CreateID.CreateID_ByteText();
            return View(obj);
        }

        // POST: THIETBIGIANGDAYs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TBGD_MA,TBGD_TEN")] THIETBIGIANGDAY tHIETBIGIANGDAY)
        {
            if (ModelState.IsValid)
            {
                db.THIETBIGIANGDAYs.Add(tHIETBIGIANGDAY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tHIETBIGIANGDAY);
        }

        // GET: THIETBIGIANGDAYs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THIETBIGIANGDAY tHIETBIGIANGDAY = db.THIETBIGIANGDAYs.Find(id);
            if (tHIETBIGIANGDAY == null)
            {
                return HttpNotFound();
            }
            return View(tHIETBIGIANGDAY);
        }

        // POST: THIETBIGIANGDAYs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TBGD_MA,TBGD_TEN")] THIETBIGIANGDAY tHIETBIGIANGDAY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHIETBIGIANGDAY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tHIETBIGIANGDAY);
        }

        // GET: THIETBIGIANGDAYs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THIETBIGIANGDAY tHIETBIGIANGDAY = db.THIETBIGIANGDAYs.Find(id);
            if (tHIETBIGIANGDAY == null)
            {
                return HttpNotFound();
            }
            return View(tHIETBIGIANGDAY);
        }

        // POST: THIETBIGIANGDAYs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            THIETBIGIANGDAY tHIETBIGIANGDAY = db.THIETBIGIANGDAYs.Find(id);
            db.THIETBIGIANGDAYs.Remove(tHIETBIGIANGDAY);
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
