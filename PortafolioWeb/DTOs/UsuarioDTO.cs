namespace PortafolioWebAdministracion.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class UsuarioDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage = "{1} caracteres máximo.")]
        [Display(Name = "Nombre de Usuario")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(30, ErrorMessage = "La contraseña debe contener entre {2} y {1} caracteres.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }
    }
}
