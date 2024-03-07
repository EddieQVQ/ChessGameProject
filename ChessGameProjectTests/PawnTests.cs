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
    public class PawnTests
    {
        [TestMethod()]
        public void Pawn_Initialized()
        {
            var board = new Piece[8, 8];
            var pawn = new Pawn("White");
            board[6, 0] = pawn;
            Piece.SetBoard(board);

            if (pawn == null || pawn.Color != "White")
            {
                Assert.Fail("Pawn has not been initialized properly.");
            }
        }

        [TestMethod()]
        public void Pawn_IsValidMoveTest_ForwardOne()
        {
            var board = new Piece[8, 8];
            var pawn = new Pawn("White");
            board[6, 0] = pawn;
            Piece.SetBoard(board);

            bool result = pawn.IsValidMove(6, 0, 5, 0);
            Assert.IsTrue(result, "Pawn should be able to move forward one square.");
        }

        [TestMethod()]
        public void Pawn_IsValidMoveTest_ForwardTwo_Initial()
        {
            var board = new Piece[8, 8];
            var pawn = new Pawn("White");
            board[6, 1] = pawn;
            Piece.SetBoard(board);

            bool result = pawn.IsValidMove(6, 1, 4, 1);
            Assert.IsTrue(result, "Pawn should be able to move forward two squares on its first move.");
        }
    }
}