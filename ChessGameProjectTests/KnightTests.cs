using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessGameProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameProject.Tests
{
    [TestClass()]
    public class KnightTests
    {
        [TestMethod()]
        public void Knight_Initialized()
        {
            var board = new Piece[8, 8];
            var knight = new Knight("White");
            board[7, 1] = knight; 
            Piece.SetBoard(board);

            if (knight == null || knight.Color != "White")
            {
                Assert.Fail("Knight has not been initialized properly.");
            }
        }

        [TestMethod()]
        public void Knight_IsValidMoveTest()
        {
            var board = new Piece[8, 8];
            var knight = new Knight("White");
            board[7, 1] = knight;
            Piece.SetBoard(board);

            bool result = knight.IsValidMove(7, 1, 5, 2);
            Assert.IsTrue(result, "Knight should be able to move in an L shape.");
        }
    }
}