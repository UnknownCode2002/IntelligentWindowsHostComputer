using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApeFree.ApeForms.Core.Controls;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;

namespace 智能窗户2._0
{
    public partial class device : Form
    {                     //初始化
        public static string dataOpen = "0"; //开窗控制码
        public static string dataStop = "2"; //停止控制码
        public static string dataClose = "1"; //关窗控制码
        public static string dataChild_lock = "3";//童锁开控制码
        public static string dataChild_unlock = "4";//童锁关控制码
        public static int count = 0;
        public string[] temp = new string[12];
        public static bool bluetoothConnect = false;//是否执行蓝牙连接
        public static bool isConnected = false;//判断蓝牙是否连接
        public static bool bluetoothClose = false;
        public static bool signalopen = false;//是否发送开窗信号
        public static bool signalstop = false;//是否发送停止信号
        public static bool signalclose = false;//是否发送关闭信号
        public static bool signalchild_lock = false;//是否发送开启童锁信号
        public static bool signalchild_unlock = false;//是否发送关闭童锁信号

        public device()
        {
            InitializeComponent();
        }

        private void listDevice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
   

        private void flash_Click(object sender, EventArgs e)
        {
            listDevice.Items.Clear();
        }

        private void connect_Click(object sender, EventArgs e)//点击连接设备按钮触发事件
        {
            Task.Run(() =>
            {                           
                    BluetoothRadio bluetoothRadio = BluetoothRadio.PrimaryRadio;
                    if (bluetoothRadio == null)
                    {
                        MessageBox.Show("请先打开Windows蓝牙");
                        Process.Start(@"ms-settings:bluetooth");
                        return;
                    }
                    if (listDevice.SelectedItem.ToString() != null)
                    {
                        BluetoothConnect();//启动蓝牙设备连接方法函数
                        for (int i = 0; i < 5; i++)
                            if (!isConnected)
                            {
                                connect.Text = "正在连接";
                                Thread.Sleep(2000);
                            }
                    }                    
                

            });
        }

        private void device_Load(object sender, EventArgs e)//显示搜索到的蓝牙设备
        {
            Task.Run(() =>
            {
                BluetoothClient client = new BluetoothClient();     //处理蓝牙的对象
                BluetoothAddress blueAddress = BluetoothAddress.None;   //需要连接的蓝牙模块的唯一标识符
                BluetoothRadio radio = BluetoothRadio.PrimaryRadio;  //获取电脑蓝牙
                radio.Mode = RadioMode.Connectable;     //设置电脑蓝牙可被搜索到                
                while (true)
                {                                                            //从搜索到的所有蓝牙设备中选择需要的那个
                    BluetoothDeviceInfo[] devices = client.DiscoverDevices();   //搜索蓝牙设备，10秒
                    bool flag = false;
                    foreach (var item in devices)
                    {
                        for (int i = 0; i < listDevice.Items.Count; i++) //显示搜索到的蓝牙设备
                        {
                            if (listDevice.Items[i].ToString() == item.DeviceName)
                            {
                                flag = true;
                            }
                            Thread.Sleep(200);
                        }
                        if (!flag)
                        {
                            listDevice.Items.Add(item.DeviceName) ;
                        }
                        flag = false;
                    }
                    Thread.Sleep(5000);
                }
            });
            
        }
        public void BluetoothConnect()
        {
            Task.Run(() =>
            {
                BluetoothClient client = new BluetoothClient();    //处理蓝牙的对象
                BluetoothAddress blueAddress = BluetoothAddress.None;   //需要连接的蓝牙模块的唯一标识符
                BluetoothDeviceInfo[] devices = client.DiscoverDevices();   //搜索蓝牙设备，10秒

                foreach (var item in devices)//配对
                {
                    if (!client.Connected && item.DeviceName.Equals(this.listDevice.SelectedItem.ToString()))   //this.listBox1.SelectedItem.ToString()))  //根据蓝牙名字找
                    {
                        blueAddress = item.DeviceAddress;           //获得蓝牙模块的唯一标识符
                        BluetoothEndPoint ep = new BluetoothEndPoint(blueAddress, BluetoothService.SerialPort);
                        client.Connect(ep);   //开始配对 蓝牙4.0不需要setpin
                        if (client.Connected && !isConnected)
                        {
                            isConnected = true;
                            connect.Text = "已连接";
                            Thread.Sleep(5000);
                            connect.Text = "连接";
                        }
                        else
                        {
                            isConnected = false;
                            connect.Text = "连接";
                        }
                    }
                }
                while (true)//循环检测signal指令信号 如检测到则启动相应的指令发送函数传输开或关窗等控制码
                {
                    if (client.Connected && signalopen == true)
                    {
                        // 将数据转换为字节数组
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(dataOpen);//dataOpen为开窗控制码                                                                                         // 发送开窗指令
                        client.GetStream().Write(buffer, 0, buffer.Length);// 发送停止指令
                        signalopen = false;
                        //connect.Text = "开";
                    }
                    else if (client.Connected && signalstop == true)
                    {
                        // 将数据转换为字节数组
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(dataStop);//dataStop为电机停止控制码                                                                                             
                        client.GetStream().Write(buffer, 0, buffer.Length);// 发送停止指令
                        signalstop = false;
                        //connect.Text = "停";
                    }
                    else if (client.Connected && signalclose == true)
                    {
                        // 将数据转换为字节数组
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(dataClose);//dataClose为关窗控制码                                                                                             
                        client.GetStream().Write(buffer, 0, buffer.Length);// 发送关窗指令
                        signalclose = false;
                        //connect.Text = "关";
                    }
                    else if (client.Connected && signalchild_lock == true)
                    {
                        // 将数据转换为字节数组
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(dataChild_lock);//dataChild_lock为童锁开控制码                                                                                             
                        client.GetStream().Write(buffer, 0, buffer.Length);// 发送开启童锁指令
                        signalchild_lock = false;
                        //connect.Text = "童锁开";
                    }
                    else if (client.Connected && signalchild_unlock == true)
                    {
                        // 将数据转换为字节数组
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(dataChild_unlock);//dataChild_unlock为童锁关控制码                                                                                             
                        client.GetStream().Write(buffer, 0, buffer.Length);// 发送关闭童锁指令
                        signalchild_unlock = false;
                        //connect.Text = "童锁关";
                    }
                }
            });
        }
    }
}
