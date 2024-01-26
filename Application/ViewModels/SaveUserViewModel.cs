using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SaveUserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocar el nombre")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Debe colocar el apellido")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Debe colocar el correo")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe colocar el nombre de usuario")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Debe colocar la contraseña")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Debe volver a colocar la contraseña")]
        public string ConfirmPassword { get; set; }
    }
}
