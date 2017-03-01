using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyAttendance
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registration form = new Registration();
            form.Show();
        }

        private void attendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Verification form = new Verification();
            form.Show();
        }
    }
}
