using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PF.Estabelecimento.API.Models;

namespace PF.Estabelecimento.API.Data.Mappings;

public class EstablishmentMapping : IEntityTypeConfiguration<Establishment>
{
    public void Configure(EntityTypeBuilder<Establishment> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .IsRequired()
            .HasColumnType("varchar(250)");

        builder.Property(e => e.Local)
            .IsRequired()
            .HasColumnType("varchar(250)");

        builder.Property(e => e.Detail)
            .IsRequired()
            .HasColumnType("varchar(500)");

        builder.Property(e => e.ImgURL)
            .IsRequired()
            .HasColumnType("varchar(250)");

        builder.Property(e => e.NominatedAudience)
            .IsRequired()
            .HasColumnType("varchar(150)");

        builder.ToTable("Establishment");
    }
}
