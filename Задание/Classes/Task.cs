using System;


namespace HomeWork2.Classes
{
    class Task
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
}
