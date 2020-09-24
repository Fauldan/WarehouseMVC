﻿using System;
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

        // GET: Article
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Index()
        {
            return View(_repo.Get());
        }

        // GET: Article/Details/5
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

        // GET: Article/Create
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Create()
        {
            ArticleCreationForm form = new ArticleCreationForm();
            return View(form);
        }

        // POST: Article/Create
        [HttpPost]
        public ActionResult Create(Article form)
        {
            if (ModelState.IsValid)
            {
                _repo.Insert(form);
            }
            return RedirectToAction("Index");
        }

        // GET: Article/Edit/5
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Edit(int id)
        {
            Article entity = _repo.Get(id);
            if (entity is null) { return RedirectToAction("Index"); }
            return View(entity);
        }

        // POST: Article/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Article form)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(id, form);
            }
            return RedirectToAction("Index");
        }

        // GET: Article/Delete/5
        [HttpGet]
        [AuthorizeManager(UtilisateurRole.ADMIN | UtilisateurRole.USER)]
        public ActionResult Delete(int id)
        {
            Article entity = _repo.Get(id);
            return View(entity);
        }

        // POST: Article/Delete/5
        public ActionResult Delete(int id, Article entity)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }


        [AuthorizeManager(UtilisateurRole.ADMIN)]
        public ActionResult Secret()
        {
            return View();
        }
    }
}
