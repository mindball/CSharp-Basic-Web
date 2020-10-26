﻿using System;
using System.Threading.Tasks;

namespace CSharpcornerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CallMethod();

            ReadAllTextDemo demo = new ReadAllTextDemo();

            demo.CallMethod();

            Console.ReadKey();
        }

        public static async void CallMethod()
        {
            Task<int> task = Method1();
            Method2();
            int count = await task;
            Method3(count);
        }

        public static async Task<int> Method1()
        {
            int count = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine(" Method 1");
                    count += 1;
                }
            });
            return count;
        }

        public static void Method2()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(" Method 2");
            }
        }

        public static void Method3(int count)
        {
            Console.WriteLine("Total count is " + count);
        }

    }
}
