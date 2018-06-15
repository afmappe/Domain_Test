// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>

using Cars.Library.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace Cars.Library.Infrastructure.Data.Mappers
{
    public class ModelMapper : EntityTypeConfiguration<ModelInfo>
    {
        public ModelMapper(string schema)
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Name)
                .HasMaxLength(50);

            // Table & Column Mappings
            ToTable("MODEL", schema);
            Property(t => t.Id).HasColumnName("id");
            Property(t => t.Name).HasColumnName("name").IsRequired();
            Property(t => t.BrandId).HasColumnName("brand_id");
        }
    }
}