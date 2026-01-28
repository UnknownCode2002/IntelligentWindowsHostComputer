using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;
using 智能窗户2._0.Properties;

namespace 智能窗户2._0
{
    public partial class control2 : Form
    {
        public Form1 Form1 { get; }
        public static string labelText;
        private static bool islocked = false;
        public control2()
        {
            InitializeComponent();
        }


        public control2(Form1 form1)
        {
        }

        private void control_Load(object sender, EventArgs e)
        {
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//开窗按钮点击触发事件
        {
            label1.Text = "控制：开";
            device.signalopen = true;//确认发送开窗信号
        }

        private void button2_Click(object sender, EventArgs e)//关窗按钮点击触发事件
        {
            label1.Text = "控制：关";
            device.signalclose = true;//确认发送关窗信号         
        }
        private void button4_Click(object sender, EventArgs e)//停止按钮点击触发事件
        {
            label1.Text = "控制：停";
            device.signalstop = true;//确认发送停止信号
        }

        private void button3_Click_1(object sender, EventArgs e)//童锁按钮点击触发事件
        {
            if (!islocked)
            {
                device.signalchild_lock = true;//确认发送开启童锁信号
                button3.Text = "儿童锁：开";
                islocked = true;
                Thread.Sleep(300);
            }
            else
            {
                device.signalchild_unlock = true;//确认发送关闭童锁信号
                button3.Text = "儿童锁：关";
                islocked = false;
                Thread.Sleep(300);
            }
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.ForeColor = Color.Black;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.ForeColor = Color.Gray;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.BackgroundImage = Resources.RoundButton6;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            button1.BackgroundImage = Resources.RoundButton8;
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            button2.BackgroundImage = Resources.RoundButton7;
        }
        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            button2.BackgroundImage = Resources.RoundButton9;
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            button4.BackgroundImage = Resources.RoundButton13;
        }
        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            button4.BackgroundImage = Resources.RoundButton12;
        }

    }
}
