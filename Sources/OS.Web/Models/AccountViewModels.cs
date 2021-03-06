﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OS.Web.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = Constants.ValidationMessages.REQUIRED)]
        [Display(Name = "Електронна пошта")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required(ErrorMessage = Constants.ValidationMessages.REQUIRED)]
        public string Provider { get; set; }

        [Required(ErrorMessage = Constants.ValidationMessages.REQUIRED)]
        [Display(Name = "Код")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required(ErrorMessage = Constants.ValidationMessages.REQUIRED)]
        [Display(Name = "Електронна пошта")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = Constants.ValidationMessages.REQUIRED)]
        [Display(Name = "Електронна пошта")]
        [EmailAddress(ErrorMessage = "Невірний формат")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запам'ятати мене?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = Constants.ValidationMessages.REQUIRED)]
        [EmailAddress]
        [Display(Name = "Електронна пошта")]
        public string Email { get; set; }

        [Required(ErrorMessage = Constants.ValidationMessages.REQUIRED)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Підтвердження паролю")]
        [Compare("Password", ErrorMessage = "Пароль та підтвердження паролю не співпадають.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = Constants.ValidationMessages.REQUIRED)]
        [EmailAddress]
        [Display(Name = "Електронна пошта")]
        public string Email { get; set; }

        [Required(ErrorMessage = Constants.ValidationMessages.REQUIRED)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Підтвердження паролю")]
        [Compare("Password", ErrorMessage = "Пароль та підтвердження паролю не співпадають.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = Constants.ValidationMessages.REQUIRED)]
        [EmailAddress]
        [Display(Name = "Електронна пошта")]
        public string Email { get; set; }
    }
}
