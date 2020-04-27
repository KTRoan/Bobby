using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralCheffBobbyFlayI
{
    public partial class Bobby : Form
    {
        string lastrecipe;
        StreamWriter fileWriter;

        recipeoptions ro = new recipeoptions();
        dietaryrestrictions drr = new dietaryrestrictions();

        public Bobby()
        {
            InitializeComponent();
        }

        private void Generate() {

            System.Diagnostics.Debug.WriteLine(Path.GetFullPath("..\\..\\letsCookTry2.txt"));

           if (ro.userchoice_ != null || drr.userchoice != null)
            {
                label2.Text = "Created recipe with cuisine selection: " + ro.userchoice_ + " and dietary restriction: "+ drr.userchoice;
            }
            lastrecipe =  textBox1.Text;
            string fileName = Path.GetFullPath("..\\..\\char-model-v2.py") + " " + Path.GetFullPath("..\\..\\letsCookTry2.txt") + " " + Path.GetFullPath("..\\..\\training_checkpoints");//python script location, will need to append command line arguments to this string if/when necessary
            string pySource = getPythonPath();//python path source
            //to find python path source, go into type "where python" into command line, copy output into string 
            try
            {
                Process p = new Process();
                ProcessStartInfo start = new ProcessStartInfo();
                start.FileName = pySource;
                start.Arguments = fileName;
                start.CreateNoWindow = true;
                start.UseShellExecute = false;
                start.RedirectStandardOutput = true;
                using (Process process = Process.Start(start))
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string result = reader.ReadToEnd();
                        textBox1.Text = result;
                    }
                }
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message; //this never caught anything, but I had errors, however error != exception, so we'll need to implement error handling into the final product
            }

        }

        private string getPythonPath()
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "CMD.exe";
            p.StartInfo.Arguments = "/c where py";
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            return output;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_cuisineoptions_Click(object sender, EventArgs e)
        {
            ro.Show();
        }

        private void button_dietaryrestrictions_Click(object sender, EventArgs e)
        {
            
            drr.Show();
            
        }

        private void button_savetofile_Click(object sender, EventArgs e)
        {
            DialogResult result;
            string fileName;

            using (SaveFileDialog fileChooser = new SaveFileDialog())
            {
                fileChooser.CheckFileExists = false;
                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName;
            }

            if (result == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    MessageBox.Show("Invalid File Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        fileWriter?.Close();
                        FileStream output = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                        fileWriter = new StreamWriter(output);

                        //any housekeeping
                    }
                    catch (IOException)
                    {
                        //write  error message
                        MessageBox.Show("Error Opening File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    try
                    {
                        //write contents of textbox(ideally a recipe) to specified file
                        fileWriter.Write(textBox1.Text);
                        fileWriter.Close();
                    }
                    catch (IOException)
                    {
                        //write error message
                        MessageBox.Show("Error Writing to File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (FormatException)
                    {
                        //write error message
                        MessageBox.Show("Invalid Format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }

        }

        private void button_genrecipe_Click(object sender, EventArgs e)
        {
            try
            {
                Generate(); //using an function call to make the event handler look cleaner
            }
            catch (Exception ex)
            {

                textBox1.Text = ex.Message;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = lastrecipe;
            label2.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
