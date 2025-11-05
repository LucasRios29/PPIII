using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PPIII.Data;
using PPIII.Models;

namespace PPIII.Pages.Ratings
{
    public class IndexModel : PageModel
    {
        private readonly PPIIIContext _context;

        public IndexModel(PPIIIContext context)
        {
            _context = context;
        }

        public IList<Rating> RatingList { get; set; } = default!;

        public async Task OnGetAsync()
        {
            RatingList = await _context.Rating.OrderBy(r => r.Name).ToListAsync();
        }
    }
}