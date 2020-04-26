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
    public class THUsController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: THUs
        public ActionResult Index()
        {
            return View(db.THUs.ToList());
        }

        // GET: THUs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THU tHU = db.THUs.Find(id);
            if (tHU == null)
            {
                return HttpNotFound();
            }
            return View(tHU);
        }

        // GET: THUs/Create
        public ActionResult Create()
        {
            THU obj = new THU();
            obj.THU_MA = CreateID.CreateID_ByteText();
            return View(obj);
        }

        // POST: THUs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "THU_MA,THU_TEN")] THU tHU)
        {
            if (ModelState.IsValid)
            {
                db.THUs.Add(tHU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tHU);
        }

        // GET: THUs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THU tHU = db.THUs.Find(id);
            if (tHU == null)
            {
                return HttpNotFound();
            }
            return View(tHU);
        }

        // POST: THUs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "THU_MA,THU_TEN")] THU tHU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tHU);
        }

        // GET: THUs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THU tHU = db.THUs.Find(id);
            if (tHU == null)
            {
                return HttpNotFound();
            }
            return View(tHU);
        }

        // POST: THUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            THU tHU = db.THUs.Find(id);
            db.THUs.Remove(tHU);
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
