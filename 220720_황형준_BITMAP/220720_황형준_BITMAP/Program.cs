// 220720 _ 황형준 _ BITMAP 
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.IO;
using System.Linq;

namespace _220720_황형준_BITMAP
{

    public static class BitmapEx
    {
        public static Bitmap FindThreshold(this Bitmap bm)
        {
            double totalsum = 0;
            double totalavg;
            double mMax = 0;
            double result = 0;
            double allpixel = 0;

            for (int l = 0; l < 256; ++l)
            {
                allpixel += his[l];
                totalsum += his[l] * l;
            }
            totalavg = totalsum / allpixel;

            for (int i = 0; i < 256; ++i)
            {
                int j;
                double presum = 0;
                double totalpresum = 0;
                double preavg = 0;
                double postsum = 0;
                double totalpostsum = 0;
                double postavg = 0;
                double p1 = 0;
                double p2 = 0;
                for (j = 0; j <= i; ++j)
                {
                    presum += his[j];
                    totalpresum += his[j] * j;
                }
                if (presum == 0)
                    continue;
                else
                    preavg = totalpresum / presum;

                for (j = i + 1; j < 256; ++j)
                {
                    postsum += his[j];
                    totalpostsum += his[j] * j;
                }
                if (postsum == 0)
                    continue;
                else
                    postavg = totalpostsum / postsum;

                p1 = presum / totalsum;
                p2 = postsum / totalsum;

                t[i] = sqrt(p1 * pow((preavg - totalavg), 2) + p2 * pow((postavg - totalavg), 2));

                if (mMax < t[i])
                {
                    mMax = t[i];
                    result = i;
                }
            }
            return result;
        }
        public static Bitmap Otsu(this Bitmap bm)
        {
            int row = bm.GetbiHeight();
            int col = bm.GetbiWidth();
            int[] his = Enumerable.Repeat<int>(0, 256).ToArray<int>(); ;
            double[] t = Enumerable.Repeat<double>(0, 256).ToArray<double>();

            byte[] pa = bm.GetBuf();

            for (int l = 0; l < 256; ++l)
            {
                int count = 0;

                for (int i = 0; i < row; ++i)
                {
                    for (int j = 0; j < col; ++j)
                    {
                        if (pa[i * col + j] == l)
                        {
                            count++;
                            his[l] = count;
                        }
                    }
                }
            }

            int n = FindThreshold(t, his);
            Console.WriteLine("{0}",n);
            for (int i = 0; i < row; ++i)
            {
                for (int j = 0; j < col; ++j)
                {
                    if (pa[i * col + j] < n)
                        pa[i * col + j] = 0;
                    else
                        pa[i * col + j] = 255;
                }
            }
            //bm.SetBuf(pix2, row * col);
            return bm;
        }
        public static Bitmap Equalization(this Bitmap bm)
        {
            byte[] newpa = Enumerable.Repeat<byte>(0, 256).ToArray<byte>();
            int[] his = Enumerable.Repeat<int>(0, 256).ToArray<int>();
            int[] sum = Enumerable.Repeat<int>(0, 256).ToArray<int>();
            int count = 0;

            byte[] buf = bm.GetBuf();

            byte[] pix2 = new byte[bm.GetbiHeight() * bm.GetbiWidth()];
            byte[] sum_new = new byte[256];
            for (int k = 0; k < 256; ++k)
            {
                for (int i = 0; i < bm.GetbiHeight(); ++i)
                    for (int j = 0; j < bm.GetbiWidth(); ++j)
                    {
                        if (buf[512 * i + j] == k)
                        {
                            ++count;
                            his[k] = count;
                        }
                    }
                count = 0;
            }

            sum[0] = his[0];
            int row = bm.GetbiWidth();
            int col = bm.GetbiHeight();

            for (int i = 1; i < 256; ++i)
            {
                sum[i] = sum[i - 1] + his[i];
                newpa[i] = (byte)(sum[i] * 255 / (col * row));
            }

            for (int i = 0; i < bm.GetbiHeight(); ++i)
            {
                for (int j = 0; j < bm.GetbiWidth(); ++j)
                {
                    pix2[i * bm.GetbiWidth() + j] = newpa[buf[i * bm.GetbiWidth() + j]];
                }
            }
            bm.SetBuf(pix2, row*col);
            return bm;
        }

        public static Bitmap Dilation(this Bitmap bm)
        {
            byte[] D = new byte[bm.GetSize()];
            byte[] D2 = bm.buf;
            for (int i = 0; i < bm.GetSize(); ++i)
            {
                D[i] = D2[i];
            }
            for (int i = 0; i < bm.hinfo.biHeight; ++i)
            {
                for (int j = 0; j < bm.hinfo.biWidth; ++j)
                {
                    byte max = 0;
                    for (int x = -1; x < 2; ++x)
                    {
                        for (int k = i - 1; k < i + 2; ++k)
                        {
                            if ((j + x >= 512) || (j + x < 0) || (k < 0) || (k >= 512))
                                continue;
                            else
                            {
                                if (max < D[512 * k + j + x])
                                {
                                    max = D[512 * k + j + x];
                                }
                            }
                        }
                    }
                    D2[512 * i + j] = max;
                }
            }
            return bm;
        }
        public static Bitmap Erosion(this Bitmap bm)
            {

                byte[] C = new byte[bm.GetSize()];
                byte[] C2 = bm.buf;

                for (int i = 0; i < bm.GetSize(); ++i)
                {
                    C[i] = C2[i];
                }

                for (int i = 0; i < bm.hinfo.biHeight; ++i)
                {
                    for (int j = 0; j < bm.hinfo.biWidth; ++j)
                    {
                        byte min = 255;
                        for (int x = -1; x < 2; ++x)
                        {
                            for (int k = i - 1; k < i + 2; ++k)
                            {
                                if ((j + x >= 512) || (j + x < 0) || (k < 0) || (k >= 512))
                                    continue;
                                else
                                {
                                    if (min > C[512 * k + j + x])
                                    {
                                        min = C[512 * k + j + x];
                                    }
                                }
                            }
                        }
                        C2[512 * i + j] = min;
                    }
                }
               
                return bm;
            }

        public class Bitmap
        {
            public Bitmap(string n)
            {
                fileName = n;
                byte[] buf = new byte[hinfo.biHeight * hinfo.biWidth];
                ReadFile(n);
            }
            public struct BITMAPFILEHEADER
            {
                public short bfType;
                public int bfSize;
                public short bfReserved1;
                public short bfReserved2;
                public int bfOffBits;
            }
            public struct BITMAPINFOHEADER
            {
                public int biSize;
                public int biWidth;
                public int biHeight;
                public short biPlanes;
                public short biBitCount;
                public int biCompression;
                public int biSizeImage;
                public int biXPelsPerMeter;
                public int biYPelsPerMeter;
                public int biClrUsed;
                public int biClrImportant;
            }
            public struct RGBQUAD
            {
                public byte rgbRed;
                public byte rgbGreen;
                public byte rgbBlue;
                public byte rgbReserved;
            }
            public int width, height;
            public string fileName;
            public BITMAPINFOHEADER hinfo;
            public BITMAPFILEHEADER hf;
            RGBQUAD[] pal = new RGBQUAD[256];
            public byte[] buf;
            public int GetWidth() { return width; }
            public int GetHeight() { return height; }
            public int GetbiWidth() { return hinfo.biWidth; }
            public int GetbiHeight() { return hinfo.biHeight; }
            public int GetSize() { return hinfo.biHeight * hinfo.biWidth; }
            public byte[] GetBuf() { return buf; }
            public void SetBuf(byte[] arg, int size)
            {
                for(int i = 0; i < size; ++i)
                {
                    buf[i] = arg[i];
                }
            }
            
            public void ReadFile(string n)
            {
                using (FileStream fs = new FileStream(n, FileMode.Open))
                {

                    byte[] bftype = new byte[2];
                    fs.Read(bftype, 0, 2);

                    hf.bfType = BitConverter.ToInt16(bftype, 0);
                    Console.WriteLine("type : {0}", hf.bfType);

                    byte[] bfsize = new byte[4];
                    fs.Read(bfsize, 0, 4);
                    hf.bfSize = BitConverter.ToInt32(bfsize, 0);
                    Console.WriteLine("bfsize : {0}", hf.bfSize);

                    byte[] bfReserved1 = new byte[2];
                    fs.Read(bfReserved1, 0, 2);
                    hf.bfReserved1 = BitConverter.ToInt16(bfReserved1, 0);
                    Console.WriteLine("bfReserved1 : {0}", hf.bfReserved1);

                    byte[] bfReserved2 = new byte[2];
                    fs.Read(bfReserved2, 0, 2);
                    hf.bfReserved2 = BitConverter.ToInt16(bfReserved2, 0);
                    Console.WriteLine("bfReserved2 : {0}", hf.bfReserved2);

                    byte[] bfOffBits = new byte[4];
                    fs.Read(bfOffBits, 0, 4);
                    hf.bfOffBits = BitConverter.ToInt32(bfOffBits, 0);
                    Console.WriteLine("bfOffBits : {0}", hf.bfOffBits);

                    Console.WriteLine("=========================");
                    Console.WriteLine("\n");

                    byte[] biSize = new byte[4];
                    fs.Read(biSize, 0, 4);
                    hinfo.biSize = BitConverter.ToInt32(biSize, 0);
                    Console.WriteLine("biSize : {0}", hinfo.biSize);

                    byte[] biWidth = new byte[4];
                    fs.Read(biWidth, 0, 4);
                    hinfo.biWidth = BitConverter.ToInt32(biWidth, 0);
                    Console.WriteLine("biWidth : {0}", hinfo.biWidth);

                    byte[] biHeight = new byte[4];
                    fs.Read(biHeight, 0, 4);
                    hinfo.biHeight = BitConverter.ToInt32(biHeight, 0);
                    Console.WriteLine("biHeight : {0}", hinfo.biHeight);

                    byte[] biPlanes = new byte[2];
                    fs.Read(biPlanes, 0, 2);
                    hinfo.biPlanes = BitConverter.ToInt16(biPlanes, 0);
                    Console.WriteLine("biPlanes : {0}", hinfo.biPlanes);

                    byte[] biBitCount = new byte[2];
                    fs.Read(biBitCount, 0, 2);
                    hinfo.biBitCount = BitConverter.ToInt16(biBitCount, 0);
                    Console.WriteLine("biBitCount : {0}", hinfo.biBitCount);

                    byte[] biCompression = new byte[4];
                    fs.Read(biCompression, 0, 4);
                    hinfo.biCompression = BitConverter.ToInt32(biCompression, 0);
                    Console.WriteLine("biCompression : {0}", hinfo.biCompression);

                    byte[] biSizeImage = new byte[4];
                    fs.Read(biSizeImage, 0, 4);
                    hinfo.biSizeImage = BitConverter.ToInt32(biSizeImage, 0);
                    Console.WriteLine("biSizeImage : {0}", hinfo.biSizeImage);

                    byte[] biXPelsPerMeter = new byte[4];
                    fs.Read(biXPelsPerMeter, 0, 4);
                    hinfo.biXPelsPerMeter = BitConverter.ToInt32(biXPelsPerMeter, 0);
                    Console.WriteLine("biXPelsPerMeter : {0}", hinfo.biXPelsPerMeter);

                    byte[] biYPelsPerMeter = new byte[4];
                    fs.Read(biYPelsPerMeter, 0, 4);
                    hinfo.biYPelsPerMeter = BitConverter.ToInt32(biYPelsPerMeter, 0);
                    Console.WriteLine("biYPelsPerMeter : {0}", hinfo.biYPelsPerMeter);

                    byte[] biClrUsed = new byte[4];
                    fs.Read(biClrUsed, 0, 4);
                    hinfo.biClrUsed = BitConverter.ToInt32(biClrUsed, 0);
                    Console.WriteLine("biClrUsed : {0}", hinfo.biClrUsed);

                    byte[] biClrImportant = new byte[4];
                    fs.Read(biClrImportant, 0, 4);
                    hinfo.biClrImportant = BitConverter.ToInt32(biClrImportant, 0);
                    Console.WriteLine("biClrImportant : {0}", hinfo.biClrImportant);

                    byte[] pal2 = new byte[1024];
                    fs.Read(pal2, 0, 1024);
                    for (int i = 0; i < 256; ++i)
                    {
                        pal[i].rgbRed = pal2[0 + 4 * i];
                        pal[i].rgbGreen = pal2[1 + 4 * i];
                        pal[i].rgbBlue = pal2[2 + 4 * i];
                        pal[i].rgbReserved = pal2[3 + 4 * i];
                    }

                    byte[] buf2 = new byte[hinfo.biWidth * hinfo.biHeight];
                    fs.Read(buf2, 0, hinfo.biWidth * hinfo.biHeight);

                    buf = new byte[hinfo.biWidth * hinfo.biHeight];
                    for (int j = 0; j < hinfo.biWidth * hinfo.biHeight; ++j)
                        buf[j] = buf2[j];

                    Console.WriteLine("=========================");
                }
            }
            public void WriteFile(string n)
            {
                using (FileStream fs = new FileStream(n, FileMode.Create))
                {
                    byte[] bftype = new byte[2];
                    Array.Copy(BitConverter.GetBytes(hf.bfType), 0, bftype, 0, 2);
                    fs.Write(bftype, 0, 2);

                    byte[] bfsize = new byte[4];
                    Array.Copy(BitConverter.GetBytes(hf.bfSize), 0, bfsize, 0, 4);
                    fs.Write(bfsize, 0, 4);

                    byte[] bfReserved1 = new byte[2];
                    Array.Copy(BitConverter.GetBytes(hf.bfReserved1), 0, bfReserved1, 0, 2);
                    fs.Write(bfReserved1, 0, 2);

                    byte[] bfReserved2 = new byte[2];
                    Array.Copy(BitConverter.GetBytes(hf.bfReserved2), 0, bfReserved2, 0, 2);
                    fs.Write(bfReserved2, 0, 2);

                    byte[] bfOffBits = new byte[4];
                    Array.Copy(BitConverter.GetBytes(hf.bfOffBits), 0, bfOffBits, 0, 4);
                    fs.Write(bfOffBits, 0, 4);

                    byte[] biSize = new byte[4];
                    Array.Copy(BitConverter.GetBytes(hinfo.biSize), 0, biSize, 0, 4);
                    fs.Write(biSize, 0, 4);

                    byte[] biWidth = new byte[4];
                    Array.Copy(BitConverter.GetBytes(hinfo.biWidth), 0, biWidth, 0, 4);
                    fs.Write(biWidth, 0, 4);

                    byte[] biHeight = new byte[4];
                    Array.Copy(BitConverter.GetBytes(hinfo.biHeight), 0, biHeight, 0, 4);
                    fs.Write(biHeight, 0, 4);

                    byte[] biPlanes = new byte[2];
                    Array.Copy(BitConverter.GetBytes(hinfo.biPlanes), 0, biPlanes, 0, 2);
                    fs.Write(biPlanes, 0, 2);

                    byte[] biBitCount = new byte[2];
                    Array.Copy(BitConverter.GetBytes(hinfo.biBitCount), 0, biBitCount, 0, 2);
                    fs.Write(biBitCount, 0, 2);

                    byte[] biCompression = new byte[4];
                    Array.Copy(BitConverter.GetBytes(hinfo.biCompression), 0, biCompression, 0, 4);
                    fs.Write(biCompression, 0, 4);

                    byte[] biSizeImage = new byte[4];
                    Array.Copy(BitConverter.GetBytes(hinfo.biSizeImage), 0, biSizeImage, 0, 4);
                    fs.Write(biSizeImage, 0, 4);

                    byte[] biXPelsPerMeter = new byte[4];
                    Array.Copy(BitConverter.GetBytes(hinfo.biXPelsPerMeter), 0, biXPelsPerMeter, 0, 4);
                    fs.Write(biXPelsPerMeter, 0, 4);

                    byte[] biYPelsPerMeter = new byte[4];
                    Array.Copy(BitConverter.GetBytes(hinfo.biYPelsPerMeter), 0, biYPelsPerMeter, 0, 4);
                    fs.Write(biYPelsPerMeter, 0, 4);

                    byte[] biClrUsed = new byte[4];
                    Array.Copy(BitConverter.GetBytes(hinfo.biClrUsed), 0, biClrUsed, 0, 4);
                    fs.Write(biClrUsed, 0, 4);

                    byte[] biClrImportant = new byte[4];
                    Array.Copy(BitConverter.GetBytes(hinfo.biClrImportant), 0, biClrImportant, 0, 4);
                    fs.Write(biClrImportant, 0, 4);

                    byte[] pal2 = new byte[1024];
                    Spal();

                    for (int i = 0; i < 256; ++i)
                    {
                        Array.Copy(BitConverter.GetBytes(pal[i].rgbRed), 0, pal2, 0 + 4 * i, 1);
                        Array.Copy(BitConverter.GetBytes(pal[i].rgbGreen), 0, pal2, 1 + 4 * i, 1);
                        Array.Copy(BitConverter.GetBytes(pal[i].rgbBlue), 0, pal2, 2 + 4 * i, 1);
                        Array.Copy(BitConverter.GetBytes(pal[i].rgbReserved), 0, pal2, 3 + 4 * i, 1);
                    }
                    fs.Write(pal2, 0, 1024);

                    byte[] buf2 = new byte[hinfo.biWidth * hinfo.biHeight];

                    for (int j = 0; j < hinfo.biWidth * hinfo.biHeight; ++j)
                        Array.Copy(BitConverter.GetBytes(buf[j]), 0, buf2, j, 1);
                    fs.Write(buf2, 0, hinfo.biWidth * hinfo.biHeight);
                }
                void Spal()
                {
                    for (int i = 0; i < 256; ++i)
                    {
                        pal[i].rgbRed = (byte)i;
                        pal[i].rgbGreen = (byte)i;
                        pal[i].rgbBlue = (byte)i;
                        pal[i].rgbReserved = (byte)i;
                    }
                }
            }

            class Program
            {
                static void Main(string[] args)
                {
                    Bitmap bitmap = new Bitmap("lena_gray.bmp");

                    bitmap.WriteFile("lena_gray1.bmp");

                    Bitmap Q = new Bitmap("lena_gray.bmp");
                    BitmapEx.Equalization(Q);
                    Q.WriteFile("평활.bmp");

                    Bitmap D = new Bitmap("lena_gray.bmp");
                    BitmapEx.Dilation(D);
                    D.WriteFile("팽창.bmp");

                    Bitmap E = new Bitmap("lena_gray.bmp");
                    BitmapEx.Erosion(E);
                    E.WriteFile("수축.bmp");


                    //Bitmap bitmap = new Bitmap("lena_gray1.bmp");

                    //bitmap.("lena_gray1.bmp");
                }
            }
        }
    }
}
