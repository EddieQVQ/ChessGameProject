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
    public class BishopTests
    {
        [TestMethod()]
        public void Bishop_Initialized()
        {
            var board = new Piece[8, 8];
            var bishop = new Bishop("White");
            board[7, 2] = bishop;
            Piece.SetBoard(board);

            if (bishop == null || bishop.Color != "White")
            {
                Assert.Fail("Bishop has not been initialized.");
            }
        }

        [TestMethod()]
        public void Bishop_IsValidMoveTest()
        {
            var board = new Piece[8, 8];
            var bishop = new Bishop("White");
            board[7, 2] = bishop;
            Piece.SetBoard(board);

            bool result = bishop.IsValidMove(7, 2, 5, 4);
            Assert.IsTrue(result, "Bishop should be able to move diagonally when there is no obstruction.");
        }
    }
}