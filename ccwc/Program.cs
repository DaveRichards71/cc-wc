using Logic;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                throw new ArgumentException("This must have 2 arguments.");
            }
            if (args[0] == "-c" || args[0] == "-l")
            {
                var services = new ServiceCollection();

                services.AddSingleton<ICounts, Counts>();

                var serviceProvider = services.BuildServiceProvider();

                var counts = serviceProvider.GetRequiredService<ICounts>();

                int numChars = 0;

                if (args[0] == "-c")
                {
                    numChars = counts.CountBytes(args[1]);
                }
                else if (args[0] == "-l")
                {
                    numChars = counts.CountLines(args[1]);
                }
                
                
                Console.WriteLine(numChars);
            }
            else
            {
                Console.WriteLine("Invalid arguments.");
            }

        }
    }
}
