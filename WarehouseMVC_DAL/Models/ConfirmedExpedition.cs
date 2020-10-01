using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMVC_DAL.Models
{
    public class ConfirmedExpedition
    {
        [DisplayName("ID Confirmation")] 
        public int ConfirmationId { get; set; }

        [DisplayName("ID Expedition")] 
        public int ExpeditionId { get; set; }

        [DisplayName("Nom")]
        public string ClientNom { get; set; }

        [DisplayName("Prénom")]
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

        [DisplayName("N° Client")]
        public int ClientId { get; set; }

        [DisplayName("N° Article")]
        [Required]
        public int ArticleId { get; set; }

        [DisplayName("Article")]
        public string ArticleNom { get; set; }

        [DisplayName("ID Utilisateur")]
        public int UtilisateurId { get; set; }

        [DisplayName("Utilisateur")]
        public string UtilisateurNom { get; set; }

        [DisplayName("Quantité")]
        public int Quantite { get; set; }

        [DisplayName("N° Categorie")]
        [Required]
        public int CategorieId { get; set; }

        [DisplayName("Categorie")]
        [Required]
        public string CategorieNom { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}
