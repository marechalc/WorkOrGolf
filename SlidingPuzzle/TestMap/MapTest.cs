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
            Tile[,] tiles = null; // TODO: initialisez à une valeur appropriée
            Map target = new Map(tiles);
            Assert.Inconclusive("TODO: implémentez le code pour vérifier la cible");
        }

        /// <summary>
        ///Test pour Constructeur Map
        ///</summary>
        [TestMethod()]
        public void MapConstructorTest1()
        {
            Map target = new Map();
            Assert.Inconclusive("TODO: implémentez le code pour vérifier la cible");
        }

        /// <summary>
        ///Test pour IsAllowed
        ///</summary>
        [TestMethod()]
        public void IsAllowedTest()
        {
            Map target = new Map(); // TODO: initialisez à une valeur appropriée
            Rectangle rect = new Rectangle(); // TODO: initialisez à une valeur appropriée
            bool expected = false; // TODO: initialisez à une valeur appropriée
            bool actual;
            actual = target.IsAllowed(rect);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Vérifiez l\'exactitude de cette méthode de test.");
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
