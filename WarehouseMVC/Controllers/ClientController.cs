using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WarehouseMVC.Models.Forms;
using WarehouseMVC_DAL.Models;
using WarehouseMVC_DAL.Repositories;

namespace WarehouseMVC.Controllers
{
    public class ClientController : Controller
    {
        ClientRepository _repo = new ClientRepository();
        // GET: Client
        public ActionResult Index()
        {
            return View(_repo.Get());
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            Client entity = _repo.Get(id);
            return View(entity);
        }

        // GET: Client/Create
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
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Client entity = _repo.Get(id);
            if (entity is null) { return RedirectToAction("Index"); }
            return View(entity);
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Client form)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(id, form);
            }
            return RedirectToAction("Index");
        }

        // GET: Client/Delete/5
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
