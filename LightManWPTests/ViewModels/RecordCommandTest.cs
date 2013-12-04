using System.Linq;
using LightManWP.Notifications;
using LightManWP.ViewModels;
using LightManWPTests.Messengers;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace LightManWPTests.ViewModels
{
    [TestClass]
    public class RecordCommandTest
    {
        [TestMethod]
        public void WhenCommandIsExecutedThenNotificationIsSended()
        {
            var inputMessenger = new MessengerFake();
            var expectedMessage = new Record(Recording.Start, Lightman.Lightman1);

            var startRecordCommand = new RecordCommand(inputMessenger, Recording.Start);
            startRecordCommand.Execute(Lightman.Lightman1);

            Assert.IsNotNull(inputMessenger.SendedMessage);
            Assert.AreEqual(expectedMessage, inputMessenger.SendedMessage.First());
        }
    }
}
