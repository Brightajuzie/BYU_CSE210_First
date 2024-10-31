using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Goal
{
    public string Title { get; set; }
    public string Description { get; set; }
    public GoalType Type { get; set; }
    public bool IsCompleted { get; set; }
    public int Points { get; set; }

    public Goal(string title, string description, GoalType type)
    {
        Title = title;
        Description = description;
        Type = type;
        IsCompleted = false;
        Points = 0;
    }

    public void MarkComplete()
    {
        IsCompleted = true;
        switch (Type)
        {
            case GoalType.Eternal:
                Points += 10;
                break;
            case GoalType.Temporary:
                Points += 50;
                break;
            case GoalType.Academic:
                Points += 20;
                break;
            case GoalType.Checklist:
                Points += 5;
                break;
        }
    }
}

enum GoalType
{
    Eternal,
    Temporary,
    Academic,
    Checklist
}

class User
{
    public string Username { get; set; }
    public List<Goal> Goals { get; set; }
    public int TotalPoints { get; set; }
    public int Level { get; set; }

    public User(string username)
    {
        Username = username;
        Goals = new List<Goal>();
        TotalPoints = 0;
        Level = 1;
    }

    public void AddGoal(Goal goal)
    {
        Goals.Add(goal);
    }

    public void ViewGoals()
    {
        foreach (var goal in Goals)
        {
            Console.WriteLine($" - {goal.Title} ({goal.Type}): {goal.Description}");
            if (goal.IsCompleted)
            {
                Console.WriteLine("   - Completed");
            }
            else
            {
                Console.WriteLine("   - In progress");
            }
        }
    }

    public void LevelUp()
    {
        if (TotalPoints >= 100)
        {
            Level++;
            Console.WriteLine($"Congratulations! You've leveled up to level {Level}!");
            TotalPoints -= 100;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();
        User user = new User(username);

        while (true)
        {
            DisplayMenu();

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.WriteLine();

            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                    user.AddGoal(CreateGoal(GoalType.Eternal));
                    break;
                case ConsoleKey.D2:
                    user.AddGoal(CreateGoal(GoalType.Temporary));
                    break;
                case ConsoleKey.D3:
                    user.AddGoal(CreateGoal(GoalType.Academic));
                    break;
                case ConsoleKey.D4:
                    user.AddGoal(CreateGoal(GoalType.Checklist));
                    break;
                case ConsoleKey.D5:
                    user.ViewGoals();
                    break;
                case ConsoleKey.D6:
                    MarkGoalComplete(user);
                    break;
                case ConsoleKey.3:
                    SaveGoalsToFile(user.Goals, "goals.json");
                    Console.WriteLine("Goals saved to file.");
                    break;
                case ConsoleKey.L:
                    user.Goals = LoadGoalsFromFile("goals.json");
                    Console.WriteLine("Goals loaded from file.");
                    break;
                case ConsoleKey.R:
                    ReadGoalsFromFile("goals.json");
                    break;
                case ConsoleKey.Escape:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("\nEternal Quest Menu:");
        Console.WriteLine("1. Create New Goals");
        Console.WriteLine("2. List goals");
        Console.WriteLine("3. Save goals");
        Console.WriteLine("4. Load goals");
        Console.WriteLine("5. Read goals");
        Console.WriteLine("Esc. Exit");
        Console.Write("Press the corresponding key to select an option: ");
    }

    static Goal CreateGoal(GoalType type)
    {
        Console.Write("Enter goal title: ");
        string title = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        return new Goal(title, description, type);
    }

    static void MarkGoalComplete(User user)
    {
        user.ViewGoals();
        Console.Write("Enter the number of the goal to mark as complete: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= user.Goals.Count)
        {
            user.Goals[index - 1].MarkComplete();
            user.TotalPoints += user.Goals[index - 1].Points;
            user.LevelUp();
        }
        else
        {
            Console.WriteLine("Invalid input. Please try again.");
        }
    }

    static void SaveGoalsToFile(List<Goal> goals, string filename)
    {
        string json = JsonSerializer.Serialize(goals);
        File.WriteAllText(filename, json);
    }

    static List<Goal> LoadGoalsFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            string json = File.ReadAllText(filename);
            return JsonSerializer.Deserialize<List<Goal>>(json);
        }
        else
        {
            Console.WriteLine("File not found.");
            return new List<Goal>();
        }
    }

    static void ReadGoalsFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            string json = File.ReadAllText(filename);
            List<Goal> goals = JsonSerializer.Deserialize<List<Goal>>(json);
            foreach (var goal in goals)
            {
                Console.WriteLine($" - {goal.Title} ({goal.Type}): {goal.Description}");
                if (goal.IsCompleted)
                {
                    Console.WriteLine("   - Completed");
                }
                else
                {
                    Console.WriteLine("   - In progress");
                }
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
