using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyAttendance
{
    public partial class Verification : Form
    {
        public Verification()
        {
            InitializeComponent();
            ValidateUser();
        }


        void ValidateUser()
        {
            using (SqlConnection con = new SqlConnection(Helper.GetConnection()))
            {
                con.Open();
                string query = @"SELECT UserID, Thumb FROM Users";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader data = cmd.ExecuteReader())
                    {

                        while (data.Read())
                        {
                            byte[] fingerPrint = (byte[])data["Thumb"];
                            verificationUserControl.Samples.Add(new DPFP.Template(new MemoryStream(fingerPrint)), null);
                        }
                    }
                }
            }
        }
    }
}
