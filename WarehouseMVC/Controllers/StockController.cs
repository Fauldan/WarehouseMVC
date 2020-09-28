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
            return View(_repo.Get().ToPagedList(pageNumber, pageSize));
        }

        // GET: Stock/Details/5 ----------------------------------------------------------------------- Détail d'une ligne de stock - NOT IMPLEMENTED YET
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Stock/GetStockArticle/5 --------------------------------------------------------------- Récupérer le stock total d'un article - Get de l'article
        public ActionResult GetStockArticle(int id)
        {
            Stock entity = _repo.GetStockArticle(id);
            return View(entity);
        }

        //  -------------------------------------------------------------------------------------------- Liste des lignes de stock pour un article
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

        
        
        
        
        
        
        
        
        
        
        
        
        // --------------------------------------------------- part of the CRUD not in use ---------------------------------------------
        
        // GET: Stock/Create
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stock/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Stock/Edit/5
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Stock/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Stock/Delete/5
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Stock/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
