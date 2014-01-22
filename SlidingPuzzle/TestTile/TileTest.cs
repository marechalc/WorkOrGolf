using SlidingPuzzle;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestTile
{
    
    
    /// <summary>
    ///Classe de test pour TileTest, destinée à contenir tous
    ///les tests unitaires TileTest
    ///</summary>
    [TestClass()]
    public class TileTest
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
        ///Test pour Constructeur Tile
        ///</summary>
        [TestMethod()]
        public void TileConstructorTest()
        {
            bool isAllowed = false;
            int symbolId = 0;
            Tile target = new Tile(isAllowed, symbolId);
            Assert.IsNotNull(target);
            Assert.AreEqual(isAllowed, target.IsAllowed);
            Assert.AreEqual(symbolId, target.SymbolId);
        }

        /// <summary>
        ///Test pour Constructeur Tile
        ///</summary>
        [TestMethod()]
        public void TileConstructorTest1()
        {
            Tile target = new Tile();
            Assert.IsNotNull(target);
            Assert.AreEqual(true, target.IsAllowed);
            Assert.AreEqual(0, target.SymbolId);
        }
    }
}
