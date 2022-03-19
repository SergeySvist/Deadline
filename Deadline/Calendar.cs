using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadline
{
    internal class Calendar
    {
        public DateTime Now { get; private set; }
        public int CountDays { get; private set; }

        public Panel[] panels;

        private List<Task> tasks;

        public Calendar(List<Task> tasks)
        {
            Now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            CountDays = DateTime.DaysInMonth(Now.Year, Now.Month);
            this.tasks = new List<Task>(tasks);
            panels = new Panel[CountDays];
            CreatePanels();
        }

        private void CreatePanels()
        {
            for(int i=0; i < CountDays; i++)
            {
                panels[i] = new Panel();
                panels[i].Dock = DockStyle.Fill;
                panels[i].Padding = new Padding(2);
                panels[i].Controls.Add(CreateNumLabel(i+1));
                panels[i].Controls.Add(CreateTaskPanels(i + 1));
                panels[i].Controls[1].BringToFront();
                if (i == Now.Day-1)
                    panels[i].BackColor = Color.FromArgb(255, 48, 73);
            }
        }

        private Label CreateNumLabel(int index)
        {
            Label l = new Label();
            l.Text = index.ToString();
            l.Font = new Font("Segoe UI", 14);
            l.ForeColor = Color.White;
            l.Dock = DockStyle.Top;
            return l;
        }

        private FlowLayoutPanel CreateTaskPanels(int day)
        {
            FlowLayoutPanel res = new FlowLayoutPanel();

            res.AutoScroll = true;
            res.Dock= DockStyle.Fill;
            res.BackColor = Color.FromArgb(31, 31, 37);

            foreach(var t in tasks)
            {
                if (t.LastDate.Year == Now.Year && t.LastDate.Month == Now.Month && t.LastDate.Day == day && t.Status != TaskStatus.Complete)
                {
                    Panel tmp = new Panel();
                    tmp.Size = new Size(15, 15);
                    tmp.BackColor = (Color)t.MainColor;
                    res.Controls.Add(tmp);
                }
            }

            return res;
        }
    }
}
