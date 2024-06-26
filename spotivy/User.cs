using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotivy
{
    internal class User
    {
        private List<User> _friendList = new List<User>();
        private List<Playlist> _playlistList = new List<Playlist>();
        public List<Playlist> Playlists { get { return _playlistList; } }
        private string _name;
        public string Name { get { return _name; } }
        public User(string name)
        {
            _name = name;
        }

        public void AddFriend(User user)
        {
            user.RecieveFriendRequest(this);
        }

        public void RecieveFriendRequest(User user)
        {
            _friendList.Add(user);
            user._friendList.Add(this);
        }

        public void RemovedByAnother(User user)
        {
            _friendList.Remove(user);
        }

        public void RemoveFriend(User user) 
        {
            if  (_friendList.Contains(user)) {
                _friendList.Remove(user);
                user.RemovedByAnother(this);
            }
            else
            {
                Console.WriteLine("You are not friends with a user " + user.Name);
                Console.WriteLine("");
            }
        }

        public void ViewFriendsList()
        {
            if (_friendList.Count == 0)
            {
                Console.WriteLine("Your friendslist is empty :(");
            }
            else
            {
                foreach (User user in _friendList)
                {
                    Console.WriteLine(user.Name);
                }
                Console.WriteLine("");
            }
        }

        public void ViewPlaylistOfUser(Playlist playlist ,User user)
        {

        }

        public void AddPlaylist(string name = "new playlist")
        {
            _playlistList.Add(new Playlist(name));
        }

        public void RemovePlaylist(Playlist playlist)
        {
            if (_playlistList.Contains(playlist))
            {
                _playlistList.Remove(playlist);
            }
        }
    }
}
