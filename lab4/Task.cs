using System;
using System.Text.Json;

namespace lab4
{
    enum TaskStatus
    {
        Active,
        Done,
        Overdue
    }
    class Task
    {
        public ulong number { get; set; }
        public string caption { get; set; }
        public string description { get; set; }
        public DateTime deadline { get; set; }
        public TaskStatus taskStatus { get; set; }

        public Task(ulong number, string caption, string description, string deadline)
        {
            this.number = number;
            this.caption = caption;
            this.description = description;
            this.deadline = StringToDate(deadline);
            this.taskStatus = TaskStatus.Active;
        }

        public Task(ulong number, string caption, string description, DateTime deadline, TaskStatus taskStatus)
        {
            this.number = number;
            this.caption = caption;
            this.description = description;
            this.deadline = deadline;
            this.taskStatus = taskStatus;
        }

        public DateTime StringToDate(string date)
        {
            return DateTime.ParseExact(date, "yyyy-MM-dd-HH-mm", null);
        }
    }
}
