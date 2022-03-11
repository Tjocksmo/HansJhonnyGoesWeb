using HansJhonnyAPI.DataModels;
using HansJhonnyAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HansJhonnyAPI.Controllers
{    
    [ApiController]
    [Route("[controller]")]
    public class ArtistController : ControllerBase
    {
        private static ArtistService _artistService;

        public ArtistController(ArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet("~/GetAllArtists")]
        public async Task<IActionResult> GetAllArtistsAsync()
        {
            var artists = await _artistService.GetAllArtistsAsync();
            if (artists is null)
            {
                return NoContent();
            }
            List<DtoArtist> dtoArtists = new List<DtoArtist>();

            int counter = 0;

            foreach (var artist in artists)
            {
                dtoArtists.Add(new DtoArtist
                {
                    Id = artist.Id,
                    Name = artist.Name,
                });
                if (artist.Albums.Count != 0)
                {
                    dtoArtists[counter].Albums = new List<DtoArtistWithAlbum>();
                    foreach (var album in artist.Albums)
                    {
                        dtoArtists[counter].Albums.Add(new DtoArtistWithAlbum
                        {
                            Id = album.Id,
                            AlbumName = album.Name,
                        });
                    }
                    counter++;
                }
            }
            return Ok(dtoArtists);
        }
        [HttpGet("~/GetArtistById")]
        public async Task<IActionResult> GetArtistByIdAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var artistById = await _artistService.GetByIdAsync(id);
            if (artistById is null)
            {
                return NoContent();
            }
           var dtoArtist = new DtoArtist();
            dtoArtist.Id = artistById.Id;
            dtoArtist.Name = artistById.Name;

            if(artistById.Albums.Count != 0)
            {
                dtoArtist.Albums = new List<DtoArtistWithAlbum>();
                for (int i = 0; i < artistById.Albums.Count; i++)
                {
                    dtoArtist.Albums.Add(new DtoArtistWithAlbum { Id = artistById.Albums[i].Id, AlbumName = artistById.Albums[i].Name });
                }
            }
            return Ok(dtoArtist);
        }

        [HttpPost("{name}")]
        public async Task<IActionResult> CreateNewArtistAsync(string name)
        {
            if (name is null)
            {
                return BadRequest();
            }
            var createdArtist = await _artistService.CreateArtistAsync(name);

            return Ok($"Id: {createdArtist.Id}. Artist name: {createdArtist.Name}");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArtistAsync(string artist, int id)
        {
            Artist newArtist = await _artistService.UpdateArtistAsync(artist, id);
            if (newArtist is null) return BadRequest($"No artist existing with Id: {id}. Please try again!");

            return Ok($"You updated: {newArtist.Name} with id: {newArtist.Id}");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletedArtistAsync(int id)
        {
            Artist deletedArtist = await _artistService.DeleteArtistAsync(id);
            if (deletedArtist is null) return NotFound();

            return Ok($"You deleted artist: {deletedArtist.Name} with id: {deletedArtist.Id}");
        }
    }
}
