class Task
{
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime DueDate { get; set; }

    public Task(string description, DateTime dueDate)
    {
        Description = description;
        IsCompleted = false;
        DueDate = dueDate;
    }
}

class TodoList
{
    private List<Task> tasks;

    public TodoList()
    {
        tasks = new List<Task>();
    }

    public void AddTask(string description, DateTime dueDate)
    {
        Task task = new Task(description, dueDate);
        tasks.Add(task);
        Console.WriteLine("Task added successfully!");
    }

    public void MarkTaskAsCompleted(int taskNumber)
    {
        if (taskNumber >= 1 && taskNumber <= tasks.Count)
        {
            Task task = tasks[taskNumber - 1];
            task.IsCompleted = true;
            Console.WriteLine($"Task '{task.Description}' marked as completed!");
        }
        else
        {
            Console.WriteLine("Invalid task number. Please try again.");
        }
    }

    public void RemoveCompletedTasks()
    {
        tasks.RemoveAll(task => task.IsCompleted);
        Console.WriteLine("Completed tasks removed successfully!");
    }

    public void ViewTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks found.");
        }
        else
        {
            Console.WriteLine("Tasks:");

            for (int i = 0; i < tasks.Count; i++)
            {
                Task task = tasks[i];
                string status = task.IsCompleted ? "(Completed)" : "(Incomplete)";
                Console.WriteLine($"{i + 1}. {status} {task.Description} (Due: {task.DueDate})");
            }
        }

        Console.WriteLine();
    }

    public void SearchTask()
    {
        Console.Write("Enter a keyword to search for task name: ");
        string keyword = Console.ReadLine();

        var matchingTasks = tasks.Where(task => task.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase));

        if (matchingTasks.Any())
        {
            Console.WriteLine($"Matching Tasks for '{keyword}':");

            foreach (var task in matchingTasks)
            {
                string status = task.IsCompleted ? "(Completed)" : "(Incomplete)";
                Console.WriteLine($"{task.Description} {status} (Due: {task.DueDate})");
            }
        }
        else
        {
            Console.WriteLine("No matching tasks found.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        TodoList todoList = new TodoList();
        bool exit = false;
        Console.WriteLine("╔══════════════════════════════╗");
        Console.WriteLine("║        Welcome to the        ║");
        Console.WriteLine("║        To-Do List App!       ║");
        Console.WriteLine("╚══════════════════════════════╝");
        Console.WriteLine();

        while (!exit)
        {
            Console.WriteLine("What do you want to do next?");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Mark Task as Completed");
            Console.WriteLine("3. Remove Completed Tasks");
            Console.WriteLine("4. View Tasks");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your number of choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.Write("Enter the task name: ");
                    string taskDescription = Console.ReadLine();
                    Console.Write("Enter the due date (YYYY-MM-DD): ");
                    DateTime taskDue = DateTime.Parse(Console.ReadLine());
                    todoList.AddTask(taskDescription, taskDue);
                    break;
                case 2:
                    Console.Clear();
                    todoList.ViewTasks();
                    Console.Write("Enter the task number to mark as completed: ");
                    int taskNumber = Convert.ToInt32(Console.ReadLine());
                    todoList.MarkTaskAsCompleted(taskNumber);
                    break;
                case 3:
                    Console.Clear();
                    todoList.RemoveCompletedTasks();
                    break;
                case 4:
                    Console.Clear();
                    todoList.ViewTasks();

                    todoList.SearchTask();
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
