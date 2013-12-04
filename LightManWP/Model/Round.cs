using System.Collections.Generic;
using System.Linq;

namespace LightManWP.Model
{
    public struct Round : IRound
    {
        private readonly IList<Tile> _runLightman1;
        private readonly IList<Tile> _runLightman2;

        public Round(Run runLightman1, Run runLightman2)
        {
            _runLightman1 = runLightman1.Tiles;
            _runLightman2 = runLightman2.Tiles;
        }

        public RunResult Resolve()
        {
            var step = 0;
            while (step < _runLightman1.Count())
            {
                if (step >= _runLightman2.Count())
                {
                    return RunResult.Run2Win;
                }

                var tileLight1 = _runLightman1[step];
                var tileLight2 = _runLightman2[step];

                if (tileLight1.Equals(tileLight2))
                {
                    return RunResult.Draw;
                }

                if (tileLight2.IsUsed)
                {
                    return RunResult.Run2Win;
                }

                if (tileLight1.IsUsed)
                {
                    return RunResult.Run1Win;
                }

                tileLight1.Used();
                tileLight2.Used();
                step++;
            }

            return step < _runLightman2.Count() ? RunResult.Run1Win : RunResult.Draw;
        }
    }
}