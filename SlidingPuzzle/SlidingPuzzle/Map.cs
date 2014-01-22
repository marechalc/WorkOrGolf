/*
* Project      : SlidingPuzzle
* Authors      : Marco Lopes, Nuno Sampaio
* Description  : Class map
* File         : Map.cs
* Groups       : 2014.01.22 , Macro Lopes & Nuno Sampaio
*/
using System.Drawing;

namespace SlidingPuzzle
{
    class Map
    {
        #region Fields
        private Tile[,] _tiles;

        internal Tile[,] Tiles
        {
            get { return _tiles; }
            set { _tiles = value; }
        }
        #endregion

        #region Constructors
        public Map()
            : this(new Tile[3, 3])
        {
            // NO CODE
        }

        public Map(Tile[,] tiles)
        {
            this.Tiles = tiles;
        }
        #endregion

        public bool IsAllowed(Rectangle rect)
        {
            return false;
        }
    }
}
