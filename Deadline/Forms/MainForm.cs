using System.Text.Json;

namespace Deadline
{
    public partial class MainForm : Form
    {
        Project? project;

        
        //tmp переменные
        bool isDragging = false;
        Point startPoint;
        int selectedTaskId;

        public MainForm()
        {
            InitializeComponent();
            pnl_CreatePanel.SelectedTab = page_Clear;
        }

        public MainForm(string path)
        {
            InitializeComponent();
            try
            {
                project = new Project("");
                FileInfo info = new FileInfo(path);
                if (info.Extension == ".dlproj")
                {
                    project.Deserealize(path);

                    UpdateAll();
                    pnl_CreatePanel.SelectedTab = page_ProjInfo;
                }
            }
            catch
            {
                pnl_CreatePanel.SelectedTab = page_Clear;
            }
        }

        // Handlers
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && e.Button == MouseButtons.Left)
            {
                if (sender is Control pan)
                    pan.Location = new Point(e.X - this.startPoint.X + pan.Location.X, e.Y - this.startPoint.Y + pan.Location.Y);
            }
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Panel p && !isDragging)
            {
                p.Parent = page_TaskBoard;
                p.BringToFront();
                p.BackColor = Color.FromArgb(150, p.BackColor.R, p.BackColor.G, p.BackColor.B);
                p.Controls[0].BackColor = p.BackColor;
            }

            isDragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
           if (sender is Panel p)
           {
                int columnSZ = pnl_TaskBoard.Width / 3;
                page_TaskBoard.Controls.Remove(p);

                if (p.Location.X <= columnSZ)
                {
                    project.Tasks[(int)p.Tag].Status = TaskStatus.ToDo;
                }
                else if (p.Location.X <= columnSZ * 2)
                {
                    project.Tasks[(int)p.Tag].Status = TaskStatus.InProcess;
                }
                else
                {
                    project.Tasks[(int)p.Tag].Status = TaskStatus.Complete;
                }
                UpdateAll();
           }

           isDragging = false;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Max_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void btn_Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pnl_Controls_MouseHover(object sender, EventArgs e)
        {
            foreach (var c in pnl_ControlPanel.Controls) 
            {
                if(c is Label control)
                    control.Visible = true;
            }
            pnl_ControlPanel.Width = pnl_ControlPanel.MaximumSize.Width;
        }

        private void pnl_Controls_MouseLeave(object sender, EventArgs e)
        {
            foreach (var c in pnl_ControlPanel.Controls)
            {
                if (c is Label control)
                    control.Visible = false;
            }
            pnl_ControlPanel.Width = pnl_ControlPanel.MinimumSize.Width;
        }

        private void btn_CreateProj_Click(object sender, EventArgs e)
        {
            CreateProj cp = new();
            cp.ShowDialog();
            if (cp.Text != "")
            {
                project = new Project(cp.Text);
                UpdateAll();
                pnl_CreatePanel.SelectedTab = page_ProjInfo;
            }
        }

        private void btn_CreateTask_Click(object sender, EventArgs e)
        {
            if (project != null)
            {
                pnl_CreatePanel.SelectedTab = page_CreateTask;
                ClearCreateTaskMenu();
            }
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            project.AddTask(rch_NameInput.Text, rch_DescInput.Text, date_LastDateChoose.Value, (TaskStatus)cmb_StatusChoose.SelectedIndex);

            UpdateAll();
            pnl_CreatePanel.SelectedTab = page_ProjInfo;
        }

        private void btn_SaveProj_Click(object sender, EventArgs e)
        {
            if(project != null)
            {
                SaveFileDialog sfd = new SaveFileDialog() { Filter = "DeadLine (*.dlproj)|*.dlproj" };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    project.Serealize(sfd.FileName);
                }
            }
        }

        private void btn_OpenProj_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "DeadLine (*.dlproj)|*.dlproj"};
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                project = new Project("");
                project.Deserealize(ofd.FileName);

                UpdateAll();
                pnl_CreatePanel.SelectedTab = page_ProjInfo;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearCreateTaskMenu();
            pnl_CreatePanel.SelectedTab = page_ProjInfo;
        }

        private void TaskEdit(object sender, EventArgs e)
        {
            if (sender is Control task)
            {
                selectedTaskId = (int)task.Tag;
                txt_NameEdit.Text = project.Tasks[selectedTaskId].Name;
                rch_DescEdit.Text = project.Tasks[selectedTaskId].Description;
                date_DateEdit.Value = project.Tasks[selectedTaskId].LastDate;
                cmb_StatusEdit.SelectedIndex = (int)project.Tasks[selectedTaskId].Status;
                
                pnl_CreatePanel.SelectedTab = page_TaskEdit;
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            project.Tasks[selectedTaskId].Name = txt_NameEdit.Text;
            project.Tasks[selectedTaskId].Description = rch_DescEdit.Text;
            project.Tasks[selectedTaskId].LastDate = date_DateEdit.Value;
            project.Tasks[selectedTaskId].Status = (TaskStatus)cmb_StatusEdit.SelectedIndex;

            pnl_CreatePanel.SelectedTab = page_ProjInfo;
            UpdateAll();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            project.DeleteTask(project.Tasks[selectedTaskId]);
            btn_Cancel_Click(sender, e);
            UpdateAll();
        }

        // Support methods

        private string AddCountToString(string text, TaskStatus status)
        {
            return text.Remove(text.IndexOf(":") + 2).Insert(text.IndexOf(":") + 2, $"{project.GetCountTasksFromStatus(status)}");
        }

        private void UpdateProjInfo()
        {
            lbl_ProjName.Text = project.Name;

            prcs_CompleteProgress.Value = project.GetProgress();
            lbl_ProgressPercent.Text = $"{prcs_CompleteProgress.Value}%";

            lbl_AllTaskCount.Text = lbl_AllTaskCount.Text.Remove(lbl_AllTaskCount.Text.IndexOf(":") + 2).Insert(lbl_AllTaskCount.Text.IndexOf(":") + 2, $"{project.GetCountAllTasks()}");
            lbl_ToDoCount.Text = AddCountToString(lbl_ToDoCount.Text, TaskStatus.ToDo);
            lbl_InProcessCount.Text = AddCountToString(lbl_InProcessCount.Text, TaskStatus.InProcess);
            lbl_CompletedCount.Text = AddCountToString(lbl_CompletedCount.Text, TaskStatus.Complete);
        }

        private void UpdateTaskBoard()
        {
            ClearTaskBoard();
            foreach (var t in project.Tasks)
            {
                TaskDirector task = new TaskDirector(t);

                if (t.Status == TaskStatus.ToDo)
                    pnl_ToDo.Controls.Add(task.BuildFullTask());
                if (t.Status == TaskStatus.InProcess)
                    pnl_InProcess.Controls.Add(task.BuildFullTask());
                if (t.Status == TaskStatus.Complete)
                    pnl_Complete.Controls.Add(task.BuildFullTask());
            }
            AddHandlersToTasks_ToDo(pnl_TaskBoard);
        }

        private void AddHandlersToTasks_List()
        {
            foreach (var t in pnl_TaskList.Controls)
            {
                AddDoubleClickToAllTask(t as Panel);
            }
        }

        private void AddDoubleClickToAllTask(Panel task)
        {
            task.DoubleClick += TaskEdit;
            foreach(var c in task.Controls)
            {
                if (c is Panel panel)
                    AddDoubleClickToAllTask(panel);
                else if (c is Control control)
                    control.DoubleClick += TaskEdit;
            }
        }

        private void AddHandlersToTasks_ToDo(Panel ToDoPanel)
        {
            foreach (var t in ToDoPanel.Controls)
            {
                if (t is FlowLayoutPanel fp)
                    AddHandlersToTasks_ToDo(fp);
                else if (t is Panel p)
                {
                    p.MouseDown += MainForm_MouseDown;
                    p.MouseUp += MainForm_MouseUp;
                    p.MouseMove += MainForm_MouseMove;
                    AddDoubleClickToAllTask(p);
                }
            }
        }

        private void UpdateTaskList()
        {
            ClearTaskList();
            foreach (var t in project.Tasks)
            {
                TaskDirector task = new TaskDirector(t);
                pnl_TaskList.Controls.Add(task.BuildFullTask());
            }
            AddHandlersToTasks_List();
        }

        private void UpdateCalendar()
        {
            ClearCalendar();
            Calendar c = new Calendar(project.Tasks);
            lbl_ThisDate.Text = c.Now.ToLongDateString();
            pnl_Calendar.Controls.AddRange(c.panels);
        }

        private void UpdateAll()
        {
            UpdateCalendar();
            UpdateTaskBoard();
            UpdateTaskList();
            UpdateProjInfo();
        }

        private void ClearCreateTaskMenu()
        {
            rch_NameInput.Text = "";
            rch_DescInput.Text = "";
            cmb_StatusChoose.SelectedIndex = 0;
        }

        private void ClearTaskList()
        {
            pnl_TaskList.Controls.Clear();
        }

        private void ClearTaskBoard()
        {
            pnl_ToDo.Controls.Clear();
            pnl_InProcess.Controls.Clear();
            pnl_Complete.Controls.Clear();
        }

        private void ClearCalendar()
        {
            pnl_Calendar.Controls.Clear();
        }

        
    }
}