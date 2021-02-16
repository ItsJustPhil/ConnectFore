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
                    PrintBoard();
                    Console.WriteLine("\n\n");
                    Console.WriteLine($"{PlayerOne.PlayerName}'s Turn:");
                    bool validColumn = false;
                    do
                    {
                        Console.Write("Where would you like to place your piece? ");
                        string columnSelect = Console.ReadLine().Trim();
                        int value;
                        if (int.TryParse(columnSelect, out value) && value < 8 && value > 0)
                        {
                            if (GameBoard.PlacePiecePlayerOne(value - 1))
                            {
                                Console.WriteLine($"Piece placed in Column {value}");
                                validColumn = true;
                                if (GameBoard.CheckWin())
                                {
                                    Console.Clear();
                                    PrintBoard();
                                    Console.WriteLine($"Congratulations! {PlayerOne.PlayerName} is the winner");
                                    Console.WriteLine("Press any key to exit.");
                                    Console.ReadLine();
                                    Environment.Exit(0);
                                }
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
                    PrintBoard();
                    Console.WriteLine("\n\n");
                    Console.WriteLine($"{PlayerTwo.PlayerName}'s Turn:");
                    bool validColumn = false;
                    do
                    {
                        Console.Write("Where would you like to place your piece? ");
                        string columnSelect = Console.ReadLine().Trim();
                        int value;
                        if (int.TryParse(columnSelect, out value) && value < 8 && value > 0)
                        {
                            if(GameBoard.PlacePiecePlayerTwo(value - 1))
                            {
                                Console.WriteLine($"Piece placed in Column {value}");
                                validColumn = true;
                                if (GameBoard.CheckWin())
                                {
                                    Console.Clear();
                                    PrintBoard();
                                    Console.WriteLine($"Congratulations! {PlayerTwo.PlayerName} is the winner");
                                    Console.WriteLine("Press any key to exit.");
                                    Console.ReadLine();
                                    Environment.Exit(0);
                                }
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
        private void PrintBoard()
        {

            string[,] board = GameBoard.Board;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[");
                    if (board[i, j].Contains('X'))
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(board[i, j]);
                    }
                    else if(board[i, j].Contains('O'))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(board[i, j]);
                    }
                    else
                    {
                        Console.Write(board[i, j]);
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("]");
                }
                Console.Write("\n");
            }Console.BackgroundColor = ConsoleColor.Black;    
        }
    }
}
