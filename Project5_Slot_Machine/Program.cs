using System;
using System.Net.Http.Headers;

namespace Project5_Slot_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const int SMALLEST_SLOT_NUMBER = 1;
            const int LARGEST_SLOT_NUMBER = 10;
            const int MIDDLE = 1;
            const int HORIZONTAL = 2;
            const int VERTICAL = 3;
            const int DIAGONAL = 4;
            const int JACKPOT = 5;


            Console.WriteLine("Welcome to the Slot Machine!");

            double balance = 0;
            double bet = 0;

            Console.WriteLine("Which slot machine would you like to play? (3, 5, 7, 9)");
            int machineSize = 0;
            while (!int.TryParse(Console.ReadLine(), out machineSize))
            {
                Console.Write("That wasn't a valid number. Try again: ");
            }

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

                Console.WriteLine("Please choose a mode: (1) Middle Line, (2) Horizontals, (3) Verticals, (4) Both Diagonals, (5) Jackpot");
                int mode = 0;
                while (!int.TryParse(Console.ReadLine(), out mode) || mode < 1 || mode > 5)
                {
                    Console.Write("That wasn't a valid option. Please choose a mode (1-5): ");
                }

                
                Console.WriteLine("Spinning the slot machine...");

                int[,] SlotMachine = new int[machineSize, machineSize];

                Random random = new Random();

                //SlotMachine = new int[3, 3] { { 10, 10, 10 }, { 10, 10, 10 }, { 10, 10, 10 } };

                Console.WriteLine("Slot Machine: ");
                for (int i = 0; i < machineSize; i++)
                {
                    for (int j = 0; j < machineSize; j++)
                    {
                        SlotMachine[i, j] = random.Next(SMALLEST_SLOT_NUMBER, LARGEST_SLOT_NUMBER);
                        Console.Write(SlotMachine[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                    

                int counter = 0;

                if (mode == MIDDLE)
                {
                    // Middle
                    int middle = machineSize / 2;
                    for (int i = 0; i < machineSize - 1; i++)
                    {
                        if (SlotMachine[middle, i] == SlotMachine[middle, i + 1])
                        {
                            counter++;
                        }
                        if (SlotMachine[i, middle] == SlotMachine[i + 1, middle])
                        {
                            counter++;
                        }

                    }
                    if (counter == 2 * (machineSize - 1))
                    {
                        Console.WriteLine("You won on the middle lines!");
                        balance += bet;
                    }
                    else
                    {
                        Console.WriteLine("You lost on the middle line.");
                        balance -= bet;
                    }
                }
                else if (mode == HORIZONTAL)
                {
                    // Horizontal
                    int horizontal_win_count = 0;
                    for (int i = 0; i < machineSize - 1; i++)
                    {
                        counter = 0;
                        for (int j = 0; j < machineSize - 1; j++)
                        {
                            if (SlotMachine[i, j] == SlotMachine[i, j + 1])
                            {
                                counter++;
                            }
                        }
                        if (counter == (machineSize - 1))
                        {
                            horizontal_win_count++;
                        }
                    }

                    if (horizontal_win_count > 0)
                    {
                        Console.WriteLine("You won on horizontal line !");
                        balance += bet * horizontal_win_count;
                    }
                    else
                    {
                        Console.WriteLine("You lost on horizontal line.");
                        balance -= bet;
                    }
                }
                else if (mode == VERTICAL)
                {
                    // Vertical
                    int vertical_win_count = 0;
                    for (int j = 0; j < machineSize - 1; j++)
                    {
                        counter = 0;
                        for (int i = 0; i < machineSize - 1; i++)
                        {
                            if (SlotMachine[i, j] == SlotMachine[i + 1, j])
                            {
                                counter++;
                            }
                        }
                        if (counter == (machineSize - 1))
                        {
                            vertical_win_count++;
                        }

                    }
                    if (vertical_win_count > 0)
                    {
                        Console.WriteLine("You won on vertical line!");
                        balance += bet * vertical_win_count;
                    }
                    else
                    {
                        Console.WriteLine("You lost on vertical line.");
                        balance -= bet;
                    }
                }
                else if (mode == DIAGONAL)
                {
                    // Diagonal 1
                    for (int i = 0; i < (machineSize - 1); i++)
                    {
                        if (SlotMachine[i, i] == SlotMachine[i + 1, i + 1])
                        {
                            counter++;
                        }
                    }
                    if (counter == (machineSize - 1))
                    {
                        Console.WriteLine("You won on diagonal 1!");
                        balance += bet;
                    }
                    else
                    {
                        Console.WriteLine("You lost on diagonal 1.");
                        balance -= bet;
                    }

                    //Diagonal 2
                    counter = 0;
                    for (int i = 0; i < (machineSize - 1); i++)
                    {
                        for (int j = (machineSize - 1); j > 0; j--)
                        {
                            if (SlotMachine[i, j] == SlotMachine[i + 1, j - 1])
                            {
                                counter++;
                            }
                        }
                    }

                    if (counter == (machineSize + 1))
                    {
                        Console.WriteLine("You won on diagonal 2!");
                        balance += bet;
                    }
                    else
                    {
                        Console.WriteLine("You lost on diagonal 2.");
                        balance -= bet;
                    }
                }
                else if (mode == JACKPOT)
                {
                    // Jackpot
                    for (int i = 0; i < (machineSize - 1); i++)
                    {
                        for (int j = 0; j < (machineSize - 1); j++)
                        {
                            if (SlotMachine[i, j] == SlotMachine[i, j + 1] && SlotMachine[i, j] == SlotMachine[i + 1, j])
                            {
                                counter++;
                            }
                        }
                    }

                    if (counter == (machineSize + 1))
                    {
                        Console.WriteLine("You won the JACKPOT! :) ");
                        balance += bet;
                    }
                    else
                    {
                        Console.WriteLine("You lost the JACKPOT... :(");
                        balance -= bet;
                    }
                }

                Console.WriteLine("New balance is " + balance);

                Console.WriteLine("Press Enter to play again or type 'exit' to quit.");
                string? play = Console.ReadLine();

                if (play != null && play.ToLower() == "exit")
                {
                    Console.WriteLine("Thank you for playing! Your final balance is: " + balance);
                    break;
                }

            }
        }
    }
}