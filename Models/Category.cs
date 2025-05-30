namespace ToDoListApplication.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        //many todo items can belong to one category
        public ICollection<Todo> TodoList { get; set; } = new List<Todo>();
    }
}
