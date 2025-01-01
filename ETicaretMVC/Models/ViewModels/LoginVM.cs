using System.ComponentModel.DataAnnotations;

namespace ETicaretMVC.Models.ViewModels
{
    public class LoginVM
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email Adresi girilmek zorundadir")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre  girilmesi zorunludur")]
        public string Password { get; set; }

        public bool RememberMe { get; set; } = false;
    }
}
