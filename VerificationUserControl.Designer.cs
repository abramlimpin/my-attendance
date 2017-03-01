namespace MyAttendance
{
    partial class VerificationUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ClearFPSamples = new System.Windows.Forms.Button();
            this.Prompt = new System.Windows.Forms.Label();
            this.FingerPrintPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FingerPrintPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // ClearFPSamples
            // 
            this.ClearFPSamples.Location = new System.Drawing.Point(154, 273);
            this.ClearFPSamples.Name = "ClearFPSamples";
            this.ClearFPSamples.Size = new System.Drawing.Size(103, 23);
            this.ClearFPSamples.TabIndex = 22;
            this.ClearFPSamples.Text = "Clear fingerprint samples";
            this.ClearFPSamples.UseVisualStyleBackColor = true;
            this.ClearFPSamples.Click += new System.EventHandler(this.ClearFPSamples_Click);
            // 
            // Prompt
            // 
            this.Prompt.AutoSize = true;
            this.Prompt.Location = new System.Drawing.Point(6, 250);
            this.Prompt.Name = "Prompt";
            this.Prompt.Size = new System.Drawing.Size(37, 13);
            this.Prompt.TabIndex = 21;
            this.Prompt.Text = "Status";
            // 
            // FingerPrintPicture
            // 
            this.FingerPrintPicture.BackColor = System.Drawing.SystemColors.Window;
            this.FingerPrintPicture.Location = new System.Drawing.Point(9, 7);
            this.FingerPrintPicture.Name = "FingerPrintPicture";
            this.FingerPrintPicture.Size = new System.Drawing.Size(248, 240);
            this.FingerPrintPicture.TabIndex = 20;
            this.FingerPrintPicture.TabStop = false;
            // 
            // VerificationUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ClearFPSamples);
            this.Controls.Add(this.Prompt);
            this.Controls.Add(this.FingerPrintPicture);
            this.Name = "VerificationUserControl";
            this.Size = new System.Drawing.Size(263, 303);
            ((System.ComponentModel.ISupportInitialize)(this.FingerPrintPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ClearFPSamples;
        private System.Windows.Forms.Label Prompt;
        private System.Windows.Forms.PictureBox FingerPrintPicture;
    }
}
