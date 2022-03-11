using System.Collections.Generic;

namespace HansJhonnyAPI.DataModels
{
    public class DtoAlbum
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DtoAlbumWithArtist Artist { get; set; } = new DtoAlbumWithArtist();
        public List<DtoAblumWithSongs> Songs { get; set; } = new List<DtoAblumWithSongs>();
    }
    public class DtoAblumWithSongs
    {
        public int Id { get; set; }
        public string SongName { get; set; }
    }
    public class DtoAlbumWithArtist
    {
        public int Id { get; set; }
        public string Artist { get; set; }
    }
}
