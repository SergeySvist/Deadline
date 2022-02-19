﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadline
{
    class Project
    {
        public string Name { get; set; }
        public List<Task> Tasks { get; set; }

        public Project(string name)
        {
            this.Name = name;
            Tasks = new List<Task>();
        }

        public void AddTask(string name, string description, DateTime lastdate, TaskStatus status)
        {
            Tasks.Add(new Task(Tasks.Count, name, description, lastdate, status));
        }

        public void DeleteTask(Task task)
        {
            Tasks.Remove(task);
        }

        public int GetCountAllTasks()
        {
            return Tasks.Count;
        }

        public int GetCountTasksFromStatus(TaskStatus status)
        {
            int tmp = 0;
            foreach(var t in Tasks)
            {
                if (t.Status == status)
                    tmp++;
            }
            return tmp;
        }

        public int GetProgress()
        {
            if (GetCountAllTasks() == 0)
                return 0;
            return (int)(((double)GetCountTasksFromStatus(TaskStatus.Complete) / (double)GetCountAllTasks())*100);
        }
    }
}
