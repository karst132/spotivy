using System.Diagnostics;
using static spotivy.Song;

namespace spotivy
{
    internal class Program
    {


        
        static async Task Main(string[] args)
        {   
            
            List<Artist> artists = [
                new ("artist1"),
                new ("artist2"),
                new ("artist3"),
                new ("artist4")
            ];

            List<Song> songs = new List<Song>();
            List<Album> albums = new List<Album>();

            //the 3 for loop should be able to be changed in one
            for (int i = 0; i < artists.Count; i++)
            {
                songs.Add(new Song(25, "EpicSong"+i, [artists[i]], [(Genre)0,(Genre)1]));
                songs.Add(new Song(20, "EpicSong"+i+4, [artists[i]], [(Genre)3]));
            }

            for (int i = 0; i < artists.Count; i++)
            {
                artists[i].AddSongs(songs);//because of how AddSongs is made it can only add songs if the artist is in it (still needs testing)
            }

            for (int i = 0; i < artists.Count; i++)
            {
                albums.Add(new Album(artists[i], "epicAlbum"+i,artists[i].SongList));
            }

            List<User> users = [
                new("test0"),
                new("test1"),
                new("test2"),
                new("test3")
            ];

            for (int i = 0; i < users.Count; i++)
            {
                users[i].AddPlaylist("epicPlayList"+i);
                users[i].AddPlaylist("epicPlayList"+(i+4));
            }
            
            Client client = new(users, albums, artists, songs);

            bool running = true;
            while (running)
            {
                Console.WriteLine("Run program by typing \"run\".");
                Console.WriteLine("clear console by typing \"clear\".");
                Console.WriteLine("Close the application by typing \"end\".");
                string input;
                input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "run":
                        Console.WriteLine("Running Program...");
                        Console.WriteLine();
                        client.RunProgramAsync();
                        Console.WriteLine("Done");
                        Console.WriteLine();
                        break;
                    case "clear":
                        Console.Clear();
                        break;
                    case "end":
                        Console.WriteLine("stopping...");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Not a valid input.");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}