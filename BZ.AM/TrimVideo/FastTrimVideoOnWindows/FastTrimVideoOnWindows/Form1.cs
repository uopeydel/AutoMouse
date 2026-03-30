using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FastTrimVideoOnWindows
{
    public partial class FastVideoTrim : Form
    {
        public FastVideoTrim()
        {
            InitializeComponent();
        }

        private void btnSelectFileToTrim_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "MP4 files (*.mp4)|*.mp4|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    tbxSourceFilePath.Text = selectedFilePath;
                }
            }
        }

        private void btnDestinationSelect_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFolderPath = folderBrowserDialog.SelectedPath;
                    tbxDestination.Text = selectedFolderPath;
                }
            }
        }

        private void btnStartTrimVideo_Click(object sender, EventArgs e)
        {
            try
            {
                var timeStartMinute = startMinute.Value;
                var timeStartSecond = startSecond.Value;
                var startTimeSumSecond = (timeStartMinute * 60) + timeStartSecond;

                var endStartMinute = endMinute.Value;
                var endStartSecond = endSecond.Value;
                var endTimeSumSecond = (endStartMinute * 60) + endStartSecond;

                if (startTimeSumSecond - endTimeSumSecond >= 0)
                {
                    MessageBox.Show("End time must more than start time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                TimeSpan startTime = TimeSpan.FromSeconds((double)startTimeSumSecond);
                TimeSpan endTime = TimeSpan.FromSeconds((double)endTimeSumSecond);
                var durationSecond = endTimeSumSecond - startTimeSumSecond;
                TimeSpan duration = TimeSpan.FromSeconds((double)durationSecond);

                string fileName1 = Path.GetFileName(tbxSourceFilePath.Text);
                var onlyFileNameWithoutExtension = fileName1.Split('.');
                var outputFilePath = onlyFileNameWithoutExtension[0] + "_trimvideo_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".mp4";
                var outputPath = Path.Combine(tbxDestination.Text, outputFilePath);
                string ffmpegArgs = $"-i \"{tbxSourceFilePath.Text}\" -ss {startTime} -t {duration} -c:v copy -c:a copy \"{outputPath}\"";

                // Execute the ffmpeg command
                ExecuteCommand("ffmpeg", ffmpegArgs);

                Process.Start("explorer.exe", tbxDestination.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        static void ExecuteCommand(string command, string arguments)
        {
            ProcessStartInfo psi = new ProcessStartInfo(command, arguments)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true
            };

            using (Process process = new Process())
            {
                process.StartInfo = psi;
                process.Start();
                process.WaitForExit();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                if (!string.IsNullOrEmpty(output))
                    Console.WriteLine("Output: " + output);

                if (!string.IsNullOrEmpty(error))
                    Console.WriteLine("Error: " + error);
            }
        }
    }
}
