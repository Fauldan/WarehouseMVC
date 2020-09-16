using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WarehouseMVC.Models.Forms
{
    public class LoginForm
    {
        [Required]
        [StringLength(25, MinimumLength = 2)]
        [DisplayName("Login : ")]
        public string Login { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 8)]
        [DisplayName("Mot de passe : ")]
        public string Password { get; set; }
    }
}