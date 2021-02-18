namespace WaveSplitter
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.OpenFilePath = new System.Windows.Forms.TextBox();
            this.SplitTest = new System.Windows.Forms.Button();
            this.SaveFile = new System.Windows.Forms.Button();
            this.SaveFilePath = new System.Windows.Forms.TextBox();
            this.StartNum = new System.Windows.Forms.NumericUpDown();
            this.StartNumLabel = new System.Windows.Forms.Label();
            this.ExecuteAll = new System.Windows.Forms.Button();
            this.ThresholdLevel = new System.Windows.Forms.NumericUpDown();
            this.ThresholdTime = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CutSilence = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.StartNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdTime)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Location = new System.Drawing.Point(1212, 10);
            this.OpenFileButton.Margin = new System.Windows.Forms.Padding(2);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(60, 23);
            this.OpenFileButton.TabIndex = 0;
            this.OpenFileButton.Text = "Open";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // OpenFilePath
            // 
            this.OpenFilePath.Location = new System.Drawing.Point(7, 11);
            this.OpenFilePath.Margin = new System.Windows.Forms.Padding(2);
            this.OpenFilePath.Name = "OpenFilePath";
            this.OpenFilePath.ReadOnly = true;
            this.OpenFilePath.Size = new System.Drawing.Size(1201, 22);
            this.OpenFilePath.TabIndex = 1;
            // 
            // SplitTest
            // 
            this.SplitTest.Location = new System.Drawing.Point(203, 170);
            this.SplitTest.Margin = new System.Windows.Forms.Padding(2);
            this.SplitTest.Name = "SplitTest";
            this.SplitTest.Size = new System.Drawing.Size(60, 23);
            this.SplitTest.TabIndex = 2;
            this.SplitTest.Text = "Split";
            this.SplitTest.UseVisualStyleBackColor = true;
            this.SplitTest.Click += new System.EventHandler(this.SplitTest_Click);
            // 
            // SaveFile
            // 
            this.SaveFile.Location = new System.Drawing.Point(1212, 295);
            this.SaveFile.Margin = new System.Windows.Forms.Padding(2);
            this.SaveFile.Name = "SaveFile";
            this.SaveFile.Size = new System.Drawing.Size(60, 23);
            this.SaveFile.TabIndex = 3;
            this.SaveFile.Text = "Save";
            this.SaveFile.UseVisualStyleBackColor = true;
            this.SaveFile.Click += new System.EventHandler(this.SaveFile_Click);
            // 
            // SaveFilePath
            // 
            this.SaveFilePath.Location = new System.Drawing.Point(7, 296);
            this.SaveFilePath.Margin = new System.Windows.Forms.Padding(2);
            this.SaveFilePath.Name = "SaveFilePath";
            this.SaveFilePath.ReadOnly = true;
            this.SaveFilePath.Size = new System.Drawing.Size(1201, 22);
            this.SaveFilePath.TabIndex = 4;
            // 
            // StartNum
            // 
            this.StartNum.Font = new System.Drawing.Font("MS UI Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.StartNum.Location = new System.Drawing.Point(121, 323);
            this.StartNum.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.StartNum.Name = "StartNum";
            this.StartNum.Size = new System.Drawing.Size(74, 40);
            this.StartNum.TabIndex = 5;
            this.StartNum.Value = new decimal(new int[] {
            48,
            0,
            0,
            0});
            // 
            // StartNumLabel
            // 
            this.StartNumLabel.AutoSize = true;
            this.StartNumLabel.Font = new System.Drawing.Font("MS UI Gothic", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.StartNumLabel.Location = new System.Drawing.Point(7, 323);
            this.StartNumLabel.Name = "StartNumLabel";
            this.StartNumLabel.Size = new System.Drawing.Size(102, 22);
            this.StartNumLabel.TabIndex = 6;
            this.StartNumLabel.Text = "StartNum.";
            // 
            // ExecuteAll
            // 
            this.ExecuteAll.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ExecuteAll.Location = new System.Drawing.Point(1101, 323);
            this.ExecuteAll.Name = "ExecuteAll";
            this.ExecuteAll.Size = new System.Drawing.Size(171, 40);
            this.ExecuteAll.TabIndex = 7;
            this.ExecuteAll.Text = "ExecuteAll";
            this.ExecuteAll.UseVisualStyleBackColor = true;
            this.ExecuteAll.Click += new System.EventHandler(this.ExecuteAll_Click);
            // 
            // ThresholdLevel
            // 
            this.ThresholdLevel.Font = new System.Drawing.Font("MS UI Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ThresholdLevel.Location = new System.Drawing.Point(169, 53);
            this.ThresholdLevel.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.ThresholdLevel.Name = "ThresholdLevel";
            this.ThresholdLevel.Size = new System.Drawing.Size(74, 40);
            this.ThresholdLevel.TabIndex = 8;
            this.ThresholdLevel.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // ThresholdTime
            // 
            this.ThresholdTime.Font = new System.Drawing.Font("MS UI Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ThresholdTime.Location = new System.Drawing.Point(165, 116);
            this.ThresholdTime.Maximum = new decimal(new int[] {
            2000000,
            0,
            0,
            0});
            this.ThresholdTime.Name = "ThresholdTime";
            this.ThresholdTime.Size = new System.Drawing.Size(131, 40);
            this.ThresholdTime.TabIndex = 9;
            this.ThresholdTime.Value = new decimal(new int[] {
            18000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(13, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "ThresholdLevel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(13, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 22);
            this.label2.TabIndex = 10;
            this.label2.Text = "ThresholdTime";
            // 
            // CutSilence
            // 
            this.CutSilence.Location = new System.Drawing.Point(382, 170);
            this.CutSilence.Margin = new System.Windows.Forms.Padding(2);
            this.CutSilence.Name = "CutSilence";
            this.CutSilence.Size = new System.Drawing.Size(119, 23);
            this.CutSilence.TabIndex = 2;
            this.CutSilence.Text = "CutSilence";
            this.CutSilence.UseVisualStyleBackColor = true;
            this.CutSilence.Click += new System.EventHandler(this.CutSilence_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 375);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ThresholdTime);
            this.Controls.Add(this.ThresholdLevel);
            this.Controls.Add(this.ExecuteAll);
            this.Controls.Add(this.StartNumLabel);
            this.Controls.Add(this.StartNum);
            this.Controls.Add(this.SaveFilePath);
            this.Controls.Add(this.SaveFile);
            this.Controls.Add(this.CutSilence);
            this.Controls.Add(this.SplitTest);
            this.Controls.Add(this.OpenFilePath);
            this.Controls.Add(this.OpenFileButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.StartNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.TextBox OpenFilePath;
        private System.Windows.Forms.Button SplitTest;
        private System.Windows.Forms.Button SaveFile;
        private System.Windows.Forms.TextBox SaveFilePath;
        private System.Windows.Forms.NumericUpDown StartNum;
        private System.Windows.Forms.Label StartNumLabel;
        private System.Windows.Forms.Button ExecuteAll;
        private System.Windows.Forms.NumericUpDown ThresholdLevel;
        private System.Windows.Forms.NumericUpDown ThresholdTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CutSilence;
    }
}

