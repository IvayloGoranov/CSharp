
using SQLite.Net.Attributes;

namespace TasksApp
{
    public class Todo
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Notes { get; set; }

        public bool Done { get; set; }
    }
}
