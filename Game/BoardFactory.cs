using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBattleships.Game
{
    internal class BoardFactory
    {
        public Board GetBoard(bool isPlayer)
        {
            Board board = new Board();
            board.IsPlayer = isPlayer;

            Shuffle(board);

            return board; 
        }

        /// <summary>
        /// Generate board with random located ships
        /// </summary>
        private void Shuffle(Board board)
        {
            ShipFactory shipFactory = new ShipFactory();

            var ship5 = shipFactory.GetShip(5, board);
            board.AddShip(ship5);

            var ship41 = shipFactory.GetShip(4, board);
            board.AddShip(ship41);

            var ship42 = shipFactory.GetShip(4, board);
            board.AddShip(ship42);
        }
    }
}
