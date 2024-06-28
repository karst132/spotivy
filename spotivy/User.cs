using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                    Console.Write(user.Name + " | ");
                }
                Console.WriteLine();
            }
        }

        
        public void ViewPlaylistOfUser(string playlistName)
        {
            foreach (Playlist playlist in _playlistList)
            {
                if (playlist.Name == playlistName)
                {
                    Console.WriteLine(playlist.Name + " has " + playlist.SongList.Count + " songs ");
                    Console.Write("these songs are: ");
                    foreach(Song song in playlist.SongList)
                    {
                        Console.Write(song.Titel + " | ");
                    }
                    Console.WriteLine();
                    return;
                }
            }
            if (_playlistList.Count == 0)
            {
                Console.WriteLine("No playlists found for this user");
            }
        }

        public void ViewAllPlaylistsOfUser()
        {
            foreach (Playlist playlist in _playlistList)
            {
                Console.WriteLine(playlist.Name + " has " + playlist.SongList.Count + " songs ");
            }
            if(_playlistList.Count == 0)
            {
                Console.WriteLine("No playlists found for this user");
            }
        }

        public void AddPlaylist(string playlistName = "new playlist")
        {
            if (_playlistList.Any(cus => cus.Name == playlistName) == false){
                _playlistList.Add(new Playlist(playlistName));
            }
            
        }

        public void RemovePlaylist(string playlistName)
        {
            try
            {
                foreach (Playlist playlist in _playlistList)
                {
                    if(playlist.Name == playlistName)
                    {
                        _playlistList.Remove(playlist);
                        break;
                    }
                }
            }
            catch
            {
                Console.WriteLine("fault?");
            }
        }

        public void CopyPlaylistsAndAlbum(SongCollection playlistToCopy)
        {
            Playlist tempPlaylist = new(playlistToCopy.Name);
            if (_playlistList.Any(cus => cus.Name == tempPlaylist.Name) == false)
            {
                tempPlaylist.AddSongs(playlistToCopy.SongList);
                _playlistList.Add(tempPlaylist);
            }
            else
            {
                Console.WriteLine(tempPlaylist.Name + " is already in use by another playlist of yours");
            }
        }
    }
}
