using System.Linq;

namespace AverageCalculator
{
	public class AverageCalculator_Class
    {
		public void Main()
		{
            bool continueStatus = true;
            double average = 0;
            string letterGrade = string.Empty;
            
            // Continue showing game until user decision
            do
            {
                // Show how to use the program
                Welcome();

                List<int> inputList = InputTaking();
                Console.ForegroundColor = ConsoleColor.Cyan;

                average = AverageCalculation(inputList);
                letterGrade = LetterGradeCalculation(average);

                Console.WriteLine();
                Console.WriteLine("Yazılan sayıların ortalaması: " + average);
                Console.WriteLine("Yazılan sayıların harf notu: " + letterGrade);

                continueStatus = ContinuationStatus();

            } while (continueStatus);

        }

        /// <summary>
        /// Shows game preview.
        /// </summary>
        /// <returns>Prints game information.</returns>
        private void Welcome()
        {
            string multiLine = new string('-', 45);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(multiLine);
            Console.WriteLine("Ortalama Hesaplama Uygulamasına Hoş Geldiniz!");
            Console.WriteLine(multiLine);

            Console.WriteLine("İstediğiniz sayıların ortalamalarını hesaplamak için bire bir!");
            Console.WriteLine($"Sayıları aralarında birer boşluk olacak şekilde yazınız: 15 21 54 32");
            Console.WriteLine(multiLine);
        }

        /// <summary>
        /// Creates a string list from user input and turns it an integer list.
        /// </summary>
        /// <returns>User input as an integer list.</returns>
        static List<int> InputTaking()
        {
            List<int> intList = new List<int>();

            // Get user input
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Ortalamasını almak istediğiniz sayıları giriniz: ");
            string input = Console.ReadLine();

            // Split the input into string array based on space
            string[] strList = input.Split(' ');

            // Loop through each string in the array
            foreach (string str in strList)
            {
                // Try to parse each string to an integer
                if (int.TryParse(str, out int number))
                {
                    if (number >= 0 && number <= 100)
                    {
                        intList.Add(number);  // Add the number to the int list if valid
                    }
                    else
                    {
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine($"\n'{number}' 0 ile 100 arasında bir not değil ve atlanacak."); // Inform user the number is not in range
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n'{str}' geçerli bir not değil ve atlanacak."); // Inform user that string cannot be involved
                }
            }

            return intList;
        }


        // Calculate average of the list
        private double AverageCalculation(List<int> intList)
        {
            return intList.Average();
        }


        /// <summary>
        /// Calculates letter grade based on average.
        /// </summary>
        /// <param name="average">Letter grade determination number.</param>
        /// <returns>Letter grade.</returns>
        private string LetterGradeCalculation(double average)
        {
            string letterGrade = string.Empty;

            // First and second letter grades determined consecutively
            if (average >= 0 && average <= 59)
            {
                // 0 <= X <= 50: F, if the score greater than 55 than add D or F
                letterGrade = "F" + (average >= 55 ? "D" : "F");
            }
            else if (average >= 60 && average <= 69)
            {
                letterGrade = "D" + (average >= 65 ? "C" : "D");
            }
            else if (average >= 70 && average <= 79)
            {
                letterGrade = "C" + (average >= 75 ? "B" : "C");
            }
            else if (average >= 80 && average <= 89)
            {
                letterGrade = "B" + (average >= 85 ? "A" : "B");
            }
            else if (average >= 90 && average <= 100)
            {
                letterGrade = "AA"; 
            }

            return letterGrade;
        }


        /// <summary>
        /// Ask user whether to continue.
        /// </summary>
        /// <returns>Boolean or recursion.</returns>
        private bool ContinuationStatus()
        {
            string multiLine = new string('-', 45);

            Console.Write("\nDevam etmek istiyor musunuz? (y/n): ");
            string continueChoice = Console.ReadLine().ToLower();

            // If user answer is yes, clear screen and start over
            if (continueChoice == "y")
            {
                Console.Clear();
                return true;
            }
            // If user answer is no, turn back to main menu
            else if (continueChoice == "n")
            {
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine(multiLine);
                Console.WriteLine("Oyun bitti. Ana menüye dönülüyor...");
                Console.WriteLine(multiLine);
                Thread.Sleep(1500);
                return false;
            }
            // If none, then wrong button pressed
            else
            {
                Console.WriteLine();
                Console.WriteLine("Geçersiz giriş. Lütfen 'y' veya 'n' giriniz.");
                return ContinuationStatus();
            }
        }
    }
}
