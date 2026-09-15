using System.ComponentModel.DataAnnotations;

namespace PawCare.Models
{
    public class Mascota
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre de la mascota")]
        public string NombreMascota { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ingrese el nombre del dueño")]
        public string NombreDueno { get; set; } = string.Empty;

        public string Tipo { get; set; } = string.Empty;

        [Range(0, 30, ErrorMessage = "La edad debe estar entre 0 y 30 años")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "Ingrese el teléfono")]
        [RegularExpression(@"^[0-9]{9}$",
            ErrorMessage = "El teléfono debe tener 9 dígitos")]
        public string Telefono { get; set; } = string.Empty;

        public string Observaciones { get; set; } = string.Empty;
    }
}
