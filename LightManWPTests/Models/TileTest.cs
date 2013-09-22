using LightManWP.Model;

using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace LightManWPTests.Models
{
    [TestClass]
    public class TileTest
    {
        [TestMethod]
        public void WhenTileIsCreatedThenPosXandYAreSetted()
        {
            var tile = new Tile(5, 5);

            Assert.AreEqual(5, tile.X);
            Assert.AreEqual(5, tile.Y);
        }

        [TestMethod]
        public void WhenTileIsUsedThenTileUsed()
        {
            var tile = new Tile(5, 5);

            tile.Used();

            Assert.IsTrue(tile.IsUsed);
        }

        [TestMethod]
        public void WhenTileAreSamePositionThenAreTheSame()
        {
            var tile = new Tile(5, 5);

            Assert.AreEqual(5, tile.X);
            Assert.AreEqual(5, tile.Y);
        }

    }
}
