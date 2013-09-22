using System.Collections.Generic;

namespace LightManWP.Model
{
    public class Run
    {
        public IList<Tile> RunList { get; private set; }

        public Run(IList<Tile> run)
        {
            RunList = run;
        }
    }
}