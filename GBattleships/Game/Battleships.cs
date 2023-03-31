﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GBattleships.Game
{
    /// <summary>
    /// Class hold domain logic of the game
    /// </summary>
    public class Battleships
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
            System.Threading.Thread.Sleep(100);
            ComputerBoard = boardFactory.GetBoard(isPlayer: false);
        }

        /// <summary>
        /// All player move activities
        /// </summary>
        /// <returns></returns>
        public void PlayerTurn(FireCommand fireCommand)
        {
            ComputerBoard.HitField(fireCommand.X, fireCommand.Y);
        }

        /// <summary>
        /// All computer move activities
        /// </summary>
        public FireCommand ComputerTurn() 
        {
            List<BoardField> availableFields = new List<BoardField>();
            foreach (var field in PlayerBoard.Fields)
            {
                if(!field.IsHit)
                {
                    availableFields.Add(field);
                }
            }

            Random random = new Random();
            var randomIndexOfFieldToPlay = random.Next(availableFields.Count);

            var fieldToPlay = availableFields[randomIndexOfFieldToPlay];
            fieldToPlay.IsHit = true;

            FireCommand fireCommand = new FireCommand(fieldToPlay.Column, fieldToPlay.Row);
            return fireCommand;
        }

        /// <summary>
        /// Check is game over
        /// </summary>
        /// <returns></returns>
        public bool IsGameOver()
        {
            return PlayerBoard.IsAllHit() || ComputerBoard.IsAllHit(); 
        }
    }
}
