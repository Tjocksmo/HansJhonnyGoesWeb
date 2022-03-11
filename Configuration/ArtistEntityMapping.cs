using HansJhonnyAPI.DataModels;

namespace HansJhonnyAPI.Configuration
{
    public class ArtistEntityMapping : EntityConfiguration<Artist>
    {
        protected override void Configure(EntityConfigurator<Artist> configurator)
        {
            configurator
                .Has(x => x.HasKey(p => p.Id))

                .Has(x => x.Property(p => p.Name))

                .Has(x => x.Property(p => p.NumberOfAlbums))

                .Has(x => x.HasMany(p => p.Albums).WithOne(p => p.Artist));
        }
    }
}
