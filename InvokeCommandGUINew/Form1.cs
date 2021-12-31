using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace InvokeCommandGUINew
{
    public partial class Form1 : Form
    {
   
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loadServer_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
          
            loadServer.Enabled = false;
        
            String[] servers = { };
            try { servers = File.ReadAllLines(openFileDialog1.FileName); }
            catch (Exception ex) { MessageBox.Show($"{ex.Message}"); }
            
            if (servers.Length > 0)
            {
                invokecmd.Enabled = true;
                scriptBlock.Enabled = true;
                foreach (var server in servers)
                {
                    server.Trim();
                    serverList.Items.Add(server);
                }

            }
            else { MessageBox.Show("Server List Empty"); }
        }

        private async void invokecmd_Click(object sender, EventArgs e)
        {
            string outputfile = "InvokeCommandOutput.txt";
            invokecmd.Enabled = false;
            scriptBlock.Enabled = false;
            try
            {
                File.WriteAllText(outputfile, "");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            if (serverList.Items.Count > 0)
            {
                System.Collections.ArrayList computers = new System.Collections.ArrayList();
                computers.AddRange(serverList.Items);
                string script=scriptBlock.Text.Trim();

                await Task.Run(() => {
                    InvokeCommandPS.InvokePSCommand((string[])computers.ToArray(typeof(string)), "", "", script, outputfile);
                });


                outputLabel.Text = "All Done, Please check the outputfile";
                outputLabel.BackColor = System.Drawing.Color.OrangeRed;
                MessageBox.Show("All Done");
                
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void outPutWrite_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
