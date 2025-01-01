using System.ComponentModel.DataAnnotations;

namespace ETicaretMVC.Models.ViewModels
{
    public class LoginVM
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "İsim girilmek zorundadir")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Soyisim girilmek zorundadir")]
        public string Surname { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email Adresi girilmek zorundadir")]
        public string Email { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Telefon Numarası girilmek zorundadir")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre  girilmesi zorunludur")]
        public string Password { get; set; }

        public bool RememberMe { get; set; } = false;
    }
}
