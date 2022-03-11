using System.Collections.Generic;
using HansJhonnyAPI.Interfaces;

namespace HansJhonnyAPI.DataModels
{

    public class Album : IId
    {
        public int Id { get; internal set; }
        public string Name { get; set; }
        public int NumberOfSongs { internal get; set; }
        public virtual List<Song> Songs { get;  set; }
        public virtual Artist Artist { get; set; }
    }
}
