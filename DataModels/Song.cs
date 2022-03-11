using HansJhonnyAPI.Interfaces;

namespace HansJhonnyAPI.DataModels
{
    public class Song : IId
    {
        public int Id { get; internal set; }
        public string SongName { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public virtual Album Album { get; set; }
    }
}
