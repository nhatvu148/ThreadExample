using System;
using System.Diagnostics;
using System.Threading;

namespace ThreadExample
{
    public class Program
    {
        public static void ThreadProc()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                // Yield the rest of the time slice.
                Thread.Sleep(0);
            }
        }
        public static void ExecuteInForeground()
        {
            DateTime start = DateTime.Now;
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Thread {0}: {1}, Priority {2}",
                              Thread.CurrentThread.ManagedThreadId,
                              Thread.CurrentThread.ThreadState,
                              Thread.CurrentThread.Priority);
            do
            {
                Console.WriteLine("Thread {0}: Elapsed {1:N2} seconds",
                                  Thread.CurrentThread.ManagedThreadId,
                                  sw.ElapsedMilliseconds / 1000.0);
                Thread.Sleep(500);
            } while (sw.ElapsedMilliseconds <= 5000);
            sw.Stop();
        }
        private static void ExecuteInBackground()
        {
            DateTime start = DateTime.Now;
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Thread {0}: {1}, Priority {2}",
                              Thread.CurrentThread.ManagedThreadId,
                              Thread.CurrentThread.ThreadState,
                              Thread.CurrentThread.Priority);
            do
            {
                Console.WriteLine("Thread {0}: Elapsed {1:N2} seconds",
                                  Thread.CurrentThread.ManagedThreadId,
                                  sw.ElapsedMilliseconds / 1000.0);
                Thread.Sleep(500);
            } while (sw.ElapsedMilliseconds <= 5000);
            sw.Stop();
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Main thread: Start a second thread.");
            //Thread t = new Thread(new ThreadStart(ThreadProc));

            //t.Start();
            //Thread.Sleep(0);

            //for (int i = 0; i < 4; i++)
            //{
            //    Console.WriteLine("Main thread: Do some work.");
            //    Thread.Sleep(0);
            //}
            //Console.WriteLine("Main thread: Call Join(), to wait until ThreadProc ends.");
            //t.Join();
            //Console.WriteLine("Main thread: ThreadProc.Join has returned.  Press Enter to end program.");
            //Console.ReadLine();

            var th = new Thread(ExecuteInForeground);
            th.Start();
            Thread.Sleep(1000);
            Console.WriteLine("Main thread ({0}) exiting...",
                              Thread.CurrentThread.ManagedThreadId);

            var th2 = new Thread(ExecuteInForeground);
            th2.IsBackground = true;
            th2.Start();
            Thread.Sleep(1000);
            Console.WriteLine("Main thread ({0}) exiting...",
                              Thread.CurrentThread.ManagedThreadId);
        }
    }
}
