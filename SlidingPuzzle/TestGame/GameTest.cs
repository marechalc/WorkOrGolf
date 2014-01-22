/*
 * File    : GameTest.cs
 * Project : Sliding Puzzle - Work Or Golf (Unit tests)
 * Authors : rejas c, menetrey s.
 * Date    : 2014-01-22
 * 
 * Vers.   : 1.0, 2014-01-22, CFPTI Technicien ES by : rejas c, menetrey s.
 */

using SlidingPuzzle;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace TestGame
{
    /// <summary>
    ///Classe de test pour GameTest, destinée à contenir tous
    ///les tests unitaires GameTest
    ///</summary>
    [TestClass()]
    public class GameTest
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
        ///Test pour Constructeur Game
        ///</summary>
        [TestMethod()]
        public void GameConstructorTest()
        {
            Game target = new Game();
            Assert.AreNotEqual(target.Map, null);
            Assert.AreNotEqual(target.Pieces, null);

            //Est-ce que les pièces sont instanciées dans Game ou au dessus ? Théoriquement = au dessus

            //foreach (Piece p in target.Pieces)
            //{
            //    Assert.AreNotEqual(p, null);
            //}

        }

        /// <summary>
        ///Test pour Constructeur Game
        ///</summary>
        [TestMethod()]
        public void GameConstructorTest1()
        {
            Map map = new Map(new Tile[10,10]);
            Piece[] pieces = new Piece[1];
            Game target = new Game(map, pieces);

            Assert.AreNotEqual(target.Map, null);
            Assert.AreNotEqual(target.Pieces, null);

            //foreach (Piece p in target.Pieces)
            //{
            //    Assert.AreNotEqual(p, null);
            //}
        }

        /// <summary>
        ///Test pour IsCompleted
        ///</summary>
        [TestMethod()]
        public void IsCompletedTest()
        {
            Map map = new Map();

            // Define actuals position of 3 pieces
            Piece[] piecesActualPositions = new Piece[3];
            piecesActualPositions[0] = new Piece(new Rectangle(0, 0, 1, 1), 0);
            piecesActualPositions[1] = new Piece(new Rectangle(1, 1, 1, 1), 1);
            piecesActualPositions[2] = new Piece(new Rectangle(2, 2, 1, 1), 2);

            // Define final position of 3 pieces
            Piece[] piecesFinalPositions = new Piece[3];
            piecesFinalPositions[0] = new Piece(new Rectangle(0, 0, 1, 1), 0);
            piecesFinalPositions[1] = new Piece(new Rectangle(1, 1, 1, 1), 1);
            piecesFinalPositions[2] = new Piece(new Rectangle(2, 2, 1, 1), 2);

            Game game = new Game(map, piecesActualPositions);

            // TODO : care of the symbol id
            Assert.AreEqual(piecesFinalPositions[0].Rect, piecesActualPositions[0].Rect);
            Assert.AreEqual(piecesFinalPositions[1].Rect, piecesActualPositions[1].Rect);
            Assert.AreEqual(piecesFinalPositions[2].Rect, piecesActualPositions[2].Rect);
        }

        /// <summary>
        ///Test pour Move
        ///</summary>
        [TestMethod()]
        public void MoveTest()
        {
            Game target = new Game(); // TODO: initialisez à une valeur appropriée
            Point point = new Point(); // TODO: initialisez à une valeur appropriée
            Direction[] expected = null; // TODO: initialisez à une valeur appropriée
            Direction[] actual;
            actual = target.Move(point);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Vérifiez l\'exactitude de cette méthode de test.");
        }

        /// <summary>
        ///Test pour Move
        ///</summary>
        [TestMethod()]
        public void MoveTest1()
        {
            Game target = new Game(); // TODO: initialisez à une valeur appropriée
            Point point = new Point(); // TODO: initialisez à une valeur appropriée
            Direction direction = new Direction(); // TODO: initialisez à une valeur appropriée
            bool expected = false; // TODO: initialisez à une valeur appropriée
            bool actual;
            actual = target.Move(point, direction);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Vérifiez l\'exactitude de cette méthode de test.");
        }

        /// <summary>
        ///Test pour Map
        ///</summary>
        [TestMethod()]
        public void MapTest()
        {
            Game target = new Game(); // TODO: initialisez à une valeur appropriée
            Map expected = null; // TODO: initialisez à une valeur appropriée
            Map actual;
            target.Map = expected;
            actual = target.Map;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Vérifiez l\'exactitude de cette méthode de test.");
        }

        /// <summary>
        ///Test pour Pieces
        ///</summary>
        [TestMethod()]
        public void PiecesTest()
        {
            Game target = new Game(); // TODO: initialisez à une valeur appropriée
            Piece[] expected = null; // TODO: initialisez à une valeur appropriée
            Piece[] actual;
            target.Pieces = expected;
            actual = target.Pieces;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Vérifiez l\'exactitude de cette méthode de test.");
        }
    }
}
