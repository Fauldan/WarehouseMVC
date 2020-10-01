using PagedList;
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

        // GET: Client ------------------------------------------------------------------- Liste des clients
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "clientId_desc" : "";
            ViewBag.NomSortParm = sortOrder == "Nom" ? "nom_desc" : "Nom";
            ViewBag.NomSocieteSortParm = sortOrder == "NomSociete" ? "nomSociete_desc" : "NomSociete";
            ViewBag.VilleSortParm = sortOrder == "Ville" ? "ville_desc" : "Ville";

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

            IEnumerable<Client> listclient = _repo.Get();
            switch (sortOrder)
            {
                case "clientId_desc":
                    listclient = listclient.OrderByDescending(s => s.ClientId);
                    break;
                case "Nom":
                    listclient = listclient.OrderBy(s => s.Nom);
                    break;
                case "nom_desc":
                    listclient = listclient.OrderByDescending(s => s.Nom);
                    break;
                case "NomSociete":
                    listclient = listclient.OrderBy(s => s.NomSociete);
                    break;
                case "nomSocietee_desc":
                    listclient = listclient.OrderByDescending(s => s.NomSociete);
                    break;
                case "Ville":
                    listclient = listclient.OrderBy(s => s.Ville);
                    break;
                case "ville_desc":
                    listclient = listclient.OrderByDescending(s => s.Ville);
                    break;
                default:
                    listclient = listclient.OrderBy(s => s.ClientId);
                    break;
            }
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(listclient.ToPagedList(pageNumber, pageSize));
        }

        // GET: Client/Details/5 ------------------------------------------------- Détail du client
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Details(int id)
        {
            Client entity = _repo.Get(id);
            return View(entity);
        }

        // GET: Client/Create ---------------------------------------------------- Créer un nouveau client - appel du formulaire
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Create()
        {
            ClientCreationForm form = new ClientCreationForm();
            return View(form);
        }

        // POST: Client/Create ---------------------------------------------------- Créer un nouveau client - envoi du formulaire
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        [HttpPost]
        public ActionResult Create(Client form)
        {
            if (ModelState.IsValid)
            {
                _repo.Insert(form);
            }
            return RedirectToAction("Index");
        }

        // GET: Client/Edit/5 ---------------------------------------------------- Modifier un client - Get du client et appel du formulaire
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Client entity = _repo.Get(id);
            if (entity is null) { return RedirectToAction("Index"); }
            return View(entity);
        }

        // POST: Client/Edit/5 ---------------------------------------------------- Modifier un client - envoi du formulaire
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        [HttpPost]
        public ActionResult Edit(int clientId, Client form)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(clientId, form);
            }
            return RedirectToAction("Index");
        }

        // GET: Client/Delete/5 -------------------------------------------------- Supprimer un client - Get du client
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Client entity = _repo.Get(id);
            return View(entity);
        }

        // POST: Client/Delete/5 ------------------------------------------------- Supprimer un client - Confirmation de suppression
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Delete(int id, Client entity)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
