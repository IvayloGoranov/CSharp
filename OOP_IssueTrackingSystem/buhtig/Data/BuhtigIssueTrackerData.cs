using System.Collections.Generic;
using Buhtig.Interfaces;
using Buhtig.Models;

namespace Buhtig.Data
{
    public class BuhtigIssueTrackerData : IBuhtigIssueTrackerData
    {
        private int nextAddIssueId = 1;
        
        public BuhtigIssueTrackerData()
        {
            this.UsersRepository = new Dictionary<string, User>();
            this.IssuesRepository = new Dictionary<int, Issue>();
            this.CommentsRepository = new Dictionary<string, List<Comment>>();
        }
        
        public IDictionary<string, User> UsersRepository { get; private set; }

        public IDictionary<int, Issue> IssuesRepository { get; private set; }

        public IDictionary<string, List<Comment>> CommentsRepository { get; private set; }

        public virtual int AddIssue(Issue issue)
        {
            issue.Id = this.nextAddIssueId;
            this.IssuesRepository.Add(this.nextAddIssueId, issue);
            this.nextAddIssueId++;

            return this.nextAddIssueId;
        }

        public virtual bool RemoveIssue(int id)
        {
            return this.IssuesRepository.Remove(id);
        }
    }
}
