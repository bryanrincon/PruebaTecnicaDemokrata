using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace DemokrataBryan.Entities.Models
{
    public class Usuario
    {
        public int Id { get; set; }

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
        [Precision(18, 2)]
        [Range(0.01, double.MaxValue, ErrorMessage = "El sueldo debe ser mayor a 0.")]
        public decimal Sueldo { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaModificacion { get; set; }

        // Campo de borrado lógico
        public bool IsDeleted { get; set; } // Marca si el usuario está eliminado
    }
}
