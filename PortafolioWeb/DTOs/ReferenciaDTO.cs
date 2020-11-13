using PortafolioWebAdministracion.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortafolioWebAdministracion.DTOs
{
    public class ReferenciaDTO
    {
        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage = "{1} caracteres máximo.")]
        [PrimeraLetraMayuscula]
        [Display(Name = "Nombre Completo")]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(60, ErrorMessage = "{1} caracteres máximo.")]
        [PrimeraLetraMayuscula]
        [Display(Name = "Profesión u Oficio")]
        public string Profesion { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo")]
        public string Email { get; set; }

        [DataType(DataType.Url)]
        public string Link { get; set; }
    }
}
