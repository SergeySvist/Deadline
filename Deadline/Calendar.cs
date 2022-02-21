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
                if (i == Now.Day-1)
                    panels[i].BackColor = Color.FromArgb(255, 48, 73);
            }
        }
    }
}
