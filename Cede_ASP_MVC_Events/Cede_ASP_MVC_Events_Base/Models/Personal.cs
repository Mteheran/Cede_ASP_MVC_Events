using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cede_ASP_MVC_Events_Base.Models
{
    public class Personal
    {        
        public Guid PersonalId { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Nombre")]
        [Display(Name= "Nombre")]
        [MaxLength(10,  ErrorMessage = "No cumple con el maximo de caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage ="*")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }

        [Display(Name = "Telefono")]
        public string Phone { get; set; }

        [Display(Name = "Eliminado")]
        public bool IsDeleted { get; set; }
    }
}