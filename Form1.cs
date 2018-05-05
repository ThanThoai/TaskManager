using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManagerHDH
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            firstPage1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            secondPage1.BringToFront(); // gọi page 2
        }

        private void button1_Click(object sender, EventArgs e)
        {
            firstPage1.BringToFront(); // gọi page 1
        }

        
    }
}
