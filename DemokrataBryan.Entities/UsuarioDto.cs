using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemokrataBryan.Entities
{
    public class UsuarioDto
    {
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El primer nombre no puede contener números.")]
        public string PrimerNombre { get; set; }

        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "El segundo nombre no puede contener números.")]
        public string? SegundoNombre { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El primer apellido no puede contener números.")]
        public string PrimerApellido { get; set; }

        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "El segundo apellido no puede contener números.")]
        public string? SegundoApellido { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El sueldo debe ser mayor a 0.")]
        public decimal Sueldo { get; set; }
    }
}
