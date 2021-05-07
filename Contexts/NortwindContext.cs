using IskurNortwindApi.Models;
using Microsoft.EntityFrameworkCore;

namespace IskurNortwindApi.Contexts
{
    public class NortwindContext : DbContext
    {
        public NortwindContext(DbContextOptions<NortwindContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        // Tabloları manuel map etmek için
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Category>().ToTable("Categories");
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}