using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMVC_DAL.Models
{
    public class Utilisateur
    {
        public int UtilisateurId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UtilisateurRole Role { get; set; }
        public string NumTel { get; set; }
        public string Rue { get; set; }
        public int Numero { get; set; }
        public int CodePostal { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
    }
    [Flags]
    public enum UtilisateurRole
    {
        USER = 1,
        ADMIN = 2
    }
}
