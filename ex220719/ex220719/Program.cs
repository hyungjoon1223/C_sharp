using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ex220719
{
    static class DataEx
    {
        public static byte[] ToBytes(this Data data)
        {
            byte[] sbytes = Encoding.Unicode.GetBytes(data.sData);
            int slen = sbytes.Length;
            byte[] buf = new byte[4 + 8 + 4 + slen];
            Array.Copy(BitConverter.GetBytes(data.nData), 0, buf, 0, 4);
            Array.Copy(BitConverter.GetBytes(data.dData), 0, buf, 4, 8);
            Array.Copy(BitConverter.GetBytes(slen), 0, buf, 12, 4);
            Array.Copy(sbytes, 0, buf, 16, slen);

            return buf;
        }
        public static void SetData(this Data data, byte[] bytes)
        {
            int nData = 0;
            double dData = 0;
            int slen = 0;
            nData = BitConverter.ToInt32(bytes, 0);
            dData = BitConverter.ToDouble(bytes, 4);
            slen = BitConverter.ToInt32(bytes, 12);
            byte[] sbytes = new byte[slen];
            Array.Copy(bytes, 16, sbytes, 0, slen);
            string sData = Encoding.Unicode.GetString(sbytes);

            data.nData = nData;
            data.dData = dData;
            data.sData = sData;
        }
    }
    class Data
    {
        public int nData { get; set; }
        public double dData { get; set; }
        public string sData { get; set; }
        public Data(int n = 0, double d = 0, string s = "")
        {
            nData = n;
            dData = d;
            sData = s;
        }
        public override string ToString()
        {
            return $"n:{nData}, d:{dData}, s:{sData}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Data data = new Data(100, 5.5, "hello!");
            byte[] sb = data.ToBytes();
            foreach (var x in sb)
                Console.Write("{0:X2} ", x);
            Console.WriteLine();

            using (FileStream fs = new FileStream("data4.txt", FileMode.Create))
            {
                byte[] buf = data.ToBytes();
                fs.Write(buf, 0, buf.Length);
            }

            using (FileStream fs = new FileStream("data4.txt", FileMode.Open))
            {
                byte[] buf = new byte[fs.Length];
                fs.Read(buf, 0, (int)fs.Length);

                Data data2 = new Data();
                data2.SetData(buf);
                Console.WriteLine("data: {0}", data2);
                //int n1 = BitConverter.ToInt32(buf, 0);
                //Console.WriteLine("int : {0}", n1);

                //fs.Read(buf, 4, 8);
                //double d1 = BitConverter.ToDouble(buf, 4);
                //Console.WriteLine("double: {0}", d1);

                //fs.Read(buf, 12, 4);
                //int slen1 = BitConverter.ToInt32(buf, 12);
                //Console.WriteLine("slen: {0}", slen1);

                //fs.Read(buf, 16, 12);
                //string s1 = Encoding.Unicode.GetString(buf, 16, 12);
                //Console.WriteLine("string: {0}", s1);
            }
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Text;

//namespace ex220719
//{
//    static class DataEx
//    {
//        public static byte[] ToBytes(this Data data)
//        {
//            byte[] sbytes = Encoding.Unicode.GetBytes(data.sData);
//            int slen = sbytes.Length;
//            byte[] buf = new byte[4 + 8 + 4 + slen];
//            Array.Copy(BitConverter.GetBytes(data.nData), 0, buf, 0, 4);
//            Array.Copy(BitConverter.GetBytes(data.dData), 0, buf, 4, 8);
//            Array.Copy(BitConverter.GetBytes(slen), 0, buf, 12, 4);
//            Array.Copy(sbytes, 0, buf, 16, slen);

//            return buf;
//        }
//    }
//    class Data
//    {
//        public int nData { get; set; }
//        public double dData { get; set; }
//        public string sData { get; set; }
//        public Data(int n = 0, double d = 0, string s = "")
//        {
//            nData = n;
//            dData = d;
//            sData = s;
//        }
//        public override string ToString()
//        {
//            return $"n:{nData}, d:{dData}, s:{sData}";
//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Data data = new Data(100, 5.5, "hello!");
//            byte[] sb = data.ToBytes();
//            foreach (var x in sb)
//                Console.Write("{0:X2} ", x);
//            Console.WriteLine();

//            using (FileStream fs = new FileStream("data3.txt", FileMode.Create))
//            {
//                byte[] buf = data.ToBytes();
//                fs.Write(buf, 0, buf.Length);
//            }
//            using (FileStream fs = new FileStream("data3.txt", FileMode.Open))
//            {
//                byte[] buf = new byte[4];
//                fs.Read(buf, 0, 4);

//                int n1 = BitConverter.ToInt32(buf, 0);
//                Console.WriteLine("int : {0}", n1);
//            }
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220719
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            int n = 10;
//            using (FileStream fs = new FileStream("data3.txt", FileMode.Create))
//            {
//                fs.Write(BitConverter.GetBytes(n), 0, 4);
//            }
//            using (FileStream fs = new FileStream("data3.txt", FileMode.Open))
//            {
//                byte[] buf = new byte[4];
//                fs.Read(buf, 0, 4);

//                int n1 = BitConverter.ToInt32(buf, 0);
//                Console.WriteLine("int: {0}", n1);
//            }
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220719
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            int n = 100;
//            double d = 5.5;
//            string s = "Hello!";

//            using (StreamWriter sw = new StreamWriter("data2.txt"))
//            {
//                sw.WriteLine("{0} {1} {2}", n, d, s);
//                sw.WriteLine("{0} {1} {2}", n, d, s);
//                sw.WriteLine("{0} {1} {2}", n, d, s);
//            }
//            using (StreamReader sr = new StreamReader("data2.txt"))
//            {
//                string input = null;
//                while ((input = sr.ReadLine()) != null)
//                {
//                    Console.WriteLine(input);
//                    string[] sarr = input.Split(new char[] { ' ' });
//                    int n1 = int.Parse(sarr[0]);
//                    double d1 = double.Parse(sarr[1]);
//                    string s1 = sarr[2];

//                    Console.WriteLine("{0} {1} {2}", n1 + 1, d1 + 0.5, s1 + "!!");
//                }
//            }
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220719
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            int n = 100;
//            double d = 5.5;
//            string s = "Hello!";

//            using (StreamWriter sw = new StreamWriter("data2.txt"))
//            {
//                sw.WriteLine("{0} {1} {2}", n, d, s);
//                sw.WriteLine("{0} {1} {2}", n, d, s);
//                sw.WriteLine("{0} {1} {2}", n, d, s);
//            }
//            using (StreamReader sr = new StreamReader("data2.txt"))
//            {
//                string input = null;
//                while ((input = sr.ReadLine()) != null)
//                {
//                    Console.WriteLine(input);
//                    string[] sarr = input.Split(new char[] { ' ' });
//                    int n1 = int.Parse(sarr[0]);
//                    double d1 = double.Parse(sarr[1]);
//                    string s1 = sarr[2];

//                    Console.WriteLine("{0} {1} {2}", n1 + 1, d1 + 0.5, s1 + "!!");
//                }
//            }
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220719
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            int n = 100;
//            double d = 5.5;
//            string s = "Hello!";

//            using (StreamWriter sw = new StreamWriter("data2.txt"))
//            {
//                sw.WriteLine("{0} {1} {2}", n, d, s);
//                sw.WriteLine("{0} {1} {2}", n, d, s);
//                sw.WriteLine("{0} {1} {2}", n, d, s);
//            }
//            using (StreamReader sr = new StreamReader("data2.txt"))
//            {
//                string input = null;
//                while ((input = sr.ReadLine()) != null)
//                {
//                    Console.WriteLine(input);
//                }
//            }
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220719
//{
//    internal class Program
//    {
//        static void PrintBytes(byte[] bytes)
//        {
//            foreach (var x in bytes)
//                Console.Write("{0:X2} ", x);
//            Console.WriteLine();
//        }
//        static void Main(string[] args)
//        {
//            string s1 = "hello!";
//            string s2 = "한글입니다.";
//            string s3 = "ABC";

//            byte[] bytes1 = Encoding.Default.GetBytes(s1);
//            byte[] bytes2 = Encoding.Default.GetBytes(s2);
//            byte[] bytes3 = Encoding.Default.GetBytes(s3);

//            PrintBytes(bytes1);
//            PrintBytes(bytes2);
//            PrintBytes(bytes3);

//            string dest1 = Encoding.Default.GetString(bytes1);
//            string dest2 = Encoding.Default.GetString(bytes2);
//            string dest3 = Encoding.Default.GetString(bytes3);

//            Console.WriteLine("string : {0}", dest1);
//            Console.WriteLine("string : {0}", dest2);
//            Console.WriteLine("string : {0}", dest3);

//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220719
//{
//    internal class Program
//    {
//        static void PrintBytes(byte[] bytes)
//        {
//            foreach (var x in bytes)
//                Console.Write("{0:X2} ", x);
//            Console.WriteLine();
//        }
//        static void Main(string[] args)
//        {
//            string s1 = "hello!";
//            string s2 = "한글입니다.";
//            string s3 = "ABC";

//            byte[] bytes1 = Encoding.Default.GetBytes(s1);
//            byte[] bytes2 = Encoding.Default.GetBytes(s2);
//            byte[] bytes3 = Encoding.Default.GetBytes(s3);

//            PrintBytes(bytes1);
//            PrintBytes(bytes2);
//            PrintBytes(bytes3);

//            PrintBytes(Encoding.UTF8.GetBytes(s1));
//            PrintBytes(Encoding.UTF8.GetBytes(s2));
//            PrintBytes(Encoding.UTF8.GetBytes(s3));

//            PrintBytes(Encoding.Unicode.GetBytes(s1));
//            PrintBytes(Encoding.Unicode.GetBytes(s2));
//            PrintBytes(Encoding.Unicode.GetBytes(s3));
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220719
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            string s1 = "15";
//            string s2 = "5.6";

//            int n1 = Convert.ToInt32(s1);
//            double d1 = Convert.ToDouble(s2);

//            Console.WriteLine("{0}, {1}", n1, d1);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220719
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            string s1 = "15";
//            string s2 = "5.6";

//            int n1 = int.Parse(s1);
//            if (int.TryParse(s1, out int n2))
//            {
//                Console.WriteLine("{0}, {1}", n1, n2);
//            }

//            double d1 = double.Parse(s2);
//            if (double.TryParse(s2, out double d2))
//            {
//                Console.WriteLine("{0}, {1}", d1, d2);
//            }
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220719
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            int n = 100;
//            double d = 5.567;

//            byte[] nBytes = BitConverter.GetBytes(n);
//            byte[] dBytes = BitConverter.GetBytes(d);
//            byte[] bytes = new byte[nBytes.Length + dBytes.Length];
//            Array.Copy(nBytes, 0, bytes, 0, 4);
//            Array.Copy(dBytes, 0, bytes, 4, 8);

//            foreach (var x in bytes)
//                Console.Write("{0:X2} ", x);
//            Console.WriteLine();

//            int n2 = 0;
//            double d2 = 0;
//            n2 = BitConverter.ToInt32(bytes, 0);
//            d2 = BitConverter.ToDouble(bytes, 4);
//            Console.WriteLine("{0} - {1}", n2, d2);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220719
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("min:{0}", byte.MinValue);
//            Console.WriteLine("min:{0}", byte.MaxValue);

//            int n = 100;
//            double d = 5.567;

//            byte[] nBytes = BitConverter.GetBytes(n);
//            byte[] dBytes = BitConverter.GetBytes(d);

//            foreach (var x in nBytes)
//                Console.Write("{0:X2} ", x);
//            Console.WriteLine();
//            foreach (var x in dBytes)
//                Console.Write("{0:X2} ", x);
//            Console.WriteLine();

//            int n2 = BitConverter.ToInt32(nBytes, 0);
//            double d2 = BitConverter.ToDouble(dBytes, 0);
//            Console.WriteLine("{0}, {1}", n2, d2);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220719
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("min:{0}", byte.MinValue);
//            Console.WriteLine("min:{0}", byte.MaxValue);

//            int n = 100;
//            double d = 5.567;

//            byte[] nBytes = BitConverter.GetBytes(n);
//            byte[] dBytes = BitConverter.GetBytes(d);

//            foreach (var x in nBytes)
//                Console.Write("{0:X2} ", x);
//            Console.WriteLine();
//            foreach (var x in dBytes)
//                Console.Write("{0:X2} ", x);
//            Console.WriteLine();

//            int n2 = BitConverter.ToInt32(nBytes, 0);
//            double d2 = BitConverter.ToDouble(dBytes, 0);
//            Console.WriteLine("{0}, {1}", n2, d2);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220719
//{
//    [Serializable]
//    class Point
//    {
//        int x, y;
//        public Point(int x = 0, int y = 0)
//        {
//            this.x = x;
//            this.y = y;
//        }
//        public override string ToString()
//        {
//            return $"({x},{y}) ";
//        }
//    }
//    [Serializable]
//    class Rect
//    {
//        Point pt;
//        int width;
//        int height;
//        DateTime currentTime;
//        public Rect(Point pt = default, int w = 0, int h = 0)
//        {
//            this.pt = pt;
//            width = w;
//            height = h;
//        }
//        public override string ToString()
//        {
//            return $"Rect: {pt.ToString()}, w:{width}, h:{height} ";
//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            string s = "Hello!";
//            int data = 100;
//            double data2 = 5.55;
//            Rect r = new Rect(new Point(5, 5), 100, 150);
//            List<Rect> lt = new List<Rect>();

//            lt.Add(new Rect(new Point(0, 0), 100, 100));
//            lt.Add(new Rect(new Point(15, 15), 10, 45));
//            lt.Add(new Rect(new Point(5, 5), 25, 100));

//            BinaryFormatter bFormat = new BinaryFormatter();
//            using (Stream fstream = new FileStream("data.txt", FileMode.Create))
//            {
//                bFormat.Serialize(fstream, s);
//                bFormat.Serialize(fstream, data);
//                bFormat.Serialize(fstream, data2);
//                bFormat.Serialize(fstream, r);
//                bFormat.Serialize(fstream, lt);
//            }
//            using (Stream fstream = new FileStream("data.txt", FileMode.Open))
//            {
//                string s1 = (string)bFormat.Deserialize(fstream);
//                int n = (int)bFormat.Deserialize(fstream);
//                double d = (double)bFormat.Deserialize(fstream);
//                Rect r1 = (Rect)bFormat.Deserialize(fstream);

//                List<Rect> destList = (List<Rect>)bFormat.Deserialize(fstream);

//                Console.WriteLine("string: {0}", s1);
//                Console.WriteLine("int: {0}", n);
//                Console.WriteLine("double: {0}", d);
//                Console.WriteLine("Rect: {0}", r1);
//                foreach (var x in destList)
//                {
//                    Console.WriteLine(x);
//                }
//            }
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220719
//{
//    [Serializable]
//    class Point
//    {
//        int x, y;
//        public Point(int x = 0, int y = 0)
//        {
//            this.x = x;
//            this.y = y;
//        }
//        public override string ToString()
//        {
//            return $"({x},{y}) ";
//        }
//    }
//    [Serializable]
//    class Rect
//    {
//        Point pt;
//        int width;
//        [NonSerialized]
//        int height;
//        [NonSerialized]
//        DateTime currentTime;
//        public Rect(Point pt = default, int w = 0, int h = 0)
//        {
//            this.pt = pt;
//            width = w;
//            height = h;
//        }
//        public override string ToString()
//        {
//            return $"Rect: {pt.ToString()}, w:{width}, h:{height} ";
//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Rect r = new Rect(new Point(5, 5), 100, 150);
//            List<Rect> lt = new List<Rect>();
//            lt.Add(new Rect(new Point(0, 0), 100, 100));
//            lt.Add(new Rect(new Point(15, 15), 10, 45));
//            lt.Add(new Rect(new Point(5, 5), 20, 100));

//            BinaryFormatter bFormat = new BinaryFormatter();
//            using (Stream fstream = new FileStream("data.txt", FileMode.Create))
//            {
//                bFormat.Serialize(fstream, lt);
//            }
//            using (Stream fstream = new FileStream("data.txt", FileMode.Open))
//            {
//                List<Rect> destList = (List<Rect>)bFormat.Deserialize(fstream);
//                foreach (var x in destList)
//                {
//                    Console.WriteLine(x);
//                }
//            }
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//namespace ex220719
//{
//    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
//    class DescriptionAttribute : Attribute
//    {
//        public string Message { get; set; }
//        public DescriptionAttribute(string m = "")
//        {
//            Message = m;
//        }
//        public override string ToString()
//        {
//            return $"msg : {Message}";
//        }
//    }
//    [Description("점을 구현한 클래스 입니다.")]
//    [Description("X,Y를 정수로 저장합니다.")]
//    [Description("좌표 평면 상의 점을 저장하기 위해 클래스를 사용할 수 있어요.")]
//    class Point
//    {
//        int x, y;
//        public Point(int x = 0, int y = 0)
//        {
//            this.x = x;
//            this.y = y;
//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Point pt = new Point(2, 3);

//            Console.WriteLine(pt);

//            Attribute[] attrArray = Attribute.GetCustomAttributes(pt.GetType());
//            foreach (var attr in attrArray)
//            {
//                DescriptionAttribute desc = attr as DescriptionAttribute;
//                Console.WriteLine("{0} {1}", attr, desc.Message);
//            }
//        }
//    }
//}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//namespace ex220719
//{
//    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
//    class DescriptionAttribute : Attribute
//    {
//        public string Message { get; set; }
//        public DescriptionAttribute(string m = "")
//        {
//            Message = m;
//        }
//        public override string ToString()
//        {
//            return $"msg : {Message}";
//        }
//    }
//    [Description("점을 구현한 클래스 입니다.")]
//    [Description("X,Y를 정수로 저장합니다.")]
//    [Description("좌표 평면 상의 점을 저장하기 위해 클래스를 사용할 수 있어요.")]
//    class Point
//    {
//        int x, y;
//        public Point(int x = 0, int y = 0)
//        {
//            this.x = x;
//            this.y = y;
//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Point pt = new Point(2, 3);

//            Console.WriteLine(pt);

//            Attribute[] attrArray = Attribute.GetCustomAttributes(pt.GetType());
//            foreach (var attr in attrArray)
//            {
//                DescriptionAttribute desc = attr as DescriptionAttribute;
//                Console.WriteLine("{0} {1}", attr, desc.Message);
//            }
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//namespace ex220719
//{
//    internal class Program
//    {
//        static void PrintString(string msg)
//        {
//            for (int i = 0; i < 10; i++)
//            {
//                Thread.Sleep(500);
//                Console.WriteLine("print string : {0}", msg);
//            }
//        }
//        //Client
//        static void DoneCallBack(IAsyncResult iar)
//        {
//            //Conso!");le.WriteLine("Done
//        }
//        static void Main(string[] args)
//        {
//            Action<string> d2 = PrintString;

//            IAsyncResult iar = d2.BeginInvoke("Hello!", DoneCallBack, "myState");
//            for (int i = 0; i < 5; ++i)
//            {
//                Thread.Sleep(500);
//                Console.WriteLine("{0}, {1}", "main", Thread.CurrentThread.ManagedThreadId);
//            }
//            d2.EndInvoke(iar);
//            Console.WriteLine("end Main()");
//            Console.ReadLine();
//        }
//    }
//}

//using Sy
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//namespace ex220719
//{
//    internal class Program
//    {
//        static void PrintString(string msg)
//        {
//            Thread.Sleep(2000);
//            Console.WriteLine("print string : {0}", msg);
//        }
//        //Client
//        static void DoneCallBack(IAsyncResult iar)
//        {
//            //Conso!");le.WriteLine("Done
//        }
//        static void Main(string[] args)
//        {
//            Action<string> d2 = PrintString;

//            IAsyncResult iar = d2.BeginInvoke("Hello!", DoneCallBack, "myState");
//            d2.EndInvoke(iar);
//            Console.WriteLine("end Main()");
//        }
//    }
//}

////using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//namespace ex220719
//{
//    internal class Program
//    {
//        static void PrintString(string msg)
//        {
//            Thread.Sleep(2000);
//            Console.WriteLine("print string : {0}", msg);
//        }
//        delegate void PS(string msg);
//        static void Main(string[] args)
//        {
//            PS d1 = PrintString;
//            Action<string> d2 = PrintString;

//            d1.Invoke("Hello!");       //동기 딜리게이트 호출
//            d2.Invoke("Hello!");
//            d1("Hello!");              //두 문법은 완벽 동일 
//            d2("Hello!");

//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//namespace ex220719
//{
//    internal class Program
//    {
//        static async void f1() //반환 x
//        {
//            await Task.Delay(1000);
//            Console.WriteLine($"f1 , {Thread.CurrentThread.ManagedThreadId}");
//        }
//        static async Task f2() //task 반환
//        {
//            await Task.Delay(2000);
//            Console.WriteLine($"f2 , {Thread.CurrentThread.ManagedThreadId}");
//        }
//        static async Task<int> f3()
//        {
//            await Task.Delay(3000);
//            return 100;
//            Console.WriteLine($"f3 , {Thread.CurrentThread.ManagedThreadId}");

//        }
//        static async Task Main(string[] args)
//        { //f1 f2 f3대기를 하지않으면 다른애들하고 중첩해서 돌아가지 않는다.
//            f1();
//            Task t = f2();    //원하는시점에 wait하고 작업을 하려고 t로 반환 ! ==> 대부분의 비동기는 task를 반환하도록 만들어짐
//            Task<int> t2 = f3();
//            t.Wait();
//            Console.WriteLine("t3의 결과 : {0}", t2.Result);
//            Console.ReadLine();
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220719
//{
//    internal class Program
//    {
//        static async Task Main(string[] args)
//        {
//            Task t1 = Task.Factory.StartNew((n) =>
//            {
//                int index = (int)n;
//                Console.WriteLine("index : {0}", imdex);

//            }), 0;
//            Task t2 = Task.Factory.StartNew((n) =>
//            {
//                int index = (int)n;
//                Console.WriteLine("inxex {0}", index);

//            }), 1;
//            Task.WaitAll(t1, t2);
//            Console.WriteLine("end Main()");

//        }
//    }
//}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220719
//{
//    internal class Program
//    {
//        static async Task Main(string[] args)
//        {
//            Random r = new Random();
//            List<int> lt = new List<int>();
//            for (int i = 0; i < 1000; ++i)
//            {
//                lt.Add((int)Math.Round(r.NextDouble() * 100));
//            }

//            foreach (var v in lt)
//            {
//                Console.Write("{0} ", v);
//            }
//            Console.WriteLine();

//            List<int> selectList = new List<int>();
//            Parallel.For(0, 2, (n) =>
//            {
//                int startIndex = n * 500;
//                for (int i = startIndex; i < startIndex + 500; ++i)
//                {
//                    if (lt[i] % 3 == 0 || lt[i] % 5 == 0)
//                    {
//                        lock (selectList)
//                        {
//                            selectList.Add(lt[i]);
//                        }
//                    }
//                }
//            });
//            Console.WriteLine();

//            foreach (var v in selectList)
//            {
//                Console.Write("{0} ", v);
//            }
//            Console.WriteLine();
//        }
//    }
//}


//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220719
//{
//    class Program
//    {
//        static async Task Main(string[] args)
//        {
//            Random r = new Random();
//            List<int> lt = new List<int>();
//            for (int i = 0; i < 1000; i++)
//                lt.Add((int)(Math.Round(r.NextDouble() * 100)));
//            foreach (var v in lt)
//                Console.WriteLine("{0}", v);
//            List<int> selectList = new List<int>();
//            Parallel.For(0, 1, (n) =>
//            {
//                int startIndex = n * 500;
//                for (int i = 0; i < lt.Count; i++)
//                    if (lt[i] % 3 == 0 || lt[i] % 5 == 0)
//                        selectList.Add(lt[i]);
//            });
//            Console.WriteLine();
//            foreach (var v in selectList) ;
//            Console.WriteLine("{0}", v);
//            Console.WriteLine();
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220719
//{
//    class Program
//    {
//        static async Task Main(string[] args)
//        {
//            Task<int> t = Task.Run(() =>
//            {
//                int sum = 0;
//                for (int i = 1; i <= 100; ++i)
//                    sum += i;

//                return sum;
//            });
//            int result = await t; // 2. wait + result;
//            Console.WriteLine("result : {0}", result); //1.wait +result 기능을 같이함
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220719
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Task<int> t = Task.Run(() =>
//            {
//                int sum = 0;
//                for (int i = 1; i <= 100; ++i)
//                    sum += i;

//                return sum;
//            });
//            Console.WriteLine("result : {0}", t.Result); //1.wait +result 기능을 같이함
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220719
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            int sum = 0;
//            for (int i = 0; i < 10; ++i)
//            {
//                sum += i;
//                Trace.WriteLine(string.Format("{0}, {1}", i, sum));
//                Trace.WriteLine($"{i}, {sum}");
//            }
//            Console.WriteLine("sum : {0}", sum);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220719
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            for (int i = 0; i < 10; ++i)
//                Console.Write("{0}", i);
//            Console.WriteLine();
//        }
//    }
//}
