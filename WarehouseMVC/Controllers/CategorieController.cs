using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WarehouseMVC.Infrastructure.Atributes;
using WarehouseMVC.Models.Forms;
using WarehouseMVC_DAL.Models;
using WarehouseMVC_DAL.Repositories;

namespace WarehouseMVC.Controllers
{
    public class CategorieController : Controller
    {
        private CategorieRepository _repo = new CategorieRepository();

        // GET: Categorie
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Index()
        {
            return View(_repo.Get());
        }

        // GET: Categorie/Details/5
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Details(int id)
        {
            Categorie entity = _repo.Get(id);
            return View(entity);
        }

        // GET: Categorie/Create
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Create()
        {
            CategorieCreationForm form = new CategorieCreationForm();
            return View(form);
        }

        // POST: Categorie/Create
        [HttpPost]
        public ActionResult Create(Categorie form)
        {
            if (ModelState.IsValid)
            {
                _repo.Insert(form);
            }
            return RedirectToAction("Index");
        }

        // GET: Categorie/Edit/5
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Edit(int id)
        {
            Categorie entity = _repo.Get(id);
            if (entity is null) { return RedirectToAction("Index"); }
            return View(entity);
        }

        // POST: Categorie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Categorie form)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(id, form);
            }
            return RedirectToAction("Index");
        }

        // GET: Categorie/Delete/5
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Delete(int id)
        {
            Categorie entity = _repo.Get(id);
            return View(entity);
        }

        // POST: Categorie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Categorie entity)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
