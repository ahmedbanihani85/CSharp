using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestParseFiles
{
    public partial class FileparsingForm : Form
    {
        string filepathname;
        FileParser fp;
        bool flag;
        public FileparsingForm()
        {
            InitializeComponent();
           // InitializeComponent2();
            openFileDialog1 = new OpenFileDialog();
            flag = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filepathname=openFileDialog1.FileName;
                
                fp = new FileParser(filepathname);
                this.button2.Enabled = true;
            }

            this.label1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fp.CleanFile();
            MessageBox.Show("Cleanning process for file: \"" + filepathname + "\"\nhas been done!");
            flag = true;
            this.button2.Enabled = false;
            //fp.CleanFile();
            this.label1.Visible = true;
            fp.Dispose();
        }
    }
}
