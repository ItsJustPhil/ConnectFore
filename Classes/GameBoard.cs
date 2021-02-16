using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFore.Classes
{
    public class GameBoard
    {
        public string[,] Board { get; private set; }
        private int[] LastPlaced { get; set; }
        private char WinCheckPiece { get; set; }
        public GameBoard()
        {
            LastPlaced = new int[2];
            Board = new string[7, 7] { {"1","2","3","4","5","6","7"},
                {" "," "," "," "," "," "," "},
                {" "," "," "," "," "," "," "},
                {" "," "," "," "," "," "," "},
                {" "," "," "," "," "," "," "},
                {" "," "," "," "," "," "," "},
                {" "," "," "," "," "," "," "} };
        }

        public string ViewBoard() {
            string boardState = "\n\n";
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    boardState += Board[i, j];
                }
                boardState += "\n";
            }return boardState;
        }

        public bool PlacePiecePlayerOne(int column)
        {
            if (!Board[1, column].Contains(' '))
            {
                return false;
            }else
            {
                for (int i = 6; i > 0; i--)
                {
                    if (Board[i, column].Contains(' '))
                    {
                        string replaceSlot = Board[i, column].Replace(' ', 'X');
                        Board[i, column] = replaceSlot;
                        LastPlaced[0] = i;
                        LastPlaced[1] = column;
                        return true;
                    }
                }return false;
            }

        }
        public bool PlacePiecePlayerTwo(int column)
        {
            if (!Board[1, column].Contains(' '))
            {
                return false;
            }
            else
            {
                for (int i = 6; i > 0; i--)
                {
                    if (Board[i, column].Contains(' '))
                    {
                        string replaceSlot = Board[i, column].Replace(' ', 'O');
                        Board[i, column] = replaceSlot;
                        LastPlaced[0] = i;
                        LastPlaced[1] = column;
                        return true;
                    }
                }
                return false;
            }

        }

        private bool CheckUp(int distance)
        {
            if ((LastPlaced[0] - distance) > -1 && Board[LastPlaced[0] - distance, LastPlaced[1]].Contains(WinCheckPiece))
            {
                return true;
            }else
            {
                return false;
            }
        }
        private bool CheckDown(int distance)
        {
            if ((LastPlaced[0] + distance) < 7 && Board[LastPlaced[0] + distance, LastPlaced[1]].Contains(WinCheckPiece))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckUpRight(int distance)
        {
            if ((LastPlaced[0] - distance) > -1 && (LastPlaced[1] + distance) < 7 &&  Board[LastPlaced[0] - distance, LastPlaced[1] + distance].Contains(WinCheckPiece))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckUpLeft(int distance)
        {
            if ((LastPlaced[0] - distance) > -1 && (LastPlaced[1] - distance) > -1 && Board[LastPlaced[0] - distance, LastPlaced[1] - distance].Contains(WinCheckPiece))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckLeft(int distance)
        {
            if ((LastPlaced[1] - distance) > -1 && Board[LastPlaced[0], LastPlaced[1] - distance].Contains(WinCheckPiece))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckRight(int distance)
        {
            if ((LastPlaced[1] + distance) < 7 && Board[LastPlaced[0], LastPlaced[1] + distance].Contains(WinCheckPiece))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckDownLeft(int distance)
        {
            if((LastPlaced[0] + distance) < 7 && (LastPlaced[1] - distance) > -1 && Board[LastPlaced[0] + distance, LastPlaced[1] - distance].Contains(WinCheckPiece))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckDownRight(int distance)
        {
            if ((LastPlaced[0] + distance) < 7 && (LastPlaced[1] + distance) < 7 && Board[LastPlaced[0] + distance, LastPlaced[1] + distance].Contains(WinCheckPiece))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckWin()
        {
            if (Board[LastPlaced[0], LastPlaced[1]].Contains('X'))
            {
                WinCheckPiece = 'X';
            }
            else
            {
                WinCheckPiece = 'O';
            }

            if (CheckDown(1))
            {
                if (CheckDown(2))
                {
                    if (CheckDown(3))
                    {
                        return true;
                    }
                    if (CheckUp(1))
                    {
                        return true;
                    }
                }
                if (CheckUp(1))
                {
                    if (CheckUp(2))
                    {
                        return true;
                    }
                }
            }
            if (CheckDownRight(1))
            {
                if (CheckDownRight(2))
                {
                    if (CheckDownRight(3))
                    {
                        return true;
                    }
                    if (CheckUpLeft(1))
                    {
                        return true;
                    }
                }
                if (CheckUpLeft(1))
                {
                    if (CheckUpLeft(2))
                    {
                        return true;
                    }
                }
            }
            if (CheckRight(1))
            {
                if (CheckRight(2))
                {
                    if (CheckRight(3))
                    {
                        return true;
                    }
                    if (CheckLeft(1))
                    {
                        return true;
                    }
                }
                if (CheckLeft(1))
                {
                    if (CheckLeft(2))
                    {
                        return true;
                    }
                }
            }
            if (CheckDownLeft(1))
            {
                if (CheckDownLeft(2))
                {
                    if (CheckDownLeft(3))
                    {
                        return true;
                    }
                    if (CheckUpRight(1))
                    {
                        return true;
                    }
                }
                if (CheckUpRight(1))
                {
                    if (CheckUpRight(2))
                    {
                        return true;
                    }
                }
            }
            if (CheckLeft(1))
            {
                if (CheckLeft(2))
                {
                    if (CheckLeft(3))
                    {
                        return true;
                    }
                    if (CheckRight(1))
                    {
                        return true;
                    }
                }
                if (CheckRight(1))
                {
                    if (CheckRight(2))
                    {
                        return true;
                    }
                }
            }
            if (CheckUpLeft(1))
            {
                if (CheckUpLeft(2))
                {
                    if (CheckUpLeft(3))
                    {
                        return true;
                    }
                    if (CheckDownRight(1))
                    {
                        return true;
                    }
                }
                if (CheckDownRight(1))
                {
                    if (CheckDownRight(2))
                    {
                        return true;
                    }
                }
            }
            if (CheckUpRight(1))
            {
                if (CheckUpRight(2))
                {
                    if (CheckUpRight(3))
                    {
                        return true;
                    }
                    if (CheckDownLeft(1))
                    {
                        return true;
                    }
                }
                if (CheckDownRight(1))
                {
                    if (CheckDownRight(2))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
