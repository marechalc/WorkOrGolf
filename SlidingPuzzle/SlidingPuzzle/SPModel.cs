
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlidingPuzzle;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;

namespace SlidingPuzzle
{
    [Serializable]
    class SPModel
    {
        const string DEFAULT_SAVE_FILENAME = "MyGame";


        #region fields & get/set
        private Game _game;
        private Dictionary<int, Image> _images;
        private int _score;

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public Dictionary<int, Image> Images
        {
            get
            {
                if (_images == null)
                    _images = new Dictionary<int, Image>(); //Lazy initialization
                return _images;
            }
            set { _images = value; }
        }

        internal Game Game
        {
            get
            {
                if (_game == null)
                    _game = new Game(); // lazy initialization
                return _game;
                // return (_game == null) ? new Game() : _game;
            }
            set { _game = value; }
        }

        #endregion

        /// <summary>
        /// Constructor of the model
        /// </summary>
        public SPModel()
        {
            this.Score = 0;
        }

        public void Serialize(string filename = DEFAULT_SAVE_FILENAME)
        {
            // Reference : http://msdn.microsoft.com/.../lib.../4abbf6k0(v=vs.110).aspx
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this.Game);
            stream.Close();
        }

        public void Unserialize(string filename = DEFAULT_SAVE_FILENAME)
        {
            // Reference : http://msdn.microsoft.com/.../lib.../4abbf6k0(v=vs.110).aspx
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            this.Game = (Game)formatter.Deserialize(stream);
            stream.Close();
        }

        public bool Move(Point point, Direction direction)
        {

            return this.Game.Move(point, direction);
        }

        public Direction[] Move(Point point)
        {
            return this.Game.Move(point);
        }

        public int[,] GetSymbolsMap()
        {
            //return this.Game.Map.Tiles[point.X, point.Y].SymbolId;
            return this.Game.GetSymbolsMap();
        }

        public Image GetImg(int id)
        {
            return this.Images[id];
        }

        public void NewMap(int[,] map)
        {
            Tile[,] tiles = new Tile[map.GetLength(0), map.GetLength(1)];
            Boolean isAllowed;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    isAllowed = true;
                    if (map[i, j] == 1) //If symbolId equals 1, then it's an unallowed tile
                    {
                        isAllowed = false;
                    }
                    tiles[i, j] = new Tile(isAllowed, map[i, j]);
                }
            }
            this.Game.Map = new Map(tiles);

        }

        public void NewPieces(int[,] pieces)
        {
            List<Piece> newPieces = new List<Piece>();
            for (int i = 0; i < pieces.GetLength(0); i++)
            {
                for (int j = 0; j < pieces.GetLength(1); j++)
                {
                    if (pieces[i, j] != 0)
                        newPieces.Add(new Piece(new Rectangle(new Point(i, j), new Size(1, 1)), pieces[i, j]));
                }
            }
            this.Game.Pieces = newPieces.ToArray();

        }

        public void AddImage(int id, Image img)
        {
            Images.Add(id, img);
        }

    }
}
