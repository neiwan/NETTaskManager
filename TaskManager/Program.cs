namespace TaskSS 
{
    class Program()
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new();

            bool exited = true;
            do
            {
                Console.WriteLine("\nВведите команду (add/delete/complete/list/exit): ");
                string? command1 = Console.ReadLine();
                switch (command1)
                {
                    case "add":
                        string? title = "";
                        string? description = "";
                        string? dueDate = "";

                        while (title == "")
                        {
                            Console.Write("\nВведите заголовок задачи: ");
                            title = Console.ReadLine();
                        }
                        Console.Write("Введите описание задачи: ");
                        description = Console.ReadLine();
                        Console.Write("Введите дату дедлайна задачи: ");
                        dueDate = Console.ReadLine();
                        List<string> taskInfo = taskManager.Add(title, description, dueDate);
                        Console.WriteLine("\nЗаметка создана:\n\tId:\t\t{0},\n\tЗаголовок:\t{1},\n\tОписание:\t{2},\n\tДедлайн:\t{3},\n\tВыполнена?:\t{4}.\n", taskInfo[0], taskInfo[1], taskInfo[2], taskInfo[3], taskInfo[4]);
                        break;
                    case "delete":
                        Console.Write("\nВведите идентификатор заметки: ");
                        int idDelete = CheckIntInput();
                        if (taskManager.Delete(idDelete)) Console.WriteLine("\nЗаметка удалена!\n");
                        else Console.WriteLine("\nЗаметка с таким идентификатором не существует!\n");
                        break;
                    case "complete":
                        Console.Write("\nВведите идентификатор заметки: ");
                        int idComplete = CheckIntInput();
                        if (taskManager.Complete(idComplete)) Console.WriteLine("\nЗаметка завершена!\n");
                        else Console.WriteLine("\nЗаметка с таким идентификатором не существует!\n");
                        break;
                    case "list":
                        List<List<string>> tasksList = taskManager.List();
                        if (tasksList.Count == 0)
                        {
                            Console.WriteLine("\nЕще не создана ни одна заметка. Создайте новую с помощью комманды add!\n");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nСписок заметок:\n");
                        }
                        foreach (List<string> task in tasksList)
                        {
                            Console.WriteLine("\tЗаметка c Id:\t{0},\n\tЗаголовок:\t{1},\n\tОписание:\t{2},\n\tДедлайн:\t{3},\n\tВыполнена?:\t{4}.\n", task[0], task[1], task[2], task[3], task[4]);
                        }
                        break;
                    case "exit":
                        Console.WriteLine("\nПриложение закрыто");
                        exited = false;
                        break;
                    default:
                        exited = true;
                        break;
                }
            } while (exited);
        }
        private static int CheckIntInput()
        {
            int id = -1;
            bool isNumberInt = false;
            while (!isNumberInt)
            {
                try
                {
                    id = Convert.ToInt32(Console.ReadLine());
                    isNumberInt = true;
                }
                catch (Exception)
                {
                    Console.Write("Введите идентификатор заметки в числовом формате:");
                }
            }
            return id;
        }
    }
}





