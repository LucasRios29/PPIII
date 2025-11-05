using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PPIII.Models
{
    public class Rating
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; } = string.Empty;

        public List<Movie> Movies { get; set; } = new();
    }
}