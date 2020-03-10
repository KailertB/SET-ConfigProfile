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

namespace SET_ConfigProfile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowseSourceFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new OpenFileDialog())
            {
                DialogResult result = fbd.ShowDialog();

                //if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                //{
                //    string[] files = Directory.GetFiles(fbd.SelectedPath);

                //    System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                //}
            }
        }
    }
}
