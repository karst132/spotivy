using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotivy
{
    internal class Album : SongCollection
    {
        private string _artistName;
        public string ArtistName { get { return _artistName; } }

        public Album(Artist artist, string name ,List<Song> songs)
        {
            _artistName = artist.UserName;
            _name = name;
            _songList = songs;
        }
    }
}
