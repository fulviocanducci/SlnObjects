using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace PrjObjects.Models
{
   public class People
   {
      public long Id { get; set; }
      public string Name { get; set; }
      public Url Site { get; set; } = new Url();
   }

   public class PeopleMap : IEntityTypeConfiguration<People>
   {
      public void Configure(EntityTypeBuilder<People> builder)
      {
         builder.ToTable("peoples");
         builder.HasKey(c => c.Id);
         builder.Property(c => c.Id).UseMySqlIdentityColumn().HasColumnName("id");
         builder.Property(c => c.Name).HasColumnName("name").HasMaxLength(100);
         builder.Property(c => c.Site.Value).HasColumnName("site").HasMaxLength(100);
      }
   }

   public class Url: ValueObject
   {
      [Required(ErrorMessage = "Digite o e-mail")]
      [EmailAddress(ErrorMessage = "E-mail inválido")]
      [MaxLength(200, ErrorMessage = "Ate 200 caracteres")]
      public string Value { get; set; }
   }

   public abstract class ValueObject
   {
   }
}
