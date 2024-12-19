using System;


namespace HomeWork2.Classes
{
    class Project
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
}
