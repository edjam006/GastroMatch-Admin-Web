using System.ComponentModel.DataAnnotations;

namespace GastroMatch.Admin.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la categoría es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        // Relación: Una categoría tiene muchos restaurantes
        public ICollection<Restaurante> Restaurantes { get; set; } = new List<Restaurante>();
    }
}
