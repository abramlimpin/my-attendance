using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DPFP.Error;
using System.IO;
using System.Data.SqlClient;

namespace MyAttendance
{
    public partial class RegistrationUserControl : UserControl, IComponent, DPFP.Capture.EventHandler
    {
        private bool isRegistrationComplete = false;
        public bool IsRegistrationComplete
        {
            get { return isRegistrationComplete; }
            private set
            {
                this.isRegistrationComplete = value;
                if (this.RegistrationCompletedStatusChanged != null)
                {
                    RegistrationCompletedStatusChanged(this, new StatusChangedEventArgs(value));
                }
            }
        }

        public event StatusChangedEventHandler RegistrationCompletedStatusChanged;

        public byte[] FingerPrint;

        private DPFP.Capture.Capture Capturer;
        private DPFP.Processing.Enrollment Enroller;

        public RegistrationUserControl()
        {
            InitializeComponent();
            this.Load += new EventHandler(FingerPrintRegistrationUserControl_Load);
            this.HandleDestroyed += new EventHandler(FingerPrintRegistrationUserControl_HandleDestroyed);
        }

        #region FingerPrint Handlers

        protected virtual void Process(DPFP.Sample Sample)
        {
            DrawPicture(FingerPrintUtility.ConvertSampleToBitmap(Sample));
            try
            {
                DPFP.FeatureSet features = FingerPrintUtility.ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);
                if (features != null)
                {
                    try
                    {
                        SetPrompt("The fingerprint feature set was created.");
                        SetPanelColor(System.Drawing.SystemColors.Control);
                        Enroller.AddFeatures(features);		// Add feature set to template.
                    }
                    catch (SDKException ex)
                    {
                        SetPrompt(ex.Message);
                    }
                    finally
                    {
                        UpdateSamplesNeeded();

                        // Check if template has been created.
                        switch (Enroller.TemplateStatus)
                        {
                            case DPFP.Processing.Enrollment.Status.Ready:	// report success and stop capturing
                                OnTemplateCollect(Enroller.Template);

                                SetPrompt("Done.");
                                Stop();
                                break;

                            case DPFP.Processing.Enrollment.Status.Failed:	// report failure and restart capturing
                                Enroller.Clear();
                                Stop();
                                UpdateSamplesNeeded();
                                OnTemplateCollect(null);
                                Start();
                                break;
                        }
                    }
                }
                else
                {
                    SetPrompt("Can't recognize as a fingerprint.");
                    UpdateSamplesNeeded();
                }
            }
            catch (Exception)
            {
                SetPrompt("Can't recognize as a fingerprint.");
                UpdateSamplesNeeded();
            }

        }

        protected virtual void Init()
        {
            try
            {
                Capturer = new DPFP.Capture.Capture();
                Enroller = new DPFP.Processing.Enrollment();
                this.TotalFeaturesNeeded = Enroller.FeaturesNeeded;

                if (null != Capturer)
                {
                    Capturer.EventHandler = this;
                }
                else
                {
                    MessageBox.Show("Can't initiate capture operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Can't initiate capture operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void Start()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StartCapture();
                    SetPrompt("Give fingerprint samples.");
                }
                catch
                {
                    SetPrompt("Can't initiate capture!");
                }
            }
        }

        protected void Stop()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StopCapture();
                }
                catch
                {
                    SetPrompt("Can't terminate capture!");
                }
            }
        }

        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
            SetPrompt("Fingerprint scan complete.");
            Process(Sample);
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            SetPrompt("Finger removed.");
            SetPanelColor(System.Drawing.SystemColors.Control);
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {

            SetPrompt("Finger touched.");
            SetPanelColor(Color.Red);
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            SetPrompt("Fingerprint reader connected.");
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            SetPrompt("Fingerprint reader disconnected.");
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
            if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
                SetPrompt("Good scan.");
            else
                SetPrompt("Poor scan.");
        }

        private void OnTemplateCollect(DPFP.Template template)
        {
            if (template != null)
            {
                this.Invoke(new Function(delegate ()
                {
                    MemoryStream s = new MemoryStream();
                    template.Serialize(s);
                    this.FingerPrint = s.ToArray();
                    this.IsRegistrationComplete = true;


                    using (SqlConnection con = new SqlConnection(Helper.GetConnection()))
                    {
                        con.Open();
                        string query = @"INSERT INTO Users VALUES (@FirstName,
                            @LastName, @Thumb, @DateAdded)";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@FirstName", "");
                            cmd.Parameters.AddWithValue("@LastName", "");
                            cmd.Parameters.AddWithValue("@Thumb", FingerPrint);
                            cmd.Parameters.AddWithValue("@DateAdded", DateTime.Now);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Added!");
                        }
                    }
                }));
            }
        }

        #endregion

        #region Form Event Handlers:
        private void FingerPrintRegistrationUserControl_Load(object sender, EventArgs e)
        {
            Init();
            Start();
            UpdateSamplesNeeded();
        }

        private void FingerPrintRegistrationUserControl_HandleDestroyed(object sender, EventArgs e)
        {
            Stop();
        }

        #endregion

        delegate void Function();

        private void UpdateSamplesNeeded()
        {
            this.Invoke(new Function(delegate ()
            {
                SamplesNeeded.Text = String.Format("Samples collected : {0}/{1}", this.TotalFeaturesNeeded - Enroller.FeaturesNeeded, this.TotalFeaturesNeeded);
            }));
        }

        private void SetPrompt(string prompt)
        {
            this.Invoke(new Function(delegate ()
            {
                Prompt.Text = prompt;
            }));
        }

        private void SetPanelColor(Color color)
        {
            this.Invoke(new Function(delegate ()
            {
                this.BackColor = color;
            }));
        }

        private void DrawPicture(Bitmap bitmap)
        {
            this.Invoke(new Function(delegate ()
            {
                FingerPrintPicture.Image = new Bitmap(bitmap, FingerPrintPicture.Size);	// fit the image into the picture box
            }));
        }

        private uint TotalFeaturesNeeded;

        private void ClearFPSamples_Click(object sender, EventArgs e)
        {
            this.Reset();
        }

        public void Reset()
        {
            Enroller.Clear();
            this.IsRegistrationComplete = false;
            this.FingerPrint = null;
            UpdateSamplesNeeded();
            SetPrompt("Give fingerprint samples again.");
            FingerPrintPicture.Image = null;
            Start();
        }
    }
}