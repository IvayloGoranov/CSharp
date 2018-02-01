using Buhtig.Models;
using Buhtig.Core;
using Buhtig.Interfaces;

namespace Buhtig.Tests
{
    public class FakeIssueTrackerWithLoggedUser : IssueTracker
    {
        private User fakeUser = new User("pesho", "parola");

        public FakeIssueTrackerWithLoggedUser()
            : base()
        {
            this.CurrentUser = fakeUser;
        }

        public FakeIssueTrackerWithLoggedUser(IBuhtigIssueTrackerData data)
            : base(data)
        {
            this.CurrentUser = fakeUser;
        }
    }
}
