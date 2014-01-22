/*
 * Project : Sliding Puzzle - Work Or Golf
 * Authors : RC & MS
 * Date    : 2014-01-22
 * 
 * Vers.   : 1.0, CFPTI Technicien ES
 */
using System.Drawing;
namespace SlidingPuzzle
{
    enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        None

    }

    class Game
    {
        #region Fields
        private Map _map;
        private Piece[] _pieces;
        #endregion

        #region Const.
        const int DEFAULT_NB_PIECES = 1;
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

        public Game():this(new Map(), new Piece[DEFAULT_NB_PIECES])
        {
            //NO CODE
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="map"></param>
        /// <param name="pieces"></param>
        public Game(Map map, Piece[] pieces)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public Direction[] Move(Point point)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public bool Move(Point point, Direction direction)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsCompleted()
        {

        }
    }
}
