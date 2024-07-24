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
            if (args[0] == "-c")
            {
                var services = new ServiceCollection();

                services.AddSingleton<ICounts, Counts>();

                var serviceProvider = services.BuildServiceProvider();

                var counts = serviceProvider.GetRequiredService<ICounts>();
                
                var numChars = counts.CountBytes(args[1]);
                Console.WriteLine(numChars);
            }
            else
            {
                Console.WriteLine("Invalid arguments.");
            }

        }
    }
}
