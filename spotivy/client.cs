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
            List<Song> tempSongs = [new Song(25, "song1")];
            currentPlay.SetSongList(tempSongs);

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
            Console.WriteLine();
            Console.WriteLine("search all");
            Console.WriteLine("search term is empty");
            Search("all", "");

            Console.WriteLine();
            Console.WriteLine("search term is 'te'");
            Search("all", "te");

            // search songs
            Console.WriteLine();
            Console.WriteLine("search songs");
            Console.WriteLine("search term is empty");
            Search("song", "");

            Console.WriteLine();
            Console.WriteLine("search term is 'te'");
            Search("song", "te");

            // search users
            Console.WriteLine();
            Console.WriteLine("search users");
            Console.WriteLine("search term is empty");
            Search("user", "");

            Console.WriteLine();
            Console.WriteLine("search term is 'li'");
            Search("user", "li");

            // search albums
            Console.WriteLine();
            Console.WriteLine("search albums");
            Console.WriteLine("search term is empty");
            Search("album", "");

            Console.WriteLine();
            Console.WriteLine("search term is 'te'");
            Search("album", "te");

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

        public void Search(string searchType, string searchTerm)
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
    }
}
