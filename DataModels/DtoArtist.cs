using Newtonsoft.Json;
using System.Collections.Generic;

namespace HansJhonnyAPI.DataModels
{
    public class DtoArtist
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<DtoArtistWithAlbum> Albums { get; set; } = null;
    }
    public class DtoArtistWithAlbum
    {
        public int Id { get; set; }
        public string AlbumName { get; set; }       
    }
}
