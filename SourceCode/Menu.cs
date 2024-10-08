using System;
using System.Threading;

namespace Menu
{
    public class aLaCarte
    {   /// <summary>
        /// Returns program choice of the user.
        /// </summary>
        /// <returns>Program choice.</returns>
        public int Main()
        {
            bool isInt = false;
            int choice = 0;

            // Continue until valid input taken
            do
            {
                Title();
                Options();

                Console.Write("Tercihinizi giriniz (0/1/2/3): ");
                isInt = int.TryParse(Console.ReadLine(), out choice);

                if (!isInt)
                    Console.WriteLine("\nLütfen geçerli bir sayı giriniz.");
                    Thread.Sleep(1000);
                    Console.Clear();

            } while (!isInt);

            return choice;
        }

        /// <summary>
        /// Main menu title.
        /// </summary>
        /// <returns>Main menu title.</returns>
        public void Title()
        {
            string title = "Nazif'in İşlevler Menüsü";
            Console.ForegroundColor = ConsoleColor.Green;
            PrintBorder(60);
            Console.WriteLine($"| {title.PadRight(58)} |");
            PrintBorder(60);
        }

        /// <summary>
        /// Main menu including all programs.
        /// </summary>
        /// <returns>Prints options available.</returns>
        public void Options()
        {
            // Print first program and its information
            string option1 = "(1) Gizemli Sayı Oyunu";
            string option1_exp = "Kullanıcının ipuçlarıyla sınırlı sayıda denemede rastgele seçilenbir sayıyı bulmaya çalıştığı eğlenceli bir sayı tahmin oyunu.";

            // Print second program and its information
            string option2 = "(2) Matematik Sihirbazı";
            string option2_exp = "Toplama, çıkarma, çarpma ve bölme gibi aritmetik işlemleri gerçekleştiren bir hesap makinesi.";

            // Print third program and its information
            string option3 = "(3) Not Ortalaması Hesaplayıcı";
            string option3_exp = "Kullanıcının üç ders notunu girip, ortalamasını ve ilgili harf notunu hesaplayan bir ortalama hesaplayıcı.";

            // Print how to quit the game
            string option4 = "(0) Oyundan Çıkış";
            string option4_exp = "Oyundan çıkmak için 0 rakamını giriniz.";

            // Print options with borders
            PrintOption(option1, option1_exp);
            PrintOption(option2, option2_exp);
            PrintOption(option3, option3_exp);
            PrintOption(option4, option4_exp);

            PrintBorder(60); // End border
        }

        /// <summary>
        /// Prints options and align borders and lines in the main menu.
        /// </summary>
        /// <param name="option">Name of the program.</param>
        /// <param name="explanation">Explanation of the program.</param>
        /// <returns>Prints options available.</returns>
        public void PrintOption(string option, string explanation)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            PrintBorder(60); // Top border

            // Set option in cyan
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"| {option.PadRight(58)} |");

            // Set explanation in white
            Console.ForegroundColor = ConsoleColor.White;
            string[] lines = WrapText(explanation, 58);
            foreach (string line in lines)
            {
                Console.WriteLine($"| {line.PadRight(58)} |");
            }
        }

        /// <summary>
        /// Alignment of the border.
        /// </summary>
        /// <param name="width">Width in pixels.</param>
        /// <returns>Prints border.</returns>
        public void PrintBorder(int width)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"+{new string('-', width)}+");
        }

        /// <summary>
        /// Wraps printed text for better UI.
        /// </summary>
        /// <param name="text">Text to be wrapped.</param>
        /// <param name="width">Width alignment for text.</param>
        /// <returns>Returns lines near a text.</returns>
        public string[] WrapText(string text, int width)
        {
            var lines = new System.Collections.Generic.List<string>();
            while (text.Length > 0)
            {
                if (text.Length > width)
                {
                    // Look for a space to break on
                    int index = text.LastIndexOf(' ', width);
                    if (index == -1) index = width;
                    lines.Add(text.Substring(0, index).Trim());
                    text = text.Substring(index).Trim();
                }
                else
                {
                    lines.Add(text);
                    break;
                }
            }
            return lines.ToArray();
        }
    }
}
