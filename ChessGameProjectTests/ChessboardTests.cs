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
    public class ChessboardTests
    {
        [TestMethod()]
        public void ChessboardTest()
        {
            var chessboard = new Chessboard();
            var board = new Piece[8, 8];
            Assert.IsTrue(chessboard.pieces[0, 3] is Queen && chessboard.pieces[0, 3].Color == "Black");
            Assert.IsTrue(chessboard.pieces[7, 3] is Queen && chessboard.pieces[7, 3].Color == "White");
            Assert.IsTrue(chessboard.pieces[0, 4] is King && chessboard.pieces[0, 4].Color == "Black");
            Assert.IsTrue(chessboard.pieces[7, 4] is King && chessboard.pieces[7, 4].Color == "White");
            Assert.IsTrue(chessboard.pieces[0, 2] is Bishop && chessboard.pieces[0, 2].Color == "Black");
            Assert.IsTrue(chessboard.pieces[0, 5] is Bishop && chessboard.pieces[0, 5].Color == "Black");
            Assert.IsTrue(chessboard.pieces[7, 2] is Bishop && chessboard.pieces[7, 2].Color == "White");
            Assert.IsTrue(chessboard.pieces[7, 5] is Bishop && chessboard.pieces[7, 5].Color == "White");
            Assert.IsTrue(chessboard.pieces[0, 1] is Knight && chessboard.pieces[0, 1].Color == "Black");
            Assert.IsTrue(chessboard.pieces[0, 6] is Knight && chessboard.pieces[0, 6].Color == "Black");
            Assert.IsTrue(chessboard.pieces[7, 1] is Knight && chessboard.pieces[7, 1].Color == "White");
            Assert.IsTrue(chessboard.pieces[7, 6] is Knight && chessboard.pieces[7, 6].Color == "White");
            Assert.IsTrue(chessboard.pieces[0, 0] is Rook && chessboard.pieces[0, 0].Color == "Black");
            Assert.IsTrue(chessboard.pieces[0, 7] is Rook && chessboard.pieces[0, 7].Color == "Black");
            Assert.IsTrue(chessboard.pieces[7, 0] is Rook && chessboard.pieces[7, 0].Color == "White");
            Assert.IsTrue(chessboard.pieces[7, 7] is Rook && chessboard.pieces[7, 7].Color == "White");
            for (int i = 0; i < 8; i++)
            {
                Assert.IsTrue(chessboard.pieces[1, i] is Pawn && chessboard.pieces[1, i].Color == "Black");
                Assert.IsTrue(chessboard.pieces[6, i] is Pawn && chessboard.pieces[6, i].Color == "White");
            }
        }
    }
}