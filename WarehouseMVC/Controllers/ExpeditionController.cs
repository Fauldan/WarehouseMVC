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
        private StockRepository _repoConfirmed = new StockRepository();

        // GET: Expedition
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Index()
        {
            return View(_repo.Get());
        }

        // GET: Expedition/Details/5
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Details(int id)
        {
            Expedition entity = _repo.Get(id);
            return View(entity);
        }

        // GET: Expedition/Create
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Create()
        {
            ExpeditionCreationForm form = new ExpeditionCreationForm();
            return View(form);
        }

        // POST: Expedition/Create
        [HttpPost]
        public ActionResult Create(Expedition form)
        {
            if (ModelState.IsValid)
            {
                form.UtilisateurId = SessionManager.Utilisateur.UtilisateurId;
                _repo.Insert(form);
            }
            return RedirectToAction("Index");
        }

        // GET: Expedition/Edit/5
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Edit(int id)
        {
            Expedition entity = _repo.Get(id);
            return View(entity);
        }

        // POST: Expedition/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Expedition form)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(id, form);
            }
            return RedirectToAction("Index");
        }

        // GET: Expedition/Delete/5
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Delete(int id)
        {
            Expedition entity = _repo.Get(id);
            return View(entity);
        }

        // POST: Expedition/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Expedition entity)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }

        // GET: Expedition/ConfirmReception
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        [HttpGet]
        public ActionResult ConfirmExpedition(int id)
        {
            Expedition entity = _repo.Get(id);
            return View(entity);
        }

        // POST: Expedition/ConfirmExpedition
        [HttpPost]
        public ActionResult ConfirmExpedition(int id, ConfirmedExpedition form)
        {
                Expedition entity = _repo.Get(id);
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
                _repoConfirmed.ConfirmExpedition(form);
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
