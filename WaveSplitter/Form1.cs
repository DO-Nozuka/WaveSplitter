using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaveSplitter
{
    public partial class Form1 : Form
    {
        List<WaveFile> results;

        public Form1()
        {
            InitializeComponent();

            string[] files = Environment.GetCommandLineArgs();

            if(files.Length == 2)
            {
                OpenFilePath.Text = files[1];
                SplitFile();
                SaveFileFunc();

                Close();
            }
        }


        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void SplitTest_Click(object sender, EventArgs e)
        {
            SplitFile();
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            SaveFileFunc();
        }


        private void OpenFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Wave files (*.wav)|*.wav";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    OpenFilePath.Text = openFileDialog.FileName;
                    SaveFilePath.Text = Path.GetDirectoryName(OpenFilePath.Text) + Path.GetFileNameWithoutExtension(OpenFilePath.Text) + $"\\" + Path.GetFileNameWithoutExtension(OpenFilePath.Text) + $"_XXX.wav";
                }
            }
        }
        private void SplitFile()
        {
            InputOptions inputOptions = new InputOptions();

            inputOptions.ThresholdLevel = (int)ThresholdLevel.Value;
            inputOptions.ThresholdTime = (int)ThresholdTime.Value;

            if(OpenFilePath.Text == "")
            {
                return;
            }

            results = WaveSplitter.SplitWaves(OpenFilePath.Text, inputOptions, (int)ThresholdLevel.Value);
        }

        private void SaveFileFunc()
        {
            if (results != null)
            {
                string saveFolerPath = Path.GetDirectoryName(OpenFilePath.Text) + $"\\" + Path.GetFileNameWithoutExtension(OpenFilePath.Text);

                DirectoryInfo di = new DirectoryInfo(saveFolerPath);
                di.Create();

                string saveFilePathBase = saveFolerPath + $"\\" + Path.GetFileNameWithoutExtension(OpenFilePath.Text);

                for (int i = 0; i < results.Count; i++)
                {
                    string saveFilePath = saveFilePathBase + "_" + (i + StartNum.Value).ToString() + ".wav";

                    File.WriteAllBytes(saveFilePath, results[i].Binary);
                }
            }
        }

        private void ExecuteAll_Click(object sender, EventArgs e)
        {
            ExecuteAllFunc();
        }

        private void ExecuteAllFunc()
        {
            OpenFile();
            SplitFile();
            SaveFileFunc();
        }

        private void CutSilence_Click(object sender, EventArgs e)
        {

        }
    }
}
