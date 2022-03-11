using HansJhonnyAPI.DataModels;
using Microsoft.EntityFrameworkCore;

namespace HansJhonnyAPI.Configuration
{
    public class AlbumEntityMapping : EntityConfiguration<Album>
    {
        protected override void Configure(EntityConfigurator<Album> configurator)
        {
            configurator                

                .Has(x => x.HasKey(p => p.Id))

                .Has(x => x.Property(p => p.Name))

                .Has(x => x.Property(p => p.NumberOfSongs))

                .Has(x => x.HasMany(p => p.Songs).WithOne(p => p.Album))

                .Has(x => x.HasOne(p => p.Artist)
                    .WithMany(p => p.Albums)
                    .OnDelete(DeleteBehavior.Cascade));                
        }
    }
}
