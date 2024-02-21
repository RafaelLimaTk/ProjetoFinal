using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using PF.Core.Data;
using PF.Core.Messages;
using PF.Reserva.API.Models;

namespace PF.Reserva.API.Data;

public class ReserveContext : DbContext, IUnitOfWork
{
    public ReserveContext(DbContextOptions<ReserveContext> options)
        : base(options) { }

    public DbSet<Reserver> Reserves { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<ValidationResult>();
        modelBuilder.Ignore<Event>();

        foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
            e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            property.SetColumnType("varchar(100)");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReserveContext).Assembly);
    }

    public async Task<bool> Commit()
    {
        return await base.SaveChangesAsync() > 0;
    }
}
