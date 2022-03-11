using HansJhonnyAPI.DataModels;
using HansJhonnyAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HansJhonnyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumController : ControllerBase
    {
        private static AlbumService _albumService;

        public AlbumController(AlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet("~/GetAllAlbum")]
        public async Task <IActionResult> GetAllAsync()
        {
            var Albums = await _albumService.GetAlbumsAsync();
           
            if (Albums is null)
            {
                return NoContent();
            }

            return Ok(Albums);
        }

        [HttpGet("~/GetAlbumById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var album = await _albumService.GetByIdAsync(id);
            if (album is null)
            {
                return NotFound();
            }
                        
            var dtoAlbum = new DtoAlbum();
            dtoAlbum.Id = album.Id;
            dtoAlbum.Title = album.Name;
            dtoAlbum.Artist.Id = album.Artist.Id;
            dtoAlbum.Artist.Artist = album.Artist.Name;

            foreach (var song in album.Songs)
            {
                dtoAlbum.Songs.Add(new DtoAblumWithSongs { Id = song.Id, SongName = song.SongName });
            }
            return Ok(dtoAlbum);
        }

        [HttpPost("{title}/{id}")]
        public async Task<IActionResult> CreateAsync(int id, string title)
        {
            if (title is null)
            {
                return BadRequest();
            }

            var createdTitle = await _albumService.CreateAsync(id, title);
            if (createdTitle is null)
            {
                return BadRequest($"No artist existing with Id {id}. Please try again!");
            }

            return Ok($"Added album {createdTitle.Name}. With id: {createdTitle.Id}");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, string album)
        {
            Album newAlbum = await _albumService.UpdateAlbum(id, album);
            if (newAlbum is null)
            {
                return BadRequest($"No album existing with Id {id}. Please try again!");
            }            
            return Ok($"You updated id: {newAlbum.Id} to album: {newAlbum.Name}");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Album deletedAlbum = await _albumService.DeleteAlbum(id);
            if (deletedAlbum is null) return NotFound();

            return Ok($"You deleted album {deletedAlbum.Name}with id: {deletedAlbum.Id}");
        }
    }
}
