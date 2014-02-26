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
        const int MAP_WIDTH = 4;
        const int MAP_HEIGHT = 5;
        const int TILE_SIZE = 100;
        const string DEFAULT_FILES_FILTER = "bin files (*.bin)|*.bin";

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

            Controller.NewPieces(myPieces);

            Controller.AddImage(0, Image.FromFile("img/map1.jpg"));
            Controller.AddImage(1, Image.FromFile("img/map2.jpg"));
            Controller.AddImage(2, Image.FromFile("img/work1.jpg"));
            Controller.AddImage(3, Image.FromFile("img/work2.jpg"));
            Controller.AddImage(4, Image.FromFile("img/work3.jpg"));
            Controller.AddImage(5, Image.FromFile("img/work4.jpg"));
            Controller.AddImage(6, Image.FromFile("img/golf1.jpg"));
            Controller.AddImage(7, Image.FromFile("img/golf2.jpg"));
            Controller.AddImage(8, Image.FromFile("img/golf3.jpg"));
            Controller.AddImage(8, Image.FromFile("img/golf4.jpg"));
            //SlidingPuzzleGUI.Properties.Resources.map1;
        }

        private void panGame_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < MAP_WIDTH; i++)
                for (int j = 0; j < MAP_HEIGHT; j++)
			    {
                    Bitmap bmp = Controller.GetImg(Controller.GetId(new Point(i,j)));
                    gra.DrawImage(bmp, i * bmp.Width, j * bmp.Width);
                }
        }

        private void panGame_MouseClick(object sender, MouseEventArgs e)
        {
            int x = (int)(e.X / TILE_SIZE);
            int y = (int)(e.Y / TILE_SIZE);
            Controller.Move(new Point(x, y));
        }
    }
}
