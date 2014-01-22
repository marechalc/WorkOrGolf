/*
 * File    : Game.cs
 * Project : Sliding Puzzle - Work Or Golf
 * Authors : rejas c, menetrey s.
 * Date    : 2014-01-22
 * 
 * Vers.   : 1.0, 2014-01-22, CFPTI Technicien ES by : rejas c, menetrey s.
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
            return new Direction[1];
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
            return true;
        }
        #endregion
    }
}
