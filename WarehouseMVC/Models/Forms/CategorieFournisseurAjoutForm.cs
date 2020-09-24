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
    public class CategorieFournisseurAjoutForm
    {
        [DisplayName("Catégorie(s) disponible(s)")]
        [Required]
        public int CategorieId { get; set; }

        [DisplayName("Catégorie")]
        [Required]
        public string CategorieNom { get; set; }

        [DisplayName("N° Fournisseur")]
        [Required]
        public int FournisseurId { get; set; }

        [DisplayName("Fournisseur")]
        [Required]
        public string FournisseurNom { get; set; }

        private CategorieRepository _categorieRepo = new CategorieRepository();
        public IEnumerable<Categorie> ListCategorie { get => _categorieRepo.Get(); }
        public IEnumerable<Categorie> ListCategorieFournisseur { get => _categorieRepo.GetCategorie_By_Fournisseur(FournisseurId); }
        public IEnumerable<Categorie> ListAjoutCategorieFournisseur { get => _categorieRepo.GetCategorie_NotIn_Fournisseur(FournisseurId); }
    }
}