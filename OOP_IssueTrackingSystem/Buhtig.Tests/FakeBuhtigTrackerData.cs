using Buhtig.Data;
using Buhtig.Models;
using System;

namespace Buhtig.Tests
{
    public class FakeBuhtigTrackerData : BuhtigIssueTrackerData
    {
        public FakeBuhtigTrackerData()
            : base()
        {
            this.FillIssueRepositoryWithFakeData();
        }

        private void FillIssueRepositoryWithFakeData()
        {
            User pesho = new User("pesho", "parola");
            User gosho = new User("gosho", "parola");

            string title1 = "title1";
            string description1 = "description1";
            IssuePriority priority1 = (IssuePriority)Enum.Parse(typeof(IssuePriority), "low");
            string[] tags1 = new string[] { "new", "issue", "pink" };

            string title2 = "bigtitle";
            string description2 = "bigdescription";
            IssuePriority priority2 = (IssuePriority)Enum.Parse(typeof(IssuePriority), "medium");
            string[] tags2 = new string[] { "new", "issue", "yellow" };

            string title3 = "smalltitle";
            string description3 = "smalldescription";
            IssuePriority priority3 = (IssuePriority)Enum.Parse(typeof(IssuePriority), "medium");
            string[] tags3 = new string[] { "green", "issue", "new" };

            Issue issue1 = new Issue(title1, description1, priority1, tags1, pesho);
            Issue issue2 = new Issue(title2, description2, priority2, tags2, pesho);
            Issue issue3 = new Issue(title3, description3, priority3, tags3, gosho);
            base.AddIssue(issue1);
            base.AddIssue(issue2);
            base.AddIssue(issue3);
        }
    }
}
