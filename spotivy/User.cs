using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotivy
{
    internal class User
    {
        private List<Playlist> _playlistList; //list of all playlists
        public List<Playlist> PlaylistList { get { return _playlistList; } }
        private List<User> _friendList;
        private string _name;

        public void AddFriend(User user)
        {

        }

        public void RemoveFriend(User user) 
        {

        }

        public void ViewPlaylistOfUser(Playlist playlist ,User user)
        {

        }

        public void ViewFriend(User user) 
        {

        }

        public void AddPlaylist(string name)
        {

        }

        public void RemovePlaylist(Playlist playlist)
        {

        }
    }
}
