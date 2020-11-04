using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


// POST 전송
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
using System.Net.Http;
using System.Net.Sockets;
using System.Drawing.Drawing2D;

namespace WindowsFormsLED
{
    public partial class Form1 : Form
    {
        public static decimal R;
        public static decimal G;
        public static decimal B;

        public static Boolean first_check = true;

        Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse("192.168.0.43"), 3000);


        public static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public Form1()
        {
            InitializeComponent();

            nudR.Text = 0.ToString();
            nudG.Text = 0.ToString();
            nudB.Text = 0.ToString();
            Track_R.Maximum = 255;
            Track_G.Maximum = 255;
            Track_B.Maximum = 255;

            int i = 0;

            timer.Interval = 500; //주기 설정
            timer.Tick += new EventHandler(Timer_Tick); //주기마다 실행되는 이벤트 등록
            void Timer_Tick(object sender, System.EventArgs e)
            {
                //수행해야할 작업
                Server_Check();

                i++;
                if(i >= 10)
                {
                    first_check = true;
                    i = 0;
                }

            }

            timer.Start();
            
        }

        private void scrR_Scroll(object sender, EventArgs e)
        {
            nudR.Text = Track_R.Value.ToString();
            label_R.BackColor = Color.FromArgb(Track_R.Value, 0, 0);
        }

        private void Track_G_Scroll(object sender, EventArgs e)
        {
            nudG.Text = Track_G.Value.ToString();
            label_G.BackColor = Color.FromArgb(0, Track_G.Value, 0);
        }

        private void Track_B_Scroll(object sender, EventArgs e)
        {
            nudB.Text = Track_B.Value.ToString();
            label_B.BackColor = Color.FromArgb(0, 0, Track_B.Value);
        }

        public void color_Change(NumericUpDown nud, TrackBar scr, Label lb)
        {
            int i;
            string num = nud.Text;
            if (int.TryParse(nud.Text.Replace(",", ""), out i))
            {
                nud.Text = i.ToString();

                if (nud.Text != "")
                {
                    scr.Value = int.Parse(nud.Text);

                    switch (lb.Name)
                    {
                        case "label_R":
                            lb.BackColor = Color.FromArgb(scr.Value, 0, 0);
                            break;

                        case "label_G":
                            lb.BackColor = Color.FromArgb(0, scr.Value, 0);
                            break;

                        case "label_B":
                            lb.BackColor = Color.FromArgb(0, 0, scr.Value);
                            break;
                    }
                        

                    nud.Select(nud.Text.Length, 0);
                }
            }
            else
            {
                nud.Text = num;
            }
        }

        private void nudR_TextChanged(object sender, EventArgs e)
        {
            color_Change(nudR, Track_R, label_R);
        }

        private void nudG_TextChanged(object sender, EventArgs e)
        {
            color_Change(nudG, Track_G, label_G);
        }

        private void nudB_TextChanged(object sender, EventArgs e)
        {
            color_Change(nudB, Track_B, label_B);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            nudR.Text = 0.ToString();
            nudG.Text = 0.ToString();
            nudB.Text = 0.ToString();
            RGB_Post();
        }

        public void RGB_Post()
        {
            if (R != nudR.Value || G != nudG.Value || B != nudB.Value || first_check == true)
            {
                first_check = false;

                try
                {


                    string cmd = string.Empty;
                    byte[] receiverBuff = new byte[30];
                    Console.WriteLine("Connected...");

                    cmd = String.Format("L{0,3:D3}{1,3:D3}{2,3:D3}", (int)nudR.Value, (int)nudG.Value, (int)nudB.Value);
                    byte[] buff = Encoding.UTF8.GetBytes(cmd);
                    // (3) 서버에 데이타 전송
                    sock.Send(buff, SocketFlags.None);

                    // (4) 서버에서 데이타 수신
                    int n = sock.Receive(receiverBuff);
                    string data = Encoding.UTF8.GetString(receiverBuff, 0, n);
                    Console.WriteLine(data);

                    pB_Connect.Image = global::WindowsFormsLED.Properties.Resources.CONNECT;
                    btn_clear.Enabled = true;

                    R = nudR.Value;
                    G = nudG.Value;
                    B = nudB.Value;

                }
                catch (ObjectDisposedException)
                {
                    Console.WriteLine("ObjectDisposedException");
                    sock.Disconnect(true);
                    pB_Connect.Image = global::WindowsFormsLED.Properties.Resources.DISCONNECT;
                    btn_clear.Enabled = false;

                }
                catch (SocketException)
                {
                    Console.WriteLine("SocketException");
                    sock.Disconnect(true);
                    pB_Connect.Image = global::WindowsFormsLED.Properties.Resources.DISCONNECT;
                    btn_clear.Enabled = false;

                }

            }

        }

        public void Server_Check()
        {
            if (sock.Connected)
            {   
                RGB_Post();
            }
            else
            {
                try
                {
                   
                    var result = sock.BeginConnect(ep, null, null);
                    bool isConnect = result.AsyncWaitHandle.WaitOne(5000, true);
                    if (isConnect)
                    {
                        sock.EndConnect(result);
                    }
                    else
                    {
                        sock.Close();
                        throw new SocketException(10060); // Connection timed out.
                    }
                }
                catch (SocketException e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("failed");

                }
                catch (ObjectDisposedException e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

        }
      
    }
}
