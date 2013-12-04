using System.Collections.Generic;

namespace LightManWP.Model
{
    public class Arena
    {
        private readonly LightMan _lightMan1;
        private readonly LightMan _lightMan2;
        private bool _player2Turn;

        public Arena(LightMan lightMan1, LightMan lightMan2)
        {
            _lightMan1 = lightMan1;
            _lightMan2 = lightMan2;
        }

        public void StartNewRound()
        {
            _player2Turn = false;
        }

        public void RecordCurrentRun(Run currentRun)
        {
            if (_player2Turn)
            {
                _lightMan2.RecordRun(currentRun);
                _player2Turn = false;
            }
            else
            {
                _lightMan1.RecordRun(currentRun);
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