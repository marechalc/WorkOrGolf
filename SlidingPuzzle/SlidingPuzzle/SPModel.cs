using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlidingPuzzle;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SlidingPuzzle
{
    [Serializable]
    class SPModel
    {
        const string DEFAULT_SAVE_FILENAME = "MyGame";

        #region fields & get/set
        private Game _game;

        internal Game Game
        {
            get
            {
                if (_game == null)
                    _game = new Game(); // lazy initialization
                return _game;
                // return (_game == null) ? new Game() : _game;
            }
            set { _game = value; }
        }
        #endregion

        /// <summary>
        /// Constructor of the model
        /// </summary>
        public SPModel()
        {
            // throw new NotImplementedException(); // The devil is hiding in the details.
        }

        public void Serialize(string filename)
        {
            // Reference : http://msdn.microsoft.com/.../lib.../4abbf6k0(v=vs.110).aspx
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this.Game);
            stream.Close();
        }

        public void Unserialize(string filename)
        {
            // Reference : http://msdn.microsoft.com/.../lib.../4abbf6k0(v=vs.110).aspx
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            this.Game = (Game)formatter.Deserialize(stream);
            stream.Close();
        }
    }
}
