using PagedList;
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

        // GET: ------------------------------------------------------------------- Liste des Catégories
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "categorieId_desc" : "";
            ViewBag.NomSortParm = sortOrder == "Nom" ? "nom_desc" : "Nom";

            ViewBag.CurrentSort = sortOrder;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            IEnumerable<Categorie> listcategorie = _repo.Get();
            switch (sortOrder)
            {
                case "categorieId_desc":
                    listcategorie = listcategorie.OrderByDescending(s => s.CategorieId);
                    break;
                case "Nom":
                    listcategorie = listcategorie.OrderBy(s => s.Nom);
                    break;
                case "nom_desc":
                    listcategorie = listcategorie.OrderByDescending(s => s.Nom);
                    break;
                default:
                    listcategorie = listcategorie.OrderBy(s => s.CategorieId);
                    break;
            }
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(listcategorie.ToPagedList(pageNumber, pageSize));
        }

        // GET: Categorie/Details/5 ------------------------------------------------- Détail de la catégorie
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Details(int id)
        {
            Categorie entity = _repo.Get(id);
            return View(entity);
        }

        // GET: Categorie/Create ---------------------------------------------------- Créer une nouvellle catégorie - appel du formulaire
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Create()
        {
            CategorieCreationForm form = new CategorieCreationForm();
            return View(form);
        }

        // POST: Categorie/Create ---------------------------------------------------- Créer une nouvellle catégorie - envoi du formulaire
        [HttpPost]
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Create(Categorie form)
        {
            if (ModelState.IsValid)
            {
                _repo.Insert(form);
            }
            return RedirectToAction("Index");
        }

        // GET: Categorie/Edit/5 ---------------------------------------------------- Modifier une catégorie - Get de l'article et appel du formulaire
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Edit(int id)
        {
            Categorie entity = _repo.Get(id);
            if (entity is null) { return RedirectToAction("Index"); }
            return View(entity);
        }

        // POST: Categorie/Edit/5 ---------------------------------------------------- Modifier une catégorie - envoi du formulaire
        [HttpPost]
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Edit(int id, Categorie form)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(id, form);
            }
            return RedirectToAction("Index");
        }

        // GET: Categorie/Delete/5 -------------------------------------------------- Supprimer un catégorie - Get de la catégorie
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Delete(int id)
        {
            Categorie entity = _repo.Get(id);
            return View(entity);
        }

        // POST: Categorie/Delete/5 ------------------------------------------------- Supprimer une catégorie - Confirmation de suppression
        [HttpPost]
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Delete(int id, Categorie entity)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
