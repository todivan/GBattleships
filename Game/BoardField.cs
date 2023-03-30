using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBattleships.Game
{
    internal class BoardField
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public bool IsShip { get; set; }
        public bool IsHit { get; set; }
    }
}
