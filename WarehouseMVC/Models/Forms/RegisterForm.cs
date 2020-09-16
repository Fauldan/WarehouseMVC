﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WarehouseMVC.Models.Forms
{
    public class RegisterForm
    {
        [Required]
        [StringLength(25, MinimumLength = 4)]
        [DisplayName("Login : ")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 8)]
        [DisplayName("Mot de passe : ")]
        public string Password { get; set; }

        [DisplayName("Nom :")]
        [Required]
        [MinLength(3)]
        public string Nom { get; set; }

        [DisplayName("Prénom :")]
        [Required]
        [MinLength(3)]
        public string Prenom { get; set; }

        [DisplayName("Email :")]
        [Required]
        [EmailAddress]
        public int Email { get; set; }

    }
}