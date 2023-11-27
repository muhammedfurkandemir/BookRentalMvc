using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookRentalApp.Models
{
    public class BookType
    {
        [Key] //primary key
        public int Id { get; set; }

        [Required(ErrorMessage ="Kitap tür adı boş bırakılamaz!")] //not null
        [MaxLength(30)]
        [DisplayName("Kitap Türü Adı")]
        public string Name { get; set; }
    }
}
