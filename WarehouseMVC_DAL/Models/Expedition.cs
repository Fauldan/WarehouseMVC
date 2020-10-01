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
    public class Expedition
    {

        private ArticleRepository _articleRepo = new ArticleRepository();
        private CategorieRepository _categorieRepo = new CategorieRepository();
        private ClientRepository _clientRepo = new ClientRepository();

        [DisplayName("N°")] 
        public int ExpeditionId { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [DisplayName("Quantité")]
        public int Quantite { get; set; }

        [DisplayName("ID Utilisateur")]
        public int UtilisateurId { get; set; }

        [DisplayName("Utilisateur")]
        public string UtilisateurNom { get; set; }

        public string UtilisateurPrenom { get; set; }

        [DisplayName("N° Article")]
        public int ArticleId { get; set; }

        [DisplayName("Article")]
        public string ArticleNom { get; set; }

        [DisplayName("Categorie")]
        public string CategorieNom { get; set; }

        [DisplayName("N° Categorie")]
        public int CategorieId { get; set; }

        [DisplayName("N° Client")]
        public int ClientId { get; set; }

        [DisplayName("Client")]
        public string ClientNom { get; set; }

        public string ClientPrenom { get; set; }

        [DisplayName("Société")]
        public string ClientNomSociete { get; set; }

        [DisplayName("Numéro TVA")]
        public int ClientNumTva { get; set; }

        [DisplayName("Rue")]
        public string ClientRue { get; set; }

        [DisplayName("Numéro")]
        public int ClientNumero { get; set; }

        [DisplayName("Code postal")]
        public int ClientCodePostal { get; set; }

        [DisplayName("Ville")]
        public string ClientVille { get; set; }

        [DisplayName("Pays")]
        public string ClientPays { get; set; }

        [DisplayName("Téléphone")]
        public string ClientNumTel { get; set; }

        public IEnumerable<Article> ListArticle { get => _articleRepo.Get(); }
        public IEnumerable<Categorie> ListCategorie { get => _categorieRepo.Get(); }
        public IEnumerable<Client> ListClient { get => _clientRepo.Get(); }
    }
}
