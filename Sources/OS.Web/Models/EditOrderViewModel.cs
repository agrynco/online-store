using System.ComponentModel.DataAnnotations;

namespace OS.Web.Models
{
    public class EditOrderViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string Comment { get; set; }

    }
}