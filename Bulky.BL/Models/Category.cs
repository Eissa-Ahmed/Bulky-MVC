using System.ComponentModel.DataAnnotations;

namespace Bulky.BL.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Of Category Is Required")]
        [MaxLength(10, ErrorMessage = "Max Length Is 10 Char")]
        [MinLength(3, ErrorMessage = "Min Length Is 3 Char")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Display Order Is Required")]
        public int DisplayOrder { get; set; }
    }
}
