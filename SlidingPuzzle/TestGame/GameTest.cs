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
using System.Text;

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

        #region Attributs de tests sUpplémentaires
        // 
        //Vous pouvez utiliser les attributs sUpplémentaires suivants lorsque vous écrivez vos tests :
        //
        //Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test dans la classe
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Utilisez ClassCleanUp pour exécuter du code après que tous les tests ont été exécutés dans une classe
        //[ClassCleanUp()]
        //public static void MyClassCleanUp()
        //{
        //}
        //
        //Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Utilisez TestCleanUp pour exécuter du code après que chaque test a été exécuté
        //[TestCleanUp()]
        //public void MyTestCleanUp()
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
        /// Check if two array contains the same elements
        /// </summary>
        /// <typeparam name="T">The type of the elements of the arrays</typeparam>
        /// <param name="expected">The expected array</param>
        /// <param name="actual">The actual array</param>
        public void ArraysAreEqual<T>(T[] expected, T[] actual)
        {
            Assert.AreEqual(expected.Length, actual.Length, "The length of the two array are not equal");
            Array.Sort(expected);
            Array.Sort(actual);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
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

        private int[,] GetSymbolsMap(Game g)
        {
            int Width = g.Map.Tiles.GetLength(0);
            int Height = g.Map.Tiles.GetLength(1);
            int[,] symbolsMap = new int[Width, Height];


            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    symbolsMap[x, y] = g.Map.Tiles[x, y].SymbolId;
                }
            }

            foreach (Piece piece in g.Pieces)
            {
                for (int x = piece.Rect.Left; x < piece.Rect.Right; x++)
                {
                    for (int y = piece.Rect.Top; y < piece.Rect.Bottom; y++)
                    {
                        symbolsMap[x, y] = piece.SymbolId;
                    }
                }

            }

            return symbolsMap;
        }

        private string GameToString(Game g)
        {   
            char[] symbolsChars = new char[] {' ', '#', '*' };
            int Width = g.Map.Tiles.GetLength(0);
            int Height = g.Map.Tiles.GetLength(1);
            int[,] symbolsMap = GetSymbolsMap(g);

            StringBuilder sb = new StringBuilder(Height * (Width + 1));

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    int symbolId = symbolsMap[x, y];
                    sb.Append(symbolsChars[Math.Min(symbolsChars.Length, symbolId)]);
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }

        /// <summary>
        ///Test pour Move
        ///</summary>
        [TestMethod()]
        public void MoveTest()
        {
            // 1D games, 1x1 pieces

            Game target = new Game(new Map(new Tile[3, 1] { { new Tile() }, { new Tile() }, { new Tile() } }), new Piece[] { new Piece(new Rectangle(0, 0, 1, 1), 2), new Piece(new Rectangle(1, 0, 1, 1), 2) });
            // This game is 3x1 map with every tiles allowed and two 1x1 pieces in the first two column

            Assert.AreEqual("** \n", GameToString(target));

            Point p = new Point(2, 0); // The empty 
            Direction[] expected = new Direction[0];
            Direction[] actual = target.Move(p);
            ArraysAreEqual(expected, actual);
      
            p = new Point(1, 0);
            expected = new Direction[1] { Direction.Right };
            actual = target.Move(p);
            ArraysAreEqual(expected, actual);
            Assert.AreEqual("* *\n", GameToString(target));

            p = new Point(1, 0);
            expected = new Direction[0];
            actual = target.Move(p);
            ArraysAreEqual(expected, actual);
            Assert.AreEqual("* *\n", GameToString(target));

            p = new Point(2, 0);
            expected = new Direction[1] { Direction.Left };
            actual = target.Move(p);
            ArraysAreEqual(expected, actual);
            Assert.AreEqual("** \n", GameToString(target));

            p = new Point(0, 0);
            expected = new Direction[1] { Direction.Right };
            actual = target.Move(p);
            ArraysAreEqual(expected, actual);
            Assert.AreEqual(" **\n", GameToString(target));

            p = new Point(0, 0);
            expected = new Direction[0];
            actual = target.Move(p);
            ArraysAreEqual(expected, actual);
            Assert.AreEqual(" **\n", GameToString(target));

            p = new Point(2, 0);
            expected = new Direction[1] { Direction.Left };
            actual = target.Move(p);
            ArraysAreEqual(expected, actual);
            Assert.AreEqual("** \n", GameToString(target));

            target = new Game(new Map(new Tile[1, 3] { { new Tile(), new Tile(), new Tile() } }), new Piece[] { new Piece(new Rectangle(0, 0, 1, 1), 2), new Piece(new Rectangle(0, 1, 1, 1), 2) });
            // This game is 1x3 map with every tiles allowed and two 1x1 pieces in the first two column

            Assert.AreEqual("*\n*\n \n", GameToString(target));

            p = new Point(0, 2);
            expected = new Direction[0];
            actual = target.Move(p);
            ArraysAreEqual(expected, actual);

            p = new Point(0, 1);
            expected = new Direction[1] { Direction.Down };
            actual = target.Move(p);
            ArraysAreEqual(expected, actual);
            Assert.AreEqual("*\n \n*\n", GameToString(target));

            p = new Point(0, 1);
            expected = new Direction[0];
            actual = target.Move(p);
            ArraysAreEqual(expected, actual);
            Assert.AreEqual("*\n \n*\n", GameToString(target));

            p = new Point(0, 2);
            expected = new Direction[1] { Direction.Up };
            actual = target.Move(p);
            ArraysAreEqual(expected, actual);
            Assert.AreEqual("*\n*\n \n", GameToString(target));

            p = new Point(0, 0);
            expected = new Direction[1] { Direction.Down };
            actual = target.Move(p);
            ArraysAreEqual(expected, actual);
            Assert.AreEqual(" \n*\n*\n", GameToString(target));

            p = new Point(0, 0);
            expected = new Direction[0];
            actual = target.Move(p);
            ArraysAreEqual(expected, actual);
            Assert.AreEqual(" \n*\n*\n", GameToString(target));

            p = new Point(0, 2);
            expected = new Direction[1] { Direction.Up };
            actual = target.Move(p);
            ArraysAreEqual(expected, actual);
            Assert.AreEqual("*\n*\n \n", GameToString(target));

            target = new Game(new Map(new Tile[4, 1] { { new Tile() }, { new Tile() }, { new Tile() }, { new Tile() } }), new Piece[] { new Piece(new Rectangle(0, 0, 1, 1), 2), new Piece(new Rectangle(1, 0, 1, 1), 2) });
            // This game is a 4x1 map with every tiles allowed and two 1x1 pieces in the first two column
            Assert.AreEqual("**  \n", GameToString(target));

            p = new Point(1, 0);
            expected = new Direction[1] { Direction.Right };
            actual = target.Move(p);
            ArraysAreEqual(expected, actual);
            Assert.AreEqual("* * \n", GameToString(target));

            p = new Point(1, 0);
            expected = new Direction[0];
            actual = target.Move(p);
            ArraysAreEqual(expected, actual);
            Assert.AreEqual("* * \n", GameToString(target));

            p = new Point(2, 0);
            expected = new Direction[2] { Direction.Left, Direction.Right };
            actual = target.Move(p);
            ArraysAreEqual(expected, actual);
            Assert.AreEqual("* * \n", GameToString(target));

            p = new Point(0, 0);
            expected = new Direction[1] { Direction.Right };
            actual = target.Move(p);
            ArraysAreEqual(expected, actual);
            Assert.AreEqual(" ** \n", GameToString(target));

            p = new Point(1, 0);
            expected = new Direction[2] { Direction.Left, Direction.Right };
            actual = target.Move(p);
            ArraysAreEqual(expected, actual);
            Assert.AreEqual(" ** \n", GameToString(target));

            p = new Point(2, 0);
            expected = new Direction[2] { Direction.Left, Direction.Right };
            actual = target.Move(p);
            ArraysAreEqual(expected, actual);
            Assert.AreEqual(" ** \n", GameToString(target));

            // todo: 1x4

            // With obstacle

            target = new Game(new Map(new Tile[5, 1] { { new Tile() }, { new Tile() }, { new Tile() }, { new Tile(false, 1) }, { new Tile() } }), new Piece[] { new Piece(new Rectangle(0, 0, 1, 1), 2), new Piece(new Rectangle(1, 0, 1, 1), 2) });
            Assert.AreEqual("** # \n", GameToString(target));

            p = new Point(1, 0);
            expected = new Direction[1] { Direction.Right };
            actual = target.Move(p);
            ArraysAreEqual(expected, actual);
            Assert.AreEqual("* *# \n", GameToString(target));

            p = new Point(2, 0);
            expected = new Direction[1] { Direction.Left };
            actual = target.Move(p);
            ArraysAreEqual(expected, actual);
            Assert.AreEqual("** # \n", GameToString(target));

            p = new Point(0, 0);
            expected = new Direction[1] { Direction.Right };
            actual = target.Move(p);
            ArraysAreEqual(expected, actual);
            Assert.AreEqual(" **# \n", GameToString(target));

            p = new Point(2, 0);
            expected = new Direction[1] { Direction.Left };
            actual = target.Move(p);
            ArraysAreEqual(expected, actual);
            Assert.AreEqual("** # \n", GameToString(target));


            // 2D games, 1x1 pieces

            target = new Game(new Map(new Tile[2, 2] { { new Tile(), new Tile() }, { new Tile(), new Tile() } }), new Piece[] { new Piece(new Rectangle(0, 0, 1, 1), 2), new Piece(new Rectangle(0, 1, 1, 1), 2) });
            // This game is 2x2 map with every tiles allowed and two 1x1 pieces in the first two column

            //2D games, pieces bigger than 1x1
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
    }
}
