using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp12;

namespace WindowsFormsApp12
{
    public partial class Boyut : Form
    {
        public Boyut()
        {
            InitializeComponent();
        }
        
        

        private void button1_Click_1(object sender, EventArgs e)
        {

            Form1.yükseklik= Convert.ToInt32(numericUpDown1.Value);
            Form1.genişlik = Convert.ToInt32(numericUpDown2.Value);
         
            Hide();
        }

        private void Boyut_Load(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = 10;
            numericUpDown1.Maximum = 9999;
            numericUpDown2.Minimum = 10;
            numericUpDown2.Maximum = 9999;
            numericUpDown1.Value = Form1.yükseklik;
            numericUpDown2.Value = Form1.genişlik;
        }
    }
}
