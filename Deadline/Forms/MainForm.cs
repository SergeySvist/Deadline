namespace Deadline
{
    public partial class MainForm : Form
    {
        bool isDragging = false;
        Point startPoint;
        Size tmpsz;
        Point tmppoint;
        public MainForm()
        {
            InitializeComponent();
            tmpsz = new(Width, Height);
            tmppoint = new(this.Location.X, this.Location.Y);
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
            if (this.Size == new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height))//this.WindowState == FormWindowState.Maximized)
            {
                this.Size = new Size(tmpsz.Width, tmpsz.Height);
                this.Location = new Point(tmppoint.X, tmppoint.Y);
                
                //this.WindowState = FormWindowState.Normal;
            }
            else
            {
                tmppoint = new(this.Location.X, this.Location.Y);
                tmpsz = new(Width, Height);
                this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.X, Screen.PrimaryScreen.WorkingArea.Y);
                //this.WindowState = FormWindowState.Maximized;
            }
        }

        private void btn_Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pnl_Controls_MouseHover(object sender, EventArgs e)
        {
            lbl_CreateTaskShow.Visible = true;
            pnl_Controls.Width = pnl_Controls.MaximumSize.Width;
        }

        private void pnl_Controls_MouseLeave(object sender, EventArgs e)
        {
            lbl_CreateTaskShow.Visible = false;
            pnl_Controls.Width = pnl_Controls.MinimumSize.Width;
        }
    }
}