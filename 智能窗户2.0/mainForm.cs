using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using 智能窗户2._0.Properties;

namespace 智能窗户2._0
{
    public partial class Form1 : Form
    {
        private static device dForm = null;
        private static control cForm = null;
        private static control2 cForm2 = null;
        private static bool Switch = false;
        Point mouseOff;//鼠标移动位置变量
        bool leftFlag;//标签是否为左键
        public Form1()
        {
            InitializeComponent();
            dForm = new device();
            cForm = new control();
            cForm2 = new control2();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cForm.Hide();
            this.OpenDevice(dForm);


        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                leftFlag = true;                  //点击左键按下时标注为true;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置
                Location = mouseSet;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;
            }
        }

        private void OpenDevice(Form objFrm)
        {
            button1.Image = Resources.blue13;
            button2.Image = Resources.gray1; ;
            //将当前子窗体设置成非顶级控件
            objFrm.TopLevel = false;
                //设置窗体最大化
            objFrm.WindowState = FormWindowState.Maximized;
                //去掉窗体边框
            objFrm.FormBorderStyle = FormBorderStyle.None;
                //指定当前子窗体显示的容器
            objFrm.Parent = this.panel1;
            //显示窗体
            //objFrm.Show();
            cForm.Visible = false;
            objFrm.Visible = true;
            objFrm.BringToFront();
            //cForm = null; 

        }

        //打开窗体方法
        private void OpenControl(Form objFrm)
        {
            button2.Image = Resources.blue13;
            button1.Image = Resources.gray1;
            //将当前子窗体设置成非顶级控件
            objFrm.TopLevel = false;
            //设置窗体最大化
            objFrm.WindowState = FormWindowState.Maximized;
            //去掉窗体边框
            objFrm.FormBorderStyle = FormBorderStyle.None;
            //指定当前子窗体显示的容器
            objFrm.Parent = this.panel1;
            //显示窗体
            //objFrm.Show();
            dForm.Visible = false;
            objFrm.Visible = true;
            objFrm.BringToFront();
            //dForm = null;
        }

        private void button2_Click(object sender, EventArgs e)//“控制”按钮的点击触发事件
        {
            if (dForm != null && !Switch || cForm.IsDisposed)
            {
                this.OpenControl(cForm);//显示控制界面
                Switch = true;
            }
            else
            {
                this.OpenControl(cForm2);
                Switch = false;
                //cForm.WindowState = FormWindowState.Normal;
                //cForm.Activate();
            }
        }

        private void button1_Click(object sender, EventArgs e)//“设备”按钮的点击触发事件
        {
            if (cForm != null || dForm.IsDisposed)
            {
                this.OpenDevice(dForm);//显示蓝牙设备界面
                if (Switch == true)
                    Switch = false;
                else
                    Switch = true;
            }
            else
            {
                dForm.WindowState = FormWindowState.Normal;
                dForm.Activate();
            }
        }

        private void btnmin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            if (dForm == null && cForm != null || dForm.IsDisposed)
            {
                button1.Image = Resources.gray2;
            }
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            if (cForm == null && dForm != null || cForm.IsDisposed)
            {
                button2.Image = Resources.gray2;
            }
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            if (dForm == null && cForm != null || dForm.IsDisposed)
            {
                button1.Image = Resources.gray3;
            }
        }
        private void button2_MouseLeave(object sender, EventArgs e)
        {
            if (cForm == null && dForm != null || cForm.IsDisposed)
            {
                button2.Image = Resources.gray3; 
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
