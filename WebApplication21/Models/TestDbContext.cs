namespace WebApplication21.Models
{
    using Microsoft.EntityFrameworkCore;

    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
        }

        public DbSet<PdfDocument> PdfDocuments { get; set; }
    }
}
