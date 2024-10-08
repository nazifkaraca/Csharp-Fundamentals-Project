using RandomGuesserGame;
using Calculator;
using AverageCalculator;
using Menu;

namespace SourceCode
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new instance from the program class
            RandomGuesser_Class RandomGuesser = new RandomGuesser_Class();
            Calculator_Class Calculator = new Calculator_Class();
            AverageCalculator_Class Average = new AverageCalculator_Class();
            aLaCarte Menu = new aLaCarte();

            bool continuation = false;

            // Continue showing menu until correct choice
            while (!continuation)
            {
                int choice = Menu.Main();
                // Clear menu before game opens
                Console.Clear();

                // Open the chosen program
                switch (choice)
                {
                    case 0:
                        continuation = true;
                        break;
                    case 1:
                        RandomGuesser.Main();
                        break;
                    case 2:
                        Calculator.Main();
                        break;
                    case 3:
                        Average.Main();
                        break;
                    default:
                        Console.WriteLine("Yanlış bir değer girdiniz!");
                        break;
                }
                
                // Clear previous game from screen
                Console.Clear();

            }
        }
    }     
}


