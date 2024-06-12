using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotivy
{
    internal class Client
    {
        List<User> users = new List<User>();
        List<Album> albums = new List<Album>();
        List<Artist> artists = new List<Artist>();
        List<Song> songs = new List<Song>();

        SongCollection currentPlay;

        public void RunProgram()
        {
            // play song
            // pause and start
            // repeat song
            // skip song
            // stop song

            // play playlist
            // skip to next
            // pause song
            // stop playlist
            // repeat playlist

            // play album
            // skip to next
            // pause song
            // stop album
            // repeat album

            // search all
            // search songs
            // search users
            // search albums

            // view user
            // view user's playlists
            // play one of user's playlists
            // stop playlist
            // view own playlists
            // copy playlist
            // view own playlists
            // friend user
            // unfriend user

            // view own playlists
            // create playlist (name "hello world")
            // view own playlists
            // add songs
            // add another playlist to previously created one
            // add album to previously created one
            // play playlist
            // stop playlist
            // delete playlist
        }
    }
}
