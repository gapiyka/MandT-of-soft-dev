using System;

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
        public ulong number;
        public string caption;
        public string description;
        public DateTime deadline;
        public TaskStatus taskStatus;

        public Task(ulong number, string caption, string description, string deadline)
        {
            this.number = number;
            this.caption = caption;
            this.description = description;
            this.deadline = StringToDate(deadline);
            this.taskStatus = TaskStatus.Active;
        }

        public DateTime StringToDate(string date)
        {
            return DateTime.ParseExact(date, "yyyy-MM-dd-HH-mm", null);
        }
    }
}
