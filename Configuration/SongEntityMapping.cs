using HansJhonnyAPI.DataModels;
using Microsoft.EntityFrameworkCore;

namespace HansJhonnyAPI.Configuration
{
    public class SongEntityMapping : EntityConfiguration<Song>
    {
        protected override void Configure(EntityConfigurator<Song> configurator)
        {
            configurator
                .Has(x => x.HasKey(p => p.Id))

                .Has(x => x.Property(p => p.Minutes))

                .Has(x => x.Property(p => p.Seconds))

                .Has(x => x.Property(p => p.SongName))

                .Has(x => x.HasOne(p => p.Album).WithMany(p => p.Songs))

                .Has(x => x.HasOne(p => p.Album)
                    .WithMany(p => p.Songs)
                    .OnDelete(DeleteBehavior.Cascade)); 
        }
    }
}
