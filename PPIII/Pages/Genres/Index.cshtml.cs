using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PPIII.Data;
using PPIII.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPIII.Pages.Genres
{
    public class IndexModel : PageModel
    {
        private readonly PPIIIContext _context;
        public IndexModel(PPIIIContext context) => _context = context;

        public IList<Genre> GenreList { get; set; } = new List<Genre>();

        public async Task OnGetAsync()
        {
            GenreList = await _context.Genre.AsNoTracking().ToListAsync();
        }
    }
}