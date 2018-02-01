using Buhtig.Models;

namespace Buhtig.Interfaces
{
    /// <summary>
    /// Defines a set of methods that allow user interaction with an issue tracking system.
    /// For example registering users, creating issues, extracting issues from a database and viewing them etc.
    /// </summary>
    public interface IIssueTracker
    {
        /// <summary>
        /// Registers the user of a issue tracking system application into a database of users.
        /// </summary>
        /// <param name="username">User's userame.</param>
        /// <param name="password">User's password.</param>
        /// <param name="confirmPassword">The user password repeated (to avoid spelling mistakes).</param>
        /// <returns>A string containing either a success message (if everything went as expected),
        /// or an error message (if there was any problem executing the command).</returns>
        string RegisterUser(string username, string password, string confirmPassword);
        
        /// <summary>
        /// Logs the user into the issue tracking system application.
        /// </summary>
        /// <param name="username">User's userame.</param>
        /// <param name="password">User's password.</param>
        /// <param name="confirmPassword">The user password repeated (to avoid spelling mistakes).</param>
        /// <returns>A string containing either a success message (if everything went as expected),
        /// or an error message (if there was any problem executing the command).</returns>
        string LoginUser(string username, string password);
        
        /// <summary>
        /// Logs the user out of the issue tracking system application.
        /// </summary>
        /// <returns>A string containing either a success message (if everything went as expected),
        /// or an error message (if there was any problem executing the command).</returns>
        string LogoutUser();

        /// <summary>
        /// Creates a new issue which is to be stored in the issue tracking system database.
        /// </summary>
        /// <param name="title">Issue title.</param>
        /// <param name="description">Issue description.</param>
        /// <param name="priority">Issue priority.</param>
        /// <param name="tags">Issue set of tags.</param>
        /// <returns>A string containing either a success message (if everything went as expected),
        /// or an error message (if there was any problem executing the command).</returns>
        string CreateIssue(string title, string description, IssuePriority priority, string[] tags);

        /// <summary>
        /// Removes an issue from the issue tracking system database.
        /// The issue to be removed is extracted from the database by issue id.
        /// </summary>
        /// <param name="issueId">Issue Id.</param>
        /// <returns>A string containing either a success message (if everything went as expected),
        /// or an error message (if there was any problem executing the command).</returns>
        string RemoveIssue(int issueId);

        /// <summary>
        /// Creates a new comment which is to be added to the respective issue,
        /// which is extracted from the database by issue id.
        /// </summary>
        /// <param name="issueId">Issue Id.</param>
        /// <param name="text">Comment text.</param>
        /// <returns>A string containing either a success message (if everything went as expected),
        /// or an error message (if there was any problem executing the command).</returns>
        string AddComment(int issueId, string text);

        /// <summary>
        /// Extracts from the issue tracking system database all issue created by the current user.
        /// In case of success, the action returns the issues sorted by priority (in descending order) first,
        /// and by title (in alphabetical order) next.
        /// </summary>
        /// <returns>A string containing either a success message (if everything went as expected),
        /// or an error message (if there was any problem executing the command).</returns>
        string GetMyIssues();

        /// <summary>
        /// Extracts from the issue tracking system database all comments created by the current user.
        /// In case of success, the action returns the comments sorted by time of adding to the application database. 
        /// </summary>
        /// <returns>A string containing either a success message (if everything went as expected),
        /// or an error message (if there was any problem executing the command).</returns>
        string GetMyComments();

        /// <summary>
        /// Searches for issues containing one or more of the provided tags. 
        /// In case of success, the action returns the issues sorted by priority (in descending order) first,
        /// and by title (in alphabetical order) next. 
        /// </summary>
        /// <param name="tags">Tags to search for.</param>
        /// <returns>A string containing either a success message (if everything went as expected),
        /// or an error message (if there was any problem executing the command).</returns>
        string SearchForIssues(string[] tags);
    }
}
