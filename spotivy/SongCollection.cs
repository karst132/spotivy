using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotivy
{
    internal class SongCollection
    {
        protected List<Song> _songList;
        public List<Song> SongList { get { return _songList; } }
        protected string _name;
        public string Name { get { return _name; } }
    }
}
