using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models
{
  public class AnimalContext : DbContext
  {
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Animal>()
          .HasData(
              new Animal { AnimalId = 1, AnimalName = "Slinko", Species = "Snake", Gender = "Male" }
          );
    }
    public AnimalContext(DbContextOptions<AnimalContext> options)
        : base(options)
    {
    }

    public DbSet<Animal> Animals { get; set; }
  }
}