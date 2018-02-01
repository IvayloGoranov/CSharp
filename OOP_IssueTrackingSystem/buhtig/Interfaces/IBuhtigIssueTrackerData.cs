using Buhtig.Models;
using System.Collections.Generic;

namespace Buhtig.Interfaces
{
    public interface IBuhtigIssueTrackerData
    {
        IDictionary<string, User> UsersRepository { get; }

        IDictionary<int, Issue> IssuesRepository { get; }

        IDictionary<string, List<Comment>> CommentsRepository { get; }

        int AddIssue(Issue issue);

        bool RemoveIssue(int id);
    }
}
