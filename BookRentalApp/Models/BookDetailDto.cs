using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookRentalApp.Models
{
    public class BookDetailDto
    {
        public int Id { get; set; }
        public string BookName { get; set; }

        public string Writer { get; set; }

        public string Contributor { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string BookTypeName { get; set; }
        public string ImageUrl { get; set; }
    }
}
