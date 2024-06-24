using System.Diagnostics;

namespace spotivy
{
    internal class Program
    {


        
        static async Task Main(string[] args)
        {
            List<User> users = new List<User>();
            List<Album> albums = new List<Album>();
            List<Artist> artists = new List<Artist>();
            List<Song> songs = new List<Song>();
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