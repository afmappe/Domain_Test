// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>

using Cars.Library.Domain.Cars;
using System.Data.Entity.ModelConfiguration;

namespace Cars.Library.Infrastructure.Data.Mappers
{
    public class CarMapper : EntityTypeConfiguration<CarInfo>
    {
        public CarMapper(string schema)
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.License)
                .HasMaxLength(50);

            // Table & Column Mappings
            ToTable("CAR", schema);
            Property(t => t.Id).HasColumnName("id");
            Property(t => t.ModelId).HasColumnName("model_id");
            Property(t => t.Year).HasColumnName("year");
            Property(t => t.License).HasColumnName("license").IsOptional();
            Property(t => t.IsNew).HasColumnName("is_new");
            Property(t => t.IsAvailable).HasColumnName("is_available");
            Property(t => t.Image).HasColumnName("image");
        }
    }
}