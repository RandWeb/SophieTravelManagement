using Microsoft.EntityFrameworkCore;
using SophieTravelManagement.Domain.Entities;
using SophieTravelManagement.Domain.ValueObjects;
using SophieTravelManagement.Infrastrcutuer.EF.Config;

namespace SophieTravelManagement.Infrastrcutuer.EF.Contexts;

internal sealed class WriteDbContext : DbContext
{
    public DbSet<TravelerCheckList> TravelerCheckLists { get; set; }

    public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("TravelerCheckList");

        var configuration = new WriteConfiguration();

        modelBuilder.ApplyConfiguration<TravelerCheckList>(configuration);
        modelBuilder.ApplyConfiguration<TravelerItem>(configuration);
    }
}