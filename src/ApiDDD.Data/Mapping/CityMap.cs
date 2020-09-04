using ApiDDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDDD.Data.Mapping
{
    public class CityMap : IEntityTypeConfiguration<CityEntity>
    {
        public void Configure(EntityTypeBuilder<CityEntity> builder)
        {
            builder.ToTable("Cities");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.IBGECode);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(60);

            builder.HasOne(x => x.State)
                   .WithMany(x => x.Cities);
        }
    }
}
