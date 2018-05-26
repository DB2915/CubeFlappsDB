using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CubeFlapps_Undermove
{
    public partial class ResetAll : Form
    {
        public ResetAll()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "leaders.lol";
            if (textBox1.Text=="DB2915" && textBox2.Text=="2004")
            {
                File.Delete(path);
                Thread.Sleep(2000);
                Close();
            }
            else if (textBox1.Text == "Undermove")
            {
                File.Delete(path);
                Thread.Sleep(2000);
                Close();
            }
        }
    }
}
