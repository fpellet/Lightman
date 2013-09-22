using LightManWP.Model;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace LightManWPTests.Models
{
    [TestClass]
    public class GridGameTest
    {
        [TestMethod]
        public void WhenGridIsCreatedThenIsNotNull()
        {
            var grid = new GridGame(5, 5);

            Assert.IsNotNull(grid);
        }
    }
}
