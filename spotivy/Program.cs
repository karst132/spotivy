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

            for (int i = 0; i < artists.Count; i++)
            {
                songs.Add(new Song(25, "EpicSong"+i));//needs works
            }
            
            List<Album> albums = new List<Album>();
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