namespace spotivy
{
    internal class Program
    {
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
