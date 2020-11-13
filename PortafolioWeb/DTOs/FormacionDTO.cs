namespace PortafolioWebAdministracion.DTOs
{
    using PortafolioWebAdministracion.Helpers;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class FormacionDTO
    {
        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage = "{1} caracteres máximo.")]
        [PrimeraLetraMayuscula]
        [Display(Name = "Profesión u Oficio")]
        public string Profesion { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(70, ErrorMessage = "{1} caracteres máximo.")]
        [PrimeraLetraMayuscula]
        [Display(Name = "Centro de Estudios")]
        public string CentroEstudios { get; set; }

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
