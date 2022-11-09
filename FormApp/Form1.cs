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
        System.Int32 m_steps = 0;
        System.Int32 m2_steps = 0;
        //시스템의 int32
        int m_x, m_y;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            m_steps++;
            label1.Text = m_steps.ToString();
            progressBar1.Value = m_steps;
            pictureBox1.Load("./2.png");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            String str = textBox1.Text;
            if (str.Trim() == "")
            {
                progressBar1.Value = 0;
                label1.Text = "0";
                return;
            }
            //비었을 때 0으로 처리
            label1.Text = str;
            try
            {
                m_steps = Convert.ToInt32(label1.Text);

                if (m_steps > 100)
                {
                    m_steps = 100;
                    label1.Text = "100";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            progressBar1.Value = m_steps;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                e.Handled = true;
            }
            //숫자가 입력받도록 한것
            //e.handled는 이벤트 중지를 알리는 것이엇다..
            //이제 이 다음에 입력이 되면 위에 이벤트가 발동하는 것!
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            m2_steps++;
            if (m2_steps > 100)
            {
                m2_steps = 100;
                timer1.Enabled = false;
            }
            progressBar2.Value = m2_steps;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (pictureBox1.Visible == true)
                pictureBox1.Visible = false;
            else
                pictureBox1.Visible = true;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            label2.Text = e.X.ToString() + "," + e.Y.ToString();
            //Graphics g = pictureBox2.CreateGraphics();
            //g.Clear(Color.White);
            //SolidBrush br = new SolidBrush(Color.Black);
            //Pen pen = new Pen(br);
            //Point pt1 = new Point(0, 0);
            //Point pt2 = new Point(e.X, e.Y);
            //g.DrawLine(pen, pt1, pt2);
            //g.Dispose();
            //리소스 많이 잡아먹기 때문에 여기서 작업하는 것은 옳지 않음
            m_x = e.X;
            m_y = e.Y;
            pictureBox2.Invalidate();
            pictureBox2.Update();
            //이 invalidate로 인해 paint메소드가 호출됨
            //이때 update를 사용하면 즉시 적용이됨
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MyDlg dlg = new MyDlg();
            //dlg.Show();
            //하면 그냥 윈도우로 나올것이고
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                label3.Text = dlg.textBox1.Text;
                //MessageBox.Show("대화상자에서 OK");

            }
            //이러면 다이어로그 윈도우로 뜸 일단 큰차이는 없다
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {

            //SolidBrush br = new SolidBrush(Color.Black);
            //Pen pen = new Pen(br);
            //Point pt1 = new Point(0, 0);
            Point pt2 = new Point(m_x, m_y);
            //e.Graphics.DrawLine(pen, pt1, pt2);

            //이번에는 점찍기. c#에는 점찍는 객체가 bitmap이다.
            Bitmap bmp = new Bitmap(5, 5);//2x2
            bmp.SetPixel(0, 0, Color.Red);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    bmp.SetPixel(i, j, Color.Red);
                }
            }
            e.Graphics.DrawImageUnscaled(bmp, pt2);
        }
    }
}
