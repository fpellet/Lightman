using System.Collections.Generic;

using LightManWP.Model;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace LightManWPTests.Models
{
    [TestClass]
    public class LightManTest
    {
        private const string ExpectedName = "Toto";

        [TestMethod]
        public void WhenLightManIsCreatedWithNameThenNameIsStored()
        {
            var lightMan = new LightMan(ExpectedName);

            Assert.AreEqual(ExpectedName, lightMan.Name);
        }
        
        [TestMethod]
        public void WhenLightManRecordRunThenRunIsRecorded()
        {
            var run = new Run(new List<Tile> { new Tile(0, 0), new Tile(0, 1), new Tile(0, 2) });

            var lightMan = new LightMan(ExpectedName);

            lightMan.RecordRun(run);

            Assert.AreEqual(run, lightMan.Run);
        }
    }
}
