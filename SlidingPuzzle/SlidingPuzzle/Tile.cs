/*
 * File    : Tile.cs
 * Project : Sliding Puzzle - Work Or Golf
 * Authors : Damien L, Zanos A.
 * Date    : 2014-01-22
 * 
 * Vers.   : 1.0, 2014-01-22, CFPTI Technicien ES by : Damien L, Zanos A.
 */

using System;
namespace SlidingPuzzle
{
    [Serializable]
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
