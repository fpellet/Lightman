using System.Linq;
using LightManWP.ViewModels;
using LightManWPTests.Messengers;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace LightManWPTests.ViewModels
{
    using LightManWP.Notifications;

    [TestClass]
    public class StartRecordCommandTest
    {
        [TestMethod]
        public void WhenCommandIsExecutedThenNotificationIsSended()
        {
            var inputMessenger = new MessengerFake();
            var message = new Record(Recording.Start);

            var startRecordCommand = new StartRecordCommand(inputMessenger, message);
            startRecordCommand.Execute(null);

            Assert.IsNotNull(inputMessenger.SendedMessage);
            Assert.AreEqual(message, inputMessenger.SendedMessage.First());
        }
    }
}
