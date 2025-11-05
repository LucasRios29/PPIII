using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PPIII.Data;
using PPIII.Models;
using System.Threading.Tasks;

namespace PPIII.Pages.Genres
{
    public class CreateModel : PageModel
    {
        private readonly PPIIIContext _context;
        public CreateModel(PPIIIContext context) => _context = context;

        [BindProperty]
        public Genre Genre { get; set; } = new();

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            _context.Genre.Add(Genre);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}