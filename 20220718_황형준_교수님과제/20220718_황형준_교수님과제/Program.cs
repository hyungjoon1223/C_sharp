
//using System;
//using System.Diagnostics;

//namespace _20220718_황형준_교수님과제
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Stopwatch st1 = new Stopwatch();
//            st1.Start();

//            long count = 0;
//            long sum = 0;

//            while (count < 100_000_000)
//            {
//                count++;
//                sum += count;
//            }
//            st1.Stop();
//            long ms1 = st1.ElapsedMilliseconds;

//            Console.WriteLine($"1 ~ 1,000,000,000 더한 값 실행시간 : " +
//                $"{ms1} 밀리초");
//            Console.WriteLine($"누산 값: {sum}");
//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;     //제어를 사용해야할때
using System.Threading.Tasks;  //제어없이 사용해도 될때

//2 - 3 순서제어
namespace AsyncApp
{
    class NumberCounter    //heap에 생성된 객체
    {
        AutoResetEvent auto;

        public NumberCounter(AutoResetEvent ar)
        {
            auto = ar;
        }

        public void Run()
        {
            Console.WriteLine("start : {0}", Thread.CurrentThread.ManagedThreadId);
            while (true)
            {
                auto.WaitOne();
                for (int i = 0; i < 50; ++i)
                {
                    Console.WriteLine();
                    Console.WriteLine("Thread [{0}] ", Thread.CurrentThread.ManagedThreadId);
                    Console.WriteLine("        {0}", i);
                    Thread.Sleep(500);
                }
                auto.Set();
            }
            Console.WriteLine("end : {0}", Thread.CurrentThread.ManagedThreadId);

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            AutoResetEvent a = new AutoResetEvent(true);

            NumberCounter nc1 = new NumberCounter(a);  //nc = 공유객체
            NumberCounter nc2 = new NumberCounter(a);  //nc2 = 공유객체
            NumberCounter nc3 = new NumberCounter(a);  //nc2 = 공유객체

            Thread[] tArray = new Thread[] { new Thread(new ThreadStart(nc1.Run)), new Thread(nc2.Run), new Thread(nc3.Run) };
            for (int i = 0; i < tArray.Length; ++i)
                tArray[i].Start();

            while (true)
            {
                Console.ReadLine();
                a.Set();
            }
            Console.WriteLine("end Main()");
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace _20220718_황형준_교수님과제
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
//                for (int i = 0; i < 10_000_000; ++i)
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