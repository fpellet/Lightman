namespace LightManWP.Notifications
{
    public struct Record
    {
        public Recording RecordingOrder { get; private set; }

        public Lightman LightmanPlayer { get; private set; }

        public Record(Recording recordingOrder, Lightman lightmanPlayer) : this()
        {
            RecordingOrder = recordingOrder;
            LightmanPlayer = lightmanPlayer;
        }
    }
}
