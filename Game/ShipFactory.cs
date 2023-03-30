using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GBattleships.Game
{
    internal class ShipFactory
    {
        private const int MAX_INDEX = 9;

        public List<KeyValuePair<int, int>> GetShip(int size, Board board)
        {
            var ship = new List<KeyValuePair<int, int>>();

            bool done = false;
            Random random = new Random();

            while (!done)
            {
                // 1 = horizontal
                // 2 = vertical
                int orientation = random.Next(1, 3); // random direction
                int x = random.Next(0, 10 - (orientation == 1 ? size : 0)); // random start X
                int y = random.Next(0, 10 - (orientation == 1 ? 0 : size)); // random start y
                
                for(int i=0; i<size; i++)
                {
                    if(orientation == 1)
                    {
                        x++;
                    }
                    else
                    {
                        y++;
                    }

                    if(x > MAX_INDEX || y > MAX_INDEX)
                    {
                        ship = new List<KeyValuePair<int, int>>();
                        break;
                    }

                    if(board.IsShip(x, y))
                    {
                        ship = new List<KeyValuePair<int, int>>();
                        break;
                    }

                    ship.Add(new KeyValuePair<int, int>(x, y));
                }

                if(ship.Count == size)
                {
                    done = true;
                }
            }
            
            return ship;
        }
    }
}
