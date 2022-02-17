using System.Text.Json;

namespace Deadline
{
    public partial class MainForm : Form
    {
        Project project;
        
        //tmp переменные
        bool isDragging = false;
        Point startPoint;
        int tmp = 0;

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
                FileInfo info = new FileInfo(path);
                if (info.Extension == ".dlproj")
                {
                    Deserealize(path);

                    UpdateAll();
                    pnl_CreatePanel.SelectedTab = page_ProjInfo;
                }
            }
            catch
            {
                pnl_CreatePanel.SelectedTab = page_Clear;
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && e.Button == MouseButtons.Left)
            {
                Point p = PointToScreen(e.Location);
                Point p2 = new Point(e.X - pnl_TaskBoard.Location.X+pnl_TaskBoard.Width, e.Y - pnl_TaskBoard.Location.Y + pnl_TaskBoard.Height);

                if (sender is Form f)
                    f.Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
                else if (sender is Panel pan)
                    pan.Location = new Point(e.X - this.startPoint.X + pan.Location.X, e.Y - this.startPoint.Y + pan.Location.Y);

            }
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Panel p && !isDragging)
            {
                p.Parent = page_TaskBoard;
                p.BringToFront();
            }

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
                UpdateProjInfo();
                pnl_CreatePanel.SelectedTab = page_ProjInfo;
            }
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
            AddHandlersToTasks();
        }

        private void AddHandlersToTasks()
        {
            foreach(var t in pnl_ToDo.Controls)
            {
                if(t is Panel p)
                {
                    p.MouseDown += MainForm_MouseDown;
                    p.MouseUp += MainForm_MouseUp;
                    p.MouseMove += MainForm_MouseMove;
                }
            }
            foreach (var t in pnl_InProcess.Controls)
            {
                if (t is Panel p)
                {
                    p.MouseDown += MainForm_MouseDown;
                    p.MouseUp += MainForm_MouseUp;
                    p.MouseMove += MainForm_MouseMove;
                }
            }
            foreach (var t in pnl_Complete.Controls)
            {
                if (t is Panel p)
                {
                    p.MouseDown += MainForm_MouseDown;
                    p.MouseUp += MainForm_MouseUp;
                    p.MouseMove += MainForm_MouseMove;
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
        }

        private void UpdateAll()
        {
            UpdateTaskBoard();
            UpdateTaskList();
            UpdateProjInfo();
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

        private void ClearTaskList()
        {
            while(pnl_TaskList.Controls.Count != 0)
            {
                pnl_TaskList.Controls.RemoveAt(0);
            }
        }

        private void ClearTaskBoard()
        {
            while (pnl_ToDo.Controls.Count != 0)
            {
                pnl_ToDo.Controls.RemoveAt(0);
            }
            while (pnl_InProcess.Controls.Count != 0)
            {
                pnl_InProcess.Controls.RemoveAt(0);
            }
            while (pnl_Complete.Controls.Count != 0)
            {
                pnl_Complete.Controls.RemoveAt(0);
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
                    Serealize(sfd.FileName);
                }
            }
        }

        private void btn_OpenProj_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "DeadLine (*.dlproj)|*.dlproj"};
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                Deserealize(ofd.FileName);

                UpdateAll();
                pnl_CreatePanel.SelectedTab = page_ProjInfo;
            }
        }

        private void Serealize(string fileName)
        {
            try
            {
                using FileStream fs = new FileStream(fileName, FileMode.Create);
                JsonSerializer.Serialize(fs, project, new JsonSerializerOptions() { WriteIndented = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Deserealize(string path)
        {
            try
            {
                using FileStream fs = new FileStream(path, FileMode.Open);
                project = JsonSerializer.Deserialize<Project>(fs, new JsonSerializerOptions() { WriteIndented = true });
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}