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

            //Mat a = Cv2.ImRead(@"C:\\Users\\ATI-4\\Desktop\\C\\2.jpg");

            //Mat b = a.SubMat(new Rect(0, 0, a.Width / 2, a.Height));
            //Mat c = a.SubMat(new Rect(a.Width / 2, 0, a.Width / 2, a.Height));

            //Cv2.ImShow("원본", b);
            //Cv2.ImShow("틀린 그림", c);

            //Mat d = b - c + 128;

            //Cv2.ImShow("Finish", d);

            //Mat src = new Mat(@"C:\\Users\\ATI-4\\Desktop\\C\\2.jpg");
            //Mat dst = new Mat();
            //Cv2.CvtColor(src, src, ColorConversionCodes.BGR2GRAY);
            //Cv2.Threshold(src, src, 0, 255, ThresholdTypes.Otsu);
            //Cv2.ImShow("src", src);

            //Mat element1 = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(7, 7));
            //Mat element2 = Cv2.GetStructuringElement(MorphShapes.Cross, new OpenCvSharp.Size(7, 7));
            //Mat element3 = Cv2.GetStructuringElement(MorphShapes.Ellipse, new OpenCvSharp.Size(7, 7));

            //Cv2.Dilate(src, dst, element1, iterations: 1);
            //Cv2.ImShow("dilate-rect", dst);
            //Cv2.Dilate(src, dst, element2);
            //Cv2.ImShow("dilate-cross", dst);
            //Cv2.Dilate(src, dst, element3);
            //Cv2.ImShow("dilate-Ellipse", dst);

            //Cv2.Erode(src, dst, element1, iterations: 1);
            //Cv2.ImShow("erode-rect", dst);
            //Cv2.Erode(src, dst, element2);
            //Cv2.ImShow("erode-cross", dst);
            //Cv2.Erode(src, dst, element3);
            //Cv2.ImShow("erode-ellipse",dst);

            //Cv2.WaitKey(0);
            //Cv2.DestroyAllWindows();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            Mat basic_image = Cv2.ImRead(@"C:\\Users\\ATI-4\\Desktop\\C\\2.jpg", ImreadModes.Unchanged);
            pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(basic_image);

            Mat left = new Mat();
            Rect rect = new Rect(0, 0, 1799, basic_image.Height);
            left = basic_image.SubMat(rect);

            Mat right = new Mat();
            Rect rect2 = new Rect(1820, 0, 1799, basic_image.Height);
            right = basic_image.SubMat(rect2);

            Mat sub = new Mat();
            Cv2.Subtract(left, right, sub);

            Mat temp = new Mat(sub.Size(), MatType.CV_8UC3);
            Mat gray = new Mat();
            Mat binary = new Mat();
            Mat rebinary = new Mat();
            Mat result = new Mat();
            left.CopyTo(result);

            Cv2.MorphologyEx(sub, temp, MorphTypes.Erode, new Mat(), null, 2);
            for (int i = 0; i < 30; i++)
            {
                Cv2.MorphologyEx(temp, temp, MorphTypes.Dilate, new Mat(), null, 2);
            }

            Cv2.CvtColor(temp, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.Threshold(gray, binary, 15, 255, ThresholdTypes.Binary);
            //이거하려면 이진화 해야함
            Cv2.FindContours(binary, out OpenCvSharp.Point[][] contour, out HierarchyIndex[] hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxSimple);
            // 화면에 오각형이 있으면 꺾이는 점을 기록해서 배열에 넣고 반복 한바퀴해서 돌아오는 것 까지 기록
            label1.Text = contour.Length.ToString();


            //contour라는 Point배열에 이미지의 테두리 좌표값을 다 저장하고
            for (int i = 0; i < contour.Length; i++) //contour.Length 이미지안에 틀린 이미지 개수만큼 반복
            {
                RotatedRect rectt = Cv2.MinAreaRect(contour[i]); // i에 테두리 좌표를 기준으로 가장 작은 사각형을 그림
                for (int j = 0; j < 4; j++) 
                {
                    Cv2.Line(result, new OpenCvSharp.Point(rectt.Points()[j].X, rectt.Points()[j].Y), new OpenCvSharp.Point(rectt.Points()[(j + 1) % 4].X, rectt.Points()[(j + 1) % 4].Y), Scalar.Black, 10, LineTypes.AntiAlias);
                }
            }
            pictureBox2.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(result);
        }
    }
}