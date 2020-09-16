using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarehouseMVC_DAL.Models;

namespace WarehouseMVC.Infrastructure
{
    public class SessionManager
    {
        public static Utilisateur Utilisateur
        {
            get { return (Utilisateur)HttpContext.Current.Session[nameof(Utilisateur)]; }
            set { HttpContext.Current.Session[nameof(Utilisateur)] = value; }
        }
        public static bool IsAdmin
        {
            get { return Utilisateur.Role.HasFlag(UtilisateurRole.ADMIN); }
        }
        public static void Abandon()
        {
            HttpContext.Current.Session.Abandon();
        }
    }
}