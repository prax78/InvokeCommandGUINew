namespace InvokeCommandGUINew
{
    partial class Form1
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
            this.loadServer = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.serverList = new System.Windows.Forms.ListBox();
            this.scriptBlock = new System.Windows.Forms.RichTextBox();
            this.invokecmd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressLabel = new System.Windows.Forms.RichTextBox();
            this.outputLabel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // loadServer
            // 
            this.loadServer.Location = new System.Drawing.Point(102, 43);
            this.loadServer.Name = "loadServer";
            this.loadServer.Size = new System.Drawing.Size(460, 52);
            this.loadServer.TabIndex = 0;
            this.loadServer.Text = "Load Servers from a file";
            this.loadServer.UseVisualStyleBackColor = true;
            this.loadServer.Click += new System.EventHandler(this.loadServer_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.txt";
            this.openFileDialog1.Title = "Select Server Text File";
            // 
            // serverList
            // 
            this.serverList.FormattingEnabled = true;
            this.serverList.ItemHeight = 20;
            this.serverList.Location = new System.Drawing.Point(102, 101);
            this.serverList.Name = "serverList";
            this.serverList.Size = new System.Drawing.Size(460, 144);
            this.serverList.TabIndex = 1;
            // 
            // scriptBlock
            // 
            this.scriptBlock.Enabled = false;
            this.scriptBlock.Location = new System.Drawing.Point(667, 101);
            this.scriptBlock.Name = "scriptBlock";
            this.scriptBlock.Size = new System.Drawing.Size(475, 104);
            this.scriptBlock.TabIndex = 2;
            this.scriptBlock.Text = "";
            // 
            // invokecmd
            // 
            this.invokecmd.Enabled = false;
            this.invokecmd.Location = new System.Drawing.Point(667, 211);
            this.invokecmd.Name = "invokecmd";
            this.invokecmd.Size = new System.Drawing.Size(475, 43);
            this.invokecmd.TabIndex = 3;
            this.invokecmd.Text = "Invoke-Command";
            this.invokecmd.UseVisualStyleBackColor = true;
            this.invokecmd.Click += new System.EventHandler(this.invokecmd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Server List";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(568, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Script Block";
            // 
            // progressLabel
            // 
            this.progressLabel.Location = new System.Drawing.Point(16, 271);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.ReadOnly = true;
            this.progressLabel.Size = new System.Drawing.Size(1126, 155);
            this.progressLabel.TabIndex = 6;
            this.progressLabel.Text = "Job Status";
            // 
            // outputLabel
            // 
            this.outputLabel.Location = new System.Drawing.Point(16, 449);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.ReadOnly = true;
            this.outputLabel.Size = new System.Drawing.Size(1126, 26);
            this.outputLabel.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 501);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.invokecmd);
            this.Controls.Add(this.scriptBlock);
            this.Controls.Add(this.serverList);
            this.Controls.Add(this.loadServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Invoke-Command GUI pr_prakash78@outlook.com";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadServer;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListBox serverList;
        private System.Windows.Forms.RichTextBox scriptBlock;
        private System.Windows.Forms.Button invokecmd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox progressLabel;
        private System.Windows.Forms.TextBox outputLabel;
    }
}

