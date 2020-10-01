using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WarehouseMVC.Infrastructure.Atributes;
using WarehouseMVC.Models.Forms;
using WarehouseMVC_DAL.Models;
using WarehouseMVC_DAL.Repositories;
using PagedList;

namespace WarehouseMVC.Controllers
{
    public class StockController : Controller
    {
        private ArticleRepository _repoArticle = new ArticleRepository();
        private StockRepository _repo = new StockRepository();

        // GET: Stock --------------------------------------------------------------------------------- Liste des lignes de stock
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "StockId" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.ActiviteSortParm = sortOrder == "Activite" ? "activite_desc" : "Activite";
            ViewBag.ArticleIdSortParm = sortOrder == "ArticleId" ? "articleId_desc" : "ArticleId";
            ViewBag.ArticleSortParm = sortOrder == "Article" ? "article_desc" : "Article";
            ViewBag.QuantiteSortParm = sortOrder == "Quantite" ? "quantite_desc" : "Quantite";
            ViewBag.StockSortParm = sortOrder == "Stock" ? "stock_desc" : "Stock";
            ViewBag.UtilisateurSortParm = sortOrder == "Utilisateur" ? "utilisateur_desc" : "Utilisateur";

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

            IEnumerable<Stock> liststock = _repo.Get();
            switch (sortOrder)
            {
                case "StockId":
                    liststock = liststock.OrderBy(s => s.StockId);
                    break;
                case "Date":
                    liststock = liststock.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    liststock = liststock.OrderByDescending(s => s.Date);
                    break; 
                case "Activite":
                    liststock = liststock.OrderBy(s => s.Activite);
                    break;
                case "activite_desc":
                    liststock = liststock.OrderByDescending(s => s.Activite);
                    break; 
                case "ArticleId":
                    liststock = liststock.OrderBy(s => s.ArticleId);
                    break;
                case "articleId_desc":
                    liststock = liststock.OrderByDescending(s => s.ArticleId);
                    break;
                case "Article":
                    liststock = liststock.OrderBy(s => s.ArticleNom);
                    break;
                case "article_desc":
                    liststock = liststock.OrderByDescending(s => s.ArticleNom);
                    break;
                case "Quantite":
                    liststock = liststock.OrderBy(s => s.Quantite);
                    break;
                case "quantite_desc":
                    liststock = liststock.OrderByDescending(s => s.Quantite);
                    break;
                case "Stock":
                    liststock = liststock.OrderBy(s => s.TotalStock);
                    break;
                case "stock_desc":
                    liststock = liststock.OrderByDescending(s => s.TotalStock);
                    break;
                case "Utilisateur":
                    liststock = liststock.OrderBy(s => s.UtilisateurNom);
                    break;
                case "utilisateur_desc":
                    liststock = liststock.OrderByDescending(s => s.UtilisateurNom);
                    break;
                default:
                    liststock = liststock.OrderByDescending(s => s.StockId);
                    break;
            }

            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(liststock.ToPagedList(pageNumber, pageSize));
        }

        // GET: Stock/Details/5 ----------------------------------------------------------------------- Détail d'une ligne de stock - NOT IMPLEMENTED YET
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Stock/GetStockArticle/5 --------------------------------------------------------------- Récupérer le stock total d'un article - Get de l'article
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult GetStockArticle(int id)
        {
            Stock entity = _repo.GetStockArticle(id);
            return View(entity);
        }

        //  -------------------------------------------------------------------------------------------- Liste des lignes de stock pour un article
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult GetMoveStock_By_ArticleId(int id, string sortOrder, string currentFilter, string searchString, int? page)
        {
            Article entity = _repoArticle.Get(id);
            ViewBag.ArticleRef = "Article n° " + entity.ArticleId + " - " + entity.Nom;
            ViewBag.BoutonRetour = ($"/Article/Details/{id}");
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
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(_repo.GetMoveStock_By_ArticleId(id).ToPagedList(pageNumber, pageSize));
        }


        // GET: Stock/Edit/5 ------------------------------------------------------------------------------ Corrections d'inventaire - appel du formulaire
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult GetStockInventaire()
        {
            return View(_repo.GetStockInventaire());
        }

        // POST: Stock/Edit/5 ------------------------------------------------------------------------------ Corrections d'inventaire - envoi du formulaire
        [HttpPost]
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Edit()
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Article");
            }
            catch
            {
                return View("Article");
            }
        }
    }
}
