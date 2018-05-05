using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.VisualBasic;

namespace TaskManagerHDH
{
    public partial class firstPage : UserControl
    {
        public firstPage()
        {
            InitializeComponent();
            GetProcess();
        }

        Process[] proc;
        private void GetProcess()
        {
            // tạo mảng process 
            proc = Process.GetProcesses();
            listView1.Items.Clear(); 
            foreach(Process p in proc)
            {
                // thêm tên , id , memory vào từng column trong listview
                ListViewItem item = new ListViewItem()
                {
                    Text = p.ProcessName
                };
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = p.Id.ToString() });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = p.PeakPagedMemorySize64.ToString() });
                listView1.Items.Add(item);
            }
        }
        private void endTask()
        {
            if (listView1.SelectedItems.Count > 0) // kiểm tra xem danh sách tiến trình có trống hay không
            {
                int index = 0;
                foreach (var item in proc)
                {
                    if (item.ProcessName == listView1.SelectedItems[0].Text)
                    {
                        index = proc.ToList().IndexOf(item); // Lấy giá trị biến index là giá trị cần tìm
                        break;
                    }
                }
                proc[index].Kill(); // dừng tiến trình
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            endTask();
        }

        private void refeshNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetProcess();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(proc.Length != Process.GetProcesses().Length) // Khi 2 độ dài của mảng tiến trình là khác nhau thì cập nhật lại
            {
                GetProcess();
            }
        }

        private void endTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            endTask();
        }

       

        private void runNewTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Microsoft.VisualBasic.Interaction.InputBox("Open:", "Run New Task", "", 350, 350);
            Process.Start(path);
        }
    }
}
