using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace TasksApp
{
    public class MainPageViewModel : BaseDatabaseViewModel
    {
        private ObservableCollection<TodoHomePageDTO> todos;

        public MainPageViewModel(TasksDatabase database)
            : base(database)
        {
            this.NewTodo = new TodoBindingModel
            {
                Name = string.Empty,
                Notes = string.Empty
            };

            this.AddCommand = new Command(this.HandleAddTodoCommand);
            this.RefreshCommand = new Command(this.HandleRefreshCommand);
            this.DeleteCommand = new Command(this.HandelDeleteCommand);
            this.EditCommand = new Command(this.HandelEditCommand);

            this.LoadTodos();
        }

        public ICommand AddCommand { get; private set; }

        public ICommand RefreshCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }

        public ICommand EditCommand { get; private set; }

        public TodoBindingModel NewTodo { get; set; }

        public IEnumerable<TodoHomePageDTO> Todos
        {
            get
            {
                if (this.todos == null)
                {
                    this.todos = new ObservableCollection<TodoHomePageDTO>();
                }

                return this.todos;
            }
            
            set
            {
                if (this.todos == null)
                {
                    this.todos = new ObservableCollection<TodoHomePageDTO>();
                }

                this.todos.Clear();
                foreach (var item in value)
                {
                    this.todos.Add(item);
                }
            }
        }

        private void HandleAddTodoCommand()
        {
            var newTodo = new Todo
            {
                Name = this.NewTodo.Name,
                Notes = this.NewTodo.Notes
            };

            this.Database.Add<Todo>(newTodo);
            this.LoadTodos();
        }

        private void HandleRefreshCommand()
        {
            this.LoadTodos();
        }

        private void HandelDeleteCommand(object primaryKey)
        {
            this.Database.Delete<Todo>(primaryKey);
        }

        private void HandelEditCommand(object primaryKey)
        {
            throw new NotImplementedException();
        }

        private void LoadTodos()
        {
            this.Todos = this.Database.Todos.AsQueryable()
                                .Select(TodoHomePageDTO.MapToDTO);
        }
    }
}
