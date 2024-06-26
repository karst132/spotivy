using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotivy
{
    internal class Song
    {
        public enum Genre
        {
            Unknown = -1,
            Classical,
            Popular,
            Blues,
            Country,
            EasyListening,
            Electronic,
            Folk,
            HipHop,
            Jazz,
            Pop,
            RAndBOrSoul,
            Rock,
            Metal,
            Punk
        }
        private List<Genre> _genres;
        public List<Genre> Genres { get { return _genres; } }

      
        private int _length; //length in ticks 1 sec = 5 ticks
        public int Length { get { return _length; } }

        private List<Artist> _artistList;
        public List<Artist> ArtistList { get { return _artistList; } }

        private string _titel;
        public string Titel { get { return _titel; } }

        public Song(int length, string titel = "", List<Artist> artistList = null, List<Genre> genres = null)
        {
            _length = length;
            _titel = titel;
            _artistList = artistList ?? new List<Artist>();
            _genres = genres ?? new List<Genre>([(Genre)(-1)]);
        }
    }
}
