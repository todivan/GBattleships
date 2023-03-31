using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBattleships.Game
{
    internal interface IBoard
    {
        bool IsAllHit();
        bool IsShip(int x, int y);
        BoardField GetField(int x, int y);
    }
}
