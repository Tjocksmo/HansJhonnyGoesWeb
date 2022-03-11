
namespace HansJhonnyAPI.DataModels
{
    public class DtoSong
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public DtoAlbumToSong Album { get; set; } = new DtoAlbumToSong();
        public DtoArtistWhoMadeSong Artist { get; set; } = new DtoArtistWhoMadeSong();
    }
    public class DtoAlbumToSong
    {
        public int Id { get; set; }
        public string AlbumName { get; set; }
    }
    public class DtoArtistWhoMadeSong
    {
        public int Id { get; set; }
        public string ArtistName { get; set; }
    }
}
