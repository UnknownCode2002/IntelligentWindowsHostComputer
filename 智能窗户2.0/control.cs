using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ApeFree.ApeForms.Forms.Notifications;
using System.Reflection.Emit;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using ApeFree.ApeForms.Core.Controls;
using 智能窗户2._0.章鱼.Forms;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using 智能窗户2._0.Properties;


namespace 智能窗户2._0
{
    public partial class control : Form
    {
        public Form1 Form1 { get; }       
        public static string labelText;
        private static bool blueDown = false;
        private static bool islocked = false;
        public control()
        {
            InitializeComponent();
        }
        public enum Effect { Roll, Slide, Center, Blend }

    

    public control(Form1 form1)
        {

        }

        private void control_Load(object sender, EventArgs e)
        {
            ControlTrans(button1, button1.Image);
            ControlTrans(button2, button2.Image);
        }
        private unsafe static GraphicsPath subGraphicsPath(Image img)
        {
            if (img == null) return null;

            // 建立GraphicsPath, 给我们的位图路径计算使用   
            GraphicsPath g = new GraphicsPath(FillMode.Alternate);

            Bitmap bitmap = new Bitmap(img);

            int width = bitmap.Width;
            int height = bitmap.Height;
            BitmapData bmData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            byte* p = (byte*)bmData.Scan0;
            int offset = bmData.Stride - width * 3;
            int p0, p1, p2;         // 记录左上角0，0座标的颜色值  
            p0 = p[0];
            p1 = p[1];
            p2 = p[2];

            int start = -1;
            // 行座标 ( Y col )   
            for (int Y = 0; Y < height; Y++)
            {
                // 列座标 ( X row )   
                for (int X = 0; X < width; X++)
                {
                    if (start == -1 && (p[0] != p0 || p[1] != p1 || p[2] != p2))     //如果 之前的点没有不透明 且 不透明   
                    {
                        start = X;                            //记录这个点  
                    }
                    else if (start > -1 && (p[0] == p0 && p[1] == p1 && p[2] == p2))      //如果 之前的点是不透明 且 透明  
                    {
                        g.AddRectangle(new Rectangle(start, Y, X - start, 1));    //添加之前的矩形到  
                        start = -1;
                    }

                    if (X == width - 1 && start > -1)        //如果 之前的点是不透明 且 是最后一个点  
                    {
                        g.AddRectangle(new Rectangle(start, Y, X - start + 1, 1));      //添加之前的矩形到  
                        start = -1;
                    }
                    //if (p[0] != p0 || p[1] != p1 || p[2] != p2)  
                    //    g.AddRectangle(new Rectangle(X, Y, 1, 1));  
                    p += 3;                                   //下一个内存地址  
                }
                p += offset;
            }
            bitmap.UnlockBits(bmData);
            bitmap.Dispose();
            // 返回计算出来的不透明图片路径   
            return g;
        }
        public static void ControlTrans(Control control, Image img)
        {
            GraphicsPath g;
            g = subGraphicsPath(img);
            if (g == null)
                return;
            control.Region = new Region(g);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!blueDown)
            {
                device.signalopen = true;
                label1.Text = "控制：开";
                blueDown = true;
                button1.Image = Resources.RoundButton6;
                button2.Image = Resources.RoundButton10;
                button2.LocationGradualChange(new Point(72, 37), 7);
                button1.LocationGradualChange(new Point(72, 257), 10);

            }
            else
            {
                device.signalstop = true;
                label1.Text = "控制：停";
                blueDown = false;
                button1.Image = Resources.RoundButton8;
                button2.Image = Resources.RoundButton9;
                button1.LocationGradualChange(new Point(72, 37), 7);
                button2.LocationGradualChange(new Point(72, 257), 10);
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (blueDown)
            {
                device.signalstop = true;
                label1.Text = "控制：停";
                blueDown = false;
                button2.Image = Resources.RoundButton9;
                button1.Image = Resources.RoundButton8;
                button1.LocationGradualChange(new Point(72, 37), 7);
                button2.LocationGradualChange(new Point(72, 257), 10);
                
            }
            else
            {
                device.signalclose = true;
                label1.Text = "控制：关";
                button2.Image = Resources.RoundButton7;
                button1.Image = Resources.RoundButton11;
                blueDown = true;
                button2.LocationGradualChange(new Point(72, 37), 7);
                button1.LocationGradualChange(new Point(72, 257), 10);
                
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "控制：停";
            device.signalstop = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!islocked) {
                device.signalchild_lock = true;
                button3.Text = "儿童锁：开";
                islocked = true;
                Thread.Sleep(300);
            }
            else
            {
                device.signalchild_unlock = true;
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
    }
}
