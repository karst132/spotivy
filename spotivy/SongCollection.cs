using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotivy
{
    internal class SongCollection
    {
        protected List<Song> _songList = new List<Song>();
        public List<Song> SongList { get { return _songList; } }
        protected string _name;
        public string Name { get { return _name; } }

        //following code used to activate and play the song

        private bool _repeat = false;
        private bool _paused = false;

        int playingSong = 0;
        bool stop = true;
        bool resetSongTime = false;
        public async void Play()
        {
            string line;
            stop = false;
            Console.WriteLine();
            while (!stop)
            {
                for (int i = 0; i <= _songList[playingSong].Length && !stop; i++)
                {
                    if (resetSongTime)
                    {
                        resetSongTime = false;
                        i = 0;
                    }
                    line = (_songList[playingSong].Titel + " | ");
                    if (_songList[playingSong].ArtistNameList.Count > 0)
                    {
                        line += "artist(s) ";
                        for (int j = 0; j < _songList[playingSong].ArtistNameList.Count; j++)
                        {
                            line += (_songList[playingSong].ArtistNameList[j] + " ");
                        }
                        line += "| ";
                    }
                    
                    if (_songList[playingSong].Genres.Count > 0)
                    {
                        line += "genre(s) ";
                        for (int j = 0; j < _songList[playingSong].Genres.Count; j++)
                        {
                            line += (_songList[playingSong].Genres[j] + " ");
                        }
                        line += "| ";
                    }
                    if(! _paused)
                    {
                        line += i / 5 + "/" + (_songList[playingSong].Length / 5);
                    }
                    else
                    {
                        line += i / 5 + "/" + (_songList[playingSong].Length / 5) + " | paused";
                    }
                    Write(line);
                    while (_paused)
                    {

                    }
                    
                    Thread.Sleep(200);
                }
                NextSong();
            }

            stop = true;
        }

        //NextSong() works but not as a skip fuction
        public void NextSong()// and skip
        {
            if (playingSong + 1 < SongList.Count)
            {
                playingSong++;
                resetSongTime = true;
            }
            else if (_repeat)
            {
                playingSong = 0;
                resetSongTime = true;
            }
            else
            {
                Stop();
            }
        }

        public void Pause()
        {
            if (_paused)
            {
                _paused = false;
            }
            else
            {
                _paused = true;
            }
        }

        public void Stop()
        {
            stop = true;
        }

        public void Repeat()
        {
            if (_repeat)
            {
                _repeat = false;
            }
            else
            {
                _repeat = true;
            }
        }

        public void SetSongList(List<Song> songList)
        {
            _songList = songList;
        }

        private static void Write(string input)//used to (over)write on the same line
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.WriteLine(input + new string(' ', Console.BufferWidth - input.Length));
        }
    }
}
