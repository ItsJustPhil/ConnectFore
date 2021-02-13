using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFore.Classes
{
    public class Player
    {
        public string PlayerName { get; private set; }
        public int Score { get; private set; }
        public Player(string name)
        {
            PlayerName = name;
            Score = 0;
        }

        public bool Win()
        {
            Score++;
            return true;
        }
    }
}
