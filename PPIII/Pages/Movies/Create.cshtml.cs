using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PPIII.Data;
using PPIII.Models;
using Microsoft.EntityFrameworkCore;

namespace PPIII.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly PPIII.Data.PPIIIContext _context;

        public CreateModel(PPIII.Data.PPIIIContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;

        public SelectList? Genres { get; set; }
        public SelectList? Ratings { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            await PopulateSelectListsAsync();
            return Page();
        }

        private async Task PopulateSelectListsAsync()
        {
            var genres = await _context.Genre.OrderBy(g => g.Name).Select(g => g.Name).ToListAsync();
            var ratings = await _context.Rating.OrderBy(r => r.Name).Select(r => r.Name).ToListAsync();
            Genres = new SelectList(genres);
            Ratings = new SelectList(ratings);
        }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await PopulateSelectListsAsync();
                return Page();
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
