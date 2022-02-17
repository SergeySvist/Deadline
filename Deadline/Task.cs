﻿using System;
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
        public RGBColor MainColor { get; set; }

        public Task(string name, string description, DateTime lastdate, TaskStatus status)
        {
            Name = name;
            Description = description;
            LastDate = new DateTime(lastdate.Year, lastdate.Month, lastdate.Day);
            Status = status;
            MainColor = new RGBColor(new Random().Next(0, 255), new Random().Next(0, 255), new Random().Next(0, 255));
        }
    }

    struct RGBColor
    {
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }

        public RGBColor(int r, int g, int b)
        {
            R = r; G = g; B = b; 
        }

        public static explicit operator Color(RGBColor color)
        {
            return Color.FromArgb(color.R, color.G, color.B);
        }
    }

    enum TaskStatus
    {
        ToDo,
        InProcess,
        Complete,
    }
}
