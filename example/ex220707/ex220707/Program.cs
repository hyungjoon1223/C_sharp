using System;
using System.Linq;

namespace ex220707
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; } //자동 속성이라고 부름

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
    struct SPoint
    {
        public int X { get; set; }
        public int Y { get; set; } //자동 속성이라고 부름

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
    class Program
    {
        static void CreateClassPoint(out Point pt, int x, int y)
        {
            pt = new Point { X = x, Y = y };
        }
        static void StructClassPoint(out SPoint pt, int x, int y)
        {
            pt = new SPoint { X = x, Y = y };
        }
        static void ResetClassPoint(Point pt)
        {
            pt.X = 0;
            pt.Y = 0;
        }
        static void ResetStructPoint(ref SPoint pt)
        {
            pt.X = 0;
            pt.Y = 0;
        }
        static void Main(string[] args)
        {
            Point cpt;
            SPoint spt;
            CreateClassPoint(out cpt, 1, 2);
            StructClassPoint(out spt, 1, 2);

            ResetClassPoint(cpt);
            ResetStructPoint(ref spt);

            Console.WriteLine(cpt);
            Console.WriteLine(spt);
        }
    }
}

using System;
using System.Linq;

namespace ex220707
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; } //자동 속성이라고 부름

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
    struct SPoint
    {
        public int X { get; set; }
        public int Y { get; set; } //자동 속성이라고 부름

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
    class Program
    {
        static Point CreateClassPoint(int x, int y)
        {
            return new Point { X = x, Y = y };
        }
        static SPoint StructClassPoint(int x, int y)
        {
            return new SPoint { X = x, Y = y };
        }
        static void ResetClassPoint(Point pt)
        {
            pt.X = 0;
            pt.Y = 0;
        }
        static void ResetStructPoint(ref SPoint pt)
        {
            pt.X = 0;
            pt.Y = 0;
        }
        static void Main(string[] args)
        {
            Point cpt = CreateClassPoint(1, 2);
            SPoint spt = StructClassPoint(1, 2);

            ResetClassPoint(cpt);
            ResetStructPoint(ref spt);
            Console.WriteLine(cpt);
            Console.WriteLine(spt);
        }
    }
}

using System;
using System.Linq;

namespace ex220707
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; } //자동 속성이라고 부름

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
    class SPoint
    {
        public int X { get; set; }
        public int Y { get; set; } //자동 속성이라고 부름

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
    class Program
    {
        static Point CreateClassPoint(int x, int y)
        {
            return new Point { X = x, Y = y };
        }
        static SPoint StructClassPoint(int x, int y)
        {
            return new SPoint { X = x, Y = y };
        }
        static void Main(string[] args)
        {
            Point cpt = CreateClassPoint(1, 2);
            SPoint spt = StructClassPoint(1, 2);

            Console.WriteLine(cpt);
            Console.WriteLine(spt);
        }
    }
}

using System;
using System.Linq;

namespace ex220707
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; } //자동 속성이라고 부름

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
    class SPoint
    {
        public int X { get; set; }
        public int Y { get; set; } //자동 속성이라고 부름

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
    class Program
    {
        static Point CreateClassPoint(int x, int y)
        {
            return new Point { X = x, Y = y };
        }
        static SPoint StructClassPoint(int x, int y)
        {
            return new SPoint { X = x, Y = y };
        }
        static void Main(string[] args)
        {
            Point cpt = CreateClassPoint(1, 2);
            SPoint spt = StructClassPoint(1, 2);

            Console.WriteLine(cpt);
            Console.WriteLine(spt);
        }
    }
}

using System;
using System.Linq;

namespace ex220707
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; } //자동 속성이라고 부름

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
    class SPoint
    {
        public int X { get; set; }
        public int Y { get; set; } //자동 속성이라고 부름

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point cpt = new Point { X = 1, Y = 2 };
            SPoint spt = new SPoint { X = 1, Y = 2 };

            Console.WriteLine(cpt);
            Console.WriteLine(spt);
        }
    }
}

using System;
using System.Linq;

namespace ex220707
{
    class Program
    {
        static void Main(string[] args)
        {
            nullable type
            string s = "Hello!"; //참조타입
            Nullable<int> n = 100;   //인트형에 NULL이 가능한 타입
            int m = n.Value;   //또는 
            int m = (int)n;    //이렇겡 DB에서 많이 사용함

            Console.WriteLine(s);
            Console.WriteLine(n);

            s = null;
            n = null;
            Console.WriteLine(s);
        }
    }
}

using System;
using System.Linq;

namespace ex220707
{
    class Program
    {
        static void Main(string[] args)
        {
            nullable type
            string s = "Hello!"; //참조타입
            int? n = 100; //값 타입   ?를 붙이면 모든 int형 + null을 저장할 수 있는
            int m = n.Value;   //또는 
            int m = (int)n;    //이렇겡 DB에서 많이 사용함

            Console.WriteLine(s);
            Console.WriteLine(n);

            s = null;
            n = null;
            Console.WriteLine(s);
        }
    }
}

using System;
using System.Linq;

namespace ex220707
{
    class Program
    {
        static void Main(string[] args)
        {
            nullable type
            string s = "Hello!"; //참조타입
            int? n = 100; //값 타입   ?를 붙이면 모든 int형 + null을 저장할 수 있는

            Console.WriteLine(s);
            Console.WriteLine(n);

            s = null;
            n = null;
            Console.WriteLine(s);
        }
    }
}

using System;
using System.Linq;

namespace ex220707
{
    class Program
    {
        static void Print(params int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write("{0} ", arr[i]);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int[] a1 = { 1, 2, 3 };
            Print(a1);
            Print(new int[] { 2, 4, 6, 8 });  //{}안에 내용이 초기화리스트여서 []생략가능
            Print(10);  //params가 있어서 가능함 없으면 X 목록화해서 배열의 원소로서 받는다는 뜻
            Print(10, 20);
            Print(10, 20, 30);
        }
    }
}

using System;
using System.Linq;

namespace ex220707
{
    class Program
    {
        static void Swap(ref int a, ref int b)  //ref는 뉴라이트 변수기 때문에 바뀌게 됨
        {
            int t = a;
            a = b;
            b = t;
        }
        static void Main(string[] args)
        {
            int n1 = 10;
            int n2 = 20;

            Swap(ref n1, ref n2);

            Console.WriteLine("{0} {1}", n1, n2);
        }
    }
}

using System;
using System.Linq;

namespace ex220707
{
    class Program
    {
        static void Add(int a, int b, out int sum)
        {
            int n = sum;  //out이기 때문에 읽기가 되지않음 out은 write만 하겠다는 뜻
            sum = a + b;
        }
        static void Main(string[] args)
        {
            int n1 = 10;
            int n2 = 20;
            int sum = 0;    //sum은 인파라미터기 때문에 // int는 값 형식이기 때문에 값이 복사된다
            Add(n1, n2, out sum);    //sum 이 아웃파라미터가 되어야함

            Console.WriteLine("sum = {0}", sum);
        }
    }
}

using System;
using System.Linq;

namespace ex220707
{
    class Program
    {
        static void Add(int a, int b, int sum)
        {
            sum = a + b;
        }
        static void Main(string[] args)
        {
            int n1 = 10;
            int n2 = 20;
            int sum = 0;    //sum은 인파라미터기 때문에 // int는 값 형식이기 때문에 값이 복사된다
            Add(n1, n2, sum);    //sum 이 아웃파라미터가 되어야함

            Console.WriteLine("sum = {0}", sum);
        }
    }
}

using System;
using System.Linq;

namespace ex220707
{
    class Program
    {
        static void Print(int a)
        {
            Console.WriteLine($"{a} ");
        }
        static void Print(int a, int b)
        {
            Console.WriteLine($"{a} {b}");
        }
        static void Print(int a, int b, int c)
        {
            Console.WriteLine($"{a} {b} {c}");
        }
        static void Main(string[] args)
        {
            Print(10);
            Print(10, 20);
            Print(10, 20, 30);
        }
    }
}

using System;
using System.Linq;

namespace ex220707
{
    class Program
    {
        static void PrintArray(int[] arr)
        {
            var subarr = arr.Select(c => c * 2);
            foreach (var n in subarr)
                Console.Write($"{n} ");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5 };

            PrintArray(arr);

            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]} ");
            Console.WriteLine();
        }
    }
}

using System;
using System.Linq;

namespace ex220707
{
    class Program
    {
        static void PrintArray(int[] arr)
        {
            arr[0] = 100;
            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]} ");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5 };

            PrintArray(arr);

            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]} ");
            Console.WriteLine();
        }
    }
}

using System;
using System.Linq;

namespace ex220707
{
    class Program
    {
        private static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5 };

            Console.WriteLine(arr.Sum());
            Console.WriteLine(arr.Skip(2).Sum());   //3번라인부터 더하기
            Console.WriteLine(arr.Max());
            Console.WriteLine(arr.Average());
        }
    }
}

using System;
using System.Linq;

namespace ex220707
{
    class Program
    {
        private static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5 };

            for (int i = 0; i < arr.Length; ++i)
                Console.Write($"{arr[i]} ");
            Console.WriteLine();

            foreach (var item in arr)
                Console.Write($"{item} ");
            Console.WriteLine();

            foreach (var item in arr.Select(n => n * 2).OrderByDescending(c => c))
                Console.WriteLine($"{item} ");
            Console.WriteLine();
        }
    }
}

using System;

namespace ex220707
{
    class Program
    {
        private static void Main(string[] args)
        {
            var t1 = new Tuple<int, int>(1, 1);   // tuple 상수
            var t2 = new Tuple<int, int, int>(1, 2, 3);

            Console.WriteLine(t1);
            Console.WriteLine(t1.GetType().Name);
            Console.WriteLine($"{t1.Item1} {t1.Item2}");
            Console.WriteLine(t2);
            Console.WriteLine($"{t2.Item1} {t2.Item2} {t2.Item3}");
        }
    }
}

using System;

namespace ex220707
{
    class Program
    {
        private static void Main(string[] args)
        {
            var t1 = (1, 1);   // tuple 상수
            var t2 = (1, 2, 3);

            Console.WriteLine(t1);
            Console.WriteLine(t1.GetType().Name);
            Console.WriteLine($"{t1.Item1} {t1.Item2}");
            Console.WriteLine(t2);
            Console.WriteLine($"{t2.Item1} {t2.Item2} {t2.Item3}");

        }
    }
}

using System;

namespace ex220707
{
    class Program
    {
        private static void Main(string[] args)
        {
            int n = 10;   //System.Int32 n =10; 과 같음
            var n2 = n;

            Console.WriteLine("{0} {1}", n.GetType().Name, n2.GetType().Name);
        }
    }
}

using System;

namespace ex220707
{
    class CData : object
    {
        public int Data1  //속성 (property)
        {
            get; set;
        }
        public int Data2
        {
            get; set;
        }

        public override string ToString()
        {
            return $"{Data1},{Data2}";
        }
    }
    class Program
    {
        private static void Main(string[] args)
        {

            CData d1 = new CData() { Data1 = 100, Data2 = 200 };  //속성 초기화  이걸하면 Cdata없어도 됨
            Console.WriteLine(d1);

            d1.Data1 += 100;
            Console.WriteLine(d1);
        }
    }
}

using System;

namespace ex220707
{
    class CData : object
    {
        public int Data1  //속성 (property)
        {
            get; set;
        }
        public int Data2
        {
            get; set;
        }

        public CData(int d1 = 0, int d2 = 0)
        {
            Data1 = d1;
            Data2 = d2;
        }
        public override string ToString()
        {
            return $"{Data1},{Data2}";
        }
    }
    class Program
    {
        private static void Main(string[] args)
        {

            CData d1 = new CData(1, 2);
            Console.WriteLine(d1);
            d1.Data1 += 100;
            Console.WriteLine(d1);
        }
    }
}

using System;

namespace ex220707
{
    class CData : object
    {
        private int data1;    //C++에서는 멤버변수라고 불렀지만 속성(property)라고 부름/ field(필드)
        public int Data1  //속성 (property)
        {
            get { return data1; }
            set
            {
                data1 = value;
            }
        }
        private int data2;
        public int Data2
        {
            get { return data2; }
            set
            {
                data2 = value;
            }
        }

        public CData(int d1 = 0, int d2 = 0)
        {
            data1 = d1;
            data2 = d2;
        }
        public override string ToString()
        {
            return $"{data1},{data2}";
        }

    }
    struct SData
    {
        public int data1;
        public int Data1  //속성 (property)
        {
            get { return data1; }
            set
            {
                data1 = value;
            }
        }
        public int data2;
        public int Data2  //속성 (property)
        {
            get { return data2; }
            set
            {
                data2 = value;
            }
        }
        public SData(int d1 = 0, int d2 = 0)
        {
            data1 = d1;
            data2 = d2;
        }
        public override string ToString()
        {
            return $"{data1},{data2}";
        }
    }
    class Program
    {
        private static void Main(string[] args)
        {

            CData d1 = new CData(1, 2);
            CData cd1 = d1;
            d1.Data1 = 100;

            Console.WriteLine(d1);
            Console.WriteLine(cd1);

            SData d2 = new SData(1, 2);
            SData cd2 = d2;
            d2.data1 = 100;
            Console.WriteLine(d2);
            Console.WriteLine(cd2);
        }
    }
}

using System;

namespace ex220707
{
    class CData
    {
        public int data1;
        public int data2;
        public CData(int d1 = 0, int d2 = 0)
        {
            data1 = d1;
            data2 = d2;
        }
        public override string ToString()
        {
            return $"{data1},{data2}";
        }

    }
    struct SData
    {
        public int data1;
        public int data2;
        public SData(int d1 = 0, int d2 = 0)
        {
            data1 = d1;
            data2 = d2;
        }
        public override string ToString()
        {
            return $"{data1},{data2}";
        }
    }
    class Program
    {
        private static void Main(string[] args)
        {

            CData d1 = new CData(1, 2);
            CData cd1 = d1;
            d1.data1 = 100;

            Console.WriteLine(d1);
            Console.WriteLine(cd1);

            SData d2 = new SData(1, 2);
            SData cd2 = d2;
            d2.data1 = 100;
            Console.WriteLine(d2);
            Console.WriteLine(cd2);
        }
    }
}

//8번 모든객체의 부모는 Object   - 8개의 메소드
using System;

namespace ex220707
{
    class CData         // 생략하게 되면 class CData : object  
    {
        public int data1;
        public int data2;
        public CData(int d1 = 0, int d2 = 0)       //  생략하면private 멤버가 됨
        {
            data1 = d1;
            data2 = d2;
        }
        public override string ToString()     //object 재정의
        {
            return $"{data1},{data2}";
        }

    }
    struct SData
    {
        public int data1;
        public int data2;
        public SData(int d1 = 0, int d2 = 0)       //  생략하면private 멤버가 됨
        {
            data1 = d1;
            data2 = d2;
        }
        public override string ToString()     //object 재정의
        {
            return $"{data1},{data2}";
        }
    }

    class Program
    {
        private static void Main(string[] args)
        {
            CData d1;     //d1 =변수 --> 변수는 객체의 참조자일뿐 객체가 아니다
            CData d1 = new CData(1, 2);

            CData d1;
            d1.data1 = 1;
            d1.data2 = 2;      //객체가 없기 때문에 안된다!
            Console.WriteLine(d1);

            SData d2 = new SData(1, 2);   //초기화만 하는 new 
            Console.WriteLine(d2);
        }
    }
}

using System;    //namespace 를 지정 System
using static System.Console;
namespace ex220707
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(100.ToString() + "hh");  //정수 객체 문자열로 변환해서 출력 그러므로
            Console.WriteLine('A'.ToString() + "hh");  //문자 객체 ...     +가능
            Console.WriteLine((5.5).ToString() + "hh"); // 실수 객체 ...
        }
    }
}

using System;    //namespace 를 지정 System
using static System.Console;
namespace ex220707
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(100.ToString());  //정수 객체 문자열로 변환해서 출력    
            Console.WriteLine('A'.ToString());  //문자 객체 ...
            Console.WriteLine((5.5).ToString()); // 실수 객체 ...
        }
    }
}

using System;    //namespace 를 지정 System
using static System.Console;
namespace ex220707
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //기본 형식(C# 내장 형식(type)
             //값 형식(value type)

            //byte // char// short // int // long // bool

            //float / double / decimal

             //참조 형식(reference type)
             //object / string

            byte b = 100;
            double d = 5.5;
            object o = new object();
            string s = "Hello!";

            Console.WriteLine(b.GetType().IsPrimitive);
            Console.WriteLine(d.GetType().IsPrimitive);   //원천적인 타입이니?
            Console.WriteLine(o.GetType().IsPrimitive);
            Console.WriteLine(s.GetType().IsPrimitive);
        }
    }
}

using System;    //namespace 를 지정 System
using static System.Console;
namespace ex220707
{
    internal class Program
    {
        private static void PrintArguments(string[] args)   //인스턴트 메소드 (객체로만 호출 할 수 있음)
        {
            Console.WriteLine("args length:{0}", args.Length);
            for (int i = 0; i < args.Length; ++i)
                Console.WriteLine("{0} : {1}", i, args[i]);
        }
        private static void Main(string[] args)  //args 는 스트링 배열객체 //프라이빗이 생략 항상
        {
            //new Program().PrintArguments(args);  //스태틱 메소드
            PrintArguments(args);
            Program.PrintArguments(args);
            ex220707.Program.PrintArguments(args);
        }
    }
}

using System;    //namespace 를 지정 System
using static System.Console;
namespace ex220707
{
    internal class Program
    {
        static void Main(string[] args)  //args 는 스트링 배열객체
        {
            Console.WriteLine("args length:{0}", args.Length);
            for (int i = 0; i < args.Length; ++i)
                Console.WriteLine("{0} : {1}", i, args[i]);
        }
    }
}

using System;    //namespace 를 지정 System
using static System.Console;
namespace ex220707
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("{0} {1} {2}", 100, 5.5, 'A');
            Console.WriteLine("{0} {1} {2}", 100, 5.5, 'A');
            Console.WriteLine("{0} {1} {2}", 100, 5.5, 'A');

            Console.Write("{0} {1} {2}", 100, 5.5, 'A');
            Console.Write("{0} {1} {2}", 100, 5.5, 'A');
            Console.Write("{0} {1} {2}", 100, 5.5, 'A');
            Console.WriteLine();
        }
    }
}

using System;    //namespace 를 지정 System
using static System.Console;
namespace ex220707
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!!");
            Console.WriteLine(100);
            Console.WriteLine(5.5);
            Console.WriteLine('A');

        }
    }
}

using System;    //namespace 를 지정 System
using static System.Console;
namespace ex220707
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!!");  //System은 네임스페이스 console은 형식(type또는 class)
            Console.WriteLine("Hello World!!");
            WriteLine("Hello World!!");
        }
    }
}