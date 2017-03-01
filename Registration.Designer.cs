namespace MyAttendance
{
    partial class Registration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxEmpName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fingerPrintRegUserControl = new MyAttendance.RegistrationUserControl();
            this.SuspendLayout();
            // 
            // textBoxEmpName
            // 
            this.textBoxEmpName.Location = new System.Drawing.Point(12, 25);
            this.textBoxEmpName.Name = "textBoxEmpName";
            this.textBoxEmpName.Size = new System.Drawing.Size(251, 20);
            this.textBoxEmpName.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Employee Name :";
            // 
            // fingerPrintRegUserControl
            // 
            this.fingerPrintRegUserControl.Location = new System.Drawing.Point(3, 51);
            this.fingerPrintRegUserControl.Name = "fingerPrintRegUserControl";
            this.fingerPrintRegUserControl.Size = new System.Drawing.Size(263, 303);
            this.fingerPrintRegUserControl.TabIndex = 22;
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 387);
            this.Controls.Add(this.fingerPrintRegUserControl);
            this.Controls.Add(this.textBoxEmpName);
            this.Controls.Add(this.label1);
            this.Name = "Registration";
            this.Text = "Registration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxEmpName;
        private System.Windows.Forms.Label label1;
        private RegistrationUserControl fingerPrintRegUserControl;
    }
}