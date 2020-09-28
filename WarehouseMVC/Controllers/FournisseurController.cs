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
    public class FournisseurController : Controller
    {
        FournisseurRepository _repo = new FournisseurRepository();
        CategorieFournisseurRepository _repoCategorieFournisseur = new CategorieFournisseurRepository();

        // GET: ----------------------------------------------------------------------- Listes des fournisseurs
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Index()
        {
            return View(_repo.Get());
        }

        // GET: Fournisseur/Details/5 ------------------------------------------------- Détail du fournisseur
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Details(int id)
        {
            ViewBag.BoutonRetour = ($"/Article");
            Fournisseur entity = _repo.Get(id);
            return View(entity);
        }

        // GET: Fournisseur/Create ---------------------------------------------------- Créer un nouveau fournisseur - appel du formulaire
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Create()
        {
            FournisseurCreationForm form = new FournisseurCreationForm();
            return View(form);
        }

        // POST: Fournisseur/Create --------------------------------------------------- Créer un nouveau fournisseur - envoi du formulaire  
        [HttpPost]
        public ActionResult Create(Fournisseur form)
        {
            if (ModelState.IsValid)
            {
                _repo.Insert(form);
            }
            return RedirectToAction("Index");
        }

        // GET: Fournisseur/AjoutCategorieFournisseur --------------------------------- Ajouter une catégorie au fournisseur - appel du formulaire
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult AjoutCategorieFournisseur(int id)
        {
            CategorieFournisseurAjoutForm form = new CategorieFournisseurAjoutForm();
            Fournisseur entity = _repo.Get(id);           
            form.FournisseurId = id;
            form.FournisseurNom = entity.Nom;
            ViewBag.BoutonRetour = ($"/Fournisseur/Details?id={id}");
            return View(form);
        }

        // POST: Fournisseur/AjoutCategorieFournisseur -------------------------------- Ajouter une catégorie au fournisseur - envoi du formulaire
        [HttpPost]
        public ActionResult AjoutCategorieFournisseur(CategorieFournisseur form)
        {
            if (ModelState.IsValid)
            {
                _repoCategorieFournisseur.Insert(form);
            }
            return RedirectToAction("Index");
        }

        // GET: Fournisseur/Edit/5 ---------------------------------------------------- Modifier un fournisseur     - appel du formulaire
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Edit(int id)
        {
            Fournisseur entity = _repo.Get(id);
            if (entity is null) { return RedirectToAction("Index"); }
            return View(entity);
        }

        // POST: Fournisseur/Edit/5 ---------------------------------------------------- Modifier un fournisseur    - envoi du formulaire
        [HttpPost]
        public ActionResult Edit(int id, Fournisseur form)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(id, form);
            }
            return RedirectToAction("Index");
        }

        // GET: Fournisseur/Delete/5 -------------------------------------------------- Supprimer un Fournisseur - appel du formulaire
        [HttpGet]
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Delete(int id)
        {
            Fournisseur entity = _repo.Get(id);
            return View(entity);
        }

        // POST: Founrisseur/Delete/5 -------------------------------------------------- Supprimer un Fournisseur - confirmation de suppression
        public ActionResult Delete(int id, Fournisseur entity)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
