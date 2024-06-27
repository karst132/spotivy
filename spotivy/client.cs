using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace spotivy
{
    internal class Client
    {
        User mainUser = new("mainuser");
        List<User> _users;
        List<Album> _albums;
        List<Artist> _artists;
        List<Song> _songs;
        public Client(List<User> Users, List<Album> Albums, List<Artist> Artists, List<Song> Songs) {
            _users = Users;
            _albums = Albums;
            _artists = Artists;
            _songs = Songs;
        }

        SongCollection currentPlay = new();

        string activity = "";

        public async Task RunProgramAsync()
        {

            // search songs
            Console.WriteLine();
            Console.WriteLine("search songs");
            Console.WriteLine("search term is empty");
            Console.WriteLine();
            Search("song");

            Console.WriteLine();
            Console.WriteLine("search term is '1'");
            Search("song", "1");

            //currentPlay.SetSongList(_albums[0].SongList);

            Console.WriteLine();
            Console.WriteLine("Select song(s) to play");
            Console.WriteLine("term is '1'");
            SetActiveSong("song", "1");
            Console.WriteLine();

            //play song
            Console.WriteLine("play song");
            await Run();

            //pause and start
            Console.WriteLine();
            Console.WriteLine("pause and start");
            activity = "pause";
            await Run();

            // repeat song
            Console.WriteLine();
            Console.WriteLine("repeat song");
            activity = "repeat";
            await Run();

            // skip song
            Console.WriteLine();
            Console.WriteLine("skip song");
            activity = "skip";
            await Run();

            // skip while repeat song
            Console.WriteLine();
            Console.WriteLine("skip song while repeat");
            activity = "skipAndRepeat";
            await Run();


            // stop song
            Console.WriteLine();
            Console.WriteLine("stop song");
            activity = "stop";
            await Run();

            // search all
            Console.WriteLine();
            Console.WriteLine("search all");
            Console.WriteLine("search term is empty");
            Search("all", "");

            Console.WriteLine();
            Console.WriteLine("search term is '1'");
            Search("all", "1");

            // search users
            Console.WriteLine();
            Console.WriteLine("search users");
            Console.WriteLine("search term is empty");
            Search("user", "");

            Console.WriteLine();
            Console.WriteLine("search term is '1'");
            Search("user", "1");

            // search albums
            Console.WriteLine();
            Console.WriteLine("search albums");
            Console.WriteLine("search term is empty");
            Search("album", "");

            Console.WriteLine();
            Console.WriteLine("search term is '1'");
            Search("album", "1");

            // view user's playlists
            Console.WriteLine();
            Console.WriteLine("view user playlist");

            
            Console.WriteLine("you are viewing user " + _users[0].Name);
            _users[0].ViewAllPlaylistsOfUser();

            // play one of user's playlists
            // stop playlist
            // view own playlists
            // copy playlist
            // view own playlists
            // friend user
            // unfriend user

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

            Console.WriteLine();
            Console.WriteLine("main user create playlist named hello world");
            mainUser.AddPlaylist("hello world");
            Console.WriteLine("");
            Console.WriteLine("Main user shows all playlists");
            mainUser.ViewAllPlaylistsOfUser();

            // add songs
            // add another playlist to previously created one
            // add album to previously created one
            // play playlist
            // stop playlist

            Console.WriteLine("");
            Console.WriteLine("Main user removes previous created playlist");
            mainUser.RemovePlaylist("hello world");
            Console.WriteLine("");
            Console.WriteLine("Main user shows all playlists");
            mainUser.ViewAllPlaylistsOfUser();
        }

        public async Task Run()
        {
            Thread t1 = new Thread(Method1)
            {
                Name = "Thread1"
            };
            Thread t2 = new Thread(Method2)
            {
                Name = "Thread2"
            };
            t1.Start();
            t2.Start();
            while (t1.IsAlive || t2.IsAlive)
            {

            }
        }

        void Method1()
        {
            currentPlay.Play();
        }
        void Method2()
        {
            switch (activity){
                case "pause":
                    Thread.Sleep(3000);
                    currentPlay.Pause();
                    Thread.Sleep(3000);
                    currentPlay.Pause();
                    break;

                case "repeat":
                    currentPlay.Repeat();
                    Thread.Sleep(6000);
                    currentPlay.Repeat();
                    break;

                case "skip":
                    Thread.Sleep(3000);
                    currentPlay.NextSong();
                    break;

                case "skipAndRepeat":
                    currentPlay.Repeat();
                    Thread.Sleep(3000);
                    currentPlay.NextSong();
                    Thread.Sleep(3000);
                    currentPlay.Repeat();
                    break;

                case "stop":
                    Thread.Sleep(3000);
                    currentPlay.Stop();
                    break;

                default:

                break;

            }
        }

        public void Search(string searchType, string searchTerm = "")
        {
            switch (searchType)
            {
                case "all":
                    foreach (Song song in _songs)
                    {
                        string titel = song.Titel.ToLower();
                        if (titel.Contains(searchTerm))
                        {
                            Console.WriteLine("Song: " + song.Titel);
                        }
                    }

                    foreach (User user in _users)
                    {
                        string name = user.Name.ToLower();
                        if (name.Contains(searchTerm))
                        {
                            Console.WriteLine("user: " + user.Name);
                        }
                    }

                    foreach (Album album in _albums)
                    {
                        string Name = album.Name.ToLower();
                        if (Name.Contains(searchTerm))
                        {
                            Console.WriteLine("album: " + album.Name);
                        }
                    }
                    break;

                case "song":
                    foreach (Song song in _songs)
                    {
                        string titel = song.Titel.ToLower();
                        if (titel.Contains(searchTerm))
                        {
                            Console.WriteLine(song.Titel);
                        }
                    }
                    break;

                case "user":
                    foreach (User user in _users)
                    {
                        string name = user.Name.ToLower();
                        if (name.Contains(searchTerm))
                        {
                            Console.WriteLine(user.Name);
                        }
                    }
                    break;

                case "album":
                    foreach (Album album in _albums)
                    {
                        string Name = album.Name.ToLower();
                        if (Name.Contains(searchTerm))
                        {
                            Console.WriteLine(album.Name);
                        }
                    }
                    break;
            }
        }

        public void SetActiveSong(string searchType, string searchTerm = "")
        {
            List<Song> tempSongList = new List<Song>();
            switch (searchType)
            {
                case "song":
                    foreach (Song song in _songs)
                    {
                        string titel = song.Titel.ToLower();
                        if (titel.Contains(searchTerm))
                        {
                            Console.WriteLine(song.Titel);
                            tempSongList.Add(song);
                        }
                    }
                    break;

                case "album":
                    foreach (Album album in _albums)
                    {
                        string Name = album.Name.ToLower();
                        if (Name.Contains(searchTerm))
                        {
                            Console.WriteLine(album.Name);
                            foreach (Song albumSong in album.SongList) 
                            { 
                                tempSongList.Add(albumSong);
                            }
                            
                        }
                    }
                    break;
            }
            if(tempSongList.Count != 0) {
                currentPlay.SetSongList(tempSongList);
            }
        }
    }
}
