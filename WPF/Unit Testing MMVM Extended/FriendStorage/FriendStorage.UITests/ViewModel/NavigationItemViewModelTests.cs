using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using Moq;
using Prism.Events;

using FriendStorage.UI.ViewModel;
using FriendStorage.UI.Events;
using FriendStorage.UITests.Extension;

namespace FriendStorage.UITests.ViewModel
{
    [TestClass]
    public class NavigationItemViewModelTests
    {
        private const int FriendId = 7;

        private MainViewModel mainViewModel;
        private Mock<INavigationViewModel> navigationViewModelMock;
        private Mock<IEventAggregator> eventAggregatorMock;
        private List<Mock<IFriendEditViewModel>> friendEditViewModelMocks;
        private NavigationItemViewModel viewModel;

        [TestInitialize]
        public void TestInitialize()
        {
            this.friendEditViewModelMocks = new List<Mock<IFriendEditViewModel>>();
            this.navigationViewModelMock = new Mock<INavigationViewModel>();
            this.eventAggregatorMock = new Mock<IEventAggregator>();
            this.mainViewModel = new MainViewModel(navigationViewModelMock.Object, 
                this.CreateFriendEditViewModel, eventAggregatorMock.Object);

            this.viewModel = new NavigationItemViewModel(FriendId, "Gosho", eventAggregatorMock.Object);
        }

        [TestMethod]
        public void ShouldPublishOpenFriendEditViewEvent()
        {
            const int friendId = 7;

            Mock<OpenFriendEditViewEvent> eventMock = new Mock<OpenFriendEditViewEvent>();
            this.eventAggregatorMock.Setup(x => x.GetEvent<OpenFriendEditViewEvent>()).
                Returns(eventMock.Object);

            this.viewModel.OpenFriendEditViewCommand.Execute(null);

            eventMock.Verify(x => x.Publish(friendId), Times.Once);
        }

        [TestMethod]
        public void ShouldRaisePropertyChangedEventForDisplayMember()
        {
            bool fired = this.viewModel.IsPropertyChangedFired(() =>
            {
                this.viewModel.DisplayMember = "Changed";
            }, nameof(this.viewModel.DisplayMember));

            Assert.IsTrue(fired);
        }

        private IFriendEditViewModel CreateFriendEditViewModel()
        {
            var friendEditViewModelMock = new Mock<IFriendEditViewModel>();
            this.friendEditViewModelMocks.Add(friendEditViewModelMock);

            return friendEditViewModelMock.Object;
        }
    }
}
