using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberTheory
{
    class Program
    {
        static void Main(string[] args)
        {
            Analysis analysis = new Analysis();
            Stopwatch stopwatch = new Stopwatch();

            int userChoics;

            do
            {
                Console.Clear();
                Console.WriteLine();
            } while(true);
            ulong userInput;
            do
            {
                Console.WriteLine("Please enter a positive integer between 2 and 18,446,744,073,709,551,615");
            } while (!(UInt64.TryParse(Console.ReadLine(), out userInput) && userInput >= 2));

            stopwatch.Start();
            List<ulong> primeFactors = analysis.CalculatePrimeFactors(userInput);
            stopwatch.Stop();
            Console.WriteLine("The calculation lasted {0} secondes", stopwatch.Elapsed);
            foreach (ulong primeNumber in primeFactors)
            {
                Console.WriteLine(primeNumber);
            }
            Console.ReadLine();
        }
    }
}
