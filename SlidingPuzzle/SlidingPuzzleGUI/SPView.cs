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
        private Graphics gra;

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
            gra = panGame.CreateGraphics();
        }
        #endregion

        #region Methods
        public void UpdateView()
        {
            panGame.Invalidate();
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
        }

        private void panGame_Paint(object sender, PaintEventArgs e)
        {
            int[,] ids = Controller.GetIds();
            for (int x = 0; x < MAP_WIDTH; x++)
                for (int y = 0; y < MAP_HEIGHT; y++)
			    {
                    Image bmp = Controller.GetImg(ids[x,y]);
                    gra.DrawImage(bmp, x * TILE_SIZE, y * TILE_SIZE, TILE_SIZE, TILE_SIZE);
                }
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
            else if (angle > Math.PI / 4 && angle < 3*Math.PI / 4)
                direction = Direction.Up;
            else if (angle < -Math.PI / 4 && angle > - 3 * Math.PI / 4)
                direction = Direction.Down;
            else
                direction = Direction.Left;
            return direction;    
        }

        private void panGame_MouseClick(object sender, MouseEventArgs e)
        {
            int pieceX = (int)(e.X / TILE_SIZE);
            int pieceY = (int)(e.Y / TILE_SIZE);

            int pieceCenterPixelX = pieceX * TILE_SIZE + TILE_SIZE/2;
            int pieceCenterPixelY = pieceY * TILE_SIZE + TILE_SIZE / 2;

            double angle = Math.Atan2(pieceCenterPixelY - e.Y, e.X - pieceCenterPixelX);
            Controller.Move(new Point(pieceX, pieceY), AngleToDirection(angle));
        }
    }
}
