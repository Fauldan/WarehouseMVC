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
    public class ArticleController : Controller
    {
        private ArticleRepository _repo = new ArticleRepository();
        private StockRepository _repoStock = new StockRepository();

        // GET: ------------------------------------------------------------------- Liste des articles
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Index()
        {
            return View(_repo.Get());
        }

        // GET: Article/Details/5 ------------------------------------------------- Détail de l'article
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Details(int id)
        {
            Stock stock = _repoStock.GetStockArticle(id);
            if (stock is null)
            { ViewBag.Stock = 0; }
            else { ViewBag.Stock = stock.TotalStock; }
            Article entity = _repo.Get(id);
            return View(entity);
        }

        // GET: Article/Create ---------------------------------------------------- Créer un nouvel article - appel du formulaire
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Create()
        {
            ArticleCreationForm form = new ArticleCreationForm();
            return View(form);
        }

        // POST: Article/Create --------------------------------------------------- Créer un nouvel article - envoi du formulaire       
        [HttpPost]
        public ActionResult Create(Article form)
        {
            if (ModelState.IsValid)
            {
                _repo.Insert(form);
            }
            return RedirectToAction("Index");
        }

        // GET: Article/Edit/5 ---------------------------------------------------- Modifier un article - Get de l'article et appel du formulaire
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Edit(int id)
        {
            Article entity = _repo.Get(id);
            if (entity is null) { return RedirectToAction("Index"); }
            return View(entity);
        }

        // POST: Article/Edit/5 --------------------------------------------------- Modifier un article - envoi du formulaire
        [HttpPost]
        public ActionResult Edit(int id, Article form)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(id, form);
            }
            return RedirectToAction("Index");
        }

        // GET: Article/Delete/5 -------------------------------------------------- Supprimer un article - Get de l'article
        [HttpGet]
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Delete(int id)
        {
            Article entity = _repo.Get(id);
            return View(entity);
        }

        // POST: Article/Delete/5 ------------------------------------------------- Supprimer un article - Confirmation de suppression
        public ActionResult Delete(int id, Article entity)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }


        // Zone ADMIN en Test  

        //[AuthorizeManager(UtilisateurRole.ADMIN)]
        //public ActionResult Secret()
        //{
        //    return View();
        //}
    }
}
