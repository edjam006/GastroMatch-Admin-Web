using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GastroMatch.Admin.Models
{
    public class Restaurante
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La dirección es obligatoria.")]
        [StringLength(200, ErrorMessage = "La dirección no puede exceder los 200 caracteres.")]
        public string Direccion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del email no es válido.")]
        [StringLength(150, ErrorMessage = "El email no puede exceder los 150 caracteres.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "El RUC es obligatorio.")]
        [RegularExpression(@"^\d{13}$", ErrorMessage = "El RUC debe tener exactamente 13 caracteres numéricos.")]
        public string RUC { get; set; } = string.Empty;

        // Foreign Key hacia Categoria
        [Required(ErrorMessage = "La categoría es obligatoria.")]
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public Categoria? Categoria { get; set; }

        // Relación: Un restaurante tiene muchos platos
        public ICollection<Plato> Platos { get; set; } = new List<Plato>();
    }
}

