using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WarehouseMVC.Infrastructure;
using WarehouseMVC.Infrastructure.Atributes;
using WarehouseMVC.Models.Forms;
using WarehouseMVC_DAL.Models;
using WarehouseMVC_DAL.Repositories;

namespace WarehouseMVC.Controllers
{
    public class ReceptionController : Controller
    {
        private ReceptionRepository _repo = new ReceptionRepository();
        private StockRepository _repoConfirmed = new StockRepository();
        private ArticleRepository _repoArticle = new ArticleRepository();

        // GET: Reception ------------------------------------------------------------------- Liste des réceptions
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "ReceptionId_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.ArticleNomSortParm = sortOrder == "ArticleNom" ? "ArticleNom_desc" : "ArticleNom";
            ViewBag.CategorieNomSortParm = sortOrder == "CategorieNom" ? "CategorieNom_desc" : "CategorieNom";
            ViewBag.FournisseurNomSortParm = sortOrder == "FournisseurNom" ? "FournisseurNom_desc" : "FournisseurNom";
            ViewBag.QuantiteSortParm = sortOrder == "Quantite" ? "Quantite_desc" : "Quantite";


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

            IEnumerable<Reception> listreception = _repo.Get();
            switch (sortOrder)
            {
                case "ReceptionId_desc":
                    listreception = listreception.OrderByDescending(s => s.ReceptionId);
                    break;
                case "Date":
                    listreception = listreception.OrderBy(s => s.Date);
                    break;
                case "Date_desc":
                    listreception = listreception.OrderByDescending(s => s.Date);
                    break;
                case "ArticleNom":
                    listreception = listreception.OrderBy(s => s.ArticleNom);
                    break;
                case "ArticleNom_desc":
                    listreception = listreception.OrderByDescending(s => s.ArticleNom);
                    break;
                case "CategorieNom":
                    listreception = listreception.OrderBy(s => s.CategorieNom);
                    break;
                case "CategorieNom_desc":
                    listreception = listreception.OrderByDescending(s => s.CategorieNom);
                    break;
                case "FournisseurNom":
                    listreception = listreception.OrderBy(s => s.FournisseurNom);
                    break;
                case "FournisseurNom_desc":
                    listreception = listreception.OrderByDescending(s => s.FournisseurNom);
                    break;
                case "Quantite":
                    listreception = listreception.OrderBy(s => s.Quantite);
                    break;
                case "Quantite_desc":
                    listreception = listreception.OrderByDescending(s => s.Quantite);
                    break;
                default:
                    listreception = listreception.OrderBy(s => s.ReceptionId);
                    break;
            }
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(listreception.ToPagedList(pageNumber, pageSize));
        }

        // GET: Reception/Details/5 ------------------------------------------------- Détail de la réception
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Details(int id)
        {
            Reception entity = _repo.Get(id);
            return View(entity);
        }

        // GET: Reception/Create ---------------------------------------------------- Créer une nouvelle reception - appel du formulaire
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Create(int id)
        {
            ReceptionCreationForm form = new ReceptionCreationForm();           
            Article entity = _repoArticle.Get(id);
            form.ArticleId = id;
            form.ArticleNom = entity.Nom;
            form.CategorieId = entity.CategorieId;
            form.CategorieNom = entity.CategorieNom;
            return View(form);
        }

        // POST: Reception/Create ---------------------------------------------------- Créer une nouvelle reception - envoi du formulaire
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        [HttpPost]
        public ActionResult Create(int id, Reception form)
        {
            if (ModelState.IsValid)
            {
                form.UtilisateurId = SessionManager.Utilisateur.UtilisateurId;
                form.ArticleId = id;
                _repo.Insert(form);
            }
            return RedirectToAction("Index");
        }

        // GET: Reception/Edit/5 ---------------------------------------------------- Modifier une reception - Get du client et appel du formulaire
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Edit(int id)
        {
            Reception entity = _repo.Get(id);
            return View(entity);
        }

        // POST: Reception/Edit/5 ---------------------------------------------------- Modifier une reception - envoi du formulaire
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        [HttpPost]
        public ActionResult Edit(int id, Reception form)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(id, form);
            }
            return RedirectToAction("Index");
        }

        // GET: Reception/Delete/5 -------------------------------------------------- Supprimer une reception - Get de la reception
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Delete(int id)
        {
            Reception entity = _repo.Get(id);
            return View(entity);
        }

        // POST: Reception/Delete/5 -------------------------------------------------- Supprimer une reception - Confirmation de suppression
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        [HttpPost]
        public ActionResult Delete(int id, Reception entity)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }

        // POST: Reception/ConfirmReception ------------------------------------------ Confirmer une reception - Get de la reception et appel du formulaire
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        [HttpGet]
        public ActionResult ConfirmReception(int id)
        {
            Reception entity = _repo.Get(id);
            return View(entity);
        }

        // POST: Reception/ConfirmReception ----------------------------------------- Confirmer une reception - Get de la reception et envoi du formulaire
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        [HttpPost]
        public ActionResult ConfirmReception(int id, ConfirmedReception form)
        {
            if (ModelState.IsValid)
            {
                Reception entity = _repo.Get(id);
                form.FournisseurNom = entity.FournisseurNom;
                form.FournisseurNumTva = entity.FournisseurNumTva;
                form.FournisseurRue = entity.FournisseurRue;
                form.FournisseurNumero = entity.FournisseurNumero;
                form.FournisseurCodePostal = entity.FournisseurCodePostal;
                form.FournisseurVille = entity.FournisseurVille;
                form.FournisseurPays = entity.FournisseurPays;
                form.ArticleNom = entity.ArticleNom;
                form.UtilisateurId = entity.UtilisateurId;
                form.UtilisateurNom = entity.UtilisateurNom + " " + entity.UtilisateurPrenom;
                form.ReceptionId = entity.ReceptionId;
                _repoConfirmed.ConfirmReception(form);
            }
            return RedirectToAction("Index");
        }
    }
}
