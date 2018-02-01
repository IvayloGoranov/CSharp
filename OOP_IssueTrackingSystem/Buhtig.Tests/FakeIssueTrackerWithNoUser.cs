using Buhtig.Core;
using Buhtig.Models;
using Buhtig.Interfaces;

namespace Buhtig.Tests
{
    public class FakeIssueTrackerWithNoUser : IssueTracker
    {
        public FakeIssueTrackerWithNoUser()
            : base()
        {
        }

        public FakeIssueTrackerWithNoUser(IBuhtigIssueTrackerData data)
            : base(data)
        {
        }
    }
}
