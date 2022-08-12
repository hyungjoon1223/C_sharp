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

namespace OpenCV_황형준
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Mat b = Cv2.ImRead("C:\\Users\\ATI-4\\Desktop\\C\\1.png", ImreadModes.Unchanged);
            //Mat a = new Mat(500,500, MatType.CV_32FC4, 0);
            //Cv2.ImShow("image", b);
            //Cv2.WaitKey();  //키를 누를 때 까지 아무것도 안한다
            //Cv2.DestroyAllWindows();

            //Mat a = Cv2.ImRead(@"C:\\Users\\ATI-4\\Desktop\\C\\1.png");

            //Mat b = a.SubMat(new Rect(0, 0, a.Width / 2, a.Height));
            //Mat c = a.SubMat(new Rect(a.Width / 2, 0, a.Width / 2, a.Height));

            //Cv2.ImShow("원본", b);
            //Cv2.ImShow("틀린 그림", c);

            //Mat d = b - c + 128;

            //Cv2.ImShow("Finish", d);
            Mat a = Cv2.ImRead(@"C:\\Users\\ATI-4\\Desktop\\C\\2.jpg");

            Mat b = a.SubMat(new Rect(0, 0, a.Width / 2, a.Height));
            Mat c = a.SubMat(new Rect(a.Width / 2, 0, a.Width / 2, a.Height));

            Cv2.ImShow("원본", b);
            Cv2.ImShow("틀린 그림", c);

            Mat d = b - c + 128;

            Cv2.ImShow("Finish", d);


            //Mat src = new Mat(@"C:\\Users\\ATI-4\\Desktop\\C\\2.jpg");
            //Mat result = new Mat();
            //Mat bin = new Mat();
            //src.CopyTo(result);
            //CvPoint[] points = new l
        }
    }
}
