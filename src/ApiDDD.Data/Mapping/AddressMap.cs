using ApiDDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDDD.Data.Mapping
{
    public class AddressMap : IEntityTypeConfiguration<AddressEntity>
    {
        public void Configure(EntityTypeBuilder<AddressEntity> builder)
        {
            builder.ToTable("Addresses");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.ZipCode);

            builder.Property(x => x.ZipCode)
                   .IsRequired()
                   .HasMaxLength(10);
            
            builder.Property(x => x.Street)
                   .IsRequired()
                   .HasMaxLength(60);
            
            builder.Property(x => x.Number)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.HasOne(x => x.City)
                   .WithMany(x => x.Addresses);
        }
    }
}
