using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBattleships.Game
{
    internal class Battleships
    {
        public Board PlayerBoard { get; private set; }
        public Board ComputerBoard { get; private set; }

        public Battleships() 
        {
            PlayerBoard = new Board();
            ComputerBoard = new Board();
        }



        /// <summary>
        /// Initialize all data
        /// </summary>
        public void Start()
        {
            BoardFactory boardFactory = new BoardFactory();

            PlayerBoard = boardFactory.GetBoard(isPlayer: true);
            ComputerBoard = boardFactory.GetBoard(isPlayer: false);
        }

        /// <summary>
        /// All player move activities
        /// </summary>
        /// <returns></returns>
        public bool PlayerTurn()
        {
            return false;
        }

        /// <summary>
        /// All computer move activities
        /// </summary>
        public void ComputerTurn() 
        {

        }

        /// <summary>
        /// Check is game over
        /// </summary>
        /// <returns></returns>
        public bool IsGmaeOver()
        { return false; }
    }
}
