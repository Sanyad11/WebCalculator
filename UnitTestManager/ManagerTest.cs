using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebCalculator.Manager;

namespace UnitTestManager
{
    [TestClass]
    public class ManagerTest
    {
        [TestMethod]
        public void AddTest()
        {
            //arrange
            var manager = new Manager();

            //act
            var result = manager.Add(4, 7);

            //accert
            Assert.AreEqual(11, result);
        }

        [TestMethod]
        public void SubTest()
        {
            //arrange
            var manager = new Manager();

            //act
            var result = manager.Sub(7, 4);

            //accert
            Assert.AreEqual(3, result);
        }
    }
}
