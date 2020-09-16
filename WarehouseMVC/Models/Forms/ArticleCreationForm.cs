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
    public class ArticleCreationForm
    {
        private FournisseurRepository _fournisseurRepo = new FournisseurRepository();
        private CategorieRepository _categorieRepo = new CategorieRepository();
        
        [DisplayName("Nom de l'article :")]
        [Required]
        [MinLength(3)]
        public string Nom { get; set; }

        [DisplayName("Prix d'achat :")]
        [Required]
        public float PrixAchat { get; set; }

        [DisplayName("Prix de vente :")]
        [Required]
        public float PrixVente { get; set; }

        [DisplayName("Id Fournisseur :")]
        [Required]
        public int FournisseurId { get; set; }

        [DisplayName("Id Catégorie :")]
        [Required]
        public int CategorieId { get; set; }

        public IEnumerable<Fournisseur> ListFournisseur { get => _fournisseurRepo.Get(); }
        public IEnumerable<Categorie> ListCategorie { get => _categorieRepo.Get(); }
    }
}