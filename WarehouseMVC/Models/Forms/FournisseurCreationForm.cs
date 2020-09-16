using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WarehouseMVC.Models.Forms
{
    public class FournisseurCreationForm
    {
        [DisplayName("Nom du fournisseur :")]
        [Required]
        [MinLength(2)]
        public string Nom { get; set; }

        [DisplayName("Numéro TVA :")]
        [Required]
        public int NumTva { get; set; }

        [DisplayName("Email :")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Téléphone :")]
        [Required]
        [MinLength(2)]
        public string NumTel { get; set; }

        [DisplayName("Rue :")]
        [Required]
        [MinLength(2)]
        public string Rue { get; set; }

        [DisplayName("Numero :")]
        [Required]
        public int Numero { get; set; }

        [DisplayName("Code Postal :")]
        [Required]
        public int CodePostal { get; set; }

        [DisplayName("Ville :")]
        [Required]
        [MinLength(2)]
        public string Ville { get; set; }

        [DisplayName("Pays :")]
        [Required]
        [MinLength(2)]
        public string Pays { get; set; }
    }
}