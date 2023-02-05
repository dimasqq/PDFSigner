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
        public DbSet<CompanyDocument> CompanyDocuments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=pdfsigner;Username=postgres;Password=admin");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyDocument>()
                .HasKey(m => new { m.CompanyId, m.DocumentId });
            modelBuilder.Entity<CompanyDocument>()
                .HasOne(c => c.SignCompany);
            modelBuilder.Entity<CompanyDocument>()
                .HasOne(d => d.SignDocument);
        }
    }
}
