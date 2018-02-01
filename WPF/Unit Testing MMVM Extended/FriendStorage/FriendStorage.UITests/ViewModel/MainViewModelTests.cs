using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using Moq;
using Prism.Events;

using FriendStorage.UI.ViewModel;
using FriendStorage.UI.Events;
using FriendStorage.Model;
using FriendStorage.UITests.Extension;
using FriendStorage.UI.Wrapper;
using System.Linq;

namespace FriendStorage.UITests.ViewModel
{
    [TestClass]
    public class MainViewModelTests
    {
        private MainViewModel mainViewModel;
        private Mock<INavigationViewModel> navigationViewModelMock;
        private Mock<IEventAggregator> eventAggregatorMock;
        private OpenFriendEditViewEvent openFriendEditViewEvent;
        private List<Mock<IFriendEditViewModel>> friendEditViewModelMocks = new List<Mock<IFriendEditViewModel>>();

        [TestInitialize]
        public void TestInitialize()
        {
            this.navigationViewModelMock = new Mock<INavigationViewModel>();
            this.eventAggregatorMock = new Mock<IEventAggregator>();
            this.openFriendEditViewEvent = new OpenFriendEditViewEvent();

            this.eventAggregatorMock.Setup(x => x.GetEvent<OpenFriendEditViewEvent>()).
                Returns(this.openFriendEditViewEvent);

            this.mainViewModel = new MainViewModel(navigationViewModelMock.Object,
                CreateFriendEditViewModel, this.eventAggregatorMock.Object);
        }

        [TestMethod]
        public void TestLoad_ShouldCallTheLoadMethodOfTheNavigationViewModel()
        {
            this.mainViewModel.Load();

            this.navigationViewModelMock.Verify(x => x.Load(), Times.AtLeastOnce());
        }

        [TestMethod]
        public void ShouldAddFriendEditViewModelAndLoadAndSelectIt()
        {
            var friendEditViewModelMock = new Mock<IFriendEditViewModel>();
            bool fired = this.mainViewModel.IsPropertyChangedFired(() =>
                {
                    this.mainViewModel.SelectedFriendEditViewModel = friendEditViewModelMock.Object;
                }, 
                nameof(this.mainViewModel.SelectedFriendEditViewModel));

            Assert.IsTrue(fired);
        }

        [TestMethod]
        public void ShouldAddFriendEditViewModelsOnlyOnce()
        {
            this.openFriendEditViewEvent.Publish(5);
            this.openFriendEditViewEvent.Publish(5);
            this.openFriendEditViewEvent.Publish(6);
            this.openFriendEditViewEvent.Publish(7);
            this.openFriendEditViewEvent.Publish(7);

            Assert.AreEqual(3, this.mainViewModel.FriendEditViewModels.Count);
        }

        [TestMethod]
        public void ShouldRaisePropertyChangedEventForSelectedFriendEditViewModel()
        {
            this.openFriendEditViewEvent.Publish(5);
            this.openFriendEditViewEvent.Publish(5);
            this.openFriendEditViewEvent.Publish(6);
            this.openFriendEditViewEvent.Publish(7);
            this.openFriendEditViewEvent.Publish(7);

            Assert.AreEqual(3, this.mainViewModel.FriendEditViewModels.Count);
        }

        [TestMethod]
        public void ShouldRemoveFriendEditViewModelOnCloseFriendTabCommand()
        {
            this.openFriendEditViewEvent.Publish(7);

            var friendEditViewModel = this.mainViewModel.SelectedFriendEditViewModel;

            this.mainViewModel.CloseFriendTabCommand.Execute(friendEditViewModel);

            Assert.AreEqual(0, this.mainViewModel.FriendEditViewModels.Count);
        }

        [TestMethod]
        public void ShouldAddFriendEditViewModelAndLoadAndSelectIt_2()
        {
            const int friendId = 7;
            this.openFriendEditViewEvent.Publish(friendId);

            Assert.AreEqual(1, this.mainViewModel.FriendEditViewModels.Count);

            var friendEditViewModel = this.mainViewModel.FriendEditViewModels.First();
            Assert.AreEqual(friendEditViewModel, this.mainViewModel.SelectedFriendEditViewModel);
            this.friendEditViewModelMocks.First().Verify(vm => vm.Load(friendId), Times.Once);
        }

        [TestMethod]
        public void ShouldAddFriendEditViewModelAndLoadItWithIdNullAndSelectIt()
        {
            this.mainViewModel.AddFriendCommand.Execute(null);

            Assert.AreEqual(1, this.mainViewModel.FriendEditViewModels.Count);

            var friendEditViewModel = this.mainViewModel.FriendEditViewModels.First();
            Assert.AreEqual(friendEditViewModel, this.mainViewModel.SelectedFriendEditViewModel);
            this.friendEditViewModelMocks.First().Verify(vm => vm.Load(null), Times.Once);
        }

        private IFriendEditViewModel CreateFriendEditViewModel()
        {
            var friendEditViewModelMock = new Mock<IFriendEditViewModel>();
            friendEditViewModelMock.Setup(vm => vm.Load(It.IsAny<int?>())).
                Callback<int?>(friendId =>
            {
                friendEditViewModelMock.Setup(vm => vm.Friend).
                Returns(new FriendWrapper(new Friend { Id = friendId.Value }));
            });

            this.friendEditViewModelMocks.Add(friendEditViewModelMock);

            return friendEditViewModelMock.Object;
        }
    }
}
