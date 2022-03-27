using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Deadline
{
    [Serializable]
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
            for (int i = task.Id + 1; i < Tasks.Count; i++)
            {
                Tasks[i].Id--;
            }
            Tasks.Remove(task);
        }

        public int GetCountAllTasks()
        {
            return Tasks.Count;
        }

        public int GetCountTasksFromStatus(TaskStatus status)
        {
            int tmp = 0;
            foreach (var t in Tasks)
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
            return (int)(((double)GetCountTasksFromStatus(TaskStatus.Complete) / (double)GetCountAllTasks()) * 100);
        }

        public void Serealize(string fileName)
        {
            try
            {
                using FileStream fs = new FileStream(fileName, FileMode.Create);
                JsonSerializer.Serialize(fs, this, new JsonSerializerOptions() { WriteIndented = true });
            }
            catch { }
        }

        public void Deserealize(string path)
        {
            try
            {
                using FileStream fs = new FileStream(path, FileMode.Open);
                Project proj = JsonSerializer.Deserialize<Project>(fs, new JsonSerializerOptions() { WriteIndented = true });
                this.Clone(proj);
            }
            catch { }
        }

        public void Clone(Project obj)
        {
            this.Name = obj.Name;
            this.Tasks.Clear();
            this.Tasks.AddRange(obj.Tasks);
        }
    }
}
