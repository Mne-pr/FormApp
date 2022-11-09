using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenCvSharp;
using OpenCvSharp.Extensions;
//이게 오픈cv 사용하는 코드

namespace NugetWindow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mat src = new Mat("1.png", ImreadModes.Color);

            //첫번째
            //OpenCvSharp.Window srcWindow = new OpenCvSharp.Window("src", src);
            //Cv2.WaitKey(0);//어떤 키라도 눌릴때까지 대기
            //Cv2.DestroyWindow("src");//"src" 이름을 가진 윈도우 파괴
            //srcWindow.Dispose();// srcWindow 객체 제거

            //3번째
            src = src.Blur(new OpenCvSharp.Size(7, 7));//영상 흐릿하게 만들기
            Mat dst = new Mat();
            Cv2.Resize(src, dst, new OpenCvSharp.Size(200, 200));

            //5번째
            unsafe
            {
                byte* buff = (byte*)dst.DataPointer;

                for (int i = 0, idx = 0; i < dst.Cols * dst.Rows; i++, idx += 3)
                {
                    int gray = 0;
                    gray = (int)buff[idx + 0] + (int)buff[idx + 1] + (int)buff[idx + 2];
                    gray = gray / 3;

                    buff[idx + 0] = (byte)gray;
                    buff[idx + 1] = (byte)gray;
                    buff[idx + 2] = (byte)gray;
                }
            }

            //2번째
            Bitmap bmp;
            bmp = dst.ToBitmap();
            //src를 dst로 지정하면 크기 바뀐거 확인가능
            //pictureBox1.Image = bmp;

            //4번째
            IntPtr hWnd = pictureBox1.Handle;
            Graphics g = Graphics.FromHwnd(hWnd);
            g.DrawImage(bmp, 0, 0);
            //pictureBox1.Image=bmp;말고 애초에 picturebox의 핸들을 얻어와서
            //그거 이용해서 그래픽 객체 만들고, 그림을 그리게 한다는 뜻

            src.Dispose();
            dst.Dispose();
            g.Dispose();
        }
    }
}
