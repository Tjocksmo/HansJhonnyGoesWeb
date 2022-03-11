using HansJhonnyAPI.DataModels;
using HansJhonnyAPI.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HansJhonnyAPI.Services
{
    public class SongService
    {
        private readonly IDataSqlAccess _dataSqlAccess;
        public SongService(IDataSqlAccess dataSqlAccess)
        {
            _dataSqlAccess = dataSqlAccess;
        }
        public async Task <IEnumerable<Song>> GetAllSongsAsync()
        {
            var songs = await _dataSqlAccess.GetAsync<Song>();
            return songs;
        }

        public async Task<Song> GetSongByIdAsync(int id)
        {
            var songsById = await _dataSqlAccess.GetById<Song>(id);
            if (songsById is null) return null;
            if (songsById.Id != id) return null;
            if (id == 0) return null;

            return songsById; // dtoSong;
        }

        internal async Task<Song> CreateNewSong(int id, string title, int minutes, int seconds)
        {
            Album albumId = new Album();
            albumId = await _dataSqlAccess.GetById<Album>(id);
            var songName = new Song();
            
            songName.SongName = title;
            songName.Minutes = minutes;
            songName.Seconds = seconds;
            songName.Album = albumId;

            if(albumId is null)
            {
                return null;
            }

            if(songName.Id != 0)
            {
                return null;
            }

            albumId.NumberOfSongs++;

            await _dataSqlAccess.Create(songName);

            return songName;
        }

        internal async Task<Song> UpdateSongAsync(int id, string newSongToUpdate, int minutes, int seconds)
        {
            var songToUpdate = await _dataSqlAccess.GetById<Song>(id);
            if (songToUpdate is null) return null;
            if (songToUpdate.Id != id) return null;
            if (id == 0) return null;

            songToUpdate.SongName = newSongToUpdate;
            songToUpdate.Minutes = minutes;
            songToUpdate.Seconds = seconds;

            if (songToUpdate is null) return null;

            await _dataSqlAccess.Update(songToUpdate);
                
            return songToUpdate;
        }

        internal async Task<Song> DeleteSongAsync(int id)
        {
            if (id == 0) return null;
            var songToDelete = await _dataSqlAccess.GetById<Song>(id);
            if (songToDelete is null) return null;
            if (songToDelete.Id != id) return null;

            songToDelete.Album.NumberOfSongs--;

            await _dataSqlAccess.Delete(songToDelete);

            return songToDelete;
        }
    }
}
