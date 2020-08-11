using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> fruits = new List<string>();
            fruits.Add("Apple");
            fruits.Add("Banana");
            fruits.Add("Bilberry");
            fruits.Add("Blackberry");
            fruits.Add("Blackcurrant");
            fruits.Add("Blueberry");
            fruits.Add("Cherry");
            fruits.Add("Coconut");
            fruits.Add("Cranberry");
            fruits.Add("Date");
            fruits.Add("Fig");
            fruits.Add("Grape");
            fruits.Add("Guava");
            fruits.Add("Jack-fruit");
            fruits.Add("Kiwi fruit");
            fruits.Add("Lemon");
            fruits.Add("Lime");
            fruits.Add("Lychee");
            fruits.Add("Mango");
            fruits.Add("Melon");
            fruits.Add("Olive");
            fruits.Add("Orange");
            fruits.Add("Papaya");
            fruits.Add("Plum");
            fruits.Add("Pineapple");
            fruits.Add("Pomegranate");

            var stopWatch = Stopwatch.StartNew();
            foreach (string fruit in fruits)
            {
                Console.WriteLine("Fruit Name: {0}, Thread Id= {1}", fruit, Thread.CurrentThread.ManagedThreadId);
            }
            Console.WriteLine("foreach loop execution time = {0} seconds\n", stopWatch.Elapsed.TotalSeconds);
            Console.WriteLine("Printing list using Parallel.ForEach");

            stopWatch = Stopwatch.StartNew();
            Parallel.ForEach(fruits, fruit =>
            {
                Console.WriteLine("Fruit Name: {0}, Thread Id= {1}", fruit, Thread.CurrentThread.ManagedThreadId);
            });

            Console.WriteLine("Parallel.ForEach() execution time = {0} seconds", stopWatch.Elapsed.TotalSeconds);
            Console.Read();

            //Task t = Task.Run(() => {
            //    Random rnd = new Random();
            //    long sum = 0;
            //    int n = 5000000;
            //    for (int ctr = 1; ctr <= n; ctr++)
            //    {
            //        int number = rnd.Next(0, 101);
            //        sum += number;
            //    }
            //    Console.WriteLine("Total:   {0:N0}", sum);
            //    Console.WriteLine("Mean:    {0:N2}", sum / n);
            //    Console.WriteLine("N:       {0:N0}", n);
            //});
            //if (!t.Wait(100))
            //    Console.WriteLine("The timeout interval elapsed.");


            //Program pg1 = new Program();
            //Program pg2 = new Program();

            //string _threadOutput = "";

            //Thread thread1 = new Thread(() => pg1.DisplayThread1(ref _threadOutput));

            //thread1.Start();

            //Thread thread2 = new Thread(() => pg2.DisplayThread2(ref _threadOutput));

            //thread2.Start();


            //Thread th = Thread.CurrentThread;
            //th.Name = "Main Thread";
            //for (int i = 0; ; i++)
            //{
            //    Console.WriteLine($"{th.Name} : " + i);
            //    Thread.Sleep(2000);
            //}
        }

        static void Method(int num)
        {
            Thread th = Thread.CurrentThread;
            th.Name = $"Thread {num}";
            for (int i = 0; ; i++)
            {
                Console.WriteLine($"{th.Name}: " + i);
                Thread.Sleep(num*1000);
                if (i == 10)
                {
                    Console.WriteLine($"{th.Name} aborted.");
                    break;
                }
            }
        }

        void DisplayThread1(ref string _threadOutput)
        {
            for (int i = 0; ; i++)
            {
                lock (this)
                {
                    Console.WriteLine("Display Thread 1");
                    _threadOutput = "Hello Thread 1";
                    Console.WriteLine("Thread 1 Output: " + _threadOutput);
                }
            }
        }

        void DisplayThread2(ref string _threadOutput)
        {
            for (int i = 0; ; i++)
            {
                lock (this)
                {
                    Console.WriteLine("Display Thread 2");
                    _threadOutput = "Hello Thread 2";
                    Console.WriteLine("Thread 2 Output: " + _threadOutput);
                }
            }
        }
    }
}
