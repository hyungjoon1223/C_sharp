using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex220712
{
    struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"({X}, {Y}) ";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Point> ptList = new List<Point>();
            ptList.Add(new Point(2, 3));
            ptList.Add(new Point(4, 5));
            ptList.Add(new Point(7, 8));

            var startTime = DateTime.Now;
            StringBuilder s = new StringBuilder("");
            foreach (var item in ptList)
                s.Append(item);

            var endTime = DateTime.Now;

            Console.WriteLine(endTime - startTime);
        }
    }
}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220712
//{
//    struct Point
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//        public Point(int x = 0, int y = 0)
//        {
//            X = x;
//            Y = y;
//        }
//        public override string ToString()
//        {
//            return $"({X}, {Y}) ";
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            List<Point> ptList = new List<Point>();
//            ptList.Add(new Point(2, 3));
//            ptList.Add(new Point(4, 5));
//            ptList.Add(new Point(7, 8));

//            string s = "";
//            foreach (var item in ptList)
//                s += item;

//            Console.WriteLine(s);
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220712
//{
//    class Point
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//        public int this[string idx]
//        {
//            get
//            {
//                if (idx == "X")
//                    return X;
//                else if (idx == "Y")
//                    return Y;
//                else
//                    throw new ApplicationException("X or Y 값 지정 실패!");
//            }
//            set
//            {
//                if (idx == "X")
//                    X = value;
//                else if (idx == "Y")
//                    Y = value;
//                else
//                    throw new ApplicationException("X or Y 값 지정 실패!");
//            }
//        }
//        public Point(int x = 0, int y = 0)
//        {
//            X = x;
//            Y = y;
//        }
//        public override string ToString()
//        {
//            return $"({X}, {Y}) ";
//        }
//        public static Point operator +(Point a, Point b)
//        {
//            return new Point(a.X + b.X, a.Y + b.Y);
//        }
//        public override bool Equals(object obj)
//        {
//            Point pt = (Point)obj;
//            return X == pt.X && Y == pt.Y;
//        }
//        public override int GetHashCode()
//        {
//            return X + Y;
//        }
//        public static bool operator ==(Point a, Point b)
//        {
//            return a.Equals(b);
//        }
//        public static bool operator !=(Point a, Point b)
//        {
//            return !(a == b);
//        }
//        public static Point operator ++(Point pt)
//        {

//            ++pt.X;
//            ++pt.Y;
//            return pt;
//        }
//        public static explicit operator int(Point pt)  //explicit 해줘야 형식변환 가능
//        {
//             return pt.X;
//        }
//    }
//    class PointArray : IEnumerable
//    {
//        private Point[] parr;
//        private int size;

//        public int Count => size;
//        public Point this[int idx]
//        {
//            get { return parr[idx]; }
//            set { parr[idx] = value; }
//        }
//        public PointArray()
//        {
//            parr = new Point[100];
//            size = 0;
//        }

//        public void Add(Point data)
//        {
//            parr[size++] = data;
//        }
//        public void Remove(int idx)
//        {
//            for (int i = idx; i < size - 1; ++i)
//                parr[i] = parr[i + 1];
//            --size;
//        }
//        public Point At(int idx)
//        {
//            return parr[idx];
//        }

//        public IEnumerator GetEnumerator()
//        {
//            for (int i = 0; i < size; ++i)
//            {
//                yield return parr[i];
//            }
//        }
//    }
//    class Program
//    {
//        static void PrintIEnumerable(IEnumerable ie)
//        {
//            foreach (var pt in ie)
//                Console.WriteLine(pt);
//        }
//        static void Main(string[] args)
//        {
//            Point pt1 = new Point(2, 3);

//            int x = (int)pt1;
//            Console.WriteLine(x);
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220712
//{
//    class Point
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//        public int this[string idx]
//        {
//            get
//            {
//                if (idx == "X")
//                    return X;
//                else if (idx == "Y")
//                    return Y;
//                else
//                    throw new ApplicationException("X or Y 값 지정 실패!");
//            }
//            set
//            {
//                if (idx == "X")
//                    X = value;
//                else if (idx == "Y")
//                    Y = value;
//                else
//                    throw new ApplicationException("X or Y 값 지정 실패!");
//            }
//        }
//        public Point(int x = 0, int y = 0)
//        {
//            X = x;
//            Y = y;
//        }
//        public override string ToString()
//        {
//            return $"({X}, {Y}) ";
//        }
//        public static Point operator +(Point a, Point b)
//        {
//            return new Point(a.X + b.X, a.Y + b.Y);
//        }
//        public override bool Equals(object obj)
//        {
//            Point pt = (Point)obj;
//            return X == pt.X && Y == pt.Y;
//        }
//        public override int GetHashCode()
//        {
//            return X + Y;
//        }
//        public static bool operator ==(Point a, Point b)
//        {
//            return a.Equals(b);
//        }
//        public static bool operator !=(Point a, Point b)
//        {
//            return !(a == b);
//        }
//        public static Point operator++(Point pt)
//        {

//            ++pt.X;
//            ++pt.Y;
//            return pt;
//        }
//    }
//    class PointArray : IEnumerable
//    {
//        private Point[] parr;
//        private int size;

//        public int Count => size;
//        public Point this[int idx]
//        {
//            get { return parr[idx]; }
//            set { parr[idx] = value; }
//        }
//        public PointArray()
//        {
//            parr = new Point[100];
//            size = 0;
//        }

//        public void Add(Point data)
//        {
//            parr[size++] = data;
//        }
//        public void Remove(int idx)
//        {
//            for (int i = idx; i < size - 1; ++i)
//                parr[i] = parr[i + 1];
//            --size;
//        }
//        public Point At(int idx)
//        {
//            return parr[idx];
//        }

//        public IEnumerator GetEnumerator()
//        {
//            for (int i = 0; i < size; ++i)
//            {
//                yield return parr[i];
//            }
//        }
//    }
//    class Program
//    {
//        static void PrintIEnumerable(IEnumerable ie)
//        {
//            foreach (var pt in ie)
//                Console.WriteLine(pt);
//        }
//        static void Main(string[] args)
//        {
//            Point pt1 = new Point(2, 3);

//            Point pt2 = ++pt1;
//            Console.WriteLine(pt1);
//            Console.WriteLine(pt2);
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220712
//{
//    class Point
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//        public int this[string idx] 
//        {
//            get
//            {
//                if (idx == "X")
//                    return X;
//                else if (idx == "Y")
//                    return Y;
//                else
//                    throw new ApplicationException("X or Y 값 지정 실패!");
//            }
//            set
//            {
//                if (idx == "X")
//                    X = value;
//                else if (idx == "Y")
//                    Y = value;
//                else
//                    throw new ApplicationException("X or Y 값 지정 실패!");
//            }
//        }
//        public Point(int x = 0, int y = 0)
//        {
//            X = x;
//            Y = y;
//        }
//        public override string ToString()
//        {
//            return $"({X}, {Y}) ";
//        }
//        public static Point operator +(Point a, Point b)
//        {
//            return new Point(a.X + b.X, a.Y + b.Y);
//        }
//        public override bool Equals(object obj)
//        {
//            Point pt = obj as Point;
//            return X == pt.X && Y == pt.Y;
//        }
//        public override int GetHashCode()
//        {
//            return X + Y;
//        }
//        public static bool operator ==(Point a, Point b)
//        {
//            return a.Equals(b);
//        }
//        public static bool operator !=(Point a, Point b)
//        {
//            return !(a == b);
//        }

//    }
//    class PointArray : IEnumerable
//    {
//        private Point[] parr;
//        private int size;

//        public int Count => size;
//        public Point this[int idx]
//        {
//            get { return parr[idx]; }
//            set { parr[idx] = value; }
//        }
//        public PointArray()
//        {
//            parr = new Point[100];
//            size = 0;
//        }

//        public void Add(Point data)
//        {
//            parr[size++] = data;
//        }
//        public void Remove(int idx)
//        {
//            for (int i = idx; i < size - 1; ++i)
//                parr[i] = parr[i + 1];
//            --size;
//        }
//        public Point At(int idx)
//        {
//            return parr[idx];
//        }

//        public IEnumerator GetEnumerator()
//        {
//            for (int i = 0; i < size; ++i)
//            {
//                yield return parr[i];
//            }
//        }
//    }
//    class Program
//    {
//        static void PrintIEnumerable(IEnumerable ie)
//        {
//            foreach (var pt in ie)
//                Console.WriteLine(pt);
//        }
//        static void Main(string[] args)
//        {
//            Point pt1 = new Point(2, 3);
//            Point pt2 = new Point(2, 3);
//            Point pt3 = pt1 + pt2; //연산자 중복은 static 메소드로

//            Console.WriteLine(pt1["X"]);
//            Console.WriteLine(pt1["Y"]);
//            pt1["X"] = 100;
//            Console.WriteLine(pt1);
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220712
//{
//    class Point
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//        public Point(int x = 0, int y = 0)
//        {
//            X = x;
//            Y = y;
//        }
//        public override string ToString()
//        {
//            return $"({X}, {Y}) ";
//        }
//        public static Point operator +(Point a, Point b)
//        {
//            return new Point(a.X + b.X, a.Y + b.Y);
//        }
//        public override bool Equals(object obj)
//        {
//            Point pt = obj as Point;
//            return X == pt.X && Y == pt.Y;
//        }
//        public override int GetHashCode()
//        {
//            return X+Y;
//        }
//        public static bool operator==(Point a, Point b)
//        {
//            return a.Equals(b);
//        }
//        public static bool operator!=(Point a, Point b)
//        {
//            return !(a == b);
//        }

//    }
//    class PointArray : IEnumerable
//    {
//        private Point[] parr;
//        private int size;

//        public int Count => size;
//        public Point this[int idx]
//        {
//            get { return parr[idx]; }
//            set { parr[idx] = value; }
//        }
//        public PointArray()
//        {
//            parr = new Point[100];
//            size = 0;
//        }

//        public void Add(Point data)
//        {
//            parr[size++] = data;
//        }
//        public void Remove(int idx)
//        {
//            for (int i = idx; i < size - 1; ++i)
//                parr[i] = parr[i + 1];
//            --size;
//        }
//        public Point At(int idx)
//        {
//            return parr[idx];
//        }

//        public IEnumerator GetEnumerator()
//        {
//            for (int i = 0; i < size; ++i)
//            {
//                yield return parr[i];
//            }
//        }
//    }
//    class Program
//    {
//        static void PrintIEnumerable(IEnumerable ie)
//        {
//            foreach (var pt in ie)
//                Console.WriteLine(pt);
//        }
//        static void Main(string[] args)
//        {
//            Point pt1 = new Point(2, 3);
//            Point pt2 = new Point(2, 3);
//            Point pt3 = pt1 + pt2; //연산자 중복은 static 메소드로


//            Console.WriteLine(pt3);

//            if(pt1==pt2)
//                Console.WriteLine("True");
//            if (pt1.Equals(pt2))
//                Console.WriteLine("True");
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220712
//{
//    class Point
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//        public Point(int x = 0, int y = 0)
//        {
//            X = x;
//            Y = y;
//        }
//        public override string ToString()
//        {
//            return $"({X}, {Y}) ";
//        }
//    }
//    class PointArray : IEnumerable
//    {
//        private Point[] parr;
//        private int size;

//        public int Count => size;
//        public Point this[int idx] 
//        {
//            get { return parr[0]; }
//            set { parr[idx] = value; }
//        }

//        public PointArray()
//        {
//            parr = new Point[100];
//            size = 0;
//        }

//        public void Add(Point data)
//        {
//            parr[size++] = data;
//        }
//        public void Remove(int idx)
//        {
//            for (int i = idx; i < size - 1; ++i)
//                parr[i] = parr[i + 1];
//            --size;
//        }
//        public Point At(int idx)
//        {
//            return parr[idx];
//        }

//        public IEnumerator GetEnumerator()
//        {
//            for (int i = 0; i < size; ++i)
//            {
//                yield return parr[i];
//            }
//        }
//    }
//    class Program
//    {
//        static void PrintIEnumerable(IEnumerable ie)
//        {
//            foreach (var pt in ie)
//                Console.WriteLine(pt);
//        }
//        static void Main(string[] args)
//        {
//            PointArray parr = new PointArray();

//            parr.Add(new Point(2, 3));
//            parr.Add(new Point(7, 3));
//            parr.Add(new Point(4, 3));
//            parr.Add(new Point(5, 1));
//            parr.Add(new Point(3, 3));

//            Console.WriteLine(parr.At(0));
//            Console.WriteLine(parr.At(1));
//            Console.WriteLine(parr.At(2));

//            parr[0] = new Point(100,100);
//            Console.WriteLine(parr[0]);
//            Console.WriteLine(parr[1]);
//            Console.WriteLine(parr[2]);
//        }
//    }
//}

//using System;
//using System.Linq;
//using System.Collections.Generic;
//using System.Collections;

//namespace ex220712
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            ArrayList arr = new ArrayList();
//            arr.Add(10);
//            arr.Add(20);
//            arr.Add(30);

//            IEnumerable<int> ie = arr.OfType<int>();
//            Console.WriteLine("sum : {0} ", ie.Sum());

//            var sub = from data in ie
//                      where data >= 20
//                      select data;
//            foreach (var data in sub)
//                Console.Write("{0} ", data);
//            Console.WriteLine();

//            var sub2 = ie.Where((n) => n >= 20)
//                      .Select((n) => n);

//            foreach (var data in sub)
//                Console.Write("{0} ", data);
//            Console.WriteLine();
//        }
//    }
//}

//using System;
//using System.Linq;
//using System.Collections.Generic;
//using System.Collections;

//namespace ex220712
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            ArrayList arr = new ArrayList();
//            arr.Add(10);
//            arr.Add(20);
//            arr.Add(30);

//            IEnumerable<int> ie = arr.OfType<int>();
//            Console.WriteLine("sum : {0} ", ie.Sum());

//            var sub = from data in ie
//                      where data >= 20
//                      select data;
//            foreach(var data in sub)
//                Console.Write("{0} ", data);
//            Console.WriteLine();

//            var sub2 = ie.Where((n) => n >= 20)
//                      .Select((n) => n);

//            foreach (var data in sub)
//                Console.Write("{0} ", data);
//            Console.WriteLine();
//        }
//    }
//}

//using System;
//using System.Linq;
//using System.Collections.Generic;

//namespace ex220712
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            IEnumerable<int> lt = Enumerable.Range(100, 10);
//            Console.WriteLine("Sum : {0}", lt.Sum());
//            Console.WriteLine("Sum : {0}", lt.Where((n)=>n%2==0).Sum());
//            Console.WriteLine("Sum : {0}", lt.Where((n)=>n%2==0).Aggregate("",(acc,item)=>acc+item));

//            foreach (int data in lt)
//                Console.Write("{0} ", data);
//            Console.WriteLine();

//            Console.WriteLine("type : {0}", lt.GetType().Name);
//        }
//    }
//}

//using System;
//using System.Linq;

//namespace ex220712
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var lt = Enumerable.Range(100, 10);

//            foreach(var data in lt)
//                Console.Write("{0} ", data);
//            Console.WriteLine();
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220712
//{
//    static class ExtensClass
//    {
//        public static int Add(this int data, int n)
//        {
//            return data + n;
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int n = 10;
//            Console.WriteLine(n.Add(100));  //110
//            Console.WriteLine(ExtensClass.Add(n, 100));  //110
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220712
//{
//    interface IPrint
//    {
//        object Data { get; }
//        void Print();
//    }
//    class Data : IPrint
//    {
//        public int Item { get; set; }

//        object IPrint.Data { get { return Item; } }

//        public void Print()
//        {
//            Console.WriteLine("Data : {0}", Item);
//        }
//    }
//    class Test : IPrint
//    {
//        public string Data { get; set; }

//        object IPrint.Data { get { return Data; } }

//        public void Print()
//        {
//            Console.WriteLine("Data : {0}", Data);
//        }
//    }
//    static class Printable
//    {
//        public static void Print(this object data)
//        {
//            Console.WriteLine("Data : {0} ", data);
//        }
//    }
//    static class ExtensClass
//    {
//        public static object GetData(this IPrint ip)
//        {
//            return ip.Data;
//        }
//        public static void PrintTest(this Test t)
//        {
//            Console.WriteLine("{0} : {1} ", typeof(Test).Name, t.Data);
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //** 별 두개 짜리 확장메소드  1. 스태틱 클래스여야 한다
//            Data d1 = new Data() { Item = 100 };
//            Test t1 = new Test() { Data = "hello" };

//            Console.WriteLine(d1.GetData());
//            Console.WriteLine(t1.GetData());

//            d1.Print();
//            t1.Print();

//            t1.PrintTest();
//            ExtensClass.PrintTest(t1);
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220712
//{
//    interface IPrint
//    {
//        object Data { get; }
//        void Print();
//    }
//    class Data : IPrint
//    {
//        public int Item { get; set; }

//        object IPrint.Data {  get { return Item; } }

//        public void Print()
//        {
//            Console.WriteLine("Data : {0}", Item);
//        }
//    }
//    class Test : IPrint
//    {
//        public string Data { get; set; }

//        object IPrint.Data { get { return Data; } }

//        public void Print()
//        {
//            Console.WriteLine("Data : {0}", Data);
//        }
//    }
//    static class Printable
//    {
//        public static void Print(this object data)
//        {
//            Console.WriteLine("Data : {0} ", data);
//        }
//    }
//    static class ExtensClass
//    {
//        public static object GetData(this IPrint ip)
//        {
//            return ip.Data;
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //** 별 두개 짜리 확장메소드  1. 스태틱 클래스여야 한다
//            Data d1 = new Data() { Item = 100 };
//            Test t1 = new Test() { Data = "hello" };

//            Console.WriteLine(d1.GetData());
//            Console.WriteLine(t1.GetData());

//            d1.Print();
//            t1.Print();
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220712
//{
//    interface IPrint
//    {
//        void Print();
//    }
//    class Data : IPrint
//    {
//        public int Item { get; set; }
//        public void Print()
//        {
//            Console.WriteLine("Data : {0}", Item);
//        }
//    }
//    class Test : IPrint
//    {
//        public string Data { get; set; }

//        public void Print()
//        {
//            Console.WriteLine("Data : {0}", Data);
//        }
//    }
//    static class Printable
//    {
//        public static void Print(this object data)
//        {
//            Console.WriteLine("Data : {0} ", data);
//        }
//    }
//    static class ExtensClass
//    {
//        public static object GetData(this IPrint ip )
//        {
//            return "interface IPrint";
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //** 별 두개 짜리 확장메소드  1. 스태틱 클래스여야 한다
//            Data d1 = new Data() { Item = 100 };
//            Test t1 = new Test() { Data = "hello" };

//            Console.WriteLine(d1.GetData());
//            Console.WriteLine(t1.GetData());

//            d1.Print();
//            t1.Print();
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220712
//{
//    static class Printable
//    {
//        public static void Print(this object data)
//        {
//            Console.WriteLine("Data : {0} ", data);
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //** 별 두개 짜리 확장메소드  1. 스태틱 클래스여야 한다
//            int n = 10;

//            n.Print();
//            200.Print();

//            string s = "hello!";
//            s.Print();

//            double d = 2.2;
//            d.Print();
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220712
//{
//    static class Printable
//    {
//        public static void Print(this object data)
//        {
//            Console.WriteLine("Data : {0} ", data);
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //** 별 두개 짜리 확장메소드  1. 스태틱 클래스여야 한다
//            int n = 10;

//            n.Print();
//            200.Print();

//            string s = "hello!";
//            s.Print();
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220712
//{
//    static class Printable
//    {
//        public static void Print(this int data)
//        {
//            Console.WriteLine("Data : {0} ", data);
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //** 별 두개 짜리 확장메소드  1. 스태틱 클래스여야 한다
//            int n = 10;

//            n.Print();
//            200.Print();

//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;ㅇ
//using System.Threading.Tasks;

//namespace ex220712
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //컬렉션 ( 1. 비제너릭 컬렉션 / 2. 제너릭 컬렉션)
//            // ArrayList => List<T>
//            // List => LinkedList<T>
//            // SortedList => SortedList<T>
//            // Hashtable => Dictionary<K,V>
//            // Stack , Queue = Stack<T> Queue<T>

//            Stack<int> st = new Stack<int>();
//            Queue<int> q = new Queue<int>();

//            st.Push(10); st.Push(20); st.Push(30);
//            q.Enqueue(10); q.Enqueue(20); q.Enqueue(30);

//            Console.WriteLine("{0} {1} {2}", st.Pop(), st.Pop(), st.Pop());
//            Console.WriteLine("{0} {1} {2}", q.Dequeue(), q.Dequeue(), q.Dequeue());
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220712
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //컬렉션 ( 1. 비제너릭 컬렉션 / 2. 제너릭 컬렉션)
//            // ArrayList => List<T>
//            // List => LinkedList<T>
//            // SortedList => SortedList<T>
//            // Hashtable => Dictionary<K,V>
//            // Stack , Queue = Stack<T> Queue<T>

//            Dictionary<int, string> dic = new Dictionary<int, string>();

//            dic[1] = "하나";
//            dic[2] = "둘";
//            dic[3] = "셋";

//            foreach (var data in dic)
//                Console.Write("{0} : {1} ", data.Key, data.Value);
//            Console.WriteLine();


//            Console.WriteLine(dic[1] + "!");
//            Console.WriteLine(dic[2] + "!");
//            Console.WriteLine(dic[3] + "!");

//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220712
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //컬렉션 ( 1. 비제너릭 컬렉션 / 2. 제너릭 컬렉션)
//            // ArrayList => List<T>
//            // List => LinkedList<T>
//            // SortedList => SortedList<T>
//            // Hashtable => Dictionary<K,V>
//            // Stack , Queue = Stack<T> Queue<T>

//            SortedList sl = new SortedList();
//            SortedList<int, string> gsl = new SortedList<int, string>();

//            sl.Add(1, "하나"); sl.Add(2, "둘"); sl.Add(3, "셋");
//            gsl.Add(1, "하나"); gsl.Add(2, "둘"); gsl.Add(3, "셋");


//            foreach (DictionaryEntry data in sl)
//                Console.Write("{0} : {1} ", data.key, data.Value);
//            Console.WriteLine();

//            foreach (var data in gsl)
//                Console.Write("{0} : {1} ", data.Key, data.Value);
//            Console.WriteLine();


//            Console.WriteLine((string)sl[1]+ "!");
//            Console.WriteLine((string)sl[2]+ "!");
//            Console.WriteLine((string)sl[3]+ "!");

//            Console.WriteLine(gsl[1]+"!");
//            Console.WriteLine(gsl[2]+"!");
//            Console.WriteLine(gsl[3]+"!");
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220712
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //컬렉션 ( 1. 비제너릭 컬렉션 / 2. 제너릭 컬렉션)
//            // ArrayList => List<T>
//            // List => LinkedList<T>
//            // SortedList => SortedList<T>
//            // Hashtable => Dictionary<K,V>
//            // Stack , Queue = Stack<T> Queue<T>


//            LinkedList<int> lt = new LinkedList<int>();
//            //al.Add(10); al.Add(20); al.Add(30);
//            lt.AddLast(10); lt.AddLast(20); lt.AddLast(30);
//            lt.AddFirst(100); lt.AddFirst(200);

//            //foreach (var data in al)
//            //    Console.Write("{0} ", data);
//            //Console.WriteLine();
//            foreach (var data in lt)
//                Console.Write("{0} ", data);
//            Console.WriteLine();
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220712
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //컬렉션 ( 1. 비제너릭 컬렉션 / 2. 제너릭 컬렉션)
//            // ArrayList => List<T>
//            // List => LinkedList<T>
//            // SortedList => SortedList<T>
//            // Hashtable => Dictionary<K,V>
//            // Stack , Queue = Stack<T> Queue<T>
//            ArrayList al = new ArrayList();
//            List<int> lt = new List<int>();
//            al.Add(10); al.Add(20); al.Add(30);
//            lt.Add(10); lt.Add(20); lt.Add(30);

//            foreach(var data in al)
//                Console.Write("{0} ", data);
//            Console.WriteLine();
//            foreach (var data in lt)
//                Console.Write("{0} ", data);
//            Console.WriteLine();
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220712
//{
//    class Point
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//        public Point():this(0,0) {  }
//        public Point(int x , int y)
//        {
//            X = x;
//            Y = y;
//        }
//        public override string ToString()
//        {
//            return $"({X}, {Y}) ";
//        }
//    }
//    class UArray<T> : IEnumerable where T: new()    // class(참조), struct(값 타입), interface(인터페이스 구현타입), new() (기본 생성자)
//    {
//        private T[] parr;
//        private int size;

//        public int Count => size;

//        public UArray()
//        {
//            parr = new T[100];
//            size = 0;
//        }

//        public void Add(T data)
//        {
//            parr[size++] = data;
//        }
//        public void Remove(int idx)
//        {
//            for (int i = idx; i < size - 1; ++i)
//                parr[i] = parr[i + 1];
//            --size;
//        }
//        public T At(int idx)
//        {
//            return parr[idx];
//        }

//        public IEnumerator GetEnumerator()  //커런트가 오브젝트 형식임
//        {
//            for (int i = 0; i < size; ++i)
//                yield return parr[i];
//        }

//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            UArray<int> arr = new UArray<int>();

//            arr.Add(10);
//            arr.Add(20);
//            arr.Add(30);

//            foreach (var n in arr)
//                Console.Write("{0} ", n);
//            Console.WriteLine();

//            UArray<Point> parr = new UArray<Point>();

//            parr.Add(new Point(2, 3));
//            parr.Add(new Point(4, 5));
//            parr.Add(new Point(7, 8));

//            foreach (var pt in parr)
//                Console.Write("{0} ", pt);
//            Console.WriteLine();
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220712
//{
//    class Point
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//        public Point(int x = 0, int y = 0)
//        {
//            X = x;
//            Y = y;
//        }
//        public override string ToString()
//        {
//            return $"({X}, {Y}) ";
//        }
//    }
//        class UArray<T> : IEnumerable
//        {
//            private T[] parr;
//            private int size;

//            public int Count => size;

//            public UArray()
//            {
//                parr = new T[100];
//                size = 0;
//            }

//            public void Add(T data)
//            {
//                parr[size++] = data;
//            }
//            public void Remove(int idx)
//            {
//                for (int i = idx; i < size - 1; ++i)
//                    parr[i] = parr[i + 1];
//                --size;
//            }
//            public T At(int idx)
//            {
//                return parr[idx];
//            }

//            public IEnumerator GetEnumerator()  //커런트가 오브젝트 형식임
//            {
//                for (int i = 0; i < size; ++i)
//                    yield return parr[i];
//            }

//        }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            UArray<int> arr = new UArray<int>();

//            arr.Add(10);
//            arr.Add(20);
//            arr.Add(30);

//            foreach(var n in arr)
//                Console.Write("{0} ", n);
//            Console.WriteLine();
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220712
//{
//    class Point
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//        public Point(int x = 0, int y = 0)
//        {
//            X = x;
//            Y = y;
//        }
//        public override string ToString()
//        {
//            return $"({X}, {Y}) ";
//        }
//    }
//    class Program
//    {
//        static void Print<T, U>(T data1, U data2)   //꺽새가 있으면 일반 메소드 꺽새 있으면 제너릭 메소드
//        {
//            Console.WriteLine("{0}-{1} : {2}-{3}", typeof(T).Name, typeof(U).Name, data1, data2);  //타입을 얻는 2번 째 방법
//        }
//        static void Swap<T>(ref T a, ref T b) 
//        {
//            T t = a;
//            a = b;
//            b = t;
//        }
//        static void Main(string[] args)
//        {
//            int a = 10, b = 20;
//            Print(a, b);
//            Swap(ref a, ref b);
//            Print(a, b);

//            string s1 = "Hello!", s2 = "12345";
//            Print(s1, s2);
//            Swap(ref s1, ref s2);
//            Print(s1, s2);
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220712
//{
//    class Point
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//        public Point(int x = 0, int y = 0)
//        {
//            X = x;
//            Y = y;
//        }
//        public override string ToString()
//        {
//            return $"({X}, {Y}) ";
//        }
//    }
//    class Program
//    {
//        static void Print<T, U>(T data1, U data2 )   //꺽새가 있으면 일반 메소드 꺽새 있으면 제너릭 메소드
//        {
//            Console.WriteLine("{0}-{1} : {2}-{3}", typeof(T).Name, typeof(U).Name, data1, data2);  //타입을 얻는 2번 째 방법
//        }
//        static void Main(string[] args)
//        {
//            Print(100,200);
//            Print(5.5,100);
//            Print("Hello!",5.5);
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220712
//{
//    class Point
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//        public Point(int x = 0, int y = 0)
//        {
//            X = x;
//            Y = y;
//        }
//        public override string ToString()
//        {
//            return $"({X}, {Y}) ";
//        }
//    }
//    class Program
//    {
//        static void Print<T>(T data)   //꺽새가 있으면 일반 메소드 꺽새 있으면 제너릭 메소드
//        {
//            Console.WriteLine("{0} : {1}", typeof(T).Name, data);  //타입을 얻는 2번 째 방법
//        }
//        static void Main(string[] args)
//        {
//            Print<int>(100);
//            Print<double>(5.5);
//            Print<string>("Hello!");
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220712
//{
//    class Point
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//        public Point(int x = 0, int y = 0)
//        {
//            X = x;
//            Y = y;
//        }
//        public override string ToString()
//        {
//            return $"({X}, {Y}) ";
//        }
//    }
//    class Program
//    {
//        static void Print<T>(T data)   //꺽새가 있으면 일반 메소드 꺽새 있으면 제너릭 메소드
//        {
//            Console.WriteLine("{0} : {1}", typeof(T).Name,data);  //타입을 얻는 2번 째 방법
//        }
//        static void Main(string[] args)
//        {
//            Print(100);
//            Print(5.5);
//            Print("Hello!");
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220712
//{
//    class Point
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//        public Point(int x = 0, int y = 0)
//        {
//            X = x;
//            Y = y;
//        }
//        public override string ToString()
//        {
//            return $"({X}, {Y}) ";
//        }
//    }
//    class PointArray : IEnumerable<Point>
//    {
//        private Point[] parr;
//        private int size;

//        public int Count => size;

//        public PointArray()
//        {
//            parr = new Point[100];
//            size = 0;
//        }

//        public void Add(Point data)
//        {
//            parr[size++] = data;
//        }
//        public void Remove(int idx)
//        {
//            for (int i = idx; i < size - 1; ++i)
//                parr[i] = parr[i + 1];
//            --size;
//        }
//        public Point At(int idx)
//        {
//            return parr[idx];
//        }

//        public IEnumerator GetEnumerator()  //커런트가 오브젝트 형식임
//        {
//            for (int i = 0; i < size; ++i)
//                yield return parr[i];
//        }

//        IEnumerator<Point> IEnumerable<Point>.GetEnumerator()  // T형식을 던짐
//        {
//            for (int i = 0; i < size; ++i)
//                yield return parr[i];  
//        }
//    }
//    class Program
//    {
//        static void PrintEnumerable(IEnumerable<Point> ie)
//        {
//            foreach (var pt in ie)
//                Console.WriteLine(pt);
//        }
//        static void Main(string[] args)
//        {
//            PointArray parr = new PointArray();

//            parr.Add(new Point(2, 3));
//            parr.Add(new Point(7, 3));
//            parr.Add(new Point(4, 3));
//            parr.Add(new Point(5, 1));
//            parr.Add(new Point(3, 3));

//            PrintEnumerable(parr);

//            //Array.Sort(parr);   Linq 메소드로 해결 가능 !!! 
//            PrintEnumerable(parr as IEnumerable<Point>);
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220712
//{
//    class Point
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//        public Point(int x = 0, int y = 0)
//        {
//            X = x;
//            Y = y;
//        }
//        public override string ToString()
//        {
//            return $"({X}, {Y}) ";
//        }
//    }
//    class PointArray : IEnumerable
//    {
//        private Point[] parr;
//        private int size;

//        public int Count => size;

//        public PointArray()
//        {
//            parr = new Point[100];
//            size = 0;
//        }

//        public void Add(Point data)
//        {
//            parr[size++] = data;
//        }
//        public void Remove(int idx)
//        {
//            for (int i = idx; i < size - 1; ++i)
//                parr[i] = parr[i + 1];
//            --size;
//        }
//        public Point At(int idx)
//        {
//            return parr[idx];
//        }

//        public IEnumerator GetEnumerator()
//        {
//            for (int i = 0; i < size; ++i)
//                yield return parr[i];
//        }
//    }
//    class Program
//    {
//        static void PrintEnumerable(IEnumerable ie)
//        {
//            foreach (var pt in ie)
//                Console.WriteLine(pt);
//        }
//        static void Main(string[] args)
//        {
//            PointArray parr = new PointArray();

//            parr.Add(new Point(2, 3));
//            parr.Add(new Point(7, 3));
//            parr.Add(new Point(4, 3));
//            parr.Add(new Point(5, 1));
//            parr.Add(new Point(3, 3));

//            PrintEnumerable(parr as IEnumerable);

//            //Array.Sort(parr);   Linq 메소드로 해결 가능 !!! 
//            PrintEnumerable(parr as IEnumerable);
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220712
//{
//    class Point
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//        public Point(int x = 0, int y = 0)
//        {
//            X = x;
//            Y = y;
//        }
//        public override string ToString()
//        {
//            return $"({X}, {Y}) ";
//        }
//    }
//    class PointArray : IEnumerable
//    {
//        private Point[] parr;
//        private int size;

//        public int Count => size;

//        public PointArray()
//        {
//            parr = new Point[100];
//            size = 0;
//        }

//        public void Add(Point data)
//        {
//            parr[size++] = data;
//        }
//        public void Remove(int idx)
//        {
//            for (int i = idx; i < size - 1; ++i)
//                parr[i] = parr[i + 1];
//            --size;
//        }
//        public Point At(int idx)
//        {
//            return parr[idx];
//        }

//        public IEnumerator GetEnumerator()
//        {
//            for (int i = 0; i < size; ++i)
//                yield return parr[i];
//        }
//    }
//    class Program
//    {
//        static void PrintEnumerable(IEnumerable ie)
//        {
//            foreach (var pt in ie)
//                Console.WriteLine(pt);
//        }
//        static void Main(string[] args)
//        {
//            PointArray parr = new PointArray();

//            parr.Add(new Point(2, 3));
//            parr.Add(new Point(7, 3));
//            parr.Add(new Point(4, 3));
//            parr.Add(new Point(5, 1));
//            parr.Add(new Point(3, 3));

//            PrintEnumerable(parr as IEnumerable);

//            int[] arr = { 1, 2, 3, 4, 5 };

//            PrintEnumerable(arr as IEnumerable);
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220712
//{
//    class Point
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//        public Point(int x = 0, int y = 0)
//        {
//            X = x;
//            Y = y;
//        }
//        public override string ToString()
//        {
//            return $"({X}, {Y}) ";
//        }
//    }
//    class PointArray : IEnumerable
//    {
//        private Point[] parr;
//        private int size;

//        public int Count => size;

//        public PointArray()
//        {
//            parr = new Point[100];
//            size = 0;
//        }

//        public void Add(Point data)
//        {
//            parr[size++] = data;
//        }
//        public void Remove(int idx)
//        {
//            for (int i = idx; i < size - 1; ++i)
//                parr[i] = parr[i + 1];
//            --size;
//        }
//        public Point At(int idx)
//        {
//            return parr[idx];
//        }

//        public IEnumerator GetEnumerator()
//        {
//            for (int i = 0; i < size; ++i)
//                yield return parr[i];
//        }
//    }
//    class Program
//    {
//        static void PrintArray(PointArray parr)
//        {
//            foreach (var pt in parr)
//                Console.WriteLine(pt);

//        }
//        static void Main(string[] args)
//        {
//            PointArray parr = new PointArray();

//            parr.Add(new Point(2, 3));
//            parr.Add(new Point(7, 3));
//            parr.Add(new Point(4, 3));
//            parr.Add(new Point(5, 1));
//            parr.Add(new Point(3, 3));

//            PrintArray(parr);
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220712
//{
//    class Point
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//        public Point(int x = 0, int y = 0)
//        {
//            X = x;
//            Y = y;
//        }
//        public override string ToString()
//        {
//            return $"({X}, {Y}) ";
//        }
//    }
//    class PointArray : IEnumerable
//    {
//        private Point[] parr;
//        private int size;

//        public int Count => size;

//        public PointArray()
//        {
//            parr = new Point[100];
//            size = 0;
//        }

//        public void Add(Point data)
//        {
//            parr[size++] = data;
//        }
//        public void Remove(int idx)
//        {
//            for (int i = idx; i < size - 1; ++i)
//                parr[i] = parr[i + 1];
//            --size;
//        }
//        public Point At(int idx)
//        {
//            return parr[idx];
//        }

//        public IEnumerator GetEnumerator()
//        {
//            for (int i = 0; i < size; ++i)
//                yield return parr[i];
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            PointArray parr = new PointArray();

//            parr.Add(new Point(2, 3));
//            parr.Add(new Point(7, 3));
//            parr.Add(new Point(4, 3));
//            parr.Add(new Point(5, 1));
//            parr.Add(new Point(3, 3));

//            foreach (var pt in parr)
//                Console.WriteLine(pt);
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220711
//{
//    class Point
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//        public Point(int x = 0, int y = 0)
//        {
//            X = x;
//            Y = y;
//        }
//        public override string ToString()
//        {
//            return $"({X},{Y}) ";
//        }
//    }
//    class PointArray
//    {
//        private Point[] parr = new Point[100];
//        private int size;

//        public int Count => size; /*{ get { return size; } }*/ //get이 생략되어있다.

//        public PointArray()
//        {
//            parr = new Point[100];
//            size = 0;
//        }
//        public void Add(Point data)
//        {
//            parr[size++] = data;
//        }
//        public void Remove(int idx)
//        {
//            for (int i = idx; i < size - 1; ++i)
//                parr[i] = parr[i + 1];
//            --size;
//        }
//        public Point At(int idx)
//        {
//            return parr[idx];
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            PointArray parr = new PointArray();

//            parr.Add(new Point(2, 3));
//            parr.Add(new Point(7, 3));
//            parr.Add(new Point(4, 3));
//            parr.Add(new Point(5, 1));
//            parr.Add(new Point(3, 3));

//            for (int i = 0; i < parr.Count; ++i)
//                Console.WriteLine(parr.At(i).ToString());
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


////16-4  IEnumerable & IEnumerator
//namespace ex220712
//{
//    class IntArray : IEnumerable
//    {
//        List<int> lt = new List<int>();
//        public IntArray(int[] arr)
//        {
//            lt.AddRange(arr);   //한번에 집어넣음
//        }
//        public IEnumerator GetEnumerator()
//        {
//            for(int i = 0; i < lt.Count; i++)
//                yield return lt[i];


//        }
//    }

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


////16-4  IEnumerable & IEnumerator
//namespace ex220712
//{
//    class IntArray : IEnumerable
//    {
//        List<int> lt = new List<int>();
//        public IntArray(int[] arr)
//        {
//            lt.AddRange(arr);   //한번에 집어넣음
//        }



//        public IEnumerator GetEnumerator()
//        {
//            yield return 10;
//            yield return 30;
//            yield return 50;
//            yield return 70;
//            yield return 90;
//        }


//    }

//internal class Program
//    {
//        static void Main(string[] args)
//        {
//            IntArray arr = new IntArray(new int[] { 10, 20, 30, 40, 50 });
//            IEnumerable ie = arr as IEnumerable;
//            IEnumerator etor = ie.GetEnumerator();
//            while (etor.MoveNext())
//                Console.Write("{0} ", etor.Current);
//            Console.WriteLine();


//            foreach (var elem in arr)   //IEnurmerable 하게 되면 foreach 사용가능
//                Console.Write("{0} ", elem);
//            Console.WriteLine();
//        }
//    }
//}