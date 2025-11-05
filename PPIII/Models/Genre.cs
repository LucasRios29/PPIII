using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PPIII.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; } = string.Empty;

        // Navegación inversa many-to-many
        public List<Movie> Movies { get; set; } = new();
    }
}