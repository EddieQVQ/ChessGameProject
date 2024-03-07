using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessGameProject.Properties;

/// <summary>
/// Student Name: Eddie Xu, Jeffery MJ, Samuel Park
/// Student Number: A01188464, A01357857, ########
/// Date: 2024-03-05
/// </summary>

namespace ChessGameProject
{
    public partial class Chessboard : Form
    {
        private Button[,] squares = new Button[8, 8];
        public Piece[,] pieces = new Piece[8, 8];
        private Button lastClicked = null;
        private int lastClickedX, lastClickedY;
        private string currentPlayerTurn = "white";
        internal static int whiteMoveCount = 0;
        internal static int blackMoveCount = 0;


        public Chessboard()
        {
            InitializeComponent();
            InitializeChessboard();
            InitializePieces();
            SetInitialImages();
            Piece.SetBoard(pieces);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null) return;
            if (!(clickedButton.Tag is Point location)) return; 

            int x = location.X;
            int y = location.Y;

            if (x < 0 || y < 0 || x >= 8 || y >= 8) return; 

            if (lastClicked == null)
            {
                if (pieces[x, y] == null || pieces[x, y].Color != currentPlayerTurn) return;
                lastClicked = clickedButton;
                lastClickedX = x;
                lastClickedY = y;
                clickedButton.BackColor = Color.LightBlue;
            }
            else
            {
                if (x != lastClickedX || y != lastClickedY) 
                {
                    MovePiece(x, y);
                    squares[lastClickedX, lastClickedY].BackColor = (lastClickedX + lastClickedY) % 2 == 0 ? Color.White : Color.Gray;
                    lastClicked = null;
                }
                else
                {
                    lastClicked.BackColor = (lastClickedX + lastClickedY) % 2 == 0 ? Color.White : Color.Gray;
                    lastClicked = null;
                }
            }
        }

        private void MovePiece(int x, int y)
        {
            if (lastClicked == null || pieces[lastClickedX, lastClickedY] == null) return;

            Piece pieceToMove = pieces[lastClickedX, lastClickedY];
            if (pieceToMove.IsValidMove(lastClickedX, lastClickedY, x, y))
            {
                if (pieces[x, y] is King)
                {
                    string winner = pieceToMove.Color == "white" ? "White" : "Black";
                    MessageBox.Show($"{winner} is the Winner", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetBoard();
                    return;
                }

                pieces[x, y] = pieceToMove;
                pieces[lastClickedX, lastClickedY] = null;
                squares[x, y].BackgroundImage = squares[lastClickedX, lastClickedY].BackgroundImage;
                squares[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                squares[lastClickedX, lastClickedY].BackgroundImage = null;
                currentPlayerTurn = currentPlayerTurn == "white" ? "black" : "white";
                lastClicked.BackColor = (lastClickedX + lastClickedY) % 2 == 0 ? Color.White : Color.Gray;
                Refresh();
            }
            else
            {
                lastClicked.BackColor = (lastClickedX + lastClickedY) % 2 == 0 ? Color.White : Color.Gray;
            }
        }

        private void ResetBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    pieces[i, j] = null;
                    squares[i, j].BackgroundImage = null;
                }
            }
            InitializePieces();
            currentPlayerTurn = "white";
        }

        private void InitializePieces()
        {
            pieces = new Piece[8, 8];
            for (int i = 0; i < 8; i++)
            {
                pieces[1, i] = new Pawn("black");
                squares[1, i].BackgroundImage = Properties.Resources.black_pawn;
            }
            pieces[0, 0] = new Rook("black");
            pieces[0, 7] = new Rook("black");
            pieces[0, 1] = new Knight("black");
            pieces[0, 6] = new Knight("black");
            pieces[0, 2] = new Bishop("black");
            pieces[0, 5] = new Bishop("black");
            pieces[0, 3] = new Queen("black");
            pieces[0, 4] = new King("black");

            for (int i = 0; i < 8; i++)
            {
                pieces[6, i] = new Pawn("white");
                squares[6, i].BackgroundImage = Properties.Resources.white_pawn;
            }
            pieces[7, 0] = new Rook("white");
            pieces[7, 7] = new Rook("white");
            pieces[7, 1] = new Knight("white");
            pieces[7, 6] = new Knight("white");
            pieces[7, 2] = new Bishop("white");
            pieces[7, 5] = new Bishop("white");
            pieces[7, 3] = new Queen("white");
            pieces[7, 4] = new King("white");

            squares[0, 0].BackgroundImage = Properties.Resources.black_rook;
            squares[0, 7].BackgroundImage = Properties.Resources.black_rook;
            squares[0, 1].BackgroundImage = Properties.Resources.black_knight;
            squares[0, 6].BackgroundImage = Properties.Resources.black_knight;
            squares[0, 2].BackgroundImage = Properties.Resources.black_bishop;
            squares[0, 5].BackgroundImage = Properties.Resources.black_bishop;
            squares[0, 3].BackgroundImage = Properties.Resources.black_queen;
            squares[0, 4].BackgroundImage = Properties.Resources.black_king;
            squares[7, 0].BackgroundImage = Properties.Resources.white_rook;
            squares[7, 7].BackgroundImage = Properties.Resources.white_rook;
            squares[7, 1].BackgroundImage = Properties.Resources.white_knight;
            squares[7, 6].BackgroundImage = Properties.Resources.white_knight;
            squares[7, 2].BackgroundImage = Properties.Resources.white_bishop;
            squares[7, 5].BackgroundImage = Properties.Resources.white_bishop;
            squares[7, 3].BackgroundImage = Properties.Resources.white_queen;
            squares[7, 4].BackgroundImage = Properties.Resources.white_king;
        }

        private void SetInitialImages()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    squares[i, j].BackgroundImage = null;

                    if (pieces[i, j] != null)
                    {
                        string pieceType = pieces[i, j].GetType().Name.ToLower();
                        string color = pieces[i, j].Color.ToLower();
                        string resourceName = $"{color}_{pieceType}";
                        var image = (Image)Properties.Resources.ResourceManager.GetObject(resourceName);

                        if (image != null)
                        {
                            squares[i, j].BackgroundImage = image;
                            squares[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                        }
                    }
                }
            }
        }
    }

    public abstract class Piece
    {
        public string Color { get; private set; }
        public bool HasMoved { get; protected set; }
        public static Piece[,] Board { get; private set; }

        protected Piece(string color)
        {
            Color = color;
            HasMoved = false;
        }

        public static void SetBoard(Piece[,] b) => Board = b;
        public abstract bool IsValidMove(int startX, int startY, int endX, int endY);
    }

    public class Pawn : Piece
    {
        public Pawn(string color) : base(color) { }

        public override bool IsValidMove(int startX, int startY, int endX, int endY)
        {
            int direction = this.Color == "white" ? -1 : 1;
            bool isFirstMove = (this.Color == "white" && startX == 6) || (this.Color == "black" && startX == 1);
            bool isForwardOne = startX + direction == endX && startY == endY && Board[endX, endY] == null;
            bool isForwardTwo = isFirstMove && startX + 2 * direction == endX && startY == endY && Board[endX, endY] == null && Board[startX + direction, startY] == null;
            bool isCapture = startX + direction == endX && Math.Abs(endY - startY) == 1 && Board[endX, endY] != null && Board[endX, endY].Color != this.Color;
            bool isEnPassant = startX + direction == endX && Math.Abs(endY - startY) == 1 && Board[endX, endY] == null && Board[startX, endY] != null && Board[startX, endY] is Pawn && Board[startX, endY].Color != this.Color && ((this.Color == "white" && Chessboard.blackMoveCount == 1) || (this.Color == "black" && Chessboard.whiteMoveCount == 1));

            if (isForwardOne || isForwardTwo)
            {
                return true;
            }
            else if (isCapture)
            {
                return true;
            }
            else if (isEnPassant)
            {
                Board[startX, endY] = null;
                return true;
            }
            return false;
        }

    }

    public class Rook : Piece
    {
        public Rook(string color) : base(color) { }

        public override bool IsValidMove(int startX, int startY, int endX, int endY)
        {
            if (startX != endX && startY != endY) return false;
            int min = startX == endX ? Math.Min(startY, endY) : Math.Min(startX, endX);
            int max = startX == endX ? Math.Max(startY, endY) : Math.Max(startX, endX);
            for (int i = min + 1; i < max; i++)
            {
                if (startX == endX && Board[endX, i] != null) return false;
                if (startY == endY && Board[i, endY] != null) return false;
            }
            return Board[endX, endY] == null || Board[endX, endY].Color != this.Color;
        }
    }

    public class Knight : Piece
    {
        public Knight(string color) : base(color) { }

        public override bool IsValidMove(int startX, int startY, int endX, int endY)
        {
            if ((Math.Abs(startX - endX) == 2 && Math.Abs(startY - endY) == 1) || (Math.Abs(startX - endX) == 1 && Math.Abs(startY - endY) == 2))
            {
                if (Board[endX, endY] != null && Board[endX, endY].Color == this.Color)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

    }

    public class Bishop : Piece
    {
        public Bishop(string color) : base(color) { }

        public override bool IsValidMove(int startX, int startY, int endX, int endY)
        {
            if (Math.Abs(startX - endX) != Math.Abs(startY - endY)) return false;
            int stepX = (endX > startX) ? 1 : -1;
            int stepY = (endY > startY) ? 1 : -1;
            int distance = Math.Abs(endX - startX);
            for (int i = 1; i < distance; i++)
            {
                if (Board[startX + i * stepX, startY + i * stepY] != null) return false;
            }
            return Board[endX, endY] == null || Board[endX, endY].Color != this.Color;
        }
    }

    public class Queen : Piece
    {
        public Queen(string color) : base(color) { }

        public override bool IsValidMove(int startX, int startY, int endX, int endY)
        {
            if (startX != endX && startY != endY && Math.Abs(startX - endX) != Math.Abs(startY - endY)) return false;
            int stepX = startX == endX ? 0 : (endX > startX ? 1 : -1);
            int stepY = startY == endY ? 0 : (endY > startY ? 1 : -1);
            int distance = Math.Max(Math.Abs(endX - startX), Math.Abs(endY - startY));
            for (int i = 1; i < distance; i++)
            {
                if (Board[startX + i * stepX, startY + i * stepY] != null) return false;
            }
            if (Board[endX, endY] != null && Board[endX, endY].Color == this.Color) return false;
            return true;
        }
    }

    public class King : Piece
    {
        public King(string color) : base(color) { }
            
        public override bool IsValidMove(int startX, int startY, int endX, int endY)
        {
            if (Math.Abs(startX - endX) > 1 || Math.Abs(startY - endY) > 1) return false;
            return Board[endX, endY] == null || Board[endX, endY].Color != this.Color;
        }
    }
}