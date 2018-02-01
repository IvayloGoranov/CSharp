
using SQLite.Net;

namespace TasksApp
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
