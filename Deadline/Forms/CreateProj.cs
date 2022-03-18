using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deadline
{
    public partial class CreateProj : Form
    {
        public new string  Text { get; set; }

        public CreateProj()
        {
            InitializeComponent();
            Text = "";
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            Text = txt_ProjName.Text;
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateProj_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btn_Ok_Click(sender, e);
            if (e.KeyData == Keys.Escape)
                btn_Cancel_Click(sender, e);
        }

    }
}
