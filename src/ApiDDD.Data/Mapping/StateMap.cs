using ApiDDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDDD.Data.Mapping
{
    public class StateMap : IEntityTypeConfiguration<StateEntity>
    {
        public void Configure(EntityTypeBuilder<StateEntity> builder)
        {
            builder.ToTable("States");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.ShortName)
                   .IsUnique();

            builder.Property(x => x.ShortName)
                   .IsRequired()
                   .HasMaxLength(2);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(45);
        }
    }
}
