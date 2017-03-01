namespace MyAttendance
{
    partial class Verification
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNote = new System.Windows.Forms.TextBox();
            this.buttonRecord = new System.Windows.Forms.Button();
            this.verificationUserControl = new MyAttendance.VerificationUserControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 316);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Note:";
            // 
            // textBoxNote
            // 
            this.textBoxNote.Location = new System.Drawing.Point(16, 335);
            this.textBoxNote.Multiline = true;
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.Size = new System.Drawing.Size(252, 56);
            this.textBoxNote.TabIndex = 13;
            // 
            // buttonRecord
            // 
            this.buttonRecord.Location = new System.Drawing.Point(287, 335);
            this.buttonRecord.Name = "buttonRecord";
            this.buttonRecord.Size = new System.Drawing.Size(248, 56);
            this.buttonRecord.TabIndex = 10;
            this.buttonRecord.Text = "&Record";
            this.buttonRecord.UseVisualStyleBackColor = true;
            // 
            // verificationUserControl
            // 
            this.verificationUserControl.IsVerificationComplete = false;
            this.verificationUserControl.Location = new System.Drawing.Point(18, 10);
            this.verificationUserControl.Name = "verificationUserControl";
            this.verificationUserControl.Size = new System.Drawing.Size(263, 303);
            this.verificationUserControl.TabIndex = 15;
            // 
            // Verification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 408);
            this.Controls.Add(this.verificationUserControl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNote);
            this.Controls.Add(this.buttonRecord);
            this.Name = "Verification";
            this.Text = "Verification";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNote;
        private System.Windows.Forms.Button buttonRecord;
        private VerificationUserControl verificationUserControl;
    }
}