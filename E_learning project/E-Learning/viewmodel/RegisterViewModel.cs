using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace E_Learning.viewmodel
{
    public class RegisterViewModel
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public DateTime birthDate { get; set; }



    }
}
