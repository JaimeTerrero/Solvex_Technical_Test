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

        [Required(ErrorMessage = "Debe colocar el nombre del usuario")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe colocar el apellido del usuario")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Debe colocar el correo del usuario")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe colocar la posición del usuario")]
        public string Position { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar el proyecto")]
        public int ProjectId { get; set; }

        public List<ProjectViewModel> Projects { get; set; }
    }
}
