using System.Collections.Generic;

using GalaSoft.MvvmLight.Messaging;

using LightManWP.Notifications;

namespace LightManWP.ViewModels
{
    public class ArenaViewModel
    {
        private readonly IDictionary<Lightman, IList<TilePosition>> _lighmansRuns;

        private Lightman _currentPlayer;

        private bool CurrentlyRecording
        {
            get
            {
                return IsWaitingForLightMan1 || IsWaitingForLightMan2;
            }
        }

        public RecordCommand StartRecordLightMan1Command { get; set; }

        public RecordCommand StartRecordLightMan2Command { get; set; }
        
        public RecordCommand StopRecordCommand { get; set; }

        public bool IsWaitingForLightMan1 { get; set; }

        public bool IsWaitingForLightMan2 { get; set; }

        public ArenaViewModel(IMessenger messenger)
        {
            StartRecordLightMan1Command = new RecordCommand(messenger, new Record(Recording.Start, Lightman.Lightman1));
            StartRecordLightMan2Command = new RecordCommand(messenger, new Record(Recording.Start, Lightman.Lightman2));
            StopRecordCommand = new RecordCommand(messenger, new Record(Recording.Stop, Lightman.Lightman1And2));

            _lighmansRuns = new Dictionary<Lightman, IList<TilePosition>>();

            messenger.Register<Record>(this, ManageRequestOrder);
            messenger.Register<TilePosition>(this, TileIsPressed);
        }

        private void ManageRequestOrder(Record recordOrder)
        {
            switch (recordOrder.RecordingOrder)
            {
                case Recording.Start:
                    StartRecord(recordOrder.LightmanPlayer);
                    break;
                default:
                    StopRecord(recordOrder.LightmanPlayer);
                    break;
            }
        }
        
        private void StartRecord(Lightman lightmanPlayer)
        {
            _lighmansRuns[lightmanPlayer] = new List<TilePosition>();
            _currentPlayer = lightmanPlayer;

            if (lightmanPlayer == Lightman.Lightman1)
            {
                IsWaitingForLightMan1 = true;
                IsWaitingForLightMan2 = false;
            }
            else if (lightmanPlayer == Lightman.Lightman2)
            {
                IsWaitingForLightMan1 = false;
                IsWaitingForLightMan2 = true;
            }
        }

        private void StopRecord(Lightman lightmanPlayer)
        {
            IsWaitingForLightMan1 = false;
            IsWaitingForLightMan2 = false;
        }

        private void TileIsPressed(TilePosition tilePosition)
        {
            if (CurrentlyRecording)
            {
                _lighmansRuns[_currentPlayer].Add(tilePosition);
            }
        }
    }
}