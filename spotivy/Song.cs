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

        }
        private Genre _genre;
      
        private int _length; //length in ticks 1 sec = 5 ticks
        public int Length { get { return _length; } }

        private List<Artist> _artistList;
        public List<Artist> ArtistList { get { return _artistList; } }

        private string _titel;
        public string Titel { get { return _titel; } }

        public Song(int length, string titel = "", List<Artist> artistList = null)
        {
            _length = length;
            _titel = titel;
            _artistList = artistList ?? new List<Artist>();
        }
    }
}
