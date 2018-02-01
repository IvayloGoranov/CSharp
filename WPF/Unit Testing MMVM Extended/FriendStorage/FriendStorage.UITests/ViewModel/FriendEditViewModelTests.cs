using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using FriendStorage.UI.DataProvider;
using FriendStorage.UI.ViewModel;
using FriendStorage.Model;
using FriendStorage.UITests.Extension;
using FriendStorage.UI.Events;
using Prism.Events;
using FriendStorage.UI.Dialogs;

namespace FriendStorage.UITests.ViewModel
{
    [TestClass]
    public class FriendEditViewModelTests
    {
        private const int FriendId = 5;

        private Mock<IFriendDataProvider> dataProviderMock;
        private FriendEditViewModel friendEditViewModel;
        private Mock<FriendSavedEvent> friendSavedEventMock;
        private Mock<IEventAggregator> eventAggregatorMock;
        private Mock<IMessageDialogService> dialogService;

        [TestInitialize]
        public void TestInitialize()
        {
            this.friendSavedEventMock = new Mock<FriendSavedEvent>();
            this.eventAggregatorMock = new Mock<IEventAggregator>();
            this.eventAggregatorMock.Setup(ea => ea.GetEvent<FriendSavedEvent>()).
                Returns(this.friendSavedEventMock.Object);

            this.dataProviderMock = new Mock<IFriendDataProvider>();
            this.dataProviderMock.Setup(dp => dp.GetFriendById(FriendId)).
                Returns(new Friend { Id = FriendId, FirstName = "Thomas" });

            this.dialogService = new Mock<IMessageDialogService>();

            this.friendEditViewModel = new FriendEditViewModel(this.dataProviderMock.Object,
                this.eventAggregatorMock.Object, this.dialogService.Object);
        }

        [TestMethod]
        public void ShouldLoadFriend()
        {
            this.friendEditViewModel.Load(FriendId);

            Assert.IsNotNull(this.friendEditViewModel.Friend);
            Assert.AreEqual(FriendId, this.friendEditViewModel.Friend.Id);

            this.dataProviderMock.Verify(dp => dp.GetFriendById(FriendId), Times.Once);
        }

        [TestMethod]
        public void ShouldRaisePropertyChangedEventForFriend()
        {
            var friendEditViewModelMock = new Mock<IFriendEditViewModel>();
            bool fired = this.friendEditViewModel.IsPropertyChangedFired(() =>
            {
                this.friendEditViewModel.Load(FriendId);
            },
            nameof(this.friendEditViewModel.Friend));

            Assert.IsTrue(fired);
        }

        [TestMethod]
        public void ShouldDisableSaveCommandWhenFriendIsLoaded()
        {
            this.friendEditViewModel.Load(FriendId);

            Assert.IsFalse(this.friendEditViewModel.SaveCommand.CanExecute(null));
        }

        [TestMethod]
        public void ShouldEnableSaveCommandWhenFriendIsChanged()
        {
            this.friendEditViewModel.Load(FriendId);

            this.friendEditViewModel.Friend.FirstName = "Changed";

            Assert.IsTrue(this.friendEditViewModel.SaveCommand.CanExecute(null));
        }

        [TestMethod]
        public void ShouldDisableSaveCommandWithoutLoad()
        {
            Assert.IsFalse(this.friendEditViewModel.SaveCommand.CanExecute(null));
        }

        [TestMethod]
        public void ShouldRsiseCanExecuteChangedForSaveCommandWhenFriendIsChanged()
        {
            this.friendEditViewModel.Load(FriendId);
            bool fired = false;

            this.friendEditViewModel.SaveCommand.CanExecuteChanged += (s, e) => fired = true;
            this.friendEditViewModel.Friend.FirstName = "Changed";

            Assert.IsTrue(fired);
        }

        [TestMethod]
        public void ShouldRaiseCanExecuteChangedForSaveCommandAfterLoad()
        {
            this.friendEditViewModel.Load(FriendId);
            bool fired = false;

            this.friendEditViewModel.SaveCommand.CanExecuteChanged += (s, e) => fired = true;
            this.friendEditViewModel.Load(FriendId);

            Assert.IsTrue(fired);
        }

        [TestMethod]
        public void ShouldCallSaveMethodOfDataProviderWhenSaveCommandIsExecuted()
        {
            this.friendEditViewModel.Load(FriendId);
            this.friendEditViewModel.Friend.FirstName = "Changed";

            this.friendEditViewModel.SaveCommand.Execute(null);
            this.dataProviderMock.
                Verify(dp => dp.SaveFriend(this.friendEditViewModel.Friend.Model), Times.Once);
        }

        [TestMethod]
        public void ShouldAcceptChangesWhenSaveCommandIsExecuted()
        {
            this.friendEditViewModel.Load(FriendId);
            this.friendEditViewModel.Friend.FirstName = "Changed";

            this.friendEditViewModel.SaveCommand.Execute(null);
            Assert.IsFalse(this.friendEditViewModel.Friend.IsChanged);
        }

        [TestMethod]
        public void ShouldFriendSavedEventWhenSaveCommandIsExecuted()
        {
            this.friendEditViewModel.Load(FriendId);
            this.friendEditViewModel.Friend.FirstName = "Changed";

            this.friendEditViewModel.SaveCommand.Execute(null);
            this.friendSavedEventMock.Verify(e => e.Publish(this.friendEditViewModel.Friend.Model), Times.Once);
        }

        [TestMethod]
        public void ShouldEnableDeleteCommandForExistingFriend()
        {
            this.friendEditViewModel.Load(FriendId);
            Assert.IsTrue(this.friendEditViewModel.DeleteCommand.CanExecute(null));
        }

        [TestMethod]
        public void ShouldDisableDeleteCommandForNewFriend()
        {
            this.friendEditViewModel.Load(null);
            Assert.IsFalse(this.friendEditViewModel.DeleteCommand.CanExecute(null));
        }

        [TestMethod]
        public void ShouldDisableDeleteCommandWithoutLoad()
        {
            Assert.IsFalse(this.friendEditViewModel.DeleteCommand.CanExecute(null));
        }

        [TestMethod]
        public void ShouldRaiseCanExecuteChangedForDeleteCommandWhenAcceptingChanges()
        {
            this.friendEditViewModel.Load(FriendId);
            bool fired = false;

            this.friendEditViewModel.Friend.FirstName = "Changed";

            this.friendEditViewModel.DeleteCommand.CanExecuteChanged += (s, e) => fired = true;
            this.friendEditViewModel.Friend.AcceptChanges();
            Assert.IsTrue(fired);
        }

        [TestMethod]
        public void ShouldCallDeleteFriendWhenDeleteCommandIsExecuted()
        {
            this.friendEditViewModel.Load(FriendId);

            this.dialogService.Setup(ds => ds.ShowYesNoDialog(It.IsAny<string>(), It.IsAny<string>())).
                Returns(MessageDialogResult.Yes);

            this.dataProviderMock.Verify(dp => dp.DeletFriend(FriendId), Times.Once);
            this.dialogService.Verify(ds => ds.ShowYesNoDialog(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
