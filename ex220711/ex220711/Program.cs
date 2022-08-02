using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//16-4  IEnumerable & IEnumerator
namespace ex220711
{
    class IntArray : IEnumerable
    {
        class Etor : IEnumerator
        {

            private int curIndex = -1;
            private List<int> list;
            public Etor(List<int> lt) { list = lt; }
            public object Current { get { return list[curIndex]; } }    //현재위치의 원소 반환

            public bool MoveNext()     //더이상 이동불가 faluse 이동가능 true
            {
                ++curIndex;
                return curIndex < list.Count; // 끝이 아닐경우 이동
            }

            public void Reset()
            {
                curIndex = -1;
            }
        }
        List<int> lt = new List<int>();
        public IntArray(int[] arr)
        {
            lt.AddRange(arr);   //한번에 집어넣음
        }



        public IEnumerator GetEnumerator()
        {
            return new Etor(lt);
        }


    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IntArray arr = new IntArray(new int[] { 10, 20, 30, 40, 50 });
            IEnumerable ie = arr as IEnumerable;
            IEnumerator etor = ie.GetEnumerator();
            while (etor.MoveNext())
                Console.Write("{0} ", etor.Current);
            Console.WriteLine();


            foreach (var elem in arr)   //IEnurmerable 하게 되면 foreach 사용가능
                Console.Write("{0} ", elem);
            Console.WriteLine();
        }
    }
}
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220711
//{
//    class IntArray : IEnumerable, IEnumerator
//    {
//        List<int> lt = new List<int>();
//        public IntArray(int[] arr)
//        {
//            lt.AddRange(arr);
//        }

//        private int curIndex = -1;
//        public object Current { get { return lt[curIndex]; } } //무조건 현재 위치 반환 

//        public IEnumerator GetEnumerator()
//        {
//            return this as IEnumerator;
//        }

//        public bool MoveNext()
//        {
//            ++curIndex;
//            return curIndex < lt.Count;
//        }

//        public void Reset()
//        {
//            curIndex = -1;
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            IntArray arr = new IntArray(new int[] { 10, 20, 30, 40, 50 });

//            IEnumerable ie = arr as IEnumerable;
//            IEnumerator etor = ie.GetEnumerator();
//            while (etor.MoveNext())
//                Console.Write("{0} ", etor.Current);
//            Console.WriteLine();
//            etor.Reset();

//            foreach (var elem in arr)
//                Console.Write("{0} ", elem);
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

//namespace ex220711
//{
//    class IntArray : IEnumerable
//    {
//        List<int> lt = new List<int>();
//        public IntArray(int[] arr)
//        {
//            lt.AddRange(arr);
//        }

//        public IEnumerator GetEnumerator()
//        {
//            return lt.GetEnumerator();
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            IntArray arr = new IntArray(new int[]{ 10, 20, 30, 40, 50 });

//            IEnumerable ie = arr as IEnumerable;
//            IEnumerator etor = ie.GetEnumerator();
//            while (etor.MoveNext())
//                Console.Write("{0} ", etor.Current);
//            Console.WriteLine();

//            foreach(var elem in arr)
//                Console.Write("{0} ", elem);
//            Console.WriteLine();
//        }
//    }
//}

//// 표준 인터페이스
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220711
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr = { 10, 20, 30, 40, 50 };

//            IEnumerable ie = arr as IEnumerable;
//            IEnumerator etor = ie.GetEnumerator();
//            while (etor.MoveNext())
//                Console.Write("{0} ", etor.Current);
//            Console.WriteLine();

//        }
//    }
//}

//// 표준 인터페이스
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220711
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr = { 10, 20, 30, 40, 50 };

//            foreach(var elem in arr)  //IEnumerable;
//                Console.Write("{0} ",elem);
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

//namespace ex220711
//{
//    class Point : ICloneable
//    {
//        class DescPointCompare : IComparer  //private
//        {
//            public int Compare(object x, object y)
//            {
//                Point a = x as Point;
//                Point b = y as Point;
//                if (a.X < b.X)
//                    return 1;
//                else if (a.X > b.X)
//                    return -1;
//                else
//                    return 0;
//            }
//        }
//        class PointCompare : IComparer
//        {
//            public int Compare(object x, object y)
//            {
//                Point a = x as Point;
//                Point b = y as Point;
//                if (a.X > b.X)
//                    return 1;
//                else if (a.X < b.X)
//                    return -1;
//                else
//                    return 0;
//            }
//        }
//        public static IComparer Asceding { get { return new PointCompare(); } }  //정적 속성
//        public static IComparer Desceing { get { return new DescPointCompare(); } }  //정적 속성
//        public int X { get; set; }
//        public int Y { get; set; }
//        public Point(int _x = 0, int _y = 0)
//        {
//            X = _x;
//            Y = _y;
//        }
//        public override string ToString()
//        {
//            return $"({X},{Y})";
//        }

//        public object Clone()
//        {
//            return MemberwiseClone();
//        }

//    }

//    class Program
//    {

//        static void Main(string[] args)
//        {
//            Point[] parr = { new Point(1, 2), new Point(5, 6), new Point(3, 2), new Point(4, 5), new Point(2, 3) };

//            Array.Sort(parr, Point.Desceing);
//            foreach (var pt in parr)
//                Console.WriteLine(pt);
//            Array.Sort(parr, Point.Asceding);
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
//    class Point : ICloneable
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//        public Point(int _x = 0, int _y = 0)
//        {
//            X = _x;
//            Y = _y;
//        }
//        public override string ToString()
//        {
//            return $"({X},{Y})";
//        }

//        public object Clone()
//        {
//            return MemberwiseClone();
//        }

//    }
//    class DescPointCompare : IComparer
//    {
//        public int Compare(object x, object y)
//        {
//            Point a = x as Point;
//            Point b = y as Point;
//            if (a.X < b.X)
//                return 1;
//            else if (a.X > b.X)
//                return -1;
//            else
//                return 0;
//        }
//    }
//    class Program
//    {

//        static void Main(string[] args)
//        {
//            Point[] parr = { new Point(1, 2), new Point(5, 6), new Point(3, 2), new Point(4, 5), new Point(2, 3) };

//            Array.Sort(parr,new DescPointCompare());
//            foreach (var pt in parr)
//                Console.WriteLine(pt);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220711
//{
//    class Point : ICloneable, IComparable
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//        public Point(int _x = 0, int _y = 0)
//        {
//            X = _x;
//            Y = _y;
//        }
//        public override string ToString()
//        {
//            return $"({X},{Y})";
//        }

//        public object Clone()
//        {
//            return MemberwiseClone();
//        }

//        public int CompareTo(object obj)
//        {
//            Point pt = obj as Point;
//            if (X > pt.X)
//                return 1;
//            else if (X < pt.X)
//                return -1;
//            else
//                return 0;
//        }
//    }
//     class Program
//    {

//        static void Main(string[] args)
//        {
//            Point[] parr = { new Point(1, 2), new Point(5, 6), new Point(3, 2), new Point(4, 5), new Point(2, 3) };

//            Array.Sort(parr);
//            foreach (var pt in parr)
//                Console.WriteLine(pt);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220711
//{
//    class Resource : IDisposable
//    {
//        public Resource()
//        {
//            Console.WriteLine("리소스 할당 or 사용");
//        }
//        public void Dispose()
//        {
//            Console.WriteLine("리소스 해제");
//        }
//    }
//    class Program
//    {
//        static void Print()
//        {

//        }
//        static void Main(string[] args)
//        {
//            using (Resource r = new Resource(), r2 = new Resource()) ;
//            {
//                Console.WriteLine("열심히 리소스 사용즁");
//            }
//            Console.WriteLine(" end ");

//        }
//    }

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220711
//{
//    class Resource : IDisposable
//    {
//        public Resource()
//        {
//            Console.WriteLine("리소스 할당 or 사용");
//        }
//        public void Dispose()
//        {
//            Console.WriteLine("리소스 해제");
//        }
//    }
//    class Program
//    {
//        static void Print()
//        {

//        }
//        static void Main(string[] args)
//        {
//            using (Resource r = new Resource())
//            {
//                Console.WriteLine("열심히 리소스 사용즁");
//            }
//            Console.WriteLine(" end ");

//        }
//    }

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220711
//{
//    class Resource : IDisposable
//    {
//        public Resource()
//        {
//            Console.WriteLine("리소스 할당 or 사용");
//        }
//        public void Dispose()
//        {
//            Console.WriteLine("리소스 해제");
//        }
//    }
//    class Program
//    {
//        static void Print()
//        {

//        }
//        static void Main(string[] args)
//        {
//            using (Resource r = new Resource())
//            {
//                Console.WriteLine("열심히 리소스 사용즁");
//            }
//            Console.WriteLine(" end ");

//        }
//    }

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220711
//{
//    class Resource : IDisposable
//    {
//        public Resource()
//        {
//            Console.WriteLine("리소스 할당 or 사용");
//        } 
//        public void Dispose()
//        {
//            Console.WriteLine("리소스 해제");
//        }
//    }
//    class Program
//    {
//        static void Print()
//        {

//        }
//        static void Main(string[] args)
//        {
//            Resource r = new Resource();
//            r.Dispose();

//            Console.WriteLine(" end ");

//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220711
//{
//    class Point : ICloneable
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
//            return $"({X},{Y})";
//        }

//        public object Clone()
//        {
//            return MemberwiseClone(); 
//        }
//    }
//    class Rect : ICloneable
//    {
//        Point pt;
//        int width;
//        int height;
//        public Rect(Point pt, int w, int h)
//        {
//            this.pt = pt;
//            this.width = w;
//            this.height = h;
//        }

//        public override string ToString()
//        {
//            return $"Rect : {pt}, w : {width} , h : {height}";
//        }

//        public object Clone()
//        {
//            Rect t = (Rect)MemberwiseClone();
//            t.pt = (Point)(t.pt as ICloneable).Clone();

//            return t;
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Point pt = new Point(2, 3);
//            Point pt2 = (Point)(pt as ICloneable).Clone() as Point;

//            Rect r = new Rect(new Point(0, 0), 100, 150);
//            Rect r2 = (Rect)(r as ICloneable).Clone();

//            Console.WriteLine(r);
//            Console.WriteLine(r2);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220711
//{
//    struct Point
//    {
//        public int X;
//        public int Y;
//        public Point(int _x, int _y)
//        {
//            X = _x;
//            Y = _y;
//        }
//        public override string ToString()
//        {
//            return $"({X},{Y})";
//        }
//    }
//    interface IPrint
//    {
//        void Print();
//    }
//    interface IPointy : IPrint
//    {
//        int GetPoints();
//    }
//    interface IClone
//    {
//        object Clone();
//    }
//    internal abstract class Shap
//    {
//        public int ShapId { get; set; }
//        public Shap(int _shapId)
//        {
//            this.ShapId = _shapId;
//        }
//        public abstract void Draw();// virtual=0; abstract= 추상 메소드
//    }
//    internal class Rect : Shap, IPointy, IClone
//    {
//        int x, y;
//        int width, height;
//        public Rect(int _x, int _y, int _width, int _height, int id) : base(id)
//        {
//            this.x = _x;
//            this.y = _y;
//            this.width = _width;
//            this.height = _height;
//        }

//        public override void Draw()
//        {
//            Console.WriteLine(this);
//        }

//        public string GetPoints()
//        {
//            return " 4 points ";
//        }

//        public void Print()
//        {
//            Console.WriteLine("use Printer");
//        }
//        public object Clone()
//        {
//           return MemberwiseClone();
//        }
//        public override string ToString()
//        {
//            return $"[{ShapId}],{x},{y},w={width},h={height}";
//        }
//        int IPointy.GetPoints() //명시적 인터페이스 메소드 구현 
//        {
//            return 4;
//        }
//    }
//    //internal class LogRect : Rect
//    //{
//    //    public LogRect(int x, int y, int w, int h, int id) : base(x, y, w, h, id) { }
//    //    public new void Draw()  //밑에 주석코드와 100% 동일하지만 이 코드가 훨씬 좋은 코드이다.
//    //    {
//    //        Console.WriteLine("log : {0}", base.ToString());
//    //    }
//    //    //public void Print()
//    //    //{
//    //    //    Console.WriteLine("log : {0}", base.ToString());
//    //    //}
//    //}
//    internal class Circle : Shap
//    {
//        int x, y;
//        int redius;
//        public Circle(int _x, int _y, int _redius, int id) : base(id)
//        {
//            this.x = _x;
//            this.y = _y;
//            this.redius = _redius;
//        }
//        public override void Draw()
//        {
//            Console.WriteLine(this);
//        }
//        public override string ToString()
//        {
//            return $"[{ShapId}],{x},{y} redius={redius}";
//        }
//    }
//    internal class Polygon : Shap, IPointy
//    {
//        List<Point> ptList = new List<Point>();
//        public Polygon(int count, int id) : base(id)
//        {

//            Random r = new Random();

//            for (int i = 0; i < count; ++i)
//            {
//                int x = r.Next(100);
//                int y = r.Next(100);
//                ptList.Add(new Point(x, y));
//            }
//        }
//        public override void Draw()
//        {
//            Console.WriteLine(this);
//        }
//        public override string ToString()
//        {
//            string s = "";
//            for (int i = 0; i < ptList.Count; ++i)
//            {
//                s += ptList[i] + " ";
//            }
//            return $"[{ShapId}] {s}";
//        }
//        public int GetPoints()
//        {
//            return ptList.Count;
//        }
//        public void Print()
//        {
//            Console.WriteLine("use printer");
//        }
//    }
//    internal class Program
//    {

//        static void Main(string[] args)
//        {
//            Rect r = new Rect(0, 0, 100, 100, 101020);
//            Circle c = new Circle(0, 0, 12, 101030);
//            Polygon p = new Polygon(10, 101050);

//            List<Shap> lt = new List<Shap> { r, c, p };
//            foreach (var s in lt)
//                s.Draw();

//            (r as IPrint).Print();
//            Console.WriteLine((r as IPointy).GetPoints());
//            Console.WriteLine((r as IClone).Clone());
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220711
//{
//    struct Point
//    {
//        public int X;
//        public int Y;
//        public Point(int _x, int _y)
//        {
//            X = _x;
//            Y = _y;
//        }
//        public override string ToString()
//        {
//            return $"({X},{Y})";
//        }
//    }
//    interface IPointy
//    {
//        int GetPoints();
//    }
//    internal abstract class Shap
//    {
//        public int ShapId { get; set; }
//        public Shap(int _shapId)
//        {
//            this.ShapId = _shapId;
//        }
//        public abstract void Draw();// virtual=0; abstract= 추상 메소드
//    }
//    internal class Rect : Shap, IPointy
//    {
//        int x, y;
//        int width, height;
//        public Rect(int _x, int _y, int _width, int _height, int id) : base(id)
//        {
//            this.x = _x;
//            this.y = _y;
//            this.width = _width;
//            this.height = _height;
//        }
//        public override void Draw()
//        {
//            Console.WriteLine(this);
//        }

//        public string GetPoints()
//        {
//            return " 4 points ";
//        }
//        public override string ToString()
//        {
//            return $"[{ShapId}],{x},{y},w={width},h={height}";
//        }
//        int IPointy.GetPoints() //명시적 인터페이스 메소드 구현 
//        {
//            return 4;
//        }
//    }
//    internal class LogRect : Rect
//    {
//        public LogRect(int x, int y, int w, int h, int id) : base(x, y, w, h, id) { }
//        public new void Draw()  //밑에 주석코드와 100% 동일하지만 이 코드가 훨씬 좋은 코드이다.
//        {
//            Console.WriteLine("log : {0}", base.ToString());
//        }
//        //public void Print()
//        //{
//        //    Console.WriteLine("log : {0}", base.ToString());
//        //}
//    }
//    internal class Circle : Shap
//    {
//        int x, y;
//        int redius;
//        public Circle(int _x, int _y, int _redius, int id) : base(id)
//        {
//            this.x = _x;
//            this.y = _y;
//            this.redius = _redius;
//        }
//        public override void Draw()
//        {
//            Console.WriteLine(this);
//        }
//        public override string ToString()
//        {
//            return $"[{ShapId}],{x},{y} redius={redius}";
//        }
//    }
//    internal class Polygon : Shap, IPointy
//    {
//        List<Point> ptList = new List<Point>();
//        public Polygon(int count, int id) : base(id)
//        {

//            Random r = new Random();

//            for (int i = 0; i < count; ++i)
//            {
//                int x = r.Next(100);
//                int y = r.Next(100);
//                ptList.Add(new Point(x, y));
//            }
//        }
//        public override void Draw()
//        {
//            Console.WriteLine(this);
//        }
//        public override string ToString()
//        {
//            string s = "";
//            for (int i = 0; i < ptList.Count; ++i)
//            {
//                s += ptList[i] + " ";
//            }
//            return $"[{ShapId}] {s}";
//        }
//        public int GetPoints()
//        {
//            return ptList.Count;
//        }
//    }
//    internal class Program
//    {

//        static void Main(string[] args)
//        {
//            LogRect lr = new LogRect(0, 0, 100, 100, 101020);
//            Shap r = lr;

//            r.Draw();
//            lr.Draw();
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220711
//{
//    struct Point
//    {
//        public int X;
//        public int Y;
//        public Point(int _x, int _y)
//        {
//            X = _x;
//            Y = _y;
//        }
//        public override string ToString()
//        {
//            return $"({X},{Y})";
//        }
//    }
//    interface IPointy
//    {
//        int GetPoints();
//    }
//    internal abstract class Shap
//    {
//        public int ShapId { get; set; }
//        public Shap(int _shapId)
//        {
//            this.ShapId = _shapId;
//        }
//        public abstract void Draw();// virtual=0; abstract= 추상 메소드
//    }
//    internal class Rect : Shap, IPointy
//    {
//        int x, y;
//        int width, height;
//        public Rect(int _x, int _y, int _width, int _height, int id) : base(id)
//        {
//            this.x = _x;
//            this.y = _y;
//            this.width = _width;
//            this.height = _height;
//        }
//        public override void Draw()
//        {
//            Console.WriteLine(this);
//        }

//        public string GetPoints()
//        {
//            return " 4 points ";
//        }
//        public override string ToString()
//        {
//            return $"[{ShapId}],{x},{y},w={width},h={height}";
//        }
//        int IPointy.GetPoints() //명시적 인터페이스 메소드 구현 
//        {
//            return 4;
//        }
//    }
//    internal class Circle : Shap
//    {
//        int x, y;
//        int redius;
//        public Circle(int _x, int _y, int _redius, int id) : base(id)
//        {
//            this.x = _x;
//            this.y = _y;
//            this.redius = _redius;
//        }
//        public override void Draw()
//        {
//            Console.WriteLine(this);
//        }
//        public override string ToString()
//        {
//            return $"[{ShapId}],{x},{y} redius={redius}";
//        }
//    }
//    internal class Polygon : Shap, IPointy
//    {
//        List<Point> ptList = new List<Point>();
//        public Polygon(int count, int id) : base(id)
//        {

//            Random r = new Random();

//            for (int i = 0; i < count; ++i)
//            {
//                int x = r.Next(100);
//                int y = r.Next(100);
//                ptList.Add(new Point(x, y));
//            }
//        }
//        public override void Draw()
//        {
//            Console.WriteLine(this);
//        }
//        public override string ToString()
//        {
//            string s = "";
//            for (int i = 0; i < ptList.Count; ++i)
//            {
//                s += ptList[i] + " ";
//            }
//            return $"[{ShapId}] {s}";
//        }
//        public int GetPoints()
//        {
//            return ptList.Count;
//        }
//    }
//    internal class Program
//    {

//        static void Main(string[] args)
//        {
//            Rect r = new Rect(0, 0, 100, 100, 101020);

//            Console.WriteLine("Rect : {0}", r.GetPoints());

//            IPointy ip = r as IPointy;
//            Console.WriteLine("Rect : {0} ", ip.GetPoints());
//        }
//    }
//}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220711
//{
//    struct Point
//    {
//        public int X;
//        public int Y;
//        public Point(int _x, int _y)
//        {
//            X = _x;
//            Y = _y;
//        }
//        public override string ToString()
//        {
//            return $"({X},{Y})";
//        }
//    }
//    interface IPointy
//    {
//        int GetPoints();
//    }
//    internal abstract class Shap
//    {
//        public int ShapId { get; set; }
//        public Shap(int _shapId)
//        {
//            this.ShapId = _shapId;
//        }
//        public abstract void Draw();// virtual=0; abstract= 추상 메소드
//    }
//    internal class Rect : Shap, IPointy
//    {
//        int x, y;
//        int width, height;
//        public Rect(int _x, int _y, int _width, int _height, int id) : base(id)
//        {
//            this.x = _x;
//            this.y = _y;
//            this.width = _width;
//            this.height = _height;
//        }
//        public override void Draw()
//        {
//            Console.WriteLine(this);
//        }

//        public int GetPoints()
//        {
//            return 4;
//        }

//        public override string ToString()
//        {
//            return $"[{ShapId}],{x},{y},w={width},h={height}";
//        }

//    }
//    internal class Circle : Shap
//    {
//        int x, y;
//        int redius;
//        public Circle(int _x, int _y, int _redius, int id) : base(id)
//        {
//            this.x = _x;
//            this.y = _y;
//            this.redius = _redius;
//        }
//        public override void Draw()
//        {
//            Console.WriteLine(this);
//        }
//        public override string ToString()
//        {
//            return $"[{ShapId}],{x},{y} redius={redius}";
//        }
//    }
//    internal class Polygon : Shap, IPointy
//    {
//        List<Point> ptList = new List<Point>();
//        public Polygon(int count, int id) : base(id)
//        {

//            Random r = new Random();

//            for (int i = 0; i < count; ++i)
//            {
//                int x = r.Next(100);
//                int y = r.Next(100);
//                ptList.Add(new Point(x, y));
//            }
//        }
//        public override void Draw()
//        {
//            Console.WriteLine(this);
//        }
//        public override string ToString()
//        {
//            string s = "";
//            for (int i = 0; i < ptList.Count; ++i)
//            {
//                s += ptList[i] + " ";
//            }
//            return $"[{ShapId}] {s}";
//        }
//        public int GetPoints()
//        {
//            return ptList.Count;
//        }

//    }
//    internal class Program
//    {

//        static void Main(string[] args)
//        {
//            List<Shap> lt = new List<Shap>();
//            lt.Add(new Rect(0, 0, 100, 100, 101020));
//            lt.Add(new Circle(0, 0, 15, 103020));
//            lt.Add(new Polygon(6, 501020));
//            lt.Add(new Rect(10, 10, 50, 50, 101030));
//            lt.Add(new Circle(10, 10, 5, 103050));

//            foreach (var shape in lt)
//            {
//                IPointy ip = shape as IPointy;
//                if(ip != null)
//                    Console.WriteLine("{0} {1}", ip.GetPoints(), ((Shap)ip).GetType().Name);
//            }
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220711
//{
//    struct Point
//    {
//        public int X;
//        public int Y;
//        public Point(int _x, int _y)
//        {
//            X = _x;
//            Y = _y;
//        }
//        public override string ToString()
//        {
//            return $"({X},{Y})";
//        }
//    }
//    interface IPointy
//    {
//        int GetPoints();
//    }
//    internal abstract class Shap
//    {
//        public int ShapId { get; set; }
//        public Shap(int _shapId)
//        {
//            this.ShapId = _shapId;
//        }
//        public abstract void Draw();// virtual=0; abstract= 추상 메소드
//    }
//    internal class Rect : Shap , IPointy
//    {
//        int x, y;
//        int width, height;
//        public Rect(int _x, int _y, int _width, int _height, int id) : base(id)
//        {
//            this.x = _x;
//            this.y = _y;
//            this.width = _width;
//            this.height = _height;
//        }
//        public override void Draw()
//        {
//            Console.WriteLine(this);
//        }

//        public int GetPoints()
//        {
//            return 4;
//        }

//        public override string ToString()
//        {
//            return $"[{ShapId}],{x},{y},w={width},h={height}";
//        }

//    }
//    internal class Circle : Shap
//    {
//        int x, y;
//        int redius;
//        public Circle(int _x, int _y, int _redius, int id) : base(id)
//        {
//            this.x = _x;
//            this.y = _y;
//            this.redius = _redius;
//        }
//        public override void Draw()
//        {
//            Console.WriteLine(this);
//        }
//        public override string ToString()
//        {
//            return $"[{ShapId}],{x},{y} redius={redius}";
//        }
//    }
//    internal class Polygon : Shap , IPointy
//    {
//        List<Point> ptList = new List<Point>();
//        public Polygon(int count, int id) : base(id)
//        {

//            Random r = new Random();

//            for (int i = 0; i < count; ++i)
//            {
//                int x = r.Next(100);
//                int y = r.Next(100);
//                ptList.Add(new Point(x, y));
//            }
//        }
//        public override void Draw()
//        {
//            Console.WriteLine(this);
//        }
//        public override string ToString()
//        {
//            string s = "";
//            for (int i = 0; i < ptList.Count; ++i)
//            {
//                s += ptList[i] + " ";
//            }
//            return $"[{ShapId}] {s}";
//        }
//        public int GetPoints()
//        {
//            return ptList.Count;
//        }

//    }
//    internal class Program
//    {

//        static void Main(string[] args)
//        {
//            List<Shap> lt = new List<Shap>();
//            lt.Add(new Rect(0, 0, 100, 100, 101020));
//            lt.Add(new Circle(0, 0, 15, 103020));
//            lt.Add(new Polygon(6, 501020));
//            lt.Add(new Rect(10, 10, 50, 50, 101030));
//            lt.Add(new Circle(10, 10, 5, 103050));

//            Console.WriteLine(((Rect)lt[0]).GetPoints());
//            Console.WriteLine(((Polygon)lt[2]).GetPoints());
//            Console.WriteLine(((Rect)lt[3]).GetPoints());
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220711
//{
//    struct Point
//    {
//        public int X;
//        public int Y;
//        public Point(int _x, int _y)
//        {
//            X = _x;
//            Y = _y;
//        }
//        public override string ToString()
//        {
//            return $"({X},{Y})";
//        }
//    }
//    internal abstract class Shap
//    {
//        public int ShapId { get; set; }
//        public Shap(int _shapId)
//        {
//            this.ShapId = _shapId;
//        }
//        public abstract void Draw();// virtual=0; abstract= 추상 메소드
//    }
//    internal class Rect : Shap
//    {
//        int x, y;
//        int width, height;
//        public Rect(int _x, int _y, int _width, int _height, int id) : base(id)
//        {
//            this.x = _x;
//            this.y = _y;
//            this.width = _width;
//            this.height = _height;
//        }
//        public override void Draw()
//        {
//            Console.WriteLine(this);
//        }
//        public override string ToString()
//        {
//            return $"[{ShapId}],{x},{y},w={width},h={height}";
//        }

//    }
//    internal class Circle : Shap
//    {
//        int x, y;
//        int redius;
//        public Circle(int _x, int _y, int _redius, int id) : base(id)
//        {
//            this.x = _x;
//            this.y = _y;
//            this.redius = _redius;
//        }
//        public override void Draw()
//        {
//            Console.WriteLine(this);
//        }
//        public override string ToString()
//        {
//            return $"[{ShapId}],{x},{y} redius={redius}";
//        }
//    }
//    internal class Polygon : Shap
//    {
//        List<Point> ptList = new List<Point>();
//        public Polygon(int count, int id) : base(id)
//        {

//            Random r = new Random();

//            for (int i = 0; i < count; ++i)
//            {
//                int x = r.Next(100);
//                int y = r.Next(100);
//                ptList.Add(new Point(x, y));
//            }
//        }
//        public override void Draw()
//        {
//            Console.WriteLine(this);
//        }
//        public override string ToString()
//        {
//            string s = "";
//            for (int i = 0; i < ptList.Count; ++i)
//            {
//                s += ptList[i] + " ";
//            }
//            return $"[{ShapId}] {s}";
//        }

//    }
//    internal class Program
//    {

//        static void Main(string[] args)
//        {
//            List<Shap> lt = new List<Shap>();
//            lt.Add(new Rect(0, 0, 100, 100, 101020));
//            lt.Add(new Circle(0, 0, 15, 103020));
//            lt.Add(new Polygon(6, 501020));
//            lt.Add(new Rect(10, 10, 50, 50, 101030));
//            lt.Add(new Circle(10, 10, 5, 103050));

//            lt.ForEach((Shape) =>
//            {
//                Console.WriteLine("Shap -{0}", Shape);
//            });
//            Console.WriteLine();
//            for (int i = 0; i < lt.Count; ++i)
//            {
//                Console.WriteLine("Shap -{0}", lt[i]);
//            }
//            Console.WriteLine();
//            foreach (var Shape in lt)
//            {
//                Console.WriteLine("Shap -{0}", Shape);

//            }
//        }
//    }
//}
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


////4번 - polygon
//namespace ex220711
//{
//    struct Point
//    {
//        public int X;
//        public int Y;
//        public Point(int _x = 0, int _y = 0)
//        {
//            X = _x;
//            Y = _y;
//        }
//        public override string ToString()
//        {
//            return $"X : {X}, Y : {Y}";
//        }
//    }

//    internal abstract class Shape   //shape class는 인수를 만들어낼 수 없다!  internal - 어셈블리 내에서 사용한다  
//    {
//        public int ShapeID { get; set; }
//        public Shape(int id)      //id는 유니크하기떄문에 초기값 int id = 0 안됨 
//        {
//            ShapeID = id;
//        }
//        public abstract void Draw(); // abstract - 추상메소드, 순수가상함수와 같음 ==> virtual  = 0;
//    }

//    internal class Rect : Shape   // 상속
//    {
//        int x, y;
//        int width, height;
//        public Rect(int x, int y, int w, int h, int id) : base(id)
//        {
//            this.x = x;
//            this.y = y;
//            width = w;
//            height = h;
//        }
//        public override void Draw()  //추상메소드도 재정의하는 것이기에 override 써야함 
//        {
//            Console.WriteLine(this);        //this -> ToString 호출! --> 문자열로 변환해야하기때문에 내부적으로 to string 호출!    
//        }
//        public override string ToString()
//        {
//            return $"[{ShapeID}] x:{x}, y:{y}, w:{width}, h:{height}";
//        }
//    }
//    internal class Circle : Shape
//    {
//        int x, y;
//        int radius;
//        public Circle(int x, int y, int r, int id) : base(id)
//        {
//            this.x = x;
//            this.y = y;
//            this.radius = r;
//        }
//        public override void Draw()
//        {
//            Console.WriteLine(this);
//        }
//        public override string ToString()
//        {
//            return $"[{ShapeID}] x:{x}, y:{y}, r:{radius}";
//        }
//    }
//    internal class Polygon : Shape
//    {
//        List<Point> ptList = new List<Point>();

//        public Polygon(int count, int id) : base(id)
//        {

//            Random r = new Random();
//            for (int i = 0; i < count; ++i)    //갯수를 받으면 랜덤하게 저장
//            {
//                int x = r.Next(100);  //100보다 작은 정수 만들어냄
//                int y = r.Next(100);
//                ptList.Add(new Point(x, y));

//            }
//        }
//        public override void Draw()
//        {
//            Console.WriteLine(this);
//        }
//        public override string ToString()
//        {
//            string s = "";
//            for (int i = 0; i < ptList.Count; ++i)
//            {
//                s += ptList[i] + " ";
//            }
//            return $"[{ShapeID}] {s}";
//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Guid : {0}", Guid.NewGuid());
//            Shape shape = new Rect(0, 0, 100, 120, 1010);
//            shape.Draw();
//            shape = new Circle(1, 2, 10, 3050);
//            shape.Draw();
//            shape = new Polygon(10, 4885);
//            shape.Draw();
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;



////3번
//namespace ex220711
//{
//    internal abstract class Shape   //shape class는 인수를 만들어낼 수 없다!  internal - 어셈블리 내에서 사용한다  
//    {
//        public int ShapeID { get; set; }
//        public Shape(int id)      //id는 유니크하기떄문에 초기값 int id = 0 안됨 
//        {
//            ShapeID = id;
//        }
//        public abstract void Draw(); // abstract - 추상메소드, 순수가상함수와 같음 ==> virtual  = 0;
//    }

//    internal class Rect : Shape   // 상속
//    {
//        int x, y;
//        int width, height;
//        public Rect(int x, int y, int w, int h, int id) : base(id)
//        {
//            this.x = x;
//            this.y = y;
//            width = w;
//            height = h;
//        }
//        public override void Draw()  //추상메소드도 재정의하는 것이기에 override 써야함 
//        {
//            Console.WriteLine(this);        //this -> ToString 호출! --> 문자열로 변환해야하기때문에 내부적으로 to string 호출!    
//        }
//        public override string ToString()
//        {
//            return $"[{ShapeID}],x:{x},y:{y}, w:{width},h:{height}";
//        }
//    }
//    internal class Circle : Shape
//    {
//        int x, y;
//        int radius;
//        public Circle(int x, int y, int r, int id) : base(id)
//        {
//            this.x = x;
//            this.y = y;
//            this.radius = r;
//        }
//        public override void Draw()
//        {
//            Console.WriteLine(this);
//        }
//        public override string ToString()
//        {
//            return $"[{ShapeID}]x:{x}, y:{y}, r:{radius}";
//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("GUID : {0}", Guid.NewGuid());
//            Shape shape = new Rect(0, 0, 100, 120,1010);
//            shape.Draw();
//            Shape shape2 = new Circle(1, 2, 10,3050);
//            shape2.Draw();
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220711
//{
//    internal abstract class Shape
//    {
//        public abstract void Draw(); //virtual = 0;  추상메소드
//    }
//    internal class Rect : Shape    
//    {
//        int x, y;
//        int width, height;  
//        public Rect(int  x, int y, int w, int h)
//        {
//            this.x = x;
//            this.y = y;
//            width = w;
//            height = h;
//        }
//        public override void Draw()
//        {
//            Console.WriteLine(this);
//        }
//        public override string ToString()
//        {
//            return $"{x},{y},w: {width} , h: {height}";
//        }
//    }
//    internal class Program
//    { 
//        static void Main(string[] args)
//        {
//            Shape shape = new Rect(0, 0, 100, 120);
//            shape.Draw();
//            Console.WriteLine(shape);
//        }
//    }
//}
