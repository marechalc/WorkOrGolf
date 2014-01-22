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
        [TestMethod()]
        public void MapConstructorTest()
        {
            Tile[,] tiles = null;
            Map target = new Map(tiles);
            Assert.AreNotEqual(null, target.Tiles);
        }

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
            Map target = new Map();
            bool actual;
            for (int i = -5; i < 5; i++)
                for (int j = -5; j < 5; j++)
                {
                    Rectangle rect = new Rectangle(i, j, 1, 1);
                    actual = target.IsAllowed(rect);
                    if ((rect.X <= target.Tiles.GetLength(0) && rect.X >= 0) && (rect.Y <= target.Tiles.GetLength(1) && rect.Y >= 0))
                        Assert.AreEqual(true, actual);
                    else
                        Assert.AreNotEqual(true, actual);
                }
            // ADD TEST DEBORDEMENT
        }

        /// <summary>
        ///Test pour Tiles
        ///</summary>
        [TestMethod()]
        public void TilesTest()
        {
            Map target = new Map(); // TODO: initialisez à une valeur appropriée
            Tile[,] expected = null; // TODO: initialisez à une valeur appropriée
            Tile[,] actual;
            target.Tiles = expected;
            actual = target.Tiles;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Vérifiez l\'exactitude de cette méthode de test.");
        }
    }
}
