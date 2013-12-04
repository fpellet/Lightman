using System.Linq;
using LightManWP.Model;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace LightManWPTests.Models
{
    [TestClass]
    public class RunTest
    {
        [TestMethod]
        public void WhenAddTileThenTileIsRecorded()
        {
            var expectedTile = new Tile(1, 1);

            var run = new Run();
            run.AddTile(expectedTile);
        
            Assert.AreEqual(expectedTile, run.Tiles.First());
        }
    }
}
