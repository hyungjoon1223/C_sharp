//2차원 배열
using System;
using System.Linq;
namespace ex220708
{
    class Program
    {
        static void Main(string[] args)
        {
            // 람다식 기본 문법
            // (param) => {return retValue} 
            // (param) => retValue   //한문장이면서 리턴 생략 가능

            //1.
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //int[] arr2 = arr.Select((elem) => { return elem; }).ToArray();  //배열의 모든 원수 하나하나를 셀렉해랑! (복사본을 만든거임)
            int[] arr2 = arr.Where((elem)=> elem%2 == 0)
                            .Select((elem) => { Console.WriteLine("{0} ", elem); return elem; })
                            .ToArray();

            for (int i = 0; i < arr2.Length; i++)
                Console.WriteLine(arr2[i]);


            
            // () => {}
            // (a) => a
            // (a,b) => a+b
            
        }
    }
}

////2차원 배열
//using System;
//using System.Linq;
//namespace ex220708
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // 람다식 기본 문법
//            // (param) => {return retValue} 
//            // (param) => retValue   //한문장이면서 리턴 생략 가능

//            //1.
//            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
//            //int[] arr2 = arr.Select((elem) => { return elem; }).ToArray();  //배열의 모든 원수 하나하나를 셀렉해랑! (복사본을 만든거임)
//            int[] arr2 = arr.Select((elem) => { Console.WriteLine("{0} ", elem); return elem; })
//                            .ToArray();

//            for (int i = 0; i < arr2.Length; i++)
//                Console.WriteLine(arr2[i]);
//        }
//    }
//}

////2차원 배열
//using System;
//using System.Linq;
//namespace ex220708
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // 람다식 기본 문법
//            // (param) => {return retValue} 
//            // (param) => retValue   //한문장이면서 리턴 생략 가능

//            //1.
//            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
//            //int[] arr2 = arr.Select((elem) => { return elem; }).ToArray();  //배열의 모든 원수 하나하나를 셀렉해랑! (복사본을 만든거임)
//            int[] arr2 = arr.Select((elem)=>elem).ToArray(); 

//            for(int i = 0; i < arr2.Length; i++)
//                Console.WriteLine(arr2[i]);
//        }
//    }
//}

////2차원 배열
//using System;
//using System.Collections;
//using System.Collections.Generic;
//namespace ex220708
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr = { 32, 50, 41, 21, 80 };
//            Array.Sort(arr);
//            Array.ForEach(arr, (elem) => Console.Write($"{elem} "));
//            Console.WriteLine();    
//        }
//    }
//}

////2차원 배열
//using System;
//using System.Collections;
//using System.Collections.Generic;
//namespace ex220708
//{
//    class Program
//    {
//        static void Main(string[] args)
//{
//            int[][] arr = new int[5][];

//            Console.WriteLine("Length: {0}" , arr.Length);
//            for (int i = 0; i < arr.Length; i++)
//                arr[i] = new int[5+i];

//            for(int i = 0; i < arr.Length; ++i)
//            {
//                for(int j = 0; j < arr[i].Length; ++j)
//                    arr[i][j] = j+1;
//            }
//            for (int i = 0; i < arr.Length; ++i)
//            {
//                for(int j = 0; j < arr[i].Length; ++j)
//                    Console.Write("{0} ",arr[i][j]);
//                Console.WriteLine();
//            }
//        }
//    }
//}

////2차원 배열
//using System;
//using System.Collections;
//using System.Collections.Generic;
//namespace ex220708
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[,] iarr = new int[2, 3] { { 10, 20, 30 }, { 40, 50, 60 } };

//            for (int i = 0; i < iarr.GetLength(0); i++)
//            {
//                for (int j = 0; j < iarr.GetLength(1); j++)
//                    Console.WriteLine("{0} ", iarr[i,j]);
//            Console.WriteLine();


//            }

//        }
//    }
//}

////배열
//using System;
//using System.Collections;
//using System.Collections.Generic;
//namespace ex220708
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] iarr = { 10, 20, 30, 40, 50 };
//            double[] darr = new double[3] { 1.1, 4.5, 9.9 };

//            for(int i = 0; i < iarr.Length; ++i)
//                Console.Write("{0} ",iarr[i]);
//            Console.WriteLine();

//            foreach(var elem in darr)
//                Console.Write("{0} ", elem);
//            Console.WriteLine();

//            Array.ForEach(iarr, (elem) => Console.WriteLine(elem));
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//namespace ex220708
//{
//    class Data
//    {
//        public void Print()
//        {
//            Console.WriteLine("Data class!");
//        }
//        public string GetString()
//        {
//            return "class Data";
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Data d = new Data();

//            //d = null;
//            string s = d?.GetString() ?? "default string";

//            Console.WriteLine(s);
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//namespace ex220708
//{
//    class Data
//    {
//        public void Print()
//        {
//            Console.WriteLine("Data class!");
//        }
//        public string GetString()
//        {
//            return "class Data";
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Data d = new Data();

//            //d = null;

//            //d.Print();
//            string s = d?.GetString();
//            Console.WriteLine(s);
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//namespace ex220708
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            object[] arr = { 10, 20, 5.5, "Hello!", 'A' };

//            // 1.(type)  2. is, 3. as
//            string s = arr[3] as string;
//            if( s!=null)
//            {
//                s += 10;
//                Console.WriteLine(s);
//            }
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//namespace ex220708
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            object[] arr = { 10, 20, 5.5, "Hello!", 'A' };

//            // 1.(type)  2. is, 3. as
//            string s = arr[2] as string;
//            s += 10;
//            Console.WriteLine(s);
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//namespace ex220708
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            object[] arr = { 10, 20, 5.5, "Hello!", 'A' };

//            // 1.(type)  2. is, 3. as
//            string s = arr[3] as string;
//            s += 10;
//            Console.WriteLine(s);
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//namespace ex220708
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            object[] arr = { 10, 20, 5.5, "Hello!", 'A' };

//            // 1.(type)  2. is, 3. as
//            if (arr[0] is double)
//                Console.WriteLine((double)arr[0]+1); 
//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//namespace ex220708
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            object[] arr = { 10, 20, 5.5, "Hello!", 'A' };

//            // 1.(type)  2. is, 3. as
//            try
//            {
//                double m = (double)arr[0];
//                Console.WriteLine(m);
//            }
//            catch(Exception e)
//            {
//                Console.WriteLine(e.Message);
//            }

//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//namespace ex220708
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            object[] arr = { 10, 20, 5.5, "Hello!", 'A' };

//            foreach(var item in arr)
//                Console.WriteLine(item);
//        }
//    }
//}

////boxing  unboxing
//using System;
//using System.Collections;
//using System.Collections.Generic;
//namespace ex220708
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            List<int> al = new List<int>();
//            al.Add(10);
//            al.Add(20);
//            al.Add(30);

//            for (int i = 0; i < al.Count; i++)
//                Console.WriteLine((int)al[i] + 100);
//        }
//    }
//}

////boxing  unboxing
//using System;
//using System.Collections;
//namespace ex220708
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            ArrayList al = new ArrayList();  //시간이 오래걸림
//            al.Add(10);
//            al.Add(20);
//            al.Add(30);

//            for (int i = 0; i < al.Count; i++)
//                Console.WriteLine((int)al[i] + 100);
//        }
//    }
//}


////boxing  unboxing
//using System;
//namespace ex220708
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int n = 10;
//            string s = "Hello!";

//            object o1 = (object)n; // boxing
//            object o2 = s;

//            Console.WriteLine((int)o1+10);
//            Console.WriteLine(((string)o2).Contains("!"));
//        }
//    }
//}

////boxing  unboxing
//using System;
//namespace ex220708
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int n = 10;
//            string s = "Hello!";

//            object o1 = (object)n; // boxing
//            object o2 = s;

//            Console.WriteLine(o1);
//            Console.WriteLine(o2);
//        }
//    }
//}

//using System;
//using System.Linq;

//namespace ex220708
//{
//    class Point : object, ICloneable
//    {
//        public int X { get; set; }
//        public int Y { get; set; } //자동 속성이라고 부름

//        public Point(int x = 0, int y = 0)
//        {
//            X = x;
//            Y = y;
//        }
//        public Point(Point arg)
//        {
//            X = arg.X;
//            Y = arg.Y;
//        }
//        public override string ToString()
//        {
//            return $"({X}, {Y})";
//        }
//        public override bool Equals(object obj)
//        {
//            Point pt = obj as Point;   // as키워드 를 이용해서 다운캐스트 한 것 obj를 포인트로 변환해라 변환 가능하면 변환된 참조를 반환하고 변한 안되면 null을 반환한다.
//            return pt.X == this.X && pt.Y == this.Y;
//        }
//        public override int GetHashCode()
//        {//값이 같으면 hashcode도 같이 만들어줘야 같은 버켓에 담긴다
//            return (X << 3 & Y);  // 2의 3승을 하고 Y값과 앤드를 한당
//            //return (X << 3 ^ Y);  // 2의 3승을 하고 Y값과 익스클루시브 or 를 한당
//        }
//        public object Clone()
//        {
//            return this.MemberwiseClone();
//        }
//    }
//    class Rect : ICloneable
//    {
//        Point origin;
//        int width;
//        int height;
//        public Rect(Point pt, int w, int h)
//        {
//            origin = pt;
//            width = w;
//            height = h;
//        }

//        public object Clone()
//        {
//            Rect t = (Rect)this.MemberwiseClone();

//            t.origin = (Point)(t.origin as ICloneable)?.Clone();  //깊은 복사 하기위해서는 꼭 Clone 이 있어야함.

//            return t;
//        }

//        public void SetPos(int x, int y)
//        {
//            origin.X = x;
//            origin.Y = y;
//        }
//        public override string ToString()
//        {
//            return $"{origin.ToString()} w:{width}, h: {height}";
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Rect r1 = new Rect(new Point(0, 0), 100, 100);
//            Rect r2 = (Rect)r1.Clone();
//            r2.SetPos(2, 2);

//            Console.WriteLine(r1);
//            Console.WriteLine(r2);
//        }
//    }
//}

//using System;
//using System.Linq;

//namespace ex220708
//{
//    class Point : object, ICloneable
//    {
//        public int X { get; set; }
//        public int Y { get; set; } //자동 속성이라고 부름

//        public Point(int x = 0, int y = 0)
//        {
//            X = x;
//            Y = y;
//        }
//        public Point(Point arg)
//        {
//            X = arg.X;
//            Y = arg.Y;
//        }
//        public override string ToString()
//        {
//            return $"({X}, {Y})";
//        }
//        public override bool Equals(object obj)
//        {
//            Point pt = obj as Point;   // as키워드 를 이용해서 다운캐스트 한 것 obj를 포인트로 변환해라 변환 가능하면 변환된 참조를 반환하고 변한 안되면 null을 반환한다.
//            return pt.X == this.X && pt.Y == this.Y;
//        }
//        public override int GetHashCode()
//        {//값이 같으면 hashcode도 같이 만들어줘야 같은 버켓에 담긴다
//            return (X << 3 & Y);  // 2의 3승을 하고 Y값과 앤드를 한당
//            //return (X << 3 ^ Y);  // 2의 3승을 하고 Y값과 익스클루시브 or 를 한당
//        }
//        public object Clone()
//        {
//            return this.MemberwiseClone();
//        }
//    }
//    class Rect : ICloneable
//    {
//        Point origin;
//        int width;
//        int height;
//        public Rect(Point pt, int w, int h)
//        {
//            origin = pt;
//            width = w;
//            height = h;
//        }

//        public object Clone()
//        {
//            Rect t = (Rect)this.MemberwiseClone();
//            t.origin = (Point)t.origin.Clone();  //깊은 복사 하기위해서는 꼭 Clone 이 있어야함.
//            return t;
//        }

//        public void SetPos(int x, int y)
//        {
//            origin.X = x;
//            origin.Y = y;
//        }
//        public override string ToString()
//        {
//            return $"{origin.ToString()} w:{width}, h: {height}";
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Rect r1 = new Rect(new Point(0, 0), 100, 100);
//            Rect r2 = (Rect)r1.Clone();
//            r2.SetPos(2, 2);

//            Console.WriteLine(r1);
//            Console.WriteLine(r2);
//        }
//    }
//}

//using System;
//using System.Linq;

//namespace ex220708
//{
//    class Point : object, ICloneable
//    {
//        public int X { get; set; }
//        public int Y { get; set; } //자동 속성이라고 부름

//        public Point(int x = 0, int y = 0)
//        {
//            X = x;
//            Y = y;
//        }
//        public Point(Point arg)
//        {
//            X = arg.X;
//            Y = arg.Y;
//        }
//        public override string ToString()
//        {
//            return $"({X}, {Y})";
//        }
//        public override bool Equals(object obj)
//        {
//            Point pt = obj as Point;   // as키워드 를 이용해서 다운캐스트 한 것 obj를 포인트로 변환해라 변환 가능하면 변환된 참조를 반환하고 변한 안되면 null을 반환한다.
//            return pt.X == this.X && pt.Y == this.Y;
//        }
//        public override int GetHashCode()
//        {//값이 같으면 hashcode도 같이 만들어줘야 같은 버켓에 담긴다
//            return (X << 3 & Y);  // 2의 3승을 하고 Y값과 앤드를 한당
//            //return (X << 3 ^ Y);  // 2의 3승을 하고 Y값과 익스클루시브 or 를 한당
//        }
//        public object Clone()
//        {
//            return new Point(this);
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Point pt = new Point(1, 2);
//            Point pt2 = new Point { X = 1, Y = 2 };

//            Console.WriteLine(pt.Equals(pt2));                 //true
//            Console.WriteLine(object.Equals(pt, pt2));          //true 
//            Console.WriteLine(object.ReferenceEquals(pt, pt2)); //참조를 반환하기 때문에 얘만 false

//            ICloneable ic = pt2 as ICloneable;  
//            pt = (Point)ic.Clone();
//            pt.X = 10;
//            Console.WriteLine(pt);
//            Console.WriteLine(pt2);
//            Console.WriteLine(object.ReferenceEquals(pt, pt2)); //참조를 반환하기 때문에 얘만 false

//        }
//    }
//}

//using System;
//using System.Linq;

//namespace ex220708
//{
//    class Point : object , ICloneable
//    {
//        public int X { get; set; }
//        public int Y { get; set; } //자동 속성이라고 부름

//        public Point(int x = 0, int y = 0)
//        {
//            X = x;
//            Y = y;
//        }
//        public Point(Point arg)
//        {
//            X = arg.X;
//            Y = arg.Y;
//        }
//        public override string ToString()
//        {
//            return $"({X}, {Y})";
//        }
//        public override bool Equals(object obj)
//        {
//            Point pt = obj as Point;   // as키워드 를 이용해서 다운캐스트 한 것 obj를 포인트로 변환해라 변환 가능하면 변환된 참조를 반환하고 변한 안되면 null을 반환한다.
//            return pt.X == this.X && pt.Y == this.Y;
//        }
//        public override int GetHashCode()
//        {//값이 같으면 hashcode도 같이 만들어줘야 같은 버켓에 담긴다
//            return (X << 3 & Y);  // 2의 3승을 하고 Y값과 앤드를 한당
//            //return (X << 3 ^ Y);  // 2의 3승을 하고 Y값과 익스클루시브 or 를 한당
//        }
//        public object Clone()
//        {
//            return new Point(this); 
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Point pt = new Point(1, 2);
//            Point pt2 = new Point { X = 1, Y = 2 };

//            Console.WriteLine(pt.Equals(pt2));                 //true
//            Console.WriteLine(object.Equals(pt, pt2));          //true 
//            Console.WriteLine(object.ReferenceEquals(pt, pt2)); //참조를 반환하기 때문에 얘만 false

//            pt = pt2.Clone() as Point;
//            pt.X = 10;
//            Console.WriteLine(pt);
//            Console.WriteLine(pt2);
//            Console.WriteLine(object.ReferenceEquals(pt, pt2)); //참조를 반환하기 때문에 얘만 false

//        }
//    }
//}

//using System;
//using System.Linq;

//namespace ex220708
//{
//    class Point : object   // 서비스와 클래스 상속 계층구조를 구성하는 곳에 사용
//    {
//        public int X { get; set; }
//        public int Y { get; set; } //자동 속성이라고 부름

//        public Point(int x = 0, int y = 0)
//        {
//            X = x;
//            Y = y;
//        }
//        public Point(Point arg)
//        {
//            X = arg.X;
//            Y = arg.Y;
//        }
//        public override string ToString()
//        {
//            return $"({X}, {Y})";
//        }
//        public override bool Equals(object obj)
//        {
//            Point pt = obj as Point;   // as키워드 를 이용해서 다운캐스트 한 것 obj를 포인트로 변환해라 변환 가능하면 변환된 참조를 반환하고 변한 안되면 null을 반환한다.
//            return pt.X == this.X && pt.Y == this.Y;
//        }
//        public override int GetHashCode()
//        {//값이 같으면 hashcode도 같이 만들어줘야 같은 버켓에 담긴다
//            return (X << 3 & Y);  // 2의 3승을 하고 Y값과 앤드를 한당
//            //return (X << 3 ^ Y);  // 2의 3승을 하고 Y값과 익스클루시브 or 를 한당
//        }
//        public Point Clone()
//        {
//            return new Point(this);
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Point pt = new Point(1, 2);
//            Point pt2 = new Point { X = 1, Y = 2 };

//            Console.WriteLine(pt.Equals(pt2));                 //true
//            Console.WriteLine(object.Equals(pt, pt2));          //true 
//            Console.WriteLine(object.ReferenceEquals(pt, pt2)); //참조를 반환하기 때문에 얘만 false

//            pt = pt2.Clone();
//            pt.X = 10;
//            Console.WriteLine(pt);
//            Console.WriteLine(pt2);
//            Console.WriteLine(object.ReferenceEquals(pt, pt2)); //참조를 반환하기 때문에 얘만 false

//        }
//    }
//}

//using System;
//using System.Linq;

//namespace ex220708
//{
//    class Point : object   // 서비스와 클래스 상속 계층구조를 구성하는 곳에 사용
//    {
//        public int X { get; set; }
//        public int Y { get; set; } //자동 속성이라고 부름

//        public Point(int x = 0, int y = 0)
//        {
//            X = x;
//            Y = y;
//        }
//        public Point(Point arg)
//        {
//            X = arg.X;
//            Y = arg.Y;
//        }
//        public override string ToString()
//        {
//            return $"({X}, {Y})";
//        }
//        public override bool Equals(object obj)
//        {
//            Point pt = obj as Point;   // as키워드 를 이용해서 다운캐스트 한 것 obj를 포인트로 변환해라 변환 가능하면 변환된 참조를 반환하고 변한 안되면 null을 반환한다.
//            return pt.X == this.X && pt.Y == this.Y;
//        }
//        public override int GetHashCode()
//        {//값이 같으면 hashcode도 같이 만들어줘야 같은 버켓에 담긴다
//            return (X << 3 & Y);  // 2의 3승을 하고 Y값과 앤드를 한당
//            //return (X << 3 ^ Y);  // 2의 3승을 하고 Y값과 익스클루시브 or 를 한당
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Point pt = new Point(1, 2);
//            Point pt2 = new Point { X = 1, Y = 2 };

//            Console.WriteLine(pt.Equals(pt2));                 //true
//            Console.WriteLine(object.Equals(pt, pt2));          //true 
//            Console.WriteLine(object.ReferenceEquals(pt, pt2)); //참조를 반환하기 때문에 얘만 false

//            pt = new Point(pt2);
//            pt.X = 10;
//            Console.WriteLine(pt);
//            Console.WriteLine(pt2);
//            Console.WriteLine(object.ReferenceEquals(pt, pt2)); //참조를 반환하기 때문에 얘만 false

//        }
//    }
//}

//using System;
//using System.Linq;

//namespace ex220708
//{
//    class Point : object   // 서비스와 클래스 상속 계층구조를 구성하는 곳에 사용
//    {
//        public int X { get; set; }
//        public int Y { get; set; } //자동 속성이라고 부름

//        public Point(int x = 0, int y = 0)
//        {
//            X = x;
//            Y = y;
//        }
//        public override string ToString()
//        {
//            return $"({X}, {Y})";
//        }
//        public override bool Equals(object obj)
//        {
//            Point pt = obj as Point;   // as키워드 를 이용해서 다운캐스트 한 것 obj를 포인트로 변환해라 변환 가능하면 변환된 참조를 반환하고 변한 안되면 null을 반환한다.
//            return pt.X == this.X && pt.Y == this.Y;
//        }
//        public override int GetHashCode()
//        {//값이 같으면 hashcode도 같이 만들어줘야 같은 버켓에 담긴다
//            return (X << 3 & Y);  // 2의 3승을 하고 Y값과 앤드를 한당
//            //return (X << 3 ^ Y);  // 2의 3승을 하고 Y값과 익스클루시브 or 를 한당
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Point pt = new Point(1, 2);
//            Point pt2 = new Point { X = 1, Y = 2 };

//            Console.WriteLine(pt.Equals(pt2));                 //true
//            Console.WriteLine(object.Equals(pt,pt2));          //true 
//            Console.WriteLine(object.ReferenceEquals(pt,pt2)); //참조를 반환하기 때문에 얘만 false

//            pt = pt2;
//            pt.X = 10;
//            Console.WriteLine(pt);
//            Console.WriteLine(pt2);
//        }
//    }
//}

//using System;
//using System.Linq;

//namespace ex220708
//{
//    class Point : object   // 서비스와 클래스 상속 계층구조를 구성하는 곳에 사용
//    {
//        public int X { get; set; }
//        public int Y { get; set; } //자동 속성이라고 부름

//        public Point(int x = 0, int y = 0)
//        {
//            X = x;
//            Y = y;
//        }
//        public override string ToString()
//        {
//            return $"({X}, {Y})";
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Point pt = new Point(1, 2);
//            Point pt2 = new Point { X = 3, Y = 4 };

//            pt = pt2;
//            pt.X = 10;
//            Console.WriteLine(pt);
//            Console.WriteLine(pt2);
//        }
//    }
//}

//using System;
//using System.Linq;

//namespace ex220708
//{
//    class Point : object   // 서비스와 클래스 상속 계층구조를 구성하는 곳에 사용
//    {
//        public int X { get; set; }  
//        public int Y { get; set; } //자동 속성이라고 부름

//        public Point(int x = 0, int y = 0)
//        {
//            X = x;
//            Y = y;
//        }
//        public override string ToString()
//        {
//            return $"({X}, {Y})";
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Point pt = new Point(1, 2);
//            Point pt2 = new Point { X = 3, Y = 4 };
//            Console.WriteLine(pt);
//            Console.WriteLine(pt2);
//        }
//    }
//}

//using System;
//using System.Linq;

//namespace ex220708
//{
//    class Point   // 서비스와 클래스 상속 계층구조를 구성하는 곳에 사용
//    {
//        public int X { get; set; }
//        public int Y { get; set; } //자동 속성이라고 부름

//        public override string ToString()
//        {
//            return $"({X}, {Y})";
//        }
//    }
//    struct SPoint   // (데이터로 사용되는 객체를 추상화)
//    {
//        public int X { get; set; }
//        public int Y { get; set; } //자동 속성이라고 부름

//        public SPoint(int x, int y)
//        {
//            X = x;
//            Y = y;
//        }
//        public override string ToString()
//        {
//            return $"({X}, {Y})";
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            SPoint pt = new SPoint(1, 2);
//            SPoint pt2 = pt;

//            pt.X = 10;
//            Console.WriteLine(pt);
//            Console.WriteLine(pt2);
//        }
//    }
//}

//using System;
//using System.Linq;

//namespace ex220708
//{
//    class Point   // 서비스와 클래스 상속 계층구조를 구성하는 곳에 사용
//    {
//        public int X { get; set; }
//        public int Y { get; set; } //자동 속성이라고 부름

//        public override string ToString()
//        {
//            return $"({X}, {Y})";
//        }
//    }
//    struct SPoint   // (데이터로 사용되는 객체를 추상화)
//    {
//        public int X { get; set; }
//        public int Y { get; set; } //자동 속성이라고 부름

//        public SPoint(int x, int y)
//        {
//            X = x;
//            Y = y;
//        }
//        public override string ToString()
//        {
//            return $"({X}, {Y})";
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            SPoint pt = new SPoint(1, 2);
//            //pt.X = 1;
//            //pt.Y = 2;
//            Console.WriteLine(pt);
//        }
//    }
//}

//using System;
//using System.Linq;

//namespace ex220708
//{
//    class Point   // 서비스와 클래스 상속 계층구조를 구성하는 곳에 사용
//    {
//        public int X { get; set; }
//        public int Y { get; set; } //자동 속성이라고 부름

//        public override string ToString()
//        {
//            return $"({X}, {Y})";
//        }
//    }
//    struct SPoint   // (데이터로 사용되는 객체를 추상화)
//    {
//        public int X { get ;set; }
//        public int Y { get ;set; } //자동 속성이라고 부름

//        public SPoint(int x , int y) 
//        {
//            X = x;
//            Y = y;
//        }
//        public override string ToString()
//        {
//            return $"({X}, {Y})";
//        }
//    }
//    class Program
//    { 
//        static void Main(string[] args)
//        {
//            SPoint pt = new SPoint(1,2);


//            Console.WriteLine(pt);
//        }
//    }
//}
