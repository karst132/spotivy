using System.Diagnostics;
using static spotivy.Song;

namespace spotivy
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            List<User> users = [
                new ("Lily"),
                new ("Harry"),
                new ("liam")
                ]; ;
            List<Album> albums = [

                ]; ;
            List<Artist> artists = [
                ]; ;
            List<Song> songs = [
                new (20, "test1"),
                new (20, "test2"),
                new (20, "yay"),
                new (20, "test3"),
                new (20, "okie"),
                new (20, "yapper")
                ];

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
                        Console.WriteLine();
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