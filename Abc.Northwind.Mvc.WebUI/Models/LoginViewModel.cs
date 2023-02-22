using System.ComponentModel.DataAnnotations;

namespace Abc.Northwind.Mvc.WebUI.Models
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public bool Rememberme { get; set; }
    }
}
