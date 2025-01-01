using Microsoft.AspNetCore.Mvc;

namespace ETicaretMVC.Models.Page
{
    public class ContactFornVM 
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
