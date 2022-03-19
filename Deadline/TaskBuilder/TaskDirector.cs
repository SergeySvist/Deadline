using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadline
{
    internal class TaskDirector
    {
        TaskBuilder builder;

        public TaskDirector(Task task)
        {
            builder = new TaskBuilder(task);
        }

        public Panel BuildFullTask()
        {
            builder.CreateMainPanel();
            builder.CreateNameLabel();
            builder.CreateDescriptionLabel();
            builder.CreateStatusLabel();
            builder.CreateDateLabel();
            builder.CreateSecondPanel();

            return builder.GetResult();
        }
    }
}
