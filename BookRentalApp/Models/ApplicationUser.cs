using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BookRentalApp.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public int StudentId { get; set; }

        public string Department { get; set; }

        public string Faculty { get; set; }

        public string Adress { get; set; }
    }
}
