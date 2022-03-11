using HansJhonnyAPI.DataModels;
using HansJhonnyAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansJhonnyAPI.Services
{
    public class AlbumService
    {
        private readonly IDataSqlAccess _dataSqlAccess;
        public AlbumService(IDataSqlAccess dataAccess)
        {
            _dataSqlAccess = dataAccess;
        }
        public async Task<IEnumerable<Album>> GetAlbumsAsync()
        {
            return await _dataSqlAccess.GetAsync<Album>();
        }
        public async Task<Album> GetByIdAsync(int id)
        {
            var albumId = await _dataSqlAccess.GetById<Album>(id);
            if (albumId is null) return null;
            if (id == 0) return null;

            return albumId;
        }

        internal async Task<Album> CreateAsync(int id, string title)
        {
            var artist = await _dataSqlAccess.GetById<Artist>(id);
            var albumName = new Album();

            
            albumName.Name = title;
            albumName.Artist = artist;

            if (artist is null)
            {
                return null;
            }

            if (albumName.Id != 0)
            {
                return null;
            }
            artist.NumberOfAlbums++;

            await _dataSqlAccess.Create(albumName);

            return albumName;
        }

        internal async Task<Album> UpdateAlbum(int id, string newAlbumName)
        {            
            var albumToUpdate = await _dataSqlAccess.GetById<Album>(id);
            if (albumToUpdate is null) return null;
            if (albumToUpdate.Id != id) return null;
            if (id == 0) return null;

            albumToUpdate.Name = newAlbumName;

            //var album = new Album() { Name = newAlbumName};
            if (albumToUpdate is null) return null;

            await _dataSqlAccess.Update(albumToUpdate);

            return albumToUpdate;
        }

        public async Task<Album> DeleteAlbum(int id)
        {
            if (id == 0) return null;

            var albumToDelete = await _dataSqlAccess.GetById<Album>(id);
            if (albumToDelete is null) return null;
            if (albumToDelete.Id != id) return null;

            albumToDelete.Artist.NumberOfAlbums--;

            await _dataSqlAccess.Delete(albumToDelete);
            
            return albumToDelete;
        }
    }
}
