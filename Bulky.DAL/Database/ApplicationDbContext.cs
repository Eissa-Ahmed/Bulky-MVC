using Bulky.BL.Models;
using Bulky.Model.Models;
using Microsoft.EntityFrameworkCore;
namespace Bulky.DAL.Database
{
    public class ApplicationDbContext  :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Scifi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Prouduct> Prouducts { get; set; }
    }
}
