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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
            this.fingerPrintRegUserControl.RegistrationCompletedStatusChanged += new StatusChangedEventHandler(fingerPrintRegUserControl_RegistrationCompleted);
        }

        private void fingerPrintRegUserControl_RegistrationCompleted(object sender, StatusChangedEventArgs e)
        {

        }

        private void registerButton_Click(object sender, EventArgs e)
        {

        }
    }
}
