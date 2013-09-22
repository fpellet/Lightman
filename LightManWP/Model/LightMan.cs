using System.Collections.Generic;

namespace LightManWP.Model
{
    public class LightMan
    {
        public Run Run { get; private set; }

        public string Name { get; private set; }

        public LightMan(string name)
        {
            Name = name;
        }

        public void RecordRun(Run run)
        {
            Run = run;
        }
    }
}