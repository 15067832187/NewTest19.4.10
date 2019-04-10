using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TC
{
    public partial class Form1 : Form
    {
        double todata;

        public Form1()
        {
            InitializeComponent();
        }

        #region 初始化控件
        private void Form1_Load(object sender, EventArgs e)
        {
            this.label1.Text = "等待转换中";
            this.label2.Text = "等待转换中";
            this.Text = "摄氏华氏温度转换";
        }
        #endregion

        #region 摄氏转华氏
        private void Button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                int tmp = int.Parse(textBox1.Text);
                todata = Convert.ToDouble(textBox1.Text);
                this.label1.Text = Convert.ToString((todata * 9 / 5) + 32) + "°F";
            }
            catch (Exception)
            {
                MessageBox.Show("请正确输入数字");
                textBox1.Text = "";
            }
        }
        #endregion

        #region 关闭按钮
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
        #endregion

        #region 华氏转摄氏
        private void Button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                int tmp = int.Parse(textBox2.Text);
                todata = Convert.ToDouble(textBox2.Text);
                this.label2.Text = Convert.ToString((todata - 32) * 5 / 9) + "°C";
            }
            catch (Exception)
            {
                MessageBox.Show("请正确输入数字");
                textBox1.Text = "";
            }
        }
        #endregion

        #region 文字框2同步1
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
        }
        #endregion

        #region 文字框1同步2
        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text;
        }
        #endregion

        #region 无边框拖动效果
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {   
         //拖动窗体
         ReleaseCapture();
         SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        [DllImport("user32.dll")]//拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        #endregion
    }
}
