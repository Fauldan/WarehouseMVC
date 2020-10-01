using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMVC_DAL.Models
{
    public class ConfirmedReception
    {
        [DisplayName("ID Confirmation")]
        public int ConfirmationId { get; set; }

        [DisplayName("ID Réception")]
        public int ReceptionId { get; set; }

        [DisplayName("Fournisseur")]
        public string FournisseurNom { get; set; }

        [DisplayName("N° TVA")]
        public int FournisseurNumTva { get; set; }

        [DisplayName("Rue")]
        public string FournisseurRue { get; set; }

        [DisplayName("Numero")]
        public int FournisseurNumero { get; set; }

        [DisplayName("CodePostal")]
        public int FournisseurCodePostal { get; set; }

        [DisplayName("Ville")]
        public string FournisseurVille { get; set; }

        [DisplayName("Pays")]
        public string FournisseurPays { get; set; }

        [DisplayName("N° Fournisseur")]
        [Required]
        public int FournisseurId { get; set; }

        [DisplayName("N° Article")]
        [Required]
        public int ArticleId { get; set; }

        [DisplayName("Article")]
        public string ArticleNom { get; set; }

        [DisplayName("N° Categorie")]
        [Required]
        public int CategorieId { get; set; }

        [DisplayName("Categorie")]
        [Required]
        public int CategorieNom { get; set; }

        [DisplayName("ID Utilisateur")]
        public int UtilisateurId { get; set; }

        [DisplayName("Utilisateur")]
        public string UtilisateurNom { get; set; }

        [DisplayName("Quantité")]
        public int Quantite { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}
