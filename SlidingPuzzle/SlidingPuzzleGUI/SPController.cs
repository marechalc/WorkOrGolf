﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlidingPuzzle;

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
            this.Model.Game = new Game(new Map(new Tile[33, 25]), new Piece[3]);
            this.View.UpdateView();
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
    }
}