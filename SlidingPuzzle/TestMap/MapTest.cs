using SlidingPuzzle;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace TestMap
{


    /// <summary>
    ///Classe de test pour MapTest, destinée à contenir tous
    ///les tests unitaires MapTest
    ///</summary>
    [TestClass()]
    public class MapTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Attributs de tests supplémentaires
        // 
        //Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        //Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test dans la classe
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Utilisez ClassCleanup pour exécuter du code après que tous les tests ont été exécutés dans une classe
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Test pour Constructeur Map
        ///</summary>
        /*[TestMethod()]
        public void MapConstructorTest()
        {
            Tile[,] tiles = null;
            Map target = new Map(tiles);
            Assert.AreNotEqual(null, target.Tiles);
        }*/
        //this test isn't usefull

        /// <summary>
        ///Test pour Constructeur Map
        ///</summary>
        [TestMethod()]
        public void MapConstructorTest1()
        {
            Map target = new Map();
            Assert.AreEqual(Map.DEFAULT_TILES_X, target.Tiles.GetLength(0));
            Assert.AreEqual(Map.DEFAULT_TILES_Y, target.Tiles.GetLength(1));
        }

        /// <summary>
        ///Test pour IsAllowed
        ///</summary>
        [TestMethod()]
        public void IsAllowedTest()
        {
            Tile[,] tiles = new Tile[10, 10];
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    tiles[i, j] = new Tile();


            Map target = new Map(tiles);
            bool actual;
            for (int i = -5; i < 15; i++)
            {
                for (int j = -5; j < 15; j++)
                {
                    for (int k = -5; k < 15; k++)
                    {
                        Rectangle rect = new Rectangle(i, j, k, k);
                        actual = target.IsAllowed(rect);
                        if (rect.X < target.Tiles.GetLength(0) &&
                            rect.X >= 0 &&
                            rect.Y < target.Tiles.GetLength(1) &&
                            rect.Y >= 0 &&
                            rect.X + rect.Width <= target.Tiles.GetLength(0) &&
                            rect.Y + rect.Height <= target.Tiles.GetLength(1))
                            Assert.AreEqual(true, actual);
                        else
                            Assert.AreNotEqual(true, actual);
                    }
                }
            }
        }

        /// <summary>
        ///Test pour Tiles
        ///</summary>
        [TestMethod()]
        public void TilesTest()
        {
            Map target = new Map();
            Assert.IsNotNull(target);

            Tile[,] tiles = new Tile[10, 20];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    tiles[i, j] = new Tile();
                }
            }

            target = new Map(tiles);
            Assert.AreEqual(10, target.Tiles.GetLength(0));
            Assert.AreEqual(20, target.Tiles.GetLength(1));
        }
    }
}
