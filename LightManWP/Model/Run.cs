using System.Collections.Generic;

namespace LightManWP.Model
{
    public class Run
    {
        public IList<Tile> Tiles { get; private set; }

        public Run(IList<Tile> tiles = null)
        {
            Tiles = tiles ?? new List<Tile>();
        }

        public void AddTile(Tile tile)
        {
            Tiles.Add(tile);
        }
    }
}