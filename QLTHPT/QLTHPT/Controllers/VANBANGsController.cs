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
    public class VANBANGsController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: VANBANGs
        public ActionResult Index()
        {
            return View(db.VANBANGs.ToList());
        }

        // GET: VANBANGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VANBANG vANBANG = db.VANBANGs.Find(id);
            if (vANBANG == null)
            {
                return HttpNotFound();
            }
            return View(vANBANG);
        }

        // GET: VANBANGs/Create
        public ActionResult Create()
        {
            VANBANG obj = new VANBANG();
            obj.VB_MA = CreateID.CreateID_ByteText();
            return View(obj);
        }

        // POST: VANBANGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VB_MA,VB_TEN")] VANBANG vANBANG)
        {
            if (ModelState.IsValid)
            {
                db.VANBANGs.Add(vANBANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vANBANG);
        }

        // GET: VANBANGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VANBANG vANBANG = db.VANBANGs.Find(id);
            if (vANBANG == null)
            {
                return HttpNotFound();
            }
            return View(vANBANG);
        }

        // POST: VANBANGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VB_MA,VB_TEN")] VANBANG vANBANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vANBANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vANBANG);
        }

        // GET: VANBANGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VANBANG vANBANG = db.VANBANGs.Find(id);
            if (vANBANG == null)
            {
                return HttpNotFound();
            }
            return View(vANBANG);
        }

        // POST: VANBANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            VANBANG vANBANG = db.VANBANGs.Find(id);
            db.VANBANGs.Remove(vANBANG);
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
