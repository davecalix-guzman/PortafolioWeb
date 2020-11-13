namespace PortafolioWebAdministracion.Models
{
    using PortafolioWebAdministracion.Helpers;
    using System.ComponentModel.DataAnnotations;

    public class Habilidad
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage = "{1} caracteres máximo.")]
        [Display(Name = "Habilidad Técnica")]
        [PrimeraLetraMayuscula]
        public string HabilidadDescripcion { get; set; }

        [Required(ErrorMessage = "*")]
        public string Nivel { get; set; }
    }
}
