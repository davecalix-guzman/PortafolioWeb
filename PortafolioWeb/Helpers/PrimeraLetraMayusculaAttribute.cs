namespace PortafolioWebAdministracion.Helpers
{
    using System.ComponentModel.DataAnnotations;

    public class PrimeraLetraMayusculaAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && !string.IsNullOrEmpty(value.ToString()))
            {
                var primeraLetra = value.ToString()[0].ToString();
                return primeraLetra != primeraLetra.ToUpper() ?
                    new ValidationResult("La primera letra debe ser mayúscula.")
                    : ValidationResult.Success;
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
