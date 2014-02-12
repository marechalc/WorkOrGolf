using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SlidingPuzzleGUI
{
    public partial class SPView : Form
    {
        const string DEFAULT_FILENAME = "MyGame";
        const string DEFAULT_FILES_FILTER = "bin files (*.bin)|*.bin";

        #region Fields & Properties
        private SPController _controller;

        internal SPController Controller
        {
            get { return _controller; }
            set { _controller = value; }
        }
        #endregion

        #region Constructor
        public SPView()
        {
            InitializeComponent();
            this.Controller = new SPController(this);
        }
        #endregion

        #region Methods
        public void UpdateView()
        {

        }

        private void menuNewGame_Click(object sender, System.EventArgs e)
        {
            this.Controller.NewGame();
        }

        private void menuLoadGame_Click(object sender, System.EventArgs e)
        {
            this.ofd = new OpenFileDialog();
            this.ofd.Filter = DEFAULT_FILES_FILTER;
            this.ofd.FileName = DEFAULT_FILENAME;

            if (this.ofd.ShowDialog() == DialogResult.OK)
                this.Controller.LoadGame(this.ofd.FileName);
        }

        private void menuSaveGame_Click(object sender, System.EventArgs e)
        {
            this.sfd = new SaveFileDialog();
            this.sfd.Filter = DEFAULT_FILES_FILTER;
            this.sfd.FileName = DEFAULT_FILENAME;

            if (this.sfd.ShowDialog() == DialogResult.OK)
                this.Controller.SaveGame(this.sfd.FileName);
        }

        private void menuQuit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
