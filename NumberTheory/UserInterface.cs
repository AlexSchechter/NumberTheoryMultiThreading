using NumberTheory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberTheory
{
    public class UserInterface
    {
        public void UserMenu()
        {
            Analysis analysis = new Analysis();
            Stopwatch stopwatch = new Stopwatch();

            int userChoice;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Check if an integer is a prime number");
                Console.WriteLine("2. Return the list of prime factors for an integer");
                Console.WriteLine("3. Return the largest prime number smaller or equal to an integer");
                Console.WriteLine("4. Exit application");
                Console.Write("Pick your choice");               
            } while (!(Int32.TryParse(Console.ReadLine(), out userChoice) && userChoice >= 1 && userChoice <= 4));


            ulong userInput;
            do
            {
                Console.WriteLine("Please enter a positive integer between 2 and 18,446,744,073,709,551,615");
            } while (!(UInt64.TryParse(Console.ReadLine(), out userInput) && userInput >= 2));

            stopwatch.Start();
            switch(userChoice)
            {
                case 1:
                   
                    if(analysis.IsPrime(userInput))
                    {
                        Console.WriteLine("{0} is a prime number", userChoice);
                    }
                    else
                    {
                        Console.WriteLine("{0} is not a prime number", userChoice);
                    }                                         
                    break;

                case 2:
                    MethodTimerWrapper<List<ulong>> methodTimer = new MethodTimerWrapper<List<ulong>>(analysis.CalculatePrimeFactors, userInput);
                    List<ulong> primeFactors = methodTimer.MethodResult;
                    //List<ulong> primeFactors = analysis.CalculatePrimeFactors(userInput);
                    foreach (ulong primeNumber in primeFactors)
                    {
                        Console.WriteLine(primeNumber);
                    }
                    break;

            }
            stopwatch.Stop();
            
            Console.WriteLine("The calculation lasted {0} secondes", stopwatch.Elapsed);
        
            Console.ReadLine();
        }
    }
}
