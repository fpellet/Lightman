using LightManWP.Notifications;
using LightManWP.ViewModels;
using LightManWPTests.Messengers;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace LightManWPTests.ViewModels
{
    [TestClass]
    public class ArenaViewModelTest
    {
        private MessengerFake _inputMessenger;
        private ArenaViewModel _arenaViewModel;

        [TestInitialize]
        public void Initialize()
        {
            _inputMessenger = new MessengerFake();
            _arenaViewModel = new ArenaViewModel(_inputMessenger);            
        }

        [TestMethod]
        public void WhenArenaWaitingForFirstRunAndReceiveStopThenNoRecordIsWaiting()
        {
            Assert.IsFalse(_arenaViewModel.IsWaitingForLightMan1);
            Assert.IsFalse(_arenaViewModel.IsWaitingForLightMan2);
            
            _arenaViewModel.StartRecordLightManCommand.Execute(Lightman.Lightman1);

            Assert.IsTrue(_arenaViewModel.IsWaitingForLightMan1);
            Assert.IsFalse(_arenaViewModel.IsWaitingForLightMan2);

            _inputMessenger.Send(new TilePosition(0, 0));
            _inputMessenger.Send(new TilePosition(0, 1));
            _inputMessenger.Send(new TilePosition(0, 2));
            _arenaViewModel.StopRecordCommand.Execute(null);

            Assert.IsFalse(_arenaViewModel.IsWaitingForLightMan1);
            Assert.IsFalse(_arenaViewModel.IsWaitingForLightMan2);
        }

        [TestMethod]
        public void WhenArenaWaitingForSecondRunThenCanRecordTheSecondRun()
        {
            Assert.IsFalse(_arenaViewModel.IsWaitingForLightMan1);
            Assert.IsFalse(_arenaViewModel.IsWaitingForLightMan2);

            _arenaViewModel.StartRecordLightManCommand.Execute(Lightman.Lightman2);

            Assert.IsTrue(_arenaViewModel.IsWaitingForLightMan2);
            Assert.IsFalse(_arenaViewModel.IsWaitingForLightMan1);

            _inputMessenger.Send(new TilePosition(2, 2));
            _inputMessenger.Send(new TilePosition(2, 1));
            _inputMessenger.Send(new TilePosition(2, 0));
            _arenaViewModel.StopRecordCommand.Execute(null);

            Assert.IsFalse(_arenaViewModel.IsWaitingForLightMan1);
            Assert.IsFalse(_arenaViewModel.IsWaitingForLightMan2);
        }

        [TestMethod]
        public void WhenTwoRunAreRecordedThenFightCanBeResolvedAndResultIsDisplayed()
        {
            _arenaViewModel.StartRecordLightManCommand.Execute(Lightman.Lightman1);
            _inputMessenger.Send(new TilePosition(0, 0));
            _inputMessenger.Send(new TilePosition(0, 1));
            _inputMessenger.Send(new TilePosition(0, 2));
            _arenaViewModel.StopRecordCommand.Execute(null);

            _arenaViewModel.StartRecordLightManCommand.Execute(Lightman.Lightman2);
            _inputMessenger.Send(new TilePosition(2, 2));
            _inputMessenger.Send(new TilePosition(2, 1));
            _inputMessenger.Send(new TilePosition(2, 0));
            _arenaViewModel.StopRecordCommand.Execute(null);

            _arenaViewModel.ResolveRunCommand.Execute(null);

            Assert.AreEqual(null, _arenaViewModel.Winner);
        }
    }
}
