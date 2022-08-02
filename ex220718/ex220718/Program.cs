//Tasks
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ex220718
{
    class Program
    {
        static async Task f1Async()
        {
            Console.WriteLine("start f1");
            Task t = Task.Delay(1000);
            await t;
            Console.WriteLine("end f1");
        }
        static async Task f2Async()
        {
            Console.WriteLine("start f2");
            await Task.Delay(1000);
            Console.WriteLine("end f2");
        }
        static async Task f3Async()
        {
            Console.WriteLine("start f3");
            await Task.Delay(1000);
            Console.WriteLine("end f3");
        }
        static async Task Main(string[] args)
        {
            int result = await Task.Run(() =>  //Task가 끝나길 기다리는 역할
            {
                Console.WriteLine("return task");
                Task.Delay(3000).Wait();
                return 100;
            });

            //t.Wait();
            Console.WriteLine("{0}", result);
        }
    }
}

////Tasks
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class Program
//    {
//        static async Task f1Async()
//        {
//            Console.WriteLine("start f1");
//            Task t = Task.Delay(1000);
//            await t;
//            Console.WriteLine("end f1");
//        }
//        static async Task f2Async()
//        {
//            Console.WriteLine("start f2");
//            await Task.Delay(1000);
//            Console.WriteLine("end f2");
//        }
//        static async Task f3Async()
//        {
//            Console.WriteLine("start f3");
//            await Task.Delay(1000);
//            Console.WriteLine("end f3");
//        }
//        static void Main(string[] args)
//        {
//            Parallel.For(0, 100_000, async (n) =>
//            {
//                //비동기 I/O 작업 
//                Task.Delay(2000).Wait();
//                Console.WriteLine("{0}-{1}", n, Thread.CurrentThread.ManagedThreadId);

//            });
//            //Console.ReadLine();
//            Console.WriteLine("end Main()");
//        }
//    }
//}

////Tasks
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class Program
//    {
//        static async Task f1Async()
//        {
//            Console.WriteLine("start f1");
//            Task t = Task.Delay(1000);
//            await t;
//            Console.WriteLine("end f1");
//        }
//        static async Task f2Async()
//        {
//            Console.WriteLine("start f2");
//            await Task.Delay(1000);
//            Console.WriteLine("end f2");
//        }
//        static async Task f3Async()
//        {
//            Console.WriteLine("start f3");
//            await Task.Delay(1000);
//            Console.WriteLine("end f3");
//        }
//        static void Main(string[] args)
//        {
//            Parallel.For(0, 100_000, async (n) =>
//            {
//                //비동기 I/O 작업 
//                await Task.Delay(2000);
//                Console.WriteLine("{0}-{1}", n,Thread.CurrentThread.ManagedThreadId);

//            });
//            Console.ReadLine();
//            Console.WriteLine("end Main()");
//        }
//    }
//}

////Tasks
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class Program
//    {
//        static async Task f1Async()
//        {
//            Console.WriteLine("start f1");
//            Task t = Task.Delay(1000);
//            await t;
//            Console.WriteLine("end f1");
//        }
//        static async Task f2Async()
//        {
//            Console.WriteLine("start f2");
//            await Task.Delay(1000);
//            Console.WriteLine("end f2");
//        }
//        static async Task f3Async()
//        {
//            Console.WriteLine("start f3");
//            await Task.Delay(1000);
//            Console.WriteLine("end f3");
//        }
//        static void Main(string[] args)
//        {
//            Task.Run(async () =>
//            {
//                await f1Async();  //비동기 함수
//                await f2Async();
//                await f3Async();
//            }).Wait();
//            Console.WriteLine("end Main()");
//        }
//    }
//}

////Tasks
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class Program
//    {
//        static async Task f1Async()
//        {
//            Console.WriteLine("start f1");
//            Task t = Task.Delay(1000);
//            await t;
//            Console.WriteLine("end f1");
//        }
//        static async Task f2Async()
//        {
//            Console.WriteLine("start f2");
//            await Task.Delay(1000);
//            Console.WriteLine("end f2");
//        }
//        static async Task f3Async()
//        {
//            Console.WriteLine("start f3");
//            await Task.Delay(1000);
//            Console.WriteLine("end f3");
//        }
//        static async Task Main(string[] args)
//        {
//            await Task.Run(async () =>
//            {
//                await f1Async();  //비동기 함수
//                await f2Async();
//                await f3Async();
//            });
//            Console.WriteLine("end Main()");
//        }
//    }
//}

////Tasks
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class Program
//    {
//        static async Task f1Async()
//        {
//            Console.WriteLine("start f1");
//            Task t = Task.Delay(1000);
//            await t;
//            Console.WriteLine("end f1");
//        }
//        static async Task f2Async()
//        {
//            Console.WriteLine("start f2");
//            await Task.Delay(1000);
//            Console.WriteLine("end f2");
//        }
//        static async Task f3Async()
//        {
//            Console.WriteLine("start f3");
//            await Task.Delay(1000);
//            Console.WriteLine("end f3");
//        }
//        static async Task Main(string[] args)
//        {
//            await Task.Run(() =>
//            {
//                var t = f1Async();  //비동기 함수
//                var t2 = f2Async();
//                var t3 = f3Async();
//                Task.WaitAll(t, t2, t3);
//            });

//            Console.WriteLine("end Main()");
//        }
//    }
//}

////Tasks
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class Program
//    {
//        static async Task f1Async()
//        {
//            Console.WriteLine("start f1");
//            Task t = Task.Delay(1000);
//            await t;
//            Console.WriteLine("end f1");
//        }
//        static async Task f2Async()
//        {
//            Console.WriteLine("start f2");
//            await Task.Delay(1000);
//            Console.WriteLine("end f2");
//        }
//        static async Task f3Async()
//        {
//            Console.WriteLine("start f3");
//            await Task.Delay(1000);
//            Console.WriteLine("end f3");
//        }
//        static void Main(string[] args)
//        {
//            Task.Run(() =>
//            {
//                var t = f1Async();  //비동기 함수
//                var t2 = f2Async();
//                var t3 = f3Async();
//                Task.WaitAll(t,t2,t3);
//            }).Wait();

//            Console.WriteLine("end Main()");
//        }
//    }
//}

////Tasks
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class Program
//    {
//        static async Task f1Async()
//        {
//            Console.WriteLine("start f1");
//            Task t = Task.Delay(1000);
//            await t;
//            Console.WriteLine("end f1");
//        }
//        static async Task f2Async()
//        {
//            Console.WriteLine("start f2");
//            await Task.Delay(1000);
//            Console.WriteLine("end f2");
//        }
//        static async Task f3Async()
//        {
//            Console.WriteLine("start f3");
//            await Task.Delay(1000);
//            Console.WriteLine("end f3");
//        }
//        static async Task Main(string[] args)
//        {
//            await f1Async();  //비동기 함수
//            await f2Async();
//            await f3Async();
//            Console.WriteLine("end Main()");
//        }
//    }
//}

////Tasks
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class Program
//    {
//        static async Task Main(string[] args)
//        {
//            await Task.Run(() =>
//            {
//                Console.WriteLine("start task!");
//                Task.Delay(1000).Wait();
//                Console.WriteLine("end task!");
//            });
//            Console.WriteLine("end Main!");
//        }
//    }
//}

////Tasks
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Task.Run(() =>
//            {
//                Console.WriteLine("start task!");
//                Task.Delay(1000).Wait();    
//                Console.WriteLine("end task!");
//            }).Wait();
//            Console.WriteLine("end Main!");
//        }
//    }
//}

////Tasks
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class Program
//    {
//        static async void f1Async()
//        {
//            Console.WriteLine("start f1");
//            Task t = Task.Delay(1000);
//            await t;
//            Console.WriteLine("end f1");
//        }
//        static async void f2Async()
//        {
//            Console.WriteLine("start f2");
//            await Task.Delay(1000);
//            Console.WriteLine("end f2");
//        }
//        static async void f3Async()
//        {
//            Console.WriteLine("start f3");
//            await Task.Delay(1000);
//            Console.WriteLine("end f3");
//        }
//        static void Main(string[] args)
//        {
//            f1Async();  //비동기 함수
//            f2Async();
//            f3Async();
//            Console.WriteLine("end Main()");
//        }
//    }
//}

////Tasks
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class Program
//    {
//        static async void f1Async()
//        {
//            Console.WriteLine("start f1");
//            await Task.Delay(1000);
//            Console.WriteLine("end f1");
//        }
//        static async void f2Async()
//        {
//            Console.WriteLine("start f2");
//            await Task.Delay(1000);
//            Console.WriteLine("end f2");
//        }
//        static async void f3Async()
//        {
//            Console.WriteLine("start f3");
//            await Task.Delay(1000);
//            Console.WriteLine("end f3");
//        }
//        static void Main(string[] args)
//        {
//            f1Async();
//            f2Async();
//            f3Async();
//            Console.WriteLine("end Main()");
//        }
//    }
//}

////Tasks
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Thread.Sleep(1000);
//            Console.WriteLine("Sleep");
//            Task.Delay(1000).Wait();
//            Console.WriteLine("Delay");

//            Console.WriteLine("end Main");
//        }
//    }
//}

////Tasks
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Thread.Sleep(1000);
//            Console.WriteLine("Sleep");
//            Task.Delay(1000).Wait();
//            Console.WriteLine("Delay");

//            Console.WriteLine("end Main");
//        }
//    }
//}

////Tasks
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Thread.Sleep(1000);
//            Console.WriteLine("Sleep");
//            Task t = Task.Delay(1000);
//            Console.WriteLine("Delay");
//            t.Wait();
//            Console.WriteLine("end Main");
//        }
//    }
//}

////Tasks
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] taskInteger = Enumerable.Range(0, 10).Select((n) => 10_000_000 * n + 1).ToArray();

//            long total = 0;
//            Task.Run(() =>
//            {
//                Parallel.ForEach(taskInteger, (num) =>
//                {
//                    Console.WriteLine("{0} : {1}", num, Thread.CurrentThread.ManagedThreadId);
//                    int start = num;
//                    int end = start + 10_000_000;
//                    long sum = 0;
//                    for (int i = start; i < end; ++i)
//                    {
//                        sum += i;
//                        Thread.Sleep(2000);
//                    }
//                    lock (taskInteger)
//                    {
//                        total += sum;
//                    }
//                }); // PARALLEL 은 모든 원소가 끝날때까지 리턴하지않는다. --> 블로킹 함수임!! 10개가 돌고나서 return
//            });

//            for (int i = 0; i < 10; ++i)
//                Console.WriteLine("main run");

//            t.Wait();
//            Console.WriteLine("end Main() : total: {0}", total);

//        }
//    }
//}

////Tasks
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] taskInteger = Enumerable.Range(0, 10).Select((n) => 10_000_000 * n + 1).ToArray();

//            long total = 0;
//            Parallel.ForEach(taskInteger, (num) =>
//            {
//                Console.WriteLine("{0} : {1}", num, Thread.CurrentThread.ManagedThreadId);
//                int start = num;
//                int end = start + 10_000_000;
//                long sum = 0;
//                for (int i = start; i < end; ++i)
//                {
//                    sum += i;
//                    Thread.Sleep(2000);
//                }
//                lock (taskInteger)
//                {
//                    total += sum;
//                }
//            }); // PARALLEL 은 모든 원소가 끝날때까지 리턴하지않는다. --> 블로킹 함수임!! 10개가 돌고나서 return
//            for(int i = 0; i < 10; ++i)
//                Console.WriteLine("Main run");
//            Console.WriteLine("end Main() : total: {0}", total);

//        }
//    }
//}

////Tasks
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] taskInteger = Enumerable.Range(0, 10).Select((n) => 10_000_000 * n + 1).ToArray();

//            long total = 0;
//            Parallel.ForEach(taskInteger, (num) =>
//            {
//                Console.WriteLine("{0} : {1}", num, Thread.CurrentThread.ManagedThreadId);
//                int start = num;
//                int end = start + 10_000_000;
//                long sum = 0;
//                for (int i = start; i < end; ++i)
//                {
//                    sum += i;
//                }
//                lock (taskInteger)
//                {
//                    total += sum;
//                }
//            }); // PARALLEL 은 모든 원소가 끝날때까지 리턴하지않는다. --> 블로킹 함수임!! 10개가 돌고나서 return

//            Console.WriteLine("end Main() : total: {0}", total);

//        }
//    }
//}

////Tasks
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] taskInteger = Enumerable.Range(0, 10).Select((n) => 10_000_000 * n + 1).ToArray();
//            Task[] tasks = new Task[10];
//            long total = 0;
//            tasks[1] = Task.Run(() =>
//            {
//                int start = taskInteger[1];
//                int end = start + 10_000_000;
//                long sum = 0;
//                for (int i = start; i < end; ++i)
//                {
//                    sum += i;
//                }
//                lock (taskInteger)
//                {
//                    total += sum;
//                }
//            });
//            tasks[1] = Task.Run(() =>
//            {
//                int start = taskInteger[1];
//                int end = start + 10_000_000;
//                long sum = 0;
//                for (int i = start; i < end; ++i)
//                {
//                    sum += i;
//                }
//                lock (taskInteger)
//                {
//                    total += sum;
//                }
//            });
//            Task.WaitAll(tasks);
//            Console.WriteLine("End Main() : total{ 0 }", total);

//        }
//    }
//}

////Tasks
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class Program
//    {
//        static void TaskFunc()
//        {
//            for (int i = 0; i < 10; i++)
//            {
//                Thread.Sleep(1000);
//                Console.WriteLine("task2 : {0} - {1}", i, Thread.CurrentThread.ManagedThreadId);
//            }
//        }
//        static void Main(string[] args)
//        {
//            Task.Run(() =>
//            {
//                for (int i = 0; i < 10; i++)
//                {
//                    Thread.Sleep(1000);
//                    Console.WriteLine("task1 : {0} - {1}", i, Thread.CurrentThread.ManagedThreadId);
//                }
//            }).Wait();
//            Task.Run(() =>
//            {
//                for (int i = 0; i < 10; i++)
//                {
//                    Thread.Sleep(700);
//                    Console.WriteLine("task2 : {0} - {1}", i, Thread.CurrentThread.ManagedThreadId);
//                }
//            }).Wait();
//            //Task.WaitAll(t, t2);
//            //Task waitTask = Task.WhenAll(t, t2);
//            waitTask.Wait();
//            Console.WriteLine("end Main()");
//        }
//    }
//}

////Tasks
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class Program
//    {
//        static void TaskFunc()
//        {
//            for (int i = 0; i < 10; i++)
//            {
//                Thread.Sleep(1000);
//                Console.WriteLine("task2 : {0} - {1}", i, Thread.CurrentThread.ManagedThreadId);
//            }
//        }
//        static void Main(string[] args)
//        {
//            Task t = Task.Run(() =>
//            {
//                for (int i = 0; i < 10; i++)
//                {
//                    Thread.Sleep(1000);
//                    Console.WriteLine("task1 : {0} - {1}", i, Thread.CurrentThread.ManagedThreadId);
//                }
//            });
//            Task t2 = Task.Run(() =>
//            {
//                for (int i = 0; i < 10; i++)
//                {
//                    Thread.Sleep(700);
//                    Console.WriteLine("task2 : {0} - {1}", i, Thread.CurrentThread.ManagedThreadId);
//                }
//            });
//            //Task.WaitAll(t, t2);
//            Task waitTask = Task.WhenAll(t, t2);
//            waitTask.Wait();
//            Console.WriteLine("end Main()");
//        }
//    }
//}

////Tasks
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class Program
//    {
//        static void TaskFunc()
//        {
//            for (int i = 0; i < 10; i++)
//            {
//                Thread.Sleep(1000);
//                Console.WriteLine("task2 : {0} - {1}", i, Thread.CurrentThread.ManagedThreadId);
//            }
//        }
//        static void Main(string[] args)
//        {
//            Task t = Task.Run(() =>
//            {
//                for (int i = 0; i < 10; i++)
//                {
//                    Thread.Sleep(1000);
//                    Console.WriteLine("task1 : {0} - {1}", i, Thread.CurrentThread.ManagedThreadId);
//                }
//            });
//            Task t2 = Task.Run(() =>
//            {
//                for (int i = 0; i < 10; i++)
//                {
//                    Thread.Sleep(700);
//                    Console.WriteLine("task2 : {0} - {1}", i, Thread.CurrentThread.ManagedThreadId);
//                }
//            });


//            t.Wait();
//            t2.Wait();
//            Console.WriteLine("end Main()");
//        }
//    }
//}

////Tasks
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class Program
//    {
//        static void TaskFunc()
//        {
//            for (int i = 0; i < 10; i++)
//            {
//                Thread.Sleep(1000);
//                Console.WriteLine("task2 : {0} - {1}", i, Thread.CurrentThread.ManagedThreadId);
//            }
//        }
//        static void Main(string[] args)
//        {
//            Task t = Task.Run(() =>
//            {
//                for (int i = 0; i < 10; i++)
//                {
//                    Thread.Sleep(1000);
//                    Console.WriteLine("task1 : {0} - {1}", i, Thread.CurrentThread.ManagedThreadId);
//                }
//            });

//            Task t2 = Task.Run(TaskFunc);

//            t.Wait();
//            t2.Wait();
//            Console.WriteLine("end Main()");
//        }
//    }
//}

////Tasks
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class Program
//    {
//        static void TaskFunc()
//        {
//            for (int i = 0; i < 10; i++)
//            {
//                Thread.Sleep(1000);
//                Console.WriteLine("task2 : {0} - {1}", i, Thread.CurrentThread.ManagedThreadId);
//            }
//        }
//        static void Main(string[] args)
//        {
//            Task t = Task.Run(() =>
//            {
//                for (int i = 0; i < 10; i++)
//                {
//                    Thread.Sleep(1000);
//                    Console.WriteLine("task1 : {0} - {1}", i, Thread.CurrentThread.ManagedThreadId);
//                }
//            });
//            t.Wait();
//            Console.WriteLine("end Main()");
//        }
//    }
//}

////Tasks
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class Program
//    {
//        static void TaskFunc()
//        {
//            for (int i = 0; i < 10; i++)
//            {
//                Thread.Sleep(1000);
//                Console.WriteLine("task2 : {0} - {1}", i, Thread.CurrentThread.ManagedThreadId);
//            }
//        }
//        static void Main(string[] args)
//        {
//            Task.Run(() =>
//            {
//                for (int i = 0; i < 10; i++)
//                {
//                    Thread.Sleep(1000);
//                    Console.WriteLine("task1 : {0} - {1}", i, Thread.CurrentThread.ManagedThreadId);
//                }
//            });
//            Task.Run(TaskFunc);
//            Thread.Sleep(5000);
//        }
//    }
//}

////Tasks
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class Program
//    {
//        static void TaskFunc()
//        {
//            for (int i = 0; i < 10; i++)
//            {
//                Thread.Sleep(1000);
//                Console.WriteLine("task2 : {0} - {1}", i, Thread.CurrentThread.ManagedThreadId);
//            }
//        }
//        static void Main(string[] args)
//        {
//            Task.Run(() =>
//            {
//                for (int i = 0; i < 10; i++)
//                {
//                    Thread.Sleep(1000);
//                    Console.WriteLine("task1 : {0} - {1}", i, Thread.CurrentThread.ManagedThreadId);
//                }
//            });
//        }
//    }
//}

////Tasks
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class Program
//    {
//        static void TaskFunc()
//        {
//            for (int i = 0; i < 10; i++)
//            {
//                Thread.Sleep(1000);
//                Console.WriteLine("task2 : {0} - {1}", i, Thread.CurrentThread.ManagedThreadId);
//            }
//        }
//        static void Main(string[] args)
//        {
//            Task.Run(() =>
//            {
//                for (int i = 0; i < 10; i++)
//                {
//                    Thread.Sleep(1000);
//                    Console.WriteLine("task1 : {0} - {1}", i, Thread.CurrentThread.ManagedThreadId);
//                }
//            });
//            for(int i = 0; i < 20; i++)
//            {
//                Thread.Sleep(1000);
//                Console.WriteLine("main : {0} - {1}", i, Thread.CurrentThread.ManagedThreadId);
//            }
//            Console.ReadLine();
//        }
//    }
//}

////Tasks
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class Program
//    {
//        static void TaskFunc()
//        {
//            for (int i = 0; i < 10; i++)
//            {
//                Thread.Sleep(1000);
//                Console.WriteLine("task2 : {0} - {1}", i, Thread.CurrentThread.ManagedThreadId);
//            }
//        }
//        static void Main(string[] args)
//        {
//            Task.Run(()=> 
//            {
//                for (int i = 0; i < 10; i++)
//                {
//                    Thread.Sleep(1000);
//                    Console.WriteLine("task1 : {0} - {1}", i, Thread.CurrentThread.ManagedThreadId);
//                }
//            });
//            Task.Run(TaskFunc);
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

//namespace ex220718
//{
//    class MyException : ApplicationException
//    {
//        private string msg;
//        public override string Message { get { return msg; } }
//        public MyException(string m)
//        {
//            msg += "  ";
//            msg += m;
//        }
//    }
//    class TestObject
//    {
//        public void Action()
//        {
//            throw new MyException("연습을 위한 예외!");
//        }
//    }
//    internal class Program
//    {
//        static void DoIt()
//        {
//            TestObject to = new TestObject();
//            to.Action();
//        }
//        static void Main(string[] args)
//        {
//            try
//            {
//                DoIt();
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("예외 처리 메시지 : {0}", e.Message);
//            }
//            finally
//            {
//                Console.WriteLine("항상 처리되는 코드!");
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

//namespace ex220718
//{
//    class MyException : ApplicationException
//    {
//        private string msg;
//        public override string Message { get { return msg; } }
//        public MyException(string m)
//        {
//            msg += "  ";
//            msg += m;
//        }
//    }
//    class TestObject
//    {
//        public void Action()
//        {
//            throw new MyException("연습을 위한 예외!");
//        }
//    }
//    internal class Program
//    {
//        static void DoIt()
//        {
//            TestObject to = new TestObject();
//            to.Action();
//        }
//        static void Main(string[] args)
//        {
//            try
//            {
//                DoIt();
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("예외 처리 메시지 : {0}", e.Message);
//            }
//            finally
//            {
//                Console.WriteLine("항상 처리되는 코드!");
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

//namespace ex220718
//{
//    class MyException : ApplicationException
//    {
//        private string msg;
//        public override string Message { get { return msg; } }
//        public MyException(string m)
//        {
//            msg += "  ";
//            msg += m;
//        }
//    }
//    class TestObject
//    {
//        public void Action()
//        {
//            throw new MyException("연습을 위한 예외!");
//        }
//    }
//    internal class Program
//    {
//        static void DoIt()
//        {
//            TestObject to = new TestObject();
//            to.Action();
//        }
//        static void Main(string[] args)
//        {
//            try
//            {
//                DoIt();
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("예외 처리 메시지 : {0}", e.Message);
//            }
//            finally
//            {
//                Console.WriteLine("항상 처리되는 코드!");
//            }
//        }
//    }
//}

//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//}
//internal class Program
//{
//    static void Main(string[] args)
//    {
//        wtring w1 = 100;
//        wtring w1 = ;"ABC"

//    }
//    int num1 = "0" =;

//        num1 = 0;
//        cnum
//    }
//}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    interface IAdder<in/*반공변성을 지원하는 키워드*/ T>
//    {
//        void Add(T data);
//    }
//    //interface IGetter<out/*공변성을 지원하는 키워드*/ T>
//    {
//        T Get(int idx);
//    }

//    class Parent { }
//    class Child : Parent { }

//    class MyArray<T> : IAdder<T>, IGetter<T>
//    {
//        List<T> lt = new List<T>();
//        public void Add(T data)
//        {
//            lt.Add(data);
//        }

//        public T Get(int idx)
//        {
//            return this[idx];
//        }

//        public T this[int idx] { get { return lt[idx]; } }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            List<Parent> lt = new List<Parent>();
//            lt.Add(new Child());
//            lt.Add(new Child());
//            lt.Add(new Child());

//            IEnumerable<object> ie = lt as IEnumerable<object>;
//            if (ie == null)

//                Console.WriteLine("ie == null");

//            IEnumerator<object> itor = ie.GetEnumerator();
//            while (itor.MoveNext())
//                Console.WriteLine("{0} ", itor.Current);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    interface IAdder<in/*반공변성을 지원하는 키워드*/ T>
//    {
//        void Add(T data);
//    }
//    interface IGetter<out/*공변성을 지원하는 키워드*/ T>
//    {
//        T Get(int idx);
//    }

//    class Parent { }
//    class Child : Parent { }

//    class MyArray<T> : IAdder<T>, IGetter<T>
//    {
//        List<T> lt = new List<T>();
//        public void Add(T data)
//        {
//            lt.Add(data);
//        }

//        public T Get(int idx)
//        {
//            return this[idx];
//        }

//        public T this[int idx] { get { return lt[idx]; } }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            List<Parent> lt = new List<Parent>();
//            lt.Add(new Child());
//            lt.Add(new Child());
//            lt.Add(new Child());

//            IEnumerable<object> ie = lt as IEnumerable<object>;
//            if (ie == null)
//                Console.WriteLine("ie == null");

//            IEnumerator<object> itor = ie.GetEnumerator();
//            while (itor.MoveNext())
//                Console.WriteLine("{0} ", itor.Current);
//        }
//    }
//}

////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading;
////using System.Threading.Tasks;

////namespace ex220718
////{
////    interface IAdder<T>
////    {
////        void Add(T data);
////    }
////    interface IGetter<T>
////    {
////        T Get(int idx);
////    }

////    class Parent { };
////    class Child : Parent { }

////    class MyArray<T> : IAdder<T>, IGetter<T>
////    {
////        List<T> lt = new List<T>();
////        public void Add(T data)
////        {
////            lt.Add(data);
////        }

////        public T Get(int idx)
////        {
////            return this[idx];
////        }

////        public T this[int idx] { get { return lt[idx]; } }
////    }
////    class Program
////    {
////        static void Main(string[] args)
////        {
////            MyArray<Parent> arr = new MyArray<Parent>();
////            arr.Add(new Child());
////            arr.Add(new Child());
////            arr.Add(new Child());

////            Console.WriteLine(arr[0]);
////            Console.WriteLine(arr[1]);
////            Console.WriteLine(arr[2]);
////        }
////    }
////}

////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading;
////using System.Threading.Tasks;

////namespace ex220718
////{
////    class Parent { };
////    class Child : Parent { }
////    class MyArray<T>
////    {
////        List<T> lt = new List<T>();
////        public void Add(T data)
////        {
////            lt.Add(data);
////        }
////        public T this[int idx] { get { return lt[idx]; } }
////    }
////    class Program
////    {
////        static void Main(string[] args)
////        {
////            MyArray<Parent> arr = new MyArray<Parent>();
////            arr.Add(new Child());
////            arr.Add(new Child());
////            arr.Add(new Child());

////            Console.WriteLine(arr[0]);
////            Console.WriteLine(arr[1]);
////            Console.WriteLine(arr[2]);
////        }
////    }
////}

////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading;
////using System.Threading.Tasks;

////namespace ex220718
////{
////    class Parent { };
////    class Child : Parent { }
////    class MyArray<T>
////    {
////        List<T> lt = new List<T>();
////        public void Add(T data)
////        {
////            lt.Add(data);
////        }
////        public T this[int idx] { get { return lt[idx]; } }
////    }
////    class Program
////    {
////        static void Main(string[] args)
////        {
////            MyArray<int> arr = new MyArray<int>();
////            arr.Add(100);
////            arr.Add(200);
////            arr.Add(300);

////            Console.WriteLine(arr[0]);
////            Console.WriteLine(arr[1]);
////            Console.WriteLine(arr[2]);
////        }
////    }
////}

////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading;
////using System.Threading.Tasks;

////namespace ex220718
////{
////    class TotalCounter
////    {
////        private long total;
////        public long Result
////        {
////            get
////            {
////                WaitThread();
////                return total;
////            }
////        }
////        int[] partIntArray;
////        int threadNum;
////        Thread[] tArray;
////        public TotalCounter(int[] parr, int thNum)
////        {
////            total = 0;
////            partIntArray = parr;
////            threadNum = thNum;
////            tArray = new Thread[threadNum];
////            for (int i = 0; i < tArray.Length; i++)
////                tArray[i] = new Thread(new ParameterizedThreadStart(CounterFunc));
////        }
////        private void CounterFunc(object arg)
////        {
////            int start = (int)arg;
////            int end = start + 10_000_000;
////            long sum = 0;
////            for (int i = start; i < end; ++i)
////                sum += i;

////            lock (this) //공유변수는 lock이 있어야함 20번 30번은 정상동작 되겠지만 우연치않게 같이 라이트되면 오류가생김
////            {
////                total += sum;
////            }

////        }
////        public void Run()
////        {
////            for (int i = 0; i < tArray.Length; i++)
////                tArray[i].Start(partIntArray[i]);
////        }
////        private void WaitThread()
////        {
////            for (int i = 0; i < tArray.Length; ++i)
////                tArray[i].Join();
////        }


////    }

////    internal class Program
////    {
////        static void Main(string[] args)
////        {
////            int[] partInt = Enumerable.Range(0, 10).Select((n) => n * 10_000_000 + 1).ToArray();
////            DateTime startTime = DateTime.Now;
////            long total = 0;
////            object key = new object(); 
////            Parallel.ForEach(partInt, (start) =>    //모든 원소에 대해
////            {
////                int end = start + 10_000_000;
////                long sum = 0;
////                for (int i = start; i < end; ++i)
////                    sum += i;

////                lock (key)
////                {
////                    total += sum;
////                }
////            });
////            Console.WriteLine("result : {0} ", total);
////            DateTime endTime = DateTime.Now;
////            Console.WriteLine("endTime-startTime : {0}", endTime-startTime);

////        }
////    }
////}

////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading;
////using System.Threading.Tasks;

////namespace ex220718
////{
////    class TotalCounter
////    {
////        private long total;
////        public long Result 
////        {
////            get 
////            {
////                WaitThread();
////                return total;
////            } 
////        }
////        int[] partIntArray;
////        int threadNum;
////        Thread[] tArray;
////        public TotalCounter(int[] parr, int thNum)
////        {
////            total = 0;
////            partIntArray = parr;
////            threadNum = thNum;
////            tArray = new Thread[threadNum];
////            for(int i = 0; i< tArray.Length; i++)
////                tArray[i] = new Thread(new ParameterizedThreadStart(CounterFunc));
////        }
////        private void CounterFunc(object arg)
////        {
////            int start = (int)arg;
////            int end = start + 10_000_000;
////            long sum = 0;
////            for (int i = start; i < end; ++i)
////                sum += i;

////            lock(this) //공유변수는 lock이 있어야함 20번 30번은 정상동작 되겠지만 우연치않게 같이 라이트되면 오류가생김
////            {
////                total += sum;
////            }

////        }
////        public void Run()
////        {
////            for (int i = 0; i < tArray.Length; i++)
////                tArray[i].Start(partIntArray[i]);
////        }
////        private void WaitThread()
////        {
////            for (int i = 0; i < tArray.Length; ++i)
////                tArray[i].Join();
////        }


////    }

////    internal class Program
////    {
////        static void Main(string[] args)
////        {
////            int[] partInt = Enumerable.Range(0, 10).Select((n) => n * 10_000_000 + 1).ToArray();

////            foreach (var n in partInt)
////                Console.WriteLine(n);

////            DateTime start = DateTime.Now;
////            TotalCounter tc = new TotalCounter(partInt, 10);
////            tc.Run();
////            Console.WriteLine("result : {0}", tc.Result);
////            DateTime end = DateTime.Now;

////            Console.WriteLine("end-start : {0}", end - start);
////        }
////    }
////}

////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading.Tasks;

////namespace ex220718
////{
////    class TotalCounter
////    {
////        public long Result { get; set; }
////        int[] partIntArray;
////        int threadNum;
////        public TotalCounter(int[] parr, int thNum)
////        {
////            partIntArray = parr;
////            threadNum = thNum;
////        }
////        public void Run()
////        {
////            long sum = 0;
////            for (int i = 1; i <= 100_000_000; ++i)
////                sum += i;
////            Result = sum;
////        }
////    }

////    internal class Program
////    {
////        static void Main(string[] args)
////        {
////            int[] partInt = Enumerable.Range(0, 10).Select((n) => n * 10_000_000 + 1).ToArray();

////            foreach (var n in partInt)
////                Console.WriteLine(n);

////            DateTime start = DateTime.Now; 
////            TotalCounter tc = new TotalCounter(partInt, 10);
////            tc.Run();
////            Console.WriteLine("result : {0}", tc.Result);
////            DateTime end = DateTime.Now;

////            Console.WriteLine("end-start : {0}",end-start);
////        }
////    }
////}

////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading.Tasks;

////namespace ex220718
////{
////    internal class Program
////    {
////        static void Main(string[] args)
////        {
////            int[] partInt = Enumerable.Range(0,10).Select((n)=> n * 10_000_000 + 1).ToArray();

////            foreach(var n in partInt)
////                Console.WriteLine(n);
////        }
////    }
////}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    interface IAdder<T>
//    {
//        void Add(T data);
//    }
//    interface IGetter<T>
//    {
//        T Get(int idx);
//    }
//    class Parent { };
//    class Child : Parent { }
//    class MyArray<T> : IAdder<T>, IGetter<T>
//    {
//        List<T> lt = new List<T>();
//        public void Add(T data) { lt.Add(data); }

//        public T this[int idx] { get { return lt[idx]; } }

//        public T Get(int idx)
//        {
//            return this[idx];
//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            MyArray<object> arr = new MyArray<object>();
//            arr.Add(new Child());
//            arr.Add(new Child());
//            arr.Add(new Child());

//            Console.WriteLine(arr[0]);
//            Console.WriteLine(arr[1]);
//            Console.WriteLine(arr[2]);

//            IGetter<Parent> ig = arr as IGetter<Parent>;
//            IAdder<Parent> ia = arr as IAdder<Parent>;

//            //ia.Add(new Child());
//            //Console.WriteLine("{0}", ig.Get(3));
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    interface IAdder<T>
//    {
//        void Add(T data);
//    }
//    interface IGetter<T>
//    {
//        T Get(int idx);
//    }
//    class Parent { };
//    class Child : Parent { }
//    class MyArray<T> : IAdder<T>, IGetter<T>
//    {
//        List<T> lt = new List<T>();
//        public void Add(T data) { lt.Add(data); }

//        public T this[int idx] { get { return lt[idx]; } }

//        public T Get(int idx)
//        {
//            return this[idx];
//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            MyArray<Parent> arr = new MyArray<Parent>();
//            arr.Add(new Child());
//            arr.Add(new Child());
//            arr.Add(new Child());

//            Console.WriteLine(arr[0]);
//            Console.WriteLine(arr[1]);
//            Console.WriteLine(arr[2]);

//            IGetter<Parent> ig = arr as IGetter<Parent>;
//            IAdder<Parent> ia = arr as IAdder<Parent>;

//            ia.Add(new Child());
//            Console.WriteLine("{0}", ig.Get(3));
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    interface IAdder<T>
//    {
//        void Add(T data);
//    }
//    interface IGetter<T>
//    {
//        T Get(int idx);
//    }
//    class Parent { };
//    class Child : Parent { }
//    class MyArray<T> : IAdder<T>, IGetter<T>
//    {
//        List<T> lt = new List<T>();
//        public void Add(T data) { lt.Add(data); }

//        public T this[int idx] { get { return lt[idx]; } }

//        public T Get(int idx)
//        {
//            return this[idx];
//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            MyArray<Parent> arr = new MyArray<Parent>();
//            arr.Add(new Child());
//            arr.Add(new Child());
//            arr.Add(new Child());

//            Console.WriteLine(arr[0]);
//            Console.WriteLine(arr[1]);
//            Console.WriteLine(arr[2]);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    interface IAdder<T>
//    {
//        void Add(T data);
//    }
//    interface IGetter<T>
//    {
//        T Get(int idx);
//    }

//    class Parent { };
//    class Child : Parent { }

//    class MyArray<T> : IAdder<T>, IGetter<T>
//    {
//        List<T> lt = new List<T>();
//        public void Add(T data)
//        {
//            lt.Add(data);
//        }

//        public T Get(int idx)
//        {
//            return this[idx];
//        }

//        public T this[int idx] { get { return lt[idx]; } }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            MyArray<Parent> arr = new MyArray<Parent>();
//            arr.Add(new Child());
//            arr.Add(new Child());
//            arr.Add(new Child());

//            Console.WriteLine(arr[0]);
//            Console.WriteLine(arr[1]);
//            Console.WriteLine(arr[2]);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class Parent { };
//    class Child : Parent { }
//    class MyArray<T>
//    {
//        List<T> lt = new List<T>();
//        public void Add(T data)
//        {
//            lt.Add(data);
//        }
//        public T this[int idx] { get { return lt[idx]; } }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            MyArray<Parent> arr = new MyArray<Parent>();
//            arr.Add(new Child());
//            arr.Add(new Child());
//            arr.Add(new Child());

//            Console.WriteLine(arr[0]);
//            Console.WriteLine(arr[1]);
//            Console.WriteLine(arr[2]);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class Parent { };
//    class Child : Parent { }
//    class MyArray<T>
//    {
//        List<T> lt = new List<T>();
//        public void Add(T data)
//        {
//            lt.Add(data);
//        }
//        public T this[int idx] { get { return lt[idx]; } }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            MyArray<int> arr = new MyArray<int>();
//            arr.Add(100);
//            arr.Add(200);
//            arr.Add(300);

//            Console.WriteLine(arr[0]);
//            Console.WriteLine(arr[1]);
//            Console.WriteLine(arr[2]);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class TotalCounter
//    {
//        private long total;
//        public long Result
//        {
//            get
//            {
//                WaitThread();
//                return total;
//            }
//        }
//        int[] partIntArray;
//        int threadNum;
//        Thread[] tArray;
//        public TotalCounter(int[] parr, int thNum)
//        {
//            total = 0;
//            partIntArray = parr;
//            threadNum = thNum;
//            tArray = new Thread[threadNum];
//            for (int i = 0; i < tArray.Length; i++)
//                tArray[i] = new Thread(new ParameterizedThreadStart(CounterFunc));
//        }
//        private void CounterFunc(object arg)
//        {
//            int start = (int)arg;
//            int end = start + 10_000_000;
//            long sum = 0;
//            for (int i = start; i < end; ++i)
//                sum += i;

//            lock (this) //공유변수는 lock이 있어야함 20번 30번은 정상동작 되겠지만 우연치않게 같이 라이트되면 오류가생김
//            {
//                total += sum;
//            }

//        }
//        public void Run()
//        {
//            for (int i = 0; i < tArray.Length; i++)
//                tArray[i].Start(partIntArray[i]);
//        }
//        private void WaitThread()
//        {
//            for (int i = 0; i < tArray.Length; ++i)
//                tArray[i].Join();
//        }


//    }

//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] partInt = Enumerable.Range(0, 10).Select((n) => n * 10_000_000 + 1).ToArray();
//            DateTime startTime = DateTime.Now;
//            long total = 0;
//            object key = new object(); 
//            Parallel.ForEach(partInt, (start) =>    //모든 원소에 대해
//            {
//                int end = start + 10_000_000;
//                long sum = 0;
//                for (int i = start; i < end; ++i)
//                    sum += i;

//                lock (key)
//                {
//                    total += sum;
//                }
//            });
//            Console.WriteLine("result : {0} ", total);
//            DateTime endTime = DateTime.Now;
//            Console.WriteLine("endTime-startTime : {0}", endTime-startTime);

//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class TotalCounter
//    {
//        private long total;
//        public long Result 
//        {
//            get 
//            {
//                WaitThread();
//                return total;
//            } 
//        }
//        int[] partIntArray;
//        int threadNum;
//        Thread[] tArray;
//        public TotalCounter(int[] parr, int thNum)
//        {
//            total = 0;
//            partIntArray = parr;
//            threadNum = thNum;
//            tArray = new Thread[threadNum];
//            for(int i = 0; i< tArray.Length; i++)
//                tArray[i] = new Thread(new ParameterizedThreadStart(CounterFunc));
//        }
//        private void CounterFunc(object arg)
//        {
//            int start = (int)arg;
//            int end = start + 10_000_000;
//            long sum = 0;
//            for (int i = start; i < end; ++i)
//                sum += i;

//            lock(this) //공유변수는 lock이 있어야함 20번 30번은 정상동작 되겠지만 우연치않게 같이 라이트되면 오류가생김
//            {
//                total += sum;
//            }

//        }
//        public void Run()
//        {
//            for (int i = 0; i < tArray.Length; i++)
//                tArray[i].Start(partIntArray[i]);
//        }
//        private void WaitThread()
//        {
//            for (int i = 0; i < tArray.Length; ++i)
//                tArray[i].Join();
//        }


//    }

//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] partInt = Enumerable.Range(0, 10).Select((n) => n * 10_000_000 + 1).ToArray();

//            foreach (var n in partInt)
//                Console.WriteLine(n);

//            DateTime start = DateTime.Now;
//            TotalCounter tc = new TotalCounter(partInt, 10);
//            tc.Run();
//            Console.WriteLine("result : {0}", tc.Result);
//            DateTime end = DateTime.Now;

//            Console.WriteLine("end-start : {0}", end - start);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    class TotalCounter
//    {
//        public long Result { get; set; }
//        int[] partIntArray;
//        int threadNum;
//        public TotalCounter(int[] parr, int thNum)
//        {
//            partIntArray = parr;
//            threadNum = thNum;
//        }
//        public void Run()
//        {
//            long sum = 0;
//            for (int i = 1; i <= 100_000_000; ++i)
//                sum += i;
//            Result = sum;
//        }
//    }

//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] partInt = Enumerable.Range(0, 10).Select((n) => n * 10_000_000 + 1).ToArray();

//            foreach (var n in partInt)
//                Console.WriteLine(n);

//            DateTime start = DateTime.Now; 
//            TotalCounter tc = new TotalCounter(partInt, 10);
//            tc.Run();
//            Console.WriteLine("result : {0}", tc.Result);
//            DateTime end = DateTime.Now;

//            Console.WriteLine("end-start : {0}",end-start);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220718
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] partInt = Enumerable.Range(0,10).Select((n)=> n * 10_000_000 + 1).ToArray();

//            foreach(var n in partInt)
//                Console.WriteLine(n);
//        }
//    }
//}
