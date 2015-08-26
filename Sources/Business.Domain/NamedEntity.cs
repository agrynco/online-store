#region Usings
using System.ComponentModel.DataAnnotations;
#endregion

namespace Business
{
    public class NamedEntity : IdentityEntity
    {
        [Required]
        [MaxLength(250, ErrorMessage = "The length of the Name property can not be more than 250 characters")]
        public string Name { get; set; }
    }
}