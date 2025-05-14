namespace TaskSS
{
    public class Task
    {
        private int id;
        private string title;
        private string description;
        private string dueDate;
        private bool isCompleted;

        public int Id { get { return id; } set { id = value; } }
        public string Title { get { return title; } set { title = value; } }
        public string Description { get { return description; } set { description = value; } }
        public string DueDate { get { return dueDate; } set { dueDate = value; } }
        public bool IsCompleted { get { return isCompleted; } set { isCompleted = value; } }
        public Task(int Id, string title, string description, string dueDate)
        {
            this.Id = Id;
            this.title = title;
            this.description = description;
            this.dueDate = dueDate;
            isCompleted = false;
        }
    }
}
