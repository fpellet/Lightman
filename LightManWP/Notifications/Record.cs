namespace LightManWP.Notifications
{
    public struct Record
    {
        public Recording RecordingOrder { get; private set; }

        public Record(Recording recordingOrder): this()
        {
            RecordingOrder = recordingOrder;
        }
    }
}
