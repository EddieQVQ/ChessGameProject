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
    public class KingTests
    {
        [TestMethod()]
        public void King_Initialized()
        {
            var board = new Piece[8, 8];
            var king = new King("White");
            board[7, 4] = king;
            Piece.SetBoard(board);

            if (king == null || king.Color != "White")
            {
                Assert.Fail("King has not been initialized.");
            } else
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod()]
        public void King_IsValidMoveTest()
        {
            var board = new Piece[8, 8];
            var king = new King("White");
            board[7, 4] = king;
            Piece.SetBoard(board);

            bool result = king.IsValidMove(7, 4, 7, 5);
            Assert.IsTrue(result, "King should be able to move one square in any direction.");
        }
    }
}