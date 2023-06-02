using Microsoft.EntityFrameworkCore;
using WebCrawler.Domain.Models;

namespace WebCrawler.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }
    }
}
