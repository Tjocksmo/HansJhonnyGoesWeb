using HansJhonnyAPI.DataModels;
using HansJhonnyAPI.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HansJhonnyAPI.Services
{
    public class ArtistService
    {
        private readonly IDataSqlAccess _dataSqlAccess;
        public ArtistService(IDataSqlAccess dataSqlAccess)
        {
            _dataSqlAccess = dataSqlAccess;
        }
        public async Task<List<Artist>> GetAllArtistsAsync()
        {
            var artists = await _dataSqlAccess.GetAsync<Artist>() as List<Artist>;
            if (artists is null) return null;

            
            return artists;
        }

        public async Task<Artist> GetByIdAsync(int id)
        {
            var artistId = await _dataSqlAccess.GetById<Artist>(id);
            if (artistId is null) return null;
            if (artistId.Id != id) return null;
            if (id == 0) return null;

            return artistId;
        }

        public async Task<Artist> CreateArtistAsync(string name)
        {        
            var artist = new Artist();
            artist.Name = name;

            if (artist.Id != 0)
            {
                return null;
            }
            await _dataSqlAccess.Create(artist);

            return artist;
        }

        public async Task<Artist> UpdateArtistAsync(string newArtistToUppdate, int id)
        {
            var artistToUpdate = await _dataSqlAccess.GetById<Artist>(id);
            if (artistToUpdate is null) return null;
            if (artistToUpdate.Id != id) return null;
            if (id == 0) return null;

            artistToUpdate.Name = newArtistToUppdate;

            if (artistToUpdate is null) return null;
            
            await _dataSqlAccess.Update(newArtistToUppdate);

            return artistToUpdate;
        }

        public async Task<Artist> DeleteArtistAsync(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var artistToDelete = await _dataSqlAccess.GetById<Artist>(id);
            if (artistToDelete == null)
            {
                return null;
            }
            await _dataSqlAccess.Delete(artistToDelete);
            return artistToDelete;
        }
    }
}
