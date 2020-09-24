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
    public class Article
    {
        private CategorieRepository _categorieRepo = new CategorieRepository();
        private StockRepository _stockRepo = new StockRepository();
        private FournisseurRepository _fournisseurRepo = new FournisseurRepository();

        [DisplayName("N° Article")]
        [Required]
        public int ArticleId { get; set; }

        [DisplayName("Nom de l'Article")]
        [StringLength(50, MinimumLength = 5)]
        public string Nom { get; set; }

        [DisplayName("Prix d'achat")]
        [Range(0, 10000)]
        [Required]
        public float PrixAchat { get; set; }

        [DisplayName("Prix de vente")]
        [Range(0, 10000)]
        [Required]
        public float PrixVente { get; set; }

        [DisplayName("N° Catégorie")]
        [Required]
        public int CategorieId { get; set; }

        [DisplayName("Catégorie")]
        public string CategorieNom { get; set; }

        public IEnumerable<Categorie> ListCategorie { get => _categorieRepo.Get(); }
        public Stock StockTotal { get => _stockRepo.GetStockArticle(ArticleId); }
        public IEnumerable<Fournisseur> ListFournisseur { get => _fournisseurRepo.GetByArticle(ArticleId); }
    }
}

