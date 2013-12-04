using System.Collections.Generic;
using LightManWP.Model;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace LightManWPTests.Models
{
    [TestClass]
    public class ArenaTest
    {
        private const string Player1Name = "1";
        private const string Player2Name = "2";

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
        public void WhenArenaIsCreatedAndLihtman1And2CanRecordFirstRoundWithDrawThenResultNameIsNull()
        {
            var run1 = new Run(new List<Tile> { _tile00, _tile01, _tile02 });
            var run2 = new Run(new List<Tile> { _tile22, _tile21, _tile20 });

            var lightMan1 = new LightMan(Player1Name);
            var lightMan2 = new LightMan(Player2Name);

            var arena = new Arena(lightMan1, lightMan2);
            arena.StartNewRound();

            arena.RecordCurrentRun(run1);
            arena.RecordCurrentRun(run2);

            var winnerRound = arena.ResolveRound();

            Assert.IsNull(winnerRound);
        }

        [TestMethod]
        public void WhenLightman1WinARoundInArenaThenResolveRoundRetuRnLightman1()
        {
            var run1 = new Run(new List<Tile> { _tile00, _tile01, _tile02 });
            var run2 = new Run(new List<Tile> { _tile22, _tile21, _tile11, _tile10 });

            var lightMan1 = new LightMan(Player1Name);
            var lightMan2 = new LightMan(Player2Name);

            var arena = new Arena(lightMan1, lightMan2);
            arena.StartNewRound();

            arena.RecordCurrentRun(run1);
            arena.RecordCurrentRun(run2);

            var winnerRound = arena.ResolveRound();

            Assert.AreEqual(lightMan1, winnerRound);
        }

        [TestMethod]
        public void WhenLightman2WinARoundInArenaThenResolveRoundReturnLightman2()
        {
            var run1 = new Run(new List<Tile> { _tile22, _tile21, _tile11, _tile10 });
            var run2 = new Run(new List<Tile> { _tile00, _tile01, _tile02 });

            var lightMan1 = new LightMan(Player1Name);
            var lightMan2 = new LightMan(Player2Name);

            var arena = new Arena(lightMan1, lightMan2);
            arena.StartNewRound();

            arena.RecordCurrentRun(run1);
            arena.RecordCurrentRun(run2);

            var winnerRound = arena.ResolveRound();

            Assert.AreEqual(lightMan2, winnerRound);
        }
    }
}
