using System;
using System.Threading;

namespace RandomGuesserGame
{
    public class RandomGuesser_Class
    {
        // Set maximum health to 5
        const int maxHealth = 5;
        int health = maxHealth;

        public void Main()
        {
            bool continueStatus = true;
            string multiLine = new string('-', 45);
            int compNum = ComputerChoice();

            // Setup welcome page
            Welcome();

            // Continue until user decides not to
            do
            {
                // Get user input and assign it to userNum
                int userNum = UserChoice();

                Console.WriteLine(multiLine);

                // Check proximity between computer and user choice
                bool proximityResult = ProximityChecker(userNum, compNum);

                // If user input not correct, decrease health
                if (!proximityResult)
                {
                    HealthChecker(ref health);
                    Console.ForegroundColor = ConsoleColor.White; 
                    Console.WriteLine(multiLine);
                }

                // Ask for continuation after either win or health reaches 0
                if (proximityResult || health == 0)
                {
                    if (health == 0)
                    {
                        Console.WriteLine("\nDoğru sayı: " + compNum + "\n");
                    }

                    continueStatus = ContinuationStatus(ref health, ref compNum);
                }

            } while (continueStatus);
        }

        /// <summary>
        /// Main menu title.
        /// </summary>
        /// <returns>Prints main menu title.</returns>
        private void Welcome()
        {
            string multiLine = new string('-', 45);
            Console.WriteLine(multiLine);
            Console.WriteLine("Sayı Tahmin Etme Oyununa Hoş Geldiniz!");
            Console.WriteLine(multiLine);

            Console.WriteLine("- Bu oyunda bilgisayar (rakibiniz) 1 ile 100 arasında " +
                "bir sayı tahmin edecek ve siz o sayıyı bilmeye çalışacaksınız!");
            Console.WriteLine($"- Toplam {maxHealth} canınız var, dikkatli oynayın!");
            Console.WriteLine(multiLine);
        }

        /// <summary>
        /// Computer determines random number.
        /// </summary>
        /// <returns>Random number.</returns>
        private int ComputerChoice()
        {
            Random random = new Random();
            return random.Next(1, 101);
        }

        /// <summary>
        /// User choice has been taken.
        /// </summary>
        /// <returns>Prints user choice.</returns>
        private int UserChoice()
        {
            int userNum;
            bool isInt;

            // Continue until user input is an integer
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Tahmininizi giriniz: ");
                isInt = int.TryParse(Console.ReadLine(), out userNum);

                if (!isInt)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Lütfen geçerli bir sayı giriniz!");
                }

            } while (!isInt);

            return userNum;
        }

        /// <summary>
        /// Check how far the user input from computer decision.
        /// </summary>
        /// <param name="userNum">User input.</param>
        /// <param name="compNum">Computer decision.</param>
        /// <returns>User input correctness in boolean.</returns>
        private bool ProximityChecker(int userNum, int compNum)
        {
            Console.ForegroundColor = ConsoleColor.White;
            // If user input greater than computer input, print "lower"
            if (userNum > compNum)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Daha düşük.");
            }
            // If user input lower than computer input, print "higher"
            else if (userNum < compNum)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Daha yüksek.");
            }
            // If user input equal to computer input, print "you win"
            else
            {
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine("Bravo! Doğru bildiniz.");
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check how many lives user has.
        /// </summary>
        /// <param name="health">Changes health parameter determined in the beginning.</param>
        /// <returns>How many healths left.</returns>
        private void HealthChecker(ref int health)
        {
            health -= 1;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Bir can kaybettiniz! Mevcut canınız: " + health);
        }

        /// <summary>
        /// Ask whether to continue the game.
        /// </summary>
        /// <param name="health">Health information.</param>
        /// <param name="compNum">Computer decision.</param>
        /// <returns>Boolean.</returns>
        private bool ContinuationStatus(ref int health, ref int compNum)
        {
            string multiLine = new string('-', 45);

            Console.Write("Oyuna devam etmek istiyor musunuz? (y/n): ");
            string continueChoice = Console.ReadLine().ToLower();

            // If user wants to continue:
            if (continueChoice == "y")
            {
                // Set health to max
                health = maxHealth;
                // Determine computer choice one more time
                compNum = ComputerChoice();
                // Clear screen for better UI
                Console.Clear();
                // Print welcome page
                Welcome();
                return true;
            }
            // If user doesnt want to continue, go back to main menu
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
            // Warn about wrong input
            else
            {
                Console.WriteLine("Geçersiz giriş. Lütfen 'y' veya 'n' giriniz.");
                return ContinuationStatus(ref health, ref compNum); 
            }
        }
    }
}
