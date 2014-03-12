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
        private Image[] _images;

        public Image[] Images
        {
            get { return _images; }
            set { _images = value; }
        }

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
            this.Images = new Image[10];
        }
        #endregion

        #region Methods
        public void UpdateView()
        {
            this.gra.Clear(Color.White);
            for (int x = 0; x < this.Controller.Model.Game.Map.Tiles.GetLength(0); x++)
            {
                for (int y = 0; y < this.Controller.Model.Game.Map.Tiles.GetLength(1); y++)
                {
                    this.gra.DrawImage(this.Images[this.Controller.Model.Game.Map.Tiles[x, y].SymbolId], new Point(x * TILE_SIZE, y * TILE_SIZE));
                }
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

            Rectangle[] rects = new Rectangle[10];
            rects[2] = new Rectangle(0, 0, 1, 1);
            rects[3] = new Rectangle(1, 0, 1, 1);
            rects[4] = new Rectangle(2, 0, 1, 1);
            rects[5] = new Rectangle(3, 0, 1, 1);

            rects[6] = new Rectangle(0, 4, 1, 1);
            rects[7] = new Rectangle(1, 4, 1, 1);
            rects[8] = new Rectangle(2, 4, 1, 1);
            rects[9] = new Rectangle(3, 4, 1, 1);
            Controller.NewPieces(rects);

            this.Images[0] = SlidingPuzzleGUI.Properties.Resources.map1;
            this.Images[1] = SlidingPuzzleGUI.Properties.Resources.map2;
            this.Images[2] = SlidingPuzzleGUI.Properties.Resources.golf1;
            this.Images[3] = SlidingPuzzleGUI.Properties.Resources.golf2;
            this.Images[4] = SlidingPuzzleGUI.Properties.Resources.golf3;
            this.Images[5] = SlidingPuzzleGUI.Properties.Resources.golf4;
            this.Images[6] = SlidingPuzzleGUI.Properties.Resources.work1;
            this.Images[7] = SlidingPuzzleGUI.Properties.Resources.work2;
            this.Images[8] = SlidingPuzzleGUI.Properties.Resources.work3;
            this.Images[9] = SlidingPuzzleGUI.Properties.Resources.work4;

            this.UpdateView();
        }

        private void panGame_Paint(object sender, PaintEventArgs e)
        {
            //this.UpdateView();
            /*for (int i = 0; i < MAP_WIDTH; i++)
                for (int j = 0; j < MAP_HEIGHT; j++)
			    {
                    Bitmap bmp = (Bitmap)Controller.GetImg(Controller.GetId(new Point(i,j)));
                    gra.DrawImage(bmp, i * bmp.Width, j * bmp.Width);
                }*/
        }

        private void panGame_MouseClick(object sender, MouseEventArgs e)
        {
            int x = (int)(e.X / TILE_SIZE);
            int y = (int)(e.Y / TILE_SIZE);
            Controller.Move(new Point(x, y));
        }
    }
}
