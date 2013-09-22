using System.Collections.Generic;
using LightManWP.Model;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace LightManWPTests.Models
{
    [TestClass]
    public class RoundTest
    {
        private readonly Tile _tile00 = new Tile(0, 0);
        private readonly Tile _tile10 = new Tile(2, 0);
        private readonly Tile _tile20 = new Tile(2, 0);
        private readonly Tile _tile01 = new Tile(0, 1);
        private readonly Tile _tile11 = new Tile(1, 1);
        private readonly Tile _tile21 = new Tile(2, 1);
        private readonly Tile _tile02 = new Tile(0, 2);
        private readonly Tile _tile12 = new Tile(1, 2);
        private readonly Tile _tile22 = new Tile(2, 2);

        [TestMethod]
        public void WhenTwoPlayersCrossThenRoundIsDraw()
        {
            var run1 = new Run(new List<Tile> { _tile00, _tile01, _tile02 });
            var run2 = new Run(new List<Tile> { _tile22, _tile21, _tile20 });

            var round = new Round(run1, run2);
            var result = round.Resolve();

            Assert.AreEqual(RunResult.Draw, result);
        }

        [TestMethod]
        public void WhenTwoDoNotInterceptAndRun1ShorterThenRun1Win()
        {
            var run1 = new Run(new List<Tile> { _tile00, _tile01, _tile02 });
            var run2 = new Run(new List<Tile> { _tile22, _tile21, _tile11, _tile10 });

            var round = new Round(run1, run2);
            var result = round.Resolve();

            Assert.AreEqual(RunResult.Run1Win, result);
        }

        [TestMethod]
        public void WhenTwoDoNotInterceptAndRun2ShorterThenRun2Win()
        {
            var run1 = new Run(new List<Tile> { _tile22, _tile21, _tile11, _tile10 });
            var run2 = new Run(new List<Tile> { _tile00, _tile01, _tile02 });

            var round = new Round(run1, run2);
            var result = round.Resolve();

            Assert.AreEqual(RunResult.Run2Win, result);
        }

        [TestMethod]
        public void WhenSecondInterceptFirstThenSecondIsWinner()
        {
            var run1 = new Run(new List<Tile> { _tile00, _tile01, _tile02 });
            var run2 = new Run(new List<Tile> { _tile12, _tile11, _tile01, _tile00 });

            var round = new Round(run1, run2);
            var result = round.Resolve();

            Assert.AreEqual(RunResult.Run2Win, result);
        }

        [TestMethod]
        public void WhenFirstInterceptSecondThenFirstIsWinner()
        {
            var run1 = new Run(new List<Tile> { _tile12, _tile11, _tile01, _tile00 });
            var run2 = new Run(new List<Tile> { _tile00, _tile01, _tile02 });

            var round = new Round(run1, run2);
            var result = round.Resolve();

            Assert.AreEqual(RunResult.Run1Win, result);
        }

        [TestMethod]
        public void WhenFirstInterceptSecondOnSameTileThenIsDraw()
        {
            var run1 = new Run(new List<Tile> { _tile12, _tile11, _tile21, _tile20 });
            var run2 = new Run(new List<Tile> { _tile10, _tile11, _tile12 });

            var round = new Round(run1, run2);
            var result = round.Resolve();

            Assert.AreEqual(RunResult.Draw, result);
        }
     }
}
