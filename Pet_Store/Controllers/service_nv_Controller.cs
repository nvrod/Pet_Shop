using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pet_Store.Models;

namespace Pet_Store.Controllers
{
    public class service_nv_Controller : Controller
    {
        private analysts_dbEntities db = new analysts_dbEntities();

        // GET: service_nv_
        public ActionResult Index_service()
        {
            var service_nv = db.service_nv.Include(s => s.employee_nv).Include(s => s.pet_nv).Include(s => s.service_type_nv)
                .Where(s => s.is_active == true);

            return View(service_nv.ToList());
        }

        // GET: service_nv_/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            service_nv service_nv = db.service_nv.Find(id);
            if (service_nv == null)
            {
                return HttpNotFound();
            }
            return View(service_nv);
        }

        // GET: service_nv_/Create
        public ActionResult Create_service()
        {
            ViewBag.employee_id = new SelectList(db.employee_nv, "id", "employee_name");
            ViewBag.pet_id = new SelectList(db.pet_nv, "id", "pet_name");
            ViewBag.service_type_id = new SelectList(db.service_type_nv, "id", "service_type");
            return View();
        }

        // POST: service_nv_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_service([Bind(Include = "id,service_type_id,service_date,employee_id,pet_id,is_active")] service_nv service_nv)
        {
            if (ModelState.IsValid)
            {
                db.service_nv.Add(service_nv);
                db.SaveChanges();
                return RedirectToAction("Index_service");
            }

            ViewBag.employee_id = new SelectList(db.employee_nv, "id", "employee_name", service_nv.employee_id);
            ViewBag.pet_id = new SelectList(db.pet_nv, "id", "pet_name", service_nv.pet_id);
            ViewBag.service_type_id = new SelectList(db.service_type_nv, "id", "service_type", service_nv.service_type_id);
            return View(service_nv);
        }

        // GET: service_nv_/Edit/5
        public ActionResult Edit_service(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            service_nv service_nv = db.service_nv.Find(id);
            if (service_nv == null)
            {
                return HttpNotFound();
            }
            ViewBag.employee_id = new SelectList(db.employee_nv, "id", "employee_name", service_nv.employee_id);
            ViewBag.pet_id = new SelectList(db.pet_nv, "id", "pet_name", service_nv.pet_id);
            ViewBag.service_type_id = new SelectList(db.service_type_nv, "id", "service_type", service_nv.service_type_id);
            return View(service_nv);
        }

        // POST: service_nv_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_service([Bind(Include = "id,service_type_id,service_date,employee_id,pet_id,is_active")] service_nv service_nv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service_nv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index_service");   
            }
            ViewBag.employee_id = new SelectList(db.employee_nv, "id", "employee_name", service_nv.employee_id);
            ViewBag.pet_id = new SelectList(db.pet_nv, "id", "pet_name", service_nv.pet_id);
            ViewBag.service_type_id = new SelectList(db.service_type_nv, "id", "service_type", service_nv.service_type_id);
            return View(service_nv);
        }


        // POST: service_nv_/Delete/5

        public ActionResult Delete_service(int id)
        {
            service_nv service_nv = db.service_nv.Find(id);
            service_nv.is_active = false;
            db.SaveChanges();
            return RedirectToAction("Index_service");
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
