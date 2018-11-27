using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PlayingWithThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            // PlayingWithParallel_listing1_1.startProgram();

            // DO NOT START THIS PROGRAM!!!
            //KillTheMachine.startProgram();

            //PlayingWithThreads.startProgram();

            //PlayingWithParalelleContinuation.startProgram();

            Listing_1_42_Bad_task_interaction.startProgram();

            Console.WriteLine("Main ended. Press a key to end.");
            Console.ReadKey();
        }

        public static class PlayingWithParallel_listing1_1
        {
            static void Task(int sleepTime)
            {
                Console.WriteLine("Task 1 starting, thread: {0}", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(sleepTime);
                Console.WriteLine("Task 1 ending, thread: {0}", Thread.CurrentThread.ManagedThreadId);
            }

            static void Task2()
            {
                Console.WriteLine("Task 2 starting");
                Thread.Sleep(1000);
                Console.WriteLine("Task 2 ending");
            }

            public static void startProgram()
            {
                for (int idx = 0; idx < 10; idx++)
                    Parallel.Invoke(()=>Task(500), ()=>Task(500), ()=>Task(1000));


                Console.WriteLine("Finished processing. Press a key to end.");
                Console.ReadKey();
            }
        }

        public static class PlayingWithParalelleContinuation
        {
            public static void startProgram()
            {
                Task task = Task.Run(() => HelloTask());
                task.ContinueWith((prevTask) => {
                    Console.WriteLine("Continuing from task {0}", prevTask.Id);
                    WorldTask(); });

                Console.WriteLine("Main thread waiting on task.");
                task.Wait();
            }

            static void HelloTask()
            {
                Thread.Sleep(1000);
                Console.WriteLine("Hello");
            }

            static void WorldTask()
            {
                Thread.Sleep(1000);
                Console.WriteLine("World");
            }
        }

        public static class Listing_1_42_Bad_task_interaction
        {
            static long sharedTotal;
            static int[] items = Enumerable.Range(0, 100001).ToArray();
            static object sharedTotalLock = new object();

            static void addRangeofValues(int start, int end)
            {
                while (start < end)
                    lock (sharedTotalLock)  // Crucial line - have to lock something to ensure correct addition.
                    {
                        sharedTotal += items[start++]; 
                    }
            }

            public static void startProgram()
            {
                List<Task> tasks = new List<Task>();
                int rangeSize = 1000;
                int rangeStart = 0;
                while (rangeStart < items.Length)
                {
                    int rangeEnd = rangeStart + rangeSize;
                    if (rangeEnd > items.Length)
                        rangeEnd = items.Length;

                    int rs = rangeStart;
                    int re = rangeEnd;
                    tasks.Add(Task.Run(() => addRangeofValues(rs,re)));
                    rangeStart = rangeEnd;
                }
                Task.WaitAll(tasks.ToArray());
                Console.WriteLine("The total is {0}", sharedTotal);
            }
        }

        public static class PlayingWithThreads
        {
            public static void startProgram()
            {
                Task[] tasks = new Task[10];

                // The following code will yield this output. Problem is, idx changes 
                // before the task is actually started.
                //Starting thread ID 6.Will sleep for 5500ms
                //Starting thread ID 5.Will sleep for 5500ms
                //Starting thread ID 3.Will sleep for 5500ms
                //Starting thread ID 4.Will sleep for 5500ms
                //Starting thread ID 7.Will sleep for 5500ms
                //Starting thread ID 8.Will sleep for 5500ms
                //Starting thread ID 9.Will sleep for 5500ms
                //Starting thread ID 10.Will sleep for 5500ms
                //Starting thread ID 11.Will sleep for 5500ms
                //Ending thread 5
                //Starting thread ID 5.Will sleep for 5500ms
                //Ending thread 6
                //Ending thread 4
                //Ending thread 3
                //Ending thread 7
                //Ending thread 8
                //Ending thread 9
                //Ending thread 10
                //Ending thread 11
                //Ending thread 5

                //for (int idx = 0; idx < tasks.Length; idx++)
                //{
                //    tasks[idx] = new Task(() => TaskTing((idx + 1) * 500));
                //    tasks[idx].Start();
                //}

                // The following code yields this output:
                //Starting thread ID 3.Will sleep for 500ms
                //Starting thread ID 4.Will sleep for 1000ms
                //Starting thread ID 6.Will sleep for 1500ms
                //Starting thread ID 5.Will sleep for 2000ms
                //Ending thread 3
                //Starting thread ID 3.Will sleep for 2500ms
                //Ending thread 4
                //Starting thread ID 4.Will sleep for 3000ms
                //Ending thread 6
                //Starting thread ID 6.Will sleep for 3500ms
                //Ending thread 5
                //Starting thread ID 5.Will sleep for 4000ms
                //Starting thread ID 7.Will sleep for 4500ms
                //Ending thread 3
                //Starting thread ID 3.Will sleep for 5000ms
                //Ending thread 4
                //Ending thread 6
                //Ending thread 5
                //Ending thread 7
                //Ending thread 3
                //Main ended.Press a key to end.
                for (int idx = 0; idx < tasks.Length; idx++)
                {
                    int time = (idx + 1) * 500;
                    tasks[idx] = new Task(() => TaskTing(time));
                    tasks[idx].Start();
                }

                for (int idx = 0; idx < tasks.Length; idx++)
                {
                    tasks[idx].Wait();
                }
            }

            static void TaskTing(int sleep)
            {
                Console.WriteLine($"Starting thread ID {Thread.CurrentThread.ManagedThreadId}. Will sleep for {sleep}ms");
                Thread.Sleep(sleep);
                Console.WriteLine("Ending thread {0}", Thread.CurrentThread.ManagedThreadId);
            }
        }


        // THIS CLASS WILL SPAWN NEW WHILE(TRUE)-THREADS NONE STOP - DO NOT START IT!!!!
        // Well okay, wasn't that bad - windows won't allow it to crash the system, so it's 
        // easy to kill in the task manager (or by closing the console).
        public static class KillTheMachine
        {
            static void InfiniteLoop()
            {
                Console.WriteLine("Thread {0} entering infinite loop... Good luck", Thread.CurrentThread.ManagedThreadId);
                while (true) ;
            }

            public static void startProgram()
            {
                List<Task> taskList = new List<Task>(1000);

                while (true)
                {
                    Task newTask = new Task(()=>InfiniteLoop());
                    newTask.Start();
                    taskList.Add(newTask);
                }
            }
        }
    }
}
