using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        [DisplayName("N°")]
        public int ReceptionId { get; set; }

        [DisplayName("N° Article")]
        [Required]
        public int ArticleId { get; set; }

        [DisplayName("Fournisseur")]
        public string FournisseurNom { get; set; }

        [DisplayName("Numéro TVA")]
        public int FournisseurNumTva { get; set; }

        [DisplayName("Rue")]
        public string FournisseurRue { get; set; }

        [DisplayName("Numéro")]
        public int FournisseurNumero { get; set; }

        [DisplayName("Code postal")]
        public int FournisseurCodePostal { get; set; }

        [DisplayName("Ville")]
        public string FournisseurVille { get; set; }

        [DisplayName("Pays")]
        public string FournisseurPays { get; set; }

        [DisplayName("N° Fournisseur")]
        [Required]
        public int FournisseurId { get; set; }

        [DisplayName("Article")]
        public string ArticleNom { get; set; }

        [DisplayName("ID Utilisateur")]
        [Required]
        public int UtilisateurId { get; set; }

        [DisplayName("Utilisateur")]
        public string UtilisateurNom { get; set; }
        
        public string UtilisateurPrenom { get; set; }

        [DisplayName("Catégorie")]
        public string CategorieNom { get; set; }

        [DisplayName("N° Catégorie")]
        public int CategorieId { get; set; }

        [DisplayName("Quantité")]
        [Required]
        public int Quantite { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public IEnumerable<Article> ListArticle { get => _articleRepo.Get(); }
        public IEnumerable<Utilisateur> ListUtilisateur { get => _authRepo.Get(); }
        public IEnumerable<Fournisseur> ListFournisseur { get => _fournisseurRepo.GetByArticle(ArticleId); }
    }
}
