using System;
using System.Linq.Expressions;

namespace TasksApp
{
    public class TodoHomePageDTO
    {
        public static Expression<Func<Todo, TodoHomePageDTO>> MapToDTO
        {
            get
            {
                return x => new TodoHomePageDTO
                {
                    Id = x.Id,
                    Name = x.Name
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
