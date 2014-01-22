/*
 * Title : Piece Class
 * Version :
 * 1.0 : Creation - BAJRAMI & TUX
 */
using System.Drawing;

namespace SlidingPuzzle
{
  class Piece
  {
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
    /// Constructor
    /// </summary>
    public Piece()
      : this(new Rectangle(), 0)
    {
      // No code
    }

    /// <summary>
    /// Designated constructor
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
