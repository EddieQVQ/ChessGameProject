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
    public class QueenTests
    {
        [TestMethod()]
        public void Queen_Initialized()
        {
            var board = new Piece[8, 8];
            var queen = new Queen("White");
            board[7, 3] = queen; // Standard starting position for a queen
            Piece.SetBoard(board);

            if (queen == null || queen.Color != "White")
            {
                Assert.Fail("Queen has not been initialized properly.");
            }
        }

        [TestMethod()]
        public void Queen_IsValidMoveTest_Vertical()
        {
            var board = new Piece[8, 8];
            var queen = new Queen("White");
            board[7, 3] = queen;
            Piece.SetBoard(board);

            // Test the queen's vertical move
            bool result = queen.IsValidMove(7, 3, 4, 3);
            Assert.IsTrue(result, "Queen should be able to move vertically without obstruction.");
        }

        [TestMethod()]
        public void Queen_IsValidMoveTest_Horizontal()
        {
            var board = new Piece[8, 8];
            var queen = new Queen("White");
            board[7, 3] = queen;
            Piece.SetBoard(board);

            // Test the queen's horizontal move
            bool result = queen.IsValidMove(7, 3, 7, 6);
            Assert.IsTrue(result, "Queen should be able to move horizontally without obstruction.");
        }

        [TestMethod()]
        public void Queen_IsValidMoveTest_Diagonal()
        {
            var board = new Piece[8, 8];
            var queen = new Queen("White");
            board[7, 3] = queen;
            Piece.SetBoard(board);

            // Test the queen's diagonal move
            bool result = queen.IsValidMove(7, 3, 5, 1);
            Assert.IsTrue(result, "Queen should be able to move diagonally without obstruction.");
        }
    }
}