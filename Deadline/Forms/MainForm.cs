namespace Deadline
{
    public partial class MainForm : Form
    {
        Project project;

        
        //tmp переменные
        bool isDragging = false;
        Point startPoint;
        Size tmpsz;
        Point tmppoint;

        public MainForm()
        {
            InitializeComponent();
            tmpsz = new(Width, Height);
            tmppoint = new(this.Location.X, this.Location.Y);
            pnl_CreatePanel.SelectedTab = page_Clear;
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
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
                UpgradeProjInfo();
                pnl_CreatePanel.SelectedTab = page_ProjInfo;
            }
        }

        private void UpgradeProjInfo()
        {
            lbl_ProjName.Text = project.Name;

            prcs_CompleteProgress.Value = project.GetProgress();
            lbl_ProgressPercent.Text = $"{prcs_CompleteProgress.Value}%";

            lbl_AllTaskCount.Text = lbl_AllTaskCount.Text.Remove(lbl_AllTaskCount.Text.IndexOf(":") + 2).Insert(lbl_AllTaskCount.Text.IndexOf(":") + 2, $"{project.GetCountAllTasks()}");
            lbl_ToDoCount.Text = AddCountToString(lbl_ToDoCount.Text, TaskStatus.ToDo);
            lbl_InProcessCount.Text = AddCountToString(lbl_InProcessCount.Text, TaskStatus.InProcess);
            lbl_CompletedCount.Text = AddCountToString(lbl_CompletedCount.Text, TaskStatus.Complete);
        }

        private string AddCountToString(string text, TaskStatus status)
        {
            return text.Remove(text.IndexOf(":") + 2).Insert(text.IndexOf(":") + 2, $"{project.GetCountTasksFromStatus(status)}");
        }

        private void ClearCreateTaskMenu()
        {
            rch_NameInput.Text = "";
            rch_DescInput.Text = "";
            cmb_StatusChoose.SelectedIndex = 0;
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

            UpgradeProjInfo();
            pnl_CreatePanel.SelectedTab = page_ProjInfo;
        }
    }
}