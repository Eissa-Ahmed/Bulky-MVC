using Bulky.BL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bulky.Model.Models
{
    public class Prouduct
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title Is Required")]
        [MaxLength(15 , ErrorMessage = "Max Length Is 15")]
        public string Title { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "ISBN Is Required")]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "Author Is Required")]
        [MaxLength(15, ErrorMessage = "Max Length Is 15")]
        public string Author { get; set; }
        [Required(ErrorMessage = "ListPrice Is Required")]
        [Range(1,1000)]
        [Display(Name = "List Price")]
        public string ListPrice { get; set; }
        [Required(ErrorMessage = "Price Is Required")]
        [Range(1, 1000)]
        public string Price { get; set; }
        [Required(ErrorMessage = "Price50+ Is Required")]
        [Range(1, 1000)]
        [Display(Name = "Price For 50+")]
        public string Price50 { get; set; }
        [Required(ErrorMessage = "Price50+ Is Required")]
        [Range(1, 1000)]
        [Display(Name = "Price For 100+")]
        public string Price100 { get; set; }
        [Required(ErrorMessage = "Image Is Required")]
        public string ImageUrl { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

    }
}
