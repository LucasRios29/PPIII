using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;                // <-- Añadido
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PPIII.Data;
using PPIII.Models;

namespace PPIII.Pages.Movies
{
    public class ManageModel : PageModel
    {
        private readonly PPIIIContext _context;

        public ManageModel(PPIIIContext context) => _context = context;

        public IList<Movie> Movie { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }

        public SelectList? Ratings { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? MovieRating { get; set; }

        public async Task OnGetAsync()
        {
            var genreNames = await _context.Genre
                                           .OrderBy(g => g.Name)
                                           .Select(g => g.Name)
                                           .ToListAsync();

            var ratingNames = await _context.Rating
                                            .OrderBy(r => r.Name)
                                            .Select(r => r.Name)
                                            .ToListAsync();

            var movies = from m in _context.Movie select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title!.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(s => s.Genre == MovieGenre);
            }
            if (!string.IsNullOrEmpty(MovieRating))
            {
                movies = movies.Where(s => s.Rating == MovieRating);
            }

            Genres = new SelectList(genreNames);
            Ratings = new SelectList(ratingNames);
            Movie = await movies.ToListAsync();
        }
    }
}