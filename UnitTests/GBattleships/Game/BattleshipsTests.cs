using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GBattleships.Game;

namespace UnitTests.GBattleships.Game
{
    [TestClass]
    public class BattleshipsTests
    {
        [TestMethod]
        public void Battleships_IsGameOver_fasle()
        {
            //Arrange
            Battleships battleships = new Battleships();
            battleships.Start();

            //Act
            bool result = battleships.IsGameOver();

            //Assert
            Assert.IsFalse(result);

        }
    }
}
