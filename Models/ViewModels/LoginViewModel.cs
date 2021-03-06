﻿using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }
    }
}