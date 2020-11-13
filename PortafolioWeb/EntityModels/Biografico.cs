namespace PortafolioWebAdministracion.Models
{
    using PortafolioWebAdministracion.Helpers;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Biografico
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage = "{1} caracteres máximo.")]
        [PrimeraLetraMayuscula]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage = "{1} caracteres máximo.")]
        [PrimeraLetraMayuscula]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "*")]
        [PrimeraLetraMayuscula]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.PhoneNumber)]
        public string Celular { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Ingrese una cuenta de correo válida")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }
        
        public byte[] Imagen { get; set; }

        [PrimeraLetraMayuscula]
        [Display(Name = "Sobre mí")]
        public string Perfil { get; set; }

        [Display(Name = "Estado Civil")]
        public string EstadoCivil { get; set; }

        [DataType(DataType.Url)]
        public string Link { get; set; }
    }
}
