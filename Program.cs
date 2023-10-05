using System;
using System.Collections.Generic;
public class Task
{
    public string Description { get; set; } // property to store the task's description.
    public bool IsCompleted { get; set; } // property to store the wether task is completed or not.

    public Task(string description) // constructor to initialize a new task.
    {
        Description = description;
        IsCompleted = false;  // by default, a new task is not completed
    }
}

class Program
{
    static List<Task> tasks = new List<Task>(); // this will store our tasks.

    static void Main()
    {
        while (true) // Infinite loop to keep the program running until the user decides to exit.
        {
            Console.Clear();
            Console.WriteLine("To-Do List App");
            Console.WriteLine("------------------");
            DisplayMenu();
            HandleChoice();
        }

    }
    static void DisplayMenu()
    {
        Console.WriteLine("1. Add Task");
        Console.WriteLine("2. View Tasks");
        Console.WriteLine("3. Mark Task as Completed");
        Console.WriteLine("4. Exit");
        Console.WriteLine("Enter your choice:");
    }

    static void HandleChoice()
    {
        int choice;
        if (int.TryParse(Console.ReadLine(), out choice)) // parse the user's input.
        {
            switch (choice)
            {
                case 1:
                    AddTask();
                    break;
                case 2:
                    ViewTasks();
                    break;
                case 3:
                    MarkTaskAsCompleted();
                    break;
                case 4:
                    Environment.Exit(0); // exit the program.
                    break;
                default:
                    Console.WriteLine("Invalid Choice. Please try again");
                    break;
            }
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
        }
    }
    static void AddTask()
    {
        Console.WriteLine("Enter Task description:");
        string description = Console.ReadLine();
        tasks.Add(new Task(description)); // add a new task to the list.
    }

    static void ViewTasks()
    {
        for (int i = 0; i < tasks.Count; i++)
        {
            string status = tasks[i].IsCompleted ? "Completed" : "Pending";
            Console.WriteLine($"{i + 1}. {tasks[i].Description} - {status}");
        }
    }
    static void MarkTaskAsCompleted()
    {
        Console.WriteLine("Enter task number to mark as completed:");
        int taskNumber;
        if (int.TryParse(Console.ReadLine(), out taskNumber) && taskNumber <= tasks.Count && taskNumber > 0)
        {
            tasks[taskNumber - 1].IsCompleted = true;
            Console.WriteLine("Task marked as Completed!");
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
    }
}