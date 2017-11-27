using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            string sentenceTwo = ("");
            bool useProgram = true;
            
            while (useProgram)
            {
                Console.Clear();
                Console.WriteLine("Please enter a name separated by comma(e.g marc,johan,nicklas)");
                input = Console.ReadLine();
                sentenceTwo = input;
                string[] split = sentenceTwo.Split(',');

                foreach (string item in split)
                {
                    if (sentenceTwo.Length < 2 && sentenceTwo.Length > 9 == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please write between 2 and 9 letters");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("***SUPER-" + item.ToUpper().Trim() + "***");
                    }
                }
                Console.ReadLine();
                
            }
            
            

        }
            
    }
}
