using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deadline
{
    class TaskBuilder
    {
        Task task;

        Panel mainPanel;
        Panel secondPanel;

        public TaskBuilder(Task task)
        {
            this.task = task;
            mainPanel = new Panel();
            secondPanel = new Panel();
        }

        public Panel GetResult()
        {
            Panel tmp = mainPanel;
            mainPanel = new Panel();
            secondPanel = new Panel();
            return tmp;
        }

        public void CreateMainPanel()
        {
            mainPanel.Size = new Size(200, 115);
            mainPanel.BackColor = (Color)task.MainColor;
            mainPanel.Padding = new Padding(10);
            mainPanel.Tag = task.Id;
        }

        public void CreateNameLabel()
        {
            Label name = new Label();
            name.Text = task.Name;
            name.Dock = DockStyle.Top;
            name.Tag = task.Id;
            mainPanel.Controls.Add(name);
        }

        public void CreateSecondPanel()
        {
            secondPanel.BackColor = Color.FromArgb(31, 31, 37);
            secondPanel.Dock = DockStyle.Fill;
            secondPanel.Padding = new Padding(0, 23, 0, 0);
            secondPanel.Tag = task.Id;
            mainPanel.Controls.Add(secondPanel);
        }

        public void CreateDescriptionLabel()
        {
            Label desc = new Label();
            desc.Text = task.Description;
            desc.ForeColor = Color.White;
            desc.Size = new Size(0, 50);
            desc.AutoSize = false;
            desc.Dock = DockStyle.Top;
            desc.Tag = task.Id;
            secondPanel.Controls.Add(desc);
        }

        public void CreateStatusLabel()
        {
            Label status = new Label();
            status.Text = task.Status.ToString();
            status.ForeColor = Color.White;
            status.Location = new Point(secondPanel.Location.X, secondPanel.Size.Height-20);
            status.Tag = task.Id;
            secondPanel.Controls.Add(status);
        }
        public void CreateDateLabel()
        {
            Label date = new Label();
            date.Text = task.LastDate.ToString();
            date.ForeColor = Color.White;
            date.Location = new Point(secondPanel.Size.Width-date.Width, secondPanel.Size.Height - 20);
            date.Tag = task.Id;
            secondPanel.Controls.Add(date);
        }

    }
}
