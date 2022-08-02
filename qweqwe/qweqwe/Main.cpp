#include<iostream>
#include<fstream>

using namespace std;
typedef unsigned char uchar;

struct bitmapheader
{
    short bfType = 19778;
    int bfSize;
    short bfReserved1 = 0;
    short bfReserved2 = 0;
    int bf0ffBits = 1078;
};
struct bitmapinfoheader
{
    int biSize = 40;
    int biWidth;
    int biHeight;
    short biPlanes = 1;
    short biBitCount = 8;
    int biCompression = 0;
    int biSizeImage = 0;
    int biXPelsPerMeter = 2844;
    int biYPelsPerMeter = 2844;
    int biClrUsed = 0;
    int biClrImportant = 0;
};
struct pallete
{
    uchar rgbtBlue;
    uchar rgbtGreen;
    uchar rgbtRed;
    uchar rgbReserved;
};
class MYBITMAP
{
private:
    int width;
    int height;
    uchar* buf;

    string fileName;
    bitmapheader hd;
    bitmapinfoheader hI;
    pallete pa[256];

public:
    MYBITMAP(int w = 0, int h = 0) :width(w), height(h) { Gray(pa); }
    /*MYBITMAP()
    {

    }*/
    ~MYBITMAP()
    {
        buf != nullptr;
        delete[] buf;
    }
    int GetWidth() { return width; }
    int GetHeight() { return height; }

    MYBITMAP(const string& fn) :fileName(fn)
    {
        ifstream ifs(fn, ios::binary);

        //ifs.read((char*)&hd, sizeof(uchar));

        ifs.read((char*)&hd.bfType, sizeof(short));
        ifs.read((char*)&hd.bfSize, sizeof(int));
        ifs.read((char*)&hd.bfReserved1, sizeof(short));
        ifs.read((char*)&hd.bfReserved2, sizeof(short));
        ifs.read((char*)&hd.bf0ffBits, sizeof(int));

        ifs.read((char*)&hI.biSize, sizeof(int));
        ifs.read((char*)&hI.biWidth, sizeof(int));
        ifs.read((char*)&hI.biHeight, sizeof(int));
        ifs.read((char*)&hI.biPlanes, sizeof(short));
        ifs.read((char*)&hI.biBitCount, sizeof(short));
        ifs.read((char*)&hI.biCompression, sizeof(int));
        ifs.read((char*)&hI.biSizeImage, sizeof(int));
        ifs.read((char*)&hI.biXPelsPerMeter, sizeof(int));
        ifs.read((char*)&hI.biYPelsPerMeter, sizeof(int));
        ifs.read((char*)&hI.biClrUsed, sizeof(int));
        ifs.read((char*)&hI.biClrImportant, sizeof(int));

        ifs.read((char*)pa, sizeof(pallete) * 256);

        buf = new uchar[hI.biWidth * hI.biHeight];
        ifs.read((char*)buf, hI.biWidth * hI.biHeight);
    }
    //gray
    void Gray(pallete hRGB[])
    {
        for (int i = 0; i < 256; ++i)
        {
            hRGB[i].rgbtBlue = i;
            hRGB[i].rgbtGreen = i;
            hRGB[i].rgbtRed = i;
            hRGB[i].rgbReserved = i;
        }
    }
    //gradation
    void SetBuf(uchar* buf)
    {
        for (int i = 0; i < 500; ++i)
        {
            for (int k = 0; k < 500; ++k)
            {
                buf[500 * i + k] = (i * 256 / 500 + k * 256 / 500) / 2;
            }
        }
    }

    void Save(const string& fn)
    {
        ofstream ofs(fn, ios::binary);

        hI.biWidth = width;
        hI.biHeight = height;
        hd.bfSize = width * height + 1078 + 2;

        ofs.write((char*)&hd.bfType, sizeof(short));
        ofs.write((char*)&hd.bfSize, sizeof(int));
        ofs.write((char*)&hd.bfReserved1, sizeof(short));
        ofs.write((char*)&hd.bfReserved2, sizeof(short));
        ofs.write((char*)&hd.bf0ffBits, sizeof(int));

        ofs.write((char*)&hI.biSize, sizeof(int));
        ofs.write((char*)&hI.biWidth, sizeof(int));
        ofs.write((char*)&hI.biHeight, sizeof(int));
        ofs.write((char*)&hI.biPlanes, sizeof(short));
        ofs.write((char*)&hI.biBitCount, sizeof(short));
        ofs.write((char*)&hI.biCompression, sizeof(int));
        ofs.write((char*)&hI.biSizeImage, sizeof(int));
        ofs.write((char*)&hI.biXPelsPerMeter, sizeof(int));
        ofs.write((char*)&hI.biYPelsPerMeter, sizeof(int));
        ofs.write((char*)&hI.biClrUsed, sizeof(int));
        ofs.write((char*)&hI.biClrImportant, sizeof(int));

        ofs.write((char*)pa, sizeof(pallete) * 256);

        buf = new uchar[hI.biWidth * hI.biHeight];
        //fill_n(buf, hI.biWidth * hI.biHeight, 0);            //black
        //SetBuf(buf);                                 //gradation

        ofs.write((char*)buf, hI.biWidth * hI.biHeight);      //buf : 배열
    }
};

int main()
{
    //MYBITMAP bm("..\\Lena_Image.bmp");
    //bm.Save("..\\Lena_Image_t.bmp");

    MYBITMAP A(500, 500);
    MYBITMAP B = MYBITMAP(500, 500);
    MYBITMAP C = MYBITMAP(500, 500);

    //A.Save("..\\1234.bmp");            //black
    //B.Save("..\\123456.bmp");         //gray
    //C.Save("..\\12334456.bmp");         //gradation 
}

//#include <iostream>
//#include <fstream>
//#include <string>
//#include <conio.h>
//using namespace std;
//typedef unsigned char uchar;
//#pragma pack(push, 1)
//struct Point
//{
//
//    Point(int _x = 0, int _y = 0) :x(_x), y(_y) {}
//    int x;
//    int y;
//    int GetX()const { return x; }
//    int GetY()const { return y; }
//    ~Point() {}
//};
//struct BITMAPFILEHEADER
//{
//    char bfType[2] = "";
//    int bfSize = 0;
//    short bfReserved1 = 0;
//    short bfReserved2 = 0;
//    int bfOffBits = 0;
//} hf;
//struct BITMAPINFOHEADER
//{
//    int biSize = 0;
//    int biWidth = 0;
//    int biHeight = 0;
//    short biPlanes = 0;
//    short biBitCount = 0;
//    int biCompression = 0;
//    int biSizeImage = 0;
//    int biXPelsPerMeter = 0;
//    int biYPelsPerMeter = 0;
//    int biClrUsed = 0;
//    int biClrImportant = 0;
//} hInfo;
//struct RGBQUAD
//{
//    uchar rgbBlue;
//    uchar rgbGreen;
//    uchar rgbRed;
//    uchar rgbReserved;
//};
//#pragma pack(pop)
//class Bitmap
//{
//private:
//    int width, height;
//    uchar* buf;
//    string fileName;
//    RGBQUAD pa[256];
//public:
//    Bitmap(int _width = 0, int _height = 0) : buf(nullptr), width(_width), height(_height) {}
//    Bitmap(const string& fN) : fileName(fN) { InitReadFile(fN); }
//    ~Bitmap() { }
//    int GetWidth() { return width; }
//    int GetHeight() { return height; }
//    int GetbiWidth() { return hInfo.biWidth; }
//    int GetbiHeight() { return hInfo.biHeight; }
//    int GetSize() { return hInfo.biHeight * hInfo.biWidth; }
//    uchar* GetBuf() { return buf; }
//    void InitReadFile(string fN)
//    {
//        ifstream ifs(fN, ios::binary);
//
//        ifs.read((char*)&hf.bfType, sizeof(short));
//        cout << "bfType : " << hf.bfType << endl;
//
//        ifs.read((char*)&hf.bfSize, sizeof(int));
//        cout << "hf.bfSize : " << hf.bfSize << endl;
//
//        ifs.read((char*)&hf.bfReserved1, sizeof(short));
//        cout << "hf.bfReserved1 : " << hf.bfReserved1 << endl;
//
//        ifs.read((char*)&hf.bfReserved2, sizeof(short));
//        cout << "hf.bfReserved2 : " << hf.bfReserved2 << endl;
//
//        ifs.read((char*)&hf.bfOffBits, sizeof(int));
//        cout << "hf.bfOffBits : " << hf.bfOffBits << endl;
//
//        ifs.read((char*)&hInfo.biSize, sizeof(int));
//        cout << "hInfo.biSize : " << hInfo.biSize << endl;
//
//        ifs.read((char*)&hInfo.biWidth, sizeof(int));
//        cout << "hInfo.biWidth : " << hInfo.biWidth << endl;
//
//        ifs.read((char*)&hInfo.biHeight, sizeof(int));
//        cout << "hInfo.biHeight : " << hInfo.biHeight << endl;
//
//        ifs.read((char*)&hInfo.biPlanes, sizeof(short));
//        cout << "hInfo.biPlanes : " << hInfo.biPlanes << endl;
//
//        ifs.read((char*)&hInfo.biBitCount, sizeof(short));
//        cout << "hInfo.biBitCount : " << hInfo.biBitCount << endl;
//
//        ifs.read((char*)&hInfo.biCompression, sizeof(int));
//        cout << "hInfo.biCompression : " << hInfo.biCompression << endl;
//
//        ifs.read((char*)&hInfo.biSizeImage, sizeof(int));
//        cout << "hInfo.biSizeImage : " << hInfo.biSizeImage << endl;
//
//        ifs.read((char*)&hInfo.biXPelsPerMeter, sizeof(int));
//        cout << "hInfo.biXPelsPerMeter : " << hInfo.biXPelsPerMeter << endl;
//
//        ifs.read((char*)&hInfo.biYPelsPerMeter, sizeof(int));
//        cout << "hInfo.biYPelsPerMeter : " << hInfo.biYPelsPerMeter << endl;
//
//        ifs.read((char*)&hInfo.biClrUsed, sizeof(int));
//        cout << "hInfo.biClrUsed : " << hInfo.biClrUsed << endl;
//
//        ifs.read((char*)&hInfo.biClrImportant, sizeof(int));
//        cout << "hInfo.biClrImportant : " << hInfo.biClrImportant << endl;
//
//        ifs.read((char*)&pa, 1024);
//        cout << "pa : " << pa << endl;
//
//        cout << "====================================================" << endl;
//        buf = new uchar[GetSize()];
//        int size = hInfo.biHeight * hInfo.biWidth;
//        ifs.read((char*)buf, size * sizeof(uchar));
//    }
//    void InitWriteFile(string fN)
//    {
//        ofstream ofs(fN, ios::binary);
//
//        ofs.write((char*)&hf.bfType, sizeof(short));
//        ofs.write((char*)&hf.bfSize, sizeof(int));
//        ofs.write((char*)&hf.bfReserved1, sizeof(short));
//        ofs.write((char*)&hf.bfReserved2, sizeof(short));
//        ofs.write((char*)&hf.bfOffBits, sizeof(int));
//
//        ofs.write((char*)&hInfo.biSize, sizeof(int));
//        ofs.write((char*)&hInfo.biWidth, sizeof(int));
//        ofs.write((char*)&hInfo.biHeight, sizeof(int));
//        ofs.write((char*)&hInfo.biPlanes, sizeof(short));
//        ofs.write((char*)&hInfo.biBitCount, sizeof(short));
//        ofs.write((char*)&hInfo.biCompression, sizeof(int));
//        ofs.write((char*)&hInfo.biSizeImage, sizeof(int));
//        ofs.write((char*)&hInfo.biXPelsPerMeter, sizeof(int));
//        ofs.write((char*)&hInfo.biYPelsPerMeter, sizeof(int));
//        ofs.write((char*)&hInfo.biClrUsed, sizeof(int));
//        ofs.write((char*)&hInfo.biClrImportant, sizeof(int));
//        ofs.write((char*)&pa, 1024);
//
//        int size = hInfo.biHeight * hInfo.biWidth;
//        ofs.write((char*)GetBuf(), size * sizeof(uchar));
//    }
//
//    void InitWriteFile(uchar* _buf, int a, int b, string fn)
//    {
//        ofstream ofs(fn, ios::binary);
//        char bfType[2] = { 'B','M' };
//        ofs.write((char*)bfType, sizeof(short));
//        int bfsize = 1078 + sizeof(uchar) * (a * b) + 2;
//        ofs.write((char*)&bfsize, sizeof(int));
//        ofs.write((char*)&hf.bfReserved1, sizeof(short));
//        ofs.write((char*)&hf.bfReserved2, sizeof(short));
//        ofs.write((char*)&hf.bfOffBits, sizeof(int));
//        ofs.write((char*)&hInfo.biSize, sizeof(int));
//        int width = a;
//        ofs.write((char*)&width, sizeof(int));
//        int height = b;
//        ofs.write((char*)&height, sizeof(int));
//        ofs.write((char*)&hInfo.biPlanes, sizeof(short));
//        ofs.write((char*)&hInfo.biBitCount, sizeof(short));
//        ofs.write((char*)&hInfo.biCompression, sizeof(int));
//        ofs.write((char*)&hInfo.biSizeImage, sizeof(int));
//        ofs.write((char*)&hInfo.biXPelsPerMeter, sizeof(int));
//        ofs.write((char*)&hInfo.biYPelsPerMeter, sizeof(int));
//        ofs.write((char*)&hInfo.biClrUsed, sizeof(int));
//        ofs.write((char*)&hInfo.biClrImportant, sizeof(int));
//        ofs.write((char*)pa, 1024);
//        int size = width * height;
//        ofs.write((char*)_buf, size * sizeof(uchar));
//        delete[] buf;
//    }
//    void SetBuf(uchar* bm)
//    {
//        for (int i = 0; i < hInfo.biHeight * hInfo.biWidth; ++i)
//        {
//            buf[i] = bm[i];
//        }
//    }
//    void SetPa()
//    {
//        for (int i = 0; i < 256; ++i)
//        {
//            pa[i].rgbRed = i;
//            pa[i].rgbBlue = i;
//            pa[i].rgbGreen = i;
//            pa[i].rgbReserved = i;
//        }
//    }
//    const Bitmap& operator = (const Bitmap& arg)
//    {
//        for (int i = 0; i < hInfo.biHeight * hInfo.biWidth; ++i)
//        {
//            buf[i] = arg.buf[i];
//        }
//        return *this;
//    }
//    void Pix(uchar* buf2, int size)
//    {
//        int k = 0;
//        int s = 0;
//        for (int x = 0; x < 512; ++x)
//        {
//            for (int y = 0; y < 512; ++y)
//            {
//                buf2[512 * x + y] = (x * 256 / 512 + y * 256 / 512) / 2;
//            }
//        }
//    }
//    void Pix(uchar* _buf2, const Point& pt, int _width, int _height)
//    {
//        for (int y = _height - 1; y >= 0; --y)
//        {
//            for (int x = _width - 1; x >= 0; --x)
//            {
//                _buf2[(_height * (_height - 1 - y) + x)] = buf[(512 * (511 - (y + pt.GetY())) + ((x + pt.GetX())))];
//            }
//        }
//    }
//    void Gradation(string fN)
//    {
//        ofstream ofs(fN, ios::binary);
//        char bfType[2] = { 'B','M' };
//        ofs.write((char*)bfType, sizeof(short));
//
//        int bfSize = 0;
//        ofs.write((char*)&hf.bfSize, sizeof(int));
//
//        int bfReserved1 = 0;
//        ofs.write((char*)&hf.bfReserved1, sizeof(short));
//
//        int bfReserved2 = 0;
//        ofs.write((char*)&hf.bfReserved2, sizeof(short));
//
//        int bf0ffButs = 1078;
//        ofs.write((char*)&hf.bfOffBits, sizeof(int));
//
//        int biSize = 40;
//        ofs.write((char*)&hInfo.biSize, sizeof(int));
//
//        int biWidth = 500;
//        ofs.write((char*)&hInfo.biWidth, sizeof(int));
//
//        int biHeight = 500;
//        ofs.write((char*)&hInfo.biHeight, sizeof(int));
//
//        int biPlanes = 1;
//        ofs.write((char*)&hInfo.biPlanes, sizeof(short));
//
//        int biBitCount = 8;
//        ofs.write((char*)&hInfo.biBitCount, sizeof(short));
//
//        int biCompression = 0;
//        ofs.write((char*)&hInfo.biCompression, sizeof(int));
//
//        int biSizeImage = 0;
//        ofs.write((char*)&hInfo.biSizeImage, sizeof(int));
//
//        int biXPelsPerMeter = 2834;
//        ofs.write((char*)&hInfo.biXPelsPerMeter, sizeof(int));
//
//        int biYPelsPerMeter = 2834;
//        ofs.write((char*)&hInfo.biYPelsPerMeter, sizeof(int));
//
//        int biClrUsed = 0;
//        ofs.write((char*)&hInfo.biClrUsed, sizeof(int));
//
//        int biClrImportant = 0;
//        ofs.write((char*)&hInfo.biClrImportant, sizeof(int));
//        SetPa();
//        ofs.write((char*)pa, 1024);
//        int size = biHeight * biWidth;
//        uchar* buf2 = new uchar[biWidth * biHeight];
//        Pix(buf2, size);
//        ofs.write((char*)buf2, size * sizeof(uchar));
//        delete[] buf;
//    }
//};
//
//void Util()
//{
//    cout << "=====================" << endl;
//    cout << "   [1] - Dilation" << endl;
//    cout << "   [2] - Erosion" << endl;
//    cout << "   [3] - Gradation" << endl;
//    cout << "   [4] - Part" << endl;
//    cout << "   [5] - Equalization " << endl;
//    cout << "   [6] - ostu" << endl;
//    cout << "   [0] - 프로그램 종료" << endl;
//    cout << "=====================" << endl;
//}
//Bitmap Erosion(Bitmap& bit)
//{
//    uchar* C = new uchar[bit.GetSize()]{ 0 };
//    uchar* C2 = bit.GetBuf();
//
//    for (int i = 0; i < bit.GetSize(); ++i)
//    {
//        C[i] = C2[i];
//    }
//
//    for (int i = 0; i < bit.GetbiHeight(); ++i)
//    {
//        for (int j = 0; j < bit.GetbiWidth(); ++j)
//        {
//            int min = 256;
//            for (int x = -1; x < 2; ++x)
//            {
//                for (int k = i - 1; k < i + 2; ++k)
//                {
//                    if ((j + x >= 512) || (j + x < 0) || (k < 0) || (k >= 512))
//                        continue;
//                    else
//                    {
//                        if (min > C[512 * k + j + x])
//                        {
//                            min = C[512 * k + j + x];
//                        }
//                    }
//                }
//            }
//            C2[512 * i + j] = min;
//        }
//    }
//    delete[] C;
//    return bit;
//}
//Bitmap Dilation(Bitmap& bit)
//{
//    uchar* D = new uchar[bit.GetSize()]{ 0 };
//    uchar* D2 = bit.GetBuf();
//
//    for (int i = 0; i < bit.GetSize(); ++i)
//    {
//        D[i] = D2[i];
//    }
//    for (int i = 0; i < bit.GetbiHeight(); ++i)
//    {
//        for (int j = 0; j < bit.GetbiWidth(); ++j)
//        {
//            int max = 0;
//            for (int x = -1; x < 2; ++x)
//            {
//                for (int k = i - 1; k < i + 2; ++k)
//                {
//                    if ((j + x >= 512) || (j + x < 0) || (k < 0) || (k >= 512))
//                        continue;
//                    else {
//                        if (max < D[512 * k + j + x])
//                        {
//                            max = D[512 * k + j + x];
//                        }
//                    }
//                }
//            }
//            D2[512 * i + j] = max;
//        }
//    }
//    delete[] D;
//    return bit;
//}
//void PartialSaveImage(Bitmap& bit, const Point& pt, int a, int b, string fn)
//{
//    uchar* buf2 = new uchar[a * b];
//    bit.Pix(buf2, pt, a, b);
//    bit.InitWriteFile(buf2, a, b, fn);
//    delete[] buf2;
//}
//
//void PartialSaveImage(Bitmap& bit, const Point& pt, const Point& pt2, string fn)
//{
//    int width = abs((pt2.GetX() - pt.GetX()));
//    int height = abs((pt2.GetY() - pt.GetY()));
//    int ptlength = sqrt(pt.GetX() * pt.GetX() + pt.GetY() * pt.GetY());
//    int pt2length = sqrt(pt2.GetX() * pt2.GetX() + pt2.GetY() * pt2.GetY());
//    uchar* buf2 = new uchar[height * width];
//    if (ptlength < pt2length)
//        bit.Pix(buf2, pt, width, height);
//    else
//        bit.Pix(buf2, pt2, width, height);
//
//    bit.InitWriteFile(buf2, width, height, fn);
//
//    delete[] buf2;
//}
//void Equalization(Bitmap& bit)
//{
//    for (int l = 0; l < 256; ++l)
//    {
//        int count = 0;
//
//        for (int i = 0; i < bit.GetbiHeight(); ++i)
//        {
//            for (int j = 0; j < bit.GetbiWidth(); ++j)
//            {
//                if (pa[i][j] == l)
//                {
//                    count++;
//                    hist[l] = count;
//                }
//            }
//        }
//    }
//}
//void Otsu(Bitmap& bit)
//{
//
//}
//int main()
//{
//    Bitmap D("lena_gray.bmp");
//    Bitmap C("lena_gray.bmp");
//    Bitmap B("lena_gray.bmp");
//    Bitmap P1("lena_gray.bmp");
//
//    int run = 1;
//    int dcount = 0;
//    int ccount = 0;
//
//    while (run)
//    {
//        Util();
//        switch (_getch())
//        {
//        case '1':
//        {
//
//            string Dil = "팽창 ";
//            string typebmp = " .bmp";
//            Dilation(D);
//            Dil.append(to_string(dcount));
//            Dil.append(typebmp);
//            D.InitWriteFile(Dil);
//            ++dcount;
//        }
//        break;
//
//        case '2':
//        {
//
//            string Ero = "수축 ";
//            string typebmp = " .bmp";
//            Erosion(C);
//            Ero.append(to_string(ccount));
//            Ero.append(typebmp);
//            C.InitWriteFile(Ero);
//            ++ccount;
//        }
//        break;
//
//        case '3':
//        {
//            B.Gradation("gradation.bmp");
//        }
//        break;
//
//        case '4':
//        {
//            PartialSaveImage(P1, Point(0, 0), 60, 60, "SelectPart.bmp");
//        }
//        break;
//
//        case '5':
//        {
//            //Equalization();
//        }
//        case '6':
//        {
//            //ostu();
//        }
//        case '0':
//        {
//            run = 0;
//        }
//        break;
//
//        default:
//            break;
//            //Bitmap bm;
//            //bm.Bitmapopen("lena_gray.bmp");
//
//            //bm.InitReadFile("lena_gray.bmp");
//            //bm.InitWriteFile("lena_gray1.bmp");
//            //bm.Black("11.bmp");
//        }
//
//    }
//}
//
//
////#include <iostream>
////#include <fstream>
////#include <string>
////#include <conio.h>
////using namespace std;
////typedef unsigned char uchar;
////#pragma pack(push, 1)
////struct Point 
////{
////
////    Point(int _x = 0, int _y = 0) :x(_x), y(_y) {}
////    int x;
////    int y;
////    int GetX()const { return x; }
////    int GetY()const { return y; }
////    ~Point() {}
////};
////struct BITMAPFILEHEADER
////{
////    char bfType[2] = "";
////    int bfSize = 0;
////    short bfReserved1 = 0;
////    short bfReserved2 = 0;
////    int bfOffBits = 0;
////} hf;
////struct BITMAPINFOHEADER
////{
////    int biSize = 0;
////    int biWidth = 0;
////    int biHeight = 0;
////    short biPlanes = 0;
////    short biBitCount = 0;
////    int biCompression = 0;
////    int biSizeImage = 0;
////    int biXPelsPerMeter = 0;
////    int biYPelsPerMeter = 0;
////    int biClrUsed = 0;
////    int biClrImportant = 0;
////} hInfo;
////struct RGBQUAD
////{
////    uchar rgbBlue;
////    uchar rgbGreen;
////    uchar rgbRed;
////    uchar rgbReserved;
////};
////#pragma pack(pop)
////class Bitmap
////{
////private:
////    int width, height;
////    uchar* buf;
////    string fileName;
////    RGBQUAD pa[256];
////public:
////    Bitmap(int _width = 0, int _height = 0 ) : buf(nullptr), width(_width), height(_height) {}
////    Bitmap(const string& fN) : fileName(fN) {InitReadFile(fN); }
////    ~Bitmap() { }
////    int GetWidth() { return width; }
////    int GetHeight() { return height; }
////    int GetbiWidth() { return hInfo.biWidth; }
////    int GetbiHeight() { return hInfo.biHeight; }
////    int GetSize() { return hInfo.biHeight * hInfo.biWidth; }
////    uchar* GetBuf(){ return buf; }
////    void InitReadFile(string fN)
////    {
////        ifstream ifs(fN, ios::binary);
////
////        ifs.read((char*)&hf.bfType, sizeof(short));
////        cout << "bfType : " << hf.bfType << endl;
////
////        ifs.read((char*)&hf.bfSize, sizeof(int));
////        cout << "hf.bfSize : " << hf.bfSize << endl;
////
////        ifs.read((char*)&hf.bfReserved1, sizeof(short));
////        cout << "hf.bfReserved1 : " << hf.bfReserved1 << endl;
////
////        ifs.read((char*)&hf.bfReserved2, sizeof(short));
////        cout << "hf.bfReserved2 : " << hf.bfReserved2 << endl;
////
////        ifs.read((char*)&hf.bfOffBits, sizeof(int));
////        cout << "hf.bfOffBits : " << hf.bfOffBits << endl;
////
////        ifs.read((char*)&hInfo.biSize, sizeof(int));
////        cout << "hInfo.biSize : " << hInfo.biSize << endl;
////
////        ifs.read((char*)&hInfo.biWidth, sizeof(int));
////        cout << "hInfo.biWidth : " << hInfo.biWidth << endl;
////
////        ifs.read((char*)&hInfo.biHeight, sizeof(int));
////        cout << "hInfo.biHeight : " << hInfo.biHeight << endl;
////
////        ifs.read((char*)&hInfo.biPlanes, sizeof(short));
////        cout << "hInfo.biPlanes : " << hInfo.biPlanes << endl;
////
////        ifs.read((char*)&hInfo.biBitCount, sizeof(short));
////        cout << "hInfo.biBitCount : " << hInfo.biBitCount << endl;
////
////        ifs.read((char*)&hInfo.biCompression, sizeof(int));
////        cout << "hInfo.biCompression : " << hInfo.biCompression << endl;
////
////        ifs.read((char*)&hInfo.biSizeImage, sizeof(int));
////        cout << "hInfo.biSizeImage : " << hInfo.biSizeImage << endl;
////
////        ifs.read((char*)&hInfo.biXPelsPerMeter, sizeof(int));
////        cout << "hInfo.biXPelsPerMeter : " << hInfo.biXPelsPerMeter << endl;
////
////        ifs.read((char*)&hInfo.biYPelsPerMeter, sizeof(int));
////        cout << "hInfo.biYPelsPerMeter : " << hInfo.biYPelsPerMeter << endl;
////
////        ifs.read((char*)&hInfo.biClrUsed, sizeof(int));
////        cout << "hInfo.biClrUsed : " << hInfo.biClrUsed << endl;
////
////        ifs.read((char*)&hInfo.biClrImportant, sizeof(int));
////        cout << "hInfo.biClrImportant : " << hInfo.biClrImportant << endl;
////
////        ifs.read((char*)&pa, 1024);
////        cout << "pa : " << pa << endl;
////
////        cout << "====================================================" << endl;
////        buf = new uchar[GetSize()];
////        int size = hInfo.biHeight * hInfo.biWidth;
////        ifs.read((char*)buf, size * sizeof(uchar));
////    }
////    void InitWriteFile(string fN)
////    {
////        ofstream ofs(fN, ios::binary);
////
////        ofs.write((char*)&hf.bfType, sizeof(short));
////        ofs.write((char*)&hf.bfSize, sizeof(int));
////        ofs.write((char*)&hf.bfReserved1, sizeof(short));
////        ofs.write((char*)&hf.bfReserved2, sizeof(short));
////        ofs.write((char*)&hf.bfOffBits, sizeof(int));
////
////        ofs.write((char*)&hInfo.biSize, sizeof(int));
////        ofs.write((char*)&hInfo.biWidth, sizeof(int));
////        ofs.write((char*)&hInfo.biHeight, sizeof(int));
////        ofs.write((char*)&hInfo.biPlanes, sizeof(short));
////        ofs.write((char*)&hInfo.biBitCount, sizeof(short));
////        ofs.write((char*)&hInfo.biCompression, sizeof(int));
////        ofs.write((char*)&hInfo.biSizeImage, sizeof(int));
////        ofs.write((char*)&hInfo.biXPelsPerMeter, sizeof(int));
////        ofs.write((char*)&hInfo.biYPelsPerMeter, sizeof(int));
////        ofs.write((char*)&hInfo.biClrUsed, sizeof(int));
////        ofs.write((char*)&hInfo.biClrImportant, sizeof(int));
////        ofs.write((char*)&pa, 1024);
////
////        int size = hInfo.biHeight * hInfo.biWidth;
////        ofs.write((char*)GetBuf(), size * sizeof(uchar));
////    }
////
////    void InitWriteFile(uchar* _buf, int a, int b, string fn)
////    {
////        ofstream ofs(fn, ios::binary);
////        char bfType[2] = { 'B','M' };
////        ofs.write((char*)bfType, sizeof(short));
////        int bfsize = 1078 + sizeof(uchar) * (a * b) + 2;
////        ofs.write((char*)&bfsize, sizeof(int));
////        ofs.write((char*)&hf.bfReserved1, sizeof(short));
////        ofs.write((char*)&hf.bfReserved2, sizeof(short));
////        ofs.write((char*)&hf.bfOffBits, sizeof(int));
////        ofs.write((char*)&hInfo.biSize, sizeof(int));
////        int width = a;
////        ofs.write((char*)&width, sizeof(int));
////        int height = b;
////        ofs.write((char*)&height, sizeof(int));
////        ofs.write((char*)&hInfo.biPlanes, sizeof(short));
////        ofs.write((char*)&hInfo.biBitCount, sizeof(short));
////        ofs.write((char*)&hInfo.biCompression, sizeof(int));
////        ofs.write((char*)&hInfo.biSizeImage, sizeof(int));
////        ofs.write((char*)&hInfo.biXPelsPerMeter, sizeof(int));
////        ofs.write((char*)&hInfo.biYPelsPerMeter, sizeof(int));
////        ofs.write((char*)&hInfo.biClrUsed, sizeof(int));
////        ofs.write((char*)&hInfo.biClrImportant, sizeof(int));
////        ofs.write((char*)pa, 1024);
////        int size = width * height;
////        ofs.write((char*)_buf, size * sizeof(uchar));
////        delete[] buf;
////
////    }
////    void SetBuf(uchar* bm)
////    {
////        for (int i = 0; i < hInfo.biHeight * hInfo.biWidth; ++i)
////        {
////            buf[i] = bm[i];
////        }
////    }
////    void SetPa()
////    {
////        for (int i = 0; i < 256; ++i)
////        {
////            pa[i].rgbRed = i;
////            pa[i].rgbBlue = i;
////            pa[i].rgbGreen = i;
////            pa[i].rgbReserved = i;
////        }
////    }
////   const Bitmap& operator = (const Bitmap& arg)
////    {
////        for (int i = 0; i < hInfo.biHeight * hInfo.biWidth; ++i)
////        {
////            buf[i] = arg.buf[i];
////        }
////        return *this;
////    } 
////   void Pix(uchar* buf2, int size)
////   {
////       int k = 0;
////       int s = 0;
////       for (int x = 0; x < 512; ++x)
////       {
////           for (int y = 0; y < 512; ++y)
////           {
////               buf2[512 * x + y] = (x * 256 / 512 + y * 256 / 512) / 2;
////           }
////       }
////   }
////   void Pix(uchar* _buf2, const Point& pt, int _width, int _height)
////   {
////       for (int y = _height - 1; y >= 0; --y)
////       {
////           for (int x = _width - 1; x >= 0; --x)
////           {
////               _buf2[(_height * (_height - 1 - y) + x)] = buf[(512 * (511 - (y + pt.GetY())) + ((x + pt.GetX())))];
////           }
////       }
////   }
////    void Gradation(string fN)
////    {
////        ofstream ofs(fN, ios::binary);
////        char bfType[2] = { 'B','M' };
////        ofs.write((char*)bfType, sizeof(short));
////
////        int bfSize = 0;
////        ofs.write((char*)&hf.bfSize, sizeof(int));
////
////        int bfReserved1 = 0;
////        ofs.write((char*)&hf.bfReserved1, sizeof(short));
////
////        int bfReserved2 = 0;
////        ofs.write((char*)&hf.bfReserved2, sizeof(short));
////
////        int bf0ffButs = 1078;
////        ofs.write((char*)&hf.bfOffBits, sizeof(int));
////
////        int biSize = 40;
////        ofs.write((char*)&hInfo.biSize, sizeof(int));
////
////        int biWidth = 500;
////        ofs.write((char*)&hInfo.biWidth, sizeof(int));
////        
////        int biHeight = 500;
////        ofs.write((char*)&hInfo.biHeight, sizeof(int));
////
////        int biPlanes = 1;
////        ofs.write((char*)&hInfo.biPlanes, sizeof(short));
////
////        int biBitCount = 8;
////        ofs.write((char*)&hInfo.biBitCount, sizeof(short));
////
////        int biCompression = 0;
////        ofs.write((char*)&hInfo.biCompression, sizeof(int));
////
////        int biSizeImage = 0;
////        ofs.write((char*)&hInfo.biSizeImage, sizeof(int));
////
////        int biXPelsPerMeter = 2834;
////        ofs.write((char*)&hInfo.biXPelsPerMeter, sizeof(int));
////
////        int biYPelsPerMeter = 2834;
////        ofs.write((char*)&hInfo.biYPelsPerMeter, sizeof(int));
////
////        int biClrUsed = 0;
////        ofs.write((char*)&hInfo.biClrUsed, sizeof(int));
////
////        int biClrImportant = 0;
////        ofs.write((char*)&hInfo.biClrImportant, sizeof(int));
////        SetPa();
////        ofs.write((char*)pa, 1024);
////        int size = biHeight * biWidth;
////        uchar* buf2 = new uchar[biWidth * biHeight];
////        Pix(buf2, size);
////        ofs.write((char*)buf2, size * sizeof(uchar));
////        delete[] buf;
////    }
////};
////
////void Util()
////{
////    cout << "=====================" << endl;
////    cout << "1. Dilation" << endl;
////    cout << "2. Erosion" << endl;
////    cout << "3. Gradation" << endl;
////    cout << "4. part" << endl;
////    cout << "0. 프로그램 종료" << endl;
////    cout << "=====================" << endl;
////}
////Bitmap Erosion(Bitmap& bit)
////{
////    uchar* C = new uchar[bit.GetSize()]{ 0 };
////    uchar* C2 = bit.GetBuf();
////
////    for (int i = 0; i < bit.GetSize(); ++i)
////    {
////        C[i] = C2[i];
////    }
////
////    for (int i = 0; i < bit.GetbiHeight(); ++i)
////    {
////        for (int j = 0; j < bit.GetbiWidth(); ++j)
////        {
////            int min = 256;
////            for (int x = -1; x < 2; ++x)
////            {
////                for (int k = i - 1; k < i + 2; ++k)
////                {
////                    if ((j + x >= 512) || (j + x < 0) || (k < 0) || (k >= 512))
////                        continue;
////                    else
////                    {
////                        if (min > C[512 * k + j + x])
////                        {
////                            min = C[512 * k + j + x];
////                        }
////                    }
////                }
////            }
////            C2[512 * i + j] = min;
////        }
////    }
////    delete[] C;
////    return bit;
////}
////Bitmap Dilation(Bitmap& bit)
////{
////    uchar* D = new uchar[bit.GetSize()]{ 0 };
////    uchar* D2 = bit.GetBuf();
////
////    for (int i = 0; i < bit.GetSize(); ++i)
////    {
////        D[i] = D2[i];
////    }
////    for (int i = 0; i < bit.GetbiHeight(); ++i)
////    {
////        for (int j = 0; j < bit.GetbiWidth(); ++j)
////        {
////            int max = 0;
////            for (int x = -1; x < 2; ++x)
////            {
////                for (int k = i - 1; k < i + 2; ++k)
////                {
////                    if ((j + x >= 512) || (j + x < 0) || (k < 0) || (k >= 512))
////                        continue;
////                    else {
////                        if (max < D[512 * k + j + x])
////                        {
////                            max = D[512 * k + j + x];
////                        }
////                    }
////                }
////            }
////            D2[512 * i + j] = max;
////        }
////    }
////    delete[] D;
////    return bit;
////}
////void PartialSaveImage(Bitmap& bit, const Point& pt, int a, int b, string fn)
////{
////    uchar* buf2 = new uchar[a * b];
////    bit.Pix(buf2, pt, a, b);
////    bit.InitWriteFile(buf2, a, b, fn);
////    delete[] buf2;
////}
////
////void PartialSaveImage(Bitmap& bit, const Point& pt, const Point& pt2, string fn)
////{
////    int width = abs((pt2.GetX() - pt.GetX()));
////    int height = abs((pt2.GetY() - pt.GetY()));
////    int ptlength = sqrt(pt.GetX() * pt.GetX() + pt.GetY() * pt.GetY());
////    int pt2length = sqrt(pt2.GetX() * pt2.GetX() + pt2.GetY() * pt2.GetY());
////    uchar* buf2 = new uchar[height * width];
////    if (ptlength < pt2length)
////        bit.Pix(buf2, pt, width, height);
////    else
////        bit.Pix(buf2, pt2, width, height);
////
////    bit.InitWriteFile(buf2, width, height, fn);
////
////    delete[] buf2;
////}
////int main()
////{
////    Bitmap D("lena_gray.bmp");
////    Bitmap C("lena_gray.bmp");
////    Bitmap A("lena_gray.bmp");
////    Bitmap B("lena_gray.bmp");
////    Bitmap P1("lena_gray.bmp");
////    Bitmap P2("lena_gray.bmp");
////
////    int run = 1;
////    int dcount = 0;
////    int ccount = 0;
////
////    while (run)
////    {
////        Util();
////        switch (_getch())
////        {
////        case '1':
////        {
////
////            string Dil = "팽창 ";
////            string typebmp = " .bmp";
////            Dilation(D);
////            Dil.append(to_string(dcount));
////            Dil.append(typebmp);
////            D.InitWriteFile(Dil);
////            ++dcount;
////        }
////        break;
////
////        case '2': 
////        {
////
////            string Ero = "수축 ";
////            string typebmp = " .bmp";
////            Erosion(C);
////            Ero.append(to_string(ccount));
////            Ero.append(typebmp);
////            C.InitWriteFile(Ero);
////            ++ccount;
////        }
////        break;
////
////        case '3':
////        {
////            B.Gradation("gradation.bmp");
////        }
////        break;
////
////        case '4':
////        {
////            PartialSaveImage(P1, Point(0, 0), 60, 60, "SelectPart.bmp");
////        }
////        break;
////
////        case '0':
////        {
////            run = 0;
////        }
////        break;
////
////        default:
////            break;
////            //Bitmap bm;
////            //bm.Bitmapopen("lena_gray.bmp");
////
////            //bm.InitReadFile("lena_gray.bmp");
////            //bm.InitWriteFile("lena_gray1.bmp");
////            //bm.Black("11.bmp");
////        }
////
////    }
////}
////
//
////#include <iostream>
////#include <algorithm>
////#include <fstream>
////#include <string>
////using namespace std;
////typedef unsigned char UC;
////
////struct HeaderData
////{
////    short bfType = 19778;
////    int bfSize;
////    short bfReserved1 = 0;
////    short bfReserved2 = 0;
////    int bfOffbits = 1078;
////};
////
////struct InfoHeader
////{
////    int biSize = 40;
////    int biWidth;
////    int biHeight;
////    short biPlanes = 1;
////    short biBitCount = 8;
////    int biCompression = 0;
////    int biSizeImage = 0;
////    int biXPelsPerMeter = 2844;
////    int biYPelsPerMeter = 2844;
////    int biClrUsed = 0;
////    int biClrimportant = 0;
////};
////
////struct tagRGBQUAD
////{
////    UC rgbBlue;
////    UC rgbGreen;
////    UC rgbRed;
////    UC rgbReserved;
////};
////
////struct Point
////{
////    int x;
////    int y;
////};
////
////class MYBITMAP
////{
////private:
////    Point pt;
////    string filename;
////    int w, h, sp;
////    UC* data;
////    HeaderData hd;
////    InfoHeader ih;
////    tagRGBQUAD pal[256];
////
////public:
////    MYBITMAP(string filename) :filename(filename)
////    {
////        InitReadFile(filename);
////    }
////    MYBITMAP(string filename, int w, int h) :filename(filename), w(w), h(h)
////    {
////        hd.bfSize = (w * h + 1078 + 2);
////        ih.biWidth = w;
////        ih.biHeight = h;
////        rgbquad_gray_exchange(pal);
////
////        data = new UC[w * h];
////        fill_n(data, w * h, 0);
////    }
////    MYBITMAP(const MYBITMAP& arg) :w(arg.w), h(arg.h), sp(arg.sp)
////    {
////        hd.bfSize = arg.hd.bfType;
////        ih.biHeight = arg.ih.biHeight;
////        ih.biWidth = arg.ih.biWidth;
////        //delete[] data;
////
////        data = new UC[arg.ih.biWidth * arg.ih.biHeight];
////        for (int i = 0; i < ih.biWidth * ih.biHeight; ++i)
////        {
////            data[i] = arg.data[i];
////        }
////    }
////
////    ~MYBITMAP() { delete[] data; }
////
////    UC* GetData() { return data; }
////    int GetIHW() { return ih.biWidth; }
////    int GetIHH() { return ih.biHeight; }
////
////    void SetData(UC* arg, int size)
////    {
////        for (int i = 0; i < size; ++i)
////        {
////            data[i] = arg[i];
////        }
////    }
////
////    MYBITMAP& operator=(const MYBITMAP& arg)
////    {
////        if (this == &arg)
////            return *this;
////
////        hd.bfSize = arg.hd.bfSize;
////        ih.biHeight = arg.ih.biHeight;
////        ih.biWidth = arg.ih.biWidth;
////        delete[] data;
////        data = new UC[ih.biWidth * ih.biHeight];
////        for (int i = 0; i < ih.biWidth * ih.biHeight; ++i)
////        {
////            data[i] = arg.data[i];
////        }
////        return *this;
////    }
////
////    MYBITMAP CutData(Point pt, int dw, int dh)
////    {
////        int posi = pt.x + (pt.y * ih.biHeight);
////
////        MYBITMAP tempMB("temp", dw, dh);
////        UC* ddata = new UC(dw * dh);
////
////        for (int i = 0; i < dw * dh; ++i)
////        {
////            ddata[i] = data[posi + (i % dw) + ((i / dw) * ih.biHeight)];
////        }
////
////        tempMB.SetData(ddata, dw * dh);
////        delete[] ddata;
////        return tempMB;
////    }
////
////    void rgbquad_gray_exchange(tagRGBQUAD hRGB[])
////    {
////        for (int i = 0; i < 256; ++i)
////        {
////            hRGB[i].rgbRed = i;
////            hRGB[i].rgbBlue = i;
////            hRGB[i].rgbGreen = i;
////            hRGB[i].rgbReserved = i;
////        }
////    }
////    void InitReadFile(string fn)
////    {
////        ifstream ifs(fn, ios::binary);
////        ifs.read((char*)&hd.bfType, sizeof(short));
////        ifs.read((char*)&hd.bfSize, sizeof(int));
////        ifs.read((char*)&hd.bfReserved1, sizeof(short));
////        ifs.read((char*)&hd.bfReserved2, sizeof(short));
////        ifs.read((char*)&hd.bfOffbits, sizeof(int));
////
////        ifs.read((char*)&ih.biSize, sizeof(int));
////        ifs.read((char*)&ih.biWidth, sizeof(int));
////        ifs.read((char*)&ih.biHeight, sizeof(int));
////        ifs.read((char*)&ih.biPlanes, sizeof(short));
////        ifs.read((char*)&ih.biBitCount, sizeof(short));
////        ifs.read((char*)&ih.biCompression, sizeof(int));
////        ifs.read((char*)&ih.biSizeImage, sizeof(int));
////        ifs.read((char*)&ih.biXPelsPerMeter, sizeof(int));
////        ifs.read((char*)&ih.biYPelsPerMeter, sizeof(int));
////        ifs.read((char*)&ih.biClrUsed, sizeof(int));
////        ifs.read((char*)&ih.biClrimportant, sizeof(int));
////
////        ifs.read((char*)pal, sizeof(tagRGBQUAD) * 256);
////
////        w = ih.biWidth;
////        h = ih.biHeight;
////        sp = hd.bfOffbits;
////        data = new UC[ih.biWidth * ih.biHeight];
////        ifs.read((char*)data, sizeof(UC) * w * h);
////        ifs.close();
////    }
////
////    const void MakeImage()const
////    {
////        ofstream ofs(filename, ios::binary);
////
////        ofs.write((char*)&hd.bfType, sizeof(short));
////        ofs.write((char*)&hd.bfSize, sizeof(int));
////        ofs.write((char*)&hd.bfReserved1, sizeof(short));
////        ofs.write((char*)&hd.bfReserved2, sizeof(short));
////        ofs.write((char*)&hd.bfOffbits, sizeof(int));
////
////        ofs.write((char*)&ih.biSize, sizeof(int));
////        ofs.write((char*)&ih.biWidth, sizeof(int));
////        ofs.write((char*)&ih.biHeight, sizeof(int));
////        ofs.write((char*)&ih.biPlanes, sizeof(short));
////        ofs.write((char*)&ih.biBitCount, sizeof(short));
////        ofs.write((char*)&ih.biCompression, sizeof(int));
////        ofs.write((char*)&ih.biSizeImage, sizeof(int));
////        ofs.write((char*)&ih.biXPelsPerMeter, sizeof(int));
////        ofs.write((char*)&ih.biYPelsPerMeter, sizeof(int));
////        ofs.write((char*)&ih.biClrUsed, sizeof(int));
////        ofs.write((char*)&ih.biClrimportant, sizeof(int));
////        ofs.write((char*)pal, sizeof(tagRGBQUAD) * 256);
////
////        ofs.write((char*)data, sizeof(UC) * w * h);
////        ofs.close();
////    }
////
////    void HSetData()
////    {
////        for (int i = 0; i < w * h; ++i)
////        {
////            data[i] = (i % w) * (255.0 / w);
////        }
////    }
////
////    void DSetData()
////    {
////        for (int i = 0; i < w * h; ++i)
////        {
////            int x = i % w;
////            int y = i / h;
////            data[i] = ((x + y) / 2) * (255.0 / w);
////        }
////    }
////};
////
////MYBITMAP& Dilation(MYBITMAP& arg)
////{
////    int w = arg.GetIHW();
////    int h = arg.GetIHH();
////    UC* data = arg.GetData();
////    UC* ddata = new UC[w * h];
////
////    for (int i = 0; i < w * h; ++i)
////    {
////        int max = 0;
////        for (int py = -1; py <= 1; ++py)
////        {
////            for (int px = -1; px <= 1; ++px)
////            {
////                int posi = i + px + (h * py);
////
////                if (posi<0 || posi>w * h)
////                {
////                    continue;
////                }
////                if (i % w == 0 && px < 0 || i % w == w - 1 && px > 0)
////                {
////                    continue;
////                }
////                if (data[posi] > max)
////                {
////                    max = data[posi];
////                }
////            }
////        }
////        ddata[i] = max;
////    }
////    arg.SetData(ddata, w * h);
////    delete[]ddata;
////    return arg;
////}
////MYBITMAP& Erosion(MYBITMAP& arg)
////{
////    int w = arg.GetIHW();
////    int h = arg.GetIHH();
////    UC* data = arg.GetData();
////    UC* ddata = new UC[w * h];
////
////    for (int i = 0; i < w * h; ++i)
////    {
////        int min = 255;
////        for (int py = -1; py <= 1; ++py)
////        {
////            for (int px = -1; px <= 1; ++px)
////            {
////                int posi = i + px + (h * py);
////
////                if (posi<0 || posi>w * h)
////                {
////                    continue;
////                }
////                if (i % w == 0 && px < 0 || i % w == w - 1 && px > 0)
////                {
////                    continue;
////                }
////                if (data[posi] < min)
////                {
////                    min = data[posi];
////                }
////            }
////        }
////        ddata[i] = min;
////    }
////    arg.SetData(ddata, w * h);
////    delete[]ddata;
////    return arg;
////}
////string MakeFileName(string defalut, int i)
////{
////    return defalut + to_string(i) + ".bmp";
////}
////
////int main()
////{
////    int dcount = 0;
////
////    MYBITMAP MB("..\\lena_gray.bmp");
////
////    MYBITMAP MB5("..\\cut_lena.bmp", MB.GetIHW(), MB.GetIHH());
////    MB5 = MB.CutData(Point{ 0, 0 }, 40, 40);
////
////
////    MYBITMAP MB1("..\\Gradation1.bmp",500,500);
////    MB1.HSetData();
////    MB1.MakeImage();
////
////    MYBITMAP MB2("..\\Gradation2.bmp",500,500);
////    MB2.DSetData();
////    MB2.MakeImage();
////
////    MYBITMAP MB3("..\\lena_gray_copy.bmp", MB.GetIHW(), MB.GetIHH());
////    MB3.SetData(MB.GetData(),MB.GetIHW()*MB.GetIHH());
////    MB3.MakeImage();
////    
////    dcount = 10;
////    //cin >> dcount;
////
////    //for (int i = 1; i <= dcount; ++i)
////    //{
////    //   string fn = MakeFileName("..\\Dilation",i);
////    //   MYBITMAP MB4(fn, MB3.GetIHW(), MB3.GetIHH());
////    //   MB4 = Dilation(MB3);
////    //   MB4.MakeImage();
////    //}
////
////    //MB3.SetData(MB.GetData(), MB.GetIHW() * MB.GetIHH());
////    //for (int i = 1; i <= dcount; ++i)
////    //{
////    //   string fn = MakeFileName("..\\Erosion", i);
////    //   MYBITMAP MB5(fn, MB3.GetIHW(), MB3.GetIHH());
////    //   MB5 = Erosion(MB3);
////    //   MB5.MakeImage();
////    //}
////
////}
//
////#pragma warning (disable : 26495)
////#include <iostream>
////#include <fstream>
////using namespace std;
////typedef unsigned char uchar;
////#pragma pack(push, 1)
////struct BITMAPFILEHEADER
////{
////    unsigned short bfType;
////    unsigned int bfSize;
////    unsigned short bfReserved1;
////    unsigned short bfReserved2;
////    unsigned int bfOffBits;
////} hf;
////struct BITMAPINFOHEADER
////{
////    unsigned int biSize;
////    int biWidth;
////    int biHeight;
////    unsigned short biPlanes;
////    unsigned short biBitCount;
////    unsigned int biCompression;
////    unsigned int biSizeImage;
////    int biXPelsPerMeter;
////    int biYPelsPerMeter;
////    unsigned int biClrUsed;
////    unsigned int biClrImportant;
////} hInfo;
////struct RGBQUAD
////{
////    uchar rgbBlue;
////    uchar rgbGreen;
////    uchar rgbRed;
////    uchar rgbReserved;
////};
////#pragma pack(pop)
////class Bitmap
////{
////private:
////    int width, height;
////    uchar* buf;
////    string fileName;
////    RGBQUAD pal[256];
////    uchar* pixel;
////
////public:
////    //buf (col * y + x) = x,y
////    Bitmap() :width(0), height(0), buf(nullptr) {}
////
////    void  Bitmapopen(string fn)
////    {
////        InitReadFile(fn);
////        /*  ifstream ifs(fileName, ios::binary);*/
////    }
////    ~Bitmap() {}
////
////    int GetWidth() { return width; }
////    int GetHeight() { return height; }
////    void InitReadFile(string fileName)
////    {
////        ifstream ifs(fileName, ios::binary);
////       
////        ifs.read((char*)&hf.bfType, sizeof(short));
////        cout << "bfType : " << hf.bfType << endl;
////
////        ifs.read((char*)&hf.bfSize, sizeof(int));
////        cout << "hf.bfSize : " << hf.bfSize << endl;
////
////        ifs.read((char*)&hf.bfReserved1, sizeof(short));
////        cout << "hf.bfReserved1 : " << hf.bfReserved1 << endl;
////
////        ifs.read((char*)&hf.bfReserved2, sizeof(short));
////        cout << "hf.bfReserved2 : " << hf.bfReserved2 << endl;
////
////        ifs.read((char*)&hf.bfOffBits, sizeof(int));
////        cout << "hf.bfOffBits : " << hf.bfOffBits << endl;
////
////        ifs.read((char*)&hInfo.biSize, sizeof(int));
////        cout << "hInfo.biSize : " << hInfo.biSize << endl;
////
////        ifs.read((char*)&hInfo.biWidth, sizeof(int));
////        cout << "hInfo.biWidth : " << hInfo.biWidth << endl;
////        
////        ifs.read((char*)&hInfo.biHeight, sizeof(int));
////        cout << "hInfo.biHeight : " << hInfo.biHeight << endl;
////        
////        ifs.read((char*)&hInfo.biPlanes, sizeof(short));
////        cout << "hInfo.biPlanes : " << hInfo.biPlanes << endl;
////
////        ifs.read((char*)&hInfo.biBitCount, sizeof(short));
////        cout << "hInfo.biBitCount : " << hInfo.biBitCount << endl;
////
////        ifs.read((char*)&hInfo.biCompression, sizeof(int));
////        cout << "hInfo.biCompression : " << hInfo.biCompression << endl;
////
////        ifs.read((char*)&hInfo.biSizeImage, sizeof(int));
////        cout << "hInfo.biSizeImage : " << hInfo.biSizeImage << endl;
////
////        ifs.read((char*)&hInfo.biXPelsPerMeter, sizeof(int));
////        cout << "hInfo.biXPelsPerMeter : " << hInfo.biXPelsPerMeter << endl;
////
////        ifs.read((char*)&hInfo.biYPelsPerMeter, sizeof(int));
////        cout << "hInfo.biYPelsPerMeter : " << hInfo.biYPelsPerMeter << endl;
////
////        ifs.read((char*)&hInfo.biClrUsed, sizeof(int));
////        cout << "hInfo.biClrUsed : " << hInfo.biClrUsed << endl;
////
////        ifs.read((char*)&hInfo.biClrImportant, sizeof(int));
////        cout << "hInfo.biClrImportant : " << hInfo.biClrImportant << endl;
////
////        ifs.read((char*)&pal, 1024);
////        cout << "pal : " << pal << endl;
////
////        cout << "====================================================" <<endl;
////        buf = new uchar[hInfo.biHeight * hInfo.biWidth];
////        int size = hInfo.biHeight * hInfo.biWidth;
////        ifs.read((char*)buf, size);
////    }
////    void InitWriteFile(string fileName)
////    {
////        ofstream ofs(fileName, ios::binary);
////
////        ofs.write((char*)&hf.bfType, sizeof(short));
////        ofs.write((char*)&hf.bfSize, sizeof(int));
////        ofs.write((char*)&hf.bfReserved1, sizeof(short));
////        ofs.write((char*)&hf.bfReserved2, sizeof(short));
////        ofs.write((char*)&hf.bfOffBits, sizeof(int));
////
////        ofs.write((char*)&hInfo.biSize, sizeof(int));
////        ofs.write((char*)&hInfo.biWidth, sizeof(int));
////        ofs.write((char*)&hInfo.biHeight, sizeof(int));
////        ofs.write((char*)&hInfo.biPlanes, sizeof(short));
////        ofs.write((char*)&hInfo.biBitCount, sizeof(short));
////        ofs.write((char*)&hInfo.biCompression, sizeof(int));
////        ofs.write((char*)&hInfo.biSizeImage, sizeof(int));
////        ofs.write((char*)&hInfo.biXPelsPerMeter, sizeof(int));
////        ofs.write((char*)&hInfo.biYPelsPerMeter, sizeof(int));
////        ofs.write((char*)&hInfo.biClrUsed, sizeof(int));
////        ofs.write((char*)&hInfo.biClrImportant, sizeof(int));
////        ofs.write((char*)&pal, 1024);
////
////        ofs.write((char*)buf, hInfo.biHeight * hInfo.biWidth);
////    }
////    void Black(string fileName)
////    {
////        ofstream ofs(fileName, ios::binary);
////        char bfType[2] = { 'B','M' };
////        ofs.write((char*)bfType, sizeof(short));
////
////        int bfSize = 0;
////        ofs.write((char*)&hf.bfSize, sizeof(int));
////
////        int bfReserved1 = 0;
////        ofs.write((char*)&hf.bfReserved1, sizeof(short));
////
////        int bfReserved2 = 0;
////        ofs.write((char*)&hf.bfReserved2, sizeof(short));
////
////        int bf0ffButs = 1078;
////        ofs.write((char*)&hf.bfOffBits, sizeof(int));
////
////        int biSize = 40;
////        ofs.write((char*)&hInfo.biSize, sizeof(int));
////
////        int biWidth = 512;
////        ofs.write((char*)&hInfo.biWidth, sizeof(int));
////
////        int biHeight = 512;
////        ofs.write((char*)&hInfo.biHeight, sizeof(int));
////
////        int biPlanes = 1;
////        ofs.write((char*)&hInfo.biPlanes, sizeof(short));
////
////        int biBitCount = 8;
////        ofs.write((char*)&hInfo.biBitCount, sizeof(short));
////
////        int biCompression = 0;
////        ofs.write((char*)&hInfo.biCompression, sizeof(int));
////
////        int biSizeImage = 0;
////        ofs.write((char*)&hInfo.biSizeImage, sizeof(int));
////
////        int biXPelsPerMeter = 2834;
////        ofs.write((char*)&hInfo.biXPelsPerMeter, sizeof(int));
////
////        int biYPelsPerMeter = 2834;
////        ofs.write((char*)&hInfo.biYPelsPerMeter, sizeof(int));
////
////        int biClrUsed = 0;
////        ofs.write((char*)&hInfo.biClrUsed, sizeof(int));
////
////        int biClrImportant = 0;
////        ofs.write((char*)&hInfo.biClrImportant, sizeof(int));
////
////        void Gray(RGBQUAD hRGB[])
////        {
////            for (int i = 0; i < 256; ++i)
////            {
////                hRGB[i].rgbRed = i;
////                hRGB[i].rgbBlue = i;
////                hRGB[i].rgbGreen = i;
////                hRGB[i].rgbReserved = i;
////            }
////        }
////        pixel = AllocMemory(hInfo.biHeight, hInfo.biWidth);
////        ofs.write((char*)&pal, 1024);
////
////        ofs.write((char*)buf, hInfo.biHeight * hInfo.biWidth);
////    }
////};
////int main()
////{
////    Bitmap bm;
////    bm.Bitmapopen("lena_gray.bmp");
////
////    bm.InitReadFile("lena_gray.bmp");
////    bm.InitWriteFile("lena_gray1.bmp");
////    bm.Black("11.bmp");
////}
