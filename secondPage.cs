using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManagerHDH
{
    public partial class secondPage : UserControl
    {
        public secondPage()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // đặt giá trị cho CPU và RAM
            float fcpu = pCPU.NextValue();
            float fram = pRam.NextValue();
            // đặt giá trị cho progressbar
            progressBar1.Value = (int)fram;
            progressBar2.Value = (int)fcpu;
            // đặt giá trị cho label
            label4.Text = String.Format("{0:0.00}%", fram);
            label5.Text = String.Format("{0:0.00}%", fcpu);
            // đặt giá trị cho từng điểm trong chart
            chart1.Series["CPU"].Points.AddY(fcpu);
            chart1.Series["RAM"].Points.AddY(fram);
        }

        private void secondPage_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
