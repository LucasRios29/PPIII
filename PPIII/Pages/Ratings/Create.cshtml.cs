using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PPIII.Data;
using PPIII.Models;

namespace PPIII.Pages.Ratings
{
    public class CreateModel : PageModel
    {
        private readonly PPIIIContext _context;

        public CreateModel(PPIIIContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rating Rating { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Rating.Add(Rating);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}