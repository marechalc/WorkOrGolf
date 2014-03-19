using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SlidingPuzzle;

namespace SlidingPuzzleGUI
{
    public partial class SPView : Form
    {
        #region Constants
        const string DEFAULT_FILENAME = "MyGame";
        const int MAP_WIDTH = 4;
        const int MAP_HEIGHT = 5;
        const int TILE_SIZE = 128;
        const string DEFAULT_FILES_FILTER = "bin files (*.bin)|*.bin";
        #endregion

        #region Fields & Properties
        private SPController _controller;
        private int _tileSize;
        private Point _mapCenter;

        internal SPController Controller
        {
            get { return _controller; }
            set { _controller = value; }
        }
        #endregion

        #region Constructor
        public SPView(string puzzleFileName = null)
        {
            InitializeComponent();
            this.Controller = new SPController(this);
            NewGame();
            if (puzzleFileName != null)
            {
                Controller.LoadGame(puzzleFileName);
                UpdateView();
            }
        }
        #endregion

        #region Methods
        public void UpdateView()
        {
            this.lblStatusStrip_Count.Text = "Number of step(s): " + this.Controller.GetScore().ToString();
            panGame.Invalidate();
            if (this.Controller.IsCompleted())
            {
                if (MessageBox.Show(string.Format("You win with {0} steps ! Do you want to restart ?", this.Controller.GetScore()), "You win", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    NewGame();
                else
                    ExitGame();

            }
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

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You are about to start a new game, you will lose your current progression. Proceed ?", "New game", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                NewGame();
        }

        private void panGame_Paint(object sender, PaintEventArgs e)
        {
            Graphics gra = e.Graphics;
            gra.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int[,] ids = Controller.GetIds();

            _tileSize = (this.panGame.ClientSize.Width / MAP_WIDTH < this.panGame.ClientSize.Height / MAP_HEIGHT) ? this.panGame.ClientSize.Width / MAP_WIDTH : this.panGame.ClientSize.Height / MAP_HEIGHT;
            _mapCenter.X = (this.panGame.ClientSize.Width - _tileSize * MAP_WIDTH) / 2;
            _mapCenter.Y = (this.panGame.ClientSize.Height - _tileSize * MAP_HEIGHT) / 2;

            for (int x = 0; x < MAP_WIDTH; x++)
                for (int y = 0; y < MAP_HEIGHT; y++)
                {
                    Image bmp = Controller.GetImg(ids[x, y]);
                    gra.DrawImage(bmp, _mapCenter.X + x * _tileSize, _mapCenter.Y + y * _tileSize, _tileSize, _tileSize);
                }
        }

        public void NewGame()
        {
            int[,] myMap = new int[MAP_WIDTH, MAP_HEIGHT];
            int[,] myPieces = new int[MAP_WIDTH, MAP_HEIGHT];

            myMap[0, 0] = 0;
            myMap[1, 0] = 0;
            myMap[2, 0] = 0;
            myMap[3, 0] = 0;

            myMap[0, 1] = 1;
            myMap[1, 1] = 0;
            myMap[2, 1] = 1;
            myMap[3, 1] = 1;

            myMap[0, 2] = 1;
            myMap[1, 2] = 0;
            myMap[2, 2] = 0;
            myMap[3, 2] = 1;

            myMap[0, 3] = 1;
            myMap[1, 3] = 0;
            myMap[2, 3] = 1;
            myMap[3, 3] = 1;

            myMap[0, 4] = 0;
            myMap[1, 4] = 0;
            myMap[2, 4] = 0;
            myMap[3, 4] = 0;

            Controller.NewMap(myMap);

            myPieces[0, 0] = 2;
            myPieces[1, 0] = 3;
            myPieces[2, 0] = 4;
            myPieces[3, 0] = 5;

            myPieces[0, 4] = 6;
            myPieces[1, 4] = 7;
            myPieces[2, 4] = 8;
            myPieces[3, 4] = 9;

            Controller.NewPieces(myPieces);


            Controller.AddImage(0, SlidingPuzzleGUI.Properties.Resources.map1);
            Controller.AddImage(1, SlidingPuzzleGUI.Properties.Resources.map2);
            Controller.AddImage(2, SlidingPuzzleGUI.Properties.Resources.golf1);
            Controller.AddImage(3, SlidingPuzzleGUI.Properties.Resources.golf2);
            Controller.AddImage(4, SlidingPuzzleGUI.Properties.Resources.golf3);
            Controller.AddImage(5, SlidingPuzzleGUI.Properties.Resources.golf4);
            Controller.AddImage(6, SlidingPuzzleGUI.Properties.Resources.work1);
            Controller.AddImage(7, SlidingPuzzleGUI.Properties.Resources.work2);
            Controller.AddImage(8, SlidingPuzzleGUI.Properties.Resources.work3);
            Controller.AddImage(9, SlidingPuzzleGUI.Properties.Resources.work4);

            Controller.NewGame();
        }

        /// <summary>
        /// Return the direction corresponding to the angle
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        private Direction AngleToDirection(double angle)
        {
            Direction direction;
            if (angle < Math.PI / 4 && angle > -Math.PI / 4)
                direction = Direction.Right;
            else if (angle > Math.PI / 4 && angle < 3 * Math.PI / 4)
                direction = Direction.Up;
            else if (angle < -Math.PI / 4 && angle > -3 * Math.PI / 4)
                direction = Direction.Down;
            else
                direction = Direction.Left;
            return direction;
        }

        private void panGame_MouseClick(object sender, MouseEventArgs e)
        {
            int pieceX = (int)((e.X - _mapCenter.X) / _tileSize);
            int pieceY = (int)((e.Y - _mapCenter.Y) / _tileSize);

            int pieceCenterPixelX = _mapCenter.X + pieceX * _tileSize + _tileSize / 2;
            int pieceCenterPixelY = _mapCenter.Y + pieceY * _tileSize + _tileSize / 2;

            double angle = Math.Atan2(pieceCenterPixelY - e.Y, e.X - pieceCenterPixelX);
            Controller.Move(new Point(pieceX, pieceY), AngleToDirection(angle));
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("WorkOrGolf\n\nTechniciens ES deuxième année A.K.A. Techniporcs\n2013/2014 - CFPT-Informatique - Genève");
        }

        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Controller.SaveGame(sfd.FileName);
            }
        }

        private void loadGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Controller.LoadGame(ofd.FileName);
                UpdateView();
            }
        }

        private void SPView_Resize(object sender, EventArgs e)
        {
            panGame.Invalidate();
        }

        private void ExitGame()
        {
            if (MessageBox.Show("Do you really want to leave the game ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitGame();
        }
    }
}
