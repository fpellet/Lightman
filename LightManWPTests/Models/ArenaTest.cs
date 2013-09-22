using System;
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
        public void WhenArenaIsCreatedAndLihtman1and2CanRecordFirstRoundWithDrawThenResultNameIsNull()
        {
            var grid = new GridGame(3, 3);

            var run1 = new List<Tile> { _tile00, _tile01, _tile02 };
            var run2 = new List<Tile> { _tile22, _tile21, _tile20 };

            var lightMan1 = new LightMan(Player1Name);
            var lightMan2 = new LightMan(Player2Name);

            var arena = new Arena(grid, lightMan1, lightMan2);
            arena.StartNewRound();

            arena.RecordCurrentRun(run1);
            arena.RecordCurrentRun(run2);

            var winnerRound = arena.ResolveRound();

            Assert.IsNull(winnerRound);
        }

        [TestMethod]
        public void WhenLightman1WinARoundInArenaThenResolveRoundRetuRnLightman1()
        {
        }

        [TestMethod]
        public void WhenLightman2WinARoundInArenaThenResolveRoundReturnLightman2()
        {
        }
    }



    public class Arena
    {
        private readonly GridGame _grid;
        private readonly LightMan _lightMan1;
        private readonly LightMan _lightMan2;
        private bool _player2Turn;

        public Arena(GridGame grid, LightMan lightMan1, LightMan lightMan2)
        {
            _grid = grid;
            _lightMan1 = lightMan1;
            _lightMan2 = lightMan2;
        }

        public void StartNewRound()
        {
            _player2Turn = false;
        }

        public void RecordCurrentRun(IList<Tile> currentRun)
        {
            if (_player2Turn)
            {
                _lightMan2.RecordRun(new Run(currentRun));
                _player2Turn = false;
            }
            else
            {
                _lightMan1.RecordRun(new Run(currentRun));
                _player2Turn = true;
            }
        }

        public LightMan ResolveRound()
        {
            var round = new Round(_lightMan1.Run, _lightMan2.Run);

            var resultRound = round.Resolve();

            switch (resultRound)
            {
                case RunResult.Run1Win:
                    return _lightMan1;
                case RunResult.Run2Win:
                    return _lightMan2;
                default:
                    return null;
            }
        }
    }
}
