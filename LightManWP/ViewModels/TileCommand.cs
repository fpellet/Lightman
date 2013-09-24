using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;

namespace LightManWP.ViewModels
{
    public class TileCommand : ICommand
    {
        private readonly IMessenger _inputMessenger;
        private readonly TilePosition _tilePosition;

        public TileCommand(IMessenger inputMessenger, TilePosition tilePosition)
        {
            _inputMessenger = inputMessenger;
            _tilePosition = tilePosition;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _inputMessenger.Send(_tilePosition);
        }

        public event EventHandler CanExecuteChanged;
    }
}
