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
    public class TIETHOCsController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: TIETHOCs
        public ActionResult Index()
        {
            return View(db.TIETHOCs.ToList());
        }

        // GET: TIETHOCs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIETHOC tIETHOC = db.TIETHOCs.Find(id);
            if (tIETHOC == null)
            {
                return HttpNotFound();
            }
            return View(tIETHOC);
        }

        // GET: TIETHOCs/Create
        public ActionResult Create()
        {
            TIETHOC obj = new TIETHOC();
            obj.TH_MA = CreateID.CreateID_ByteText();
            return View(obj);
        }

        // POST: TIETHOCs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TH_MA,TH_TEN")] TIETHOC tIETHOC)
        {
            if (ModelState.IsValid)
            {
                db.TIETHOCs.Add(tIETHOC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIETHOC);
        }

        // GET: TIETHOCs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIETHOC tIETHOC = db.TIETHOCs.Find(id);
            if (tIETHOC == null)
            {
                return HttpNotFound();
            }
            return View(tIETHOC);
        }

        // POST: TIETHOCs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TH_MA,TH_TEN")] TIETHOC tIETHOC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIETHOC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIETHOC);
        }

        // GET: TIETHOCs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIETHOC tIETHOC = db.TIETHOCs.Find(id);
            if (tIETHOC == null)
            {
                return HttpNotFound();
            }
            return View(tIETHOC);
        }

        // POST: TIETHOCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TIETHOC tIETHOC = db.TIETHOCs.Find(id);
            db.TIETHOCs.Remove(tIETHOC);
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
