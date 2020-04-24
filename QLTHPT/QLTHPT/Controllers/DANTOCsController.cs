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
    public class DANTOCsController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: DANTOCs
        public ActionResult Index()
        {
            return View(db.DANTOCs.ToList());
        }

        // GET: DANTOCs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANTOC dANTOC = db.DANTOCs.Find(id);
            if (dANTOC == null)
            {
                return HttpNotFound();
            }
            return View(dANTOC);
        }

        // GET: DANTOCs/Create
        public ActionResult Create()
        {
            DANTOC obj = new DANTOC();
            obj.DT_MA = CreateID.CreateID_ByteText();
            return View(obj);
        }

        // POST: DANTOCs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DT_MA,DT_TEN")] DANTOC dANTOC)
        {
            if (ModelState.IsValid)
            {
                db.DANTOCs.Add(dANTOC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dANTOC);
        }

        // GET: DANTOCs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANTOC dANTOC = db.DANTOCs.Find(id);
            if (dANTOC == null)
            {
                return HttpNotFound();
            }
            return View(dANTOC);
        }

        // POST: DANTOCs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DT_MA,DT_TEN")] DANTOC dANTOC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dANTOC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dANTOC);
        }

        // GET: DANTOCs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANTOC dANTOC = db.DANTOCs.Find(id);
            if (dANTOC == null)
            {
                return HttpNotFound();
            }
            return View(dANTOC);
        }

        // POST: DANTOCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DANTOC dANTOC = db.DANTOCs.Find(id);
            db.DANTOCs.Remove(dANTOC);
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
