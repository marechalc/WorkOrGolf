using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlidingPuzzle
{
    public class Tile
    {
        #region fields
        bool _isAllowed;
        int _symbolId;
        #endregion

        #region properties
        public int SymbolId
        {
            get { return _symbolId; }
            set { _symbolId = value; }
        }

        public bool IsAllowed
        {
            get { return _isAllowed; }
            set { _isAllowed = value; }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Tile"/> class.
        /// </summary>
        public Tile():this(true,0)
        { 
            //NO CODE
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tile"/> class.
        /// </summary>
        public Tile(bool isAllowed, int symbolId)
        {
            IsAllowed = isAllowed;
            SymbolId = symbolId;
        }
    }
}
