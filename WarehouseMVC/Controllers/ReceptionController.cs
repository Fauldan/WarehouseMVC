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

        // GET: Reception
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Index()
        {
            //if (SessionManager.Utilisateur != null)
            //{
            //    if (SessionManager.IsAdmin)
            //    {
                    return View(_repo.Get());
            //    }
            //}
            //return RedirectToAction("Index", "Home");
        }

        // GET: Reception/Details/5
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Details(int id)
        {
            Reception entity = _repo.Get(id);
            return View(entity);
        }

        // GET: Reception/Create
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

        // POST: Reception/Create
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

        // POST: Reception/ConfirmReception
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        [HttpGet]
        public ActionResult ConfirmReception(int id)
        {
            Reception entity = _repo.Get(id);
            return View(entity);
        }

        // POST: Reception/ConfirmReception
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

        // GET: Reception/Edit/5
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Edit(int id)
        {
            Reception entity = _repo.Get(id);
            return View(entity);
        }

        // POST: Reception/Edit/5
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

        // GET: Reception/Delete/5
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Delete(int id)
        {
            Reception entity = _repo.Get(id);
            return View(entity);
        }

        // POST: Reception/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Reception entity)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
