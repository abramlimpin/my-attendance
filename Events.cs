using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyAttendance
{
    public delegate void StatusChangedEventHandler(object sender, StatusChangedEventArgs e);

    public class StatusChangedEventArgs
    {
        public StatusChangedEventArgs(bool status)
        {
            this.Status = status;
        }
        public bool Status { get; set; }
    }
}
