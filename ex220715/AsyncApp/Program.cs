using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;     //제어를 사용해야할때
using System.Threading.Tasks;  //제어없이 사용해도 될때



//2 - 2 순서제어
namespace AsyncApp
{
    class NumberCounter    //heap에 생성된 객체
    {
        AutoResetEvent auto;

        public NumberCounter(AutoResetEvent ar)
        {
            auto = ar;
        }
        int count = 0;

        public void Run()
        {
            Console.WriteLine("start : {0}", Thread.CurrentThread.ManagedThreadId);
            for (int k = 0; k < 10; ++k)
            {
                auto.WaitOne();
                for (int i = 0; i < 10_000_000; ++i)
                {

                    lock (this)
                    {
                        ++this.count;
                    }
                }
                Console.WriteLine("[{0}] : count - {1}", Thread.CurrentThread.ManagedThreadId, count);
            }
            Console.WriteLine("end : {0}", Thread.CurrentThread.ManagedThreadId);

        }
        public int Count { get { return count; } }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            AutoResetEvent a = new AutoResetEvent(false);

            NumberCounter nc1 = new NumberCounter(a);  //nc = 공유객체
            NumberCounter nc2 = new NumberCounter(a);  //nc2 = 공유객체
            NumberCounter nc3 = new NumberCounter(a);  //nc2 = 공유객체

            Thread[] tArray = new Thread[] { new Thread(new ThreadStart(nc1.Run)), new Thread(nc2.Run), new Thread(nc3.Run) };
            for (int i = 0; i < tArray.Length; ++i)
                tArray[i].Start();

            while (true)
            {
                Console.Write("Thread 실행 : ");
                Console.ReadLine();
                a.Set();
            }
            Console.WriteLine("end Main() : count - {0} {1} {2}", nc1.Count, nc2.Count, nc3.Count);
        }

    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;     //제어를 사용해야할때
//using System.Threading.Tasks;  //제어없이 사용해도 될때

////2 - 3 순서제어
//namespace AsyncApp
//{
//    class NumberCounter    //heap에 생성된 객체
//    {
//        AutoResetEvent auto;

//        public NumberCounter(AutoResetEvent ar)
//        {
//            auto = ar;
//        }

//        public void Run()
//        {
//            Console.WriteLine("start : {0}", Thread.CurrentThread.ManagedThreadId);
//            while (true)
//            {
//                auto.WaitOne();
//                for (int i = 0; i < 10; ++i)
//                {
//                    Console.WriteLine("[{0}] : count - {1}", Thread.CurrentThread.ManagedThreadId, i);
//                    Thread.Sleep(100);
//                }
//                auto.Set();
//            }
//            Console.WriteLine("end : {0}", Thread.CurrentThread.ManagedThreadId);

//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            AutoResetEvent a = new AutoResetEvent(true);

//            NumberCounter nc1 = new NumberCounter(a);  //nc = 공유객체
//            NumberCounter nc2 = new NumberCounter(a);  //nc2 = 공유객체
//            NumberCounter nc3 = new NumberCounter(a);  //nc2 = 공유객체

//            Thread[] tArray = new Thread[] { new Thread(new ThreadStart(nc1.Run)), new Thread(nc2.Run), new Thread(nc3.Run) };
//            for (int i = 0; i < tArray.Length; ++i)
//                tArray[i].Start();

//            while (true)
//            {
//                Console.ReadLine();
//                a.Set();
//            }
//            Console.WriteLine("end Main()");
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;     //제어를 사용해야할때
//using System.Threading.Tasks;  //제어없이 사용해도 될때



////2 - 2 순서제어
//namespace AsyncApp
//{
//    class NumberCounter    //heap에 생성된 객체
//    {
//        AutoResetEvent auto;

//        public NumberCounter(AutoResetEvent ar)
//        {
//            auto = ar;
//        }
//        int count = 0;

//        public void Run()
//        {
//            Console.WriteLine("start : {0}", Thread.CurrentThread.ManagedThreadId);
//            for (int k = 0; k < 10; ++k)
//            {
//                auto.WaitOne();
//                for (int i = 0; i < 1_000_000; ++i)
//                {

//                    lock (this)
//                    {
//                        ++this.count;
//                    }
//                }
//                Console.WriteLine("[{0}] : count - {1}", Thread.CurrentThread.ManagedThreadId, count);
//            }
//            Console.WriteLine("end : {0}", Thread.CurrentThread.ManagedThreadId);

//        }
//        public int Count { get { return count; } }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            AutoResetEvent a = new AutoResetEvent(false);

//            NumberCounter nc1 = new NumberCounter(a);  //nc = 공유객체
//            NumberCounter nc2 = new NumberCounter(a);  //nc2 = 공유객체
//            NumberCounter nc3 = new NumberCounter(a);  //nc2 = 공유객체

//            Thread[] tArray = new Thread[] { new Thread(new ThreadStart(nc1.Run)), new Thread(nc2.Run), new Thread(nc3.Run) };
//            for (int i = 0; i < tArray.Length; ++i)
//                tArray[i].Start();

//            while (true)
//            {
//                Console.Write("Thread 실행 : ");
//                Console.ReadLine();
//                a.Set();
//            }
//            Console.WriteLine("end Main() : count - {0} {1} {2}", nc1.Count, nc2.Count, nc3.Count);
//        }

//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace AsyncApp
//{
//    class NumberCounter
//    {
//        //static object key = new object();
//        int count = 0;
//        AutoResetEvent startAutoReset;
//        AutoResetEvent endAutoReset;
//        public NumberCounter(AutoResetEvent ar1, AutoResetEvent ar2)
//        {
//            startAutoReset = ar1;
//            endAutoReset = ar2;
//        }
//        public void Run()
//        {
//            startAutoReset.WaitOne();
//            Console.WriteLine("Start : {0}", Thread.CurrentThread.ManagedThreadId);
//            //object key = new object();
//            for (int i = 0; i < 1_000_000; ++i)
//            {
//                lock (this/*key*/)
//                {
//                    ++this.count;
//                }
//            }
//            Console.WriteLine("End : {0}", Thread.CurrentThread.ManagedThreadId);
//            endAutoReset.Set();
//        }
//        public int Count { get { return count; } }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            AutoResetEvent a1 = new AutoResetEvent(true);
//            AutoResetEvent a2 = new AutoResetEvent(false);
//            AutoResetEvent a3 = new AutoResetEvent(false);
//            AutoResetEvent m = new AutoResetEvent(false);

//            NumberCounter nc1 = new NumberCounter(a1, a2);
//            NumberCounter nc2 = new NumberCounter(a2, a3);
//            NumberCounter nc3 = new NumberCounter(a3, m);

//            Thread[] tArray = new Thread[] { new Thread(new ThreadStart(nc1.Run)),
//                new Thread(nc2.Run),
//                new Thread(nc3.Run)};
//            for (int i = 0; i < tArray.Length; ++i)
//                tArray[i].Start();

//            //for (int i = 0; i < tArray.Length; ++i)
//            //    tArray[i].Join();
//            m.WaitOne();

//            Console.WriteLine("end Main() : count - {0} {1} {2}", nc1.Count, nc2.Count, nc3.Count);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;


//namespace AsyncApp
//{
//    class NumberCounter
//    {

//        int count = 0;
//        public AutoResetEvent startAutoReset;
//        public AutoResetEvent endAutoReset;
//        public NumberCounter(AutoResetEvent ar1, AutoResetEvent ar2) 
//        {
//            startAutoReset = ar1;
//            endAutoReset = ar2; 
//        }
//        public void Run()
//        {
//            startAutoReset.WaitOne(); //이벤트 대기하는 함수
//            Console.WriteLine("Start : {0}", Thread.CurrentThread.ManagedThreadId);
//            endAutoReset.Set();
//            for (int i = 0; i < 1_000_000; ++i)
//            {
//                lock (this)
//                {
//                    ++this.count;
//                }
//            }
//            Console.WriteLine("End : {0}", Thread.CurrentThread.ManagedThreadId);
//        }
//        public int Count { get { return count; } }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            AutoResetEvent a1 = new AutoResetEvent(true);
//            AutoResetEvent a2 = new AutoResetEvent(false);
//            AutoResetEvent a3 = new AutoResetEvent(false);
//            AutoResetEvent m = new AutoResetEvent(false);

//            NumberCounter nc1 = new NumberCounter(a1,a2);
//            NumberCounter nc2 = new NumberCounter(a2,a3);
//            NumberCounter nc3 = new NumberCounter(a3,m);

//            Thread[] tArray = new Thread[] { new Thread(new ThreadStart(nc1.Run)), new Thread(nc2.Run), new Thread(nc3.Run) };

//            for (int i = 0; i < tArray.Length; ++i)
//                tArray[i].Start();

//            m.WaitOne();
//            Console.WriteLine("end Main() : count - {0} {1} {2}",nc1.Count, nc2.Count, nc3.Count);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;


//namespace AsyncApp
//{
//    class NumberCounter
//    {

//        int count = 0;
//        public AutoResetEvent autoReset;
//        public NumberCounter(AutoResetEvent ar) { autoReset = ar; }
//        public void Run()
//        {
//            autoReset.WaitOne(); //이벤트 대기하는 함수
//            Console.WriteLine("Start : {0}", Thread.CurrentThread.ManagedThreadId);
//            for (int i = 0; i < 1_000_000; ++i)
//            {
//                lock (this)
//                {
//                    ++this.count;
//                }
//            }
//            Console.WriteLine("End : {0}", Thread.CurrentThread.ManagedThreadId);
//        }
//        public int Count { get { return count; } }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            AutoResetEvent a1 = new AutoResetEvent(false);
//            AutoResetEvent a2 = new AutoResetEvent(false);
//            AutoResetEvent a3 = new AutoResetEvent(false);

//            NumberCounter nc1 = new NumberCounter(a1);
//            NumberCounter nc2 = new NumberCounter(a2);
//            NumberCounter nc3 = new NumberCounter(a3);

//            Thread[] tArray = new Thread[] { new Thread(new ThreadStart(nc1.Run)), new Thread(nc2.Run), new Thread(nc3.Run) };

//            for (int i = 0; i < tArray.Length; ++i)
//                tArray[i].Start();

//            Console.WriteLine("end Main() ");
//            Console.ReadLine();
//            a1.Set();
//            Console.ReadLine();
//            a2.Set();
//            Console.ReadLine();
//            a3.Set();
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;


//namespace AsyncApp
//{
//    class NumberCounter
//    {
//        int count = 0;
//        public void Run()
//        {
//            for (int i = 0; i < 1_000_000; ++i)
//            {
//                lock (this)
//                {
//                    ++this.count;
//                }
//            }
//        }
//        public int Count { get { return count; } }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            NumberCounter nc = new NumberCounter();
//            NumberCounter nc2 = new NumberCounter();

//            Thread[] tArray = new Thread[5] { new Thread(new ThreadStart(nc.Run)), new Thread((nc.Run)), new Thread((nc.Run)), new Thread(nc2.Run), new Thread(nc2.Run) };

//            for (int i = 0; i < tArray.Length; ++i)
//                tArray[i].Start();

//            for (int i = 0; i < tArray.Length; ++i)
//                tArray[i].Join();

//            Console.WriteLine("count : {0}", nc.Count);
//            Console.WriteLine("count : {0}", nc2.Count);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;


//namespace AsyncApp
//{
//    class NumberCounter
//    {
//        int count = 0;
//        public void Run()
//        {
//            for (int i = 0; i < 1_000_000; ++i)
//            {
//                lock (this) 
//                {
//                    ++this.count;
//                }
//            }
//        }
//        public int Count { get { return count; } }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            NumberCounter nc = new NumberCounter();
//            Thread[] tArray = new Thread[3] { new Thread(new ThreadStart(nc.Run)), new Thread((nc.Run)), new Thread((nc.Run)) };

//            for (int i = 0; i < tArray.Length; ++i)
//                tArray[i].Start();

//            for (int i = 0; i < tArray.Length; ++i)
//                tArray[i].Join();

//            Console.WriteLine("count : {0}", nc.Count);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;     
//using System.Threading.Tasks;


//namespace AsyncApp
//{
//    class NumberCounter
//    {
//        int count = 0;
//        public void Run()
//        {
//            for (int i = 0; i < 1_000_000; ++i)
//                ++count;
//        }
//        public int Count{get {return count;} }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            NumberCounter nc = new NumberCounter();
//            nc.Run();
//            nc.Run();
//            nc.Run();

//            Console.WriteLine("count : {0}", nc.Count);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;     //제어를 사용해야할때
//using System.Threading.Tasks;  //제어없이 사용해도 될때


////1-6-1번
//namespace AsyncApp
//{
//    internal class Program
//    {
//        static object key = new object();

//        static void ThreadFunc(object num)
//        {
//            Data ThreadNum = num as Data;
//            for (int i = 0; i < 10; ++i)
//            {
//                int inum = 0;
//                lock (key)
//                {
//                    inum = ThreadNum.Number;    //읽는곳
//                }
//                string sNum = inum.ToString();
//                Console.WriteLine("[{0}] - thread : {1}", ThreadNum, i);
//                Thread.Sleep(1000);
//            }
//        }
//        class Data
//        {
//            public int Number { get; set; }
//            public override string ToString()
//            {
//                return Number.ToString();
//            }
//        }

//        static void Main(string[] args)
//        {
//            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
//            Thread t = new Thread(new ParameterizedThreadStart(ThreadFunc));   // 리턴타입 void 인수가 없는 형태임  --> 인수를 받기위해 delegate 생성
//            Thread t2 = new Thread(new ParameterizedThreadStart(ThreadFunc));  //  리턴타입 void 인수가 없는 형태임  --> 인수를 받기위해 delegate 생성

//            Data num = new Data { Number = 1 };
//            t.Start(num);   //1번 Thread 실행 // t.Start(1);
//                            // 공유하는 연산이기 때문에  lock을 걸어야한다. ---> 읽는곳
//            lock (key)
//            {
//                num.Number = 2;
//            }

//            t2.Start(num);  //2번 Thread 실행

//            Console.WriteLine("end main()");
//            Console.ReadLine();

//            lock (key)
//            {
//                num.Number = 3;

//            }

//            //num = new Data { Number = 2 };

//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace AsyncApp
//{
//    class Program
//    {
//        static object key = new object();
//        static void ThreadFunc(object num)
//        {
//            Data threadNum = num as Data;
//            for (int i = 0; i < 1_000_000; ++i)
//            {
//                lock (key)
//                {
//                    ++threadNum.Number;  //공유 객체 lock실행동안에는 이 안에걸 절대 건들 수 없음 대신 성능이 안좋다
//                }
//            }
//        }
//        class Data
//        {
//            public int Number { get; set; }
//            public override string ToString()
//            {
//                return Number.ToString();
//            }
//        }
//        static void Main(string[] args)
//        {
//            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
//            Thread t1 /*스레드객체화*/= new Thread(new ParameterizedThreadStart(ThreadFunc));    //스레드 객체   
//            Thread t2 = new Thread(new ParameterizedThreadStart(ThreadFunc));

//            Data num = new Data { Number = 0 };
//            t1.Start(num);
//            t2.Start(num);

//            t1.Join();
//            t2.Join();

//            Console.WriteLine("Number Count : {0}", num.Number);
//            Console.ReadLine();
//            (num as Data).Number = 3;
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace AsyncApp
//{
//    class Program
//    {
//        static object key = new object();
//        static void ThreadFunc(object num)
//        {
//            Data threadNum = num as Data;
//            for (int i = 0; i < 1_000_000; ++i)
//            {
//                lock (key)
//                {
//                    ++threadNum.Number;
//                }
//            }
//        }
//        class Data
//        {
//            public int Number { get; set; }
//            public override string ToString()
//            {
//                return Number.ToString();
//            }
//        }
//        static void Main(string[] args)
//        {
//            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
//            Thread t1 /*스레드객체화*/= new Thread(new ParameterizedThreadStart(ThreadFunc));    //스레드 객체   
//            Thread t2 = new Thread(new ParameterizedThreadStart(ThreadFunc));

//            Data num = new Data { Number = 0 };
//            t1.Start(num);
//            t2.Start(num);

//            t1.Join();
//            t2.Join();

//            Console.WriteLine("Number Count : {0}", num.Number);
//            Console.ReadLine();
//            (num as Data).Number = 3;
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace AsyncApp
//{
//    class Program
//    {
//        static void ThreadFunc(object num)
//        {
//            object threadNum = num;
//            for (int i/*스택변수*/ = 0; i < 10; ++i)
//            {
//                Console.WriteLine("[{0}]-thread : {1}", threadNum, i);
//                Thread.Sleep(1000);
//            }
//        }
//        class Data
//        {
//            public int Number { get; set; }
//            public override string ToString()
//            {
//                return Number.ToString();
//            }
//        }
//        static void Main(string[] args)
//        {
//            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
//            Thread t1 /*스레드객체화*/= new Thread(new ParameterizedThreadStart(ThreadFunc));    //스레드 객체   
//            Thread t2 = new Thread(new ParameterizedThreadStart(ThreadFunc));

//            object num = new Data { Number = 1 };
//            t1.Start(num);
//            num = new Data { Number =2};
//            t2.Start(num);

//            Console.WriteLine("end Main()");
//            Console.ReadLine();
//            (num as Data).Number = 3;
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace AsyncApp
//{
//    class Program
//    {
//        static void ThreadFunc(object num)
//        {
//            object threadNum = num;
//            for (int i/*스택변수*/ = 0; i < 10; ++i)
//            {
//                Console.WriteLine("[{0}]-thread : {1}", threadNum, i);
//                Thread.Sleep(1000);
//            }
//        }
//        class Data
//        {
//            public int Number { get; set; }
//            public override string ToString()
//            {
//                return Number.ToString();
//            }
//        }
//        static void Main(string[] args)
//        {
//            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
//            Thread t1 /*스레드객체화*/= new Thread(new ParameterizedThreadStart(ThreadFunc));    //스레드 객체   
//            Thread t2 = new Thread(new ParameterizedThreadStart(ThreadFunc));

//            object num = new Data { Number = 1 };
//            t1.Start(num);
//            ((Data)num).Number = 2;
//            t2.Start(num);

//            Console.WriteLine("end Main()");
//            Console.ReadLine();
//            (num as Data).Number = 3;
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace AsyncApp
//{
//    class Program
//    {
//        static void ThreadFunc(object num)
//        {
//            object threadNum = num;
//            for (int i = 0; i < 10; i++)
//            {
//                Console.WriteLine("[{0}]-thread : {1} ", threadNum, i);
//                Thread.Sleep(1000);
//            }
//        }
//        static void Main(string[] args)
//        {
//            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
//            Thread t1 = new Thread(new ParameterizedThreadStart(ThreadFunc));
//            Thread t2 = new Thread(new ParameterizedThreadStart(ThreadFunc));

//            t1.IsBackground = true;
//            t2.IsBackground = true;

//            object num = 1;
//            t1.Start(num);
//            num = 2;
//            t2.Start(2);

//            Console.WriteLine("end Main()");
//            Console.ReadLine();

//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace AsyncApp
//{
//    class Program
//    {
//        static void ThreadFunc(object num)
//        {
//            int threadNum = (int)num;
//            for (int i = 0; i < 10; i++)
//            {
//                Console.WriteLine("[{0}]-thread : {1} ", threadNum, i);
//                Thread.Sleep(1000);
//            }
//        }
//        static void Main(string[] args)
//        {
//            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
//            Thread t1 = new Thread(new ParameterizedThreadStart(ThreadFunc));
//            Thread t2 = new Thread(new ParameterizedThreadStart(ThreadFunc));

//            t1.IsBackground = true;
//            t2.IsBackground = true;

//            t1.Start(1);
//            t2.Start(2);

//            Console.WriteLine("end Main()");
//            Console.ReadLine();
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace AsyncApp
//{
//    class Program
//    {
//        static void ThreadFunc(int num)
//        {
//            for (int i = 0; i < 10; i++)
//            {
//                Console.WriteLine("[{1}]-thread : {0} ", i, Thread.CurrentThread.ManagedThreadId);
//                Thread.Sleep(1000);
//            }
//        }
//        static void Main(string[] args)
//        {
//            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
//            Thread t1 = new Thread(new ThreadStart(ThreadFunc));
//            Thread t2 = new Thread(new ThreadStart(ThreadFunc));

//            t1.IsBackground = true;
//            t2.IsBackground = true;

//            t1.Start();
//            t2.Start();

//            Console.WriteLine("end Main()");
//            Console.ReadLine();
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace AsyncApp
//{
//    class Program
//    {
//        static void ThreadFunc()
//        {
//            for (int i = 0; i < 10; i++)
//            {
//                Console.WriteLine("[{1}]-thread : {0} ", i, Thread.CurrentThread.ManagedThreadId);
//                Thread.Sleep(1000);
//            }
//        }
//        static void Main(string[] args)
//        {
//            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
//            Thread t1 = new Thread(new ThreadStart(ThreadFunc));
//            Thread t2 = new Thread(new ThreadStart(ThreadFunc));

//            t1.IsBackground = true;
//            t2.IsBackground = true;

//            t1.Start();
//            t2.Start();

//            Console.WriteLine("end Main()");
//            Console.ReadLine();
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace AsyncApp
//{
//    class Program
//    { 
//        static void ThreadFunc()
//        {
//            for (int i = 0; i < 10; i++)
//            {
//                Console.WriteLine("[{1}]-thread : {0} ", i, Thread.CurrentThread.ManagedThreadId);
//                Thread.Sleep(1000);
//            }
//        }
//        static void Main(string[] args)
//        {
//            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
//            Thread t = new Thread(new ThreadStart(ThreadFunc));

//            t.Start();
//            ThreadFunc();

//            Console.WriteLine("end Main()");
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace AsyncApp
//{
//    class Program
//    {
//        static void ThreadFunc()
//        {
//            for (int i = 0; i < 10; i++)
//            {
//                Console.WriteLine("[{1}]-thread : {0} ", i,Thread.CurrentThread.ManagedThreadId);
//            }
//        }    
//        static void Main(string[] args)
//        {
//            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
//            Thread t = new Thread(new ThreadStart(ThreadFunc));

//            t.Start();
//            ThreadFunc();

//            Console.WriteLine("end Main()");
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace AsyncApp
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
//        }
//    }
//}
