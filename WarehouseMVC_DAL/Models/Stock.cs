using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMVC_DAL.Models
{
    public class Stock
    {
        [DisplayName("ID")]
        public int StockId { get; set; }

        [DisplayName("N° Article")]
        public int ArticleId { get; set; }

        [DisplayName("Article")]
        public string ArticleNom { get; set; }

        [DisplayName("ID Utilisateur")]
        public int UtilisateurId { get; set; }

        [DisplayName("Utilisateur")]
        public string UtilisateurNom { get; set; }

        [DisplayName("Quantité")]
        public int Quantite { get; set; }

        [DisplayName("Stock")]
        public int TotalStock { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [DisplayName("Activité")]
        public string Activite { get; set; }
    }
}
