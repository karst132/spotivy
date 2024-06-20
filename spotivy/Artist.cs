using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotivy
{

    internal class Artist
    {
        private string _userName;
        public string UserName { get { return _userName; } }
        private List<Song> _songList;
        public List<Song> SongList { get { return _songList; } }
        private List<Album> _albumList;
        public List<Album> AlbumList { get { return _albumList; } }

        public Artist(string UserName, List<Song> SongList = null, List<Album> AlbumList = null)
        {
            _userName = UserName;
            _songList = SongList ?? new List<Song>();
            _albumList = AlbumList ?? new List<Album>();
        }
    }
}
