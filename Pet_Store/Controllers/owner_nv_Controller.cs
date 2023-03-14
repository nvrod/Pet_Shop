using Pet_Store.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pet_Store.Controllers
{
    public class owner_nv_Controller : Controller
    {
        // GET: owner_nv_
        public ActionResult Index_client()
        {
            List<owner_nv_CLS> ownerList = null;

            using ( var bd = new analysts_dbEntities())
            {
                ownerList = (from owner_nv in bd.owner_nv
                             join code in bd.client_type_nv on owner_nv.client_type_id equals code.id
                             where owner_nv.is_active == true
                             select new owner_nv_CLS
                             {
                                 Id = owner_nv.id,
                                 owner_national_id = (int)owner_nv.owner_national_id,
                                 owner_name = owner_nv.owner_name,
                                 owner_email = owner_nv.owner_email,
                                 owner_phone_number = owner_nv.owner_phone_number,
                                 client_type_name = code.client_type
                             }
                            ).ToList();
            }
                return View(ownerList);
        }


        // GET: owner_nv_/Create
        public ActionResult Create_client()
        {
            listOwnerType();
            ViewBag.List = listType;
            return View();
        }

        // POST: owner_nv_/Create
        [HttpPost]
        public ActionResult Create_client(owner_nv_CLS iowner_nv_CLS)
        {
            if (!ModelState.IsValid)
            {
                listOwnerType();
                ViewBag.List = listType;
                return View(iowner_nv_CLS);
            }

            else
            {
                using (var bd = new analysts_dbEntities())
                {
                    owner_nv iowner_nv = new owner_nv();
                    iowner_nv.owner_national_id = iowner_nv_CLS.owner_national_id;
                    iowner_nv.owner_name = iowner_nv_CLS.owner_name;
                    iowner_nv.owner_phone_number = iowner_nv_CLS.owner_phone_number;
                    iowner_nv.owner_email = iowner_nv_CLS.owner_email;
                    iowner_nv.client_type_id = iowner_nv_CLS.client_type_id;
                    iowner_nv.is_active = true;
                    bd.owner_nv.Add(iowner_nv);
                    bd.SaveChanges();
                }
            }
            return RedirectToAction("index_client");
        }

        List<SelectListItem> listType;
        private void listOwnerType()
        {
            using (var bd = new analysts_dbEntities())
            {
                listType = (from clientType in bd.client_type_nv
                            where clientType.is_active == true
                            select new SelectListItem
                            {
                                Text = clientType.client_type,
                                Value = SqlFunctions.StringConvert((decimal)clientType.id),
                            }).ToList(); 
            }
        }

            // GET: owner_nv_/Edit/5
            public ActionResult Edit_client(int id_)
        {
            owner_nv_CLS eowner_nv_CLS = new owner_nv_CLS();
            using (var bd = new analysts_dbEntities())
            {
                listOwnerType();
                ViewBag.List = listType;
                owner_nv eOwner = bd.owner_nv.Where(p => p.id.Equals(id_)).First();
                eowner_nv_CLS.Id = eOwner.id;
                eowner_nv_CLS.owner_name = eOwner.owner_name;
                eowner_nv_CLS.owner_phone_number = eOwner.owner_phone_number;
                eowner_nv_CLS.client_type_id = (int)eOwner.client_type_id;
                eowner_nv_CLS.owner_email = eOwner.owner_email;
                eowner_nv_CLS.owner_national_id = (int)eOwner.owner_national_id;
            }
            return View(eowner_nv_CLS);
        }

        // POST: owner_nv_/Edit/5
        [HttpPost]
        public ActionResult Edit_client( owner_nv_CLS iowner_nv_CLS)
        {

            if (!ModelState.IsValid) {
                listOwnerType();
                ViewBag.List = listType;
                return View(iowner_nv_CLS);
            }
            else
            {
                var id_edit = iowner_nv_CLS.Id;
                using (var bd = new analysts_dbEntities())
                {
                    listOwnerType();
                    ViewBag.List = listType;
                    owner_nv eOwner = bd.owner_nv.Where(p => p.id.Equals(id_edit)).First();
                    eOwner.owner_name = iowner_nv_CLS.owner_name;
                    eOwner.owner_phone_number = iowner_nv_CLS.owner_phone_number;
                    eOwner.owner_email = iowner_nv_CLS.owner_email;
                    eOwner.client_type_id = iowner_nv_CLS.client_type_id;
                    eOwner.owner_national_id = iowner_nv_CLS.owner_national_id;

                    eOwner.is_active = true;
                    bd.SaveChanges();
                }

            }

            return RedirectToAction("Index_client");
        }


        // POST: owner_nv_/Delete/5

        public ActionResult Delete(int id_)
        {
            using (var bd = new analysts_dbEntities())
            {
                owner_nv dOwner_nv = bd.owner_nv.Where(p => p.id.Equals(id_)).First();
                dOwner_nv.is_active = false;
                bd.SaveChanges();
            }

            return RedirectToAction("Index_client");
        }
    }
}
