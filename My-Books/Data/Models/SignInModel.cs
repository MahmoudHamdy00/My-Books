using System.ComponentModel.DataAnnotations;

namespace My_Books.Data.Models
{
    public class SignInModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
