/*
 * Title : Piece Class
 * Version :
 * 1.0 : Creation - BAJRAMI & TUX
 */
using System.Drawing;
using System;

namespace SlidingPuzzle
{
    [Serializable]
    public class Piece
    {
        #region Consts
        static readonly Point DEFAULT_LOCATION = new Point(0,0);
        static readonly Size DEFAULT_SIZE = new Size(1, 1);
        const int DEFAULT_SYMBOL_ID = 0;
        #endregion

        #region Fields
        private Rectangle _rect;
        private int _symbolId;
        #endregion

        #region Properties
        public int SymbolId
        {
            get { return _symbolId; }
            set { _symbolId = value; }
        }

        public Rectangle Rect
        {
            get { return _rect; }
            set { _rect = value; }
        }
        #endregion

        /// <summary>
        ///  Initializes a new instance of the <see cref="SlidingPuzzle"/> class.
        /// </summary>
        public Piece()
            : this(new Rectangle(DEFAULT_LOCATION, DEFAULT_SIZE), DEFAULT_SYMBOL_ID)
        {
            // No code
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="SlidingPuzzle"/> class with a rectangle and a symbol id.
        /// </summary>
        /// <param name="rect">Size and position of the piece</param>
        /// <param name="symbolId">Index of the symbol</param>
        public Piece(Rectangle rect, int symbolId)
        {
            this.Rect = rect;
            this.SymbolId = symbolId;
        }
    }
}
