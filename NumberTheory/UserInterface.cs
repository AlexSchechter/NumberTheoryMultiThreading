using System;
using System.Collections.Generic;

namespace NumberTheory
{
    public class UserInterface
    {
        readonly Analysis fAnalysis;
        readonly MethodTimerWrapper fMethodTimerWrapper;

        public UserInterface()
        {
            fAnalysis = new Analysis();
            fMethodTimerWrapper = new MethodTimerWrapper();
        }

        public void UserMenu()
        {
            int menuChoice;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Check if an integer is a prime number");
                Console.WriteLine("2. Return the list of prime factors for an integer");
                Console.WriteLine("3. Return the largest prime number smaller or equal to an integer");
                Console.WriteLine("4. Exit application");
                Console.Write("{0}Pick your choice: ", Environment.NewLine);               
            } while (!(Int32.TryParse(Console.ReadLine(), out menuChoice) && menuChoice >= 1 && menuChoice <= 4));

            if (menuChoice == 4)
            {
                return;
            }

            ulong integerInput;
            do
            {
                Console.Write("{0}Please enter a positive integer between 2 and 18,446,744,073,709,551,615: ", Environment.NewLine);
            } while (!(UInt64.TryParse(Console.ReadLine(), out integerInput) && integerInput >= 2));

            Console.WriteLine();
            ProcessUserChoice(integerInput, menuChoice);                      
        }

        private void ProcessUserChoice(ulong integerInput, int menuChoice)
        {          
            switch (menuChoice)
            {               
                case 1:
                    if (fMethodTimerWrapper.ExecuteMethod(fAnalysis.IsPrime, integerInput))
                    {
                        Console.WriteLine("{0} is a prime number", integerInput);
                    }
                    else
                    {
                        Console.WriteLine("{0} is not a prime number", integerInput);
                    }
                    break;

                case 2:
                    List<ulong> primeFactors = fMethodTimerWrapper.ExecuteMethod(fAnalysis.CalculatePrimeFactors, integerInput);
                    Console.WriteLine("The prime factors for {0} are :", integerInput);
                    foreach (ulong primeNumber in primeFactors)
                    {
                        Console.Write(primeNumber + " ");
                    }
                    Console.WriteLine();
                    break;

                case 3:
                    Console.WriteLine("The largest prime that is smaller than {0} is {1}.", integerInput, fMethodTimerWrapper.ExecuteMethod(fAnalysis.CalculateLargestPrime, integerInput));
                    break;
            }

            Console.WriteLine("{0}The calculation lasted {1} seconds", Environment.NewLine, fMethodTimerWrapper.MethodExecutionTime);
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            UserMenu();
        }
    }
}
