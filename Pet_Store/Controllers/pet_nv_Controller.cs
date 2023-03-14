using Pet_Store.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pet_Store.Controllers
{
    public class pet_nv_Controller : Controller
    {
        // GET: pet_nv_
        public ActionResult Index_pet()
        {
            List<pet_nv_CLS> petList = null;

            using (var bd = new analysts_dbEntities())
            {
                petList = (from pet in bd.pet_nv
                           join code in bd.pet_type_nv on pet.pet_type_id equals code.id
                           join owner in bd.owner_nv on pet.owner_id equals owner.id
                           where pet.is_active == true
                             select new pet_nv_CLS
                             {
                                 Id = pet.id,
                                 pet_name = pet.pet_name,
                                 pet_age_in_months = (int)pet.pet_age_in_months,
                                 owner_name = owner.owner_name,
                                 pet_type_name = code.pet_type,
                                 pet_type_id = (int)pet.pet_type_id,
                             }
                            ).ToList();
            }
            return View(petList);
        }




        // GET: pet_nv_/Create
        public ActionResult Create_pet()
        {
            listPetType();
            listOwner();
            ViewBag.List_one = listType_one;
            ViewBag.List_pets = listType_pets;
            return View();
        }

        // POST: pet_nv_/Create
        [HttpPost]
        public ActionResult Create_pet(pet_nv_CLS cPet_nv_CLS)
        {
            if (!ModelState.IsValid)
            {
                listPetType();
                listOwner();
                ViewBag.List = listType_pets;
                ViewBag.List_one = listType_one;
                return View(cPet_nv_CLS);
            }

            else
            {
                using (var bd = new analysts_dbEntities())
                {
                    listPetType();
                    listOwner();
                    ViewBag.List = listType_pets;
                    ViewBag.List_one = listType_one;
                    pet_nv cPet_nv = new pet_nv();
                    cPet_nv.pet_name = cPet_nv_CLS.pet_name;
                    cPet_nv.pet_age_in_months = cPet_nv_CLS.pet_age_in_months;
                    cPet_nv.pet_type_id = cPet_nv_CLS.pet_type_id;
                    cPet_nv.owner_id = cPet_nv_CLS.owner_id;
                    cPet_nv.is_active = true;
                    bd.pet_nv.Add(cPet_nv);
                    bd.SaveChanges();
                }
            }
            return RedirectToAction("index_pet");
        }

        List<SelectListItem> listType_pets;
        private void listPetType()
        {
            using (var bd = new analysts_dbEntities())
            {
                listType_pets = (from petType in bd.pet_type_nv
                            where petType.is_active == true
                            select new SelectListItem
                            {
                                Text = petType.pet_type,
                                Value = SqlFunctions.StringConvert((decimal)petType.id),
                            }).ToList();
            }
        }

        List<SelectListItem> listType_one;
        private void listOwner()
        {
            using (var bd = new analysts_dbEntities())
            {
                listType_one = (from ownerType in bd.owner_nv
                            where ownerType.is_active == true
                            select new SelectListItem
                            {
                                Text = ownerType.owner_name,
                                Value = SqlFunctions.StringConvert((decimal)ownerType.id),
                            }).ToList();
            }
        }
        // GET: owner_nv_/Edit/5
        public ActionResult Edit_pet(int id_)
        {
            pet_nv_CLS ePet_nv_CLS = new pet_nv_CLS(); 
            using (var bd = new analysts_dbEntities())
            {
                listPetType();
                listOwner();
                ViewBag.List_pets = listType_pets;
                ViewBag.List_one = listType_one;
                pet_nv ePet = bd.pet_nv.Where(p => p.id.Equals(id_)).First();
                ePet_nv_CLS.Id = ePet.id;
                ePet_nv_CLS.pet_name = ePet.pet_name;
                ePet_nv_CLS.pet_age_in_months = (int)ePet.pet_age_in_months;
                ePet_nv_CLS.owner_id = (int)ePet.owner_id;
            }
            return View(ePet_nv_CLS);
        }

        // POST: pet_nv_/Edit/5
        [HttpPost]
        public ActionResult Edit_pet(int id_, pet_nv_CLS ePet_nv_CLS)
        {
            if (!ModelState.IsValid)
            {
                listPetType();
                listOwner();
                ViewBag.List_pets = listType_pets;
                ViewBag.List_one = listType_one;
                return View(ePet_nv_CLS);
            }

            else
            {
                var id_edit = ePet_nv_CLS.Id;
                using (var bd = new analysts_dbEntities())
                {
                    listPetType();
                    listOwner();
                    ViewBag.List_pets = listType_pets;
                    ViewBag.List_one = listType_one;
                    pet_nv ePet = bd.pet_nv.Where(p => p.id.Equals(id_edit)).First();
                    ePet.pet_name = ePet_nv_CLS.pet_name;
                    ePet.pet_age_in_months = ePet.pet_age_in_months;
                    ePet.pet_type_id = ePet_nv_CLS.pet_type_id;
                    ePet.is_active = true;
                    bd.SaveChanges();

                }

            }

            return RedirectToAction("Index_pet");
        }


        // POST: pet_nv_/Delete/5

        public ActionResult Delete_pet(int id_)
        {
            using (var bd = new analysts_dbEntities())
            {
                pet_nv dPet_nv = bd.pet_nv.Where(p => p.id.Equals(id_)).First();
                dPet_nv.is_active = false;
                bd.SaveChanges();
            }

            return RedirectToAction("Index_pet");
        }
    }
}
