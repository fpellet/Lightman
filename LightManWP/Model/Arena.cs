using System.Collections.Generic;

namespace LightManWP.Model
{
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