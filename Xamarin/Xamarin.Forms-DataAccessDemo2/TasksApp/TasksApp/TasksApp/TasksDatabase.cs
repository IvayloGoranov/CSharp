using Xamarin.Forms;

using SQLite.Net;

namespace TasksApp
{
    public class TasksDatabase
    {
        private SQLiteConnection database;

        public TasksDatabase()
        {
            this.database = DependencyService.Get<ISQLite>().GetConnection();
            this.InitializeDatabase();
            this.Todos = this.database.Table<Todo>();
        }

        public TableQuery<Todo> Todos { get; private set; }

        public int Add<T>(T entity) where T : new()
        {
            return this.database.Insert(entity);
        }

        public int Delete<T>(object primaryKey)
        {
            return this.database.Delete<T>(primaryKey);
        }

        public int Update<T>(T entity)
        {
            return this.database.Update(entity);
        }

        private void InitializeDatabase()
        {
            this.database.CreateTable<Todo>();
            this.Add(new Todo { Name = "Clean the dishes" });
        }
    }
}
