using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ImageControllerApp
{
    interface ImageSource
    {
        List<string> ReadData();
    }
    interface ImageLog
    {
        void WriteLog(string result);
    }
    class MemoryImageLog : ImageLog // Console장치
    {
        public void WriteLog(string result)
        {
            Console.WriteLine(result);
        }
    }
    class FileImageLog : ImageLog
    {
        public void WriteLog(string result)
        {
            string logName = "data.log";
            using (StreamWriter sw = new StreamWriter(logName))
            {
                sw.WriteLine("이미지 처리 결과: {0}", result);
            }
        }
    }
    class MemoryDataSource : ImageSource
    {
        public List<string> ReadData()
        {
            List<string> lt = new List<string>();
            lt.Add("a");
            lt.Add("b");
            lt.Add("c");

            return lt;
        }
    }
    class FileDataSource : ImageSource
    {
        public List<string> ReadData()
        {
            StreamReader sr = new StreamReader("image.txt");
            List<string> lt = new List<string>();
            while (!sr.EndOfStream)
                lt.Add(sr.ReadLine());

            return lt;
        }
    }
    class ImageProcessor
    {
        List<string> imageDataList;
        public ImageProcessor(List<string> lt)
        {
            imageDataList = lt;
        }
        public string Action()
        {
            return imageDataList.Aggregate("", (acc, item) => acc + "," + item);
        }
    }
    class ImageController
    {
        ImageProcessor imageProcess;
        ImageSource imageSource;
        ImageLog imageLog;
        List<string> imageDataList = new List<string>();

        public ImageController(ImageSource fds, ImageLog fil)
        {
            imageProcess = new ImageProcessor(imageDataList);
            imageSource = fds;
            imageLog = fil;
        }

        public void Run()
        {
            //1. 파일 읽기
            var lt = imageSource.ReadData();
            lt.ForEach((item) => imageDataList.Add(item));
            // 파일 읽기 성공

            //2. 이미지 처리
            string result = imageProcess.Action();

            //3. 결과 로그 저장
            imageLog.WriteLog(result);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ImageController ic = new ImageController(new MemoryDataSource(), new MemoryImageLog());
            ic.Run();
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.IO;
//using System.Threading.Tasks;

//namespace ImageControllerApp
//{
//    interface ImageSource
//    {
//        List<string> ReadData();
//    }
//    interface ImageLog
//    {
//        void WriteLog(string result);
//    }
//    class FileImageLog : ImageLog
//    {
//        public void WriteLog(string result)
//        {
//            string logName = "data.log";
//            using (StreamWriter sw = new StreamWriter(logName))
//            {
//                sw.WriteLine("이미지 처리 결과: {0}", result);
//            }
//        }
//    }
//    class FileDataSource : ImageSource
//    {
//        public List<string> ReadData()
//        {
//            StreamReader sr = new StreamReader("image.txt");
//            List<string> lt = new List<string>();
//            while (!sr.EndOfStream)
//                lt.Add(sr.ReadLine());

//            return lt;
//        }
//    }
//    class ImageProcessor
//    {
//        List<string> imageDataList;
//        public ImageProcessor(List<string> lt)
//        {
//            imageDataList = lt;
//        }
//        public string Action()
//        {
//            return imageDataList.Aggregate("", (acc, item) => acc + "," + item);
//        }
//    }
//    class ImageController
//    {
//        ImageProcessor imageProcess;
//        ImageSource imageSource;
//        ImageLog imageLog;
//        List<string> imageDataList = new List<string>();

//        public ImageController(ImageSource fds, ImageLog fil)
//        {
//            imageProcess = new ImageProcessor(imageDataList);
//            imageSource = fds;
//            imageLog = fil;
//        }

//        public void Run()
//        {
//            //1. 파일 읽기
//            var lt = imageSource.ReadData();
//            lt.ForEach((item) => imageDataList.Add(item));
//            // 파일 읽기 성공

//            //2. 이미지 처리
//            string result = imageProcess.Action();

//            //3. 결과 로그 저장
//            imageLog.WriteLog(result);
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            ImageController ic = new ImageController(new FileDataSource(), new FileImageLog());
//            ic.Run();
//        }

//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.IO;
//using System.Threading.Tasks;
//namespace ImageControllerApp
//{
//    interface ImageSource
//    {
//        List<string> ReadData();
//    }
//    interface ImageLog
//    {
//        void WriteLog(string result);
//    }
//    class FileImageLog : ImageLog
//    {
//        public void WriteLog(string result)
//        {
//            string logName = "data.log";
//            using (StreamWriter sw = new StreamWriter(logName))
//            {
//                sw.WriteLine("Image Process 결과 : {0}", result);
//            }
//        }
//    }
//    class FileDataSource : ImageSource
//    {
//        public List<string> ReadData()
//        {
//            StreamReader sr = new StreamReader("image.txt");
//            List<string> lt = new List<string>();
//            while (!sr.EndOfStream)
//            {
//                string data = sr.ReadLine();
//                lt.Add(data);
//            }
//            return lt;
//        }
//    }
//    class ImageProcessor
//    {
//        List<string> imageDataList;
//        public ImageProcessor(List<string> lt)
//        {
//            imageDataList = lt;
//        }
//        public string Action()
//        {
//            return imageDataList.Aggregate("", (acc, item) => acc + "," + item);
//        }
//    }

//    public class ImageController
//    {
//        ImageProcessor imageProcess;
//        ImageLog imageLog;
//        List<string> imageDataList = new List<string>();
//        ImageSource imageSource;
//        public ImageController()
//        {
//            imageProcess = new ImageProcessor(imageDataList);
//            imageSource = new FileDataSource();
//            imageLog = new FileImageLog();
//        }

//        public void Run()
//        {
//            // 1.파일 열기
//            var lt = imageSource.ReadData();
//            lt.ForEach((item) => imageDataList.Add(item));
//            //2. 이미지 처리

//            string result = imageProcess.Action();
//            Console.WriteLine(result);
//            //3. 결과로그 저장
//            imageLog.WriteLog(result);
//        }
//    }

//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            ImageController ic = new ImageController();
//            ic.Run();
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.IO;
//using System.Threading.Tasks;

//namespace ImageControllerApp
//{
//    interface ImageSource
//    {
//        List<string> ReadData();
//    }
//    class FileDataSource : ImageSource
//    {
//        public List<string> ReadData()
//        {
//            StreamReader sr = new StreamReader("image.txt");
//            List<string> lt = new List<string>();
//            while (!sr.EndOfStream)
//            {
//                string data = sr.ReadLine();
//                lt.Add(data);
//            }
//            return lt;
//        }
//    }
//    class ImageProcessor
//    {
//        List<string> imageDataList;
//        public ImageProcessor(List<string> lt)
//        {
//            imageDataList = lt;
//        }
//        public string Action()
//        {
//            return imageDataList.Aggregate("", (acc, item) => acc + "," + item);
//        }
//    }

//    public class ImageController
//    {
//        ImageProcessor imageProcess;
//        List<string> imageDataList = new List<string>();
//        ImageSource imageSource;
//        public ImageController()
//        {
//            imageProcess = new ImageProcessor(imageDataList);
//            imageSource = new FileDataSource();
//        }

//        public void Run()
//        {
//            // 1.파일 열기
//            var lt = imageSource.ReadData();
//            lt.ForEach((item) => imageDataList.Add(item));
//            //2. 이미지 처리

//            string result = imageProcess.Action();
//            Console.WriteLine(result);
//            //3. 결과로그 저장

//            string logName = "data.log";
//            using (StreamWriter sw = new StreamWriter(logName))
//            {
//                sw.WriteLine("Image Process 결과 : {0}", result);
//            }
//        }
//    }

//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            ImageController ic = new ImageController();
//            ic.Run();
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.IO;
//using System.Threading.Tasks;

//namespace ImageControllerApp
//{
//    class ImageProcessor
//    {
//        List<string> imageDataList;
//        public ImageProcessor(List<string> lt)
//        {
//            imageDataList = lt;
//        }
//        public string Action()
//        {
//            return imageDataList.Aggregate("", (acc, item) => acc + "," + item);
//        }
//    }

//    public class ImageController
//    {
//        ImageProcessor imageProcess;
//        List<string> imageDataList = new List<string>();
//        public ImageController()
//        {
//            imageProcess = new ImageProcessor(imageDataList);
//        }

//        public void Run()
//        {
//            // 1.파일 열기
//            StreamReader sr = new StreamReader("image.txt");
//            while (!sr.EndOfStream)
//            {
//                string data = sr.ReadLine();
//                imageDataList.Add(data);
//            }

//            //2. 이미지 처리
//            string result = imageProcess.Action();

//            //3. 결과로그 저장

//            string logName = "data.log";
//            using (StreamWriter sw = new StreamWriter(logName))
//            {
//                sw.WriteLine("Image Process 결과 : {0}", result);
//            }

//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            ImageController ic = new ImageController();
//            ic.Run();
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.IO;
//using System.Threading.Tasks;

//namespace ImageControllerApp
//{
//    public class ImageController
//    {
//        List<string> imageDataList = new List<string>();
//        public void Run()
//        {
//            //1. 파일 읽기
//            StreamReader ws = new StreamReader("image.txt");
//            while (!ws.EndOfStream)
//            {
//                string data = ws.ReadLine();
//                imageDataList.Add(data);
//            }
//            // 파일 읽기 성공

//            //2. 이미지 처리
//            Console.WriteLine("이미지 처리 오류 찾기~");
//            imageDataList.ForEach((image) =>
//            {
//                Console.WriteLine("처리 데이터 : {0}", image);
//            });

//            //3. 결과 로그 저장
//            string logName = "data.log";
//            StreamWriter sw = new StreamWriter(logName);
//            sw.WriteLine("이미지 처리 결과: {0}", imageDataList.Count);
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            ImageController ic = new ImageController();
//            ic.Run();
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ImageControllerApp
//{
//    class ImageController
//    {
//        public void Run()
//        {
//            //1. 파일 읽기
//            string fileName = Console.ReadLine();
//            // 파일 읽기 성공
//            Console.WriteLine("이미지 처리 오류 찾기~"); 

//            string logName = "data.log";
//            Console.WriteLine($"log : {logName}");
//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            ImageController ic = new ImageController();
//            ic.Run();
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ImageControllerApp
//{
//    class ImageController
//    {
//        public void Run()
//        {
//            //1. 파일 읽기
//            string fileName = Console.ReadLine();
//            // 파일 읽기 성공
//            Console.WriteLine("이미지 처리 오류 찾기~");

//            string logName = "data.log";
//            Console.WriteLine($"log : {logName}");
//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            ImageController ic = new ImageController();
//            ic.Run();
//        }
//    }
//}
