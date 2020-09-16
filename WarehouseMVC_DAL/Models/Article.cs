using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMVC_DAL.Repositories;

namespace WarehouseMVC_DAL.Models
{
    public class Article
    {
        private FournisseurRepository _fournisseurRepo = new FournisseurRepository();
        private CategorieRepository _categorieRepo = new CategorieRepository();

        public int ArticleId { get; set; }
        public string Nom { get; set; }
        public int Quantite { get; set; }
        public float PrixAchat { get; set; }
        public float PrixVente { get; set; }
        public int FournisseurId { get; set; }
        public int CategorieId { get; set; }
        public string CategorieNom { get; set; }
        public string FournisseurNom { get; set; }
        public IEnumerable<Fournisseur> ListFournisseur { get => _fournisseurRepo.Get(); }
        public IEnumerable<Categorie> ListCategorie { get => _categorieRepo.Get(); }
    }
}

