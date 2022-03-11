using System.Collections.Generic;
using HansJhonnyAPI.Interfaces;

namespace HansJhonnyAPI.DataModels
{
    public class Artist : IId
    {
        public int Id { get; internal set; }
        public string Name { get; set; }
        public int NumberOfAlbums { internal get; set; }
        public virtual List <Album> Albums { get; set; }
    }
}
