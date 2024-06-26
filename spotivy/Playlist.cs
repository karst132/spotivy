using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotivy
{
    internal class Playlist : SongCollection
    {
        public Playlist(String tempName = "New playlist")
        {
            _name = tempName;
        }

        public void ChangeName(string tempName)
        {
            _name = tempName;
        }

        public void AddSongs(List<Song> songs)
        {
            for (int i = 0; i < songs.Count; i++)
            {
                bool dupe = false;
                for( int j = 0; j < _songList.Count; j++)
                {
                    if(_songList[j] == songs[i])
                    {
                        dupe = true;
                    }
                }
                if(!dupe)
                {
                    _songList.Add(songs[i]);
                }
            }
        }

        public void RemoveSongBySong(Song song)
        {
            for(int i = 0; i < _songList.Count; i++)
            {
                if (_songList[i] == song)
                {
                    _songList.RemoveAt(i);
                    return;
                }
            }
        }

        //fuction RemoveSongByTitel is not planed to be inplementet/used but we may decide to change this later

        /*public void RemoveSongByTitel(string titel)
        {
            for (int i = 0; i < _songList.Count; i++)
            {
                if (_songList[i].Titel == titel)
                {
                    _songList.RemoveAt(i);
                    return;
                }
            }
        }*/
    }
}

