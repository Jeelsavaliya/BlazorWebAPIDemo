using BlazorClass;
using Microsoft.EntityFrameworkCore;

namespace BlazorAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; }

    }
}
