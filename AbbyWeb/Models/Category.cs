using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AbbyWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Display(Name="Display order")]
        [Range(1, 10000, ErrorMessage = "Display range must be in range of 1 to 10000.")]
        public int DisplayOrder { get; set; }

    }
}
