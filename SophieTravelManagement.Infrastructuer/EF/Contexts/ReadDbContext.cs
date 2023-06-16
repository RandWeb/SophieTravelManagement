using Microsoft.EntityFrameworkCore;
using SophieTravelManagement.Domain.Entities;
using SophieTravelManagement.Domain.ValueObjects;
using SophieTravelManagement.Infrastrcutuer.EF.Config;
using SophieTravelManagement.Infrastrcutuer.EF.Models;

namespace SophieTravelManagement.Infrastrcutuer.EF.Contexts;

internal sealed class ReadDbContext : DbContext
{
    public DbSet<TravelerCheckList> TravelerCheckLists { get; set; }

    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("TravelerCheckList");

        var configuration = new ReadConfiguration();

        modelBuilder.ApplyConfiguration<TravelerCheckListReadModel>(configuration);
        modelBuilder.ApplyConfiguration<TravelerItemReadModel>(configuration);
    }
}