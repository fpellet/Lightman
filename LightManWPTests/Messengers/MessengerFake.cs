using System.Collections.Generic;
using GalaSoft.MvvmLight.Messaging;

namespace LightManWPTests.Messengers
{
    public class MessengerFake: Messenger
    {
        public IList<object> SendedMessage { get; private set; }

        public MessengerFake()
        {
            SendedMessage = new List<object>();
        }

        public override void Send<TMessage>(TMessage message)
        {
            SendedMessage.Add(message);
            base.Send(message);
        }
    }
}