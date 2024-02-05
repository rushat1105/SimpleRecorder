namespace Geming.SimpleRec
{
    partial class MainForm
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
            if (disposing)
            {
                _sndrec.Dispose();
                _sndplay.Dispose();
                _timer.Dispose();
                if (components != null)
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.recordToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lengthToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.recordingsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.playToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.stopToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.locationToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recordToolStripButton,
            this.toolStripSeparator1,
            this.lengthToolStripLabel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(262, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // recordToolStripButton
            // 
            this.recordToolStripButton.Image = global::Geming.SimpleRec.Properties.Resources.RecordHS;
            this.recordToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.recordToolStripButton.Name = "recordToolStripButton";
            this.recordToolStripButton.Size = new System.Drawing.Size(121, 22);
            this.recordToolStripButton.Text = "&Start Recording";
            this.recordToolStripButton.Click += new System.EventHandler(this.recordToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // lengthToolStripLabel
            // 
            this.lengthToolStripLabel.Name = "lengthToolStripLabel";
            this.lengthToolStripLabel.Size = new System.Drawing.Size(56, 22);
            this.lengthToolStripLabel.Text = "00:00:00";
            // 
            // recordingsListView
            // 
            this.recordingsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.recordingsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recordingsListView.FullRowSelect = true;
            this.recordingsListView.GridLines = true;
            this.recordingsListView.HideSelection = false;
            this.recordingsListView.Location = new System.Drawing.Point(0, 25);
            this.recordingsListView.MultiSelect = false;
            this.recordingsListView.Name = "recordingsListView";
            this.recordingsListView.ShowItemToolTips = true;
            this.recordingsListView.Size = new System.Drawing.Size(262, 229);
            this.recordingsListView.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.recordingsListView.TabIndex = 1;
            this.recordingsListView.UseCompatibleStateImageBehavior = false;
            this.recordingsListView.View = System.Windows.Forms.View.Details;
            this.recordingsListView.SelectedIndexChanged += new System.EventHandler(this.recordingsListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Date";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Length";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 75;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripButton,
            this.stopToolStripButton,
            this.toolStripSeparator2,
            this.locationToolStripLabel,
            this.toolStripSeparator3,
            this.saveToolStripButton,
            this.deleteToolStripButton});
            this.toolStrip2.Location = new System.Drawing.Point(0, 229);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(262, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // playToolStripButton
            // 
            this.playToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.playToolStripButton.Image = global::Geming.SimpleRec.Properties.Resources.PlayHS;
            this.playToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.playToolStripButton.Name = "playToolStripButton";
            this.playToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.playToolStripButton.Text = "Play";
            this.playToolStripButton.Click += new System.EventHandler(this.playToolStripButton_Click);
            // 
            // stopToolStripButton
            // 
            this.stopToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopToolStripButton.Image = global::Geming.SimpleRec.Properties.Resources.StopHS;
            this.stopToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopToolStripButton.Name = "stopToolStripButton";
            this.stopToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.stopToolStripButton.Text = "Stop";
            this.stopToolStripButton.Click += new System.EventHandler(this.stopToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // locationToolStripLabel
            // 
            this.locationToolStripLabel.Name = "locationToolStripLabel";
            this.locationToolStripLabel.Size = new System.Drawing.Size(121, 22);
            this.locationToolStripLabel.Text = "00:00:00 of 00:00:00";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = global::Geming.SimpleRec.Properties.Resources.SaveHS;
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // deleteToolStripButton
            // 
            this.deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteToolStripButton.Image = global::Geming.SimpleRec.Properties.Resources.DeleteHS;
            this.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripButton.Name = "deleteToolStripButton";
            this.deleteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deleteToolStripButton.Text = "Delete";
            this.deleteToolStripButton.Click += new System.EventHandler(this.deleteToolStripButton_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "wav";
            this.saveFileDialog.Filter = "Waveform (Audio) Files (*.wav)|*.wav";
            this.saveFileDialog.RestoreDirectory = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 254);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.recordingsListView);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton recordToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lengthToolStripLabel;
        private System.Windows.Forms.ListView recordingsListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton playToolStripButton;
        private System.Windows.Forms.ToolStripButton stopToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel locationToolStripLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;

    }
}

