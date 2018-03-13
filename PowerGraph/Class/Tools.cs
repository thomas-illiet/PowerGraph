using System;

namespace PowerGraph
{
    public class Tools
    {
        public bool ReadChoice(string message)
        {
            ConsoleKey response;
            do
            {
                Console.Write($"{message} [y/n] ");
                response = Console.ReadKey(false).Key;   // true is intercept key (dont show), false is show
                if (response != ConsoleKey.Enter)
                    Console.WriteLine();

            } while (response != ConsoleKey.Y && response != ConsoleKey.N);

            return (response == ConsoleKey.Y ? true : false);
        }
    }
}
