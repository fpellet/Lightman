using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;

namespace LightManWP.ViewModels
{
    using LightManWP.Notifications;

    public class RecordCommand : ICommand
    {
        private readonly IMessenger _inputMessenger;
        private readonly Record _recordingOrder;

        public RecordCommand(IMessenger inputMessenger, Record recordingOrder)
        {
            _inputMessenger = inputMessenger;
            _recordingOrder = recordingOrder;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _inputMessenger.Send(_recordingOrder);
        }

        public event EventHandler CanExecuteChanged;
    }
}
