namespace LightManWP.ViewModels
{
    public struct TilePosition
    {
        public int PositionX { get; private set; }

        public int PositionY { get; private set; }

        public TilePosition(int positionX, int positionY)
            : this()
        {
            PositionX = positionX;
            PositionY = positionY;
        }
    }
}