namespace LightManWP.Model
{
    public class Tile
    {
        public bool IsUsed { get; private set; }

        public int X { get; private set; }

        public int Y { get; private set; }

        public Tile(int posX, int posY)
        {
            X = posX;
            Y = posY;
        }

        public void Used()
        {
            IsUsed = true;
        }
    }
}