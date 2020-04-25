using BlackJackLibrairie;
using System;

namespace TestConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Sabot sab = new Sabot();
            sab.SabotJeu.ForEach(carte => Console.WriteLine(carte.ToString()));
            Console.ReadKey();
        }
    }
}