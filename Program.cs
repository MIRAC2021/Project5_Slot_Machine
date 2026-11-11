using System;

namespace Project5_Slot_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Slot Machine!");
            List<int> arraySize = new List<int> { 3, 5, 7, 9 };

            int randomIndex = new Random().Next(arraySize.Count);
            int[,] SlotMachine = new int[arraySize[randomIndex], arraySize[randomIndex]];

            Random random = new Random();

            for (int i = 0; i < arraySize[0]; i++)
            {
                for (int j = 0; j < arraySize[0]; j++)
                {
                    SlotMachine[i, j] = random.Next(1, 10);
                    Console.WriteLine(SlotMachine[i, j]);
                }
            }

            double balance = 0;
            double bet = 0;

            Console.WriteLine("Enter your balance: ");
            while (!double.TryParse(Console.ReadLine(), out balance))
            {
                Console.Write("That wasn't a valid number. Try again: ");
            }
            Console.WriteLine("How much would you like to bet per spin? ");
            while (!double.TryParse(Console.ReadLine(), out bet))
            {
                Console.Write("That wasn't a valid number. Try again: ");
            }

            if (bet > balance)
            {
                Console.WriteLine("You don't have enough balance to make that bet.");
                return;
            }

            while (true)
            {
                if (balance <= 0)
                {
                    Console.WriteLine("You have no more balance left. Game over!");
                    break;
                }
                if (bet > balance)
                {
                    Console.WriteLine("You don't have enough balance to make that bet.");
                    break;
                }

                Console.WriteLine("Press Enter to spin the slot machine or type 'exit' to quit.");
                string? input = Console.ReadLine();
                
                if (input != null && input.ToLower() == "exit")
                {
                    Console.WriteLine("Thank you for playing! Your final balance is: " + balance);
                    break;
                }
                else
                {
                    Console.WriteLine("Spinning the slot machine...");
                }





            }

            // Check middle
            // check both diagonal
            // check all horizontal
            // check all vertical
            // check jackpot

            // win or loss



        }
    }
}