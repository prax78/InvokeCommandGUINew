using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Security;
using System.IO;

namespace InvokeCommandGUINew
{
    public class InvokeCommandPS
    {



        public static  async void InvokePSCommand(String[] computers, string username, string password, string scriptblock, string outputfile)
        {
            int TotJob = 0;
            int CompltdJob = 0;
            int BlJob = 0;
            int DiscJob = 0;
            int FailJob = 0;
            int RunJob = 0;
            int StopJob = 0;
            int counter = 0;

            // Future release, this can be used to pass secure password to connect servers
            //SecureString securePass = new SecureString();
            //foreach (var pass in password.ToCharArray())
            //{
            //    securePass.AppendChar(pass);
            //}



            InitialSessionState iss = InitialSessionState.CreateDefault();
            
            using (Runspace rs = RunspaceFactory.CreateRunspace(iss))
            {
                rs.Open();

                
                PSDataCollection<PSObject> jobCol = new PSDataCollection<PSObject>();
                PSDataCollection<PSObject> checkjobCol = new PSDataCollection<PSObject>();

                ScriptBlock myscript = ScriptBlock.Create(scriptblock);

                foreach (var computername in computers)
                {


                    using (PowerShell invokePS = PowerShell.Create().AddCommand("Invoke-Command").AddParameter("ScriptBlock", myscript).AddParameter("ComputerName", computername).AddParameter("AsJob"))
                    {
                        invokePS.Runspace = rs;

                        try
                        {
                            IAsyncResult asyncResult = invokePS.BeginInvoke<PSObject, PSObject>(null, jobCol);
                            asyncResult.AsyncWaitHandle.WaitOne();
                        }
                        catch(Exception ex) { }
                            
                        
                    }
                }
                
                TotJob = jobCol.Count;
                
                
                while(true)
                {
                    updateProgressLabelGUI(TotJob, CompltdJob, FailJob, BlJob, DiscJob, RunJob, StopJob, true);

                    CompltdJob = jobCol.Where(x => x.Members["JobStateInfo"].Value.ToString() == "Completed").Count();
                    FailJob = jobCol.Where(x => x.Members["JobStateInfo"].Value.ToString() == "Failed").Count();
                    BlJob = jobCol.Where(x => x.Members["JobStateInfo"].Value.ToString() == "Blocked").Count();
                    DiscJob = jobCol.Where(x => x.Members["JobStateInfo"].Value.ToString() == "Disconnected").Count();
                    RunJob = jobCol.Where(x => x.Members["JobStateInfo"].Value.ToString() == "Running").Count();
                    StopJob = jobCol.Where(x => x.Members["JobStateInfo"].Value.ToString() == "Stopped").Count();
                    

                    
                    if (!jobCol.Any(s => s.Members["JobStateInfo"].Value.ToString() == "Running"))
                        
                        break;
                }
                System.Threading.Thread.Sleep(3000);

                FailJob = jobCol.Where(x => x.Members["JobStateInfo"].Value.ToString() == "Failed").Count();
                BlJob = jobCol.Where(x => x.Members["JobStateInfo"].Value.ToString() == "Blocked").Count();
                DiscJob = jobCol.Where(x => x.Members["JobStateInfo"].Value.ToString() == "Disconnected").Count();
                RunJob = jobCol.Where(x => x.Members["JobStateInfo"].Value.ToString() == "Running").Count();
                StopJob = jobCol.Where(x => x.Members["JobStateInfo"].Value.ToString() == "Stopped").Count();
                CompltdJob = jobCol.Where(x => x.Members["JobStateInfo"].Value.ToString() == "Completed").Count();
                
                updateProgressLabelGUI(TotJob, CompltdJob, FailJob, BlJob, DiscJob, RunJob, StopJob, false);



                foreach (var job in jobCol)
                {
                    counter++;
                    WriteProgressLabelGUI(TotJob, counter);

                    WriteOutputFile(outputfile, $"Job ID--> {job.Members["Id"].Value} :: Job State--> {job.Members["JobStateInfo"].Value} :: Server--> {job.Members["Location"].Value}");
                    WriteOutputFile(outputfile, Environment.NewLine);
                   
                   

                    using (PowerShell resJob = PowerShell.Create().AddCommand("Receive-Job").AddParameter("Id", job.Members["Id"].Value))
                    {
                        resJob.Runspace = rs;

                        IAsyncResult resResult = resJob.BeginInvoke<PSObject, PSObject>(null, checkjobCol);
                        resResult.AsyncWaitHandle.WaitOne();
                        foreach (var j in checkjobCol)
                        {
                            WriteOutputFile(outputfile, $"{j}");
                            WriteOutputFile(outputfile, Environment.NewLine);
                            WriteOutputFile(outputfile, "===========================================");
                            WriteOutputFile(outputfile, Environment.NewLine);

                        }
                    }
                   
                }
            }
        }

        private static async void WriteOutputFile(string outputfile, string v)
        {
           

                try
                {
                    File.AppendAllText(outputfile,v);
                }
                catch { }
            await Task.Delay(100);

        }

        

        private static void updateProgressLabelGUI(int tJob,int cJob,int fJob, int bJob, int dJob,int rJob, int sJob,bool color)
        {
            int compJob = cJob;
            int totJob = tJob;
            int failJob = fJob;
            int dicJOb = dJob;
            int blckJob = bJob;
            int runJob = rJob;
            int stopJob = sJob;
    
            var richTextbox = System.Windows.Forms.Form.ActiveForm.Controls.Find("progressLabel",false);
            foreach(var control in richTextbox)
            {
                System.Windows.Forms.RichTextBox r =(System.Windows.Forms.RichTextBox)control;
                r.BeginInvoke(new Action(() => {
                    if (color)
                    {
                        r.BackColor = System.Drawing.Color.LightYellow;
                        r.Text = $"Total {compJob}/{totJob} Jobs Completed\nTotal {failJob} Jobs Failed\nTotal {blckJob} Blocked\nTotal {dicJOb} Jobs Disconnected\nTotal {runJob} Jobs Running\nTotal {stopJob} Jobs Stopped";

                    }
                    else
                    {
                        r.BackColor = System.Drawing.Color.OrangeRed;
                        r.Text = $"Total {compJob}/{totJob} Jobs Completed\nTotal {failJob} Jobs Failed\nTotal {blckJob} Blocked\nTotal {dicJOb} Jobs Disconnected\nTotal {runJob} Jobs Running\nTotal {stopJob} Jobs Stopped";

                    }

                }));
                   
                
            }
            
        }

        private static void WriteProgressLabelGUI(int tJob,int opJob)
        {

            var TextboxOp = System.Windows.Forms.Form.ActiveForm.Controls.Find("outputLabel", false);
            foreach (var control in TextboxOp)
            {
                System.Windows.Forms.TextBox r = (System.Windows.Forms.TextBox)control;
                r.BeginInvoke(new Action(() => {
                    
                        r.BackColor = System.Drawing.Color.LightYellow;

                        r.Text = $"Please Standby!! Writing output for Job  {opJob}/{tJob}"; 
                    


                }));


            }

        }

        

    }
}
