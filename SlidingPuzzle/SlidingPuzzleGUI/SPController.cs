using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlidingPuzzle;
using System.Drawing;

namespace SlidingPuzzleGUI
{
    class SPController
    {
        #region Fields & Properties
        private SPModel _model;
        private SPView _view;

        internal SPView View
        {
            get { return _view; }
            set { _view = value; }
        }

        internal SPModel Model
        {
            get
            {
                if (_model == null)
                    _model = new SPModel(); //lazy initialization
                return _model;
            }
            set { _model = value; }
        }

        #endregion

        /// <summary>
        /// Constructor of the controller
        /// </summary>
        /// <param name="paramView">The view</param>
        public SPController(SPView paramView)
        {
            this.View = paramView;
            this.Model = new SPModel();
        }

        /// <summary>
        /// Create a new game
        /// </summary>
        public void NewGame()
        {
            this.View.UpdateView();
            this.Model.Score = 0;                    
        }

        /// <summary>
        /// Load a game
        /// </summary>
        public void LoadGame(string filename)
        {
            this.Model.Unserialize(filename);
        }

        /// <summary>
        /// Save the current game
        /// </summary>
        public void SaveGame(string filename)
        {
            this.Model.Serialize(filename);
        }

        public bool Move(Point point, Direction direction)
        {
            bool move = false;
            move = this.Model.Move(point, direction);
            if (move)
            {
                this.Model.Score++;
                this.View.UpdateView();
            }
            return move;
        }

        public Direction[] Move(Point point)
        {
            return this.Model.Move(point);            
        }

        public int[,] GetIds()
        {
            return this.Model.GetSymbolsMap();
        }

        public Image GetImg(int id)
        {
            return this.Model.GetImg(id);
        }

        public void NewMap(int[,] map)
        {
            this.Model.NewMap(map);            
        }

        public void NewPieces(int[,] pieces)
        {
            this.Model.NewPieces(pieces);            
        }

        public void AddImage(int id, Image img)
        {
            this.Model.AddImage(id, img);
        }

        public int GetScore()
        {
            return this.Model.Score;
		}
			
        public bool IsCompleted()
        {
            return this.Model.IsCompleted();
        }
    }
}
