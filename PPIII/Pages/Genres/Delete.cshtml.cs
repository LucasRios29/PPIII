using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PPIII.Data;
using PPIII.Models;
using System.Threading.Tasks;

namespace PPIII.Pages.Genres
{
    public class DeleteModel : PageModel
    {
        private readonly PPIIIContext _context;
        public DeleteModel(PPIIIContext context) => _context = context;

        [BindProperty]
        public Genre Genre { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var genre = await _context.Genre.AsNoTracking().FirstOrDefaultAsync(g => g.Id == id);
            if (genre == null) return NotFound();
            Genre = genre;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var genre = await _context.Genre.FindAsync(id);
            if (genre != null)
            {
                _context.Genre.Remove(genre);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}