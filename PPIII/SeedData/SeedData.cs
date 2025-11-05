using Microsoft.EntityFrameworkCore;
using PPIII.Data;

namespace PPIII.SeedData
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PPIIIContext(serviceProvider.GetRequiredService<DbContextOptions<PPIIIContext>>()))
            {
                if (context == null || context.Movie == null)
                {
                    throw new ArgumentNullException("Null PPIIIContext");
                }

                if (context.Movie.Any())
                {
                    return; // DB has been seeded
                }

                context.Movie.AddRange(
                    new Models.Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Price = 200,
                        Rating = "R"
                    },
                    new Models.Movie
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Price = 150,
                        Rating = "R"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
