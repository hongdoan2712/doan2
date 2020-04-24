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
    public class COQUANsController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: COQUANs
        public ActionResult Index()
        {
            return View(db.COQUANs.ToList());
        }

        // GET: COQUANs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COQUAN cOQUAN = db.COQUANs.Find(id);
            if (cOQUAN == null)
            {
                return HttpNotFound();
            }
            return View(cOQUAN);
        }

        // GET: COQUANs/Create
        public ActionResult Create()
        {
            COQUAN obj = new COQUAN();
            obj.CQ_MA = CreateID.CreateID_ByteText();
            return View(obj);
        }

        // POST: COQUANs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CQ_MA,CQ_TEN")] COQUAN cOQUAN)
        {
            if (ModelState.IsValid)
            {
                db.COQUANs.Add(cOQUAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cOQUAN);
        }

        // GET: COQUANs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COQUAN cOQUAN = db.COQUANs.Find(id);
            if (cOQUAN == null)
            {
                return HttpNotFound();
            }
            return View(cOQUAN);
        }

        // POST: COQUANs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CQ_MA,CQ_TEN")] COQUAN cOQUAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOQUAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cOQUAN);
        }

        // GET: COQUANs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COQUAN cOQUAN = db.COQUANs.Find(id);
            if (cOQUAN == null)
            {
                return HttpNotFound();
            }
            return View(cOQUAN);
        }

        // POST: COQUANs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            COQUAN cOQUAN = db.COQUANs.Find(id);
            db.COQUANs.Remove(cOQUAN);
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
