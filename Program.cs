using System;

namespace Project5_Slot_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Slot Machine!");

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

                    List<int> arraySize = new List<int> { 3 };

                    int randomIndex = new Random().Next(arraySize.Count);
                    int[,] SlotMachine = new int[arraySize[randomIndex], arraySize[randomIndex]];

                    Random random = new Random();

                    // Test Array
                    //int[,] testArray = new int[3,3] { { 1, 2, 3 }, { 4, 1, 6 }, { 7, 8, 1 } };
                    //int[,] testArray = new int[3, 3] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };

                    Console.WriteLine("Slot Machine: ");
                    for (int i = 0; i < arraySize[randomIndex]; i++)
                    {
                        for (int j = 0; j < arraySize[randomIndex]; j++)
                        {
                            SlotMachine[i, j] = random.Next(1, 10);
                            Console.Write(SlotMachine[i, j] + " ");
                        }
                        Console.WriteLine();
                    }

                    int counter = 0;
                    int jackpotCounter = 0;
                    int lossCounter = 0;

                    // Diagonal 1
                    for (int i = 0; i < (arraySize[randomIndex] - 1); i++)
                    {
                        if (SlotMachine[i, i] == SlotMachine[i + 1, i + 1])
                        {
                            counter++;
                        }
                    }
                    if (counter == (arraySize[randomIndex] - 1))
                    {
                        Console.WriteLine("You won on diagonal 1!");
                        balance += bet;
                        Console.WriteLine("New balance is " + balance);
                    }
                    else
                    {
                        Console.WriteLine("You lost on diagonal 1.");
                        balance -= bet;
                        Console.WriteLine("New balance is " + balance);
                    }

                    //Diagonal 2
                    counter = 0;
                    for (int i = 0; i < (arraySize[randomIndex] - 1); i++)
                    {
                        for (int j = (arraySize[randomIndex] - 1); j > 0; j--)
                        {
                            if (SlotMachine[i, j] == SlotMachine[i + 1, j - 1])
                            {
                                counter++;
                            }
                        }
                    }

                    if (counter == (arraySize[randomIndex] - 1))
                    {
                        Console.WriteLine("You won on diagonal 2!");
                        balance += bet;
                        Console.WriteLine("New balance is " + balance);
                    }
                    else
                    {
                        Console.WriteLine("You lost on diagonal 2.");
                        balance -= bet;
                        Console.WriteLine("New balance is " + balance);
                    }

                    // Horizontal
                    for (int i = 0; i < arraySize[randomIndex] -1; i++)
                    {
                        counter = 0;
                        for (int j = 0; j < arraySize[randomIndex] -1; j++)
                        {
                            if (SlotMachine[i, j] == SlotMachine[i, j + 1])
                            {
                                counter++;
                            }
                        }
                        if (counter == (arraySize[randomIndex] - 1))
                        {
                            Console.WriteLine("You won on horizontal line " + i + "!");
                            balance += bet;
                            Console.WriteLine("New balance is " + balance);
                        }
                        else
                        {
                            Console.WriteLine("You lost on horizontal line " + i + ".");
                            balance -= bet;
                            Console.WriteLine("New balance is " + balance);
                        }
                    }

                    // Vertical
                    for (int j = 0; j < arraySize[randomIndex] - 1; j++)
                    {
                        counter = 0;
                        for (int i = 0; i < arraySize[randomIndex] - 1; i++)
                        {
                            if (SlotMachine[i, j] == SlotMachine[i + 1, j])
                            {
                                counter++;
                            }
                        }
                        if (counter == (arraySize[randomIndex] - 1))
                        {
                            Console.WriteLine("You won on vertical line " + j + "!");
                            balance += bet;
                            Console.WriteLine("New balance is " + balance);
                        }
                        else
                        {
                            Console.WriteLine("You lost on vertical line " + j + ".");
                            balance -= bet;
                            Console.WriteLine("New balance is " + balance);
                        }
                    }

                    // Middle
                    int middle = arraySize[randomIndex] / 2;
                    for (int i = 0; i < arraySize[randomIndex] - 1; i++)
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
                    if (counter == 2 * (arraySize[randomIndex] - 1))
                    {
                        Console.WriteLine("You won on the middle lines!");
                        balance += bet;
                        Console.WriteLine("New balance is " + balance);
                    }
                    else
                    {
                        Console.WriteLine("You lost on the middle line.");
                        balance -= bet;
                        Console.WriteLine("New balance is " + balance);
                    }
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