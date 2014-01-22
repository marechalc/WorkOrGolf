using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlidingPuzzle
{
    public class Tile
    {
        #region consts
        const bool DEFAULT_ISALLOWED = true;
        const int DEFAULT_SYMBOLID = 0;
        #endregion

        #region fields
        bool _isAllowed;
        int _symbolId;
        #endregion

        #region properties
        public int SymbolId
        {
            get { return _symbolId; }
            private set { _symbolId = value; }
        }

        public bool IsAllowed
        {
            get { return _isAllowed; }
            private set { _isAllowed = value; }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Tile"/> class.
        /// </summary>
        public Tile()
            : this(DEFAULT_ISALLOWED, DEFAULT_SYMBOLID)
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
