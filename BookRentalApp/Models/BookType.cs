using System.ComponentModel.DataAnnotations;

namespace BookRentalApp.Models
{
    public class BookType
    {
        [Key] //primary key
        public int Id { get; set; }

        [Required] //not null
        public string Name { get; set; }
    }
}
