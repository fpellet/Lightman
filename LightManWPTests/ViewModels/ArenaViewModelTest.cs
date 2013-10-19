using LightManWP.Notifications;
using LightManWP.ViewModels;

using LightManWPTests.Messengers;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace LightManWPTests.ViewModels
{
    [TestClass]
    public class ArenaViewModelTest
    {
        [TestMethod]
        public void WhenArenaWaitingForFirstRunAndReceiveStopThenNoRecordIsWaiting()
        {
            var inputMessenger = new MessengerFake();
            var arenaViewModel = new ArenaViewModel(inputMessenger);

            Assert.IsFalse(arenaViewModel.IsWaitingForLightMan1);
            Assert.IsFalse(arenaViewModel.IsWaitingForLightMan2);
            
            arenaViewModel.StartRecordLightMan1Command.Execute(null);

            Assert.IsTrue(arenaViewModel.IsWaitingForLightMan1);
            Assert.IsFalse(arenaViewModel.IsWaitingForLightMan2);

            inputMessenger.Send(new TilePosition(0, 0));
            inputMessenger.Send(new TilePosition(0, 1));
            inputMessenger.Send(new TilePosition(0, 2));
            arenaViewModel.StopRecordCommand.Execute(null);

            Assert.IsFalse(arenaViewModel.IsWaitingForLightMan1);
            Assert.IsFalse(arenaViewModel.IsWaitingForLightMan2);
        }

        [TestMethod]
        public void WhenArenaWaitingForSecondRunThenCanRecordTheSecondRun()
        {
            var inputMessenger = new MessengerFake();
            var arenaViewModel = new ArenaViewModel(inputMessenger);

            Assert.IsFalse(arenaViewModel.IsWaitingForLightMan1);
            Assert.IsFalse(arenaViewModel.IsWaitingForLightMan2);

            arenaViewModel.StartRecordLightMan2Command.Execute(null);

            Assert.IsTrue(arenaViewModel.IsWaitingForLightMan2);
            Assert.IsFalse(arenaViewModel.IsWaitingForLightMan1);

            inputMessenger.Send(new TilePosition(2, 2));
            inputMessenger.Send(new TilePosition(2, 1));
            inputMessenger.Send(new TilePosition(2, 0));
            arenaViewModel.StopRecordCommand.Execute(null);

            Assert.IsFalse(arenaViewModel.IsWaitingForLightMan1);
            Assert.IsFalse(arenaViewModel.IsWaitingForLightMan2);
        }
    }
}
