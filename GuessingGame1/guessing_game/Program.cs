using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int theAnswer;
            int playerGuess;
            int playerAttempts = 0;
            int range = 0; 
            string playerInput;
            string playerName;
            string playerMode;

            Console.Write("Welcome! What is your name? ");
            playerName = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine($"Hello {playerName}! Select a level to play and enter the number below.");
            Console.WriteLine("");
            Console.WriteLine("1 - Easy Level - Guess 1-5");
            Console.WriteLine("2 - Normal Level - Guess 1-20");
            Console.WriteLine("3 - Hard Level - Guess 1-50");
            Console.WriteLine("");

            Console.Write("Level to Play: ");
            playerMode = Console.ReadLine();

            if (playerMode == "1")
            {
                range = 6;
            }
            else if (playerMode == "2")
            {
                range = 21;
            }
            else if (playerMode == "3")
            {
                range = 51;
            }

            Random r = new Random();
            theAnswer = r.Next(1, range);

            do
            {
                Console.WriteLine("");
                Console.Write($"Enter your guess between 1-{range -1} {playerName}: ");
                playerInput = Console.ReadLine();

                if (int.TryParse(playerInput, out playerGuess))
                {
                    if (playerGuess <= 0 || playerGuess >= range)
                    {
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Sorry {playerName}, your entry was not in the required range of numbers.");
                        Console.ResetColor();
                    }
                    else if (playerGuess > theAnswer)
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"Sorry {playerName}, your guess was too HIGH!");
                        playerAttempts++;
                    }
                    else if (playerGuess < theAnswer)
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"Sorry {playerName}, your guess was too LOW!");
                        playerAttempts++;
                    }
                    else if (playerGuess == theAnswer && playerAttempts != 0)
                    {
                        playerAttempts++;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("");
                        Console.WriteLine($"{theAnswer} was the number. You WIN {playerName}!");
                        Console.WriteLine($"It took you a total of {playerAttempts} attempts {playerName}!");
                        Console.ResetColor();
                    }
                    else
                    {
                        playerAttempts++;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("");
                        Console.WriteLine($"Nice job {playerName}! You guess the answer on the FIRST TRY!");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("");
                    Console.WriteLine($"Sorry {playerName}, that wasn't a number!");
                    Console.ResetColor();
                }
                Console.WriteLine("");
                Console.WriteLine($"Press ENTER to PLAY AGAIN {playerName} - OR - press Q to QUIT or change playing levels.");
                }
                while (Console.ReadKey().KeyChar != 'q');
        }
    }
}