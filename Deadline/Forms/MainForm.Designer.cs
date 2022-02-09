namespace Deadline
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainIcon = new System.Windows.Forms.PictureBox();
            this.lbl_Deadline = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Max = new System.Windows.Forms.Button();
            this.btn_Min = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_TaskList = new System.Windows.Forms.Panel();
            this.pnl_ChooseMain = new System.Windows.Forms.Panel();
            this.pnl_ProjInfo = new System.Windows.Forms.Panel();
            this.pnl_Controls = new System.Windows.Forms.Panel();
            this.btn_OpenProj = new System.Windows.Forms.Button();
            this.btn_CreateProj = new System.Windows.Forms.Button();
            this.lbl_CreateTaskShow = new System.Windows.Forms.Label();
            this.btn_CreateTask = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainIcon)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnl_Controls.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainIcon
            // 
            this.MainIcon.Image = global::Deadline.Properties.Resources.fire;
            this.MainIcon.Location = new System.Drawing.Point(10, 7);
            this.MainIcon.Name = "MainIcon";
            this.MainIcon.Size = new System.Drawing.Size(30, 30);
            this.MainIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.MainIcon.TabIndex = 1;
            this.MainIcon.TabStop = false;
            this.MainIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MainIcon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MainIcon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            // 
            // lbl_Deadline
            // 
            this.lbl_Deadline.AutoSize = true;
            this.lbl_Deadline.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_Deadline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_Deadline.Location = new System.Drawing.Point(46, 7);
            this.lbl_Deadline.Name = "lbl_Deadline";
            this.lbl_Deadline.Size = new System.Drawing.Size(114, 32);
            this.lbl_Deadline.TabIndex = 2;
            this.lbl_Deadline.Text = "DeadLine";
            this.lbl_Deadline.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.lbl_Deadline.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.lbl_Deadline.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.AutoSize = true;
            this.btn_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(22)))));
            this.btn_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Image = global::Deadline.Properties.Resources.exit;
            this.btn_Close.Location = new System.Drawing.Point(1241, 11);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(26, 26);
            this.btn_Close.TabIndex = 3;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Max
            // 
            this.btn_Max.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Max.AutoSize = true;
            this.btn_Max.FlatAppearance.BorderSize = 0;
            this.btn_Max.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Max.Image = global::Deadline.Properties.Resources.max;
            this.btn_Max.Location = new System.Drawing.Point(1209, 11);
            this.btn_Max.Name = "btn_Max";
            this.btn_Max.Size = new System.Drawing.Size(26, 26);
            this.btn_Max.TabIndex = 4;
            this.btn_Max.UseVisualStyleBackColor = true;
            this.btn_Max.Click += new System.EventHandler(this.btn_Max_Click);
            // 
            // btn_Min
            // 
            this.btn_Min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Min.AutoSize = true;
            this.btn_Min.FlatAppearance.BorderSize = 0;
            this.btn_Min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Min.Image = global::Deadline.Properties.Resources.min;
            this.btn_Min.Location = new System.Drawing.Point(1177, 11);
            this.btn_Min.Name = "btn_Min";
            this.btn_Min.Size = new System.Drawing.Size(26, 26);
            this.btn_Min.TabIndex = 5;
            this.btn_Min.UseVisualStyleBackColor = true;
            this.btn_Min.Click += new System.EventHandler(this.btn_Min_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(37)))));
            this.panel1.Controls.Add(this.pnl_TaskList);
            this.panel1.Controls.Add(this.pnl_ChooseMain);
            this.panel1.Controls.Add(this.pnl_ProjInfo);
            this.panel1.Controls.Add(this.pnl_Controls);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 45);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20);
            this.panel1.Size = new System.Drawing.Size(1260, 665);
            this.panel1.TabIndex = 6;
            // 
            // pnl_TaskList
            // 
            this.pnl_TaskList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_TaskList.Location = new System.Drawing.Point(90, 70);
            this.pnl_TaskList.Name = "pnl_TaskList";
            this.pnl_TaskList.Size = new System.Drawing.Size(899, 575);
            this.pnl_TaskList.TabIndex = 3;
            // 
            // pnl_ChooseMain
            // 
            this.pnl_ChooseMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(22)))));
            this.pnl_ChooseMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_ChooseMain.Location = new System.Drawing.Point(90, 20);
            this.pnl_ChooseMain.Name = "pnl_ChooseMain";
            this.pnl_ChooseMain.Size = new System.Drawing.Size(899, 50);
            this.pnl_ChooseMain.TabIndex = 2;
            // 
            // pnl_ProjInfo
            // 
            this.pnl_ProjInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(22)))));
            this.pnl_ProjInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_ProjInfo.Location = new System.Drawing.Point(989, 20);
            this.pnl_ProjInfo.Name = "pnl_ProjInfo";
            this.pnl_ProjInfo.Size = new System.Drawing.Size(251, 625);
            this.pnl_ProjInfo.TabIndex = 1;
            // 
            // pnl_Controls
            // 
            this.pnl_Controls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(22)))));
            this.pnl_Controls.Controls.Add(this.btn_OpenProj);
            this.pnl_Controls.Controls.Add(this.btn_CreateProj);
            this.pnl_Controls.Controls.Add(this.lbl_CreateTaskShow);
            this.pnl_Controls.Controls.Add(this.btn_CreateTask);
            this.pnl_Controls.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_Controls.Location = new System.Drawing.Point(20, 20);
            this.pnl_Controls.MaximumSize = new System.Drawing.Size(220, 0);
            this.pnl_Controls.MinimumSize = new System.Drawing.Size(70, 0);
            this.pnl_Controls.Name = "pnl_Controls";
            this.pnl_Controls.Padding = new System.Windows.Forms.Padding(10, 20, 10, 20);
            this.pnl_Controls.Size = new System.Drawing.Size(70, 625);
            this.pnl_Controls.TabIndex = 0;
            this.pnl_Controls.MouseLeave += new System.EventHandler(this.pnl_Controls_MouseLeave);
            this.pnl_Controls.MouseHover += new System.EventHandler(this.pnl_Controls_MouseHover);
            // 
            // btn_OpenProj
            // 
            this.btn_OpenProj.FlatAppearance.BorderSize = 0;
            this.btn_OpenProj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OpenProj.Image = global::Deadline.Properties.Resources.openproj;
            this.btn_OpenProj.Location = new System.Drawing.Point(21, 129);
            this.btn_OpenProj.Margin = new System.Windows.Forms.Padding(11);
            this.btn_OpenProj.Name = "btn_OpenProj";
            this.btn_OpenProj.Size = new System.Drawing.Size(26, 26);
            this.btn_OpenProj.TabIndex = 3;
            this.btn_OpenProj.UseVisualStyleBackColor = true;
            // 
            // btn_CreateProj
            // 
            this.btn_CreateProj.FlatAppearance.BorderSize = 0;
            this.btn_CreateProj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CreateProj.Image = global::Deadline.Properties.Resources.createproj;
            this.btn_CreateProj.Location = new System.Drawing.Point(21, 81);
            this.btn_CreateProj.Margin = new System.Windows.Forms.Padding(11);
            this.btn_CreateProj.Name = "btn_CreateProj";
            this.btn_CreateProj.Size = new System.Drawing.Size(26, 26);
            this.btn_CreateProj.TabIndex = 2;
            this.btn_CreateProj.UseVisualStyleBackColor = true;
            // 
            // lbl_CreateTaskShow
            // 
            this.lbl_CreateTaskShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_CreateTaskShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lbl_CreateTaskShow.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_CreateTaskShow.ForeColor = System.Drawing.Color.White;
            this.lbl_CreateTaskShow.Location = new System.Drawing.Point(60, 556);
            this.lbl_CreateTaskShow.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lbl_CreateTaskShow.Name = "lbl_CreateTaskShow";
            this.lbl_CreateTaskShow.Size = new System.Drawing.Size(150, 49);
            this.lbl_CreateTaskShow.TabIndex = 1;
            this.lbl_CreateTaskShow.Text = "CreateTask";
            this.lbl_CreateTaskShow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_CreateTaskShow.Visible = false;
            // 
            // btn_CreateTask
            // 
            this.btn_CreateTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_CreateTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_CreateTask.FlatAppearance.BorderSize = 0;
            this.btn_CreateTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CreateTask.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_CreateTask.ForeColor = System.Drawing.Color.White;
            this.btn_CreateTask.Location = new System.Drawing.Point(11, 556);
            this.btn_CreateTask.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.btn_CreateTask.Name = "btn_CreateTask";
            this.btn_CreateTask.Size = new System.Drawing.Size(49, 49);
            this.btn_CreateTask.TabIndex = 0;
            this.btn_CreateTask.Text = "+";
            this.btn_CreateTask.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btn_CreateTask.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(22)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Min);
            this.Controls.Add(this.btn_Max);
            this.Controls.Add(this.lbl_Deadline);
            this.Controls.Add(this.MainIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(10, 45, 10, 10);
            this.Text = "Deadline";
            this.DoubleClick += new System.EventHandler(this.btn_Max_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.MainIcon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnl_Controls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PictureBox MainIcon;
        private Label lbl_Deadline;
        private Button btn_Close;
        private Button btn_Max;
        private Button btn_Min;
        private Panel panel1;
        private Panel pnl_Controls;
        private Panel pnl_ProjInfo;
        private Panel pnl_TaskList;
        private Panel pnl_ChooseMain;
        private Button btn_CreateTask;
        private Label lbl_CreateTaskShow;
        private Button btn_CreateProj;
        private Button btn_OpenProj;
    }
}