namespace PortafolioWebAdministracion.DTOs
{
    using PortafolioWebAdministracion.Helpers;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CertificacionDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(100, ErrorMessage = "{1} caracteres máximo.")]
        [PrimeraLetraMayuscula]
        [Display(Name = "Nombre del Curso o Certificación")]
        public string CertificacionDescripcion { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Duración")]
        public string Duracion { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Unidad de Tiempo")]
        public string UnidadTiempo { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Date)]
        [Display(Name = "Año")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Anio { get; set; }
    }
}
