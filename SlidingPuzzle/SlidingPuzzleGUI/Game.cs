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
namespace SlidingPuzzle
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        None
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
        #endregion

        #region Methods
        /// <summary>
        /// Designed constructor
        /// </summary>
        public Game() : this(new Map(), new Piece[DEFAULT_NB_PIECES])
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
        /// <param name="point"></param>
        /// <returns></returns>
        public Direction[] Move(Point point)
        {
            Direction[] dir = new Direction[4];
            if ((point.Y - 1) >= 0) {
                if (Map.Tiles[point.X, point.Y - 1].IsAllowed == true) {
                    dir[0] = Direction.Up;
                } else
                    dir[0] = Direction.None;            
            }

            if ((point.Y + 1) >= this.Map.Tiles.GetLength(1)) {
                if (Map.Tiles[point.X, point.Y + 1].IsAllowed == true) {
                    dir[1] = Direction.Down;
                } else
                    dir[1] = Direction.None;
                
            }

            if ((point.X - 1) >= 0) {
                if (Map.Tiles[point.X - 1, point.Y].IsAllowed == true) {
                    dir[2] = Direction.Left;
                } else
                    dir[2] = Direction.None;
            }

            if ((point.X + 1) <= this.Map.Tiles.GetLength(0)) {
                if (Map.Tiles[point.X + 1, point.Y].IsAllowed == true) {
                    dir[3] = Direction.Right;
                } else
                    dir[3] = Direction.None;
            }

            return dir;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public bool Move(Point point, Direction direction)
        {
            return true;
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
        #endregion
    }
}
