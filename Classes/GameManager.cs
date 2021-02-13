using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFore.Classes
{
    public class GameManager
    {
        public Player PlayerOne { get; private set; }
        public Player PlayerTwo { get; private set; }
        public GameBoard GameBoard { get; private set; }

        public void Start()
        {
            GameBoard = new GameBoard();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Welcome to Connect Fore(Legal Reasons)\n" +
                              "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n");
            Console.Write("Please enter Player 1's Name: ");
            string playerOneName = Console.ReadLine();
            PlayerOne = new Player(playerOneName);
            Console.WriteLine($"Welcome {PlayerOne.PlayerName}\n");
            Console.Write("Please enter Player 2's Name: ");
            string playerTwoName = Console.ReadLine();
            PlayerTwo = new Player(playerTwoName);
            Console.WriteLine($"Welcome {PlayerTwo.PlayerName}\n");
            Console.WriteLine("Press any key to begin the game");
            Console.ReadLine();
            TakeTurn();
        }

        public void TakeTurn()
        {
            bool gameOver = false;
            bool playerOnesTurn = true;
            do
            {
                Console.Clear();
                do {
                    Console.WriteLine(GameBoard.ViewBoard());
                    Console.WriteLine("\n\n");
                    Console.WriteLine($"{PlayerOne.PlayerName}'s Turn:");
                    bool validColumn = false;
                    do
                    {
                        Console.Write("Where would you like to place your piece? (1-7)");
                        string columnSelect = Console.ReadLine().Trim();
                        int value;
                        if (int.TryParse(columnSelect, out value) && value < 8 && value > 0)
                        {
                            if (GameBoard.PlacePiecePlayerOne(value - 1))
                            {
                                Console.WriteLine($"Piece placed in Column {value - 1}");
                                validColumn = true;
                            }
                            else
                            {
                                Console.WriteLine("Please choose a row with an empty slot");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please choose a row with an empty slot between 1 and 7");
                            columnSelect = Console.ReadLine().Trim();
                        }
                    } while (!validColumn);
                    playerOnesTurn = !playerOnesTurn;
                } while (playerOnesTurn);
                while (!playerOnesTurn)
                {
                    Console.Clear();
                    Console.WriteLine(GameBoard.ViewBoard());
                    Console.WriteLine("\n\n");
                    Console.WriteLine($"{PlayerTwo.PlayerName}'s Turn:");
                    bool validColumn = false;
                    do
                    {
                        Console.Write("Where would you like to place your piece?");
                        string columnSelect = Console.ReadLine().Trim();
                        int value;
                        if (int.TryParse(columnSelect, out value) && value < 8 && value > 0)
                        {
                            if(GameBoard.PlacePiecePlayerTwo(value - 1))
                            {
                                Console.WriteLine($"Piece placed in Column {value - 1}");
                                validColumn = true;
                            }
                            else
                            {
                                Console.WriteLine("Please choose a row with an empty slot");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please choose a number between 1 and 7");
                            columnSelect = Console.ReadLine().Trim();
                        }
                    } while (!validColumn);
                    playerOnesTurn = !playerOnesTurn;
                }
            } 
            while (!gameOver);

        }
    }
}
