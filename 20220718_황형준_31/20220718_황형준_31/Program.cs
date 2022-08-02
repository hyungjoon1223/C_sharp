// 220718 _ 황형준 _ 31
using System;

using System.Threading;


namespace _220718_황형준_31
{
    class Count
    {
        public int c;
    }
    class NumberCounter
    {
        public int MaxNum = 0;
        Count count;
        AutoResetEvent startAutoEvent;
        AutoResetEvent endAutoEvent;
        AutoResetEvent outAutoEvent;
        public NumberCounter(int _MaxNum, AutoResetEvent ar1, AutoResetEvent ar2, AutoResetEvent _m, Count _count)
        { MaxNum = _MaxNum; startAutoEvent = ar1; endAutoEvent = ar2; outAutoEvent = _m; count = _count; }

        public void Run()
        {
            while (true)
            {
                startAutoEvent.WaitOne();
                if (count.c == MaxNum)
                {
                    break;
                }
                Random random = new Random();
                int Num = random.Next(1, 4);
                Console.WriteLine("Thread : {0}", Thread.CurrentThread.ManagedThreadId);
                for (int i = 0; i < Num; ++i)
                {
                    ++count.c;
                    Console.WriteLine("{0}", count.c);

                    if (count.c == MaxNum)
                    {
                        outAutoEvent.Set();
                        break;
                    }
                    Thread.Sleep(500);
                }
                endAutoEvent.Set();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("");
            string a = Console.ReadLine();
            int a2 = Convert.ToInt32(a);
            Console.WriteLine("");
            string b = Console.ReadLine();
            int b2 = Convert.ToInt32(b);
            Count cc = new Count();
            AutoResetEvent[] AutoArray = new AutoResetEvent[a2];
            AutoResetEvent m = new AutoResetEvent(false);

            NumberCounter[] NumArray = new NumberCounter[a2];
            AutoArray[0] = new AutoResetEvent(true);
            Thread[] tArray = new Thread[a2];

            for (int i = 1; i < a2; ++i)
            {
                AutoArray[i] = new AutoResetEvent(false);
            }

            for (int i = 0; i < a2; ++i)
            {
                NumArray[i] = new NumberCounter(b2, AutoArray[i], AutoArray[(i + 1) % a2], m, cc);
                tArray[i] = new Thread(NumArray[i].Run);
            }

            for (int i = 0; i < a2; ++i)
            {
                tArray[i].Start();
                tArray[i].IsBackground = true;
            }
            m.WaitOne();
        }
    }
}
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;     
//using System.Threading.Tasks; 

//namespace _20220718_황형준_31
//{
//    class NumberCounter    
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
//                for (int i = 0; i <= 31; ++i)
//                {
//                    Console.WriteLine();
//                    Console.WriteLine("Thread [{0}] ", Thread.CurrentThread.ManagedThreadId);
//                    Console.WriteLine("        {0}", i);
//                    Thread.Sleep(500);
//                }
//                auto.Set();
//            }
//            Console.WriteLine("end : {0}", Thread.CurrentThread.ManagedThreadId);
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            AutoResetEvent a = new AutoResetEvent(true);
//            AutoResetEvent a2 = new AutoResetEvent(false);
//            AutoResetEvent a3 = new AutoResetEvent(false);

//            NumberCounter nc1 = new NumberCounter(a); 
//            NumberCounter nc2 = new NumberCounter(a);  
//            NumberCounter nc3 = new NumberCounter(a);  
//            NumberCounter nc4 = new NumberCounter(a);  
//            NumberCounter nc5 = new NumberCounter(a);

//            Thread[] tArray = new Thread[] { new Thread(new ThreadStart(nc1.Run)), new Thread(nc2.Run), new Thread(nc3.Run),new Thread(nc4.Run), new Thread(nc5.Run) };
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
