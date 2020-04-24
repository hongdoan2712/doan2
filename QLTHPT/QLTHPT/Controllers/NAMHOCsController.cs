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
    public class NAMHOCsController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: NAMHOCs
        public ActionResult Index()
        {
            return View(db.NAMHOCs.ToList());
        }

        // GET: NAMHOCs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NAMHOC nAMHOC = db.NAMHOCs.Find(id);
            if (nAMHOC == null)
            {
                return HttpNotFound();
            }
            return View(nAMHOC);
        }

        // GET: NAMHOCs/Create
        public ActionResult Create()
        {
            NAMHOC obj = new NAMHOC();
            obj.NH_MA = CreateID.CreateID_ByteText();
            return View(obj);
        }

        // POST: NAMHOCs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NH_MA,NH_NAMHOC")] NAMHOC nAMHOC)
        {
            if (ModelState.IsValid)
            {
                db.NAMHOCs.Add(nAMHOC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nAMHOC);
        }

        // GET: NAMHOCs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NAMHOC nAMHOC = db.NAMHOCs.Find(id);
            if (nAMHOC == null)
            {
                return HttpNotFound();
            }
            return View(nAMHOC);
        }

        // POST: NAMHOCs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NH_MA,NH_NAMHOC")] NAMHOC nAMHOC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nAMHOC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nAMHOC);
        }

        // GET: NAMHOCs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NAMHOC nAMHOC = db.NAMHOCs.Find(id);
            if (nAMHOC == null)
            {
                return HttpNotFound();
            }
            return View(nAMHOC);
        }

        // POST: NAMHOCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NAMHOC nAMHOC = db.NAMHOCs.Find(id);
            db.NAMHOCs.Remove(nAMHOC);
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
