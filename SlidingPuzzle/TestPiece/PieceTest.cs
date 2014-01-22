using SlidingPuzzle;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace TestPiece
{
    
    
    /// <summary>
    ///Classe de test pour PieceTest, destinée à contenir tous
    ///les tests unitaires PieceTest
    ///</summary>
  [TestClass()]
  public class PieceTest
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
    ///Test pour Constructeur Piece
    ///</summary>
    [TestMethod()]
    public void PieceConstructorTest()
    {
      Rectangle rect = new Rectangle(); // TODO: initialisez à une valeur appropriée
      int symbolId = 0; // TODO: initialisez à une valeur appropriée
      Piece target = new Piece(rect, symbolId);
      Assert.Inconclusive("TODO: implémentez le code pour vérifier la cible");
    }

    /// <summary>
    ///Test pour Constructeur Piece
    ///</summary>
    [TestMethod()]
    public void PieceConstructorTest1()
    {
      Piece target = new Piece();
      Assert.Inconclusive("TODO: implémentez le code pour vérifier la cible");
    }
  }
}
