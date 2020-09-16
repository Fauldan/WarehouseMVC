using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WarehouseMVC.Models.Forms;
using WarehouseMVC_DAL.Models;
using WarehouseMVC_DAL.Repositories;
using WarehouseMVC.Infrastructure;

namespace WarehouseMVC.Controllers
{
    public class AuthController : Controller
    {
        private AuthRepository _repo = new AuthRepository();

        // GET: Auth
        public ActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginForm form)
        {
            if (ModelState.IsValid)
            {               
                SessionManager.Utilisateur = _repo.Login(form.Login, form.Password);
            }
            return RedirectToAction("Index","Home");
        }

        public ActionResult Logout()
        {
            SessionManager.Abandon();
            return RedirectToAction("Index");
        }



        // GET: Auth/Create
        public ActionResult Register()
        {
                RegisterForm form = new RegisterForm();
                return View(form);
        }

        // POST: Auth/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Utilisateur form)
        {
            if (ModelState.IsValid)
            {
                _repo.Register(form);
            }
            return RedirectToAction("Index");
        }

        // GET: Auth/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Auth/Edit/5
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

        // GET: Auth/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Auth/Delete/5
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
