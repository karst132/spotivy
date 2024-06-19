using System.Diagnostics;

namespace spotivy
{
    internal class Program
    {
        List<User> users = new List<User>();
        List<Album> albums = new List<Album>();
        List<Artist> artists = new List<Artist>();
        List<Song> songs = new List<Song>();
        static async Task Main(string[] args)
        {
            Client client = new();
            bool running = true;
            while (running) {
                Console.WriteLine("Run program by typing \"run\".");
                Console.WriteLine("clear console by typing \"clear\".");
                Console.WriteLine("Close the application by typing \"end\".");
                string input;
                input = Console.ReadLine().ToLower();

        Active currentPlay;


        static async Task Main(string[] args) 
        { 
            Console.WriteLine("start");
            Program program = new Program();
            await program.Run();
            Console.WriteLine("end");
        }

        async Task Run()
        {
            List<Song> tempSongs = [new Song(50,"song1"),new Song(40,"song2")];//for tessting purposes

            currentPlay = new Active();
            currentPlay.SetSongList(tempSongs);

            Thread t1 = new Thread(Method1)
            {
                Name = "Thread1"
            };
            Thread t2 = new Thread(Method2)
            {
                Name = "Thread2"
            };
            t1.Start();
            t2.Start();
            while (t1.IsAlive || t2.IsAlive)
            {

            }
        }

        void Method1()
        {
            currentPlay.Play();
        }
        void Method2()
        {
            Thread.Sleep(3000);

            //currentPlay.Stop();
                if (input == "run")
                {
                    client.RunProgram();
                }
                else if (input == "end")
                {
                    running = false;
                    Console.WriteLine("Closing...");
                    Console.WriteLine("");
                }
                else if (input == "clear")
                {
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Not a valid input.");
                    Console.WriteLine("");
                }
            }
        }
    }
}
