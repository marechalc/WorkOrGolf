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
        public const int DEFAULT_TILES_X = 3;
        public const int DEFAULT_TILES_Y = 4;
        private Tile[,] _tiles;

        internal Tile[,] Tiles
        {
            get { return _tiles; }
            set { _tiles = value; }
        }
        #endregion

        #region Constructors
        public Map()
            : this(new Tile[DEFAULT_TILES_X, DEFAULT_TILES_Y])
        {
            // NO CODE
        }

        public Map(Tile[,] tiles)
        {
            if (tiles == null)
                this.Tiles = new Tile[DEFAULT_TILES_X, DEFAULT_TILES_Y]; // NO REPEAT !!
            else
                this.Tiles = tiles;
        }
        #endregion

        public bool IsAllowed(Rectangle rect)
        {
            return false;
        }
    }
}
