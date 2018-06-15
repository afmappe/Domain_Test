// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>

using Cars.Library.Domain.Brands;
using System.Data.Entity.ModelConfiguration;

namespace Cars.Library.Infrastructure.Data.Mappers
{
    public class BrandMapper : EntityTypeConfiguration<BrandInfo>
    {
        public BrandMapper(string schema)
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Name)
                .HasMaxLength(50);

            // Table & Column Mappings
            ToTable("BRAND", schema);
            Property(t => t.Id).HasColumnName("id");
            Property(t => t.Name).HasColumnName("name").IsRequired();
        }
    }
}