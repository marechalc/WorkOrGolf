/*
* Project      : SlidingPuzzle
* Authors      : Marco Lopes, Nuno Sampaio
* Description  : Class map
* File         : Map.cs
* Groups       : 2014.01.22, Marco Lopes & Nuno Sampaio
*                2014.02.26, Premtim Bajrami & Christopher Rejas
*/
using System.Drawing;

namespace SlidingPuzzle
{
    public class Map
    {
        #region Constants
        public const int DEFAULT_TILES_X = 3;
        public const int DEFAULT_TILES_Y = 4;
        #endregion

        #region Fields & Properties
        private Tile[,] _tiles;

        public Tile[,] Tiles
        {
            get { return _tiles; }
            set { _tiles = value; }
        }
        #endregion

        #region Constructors
        public Map() : this(new Tile[DEFAULT_TILES_X, DEFAULT_TILES_Y])
        {
            // NO CODE
        }

        public Map(Tile[,] tiles)
        {
            this.Tiles = tiles;
        }
        #endregion

        #region Methods

        private bool RectangleConditionsAreCorrect(Rectangle rect)
        {
            return (rect.X >= 0 &&
                    rect.Y >= 0 &&
                    rect.X < Tiles.GetLength(0) &&
                    rect.Y < Tiles.GetLength(1) &&
                    rect.X + rect.Width <= Tiles.GetLength(0) &&
                    rect.Y + rect.Height <= Tiles.GetLength(1));
        }

        public bool IsAllowed(Rectangle rect)
        {
            bool allowed = true;
            if (RectangleConditionsAreCorrect(rect))
            {
                for (int i = rect.X; i < (rect.X + rect.Width); i++)
                    for (int j = rect.Y; j < (rect.Y + rect.Height); j++)
                        if (!this.Tiles[i, j].IsAllowed)
                            allowed = false;
            }
            else
                allowed = false;

            return allowed;
        }
        #endregion
    }
}
