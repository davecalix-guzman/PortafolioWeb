namespace PortafolioWebAdministracion.Models
{
    using PortafolioWebAdministracion.Helpers;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ExperienciaLaboral
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage = "{1} caracteres máximo.")]
        [PrimeraLetraMayuscula]
        public string NombreEmpresa { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage = "{1} caracteres máximo.")]
        [PrimeraLetraMayuscula]
        public string Puesto { get; set; }

        [Required(ErrorMessage = "*")]
        [PrimeraLetraMayuscula]
        public string Responsabilidad { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Inicio")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Finalización")]
        public DateTime FechaFinalizacion { get; set; }
    }
}
