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

        public void AddSongs(List<Song> songs)
        {
            List<Song> tempSongs = new List<Song>();
            foreach (Song s in songs)
            {
                bool foundArtistName = false;
                foreach (string artistName in s.ArtistNameList)
                {
                    if (artistName == _userName) 
                    { 
                        foundArtistName = true;
                    }
                    
                }
                if (foundArtistName)
                {
                    tempSongs.Add(s);
                }
            }

            _songList.AddRange(tempSongs);
        }

        public void AddAlbums(List<Album> albums)
        {
            List<Album> tempAlbums = new List<Album>();
            foreach (Album a in albums)
            {
                if(a.ArtistName == _userName)
                {
                    tempAlbums.Add(a);
                }
                
                
            }
            _albumList.AddRange(tempAlbums);
        }
    }
}
