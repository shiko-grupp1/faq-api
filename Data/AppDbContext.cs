using Microsoft.EntityFrameworkCore;
using FAQ_API.Models;

namespace FAQ_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Faq> Faqs { get; set; }
    }
}