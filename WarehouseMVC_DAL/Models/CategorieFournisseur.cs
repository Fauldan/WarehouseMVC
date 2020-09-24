using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMVC_DAL.Repositories;

namespace WarehouseMVC_DAL.Models
{
    public class CategorieFournisseur
    {
        private CategorieRepository _categorieRepo = new CategorieRepository();
        public IEnumerable<Categorie> ListCategorie { get => _categorieRepo.GetCategorie_By_Fournisseur(FournisseurId); }
        public int CategorieId { get; set; }
        public int FournisseurId { get; set; }
        public string CategorieNom { get; set; }
    }
}
