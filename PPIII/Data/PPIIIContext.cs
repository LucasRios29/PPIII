using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPIII.Models;

namespace PPIII.Data
{
    public class PPIIIContext : DbContext
    {
        public PPIIIContext (DbContextOptions<PPIIIContext> options)
            : base(options)
        {
        }

        public DbSet<PPIII.Models.Movie> Movie { get; set; } = default!;
        public DbSet<PPIII.Models.Genre> Genre { get; set; } = default!;
        public DbSet<PPIII.Models.Rating> Rating { get; set; } = default!;
    }
}
