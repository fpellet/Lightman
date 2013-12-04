using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using LightManWP.Model;
using LightManWP.Notifications;

namespace LightManWP.ViewModels
{
    public class ArenaViewModel
    {
        public ICommand StartRecordLightManCommand { get; private set; }

        public ICommand StopRecordCommand { get; private set; }

        public ICommand ResolveRunCommand { get; private set; }

        public bool IsWaitingForLightMan1 { get; private set; }

        public bool IsWaitingForLightMan2 { get; private set; }

        public LightMan Winner { get; private set; }

        private readonly IDictionary<Lightman, Run> _lighmansRuns;

        private Lightman _currentPlayer;

        private Arena _arena;

        private bool CurrentlyRecording
        {
            get
            {
                return IsWaitingForLightMan1 || IsWaitingForLightMan2;
            }
        }

        public ArenaViewModel(IMessenger messenger)
        {
            StartRecordLightManCommand = new RecordCommand(messenger, Recording.Start);
            StopRecordCommand = new RecordCommand(messenger, Recording.Stop);
            ResolveRunCommand = new RelayCommand(ResolveRound);

            _lighmansRuns = new Dictionary<Lightman, Run>();
            _arena = new Arena(new LightMan("J1"), new LightMan("J2"));

            messenger.Register<Record>(this, ManageRequestOrder);
            messenger.Register<TilePosition>(this, TileIsPressed);
        }

        private void ResolveRound()
        {
            _arena.StartNewRound();
            _arena.RecordCurrentRun(_lighmansRuns[Lightman.Lightman1]);
            _arena.RecordCurrentRun(_lighmansRuns[Lightman.Lightman2]);
            Winner = _arena.ResolveRound();
        }

        private void ManageRequestOrder(Record recordOrder)
        {
            switch (recordOrder.RecordingOrder)
            {
                case Recording.Start:
                    StartRecord(recordOrder.LightmanPlayer);
                    break;
                default:
                    StopRecord();
                    break;
            }
        }
        
        private void StartRecord(Lightman lightmanPlayer)
        {
            _lighmansRuns[lightmanPlayer] = new Run();
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

        private void StopRecord()
        {
            IsWaitingForLightMan1 = false;
            IsWaitingForLightMan2 = false;
        }

        private void TileIsPressed(TilePosition tilePosition)
        {
            if (CurrentlyRecording)
            {
                _lighmansRuns[_currentPlayer].AddTile(new Tile(tilePosition.PositionX, tilePosition.PositionY));
            }
        }
    }
}