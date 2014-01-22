using ObserversSubjectEvent;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestObserversSubjects
{
    
    
    /// <summary>
    ///Classe de test pour ObserverTest, destinée à contenir tous
    ///les tests unitaires ObserverTest
    ///</summary>
    [TestClass()]
    public class ObserverTest
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
        ///Test pour Constructeur Observer
        ///</summary>
        [TestMethod()]
        public void ObserverConstructorTest()
        {
            int id = 0; // TODO: initialisez à une valeur appropriée
            Observer target = new Observer(id);
            Assert.Inconclusive("TODO: implémentez le code pour vérifier la cible");
        }

        /// <summary>
        ///Test pour Notify
        ///</summary>
        [TestMethod()]
        public void NotifyTest()
        {
            int id = 0; // TODO: initialisez à une valeur appropriée
            Observer target = new Observer(id); // TODO: initialisez à une valeur appropriée
            object sender = null; // TODO: initialisez à une valeur appropriée
            EventArgs e = null; // TODO: initialisez à une valeur appropriée
            target.Notify(sender, e);
            Assert.Inconclusive("Une méthode qui ne retourne pas une valeur ne peut pas être vérifiée...");
        }

        /// <summary>
        ///Test pour Id
        ///</summary>
        [TestMethod()]
        public void IdTest()
        {
            int id = 0; // TODO: initialisez à une valeur appropriée
            Observer target = new Observer(id); // TODO: initialisez à une valeur appropriée
            int expected = 0; // TODO: initialisez à une valeur appropriée
            int actual;
            target.Id = expected;
            actual = target.Id;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Vérifiez l\'exactitude de cette méthode de test.");
        }
    }
}
