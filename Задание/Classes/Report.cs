using System;

namespace HomeWork2.Classes
{
    class Report
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
}
