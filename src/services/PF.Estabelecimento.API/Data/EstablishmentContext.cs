using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using PF.Core.Data;
using PF.Core.Messages;
using PF.Estabelecimento.API.Models;

namespace PF.Estabelecimento.API.Data;

public class EstablishmentContext : DbContext, IUnitOfWork
{
    public EstablishmentContext(DbContextOptions<EstablishmentContext> options)
        : base(options) { }

    public DbSet<Establishment> Establishments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<ValidationResult>();
        modelBuilder.Ignore<Event>();

        foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
            e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            property.SetColumnType("varchar(100)");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EstablishmentContext).Assembly);
    }

    public async Task<bool> Commit()
    {
        return await base.SaveChangesAsync() > 0;
    }
}
