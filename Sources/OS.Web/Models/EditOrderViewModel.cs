using System.ComponentModel.DataAnnotations;

namespace OS.Web.Models
{
    public class EditOrderViewModel
    {
        [Required]
        [Display(Name = "Ім'я")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Прізвище")]
        public string LastName { get; set; }

        [Display(Name = "По-батькові")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Електрона пошта")]
        [RegularExpression(Constants.RegularExpressions.EMAIL, ErrorMessage = "Невірний формат")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Додатковий коментар")]
        public string Comment { get; set; }

    }
}