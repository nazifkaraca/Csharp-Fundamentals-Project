using System;
using System.Threading;

namespace Calculator
{
    public class Calculator_Class
    {
        public void Main()
        {
            bool continueStatus = true;

            do
            {
                // Get user inputs (num1, num2, operation)
                (double num1, double num2, char operation) = UserInput();

                // Perform the operation
                double result = Operation(num1, num2, operation);

                // Display the result
                if (num2 != '0' && operation != '/')
                    Console.WriteLine($"Sonuç: {num1} {operation} {num2} = {result}");

                continueStatus = ContinuationStatus();

                Console.Clear();

            } while (continueStatus);
        }

        /// <summary>
        /// Main menu title.
        /// </summary>
        /// <returns>Prints main menu title.</returns>
        private void Welcome()
        {
            string multiLine = new string('-', 45);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(multiLine);
            Console.WriteLine("Hesaplama Makinesi");
            Console.WriteLine(multiLine);
            Console.WriteLine("İki sayı ve yapmak istediğiniz işlemi giriniz!");
            Console.WriteLine(multiLine);
        }

        /// <summary>
        /// Takes user input and checks correctness.
        /// </summary>
        /// <returns>Double number, double number, operation.</returns>
        private (double, double, char) UserInput()
        {
            double num1;
            double num2;
            char operation;
            bool isValid = false;

            // Continue until both numbers and operations gotten correctly
            do
            {
                // Set welcome foreground to green
                Console.ForegroundColor= ConsoleColor.Green;
                Welcome();

                // Set input foreground to white
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("İlk sayıyı giriniz: ");
                bool isInt1 = double.TryParse(Console.ReadLine(), out num1);

                Console.Write("İkinci sayıyı giriniz: ");
                bool isInt2 = double.TryParse(Console.ReadLine(), out num2);

                // Set operation foreground to cyan
                Console.ForegroundColor= ConsoleColor.Cyan;
                Console.Write("İşlem seçiniz (+, -, /, *): ");
                operation = Console.ReadKey().KeyChar;
                Console.ReadLine();
                Console.WriteLine();

                // Check whether numbers or operations correct
                if (isInt1 && isInt2 && (operation == '+' || operation == '-' || operation == '/' || operation == '*'))
                {
                    isValid = true;
                }
                // If not, warn the user
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Geçersiz giriş! Lütfen iki geçerli sayı ve geçerli bir işlem giriniz.\n");
                    Thread.Sleep(2000);
                    Console.Clear();
                }

            } while (!isValid);

            return (num1, num2, operation);
        }

        /// <summary>
        /// Completes the operation.
        /// </summary>
        /// <param name="num1">First double number.</param>
        /// <param name="num2">Second double number.</param>
        /// <param name="operation">Either '+, -, /, *'.</param>
        /// <returns>Result of the operation.</returns>
        private double Operation(double num1, double num2, char operation)
        {
            double result = 0;

            // Complete operation based on input
            switch (operation)
            {
                case '+':
                    {
                        result = num1 + num2;
                        break;
                    }
                case '-':
                    {
                        result = num1 - num2;
                        break;
                    }
                case '*':
                    {
                        result = num1 * num2;
                        break;
                    }
                case '/':
                    {
                        if (num2 != 0)
                        {
                            result = num1 / num2;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red; 
                            Console.WriteLine("Sıfıra bölme hatası!"); // Warn user about division by zero error
                        }
                        break;
                    }
                default:
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Geçersiz işlem!"); // Warn about incorrect input
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                    }
            }

            return result;
        }

        /// <summary>
        /// Asks user whether to continue.
        /// </summary>
        /// <returns>Returns true or false.</returns>
        private bool ContinuationStatus()
        {
            string multiLine = new string('-', 45);

            Console.ForegroundColor= ConsoleColor.Green;
            Console.Write("\nDevam etmek istiyor musunuz? (y/n): ");
            string continueChoice = Console.ReadLine().ToLower();

            // If the user wants to continue, start over
            if (continueChoice == "y")
            {
                Console.Clear();
                return true;
            }
            // If the user doesnt want to continue, go back to main menu
            else if (continueChoice == "n")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine(multiLine);
                Console.WriteLine("Oyun bitti. Ana menüye dönülüyor...");
                Console.WriteLine(multiLine);
                Thread.Sleep(1500);
                return false;
            }
            // Warn about the wrong input
            else
            {
                Console.WriteLine("Geçersiz giriş. Lütfen 'y' veya 'n' giriniz.");
                return ContinuationStatus();
            }
        }
    }
}
