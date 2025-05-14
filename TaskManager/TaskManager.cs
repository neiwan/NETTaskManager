namespace TaskSS
{
    public class TaskManager
    {
        private List<Task> tasks = new List<Task>();
        private static int nextId = 0;
        public List<string> Add(string Title, string Description, string DueDate)
        {
            Task newTask = new Task(nextId, Title, Description, DueDate);
            tasks.Add(newTask);
            Task? currentTask = tasks.FirstOrDefault(t => t.Id == nextId);
            
            nextId++;

            return [
                    currentTask.Id.ToString(),
                    currentTask.Title,
                    currentTask.Description,
                    currentTask.DueDate,
                    currentTask.IsCompleted ? "Да":"Нет",
                   ];
        }
        public bool Delete(int Id)
        {
            Task? currentTask = tasks.FirstOrDefault(t => t.Id == Id);
            if (currentTask != null)
            {
                tasks.Remove(currentTask);
                return true;
            }
            return false;
        }
        public bool Complete(int Id)
        {
            Task? currentTask = tasks.FirstOrDefault(t => t.Id == Id);
            if (currentTask != null)
            {
                currentTask.IsCompleted = true;
                return true;
            }
            return false;
        }
        public List<List<string>> List()
        {
            List<List<string>> listOfTasks= new List<List<string>>();
            foreach (Task task in tasks)
            {
                listOfTasks.Add(
                    [
                     task.Id.ToString(),
                     task.Title,
                     task.Description,
                     task.DueDate,
                     task.IsCompleted ? "Да":"Нет",
                    ]
                );    
            }
            return listOfTasks;
        }
    }
}
