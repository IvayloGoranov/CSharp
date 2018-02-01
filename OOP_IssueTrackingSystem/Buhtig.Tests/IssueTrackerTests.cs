using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Buhtig.Data;
using Buhtig.Core;
using Buhtig.Models;
using Buhtig.Interfaces;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Buhtig.Tests
{
    [TestClass]
    public class IssueTrackerTests
    {
        [TestMethod]
        public void TestRegisterUser_ExistingUser()
        {
            IIssueTracker tracker = new FakeIssueTrackerWithNoUser();
            string username = "pesho";
            string password = "parola";
            string confirmPassword = "parola";

            tracker.RegisterUser(username, password, confirmPassword);
            string result = tracker.RegisterUser(username, password, confirmPassword);

            Assert.AreEqual(result, "A user with username pesho already exists", 
                "RegisterUser() does not return proper outcome in case of duplicate user.");
        }

        [TestMethod]
        public void TestRegisterUser_AlreadyLoggedInUser()
        {
            IIssueTracker tracker = new FakeIssueTrackerWithLoggedUser();
            string username = "pesho";
            string password = "parola";
            string confirmPassword = "parola";

            tracker.RegisterUser(username, password, confirmPassword);
            string result = tracker.RegisterUser(username, password, confirmPassword);

            Assert.AreEqual(result, "There is already a logged in user",
                "RegisterUser() does not return proper outcome in case of duplicate user.");
        }

        [TestMethod]
        public void TestRegisterUser_PasswordsDoNotMatch()
        {
            IIssueTracker tracker = new FakeIssueTrackerWithNoUser();
            string username = "pesho";
            string password = "parola";
            string confirmPassword = "parol";

            string result = tracker.RegisterUser(username, password, confirmPassword);

            Assert.AreEqual(result, "The provided passwords do not match",
                "RegisterUser() does not return proper outcome in case of pasword mismatch.");
        }

        [TestMethod]
        public void TestRegisterUser_ValidUserDetails_ShouldAddUserToDatabase()
        {
            IBuhtigIssueTrackerData data = new BuhtigIssueTrackerData();
            IIssueTracker tracker = new IssueTracker(data);
            string username = "pesho";
            string password = "parola";
            string confirmPassword = "parola";

            string result = tracker.RegisterUser(username, password, confirmPassword);
            
            User expectedUser = new User(username, password);
            User actualUser = data.UsersRepository[username];

            Assert.AreEqual(result, "User pesho registered successfully",
                "RegisterUser() does not return proper outcome in case of no logged in user.");
            
            Assert.AreEqual(expectedUser.Username, actualUser.Username, "RegisterUser() does not add user to database properly.");
            Assert.AreEqual(expectedUser.Password, actualUser.Password, "RegisterUser() does not add user to database properly.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateIssue_InvalidTitleAndDescription_ShouldThrowUp()
        {
            IIssueTracker tracker = new FakeIssueTrackerWithLoggedUser();
            
            string title = "ab";
            string description = "abc";
            IssuePriority priority = (IssuePriority)Enum.Parse(typeof(IssuePriority), "low");
            string[] tags = new string[]{"new", "issue", "another"};

            tracker.CreateIssue(title, description, priority, tags);
        }

        [TestMethod]
        public void TestCreateIssue_ValidIssueDetails_ShouldAddIssueToDatabase()
        {
            IIssueTracker tracker = new FakeIssueTrackerWithLoggedUser();

            string title = "title";
            string description = "description";
            IssuePriority priority = (IssuePriority)Enum.Parse(typeof(IssuePriority), "low");
            string[] tags = new string[] { "new", "issue", "another" };

            string result = tracker.CreateIssue(title, description, priority, tags);

            Assert.AreEqual(result, "Issue 1 created successfully",
                "CreateIssue() does not return proper outcome after successful issue creation.");
        }

        [TestMethod]
        public void TestCreateIssue_NoLoggedInUser()
        {
            IIssueTracker tracker = new FakeIssueTrackerWithNoUser();

            string title = "title";
            string description = "description";
            IssuePriority priority = (IssuePriority)Enum.Parse(typeof(IssuePriority), "low");
            string[] tags = new string[] { "new", "issue", "another" };

            string result = tracker.CreateIssue(title, description, priority, tags);

            Assert.AreEqual(result, "There is no currently logged in user",
                "CreateIssue() does not return proper outcome in case of no logged in user.");
        }

        [TestMethod]
        public void TestGetMyIssues_ShouldReturnCurrentUserIssues()
        {
            IBuhtigIssueTrackerData data = new FakeBuhtigTrackerData();
            IIssueTracker tracker = new FakeIssueTrackerWithLoggedUser(data);

            string actualResult = tracker.GetMyIssues();

            string title1 = "title1";
            string description1 = "description1";
            IssuePriority priority1 = (IssuePriority)Enum.Parse(typeof(IssuePriority), "low");
            string[] tags1 = new string[] { "new", "issue", "pink" };

            string title2 = "bigtitle";
            string description2 = "bigdescription";
            IssuePriority priority2 = (IssuePriority)Enum.Parse(typeof(IssuePriority), "medium");
            string[] tags2 = new string[] { "new", "issue", "yellow" };

            User pesho = new User("pesho", "parola");
            User gosho = new User("gosho", "parola");
            Issue issue1 = new Issue(title1, description1, priority1, tags1, pesho);
            Issue issue2 = new Issue(title2, description2, priority2, tags2, pesho);
            List<Issue> issues = new List<Issue>();
            issues.Add(issue1);
            issues.Add(issue2);
            var sortedIssues = issues.OrderByDescending(issue => issue.Priority).ThenBy(issue => issue.Title);

            string expectedResult = string.Join("", sortedIssues);

            Assert.AreEqual(expectedResult, actualResult, "GetMyIssues() does not get issues properly.");
        }

        [TestMethod]
        public void TestGetMyIssues_NoIssues()
        {
            IIssueTracker tracker = new FakeIssueTrackerWithLoggedUser();

            string actualResult = tracker.GetMyIssues();
            string expectedResult = "No issues";

            Assert.AreEqual(expectedResult, actualResult, "GetMyIssues() does not show proper output in case of no issues.");
        }

        [TestMethod]
        public void TestGetMyIssues_NoUser()
        {
            IIssueTracker tracker = new FakeIssueTrackerWithNoUser();

            string actualResult = tracker.GetMyIssues();
            string expectedResult = "There is no currently logged in user";

            Assert.AreEqual(expectedResult, actualResult, 
                "GetMyIssues() does not show proper output in case of no logged in user.");
        }

        [TestMethod]
        public void TestSearchForIssues_MatchingTags_ShouldReturnIssuesasStringAndNoDuplicates_Test1()
        {
            IBuhtigIssueTrackerData data = new FakeBuhtigTrackerData();
            IIssueTracker tracker = new FakeIssueTrackerWithLoggedUser(data);

            string actualResult1 = tracker.SearchForIssues(new string[] {"new"});

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

            User pesho = new User("pesho", "parola");
            User gosho = new User("gosho", "parola");
            Issue issue1 = new Issue(title1, description1, priority1, tags1, pesho);
            Issue issue2 = new Issue(title2, description2, priority2, tags2, pesho);
            Issue issue3 = new Issue(title3, description3, priority3, tags3, gosho);
            List<Issue> issues = new List<Issue>();
            issues.Add(issue1);
            issues.Add(issue2);
            issues.Add(issue3);
            var sortedIssues = issues.OrderByDescending(issue => issue.Priority).ThenBy(issue => issue.Title);

            string expectedResult1 = string.Join("", sortedIssues);

            Assert.AreEqual(expectedResult1, actualResult1, "SearchForIssues() does not get issues properly.");
        }

        [TestMethod]
        public void TestSearchForIssues_MatchingTags_ShouldReturnIssuesasStringAndNoDuplicates_Test2()
        {
            IBuhtigIssueTrackerData data = new FakeBuhtigTrackerData();
            IIssueTracker tracker = new FakeIssueTrackerWithLoggedUser(data);

            string actualResult = tracker.SearchForIssues(new string[] { "pink" });

            string title1 = "title1";
            string description1 = "description1";
            IssuePriority priority1 = (IssuePriority)Enum.Parse(typeof(IssuePriority), "low");
            string[] tags1 = new string[] { "new", "issue", "pink" };

            User pesho = new User("pesho", "parola");
            Issue issue1 = new Issue(title1, description1, priority1, tags1, pesho);
            List<Issue> issues = new List<Issue>();
            issues.Add(issue1);
            var sortedIssues = issues.OrderByDescending(issue => issue.Priority).ThenBy(issue => issue.Title);

            string expectedResult = string.Join("", sortedIssues);

            Assert.AreEqual(expectedResult, actualResult, "SearchForIssues() does not get issues properly.");
        }

        [TestMethod]
        public void TestSearchForIssues_MatchingTags_ShouldReturnIssuesasStringAndNoDuplicates_Test3()
        {
            IBuhtigIssueTrackerData data = new FakeBuhtigTrackerData();
            IIssueTracker tracker = new FakeIssueTrackerWithLoggedUser(data);

            string actualResult = tracker.SearchForIssues(new string[] { "pink", "green" });

            string title1 = "title1";
            string description1 = "description1";
            IssuePriority priority1 = (IssuePriority)Enum.Parse(typeof(IssuePriority), "low");
            string[] tags1 = new string[] { "new", "issue", "pink" };

            string title3 = "smalltitle";
            string description3 = "smalldescription";
            IssuePriority priority3 = (IssuePriority)Enum.Parse(typeof(IssuePriority), "medium");
            string[] tags3 = new string[] { "green", "issue", "new" };

            User pesho = new User("pesho", "parola");
            User gosho = new User("gosho", "parola");
            Issue issue1 = new Issue(title1, description1, priority1, tags1, pesho);
            Issue issue3 = new Issue(title3, description3, priority3, tags3, gosho);
            List<Issue> issues = new List<Issue>();
            issues.Add(issue1);
            issues.Add(issue3);
            var sortedIssues = issues.OrderByDescending(issue => issue.Priority).ThenBy(issue => issue.Title);

            string expectedResult = string.Join("", sortedIssues);

            Assert.AreEqual(expectedResult, actualResult, "SearchForIssues() does not get issues properly.");
        }

        [TestMethod]
        public void TestSearchForIssues_EmptyTagsArray_ShouldReturnMessageAsString()
        {
            IBuhtigIssueTrackerData data = new FakeBuhtigTrackerData();
            IIssueTracker tracker = new FakeIssueTrackerWithLoggedUser(data);

            string actualResult = tracker.SearchForIssues(new string[] {});

            string expectedResult = "There are no tags provided";

            Assert.AreEqual(expectedResult, actualResult, 
                "SearchForIssues() does not show proper message in case of empty tags array.");
        }

        [TestMethod]
        public void TestSearchForIssues_NoIssuesMatchingTheTags_ShouldReturnMessageAsString()
        {
            IBuhtigIssueTrackerData data = new FakeBuhtigTrackerData();
            IIssueTracker tracker = new FakeIssueTrackerWithLoggedUser(data);

            string actualResult = tracker.SearchForIssues(new string[] { "brown", "grey", "black"});

            string expectedResult = "There are no issues matching the tags provided";

            Assert.AreEqual(expectedResult, actualResult,
                "SearchForIssues() does not show proper message in case of mismatching tags array.");
        }
    }
}
