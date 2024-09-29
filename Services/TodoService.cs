namespace supaBlazor.Services;

public class TodoService
{
    public List<TodoItem> Todos { get; private set; } = new List<TodoItem>();

    public class TodoItem
    {
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
    }
}
