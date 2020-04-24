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
    public class THIETBIDAYHOCsController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: THIETBIDAYHOCs
        public ActionResult Index()
        {
            return View(db.THIETBIDAYHOCs.ToList());
        }

        // GET: THIETBIDAYHOCs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THIETBIDAYHOC tHIETBIDAYHOC = db.THIETBIDAYHOCs.Find(id);
            if (tHIETBIDAYHOC == null)
            {
                return HttpNotFound();
            }
            return View(tHIETBIDAYHOC);
        }

        // GET: THIETBIDAYHOCs/Create
        public ActionResult Create()
        {
            THIETBIDAYHOC obj = new THIETBIDAYHOC();
            obj.TBDH_MA = CreateID.CreateID_ByteText();
            return View(obj);
        }

        // POST: THIETBIDAYHOCs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TBDH_MA,TBDH_TEN")] THIETBIDAYHOC tHIETBIDAYHOC)
        {
            if (ModelState.IsValid)
            {
                db.THIETBIDAYHOCs.Add(tHIETBIDAYHOC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tHIETBIDAYHOC);
        }

        // GET: THIETBIDAYHOCs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THIETBIDAYHOC tHIETBIDAYHOC = db.THIETBIDAYHOCs.Find(id);
            if (tHIETBIDAYHOC == null)
            {
                return HttpNotFound();
            }
            return View(tHIETBIDAYHOC);
        }

        // POST: THIETBIDAYHOCs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TBDH_MA,TBDH_TEN")] THIETBIDAYHOC tHIETBIDAYHOC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHIETBIDAYHOC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tHIETBIDAYHOC);
        }

        // GET: THIETBIDAYHOCs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THIETBIDAYHOC tHIETBIDAYHOC = db.THIETBIDAYHOCs.Find(id);
            if (tHIETBIDAYHOC == null)
            {
                return HttpNotFound();
            }
            return View(tHIETBIDAYHOC);
        }

        // POST: THIETBIDAYHOCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            THIETBIDAYHOC tHIETBIDAYHOC = db.THIETBIDAYHOCs.Find(id);
            db.THIETBIDAYHOCs.Remove(tHIETBIDAYHOC);
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
