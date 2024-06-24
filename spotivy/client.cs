﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotivy
{
    internal class Client
    {
        public Client(List<User> Users, List<Album> Albums, List<Artist> Artists, List<Song> Songs) {
            List<User> _users = Users;
            List<Album> _albums = Albums;
            List<Artist> _artists = Artists;
            List<Song> _songs = Songs;
        }
        
        Active currentPlay = new Active();

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
    }
}
