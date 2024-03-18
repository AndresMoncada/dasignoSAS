using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dasignoSAS.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El primer nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El primer nombre no puede tener más de 50 caracteres.")]
        [RegularExpression("^[^0-9]*$", ErrorMessage = "El primer nombre no puede contener números.")]
        public required string PrimerNombre { get; set; }

        [StringLength(50, ErrorMessage = "El segundo nombre no puede tener más de 50 caracteres.")]
        [RegularExpression("^[^0-9]*$", ErrorMessage = "El segundo nombre no puede contener números.")]
        public string? SegundoNombre { get; set; }

        [Required(ErrorMessage = "El primer apellido es obligatorio.")]
        [StringLength(50, ErrorMessage = "El primer apellido no puede tener más de 50 caracteres.")]
        [RegularExpression("^[^0-9]*$", ErrorMessage = "El primer apellido no puede contener números.")]
        public required string PrimerApellido { get; set; }

        [StringLength(50, ErrorMessage = "El segundo apellido no puede tener más de 50 caracteres.")]
        [RegularExpression("^[^0-9]*$", ErrorMessage = "El segundo apellido no puede contener números.")]
        public string? SegundoApellido { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El sueldo es obligatorio.")]
        [RegularExpression("^[1-9]\\d*$", ErrorMessage = "El sueldo debe ser mayor que cero.")]
        public decimal Sueldo { get; set; }

        [Required(ErrorMessage = "La fecha de creación es obligatoria.")]
        public DateTime FechaCrea { get; set; }
        public DateTime? FechaModifica { get; set; }
    }
}
