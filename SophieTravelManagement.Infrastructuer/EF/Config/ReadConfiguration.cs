namespace SophieTravelManagement.Infrastrcutuer.EF.Config;
using Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


internal sealed class ReadConfiguration :
    IEntityTypeConfiguration<TravelerCheckListReadModel>,
    IEntityTypeConfiguration<TravelerItemReadModel>
{
    public void Configure(EntityTypeBuilder<TravelerCheckListReadModel> builder)
    {
        builder.HasKey(p=>p.Id);
        builder
            .Property(p => p.Destination)
            .HasConversion(
                l => l.ToString(),
                l=> DestinationReadModel.Create(l));

        builder
            .HasMany(p => p.Items)
            .WithOne(p => p.TravelerCheckList);
        
        builder.ToTable("TravelerCheckList");
    }

    public void Configure(EntityTypeBuilder<TravelerItemReadModel> builder)
    {
        builder.ToTable("TravelerItems");
    }
}