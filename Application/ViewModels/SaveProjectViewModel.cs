using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SaveProjectViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocar el nombre del proyecto")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe colocar la descripción del proyecto")]
        public string Description { get; set; }

        public int UserId { get; set; }

        public List<UserViewModel> Users { get; set; }
    }
}
