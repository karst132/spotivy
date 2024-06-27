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

        /*public async Task RunProgramAsync()
        {
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
        }*/

        //Cases that use a Thread use a while loop to stop it from continuing in the code
        public async Task Case1() //als gebruiker wil ik alle songs kunnen zien songs
        {
            Search("song");
        }

        public async Task Case2() //als gebruiker wil ik songs kunnen zoeken
        {
            Search("song", "1");
        }

        public async Task Case3() //als gebruiker wil ik nummers kunnen afspellen 
        {
            SetActiveSong("song", "0");
            Thread t1 = new Thread(Play)
            {
                Name = "Thread1"
            };
            t1.Start();
            while (t1.IsAlive) { }
        }

        public async Task Case4() //pause and play
        {
            SetActiveSong("song", "0");
            Thread t1 = new Thread(Play)
            {
                Name = "Thread1"
            };
            Thread t2 = new Thread(PauseAndPlay)
            {
                Name = "Thread2"
            };
            t1.Start();
            t2.Start();
            while (t1.IsAlive || t2.IsAlive) { }
        }

        public async Task Case5() //reapeat
        {
            SetActiveSong("song", "0");
            currentPlay.Repeat();
            Thread t1 = new Thread(Play)
            {
                Name = "Thread1"
            };
            Thread t2 = new Thread(StopMediumTime)
            {
                Name = "Thread1"
            };
            t1.Start();
            t2.Start();
            while (t1.IsAlive || t2.IsAlive) { }
            currentPlay.Repeat();
        }

        public async Task Case6() //skip
        {
            SetActiveSong("song", "0");
            Thread t1 = new Thread(Play)
            {
                Name = "Thread1"
            };
            Thread t2 = new Thread(Skip)
            {
                Name = "Thread1"
            };
            t1.Start();
            t2.Start();
            while (t1.IsAlive || t2.IsAlive) { }
        }

        public async Task Case7() //skip and reapeat
        {
            SetActiveSong("song", "0");
            currentPlay.Repeat();
            Thread t1 = new Thread(Play)
            {
                Name = "Thread1"
            };
            Thread t2 = new Thread(Skip)
            {
                Name = "Thread1"
            };
            Thread t3 = new Thread(StopMediumTime)
            {
                Name = "Thread1"
            };
            t1.Start();
            t2.Start();
            t3.Start();
            while (t1.IsAlive || t2.IsAlive || t3.IsAlive) { }
            currentPlay.Repeat();
        }

        public async Task Case8() //stop
        {
            SetActiveSong("song", "0");
            Thread t1 = new Thread(Play)
            {
                Name = "Thread1"
            };
            Thread t2 = new Thread(StopShortTime)
            {
                Name = "Thread1"
            };
            t1.Start();
            t2.Start();
            while (t1.IsAlive || t2.IsAlive) { }
        }

        public async Task Case9() //shows all in client
        {
            Search("all", "");
        }

        public async Task Case10() //shearches in all of client
        {
            Search("all", "1");
        }
        
        public async Task Case11() //shows all users
        {
            Search("user", "");
        }

        public async Task Case12() //searches user in client
        {
            Search("user", "1");
        }

        public async Task case13() //shows all albums
        {
            Search("album", "");
        }

        public async Task case14() //searches album in client
        {
            Search("album", "1");
        }

        void Play()
        {
            currentPlay.Play();
        }

        void PauseAndPlay()
        {
            Thread.Sleep(3000);
            currentPlay.Pause();
            Thread.Sleep(3000);
            currentPlay.Pause();
        }

        void StopShortTime()
        {
            Thread.Sleep(3000);
            currentPlay.Stop();
        }

        void StopMediumTime()
        {
            Thread.Sleep(8000);
            currentPlay.Stop();
        }

        void StopLongTime()
        {
            Thread.Sleep(16000);
            currentPlay.Stop();
        }

        void Skip()
        {
            Thread.Sleep(3000);
            currentPlay.NextSong();
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
