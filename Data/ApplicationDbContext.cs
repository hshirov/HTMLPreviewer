using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public ApplicationDbContext() { }
        public virtual DbSet<HTMLExample> HTMLExamples { get; set; }
    }
}
