using System.Diagnostics;

namespace spotivy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> users = [new User("Lily"), new User("Adam"), new User("Ph1l"), new User("Steve")];
            User mainUser = new User("MainUser");
            List<Album> albums = new List<Album>();
            List<Artist> artists = new List<Artist>();
            List<Song> songs = new List<Song>();

            SongCollection currentPlay;

            mainUser.ViewFriendsList();
            users[0].ViewFriendsList();

            mainUser.AddFriend(users[0]);

            Thread.Sleep(200);

            mainUser.ViewFriendsList();
            users[0].ViewFriendsList();

            mainUser.RemoveFriend(users[0]);

            Thread.Sleep(200);

            mainUser.ViewFriendsList();
            users[0].ViewFriendsList();
        }
    }
}
