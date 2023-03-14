using Pet_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pet_Store.Controllers
{
    public class employee_nv_Controller : Controller
    {
        // GET: employee_nv_
        public ActionResult Index_employee()
        {
            List<employee_nv_CLS> employeeList = null;
            using (var bd = new analysts_dbEntities())
            {
                employeeList = (from employee in bd.employee_nv
                                where employee.is_active == true
                                select new employee_nv_CLS
                                {
                                    Id = employee.id,
                                    employee_national_id = (int)employee.employee_national_id,
                                    employee_name = employee.employee_name,
                                }
                            ).ToList();
            }
                return View(employeeList);
        }



        // GET: employee_nv_/Create
        public ActionResult Create_employee()
        {
            return View();
        }

        // POST: employee_nv_/Create
        [HttpPost]
        public ActionResult Create_employee(employee_nv_CLS cEmployee_nv_CLS)
        {
            if (!ModelState.IsValid)
            {
                return View(cEmployee_nv_CLS);
            }

            else
            {
                using (var bd = new analysts_dbEntities())
                {
                    employee_nv cEmployee_nv = new employee_nv();
                    cEmployee_nv.employee_name = cEmployee_nv_CLS.employee_name;
                    cEmployee_nv.employee_national_id = cEmployee_nv_CLS.employee_national_id;
                    cEmployee_nv.is_active = true;
                    bd.employee_nv.Add(cEmployee_nv);
                    bd.SaveChanges();
                }
            }
            return RedirectToAction("index_employee");
        }

        // GET: employee_nv_/Edit/5
        public ActionResult Edit_employee(int id_)
        {
            employee_nv_CLS eEmployee_nv_CLS = new employee_nv_CLS();
            using (var bd = new analysts_dbEntities())
            {
                employee_nv eEmployee = bd.employee_nv.Where(p => p.id.Equals(id_)).First();
                eEmployee_nv_CLS.Id = eEmployee.id;
                eEmployee_nv_CLS.employee_name = eEmployee.employee_name;
                eEmployee_nv_CLS.employee_national_id = (int)eEmployee.employee_national_id;
            }
                return View(eEmployee_nv_CLS);
        }

        // POST: employee_nv_/Edit/5
        [HttpPost]
        public ActionResult Edit_employee( employee_nv_CLS eEmployee_nv_CLS)
        {
            if (!ModelState.IsValid)
            {
                return View(eEmployee_nv_CLS);
            }
            else
            {
                var id_edit = eEmployee_nv_CLS.Id;
                using (var bd = new analysts_dbEntities())
                {

                    employee_nv eEmployee = bd.employee_nv.Where(p => p.id.Equals(id_edit)).First();
                    eEmployee.employee_name = eEmployee_nv_CLS.employee_name;
                    eEmployee.employee_national_id = eEmployee_nv_CLS.employee_national_id;
                    eEmployee.is_active = true;
                    bd.SaveChanges();
                }

            }

            return RedirectToAction("Index_employee");
        }



        // POST: employee_nv_/Delete/5
        public ActionResult Delete_employee(int id_)
        {
            using (var bd = new analysts_dbEntities())
            {
                employee_nv dEmployee_nv = bd.employee_nv.Where(p => p.id.Equals(id_)).First();
                dEmployee_nv.is_active = false;
                bd.SaveChanges();
            }

            return RedirectToAction("Index_employee");
        }
    }
}
