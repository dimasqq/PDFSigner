using Microsoft.EntityFrameworkCore;
using PDFSigner.Data.Entities;

namespace PDFSigner.Data
{
    public class Context : DbContext
    {
        private readonly IConfiguration _config;

        public Context(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Document> Documents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=pdfsigner;Username=postgres;Password=admin");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
