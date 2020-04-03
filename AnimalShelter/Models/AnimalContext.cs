using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models
{
  public class AnimalContext : DbContext
  {
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Animal>()
          .HasData(
              new Animal { AnimalId = 1, AnimalName = "Burger", Species = "Dog", Gender = "Male" },
              new Animal { AnimalId = 2, AnimalName = "Hotdog", Species = "Cat", Gender = "Female" },
              new Animal { AnimalId = 3, AnimalName = "Slinko", Species = "Snake", Gender = "Male" },
              new Animal { AnimalId = 4, AnimalName = "Larry", Species = "Bird", Gender = "Male" },
              new Animal { AnimalId = 5, AnimalName = "Shelly", Species = "Turtle", Gender = "Female" }
          );
    }
    public AnimalContext(DbContextOptions<AnimalContext> options)
        : base(options)
    {
    }

    public DbSet<Animal> Animals { get; set; }
  }
}