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
    public class ExpeditionController : Controller
    {
        private ExpeditionRepository _repo = new ExpeditionRepository();
        private StockRepository _repoStock = new StockRepository();
        private ArticleRepository _repoArticle = new ArticleRepository();

        // GET: Expedition ------------------------------------------------------------------- Liste des expeditions
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "expeditionId_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.ArticleNomSortParm = sortOrder == "ArticleNom" ? "ArticleNom_desc" : "ArticleNom";
            ViewBag.CategorieNomSortParm = sortOrder == "CategorieNom" ? "CategorieNom_desc" : "CategorieNom";
            ViewBag.ClientNomSortParm = sortOrder == "ClientNom" ? "ClientNom_desc" : "ClientNom";
            ViewBag.ClientNomSocieteSortParm = sortOrder == "ClientNomSociete" ? "ClientNomSociete_desc" : "ClientNomSociete";
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

            IEnumerable<Expedition> listexpedition = _repo.Get();
            switch (sortOrder)
            {
                case "expeditionId_desc":
                    listexpedition = listexpedition.OrderByDescending(s => s.ArticleId);
                    break;
                case "Date":
                    listexpedition = listexpedition.OrderBy(s => s.Date);
                    break;
                case "Date_desc":
                    listexpedition = listexpedition.OrderByDescending(s => s.Date);
                    break;
                case "ArticleNom":
                    listexpedition = listexpedition.OrderBy(s => s.ArticleNom);
                    break;
                case "ArticleNom_desc":
                    listexpedition = listexpedition.OrderByDescending(s => s.ArticleNom);
                    break;
                case "CategorieNom":
                    listexpedition = listexpedition.OrderBy(s => s.CategorieNom);
                    break;
                case "CategorieNom_desc":
                    listexpedition = listexpedition.OrderByDescending(s => s.CategorieNom);
                    break;
                case "ClientNom":
                    listexpedition = listexpedition.OrderBy(s => s.ClientNom);
                    break;
                case "ClientNom_desc":
                    listexpedition = listexpedition.OrderByDescending(s => s.ClientNom);
                    break;
                case "ClientNomSociete":
                    listexpedition = listexpedition.OrderBy(s => s.ClientNomSociete);
                    break;
                case "ClientNomSociete_desc":
                    listexpedition = listexpedition.OrderByDescending(s => s.ClientNomSociete);
                    break;
                case "Quantite":
                    listexpedition = listexpedition.OrderBy(s => s.Quantite);
                    break;
                case "Quantite_desc":
                    listexpedition = listexpedition.OrderByDescending(s => s.Quantite);
                    break;
                default:
                    listexpedition = listexpedition.OrderBy(s => s.ExpeditionId);
                    break;
            }
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(listexpedition.ToPagedList(pageNumber, pageSize));
        }

        // GET: Expedition/Details/5 ------------------------------------------------- Détail de l'expedition
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Details(int id)
        {
            Expedition entity = _repo.Get(id);
            return View(entity);
        }

        // GET: Expedition/Create ---------------------------------------------------- Créer une nouvelle expedition - appel du formulaire
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Create(int id)
        {
            ExpeditionCreationForm form = new ExpeditionCreationForm();
            Article entity = _repoArticle.Get(id);
            form.ArticleId = id;
            form.ArticleNom = entity.Nom;
            form.CategorieId = entity.CategorieId;
            form.CategorieNom = entity.CategorieNom; 
            return View(form);
        }

        // POST: Expedition/Create ---------------------------------------------------- Créer une nouvelle expedition - envoi du formulaire
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        [HttpPost]
        public ActionResult Create(int id, Expedition form)
        {
            Stock stock = _repoStock.GetStockArticle(id);
            form.ArticleNom = stock.ArticleNom;
            if (stock.TotalStock < form.Quantite)
            {
                return RedirectToAction("Create");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    form.UtilisateurId = SessionManager.Utilisateur.UtilisateurId;
                    form.ArticleId = id;
                    _repo.Insert(form);
                }
                return RedirectToAction("Index");
            }          
        }

        // GET: Expedition/Edit/5 ---------------------------------------------------- Modifier une expedition - Get du client et appel du formulaire
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Edit(int id)
        {
            Expedition entity = _repo.Get(id);
            return View(entity);
        }

        // POST: Expedition/Edit/5 ---------------------------------------------------- Modifier une expedition - envoi du formulaire
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        [HttpPost]
        public ActionResult Edit(int id, Expedition form)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(id, form);
            }
            return RedirectToAction("Index");
        }

        // GET: Expedition/Delete/5 -------------------------------------------------- Supprimer une expedition - Get de l'expedition
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Delete(int id)
        {
            Expedition entity = _repo.Get(id);
            return View(entity);
        }

        // POST: Expedition/Delete/5 -------------------------------------------------- Supprimer une expedition - Confirmation de suppression
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        [HttpPost]
        public ActionResult Delete(int id, Expedition entity)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }

        // GET: Expedition/ConfirmExpedition ------------------------------------------ Confirmer une expedition - Get de l'expedition et appel du formulaire
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        [HttpGet]
        public ActionResult ConfirmExpedition(int id)
        {
            Expedition entity = _repo.Get(id);
            return View(entity);
        }

        // POST: Expedition/ConfirmExpedition ----------------------------------------- Confirmer une expedition - Get de l'expedition et envoi du formulaire
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        [HttpPost]
        public ActionResult ConfirmExpedition(int id, ConfirmedExpedition form)
        {
            Expedition entity = _repo.Get(id);
            form.ArticleId = entity.ArticleId;
            form.ArticleNom = entity.ArticleNom;
            form.ClientNumTva = entity.ClientNumTva;
            form.ClientRue = entity.ClientRue;
            form.ClientNumero = entity.ClientNumero;
            form.ClientCodePostal = entity.ClientCodePostal;
            form.ClientVille = entity.ClientVille;
            form.ClientPays = entity.ClientPays;
            form.ClientNom = entity.ClientNom;
            form.ClientPrenom = entity.ClientPrenom;
            form.ClientNomSociete = entity.ClientNomSociete;
            form.UtilisateurNom = entity.UtilisateurNom + " " + entity.UtilisateurPrenom;
            form.ExpeditionId = entity.ExpeditionId;
            form.CategorieId = entity.CategorieId;
            form.CategorieNom = entity.CategorieNom;
            form.Quantite = entity.Quantite;
            form.UtilisateurId = entity.UtilisateurId;
            _repoStock.ConfirmExpedition(form);
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
