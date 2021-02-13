using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFore.Classes
{
    public class GameBoard
    {
        public string[,] Board { get; private set; }

        public GameBoard()
        {
            Board = new string[7, 7] { {"1 ","2 ","3 ","4 ","5 ","6 ","7"},
                {"- ","- ","- ","- ","- ","- ","-"},
                {"- ","- ","- ","- ","- ","- ","-"},
                {"- ","- ","- ","- ","- ","- ","-"},
                {"- ","- ","- ","- ","- ","- ","-"},
                {"- ","- ","- ","- ","- ","- ","-"},
                {"- ","- ","- ","- ","- ","- ","-"} };
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
            if (!Board[1, column].Contains('-'))
            {
                return false;
            }else
            {
                for (int i = 6; i > 0; i--)
                {
                    if (Board[i, column].Contains('-'))
                    {
                        string replaceSlot = Board[i, column].Replace('-', 'X');
                        Board[i, column] = replaceSlot;
                        return true;
                    }
                }return false;
            }

        }
        public bool PlacePiecePlayerTwo(int column)
        {
            if (!Board[1, column].Contains('-'))
            {
                return false;
            }
            else
            {
                for (int i = 6; i > 0; i--)
                {
                    if (Board[i, column].Contains('-'))
                    {
                        string replaceSlot = Board[i, column].Replace('-', 'O');
                        Board[i, column] = replaceSlot;
                        return true;
                    }
                }
                return false;
            }

        }

    }
}
