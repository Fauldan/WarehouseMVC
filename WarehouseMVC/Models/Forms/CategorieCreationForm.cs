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
    public class CategorieCreationForm
    {
        [DisplayName("Nom :")]
        [Required]
        [MinLength(3)]
        public string Nom { get; set; }
    }
}