/*
 * Title : Piece Class
 * Version :
 * 1.0 : Creation - BAJRAMI & TUX
 */
using System.Drawing;

namespace SlidingPuzzle
{
  public class Piece
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
    ///  Initializes a new instance of the <see cref="SlidingPuzzle"/> class.
    /// </summary>
    public Piece()
      : this(new Rectangle(new Point(0,0), new Size(1,1)), 0)
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
