/*--------------------------------------------------------
 * MainForm.cs - (c) Mohammad Elsheimy, 2010
 * http://JustLikeAMagic.WordPress.com
  --------------------------------------------------------*/

using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Helpers = Geming.SimpleRec.HelperMethods;
using Res = Geming.SimpleRec.Properties.Resources;

namespace Geming.SimpleRec
{
    public partial class MainForm : Form
    {
        private SndRec _sndrec = SndRec.Instance;
        private SndPlay _sndplay = SndPlay.Instance;
        private bool _recording, _playing, _paused;
        private System.Threading.Timer _timer;
        private DateTime _startDate;

        public MainForm()
        {
            InitializeComponent();

            this.Text = Application.ProductName;
            this.saveFileDialog.Title = Application.ProductName + " - Save As";
            _timer = new System.Threading.Timer(TimerProc);
            SetButtonState();
        }

        private void StartTimer()
        {
            _timer.Change(0, 500);
        }
        private void StopTimer()
        {
            _timer.Change(Timeout.Infinite, 500);
        }

        private void recordToolStripButton_Click(object sender, EventArgs e)
        {
            if (_recording)
            {
                try
                {
                    string path;

                    path = Helpers.GetNewRecording(Helpers.GetTimeStr(_sndrec.Length).Replace(":", string.Empty));

                    _sndrec.Stop();

                    StopTimer();
                    _recording = false;
                    SetButtonState();

                    _sndrec.Save(path);
                    AddRecording(path);

                    _sndrec.Close();
                }
                catch (SndException ex)
                {
                    Helpers.ErrMsgBox(this, ex.Message);
                }
            }
            else
            {
                try
                {
                    if (!_sndrec.IsInitialized)
                        _sndrec.Initialize();

                    _sndrec.Start();
                    _startDate = DateTime.Now;
                    StartTimer();

                    _recording = true;
                    SetButtonState();
                }
                catch (SndException ex)
                {
                    Helpers.ErrMsgBox(this, ex.Message);
                }
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.recordingsListView.BeginUpdate();

            string[] arr = Helpers.GetRecordings();
            foreach (string str in arr)
                AddRecording(str);

            this.recordingsListView.EndUpdate();
            this.Cursor = Cursors.Default;
        }


        private void recordingsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonState();
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            if (Helpers.AskMsgBox(this, Res.MsgBox_Delete) == DialogResult.Yes)
            {
                ListViewItem itm = this.recordingsListView.SelectedItems[0];
                string path = itm.Tag.ToString();

                try
                {
                    File.Delete(path);
                    itm.Remove();
                }
                catch (FileNotFoundException) { itm.Remove(); }
                catch (IOException ex)
                {
                    Helpers.ErrMsgBox(this, ex.Message);
                }
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    File.Copy(this.recordingsListView.SelectedItems[0].Tag.ToString(), this.saveFileDialog.FileName);
                }
                catch (IOException ex)
                {
                    Helpers.ErrMsgBox(this, ex.Message);
                }
            }
        }

        private void playToolStripButton_Click(object sender, EventArgs e)
        {
            if (_playing && _paused)    // Resume
            {
                try
                {
                    _sndplay.Resume();

                    _startDate = DateTime.Now;
                    StartTimer();
                    _paused = false;
                    SetButtonState();
                }
                catch (SndException ex)
                {
                    Helpers.ErrMsgBox(this, ex.Message);
                }
            }
            else if (_playing)      // Pause
            {
                try
                {
                    _sndplay.Pause();

                    StopTimer();
                    _paused = true;
                    SetButtonState();
                }
                catch (SndException ex)
                {
                    Helpers.ErrMsgBox(this, ex.Message);
                }
            }
            else                    // Play
            {
                try
                {
                    string filename = this.recordingsListView.SelectedItems[0].Tag.ToString();

                    if (!_sndplay.IsInitialized)
                        _sndplay.Initialize(filename, this.Handle);

                    _sndplay.Start();
                    _startDate = DateTime.Now;
                    StartTimer();

                    _playing = true;
                    SetButtonState();
                }
                catch (SndException ex)
                {
                    Helpers.ErrMsgBox(this, ex.Message);
                }

            }
        }

        private void SetButtonState()
        {
            bool bSelected = this.recordingsListView.SelectedItems.Count > 0;

            this.recordToolStripButton.Text = _recording ? "&Stop Recording" : "&Sart Recording";
            this.recordToolStripButton.Image = _recording ? Res.PauseRecorderHS : Res.RecordHS;
            this.recordToolStripButton.Enabled = !_playing;

            this.recordingsListView.Enabled = !_recording && !_playing;

            this.playToolStripButton.Enabled = !_recording && bSelected;
            this.stopToolStripButton.Enabled = _playing;
            this.saveToolStripButton.Enabled = !_recording && bSelected && !_playing;
            this.deleteToolStripButton.Enabled = !_recording && bSelected && !_playing;

            if ((_playing && _paused) || (!_recording && !_playing))
            {
                this.playToolStripButton.Text = "Play";
                this.playToolStripButton.Image = Res.PlayHS;
            }
            else
            {
                this.playToolStripButton.Text = "Pause";
                this.playToolStripButton.Image = Res.PauseHS;
            }
        }

        private void TimerProc(object obj)
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(SetTime));
            else
                SetTime();
        }

        private void SetTime()
        {
            if (_recording)
            {
                this.lengthToolStripLabel.Text = Helpers.GetTimeStr(_sndrec.Length);
            }
            else
            {
                string len = Helpers.GetTimeStr(_sndplay.Length);
                string pos = Helpers.GetTimeStr(_sndplay.Position);

                this.locationToolStripLabel.Text = String.Format(CultureInfo.InvariantCulture, "{0} of {1}", pos, len);

                if (_sndplay.Position == _sndplay.Length)
                {
                    try
                    {
                        StopTimer();
                        _playing = _paused = false;
                        SetButtonState();
                        _sndplay.Close();
                    }
                    catch (SndException ex)
                    {
                        Helpers.ErrMsgBox(this, ex.Message);
                    }
                }
            }
        }

        private void AddRecording(string path)
        {
            string name = Path.GetFileNameWithoutExtension(path);
            string[] vals = name.Split('-');
            DateTime date = new DateTime(
                int.Parse(vals[0].Substring(4, 4), CultureInfo.InvariantCulture),
                int.Parse(vals[0].Substring(0, 2), CultureInfo.InvariantCulture),
                int.Parse(vals[0].Substring(2, 2), CultureInfo.InvariantCulture),
                int.Parse(vals[1].Substring(0, 2), CultureInfo.InvariantCulture),
                int.Parse(vals[1].Substring(2, 2), CultureInfo.InvariantCulture),
                int.Parse(vals[1].Substring(4, 2), CultureInfo.InvariantCulture));
            string length = string.Format(CultureInfo.InvariantCulture, "{0:D2}:{1:D2}:{2:D2}",
                vals[2].Substring(0, 2),
                vals[2].Substring(2, 2),
                vals[2].Substring(4, 2));

            ListViewItem itm = new ListViewItem(date.ToShortDateString() + " " + date.ToLongTimeString());
            itm.SubItems.Add(length);
            itm.Tag = path;
            this.recordingsListView.Items.Add(itm);
        }

        private void stopToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                _sndplay.Stop();

                StopTimer();
                _playing = _paused = false;
                SetButtonState();

                _sndplay.Close();
            }
            catch (SndException ex)
            {
                Helpers.ErrMsgBox(this, ex.Message);
            }

        }
    }

}