using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
namespace PrjObjects.Models
{
   public class People
   {
      public long Id { get; set; }

      [Display(Name = "Nome completo")]
      [Required(ErrorMessage = "Digite o nome")]
      [MaxLength(100, ErrorMessage = "Ate 100 caracteres")]
      public string Name { get; set; }
      public virtual Url Site { get; set; } = new Url();

      [Display(Name = "Salário")]
      [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N2}")]
      [Required(ErrorMessage = "Digite o salário")]
      public decimal Value { get; set; }
   }

   public class PeopleMap : IEntityTypeConfiguration<People>
   {
      public void Configure(EntityTypeBuilder<People> builder)
      {
         builder.ToTable("peoples");
         builder.HasKey(c => c.Id);
         builder.Property(c => c.Id).UseMySqlIdentityColumn().HasColumnName("id");
         builder.Property(c => c.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
         builder.Property(c => c.Value).HasColumnName("value").HasPrecision(18,2).IsRequired();
         builder.OwnsOne(c => c.Site, options =>
         {            
            options.Property(c => c.Value).HasColumnName("site").HasMaxLength(100).IsRequired();
         });         
      }
   }

   public class Url: ValueObject
   {
      [Required(ErrorMessage = "Digite a url")]
      [Url(ErrorMessage = "Url inválido")]
      [MaxLength(200, ErrorMessage = "Ate 200 caracteres")]
      [Display(Name = "Url")]
      public string Value { get; set; }
   }

   public abstract class ValueObject
   {
   }
}
