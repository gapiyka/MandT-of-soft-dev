using System;
using System.Text.Json;

namespace lab4
{
    class JSONS
    {
        public static string TaskToJson(Task task)
        {
            return JsonSerializer.Serialize(task);
        }

        public static Task JsonToTask(string jsonString)
        {
            string[] fields = jsonString.Split(",");
            int found = fields[0].IndexOf(":");
            ulong number = UInt64.Parse(fields[0].Substring(found + 1));
            found = fields[1].IndexOf(":");
            string caption = fields[1].Substring(found + 1).Trim("\""[0]);
            found = fields[2].IndexOf(":");
            string description = fields[2].Substring(found + 1).Trim("\""[0]);
            found = fields[3].IndexOf(":");
            DateTime deadline = DateTime.Parse(fields[3].Substring(found + 1).Trim("\""[0]));
            found = fields[4].IndexOf(":");
            TaskStatus taskStatus = (TaskStatus)int.Parse(fields[4].Substring(found + 1, 1));
            return new Task(number, caption, description, deadline, taskStatus);
            //return JsonSerializer.Deserialize<Task>(jsonString);
        }
    }
}
