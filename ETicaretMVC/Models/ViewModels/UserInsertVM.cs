using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ETicaretMVC.Models.ViewModels
{
    public class UserInsertVM
    {
        [Required(ErrorMessage = "Hey! we need to name to connect with you!")]
        [MinLength(2, ErrorMessage = "At least you should enter 2 char")]
        [MaxLength(20, ErrorMessage = "More 20 char")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Hey! we need to name to connect with you!")]
        [MinLength(2, ErrorMessage = "At least you should enter 2 char")]
        [MaxLength(20, ErrorMessage = "More 20 char")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "BirthDate is required")]
        [DataType(DataType.Date)]
        public DateOnly BirthDate { get; set; }

        [Required(ErrorMessage = "You must enter your mail adress")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must enter your phone")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Phone number must contain 10 digits.")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Password is mandatory")]
        [MinLength(6, ErrorMessage = "At least enter 6 char")]
        [MaxLength(16, ErrorMessage = "Limit 16 char")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

}
