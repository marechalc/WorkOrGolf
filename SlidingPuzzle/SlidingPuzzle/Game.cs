/*
 * File    : Game.cs
 * Project : Sliding Puzzle - Work Or Golf
 * Authors : rejas c, menetrey s.
 * Date    : 2014-01-22
 * 
 * Vers.   : 1.0, 2014-01-22, CFPTI Technicien ES by : rejas c, menetrey s.
 * 
 * Authors : Pereira M, Sampaio N.
 * Date    : 2014-02-05
 * Description : Add method Move(Point point)
 *               Initialization of final pieces for method IsCompleted
 */

using System.Drawing;
using System.Collections.Generic;
using System;
namespace SlidingPuzzle
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    class Game
    {
        #region Const.
        const int DEFAULT_NB_PIECES = 1;
        #endregion

        #region Fields
        private Map _map;
        private Piece[] _pieces;
        #endregion

        #region Properties
        public Piece[] Pieces
        {
            get { return _pieces; }
            set { _pieces = value; }
        }

        public Map Map
        {
            get { return _map; }
            set { _map = value; }
        }

        private int Width
        {
            get { return Map.Tiles.GetLength(0); }
        }

        private int Height
        {
            get { return Map.Tiles.GetLength(1); }
        }

        #endregion

        #region Methods
        /// <summary>
        /// Designed constructor
        /// </summary>
        public Game()
            : this(new Map(), new Piece[DEFAULT_NB_PIECES] {new Piece()})
        { } // No code

        /// <summary>
        /// 
        /// </summary>
        /// <param name="map"></param>
        /// <param name="pieces"></param>
        public Game(Map map, Piece[] pieces)
        {
            this.Map = map;
            this.Pieces = pieces;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private Piece GetPieceFromPoint(Point p)
        {
            foreach (Piece piece in Pieces)
            {
                if (piece.Rect.Contains(p))
                {
                    return piece;
                }
            }
            return null;
        }

        //TODO: put this method somewhere accessible by all classes
        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private Point DirectionToPoint(Direction d)
        {
            switch (d)
            {
                case Direction.Down:
                    return new Point(0, 1);
                case Direction.Left:
                    return new Point(-1, 0);
                case Direction.Right:
                    return new Point(1, 0);
                case Direction.Up:
                    return new Point(0, -1);
                default:
                    return new Point(0, 0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        private IEnumerable<Point> PointsNextToPiece(Piece p, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    for (int x = 0; x < p.Rect.Width; x++)
                        yield return new Point(x, p.Rect.Top-1);
                    break;
                case Direction.Down:
                    for (int x = 0; x < p.Rect.Width; x++)
                        yield return new Point(x, p.Rect.Bottom);
                    break;
                case Direction.Left:
                    for (int y = 0; y < p.Rect.Height; y++)
                        yield return new Point(p.Rect.Left - 1, y);
                    break;
                case Direction.Right:
                    for (int y = 0; y < p.Rect.Height; y++)
                        yield return new Point(p.Rect.Right, y);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        private bool CanMove(Piece p, Direction direction)
        {
            Point pointDirection = DirectionToPoint(direction);
            Point nextPoint = new Point(p.Rect.X + pointDirection.X, p.Rect.Y + pointDirection.Y);

            if (nextPoint.X < 0 || nextPoint.X >= Width || nextPoint.Y < 0 || nextPoint.Y >= Height)
            {
                return false;
            }
            else if (!Map.Tiles[nextPoint.X, nextPoint.Y].IsAllowed)
            {
                return false;
            }

            Piece nextToPiece = GetPieceFromPoint(nextPoint);
            if (nextToPiece != null)
            {
                return CanMove(nextToPiece, direction);
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Direction[] Move(Point p)
        {
            List<Direction> possiblesDirections = new List<Direction>();
            Piece piece = GetPieceFromPoint(p);
            if (piece != null)
            {
                foreach (Direction direction in Enum.GetValues(typeof(Direction)))
                {

                    if (CanMove(piece, direction))
                    {
                        possiblesDirections.Add(direction);
                    }
                }
                if (possiblesDirections.Count == 1)
                    Move(piece, possiblesDirections[0]);
            }

            return possiblesDirections.ToArray();
        }

        /// <summary>
        /// Actually move the pieces, assume the piece can move
        /// </summary>
        /// <param name="p"></param>
        /// <param name="direction"></param>
        private void Move(Piece p, Direction direction)
        {
            Point pointDirection = DirectionToPoint(direction);
            Point nextPoint = new Point(p.Rect.X + pointDirection.X, p.Rect.Y + pointDirection.Y);
            Piece nextToPiece = GetPieceFromPoint(nextPoint);
            if (nextToPiece != null)
            {
                Move(nextToPiece, direction);
            }
            p.Rect = new Rectangle(nextPoint.X, nextPoint.Y, p.Rect.Width, p.Rect.Height);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public bool Move(Point point, Direction direction)
        {
            Piece piece = GetPieceFromPoint(point);
            bool moved = false;
            if (piece != null && CanMove(piece, direction))
            {
                Move(piece, direction);
                moved = true;
            }
            return moved;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsCompleted()
        {
            bool completed = false;
            // Initialization of final pieces
            Piece[] piecesFinal = new Piece[8];
            piecesFinal[0] = new Piece(new Rectangle(0, 0, 1, 1), 4);
            piecesFinal[1] = new Piece(new Rectangle(1, 0, 1, 1), 5);
            piecesFinal[2] = new Piece(new Rectangle(2, 0, 1, 1), 6);
            piecesFinal[3] = new Piece(new Rectangle(3, 0, 1, 1), 7);

            piecesFinal[4] = new Piece(new Rectangle(0, 4, 1, 1), 0);
            piecesFinal[5] = new Piece(new Rectangle(1, 4, 1, 1), 1);
            piecesFinal[6] = new Piece(new Rectangle(2, 4, 1, 1), 2);
            piecesFinal[7] = new Piece(new Rectangle(3, 4, 1, 1), 3);

            // Test if current game is completed

            return completed;
        }

        public int[,] GetSymbolsMap()
        {
            int[,] symbolsMap = new int[Width, Height];


            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    symbolsMap[x, y] = Map.Tiles[x, y].SymbolId;
                }
            }

            foreach (Piece piece in Pieces)
            {
                for (int x = piece.Rect.Left; x < piece.Rect.Right; x++)
                {
                    for (int y = piece.Rect.Top; y < piece.Rect.Bottom; y++)
                    {
                        symbolsMap[x, y] = piece.SymbolId;
                    }
                }

            }

            return symbolsMap;
        }

        #endregion
    }


}
