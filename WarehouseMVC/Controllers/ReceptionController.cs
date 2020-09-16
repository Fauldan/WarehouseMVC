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
        private ConfirmedReceptionRepository _repoConfirmed = new ConfirmedReceptionRepository();

        // GET: Reception
        public ActionResult Index()
        {
            string a = SessionManager.Utilisateur.Role.ToString();
            if (a == "ADMIN")
            {
                return View(_repo.Get());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Reception/Details/5
        public ActionResult Details(int id)
        {
            Reception entity = _repo.Get(id);
            return View(entity);
        }

        // GET: Reception/Create
        public ActionResult Create()
        {
            ReceptionCreationForm form = new ReceptionCreationForm();
            return View(form);
        }

        // POST: Reception/Create
        [HttpPost]
        public ActionResult Create(Reception form)
        {
            if (ModelState.IsValid)
            {
                form.Date = DateTime.Now.ToString("dd/MM/yyyy");
                form.UtilisateurId = SessionManager.Utilisateur.UtilisateurId;
                _repo.Insert(form);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ConfirmReception(int id)
        {
            Reception entity = new Reception();
            entity = _repo.Get(id);
            return View(entity);
        }

        // POST: Reception/Create
        [HttpPost]
        public ActionResult ConfirmReception(ConfirmedReception form)
        {

            if (ModelState.IsValid)
            {
                _repoConfirmed.ConfirmReception(form);
                _repo.Delete(form.ReceptionId);
            }
            return RedirectToAction("Index");
        }

        // GET: Reception/Edit/5
        public ActionResult Edit(int id)
        {
            Reception entity = _repo.Get(id);
            return View(entity);
        }

        // POST: Reception/Edit/5
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
