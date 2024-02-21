using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PF.Reserva.API.Models;

namespace PF.Reserva.API.Data.Mappings;

public class ReserveMapping : IEntityTypeConfiguration<Reserver>
{
    public void Configure(EntityTypeBuilder<Reserver> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.EstablishmentId)
               .IsRequired();

        builder.Property(r => r.StartDate)
               .IsRequired()
               .HasColumnType("datetime");

        builder.Property(r => r.EndDate)
               .IsRequired()
               .HasColumnType("datetime");

        builder.Property(r => r.Status)
               .IsRequired()
               .HasConversion<string>()
               .HasColumnType("varchar(50)");

        builder.Property(r => r.NumberOfPeople)
               .IsRequired()
               .HasColumnType("int");

        builder.Property(r => r.TotalPrice)
               .IsRequired()
               .HasColumnType("decimal(18,2)");

        builder.Property(r => r.Comments)
               .HasColumnType("varchar(500)");

        builder.ToTable("Reserve");
    }
}
