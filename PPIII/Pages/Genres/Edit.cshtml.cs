using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PPIII.Data;
using PPIII.Models;
using System.Threading.Tasks;

namespace PPIII.Pages.Genres
{
    public class EditModel : PageModel
    {
        private readonly PPIIIContext _context;
        public EditModel(PPIIIContext context) => _context = context;

        [BindProperty]
        public Genre Genre { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var genre = await _context.Genre.FindAsync(id);
            if (genre == null) return NotFound();
            Genre = genre;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.Attach(Genre).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}