
namespace TasksApp
{
    public abstract class BaseDatabaseViewModel : BaseViewModel
    {
        private TasksDatabase database;

        public BaseDatabaseViewModel(TasksDatabase database)
        {
            this.database = database;       
        }

        public TasksDatabase Database
        {
            get
            {
                return this.database;
            }
        }
    }
}
