using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadline
{
    class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastDate { get; set; }
        public TaskStatus Status { get; set; }
        public Color MainColor { get; set; }

        public Task(string name, string description, DateTime lastdate, TaskStatus status)
        {
            Name = name;
            Description = description;
            LastDate = new DateTime(lastdate.Year, lastdate.Month, lastdate.Day);
            Status = status;
            MainColor = Color.FromArgb(new Random().Next(0, 255), new Random().Next(0, 255), new Random().Next(0, 255));
        }
    }

    enum TaskStatus
    {
        ToDo,
        InProcess,
        Complete,
    }
}
