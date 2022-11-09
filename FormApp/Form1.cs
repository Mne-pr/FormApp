using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApp
{
    public partial class Form1 : Form
    {
        Form2 frm2;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show("프로그램 종료합니다");
            Application.Exit();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //Graphics g = CreateGraphics();
            ////화면에 뭔가 출력하기 위해 만드는 그래픽 객체

            //String drawString = "X";
            //Font drawFont = new Font("Arial", 12);
            //SolidBrush drawBrush = new SolidBrush(Color.Black);
            //PointF drawPoint = new PointF(e.X, e.Y);
            ////DrawString에 들어가는 인자들

            //g.DrawString(drawString,drawFont,drawBrush, drawPoint);
            ////문자 출력하는 함수
            //g.Dispose();
            ////만들었으면 삭제해줘야함
            ///

            Graphics g = CreateGraphics();

            Font drawFont = new Font("FixedSys", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            float x = 0.0F;
            float y = 16.0F;
            float width = 200.0F;
            float height = 50.0F;
            RectangleF drawRect = new RectangleF(x, y, width, height);

            Color backGray = Color.FromArgb(240, 240, 240);
            SolidBrush backBrush = new SolidBrush(backGray);
            g.FillRectangle(backBrush, 0, 0, 200, 50 + y);

            String str = String.Format("{0:d5} {1:d5}", e.X, e.Y);

            g.DrawString(str, drawFont, drawBrush, drawRect);

            g.Dispose();
        }

        private void MyBtn1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("버튼 클릭했다", "타이틀");
            frm2.textBox1.Text = "안녕하세요! 폼1로부터";
        }

        private void MyBtn1_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g = CreateGraphics();

            Font drawFont = new Font("FixedSys", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Red);

            float x = 0.0F;
            float y = 16.0F;
            float width = 200.0F;
            float height = 50.0F;
            RectangleF drawRect = new RectangleF(x, y, width, height);

            Color backGray = Color.FromArgb(240, 240, 240);
            SolidBrush backBrush = new SolidBrush(backGray);
            g.FillRectangle(backBrush, 0, 0, 200, 50 + y);

            String str = String.Format("{0:d5} {1:d5}", e.X, e.Y);

            g.DrawString(str, drawFont, drawBrush, drawRect);

            g.Dispose();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //frm2 = new Form2();
            frm2 = new Form2(this);
            //frm2.Owner = this;
            frm2.TopLevel = false;
            this.Controls.Add(frm2);           
            frm2.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //frm2.Owner을 지정하지 않았을 경우 여기서 frm2의 삭제가 이루어진다.
            frm2.Dispose();
        }

        private void 나가기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("프로그램 종료합니다");
            Application.Exit();
        }
    }
}
