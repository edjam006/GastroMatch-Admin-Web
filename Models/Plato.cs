using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GastroMatch.Admin.Models
{
    public class Plato
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del plato es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0.01, 99999.99, ErrorMessage = "El precio debe ser mayor a 0.")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "Las calorías son obligatorias.")]
        [Range(0, int.MaxValue, ErrorMessage = "Las calorías deben ser un valor positivo.")]
        public int Calorias { get; set; }

        // Foreign Key hacia Restaurante
        [Required]
        public int RestauranteId { get; set; }

        [ForeignKey("RestauranteId")]
        public Restaurante? Restaurante { get; set; }
    }
}
