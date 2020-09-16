using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMVC_DAL.Repositories;

namespace WarehouseMVC_DAL.Models
{
    public class Reception
    {
        private ArticleRepository _articleRepo = new ArticleRepository();
        private AuthRepository _authRepo = new AuthRepository();
        private FournisseurRepository _fournisseurRepo = new FournisseurRepository();

        public int ReceptionId { get; set; }
        public string FournisseurNom { get; set; }
        public int FournisseurNumTva { get; set; }
        public string FournisseurRue { get; set; }
        public int FournisseurNumero { get; set; }
        public int FournisseurCodePostal { get; set; }
        public string FournisseurVille { get; set; }
        public string FournisseurPays { get; set; }
        public int FournisseurId { get; set; }
        public int ArticleId { get; set; }
        public string ArticleNom { get; set; }
        public int UtilisateurId { get; set; }
        public string UtilisateurNom { get; set; }
        public int Quantite { get; set; }
        public string Date { get; set; }

        public IEnumerable<Article> ListArticle { get => _articleRepo.Get(); }
        public IEnumerable<Utilisateur> ListUtilisateur { get => _authRepo.Get(); }
        public IEnumerable<Fournisseur> ListFournisseur { get => _fournisseurRepo.Get(); }
    }
}
