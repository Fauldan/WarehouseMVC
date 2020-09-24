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
    public class ClientController : Controller
    {
        ClientRepository _repo = new ClientRepository();
        // GET: Client
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Index()
        {
            return View(_repo.Get());
        }

        // GET: Client/Details/5
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Details(int id)
        {
            Client entity = _repo.Get(id);
            return View(entity);
        }

        // GET: Client/Create
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Create()
        {
            ClientCreationForm form = new ClientCreationForm();
            return View(form);
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(Client form)
        {
            if (ModelState.IsValid)
            {
                _repo.Insert(form);
            }
            return RedirectToAction("Index");
        }

        // GET: Client/Edit/5
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Client entity = _repo.Get(id);
            if (entity is null) { return RedirectToAction("Index"); }
            return View(entity);
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(int clientId, Client form)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(clientId, form);
            }
            return RedirectToAction("Index");
        }

        // GET: Client/Delete/5
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Client entity = _repo.Get(id);
            return View(entity);
        }

        // POST: Client/Delete/5
        public ActionResult Delete(int id, Client entity)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
