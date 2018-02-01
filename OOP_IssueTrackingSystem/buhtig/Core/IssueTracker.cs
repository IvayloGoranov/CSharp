using Buhtig.Interfaces;
using Buhtig.Data;
using Buhtig.Models;
using Buhtig.Utilities;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System;

namespace Buhtig.Core 
{
    public class IssueTracker : IIssueTracker
    {
        //DI: Decoupling the IssueTracker class from the concrete BuhtigIssueTrackerData class
        //by introducing a dependancy injection.
        //The IssueTracker can now work with any Data type that extends the IBuhtigIssueTrackerDat interface.
        public IssueTracker(IBuhtigIssueTrackerData data)
        {
            //PERFORMANCE: Fixed Unnecessary time consuming cast to BuhtigIssueTrackerData.
            this.Data = data;
        }
        
        public IssueTracker()
            : this(new BuhtigIssueTrackerData()) 
        {
        }
        
        public IBuhtigIssueTrackerData Data { get; private set; }

        public User CurrentUser { get; protected set; }

        public string RegisterUser(string username, string password, string confirmPassword)
        {
            string viewResult = string.Empty;
            
            if (this.CurrentUser != null)
            {
                viewResult = string.Format("There is already a logged in user");
                return viewResult;
            }

            if (password != confirmPassword)
            {
                viewResult = string.Format("The provided passwords do not match");
                return viewResult;
            }

            if (this.Data.UsersRepository.ContainsKey(username))
            {
                viewResult = string.Format("A user with username {0} already exists", username);
                return viewResult;
            }

            User user = new User(username, password);
            this.Data.UsersRepository.Add(username, user);

            viewResult = string.Format("User {0} registered successfully", username);
            return viewResult;
        }

        public string LoginUser(string username, string password) 
        {
            string viewResult = string.Empty;

            if (this.CurrentUser != null)
            {
                viewResult = string.Format("There is already a logged in user");
                return viewResult;
            }

            if (!this.Data.UsersRepository.ContainsKey(username))
            {
                viewResult = string.Format("A user with username {0} does not exist", username);
                return viewResult;
            }
            
            var user = this.Data.UsersRepository[username];
            string hashedPassword = HashUtilities.HashPassword(password);

            if (user.Password != hashedPassword)
            {
                viewResult = string.Format("The password is invalid for user {0}", username);
                return viewResult;
            }
            
            this.CurrentUser = user;
            viewResult = string.Format("User {0} logged in successfully", username);
            return viewResult;
        }

        public string LogoutUser() 
        {
            string viewResult = string.Empty;
            if (this.CurrentUser == null)
            {
                viewResult = string.Format("There is no currently logged in user");
                return viewResult;
            }

            string username = this.CurrentUser.Username;
            
            this.CurrentUser = null;

            viewResult = string.Format("User {0} logged out successfully", username);
            return viewResult;
        }

        public string CreateIssue(string title, string description, IssuePriority priority, string[] tags) 
        {
            string viewResult = string.Empty;
            if (this.CurrentUser == null)
            {
                viewResult = string.Format("There is no currently logged in user");
                return viewResult;
            }

            //PERFORMANCE: Fixed a performance issue with redundant data structures. Changed and reduced the number of
            //data structures.
            
            var issue = new Issue(title, description, priority, tags.ToList(), this.CurrentUser);
            this.Data.AddIssue(issue);

            viewResult = string.Format("Issue {0} created successfully", issue.Id);
            return viewResult;
        }

        public string RemoveIssue(int issueId) 
        {
            string viewResult = string.Empty;
            if (this.CurrentUser == null)
            {
                viewResult = string.Format("There is no currently logged in user");
                return viewResult;
            }

            if (!this.Data.IssuesRepository.ContainsKey(issueId))
            {
                viewResult = string.Format("There is no issue with ID {0}", issueId);
                return viewResult;
            }
            
            var issue = this.Data.IssuesRepository[issueId];
            if (issue.Author.Username != this.CurrentUser.Username)
            {
                viewResult = string.Format("The issue with ID {0} does not belong to user {1}", issueId, this.CurrentUser.Username);
                return viewResult;
            }

            //PERFORMANCE: Fixed a performance issue with redundant data structures. Changed and reduced the number of
            //data structures.

            this.Data.RemoveIssue(issueId);

            viewResult = string.Format("Issue {0} removed", issueId);
            return viewResult;
        }

        public string AddComment(int issueId, string commentText) 
        {
            string viewResult = string.Empty;
            if (this.CurrentUser == null)
            {
                viewResult = string.Format("There is no currently logged in user");
                return viewResult;
            }

            if (!this.Data.IssuesRepository.ContainsKey(issueId))
            {
                viewResult = string.Format("There is no issue with ID {0}", issueId);
                return viewResult;
            }

            var issue = this.Data.IssuesRepository[issueId];
            var comment = new Comment(this.CurrentUser, commentText);
            issue.Comments.Add(comment);

            if (!this.Data.CommentsRepository.ContainsKey(this.CurrentUser.Username))
            {
                this.Data.CommentsRepository.Add(this.CurrentUser.Username, new List<Comment>());
                this.Data.CommentsRepository[this.CurrentUser.Username].Add(comment);
            }
            else
            {
                this.Data.CommentsRepository[this.CurrentUser.Username].Add(comment);
            }

            viewResult = string.Format("Comment added successfully to issue {0}", issue.Id);
            return viewResult;
        }

        public string GetMyIssues() 
        {
            string viewResult = string.Empty;
            if (this.CurrentUser == null)
            {
                viewResult = string.Format("There is no currently logged in user");
                return viewResult;
            }

            var currentUserIssues = this.Data.IssuesRepository.Values.ToList().
                Where(issue => issue.Author.Username == this.CurrentUser.Username);

            if (!currentUserIssues.Any())
            {
                viewResult = "No issues";
                return viewResult;
            }
            
            var sortedIssues = currentUserIssues.OrderByDescending(issue => issue.Priority).ThenBy(issue => issue.Title).ToList();

            StringBuilder output = new StringBuilder();
            for (int i = 0; i < sortedIssues.Count; i++)
            {
                if (i == sortedIssues.Count - 1)
                {
                    output.AppendFormat("{0}", sortedIssues[i]);
                    break;
                }

                output.AppendFormat("{0}{1}", sortedIssues[i], Environment.NewLine);
            }
            
            viewResult = output.ToString();
            return viewResult;
        }

        public string GetMyComments() 
        {
            string viewResult = string.Empty;
            if (this.CurrentUser == null)
            {
                viewResult = string.Format("There is no currently logged in user");
                return viewResult;
            }

            if (!this.Data.CommentsRepository.ContainsKey(this.CurrentUser.Username))
            {
                viewResult = string.Format("No comments");
                return viewResult;
            }
            
            var currentUserComments = this.Data.CommentsRepository[this.CurrentUser.Username];

            StringBuilder output = new StringBuilder();
            for (int i = 0; i < currentUserComments.Count; i++)
            {
                if (i == currentUserComments.Count - 1)
                {
                    output.AppendFormat("{0}", currentUserComments[i]);
                    break;
                }

                output.AppendFormat("{0}{1}", currentUserComments[i], Environment.NewLine);
            }
            
            viewResult = output.ToString();

            return viewResult;
        }

        public string SearchForIssues(string[] tags) 
        {
            string viewResult = string.Empty;
            if (tags.Length == 0)
            {
                viewResult = "There are no tags provided";
                return viewResult;
            }

            var allIssues = this.Data.IssuesRepository.Values;
            List<Issue> matchingIssues = new List<Issue>();
            foreach (Issue issue in allIssues)
            {
                foreach (string tag in tags)
                {
                    if (issue.Tags.Contains(tag))
                    {
                        matchingIssues.Add(issue);
                        break;
                    }
                }
            }

            if (!matchingIssues.Any())
            {
                viewResult = "There are no issues matching the tags provided";
                return viewResult;
            }

            var sortedIssues = matchingIssues.OrderByDescending(issue => issue.Priority).ThenBy(issue => issue.Title).ToList();

            StringBuilder output = new StringBuilder();
            for (int i = 0; i < sortedIssues.Count; i++)
            {
                if (i == sortedIssues.Count - 1)
                {
                    output.AppendFormat("{0}", sortedIssues[i]);
                    break;
                }

                output.AppendFormat("{0}{1}", sortedIssues[i], Environment.NewLine);
            }

            viewResult = output.ToString();
            return viewResult;
        }
    }
}
