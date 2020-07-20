using System;
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
                Thread.Sleep(500);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread: Start a second thread.");
            Thread t = new Thread(new ThreadStart(ThreadProc));

            t.Start();
            Thread.Sleep(500);

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread: Do some work.");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Main thread: Call Join(), to wait until ThreadProc ends.");
            t.Join();
            Console.WriteLine("Main thread: ThreadProc.Join has returned.  Press Enter to end program.");
            Console.ReadLine();

        }
    }
}
