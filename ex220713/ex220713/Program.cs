using System;
using System.Collections.Generic;
using System.Linq;
namespace ex220713
{
    static class ArrayEx
    {
        public static IEnumerable<T> select<T>(this IEnumerable<T> source, Func<T, T> f)
        {
            return source;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 60, 40, 39, 69, 10, 29, 49, 75 };

            var subArray = arr.select((data) => data);   // 1. 컬렉션 반환
            var count = arr.Count();                     // 2. 스칼라 값
            var flag = arr.Any((n) => n > 100);          // 3. boolean 값

            Console.WriteLine(subArray);
            Console.WriteLine(count);
            Console.WriteLine(flag);
        }
    }
}
////LINQ 메소드 시작!
//using System;
//using System.Collections.Generic;
//using System.Linq;
//namespace ex220713
//{
//    static class ArrayEx
//    {
//        public static IEnumerable<T> Select<T>(this IEnumerable<T> source, Func<T, T> f)
//        {
//            return source;
//        }
//    }
//    class Program
//    {
//        static void Print(int data)
//        {
//            Console.WriteLine("data : {0}", data);
//        }
//        static void Main(string[] args)
//        {
//            int[] arr = { 60, 40, 39, 69, 10, 29, 49, 75 };

//            int sum = 0;
//            arr.ToList().ForEach((data) => sum += data);
//            arr.ToList().ForEach(Print);
//            Console.WriteLine("Sum : {0}", sum);
//        }
//    }
//}

////LINQ 메소드 시작!
//using System;
//using System.Collections.Generic;
//using System.Linq;
//namespace ex220713
//{
//    static class ArrayEx
//    {
//        public static IEnumerable<T> Select<T>(this IEnumerable<T> source, Func<T, T> f)
//        {
//            return source;
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr = { 60, 40, 39, 69, 10, 29, 49, 75 };

//            int sum = 0;
//            //arr.ToList().ForEach((data) => Console.WriteLine(data));
//            arr.ToList().ForEach((data) => sum+=data);
//            Console.WriteLine(sum);
//        }
//    }
//}

////LINQ 메소드 시작!
//using System;
//using System.Collections.Generic;
////using System.Linq;
//namespace ex220713
//{
//    static class ArrayEx
//    {
//        public static IEnumerable<T> Select<T>(this IEnumerable<T> source, Func<T, T> f)
//        {
//            return source;
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr = { 60, 40, 39, 69, 10, 29, 49, 75 };

//            var subArray = arr.Select((data) => data);   // 1. 컬렉션 반환
//            var count = arr.Count();                     // 2. 스칼라 값
//            var flag = arr.Any((n) => n > 100);          // 3. boolean 값

//            Console.WriteLine(subArray);
//            Console.WriteLine(count);
//            Console.WriteLine(flag);
//        }
//    }
//}

////익명 객체
//using System;
//using System.Collections.Generic;
//using System.Linq;
//namespace ex220713
//{
//    class Program
//    {
//        delegate void MyDel();
//        static void Main(string[] args)
//        {
//            var obj = new { Name = "홍길동", Age = 25, Phone = "010-1234-5555" };

//            Console.WriteLine("{0} - {1} ", obj.GetType().Name, obj);
//        }
//    }
//}

////익명 객체
//using System;
//using System.Collections.Generic;
//using System.Linq;
//namespace ex220713
//{
//    class Program
//    {
//        delegate void MyDel();
//        static void Main(string[] args)
//        {
//            var obj = new { A = 10, B = 20 };

//            Console.WriteLine("{0} - {1} ", obj.GetType().Name, obj);
//            Console.WriteLine("{0} - {1} ", obj.A, obj.B);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//namespace ex220713
//{
//    class Program
//    {
//        delegate void MyDel();
//        static void Main(string[] args)
//        {
//            Func<int, int, int> f2 = (a, b) => a + b;
//            Func<int, int, double> f3 = (a, b) => (double)a / b;
//            Func<int, int, long> f4 = (a, b) => { return a * b; };
//            Func<int, int, bool> f5 = (a, b) => a == b;
//            Predicate<int> f6 = (a) => a == 10;

//            Console.WriteLine(f2(10,20));
//            Console.WriteLine(f3(10,20));
//            Console.WriteLine(f4(10,20));
//            Console.WriteLine(f5(10,20));
//            Console.WriteLine(f6(10));

//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//namespace ex220713
//{
//    class Program
//    {
//        delegate void MyDel();
//        static void Main(string[] args)
//        {
//            MyDel f1 = () => Console.WriteLine("Hello!");
//            Action<int> f2 = (n) => Console.WriteLine("Hello! : {0}, n ");
//            Action<string> f3 = (s) => Console.WriteLine("Hello! : {0}", s);
//            Action<int, string> f4 =
//                (n, s) => { Console.WriteLine("int :{0}", n); Console.WriteLine("string: {0}", s);};

//            f1();
//            f2(10);
//            f3("hello!");
//            f4(12, "ABC");
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//namespace ex220713
//{
//    class ESArgs : EventArgs
//    {
//        public int Index { get; set; }
//        public string Number { get; set; }
//        public ESArgs(int idx, string n)
//        {
//            Index = idx;
//            Number = n;
//        }
//    }
//    class EventServer
//    {
//        List<String> strList = new List<string>();
//        public EventHandler<ESArgs> Event = null;  //모든 이벤트핸들러는 이렇게 만들기로함
//        public void AddRandom()
//        {
//            Random r = new Random();
//            int num = r.Next(10, 100);
//            for (int i = 0; i < num; ++i)
//            {
//                int number = r.Next(100);
//                if (number == 50)
//                {
//                    //if(Event != null)
//                    Event?.Invoke(this, new ESArgs(i, number.ToString()));
//                }
//                strList.Add(number.ToString());
//            }
//        }
//        public override string ToString()
//        {
//            StringBuilder sb = new StringBuilder("");
//            strList.ForEach((s) => sb.Append(s + " "));
//            return sb.ToString();
//        }
//    }
//    class Program
//    {
//        static void Handler(object sender, ESArgs e)
//        {
//            Console.WriteLine($"{e.Index} 위치에서 {e.Number} 문자열 생성!");
//        }
//        static void Handler2(object sender, ESArgs e)
//        {
//            Console.WriteLine($"client2 - {e.Index} 위치에서 {e.Number} 문자열 생성!");
//        }
//        static void Main(string[] args)
//        {
//            EventServer es = new EventServer();
//            es.Event += Handler;   //이벤트 핸들러 등록  
//            es.Event += Handler2;   //이벤트 핸들러 등록  
//            //es.Event -= Handler;
//            //es.Event = null;

//            es.AddRandom();
//            Console.WriteLine(es);
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//namespace ex220713
//{
//    class ESArgs : EventArgs
//    {
//        public int Index { get; set; }
//        public string Number { get; set; }
//        public ESArgs(int idx, string n)
//        {
//            Index = idx;
//            Number = n;
//        }
//    }
//    class EventServer
//    {
//        List<String> strList = new List<string>();
//        public event Action<object, ESArgs> Event = null;  //모든 이벤트핸들러는 이렇게 만들기로함
//        public void AddRandom()
//        {
//            Random r = new Random();
//            int num = r.Next(10, 100);
//            for (int i = 0; i < num; ++i)
//            {
//                int number = r.Next(100);
//                if (number == 50)
//                {
//                    //if(Event != null)
//                    Event?.Invoke(this, new ESArgs(i, number.ToString()));
//                }
//                strList.Add(number.ToString());
//            }
//        }
//        public override string ToString()
//        {
//            StringBuilder sb = new StringBuilder("");
//            strList.ForEach((s) => sb.Append(s + " "));
//            return sb.ToString();
//        }
//    }
//    class Program
//    {
//        static void Handler(object sender, ESArgs e)
//        {
//            Console.WriteLine($"{e.Index} 위치에서 {e.Number} 문자열 생성!");
//        }
//        static void Handler2(object sender, ESArgs e)
//        {
//            Console.WriteLine($"client2 - {e.Index} 위치에서 {e.Number} 문자열 생성!");
//        }
//        static void Main(string[] args)
//        {
//            EventServer es = new EventServer();
//            es.Event += Handler;   //이벤트 핸들러 등록  
//            es.Event += Handler2;   //이벤트 핸들러 등록  
//            //es.Event -= Handler;
//            //es.Event = null;

//            es.AddRandom();
//            Console.WriteLine(es);
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//namespace ex220713
//{
//    class EventServer
//    {
//        List<String> strList = new List<string>();
//        public event Action<object, EventArgs> Event = null;  //모든 이벤트는 이렇게 만들기로함
//        public void AddRandom()
//        {
//            Random r = new Random();
//            int num = r.Next(10, 100);
//            for (int i = 0; i < num; ++i)
//            {
//                int number = r.Next(100);
//                if (number == 50)
//                {
//                    //if(Event != null)
//                    Event?.Invoke(this, new EventArgs() );
//                }
//                strList.Add(number.ToString());
//            }
//        }
//        public override string ToString()
//        {
//            StringBuilder sb = new StringBuilder("");
//            strList.ForEach((s) => sb.Append(s + " "));
//            return sb.ToString();
//        }
//    }
//    class Program
//    {
//        static void Handler(object sender, EventArgs e)
//        {
//            Console.WriteLine($"{sender} 위치에서 {e.ToString()} 문자열 생성!");
//        }
//        static void Handler2(object sender, EventArgs e)
//        {
//            Console.WriteLine($"client2 - {sender} 위치에서 {e.ToString()} 문자열 생성!");
//        }
//        static void Main(string[] args)
//        {
//            EventServer es = new EventServer();
//            es.Event += Handler;   //이벤트 핸들러 등록  
//            es.Event += Handler2;   //이벤트 핸들러 등록  
//            //es.Event -= Handler;
//            //es.Event = null;

//            es.AddRandom();
//            Console.WriteLine(es);
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//namespace ex220713
//{
//    class EventServer
//    {
//        List<String> strList = new List<string>();
//        public event Action<int, string> Event = null;  //event를 추가해서 event임  딜리게이트 아니고
//        public void AddRandom()
//        {
//            Random r = new Random();
//            int num = r.Next(10, 100);
//            for (int i = 0; i < num; ++i)
//            {
//                int number = r.Next(100);
//                if (number == 50)
//                {
//                    //if(Event != null)
//                    Event?.Invoke(i, number.ToString());
//                }
//                strList.Add(number.ToString());
//            }
//        }
//        public override string ToString()
//        {
//            StringBuilder sb = new StringBuilder("");
//            strList.ForEach((s) => sb.Append(s + " "));
//            return sb.ToString();
//        }
//    }
//    class Program
//    {
//        static void Handler(int idx, string s)
//        {
//            Console.WriteLine($"{idx} 위치에서 {s} 문자열 생성!");
//        }
//        static void Handler2(int idx, string s)
//        {
//            Console.WriteLine($"client2 - {idx} 위치에서 {s} 문자열 생성!");
//        }
//        static void Main(string[] args)
//        {
//            EventServer es = new EventServer();
//            es.Event += Handler;   //이벤트 핸들러 등록  
//            es.Event += Handler2;   //이벤트 핸들러 등록  
//            //es.Event -= Handler;
//            es.Event = null;

//            es.AddRandom();
//            Console.WriteLine(es);
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//namespace ex220713
//{
//    class EventServer
//    {
//        List<String> strList = new List<string>();
//        public Action<int, string> Event = null;
//        public void AddRandom()
//        {
//            Random r = new Random();
//            int num = r.Next(10, 100);
//            for (int i = 0; i < num; ++i)
//            {
//                int number = r.Next(100);
//                if (number == 50)
//                {
//                    //if(Event != null)
//                    Event?.Invoke(i, number.ToString());
//                }
//                strList.Add(number.ToString());
//            }
//        }
//        public override string ToString()
//        {
//            StringBuilder sb = new StringBuilder("");
//            strList.ForEach((s) => sb.Append(s + " "));
//            return sb.ToString();
//        }
//    }
//    class Program
//    {
//        static void Handler(int idx, string s)
//        {
//            Console.WriteLine($"{idx} 위치에서 {s} 문자열 생성!");
//        }
//        static void Handler2(int idx, string s)
//        {
//            Console.WriteLine($"client2 - {idx} 위치에서 {s} 문자열 생성!");
//        }
//        static void Main(string[] args)
//        {
//            EventServer es = new EventServer();
//            es.Event += Handler;   //이벤트 핸들러 등록  
//            es.Event += Handler2;   //이벤트 핸들러 등록  
//            //es.Event -= Handler;
//            es.Event = null;

//            es.AddRandom();
//            Console.WriteLine(es);
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//namespace ex220713
//{
//    class EventServer
//    {
//        List<String> strList = new List<string>();
//        public Action<int, string> Event = null; 
//        public void AddRandom()
//        {
//            Random r = new Random();
//            int num = r.Next(10, 100);
//            for (int i = 0; i < num; ++i)
//            {
//                int number = r.Next(100);
//                if(number == 50)
//                {
//                    //if(Event != null)
//                        Event?.Invoke(i, number.ToString());
//                }
//                strList.Add(number.ToString());
//            }
//        }
//        public override string ToString()
//        {
//            StringBuilder sb = new StringBuilder("");
//            strList.ForEach( (s)=> sb.Append(s+ " "));
//            return sb.ToString(); 
//        }
//    }
//    class Program
//    {
//        static void Handler(int idx, string s)
//        {
//            Console.WriteLine($"{idx} 위치에서 {s} 문자열 생성!");
//        }
//        static void Handler2(int idx, string s)
//        {
//            Console.WriteLine($"client2 - {idx} 위치에서 {s} 문자열 생성!");
//        }
//        static void Main(string[] args)
//        {
//            EventServer es = new EventServer();
//            es.Event += Handler;   //이벤트 핸들러 등록  
//            es.Event += Handler2;   //이벤트 핸들러 등록  
//            es.AddRandom();

//            Console.WriteLine(es);
//        }
//    }
//}

////표준 delegate<T>
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//namespace ex220713
//{
//    class Program
//    {
//        static int Add(int a, int b)
//        {c
//            return a + b;
//        }
//        static int Sum(int a, int b, int c)
//        {
//            return a + b + c;
//        }
//        static double Div(int a, int b)
//        {
//            return (double)a / b;
//        }
//        static void Main(string[] args)
//        {
//            Func<int, int, int> f1 = Add;
//            Func<int, int, int, int> f2 = Sum;
//            Func<int, int, double> f3 = new Func<int, int, double>(Div);

//            Console.WriteLine(f1(10,20));
//            Console.WriteLine(f2(10,20,30));
//            Console.WriteLine(f3(10,3));
//        }
//    }
//}

////표준 delegate<T>
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//namespace ex220713
//{
//    class Program
//    {
//        static void PrintA(int n1) { Console.WriteLine(n1); }
//        static void PrintB(int n1, int n2) { Console.WriteLine($"{n1} {n2}"); }
//        static void PrintC(int n1, int n2, int n3) { Console.WriteLine($"{n1} {n2} {n3}"); }
//        static void PrintD(int n1, double n2, string n3) { Console.WriteLine($"{n1} {n2} {n3}"); }
//        static void Main(string[] args)
//        {
//            Action<int> ad = PrintA;
//            Action<int,int> bd = PrintB;
//            Action<int,int,int> cd = PrintC;
//            Action<int,double,string> dd = new Action<int,double,string>(PrintD);

//            ad(10);
//            bd(10, 30);
//            cd(15, 37, 98);
//            dd(100, 5.43, "Hello!");
//        }
//    }
//}

////표준 delegate<T>
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//namespace ex220713
//{
//    class Program
//    {
//        static void PrintA(int n1) { Console.WriteLine(n1); }
//        static void PrintB(int n1,int n2) { Console.WriteLine($"{n1} {n2}"); }
//        static void PrintC(int n1,int n2,int n3) { Console.WriteLine($"{n1} {n2} {n3}"); }

//        delegate void PrintADel(int n1);
//        delegate void PrintBDel(int n1, int n2);
//        delegate void PrintCDel(int n1, int n2, int n3);
//        static void Main(string[] args)
//        {
//            PrintADel ad = PrintA;
//            PrintBDel bd = PrintB;
//            PrintCDel cd = PrintC;

//            ad(10);
//            bd(10,30);
//            cd(15,37,98);
//        }
//    }
//}


//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//namespace ex220713
//{
//    delegate int Op(int a, int b); // 어셈블리 내에서 사용할 수 있는 타입!

//    struct Point        //point는 값만 만들어지기떄문에 struct로 만들어진다
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//        public Point(int x = 0, int y = 0) { X = x; Y = y; }
//        public override string ToString() { return $"({X}, {Y}) "; }
//        public void Print()
//        {
//            Console.WriteLine(this.ToString());
//        }
//    }
//    struct Person
//    {
//        public string Name { get; set; }
//        public int Age { get; set; }
//        public string Phone { get; set; }
//        public Person(string n, int a, string p)
//        {
//            Name = n;
//            Age = a;
//            Phone = p;
//        }
//        public override string ToString()
//        {
//            return $"Name:{Name},Age:{Age},Phone:{Phone}";
//        }
//    }

//    delegate bool Pred<T>(T key);
//    static class Algorithm
//    {
//        public static int Find<T>(T[] arr, Pred<T> pred)  //Predicate로 쓰기 수정
//        {
//            for (int i = 0; i < arr.Length; ++i)
//                if (pred(arr[i]))
//                    return i;
//            return -1;
//        }
//    }
//    class Program
//    {
//        static bool cmp(int key)
//        {
//            return key > 50 && key % 2 == 0;
//        }
//        static bool cmp(Point key)
//        {
//            return key.X == 93;
//        }
//        static bool cmp(Person key)
//        {
//            return key.Name == "장길산";
//        }


//        static void Main(string[] args)
//        {
//            Person[] parr = { new Person("홍길동", 20, "010-1234-1234"),
//                                new Person("임꺽정", 25, "010-2222-5678"),
//                                 new Person("장길산", 30, "010-5522-9988")};

//            int idx = Algorithm.Find(parr, cmp);
//            if (idx != -1)
//                Console.WriteLine("{0} : {1}", idx, parr[idx]);

//        }
//    }
//}



//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//namespace ex220713
//{
//    delegate int Op(int a, int b); // 어셈블리 내에서 사용할 수 있는 타입!

//    struct Point        //point는 값만 만들어지기떄문에 struct로 만들어진다
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//        public Point(int x = 0, int y = 0) { X = x; Y = y; }
//        public override string ToString() { return $"({X}, {Y}) "; }
//        public void Print()
//        {
//            Console.WriteLine(this.ToString());
//        }
//    }
//    delegate bool Pred<T>(T key);
//    static class Algorithm
//    {
//        public static int Find<T>(T[] arr, Pred<T> pred)
//        {
//            for (int i = 0; i < arr.Length; ++i)
//                if (pred(arr[i]))
//                    return i;
//            return -1;
//        }
//    }
//    class Program
//    {
//        static bool cmp(int key)  //콜백함수
//        {
//            return key > 50 && key % 2 == 0;
//        }
//        static bool cmp(Point key)  //콜백함수
//        {
//            return key.X == 93;
//        }
//        static int Add(int a, int b)
//        {
//            return a + b;
//        }
//        static int Sub(int a, int b)
//        {
//            return a - b;
//        }

//        static void Main(string[] args)
//        {
//            Point[] arr = { new Point(10, 0), new Point(50, 0), new Point(32, 0), new Point(76, 0), new Point(93, 0), new Point(20, 0) };

//            int idx = Algorithm.Find(arr, cmp);
//            if (idx != -1)
//                Console.WriteLine("{0} : {1}", idx, arr[idx]);

//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//namespace ex220713
//{
//    delegate int Op(int a, int b); // 어셈블리 내에서 사용할 수 있는 타입!

//    struct Point        //point는 값만 만들어지기떄문에 struct로 만들어진다
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//        public Point(int x = 0, int y = 0) { X = x; Y = y; }
//        public override string ToString() { return $"({X}, {Y}) "; }
//        public void Print()
//        {
//            Console.WriteLine(this.ToString());
//        }
//    }
//    delegate bool Pred<T>(T key);
//    static class Algorithm
//    {
//        public static int Find<T>(T[] arr, Pred<T> pred)
//        {
//            for (int i = 0; i < arr.Length; ++i)
//                if (pred(arr[i]))
//                    return i;
//            return -1;
//        }
//    }
//    class Program
//    {
//        static bool cmp(int key)  //콜백함수
//        {
//            return key > 50 && key % 2 == 0;
//        }
//        static bool cmp(Point key)  //콜백함수
//        {
//            return key.X == 93;
//        }
//        static int Add(int a, int b)
//        {
//            return a + b;
//        }
//        static int Sub(int a, int b)
//        {
//            return a - b;
//        }

//        static void Main(string[] args)
//        {
//            Point[] arr = {new Point(10,0), new Point(50, 0), new Point(32, 0), new Point(76, 0), new Point(93, 0), new Point(20, 0) };

//            int idx = Algorithm.Find(arr, cmp);
//            if (idx != -1)
//                Console.WriteLine("{0} : {1}", idx, arr[idx]);

//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//namespace ex220713
//{
//    delegate int Op(int a, int b); // 어셈블리 내에서 사용할 수 있는 타입!

//    struct Point        //point는 값만 만들어지기떄문에 struct로 만들어진다
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//        public Point(int x = 0, int y = 0) { X = x; Y = y; }
//        public override string ToString() { return $"({X}, {Y}) "; }
//        public void Print()
//        {
//            Console.WriteLine(this.ToString());
//        }
//    }
//    delegate bool Pred(int key);
//    static class Algorithm
//    {
//        public static int Find(int[] arr, Pred pred)
//        {
//            for (int i = 0; i < arr.Length; ++i)
//                if (pred(arr[i]))
//                    return i;
//            return -1;
//        }
//    }
//    class Program
//    {
//        static bool cmp(int key)  //콜백함수
//        {
//            return key > 50 && key % 2 == 0;
//        }
//        static int Add(int a, int b)
//        {
//            return a + b;
//        }
//        static int Sub(int a, int b)
//        {
//            return a - b;
//        }

//        static void Main(string[] args)
//        {
//            int[] arr = { 10, 50, 32, 76, 93, 20 };

//            int idx = Algorithm.Find(arr, cmp);
//            if (idx != -1)
//                Console.WriteLine("{0} : {1}", idx, arr[idx]);

//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//namespace ex220713
//{
//    delegate int Op(int a, int b); // 어셈블리 내에서 사용할 수 있는 타입!

//    struct Point        //point는 값만 만들어지기떄문에 struct로 만들어진다
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//        public Point(int x = 0, int y = 0) { X = x; Y = y; }
//        public override string ToString() { return $"({X}, {Y}) "; }
//        public void Print()
//        {
//            Console.WriteLine(this.ToString());
//        }
//    }
//    static class Algorithm
//    {
//        public static int Find(int[] arr, int key)
//        {
//            for(int i = 0; i < arr.Length; ++i)
//                if(key == arr[i])
//                    return i;
//            return -1;
//        }
//    }
//    class Program
//    {
//        static int Add(int a, int b)
//        {
//            return a + b;
//        }
//        static int Sub(int a, int b)
//        {
//            return a - b;
//        }

//        static void Main(string[] args)
//        {
//            int[] arr = { 10, 50, 32, 76, 93, 20 };

//            int idx = Algorithm.Find(arr, 93);
//            if(idx!=-1)
//                Console.WriteLine("{0} : {1}", idx, arr[idx]);

//        }
//    }
//}
////using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220713
//{
//    struct Point
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//        public Point(int x = 0, int y = 0) { X = x; Y = y; }
//        public override string ToString() { return $"({X}, {Y}) "; }
//        public void Print()
//        {
//            Console.WriteLine(this.ToString());
//        }
//    }
//    class Program
//    {
//        static int Add(int a, int b)
//        { return a + b; }
//        static int Sub(int a, int b)
//        { return a - b; }
//    }

//        delegate int OP(int a, int b);
//        static void Main(string[] args)
//        {
//            OP op = Add; //new OP(Add);
//            Console.WriteLine(op(10,20));
//            OP = Sub; 
//            Console.WriteLine(op(10, 20));

//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220713
//{
//    struct Point
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//        public Point(int x = 0, int y = 0) { X = x; Y = y; }
//        public override string ToString() { return $"({X}, {Y}) "; }
//        public void Print()
//        {
//            Console.WriteLine(this.ToString());
//        }
//    }
//    class Program
//    {
//        static void PrintA()
//        {
//            Console.WriteLine("Print A!");
//        }
//        static void PrintB()
//        {
//            Console.WriteLine("Print B!");
//        }
//        delegate void PrintDel();
//        static void Main(string[] args)
//        {
//            Point pt = new Point(2, 3);
//            pt.Print();

//            PrintDel d = new PrintDel(pt.Print);
//            d += new PrintDel(PrintA);
//            d += new PrintDel(PrintB);
//            d();


//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220713
//{
//    struct Point
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//        public Point(int x = 0, int y = 0) { X = x; Y = y; }
//        public override string ToString() { return $"({X}, {Y}) "; }
//        public void Print()
//        {
//            Console.WriteLine(this.ToString());
//        }
//    }
//    class Program
//    {
//        delegate void PrintDel();
//        static void Main(string[] args)
//        {
//            Point pt = new Point(2, 3);
//            pt.Print();

//            PrintDel d = new PrintDel(pt.Print);
//            d();
//            d.Invoke();


//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220713
//{
//    struct Point
//    {
//        public int X { get; set; }
//        public int Y { get; set; }
//        public Point(int x = 0, int y = 0){X = x; Y = y;}
//        public override string ToString() { return $"({X}, {Y}) "; }
//    }
//    class Program
//    {
//        static void PrintInt(int data)
//        {
//            Console.WriteLine("Int : {0} ", data);
//        }
//        static void PrintString(string data)
//        {
//            Console.WriteLine("String : {0} ", data);
//        }
//        delegate void PrintStringType(string data); 
//        delegate void PrintIntType(int data);  //딜리게이트 : 함수를 가르키고 호출
//        static void Main(string[] args)
//        {
//            PrintInt(10);
//            PrintString("hello!");

//            PrintIntType del1 = new PrintIntType(PrintInt);
//            PrintStringType del2 = new PrintStringType(PrintString);
//            del1(10);
//            del2("hello!");

//            del1.Invoke(10);
//            del1.Invoke("hello!");

//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220713
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
//    class Polygon
//    {
//        List<Point> ptList = new List<Point>();
//        public Polygon(int count)
//        {
//            for (int i = 0; i < count; ++i)
//            {
//                ptList.Add(new Point(i, i));
//            }
//        }
//        public override string ToString()
//        {
//            StringBuilder sb = new StringBuilder("");
//            for (int i = 0; i < ptList.Count; ++i)
//                sb.Append(ptList[i].ToString());
//            return sb.ToString();
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Polygon pg = new Polygon(100);
//            Console.WriteLine(pg);
//        }
//    }
//}
