/****************************************
 * Authors : M. Pereira & J. Peiry
 * Date    : 22.01.14
 * Desc    : Model for sliding puzzle
 * **************************************/

using System;
namespace SlidingPuzzle
{
    class SPModel {

        #region fields & get/set
        private Game _game;

        internal Game Game {
            get {
                if (_game == null)
                    _game = new Game(); //lazy initialization                
                return _game; }
            set { _game = value; }
        }
        #endregion

        /// <summary>
        /// Constructor of the model
        /// </summary>
        public SPModel()
        {
            throw new NotImplementedException();
        }
    }
}
