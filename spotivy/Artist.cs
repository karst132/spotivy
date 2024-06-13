using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotivy
{

    internal class Artist
    {
        public Artist(string UserName, List<Song> SongList, List<Album> AlbumList) 
        {
            _userName = UserName;
            _songList = SongList;
            _albumList = AlbumList;
        }


        private string _userName;
        private List<Song> _songList;
        private List<Album> _albumList;
    }
}
