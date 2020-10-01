using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WarehouseMVC_DAL.Models;
using WarehouseMVC_DAL.Repositories;


namespace WarehouseMVC.Models.Forms
{
    public class ExpeditionCreationForm
    {
        private ArticleRepository _articleRepo = new ArticleRepository();
        private CategorieRepository _categorieRepo = new CategorieRepository();
        private UtilisateurRepository _utilisateurRepo = new UtilisateurRepository();
        private ClientRepository _clientRepo = new ClientRepository();

        [DisplayName("Id article")]
        [Required]
        public int ArticleId { get; set; }

        [DisplayName("Quantité expédiée :")]
        [Range(0, 10000)]
        [Required]
        public int Quantite { get; set; }

        [DisplayName("Id Catégorie")]
        [Required]
        public int CategorieId { get; set; }

        [DisplayName("Id Client :")]
        [Required]
        public int ClientId { get; set; }

        [DisplayName("Id Utilisateur :")]
        [Required]
        public int UtilisateurId { get; set; }

        public string ArticleNom { get; set; }
        public string CategorieNom { get; set; }

        public IEnumerable<Article> ListArticle { get => _articleRepo.Get(); }
        public IEnumerable<Categorie> ListCategorie { get => _categorieRepo.Get(); }
        public IEnumerable<Utilisateur> ListUtilisateur { get => _utilisateurRepo.Get(); }
        public IEnumerable<Client> ListClient { get => _clientRepo.Get(); }
    }
}