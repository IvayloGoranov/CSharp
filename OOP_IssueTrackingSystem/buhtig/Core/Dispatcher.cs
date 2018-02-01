using Buhtig.Interfaces;
using Buhtig.Models;
using System;

namespace Buhtig.Core
{
    public class Dispatcher : IDispatcher
    {
        private IIssueTracker tracker;
        
        Dispatcher(IIssueTracker tracker)
        {
            this.tracker = tracker;
        }
        
        public Dispatcher()
            : this(new IssueTracker())
        {
        }

        public string DispatchAction(IEndpoint endpoint)
        {
            switch (endpoint.ActionName)
            {
                case "RegisterUser":
                    string username = endpoint.Parameters["username"];
                    string password = endpoint.Parameters["password"];
                    string confirmPassword = endpoint.Parameters["confirmPassword"];
                    
                    return tracker.RegisterUser(username, password, confirmPassword);
                case "LoginUser":
                    username = endpoint.Parameters["username"];
                    password = endpoint.Parameters["password"];
                    
                    return tracker.LoginUser(username, password);
                case "LogoutUser":
                    return tracker.LogoutUser();
                case "CreateIssue":
                    string title = endpoint.Parameters["title"];
                    string description = endpoint.Parameters["description"];
                    IssuePriority priority = (IssuePriority)System.Enum.Parse(typeof(IssuePriority), 
                        endpoint.Parameters["priority"]);
                    string[] tags = endpoint.Parameters["tags"].Split('|');
                    
                    return tracker.CreateIssue(title, description, priority, tags);
                case "RemoveIssue":
                    int issueId = int.Parse(endpoint.Parameters["id"]);
                    
                    return tracker.RemoveIssue(issueId);
                case "AddComment":
                    issueId = int.Parse(endpoint.Parameters["id"]);
                    string commentText = endpoint.Parameters["text"];
                    
                    return tracker.AddComment(issueId, commentText);
                case "MyIssues": 
                    return tracker.GetMyIssues();
                case "MyComments": return tracker.GetMyComments();
                case "Search":
                    tags = endpoint.Parameters["tags"].Split('|');
                    
                    return tracker.SearchForIssues(tags);
                default:
                    throw new InvalidOperationException(string.Format("Invalid action: {0}", endpoint.ActionName));
            }
        }
    }
}
