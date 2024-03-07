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
    public class RookTests
    {
        [TestMethod()]
        public void Rook_Initialized()
        {
            var board = new Piece[8, 8];
            var rook = new Rook("White");
            board[7, 0] = rook; // Standard starting position for a white rook
            Piece.SetBoard(board);

            if (rook == null || rook.Color != "White")
            {
                Assert.Fail("Rook has not been initialized properly.");
            }
        }

        [TestMethod()]
        public void Rook_IsValidMoveTest_Vertical()
        {
            var board = new Piece[8, 8];
            var rook = new Rook("White");
            board[7, 0] = rook;
            Piece.SetBoard(board);

            // Test the rook's vertical move
            bool result = rook.IsValidMove(7, 0, 4, 0);
            Assert.IsTrue(result, "Rook should be able to move vertically without obstruction.");
        }

        [TestMethod()]
        public void Rook_IsValidMoveTest_Horizontal()
        {
            var board = new Piece[8, 8];
            var rook = new Rook("White");
            board[7, 0] = rook;
            Piece.SetBoard(board);

            // Test the rook's horizontal move
            bool result = rook.IsValidMove(7, 0, 7, 5);
            Assert.IsTrue(result, "Rook should be able to move horizontally without obstruction.");
        }
    }
}