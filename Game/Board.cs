using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBattleships.Game
{
    internal class Board
    {
        public Board() 
        {
            Fields = new BoardField[10, 10];
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    Fields[x, y] = new BoardField() { IsHit = false, IsShip = false };
                }
            }
        }

        public BoardField[,] Fields { get; private set; }

        public bool IsPlayer { get; set; }

        public BoardField GetField(int x, int y)
        { 
            return Fields[x, y]; 
        }

        public bool IsShip(int x, int y)
        {
            return Fields[x, y].IsShip;
        }

        public void AddShip(List<KeyValuePair<int, int>> ship)
        {
            foreach(var shipField in ship)
            {
                Fields[shipField.Key, shipField.Value].IsShip = true;
            }
        }
    }
}
