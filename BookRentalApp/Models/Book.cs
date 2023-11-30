using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookRentalApp.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string BookName { get; set; }

        [Required]
        public string Writer { get; set; }

        [Required]
        public string Contributor { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ValidateNever]
        public int BookTypeId { get; set; }
        [ForeignKey("BookTypeId")]
        [ValidateNever]
        public BookType BookType { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }

    }
}
