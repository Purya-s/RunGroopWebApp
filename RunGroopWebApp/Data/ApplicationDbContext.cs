using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Models;

namespace RunGroopWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {

        }
        public DbSet<Club> clubs { get; set; }
        public DbSet<Race> races { get; set; }
        public DbSet<Address> addresses { get; set; }
    }
}
