using GalaSoft.MvvmLight.Messaging;
using LightManWP.Notifications;

namespace LightManWP.ViewModels
{
    public class RecordCommand : CommandBase<Lightman?>
    {
        private readonly IMessenger _inputMessenger;
        private readonly Recording _recording;

        public RecordCommand(IMessenger inputMessenger, Recording recording)
        {
            _inputMessenger = inputMessenger;
            _recording = recording;
        }

        protected override void Execute(Lightman? lightman)
        {
            _inputMessenger.Send(new Record(_recording, lightman ?? Lightman.Lightman1And2));
        }
    }
}
