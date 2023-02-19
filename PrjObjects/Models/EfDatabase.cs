using Microsoft.EntityFrameworkCore;
namespace PrjObjects.Models
{
   public class EfDatabase : DbContext
   {
      public EfDatabase(DbContextOptions options) : base(options)
      {
      }

      public DbSet<People> People { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.ApplyConfiguration(new PeopleMap());
      }
   }
}
