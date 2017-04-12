using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FateDisclosedLauncher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool CheckUpdates()
        {
            return false;
        }

        private void UpdateGame()
        {

        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if(CheckUpdates())
            {
                UpdateGame();
            }
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = "FateDisclosed.exe";
            startInfo.Arguments = "1600 900";
            try
            {
                System.Diagnostics.Process.Start(startInfo);
                Application.Exit();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            resolutionBox.SelectedIndex = 0;
        }
    }
}
