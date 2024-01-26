using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "An email must be specified")]
        [DataType(DataType.Text)]
        public string Email { get; set; }

        [Required(ErrorMessage = "A password must be specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool HasError { get; set; }
        public string Error { get; set; }
    }
}
