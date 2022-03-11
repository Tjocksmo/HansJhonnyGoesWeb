using HansJhonnyAPI.DataModels;
using HansJhonnyAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HansJhonnyAPI.Controllers
{    
    [ApiController]
    [Route("[controller]")]
    public class SongController : ControllerBase
    {
        private static SongService _songService;

        public SongController(SongService songService)
        {
            _songService = songService;
        }

        [HttpGet("~/GetAllSongs")]
        public async Task<IActionResult> GetAllSongsAsync()
        {
            var song = await _songService.GetAllSongsAsync();
            if (song is null)
            {
                return NoContent();
            }
            return Ok(song);
        }
        [HttpGet("~/GetSongsById")]
        public async Task<IActionResult> GetSongsByIdAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var artistById = await _songService.GetSongByIdAsync(id);
            if (artistById is null)
            {
                return NotFound($"No song found with id: {id}");
            }
            var dtoSong = new DtoSong();
            dtoSong.Id = artistById.Id;
            dtoSong.Name = artistById.SongName;
            dtoSong.Minutes = artistById.Minutes;
            dtoSong.Seconds = artistById.Seconds;
            dtoSong.Album.AlbumName = artistById.Album.Name;
            dtoSong.Album.Id = artistById.Album.Id;
            dtoSong.Artist.ArtistName = artistById.Album.Artist.Name;
            dtoSong.Artist.Id = artistById.Album.Artist.Id;
            return Ok(dtoSong);
        }

        [HttpPost("{id}/{title}/{minutes}/{seconds}")]
        public async Task<IActionResult> CreateNewSong(int id, string title, int minutes, int seconds )
        {
            if (id < 1) return BadRequest();
            if (title is null) return BadRequest();
            if (minutes < 0 || minutes > 59) return BadRequest();
            if (seconds < 0 || seconds > 59) return BadRequest();

            var createdSong = await _songService.CreateNewSong(id, title, minutes, seconds);

            if (createdSong is null)
            {
                return BadRequest($"No album existing with Id {id}. Please try again!");
            }
            
            return createdSong.Seconds < 10 ? Ok($"Added song {createdSong.SongName}. Length: {createdSong.Minutes}:0{createdSong.Seconds} With id: {createdSong.Id}")
                                            : Ok($"Added song {createdSong.SongName}. Length: {createdSong.Minutes}:{createdSong.Seconds} With id: {createdSong.Id}");

        }

        [HttpPut("{id}/{song}/{minutes}/{seconds}")]
        public async Task<IActionResult> UpdateSongAsync(int id, string song, int minutes, int seconds)
        {
            if (id < 1) return BadRequest();
            if (song is null) return BadRequest();
            if (minutes < 0 || minutes > 59) return BadRequest();
            if (seconds < 0 || seconds > 59) return BadRequest();

            Song changeSong = await _songService.UpdateSongAsync(id, song, minutes, seconds);

            if (changeSong is null) return BadRequest($"No song existing with Id: {id}. Please try again!");

            return Ok($" Changed song: {changeSong.SongName} with id {changeSong.Id} length: {changeSong.Minutes}:{changeSong.Seconds}");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletedSongAsync(int id)
        {
            Song deletedSong = await _songService.DeleteSongAsync(id);
            if (deletedSong is null) return NotFound();

            return Ok($"Deleted song: {deletedSong.SongName} with id: {deletedSong.Id}");
        }
    }
}
