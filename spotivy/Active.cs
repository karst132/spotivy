namespace spotivy
{
    internal class Active : SongCollection
    {
        private bool _repeat = false;
        private bool _paused = false;

        int playingSong = 0;
        bool stop = true;
        public async void Play()
        {
            string line;
            stop = false;
            Console.WriteLine();
            while (!stop)
            {
                for (int i = 0; i <= _songList[playingSong].Length && !stop; i++)
                {
                    line = (_songList[playingSong].Titel + " | ");
                    for (int j = 0; j < _songList[playingSong].ArtistList.Count; j++)
                    {
                        line += (_songList[playingSong].ArtistList[j].UserName + " | ");
                    }
                    line += i / 5 + "/" + (_songList[playingSong].Length / 5);
                    Write(line);
                    Thread.Sleep(200);
                    if (_paused)
                    {
                        Write(line + " Paused");
                        while (_paused)
                        {
                            
                        }
                    }
                   

                }
                NextSong();
            }

            stop = true;
        }

        public void NextSong()// and skip
        {
            if (playingSong + 1 < SongList.Count)
            {
                playingSong++;
            }
            else if (_repeat)
            {
                playingSong = 0;
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

        private static void Write(string input)
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.WriteLine(input + new string(' ', Console.BufferWidth - input.Length));
        }
    }
}
