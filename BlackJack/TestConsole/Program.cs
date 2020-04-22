using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJackLibrairie;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Sabot sab = new Sabot();
            sab.SabotJeu.ForEach(carte => Console.WriteLine(carte.ToString()));
            Console.ReadKey();
        }
    }
}
