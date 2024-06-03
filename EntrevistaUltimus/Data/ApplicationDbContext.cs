using EntrevistaUltimus.Models;
using Microsoft.EntityFrameworkCore;

namespace EntrevistaUltimus.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }

}
