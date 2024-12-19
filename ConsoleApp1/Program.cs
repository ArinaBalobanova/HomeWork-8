using System;
using System.Collections.Generic;

public enum ProjectStatus
{
    Project,
    InProgress,
    Closed
}

public enum TaskStatus
{
    Assigned,
    InProgress,
    UnderReview,
    Completed
}

public class Report
{
    public string Text { get; set; }
    public DateTime DateCompleted { get; set; }
    public string Performer { get; set; }

    public Report(string text, DateTime dateCompleted, string performer)
    {
        Text = text;
        DateCompleted = dateCompleted;
        Performer = performer;
    }
}

public class Task
{
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public string Initiator { get; set; }
    public string Performer { get; set; }
    public TaskStatus Status { get; set; }
    public List<Report> Reports { get; set; }

    public Task(string description, DateTime deadline, string initiator)
    {
        Description = description;
        Deadline = deadline;
        Initiator = initiator;
        Status = TaskStatus.Assigned;
        Reports = new List<Report>();
    }

    public void AssignTo(string performer)
    {
        Performer = performer;
    }

    public void Start()
    {
        if (Performer != null)
        {
            Status = TaskStatus.InProgress;
        }
    }

    public void Complete(string reportText)
    {
        Status = TaskStatus.Completed;
        var report = new Report(reportText, DateTime.Now, Performer);
        Reports.Add(report);
    }
}

public class Project
{
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public string Initiator { get; set; }
    public string TeamLead { get; set; }
    public List<Task> Tasks { get; set; }
    public ProjectStatus Status { get; set; }

    public Project(string description, DateTime deadline, string initiator, string teamLead)
    {
        Description = description;
        Deadline = deadline;
        Initiator = initiator;
        TeamLead = teamLead;
        Tasks = new List<Task>();
        Status = ProjectStatus.Project;
    }

    public void AddTask(Task task)
    {
        if (Status == ProjectStatus.Project)
        {
            Tasks.Add(task);
        }
        else
        {
            Console.WriteLine("Cannot add tasks - Project is not in 'Project' status.");
        }
    }

    public void StartProject()
    {
        if (Status == ProjectStatus.Project)
        {
            Status = ProjectStatus.InProgress;
        }
    }

    public bool IsCompleted()
    {
        foreach (var task in Tasks)
        {
            if (task.Status != TaskStatus.Completed)
            {
                return false;
            }
        }
        Status = ProjectStatus.Closed;
        return true;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var projects = new List<Project>();

        // Создаем 10 сотрудников
        string[] teamMembers = { "Alice", "Bob", "Charlie", "David", "Eve", "Frank", "Grace", "Heidi", "Ivan", "Judy" };

        // Создаем проект
        Project project = new Project("Website Development", DateTime.Now.AddMonths(2), "Client1", "TeamLead1");
        projects.Add(project);

        // Создаем задачи и назначаем их
        for (int i = 0; i < 10; i++)
        {
            var task = new Task($"Task {i + 1}", DateTime.Now.AddDays(30), "Client1");
            task.AssignTo(teamMembers[i % teamMembers.Length]);
            project.AddTask(task);
        }

        // Запускаем проект
        project.StartProject();

        // Статус задач
        foreach (var task in project.Tasks)
        {
            Console.WriteLine($"Task: {task.Description}, Assigned to: {task.Performer}, Status: {task.Status}");
        }

        // Эмуляция выполнения задач
        foreach (var task in project.Tasks)
        {
            task.Start();
            task.Complete("Completed the task successfully.");
        }

        if (project.IsCompleted())
        {
            Console.WriteLine("Project is completed and closed.");
        }
    }
}