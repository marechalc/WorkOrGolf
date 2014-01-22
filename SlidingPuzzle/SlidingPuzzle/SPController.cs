/****************************************
 * Authors : M. Pereira & J. Peiry
 * Date    : 22.01.14
 * Desc    : Controller for sliding puzzle
 * **************************************/

using System;
namespace SlidingPuzzle
{
    class SPController
    {
        #region fields & get/set

        private SPModel _model;
        private SPView _view;

        internal SPView View
        {
            get { return _view; }
            set { _view = value; }
        }

        internal SPModel Model
        {
            get {
                if (_model == null)
                    _model = new SPModel(); //lazy initialization
                return _model; }
            set { _model = value; }
        }

        #endregion

        /// <summary>
        /// Constructor of the controller
        /// </summary>
        /// <param name="paramView">The view</param>
        public SPController(SPView paramView)
        {
            throw new NotImplementedException();
        }


    }
}
